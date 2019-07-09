using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager
{
    public partial class Main : Form
    {
        static System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));

        //正常的图标
        Icon normal = ((System.Drawing.Icon)(resources.GetObject("JackTime2Run.Icon")));
        //灰色的图标
        Icon disabled = ((System.Drawing.Icon)(resources.GetObject("disabled")));
        //报错的图标
        Icon error = ((System.Drawing.Icon)(resources.GetObject("error")));
        string currentIcon = "normal";
        public Main()
        {
            InitializeComponent();
        }

        private static List<JackTime2Run.JackJob> jobs = new List<JackTime2Run.JackJob>();

        /// <summary>安装服务按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 安装_Click(object sender, EventArgs e)
        {
            string startBat = AppDomain.CurrentDomain.BaseDirectory + "setup.bat";
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.FileName = startBat;
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
            }
            catch { }
            finally
            {
                try
                {
                    proc.Close();
                    proc = null;
                    GC.Collect();
                }
                catch { }
            }
        }

        /// <summary>开启服务按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 开启_Click(object sender, EventArgs e)
        {
            StartSrv();
        }

        /// <summary>暂停服务按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 暂停服务_Click(object sender, EventArgs e)
        {
            string startBat = AppDomain.CurrentDomain.BaseDirectory + "pause.bat";
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.FileName = startBat;
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
            }
            catch { }
            finally
            {
                try
                {
                    proc.Close();
                    proc = null;
                    GC.Collect();
                }
                catch { }
            }
        }

        /// <summary>开启服务具体方法
        /// </summary>
        private void StartSrv()
        {
            string startBat = AppDomain.CurrentDomain.BaseDirectory + "start.bat";
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.FileName = startBat;
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
            }
            catch { }
            finally
            {
                try
                {
                    proc.Close();
                    proc = null;
                    GC.Collect();
                }
                catch { }
            }
        }

        /// <summary>停止服务具体方法
        /// </summary>
        private void StopSrv()
        {
            string startBat = AppDomain.CurrentDomain.BaseDirectory + "stop.bat";
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.FileName = startBat;
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
            }
            catch { }
            finally
            {
                try
                {
                    proc.Close();
                    proc = null;
                    GC.Collect();
                }
                catch { }
            }
        }

        /// <summary>停止服务按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 停止服务_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否停止服务,停止服务后将不能定时执行任务?", "停止JackTime2Run?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                StopSrv();
            }
        }

        /// <summary>卸载服务按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 卸载服务_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否卸载服务,卸载服务后将不能使用定时任务功能?", "卸载JackTime2Run?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string startBat = AppDomain.CurrentDomain.BaseDirectory + "uninstall.bat";
                Process proc = null;
                try
                {
                    proc = new Process();
                    proc.StartInfo.FileName = startBat;
                    proc.StartInfo.CreateNoWindow = false;
                    proc.Start();
                    proc.WaitForExit();
                }
                catch { }
                finally
                {
                    try
                    {
                        proc.Close();
                        proc = null;
                        GC.Collect();
                    }
                    catch { }
                }
            }
        }

        /// <summary>刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            _isPollTask = true;//只是设置为true,交由定时刷新去判断
        }

        //手动点击刷新按钮的标志,为true时代表手动触发了刷新按钮(在执行完手动刷新后自动置为false)
        private bool _isPollTask = false;

        /// <summary>刷新定时任务列表方法
        /// </summary>
        private new void Refresh()
        {
            jobs = GetAllTask();
            DataTable dt = CreateDT(jobs);
            this.BeginInvoke((Action)(() =>
            {
                dataGridView1.DataSource = dt;
            }));
        }

        private DataTable CreateDT(List<JackTime2Run.JackJob> tasks)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("序号"));
            dt.Columns.Add(new DataColumn("名称"));
            dt.Columns.Add(new DataColumn("类型"));
            dt.Columns.Add(new DataColumn("配置状态"));
            dt.Columns.Add(new DataColumn("运行状态"));
            dt.Columns.Add(new DataColumn("上次执行"));
            dt.Columns.Add(new DataColumn("下次执行"));
            for (int i = 0; i < tasks.Count; i++)
            {
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);
                row["序号"] = i + 1;
                row["名称"] = tasks[i].Name;
                row["类型"] = tasks[i].JobType;
                row["配置状态"] = tasks[i].Enable;
                row["运行状态"] = tasks[i].State;
                row["上次执行"] = tasks[i].LastDate;
                row["下次执行"] = tasks[i].NextDate;

            }
            return dt;
        }

        //用于循环调用wcf服务的客户端
        JackTime2Run.NamePipeSrvClient cycle_client = new JackTime2Run.NamePipeSrvClient();

        /// <summary>获取完整的任务列表
        /// </summary>
        /// <returns></returns>
        private List<JackTime2Run.JackJob> GetAllTask()
        {
            try
            {
                if (cycle_client.State == System.ServiceModel.CommunicationState.Faulted)
                {
                    cycle_client = new JackTime2Run.NamePipeSrvClient();
                }

                if (cycle_client.State != System.ServiceModel.CommunicationState.Opened)
                {
                    cycle_client.Open();
                }
                JackTime2Run.JackJob[] tasks = cycle_client.GetAllJobs();
                //client.Close();
                //成功返回结果,图标变正常
                if (currentIcon == "disabled")
                {
                    JackTime2Run.Icon = normal;
                    currentIcon = "normal";
                }
                if (tasks == null)
                {
                    MessageBox.Show("拉取当前任务计划失败,服务异常,请查看日志[" + AppDomain.CurrentDomain.BaseDirectory + "log\\SrvManage" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log]", "服务异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkBox1.Checked = false;
                    return new List<JackTime2Run.JackJob>();
                }
                return tasks.ToList();
            }
            catch (Exception ex)
            {
                if (ex is System.ServiceModel.EndpointNotFoundException)
                {
                    MessageBox.Show("拉取当前任务计划失败,请检查是否安装并启动了服务JackTime2Run!", "连接失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }

                this.BeginInvoke((Action)(() =>
                {
                    //出现异常,图标变灰色
                    if (currentIcon == "normal")
                    {
                        JackTime2Run.Icon = disabled;
                        currentIcon = "disabled";
                    }
                    checkBox1.Checked = false;
                }));
                return new List<JackTime2Run.JackJob>();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.DoubleBuffered(true);
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (checkBox1.Checked)
                    {
                        //如果选中了每秒刷新复选框就直接刷新
                        Refresh();
                    }
                    else if (_isPollTask)
                    {
                        //如果是手动点击的刷新按钮也刷新
                        _isPollTask = false;
                        Refresh();
                    }
                    else
                    {
                        //如果既没有选中每秒刷新也没有指定手动刷新就只进行连通后台服务的测试
                        try
                        {
                            if (cycle_client.State != System.ServiceModel.CommunicationState.Opened)
                            {
                                cycle_client.Open();
                            }
                            cycle_client.TestConn();
                            if (currentIcon == "disabled")
                            {
                                JackTime2Run.Icon = normal;
                                currentIcon = "normal";
                            }
                        }
                        catch
                        {
                            if (currentIcon == "normal")
                            {
                                JackTime2Run.Icon = disabled;
                                currentIcon = "disabled";
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            });
        }

        /// <summary>单元格点击事件，启用、禁用、编辑以及删除功能代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    string name = (dataGridView1.Rows[e.RowIndex].Cells[6].Value ?? "").ToString();
                    string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    //这里可以编写你需要的任意关于按钮事件的操作
                    JackTime2Run.NamePipeSrvClient client = null;
                    try
                    {
                        client = new JackTime2Run.NamePipeSrvClient();
                        if (value == "禁用")
                        {
                            if (MessageBox.Show("是否禁用任务:" + name + "?", "禁用任务:" + name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                Task.Factory.StartNew(() =>
                                {
                                    if (!client.DisableJob(name))
                                    {
                                        this.Invoke((Action)(() =>
                                        {
                                            MessageBox.Show("执行失败,服务异常,请查看日志[" + AppDomain.CurrentDomain.BaseDirectory + "log\\SrvManage" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log]", "服务异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            Refresh();
                                        }));
                                    };
                                });
                            }
                        }
                        else if (value == "启用")
                        {
                            if (MessageBox.Show("是否启用任务:" + name + "?", "启用任务:" + name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                Task.Factory.StartNew(() =>
                                {
                                    if (!client.EnableJob(name))
                                    {
                                        this.Invoke((Action)(() =>
                                        {
                                            MessageBox.Show("执行失败,服务异常,请查看日志[" + AppDomain.CurrentDomain.BaseDirectory + "log\\SrvManage" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log]", "服务异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            Refresh();
                                        }));
                                    };
                                });
                            }
                        }
                        else if (value == "删除")
                        {
                            if (MessageBox.Show("是否删除任务:" + name + "?", "删除任务:" + name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                Task.Factory.StartNew(() =>
                                {
                                    if (!client.RemoveJob(name))
                                    {
                                        this.Invoke((Action)(() =>
                                        {
                                            MessageBox.Show("执行失败,服务异常,请查看日志[" + AppDomain.CurrentDomain.BaseDirectory + "log\\SrvManage" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log]", "服务异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            Refresh();
                                        }));
                                    };
                                });
                            }
                        }
                        else if (value == "编辑")
                        {
                            int index = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                            DataTransfer.job = jobs[index - 1];
                            new JobEdit().ShowDialog();
                            Refresh();
                        }
                        else if (value == "执行一次")
                        {
                            if (MessageBox.Show("是否临时执行任务:" + name + "?", "临时执行任务:" + name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                Task.Factory.StartNew(() =>
                                {
                                    if (!client.TriJob(name))
                                    {
                                        this.Invoke((Action)(() =>
                                        {
                                            MessageBox.Show("执行失败,服务异常,请查看日志[" + AppDomain.CurrentDomain.BaseDirectory + "log\\SrvManage" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log]", "服务异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }));
                                    };
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is System.ServiceModel.EndpointNotFoundException)
                        {
                            MessageBox.Show("连接失败,请检查是否启动了服务JackTime2Run!", "连接失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("执行失败,失败信息:" + ex.ToString(), "执行失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    finally
                    {
                        client.Close();
                    }
                }
            }
        }

        /// <summary>添加任务按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DataTransfer.job = null;
            new JobEdit().ShowDialog();
        }

        /// <summary>通知图标双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        /// <summary>通知图标右键退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        /// <summary>通知图标右键管理事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        /// <summary>通知图标右键启动服务事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 启动服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartSrv();
        }

        /// <summary>通知图标右键暂停服务事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 暂停服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopSrv();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

    }

    /// <summary>DataGridView添加双缓冲
    /// </summary>
    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}

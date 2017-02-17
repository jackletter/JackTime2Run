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
        public Main()
        {
            InitializeComponent();
        }

        private static List<JackTime2Run.JackJob> jobs = new List<JackTime2Run.JackJob>();

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

        private void 开启_Click(object sender, EventArgs e)
        {
            StartSrv();
        }

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

        private void 停止服务_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否停止服务,停止服务后将不能定时执行任务?", "停止JackTime2Run?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                StopSrv();
            }
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            _isPollTask = true;//只是设置为true,交由定时刷洗去判断
        }

        private bool _isPollTask = false;
        private void Refresh()
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

        private List<JackTime2Run.JackJob> GetAllTask()
        {
            JackTime2Run.NamePipeSrvClient client = new JackTime2Run.NamePipeSrvClient();
            try
            {
                JackTime2Run.JackJob[] tasks = client.GetAllJobs();
                if (tasks == null)
                {
                    MessageBox.Show("拉去当前任务计划失败,服务异常,请查看日志[" + AppDomain.CurrentDomain.BaseDirectory + "log\\SrvManage" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log]", "服务异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkBox1.Checked = false;
                    return new List<JackTime2Run.JackJob>();
                }
                return tasks.ToList();
            }
            catch (Exception ex)
            {
                if (ex is System.ServiceModel.EndpointNotFoundException)
                {
                    MessageBox.Show("拉去当前任务计划失败,请检查是否安装并启动了服务JackTime2Run!", "连接失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
                checkBox1.Checked = false;
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
                        Refresh();
                    }
                    else if (_isPollTask)
                    {
                        _isPollTask = false;
                        Refresh();
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            });
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    string name = (dataGridView1.Rows[e.RowIndex].Cells[9].Value ?? "").ToString();
                    string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    //这里可以编写你需要的任意关于按钮事件的操作~
                    try
                    {
                        if (value == "禁用")
                        {
                            if (MessageBox.Show("是否禁用任务:" + name + "?", "禁用任务:" + name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                JackTime2Run.NamePipeSrvClient client = new JackTime2Run.NamePipeSrvClient();
                                if (!client.DisableJob(name))
                                {
                                    MessageBox.Show("执行失败,服务异常,请查看日志[" + AppDomain.CurrentDomain.BaseDirectory + "log\\SrvManage" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log]", "服务异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                };
                                Refresh();
                            }
                        }
                        else if (value == "启用")
                        {
                            if (MessageBox.Show("是否启用任务:" + name + "?", "启用任务:" + name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                JackTime2Run.NamePipeSrvClient client = new JackTime2Run.NamePipeSrvClient();
                                if (!client.EnableJob(name))
                                {
                                    MessageBox.Show("执行失败,服务异常,请查看日志[" + AppDomain.CurrentDomain.BaseDirectory + "log\\SrvManage" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log]", "服务异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                };
                                Refresh();
                            }
                        }
                        else if (value == "删除")
                        {
                            if (MessageBox.Show("是否删除任务:" + name + "?", "删除任务:" + name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                JackTime2Run.NamePipeSrvClient client = new JackTime2Run.NamePipeSrvClient();
                                if (!client.RemoveJob(name))
                                {
                                    MessageBox.Show("执行失败,服务异常,请查看日志[" + AppDomain.CurrentDomain.BaseDirectory + "log\\SrvManage" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log]", "服务异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                };
                                Refresh();
                            }
                        }
                        else if (value == "编辑")
                        {
                            JackTime2Run.NamePipeSrvClient client = new JackTime2Run.NamePipeSrvClient();
                            int index = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                            DataTransfer.job = jobs[index - 1];
                            new JobEdit().ShowDialog();
                            Refresh();
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
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTransfer.job = null;
            new JobEdit().ShowDialog();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void 管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void 启动服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartSrv();
        }

        private void 暂停服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopSrv();
        }

    }
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager
{
    public partial class JobEdit : Form
    {
        public JobEdit()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (DataTransfer.job != null)
            {
                button1.Hide();
                txt_name.Text = DataTransfer.job.Name;
                txt_cron.Text = DataTransfer.job.Cron;
                txt_typename.Text = DataTransfer.job.TypeName;
                txt_searchpath.Text = DataTransfer.job.SearchPath;
                txt_srccodepath.Text = DataTransfer.job.SrcCodeFilePath;
                SelectBox(txt_logwhen, DataTransfer.job.LogWhen);
                SelectBox(txt_jobtype, DataTransfer.job.JobType);
                SelectBox(txt_enable, DataTransfer.job.Enable);
                txt_method.Text = DataTransfer.job.Method;
                for (int i = 0; i < DataTransfer.job.Paras.Length; i++)
                {
                    dataGridView1.Rows.Add(DataTransfer.job.Paras[i]);
                }
                txt_name.ReadOnly = true;
            }
            else
            {
                txt_name.ReadOnly = false;
                txt_logwhen.SelectedIndex = 0;
                txt_jobtype.SelectedIndex = 0;
                txt_enable.SelectedIndex = 0;
                button2.Hide();
            }
        }

        private void SelectBox(ComboBox box, string text)
        {
            for (int i = 0; i < box.Items.Count; i++)
            {
                if (box.Items[i].ToString() == text)
                {
                    box.SelectedIndex = i;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Vali()) { return; }
                JackTime2Run.JackJob job = GeneJob();
                JackTime2Run.NamePipeSrvClient client = new JackTime2Run.NamePipeSrvClient();
                if (!client.UpdateJob(job))
                {
                    MessageBox.Show("执行失败,服务异常,请查看日志[" + AppDomain.CurrentDomain.BaseDirectory + "log\\SrvManage" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log]", "服务异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.Close();
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

        private JackTime2Run.JackJob GeneJob()
        {
            JackTime2Run.JackJob job = new JackTime2Run.JackJob();
            job.Name = txt_name.Text;
            job.Cron = txt_cron.Text;
            job.TypeName = txt_typename.Text;
            job.SearchPath = txt_searchpath.Text;
            job.Method = txt_method.Text;
            job.SrcCodeFilePath = txt_srccodepath.Text;
            job.LogWhen = txt_logwhen.SelectedIndex.ToString();
            job.JobType = txt_jobtype.SelectedIndex.ToString();
            job.Enable = txt_enable.SelectedIndex.ToString();
            List<string> linesList = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (i == dataGridView1.Rows.Count - 1 && (dataGridView1.Rows[i].Cells[0].Value ?? "").ToString() == "") { break; }
                linesList.Add((dataGridView1.Rows[i].Cells[0].Value ?? "").ToString());
            }
            job.Paras = linesList.ToArray();
            return job;
        }

        private bool Vali()
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text))
            {
                MessageBox.Show("请填写任务名称");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_cron.Text))
            {
                MessageBox.Show("请填写Cron表达式");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Vali()) { return; }
                JackTime2Run.JackJob job = GeneJob();
                JackTime2Run.NamePipeSrvClient client = new JackTime2Run.NamePipeSrvClient();
                if (!client.AddJob(job))
                {
                    MessageBox.Show("执行失败,服务异常,请查看日志[" + AppDomain.CurrentDomain.BaseDirectory + "log\\SrvManage" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log]", "服务异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.Close();
                }
                this.Close();
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

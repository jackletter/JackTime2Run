namespace Manager
{
    partial class JobEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_cron = new System.Windows.Forms.TextBox();
            this.txt_typename = new System.Windows.Forms.TextBox();
            this.txt_searchpath = new System.Windows.Forms.TextBox();
            this.txt_method = new System.Windows.Forms.TextBox();
            this.txt_logwhen = new System.Windows.Forms.ComboBox();
            this.txt_jobtype = new System.Windows.Forms.ComboBox();
            this.txt_enable = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.参数值 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_srccodepath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(17, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(453, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cron:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(17, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "日志记录:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(230, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "任务类型:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(17, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "程序集搜索路径:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.Location = new System.Drawing.Point(17, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "完整类名:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(440, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "方法名:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(687, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "是否可用:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.Location = new System.Drawing.Point(17, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "参数:";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(26, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(26, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 36);
            this.button2.TabIndex = 11;
            this.button2.Text = "更新";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(132, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 36);
            this.button3.TabIndex = 12;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_name.Location = new System.Drawing.Point(114, 69);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(303, 26);
            this.txt_name.TabIndex = 13;
            // 
            // txt_cron
            // 
            this.txt_cron.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_cron.Location = new System.Drawing.Point(507, 69);
            this.txt_cron.Name = "txt_cron";
            this.txt_cron.Size = new System.Drawing.Size(332, 26);
            this.txt_cron.TabIndex = 14;
            // 
            // txt_typename
            // 
            this.txt_typename.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_typename.Location = new System.Drawing.Point(114, 121);
            this.txt_typename.Name = "txt_typename";
            this.txt_typename.Size = new System.Drawing.Size(725, 26);
            this.txt_typename.TabIndex = 15;
            // 
            // txt_searchpath
            // 
            this.txt_searchpath.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_searchpath.Location = new System.Drawing.Point(161, 167);
            this.txt_searchpath.Name = "txt_searchpath";
            this.txt_searchpath.Size = new System.Drawing.Size(678, 26);
            this.txt_searchpath.TabIndex = 16;
            // 
            // txt_method
            // 
            this.txt_method.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_method.Location = new System.Drawing.Point(507, 228);
            this.txt_method.Name = "txt_method";
            this.txt_method.Size = new System.Drawing.Size(164, 26);
            this.txt_method.TabIndex = 17;
            // 
            // txt_logwhen
            // 
            this.txt_logwhen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_logwhen.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_logwhen.FormattingEnabled = true;
            this.txt_logwhen.Items.AddRange(new object[] {
            "一定记录",
            "成功时记录",
            "失败时记录"});
            this.txt_logwhen.Location = new System.Drawing.Point(114, 229);
            this.txt_logwhen.Name = "txt_logwhen";
            this.txt_logwhen.Size = new System.Drawing.Size(110, 24);
            this.txt_logwhen.TabIndex = 18;
            // 
            // txt_jobtype
            // 
            this.txt_jobtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_jobtype.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_jobtype.FormattingEnabled = true;
            this.txt_jobtype.Items.AddRange(new object[] {
            "动态库",
            "单个cs文件",
            "exe程序"});
            this.txt_jobtype.Location = new System.Drawing.Point(311, 229);
            this.txt_jobtype.Name = "txt_jobtype";
            this.txt_jobtype.Size = new System.Drawing.Size(106, 24);
            this.txt_jobtype.TabIndex = 19;
            // 
            // txt_enable
            // 
            this.txt_enable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_enable.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_enable.FormattingEnabled = true;
            this.txt_enable.Items.AddRange(new object[] {
            "禁用",
            "可用"});
            this.txt_enable.Location = new System.Drawing.Point(764, 229);
            this.txt_enable.Name = "txt_enable";
            this.txt_enable.Size = new System.Drawing.Size(106, 24);
            this.txt_enable.TabIndex = 20;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.参数值});
            this.dataGridView1.Location = new System.Drawing.Point(12, 316);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(874, 138);
            this.dataGridView1.TabIndex = 21;
            // 
            // 参数值
            // 
            this.参数值.HeaderText = "参数值";
            this.参数值.Name = "参数值";
            // 
            // txt_srccodepath
            // 
            this.txt_srccodepath.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_srccodepath.Location = new System.Drawing.Point(161, 198);
            this.txt_srccodepath.Name = "txt_srccodepath";
            this.txt_srccodepath.Size = new System.Drawing.Size(678, 26);
            this.txt_srccodepath.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F);
            this.label10.Location = new System.Drawing.Point(17, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "cs文件路径:";
            // 
            // JobEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 466);
            this.Controls.Add(this.txt_srccodepath);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt_enable);
            this.Controls.Add(this.txt_jobtype);
            this.Controls.Add(this.txt_logwhen);
            this.Controls.Add(this.txt_method);
            this.Controls.Add(this.txt_searchpath);
            this.Controls.Add(this.txt_typename);
            this.Controls.Add(this.txt_cron);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JobEdit";
            this.Opacity = 0.85D;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_cron;
        private System.Windows.Forms.TextBox txt_typename;
        private System.Windows.Forms.TextBox txt_searchpath;
        private System.Windows.Forms.TextBox txt_method;
        private System.Windows.Forms.ComboBox txt_logwhen;
        private System.Windows.Forms.ComboBox txt_jobtype;
        private System.Windows.Forms.ComboBox txt_enable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 参数值;
        private System.Windows.Forms.TextBox txt_srccodepath;
        private System.Windows.Forms.Label label10;
    }
}
namespace Manager
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.卸载服务 = new System.Windows.Forms.Button();
            this.安装 = new System.Windows.Forms.Button();
            this.开启 = new System.Windows.Forms.Button();
            this.停止服务 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.JackTime2Run = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.启动服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.序号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.配置状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.运行状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.上次执行 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.下次执行 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.启用 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.禁用 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.编辑 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.删除 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.执行一次 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 卸载服务
            // 
            this.卸载服务.Cursor = System.Windows.Forms.Cursors.Hand;
            this.卸载服务.Location = new System.Drawing.Point(7, 385);
            this.卸载服务.Name = "卸载服务";
            this.卸载服务.Size = new System.Drawing.Size(105, 35);
            this.卸载服务.TabIndex = 0;
            this.卸载服务.Text = "卸载服务";
            this.卸载服务.UseVisualStyleBackColor = true;
            this.卸载服务.Click += new System.EventHandler(this.卸载服务_Click);
            // 
            // 安装
            // 
            this.安装.Cursor = System.Windows.Forms.Cursors.Hand;
            this.安装.Location = new System.Drawing.Point(7, 186);
            this.安装.Name = "安装";
            this.安装.Size = new System.Drawing.Size(105, 35);
            this.安装.TabIndex = 2;
            this.安装.Text = "安装服务";
            this.安装.UseVisualStyleBackColor = true;
            this.安装.Click += new System.EventHandler(this.安装_Click);
            // 
            // 开启
            // 
            this.开启.Cursor = System.Windows.Forms.Cursors.Hand;
            this.开启.Location = new System.Drawing.Point(7, 238);
            this.开启.Name = "开启";
            this.开启.Size = new System.Drawing.Size(105, 35);
            this.开启.TabIndex = 3;
            this.开启.Text = "开启服务";
            this.开启.UseVisualStyleBackColor = true;
            this.开启.Click += new System.EventHandler(this.开启_Click);
            // 
            // 停止服务
            // 
            this.停止服务.Cursor = System.Windows.Forms.Cursors.Hand;
            this.停止服务.Location = new System.Drawing.Point(7, 340);
            this.停止服务.Name = "停止服务";
            this.停止服务.Size = new System.Drawing.Size(105, 35);
            this.停止服务.TabIndex = 5;
            this.停止服务.Text = "停止服务";
            this.停止服务.UseVisualStyleBackColor = true;
            this.停止服务.Click += new System.EventHandler(this.停止服务_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.序号,
            this.名称,
            this.类型,
            this.配置状态,
            this.运行状态,
            this.上次执行,
            this.下次执行,
            this.启用,
            this.禁用,
            this.编辑,
            this.删除,
            this.执行一次});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(123, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.Size = new System.Drawing.Size(969, 408);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(7, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "刷新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(7, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 35);
            this.button2.TabIndex = 8;
            this.button2.Text = "添加任务";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // JackTime2Run
            // 
            this.JackTime2Run.ContextMenuStrip = this.contextMenuStrip1;
            this.JackTime2Run.Icon = ((System.Drawing.Icon)(resources.GetObject("JackTime2Run.Icon")));
            this.JackTime2Run.Text = "JackTime2Run";
            this.JackTime2Run.Visible = true;
            this.JackTime2Run.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启动服务ToolStripMenuItem,
            this.暂停服务ToolStripMenuItem,
            this.管理ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            // 
            // 启动服务ToolStripMenuItem
            // 
            this.启动服务ToolStripMenuItem.Name = "启动服务ToolStripMenuItem";
            this.启动服务ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.启动服务ToolStripMenuItem.Text = "启动服务";
            this.启动服务ToolStripMenuItem.Click += new System.EventHandler(this.启动服务ToolStripMenuItem_Click);
            // 
            // 暂停服务ToolStripMenuItem
            // 
            this.暂停服务ToolStripMenuItem.Name = "暂停服务ToolStripMenuItem";
            this.暂停服务ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.暂停服务ToolStripMenuItem.Text = "停止服务";
            this.暂停服务ToolStripMenuItem.Click += new System.EventHandler(this.暂停服务ToolStripMenuItem_Click);
            // 
            // 管理ToolStripMenuItem
            // 
            this.管理ToolStripMenuItem.Name = "管理ToolStripMenuItem";
            this.管理ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.管理ToolStripMenuItem.Text = "管理";
            this.管理ToolStripMenuItem.Click += new System.EventHandler(this.管理ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.checkBox1.Location = new System.Drawing.Point(12, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 20);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "每秒刷新";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // 序号
            // 
            this.序号.DataPropertyName = "序号";
            this.序号.FillWeight = 7F;
            this.序号.HeaderText = "序号";
            this.序号.Name = "序号";
            this.序号.ReadOnly = true;
            // 
            // 名称
            // 
            this.名称.DataPropertyName = "名称";
            this.名称.FillWeight = 18F;
            this.名称.HeaderText = "名称";
            this.名称.Name = "名称";
            this.名称.ReadOnly = true;
            // 
            // 类型
            // 
            this.类型.DataPropertyName = "类型";
            this.类型.FillWeight = 9F;
            this.类型.HeaderText = "类型";
            this.类型.Name = "类型";
            this.类型.ReadOnly = true;
            // 
            // 配置状态
            // 
            this.配置状态.DataPropertyName = "配置状态";
            this.配置状态.FillWeight = 7F;
            this.配置状态.HeaderText = "配置";
            this.配置状态.Name = "配置状态";
            this.配置状态.ReadOnly = true;
            // 
            // 运行状态
            // 
            this.运行状态.DataPropertyName = "运行状态";
            this.运行状态.FillWeight = 7F;
            this.运行状态.HeaderText = "运行";
            this.运行状态.Name = "运行状态";
            this.运行状态.ReadOnly = true;
            // 
            // 上次执行
            // 
            this.上次执行.DataPropertyName = "上次执行";
            this.上次执行.FillWeight = 16F;
            this.上次执行.HeaderText = "上次执行";
            this.上次执行.Name = "上次执行";
            this.上次执行.ReadOnly = true;
            // 
            // 下次执行
            // 
            this.下次执行.DataPropertyName = "下次执行";
            this.下次执行.FillWeight = 16F;
            this.下次执行.HeaderText = "下次执行";
            this.下次执行.Name = "下次执行";
            this.下次执行.ReadOnly = true;
            // 
            // 启用
            // 
            this.启用.FillWeight = 7F;
            this.启用.HeaderText = "启用";
            this.启用.Name = "启用";
            this.启用.ReadOnly = true;
            this.启用.Text = "启用";
            this.启用.UseColumnTextForButtonValue = true;
            // 
            // 禁用
            // 
            this.禁用.FillWeight = 7F;
            this.禁用.HeaderText = "禁用";
            this.禁用.Name = "禁用";
            this.禁用.ReadOnly = true;
            this.禁用.Text = "禁用";
            this.禁用.UseColumnTextForButtonValue = true;
            // 
            // 编辑
            // 
            this.编辑.FillWeight = 7F;
            this.编辑.HeaderText = "编辑";
            this.编辑.Name = "编辑";
            this.编辑.ReadOnly = true;
            this.编辑.Text = "编辑";
            this.编辑.UseColumnTextForButtonValue = true;
            // 
            // 删除
            // 
            this.删除.FillWeight = 7F;
            this.删除.HeaderText = "删除";
            this.删除.Name = "删除";
            this.删除.ReadOnly = true;
            this.删除.Text = "删除";
            this.删除.UseColumnTextForButtonValue = true;
            // 
            // 执行一次
            // 
            this.执行一次.FillWeight = 8F;
            this.执行一次.HeaderText = "执行一次";
            this.执行一次.Name = "执行一次";
            this.执行一次.ReadOnly = true;
            this.执行一次.Text = "执行一次";
            this.执行一次.UseColumnTextForButtonValue = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 427);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.停止服务);
            this.Controls.Add(this.开启);
            this.Controls.Add(this.安装);
            this.Controls.Add(this.卸载服务);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Opacity = 0.88D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JackTime2RunManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button 卸载服务;
        private System.Windows.Forms.Button 安装;
        private System.Windows.Forms.Button 开启;
        private System.Windows.Forms.Button 停止服务;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NotifyIcon JackTime2Run;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 启动服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 暂停服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 序号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配置状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 运行状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 上次执行;
        private System.Windows.Forms.DataGridViewTextBoxColumn 下次执行;
        private System.Windows.Forms.DataGridViewButtonColumn 启用;
        private System.Windows.Forms.DataGridViewButtonColumn 禁用;
        private System.Windows.Forms.DataGridViewButtonColumn 编辑;
        private System.Windows.Forms.DataGridViewButtonColumn 删除;
        private System.Windows.Forms.DataGridViewButtonColumn 执行一次;
    }
}


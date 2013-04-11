namespace EmlExtractorWin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblTotalEml = new System.Windows.Forms.Label();
            this.tbxEmlFolder = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.inquerytime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clerkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.platfrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customcountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customemail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(12, 11);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(116, 23);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "选择eml文件夹";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // btnGet
            // 
            this.btnGet.Enabled = false;
            this.btnGet.Location = new System.Drawing.Point(12, 40);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(116, 23);
            this.btnGet.TabIndex = 0;
            this.btnGet.Text = "提取数据";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.lblResult);
            this.panel1.Controls.Add(this.btnGet);
            this.panel1.Controls.Add(this.lblTotalEml);
            this.panel1.Controls.Add(this.tbxEmlFolder);
            this.panel1.Controls.Add(this.btnSelectFolder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 70);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(134, 41);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(437, 18);
            this.progressBar1.TabIndex = 6;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(586, 45);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(47, 12);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "       ";
            // 
            // lblTotalEml
            // 
            this.lblTotalEml.AutoSize = true;
            this.lblTotalEml.Location = new System.Drawing.Point(586, 16);
            this.lblTotalEml.Name = "lblTotalEml";
            this.lblTotalEml.Size = new System.Drawing.Size(0, 12);
            this.lblTotalEml.TabIndex = 3;
            // 
            // tbxEmlFolder
            // 
            this.tbxEmlFolder.Location = new System.Drawing.Point(134, 13);
            this.tbxEmlFolder.Name = "tbxEmlFolder";
            this.tbxEmlFolder.Size = new System.Drawing.Size(437, 21);
            this.tbxEmlFolder.TabIndex = 2;
            this.tbxEmlFolder.TextChanged += new System.EventHandler(this.tbxEmlFolder_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inquerytime,
            this.clerkName,
            this.productname,
            this.platfrom,
            this.customcountry,
            this.customname,
            this.customemail});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(745, 328);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.w_Dgv_RowPostPaint);
            // 
            // inquerytime
            // 
            this.inquerytime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.inquerytime.DefaultCellStyle = dataGridViewCellStyle1;
            this.inquerytime.Frozen = true;
            this.inquerytime.HeaderText = "时间";
            this.inquerytime.Name = "inquerytime";
            this.inquerytime.Width = 54;
            // 
            // clerkName
            // 
            this.clerkName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clerkName.HeaderText = "跟进业务员";
            this.clerkName.Name = "clerkName";
            this.clerkName.Width = 90;
            // 
            // productname
            // 
            this.productname.HeaderText = "产品名称";
            this.productname.Name = "productname";
            // 
            // platfrom
            // 
            this.platfrom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.platfrom.HeaderText = "来源";
            this.platfrom.Name = "platfrom";
            this.platfrom.Width = 54;
            // 
            // customcountry
            // 
            this.customcountry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.customcountry.HeaderText = "国家";
            this.customcountry.Name = "customcountry";
            this.customcountry.Width = 54;
            // 
            // customname
            // 
            this.customname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.customname.HeaderText = "客户名称";
            this.customname.Name = "customname";
            this.customname.Width = 78;
            // 
            // customemail
            // 
            this.customemail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.customemail.HeaderText = "客户邮箱";
            this.customemail.Name = "customemail";
            this.customemail.Width = 78;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 398);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(745, 34);
            this.panel2.TabIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 432);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NTS询谈邮件数据提取器";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbxEmlFolder;
        private System.Windows.Forms.Label lblTotalEml;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn inquerytime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clerkName;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn platfrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn customcountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn customname;
        private System.Windows.Forms.DataGridViewTextBoxColumn customemail;
    }
}


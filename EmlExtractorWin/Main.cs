using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;
using EEBiz;
using EEModel;
namespace EmlExtractorWin
{
    public partial class Main : Form
    {
        public Main()
        {
            
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            CheckPath();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedPath = folderBrowserDialog1.SelectedPath;
                tbxEmlFolder.Text = selectedPath;


            }
        }
        EEBiz.ExtractService bizExtract = new ExtractService();
        private void btnGet_Click(object sender, EventArgs e)
        {
           
            // btnGet.Enabled = false;
           lblResult.Text = "正在导入,请稍候";
            backgroundWorker1.RunWorkerAsync();
        }

        private void BindData()
        {
            //dataGridView1.DataSource=
        }

        private void tbxEmlFolder_TextChanged(object sender, EventArgs e)
        {
            CheckPath();

        }
        private void CheckPath()
        {
            int totalFiles = 0;
            try
            {
                string[] fileNames = Directory.GetFiles(tbxEmlFolder.Text, "*.eml", SearchOption.AllDirectories);
                totalFiles = fileNames.Length;
                lblTotalEml.Text = string.Format("共{0}个文件", totalFiles);
                btnGet.Enabled = true;
            }
            catch
            {
                lblTotalEml.Text = "无效的路径";
                btnGet.Enabled = false;
            }

        }
        IList<ExtractorResultObject> resultList = new List<ExtractorResultObject>();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            resultList = bizExtract.GetListFromFolder(tbxEmlFolder.Text);
           // backgroundWorker1.ReportProgress(50);
         //   bizExtract.SaveResultList(resultList);
            backgroundWorker1.ReportProgress(100);


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progressValue = e.ProgressPercentage;
            progressBar1.Value = progressValue;
            if (progressValue == 50)
            {
                lblResult.Text = "分析完毕,开始导入";
            }
            else if (progressValue == 100)
            {
                lblResult.Text = "导入成功,操作完成";
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            dataGridView1.Columns["inquerytime"].DataPropertyName = "InquiryTime";
            
            dataGridView1.Columns["ProductName"].DataPropertyName = "ProductName";
            dataGridView1.Columns["CustomName"].DataPropertyName = "CustomName";

            dataGridView1.Columns["CustomCountry"].DataPropertyName = "CustomCountry";
            dataGridView1.Columns["CustomEmail"].DataPropertyName = "CustomEmail";

            dataGridView1.Columns["PlatFrom"].DataPropertyName = "PlatFrom";
            dataGridView1.Columns["ClerkName"].DataPropertyName = "ClerkName";
            dataGridView1.DataSource = new Library.Forms.SortableBindingList<ExtractorResultObject>(resultList);

        }
        private void w_Dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Add row numbers
            // Taken from "Pro C# 2008 and The .NET 3.5 Platform" pp. 807-808
            using (var brush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString((e.RowIndex).ToString(),
                                      e.InheritedRowStyle.Font, brush, e.RowBounds.Location.X + 15,
                                      e.RowBounds.Location.Y + 4
                    );
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }






    }
}

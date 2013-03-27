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
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbxEmlFolder.Text = folderBrowserDialog1.SelectedPath;
                
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
           new  EEBiz.ExtractService().ExtractFromFolder(tbxEmlFolder.Text);
            MessageBox.Show("操作成功");

        }

      

       

       
    }
}

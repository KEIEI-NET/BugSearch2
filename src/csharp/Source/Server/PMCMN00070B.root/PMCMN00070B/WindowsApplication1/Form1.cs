using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Diagnostics;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OutputClcLog_Click(object sender, EventArgs e)
        {
            CLCLogTextOut cLCLogTextOut = new CLCLogTextOut();
            Exception ex = new Exception(ExPara.Text);

            cLCLogTextOut.OutputClcLog(PGID.Text, ProductId.Text, Message.Text, Convert.ToInt32(Status.Text), ex);
        }

        private void CopyClcLogFile_Click(object sender, EventArgs e)
        {
            CLCLogTextOut cLCLogTextOut = new CLCLogTextOut();

            CopyClcLogFile_Return.Text = cLCLogTextOut.CopyClcLogFile(FileFullPath.Text).ToString();
        }
    }
}
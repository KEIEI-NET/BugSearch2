using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;

namespace TestClient
{
    public partial class Form1 : Form
    {
        //SimpleInqPMIpcClient _client;

        public Form1()
        {
            InitializeComponent();
            //_client = new SimpleInqPMIpcClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string errmsg;
            int status = SimpleInqPMIpcClient.SendMessage(this.textBox1.Text, out errmsg);

            if (status != 0)
            {
                MessageBox.Show(errmsg);
            }
        }

    }
}
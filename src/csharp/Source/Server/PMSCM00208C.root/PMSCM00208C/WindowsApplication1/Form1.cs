using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SimplInqCnectInfo info = this.GetDisplayInfo();
            SimplInqCnectInfoController.AddConnectionInfo(this.textBox1.Text, info);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SimplInqCnectInfo info = this.GetDisplayInfo();
            SimplInqCnectInfoController.DeleteConnectionInfo(this.textBox1.Text, info);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SimplInqCnectInfo info = this.GetDisplayInfo();
            SimplInqCnectInfoController.ClearConnectionInfo(this.textBox1.Text);
        }

        private SimplInqCnectInfo GetDisplayInfo()
        {
            SimplInqCnectInfo info = new SimplInqCnectInfo();
            //info.EnterpriseCode = this.textBox1.Text;
            info.CashRegisterNo = int.Parse(this.textBox2.Text.Trim());
            info.CustomerCode = int.Parse(this.textBox3.Text.Trim());

            return info;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            //const string col_EnterpriseCode = "EnterpriseCode";
            const string col_CashRegisterNo = "CashRegisterNo";
            const string col_CustomerCode = "CustomerCode";

            //dt.Columns.Add(col_EnterpriseCode, typeof(string));
            dt.Columns.Add(col_CashRegisterNo, typeof(int));
            dt.Columns.Add(col_CustomerCode, typeof(int));

            List<SimplInqCnectInfo> list = SimplInqCnectInfoController.GetConnectionInfolist(this.textBox1.Text);

            foreach (SimplInqCnectInfo info in list)
            {
                DataRow dr = dt.NewRow();
                //dr[col_EnterpriseCode] = info.EnterpriseCode;
                dr[col_CashRegisterNo] = info.CashRegisterNo;
                dr[col_CustomerCode] = info.CustomerCode;
                dt.Rows.Add(dr);
            }

            this.dataGridView1.DataSource = dt;
        }
    }
}
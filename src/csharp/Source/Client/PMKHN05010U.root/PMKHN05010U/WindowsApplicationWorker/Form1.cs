using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    public partial class Form1_1 : Form
    {
        public Form1_1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            PMKHN05010UA clas = new PMKHN05010UA();
            int status;
            string msg;
            PMKHN05010UA.OptSendTargetDiv optSendTarget;
            SalesSlip salesslip = new SalesSlip();
            SalesDetail salesdetail = new SalesDetail();
            List<SalesDetail> salesDetailList = new List<SalesDetail>();
            CustomerInfo customer = new CustomerInfo();
            salesDetailList.Add(salesdetail);
            int count = 0;
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                count++;
            }
            else
            {
                salesslip.AcptAnOdrStatus = Convert.ToInt32(textBox5.Text);
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                count++;
            }
            else
                salesslip.EstimateDivide = Convert.ToInt32(textBox4.Text);
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                count++;
            }
            else
                salesslip.InquiryNumber = Convert.ToInt64(textBox3.Text);
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                count++;
            }
            else
                salesslip.CustomerCode = Convert.ToInt32(textBox2.Text);
            salesslip.EnterpriseCode = "0101150842020050";
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                customer = null;
            }
            else
                customer.OnlineKindDiv = Convert.ToInt32(textBox6.Text);
            salesslip.CustomerSnm = textBox1.Text;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                count++;
            }
            if (count == 5)
            {
                salesslip = null;
            }
            if (checkBox1.Checked)
            {
                salesDetailList = null;
            }
            clas.SalesSlip = salesslip;
            clas.SalesDetailList = salesDetailList;
            clas.CustomerInfo = customer;
            PMKHN05010UA.OptSendTargetDiv optSendTargetDiv;
            DialogResult result = new DialogResult();
            result = clas.ShowDialog(this, out status, out msg, out optSendTargetDiv);
            string dialogResult = result.ToString();
            string stat = status.ToString();
            string opt = optSendTargetDiv.ToString();
            string mes = "処理終了（オーナーフォームセット）\n" + "DialogResult : " + dialogResult + "\n";
            mes += "status : " + stat + "\n";
            mes += "optSendTargetDiv : " + opt + "\n";
            mes += "msg : " + msg;
            MessageBox.Show(mes, "通知");

            result = clas.ShowDialog(out status, out msg, out optSendTargetDiv);
            dialogResult = result.ToString();
            stat = status.ToString();
            opt = optSendTargetDiv.ToString();
            mes = "処理終了（オーナーフォームセットなし）\n" + "DialogResult : " + dialogResult + "\n";
            mes += "status : " + stat + "\n";
            mes += "optSendTargetDiv : " + opt + "\n";
            mes += "msg : " + msg;
            MessageBox.Show(mes, "通知");
        }
    }
}
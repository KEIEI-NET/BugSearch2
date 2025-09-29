using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

namespace WebTester
{
    public partial class Form1 : Form
    {
        SimplInqIDExchangeAcs _acs = new SimplInqIDExchangeAcs();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_ExchangeAcntId_Click(object sender, EventArgs e)
        {
            SmplInqInf inf;
            SmplInqBas bas;
            SmplInqChg chg;
            string msg=string.Empty;

            int status = _acs.ExchangeAcntId(this.txt_EnterpriseCode.Text.Trim(),this.txt_Employee.Text.Trim(),out inf,out bas,out msg);
            
            if (status!=0)
            {
                MessageBox.Show(msg);
            }
        }

        private void btn_SearchRelatedSmplInqInf_Click(object sender, EventArgs e)
        {
            SmplInqInf inf;
            SmplInqBas bas;
            List<SmplInqChg> chgList;
            string msg=string.Empty;

            int status = _acs.SearchRelatedSmplInqInf(this.txt_Acnt.Text, out inf, out bas, out chgList, out msg);
            
            if (status!=0)
            {
                MessageBox.Show(msg);
            }
        }
    }
}
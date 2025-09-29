using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Broadleaf.Application.Control;
using Broadleaf.Application.Remoting.ParamData;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ChangePgGuideDBAcs aaa = new ChangePgGuideDBAcs();
        //SvrMntInfoWork _SvrMntInfoWork = null;
        

        private void button1_Click(object sender, EventArgs e)
        {
        //    _SvrMntInfoWork = new SvrMntInfoWork();
        //    _SvrMntInfoWork.ProductCode = "SuperFrontman";
        //    _SvrMntInfoWork.ServerMainteDivCd = 9;
        //    List<SvrMntInfoWork> gelist = new List<SvrMntInfoWork>();
        //    //gelist.Add(_SvrMntInfoWork);
        //    string errMessage = "";
        //    int maxCount = 0;
            
        //    int status = aaa.SearchSvrMntInf(out gelist, _SvrMntInfoWork, 0, 1,out maxCount, out errMessage);
        //    dataGridView1.DataSource = gelist;
        //    if (status != 0)
        //    {
        //        Text = "該当データがありません";
        //    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        //    if(_SvrMntInfoWork == null) _SvrMntInfoWork = new SvrMntInfoWork();
        //    _SvrMntInfoWork.LogicalDeleteCode = 0;
        //    _SvrMntInfoWork.ProductCode = "1";
        //    _SvrMntInfoWork.ServerMainteConsNo = 1;
        //    _SvrMntInfoWork.ServerMainteDivCd = 1;
        //    _SvrMntInfoWork.ServerMainteStScdl = 200703031230;
        //    _SvrMntInfoWork.ServerMainteEdScdl = 200703041230;
        //    _SvrMntInfoWork.ServerMainteStTime = 200703031300;
        //    _SvrMntInfoWork.ServerMainteEdTime = 200703041200;
        //    _SvrMntInfoWork.ServerMainteCntnts = "サーバーメンテナンス内容です";
        //    _SvrMntInfoWork.ServerMainteGidnc = "サーバーメンテナンス案内です";
        //    string errMessage = "";

        //    int status = aaa.WriteSvrMntInf(ref _SvrMntInfoWork, out errMessage);
        //    if (status == 0)
        //    {
        //        Text = "更新成功";
        //    }
        //    else
        //    {
        //        Text = "更新失敗";
        //    }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        //    if (_SvrMntInfoWork == null) _SvrMntInfoWork = new SvrMntInfoWork();
        //    _SvrMntInfoWork.ProductCode = "1";
        //    _SvrMntInfoWork.ServerMainteConsNo = 1;
        //    string errMessage = "";
        //    SvrMntInfoWork retwk = new SvrMntInfoWork();

        //    int status = aaa.ReadSvrMntInf(_SvrMntInfoWork,out retwk, out errMessage);
        //    ArrayList arr = new ArrayList();
        //    arr.Add(_SvrMntInfoWork);
        //    dataGridView1.DataSource = arr;
        //    if (status != 0)
        //    {
        //        Text = "該当データがありません";
        //    }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
        //    Form2 form2 = new Form2();
        //    form2.Show();
        }
    }
}
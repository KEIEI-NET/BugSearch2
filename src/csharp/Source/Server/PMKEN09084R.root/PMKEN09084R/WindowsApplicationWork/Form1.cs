using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;

namespace WindowsApplicationWork
{
    public partial class Form1 : Form
    {
        IPartsSubstDspDB partsSubstDspDB = null;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0101150842020000";
            textBox2.Text = "01";
            textBox3.Text = "1";
            textBox4.Text = "TEST-001";
            textBox5.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            partsSubstDspDB = MediationPartsSubstDspDB.GetPartsSubstDspDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PartsSubstUSearchParamWork PartsSubstUSearchParamWork = null;

            PartsSubstUSearchParamWork = new PartsSubstUSearchParamWork();

            // 企業コード
            PartsSubstUSearchParamWork.EnterpriseCode = textBox1.Text;
            // 検索区分
            PartsSubstUSearchParamWork.SearchDiv = Convert.ToInt32(textBox5.Text);
            // 拠点コード
            PartsSubstUSearchParamWork.SectionCode = textBox2.Text;
            // メーカーコード
            PartsSubstUSearchParamWork.ChgSrcMakerCd = Convert.ToInt32(textBox3.Text);
            // 品番
            PartsSubstUSearchParamWork.ChgSrcGoodsNo = textBox4.Text;
            

            ArrayList al = new ArrayList();
            al.Add(PartsSubstUSearchParamWork);
            dataGridView2.DataSource = al;
            Search();
        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                dataGridView1.DataSource = null;

                int status = partsSubstDspDB.Search(out objResult, objParam);
                if (status != 0)
                {
                    Text = "該当データ無し ST="+ Convert.ToString(status);
                }
                else
                {
                    // XMLの読み込み
                    Text = "該当データ有り  HIT " + ((ArrayList)objResult).Count.ToString() + "件";

                    if (objResult != null)
                    {
                        dataGridView1.DataSource = objResult;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
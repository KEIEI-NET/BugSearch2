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
        ISalTrgtPrintResultDB salTrgtPrintResultDB = null;
        
        public Form1()
        {
            InitializeComponent();

            //集計単位
            //10:拠点,20:拠点+部門,22:拠点+従業員,
            //30:拠点+得意先,31:拠点+業種,32:拠点+販売ｴﾘｱ,
            //33:拠点+販売ｴﾘｱ+得意先,34:拠点販売区分40:拠点+ﾒｰｶｰ,
            //41:拠点+ﾒｰｶｰ+商品,42:拠点+ｸﾞﾙｰﾌﾟ,43:拠点+BL商品ｺｰﾄﾞ,
            //44:拠点+販売区分,45,自社分類(商品区分)
            comboBox1.Items.Add("10:拠点");
            comboBox1.Items.Add("20:拠点+部門");
            comboBox1.Items.Add("22:拠点+従業員");
            comboBox1.Items.Add("30:拠点+得意先");
            comboBox1.Items.Add("31:拠点+業種");
            comboBox1.Items.Add("32:拠点+販売ｴﾘｱ");
            //comboBox1.Items.Add("33:拠点+販売ｴﾘｱ+得意先");
            //comboBox1.Items.Add("40:拠点+ﾒｰｶｰ");
            //comboBox1.Items.Add("41:拠点+ﾒｰｶｰ+商品");
            //comboBox1.Items.Add("42:拠点+ｸﾞﾙｰﾌﾟ");
            //comboBox1.Items.Add("43:拠点+BL商品ｺｰﾄﾞ");
            comboBox1.Items.Add("44:拠点+販売区分");
            comboBox1.Items.Add("45:自社分類(商品区分)");
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            salTrgtPrintResultDB = MediationSalTrgtPrintResultDB.GetSalTrgtPrintResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalTrgtPrintParamWork paramWork = null;

            paramWork = new SalTrgtPrintParamWork();

            //企業コード
            paramWork.EnterpriseCode = textBox1.Text;

            //拠点コード
            string[] SectionCodes = new string[4];
            //SectionCodes[0] = textBox2.Text;
            SectionCodes = null;
            paramWork.SectionCodes = SectionCodes;

            //印刷区分
            String[] PrintTypelist = comboBox1.Text.Split((new Char[] { ':' }));
            paramWork.PrintType = Convert.ToInt32(PrintTypelist[0]);

            //年月
            paramWork.TargetDivideCodeSt = Convert.ToInt32(textBox3.Text);
            paramWork.TargetDivideCodeEd = Convert.ToInt32(textBox4.Text);

            // 従業員別
            if ((paramWork.PrintType == 10) ||
                (paramWork.PrintType == 20) ||
                (paramWork.PrintType == 22))
            {
                // 部門
                paramWork.SubSectionCodeSt = Convert.ToInt32(textBox5.Text);
                paramWork.SubSectionCodeEd = Convert.ToInt32(textBox6.Text);
                // 従業員コード
                paramWork.EmployeeCodeSt = textBox9.Text;
                paramWork.EmployeeCodeEd = textBox10.Text;

            }
            // 得意先別
            else if ((paramWork.PrintType == 30) ||
                     (paramWork.PrintType == 31) ||
                     (paramWork.PrintType == 32) ||
                     (paramWork.PrintType == 33) ||
                     (paramWork.PrintType == 34))
            {
                // 得意先
                paramWork.CustomerCodeSt = Convert.ToInt32(textBox7.Text);
                paramWork.CustomerCodeEd = Convert.ToInt32(textBox8.Text);
                // 業種
                paramWork.BusinessTypeCodeSt = Convert.ToInt32(textBox15.Text);
                paramWork.BusinessTypeCodeEd = Convert.ToInt32(textBox16.Text);
                // 販売エリア
                paramWork.SalesAreaCodeSt = Convert.ToInt32(textBox17.Text);
                paramWork.SalesAreaCodeEd = Convert.ToInt32(textBox18.Text);
            }
            // 商品別
            else if ((paramWork.PrintType == 40) ||
                (paramWork.PrintType == 41) ||
                (paramWork.PrintType == 42) ||
                (paramWork.PrintType == 43) ||
                (paramWork.PrintType == 44) ||
                (paramWork.PrintType == 45))
            {
                // 販売区分
                paramWork.SalesCodeSt = Convert.ToInt32(textBox11.Text);
                paramWork.SalesCodeEd = Convert.ToInt32(textBox12.Text);
                // 商品区分
                paramWork.EnterpriseGanreCodeSt = Convert.ToInt32(textBox13.Text);
                paramWork.EnterpriseGanreCodeEd = Convert.ToInt32(textBox14.Text);
            }  

            ArrayList al = new ArrayList();
            al.Add(paramWork);
            dataGridView2.DataSource = al;

            Search();


        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                int status = salTrgtPrintResultDB.Search(out objResult, objParam,0);
                if (status != 0)
                {
                    Text = "該当データ無し";
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //印刷区分
            String[] PrintTypelist = comboBox1.Text.Split((new Char[] { ':' }));
            int iPrintType = Convert.ToInt32(PrintTypelist[0]);
            // 従業員別
            if ((iPrintType == 10) ||
                (iPrintType == 20) ||
                (iPrintType == 22))
            {
                // 部門
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                // 従業員コード
                textBox9.Enabled = true;
                textBox10.Enabled = true;
                //------------------------
                // 得意先
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                // 業種
                textBox15.Enabled = false;
                textBox16.Enabled = false;
                // 販売エリア
                textBox17.Enabled = false;
                textBox18.Enabled = false;
                // 販売区分
                textBox11.Enabled = false;
                textBox12.Enabled = false;
                // 商品区分
                textBox13.Enabled = false;
                textBox14.Enabled = false;

            }
            // 得意先別
            else if ((iPrintType == 30) ||
                     (iPrintType == 31) ||
                     (iPrintType == 32) ||
                     (iPrintType == 33) ||
                     (iPrintType == 34))
            {
                // 得意先
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                // 業種
                textBox15.Enabled = true;
                textBox16.Enabled = true;
                // 販売エリア
                textBox17.Enabled = true;
                textBox18.Enabled = true;
                //----------------------------
                // 部門
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                // 従業員コード
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                // 販売区分
                textBox11.Enabled = false;
                textBox12.Enabled = false;
                // 商品区分
                textBox13.Enabled = false;
                textBox14.Enabled = false;

            }
            // 商品別
            else if ((iPrintType == 40) ||
                    (iPrintType == 41) ||
                    (iPrintType == 42) ||
                    (iPrintType == 43) ||
                    (iPrintType == 44) ||
                    (iPrintType == 45))
            {
                // 販売区分
                textBox11.Enabled = true;
                textBox12.Enabled = true;
                // 商品区分
                textBox13.Enabled = true;
                textBox14.Enabled = true;
                //---------------------------
                // 部門
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                // 従業員コード
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                // 得意先
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                // 業種
                textBox15.Enabled = false;
                textBox16.Enabled = false;
                // 販売エリア
                textBox17.Enabled = false;
                textBox18.Enabled = false;

            }  



        }

    }
}
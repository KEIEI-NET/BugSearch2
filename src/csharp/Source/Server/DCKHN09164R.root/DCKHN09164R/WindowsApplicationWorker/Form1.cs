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
        IRateDB rateDB = null;
        RateWork rateWork = null;

        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            rateDB = MediationRateDB.GetRateDB();

        }

        //Clear button
        private void button1_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            textBox1.Text = "0101150842020000";
            textBox2.Text = "01";
            textBox3.Text = "1A10";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "-1.0";
            textBox17.Text = "";
            textBox18.Text = "1";
            textBox19.Text = "A1";
            textBox20.Text = "0";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
        }

        // Read button
        private void button2_Click(object sender, EventArgs e)
        {
            rateWork = new RateWork();
            rateWork.EnterpriseCode = textBox1.Text;
            rateWork.SectionCode = textBox2.Text;
            //rateWork.UnitRateSetDivCd = textBox3.Text;
            //rateWork.GoodsMakerCd = textBox4.Text == "" ? 0 : Convert.ToInt32(textBox4.Text);
            //rateWork.GoodsNo = textBox5.Text;
            //rateWork.GoodsRateRank = textBox6.Text;
            //rateWork.LargeGoodsGanreCode = textBox7.Text;
            //rateWork.MediumGoodsGanreCode = textBox8.Text;
            //rateWork.DetailGoodsGanreCode = textBox9.Text;
            //rateWork.EnterpriseGanreCode = textBox10.Text == "" ? 0 : Convert.ToInt32(textBox10.Text);
            //rateWork.BLGoodsCode = textBox11.Text == "" ? 0 : Convert.ToInt32(textBox11.Text);
            //rateWork.CustomerCode = textBox12.Text == "" ? 0 : Convert.ToInt32(textBox12.Text);
            //rateWork.CustRateGrpCode = textBox13.Text == "" ? 0 : Convert.ToInt32(textBox13.Text);
            //rateWork.SupplierCd = textBox14.Text == "" ? 0 : Convert.ToInt32(textBox14.Text);
            //rateWork.SuppRateGrpCode = textBox15.Text == "" ? 0 : Convert.ToInt32(textBox15.Text);
            //rateWork.LotCount = textBox16.Text == "" ? 0.0 : Convert.ToDouble(textBox16.Text);

            //rateWork.UnitPriceKind = textBox18.Text;
            //rateWork.RateSettingDivide = textBox19.Text;
            //rateWork.OldNewDivCd = textBox20.Text;

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(rateWork);

            //object retList = null;
            //object paraObj = _subSectionWork;

            try
            {
                int status = rateDB.Read(ref parabyte, 0);
                if (status != 0)
                {
                    Text = "該当データ無し";
                }
                else
                {
                    // XMLの読み込み
                    rateWork = (RateWork)XmlByteSerializer.Deserialize(parabyte, typeof(RateWork));

                    Text = "該当データ有り";
                    textBox1.Text = rateWork.EnterpriseCode.ToString();
                    textBox2.Text = rateWork.SectionCode.ToString();
                    //textBox3.Text = rateWork.UnitRateSetDivCd.ToString();
                    //textBox4.Text = rateWork.GoodsMakerCd.ToString();
                    //textBox5.Text = rateWork.GoodsNo;
                    //textBox7.Text = rateWork.LargeGoodsGanreCode;
                    //textBox8.Text = rateWork.MediumGoodsGanreCode;
                    //textBox9.Text = rateWork.DetailGoodsGanreCode;
                    //textBox10.Text = rateWork.EnterpriseGanreCode.ToString();
                    //textBox11.Text = rateWork.BLGoodsCode.ToString();
                    //textBox12.Text = rateWork.CustomerCode.ToString();
                    //textBox13.Text = rateWork.CustRateGrpCode.ToString();
                    //textBox14.Text = rateWork.SupplierCd.ToString();
                    //textBox15.Text = rateWork.SuppRateGrpCode.ToString();
                    //textBox16.Text = rateWork.LotCount.ToString();

                    //textBox17.Text = rateWork.LogicalDeleteCode.ToString();

                    //textBox18.Text = rateWork.UnitPriceKind;
                    //textBox19.Text = rateWork.RateSettingDivide;
                    //textBox20.Text = rateWork.OldNewDivCd;
                  
                    //textBox21.Text = rateWork.RateMngGoodsCd;
                    //textBox22.Text = rateWork.RateMngGoodsNm;
                    //textBox23.Text = rateWork.RateMngCustCd;
                    //textBox24.Text = rateWork.RateMngCustNm;

                    //textBox25.Text = rateWork.UnitPrcCalcDiv.ToString();
                    //textBox26.Text = rateWork.PriceDiv.ToString();
                    //textBox27.Text = rateWork.PriceFl.ToString();
                    //textBox28.Text = rateWork.RateVal.ToString();
                    //textBox29.Text = rateWork.UnPrcFracProcUnit.ToString();
                    //textBox30.Text = rateWork.UnPrcFracProcDiv.ToString();
                    //textBox31.Text = rateWork.RateStartDate.ToShortDateString();
                    //textBox32.Text = rateWork.BargainCd.ToString();

                    Text = "該当データ有り";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (rateWork == null) rateWork = new RateWork();

            rateWork.EnterpriseCode = textBox1.Text;
            rateWork.SectionCode = textBox2.Text;
            //rateWork.UnitRateSetDivCd = textBox3.Text;
            //rateWork.GoodsMakerCd = textBox4.Text == "" ? 0 : Convert.ToInt32(textBox4.Text);
            //rateWork.GoodsNo = textBox5.Text;
            //rateWork.GoodsRateRank = textBox6.Text;
            //rateWork.LargeGoodsGanreCode = textBox7.Text;
            //rateWork.MediumGoodsGanreCode = textBox8.Text;
            //rateWork.DetailGoodsGanreCode = textBox9.Text;
            //rateWork.EnterpriseGanreCode = textBox10.Text == "" ? 0 : Convert.ToInt32(textBox10.Text);
            //rateWork.BLGoodsCode = textBox11.Text == "" ? 0 : Convert.ToInt32(textBox11.Text);
            //rateWork.CustomerCode = textBox12.Text == "" ? 0 : Convert.ToInt32(textBox12.Text);
            //rateWork.CustRateGrpCode = textBox13.Text == "" ? 0 : Convert.ToInt32(textBox13.Text);
            //rateWork.SupplierCd = textBox14.Text == "" ? 0 : Convert.ToInt32(textBox14.Text);
            //rateWork.SuppRateGrpCode = textBox15.Text == "" ? 0 : Convert.ToInt32(textBox15.Text);
            //rateWork.LotCount = textBox16.Text == "" ? 0.0 : Convert.ToDouble(textBox16.Text);

            rateWork.LogicalDeleteCode = textBox17.Text=="" ? 0 : Convert.ToInt32(textBox17.Text);

            string UnitRateSetDivCd = textBox3.Text;
            if (UnitRateSetDivCd.Length != 4)
            {
                MessageBox.Show("単価掛率設定区分の長さが４(文字)でありません。");
                textBox3.Focus();
                return;
            }

            //rateWork.OldNewDivCd = UnitRateSetDivCd.Substring(3, 1);
            //rateWork.UnitPriceKind = UnitRateSetDivCd.Substring(0, 1);
            //rateWork.RateSettingDivide = UnitRateSetDivCd.Substring(1, 2);
            //rateWork.RateMngGoodsCd = textBox21.Text;
            //rateWork.RateMngGoodsNm = textBox22.Text;
            //rateWork.RateMngCustCd = textBox23.Text;
            //rateWork.RateMngCustNm = textBox24.Text;

            //rateWork.UnitPrcCalcDiv = textBox25.Text == "" ? 1 : Convert.ToInt32(textBox25.Text);
            //rateWork.PriceDiv = textBox26.Text == "" ? 0 : Convert.ToInt32(textBox26.Text);
            //rateWork.PriceFl = textBox27.Text == "" ? 0.0 : Convert.ToDouble(textBox27.Text);
            //rateWork.RateVal = textBox28.Text == "" ? 1.0 : Convert.ToDouble(textBox28.Text);
            //rateWork.UnPrcFracProcUnit = textBox29.Text == "" ? 1.0 : Convert.ToDouble(textBox29.Text);
            //rateWork.UnPrcFracProcDiv = textBox30.Text == "" ? 0 : Convert.ToInt32(textBox30.Text);
            //rateWork.RateStartDate = textBox31.Text == "" ? Convert.ToDateTime("0001/01/01") : Convert.ToDateTime(textBox31.Text);
            //rateWork.BargainCd = textBox32.Text == "" ? 0 : Convert.ToInt32(textBox32.Text);

            try
            {
                ArrayList al = new ArrayList();
                al.Add(rateWork);

                object obj = al;

                int status = rateDB.Write(ref obj);
                if (status != 0)
                {
                    Text = "更新失敗";
                    if (status == 800)
                    {
                        MessageBox.Show("他端末で更新されています。再度データを読み込んでから再登録してください。");
                    }
                    else if (status == 801)
                    {
                        MessageBox.Show("他端末でデータが削除されています。登録出来ませんでした。");
                    }
                }
                else
                {
                    Text = "更新成功";
                    //_ejibaiRtDtWork = (EjibaiRtDtWork)XmlByteSerializer.Deserialize(parabyte,typeof(EjibaiRtDtWork));
                    dataGridView1.DataSource = obj;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //単価種別
        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox18.Text;
        }

        //掛率設定区分
        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox18.Text + textBox19.Text;
        }

        //新旧区分
        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox18.Text + textBox19.Text + textBox20.Text;
        }

        //Search button
        private void button4_Click(object sender, EventArgs e)
        {
            RateWork rateWork = null;

            rateWork = new RateWork();
            rateWork.EnterpriseCode = textBox1.Text;
            rateWork.SectionCode = textBox2.Text;
            //rateWork.UnitRateSetDivCd = textBox3.Text;
            //rateWork.GoodsMakerCd = textBox4.Text == "" ? 0 : Convert.ToInt32(textBox4.Text);
            //rateWork.GoodsNo = textBox5.Text;
            //rateWork.GoodsRateRank = textBox6.Text;
            //rateWork.LargeGoodsGanreCode = textBox7.Text;
            //rateWork.MediumGoodsGanreCode = textBox8.Text;
            //rateWork.DetailGoodsGanreCode = textBox9.Text;
            //rateWork.EnterpriseGanreCode = textBox10.Text == "" ? 0 : Convert.ToInt32(textBox10.Text);
            //rateWork.BLGoodsCode = textBox11.Text == "" ? 0 : Convert.ToInt32(textBox11.Text);
            //rateWork.CustomerCode = textBox12.Text == "" ? 0 : Convert.ToInt32(textBox12.Text);
            //rateWork.CustRateGrpCode = textBox13.Text == "" ? 0 : Convert.ToInt32(textBox13.Text);
            //rateWork.SupplierCd = textBox14.Text == "" ? 0 : Convert.ToInt32(textBox14.Text);
            //rateWork.SuppRateGrpCode = textBox15.Text == "" ? 0 : Convert.ToInt32(textBox15.Text);
            //rateWork.LotCount = textBox16.Text == "" ? -1.0 : Convert.ToDouble(textBox16.Text);

            //rateWork.UnitPriceKind = textBox18.Text;
            //rateWork.RateSettingDivide = textBox19.Text;
            //rateWork.OldNewDivCd = textBox20.Text;

            ArrayList al = new ArrayList();
            //rateWork.UnitRateSetDivCd = "1A1";
            al.Add(rateWork);

            ////////
            /*
            rateWork = new RateWork();
            rateWork.EnterpriseCode = textBox1.Text;
            rateWork.SectionCode = textBox2.Text;
            rateWork.UnitRateSetDivCd = "1A2";
            rateWork.GoodsMakerCd = textBox4.Text == "" ? 0 : Convert.ToInt32(textBox4.Text);
            rateWork.GoodsNo = textBox5.Text;
            rateWork.GoodsRateRank = textBox6.Text;
            rateWork.LargeGoodsGanreCode = textBox7.Text;
            rateWork.MediumGoodsGanreCode = textBox8.Text;
            rateWork.DetailGoodsGanreCode = textBox9.Text;
            rateWork.EnterpriseGanreCode = textBox10.Text == "" ? 0 : Convert.ToInt32(textBox10.Text);
            rateWork.BLGoodsCode = textBox11.Text == "" ? 0 : Convert.ToInt32(textBox11.Text);
            rateWork.CustomerCode = textBox12.Text == "" ? 0 : Convert.ToInt32(textBox12.Text);
            rateWork.CustRateGrpCode = textBox13.Text == "" ? 0 : Convert.ToInt32(textBox13.Text);
            rateWork.SupplierCd = textBox14.Text == "" ? 0 : Convert.ToInt32(textBox14.Text);
            rateWork.SuppRateGrpCode = textBox15.Text == "" ? 0 : Convert.ToInt32(textBox15.Text);
            rateWork.LotCount = textBox16.Text == "" ? -1.0 : Convert.ToDouble(textBox16.Text);

            rateWork.UnitPriceKind = textBox18.Text;
            rateWork.RateSettingDivide = textBox19.Text;
            rateWork.OldNewDivCd = textBox20.Text;

            al.Add(rateWork);
            */ 
            
            //dataGridView2.DataSource = al;
            Search(al);

        }

        private void Search(ArrayList al)
        {
            //object objParam = dataGridView2.DataSource;
            object objParam = (object)al;
            object objResult = null;
            int status = rateDB.Search(out objResult, objParam, 0, 0);
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                // XMLの読み込み
                Text = "該当データ有り  HIT " + ((ArrayList)objResult).Count.ToString() + "件";

                dataGridView1.DataSource = objResult;
            }		
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RateSearchParamWork rateSearchParamWork = new RateSearchParamWork();

            rateSearchParamWork.EnterpriseCode = textBox1.Text;
            if (textBox2.Text != string.Empty)
            {
                string[] SectionCodes = new string[1];
                SectionCodes[0] = textBox2.Text;
                rateSearchParamWork.SectionCode = SectionCodes;
            }
            if (textBox12.Text != string.Empty)
            {
                int[] CustomerCodes = new int[1];
                CustomerCodes[0] = Convert.ToInt32(textBox12.Text);
                rateSearchParamWork.CustomerCode = CustomerCodes;
            }
            if (textBox13.Text != String.Empty)
            {
                int[] CustRateGrpCode = new int[1];
                CustRateGrpCode[0] = Convert.ToInt32(textBox13.Text);
                rateSearchParamWork.CustRateGrpCode = CustRateGrpCode;

            }
            rateSearchParamWork.SupplierCd = Convert.ToInt32(textBox14.Text);
            object al = rateSearchParamWork as object;
            SearchRate(al);
        }

        private void SearchRate(object al)
        {
            //object objParam = dataGridView2.DataSource;
            object objParam = al;
            object objResult = null;
            int status = rateDB.SearchRate(out objResult, objParam, 0, 0);
            if (status != 0)
            {
                Text = "該当データ無し";
            }
            else
            {
                // XMLの読み込み
                Text = "該当データ有り  HIT " + ((ArrayList)objResult).Count.ToString() + "件";

                dataGridView1.DataSource = objResult;
            }
        }

    }
}
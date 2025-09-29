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
        IStockTransListResultDB stockTransListResultDB = null;
        
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0113180842031000";
            textBox2.Text = "000001";
            textBox7.Text = "0";
            textBox8.Text = "200704";
            textBox9.Text = "200803";
            textBox10.Text = "1";
            textBox11.Text = "200704";
            textBox12.Text = "200803";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            stockTransListResultDB = MediationStockTransListResultDB.GetStockTransListResultDB();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockTransListCndtnWork stockTransListCndtnWork = null;

            stockTransListCndtnWork = new StockTransListCndtnWork();

            // 企業コード
            stockTransListCndtnWork.EnterpriseCode = textBox1.Text;

            //拠点別集計区分プロパティ
            //0:全社集計／1:拠点別集計
            stockTransListCndtnWork.GroupBySectionDiv = 1;

            //帳票集計区分プロパティ
            //（予備項目）0:商品別／1:仕入先別／2:担当者別
            stockTransListCndtnWork.PrintSelectDiv = 2;

            // 拠点コード
            string[] SectionCodes = new string[2];
            SectionCodes[0] = textBox2.Text;
            //SectionCodes[1] = "000002";
            stockTransListCndtnWork.AddUpSecCodes = SectionCodes;

            //開始当期月
            stockTransListCndtnWork.St_ThisYearMonth = Convert.ToInt32(textBox8.Text);

            //終了当期月
            stockTransListCndtnWork.Ed_ThisYearMonth = Convert.ToInt32(textBox9.Text);

            //集計単位
            //0:商品コード  1:BLコード  2:自社分類コード  3:商品区分詳細コード  4:詳細区分コード  5:商品区分グループコード  6:メーカーコード</value>
            //salesRsltListCndtnWork.TtlType = 0;
            stockTransListCndtnWork.SummaryUnit = 0;

            //在庫取寄区分プロパティ
            //0:合計 1:在庫 2:取寄
            stockTransListCndtnWork.StockOrderDiv = 0;

            //従業員コード
            stockTransListCndtnWork.St_EmployeeCode = "";
            stockTransListCndtnWork.Ed_EmployeeCode = "";

            //得意先コード
            stockTransListCndtnWork.St_SupplierCd = 0;
            stockTransListCndtnWork.Ed_SupplierCd = 0;

            //メーカーコード
            stockTransListCndtnWork.St_GoodsMakerCd = 0;
            stockTransListCndtnWork.Ed_GoodsMakerCd = 0;

            //商品番号
            stockTransListCndtnWork.St_GoodsNo = "";
            stockTransListCndtnWork.Ed_GoodsNo = "";

            //BL商品コード
            stockTransListCndtnWork.St_BLGoodsCode = 0;
            stockTransListCndtnWork.Ed_BLGoodsCode = 0;

            //商品区分グループコード
            stockTransListCndtnWork.St_LargeGoodsGanreCode = "";
            stockTransListCndtnWork.Ed_LargeGoodsGanreCode = "";

            //商品区分コード
            stockTransListCndtnWork.St_MediumGoodsGanreCode = "";
            stockTransListCndtnWork.Ed_MediumGoodsGanreCode = "";

            //商品区分詳細コード
            stockTransListCndtnWork.St_DetailGoodsGanreCode = "";
            stockTransListCndtnWork.Ed_DetailGoodsGanreCode = "";

            //自社分類コード
            stockTransListCndtnWork.St_EnterpriseGanreCode = 0;
            stockTransListCndtnWork.Ed_EnterpriseGanreCode = 0;

            //仕入先コード
            stockTransListCndtnWork.St_SupplierCd = 0;
            stockTransListCndtnWork.Ed_SupplierCd = 0;

            //出荷数
            stockTransListCndtnWork.St_TotalStockCount = 1.0;
            stockTransListCndtnWork.Ed_TotalStockCount = 99999999.0;


            //集計区分
            //salesRsltListCndtnWork.TotalType = textBox10.Text == "" ? 0 : Convert.ToInt32(textBox10.Text);


            ArrayList al = new ArrayList();
            al.Add(stockTransListCndtnWork);
            dataGridView2.DataSource = al;

            Search();


        }

        private void Search()
        {
            object objParam = dataGridView2.DataSource;
            object objResult = null;
            try
            {
                int status = stockTransListResultDB.Search(out objResult, objParam);
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

    }
}
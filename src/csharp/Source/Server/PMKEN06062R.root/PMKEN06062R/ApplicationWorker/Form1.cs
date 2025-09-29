using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;

namespace WindowsApplicationWorker
{
    /// <summary>
    /// Form1 の概要の説明です。
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txtMakerCd;
        private System.Windows.Forms.DataGrid dataGrid1;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHinban;

        //private CTICustomerSearchRetWork _cTICustomerSearchRetWork = null;

        //private CTICustomerSearchRetWork _prevCTICustomerSearchRetWork = null;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnSearch;

        //private IOfferPrimeBlSearchDB iofferPrimeBlSearchDB = null;
        private IUsrJoinPartsSearchDB iUsrJoinPartsSearchDB = null;


        private static System.Windows.Forms.Form _form = null;
        private DataGrid dataGrid2;
        private DataGrid dataGrid3;
        private DataGrid dataGrid4;
        private Button button1;
        private static string[] _parameter;

        public Form1()
        {
            //
            // Windows フォーム デザイナ サポートに必要です。
            //
            InitializeComponent();

            //
            // TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
            //
        }

        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMakerCd = new System.Windows.Forms.TextBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button9 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHinban = new System.Windows.Forms.TextBox();
            this.btnJoin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.dataGrid4 = new System.Windows.Forms.DataGrid();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMakerCd
            // 
            this.txtMakerCd.Location = new System.Drawing.Point(84, 8);
            this.txtMakerCd.Name = "txtMakerCd";
            this.txtMakerCd.Size = new System.Drawing.Size(155, 19);
            this.txtMakerCd.TabIndex = 1;
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 61);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(1036, 161);
            this.dataGrid1.TabIndex = 13;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(323, 34);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(96, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "品番曖昧";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "品番";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHinban
            // 
            this.txtHinban.Location = new System.Drawing.Point(83, 33);
            this.txtHinban.Name = "txtHinban";
            this.txtHinban.Size = new System.Drawing.Size(155, 19);
            this.txtHinban.TabIndex = 23;
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(323, 5);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(96, 24);
            this.btnJoin.TabIndex = 33;
            this.btnJoin.Text = "結合検索";
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 23);
            this.label1.TabIndex = 35;
            this.label1.Text = "メーカコード";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(576, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "Time:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(624, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 19);
            this.textBox2.TabIndex = 39;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(447, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 24);
            this.btnSearch.TabIndex = 58;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGrid2
            // 
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(16, 225);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(1036, 161);
            this.dataGrid2.TabIndex = 59;
            // 
            // dataGrid3
            // 
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(16, 390);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(1036, 161);
            this.dataGrid3.TabIndex = 60;
            // 
            // dataGrid4
            // 
            this.dataGrid4.DataMember = "";
            this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid4.Location = new System.Drawing.Point(16, 554);
            this.dataGrid4.Name = "dataGrid4";
            this.dataGrid4.Size = new System.Drawing.Size(1036, 161);
            this.dataGrid4.TabIndex = 61;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(447, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 24);
            this.button1.TabIndex = 62;
            this.button1.Text = "0710Test";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.ClientSize = new System.Drawing.Size(1064, 718);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGrid4);
            this.Controls.Add(this.dataGrid3);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtHinban);
            this.Controls.Add(this.txtMakerCd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.dataGrid1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            /*
            _form = new Form1();
            System.Windows.Forms.Application.Run(_form);
            */
            //*
            try
            {
                string msg = "";
                _parameter = args;
                //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。
                //出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(out msg, ref args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                //int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, 
                //　　　　　　　　　　　　　　　　　　　　　　　　　　　　new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    _form = new Form1();
                    System.Windows.Forms.Application.Run(_form);
                }
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "Form1", msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "Form1", ex.Message, 0, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
            //*/
        }

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">メッセージ</param>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();
            //従業員ログオフのメッセージを表示
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "Form1", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "Form1", e.ToString(), 0, MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();


        }

        private void button9_Click(object sender, System.EventArgs e)
        {

            // 初期化
#if False
			ArrayList RetParts1 = new ArrayList();
			ArrayList RetParts2 = new ArrayList();
			object data1 = null;
			object data2 = null;
			data1 = RetParts1;
			data2 = RetParts2;

			int[] iSet = new int[1];
			iSet[0] = 11392;

			OfferPrimeBlSearchCondWork OfferPrimeBlSearchCondWork = new OfferPrimeBlSearchCondWork();

//			OfferPrimeBlSearchCondWork.TbsPartsCode = 7350;
			OfferPrimeBlSearchCondWork.TbsPartsCode = 5250;
			OfferPrimeBlSearchCondWork.TbsPartsCdDerivedNo = 0;
			OfferPrimeBlSearchCondWork.FullModelFixedNo = iSet;
#endif
            DateTime start, end;
            start = DateTime.Now;



            UsrPartsNoSearchCondWork usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
            usrJoinPartsCondWork.MakerCode = 1;
            usrJoinPartsCondWork.PrtsNo = "1";

            ArrayList usrRet = null;
            //ArrayList usrJoinPartsRetWork = null;
            //ArrayList usrGoodsRetWork = null;
            //ArrayList usrSetPartsRetWork = null;
            //ArrayList usrPartsPrice = null;
            object retObj;

            int status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retObj, UsrSearchFlg.UsrPartsAndAll, 0, usrJoinPartsCondWork);


            //            textBox7.Text = ((ArrayList)data).Count.ToString();
            end = DateTime.Now;
            textBox2.Text = Convert.ToString((end - start).TotalSeconds);
            CustomSerializeArrayList lst = retObj as CustomSerializeArrayList;
            if (lst.Count > 0)
            {
                usrRet = lst[0] as ArrayList;
                dataGrid2.DataSource = (ArrayList)usrRet;
            }
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            // 初期化
            ArrayList usrGoodsRetAry;
            ArrayList usrPriceRet;
            ArrayList usStockRet;

            UsrPartsNoSearchCondWork usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();

            usrJoinPartsCondWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            int makercd;
            if(int.TryParse(txtMakerCd.Text, out makercd))
                usrJoinPartsCondWork.MakerCode = makercd;
            //usrJoinPartsCondWork.PrtsNo = "TEST-01";
            usrJoinPartsCondWork.PrtsNo = txtHinban.Text;

            int status = iUsrJoinPartsSearchDB.UserGoodsSearch(usrJoinPartsCondWork, 0, out usrGoodsRetAry, out usrPriceRet, out usStockRet);
            dataGrid2.DataSource = usrGoodsRetAry;

        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            /*
			CTICustomerSearchParaWork cTICustomerSearchParaWork = new CTICustomerSearchParaWork();
			cTICustomerSearchParaWork.EnterpriseCode = textBox1.Text;
			ArrayList al = new ArrayList();
			al.Add(cTICustomerSearchParaWork);

			dataGrid1.DataSource = null;
			dataGrid1.DataSource = al;
             */
        }

        private void btnJoin_Click(object sender, System.EventArgs e)
        {
            //ArrayList usrPartsSubstRetWork;
            //ArrayList usrJoinPartsRetWork;
            //ArrayList usrGoodsRetWork;
            //ArrayList usrSetPartsRetWork;
            //ArrayList usrPartsPrice = null;

            UsrPartsNoSearchCondWork usrPartsNoSearchCondWork = new UsrPartsNoSearchCondWork();
            usrPartsNoSearchCondWork.MakerCode = Convert.ToInt32(txtMakerCd.Text);
            usrPartsNoSearchCondWork.PrtsNo = txtHinban.Text;
            object retObj;

            int status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retObj, UsrSearchFlg.UsrPartsAndAll, 0, usrPartsNoSearchCondWork);

            CustomSerializeArrayList arrList = retObj as CustomSerializeArrayList;

            for (int i = 0; i < arrList.Count; i++)
            {
                ArrayList usrRet = arrList[i] as ArrayList;
                switch (usrRet[0].GetType().Name)
                {
                    case "UsrPartsSubstRetWork":
                        //ユーザー結合検索:代替情報
                        dataGrid1.DataSource = usrRet;
                        break;
                    case "UsrJoinPartsRetWork":
                        //ユーザー結合検索:結合情報
                        dataGrid2.DataSource = usrRet;
                        break;
                    case "UsrSetPartsRetWork":
                        //ユーザー結合検索:セット情報
                        dataGrid4.DataSource = usrRet;
                        break;
                    case "UsrGoodsRetWork":
                        //ユーザー結合検索:商品情報
                        dataGrid3.DataSource = usrRet;
                        break;
                    case "UsrGoodsPriceWork":
                        //SetUsrGoodsPriceTable(usrRet);
                        break;
                    case "StockWork":
                        //SetUsrGoodsStockTable(usrRet);
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Search(ref object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode)
            //GoodsUnitDataWork
            CustomSerializeArrayList list = new CustomSerializeArrayList();
            list.Add(new GoodsUnitDataWork());
            object objRet = (object)list;
            GoodsUCndtnWork paraObj = new GoodsUCndtnWork();
            paraObj.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            paraObj.GoodsNo = txtHinban.Text;
            int status = iUsrJoinPartsSearchDB.Search(ref objRet, (object)paraObj, 0, ConstantManagement.LogicalMode.GetData0);
            //string a = "";
        }

    }
}

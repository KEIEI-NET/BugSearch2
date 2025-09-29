using System;
using Broadleaf.Library.Text;
using DataDynamics.ActiveReports;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;// ADD　2014/09/16 時シン 伝票番号印字区分の追加
using Broadleaf.Application.UIData;// ADD　2014/09/16 時シン 伝票番号印字区分の追加

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 仕入先元帳明細フォーム印刷クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入先元帳の明細印刷を行います。</br>
	/// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2007.11.14</br>
	/// <br></br>
    /// <br>UpdateNote : 消費税転嫁方式が反映されずに表示される問題対応</br>
    /// <br>Programmer : FSI斎藤 和宏</br>
    /// <br>Date       : 2012/11/01</br>
    /// <br></br>
    /// <br>UpdateNote : 請求転嫁が仕入先の場合、合計残高が合致しない問題対応</br>
    /// <br>Programmer : FSI菅原 庸平</br>
    /// <br>Date       : 2012/11/14</br>
    /// <br>Update Note: 2014/09/16 時シン</br>
    /// <br>           : ㈱陸整自動車用品 伝票番号印字区分の追加</br>
	/// </remarks>
	public class PMKOU02033P_02_Detail : DataDynamics.ActiveReports.ActiveReport3
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
        // --- DEL　2014/09/16 時シン 伝票番号印字区分の追加------->>>>>
        //public PMKOU02033P_02_Detail()
        //{
        //    InitializeComponent();
        //}
        // --- DEL　2014/09/16 時シン 伝票番号印字区分の追加-------<<<<<
        // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加------->>>>>
        public PMKOU02033P_02_Detail(SFCMN06002C PrintInfo)
        {
            InitializeComponent();

            this._printInfo = PrintInfo;
            this._ledgerCmnCndtn = this._printInfo.jyoken as LedgerCmnCndtn;

            if (_ledgerCmnCndtn.PrintDiv == 0)
            {
                this.SlipNo.DataField = "SupplierSlipNo";
                this.PartySaleSlipNum.DataField = "PartySaleSlipNum";
                this.SlipNo.OutputFormat = "000000000";
                this.PartySaleSlipNum.OutputFormat = "";

            }
            else
            {
                this.SlipNo.DataField = "PartySaleSlipNum";
                this.PartySaleSlipNum.DataField = "SupplierSlipNo";
                this.SlipNo.OutputFormat = "";
                this.PartySaleSlipNum.OutputFormat = "000000000";
            }
        }
        // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加-------<<<<<
		#endregion
        // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加------->>>>>
        // 印刷情報
        private SFCMN06002C _printInfo;

        // 抽出条件クラス
        private LedgerCmnCndtn _ledgerCmnCndtn = null;
        // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加-------<<<<<
        private TextBox DraftPayTimeLimit;
        private TextBox PartySaleSlipNum;
        private TextBox KeyThisTimeTtlBlcPay;

		//================================================================================
		//  内部変数
		//================================================================================
		#region private member
		// 拠点情報印字有無
		private bool _isSectionPrint = false;
        private Label label12;
        private TextBox TotalStockPrice;
        private TextBox TotalConsTax;
        private TextBox textBox3;
        private Line line1;
        private TextBox KeyAddUpSecCode;
        private TextBox KeyCustomerCode;
        private TextBox KeyAddUpDate;
   		#endregion
        private TextBox SubConsTax1;
        private TextBox SubConsTax;
        private TextBox SubStockPrice1;
        private TextBox SubStockPrice;
        private Label SlitTitle;
        private TextBox LastMonthBalance;
        private Line line2;

        public int _lastTimePayment = 0;
        public string _slitTitle = "";
        private long _StockSubttlPrice;
        private TextBox TotalBalance;
        private TextBox GoodsNameMny;
        private TextBox StockRecordCd;
        private TextBox GoodsDivMny;
        private long _StockPriceConsTax;

        // --- ADD 2012/11/01 ---------->>>>>
        // 消費税転嫁方式
        public int _suppCTaxLayCd = 0;
        // 消費税額
        public long _thisStockTaxValue = 0;
        // --- ADD 2012/11/01 ----------<<<<<

		//================================================================================
		//  プロパティ 
		//================================================================================
		#region public property
		/// <summary>
		/// 拠点情報印字有無
		/// </summary>
		public bool IsSectionPrint
		{
			set{this._isSectionPrint = value;}
		}
		#endregion
		
		//================================================================================
		//  イベント
		//================================================================================
		#region event
		/// <summary>
		/// 明細ヘッダフォーマットイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.11.14</br>
		/// </remarks>
        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            int iStockPrice = 0;
            int iConsTax = 0;
            int iPayment = 0;

            if (this.StockPrice.Value != null)
            {
                iStockPrice = TStrConv.StrToIntDef(this.StockPrice.Value.ToString(), 0);
                iConsTax = TStrConv.StrToIntDef(this.ConsTax.Value.ToString(), 0);
            }

            if (this.Payment.Value != null)
            {
                iPayment = TStrConv.StrToIntDef(this.Payment.Value.ToString(), 0);
            }

            // --- DEL 2012/11/14 ---------->>>>>
            //this._lastTimePayment = (this._lastTimePayment + (iStockPrice + iConsTax)) - iPayment;
            // --- DEL 2012/11/14 ----------<<<<<

            // --- ADD 2012/11/14 ---------->>>>>
            // 消費税転嫁方式で仕入先の場合
            if (this._suppCTaxLayCd == 2 || // 請求子の場合
                this._suppCTaxLayCd == 3)   // 請求親の場合
            {
                this._lastTimePayment = (this._lastTimePayment + (iStockPrice )) - iPayment;
            }
            else
            {
                this._lastTimePayment = (this._lastTimePayment + (iStockPrice + iConsTax)) - iPayment;
            }
            // --- ADD 2012/11/14 ----------<<<<<

            this.Balance.Value = this._lastTimePayment;

            if (StockAddUpADate.Value != null)
            {
                int idt = int.Parse(StockAddUpADate.Value.ToString());
                DateTime dt = TDateTime.LongDateToDateTime(idt);
                this.StockAddUpADate.Text = dt.Year.ToString() + "/" + dt.Month.ToString() + "/" + dt.Day.ToString();
            }

            DraftPayTimeLimit.Visible = true;
            if ((DraftPayTimeLimit.Value != null) && (DraftPayTimeLimit.Value.ToString() != ""))
            {
                int idt = int.Parse(DraftPayTimeLimit.Value.ToString());
                DateTime dt = TDateTime.LongDateToDateTime(idt);
                this.DraftPayTimeLimit.Text = dt.Year.ToString() + "/" + dt.Month.ToString() + "/" + dt.Day.ToString();

                if (DraftPayTimeLimit.Text == "1/1/1")
                {
                    DraftPayTimeLimit.Visible = false;
                }
            }

            if ((StockPrice.Value != null) && (StockPrice.Value.ToString() != ""))
            {
                _StockPriceConsTax += long.Parse(StockPrice.Value.ToString());
            }
            if ((ConsTax.Value != null) && (ConsTax.Value.ToString() != ""))
            {
                _StockSubttlPrice += long.Parse(ConsTax.Value.ToString());
            }
            if (StockRecordCd.Value != null)
            {
                if (int.Parse(StockRecordCd.Value.ToString()) == 1)
                {
                    switch (int.Parse(GoodsDivMny.Value.ToString()))
                    {
                        case 101:
                            SlipKindNm.Value = "現金";
                            break;
                        case 102:
                            SlipKindNm.Value = "振込";
                            break;
                        case 107:
                            SlipKindNm.Value = "小切手";
                            break;
                        case 105:
                            SlipKindNm.Value = "手形";
                            break;
                        case 106:
                            SlipKindNm.Value = "相殺";
                            break;
                        case 109:
                            SlipKindNm.Value = "その他";
                            break;
                        // --- ADD 2012/11/01 ---------->>>>>
                        case 998:
                            SlipKindNm.Value = "手数料";
                            break;
                        case 999:
                            SlipKindNm.Value = "値引";
                            break;
                        // --- ADD 2012/11/01 ----------<<<<<
                        default:
                            SlipKindNm.Value = "口座振替";
                            break;
                    }
                    GoodsNameMny.Value = "0";
                }
            }

            // --- ADD 2012/11/01 ---------->>>>>
            // 消費税転嫁方式で消費税印字アイテムを制御
            if (this._suppCTaxLayCd == 2 || // 請求子の場合
                this._suppCTaxLayCd == 3 || // 請求親の場合
                this._suppCTaxLayCd == 9)   // 非課税の場合
            {
                // 印字しない
                ConsTax.Visible = false;
            }
            else if (this._suppCTaxLayCd == 0 || // 伝票単位の場合
                     this._suppCTaxLayCd == 1)   // 明細単位の場合
            {
                // 印字する
                ConsTax.Visible = true;
            }
            // --- ADD 2012/11/01 ----------<<<<<

            // --- ADD　2014/10/17 時シン 「支払」の場合、「支払伝票番号」は常に「伝票番号」欄に印字する------->>>>>
            if (SlipKindNm.Value != null)
            {
                if ((!"仕入".Equals(SlipKindNm.Value.ToString())) && this._ledgerCmnCndtn.PrintDiv == 1)
                {
                    SlipNo.Value = PartySaleSlipNum.Value.ToString().PadLeft(9, '0');
                    PartySaleSlipNum.Visible = false;
                }
                else
                {
                    PartySaleSlipNum.Visible = true;
                }

            }
            // --- ADD　2014/10/17 時シン 「支払」の場合、「支払伝票番号」は常に「伝票番号」欄に印字する-------<<<<<

        }

		/// <summary>
		/// 明細ビフォープリントイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画される前に発生します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
        /// <br>Date        : 2007.11.14</br>
		/// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
			// レポート用文字列編集処理
			PrintCommonLibrary.ConvertReportString(this.Detail);
		}
		#endregion
		
		// ===============================================================================
		// ActiveReportsデザイナで生成されたコード
		// ===============================================================================
		#region ActiveReports Designer generated code
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox StockAddUpADate;
        private DataDynamics.ActiveReports.TextBox SlipNo;
        private DataDynamics.ActiveReports.TextBox SlipKindNm;
		private DataDynamics.ActiveReports.TextBox StockPrice;
		private DataDynamics.ActiveReports.TextBox ConsTax;
		private DataDynamics.ActiveReports.TextBox Payment;
		private DataDynamics.ActiveReports.TextBox Balance;
        private DataDynamics.ActiveReports.TextBox SupplierSlipNote1;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKOU02033P_02_Detail));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.StockAddUpADate = new DataDynamics.ActiveReports.TextBox();
            this.SlipNo = new DataDynamics.ActiveReports.TextBox();
            this.SlipKindNm = new DataDynamics.ActiveReports.TextBox();
            this.StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.ConsTax = new DataDynamics.ActiveReports.TextBox();
            this.Payment = new DataDynamics.ActiveReports.TextBox();
            this.Balance = new DataDynamics.ActiveReports.TextBox();
            this.SupplierSlipNote1 = new DataDynamics.ActiveReports.TextBox();
            this.DraftPayTimeLimit = new DataDynamics.ActiveReports.TextBox();
            this.PartySaleSlipNum = new DataDynamics.ActiveReports.TextBox();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.GoodsNameMny = new DataDynamics.ActiveReports.TextBox();
            this.StockRecordCd = new DataDynamics.ActiveReports.TextBox();
            this.GoodsDivMny = new DataDynamics.ActiveReports.TextBox();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.KeyThisTimeTtlBlcPay = new DataDynamics.ActiveReports.TextBox();
            this.KeyAddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.KeyCustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.KeyAddUpDate = new DataDynamics.ActiveReports.TextBox();
            this.SlitTitle = new DataDynamics.ActiveReports.Label();
            this.LastMonthBalance = new DataDynamics.ActiveReports.TextBox();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.TotalStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.TotalConsTax = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.SubConsTax1 = new DataDynamics.ActiveReports.TextBox();
            this.SubConsTax = new DataDynamics.ActiveReports.TextBox();
            this.SubStockPrice1 = new DataDynamics.ActiveReports.TextBox();
            this.SubStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.TotalBalance = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.StockAddUpADate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipKindNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Payment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Balance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNote1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftPayTimeLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySaleSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameMny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockRecordCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsDivMny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyThisTimeTtlBlcPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyAddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyCustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyAddUpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlitTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastMonthBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalConsTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubConsTax1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubConsTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubStockPrice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.StockAddUpADate,
            this.SlipNo,
            this.SlipKindNm,
            this.StockPrice,
            this.ConsTax,
            this.Payment,
            this.Balance,
            this.SupplierSlipNote1,
            this.DraftPayTimeLimit,
            this.PartySaleSlipNum,
            this.line1,
            this.GoodsNameMny,
            this.StockRecordCd,
            this.GoodsDivMny});
            this.Detail.Height = 0.281F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // StockAddUpADate
            // 
            this.StockAddUpADate.Border.BottomColor = System.Drawing.Color.Black;
            this.StockAddUpADate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAddUpADate.Border.LeftColor = System.Drawing.Color.Black;
            this.StockAddUpADate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAddUpADate.Border.RightColor = System.Drawing.Color.Black;
            this.StockAddUpADate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAddUpADate.Border.TopColor = System.Drawing.Color.Black;
            this.StockAddUpADate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockAddUpADate.DataField = "StockAddUpADate";
            this.StockAddUpADate.Height = 0.125F;
            this.StockAddUpADate.Left = 0.125F;
            this.StockAddUpADate.MultiLine = false;
            this.StockAddUpADate.Name = "StockAddUpADate";
            this.StockAddUpADate.OutputFormat = resources.GetString("StockAddUpADate.OutputFormat");
            this.StockAddUpADate.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.StockAddUpADate.Text = "2007年05月09日";
            this.StockAddUpADate.Top = 0.0625F;
            this.StockAddUpADate.Width = 0.8125F;
            // 
            // SlipNo
            // 
            this.SlipNo.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo.Border.RightColor = System.Drawing.Color.Black;
            this.SlipNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo.Border.TopColor = System.Drawing.Color.Black;
            this.SlipNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipNo.DataField = "SupplierSlipNo";
            this.SlipNo.Height = 0.125F;
            this.SlipNo.Left = 0.8125F;
            this.SlipNo.MultiLine = false;
            this.SlipNo.Name = "SlipNo";
            this.SlipNo.OutputFormat = resources.GetString("SlipNo.OutputFormat");
            this.SlipNo.Style = "text-align: left; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.SlipNo.Text = "12345678901234567890";
            this.SlipNo.Top = 0.0625F;
            this.SlipNo.Width = 1.188F;
            // 
            // SlipKindNm
            // 
            this.SlipKindNm.Border.BottomColor = System.Drawing.Color.Black;
            this.SlipKindNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipKindNm.Border.LeftColor = System.Drawing.Color.Black;
            this.SlipKindNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipKindNm.Border.RightColor = System.Drawing.Color.Black;
            this.SlipKindNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipKindNm.Border.TopColor = System.Drawing.Color.Black;
            this.SlipKindNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlipKindNm.DataField = "SlipKindNm";
            this.SlipKindNm.Height = 0.1875F;
            this.SlipKindNm.Left = 1.9375F;
            this.SlipKindNm.MultiLine = false;
            this.SlipKindNm.Name = "SlipKindNm";
            this.SlipKindNm.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.SlipKindNm.Text = "仕入";
            this.SlipKindNm.Top = 0.0625F;
            this.SlipKindNm.Width = 0.5625F;
            // 
            // StockPrice
            // 
            this.StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.DataField = "StockSubttlPrice";
            this.StockPrice.Height = 0.1377953F;
            this.StockPrice.Left = 2.375F;
            this.StockPrice.MultiLine = false;
            this.StockPrice.Name = "StockPrice";
            this.StockPrice.OutputFormat = resources.GetString("StockPrice.OutputFormat");
            this.StockPrice.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.StockPrice.Text = "123,456,789,012";
            this.StockPrice.Top = 0.0625F;
            this.StockPrice.Width = 0.9212598F;
            // 
            // ConsTax
            // 
            this.ConsTax.Border.BottomColor = System.Drawing.Color.Black;
            this.ConsTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTax.Border.LeftColor = System.Drawing.Color.Black;
            this.ConsTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTax.Border.RightColor = System.Drawing.Color.Black;
            this.ConsTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTax.Border.TopColor = System.Drawing.Color.Black;
            this.ConsTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ConsTax.DataField = "StockPriceConsTax";
            this.ConsTax.Height = 0.1377953F;
            this.ConsTax.Left = 3.375F;
            this.ConsTax.MultiLine = false;
            this.ConsTax.Name = "ConsTax";
            this.ConsTax.OutputFormat = resources.GetString("ConsTax.OutputFormat");
            this.ConsTax.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.ConsTax.Text = "123,456,789,012";
            this.ConsTax.Top = 0.0625F;
            this.ConsTax.Width = 0.9212598F;
            // 
            // Payment
            // 
            this.Payment.Border.BottomColor = System.Drawing.Color.Black;
            this.Payment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Payment.Border.LeftColor = System.Drawing.Color.Black;
            this.Payment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Payment.Border.RightColor = System.Drawing.Color.Black;
            this.Payment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Payment.Border.TopColor = System.Drawing.Color.Black;
            this.Payment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Payment.DataField = "Payment";
            this.Payment.Height = 0.1377953F;
            this.Payment.Left = 4.3125F;
            this.Payment.MultiLine = false;
            this.Payment.Name = "Payment";
            this.Payment.OutputFormat = resources.GetString("Payment.OutputFormat");
            this.Payment.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.Payment.Text = "123,456,789,012";
            this.Payment.Top = 0.0625F;
            this.Payment.Width = 0.9212598F;
            // 
            // Balance
            // 
            this.Balance.Border.BottomColor = System.Drawing.Color.Black;
            this.Balance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Balance.Border.LeftColor = System.Drawing.Color.Black;
            this.Balance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Balance.Border.RightColor = System.Drawing.Color.Black;
            this.Balance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Balance.Border.TopColor = System.Drawing.Color.Black;
            this.Balance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Balance.Height = 0.1377953F;
            this.Balance.Left = 6.1875F;
            this.Balance.MultiLine = false;
            this.Balance.Name = "Balance";
            this.Balance.OutputFormat = resources.GetString("Balance.OutputFormat");
            this.Balance.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.Balance.Text = "123,456,789,012";
            this.Balance.Top = 0.0625F;
            this.Balance.Width = 0.9212598F;
            // 
            // SupplierSlipNote1
            // 
            this.SupplierSlipNote1.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierSlipNote1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNote1.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierSlipNote1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNote1.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierSlipNote1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNote1.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierSlipNote1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSlipNote1.DataField = "SupplierSlipNote1";
            this.SupplierSlipNote1.Height = 0.125F;
            this.SupplierSlipNote1.Left = 8.4375F;
            this.SupplierSlipNote1.MultiLine = false;
            this.SupplierSlipNote1.Name = "SupplierSlipNote1";
            this.SupplierSlipNote1.OutputFormat = resources.GetString("SupplierSlipNote1.OutputFormat");
            this.SupplierSlipNote1.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.SupplierSlipNote1.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５";
            this.SupplierSlipNote1.Top = 0.0625F;
            this.SupplierSlipNote1.Width = 2.6875F;
            // 
            // DraftPayTimeLimit
            // 
            this.DraftPayTimeLimit.Border.BottomColor = System.Drawing.Color.Black;
            this.DraftPayTimeLimit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayTimeLimit.Border.LeftColor = System.Drawing.Color.Black;
            this.DraftPayTimeLimit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayTimeLimit.Border.RightColor = System.Drawing.Color.Black;
            this.DraftPayTimeLimit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayTimeLimit.Border.TopColor = System.Drawing.Color.Black;
            this.DraftPayTimeLimit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DraftPayTimeLimit.DataField = "ValidityTerm";
            this.DraftPayTimeLimit.Height = 0.125F;
            this.DraftPayTimeLimit.Left = 5.3125F;
            this.DraftPayTimeLimit.MultiLine = false;
            this.DraftPayTimeLimit.Name = "DraftPayTimeLimit";
            this.DraftPayTimeLimit.OutputFormat = resources.GetString("DraftPayTimeLimit.OutputFormat");
            this.DraftPayTimeLimit.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.DraftPayTimeLimit.Text = "2007年05月09日";
            this.DraftPayTimeLimit.Top = 0.0625F;
            this.DraftPayTimeLimit.Width = 0.8125F;
            // 
            // PartySaleSlipNum
            // 
            this.PartySaleSlipNum.Border.BottomColor = System.Drawing.Color.Black;
            this.PartySaleSlipNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySaleSlipNum.Border.LeftColor = System.Drawing.Color.Black;
            this.PartySaleSlipNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySaleSlipNum.Border.RightColor = System.Drawing.Color.Black;
            this.PartySaleSlipNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySaleSlipNum.Border.TopColor = System.Drawing.Color.Black;
            this.PartySaleSlipNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartySaleSlipNum.DataField = "PartySaleSlipNum";
            this.PartySaleSlipNum.Height = 0.125F;
            this.PartySaleSlipNum.Left = 7.1875F;
            this.PartySaleSlipNum.MultiLine = false;
            this.PartySaleSlipNum.Name = "PartySaleSlipNum";
            this.PartySaleSlipNum.Style = "text-align: left; font-size: 8pt; font-family: ＭＳ 明朝; white-space: inherit; ";
            this.PartySaleSlipNum.Text = "12345678901234567890";
            this.PartySaleSlipNum.Top = 0.0625F;
            this.PartySaleSlipNum.Width = 1.1875F;
            // 
            // line1
            // 
            this.line1.Border.BottomColor = System.Drawing.Color.Black;
            this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.LeftColor = System.Drawing.Color.Black;
            this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.RightColor = System.Drawing.Color.Black;
            this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.TopColor = System.Drawing.Color.Black;
            this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Height = 0F;
            this.line1.Left = 0F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 0.25F;
            this.line1.Width = 11.188F;
            this.line1.X1 = 0F;
            this.line1.X2 = 11.188F;
            this.line1.Y1 = 0.25F;
            this.line1.Y2 = 0.25F;
            // 
            // GoodsNameMny
            // 
            this.GoodsNameMny.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNameMny.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameMny.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNameMny.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameMny.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNameMny.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameMny.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNameMny.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNameMny.DataField = "GoodsNameMny";
            this.GoodsNameMny.Height = 0.125F;
            this.GoodsNameMny.Left = 10.5625F;
            this.GoodsNameMny.MultiLine = false;
            this.GoodsNameMny.Name = "GoodsNameMny";
            this.GoodsNameMny.OutputFormat = resources.GetString("GoodsNameMny.OutputFormat");
            this.GoodsNameMny.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.GoodsNameMny.Text = "１２";
            this.GoodsNameMny.Top = 0.125F;
            this.GoodsNameMny.Visible = false;
            this.GoodsNameMny.Width = 0.5625F;
            // 
            // StockRecordCd
            // 
            this.StockRecordCd.Border.BottomColor = System.Drawing.Color.Black;
            this.StockRecordCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockRecordCd.Border.LeftColor = System.Drawing.Color.Black;
            this.StockRecordCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockRecordCd.Border.RightColor = System.Drawing.Color.Black;
            this.StockRecordCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockRecordCd.Border.TopColor = System.Drawing.Color.Black;
            this.StockRecordCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockRecordCd.DataField = "StockRecordCd";
            this.StockRecordCd.Height = 0.125F;
            this.StockRecordCd.Left = 9.875F;
            this.StockRecordCd.MultiLine = false;
            this.StockRecordCd.Name = "StockRecordCd";
            this.StockRecordCd.OutputFormat = resources.GetString("StockRecordCd.OutputFormat");
            this.StockRecordCd.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.StockRecordCd.Text = "１２";
            this.StockRecordCd.Top = 0.125F;
            this.StockRecordCd.Visible = false;
            this.StockRecordCd.Width = 0.5625F;
            // 
            // GoodsDivMny
            // 
            this.GoodsDivMny.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsDivMny.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsDivMny.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsDivMny.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsDivMny.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsDivMny.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsDivMny.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsDivMny.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsDivMny.DataField = "GoodsDivMny";
            this.GoodsDivMny.Height = 0.125F;
            this.GoodsDivMny.Left = 9.1875F;
            this.GoodsDivMny.MultiLine = false;
            this.GoodsDivMny.Name = "GoodsDivMny";
            this.GoodsDivMny.OutputFormat = resources.GetString("GoodsDivMny.OutputFormat");
            this.GoodsDivMny.Style = "text-align: left; font-size: 8pt; white-space: inherit; ";
            this.GoodsDivMny.Text = "１２";
            this.GoodsDivMny.Top = 0.125F;
            this.GoodsDivMny.Visible = false;
            this.GoodsDivMny.Width = 0.5625F;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.KeyThisTimeTtlBlcPay,
            this.KeyAddUpSecCode,
            this.KeyCustomerCode,
            this.KeyAddUpDate,
            this.SlitTitle,
            this.LastMonthBalance});
            this.TitleHeader.DataField = "AddUpDate";
            this.TitleHeader.Height = 0.21875F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.TitleHeader.Format += new System.EventHandler(this.TitleHeader_Format);
            // 
            // KeyThisTimeTtlBlcPay
            // 
            this.KeyThisTimeTtlBlcPay.Border.BottomColor = System.Drawing.Color.Black;
            this.KeyThisTimeTtlBlcPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyThisTimeTtlBlcPay.Border.LeftColor = System.Drawing.Color.Black;
            this.KeyThisTimeTtlBlcPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyThisTimeTtlBlcPay.Border.RightColor = System.Drawing.Color.Black;
            this.KeyThisTimeTtlBlcPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyThisTimeTtlBlcPay.Border.TopColor = System.Drawing.Color.Black;
            this.KeyThisTimeTtlBlcPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyThisTimeTtlBlcPay.DataField = "ThisTimeTtlBlcPay";
            this.KeyThisTimeTtlBlcPay.Height = 0.1377953F;
            this.KeyThisTimeTtlBlcPay.Left = 10.1875F;
            this.KeyThisTimeTtlBlcPay.MultiLine = false;
            this.KeyThisTimeTtlBlcPay.Name = "KeyThisTimeTtlBlcPay";
            this.KeyThisTimeTtlBlcPay.OutputFormat = resources.GetString("KeyThisTimeTtlBlcPay.OutputFormat");
            this.KeyThisTimeTtlBlcPay.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.KeyThisTimeTtlBlcPay.Text = null;
            this.KeyThisTimeTtlBlcPay.Top = 0.125F;
            this.KeyThisTimeTtlBlcPay.Visible = false;
            this.KeyThisTimeTtlBlcPay.Width = 0.9212598F;
            // 
            // KeyAddUpSecCode
            // 
            this.KeyAddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.KeyAddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.KeyAddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.KeyAddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.KeyAddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpSecCode.DataField = "AddUpSecCode";
            this.KeyAddUpSecCode.Height = 0.1479167F;
            this.KeyAddUpSecCode.Left = 10.0625F;
            this.KeyAddUpSecCode.Name = "KeyAddUpSecCode";
            this.KeyAddUpSecCode.Style = "font-size: 10pt; ";
            this.KeyAddUpSecCode.Text = null;
            this.KeyAddUpSecCode.Top = 0.0625F;
            this.KeyAddUpSecCode.Visible = false;
            this.KeyAddUpSecCode.Width = 0.9375F;
            // 
            // KeyCustomerCode
            // 
            this.KeyCustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.KeyCustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyCustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.KeyCustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyCustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.KeyCustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyCustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.KeyCustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyCustomerCode.DataField = "PayeeCode";
            this.KeyCustomerCode.Height = 0.1479167F;
            this.KeyCustomerCode.Left = 8.875F;
            this.KeyCustomerCode.Name = "KeyCustomerCode";
            this.KeyCustomerCode.Style = "font-size: 10pt; ";
            this.KeyCustomerCode.Text = null;
            this.KeyCustomerCode.Top = 0.0625F;
            this.KeyCustomerCode.Visible = false;
            this.KeyCustomerCode.Width = 0.9375F;
            // 
            // KeyAddUpDate
            // 
            this.KeyAddUpDate.Border.BottomColor = System.Drawing.Color.Black;
            this.KeyAddUpDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpDate.Border.LeftColor = System.Drawing.Color.Black;
            this.KeyAddUpDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpDate.Border.RightColor = System.Drawing.Color.Black;
            this.KeyAddUpDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpDate.Border.TopColor = System.Drawing.Color.Black;
            this.KeyAddUpDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpDate.DataField = "AddUpDateInt";
            this.KeyAddUpDate.Height = 0.1479167F;
            this.KeyAddUpDate.Left = 9.4375F;
            this.KeyAddUpDate.Name = "KeyAddUpDate";
            this.KeyAddUpDate.Style = "";
            this.KeyAddUpDate.Text = null;
            this.KeyAddUpDate.Top = 0.0625F;
            this.KeyAddUpDate.Visible = false;
            this.KeyAddUpDate.Width = 0.9375F;
            // 
            // SlitTitle
            // 
            this.SlitTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SlitTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlitTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SlitTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlitTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SlitTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlitTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SlitTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlitTitle.Height = 0.1875F;
            this.SlitTitle.HyperLink = "";
            this.SlitTitle.Left = 0.0625F;
            this.SlitTitle.Name = "SlitTitle";
            this.SlitTitle.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.SlitTitle.Text = "前回残高";
            this.SlitTitle.Top = 0.0625F;
            this.SlitTitle.Width = 0.625F;
            // 
            // LastMonthBalance
            // 
            this.LastMonthBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.LastMonthBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastMonthBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.LastMonthBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastMonthBalance.Border.RightColor = System.Drawing.Color.Black;
            this.LastMonthBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastMonthBalance.Border.TopColor = System.Drawing.Color.Black;
            this.LastMonthBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastMonthBalance.Height = 0.1377953F;
            this.LastMonthBalance.Left = 6.1875F;
            this.LastMonthBalance.MultiLine = false;
            this.LastMonthBalance.Name = "LastMonthBalance";
            this.LastMonthBalance.OutputFormat = resources.GetString("LastMonthBalance.OutputFormat");
            this.LastMonthBalance.Style = "text-align: right; font-size: 8pt; font-family: ＭＳ ゴシック; white-space: inherit; ";
            this.LastMonthBalance.SummaryGroup = "TitleHeader";
            this.LastMonthBalance.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.LastMonthBalance.Text = "123,456,789,012";
            this.LastMonthBalance.Top = 0.0625F;
            this.LastMonthBalance.Width = 0.9212598F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label12,
            this.TotalStockPrice,
            this.TotalConsTax,
            this.textBox3,
            this.SubConsTax1,
            this.SubConsTax,
            this.SubStockPrice1,
            this.SubStockPrice,
            this.line2,
            this.TotalBalance});
            this.TitleFooter.Height = 0.3645833F;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Format += new System.EventHandler(this.TitleFooter_Format);
            // 
            // label12
            // 
            this.label12.Border.BottomColor = System.Drawing.Color.Black;
            this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.LeftColor = System.Drawing.Color.Black;
            this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.RightColor = System.Drawing.Color.Black;
            this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.TopColor = System.Drawing.Color.Black;
            this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Height = 0.25F;
            this.label12.HyperLink = "";
            this.label12.Left = 0.1875F;
            this.label12.Name = "label12";
            this.label12.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.label12.Text = "合計";
            this.label12.Top = 0F;
            this.label12.Width = 1.125F;
            // 
            // TotalStockPrice
            // 
            this.TotalStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.TotalStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.TotalStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalStockPrice.DataField = "StockSubttlPrice";
            this.TotalStockPrice.Height = 0.1377953F;
            this.TotalStockPrice.Left = 2.375F;
            this.TotalStockPrice.MultiLine = false;
            this.TotalStockPrice.Name = "TotalStockPrice";
            this.TotalStockPrice.OutputFormat = resources.GetString("TotalStockPrice.OutputFormat");
            this.TotalStockPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.TotalStockPrice.SummaryGroup = "TitleHeader";
            this.TotalStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TotalStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TotalStockPrice.Text = "123,456,789,012";
            this.TotalStockPrice.Top = 0.0625F;
            this.TotalStockPrice.Width = 0.9212598F;
            // 
            // TotalConsTax
            // 
            this.TotalConsTax.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalConsTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalConsTax.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalConsTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalConsTax.Border.RightColor = System.Drawing.Color.Black;
            this.TotalConsTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalConsTax.Border.TopColor = System.Drawing.Color.Black;
            this.TotalConsTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalConsTax.DataField = "StockPriceConsTax";
            this.TotalConsTax.Height = 0.1377953F;
            this.TotalConsTax.Left = 3.375F;
            this.TotalConsTax.MultiLine = false;
            this.TotalConsTax.Name = "TotalConsTax";
            this.TotalConsTax.OutputFormat = resources.GetString("TotalConsTax.OutputFormat");
            this.TotalConsTax.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.TotalConsTax.SummaryGroup = "TitleHeader";
            this.TotalConsTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TotalConsTax.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.TotalConsTax.Text = "123,456,789,012";
            this.TotalConsTax.Top = 0.0625F;
            this.TotalConsTax.Width = 0.9212598F;
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightColor = System.Drawing.Color.Black;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopColor = System.Drawing.Color.Black;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.DataField = "Payment";
            this.textBox3.Height = 0.1377953F;
            this.textBox3.Left = 4.3125F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.textBox3.SummaryGroup = "TitleHeader";
            this.textBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox3.Text = "123,456,789,012";
            this.textBox3.Top = 0.0625F;
            this.textBox3.Width = 0.9212598F;
            // 
            // SubConsTax1
            // 
            this.SubConsTax1.Border.BottomColor = System.Drawing.Color.Black;
            this.SubConsTax1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubConsTax1.Border.LeftColor = System.Drawing.Color.Black;
            this.SubConsTax1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubConsTax1.Border.RightColor = System.Drawing.Color.Black;
            this.SubConsTax1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubConsTax1.Border.TopColor = System.Drawing.Color.Black;
            this.SubConsTax1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubConsTax1.DataField = "ConsTax1";
            this.SubConsTax1.Height = 0.1377953F;
            this.SubConsTax1.Left = 9.6875F;
            this.SubConsTax1.MultiLine = false;
            this.SubConsTax1.Name = "SubConsTax1";
            this.SubConsTax1.OutputFormat = resources.GetString("SubConsTax1.OutputFormat");
            this.SubConsTax1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.SubConsTax1.SummaryGroup = "TitleHeader";
            this.SubConsTax1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SubConsTax1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SubConsTax1.Text = "123,456,789,012";
            this.SubConsTax1.Top = 0.125F;
            this.SubConsTax1.Visible = false;
            this.SubConsTax1.Width = 0.9212598F;
            // 
            // SubConsTax
            // 
            this.SubConsTax.Border.BottomColor = System.Drawing.Color.Black;
            this.SubConsTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubConsTax.Border.LeftColor = System.Drawing.Color.Black;
            this.SubConsTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubConsTax.Border.RightColor = System.Drawing.Color.Black;
            this.SubConsTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubConsTax.Border.TopColor = System.Drawing.Color.Black;
            this.SubConsTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubConsTax.DataField = "ConsTax";
            this.SubConsTax.Height = 0.1377953F;
            this.SubConsTax.Left = 9.6875F;
            this.SubConsTax.MultiLine = false;
            this.SubConsTax.Name = "SubConsTax";
            this.SubConsTax.OutputFormat = resources.GetString("SubConsTax.OutputFormat");
            this.SubConsTax.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.SubConsTax.SummaryGroup = "TitleHeader";
            this.SubConsTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SubConsTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SubConsTax.Text = "123,456,789,012";
            this.SubConsTax.Top = 0.0625F;
            this.SubConsTax.Visible = false;
            this.SubConsTax.Width = 0.9212598F;
            // 
            // SubStockPrice1
            // 
            this.SubStockPrice1.Border.BottomColor = System.Drawing.Color.Black;
            this.SubStockPrice1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubStockPrice1.Border.LeftColor = System.Drawing.Color.Black;
            this.SubStockPrice1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubStockPrice1.Border.RightColor = System.Drawing.Color.Black;
            this.SubStockPrice1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubStockPrice1.Border.TopColor = System.Drawing.Color.Black;
            this.SubStockPrice1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubStockPrice1.DataField = "StockPrice1";
            this.SubStockPrice1.Height = 0.1377953F;
            this.SubStockPrice1.Left = 8.5625F;
            this.SubStockPrice1.MultiLine = false;
            this.SubStockPrice1.Name = "SubStockPrice1";
            this.SubStockPrice1.OutputFormat = resources.GetString("SubStockPrice1.OutputFormat");
            this.SubStockPrice1.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.SubStockPrice1.SummaryGroup = "TitleHeader";
            this.SubStockPrice1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SubStockPrice1.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SubStockPrice1.Text = "123,456,789,012";
            this.SubStockPrice1.Top = 0.125F;
            this.SubStockPrice1.Visible = false;
            this.SubStockPrice1.Width = 0.9212598F;
            // 
            // SubStockPrice
            // 
            this.SubStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.SubStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.SubStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.SubStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.SubStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SubStockPrice.DataField = "StockPrice";
            this.SubStockPrice.Height = 0.1377953F;
            this.SubStockPrice.Left = 8.5625F;
            this.SubStockPrice.MultiLine = false;
            this.SubStockPrice.Name = "SubStockPrice";
            this.SubStockPrice.OutputFormat = resources.GetString("SubStockPrice.OutputFormat");
            this.SubStockPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.SubStockPrice.SummaryGroup = "TitleHeader";
            this.SubStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.SubStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.SubStockPrice.Text = "123,456,789,012";
            this.SubStockPrice.Top = 0.0625F;
            this.SubStockPrice.Visible = false;
            this.SubStockPrice.Width = 0.9212598F;
            // 
            // line2
            // 
            this.line2.Border.BottomColor = System.Drawing.Color.Black;
            this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.LeftColor = System.Drawing.Color.Black;
            this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.RightColor = System.Drawing.Color.Black;
            this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.TopColor = System.Drawing.Color.Black;
            this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Height = 0F;
            this.line2.Left = 0F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0.3125F;
            this.line2.Width = 11.188F;
            this.line2.X1 = 0F;
            this.line2.X2 = 11.188F;
            this.line2.Y1 = 0.3125F;
            this.line2.Y2 = 0.3125F;
            // 
            // TotalBalance
            // 
            this.TotalBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalBalance.Border.RightColor = System.Drawing.Color.Black;
            this.TotalBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalBalance.Border.TopColor = System.Drawing.Color.Black;
            this.TotalBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalBalance.Height = 0.1377953F;
            this.TotalBalance.Left = 6.1875F;
            this.TotalBalance.MultiLine = false;
            this.TotalBalance.Name = "TotalBalance";
            this.TotalBalance.OutputFormat = resources.GetString("TotalBalance.OutputFormat");
            this.TotalBalance.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: ＭＳ ゴシック; white-space: inherit; ";
            this.TotalBalance.Text = "123,456,789,012";
            this.TotalBalance.Top = 0.0625F;
            this.TotalBalance.Width = 0.9212598F;
            // 
            // PMKOU02033P_02_Detail
            // 
            this.MasterReport = false;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 11.26875F;
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.TitleFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            ((System.ComponentModel.ISupportInitialize)(this.StockAddUpADate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipKindNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Payment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Balance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNote1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DraftPayTimeLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PartySaleSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNameMny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockRecordCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsDivMny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyThisTimeTtlBlcPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyAddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyCustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyAddUpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlitTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastMonthBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalConsTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubConsTax1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubConsTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubStockPrice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        private void TitleFooter_Format(object sender, EventArgs e)
        {
            // --- ADD 2012/11/01 ---------->>>>>
            // 消費税転嫁方式で消費税合計の値を制御
            //if (this._suppCTaxLayCd == 2 || // 請求子の場合
            //    this._suppCTaxLayCd == 3)   // 請求親の場合
            //{
            //    this.TotalConsTax.Value = this._thisStockTaxValue;
            //}
            //else
            //{
            //    // 既存処理
            //    this.TotalConsTax.Value = TStrConv.StrToIntDef(this.SubConsTax.Value.ToString(), 0) - TStrConv.StrToIntDef(this.SubConsTax1.Value.ToString(), 0);
            //    TotalConsTax.Value = _StockSubttlPrice;
            //}
            // --- ADD 2012/11/01 ----------<<<<<

            this.TotalStockPrice.Value = TStrConv.StrToIntDef(this.SubStockPrice.Value.ToString(), 0) - TStrConv.StrToIntDef(this.SubStockPrice1.Value.ToString(), 0);
            
            TotalStockPrice.Value = _StockPriceConsTax;

            // --- DEL 2012/11/14 ---------->>>>>
            //TotalBalance.Value = this._lastTimePayment;
            // --- DEL 2012/11/14 ----------<<<<<

            // --- ADD 2012/11/14 ---------->>>>>
            int iTotalConsTax = 0;

            iTotalConsTax = TStrConv.StrToIntDef(this.TotalConsTax.Value.ToString(), 0);

            if (this._suppCTaxLayCd == 2 || // 請求子の場合
                this._suppCTaxLayCd == 3)   // 請求親の場合
            {
                TotalBalance.Value = this._lastTimePayment + iTotalConsTax;
            }
            else
            {
                TotalBalance.Value = this._lastTimePayment;
            }
            // --- ADD 2012/11/14 ----------<<<<<
        }

        private void TitleHeader_Format(object sender, EventArgs e)
        {
            this.LastMonthBalance.Value = this._lastTimePayment;
            if (this.LastMonthBalance.Value == null)
            {
                this.LastMonthBalance.Value = 0;
            }
            //this.SlitTitle.Value = "前月" + this._slitTitle;

            _StockPriceConsTax = 0;
            _StockSubttlPrice = 0;
        }
	}
}

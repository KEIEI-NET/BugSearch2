//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入先元帳
// プログラム概要   : 仕入先元帳の印刷を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 疋田 勇人
// 作 成 日  2007/11/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/04/06  修正内容 : 障害対応13145
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI斎藤 和宏
// 修 正 日  2012/11/01  修正内容 : 消費税転嫁方式が反映されずに表示される問題対応
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 時シン
// 修 正 日  2014/09/16  修正内容 : 伝票番号印字区分の追加
//----------------------------------------------------------------------------//
// 管理番号  11170129-00 作成担当 : 黄興貴
// 修 正 日  2015/08/18  修正内容 : 仕入先元帳の障害対応
//----------------------------------------------------------------------------//
// 管理番号  11170129-00 作成担当 : 黄興貴
// 修 正 日  2015/09/01  修正内容 : ソースレビュー指摘対応
//----------------------------------------------------------------------------//
// 管理番号  11170129-00 作成担当 : 黄興貴
// 修 正 日  2015/09/10  修正内容 : ソースレビュー指摘再対応
//----------------------------------------------------------------------------//
// 管理番号  11170187-00 作成担当 : 田思春
// 修 正 日  2015/10/21  修正内容 : Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応
//----------------------------------------------------------------------------//
// 管理番号  11170187-00 作成担当 : 田思春
// 修 正 日  2015/12/10  修正内容 : Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応
//                                                障害３ 複数ページに跨る条件を指定した場合、締日による改ページ不正の障害対応
//----------------------------------------------------------------------------//
// 管理番号  11170187-00 作成担当 : 陳艶丹
// 修 正 日  2016/01/05  修正内容 : Redmine#47545 ソースレビュー指摘NO3の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Collections.Specialized;
using DataDynamics.ActiveReports;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Text;
// ---------- ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ---------->>>>>
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
// ---------- ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ----------<<<<<

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// 仕入先元帳フォーム印刷クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入先元帳の印刷を行います。</br>
	/// <br>Programmer : 20081 疋田 勇人</br>
	/// <br>Date       : 2007.11.14</br>
    /// <br>Update Note: 2009/04/06 30452 上野 俊治</br>
    /// <br>            ・障害対応13145</br>
    /// <br>Update Note: 2014/09/16 時シン</br>
    /// <br>           : ㈱陸整自動車用品 伝票番号印字区分の追加</br>
    /// <br>Update Note : 2015/08/18 黄興貴 </br>
    /// <br>管理番号    : 11170129-00</br>
    /// <br>            : redmine#47013 仕入先元帳の障害対応</br>
    /// <br>Update Note : 2015/09/01 黄興貴 </br>
    /// <br>管理番号    : 11170129-00</br>
    /// <br>            : redmine#47013 ソースレビュー指摘対応</br>
    /// <br>Update Note : 2015/09/10 黄興貴 </br>
    /// <br>管理番号    : 11170129-00</br>
    /// <br>            : redmine#47013 ソースレビュー指摘再対応</br>
    /// <br>UpdateNote  : 2015/10/21 田思春</br>
    /// <br>管理番号    : 11170187-00</br>
    /// <br>            : Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応</br>
    /// <br>UpdateNote  : 2015/12/10 田思春</br>
    /// <br>管理番号    : 11170204-00</br>
    /// <br>            : Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応</br>
    /// <br>                            障害３ 複数ページに跨る条件を指定した場合、締日による改ページ不正の障害対応</br>
    /// <br>UpdateNote  : 2016/01/05 陳艶丹</br>
    /// <br>管理番号    : 11170204-00</br>
    /// <br>            : Redmine#47545 ソースレビュー指摘NO3の対応</br>
	/// </remarks>
	public class PMKOU02033P_02A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeCommon,IPrintActiveReportTypeList	
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		public PMKOU02033P_02A4C()
		{
			InitializeComponent();
		
			// 仕入先元帳アクセスクラス
            this._supplierLedgerAcs = new SupplierLedgerAcs();

            // ---------- ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ---------->>>>>
            // オプションコードの仕入先総括利用可否を取得
            this._sumSuppPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
            // ---------- ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ----------<<<<<
		}
		#endregion

		//================================================================================
		//  内部変数
		//================================================================================
		#region private member
		// 拠点情報印字有無
		private bool _isSectionPrint = false;

		// 拠点タイトル情報印字有無
		private bool _isSectionTitlePrint = false;
		
		// 抽出条件ヘッダ出力区分
		private int _extraCondHeadOutDiv;
		
		// ソート順タイトル
		private string _pageHeaderSortOderTitle;
		
		// サブタイトル
		private string _pageHeaderSubTitle;
		
		// 抽出条件印字項目
		private StringCollection _extraConditions;
		
		// フッター出力有無
		private int _pageFooterOutCode;
		
		// フッタメッセージ1
		private StringCollection _pageFooters;
		
		// 印刷情報
		private SFCMN06002C _printInfo;

		// 抽出条件クラス
		private LedgerCmnCndtn _ledgerCmnCndtn         = null;
		
		// 仕入先元帳アクセスクラス
        private SupplierLedgerAcs _supplierLedgerAcs = null;
		
		// 関連データオブジェクト
		private ArrayList _otherDataList;

		// 印刷件数
		private int _printCount = 1;
		
		// 背景透かし無し
		private int _waterMarkMode = 0;

        // バグ対応、照らし合わせ filter 一時保管
        private string _filter = "";
		
		//-----------------------------------------//
		// 内部使用メンバ変数                      //
		//-----------------------------------------//
		// 元帳明細取得用KEY項目格納用変数
        private int _keyAddUpSecCode = 0;
		private int _keyCustomerCode   = 0;
		private int _keyAddUpdate      = 0;
        // 元帳明細取得用KEY項目格納用変数(残高算出用)
        private int _keyAddUpSecCodeB = 0;
        private int _keyCustomerCodeB = 0;
        private int _keyAddUpdateB = 0;

        // --- ADD 2012/11/01 ---------->>>>>
        // 消費税額
        private long _thisStockTaxValue = 0;
        // --- ADD 2012/11/01 ----------<<<<<
        private Broadleaf.Application.Remoting.ParamData.PurchaseStatus _sumSuppPs; // ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応

		private PMKOU02033P_02_Detail _detailRpt = null;
        private GroupHeader SectionHeader;
        private GroupFooter SectionFooter;
        private GroupHeader ExtraHeader;
        private GroupFooter ExtraFooter;
        private Label Label1;
        private Label Label3;
        private TextBox DATE;
        private TextBox TIME;
        private Label Label2;
        private TextBox PAGE;
        private GroupHeader TitleHeader;
        private GroupFooter TitleFooter;
        private Label Label14;
        private Label Label15;
        private TextBox PayeeSnm;
        private TextBox PrintAddUpDate;
        private TextBox AddUpSecName;
        private Label Label21;
        private Label Label22;
        private Label Label23;
        private Label Label24;
        private Label Label25;
        private Label Label26;
        private Label Label27;
        private TextBox LastTimePayment;
        private TextBox ThisTimePayNrml;
        private TextBox ThisTimeTtlBlcPay;
        private TextBox ThisTimeStockPrice;
        private TextBox ThisStckPricRgdsDis;
        private TextBox OfsThisTimeStock;
        private TextBox OfsThisStockTax;
        private TextBox PayeeCode;
        private Label Label6;
        private Label Label7;
        private TextBox OfsThisTimeStockTax;
        private TextBox StockTotalPayBalance;
        private TextBox AddUpSecCode;
        private Line line19;
        private Line line4;
        private Line line3;
        private Line line5;
        private Line line6;
        private Line line7;
        private Line line8;
        private Line line9;
        private Line line10;
        private Line line11;
        private Line line12;
        private Line line1;
        private Line line2;
        private TextBox KeyAddUpDate;
        private TextBox KeyAddUpSecCode;
        private TextBox KeyCustomerCode;
        private Label label4;
        private Label label5;
        private Label Label32;
        private Label Label34;
        private TextBox TextBox32;
        private TextBox TextBox47;
        private TextBox textBox1;
        private TextBox TextBox33;
        private Label label8;
        private TextBox TextBox48;
        private Label label9;
        private Label SlitTitle;
        private TextBox StockTtl2TmBfBlPay;
        private TextBox StockTtl3TmBfBlPay;
        private Line line13;
        private Line Line87;
        private TextBox TaxLayCd;
        private TextBox PageFooter1;
        private TextBox PageFooter2;
        private Line line14;
        private TextBox LastTimePayment_Bak;// ADD 黄興貴 2015/08/18 for redmine#47013 仕入先元帳の障害対応

		// 全体項目表示設定データ
		private AlItmDspNm _alItmDspNm = null;
		#endregion

		//================================================================================
		//  プロパティ
		//================================================================================
		#region public property
		#region IPrintActiveReportTypeList メンバ

		/// <summary>
		/// ページヘッダソート順タイトル項目
		/// </summary>
		public string PageHeaderSortOderTitle
		{
			set
			{
				this._pageHeaderSortOderTitle = value;
			}
		}

		/// <summary>
		/// 抽出条件ヘッダ出力区分[0:毎ページ,1:先頭ページのみ]
		/// </summary>
		public int ExtraCondHeadOutDiv
		{
			set{this._extraCondHeadOutDiv = value;}
		}
		
		/// <summary>
		/// 抽出条件ヘッダー項目
		/// </summary>
		public StringCollection ExtraConditions
		{
			set
			{
				this._extraConditions = value;
			}
		}

		/// <summary>
		/// フッター出力区分
		/// </summary>
		public int PageFooterOutCode
		{
			set
			{
				this._pageFooterOutCode = value;
			}
		}
		
		/// <summary>
		/// フッタ出力文
		/// </summary>
		public StringCollection PageFooters
		{
			set
			{
				this._pageFooters = value;
			}
		}

		/// <summary>
		/// 印刷条件
		/// </summary>
		public SFCMN06002C PrintInfo
		{
			set
			{
				this._printInfo     = value;
				this._ledgerCmnCndtn = this._printInfo.jyoken as LedgerCmnCndtn;
			}
		}

		/// <summary>
		/// その他データ
		/// </summary>
		public ArrayList OtherDataList
		{
			set
			{
				this._otherDataList = value;
				if (this._otherDataList != null)
				{
					if (this._otherDataList.Count > 0)
					{
						this._isSectionPrint = (bool)this._otherDataList[0];
						this._isSectionTitlePrint = (bool)this._otherDataList[1];

						foreach (object obj in this._otherDataList)
						{
							Type t = obj.GetType();

							// 全体項目表示設定データ 
							if (t.Equals(typeof(AlItmDspNm)))
							{
								this._alItmDspNm = obj as AlItmDspNm;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// ページヘッダサブタイトル
		/// </summary>
		public string PageHeaderSubtitle
		{
			set{this._pageHeaderSubTitle = value;}
		}
		#endregion
		
		#region	IPrintActiveReportTypeCommon メンバ 	 
		public int WatermarkMode 
		{
			set{}
			get{return this._waterMarkMode;}
		}
		
		public event ProgressBarUpEventHandler ProgressBarUpEvent;
		#endregion
		#endregion

		//================================================================================
		//  イベント
		//================================================================================
		#region event
		/// <summary>
		/// レポートスタートイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: レポートの生成処理が開始されたときに発生します。</br>
		/// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.11.14</br>
        /// <br>Update Note : 2014/09/16 時シン</br>
        /// <br>            : ㈱陸整自動車用品 伝票番号印字区分の追加</br>
		/// </remarks>
        private void DCKAU02662P_02A4C_ReportStart(object sender, EventArgs e)
        {
            // 印刷件数初期化
            this._printCount = 0;

            // 罫線表示・非表示制御
            foreach (Section section in this.Sections)
            {
                Section targetSection = section;
                this.SetVisibleRuledLine(ref targetSection);
            }
            // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加------->>>>>
            if (this._ledgerCmnCndtn.PrintDiv != 0)
            {
                this.label8.Text = "ＳＥＱ番号";
            }
            // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加-------<<<<<
        }

		/// <summary>
		/// 得意先ヘッダフォーマットイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.11.14</br>
        /// <br>Update Note : 2015/08/18 黄興貴 </br>
        /// <br>管理番号    : 11170129-00</br>
        /// <br>            : redmine#47013 仕入先元帳の障害対応</br>
		/// </remarks>
		private void CustomerHeader_Format(object sender, System.EventArgs eArgs)
		{
            if (PrintAddUpDate.Value != null)
            {
                int _printAddUpDate = (int)PrintAddUpDate.Value;

                DateTime dt = TDateTime.LongDateToDateTime(_printAddUpDate);
                this.PrintAddUpDate.Text = dt.Year.ToString() + "年" + dt.Month.ToString() + "月" + dt.Day.ToString() + "日";
            }
            // 2009.03.02 30413 犬飼 純仕入額の計算を変更 >>>>>>START
            //OfsThisTimeStock.Value = long.Parse(ThisTimeStockPrice.Value.ToString()) + long.Parse(ThisStckPricRgdsDis.Value.ToString());
            OfsThisTimeStock.Value = long.Parse(ThisTimeStockPrice.Value.ToString()) - long.Parse(ThisStckPricRgdsDis.Value.ToString());
            // 2009.03.02 30413 犬飼 純仕入額の計算を変更 <<<<<<END
            OfsThisTimeStockTax.Value = long.Parse(OfsThisTimeStock.Value.ToString()) + long.Parse(OfsThisStockTax.Value.ToString());
            // --- DEL 黄興貴 2015/08/18 for redmine#47013 仕入先元帳の障害対応 ----------------->>>>>
            //LastTimePayment.Value = TStrConv.StrToIntDef(LastTimePayment.Value.ToString(), 0)
            //                        + TStrConv.StrToIntDef(StockTtl2TmBfBlPay.Value.ToString(), 0)
            //                        + TStrConv.StrToIntDef(StockTtl3TmBfBlPay.Value.ToString(), 0);
            // --- DEL 黄興貴 2015/08/18 for redmine#47013 仕入先元帳の障害対応 -----------------<<<<<
            // --- ADD 黄興貴 2015/08/18 for redmine#47013 仕入先元帳の障害対応 ----------------->>>>>
            LastTimePayment.Value = TStrConv.StrToIntDef(LastTimePayment_Bak.Value.ToString(), 0)
                        + TStrConv.StrToIntDef(StockTtl2TmBfBlPay.Value.ToString(), 0)
                        + TStrConv.StrToIntDef(StockTtl3TmBfBlPay.Value.ToString(), 0);
            // --- ADD 黄興貴 2015/08/18 for redmine#47013 仕入先元帳の障害対応 -----------------<<<<<

            // --- ADD 2012/11/01 ---------->>>>>
            // 消費税額
            this._thisStockTaxValue = (long)OfsThisStockTax.Value;
            // -- ADD 2012/11/01 ----------<<<<<
		}
		
		/// <summary>
		/// 明細フォーマットイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.11.14</br>
        /// <br>Update Note : 2014/09/16 時シン</br>
        /// <br>            : ㈱陸整自動車用品 伝票番号印字区分の追加</br>
        /// <br>UpdateNote  : 2015/10/21 田思春</br>
        /// <br>管理番号    : 11170187-00</br>
        /// <br>            : Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応</br>
        /// <br>UpdateNote  : 2015/12/10 田思春</br>
        /// <br>管理番号    : 11170204-00</br>
        /// <br>            : Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応</br>
        /// <br>UpdateNote  : 2016/01/05 陳艶丹</br>
        /// <br>管理番号    : 11170204-00</br>
        /// <br>            : Redmine#47545 ソースレビュー指摘NO3の対応</br>
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            // ---------- DEL 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ---------->>>>>
            //// ---------- DEL 2015/10/21 田思春 For Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 ---------->>>>>
            ////string filter = String.Format("{0} = {1} AND {2} = {3} AND {4} = {5}",
            ////    SupplierLedgerAcs.CT_SplLedger_PayeeCode, this._keyCustomerCode,
            ////    SupplierLedgerAcs.CT_SplLedger_AddUpDate, this._keyAddUpdate,
            ////    SupplierLedgerAcs.CT_SplLedger_StockAddUpSectionCd, this._keyAddUpSecCode);
            //// ---------- DEL 2015/10/21 田思春 For Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 ----------<<<<<
            //// ---------- ADD 2015/10/21 田思春 For Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 ---------->>>>>
            //string filter = String.Format("{0} = {1} AND {2} = {3} ",
            //    SupplierLedgerAcs.CT_SplLedger_PayeeCode, this._keyCustomerCode,
            //    SupplierLedgerAcs.CT_SplLedger_AddUpDate, this._keyAddUpdate);
            //// ---------- ADD 2015/10/21 田思春 For Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 ----------<<<<<
            // ---------- DEL 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ----------<<<<<

            // ---------- ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ---------->>>>>
            string filter = null;
            if (_sumSuppPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                // 仕入総括あり場合、拠点はフィルター条件とする
                // --- DEL 2016/01/05 陳艶丹 For Redmine#47545 ソースレビュー指摘NO3の対応 ---------->>>>>
                //filter = String.Format("{0} = {1} AND {2} = {3} AND {4} = {5}",
                //    SupplierLedgerAcs.CT_DtlLedger_PayeeCode, this._keyCustomerCode,
                //    SupplierLedgerAcs.CT_DtlLedger_AddUpDate, this._keyAddUpdate,
                //    SupplierLedgerAcs.CT_DtlLedger_StockAddUpSectionCd, this._keyAddUpSecCode);
                // --- DEL 2016/01/05 陳艶丹 For Redmine#47545 ソースレビュー指摘NO3の対応 ----------<<<<<
                // --- ADD 2016/01/05 陳艶丹 For Redmine#47545 ソースレビュー指摘NO3の対応 ---------->>>>>
                filter = String.Format("{0} = {1} AND {2} = {3} AND {4} = {5}",
                    SupplierLedgerAcs.CT_SplLedger_SupplierCd, this._keyCustomerCode,// 仕入総括オプションが有効であればSupplierCdで比較
                    SupplierLedgerAcs.CT_SplLedger_AddUpDate, this._keyAddUpdate,
                    SupplierLedgerAcs.CT_SplLedger_StockAddUpSectionCd, this._keyAddUpSecCode);
                // --- ADD 2016/01/05 陳艶丹 For Redmine#47545 ソースレビュー指摘NO3の対応 ----------<<<<<
            }
            else
            {
                // 仕入総括なし場合、拠点はフィルター条件としない
                // --- DEL 2016/01/05 陳艶丹 For Redmine#47545 ソースレビュー指摘NO3の対応 ---------->>>>>
                //filter = String.Format("{0} = {1} AND {2} = {3}",
                //    SupplierLedgerAcs.CT_DtlLedger_PayeeCode, this._keyCustomerCode,
                //    SupplierLedgerAcs.CT_DtlLedger_AddUpDate, this._keyAddUpdate);
                // --- DEL 2016/01/05 陳艶丹 For Redmine#47545 ソースレビュー指摘NO3の対応 ----------<<<<<
                // --- ADD 2016/01/05 陳艶丹 For Redmine#47545 ソースレビュー指摘NO3の対応 ---------->>>>>
                filter = String.Format("{0} = {1} AND {2} = {3}",
                   SupplierLedgerAcs.CT_SplLedger_PayeeCode, this._keyCustomerCode, // 仕入総括オプションが無効であればPayeeCodeで比較
                   SupplierLedgerAcs.CT_SplLedger_AddUpDate, this._keyAddUpdate);
                // --- ADD 2016/01/05 陳艶丹 For Redmine#47545 ソースレビュー指摘NO3の対応 ----------<<<<<
            }
            // ---------- ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ----------<<<<<

            // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加------->>>>>
            string sort = string.Empty;
            if (this._ledgerCmnCndtn.PrintDiv == 0)
            {
                // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加-------<<<<<
                //string sort = SupplierLedgerAcs.CT_SplLedger_PayeeCode + "," +//  DEL 2014/09/16 時シン 伝票番号印字区分の追加
                sort = SupplierLedgerAcs.CT_SplLedger_PayeeCode + "," +
                       SupplierLedgerAcs.CT_SplLedger_StockRecordCd + "," +
                       SupplierLedgerAcs.CT_SplLedger_AddUpDate + "," +
                       SupplierLedgerAcs.CT_SplLedger_StockAddUpADate + "," +
                       SupplierLedgerAcs.CT_SplLedger_SupplierSlipNo;
                // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加------->>>>>
            }
            else
            {
                sort = SupplierLedgerAcs.CT_SplLedger_PayeeCode + "," +
                       SupplierLedgerAcs.CT_SplLedger_StockRecordCd + "," +
                       SupplierLedgerAcs.CT_SplLedger_AddUpDate + "," +
                       SupplierLedgerAcs.CT_SplLedger_StockAddUpADate + "," +
                       SupplierLedgerAcs.CT_SplLedger_PartySaleSlipNum;
            }
            // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加-------<<<<<

            // >>>>>> まったく同じ伝票が出てしまうバグに対応
            if (filter == this._filter)
            {
                this._filter = filter;
                filter = "AddUpDate = 00000000"; // ヒットなし
                Detail.Visible = false;
            }
            else
            {
                this._filter = filter;
                Detail.Visible = true;
            }
            // <<<<<<

            DataView dv = new DataView(this._supplierLedgerAcs.CsLedgerSlipDataTable, filter, sort, DataViewRowState.CurrentRows);

			// 明細レポート作成
			if (this._detailRpt == null)
			{
                //this._detailRpt = new PMKOU02033P_02_Detail();//  DEL 2014/09/16 時シン 伝票番号印字区分の追加
                this._detailRpt = new PMKOU02033P_02_Detail(_printInfo);//  ADD 2014/09/16 時シン 伝票番号印字区分の追加
			}
			else
			{
				this._detailRpt.DataSource = null;
			}

            if ((this.KeyAddUpSecCode.Text != _keyAddUpSecCodeB.ToString("000000"))
               && (this.KeyCustomerCode.Text != _keyCustomerCodeB.ToString("000000000"))/* && (TStrConv.StrToIntDef(this.KeyAddUpDate.Text, 0) != _keyAddUpdateB)*/)
            {
                this._keyAddUpSecCodeB = this._keyAddUpSecCode;
                this._keyCustomerCodeB = this._keyCustomerCode;
                this._keyAddUpdateB = this._keyAddUpdate;
                this._detailRpt._lastTimePayment = TStrConv.StrToIntDef(LastTimePayment.Value.ToString(), 0);
                this._detailRpt._slitTitle = this.SlitTitle.Text;
            }

            // --- ADD 2012/11/01 ---------->>>>>
            // 消費税転嫁方式と消費税額を渡す
            this._detailRpt._suppCTaxLayCd = int.Parse(this.TaxLayCd.Value.ToString());
            this._detailRpt._thisStockTaxValue = this._thisStockTaxValue;
            // --- ADD 2012/11/01 ----------<<<<<

			// 拠点情報印字有無
			this._detailRpt.IsSectionPrint = this._isSectionPrint;

            // データバインド
            this._detailRpt.DataSource = dv;

            // サブレポートにバインド
            this.Detail_SubReport.Report = this._detailRpt;
		}
		
		/// <summary>
		/// ページフッタフォーマットイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.11.14</br>
        /// <br>Update Note : 2014/09/16 時シン</br>
        /// <br>            : ㈱陸整自動車用品 伝票番号印字区分の追加</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // --- DEL　2014/09/16 時シン 伝票番号印字区分の追加------->>>>>
			// フッター出力する？
            //if (this._pageFooterOutCode == 0)
            //{
            //    // フッターレポート作成
            //    ListCommon_PageFooter rpt = new ListCommon_PageFooter();
			
            //    // フッター印字項目設定
            //    if (this._pageFooters[0] != null)
            //    {
            //        rpt.PrintFooter1 = this._pageFooters[0];
            //    }
            //    if (this._pageFooters[1] != null)
            //    {
            //        rpt.PrintFooter2 = this._pageFooters[1];
            //   			
            //    this.Footer_SubReport.Report = rpt;
            //}
            // --- DEL　2014/09/16 時シン 伝票番号印字区分の追加-------<<<<<
            // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加------->>>>>
            // フッター出力する？
            if (this._pageFooterOutCode == 0)
            {
                // フッター印字項目設定
                this.line14.Visible = true;
                if (this._pageFooters[0] != null)
                {
                    this.PageFooter1.Text = this._pageFooters[0];
                }
                else
                {
                    this.PageFooter1.Text = string.Empty;
                }
                if (this._pageFooters[1] != null)
                {
                    this.PageFooter2.Text = this._pageFooters[1];
                }
                else
                {
                    this.PageFooter2.Text = string.Empty;
                }
            }
            else
            {
                this.line14.Visible = false;
                this.PageFooter1.Text = string.Empty;
                this.PageFooter2.Text = string.Empty;
            }
            // --- ADD　2014/09/16 時シン 伝票番号印字区分の追加-------<<<<<
		}
		
		/// <summary>
		/// 明細アフタープリントイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : セクションがページに描画された後に発生します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
        /// <br>Date        : 2007.11.14</br>
		/// </remarks>
		private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
		{
			// 印刷件数カウントアップ
			this._printCount++;
			
			if (this.ProgressBarUpEvent != null)
			{
				this.ProgressBarUpEvent(this, this._printCount);
			}
		}

		/// <summary>
		/// レポートエンドイベント
		/// </summary>
		/// <param name="sender">イベントソース</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note        : レポートがすべてのページの処理を完了した後に発生します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
        /// <br>Date        : 2007.11.14</br>
		/// </remarks>
        private void DCKAU02662P_02A4C_ReportEnd(object sender, EventArgs e)
        {
            this._detailRpt.Document.Dispose();
            this._detailRpt.Dispose();
            this._detailRpt = null;
        }

		#endregion
		
		// ===============================================================================
		// ActiveReportsデザイナで生成されたコード
		// ===============================================================================
		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.GroupHeader AddUpDateHeader;
        private DataDynamics.ActiveReports.TextBox StartAddUpDate;
        private DataDynamics.ActiveReports.GroupHeader CustomerHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.SubReport Detail_SubReport;
        private DataDynamics.ActiveReports.GroupFooter CustomerFooter;
		private DataDynamics.ActiveReports.GroupFooter AddUpDateFooter;
        private DataDynamics.ActiveReports.PageFooter PageFooter;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKOU02033P_02A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Detail_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.DATE = new DataDynamics.ActiveReports.TextBox();
            this.TIME = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.PAGE = new DataDynamics.ActiveReports.TextBox();
            this.KeyAddUpDate = new DataDynamics.ActiveReports.TextBox();
            this.KeyAddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.KeyCustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.SlitTitle = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.PageFooter1 = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter2 = new DataDynamics.ActiveReports.TextBox();
            this.line14 = new DataDynamics.ActiveReports.Line();
            this.AddUpDateHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.StartAddUpDate = new DataDynamics.ActiveReports.TextBox();
            this.AddUpDateFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.CustomerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.CustomerFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Label14 = new DataDynamics.ActiveReports.Label();
            this.Label15 = new DataDynamics.ActiveReports.Label();
            this.PayeeSnm = new DataDynamics.ActiveReports.TextBox();
            this.PrintAddUpDate = new DataDynamics.ActiveReports.TextBox();
            this.AddUpSecName = new DataDynamics.ActiveReports.TextBox();
            this.Label21 = new DataDynamics.ActiveReports.Label();
            this.Label22 = new DataDynamics.ActiveReports.Label();
            this.Label23 = new DataDynamics.ActiveReports.Label();
            this.Label24 = new DataDynamics.ActiveReports.Label();
            this.Label25 = new DataDynamics.ActiveReports.Label();
            this.Label26 = new DataDynamics.ActiveReports.Label();
            this.Label27 = new DataDynamics.ActiveReports.Label();
            this.LastTimePayment = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimePayNrml = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeTtlBlcPay = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.ThisStckPricRgdsDis = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisTimeStock = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisStockTax = new DataDynamics.ActiveReports.TextBox();
            this.PayeeCode = new DataDynamics.ActiveReports.TextBox();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.OfsThisTimeStockTax = new DataDynamics.ActiveReports.TextBox();
            this.StockTotalPayBalance = new DataDynamics.ActiveReports.TextBox();
            this.AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.line19 = new DataDynamics.ActiveReports.Line();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.line11 = new DataDynamics.ActiveReports.Line();
            this.line12 = new DataDynamics.ActiveReports.Line();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.Label32 = new DataDynamics.ActiveReports.Label();
            this.Label34 = new DataDynamics.ActiveReports.Label();
            this.TextBox32 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox47 = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox33 = new DataDynamics.ActiveReports.TextBox();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.TextBox48 = new DataDynamics.ActiveReports.TextBox();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.StockTtl2TmBfBlPay = new DataDynamics.ActiveReports.TextBox();
            this.StockTtl3TmBfBlPay = new DataDynamics.ActiveReports.TextBox();
            this.line13 = new DataDynamics.ActiveReports.Line();
            this.Line87 = new DataDynamics.ActiveReports.Line();
            this.TaxLayCd = new DataDynamics.ActiveReports.TextBox();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.LastTimePayment_Bak = new DataDynamics.ActiveReports.TextBox();// ADD 黄興貴 2015/08/18 for redmine#47013 仕入先元帳の障害対応
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyAddUpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyAddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyCustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlitTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooter2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartAddUpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintAddUpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimePayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimePayNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisStckPricRgdsDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisTimeStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisStockTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisTimeStockTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotalPayBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTtl2TmBfBlPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTtl3TmBfBlPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxLayCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimePayment_Bak)).BeginInit();// ADD 黄興貴 2015/08/18 for redmine#47013 仕入先元帳の障害対応
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Detail_SubReport});
            this.Detail.Height = 0.4166667F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            // 
            // Detail_SubReport
            // 
            this.Detail_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Detail_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Detail_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Detail_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Detail_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SubReport.CloseBorder = false;
            this.Detail_SubReport.Height = 0.394F;
            this.Detail_SubReport.Left = 0F;
            this.Detail_SubReport.Name = "Detail_SubReport";
            this.Detail_SubReport.Report = null;
            this.Detail_SubReport.Top = 0F;
            this.Detail_SubReport.Width = 11.238F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label1,
            this.Label3,
            this.DATE,
            this.TIME,
            this.Label2,
            this.PAGE,
            this.KeyAddUpDate,
            this.KeyAddUpSecCode,
            this.KeyCustomerCode,
            this.SlitTitle});
            this.PageHeader.Height = 0.271F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = "";
            this.Label1.Left = 0.125F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-weight: bold; font-style: italic; font-size: 14.25pt; vertical-align: top; ";
            this.Label1.Text = "仕入先元帳（伝票）";
            this.Label1.Top = 0F;
            this.Label1.Width = 1.875F;
            // 
            // Label3
            // 
            this.Label3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.RightColor = System.Drawing.Color.Black;
            this.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.TopColor = System.Drawing.Color.Black;
            this.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Height = 0.156F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 7.875F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label3.Text = "作成日付：";
            this.Label3.Top = 0.0625F;
            this.Label3.Width = 0.625F;
            // 
            // DATE
            // 
            this.DATE.Border.BottomColor = System.Drawing.Color.Black;
            this.DATE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.LeftColor = System.Drawing.Color.Black;
            this.DATE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.RightColor = System.Drawing.Color.Black;
            this.DATE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.TopColor = System.Drawing.Color.Black;
            this.DATE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.CanShrink = true;
            this.DATE.Height = 0.156F;
            this.DATE.Left = 8.4375F;
            this.DATE.MultiLine = false;
            this.DATE.Name = "DATE";
            this.DATE.OutputFormat = resources.GetString("DATE.OutputFormat");
            this.DATE.Style = "ddo-char-set: 1; font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.DATE.Text = null;
            this.DATE.Top = 0.0625F;
            this.DATE.Width = 0.938F;
            // 
            // TIME
            // 
            this.TIME.Border.BottomColor = System.Drawing.Color.Black;
            this.TIME.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.LeftColor = System.Drawing.Color.Black;
            this.TIME.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.RightColor = System.Drawing.Color.Black;
            this.TIME.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.TopColor = System.Drawing.Color.Black;
            this.TIME.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Height = 0.156F;
            this.TIME.Left = 9.375F;
            this.TIME.Name = "TIME";
            this.TIME.Style = "font-size: 8pt; ";
            this.TIME.Text = null;
            this.TIME.Top = 0.0625F;
            this.TIME.Width = 0.5F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.156F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 9.875F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 8pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.Label2.Text = "ページ：";
            this.Label2.Top = 0.0625F;
            this.Label2.Width = 0.5F;
            // 
            // PAGE
            // 
            this.PAGE.Border.BottomColor = System.Drawing.Color.Black;
            this.PAGE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PAGE.Border.LeftColor = System.Drawing.Color.Black;
            this.PAGE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PAGE.Border.RightColor = System.Drawing.Color.Black;
            this.PAGE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PAGE.Border.TopColor = System.Drawing.Color.Black;
            this.PAGE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PAGE.CanShrink = true;
            this.PAGE.Height = 0.156F;
            this.PAGE.Left = 10.375F;
            this.PAGE.MultiLine = false;
            this.PAGE.Name = "PAGE";
            this.PAGE.OutputFormat = resources.GetString("PAGE.OutputFormat");
            this.PAGE.Style = "text-align: right; font-size: 8.25pt; font-family: ＭＳ 明朝; vertical-align: top; ";
            this.PAGE.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.PAGE.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.PAGE.Text = null;
            this.PAGE.Top = 0.0625F;
            this.PAGE.Width = 0.281F;
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
            this.KeyAddUpDate.DataField = "AddUpDate";
            this.KeyAddUpDate.Height = 0.1479167F;
            this.KeyAddUpDate.Left = 3.3125F;
            this.KeyAddUpDate.Name = "KeyAddUpDate";
            this.KeyAddUpDate.Style = "";
            this.KeyAddUpDate.Text = null;
            this.KeyAddUpDate.Top = 0.0625F;
            this.KeyAddUpDate.Visible = false;
            this.KeyAddUpDate.Width = 0.9375F;
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
            this.KeyAddUpSecCode.Left = 4.322917F;
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
            this.KeyCustomerCode.Left = 5.333333F;
            this.KeyCustomerCode.Name = "KeyCustomerCode";
            this.KeyCustomerCode.Style = "font-size: 10pt; ";
            this.KeyCustomerCode.Text = null;
            this.KeyCustomerCode.Top = 0.0625F;
            this.KeyCustomerCode.Visible = false;
            this.KeyCustomerCode.Width = 0.9375F;
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
            this.SlitTitle.DataField = "SlitTitle";
            this.SlitTitle.Height = 0.25F;
            this.SlitTitle.HyperLink = "";
            this.SlitTitle.Left = 1.875F;
            this.SlitTitle.Name = "SlitTitle";
            this.SlitTitle.Style = "font-weight: bold; font-style: italic; font-size: 14.25pt; vertical-align: top; ";
            this.SlitTitle.Text = "";
            this.SlitTitle.Top = 0F;
            this.SlitTitle.Width = 1.3125F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.PageFooter1,
            this.PageFooter2,
            this.line14});
            this.PageFooter.Height = 0.28125F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // PageFooter1
            // 
            this.PageFooter1.Border.BottomColor = System.Drawing.Color.Black;
            this.PageFooter1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter1.Border.LeftColor = System.Drawing.Color.Black;
            this.PageFooter1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter1.Border.RightColor = System.Drawing.Color.Black;
            this.PageFooter1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter1.Border.TopColor = System.Drawing.Color.Black;
            this.PageFooter1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter1.Height = 0.15F;
            this.PageFooter1.Left = 0F;
            this.PageFooter1.Name = "PageFooter1";
            this.PageFooter1.Style = "font-size: 8pt; white-space: nowrap; vertical-align: middle; ";
            this.PageFooter1.Text = "123456789012345678901234567890123456789012345678901234567890123456789012345678901" +
                "234567890123456";
            this.PageFooter1.Top = 0.031F;
            this.PageFooter1.Width = 5.35F;
            // 
            // PageFooter2
            // 
            this.PageFooter2.Border.BottomColor = System.Drawing.Color.Black;
            this.PageFooter2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter2.Border.LeftColor = System.Drawing.Color.Black;
            this.PageFooter2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter2.Border.RightColor = System.Drawing.Color.Black;
            this.PageFooter2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter2.Border.TopColor = System.Drawing.Color.Black;
            this.PageFooter2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooter2.Height = 0.15F;
            this.PageFooter2.Left = 5.9F;
            this.PageFooter2.Name = "PageFooter2";
            this.PageFooter2.RightToLeft = true;
            this.PageFooter2.Style = "font-size: 8pt; white-space: nowrap; vertical-align: middle; ";
            this.PageFooter2.Text = "123456789012345678901234567890123456789012345678901234567890123456789012345678901" +
                "234567890123456";
            this.PageFooter2.Top = 0.031F;
            this.PageFooter2.Width = 5.35F;
            // 
            // line14
            // 
            this.line14.Border.BottomColor = System.Drawing.Color.Black;
            this.line14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.LeftColor = System.Drawing.Color.Black;
            this.line14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.RightColor = System.Drawing.Color.Black;
            this.line14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.TopColor = System.Drawing.Color.Black;
            this.line14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Height = 0F;
            this.line14.Left = 0F;
            this.line14.LineWeight = 1F;
            this.line14.Name = "line14";
            this.line14.Top = 0F;
            this.line14.Width = 11.25F;
            this.line14.X1 = 0F;
            this.line14.X2 = 11.25F;
            this.line14.Y1 = 0F;
            this.line14.Y2 = 0F;
            // 
            // AddUpDateHeader
            // 
            this.AddUpDateHeader.CanShrink = true;
            this.AddUpDateHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.StartAddUpDate});
            //this.AddUpDateHeader.DataField = "AddUpDateInt"; // DEL 2015/12/10 田思春 For Redmine#47545 障害３ 複数ページに跨る条件を指定した場合、締日による改ページ不正の障害対応
            this.AddUpDateHeader.DataField = "AddUpDate"; // ADD 2015/12/10 田思春 For Redmine#47545 障害３ 複数ページに跨る条件を指定した場合、締日による改ページ不正の障害対応
            this.AddUpDateHeader.Height = 0F;
            this.AddUpDateHeader.Name = "AddUpDateHeader";
            // 
            // StartAddUpDate
            // 
            this.StartAddUpDate.Border.BottomColor = System.Drawing.Color.Black;
            this.StartAddUpDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StartAddUpDate.Border.LeftColor = System.Drawing.Color.Black;
            this.StartAddUpDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StartAddUpDate.Border.RightColor = System.Drawing.Color.Black;
            this.StartAddUpDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StartAddUpDate.Border.TopColor = System.Drawing.Color.Black;
            this.StartAddUpDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StartAddUpDate.DataField = "StartAddUpDate";
            this.StartAddUpDate.Height = 0.1895833F;
            this.StartAddUpDate.Left = 1.220833F;
            this.StartAddUpDate.Name = "StartAddUpDate";
            this.StartAddUpDate.Style = "";
            this.StartAddUpDate.Text = null;
            this.StartAddUpDate.Top = 0.05416668F;
            this.StartAddUpDate.Visible = false;
            this.StartAddUpDate.Width = 1.083333F;
            // 
            // AddUpDateFooter
            // 
            this.AddUpDateFooter.Height = 0F;
            this.AddUpDateFooter.Name = "AddUpDateFooter";
            this.AddUpDateFooter.Visible = false;
            // 
            // CustomerHeader
            // 
            this.CustomerHeader.DataField = "PayeeCode";
            this.CustomerHeader.Height = 0F;
            this.CustomerHeader.Name = "CustomerHeader";
            this.CustomerHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            // 
            // CustomerFooter
            // 
            this.CustomerFooter.CanShrink = true;
            this.CustomerFooter.Height = 0F;
            this.CustomerFooter.KeepTogether = true;
            this.CustomerFooter.Name = "CustomerFooter";
            this.CustomerFooter.Format += new System.EventHandler(this.CustomerFooter_Format);
            // 
            // SectionHeader
            // 
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.Height = 0F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            // 
            // SectionFooter
            // 
            this.SectionFooter.Height = 0F;
            this.SectionFooter.Name = "SectionFooter";
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Height = 0F;
            this.ExtraHeader.Name = "ExtraHeader";
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.Name = "ExtraFooter";
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanGrow = false;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label14,
            this.Label15,
            this.PayeeSnm,
            this.PrintAddUpDate,
            this.AddUpSecName,
            this.Label21,
            this.Label22,
            this.Label23,
            this.Label24,
            this.Label25,
            this.Label26,
            this.Label27,
            this.LastTimePayment,
            this.ThisTimePayNrml,
            this.ThisTimeTtlBlcPay,
            this.ThisTimeStockPrice,
            this.ThisStckPricRgdsDis,
            this.OfsThisTimeStock,
            this.OfsThisStockTax,
            this.PayeeCode,
            this.Label6,
            this.Label7,
            this.OfsThisTimeStockTax,
            this.StockTotalPayBalance,
            this.AddUpSecCode,
            this.line19,
            this.line4,
            this.line3,
            this.line5,
            this.line6,
            this.line7,
            this.line8,
            this.line9,
            this.line10,
            this.line11,
            this.line12,
            this.line1,
            this.line2,
            this.label4,
            this.label5,
            this.Label32,
            this.Label34,
            this.TextBox32,
            this.TextBox47,
            this.textBox1,
            this.TextBox33,
            this.label8,
            this.TextBox48,
            this.label9,
            this.StockTtl2TmBfBlPay,
            this.StockTtl3TmBfBlPay,
            this.line13,
            this.Line87,
            //this.TaxLayCd});// --- DEL 黄興貴 2015/09/10 for redmine#47013 ソースレビュー指摘再対応        
            // --- ADD 黄興貴 2015/09/10 for redmine#47013 ソースレビュー指摘再対応 ------>>>>>
            this.TaxLayCd,
            this.LastTimePayment_Bak});
            // --- ADD 黄興貴 2015/09/10 for redmine#47013 ソースレビュー指摘再対応 ------<<<<<
            this.TitleHeader.Height = 1.625F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.TitleHeader.Format += new System.EventHandler(this.CustomerHeader_Format);
            // 
            // Label14
            // 
            this.Label14.Border.BottomColor = System.Drawing.Color.Black;
            this.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.LeftColor = System.Drawing.Color.Black;
            this.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.RightColor = System.Drawing.Color.Black;
            this.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.TopColor = System.Drawing.Color.Black;
            this.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Height = 0.125F;
            this.Label14.HyperLink = "";
            this.Label14.Left = 0.125F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "font-size: 8pt; ";
            this.Label14.Text = "拠点  ：";
            this.Label14.Top = 0.125F;
            this.Label14.Width = 0.5F;
            // 
            // Label15
            // 
            this.Label15.Border.BottomColor = System.Drawing.Color.Black;
            this.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.LeftColor = System.Drawing.Color.Black;
            this.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.RightColor = System.Drawing.Color.Black;
            this.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.TopColor = System.Drawing.Color.Black;
            this.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Height = 0.125F;
            this.Label15.HyperLink = "";
            this.Label15.Left = 0.125F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "font-size: 8pt; ";
            this.Label15.Text = "仕入先：";
            this.Label15.Top = 0.3125F;
            this.Label15.Width = 0.5F;
            // 
            // PayeeSnm
            // 
            this.PayeeSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.Border.RightColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.Border.TopColor = System.Drawing.Color.Black;
            this.PayeeSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeSnm.DataField = "PayeeSnm";
            this.PayeeSnm.Height = 0.1377953F;
            this.PayeeSnm.Left = 1.458333F;
            this.PayeeSnm.MultiLine = false;
            this.PayeeSnm.Name = "PayeeSnm";
            this.PayeeSnm.Style = "font-size: 8pt; ";
            this.PayeeSnm.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５６７８９０";
            this.PayeeSnm.Top = 0.3125F;
            this.PayeeSnm.Width = 3.375F;
            // 
            // PrintAddUpDate
            // 
            this.PrintAddUpDate.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintAddUpDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintAddUpDate.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintAddUpDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintAddUpDate.Border.RightColor = System.Drawing.Color.Black;
            this.PrintAddUpDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintAddUpDate.Border.TopColor = System.Drawing.Color.Black;
            this.PrintAddUpDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintAddUpDate.DataField = "AddUpDate";
            this.PrintAddUpDate.Height = 0.1875F;
            this.PrintAddUpDate.Left = 8.9375F;
            this.PrintAddUpDate.MultiLine = false;
            this.PrintAddUpDate.Name = "PrintAddUpDate";
            this.PrintAddUpDate.OutputFormat = resources.GetString("PrintAddUpDate.OutputFormat");
            this.PrintAddUpDate.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; font-family: ＭＳ 明朝; ve" +
                "rtical-align: middle; ";
            this.PrintAddUpDate.Text = null;
            this.PrintAddUpDate.Top = 0.875F;
            this.PrintAddUpDate.Width = 1.0625F;
            // 
            // AddUpSecName
            // 
            this.AddUpSecName.Border.BottomColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.Border.LeftColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.Border.RightColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.Border.TopColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.DataField = "AddUpSecName";
            this.AddUpSecName.Height = 0.1574803F;
            this.AddUpSecName.Left = 1.458333F;
            this.AddUpSecName.MultiLine = false;
            this.AddUpSecName.Name = "AddUpSecName";
            this.AddUpSecName.Style = "font-size: 8pt; ";
            this.AddUpSecName.Text = "福岡営業所○";
            this.AddUpSecName.Top = 0.125F;
            this.AddUpSecName.Width = 1.177165F;
            // 
            // Label21
            // 
            this.Label21.Border.BottomColor = System.Drawing.Color.Black;
            this.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.LeftColor = System.Drawing.Color.Black;
            this.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.RightColor = System.Drawing.Color.Black;
            this.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.TopColor = System.Drawing.Color.Black;
            this.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Height = 0.2519685F;
            this.Label21.HyperLink = "";
            this.Label21.Left = 0.125F;
            this.Label21.Name = "Label21";
            this.Label21.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label21.Text = "前回残高";
            this.Label21.Top = 0.5625F;
            this.Label21.Width = 0.9212598F;
            // 
            // Label22
            // 
            this.Label22.Border.BottomColor = System.Drawing.Color.Black;
            this.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.LeftColor = System.Drawing.Color.Black;
            this.Label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.RightColor = System.Drawing.Color.Black;
            this.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.TopColor = System.Drawing.Color.Black;
            this.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Height = 0.2519685F;
            this.Label22.HyperLink = "";
            this.Label22.Left = 1.0625F;
            this.Label22.Name = "Label22";
            this.Label22.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label22.Text = "今回支払額";
            this.Label22.Top = 0.5625F;
            this.Label22.Width = 0.9212598F;
            // 
            // Label23
            // 
            this.Label23.Border.BottomColor = System.Drawing.Color.Black;
            this.Label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.LeftColor = System.Drawing.Color.Black;
            this.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.RightColor = System.Drawing.Color.Black;
            this.Label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.TopColor = System.Drawing.Color.Black;
            this.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Height = 0.2519685F;
            this.Label23.HyperLink = "";
            this.Label23.Left = 2.041667F;
            this.Label23.Name = "Label23";
            this.Label23.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label23.Text = "繰越残高";
            this.Label23.Top = 0.5625F;
            this.Label23.Width = 0.9212598F;
            // 
            // Label24
            // 
            this.Label24.Border.BottomColor = System.Drawing.Color.Black;
            this.Label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.LeftColor = System.Drawing.Color.Black;
            this.Label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.RightColor = System.Drawing.Color.Black;
            this.Label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.TopColor = System.Drawing.Color.Black;
            this.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Height = 0.2519685F;
            this.Label24.HyperLink = "";
            this.Label24.Left = 2.989583F;
            this.Label24.Name = "Label24";
            this.Label24.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label24.Text = "今回仕入額";
            this.Label24.Top = 0.5625F;
            this.Label24.Width = 0.9212598F;
            // 
            // Label25
            // 
            this.Label25.Border.BottomColor = System.Drawing.Color.Black;
            this.Label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.LeftColor = System.Drawing.Color.Black;
            this.Label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.RightColor = System.Drawing.Color.Black;
            this.Label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.TopColor = System.Drawing.Color.Black;
            this.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Height = 0.2519685F;
            this.Label25.HyperLink = "";
            this.Label25.Left = 3.958333F;
            this.Label25.Name = "Label25";
            this.Label25.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label25.Text = "返品・値引";
            this.Label25.Top = 0.5625F;
            this.Label25.Width = 0.9212598F;
            // 
            // Label26
            // 
            this.Label26.Border.BottomColor = System.Drawing.Color.Black;
            this.Label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.LeftColor = System.Drawing.Color.Black;
            this.Label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.RightColor = System.Drawing.Color.Black;
            this.Label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.TopColor = System.Drawing.Color.Black;
            this.Label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Height = 0.2519685F;
            this.Label26.HyperLink = "";
            this.Label26.Left = 4.9375F;
            this.Label26.Name = "Label26";
            this.Label26.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label26.Text = "純仕入額";
            this.Label26.Top = 0.5625F;
            this.Label26.Width = 0.9212598F;
            // 
            // Label27
            // 
            this.Label27.Border.BottomColor = System.Drawing.Color.Black;
            this.Label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.LeftColor = System.Drawing.Color.Black;
            this.Label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.RightColor = System.Drawing.Color.Black;
            this.Label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.TopColor = System.Drawing.Color.Black;
            this.Label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Height = 0.2519685F;
            this.Label27.HyperLink = "";
            this.Label27.Left = 5.885417F;
            this.Label27.Name = "Label27";
            this.Label27.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label27.Text = "消費税";
            this.Label27.Top = 0.5625F;
            this.Label27.Width = 0.9212598F;
            // 
            // LastTimePayment
            // 
            this.LastTimePayment.Border.BottomColor = System.Drawing.Color.Black;
            this.LastTimePayment.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimePayment.Border.LeftColor = System.Drawing.Color.Black;
            this.LastTimePayment.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimePayment.Border.RightColor = System.Drawing.Color.Black;
            this.LastTimePayment.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimePayment.Border.TopColor = System.Drawing.Color.Black;
            this.LastTimePayment.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimePayment.DataField = "LastTimePayment";
            this.LastTimePayment.Height = 0.2007874F;
            this.LastTimePayment.Left = 0.125F;
            this.LastTimePayment.Name = "LastTimePayment";
            this.LastTimePayment.OutputFormat = resources.GetString("LastTimePayment.OutputFormat");
            this.LastTimePayment.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: middle; ";
            this.LastTimePayment.Text = "123,456,789,012";
            this.LastTimePayment.Top = 0.875F;
            this.LastTimePayment.Width = 0.9217521F;
            // 
            // ThisTimePayNrml
            // 
            this.ThisTimePayNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimePayNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimePayNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimePayNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimePayNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimePayNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimePayNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimePayNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimePayNrml.DataField = "ThisTimePayNrml";
            this.ThisTimePayNrml.Height = 0.2007874F;
            this.ThisTimePayNrml.Left = 1.0625F;
            this.ThisTimePayNrml.Name = "ThisTimePayNrml";
            this.ThisTimePayNrml.OutputFormat = resources.GetString("ThisTimePayNrml.OutputFormat");
            this.ThisTimePayNrml.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: middle; ";
            this.ThisTimePayNrml.Text = "123,456,789,012";
            this.ThisTimePayNrml.Top = 0.875F;
            this.ThisTimePayNrml.Width = 0.9212598F;
            // 
            // ThisTimeTtlBlcPay
            // 
            this.ThisTimeTtlBlcPay.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcPay.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcPay.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcPay.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcPay.DataField = "ThisTimeTtlBlcPay";
            this.ThisTimeTtlBlcPay.Height = 0.2007874F;
            this.ThisTimeTtlBlcPay.Left = 2.041667F;
            this.ThisTimeTtlBlcPay.Name = "ThisTimeTtlBlcPay";
            this.ThisTimeTtlBlcPay.OutputFormat = resources.GetString("ThisTimeTtlBlcPay.OutputFormat");
            this.ThisTimeTtlBlcPay.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: middle; ";
            this.ThisTimeTtlBlcPay.Text = "123,456,789,012";
            this.ThisTimeTtlBlcPay.Top = 0.875F;
            this.ThisTimeTtlBlcPay.Width = 0.9212598F;
            // 
            // ThisTimeStockPrice
            // 
            this.ThisTimeStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeStockPrice.DataField = "ThisTimeStockPrice";
            this.ThisTimeStockPrice.Height = 0.2007874F;
            this.ThisTimeStockPrice.Left = 2.989583F;
            this.ThisTimeStockPrice.Name = "ThisTimeStockPrice";
            this.ThisTimeStockPrice.OutputFormat = resources.GetString("ThisTimeStockPrice.OutputFormat");
            this.ThisTimeStockPrice.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: middle; ";
            this.ThisTimeStockPrice.Text = "123,456,789,012";
            this.ThisTimeStockPrice.Top = 0.875F;
            this.ThisTimeStockPrice.Width = 0.9212598F;
            // 
            // ThisStckPricRgdsDis
            // 
            this.ThisStckPricRgdsDis.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisStckPricRgdsDis.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisStckPricRgdsDis.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisStckPricRgdsDis.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisStckPricRgdsDis.Border.RightColor = System.Drawing.Color.Black;
            this.ThisStckPricRgdsDis.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisStckPricRgdsDis.Border.TopColor = System.Drawing.Color.Black;
            this.ThisStckPricRgdsDis.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisStckPricRgdsDis.DataField = "ThisStckPricRgdsDis";
            this.ThisStckPricRgdsDis.Height = 0.2007874F;
            this.ThisStckPricRgdsDis.Left = 3.958333F;
            this.ThisStckPricRgdsDis.Name = "ThisStckPricRgdsDis";
            this.ThisStckPricRgdsDis.OutputFormat = resources.GetString("ThisStckPricRgdsDis.OutputFormat");
            this.ThisStckPricRgdsDis.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: middle; ";
            this.ThisStckPricRgdsDis.Text = "123,456,789,012";
            this.ThisStckPricRgdsDis.Top = 0.875F;
            this.ThisStckPricRgdsDis.Width = 0.9212598F;
            // 
            // OfsThisTimeStock
            // 
            this.OfsThisTimeStock.Border.BottomColor = System.Drawing.Color.Black;
            this.OfsThisTimeStock.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeStock.Border.LeftColor = System.Drawing.Color.Black;
            this.OfsThisTimeStock.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeStock.Border.RightColor = System.Drawing.Color.Black;
            this.OfsThisTimeStock.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeStock.Border.TopColor = System.Drawing.Color.Black;
            this.OfsThisTimeStock.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeStock.Height = 0.2007874F;
            this.OfsThisTimeStock.Left = 4.9375F;
            this.OfsThisTimeStock.Name = "OfsThisTimeStock";
            this.OfsThisTimeStock.OutputFormat = resources.GetString("OfsThisTimeStock.OutputFormat");
            this.OfsThisTimeStock.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: middle; ";
            this.OfsThisTimeStock.Text = "123,456,789,012";
            this.OfsThisTimeStock.Top = 0.875F;
            this.OfsThisTimeStock.Width = 0.9212598F;
            // 
            // OfsThisStockTax
            // 
            this.OfsThisStockTax.Border.BottomColor = System.Drawing.Color.Black;
            this.OfsThisStockTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisStockTax.Border.LeftColor = System.Drawing.Color.Black;
            this.OfsThisStockTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisStockTax.Border.RightColor = System.Drawing.Color.Black;
            this.OfsThisStockTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisStockTax.Border.TopColor = System.Drawing.Color.Black;
            this.OfsThisStockTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisStockTax.DataField = "OfsThisStockTax";
            this.OfsThisStockTax.Height = 0.2007874F;
            this.OfsThisStockTax.Left = 5.885417F;
            this.OfsThisStockTax.Name = "OfsThisStockTax";
            this.OfsThisStockTax.OutputFormat = resources.GetString("OfsThisStockTax.OutputFormat");
            this.OfsThisStockTax.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: middle; ";
            this.OfsThisStockTax.Text = "123,456,789,012";
            this.OfsThisStockTax.Top = 0.875F;
            this.OfsThisStockTax.Width = 0.9212598F;
            // 
            // PayeeCode
            // 
            this.PayeeCode.Border.BottomColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.Border.LeftColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.Border.RightColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.Border.TopColor = System.Drawing.Color.Black;
            this.PayeeCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PayeeCode.DataField = "PayeeCode";
            this.PayeeCode.Height = 0.125F;
            this.PayeeCode.Left = 0.6458333F;
            this.PayeeCode.MultiLine = false;
            this.PayeeCode.Name = "PayeeCode";
            this.PayeeCode.OutputFormat = resources.GetString("PayeeCode.OutputFormat");
            this.PayeeCode.Style = "text-align: left; font-size: 8pt; ";
            this.PayeeCode.Text = null;
            this.PayeeCode.Top = 0.3125F;
            this.PayeeCode.Width = 0.75F;
            // 
            // Label6
            // 
            this.Label6.Border.BottomColor = System.Drawing.Color.Black;
            this.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.LeftColor = System.Drawing.Color.Black;
            this.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.RightColor = System.Drawing.Color.Black;
            this.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.TopColor = System.Drawing.Color.Black;
            this.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Height = 0.2519685F;
            this.Label6.HyperLink = "";
            this.Label6.Left = 6.84375F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label6.Text = "税込仕入額";
            this.Label6.Top = 0.5625F;
            this.Label6.Width = 0.9212598F;
            // 
            // Label7
            // 
            this.Label7.Border.BottomColor = System.Drawing.Color.Black;
            this.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.LeftColor = System.Drawing.Color.Black;
            this.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.RightColor = System.Drawing.Color.Black;
            this.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.TopColor = System.Drawing.Color.Black;
            this.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Height = 0.2519685F;
            this.Label7.HyperLink = "";
            this.Label7.Left = 7.8125F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label7.Text = "今回残高";
            this.Label7.Top = 0.5625F;
            this.Label7.Width = 0.9212598F;
            // 
            // OfsThisTimeStockTax
            // 
            this.OfsThisTimeStockTax.Border.BottomColor = System.Drawing.Color.Black;
            this.OfsThisTimeStockTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeStockTax.Border.LeftColor = System.Drawing.Color.Black;
            this.OfsThisTimeStockTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeStockTax.Border.RightColor = System.Drawing.Color.Black;
            this.OfsThisTimeStockTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeStockTax.Border.TopColor = System.Drawing.Color.Black;
            this.OfsThisTimeStockTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeStockTax.Height = 0.2007874F;
            this.OfsThisTimeStockTax.Left = 6.84375F;
            this.OfsThisTimeStockTax.Name = "OfsThisTimeStockTax";
            this.OfsThisTimeStockTax.OutputFormat = resources.GetString("OfsThisTimeStockTax.OutputFormat");
            this.OfsThisTimeStockTax.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; font-family: ＭＳ ゴシック; " +
                "vertical-align: middle; ";
            this.OfsThisTimeStockTax.Text = "123,456,789,012";
            this.OfsThisTimeStockTax.Top = 0.875F;
            this.OfsThisTimeStockTax.Width = 0.9212598F;
            // 
            // StockTotalPayBalance
            // 
            this.StockTotalPayBalance.Border.BottomColor = System.Drawing.Color.Black;
            this.StockTotalPayBalance.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalPayBalance.Border.LeftColor = System.Drawing.Color.Black;
            this.StockTotalPayBalance.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalPayBalance.Border.RightColor = System.Drawing.Color.Black;
            this.StockTotalPayBalance.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalPayBalance.Border.TopColor = System.Drawing.Color.Black;
            this.StockTotalPayBalance.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTotalPayBalance.DataField = "StockTotalPayBalance";
            this.StockTotalPayBalance.Height = 0.2007874F;
            this.StockTotalPayBalance.Left = 7.8125F;
            this.StockTotalPayBalance.Name = "StockTotalPayBalance";
            this.StockTotalPayBalance.OutputFormat = resources.GetString("StockTotalPayBalance.OutputFormat");
            this.StockTotalPayBalance.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; font-family: ＭＳ ゴシック; " +
                "vertical-align: middle; ";
            this.StockTotalPayBalance.Text = "123,456,789,012";
            this.StockTotalPayBalance.Top = 0.875F;
            this.StockTotalPayBalance.Width = 0.9212598F;
            // 
            // AddUpSecCode
            // 
            this.AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.DataField = "AddUpSecCode";
            this.AddUpSecCode.Height = 0.125F;
            this.AddUpSecCode.Left = 0.6458333F;
            this.AddUpSecCode.MultiLine = false;
            this.AddUpSecCode.Name = "AddUpSecCode";
            this.AddUpSecCode.Style = "text-align: left; font-size: 8pt; ";
            this.AddUpSecCode.Text = null;
            this.AddUpSecCode.Top = 0.125F;
            this.AddUpSecCode.Width = 0.75F;
            // 
            // line19
            // 
            this.line19.Border.BottomColor = System.Drawing.Color.Black;
            this.line19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.LeftColor = System.Drawing.Color.Black;
            this.line19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.RightColor = System.Drawing.Color.Black;
            this.line19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.TopColor = System.Drawing.Color.Black;
            this.line19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Height = 0F;
            this.line19.Left = 0.125F;
            this.line19.LineWeight = 1F;
            this.line19.Name = "line19";
            this.line19.Top = 0.5625F;
            this.line19.Width = 8.6875F;
            this.line19.X1 = 0.125F;
            this.line19.X2 = 8.8125F;
            this.line19.Y1 = 0.5625F;
            this.line19.Y2 = 0.5625F;
            // 
            // line4
            // 
            this.line4.Border.BottomColor = System.Drawing.Color.Black;
            this.line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.LeftColor = System.Drawing.Color.Black;
            this.line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.RightColor = System.Drawing.Color.Black;
            this.line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.TopColor = System.Drawing.Color.Black;
            this.line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Height = 0.5625F;
            this.line4.Left = 0.125F;
            this.line4.LineWeight = 1F;
            this.line4.Name = "line4";
            this.line4.Top = 0.5625F;
            this.line4.Width = 0F;
            this.line4.X1 = 0.125F;
            this.line4.X2 = 0.125F;
            this.line4.Y1 = 0.5625F;
            this.line4.Y2 = 1.125F;
            // 
            // line3
            // 
            this.line3.Border.BottomColor = System.Drawing.Color.Black;
            this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.LeftColor = System.Drawing.Color.Black;
            this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.RightColor = System.Drawing.Color.Black;
            this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.TopColor = System.Drawing.Color.Black;
            this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Height = 0.5625F;
            this.line3.Left = 1.0625F;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0.5625F;
            this.line3.Width = 0F;
            this.line3.X1 = 1.0625F;
            this.line3.X2 = 1.0625F;
            this.line3.Y1 = 0.5625F;
            this.line3.Y2 = 1.125F;
            // 
            // line5
            // 
            this.line5.Border.BottomColor = System.Drawing.Color.Black;
            this.line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.LeftColor = System.Drawing.Color.Black;
            this.line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.RightColor = System.Drawing.Color.Black;
            this.line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.TopColor = System.Drawing.Color.Black;
            this.line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Height = 0.5625F;
            this.line5.Left = 2F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 0.5625F;
            this.line5.Width = 0F;
            this.line5.X1 = 2F;
            this.line5.X2 = 2F;
            this.line5.Y1 = 0.5625F;
            this.line5.Y2 = 1.125F;
            // 
            // line6
            // 
            this.line6.Border.BottomColor = System.Drawing.Color.Black;
            this.line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.LeftColor = System.Drawing.Color.Black;
            this.line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.RightColor = System.Drawing.Color.Black;
            this.line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.TopColor = System.Drawing.Color.Black;
            this.line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Height = 0.5625F;
            this.line6.Left = 3F;
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 0.5625F;
            this.line6.Width = 0F;
            this.line6.X1 = 3F;
            this.line6.X2 = 3F;
            this.line6.Y1 = 0.5625F;
            this.line6.Y2 = 1.125F;
            // 
            // line7
            // 
            this.line7.Border.BottomColor = System.Drawing.Color.Black;
            this.line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.LeftColor = System.Drawing.Color.Black;
            this.line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.RightColor = System.Drawing.Color.Black;
            this.line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.TopColor = System.Drawing.Color.Black;
            this.line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Height = 0.5625F;
            this.line7.Left = 3.9375F;
            this.line7.LineWeight = 1F;
            this.line7.Name = "line7";
            this.line7.Top = 0.5625F;
            this.line7.Width = 0F;
            this.line7.X1 = 3.9375F;
            this.line7.X2 = 3.9375F;
            this.line7.Y1 = 0.5625F;
            this.line7.Y2 = 1.125F;
            // 
            // line8
            // 
            this.line8.Border.BottomColor = System.Drawing.Color.Black;
            this.line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.LeftColor = System.Drawing.Color.Black;
            this.line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.RightColor = System.Drawing.Color.Black;
            this.line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.TopColor = System.Drawing.Color.Black;
            this.line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Height = 0.5625F;
            this.line8.Left = 4.9375F;
            this.line8.LineWeight = 1F;
            this.line8.Name = "line8";
            this.line8.Top = 0.5625F;
            this.line8.Width = 0F;
            this.line8.X1 = 4.9375F;
            this.line8.X2 = 4.9375F;
            this.line8.Y1 = 0.5625F;
            this.line8.Y2 = 1.125F;
            // 
            // line9
            // 
            this.line9.Border.BottomColor = System.Drawing.Color.Black;
            this.line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.LeftColor = System.Drawing.Color.Black;
            this.line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.RightColor = System.Drawing.Color.Black;
            this.line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.TopColor = System.Drawing.Color.Black;
            this.line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Height = 0.5625F;
            this.line9.Left = 5.875F;
            this.line9.LineWeight = 1F;
            this.line9.Name = "line9";
            this.line9.Top = 0.5625F;
            this.line9.Width = 0F;
            this.line9.X1 = 5.875F;
            this.line9.X2 = 5.875F;
            this.line9.Y1 = 0.5625F;
            this.line9.Y2 = 1.125F;
            // 
            // line10
            // 
            this.line10.Border.BottomColor = System.Drawing.Color.Black;
            this.line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.LeftColor = System.Drawing.Color.Black;
            this.line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.RightColor = System.Drawing.Color.Black;
            this.line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.TopColor = System.Drawing.Color.Black;
            this.line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Height = 0.5625F;
            this.line10.Left = 6.875F;
            this.line10.LineWeight = 1F;
            this.line10.Name = "line10";
            this.line10.Top = 0.5625F;
            this.line10.Width = 0F;
            this.line10.X1 = 6.875F;
            this.line10.X2 = 6.875F;
            this.line10.Y1 = 0.5625F;
            this.line10.Y2 = 1.125F;
            // 
            // line11
            // 
            this.line11.Border.BottomColor = System.Drawing.Color.Black;
            this.line11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.LeftColor = System.Drawing.Color.Black;
            this.line11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.RightColor = System.Drawing.Color.Black;
            this.line11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.TopColor = System.Drawing.Color.Black;
            this.line11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Height = 0.5625F;
            this.line11.Left = 7.8125F;
            this.line11.LineWeight = 1F;
            this.line11.Name = "line11";
            this.line11.Top = 0.5625F;
            this.line11.Width = 0F;
            this.line11.X1 = 7.8125F;
            this.line11.X2 = 7.8125F;
            this.line11.Y1 = 0.5625F;
            this.line11.Y2 = 1.125F;
            // 
            // line12
            // 
            this.line12.Border.BottomColor = System.Drawing.Color.Black;
            this.line12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.LeftColor = System.Drawing.Color.Black;
            this.line12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.RightColor = System.Drawing.Color.Black;
            this.line12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.TopColor = System.Drawing.Color.Black;
            this.line12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Height = 0.5625F;
            this.line12.Left = 8.8125F;
            this.line12.LineWeight = 1F;
            this.line12.Name = "line12";
            this.line12.Top = 0.5625F;
            this.line12.Width = 0F;
            this.line12.X1 = 8.8125F;
            this.line12.X2 = 8.8125F;
            this.line12.Y1 = 0.5625F;
            this.line12.Y2 = 1.125F;
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
            this.line1.Left = 0.125F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 1.125F;
            this.line1.Width = 8.6875F;
            this.line1.X1 = 0.125F;
            this.line1.X2 = 8.8125F;
            this.line1.Y1 = 1.125F;
            this.line1.Y2 = 1.125F;
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
            this.line2.LineWeight = 3F;
            this.line2.Name = "line2";
            this.line2.Top = 0F;
            this.line2.Width = 11.248F;
            this.line2.X1 = 0F;
            this.line2.X2 = 11.248F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // label4
            // 
            this.label4.Border.BottomColor = System.Drawing.Color.Black;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.LeftColor = System.Drawing.Color.Black;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.RightColor = System.Drawing.Color.Black;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopColor = System.Drawing.Color.Black;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Height = 0.1875F;
            this.label4.HyperLink = "";
            this.label4.Left = 0.125F;
            this.label4.Name = "label4";
            this.label4.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.label4.Text = "日付";
            this.label4.Top = 1.375F;
            this.label4.Width = 0.625F;
            // 
            // label5
            // 
            this.label5.Border.BottomColor = System.Drawing.Color.Black;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.LeftColor = System.Drawing.Color.Black;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.RightColor = System.Drawing.Color.Black;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopColor = System.Drawing.Color.Black;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Height = 0.2007874F;
            this.label5.HyperLink = "";
            this.label5.Left = 0.8125F;
            this.label5.Name = "label5";
            this.label5.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.label5.Text = "伝票番号";
            this.label5.Top = 1.375F;
            this.label5.Width = 0.6102362F;
            // 
            // Label32
            // 
            this.Label32.Border.BottomColor = System.Drawing.Color.Black;
            this.Label32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Border.LeftColor = System.Drawing.Color.Black;
            this.Label32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Border.RightColor = System.Drawing.Color.Black;
            this.Label32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Border.TopColor = System.Drawing.Color.Black;
            this.Label32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Height = 0.1875F;
            this.Label32.HyperLink = "";
            this.Label32.Left = 1.9375F;
            this.Label32.Name = "Label32";
            this.Label32.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.Label32.Text = "区分";
            this.Label32.Top = 1.375F;
            this.Label32.Width = 0.4375F;
            // 
            // Label34
            // 
            this.Label34.Border.BottomColor = System.Drawing.Color.Black;
            this.Label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Border.LeftColor = System.Drawing.Color.Black;
            this.Label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Border.RightColor = System.Drawing.Color.Black;
            this.Label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Border.TopColor = System.Drawing.Color.Black;
            this.Label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Height = 0.1875F;
            this.Label34.HyperLink = "";
            this.Label34.Left = 2.3755F;
            this.Label34.Name = "Label34";
            this.Label34.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.Label34.Text = "仕入金額";
            this.Label34.Top = 1.375F;
            this.Label34.Width = 0.921F;
            // 
            // TextBox32
            // 
            this.TextBox32.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Height = 0.2007874F;
            this.TextBox32.Left = 3.375F;
            this.TextBox32.Name = "TextBox32";
            this.TextBox32.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.TextBox32.Text = "消費税";
            this.TextBox32.Top = 1.375F;
            this.TextBox32.Width = 0.9212598F;
            // 
            // TextBox47
            // 
            this.TextBox47.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.Height = 0.2007874F;
            this.TextBox47.Left = 4.3125F;
            this.TextBox47.Name = "TextBox47";
            this.TextBox47.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.TextBox47.Text = "支払額";
            this.TextBox47.Top = 1.375F;
            this.TextBox47.Width = 0.9212598F;
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Height = 0.1875F;
            this.textBox1.Left = 5.3125F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.textBox1.Text = "手形期日";
            this.textBox1.Top = 1.375F;
            this.textBox1.Width = 0.813F;
            // 
            // TextBox33
            // 
            this.TextBox33.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Height = 0.2007874F;
            this.TextBox33.Left = 6.1875F;
            this.TextBox33.Name = "TextBox33";
            this.TextBox33.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.TextBox33.Text = "残高";
            this.TextBox33.Top = 1.375F;
            this.TextBox33.Width = 0.9212598F;
            // 
            // label8
            // 
            this.label8.Border.BottomColor = System.Drawing.Color.Black;
            this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.LeftColor = System.Drawing.Color.Black;
            this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.RightColor = System.Drawing.Color.Black;
            this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.TopColor = System.Drawing.Color.Black;
            this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Height = 0.1875F;
            this.label8.HyperLink = "";
            this.label8.Left = 7.1875F;
            this.label8.Name = "label8";
            this.label8.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.label8.Text = "相手先伝票番号";
            this.label8.Top = 1.375F;
            this.label8.Width = 1.188F;
            // 
            // TextBox48
            // 
            this.TextBox48.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.Height = 0.1875F;
            this.TextBox48.Left = 8.4375F;
            this.TextBox48.Name = "TextBox48";
            this.TextBox48.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.TextBox48.Text = "備  考";
            this.TextBox48.Top = 1.375F;
            this.TextBox48.Width = 1.0625F;
            // 
            // label9
            // 
            this.label9.Border.BottomColor = System.Drawing.Color.Black;
            this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.LeftColor = System.Drawing.Color.Black;
            this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.RightColor = System.Drawing.Color.Black;
            this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.TopColor = System.Drawing.Color.Black;
            this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Height = 0.2519685F;
            this.label9.HyperLink = "";
            this.label9.Left = 9.0625F;
            this.label9.Name = "label9";
            this.label9.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; vertical-align: middle; " +
                "";
            this.label9.Text = "締日";
            this.label9.Top = 0.5625F;
            this.label9.Width = 0.9212598F;
            // 
            // StockTtl2TmBfBlPay
            // 
            this.StockTtl2TmBfBlPay.Border.BottomColor = System.Drawing.Color.Black;
            this.StockTtl2TmBfBlPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl2TmBfBlPay.Border.LeftColor = System.Drawing.Color.Black;
            this.StockTtl2TmBfBlPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl2TmBfBlPay.Border.RightColor = System.Drawing.Color.Black;
            this.StockTtl2TmBfBlPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl2TmBfBlPay.Border.TopColor = System.Drawing.Color.Black;
            this.StockTtl2TmBfBlPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl2TmBfBlPay.DataField = "StockTtl2TmBfBlPay";
            this.StockTtl2TmBfBlPay.Height = 0.2007874F;
            this.StockTtl2TmBfBlPay.Left = 8.1875F;
            this.StockTtl2TmBfBlPay.Name = "StockTtl2TmBfBlPay";
            this.StockTtl2TmBfBlPay.OutputFormat = resources.GetString("StockTtl2TmBfBlPay.OutputFormat");
            this.StockTtl2TmBfBlPay.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: middle; ";
            this.StockTtl2TmBfBlPay.Text = "123,456,789,012";
            this.StockTtl2TmBfBlPay.Top = 0.125F;
            this.StockTtl2TmBfBlPay.Visible = false;
            this.StockTtl2TmBfBlPay.Width = 0.9217521F;
            // 
            // StockTtl3TmBfBlPay
            // 
            this.StockTtl3TmBfBlPay.Border.BottomColor = System.Drawing.Color.Black;
            this.StockTtl3TmBfBlPay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl3TmBfBlPay.Border.LeftColor = System.Drawing.Color.Black;
            this.StockTtl3TmBfBlPay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl3TmBfBlPay.Border.RightColor = System.Drawing.Color.Black;
            this.StockTtl3TmBfBlPay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl3TmBfBlPay.Border.TopColor = System.Drawing.Color.Black;
            this.StockTtl3TmBfBlPay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockTtl3TmBfBlPay.DataField = "StockTtl3TmBfBlPay";
            this.StockTtl3TmBfBlPay.Height = 0.2007874F;
            this.StockTtl3TmBfBlPay.Left = 9.25F;
            this.StockTtl3TmBfBlPay.Name = "StockTtl3TmBfBlPay";
            this.StockTtl3TmBfBlPay.OutputFormat = resources.GetString("StockTtl3TmBfBlPay.OutputFormat");
            this.StockTtl3TmBfBlPay.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: middle; ";
            this.StockTtl3TmBfBlPay.Text = "123,456,789,012";
            this.StockTtl3TmBfBlPay.Top = 0.125F;
            this.StockTtl3TmBfBlPay.Visible = false;
            this.StockTtl3TmBfBlPay.Width = 0.9217521F;
            // 
            // line13
            // 
            this.line13.Border.BottomColor = System.Drawing.Color.Black;
            this.line13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.LeftColor = System.Drawing.Color.Black;
            this.line13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.RightColor = System.Drawing.Color.Black;
            this.line13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.TopColor = System.Drawing.Color.Black;
            this.line13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Height = 0F;
            this.line13.Left = 0.125F;
            this.line13.LineWeight = 1F;
            this.line13.Name = "line13";
            this.line13.Top = 0.8125F;
            this.line13.Width = 8.6875F;
            this.line13.X1 = 0.125F;
            this.line13.X2 = 8.8125F;
            this.line13.Y1 = 0.8125F;
            this.line13.Y2 = 0.8125F;
            // 
            // Line87
            // 
            this.Line87.Border.BottomColor = System.Drawing.Color.Black;
            this.Line87.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line87.Border.LeftColor = System.Drawing.Color.Black;
            this.Line87.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line87.Border.RightColor = System.Drawing.Color.Black;
            this.Line87.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line87.Border.TopColor = System.Drawing.Color.Black;
            this.Line87.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line87.Height = 0F;
            this.Line87.Left = 0F;
            this.Line87.LineWeight = 1F;
            this.Line87.Name = "Line87";
            this.Line87.Top = 1.5625F;
            this.Line87.Width = 11.248F;
            this.Line87.X1 = 0F;
            this.Line87.X2 = 11.248F;
            this.Line87.Y1 = 1.5625F;
            this.Line87.Y2 = 1.5625F;
            // 
            // TaxLayCd
            // 
            this.TaxLayCd.Border.BottomColor = System.Drawing.Color.Black;
            this.TaxLayCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaxLayCd.Border.LeftColor = System.Drawing.Color.Black;
            this.TaxLayCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaxLayCd.Border.RightColor = System.Drawing.Color.Black;
            this.TaxLayCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaxLayCd.Border.TopColor = System.Drawing.Color.Black;
            this.TaxLayCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TaxLayCd.DataField = "SuppCTaxLayCd";
            this.TaxLayCd.Height = 0.1875F;
            this.TaxLayCd.Left = 7.875F;
            this.TaxLayCd.Name = "TaxLayCd";
            this.TaxLayCd.OutputFormat = resources.GetString("TaxLayCd.OutputFormat");
            this.TaxLayCd.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: middle; ";
            this.TaxLayCd.Text = "0";
            this.TaxLayCd.Top = 0.125F;
            this.TaxLayCd.Visible = false;
            this.TaxLayCd.Width = 0.125F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Height = 0F;
            this.TitleFooter.Name = "TitleFooter";
            // --- ADD 黄興貴 2015/08/18 for redmine#47013 仕入先元帳の障害対応 ----------------->>>>>
            // 
            // LastTimePayment_Bak
            // 
            this.LastTimePayment_Bak.Border.BottomColor = System.Drawing.Color.Black;
            this.LastTimePayment_Bak.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimePayment_Bak.Border.LeftColor = System.Drawing.Color.Black;
            this.LastTimePayment_Bak.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimePayment_Bak.Border.RightColor = System.Drawing.Color.Black;
            this.LastTimePayment_Bak.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimePayment_Bak.Border.TopColor = System.Drawing.Color.Black;
            this.LastTimePayment_Bak.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimePayment_Bak.DataField = "LastTimePayment";
            this.LastTimePayment_Bak.Height = 0.2007874F;
            this.LastTimePayment_Bak.Left = 5.3125F;
            this.LastTimePayment_Bak.Name = "LastTimePayment_Bak";
            this.LastTimePayment_Bak.OutputFormat = resources.GetString("LastTimePayment_Bak.OutputFormat");
            this.LastTimePayment_Bak.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: ＭＳ ゴシック; vertical-align: middle; ";
            this.LastTimePayment_Bak.Text = "123,456,789,012";
            this.LastTimePayment_Bak.Top = 0.125F;
            this.LastTimePayment_Bak.Visible = false;
            this.LastTimePayment_Bak.Width = 0.9217521F;
            // --- ADD 黄興貴 2015/08/18 for redmine#47013 仕入先元帳の障害対応 -----------------<<<<<
            // 
            // PMKOU02033P_02A4C
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11.69291F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.PaperWidth = 8.268056F;
            this.PrintWidth = 11.26883F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.AddUpDateHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.CustomerHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.CustomerFooter);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.AddUpDateFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportEnd += new System.EventHandler(this.DCKAU02662P_02A4C_ReportEnd);
            this.ReportStart += new System.EventHandler(this.DCKAU02662P_02A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyAddUpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyAddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyCustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlitTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooter2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartAddUpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintAddUpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimePayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimePayNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisStckPricRgdsDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisTimeStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisStockTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisTimeStockTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTotalPayBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTtl2TmBfBlPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockTtl3TmBfBlPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaxLayCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimePayment_Bak)).EndInit();// ADD 黄興貴 2015/08/18 for redmine#47013 仕入先元帳の障害対応
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

		// ===============================================================================
		// 内部使用関数
		// ===============================================================================
		#region private methods		
		/// <summary>
		/// 罫線表示非表示制御処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="eArgs">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: セクションのデータがロードされ連結された後に発生します。</br>
		/// <br>Programmer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.11.14</br>
		/// </remarks>
		private void SetVisibleRuledLine(ref Section sections)
		{
			// 罫線有無判定
			bool isRuledLine = (this._printInfo.frycd == 1);
			

			for (int i = 0; i < sections.Controls.Count; i++)
			{
				if (sections.Controls[i] is Line)
				{
					Line line = (Line)sections.Controls[i];
					
					// 表示非表示対象の罫線か
					if (line.Name.IndexOf("RuledLine") != -1)
					{
						line.Visible = isRuledLine; 
					}
				}
			}
		}
		#endregion

        private void PageHeader_Format(object sender, EventArgs e)
        {
            // KEY項目保存
            this._keyAddUpdate = TStrConv.StrToIntDef(this.KeyAddUpDate.Text, 0);
            this._keyAddUpSecCode = TStrConv.StrToIntDef(this.KeyAddUpSecCode.Text, 0);
            this._keyCustomerCode = TStrConv.StrToIntDef(this.KeyCustomerCode.Text, 0);

            DateTime now = DateTime.Now;

            this.DATE.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);

            // 作成時間
            this.TIME.Text = now.ToString("HH:mm");

        }

        // --- ADD 2012/11/01 ---------->>>>>
        private void CustomerFooter_Format(object sender, EventArgs e)
        {
            // 消費税額を初期化する
            this._thisStockTaxValue = 0;
        }
        // --- ADD 2012/11/01 ----------<<<<<

	}
}

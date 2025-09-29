using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 得意先元帳照会アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 得意先元帳照会のデータアクセスクラス</br>
	/// <br>Programer	: 20081 疋田 勇人</br>
	/// <br>Date		: 2007.10.18</br>
    /// <br>Programmer  : 30009 渋谷 大輔</br>
    /// <br>Date        : 2009.01.21</br>
    /// <br>Note        : PM.NS用に修正</br>
    /// <br>Note        : ※DC→PMで変更が必要な部分のみ修正しました。※</br>
    /// <br>Note        : ※PMで不要な処理があっても問題がなければそのままにしてあります※</br>
    /// <br>Date        : 2014/02/20</br>
    /// <br>Note        : 仕掛一覧 №2294対応</br>
    /// <br>Note        : 売掛情報取得時のエラーStatusを例外で返すように修正</br>
    /// <br>Update Note : 2014/02/26 田建委</br>
    /// <br>            : Redmine#42188 出力金額区分追加</br>
    /// <br>UpdateNote  : 2015/09/21 田思春</br>
    /// <br>管理番号    : 11170168-00</br>
    /// <br>            : Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応</br>
    /// </remarks>
	public class CsLedgerDmdAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 得意先元帳照会アクセスクラスコンストラクター
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public CsLedgerDmdAcs()
		{
		}

		/// <summary>
		/// 得意先元帳照会アクセスクラス静的コンストラクター
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		static CsLedgerDmdAcs()
		{
			// 拠点情報取得部品インスタンス化
			_secInfoAcs = new SecInfoAcs();
			// 合計用計上年月日(開始)            
			_ttlAddUpDateSpanStart = new DateTime(1, 1, 1);
			// 合計用計上年月日(終了)            
			_ttlAddUpDateSpanEnd = new DateTime(1, 1, 1);
			// データセット作成
			SettingDataSet();
			// 使用するテーブル初期化
			_csLedgerCustomerHTable = new Hashtable();
			_sectionHTable = new Hashtable();
			_secCodeList = new ArrayList();
			_htCAddUpUpDate = new Hashtable();
            // 入金ワークテーブル
			_depsitHTable = new Hashtable();
			// ログイン拠点取得
			Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
			if (loginEmployee != null)
			{
				_mySectionCode = loginEmployee.BelongSectionCode;
			}
            try
            {
                // リモートオブジェクト取得
                _iCustDmdPrcInfGetDB = (ICustDmdPrcInfGetDB)MediationCustDmdPrcInfGetDB.GetCustDmdPrcInfGetDB();
                _iCustAccRecInfGetDB = (ICustAccRecInfGetDB)MediationCustAccRecInfGetDB.GetCustAccRecInfGetDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                _iCustDmdPrcInfGetDB = null;
                _iCustAccRecInfGetDB = null;
            }

		}
		#endregion ■ Constructor

        

        #region ■ Static Member
        /// <summary>モード</summary>
        private static int _imode;

        /// <summary>元帳照会データセット</summary>
		private static DataSet _csLedgerDataSet = null;

		/// <summary>元帳照会明細データテーブル(伝票一覧)</summary>
		private static DataTable _csLedgerSlipDataTable = null;

        /// <summary>元帳照会明細画面用データビュー(伝票一覧)</summary>
		private static DataView _csLedgerSlipDataView = null;

		/// <summary>元帳照会明細データテーブル(明細一覧)</summary>
		private static DataTable _csLedgerDtlDataTable = null;

        /// <summary>元帳照会明細画面用データビュー(明細一覧)</summary>
		private static DataView _csLedgerDtlDataView = null;

        /// <summary>元帳照会明細データテーブル(残高一覧)</summary>
        private static DataTable _csLedgerBlanceDataTable = null;

        /// <summary>元帳照会明細画面用データビュー(残高一覧)</summary>
        private static DataView _csLedgerBlanceDataView = null;

		/// <summary>得意先請求金額データテーブル</summary>
		private static DataTable _custDmdPrcDataTable = null;

		/// <summary>得意先請求金額データビュー</summary>
		private static DataView _custDmdPrcDataView = null;

		/// <summary>入金データリスト</summary>
		private static Hashtable _depsitHTable = null;

		/// <summary>元帳得意先情報</summary>
		private static Hashtable _csLedgerCustomerHTable = null;

		/// <summary>締範囲(開始)</summary>
		private static DateTime _ttlAddUpDateSpanStart = new DateTime(1, 1, 1);

		/// <summary>締範囲(終了)</summary>
		private static DateTime _ttlAddUpDateSpanEnd = new DateTime(1, 1, 1);

		/// <summary>計上年月日(開始)</summary>
		private static DateTime _addUpDateStart = new DateTime(1, 1, 1);

		/// <summary>計上年月日(終了)</summary>
		private static DateTime _addUpDateEnd = new DateTime(1, 1, 1);

		/// <summary>拠点テーブル取得用</summary>
		private static Hashtable _sectionHTable = null;
		private static ArrayList _secCodeList = null;

		/// <summary>自拠点コード</summary>
		private static string _mySectionCode = "";

		/// <summary>本社機能有無[true:本社機能,false:拠点機能]</summary>
		private static bool _isMainOfficeFunc = false;
		
		/// <summary>表示対象拠点コード</summary>
		private static string _targetSectionCode = "";

		/// <summary>締次更新年月日テーブル[KEY:締日,Value:締次更新年月日(int)]</summary>
		private static Hashtable _htCAddUpUpDate = null;

		/// <summary>拠点情報取得部品</summary>
		private static SecInfoAcs _secInfoAcs = null;

		// Acs Class -------------------------------------------------------------
		/// <summary>帳票出力設定アクセスクラス</summary>
		private static PrtOutSetAcs _prtOutSetAcs = null;

		/// <summary>帳票出力設定データクラス</summary>
		private static PrtOutSet _prtOutSetData = null;

		/// <summary>帳票出力設定アクセスクラス</summary>
		private static AlItmDspNmAcs _alItmDspNmAcs = null;

		/// <summary>帳票出力設定データクラス</summary>
		private static AlItmDspNm _alItmDspNmData = null;

        private static ICustDmdPrcInfGetDB _iCustDmdPrcInfGetDB = null;
        private static ICustAccRecInfGetDB _iCustAccRecInfGetDB = null;
        #endregion ■ Static Member

		#region ■ Public Const
		/// <summary>元帳照会データセット名</summary>
		public const string CT_CsLedgerDataSet = "CsLedgerDataSet";
		/// <summary>得意先請求金額テーブル名称</summary>
		public const string Ct_Tbl_CustDmdPrcDataTable = "CustDmdPrcDataTable";
		/// <summary>元帳照会用テーブル名称(伝票一覧画面表示用)</summary>
		public const string Ct_Tbl_CsLedgerSlipDataTable = "CsLedgerSlipDataTable";
        /// <summary>元帳照会用テーブル名称(明細一覧画面表示用)</summary>
        public const string Ct_Tbl_CsLedgerDtlDataTable = "CsLedgerDtlDataTable";
        /// <summary>元帳照会用テーブル名称(残高一覧画面表示用)</summary>
        public const string Ct_Tbl_CsLedgerBalanceDataTable = "CsLedgerBalanceDataTable";


		#region ◆ 得意先請求金額カラム情報(鑑表示用)
		/// <summary>計上拠点コード</summary>
		public const string Ct_CsDmd_AddUpSecCode = "AddUpSecCode";
		/// <summary>計上拠点名称</summary>
		public const string Ct_CsDmd_AddUpSecName = "AddUpSecName";
		/// <summary>計上年月日</summary>
		public const string Ct_CsDmd_AddUpDate = "AddUpDate";
        /// <summary>帳票タイトル</summary>
        public const string Ct_CsDmd_SlitTitle = "SlitTitle";
        /// <summary>計上年月日(Int型)</summary>
		public const string Ct_CsDmd_AddUpDateInt = "AddUpDateInt";
		/// <summary>計上年月</summary>
		public const string Ct_CsDmd_AddUpYearMonth = "AddUpYearMonth";
		/// <summary>前回請求金額</summary>
		public const string Ct_CsDmd_LastTimeDemand = "LastTimeDemand";
		/// <summary>今回入金金額（通常入金）</summary>
		public const string Ct_CsDmd_ThisTimeDmdNrml = "ThisTimeDmdNrml";
		/// <summary>今回繰越残高（請求計）</summary>
		public const string Ct_CsDmd_ThisTimeTtlBlcDmd = "ThisTimeTtlBlcDmd";
        /// <summary>相殺後今回売上金額</summary>
        public const string Ct_CsDmd_OfsThisTimeSales = "OfsThisTimeSales";
        /// <summary>相殺後今回売上消費税</summary>
        public const string Ct_CsDmd_OfsThisSalesTax = "OfsThisSalesTax";
		/// <summary>今回売上金額</summary>
		public const string Ct_CsDmd_ThisTimeSales = "ThisTimeSales";
		/// <summary>消費税転嫁方式</summary>
		public const string Ct_CsDmd_ConsTaxLayMethod = "ConsTaxLayMethod";
		/// <summary>消費税転嫁方式名称</summary>
		public const string Ct_CsDmd_ConsTaxLayMethodName = "ConsTaxLayMethodName";
		/// <summary>計算後請求金額</summary>
		public const string Ct_CsDmd_AfCalDemandPrice = "AfCalDemandPrice";
		/// <summary>受注2回前残高（請求計）</summary>
		public const string Ct_CsDmd_AcpOdrTtl2TmBfBlDmd = "AcpOdrTtl2TmBfBlDmd";
		/// <summary>受注3回前残高（請求計）</summary>
		public const string Ct_CsDmd_AcpOdrTtl3TmBfBlDmd = "AcpOdrTtl3TmBfBlDmd";
		/// <summary>締次更新実行年月日</summary>
		public const string Ct_CsDmd_CAddUpUpdExecDate = "CAddUpUpdExecDate";
		/// <summary>締済フラグ</summary>
		public const string Ct_CsDmd_CloseFlag = "CloseFlag";
        /// <summary>返品・値引額</summary>
        public const string Ct_CsDmd_ThisRgdsDis = "ThisRgdsDis";
        /// <summary>税込売上額</summary>
        public const string Ct_CsDmd_ThisSalesTaxTotal = "ThisSalesTaxTotal";
		/// <summary>日付範囲（開始）</summary>
		public const string Ct_CsDmd_StartDateSpan = "StartDateSpan";
		/// <summary>日付範囲（終了）</summary>
		public const string Ct_CsDmd_EndDateSpan = "EndDateSpan";
        /// <summary>請求先コード</summary>
        public const string Ct_CsDmd_ClaimCode = "ClaimCode";
        /// <summary>請求先略称</summary>
        public const string Ct_CsDmd_ClaimSnm = "ClaimSnm";
        /// <summary>得意先コード</summary>
		public const string Ct_CsDmd_CustomerCode = "CustomerCode";
		/// <summary>名称</summary>
		public const string Ct_CsDmd_Name = "Name";
		/// <summary>名称２</summary>
		public const string Ct_CsDmd_Name2 = "Name2";
        /// <summary>得意先略称</summary>
        public const string Ct_CsDmd_CustomerSnm = "CustomerSnm";
		//--------------------------------------------------
		//  その他項目(印刷用)
		//--------------------------------------------------
		/// <summary>計上年月(印刷用)</summary>
		public const string Ct_CsDmd_PrintAddUpYearMonth = "PrintAddUpYearMonth";
		/// <summary>計上年月日(印刷用)</summary>
		public const string Ct_CsDmd_PrintAddUpDate = "PrintAddUpDate";
		/// <summary>計上年月日開始(一括印刷用)</summary>
		public const string Ct_CsDmd_StratAddUpDate = "StartAddUpDate";
        /// <summary> 返品・値引合計 </summary>
        public const string Col_CsDmd_RgdsDisT = "RgdsDisT";
        /// <summary> 売上伝票枚数 </summary>
        public const string Col_CsDmd_SalesSlipCount = "SalesSlipCount";
        /// <summary> 前回売掛金額 </summary>
        public const string Col_CsDmd_LastTimeAccRec = "LastTimeAccRec";
        /// <summary> 今回繰越残高 </summary>
        public const string Col_CsDmd_ThisTimeTtlBlcAcc = "ThisTimeTtlBlcAcc";
        /// <summary> 税込売上額 </summary>
        public const string Col_CsDmd_TimeSalesTax = "TimeSalesTax";
        /// <summary> 計算後当月売掛金額(今月分の売掛金額)</summary>
        public const string Col_CsDmd_AfCalTMonthAccRec = "AfCalTMonthAccRec";

		#endregion

		#region ◆ 元帳照会用カラム情報(伝票一覧画面表示用)
        /// <summary>請求先コード</summary>
        public const string Ct_CsLedger_ClaimCode = "ClaimCode";
		/// <summary>得意先コード</summary>
		public const string Ct_CsLedger_CustomerCode = "CustomerCode";
		/// <summary>計上日付(締基準)</summary>
		public const string Ct_CsLedger_AddUpDate = "AddUpDate";
		/// <summary>前残繰越区分(0:前残,1:その他(売 or 入),2:繰越)</summary>
		public const string Ct_CsLedger_BalanseCode = "BalanseCode";
		/// <summary>レコード区分(0:売上,1:入金)</summary>
		public const string Ct_CsLedger_RecordCode = "RecordCode";
		/// <summary>売掛区分(0:売掛なし,1:売掛)</summary>
		public const string Ct_CsLedger_AccRecDivCd = "SalesSlipKind";
		/// <summary>伝票種別</summary>
		public const string Ct_CsLedger_SalesSlipKindName = "SalesSlipKindName";
		/// <summary>売上伝票区分(0:売上,1:返品)</summary>
		public const string Ct_CsLedger_SalesSlipCd = "SalesSlipCd";
		/// <summary>赤伝区分(0:黒,1:赤,2相殺済み黒)</summary>
		public const string Ct_CsLedger_DebitNoteDiv = "DebitNoteDiv";
		/// <summary>計上日付</summary>
		public const string Ct_CsLedger_AddUpADate = "AddUpADate";
		/// <summary>計上日付(Int)</summary>
		public const string Ct_CsLedger_AddUpADateInt = "AddUpADateInt";
		/// <summary>計上日付(表示用)</summary>
		public const string Ct_CsLedger_AddUpADateDisp = "AddUpADateDisp";
		/// <summary>伝票番号</summary>
		public const string Ct_CsLedger_SlipNo = "SlipNo";
		/// <summary>受注・入金内容</summary>
		public const string Ct_CsLedger_SlipDetail = "SlipDetail";
		/// <summary>売上金額</summary>
		public const string Ct_CsLedger_SalesTotal = "SalesTotal";
        /// <summary>売上金額(元帳用)</summary>
        public const string Ct_CsLedger_SalesTotal1 = "SalesTotal1";
        /// <summary>売上消費税</summary>
        public const string Ct_CsLedger_SalesSubtotalTax = "SalesSubtotalTax";
        /// <summary>売上消費税(元帳)</summary>
        public const string Ct_CsLedger_SalesSubtotalTax1 = "SalesSubtotalTax1";
        /// <summary>税込売上額</summary>
        public const string Ct_CsLedger_ThisSalesTaxTotal = "ThisSalesTaxTotal";
        /// <summary>手形支払期日(表示用)</summary>
        public const string Ct_CsLedger_DraftPayTimeLimit = "DraftPayTimeLimit";
        /// <summary>入金金額</summary>
		public const string Ct_CsLedger_Deposit = "Deposit";
		/// <summary>残高</summary>
		public const string Ct_CsLedger_Balance = "Balance";
		/// <summary>伝票備考</summary>
		public const string Ct_CsLedger_SlipNote = "SlipNote";
        /// <summary>伝票備考2</summary>
        public const string Ct_CsLedger_SlipNote2 = "SlipNote2";
        /// <summary>計上拠点コード</summary>
		public const string Ct_CsLedger_AddUpSecCode = "AddUpSecCode";
		/// <summary>計上拠点名称</summary>
		public const string Ct_CsLedger_AddUpSecName = "AddUpSecName";
        /// <summary>相手先伝票番号（明細）</summary>
        public const string Ct_CsLedger_PartySlipNumDtl = "PartySlipNum";
        /// <summary>印字区分</summary>
        public const string Ct_CsLedger_PrtDiv = "PrtDiv";
        /// <summary>UOEリマーク1</summary>
        public const string Ct_CsLedger_UOERemark1 = "UOERemark1";
        /// <summary>UOEリマーク2</summary>
        public const string Ct_CsLedger_UOERemark2 = "UOERemark2";
        #endregion

        #region ◆ 元帳照会用カラム情報(明細一覧画面表示用)
        /// <summary>請求先コード</summary>
        public const string Ct_CsLedgerDtl_ClaimCode = "ClaimCode";
        /// <summary>得意先コード</summary>
		public const string Ct_CsLedgerDtl_CustomerCode = "CustomerCode";
		/// <summary>計上日付(締基準)</summary>
		public const string Ct_CsLedgerDtl_AddUpDate = "AddUpDate";
		/// <summary>前残繰越区分(0:前残,1:その他(売 or 入),2:繰越)</summary>
		public const string Ct_CsLedgerDtl_BalanseCode = "BalanseCode";
		/// <summary>レコード区分(0:売上,1:入金)</summary>
		public const string Ct_CsLedgerDtl_RecordCode = "RecordCode";
		/// <summary>伝票種別</summary>
		public const string Ct_CsLedgerDtl_SalesSlipKindName = "SalesSlipKindName";
		/// <summary>売上伝票区分(0:売上,1:返品)</summary>
		public const string Ct_CsLedgerDtl_SalesSlipCd = "SalesSlipCd";
		/// <summary>赤伝区分(0:黒,1:赤,2相殺済み黒)</summary>
		public const string Ct_CsLedgerDtl_DebitNoteDiv = "DebitNoteDiv";
		/// <summary>計上日付</summary>
		public const string Ct_CsLedgerDtl_AddUpADate = "AddUpADate";
		/// <summary>計上日付(Int)</summary>
		public const string Ct_CsLedgerDtl_AddUpADateInt = "AddUpADateInt";
		/// <summary>計上日付(表示用)</summary>
		public const string Ct_CsLedgerDtl_AddUpADateDisp = "AddUpADateDisp";
		/// <summary>伝票番号・入金番号</summary>
		/// <remarks>売伝時:売上伝票番号、入金時:入金番号</remarks>
		public const string Ct_CsLedgerDtl_SlipNo = "SlipNo";
		/// <summary>計上拠点コード</summary>
		public const string Ct_CsLedgerDtl_AddUpSecCode = "AddUpSecCode";
		/// <summary>計上拠点名称</summary>
        public const string Ct_CsLedgerDtl_AddUpSecName = "AddUpSecName";
        /// <summary>売上金額</summary>
        public const string Ct_CsLedgerDtl_SalesTotal = "SalesTotal";
        /// <summary>売上消費税</summary>
        public const string Ct_CsLedgerDtl_SalesSubtotalTax = "SalesSubtotalTax";
        /// <summary>税込売上額</summary>
        public const string Ct_CsLedgerDtl_ThisSalesTaxTotal = "ThisSalesTaxTotal";
        /// <summary>手形支払期日(表示用)</summary>
        public const string Ct_CsLedgerDtl_DraftPayTimeLimit = "DraftPayTimeLimit";
        /// <summary>受注・入金内容</summary>
        public const string Ct_CsLedgerDtl_SlipDetail = "SlipDetail";
        /// <summary>残高</summary>
        public const string Ct_CsLedgerDtl_Balance = "Balance";
        /// <summary>入金金額</summary>
        public const string Ct_CsLedgerDtl_Deposit = "Deposit";
        /// <summary>伝票備考</summary>
        public const string Ct_CsLedgerDtl_SlipNote = "SlipNote";
        /// <summary>伝票備考2</summary>
        public const string Ct_CsLedgerDtl_SlipNote2 = "SlipNote2";
        /// <summary>売上行番号</summary>
        public const string Ct_CsLedgerDtl_SalesRowNo = "SalesRowNo";
        /// <summary>商品番号</summary>
        public const string Ct_CsLedgerDtl_GoodsNo = "GoodsNo";
        /// <summary>商品名称</summary>
        public const string Ct_CsLedgerDtl_GoodsName = "GoodsName";
        /// <summary>出荷数</summary>
        public const string Ct_CsLedgerDtl_ShipmentCnt = "ShipmentCnt";
        /// <summary>売上単価（税抜，浮動）</summary>
        public const string Ct_CsLedgerDtl_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";
        /// <summary>売上金額（税抜き）</summary>
        public const string Ct_CsLedgerDtl_SalesMoneyTaxExc = "SalesMoneyTaxExc";
        /// <summary>売上金額（元帳用）</summary>
        public const string Ct_CsLedgerDtl_SalesMoneyTaxExc1 = "SalesMoneyTaxExc1";
        /// <summary>売上金額消費税</summary>
        public const string Ct_CsLedgerDtl_SalsePriceConsTax = "SalsePriceConsTax";
        /// <summary>売上金額消費税(元帳用)</summary>
        public const string Ct_CsLedgerDtl_SalsePriceConsTax1 = "SalsePriceConsTax1";
        /// <summary>相手先伝票番号（明細）</summary> 
        public const string Ct_CsLedgerDtl_PartySlipNumDtl = "PartySlipNumDtl";
        /// <summary>UOEリマーク1</summary>
        public const string Ct_CsLedgerDtl_UOERemark1 = "UOERemark1";
        /// <summary>UOEリマーク2</summary>
        public const string Ct_CsLedgerDtl_UOERemark2 = "UOERemark2";
        /// <summary>仕入先コード</summary>
        public const string Ct_CsLedgerDtl_SupplierCd = "SupplierCd";

        // 2009.02.25 30413 犬飼 消費税転嫁方式の追加 >>>>>>START
        /// <summary>消費税転嫁方式</summary>
        public const string Ct_CsLedgerDtl_ConsTaxLayMethod = "ConsTaxLayMethod";
        /// <summary>課税区分</summary>
        public const string Ct_CsLedgerDtl_TaxationDivCd = "TaxationDivCd";
        // 2009.02.25 30413 犬飼 消費税転嫁方式の追加 <<<<<<END
                                    
        #endregion

        #region ◆ 元帳照会用カラム情報(残高一覧画面表示用)
        /// <summary>計上拠点コード</summary>
        public const string Ct_CsLedgerBlance_AddUpSecCode = "AddUpSecCode";
        /// <summary>計上拠点名称</summary>
        public const string Ct_CsLedgerBlance_AddUpSecName = "AddUpSecName";
        /// <summary>計上年月日</summary>
        public const string Ct_CsLedgerBlance_AddUpDate = "AddUpDate";
        /// <summary>帳票タイトル</summary>
        public const string Ct_CsLedgerBlance_SlitTitle = "SlitTitle";
        /// <summary>計上年月日(Int型)</summary>
        public const string Ct_CsLedgerBlance_AddUpDateInt = "AddUpDateInt";
        /// <summary>計上年月</summary>
        public const string Ct_CsLedgerBlance_AddUpYearMonth = "AddUpYearMonth";
        /// <summary>前回請求金額</summary>
        public const string Ct_CsLedgerBlance_LastTimeDemand = "LastTimeDemand";
        /// <summary>今回入金金額（通常入金）</summary>
        public const string Ct_CsLedgerBlance_ThisTimeDmdNrml = "ThisTimeDmdNrml";
        /// <summary>今回繰越残高（請求計）</summary>
        public const string Ct_CsLedgerBlance_ThisTimeTtlBlcDmd = "ThisTimeTtlBlcDmd";
        /// <summary>相殺後今回売上金額</summary>
        public const string Ct_CsLedgerBlance_OfsThisTimeSales = "OfsThisTimeSales";
        /// <summary>相殺後今回売上消費税</summary>
        public const string Ct_CsLedgerBlance_OfsThisSalesTax = "OfsThisSalesTax";
        /// <summary>今回売上金額</summary>
        public const string Ct_CsLedgerBlance_ThisTimeSales = "ThisTimeSales";
        /// <summary>消費税転嫁方式</summary>
        public const string Ct_CsLedgerBlance_ConsTaxLayMethod = "ConsTaxLayMethod";
        /// <summary>消費税転嫁方式名称</summary>
        public const string Ct_CsLedgerBlance_ConsTaxLayMethodName = "ConsTaxLayMethodName";
        /// <summary>計算後請求金額</summary>
        public const string Ct_CsLedgerBlance_AfCalDemandPrice = "AfCalDemandPrice";
        /// <summary>受注2回前残高（請求計）</summary>
        public const string Ct_CsLedgerBlance_AcpOdrTtl2TmBfBlDmd = "AcpOdrTtl2TmBfBlDmd";
        /// <summary>受注3回前残高（請求計）</summary>
        public const string Ct_CsLedgerBlance_AcpOdrTtl3TmBfBlDmd = "AcpOdrTtl3TmBfBlDmd";
        /// <summary>締次更新実行年月日</summary>
        public const string Ct_CsLedgerBlance_CAddUpUpdExecDate = "CAddUpUpdExecDate";
        /// <summary>締済フラグ</summary>
        public const string Ct_CsLedgerBlance_CloseFlag = "CloseFlag";
        /// <summary>返品・値引額</summary>
        public const string Ct_CsLedgerBlance_ThisRgdsDis = "ThisRgdsDis";
        /// <summary>税込売上額</summary>
        public const string Ct_CsLedgerBlance_ThisSalesTaxTotal = "ThisSalesTaxTotal";
        /// <summary>日付範囲（開始）</summary>
        public const string Ct_CsLedgerBlance_StartDateSpan = "StartDateSpan";
        /// <summary>日付範囲（終了）</summary>
        public const string Ct_CsLedgerBlance_EndDateSpan = "EndDateSpan";
        /// <summary>請求先コード</summary>
        public const string Ct_CsLedgerBlance_ClaimCode = "ClaimCode";
        /// <summary>得意先コード</summary>
        public const string Ct_CsLedgerBlance_CustomerCode = "CustomerCode";
        /// <summary>名称</summary>
        public const string Ct_CsLedgerBlance_Name = "Name";
        /// <summary>名称２</summary>
        public const string Ct_CsLedgerBlance_Name2 = "Name2";
        #endregion

		#endregion ■ Public Member

		#region ■ Public Enum
		/// <summary>元帳明細のレコード区分の列挙型</summary>
		public enum LedgerDtlRecordState : int
		{
			/// <summary>売上</summary>
			Sales = 0,
			/// <summary>入金</summary>
			Deposit = 1,
		}

		/// <summary>元帳明細の前残繰越区分の列挙型です。</summary>
		public enum LedgerDtlBalanseState : int
		{
			/// <summary>前残</summary>
			Balance = 0,
			/// <summary>その他(売 or 入)</summary>
			Others = 1,
			/// <summary>消費税</summary>
			ConsTax = 2,
			/// <summary>繰越</summary>
			Carried = 3,
		}

		/// <summary>赤伝区分(0:黒,1:赤,2:相殺済み黒)</summary>
		public enum LedgerDtlDebitNoteDivState : int
		{
			/// <summary>黒</summary>
			Black = 0,
			/// <summary>赤</summary>
			Red = 1,
			/// <summary>相殺済み黒</summary>
			OffsetBlack = 2,
		}

		/// <summary>売上伝票区分(0:売上,1:返品)</summary>
		public enum LedgerDtlSalesSlipCdState : int
		{
			/// <summary>売上</summary>
			Sale = 0,
            /// <summary>返品</summary>
            Back = 1,
            /// <summary>値引</summary>
            Discount = 2,
		}

		/// <summary>締フラグ区分(0:未締,1:締済)</summary>
		public enum CloseFlagState : int
		{
			/// <summary>未締</summary>
			NotClose = 0,
			/// <summary>締済</summary>
			Close = 1,
		}


		#endregion ■ Public Enum

		#region ■ Public Property

		/// <summary>元帳明細データセットプロパティ</summary>
		public DataSet CsLedgerDataSet
		{
			get { return _csLedgerDataSet; }
		}

		/// <summary>元帳明細データテーブルプロパティ(伝票一覧)</summary>
		public DataTable CsLedgerSlipDataTable
		{
			get { return _csLedgerSlipDataTable; }
		}

		/// <summary>元帳明細データビュープロパティ(伝票一覧)</summary>
		public DataView CsLedgerSlipDataView
		{
			get { return _csLedgerSlipDataView; }
		}

		/// <summary>元帳明細データテーブルプロパティ(明細一覧)</summary>
		public DataTable CsLedgerDtlDataTable
		{
			get { return _csLedgerDtlDataTable; }
		}

		/// <summary>元帳明細データビュープロパティ(明細一覧)</summary>
		public DataView CsLedgerDtlDataView
		{
			get { return _csLedgerDtlDataView; }
		}

        /// <summary>元帳明細データテーブルプロパティ(残高一覧)</summary>
        public DataTable CsLedgerBalanceDataTable
        {
            get { return _csLedgerBlanceDataTable; }
        }

        /// <summary>元帳明細データビュープロパティ(残高一覧)</summary>
        public DataView CsLedgerBalanceDataView
        {
            get { return _csLedgerBlanceDataView; }
        }

		/// <summary>得意先金額データテーブルプロパティ</summary>
		public DataTable CustDmdPrcDataTable
		{
			get { return _custDmdPrcDataTable; }
		}

		/// <summary>得意先金額データビュープロパティ</summary>
		public DataView CustDmdPrcDataView
		{
			get { return _custDmdPrcDataView; }
		}

		/// <summary>入金伝票データテーブルプロパティ</summary>
		public Hashtable DepsitHTable
		{
			get { return _depsitHTable; }
		}

		/// <summary>締範囲（開始）</summary>
		public DateTime TtlAddUpDateSpanStart
		{
			get { return _ttlAddUpDateSpanStart; }
		}

		/// <summary>締範囲（終了）</summary>
		public DateTime TtlAddUpDateSpanEnd
		{
			get { return _ttlAddUpDateSpanEnd; }
		}

		/// <summary>計上年月日（開始）</summary>
		public DateTime AddUpDateStart
		{
			get { return _addUpDateStart; }
		}

		/// <summary>計上年月日（終了）</summary>
		public DateTime AddUpDateEnd
		{
			get { return _addUpDateEnd; }
		}

		/// <summary>拠点情報リスト</summary>
		public Hashtable SectionHTable
		{
			get { return _sectionHTable; }
		}

		/// <summary>拠点コードリスト</summary>
		public ArrayList SecCodeList
		{
			get { return _secCodeList;}
		}

		#endregion ■ Public Property

		#region ■ Public Static Method
		/// <summary>
		/// データセット、データテーブル設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		private static void SettingDataSet()
		{
			if (_csLedgerDataSet == null)
			{
			    _csLedgerDataSet = new DataSet();
			    CreateTableSchemer_CsLedgerSlipDataTable(ref _csLedgerDataSet);
                CreateTableSchemer_CsLedgerDtlDataTable(ref _csLedgerDataSet);
                CreateTableSchemer_CsLedgerBalanceDataTable(ref _csLedgerDataSet);
                CreateTableSchemer_CustDmdPrcDataTable(ref _csLedgerDataSet);
			}
		}


		#region ◆ 得意先請求金額(鑑用)テーブルスキーマ定義
		/// <summary>
		/// 得意先請求金額(鑑用)テーブルスキーマ定義
		/// </summary>
		/// <param name="ds"></param>
		public static void CreateTableSchemer_CustDmdPrcDataTable(ref DataSet ds)
		{
			DataTable dt = new DataTable(Ct_Tbl_CustDmdPrcDataTable);

			#region
			dt.Columns.Add(Ct_CsDmd_AddUpSecCode, typeof( string )); // 計上拠点コード
			dt.Columns[Ct_CsDmd_AddUpSecCode].Caption = "計上拠点コード";

			dt.Columns.Add(Ct_CsDmd_AddUpSecName, typeof( string )); // 計上拠点名称
			dt.Columns[Ct_CsDmd_AddUpSecName].Caption = "計上拠点名称";

			dt.Columns.Add(Ct_CsDmd_AddUpDate, typeof( DateTime )); // 計上年月日
			dt.Columns[Ct_CsDmd_AddUpDate].Caption = "計上年月日";

            dt.Columns.Add(Ct_CsDmd_SlitTitle, typeof(string)); // 帳票タイトル
            dt.Columns[Ct_CsDmd_SlitTitle].Caption = "帳票タイトル";

			dt.Columns.Add(Ct_CsDmd_AddUpDateInt, typeof( Int32 )); // 計上年月日(Int)
			dt.Columns[Ct_CsDmd_AddUpDateInt].Caption = "計上年月日";

			dt.Columns.Add(Ct_CsDmd_AddUpYearMonth, typeof( Int32 )); // 計上年月
			dt.Columns[Ct_CsDmd_AddUpYearMonth].Caption = "計上年月";

			dt.Columns.Add(Ct_CsDmd_LastTimeDemand, typeof( Int64 )); // 前回請求金額
			dt.Columns[Ct_CsDmd_LastTimeDemand].Caption = "前回請求金額";

			dt.Columns.Add(Ct_CsDmd_ThisTimeDmdNrml, typeof( Int64 )); // 今回入金金額（通常入金）
			dt.Columns[Ct_CsDmd_ThisTimeDmdNrml].Caption = "今回入金金額（通常入金）";

			dt.Columns.Add(Ct_CsDmd_ThisTimeTtlBlcDmd, typeof( Int64 )); // 今回繰越残高（請求計）
			dt.Columns[Ct_CsDmd_ThisTimeTtlBlcDmd].Caption = "今回繰越残高（請求計）";

			dt.Columns.Add(Ct_CsDmd_OfsThisTimeSales, typeof( Int64 )); // 相殺後今回売上金額
			dt.Columns[Ct_CsDmd_OfsThisTimeSales].Caption = "相殺後今回売上金額";

			dt.Columns.Add(Ct_CsDmd_OfsThisSalesTax, typeof( Int64 )); // 相殺後今回売上消費税
			dt.Columns[Ct_CsDmd_OfsThisSalesTax].Caption = "相殺後今回売上消費税";

			dt.Columns.Add(Ct_CsDmd_ThisTimeSales, typeof( Int64 )); // 今回売上金額
			dt.Columns[Ct_CsDmd_ThisTimeSales].Caption = "今回売上金額";

			dt.Columns.Add(Ct_CsDmd_ConsTaxLayMethod, typeof( Int32 )); // 消費税転嫁方式
			dt.Columns[Ct_CsDmd_ConsTaxLayMethod].Caption = "消費税転嫁方式";

			dt.Columns.Add(Ct_CsDmd_ConsTaxLayMethodName, typeof( string )); // 消費税転嫁方式
			dt.Columns[Ct_CsDmd_ConsTaxLayMethodName].Caption = "消費税転嫁方式";

			dt.Columns.Add(Ct_CsDmd_AfCalDemandPrice, typeof( Int64 )); // 計算後請求金額
			dt.Columns[Ct_CsDmd_AfCalDemandPrice].Caption = "計算後請求金額";

			dt.Columns.Add(Ct_CsDmd_AcpOdrTtl2TmBfBlDmd, typeof( Int64 )); // 受注2回前残高（請求計）
			dt.Columns[Ct_CsDmd_AcpOdrTtl2TmBfBlDmd].Caption = "受注2回前残高（請求計）";

			dt.Columns.Add(Ct_CsDmd_AcpOdrTtl3TmBfBlDmd, typeof( Int64 )); // 受注3回前残高（請求計）
			dt.Columns[Ct_CsDmd_AcpOdrTtl3TmBfBlDmd].Caption = "受注3回前残高（請求計）";

			dt.Columns.Add(Ct_CsDmd_CAddUpUpdExecDate, typeof( Int32 )); // 締次更新実行年月日
			dt.Columns[Ct_CsDmd_CAddUpUpdExecDate].Caption = "締次更新実行年月日";

			dt.Columns.Add(Ct_CsDmd_CloseFlag, typeof( Int32 )); // 請求処理通番
			dt.Columns[Ct_CsDmd_CloseFlag].Caption = "締済フラグ";

			dt.Columns.Add(Ct_CsDmd_ThisRgdsDis, typeof( Int64 )); // 返品・値引額
			dt.Columns[Ct_CsDmd_ThisRgdsDis].Caption = "返品・値引額";

			dt.Columns.Add(Ct_CsDmd_ThisSalesTaxTotal, typeof( Int64 )); // 税込売上額
			dt.Columns[Ct_CsDmd_ThisSalesTaxTotal].Caption = "税込売上額";

			dt.Columns.Add(Ct_CsDmd_StartDateSpan, typeof( Int32 )); // 日付範囲（開始）
			dt.Columns[Ct_CsDmd_StartDateSpan].Caption = "日付範囲（開始）";

			dt.Columns.Add(Ct_CsDmd_EndDateSpan, typeof( Int32 )); // 日付範囲（終了）
			dt.Columns[Ct_CsDmd_EndDateSpan].Caption = "日付範囲（終了）";

			dt.Columns.Add(Ct_CsDmd_ClaimCode, typeof( Int32 )); // 請求先コード
            dt.Columns[Ct_CsDmd_ClaimCode].Caption = "請求先コード";

			dt.Columns.Add(Ct_CsDmd_ClaimSnm, typeof( string )); // 請求先略称
			dt.Columns[Ct_CsDmd_ClaimSnm].Caption = "請求先略称";

			dt.Columns.Add(Ct_CsDmd_CustomerCode, typeof( Int32 )); // 得意先コード
			dt.Columns[Ct_CsDmd_CustomerCode].Caption = "得意先コード";

			dt.Columns.Add(Ct_CsDmd_Name, typeof( string )); // 得意先名称
			dt.Columns[Ct_CsDmd_Name].Caption = "得意先名称";

			dt.Columns.Add(Ct_CsDmd_Name2, typeof( string )); // 得意先名称2
			dt.Columns[Ct_CsDmd_Name2].Caption = "得意先名称2";

			dt.Columns.Add(Ct_CsDmd_CustomerSnm, typeof( string )); // 略称
			dt.Columns[Ct_CsDmd_CustomerSnm].Caption = "得意先略称";

			dt.Columns.Add(Ct_CsDmd_PrintAddUpYearMonth, typeof( Int32 )); // 計上年月
			dt.Columns[Ct_CsDmd_PrintAddUpYearMonth].Caption = "計上年月";

			dt.Columns.Add(Ct_CsDmd_PrintAddUpDate, typeof( Int32 )); // 計上年月日
			dt.Columns[Ct_CsDmd_PrintAddUpDate].Caption = "計上年月日";

			dt.Columns.Add(Ct_CsDmd_StratAddUpDate, typeof( string )); // 集金日
			dt.Columns[Ct_CsDmd_StratAddUpDate].Caption = "計上年月日開始";

			dt.Columns.Add(Col_CsDmd_RgdsDisT, typeof( Int64 )); // 返品・値引合計
			dt.Columns[Col_CsDmd_RgdsDisT].Caption = "返品・値引合計";

			dt.Columns.Add(Col_CsDmd_SalesSlipCount, typeof( Int32 )); // 売上伝票枚数
			dt.Columns[Col_CsDmd_SalesSlipCount].Caption = "売上伝票枚数";

			dt.Columns.Add(Col_CsDmd_LastTimeAccRec, typeof( Int64 )); // 前回売掛金額
			dt.Columns[Col_CsDmd_LastTimeAccRec].Caption = "前回売掛金額";

			dt.Columns.Add(Col_CsDmd_ThisTimeTtlBlcAcc, typeof( Int64 )); // 今回繰越残高
			dt.Columns[Col_CsDmd_ThisTimeTtlBlcAcc].Caption = "今回繰越残高(買掛)";

			dt.Columns.Add(Col_CsDmd_TimeSalesTax, typeof( Int64 )); // 税込売上額
			dt.Columns[Col_CsDmd_TimeSalesTax].Caption = "税込売上額";

			dt.Columns.Add(Col_CsDmd_AfCalTMonthAccRec, typeof( Int64 )); // 計算後当月売掛金額
			dt.Columns[Col_CsDmd_AfCalTMonthAccRec].Caption = "計算後当月売掛金額";
			#endregion

			ds.Tables.Add( dt );

			string sort = Ct_CsDmd_AddUpSecCode + "," + Ct_CsDmd_ClaimCode + "," + Ct_CsDmd_AddUpDate;

			// 得意先請求金額テーブル
			_custDmdPrcDataTable = dt;
			_custDmdPrcDataView  = new DataView( dt, string.Empty, sort, DataViewRowState.CurrentRows );

		}
		#endregion

		#region ◆ 元帳照会用(伝票一覧画面表示用)テーブルスキーマ定義
		/// <summary>
		/// 元帳用(伝票一覧画面表示用)テーブルスキーマ定義
		/// </summary>
		/// <param name="ds"></param>
		public static void CreateTableSchemer_CsLedgerSlipDataTable(ref DataSet ds)
		{
			DataTable dt = new DataTable( Ct_Tbl_CsLedgerSlipDataTable );

			#region
			dt.Columns.Add(Ct_CsLedger_ClaimCode, typeof( Int32 )); // 請求先コード
			dt.Columns[Ct_CsLedger_ClaimCode].Caption = "請求先コード";

			dt.Columns.Add(Ct_CsLedger_CustomerCode, typeof( Int32 )); // 得意先コード
			dt.Columns[Ct_CsLedger_CustomerCode].Caption = "得意先コード";

			dt.Columns.Add(Ct_CsLedger_AddUpDate, typeof( Int32 )); // 計上日付(締基準)
			dt.Columns[Ct_CsLedger_AddUpDate].Caption = "計上年月日";

			dt.Columns.Add(Ct_CsLedger_BalanseCode, typeof( Int32 )); // 前残繰越区分(0:前残,1:その他(売 or 入),2:繰越)
			dt.Columns[Ct_CsLedger_BalanseCode].Caption = "前残繰越区分";

			dt.Columns.Add(Ct_CsLedger_RecordCode, typeof( Int32 )); // レコード区分
			dt.Columns[Ct_CsLedger_RecordCode].Caption = "レコード区分";

			dt.Columns.Add(Ct_CsLedger_SalesSlipCd, typeof( Int32 )); // 売上伝票区分(0:売上,1:返品)
			dt.Columns[Ct_CsLedger_SalesSlipCd].Caption = "売上伝票区分";

			dt.Columns.Add(Ct_CsLedger_DebitNoteDiv, typeof( Int32 )); // 赤伝区分
			dt.Columns[Ct_CsLedger_DebitNoteDiv].Caption = "赤伝区分";

			dt.Columns.Add(Ct_CsLedger_AddUpADate, typeof( DateTime )); // 計上日付
			dt.Columns[Ct_CsLedger_AddUpADate].Caption = "計上日付";

			dt.Columns.Add(Ct_CsLedger_AddUpADateInt, typeof( Int32 )); // 計上日付(Int)
			dt.Columns[Ct_CsLedger_AddUpADateInt].Caption = "計上日付";

			dt.Columns.Add(Ct_CsLedger_AddUpADateDisp, typeof( string )); // 計上日付(表示用)
			dt.Columns[Ct_CsLedger_AddUpADateDisp].Caption = "計上日付";

			dt.Columns.Add(Ct_CsLedger_SlipNo, typeof( string )); // 伝票番号・入金番号
			dt.Columns[Ct_CsLedger_SlipNo].Caption = "伝票番号";

            dt.Columns.Add(Ct_CsLedger_AccRecDivCd, typeof(string)); // 売掛区分(0:売掛なし,1:売掛)
			dt.Columns[Ct_CsLedger_AccRecDivCd].Caption = "売掛区分";

			dt.Columns.Add(Ct_CsLedger_SalesSlipKindName, typeof( string )); // 伝票種別
			dt.Columns[Ct_CsLedger_SalesSlipKindName].Caption = "伝票種別";

			dt.Columns.Add(Ct_CsLedger_SlipDetail, typeof( string )); // 受注・入金内容
			dt.Columns[Ct_CsLedger_SlipDetail].Caption = "内容";

			dt.Columns.Add(Ct_CsLedger_SalesTotal, typeof( Int64 )); // 売上金額
			dt.Columns[Ct_CsLedger_SalesTotal].Caption = "売上金額";

            dt.Columns.Add(Ct_CsLedger_SalesTotal1, typeof(Int64)); // 売上金額(元帳用)
            dt.Columns[Ct_CsLedger_SalesTotal1].Caption = "売上金額(元帳用)";

			dt.Columns.Add(Ct_CsLedger_SalesSubtotalTax, typeof( Int64 )); // 売上消費税
			dt.Columns[Ct_CsLedger_SalesSubtotalTax].Caption = "売上消費税";

            dt.Columns.Add(Ct_CsLedger_SalesSubtotalTax1, typeof(Int64)); // 売上消費税(元帳用)
            dt.Columns[Ct_CsLedger_SalesSubtotalTax1].Caption = "売上消費税(元帳用)";

			dt.Columns.Add(Ct_CsLedger_ThisSalesTaxTotal, typeof( Int64 )); // 税込売上額
			dt.Columns[Ct_CsLedger_ThisSalesTaxTotal].Caption = "税込売上額";

            dt.Columns.Add(Ct_CsLedger_DraftPayTimeLimit, typeof(string)); // 手形支払期日(表示用)
            dt.Columns[Ct_CsLedger_DraftPayTimeLimit].Caption = "手形支払期日";

            dt.Columns.Add(Ct_CsLedgerDtl_GoodsName, typeof(string));   // 商品名称
            dt.Columns[Ct_CsLedgerDtl_GoodsName].Caption = "商品名称";

            dt.Columns.Add(Ct_CsLedger_Deposit, typeof(Int64)); // 入金金額
			dt.Columns[Ct_CsLedger_Deposit].Caption = "入金金額";

			dt.Columns.Add(Ct_CsLedger_Balance, typeof( Int64 )); // 残高
			dt.Columns[Ct_CsLedger_Balance].Caption = "残高";

			dt.Columns.Add(Ct_CsLedger_SlipNote, typeof( string )); // 備考
			dt.Columns[Ct_CsLedger_SlipNote].Caption = "備考";

            dt.Columns.Add(Ct_CsLedger_SlipNote2, typeof(string)); // 備考2
            dt.Columns[Ct_CsLedger_SlipNote2].Caption = "備考";

			dt.Columns.Add(Ct_CsLedger_AddUpSecCode, typeof( string )); // 計上拠点コード
			dt.Columns[Ct_CsLedger_AddUpSecCode].Caption = "計上拠点コード";

			dt.Columns.Add(Ct_CsLedger_AddUpSecName, typeof( string )); // 計上拠点名称
			dt.Columns[Ct_CsLedger_AddUpSecName].Caption = "計上拠点名称";

			dt.Columns.Add(Ct_CsLedger_PartySlipNumDtl, typeof( string )); // 相手先伝票番号（明細）
			dt.Columns[Ct_CsLedger_PartySlipNumDtl].Caption = "相手先伝票番号";

			dt.Columns.Add(Ct_CsLedger_PrtDiv, typeof( Int32 )); // 印字区分
			dt.Columns[Ct_CsLedger_PrtDiv].Caption = "印字区分";

            dt.Columns.Add(Ct_CsLedger_UOERemark1, typeof(string)); // UOEリマーク1
            dt.Columns[Ct_CsLedger_UOERemark1].Caption = "リマーク1";

            dt.Columns.Add(Ct_CsLedger_UOERemark2, typeof(string)); // UOEリマーク2
            dt.Columns[Ct_CsLedger_UOERemark2].Caption = "リマーク1";
            #endregion

            ds.Tables.Add(dt);

            string sort = Ct_CsLedger_ClaimCode + "," + Ct_CsLedger_AddUpDate + "," + Ct_CsLedger_BalanseCode + "," + Ct_CsLedger_AddUpADateInt + "," + Ct_CsLedger_RecordCode + "," + Ct_CsLedger_SlipNo;
            
			_csLedgerSlipDataTable	= dt;
			_csLedgerSlipDataView	= new DataView(_csLedgerSlipDataTable, string.Empty, sort, DataViewRowState.CurrentRows);
		}
		#endregion

		#region ◆ 元帳照会用(明細一覧画面表示用)テーブルスキーマ定義
		/// <summary>
		/// 元帳用(明細一覧画面表示用)テーブルスキーマ定義
		/// </summary>
		/// <param name="ds"></param>
		public static void CreateTableSchemer_CsLedgerDtlDataTable(ref DataSet ds)
		{
			DataTable dt = new DataTable( Ct_Tbl_CsLedgerDtlDataTable );

			#region
			dt.Columns.Add(Ct_CsLedgerDtl_ClaimCode, typeof( Int32 )); // 請求先コード
			dt.Columns[Ct_CsLedgerDtl_ClaimCode].Caption = "請求先コード";

			dt.Columns.Add(Ct_CsLedgerDtl_CustomerCode, typeof( Int32 )); // 得意先コード
			dt.Columns[Ct_CsLedgerDtl_CustomerCode].Caption = "得意先コード";

			dt.Columns.Add(Ct_CsLedgerDtl_AddUpDate, typeof( Int32 )); // 計上日付(締基準)
			dt.Columns[Ct_CsLedgerDtl_AddUpDate].Caption = "計上年月日";

			dt.Columns.Add(Ct_CsLedgerDtl_BalanseCode, typeof( Int32 )); // 前残繰越区分(0:前残,1:その他(売 or 入),2:繰越)
			dt.Columns[Ct_CsLedgerDtl_BalanseCode].Caption = "前残繰越区分";

			dt.Columns.Add(Ct_CsLedgerDtl_RecordCode, typeof( Int32 )); // レコード区分
			dt.Columns[Ct_CsLedgerDtl_RecordCode].Caption = "レコード区分";

			dt.Columns.Add(Ct_CsLedgerDtl_SalesSlipCd, typeof( Int32 )); // 売上伝票区分(0:売上,1:返品)
			dt.Columns[Ct_CsLedgerDtl_SalesSlipCd].Caption = "売上伝票区分";

			dt.Columns.Add(Ct_CsLedgerDtl_DebitNoteDiv, typeof( Int32 )); // 赤伝区分
			dt.Columns[Ct_CsLedgerDtl_DebitNoteDiv].Caption = "赤伝区分";

			dt.Columns.Add(Ct_CsLedgerDtl_AddUpADate, typeof( DateTime )); // 計上日付
			dt.Columns[Ct_CsLedgerDtl_AddUpADate].Caption = "計上日付";

			dt.Columns.Add(Ct_CsLedgerDtl_AddUpADateInt, typeof( Int32 )); // 計上日付(Int)
			dt.Columns[Ct_CsLedgerDtl_AddUpADateInt].Caption = "計上日付";

			dt.Columns.Add(Ct_CsLedgerDtl_AddUpADateDisp, typeof( string )); // 計上日付(表示用)
			dt.Columns[Ct_CsLedgerDtl_AddUpADateDisp].Caption = "計上日付";

			dt.Columns.Add(Ct_CsLedgerDtl_SlipNo, typeof( string )); // 伝票番号・入金番号
			dt.Columns[Ct_CsLedgerDtl_SlipNo].Caption = "伝票番号";

			dt.Columns.Add(Ct_CsLedgerDtl_SalesSlipKindName, typeof( string )); // 伝票種別
			dt.Columns[Ct_CsLedgerDtl_SalesSlipKindName].Caption = "伝票種別";

			dt.Columns.Add(Ct_CsLedgerDtl_AddUpSecCode, typeof( string )); // 計上拠点コード
			dt.Columns[Ct_CsLedgerDtl_AddUpSecCode].Caption = "計上拠点コード";

			dt.Columns.Add(Ct_CsLedgerDtl_AddUpSecName, typeof( string )); // 計上拠点名称
			dt.Columns[Ct_CsLedgerDtl_AddUpSecName].Caption = "計上拠点名称";

			dt.Columns.Add(Ct_CsLedgerDtl_SalesTotal, typeof( Int64 )); // 売上金額
			dt.Columns[Ct_CsLedgerDtl_SalesTotal].Caption = "売上金額";

			dt.Columns.Add(Ct_CsLedgerDtl_SalesSubtotalTax, typeof( Int64 )); // 売上消費税
			dt.Columns[Ct_CsLedgerDtl_SalesSubtotalTax].Caption = "売上金額";

			dt.Columns.Add(Ct_CsLedgerDtl_ThisSalesTaxTotal, typeof( Int64 )); // 税込売上額
			dt.Columns[Ct_CsLedgerDtl_ThisSalesTaxTotal].Caption = "税込売上額";

			dt.Columns.Add(Ct_CsLedgerDtl_DraftPayTimeLimit, typeof( string )); // 手形支払期日(表示用)
			dt.Columns[Ct_CsLedgerDtl_DraftPayTimeLimit].Caption = "手形支払期日";

			dt.Columns.Add(Ct_CsLedgerDtl_SlipDetail, typeof( string )); // 受注・入金内容
			dt.Columns[Ct_CsLedgerDtl_SlipDetail].Caption = "受注・入金内容";

			dt.Columns.Add(Ct_CsLedgerDtl_Balance, typeof( Int64 ));      // 残高
			dt.Columns[Ct_CsLedgerDtl_Balance].Caption = "残高";

			dt.Columns.Add(Ct_CsLedgerDtl_Deposit, typeof( Int64 ));      // 入金金額
			dt.Columns[Ct_CsLedgerDtl_Deposit].Caption = "入金額";

			dt.Columns.Add(Ct_CsLedgerDtl_SlipNote, typeof( string ));    // 伝票備考
			dt.Columns[Ct_CsLedgerDtl_SlipNote].Caption = "伝票備考";

			dt.Columns.Add(Ct_CsLedgerDtl_SlipNote2, typeof( string ));   // 伝票備考2
			dt.Columns[Ct_CsLedgerDtl_SlipNote2].Caption = "伝票備考2";

			dt.Columns.Add(Ct_CsLedgerDtl_SalesRowNo, typeof( Int32 ));   // 売上行番号
			dt.Columns[Ct_CsLedgerDtl_SalesRowNo].Caption = "売上行番号";

			dt.Columns.Add(Ct_CsLedgerDtl_GoodsNo, typeof( string ));     // 商品番号
			dt.Columns[Ct_CsLedgerDtl_GoodsNo].Caption = "商品番号";

			dt.Columns.Add(Ct_CsLedgerDtl_GoodsName, typeof( string ));   // 商品名称
			dt.Columns[Ct_CsLedgerDtl_GoodsName].Caption = "商品名称";

			dt.Columns.Add(Ct_CsLedgerDtl_ShipmentCnt, typeof( double )); // 出荷数
			dt.Columns[Ct_CsLedgerDtl_ShipmentCnt].Caption = "出荷数";

			dt.Columns.Add(Ct_CsLedgerDtl_SalesUnPrcTaxExcFl, typeof( double )); // 売上単価（税抜，浮動）
			dt.Columns[Ct_CsLedgerDtl_SalesUnPrcTaxExcFl].Caption = "売上単価";

			dt.Columns.Add(Ct_CsLedgerDtl_SalesMoneyTaxExc, typeof( Int64 ));    // 売上金額（税抜き）
			dt.Columns[Ct_CsLedgerDtl_SalesMoneyTaxExc].Caption = "売上金額";

            dt.Columns.Add(Ct_CsLedgerDtl_SalesMoneyTaxExc1, typeof(Int64));    // 売上金額（元帳用）
            dt.Columns[Ct_CsLedgerDtl_SalesMoneyTaxExc1].Caption = "売上金額（元帳用）";

            dt.Columns.Add(Ct_CsLedgerDtl_SalsePriceConsTax, typeof(Int64));     // 消費税
            dt.Columns[Ct_CsLedgerDtl_SalsePriceConsTax].Caption = "売上金額消費税";

            dt.Columns.Add(Ct_CsLedgerDtl_SalsePriceConsTax1, typeof(Int64));    // 消費税(元帳用)
            dt.Columns[Ct_CsLedgerDtl_SalsePriceConsTax1].Caption = "売上金額消費税(元帳用)";

			dt.Columns.Add(Ct_CsLedgerDtl_PartySlipNumDtl, typeof( string ));    // 相手先伝票番号（明細）
			dt.Columns[Ct_CsLedgerDtl_PartySlipNumDtl].Caption = "相手先伝票番号";

            dt.Columns.Add(Ct_CsLedgerDtl_UOERemark1, typeof(string)); // UOEリマーク1
            dt.Columns[Ct_CsLedgerDtl_UOERemark1].Caption = "リマーク1";

            dt.Columns.Add(Ct_CsLedgerDtl_UOERemark2, typeof(string)); // UOEリマーク2
            dt.Columns[Ct_CsLedgerDtl_UOERemark2].Caption = "リマーク1";

            dt.Columns.Add(Ct_CsLedgerDtl_SupplierCd, typeof(Int32));   // 仕入先コード
            dt.Columns[Ct_CsLedgerDtl_SupplierCd].Caption = "仕入先コード";

            // 2009.02.25 30413 犬飼 消費税転嫁方式の追加 >>>>>>START
            dt.Columns.Add(Ct_CsLedgerDtl_ConsTaxLayMethod, typeof(Int32));   // 消費税転嫁方式
            dt.Columns[Ct_CsLedgerDtl_ConsTaxLayMethod].Caption = "消費税転嫁方式";

            dt.Columns.Add(Ct_CsLedgerDtl_TaxationDivCd, typeof(Int32));   // 課税区分
            dt.Columns[Ct_CsLedgerDtl_TaxationDivCd].Caption = "課税区分";
            // 2009.02.25 30413 犬飼 消費税転嫁方式の追加 <<<<<<END
                                    
            #endregion

            ds.Tables.Add(dt);

            string sort = Ct_CsLedgerDtl_ClaimCode + "," + Ct_CsLedgerDtl_AddUpDate + "," + Ct_CsLedgerDtl_BalanseCode + "," + Ct_CsLedgerDtl_AddUpADateInt + "," + Ct_CsLedgerDtl_RecordCode + "," + Ct_CsLedgerDtl_SlipNo + "," + Ct_CsLedgerDtl_SalesRowNo;

			_csLedgerDtlDataTable	= dt;
			_csLedgerDtlDataView	= new DataView(_csLedgerDtlDataTable, string.Empty, sort, DataViewRowState.CurrentRows);
		}
		#endregion



        #region ◆ 元帳照会用(残高一覧画面表示用)テーブルスキーマ定義
        /// <summary>
        /// 元帳照会用(残高一覧画面表示用)テーブルスキーマ定義
        /// </summary>
        /// <param name="ds"></param>
        public static void CreateTableSchemer_CsLedgerBalanceDataTable(ref DataSet ds)
        {
            DataTable dt = new DataTable(Ct_Tbl_CsLedgerBalanceDataTable);

            #region
            dt.Columns.Add(Ct_CsLedgerBlance_AddUpSecCode, typeof(string)); // 計上拠点コード
            dt.Columns[Ct_CsLedgerBlance_AddUpSecCode].Caption = "計上拠点コード";

            dt.Columns.Add(Ct_CsLedgerBlance_AddUpSecName, typeof(string)); // 計上拠点名称
            dt.Columns[Ct_CsLedgerBlance_AddUpSecName].Caption = "計上拠点名称";

            dt.Columns.Add(Ct_CsLedgerBlance_AddUpDate, typeof(DateTime)); // 計上年月日
            dt.Columns[Ct_CsLedgerBlance_AddUpDate].Caption = "計上年月日";

            dt.Columns.Add(Ct_CsLedgerBlance_SlitTitle, typeof(string)); // 帳票タイトル
            dt.Columns[Ct_CsLedgerBlance_SlitTitle].Caption = "帳票タイトル";

            dt.Columns.Add(Ct_CsLedgerBlance_AddUpDateInt, typeof(Int32)); // 計上年月日(Int)
            dt.Columns[Ct_CsLedgerBlance_AddUpDateInt].Caption = "計上年月日";

            dt.Columns.Add(Ct_CsLedgerBlance_AddUpYearMonth, typeof(Int32)); // 計上年月
            dt.Columns[Ct_CsLedgerBlance_AddUpYearMonth].Caption = "計上年月";

            dt.Columns.Add(Ct_CsLedgerBlance_LastTimeDemand, typeof(Int64)); // 前回請求金額
            dt.Columns[Ct_CsLedgerBlance_LastTimeDemand].Caption = "前回請求金額";

            dt.Columns.Add(Ct_CsLedgerBlance_ThisTimeDmdNrml, typeof(Int64)); // 今回入金金額（通常入金）
            dt.Columns[Ct_CsLedgerBlance_ThisTimeDmdNrml].Caption = "今回入金金額（通常入金）";

            dt.Columns.Add(Ct_CsLedgerBlance_ThisTimeTtlBlcDmd, typeof(Int64)); // 今回繰越残高（請求計）
            dt.Columns[Ct_CsLedgerBlance_ThisTimeTtlBlcDmd].Caption = "今回繰越残高（請求計）";

            dt.Columns.Add(Ct_CsLedgerBlance_ThisTimeSales, typeof(Int64)); // 今回売上金額
            dt.Columns[Ct_CsLedgerBlance_ThisTimeSales].Caption = "今回売上金額";

            dt.Columns.Add(Ct_CsLedgerBlance_ThisRgdsDis, typeof(Int64)); // 返品・値引額
            dt.Columns[Ct_CsLedgerBlance_ThisRgdsDis].Caption = "返品・値引額";

            dt.Columns.Add(Ct_CsLedgerBlance_OfsThisTimeSales, typeof(Int64)); // 相殺後今回売上金額
            dt.Columns[Ct_CsLedgerBlance_OfsThisTimeSales].Caption = "相殺後今回売上金額";

            dt.Columns.Add(Ct_CsLedgerBlance_OfsThisSalesTax, typeof(Int64)); // 相殺後今回売上消費税
            dt.Columns[Ct_CsLedgerBlance_OfsThisSalesTax].Caption = "相殺後今回売上消費税";

            dt.Columns.Add(Ct_CsLedgerBlance_ThisSalesTaxTotal, typeof(Int64)); // 税込売上額
            dt.Columns[Ct_CsLedgerBlance_ThisSalesTaxTotal].Caption = "税込売上額";

            dt.Columns.Add(Ct_CsLedgerBlance_ConsTaxLayMethod, typeof(Int32)); // 消費税転嫁方式
            dt.Columns[Ct_CsLedgerBlance_ConsTaxLayMethod].Caption = "消費税転嫁方式";

            dt.Columns.Add(Ct_CsLedgerBlance_ConsTaxLayMethodName, typeof(string)); // 消費税転嫁方式
            dt.Columns[Ct_CsLedgerBlance_ConsTaxLayMethodName].Caption = "消費税転嫁方式";

            dt.Columns.Add(Ct_CsLedgerBlance_AfCalDemandPrice, typeof(Int64)); // 計算後請求金額
            dt.Columns[Ct_CsLedgerBlance_AfCalDemandPrice].Caption = "計算後請求金額";

            dt.Columns.Add(Ct_CsLedgerBlance_AcpOdrTtl2TmBfBlDmd, typeof(Int64)); // 受注2回前残高（請求計）
            dt.Columns[Ct_CsLedgerBlance_AcpOdrTtl2TmBfBlDmd].Caption = "受注2回前残高（請求計）";

            dt.Columns.Add(Ct_CsLedgerBlance_AcpOdrTtl3TmBfBlDmd, typeof(Int64)); // 受注3回前残高（請求計）
            dt.Columns[Ct_CsLedgerBlance_AcpOdrTtl3TmBfBlDmd].Caption = "受注3回前残高（請求計）";

            dt.Columns.Add(Ct_CsLedgerBlance_CAddUpUpdExecDate, typeof(Int32)); // 締次更新実行年月日
            dt.Columns[Ct_CsLedgerBlance_CAddUpUpdExecDate].Caption = "締次更新実行年月日";

            dt.Columns.Add(Ct_CsLedgerBlance_CloseFlag, typeof(Int32)); // 請求処理通番
            dt.Columns[Ct_CsLedgerBlance_CloseFlag].Caption = "締済フラグ";

            dt.Columns.Add(Ct_CsLedgerBlance_StartDateSpan, typeof(Int32)); // 日付範囲（開始）
            dt.Columns[Ct_CsLedgerBlance_StartDateSpan].Caption = "日付範囲（開始）";

            dt.Columns.Add(Ct_CsLedgerBlance_EndDateSpan, typeof(Int32)); // 日付範囲（終了）
            dt.Columns[Ct_CsLedgerBlance_EndDateSpan].Caption = "日付範囲（終了）";

            dt.Columns.Add(Ct_CsLedgerBlance_ClaimCode, typeof(Int32)); // 請求先コード
            dt.Columns[Ct_CsLedgerBlance_ClaimCode].Caption = "請求先コード";

            dt.Columns.Add(Ct_CsLedgerBlance_CustomerCode, typeof(Int32)); // 得意先コード
            dt.Columns[Ct_CsLedgerBlance_CustomerCode].Caption = "得意先コード";

            dt.Columns.Add(Ct_CsLedgerBlance_Name, typeof(string)); // 得意先名称
            dt.Columns[Ct_CsLedgerBlance_Name].Caption = "得意先名称";

            dt.Columns.Add(Ct_CsLedgerBlance_Name2, typeof(string)); // 得意先名称2
            dt.Columns[Ct_CsLedgerBlance_Name2].Caption = "得意先名称2";
            #endregion

            ds.Tables.Add(dt);

            string sort = Ct_CsLedgerBlance_AddUpSecCode + "," + Ct_CsLedgerBlance_ClaimCode + "," + Ct_CsLedgerBlance_AddUpDate;

            _csLedgerBlanceDataTable = dt;
            _csLedgerBlanceDataView = new DataView(_csLedgerBlanceDataTable, string.Empty, sort, DataViewRowState.CurrentRows);
        }
        #endregion

        #endregion ■ Public Static Method

        #region ■ Private Static Method
        #region ◆ KingetCall
        #region ◎ 請求KINGETコール関数
        /// <summary>
		/// 請求KINGETコール関数
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
        /// <param name="startCustomerCode">開始得意先コード</param>
        /// <param name="endCustomerCode">終了得意先コード</param>
        /// <param name="stratdt">計上年月(開始)</param>
		/// <param name="enddt">計上年月(終了)</param>
		/// <param name="viewSectionCd">表示拠点コード</param>
		/// <param name="sectionCodeList">拠点コードリスト</param>
        /// <param name="outMoneyDiv">出力金額区分</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note        : 請求KINGETを呼出します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2009.01.21</br>
        /// <br>Note		: リモート側で一部機能(電子元帳用の処理)が削除された為、該当部分の処理を削除しました</br>
        /// <br>Note		: また、現在のリモートに合わせた処理に変更するため、別アクセスクラスで行っていた処理を</br>
        /// <br>Note		: 当クラスに移動しました</br>
        /// </remarks>
        private static int SeiKingetCall(string enterpriseCode, int customerCode, int startCustomerCode, int endCustomerCode, int stratdt, int enddt, string viewSectionCd, ArrayList sectionCodeList, int outMoneyDiv)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			ArrayList dmdprcList = null;
            Hashtable salesBTable = null;
            Hashtable salesHTable = null;
            Hashtable salesDTable = null;
            Hashtable depositHTable = null;

            // 全社を選択
            if ((sectionCodeList.Count == 1) && (sectionCodeList[0].ToString() == "0"))
            {
                sectionCodeList = null;
            }

			try
			{
				// 請求KINGETコール
				// 通常モード
                status = GetCustDmdPrcAcsSearch(out dmdprcList,
                    out salesBTable,
                    out salesHTable,
                    out salesDTable,
                    out depositHTable,
					enterpriseCode,
    				sectionCodeList,
					customerCode,
                    startCustomerCode,
                    endCustomerCode,
    				stratdt,
					enddt,
                    outMoneyDiv);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						{
								// 得意先情報設定           
								CustDmdPrcWorkToCustomer(enterpriseCode, dmdprcList);

								// 請求金額DataTable作成
								foreach (CustDmdPrcInfGetWork csdmd in dmdprcList)
								{
									DataRow row = CustDmdPrcWorkToDataRow(csdmd);
									_custDmdPrcDataTable.Rows.Add(row);
								}

								// 計上範囲設定
								SetCustomerAddUpDateSpanAndAddUpDate(customerCode, viewSectionCd);

								// 売上・入金・残高データテーブル設定
                                SalesAndDepsitToDataTable(salesBTable, salesHTable, salesDTable, depositHTable, viewSectionCd, false);

								// 入金ワークを内部保持用に設定
								foreach (DictionaryEntry entry in depositHTable)
								{
									ArrayList arDeposit = entry.Value as ArrayList;

									if (arDeposit != null)
									{
										foreach (LedgerDepsitMainWork wk in arDeposit)
										{
											if (wk != null)
											{
                                                string key = string.Empty;
                                                key = wk.AddUpSecCode + "_" + wk.ClaimCode.ToString() + "_" + wk.CustomerCode.ToString() + "_" + String.Format("{0:D9}", wk.DepositSlipNo);
                                                if (!_depsitHTable.ContainsKey(key))
                                                {
                                                    //DクラスからClone()メソッドが削除されたため、別の方法で実装
                                                    //(本当はDクラスに実装すべき処理)
                                                    //_depsitHTable.Add(key, wk.Clone());
                                                    LedgerDepsitMainWork wk2 = new LedgerDepsitMainWork();
                                                    wk2.AcptAnOdrStatus = wk.AcptAnOdrStatus;
                                                    wk2.AddUpADate = wk.AddUpADate;
                                                    wk2.AddUpSecCode = wk.AddUpSecCode.ToString();
                                                    wk2.ClaimCode = wk.ClaimCode;
                                                    wk2.ClaimName = wk.ClaimName.ToString();
                                                    wk2.ClaimName2 = wk.ClaimName2.ToString();
                                                    wk2.ClaimSnm = wk.ClaimSnm.ToString();
                                                    wk2.CustomerCode = wk.CustomerCode;
                                                    wk2.CustomerName = wk.CustomerName.ToString();
                                                    wk2.CustomerName2 = wk.CustomerName2.ToString();
                                                    wk2.CustomerSnm = wk.CustomerSnm.ToString();
                                                    wk2.Deposit = wk.Deposit;
                                                    wk2.DepositAgentCode = wk.DepositAgentCode.ToString();
                                                    wk2.DepositAgentNm = wk.DepositAgentNm.ToString();
                                                    wk2.DepositDate = wk.DepositDate;
                                                    wk2.DepositDebitNoteCd = wk.DepositDebitNoteCd;
                                                    wk2.DepositInputAgentCd = wk.DepositInputAgentCd.ToString();
                                                    wk2.DepositInputAgentNm = wk.DepositInputAgentNm.ToString();
                                                    wk2.DepositRowNo = wk.DepositRowNo;
                                                    wk2.DepositSlipNo = wk.DepositSlipNo;
                                                    wk2.EnterpriseCode = wk.EnterpriseCode.ToString();
                                                    wk2.InputDepositSecCd = wk.InputDepositSecCd.ToString();
                                                    wk2.MoneyKindCode = wk.MoneyKindCode;
                                                    wk2.MoneyKindDiv = wk.MoneyKindDiv;
                                                    wk2.MoneyKindName = wk.MoneyKindName.ToString();
                                                    wk2.Outline = wk.Outline.ToString();
                                                    wk2.SalesSlipNum = wk.SalesSlipNum.ToString();
                                                    wk2.UpdateSecCd = wk.UpdateSecCd.ToString();
                                                    wk2.ValidityTerm = wk.ValidityTerm;
                                                    _depsitHTable.Add(key, wk2);
                                                }
											}
										}
									}
								}
							break;
						}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						{
							break;
						}
					default:
						throw new CsLedgerException("請求情報の取得に失敗しました。", status);
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				throw new CsLedgerException(ex.Message, status);
			}

			return status;
		}
		#endregion
        /// <summary>
        /// 請求情報取得処理（計上年月範囲指定）
        /// </summary>
        /// <param name="custDmdPrcInfGetWorkList">得意先請求金額クラスワークリスト</param>
        /// <param name="ledgerSalesBlanceWorkHash">請求残高情報テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="ledgerSalesSlipWorkHash">請求情報テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="ledgerSalesDtlWorkHash">請求情報明細テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="ledgerDepsitMainWorkHash">入金情報テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCodeList">計上拠点コードリスト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="startCustomerCode">開始得意先コード</param>
        /// <param name="endCustomerCode">終了得意先コード</param>
        /// <param name="startAddUpYearMonth">計上年月（開始）(YYYYMM)</param>
        /// <param name="endAddUpYearMonth">計上年月（終了）(YYYYMM)</param>
        /// <param name="outMoneyDiv">出力金額区分</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 条件パラメータの内容で得意先請求情報を取得します。
        ///                : 主に得意先元帳にて使用します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.18</br>
        /// <br>Update Note: 2014/02/26 田建委</br>
        /// <br>           : Redmine#42188 出力金額区分追加</br>
        /// </remarks>
        private static int GetCustDmdPrcAcsSearch(out ArrayList custDmdPrcInfGetWorkList, out Hashtable ledgerSalesBlanceWorkHash, out Hashtable ledgerSalesSlipWorkHash, out Hashtable ledgerSalesDtlWorkHash, out Hashtable ledgerDepsitMainWorkHash,
            string enterpriseCode, ArrayList addUpSecCodeList, int customerCode, int startCustomerCode, int endCustomerCode, int startAddUpYearMonth, int endAddUpYearMonth, int outMoneyDiv)
        {
            // 請求情報取得抽出条件パラメータクラス生成
            CustDmdPrcInfSearchParameter parameter = new CustDmdPrcInfSearchParameter();
            parameter.EnterpriseCode = enterpriseCode;

            if (addUpSecCodeList != null)
            {
                parameter.AddUpSecCodeList = (string[])addUpSecCodeList.ToArray(typeof(string));
            }
            parameter.StartCustomerCode = startCustomerCode;
            parameter.EndCustomerCode = endCustomerCode;
            parameter.StartAddUpYearMonth = DateTime.ParseExact(startAddUpYearMonth.ToString(), "yyyyMM", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            parameter.EndAddUpYearMonth = DateTime.ParseExact(endAddUpYearMonth.ToString(), "yyyyMM", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            // 請求情報検索処理
            //return GetCustDmdPrcAcsSearchDB(out custDmdPrcInfGetWorkList, out ledgerSalesBlanceWorkHash, out ledgerSalesSlipWorkHash, out ledgerSalesDtlWorkHash, out ledgerDepsitMainWorkHash, parameter);// DEL 2014/02/26 田建委 Redmine#42188
            return GetCustDmdPrcAcsSearchDB(out custDmdPrcInfGetWorkList, out ledgerSalesBlanceWorkHash, out ledgerSalesSlipWorkHash, out ledgerSalesDtlWorkHash, out ledgerDepsitMainWorkHash, parameter, outMoneyDiv);// ADD 2014/02/26 田建委 Redmine#42188
        }

        /// <summary>
        /// 請求情報検索処理
        /// </summary>
        /// <param name="custDmdPrcInfGetWorkList">得意先請求金額クラスワークリスト</param>
        /// <param name="ledgerSalesBlanceWorkHash">残高情報テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="ledgerSalesSlipWorkHash">売上情報テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="ledgerSalesDtlWorkHash">売上明細情報テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="ledgerDepsitMainWorkHash">入金情報テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="parameter">請求情報取得抽出条件パラメータクラス</param>
        /// <param name="outMoneyDiv">outMoneyDiv</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 請求情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.18</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2009.01.21</br>
        /// <br>Update Note: 2014/02/26 田建委</br>
        /// <br>           : Redmine#42188 出力金額区分追加</br>
        /// <br>UpdateNote : 2015/09/21 田思春</br>
        /// <br>           : Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応</br> 
        /// </remarks>
        private static int GetCustDmdPrcAcsSearchDB(out ArrayList custDmdPrcInfGetWorkList, out Hashtable ledgerSalesBlanceWorkHash, out Hashtable ledgerSalesSlipWorkHash, out Hashtable ledgerSalesDtlWorkHash, out Hashtable ledgerDepsitMainWorkHash,
            //CustDmdPrcInfSearchParameter parameter)// DEL 2014/02/26 田建委 Redmine#42188
            CustDmdPrcInfSearchParameter parameter, int outMoneyDiv)// ADD 2014/02/26 田建委 Redmine#42188
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int status2 = (int)ConstantManagement.DB_Status.ctDB_EOF;
            custDmdPrcInfGetWorkList = null;
            ledgerSalesBlanceWorkHash = null;
            ledgerSalesSlipWorkHash = null;
            ledgerSalesDtlWorkHash = null;
            ledgerDepsitMainWorkHash = null;

            try
            {
                // リモート戻り値宣言
                object objCustDmdPrcInfGetWorkList = null;
                object objLedgerSalesSlipWorkList = null;
                object objLedgerSalesDtlWorkList = null;
                object objLedgerDepsitMainWorkList = null;
                object objCustDmdPrcInfGetWorkList2 = null;            //DMY
                object objLedgerDepsitMainWorkList2 = null;            //DMY

                // 請求情報取得処理
                status = _iCustDmdPrcInfGetDB.SearchSlip(out objCustDmdPrcInfGetWorkList, out objLedgerSalesSlipWorkList, out objLedgerDepsitMainWorkList, parameter);
                status2 = _iCustDmdPrcInfGetDB.SearchDtl(out objCustDmdPrcInfGetWorkList2, out objLedgerSalesDtlWorkList, out objLedgerDepsitMainWorkList2, parameter);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status2;

                // 取得したデータ
                custDmdPrcInfGetWorkList = objCustDmdPrcInfGetWorkList as ArrayList;
                ArrayList ledgerSalesBlanceWorkList = objCustDmdPrcInfGetWorkList as ArrayList;
                ArrayList ledgerSalesSlipWorkList = objLedgerSalesSlipWorkList as ArrayList;
                ArrayList ledgerSalesDtlWorkList = objLedgerSalesDtlWorkList as ArrayList;
                ArrayList ledgerDepsitMainWorkList = objLedgerDepsitMainWorkList as ArrayList;

                // 得意先請求金額情報リストが無い時は抜ける
                if (custDmdPrcInfGetWorkList == null) return status;

                ledgerSalesBlanceWorkHash = new Hashtable();
                ledgerSalesSlipWorkHash = new Hashtable();
                ledgerSalesDtlWorkHash = new Hashtable();
                ledgerDepsitMainWorkHash = new Hashtable();

                int ledgerSalesBlanceWorkCounter = 0;
                int ledgerSalesSlipWorkCounter = 0;
                int ledgerSalesDtlWorkCounter = 0;
                int ledgerDepsitMainWorkCounter = 0;

                // ---ADD 2014/02/26 田建委 Redmine#42188---->>>>>
                List<CustDmdPrcInfGetWork> custDmdPrcInfGetDelList = new List<CustDmdPrcInfGetWork>();

                bool salesSlipFlag = false;
                bool salesSalesDtl = false;
                bool salesDepsitMain = false;
                // ---ADD 2014/02/26 田建委 Redmine#42188----<<<<<

                // 取得した得意先請求金額情報リストをまわす
                foreach (CustDmdPrcInfGetWork custDmdPrcInfGetWork in custDmdPrcInfGetWorkList)
                {
                    // ---ADD 2014/02/26 田建委 Redmine#42188---->>>>>
                    salesSlipFlag = false;
                    salesSalesDtl = false;
                    salesDepsitMain = false;
                    // ---ADD 2014/02/26 田建委 Redmine#42188----<<<<<

                    // 残高情報を取得していて、戻り値リストに全て転記していない時
                    if ((ledgerSalesBlanceWorkList != null) && (ledgerSalesBlanceWorkList.Count > 0))
                    {
                        // 取得した残高データをまわす
                        foreach (CustDmdPrcInfGetWork ledgerSalesBlanceWork in ledgerSalesBlanceWorkList)
                        {
                            // 残高データの計上日付を取得                                
                            DateTime workAddUpADate = ledgerSalesBlanceWork.AddUpDate;

                            // 計上拠点が同一で、売上データの計上日付が得意先請求金額マスタの締日付範囲に入っている場合
                            if ((ledgerSalesBlanceWork.AddUpSecCode.TrimEnd() == custDmdPrcInfGetWork.AddUpSecCode.TrimEnd()) &&
                                (ledgerSalesBlanceWork.ClaimCode == custDmdPrcInfGetWork.ClaimCode) &&
                                (workAddUpADate >= custDmdPrcInfGetWork.LastCAddUpUpdDate) &&
                                (workAddUpADate <= custDmdPrcInfGetWork.AddUpDate))
                            {
                                int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custDmdPrcInfGetWork.AddUpDate);

                                // Hashtableに同一の計上日付が無い時は作成
                                if (!ledgerSalesBlanceWorkHash.Contains(addUpDate)) ledgerSalesBlanceWorkHash.Add(addUpDate, new ArrayList());

                                // 得意先請求金額マスタの計上年月日をKEYにしてHashtableに売上データをArrayListにしてぶら下げる
                                ArrayList list = (ArrayList)ledgerSalesBlanceWorkHash[addUpDate];
                                //DクラスからClone()メソッドが削除されたため、別の方法で実装
                                //(本当はDクラスに実装すべき処理)
                                //list.Add(ledgerSalesBlanceWork.Clone());
                                CustDmdPrcInfGetWork wk = new CustDmdPrcInfGetWork();
                                wk.AcpOdrTtl2TmBfBlDmd = ledgerSalesBlanceWork.AcpOdrTtl2TmBfBlDmd;
                                wk.AcpOdrTtl3TmBfBlDmd = ledgerSalesBlanceWork.AcpOdrTtl3TmBfBlDmd;
                                wk.AddUpDate = ledgerSalesBlanceWork.AddUpDate;
                                wk.AddUpSecCode = ledgerSalesBlanceWork.AddUpSecCode;
                                wk.AddUpYearMonth = ledgerSalesBlanceWork.AddUpYearMonth;
                                wk.AfCalDemandPrice = ledgerSalesBlanceWork.AfCalDemandPrice;
                                wk.BalanceAdjust = ledgerSalesBlanceWork.BalanceAdjust;
                                wk.CAddUpUpdExecDate = ledgerSalesBlanceWork.CAddUpUpdExecDate;
                                wk.ClaimCode = ledgerSalesBlanceWork.ClaimCode;
                                wk.ClaimName = ledgerSalesBlanceWork.ClaimName.ToString();
                                wk.ClaimName2 = ledgerSalesBlanceWork.ClaimName2.ToString();
                                wk.ClaimSnm = ledgerSalesBlanceWork.ClaimSnm.ToString();
                                wk.CloseFlg = ledgerSalesBlanceWork.CloseFlg;
                                wk.ConsTaxLayMethod = ledgerSalesBlanceWork.ConsTaxLayMethod;
                                wk.CustomerCode = ledgerSalesBlanceWork.CustomerCode;
                                wk.CustomerName = ledgerSalesBlanceWork.CustomerName.ToString();
                                wk.CustomerName2 = ledgerSalesBlanceWork.CustomerName2.ToString();
                                wk.CustomerSnm = ledgerSalesBlanceWork.CustomerSnm.ToString();
                                wk.EnterpriseCode = ledgerSalesBlanceWork.EnterpriseCode.ToString();
                                wk.LastCAddUpUpdDate = ledgerSalesBlanceWork.LastCAddUpUpdDate;
                                wk.LastTimeDemand = ledgerSalesBlanceWork.LastTimeDemand;
                                wk.OfsThisSalesTax = ledgerSalesBlanceWork.OfsThisSalesTax;
                                wk.OfsThisTimeSales = ledgerSalesBlanceWork.OfsThisTimeSales;
                                wk.ResultsSectCd = ledgerSalesBlanceWork.ResultsSectCd.ToString();
                                wk.SalesSlipCount = ledgerSalesBlanceWork.SalesSlipCount;
                                wk.StartCAddUpUpdDate = ledgerSalesBlanceWork.StartCAddUpUpdDate;
                                wk.TaxAdjust = ledgerSalesBlanceWork.TaxAdjust;
                                wk.ThisSalesPrcTaxDis = ledgerSalesBlanceWork.ThisSalesPrcTaxDis;
                                wk.ThisSalesPrcTaxRgds = ledgerSalesBlanceWork.ThisSalesPrcTaxRgds;
                                wk.ThisSalesPricDis = ledgerSalesBlanceWork.ThisSalesPricDis;
                                wk.ThisSalesPricRgds = ledgerSalesBlanceWork.ThisSalesPricRgds;
                                wk.ThisSalesTax = ledgerSalesBlanceWork.ThisSalesTax;
                                wk.ThisTimeDmdNrml = ledgerSalesBlanceWork.ThisTimeDmdNrml;
                                wk.ThisTimeSales = ledgerSalesBlanceWork.ThisTimeSales;
                                wk.ThisTimeTtlBlcDmd = ledgerSalesBlanceWork.ThisTimeTtlBlcDmd;
                                list.Add(wk);
                              
                                ledgerSalesBlanceWorkCounter++;
                            }
                        }
                    }

                    // 売上データを取得していて、戻り値リストに全て転記していない時
                    if ((ledgerSalesSlipWorkList != null) && (ledgerSalesSlipWorkList.Count > 0))
                    {
                        // 取得した売上データをまわす
                        foreach (ArrayList arrayList in ledgerSalesSlipWorkList)
                        {
                            foreach (LedgerSalesSlipWork ledgerSalesSlipWork in arrayList)
                            {
                                // 売上データの計上日付を取得
                                DateTime workAddUpADate = ledgerSalesSlipWork.AddUpADate;

                                // 計上拠点が同一で、売上データの計上日付が得意先請求金額マスタの締日付範囲に入っている場合
                                // ---------- DEL 2015/09/21 田思春 For Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応 ---------->>>>>
                                //if ((ledgerSalesSlipWork.DemandAddUpSecCd.TrimEnd() == custDmdPrcInfGetWork.AddUpSecCode.TrimEnd()) &&
                                //    (ledgerSalesSlipWork.ClaimCode == custDmdPrcInfGetWork.ClaimCode) &&
                                // ---------- DEL 2015/09/21 田思春 For Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応 ----------<<<<<
                                if ((ledgerSalesSlipWork.ClaimCode == custDmdPrcInfGetWork.ClaimCode) &&            // ADD 2015/09/21 田思春 For Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応
                                    (workAddUpADate >= custDmdPrcInfGetWork.LastCAddUpUpdDate) &&
                                    (workAddUpADate <= custDmdPrcInfGetWork.AddUpDate))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custDmdPrcInfGetWork.AddUpDate);

                                    // Hashtableに同一の計上日付が無い時は作成
                                    if (!ledgerSalesSlipWorkHash.Contains(addUpDate)) ledgerSalesSlipWorkHash.Add(addUpDate, new ArrayList());

                                    // 得意先請求金額マスタの計上年月日をKEYにしてHashtableに売上データをArrayListにしてぶら下げる
                                    ArrayList list = (ArrayList)ledgerSalesSlipWorkHash[addUpDate];
                                    //DクラスからClone()メソッドが削除されたため、別の方法で実装
                                    //(本当はDクラスに実装すべき処理)
                                    //list.Add(ledgerSalesSlipWork.Clone());
                                    LedgerSalesSlipWork wk = new LedgerSalesSlipWork();
                                    wk.AccRecDivCd = ledgerSalesSlipWork.AccRecDivCd;
                                    wk.AcptAnOdrStatus = ledgerSalesSlipWork.AcptAnOdrStatus;
                                    wk.AddUpADate = ledgerSalesSlipWork.AddUpADate;
                                    wk.ClaimCode = ledgerSalesSlipWork.ClaimCode;
                                    wk.ClaimSnm = ledgerSalesSlipWork.ClaimSnm.ToString();
                                    wk.CustomerCode = ledgerSalesSlipWork.CustomerCode;
                                    wk.CustomerName = ledgerSalesSlipWork.CustomerName.ToString();
                                    wk.CustomerName2 = ledgerSalesSlipWork.CustomerName2.ToString();
                                    wk.CustomerSnm = ledgerSalesSlipWork.CustomerSnm.ToString();
                                    wk.DebitNLnkSalesSlNum = ledgerSalesSlipWork.DebitNLnkSalesSlNum.ToString();
                                    wk.DebitNoteDiv = ledgerSalesSlipWork.DebitNoteDiv;
                                    wk.DemandAddUpSecCd = ledgerSalesSlipWork.DemandAddUpSecCd.ToString();
                                    wk.EnterpriseCode = ledgerSalesSlipWork.EnterpriseCode.ToString();
                                    wk.FrontEmployeeCd = ledgerSalesSlipWork.FrontEmployeeCd.ToString();
                                    wk.FrontEmployeeNm = ledgerSalesSlipWork.FrontEmployeeNm.ToString();
                                    wk.HonorificTitle = ledgerSalesSlipWork.HonorificTitle.ToString();
                                    wk.InputAgenCd = ledgerSalesSlipWork.InputAgenCd.ToString();
                                    wk.InputAgenNm = ledgerSalesSlipWork.InputAgenNm.ToString();
                                    wk.PartySaleSlipNum = ledgerSalesSlipWork.PartySaleSlipNum.ToString();
                                    wk.ResultsAddUpSecCd = ledgerSalesSlipWork.ResultsAddUpSecCd.ToString();
                                    wk.SalesDate = ledgerSalesSlipWork.SalesDate;
                                    wk.SalesEmployeeCd = ledgerSalesSlipWork.SalesEmployeeCd.ToString();
                                    wk.SalesEmployeeNm = ledgerSalesSlipWork.SalesEmployeeNm.ToString();
                                    wk.SalesGoodsCd = ledgerSalesSlipWork.SalesGoodsCd;
                                    wk.SalesInpSecCd = ledgerSalesSlipWork.SalesInpSecCd.ToString();
                                    wk.SalesInputCode = ledgerSalesSlipWork.SalesInputCode.ToString();
                                    wk.SalesInputName = ledgerSalesSlipWork.SalesInputName.ToString();
                                    wk.SalesSlipCd = ledgerSalesSlipWork.SalesSlipCd;
                                    wk.SalesSlipNum = ledgerSalesSlipWork.SalesSlipNum.ToString();
                                    wk.SalesSubtotalTax = ledgerSalesSlipWork.SalesSubtotalTax;
                                    wk.SalesSubtotalTaxExc = ledgerSalesSlipWork.SalesSubtotalTaxExc;
                                    wk.SalesSubtotalTaxInc = ledgerSalesSlipWork.SalesSubtotalTaxInc;
                                    wk.SearchSlipDate = ledgerSalesSlipWork.SearchSlipDate;
                                    wk.SectionCode = ledgerSalesSlipWork.SectionCode.ToString();
                                    wk.ShipmentDay = ledgerSalesSlipWork.ShipmentDay;
                                    wk.SlipNote = ledgerSalesSlipWork.SlipNote.ToString();
                                    wk.SlipNote2 = ledgerSalesSlipWork.SlipNote2.ToString();
                                    wk.SlipNote3 = ledgerSalesSlipWork.SlipNote3.ToString();
                                    wk.UoeRemark1 = ledgerSalesSlipWork.UoeRemark1.ToString();
                                    wk.UoeRemark2 = ledgerSalesSlipWork.UoeRemark2.ToString();
                                    wk.UpdateSecCd = ledgerSalesSlipWork.UpdateSecCd.ToString();
                                    // 2009.02.25 30413 犬飼 消費税転嫁方式の追加 >>>>>>START
                                    wk.ConsTaxLayMethod = ledgerSalesSlipWork.ConsTaxLayMethod;
                                    // 2009.02.25 30413 犬飼 消費税転嫁方式の追加 <<<<<<END
                                    // 2009.03.02 30413 犬飼 売上伝票合計（税抜き）の追加 >>>>>>START
                                    wk.SalesTotalTaxExc = ledgerSalesSlipWork.SalesTotalTaxExc;
                                    // 2009.03.02 30413 犬飼 売上伝票合計（税抜き）の追加 <<<<<<END
                                    list.Add(wk);
                                    ledgerSalesSlipWorkCounter++;
                                    salesSlipFlag = true;// ADD 2014/02/26 田建委 Redmine#42188
                                }
                            }
                        }
                    }

                    // 売上明細データを取得していて、戻り値リストに全て転記していない時
                    if ((ledgerSalesDtlWorkList != null) && (ledgerSalesDtlWorkList.Count > 0))
                    {
                        // 取得した売上データをまわす
                        foreach (ArrayList arrayList in ledgerSalesDtlWorkList)
                        {
                            foreach (LedgerSalesDetailWork ledgerSalesDtlWork in arrayList)
                            {
                                // 売上データの計上日付を取得
                                DateTime workAddUpADate = ledgerSalesDtlWork.AddUpADate;

                                // 計上拠点が同一で、売上データの計上日付が得意先請求金額マスタの締日付範囲に入っている場合
                                // ---------- DEL 2015/09/21 田思春 For Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応 ---------->>>>>
                                //if ((ledgerSalesDtlWork.DemandAddUpSecCd.TrimEnd() == custDmdPrcInfGetWork.AddUpSecCode.TrimEnd()) &&
                                //    (ledgerSalesDtlWork.ClaimCode == custDmdPrcInfGetWork.ClaimCode) &&
                                // ---------- DEL 2015/09/21 田思春 For Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応 ----------<<<<<
                                if ((ledgerSalesDtlWork.ClaimCode == custDmdPrcInfGetWork.ClaimCode) &&       // ADD 2015/09/21 田思春 For Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応         
                                    (workAddUpADate >= custDmdPrcInfGetWork.LastCAddUpUpdDate) &&
                                    (workAddUpADate <= custDmdPrcInfGetWork.AddUpDate))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custDmdPrcInfGetWork.AddUpDate);

                                    // Hashtableに同一の計上日付が無い時は作成
                                    if (!ledgerSalesDtlWorkHash.Contains(addUpDate)) ledgerSalesDtlWorkHash.Add(addUpDate, new ArrayList());

                                    // 得意先請求金額マスタの計上年月日をKEYにしてHashtableに売上データをArrayListにしてぶら下げる
                                    ArrayList list = (ArrayList)ledgerSalesDtlWorkHash[addUpDate];
                                    //DクラスからClone()メソッドが削除されたため、別の方法で実装
                                    //(本当はDクラスに実装すべき処理)
                                    //list.Add(ledgerSalesDtlWork.Clone());
                                    LedgerSalesDetailWork wk = new LedgerSalesDetailWork();
                                    wk.AccRecDivCd = ledgerSalesDtlWork.AccRecDivCd;
                                    wk.AcptAnOdrStatus = ledgerSalesDtlWork.AcptAnOdrStatus;
                                    wk.AddUpADate = ledgerSalesDtlWork.AddUpADate;
                                    wk.ClaimCode = ledgerSalesDtlWork.ClaimCode;
                                    wk.ClaimSnm = ledgerSalesDtlWork.ClaimSnm.ToString();
                                    wk.CommonSeqNo = ledgerSalesDtlWork.CommonSeqNo;
                                    wk.CustomerCode = ledgerSalesDtlWork.CustomerCode;
                                    wk.CustomerName = ledgerSalesDtlWork.CustomerName.ToString();
                                    wk.CustomerName2 = ledgerSalesDtlWork.CustomerName2.ToString();
                                    wk.CustomerSnm = ledgerSalesDtlWork.CustomerSnm.ToString();
                                    wk.DebitNLnkSalesSlNum = ledgerSalesDtlWork.DebitNLnkSalesSlNum.ToString();
                                    wk.DebitNoteDiv = ledgerSalesDtlWork.DebitNoteDiv;
                                    wk.DemandAddUpSecCd = ledgerSalesDtlWork.DemandAddUpSecCd.ToString();
                                    wk.EnterpriseCode = ledgerSalesDtlWork.EnterpriseCode.ToString();
                                    wk.FrontEmployeeCd = ledgerSalesDtlWork.FrontEmployeeCd.ToString();
                                    wk.FrontEmployeeNm = ledgerSalesDtlWork.FrontEmployeeNm.ToString();
                                    wk.GoodsName = ledgerSalesDtlWork.GoodsName.ToString();
                                    wk.GoodsNameKana = ledgerSalesDtlWork.GoodsNameKana.ToString();
                                    wk.GoodsNo = ledgerSalesDtlWork.GoodsNo.ToString();
                                    wk.HonorificTitle = ledgerSalesDtlWork.HonorificTitle.ToString();
                                    wk.InputAgenCd = ledgerSalesDtlWork.InputAgenCd.ToString();
                                    wk.InputAgenNm = ledgerSalesDtlWork.InputAgenNm.ToString();
                                    wk.PartySaleSlipNum = ledgerSalesDtlWork.PartySaleSlipNum.ToString();
                                    wk.ResultsAddUpSecCd = ledgerSalesDtlWork.ResultsAddUpSecCd.ToString();
                                    wk.SalesDate = ledgerSalesDtlWork.SalesDate;
                                    wk.SalesEmployeeCd = ledgerSalesDtlWork.SalesEmployeeCd.ToString();
                                    wk.SalesEmployeeNm = ledgerSalesDtlWork.SalesEmployeeNm.ToString();
                                    wk.SalesGoodsCd = ledgerSalesDtlWork.SalesGoodsCd;
                                    wk.SalesInpSecCd = ledgerSalesDtlWork.SalesInpSecCd.ToString();
                                    wk.SalesInputCode = ledgerSalesDtlWork.SalesInputCode.ToString();
                                    wk.SalesInputName = ledgerSalesDtlWork.SalesInputName.ToString();
                                    wk.SalesMoneyTaxExc = ledgerSalesDtlWork.SalesMoneyTaxExc;
                                    wk.SalesPriceConsTax = ledgerSalesDtlWork.SalesPriceConsTax;
                                    wk.SalesRowDerivNo = ledgerSalesDtlWork.SalesRowDerivNo;
                                    wk.SalesRowNo = ledgerSalesDtlWork.SalesRowNo;
                                    wk.SalesSlipCd = ledgerSalesDtlWork.SalesSlipCd;
                                    wk.SalesSlipDtlNum = ledgerSalesDtlWork.SalesSlipDtlNum;
                                    wk.SalesSlipNum = ledgerSalesDtlWork.SalesSlipNum.ToString();
                                    wk.SalesSubtotalTax = ledgerSalesDtlWork.SalesSubtotalTax;
                                    wk.SalesSubtotalTaxExc = ledgerSalesDtlWork.SalesSubtotalTaxExc;
                                    wk.SalesSubtotalTaxInc = ledgerSalesDtlWork.SalesSubtotalTaxInc;
                                    wk.SalesUnPrcTaxExcFl = ledgerSalesDtlWork.SalesUnPrcTaxExcFl;
                                    wk.SearchSlipDate = ledgerSalesDtlWork.SearchSlipDate;
                                    wk.SectionCode = ledgerSalesDtlWork.SectionCode.ToString();
                                    wk.ShipmentCnt = ledgerSalesDtlWork.ShipmentCnt;
                                    wk.ShipmentDay = ledgerSalesDtlWork.ShipmentDay;
                                    wk.SlipNote = ledgerSalesDtlWork.SlipNote.ToString();
                                    wk.SlipNote2 = ledgerSalesDtlWork.SlipNote2.ToString();
                                    wk.SlipNote3 = ledgerSalesDtlWork.SlipNote3.ToString();
                                    wk.SupplierCd = ledgerSalesDtlWork.SupplierCd;
                                    wk.SupplierSnm = ledgerSalesDtlWork.SupplierSnm.ToString();
                                    wk.UoeRemark1 = ledgerSalesDtlWork.UoeRemark1.ToString();
                                    wk.UoeRemark2 = ledgerSalesDtlWork.UoeRemark2.ToString();
                                    wk.UpdateSecCd = ledgerSalesDtlWork.UpdateSecCd.ToString();
                                    // 2009.02.25 30413 犬飼 消費税転嫁方式の追加 >>>>>>START
                                    wk.ConsTaxLayMethod = ledgerSalesDtlWork.ConsTaxLayMethod;
                                    wk.TaxationDivCd = ledgerSalesDtlWork.TaxationDivCd;
                                    // 2009.02.25 30413 犬飼 消費税転嫁方式の追加 <<<<<<END
                                    list.Add(wk);
                                    ledgerSalesDtlWorkCounter++;
                                    salesSalesDtl = true;// ADD 2014/02/26 田建委 Redmine#42188
                                }
                            }
                        }
                    }

                    // 入金データを取得していて、戻り値リストに全て転記していない時
                    if ((ledgerDepsitMainWorkList != null) && (ledgerDepsitMainWorkList.Count > 0))
                    {
                        // 取得した入金データをまわす
                        foreach (ArrayList arrayList in ledgerDepsitMainWorkList)
                        {
                            foreach (LedgerDepsitMainWork ledgerDepsitMainWork in arrayList)
                            {
                                // 入金データの計上日付を取得
                                DateTime workAddUpADate = ledgerDepsitMainWork.AddUpADate;

                                // 計上拠点が同一で、入金データの計上日付が得意先請求金額マスタの締日付範囲に入っている場合
                                if ((ledgerDepsitMainWork.AddUpSecCode.TrimEnd() == custDmdPrcInfGetWork.AddUpSecCode.TrimEnd()) &&
                                    (ledgerDepsitMainWork.ClaimCode == custDmdPrcInfGetWork.ClaimCode) &&
                                    (workAddUpADate >= custDmdPrcInfGetWork.LastCAddUpUpdDate) &&
                                    (workAddUpADate <= custDmdPrcInfGetWork.AddUpDate))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custDmdPrcInfGetWork.AddUpDate);

                                    // Hashtableに同一の計上日付が無い時は作成
                                    if (!ledgerDepsitMainWorkHash.Contains(addUpDate)) ledgerDepsitMainWorkHash.Add(addUpDate, new ArrayList());

                                    // 得意先請求金額マスタの計上年月日をKEYにしてHashtableに入金データをArrayListにしてぶら下げる
                                    ArrayList list = (ArrayList)ledgerDepsitMainWorkHash[addUpDate];
                                    //DクラスからClone()メソッドが削除されたため、別の方法で実装
                                    //(本当はDクラスに実装すべき処理)
                                    //list.Add(ledgerDepsitMainWork.Clone());
                                    LedgerDepsitMainWork wk2 = new LedgerDepsitMainWork();
                                    wk2.AcptAnOdrStatus = ledgerDepsitMainWork.AcptAnOdrStatus;
                                    wk2.AddUpADate = ledgerDepsitMainWork.AddUpADate;
                                    wk2.AddUpSecCode = ledgerDepsitMainWork.AddUpSecCode.ToString();
                                    wk2.ClaimCode = ledgerDepsitMainWork.ClaimCode;
                                    wk2.ClaimName = ledgerDepsitMainWork.ClaimName.ToString();
                                    wk2.ClaimName2 = ledgerDepsitMainWork.ClaimName2.ToString();
                                    wk2.ClaimSnm = ledgerDepsitMainWork.ClaimSnm.ToString();
                                    wk2.CustomerCode = ledgerDepsitMainWork.CustomerCode;
                                    wk2.CustomerName = ledgerDepsitMainWork.CustomerName.ToString();
                                    wk2.CustomerName2 = ledgerDepsitMainWork.CustomerName2.ToString();
                                    wk2.CustomerSnm = ledgerDepsitMainWork.CustomerSnm.ToString();
                                    wk2.Deposit = ledgerDepsitMainWork.Deposit;
                                    wk2.DepositAgentCode = ledgerDepsitMainWork.DepositAgentCode.ToString();
                                    wk2.DepositAgentNm = ledgerDepsitMainWork.DepositAgentNm.ToString();
                                    wk2.DepositDate = ledgerDepsitMainWork.DepositDate;
                                    wk2.DepositDebitNoteCd = ledgerDepsitMainWork.DepositDebitNoteCd;
                                    wk2.DepositInputAgentCd = ledgerDepsitMainWork.DepositInputAgentCd.ToString();
                                    wk2.DepositInputAgentNm = ledgerDepsitMainWork.DepositInputAgentNm.ToString();
                                    wk2.DepositRowNo = ledgerDepsitMainWork.DepositRowNo;
                                    wk2.DepositSlipNo = ledgerDepsitMainWork.DepositSlipNo;
                                    wk2.EnterpriseCode = ledgerDepsitMainWork.EnterpriseCode.ToString();
                                    wk2.InputDepositSecCd = ledgerDepsitMainWork.InputDepositSecCd.ToString();
                                    wk2.MoneyKindCode = ledgerDepsitMainWork.MoneyKindCode;
                                    wk2.MoneyKindDiv = ledgerDepsitMainWork.MoneyKindDiv;
                                    wk2.MoneyKindName = ledgerDepsitMainWork.MoneyKindName.ToString();
                                    wk2.Outline = ledgerDepsitMainWork.Outline.ToString();
                                    wk2.SalesSlipNum = ledgerDepsitMainWork.SalesSlipNum.ToString();
                                    wk2.UpdateSecCd = ledgerDepsitMainWork.UpdateSecCd.ToString();
                                    wk2.ValidityTerm = ledgerDepsitMainWork.ValidityTerm;
                                    list.Add(wk2);
                                    ledgerDepsitMainWorkCounter++;
                                    salesDepsitMain = true;// ADD 2014/02/26 田建委 Redmine#42188
                                }
                            }
                        }
                    }

                    // -----ADD 2014/02/26 田建委 Redmine#42188 ----->>>>>
                    if (salesSlipFlag == false
                      && salesSalesDtl == false
                      && salesDepsitMain == false
                      && outMoneyDiv == 1
                      && custDmdPrcInfGetWork.LastTimeDemand == 0         // 前回請求金額
                      && custDmdPrcInfGetWork.AcpOdrTtl2TmBfBlDmd == 0    // 受注2回前残高（請求計）
                      && custDmdPrcInfGetWork.AcpOdrTtl3TmBfBlDmd == 0)   // 受注3回前残高（請求計）
                    {
                        custDmdPrcInfGetDelList.Add(custDmdPrcInfGetWork);
                    }
                    // -----ADD 2014/02/26 田建委 Redmine#42188 -----<<<<<
                }

                // -----ADD 2014/02/26 田建委 Redmine#42188 ------------------------->>>>>
                if (outMoneyDiv == 0) return status;
                // 全て金額0の場合、印刷しない
                foreach (CustDmdPrcInfGetWork wkCustDmdPrcInfGet in custDmdPrcInfGetDelList)
                {

                    if (custDmdPrcInfGetWorkList.Contains(wkCustDmdPrcInfGet))
                    {
                        custDmdPrcInfGetWorkList.Remove(wkCustDmdPrcInfGet);
                    }
                }

                // 全てデータフィルタした後、戻るステータスも変更する
                if (custDmdPrcInfGetWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                // -----ADD 2014/02/26 田建委 Redmine#42188 -------------------------<<<<<

                return status;
            }
            catch (Exception e)
            {
                custDmdPrcInfGetWorkList = null;
                ledgerSalesBlanceWorkHash = null;
                ledgerSalesSlipWorkHash = null;
                ledgerSalesDtlWorkHash = null;
                ledgerDepsitMainWorkHash = null;
                _iCustDmdPrcInfGetDB = null;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                throw new CsLedgerException(e.Message, status);

            }
        }

        #region ◎ 売掛KINGETコール関数
		/// <summary>
		/// 売掛KINGETコール関数
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
        /// <param name="startCustomerCode">開始得意先コード</param>
        /// <param name="endCustomerCode">終了得意先コード</param>
        /// <param name="stratdt">計上年月(開始)</param>
		/// <param name="enddt">計上年月(終了)</param>
		/// <param name="viewSectionCd">表示拠点コード</param>
		/// <param name="sectionCodeList">拠点コードリスト</param>
        /// <param name="outMoneyDiv">出力金額区分</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note        : 売掛KINGETを呼出します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
        /// <br>Programer	: 30009 渋谷 大輔</br>
        /// <br>Date		: 2009.01.21</br>
        /// <br>Note		: リモート側で一部機能(電子元帳用の処理)が削除された為、該当部分の処理を削除しました</br>
        /// <br>Note		: また、現在のリモートに合わせた処理に変更するため、別アクセスクラスで行っていた処理を</br>
        /// <br>Note		: 当クラスに移動しました</br>
        /// </remarks>
        private static int UriKingetCall(string enterpriseCode, int customerCode, int startCustomerCode, int endCustomerCode, int stratdt, int enddt, string viewSectionCd, ArrayList sectionCodeList, int outMoneyDiv)
        {
		    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

		    ArrayList accRecList = null;
            Hashtable salesBTable = null;
            Hashtable salesHTable = null;
            Hashtable salesDTable = null;
            Hashtable depositHTable = null;

            // 全社を選択
            if ((sectionCodeList.Count == 1) && (sectionCodeList[0].ToString() == "0"))
            {
                sectionCodeList = null;
            }

		    try
		    {
		        // 売掛KINGETコール
                status = getCustAccRecAcsSearch(out accRecList,
                out salesBTable,
                        out salesHTable,
                        out salesDTable,
                        out depositHTable,
   						enterpriseCode,
						sectionCodeList,
						customerCode,
                        startCustomerCode,
                        endCustomerCode,
						stratdt,
						enddt,
                        outMoneyDiv);
		        switch (status)
		        {
		            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
		                {
								// 得意先情報設定           
								CustAccRecWorkToCustomer(enterpriseCode, accRecList);

								// 請求金額DataTable作成
								foreach ( CustAccRecInfGetWork csAccRec in accRecList )
								{
								    DataRow row = CustAccRecWorkToDataRow(csAccRec);
								    _custDmdPrcDataTable.Rows.Add(row);
								}

								// 計上範囲設定
								SetCustomerAddUpDateSpanAndAddUpDate(customerCode, viewSectionCd);

								// 売上・入金データテーブル設定
                                SalesAndDepsitToDataTable(salesBTable, salesHTable, salesDTable, depositHTable, viewSectionCd, false);

								// 入金ワークを内部保持用に設定
								foreach ( DictionaryEntry entry in depositHTable )
								{
									ArrayList arDeposit = entry.Value as ArrayList;

									if ( arDeposit != null )
									{
										foreach ( LedgerDepsitMainWork wk in arDeposit )
										{
											if ( wk != null )
											{
                                                string key = string.Empty;
                                                key = wk.AddUpSecCode + "_" + wk.ClaimCode.ToString() + "_" + wk.CustomerCode.ToString() + "_" + String.Format("{0:D9}", wk.DepositSlipNo);
                                                if (!_depsitHTable.ContainsKey(key))
                                                {    
                                                    //DクラスからClone()メソッドが削除されたため、別の方法で実装
                                                    //(本当はDクラスに実装すべき処理)
                                                    //_depsitHTable.Add(key, wk.Clone());
                                                    LedgerDepsitMainWork wk2 = new LedgerDepsitMainWork();
                                                    wk2.AcptAnOdrStatus = wk.AcptAnOdrStatus;
                                                    wk2.AddUpADate = wk.AddUpADate;
                                                    wk2.AddUpSecCode = wk.AddUpSecCode.ToString();
                                                    wk2.ClaimCode = wk.ClaimCode;
                                                    wk2.ClaimName = wk.ClaimName.ToString();
                                                    wk2.ClaimName2 = wk.ClaimName2.ToString();
                                                    wk2.ClaimSnm = wk.ClaimSnm.ToString();
                                                    wk2.CustomerCode = wk.CustomerCode;
                                                    wk2.CustomerName = wk.CustomerName.ToString();
                                                    wk2.CustomerName2 = wk.CustomerName2.ToString();
                                                    wk2.CustomerSnm = wk.CustomerSnm.ToString();
                                                    wk2.Deposit = wk.Deposit;
                                                    wk2.DepositAgentCode = wk.DepositAgentCode.ToString();
                                                    wk2.DepositAgentNm = wk.DepositAgentNm.ToString();
                                                    wk2.DepositDate = wk.DepositDate;
                                                    wk2.DepositDebitNoteCd = wk.DepositDebitNoteCd;
                                                    wk2.DepositInputAgentCd = wk.DepositInputAgentCd.ToString();
                                                    wk2.DepositInputAgentNm = wk.DepositInputAgentNm.ToString();
                                                    wk2.DepositRowNo = wk.DepositRowNo;
                                                    wk2.DepositSlipNo = wk.DepositSlipNo;
                                                    wk2.EnterpriseCode = wk.EnterpriseCode.ToString();
                                                    wk2.InputDepositSecCd = wk.InputDepositSecCd.ToString();
                                                    wk2.MoneyKindCode = wk.MoneyKindCode;
                                                    wk2.MoneyKindDiv = wk.MoneyKindDiv;
                                                    wk2.MoneyKindName = wk.MoneyKindName.ToString();
                                                    wk2.Outline = wk.Outline.ToString();
                                                    wk2.SalesSlipNum = wk.SalesSlipNum.ToString();
                                                    wk2.UpdateSecCd = wk.UpdateSecCd.ToString();
                                                    wk2.ValidityTerm = wk.ValidityTerm;
                                                    _depsitHTable.Add(key, wk2);

                                                }
											}
										}
									}
								}
		                    break;
		                }
		            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
		            case (int)ConstantManagement.DB_Status.ctDB_EOF:
		                {
		                    break;
		                }
		            default:
		                throw new CsLedgerException("売掛情報の取得に失敗しました。", status);
		        }
		    }
            // --- ADD 2014/02/20 T.Miyamoto ------------------------------>>>>>
            catch (CsLedgerException ex)
            {
                throw new CsLedgerException(ex.Message, ex.Status);
            }
            // --- ADD 2014/02/20 T.Miyamoto ------------------------------<<<<<
		    catch ( Exception ex )
		    {
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
		        throw new CsLedgerException(ex.Message, status);
		    }
		    return status;
		}
		#endregion

        /// <summary>
        /// 売掛情報取得処理（計上年月範囲指定）
        /// </summary>
        /// <param name="custAccRecInfGetWorkList">得意先売掛金額クラスワークリスト</param>
        /// <param name="ledgerSalesBlanceWorkHash">売掛残高情報テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="ledgerSalesSlipWorkHash">売掛情報テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="ledgerSalesDtlWorkHash">売掛情報テーブル(明細)(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="ledgerDepsitMainWorkHash">入金情報テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="addUpSecCodeList">計上拠点コードリスト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="startCustomerCode">開始得意先コード</param>
        /// <param name="endCustomerCode">終了得意先コード</param>
        /// <param name="startAddUpYearMonth">計上年月（開始）(YYYYMM)</param>
        /// <param name="endAddUpYearMonth">計上年月（終了）(YYYYMM)</param>
        /// <param name="outMoneyDiv">出力金額区分</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 条件パラメータの内容で得意先売掛情報を取得します。
        ///                : 主に得意先元帳にて使用します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.18</br>
        /// <br>Update Note: 2014/02/26 田建委</br>
        /// <br>           : Redmine#42188 出力金額区分追加</br>
        /// </remarks>
        private static int getCustAccRecAcsSearch(out ArrayList custAccRecInfGetWorkList, out Hashtable ledgerSalesBlanceWorkHash, out Hashtable ledgerSalesSlipWorkHash, out Hashtable ledgerSalesDtlWorkHash, out Hashtable ledgerDepsitMainWorkHash,
            string enterpriseCode, ArrayList addUpSecCodeList, int customerCode, int startCustomerCode, int endCustomerCode, int startAddUpYearMonth, int endAddUpYearMonth, int outMoneyDiv)
        {
            // 売掛情報取得抽出条件パラメータクラス生成
            CustAccRecInfSearchParameter parameter = new CustAccRecInfSearchParameter();
            parameter.EnterpriseCode = enterpriseCode;
            if (addUpSecCodeList != null)
            {
                parameter.AddUpSecCodeList = (string[])addUpSecCodeList.ToArray(typeof(string));
            }
            parameter.StartCustomerCode = startCustomerCode;
            parameter.EndCustomerCode = endCustomerCode;
            parameter.StartAddUpYearMonth = DateTime.ParseExact(startAddUpYearMonth.ToString(), "yyyyMM", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            parameter.EndAddUpYearMonth = DateTime.ParseExact(endAddUpYearMonth.ToString(), "yyyyMM", System.Globalization.DateTimeFormatInfo.InvariantInfo);
  
            // 売掛情報検索処理
            //return getCustAccRecAcsSearchDB(out custAccRecInfGetWorkList, out ledgerSalesBlanceWorkHash, out ledgerSalesSlipWorkHash, out ledgerSalesDtlWorkHash, out ledgerDepsitMainWorkHash, parameter);// DEL 2014/02/27 鄧潘ハン
            return getCustAccRecAcsSearchDB(out custAccRecInfGetWorkList, out ledgerSalesBlanceWorkHash, out ledgerSalesSlipWorkHash, out ledgerSalesDtlWorkHash, out ledgerDepsitMainWorkHash, parameter, outMoneyDiv);// ADD 2014/02/27 鄧潘ハン
        }

        /// <summary>
        /// 売掛情報検索処理
        /// </summary>
        /// <param name="custAccRecInfGetWorkList">得意先売掛金額クラスワークリスト</param>
        /// <param name="ledgerSalesBlanceWorkHash">売上残高情報テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="ledgerSalesSlipWorkHash">売上情報テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="ledgerSalesDtlWorkHash">売上明細情報テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="ledgerDepsitMainWorkHash">入金情報テーブル(HashTable[計上年月日]->ArrayList)</param>
        /// <param name="parameter">売掛情報取得抽出条件パラメータクラス</param>
        /// <param name="outMoneyDiv">出力金額区分</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 売掛情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.18</br>
        /// <br>Update Note: 2014/02/26 田建委</br>
        /// <br>           : Redmine#42188 出力金額区分追加</br>
        /// <br>UpdateNote : 2015/09/21 田思春</br>
        /// <br>           : Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応</br> 
        /// </remarks>
        private static int getCustAccRecAcsSearchDB(out ArrayList custAccRecInfGetWorkList, out Hashtable ledgerSalesBlanceWorkHash, out Hashtable ledgerSalesSlipWorkHash, out Hashtable ledgerSalesDtlWorkHash, out Hashtable ledgerDepsitMainWorkHash,
            //CustAccRecInfSearchParameter parameter)// DEL 2014/02/27 鄧潘ハン
            CustAccRecInfSearchParameter parameter, int outMoneyDiv)// ADD 2014/02/27 鄧潘ハン
        {
            // 戻り値の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int status2 = (int)ConstantManagement.DB_Status.ctDB_EOF;
            custAccRecInfGetWorkList = null;
            ledgerSalesBlanceWorkHash = null;
            ledgerSalesSlipWorkHash = null;
            ledgerDepsitMainWorkHash = null;
            ledgerSalesDtlWorkHash = null;

            try
            {
                // リモート戻り値宣言
                object objCustAccRecInfGetWorkList = null;
                object objLedgerSalesSlipWorkList = null;
                object objLedgerDepsitMainWorkList = null;
                object objLedgerSalesDtlWorkList = null;
                object objCustAccRecInfGetWorkList2 = null;            //DMY
                object objLedgerDepsitMainWorkList2 = null;            //DMY

                // 売掛情報取得処理
                // --- UPD 2014/02/20 T.Miyamoto ------------------------------>>>>>
                //status = _iCustAccRecInfGetDB.SearchSlip(out objCustAccRecInfGetWorkList, out objLedgerSalesSlipWorkList, out objLedgerDepsitMainWorkList, parameter);
                //status2 = _iCustAccRecInfGetDB.SearchDtl(out objCustAccRecInfGetWorkList2, out objLedgerSalesDtlWorkList, out objLedgerDepsitMainWorkList2, parameter);
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                //if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                status = _iCustAccRecInfGetDB.SearchSlip(out objCustAccRecInfGetWorkList, out objLedgerSalesSlipWorkList, out objLedgerDepsitMainWorkList, parameter);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                status2 = _iCustAccRecInfGetDB.SearchDtl(out objCustAccRecInfGetWorkList2, out objLedgerSalesDtlWorkList, out objLedgerDepsitMainWorkList2, parameter);
                if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status2;
                // --- UPD 2014/02/20 T.Miyamoto ------------------------------<<<<<

                // 取得したデータ
                custAccRecInfGetWorkList = objCustAccRecInfGetWorkList as ArrayList;
                ArrayList ledgerSalesBlanceWorkList = objCustAccRecInfGetWorkList as ArrayList;
                ArrayList ledgerSalesSlipWorkList = objLedgerSalesSlipWorkList as ArrayList;
                ArrayList ledgerSalesDtlWorkList = objLedgerSalesDtlWorkList as ArrayList;
                ArrayList ledgerDepsitMainWorkList = objLedgerDepsitMainWorkList as ArrayList;

                // 得意先売掛金額情報リストが無い時は抜ける
                if (custAccRecInfGetWorkList == null) return status;

                ledgerSalesBlanceWorkHash = new Hashtable();
                ledgerSalesSlipWorkHash = new Hashtable();
                ledgerSalesDtlWorkHash = new Hashtable();
                ledgerDepsitMainWorkHash = new Hashtable();

                int ledgerSalesBlanceWorkCounter = 0;
                int ledgerSalesSlipWorkCounter = 0;
                int ledgerSalesDtlWorkCounter = 0;
                int ledgerDepsitMainWorkCounter = 0;

                // ---ADD 2014/02/26 田建委 Redmine#42188---->>>>>
                List<CustAccRecInfGetWork> custAccRecInfGetDelList = new List<CustAccRecInfGetWork>();

                bool salesSlipFlag = false;
                bool salesSalesDtl = false;
                bool salesDepsitMain = false;
                // ---ADD 2014/02/26 田建委 Redmine#42188----<<<<<

                // 取得した得意先売掛金額情報リストをまわす
                foreach (CustAccRecInfGetWork custAccRecInfGetWork in custAccRecInfGetWorkList)
                {
                    // ---ADD 2014/02/26 田建委 Redmine#42188---->>>>>
                    salesSlipFlag = false;
                    salesSalesDtl = false;
                    salesDepsitMain = false;
                    // ---ADD 2014/02/26 田建委 Redmine#42188----<<<<<

                    // 残高データを取得していて、戻り値リストに全て転記していない時
                    if ((ledgerSalesBlanceWorkList != null) && (ledgerSalesBlanceWorkList.Count > 0))
                    {
                        // 取得した残高データをまわす
                        foreach (CustAccRecInfGetWork ledgerSalesBlanceWork in ledgerSalesBlanceWorkList)
                        {
                            // 残高データの計上日付を取得
                            DateTime workAddUpADate = ledgerSalesBlanceWork.AddUpDate;

                            // 計上拠点が同一で、売上データの計上日付が得意先売掛金額マスタの締日付範囲に入っている場合
                            if ((ledgerSalesBlanceWork.AddUpSecCode.TrimEnd() == custAccRecInfGetWork.AddUpSecCode.TrimEnd()) &&
                                (ledgerSalesBlanceWork.ClaimCode == custAccRecInfGetWork.ClaimCode) &&
                                (workAddUpADate >= custAccRecInfGetWork.StMonCAddUpUpdDate) &&
                                (workAddUpADate <= custAccRecInfGetWork.AddUpDate))
                            {
                                int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custAccRecInfGetWork.AddUpDate);

                                // Hashtableに同一の計上日付が無い時は作成
                                if (!ledgerSalesBlanceWorkHash.Contains(addUpDate)) ledgerSalesBlanceWorkHash.Add(addUpDate, new ArrayList());

                                // 得意先売掛金額マスタの計上年月日をKEYにしてHashtableに売上データをArrayListにしてぶら下げる
                                ArrayList list = (ArrayList)ledgerSalesBlanceWorkHash[addUpDate];
                                //DクラスからClone()メソッドが削除されたため、別の方法で実装
                                //(本当はDクラスに実装すべき処理)
                                //list.Add(ledgerSalesBlanceWork.Clone());
                                CustAccRecInfGetWork wk = new CustAccRecInfGetWork();
                                wk.AcpOdrTtl2TmBfAccRec = ledgerSalesBlanceWork.AcpOdrTtl2TmBfAccRec;
                                wk.AcpOdrTtl3TmBfAccRec = ledgerSalesBlanceWork.AcpOdrTtl3TmBfAccRec;
                                wk.AddUpDate = ledgerSalesBlanceWork.AddUpDate;
                                wk.AddUpSecCode = ledgerSalesBlanceWork.AddUpSecCode.ToString();
                                wk.AddUpYearMonth = ledgerSalesBlanceWork.AddUpYearMonth;
                                wk.AfCalTMonthAccRec = ledgerSalesBlanceWork.AfCalTMonthAccRec;
                                wk.BalanceAdjust = ledgerSalesBlanceWork.BalanceAdjust;
                                wk.ClaimCode = ledgerSalesBlanceWork.ClaimCode;
                                wk.ClaimName = ledgerSalesBlanceWork.ClaimName.ToString();
                                wk.ClaimName2 = ledgerSalesBlanceWork.ClaimName2.ToString();
                                wk.ClaimSnm = ledgerSalesBlanceWork.ClaimSnm.ToString();
                                wk.CloseFlg = wk.CloseFlg;
                                wk.ConsTaxLayMethod = ledgerSalesBlanceWork.ConsTaxLayMethod;
                                wk.CustomerCode = ledgerSalesBlanceWork.CustomerCode;
                                wk.CustomerName = ledgerSalesBlanceWork.CustomerName.ToString();
                                wk.CustomerName2 = ledgerSalesBlanceWork.CustomerName2.ToString();
                                wk.CustomerSnm = ledgerSalesBlanceWork.CustomerSnm.ToString();
                                wk.EnterpriseCode = ledgerSalesBlanceWork.EnterpriseCode.ToString();
                                wk.LaMonCAddUpUpdDate = ledgerSalesBlanceWork.LaMonCAddUpUpdDate;
                                wk.LastTimeAccRec = ledgerSalesBlanceWork.LastTimeAccRec;
                                wk.MonthAddUpExpDate = ledgerSalesBlanceWork.MonthAddUpExpDate;
                                wk.OfsThisSalesTax = ledgerSalesBlanceWork.OfsThisSalesTax;
                                wk.OfsThisTimeSales = ledgerSalesBlanceWork.OfsThisTimeSales;
                                wk.SalesSlipCount = ledgerSalesBlanceWork.SalesSlipCount;
                                wk.StMonCAddUpUpdDate = ledgerSalesBlanceWork.StMonCAddUpUpdDate;
                                wk.TaxAdjust = ledgerSalesBlanceWork.TaxAdjust;
                                wk.ThisSalesPrcTaxDis = ledgerSalesBlanceWork.ThisSalesPrcTaxDis;
                                wk.ThisSalesPrcTaxRgds = ledgerSalesBlanceWork.ThisSalesPrcTaxRgds;
                                wk.ThisSalesPricDis = ledgerSalesBlanceWork.ThisSalesPricDis;
                                wk.ThisSalesPricRgds = ledgerSalesBlanceWork.ThisSalesPricRgds;
                                wk.ThisSalesTax = ledgerSalesBlanceWork.ThisSalesTax;
                                wk.ThisTimeDmdNrml = ledgerSalesBlanceWork.ThisTimeDmdNrml;
                                wk.ThisTimeSales = ledgerSalesBlanceWork.ThisTimeSales;
                                wk.ThisTimeTtlBlcAcc = ledgerSalesBlanceWork.ThisTimeTtlBlcAcc;
                                list.Add(wk);
                                ledgerSalesBlanceWorkCounter++;
                            }
                        }
                    }

                    // 売上データを取得していて、戻り値リストに全て転記していない時
                    if ((ledgerSalesSlipWorkList != null) && (ledgerSalesSlipWorkList.Count > 0))
                    {
                        // 取得した売上データをまわす
                        foreach (ArrayList arrayList in ledgerSalesSlipWorkList)
                        {
                            foreach (LedgerSalesSlipWork ledgerSalesSlipWork in arrayList)
                            {
                                // 売上データの計上日付を取得
                                DateTime workAddUpADate = ledgerSalesSlipWork.AddUpADate;

                                // 計上拠点が同一で、売上データの計上日付が得意先売掛金額マスタの締日付範囲に入っている場合
                                // ---------- DEL 2015/09/21 田思春 For Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応 ---------->>>>>
                                //if ((ledgerSalesSlipWork.DemandAddUpSecCd.TrimEnd() == custAccRecInfGetWork.AddUpSecCode.TrimEnd()) &&
                                //    (ledgerSalesSlipWork.ClaimCode == custAccRecInfGetWork.ClaimCode) &&
                                // ---------- DEL 2015/09/21 田思春 For Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応 ----------<<<<<
                                if ((ledgerSalesSlipWork.ClaimCode == custAccRecInfGetWork.ClaimCode) &&     // ADD 2015/09/21 田思春 For Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応
                                    (workAddUpADate >= custAccRecInfGetWork.StMonCAddUpUpdDate) &&
                                    (workAddUpADate <= custAccRecInfGetWork.AddUpDate))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custAccRecInfGetWork.AddUpDate);

                                    // Hashtableに同一の計上日付が無い時は作成
                                    if (!ledgerSalesSlipWorkHash.Contains(addUpDate)) ledgerSalesSlipWorkHash.Add(addUpDate, new ArrayList());

                                    // 得意先売掛金額マスタの計上年月日をKEYにしてHashtableに売上データをArrayListにしてぶら下げる
                                    ArrayList list = (ArrayList)ledgerSalesSlipWorkHash[addUpDate];
                                    //DクラスからClone()メソッドが削除されたため、別の方法で実装
                                    //(本当はDクラスに実装すべき処理)
                                    //list.Add(ledgerSalesSlipWork.Clone());
                                    LedgerSalesSlipWork wk = new LedgerSalesSlipWork();
                                    wk.AccRecDivCd = ledgerSalesSlipWork.AccRecDivCd;
                                    wk.AcptAnOdrStatus = ledgerSalesSlipWork.AcptAnOdrStatus;
                                    wk.AddUpADate = ledgerSalesSlipWork.AddUpADate;
                                    wk.ClaimCode = ledgerSalesSlipWork.ClaimCode;
                                    wk.ClaimSnm = ledgerSalesSlipWork.ClaimSnm.ToString();
                                    wk.CustomerCode = ledgerSalesSlipWork.CustomerCode;
                                    wk.CustomerName = ledgerSalesSlipWork.CustomerName.ToString();
                                    wk.CustomerName2 = ledgerSalesSlipWork.CustomerName2.ToString();
                                    wk.CustomerSnm = ledgerSalesSlipWork.CustomerSnm.ToString();
                                    wk.DebitNLnkSalesSlNum = ledgerSalesSlipWork.DebitNLnkSalesSlNum.ToString();
                                    wk.DebitNoteDiv = ledgerSalesSlipWork.DebitNoteDiv;
                                    wk.DemandAddUpSecCd = ledgerSalesSlipWork.DemandAddUpSecCd.ToString();
                                    wk.EnterpriseCode = ledgerSalesSlipWork.EnterpriseCode.ToString();
                                    wk.FrontEmployeeCd = ledgerSalesSlipWork.FrontEmployeeCd.ToString();
                                    wk.FrontEmployeeNm = ledgerSalesSlipWork.FrontEmployeeNm.ToString();
                                    wk.HonorificTitle = ledgerSalesSlipWork.HonorificTitle.ToString();
                                    wk.InputAgenCd = ledgerSalesSlipWork.InputAgenCd.ToString();
                                    wk.InputAgenNm = ledgerSalesSlipWork.InputAgenNm.ToString();
                                    wk.PartySaleSlipNum = ledgerSalesSlipWork.PartySaleSlipNum.ToString();
                                    wk.ResultsAddUpSecCd = ledgerSalesSlipWork.ResultsAddUpSecCd.ToString();
                                    wk.SalesDate = ledgerSalesSlipWork.SalesDate;
                                    wk.SalesEmployeeCd = ledgerSalesSlipWork.SalesEmployeeCd.ToString();
                                    wk.SalesEmployeeNm = ledgerSalesSlipWork.SalesEmployeeNm.ToString();
                                    wk.SalesGoodsCd = ledgerSalesSlipWork.SalesGoodsCd;
                                    wk.SalesInpSecCd = ledgerSalesSlipWork.SalesInpSecCd.ToString();
                                    wk.SalesInputCode = ledgerSalesSlipWork.SalesInputCode.ToString();
                                    wk.SalesInputName = ledgerSalesSlipWork.SalesInputName.ToString();
                                    wk.SalesSlipCd = ledgerSalesSlipWork.SalesSlipCd;
                                    wk.SalesSlipNum = ledgerSalesSlipWork.SalesSlipNum.ToString();
                                    wk.SalesSubtotalTax = ledgerSalesSlipWork.SalesSubtotalTax;
                                    wk.SalesSubtotalTaxExc = ledgerSalesSlipWork.SalesSubtotalTaxExc;
                                    wk.SalesSubtotalTaxInc = ledgerSalesSlipWork.SalesSubtotalTaxInc;
                                    wk.SearchSlipDate = ledgerSalesSlipWork.SearchSlipDate;
                                    wk.SectionCode = ledgerSalesSlipWork.SectionCode.ToString();
                                    wk.ShipmentDay = ledgerSalesSlipWork.ShipmentDay;
                                    wk.SlipNote = ledgerSalesSlipWork.SlipNote.ToString();
                                    wk.SlipNote2 = ledgerSalesSlipWork.SlipNote2.ToString();
                                    wk.SlipNote3 = ledgerSalesSlipWork.SlipNote3.ToString();
                                    wk.UoeRemark1 = ledgerSalesSlipWork.UoeRemark1.ToString();
                                    wk.UoeRemark2 = ledgerSalesSlipWork.UoeRemark2.ToString();
                                    wk.UpdateSecCd = ledgerSalesSlipWork.UpdateSecCd.ToString();
                                    // 2009.02.25 30413 犬飼 消費税転嫁方式の追加 >>>>>>START
                                    wk.ConsTaxLayMethod = ledgerSalesSlipWork.ConsTaxLayMethod;
                                    // 2009.02.25 30413 犬飼 消費税転嫁方式の追加 <<<<<<END
                                    // 2009.03.02 30413 犬飼 売上伝票合計（税抜き）の追加 >>>>>>START
                                    wk.SalesTotalTaxExc = ledgerSalesSlipWork.SalesTotalTaxExc;
                                    // 2009.03.02 30413 犬飼 売上伝票合計（税抜き）の追加 <<<<<<END
                                    list.Add(wk);
                                    ledgerSalesSlipWorkCounter++;
                                    salesSlipFlag = true;// ADD 2014/02/26 田建委 Redmine#42188
                                }
                            }
                        }
                    }

                    // 売上明細データを取得していて、戻り値リストに全て転記していない時
                    if ((ledgerSalesDtlWorkList != null) && (ledgerSalesDtlWorkList.Count > 0))
                    {
                        // 取得した売上データをまわす
                        foreach (ArrayList arrayList in ledgerSalesDtlWorkList)
                        {
                            foreach (LedgerSalesDetailWork ledgerSalesDtlWork in arrayList)
                            {
                                // 売上データの計上日付を取得
                                DateTime workAddUpADate = ledgerSalesDtlWork.AddUpADate;

                                // 計上拠点が同一で、売上データの計上日付が得意先売掛金額マスタの締日付範囲に入っている場合
                                // ---------- DEL 2015/09/21 田思春 For Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応 ---------->>>>>
                                //if ((ledgerSalesDtlWork.DemandAddUpSecCd.TrimEnd() == custAccRecInfGetWork.AddUpSecCode.TrimEnd()) &&
                                //    (ledgerSalesDtlWork.ClaimCode == custAccRecInfGetWork.ClaimCode) &&
                                // ---------- DEL 2015/09/21 田思春 For Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応 ----------<<<<<
                                if ((ledgerSalesDtlWork.ClaimCode == custAccRecInfGetWork.ClaimCode) &&       // ADD 2015/09/21 田思春 For Redmine#47031 得意先元帳の明細部に得意先子の明細が印字されないの障害対応
                                    (workAddUpADate >= custAccRecInfGetWork.StMonCAddUpUpdDate) &&
                                    (workAddUpADate <= custAccRecInfGetWork.AddUpDate))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custAccRecInfGetWork.AddUpDate);

                                    // Hashtableに同一の計上日付が無い時は作成
                                    if (!ledgerSalesDtlWorkHash.Contains(addUpDate)) ledgerSalesDtlWorkHash.Add(addUpDate, new ArrayList());

                                    // 得意先売掛金額マスタの計上年月日をKEYにしてHashtableに売上データをArrayListにしてぶら下げる
                                    ArrayList list = (ArrayList)ledgerSalesDtlWorkHash[addUpDate];
                                    //DクラスからClone()メソッドが削除されたため、別の方法で実装
                                    //(本当はDクラスに実装すべき処理)
                                    //list.Add(ledgerSalesDtlWork.Clone());
                                    LedgerSalesDetailWork wk = new LedgerSalesDetailWork();
                                    wk.AccRecDivCd = ledgerSalesDtlWork.AccRecDivCd;
                                    wk.AcptAnOdrStatus = ledgerSalesDtlWork.AcptAnOdrStatus;
                                    wk.AddUpADate = ledgerSalesDtlWork.AddUpADate;
                                    wk.ClaimCode = ledgerSalesDtlWork.ClaimCode;
                                    wk.ClaimSnm = ledgerSalesDtlWork.ClaimSnm.ToString();
                                    wk.CommonSeqNo = ledgerSalesDtlWork.CommonSeqNo;
                                    wk.CustomerCode = ledgerSalesDtlWork.CustomerCode;
                                    wk.CustomerName = ledgerSalesDtlWork.CustomerName.ToString();
                                    wk.CustomerName2 = ledgerSalesDtlWork.CustomerName2.ToString();
                                    wk.CustomerSnm = ledgerSalesDtlWork.CustomerSnm.ToString();
                                    wk.DebitNLnkSalesSlNum = ledgerSalesDtlWork.DebitNLnkSalesSlNum.ToString();
                                    wk.DebitNoteDiv = ledgerSalesDtlWork.DebitNoteDiv;
                                    wk.DemandAddUpSecCd = ledgerSalesDtlWork.DemandAddUpSecCd.ToString();
                                    wk.EnterpriseCode = ledgerSalesDtlWork.EnterpriseCode.ToString();
                                    wk.FrontEmployeeCd = ledgerSalesDtlWork.FrontEmployeeCd.ToString();
                                    wk.FrontEmployeeNm = ledgerSalesDtlWork.FrontEmployeeNm.ToString();
                                    wk.GoodsName = ledgerSalesDtlWork.GoodsName.ToString();
                                    wk.GoodsNameKana = ledgerSalesDtlWork.GoodsNameKana.ToString();
                                    wk.GoodsNo = ledgerSalesDtlWork.GoodsNo.ToString();
                                    wk.HonorificTitle = ledgerSalesDtlWork.HonorificTitle.ToString();
                                    wk.InputAgenCd = ledgerSalesDtlWork.InputAgenCd.ToString();
                                    wk.InputAgenNm = ledgerSalesDtlWork.InputAgenNm.ToString();
                                    wk.PartySaleSlipNum = ledgerSalesDtlWork.PartySaleSlipNum.ToString();
                                    wk.ResultsAddUpSecCd = ledgerSalesDtlWork.ResultsAddUpSecCd.ToString();
                                    wk.SalesDate = ledgerSalesDtlWork.SalesDate;
                                    wk.SalesEmployeeCd = ledgerSalesDtlWork.SalesEmployeeCd.ToString();
                                    wk.SalesEmployeeNm = ledgerSalesDtlWork.SalesEmployeeNm.ToString();
                                    wk.SalesGoodsCd = ledgerSalesDtlWork.SalesGoodsCd;
                                    wk.SalesInpSecCd = ledgerSalesDtlWork.SalesInpSecCd.ToString();
                                    wk.SalesInputCode = ledgerSalesDtlWork.SalesInputCode.ToString();
                                    wk.SalesInputName = ledgerSalesDtlWork.SalesInputName.ToString();
                                    wk.SalesMoneyTaxExc = ledgerSalesDtlWork.SalesMoneyTaxExc;
                                    wk.SalesPriceConsTax = ledgerSalesDtlWork.SalesPriceConsTax;
                                    wk.SalesRowDerivNo = ledgerSalesDtlWork.SalesRowDerivNo;
                                    wk.SalesRowNo = ledgerSalesDtlWork.SalesRowNo;
                                    wk.SalesSlipCd = ledgerSalesDtlWork.SalesSlipCd;
                                    wk.SalesSlipDtlNum = ledgerSalesDtlWork.SalesSlipDtlNum;
                                    wk.SalesSlipNum = ledgerSalesDtlWork.SalesSlipNum.ToString();
                                    wk.SalesSubtotalTax = ledgerSalesDtlWork.SalesSubtotalTax;
                                    wk.SalesSubtotalTaxExc = ledgerSalesDtlWork.SalesSubtotalTaxExc;
                                    wk.SalesSubtotalTaxInc = ledgerSalesDtlWork.SalesSubtotalTaxInc;
                                    wk.SalesUnPrcTaxExcFl = ledgerSalesDtlWork.SalesUnPrcTaxExcFl;
                                    wk.SearchSlipDate = ledgerSalesDtlWork.SearchSlipDate;
                                    wk.SectionCode = ledgerSalesDtlWork.SectionCode.ToString();
                                    wk.ShipmentCnt = ledgerSalesDtlWork.ShipmentCnt;
                                    wk.ShipmentDay = ledgerSalesDtlWork.ShipmentDay;
                                    wk.SlipNote = ledgerSalesDtlWork.SlipNote.ToString();
                                    wk.SlipNote2 = ledgerSalesDtlWork.SlipNote2.ToString();
                                    wk.SlipNote3 = ledgerSalesDtlWork.SlipNote3.ToString();
                                    wk.SupplierCd = ledgerSalesDtlWork.SupplierCd;
                                    wk.SupplierSnm = ledgerSalesDtlWork.SupplierSnm.ToString();
                                    wk.UoeRemark1 = ledgerSalesDtlWork.UoeRemark1.ToString();
                                    wk.UoeRemark2 = ledgerSalesDtlWork.UoeRemark2.ToString();
                                    wk.UpdateSecCd = ledgerSalesDtlWork.UpdateSecCd.ToString();
                                    // 2009.02.25 30413 犬飼 消費税転嫁方式の追加 >>>>>>START
                                    wk.ConsTaxLayMethod = ledgerSalesDtlWork.ConsTaxLayMethod;
                                    wk.TaxationDivCd = ledgerSalesDtlWork.TaxationDivCd;
                                    // 2009.02.25 30413 犬飼 消費税転嫁方式の追加 <<<<<<END
                                    list.Add(wk);
                                    ledgerSalesDtlWorkCounter++;
                                    salesSalesDtl = false;// ADD 2014/02/26 田建委 Redmine#42188
                                }
                            }
                        }
                    }

                    // 入金データを取得していて、戻り値リストに全て転記していない時
                    if ((ledgerDepsitMainWorkList != null) && (ledgerDepsitMainWorkList.Count > 0))
                    {
                        // 取得した入金データをまわす
                        foreach (ArrayList arrayList in ledgerDepsitMainWorkList)
                        {
                            foreach (LedgerDepsitMainWork ledgerDepsitMainWork in arrayList)
                            {
                                // 入金データの計上日付を取得
                                DateTime workAddUpADate = ledgerDepsitMainWork.AddUpADate;

                                // 計上拠点が同一で、入金データの計上日付が得意先売掛金額マスタの締日付範囲に入っている場合
                                if ((ledgerDepsitMainWork.AddUpSecCode.TrimEnd() == custAccRecInfGetWork.AddUpSecCode.TrimEnd()) &&
                                    (ledgerDepsitMainWork.ClaimCode == custAccRecInfGetWork.ClaimCode) &&
                                    (workAddUpADate >= custAccRecInfGetWork.StMonCAddUpUpdDate) &&
                                    (workAddUpADate <= custAccRecInfGetWork.AddUpDate))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custAccRecInfGetWork.AddUpDate);

                                    // Hashtableに同一の計上日付が無い時は作成
                                    if (!ledgerDepsitMainWorkHash.Contains(addUpDate)) ledgerDepsitMainWorkHash.Add(addUpDate, new ArrayList());

                                    // 得意先売掛金額マスタの計上年月日をKEYにしてHashtableに入金データをArrayListにしてぶら下げる
                                    ArrayList list = (ArrayList)ledgerDepsitMainWorkHash[addUpDate];
                                    //DクラスからClone()メソッドが削除されたため、別の方法で実装
                                    //(本当はDクラスに実装すべき処理)
                                    //list.Add(ledgerDepsitMainWork.Clone());
                                    LedgerDepsitMainWork wk = new LedgerDepsitMainWork();
                                    wk.AcptAnOdrStatus = ledgerDepsitMainWork.AcptAnOdrStatus;
                                    wk.AddUpADate = ledgerDepsitMainWork.AddUpADate;
                                    wk.AddUpSecCode = ledgerDepsitMainWork.AddUpSecCode.ToString();
                                    wk.ClaimCode = ledgerDepsitMainWork.ClaimCode;
                                    wk.ClaimName = ledgerDepsitMainWork.ClaimName.ToString();
                                    wk.ClaimName2 = ledgerDepsitMainWork.ClaimName2.ToString();
                                    wk.ClaimSnm = ledgerDepsitMainWork.ClaimSnm.ToString();
                                    wk.CustomerCode = ledgerDepsitMainWork.CustomerCode;
                                    wk.CustomerName = ledgerDepsitMainWork.CustomerName.ToString();
                                    wk.CustomerName2 = ledgerDepsitMainWork.CustomerName2.ToString();
                                    wk.CustomerSnm = ledgerDepsitMainWork.CustomerSnm.ToString();
                                    wk.Deposit = ledgerDepsitMainWork.Deposit;
                                    wk.DepositAgentCode = ledgerDepsitMainWork.DepositAgentCode.ToString();
                                    wk.DepositAgentNm = ledgerDepsitMainWork.DepositAgentNm.ToString();
                                    wk.DepositDate = ledgerDepsitMainWork.DepositDate;
                                    wk.DepositDebitNoteCd = ledgerDepsitMainWork.DepositDebitNoteCd;
                                    wk.DepositInputAgentCd = ledgerDepsitMainWork.DepositInputAgentCd.ToString();
                                    wk.DepositInputAgentNm = ledgerDepsitMainWork.DepositInputAgentNm.ToString();
                                    wk.DepositRowNo = ledgerDepsitMainWork.DepositRowNo;
                                    wk.DepositSlipNo = ledgerDepsitMainWork.DepositSlipNo;
                                    wk.EnterpriseCode = ledgerDepsitMainWork.EnterpriseCode.ToString();
                                    wk.InputDepositSecCd = ledgerDepsitMainWork.InputDepositSecCd.ToString();
                                    wk.MoneyKindCode = ledgerDepsitMainWork.MoneyKindCode;
                                    wk.MoneyKindDiv = ledgerDepsitMainWork.MoneyKindDiv;
                                    wk.MoneyKindName = ledgerDepsitMainWork.MoneyKindName.ToString();
                                    wk.Outline = ledgerDepsitMainWork.Outline.ToString();
                                    wk.SalesSlipNum = ledgerDepsitMainWork.SalesSlipNum.ToString();
                                    wk.UpdateSecCd = ledgerDepsitMainWork.UpdateSecCd.ToString();
                                    wk.ValidityTerm = ledgerDepsitMainWork.ValidityTerm;
                                    list.Add(wk);
                                    ledgerDepsitMainWorkCounter++;
                                    salesDepsitMain = false;// ADD 2014/02/26 田建委 Redmine#42188
                                }
                            }
                        }
                    }
                    // ---ADD 2014/02/26 田建委 Redmine#42188 ------>>>>>
                    if (salesSlipFlag == false
                     && salesSalesDtl == false
                     && salesDepsitMain == false
                     && outMoneyDiv == 1
                     && custAccRecInfGetWork.LastTimeAccRec == 0         // 前回売掛金額
                     && custAccRecInfGetWork.AcpOdrTtl2TmBfAccRec == 0   // 受注2回前残高（売掛計）
                     && custAccRecInfGetWork.AcpOdrTtl3TmBfAccRec == 0)  // 受注3回前残高（売掛計）
                    {
                        custAccRecInfGetDelList.Add(custAccRecInfGetWork);
                    }
                    // ---ADD 2014/02/26 田建委 Redmine#42188 ------<<<<<
                }
                // ---ADD 2014/02/26 田建委 Redmine#42188 ------>>>>>
                if (outMoneyDiv == 0) return status;
                // 全て金額0の場合、印刷しない
                foreach (CustAccRecInfGetWork wkCustAccRecInfGet in custAccRecInfGetDelList)
                {

                    if (custAccRecInfGetWorkList.Contains(wkCustAccRecInfGet))
                    {
                        custAccRecInfGetWorkList.Remove(wkCustAccRecInfGet);
                    }
                }

                // 全てデータフィルタした後、戻るステータスも変更する
                if (custAccRecInfGetWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                // ---ADD 2014/02/26 田建委 Redmine#42188 ------<<<<<

                return status;
            }
            catch (Exception e)
            {
                custAccRecInfGetWorkList = null;
                ledgerSalesBlanceWorkHash = null;
                ledgerSalesSlipWorkHash = null;
                ledgerSalesDtlWorkHash = null;
                ledgerDepsitMainWorkHash = null;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                throw new CsLedgerException(e.Message, status);
            }
        }


		#region ◎ 売上・入金データ元帳照会明細テーブル設定処理
		/// <summary>
		/// 売上・入金データ元帳照会明細テーブル設定処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note        : 売上・入金リストより元帳照会明細テーブルに明細を設定します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
        private static void SalesAndDepsitToDataTable(Hashtable salesBTable, Hashtable salesHTable, Hashtable salesDTable, Hashtable depsitHTable, string viewSecCd, bool isNotCloseOnly)
		{
			if (_custDmdPrcDataView.Count != 0)
			{
				// 拠点別に前回残高行・繰越残高行を作成する 
				for (int i = 0; i < _custDmdPrcDataView.Count; i++)
				{
					// DataRow → 請求金額クラス
					CsLedgerDmdPrc dmdPrc = DataRowToCsLedgerDmdPrc(_custDmdPrcDataView[i].Row);

					CsLedgerCustomer csLedgerCustomer = 
						(CsLedgerCustomer)_csLedgerCustomerHTable[
							dmdPrc.ClaimCode.ToString() + "_" +
							TDateTime.DateTimeToLongDate( dmdPrc.AddUpDate ).ToString() + "_" +
							dmdPrc.AddUpSecCode];

					// KEY情報の設定
					int keyDate = TDateTime.DateTimeToLongDate(dmdPrc.AddUpDate);
					string addUpSecCd = dmdPrc.AddUpSecCode;

					// 前回残高が有る場合前回残高行作成
					if (dmdPrc.LastTimeDemand != 0)
					{
					    
                        if ( isNotCloseOnly )
						{
						}
						else
						{
                            //通常Searchで未締データの場合に初期状態で前回残高行は作成しない
							if ( dmdPrc.CloseFlag == (int)CloseFlagState.Close )
							{
								// 前回残高行作成
								_csLedgerSlipDataTable.Rows.Add(
								MakingBalanceDataRow( (int)LedgerDtlBalanseState.Balance, dmdPrc, addUpSecCd, keyDate));
							}
						}
					}

                    // 請求単位の場合
   					if ( csLedgerCustomer.CustTaxLayCd == 2 )
                    {                       
                        if(isNotCloseOnly)
                        {
                        }
                        else
                        {
                            // 売上伝票が存在する、もしくは入金金額がある(期首残は枚数カウント無しのため)
					        if ((dmdPrc.SlipCount > 0) || (dmdPrc.ThisTimeDmdNrml != 0))
					        {
								// 締済のときだけ消費税行作成
								if ( dmdPrc.CloseFlag == (int)CloseFlagState.Close )
								{
									// 消費税行作成
									_csLedgerSlipDataTable.Rows.Add(MakingBalanceDataRow((int)LedgerDtlBalanseState.ConsTax, dmdPrc, addUpSecCd, keyDate));
								}
					        }
                        }                      
                    }
                  
                    // 繰越残高行作成処理
                    //未締データか？
                    if(isNotCloseOnly)
                    { 
                    }
                    else
                    {
                        //通常Searchで未締データの場合に初期状態で前回残高行は作成しない
						if ( dmdPrc.CloseFlag == (int)CloseFlagState.Close )
						{
							//締済データ
							// 繰越残高行作成
							_csLedgerSlipDataTable.Rows.Add(MakingBalanceDataRow((int)LedgerDtlBalanseState.Others, dmdPrc, addUpSecCd, keyDate));
						}
                    }
 
                }
				// 売上・入金明細行を作成する
                SettingDataCsLedgerTable(salesBTable, salesHTable, salesDTable, depsitHTable);
			}
		}
		#endregion

		#region ◎ 繰越残高行作成
		/// <summary>
		/// 繰越残高行作成
		/// </summary>
		/// <param name="makeMode">[0:繰越残高,1:前回残高]</param>
		/// <param name="csLedgerDmdPrc">得意先クラス</param>
		/// <param name="addUpSecCd">請求計上拠点コード</param>
		/// <param name="addUpDate">計上年月日</param>
		/// <remarks>
		/// <br>Note       : 拠点毎に繰越残高行を作成します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static DataRow MakingBalanceDataRow(int makeMode, CsLedgerDmdPrc csLedgerDmdPrc, string addUpSecCd, Int32 addUpDate)
		{
			DataRow row = _csLedgerSlipDataTable.NewRow();

			// 請求先コード
			row[Ct_CsLedger_ClaimCode] = csLedgerDmdPrc.ClaimCode;
			// 得意先コード
			row[Ct_CsLedger_CustomerCode] = csLedgerDmdPrc.CustomerCode;
			// 計上年月日
			row[Ct_CsLedger_AddUpDate] = addUpDate;
			// レコード区分(0:売上,1:入金)
			row[Ct_CsLedger_RecordCode] = LedgerDtlRecordState.Sales;
			// 前残繰越区分(0:前残,1:その他(売 or 入),2:繰越)
			if (makeMode == (int)LedgerDtlBalanseState.Balance)
			{
				row[Ct_CsLedger_BalanseCode] = LedgerDtlBalanseState.Balance;
				row[Ct_CsLedger_SlipDetail] = "【　前回繰越　】";
				row[Ct_CsLedger_Balance] = csLedgerDmdPrc.LastTimeDemand;

			}
			else if ( makeMode == (int)LedgerDtlBalanseState.ConsTax )
			{
				row[Ct_CsLedger_BalanseCode] = LedgerDtlBalanseState.ConsTax;
				row[Ct_CsLedger_SlipDetail] = "消 費 税";
				//row[Ct_CsLedger_SalesSubtotalTax] = csLedgerDmdPrc.ThisSalesTax;
			}
			else
			{
				row[Ct_CsLedger_BalanseCode] = LedgerDtlBalanseState.Carried;
				row[Ct_CsLedger_SlipDetail] = "【　繰越残高　】" + TDateTime.DateTimeToString("yyyy.mm.dd", DateConverter.GetDateTimeFromYYYYMMDD(addUpDate));
				// 繰越残高は拠点別に再計算する必要がある！！
				row[Ct_CsLedger_Balance] = 0;
			}
			// 計上日(Int)
			row[Ct_CsLedger_AddUpADateInt] = addUpDate;
			// 計上拠点コード
			row[Ct_CsLedger_AddUpSecCode] = addUpSecCd;
			// 計上拠点名称(繰越残高行は拠点名称を表示しない)
			row[Ct_CsLedger_AddUpSecName] = "";

			return row;
		}
		#endregion

		#region ◎ 元帳照会明細データ設定処理
		/// <summary>
		/// 元帳照会明細データ設定処理
		/// </summary>
        /// <param name="salesBTable">残高リスト</param>
        /// <param name="salesHTable">売上リスト</param>
        /// <param name="salesDTable">売上明細リスト</param>
        /// <param name="depsitHTable">入金リスト</param>
        /// <remarks>
		/// <br>Note        : 請求金額レコードの計上範囲の売上・入金データを元帳照会明細テーブルに設定します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
        private static void SettingDataCsLedgerTable(Hashtable salesBTable, Hashtable salesHTable, Hashtable salesDTable, Hashtable depsitHTable)
		{
            if (salesBTable != null)
            {
                // 残高行作成(HashTable Key: 計上年月日(int),Value: 該当計上年月日の売上レコードリスト)
                foreach (DictionaryEntry entry in salesBTable)
                {
                    int keyDate = TStrConv.StrToIntDef(entry.Key.ToString(), 0);
                    ArrayList arDmdSalesB = (ArrayList)entry.Value;

                    DataRow addRow;

                    if (_imode == 0) // 請求モード
                    {
                        foreach (CustDmdPrcInfGetWork dmdSalesB in arDmdSalesB)
                        {
                            addRow = CustDmdPrcWorkToBlanceDataRow(keyDate, dmdSalesB);
                            if (addRow != null)
                            {
                                _csLedgerBlanceDataTable.Rows.Add(addRow);
                            }
                        }
                    }
                    else
                    {
                        foreach (CustAccRecInfGetWork dmdSalesB in arDmdSalesB)
                        {
                            addRow = CustDmdPrcWorkToBlanceDataRow(keyDate, dmdSalesB);
                            if (addRow != null)
                            {
                                _csLedgerBlanceDataTable.Rows.Add(addRow);
                            }
                        }
                    }
                }
            }

            if (salesHTable != null)
			{
				// 売上行作成(HashTable Key: 計上年月日(int),Value: 該当計上年月日の売上レコードリスト)
				foreach (DictionaryEntry entry in salesHTable)
				{
					int keyDate = TStrConv.StrToIntDef(entry.Key.ToString(), 0);
					ArrayList arDmdSales = (ArrayList)entry.Value;

					DataRow addRow;
					foreach (LedgerSalesSlipWork dmdSales in arDmdSales)
					{
                        // 請求モードで消費税調整(売掛用)または残高調整(売掛用)の場合次データを処理
                        if ((_imode == 0) && ((dmdSales.SalesGoodsCd == 4) || (dmdSales.SalesGoodsCd == 5))) continue;
                        // 請求モードで現金の場合次データを処理
                        if ((_imode == 0) && (dmdSales.AccRecDivCd == 0)) continue;

                        addRow = SalesToCsLedgerSlipDataRow(keyDate, dmdSales); 
						if ( addRow != null )
						{
							_csLedgerSlipDataTable.Rows.Add( addRow );
						}
					}
				}
			}

			if (salesDTable != null)
			{
				// 売上明細行作成(HashTable Key: 計上年月日(int),Value: 該当計上年月日の売上レコードリスト)
				foreach (DictionaryEntry entry in salesDTable)
				{
					int keyDate = TStrConv.StrToIntDef(entry.Key.ToString(), 0);
					ArrayList arDmdSalesD = (ArrayList)entry.Value;

					DataRow addRow;
                    foreach (LedgerSalesDetailWork dmdSalesD in arDmdSalesD)
					{
                        // 請求モードで消費税調整(売掛用)または残高調整(売掛用)の場合次データを処理
                        if ((_imode == 0) && ((dmdSalesD.SalesGoodsCd == 4) || (dmdSalesD.SalesGoodsCd == 5))) continue;

                        // 請求モードで現金の場合次データを処理
                        if ((_imode == 0) && (dmdSalesD.AccRecDivCd == 0)) continue;

						addRow = SalesToCsLedgerDtlDataRow(keyDate, dmdSalesD); 
						if ( addRow != null )
						{
							_csLedgerDtlDataTable.Rows.Add( addRow );
						}
					}
				}
			}

            if (depsitHTable != null)
            {

                // 入金明細行作成(HashTable Key: 計上年月日(int),Value: 該当計上年月日の入金レコードリスト)
                foreach (DictionaryEntry entry in depsitHTable)
                {
                    // 他拠点入金用クラス作成
                    LedgerDepsitMainWork otherDeposit = new LedgerDepsitMainWork();

                    int keyDate = TStrConv.StrToIntDef(entry.Key.ToString(), 0);
                    ArrayList arDeposits = (ArrayList)entry.Value;

                    foreach (LedgerDepsitMainWork depsit in arDeposits)
                    {
                        _csLedgerSlipDataTable.Rows.Add(DepsitToCsLedgerSlipDataRow(keyDate, depsit));
                        _csLedgerDtlDataTable.Rows.Add(DepsitToCsLedgerDtlDataRow(keyDate, depsit));
                    }
                }
            }
   		}
		#endregion

        #region ◎ 残高情報から元帳照会明細情報データ行設定処理
        /// <summary>
        /// 残高情報から元帳照会明細情報データ行設定処理
        /// </summary>
        /// <param name="addUpDate">計上年月日(締単位)</param>
        /// <param name="custDmdPrcInfGetWork">請求売上データクラス</param>
        /// <returns>設定されたデータ行</returns>
        /// <remarks>
        /// <br>Note        : 残高情報から元帳照会明細情報のデータ行へ設定します。</br>
        /// <br>Programer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.18</br>
        /// </remarks>
        private static DataRow CustDmdPrcWorkToBlanceDataRow(int addUpDate, CustDmdPrcInfGetWork custDmdPrcInfGetWork)
        {
            DataRow row = _csLedgerBlanceDataTable.NewRow();
            // 計上拠点コード
            row[Ct_CsLedgerBlance_AddUpSecCode] = custDmdPrcInfGetWork.AddUpSecCode;

            // 計上拠点名称
            string sectionName = "";
            if (_sectionHTable.ContainsKey(custDmdPrcInfGetWork.AddUpSecCode))
            {
                SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[custDmdPrcInfGetWork.AddUpSecCode];
                sectionName = secInfoSet.SectionGuideNm;
            }

            row[Ct_CsLedgerBlance_AddUpSecName] = sectionName;

            row[Ct_CsLedgerBlance_ClaimCode] = custDmdPrcInfGetWork.ClaimCode;                                         // 請求先コード
            row[Ct_CsLedgerBlance_CustomerCode] = custDmdPrcInfGetWork.CustomerCode;                                   // 得意先コード
            row[Ct_CsLedgerBlance_AddUpDate] = custDmdPrcInfGetWork.AddUpDate;                                         // 計上年月日
            row[Ct_CsLedgerBlance_SlitTitle] = "請求残";        // 帳票タイトル
            row[Ct_CsLedgerBlance_AddUpDateInt] = TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.AddUpDate);        // 計上年月日
            row[Ct_CsLedgerBlance_AddUpYearMonth] = TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.AddUpYearMonth); // 計上年月
            row[Ct_CsLedgerBlance_LastTimeDemand] = custDmdPrcInfGetWork.LastTimeDemand;                               // 前回請求金額
            row[Ct_CsLedgerBlance_ThisTimeDmdNrml] = custDmdPrcInfGetWork.ThisTimeDmdNrml;                             // 今回入金金額（通常入金）
            row[Ct_CsLedgerBlance_ThisTimeTtlBlcDmd] = custDmdPrcInfGetWork.ThisTimeTtlBlcDmd;                         // 今回繰越残高（請求計）
            row[Ct_CsLedgerBlance_OfsThisTimeSales] = custDmdPrcInfGetWork.OfsThisTimeSales;                           // 相殺後今回売上金額           
            row[Ct_CsLedgerBlance_OfsThisSalesTax] = custDmdPrcInfGetWork.OfsThisSalesTax;    // 相殺後今回売上消費税                      
            row[Ct_CsLedgerBlance_ThisTimeSales] = custDmdPrcInfGetWork.ThisTimeSales;        // 今回売上金額
            row[Ct_CsLedgerBlance_AfCalDemandPrice] = custDmdPrcInfGetWork.AfCalDemandPrice;           // 計算後請求金額
            row[Ct_CsLedgerBlance_AcpOdrTtl2TmBfBlDmd] = custDmdPrcInfGetWork.AcpOdrTtl2TmBfBlDmd;     // 受注2回前残高（請求計）
            row[Ct_CsLedgerBlance_AcpOdrTtl3TmBfBlDmd] = custDmdPrcInfGetWork.AcpOdrTtl3TmBfBlDmd;     // 受注3回前残高（請求計）
            row[Ct_CsLedgerBlance_CAddUpUpdExecDate] = TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.CAddUpUpdExecDate);     // 締次更新実行年月日
            row[Ct_CsLedgerBlance_CloseFlag] = custDmdPrcInfGetWork.CloseFlg;                                                    // 締済フラグ
            row[Ct_CsLedgerBlance_ThisRgdsDis] = custDmdPrcInfGetWork.ThisSalesPricRgds + custDmdPrcInfGetWork.ThisSalesPricDis; // 返品・値引額
            row[Ct_CsLedgerBlance_ThisSalesTaxTotal] = custDmdPrcInfGetWork.OfsThisTimeSales + custDmdPrcInfGetWork.OfsThisSalesTax;   // 税込売上額
            row[Ct_CsLedgerBlance_StartDateSpan] = TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.StartCAddUpUpdDate);   // 日付範囲（開始）
            row[Ct_CsLedgerBlance_EndDateSpan] = TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.AddUpDate);       // 日付範囲（終了）
            row[Ct_CsLedgerBlance_Name] = custDmdPrcInfGetWork.CustomerName;             // 得意先名称
            row[Ct_CsLedgerBlance_Name2] = custDmdPrcInfGetWork.CustomerName2;           // 得意先名称2

            return row;
        }
        #endregion

        #region ◎ 残高情報から元帳照会明細情報データ行設定処理
        /// <summary>
        /// 残高情報から元帳照会明細情報データ行設定処理
        /// </summary>
        /// <param name="addUpDate">計上年月日(締単位)</param>
        /// <param name="custAccRecInfGetWork">請求売上データクラス</param>
        /// <returns>設定されたデータ行</returns>
        /// <remarks>
        /// <br>Note        : 残高情報から元帳照会明細情報のデータ行へ設定します。</br>
        /// <br>Programer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.18</br>
        /// </remarks>
        private static DataRow CustDmdPrcWorkToBlanceDataRow(int addUpDate, CustAccRecInfGetWork custAccRecInfGetWork)
        {
            DataRow row = _csLedgerBlanceDataTable.NewRow();
            // 計上拠点コード
            row[Ct_CsLedgerBlance_AddUpSecCode] = custAccRecInfGetWork.AddUpSecCode;

            // 計上拠点名称
            string sectionName = "";
            if (_sectionHTable.ContainsKey(custAccRecInfGetWork.AddUpSecCode))
            {
                SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[custAccRecInfGetWork.AddUpSecCode];
                sectionName = secInfoSet.SectionGuideNm;
            }

            row[Ct_CsLedgerBlance_AddUpSecName] = sectionName;

            row[Ct_CsLedgerBlance_ClaimCode] = custAccRecInfGetWork.ClaimCode;                                         // 請求先コード
            row[Ct_CsLedgerBlance_CustomerCode] = custAccRecInfGetWork.CustomerCode;                                   // 得意先コード
            row[Ct_CsLedgerBlance_AddUpDate] = custAccRecInfGetWork.AddUpDate;                                         // 計上年月日
            row[Ct_CsLedgerBlance_SlitTitle] = "売掛残";        // 帳票タイトル
            row[Ct_CsLedgerBlance_AddUpDateInt] = TDateTime.DateTimeToLongDate(custAccRecInfGetWork.AddUpDate);        // 計上年月日
            row[Ct_CsLedgerBlance_AddUpYearMonth] = TDateTime.DateTimeToLongDate(custAccRecInfGetWork.AddUpYearMonth); // 計上年月
            row[Ct_CsLedgerBlance_LastTimeDemand] = custAccRecInfGetWork.LastTimeAccRec;                               // 前回売掛金額
            row[Ct_CsLedgerBlance_ThisTimeDmdNrml] = custAccRecInfGetWork.ThisTimeDmdNrml;                             // 今回入金金額（通常入金）
            row[Ct_CsLedgerBlance_ThisTimeTtlBlcDmd] = custAccRecInfGetWork.ThisTimeTtlBlcAcc;                         // 今回繰越残高（売掛計）
            row[Ct_CsLedgerBlance_OfsThisTimeSales] = custAccRecInfGetWork.OfsThisTimeSales;                           // 相殺後今回売上金額           
            row[Ct_CsLedgerBlance_OfsThisSalesTax] = custAccRecInfGetWork.OfsThisSalesTax;    // 相殺後今回売上消費税                      
            row[Ct_CsLedgerBlance_ThisTimeSales] = custAccRecInfGetWork.ThisTimeSales;        // 今回売上金額
            row[Ct_CsLedgerBlance_AfCalDemandPrice] = custAccRecInfGetWork.AfCalTMonthAccRec;           // 計算後請求金額
            row[Ct_CsLedgerBlance_AcpOdrTtl2TmBfBlDmd] = custAccRecInfGetWork.AcpOdrTtl2TmBfAccRec;     // 受注2回前残高（売掛計）
            row[Ct_CsLedgerBlance_AcpOdrTtl3TmBfBlDmd] = custAccRecInfGetWork.AcpOdrTtl3TmBfAccRec;     // 受注3回前残高（売掛計）
            row[Ct_CsLedgerBlance_CAddUpUpdExecDate] = TDateTime.DateTimeToLongDate(custAccRecInfGetWork.MonthAddUpExpDate);     // 月次更新実行年月日
            row[Ct_CsLedgerBlance_CloseFlag] = custAccRecInfGetWork.CloseFlg;                                                    // 締済フラグ
            row[Ct_CsLedgerBlance_ThisRgdsDis] = custAccRecInfGetWork.ThisSalesPricRgds + custAccRecInfGetWork.ThisSalesPricDis; // 返品・値引額
            row[Ct_CsLedgerBlance_ThisSalesTaxTotal] = custAccRecInfGetWork.OfsThisTimeSales + custAccRecInfGetWork.OfsThisSalesTax;   // 税込売上額
            row[Ct_CsLedgerBlance_StartDateSpan] = TDateTime.DateTimeToLongDate(custAccRecInfGetWork.StMonCAddUpUpdDate);   // 日付範囲（開始）
            row[Ct_CsLedgerBlance_EndDateSpan] = TDateTime.DateTimeToLongDate(custAccRecInfGetWork.AddUpDate);       // 日付範囲（終了）
            row[Ct_CsLedgerBlance_Name] = custAccRecInfGetWork.CustomerName;             // 得意先名称
            row[Ct_CsLedgerBlance_Name2] = custAccRecInfGetWork.CustomerName2;           // 得意先名称2

            return row;
        }
        #endregion

        #region ◎ 売上情報から元帳照会明細情報データ行設定処理
        /// <summary>
		/// 売上情報から元帳照会明細情報データ行設定処理
		/// </summary>
		/// <param name="addUpDate">計上年月日(締単位)</param>
		/// <param name="dmd">請求売上データクラス</param>
		/// <returns>設定されたデータ行</returns>
		/// <remarks>
		/// <br>Note        : 売上情報から元帳照会明細情報のデータ行へ設定します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static DataRow SalesToCsLedgerSlipDataRow(int addUpDate, LedgerSalesSlipWork dmd)
		{
			DataRow row = _csLedgerSlipDataTable.NewRow();

            // 請求先コード
			row[Ct_CsLedger_ClaimCode] = dmd.ClaimCode;
            // 得意先コード
			row[Ct_CsLedger_CustomerCode] = dmd.CustomerCode;
			// 計上年月日
			row[Ct_CsLedger_AddUpDate] = addUpDate;
			// レコード区分(0:売上,1:入金)
			row[Ct_CsLedger_RecordCode] = LedgerDtlRecordState.Sales;
			// 前残繰越区分(0:前残,1:その他(売 or 入),2:繰越)
			row[Ct_CsLedger_BalanseCode] = LedgerDtlBalanseState.Others;
			// 赤伝区分(0:黒,1:赤,2相殺済み黒)
			row[Ct_CsLedger_DebitNoteDiv] = dmd.DebitNoteDiv;
            if (dmd.DebitNoteDiv == 0)
            {
				row[Ct_CsLedger_DebitNoteDiv] = 2;
			}
			// 計上日付
			row[Ct_CsLedger_AddUpADate] = dmd.AddUpADate;
			// 計上日付(Int)
			row[Ct_CsLedger_AddUpADateInt] = TDateTime.DateTimeToLongDate( dmd.AddUpADate );
			// 計上日付(表示用)
			row[Ct_CsLedger_AddUpADateDisp] = TDateTime.DateTimeToString("YYYY/MM/DD", dmd.AddUpADate);
            // 売上伝票区分
            row[Ct_CsLedger_SalesSlipCd] = dmd.SalesSlipCd;
            string sliptypenm = "";
            switch (dmd.SalesSlipCd)
			{
				case 0:
					sliptypenm = "売上";
					break;
				case 1:
					sliptypenm = "返品";
					break;
				default:
					sliptypenm = "売上";
					break;
			}
			row[Ct_CsLedger_SalesSlipKindName] = sliptypenm;

			// 伝票番号
			row[Ct_CsLedger_SlipNo] = dmd.SalesSlipNum;
			// 受注・入金内容
			// Todo:内容が表示されないときはここが原因
            string slipDetail = "";
            
            switch (dmd.SalesGoodsCd)
            { 
                case 0:
                    slipDetail = "商品";
                    break;
                case 1:
                    slipDetail = "商 品 外";
                    break;
                case 2:
                    slipDetail = "消費税調整";
                    break;
                case 3:
                    slipDetail = "残高調整";
                    break;
                case 4:
                    slipDetail = "売掛用消費税調整";
                    break;
                case 5:
                    slipDetail = "売掛用残高調整";
                    break;
            }
            row[Ct_CsLedger_SlipDetail] = slipDetail;
			
			// 売上金額
            // 残高調整の場合
            if ((dmd.SalesGoodsCd == 3) || (dmd.SalesGoodsCd == 5)) 
            {
                row[Ct_CsLedger_SalesTotal] = dmd.SalesSubtotalTaxInc;
                row[Ct_CsLedger_SalesTotal1] = dmd.SalesSubtotalTaxInc;
            }
            else
            {
                // 2009.03.02 30413 犬飼 売上伝票合計（税抜き）の追加 >>>>>>START
                //row[Ct_CsLedger_SalesTotal] = dmd.SalesSubtotalTaxExc;
                row[Ct_CsLedger_SalesTotal] = dmd.SalesTotalTaxExc;
                // 2009.03.02 30413 犬飼 売上伝票合計（税抜き）の追加 <<<<<<END
                row[Ct_CsLedger_SalesTotal1] = 0;

            }
            // 売上消費税
            row[Ct_CsLedger_SalesSubtotalTax] = dmd.SalesSubtotalTax;
            // 売上消費税(元帳用)
            if ((dmd.SalesGoodsCd == 2) || (dmd.SalesGoodsCd == 4))
            {
                row[Ct_CsLedger_SalesSubtotalTax1] = dmd.SalesSubtotalTax;
            }
            else
            {
                row[Ct_CsLedger_SalesSubtotalTax1] = 0;
            }
            // 税込合計
            // 2009.03.02 30413 犬飼 売上伝票合計（税抜き）の追加 >>>>>>START
            //row[Ct_CsLedger_ThisSalesTaxTotal] = dmd.SalesSubtotalTaxExc + dmd.SalesSubtotalTax;
            row[Ct_CsLedger_ThisSalesTaxTotal] = dmd.SalesTotalTaxExc + dmd.SalesSubtotalTax;
            // 2009.03.02 30413 犬飼 売上伝票合計（税抜き）の追加 <<<<<<END
            // 備考
			row[Ct_CsLedger_SlipNote] = dmd.SlipNote;
            // 備考2
            row[Ct_CsLedger_SlipNote2] = dmd.SlipNote2;

            //リマーク1
            row[Ct_CsLedger_UOERemark1] = dmd.UoeRemark1;
            //リマーク2
            row[Ct_CsLedger_UOERemark2] = dmd.UoeRemark2;

            // 残高計算は売上・入金をDataTableにセットした後で行います。
			
			row[Ct_CsLedger_AddUpSecCode] = dmd.DemandAddUpSecCd;	// 計上拠点コード
			// 計上拠点名称
			string sectionName = "";
			if (_sectionHTable.ContainsKey(dmd.DemandAddUpSecCd))
			{
				SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[dmd.DemandAddUpSecCd];
				sectionName = secInfoSet.SectionGuideNm;
			}
			row[Ct_CsLedger_AddUpSecName] = sectionName;

            // 相手先伝票番号（明細）
            row[Ct_CsLedger_PartySlipNumDtl] = dmd.PartySaleSlipNum;

            // 印字区分
            row[Ct_CsLedger_PrtDiv] = 1;

   			return row;
		}

		/// <summary>
		/// 売上情報から元帳照会明細情報データ行設定処理
		/// </summary>
		/// <param name="addUpDate">計上年月日(締単位)</param>
		/// <param name="dmd">請求売上データクラス</param>
		/// <returns>設定されたデータ行</returns>
		/// <remarks>
		/// <br>Note        : 売上情報から元帳照会明細情報のデータ行へ設定します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
        private static DataRow SalesToCsLedgerDtlDataRow(int addUpDate, LedgerSalesDetailWork dmd)
		{
			DataRow row = _csLedgerDtlDataTable.NewRow();

            // 請求先コード
            row[Ct_CsLedgerDtl_ClaimCode] = dmd.ClaimCode;
            // 得意先コード
            row[Ct_CsLedgerDtl_CustomerCode] = dmd.CustomerCode;
			// 計上年月日
            row[Ct_CsLedgerDtl_AddUpDate] = addUpDate;
			// レコード区分(0:売上,1:入金)
            row[Ct_CsLedgerDtl_RecordCode] = LedgerDtlRecordState.Sales;
			// 前残繰越区分(0:前残,1:その他(売 or 入),2:繰越)
            row[Ct_CsLedgerDtl_BalanseCode] = LedgerDtlBalanseState.Others;
			// 赤伝区分(0:黒,1:赤,2相殺済み黒)
            row[Ct_CsLedgerDtl_DebitNoteDiv] = dmd.DebitNoteDiv;
            if (dmd.DebitNoteDiv == 0)
            {
                row[Ct_CsLedgerDtl_DebitNoteDiv] = 2;
			}
			// 計上日付
            row[Ct_CsLedgerDtl_AddUpADate] = dmd.AddUpADate;
			// 計上日付(Int)
            row[Ct_CsLedgerDtl_AddUpADateInt] = TDateTime.DateTimeToLongDate(dmd.AddUpADate);
			// 計上日付(表示用)
            row[Ct_CsLedgerDtl_AddUpADateDisp] = TDateTime.DateTimeToString("YYYY/MM/DD", dmd.AddUpADate);
            // 売上伝票区分
            row[Ct_CsLedgerDtl_SalesSlipCd] = dmd.SalesSlipCd;
            string sliptypenm = "";
            switch (dmd.SalesSlipCd)
			{
				case 0:
					sliptypenm = "売上";
					break;
				case 1:
					sliptypenm = "返品";
					break;
				default:
					sliptypenm = "売上";
					break;
			}
            row[Ct_CsLedgerDtl_SalesSlipKindName] = sliptypenm;

			// 伝票番号・入金番号
            row[Ct_CsLedgerDtl_SlipNo] = dmd.SalesSlipNum;
            // 計上拠点コード
            row[Ct_CsLedgerDtl_AddUpSecCode] = dmd.DemandAddUpSecCd;	
			// 計上拠点名称
			string sectionName = "";
			if (_sectionHTable.ContainsKey(dmd.DemandAddUpSecCd))
			{
				SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[dmd.DemandAddUpSecCd];
				sectionName = secInfoSet.SectionGuideNm;
			}
            row[Ct_CsLedgerDtl_AddUpSecName] = sectionName;
            // 売上金額                          
            // 2009.03.02 30413 犬飼 売上伝票合計（税抜き）の追加 >>>>>>START
            //row[Ct_CsLedgerDtl_SalesTotal] = dmd.SalesSubtotalTaxExc;
            row[Ct_CsLedgerDtl_SalesTotal] = dmd.SalesTotalTaxExc;
            // 2009.03.02 30413 犬飼 売上伝票合計（税抜き）の追加 <<<<<<END
            // 売上消費税                           
            row[Ct_CsLedgerDtl_SalesSubtotalTax] = dmd.SalesSubtotalTax;
            // 税込売上額
            // 2009.03.02 30413 犬飼 売上伝票合計（税抜き）の追加 >>>>>>START
            //row[Ct_CsLedgerDtl_ThisSalesTaxTotal] = dmd.SalesSubtotalTaxExc + dmd.SalesSubtotalTax;
            row[Ct_CsLedgerDtl_ThisSalesTaxTotal] = dmd.SalesTotalTaxExc + dmd.SalesSubtotalTax;
            // 2009.03.02 30413 犬飼 売上伝票合計（税抜き）の追加 <<<<<<END
            // 伝票備考
            row[Ct_CsLedgerDtl_SlipNote] = dmd.SlipNote; 
            // 伝票備考2
            row[Ct_CsLedgerDtl_SlipNote2] = dmd.SlipNote2;
            //リマーク1
            row[Ct_CsLedgerDtl_UOERemark1] = dmd.UoeRemark1;
            //リマーク2
            row[Ct_CsLedgerDtl_UOERemark2] = dmd.UoeRemark2;
            // 売上行番号
            row[Ct_CsLedgerDtl_SalesRowNo] = dmd.SalesRowNo;
            // メーカー名称
            // 商品番号
            row[Ct_CsLedgerDtl_GoodsNo] = dmd.GoodsNo;
            // 商品名称
            row[Ct_CsLedgerDtl_GoodsName] = dmd.GoodsName;
            // 出荷数
            // 売上単価
            if ((dmd.SalesGoodsCd == 0) || (dmd.SalesGoodsCd == 1))
            {
                row[Ct_CsLedgerDtl_ShipmentCnt] = dmd.ShipmentCnt;
                row[Ct_CsLedgerDtl_SalesUnPrcTaxExcFl] = dmd.SalesUnPrcTaxExcFl;
            }
            else
            {
                row[Ct_CsLedgerDtl_ShipmentCnt] = 0;
                row[Ct_CsLedgerDtl_SalesUnPrcTaxExcFl] = 0;
            }
            // 売上金額
            // 残高調整の場合
            if ((dmd.SalesGoodsCd == 3) || (dmd.SalesGoodsCd == 5))
            {
                row[Ct_CsLedgerDtl_SalesMoneyTaxExc] = dmd.SalesSubtotalTaxInc;
                row[Ct_CsLedgerDtl_SalesMoneyTaxExc1] = dmd.SalesSubtotalTaxInc;
            }
            else
            {
                if ((dmd.SalesGoodsCd == 0) || (dmd.SalesGoodsCd == 1))
                {
                    row[Ct_CsLedgerDtl_SalesMoneyTaxExc] = dmd.SalesMoneyTaxExc;
                }
                else
                {
                    row[Ct_CsLedgerDtl_SalesMoneyTaxExc] = 0;
                }
                row[Ct_CsLedgerDtl_SalesMoneyTaxExc1] = 0;
            }
            // 売上金額消費税
            // 消費税調整の場合
            if ((dmd.SalesGoodsCd == 2) || (dmd.SalesGoodsCd == 4))
            {
                row[Ct_CsLedgerDtl_SalsePriceConsTax] = dmd.SalesSubtotalTax;
                row[Ct_CsLedgerDtl_SalsePriceConsTax1] = dmd.SalesSubtotalTax;
            }
            else
            {
                if ((dmd.SalesGoodsCd == 0) || (dmd.SalesGoodsCd == 1))
                {
                    row[Ct_CsLedgerDtl_SalsePriceConsTax] = dmd.SalesPriceConsTax;
                }
                else
                {
                    row[Ct_CsLedgerDtl_SalsePriceConsTax] = 0;
                }
                row[Ct_CsLedgerDtl_SalsePriceConsTax1] = 0;
            }
           
            // 商品名称
            row[Ct_CsLedgerDtl_SupplierCd] = dmd.SupplierCd;

            // 2009.02.25 30413 犬飼 消費税転嫁方式の追加 >>>>>>START
            // 消費税転嫁方式
            row[Ct_CsLedgerDtl_ConsTaxLayMethod] = dmd.ConsTaxLayMethod;
            // 課税区分
            row[Ct_CsLedgerDtl_TaxationDivCd] = dmd.TaxationDivCd;
            // 2009.02.25 30413 犬飼 消費税転嫁方式の追加 <<<<<<END
                                    
           return row;
		}
		#endregion

		#region ◎ 入金情報から元帳明細情報データ行設定処理
		/// <summary>
		/// 入金情報から元帳明細情報データ行設定処理
		/// </summary>
		/// <param name="AddUpDate">計上年月日(締単位)</param>
		/// <param name="depsit">入金データクラス</param>
		/// <returns>設定されたデータ行</returns>
		/// <remarks>
		/// <br>Note        : 入金情報から元帳明細情報のデータ行へ設定します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static DataRow DepsitToCsLedgerSlipDataRow(int AddUpDate, LedgerDepsitMainWork depsit)
		{
			DataRow row = _csLedgerSlipDataTable.NewRow();

			// 請求先コード
			row[Ct_CsLedger_ClaimCode] = depsit.ClaimCode;
			// 得意先コード
			row[Ct_CsLedger_CustomerCode] = depsit.CustomerCode;
			// 計上年月日
			row[Ct_CsLedger_AddUpDate] = AddUpDate;
			// レコード区分(0:売上,1:入金)
			row[Ct_CsLedger_RecordCode] = LedgerDtlRecordState.Deposit;
			// 前残繰越区分(0:前残,1:その他(売 or 入),2:繰越)
			row[Ct_CsLedger_BalanseCode] = LedgerDtlBalanseState.Others;
			// 赤伝区分(0:黒,1:赤,2相殺済み黒)
			row[Ct_CsLedger_DebitNoteDiv] = depsit.DepositDebitNoteCd;
			// 計上日付
			row[Ct_CsLedger_AddUpADate] = depsit.DepositDate;
			// 計上日付
			row[Ct_CsLedger_AddUpADateInt] = TDateTime.DateTimeToLongDate( depsit.DepositDate );
			// 計上日付(表示用)
			row[Ct_CsLedger_AddUpADateDisp] = TDateTime.DateTimeToString("YYYY/MM/DD", depsit.DepositDate);
			// 売上伝票区分
			row[Ct_CsLedger_SalesSlipCd] = 0;
			// 伝票種類
            row[Ct_CsLedger_SalesSlipKindName] = "入金";
            // 入金名称
            row[Ct_CsLedgerDtl_GoodsName] = string.Format("{0}", depsit.MoneyKindName);
            // 入金番号
            row[Ct_CsLedger_SlipNo] = String.Format("{0:D9}", depsit.DepositSlipNo);
            // 手形支払期日(表示用)
            row[Ct_CsLedger_DraftPayTimeLimit] = TDateTime.DateTimeToString("YYYY/MM/DD", depsit.ValidityTerm);
            // 入金金額
            row[Ct_CsLedger_Deposit] = depsit.Deposit;
			row[Ct_CsLedger_AddUpSecCode] = depsit.AddUpSecCode;	// 計上拠点コード
			// 計上拠点名称
			string sectionName = "";
			if (_sectionHTable.ContainsKey(depsit.AddUpSecCode))
			{
				SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[depsit.AddUpSecCode];
				sectionName = secInfoSet.SectionGuideNm;
			}
			row[Ct_CsLedger_AddUpSecName] = sectionName;

            // 印字区分
            row[Ct_CsLedger_PrtDiv] = 1;

			return row;
		}
		#endregion

        #region ◎ 入金情報から元帳明細情報データ行設定処理
        /// <summary>
        /// 入金情報から元帳明細情報データ行設定処理
        /// </summary>
        /// <param name="AddUpDate">計上年月日(締単位)</param>
        /// <param name="depsit">入金データクラス</param>
        /// <returns>設定されたデータ行</returns>
        /// <remarks>
        /// <br>Note        : 入金情報から元帳明細情報のデータ行へ設定します。</br>
        /// <br>Programer	: 20081 疋田 勇人</br>
        /// <br>Date		: 2007.10.18</br>
        /// </remarks>
        private static DataRow DepsitToCsLedgerDtlDataRow(int AddUpDate, LedgerDepsitMainWork depsit)
        {
            DataRow row = _csLedgerDtlDataTable.NewRow();

            // 請求先コード
            row[Ct_CsLedgerDtl_ClaimCode] = depsit.ClaimCode;
            // 得意先コード
            row[Ct_CsLedgerDtl_CustomerCode] = depsit.CustomerCode;
            // 計上年月日
            row[Ct_CsLedgerDtl_AddUpDate] = AddUpDate;
            // レコード区分(0:売上,1:入金)
            row[Ct_CsLedgerDtl_RecordCode] = LedgerDtlRecordState.Deposit;
            // 前残繰越区分(0:前残,1:その他(売 or 入),2:繰越)
            row[Ct_CsLedgerDtl_BalanseCode] = LedgerDtlBalanseState.Others;
            // 赤伝区分(0:黒,1:赤,2相殺済み黒)
            row[Ct_CsLedgerDtl_DebitNoteDiv] = depsit.DepositDebitNoteCd;
            // 計上日付
            row[Ct_CsLedgerDtl_AddUpADate] = depsit.DepositDate;
            // 計上日付
            row[Ct_CsLedgerDtl_AddUpADateInt] = TDateTime.DateTimeToLongDate(depsit.DepositDate);
            // 計上日付(表示用)
            row[Ct_CsLedgerDtl_AddUpADateDisp] = TDateTime.DateTimeToString("YYYY/MM/DD", depsit.DepositDate);
            // 売上伝票区分
            row[Ct_CsLedgerDtl_SalesSlipCd] = 0;
            // 伝票種類
            row[Ct_CsLedgerDtl_SalesSlipKindName] = "入金";
            // 入金番号
            row[Ct_CsLedgerDtl_SlipNo] = String.Format("{0:000000000}", depsit.DepositSlipNo);
            // 手形支払期日(表示用)
            row[Ct_CsLedgerDtl_DraftPayTimeLimit] = TDateTime.DateTimeToString("YYYY/MM/DD", depsit.ValidityTerm);
            // 入金名称
            row[Ct_CsLedgerDtl_GoodsName] = string.Format("{0}", depsit.MoneyKindName);
            // 入金金額
            row[Ct_CsLedgerDtl_Deposit] = depsit.Deposit;
            row[Ct_CsLedgerDtl_AddUpSecCode] = depsit.AddUpSecCode;	// 計上拠点コード
            // 計上拠点名称
            string sectionName = "";
            if (_sectionHTable.ContainsKey(depsit.AddUpSecCode))
            {
                SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[depsit.AddUpSecCode];
                sectionName = secInfoSet.SectionGuideNm;
            }
            row[Ct_CsLedgerDtl_AddUpSecName] = sectionName;

            return row;
        }
        #endregion

		#region ◎ 得意先情報StaticMemory設定処理
		/// <summary>
		/// 得意先情報StaticMemory設定処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="custDmdPrcInfGetWorks">KINGETパラメータ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note        : KINGETパラメータより得意先情報をStaticMemoryへ設定します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static int CustDmdPrcWorkToCustomer(string enterpriseCode, ArrayList custDmdPrcInfGetWorks)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			string key = "";
			
			foreach (CustDmdPrcInfGetWork custDmdPrcInfGetWork in custDmdPrcInfGetWorks)
			{
                key = custDmdPrcInfGetWork.ClaimCode.ToString() + "_" + TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.AddUpDate).ToString() + "_" + custDmdPrcInfGetWork.AddUpSecCode;

				if (!_csLedgerCustomerHTable.ContainsKey(key))
				{
					CsLedgerCustomer cs = new CsLedgerCustomer();

                    // 請求先コード
                    cs.ClaimCode = custDmdPrcInfGetWork.ClaimCode;
                    // 略称
                    cs.SNm = custDmdPrcInfGetWork.ClaimSnm;
                    // 得意先コード
					cs.CustomerCode = custDmdPrcInfGetWork.CustomerCode;
					// 名称
					cs.Name = custDmdPrcInfGetWork.CustomerName;
					// 名称２
					cs.Name2 = custDmdPrcInfGetWork.CustomerName2;
					// 消費税転嫁方式
					cs.CustTaxLayCd = custDmdPrcInfGetWork.ConsTaxLayMethod;
					
					_csLedgerCustomerHTable.Add(key, cs);
				}
				
			}
			return status;
		}
		#endregion

		#region ◎ 得意先情報StaticMemory設定処理
		/// <summary>
		/// 得意先情報StaticMemory設定処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="custAccRecInfGetWorks">KINGETパラメータ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note        : KINGETパラメータより得意先情報をStaticMemoryへ設定します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static int CustAccRecWorkToCustomer(string enterpriseCode, ArrayList custAccRecInfGetWorks)
		{
		    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			string key = "";

			foreach (CustAccRecInfGetWork custAccRecInfGetWork in custAccRecInfGetWorks)
		    {
				
                key = custAccRecInfGetWork.ClaimCode.ToString() + "_" + TDateTime.DateTimeToLongDate(custAccRecInfGetWork.AddUpDate).ToString() + "_" + custAccRecInfGetWork.AddUpSecCode;

				if (!_csLedgerCustomerHTable.ContainsKey(key))
		        {
		            CsLedgerCustomer cs = new CsLedgerCustomer();

                    // 請求先コード
                    cs.ClaimCode = custAccRecInfGetWork.ClaimCode;
                    // 請求先略称
                    cs.SNm = custAccRecInfGetWork.ClaimSnm;
		            // 得意先コード
		            cs.CustomerCode = custAccRecInfGetWork.CustomerCode;
		            // 名称
		            cs.Name = custAccRecInfGetWork.CustomerName;
		            // 名称２
		            cs.Name2 = custAccRecInfGetWork.CustomerName2;
                    cs.SNm = custAccRecInfGetWork.CustomerSnm;

					// 消費税転嫁方式
					cs.CustTaxLayCd = custAccRecInfGetWork.ConsTaxLayMethod;

					_csLedgerCustomerHTable.Add(key, cs);
		        }
				
		    }
		    return status;
		}
		#endregion

		#region ◎ 得意先請求金額情報データ行設定処理(請求)
		/// <summary>
		/// 得意先請求金額情報データ行設定処理(請求)
		/// </summary>
        /// <param name="custDmdPrcInfGetWork">請求KINGET戻りパラメータ</param>
		/// <returns>設定されたデータ行</returns>
		/// <remarks>
		/// <br>Note        : 得意先請求金額情報をデータ行へ設定します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static DataRow CustDmdPrcWorkToDataRow(CustDmdPrcInfGetWork custDmdPrcInfGetWork)
		{
			DataRow newRow = _custDmdPrcDataTable.NewRow();

			CustDmdPrcWorkToDataRow( ref newRow, custDmdPrcInfGetWork );

			return newRow;
		}
		#endregion

		#region ◎ 得意先請求金額情報データ行設定処理(請求)
		/// <summary>
		/// 得意先請求金額情報データ行設定処理(請求)
		/// </summary>
		/// <param name="newRow">対象行</param>
        /// <param name="custDmdPrcInfGetWork">請求KINGET戻りパラメータ</param>
		/// <returns>設定されたデータ行</returns>
		/// <remarks>
		/// <br>Note        : 得意先請求金額情報をデータ行へ設定します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static DataRow CustDmdPrcWorkToDataRow(ref DataRow newRow, CustDmdPrcInfGetWork custDmdPrcInfGetWork)
		{
			// 計上拠点コード
			newRow[Ct_CsDmd_AddUpSecCode] = custDmdPrcInfGetWork.AddUpSecCode;

			// 計上拠点名称
			string sectionName = "";
			if (_sectionHTable.ContainsKey(custDmdPrcInfGetWork.AddUpSecCode))
			{
				SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[custDmdPrcInfGetWork.AddUpSecCode];
				sectionName = secInfoSet.SectionGuideNm;
			}

			newRow[Ct_CsDmd_AddUpSecName] = sectionName;

            newRow[Ct_CsDmd_ClaimCode] = custDmdPrcInfGetWork.ClaimCode;        // 請求先コード
            newRow[Ct_CsDmd_ClaimSnm]  = custDmdPrcInfGetWork.ClaimSnm;         // 請求先略称
            newRow[Ct_CsDmd_CustomerCode] = custDmdPrcInfGetWork.CustomerCode;  // 得意先コード
            newRow[Ct_CsDmd_CustomerSnm] = custDmdPrcInfGetWork.CustomerSnm;    // 得意先略称
            newRow[Ct_CsDmd_AddUpDate] = custDmdPrcInfGetWork.AddUpDate;                                      // 計上年月日
            newRow[Ct_CsDmd_SlitTitle] = "請求残";                                      // 帳票タイトル
            newRow[Ct_CsDmd_AddUpDateInt] = TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.AddUpDate);      // 計上年月日
			newRow[Ct_CsDmd_AddUpYearMonth		]	= TDateTime.DateTimeToLongDate( custDmdPrcInfGetWork.AddUpYearMonth ); // 計上年月
			newRow[Ct_CsDmd_LastTimeDemand		]	= custDmdPrcInfGetWork.LastTimeDemand;                                 // 前回請求金額
			newRow[Ct_CsDmd_ThisTimeDmdNrml		]	= custDmdPrcInfGetWork.ThisTimeDmdNrml;    // 今回入金金額（通常入金）
			newRow[Ct_CsDmd_ThisTimeTtlBlcDmd	]	= custDmdPrcInfGetWork.ThisTimeTtlBlcDmd;  // 今回繰越残高（請求計）
			newRow[Ct_CsDmd_OfsThisTimeSales	]	= custDmdPrcInfGetWork.OfsThisTimeSales;   // 相殺後今回売上金額           
			newRow[Ct_CsDmd_OfsThisSalesTax	    ]	= custDmdPrcInfGetWork.OfsThisSalesTax;    // 相殺後今回売上消費税                      
            newRow[Ct_CsDmd_ThisTimeSales       ]   = custDmdPrcInfGetWork.ThisTimeSales;      // 今回売上金額
			newRow[Ct_CsDmd_AfCalDemandPrice	]	= custDmdPrcInfGetWork.AfCalDemandPrice;    // 計算後請求金額
			newRow[Ct_CsDmd_AcpOdrTtl2TmBfBlDmd	]	= custDmdPrcInfGetWork.AcpOdrTtl2TmBfBlDmd; // 受注2回前残高（請求計）
			newRow[Ct_CsDmd_AcpOdrTtl3TmBfBlDmd	]	= custDmdPrcInfGetWork.AcpOdrTtl3TmBfBlDmd; // 受注3回前残高（請求計）
			newRow[Ct_CsDmd_CAddUpUpdExecDate	]	= TDateTime.DateTimeToLongDate( custDmdPrcInfGetWork.CAddUpUpdExecDate ); // 締次更新実行年月日
			newRow[Ct_CsDmd_CloseFlag			]	= custDmdPrcInfGetWork.CloseFlg;            // 締済フラグ
            // 2009.03.02 30413 犬飼 返品、値引の符号を反転させる >>>>>>START
            //newRow[Ct_CsDmd_ThisRgdsDis         ]   = custDmdPrcInfGetWork.ThisSalesPricRgds + custDmdPrcInfGetWork.ThisSalesPricDis; // 返品・値引額
            newRow[Ct_CsDmd_ThisRgdsDis         ]   = -(custDmdPrcInfGetWork.ThisSalesPricRgds + custDmdPrcInfGetWork.ThisSalesPricDis); // 返品・値引額
            // 2009.03.02 30413 犬飼 返品、値引の符号を反転させる <<<<<<END
            newRow[Ct_CsDmd_ThisSalesTaxTotal] = custDmdPrcInfGetWork.OfsThisTimeSales + custDmdPrcInfGetWork.OfsThisSalesTax;   // 税込売上額
            newRow[Ct_CsDmd_StartDateSpan] = TDateTime.DateTimeToLongDate( custDmdPrcInfGetWork.StartCAddUpUpdDate );   // 日付範囲（開始）
            newRow[Ct_CsDmd_EndDateSpan] = TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.AddUpDate);     // 日付範囲（終了）
            newRow[Ct_CsDmd_Name] = custDmdPrcInfGetWork.CustomerName;    // 得意先名称
			newRow[Ct_CsDmd_Name2				]	= custDmdPrcInfGetWork.CustomerName2;   // 得意先名称2
			
			int yy = 0;
			int mm = 0;
			int dd = 0;
			string strGengo = "";
			int status;

			// 計上年月(印刷用)
			status = TDateTime.SplitDate("YYYYMMDD", custDmdPrcInfGetWork.AddUpYearMonth,
			    ref strGengo,
			    ref yy,
			    ref mm,
			    ref dd);
			if (status == 0)
			{
				newRow[Ct_CsDmd_PrintAddUpYearMonth] = yy * 100 + mm;
			}

			// 計上年月日(印刷用)
			newRow[Ct_CsDmd_PrintAddUpDate] = TDateTime.DateTimeToLongDate( custDmdPrcInfGetWork.AddUpDate );

            // 返品・値引合計
            newRow[Col_CsDmd_RgdsDisT           ]   = custDmdPrcInfGetWork.ThisSalesPricRgds + custDmdPrcInfGetWork.ThisSalesPricDis;

            // 売上伝票枚数
            newRow[Col_CsDmd_SalesSlipCount] = custDmdPrcInfGetWork.SalesSlipCount;	       // 黒伝伝票枚数

			newRow.EndEdit();

			return newRow;
		}
		#endregion

		#region ◎ 得意先請求金額情報データ行設定処理(売掛)
		/// <summary>
		/// 得意先請求金額情報データ行設定処理(売掛)
		/// </summary>
		/// <param name="custAccRecInfGetWork">売掛KINGET戻りパラメータ</param>
		/// <returns>設定されたデータ行</returns>
		/// <remarks>
		/// <br>Note        : 得意先請求金額情報をデータ行へ設定します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static DataRow CustAccRecWorkToDataRow(CustAccRecInfGetWork custAccRecInfGetWork)
		{
			DataRow newRow = _custDmdPrcDataTable.NewRow();

			CustAccRecWorkToDataRow( ref newRow, custAccRecInfGetWork );

			return newRow;
		}
		#endregion
		#region ◎ 得意先請求金額情報データ行設定処理(売掛)
		/// <summary>
		/// 得意先請求金額情報データ行設定処理(売掛)
		/// </summary>
		/// <param name="newRow">対象行</param>
		/// <param name="custAccRecInfGetWork">請求KINGET戻りパラメータ</param>
		/// <returns>設定されたデータ行</returns>
		/// <remarks>
		/// <br>Note        : 得意先請求金額情報をデータ行へ設定します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static DataRow CustAccRecWorkToDataRow(ref DataRow newRow, CustAccRecInfGetWork custAccRecInfGetWork)
		{
		    // 計上拠点コード
		    newRow[Ct_CsDmd_AddUpSecCode] = custAccRecInfGetWork.AddUpSecCode;

		    // 計上拠点名称
		    string sectionName = "";
		    if (_sectionHTable.ContainsKey(custAccRecInfGetWork.AddUpSecCode))
		    {
		        SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[custAccRecInfGetWork.AddUpSecCode];
		        sectionName = secInfoSet.SectionGuideNm;
		    }

		    newRow[Ct_CsDmd_AddUpSecName] = sectionName;
            newRow[Ct_CsDmd_ClaimCode	] = custAccRecInfGetWork.ClaimCode;     // 請求先コード
            newRow[Ct_CsDmd_ClaimSnm	] = custAccRecInfGetWork.ClaimSnm;      // 請求先略称
            newRow[Ct_CsDmd_SlitTitle] = "売掛残";                                      // 帳票タイトル
            newRow[Ct_CsDmd_CustomerCode] = custAccRecInfGetWork.CustomerCode;                              // 得意先コード
		    newRow[Ct_CsDmd_CustomerSnm		    ]	= custAccRecInfGetWork.CustomerSnm;                               // 得意先略称
            newRow[Ct_CsDmd_AddUpDate			]	= custAccRecInfGetWork.AddUpDate;                                 // 計上年月日
		    newRow[Ct_CsDmd_AddUpDateInt		]	= TDateTime.DateTimeToLongDate( custAccRecInfGetWork.AddUpDate ); // 計上年月日
		    newRow[Ct_CsDmd_AddUpYearMonth		]	= TDateTime.DateTimeToLongDate( custAccRecInfGetWork.AddUpYearMonth ); // 計上年月
		    newRow[Ct_CsDmd_LastTimeDemand		]	= custAccRecInfGetWork.LastTimeAccRec;  // 前回請求金額

		    newRow[Ct_CsDmd_ThisTimeDmdNrml		]	= custAccRecInfGetWork.ThisTimeDmdNrml;    // 今回入金金額（通常入金）
		    newRow[Ct_CsDmd_ThisTimeTtlBlcDmd	]	= custAccRecInfGetWork.ThisTimeTtlBlcAcc;  // 今回繰越残高（請求計）
            newRow[Ct_CsDmd_OfsThisTimeSales	]	= custAccRecInfGetWork.OfsThisTimeSales;   // 相殺後今回売上金額
            newRow[Ct_CsDmd_OfsThisSalesTax	    ]	= custAccRecInfGetWork.OfsThisSalesTax;    // 相殺後今回売上消費税
            newRow[Ct_CsDmd_ThisTimeSales       ]   = custAccRecInfGetWork.ThisTimeSales;      // 今回売上金額
		    newRow[Ct_CsDmd_AfCalDemandPrice	]	= custAccRecInfGetWork.AfCalTMonthAccRec;    // 計算後請求金額
		    newRow[Ct_CsDmd_AcpOdrTtl2TmBfBlDmd	]	= custAccRecInfGetWork.AcpOdrTtl2TmBfAccRec; // 受注2回前残高（請求計）
		    newRow[Ct_CsDmd_AcpOdrTtl3TmBfBlDmd	]	= custAccRecInfGetWork.AcpOdrTtl3TmBfAccRec; // 受注3回前残高（請求計）
		    newRow[Ct_CsDmd_CAddUpUpdExecDate	]	= 0; // 締次更新実行年月日
		    newRow[Ct_CsDmd_CloseFlag			]	= custAccRecInfGetWork.CloseFlg; // 締済フラグ
            // 2009.03.02 30413 犬飼 返品、値引の符号を反転させる >>>>>>START
            //newRow[Ct_CsDmd_ThisRgdsDis         ]   = custAccRecInfGetWork.ThisSalesPricRgds + custAccRecInfGetWork.ThisSalesPricDis; // 返品・値引
            newRow[Ct_CsDmd_ThisRgdsDis         ]   = -(custAccRecInfGetWork.ThisSalesPricRgds + custAccRecInfGetWork.ThisSalesPricDis); // 返品・値引
            // 2009.03.02 30413 犬飼 返品、値引の符号を反転させる <<<<<<END
            newRow[Ct_CsDmd_ThisSalesTaxTotal] = custAccRecInfGetWork.OfsThisTimeSales + custAccRecInfGetWork.OfsThisSalesTax;   // 税込
            newRow[Ct_CsDmd_StartDateSpan] = TDateTime.DateTimeToLongDate(custAccRecInfGetWork.StMonCAddUpUpdDate); // 日付範囲（開始）
            newRow[Ct_CsDmd_EndDateSpan] = TDateTime.DateTimeToLongDate(custAccRecInfGetWork.AddUpDate); // 日付範囲（終了）
		    newRow[Ct_CsDmd_Name				]	= custAccRecInfGetWork.CustomerName; // 得意先名称
		    newRow[Ct_CsDmd_Name2				]	= custAccRecInfGetWork.CustomerName2; // 得意先名称2

		    int yy = 0;
		    int mm = 0;
		    int dd = 0;
		    string strGengo = "";
		    int status;

		    // 計上年月(印刷用)
		    status = TDateTime.SplitDate("YYYYMMDD", custAccRecInfGetWork.AddUpYearMonth,
		        ref strGengo,
		        ref yy,
		        ref mm,
		        ref dd);
		    if (status == 0)
		    {
				newRow[Ct_CsDmd_PrintAddUpYearMonth] = yy * 100 + mm;
		    }

		    // 計上年月日(印刷用)
			newRow[Ct_CsDmd_PrintAddUpDate] = TDateTime.DateTimeToLongDate( custAccRecInfGetWork.AddUpDate );

             // 返品・値引
            newRow[Col_CsDmd_RgdsDisT         ] = custAccRecInfGetWork.ThisSalesPricRgds + custAccRecInfGetWork.ThisSalesPricDis;

            // 黒伝伝票枚数
            newRow[Col_CsDmd_SalesSlipCount	  ]	= custAccRecInfGetWork.SalesSlipCount;	    

            newRow[Col_CsDmd_LastTimeAccRec	  ]	= custAccRecInfGetWork.LastTimeAccRec;                                            // 前回売掛金額

            newRow[Col_CsDmd_ThisTimeTtlBlcAcc]	= custAccRecInfGetWork.ThisTimeTtlBlcAcc;                                         // 今回繰越残高

            newRow[Col_CsDmd_TimeSalesTax     ] = custAccRecInfGetWork.OfsThisTimeSales + custAccRecInfGetWork.OfsThisSalesTax;   // 税込売上額
            
            newRow[Col_CsDmd_AfCalTMonthAccRec]	= custAccRecInfGetWork.AfCalTMonthAccRec;                                         // 計算後請求金額

		    newRow.EndEdit();

		    return newRow;
		}
		#endregion


        #region ◎ 顧客別計上年月範囲取得処理
        /// <summary>
		/// 顧客別計上年月範囲取得処理
		/// </summary>
		/// <param name="cutomerCode">得意先コード</param>
		/// <param name="viewSecCd">表示拠点コード</param>
		/// <remarks>
		/// <br>Note        : メソッド内容を説明します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
        public static void SetCustomerAddUpDateSpanAndAddUpDate(int cutomerCode, string viewSecCd)
		{
            //可視性をPrivte→Publicに変更
			string sort = Ct_CsDmd_ClaimCode + "," + Ct_CsDmd_AddUpSecCode + "," + Ct_CsDmd_AddUpDate;
			string filter = String.Format("{0} = {1} AND {2} = '{3}'", Ct_CsDmd_ClaimCode, cutomerCode, Ct_CsDmd_AddUpSecCode, viewSecCd);
			DataView dv = new DataView(_custDmdPrcDataTable, filter, sort, DataViewRowState.CurrentRows);

			// 全社レコードのみで絞り込む        

			if (dv.Count > 0)
			{
				CsLedgerDmdPrc csDmdPrc;

				// 開始取得
				csDmdPrc = DataRowToCsLedgerDmdPrc(dv[0].Row);
				_ttlAddUpDateSpanStart = TDateTime.LongDateToDateTime(csDmdPrc.StartDateSpan);
				_addUpDateStart = csDmdPrc.AddUpDate;

				// 終了取得
				csDmdPrc = DataRowToCsLedgerDmdPrc(dv[dv.Count - 1].Row);

				if ( ( csDmdPrc.CloseFlag == (int)CloseFlagState.NotClose ) &&  ( dv.Count > 1 ))
				{
					csDmdPrc = DataRowToCsLedgerDmdPrc(dv[dv.Count - 2].Row);
				}

				_ttlAddUpDateSpanEnd = TDateTime.LongDateToDateTime(csDmdPrc.EndDateSpan);
				_addUpDateEnd = csDmdPrc.AddUpDate;
			}
		}
		#endregion

		#region ◎ データ行より得意先請求情報(元帳照会用)取得
		/// <summary>
		/// データ行より得意先請求情報(元帳照会用)取得
		/// </summary>
		/// <param name="dr">データ行情報</param>
		/// <returns>得意先請求金額情報(元帳照会用に加工済み)</returns>
		/// <remarks>
		/// <br>Note        : データ行より元帳照会用に加工された得意先請求(鑑)情報を取得します。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static CsLedgerDmdPrc DataRowToCsLedgerDmdPrc(DataRow dr)
		{
			CsLedgerDmdPrc csLedgerDmdPrc = new CsLedgerDmdPrc();

			csLedgerDmdPrc.AddUpSecCode				= GetCellString		(dr[Ct_CsDmd_AddUpSecCode			]);		// 計上拠点コード
            csLedgerDmdPrc.ClaimCode				= GetCellInt32		(dr[Ct_CsDmd_ClaimCode			    ]);		// 請求先コード
			csLedgerDmdPrc.CustomerCode				= GetCellInt32		(dr[Ct_CsDmd_CustomerCode			]);		// 得意先コード
			csLedgerDmdPrc.AddUpDate				= GetCellDateTime	(dr[Ct_CsDmd_AddUpDate				]);		// 計上年月日
			csLedgerDmdPrc.AddUpYearMonth			= GetCellInt32		(dr[Ct_CsDmd_AddUpYearMonth			]);		// 計上年月
			csLedgerDmdPrc.LastTimeDemand			= GetCellInt64		(dr[Ct_CsDmd_LastTimeDemand			]);		// 前回請求金額
            csLedgerDmdPrc.SlipCount = GetCellInt32(dr[Col_CsDmd_SalesSlipCount]);		// 伝票枚数
			csLedgerDmdPrc.ThisTimeDmdNrml			= GetCellInt64		(dr[Ct_CsDmd_ThisTimeDmdNrml		]);		// 今回入金金額（通常入金）
			csLedgerDmdPrc.ThisTimeTtlBlcDmd		= GetCellInt64		(dr[Ct_CsDmd_ThisTimeTtlBlcDmd		]);		// 今回繰越残高（請求計）
            csLedgerDmdPrc.OfsThisTimeSales         = GetCellInt64      (dr[Ct_CsDmd_OfsThisTimeSales       ]);		// 相殺後今回売上金額
            csLedgerDmdPrc.OfsThisSalesTax          = GetCellInt64      (dr[Ct_CsDmd_OfsThisSalesTax        ]);		// 相殺後今回売上消費税
			csLedgerDmdPrc.ThisTimeSales			= GetCellInt64		(dr[Ct_CsDmd_ThisTimeSales			]);		// 今回売上金額
            csLedgerDmdPrc.AfCalDemandPrice			= GetCellInt64		(dr[Ct_CsDmd_AfCalDemandPrice		]);		// 計算後請求金額
			csLedgerDmdPrc.AcpOdrTtl2TmBfBlDmd		= GetCellInt64		(dr[Ct_CsDmd_AcpOdrTtl2TmBfBlDmd	]);		// 受注2回前残高（請求計）
			csLedgerDmdPrc.AcpOdrTtl3TmBfBlDmd		= GetCellInt64		(dr[Ct_CsDmd_AcpOdrTtl3TmBfBlDmd	]);		// 受注3回前残高（請求計）
			csLedgerDmdPrc.StartDateSpan			= GetCellInt32		(dr[Ct_CsDmd_StartDateSpan			]);		// 日付範囲(開始)
			csLedgerDmdPrc.EndDateSpan				= GetCellInt32		(dr[Ct_CsDmd_EndDateSpan			]);		// 日付範囲(終了)
			csLedgerDmdPrc.CloseFlag				= GetCellInt32		(dr[Ct_CsDmd_CloseFlag				]);		// 締済フラグ
   			csLedgerDmdPrc.CustTaxLayMethod			= GetCellInt32		(dr[Ct_CsDmd_ConsTaxLayMethod		]);		// 消費税転嫁方式
			return csLedgerDmdPrc;
		}

		#endregion

		#endregion

		#region ◆ データ取得
		/// <summary>
		/// データセル→文字列取得
		/// </summary>
		/// <param name="cell">データセル</param>
		/// <returns>取得文字列</returns>
		/// <remarks>
		/// <br>Note       : データセルに格納されている値がDBNullかどうかを判別して値を返します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		private static string GetCellString(object cell)
		{
			return (cell != DBNull.Value) ? (string)cell : string.Empty;
		}

		/// <summary>
		/// データセル→Int32取得
		/// </summary>
		/// <param name="cell">データセル</param>
		/// <returns>取得数値</returns>
		/// <remarks>
		/// <br>Note       : データセルに格納されている値がDBNullかどうかを判別して値を返します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		private static Int32 GetCellInt32(object cell)
		{
			return (cell != DBNull.Value) ? (Int32)cell : 0;
		}

		/// <summary>
		/// データセル→Int64取得
		/// </summary>
		/// <param name="cell">データセル</param>
		/// <returns>取得数値</returns>
		/// <remarks>
		/// <br>Note       : データセルに格納されている値がDBNullかどうかを判別して値を返します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		private static Int64 GetCellInt64(object cell)
		{
			return (cell != DBNull.Value) ? (Int64)cell : 0;
		}

		/// <summary>
		/// データセル→DateTime取得
		/// </summary>
		/// <param name="cell">データセル</param>
		/// <returns>取得DateTime</returns>
		/// <remarks>
		/// <br>Note       : データセルに格納されている値がDBNullかどうかを判別して値を返します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		private static DateTime GetCellDateTime(object cell)
		{
			return (cell != DBNull.Value) ? (DateTime)cell : new DateTime(1, 1, 1);
		}
		#endregion
		#endregion

		#region ■ Public Method
		#region ◆ 変数初期化関連
		#region ◎ 初期設定情報読込
		/// <summary>
		/// 初期設定情報読込
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 初期設定情報の読込を行います。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public int InitSettingDataRead(string enterpriseCode, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			message = string.Empty;

			try
			{
				// 自拠点コードが設定されていない場合
				if (_mySectionCode == string.Empty)
				{
					message = "ログイン担当者の所属拠点が設定されていません\n\r拠点設定を行って起動してください";
					return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
				}

				// 拠点情報取得
				_sectionHTable.Clear();
				_secCodeList.Clear();

				foreach (SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)
				{
					_sectionHTable.Add(secInfoSet.SectionCode, secInfoSet.Clone());
					_secCodeList.Add(secInfoSet.SectionCode);
				}
				_secCodeList.Sort(new SecInfoKey0());

				// 残高表示拠点取得
				status = GetOwnSeCtrlCode(_mySectionCode, SecInfoAcs.CtrlFuncCode.BalanceDispSecCd, out _targetSectionCode);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						message = String.Format("拠点コード 「{0}」の残高表示拠点が設定されていません", _mySectionCode)
											+ "\n\r拠点制御設定を行って起動してください";
						return status;
					}
					default:
					{
						message = String.Format("拠点コード 「{0}」の拠点制御情報の取得に失敗しました", _mySectionCode)
											+ "\n\r拠点制御設定を行って起動してください";
						return status;
					}
				}

				// 本社機能有無
				_isMainOfficeFunc = (_secInfoAcs.GetMainOfficeFuncFlag(_mySectionCode) == 1);

				if ( _alItmDspNmAcs == null )
					_alItmDspNmAcs = new AlItmDspNmAcs();

				// 全体項目表示設定の取得 
				status = _alItmDspNmAcs.ReadStatic(out _alItmDspNmData, enterpriseCode);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						break;
					default:
						message = "全体項目表示設定の読み込みに失敗しました";
						break;
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return status;
		}
		#endregion

		#region ◎ 帳票出力設定読込
		/// <summary>
		/// 帳票出力設定読込
		/// </summary>
		/// <param name="prtOutSet">帳票出力設定データクラス</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			prtOutSet = null;
			message = string.Empty;

			// Staticに保持済みの場合
			if (_prtOutSetData != null)
			{
				prtOutSet = _prtOutSetData.Clone();
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}

			try
			{
				// 帳票出力設定アクセスクラス
				if (_prtOutSetAcs == null)
					_prtOutSetAcs = new PrtOutSetAcs();

				status = _prtOutSetAcs.Read(out _prtOutSetData, LoginInfoAcquisition.EnterpriseCode, _mySectionCode);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						prtOutSet = _prtOutSetData.Clone();
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						prtOutSet = new PrtOutSet();
						break;
					}
					default:
					{
						prtOutSet = new PrtOutSet();
						message = "帳票出力設定の読込に失敗しました";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return status;
		}
		#endregion

		#region ◎ 全体項目表示設定データクラス取得
		/// <summary>
		/// 全体項目表示設定データクラス取得
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>全体項目表示設定データクラス</returns>
		/// <remarks>
		/// <br>Note       : 全体項目表示設定データクラスの取得を行います。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public AlItmDspNm GetAlItmDspNm(string enterpriseCode)
		{
			AlItmDspNm alItmDspNm = null;

			// Staticにすでにあればそれを返す
			if (_alItmDspNmData != null)
			{
				alItmDspNm = _alItmDspNmData.Clone();
			}
			else
			{
				this.ReadAlItmDspNm(out alItmDspNm, enterpriseCode);
			}

			return alItmDspNm;
		}
		#endregion

		#region ◎ 全体項目表示設定読込み
		/// <summary>
		/// 全体項目表示設定読込み
		/// </summary>
		/// <param name="alItmDspNm">全体項目表示設定データクラス</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>0:正常,4:データ無し,その他:異常</returns>
		/// <remarks>
		/// <br>Note       : 全体項目表示設定データクラスの取得を行います。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		private int ReadAlItmDspNm(out AlItmDspNm alItmDspNm, string enterpriseCode)
		{
			if (_alItmDspNmAcs == null) _alItmDspNmAcs = new AlItmDspNmAcs();
			
			// 全体項目表示設定の取得 
			int status = _alItmDspNmAcs.ReadStatic(out alItmDspNm, enterpriseCode);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					break;
				}
				default:
				{
					break;
				}
			}
			return status;
		}
		#endregion

		#region ◎ 本社機能有無取得
		/// <summary>
		/// 本社機能有無取得
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>true: 本社,false: 拠点</returns>
		/// <remarks>
		/// <br>Note       : 本社機能有無チェックを行います。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool CheckMainOfficeFunc(string sectionCode)
		{
			return (_secInfoAcs.GetMainOfficeFuncFlag(sectionCode) == 1);
		}
		#endregion

		#region ◎ 制御機能拠点取得
		/// <summary>
		/// 制御機能拠点取得
		/// </summary>
		/// <param name="sectionCode">対象拠点コード</param>
		/// <param name="ctrlFuncCode">取得する制御機能コード</param>
		/// <param name="ctrlSectionCode">対象制御拠点コード</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 該当拠点の拠点制御情報の読込を行います。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public int GetOwnSeCtrlCode(string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode, out string ctrlSectionCode)
		{
			// 対象制御拠点の初期値は自拠点
			ctrlSectionCode = sectionCode;

			SecInfoSet secInfoSet;
            int status = _secInfoAcs.GetSecInfo(sectionCode, out secInfoSet);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if (secInfoSet != null)
				{
					ctrlSectionCode = secInfoSet.SectionCode;
				}
				else
				{
					// 拠点制御設定がされていない
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}

			return status;
		}
		#endregion
		#endregion ◆ 変数初期化関連

		#region ◆ 元帳照会データ取得関連
		#region ◎ 元帳照会データ取得処理
		/// <summary>
		/// 元帳照会データ取得処理
		/// </summary>
		/// <param name="mode">読込モード[0:請求,1:売掛]</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
        /// <param name="startCustomerCode">開始得意先コード</param>
        /// <param name="endCustomerCode">終了得意先コード</param>
        /// <param name="stratdt">検索範囲(開始)</param>
		/// <param name="enddt">検索範囲(終了)</param>
		/// <param name="sectionCode">対象拠点コード</param>
		/// <param name="sectionCodeList">拠点コードリスト</param>
		/// <param name="isBufferClear">StaticMemory初期化フラグ[True:初期化する, False:初期化しない]</param>
		/// <param name="message">エラーメッセージ</param>
        /// <param name="outMoneyDiv">出力金額区分</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 対象得意先の元帳照会データを取得します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
        public int Read(int mode, string enterpriseCode, int customerCode, int startCustomerCode, int endCustomerCode, int stratdt, int enddt, string sectionCode, ArrayList sectionCodeList, bool isBufferClear, out string message, int outMoneyDiv)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			message = "";
            _imode = mode;

			try
			{
				// 静的領域同期化処理
				lock (typeof(CsLedgerDmdAcs))
				{
					// StaticMemory　初期化
					if ( isBufferClear )
						InitializeCustomerLedger();

					switch (mode)
					{
						case 0:
							// 請求KINGETCALL
                            status = SeiKingetCall(enterpriseCode, customerCode, startCustomerCode, endCustomerCode, stratdt, enddt, sectionCode, sectionCodeList, outMoneyDiv);
                            break;
						case 1:
							// 売掛KINGETCALL
                            status = UriKingetCall(enterpriseCode, customerCode, startCustomerCode, endCustomerCode, stratdt, enddt, sectionCode, sectionCodeList, outMoneyDiv);
                            break;
						default:
							break;
					}
				}
			}
			catch (CsLedgerException ex)
			{
				status = ex.Status;
				message = ex.Message;
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return status;
		}
		#endregion

		#region ◎ 元帳明細情報フィルタリング処理
		/// <summary>
		/// 元帳明細情報フィルタリング処理
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="startDate">計上年月日(開始)</param>
		/// <param name="endDate">計上年月日(終了)</param>
		/// <param name="sectionCode">計上拠点コード</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 元帳明細を指定の計上年月日でフィルタリングします。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public void FilterAddUpDateCsLedgerSlip(int customerCode, int startDate, int endDate, string sectionCode)
		{
			FilterAddUpDateCsLedgerSlip(customerCode, startDate, endDate, sectionCode, ref _csLedgerSlipDataView);
		}
		#endregion

        #region ◎ 元帳明細情報フィルタリング処理
        /// <summary>
        /// 元帳明細情報フィルタリング処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="startDate">計上年月日(開始)</param>
        /// <param name="endDate">計上年月日(終了)</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 元帳明細を指定の計上年月日でフィルタリングします。</br>
        /// <br>Programer  : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.18</br>
        /// </remarks>
        public void FilterAddUpDateCsLedgerDtl(int customerCode, int startDate, int endDate, string sectionCode)
        {
            FilterAddUpDateCsLedgerDtl(customerCode, startDate, endDate, sectionCode, ref _csLedgerDtlDataView);
        }
        #endregion

		#region ◎ 元帳照会明細情報フィルタリング処理
        /// <summary>
        /// 元帳照会明細情報フィルタリング処理(明細情報)
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="startDate">計上年月日(開始)</param>
        /// <param name="endDate">計上年月日(終了)</param>
        /// <param name="sectionCode">計上拠点コード</param>
        /// <param name="dv">フィルタ後DataView</param>
        /// <remarks>
        /// <br>Note       : 元帳照会明細を指定の計上年月日でフィルタリングします。(明細情報)</br>
        /// <br>Programer  : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.10.18</br>
        /// </remarks>
        public void FilterAddUpDateCsLedgerDtl(int customerCode, int startDate, int endDate, string sectionCode, ref DataView dv)
        {
            string querry = "";
            string secCodeBalnce = "";
            string secCode = "";

            secCodeBalnce = sectionCode;
            secCode = sectionCode;

            // 計上範囲指定
            if (startDate != endDate)
            {
                querry = String.Format("{0} = {1} AND {2} <= {3} AND (({4} = 0 AND {5} = {6} AND {7} = '{8}') OR ({9} IN (1,3) AND {10} = '{11}')) ",
                    Ct_CsLedgerDtl_ClaimCode,
                    customerCode,
                    Ct_CsLedgerDtl_AddUpADateInt,
                    endDate.ToString(),
                    Ct_CsLedgerDtl_BalanseCode,
                    Ct_CsLedgerDtl_AddUpDate,
                    startDate.ToString(),
                    Ct_CsLedgerDtl_AddUpSecCode,
                    secCodeBalnce,
                    Ct_CsLedgerDtl_BalanseCode,
                    Ct_CsLedgerDtl_AddUpSecCode,
                    secCode);

                querry += String.Format(" OR ({0}={1} AND {2}='{3}')",
                    Ct_CsLedgerDtl_BalanseCode, (int)LedgerDtlBalanseState.ConsTax,
                    Ct_CsLedgerDtl_AddUpSecCode, secCode);

                dv.RowFilter = querry;
            }

            // 単月指定
            else
            {

                querry = String.Format("{0} = {1} AND {2} = {3} AND (({4} IN (0,1,3) AND {5} = '{6}')",
                    Ct_CsLedgerDtl_ClaimCode,
                    customerCode,
                    Ct_CsLedgerDtl_AddUpDate,
                    startDate.ToString(),
                    Ct_CsLedgerDtl_BalanseCode,
                    Ct_CsLedgerDtl_AddUpSecCode,
                    secCode);

                querry += String.Format(" OR ({0}={1} AND {2}='{3}'))",
                    Ct_CsLedgerDtl_BalanseCode, (int)LedgerDtlBalanseState.ConsTax,
                    Ct_CsLedgerDtl_AddUpSecCode, secCode);

                dv.RowFilter = querry;

            }
        }

		/// <summary>
		/// 元帳照会明細情報フィルタリング処理(伝票一覧)
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="startDate">計上年月日(開始)</param>
		/// <param name="endDate">計上年月日(終了)</param>
		/// <param name="sectionCode">計上拠点コード</param>
		/// <param name="dv">フィルタ後DataView</param>
		/// <remarks>
        /// <br>Note       : 元帳照会明細を指定の計上年月日でフィルタリングします。(伝票一覧)</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public void FilterAddUpDateCsLedgerSlip(int customerCode, int startDate, int endDate, string sectionCode, ref DataView dv)
		{
			string querry = "";
			string secCodeBalnce = "";
			string secCode = "";

			secCodeBalnce = sectionCode;
			secCode = sectionCode;

			// 計上範囲指定
			if (startDate != endDate)
			{
				querry = String.Format("{0} = {1} AND {2} <= {3} AND (({4} = 0 AND {5} = {6} AND {7} = '{8}') OR ({9} IN (1,3) AND {10} = '{11}')) ",
				    Ct_CsLedger_ClaimCode,
				    customerCode,
				    Ct_CsLedger_AddUpADateInt,
				    endDate.ToString(),
				    Ct_CsLedger_BalanseCode,
				    Ct_CsLedger_AddUpDate,
				    startDate.ToString(),
				    Ct_CsLedger_AddUpSecCode,
				    secCodeBalnce,
				    Ct_CsLedger_BalanseCode,
				    Ct_CsLedger_AddUpSecCode,
				    secCode);

			    querry += String.Format(" OR ({0}={1} AND {2}='{3}')",
			        Ct_CsLedger_BalanseCode, (int)LedgerDtlBalanseState.ConsTax,
			        Ct_CsLedger_AddUpSecCode, secCode);

				dv.RowFilter = querry;
			}

			// 単月指定
			else
			{

				querry = String.Format("{0} = {1} AND {2} = {3} AND (({4} IN (0,1,3) AND {5} = '{6}')",
					Ct_CsLedger_ClaimCode,
					customerCode,
					Ct_CsLedger_AddUpDate,
					startDate.ToString(),
					Ct_CsLedger_BalanseCode,
					Ct_CsLedger_AddUpSecCode,
					secCode);

				querry += String.Format(" OR ({0}={1} AND {2}='{3}'))",
					Ct_CsLedger_BalanseCode, (int)LedgerDtlBalanseState.ConsTax,
					Ct_CsLedger_AddUpSecCode, secCode);

				dv.RowFilter = querry;

			}

			// 残高再計算
			CalculattonNowBalance(ref dv);
		}
		#endregion

		#region ◎ 残高再計算処理
		/// <summary>
		/// 残高再計算処理
		/// </summary>
		/// <param name="dv">データビュー</param>
		/// <remarks>
		/// <br>Note       : 引数で渡されたDataViewに対して残高の計算を行います。</br>
		/// <br>Programer	: 20081 疋田 勇人</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static void CalculattonNowBalance(ref DataView dv)
		{
			Int64 balance = 0;

			for (int index = 0; index < dv.Count; index++)
			{
				DataRowView drv = dv[index];

				// 前残の場合
				if (GetCellInt32(drv[Ct_CsLedger_BalanseCode]) == (int)LedgerDtlBalanseState.Balance)
				{
					// 前残レコードが存在する場合のみ残高を保持
					balance = GetCellInt64(drv[Ct_CsLedger_Balance]);
				}

				Int64 deposit		= GetCellInt64(drv[Ct_CsLedger_Deposit			]);	// 入金額
				Int64 sales			= GetCellInt64(drv[Ct_CsLedger_SalesTotal		]);	// 売上
				Int64 salesTax		= GetCellInt64(drv[Ct_CsLedger_SalesSubtotalTax	]);	// 売上消費税

				// 残高変更
				drv.BeginEdit();
				// Todo:明細の残高がおかしくなったらここガ原因
				balance += sales + salesTax - deposit; // 残高=売上+売上消費税-入金
                
				drv[Ct_CsLedger_Balance	] = balance;
				drv.EndEdit();
			}
		}
		#endregion

		#region ◎ 元帳照会データ初期化処理
		/// <summary>
		/// 元帳照会データ初期化処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : Static情報を初期化します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public void InitializeCustomerLedger()
		{
			_addUpDateStart = new DateTime(1, 1, 1);
			_addUpDateEnd = new DateTime(1, 1, 1);
			_ttlAddUpDateSpanStart = new DateTime(1, 1, 1);
			_ttlAddUpDateSpanEnd = new DateTime(1, 1, 1);

			// テーブル行初期化
			_csLedgerCustomerHTable.Clear();
			_csLedgerSlipDataTable.Rows.Clear();
            _csLedgerDtlDataTable.Rows.Clear();
            _csLedgerBlanceDataTable.Rows.Clear();
			_custDmdPrcDataTable.Rows.Clear();
			//_custDmdPrcPrintDataTable.Rows.Clear();

			_depsitHTable.Clear();

			// 初期ソート条件設定    
			_custDmdPrcDataView.Sort = Ct_CsDmd_AddUpSecCode + "," + Ct_CsDmd_ClaimCode + "," + Ct_CsDmd_AddUpDate;
            _csLedgerSlipDataView.Sort = Ct_CsLedger_ClaimCode + "," + Ct_CsLedger_AddUpDate + "," + Ct_CsLedger_BalanseCode + "," + Ct_CsLedger_AddUpADateInt + "," + Ct_CsLedger_RecordCode + "," + Ct_CsLedger_SlipNo;
            _csLedgerDtlDataView.Sort = Ct_CsLedgerDtl_ClaimCode + "," + Ct_CsLedgerDtl_AddUpDate + "," + Ct_CsLedgerDtl_BalanseCode + "," + Ct_CsLedgerDtl_AddUpADateInt + "," + Ct_CsLedgerDtl_RecordCode + "," + Ct_CsLedgerDtl_SlipNo + "," + Ct_CsLedgerDtl_SalesRowNo;
            _csLedgerBlanceDataView.Sort = Ct_CsLedgerBlance_AddUpSecCode + "," + Ct_CsLedgerBlance_ClaimCode + "," + Ct_CsLedgerBlance_AddUpDate;

			// フィルター条件初期化
			_custDmdPrcDataView.RowFilter = "";
			_csLedgerSlipDataView.RowFilter = "";
            _csLedgerDtlDataView.RowFilter = "";
            _csLedgerBlanceDataView.RowFilter = "";
		}
		#endregion
		#endregion

		#region ◆ 鑑データ作成関連
		#region ◎ 得意先元帳用鑑データ配列取得
		/// <summary>
		/// 得意先元帳用鑑データ配列取得
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="csLedgerDmdPrc">得意先元帳用鑑データ配列</param>
		/// <param name="msg">メッセージ</param>
		/// <returns>true:取得成功,false:データなし</returns>
		/// <remarks>
		/// <br>Note       : 得意先元帳用鑑データを取得します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool SearchCustDmdPrcToList(string sectionCode, out CsLedgerDmdPrc[] csLedgerDmdPrc, out string msg)
		{
			return SearchCustDmdPrcToList(0, sectionCode, out csLedgerDmdPrc, out msg);
		}
		#endregion

		#region ◎ 得意先元帳用鑑データ配列取得
		/// <summary>
		/// 得意先元帳用鑑データ配列取得(締フラグ指定)
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="customerCode">得意先ｺｰﾄﾞ</param>
		/// <param name="addupDate">計上年月日</param>
		/// <param name="csLedgerDmdPrc">得意先元帳用鑑データ配列</param>
		/// <param name="msg">メッセージ</param>
		/// <returns>true:取得成功,false:データなし</returns>
		/// <remarks>
		/// <br>Note       : 得意先元帳用鑑データを取得します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.05.14</br>
		/// </remarks>
		public bool ReadCustDmdPrcToList(string sectionCode, int customerCode, int addupDate, out CsLedgerDmdPrc[] csLedgerDmdPrc, out string msg)
		{
			CsLedgerDmdPrc[] csLedgerDmdPrcWork;
			csLedgerDmdPrc = null;
			// 指定した得意先の鑑データを全て取得
			bool isStatus = SearchCustDmdPrcToList(customerCode, sectionCode, out csLedgerDmdPrcWork, out msg);

			// 指定された計上日のデータを取得
			if ( isStatus )
			{
				if ( csLedgerDmdPrcWork.Length > 0 )
				{
					for( int index = 0; index < csLedgerDmdPrcWork.Length; index++ )
					{
						if (TDateTime.DateTimeToLongDate( csLedgerDmdPrcWork[index].AddUpDate ) == addupDate )
						{
							csLedgerDmdPrc = new CsLedgerDmdPrc[1];
							csLedgerDmdPrc[0] = csLedgerDmdPrcWork[index];
							break;
						}
					}
				}
			}

			return isStatus;
		}
		#endregion

		#region ◎ 得意先元帳用鑑データ配列取得(得意先指定)
		/// <summary>
		/// 得意先元帳用鑑データ配列取得(得意先指定)
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="csLedgerDmdPrc">得意先元帳用鑑データ配列</param>
		/// <param name="msg">メッセージ</param>
		/// <returns>true:取得成功,false:データなし</returns>
		/// <remarks>
		/// <br>Note       : 得意先元帳用鑑データを取得します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool SearchCustDmdPrcToList(int customerCode, string sectionCode, out CsLedgerDmdPrc[] csLedgerDmdPrc, out string msg)
		{
			csLedgerDmdPrc = null;
			ArrayList csLedgerDmdList;
			bool exist = SearchCustDmdPrcToArray(customerCode, sectionCode, out csLedgerDmdList, out msg);
			if (exist)
			{
				csLedgerDmdPrc = (CsLedgerDmdPrc[])csLedgerDmdList.ToArray(typeof(CsLedgerDmdPrc));
			}
			return exist;
		}
		#endregion

		#region ◎ 得意先元帳用鑑データ配列取得
		/// <summary>
		/// 得意先元帳用鑑データ配列取得
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="csLedgerDmdList">得意先元帳用鑑データリスト</param>
		/// <param name="msg">メッセージ</param>
		/// <returns>true:取得成功,false:データなし</returns>
		/// <remarks>
		/// <br>Note       : 得意先元帳用鑑データを取得します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool SearchCustDmdPrcToArray(string sectionCode, out ArrayList csLedgerDmdList, out string msg)
		{
			return SearchCustDmdPrcToArray(0, sectionCode, out csLedgerDmdList, out msg);
		}
		#endregion

		#region ◎ 得意先元帳用鑑データリスト取得(得意先指定)
		/// <summary>
		/// 得意先元帳用鑑データリスト取得(得意先指定)
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="csLedgerDmdList">得意先元帳用鑑データリスト</param>
		/// <param name="msg">メッセージ</param>
		/// <returns>true:取得成功,false:データなし</returns>
		/// <remarks>
		/// <br>Note       : 得意先元帳用鑑データを取得します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool SearchCustDmdPrcToArray(int customerCode, string sectionCode, out ArrayList csLedgerDmdList, out string msg)
		{
			csLedgerDmdList = null;
			msg = string.Empty;

			if (_custDmdPrcDataTable.Rows.Count > 0)
			{
				StringBuilder filter = new StringBuilder(String.Format("{0}='{1}'", Ct_CsDmd_AddUpSecCode, sectionCode));

				// 得意先コードが指定されている場合
				if (customerCode != 0)	filter.Append(String.Format(" AND {0}={1}", Ct_CsDmd_ClaimCode, customerCode));

				string sort		= Ct_CsDmd_AddUpSecCode + "," + Ct_CsDmd_ClaimCode + "," + Ct_CsDmd_AddUpDate;

				// 得意先元帳用鑑データ金額情報リスト取得
				csLedgerDmdList = this.GetCsLedgerDmdPrcList(filter.ToString(), sort);

				return true;
			}
			else
			{
				msg = "取引がありません。";
				return false;
			}
		}
		#endregion

		#region ◎ 得意先元帳照会用鑑データDataView取得
		/// <summary>
		/// 得意先元帳照会用鑑データDataView取得
		/// </summary>
		/// <param name="sectionCode">指定拠点コード</param>
		/// <param name="dv">得意先金額DataView</param>
		/// <param name="msg">メッセージ</param>
		/// <returns>true:取得成功,false:データなし</returns>
		/// <remarks>
		/// <br>Note       : 得意先元帳照会用鑑データを取得します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool GetStaticCustDmdPrcToDataView(string sectionCode, out DataView dv, out string msg)
		{
			dv = null;
			msg = "取引がありません。";

			if (_custDmdPrcDataTable.Rows.Count > 0)
			{
				string filter = String.Format("{0}='{1}'", Ct_CsDmd_AddUpSecCode, sectionCode);
				string sort = Ct_CsDmd_AddUpSecCode + "," + Ct_CsDmd_ClaimCode + "," + Ct_CsDmd_AddUpDate;

				dv = new DataView(_custDmdPrcDataTable, filter, sort, DataViewRowState.CurrentRows);

				if (dv.Count > 0) return true;
			}

			return false;
		}
		#endregion

		#region ◎ 元帳照会得意先情報(static memory)の取得
		/// <summary>
		/// 元帳照会得意先情報(static memory)の取得
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>元帳照会得意先情報データクラス</returns>
		/// <remarks>
		/// <br>Note       : 得意先情報を取得します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public CsLedgerCustomer CustomerInfo(int customerCode)
		{
			if (_csLedgerCustomerHTable.Contains(customerCode))
			{
				CsLedgerCustomer cs = (CsLedgerCustomer)_csLedgerCustomerHTable[customerCode];
				return cs.Clone();
			}
			else
			{
				return new CsLedgerCustomer();
			}
		}
		#endregion

		#region ◎ 元帳得意先情報(static memory)の取得
		/// <summary>
		/// 元帳得意先情報(static memory)の取得
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
        /// <param name="addUpdate">計上日</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>元帳得意先情報データクラス</returns>
		/// <remarks>
		/// <br>Note       : 得意先情報を取得します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public CsLedgerCustomer CustomerInfo(int customerCode,int addUpdate,string sectionCode)
		{
            string key = customerCode.ToString() + "_" + addUpdate.ToString() + "_" + sectionCode;
			if (_csLedgerCustomerHTable.Contains(key))
			{
				CsLedgerCustomer cs = (CsLedgerCustomer)_csLedgerCustomerHTable[key];
				return cs.Clone();
			}
			else
			{
				return new CsLedgerCustomer();
			}
		}
		#endregion
		
		#region ◎ 元帳得意先金額合計情報(static memory)の取得
		/// <summary>
		/// 元帳得意先金額合計情報(static memory)の取得
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="sectionCode">指定拠点コード</param>
		/// <param name="csLedgerDmdPrc">得意先元帳支払金額合計情報</param>
		/// <param name="msg">エラーメッセージ</param>
		/// <returns>true:取得成功,false:データなし</returns>
		/// <remarks>
		/// <br>Note       : 得意先金額の合計情報を取得します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool GetTotalCustDmdPrc(int customerCode, string sectionCode, out CsLedgerDmdPrc csLedgerDmdPrc, out string msg)
		{
			msg = string.Empty;
			csLedgerDmdPrc = null;
			int totalCleateCounter = 0;

			ArrayList custDmdPrcList;

			if (SearchCustDmdPrcToArray(customerCode, sectionCode, out custDmdPrcList, out msg))
			{
				csLedgerDmdPrc = new CsLedgerDmdPrc();

				for (int index = 0; index < custDmdPrcList.Count; index++)
				{
					CsLedgerDmdPrc wkCsLedgeDmdPrc = (CsLedgerDmdPrc)custDmdPrcList[index];

					// 締済みデータは鑑に加えない
					if ( wkCsLedgeDmdPrc.CloseFlag == (int)CloseFlagState.NotClose )
						continue;

					// 合計タブ作成判断カウンター
					totalCleateCounter++;

					if (index == 0)
					{
						
						csLedgerDmdPrc.AddUpSecCode			= wkCsLedgeDmdPrc.AddUpSecCode;				// 拠点コード
                        csLedgerDmdPrc.ClaimCode            = wkCsLedgeDmdPrc.ClaimCode;                // 請求先コード

						csLedgerDmdPrc.CustomerCode			= wkCsLedgeDmdPrc.CustomerCode;				// 得意先コード
						// 3回前残高,2回前残高,前回残高,計算ご請求金額は先頭レコードの金額情報
						csLedgerDmdPrc.AcpOdrTtl3TmBfBlDmd	= wkCsLedgeDmdPrc.AcpOdrTtl3TmBfBlDmd;		// 受注3回前残高
						csLedgerDmdPrc.AcpOdrTtl2TmBfBlDmd	= wkCsLedgeDmdPrc.AcpOdrTtl2TmBfBlDmd;		// 受注2回前残高
						csLedgerDmdPrc.LastTimeDemand		= wkCsLedgeDmdPrc.LastTimeDemand;			// 前回請求金額
					}
					
					csLedgerDmdPrc.ThisTimeDmdNrml		+= wkCsLedgeDmdPrc.ThisTimeDmdNrml;		// 今回入金金額（通常入金）
					csLedgerDmdPrc.ThisTimeTtlBlcDmd	+= wkCsLedgeDmdPrc.ThisTimeTtlBlcDmd;	// 今回繰越残高（請求計）
                    csLedgerDmdPrc.OfsThisTimeSales     += wkCsLedgeDmdPrc.OfsThisTimeSales;    // 相殺後今回売上金額
                    csLedgerDmdPrc.OfsThisSalesTax      += wkCsLedgeDmdPrc.OfsThisSalesTax;     // 相殺御今回売上消費税          
					csLedgerDmdPrc.ThisTimeSales		+= wkCsLedgeDmdPrc.ThisTimeSales;		// 今回売上金額
				}
				
				if ( totalCleateCounter < 2 )
				{
					return false;
				}
				
				// Todo:鑑の合計がおかしかったらここがおかしい
				int listCount = custDmdPrcList.Count;
				int afCalDemandIndex = 1;
				if ( ((CsLedgerDmdPrc)custDmdPrcList[listCount - afCalDemandIndex ]).CloseFlag == (int)CloseFlagState.NotClose &&
					listCount > 1)
					afCalDemandIndex = 2;
				else
					// 最終レコードが未締めの場合
					// 最終レコードの一個手前の計算後請求金額が合計タブの計算後請求金額になる
					// 件数が未締の一軒しかない場合は最後のレコードをとるしかない
					afCalDemandIndex = 1;

				// 残高
				csLedgerDmdPrc.AfCalDemandPrice = ((CsLedgerDmdPrc)custDmdPrcList[listCount - afCalDemandIndex ]).AfCalDemandPrice;

				//最終の計上日を戻す(合計タブが選択された時に鑑に表示される転嫁方式はこの月の設定になる)
				csLedgerDmdPrc.AddUpDate = ((CsLedgerDmdPrc)custDmdPrcList[listCount - afCalDemandIndex ]).AddUpDate;

				csLedgerDmdPrc.StartDateSpan		= TDateTime.DateTimeToLongDate(_ttlAddUpDateSpanStart);		// 締対象日付範囲（開始）
				csLedgerDmdPrc.EndDateSpan			= TDateTime.DateTimeToLongDate(_ttlAddUpDateSpanEnd);		// 締対象日付範囲（終了）

				csLedgerDmdPrc.CloseFlag			= (int)CloseFlagState.Close;		// 締対象日付範囲（終了）
				return true;
			}
			else
			{
				return false;

			}
		}


		#endregion

		#endregion

		#region ◆ 得意先情報取得
		#region ◎ 元帳得意先金額情報(Static Memory)の取得(得意先指定)
		/// <summary>
		/// 元帳得意先金額情報(Static Memory)の取得(得意先指定)
		/// </summary>
		/// <param name="customerCode">指定得意先コード</param>
		/// <param name="sectionCode">指定拠点コード</param>
		/// <param name="addUpDate">指定計上年月日</param>
		/// <param name="csLedgerDmdPrc">請求金額データクラス</param>
		/// <param name="msg">メッセージ</param>
		/// <returns>true:取得成功,false:データなし</returns>
		/// <remarks>
		/// <br>Note       : 指定得意先、拠点、計上年月日の請求金額レコードを取得します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool GetDmdPrc(int customerCode, string sectionCode, int addUpDate, out CsLedgerDmdPrc csLedgerDmdPrc, out string msg)
		{
			msg = string.Empty;

			if (_custDmdPrcDataTable.Rows.Count != 0)
			{
				string sort = Ct_CsDmd_AddUpSecCode + "," + Ct_CsDmd_ClaimCode + "," + Ct_CsDmd_AddUpDate;
				
				DataView dv = new DataView(_custDmdPrcDataTable, string.Empty, sort, DataViewRowState.CurrentRows);

				DateTime dtaddUpDate = DateConverter.GetDateTimeFromYYYYMMDD(addUpDate);

				object[] findKey = new object[] { sectionCode, customerCode, dtaddUpDate };

				// ビューを検索(存在しない場合は-1が戻る)
				int index = dv.Find(findKey);

				if (index < 0)
				{
					// 空レコードを作る
					csLedgerDmdPrc = new CsLedgerDmdPrc();
				}
				else
				{
					csLedgerDmdPrc = DataRowToCsLedgerDmdPrc(dv[index].Row);
				}
				return true;
			}
			else
			{
				msg = "取引がありません。";
				csLedgerDmdPrc = null;
				return false;
			}
		}
		#endregion
		#endregion

		#endregion ■ Public Method

		#region ■ Private Method
		/// <summary>
		/// 得意先元帳照会用鑑データリスト取得
		/// </summary>
		/// <param name="filter">フィルタ</param>
		/// <param name="sort">ソート</param>
		/// <returns>得意先元帳照会用鑑データリスト</returns>
		/// <remarks>
		/// <br>Note       : 条件に合った得意先元帳照会用鑑データをリストで返します。
		///					 条件に合うものが１件も無い場合には空レコードを１件追加して返します。</br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		private ArrayList GetCsLedgerDmdPrcList(string filter, string sort)
		{
			ArrayList csLedgerDmdPrcList = new ArrayList();

			DataView dv = new DataView(_custDmdPrcDataTable, filter, sort, DataViewRowState.CurrentRows);
			if (dv.Count == 0)
			{
				// 空レコード作成
				csLedgerDmdPrcList.Add(new CsLedgerDmdPrc());
			}
			else
			{
				for (int index = 0; index < dv.Count; index++)
				{
					csLedgerDmdPrcList.Add(DataRowToCsLedgerDmdPrc(dv[index].Row));
				}
			}

			return csLedgerDmdPrcList;
		}
		#endregion ■ Private Method

		// ===================================================================================== //
		// 例外クラス
		// ===================================================================================== //
		#region 例外クラス
		private class CsLedgerException : ApplicationException
		{
			private int _status;

			#region constructor
			public CsLedgerException(string message, int status)
				: base(message)
			{
				this._status = status;
			}
			#endregion

			#region public property
			public int Status
			{
				get { return this._status; }
			}
			#endregion
		}
		#endregion

		#region InnerClass DateTime ← Int32変換クラス
		private class DateConverter
		{
			/// <summary>
			/// DateTime値取得(Int32 YYYYMMDDより)
			/// </summary>
			/// <param name="dateInt32">YYYYMMDD(Int32)</param>
			/// <returns>DateTime値</returns>
			public static DateTime GetDateTimeFromYYYYMMDD(Int32 dateInt32)
			{
				if (dateInt32 == 0) return DateTime.MinValue;
				else
				{
					try
					{
						if (dateInt32 == 0) return DateTime.MinValue;
						else if (dateInt32 == 99999999) return DateTime.MaxValue;
						else
						{
							int yyyy = dateInt32 / 10000;
							int mm = (dateInt32 % 10000) / 100;
							int dd = dateInt32 % 100;
							DateTime retDate = new DateTime(yyyy, mm, dd);
							return retDate;
						}
					}
					//正常範囲日付で無ければ最小値をセット
					catch (Exception)
					{
						return DateTime.MinValue;
					}
				}
			}

			/// <summary>
			/// DateTime値取得(Int32 YYYYMMより)
			/// </summary>
			/// <param name="dateInt32">YYYYMM(Int32)</param>
			/// <returns>DateTime値</returns>
			public static DateTime GetDateTimeFromYYYYMM(Int32 dateInt32)
			{
				if (dateInt32 == 0) return DateTime.MinValue;
				else
				{
					try
					{
						if (dateInt32 == 0) return DateTime.MinValue;
						else if (dateInt32 == 999999) return DateTime.MaxValue;
						else
						{
							int yyyy = dateInt32 / 100;
							int mm = dateInt32 % 100;
							int dd = DateTime.DaysInMonth(yyyy, mm);
							DateTime retDate = new DateTime(yyyy, mm, dd);
							return retDate;
						}
					}
					//正常範囲日付で無ければ最小値をセット
					catch (Exception)
					{
						return DateTime.MinValue;
					}
				}
			}
		}
		#endregion

		#region ICompare の実装部
		/// <summary>
		/// 拠点コード並べ替え用KEY
		/// </summary>
		class SecInfoKey0 : IComparer
		{
			public int Compare(object x, object y)
			{
				string cx = x.ToString();
				string cy = y.ToString();
				return cx.CompareTo(cy);
			}
		}
		#endregion
	}
}

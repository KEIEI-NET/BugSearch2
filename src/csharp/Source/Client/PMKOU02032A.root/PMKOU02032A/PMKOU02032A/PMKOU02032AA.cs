using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

// --- ADD 2012/10/02 ---------->>>>>
// オプションコード取得に必要
using Broadleaf.Application.Resources;
// --- ADD 2012/10/02 ----------<<<<<

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 仕入先元帳照会アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note        : 仕入先元帳にアクセスするクラスです。</br>
	/// <br>Programer   : 20081 疋田 勇人</br>
	/// <br>Date        : 2007.11.26</br>
	/// <br></br>
    /// <br>UpdateNote	: </br>
    /// <br>Programer   : 30365 宮津 銀次郎</br>
    /// <br>Date        : 2009.1.28 DC仕入先元帳ををPM.NS対応。</br>
    /// <br>            :           必要無い照会機能を削除。テーブルを仕様に合わせ改変。</br>
    /// <br></br>
    /// <br>UpdateNote	: </br>
    /// <br>Programer   : FSI斎藤 和宏</br>
    /// <br>Date        : 2012/10/02 仕入先総括対応。</br>
    /// <br>            :            仕入先総括用オプションコード取得処理の追加。</br>
    /// <br>UpdateNote	: </br>
    /// <br>Programer   : FSI斎藤 和宏</br>
    /// <br>Date        : 2012/11/01 支払データに値引額・手数料額が反映されていない問題対応。</br>
    /// <br>            :            消費税転嫁方式が反映されずに表示される問題対応。</br>
    /// <br>Update Note : 2014/02/26 田建委</br>
    /// <br>            : Redmine#42188 出力金額区分追加</br>
    /// <br>UpdateNote  : 2015/10/21 田思春</br>
    /// <br>管理番号    : 11170187-00</br>
    /// <br>            : Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応</br>
    /// <br>UpdateNote  : 2015/12/10 田思春</br>
    /// <br>管理番号    : 11170204-00</br>
    /// <br>            : Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応</br>
    /// </remarks>
	public class SupplierLedgerAcs
	{
		#region Constructor
		/// <summary>
		/// 仕入先元帳アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public SupplierLedgerAcs()
		{
		}
		#endregion

		#region Static Constructor
		/// <summary>
		/// 仕入先元帳アクセスクラス静的コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programer  : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// <br>Update Date: xxxx.xx.xx</br>
		/// </remarks>
		static SupplierLedgerAcs()
		{
			// 拠点情報取得部品
			_secInfoAcs = new SecInfoAcs();

            _suplierPayInfGetDB = (ISuplierPayInfGetDB)MediationSuplierPayInfGetDB.GetSuplierPayInfGetDB();
            _suplAccInfGetDB = (ISuplAccInfGetDB)MediationSuplAccInfGetDB.GetSuplAccInfGetDB();

			//締範囲
			_startTtlAddUpDateSpan	= new DateTime(1, 1, 1);
			_endTtlAddUpDateSpan	= new DateTime(1, 1, 1);

			// データセット作成
			SettingDataSet();

			// 使用するテーブル初期化
			_stockLedgerSupplierInfoTable = new Hashtable();          
			_sectionTable = new Hashtable();
			_secCodeList = new ArrayList();
            _paymentSlpTable = new Hashtable();

			// ログイン拠点取得
			Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
			if (loginEmployee != null)
			{
				_mySectionCode = loginEmployee.BelongSectionCode;
			}
		}
		#endregion

		#region Public enum
		/// <summary>元帳の画面モードの列挙型です。</summary>
		public enum Mode : int
		{
			/// <summary>支払</summary>
			Shr	= 0,
			/// <summary>買掛</summary>
			Kai	= 1,
		}

		/// <summary>元帳明細のレコード区分の列挙型です。</summary>
		public enum RecordCode : int
		{
			/// <summary>支払買掛</summary>
			AccPay		= 0,
			/// <summary>支払伝票</summary>
			PaymentSlp	= 1,
		}

        /// <summary>仕入形式</summary>
		public enum SupplierFormal : int
		{
			/// <summary>買掛(仕入)</summary>
			TypeStock		= 0,
			/// <summary>入荷</summary>
			Arrive	= 1,
            /// <summary>発注</summary>
            SalesOrder = 2,
		}

        /// <summary>買掛区分</summary>
		public enum AccPayDiv : int
		{
			/// <summary>0:買掛無し</summary>
			NotAccPay	= 0,
			/// <summary>1:買掛</summary>
			JustAccPay	= 1,
		}
     
		/// <summary>元帳明細の前残繰越区分の列挙型です。</summary>
		public enum BalanceCode : int
		{
			/// <summary>前残</summary>
			Balance	= 0,
			/// <summary>その他(支払買掛 or 支払伝票)</summary>
			Others	= 1,
			/// <summary>消費税(請求単位の場合のみ)</summary>
			ConsTax	= 2,
			/// <summary>繰越</summary>
			Carried	= 3,
		}

        /// <summary>仕入伝票区分(10:仕入,20:返品)</summary>
		public enum  SupplierLedgerSlipCdDiv : int
		{
			/// <summary>仕入</summary>
			Stock = 10,
			/// <summary>返品</summary>
			Back = 20,		
		}

        /// <summary>赤伝区分(0:黒,1:赤,2:相殺済み黒)</summary>
		public enum SupplierLedgerDtlDebitNoteDiv : int
		{
			/// <summary>黒伝</summary>
			Black = 0,
			/// <summary>赤伝</summary>
			Red = 1,
			/// <summary>元黒</summary>
			OffsetBlack = 2,
		}

        /// <summary>締フラグ区分(0:未締,1:締済)</summary>
		public enum CloseFlagState : int
		{
			/// <summary>未締</summary>
			NotClose = 0,
			/// <summary>締済</summary>
			Close = 1,
		}

		#endregion
		#region Public Const

        #region テーブル名
        /// <summary>支払ヘッダ</summary>
        public const string TABLE_SuplierPay = "TABLE_SuplierPay";

        /// <summary>元帳伝票データテーブル名</summary>
        public const string TABLE_SplLedger = "TABLE_SplLedger";

        /// <summary>元帳明細データテーブル名</summary>
        public const string TABLE_DtlLedger = "TABLE_DtlLedger";

        /// <summary>元帳支払伝票テーブル名</summary>
        public const string TABLE_PaymentLedger = "TABLE_PaymentLedger";
        #endregion

        #region 支払の鑑
        /// <summary> 企業コード </summary>
        public const string COL_Spl_EnterpriseCode = "EnterpriseCode";
        /// <summary> 計上拠点コード </summary>
        public const string COL_Spl_AddUpSecCode = "AddUpSecCode";
        /// <summary> 計上拠点名 </summary>
        public const string COL_Spl_AddUpSecName = "AddUpSecName";
        /// <summary> 支払先コード </summary>
        public const string COL_Spl_PayeeCode = "PayeeCode";
        /// <summary> 支払先名称 </summary>
        public const string COL_Spl_PayeeName = "PayeeName";
        /// <summary> 支払先名称2 </summary>
        public const string COL_Spl_PayeeName2 = "PayeeName2";
        /// <summary> 支払先略称 </summary>
        public const string COL_Spl_PayeeSnm = "PayeeSnm";
        /// <summary> 実績拠点コード </summary>
        public const string COL_Spl_ResultsSectCd = "ResultsSectCd";
        /// <summary> 仕入先コード </summary>
        public const string COL_Spl_SupplierCd = "SupplierCd";
        /// <summary> 仕入先名1 </summary>
        public const string COL_Spl_SupplierNm1 = "SupplierNm1";
        /// <summary> 仕入先名2 </summary>
        public const string COL_Spl_SupplierNm2 = "SupplierNm2";
        /// <summary> 仕入先略称 </summary>
        public const string COL_Spl_SupplierSnm = "SupplierSnm";
        /// <summary> 計上年月日 </summary>
        public const string COL_Spl_AddUpDate = "AddUpDate";
        /// <summary> 計上年月 </summary>
        public const string COL_Spl_AddUpYearMonth = "AddUpYearMonth";
        /// <summary> 前回支払金額 </summary>
        public const string COL_Spl_LastTimePayment = "LastTimePayment";
        /// <summary> 仕入2回前残高（支払計） </summary>
        public const string COL_Spl_StockTtl2TmBfBlPay = "StockTtl2TmBfBlPay";
        /// <summary> 仕入3回前残高（支払計） </summary>
        public const string COL_Spl_StockTtl3TmBfBlPay = "StockTtl3TmBfBlPay";
        /// <summary> 今回支払金額（通常支払） </summary>
        public const string COL_Spl_ThisTimePayNrml = "ThisTimePayNrml";
        /// <summary> 今回繰越残高（支払計） </summary>
        public const string COL_Spl_ThisTimeTtlBlcPay = "ThisTimeTtlBlcPay";
        /// <summary> 相殺後今回仕入金額 </summary>
        public const string COL_Spl_OfsThisTimeStock = "OfsThisTimeStock";
        /// <summary> 相殺後今回仕入消費税 </summary>
        public const string COL_Spl_OfsThisStockTax = "OfsThisStockTax";
        /// <summary> 税込仕入額 </summary>
        public const string COL_Spl_OfsThisTimeStockTax = "OfsThisTimeStockTax";
        /// <summary> 今回返品金額 </summary>
        public const string COL_Spl_ThisStckPricRgds = "ThisStckPricRgds";
        /// <summary> 今回返品消費税 </summary>
        public const string COL_Spl_ThisStcPrcTaxRgds = "ThisStcPrcTaxRgds";
        /// <summary> 今回値引金額 </summary>
        public const string COL_Spl_ThisStckPricDis = "ThisStckPricDis";
        /// <summary> 今回値引消費税 </summary>
        public const string COL_Spl_ThisStcPrcTaxDis = "ThisStcPrcTaxDis";
        /// <summary> 今回返品・値引金額 </summary>
        public const string COL_Spl_ThisStckPricRgdsDis = "ThisStckPricRgdsDis";
        /// <summary> 消費税調整額 </summary>
        public const string COL_Spl_TaxAdjust = "TaxAdjust";
        /// <summary> 残高調整額 </summary>
        public const string COL_Spl_BalanceAdjust = "BalanceAdjust";
        /// <summary> 仕入合計残高（支払計） </summary>
        public const string COL_Spl_StockTotalPayBalance = "StockTotalPayBalance";
        /// <summary> 締次更新実行年月日 </summary>
        public const string COL_Spl_CAddUpUpdExecDate = "CAddUpUpdExecDate";
        /// <summary> 締次更新開始年月日 </summary>
        public const string COL_Spl_StartCAddUpUpdDate = "StartCAddUpUpdDate";
        /// <summary> 前回締次更新年月日 </summary>
        public const string COL_Spl_LastCAddUpUpdDate = "LastCAddUpUpdDate";
        /// <summary> 仕入伝票枚数 </summary>
        public const string COL_Spl_StockSlipCount = "StockSlipCount";
        /// <summary> 締済みフラグ </summary>
        public const string COL_Spl_CloseFlg = "CloseFlg";
        /// <summary> 印刷用 支払残・買掛残 </summary>
        public const string COL_Spl_SlitTitle = "SlitTitle";
        // 2009.02.24 30413 犬飼 今回仕入金額の追加 >>>>>>START
        /// <summary> 今回仕入金額 </summary>
        public const string COL_Spl_ThisTimeStockPrice = "ThisTimeStockPrice";
        // 2009.02.24 30413 犬飼 今回仕入金額の追加 <<<<<<END
        // --- ADD 2012/11/01 ---------->>>>>
        /// <summary> 消費税転嫁方式 </summary>
        public const string COL_Spl_SuppCTaxLayCd = "SuppCTaxLayCd";
        // --- ADD 2012/11/01 ----------<<<<<

        #endregion
        #region 買掛の鑑
        /// <summary> 企業コード </summary>
        public const string COL_Acc_EnterpriseCode = "EnterpriseCode";
        /// <summary> 計上拠点コード </summary>
        public const string COL_Acc_AddUpSecCode = "AddUpSecCode";
        /// <summary> 計上拠点名 </summary>
        public const string COL_Acc_AddUpSecName = "AddUpSecName";
        /// <summary> 支払先コード </summary>
        public const string COL_Acc_PayeeCode = "PayeeCode";
        /// <summary> 支払先名称 </summary>
        public const string COL_Acc_PayeeName = "PayeeName";
        /// <summary> 支払先名称2 </summary>
        public const string COL_Acc_PayeeName2 = "PayeeName2";
        /// <summary> 支払先略称 </summary>
        public const string COL_Acc_PayeeSnm = "PayeeSnm";
        /// <summary> 仕入先コード </summary>
        public const string COL_Acc_SupplierCd = "SupplierCd";
        /// <summary> 仕入先名1 </summary>
        public const string COL_Acc_SupplierNm1 = "SupplierNm1";
        /// <summary> 仕入先名2 </summary>
        public const string COL_Acc_SupplierNm2 = "SupplierNm2";
        /// <summary> 仕入先略称 </summary>
        public const string COL_Acc_SupplierSnm = "SupplierSnm";
        /// <summary> 計上年月日 </summary>
        public const string COL_Acc_AddUpDate = "AddUpDate";
        /// <summary> 計上年月 </summary>
        public const string COL_Acc_AddUpYearMonth = "AddUpYearMonth";
        /// <summary> 前回買掛金額 </summary>
        public const string COL_Acc_LastTimeAccPay = "LastTimeAccPay";
        /// <summary> 仕入2回前残高（買掛計） </summary>
        public const string COL_Acc_StckTtl2TmBfBlAccPay = "StckTtl2TmBfBlAccPay";
        /// <summary> 仕入3回前残高（買掛計） </summary>
        public const string COL_Acc_StckTtl3TmBfBlAccPay = "StckTtl3TmBfBlAccPay";
        /// <summary> 今回支払金額（通常支払） </summary>
        public const string COL_Acc_ThisTimePayNrml = "ThisTimePayNrml";
        /// <summary> 今回繰越残高（買掛計） </summary>
        public const string COL_Acc_ThisTimeTtlBlcAcPay = "ThisTimeTtlBlcAcPay";
        /// <summary> 相殺後今回仕入金額 </summary>
        public const string COL_Acc_OfsThisTimeStock = "OfsThisTimeStock";
        /// <summary> 相殺後今回仕入消費税 </summary>
        public const string COL_Acc_OfsThisStockTax = "OfsThisStockTax";
        /// <summary> 今回返品金額 </summary>
        public const string COL_Acc_ThisStckPricRgds = "ThisStckPricRgds";
        /// <summary> 今回返品消費税 </summary>
        public const string COL_Acc_ThisStcPrcTaxRgds = "ThisStcPrcTaxRgds";
        /// <summary> 今回値引金額 </summary>
        public const string COL_Acc_ThisStckPricDis = "ThisStckPricDis";
        /// <summary> 今回値引消費税 </summary>
        public const string COL_Acc_ThisStcPrcTaxDis = "ThisStcPrcTaxDis";
        /// <summary> 消費税調整額 </summary>
        public const string COL_Acc_TaxAdjust = "TaxAdjust";
        /// <summary> 残高調整額 </summary>
        public const string COL_Acc_BalanceAdjust = "BalanceAdjust";
        /// <summary> 仕入合計残高（買掛計） </summary>
        public const string COL_Acc_StckTtlAccPayBalance = "StckTtlAccPayBalance";
        /// <summary> 月次更新実行年月日 </summary>
        public const string COL_Acc_MonthAddUpExpDate = "MonthAddUpExpDate";
        /// <summary> 月次更新開始年月日 </summary>
        public const string COL_Acc_StMonCAddUpUpdDate = "StMonCAddUpUpdDate";
        /// <summary> 前回月次更新年月日 </summary>
        public const string COL_Acc_LaMonCAddUpUpdDate = "LaMonCAddUpUpdDate";
        /// <summary> 仕入伝票枚数 </summary>
        public const string COL_Acc_StockSlipCount = "StockSlipCount";
        /// <summary> 締済みフラグ </summary>
        public const string COL_Acc_CloseFlg = "CloseFlg";
        /// <summary> 印刷用 支払残・買掛残 </summary>
        public const string COL_Acc_SlitTitle = "SlitTitle";
        // --- ADD 2012/11/01 ---------->>>>>
        /// <summary> 消費税転嫁方式 </summary>
        public const string COL_Acc_SuppCTaxLayCd = "SuppCTaxLayCd";
        // --- ADD 2012/11/01 ----------<<<<<
        #endregion

        #region 元帳明細カラム情報(伝票)
        /// <summary> 企業コード </summary>
        public const string CT_SplLedger_EnterpriseCode = "EnterpriseCode";
        /// <summary> 計上日付(締基準) </summary>
        public const string CT_SplLedger_AddUpDate = "AddUpDate";
        /// <summary> 仕入形式 </summary>
        public const string CT_SplLedger_SupplierFormal = "SupplierFormal";
        /// <summary> 仕入伝票番号 </summary>
        public const string CT_SplLedger_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> 仕入伝票種別 </summary>
        public const string CT_SplLedger_SlipKindNm = "SlipKindNm";
        /// <summary> 拠点コード </summary>
        public const string CT_SplLedger_SectionCode = "SectionCode";
        /// <summary> 赤伝区分 </summary>
        public const string CT_SplLedger_DebitNoteDiv = "DebitNoteDiv";
        /// <summary> 赤黒連結仕入伝票番号 </summary>
        public const string CT_SplLedger_DebitNLnkSuppSlipNo = "DebitNLnkSuppSlipNo";
        /// <summary> 仕入伝票区分 </summary>
        public const string CT_SplLedger_SupplierSlipCd = "SupplierSlipCd";
        /// <summary> 仕入商品区分 </summary>
        public const string CT_SplLedger_StockGoodsCd = "StockGoodsCd";
        /// <summary> 仕入拠点コード </summary>
        public const string CT_SplLedger_StockSectionCd = "StockSectionCd";
        /// <summary> 仕入計上拠点コード </summary>
        public const string CT_SplLedger_StockAddUpSectionCd = "StockAddUpSectionCd";
        /// <summary> 入力日 </summary>
        public const string CT_SplLedger_InputDay = "InputDay";
        /// <summary> 入荷日 </summary>
        public const string CT_SplLedger_ArrivalGoodsDay = "ArrivalGoodsDay";
        /// <summary> 仕入日 </summary>
        public const string CT_SplLedger_StockDate = "StockDate";
        /// <summary> 仕入計上日付 </summary>
        public const string CT_SplLedger_StockAddUpADate = "StockAddUpADate";
        /// <summary> 仕入レコード区分 </summary>
        public const string CT_SplLedger_StockRecordCd = "StockRecordCd";
        /// <summary> 仕入入力者コード </summary>
        public const string CT_SplLedger_StockInputCode = "StockInputCode";
        /// <summary> 仕入入力者名称 </summary>
        public const string CT_SplLedger_StockInputName = "StockInputName";
        /// <summary> 仕入担当者コード </summary>
        public const string CT_SplLedger_StockAgentCode = "StockAgentCode";
        /// <summary> 仕入担当者名称 </summary>
        public const string CT_SplLedger_StockAgentName = "StockAgentName";
        /// <summary> 支払先コード </summary>
        public const string CT_SplLedger_PayeeCode = "PayeeCode";
        /// <summary> 支払先略称 </summary>
        public const string CT_SplLedger_PayeeSnm = "PayeeSnm";
        /// <summary> 仕入先コード </summary>
        public const string CT_SplLedger_SupplierCd = "SupplierCd";
        /// <summary> 仕入先名1 </summary>
        public const string CT_SplLedger_SupplierNm1 = "SupplierNm1";
        /// <summary> 仕入先名2 </summary>
        public const string CT_SplLedger_SupplierNm2 = "SupplierNm2";
        /// <summary> 仕入先略称 </summary>
        public const string CT_SplLedger_SupplierSnm = "SupplierSnm";
        /// <summary> 仕入金額合計 </summary>
        public const string CT_SplLedger_StockTotalPrice = "StockTotalPrice";
        /// <summary> 仕入金額小計 </summary>
        public const string CT_SplLedger_StockSubttlPrice = "StockSubttlPrice";
        /// <summary> 仕入金額消費税額 </summary>
        public const string CT_SplLedger_StockPriceConsTax = "StockPriceConsTax";
        /// <summary> 相手先伝票番号 </summary>
        public const string CT_SplLedger_PartySaleSlipNum = "PartySaleSlipNum";
        /// <summary> 仕入伝票備考1 </summary>
        public const string CT_SplLedger_SupplierSlipNote1 = "SupplierSlipNote1";
        /// <summary> 仕入伝票備考2 </summary>
        public const string CT_SplLedger_SupplierSlipNote2 = "SupplierSlipNote2";
        /// <summary> ＵＯＥリマーク１ </summary>
        public const string CT_SplLedger_UoeRemark1 = "UoeRemark1";
        /// <summary> ＵＯＥリマーク２ </summary>
        public const string CT_SplLedger_UoeRemark2 = "UoeRemark2";
        //以下は支払伝票のデータ
        /// <summary> 支払金額 </summary>
        public const string CT_SplLedger_Payment = "Payment";
        /// <summary> 有効期限 </summary>
        public const string CT_SplLedger_ValidityTerm = "ValidityTerm";
        //以下印刷用
        /// <summary> 支払残or買掛残string </summary>
        public const string CT_SplLedger_SlitTitle = "SlitTitle";
        /// <summary> 仕入金額消費税額 </summary>
        public const string CT_SplLedger_Balance = "Balance";
        /// <summary> 支払用金額区分名 </summary>
        public const string CT_SplLedger_GoodsName = "GoodsNameMny";
        /// <summary> 支払用金額区分 </summary>
        public const string CT_SplLedger_GoodsDiv = "GoodsDivMny";
        #endregion

        #region 元帳明細カラム情報(明細)
        /// <summary> 企業コード </summary>
        public const string CT_DtlLedger_EnterpriseCode = "EnterpriseCode";
        /// <summary> 計上日(締基準) </summary>
        public const string CT_DtlLedger_AddUpDate = "AddUpDate";
        /// <summary> 仕入形式 </summary>
        public const string CT_DtlLedger_SupplierFormal = "SupplierFormal";
        /// <summary> 仕入伝票番号 </summary>
        public const string CT_DtlLedger_SupplierSlipNo = "SupplierSlipNo";
        /// <summary> 仕入伝票種別 </summary>
        public const string CT_DtlLedger_SlipKindNm = "SlipKindNm";
        /// <summary> 拠点コード </summary>
        public const string CT_DtlLedger_SectionCode = "SectionCode";
        /// <summary> 赤伝区分 </summary>
        public const string CT_DtlLedger_DebitNoteDiv = "DebitNoteDiv";
        /// <summary> 赤黒連結仕入伝票番号 </summary>
        public const string CT_DtlLedger_DebitNLnkSuppSlipNo = "DebitNLnkSuppSlipNo";
        /// <summary> 仕入伝票区分 </summary>
        public const string CT_DtlLedger_SupplierSlipCd = "SupplierSlipCd";
        /// <summary> 仕入商品区分 </summary>
        public const string CT_DtlLedger_StockGoodsCd = "StockGoodsCd";
        /// <summary> 仕入拠点コード </summary>
        public const string CT_DtlLedger_StockSectionCd = "StockSectionCd";
        /// <summary> 仕入計上拠点コード </summary>
        public const string CT_DtlLedger_StockAddUpSectionCd = "StockAddUpSectionCd";
        /// <summary> 入力日 </summary>
        public const string CT_DtlLedger_InputDay = "InputDay";
        /// <summary> 入荷日 </summary>
        public const string CT_DtlLedger_ArrivalGoodsDay = "ArrivalGoodsDay";
        /// <summary> 仕入日 </summary>
        public const string CT_DtlLedger_StockDate = "StockDate";
        /// <summary> 仕入計上日付 </summary>
        public const string CT_DtlLedger_StockAddUpADate = "StockAddUpADate";
        /// <summary> 仕入入力者コード </summary>
        public const string CT_DtlLedger_StockInputCode = "StockInputCode";
        /// <summary> 仕入入力者名称 </summary>
        public const string CT_DtlLedger_StockInputName = "StockInputName";
        /// <summary> 仕入担当者コード </summary>
        public const string CT_DtlLedger_StockAgentCode = "StockAgentCode";
        /// <summary> 仕入担当者名称 </summary>
        public const string CT_DtlLedger_StockAgentName = "StockAgentName";
        /// <summary> 支払先コード </summary>
        public const string CT_DtlLedger_PayeeCode = "PayeeCode";
        /// <summary> 支払先略称 </summary>
        public const string CT_DtlLedger_PayeeSnm = "PayeeSnm";
        /// <summary> 仕入先コード </summary>
        public const string CT_DtlLedger_SupplierCd = "SupplierCd";
        /// <summary> 仕入先レコード区分 </summary>
        public const string CT_DtlLedger_StockRecordCd = "StockRecordCd";
        /// <summary> 仕入先名1 </summary>
        public const string CT_DtlLedger_SupplierNm1 = "SupplierNm1";
        /// <summary> 仕入先名2 </summary>
        public const string CT_DtlLedger_SupplierNm2 = "SupplierNm2";
        /// <summary> 仕入先略称 </summary>
        public const string CT_DtlLedger_SupplierSnm = "SupplierSnm";
        /// <summary> 仕入金額合計 </summary>
        public const string CT_DtlLedger_StockTotalPrice = "StockTotalPrice";
        /// <summary> 仕入金額小計 </summary>
        public const string CT_DtlLedger_StockSubttlPrice = "StockSubttlPrice";
        /// <summary> 仕入金額消費税額 </summary>
        public const string CT_DtlLedger_StockPriceConsTax = "StockPriceConsTax";
        /// <summary> 相手先伝票番号 </summary>
        public const string CT_DtlLedger_PartySaleSlipNum = "PartySaleSlipNum";
        /// <summary> 仕入伝票備考1 </summary>
        public const string CT_DtlLedger_SupplierSlipNote1 = "SupplierSlipNote1";
        /// <summary> 仕入伝票備考2 </summary>
        public const string CT_DtlLedger_SupplierSlipNote2 = "SupplierSlipNote2";
        /// <summary> ＵＯＥリマーク１ </summary>
        public const string CT_DtlLedger_UoeRemark1 = "UoeRemark1";
        /// <summary> ＵＯＥリマーク２ </summary>
        public const string CT_DtlLedger_UoeRemark2 = "UoeRemark2";
        /// <summary> 仕入行番号 </summary>
        public const string CT_DtlLedger_StockRowNo = "StockRowNo";
        /// <summary> 共通通番 </summary>
        public const string CT_DtlLedger_CommonSeqNo = "CommonSeqNo";
        /// <summary> 仕入明細通番 </summary>
        public const string CT_DtlLedger_StockSlipDtlNum = "StockSlipDtlNum";
        /// <summary> 商品番号 </summary>
        public const string CT_DtlLedger_GoodsNo = "GoodsNo";
        /// <summary> 商品名称 </summary>
        public const string CT_DtlLedger_GoodsName = "GoodsName";
        /// <summary> 商品名称カナ </summary>
        public const string CT_DtlLedger_GoodsNameKana = "GoodsNameKana";
        /// <summary> 販売先コード </summary>
        public const string CT_DtlLedger_SalesCustomerCode = "SalesCustomerCode";
        /// <summary> 販売先略称 </summary>
        public const string CT_DtlLedger_SalesCustomerSnm = "SalesCustomerSnm";
        /// <summary> 仕入数 </summary>
        public const string CT_DtlLedger_StockCount = "StockCount";
        /// <summary> 仕入単価（税抜，浮動） </summary>
        public const string CT_DtlLedger_StockUnitPriceFl = "StockUnitPriceFl";
        /// <summary> 仕入金額（税抜き） </summary>
        public const string CT_DtlLedger_StockPriceTaxExc = "StockPriceTaxExc";
        /// <summary> 仕入金額消費税額 </summary>
        public const string CT_DtlLedger_Dtl_StockPriceConsTax = "Dtl_StockPriceConsTax";
        //以下支払伝票
        /// <summary> 支払金額 </summary>
        public const string CT_DtlLedger_Payment = "Payment";
        /// <summary> 有効期限 </summary>
        public const string CT_DtlLedger_ValidityTerm = "ValidityTerm";
        //以下印刷用
        /// <summary> 支払残or買掛残string </summary>
        public const string CT_DtlLedger_SlitTitle = "SlitTitle";
        /// <summary> 残高 </summary>
        public const string CT_DtlLedger_Balance = "Balance";
        #endregion

        # endregion
        #region Private Static Member
        /// <summary>支払残or買掛残モード</summary>
        private static int _imode = 0;
        /// <summary>印刷区分</summary>
        private static int _printDiv = 0;

        ///// <summary>支払残高元帳データセット</summary>
        //private static DataSet _payBalanceDs;

        ///// <summary>買掛残高元帳データセット</summary>
        //private static DataSet _accPayBalanceDs;

        /// <summary>元帳データセット</summary>
		private static DataSet _stockLedgerDataSet = null;

		/// <summary>元帳伝票データテーブル</summary>
		private static DataTable _stockLedgerSlipDataTable = null;

		/// <summary>元帳伝票画面用データビュー</summary>
		private static DataView _stockLedgerSlipDataView = null;

        /// <summary>元帳明細データテーブル</summary>
        private static DataTable _stockLedgerDtlDataTable = null;

        /// <summary>元帳明細画面用データビュー</summary>
        private static DataView _stockLedgerDtlDataView = null;

        /// <summary>元帳支払伝票データテーブル</summary>
        private static DataTable _stockLedgerPaymentDataTable = null;

        ///// <summary>元帳支払伝票画面用データビュー</summary>
        //private static DataView _stockLedgerPaymentDataView = null;

        ///// <summary>元帳残高データテーブル</summary>
        //private static DataTable _stockLedgerBlanceDataTable = null;

        ///// <summary>元帳残高画面用データビュー</summary>
        //private static DataView _stockLedgerBlanceDataView = null;

		/// <summary>仕入先金額データテーブル</summary>
		private static DataTable _suplierPayDataTable = null;

        ///// <summary>仕入先金額データテーブル(印刷用)</summary>
        //private static DataTable _suplierPayPrintDataTable = null;

		/// <summary>仕入先金額データビュー</summary>
        private static DataView _suplierPayDataView = null;

        /// <summary>仕入先金額データビュー(印刷用)</summary>
        private static DataView _suplierPayPrintDataView = null;

        /// <summary>支払伝票テーブル</summary>
        private static Hashtable _paymentSlpTable = null;

		/// <summary>元帳得意先情報</summary>
		private static Hashtable _stockLedgerSupplierInfoTable = null;
       
		/// <summary>締範囲(開始)</summary>
		private static DateTime _startTtlAddUpDateSpan = DateTime.MinValue;

		/// <summary>締範囲(終了)</summary>
		private static DateTime _endTtlAddUpDateSpan = DateTime.MinValue;

		/// <summary>計上年月日(開始)</summary>
		private static DateTime _startAddUpDate = DateTime.MinValue;

		/// <summary>計上年月日(終了)</summary>
		private static DateTime _endAddUpDate = DateTime.MinValue;

		/// <summary>拠点テーブル取得用</summary>
		private static Hashtable _sectionTable = null;

		/// <summary>拠点コードリスト</summary>
		private static ArrayList _secCodeList = null;
      
		/// <summary>自拠点コード</summary>
		private static string _mySectionCode = string.Empty;

		/// <summary>本社機能有無[true:本社機能,false:拠点機能]</summary>
		private static bool _isMainOfficeFunc = false;

		/// <summary>表示対象拠点コード</summary>
		private static string _targetSectionCode = string.Empty;

		/// <summary>拠点情報取得部品</summary>
		private static SecInfoAcs _secInfoAcs = null;

		/// <summary>帳票出力設定データクラス</summary>
		private static PrtOutSet _prtOutSet = null;

		/// <summary>帳票出力設定アクセスクラス</summary>
		private static PrtOutSetAcs _prtOutSetAcs = null;

		/// <summary>全体項目表示設定データクラス</summary>
		private static AlItmDspNm _alItmDspNmData = null;

		/// <summary>全体項目表示設定データクラス</summary>
		private static AlItmDspNmAcs _alItmDspNmAcs = null;

        /// <summary>仕入先支払情報取得アクセスクラス</summary>
		private static GetSuplierPayAcs _getSuplierPayAcs = null;

        /// <summary>仕入先買掛情報取得アクセスクラス</summary>
		private static GetSuplAccAcs _getSuplAccAcs = null;

        /// <summary>支払履歴取得リモート</summary>
        private static ISuplierPayInfGetDB _suplierPayInfGetDB = null;

        /// <summary>買掛履歴取得リモート</summary>
        private static ISuplAccInfGetDB _suplAccInfGetDB = null;

        ///// <summary>仕入先元帳（仕入伝票）抽出結果データテーブル(印刷用)</summary>
        //private static DataTable _suplierPayInfGetDt = null;

        ///// <summary>仕入先元帳（仕入伝票）抽出結果データビュー(印刷用)</summary>
        //private static DataView _suplierPayInfGetDv = null;

		#endregion
        //とりあえずok。後で修正する可能性
		#region Property
        ///// <summary>支払残高元帳データセット(読み取り専用)</summary>
        //public DataSet PayBalanceDs
        //{
        //    get { return _payBalanceDs; }
        //}

        ///// <summary>買掛残高元帳データセット(読み取り専用)</summary>
        //public DataSet AccPayBalanceDs
        //{
        //    get { return _accPayBalanceDs; }
        //}

		/// <summary>元帳データセットプロパティ</summary>
		public DataSet CsLedgerDataSet
		{
			get { return _stockLedgerDataSet; }
		}

		/// <summary>元帳伝票データテーブルプロパティ</summary>
		public DataTable CsLedgerSlipDataTable
		{
			get { return _stockLedgerSlipDataTable; }
		}

		/// <summary>元帳伝票データビュープロパティ</summary>
		public DataView CsLedgerSlipDataView
		{
			get { return _stockLedgerSlipDataView; }
		}

        /// <summary>元帳明細データテーブルプロパティ</summary>
        public DataTable CsLedgerDtlDataTable
        {
            get { return _stockLedgerDtlDataTable; }
        }

        /// <summary>元帳明細データビュープロパティ</summary>
        public DataView CsLedgerDtlDataView
        {
            get { return _stockLedgerDtlDataView; }
        }

        /// <summary>元帳明細データテーブルプロパティ</summary>
        public DataTable CsLedgerPaymentDataTable
        {
            get { return _stockLedgerPaymentDataTable; }
        }

        ///// <summary>元帳明細データビュープロパティ</summary>
        //public DataView CsLedgerPaymentDataView
        //{
        //    get { return _stockLedgerPaymentDataView; }
        //}

        ///// <summary>元帳残高データテーブルプロパティ</summary>
        //public DataTable CsLedgerBlanceDataTable
        //{
        //    get { return _stockLedgerBlanceDataTable; }
        //}

        ///// <summary>元帳残高データビュープロパティ</summary>
        //public DataView CsLedgerBlanceDataView
        //{
        //    get { return _stockLedgerBlanceDataView; }
        //}

		/// <summary>仕入先金額データテーブルプロパティ</summary>
		public DataTable SuplierPayDataTable
		{
			get { return _suplierPayDataTable; }
		}

        ///// <summary>仕入先金額データテーブル(印刷用)プロパティ</summary>
        //public DataTable SuplierPayPrintDataTable
        //{
        //    get { return _suplierPayPrintDataTable; }
        //}

        /// <summary>支払伝票データテーブルプロパティ</summary>
        public Hashtable PaymentSlpTable
        {
            get { return _paymentSlpTable; }
        }

		/// <summary>仕入先金額データビュープロパティ</summary>
		public DataView SuplierPayDataView
		{
			get { return _suplierPayDataView; }
		}

        /// <summary>仕入先金額データビュー(印刷用)プロパティ</summary>
        public DataView SuplierPayPrintDataView
        {
            get { return _suplierPayPrintDataView; }
        }

		/// <summary>締範囲（開始）</summary>
		public DateTime TtlAddUpDateSpanStart
		{
			get { return _startTtlAddUpDateSpan; }
		}

		/// <summary>締範囲（終了）</summary>
		public DateTime TtlAddUpDateSpanEnd
		{
			get { return _endTtlAddUpDateSpan; }
		}

		/// <summary>計上年月日（開始）</summary>
		public DateTime AddUpDateStrart
		{
			get { return _startAddUpDate; }
		}

		/// <summary>計上年月日（終了）</summary>
		public DateTime AddUpDateEnd
		{
			get { return _endAddUpDate; }
		}

		/// <summary>拠点情報リスト</summary>
		public Hashtable SectionTable
		{
			get { return _sectionTable; }
		}

		/// <summary>拠点コードリスト</summary>
		public ArrayList SecCodeList
		{
			get { return _secCodeList; }
		}

        ///// <summary>仕入先元帳（仕入明細）データビュープロパティ</summary>
        //public DataView SuplierPayInfGetDataView
        //{
        //    get { return _suplierPayInfGetDv; }
        //}

		#endregion

		#region Public Method

        #region 初期設定情報読込
        /// <summary>
		/// 初期設定情報読込
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 初期設定情報の読込を行います。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
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
				_sectionTable.Clear();
				_secCodeList.Clear();

				foreach (SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)
				{			
					_sectionTable.Add(secInfoSet.SectionCode, secInfoSet.Clone());
					_secCodeList.Add(secInfoSet.SectionCode);
				}
				_secCodeList.Sort(new SecInfoKey0());

				// 支払残高表示拠点取得
				status = GetOwnSeCtrlCode(_mySectionCode, SecInfoAcs.CtrlFuncCode.PayBlcDispSecCd, out _targetSectionCode);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						message = String.Format("拠点コード 「{0}」の支払残高表示拠点が設定されていません", _mySectionCode)
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
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return status;
        }

        #endregion

        #region 帳票出力設定読込
        /// <summary>
		/// 帳票出力設定読込
		/// </summary>
		/// <param name="prtOutSet">帳票出力設定データクラス</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			prtOutSet = null;
			message = string.Empty;

			// Staticに保持済みの場合
			if (_prtOutSet != null)
			{
				prtOutSet = _prtOutSet.Clone();
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}

			try
			{
				// 帳票出力設定アクセスクラス
				if (_prtOutSetAcs == null) _prtOutSetAcs = new PrtOutSetAcs();

				status = _prtOutSetAcs.Read(out _prtOutSet, LoginInfoAcquisition.EnterpriseCode, _mySectionCode);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						prtOutSet = _prtOutSet.Clone();
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

        #region 全体項目表示設定読込
        /// <summary>
		/// 全体項目表示設定データクラス取得
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>全体項目表示設定データクラス</returns>
		/// <remarks>
		/// <br>Note       : 全体項目表示設定データクラスの取得を行います。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
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

		/// <summary>
		/// 全体項目表示設定読込み
		/// </summary>
		/// <param name="alItmDspNm">全体項目表示設定データクラス</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>0:正常,4:データ無し,その他:異常</returns>
		/// <remarks>
		/// <br>Note       : 全体項目表示設定データクラスの取得を行います。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
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

        #region 拠点情報取得
        /// <summary>
		/// 本社機能有無取得
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>true: 本社,false: 拠点</returns>
		/// <remarks>
		/// <br>Note       : 本社機能有無チェックを行います。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public bool CheckMainOfficeFunc(string sectionCode)
		{
			return (_secInfoAcs.GetMainOfficeFuncFlag(sectionCode) == 1);
		}

		/// <summary>
		/// 制御機能拠点取得
		/// </summary>
		/// <param name="sectionCode">対象拠点コード</param>
		/// <param name="ctrlFuncCode">取得する制御機能コード</param>
		/// <param name="ctrlSectionCode">対象制御拠点コード</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 該当拠点の拠点制御情報の読込を行います。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
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
        #region 元帳データ初期化処理
        /// <summary>
		/// 元帳データ初期化処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : Static情報を初期化します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public void InitializeCustomerLedger()
		{
			_startAddUpDate			= new DateTime(1, 1, 1);
			_endAddUpDate			= new DateTime(1, 1, 1);
			_startTtlAddUpDateSpan	= new DateTime(1, 1, 1);
			_endTtlAddUpDateSpan	= new DateTime(1, 1, 1);

			// テーブル行初期化
			_stockLedgerSupplierInfoTable.Clear();
            //_stockLedgerBlanceDataTable.Rows.Clear();
			_stockLedgerSlipDataTable.Rows.Clear();
            _stockLedgerDtlDataTable.Rows.Clear();
			_suplierPayDataTable.Rows.Clear();
			//_suplierPayPrintDataTable.Rows.Clear();
            _paymentSlpTable.Clear();

			// フィルター条件初期化
			_suplierPayDataView.RowFilter		= string.Empty;
			//_suplierPayPrintDataView.RowFilter	= string.Empty;
			_stockLedgerSlipDataView.RowFilter	= string.Empty;
            //_stockLedgerBlanceDataView.RowFilter = string.Empty;
            _stockLedgerDtlDataView.RowFilter   = string.Empty;
            //_stockLedgerPaymentDataView.RowFilter = string.Empty;

			// 初期ソート条件設定
            _suplierPayDataView.Sort = COL_Spl_AddUpSecCode + "," + COL_Spl_PayeeCode + "," + COL_Spl_AddUpDate;
            //_suplierPayPrintDataView.Sort	= COL_Spl_AddUpSecCode + "," + COL_Spl_PayeeCode + "," + COL_Spl_AddUpDate;
            //_stockLedgerBlanceDataView.Sort = COL_BlanceLedger_AddUpSecCode + "," + COL_BlanceLedger_PayeeCode + "," + COL_BlanceLedger_AddUpDate;
            _stockLedgerSlipDataView.Sort = CT_SplLedger_PayeeCode + "," + CT_SplLedger_StockRecordCd + "," + CT_SplLedger_StockAddUpADate + "," + CT_SplLedger_SupplierSlipNo;
            _stockLedgerDtlDataView.Sort = CT_DtlLedger_PayeeCode + "," + CT_DtlLedger_StockAddUpADate + "," + CT_DtlLedger_StockRecordCd + "," + CT_DtlLedger_SupplierSlipNo;
 
        }

        #endregion

        #region 元帳データ取得処理(Read)
        /// <summary>
		/// 元帳データ取得処理
		/// </summary>
		/// <param name="mode">読込モード[0:支払,1:買掛]</param>
        /// <param name="printDiv">印刷モード[1:明細,1:伝票]</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierCode">仕入先コード</param>
        /// <param name="startCustomerCode">開始得意先コード</param>
        /// <param name="endCustomerCode">終了得意先コード</param>
        /// <param name="startYearMonth">検索範囲(開始)</param>
		/// <param name="endYearMonth">検索範囲(終了)</param>
		/// <param name="sectionCode">対象拠点コード</param>
        /// <param name="sectionCodeList">対象拠点コードリスト(全社分格納)</param>
        /// <param name="isBufferClear">StaticMemory初期化フラグ[True:初期化する, False:初期化しない]</param>
		/// <param name="message">エラーメッセージ</param>
        /// <param name="outMoneyDiv">出力金額区分</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 対象得意先の元帳データを取得します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 2014/02/26 田建委</br>
        /// <br>           : Redmine#42188 出力金額区分追加</br>
        /// </remarks>
        //public int Read(int mode, int realMode, string enterpriseCode, int supplierCode, int startCustomerCode, int endCustomerCode, int startYearMonth, int endYearMonth, string sectionCode, ArrayList sectionCodeList, bool isBufferClear, out string message)
        //public int Read(int mode,int printDiv, string enterpriseCode, int supplierCode, int startCustomerCode, int endCustomerCode, int startYearMonth, int endYearMonth, string sectionCode, ArrayList sectionCodeList, bool isBufferClear,out string message)
        public int Read(int mode,int printDiv, string enterpriseCode, int supplierCode, int startCustomerCode, int endCustomerCode, int startYearMonth, int endYearMonth, string sectionCode, ArrayList sectionCodeList, bool isBufferClear, int outMoneyDiv, out string message)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            message = string.Empty;

            _imode = mode;
            _printDiv = printDiv;

            // 全社を選択
            if ((sectionCodeList.Count == 1) && (sectionCodeList[0].ToString() == "0"))
            {
                sectionCodeList = null;
            }

            try
            {
                // 静的領域同期化処理
                lock (typeof(SupplierLedgerAcs))
                {
                    // StaticMemory初期化
                    if (isBufferClear)
                    {
                        InitializeCustomerLedger();
                    }

                    // --- ADD 2012/10/02 ---------->>>>>
                    // オプションコードの仕入先総括利用可否を取得
                    Broadleaf.Application.Remoting.ParamData.PurchaseStatus sumSuppPs;
                    sumSuppPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
                    // --- ADD 2012/10/02 ----------<<<<<

                    if (mode == (int)Mode.Shr)
                    {
                        // データ取得準備、パラメーター設定
                        Broadleaf.Application.Remoting.ParamData.SuplierPayInfGetParameter param = new Broadleaf.Application.Remoting.ParamData.SuplierPayInfGetParameter();
                        param.AddUpSecCodeList = sectionCodeList;
                        param.EnterpriseCode = enterpriseCode;
                        param.StartAddUpYearMonth = TDateTime.LongDateToDateTime(int.Parse(startYearMonth.ToString() + "02"));
                        param.EndAddUpYearMonth = TDateTime.LongDateToDateTime(int.Parse(endYearMonth.ToString() + "01"));
                        param.SupplierCd = supplierCode;
                        param.StartSupplierCd = startCustomerCode;
                        param.EndSupplierCd = endCustomerCode;

                        // --- ADD 2012/10/02 ---------->>>>>
                        if (sumSuppPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                        {
                            // 仕入先総括利用可否を利用可
                            param.SumSuppEnable = 1;
                        }
                        else
                        {
                            // 仕入先総括利用可否を利用不可
                            param.SumSuppEnable = 0;
                        }
                        // --- ADD 2012/10/02 ----------<<<<<
                        // 仕入先支払関連データ取得                      
                        //status = GetSupplierPayInfo(printDiv, param);// DEL 2014/02/26 田建委 Redmine#42188
                        status = GetSupplierPayInfo(printDiv, param, outMoneyDiv);// ADD 2014/02/26 田建委 Redmine#42188
                    }
                    else
                        if (mode == (int)Mode.Kai)
                        {
                            // データ取得準備、パラメーター設定
                            Broadleaf.Application.Remoting.ParamData.SuplAccInfGetParameter　param = new Broadleaf.Application.Remoting.ParamData.SuplAccInfGetParameter();
                            param.AddUpSecCodeList = sectionCodeList;
                            param.EnterpriseCode = enterpriseCode;
                            param.StartAddUpYearMonth = TDateTime.LongDateToDateTime(int.Parse(startYearMonth.ToString() + "02"));
                            param.EndAddUpYearMonth = TDateTime.LongDateToDateTime(int.Parse(endYearMonth.ToString() + "01"));
                            param.SupplierCd = supplierCode;
                            param.StartSupplierCd = startCustomerCode;
                            param.EndSupplierCd = endCustomerCode;

                            // --- ADD 2012/10/02 ---------->>>>>
                            if (sumSuppPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                            {
                                // 仕入先総括利用可否を利用可
                                param.SumSuppEnable = 1;
                            }
                            else
                            {
                                // 仕入先総括利用可否を利用不可
                                param.SumSuppEnable = 0;
                            }
                            // --- ADD 2012/10/02 ----------<<<<<

                            // 仕入先買掛関連データ取得
                            //status = GetSupplierAccPayInfo(printDiv,param);// DEL 2014/02/26 田建委 Redmine#42188
                            status = GetSupplierAccPayInfo(printDiv, param, outMoneyDiv);// ADD 2014/02/26 田建委 Redmine#42188
                        }
                }
            }

            #region [元のやつ]
            //try
            //{
            //    // 静的領域同期化処理
            //    lock (typeof(SupplierLedgerAcs))
            //    {
            //        // StaticMemory初期化
            //        if (isBufferClear)
            //        {
            //            InitializeCustomerLedger();
            //        }

            //        if (mode == (int)Mode.Shr)
            //        {
            //            // 仕入先支払関連データ取得                      
            //            status = GetSupplierPayInfo(enterpriseCode, customerCode, startCustomerCode, endCustomerCode, startYearMonth, endYearMonth, sectionCode, sectionCodeList, realMode);
            //        }
            //        else
            //            if (mode == (int)Mode.Kai)
            //            {
            //                // 仕入先買掛関連データ取得
            //                status = GetSupplierAccPayInfo(enterpriseCode, customerCode, startCustomerCode, endCustomerCode, startYearMonth, endYearMonth, sectionCode, sectionCodeList, realMode);
            //            }
            //    }
            //}
            #endregion

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

        #region 元帳仕入先情報(得意先毎)(static memory)の取得
        /// <summary>
		/// 元帳仕入先情報(static memory)の取得
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>元帳仕入先情報データクラス</returns>
		/// <remarks>
		/// <br>Note       : 仕入先情報を取得します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public StockLedgerSupplier SupplierInfo(int customerCode)
		{
			if (_stockLedgerSupplierInfoTable.Contains(customerCode))
			{
				StockLedgerSupplier cs = (StockLedgerSupplier)_stockLedgerSupplierInfoTable[customerCode];
				return cs.Clone();
			}
			else
			{
				return new StockLedgerSupplier();
			}
        }

        #endregion

        #region 元帳仕入先情報(得意先 + 計上日 + 拠点毎)(static memory)の取得

        /// <summary>
		/// 元帳仕入先情報(static memory)の取得
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
        /// <param name="addUpdate">計上日</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>元帳仕入先情報データクラス</returns>
		/// <remarks>
		/// <br>Note       : 仕入先情報を取得します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public StockLedgerSupplier SupplierInfo(int customerCode,int addUpdate,string sectionCode)
		{
            //キー作成(得意先+計上日+拠点)
            string key = customerCode.ToString() + "_" + addUpdate.ToString() + "_" + sectionCode;
			if (_stockLedgerSupplierInfoTable.Contains(key))
			{
				StockLedgerSupplier supInfo = (StockLedgerSupplier)_stockLedgerSupplierInfoTable[key];
				return supInfo.Clone();
			}
			else
			{
				return new StockLedgerSupplier();
			}
        }

        #endregion

        #region 元帳仕入先金額合計情報(static memory)の取得
        /// <summary>
        /// 元帳仕入先金額合計情報(static memory)の取得
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="sectionCode">指定拠点コード</param>
        /// <param name="stockLedgerPay">仕入先元帳支払金額合計情報</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>true:取得成功,false:データなし</returns>
        /// <remarks>
        /// <br>Note       : 仕入先金額の合計情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public bool GetTotalSuplierPay(int customerCode, string sectionCode, out StockLedgerPay stockLedgerPay, out string msg)
        {
            msg = string.Empty;
            stockLedgerPay = null;
            int totalCleateCounter = 0;
            ArrayList suplierPaysList;

            if (SearchSuplierPayToArray(customerCode, sectionCode, out suplierPaysList, out msg))
            {
                stockLedgerPay = new StockLedgerPay();

                for (int index = 0; index < suplierPaysList.Count; index++)
                {
                    StockLedgerPay wkStockLedgePay = (StockLedgerPay)suplierPaysList[index];

                    // 未締データは鑑に加えない
                    if (wkStockLedgePay.CloseFlag == (int)CloseFlagState.NotClose)
                        continue;

                    // 合計タブ作成判断カウンター
                    totalCleateCounter++;

                    if (index == 0)
                    {
                        //拠点コードも返す
                        stockLedgerPay.AddUpSecCode = wkStockLedgePay.AddUpSecCode;
                        stockLedgerPay.PayeeCode = wkStockLedgePay.PayeeCode;
                        stockLedgerPay.CustomerCode = wkStockLedgePay.CustomerCode;

                        // 得意先コード
                        // 3回前残高,2回前残高,前回残高は先頭レコードの金額情報
                        stockLedgerPay.StockTtl3TmBfBlPay = wkStockLedgePay.StockTtl3TmBfBlPay;	        // 仕入3回前残高
                        stockLedgerPay.StockTtl2TmBfBlPay = wkStockLedgePay.StockTtl2TmBfBlPay;	        // 仕入2回前残高
                        stockLedgerPay.LastTimePayment = wkStockLedgePay.LastTimePayment;	            // 仕入前月残高
                    }

                    stockLedgerPay.StockSlipCount += wkStockLedgePay.StockSlipCount;		        // 仕入伝票枚数
                    stockLedgerPay.ReturnGoodsSlipCount += wkStockLedgePay.ReturnGoodsSlipCount;        // 返品伝票枚数
                    stockLedgerPay.TotalSlipCount += wkStockLedgePay.TotalSlipCount;		        // 伝票枚数合計

                    stockLedgerPay.ThisTimeStockPrice += wkStockLedgePay.ThisTimeStockPrice;	        // 今回仕入額
                    stockLedgerPay.ThisTimeStockPrcTax += wkStockLedgePay.ThisTimeStockPrcTax;	        // 今回仕入消費税
                    stockLedgerPay.OfsThisTimeStock += wkStockLedgePay.OfsThisTimeStock;            // 相殺後額    
                    stockLedgerPay.OfsThisStockTax += wkStockLedgePay.OfsThisStockTax;	            // 相殺後消費税額
                    stockLedgerPay.ThisTimeStockPriceRgds += wkStockLedgePay.ThisTimeStockPriceRgds;	    // 今回返品額
                    stockLedgerPay.ThisTimeStockPriceTaxRgds += wkStockLedgePay.ThisTimeStockPriceTaxRgds;	// 今回返品消費税
                    stockLedgerPay.ThisTimePayNrml += wkStockLedgePay.ThisTimePayNrml;		        // 支払額

                }

                if (totalCleateCounter < 2)
                {
                    return false;
                }

                int listCount = suplierPaysList.Count;
                int afCalDemandIndex = 1;
                if (((StockLedgerPay)suplierPaysList[listCount - afCalDemandIndex]).CloseFlag == (int)CloseFlagState.NotClose &&
                    listCount > 1)
                    afCalDemandIndex = 2;
                else
                    // 最終レコードが未締めの場合
                    // 最終レコードの一個手前の計算後請求金額が合計タブの計算後請求金額になる
                    // 件数が未締の一軒しかない場合は最後のレコードをとるしかない
                    afCalDemandIndex = 1;

                // 残高
                stockLedgerPay.StockTotalPayBalance = ((StockLedgerPay)suplierPaysList[listCount - afCalDemandIndex]).StockTotalPayBalance;
                //最終の計上日を戻す(合計タブが選択された時に鑑に表示される転嫁方式はこの月の設定になる)
                stockLedgerPay.AddUpDate = ((StockLedgerPay)suplierPaysList[listCount - afCalDemandIndex]).AddUpDate; //計上日

                stockLedgerPay.StartDateSpan = TDateTime.DateTimeToLongDate(_startTtlAddUpDateSpan);		    // 締対象日付範囲（開始）
                stockLedgerPay.EndDateSpan = TDateTime.DateTimeToLongDate(_endTtlAddUpDateSpan);		    // 締対象日付範囲（終了）
                stockLedgerPay.CloseFlag = (int)CloseFlagState.Close;

                return true;
            }
            else
            {
                return false;

            }
        }

        #endregion

        #region 仕入先元帳用鑑データ配列取得
        /// <summary>
        /// 仕入先元帳用鑑データ配列取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="stockLedgerPays">仕入先元帳用鑑データ配列</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>true:取得成功,false:データなし</returns>
        /// <remarks>
        /// <br>Note       : 仕入先元帳用鑑データを取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public bool SearchSuplierPayToList(string sectionCode, out StockLedgerPay[] stockLedgerPays, out string msg)
        {
            return SearchSuplierPayToList(0, sectionCode, out stockLedgerPays, out msg);
        }

        #endregion

        #region  仕入先元帳用鑑データ配列取得(得意先指定)
        /// <summary>
        /// 仕入先元帳用鑑データ配列取得(得意先指定)
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="stockLedgerPays">仕入先元帳用鑑データ配列</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>true:取得成功,false:データなし</returns>
        /// <remarks>
        /// <br>Note       : 仕入先元帳用鑑データを取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public bool SearchSuplierPayToList(int customerCode, string sectionCode, out StockLedgerPay[] stockLedgerPays, out string msg)
        {
            stockLedgerPays = null;
            ArrayList stockLedgerPayList;
            bool exist = SearchSuplierPayToArray(customerCode, sectionCode, out stockLedgerPayList, out msg);
            if (exist)
            {
                stockLedgerPays = (StockLedgerPay[])stockLedgerPayList.ToArray(typeof(StockLedgerPay));
            }
            return exist;
        }

        #endregion

        #region 仕入先元帳用鑑データ配列取得
        /// <summary>
        /// 仕入先元帳用鑑データリスト取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="stockLedgerPayList">仕入先元帳用鑑データリスト</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>true:取得成功,false:データなし</returns>
        /// <remarks>
        /// <br>Note       : 仕入先元帳用鑑データを取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public bool SearchSuplierPayToArray(string sectionCode, out ArrayList stockLedgerPayList, out string msg)
        {
            return SearchSuplierPayToArray(0, sectionCode, out stockLedgerPayList, out msg);
        }

        #endregion

        #region 仕入先元帳用鑑データリスト取得(得意先指定)
        /// <summary>
        /// 仕入先元帳用鑑データリスト取得(得意先指定)
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="stockLedgerPayList">仕入先元帳用鑑データリスト</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>true:取得成功,false:データなし</returns>
        /// <remarks>
        /// <br>Note       : 仕入先元帳用鑑データを取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public bool SearchSuplierPayToArray(int customerCode, string sectionCode, out ArrayList stockLedgerPayList, out string msg)
        {
            stockLedgerPayList = null;
            msg = string.Empty;

            //仕入先金額(鑑)テーブル
            if (_suplierPayDataTable.Rows.Count > 0)
            {
                StringBuilder filter = new StringBuilder(String.Format("{0}='{1}'", COL_Spl_AddUpSecCode, sectionCode));

                // 得意先コードが指定されている場合
                if (customerCode != 0) filter.Append(String.Format(" AND {0}={1}", COL_Spl_PayeeCode, customerCode));

                string sort = COL_Spl_AddUpSecCode + "," + COL_Spl_PayeeCode + "," + COL_Spl_AddUpDate;

                // 仕入先元帳用鑑データ金額情報リスト取得
                stockLedgerPayList = this.GetStockLedgerPayList(filter.ToString(), sort);

                return true;
            }
            else
            {
                msg = "取引がありません。";
                return false;
            }
        }

        #endregion

        #region 仕入先元帳用鑑データDataView取得
        /// <summary>
		/// 仕入先元帳用鑑データDataView取得
		/// </summary>
		/// <param name="sectionCode">指定拠点コード</param>
		/// <param name="dv">仕入先金額DataView</param>
		/// <param name="msg">メッセージ</param>
		/// <returns>true:取得成功,false:データなし</returns>
		/// <remarks>
		/// <br>Note       : 仕入先元帳用鑑データを取得します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public bool GetStaticSuplierPayToDataView(string sectionCode, out DataView dv, out string msg)
		{
			dv = null;
			msg = "取引がありません。";

            //仕入先金額(鑑)テーブル
			if (_suplierPayDataTable.Rows.Count > 0)
			{
				string filter = String.Format("{0}='{1}'", COL_Spl_AddUpSecCode, sectionCode);
				string sort = COL_Spl_AddUpSecCode + "," + COL_Spl_PayeeCode + "," + COL_Spl_AddUpDate;

				dv = new DataView(_suplierPayDataTable, filter, sort, DataViewRowState.CurrentRows);

				if (dv.Count > 0) return true;
			}

			return false;
        }

        #endregion

        #region 元帳明細情報フィルタリング処理
        ///// <summary>
        ///// 元帳明細情報フィルタリング処理
        ///// </summary>
        ///// <param name="customerCode">得意先コード</param>
        ///// <param name="startDate">計上年月日(開始)</param>
        ///// <param name="endDate">計上年月日(終了)</param>
        ///// <param name="sectionCode">計上拠点コード</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : 元帳明細を指定の計上年月日でフィルタリングします。</br>
        ///// <br>Programmer : 20081 疋田 勇人</br>
        ///// <br>Date       : 2007.11.26</br>
        ///// </remarks>
        //public void FilterAddUpDateCsLedgerSlip(int customerCode, int startDate, int endDate, string sectionCode)
        //{
        //    FilterAddUpDateCsLedgerSlip(customerCode, startDate, endDate, sectionCode, ref _stockLedgerSlipDataView);
        //}

        ///// <summary>
        ///// 元帳明細情報フィルタリング処理
        ///// </summary>
        ///// <param name="customerCode">得意先コード</param>
        ///// <param name="startDate">計上年月日(開始)</param>
        ///// <param name="endDate">計上年月日(終了)</param>
        ///// <param name="sectionCode">計上拠点コード</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : 元帳明細を指定の計上年月日でフィルタリングします。</br>
        ///// <br>Programmer : 20081 疋田 勇人</br>
        ///// <br>Date       : 2007.11.26</br>
        ///// </remarks>
        //public void FilterAddUpDateCsLedgerDtl(int customerCode, int startDate, int endDate, string sectionCode)
        //{
        //    FilterAddUpDateCsLedgerDtl(customerCode, startDate, endDate, sectionCode, ref _stockLedgerDtlDataView);
        //}

        ///// <summary>
        ///// 元帳明細情報フィルタリング処理
        ///// </summary>
        ///// <param name="customerCode">得意先コード</param>
        ///// <param name="startDate">計上年月日(開始)</param>
        ///// <param name="endDate">計上年月日(終了)</param>
        ///// <param name="sectionCode">計上拠点コード</param>
        ///// <param name="dv">データビュー</param>
        ///// <remarks>
        ///// <br>Note       : 元帳明細を指定の計上年月日でフィルタリングします。</br>
        ///// <br>Programmer : 20081 疋田 勇人</br>
        ///// <br>Date       : 2007.11.26</br>
        ///// </remarks>
        //public void FilterAddUpDateCsLedgerSlip(int customerCode, int startDate, int endDate, string sectionCode, ref DataView dv)
        //{
        //    StringBuilder filter = new StringBuilder();

        //    // 得意先コード
        //    filter.Append(String.Format("{0}={1}", CT_SplLedger_PayeeCode, customerCode));

        //    // 日付範囲による判断
        //    if (startDate == endDate)
        //    {

        //        // 単月の場合
        //        filter.Append(String.Format(" AND {0}={1}", CT_SplLedger_AddUpDate, startDate));
        //        // 拠点指定
        //        filter.Append(String.Format(" AND {0}='{1}'", CT_SplLedger_AddUpSecCode, sectionCode));

        //    }
        //    else
        //    {
        //        // 複数月の場合
        //        //複数月の場合は開始月の前回残高のみ表示するようにする
        //        filter.Append(String.Format(" AND (({0}={1} AND {2}={3} AND {4}='{5}') OR ({6} IN ({7},{8}) AND {9}='{10}' AND {11} <= {12})",
        //            CT_SplLedger_BalanceCode, (int)BalanceCode.Balance,
        //            CT_SplLedger_AddUpDate, startDate.ToString(),
        //            CT_SplLedger_AddUpSecCode, sectionCode,
        //            CT_SplLedger_BalanceCode, (int)BalanceCode.Others, (int)BalanceCode.Carried,
        //            CT_SplLedger_AddUpSecCode, sectionCode,
        //            CT_SplLedger_AddUpADateInt, endDate));

        //        filter.Append(String.Format(" OR ({0}={1} AND {2}='{3}' AND {4} <= {5})",
        //                CT_SplLedger_BalanceCode, (int)BalanceCode.ConsTax,
        //                CT_SplLedger_AddUpSecCode, sectionCode,
        //                CT_SplLedger_AddUpADateInt, endDate));

        //        filter.Append(")");
        //    }

        //    dv.RowFilter = filter.ToString();
        //    // 残高計算処理
        //    CalcBalance(ref dv);
        //}

        ///// <summary>
        ///// 元帳明細情報フィルタリング処理
        ///// </summary>
        ///// <param name="customerCode">得意先コード</param>
        ///// <param name="startDate">計上年月日(開始)</param>
        ///// <param name="endDate">計上年月日(終了)</param>
        ///// <param name="sectionCode">計上拠点コード</param>
        ///// <param name="dv">データビュー</param>
        ///// <remarks>
        ///// <br>Note       : 元帳明細を指定の計上年月日でフィルタリングします。</br>
        ///// <br>Programmer : 20081 疋田 勇人</br>
        ///// <br>Date       : 2007.11.26</br>
        ///// </remarks>
        //public void FilterAddUpDateCsLedgerDtl(int customerCode, int startDate, int endDate, string sectionCode, ref DataView dv)
        //{
        //    StringBuilder filter = new StringBuilder();

        //    // 得意先コード
        //    filter.Append(String.Format("{0}={1}", CT_DtlLedger_PayeeCode, customerCode));

        //    // 日付範囲による判断
        //    if (startDate == endDate)
        //    {

        //        // 単月の場合
        //        filter.Append(String.Format(" AND {0}={1}", CT_DtlLedger_AddUpDate, startDate));
        //        // 拠点指定
        //        filter.Append(String.Format(" AND {0}='{1}'", CT_DtlLedger_AddUpSecCode, sectionCode));

        //    }
        //    else
        //    {
        //        // 複数月の場合
        //        //複数月の場合は開始月の前回残高のみ表示するようにする
        //        filter.Append(String.Format(" AND (({0}={1} AND {2}={3} AND {4}='{5}') OR ({6} IN ({7},{8}) AND {9}='{10}' AND {11} <= {12})",
        //            CT_DtlLedger_BalanceCode, (int)BalanceCode.Balance,
        //            CT_DtlLedger_AddUpDate, startDate.ToString(),
        //            CT_DtlLedger_AddUpSecCode, sectionCode,
        //            CT_DtlLedger_BalanceCode, (int)BalanceCode.Others, (int)BalanceCode.Carried,
        //            CT_DtlLedger_AddUpSecCode, sectionCode,
        //            CT_DtlLedger_AddUpADateInt, endDate));

        //        filter.Append(String.Format(" OR ({0}={1} AND {2}='{3}' AND {4} <= {5})",
        //                CT_DtlLedger_BalanceCode, (int)BalanceCode.ConsTax,
        //                CT_DtlLedger_AddUpSecCode, sectionCode,
        //                CT_DtlLedger_AddUpADateInt, endDate));

        //        filter.Append(")");
        //    }

        //    dv.RowFilter = filter.ToString();
        //}
        #endregion

        #endregion

        #region Private Method

        #region 仕入先元帳用鑑データリスト取得
        /// <summary>
        /// 仕入先元帳用鑑データリスト取得
        /// </summary>
        /// <param name="filter">フィルタ</param>
        /// <param name="sort">ソート</param>
        /// <returns>仕入先元帳用鑑データリスト</returns>
        /// <remarks>
        /// <br>Note       : 条件に合った仕入先元帳用鑑データをリストで返します。
        ///					 条件に合うものが１件も無い場合には空レコードを１件追加して返します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private ArrayList GetStockLedgerPayList(string filter, string sort)
        {
            ArrayList stockLedgerPayList = new ArrayList();

            //_suplierPayDataTable→仕入先金額(鑑)テーブル
            DataView dv = new DataView(_suplierPayDataTable, filter, sort, DataViewRowState.CurrentRows);
            if (dv.Count == 0)
            {
                // 空レコード作成
                stockLedgerPayList.Add(new StockLedgerPay());
            }
            else
            {
                for (int index = 0; index < dv.Count; index++)
                {
                    stockLedgerPayList.Add(GetStockLedgerPayFromDataRow(dv[index].Row));
                }
            }

            return stockLedgerPayList;
        }

        #endregion

        #endregion

        #region Private Static Method

        #region データ行→仕入先元帳用鑑データクラス取得(StockLedgerPay)
        /// <summary>
        /// データ行→仕入先元帳用鑑データクラス取得
        /// </summary>
        /// <param name="dr">データ行</param>
        /// <returns>仕入先元帳用鑑データクラス</returns>
        /// <remarks>
        /// <br>Note       : データ行より仕入先元帳用鑑データクラスを取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private static StockLedgerPay GetStockLedgerPayFromDataRow(DataRow dr)
        {
            StockLedgerPay stockLedgerPay = new StockLedgerPay();

            stockLedgerPay.AddUpSecCode = GetCellString(dr[COL_Spl_AddUpSecCode]);	// 計上拠点コード
            stockLedgerPay.PayeeCode = GetCellInt32(dr[COL_Spl_PayeeCode]);	// 支払先コード
            stockLedgerPay.CustomerCode = GetCellInt32(dr[COL_Spl_SupplierCd]);	// 得意先コード
            stockLedgerPay.AddUpDate = TDateTime.LongDateToDateTime(GetCellInt32(dr[COL_Spl_AddUpDate]));	// 計上年月日
            //stockLedgerPay.AddUpYearMonth = GetCellInt32(dr[COL_Spl_AddUpYearMonth]);	// 計上年月                     
            //stockLedgerPay.LastTimePayment = GetCellInt64(dr[COL_Spl_LastTimePayment]); // 前回支払金額(前月残高)
            //stockLedgerPay.ThisTimePayNrml = GetCellInt64(dr[COL_Spl_ThisTimePayNrml]); // 今回支払額(通常支払)
            //stockLedgerPay.ThisTimeFeePayNrml = GetCellInt64(dr[COL_Spl_ThisTimeFeePayNrml]); // 今回手数料(通常支払)
            //stockLedgerPay.ThisTimeDisPayNrml = GetCellInt64(dr[COL_Spl_ThisTimeDisPayNrml]); // 今回値引額(通常支払)
            //stockLedgerPay.ThisTimeTtlBlcPay = GetCellInt64(dr[COL_Spl_ThisTimeTtlBlcPay]); // 今回繰越残高（支払計）
            //stockLedgerPay.OfsThisTimeStock = GetCellInt64(dr[COL_Spl_OfsThisTimeStock]); // 相殺後今回仕入金額
            //stockLedgerPay.OfsThisStockTax = GetCellInt64(dr[COL_Spl_OfsThisStockTax]); // 相殺後今回仕入消費税
            //stockLedgerPay.ThisTimeStockPrice = GetCellInt64(dr[COL_Spl_ThisTimeStockPrice]);	// 今回仕入額
            //stockLedgerPay.ThisTimeStockPrcTax = GetCellInt64(dr[COL_Spl_ThisStcPrcTax]);	// 今回仕入消費税額
            //stockLedgerPay.ThisTimeStockPriceRgds = GetCellInt64(dr[COL_Spl_ThisStckPricRgds]);	// 今回返品額
            //stockLedgerPay.ThisTimeStockPriceTaxRgds = GetCellInt64(dr[COL_Spl_ThisStcPrcTaxRgds]);	// 今回返品消費税額
            //stockLedgerPay.StockTotalPayBalance = GetCellInt64(dr[COL_Spl_StockTotalPayBalance]);	// 仕入合計残高
            //stockLedgerPay.StockTtl2TmBfBlPay = GetCellInt64(dr[COL_Spl_StockTtl2TmBfBlPay]);	// 仕入2回前残高
            //stockLedgerPay.StockTtl3TmBfBlPay = GetCellInt64(dr[COL_Spl_StockTtl3TmBfBlPay]);	// 仕入3回前残高
            //stockLedgerPay.StartDateSpan = GetCellInt32(dr[COL_Spl_StartDateSpan]);	// 日付範囲（開始）
            //stockLedgerPay.EndDateSpan = GetCellInt32(dr[COL_Spl_EndDateSpan]);	// 日付範囲（終了）
            //stockLedgerPay.StockSlipCount = GetCellInt32(dr[COL_Spl_StockSlipCount]);	// 仕入伝票枚数
            //stockLedgerPay.ReturnGoodsSlipCount = GetCellInt32(dr[COL_Spl_ReturnGoodsSlipCount]);	// 返品伝票枚数
            //stockLedgerPay.CloseFlag = GetCellInt32(dr[COL_Spl_CloseFlag]); // 締済フラグ

            return stockLedgerPay;
        }
        #endregion
        #region データ行→仕入先元帳用鑑データクラス取得
        /// <summary>
		/// データ行→仕入先元帳用鑑データクラス取得
		/// </summary>
		/// <param name="dr">データ行</param>
		/// <returns>仕入先元帳用鑑データクラス</returns>
		/// <remarks>
		/// <br>Note       : データ行より仕入先元帳用鑑データクラスを取得します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private static SuplierPayInfGet GetSuplierPayInfGetFromDataRow(DataRow dr)
		{
            SuplierPayInfGet suplierPayInfGet = new SuplierPayInfGet();
            
            suplierPayInfGet.EnterpriseCode = GetCellString(dr[COL_Spl_EnterpriseCode]); // 企業コード
            suplierPayInfGet.AddUpSecCode = GetCellString(dr[COL_Spl_AddUpSecCode]); // 計上拠点コード
            suplierPayInfGet.AddUpSecName = GetCellString(dr[COL_Spl_AddUpSecName]); // 計上拠点名
            suplierPayInfGet.PayeeCode = GetCellInt32(dr[COL_Spl_PayeeCode]); // 支払先コード
            suplierPayInfGet.PayeeName = GetCellString(dr[COL_Spl_PayeeName]); // 支払先名称
            suplierPayInfGet.PayeeName2 = GetCellString(dr[COL_Spl_PayeeName2]); // 支払先名称2
            suplierPayInfGet.PayeeSnm = GetCellString(dr[COL_Spl_PayeeSnm]); // 支払先略称
            suplierPayInfGet.ResultsSectCd = GetCellString(dr[COL_Spl_ResultsSectCd]); // 実績拠点コード
            suplierPayInfGet.SupplierCd = GetCellInt32(dr[COL_Spl_SupplierCd]); // 仕入先コード
            suplierPayInfGet.SupplierNm1 = GetCellString(dr[COL_Spl_SupplierNm1]); // 仕入先名1
            suplierPayInfGet.SupplierNm2 = GetCellString(dr[COL_Spl_SupplierNm2]); // 仕入先名2
            suplierPayInfGet.SupplierSnm = GetCellString(dr[COL_Spl_SupplierSnm]); // 仕入先略称
            suplierPayInfGet.AddUpDate = GetCellDateTime(dr[COL_Spl_AddUpDate]); // 計上年月日 
            suplierPayInfGet.AddUpYearMonth = GetCellDateTime(dr[COL_Spl_AddUpYearMonth]); // 計上年月
            suplierPayInfGet.LastTimePayment = GetCellInt64(dr[COL_Spl_LastTimePayment]); // 前回支払金額
            suplierPayInfGet.StockTtl2TmBfBlPay = GetCellInt64(dr[COL_Spl_StockTtl2TmBfBlPay]); // 仕入2回前残高（支払計）
            suplierPayInfGet.StockTtl3TmBfBlPay = GetCellInt64(dr[COL_Spl_StockTtl3TmBfBlPay]); // 仕入3回前残高（支払計）
            suplierPayInfGet.ThisTimePayNrml = GetCellInt64(dr[COL_Spl_ThisTimePayNrml]); // 今回支払金額（通常支払）
            suplierPayInfGet.ThisTimeTtlBlcPay = GetCellInt64(dr[COL_Spl_ThisTimeTtlBlcPay]); // 今回繰越残高（支払計）
            suplierPayInfGet.OfsThisTimeStock = GetCellInt64(dr[COL_Spl_OfsThisTimeStock]); // 相殺後今回仕入金額
            suplierPayInfGet.OfsThisStockTax = GetCellInt64(dr[COL_Spl_OfsThisStockTax]); // 相殺後今回仕入消費税
            suplierPayInfGet.ThisStckPricRgds = GetCellInt64(dr[COL_Spl_ThisStckPricRgds]); // 今回返品金額
            suplierPayInfGet.ThisStcPrcTaxRgds = GetCellInt64(dr[COL_Spl_ThisStcPrcTaxRgds]); // 今回返品消費税
            suplierPayInfGet.ThisStckPricDis = GetCellInt64(dr[COL_Spl_ThisStckPricDis]); // 今回値引金額
            suplierPayInfGet.ThisStcPrcTaxDis = GetCellInt64(dr[COL_Spl_ThisStcPrcTaxDis]); // 今回値引消費税
            suplierPayInfGet.ThisStckPricRgdsDis = GetCellInt64(dr[COL_Spl_ThisStckPricRgdsDis]); // 今回返品・値引金額
            suplierPayInfGet.TaxAdjust = GetCellInt64(dr[COL_Spl_TaxAdjust]); // 消費税調整額
            suplierPayInfGet.BalanceAdjust = GetCellInt64(dr[COL_Spl_BalanceAdjust]); // 残高調整額
            suplierPayInfGet.StockTotalPayBalance = GetCellInt64(dr[COL_Spl_StockTotalPayBalance]); // 仕入合計残高（支払計）
            suplierPayInfGet.CAddUpUpdExecDate = GetCellDateTime(dr[COL_Spl_CAddUpUpdExecDate]); // 締次更新実行年月日　
            suplierPayInfGet.StartCAddUpUpdDate = GetCellDateTime(dr[COL_Spl_StartCAddUpUpdDate]); // 締次更新開始年月日　
            suplierPayInfGet.LastCAddUpUpdDate = GetCellDateTime(dr[COL_Spl_LastCAddUpUpdDate]); // 前回締次更新年月日
            suplierPayInfGet.StockSlipCount = GetCellInt32(dr[COL_Spl_StockSlipCount]); // 仕入伝票枚数
            suplierPayInfGet.CloseFlg = GetCellInt32(dr[COL_Spl_CloseFlg]); // 締済みフラグ


            return suplierPayInfGet;
        }
        #endregion

        #region データセル→データ取得処理
        /// <summary>
		/// データセル→文字列取得
		/// </summary>
		/// <param name="cell">データセル</param>
		/// <returns>取得文字列</returns>
		/// <remarks>
		/// <br>Note       : データセルに格納されている値がDBNullかどうかを判別して値を返します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private static DateTime GetCellDateTime(object cell)
		{
			return (cell != DBNull.Value) ? (DateTime)cell : new DateTime(1, 1, 1);
        }

        #endregion

        #region DataSet,DataTable生成
        /// <summary>
		/// データセット、データテーブル設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private static void SettingDataSet()
		{
			if (_stockLedgerDataSet == null)
			{
				_stockLedgerDataSet = new DataSet();
                ////仕入先金額テーブル(鑑)作成
				CreateSuplierPayTable(ref _stockLedgerDataSet);
                //仕入先元帳伝票テーブル作成
                CreateSlipLedgerTable(ref _stockLedgerDataSet);
                //仕入先元帳明細テーブル作成
                CreateDtlLedgerTable(ref _stockLedgerDataSet);
			}
		}

		/// <summary>
		/// 仕入先金額テーブル(鑑)情報作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private static void CreateSuplierPayTable(ref DataSet ds)
		{
			DataTable  dt = new DataTable(TABLE_SuplierPay);

            #region カラム設定
            // 企業コード
            dt.Columns.Add(COL_Spl_EnterpriseCode, typeof(string));
            dt.Columns[COL_Spl_EnterpriseCode].Caption = "企業コード";
            // 計上拠点コード
            dt.Columns.Add(COL_Spl_AddUpSecCode, typeof(string));
            dt.Columns[COL_Spl_AddUpSecCode].Caption = "計上拠点コード";
            // 計上拠点名
            dt.Columns.Add(COL_Spl_AddUpSecName, typeof(string));
            dt.Columns[COL_Spl_AddUpSecName].Caption = "計上拠点名";
            // 支払先コード
            dt.Columns.Add(COL_Spl_PayeeCode, typeof(Int32));
            dt.Columns[COL_Spl_PayeeCode].Caption = "支払先コード";
            // 支払先名称
            dt.Columns.Add(COL_Spl_PayeeName, typeof(string));
            dt.Columns[COL_Spl_PayeeName].Caption = "支払先名称";
            // 支払先名称2
            dt.Columns.Add(COL_Spl_PayeeName2, typeof(string));
            dt.Columns[COL_Spl_PayeeName2].Caption = "支払先名称2";
            // 支払先略称
            dt.Columns.Add(COL_Spl_PayeeSnm, typeof(string));
            dt.Columns[COL_Spl_PayeeSnm].Caption = "支払先略称";
            // 実績拠点コード
            dt.Columns.Add(COL_Spl_ResultsSectCd, typeof(string));
            dt.Columns[COL_Spl_ResultsSectCd].Caption = "実績拠点コード";
            // 仕入先コード
            dt.Columns.Add(COL_Spl_SupplierCd, typeof(Int32));
            dt.Columns[COL_Spl_SupplierCd].Caption = "仕入先コード";
            // 仕入先名1
            dt.Columns.Add(COL_Spl_SupplierNm1, typeof(string));
            dt.Columns[COL_Spl_SupplierNm1].Caption = "仕入先名1";
            // 仕入先名2
            dt.Columns.Add(COL_Spl_SupplierNm2, typeof(string));
            dt.Columns[COL_Spl_SupplierNm2].Caption = "仕入先名2";
            // 仕入先略称
            dt.Columns.Add(COL_Spl_SupplierSnm, typeof(string));
            dt.Columns[COL_Spl_SupplierSnm].Caption = "仕入先略称";
            // 計上年月日
            dt.Columns.Add(COL_Spl_AddUpDate, typeof(Int32));
            dt.Columns[COL_Spl_AddUpDate].Caption = "計上年月日";
            // 計上年月
            dt.Columns.Add(COL_Spl_AddUpYearMonth, typeof(Int32));
            dt.Columns[COL_Spl_AddUpYearMonth].Caption = "計上年月";
            // 前回支払金額
            dt.Columns.Add(COL_Spl_LastTimePayment, typeof(Int64));
            dt.Columns[COL_Spl_LastTimePayment].Caption = "前回支払金額";
            // 仕入2回前残高（支払計）
            dt.Columns.Add(COL_Spl_StockTtl2TmBfBlPay, typeof(Int64));
            dt.Columns[COL_Spl_StockTtl2TmBfBlPay].Caption = "仕入2回前残高（支払計）";
            // 仕入3回前残高（支払計）
            dt.Columns.Add(COL_Spl_StockTtl3TmBfBlPay, typeof(Int64));
            dt.Columns[COL_Spl_StockTtl3TmBfBlPay].Caption = "仕入3回前残高（支払計）";
            // 今回支払金額（通常支払）
            dt.Columns.Add(COL_Spl_ThisTimePayNrml, typeof(Int64));
            dt.Columns[COL_Spl_ThisTimePayNrml].Caption = "今回支払金額（通常支払）";
            // 今回繰越残高（支払計）
            dt.Columns.Add(COL_Spl_ThisTimeTtlBlcPay, typeof(Int64));
            dt.Columns[COL_Spl_ThisTimeTtlBlcPay].Caption = "今回繰越残高（支払計）";
            // 相殺後今回仕入金額
            dt.Columns.Add(COL_Spl_OfsThisTimeStock, typeof(Int64));
            dt.Columns[COL_Spl_OfsThisTimeStock].Caption = "相殺後今回仕入金額";
            // 税込仕入額
            dt.Columns.Add(COL_Spl_OfsThisTimeStockTax, typeof(Int64));
            dt.Columns[COL_Spl_OfsThisTimeStockTax].Caption = "税込仕入額";
            // 相殺後今回仕入消費税
            dt.Columns.Add(COL_Spl_OfsThisStockTax, typeof(Int64));
            dt.Columns[COL_Spl_OfsThisStockTax].Caption = "相殺後今回仕入消費税";
            // 今回返品金額
            dt.Columns.Add(COL_Spl_ThisStckPricRgds, typeof(Int64));
            dt.Columns[COL_Spl_ThisStckPricRgds].Caption = "今回返品金額";
            // 今回返品消費税
            dt.Columns.Add(COL_Spl_ThisStcPrcTaxRgds, typeof(Int64));
            dt.Columns[COL_Spl_ThisStcPrcTaxRgds].Caption = "今回返品消費税";
            // 今回値引金額
            dt.Columns.Add(COL_Spl_ThisStckPricDis, typeof(Int64));
            dt.Columns[COL_Spl_ThisStckPricDis].Caption = "今回値引金額";
            // 今回値引消費税
            dt.Columns.Add(COL_Spl_ThisStcPrcTaxDis, typeof(Int64));
            dt.Columns[COL_Spl_ThisStcPrcTaxDis].Caption = "今回値引消費税";
            // 今回返品・値引金額
            dt.Columns.Add(COL_Spl_ThisStckPricRgdsDis, typeof(Int64));
            dt.Columns[COL_Spl_ThisStckPricRgdsDis].Caption = "今回返品・値引金額";
            // 消費税調整額
            dt.Columns.Add(COL_Spl_TaxAdjust, typeof(Int64));
            dt.Columns[COL_Spl_TaxAdjust].Caption = "消費税調整額";
            // 残高調整額
            dt.Columns.Add(COL_Spl_BalanceAdjust, typeof(Int64));
            dt.Columns[COL_Spl_BalanceAdjust].Caption = "残高調整額";
            // 仕入合計残高（支払計）
            dt.Columns.Add(COL_Spl_StockTotalPayBalance, typeof(Int64));
            dt.Columns[COL_Spl_StockTotalPayBalance].Caption = "仕入合計残高（支払計）";
            // 締次更新実行年月日
            dt.Columns.Add(COL_Spl_CAddUpUpdExecDate, typeof(Int32));
            dt.Columns[COL_Spl_CAddUpUpdExecDate].Caption = "締次更新実行年月日";
            // 締次更新開始年月日
            dt.Columns.Add(COL_Spl_StartCAddUpUpdDate, typeof(Int32));
            dt.Columns[COL_Spl_StartCAddUpUpdDate].Caption = "締次更新開始年月日";
            // 前回締次更新年月日
            dt.Columns.Add(COL_Spl_LastCAddUpUpdDate, typeof(Int32));
            dt.Columns[COL_Spl_LastCAddUpUpdDate].Caption = "前回締次更新年月日";
            // 仕入伝票枚数
            dt.Columns.Add(COL_Spl_StockSlipCount, typeof(Int32));
            dt.Columns[COL_Spl_StockSlipCount].Caption = "仕入伝票枚数";
            // 締済みフラグ
            dt.Columns.Add(COL_Spl_CloseFlg, typeof(Int32));
            dt.Columns[COL_Spl_CloseFlg].Caption = "締済みフラグ";
            // 印刷用 支払・買掛
            dt.Columns.Add(COL_Spl_SlitTitle, typeof(String));
            dt.Columns[COL_Spl_SlitTitle].Caption = "印刷用 支払残・買掛残";

            // 2009.02.24 30413 犬飼 今回仕入金額の追加 >>>>>>START
            // 税込仕入額
            dt.Columns.Add(COL_Spl_ThisTimeStockPrice, typeof(Int64));
            dt.Columns[COL_Spl_ThisTimeStockPrice].Caption = "今回仕入金額";
            // 2009.02.24 30413 犬飼 今回仕入金額の追加 <<<<<<END

            // --- ADD 2012/11/01 ---------->>>>>
            // 消費税転嫁方式
            dt.Columns.Add(COL_Spl_SuppCTaxLayCd, typeof(Int32));
            dt.Columns[COL_Spl_SuppCTaxLayCd].Caption = "消費税転嫁方式";
            // --- ADD 2012/11/01 ----------<<<<<
            #endregion

            ds.Tables.Add(dt);

            //ソート
            //計上拠点コード→得意先コード→計上年月日(締基準)
			string sort = COL_Spl_AddUpSecCode + "," + COL_Spl_PayeeCode + "," + COL_Spl_AddUpDate;

			//仕入先金額(鑑)データテーブル
			_suplierPayDataTable	= dt;
			_suplierPayDataView		= new DataView(_suplierPayDataTable, string.Empty, sort, DataViewRowState.CurrentRows);

			// 仕入先金額DataTable(印刷用)
            //_suplierPayPrintDataTable	= dt.Clone();
            //_suplierPayPrintDataView	= new DataView(_suplierPayPrintDataTable, string.Empty, sort, DataViewRowState.CurrentRows);
		}

        /// <summary>
        /// 仕入先元帳伝票テーブル情報作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private static void CreateSlipLedgerTable(ref DataSet ds)
        {
            //グリッド用
            DataTable dt = new DataTable(TABLE_SplLedger);

            #region [カラム設定]
            // 企業コード
            dt.Columns.Add(CT_SplLedger_EnterpriseCode, typeof(string));
            dt.Columns[CT_SplLedger_EnterpriseCode].Caption = "企業コード";
            // 企業コード
            dt.Columns.Add(CT_SplLedger_AddUpDate, typeof(Int32));
            dt.Columns[CT_SplLedger_AddUpDate].Caption = "企業コード";
            // 仕入形式
            dt.Columns.Add(CT_SplLedger_SupplierFormal, typeof(Int32));
            dt.Columns[CT_SplLedger_SupplierFormal].Caption = "仕入形式";
            // 仕入伝票番号
            dt.Columns.Add(CT_SplLedger_SupplierSlipNo, typeof(Int32));
            dt.Columns[CT_SplLedger_SupplierSlipNo].Caption = "仕入伝票番号";
            // 仕入伝票種別
            dt.Columns.Add(CT_SplLedger_SlipKindNm, typeof(String));
            dt.Columns[CT_SplLedger_SlipKindNm].Caption = "仕入伝票種別";
            // 拠点コード
            dt.Columns.Add(CT_SplLedger_SectionCode, typeof(string));
            dt.Columns[CT_SplLedger_SectionCode].Caption = "拠点コード";
            // 赤伝区分
            dt.Columns.Add(CT_SplLedger_DebitNoteDiv, typeof(Int32));
            dt.Columns[CT_SplLedger_DebitNoteDiv].Caption = "赤伝区分";
            // 赤黒連結仕入伝票番号
            dt.Columns.Add(CT_SplLedger_DebitNLnkSuppSlipNo, typeof(Int32));
            dt.Columns[CT_SplLedger_DebitNLnkSuppSlipNo].Caption = "赤黒連結仕入伝票番号";
            // 仕入伝票区分
            dt.Columns.Add(CT_SplLedger_SupplierSlipCd, typeof(Int32));
            dt.Columns[CT_SplLedger_SupplierSlipCd].Caption = "仕入伝票区分";
            // 仕入商品区分
            dt.Columns.Add(CT_SplLedger_StockGoodsCd, typeof(Int32));
            dt.Columns[CT_SplLedger_StockGoodsCd].Caption = "仕入商品区分";
            // 仕入拠点コード
            dt.Columns.Add(CT_SplLedger_StockSectionCd, typeof(string));
            dt.Columns[CT_SplLedger_StockSectionCd].Caption = "仕入拠点コード";
            // 仕入計上拠点コード
            dt.Columns.Add(CT_SplLedger_StockAddUpSectionCd, typeof(string));
            dt.Columns[CT_SplLedger_StockAddUpSectionCd].Caption = "仕入計上拠点コード";
            // 入力日
            dt.Columns.Add(CT_SplLedger_InputDay, typeof(Int32));
            dt.Columns[CT_SplLedger_InputDay].Caption = "入力日";
            // 入荷日
            dt.Columns.Add(CT_SplLedger_ArrivalGoodsDay, typeof(Int32));
            dt.Columns[CT_SplLedger_ArrivalGoodsDay].Caption = "入荷日";
            // 仕入日
            dt.Columns.Add(CT_SplLedger_StockDate, typeof(Int32));
            dt.Columns[CT_SplLedger_StockDate].Caption = "仕入日";
            // 仕入計上日付
            dt.Columns.Add(CT_SplLedger_StockAddUpADate, typeof(Int32));
            dt.Columns[CT_SplLedger_StockAddUpADate].Caption = "仕入計上日付";
            // 仕入レコード区分
            dt.Columns.Add(CT_SplLedger_StockRecordCd, typeof(Int32));
            dt.Columns[CT_SplLedger_StockRecordCd].Caption = "仕入レコード区分";
            // 仕入入力者コード
            dt.Columns.Add(CT_SplLedger_StockInputCode, typeof(string));
            dt.Columns[CT_SplLedger_StockInputCode].Caption = "仕入入力者コード";
            // 仕入入力者名称
            dt.Columns.Add(CT_SplLedger_StockInputName, typeof(string));
            dt.Columns[CT_SplLedger_StockInputName].Caption = "仕入入力者名称";
            // 仕入担当者コード
            dt.Columns.Add(CT_SplLedger_StockAgentCode, typeof(string));
            dt.Columns[CT_SplLedger_StockAgentCode].Caption = "仕入担当者コード";
            // 仕入担当者名称
            dt.Columns.Add(CT_SplLedger_StockAgentName, typeof(string));
            dt.Columns[CT_SplLedger_StockAgentName].Caption = "仕入担当者名称";
            // 支払先コード
            dt.Columns.Add(CT_SplLedger_PayeeCode, typeof(Int32));
            dt.Columns[CT_SplLedger_PayeeCode].Caption = "支払先コード";
            // 支払先略称
            dt.Columns.Add(CT_SplLedger_PayeeSnm, typeof(string));
            dt.Columns[CT_SplLedger_PayeeSnm].Caption = "支払先略称";
            // 仕入先コード
            dt.Columns.Add(CT_SplLedger_SupplierCd, typeof(Int32));
            dt.Columns[CT_SplLedger_SupplierCd].Caption = "仕入先コード";
            // 仕入先名1
            dt.Columns.Add(CT_SplLedger_SupplierNm1, typeof(string));
            dt.Columns[CT_SplLedger_SupplierNm1].Caption = "仕入先名1";
            // 仕入先名2
            dt.Columns.Add(CT_SplLedger_SupplierNm2, typeof(string));
            dt.Columns[CT_SplLedger_SupplierNm2].Caption = "仕入先名2";
            // 仕入先略称
            dt.Columns.Add(CT_SplLedger_SupplierSnm, typeof(string));
            dt.Columns[CT_SplLedger_SupplierSnm].Caption = "仕入先略称";
            // 仕入金額合計
            dt.Columns.Add(CT_SplLedger_StockTotalPrice, typeof(Int64));
            dt.Columns[CT_SplLedger_StockTotalPrice].Caption = "仕入金額合計";
            // 仕入金額小計
            dt.Columns.Add(CT_SplLedger_StockSubttlPrice, typeof(Int64));
            dt.Columns[CT_SplLedger_StockSubttlPrice].Caption = "仕入金額小計";
            // 仕入金額消費税額
            dt.Columns.Add(CT_SplLedger_StockPriceConsTax, typeof(Int64));
            dt.Columns[CT_SplLedger_StockPriceConsTax].Caption = "仕入金額消費税額";
            // 相手先伝票番号
            dt.Columns.Add(CT_SplLedger_PartySaleSlipNum, typeof(string));
            dt.Columns[CT_SplLedger_PartySaleSlipNum].Caption = "相手先伝票番号";
            // 仕入伝票備考1
            dt.Columns.Add(CT_SplLedger_SupplierSlipNote1, typeof(string));
            dt.Columns[CT_SplLedger_SupplierSlipNote1].Caption = "仕入伝票備考1";
            // 仕入伝票備考2
            dt.Columns.Add(CT_SplLedger_SupplierSlipNote2, typeof(string));
            dt.Columns[CT_SplLedger_SupplierSlipNote2].Caption = "仕入伝票備考2";
            // ＵＯＥリマーク１
            dt.Columns.Add(CT_SplLedger_UoeRemark1, typeof(string));
            dt.Columns[CT_SplLedger_UoeRemark1].Caption = "ＵＯＥリマーク１";
            // ＵＯＥリマーク２
            dt.Columns.Add(CT_SplLedger_UoeRemark2, typeof(string));
            dt.Columns[CT_SplLedger_UoeRemark2].Caption = "ＵＯＥリマーク２";
            //以下は支払伝票
            // 支払金額
            dt.Columns.Add(CT_SplLedger_Payment, typeof(Int64));
            dt.Columns[CT_SplLedger_Payment].Caption = "支払金額";
            // 有効期限
            dt.Columns.Add(CT_SplLedger_ValidityTerm, typeof(Int32));
            dt.Columns[CT_SplLedger_ValidityTerm].Caption = "有効期限";
            // 支払用金額区分名
            dt.Columns.Add(CT_SplLedger_GoodsName, typeof(string));
            dt.Columns[CT_SplLedger_GoodsName].Caption = "支払用金額区分名";
            // 支払用金額区分
            dt.Columns.Add(CT_SplLedger_GoodsDiv, typeof(Int32));
            dt.Columns[CT_SplLedger_GoodsDiv].Caption = "支払用金額区分";


            #endregion

            ds.Tables.Add(dt);

            //ソート
            string sort = CT_SplLedger_SectionCode + "," + CT_SplLedger_PayeeCode + "," + CT_SplLedger_SupplierCd + "," + CT_SplLedger_StockAddUpADate + "," + CT_SplLedger_SupplierSlipNo;

            _stockLedgerSlipDataTable = dt;
            _stockLedgerSlipDataView = new DataView(_stockLedgerSlipDataTable, string.Empty, sort, DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// 仕入先元帳明細テーブル情報作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private static void CreateDtlLedgerTable(ref DataSet ds)
        {
            //グリッド用
            DataTable dt = new DataTable(TABLE_DtlLedger);

            #region カラム設定
            // 企業コード
            dt.Columns.Add(CT_DtlLedger_EnterpriseCode, typeof(string));
            dt.Columns[CT_DtlLedger_EnterpriseCode].Caption = "企業コード";
            // 計上日付(締基準)
            dt.Columns.Add(CT_DtlLedger_AddUpDate, typeof(Int32));
            dt.Columns[CT_DtlLedger_AddUpDate].Caption = "計上日付(締基準)";
            // 仕入形式
            dt.Columns.Add(CT_DtlLedger_SupplierFormal, typeof(Int32));
            dt.Columns[CT_DtlLedger_SupplierFormal].Caption = "仕入形式";
            // 仕入伝票番号
            dt.Columns.Add(CT_DtlLedger_SupplierSlipNo, typeof(Int32));
            dt.Columns[CT_DtlLedger_SupplierSlipNo].Caption = "仕入伝票番号";
            // 仕入伝票種別
            dt.Columns.Add(CT_DtlLedger_SlipKindNm, typeof(String));
            dt.Columns[CT_DtlLedger_SlipKindNm].Caption = "仕入伝票種別";
            // 拠点コード
            dt.Columns.Add(CT_DtlLedger_SectionCode, typeof(string));
            dt.Columns[CT_DtlLedger_SectionCode].Caption = "拠点コード";
            // 赤伝区分
            dt.Columns.Add(CT_DtlLedger_DebitNoteDiv, typeof(Int32));
            dt.Columns[CT_DtlLedger_DebitNoteDiv].Caption = "赤伝区分";
            // 赤黒連結仕入伝票番号
            dt.Columns.Add(CT_DtlLedger_DebitNLnkSuppSlipNo, typeof(Int32));
            dt.Columns[CT_DtlLedger_DebitNLnkSuppSlipNo].Caption = "赤黒連結仕入伝票番号";
            // 仕入伝票区分
            dt.Columns.Add(CT_DtlLedger_SupplierSlipCd, typeof(Int32));
            dt.Columns[CT_DtlLedger_SupplierSlipCd].Caption = "仕入伝票区分";
            // 仕入商品区分
            dt.Columns.Add(CT_DtlLedger_StockGoodsCd, typeof(Int32));
            dt.Columns[CT_DtlLedger_StockGoodsCd].Caption = "仕入商品区分";
            // 仕入拠点コード
            dt.Columns.Add(CT_DtlLedger_StockSectionCd, typeof(string));
            dt.Columns[CT_DtlLedger_StockSectionCd].Caption = "仕入拠点コード";
            // 仕入計上拠点コード
            dt.Columns.Add(CT_DtlLedger_StockAddUpSectionCd, typeof(string));
            dt.Columns[CT_DtlLedger_StockAddUpSectionCd].Caption = "仕入計上拠点コード";
            // 入力日
            dt.Columns.Add(CT_DtlLedger_InputDay, typeof(Int32));
            dt.Columns[CT_DtlLedger_InputDay].Caption = "入力日";
            // 入荷日
            dt.Columns.Add(CT_DtlLedger_ArrivalGoodsDay, typeof(Int32));
            dt.Columns[CT_DtlLedger_ArrivalGoodsDay].Caption = "入荷日";
            // 仕入日
            dt.Columns.Add(CT_DtlLedger_StockDate, typeof(Int32));
            dt.Columns[CT_DtlLedger_StockDate].Caption = "仕入日";
            // 仕入計上日付
            dt.Columns.Add(CT_DtlLedger_StockAddUpADate, typeof(Int32));
            dt.Columns[CT_DtlLedger_StockAddUpADate].Caption = "仕入計上日付";
            // 仕入入力者コード
            dt.Columns.Add(CT_DtlLedger_StockInputCode, typeof(string));
            dt.Columns[CT_DtlLedger_StockInputCode].Caption = "仕入入力者コード";
            // 仕入入力者名称
            dt.Columns.Add(CT_DtlLedger_StockInputName, typeof(string));
            dt.Columns[CT_DtlLedger_StockInputName].Caption = "仕入入力者名称";
            // 仕入担当者コード
            dt.Columns.Add(CT_DtlLedger_StockAgentCode, typeof(string));
            dt.Columns[CT_DtlLedger_StockAgentCode].Caption = "仕入担当者コード";
            // 仕入担当者名称
            dt.Columns.Add(CT_DtlLedger_StockAgentName, typeof(string));
            dt.Columns[CT_DtlLedger_StockAgentName].Caption = "仕入担当者名称";
            // 支払先コード
            dt.Columns.Add(CT_DtlLedger_PayeeCode, typeof(Int32));
            dt.Columns[CT_DtlLedger_PayeeCode].Caption = "支払先コード";
            // 支払先略称
            dt.Columns.Add(CT_DtlLedger_PayeeSnm, typeof(string));
            dt.Columns[CT_DtlLedger_PayeeSnm].Caption = "支払先略称";
            // 仕入先コード
            dt.Columns.Add(CT_DtlLedger_SupplierCd, typeof(Int32));
            dt.Columns[CT_DtlLedger_SupplierCd].Caption = "仕入先コード";
            // 仕入先レコード区分
            dt.Columns.Add(CT_DtlLedger_StockRecordCd, typeof(Int32));
            dt.Columns[CT_DtlLedger_StockRecordCd].Caption = "仕入先レコード区分";
            // 仕入先名1
            dt.Columns.Add(CT_DtlLedger_SupplierNm1, typeof(string));
            dt.Columns[CT_DtlLedger_SupplierNm1].Caption = "仕入先名1";
            // 仕入先名2
            dt.Columns.Add(CT_DtlLedger_SupplierNm2, typeof(string));
            dt.Columns[CT_DtlLedger_SupplierNm2].Caption = "仕入先名2";
            // 仕入先略称
            dt.Columns.Add(CT_DtlLedger_SupplierSnm, typeof(string));
            dt.Columns[CT_DtlLedger_SupplierSnm].Caption = "仕入先略称";
            // 仕入金額合計
            dt.Columns.Add(CT_DtlLedger_StockTotalPrice, typeof(Int64));
            dt.Columns[CT_DtlLedger_StockTotalPrice].Caption = "仕入金額合計";
            // 仕入金額小計
            dt.Columns.Add(CT_DtlLedger_StockSubttlPrice, typeof(Int64));
            dt.Columns[CT_DtlLedger_StockSubttlPrice].Caption = "仕入金額小計";
            // 仕入金額消費税額
            dt.Columns.Add(CT_DtlLedger_StockPriceConsTax, typeof(Int64));
            dt.Columns[CT_DtlLedger_StockPriceConsTax].Caption = "仕入金額消費税額";
            // 相手先伝票番号
            dt.Columns.Add(CT_DtlLedger_PartySaleSlipNum, typeof(string));
            dt.Columns[CT_DtlLedger_PartySaleSlipNum].Caption = "相手先伝票番号";
            // 仕入伝票備考1
            dt.Columns.Add(CT_DtlLedger_SupplierSlipNote1, typeof(string));
            dt.Columns[CT_DtlLedger_SupplierSlipNote1].Caption = "仕入伝票備考1";
            // 仕入伝票備考2
            dt.Columns.Add(CT_DtlLedger_SupplierSlipNote2, typeof(string));
            dt.Columns[CT_DtlLedger_SupplierSlipNote2].Caption = "仕入伝票備考2";
            // ＵＯＥリマーク１
            dt.Columns.Add(CT_DtlLedger_UoeRemark1, typeof(string));
            dt.Columns[CT_DtlLedger_UoeRemark1].Caption = "ＵＯＥリマーク１";
            // ＵＯＥリマーク２
            dt.Columns.Add(CT_DtlLedger_UoeRemark2, typeof(string));
            dt.Columns[CT_DtlLedger_UoeRemark2].Caption = "ＵＯＥリマーク２";
            // 仕入行番号
            dt.Columns.Add(CT_DtlLedger_StockRowNo, typeof(Int32));
            dt.Columns[CT_DtlLedger_StockRowNo].Caption = "仕入行番号";
            // 共通通番
            dt.Columns.Add(CT_DtlLedger_CommonSeqNo, typeof(Int64));
            dt.Columns[CT_DtlLedger_CommonSeqNo].Caption = "共通通番";
            // 仕入明細通番
            dt.Columns.Add(CT_DtlLedger_StockSlipDtlNum, typeof(Int64));
            dt.Columns[CT_DtlLedger_StockSlipDtlNum].Caption = "仕入明細通番";
            // 商品番号
            dt.Columns.Add(CT_DtlLedger_GoodsNo, typeof(string));
            dt.Columns[CT_DtlLedger_GoodsNo].Caption = "商品番号";
            // 商品名称
            dt.Columns.Add(CT_DtlLedger_GoodsName, typeof(string));
            dt.Columns[CT_DtlLedger_GoodsName].Caption = "商品名称";
            // 商品名称カナ
            dt.Columns.Add(CT_DtlLedger_GoodsNameKana, typeof(string));
            dt.Columns[CT_DtlLedger_GoodsNameKana].Caption = "商品名称カナ";
            // 販売先コード
            dt.Columns.Add(CT_DtlLedger_SalesCustomerCode, typeof(Int32));
            dt.Columns[CT_DtlLedger_SalesCustomerCode].Caption = "販売先コード";
            // 販売先略称
            dt.Columns.Add(CT_DtlLedger_SalesCustomerSnm, typeof(string));
            dt.Columns[CT_DtlLedger_SalesCustomerSnm].Caption = "販売先略称";
            // 仕入数
            dt.Columns.Add(CT_DtlLedger_StockCount, typeof(Double));
            dt.Columns[CT_DtlLedger_StockCount].Caption = "仕入数";
            // 仕入単価（税抜，浮動）
            dt.Columns.Add(CT_DtlLedger_StockUnitPriceFl, typeof(Double));
            dt.Columns[CT_DtlLedger_StockUnitPriceFl].Caption = "仕入単価（税抜，浮動）";
            // 仕入金額（税抜き）
            dt.Columns.Add(CT_DtlLedger_StockPriceTaxExc, typeof(Int64));
            dt.Columns[CT_DtlLedger_StockPriceTaxExc].Caption = "仕入金額（税抜き）";
            // 仕入金額消費税額
            dt.Columns.Add(CT_DtlLedger_Dtl_StockPriceConsTax, typeof(Int64));
            dt.Columns[CT_DtlLedger_Dtl_StockPriceConsTax].Caption = "仕入金額消費税額";
            //以下支払伝票
            // 支払金額
            dt.Columns.Add(CT_DtlLedger_Payment, typeof(Int64));
            dt.Columns[CT_DtlLedger_Payment].Caption = "支払金額";
            // 有効期限
            dt.Columns.Add(CT_DtlLedger_ValidityTerm, typeof(Int32));
            dt.Columns[CT_DtlLedger_ValidityTerm].Caption = "有効期限";
            //以下印刷用
            // 支払残or買掛残string
            dt.Columns.Add(CT_DtlLedger_SlitTitle, typeof(String));
            dt.Columns[CT_DtlLedger_SlitTitle].Caption = "支払残or買掛残string";
            // 残高
            dt.Columns.Add(CT_DtlLedger_Balance, typeof(Int64));
            dt.Columns[CT_DtlLedger_Balance].Caption = "残高";
            #endregion

            ds.Tables.Add(dt);

            //ソート
            //得意先コード→計上年月日(締基準)→前残繰越区分→計上日付?→レコード区分→伝票番号
            string sort = CT_DtlLedger_PayeeCode + "," + CT_DtlLedger_StockAddUpADate + "," + CT_DtlLedger_SupplierSlipNo;

            _stockLedgerDtlDataTable = dt;
            _stockLedgerDtlDataView = new DataView(_stockLedgerDtlDataTable, string.Empty, sort, DataViewRowState.CurrentRows);
        }

        #endregion

        #region 仕入先支払金額データ取得処理(リモート接続)
        /// <summary>
		/// 仕入先支払金額データ取得処理
		/// </summary>
		/// <param name="printDiv">印刷区分</param>
		/// <param name="param">パラメータ</param>
        /// <param name="outMoneyDiv">出力金額区分</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note        : 仕入先支払金額データを取得します</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
        /// <br>Update Note : 2014/02/26 田建委</br>
        /// <br>            : Redmine#42188 出力金額区分追加</br>
        /// <br>UpdateNote  : 2015/12/10 田思春</br>
        /// <br>管理番号    : 11170204-00</br>
        /// <br>            : Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応</br>
        /// </remarks>
        //private static int GetSupplierPayInfo(string enterpriseCode, int customerCode, int startCustomerCode, int endCustomerCode, int startYearMonth, int endYearMonth, string sectionCode, ArrayList sectionCodeList, int mode)
        //private static int GetSupplierPayInfo(int printDiv, Broadleaf.Application.Remoting.ParamData.SuplierPayInfGetParameter param)// DEL 2014/02/27 鄧潘ハン
        private static int GetSupplierPayInfo(int printDiv, Broadleaf.Application.Remoting.ParamData.SuplierPayInfGetParameter param, int outMoneyDiv)// ADD 2014/02/27 鄧潘ハン
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList supplierPayList       = null;     // 仕入先支払金額マスタ用List
            //Hashtable accBlanceTable        = null;     // 残高(仕入)データ用HashTable
            Hashtable supplierSlpInf = null;     // 買掛(仕入)データ用HashTable
            Hashtable supplierDtlInf = null;     // 買掛(仕入)明細データ用HashTable
            Hashtable paymentSlpTable = null;     // 支払データ用HashTable

            ArrayList supplierSlpInfAry = null;     // 買掛(仕入)データ用ArrayList
            ArrayList supplierDtlInfAry = null;     // 買掛(仕入)明細データ用ArrayList 
            ArrayList paymentSlpTableAry = null;     // 支払データ用ArrayList
            object supplierPayWorkList = null;
            object supplierSlpInfWork = null;
            object supplierDtlInfWork = null;
            object supplierPaymentInfWork = null;

            SuplierPayInfGetWork suplierPayInfGetWork = new SuplierPayInfGetWork();  // 仕入先支払金額マスタワーク

            try
            {
                // 仕入先支払情報取得アクセスクラス
                if (_getSuplierPayAcs == null)
                {
                    _getSuplierPayAcs = new GetSuplierPayAcs();
                    _getSuplierPayAcs.ThroughException = true;
                }

                //  元帳検索
                switch (printDiv)
                {
                case 1: // 明細モード
                    {
                        status = _suplierPayInfGetDB.SearchDtl(out supplierPayWorkList, out supplierDtlInfWork, out supplierPaymentInfWork, param);
                        supplierPayList = supplierPayWorkList as ArrayList;
                        supplierSlpInfAry = supplierSlpInfWork as ArrayList;
                        supplierDtlInfAry = supplierDtlInfWork as ArrayList;
                        paymentSlpTableAry = supplierPaymentInfWork as ArrayList;
                        //gatherUpSupPay(ref supplierPayList); // ダブりに対応する排除処理
                        ArrayInfoToHashTable(out supplierSlpInf, out supplierDtlInf, out paymentSlpTable,
                            //supplierPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry);// DEL 2014/02/26 田建委 Redmine#42188
                        // ---ADD 2014/02/26 田建委 Redmine#42188--------------------->>>>>
                            //ref supplierPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv);// DEL 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応
                            ref supplierPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv, param.SumSuppEnable);// ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応
                        if (supplierPayList == null || supplierPayList.Count == 0) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        // ---ADD 2014/02/26 田建委 Redmine#42188---------------------<<<<<
                        break;
                    }
                case 2: // 伝票モード
                    {
                        status = _suplierPayInfGetDB.SearchSlip(out supplierPayWorkList, out supplierSlpInfWork, out supplierPaymentInfWork, param);
                        supplierPayList = supplierPayWorkList as ArrayList;
                        supplierSlpInfAry = supplierSlpInfWork as ArrayList;
                        supplierDtlInfAry = supplierDtlInfWork as ArrayList;
                        paymentSlpTableAry = supplierPaymentInfWork as ArrayList;
                        //gatherUpSupPay(ref supplierPayList); // ダブりに対応する排除処理
                        ArrayInfoToHashTable(out supplierSlpInf, out supplierDtlInf, out paymentSlpTable,
                            //supplierPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry);// DEL 2014/02/26 田建委 Redmine#42188
                        // ---ADD 2014/02/26 田建委 Redmine#42188--------------------->>>>>    
                            //ref supplierPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv);// DEL 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応
                            ref supplierPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv, param.SumSuppEnable);// ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応
                        if (supplierPayList == null || supplierPayList.Count == 0) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        // ---ADD 2014/02/26 田建委 Redmine#42188---------------------<<<<<
                        break;
                    }
                default:
                    {
                        throw new CsLedgerException("印刷区分が不正です。", status);
                    }
                } 

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //仕入先支払情報データリスト→StaticMemory設定
                    SetStaticFromSupplierPayList(supplierPayList);

                    //仕入先別計上年月日範囲取得
                    SetCustomerAddUpDateSpanAndAddUpDate(param.SupplierCd);

                    // 支払買掛・支払伝票データテーブル設定
                    AccPayAndPaymentSlpToDataTable(param.SupplierCd, supplierSlpInf, supplierDtlInf, paymentSlpTable);

                    // 照会用かと思われるので消去。
                    //// 支払伝票ワークを内部保持用に設定
                    ////foreach (DictionaryEntry de in paymentSlpTable)
                    //foreach (ArrayList paymentSlpList in paymentSlpTable)
                    //{
                    //    //ArrayList paymentSlpList = (ArrayList)de.Value;

                    //    if (paymentSlpList != null)
                    //    {
                    //        foreach (LedgerPaymentSlpWork wk in paymentSlpList)
                    //        {
                    //            if (wk != null)
                    //            {
                    //                string key = string.Empty;
                    //                //key = wk.AddUpSecCode + "_" + wk.PayeeCode.ToString() + "_" + wk.CustomerCode.ToString() + "_" + String.Format("{0:D9}", wk.PaymentSlipNo);
                    //                key = wk.AddUpSecCode + "_" + wk.PayeeCode.ToString() + "_" + wk.SupplierCd.ToString() + "_" + String.Format("{0:D9}", wk.PaymentSlipNo);
                    //                if (!_paymentSlpTable.ContainsKey(key))
                    //                {
                    //                    _paymentSlpTable.Add(key, wk);
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                }
                else
                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                        (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        //
                    }
                    else
                    {
                        throw new CsLedgerException("支払情報の取得に失敗しました。", status);
                    }
            }
            catch (Exception ex)
            {
                throw new CsLedgerException(ex.Message, status);
            }
            finally
            {
                if (supplierPayList != null) supplierPayList = null;
                if (supplierSlpInf != null) supplierSlpInf = null;
                if (supplierDtlInf != null) supplierDtlInf = null;
                if (paymentSlpTable != null) paymentSlpTable = null;
            }

			return status;
        }
    
        #endregion

        #region ◎ 得意先別計上年月日範囲取得処理
        /// <summary>
		/// 得意先別計上年月日範囲取得処理
		/// </summary>
		/// <param name="cutomerCode">得意先コード</param>
		/// <remarks>
		/// <br>Note       : メソッド内容を説明します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public static void SetCustomerAddUpDateSpanAndAddUpDate(int cutomerCode)
		{
			//同一得意先、同一計上拠点のレコードを絞り込む(拠点ごと専用の得意先を設定してるので拠点は絞り込まない)
            string filter	= String.Format("{0}={1}", COL_Spl_SupplierCd, cutomerCode);
            string sort		= COL_Spl_PayeeCode + "," + COL_Spl_AddUpSecCode + "," + COL_Spl_AddUpDate;

            DataView dv = new DataView(_suplierPayDataTable, filter, sort, DataViewRowState.CurrentRows);

            if (dv.Count > 0)
            {
                //仕入先元帳用鑑データクラス
                StockLedgerPay stockLedgerPay;

                // 開始取得
                stockLedgerPay = GetStockLedgerPayFromDataRow(dv[0].Row);
                _startTtlAddUpDateSpan = TDateTime.LongDateToDateTime(stockLedgerPay.StartDateSpan);
                _startAddUpDate = stockLedgerPay.AddUpDate;

                // 終了取得
                stockLedgerPay = GetStockLedgerPayFromDataRow(dv[dv.Count-1].Row);

                if ( ( stockLedgerPay.CloseFlag == (int)CloseFlagState.NotClose ) &&  ( dv.Count > 1 ))
				{
					stockLedgerPay = GetStockLedgerPayFromDataRow(dv[dv.Count - 2].Row);
				}

                _endTtlAddUpDateSpan = TDateTime.LongDateToDateTime(stockLedgerPay.EndDateSpan);
                _endAddUpDate = stockLedgerPay.AddUpDate;
            }
        }

        #endregion

        #region ◎ 元帳明細テーブル行作成処理
        /// <summary>
		/// 元帳明細テーブル行作成処理
		/// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <param name="supplierSlpInf">仕入伝票情報</param>
        /// <param name="supplierDtlInf">仕入明細情報</param>
        /// <param name="paymentSlpTable">支払伝票テーブル</param>
		/// <remarks>
		/// <br>Note       : 支払買掛・支払伝票リストより元帳明細テーブルに明細を設定します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
        private static void AccPayAndPaymentSlpToDataTable(int supplierCode, Hashtable supplierSlpInf, Hashtable supplierDtlInf, Hashtable paymentSlpTable)
        {
            if (_suplierPayDataView.Count != 0)
            {
                // 金額データ別(鑑別)に前回残高行・繰越残高行を作成する 
                for (int index = 0; index < _suplierPayDataView.Count; index++)
                {
                    // DataRow → 支払金額クラス
                    StockLedgerPay stockLedgerPay = GetStockLedgerPayFromDataRow(_suplierPayDataView[index].Row);

                    //各月ごとの鑑情報をもとに明細行を作成
                    //仕入先情報テーブルより情報を取得
                    StockLedgerSupplier csLedgerSupplier = (StockLedgerSupplier)_stockLedgerSupplierInfoTable[stockLedgerPay.PayeeCode.ToString() + "_" + TDateTime.DateTimeToLongDate(stockLedgerPay.AddUpDate).ToString() + "_" + stockLedgerPay.AddUpSecCode];

                    // KEY情報の設定
                    int keyDate = TDateTime.DateTimeToLongDate(stockLedgerPay.AddUpDate);
                    string addUpSecCd = stockLedgerPay.AddUpSecCode;

                    #region 残高ってのが照会用だと感じさせる。一時消去
                    //// 前回残高が有る場合前回残高行作成
                    //if (stockLedgerPay.LastTimePayment != 0)
                    //{
                    //    //通常Searchで未締データの場合に初期状態で前回残高行は作成しない
                    //    if (stockLedgerPay.CloseFlag == (int)CloseFlagState.Close)
                    //    {
                    //        // 前回残高行作成
                    //        _stockLedgerSlipDataTable.Rows.Add(
                    //            SetDataRowBalance((int)BalanceCode.Balance, stockLedgerPay, addUpSecCd, keyDate));
                    //    }
                    //}
                    #endregion
                }
                // 支払買掛・支払伝票明細行を作成する
                SettingDataSlpLedgerTable(supplierSlpInf, supplierDtlInf, paymentSlpTable);
            }
        }

        #endregion

        #region 元帳明細データ設定処理
        /// <summary>
		/// 元帳明細データ設定処理
		/// </summary>
        /// <param name="supplierSlpInf">仕入伝票情報</param>
        /// <param name="supplierDtlInf">仕入明細情報</param>
        /// <param name="paymentSlpTable">支払伝票テーブル</param>
        /// <remarks>
		/// <br>Note       : 支払金額レコードの計上範囲の売上・支払伝票データを元帳明細テーブルに設定します。</br>
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.26</br>
		/// </remarks>
        private static void SettingDataSlpLedgerTable(Hashtable supplierSlpInf, Hashtable supplierDtlInf, Hashtable paymentSlpTable)
        {
            if (supplierSlpInf != null)
            {
                // 仕入伝票行作成(HashTable Key: 計上年月日(int),Value: 該当計上年月日の売上レコードリスト)
                foreach (DictionaryEntry de in supplierSlpInf)
                {
                    int addUpDate = (int)de.Key;

                    ArrayList accPayList = (ArrayList)de.Value;

                    foreach (LedgerStockSlipWork accPayWork in accPayList)
                    {
                        // 支払モードで消費税調整(買掛用)または残高調整(買掛用)の場合は次データ
                        if ((_imode == 0) && ((accPayWork.StockGoodsCd == 4) || (accPayWork.StockGoodsCd == 5))) continue;

                        //明細テーブルにRowをAdd
                        _stockLedgerSlipDataTable.Rows.Add(SetDataRowFromAccPay(addUpDate, accPayWork));
                    }
                }
            }

            if (supplierDtlInf != null)
            {
                // 仕入明細伝票明細行作成(HashTable Key: 計上年月日(int),Value: 該当計上年月日の支払伝票レコードリスト)
                foreach (DictionaryEntry de in supplierDtlInf)
                {
                    int addUpDate = (int)de.Key;
                    ArrayList accPayDtlList = (ArrayList)de.Value;

                    foreach (LedgerStockDetailWork accPayDtlWork in accPayDtlList)
                    {
                        // 支払モードで消費税調整(買掛用)または残高調整(買掛用)の場合は次データ
                        if ((_imode == 0) && ((accPayDtlWork.StockGoodsCd == 4) || (accPayDtlWork.StockGoodsCd == 5))) continue;

                        _stockLedgerDtlDataTable.Rows.Add(SetDataRowFromAccPayDtl(addUpDate, accPayDtlWork));
                    }
                }

            }

            if (paymentSlpTable != null)
            {
                // 支払伝票行作成(HashTable Key: 計上年月日(int),Value: 該当計上年月日の支払伝票レコードリスト)
                foreach (DictionaryEntry de in paymentSlpTable)
                {
                    int addUpDate = (int)de.Key;
                    ArrayList paymentSlpList = (ArrayList)de.Value;

                    // --- DEL 2012/11/01 ---------->>>>>
                    //foreach (LedgerPaymentSlpWork paymentSlpWork in paymentSlpList)
                    //{
                    //    _stockLedgerSlipDataTable.Rows.Add(SetDataRowFromPaymentSlp(addUpDate, paymentSlpWork));
                    //    _stockLedgerDtlDataTable.Rows.Add(SetDataRowFromPaymentDtl(addUpDate, paymentSlpWork));
                    //}
                    // --- DEL 2012/11/01 ----------<<<<<

                    // --- ADD 2012/11/01 ---------->>>>>
                    for (int index = 0; index < paymentSlpList.Count; index++)
                    {
                        // 現在処理中のデータ
                        LedgerPaymentSlpWork paymentSlpWork = (LedgerPaymentSlpWork)paymentSlpList[index];
                        // 次行のデータ
                        LedgerPaymentSlpWork nextPaymentSlpWork = null;
                        
                        if (index + 1 < paymentSlpList.Count)
                        {
                            // 次行のデータセット
                            nextPaymentSlpWork = (LedgerPaymentSlpWork)paymentSlpList[index + 1];
                        }

                        if (paymentSlpWork.MoneyKindDiv != 0)
                        {
                            // 金種が登録されていれば通常のデータ行を生成
                            _stockLedgerSlipDataTable.Rows.Add(SetDataRowFromPaymentSlp(addUpDate, paymentSlpWork));
                            _stockLedgerDtlDataTable.Rows.Add(SetDataRowFromPaymentDtl(addUpDate, paymentSlpWork));
                        }

                        // 最終行または現在処理中行と次行の伝票Noが異なる場合
                        if (nextPaymentSlpWork == null || paymentSlpWork.PaymentSlipNo != nextPaymentSlpWork.PaymentSlipNo)
                        {
                            // 現在処理中行手数料行と値引行を追加する
                            if (paymentSlpWork.FeePayment != 0)
                            {
                                _stockLedgerSlipDataTable.Rows.Add(SetDataFeeRowFromPaymentSlp(addUpDate, paymentSlpWork));
                                _stockLedgerDtlDataTable.Rows.Add(SetDataFeeRowFromPaymentDtl(addUpDate, paymentSlpWork));
                            }
                            if (paymentSlpWork.DiscountPayment != 0)
                            {
                                _stockLedgerSlipDataTable.Rows.Add(SetDataDiscountRowFromPaymentSlp(addUpDate, paymentSlpWork));
                                _stockLedgerDtlDataTable.Rows.Add(SetDataDiscountRowFromPaymentDtl(addUpDate, paymentSlpWork));
                            }
                        }
                    }
                    // --- ADD 2012/11/01 ----------<<<<<
                }
            }
        }
        #endregion

        #region 仕入先支払金額マスタデータリスト→StaticMemory設定処理

        /// <summary>
		/// 仕入先支払金額マスタデータリスト→StaticMemory設定処理
		/// </summary>
		/// <param name="supplierPayList">仕入先支払金額マスタデータリスト</param>
		/// <remarks>
		/// <br>Note        : 仕入先支払金額マスタの仕入先情報をStaticMemoryへ設定します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static void SetStaticFromSupplierPayList(ArrayList supplierPayList)
		{
			foreach (SuplierPayInfGetWork suplierPayInfGetWork in supplierPayList)
			{
                ////キーを(支払先 + 計上日 + 拠点)に変更
                //string key = suplierPayInfGetWork.PayeeCode.ToString() + "_" + TDateTime.DateTimeToLongDate(suplierPayInfGetWork.AddUpDate).ToString() + "_" + suplierPayInfGetWork.AddUpSecCode;
                //// 仕入先情報設定
                //if (!_stockLedgerSupplierInfoTable.Contains(key))
                //{

                //    //仕入先支払金額マスタデータより仕入先 + 計上日 + 拠点毎のデータを作成します。
                //    _stockLedgerSupplierInfoTable.Add(key, CopyToStockLedgerSupplier(suplierPayInfGetWork));
                //}

				//仕入先金額(鑑)テーブル作成
                DataRow row = GetDataRowFromSuplierPayInfGetWork(suplierPayInfGetWork);
				_suplierPayDataTable.Rows.Add(row);
			}
        }

        #endregion       
        
        #region 仕入先支払金額情報データ行設定処理(支払)
		/// <summary>
		/// 仕入先支払金額情報データ行設定処理(支払)
		/// </summary>
        /// <param name="suplierPayInfGetWork">仕入先支払金額情報パラメータ</param>
		/// <returns>設定されたデータ行</returns>
		/// <remarks>
		/// <br>Note        : 仕入先支払金額情報をデータ行へ設定します。</br>
		/// <br>Programmer  : 18012 Y.Sasaki</br>
		/// <br>Date        : 2005.07.26</br>
		/// </remarks>
		private static DataRow GetDataRowFromSuplierPayInfGetWork(SuplierPayInfGetWork suplierPayInfGetWork)
		{
			DataRow newRow = _suplierPayDataTable.NewRow();

			GetDataRowFromSuplierPayInfGetWork( ref newRow, suplierPayInfGetWork );

			return newRow;
		}
		#endregion

        #region 仕入先支払金額パラメータ→仕入先金額情報データ行設定処理
        /// <summary>
		/// 仕入先支払金額パラメータ→仕入先金額情報データ行設定処理
		/// </summary>
        /// <param name="dr">データRow</param>
		/// <param name="work"> 仕入先支払金額パラメータ</param>
		/// <returns>データ行</returns>
		/// <remarks>
		/// <br>Note        :  仕入先支払金額パラメータを仕入先金額データ行へ設定します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
        /// <br>UpdateNote  :  消費税転嫁方式が反映されていない問題対応。</br>
        /// <br>Programmer  : FSI斎藤 和宏</br>
        /// <br>Date        : 2012/11/01</br>
        /// 
		/// </remarks>
        //private static void GetDataRowFromSuplierPayInfGetWork(ref DataRow dr, SuplierPayInfGetWork work)
		private static void GetDataRowFromSuplierPayInfGetWork(ref DataRow dr, SuplierPayInfGetWork work)
        {
            //dr[COL_Spl_EnterpriseCode] = work.EnterpriseCode; // 企業コード
            dr[COL_Spl_AddUpSecCode] = work.AddUpSecCode; // 計上拠点コード
            dr[COL_Spl_AddUpSecName] = GetSectionName(work.AddUpSecCode); // 計上拠点コード
            dr[COL_Spl_PayeeCode] = work.PayeeCode; // 支払先コード
            //dr[COL_Spl_PayeeName] = work.PayeeName; // 支払先名称
            //dr[COL_Spl_PayeeName2] = work.PayeeName2; // 支払先名称2
            dr[COL_Spl_PayeeSnm] = work.PayeeSnm; // 支払先略称
            //dr[COL_Spl_ResultsSectCd] = work.ResultsSectCd; // 実績拠点コード
            //dr[COL_Spl_SupplierCd] = work.SupplierCd; // 仕入先コード
            //dr[COL_Spl_SupplierNm1] = work.SupplierNm1; // 仕入先名1
            //dr[COL_Spl_SupplierNm2] = work.SupplierNm2; // 仕入先名2
            //dr[COL_Spl_SupplierSnm] = work.SupplierSnm; // 仕入先略称
            dr[COL_Spl_AddUpDate] = TDateTime.DateTimeToLongDate(work.AddUpDate); // 計上年月日
            dr[COL_Spl_AddUpYearMonth] = TDateTime.DateTimeToLongDate(work.AddUpYearMonth); // 計上年月
            dr[COL_Spl_LastTimePayment] = work.LastTimePayment; // 前回支払金額
            dr[COL_Spl_StockTtl2TmBfBlPay] = work.StockTtl2TmBfBlPay; // 仕入2回前残高（支払計）
            dr[COL_Spl_StockTtl3TmBfBlPay] = work.StockTtl3TmBfBlPay; // 仕入3回前残高（支払計）
            dr[COL_Spl_ThisTimePayNrml] = work.ThisTimePayNrml; // 今回支払金額（通常支払）
            dr[COL_Spl_ThisTimeTtlBlcPay] = work.ThisTimeTtlBlcPay; // 今回繰越残高（支払計）
            dr[COL_Spl_OfsThisTimeStock] = work.OfsThisTimeStock; // 相殺後今回仕入金額
            dr[COL_Spl_OfsThisStockTax] = work.OfsThisStockTax; // 相殺後今回仕入消費税
            dr[COL_Spl_ThisStckPricRgds] = work.ThisStckPricRgds; // 今回返品金額
            dr[COL_Spl_ThisStcPrcTaxRgds] = work.ThisStcPrcTaxRgds; // 今回返品消費税
            dr[COL_Spl_ThisStckPricDis] = work.ThisStckPricDis; // 今回値引金額
            dr[COL_Spl_ThisStcPrcTaxDis] = work.ThisStcPrcTaxDis; // 今回値引消費税
            // 2009.03.02 30413 犬飼 返品値引の符号を反転させる >>>>>>START
            //dr[COL_Spl_ThisStckPricRgdsDis] = work.ThisStckPricRgds + work.ThisStckPricDis; // 今回返品金額
            dr[COL_Spl_ThisStckPricRgdsDis] = -(work.ThisStckPricRgds + work.ThisStckPricDis); // 今回返品値引金額
            // 2009.03.02 30413 犬飼 返品、値引の符号を反転させる <<<<<<END
            dr[COL_Spl_OfsThisTimeStockTax] = work.ThisTimePayNrml + work.ThisStckPricRgds + work.ThisStckPricDis; // 税込仕入額
            //dr[COL_Spl_TaxAdjust] = work.TaxAdjust; // 消費税調整額
            //dr[COL_Spl_BalanceAdjust] = work.BalanceAdjust; // 残高調整額
            dr[COL_Spl_StockTotalPayBalance] = work.StockTotalPayBalance; // 仕入合計残高（支払計）
            dr[COL_Spl_CAddUpUpdExecDate] = TDateTime.DateTimeToLongDate(work.CAddUpUpdExecDate); // 締次更新実行年月日
            dr[COL_Spl_StartCAddUpUpdDate] = TDateTime.DateTimeToLongDate(work.StartCAddUpUpdDate); // 締次更新開始年月日
            //dr[COL_Spl_LastCAddUpUpdDate] = work.LastCAddUpUpdDate; // 前回締次更新年月日
            dr[COL_Spl_StockSlipCount] = work.StockSlipCount; // 仕入伝票枚数
            //dr[COL_Spl_CloseFlg] = work.CloseFlg; // 締済みフラグ
            if (_imode == (int)Mode.Shr) { dr[COL_Spl_SlitTitle] = "支払残"; }
            else if (_imode == (int)Mode.Kai) { dr[COL_Spl_SlitTitle] = "買掛残"; }// 印刷用 支払残・買掛残

            // 2009.02.24 30413 犬飼 今回仕入金額の追加 >>>>>>START
            dr[COL_Spl_ThisTimeStockPrice] = work.ThisTimeStockPrice;   // 今回仕入金額
            // 2009.02.24 30413 犬飼 今回仕入金額の追加 <<<<<<END

            // --- ADD 2012/11/01 ---------->>>>>
            dr[COL_Spl_SuppCTaxLayCd] = work.SuppCTaxLayCd;   // 消費税転嫁方式
            // --- ADD 2012/11/01 ----------<<<<<

        }

        #endregion    
            
        // >>> danger
        #region ◎仕入データ→元帳明細情報データ行設定処理
        /// <summary>
		/// 仕入データ→元帳明細情報データ行設定処理
		/// </summary>
		/// <param name="addUpDate">計上年月日</param>
        /// <param name="stockSlipWork">仕入データクラス</param>
		/// <returns>データ行</returns>
		/// <remarks>
		/// <br>Note        :仕入データを元帳明細情報データ行へ設定します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static DataRow SetDataRowFromAccPay(int addUpDate, LedgerStockSlipWork stockSlipWork/*, ArrayList paymentSlpTable*/)
		{
			DataRow dr = _stockLedgerSlipDataTable.NewRow();

            //テーブルのキーを変更
            //StockLedgerSupplier csLedgerSupplier = (StockLedgerSupplier)_stockLedgerSupplierInfoTable[stockSlipWork.PayeeCode.ToString() + "_" + addUpDate.ToString()+ "_" + stockSlipWork.SectionCode];

            #region [旧D→Table格納処理]
            ////表示項目
            //dr[CT_SplLedger_AddUpADateDisp	] = TDateTime.DateTimeToString("yyyy.mm.dd", stockSlipWork.StockAddUpADate);	// 計上日付(表示用)
            //dr[CT_SplLedger_SlipNo] = GetSupplierSlipNo(stockSlipWork);					                        // 仕入伝票番号・支払伝票番号
            //dr[CT_SplLedger_SlipKindNm] = GetSlipKindNm(stockSlipWork.SupplierSlipCd);		                                // 仕入伝票区分名称

            //string slipDetail = "";
            
            //switch (stockSlipWork.StockGoodsCd)
            //{ 
            //    case 0:
            //        slipDetail = "商品";
            //        break;
            //    case 1:
            //        slipDetail = "商 品 外";
            //        break;
            //    case 2:
            //        slipDetail = "消費税調整";
            //        break;
            //    case 3:
            //        slipDetail = "残高調整";
            //        break;
            //    case 4:
            //        slipDetail = "買掛用消費税調整";
            //        break;
            //    case 5:
            //        slipDetail = "買掛用残高調整";
            //        break;
            //}
            //dr[CT_SplLedger_Detail] = slipDetail;

            //if ((stockSlipWork.StockGoodsCd == 3) || (stockSlipWork.StockGoodsCd == 5))
            //{
            //    dr[CT_SplLedger_StockPrice] = stockSlipWork.StockTotalPrice;
            //    dr[CT_SplLedger_StockPrice1] = stockSlipWork.StockTotalPrice;
            //}
            //else
            //{
            //    dr[CT_SplLedger_StockPrice] = stockSlipWork.StockSubttlPrice;						                        // 仕入金額(仕入金額小計(税抜)を使用)
            //    dr[CT_SplLedger_StockPrice1] = 0;
            //}

            //dr[CT_SplLedger_ConsTax] = stockSlipWork.StockPriceConsTax;                                                     // 消費税額

            //if ((stockSlipWork.StockGoodsCd == 2) || (stockSlipWork.StockGoodsCd == 4))
            //{
            //    dr[CT_SplLedger_ConsTax1] = stockSlipWork.StockPriceConsTax;                                                // 消費税額
            //}
            //else
            //{
            //    dr[CT_SplLedger_ConsTax1] = 0;
            //}

            //dr[CT_SplLedger_StockTotalPrice	] = stockSlipWork.StockTotalPrice;		                                        // 仕入金額
            
            //dr[CT_SplLedger_Payment			] = DBNull.Value;										                        // 支払金額
            //dr[CT_SplLedger_Balance			] = 0;													                        // 残高(残高計算は仕入・支払データをセットした後で計算します)
            
            //if(stockSlipWork.SupplierSlipCd == (int)SupplierLedgerSlipCdDiv.Back)
            //{
            //    //返品伝票時は返品理由を代入(文字数が長いので途切れるが。)
            //    dr[CT_SplLedger_Note        ] = stockSlipWork.SupplierSlipNote1;    //返品理由が入るらしいがそんな項目はクラスに無い。
            //}
            //else if(stockSlipWork.SupplierSlipCd == (int)SupplierLedgerSlipCdDiv.Stock)
            //{
            //    //仕入伝票時は伝票備考１を代入(文字数が長いので切れるがどうするか)
            //    dr[CT_SplLedger_Note            ] = stockSlipWork.SupplierSlipNote1;
            //}

            //dr[CT_SplLedger_PayeeCode	] = stockSlipWork.PayeeCode;						        // 支払先コード
            //dr[CT_SplLedger_CustomerCode	] = stockSlipWork.SupplierCd;						    // 得意先コード
            //dr[CT_SplLedger_AddUpDate		] = addUpDate;											// 計上年月日
            //dr[CT_SplLedger_RecordCode		] = (int)RecordCode.AccPay;								// レコード区分(0:支払買掛,1:支払伝票)			
            //dr[CT_SplLedger_BalanceCode		] = (int)BalanceCode.Others;							// 前残繰越区分(0:前残,1:その他(支払買掛 or 支払伝票),2:消費税(請求単位の場合のみ),3:繰越)
            //dr[CT_SplLedger_DebitNoteDiv	] = stockSlipWork.DebitNoteDiv;                         // 赤伝区分(0:黒,1:赤,2相殺済み黒)           
            ////赤伝区分が黒伝かつ赤伝連結仕入伝票番号が０で無い
            //if (stockSlipWork.DebitNoteDiv == 0 && stockSlipWork.DebitNLnkSuppSlipNo != 0)
            //{
            //    //元黒
            //    dr[CT_SplLedger_DebitNoteDiv] = 2;
            //}		
            //dr[CT_SplLedger_AddUpADate		] = stockSlipWork.StockAddUpADate;						// 計上日付	
            //dr[CT_SplLedger_AddUpADateInt	] = TDateTime.DateTimeToLongDate(stockSlipWork.StockAddUpADate);
            //dr[CT_SplLedger_SupplierSlipCd	] = stockSlipWork.SupplierSlipCd;						// 仕入伝票区分(10:仕入,20:返品)           
            //dr[CT_SplLedger_AddUpSecCode	] = stockSlipWork.StockAddUpSectionCd;					// 計上拠点コード
            //dr[CT_SplLedger_AddUpSecName	] = GetSectionName(stockSlipWork.StockAddUpSectionCd);	// 計上拠点名称
            //dr[CT_SplLedger_PartySaleSlipNum] = stockSlipWork.PartySaleSlipNum;		                // 相手先伝票番号
            //dr[CT_SplLedger_SupplierFormal	] = stockSlipWork.SupplierFormal;	                    // 仕入形式
            //dr[CT_SplLedger_SupplierSlipNote1] = stockSlipWork.SupplierSlipNote1;		            // 仕入伝票備考1
            //dr[CT_SplLedger_SupplierSlipNote2] = stockSlipWork.SupplierSlipNote2;		            // 仕入伝票備考2
            //dr[CT_SplLedger_DraftPayTimeLimit] = "";		                                        // 手形支払期日
            //dr[CT_SplLedger_PrtDiv] = 1;                                                            // 印字区分 
            #endregion

            dr[CT_SplLedger_EnterpriseCode] = stockSlipWork.EnterpriseCode; // 企業コード
            dr[CT_SplLedger_AddUpDate] = addUpDate; // 計上日付(締基準)
            dr[CT_SplLedger_SupplierFormal] = stockSlipWork.SupplierFormal; // 仕入形式
            dr[CT_SplLedger_SupplierSlipNo] = stockSlipWork.SupplierSlipNo; // 仕入伝票番号
            dr[CT_SplLedger_SlipKindNm] = "仕入"; // 仕入伝票種別
            dr[CT_SplLedger_SectionCode] = stockSlipWork.SectionCode; // 拠点コード
            dr[CT_SplLedger_DebitNoteDiv] = stockSlipWork.DebitNoteDiv; // 赤伝区分
            dr[CT_SplLedger_DebitNLnkSuppSlipNo] = stockSlipWork.DebitNLnkSuppSlipNo; // 赤黒連結仕入伝票番号
            dr[CT_SplLedger_SupplierSlipCd] = stockSlipWork.SupplierSlipCd; // 仕入伝票区分
            dr[CT_SplLedger_StockGoodsCd] = stockSlipWork.StockGoodsCd; // 仕入商品区分
            dr[CT_SplLedger_StockSectionCd] = stockSlipWork.StockSectionCd; // 仕入拠点コード
            dr[CT_SplLedger_StockAddUpSectionCd] = stockSlipWork.StockAddUpSectionCd; // 仕入計上拠点コード
            dr[CT_SplLedger_InputDay] = TDateTime.DateTimeToLongDate(stockSlipWork.InputDay); // 入力日
            dr[CT_SplLedger_ArrivalGoodsDay] = TDateTime.DateTimeToLongDate(stockSlipWork.ArrivalGoodsDay); // 入荷日
            dr[CT_SplLedger_StockDate] = TDateTime.DateTimeToLongDate(stockSlipWork.StockDate); // 仕入日
            dr[CT_SplLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate(stockSlipWork.StockAddUpADate); // 仕入計上日付
            dr[CT_SplLedger_StockRecordCd] = (int)RecordCode.AccPay; // 仕入レコード区分
            dr[CT_SplLedger_StockInputCode] = stockSlipWork.StockInputCode; // 仕入入力者コード
            dr[CT_SplLedger_StockInputName] = stockSlipWork.StockInputName; // 仕入入力者名称
            dr[CT_SplLedger_StockAgentCode] = stockSlipWork.StockAgentCode; // 仕入担当者コード
            dr[CT_SplLedger_StockAgentName] = stockSlipWork.StockAgentName; // 仕入担当者名称
            dr[CT_SplLedger_PayeeCode] = stockSlipWork.PayeeCode; // 支払先コード
            dr[CT_SplLedger_PayeeSnm] = stockSlipWork.PayeeSnm; // 支払先略称
            dr[CT_SplLedger_SupplierCd] = stockSlipWork.SupplierCd; // 仕入先コード
            dr[CT_SplLedger_SupplierNm1] = stockSlipWork.SupplierNm1; // 仕入先名1
            dr[CT_SplLedger_SupplierNm2] = stockSlipWork.SupplierNm2; // 仕入先名2
            dr[CT_SplLedger_SupplierSnm] = stockSlipWork.SupplierSnm; // 仕入先略称
            dr[CT_SplLedger_StockTotalPrice] = stockSlipWork.StockTotalPrice; // 仕入金額合計
            dr[CT_SplLedger_StockSubttlPrice] = stockSlipWork.StockSubttlPrice; // 仕入金額小計
            dr[CT_SplLedger_StockPriceConsTax] = stockSlipWork.StockPriceConsTax; // 仕入金額消費税額
            dr[CT_SplLedger_PartySaleSlipNum] = stockSlipWork.PartySaleSlipNum; // 相手先伝票番号
            dr[CT_SplLedger_SupplierSlipNote1] = stockSlipWork.SupplierSlipNote1; // 仕入伝票備考1
            dr[CT_SplLedger_SupplierSlipNote2] = stockSlipWork.SupplierSlipNote2; // 仕入伝票備考2
            dr[CT_SplLedger_UoeRemark1] = stockSlipWork.UoeRemark1; // ＵＯＥリマーク１
            dr[CT_SplLedger_UoeRemark2] = stockSlipWork.UoeRemark2; // ＵＯＥリマーク２
            dr[CT_SplLedger_StockRecordCd] = RecordCode.AccPay;

            return dr;
        }
        #endregion

        #region 支払伝票情報→元帳伝票情報データ行設定処理
        /// <summary>
		/// 支払伝票情報→元帳伝票情報データ行設定処理
		/// </summary>
		/// <param name="addUpDate">計上年月日(締単位)</param>
        /// <param name="paymentSlpWork">支払伝票データクラス</param>
        /// <returns>設定されたデータ行</returns>
		/// <remarks>
		/// <br>Note        : 支払伝票情報から元帳明細情報のデータ行へ設定します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
        /// <br>UpdateNote	: 支払データに値引額・手数料額が反映されていない問題対応。</br>
        /// <br>Programer   : FSI斎藤 和宏</br>
        /// <br>Date        : 2012/11/01</br>
		/// </remarks>
		private static DataRow SetDataRowFromPaymentSlp(int addUpDate, LedgerPaymentSlpWork paymentSlpWork)
		{
			DataRow dr = _stockLedgerSlipDataTable.NewRow();
            ////表示項目
            dr[CT_SplLedger_AddUpDate] = addUpDate;
            dr[CT_SplLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.AddUpADate);	// 計上日付(表示用)
            dr[CT_SplLedger_SupplierSlipNo] = String.Format("{0:D9}", paymentSlpWork.PaymentSlipNo);	                // 仕入伝票番号・支払伝票番号
            dr[CT_SplLedger_SlipKindNm] = "支払";                                                                       // 伝票種別名称
            //dr[CT_SplLedger] = string.Format("支払【{0}】", paymentSlpWork.MoneyKindName);
            dr[CT_SplLedger_StockSubttlPrice] = DBNull.Value;										                    // 仕入金額
            dr[CT_SplLedger_StockPriceConsTax] = DBNull.Value;										                    // 消費税額
            dr[CT_SplLedger_StockTotalPrice] = DBNull.Value;										                    // 仕入金額合計
            dr[CT_SplLedger_StockAddUpSectionCd] = paymentSlpWork.AddUpSecCode;

            dr[CT_SplLedger_Payment] = paymentSlpWork.Payment;						                    // 支払金額
            
            //dr[CT_SplLedger_Balance] = 0;													                    // 残高			
            dr[CT_SplLedger_SupplierSlipNote1] = paymentSlpWork.Outline;							                        // 備考(伝票適用)
            dr[CT_SplLedger_GoodsName] = paymentSlpWork.MoneyKindName;							                        // 支払金額区分名
            dr[CT_SplLedger_GoodsDiv] = paymentSlpWork.MoneyKindDiv;							                        // 支払金額区分

            //非表示項目
            dr[CT_SplLedger_DebitNoteDiv] = paymentSlpWork.DebitNoteDiv;                                            // 赤伝区分(0:黒,1:赤,2相殺済み黒)        
            dr[CT_SplLedger_PayeeCode] = paymentSlpWork.PayeeCode;						                            // 支払先コード
            dr[CT_SplLedger_SupplierCd] = paymentSlpWork.SupplierCd;						                    // 得意先コード
            //dr[CT_SplLedger_StockAddUpADate] = addUpDate;                                                              // 計上年月日
            dr[CT_SplLedger_StockRecordCd] = (int)RecordCode.PaymentSlp;							                    // レコード区分(0:支払買掛,1:支払伝票)
            dr[CT_SplLedger_SupplierSlipCd] = 0;													                    // 仕入伝票区分(10:仕入,20:返品)
            //dr[CT_SplLedger_BalanceCode] = (int)BalanceCode.Others;							                    // 前残繰越区分(0:前残,1:その他(支払買掛 or 支払伝票),2:消費税(請求単位の場合のみ),3:繰越)
            //dr[CT_SplLedger_StockAddUpADate] = paymentSlpWork.PaymentDate;							                    // 計上日付
            //dr[CT_SplLedger] = TDateTime.DateTimeToLongDate(paymentSlpWork.PaymentDate);               // 計上日付
            dr[CT_SplLedger_SupplierSlipCd] = 0;													                    // 仕入伝票種別			
            dr[CT_SplLedger_StockSectionCd] = paymentSlpWork.AddUpSecCode;						                    // 計上拠点コード
            //dr[CT_SplLedger_] = GetSectionName(paymentSlpWork.AddUpSecCode);		                    // 計上拠点名称
            //dr[CT_SplLedger_AddUpSecName] = GetSectionName(paymentSlpWork.AddUpSecCode);		                        // 計上拠点名称
            dr[CT_SplLedger_ValidityTerm] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.ValidityTerm); // 手形支払期日	
            //dr[CT_SplLedger_] = 1;                                                                                     // 印字区分 

            return dr;
        }

        // --- ADD 2012/11/01 ---------->>>>>
        /// <summary>
        /// 支払伝票情報→元帳伝票情報データ行設定処理(手数料)
        /// </summary>
        /// <param name="addUpDate">計上年月日(締単位)</param>
        /// <param name="paymentSlpWork">支払伝票データクラス</param>
        /// <returns>設定されたデータ行</returns>
        /// <remarks>
        /// <br>Note	: 支払データを元に手数料額行・値引額行を生成する</br>
        /// <br>Programer   : FSI斎藤 和宏</br>
        /// <br>Date        : 2012/11/01</br>
        /// </remarks>
        private static DataRow SetDataFeeRowFromPaymentSlp(int addUpDate, LedgerPaymentSlpWork paymentSlpWork)
        {
            DataRow dr = _stockLedgerSlipDataTable.NewRow();
            ////表示項目
            dr[CT_SplLedger_AddUpDate] = addUpDate;
            dr[CT_SplLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.AddUpADate);	// 計上日付(表示用)
            dr[CT_SplLedger_SupplierSlipNo] = String.Format("{0:D9}", paymentSlpWork.PaymentSlipNo);	                // 仕入伝票番号・支払伝票番号
            dr[CT_SplLedger_SlipKindNm] = "支払";                                                                       // 伝票種別名称
            //dr[CT_SplLedger] = string.Format("支払【{0}】", paymentSlpWork.MoneyKindName);
            dr[CT_SplLedger_StockSubttlPrice] = DBNull.Value;										                    // 仕入金額
            dr[CT_SplLedger_StockPriceConsTax] = DBNull.Value;										                    // 消費税額
            dr[CT_SplLedger_StockTotalPrice] = DBNull.Value;										                    // 仕入金額合計
            dr[CT_SplLedger_StockAddUpSectionCd] = paymentSlpWork.AddUpSecCode;

            dr[CT_SplLedger_Payment] = paymentSlpWork.FeePayment;						                    // 支払金額(手数料額)

            //dr[CT_SplLedger_Balance] = 0;													                    // 残高			
            dr[CT_SplLedger_SupplierSlipNote1] = paymentSlpWork.Outline;							                        // 備考(伝票適用)
            dr[CT_SplLedger_GoodsName] = "手数料";							                        // 支払金額区分名(手数料)
            dr[CT_SplLedger_GoodsDiv] = 998;      						                        // 支払金額区分(PMKOU02033P_02A4C_Detail.csと合わせる)

            //非表示項目
            dr[CT_SplLedger_DebitNoteDiv] = paymentSlpWork.DebitNoteDiv;                                            // 赤伝区分(0:黒,1:赤,2相殺済み黒)        
            dr[CT_SplLedger_PayeeCode] = paymentSlpWork.PayeeCode;						                            // 支払先コード
            dr[CT_SplLedger_SupplierCd] = paymentSlpWork.SupplierCd;						                    // 得意先コード
            //dr[CT_SplLedger_StockAddUpADate] = addUpDate;                                                              // 計上年月日
            dr[CT_SplLedger_StockRecordCd] = (int)RecordCode.PaymentSlp;							                    // レコード区分(0:支払買掛,1:支払伝票)
            dr[CT_SplLedger_SupplierSlipCd] = 0;													                    // 仕入伝票区分(10:仕入,20:返品)
            //dr[CT_SplLedger_BalanceCode] = (int)BalanceCode.Others;							                    // 前残繰越区分(0:前残,1:その他(支払買掛 or 支払伝票),2:消費税(請求単位の場合のみ),3:繰越)
            //dr[CT_SplLedger_StockAddUpADate] = paymentSlpWork.PaymentDate;							                    // 計上日付
            //dr[CT_SplLedger] = TDateTime.DateTimeToLongDate(paymentSlpWork.PaymentDate);               // 計上日付
            dr[CT_SplLedger_SupplierSlipCd] = 0;													                    // 仕入伝票種別			
            dr[CT_SplLedger_StockSectionCd] = paymentSlpWork.AddUpSecCode;						                    // 計上拠点コード
            //dr[CT_SplLedger_] = GetSectionName(paymentSlpWork.AddUpSecCode);		                    // 計上拠点名称
            //dr[CT_SplLedger_AddUpSecName] = GetSectionName(paymentSlpWork.AddUpSecCode);		                        // 計上拠点名称
            //dr[CT_SplLedger_ValidityTerm] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.ValidityTerm); // 手形支払期日	
            //dr[CT_SplLedger_] = 1;                                                                                     // 印字区分 

            return dr;
        }

        /// <summary>
        /// 支払伝票情報→元帳伝票情報データ行設定処理(値引)
        /// </summary>
        /// <param name="addUpDate">計上年月日(締単位)</param>
        /// <param name="paymentSlpWork">支払伝票データクラス</param>
        /// <returns>設定されたデータ行</returns>
        /// <remarks>
        /// <br>Note	: 支払データを元に手数料額行を生成する</br>
        /// <br>Programer   : FSI斎藤 和宏</br>
        /// <br>Date        : 2012/11/01</br>
        /// </remarks>
        private static DataRow SetDataDiscountRowFromPaymentSlp(int addUpDate, LedgerPaymentSlpWork paymentSlpWork)
        {
            DataRow dr = _stockLedgerSlipDataTable.NewRow();
            ////表示項目
            dr[CT_SplLedger_AddUpDate] = addUpDate;
            dr[CT_SplLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.AddUpADate);	// 計上日付(表示用)
            dr[CT_SplLedger_SupplierSlipNo] = String.Format("{0:D9}", paymentSlpWork.PaymentSlipNo);	                // 仕入伝票番号・支払伝票番号
            dr[CT_SplLedger_SlipKindNm] = "支払";                                                                       // 伝票種別名称
            //dr[CT_SplLedger] = string.Format("支払【{0}】", paymentSlpWork.MoneyKindName);
            dr[CT_SplLedger_StockSubttlPrice] = DBNull.Value;										                    // 仕入金額
            dr[CT_SplLedger_StockPriceConsTax] = DBNull.Value;										                    // 消費税額
            dr[CT_SplLedger_StockTotalPrice] = DBNull.Value;										                    // 仕入金額合計
            dr[CT_SplLedger_StockAddUpSectionCd] = paymentSlpWork.AddUpSecCode;

            dr[CT_SplLedger_Payment] = paymentSlpWork.DiscountPayment;						                    // 支払金額(値引額)

            //dr[CT_SplLedger_Balance] = 0;													                    // 残高			
            dr[CT_SplLedger_SupplierSlipNote1] = paymentSlpWork.Outline;							                        // 備考(伝票適用)
            dr[CT_SplLedger_GoodsName] = "値引";							                        // 支払金額区分名(値引)
            dr[CT_SplLedger_GoodsDiv] = 999;      						                        // 支払金額区分(PMKOU02033P_02A4C_Detail.csと合わせる)

            //非表示項目
            dr[CT_SplLedger_DebitNoteDiv] = paymentSlpWork.DebitNoteDiv;                                            // 赤伝区分(0:黒,1:赤,2相殺済み黒)        
            dr[CT_SplLedger_PayeeCode] = paymentSlpWork.PayeeCode;						                            // 支払先コード
            dr[CT_SplLedger_SupplierCd] = paymentSlpWork.SupplierCd;						                    // 得意先コード
            //dr[CT_SplLedger_StockAddUpADate] = addUpDate;                                                              // 計上年月日
            dr[CT_SplLedger_StockRecordCd] = (int)RecordCode.PaymentSlp;							                    // レコード区分(0:支払買掛,1:支払伝票)
            dr[CT_SplLedger_SupplierSlipCd] = 0;													                    // 仕入伝票区分(10:仕入,20:返品)
            //dr[CT_SplLedger_BalanceCode] = (int)BalanceCode.Others;							                    // 前残繰越区分(0:前残,1:その他(支払買掛 or 支払伝票),2:消費税(請求単位の場合のみ),3:繰越)
            //dr[CT_SplLedger_StockAddUpADate] = paymentSlpWork.PaymentDate;							                    // 計上日付
            //dr[CT_SplLedger] = TDateTime.DateTimeToLongDate(paymentSlpWork.PaymentDate);               // 計上日付
            dr[CT_SplLedger_SupplierSlipCd] = 0;													                    // 仕入伝票種別			
            dr[CT_SplLedger_StockSectionCd] = paymentSlpWork.AddUpSecCode;						                    // 計上拠点コード
            //dr[CT_SplLedger_] = GetSectionName(paymentSlpWork.AddUpSecCode);		                    // 計上拠点名称
            //dr[CT_SplLedger_AddUpSecName] = GetSectionName(paymentSlpWork.AddUpSecCode);		                        // 計上拠点名称
            //dr[CT_SplLedger_ValidityTerm] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.ValidityTerm); // 手形支払期日	
            //dr[CT_SplLedger_] = 1;                                                                                     // 印字区分 

            return dr;
        }
        // --- ADD 2012/11/01 ----------<<<<<
        #endregion

        #region 支払伝票情報→元帳明細情報データ行設定処理
        /// <summary>
        /// 支払伝票情報→元帳明細情報データ行設定処理
        /// </summary>
        /// <param name="addUpDate">計上年月日(締単位)</param>
        /// <param name="paymentSlpWork">支払伝票データクラス</param>
        /// <returns>設定されたデータ行</returns>
        /// <remarks>
        /// <br>Note	: 支払データを元に値引額行を生成する</br>
        /// <br>Programer   : FSI斎藤 和宏</br>
        /// <br>Date        : 2012/11/01</br>
        /// </remarks>
        private static DataRow SetDataRowFromPaymentDtl(int addUpDate, LedgerPaymentSlpWork paymentSlpWork)
        {
            DataRow dr = _stockLedgerDtlDataTable.NewRow();

            ////表示項目
            dr[CT_DtlLedger_AddUpDate] = addUpDate;
            dr[CT_DtlLedger_GoodsName] = paymentSlpWork.MoneyKindName;
            dr[CT_DtlLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.AddUpADate);	// 計上日付(表示用)
            dr[CT_DtlLedger_SupplierSlipNo] = String.Format("{0:D9}", paymentSlpWork.PaymentSlipNo);	                // 仕入伝票番号・支払伝票番号
            dr[CT_DtlLedger_SlipKindNm] = "支払";                                                                       // 伝票種別名称
            //dr[CT_SplLedger_Detail] = string.Format("支払【{0}】", paymentSlpWork.MoneyKindName);
            dr[CT_DtlLedger_StockSubttlPrice] = DBNull.Value;										                    // 仕入金額
            dr[CT_DtlLedger_StockPriceConsTax] = DBNull.Value;										                    // 消費税額
            dr[CT_DtlLedger_StockTotalPrice] = DBNull.Value;										                    // 仕入金額合計
            dr[CT_DtlLedger_StockAddUpSectionCd] = paymentSlpWork.AddUpSecCode;

            dr[CT_DtlLedger_Payment] = paymentSlpWork.Payment;						                    // 支払金額
            
            //dr[CT_SplLedger_Balance] = 0;													                    // 残高			
            dr[CT_DtlLedger_SupplierSlipNote1] = paymentSlpWork.Outline;							                        // 備考(伝票適用)

            //非表示項目
            dr[CT_DtlLedger_DebitNoteDiv] = paymentSlpWork.DebitNoteDiv;                                            // 赤伝区分(0:黒,1:赤,2相殺済み黒)        
            dr[CT_DtlLedger_PayeeCode] = paymentSlpWork.PayeeCode;						                            // 支払先コード
            dr[CT_DtlLedger_SupplierCd] = paymentSlpWork.SupplierCd;						                    // 得意先コード
            //dr[CT_SplLedger_StockAddUpADate] = addUpDate;                                                              // 計上年月日
            dr[CT_DtlLedger_StockRecordCd] = (int)RecordCode.PaymentSlp;							                    // レコード区分(0:支払買掛,1:支払伝票)
            dr[CT_DtlLedger_SupplierSlipCd] = 0;													                    // 仕入伝票区分(10:仕入,20:返品)
            //dr[CT_SplLedger_BalanceCode] = (int)BalanceCode.Others;							                    // 前残繰越区分(0:前残,1:その他(支払買掛 or 支払伝票),2:消費税(請求単位の場合のみ),3:繰越)
            //dr[CT_SplLedger_StockAddUpADate] = paymentSlpWork.PaymentDate;							                    // 計上日付
            //dr[CT_SplLedger] = TDateTime.DateTimeToLongDate(paymentSlpWork.PaymentDate);               // 計上日付
            dr[CT_DtlLedger_SupplierSlipCd] = 0;													                    // 仕入伝票種別			
            dr[CT_DtlLedger_StockSectionCd] = paymentSlpWork.AddUpSecCode;						                    // 計上拠点コード
            //dr[CT_SplLedger_] = GetSectionName(paymentSlpWork.AddUpSecCode);		                    // 計上拠点名称
            //dr[CT_SplLedger_AddUpSecName] = GetSectionName(paymentSlpWork.AddUpSecCode);		                        // 計上拠点名称
            dr[CT_DtlLedger_ValidityTerm] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.ValidityTerm); // 手形支払期日	
            //dr[CT_SplLedger_] = 1;                                                                                     // 印字区分 

            return dr;
        }
        // --- ADD 2012/11/01 ---------->>>>>
        /// <summary>
        /// 支払伝票情報→元帳明細情報データ行設定処理(手数料)
        /// </summary>
        /// <param name="addUpDate">計上年月日(締単位)</param>
        /// <param name="paymentSlpWork">支払伝票データクラス</param>
        /// <returns>設定されたデータ行</returns>
        /// <remarks>
        /// <br>Note	: 支払データを元に手数料額行を生成する</br>
        /// <br>Programer   : FSI斎藤 和宏</br>
        /// <br>Date        : 2012/11/01</br>
        /// </remarks>
        private static DataRow SetDataFeeRowFromPaymentDtl(int addUpDate, LedgerPaymentSlpWork paymentSlpWork)
        {
            DataRow dr = _stockLedgerDtlDataTable.NewRow();

            ////表示項目
            dr[CT_DtlLedger_AddUpDate] = addUpDate;
            dr[CT_DtlLedger_GoodsName] = "手数料";
            dr[CT_DtlLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.AddUpADate);	// 計上日付(表示用)
            dr[CT_DtlLedger_SupplierSlipNo] = String.Format("{0:D9}", paymentSlpWork.PaymentSlipNo);	                // 仕入伝票番号・支払伝票番号
            dr[CT_DtlLedger_SlipKindNm] = "支払";                                                                       // 伝票種別名称
            //dr[CT_SplLedger_Detail] = string.Format("支払【{0}】", paymentSlpWork.MoneyKindName);
            dr[CT_DtlLedger_StockSubttlPrice] = DBNull.Value;										                    // 仕入金額
            dr[CT_DtlLedger_StockPriceConsTax] = DBNull.Value;										                    // 消費税額
            dr[CT_DtlLedger_StockTotalPrice] = DBNull.Value;										                    // 仕入金額合計
            dr[CT_DtlLedger_StockAddUpSectionCd] = paymentSlpWork.AddUpSecCode;

            dr[CT_DtlLedger_Payment] = paymentSlpWork.FeePayment;						                    // 支払金額(手数料額)

            //dr[CT_SplLedger_Balance] = 0;													                    // 残高			
            dr[CT_DtlLedger_SupplierSlipNote1] = paymentSlpWork.Outline;							                        // 備考(伝票適用)

            //非表示項目
            dr[CT_DtlLedger_DebitNoteDiv] = paymentSlpWork.DebitNoteDiv;                                            // 赤伝区分(0:黒,1:赤,2相殺済み黒)        
            dr[CT_DtlLedger_PayeeCode] = paymentSlpWork.PayeeCode;						                            // 支払先コード
            dr[CT_DtlLedger_SupplierCd] = paymentSlpWork.SupplierCd;						                    // 得意先コード
            //dr[CT_SplLedger_StockAddUpADate] = addUpDate;                                                              // 計上年月日
            dr[CT_DtlLedger_StockRecordCd] = (int)RecordCode.PaymentSlp;							                    // レコード区分(0:支払買掛,1:支払伝票)
            dr[CT_DtlLedger_SupplierSlipCd] = 0;													                    // 仕入伝票区分(10:仕入,20:返品)
            //dr[CT_SplLedger_BalanceCode] = (int)BalanceCode.Others;							                    // 前残繰越区分(0:前残,1:その他(支払買掛 or 支払伝票),2:消費税(請求単位の場合のみ),3:繰越)
            //dr[CT_SplLedger_StockAddUpADate] = paymentSlpWork.PaymentDate;							                    // 計上日付
            //dr[CT_SplLedger] = TDateTime.DateTimeToLongDate(paymentSlpWork.PaymentDate);               // 計上日付
            dr[CT_DtlLedger_SupplierSlipCd] = 0;													                    // 仕入伝票種別			
            dr[CT_DtlLedger_StockSectionCd] = paymentSlpWork.AddUpSecCode;						                    // 計上拠点コード
            //dr[CT_SplLedger_] = GetSectionName(paymentSlpWork.AddUpSecCode);		                    // 計上拠点名称
            //dr[CT_SplLedger_AddUpSecName] = GetSectionName(paymentSlpWork.AddUpSecCode);		                        // 計上拠点名称
            //dr[CT_DtlLedger_ValidityTerm] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.ValidityTerm); // 手形支払期日	
            //dr[CT_SplLedger_] = 1;                                                                                     // 印字区分 

            return dr;
        }

        /// <summary>
        /// 支払伝票情報→元帳明細情報データ行設定処理(値引)
        /// </summary>
        /// <param name="addUpDate">計上年月日(締単位)</param>
        /// <param name="paymentSlpWork">支払伝票データクラス</param>
        /// <returns>設定されたデータ行</returns>
        /// <remarks>
        /// <br>Note	: 支払データを元に値引額行を生成する</br>
        /// <br>Programer   : FSI斎藤 和宏</br>
        /// <br>Date        : 2012/11/01</br>
        /// </remarks>
        private static DataRow SetDataDiscountRowFromPaymentDtl(int addUpDate, LedgerPaymentSlpWork paymentSlpWork)
        {
            DataRow dr = _stockLedgerDtlDataTable.NewRow();

            ////表示項目
            dr[CT_DtlLedger_AddUpDate] = addUpDate;
            dr[CT_DtlLedger_GoodsName] = "値引";
            dr[CT_DtlLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.AddUpADate);	// 計上日付(表示用)
            dr[CT_DtlLedger_SupplierSlipNo] = String.Format("{0:D9}", paymentSlpWork.PaymentSlipNo);	                // 仕入伝票番号・支払伝票番号
            dr[CT_DtlLedger_SlipKindNm] = "支払";                                                                       // 伝票種別名称
            //dr[CT_SplLedger_Detail] = string.Format("支払【{0}】", paymentSlpWork.MoneyKindName);
            dr[CT_DtlLedger_StockSubttlPrice] = DBNull.Value;										                    // 仕入金額
            dr[CT_DtlLedger_StockPriceConsTax] = DBNull.Value;										                    // 消費税額
            dr[CT_DtlLedger_StockTotalPrice] = DBNull.Value;										                    // 仕入金額合計
            dr[CT_DtlLedger_StockAddUpSectionCd] = paymentSlpWork.AddUpSecCode;

            dr[CT_DtlLedger_Payment] = paymentSlpWork.DiscountPayment;						                    // 支払金額(値引額)

            //dr[CT_SplLedger_Balance] = 0;													                    // 残高			
            dr[CT_DtlLedger_SupplierSlipNote1] = paymentSlpWork.Outline;							                        // 備考(伝票適用)

            //非表示項目
            dr[CT_DtlLedger_DebitNoteDiv] = paymentSlpWork.DebitNoteDiv;                                            // 赤伝区分(0:黒,1:赤,2相殺済み黒)        
            dr[CT_DtlLedger_PayeeCode] = paymentSlpWork.PayeeCode;						                            // 支払先コード
            dr[CT_DtlLedger_SupplierCd] = paymentSlpWork.SupplierCd;						                    // 得意先コード
            //dr[CT_SplLedger_StockAddUpADate] = addUpDate;                                                              // 計上年月日
            dr[CT_DtlLedger_StockRecordCd] = (int)RecordCode.PaymentSlp;							                    // レコード区分(0:支払買掛,1:支払伝票)
            dr[CT_DtlLedger_SupplierSlipCd] = 0;													                    // 仕入伝票区分(10:仕入,20:返品)
            //dr[CT_SplLedger_BalanceCode] = (int)BalanceCode.Others;							                    // 前残繰越区分(0:前残,1:その他(支払買掛 or 支払伝票),2:消費税(請求単位の場合のみ),3:繰越)
            //dr[CT_SplLedger_StockAddUpADate] = paymentSlpWork.PaymentDate;							                    // 計上日付
            //dr[CT_SplLedger] = TDateTime.DateTimeToLongDate(paymentSlpWork.PaymentDate);               // 計上日付
            dr[CT_DtlLedger_SupplierSlipCd] = 0;													                    // 仕入伝票種別			
            dr[CT_DtlLedger_StockSectionCd] = paymentSlpWork.AddUpSecCode;						                    // 計上拠点コード
            //dr[CT_SplLedger_] = GetSectionName(paymentSlpWork.AddUpSecCode);		                    // 計上拠点名称
            //dr[CT_SplLedger_AddUpSecName] = GetSectionName(paymentSlpWork.AddUpSecCode);		                        // 計上拠点名称
            //dr[CT_DtlLedger_ValidityTerm] = TDateTime.DateTimeToLongDate("yyyy.mm.dd", paymentSlpWork.ValidityTerm); // 手形支払期日	
            //dr[CT_SplLedger_] = 1;                                                                                     // 印字区分 

            return dr;
        }
        // --- ADD 2012/11/01 ----------<<<<<

        #endregion

        #region ◎仕入明細データ→元帳明細情報データ行設定処理
        /// <summary>
        /// 仕入明細データ→元帳明細情報データ行設定処理
        /// </summary>
        /// <param name="addUpDate">計上年月日</param>
        /// <param name="stockDtlWork">仕入明細データクラス</param>
        /// <returns>データ行</returns>
        /// <remarks>
        /// <br>Note        :仕入明細データを元帳明細情報データ行へ設定します。</br>
        /// <br>Programmer  : 20081 疋田 勇人</br>
        /// <br>Date        : 2007.11.26</br>
        /// </remarks>
        private static DataRow SetDataRowFromAccPayDtl(int addUpDate, LedgerStockDetailWork stockDtlWork)
        {
            DataRow dr = _stockLedgerDtlDataTable.NewRow();

            //テーブルのキーを変更
            //StockLedgerSupplier csLedgerSupplier = (StockLedgerSupplier)_stockLedgerSupplierInfoTable[stockDtlWork.PayeeCode.ToString() + "_" + addUpDate.ToString() + "_" + stockDtlWork.SectionCode];

            #region [テーブルに結果を格納]
            dr[CT_DtlLedger_EnterpriseCode] = stockDtlWork.EnterpriseCode; // 企業コード
            dr[CT_DtlLedger_AddUpDate] = addUpDate; // 計上日付(締基準)
            dr[CT_DtlLedger_SupplierFormal] = stockDtlWork.SupplierFormal; // 仕入形式
            dr[CT_DtlLedger_SupplierSlipNo] = stockDtlWork.SupplierSlipNo; // 仕入伝票番号
            dr[CT_DtlLedger_SlipKindNm] = "仕入"; // 仕入伝票種別
            dr[CT_DtlLedger_SectionCode] = stockDtlWork.SectionCode; // 拠点コード
            dr[CT_DtlLedger_DebitNoteDiv] = stockDtlWork.DebitNoteDiv; // 赤伝区分
            dr[CT_DtlLedger_DebitNLnkSuppSlipNo] = stockDtlWork.DebitNLnkSuppSlipNo; // 赤黒連結仕入伝票番号
            dr[CT_DtlLedger_SupplierSlipCd] = stockDtlWork.SupplierSlipCd; // 仕入伝票区分
            dr[CT_DtlLedger_StockGoodsCd] = stockDtlWork.StockGoodsCd; // 仕入商品区分
            dr[CT_DtlLedger_StockSectionCd] = stockDtlWork.StockSectionCd; // 仕入拠点コード
            dr[CT_DtlLedger_StockAddUpSectionCd] = stockDtlWork.StockAddUpSectionCd; // 仕入計上拠点コード
            dr[CT_DtlLedger_InputDay] = TDateTime.DateTimeToLongDate(stockDtlWork.InputDay); // 入力日
            dr[CT_DtlLedger_ArrivalGoodsDay] = TDateTime.DateTimeToLongDate(stockDtlWork.ArrivalGoodsDay); // 入荷日
            dr[CT_DtlLedger_StockDate] = TDateTime.DateTimeToLongDate(stockDtlWork.StockDate); // 仕入日
            dr[CT_DtlLedger_StockAddUpADate] = TDateTime.DateTimeToLongDate(stockDtlWork.StockAddUpADate); // 仕入計上日付
            dr[CT_DtlLedger_StockInputCode] = stockDtlWork.StockInputCode; // 仕入入力者コード
            dr[CT_DtlLedger_StockInputName] = stockDtlWork.StockInputName; // 仕入入力者名称
            dr[CT_DtlLedger_StockAgentCode] = stockDtlWork.StockAgentCode; // 仕入担当者コード
            dr[CT_DtlLedger_StockAgentName] = stockDtlWork.StockAgentName; // 仕入担当者名称
            dr[CT_DtlLedger_PayeeCode] = stockDtlWork.PayeeCode; // 支払先コード
            dr[CT_DtlLedger_PayeeSnm] = stockDtlWork.PayeeSnm; // 支払先略称
            dr[CT_DtlLedger_SupplierCd] = stockDtlWork.SupplierCd; // 仕入先コード
            dr[CT_DtlLedger_SupplierNm1] = stockDtlWork.SupplierNm1; // 仕入先名1
            dr[CT_DtlLedger_SupplierNm2] = stockDtlWork.SupplierNm2; // 仕入先名2
            dr[CT_DtlLedger_SupplierSnm] = stockDtlWork.SupplierSnm; // 仕入先略称
            dr[CT_DtlLedger_StockTotalPrice] = stockDtlWork.StockTotalPrice; // 仕入金額合計
            dr[CT_DtlLedger_StockSubttlPrice] = stockDtlWork.StockSubttlPrice; // 仕入金額小計
            dr[CT_DtlLedger_StockPriceConsTax] = stockDtlWork.StockPriceConsTax; // 仕入金額消費税額
            dr[CT_DtlLedger_PartySaleSlipNum] = stockDtlWork.PartySaleSlipNum; // 相手先伝票番号
            dr[CT_DtlLedger_SupplierSlipNote1] = stockDtlWork.SupplierSlipNote1; // 仕入伝票備考1
            dr[CT_DtlLedger_SupplierSlipNote2] = stockDtlWork.SupplierSlipNote2; // 仕入伝票備考2
            dr[CT_DtlLedger_UoeRemark1] = stockDtlWork.UoeRemark1; // ＵＯＥリマーク１
            dr[CT_DtlLedger_UoeRemark2] = stockDtlWork.UoeRemark2; // ＵＯＥリマーク２
            dr[CT_DtlLedger_StockRowNo] = stockDtlWork.StockRowNo; // 仕入行番号
            dr[CT_DtlLedger_CommonSeqNo] = stockDtlWork.CommonSeqNo; // 共通通番
            dr[CT_DtlLedger_StockSlipDtlNum] = stockDtlWork.StockSlipDtlNum; // 仕入明細通番
            dr[CT_DtlLedger_GoodsNo] = stockDtlWork.GoodsNo; // 商品番号
            dr[CT_DtlLedger_GoodsName] = stockDtlWork.GoodsName; // 商品名称
            dr[CT_DtlLedger_GoodsNameKana] = stockDtlWork.GoodsNameKana; // 商品名称カナ
            dr[CT_DtlLedger_SalesCustomerCode] = stockDtlWork.SalesCustomerCode; // 販売先コード
            dr[CT_DtlLedger_SalesCustomerSnm] = stockDtlWork.SalesCustomerSnm; // 販売先略称
            dr[CT_DtlLedger_StockCount] = stockDtlWork.StockCount; // 仕入数
            dr[CT_DtlLedger_StockUnitPriceFl] = stockDtlWork.StockUnitPriceFl; // 仕入単価（税抜，浮動）
            dr[CT_DtlLedger_StockPriceTaxExc] = stockDtlWork.StockPriceTaxExc; // 仕入金額（税抜き）
            dr[CT_DtlLedger_Dtl_StockPriceConsTax] = stockDtlWork.Dtl_StockPriceConsTax; // 仕入金額消費税額
            dr[CT_DtlLedger_StockRecordCd] = RecordCode.AccPay;

            #endregion
            return dr;
        }
        #endregion

        // <<< danger

        // >>> スルー
        #region 日付編集処理
        /// <summary>
		/// 日付編集処理
		/// </summary>
		/// <param name="day">日付</param>
		/// <returns>編集後文字列</returns>
		private static string GetFormatDay(int day)
		{
			return (day != 0) ? String.Format("{0,2}日", day) : "  日";
        }

        #endregion
        
        #region 計上年月（印刷用）文字列変換処理
        /// <summary>
		/// 計上年月（印刷用）文字列変換処理
		/// </summary>
		/// <param name="addUpYearMonth">計上年月</param>
		/// <returns>取得文字列</returns>
		/// <remarks>
		/// <br>Note        : 指定の計上年月を文字列に変換します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static string GetPrintAddUpYearMonth(Int32 addUpYearMonth)
		{
			string result = string.Empty;

			int yy = 0;
			int mm = 0;
			int dd = 0;
			string gen = string.Empty;

			int status = TDateTime.SplitDate("GGYYMMDD", addUpYearMonth * 100 + 1, ref gen, ref yy, ref mm, ref dd);
			if (status == 0)
			{
				result = String.Format("{0,2}年{1,2}月", yy, mm);
			}

			return result;
        }

        #endregion
        
        #region 計上年月日（印刷用）文字列変換処理
        /// <summary>
		/// 計上年月日（印刷用）文字列変換処理
		/// </summary>
		/// <param name="addUpDate">計上年月日</param>
		/// <returns>取得文字列</returns>
		/// <remarks>
		/// <br>Note        : 指定の計上年月日を文字列に変換します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static string GetPrintAddUpDate(DateTime addUpDate)
		{
			string result = string.Empty;

			int yy = 0;
			int mm = 0;
			int dd = 0;
			string gen = string.Empty;

			int status = TDateTime.SplitDate("YYYYMMDD", addUpDate, ref gen, ref yy, ref mm, ref dd);
			if (status == 0)
			{
				result = String.Format("({0,2}年{1,2}月{2,2}日計上)", yy, mm, dd);
			}

			return result;
        }

        #endregion
        
        #region 仕入伝票番号取得処理
        /// <summary>
		/// 仕入伝票番号取得処理
		/// </summary>
        /// <param name="stockSlipWork"></param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note        : データ行にセットする仕入伝票番号を取得します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static string GetSupplierSlipNo(LedgerStockSlipWork stockSlipWork)
		{
			if (stockSlipWork.SupplierSlipNo == 0)
			{
				return string.Empty;
			}
			else
			{
                return string.Format("{0:D9}", stockSlipWork.SupplierSlipNo);
			}
        }
        #endregion
        
        #region 仕入伝票番号取得処理
        /// <summary>
        /// 仕入伝票番号取得処理
        /// </summary>
        /// <param name="stockDtlWork"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : データ行にセットする仕入伝票番号を取得します。</br>
        /// <br>Programmer  : 20081 疋田 勇人</br>
        /// <br>Date        : 2007.11.26</br>
        /// </remarks>
        private static string GetSupplierSlipNo(LedgerStockDetailWork stockDtlWork)
        {
            if (stockDtlWork.SupplierSlipNo == 0)
            {
                return string.Empty;
            }
            else
            {
                return string.Format("{0:D9}", stockDtlWork.SupplierSlipNo);
            }
        }
        #endregion
        
        #region 仕入伝票区分名称取得処理
        /// <summary>
		/// 支払買掛情報 仕入伝票区分名称取得処理
		/// </summary>
		/// <param name="slipCd">仕入伝票区分</param>      
		/// <returns>仕入伝票区分名称</returns>
		/// <remarks>
		/// <br>Note        : 仕入伝票区分の名称を取得します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static string GetSlipKindNm(int slipCd)
		{
            //仕入伝票区分-20で赤伝区分が0のデータが返品
			string name = string.Empty;
			
            if(slipCd == 20)
            {
                name = "返品";
            }
			else
			{
				name = "仕入";
			}
			
			return name;
        }

        #endregion
        
        #region 伝票区分名称取得処理
        /// <summary>
		/// 伝票区分名称取得
		/// </summary>
        /// <param name="stockSlipWork">仕入データ</param>
		/// <returns>伝票区分名称</returns>
		/// <remarks>
		/// <br>Note        : 伝票区分名称を取得します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static string GetSupplierSlipNm(LedgerStockSlipWork stockSlipWork)
		{
			string name = string.Empty;

            switch(stockSlipWork.SupplierSlipCd)
            {
                case (int)SupplierLedgerSlipCdDiv.Stock:
                    {
                        name = "仕入";
                        break;
                    }
                case (int)SupplierLedgerSlipCdDiv.Back:
                    {
                        name = "返品";
                        break;
                    }
            }       
			return name;
        }

        #endregion
        
        #region 支払買掛情報 消費税セル内容取得処理
        /// <summary>
		/// 支払買掛情報 消費税セル内容取得処理
		/// </summary>
        /// <param name="stockSlipWork">支払買掛情報</param>
		/// <param name="stockLedgerSupplier">仕入先元帳仕入先情報</param>
		/// <returns>消費税セルに表示する値</returns>
		/// <remarks>
		/// <br>Note        : 消費税セルに表示する値を取得します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static object GetConsTax(LedgerStockSlipWork stockSlipWork, StockLedgerSupplier stockLedgerSupplier)
		{
			// 消費税転嫁方式
			if (stockLedgerSupplier.SuppCTaxLayCd == 2)	
				return DBNull.Value;
			else
                return stockSlipWork.StockPriceConsTax;	// 消費税額
        }

        #endregion
        
        #region 支払買掛情報 消費税セル内容取得処理
        /// <summary>
        /// 支払買掛情報 消費税セル内容取得処理
        /// </summary>
        /// <param name="stockDtlWork">支払買掛情報</param>
        /// <param name="stockLedgerSupplier">仕入先元帳仕入先情報</param>
        /// <returns>消費税セルに表示する値</returns>
        /// <remarks>
        /// <br>Note        : 消費税セルに表示する値を取得します。</br>
        /// <br>Programmer  : 20081 疋田 勇人</br>
        /// <br>Date        : 2007.11.26</br>
        /// </remarks>
        private static object GetConsTax(LedgerStockDetailWork stockDtlWork, StockLedgerSupplier stockLedgerSupplier)
        {
            // 消費税転嫁方式
            if (stockLedgerSupplier.SuppCTaxLayCd == 2)
                return DBNull.Value;
            else
                return stockDtlWork.StockPriceConsTax;	// 消費税額
        }

        #endregion
        
        #region 拠点名称取得処理
        /// <summary>
		/// 拠点名称取得処理
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>拠点名称</returns>
		/// <remarks>
		/// <br>Note        : 拠点名称を取得します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static string GetSectionName(string sectionCode)
		{
			string name = string.Empty;
			if (_sectionTable.Contains(sectionCode))
			{
				SecInfoSet secInfoSet = (SecInfoSet)_sectionTable[sectionCode];
				name = secInfoSet.SectionGuideNm;
			}
			return name;
        }

        #endregion

        #endregion

        #region 仕入先買掛金額データ取得処理(リモート接続)
        /// <summary>
		/// 仕入先買掛金額データ取得処理
		/// </summary>
        /// <param name="printDiv">印刷区分</param>
		/// <param name="param">パラメータ</param>
        /// <param name="outMoneyDiv">outMoneyDiv</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note        : 仕入先買掛金額データを取得します</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
        /// <br>Update Note : 2014/02/26 田建委</br>
        /// <br>            : Redmine#42188 出力金額区分追加</br>
        /// <br>UpdateNote  : 2015/12/10 田思春</br>
        /// <br>管理番号    : 11170204-00</br>
        /// <br>            : Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応</br>
        /// </remarks>
        //private static int GetSupplierAccPayInfo(string enterpriseCode, int customerCode, int startCustomerCode, int endCustomerCode, int startYearMonth, int endYearMonth, string sectionCode, ArrayList sectionCodeList, int mode)
        //private static int GetSupplierAccPayInfo(int printDiv, Broadleaf.Application.Remoting.ParamData.SuplAccInfGetParameter param)// DEL 2014/02/26 田建委 Redmine#42188
        private static int GetSupplierAccPayInfo(int printDiv, Broadleaf.Application.Remoting.ParamData.SuplAccInfGetParameter param, int outMoneyDiv)// ADD 2014/02/26 田建委 Redmine#42188
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            
            ArrayList suplAccPayList = null;
            Hashtable supplierSlpInf = null;     // 買掛(仕入)データ用HashTable
            Hashtable supplierDtlInf = null;     // 買掛(仕入)明細データ用HashTable
            Hashtable paymentSlpTable = null;     // 支払データ用HashTable
            ArrayList supplierSlpInfAry = null;     // 買掛(仕入)データ用ArrayList
            ArrayList supplierDtlInfAry = null;     // 買掛(仕入)明細データ用ArrayList 
            ArrayList paymentSlpTableAry = null;     // 支払データ用ArrayList
            object suplAccPayWorkList = null;
            object supplierSlpInfWork = null;
            object supplierDtlInfWork = null;
            object supplierPaymentInfWork = null;


            SuplAccInfGetWork suplAccInfGetWork = new SuplAccInfGetWork(); //仕入先買掛金額マスタパラメータ

            try
            {
                // 仕入先買掛金報取得アクセスクラス
                if (_getSuplAccAcs == null)
                {
                    _getSuplAccAcs = new GetSuplAccAcs();
                    _getSuplAccAcs.ThroughException = true;
                }

                //  元帳検索
                switch (printDiv)
                {
                case 1: // 明細モード
                    {
                        status = _suplAccInfGetDB.SearchDtl(out suplAccPayWorkList, out supplierDtlInfWork, out supplierPaymentInfWork, param);
                        suplAccPayList = suplAccPayWorkList as ArrayList;
                        supplierDtlInfAry = supplierDtlInfWork as ArrayList;
                        paymentSlpTableAry = supplierPaymentInfWork as ArrayList;
                        ArrayInfoToHashTableAcc(out supplierSlpInf, out supplierDtlInf, out paymentSlpTable,
                            //suplAccPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry);// DEL 2014/02/26 田建委 Redmine#42188
                        // ----ADD 2014/02/26 田建委 Redmine#42188 ---->>>>>
                            //ref suplAccPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv); // DEL 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応
                            ref suplAccPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv, param.SumSuppEnable); // ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応
                        if (suplAccPayList == null || suplAccPayList.Count == 0) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        // ----ADD 2014/02/26 田建委 Redmine#42188 ----<<<<<
                        break;
                    }
                case 2: // 伝票モード
                    {
                        status = _suplAccInfGetDB.SearchSlip(out suplAccPayWorkList, out supplierSlpInfWork, out supplierPaymentInfWork, param);
                        suplAccPayList = suplAccPayWorkList as ArrayList;
                        supplierSlpInfAry = supplierSlpInfWork as ArrayList;
                        paymentSlpTableAry = supplierPaymentInfWork as ArrayList;
                        ArrayInfoToHashTableAcc(out supplierSlpInf, out supplierDtlInf, out paymentSlpTable,
                            //suplAccPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry);// DEL 2014/02/26 田建委 Redmine#42188
                        // ----ADD 2014/02/26 田建委 Redmine#42188 ---->>>>>
                            //ref suplAccPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv); // DEL 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応
                            ref suplAccPayList, supplierSlpInfAry, supplierDtlInfAry, paymentSlpTableAry, outMoneyDiv, param.SumSuppEnable); // ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応
                        if (suplAccPayList == null || suplAccPayList.Count == 0) status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        // ----ADD 2014/02/26 田建委 Redmine#42188 ----<<<<<
                        break;
                    }
                default:
                    {
                        throw new CsLedgerException("印刷区分が不正です。", status);
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //仕入先支払情報データが１件以上ある
                    if(suplAccPayList.Count > 0)
                    {
                        //仕入先区分を取得(List内のものは全て同じ値になるので、０番目を取得)
                        SuplAccInfGetWork workFirst = (SuplAccInfGetWork)suplAccPayList[0];
                    }
                    //仕入先支払情報データリスト→StaticMemory設定
                    SetStaticFromSuplAccPayWorkList(suplAccPayList);

                    //得意先別計上年月日範囲取得
                    SetCustomerAddUpDateSpanAndAddUpDate(param.SupplierCd);

                    // 支払買掛・支払伝票データテーブル設定
                    AccPayAndPaymentSlpToDataTable(param.SupplierCd, supplierSlpInf, supplierDtlInf, paymentSlpTable);

                    // 支払伝票ワークを内部保持用に設定
                    foreach (ArrayList paymentSlpList in paymentSlpTable)
                    {
                        //ArrayList paymentSlpList = (ArrayList)de.Value;

                        if (paymentSlpList != null)
                        {
                            foreach (LedgerPaymentSlpWork wk in paymentSlpList)
                            {
                                if (wk != null)
                                {
                                    string key = string.Empty;
                                    key = wk.AddUpSecCode + "_" + wk.PayeeCode.ToString() + "_" + wk.SupplierCd.ToString() + "_" + String.Format("{0:D9}", wk.PaymentSlipNo);
                                    if (!_paymentSlpTable.ContainsKey(key))
                                    {
                                        _paymentSlpTable.Add(key, wk);
                                    }
                                }
                            }
                        }
                    }          
                }
                else
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    //
                }
                else
                {
                    throw new CsLedgerException("支払情報の取得に失敗しました。", status);
                }
            }
            catch (Exception ex)
            {
                throw new CsLedgerException(ex.Message, status);
            }
            finally
            {
                if (paymentSlpTable != null) paymentSlpTable = null;
                if (supplierSlpInf != null) supplierSlpInf = null;
                if (supplierDtlInf != null) supplierDtlInf = null;
                if (suplAccPayList != null) suplAccPayList = null;
            }
			return status;             
        }
    
        #endregion

        #region 仕入先買掛金額マスタデータリスト→StaticMemory設定処理
        /// <summary>
		/// 仕入先買掛金額マスタデータリスト→StaticMemory設定処理
		/// </summary>
		/// <param name="suplAccPayWorkList">買掛KINGETデータリスト</param>
		/// <remarks>
		/// <br>Note        : 仕入先買掛金額マスタパラメータの仕入先情報をStaticMemoryへ設定します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static void SetStaticFromSuplAccPayWorkList(ArrayList suplAccPayWorkList)
		{
            foreach (SuplAccInfGetWork suplAccInfGetWork in suplAccPayWorkList)
            {
                ////テーブルのkeyを(得意先 + 計上日 + 拠点)に変更し、計上日毎の鑑データを入れておく
                //string key = suplAccInfGetWork.PayeeCode.ToString() + "_" + TDateTime.DateTimeToLongDate(suplAccInfGetWork.AddUpDate).ToString() + "_" + suplAccInfGetWork.AddUpSecCode;
                //// 仕入先情報設定
                //if (!_stockLedgerSupplierInfoTable.Contains(key))
                //{
                //    //仕入先支払金額マスタデータより仕入先 + 計上日 + 拠点毎のデータを作成します。
                //    //各月ごとに消費税転嫁方式が異なるデータが作成可能なため
                //    _stockLedgerSupplierInfoTable.Add(key, CopySuplAccInfGetWork(suplAccInfGetWork));
                //}
             
                // データテーブル設定
                _suplierPayDataTable.Rows.Add(GetDataRowFromSuplierAccPayInfGetWork(suplAccInfGetWork));
            }
        }

        #endregion

        #region 仕入先買掛金額情報データ行設定処理(買掛)
		/// <summary>
		/// 仕入先買掛金額情報データ行設定処理(買掛)
		/// </summary>
		/// <param name="suplAccInfGetWork">仕入先買掛金額情報パラメータ</param>
		/// <returns>設定されたデータ行</returns>
		/// <remarks>
		/// <br>Note        : 仕入先買掛金額情報をデータ行へ設定します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
		private static DataRow GetDataRowFromSuplierAccPayInfGetWork(SuplAccInfGetWork suplAccInfGetWork)
		{
			DataRow newRow = _suplierPayDataTable.NewRow();

			GetDataRowFromSuplAccPayWork( ref newRow, suplAccInfGetWork );

			return newRow;
		}
		#endregion

        #region 仕入先買掛金額パラメータ→仕入先金額情報データ行設定処理
        /// <summary>
		/// 仕入先買掛金額パラメータ→仕入先金額情報データ行設定処理
		/// </summary>
        /// <param name="dr">データ行</param>
		/// <param name="work">仕入先買掛金額パラメータ</param>
		/// <remarks>
		/// <br>Note        : 仕入先買掛金額パラメータを仕入先金額データ行へ設定します。</br>
		/// <br>Programmer  : 20081 疋田 勇人</br>
		/// <br>Date        : 2007.11.26</br>
		/// </remarks>
        private static void GetDataRowFromSuplAccPayWork(ref DataRow dr ,SuplAccInfGetWork work)
        {
            //dr[COL_Spl_EnterpriseCode] = work.EnterpriseCode; // 企業コード
            dr[COL_Spl_AddUpSecCode] = work.AddUpSecCode; // 計上拠点コード
            dr[COL_Spl_AddUpSecName] = GetSectionName(work.AddUpSecCode); // 計上拠点コード
            dr[COL_Spl_PayeeCode] = work.PayeeCode; // 支払先コード
            //dr[COL_Spl_PayeeName] = work.PayeeName; // 支払先名称
            //dr[COL_Spl_PayeeName2] = work.PayeeName2; // 支払先名称2
            dr[COL_Spl_PayeeSnm] = work.PayeeSnm; // 支払先略称
            //dr[COL_Spl_ResultsSectCd] = work.ResultsSectCd; // 実績拠点コード
            //dr[COL_Spl_SupplierCd] = work.SupplierCd; // 仕入先コード
            //dr[COL_Spl_SupplierNm1] = work.SupplierNm1; // 仕入先名1
            //dr[COL_Spl_SupplierNm2] = work.SupplierNm2; // 仕入先名2
            //dr[COL_Spl_SupplierSnm] = work.SupplierSnm; // 仕入先略称
            dr[COL_Spl_AddUpDate] = TDateTime.DateTimeToLongDate(work.AddUpDate); // 計上年月日
            dr[COL_Spl_AddUpYearMonth] = TDateTime.DateTimeToLongDate(work.AddUpYearMonth); // 計上年月
            dr[COL_Spl_LastTimePayment] = work.LastTimeAccPay; // 前回支払金額
            dr[COL_Spl_StockTtl2TmBfBlPay] = work.StckTtl2TmBfBlAccPay; // 仕入2回前残高（支払計）
            dr[COL_Spl_StockTtl3TmBfBlPay] = work.StckTtl3TmBfBlAccPay; // 仕入3回前残高（支払計）
            dr[COL_Spl_ThisTimePayNrml] = work.ThisTimePayNrml; // 今回支払金額（通常支払）
            dr[COL_Spl_ThisTimeTtlBlcPay] = work.ThisTimeTtlBlcAcPay; // 今回繰越残高（支払計）
            dr[COL_Spl_OfsThisTimeStock] = work.OfsThisTimeStock; // 相殺後今回仕入金額
            dr[COL_Spl_OfsThisStockTax] = work.OfsThisStockTax; // 相殺後今回仕入消費税
            dr[COL_Spl_ThisStckPricRgds] = work.ThisStckPricRgds; // 今回返品金額
            dr[COL_Spl_ThisStcPrcTaxRgds] = work.ThisStcPrcTaxRgds; // 今回返品消費税
            dr[COL_Spl_ThisStckPricDis] = work.ThisStckPricDis; // 今回値引金額
            dr[COL_Spl_ThisStcPrcTaxDis] = work.ThisStcPrcTaxDis; // 今回値引消費税
            // 2009.03.02 30413 犬飼 返品値引の符号を反転させる >>>>>>START
            //dr[COL_Spl_ThisStckPricRgdsDis] = work.ThisStckPricRgds + work.ThisStckPricDis; // 今回返品金額+今回値引金額
            dr[COL_Spl_ThisStckPricRgdsDis] = -(work.ThisStckPricRgds + work.ThisStckPricDis); // 今回返品値引金額
            // 2009.03.02 30413 犬飼 返品値引の符号を反転させる <<<<<<END
            //dr[COL_Spl_TaxAdjust] = work.TaxAdjust; // 消費税調整額
            //dr[COL_Spl_BalanceAdjust] = work.BalanceAdjust; // 残高調整額
            dr[COL_Spl_StockTotalPayBalance] = work.StckTtlAccPayBalance; // 仕入合計残高（支払計）
            dr[COL_Spl_CAddUpUpdExecDate] = TDateTime.DateTimeToLongDate(work.MonthAddUpExpDate); // 締次更新実行年月日
            dr[COL_Spl_StartCAddUpUpdDate] = TDateTime.DateTimeToLongDate(work.StMonCAddUpUpdDate); // 締次更新開始年月日
            //dr[COL_Spl_LastCAddUpUpdDate] = work.LastCAddUpUpdDate; // 前回締次更新年月日
            dr[COL_Spl_StockSlipCount] = work.StockSlipCount; // 仕入伝票枚数
            //dr[COL_Spl_CloseFlg] = work.CloseFlg; // 締済みフラグ
            if (_imode == (int)Mode.Shr) { dr[COL_Spl_SlitTitle] = "支払残"; }
            else if (_imode == (int)Mode.Kai) { dr[COL_Spl_SlitTitle] = "買掛残"; }// 印刷用 支払残・買掛残

            // 2009.02.24 30413 犬飼 今回仕入金額の追加 >>>>>>START
            dr[COL_Spl_ThisTimeStockPrice] = work.ThisTimeStockPrice;   // 今回仕入金額
            // 2009.02.24 30413 犬飼 今回仕入金額の追加 <<<<<<END

            // --- ADD 2012/11/01 ---------->>>>>
            dr[COL_Spl_SuppCTaxLayCd] = work.SuppCTaxLayCd;         // 消費税転嫁方式
            // --- ADD 2012/11/01 ----------<<<<<
        }

        #endregion  
      
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

        #region [支払残ArrayをHashTableに入れる]
        /// <remarks>
        /// <br>UpdateNote : 2015/10/21 田思春</br>
        /// <br>管理番号   : 11170187-00</br>
        /// <br>           : Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応</br> 
        /// <br>UpdateNote : 2015/12/10 田思春</br>
        /// <br>管理番号   : 11170204-00</br>
        /// <br>           : Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応</br>
        /// </remarks>
        private static void ArrayInfoToHashTable(out Hashtable supplierSlpInf, out Hashtable supplierDtlInf, out Hashtable paymentSlpTable,
            //ArrayList suplierPayInfGetWorkList, ArrayList ledgerStockSlipWorkList, ArrayList ledgerStockDtlWorkList, ArrayList ledgerPaymentSlpWorkList)// DEL 2014/02/27 鄧潘ハン
            //ref ArrayList suplierPayInfGetWorkList, ArrayList ledgerStockSlipWorkList, ArrayList ledgerStockDtlWorkList, ArrayList ledgerPaymentSlpWorkList, int outMoneyDiv)// ADD 2014/02/27 鄧潘ハン // DEL 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応
            ref ArrayList suplierPayInfGetWorkList, ArrayList ledgerStockSlipWorkList, ArrayList ledgerStockDtlWorkList, ArrayList ledgerPaymentSlpWorkList, int outMoneyDiv, int sumSuppEnable) // ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応
        {
            try
            {
                supplierSlpInf = new Hashtable();
                supplierDtlInf = new Hashtable();
                paymentSlpTable = new Hashtable();

                // 仕入先支払金額情報リストが無い時は抜ける
                if (suplierPayInfGetWorkList == null) return;

                // ---ADD 2014/02/26 田建委 Redmine#42188--->>>>>
                List<SuplierPayInfGetWork> suplierPayInfGetDelList = new List<SuplierPayInfGetWork>();
                bool stockSlipFlag = false;
                bool stockDtlFlag = false;
                bool paymentSlpFlag = false;
                // ---ADD 2014/02/26 田建委 Redmine#42188---<<<<<

                // 取得した仕入先支払金額情報リストをまわす
                foreach (SuplierPayInfGetWork suplierPayInfGetWork in suplierPayInfGetWorkList)
                {
                    // ---ADD 2014/02/26 田建委 Redmine#42188--->>>>>
                    stockSlipFlag = false;
                    stockDtlFlag = false;
                    paymentSlpFlag = false;
                    // ---ADD 2014/02/26 田建委 Redmine#42188---<<<<<

                    // 仕入データを取得していて、戻り値リストに全て転記していない時
                    if ((ledgerStockSlipWorkList != null) && (ledgerStockSlipWorkList.Count > 0))
                    {
                        // 取得した仕入データをまわす
                        foreach (ArrayList ledgerStockSlipWorkAry in ledgerStockSlipWorkList)
                        {
                            foreach (LedgerStockSlipWork ledgerStockSlipWork in ledgerStockSlipWorkAry)
                            {
                                // 仕入データの計上日付を取得
                                int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", ledgerStockSlipWork.StockAddUpADate);

                                // 仕入データの計上日付が仕入先支払金額マスタの締日付範囲に入っている場合
                                if ((TDateTime.LongDateToDateTime(workAddUpADate) >= suplierPayInfGetWork.StartCAddUpUpdDate) &&
                                    (TDateTime.LongDateToDateTime(workAddUpADate) <= suplierPayInfGetWork.AddUpDate) &&
                                    // --- DEL 2015/10/21 田思春 For Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 ---------->>>>>
                                    //(ledgerStockSlipWork.StockAddUpSectionCd.TrimEnd() == suplierPayInfGetWork.AddUpSecCode.TrimEnd()) &&
                                    // --- DEL 2015/10/21 田思春 For Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 ----------<<<<<
                                    // --- ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ---------->>>>>
                                    ((ledgerStockSlipWork.StockAddUpSectionCd.TrimEnd() == suplierPayInfGetWork.AddUpSecCode.TrimEnd()) || (sumSuppEnable == 0)) && // 仕入総括オプションONの時、仕入データの仕入計上拠点コードが仕入支払金額情報の計上拠点コードと同様の場合、あるいは、仕入総括オプションOFFの場合
                                    // --- ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ----------<<<<<
                                    (ledgerStockSlipWork.PayeeCode == suplierPayInfGetWork.PayeeCode)) // 仕入データの支払先コードが仕入支払金額情報の支払先コードと同様(仕入総括オプションONの時、リモート側でPayeeCodeに仕入先(SupplierCd)が格納されている)
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", suplierPayInfGetWork.AddUpDate);

                                    // Hashtableに同一の計上日付が無い時は作成
                                    if (!supplierSlpInf.Contains(addUpDate)) supplierSlpInf.Add(addUpDate, new ArrayList());

                                    // 仕入先支払金額マスタの計上年月日をKEYにしてHashtableに仕入データをArrayListにしてぶら下げる
                                    ArrayList list = (ArrayList)supplierSlpInf[addUpDate];
                                    //list.Add(ledgerStockSlipWork.Clone());
                                    LedgerStockSlipWork ledgerStockSlipWorkClone = new LedgerStockSlipWork();
                                    ledgerStockSlipWorkClone.ArrivalGoodsDay = ledgerStockSlipWork.ArrivalGoodsDay;
                                    ledgerStockSlipWorkClone.DebitNLnkSuppSlipNo = ledgerStockSlipWork.DebitNLnkSuppSlipNo;
                                    ledgerStockSlipWorkClone.DebitNoteDiv = ledgerStockSlipWork.DebitNoteDiv;
                                    ledgerStockSlipWorkClone.EnterpriseCode = ledgerStockSlipWork.EnterpriseCode;
                                    ledgerStockSlipWorkClone.InputDay = ledgerStockSlipWork.InputDay;
                                    ledgerStockSlipWorkClone.PartySaleSlipNum = ledgerStockSlipWork.PartySaleSlipNum;
                                    ledgerStockSlipWorkClone.PayeeCode = ledgerStockSlipWork.PayeeCode;
                                    ledgerStockSlipWorkClone.PayeeSnm = ledgerStockSlipWork.PayeeSnm;
                                    ledgerStockSlipWorkClone.SectionCode = ledgerStockSlipWork.SectionCode;
                                    ledgerStockSlipWorkClone.StockAddUpADate = ledgerStockSlipWork.StockAddUpADate;
                                    ledgerStockSlipWorkClone.StockAddUpSectionCd = ledgerStockSlipWork.StockAddUpSectionCd;
                                    ledgerStockSlipWorkClone.StockAgentCode = ledgerStockSlipWork.StockAgentCode;
                                    ledgerStockSlipWorkClone.StockAgentName = ledgerStockSlipWork.StockAgentName;
                                    ledgerStockSlipWorkClone.StockDate = ledgerStockSlipWork.StockDate;
                                    ledgerStockSlipWorkClone.StockGoodsCd = ledgerStockSlipWork.StockGoodsCd;
                                    ledgerStockSlipWorkClone.StockInputCode = ledgerStockSlipWork.StockInputCode;
                                    ledgerStockSlipWorkClone.StockInputName = ledgerStockSlipWork.StockInputName;
                                    ledgerStockSlipWorkClone.StockPriceConsTax = ledgerStockSlipWork.StockPriceConsTax;
                                    ledgerStockSlipWorkClone.StockSectionCd = ledgerStockSlipWork.StockSectionCd;
                                    ledgerStockSlipWorkClone.StockSubttlPrice = ledgerStockSlipWork.StockSubttlPrice;
                                    ledgerStockSlipWorkClone.StockTotalPrice = ledgerStockSlipWork.StockTotalPrice;
                                    ledgerStockSlipWorkClone.SupplierCd = ledgerStockSlipWork.SupplierCd;
                                    ledgerStockSlipWorkClone.SupplierFormal = ledgerStockSlipWork.SupplierFormal;
                                    ledgerStockSlipWorkClone.SupplierNm1 = ledgerStockSlipWork.SupplierNm1;
                                    ledgerStockSlipWorkClone.SupplierNm2 = ledgerStockSlipWork.SupplierNm2;
                                    ledgerStockSlipWorkClone.SupplierSlipCd = ledgerStockSlipWork.SupplierSlipCd;
                                    ledgerStockSlipWorkClone.SupplierSlipNo = ledgerStockSlipWork.SupplierSlipNo;
                                    ledgerStockSlipWorkClone.SupplierSlipNote1 = ledgerStockSlipWork.SupplierSlipNote1;
                                    ledgerStockSlipWorkClone.SupplierSlipNote2 = ledgerStockSlipWork.SupplierSlipNote2;
                                    ledgerStockSlipWorkClone.SupplierSnm = ledgerStockSlipWork.SupplierSnm;
                                    ledgerStockSlipWorkClone.UoeRemark1 = ledgerStockSlipWork.UoeRemark1;
                                    ledgerStockSlipWorkClone.UoeRemark2 = ledgerStockSlipWork.UoeRemark2;
                                    list.Add(ledgerStockSlipWorkClone);
                                    stockSlipFlag = true;// ADD 2014/02/26 田建委 Redmine#42188
                                }
                            }
                        }
                    }

                    // 仕入明細データを取得していて、戻り値リストに全て転記していない時
                    if ((ledgerStockDtlWorkList != null) && (ledgerStockDtlWorkList.Count > 0))
                    {
                        // 取得した仕入明細伝票データをまわす
                        foreach (ArrayList ledgerStockDetailWorkAry in ledgerStockDtlWorkList)
                        {
                            foreach (LedgerStockDetailWork ledgerStockDetailWork in ledgerStockDetailWorkAry)
                            {
                                // 仕入伝票データの計上日付を取得
                                int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", ledgerStockDetailWork.StockAddUpADate);

                                // 仕入伝票データの計上日付が仕入先支払金額マスタの締日付範囲に入っている場合
                                if ((TDateTime.LongDateToDateTime(workAddUpADate) >= suplierPayInfGetWork.StartCAddUpUpdDate) &&
                                    (TDateTime.LongDateToDateTime(workAddUpADate) <= suplierPayInfGetWork.AddUpDate) &&
                                    // --- DEL 2015/10/21 田思春 For Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 ---------->>>>>
                                    //(ledgerStockDetailWork.StockAddUpSectionCd.TrimEnd() == suplierPayInfGetWork.AddUpSecCode.TrimEnd()) &&
                                    // --- DEL 2015/10/21 田思春 For Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 ----------<<<<<
                                    // --- ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ---------->>>>>
                                    ((ledgerStockDetailWork.StockAddUpSectionCd.TrimEnd() == suplierPayInfGetWork.AddUpSecCode.TrimEnd()) || (sumSuppEnable == 0)) && // 仕入総括オプションONの時、仕入データの仕入計上拠点コードが仕入支払金額情報の計上拠点コードと同様の場合、あるいは、仕入総括オプションOFFの場合
                                    // --- ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ----------<<<<<
                                    (ledgerStockDetailWork.PayeeCode == suplierPayInfGetWork.PayeeCode)) // 仕入データの支払先コードが仕入支払金額情報の支払先コードと同様(仕入総括オプションONの時、リモート側でPayeeCodeに仕入先(SupplierCd)が格納されている)
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", suplierPayInfGetWork.AddUpDate);

                                    // Hashtableに同一の計上日付が無い時は作成
                                    if (!supplierDtlInf.Contains(addUpDate)) supplierDtlInf.Add(addUpDate, new ArrayList());

                                    // 仕入先支払金額マスタの計上年月日をKEYにしてHashtableに支払明細伝票データをArrayListにしてぶら下げる
                                    ArrayList list = (ArrayList)supplierDtlInf[addUpDate];
                                    //list.Add(ledgerStockDetailWork.Clone());
                                    LedgerStockDetailWork ledgerStockDetailWorkClone = new LedgerStockDetailWork();
                                    ledgerStockDetailWorkClone.ArrivalGoodsDay = ledgerStockDetailWork.ArrivalGoodsDay;
                                    ledgerStockDetailWorkClone.CommonSeqNo = ledgerStockDetailWork.CommonSeqNo;
                                    ledgerStockDetailWorkClone.DebitNLnkSuppSlipNo = ledgerStockDetailWork.DebitNLnkSuppSlipNo;
                                    ledgerStockDetailWorkClone.DebitNoteDiv = ledgerStockDetailWork.DebitNoteDiv;
                                    ledgerStockDetailWorkClone.Dtl_StockPriceConsTax = ledgerStockDetailWork.Dtl_StockPriceConsTax;
                                    ledgerStockDetailWorkClone.EnterpriseCode = ledgerStockDetailWork.EnterpriseCode;
                                    ledgerStockDetailWorkClone.GoodsName = ledgerStockDetailWork.GoodsName;
                                    ledgerStockDetailWorkClone.GoodsNameKana = ledgerStockDetailWork.GoodsNameKana;
                                    ledgerStockDetailWorkClone.GoodsNo = ledgerStockDetailWork.GoodsNo;
                                    ledgerStockDetailWorkClone.InputDay = ledgerStockDetailWork.InputDay;
                                    ledgerStockDetailWorkClone.PartySaleSlipNum = ledgerStockDetailWork.PartySaleSlipNum;
                                    ledgerStockDetailWorkClone.PayeeCode = ledgerStockDetailWork.PayeeCode;
                                    ledgerStockDetailWorkClone.PayeeSnm = ledgerStockDetailWork.PayeeSnm;
                                    ledgerStockDetailWorkClone.SalesCustomerCode = ledgerStockDetailWork.SalesCustomerCode;
                                    ledgerStockDetailWorkClone.SalesCustomerSnm = ledgerStockDetailWork.SalesCustomerSnm;
                                    ledgerStockDetailWorkClone.SectionCode = ledgerStockDetailWork.SectionCode;
                                    ledgerStockDetailWorkClone.StockAddUpADate = ledgerStockDetailWork.StockAddUpADate;
                                    ledgerStockDetailWorkClone.StockAddUpSectionCd = ledgerStockDetailWork.StockAddUpSectionCd;
                                    ledgerStockDetailWorkClone.StockAgentCode = ledgerStockDetailWork.StockAgentCode;
                                    ledgerStockDetailWorkClone.StockAgentName = ledgerStockDetailWork.StockAgentName;
                                    ledgerStockDetailWorkClone.StockCount = ledgerStockDetailWork.StockCount;
                                    ledgerStockDetailWorkClone.StockDate = ledgerStockDetailWork.StockDate;
                                    ledgerStockDetailWorkClone.StockGoodsCd = ledgerStockDetailWork.StockGoodsCd;
                                    ledgerStockDetailWorkClone.StockInputCode = ledgerStockDetailWork.StockInputCode;
                                    ledgerStockDetailWorkClone.StockInputName = ledgerStockDetailWork.StockInputName;
                                    ledgerStockDetailWorkClone.StockPriceConsTax = ledgerStockDetailWork.StockPriceConsTax;
                                    ledgerStockDetailWorkClone.StockPriceTaxExc = ledgerStockDetailWork.StockPriceTaxExc;
                                    ledgerStockDetailWorkClone.StockRowNo = ledgerStockDetailWork.StockRowNo;
                                    ledgerStockDetailWorkClone.StockSectionCd = ledgerStockDetailWork.StockSectionCd;
                                    ledgerStockDetailWorkClone.StockSlipDtlNum = ledgerStockDetailWork.StockSlipDtlNum;
                                    ledgerStockDetailWorkClone.StockSubttlPrice = ledgerStockDetailWork.StockSubttlPrice;
                                    ledgerStockDetailWorkClone.StockTotalPrice = ledgerStockDetailWork.StockTotalPrice;
                                    ledgerStockDetailWorkClone.StockUnitPriceFl = ledgerStockDetailWork.StockUnitPriceFl;
                                    ledgerStockDetailWorkClone.SupplierCd = ledgerStockDetailWork.SupplierCd;
                                    ledgerStockDetailWorkClone.SupplierFormal = ledgerStockDetailWork.SupplierFormal;
                                    ledgerStockDetailWorkClone.SupplierNm1 = ledgerStockDetailWork.SupplierNm1;
                                    ledgerStockDetailWorkClone.SupplierNm2 = ledgerStockDetailWork.SupplierNm2;
                                    ledgerStockDetailWorkClone.SupplierSlipCd = ledgerStockDetailWork.SupplierSlipCd;
                                    ledgerStockDetailWorkClone.SupplierSlipNo = ledgerStockDetailWork.SupplierSlipNo;
                                    ledgerStockDetailWorkClone.SupplierSlipNote1 = ledgerStockDetailWork.SupplierSlipNote1;
                                    ledgerStockDetailWorkClone.SupplierSlipNote2 = ledgerStockDetailWork.SupplierSlipNote2;
                                    ledgerStockDetailWorkClone.SupplierSnm = ledgerStockDetailWork.SupplierSnm;
                                    ledgerStockDetailWorkClone.UoeRemark1 = ledgerStockDetailWork.UoeRemark1;
                                    ledgerStockDetailWorkClone.UoeRemark2 = ledgerStockDetailWork.UoeRemark2;
                                    list.Add(ledgerStockDetailWorkClone);;
                                    stockDtlFlag = true;// ADD 2014/02/26 田建委 Redmine#42188
                                }
                            }
                        }
                    }

                    // 支払伝票データを取得していて、戻り値リストに全て転記していない時
                    if ((ledgerPaymentSlpWorkList != null) && (ledgerPaymentSlpWorkList.Count > 0))
                    {
                        // 取得した支払伝票データをまわす
                        foreach (ArrayList ledgerPaymentSlpWorkAry in ledgerPaymentSlpWorkList)
                        {
                            foreach (LedgerPaymentSlpWork ledgerPaymentSlpWork in ledgerPaymentSlpWorkAry)
                            {
                                // 支払伝票データの計上日付を取得
                                int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", ledgerPaymentSlpWork.AddUpADate);

                                // 支払伝票データの計上日付が仕入先支払金額マスタの締日付範囲に入っている場合
                                if ((TDateTime.LongDateToDateTime(workAddUpADate) >= suplierPayInfGetWork.StartCAddUpUpdDate) &&
                                    (TDateTime.LongDateToDateTime(workAddUpADate) <= suplierPayInfGetWork.AddUpDate) &&
                                    (ledgerPaymentSlpWork.AddUpSecCode.TrimEnd() == suplierPayInfGetWork.AddUpSecCode.TrimEnd()) &&
                                    (ledgerPaymentSlpWork.PayeeCode == suplierPayInfGetWork.PayeeCode))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", suplierPayInfGetWork.AddUpDate);

                                    // Hashtableに同一の計上日付が無い時は作成
                                    if (!paymentSlpTable.Contains(addUpDate)) paymentSlpTable.Add(addUpDate, new ArrayList());

                                    // 仕入先支払金額マスタの計上年月日をKEYにしてHashtableに支払伝票データをArrayListにしてぶら下げる
                                    ArrayList list = (ArrayList)paymentSlpTable[addUpDate];
                                    //list.Add(ledgerPaymentSlpWork.Clone());
                                    LedgerPaymentSlpWork ledgerPaymentSlpWorkClone = new LedgerPaymentSlpWork();
                                    ledgerPaymentSlpWorkClone.AddUpADate = ledgerPaymentSlpWork.AddUpADate;
                                    ledgerPaymentSlpWorkClone.AddUpSecCode = ledgerPaymentSlpWork.AddUpSecCode;
                                    ledgerPaymentSlpWorkClone.DebitNoteDiv = ledgerPaymentSlpWork.DebitNoteDiv;
                                    ledgerPaymentSlpWorkClone.EnterpriseCode = ledgerPaymentSlpWork.EnterpriseCode;
                                    ledgerPaymentSlpWorkClone.MoneyKindCode = ledgerPaymentSlpWork.MoneyKindCode;
                                    ledgerPaymentSlpWorkClone.MoneyKindDiv = ledgerPaymentSlpWork.MoneyKindDiv;
                                    ledgerPaymentSlpWorkClone.MoneyKindName = ledgerPaymentSlpWork.MoneyKindName;
                                    ledgerPaymentSlpWorkClone.Outline = ledgerPaymentSlpWork.Outline;
                                    ledgerPaymentSlpWorkClone.PayeeCode = ledgerPaymentSlpWork.PayeeCode;
                                    ledgerPaymentSlpWorkClone.PayeeName = ledgerPaymentSlpWork.PayeeName;
                                    ledgerPaymentSlpWorkClone.PayeeName2 = ledgerPaymentSlpWork.PayeeName2;
                                    ledgerPaymentSlpWorkClone.PayeeSnm = ledgerPaymentSlpWork.PayeeSnm;
                                    ledgerPaymentSlpWorkClone.Payment = ledgerPaymentSlpWork.Payment;
                                    // --- ADD 2012/11/01 ---------->>>>>
                                    ledgerPaymentSlpWorkClone.FeePayment = ledgerPaymentSlpWork.FeePayment;
                                    ledgerPaymentSlpWorkClone.DiscountPayment = ledgerPaymentSlpWork.DiscountPayment;
                                    // --- ADD 2012/11/01 ----------<<<<<
                                    ledgerPaymentSlpWorkClone.PaymentAgentCode = ledgerPaymentSlpWork.PaymentAgentCode;
                                    ledgerPaymentSlpWorkClone.PaymentAgentName = ledgerPaymentSlpWork.PaymentAgentName;
                                    ledgerPaymentSlpWorkClone.PaymentDate = ledgerPaymentSlpWork.PaymentDate;
                                    ledgerPaymentSlpWorkClone.PaymentInpSectionCd = ledgerPaymentSlpWork.PaymentInpSectionCd;
                                    ledgerPaymentSlpWorkClone.PaymentInputAgentCd = ledgerPaymentSlpWork.PaymentInputAgentCd;
                                    ledgerPaymentSlpWorkClone.PaymentInputAgentNm = ledgerPaymentSlpWork.PaymentInputAgentNm;
                                    ledgerPaymentSlpWorkClone.PaymentRowNo = ledgerPaymentSlpWork.PaymentRowNo;
                                    ledgerPaymentSlpWorkClone.PaymentSlipNo = ledgerPaymentSlpWork.PaymentSlipNo;
                                    ledgerPaymentSlpWorkClone.SupplierCd = ledgerPaymentSlpWork.SupplierCd;
                                    ledgerPaymentSlpWorkClone.SupplierFormal = ledgerPaymentSlpWork.SupplierFormal;
                                    ledgerPaymentSlpWorkClone.SupplierNm1 = ledgerPaymentSlpWork.SupplierNm1;
                                    ledgerPaymentSlpWorkClone.SupplierNm2 = ledgerPaymentSlpWork.SupplierNm2;
                                    ledgerPaymentSlpWorkClone.SupplierSlipNo = ledgerPaymentSlpWork.SupplierSlipNo;
                                    ledgerPaymentSlpWorkClone.SupplierSnm = ledgerPaymentSlpWork.SupplierSnm;
                                    ledgerPaymentSlpWorkClone.UpdateSecCd = ledgerPaymentSlpWork.UpdateSecCd;
                                    ledgerPaymentSlpWorkClone.ValidityTerm = ledgerPaymentSlpWork.ValidityTerm;
                                    list.Add(ledgerPaymentSlpWorkClone);
                                    paymentSlpFlag = true;// ADD 2014/02/26 田建委 Redmine#42188
                                }
                            }
                        }
                    }

                    // ---ADD 2014/02/26 田建委 Redmine#42188 ------>>>>>
                    if (stockSlipFlag == false
                       && stockDtlFlag == false
                       && paymentSlpFlag == false
                       && outMoneyDiv == 1
                       && suplierPayInfGetWork.LastTimePayment == 0     //前回支払金額
                       && suplierPayInfGetWork.StockTtl2TmBfBlPay == 0  //仕入2回前残高（支払計）
                       && suplierPayInfGetWork.StockTtl3TmBfBlPay == 0) //仕入3回前残高（支払計）
                    {

                        suplierPayInfGetDelList.Add(suplierPayInfGetWork);
                    }
                    // ---ADD 2014/02/26 田建委 Redmine#42188 ------<<<<<

                }

                // ---ADD 2014/02/26 田建委 Redmine#42188 ------>>>>>
                if (outMoneyDiv == 0) return;
                // 全て金額0の場合、印刷しない
                foreach (SuplierPayInfGetWork wkSuplierPayInfGet in suplierPayInfGetDelList)
                {
                    if (suplierPayInfGetWorkList.Contains(wkSuplierPayInfGet))
                    {
                        suplierPayInfGetWorkList.Remove(wkSuplierPayInfGet);
                    }
                }
                // ---ADD 2014/02/26 田建委 Redmine#42188 ------<<<<<

                return ;
            }
            catch (Exception)
            {
                suplierPayInfGetWorkList = null;
                supplierSlpInf = null;
                supplierDtlInf = null;
                paymentSlpTable = null;

                
                //if (this._throughException) throw (e);

                ////オフライン時はnullをセット
                //this._iSuplierPayInfGetDB = null;
                //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "DCKAK02623A", e.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                //return -1;
            }
        }
        #endregion
        #region [買掛残ArrayをHashTableに入れる]
        /// <remarks>
        /// <br>UpdateNote : 2015/10/21 田思春</br>
        /// <br>管理番号   : 11170187-00</br>
        /// <br>           : Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応</br>
        /// <br>UpdateNote  : 2015/12/10 田思春</br>
        /// <br>管理番号    : 11170204-00</br>
        /// <br>            : Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応</br>
        /// </remarks>
        private static void ArrayInfoToHashTableAcc(out Hashtable supplierSlpInf, out Hashtable supplierDtlInf, out Hashtable paymentSlpTable,
            //ArrayList suplAccPayWorkList, ArrayList ledgerStockSlipWorkList, ArrayList ledgerStockDtlWorkList, ArrayList ledgerPaymentSlpWorkList)// DEL 2014/02/26 田建委 Redmine#42188
            //ref ArrayList suplAccPayWorkList, ArrayList ledgerStockSlipWorkList, ArrayList ledgerStockDtlWorkList, ArrayList ledgerPaymentSlpWorkList, int outMoneyDiv)// ADD 2014/02/26 田建委 Redmine#42188 // DEL 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応
            ref ArrayList suplAccPayWorkList, ArrayList ledgerStockSlipWorkList, ArrayList ledgerStockDtlWorkList, ArrayList ledgerPaymentSlpWorkList, int outMoneyDiv, int sumSuppEnable) // ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応
        {
            try
            {
                supplierSlpInf = new Hashtable();
                supplierDtlInf = new Hashtable();
                paymentSlpTable = new Hashtable();

                // 仕入先支払金額情報リストが無い時は抜ける
                if (suplAccPayWorkList == null) return;

                // ------ADD 2014/02/26 田建委 Redmine#42188------------------------>>>>>
                List<SuplAccInfGetWork> suplAccInfGetDelList = new List<SuplAccInfGetWork>();

                bool stockSlipFlag = false;
                bool stockDtlFlag = false;
                bool paymentSlpFlag = false;
                // ------ADD 2014/02/26 田建委 Redmine#42188------------------------<<<<<

                // 取得した仕入先支払金額情報リストをまわす
                foreach (SuplAccInfGetWork suplAccPayWork in suplAccPayWorkList)
                {
                    // --ADD 2014/02/26 田建委 Redmine#42188-->>>>>
                    stockSlipFlag = false;
                    stockDtlFlag = false;
                    paymentSlpFlag = false;
                    // --ADD 2014/02/26 田建委 Redmine#42188--<<<<<


                    // 仕入データを取得していて、戻り値リストに全て転記していない時
                    if ((ledgerStockSlipWorkList != null) && (ledgerStockSlipWorkList.Count > 0))
                    {
                        // 取得した仕入データをまわす
                        foreach (ArrayList ledgerStockSlipWorkAry in ledgerStockSlipWorkList)
                        {
                            foreach (LedgerStockSlipWork ledgerStockSlipWork in ledgerStockSlipWorkAry)
                            {
                                // 仕入データの計上日付を取得
                                int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", ledgerStockSlipWork.StockAddUpADate);

                                // 仕入データの計上日付が仕入先支払金額マスタの締日付範囲に入っている場合
                                if ((TDateTime.LongDateToDateTime(workAddUpADate) >= suplAccPayWork.StMonCAddUpUpdDate) &&
                                    (TDateTime.LongDateToDateTime(workAddUpADate) <= suplAccPayWork.AddUpDate) &&
                                    // --- DEL 2015/10/21 田思春 For Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 ---------->>>>>
                                    //(ledgerStockSlipWork.StockAddUpSectionCd.TrimEnd() == suplAccPayWork.AddUpSecCode.TrimEnd()) &&
                                    // --- DEL 2015/10/21 田思春 For Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 ----------<<<<<
                                    // --- ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ---------->>>>>
                                    ((ledgerStockSlipWork.StockAddUpSectionCd.TrimEnd() == suplAccPayWork.AddUpSecCode.TrimEnd()) || (sumSuppEnable == 0)) && // 仕入総括オプションONの時、仕入データの仕入計上拠点コードが仕入支払金額情報の計上拠点コードと同様の場合、あるいは、仕入総括オプションOFFの場合
                                    // --- ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ----------<<<<<
                                    (ledgerStockSlipWork.PayeeCode == suplAccPayWork.PayeeCode)) // 仕入データの支払先コードが仕入支払金額情報の支払先コードと同様(仕入総括オプションONの時、リモート側でPayeeCodeに仕入先(SupplierCd)が格納されている)
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", suplAccPayWork.AddUpDate);

                                    // Hashtableに同一の計上日付が無い時は作成
                                    if (!supplierSlpInf.Contains(addUpDate)) supplierSlpInf.Add(addUpDate, new ArrayList());

                                    // 仕入先支払金額マスタの計上年月日をKEYにしてHashtableに仕入データをArrayListにしてぶら下げる
                                    ArrayList list = (ArrayList)supplierSlpInf[addUpDate];
                                    //list.Add(ledgerStockSlipWork.Clone());
                                    LedgerStockSlipWork ledgerStockSlipWorkClone = new LedgerStockSlipWork();
                                    ledgerStockSlipWorkClone.ArrivalGoodsDay = ledgerStockSlipWork.ArrivalGoodsDay;
                                    ledgerStockSlipWorkClone.DebitNLnkSuppSlipNo = ledgerStockSlipWork.DebitNLnkSuppSlipNo;
                                    ledgerStockSlipWorkClone.DebitNoteDiv = ledgerStockSlipWork.DebitNoteDiv;
                                    ledgerStockSlipWorkClone.EnterpriseCode = ledgerStockSlipWork.EnterpriseCode;
                                    ledgerStockSlipWorkClone.InputDay = ledgerStockSlipWork.InputDay;
                                    ledgerStockSlipWorkClone.PartySaleSlipNum = ledgerStockSlipWork.PartySaleSlipNum;
                                    ledgerStockSlipWorkClone.PayeeCode = ledgerStockSlipWork.PayeeCode;
                                    ledgerStockSlipWorkClone.PayeeSnm = ledgerStockSlipWork.PayeeSnm;
                                    ledgerStockSlipWorkClone.SectionCode = ledgerStockSlipWork.SectionCode;
                                    ledgerStockSlipWorkClone.StockAddUpADate = ledgerStockSlipWork.StockAddUpADate;
                                    ledgerStockSlipWorkClone.StockAddUpSectionCd = ledgerStockSlipWork.StockAddUpSectionCd;
                                    ledgerStockSlipWorkClone.StockAgentCode = ledgerStockSlipWork.StockAgentCode;
                                    ledgerStockSlipWorkClone.StockAgentName = ledgerStockSlipWork.StockAgentName;
                                    ledgerStockSlipWorkClone.StockDate = ledgerStockSlipWork.StockDate;
                                    ledgerStockSlipWorkClone.StockGoodsCd = ledgerStockSlipWork.StockGoodsCd;
                                    ledgerStockSlipWorkClone.StockInputCode = ledgerStockSlipWork.StockInputCode;
                                    ledgerStockSlipWorkClone.StockInputName = ledgerStockSlipWork.StockInputName;
                                    ledgerStockSlipWorkClone.StockPriceConsTax = ledgerStockSlipWork.StockPriceConsTax;
                                    ledgerStockSlipWorkClone.StockSectionCd = ledgerStockSlipWork.StockSectionCd;
                                    ledgerStockSlipWorkClone.StockSubttlPrice = ledgerStockSlipWork.StockSubttlPrice;
                                    ledgerStockSlipWorkClone.StockTotalPrice = ledgerStockSlipWork.StockTotalPrice;
                                    ledgerStockSlipWorkClone.SupplierCd = ledgerStockSlipWork.SupplierCd;
                                    ledgerStockSlipWorkClone.SupplierFormal = ledgerStockSlipWork.SupplierFormal;
                                    ledgerStockSlipWorkClone.SupplierNm1 = ledgerStockSlipWork.SupplierNm1;
                                    ledgerStockSlipWorkClone.SupplierNm2 = ledgerStockSlipWork.SupplierNm2;
                                    ledgerStockSlipWorkClone.SupplierSlipCd = ledgerStockSlipWork.SupplierSlipCd;
                                    ledgerStockSlipWorkClone.SupplierSlipNo = ledgerStockSlipWork.SupplierSlipNo;
                                    ledgerStockSlipWorkClone.SupplierSlipNote1 = ledgerStockSlipWork.SupplierSlipNote1;
                                    ledgerStockSlipWorkClone.SupplierSlipNote2 = ledgerStockSlipWork.SupplierSlipNote2;
                                    ledgerStockSlipWorkClone.SupplierSnm = ledgerStockSlipWork.SupplierSnm;
                                    ledgerStockSlipWorkClone.UoeRemark1 = ledgerStockSlipWork.UoeRemark1;
                                    ledgerStockSlipWorkClone.UoeRemark2 = ledgerStockSlipWork.UoeRemark2;
                                    list.Add(ledgerStockSlipWorkClone);
                                    stockSlipFlag = true;// ADD 2014/02/26 田建委 Redmine#42188
                                }
                            }
                        }
                    }

                    // 仕入明細データを取得していて、戻り値リストに全て転記していない時
                    if ((ledgerStockDtlWorkList != null) && (ledgerStockDtlWorkList.Count > 0))
                    {
                        // 取得した仕入明細伝票データをまわす
                        foreach (ArrayList ledgerStockDetailWorkAry in ledgerStockDtlWorkList)
                        {
                            foreach (LedgerStockDetailWork ledgerStockDetailWork in ledgerStockDetailWorkAry)
                            {
                                // 仕入伝票データの計上日付を取得
                                int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", ledgerStockDetailWork.StockAddUpADate);

                                // 仕入伝票データの計上日付が仕入先支払金額マスタの締日付範囲に入っている場合
                                if ((TDateTime.LongDateToDateTime(workAddUpADate) >= suplAccPayWork.StMonCAddUpUpdDate) &&
                                    (TDateTime.LongDateToDateTime(workAddUpADate) <= suplAccPayWork.AddUpDate) &&
                                    // --- DEL 2015/10/21 田思春 For Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 ---------->>>>>
                                    //(ledgerStockDetailWork.StockAddUpSectionCd.TrimEnd() == suplAccPayWork.AddUpSecCode.TrimEnd()) &&
                                    // --- DEL 2015/10/21 田思春 For Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 ----------<<<<<
                                    // --- ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ---------->>>>>
                                    ((ledgerStockDetailWork.StockAddUpSectionCd.TrimEnd() == suplAccPayWork.AddUpSecCode.TrimEnd()) || (sumSuppEnable == 0)) && // 仕入総括オプションONの時、仕入データの仕入計上拠点コードが仕入支払金額情報の計上拠点コードと同様の場合、あるいは、仕入総括オプションOFFの場合
                                    // --- ADD 2015/12/10 田思春 For Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 ----------<<<<<
                                    (ledgerStockDetailWork.PayeeCode == suplAccPayWork.PayeeCode)) // 仕入データの支払先コードが仕入支払金額情報の支払先コードと同様(仕入総括オプションONの時、リモート側でPayeeCodeに仕入先(SupplierCd)が格納されている)
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", suplAccPayWork.AddUpDate);

                                    // Hashtableに同一の計上日付が無い時は作成
                                    if (!supplierDtlInf.Contains(addUpDate)) supplierDtlInf.Add(addUpDate, new ArrayList());

                                    // 仕入先支払金額マスタの計上年月日をKEYにしてHashtableに支払明細伝票データをArrayListにしてぶら下げる
                                    ArrayList list = (ArrayList)supplierDtlInf[addUpDate];
                                    //list.Add(ledgerStockDetailWork.Clone());
                                    LedgerStockDetailWork ledgerStockDetailWorkClone = new LedgerStockDetailWork();
                                    ledgerStockDetailWorkClone.ArrivalGoodsDay = ledgerStockDetailWork.ArrivalGoodsDay;
                                    ledgerStockDetailWorkClone.CommonSeqNo = ledgerStockDetailWork.CommonSeqNo;
                                    ledgerStockDetailWorkClone.DebitNLnkSuppSlipNo = ledgerStockDetailWork.DebitNLnkSuppSlipNo;
                                    ledgerStockDetailWorkClone.DebitNoteDiv = ledgerStockDetailWork.DebitNoteDiv;
                                    ledgerStockDetailWorkClone.Dtl_StockPriceConsTax = ledgerStockDetailWork.Dtl_StockPriceConsTax;
                                    ledgerStockDetailWorkClone.EnterpriseCode = ledgerStockDetailWork.EnterpriseCode;
                                    ledgerStockDetailWorkClone.GoodsName = ledgerStockDetailWork.GoodsName;
                                    ledgerStockDetailWorkClone.GoodsNameKana = ledgerStockDetailWork.GoodsNameKana;
                                    ledgerStockDetailWorkClone.GoodsNo = ledgerStockDetailWork.GoodsNo;
                                    ledgerStockDetailWorkClone.InputDay = ledgerStockDetailWork.InputDay;
                                    ledgerStockDetailWorkClone.PartySaleSlipNum = ledgerStockDetailWork.PartySaleSlipNum;
                                    ledgerStockDetailWorkClone.PayeeCode = ledgerStockDetailWork.PayeeCode;
                                    ledgerStockDetailWorkClone.PayeeSnm = ledgerStockDetailWork.PayeeSnm;
                                    ledgerStockDetailWorkClone.SalesCustomerCode = ledgerStockDetailWork.SalesCustomerCode;
                                    ledgerStockDetailWorkClone.SalesCustomerSnm = ledgerStockDetailWork.SalesCustomerSnm;
                                    ledgerStockDetailWorkClone.SectionCode = ledgerStockDetailWork.SectionCode;
                                    ledgerStockDetailWorkClone.StockAddUpADate = ledgerStockDetailWork.StockAddUpADate;
                                    ledgerStockDetailWorkClone.StockAddUpSectionCd = ledgerStockDetailWork.StockAddUpSectionCd;
                                    ledgerStockDetailWorkClone.StockAgentCode = ledgerStockDetailWork.StockAgentCode;
                                    ledgerStockDetailWorkClone.StockAgentName = ledgerStockDetailWork.StockAgentName;
                                    ledgerStockDetailWorkClone.StockCount = ledgerStockDetailWork.StockCount;
                                    ledgerStockDetailWorkClone.StockDate = ledgerStockDetailWork.StockDate;
                                    ledgerStockDetailWorkClone.StockGoodsCd = ledgerStockDetailWork.StockGoodsCd;
                                    ledgerStockDetailWorkClone.StockInputCode = ledgerStockDetailWork.StockInputCode;
                                    ledgerStockDetailWorkClone.StockInputName = ledgerStockDetailWork.StockInputName;
                                    ledgerStockDetailWorkClone.StockPriceConsTax = ledgerStockDetailWork.StockPriceConsTax;
                                    ledgerStockDetailWorkClone.StockPriceTaxExc = ledgerStockDetailWork.StockPriceTaxExc;
                                    ledgerStockDetailWorkClone.StockRowNo = ledgerStockDetailWork.StockRowNo;
                                    ledgerStockDetailWorkClone.StockSectionCd = ledgerStockDetailWork.StockSectionCd;
                                    ledgerStockDetailWorkClone.StockSlipDtlNum = ledgerStockDetailWork.StockSlipDtlNum;
                                    ledgerStockDetailWorkClone.StockSubttlPrice = ledgerStockDetailWork.StockSubttlPrice;
                                    ledgerStockDetailWorkClone.StockTotalPrice = ledgerStockDetailWork.StockTotalPrice;
                                    ledgerStockDetailWorkClone.StockUnitPriceFl = ledgerStockDetailWork.StockUnitPriceFl;
                                    ledgerStockDetailWorkClone.SupplierCd = ledgerStockDetailWork.SupplierCd;
                                    ledgerStockDetailWorkClone.SupplierFormal = ledgerStockDetailWork.SupplierFormal;
                                    ledgerStockDetailWorkClone.SupplierNm1 = ledgerStockDetailWork.SupplierNm1;
                                    ledgerStockDetailWorkClone.SupplierNm2 = ledgerStockDetailWork.SupplierNm2;
                                    ledgerStockDetailWorkClone.SupplierSlipCd = ledgerStockDetailWork.SupplierSlipCd;
                                    ledgerStockDetailWorkClone.SupplierSlipNo = ledgerStockDetailWork.SupplierSlipNo;
                                    ledgerStockDetailWorkClone.SupplierSlipNote1 = ledgerStockDetailWork.SupplierSlipNote1;
                                    ledgerStockDetailWorkClone.SupplierSlipNote2 = ledgerStockDetailWork.SupplierSlipNote2;
                                    ledgerStockDetailWorkClone.SupplierSnm = ledgerStockDetailWork.SupplierSnm;
                                    ledgerStockDetailWorkClone.UoeRemark1 = ledgerStockDetailWork.UoeRemark1;
                                    ledgerStockDetailWorkClone.UoeRemark2 = ledgerStockDetailWork.UoeRemark2;
                                    list.Add(ledgerStockDetailWorkClone);
                                    stockDtlFlag = true;// ADD 2014/02/26 田建委 Redmine#42188
                                }
                            }
                        }
                    }

                    // 支払伝票データを取得していて、戻り値リストに全て転記していない時
                    if ((ledgerPaymentSlpWorkList != null) && (ledgerPaymentSlpWorkList.Count > 0))
                    {
                        // 取得した支払伝票データをまわす
                        foreach (ArrayList ledgerPaymentSlpWorkAry in ledgerPaymentSlpWorkList)
                        {
                            foreach (LedgerPaymentSlpWork ledgerPaymentSlpWork in ledgerPaymentSlpWorkAry)
                            {
                                // 支払伝票データの計上日付を取得
                                int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", ledgerPaymentSlpWork.AddUpADate);

                                // 支払伝票データの計上日付が仕入先支払金額マスタの締日付範囲に入っている場合
                                if ((TDateTime.LongDateToDateTime(workAddUpADate) >= suplAccPayWork.StMonCAddUpUpdDate) &&
                                    (TDateTime.LongDateToDateTime(workAddUpADate) <= suplAccPayWork.AddUpDate) &&
                                    (ledgerPaymentSlpWork.AddUpSecCode.TrimEnd() == suplAccPayWork.AddUpSecCode.TrimEnd()) &&
                                    (ledgerPaymentSlpWork.PayeeCode == suplAccPayWork.PayeeCode))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", suplAccPayWork.AddUpDate);

                                    // Hashtableに同一の計上日付が無い時は作成
                                    if (!paymentSlpTable.Contains(addUpDate)) paymentSlpTable.Add(addUpDate, new ArrayList());

                                    // 仕入先支払金額マスタの計上年月日をKEYにしてHashtableに支払伝票データをArrayListにしてぶら下げる
                                    ArrayList list = (ArrayList)paymentSlpTable[addUpDate];
                                    //list.Add(ledgerPaymentSlpWork.Clone());
                                    LedgerPaymentSlpWork ledgerPaymentSlpWorkClone = new LedgerPaymentSlpWork();
                                    ledgerPaymentSlpWorkClone.AddUpADate = ledgerPaymentSlpWork.AddUpADate;
                                    ledgerPaymentSlpWorkClone.AddUpSecCode = ledgerPaymentSlpWork.AddUpSecCode;
                                    ledgerPaymentSlpWorkClone.DebitNoteDiv = ledgerPaymentSlpWork.DebitNoteDiv;
                                    ledgerPaymentSlpWorkClone.EnterpriseCode = ledgerPaymentSlpWork.EnterpriseCode;
                                    ledgerPaymentSlpWorkClone.MoneyKindCode = ledgerPaymentSlpWork.MoneyKindCode;
                                    ledgerPaymentSlpWorkClone.MoneyKindDiv = ledgerPaymentSlpWork.MoneyKindDiv;
                                    ledgerPaymentSlpWorkClone.MoneyKindName = ledgerPaymentSlpWork.MoneyKindName;
                                    ledgerPaymentSlpWorkClone.Outline = ledgerPaymentSlpWork.Outline;
                                    ledgerPaymentSlpWorkClone.PayeeCode = ledgerPaymentSlpWork.PayeeCode;
                                    ledgerPaymentSlpWorkClone.PayeeName = ledgerPaymentSlpWork.PayeeName;
                                    ledgerPaymentSlpWorkClone.PayeeName2 = ledgerPaymentSlpWork.PayeeName2;
                                    ledgerPaymentSlpWorkClone.PayeeSnm = ledgerPaymentSlpWork.PayeeSnm;
                                    ledgerPaymentSlpWorkClone.Payment = ledgerPaymentSlpWork.Payment;
                                    // --- ADD 2012/11/01 ---------->>>>>
                                    ledgerPaymentSlpWorkClone.FeePayment = ledgerPaymentSlpWork.FeePayment;
                                    ledgerPaymentSlpWorkClone.DiscountPayment = ledgerPaymentSlpWork.DiscountPayment;
                                    // --- ADD 2012/11/01 ----------<<<<<
                                    ledgerPaymentSlpWorkClone.PaymentAgentCode = ledgerPaymentSlpWork.PaymentAgentCode;
                                    ledgerPaymentSlpWorkClone.PaymentAgentName = ledgerPaymentSlpWork.PaymentAgentName;
                                    ledgerPaymentSlpWorkClone.PaymentDate = ledgerPaymentSlpWork.PaymentDate;
                                    ledgerPaymentSlpWorkClone.PaymentInpSectionCd = ledgerPaymentSlpWork.PaymentInpSectionCd;
                                    ledgerPaymentSlpWorkClone.PaymentInputAgentCd = ledgerPaymentSlpWork.PaymentInputAgentCd;
                                    ledgerPaymentSlpWorkClone.PaymentInputAgentNm = ledgerPaymentSlpWork.PaymentInputAgentNm;
                                    ledgerPaymentSlpWorkClone.PaymentRowNo = ledgerPaymentSlpWork.PaymentRowNo;
                                    ledgerPaymentSlpWorkClone.PaymentSlipNo = ledgerPaymentSlpWork.PaymentSlipNo;
                                    ledgerPaymentSlpWorkClone.SupplierCd = ledgerPaymentSlpWork.SupplierCd;
                                    ledgerPaymentSlpWorkClone.SupplierFormal = ledgerPaymentSlpWork.SupplierFormal;
                                    ledgerPaymentSlpWorkClone.SupplierNm1 = ledgerPaymentSlpWork.SupplierNm1;
                                    ledgerPaymentSlpWorkClone.SupplierNm2 = ledgerPaymentSlpWork.SupplierNm2;
                                    ledgerPaymentSlpWorkClone.SupplierSlipNo = ledgerPaymentSlpWork.SupplierSlipNo;
                                    ledgerPaymentSlpWorkClone.SupplierSnm = ledgerPaymentSlpWork.SupplierSnm;
                                    ledgerPaymentSlpWorkClone.UpdateSecCd = ledgerPaymentSlpWork.UpdateSecCd;
                                    ledgerPaymentSlpWorkClone.ValidityTerm = ledgerPaymentSlpWork.ValidityTerm;
                                    list.Add(ledgerPaymentSlpWorkClone);
                                    paymentSlpFlag = true;// ADD 2014/02/26 田建委 Redmine#42188
                                }
                            }
                        }
                    }

                    // ---ADD 2014/02/26 田建委 Redmine#42188 ------>>>>>
                    if (stockSlipFlag == false
                       && stockDtlFlag == false
                       && paymentSlpFlag == false
                       && outMoneyDiv == 1
                       && suplAccPayWork.LastTimeAccPay == 0        //前回買掛金額
                       && suplAccPayWork.StckTtl2TmBfBlAccPay == 0  //仕入2回前残高（買掛計）
                       && suplAccPayWork.StckTtl3TmBfBlAccPay == 0) //仕入3回前残高（買掛計）
                    {

                        suplAccInfGetDelList.Add(suplAccPayWork);
                    }
                    // ---ADD 2014/02/26 田建委 Redmine#42188 ------<<<<<

                }

                // ---ADD 2014/02/26 田建委 Redmine#42188 ------>>>>>
                if (outMoneyDiv == 0) return;
                // 全て金額0の場合、印刷しない
                foreach (SuplAccInfGetWork wkSuplAccInfGet in suplAccInfGetDelList)
                {
                    if (suplAccPayWorkList.Contains(wkSuplAccInfGet))
                    {
                        suplAccPayWorkList.Remove(wkSuplAccInfGet);
                    }
                }
                // ---ADD 2014/02/26 田建委 Redmine#42188 ------<<<<<

                return;
            }
            catch (Exception)
            {
                suplAccPayWorkList = null;
                supplierSlpInf = null;
                supplierDtlInf = null;
                paymentSlpTable = null;

                //if (this._throughException) throw (e);

                ////オフライン時はnullをセット
                //this._iSuplierPayInfGetDB = null;
                //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "DCKAK02623A", e.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                //return -1;
            }
        }
        #endregion
    }
   
}


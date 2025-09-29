//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 請求書発行(総括)
// プログラム概要   : 請求書発行(総括)の印字を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30531 大矢　睦美
// 作 成 日  2010/02/01  修正内容 : Mantis【14929】請求書タイプ毎に印刷制御ができるように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30531 大矢　睦美
// 作 成 日  2010/02/24  修正内容 : Mantis【15037】金額プラスなどの絞り込み条件が有効になるよう修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2010/03/12  修正内容 : Mantis【15092】掛率区分『売掛』の時現金得意先があるとそれ以降の得意先が印字されない件の修正
//----------------------------------------------------------------------------//
// 管理番号  11570208-00    作成担当：陳艶丹
// 修正日    2020/04/13     修正内容：PMKOBETSU-2912 軽減税率の対応
// ---------------------------------------------------------------------//
// 管理番号  11800255-00    作成担当：陳艶丹
// 修正日    2022/08/30     修正内容：PMKOBETSU-4225 インボイス対応（税率別合計金額不具合修正）
// ---------------------------------------------------------------------//

using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Collections;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Windows.Forms;
// --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----->>>>>
using System.Reflection;
using Broadleaf.Windows.Forms;
// --- ADD 2020/04/13 陳艶丹 軽減税率対応 -----<<<<<
namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// 請求書発行(総括)アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求書発行(総括)の情報を取得するアクセスクラスです。</br>
    /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/04/13</br>
    /// </remarks>
    public class SumDemandPrintAcs
    {
        //================================================================================
        //  外部提供定数群
        //================================================================================
        #region public constant
        
        /// <summary>請求帳票データセット名</summary>
        public const string CT_DemandDataSet = "DemandDataSet";
        /// <summary>得意先請求金額データテーブル名</summary>
        public const string CT_CustDmdPrcDataTable = "CustDmdPrcDataTable";
        
        /// <summary>全拠点コード</summary>
        public const string CT_AllSectionCode = "00";

        //--------------------------------------------------
        //  得意先請求金額カラム情報
        //--------------------------------------------------
        #region 得意先請求金額カラム情報
        /// <summary>ユニークID</summary>
        public const string CT_CsDmd_UniqueID = "UniqueID";

        /// <summary>レコードタイプ</summary>
        public const string CT_CsDmd_DataType = "DataType";

        /// <summary>レコード名</summary>
        public const string CT_CsDmd_RecordName = "RecordName";
        
        /// <summary>印刷フラグ</summary>
        public const string CT_CsDmd_PrintFlag = "PrintFlag";

        /// <summary>印刷用インデックス</summary>
        public const string CT_CsDmd_PrintIndex = "PrintIndex";

        /// <summary>計上拠点コード</summary>
        public const string CT_CsDmd_AddUpSecCode = "AddUpSecCode";

        /// <summary>計上拠点名称</summary>
        public const string CT_CsDmd_AddUpSecName = "AddUpSecName";

        /// <summary>請求拠点コード</summary>
        public const string CT_CsDmd_ClaimSectionCode = "ClaimSectionCode";

        /// <summary>請求拠点名称</summary>
        public const string CT_CsDmd_ClaimSectionName = "ClaimSectionName";
        
        /// <summary>実績拠点コード</summary>
        public const string CT_CsDmd_ResultsSectCd = "ResultsSectCd";
        
        /// <summary>総括得意先コード</summary>
        public const string CT_CsDmd_SumClaimCustCode = "SumClaimCustCode";

        /// <summary>総括得意先コード(抽出結果表示用)</summary>
        public const string CT_CsDmd_SumClaimCustCodeDisp = "SumClaimCustCodeDisp";

        /// <summary>総括得意先略称</summary>
        public const string CT_CsDmd_SumClaimCustSnm = "SumClaimCustSnm";

        /// <summary>請求先コード</summary>
        public const string CT_CsDmd_ClaimCode = "ClaimCode";

        /// <summary>請求先コード(抽出結果表示用)</summary>
        public const string CT_CsDmd_ClaimCodeDisp = "ClaimCodeDisp";
        
        /// <summary>請求先名称</summary>
        public const string CT_CsDmd_ClaimName = "ClaimName";

        /// <summary>請求先名称2</summary>
        public const string CT_CsDmd_ClaimName2 = "ClaimName2";

        /// <summary>請求先略称</summary>
        public const string CT_CsDmd_ClaimSnm = "ClaimSnm";

        /// <summary>得意先コード</summary>
        public const string CT_CsDmd_CustomerCode = "CustomerCode";

        /// <summary>得意先名称</summary>
        public const string CT_CsDmd_CustomerName = "CustomerName";

        /// <summary>得意先名称2</summary>
        public const string CT_CsDmd_CustomerName2 = "CustomerName2";

        /// <summary>得意先略称</summary>
        public const string CT_CsDmd_CustomerSnm = "CustomerSnm";

        /// <summary>計上年月日</summary>
        public const string CT_CsDmd_AddUpDate = "AddUpDate";

        /// <summary>計上年月日(数値型)</summary>
        public const string CT_CsDmd_AddUpDateInt = "AddUpDateInt";

        /// <summary>計上年月</summary>
        public const string CT_CsDmd_AddUpYearMonth = "AddUpYearMonth";

        /// <summary>前回請求額</summary>
        public const string CT_CsDmd_LastTimeDemand = "LastTimeDemand";

        /// <summary>今回入金金額（通常入金）</summary>
        public const string CT_CsDmd_ThisTimeDmdNrml = "ThisTimeDmdNrml";

        /// <summary>今回手数料額（通常入金）</summary>
        public const string CT_CsDmd_ThisTimeFeeDmdNrml = "ThisTimeFeeDmdNrml";

        /// <summary>今回値引額(通常入金)</summary>
        public const string CT_CsDmd_ThisTimeDisDmdNrml = "ThisTimeDisDmdNrml";

        /// <summary>今回繰越残高（請求計）[今回繰越残高＝前回請求額－入金額（請求計）]</summary>
        public const string CT_CsDmd_ThisTimeTtlBlcDmd = "ThisTimeTtlBlcDmd";

        /// <summary>相殺後今回売上金額</summary>
        public const string CT_CsDmd_OfsThisTimeSales = "OfsThisTimeSales";

        /// <summary>相殺後今回売上消費税</summary>
        public const string CT_CsDmd_OfsThisSalesTax = "OfsThisSalesTax";

        /// <summary>相殺後今回合計売上金額</summary>
        public const string CT_CsDmd_OfsThisSalesSum = "OfsThisSalesSum";

        /// <summary>今回売上金額</summary>
        public const string CT_CsDmd_ThisTimeSales = "ThisTimeSales";

        /// <summary>今回売上返品金額</summary>
        public const string CT_CsDmd_ThisSalesPricRgds = "ThisSalesPricRgds";

        /// <summary>今回売上値引金額</summary>
        public const string CT_CsDmd_ThisSalesPricDis = "ThisSalesPricDis";

        /// <summary>今回売上返品・値引金額</summary>
        public const string CT_CsDmd_ThisSalesPricRgdsDis = "ThisSalesPricRgdsDis";

        /// <summary>残高調整額</summary>
        public const string CT_CsDmd_BalanceAdjust = "BalanceAdjust";

        /// <summary>計算後請求金額</summary>
        public const string CT_CsDmd_AfCalDemandPrice = "AfCalDemandPrice";

        /// <summary>計算後請求金額(フィルター用)</summary>
        public const string CT_CsDmd_AfCalDemandPriceFilter = "AfCalDemandPriceFilter";
            
        /// <summary>売上伝票枚数</summary>
        public const string CT_CsDmd_SaleslSlipCount = "SaleslSlipCount";

        /// <summary>端数処理区分</summary>
        public const string CT_CsDmd_FractionProcCd = "FractionProcCd";

        #endregion

        //--------------------------------------------------
        //  得意先関連情報
        //--------------------------------------------------
        #region 得意先関連情報
        /// <summary>締日</summary>
        public const string CT_CsDmd_TotalDay = "TotalDay";

        /// <summary>締日(印刷用)</summary>
        public const string CT_CsDmd_PrintTotalDay = "PrintTotalDay";

        /// <summary>集金月区分名称</summary>
        public const string CT_CsDmd_CollectMoneyName = "CollectMoneyName";

        /// <summary>集金日</summary>
        public const string CT_CsDmd_CollectMoneyDay = "CollectMoneyDay";

        /// <summary>集金日(印刷用)</summary>
        public const string CT_CsDmd_CollectMoneyDayNm = "CollectMoneyDayNm";

        /// <summary>顧客担当従業員コード</summary>
        public const string CT_CsDmd_CustomerAgentCd = "CustomerAgentCd";

        /// <summary>顧客担当従業員名称</summary>
        public const string CT_CsDmd_CustomerAgentNm = "CustomerAgentNm";

        /// <summary>集金担当従業員コード</summary>
        public const string CT_CsDmd_BillCollecterCd = "BillCollecterCd";

        /// <summary>集金担当従業員名称</summary>
        public const string CT_CsDmd_BillCollecterNm = "BillCollecterNm";

        /// <summary>印刷用従業員コード</summary>
        public const string CT_CsDmd_EmployeeCd = "EmployeeCd";

        /// <summary>印刷用従業員名称</summary>
        public const string CT_CsDmd_EmployeeNm = "EmployeeNm";

        /// <summary>総額表示区分</summary>
        public const string CT_CsDmd_TotalAmountDispWayCd = "TotalAmountDispWayCd";

        #endregion
        
        //--------------------------------------------------
        //  その他項目(印刷用)
        //--------------------------------------------------
        #region その他項目(印刷用)
        /// <summary>請求金額</summary>
        public const string CT_CsDmd_PrintAfCalDemandPrice = "PrintAfCalDemandPrice";

        /// <summary>今回消費税</summary>
        public const string CT_CsDmd_PrintTtlConsTaxDmd = "PrintTtlConsTaxDmd";

        #endregion
        
        /// <summary>請求残高</summary>
        public const string CT_CsDmd_DemandBalance = "DemandBalance";

        /// <summary>純売上額</summary>
        public const string CT_CsDmd_NetSales = "NetSales";

        /// <summary>回収率</summary>
        public const string CT_CsDmd_CollectRate = "CollectRate";

        /// <summary>回収残高(合計部計算用)</summary>
        public const string CT_CsDmd_CollectDemand = "CollectDemand";

        /// <summary>販売エリアコード</summary>
        public const string CT_CsDmd_SalesAreaCode = "SalesAreaCode";

        /// <summary>販売エリア名称</summary>
        public const string CT_CsDmd_SalesAreaName = "SalesAreaName";

        //--------------------------------------------------
        //  残高入金内訳
        //--------------------------------------------------
        /// <summary>受注３回前残高(前々々回)</summary>
        public const string CT_Blnce_AcpOdrTtl3TmBfBlDmd = "AcpOdrTtl3TmBfBlDmd";

        /// <summary>受注２回前残高(前々回)</summary>
        public const string CT_Blnce_AcpOdrTtl2TmBfBlDmd = "AcpOdrTtl2TmBfBlDmd";

        /// <summary>現金(金種区分)</summary>
        public const string CT_Blnce_MoneyKindDiv101 = "MoneyKindDiv101";

        /// <summary>振込(金種区分)</summary>
        public const string CT_Blnce_MoneyKindDiv102 = "MoneyKindDiv102";

        /// <summary>小切手(金種区分)</summary>
        public const string CT_Blnce_MoneyKindDiv107 = "MoneyKindDiv107";

        /// <summary>手形(金種区分)</summary>
        public const string CT_Blnce_MoneyKindDiv105 = "MoneyKindDiv105";

        /// <summary>相殺(金種区分)</summary>
        public const string CT_Blnce_MoneyKindDiv106 = "MoneyKindDiv106";

        /// <summary>その他(金種区分)</summary>
        public const string CT_Blnce_MoneyKindDiv109 = "MoneyKindDiv109";

        /// <summary>口座振替(金種区分)</summary>
        public const string CT_Blnce_MoneyKindDiv112 = "MoneyKindDiv112";
        
        /// <summary>請求書出力区分コード</summary>
        public const string CT_Blnce_BillOutputCode = "BillOutputCode";
        
        /// <summary>領収書出力区分コード</summary>
        public const string CT_Blnce_ReceiptOutputCode = "ReceiptOutputCode";

        // --- ADD  大矢睦美  2010/02/01 ---------->>>>>
        /// <summary>請求書出力区分コード</summary>
        public const string CT_Blnce_TotalBillOutputDiv = "TotalBillOutputDiv";

        /// <summary>請求書出力区分コード</summary>
        public const string CT_Blnce_DetailBillOutputCode = "DetailBillOutputCode";

        /// <summary>請求書出力区分コード</summary>
        public const string CT_Blnce_SlipTtlBillOutputDiv = "SlipTtlBillOutputDiv";

        // --- ADD  大矢睦美  2010/02/01 ----------<<<<<
            
        //--------------------------------------------------
        //  その他項目(印刷用)
        //--------------------------------------------------
        /// <summary>計上日付(印刷用)</summary>
        public const string CT_SaleDepo_AddUpADatePrint = "AddUpADatePrint";

        /// <summary>印刷用順位(0:プレート番号ヘッダー用,1:それ以外)</summary>
        public const string CT_SaleDepo_PrintDetailHeaderOder = "PrintDetailHeaderOder";

        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
        /// <summary> 売上額(計税率1) </summary>
        public const string Col_TotalThisTimeSalesTaxRate1 = "TotalThisTimeSalesTaxRate1";

        /// <summary> 売上額(計税率2) </summary>
        public const string Col_TotalThisTimeSalesTaxRate2 = "TotalThisTimeSalesTaxRate2";

        /// <summary> 売上額(計その他) </summary>
        public const string Col_TotalThisTimeSalesOther = "TotalThisTimeSalesOther";

        /// <summary> 返品値引(計税率1) </summary>
        public const string Col_TotalThisRgdsDisPricTaxRate1 = "TotalThisRgdsDisPricTaxRate1";

        /// <summary> 返品値引(計税率2) </summary>
        public const string Col_TotalThisRgdsDisPricTaxRate2 = "TotalThisRgdsDisPricTaxRate2";

        /// <summary> 返品値引(計その他) </summary>
        public const string Col_TotalThisRgdsDisPricOther = "TotalThisRgdsDisPricOther";

        /// <summary> 純売上額(計税率1) </summary>
        public const string Col_TotalPureSalesTaxRate1 = "TotalPureSalesTaxRate1";

        /// <summary> 純売上額(計税率2) </summary>
        public const string Col_TotalPureSalesTaxRate2 = "TotalPureSalesTaxRate2";

        /// <summary> 純売上額(計その他) </summary>
        public const string Col_TotalPureSalesOther = "TotalPureSalesOther";

        /// <summary> 消費税(計税率1) </summary>
        public const string Col_TotalSalesPricTaxTaxRate1 = "TotalSalesPricTaxTaxRate1";

        /// <summary> 消費税(計税率2) </summary>
        public const string Col_TotalSalesPricTaxTaxRate2 = "TotalSalesPricTaxTaxRate2";

        /// <summary> 消費税(計その他) </summary>
        public const string Col_TotalSalesPricTaxOther = "TotalSalesPricTaxOther";

        /// <summary> 今回合計(計税率1) </summary>
        public const string Col_TotalThisSalesSumTaxRate1 = "TotalThisSalesSumTaxRate1";

        /// <summary> 今回合計(計税率2) </summary>
        public const string Col_TotalThisSalesSumTaxRate2 = "TotalThisSalesSumTaxRate2";

        /// <summary> 今回合計(計その他) </summary>
        public const string Col_TotalThisSalesSumTaxOther = "TotalThisSalesSumTaxOther";

        /// <summary> 枚数(計税率1) </summary>
        public const string Col_TotalSalesSlipCountTaxRate1 = "TotalSalesSlipCountTaxRate1";

        /// <summary> 枚数(計税率2) </summary>
        public const string Col_TotalSalesSlipCountTaxRate2 = "TotalSalesSlipCountTaxRate2";

        /// <summary> 枚数(計その他) </summary>
        public const string Col_TotalSalesSlipCountOther = "TotalSalesSlipCountOther";

        /// <summary> 税率1タイトル </summary>
        public const string Col_TitleTaxRate1 = "TitleTaxRate1";

        /// <summary> 税率2タイトル </summary>
        public const string Col_TitleTaxRate2 = "TitleTaxRate2";

        /// <summary> 軽減税率を対応するか判断専用(注意：他PG(Pクラス)で条件判断に使用) </summary>
        public const bool TaxReductionAccessDone = true;
        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
        //--- ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
        /// <summary> 売上額(計非課税) </summary>
        public const string Col_TotalThisTimeSalesTaxFree = "TotalThisTimeSalesTaxFree";

        /// <summary> 返品値引(計非課税) </summary>
        public const string Col_TotalThisRgdsDisPricTaxFree = "TotalThisRgdsDisPricTaxFree";

        /// <summary> 純売上額(計非課税) </summary>
        public const string Col_TotalPureSalesTaxFree = "TotalPureSalesTaxFree";

        /// <summary> 消費税(計非課税) </summary>
        public const string Col_TotalSalesPricTaxTaxFree = "TotalSalesPricTaxTaxFree";

        /// <summary> 今回合計(計非課税) </summary>
        public const string Col_TotalThisSalesSumTaxFree = "TotalThisSalesSumTaxFree";

        /// <summary> 枚数(計非課税) </summary>
        public const string Col_TotalSalesSlipCountTaxFree = "TotalSalesSlipCountTaxFree";
        //--- ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
        #endregion

        //================================================================================
        //  プライベート変数
        //================================================================================
        #region private member
        
        /// <summary>請求一覧（総括）データリモートオブジェクト</summary>
        private static ISumBillTableDB _iSumBillTableDB = null;

        /// <summary>拠点情報部品アクセスクラス</summary>
        private static SecInfoAcs mSecInfoAcs = null;

        /// <summary>全体初期値設定アクセスクラス</summary>
        private static AllDefSetAcs mAllDefSetAcs = null;

        /// <summary>請求印刷設定アクセスクラス</summary>
        private static BillPrtStAcs mBillPrtStAcs = null;

        /// <summary>税率設定アクセスクラス</summary>
        private static TaxRateSetAcs mTaxRateSetAcs = null;

        /// <summary>帳票出力設定アクセスクラス</summary>
        private static PrtOutSetAcs mPrtOutSetAcs = null;

        /// <summary>請求書印刷パターンマスタアクセスクラス</summary>
        private static DmdPrtPtnAcs _dmdPrtPtnAcs = null;

        /// <summary>全体項目表示設定のアクセスクラス</summary>
        private static AlItmDspNmAcs mAlItmDspNmAcs = null;
        private static AlItmDspNm _alItmDspNm = null;

        /// <summary>得意先マスタのアクセスクラス</summary>
        private static CustomerInfoAcs _customerInfoAcs = null;
        
        /// <summary>請求帳票データセット</summary>
        private DataSet _demandDataSet = null;

        /// <summary>請求金額データテーブル</summary>
        private DataTable _custDmdPrcDataTable = null;

        /// <summary>請求金額データビュー(画面用)</summary>
        private DataView _custDmdPrcDataView = null;

        /// <summary>請求金額データテーブル(印刷用)</summary>
        private DataTable _custDmdPrcPrintDataTable = null;

        /// <summary>請求金額データビュー(印刷用)</summary>
        private DataView _custDmdPrcDataViewPrint = null;

        /// <summary>拠点テーブル取得用</summary>
        private static Hashtable sectionTable = null;
        private static ArrayList secCodeList = null;

        /// <summary>請求印刷設定</summary>
        private static BillPrtSt _billPrtSt = null;

        /// <summary>自拠点コード</summary>
        private static string _ownSectionCd = "";

        /// <summary>拠点管理</summary>
        private static bool _sectionOption = false;

        /// <summary>税率設定リスト</summary>
        private static ArrayList _taxRateSetList = null;

        /// <summary>帳票出力設定データクラス</summary>
        private static PrtOutSet _prtOutSet = null;

        /// <summary>全体初期値設定データクラス</summary>
        private static AllDefSet _allDefSet = null;

        // 総括得意先コードリスト
        private List<int> _sumClaimCustCodeList;

        // 計算後請求金額のキャッシュ
        private Dictionary<string, long> afCalDemandPriceDic;

        private int _endDays = 0;       // 締日の月末

        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
        private bool _taxReductionDone = false;
        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<

        #endregion

        //================================================================================
        //  外部提供プロパティ
        //================================================================================
        #region public property
        /// <summary>
        /// 請求帳票抽出DataSet
        /// </summary>
        public DataSet DemandDataSet
        {
            get { return _demandDataSet; }
        }

        /// <summary>
        /// 得意先請求金額データテーブル
        /// </summary>
        public DataTable CustDmdPrcDataTable
        {
            get { return _custDmdPrcDataTable; }
        }

        /// <summary>
        /// 得意先請求金額データビュー(画面表示用)
        /// </summary>
        public DataView CustDmdPrcDataView
        {
            get { return _custDmdPrcDataView; }
        }

        /// <summary>
        /// 得意先請求金額データビュー(印刷用)
        /// </summary>
        public DataView CustDmdPrcDataViewPrint
        {
            get { return _custDmdPrcDataViewPrint; }
        }

        /// <summary>拠点情報リスト</summary>
        public Hashtable SectionTable
        {
            get { return sectionTable; }
        }

        /// <summary>拠点コードリスト</summary>
        public ArrayList SecCodeList
        {
            get { return secCodeList; }
        }

        /// <summary>請求印刷設定</summary>
        public BillPrtSt BillPrtStData
        {
            get { return _billPrtSt; }
        }

        /// <summary>全体初期値設定</summary>
        public AllDefSet AllDefSetData
        {
            get { return _allDefSet; }
        }

        /// <summary>拠点管理機能有無[true:有り,false:無し]</summary>
        public bool SectionOption
        {
            get { return _sectionOption; }
            set { _sectionOption = value; }
        }

        /// <summary>自拠点コード</summary>
        public string OwnSectionCd
        {
            get { return _ownSectionCd; }
            set { _ownSectionCd = value; }
        }

        #endregion

        //================================================================================
        //  コンストラクター
        //================================================================================
        #region コンストラクター
        /// <summary>
        /// 請求書発行(総括)抽出情報アクセスクラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : 請求書発行(総括)抽出情報アクセスクラスの新しいインスタンスを作成します。</br>
        /// <br></br>
        /// </remarks>
        public SumDemandPrintAcs()
        {
            SettingDataSet();
        }
        #endregion

        // ===============================================================================
        // 例外クラス
        // ===============================================================================
        #region 例外クラス
        private class DemandPrintException : ApplicationException
        {
            private int _status;

            #region constructor
            public DemandPrintException(string message, int status)
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

        //================================================================================
        //  静的コンストラクター
        //================================================================================
        #region 静的コンストラクター
        /// <summary>
        /// 請求書発行(総括)抽出情報アクセスクラス静的コンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : 請求書発行(総括)抽出情報アクセスクラスの新しいインスタンスを作成します。</br>
        /// <br></br>
        /// </remarks>
        static SumDemandPrintAcs()
        {
            // 拠点取得部品アクセスクラスインスタンス化
            mSecInfoAcs = new SecInfoAcs();

            // 請求印刷設定アクセスクラスインスタンス化
            mBillPrtStAcs = new BillPrtStAcs();

            // 税率設定アクセスクラスインスタンス化
            mTaxRateSetAcs = new TaxRateSetAcs();

            // 帳票出力設定アクセスクラスインスタンス化
            mPrtOutSetAcs = new PrtOutSetAcs();

            // 全体初期値設定アクセスクラスインスタンス化
            mAllDefSetAcs = new AllDefSetAcs();

            // 全体項目表示設定のアクセスクラスインスタンス化
            mAlItmDspNmAcs = new AlItmDspNmAcs();

            // 請求書印刷パターン設定マスタアクセスクラスインスタンス化
            _dmdPrtPtnAcs = new DmdPrtPtnAcs();

            // 得意先マスタのアクセスクラスインスタンス化
            _customerInfoAcs = new CustomerInfoAcs();

            sectionTable = new Hashtable();
            secCodeList = new ArrayList();

            // 請求一覧（総括）データリモートオブジェクト インスタンス化
            _iSumBillTableDB = (ISumBillTableDB)MediationSumBillTableDB.GetSumBillTableDB();
        }
        #endregion

        //================================================================================
        //  外部提供関数
        //================================================================================
        #region public methods
        /// <summary>
        /// 請求書発行(総括)データ初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出データを初期化します。</br>
        /// <br></br>
        /// </remarks>
        public void InitializeDemandData()
        {
            _custDmdPrcDataTable.Rows.Clear();
            _custDmdPrcPrintDataTable.Rows.Clear();

            // フィルタ条件初期化
            _custDmdPrcDataView.RowFilter = "";
            _custDmdPrcDataViewPrint.RowFilter = "";

            // 自動インクリメント列初期化
            DataColumn column = _custDmdPrcDataTable.Columns[CT_CsDmd_UniqueID];
            column.AutoIncrementSeed = 1;

            // キャッシュの初期化
            _sumClaimCustCodeList = new List<int>();
            afCalDemandPriceDic = new Dictionary<string, long>();
        }

        /// <summary>
        /// 請求印刷設定データ読込処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       :請求印刷設定データの読込を行います。</br>
        /// <br></br>
        /// </remarks>
        public int ReadBillPrtSt(string enterpriseCode, out string message)
        {
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // 請求印刷設定情報取得
                _billPrtSt = null;
                BillPrtSt billPrtSt;

                status = mBillPrtStAcs.Read(out billPrtSt, enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            _billPrtSt = billPrtSt;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            message = "請求印刷設定を行って下さい";
                            return status;
                        }
                    default:
                        message = "請求印刷設定の取得に失敗しました";
                        return status;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// 初期データ読込処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 初期データの読込を行います。</br>
        /// <br></br>
        /// </remarks>
        public int InitialDataRead(string enterpriseCode, out string message)
        {
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // 拠点情報取得
                sectionTable.Clear();
                secCodeList.Clear();

                ArrayList ar = new ArrayList();

                // 全社レコード追加判定
                SecInfoSet secAll = new SecInfoSet();
                secAll.SectionCode = CT_AllSectionCode;
                secAll.CompanyName1 = "全社";
                secAll.SectionGuideNm = "全社";

                sectionTable.Add(CT_AllSectionCode, secAll);
                secCodeList.Add(CT_AllSectionCode);

                for (int i = 0; i < mSecInfoAcs.SecInfoSetList.Length; i++)
                {
                    sectionTable.Add(mSecInfoAcs.SecInfoSetList[i].SectionCode, mSecInfoAcs.SecInfoSetList[i].Clone());
                    secCodeList.Add(mSecInfoAcs.SecInfoSetList[i].SectionCode);
                }
                secCodeList.Sort(new SecInfoKey0());


                // 全体初期値設置取得
                message = "全体初期値設定の読み込み";
                status = ReadAllDefSet(out _allDefSet, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // 全体項目表示設定 
                message = "全体項目表示設定の読み込み";
                status = mAlItmDspNmAcs.ReadStatic(out _alItmDspNm, enterpriseCode);
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
                message += "エラー " + "\n\r";
                message += ex.Message;
            }

            return status;
        }

        /// <summary>
        /// 税率設定データ取得
        /// </summary>
        /// <param name="taxRateSet">税率</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="taxRateCode">税率設定コード</param>
        /// <param name="date">売上日・発行日等（税率取得判定日付）</param>
        /// <returns>ConstantManagement.DB_Status ctDB_NORMAL:正常取得 ctDB_NOT_FOUND:取得データ無し　以外:通信エラー</returns>
        /// <remarks>
        /// <br>Note       : 税率設定を取得します。</br>
        /// <br></br>
        /// </remarks>
        public int ReadTaxRateSet(out double taxRate, out int consTaxLayMethod, string enterpriseCode, int taxRateCode, DateTime date)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            int lDate = 0;
            int lTaxRateStartDate = 0;
            int lTaxRateEndDate = 0;
            int lTaxRateStartDate2 = 0;
            int lTaxRateEndDate2 = 0;
            int lTaxRateStartDate3 = 0;
            int lTaxRateEndDate3 = 0;

            taxRate = 0;
            consTaxLayMethod = 0;

            if (_taxRateSetList == null)
            {
                // 税率設定取得
                status = mTaxRateSetAcs.Search(out _taxRateSetList, enterpriseCode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        return status;
                    default:
                        throw new DemandPrintException("税率設定の取得に失敗しました。", status);
                }
            }

            if (_taxRateSetList != null)
            {
                try
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    foreach (TaxRateSet ns in _taxRateSetList)
                    {
                        if (taxRateCode == ns.TaxRateCode)
                        {
                            consTaxLayMethod = ns.ConsTaxLayMethod;

                            lDate = TDateTime.DateTimeToLongDate("YYYYMMDD", date);
                            lTaxRateStartDate = TDateTime.DateTimeToLongDate("YYYYMMDD", ns.TaxRateStartDate);
                            lTaxRateEndDate = TDateTime.DateTimeToLongDate("YYYYMMDD", ns.TaxRateEndDate);
                            lTaxRateStartDate2 = TDateTime.DateTimeToLongDate("YYYYMMDD", ns.TaxRateStartDate2);
                            lTaxRateEndDate2 = TDateTime.DateTimeToLongDate("YYYYMMDD", ns.TaxRateEndDate2);
                            lTaxRateStartDate3 = TDateTime.DateTimeToLongDate("YYYYMMDD", ns.TaxRateStartDate3);
                            lTaxRateEndDate3 = TDateTime.DateTimeToLongDate("YYYYMMDD", ns.TaxRateEndDate3);

                            if ((lDate >= lTaxRateStartDate) && (lDate <= lTaxRateEndDate))
                            {
                                taxRate = ns.TaxRate;
                            }
                            else if ((lDate >= lTaxRateStartDate2) && (lDate <= lTaxRateEndDate2))
                            {
                                taxRate = ns.TaxRate2;
                            }
                            else if ((lDate >= lTaxRateStartDate3) && (lDate <= lTaxRateEndDate3))
                            {
                                taxRate = ns.TaxRate;
                            }

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            return status;
                        }
                    }
                    return status;
                }
                catch (DemandPrintException ex)
                {
                    status = ex.Status;
                }
                catch (Exception)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            return status;
        }

        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="prtOutSet">帳票出力設定データクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br></br>
        /// </remarks>
        public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            prtOutSet = null;
            message = "";
            try
            {
                // データは読込済みか？
                if (_prtOutSet != null)
                {
                    prtOutSet = _prtOutSet.Clone();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    string sectionCode = "";

                    if (LoginInfoAcquisition.Employee != null)
                    {
                        sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                    }

                    status = mPrtOutSetAcs.Read(out _prtOutSet, LoginInfoAcquisition.EnterpriseCode, sectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            prtOutSet = _prtOutSet.Clone();
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            prtOutSet = new PrtOutSet();
                            break;
                        default:
                            prtOutSet = new PrtOutSet();
                            message = "帳票出力設定の読込に失敗しました。";
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

        /// <summary>
        /// 全体初期値設定読込
        /// </summary>
        /// <param name="prtOutSet">帳票出力設定データクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の全体初期値設定の読込を行います。</br>
        /// <br></br>
        /// </remarks>
        public int ReadAllDefSet(out AllDefSet allDefSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            allDefSet = null;
            message = "";
            // --- ADD  大矢睦美  2010/02/01 ---------->>>>>
            AllDefSet allDefSetZero = null;
            // --- ADD  大矢睦美  2010/02/01 ----------<<<<<

            try
            {
                string sectionCode = "";

                if (LoginInfoAcquisition.Employee != null)
                {
                    sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                }

                ArrayList retList = new ArrayList();
                status = mAllDefSetAcs.Search(out retList, LoginInfoAcquisition.EnterpriseCode);
                
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        foreach (AllDefSet workAllDefSet in retList)
                        {
                            if (workAllDefSet.SectionCode == sectionCode)
                            {
                                // 同一拠点
                                allDefSet = workAllDefSet.Clone();
                                break;
                            }
                            // --- ADD  大矢睦美  2010/02/01 ---------->>>>>
                            if (workAllDefSet.SectionCode.Trim() == "00")
                            {
                                allDefSetZero = workAllDefSet;
                            }
                            // --- ADD  大矢睦美  2010/02/01 ----------<<<<<
                        }
                        if (allDefSet == null)
                        {
                            // --- UPD  大矢睦美  2010/02/01 ---------->>>>>
                            //// 同一拠点が無い場合はエラー                                
                            //allDefSet = new AllDefSet();
                            //message = "全体初期値設定が設定されていません。";
                            allDefSet = allDefSetZero;
                            // --- UPD  大矢睦美  2010/02/01 ----------<<<<<
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        allDefSet = new AllDefSet();
                        message = "全体初期値設定が設定されていません。";
                        break;
                    default:
                        allDefSet = new AllDefSet();
                        message = "全体初期値設定の読込に失敗しました。";
                        break;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }

        /// <summary>
        /// 制御機能拠点取得
        /// </summary>
        /// <param name="sectionCode">対象拠点コード</param>
        /// <param name="ctrlFuncCode">取得する制御機能コード</param>
        /// <param name="ctrlSectionCode">対象制御拠点コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 該当拠点の拠点制御情報の読込を行います。</br>
        /// <br></br>
        /// </remarks>
        public int GetOwnSeCtrlCode(string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode, out string ctrlSectionCode)
        {
            // 対象制御拠点の初期値は自拠点
            ctrlSectionCode = sectionCode;

            SecInfoSet secInfoSet;

            int status = mSecInfoAcs.GetSecInfo(sectionCode, out secInfoSet);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    if (secInfoSet != null)
                    {
                        ctrlSectionCode = secInfoSet.SectionCode;
                    }
                    break;
                default:
                    break;
            }
            return status;
        }

        /// <summary>
        /// 本社機能有無取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>true: 本社,false: 拠点</returns>
        /// <remarks>
        /// <br>Note       : 本社機能有無チェックを行います。</br>
        /// <br></br>
        /// </remarks>
        public bool CheckMainOfficeFunc(string sectionCode)
        {
            if (mSecInfoAcs.GetMainOfficeFuncFlag(sectionCode) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 自社名称取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="companyNameCd">自社名称コード</param>
        /// <param name="companyNm">自社名称</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 該当拠点の自社名称情報の取得を行います。</br>
        /// <br></br>
        /// </remarks>
        public int ReadCompanyName(string sectionCode, SecInfoAcs.CompanyNameCd companyNameCd, out CompanyNm companyNm)
        {
            SecInfoSet secInfoSet;
            int status = mSecInfoAcs.GetSecInfo(sectionCode, companyNameCd, out secInfoSet, out companyNm);

            return status;
        }

        /// <summary>
        /// 全体項目表示設定データクラス取得
        /// </summary>
        /// <returns>全体項目表示設定データクラス</returns>
        /// <remarks>
        /// <br>Note       : 全体項目表示設定データクラスの取得を行います。</br>
        /// <br></br>
        /// </remarks>
        public AlItmDspNm GetAlItmDspNm()
        {
            AlItmDspNm retAlItmDspNm = null;

            if (_alItmDspNm != null)
            {
                retAlItmDspNm = _alItmDspNm.Clone();
            }
            else
            {
                retAlItmDspNm = new AlItmDspNm();
            }

            return retAlItmDspNm;
        }

        /// <summary>
        /// 請求書発行(総括)抽出処理
        /// </summary>
        /// <param name="extraInfo">抽出条件データクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="errDspMsg">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 請求書発行(総括)情報を抽出します。</br>
        /// <br></br>
        /// </remarks>
        public int SearchDemandList(SumExtrInfo_DemandTotal extraInfo, out string message, out string errDspMsg)
        {
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errDspMsg = "";

            try
            {
                // DataSet初期化
                this.InitializeDemandData();

                ArrayList custDmdPrcList = new ArrayList();
                ArrayList dmdPrtPtnParamList = new ArrayList();
                
                // 抽出条件をワーカークラスへコピー
                SumExtrInfo_DemandTotalWork extraInfoWork = new SumExtrInfo_DemandTotalWork();
                extraInfoWork = this.CopyToExtraInfoWorkFromExtraInfo(extraInfo);

                object paraObj = null;
                object retObj = null;
                object paraAddObj = null;
                object retAddObj = null;

                paraObj = (object)extraInfoWork;

                status = _iSumBillTableDB.SearchBillTable(out retObj, paraObj);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // 締日の月末を取得
                            _endDays = DateTime.DaysInMonth(extraInfo.AddUpDate.Year, extraInfo.AddUpDate.Month);
                            
                            // --- UPD  大矢睦美  2010/02/01 ---------->>>>>                                                        
                            //retAddObj  = retObj;
                            retAddObj = (retObj as CustomSerializeArrayList)[0];
                            // --- UPD  大矢睦美  2010/02/01 ----------<<<<<
                            paraAddObj = (object)dmdPrtPtnParamList;

                            custDmdPrcList = retAddObj as ArrayList;

                            // --- ADD  大矢睦美  2010/02/01 ---------->>>>>
                            object AllDefSetObj = null;
                            AllDefSetObj = (retObj as CustomSerializeArrayList)[1];
                            ReadAllDefSetWork(AllDefSetObj as ArrayList);

                            paraAddObj = (object)dmdPrtPtnParamList;

                            custDmdPrcList = retAddObj as ArrayList;
                            // --- ADD  大矢睦美  2010/02/01 ----------<<<<<

                            // 請求金額DataTable作成
                            foreach (SumRsltInfo_DemandTotalWork csdmd in custDmdPrcList)
                            {
                                DataRow row = CustDmdPrcWorkToDataRow(extraInfo, csdmd);
                                if (row != null)
                                {
                                    // 抽出対象データ
                                    this._custDmdPrcDataTable.Rows.Add(row);
                                }
                            }

                            // 総括レコードの作成
                            CreateSumDmdRow(extraInfo);

                            // フィルター用の計算後請求金額を設定
                            SetAfCalDemandPriceFilter();

                            // 抽出対象データなし
                            if (_custDmdPrcDataTable.Rows.Count == 0) status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        message = "請求データの抽出に失敗しました";
                        break;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }

        // --- ADD  大矢睦美  2010/02/01 ---------->>>>>
        /// <summary>
        /// 全体初期値設定の内容を更新
        /// </summary>
        /// <param name="arrayList"></param>
        private void ReadAllDefSetWork(ArrayList arrayList)
        {
            AllDefSetWork allDefSetWork = null;
            AllDefSetWork allDefSetWorkZero = null;

            string sectionCode = "";

            if (LoginInfoAcquisition.Employee != null)
            {
                sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }

            foreach (AllDefSetWork workAllDefSet in arrayList)
            {
                if (workAllDefSet.SectionCode == sectionCode)
                {
                    //同一拠点
                    allDefSetWork = workAllDefSet;
                    break;
                }
            
                if (workAllDefSet.SectionCode.Trim() == "00")
                {
                    allDefSetWorkZero = workAllDefSet;
                }
            }
            if (allDefSetWork == null)
            {
                allDefSetWork = allDefSetWorkZero;
            }
            if (allDefSetWork != null)
            {
                _allDefSet = CopyToAllDefSetFromAllDefSetWork(allDefSetWork);
            }
        }

        /// <summary>
        /// 全体初期値設定マスタを取得
        /// </summary>
        /// <param name="allDefSetWork"></param>
        /// <returns></returns>
        private AllDefSet CopyToAllDefSetFromAllDefSetWork(AllDefSetWork allDefSetWork)
        {
            AllDefSet allDefSet = new AllDefSet();

            allDefSet.CreateDateTime = allDefSetWork.CreateDateTime;  // 作成日時
            allDefSet.UpdateDateTime = allDefSetWork.UpdateDateTime;  // 更新日時
            allDefSet.EnterpriseCode = allDefSetWork.EnterpriseCode;  // 企業コード
            allDefSet.FileHeaderGuid = allDefSetWork.FileHeaderGuid;  // GUID
            allDefSet.UpdEmployeeCode = allDefSetWork.UpdEmployeeCode;  // 更新従業員コード
            allDefSet.UpdAssemblyId1 = allDefSetWork.UpdAssemblyId1;  // 更新アセンブリID1
            allDefSet.UpdAssemblyId2 = allDefSetWork.UpdAssemblyId2;  // 更新アセンブリID2
            allDefSet.LogicalDeleteCode = allDefSetWork.LogicalDeleteCode;  // 論理削除区分
            allDefSet.SectionCode = allDefSetWork.SectionCode;  // 拠点コード
            allDefSet.TotalAmountDispWayCd = allDefSetWork.TotalAmountDispWayCd;  // 総額表示方法区分
            allDefSet.DefDspCustTtlDay = allDefSetWork.DefDspCustTtlDay;  // 初期表示顧客締日
            allDefSet.DefDspCustClctMnyDay = allDefSetWork.DefDspCustClctMnyDay;  // 初期表示顧客集金日
            allDefSet.DefDspClctMnyMonthCd = allDefSetWork.DefDspClctMnyMonthCd;  // 初期表示集金月区分
            allDefSet.IniDspPrslOrCorpCd = allDefSetWork.IniDspPrslOrCorpCd;  // 初期表示個人・法人区分
            allDefSet.InitDspDmDiv = allDefSetWork.InitDspDmDiv;  // 初期表示DM区分
            allDefSet.DefDspBillPrtDivCd = allDefSetWork.DefDspBillPrtDivCd;  // 初期表示請求書出力区分
            allDefSet.EraNameDispCd1 = allDefSetWork.EraNameDispCd1;  // 元号表示区分１
            allDefSet.EraNameDispCd2 = allDefSetWork.EraNameDispCd2;  // 元号表示区分２
            allDefSet.EraNameDispCd3 = allDefSetWork.EraNameDispCd3;  // 元号表示区分３
            allDefSet.GoodsNoInpDiv = allDefSetWork.GoodsNoInpDiv;  // 商品番号入力区分
            allDefSet.CnsTaxAutoCorrDiv = allDefSetWork.CnsTaxAutoCorrDiv;  // 消費税自動補正区分
            allDefSet.RemainCntMngDiv = allDefSetWork.RemainCntMngDiv;  // 残数管理区分
            allDefSet.MemoMoveDiv = allDefSetWork.MemoMoveDiv;  // メモ複写区分
            allDefSet.RemCntAutoDspDiv = allDefSetWork.RemCntAutoDspDiv;  // 残数自動表示区分
            allDefSet.TtlAmntDspRateDivCd = allDefSetWork.TtlAmntDspRateDivCd;  // 総額表示掛率適用区分
            allDefSet.DefTtlBillOutput = allDefSetWork.DefTtlBillOutput;  // 初期表示合計請求書出力区分
            allDefSet.DefDtlBillOutput = allDefSetWork.DefDtlBillOutput;  // 初期表示明細請求書出力区分
            allDefSet.DefSlTtlBillOutput = allDefSetWork.DefSlTtlBillOutput;  // 初期表示伝票合計請求書出力区分

            return allDefSet;
        }
        // --- ADD  大矢睦美  2010/02/01 ----------<<<<<
    

        /// <summary>
        /// 選択行印字選択・非選択状態処理
        /// </summary>
        /// <param name="_uniqueID">ユニークID</param>
        /// <remarks>
        /// <br>Note       : 選択行の印字状態を設定します。</br>
        /// <br></br>
        /// </remarks>
        public void SelectedPrintRow(int _uniqueID)
        {
            // ------------------------------------------------------------//
            // Find メソッドを使う但し、Viewのソート順を変更したくない為、 //
            // DataTableに更新をかける。                                   //
            // ------------------------------------------------------------//
            DataRow _row = _custDmdPrcDataTable.Rows.Find(_uniqueID);

            // 一致する行が存在する！
            if (_row != null)
            {
                bool printFlag = (bool)_row[CT_CsDmd_PrintFlag];

                _row.BeginEdit();
                _row[CT_CsDmd_PrintFlag] = !printFlag;
                _row.EndEdit();
            }
        }

        /// <summary>
        /// 選択行印字選択・非選択状態処理(指定型)
        /// </summary>
        /// <param name="_uniqueID">ユニークID</param>
        /// <param name="selected">true:選択,false:非選択</param>
        /// <remarks>
        /// <br>Note       : 選択行の印字状態を設定します。</br>
        /// <br></br>
        /// </remarks>
        public void SelectedPrintRow(int _uniqueID, bool selected)
        {
            // ------------------------------------------------------------//
            // Find メソッドを使う但し、Viewのソート順を変更したくない為、 //
            // DataTableに更新をかける。                                   //
            // ------------------------------------------------------------//
            DataRow _row = _custDmdPrcDataTable.Rows.Find(_uniqueID);

            // 一致する行が存在する！
            if (_row != null)
            {
                _row.BeginEdit();
                _row[CT_CsDmd_PrintFlag] = selected;
                _row.EndEdit();
            }
        }

        /// <summary>
        /// 抽出データ表示用DataView　フィルタ設定
        /// </summary>
        /// <param name="outPutDiv">出力区分</param>
        /// <param name="sumCustDtl">総括得意先内訳</param>
        /// <remarks>
        /// <br>Note       : 抽出データにフィルタを設定します。</br>
        /// <br></br>
        /// </remarks>
        // --- UPD  大矢睦美  2010/02/01 ---------->>>>>
        //public void SelectViewData(int outPutDiv, int sumCustDtl)
        public void SelectViewData(int outPutDiv, int sumCustDtl, int issueType)
        // --- UPD  大矢睦美  2010/02/01 ----------<<<<<
        {
            string strQuery = "";
            string strQuery1 = "";
            // --- ADD  大矢睦美  2010/02/01 ---------->>>>>
            string strQuery2 = "";
            // --- ADD  大矢睦美  2010/02/01 ----------<<<<<

            // 計算後請求金額(フィルター用)でフィルター条件作成
            //if (sumCustDtl != 2)
            //{
                switch (outPutDiv)
                {
                    case 0: // 全て出力 
                        break;
                    case 1: // ０とプラス金額を出力
                        strQuery = String.Format("{0} >= {1}",
                            CT_CsDmd_AfCalDemandPriceFilter,
                            0);
                        break;
                    case 2: // プラス金額のみ出力
                        strQuery = String.Format("{0} > {1}",
                            CT_CsDmd_AfCalDemandPriceFilter,
                            0);
                        break;
                    case 3: // ０のみ出力
                        strQuery = String.Format("{0} = {1}",
                            CT_CsDmd_AfCalDemandPriceFilter,
                            0);
                        break;
                    case 4: // プラス金額とマイナス金額を出力
                        strQuery = String.Format("{0} <> {1}",
                            CT_CsDmd_AfCalDemandPriceFilter,
                            0);
                        break;
                    case 5: // ０とマイナス金額を出力
                        strQuery = String.Format("{0} <= {1}",
                            CT_CsDmd_AfCalDemandPriceFilter,
                            0);
                        break;
                    case 6: // マイナス金額のみ出力
                        strQuery = String.Format("{0} < {1}",
                            CT_CsDmd_AfCalDemandPriceFilter,
                            0);
                        break;
                    default:
                        break;
                }
            //}
            
            if (sumCustDtl == 1)  //  総括得意先内訳→印字しない
            {
                if (outPutDiv == 0)
                {
                    strQuery = String.Format("{0} = {1}",
                    CT_CsDmd_DataType,
                    true);
                }
                else
                {
                    strQuery1 = String.Format(" AND {0} = {1}",
                    CT_CsDmd_DataType,
                    true);
                }
            }

            // --- UPD  大矢睦美  2010/02/01 ---------->>>>>
            switch (issueType)
            {                
                //合計請求書
                case 50:
                    {
                        strQuery2 = string.Empty;
                        if (!string.IsNullOrEmpty(strQuery) || !string.IsNullOrEmpty(strQuery1))
                        {
                            strQuery2 = " AND ";
                        }
                            //全体初期値設定「出力する」
                            if (AllDefSetData.DefTtlBillOutput == 0)
                            {
                                //得意先マスタ「標準」または「使用」
                                strQuery2 += string.Format("{0} <> {1}",
                                CT_Blnce_TotalBillOutputDiv,
                                2);
                            }
                            //全体初期値設定「出力しない」
                            else if(AllDefSetData.DefTtlBillOutput == 1)
                            {
                                //得意先マスタ「使用」
                                strQuery2 += string.Format("{0} = {1}",
                                CT_Blnce_TotalBillOutputDiv,
                                1);
                            }
                            break;
                    }
                //明細請求書                
                case 60:
                    {
                        //
                        strQuery2 = string.Empty;
                        if (!string.IsNullOrEmpty(strQuery) || !string.IsNullOrEmpty(strQuery1))
                        {
                            strQuery2 = " AND ";
                        }
                        //全体初期値設定「出力する」
                        if (AllDefSetData.DefDtlBillOutput == 0)
                        {
                            //得意先マスタ「標準」または「使用」
                            strQuery2 += string.Format("{0} <> {1}",
                            CT_Blnce_DetailBillOutputCode,
                            2);
                        }
                        //全体初期値設定「出力しない」
                        else if (AllDefSetData.DefDtlBillOutput == 1)
                        {
                            //得意先マスタ「使用」
                            strQuery2 += string.Format("{0} = {1}",
                            CT_Blnce_DetailBillOutputCode,
                            1);
                        }
                        break;
                    }                    
                //伝票合計請求書
                case 70:
                    {
                        strQuery2 = string.Empty;
                        if (!string.IsNullOrEmpty(strQuery) || !string.IsNullOrEmpty(strQuery1))
                        {
                            strQuery2 = " AND ";
                        }
                            //全体初期値設定「出力する」
                            if (AllDefSetData.DefSlTtlBillOutput == 0)
                            {
                                //得意先マスタ「標準」または「使用」
                                strQuery2 += string.Format("{0} <> {1}",
                                CT_Blnce_SlipTtlBillOutputDiv,
                                2);
                            }
                            //全体初期値設定「出力しない」
                            else if (AllDefSetData.DefSlTtlBillOutput == 1)
                            {
                                //得意先マスタ「使用」
                                strQuery2 += string.Format("{0} = {1}",
                                CT_Blnce_SlipTtlBillOutputDiv,
                                1);
                            }
                            break;
                    }
            }
                    
            // クエリ設定
            //_custDmdPrcDataView.RowFilter = strQuery + strQuery1;
            _custDmdPrcDataView.RowFilter = strQuery + strQuery1 + strQuery2;
            // --- UPD  大矢睦美  2010/02/01 ----------<<<<<
        }

        /// <summary>
        /// 印刷用データテーブル作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 印刷用データテーブルを作成します。</br>
        /// <br></br>
        /// </remarks>
        public int MakePrintDataTable()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 印刷インデックス
            int printOder = 0;

            // 印刷用DataTable初期化
            _custDmdPrcPrintDataTable.Rows.Clear();
            _custDmdPrcDataViewPrint.RowFilter = "";

            // 表示用DataViewから印刷用DataTableに設定
            if (_custDmdPrcDataView.Count != 0)
            {
                for (int i = 0; i < _custDmdPrcDataView.Count; i++)
                {
                    DataRow row = _custDmdPrcDataView[i].Row;

                    // 印刷有無					
                    if ((bool)row[CT_CsDmd_PrintFlag])
                    {
                        printOder++;
                        row.BeginEdit();
                        // 印刷用インデックス付加
                        row[CT_CsDmd_PrintIndex] = printOder;
                        row.EndEdit();
                        // 行を追加					
                        _custDmdPrcPrintDataTable.ImportRow(row);
                    }
                }
            }

            if (_custDmdPrcPrintDataTable.Rows.Count > 0)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }

        /// <summary>
        /// 印刷用データテーブル作成処理(印刷一時中断枚数設定)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 印刷用データテーブルを作成します。</br>
        /// <br></br>
        /// </remarks>
        public int MakePrintDataTable(int pcardPrtSuspendcnt, SumExtrInfo_DemandTotal extrInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 印刷インデックス
            int printOder = 0;

            // 印刷用DataTable初期化
            _custDmdPrcPrintDataTable.Rows.Clear();
            _custDmdPrcDataViewPrint.RowFilter = "";

            string strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_SumClaimCustCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_ClaimCode;
            if (extrInfo.SortOrder == 1)
            {
                // 担当者順
                if (extrInfo.CustomerAgentDivCd == 0)
                {
                    // 顧客担当
                    strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_CustomerAgentCd + "," + CT_CsDmd_SumClaimCustCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_ClaimCode;
                }
                else
                {
                    // 集金担当
                    strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_BillCollecterCd + "," + CT_CsDmd_SumClaimCustCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_ClaimCode;
                }
            }
            else if (extrInfo.SortOrder == 2)
            {
                // 地区順
                strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_SalesAreaCode + "," + CT_CsDmd_SumClaimCustCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_ClaimCode;
            }

            // --- ADD  大矢睦美  2010/02/24 ---------->>>>>
            ////
            //string rowFilter = "";
            //if (_custDmdPrcDataView.RowFilter != "")
            //{
            //    rowFilter = _custDmdPrcDataView.RowFilter;
            //}
            // Filter設定
            string rowFilter = "";
            if (_custDmdPrcDataView.RowFilter != "")
            {
                rowFilter = _custDmdPrcDataView.RowFilter;
            }
            // --- ADD  大矢睦美  2010/02/24 ----------<<<<<

            // --- UPD  大矢睦美  2010/02/24 ---------->>>>>                       
            // ワーク用のDataView
            //DataView workDataView = new DataView(_custDmdPrcDataTable, _custDmdPrcDataTable.DefaultView.RowFilter, strSort, DataViewRowState.CurrentRows);            
            DataView workDataView = new DataView(_custDmdPrcDataTable, rowFilter, strSort, DataViewRowState.CurrentRows);
            // --- UPD  大矢睦美  2010/02/24 ----------<<<<<

            // 表示用DataViewから印刷用DataTableに設定
            if (workDataView.Count != 0)
            {
                //for (int i = 0; i < _custDmdPrcDataView.Count; i++)
                for (int i = 0; i < workDataView.Count; i++)
                {
                    DataRow row = workDataView[i].Row;

                    switch (extrInfo.SlipPrtKind)
                    {
                        // --- UPD  大矢睦美  2010/02/01 ---------->>>>>
                        //合計請求書
                        case 50:
                            {
                                //得意先マスタの区分「0：標準」
                                if ((int)row[CT_Blnce_TotalBillOutputDiv] == 0)
                                {
                                    //全体初期値設定マスタの区分「1：出力しない」
                                    if (AllDefSetData.DefTtlBillOutput == 1)
                                    {
                                        //印刷しない
                                        continue;
                                    }
                                }
                                //得意先マスタの区分「2：未使用」
                                else if ((int)row[CT_Blnce_TotalBillOutputDiv] == 2)
                                {
                                    //印刷しない
                                    continue;
                                }
                                break;
                            }
                        //明細請求書                       
                        case 60:
                            {
                                //得意先マスタの区分「0:標準」
                                if ((int)row[CT_Blnce_DetailBillOutputCode] == 0)
                                {
                                    //全体初期値設定マスタの区分「1:出力しない」
                                    if (AllDefSetData.DefDtlBillOutput == 1)
                                    {
                                        //印刷しない
                                        continue;
                                    }
                                }
                                //得意先マスタの区分「2:未使用」
                                else if ((int)row[CT_Blnce_DetailBillOutputCode] == 2)
                                {
                                    //印刷しない
                                    continue;
                                }
                                break;
                            }                            
                        //伝票合計請求書
                        case 70:
                            {
                                //得意先マスタの区分「0：標準」
                                if ((int)row[CT_Blnce_SlipTtlBillOutputDiv] == 0)
                                {
                                    //全体初期値設定マスタの区分「2：出力しない」
                                    if (AllDefSetData.DefSlTtlBillOutput == 1)
                                    {
                                        //印刷しない
                                        continue;
                                    }
                                }
                                //得意先マスタの区分「2：未使用」
                                else if ((int)row[CT_Blnce_SlipTtlBillOutputDiv] == 2)
                                {
                                    //印刷しない
                                    continue;
                                }
                                break;

                                //// 請求書関係
                                //if ((int)row[CT_Blnce_BillOutputCode] == 1)
                                //{
                                //    // 印刷しない
                                //    continue;
                                //}
                                //break;
                            }
                        // --- UPD  大矢睦美  2010/02/01 ----------<<<<<
                    }
                    
                    // 印刷有無					
                    if ((bool)row[CT_CsDmd_PrintFlag])
                    {
                        printOder++;
                        row.BeginEdit();
                        // 印刷用インデックス付加
                        row[CT_CsDmd_PrintIndex] = printOder;
                        row.EndEdit();
                        // 行を追加					
                        _custDmdPrcPrintDataTable.ImportRow(row);
                    }

                    // 印刷一時中断枚数
                    if ((pcardPrtSuspendcnt != 0) && (printOder >= pcardPrtSuspendcnt))
                    {
                        break;
                    }
                }
            }
            _custDmdPrcDataViewPrint.Sort = strSort;
            
            if (_custDmdPrcPrintDataTable.Rows.Count > 0)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }

        #endregion

        //================================================================================
        //  内部関数
        //================================================================================
        #region private methods
        /// <summary>
        /// データセット、データテーブル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private void SettingDataSet()
        {

            if (_demandDataSet == null)
            {
                _demandDataSet = new DataSet(CT_DemandDataSet);

                CreateCustDmdPrTable();
            }
        }
        /// <summary>
        /// 得意先請求金額テーブル情報作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Update Note: 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private void CreateCustDmdPrTable()
        {
            //　得意先請求金額DataTable作成
            _custDmdPrcDataTable = new DataTable(CT_CustDmdPrcDataTable);
            _custDmdPrcDataView  = new DataView();

            _custDmdPrcPrintDataTable = new DataTable(CT_CustDmdPrcDataTable);
            _custDmdPrcDataViewPrint  = new DataView();

            // ユニークID(自動インクリメント列)
            DataColumn UniqueID = new DataColumn(CT_CsDmd_UniqueID, typeof(System.Int32), "", MappingType.Element);
            UniqueID.Caption = "ユニークID";
            UniqueID.AutoIncrement = true;
            UniqueID.AutoIncrementSeed = 1;
            UniqueID.AutoIncrementStep = 1;
            UniqueID.ReadOnly = true;

            // レコードタイプ
            DataColumn DataType = new DataColumn(CT_CsDmd_DataType, typeof(Boolean), "", MappingType.Element);
            DataType.Caption = "レコードタイプ";

            // レコード名
            DataColumn RecordName = new DataColumn(CT_CsDmd_RecordName, typeof(String), "", MappingType.Element);
            DataType.Caption = "レコード名";
            
            // 印刷フラグ
            DataColumn PrintFlag = new DataColumn(CT_CsDmd_PrintFlag, typeof(Boolean), "", MappingType.Element);
            PrintFlag.Caption = "印刷フラグ";

            // 印刷用インデックス
            DataColumn PrintIndex = new DataColumn(CT_CsDmd_PrintIndex, typeof(System.Int32), "", MappingType.Element);
            PrintIndex.Caption = "印刷用インデックス";

            // 計上拠点コード
            DataColumn AddUpSecCode = new DataColumn(CT_CsDmd_AddUpSecCode, typeof(String), "", MappingType.Element);
            AddUpSecCode.Caption = "計上拠点コード";

            // 計上拠点名称
            DataColumn AddUpSecName = new DataColumn(CT_CsDmd_AddUpSecName, typeof(String), "", MappingType.Element);
            AddUpSecName.Caption = "請求拠点名";
            
            // 請求拠点コード
            DataColumn ClaimSectionCode = new DataColumn(CT_CsDmd_ClaimSectionCode, typeof(String), "", MappingType.Element);
            ClaimSectionCode.Caption = "請求拠点コード";

            // 請求拠点名称
            DataColumn ClaimSectionName = new DataColumn(CT_CsDmd_ClaimSectionName, typeof(String), "", MappingType.Element);
            ClaimSectionName.Caption = "請求拠点名称";
            
            // 実績拠点コード
            DataColumn ResultsSectCd = new DataColumn(CT_CsDmd_ResultsSectCd, typeof(String), "", MappingType.Element);
            ResultsSectCd.Caption = "実績拠点コード";
            
            // 総括得意先コード
            DataColumn SumClaimCustCode = new DataColumn(CT_CsDmd_SumClaimCustCode, typeof(System.Int32), "", MappingType.Element);
            SumClaimCustCode.Caption = "総括得意先コード";

            // 総括得意先コード(抽出結果表示用)
            DataColumn SumClaimCustCodeDisp = new DataColumn(CT_CsDmd_SumClaimCustCodeDisp, typeof(System.String), "", MappingType.Element);
            SumClaimCustCodeDisp.Caption = "総括得意先コード";

            // 総括得意先略称
            DataColumn SumClaimCustSnm = new DataColumn(CT_CsDmd_SumClaimCustSnm, typeof(String), "", MappingType.Element);
            SumClaimCustSnm.Caption = "総括得意先略称";

            // 請求先コード
            DataColumn ClaimCode = new DataColumn(CT_CsDmd_ClaimCode, typeof(System.Int32), "", MappingType.Element);
            ClaimCode.Caption = "請求先コード";

            // 請求先コード(抽出結果表示用)
            DataColumn ClaimCodeDisp = new DataColumn(CT_CsDmd_ClaimCodeDisp, typeof(String), "", MappingType.Element);
            ClaimCodeDisp.Caption = "請求先コード";
            
            // 請求先名称
            DataColumn ClaimName = new DataColumn(CT_CsDmd_ClaimName, typeof(String), "", MappingType.Element);
            ClaimName.Caption = "請求先名称";

            // 請求先名称2
            DataColumn ClaimName2 = new DataColumn(CT_CsDmd_ClaimName2, typeof(String), "", MappingType.Element);
            ClaimName2.Caption = "請求先名称２";

            // 請求先略称
            DataColumn ClaimSnm = new DataColumn(CT_CsDmd_ClaimSnm, typeof(String), "", MappingType.Element);
            ClaimSnm.Caption = "請求先略称";

            // 得意先コード
            DataColumn CustomerCode = new DataColumn(CT_CsDmd_CustomerCode, typeof(System.Int32), "", MappingType.Element);
            CustomerCode.Caption = "得意先コード";

            // 得意先名称
            DataColumn CustomerName = new DataColumn(CT_CsDmd_CustomerName, typeof(String), "", MappingType.Element);
            CustomerName.Caption = "得意先名称";

            // 得意先名称2
            DataColumn CustomerName2 = new DataColumn(CT_CsDmd_CustomerName2, typeof(String), "", MappingType.Element);
            CustomerName2.Caption = "得意先名称２";

            // 得意先略称
            DataColumn CustomerSnm = new DataColumn(CT_CsDmd_CustomerSnm, typeof(String), "", MappingType.Element);
            CustomerSnm.Caption = "得意先略称";

            // 計上年月日
            DataColumn AddUpDate = new DataColumn(CT_CsDmd_AddUpDate, typeof(System.DateTime), "", MappingType.Element);
            AddUpDate.Caption = "計上年月日";

            // 計上年月日(Int型)
            DataColumn AddUpDateInt = new DataColumn(CT_CsDmd_AddUpDateInt, typeof(System.Int32), "", MappingType.Element);
            AddUpDateInt.Caption = "計上年月日";

            // 計上年月
            DataColumn AddUpYearMonth = new DataColumn(CT_CsDmd_AddUpYearMonth, typeof(System.DateTime), "", MappingType.Element);
            AddUpYearMonth.Caption = "計上年月";

            // 前回請求額
            DataColumn LastTimeDemand = new DataColumn(CT_CsDmd_LastTimeDemand, typeof(System.Int64), "", MappingType.Element);
            LastTimeDemand.Caption = "前回請求額";

            // 今回入金金額（通常入金）
            DataColumn ThisTimeDmdNrml = new DataColumn(CT_CsDmd_ThisTimeDmdNrml, typeof(System.Int64), "", MappingType.Element);
            ThisTimeDmdNrml.Caption = "今回入金金額（通常入金）";

            // 今回手数料額（通常入金）
            DataColumn ThisTimeFeeDmdNrml = new DataColumn(CT_CsDmd_ThisTimeFeeDmdNrml, typeof(System.Int64), "", MappingType.Element);
            ThisTimeFeeDmdNrml.Caption = "今回手数料額（通常入金）";

            // 今回値引額（通常入金）
            DataColumn ThisTimeDisDmdNrml = new DataColumn(CT_CsDmd_ThisTimeDisDmdNrml, typeof(System.Int64), "", MappingType.Element);
            ThisTimeDisDmdNrml.Caption = "今回値引額（通常入金）";

            // 今回繰越残高（請求計）[今回繰越残高＝前回請求額－入金額（請求計）]
            DataColumn ThisTimeTtlBlcDmd = new DataColumn(CT_CsDmd_ThisTimeTtlBlcDmd, typeof(System.Int64), "", MappingType.Element);
            ThisTimeTtlBlcDmd.Caption = "今回繰越残高（請求計）";

            // 相殺後今回売上金額
            DataColumn OfsThisTimeSales = new DataColumn(CT_CsDmd_OfsThisTimeSales, typeof(System.Int64), "", MappingType.Element);
            OfsThisTimeSales.Caption = "相殺後今回売上金額";

            // 相殺後今回売上消費税
            DataColumn OfsThisSalesTax = new DataColumn(CT_CsDmd_OfsThisSalesTax, typeof(System.Int64), "", MappingType.Element);
            OfsThisSalesTax.Caption = "相殺後今回売上消費税";

            // 相殺後今回合計売上金額
            DataColumn OfsThisSalesSum = new DataColumn(CT_CsDmd_OfsThisSalesSum, typeof(System.Int64), "", MappingType.Element);
            OfsThisSalesSum.Caption = "相殺後今回合計売上金額";

            // 今回売上金額
            DataColumn ThisTimeSales = new DataColumn(CT_CsDmd_ThisTimeSales, typeof(System.Int64), "", MappingType.Element);
            ThisTimeSales.Caption = "今回売上金額";

            // 今回売上返品金額
            DataColumn ThisSalesPricRgds = new DataColumn(CT_CsDmd_ThisSalesPricRgds, typeof(System.Int64), "", MappingType.Element);
            ThisSalesPricRgds.Caption = "今回売上返品金額";

            // 今回売上値引金額
            DataColumn ThisSalesPricDis = new DataColumn(CT_CsDmd_ThisSalesPricDis, typeof(System.Int64), "", MappingType.Element);
            ThisSalesPricDis.Caption = "今回売上値引金額";

            // 今回売上返品・値引金額
            DataColumn ThisSalesPricRgdsDis = new DataColumn(CT_CsDmd_ThisSalesPricRgdsDis, typeof(System.Int64), "", MappingType.Element);
            ThisSalesPricRgdsDis.Caption = "今回売上返品・値引金額";

            // 残高調整額
            DataColumn BalanceAdjust = new DataColumn(CT_CsDmd_BalanceAdjust, typeof(System.Int64), "", MappingType.Element);
            BalanceAdjust.Caption = "残高調整額";

            // 計算後請求金額
            DataColumn AfCalDemandPrice = new DataColumn(CT_CsDmd_AfCalDemandPrice, typeof(System.Int64), "", MappingType.Element);
            AfCalDemandPrice.Caption = "計算後請求金額";

            // 計算後請求金額(フィルター用)
            DataColumn AfCalDemandPriceFilter = new DataColumn(CT_CsDmd_AfCalDemandPriceFilter, typeof(System.Int64), "", MappingType.Element);
            AfCalDemandPriceFilter.Caption = "計算後請求金額(フィルター用)";
            
            // 売上伝票枚数
            DataColumn SaleslSlipCount = new DataColumn(CT_CsDmd_SaleslSlipCount, typeof(System.Int32), "", MappingType.Element);
            SaleslSlipCount.Caption = "売上伝票枚数";

            // 端数処理区分
            DataColumn FractionProcCd = new DataColumn(CT_CsDmd_FractionProcCd, typeof(System.Int32), "", MappingType.Element);
            FractionProcCd.Caption = "端数処理区分";

            // 相殺後今回売上消費税(印刷用)
            DataColumn PrintTtlConsTaxDmd = new DataColumn(CT_CsDmd_PrintTtlConsTaxDmd, typeof(String), "", MappingType.Element);
            PrintTtlConsTaxDmd.Caption = "相殺後今回売上消費税";
            
            // ****************
            // 得意先情報
            // ****************
            // 締日
            DataColumn TotalDay = new DataColumn(CT_CsDmd_TotalDay, typeof(System.Int32), "", MappingType.Element);
            TotalDay.Caption = "締日";

            // 締日(印刷用)
            DataColumn PrintTotalDay = new DataColumn(CT_CsDmd_PrintTotalDay, typeof(String), "", MappingType.Element);
            PrintTotalDay.Caption = "締日";

            // 集金月区分名称
            DataColumn CollectMoneyName = new DataColumn(CT_CsDmd_CollectMoneyName, typeof(String), "", MappingType.Element);
            CollectMoneyName.Caption = "集金月区分名称";

            // 集金日
            DataColumn CollectMoneyDay = new DataColumn(CT_CsDmd_CollectMoneyDay, typeof(System.Int32), "", MappingType.Element);
            CollectMoneyDay.Caption = "集金日";

            // 集金日(印刷用)
            DataColumn CollectMoneyDayNm = new DataColumn(CT_CsDmd_CollectMoneyDayNm, typeof(String), "", MappingType.Element);
            CollectMoneyDayNm.Caption = "集金日(印刷用)";

            // 顧客担当従業員コード
            DataColumn CustomerAgentCd = new DataColumn(CT_CsDmd_CustomerAgentCd, typeof(String), "", MappingType.Element);
            CustomerAgentCd.Caption = "顧客担当従業員コード";

            // 顧客担当従業員名称
            DataColumn CustomerAgentNm = new DataColumn(CT_CsDmd_CustomerAgentNm, typeof(String), "", MappingType.Element);
            CustomerAgentNm.Caption = "顧客担当従業員名称";

            // 集金担当従業員コード
            DataColumn BillCollecterCd = new DataColumn(CT_CsDmd_BillCollecterCd, typeof(String), "", MappingType.Element);
            BillCollecterCd.Caption = "集金担当従業員コード";

            // 集金担当従業員名称
            DataColumn BillCollecterNm = new DataColumn(CT_CsDmd_BillCollecterNm, typeof(String), "", MappingType.Element);
            BillCollecterNm.Caption = "集金担当従業員名称";

            // 印刷用従業員コード
            DataColumn EmployeeCd = new DataColumn(CT_CsDmd_EmployeeCd, typeof(String), "", MappingType.Element);
            EmployeeCd.Caption = "印刷用従業員コード";

            // 印刷用従業員名称
            DataColumn EmployeeNm = new DataColumn(CT_CsDmd_EmployeeNm, typeof(String), "", MappingType.Element);
            EmployeeNm.Caption = "印刷用従業員名称";

            // 総額表示区分
            DataColumn TotalAmountDispWayCd = new DataColumn(CT_CsDmd_TotalAmountDispWayCd, typeof(Int32), "", MappingType.Element);
            TotalAmountDispWayCd.Caption = "総額表示区分";

            // 印刷用請求金額
            DataColumn PrintAfCalDemandPrice = new DataColumn(CT_CsDmd_PrintAfCalDemandPrice, typeof(String), "", MappingType.Element);

            // 請求残高
            DataColumn DemandBalance = new DataColumn(CT_CsDmd_DemandBalance, typeof(System.Int64), "", MappingType.Element);

            // 純売上額
            DataColumn NetSales = new DataColumn(CT_CsDmd_NetSales, typeof(System.Int64), "", MappingType.Element);

            // 回収率
            DataColumn CollectRate = new DataColumn(CT_CsDmd_CollectRate, typeof(double), "", MappingType.Element);

            // 回収残高(合計部計算用)
            DataColumn CollectDemand = new DataColumn(CT_CsDmd_CollectDemand, typeof(System.Int64), "", MappingType.Element);

            // 販売エリアコード
            DataColumn SalesAreaCode = new DataColumn(CT_CsDmd_SalesAreaCode, typeof(System.Int32), "", MappingType.Element);

            // 販売エリアコード
            DataColumn SalesAreaName = new DataColumn(CT_CsDmd_SalesAreaName, typeof(String), "", MappingType.Element);

            //--------------------------------------------------
            //  残高入金内訳
            //--------------------------------------------------
            // 受注３回前残高(前々々回)
            DataColumn AcpOdrTtl3TmBfBlDmd = new DataColumn(CT_Blnce_AcpOdrTtl3TmBfBlDmd, typeof(System.Int64), "", MappingType.Element);

            // 受注２回前残高(前々回)
            DataColumn AcpOdrTtl2TmBfBlDmd = new DataColumn(CT_Blnce_AcpOdrTtl2TmBfBlDmd, typeof(System.Int64), "", MappingType.Element);

            // 現金(金種区分)
            DataColumn MoneyKindDiv101 = new DataColumn(CT_Blnce_MoneyKindDiv101, typeof(System.Int64), "", MappingType.Element);

            // 振込(金種区分)
            DataColumn MoneyKindDiv102 = new DataColumn(CT_Blnce_MoneyKindDiv102, typeof(System.Int64), "", MappingType.Element);

            // 小切手(金種区分)
            DataColumn MoneyKindDiv107 = new DataColumn(CT_Blnce_MoneyKindDiv107, typeof(System.Int64), "", MappingType.Element);

            // 手形(金種区分)
            DataColumn MoneyKindDiv105 = new DataColumn(CT_Blnce_MoneyKindDiv105, typeof(System.Int64), "", MappingType.Element);

            // 相殺(金種区分)
            DataColumn MoneyKindDiv106 = new DataColumn(CT_Blnce_MoneyKindDiv106, typeof(System.Int64), "", MappingType.Element);

            // その他(金種区分)
            DataColumn MoneyKindDiv109 = new DataColumn(CT_Blnce_MoneyKindDiv109, typeof(System.Int64), "", MappingType.Element);

            // 口座振替(金種区分)
            DataColumn MoneyKindDiv112 = new DataColumn(CT_Blnce_MoneyKindDiv112, typeof(System.Int64), "", MappingType.Element);
            
            // 請求書出力区分コード
            DataColumn BillOutputCode = new DataColumn(CT_Blnce_BillOutputCode, typeof(Int32), "", MappingType.Element);
            
            // 領収書出力区分コード
            DataColumn ReceiptOutputCode = new DataColumn(CT_Blnce_ReceiptOutputCode, typeof(Int32), "", MappingType.Element);  // ADD 2009/04/07

            // --- ADD  大矢睦美  2010/02/01 ---------->>>>>
            //合計請求書出力区分コード
            DataColumn TotalBillOutputDiv = new DataColumn(CT_Blnce_TotalBillOutputDiv, typeof(Int32), "", MappingType.Element);

            //明細請求書出力区分コード
            DataColumn DetailBillOutputCode = new DataColumn(CT_Blnce_DetailBillOutputCode, typeof(Int32), "", MappingType.Element);

            //伝票合計請求書出力区分コード
            DataColumn SlipTtlBillOutputDiv = new DataColumn(CT_Blnce_SlipTtlBillOutputDiv, typeof(Int32), "", MappingType.Element);

            // --- ADD  大矢睦美  2010/02/01 ----------<<<<<

            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
            //  売上額(計税率1)
            DataColumn TotalThisTimeSalesTaxRate1 = new DataColumn(Col_TotalThisTimeSalesTaxRate1, typeof(System.Int64), "", MappingType.Element);
            // 売上額(計税率2)
            DataColumn TotalThisTimeSalesTaxRate2 = new DataColumn(Col_TotalThisTimeSalesTaxRate2, typeof(System.Int64), "", MappingType.Element);
            // 売上額(計その他)
            DataColumn TotalThisTimeSalesOther = new DataColumn(Col_TotalThisTimeSalesOther, typeof(System.Int64), "", MappingType.Element);
            // 返品値引(計税率1)
            DataColumn TotalThisRgdsDisPricTaxRate1 = new DataColumn(Col_TotalThisRgdsDisPricTaxRate1, typeof(System.Int64), "", MappingType.Element);
            // 返品値引(計税率2)
            DataColumn TotalThisRgdsDisPricTaxRate2 = new DataColumn(Col_TotalThisRgdsDisPricTaxRate2, typeof(System.Int64), "", MappingType.Element);
            // 返品値引(計その他)
            DataColumn TotalThisRgdsDisPricOther = new DataColumn(Col_TotalThisRgdsDisPricOther, typeof(System.Int64), "", MappingType.Element);
            // 純売上額(計税率1)
            DataColumn TotalPureSalesTaxRate1 = new DataColumn(Col_TotalPureSalesTaxRate1, typeof(System.Int64), "", MappingType.Element);
            // 純売上額(計税率2)
            DataColumn TotalPureSalesTaxRate2 = new DataColumn(Col_TotalPureSalesTaxRate2, typeof(System.Int64), "", MappingType.Element);
            // 純売上額(計その他)
            DataColumn TotalPureSalesOther = new DataColumn(Col_TotalPureSalesOther, typeof(System.Int64), "", MappingType.Element);
            // 消費税(計税率1)
            DataColumn TotalSalesPricTaxTaxRate1 = new DataColumn(Col_TotalSalesPricTaxTaxRate1, typeof(System.Int64), "", MappingType.Element);
            // 消費税(計税率2)
            DataColumn TotalSalesPricTaxTaxRate2 = new DataColumn(Col_TotalSalesPricTaxTaxRate2, typeof(System.Int64), "", MappingType.Element);
            // 消費税(計その他)
            DataColumn TotalSalesPricTaxOther = new DataColumn(Col_TotalSalesPricTaxOther, typeof(System.Int64), "", MappingType.Element);
            // 今回合計(計税率1)
            DataColumn TotalThisSalesSumTaxRate1 = new DataColumn(Col_TotalThisSalesSumTaxRate1, typeof(System.Int64), "", MappingType.Element);
            // 今回合計(計税率2)
            DataColumn TotalThisSalesSumTaxRate2 = new DataColumn(Col_TotalThisSalesSumTaxRate2, typeof(System.Int64), "", MappingType.Element);
            // 今回合計(計その他)
            DataColumn TotalThisSalesSumTaxOther = new DataColumn(Col_TotalThisSalesSumTaxOther, typeof(System.Int64), "", MappingType.Element);
            // 枚数(計税率1)
            DataColumn TotalSalesSlipCountTaxRate1 = new DataColumn(Col_TotalSalesSlipCountTaxRate1, typeof(System.Int64), "", MappingType.Element);
            // 枚数(計税率2)
            DataColumn TotalSalesSlipCountTaxRate2 = new DataColumn(Col_TotalSalesSlipCountTaxRate2, typeof(System.Int64), "", MappingType.Element);
            // 枚数(計その他)
            DataColumn TotalSalesSlipCountOther = new DataColumn(Col_TotalSalesSlipCountOther, typeof(System.Int64), "", MappingType.Element);
            // 税率1タイトル
            DataColumn TitleTaxRate1 = new DataColumn(Col_TitleTaxRate1, typeof(System.String), "", MappingType.Element);
            // 税率2タイトル
            DataColumn TitleTaxRate2 = new DataColumn(Col_TitleTaxRate2, typeof(System.String), "", MappingType.Element);
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
            // --- ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
            // 売上額(計非課税)
            DataColumn TotalThisTimeSalesTaxFree = new DataColumn(Col_TotalThisTimeSalesTaxFree, typeof(System.Int64), "", MappingType.Element);
            // 返品値引(計非課税)
            DataColumn TotalThisRgdsDisPricTaxFree = new DataColumn(Col_TotalThisRgdsDisPricTaxFree, typeof(System.Int64), "", MappingType.Element);
            // 純売上額(計非課税)
            DataColumn TotalPureSalesTaxFree = new DataColumn(Col_TotalPureSalesTaxFree, typeof(System.Int64), "", MappingType.Element);
            // 消費税(計非課税)
            DataColumn TotalSalesPricTaxTaxFree = new DataColumn(Col_TotalSalesPricTaxTaxFree, typeof(System.Int64), "", MappingType.Element);
            // 今回合計(計非課税)
            DataColumn TotalThisSalesSumTaxFree = new DataColumn(Col_TotalThisSalesSumTaxFree, typeof(System.Int64), "", MappingType.Element);
            // 枚数(計非課税)
            DataColumn TotalSalesSlipCountTaxFree = new DataColumn(Col_TotalSalesSlipCountTaxFree, typeof(System.Int64), "", MappingType.Element);
            // --- ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    
            _demandDataSet.Tables.AddRange(new DataTable[] { _custDmdPrcDataTable });
            _custDmdPrcDataTable.Columns.AddRange(new DataColumn[]{
                UniqueID,
                    DataType,
                    RecordName,
				    PrintFlag,
				    PrintIndex,
				    AddUpSecCode,
				    AddUpSecName,
                    ClaimSectionCode,
                    ClaimSectionName,
                    ResultsSectCd,
                    SumClaimCustCode,
                    SumClaimCustCodeDisp,
                    SumClaimCustSnm,
                    ClaimCode,
                    ClaimCodeDisp,
                    ClaimName,
                    ClaimName2,
                    ClaimSnm,
				    CustomerCode,
                    CustomerName,
                    CustomerName2,
                    CustomerSnm,
                    AddUpDate,
				    AddUpDateInt,		
				    AddUpYearMonth,
                    LastTimeDemand,
                    DemandBalance,
                    ThisTimeDmdNrml,        
                    ThisTimeFeeDmdNrml,     
                    ThisTimeDisDmdNrml,
                    ThisTimeTtlBlcDmd,
                    OfsThisTimeSales,
                    OfsThisSalesTax,
                    OfsThisSalesSum,
                    ThisTimeSales,
                    ThisSalesPricRgds,
                    ThisSalesPricDis,
                    ThisSalesPricRgdsDis,
                    BalanceAdjust,
                    AfCalDemandPrice,
                    AfCalDemandPriceFilter,
                    SaleslSlipCount,
                    FractionProcCd,
                    PrintTtlConsTaxDmd,
                    CollectMoneyName,
				    CollectMoneyDay,
				    CollectMoneyDayNm,
                    TotalDay,
				    PrintTotalDay,
				    CustomerAgentCd,
				    CustomerAgentNm,
				    BillCollecterCd,
				    BillCollecterNm,
				    EmployeeCd,
				    EmployeeNm,
                    TotalAmountDispWayCd,
                    PrintAfCalDemandPrice,
                    NetSales,
                    CollectRate,
                    CollectDemand,
                    SalesAreaCode,
                    SalesAreaName,
                    AcpOdrTtl3TmBfBlDmd,
                    AcpOdrTtl2TmBfBlDmd,
                    MoneyKindDiv101,
                    MoneyKindDiv102,
                    MoneyKindDiv107,
                    MoneyKindDiv105,
                    MoneyKindDiv106,
                    MoneyKindDiv109,
                    MoneyKindDiv112,
                    BillOutputCode,
                // --- ADD  大矢睦美  2010/02/01 ---------->>>>>
                    //ReceiptOutputCode
                    ReceiptOutputCode,
                    TotalBillOutputDiv,
                    DetailBillOutputCode,
                    SlipTtlBillOutputDiv,
                // --- ADD  大矢睦美  2010/02/01 ----------<<<<<
                　// --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                　　TotalThisTimeSalesTaxRate1,
                    TotalThisTimeSalesTaxRate2,
                    TotalThisTimeSalesTaxFree,// ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    TotalThisTimeSalesOther,
                    TotalThisRgdsDisPricTaxRate1,
                    TotalThisRgdsDisPricTaxRate2,
                    TotalThisRgdsDisPricTaxFree,// ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    TotalThisRgdsDisPricOther,
                    TotalPureSalesTaxRate1,
                    TotalPureSalesTaxRate2,
                    TotalPureSalesTaxFree,// ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    TotalPureSalesOther,
                    TotalSalesPricTaxTaxRate1,
                    TotalSalesPricTaxTaxRate2,
                    TotalSalesPricTaxTaxFree,// ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    TotalSalesPricTaxOther,
                    TotalThisSalesSumTaxRate1,
                    TotalThisSalesSumTaxRate2,
                    TotalThisSalesSumTaxFree,// ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    TotalThisSalesSumTaxOther,
                    TotalSalesSlipCountTaxRate1,
                    TotalSalesSlipCountTaxRate2,
                    TotalSalesSlipCountTaxFree,// ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    TotalSalesSlipCountOther,
                    TitleTaxRate1,
                    TitleTaxRate2,
　　　　　　　　　　// --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
			    });
            // プライマリーキーをユニークIDに設定
            _custDmdPrcDataTable.PrimaryKey = new DataColumn[] { UniqueID };
            _custDmdPrcDataView.Table = _custDmdPrcDataTable;
            // ソート順：請求拠点＋総括得意先＋実績拠点＋請求得意先
            _custDmdPrcDataView.Sort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_SumClaimCustCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_ClaimCode;

            // 印刷用DataTable作成
            _custDmdPrcPrintDataTable = _custDmdPrcDataTable.Clone();
            _custDmdPrcDataViewPrint.Table = _custDmdPrcPrintDataTable;
            // ソート順：請求拠点＋総括得意先＋実績拠点＋請求得意先
            _custDmdPrcDataViewPrint.Sort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_SumClaimCustCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_ClaimCode;
            
            _custDmdPrcDataViewPrint.RowFilter = String.Format("{0} = {1}", CT_CsDmd_PrintFlag, true);

        }

        /// <summary>
        /// 得意先請求金額情報データ行設定処理(請求)
        /// </summary>
        /// <param name="extraInfo">抽出条件データクラス</param>
        /// <param name="rsltInfo_DemandTotalWork">抽出結果データワーククラス</param>
        /// <returns>設定されたデータ行</returns>
        /// <remarks>
        /// <br>Note        : 得意先請求金額情報をデータ行へ設定します。</br>
        /// <br>Update Note : 11570208-00 軽減税率対応</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/04/13</br>
        /// </remarks>
        private DataRow CustDmdPrcWorkToDataRow(SumExtrInfo_DemandTotal extraInfo, SumRsltInfo_DemandTotalWork rsltInfo_DemandTotalWork)
        {
            DataRow newRow = _custDmdPrcDataTable.NewRow();

            // 総括得意先コードの取得
            if (!_sumClaimCustCodeList.Contains(rsltInfo_DemandTotalWork.SumClaimCustCode))
            {
                _sumClaimCustCodeList.Add(rsltInfo_DemandTotalWork.SumClaimCustCode);
            }
            
            // 売掛区分のチェック
            if (extraInfo.SlipPrtKind == 0)
            {
                // 発行タイプ：請求一覧表（総括）
                if (extraInfo.AccRecDivCd != -1)
                {
                    // 抽出条件の売掛区分が"全て"以外
                    if (extraInfo.AccRecDivCd != rsltInfo_DemandTotalWork.AccRecDivCd)
                    {
                        // 売掛区分が一致しない場合は抽出対象外
                        return null;
                    }
                }
            }
            else
            {
                // 発行タイプ：請求書（総括）
                if (rsltInfo_DemandTotalWork.AccRecDivCd == 0)
                {
                    // 売掛区分が"売掛"以外は抽出対象外
                    return null;
                }
            }
            
            // レコードタイプ（集計レコードはfalse）
            newRow[CT_CsDmd_DataType] = false;
            // レコード名
            newRow[CT_CsDmd_RecordName] = "集計レコード";
            // 印刷フラグ
            newRow[CT_CsDmd_PrintFlag] = true;

            // 計上拠点コード
            string secCode = rsltInfo_DemandTotalWork.AddUpSecCode;
            newRow[CT_CsDmd_AddUpSecCode] = secCode;
            // 計上拠点名称
            if (_sectionOption)
            {
                if (SectionTable.ContainsKey(secCode))
                {
                    newRow[CT_CsDmd_AddUpSecName] = ((SecInfoSet)SectionTable[secCode]).SectionGuideNm;
                }
                else
                {
                    newRow[CT_CsDmd_AddUpSecName] = "";
                }
            }
            else
            {
                newRow[CT_CsDmd_AddUpSecName] = "";
            }
            
            // 請求拠点コード
            string claimSecCode = rsltInfo_DemandTotalWork.ClaimSectionCode;
            newRow[CT_CsDmd_ClaimSectionCode] = claimSecCode;
            // 請求拠点名称
            if (_sectionOption)
            {
                if (SectionTable.ContainsKey(claimSecCode))
                {
                    newRow[CT_CsDmd_ClaimSectionName] = ((SecInfoSet)SectionTable[claimSecCode]).SectionGuideNm;
                }
                else
                {
                    newRow[CT_CsDmd_ClaimSectionName] = "";
                }
            }
            else
            {
                newRow[CT_CsDmd_ClaimSectionName] = "";
            }

            // 実績拠点コード（4/23現在、"00"が返ってくる）
            newRow[CT_CsDmd_ResultsSectCd] = rsltInfo_DemandTotalWork.ResultsSectCd;

            // 総括得意先コード
            newRow[CT_CsDmd_SumClaimCustCode] = rsltInfo_DemandTotalWork.SumClaimCustCode;
            // 総括得意先コード(抽出結果表示用)
            newRow[CT_CsDmd_SumClaimCustCodeDisp] = rsltInfo_DemandTotalWork.SumClaimCustCode.ToString("d08");

            // 総括得意先略称
            // 2010/07/01 >>>
            //newRow[CT_CsDmd_SumClaimCustSnm] = rsltInfo_DemandTotalWork.SumClaimCustName;
            newRow[CT_CsDmd_SumClaimCustSnm] = nameJoin(rsltInfo_DemandTotalWork.SumClaimCustName1, rsltInfo_DemandTotalWork.SumClaimCustName2);
            // 2010/07/01 <<<
            
            // 請求先コード
            newRow[CT_CsDmd_ClaimCode] = rsltInfo_DemandTotalWork.ClaimCode;
            // 請求先コード(抽出結果表示用)
            newRow[CT_CsDmd_ClaimCodeDisp] = rsltInfo_DemandTotalWork.ClaimCode.ToString("d08");
            
            // 請求先名称
            newRow[CT_CsDmd_ClaimName] = rsltInfo_DemandTotalWork.ClaimName;
            // 請求先名称2
            newRow[CT_CsDmd_ClaimName2] = rsltInfo_DemandTotalWork.ClaimName2;
            // 請求先略称
            newRow[CT_CsDmd_ClaimSnm] = rsltInfo_DemandTotalWork.ClaimSnm;

            // 得意先コード
            newRow[CT_CsDmd_CustomerCode] = rsltInfo_DemandTotalWork.CustomerCode;
            // 得意先名称
            newRow[CT_CsDmd_CustomerName] = rsltInfo_DemandTotalWork.CustomerName;
            // 得意先名称2
            newRow[CT_CsDmd_CustomerName2] = rsltInfo_DemandTotalWork.CustomerName2;
            // 得意先略称
            newRow[CT_CsDmd_CustomerSnm] = rsltInfo_DemandTotalWork.CustomerSnm;
            
            // 計上年月日
            newRow[CT_CsDmd_AddUpDate] = rsltInfo_DemandTotalWork.AddUpDate;
            // 計上年月日(Int型)
            newRow[CT_CsDmd_AddUpDateInt] = TDateTime.DateTimeToLongDate(rsltInfo_DemandTotalWork.AddUpDate);
            // 計上年月
            newRow[CT_CsDmd_AddUpYearMonth] = rsltInfo_DemandTotalWork.AddUpYearMonth;

            // 前回請求額 
            newRow[CT_CsDmd_LastTimeDemand] = rsltInfo_DemandTotalWork.LastTimeDemand;
            
            // 今回入金金額（通常入金）
            newRow[CT_CsDmd_ThisTimeDmdNrml] = rsltInfo_DemandTotalWork.ThisTimeDmdNrml;

            // 今回手数料額（通常入金）
            newRow[CT_CsDmd_ThisTimeFeeDmdNrml] = rsltInfo_DemandTotalWork.ThisTimeFeeDmdNrml;

            // 今回値引額(通常入金)
            newRow[CT_CsDmd_ThisTimeDisDmdNrml] = rsltInfo_DemandTotalWork.ThisTimeDisDmdNrml;

            // 今回繰越残高（請求計）
            newRow[CT_CsDmd_ThisTimeTtlBlcDmd] = rsltInfo_DemandTotalWork.ThisTimeTtlBlcDmd;

            // 相殺後今回売上金額
            newRow[CT_CsDmd_OfsThisTimeSales] = rsltInfo_DemandTotalWork.OfsThisTimeSales;

            // 相殺後今回売上消費税
            newRow[CT_CsDmd_OfsThisSalesTax] = rsltInfo_DemandTotalWork.OfsThisSalesTax;

            // 相殺後今回合計売上金額
            // 相殺後今回売上金額＋相殺後今回売上消費税
            Int64 ofsThisSalesSum = rsltInfo_DemandTotalWork.OfsThisTimeSales + rsltInfo_DemandTotalWork.OfsThisSalesTax;
            newRow[CT_CsDmd_OfsThisSalesSum] = ofsThisSalesSum;
            
            // 今回売上金額
            newRow[CT_CsDmd_ThisTimeSales] = rsltInfo_DemandTotalWork.ThisTimeSales;

            // 今回売上返品金額
            newRow[CT_CsDmd_ThisSalesPricRgds] = rsltInfo_DemandTotalWork.ThisSalesPricRgds;

            // 今回売上値引金額
            newRow[CT_CsDmd_ThisSalesPricDis] = rsltInfo_DemandTotalWork.ThisSalesPricDis;

            // 今回売上返品・値引金額
            long thisSalesPricRgdsDis = (Int64)(rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis);
            newRow[CT_CsDmd_ThisSalesPricRgdsDis] = -thisSalesPricRgdsDis;
            
            // 残高調整額
            newRow[CT_CsDmd_BalanceAdjust] = rsltInfo_DemandTotalWork.BalanceAdjust;

            // 計算後請求金額
            newRow[CT_CsDmd_AfCalDemandPrice] = rsltInfo_DemandTotalWork.AfCalDemandPrice;

            // --- DEL  大矢睦美  2010/02/24 ---------->>>>>
            ////計算後請求金額をキャッシュ登録
            //string key = secCode.TrimEnd() + "-" + rsltInfo_DemandTotalWork.SumClaimCustCode.ToString("d08");
            //if ((bool)newRow[CT_CsDmd_DataType])
            //{
            //    // 集計レコード
            //    if (afCalDemandPriceDic.ContainsKey(key))
            //    {
            //        long afCalDemandPrice = afCalDemandPriceDic[key] + rsltInfo_DemandTotalWork.AfCalDemandPrice;
            //        afCalDemandPriceDic.Remove(key);
            //    }
            //    afCalDemandPriceDic.Add(key, rsltInfo_DemandTotalWork.AfCalDemandPrice);
            //}
            // --- DEL  大矢睦美  2010/02/24 ----------<<<<<
                            
            // 売上伝票枚数
            newRow[CT_CsDmd_SaleslSlipCount] = rsltInfo_DemandTotalWork.SalesSlipCount;

            // 端数処理区分
            newRow[CT_CsDmd_FractionProcCd] = rsltInfo_DemandTotalWork.FractionProcCd;

            // 集計レコードの場合
            if (_allDefSet.TotalAmountDispWayCd == 0)
            {
                // 総額表示しない税抜き(相殺後今回売上消費税) 
                newRow[CT_CsDmd_PrintTtlConsTaxDmd] = rsltInfo_DemandTotalWork.OfsThisSalesTax.ToString("#,##0");
            }
            else
            {
                // 総額表示する税込み(相殺後今回売上消費税)
                newRow[CT_CsDmd_PrintTtlConsTaxDmd] = "(" + rsltInfo_DemandTotalWork.OfsThisSalesTax.ToString("#,##0") + ")";
            }
            
            // 印刷用請求金額
            newRow[CT_CsDmd_PrintAfCalDemandPrice] = "\\" + rsltInfo_DemandTotalWork.AfCalDemandPrice.ToString("#,##0");

            // *********************
            // 得意先関連項目
            // *********************
            // 締日
            newRow[CT_CsDmd_TotalDay] = rsltInfo_DemandTotalWork.TotalDay;

            // 締日(印刷用)
            if (rsltInfo_DemandTotalWork.TotalDay != 0)
            {
                newRow[CT_CsDmd_PrintTotalDay] = String.Format("{0,2}日", rsltInfo_DemandTotalWork.TotalDay);
            }

            // 集金月区分名称
            newRow[CT_CsDmd_CollectMoneyName] = rsltInfo_DemandTotalWork.CollectMoneyName;

            // 集金日
            newRow[CT_CsDmd_CollectMoneyDay] = rsltInfo_DemandTotalWork.CollectMoneyDay;

            // 集金日(印刷用)
            if (rsltInfo_DemandTotalWork.CollectMoneyDay != 0)
            {
                // 請求書末日印字区分 = 1(28～31日は末日と印字) で28日以降の場合
                if (rsltInfo_DemandTotalWork.CollectMoneyDay >= 28 && _billPrtSt.BillLastDayPrtDiv == 1)
                {
                    newRow[CT_CsDmd_CollectMoneyDayNm] = "末日";
                }
                else
                {
                    newRow[CT_CsDmd_CollectMoneyDayNm] = String.Format("{0}日", rsltInfo_DemandTotalWork.CollectMoneyDay);
                }
            }
            else
            {
                newRow[CT_CsDmd_CollectMoneyDayNm] = "";
            }

            // 顧客担当従業員コード
            newRow[CT_CsDmd_CustomerAgentCd] = rsltInfo_DemandTotalWork.CustomerAgentCd;

            // 顧客担当従業員名称
            newRow[CT_CsDmd_CustomerAgentNm] = rsltInfo_DemandTotalWork.CustomerAgentNm;

            // 集金担当従業員コード
            newRow[CT_CsDmd_BillCollecterCd] = rsltInfo_DemandTotalWork.BillCollecterCd;

            // 集金担当従業員名称
            newRow[CT_CsDmd_BillCollecterNm] = rsltInfo_DemandTotalWork.BillCollecterNm;

            // 総額表示区分
            newRow[CT_CsDmd_TotalAmountDispWayCd] = rsltInfo_DemandTotalWork.TotalAmountDispWayCd;

            // 請求残高
            newRow[CT_CsDmd_DemandBalance] = rsltInfo_DemandTotalWork.LastTimeDemand + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd;

            // 純売上額
            newRow[CT_CsDmd_NetSales] = rsltInfo_DemandTotalWork.OfsThisTimeSales;
            
            // 回収率
            Int64 collectDemand = 0;
            double collectRate = 0.0;
            if (extraInfo.CollectRatePrtDiv == 0)
            {
                // 前回残計算
                collectDemand = rsltInfo_DemandTotalWork.LastTimeDemand + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd;
            }
            else if (extraInfo.CollectRatePrtDiv == 1)
            {
                // 回収月計算
                if (rsltInfo_DemandTotalWork.CollectMoneyCode == 0)
                {
                    // 当月
                    if ((rsltInfo_DemandTotalWork.TotalDay < _endDays) && (rsltInfo_DemandTotalWork.TotalDay < rsltInfo_DemandTotalWork.CollectMoneyDay))
                    {
                        // 締日が月末以外で、締日より集金日が後の場合は当月扱い
                        collectDemand = rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd
                                      + rsltInfo_DemandTotalWork.LastTimeDemand + rsltInfo_DemandTotalWork.OfsThisTimeSales
                                      + rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis
                                      + rsltInfo_DemandTotalWork.OfsThisSalesTax;
                    }
                    else
                    {
                        // 上記以外は翌月扱い
                        collectDemand = rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd
                                      + rsltInfo_DemandTotalWork.LastTimeDemand;
                    }
                }
                else if (rsltInfo_DemandTotalWork.CollectMoneyCode == 1)
                {
                    // 翌月
                    collectDemand = rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd
                                  + rsltInfo_DemandTotalWork.LastTimeDemand;
                }
                else if (rsltInfo_DemandTotalWork.CollectMoneyCode == 2)
                {
                    // 翌々月
                    collectDemand = rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd;
                }
                else
                {
                    // 翌々々月
                    collectDemand = rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd;                    
                }
            }

            // 前回残／回収月金額と今回入金額がゼロ以外の場合回収率計算
            if ((collectDemand != 0) && (rsltInfo_DemandTotalWork.ThisTimeDmdNrml != 0))
            {
                collectRate = (double)rsltInfo_DemandTotalWork.ThisTimeDmdNrml * 100 / (double)collectDemand;
            }
            newRow[CT_CsDmd_CollectRate] = collectRate;

            // 回収残高(合計部計算用)
            newRow[CT_CsDmd_CollectDemand] = collectDemand;

            // 販売エリアコード
            newRow[CT_CsDmd_SalesAreaCode] = rsltInfo_DemandTotalWork.SalesAreaCode;

            // 販売エリア名称
            newRow[CT_CsDmd_SalesAreaName] = rsltInfo_DemandTotalWork.SalesAreaName;

            // 受注３回前残高(前々々回)
            newRow[CT_Blnce_AcpOdrTtl3TmBfBlDmd] = rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd;

            // 受注２回前残高(前々回)
            newRow[CT_Blnce_AcpOdrTtl2TmBfBlDmd] = rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd;

            // 現金(金種区分)
            newRow[CT_Blnce_MoneyKindDiv101] = 0;
            // 振込(金種区分)
            newRow[CT_Blnce_MoneyKindDiv102] = 0;
            // 小切手(金種区分)
            newRow[CT_Blnce_MoneyKindDiv107] = 0;
            // 手形(金種区分)
            newRow[CT_Blnce_MoneyKindDiv105] = 0;
            // 相殺(金種区分)
            newRow[CT_Blnce_MoneyKindDiv106] = 0;
            // 口座振替(金種区分)
            newRow[CT_Blnce_MoneyKindDiv112] = 0;
            // その他
            newRow[CT_Blnce_MoneyKindDiv109] = 0;
            
            foreach (SumRsltInfo_DepsitTotalWork work in rsltInfo_DemandTotalWork.MoneyKindList)
            {
                if (work.MoneyKindDiv == 101)
                {
                    // 現金(金種区分)
                    newRow[CT_Blnce_MoneyKindDiv101] = work.Deposit;
                }
                else if (work.MoneyKindDiv == 102)
                {
                    // 振込(金種区分)
                    newRow[CT_Blnce_MoneyKindDiv102] = work.Deposit;
                }
                else if (work.MoneyKindDiv == 107)
                {
                    // 小切手(金種区分)
                    newRow[CT_Blnce_MoneyKindDiv107] = work.Deposit;
                }
                else if (work.MoneyKindDiv == 105)
                {
                    // 手形(金種区分)
                    newRow[CT_Blnce_MoneyKindDiv105] = work.Deposit;
                }
                else if (work.MoneyKindDiv == 106)
                {
                    // 相殺(金種区分)
                    newRow[CT_Blnce_MoneyKindDiv106] = work.Deposit;
                }
                else if (work.MoneyKindDiv == 112)
                {
                    // 口座振替(金種区分)
                    newRow[CT_Blnce_MoneyKindDiv112] = work.Deposit;
                }
                else
                {
                    // その他
                    newRow[CT_Blnce_MoneyKindDiv109] = (long)newRow[CT_Blnce_MoneyKindDiv109] + work.Deposit;
                }                
            }
            
            // 請求書出力区分コード
            newRow[CT_Blnce_BillOutputCode] = rsltInfo_DemandTotalWork.BillOutputCode;            
            // 領収書出力区分コード
            newRow[CT_Blnce_ReceiptOutputCode] = rsltInfo_DemandTotalWork.ReceiptOutputCode;

            // --- ADD  大矢睦美  2010/02/01 ---------->>>>>
            //合計請求書出力区分コード
            newRow[CT_Blnce_TotalBillOutputDiv] = rsltInfo_DemandTotalWork.TotalBillOutputDiv;

            //明細請求書出力区分コード
            newRow[CT_Blnce_DetailBillOutputCode] = rsltInfo_DemandTotalWork.DetailBillOutputCode;

            //伝票合計請求書出力区分コード
            newRow[CT_Blnce_SlipTtlBillOutputDiv] = rsltInfo_DemandTotalWork.SlipTtlBillOutputDiv;

            // --- ADD  大矢睦美  2010/02/01 ----------<<<<<

            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
            if (_taxReductionDone)
            {
                // 売上額(計税率1)
                newRow[Col_TotalThisTimeSalesTaxRate1] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisTimeSalesTaxRate1");
                // 売上額(計税率2)
                newRow[Col_TotalThisTimeSalesTaxRate2] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisTimeSalesTaxRate2");
                // 売上額(計その他)
                newRow[Col_TotalThisTimeSalesOther] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisTimeSalesOther");
                // 返品値引(計税率1)
                newRow[Col_TotalThisRgdsDisPricTaxRate1] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisRgdsDisPricTaxRate1");
                // 返品値引(計税率2)
                newRow[Col_TotalThisRgdsDisPricTaxRate2] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisRgdsDisPricTaxRate2");
                // 返品値引(計その他)
                newRow[Col_TotalThisRgdsDisPricOther] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisRgdsDisPricOther");
                // 純売上額(計税率1)
                newRow[Col_TotalPureSalesTaxRate1] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalPureSalesTaxRate1");
                // 純売上額(計税率2)
                newRow[Col_TotalPureSalesTaxRate2] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalPureSalesTaxRate2");
                // 純売上額(計その他)
                newRow[Col_TotalPureSalesOther] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalPureSalesOther");
                // 消費税(計税率1)
                newRow[Col_TotalSalesPricTaxTaxRate1] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesPricTaxTaxRate1");
                // 消費税(計税率2)
                newRow[Col_TotalSalesPricTaxTaxRate2] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesPricTaxTaxRate2");
                // 消費税(計その他)
                newRow[Col_TotalSalesPricTaxOther] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesPricTaxOther");
                // 今回合計(計税率1)
                newRow[Col_TotalThisSalesSumTaxRate1] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisSalesSumTaxRate1");
                // 今回合計(計税率2)
                newRow[Col_TotalThisSalesSumTaxRate2] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisSalesSumTaxRate2");
                // 今回合計(計その他)
                newRow[Col_TotalThisSalesSumTaxOther] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisSalesSumTaxOther");
                // 枚数(計税率1)
                newRow[Col_TotalSalesSlipCountTaxRate1] = (int)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesSlipCountTaxRate1");
                // 枚数(計税率2)
                newRow[Col_TotalSalesSlipCountTaxRate2] = (int)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesSlipCountTaxRate2");
                // 枚数(計その他)
                newRow[Col_TotalSalesSlipCountOther] = (int)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesSlipCountOther");
                // 税率1タイトル
                newRow[Col_TitleTaxRate1] = Convert.ToInt32((double)GetPropertyValue(extraInfo, "TaxRate1") * 100) + "%";
                // 税率2タイトル
                newRow[Col_TitleTaxRate2] = Convert.ToInt32((double)GetPropertyValue(extraInfo, "TaxRate2") * 100) + "%";
                // --- ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                // 売上額(計非課税)
                newRow[Col_TotalThisTimeSalesTaxFree] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisTimeSalesTaxFree");
                // 返品値引(計非課税)
                newRow[Col_TotalThisRgdsDisPricTaxFree] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisRgdsDisPricTaxFree");
                // 純売上額(計非課税)
                newRow[Col_TotalPureSalesTaxFree] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalPureSalesTaxFree");
                // 消費税(計非課税)
                newRow[Col_TotalSalesPricTaxTaxFree] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesPricTaxTaxFree");
                // 今回合計(計非課税)
                newRow[Col_TotalThisSalesSumTaxFree] = (long)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalThisSalesSumTaxFree");
                // 枚数(計非課税)
                newRow[Col_TotalSalesSlipCountTaxFree] = (int)GetPropertyValue(rsltInfo_DemandTotalWork, "TotalSalesSlipCountTaxFree");
                // --- ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            }
            else
            {
                // 売上額(計税率1)
                newRow[Col_TotalThisTimeSalesTaxRate1] = 0;
                // 売上額(計税率2)
                newRow[Col_TotalThisTimeSalesTaxRate2] = 0;
                // 売上額(計その他)
                newRow[Col_TotalThisTimeSalesOther] = 0;
                // 返品値引(計税率1)
                newRow[Col_TotalThisRgdsDisPricTaxRate1] = 0;
                // 返品値引(計税率2)
                newRow[Col_TotalThisRgdsDisPricTaxRate2] = 0;
                // 返品値引(計その他)
                newRow[Col_TotalThisRgdsDisPricOther] = 0;
                // 純売上額(計税率1)
                newRow[Col_TotalPureSalesTaxRate1] = 0;
                // 純売上額(計税率2)
                newRow[Col_TotalPureSalesTaxRate2] = 0;
                // 純売上額(計その他)
                newRow[Col_TotalPureSalesOther] = 0;
                // 消費税(計税率1)
                newRow[Col_TotalSalesPricTaxTaxRate1] = 0;
                // 消費税(計税率2)
                newRow[Col_TotalSalesPricTaxTaxRate2] = 0;
                // 消費税(計その他)
                newRow[Col_TotalSalesPricTaxOther] = 0;
                // 今回合計(計税率1)
                newRow[Col_TotalThisSalesSumTaxRate1] = 0;
                // 今回合計(計税率2)
                newRow[Col_TotalThisSalesSumTaxRate2] = 0;
                // 今回合計(計その他)
                newRow[Col_TotalThisSalesSumTaxOther] = 0;
                // 枚数(計税率1)
                newRow[Col_TotalSalesSlipCountTaxRate1] = 0;
                // 枚数(計税率2)
                newRow[Col_TotalSalesSlipCountTaxRate2] = 0;
                // 枚数(計その他)
                newRow[Col_TotalSalesSlipCountOther] = 0;
                //--- ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                // 売上額(計非課税)
                newRow[Col_TotalThisTimeSalesTaxFree] = 0;
                // 返品値引(計非課税)
                newRow[Col_TotalThisRgdsDisPricTaxFree] = 0;
                // 純売上額(計非課税)
                newRow[Col_TotalPureSalesTaxFree] = 0;
                // 消費税(計非課税)
                newRow[Col_TotalSalesPricTaxTaxFree] = 0;
                // 今回合計(計非課税)
                newRow[Col_TotalThisSalesSumTaxFree] = 0;
                // 枚数(計非課税)
                newRow[Col_TotalSalesSlipCountTaxFree] = 0;
                //--- ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                // 税率1タイトル
                newRow[Col_TitleTaxRate1] = string.Empty;
                // 税率2タイトル
                newRow[Col_TitleTaxRate2] = string.Empty;
            }
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<

            newRow.EndEdit();

            return newRow;
        }

        /// <summary>
        /// クラスメンバーコピー処理（抽出条件クラス⇒抽出条件ワーククラス）
        /// </summary>
        /// <param name="extraInfo">抽出条件クラス</param>
        /// <returns>抽出条件ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件クラスから抽出条件ワーククラスへメンバーのコピーを行います。</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private SumExtrInfo_DemandTotalWork CopyToExtraInfoWorkFromExtraInfo(SumExtrInfo_DemandTotal extraInfo)
        {
            SumExtrInfo_DemandTotalWork extraInfoWork = new SumExtrInfo_DemandTotalWork();

            // 拠点
            if (extraInfo.ResultsAddUpSecList.Length != 0)
            {
                if (extraInfo.ResultsAddUpSecList[0] == "")
                {
                    // 全社の時
                    extraInfoWork.ResultsAddUpSecList = new string[1];						// 拠点コード
                    extraInfoWork.ResultsAddUpSecList[0] = "";
                }
                else
                {
                    extraInfoWork.ResultsAddUpSecList = extraInfo.ResultsAddUpSecList;      // 拠点コード
                }
            }
            else
            {
                extraInfoWork.ResultsAddUpSecList = new string[0];                          // 拠点コード
            }

            extraInfoWork.AddUpDate = extraInfo.AddUpDate;                          // 締日
            
            if (extraInfo.CustomerAgentDivCd == 0)
            {
                extraInfoWork.CustomerAgentCdSt = extraInfo.CustomerAgentCdSt;      // 顧客担当者(開始)
                extraInfoWork.CustomerAgentCdEd = extraInfo.CustomerAgentCdEd;      // 顧客担当者(終了)
                extraInfoWork.BillCollecterCdSt = "";                               // 集金担当者(開始)
                extraInfoWork.BillCollecterCdEd = "";                               // 集金担当者(終了)
            }
            else
            {
                extraInfoWork.BillCollecterCdSt = extraInfo.BillCollecterCdSt;      // 集金担当者(開始)
                extraInfoWork.BillCollecterCdEd = extraInfo.BillCollecterCdEd;      // 集金担当者(終了)
                extraInfoWork.CustomerAgentCdSt = "";                               // 顧客担当者(開始)
                extraInfoWork.CustomerAgentCdEd = "";                               // 顧客担当者(終了)
            }

            extraInfoWork.SalesAreaCodeSt = extraInfo.SalesAreaCodeSt;              // 販売エリアコード(開始)
            extraInfoWork.SalesAreaCodeEd = extraInfo.SalesAreaCodeEd;              // 販売エリアコード(終了)
            
            extraInfoWork.CustomerCodeSt = extraInfo.CustomerCodeSt;                // 得意先コード(開始)
            extraInfoWork.CustomerCodeEd = extraInfo.CustomerCodeEd;                // 得意先コード(終了)
            extraInfoWork.EnterpriseCode = extraInfo.EnterpriseCode;                // 企業コード
            
            extraInfoWork.SlipPrtKind = extraInfo.SlipPrtKind;                      // 伝票印刷種別

            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
            _taxReductionDone = IsTaxReductionDone();
            if (_taxReductionDone)
            {
                // 税別内訳印字区分
                SetPropertyValue(extraInfoWork, "TaxPrintDiv", (int)GetPropertyValue(extraInfo, "TaxPrintDiv"));
                // 税率1
                SetPropertyValue(extraInfoWork, "TaxRate1", (double)GetPropertyValue(extraInfo, "TaxRate1"));
                // 税率2
                SetPropertyValue(extraInfoWork, "TaxRate2", (double)GetPropertyValue(extraInfo, "TaxRate2"));
            }
            else
            {
                // 税別内訳印字区分
                SetPropertyValue(extraInfoWork, "TaxPrintDiv", 1);
            }
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
            
            return extraInfoWork;
        }
        
        #endregion

        // ===============================================================================
        // ICompare実装部
        // ===============================================================================
        #region ICompare の実装部
        /// <summary>
        /// 拠点コード並べ替え用KEY
        /// </summary>
        class SecInfoKey0 : IComparer
        {
            public int Compare(object x, object y)
            {
                string cx, cy;
                cx = x.ToString();
                cy = y.ToString();

                return cx.CompareTo(cy);
            }
        }
        #endregion

        /// <summary>
        /// フィルター用の計算後請求金額を設定
        /// </summary>
        private void SetAfCalDemandPriceFilter()
        {
            for (int i = 0; i < this._custDmdPrcDataTable.Rows.Count; i++)
            {
                // 計上拠点コードと総括得意先コードでキー作成
                string sectionCd = (string)this._custDmdPrcDataTable.Rows[i][CT_CsDmd_AddUpSecCode];
                string claimCode = ((int)this._custDmdPrcDataTable.Rows[i][CT_CsDmd_SumClaimCustCode]).ToString("d08");
                string key = sectionCd.TrimEnd() + "-" + claimCode;

                // 計算後請求金額の取得
                long afCalDemandPrice = 0;
                if (afCalDemandPriceDic.ContainsKey(key))
                {
                    afCalDemandPrice = afCalDemandPriceDic[key];
                }
                // 計算後請求金額(フィルター用)に設定
                this._custDmdPrcDataTable.Rows[i][CT_CsDmd_AfCalDemandPriceFilter] = afCalDemandPrice;
            }
        }

        /// <summary>
        /// 総括レコード作成処理
        /// </summary>
        /// <param name="extraInfo">抽出条件</param>
        /// <remarks>
        /// <br>Note       : 集計レコードから総括レコードを作成します。</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private void CreateSumDmdRow(SumExtrInfo_DemandTotal extraInfo)
        {
            foreach (int sumClaimCustCode in _sumClaimCustCodeList)
            {
                DataRow newRow = this._custDmdPrcDataTable.NewRow();
                newRow.BeginEdit();

                this._custDmdPrcDataTable.DefaultView.RowFilter = CT_CsDmd_SumClaimCustCode + " = " + sumClaimCustCode.ToString();
                // 2010/03/12 Add 該当なしの場合はコンティニュー >>>
                if (this._custDmdPrcDataTable.DefaultView.Count == 0)
                    continue;
                // 2010/03/12 Add <<<
                for (int i = 0; i < this._custDmdPrcDataTable.DefaultView.Count; i++)
                {
                    DataRow sumClaimCustRow = this._custDmdPrcDataTable.DefaultView[i].Row;

                    if (i == 0)
                    {
                        // １レコード目の集計レコードの内容をコピー
                        newRow[CT_CsDmd_DataType] = true;   // レコードタイプ
                        newRow[CT_CsDmd_RecordName] = "総括レコード";   // レコード名称
                        newRow[CT_CsDmd_PrintFlag] = true;  // 印刷フラグ
                        newRow[CT_CsDmd_AddUpSecCode] = sumClaimCustRow[CT_CsDmd_AddUpSecCode];     // 計上拠点コード
                        newRow[CT_CsDmd_AddUpSecName] = sumClaimCustRow[CT_CsDmd_AddUpSecName];     // 計上拠点名称
                        newRow[CT_CsDmd_ClaimSectionCode] = sumClaimCustRow[CT_CsDmd_ClaimSectionCode];     // 請求拠点コード
                        newRow[CT_CsDmd_ClaimSectionName] = sumClaimCustRow[CT_CsDmd_ClaimSectionName];     // 請求拠点名称
                        newRow[CT_CsDmd_ResultsSectCd] = sumClaimCustRow[CT_CsDmd_ResultsSectCd];       // 実績拠点コード
                        newRow[CT_CsDmd_SumClaimCustCode] = sumClaimCustRow[CT_CsDmd_SumClaimCustCode];     // 総括得意先コード
                        newRow[CT_CsDmd_SumClaimCustCodeDisp] = sumClaimCustRow[CT_CsDmd_SumClaimCustCodeDisp];     // 総括得意先コード(抽出結果表示用)
                        newRow[CT_CsDmd_SumClaimCustSnm] = sumClaimCustRow[CT_CsDmd_SumClaimCustSnm];   // 総括得意先略称
                        newRow[CT_CsDmd_ClaimCode] = 0;     // 請求先コード
                        newRow[CT_CsDmd_ClaimCodeDisp] = "00000000";    // 請求先コード(抽出結果表示用)
                        newRow[CT_CsDmd_ClaimSnm] = string.Empty;       // 請求先略称
                        newRow[CT_CsDmd_AddUpDateInt] = sumClaimCustRow[CT_CsDmd_AddUpDateInt];     // 計上年月日(Int型)
                        newRow[CT_CsDmd_CustomerAgentCd] = sumClaimCustRow[CT_CsDmd_CustomerAgentCd];       // 顧客担当従業員コード
                        newRow[CT_CsDmd_CustomerAgentNm] = sumClaimCustRow[CT_CsDmd_CustomerAgentNm];       // 顧客担当従業員名称
                        newRow[CT_CsDmd_BillCollecterCd] = sumClaimCustRow[CT_CsDmd_BillCollecterCd];       // 集金担当従業員コード
                        newRow[CT_CsDmd_BillCollecterNm] = sumClaimCustRow[CT_CsDmd_BillCollecterNm];       // 集金担当従業員名称
                        newRow[CT_CsDmd_SalesAreaCode] = sumClaimCustRow[CT_CsDmd_SalesAreaCode];       // 販売エリアコード
                        newRow[CT_CsDmd_SalesAreaName] = sumClaimCustRow[CT_CsDmd_SalesAreaName];       // 販売エリア名称
                        newRow[CT_Blnce_BillOutputCode] = sumClaimCustRow[CT_Blnce_BillOutputCode];     // 請求書出力区分コード
                        // --- ADD  大矢睦美  2010/02/01 ---------->>>>>
                        newRow[CT_Blnce_TotalBillOutputDiv] = sumClaimCustRow[CT_Blnce_TotalBillOutputDiv];   //合計請求書出力区分コード
                        newRow[CT_Blnce_DetailBillOutputCode] = sumClaimCustRow[CT_Blnce_DetailBillOutputCode];   //明細請求書出力区分コード
                        newRow[CT_Blnce_SlipTtlBillOutputDiv] = sumClaimCustRow[CT_Blnce_SlipTtlBillOutputDiv];   //伝票合計請求書出力区分コード
                        // --- ADD  大矢睦美  2010/02/01 ----------<<<<<

                        newRow[CT_CsDmd_DemandBalance] = sumClaimCustRow[CT_CsDmd_DemandBalance];   // 請求残高
                        newRow[CT_CsDmd_ThisTimeDmdNrml] = sumClaimCustRow[CT_CsDmd_ThisTimeDmdNrml];   // 今回入金金額（通常入金）
                        newRow[CT_CsDmd_ThisTimeTtlBlcDmd] = sumClaimCustRow[CT_CsDmd_ThisTimeTtlBlcDmd];   // 今回繰越残高（請求計）
                        newRow[CT_CsDmd_ThisTimeSales] = sumClaimCustRow[CT_CsDmd_ThisTimeSales];   // 今回売上金額
                        newRow[CT_CsDmd_ThisSalesPricRgdsDis] = sumClaimCustRow[CT_CsDmd_ThisSalesPricRgdsDis];     // 今回売上返品・値引金額
                        newRow[CT_CsDmd_NetSales] = sumClaimCustRow[CT_CsDmd_NetSales];     // 純売上額
                        newRow[CT_CsDmd_OfsThisTimeSales] = sumClaimCustRow[CT_CsDmd_OfsThisTimeSales];     // 相殺後今回売上金額
                        newRow[CT_CsDmd_OfsThisSalesTax] = sumClaimCustRow[CT_CsDmd_OfsThisSalesTax];       // 相殺後今回売上消費税
                        newRow[CT_CsDmd_OfsThisSalesSum] = sumClaimCustRow[CT_CsDmd_OfsThisSalesSum];       // 相殺後今回合計売上金額
                        newRow[CT_CsDmd_AfCalDemandPrice] = sumClaimCustRow[CT_CsDmd_AfCalDemandPrice];     // 計算後請求金額
                        newRow[CT_CsDmd_CollectDemand] = sumClaimCustRow[CT_CsDmd_CollectDemand];       // 回収残高(合計部計算用)
                        newRow[CT_CsDmd_SaleslSlipCount] = sumClaimCustRow[CT_CsDmd_SaleslSlipCount];   // 売上伝票枚数
                        newRow[CT_Blnce_AcpOdrTtl3TmBfBlDmd] = sumClaimCustRow[CT_Blnce_AcpOdrTtl3TmBfBlDmd];   // 受注３回前残高(前々々回)
                        newRow[CT_Blnce_AcpOdrTtl2TmBfBlDmd] = sumClaimCustRow[CT_Blnce_AcpOdrTtl2TmBfBlDmd];   // 受注２回前残高(前々回)
                        newRow[CT_CsDmd_LastTimeDemand] = sumClaimCustRow[CT_CsDmd_LastTimeDemand];     // 前回請求額
                        newRow[CT_Blnce_MoneyKindDiv101] = sumClaimCustRow[CT_Blnce_MoneyKindDiv101];   // 現金(金種区分)
                        newRow[CT_Blnce_MoneyKindDiv102] = sumClaimCustRow[CT_Blnce_MoneyKindDiv102];   // 振込(金種区分)
                        newRow[CT_Blnce_MoneyKindDiv107] = sumClaimCustRow[CT_Blnce_MoneyKindDiv107];   // 小切手(金種区分)
                        newRow[CT_Blnce_MoneyKindDiv105] = sumClaimCustRow[CT_Blnce_MoneyKindDiv105];   // 手形(金種区分)
                        newRow[CT_Blnce_MoneyKindDiv106] = sumClaimCustRow[CT_Blnce_MoneyKindDiv106];   // 相殺(金種区分)
                        newRow[CT_Blnce_MoneyKindDiv112] = sumClaimCustRow[CT_Blnce_MoneyKindDiv112];   // 口座振替(金種区分)
                        newRow[CT_Blnce_MoneyKindDiv109] = sumClaimCustRow[CT_Blnce_MoneyKindDiv109];   // その他(金種区分)
                        newRow[CT_CsDmd_ThisTimeFeeDmdNrml] = sumClaimCustRow[CT_CsDmd_ThisTimeFeeDmdNrml];     // 今回手数料額（通常入金）
                        newRow[CT_CsDmd_ThisTimeDisDmdNrml] = sumClaimCustRow[CT_CsDmd_ThisTimeDisDmdNrml];     // 今回値引額(通常入金)
                        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                        // 売上額(計税率1)
                        newRow[Col_TotalThisTimeSalesTaxRate1] = sumClaimCustRow[Col_TotalThisTimeSalesTaxRate1];
                        // 売上額(計税率2)
                        newRow[Col_TotalThisTimeSalesTaxRate2] = sumClaimCustRow[Col_TotalThisTimeSalesTaxRate2];
                        // 売上額(計その他)
                        newRow[Col_TotalThisTimeSalesOther] = sumClaimCustRow[Col_TotalThisTimeSalesOther];
                        // 返品値引(計税率1)
                        newRow[Col_TotalThisRgdsDisPricTaxRate1] = sumClaimCustRow[Col_TotalThisRgdsDisPricTaxRate1];
                        // 返品値引(計税率2)
                        newRow[Col_TotalThisRgdsDisPricTaxRate2] = sumClaimCustRow[Col_TotalThisRgdsDisPricTaxRate2];
                        // 返品値引(計その他)
                        newRow[Col_TotalThisRgdsDisPricOther] = sumClaimCustRow[Col_TotalThisRgdsDisPricOther];
                        // 純売上額(計税率1)
                        newRow[Col_TotalPureSalesTaxRate1] = sumClaimCustRow[Col_TotalPureSalesTaxRate1];
                        // 純売上額(計税率2)
                        newRow[Col_TotalPureSalesTaxRate2] = sumClaimCustRow[Col_TotalPureSalesTaxRate2];
                        // 純売上額(計その他)
                        newRow[Col_TotalPureSalesOther] = sumClaimCustRow[Col_TotalPureSalesOther];
                        // 消費税(計税率1)
                        newRow[Col_TotalSalesPricTaxTaxRate1] = sumClaimCustRow[Col_TotalSalesPricTaxTaxRate1];
                        // 消費税(計税率2)
                        newRow[Col_TotalSalesPricTaxTaxRate2] = sumClaimCustRow[Col_TotalSalesPricTaxTaxRate2];
                        // 消費税(計その他)
                        newRow[Col_TotalSalesPricTaxOther] = sumClaimCustRow[Col_TotalSalesPricTaxOther];
                        // 今回合計(計税率1)
                        newRow[Col_TotalThisSalesSumTaxRate1] = sumClaimCustRow[Col_TotalThisSalesSumTaxRate1];
                        // 今回合計(計税率2)
                        newRow[Col_TotalThisSalesSumTaxRate2] = sumClaimCustRow[Col_TotalThisSalesSumTaxRate2];
                        // 今回合計(計その他)
                        newRow[Col_TotalThisSalesSumTaxOther] = sumClaimCustRow[Col_TotalThisSalesSumTaxOther];
                        // 枚数(計税率1)
                        newRow[Col_TotalSalesSlipCountTaxRate1] = sumClaimCustRow[Col_TotalSalesSlipCountTaxRate1];
                        // 枚数(計税率2)
                        newRow[Col_TotalSalesSlipCountTaxRate2] = sumClaimCustRow[Col_TotalSalesSlipCountTaxRate2];
                        // 枚数(計その他)
                        newRow[Col_TotalSalesSlipCountOther] = sumClaimCustRow[Col_TotalSalesSlipCountOther];
                        // 税率1タイトル
                        newRow[Col_TitleTaxRate1] = sumClaimCustRow[Col_TitleTaxRate1];
                        // 税率2タイトル
                        newRow[Col_TitleTaxRate2] = sumClaimCustRow[Col_TitleTaxRate2];
                        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
                        //--- ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                        // 売上額(計非課税)
                        newRow[Col_TotalThisTimeSalesTaxFree] = sumClaimCustRow[Col_TotalThisTimeSalesTaxFree];
                        // 返品値引(計非課税)
                        newRow[Col_TotalThisRgdsDisPricTaxFree] = sumClaimCustRow[Col_TotalThisRgdsDisPricTaxFree];
                        // 純売上額(計非課税)
                        newRow[Col_TotalPureSalesTaxFree] = sumClaimCustRow[Col_TotalPureSalesTaxFree];
                        // 消費税(計非課税)
                        newRow[Col_TotalSalesPricTaxTaxFree] = sumClaimCustRow[Col_TotalSalesPricTaxTaxFree];
                        // 今回合計(計非課税)
                        newRow[Col_TotalThisSalesSumTaxFree] = sumClaimCustRow[Col_TotalThisSalesSumTaxFree];
                        // 枚数(計非課税)
                        newRow[Col_TotalSalesSlipCountTaxFree] = sumClaimCustRow[Col_TotalSalesSlipCountTaxFree];
                        //--- ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    }
                    else
                    {
                        // ２レコード目以降は金額を集計
                        newRow[CT_CsDmd_DemandBalance] = (long)newRow[CT_CsDmd_DemandBalance] + (long)sumClaimCustRow[CT_CsDmd_DemandBalance];      // 請求残高
                        newRow[CT_CsDmd_ThisTimeDmdNrml] = (long)newRow[CT_CsDmd_ThisTimeDmdNrml] + (long)sumClaimCustRow[CT_CsDmd_ThisTimeDmdNrml];    // 今回入金金額（通常入金）
                        newRow[CT_CsDmd_ThisTimeTtlBlcDmd] = (long)newRow[CT_CsDmd_ThisTimeTtlBlcDmd] + (long)sumClaimCustRow[CT_CsDmd_ThisTimeTtlBlcDmd];  // 今回繰越残高（請求計）
                        newRow[CT_CsDmd_ThisTimeSales] = (long)newRow[CT_CsDmd_ThisTimeSales] + (long)sumClaimCustRow[CT_CsDmd_ThisTimeSales];      // 今回売上金額
                        newRow[CT_CsDmd_ThisSalesPricRgdsDis] = (long)newRow[CT_CsDmd_ThisSalesPricRgdsDis] + (long)sumClaimCustRow[CT_CsDmd_ThisSalesPricRgdsDis];     // 今回売上返品・値引金額
                        newRow[CT_CsDmd_NetSales] = (long)newRow[CT_CsDmd_NetSales] + (long)sumClaimCustRow[CT_CsDmd_NetSales];     // 純売上額
                        newRow[CT_CsDmd_OfsThisTimeSales] = (long)newRow[CT_CsDmd_OfsThisTimeSales] + (long)sumClaimCustRow[CT_CsDmd_OfsThisTimeSales];     // 相殺後今回売上金額
                        newRow[CT_CsDmd_OfsThisSalesTax] = (long)newRow[CT_CsDmd_OfsThisSalesTax] + (long)sumClaimCustRow[CT_CsDmd_OfsThisSalesTax];        // 相殺後今回売上消費税
                        newRow[CT_CsDmd_OfsThisSalesSum] = (long)newRow[CT_CsDmd_OfsThisSalesSum] + (long)sumClaimCustRow[CT_CsDmd_OfsThisSalesSum];        // 相殺後今回合計売上金額
                        newRow[CT_CsDmd_AfCalDemandPrice] = (long)newRow[CT_CsDmd_AfCalDemandPrice] + (long)sumClaimCustRow[CT_CsDmd_AfCalDemandPrice];     // 計算後請求金額
                        newRow[CT_CsDmd_CollectDemand] = (long)newRow[CT_CsDmd_CollectDemand] + (long)sumClaimCustRow[CT_CsDmd_CollectDemand];      // 回収残高(合計部計算用)
                        newRow[CT_CsDmd_SaleslSlipCount] = (int)newRow[CT_CsDmd_SaleslSlipCount] + (int)sumClaimCustRow[CT_CsDmd_SaleslSlipCount];      // 売上伝票枚数
                        newRow[CT_Blnce_AcpOdrTtl3TmBfBlDmd] = (long)newRow[CT_Blnce_AcpOdrTtl3TmBfBlDmd] + (long)sumClaimCustRow[CT_Blnce_AcpOdrTtl3TmBfBlDmd];    // 受注３回前残高(前々々回)
                        newRow[CT_Blnce_AcpOdrTtl2TmBfBlDmd] = (long)newRow[CT_Blnce_AcpOdrTtl2TmBfBlDmd] + (long)sumClaimCustRow[CT_Blnce_AcpOdrTtl2TmBfBlDmd];    // 受注２回前残高(前々回)
                        newRow[CT_CsDmd_LastTimeDemand] = (long)newRow[CT_CsDmd_LastTimeDemand] + (long)sumClaimCustRow[CT_CsDmd_LastTimeDemand];       // 前回請求額
                        newRow[CT_Blnce_MoneyKindDiv101] = (long)newRow[CT_Blnce_MoneyKindDiv101] + (long)sumClaimCustRow[CT_Blnce_MoneyKindDiv101];    // 現金(金種区分)
                        newRow[CT_Blnce_MoneyKindDiv102] = (long)newRow[CT_Blnce_MoneyKindDiv102] + (long)sumClaimCustRow[CT_Blnce_MoneyKindDiv102];    // 振込(金種区分)
                        newRow[CT_Blnce_MoneyKindDiv107] = (long)newRow[CT_Blnce_MoneyKindDiv107] + (long)sumClaimCustRow[CT_Blnce_MoneyKindDiv107];    // 小切手(金種区分)
                        newRow[CT_Blnce_MoneyKindDiv105] = (long)newRow[CT_Blnce_MoneyKindDiv105] + (long)sumClaimCustRow[CT_Blnce_MoneyKindDiv105];    // 手形(金種区分)
                        newRow[CT_Blnce_MoneyKindDiv106] = (long)newRow[CT_Blnce_MoneyKindDiv106] + (long)sumClaimCustRow[CT_Blnce_MoneyKindDiv106];    // 相殺(金種区分)
                        newRow[CT_Blnce_MoneyKindDiv112] = (long)newRow[CT_Blnce_MoneyKindDiv112] + (long)sumClaimCustRow[CT_Blnce_MoneyKindDiv112];    // 口座振替(金種区分)
                        newRow[CT_Blnce_MoneyKindDiv109] = (long)newRow[CT_Blnce_MoneyKindDiv109] + (long)sumClaimCustRow[CT_Blnce_MoneyKindDiv109];    // その他(金種区分)
                        newRow[CT_CsDmd_ThisTimeFeeDmdNrml] = (long)newRow[CT_CsDmd_ThisTimeFeeDmdNrml] + (long)sumClaimCustRow[CT_CsDmd_ThisTimeFeeDmdNrml];   // 今回手数料額（通常入金）
                        newRow[CT_CsDmd_ThisTimeDisDmdNrml] = (long)newRow[CT_CsDmd_ThisTimeDisDmdNrml] + (long)sumClaimCustRow[CT_CsDmd_ThisTimeDisDmdNrml];   // 今回値引額(通常入金)
                        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                        // 売上額(計税率1)
                        newRow[Col_TotalThisTimeSalesTaxRate1] = (long)newRow[Col_TotalThisTimeSalesTaxRate1] + (long)sumClaimCustRow[Col_TotalThisTimeSalesTaxRate1];
                        // 売上額(計税率2)
                        newRow[Col_TotalThisTimeSalesTaxRate2] = (long)newRow[Col_TotalThisTimeSalesTaxRate2] + (long)sumClaimCustRow[Col_TotalThisTimeSalesTaxRate2];
                        // 売上額(計その他)
                        newRow[Col_TotalThisTimeSalesOther] = (long)newRow[Col_TotalThisTimeSalesOther] + (long)sumClaimCustRow[Col_TotalThisTimeSalesOther];
                        // 返品値引(計税率1)
                        newRow[Col_TotalThisRgdsDisPricTaxRate1] = (long)newRow[Col_TotalThisRgdsDisPricTaxRate1] + (long)sumClaimCustRow[Col_TotalThisRgdsDisPricTaxRate1];
                        // 返品値引(計税率2)
                        newRow[Col_TotalThisRgdsDisPricTaxRate2] = (long)newRow[Col_TotalThisRgdsDisPricTaxRate2] + (long)sumClaimCustRow[Col_TotalThisRgdsDisPricTaxRate2];
                        // 返品値引(計その他)
                        newRow[Col_TotalThisRgdsDisPricOther] = (long)newRow[Col_TotalThisRgdsDisPricOther] + (long)sumClaimCustRow[Col_TotalThisRgdsDisPricOther];
                        // 純売上額(計税率1)
                        newRow[Col_TotalPureSalesTaxRate1] = (long)newRow[Col_TotalPureSalesTaxRate1] + (long)sumClaimCustRow[Col_TotalPureSalesTaxRate1];
                        // 純売上額(計税率2)
                        newRow[Col_TotalPureSalesTaxRate2] = (long)newRow[Col_TotalPureSalesTaxRate2] + (long)sumClaimCustRow[Col_TotalPureSalesTaxRate2];
                        // 純売上額(計その他)
                        newRow[Col_TotalPureSalesOther] = (long)newRow[Col_TotalPureSalesOther] + (long)sumClaimCustRow[Col_TotalPureSalesOther];
                        // 消費税(計税率1)
                        newRow[Col_TotalSalesPricTaxTaxRate1] = (long)newRow[Col_TotalSalesPricTaxTaxRate1] + (long)sumClaimCustRow[Col_TotalSalesPricTaxTaxRate1];
                        // 消費税(計税率2)
                        newRow[Col_TotalSalesPricTaxTaxRate2] = (long)newRow[Col_TotalSalesPricTaxTaxRate2] + (long)sumClaimCustRow[Col_TotalSalesPricTaxTaxRate2];
                        // 消費税(計その他)
                        newRow[Col_TotalSalesPricTaxOther] = (long)newRow[Col_TotalSalesPricTaxOther] + (long)sumClaimCustRow[Col_TotalSalesPricTaxOther];
                        // 今回合計(計税率1)
                        newRow[Col_TotalThisSalesSumTaxRate1] = (long)newRow[Col_TotalThisSalesSumTaxRate1] + (long)sumClaimCustRow[Col_TotalThisSalesSumTaxRate1];
                        // 今回合計(計税率2)
                        newRow[Col_TotalThisSalesSumTaxRate2] = (long)newRow[Col_TotalThisSalesSumTaxRate2] + (long)sumClaimCustRow[Col_TotalThisSalesSumTaxRate2];
                        // 今回合計(計その他)
                        newRow[Col_TotalThisSalesSumTaxOther] = (long)newRow[Col_TotalThisSalesSumTaxOther] + (long)sumClaimCustRow[Col_TotalThisSalesSumTaxOther];
                        // 枚数(計税率1)
                        newRow[Col_TotalSalesSlipCountTaxRate1] = (long)newRow[Col_TotalSalesSlipCountTaxRate1] + (long)sumClaimCustRow[Col_TotalSalesSlipCountTaxRate1];
                        // 枚数(計税率2)
                        newRow[Col_TotalSalesSlipCountTaxRate2] = (long)newRow[Col_TotalSalesSlipCountTaxRate2] + (long)sumClaimCustRow[Col_TotalSalesSlipCountTaxRate2];
                        // 枚数(計その他)
                        newRow[Col_TotalSalesSlipCountOther] = (long)newRow[Col_TotalSalesSlipCountOther] + (long)sumClaimCustRow[Col_TotalSalesSlipCountOther];
                        // 税率1タイトル
                        newRow[Col_TitleTaxRate1] = sumClaimCustRow[Col_TitleTaxRate1];
                        // 税率2タイトル
                        newRow[Col_TitleTaxRate2] = sumClaimCustRow[Col_TitleTaxRate2];
                        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
                        //--- ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
                        // 売上額(計非課税)
                        newRow[Col_TotalThisTimeSalesTaxFree] = (long)newRow[Col_TotalThisTimeSalesTaxFree] + (long)sumClaimCustRow[Col_TotalThisTimeSalesTaxFree];
                        // 返品値引(計非課税)
                        newRow[Col_TotalThisRgdsDisPricTaxFree] = (long)newRow[Col_TotalThisRgdsDisPricTaxFree] + (long)sumClaimCustRow[Col_TotalThisRgdsDisPricTaxFree];
                        // 純売上額(計非課税)
                        newRow[Col_TotalPureSalesTaxFree] = (long)newRow[Col_TotalPureSalesTaxFree] + (long)sumClaimCustRow[Col_TotalPureSalesTaxFree];
                        // 消費税(計非課税)
                        newRow[Col_TotalSalesPricTaxTaxFree] = (long)newRow[Col_TotalSalesPricTaxTaxFree] + (long)sumClaimCustRow[Col_TotalSalesPricTaxTaxFree];
                        // 今回合計(計非課税)
                        newRow[Col_TotalThisSalesSumTaxFree] = (long)newRow[Col_TotalThisSalesSumTaxFree] + (long)sumClaimCustRow[Col_TotalThisSalesSumTaxFree];
                        // 枚数(計非課税)
                        newRow[Col_TotalSalesSlipCountTaxFree] = (long)newRow[Col_TotalSalesSlipCountTaxFree] + (long)sumClaimCustRow[Col_TotalSalesSlipCountTaxFree];
                        //--- ADD 2022/08/30 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
                    }
                    // --- ADD  大矢睦美  2010/02/24 ---------->>>>>
                    // キャッシュ登録のKEY生成
                    string key = ((string)sumClaimCustRow[CT_CsDmd_AddUpSecCode]).TrimEnd() + "-" + ((int)sumClaimCustRow[CT_CsDmd_SumClaimCustCode]).ToString("d08");
                    // 金額集計
                    long afCalDemandPrice;
                    if (afCalDemandPriceDic.ContainsKey(key))
                    {
                        afCalDemandPrice = afCalDemandPriceDic[key] + (long)sumClaimCustRow[CT_CsDmd_AfCalDemandPrice];
                        afCalDemandPriceDic.Remove(key);
                    }
                    else
                    {
                        afCalDemandPrice = (long)sumClaimCustRow[CT_CsDmd_AfCalDemandPrice];
                    }
                    afCalDemandPriceDic.Add(key, afCalDemandPrice);
                    // --- ADD  大矢睦美  2010/02/24 ----------<<<<<                    
                }

                // 得意先情報の取得（集金月区分名称、集金日）
                CustomerInfo customerInfo;
                int status = GetCustomerInfo((int)newRow[CT_CsDmd_SumClaimCustCode], extraInfo.EnterpriseCode, out customerInfo);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    newRow[CT_CsDmd_CollectMoneyName] = customerInfo.CollectMoneyName;// 集金月区分名称
                    newRow[CT_CsDmd_CollectMoneyDay] = customerInfo.CollectMoneyDay;// 集金日
                    // 集金日(印刷用)
                    if (customerInfo.CollectMoneyDay != 0)
                    {
                        // 請求書末日印字区分 = 1(28～31日は末日と印字) で28日以降の場合
                        if (customerInfo.CollectMoneyDay >= 28 && _billPrtSt.BillLastDayPrtDiv == 1)
                        {
                            newRow[CT_CsDmd_CollectMoneyDayNm] = "末日";
                        }
                        else
                        {
                            newRow[CT_CsDmd_CollectMoneyDayNm] = String.Format("{0}日", customerInfo.CollectMoneyDay);
                        }
                    }
                    else
                    {
                        newRow[CT_CsDmd_CollectMoneyDayNm] = "";
                    }
                }

                // 今回消費税
                if (_allDefSet.TotalAmountDispWayCd == 0)
                {
                    // 総額表示しない税抜き
                    newRow[CT_CsDmd_PrintTtlConsTaxDmd] = ((long)newRow[CT_CsDmd_OfsThisSalesTax]).ToString("#,##0");
                }
                else
                {
                    // 総額表示する税込み
                    newRow[CT_CsDmd_PrintTtlConsTaxDmd] = "(" + ((long)newRow[CT_CsDmd_OfsThisSalesTax]).ToString("#,##0") + ")";
                }

                // 回収率計算
                double collectRate = 0.0;
                if (((long)newRow[CT_CsDmd_CollectDemand] != 0) && ((long)newRow[CT_CsDmd_ThisTimeDmdNrml] != 0))
                {
                    collectRate = double.Parse(newRow[CT_CsDmd_ThisTimeDmdNrml].ToString()) * 100 / double.Parse(newRow[CT_CsDmd_CollectDemand].ToString());
                }
                newRow[CT_CsDmd_CollectRate] = collectRate;

                newRow.EndEdit();

                this._custDmdPrcDataTable.Rows.Add(newRow);
            }

            this._custDmdPrcDataTable.DefaultView.RowFilter = string.Empty;
        }

        /// <summary>
        /// 得意先マスタの取得
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerInfo">得意先情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタの情報を取得します。</br>
        /// <br></br>
        /// </remarks>
        private int GetCustomerInfo(int customerCode, string enterpriseCode, out CustomerInfo customerInfo)
        {
            int status;

            customerInfo = new CustomerInfo();

            try
            {
                status = _customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, enterpriseCode, customerCode, true, out customerInfo);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    customerInfo = new CustomerInfo();
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">ステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">デフォルトフォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージ表示の出力を行います。</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "請求書発行(総括)データ抽出処理", iMsg, iSt, iButton, iDefButton);
        }

        // 2010/07/01 Add >>>
        /// <summary>
        /// 名称１と名称２を結合します。
        /// </summary>
        /// <param name="name1">名称１</param>
        /// <param name="name2">名称２</param>
        /// <returns></returns>
        private string nameJoin(string name1, string name2)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            int count = sjisEnc.GetByteCount(name1);
            int spaceCount = 0;
            string n1 = "";
            string n2 = "";
            if (count <= 20)
            {
                spaceCount = 20 - count;
                if (sjisEnc.GetByteCount(name2) > 20)
                {
                    n2 = name2.Substring(0, 10);
                }
                else
                {
                    n2 = name2;
                }
                n1 = name1;
                for (; spaceCount > 0; spaceCount--)
                {
                    n1 = n1 + " ";
                }
                return n1 + n2;
            }
            else if (count < 40)
            {
                if (sjisEnc.GetByteCount(name2) > 40 - count)
                {
                    n2 = name2.Substring(0, (40 - count) / 2);
                }
                else
                {
                    n2 = name2;
                }
                return name1 + n2;
            }
            else
            {
                return name1;
            }
        }
        // 2010/07/01 Add <<<

        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
        #region 軽減税率対応済か
        /// <summary>
        /// 軽減税率対応したか判定処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private bool IsTaxReductionDone()
        {
            // 軽減税率対応したか
            bool doneFlag = false;

            // Uクラス
            PMHNB02252UA uiObj = new PMHNB02252UA();
            doneFlag = ContainMember(uiObj, "TaxReductionUIDone");
            if (!doneFlag) return doneFlag;

            // Eクラス
            SumExtrInfo_DemandTotal demandTotal = new SumExtrInfo_DemandTotal();
            doneFlag = ContainProperty(demandTotal, "TaxPrintDiv");
            if (!doneFlag) return doneFlag;

            // Dクラス
            SumExtrInfo_DemandTotalWork demandTotalWork = new SumExtrInfo_DemandTotalWork();
            doneFlag = ContainProperty(demandTotalWork, "TaxPrintDiv");

            return doneFlag;
        }

        /// <summary>
        /// ワークにパラメータが存在するか判定処理
        /// </summary>
        /// <param name="instance">ワーク対象</param>
        /// <param name="propertyName">パラメータ名</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private bool ContainProperty(object instance, string propertyName)
        {
            // ワークにパラメータが存在するかフラグ
            bool existFlag = false;

            if (instance != null && !string.IsNullOrEmpty(propertyName))
            {
                PropertyInfo findedPropertyInfo = instance.GetType().GetProperty(propertyName);

                if (findedPropertyInfo != null)
                {
                    existFlag = true;
                }
            }

            return existFlag;
        }

        /// <summary>
        /// クラスにメンバーが存在するか判定処理
        /// </summary>
        /// <param name="instance">ワーク対象</param>
        /// <param name="propertyName">パラメータ名</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private bool ContainMember(object instance, string propertyName)
        {
            // ワークにパラメータが存在するかフラグ
            bool existFlag = false;

            if (instance != null)
            {
                MemberInfo[] findedMemberInfo = instance.GetType().GetMember(propertyName);

                // 変数がある場合、最新バジョーンとする
                if (findedMemberInfo != null && findedMemberInfo.Length > 0)
                {
                    existFlag = true;
                }
            }

            return existFlag;
        }

        /// <summary>
        /// パラメータ値を取得する処理
        /// </summary>
        /// <param name="instance">ワーク対象</param>
        /// <param name="propertyName">パラメータ名</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private object GetPropertyValue(object instance, string propertyName)
        {
            // パラメータ設定値
            object propertyValue = null;

            foreach (PropertyInfo p in instance.GetType().GetProperties())
            {
                if (propertyName.Equals(p.Name))
                {
                    propertyValue = p.GetValue(instance, null);
                    break;
                }
            }

            return propertyValue;
        }

        /// <summary>
        /// パラメータにセットする処理
        /// </summary>
        /// <param name="instance">ワーク対象</param>
        /// <param name="propertyName">パラメータ名</param>
        /// <param name="settingValue">設定値</param>
        /// <remarks>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private void SetPropertyValue(object instance, string propertyName, object settingValue)
        {
            foreach (PropertyInfo p in instance.GetType().GetProperties())
            {
                if (propertyName.Equals(p.Name))
                {
                    p.SetValue(instance, settingValue, null);
                    break;
                }
            }
        }
        #endregion
        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
    }
}

//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：請求帳票
// プログラム概要   ：請求帳票の印刷を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2008/09/04     修正内容：Partsman用に修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/07     修正内容：Mantis【11633】領収書出力区分による印刷制御追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/20     修正内容：Mantis【13192】抽出画面にレコード名を追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/03     修正内容：Mantis【13419】印刷時の範囲指定時、出力金額区分の不具合対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30531 大矢 睦美
// 修正日    2010/01/25     修正内容：Mantis【14928】請求書出力区分による印刷制御追加
//                                                   抽出結果に印刷対象の得意先のみを表示するよう修正 
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：凌小青
// 修正日    2011/11/17     修正内容：Redmine#7765の対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：凌小青
// 修正日    2011/11/28     修正内容：Redmine#7765の対応(再修正)
// ---------------------------------------------------------------------//
// 管理番号  11170129-00    作成担当：時シン
// 修正日    2015/09/17     修正内容：Redmine#47028の請求一覧表Out Of Memoryの対応
// ---------------------------------------------------------------------//
// 管理番号  11570208-00    作成担当：陳艶丹
// 修正日    2020/04/13     修正内容：PMKOBETSU-2912 軽減税率の対応
// ---------------------------------------------------------------------//
// 管理番号  11800255-00    作成担当：陳艶丹
// 修正日    2022/08/24     修正内容：PMKOBETSU-4225 インボイス対応（税率別合計金額不具合修正）
// ---------------------------------------------------------------------//
#define ADD20060410
#define CHG20060418
#define ADD20060425
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
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Collections;
// --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----->>>>>
using System.Reflection;
using Broadleaf.Windows.Forms;
// --- ADD 2020/04/13 陳艶丹 軽減税率対応 -----<<<<<

namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// 請求帳票抽出情報アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求帳票にアクセスするクラスです。</br>
    /// <br>Programer  : 980023  飯谷 耕平</br>
    /// <br>Date       : 2007.07.09</br>
    /// <br>Update Note: 20081 疋田 勇人
    /// <br>           : 2007.10.15 DC.NS用に変更</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.09.04</br>
    /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/04/13</br>
    /// </remarks>
    public class DemandPrintAcs
    {
        //================================================================================
        //  外部提供定数群
        //================================================================================
        #region public constant
        // システム区分
        private const int ctSYSTEMDIV_CD = 0;
        // 画像情報区分	
        private const int ctIMAGEINFODIV_CODE = 10;  // 10:自社画像 20:POSで使用する画像

        /// <summary>請求帳票データセット名</summary>
        public const string CT_DemandDataSet = "DemandDataSet";
        /// <summary>得意先請求金額データテーブル名</summary>
        public const string CT_CustDmdPrcDataTable = "CustDmdPrcDataTable";

        /// <summary>売上データセット名</summary>
        public const string CT_SaleDataSet = "SaleDataSet";
        /// <summary>売上データテーブル名</summary>
        public const string CT_SaleDataTable = "SaleDataTable";

        /// <summary>入金データセット名</summary>
        public const string CT_DepoDataSet = "DepoDataSet";
        /// <summary>入金データテーブル名</summary>
        public const string CT_DepoDataTable = "DepoDataTable";
        
        // 2008.09.05 30413 犬飼 桁数変更 >>>>>>START
        /// <summary>全拠点コード</summary>
        //public const string CT_AllSectionCode = "000000";
        public const string CT_AllSectionCode = "00";
        // 2008.09.05 30413 犬飼 桁数変更 <<<<<<END

        //--------------------------------------------------
        //  得意先請求金額カラム情報
        //--------------------------------------------------
        #region 得意先請求金額カラム情報
        /// <summary>ユニークID</summary>
        public const string CT_CsDmd_UniqueID = "UniqueID";

        /// <summary>レコードタイプ</summary>
        public const string CT_CsDmd_DataType = "DataType";

        // ADD 2009/04/20 ------>>>
        /// <summary>レコード名</summary>
        public const string CT_CsDmd_RecordName = "RecordName";
        // ADD 2009/04/20 ------<<<

        /// <summary>印刷フラグ</summary>
        public const string CT_CsDmd_PrintFlag = "PrintFlag";

        /// <summary>印刷用インデックス</summary>
        public const string CT_CsDmd_PrintIndex = "PrintIndex";

        /// <summary>計上拠点コード</summary>
        public const string CT_CsDmd_AddUpSecCode = "AddUpSecCode";

        /// <summary>計上拠点名称</summary>
        public const string CT_CsDmd_AddUpSecName = "AddUpSecName";

        // 2008.09.05 30413 犬飼 項目追加 >>>>>>START
        /// <summary>請求拠点コード</summary>
        public const string CT_CsDmd_ClaimSectionCode = "ClaimSectionCode";

        /// <summary>請求拠点名称</summary>
        public const string CT_CsDmd_ClaimSectionName = "ClaimSectionName";
        // 2008.09.05 30413 犬飼 項目追加 <<<<<<END

        // 2009.01.21 30413 犬飼 項目追加 >>>>>>START
        /// <summary>実績拠点コード</summary>
        public const string CT_CsDmd_ResultsSectCd = "ResultsSectCd";
        // 2009.01.21 30413 犬飼 項目追加 <<<<<<END
        
        /// <summary>請求書パターン番号</summary>
        public const string CT_CsDmd_DemandPtnNo = "DemandPtnNo";

        /// <summary>請求明細書パターン番号</summary>
        public const string CT_CsDmd_DmdDtlPtnNo = "DmdDtlPtnNo";

        /// <summary>請求書・支払書区分</summary>
        public const string CT_CsDmd_DemandOrPay = "DemandOrPay";

        /// <summary>請求先コード</summary>
        public const string CT_CsDmd_ClaimCode = "ClaimCode";

        // 2008.11.19 30413 犬飼 抽出結果表示用 >>>>>>START
        /// <summary>請求先コード(抽出結果表示用)</summary>
        public const string CT_CsDmd_ClaimCodeDisp = "ClaimCodeDisp";
        // 2008.11.19 30413 犬飼 抽出結果表示用 <<<<<<END

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

        // 2008.11.19 30413 犬飼 抽出結果表示用 >>>>>>START
        /// <summary>得意先コード(抽出結果表示用)</summary>
        public const string CT_CsDmd_CustomerCodeDisp = "CustomerCodeDisp";

        /// <summary>得意先略称(抽出結果表示用)</summary>
        public const string CT_CsDmd_CustomerSnmDisp = "CustomerSnmDisp";
        // 2008.11.19 30413 犬飼 抽出結果表示用 <<<<<<END
        
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

        // 2009.01.21 30413 犬飼 計算後請求金額(フィルター用)を追加 >>>>>>START
        /// <summary>計算後請求金額(フィルター用)</summary>
        public const string CT_CsDmd_AfCalDemandPriceFilter = "AfCalDemandPriceFilter";
        // 2009.01.21 30413 犬飼 計算後請求金額(フィルター用)を追加 <<<<<<END
            
        /// <summary>売上伝票枚数</summary>
        public const string CT_CsDmd_SaleslSlipCount = "SaleslSlipCount";

        /// <summary>請求書発行日</summary>
        public const string CT_CsDmd_BillPrintDate = "BillPrintDate";

        /// <summary>請求書発行日(印刷用)</summary>
        public const string CT_CsDmd_BillPrintDatePrt = "BillPrintDatePrt";

        /// <summary>入金予定日</summary>
        public const string CT_CsDmd_ExpectedDepositDate = "ExpectedDepositDate";

        /// <summary>入金予定日(印刷用)</summary>
        public const string CT_CsDmd_ExpectedDepositDatePrt = "ExpectedDepositDatePrt";

        /// <summary>回収条件</summary>
        /// <remarks>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</remarks>
        public const string CT_CsDmd_CollectCond = "CollectCond";

        /// <summary>消費税率</summary>
        public const string CT_CsDmd_ConsTaxRate = "ConsTaxRate";

        /// <summary>端数処理区分</summary>
        public const string CT_CsDmd_FractionProcCd = "FractionProcCd";

        /// <summary>締次更新実行年月日</summary>
        public const string CT_CsDmd_CAddUpUpdExecDate = "CAddUpUpdExecDate";

        /// <summary>締次更新実行年月日(印刷用)</summary>
        public const string CT_CsDmd_CAddUpUpdExecDatePrt = "CAddUpUpdExecDatePrt";

        /// <summary>締次更新開始年月日</summary>
        public const string CT_CsDmd_StartCAddUpUpdDate = "StartCAddUpUpdDate";

        /// <summary>締次更新開始年月日(印刷用)</summary>
        public const string CT_CsDmd_StartCAddUpUpdDatePrt = "StartCAddUpUpdDatePrt";

        /// <summary>前回締次更新年月日</summary>
        public const string CT_CsDmd_LastCAddUpUpdDate = "LastCAddUpUpdDate";

        /// <summary>前回締次更新年月日(印刷用)</summary>
        public const string CT_CsDmd_LastCAddUpUpdDatePrt = "LastCAddUpUpdDatePrt";

        /// <summary>計上日付(印刷用)</summary>
        public const string CT_CsDmd_AddUpADatePrint = "AddUpADatePrint";
        
        /// <summary>前回請求額(請求先)</summary>
        public const string CT_CsDmd_ClaimLastTimeDemand = "ClaimLastTimeDemand";

        /// <summary>今回入金金額（請求先）</summary>
        public const string CT_CsDmd_ClaimThisTimeDmdNrml = "ClaimThisTimeDmdNrml";

        /// <summary>今回繰越残高（請求先）</summary>
        public const string CT_CsDmd_ClaimThisTimeTtlBlcDmd = "ClaimThisTimeTtlBlcDmd";

        /// <summary>今回売上金額（請求先）</summary>
        public const string CT_CsDmd_ClaimThisTimeSales = "ClaimThisTimeSales";

        /// <summary>今回売上返品・値引金額（請求先）</summary>
        public const string CT_CsDmd_ClaimThisSalesPricRgdsDis = "ClaimThisSalesPricRgdsDis";

        /// <summary>相殺後今回売上金額（請求先）</summary>
        public const string CT_CsDmd_ClaimOfsThisTimeSales = "ClaimOfsThisTimeSales";

        /// <summary>相殺後今回売上消費税（請求先）</summary>
        public const string CT_CsDmd_ClaimOfsThisSalesTax = "ClaimOfsThisSalesTax";

        /// <summary>相殺後今回合計売上金額（請求先）</summary>
        public const string CT_CsDmd_ClaimOfsThisSalesSum = "ClaimOfsThisSalesSum";

        /// <summary>計算後請求金額（請求先）</summary>
        public const string CT_CsDmd_ClaimAfCalDemandPrice = "ClaimAfCalDemandPrice";

        /// <summary>売上伝票枚数（請求先）</summary>
        public const string CT_CsDmd_ClaimSaleslSlipCount = "ClaimSaleslSlipCount";
        #endregion

        //--------------------------------------------------
        //  得意先関連情報
        //--------------------------------------------------
        #region 得意先関連情報
        /// <summary>名称</summary>
        public const string CT_CsDmd_Name = "Name";

        /// <summary>名称２</summary>
        public const string CT_CsDmd_Name2 = "Name2";

        /// <summary>印刷用得意先名称１</summary>
        public const string CT_CsDmd_EditCustomerName1 = "EditCustomerName1";

        /// <summary>印刷用得意先名称２</summary>
        public const string CT_CsDmd_EditCustomerName2 = "EditCustomerName2";

        /// <summary>カナ</summary>
        public const string CT_CsDmd_Kana = "Kana";

        /// <summary>郵便番号</summary>
        public const string CT_CsDmd_PostNo = "PostNo";

        /// <summary>住所１（都道府県市区郡・町村・字）</summary>
        public const string CT_CsDmd_Address1 = "Address1";

        /// <summary>住所２（丁目）</summary>
        public const string CT_CsDmd_Address2 = "Address2";

        /// <summary>住所３（番地）</summary>
        public const string CT_CsDmd_Address3 = "Address3";

        /// <summary>住所４（アパート名称）</summary>
        public const string CT_CsDmd_Address4 = "Address4";

        /// <summary>編集後住所１（印刷用住所1行目）</summary>
        public const string CT_CsDmd_EditAddress1 = "EditAddress1";

        /// <summary>編集後住所２（印刷用住所2行目）</summary>
        public const string CT_CsDmd_EditAddress2 = "EditAddress2";

        /// <summary>編集後住所３（印刷用住所3行目）</summary>
        public const string CT_CsDmd_EditAddress3 = "EditAddress3";

        /// <summary>編集後住所１（リスト印刷用住所1行目）</summary>
        public const string CT_CsDmd_ListAddress1 = "ListAddress1";

        /// <summary>編集後住所２（リスト印刷用住所2行目）</summary>
        public const string CT_CsDmd_ListAddress2 = "ListAddress2";

        /// <summary>編集後住所３（リスト印刷用住所3行目）</summary>
        public const string CT_CsDmd_ListAddress3 = "ListAddress3";

        /// <summary>電話番号（自宅）</summary>
        public const string CT_CsDmd_HomeTelNo = "HomeTelNo";

        /// <summary>電話番号（勤務先）</summary>
        public const string CT_CsDmd_OfficeTelNo = "OfficeTelNo";

        /// <summary>電話番号（携帯）</summary>
        public const string CT_CsDmd_PortableTelNo = "PortableTelNo";

        /// <summary>FAX番号（自宅）</summary>
        public const string CT_CsDmd_HomeFaxNo = "HomeFaxNo";

        /// <summary>FAX番号（勤務先）</summary>
        public const string CT_CsDmd_OfficeFaxNo = "OfficeFaxNo";

        /// <summary>電話番号（その他）</summary>
        public const string CT_CsDmd_OthersTelNo = "OthersTelNo";

        /// <summary>主連絡先区分[0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･</summary>
        public const string CT_CsDmd_MainContactCode = "MainContactCode";

        /// <summary>主連絡先タイトル</summary>
        public const string CT_CsDmd_MainContactName = "MainContactName";

        /// <summary>主連絡先電話番号</summary>
        public const string CT_CsDmd_MainContactTelNo = "MainContactTelNo";

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

        /// <summary>御振込期限(印刷用)</summary>
        public const string CT_CsDmd_CollectMoneyDate = "CollectMoneyDate";

        /// <summary>御支払期限(印刷用)</summary>
        public const string CT_CsDmd_PaymentMoneyDate = "PaymentMoneyDate";

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

        /// <summary>敬称</summary>
        public const string CT_CsDmd_HonorificTitle = "HonorificTitle";

        /// <summary>諸口コード</summary>
        public const string CT_CsDmd_OutputNameCode = "OutputNameCode";

        /// <summary>諸口名称</summary>
        public const string CT_CsDmd_OutputName = "OutputName";

        /// <summary>得意先分析コード１</summary>
        public const string CT_CsDmd_CustAnalysCode1 = "CustAnalysCode1";
        /// <summary>得意先分析コード２</summary>
        public const string CT_CsDmd_CustAnalysCode2 = "CustAnalysCode2";
        /// <summary>得意先分析コード３</summary>
        public const string CT_CsDmd_CustAnalysCode3 = "CustAnalysCode3";
        /// <summary>得意先分析コード４</summary>
        public const string CT_CsDmd_CustAnalysCode4 = "CustAnalysCode4";
        /// <summary>得意先分析コード５</summary>
        public const string CT_CsDmd_CustAnalysCode5 = "CustAnalysCode5";
        /// <summary>得意先分析コード６</summary>
        public const string CT_CsDmd_CustAnalysCode6 = "CustAnalysCode6";

        /// <summary>得意先銀行1</summary>
        public const string CT_CsDmd_AccountNoInfoTK1 = "AccountNoInfoTK1";
        /// <summary>得意先銀行2</summary>
        public const string CT_CsDmd_AccountNoInfoTK2 = "AccountNoInfoTK2";
        /// <summary>得意先銀行3</summary>
        public const string CT_CsDmd_AccountNoInfoTK3 = "AccountNoInfoTK3";

        /// <summary>総額表示区分</summary>
        public const string CT_CsDmd_TotalAmountDispWayCd = "TotalAmountDispWayCd";
        #endregion
        
        //--------------------------------------------------
        //  自社名称情報(印刷用)
        //--------------------------------------------------
        #region 自社名称情報
        /// <summary>自社PR文</summary>
        public const string CT_CsDmd_CompanyPr = "CompanyPr";

        /// <summary>自社名称1</summary>
        public const string CT_CsDmd_CompanyName1 = "CompanyName1";

        /// <summary>自社名称2</summary>
        public const string CT_CsDmd_CompanyName2 = "CompanyName2";

        /// <summary>郵便番号</summary>
        public const string CT_CsDmd_CompanyPostNo = "CompanyPostNo";

        /// <summary>自社住所１行目(印刷用)</summary>
        public const string CT_CsDmd_EditCompanyAddress1 = "EditCompanyAddress1";

        /// <summary>自社住所２行目(印刷用)</summary>
        public const string CT_CsDmd_EditCompanyAddress2 = "EditCompanyAddress2";

        /// <summary>自社電話番号1(印刷用タイトル含む)</summary>
        public const string CT_CsDmd_EditCompanyTelNo1 = "EditCompanyTelNo1";

        /// <summary>自社電話番号2(印刷用タイトル含む)</summary>
        public const string CT_CsDmd_EditCompanyTelNo2 = "EditCompanyTelNo2";

        /// <summary>自社電話番号3(印刷用タイトル含む)</summary>
        public const string CT_CsDmd_EditCompanyTelNo3 = "EditCompanyTelNo3";

        /// <summary>銀行振込案内文</summary>
        public const string CT_CsDmd_TransferGuidance = "TransferGuidance";

        /// <summary>銀行口座1</summary>
        public const string CT_CsDmd_AccountNoInfo1 = "AccountNoInfo1";

        /// <summary>銀行口座2</summary>
        public const string CT_CsDmd_AccountNoInfo2 = "AccountNoInfo2";

        /// <summary>銀行口座3</summary>
        public const string CT_CsDmd_AccountNoInfo3 = "AccountNoInfo3";

        /// <summary>自社プロテクト1</summary>
        public const string CT_CsDmd_CompanyProt1 = "CompanyProt1";

        /// <summary>自社プロテクト2</summary>
        public const string CT_CsDmd_CompanyProt2 = "CompanyProt2";

        /// <summary>請求設定摘要1</summary>
        public const string CT_CsDmd_CompanySetNote1 = "CompanySetNote1";

        /// <summary>請求設定摘要2</summary>
        public const string CT_CsDmd_CompanySetNote2 = "CompanySetNote2";

        /// <summary>自社画像</summary>
        public const string CT_CsDmd_CampImgID = "CampImg";

        /// <summary>画像コメント１</summary>
        public const string CT_CsDmd_ImageCommentForPrt1 = "ImageCommentForPrt1";
        /// <summary>画像コメント２</summary>
        public const string CT_CsDmd_ImageCommentForPrt2 = "ImageCommentForPrt2";
        #endregion
        
        //--------------------------------------------------
        //  その他項目(印刷用)
        //--------------------------------------------------
        #region その他項目(印刷用)
        /// <summary>発行年月日</summary>
        public const string CT_CsDmd_Publication = "Publication";

        /// <summary>請求年月日</summary>
        public const string CT_CsDmd_TargetAddUpDate = "TargetAddUpDate";

        /// <summary>請求月</summary>
        public const string CT_CsDmd_TargetAddUpMonth = "TargetAddUpMonth";

        /// <summary>請求金額</summary>
        public const string CT_CsDmd_PrintAfCalDemandPrice = "PrintAfCalDemandPrice";

        /// <summary>今回消費税</summary>
        public const string CT_CsDmd_PrintTtlConsTaxDmd = "PrintTtlConsTaxDmd";

        /// <summary>銀行1</summary>
        public const string CT_CsDmd_AccountNoInfoDsp1 = "AccountNoInfoDsp1";

        /// <summary>銀行2</summary>
        public const string CT_CsDmd_AccountNoInfoDsp2 = "AccountNoInfoDsp2";

        /// <summary>銀行3</summary>
        public const string CT_CsDmd_AccountNoInfoDsp3 = "AccountNoInfoDsp3";
        #endregion
        
        // 2008.09.08 30413 犬飼 項目追加 >>>>>>START
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
        // 2008.09.08 30413 犬飼 項目追加 <<<<<<END

        // --- DEL  大矢睦美  2010/01/25 ---------->>>>>
        // 2009.01.23 30413 犬飼 請求書出力区分を追加 >>>>>>START
        /// <summary>請求書出力区分コード</summary>
        //public const string CT_Blnce_BillOutputCode = "BillOutputCode";
        // 2009.01.23 30413 犬飼 請求書出力区分を追加 <<<<<<END
        // --- DEL  大矢睦美  2010/01/25 ----------<<<<<

        /// <summary>領収書出力区分コード</summary>
        public const string CT_Blnce_ReceiptOutputCode = "ReceiptOutputCode";       // ADD 2009/04/07
        
        // --- ADD  大矢睦美  2010/01/25 ---------->>>>>
        /// <summary>合計請求書出力区分コード</summary>
        public const string CT_Blnce_TotalBillOutputDiv = "TotalBillOutputDiv";
        /// <summary>明細請求書出力区分コード</summary>
        public const string CT_Blnce_DetailBillOutputCode = "DetailBillOutputCode";
        /// <summary>伝票合計請求書出力区分コード</summary>
        public const string CT_Blnce_SlipTtlBillOutputDiv = "SlipTtlBillOutputDiv";
        // --- ADD  大矢睦美  2010/01/25 ----------<<<<<

        ////--------------------------------------------------
        ////  明細項目
        ////--------------------------------------------------
        #region 売上・入金明細カラム情報(請求明細印刷用)
        /// <summary>請求先コード</summary>
        public const string CT_SaleDepo_ClaimCode = "ClaimCode";

        /// <summary>請求先名</summary>
        public const string CT_SaleDepo_ClaimName = "ClaimName";

        /// <summary>請求先名2</summary>
        public const string CT_SaleDepo_ClaimName2 = "ClaimName2";

        /// <summary>請求先略称</summary>
        public const string CT_SaleDepo_ClaimSnm = "ClaimSnm";

        /// <summary>得意先コード</summary>
        public const string CT_SaleDepo_CustomerCode = "CustomerCode";

        /// <summary>得意先名</summary>
        public const string CT_SaleDepo_CustomerName = "CustomerName";

        /// <summary>得意先名2</summary>
        public const string CT_SaleDepo_CustomerName2 = "CustomerName2";

        /// <summary>得意先略称</summary>
        public const string CT_SaleDepo_CustomerSnm = "CustomerSnm";

        // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
        ///// <summary>赤伝区分(0:黒,1:赤,2相殺済み黒)</summary>
        //public const string CT_SaleDepo_DebitNoteDiv = "DebitNoteDiv";
        // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
        
        /// <summary>計上日付</summary>
        public const string CT_SaleDepo_AddUpADate = "AddUpADate";

        /// <summary>計上日付(表示用)</summary>
        public const string CT_SaleDepo_AddUpADateDisp = "AddUpADateDisp";

        /// <summary>データ入力システム</summary>
        public const string CT_SaleDepo_DataInputSystem = "DataInputSystem";

        /// <summary>伝票番号・入金番号</summary>                
        public const string CT_SaleDepo_SalesSlipNum = "SalesSlipNum";

        /// <summary>売上伝票区分</summary>                
        public const string CT_SaleDepo_SalesSlipCd = "SalesSlipCd";

        /// <summary>売掛区分</summary>
        public const string CT_SaleDepo_AccRecDivCd = "AccRecDivCd";

        /// <summary>相手先伝票番号</summary>                
        public const string CT_SaleDepo_PartySaleSlipNum = "PartySaleSlipNum";

        // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
        ///// <summary>赤黒連結受注番号</summary>                
        //public const string CT_SaleDepo_DebitNLnkAcptAnOdr = "DebitNLnkAcptAnOdr";
        // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
        
        /// <summary>売上伝票合計（税込み）</summary>                
        public const string CT_SaleDepo_SalesTotalTaxInc = "SalesTotalTaxInc";

        /// <summary>売上伝票合計（税抜き）</summary>                
        public const string CT_SaleDepo_SalesTotalTaxExc = "SalesTotalTaxExc";

        /// <summary>売上伝票消費税額</summary>                
        public const string CT_SaleDepo_SalesTotalTax = "SalesTotalTax";

        /// <summary>伝票備考</summary>                
        public const string CT_SaleDepo_SlipNote = "SlipNote";

        /// <summary>伝票備考２</summary>                
        public const string CT_SaleDepo_SlipNote2 = "SlipNote2";

        /// <summary>売上行番号</summary>
        public const string CT_SaleDepo_SalesRowNo = "SalesRowNo";

        /// <summary>売上伝票区分（明細）</summary>
        public const string CT_SaleDepo_SalesSlipCdDtl = "SalesSlipCdDtl";

        /// <summary>受注番号</summary>
        public const string CT_SaleDepo_AcceptAnOrderNo = "AcceptAnOrderNo";

        /// <summary>商品メーカーコード</summary>
        public const string CT_SaleDepo_GoodsMakerCd = "GoodsMakerCd";

        /// <summary>メーカー名称</summary>
        public const string CT_SaleDepo_MakerName = "MakerName";

        /// <summary>商品番号</summary>
        public const string CT_SaleDepo_GoodsNo = "GoodsNo";

        /// <summary>商品名</summary>
        public const string CT_SaleDepo_GoodsName = "GoodsName";

        // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
        ///// <summary>商品区分コード</summary>
        //public const string CT_SaleDepo_MediumGoodsGanreCode = "MediumGoodsGanreCode";

        ///// <summary>商品区分名</summary>
        //public const string CT_SaleDepo_MediumGoodsGanreName = "MediumGoodsGanreName";

        ///// <summary>商品区分グループコード</summary>
        //public const string CT_SaleDepo_LargeGoodsGanreCode = "LargeGoodsGanreCode";

        ///// <summary>商品区分グループ名</summary>
        //public const string CT_SaleDepo_LargeGoodsGanreName = "LargeGoodsGanreName";

        ///// <summary>商品区分詳細コード</summary>
        //public const string CT_SaleDepo_DetailGoodsGanreCode = "DetailGoodsGanreCode";

        ///// <summary>商品区分詳細名称</summary>
        //public const string CT_SaleDepo_DetailGoodsGanreName = "DetailGoodsGanreName";
        // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<<END
        
        /// <summary>BL商品コード</summary>
        public const string CT_SaleDepo_BLGoodsCode = "BLGoodsCode";

        /// <summary>BL商品コード名称</summary>
        public const string CT_SaleDepo_BLGoodsFullName = "BLGoodsFullName";

        // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
        ///// <summary>自社分類コード</summary>
        //public const string CT_SaleDepo_EnterpriseGanreCode = "EnterpriseGanreCode";

        ///// <summary>自社分類名称</summary>
        //public const string CT_SaleDepo_EnterpriseGanreName = "EnterpriseGanreName";

        ///// <summary>単位コード</summary>
        //public const string CT_SaleDepo_UnitCode = "UnitCode";

        ///// <summary>単位名称</summary>
        //public const string CT_SaleDepo_UnitName = "UnitName";
        // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
        
        /// <summary>売上単価（税込，浮動）</summary>
        public const string CT_SaleDepo_SalesUnPrcTaxIncFl = "SalesUnPrcTaxIncFl";

        /// <summary>売上単価（税抜，浮動）</summary>
        public const string CT_SaleDepo_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";

        /// <summary>出荷数</summary>
        public const string CT_SaleDepo_ShipmentCnt = "ShipmentCnt";

        /// <summary>売上金額（税込み）</summary>
        public const string CT_SaleDepo_SalesMoneyTaxInc = "SalesMoneyTaxInc";

        /// <summary>売上金額（税抜き）</summary>
        public const string CT_SaleDepo_SalesMoneyTaxExc = "SalesMoneyTaxExc";

        /// <summary>売上金額（税抜き 印刷用）</summary>
        public const string CT_SaleDepo_SalesMoneyTaxExc1 = "SalesMoneyTaxExc1";

        // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
        ///// <summary>消費税調整額</summary>
        //public const string CT_SaleDepo_TaxAdjust = "TaxAdjust";

        ///// <summary>残高調整額</summary>
        //public const string CT_SaleDepo_BalanceAdjust = "BalanceAdjust";
        // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
            
        /// <summary>課税区分</summary>
        public const string CT_SaleDepo_TaxationDivCd = "TaxationDivCd";

        /// <summary>相手先伝票番号（明細）</summary>
        public const string CT_SaleDepo_PartySlipNumDtl = "PartySlipNumDtl";

        /// <summary>明細備考</summary>
        public const string CT_SaleDepo_DtlNote = "DtlNote";

        /// <summary>伝票メモ１</summary>
        public const string CT_SaleDepo_SlipMemo1 = "SlipMemo1";

        /// <summary>伝票メモ２</summary>
        public const string CT_SaleDepo_SlipMemo2 = "SlipMemo2";

        /// <summary>伝票メモ３</summary>
        public const string CT_SaleDepo_SlipMemo3 = "SlipMemo3";

        // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
        ///// <summary>伝票メモ４</summary>
        //public const string CT_SaleDepo_SlipMemo4 = "SlipMemo4";

        ///// <summary>伝票メモ５</summary>
        //public const string CT_SaleDepo_SlipMemo5 = "SlipMemo5";

        ///// <summary>伝票メモ６</summary>
        //public const string CT_SaleDepo_SlipMemo6 = "SlipMemo6";

        ///// <summary>印刷用商品番号</summary>
        //public const string CT_SaleDepo_PrtGoodsNo = "PrtGoodsNo";

        ///// <summary>印刷用商品名称</summary>
        //public const string CT_SaleDepo_PrtGoodsName = "PrtGoodsName";

        ///// <summary>印刷用商品メーカーコード</summary>
        //public const string CT_SaleDepo_PrtGoodsMakerCd = "PrtGoodsMakerCd";

        ///// <summary>印刷用商品メーカー名称</summary>
        //public const string CT_SaleDepo_PrtGoodsMakerNm = "PrtGoodsMakerNm";
        // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
            
        /// <summary>計上拠点コード</summary>
        public const string CT_SaleDepo_AddUpSecCode = "AddUpSecCode";

        /// <summary>計上拠点名称</summary>
        public const string CT_SaleDepo_AddUpSecName = "AddUpSecName";

        //--------------------------------------------------
        //  明細項目(入金用)
        //--------------------------------------------------
        /// <summary>赤黒入金連結番号</summary>
        public const string CT_SaleDepo_DebitNoteLinkDepoNo = "DebitNoteLinkDepoNo";

        /// <summary>入金伝票番号</summary>
        public const string CT_SaleDepo_DepositSlipNo = "DepositSlipNo";

        /// <summary>入金金種コード</summary>              
        public const string CT_SaleDepo_DepositKindCode = "DepositKindCode";

        /// <summary>入金金種名称</summary>                
        public const string CT_SaleDepo_DepositKindName = "DepositKindName";

        /// <summary>入金計</summary>
        public const string CT_SaleDepo_DepositTotal = "DepositTotal";

        /// <summary>伝票摘要</summary>
        public const string CT_SaleDepo_Outline = "Outline";

        /// <summary>手形種類</summary>
        public const string CT_SaleDepo_DraftKind = "DraftKind";

        /// <summary>手形種類名称</summary>
        public const string CT_SaleDepo_DraftKindName = "DraftKindName";

        /// <summary>手形区分</summary>
        public const string CT_SaleDepo_DraftDivide = "DraftDivide";

        /// <summary>手形区分名称</summary>
        public const string CT_SaleDepo_DraftDivideName = "DraftDivideName";

        /// <summary>手形番号</summary>
        public const string CT_SaleDepo_DraftNo = "DraftNo";

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
        //--- ADD 2022/08/24 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
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
        //--- ADD 2022/08/24 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<

        #endregion
        #endregion

        //================================================================================
        //  プライベート変数
        //================================================================================
        #region private member
        /// <summary>請求一覧データリモートオブジェクト</summary>
        private static IBillTableDB _iBillTableDB = null;

        /// <summary>請求明細データリモートオブジェクト</summary>
        private static IBillDetailTableDB _iBillDetailTableDB = null;
        
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

        /// <summary>変換前住所データクラス</summary>
        private BeforeConvertAddressParam _beforeConvertAddressParam;
        /// <summary>変換後住所データクラス</summary>
        private AfterConvertAddressParam _afterConvertAddressParam;

        // 自社画像イメージ
        private Image _CampImage = null;
        // 画像管理データクラス
        private ImageInfo _imageInfo = new ImageInfo();
        // 画像管理アクセスクラス
        private ImageInfoAcs _imageInfoAcs = new ImageInfoAcs();

        // 2009.01.21 30413 犬飼 計算後請求金額のキャッシュを追加 >>>>>>START
        // 計算後請求金額のキャッシュ
        private Dictionary<string, long> afCalDemandPriceDic;
        // 2009.01.21 30413 犬飼 計算後請求金額のキャッシュを追加 <<<<<<END

        // 2009.02.02 30413 犬飼 回収率計算の仕様変更 >>>>>>START
        private int _endDays = 0;       // 締日の月末
        // 2009.02.02 30413 犬飼 回収率計算の仕様変更 <<<<<<END

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
        /// 請求帳票抽出情報アクセスクラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : 請求帳票抽出情報アクセスクラスの新しいインスタンスを作成します。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        public DemandPrintAcs()
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
        /// 請求帳票抽出情報アクセスクラス静的コンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : 請求帳票抽出情報アクセスクラスの新しいインスタンスを作成します。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
        /// <br>Update Date: xxxx.xx.xx</br>
        /// </remarks>
        static DemandPrintAcs()
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

            sectionTable = new Hashtable();
            secCodeList = new ArrayList();

            // 請求一覧データリモートオブジェクト インスタンス化
            _iBillTableDB = (IBillTableDB)MediationBillTableDB.GetBillTableDB();

            // 請求明細データリモートオブジェクト インスタンス化
            _iBillDetailTableDB = (IBillDetailTableDB)MediationBillDetailTableDB.GetBillDetailTableDB();

        }
        #endregion

        //================================================================================
        //  外部提供関数
        //================================================================================
        #region public methods
        /// <summary>
        /// 請求書データ初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出データを初期化します。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
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

            // 2009.01.21 30413 犬飼 計算後請求金額のキャッシュを追加 >>>>>>START
            afCalDemandPriceDic = new Dictionary<string, long>();
            // 2009.01.21 30413 犬飼 計算後請求金額のキャッシュを追加 <<<<<<END
        }

        /// <summary>
        /// 請求印刷設定データ読込処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 初期データの読込を行います。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        public int ReadAllDefSet(out AllDefSet allDefSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            allDefSet = null;
            message = "";
            AllDefSet allDefSetZero = null;
            try
            {
                string sectionCode = "";

                if (LoginInfoAcquisition.Employee != null)
                {
                    sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                }

                // 2008.09.08 30413 犬飼 Readメソッドが動作しないため、メソッドを変更 >>>>>>START
                //status = mAllDefSetAcs.Read(out allDefSet, LoginInfoAcquisition.EnterpriseCode, sectionCode);
                ArrayList retList = new ArrayList();
                status = mAllDefSetAcs.Search(out retList, LoginInfoAcquisition.EnterpriseCode);
                // 2008.09.08 30413 犬飼 Readメソッドが動作しないため、メソッドを変更 <<<<<<END
                
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // 2008.09.05 30413 犬飼 Readメソッドが動作しないため、メソッドを変更 >>>>>>START
                        foreach (AllDefSet workAllDefSet in retList)
                        {
                            if (workAllDefSet.SectionCode == sectionCode)
                            {
                                // 同一拠点
                                allDefSet = workAllDefSet.Clone();
                                break;
                            }
                            // --- ADD  大矢睦美  2010/01/25 ---------->>>>>
                            if (workAllDefSet.SectionCode.Trim() == "00")
                            {
                                //同一拠点がない場合は全社設定を取ってくる
                                allDefSetZero = workAllDefSet;
                            }
                            // --- ADD  大矢睦美  2010/01/25 ----------<<<<<

                        }
                        if (allDefSet == null)
                        {
                            // --- UPD  大矢睦美  2010/01/25 ---------->>>>>
                            // 同一拠点が無い場合はエラー                                
                            //allDefSet = new AllDefSet();
                            //message = "全体初期値設定が設定されていません。";
                            allDefSet = allDefSetZero;
                            // --- UPD  大矢睦美  2010/01/25 ----------<<<<<
                        }
                        // 2008.09.05 30413 犬飼 Readメソッドが動作しないため、メソッドを変更 <<<<<<END
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
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        public int GetOwnSeCtrlCode(string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode, out string ctrlSectionCode)
        {
            // 対象制御拠点の初期値は自拠点
            ctrlSectionCode = sectionCode;

            SecInfoSet secInfoSet;

            // 2008.09.05 30413 犬飼 引数変更 >>>>>>START
            //int status = mSecInfoAcs.GetSecInfo(sectionCode, ctrlFuncCode, out secInfoSet);
            int status = mSecInfoAcs.GetSecInfo(sectionCode, out secInfoSet);
            // 2008.09.05 30413 犬飼 引数変更 <<<<<<END
                
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
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 該当拠点の自社名称情報の取得を行います。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// 得意先請求金額取得
        /// </summary>
        /// <param name="extraInfo">請求書抽出条件データクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 請求一覧情報を抽出します。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        public int ReadCustDmd(ExtrInfo_DemandTotal extraInfo, out string message)
        {
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // DataSet初期化
            this.InitializeDemandData();

            string enterpriseCode = extraInfo.EnterpriseCode;
            string addUpSecCode = extraInfo.ResultsAddUpSecList[0].ToString();
            int customerCode = extraInfo.CustomerCodeSt;
            // 2008.09.08 30413 犬飼 締日を変更 >>>>>>START
            //int targetDate = extraInfo.TargetAddUpDate;
            DateTime addUpDate = extraInfo.AddUpDate;
            // 2008.09.08 30413 犬飼 締日を変更 <<<<<<END
            
            RsltInfo_DemandTotalWork csdmd;
            csdmd = new RsltInfo_DemandTotalWork();

            status = 0;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    DataRow row = CustDmdPrcWorkToDataRow(extraInfo, csdmd);
                    this._custDmdPrcDataTable.Rows.Add(row);

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    message = "得意先請求金額情報の取得に失敗しました";
                    break;
            }

            return status;
        }

        /// <summary>
        /// 請求一覧抽出処理
        /// </summary>
        /// <param name="extraInfo">請求書抽出条件データクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 請求一覧情報を抽出します。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        public int SearchDemandList(ExtrInfo_DemandTotal extraInfo, out string message, out string errDspMsg)
        {
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errDspMsg = "";

            try
            {
                // DataSet初期化
                this.InitializeDemandData();

                ArrayList arCustDmdPrcBef = new ArrayList();
                ArrayList arCustDmdPrcAft = new ArrayList();
                Dictionary<int, DmdPrtPtn> dmdPrtPtnKeyList = new Dictionary<int, DmdPrtPtn>();
                ArrayList dmdPrtPtnParamList = new ArrayList();
                Dictionary<int, string> errDmdGrpSumCustomerList = new Dictionary<int, string>();
                Dictionary<int, string> errDmdDtlCustomerList = new Dictionary<int, string>();

                // 2008.09.08 30413 犬飼 削除項目 >>>>>>START
                //int startTotalDay = extraInfo.TotalDay;
                //int endTotalDay = extraInfo.TotalDay;
                // 2008.09.08 30413 犬飼 削除項目 <<<<<<END
            
                // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                //// 得意先締日28～31日全て含める
                //if (startTotalDay >= 28 && extraInfo.IsLastDay)
                //{
                //    startTotalDay = 28;
                //    endTotalDay = 31;
                //}
                // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                
                ExtrInfo_DemandTotalWork extraInfoWork = new ExtrInfo_DemandTotalWork();
                extraInfoWork = this.CopyToExtraInfoWorkFromExtraInfo(extraInfo);

                object paraObj = null;
                object retObj = null;
                object paraAddObj = null;
                object retAddObj = null;

                paraObj = (object)extraInfoWork;

                status = _iBillTableDB.SearchBillTable(out retObj, paraObj);
                 
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            arCustDmdPrcBef = retObj as ArrayList;
                            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                            //DmdPrtPtn dmdPrtPtn;

                            //foreach (RsltInfo_DemandTotalWork csdmd in arCustDmdPrcBef)
                            //{
                            //    if (dmdPrtPtnKeyList.ContainsKey(csdmd.DemandPtnNo) == false)
                            //    {
                            //        // 請求書印刷パターン取得
                            //        this.GetDmdPrtPtn(csdmd.DemandPtnNo, out dmdPrtPtn);
                            //        // 取得済みパターンのリストに追加
                            //        dmdPrtPtnKeyList.Add(csdmd.DemandPtnNo, dmdPrtPtn);
                            //    }
                            //}
                            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

                            // 2009.02.02 30413 犬飼 締日の月末を取得 >>>>>>START
                            _endDays = DateTime.DaysInMonth(extraInfo.AddUpDate.Year, extraInfo.AddUpDate.Month);
                            // 2009.02.02 30413 犬飼 締日の月末を取得 <<<<<<END
        
                            // --- ADD  大矢睦美  2010/01/25 ---------->>>>>
                            //retAddObj  = retObj;                            
                            retAddObj = (retObj as CustomSerializeArrayList)[0];
                            // --- ADD  大矢睦美  2010/01/25 ----------<<<<<
                            
                            paraAddObj = (object)dmdPrtPtnParamList;

                            arCustDmdPrcAft = retAddObj as ArrayList;

                            // --- ADD  大矢睦美  2010/01/25 ---------->>>>>
                            object AllDefSetObj = null;
                            AllDefSetObj = (retObj as CustomSerializeArrayList)[1];
                            ReadAllDefSetWork(AllDefSetObj as ArrayList);

                            paraAddObj = (object)dmdPrtPtnParamList;

                            arCustDmdPrcAft = retAddObj as ArrayList;
                            // --- ADD  大矢睦美  2010/01/25 ----------<<<<<

                            // 請求金額DataTable作成     
                            foreach (RsltInfo_DemandTotalWork csdmd in arCustDmdPrcAft)                                               
                            {
                                // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                                //// 請求書印刷パターンの取得できないものは出力しない(メッセージダイアログ表示)
                                //if (csdmd.DemandPtnNo == 0)
                                //{
                                //    errDmdGrpSumCustomerList.Add(csdmd.CustomerCode, csdmd.CustomerName);
                                //    continue;
                                //}

                                //// 請求明細書印刷パターンの取得できないものは出力しない(メッセージダイアログ表示)
                                //if (csdmd.DmdDtlPtnNo == 0)
                                //{
                                //    errDmdDtlCustomerList.Add(csdmd.CustomerCode, csdmd.CustomerName);
                                //    continue;
                                //}
                                // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

                                DataRow row = CustDmdPrcWorkToDataRow(extraInfo, csdmd);

                                // 2009.01.19 30413 犬飼 親得意先内訳の処理を追加 >>>>>>START
                                //this._custDmdPrcDataTable.Rows.Add(row);
                                if (row != null)
                                {
                                    // 親得意先内訳の処理でnullが返ってくる
                                    this._custDmdPrcDataTable.Rows.Add(row);
                                }
                                // 2009.01.19 30413 犬飼 親得意先内訳の処理を追加 <<<<<<END
                            }

                             

                            // 2009.01.21 30413 犬飼 計算後請求金額(フィルター用)を追加 >>>>>>START
                            // フィルター用の計算後請求金額を設定
                            SetAfCalDemandPriceFilter();
                            // 2009.01.21 30413 犬飼 計算後請求金額(フィルター用)を追加 <<<<<<END
                            
                            // 請求書印刷パターン取得不能エラーメッセージ
                            if (errDmdGrpSumCustomerList.Count > 0)
                            {
                                errDspMsg = "以下の請求先は請求書印刷パターンの設定が行われていないため出力を回避します。";
                                foreach (KeyValuePair<int, string> errInfo in errDmdGrpSumCustomerList)
                                {
                                    errDspMsg = errDspMsg + "\n";
                                    errDspMsg = errDspMsg + errInfo.Key + " , " + errInfo.Value;
                                }
                            }

                            // 請求明細書印刷パターン取得不能エラーメッセージ
                            if (errDmdDtlCustomerList.Count > 0)
                            {
                                if (errDspMsg == "")
                                {
                                    errDspMsg = errDspMsg + "\n\n";
                                }
                                errDspMsg = "以下の請求先は請求明細書印刷パターンの設定が行われていないため出力を回避します。";
                                foreach (KeyValuePair<int, string> errInfo in errDmdDtlCustomerList)
                                {
                                    errDspMsg = errDspMsg + "\n";
                                    errDspMsg = errDspMsg + errInfo.Key + " , " + errInfo.Value;
                                }
                            }

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


        // --- ADD  大矢睦美  2010/01/25 ---------->>>>>
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
                    // 同一拠点
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
                //// 同一拠点が無い場合はエラー                                
                //allDefSet = new AllDefSet();
                //message = "全体初期値設定が設定されていません。";
                //foreach (AllDefSetWork workAllDefSet in arrayList)
                //{
                //    if (workAllDefSet.SectionCode.Trim() == "00")
                //    {
                //        // 同一拠点
                //        allDefSetWork = workAllDefSet;
                //        break;
                //    }
                //}
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
        // --- ADD  大矢睦美  2010/01/25 ----------<<<<<

        #region 売上・入金明細抽出処理
        /// <summary>
        /// 売上・入金明細抽出処理
        /// </summary>
        /// <param name="ds">抽出DataSet</param>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="seikingetDetailParamList">請求KINGETパラメータリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 売上・入金明細情報を抽出します。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        public int SearchSaleDepoDetail(out DataSet dsSale, out DataSet dsDepo, string enterPriseCode, ExtrInfo_DemandDetailWork detailParam, DmdDtlPrtPtn dmdDtlPrtPtn, out string message)
        {
            message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            dsSale = new DataSet(CT_SaleDataSet);
            dsDepo = new DataSet(CT_DepoDataSet);

            // 売上・入金明細DataSet作成
            this.CreateSaleTable(ref dsSale);
            this.CreateDepoTable(ref dsDepo);

            DataTable dtSale = dsSale.Tables[CT_SaleDataTable];
            DataTable dtDepo = dsDepo.Tables[CT_DepoDataTable];

            ArrayList htSales = new ArrayList();

            object htSalesObj = null;
            object paramObj = (object)detailParam;

            status = _iBillDetailTableDB.SearchBillDetailTable(out htSalesObj, paramObj);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        htSales = htSalesObj as ArrayList;

                        // 売上
                        foreach (RsltInfo_DemandDetailWork detailWork in htSales)
                        {
                            if (detailWork.DepositSlipNo == 0)
                            {
                                // 現金は印字しない
                                if (detailWork.AccRecDivCd != 0)
                                {
                                    // 売上データ
                                    SalesToSaleDtlDataRow(detailWork, ref dtSale, dmdDtlPrtPtn);
                                }
                            }
                            else
                            {
                                // 自動入金の場合は印字しない
                                if (detailWork.AutoDepositCd != 1)
                                {
                                    // 入金データ
                                    SalesToDepoDtlDataRow(detailWork, ref dtDepo, dmdDtlPrtPtn);
                                }
                            }
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    message = "売上・入金データの取得に失敗しました";
                    break;
            }
            return status;
        }
        #endregion
        
        /// <summary>
        /// 選択行印字選択・非選択状態処理
        /// </summary>
        /// <param name="_uniqueID">ユニークID</param>
        /// <remarks>
        /// <br>Note       : 抽出データを初期化します。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Note       : 抽出データを初期化します。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <param name="outPutDive">出力区分</param>
        /// <param name="outPutDive">請求内訳</param>
        /// <remarks>
        /// <br>Note       : 抽出データ表示用データビューにフィルタ設定を行います。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>        
        // --- UPD  大矢睦美  2010/01/25 ---------->>>>>
        //public void SelectViewData(int outPutDive, int dmdDtlDiv)        
        public void SelectViewData(int outPutDive, int dmdDtlDiv, int issueType)
        // --- UPD  大矢睦美  2010/01/25 ----------<<<<<
        {
            string strQuery = "";
            string strQuery1 = "";
            // --- ADD  大矢睦美  2010/01/25 ---------->>>>>
            string strQuery2 = "";
            // --- ADD  大矢睦美  2010/01/25 ----------<<<<<

            // 2009.01.21 30413 犬飼 計算後請求金額(フィルター用)を追加 >>>>>>START
            // 出力区分と請求内訳によるフィルタ条件作成
            //switch (outPutDive)
            //{
            //    case 0: // 全て出力 
            //        break;
            //    case 1: // ０とプラス金額を出力
            //        strQuery = String.Format("{0} >= {1}",
            //            CT_CsDmd_AfCalDemandPrice,
            //            0);
            //        break;
            //    case 2: // プラス金額のみ出力
            //        strQuery = String.Format("{0} > {1}",
            //            CT_CsDmd_AfCalDemandPrice,
            //            0);
            //        break;
            //    case 3: // ０のみ出力
            //        strQuery = String.Format("{0} = {1}",
            //            CT_CsDmd_AfCalDemandPrice,
            //            0);
            //        break;
            //    case 4: // プラス金額とマイナス金額を出力
            //        strQuery = String.Format("{0} <> {1}",
            //            CT_CsDmd_AfCalDemandPrice,
            //            0);
            //        break;
            //    case 5: // ０とマイナス金額を出力
            //        strQuery = String.Format("{0} <= {1}",
            //            CT_CsDmd_AfCalDemandPrice,
            //            0);
            //        break;
            //    case 6: // マイナス金額のみ出力
            //        strQuery = String.Format("{0} < {1}",
            //            CT_CsDmd_AfCalDemandPrice,
            //            0);
            //        break;
            //    default:
            //        break;
            //}
            // 計算後請求金額(フィルター用)でフィルター条件作成
            if (dmdDtlDiv != 2)
            {
                switch (outPutDive)
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
            }
            // 2009.01.21 30413 犬飼 計算後請求金額(フィルター用)を追加 <<<<<<END

            if (dmdDtlDiv == 1)  //  請求内訳→請求先
            {
                if (outPutDive == 0)
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

            // 2009.01.21 30413 犬飼 計算後請求金額(フィルター用)を追加 >>>>>>START
            // 得意先の場合は出力区分によるフィルター条件作成は無し
            if (dmdDtlDiv == 2)  //  請求内訳→得意先
            {
                //if (outPutDive == 0)
                //{
                strQuery = String.Format("{0} = {1}",
                CT_CsDmd_DataType,
                false);
                //}
                //else
                //{
                //    strQuery1 = String.Format(" AND {0} = {1}",
                //    CT_CsDmd_DataType,
                //    false);
                //}
            }
            // 2009.01.21 30413 犬飼 計算後請求金額(フィルター用)を追加 <<<<<<END

            // --- ADD  大矢睦美  2010/01/25 ---------->>>>>
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
                                strQuery2 += string.Format(" {0} <> {1}",
                                CT_Blnce_TotalBillOutputDiv,
                                2);
                            }
                            //全体初期値設定「出力しない」
                            else if (AllDefSetData.DefTtlBillOutput == 1)
                            {
                                //得意先マスタ「使用」のみ
                                strQuery2 += string.Format(" {0} = {1}",
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
                            strQuery2 += string.Format(" {0} <> {1}",
                            CT_Blnce_DetailBillOutputCode,
                            2);
                        }
                        //全体初期値設定「出力しない」
                        else if (AllDefSetData.DefDtlBillOutput == 1)
                        {
                            //得意先マスタ「使用」
                            strQuery2 += string.Format(" {0} = {1}",
                            CT_Blnce_DetailBillOutputCode,
                            1);
                        }
                        break;
                    }
                //伝票合計請求書
                case 70:
                    {
                        //
                        strQuery2 = string.Empty;
                        if (!string.IsNullOrEmpty(strQuery) || !string.IsNullOrEmpty(strQuery1))
                        {
                            strQuery2 = " AND ";
                        }
                        //全体初期値設定「出力する」
                        if (AllDefSetData.DefSlTtlBillOutput == 0)
                        {
                            //得意先マスタ「標準」または「使用」
                            strQuery2 += string.Format(" {0} <> {1}",
                            CT_Blnce_SlipTtlBillOutputDiv,
                            2);
                        }
                        //全体初期値設定「出力しない」
                        else if (AllDefSetData.DefSlTtlBillOutput == 1)
                        {
                            //得意先マスタ「使用」
                            strQuery2 += string.Format(" {0} = {1}",
                            CT_Blnce_SlipTtlBillOutputDiv,
                            1);
                        }
                        break;
                    }
            }
            // --- ADD  大矢睦美  2010/01/25 ----------<<<<<    

            // クエリ設定
            // --- UPD  大矢睦美  2010/01/25 ---------->>>>>
            //_custDmdPrcDataView.RowFilter = strQuery + strQuery1;
            _custDmdPrcDataView.RowFilter = strQuery + strQuery1 + strQuery2;
            // --- UPD  大矢睦美  2010/01/25 ----------<<<<<
        }

        /// <summary>
        /// 印刷用データテーブル作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 印刷用データテーブルを作成します。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Programer  : 30413 犬飼</br>
        /// <br>Date       : 2009.01.22</br>
        /// </remarks>
        public int MakePrintDataTable(int pcardPrtSuspendcnt, ExtrInfo_DemandTotal extrInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

            // 印刷インデックス
            int printOder = 0;

            // ADD 2009/06/03 ------>>>
            // Filter設定
            string rowFilter = "";
            if (_custDmdPrcDataView.RowFilter != "")
            {
                rowFilter = _custDmdPrcDataView.RowFilter;
            }
            // ADD 2009/06/03 ------<<<
            
            // 印刷用DataTable初期化
            _custDmdPrcPrintDataTable.Rows.Clear();
            _custDmdPrcDataViewPrint.RowFilter = "";

            // 2009.01.29 30413 犬飼 出力順に対応するように修正 >>>>>>START
            string strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_CustomerCode;
            if (extrInfo.SortOrder == 1)
            {
                // 担当者順
                if (extrInfo.CustomerAgentDivCd == 0)
                {
                    // 顧客担当
                    strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_CustomerAgentCd + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_CustomerCode;
                }
                else
                {
                    // 集金担当
                    strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_BillCollecterCd + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_CustomerCode;
                }
            }
            else if (extrInfo.SortOrder == 2)
            {
                // 地区順
                strSort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_SalesAreaCode + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_CustomerCode;
            }

            // ワーク用のDataView
            //DataView workDataView = new DataView(_custDmdPrcDataTable, _custDmdPrcDataTable.DefaultView.RowFilter, strSort, DataViewRowState.CurrentRows);    // DEL 2009/06/03
            DataView workDataView = new DataView(_custDmdPrcDataTable, rowFilter, strSort, DataViewRowState.CurrentRows);   // ADD 2009/06/03

            // 表示用DataViewから印刷用DataTableに設定
            //if (_custDmdPrcDataView.Count != 0)
            if (workDataView.Count != 0)
            {
                //for (int i = 0; i < _custDmdPrcDataView.Count; i++)
                for (int i = 0; i < workDataView.Count; i++)
                {
                    //DataRow row = _custDmdPrcDataView[i].Row;
                    DataRow row = workDataView[i].Row;

                    // DEL 2009/04/07 ------>>>
                    //// 2009.01.23 30413 犬飼 請求書出力区分を追加 >>>>>>START
                    //// 請求書出力区分チェック
                    //if ((int)row[CT_Blnce_BillOutputCode] == 1)
                    //{
                    //    // 印刷しない
                    //    continue;
                    //}
                    //// 2009.01.23 30413 犬飼 請求書出力区分を追加 <<<<<<END
                    // DEL 2009/04/07 ------<<<
                    
                    // --- DEL  大矢睦美  2010/01/25 ---------->>>>>
                    //// UPD 2009/04/07 ------>>>                    
                    //switch (extrInfo.SlipPrtKind)
                    //{
                    //    case 50:
                    //    case 60:
                    //    case 70:
                    //        {
                    //            // 請求書関係
                    //            if ((int)row[CT_Blnce_BillOutputCode] == 1)
                    //            {
                    //                // 印刷しない
                    //                continue;
                    //            }
                    //            break;
                    //        }                                       
                    //    case 80:
                    //        {
                    //            // 領収書
                    //            if ((int)row[CT_Blnce_ReceiptOutputCode] == 1)
                    //            {
                    //                // 印刷しない
                    //                continue;
                    //            }
                    //            break;
                    //        }
                    //}
                    //// UPD 2009/04/07 ------<<<
                    // --- DEL  大矢睦美  2010/01/25 ---------->>>>>

                    // --- ADD  大矢睦美  2010/01/25 ---------->>>>>
                    switch (extrInfo.SlipPrtKind)
                    {   
                        //合計請求書                  
                        case 50:
                            {
                                //得意先マスタの区分「0:標準」
                                if ((int)row[CT_Blnce_TotalBillOutputDiv] == 0)
                                {
                                    //全体初期値設定マスタの区分「1:出力しない」
                                    if (AllDefSetData.DefTtlBillOutput == 1)
                                    {
                                        //印刷しない
                                        continue;
                                    }                                                                                 
                                }
                                //得意先マスタの区分「2:未使用」
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
                                //得意先マスタの区分「0:標準」
                                if ((int)row[CT_Blnce_SlipTtlBillOutputDiv] == 0)
                                {
                                    //全体初期値設定マスタの区分「1:出力しない」
                                    if (AllDefSetData.DefSlTtlBillOutput == 1)
                                    {
                                        //印刷しない
                                        continue;
                                    }
                                }
                                //得意先マスタの区分「2:未使用」
                                else if ((int)row[CT_Blnce_SlipTtlBillOutputDiv] == 2)
                                {
                                    //印刷しない
                                    continue;
                                }
                                break;
                            }
                        //領収書
                        case 80:
                            {
                                // 得意先マスタの区分「1:しない」
                                if ((int)row[CT_Blnce_ReceiptOutputCode] == 1)
                                {
                                    // 印刷しない
                                    continue;
                                }
                                break;
                            }
                    }
                    // --- ADD  大矢睦美  2010/01/25 ----------<<<<<
                    
                   
                    
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
            // 2009.01.29 30413 犬飼 出力順に対応するように修正 <<<<<<END
            
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
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
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
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
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

            // ADD 2009/04/20 ------>>>
            // レコード名
            DataColumn RecordName = new DataColumn(CT_CsDmd_RecordName, typeof(String), "", MappingType.Element);
            DataType.Caption = "レコード名";
            // ADD 2009/04/20 ------<<<
            
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
            // 2009.01.26 30413 犬飼 計上拠点→請求拠点名に変更 >>>>>>START
            //AddUpSecName.Caption = "計上拠点";
            AddUpSecName.Caption = "請求拠点名";
            // 2009.01.26 30413 犬飼 計上拠点→請求拠点名に変更 <<<<<<END
            
            // 2008.09.05 30413 犬飼 項目追加 >>>>>>START
            // 請求拠点コード
            DataColumn ClaimSectionCode = new DataColumn(CT_CsDmd_ClaimSectionCode, typeof(String), "", MappingType.Element);
            ClaimSectionCode.Caption = "請求拠点コード";

            // 請求拠点名称
            DataColumn ClaimSectionName = new DataColumn(CT_CsDmd_ClaimSectionName, typeof(String), "", MappingType.Element);
            ClaimSectionName.Caption = "請求拠点名称";
            // 2008.09.05 30413 犬飼 項目追加 <<<<<<END

            // 2009.01.21 30413 犬飼 項目追加 >>>>>>START
            // 実績拠点コード
            DataColumn ResultsSectCd = new DataColumn(CT_CsDmd_ResultsSectCd, typeof(String), "", MappingType.Element);
            ResultsSectCd.Caption = "実績拠点コード";
            // 2009.01.21 30413 犬飼 項目追加 <<<<<<END
        
            // 請求書パターン番号
            DataColumn DemandPtnNo = new DataColumn(CT_CsDmd_DemandPtnNo, typeof(System.Int32), "", MappingType.Element);
            DemandPtnNo.Caption = "請求書パターン番号";

            // 請求明細書パターン番号
            DataColumn DmdDtlPtnNo = new DataColumn(CT_CsDmd_DmdDtlPtnNo, typeof(System.Int32), "", MappingType.Element);
            DmdDtlPtnNo.Caption = "請求明細書パターン番号";

            // 請求書・支払書区分
            DataColumn DemandOrPay = new DataColumn(CT_CsDmd_DemandOrPay, typeof(System.Int32), "", MappingType.Element);
            DemandOrPay.Caption = "請求書・支払書区分";

            // 請求先コード
            DataColumn ClaimCode = new DataColumn(CT_CsDmd_ClaimCode, typeof(System.Int32), "", MappingType.Element);
            ClaimCode.Caption = "請求先コード";

            // 2008.11.19 30413 犬飼 抽出結果表示用 >>>>>>START
            // 請求先コード(抽出結果表示用)
            DataColumn ClaimCodeDisp = new DataColumn(CT_CsDmd_ClaimCodeDisp, typeof(String), "", MappingType.Element);
            ClaimCodeDisp.Caption = "請求先コード";
            // 2008.11.19 30413 犬飼 抽出結果表示用 <<<<<<END

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

            // 2008.11.19 30413 犬飼 抽出結果表示用 >>>>>>START
            // 得意先コード(抽出結果表示用)
            DataColumn CustomerCodeDisp = new DataColumn(CT_CsDmd_CustomerCodeDisp, typeof(String), "", MappingType.Element);
            CustomerCodeDisp.Caption = "得意先コード";

            // 得意先略称(抽出結果表示用)
            DataColumn CustomerSnmDisp = new DataColumn(CT_CsDmd_CustomerSnmDisp, typeof(String), "", MappingType.Element);
            CustomerSnmDisp.Caption = "得意先略称";
            // 2008.11.19 30413 犬飼 抽出結果表示用 <<<<<<END
            
            // 2008.09.08 30413 犬飼 未使用項目削除 >>>>>>START
            //// 印刷用得意先名称１
            //DataColumn EditCustomerName1 = new DataColumn(CT_CsDmd_EditCustomerName1, typeof(String), "", MappingType.Element);
            //EditCustomerName1.Caption = "印刷用得意先名称１";

            //// 印刷用得意先名称２
            //DataColumn EditCustomerName2 = new DataColumn(CT_CsDmd_EditCustomerName2, typeof(String), "", MappingType.Element);
            //EditCustomerName2.Caption = "印刷用得意先名称２";
            // 2008.09.08 30413 犬飼 未使用項目削除 <<<<<<END
        
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

            // 2009.01.21 30413 犬飼 計算後請求金額(フィルター用)を追加 >>>>>>START
            // 計算後請求金額(フィルター用)
            DataColumn AfCalDemandPriceFilter = new DataColumn(CT_CsDmd_AfCalDemandPriceFilter, typeof(System.Int64), "", MappingType.Element);
            AfCalDemandPriceFilter.Caption = "計算後請求金額(フィルター用)";
            // 2009.01.21 30413 犬飼 計算後請求金額(フィルター用)を追加 <<<<<<END
        
            // 売上伝票枚数
            DataColumn SaleslSlipCount = new DataColumn(CT_CsDmd_SaleslSlipCount, typeof(System.Int32), "", MappingType.Element);
            SaleslSlipCount.Caption = "売上伝票枚数";

            // 請求書発行日
            DataColumn BillPrintDate = new DataColumn(CT_CsDmd_BillPrintDate, typeof(System.DateTime), "", MappingType.Element);
            BillPrintDate.Caption = "請求書発行日";

            // 請求書発行日(印刷用)
            DataColumn BillPrintDatePrt = new DataColumn(CT_CsDmd_BillPrintDatePrt, typeof(String), "", MappingType.Element);
            BillPrintDatePrt.Caption = "請求書発行日(印刷用)";

            // 入金予定日
            DataColumn ExpectedDepositDate = new DataColumn(CT_CsDmd_ExpectedDepositDate, typeof(System.DateTime), "", MappingType.Element);
            ExpectedDepositDate.Caption = "入金予定日";

            // 入金予定日(印刷用)
            DataColumn ExpectedDepositDatePrt = new DataColumn(CT_CsDmd_ExpectedDepositDatePrt, typeof(String), "", MappingType.Element);
            ExpectedDepositDatePrt.Caption = "入金予定日(印刷用)";

            // 回収条件
            DataColumn CollectCond = new DataColumn(CT_CsDmd_CollectCond, typeof(String), "", MappingType.Element);
            CollectCond.Caption = "回収条件";

            // 消費税率
            DataColumn ConsTaxRate = new DataColumn(CT_CsDmd_ConsTaxRate, typeof(System.Double), "", MappingType.Element);
            ConsTaxRate.Caption = "消費税率";

            // 端数処理区分
            DataColumn FractionProcCd = new DataColumn(CT_CsDmd_FractionProcCd, typeof(System.Int32), "", MappingType.Element);
            FractionProcCd.Caption = "端数処理区分";

            // 締次更新実行年月日
            DataColumn CAddUpUpdExecDate = new DataColumn(CT_CsDmd_CAddUpUpdExecDate, typeof(System.DateTime), "", MappingType.Element);
            CAddUpUpdExecDate.Caption = "締次更新実行年月日";

            // 締次更新実行年月日(印刷用)
            DataColumn CAddUpUpdExecDatePrt = new DataColumn(CT_CsDmd_CAddUpUpdExecDatePrt, typeof(String), "", MappingType.Element);
            CAddUpUpdExecDatePrt.Caption = "締次更新実行年月日(印刷用)";

            // 締次更新開始年月日
            DataColumn StartCAddUpUpdDate = new DataColumn(CT_CsDmd_StartCAddUpUpdDate, typeof(System.DateTime), "", MappingType.Element);
            StartCAddUpUpdDate.Caption = "締次更新開始年月日";

            // 締次更新開始年月日(印刷用)
            DataColumn StartCAddUpUpdDatePrt = new DataColumn(CT_CsDmd_StartCAddUpUpdDatePrt, typeof(String), "", MappingType.Element);
            StartCAddUpUpdDatePrt.Caption = "締次更新開始年月日(印刷用)";

            // 前回締次更新年月日
            DataColumn LastCAddUpUpdDate = new DataColumn(CT_CsDmd_LastCAddUpUpdDate, typeof(System.DateTime), "", MappingType.Element);
            LastCAddUpUpdDate.Caption = "前回締次更新年月日";

            // 前回締次更新年月日(印刷用)
            DataColumn LastCAddUpUpdDatePrt = new DataColumn(CT_CsDmd_LastCAddUpUpdDatePrt, typeof(String), "", MappingType.Element);
            LastCAddUpUpdDatePrt.Caption = "前回締次更新年月日(印刷用)";

            // 計上日付(印刷用)
            DataColumn AddUpADatePrint = new DataColumn(CT_CsDmd_AddUpADatePrint, typeof(String), "", MappingType.Element);
            AddUpADatePrint.Caption = "計上日付(印刷用)";

            // 相殺後今回売上消費税(印刷用)
            DataColumn PrintTtlConsTaxDmd = new DataColumn(CT_CsDmd_PrintTtlConsTaxDmd, typeof(String), "", MappingType.Element);
            PrintTtlConsTaxDmd.Caption = "相殺後今回売上消費税";
            
            // 前回請求額(請求先)
            DataColumn ClaimLastTimeDemand = new DataColumn(CT_CsDmd_ClaimLastTimeDemand, typeof(System.Int64), "", MappingType.Element);
            ClaimLastTimeDemand.Caption = "前回請求額(請求先)";

            // 今回入金金額（請求先）
            DataColumn ClaimThisTimeDmdNrml = new DataColumn(CT_CsDmd_ClaimThisTimeDmdNrml, typeof(System.Int64), "", MappingType.Element);
            ClaimThisTimeDmdNrml.Caption = "今回入金金額（請求先）";

            // 今回繰越残高（請求先）
            DataColumn ClaimThisTimeTtlBlcDmd = new DataColumn(CT_CsDmd_ClaimThisTimeTtlBlcDmd, typeof(System.Int64), "", MappingType.Element);
            ClaimThisTimeTtlBlcDmd.Caption = "今回繰越残高（請求先）";

            // 今回売上金額（請求先）
            DataColumn ClaimThisTimeSales = new DataColumn(CT_CsDmd_ClaimThisTimeSales, typeof(System.Int64), "", MappingType.Element);
            ClaimThisTimeSales.Caption = "今回売上金額（請求先）";

            // 今回売上返品・値引金額（請求先）
            DataColumn ClaimThisSalesPricRgdsDis = new DataColumn(CT_CsDmd_ClaimThisSalesPricRgdsDis, typeof(System.Int64), "", MappingType.Element);
            ClaimThisSalesPricRgdsDis.Caption = "今回売上返品・値引金額（請求先）";

            // 相殺後今回売上金額（請求先）
            DataColumn ClaimOfsThisTimeSales = new DataColumn(CT_CsDmd_ClaimOfsThisTimeSales, typeof(System.Int64), "", MappingType.Element);
            ClaimOfsThisTimeSales.Caption = "相殺後今回売上金額（請求先）";

            // 相殺後今回売上消費税（請求先）
            DataColumn ClaimOfsThisSalesTax = new DataColumn(CT_CsDmd_ClaimOfsThisSalesTax, typeof(System.Int64), "", MappingType.Element);
            ClaimOfsThisSalesTax.Caption = "相殺後今回売上消費税（請求先）";

            // 相殺後今回合計売上金額（請求先）
            DataColumn ClaimOfsThisSalesSum = new DataColumn(CT_CsDmd_ClaimOfsThisSalesSum, typeof(System.Int64), "", MappingType.Element);
            ClaimOfsThisSalesSum.Caption = "相殺後今回合計売上金額（請求先）";

            // 計算後請求金額（請求先）
            DataColumn ClaimAfCalDemandPrice = new DataColumn(CT_CsDmd_ClaimAfCalDemandPrice, typeof(System.Int64), "", MappingType.Element);
            ClaimAfCalDemandPrice.Caption = "計算後請求金額（請求先）";

            // 売上伝票枚数（請求先）
            DataColumn ClaimSaleslSlipCount = new DataColumn(CT_CsDmd_ClaimSaleslSlipCount, typeof(System.Int64), "", MappingType.Element);
            ClaimSaleslSlipCount.Caption = "売上伝票枚数（請求先）";

            // ****************
            // 得意先情報
            // ****************
            // 名称
            DataColumn Name = new DataColumn(CT_CsDmd_Name, typeof(String), "", MappingType.Element);
            Name.Caption = "名称";

            // 名称２
            DataColumn Name2 = new DataColumn(CT_CsDmd_Name2, typeof(String), "", MappingType.Element);
            Name2.Caption = "名称２";

            // カナ
            DataColumn Kana = new DataColumn(CT_CsDmd_Kana, typeof(String), "", MappingType.Element);
            Kana.Caption = "カナ";

            // 郵便番号
            DataColumn PostNo = new DataColumn(CT_CsDmd_PostNo, typeof(String), "", MappingType.Element);
            PostNo.Caption = "郵便番号";

            // 住所１（都道府県市区郡・町村・字）
            DataColumn Address1 = new DataColumn(CT_CsDmd_Address1, typeof(String), "", MappingType.Element);
            Address1.Caption = "住所１（都道府県市区郡・町村・字）";

            // 住所２（丁目）
            DataColumn Address2 = new DataColumn(CT_CsDmd_Address2, typeof(System.Int32), "", MappingType.Element);
            Address2.Caption = "住所２（丁目）";

            // 住所３（番地）
            DataColumn Address3 = new DataColumn(CT_CsDmd_Address3, typeof(String), "", MappingType.Element);
            Address3.Caption = "住所３（番地）";

            // 住所４（アパート名称）
            DataColumn Address4 = new DataColumn(CT_CsDmd_Address4, typeof(String), "", MappingType.Element);
            Address4.Caption = "住所４（アパート名称）";

            // 編集後住所１
            DataColumn EditAddress1 = new DataColumn(CT_CsDmd_EditAddress1, typeof(String), "", MappingType.Element);
            EditAddress1.Caption = "編集後住所１";

            // 編集後住所２
            DataColumn EditAddress2 = new DataColumn(CT_CsDmd_EditAddress2, typeof(String), "", MappingType.Element);
            EditAddress2.Caption = "編集後住所２";

            // 編集後住所３
            DataColumn EditAddress3 = new DataColumn(CT_CsDmd_EditAddress3, typeof(String), "", MappingType.Element);
            EditAddress3.Caption = "編集後住所３";

            // 編集後住所１（リスト印刷用住所1行目）
            DataColumn ListAddress1 = new DataColumn(CT_CsDmd_ListAddress1, typeof(String), "", MappingType.Element);

            // 編集後住所２（リスト印刷用住所2行目）
            DataColumn ListAddress2 = new DataColumn(CT_CsDmd_ListAddress2, typeof(String), "", MappingType.Element);

            // 編集後住所３（リスト印刷用住所3行目）
            DataColumn ListAddress3 = new DataColumn(CT_CsDmd_ListAddress3, typeof(String), "", MappingType.Element);

            // 電話番号（自宅
            DataColumn HomeTelNo = new DataColumn(CT_CsDmd_HomeTelNo, typeof(String), "", MappingType.Element);
            HomeTelNo.Caption = "電話番号(自宅)";

            // 電話番号（勤務先
            DataColumn OfficeTelNo = new DataColumn(CT_CsDmd_OfficeTelNo, typeof(String), "", MappingType.Element);
            OfficeTelNo.Caption = "電話番号（勤務先）";

            // 電話番号（携帯
            DataColumn PortableTelNo = new DataColumn(CT_CsDmd_PortableTelNo, typeof(String), "", MappingType.Element);
            PortableTelNo.Caption = "電話番号（携帯）";

            // FAX番号（自宅）
            DataColumn HomeFaxNo = new DataColumn(CT_CsDmd_HomeFaxNo, typeof(String), "", MappingType.Element);
            HomeFaxNo.Caption = "FAX番号（自宅）";

            // FAX番号（勤務先）
            DataColumn OfficeFaxNo = new DataColumn(CT_CsDmd_OfficeFaxNo, typeof(String), "", MappingType.Element);
            OfficeFaxNo.Caption = "FAX番号（勤務先）";

            // 電話番号（その他）
            DataColumn OthersTelNo = new DataColumn(CT_CsDmd_OthersTelNo, typeof(String), "", MappingType.Element);
            OthersTelNo.Caption = "電話番号（その他）";

            // 主連絡先区分[0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･]
            DataColumn MainContactCode = new DataColumn(CT_CsDmd_MainContactCode, typeof(System.Int32), "", MappingType.Element);
            MainContactCode.Caption = "主連絡先区分";

            // 主連絡タイトル
            DataColumn MainContactName = new DataColumn(CT_CsDmd_MainContactName, typeof(String), "", MappingType.Element);
            MainContactName.Caption = "主連絡先区分";

            // 主連絡先電話番号
            DataColumn MainContactTelNo = new DataColumn(CT_CsDmd_MainContactTelNo, typeof(String), "", MappingType.Element);
            MainContactTelNo.Caption = "主連絡先電話番号";

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

            // 御振込期限(印刷用)
            DataColumn CollectMoneyDate = new DataColumn(CT_CsDmd_CollectMoneyDate, typeof(String), "", MappingType.Element);
            CollectMoneyDate.Caption = "御振込期限(印刷用)";

            // 御支払期限(印刷用)
            DataColumn PaymentMoneyDate = new DataColumn(CT_CsDmd_PaymentMoneyDate, typeof(String), "", MappingType.Element);
            PaymentMoneyDate.Caption = "御振込期限(印刷用)";

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

            // 敬称
            DataColumn HonorificTitle = new DataColumn(CT_CsDmd_HonorificTitle, typeof(String), "", MappingType.Element);
            HonorificTitle.Caption = "敬称";

            // 諸口コード
            DataColumn OutputNameCode = new DataColumn(CT_CsDmd_OutputNameCode, typeof(System.Int32), "", MappingType.Element);
            OutputNameCode.Caption = "諸口コード";

            // 諸口名称
            DataColumn OutputName = new DataColumn(CT_CsDmd_OutputName, typeof(String), "", MappingType.Element);
            OutputName.Caption = "諸口名称";

            // 得意先分析コード１
            DataColumn CustAnalysCode1 = new DataColumn(CT_CsDmd_CustAnalysCode1, typeof(System.Int32), "", MappingType.Element);
            CustAnalysCode1.Caption = "得意先分析コード１";
            // 得意先分析コード２
            DataColumn CustAnalysCode2 = new DataColumn(CT_CsDmd_CustAnalysCode2, typeof(System.Int32), "", MappingType.Element);
            CustAnalysCode2.Caption = "得意先分析コード２";
            // 得意先分析コード３
            DataColumn CustAnalysCode3 = new DataColumn(CT_CsDmd_CustAnalysCode3, typeof(System.Int32), "", MappingType.Element);
            CustAnalysCode3.Caption = "得意先分析コード３";
            // 得意先分析コード４
            DataColumn CustAnalysCode4 = new DataColumn(CT_CsDmd_CustAnalysCode4, typeof(System.Int32), "", MappingType.Element);
            CustAnalysCode4.Caption = "得意先分析コード４";
            // 得意先分析コード５
            DataColumn CustAnalysCode5 = new DataColumn(CT_CsDmd_CustAnalysCode5, typeof(System.Int32), "", MappingType.Element);
            CustAnalysCode5.Caption = "得意先分析コード５";
            // 得意先分析コード６
            DataColumn CustAnalysCode6 = new DataColumn(CT_CsDmd_CustAnalysCode6, typeof(System.Int32), "", MappingType.Element);
            CustAnalysCode6.Caption = "得意先分析コード６";

            // 得意先銀行1
            DataColumn AccountNoInfoTK1 = new DataColumn(CT_CsDmd_AccountNoInfoTK1, typeof(String), "", MappingType.Element);
            AccountNoInfoTK1.Caption = "得意先銀行1";
            // 得意先銀行2
            DataColumn AccountNoInfoTK2 = new DataColumn(CT_CsDmd_AccountNoInfoTK2, typeof(String), "", MappingType.Element);
            AccountNoInfoTK2.Caption = "得意先銀行2";
            // 得意先銀行3
            DataColumn AccountNoInfoTK3 = new DataColumn(CT_CsDmd_AccountNoInfoTK3, typeof(String), "", MappingType.Element);
            AccountNoInfoTK3.Caption = "得意先銀行3";

            // 総額表示区分
            DataColumn TotalAmountDispWayCd = new DataColumn(CT_CsDmd_TotalAmountDispWayCd, typeof(Int32), "", MappingType.Element);
            TotalAmountDispWayCd.Caption = "総額表示区分";

            // 自社PR文
            DataColumn CompanyPr = new DataColumn(CT_CsDmd_CompanyPr, typeof(String), "", MappingType.Element);
            // 自社名称1
            DataColumn CompanyName1 = new DataColumn(CT_CsDmd_CompanyName1, typeof(String), "", MappingType.Element);
            // 自社名称2
            DataColumn CompanyName2 = new DataColumn(CT_CsDmd_CompanyName2, typeof(String), "", MappingType.Element);
            // 郵便番号
            DataColumn CompanyPostNo = new DataColumn(CT_CsDmd_CompanyPostNo, typeof(String), "", MappingType.Element);
            // 自社住所１行目(印刷用)
            DataColumn EditCompanyAddress1 = new DataColumn(CT_CsDmd_EditCompanyAddress1, typeof(String), "", MappingType.Element);
            // 自社住所２行目(印刷用)
            DataColumn EditCompanyAddress2 = new DataColumn(CT_CsDmd_EditCompanyAddress2, typeof(String), "", MappingType.Element);
            // 自社電話番号1(印刷用タイトル含む)
            DataColumn EditCompanyTelNo1 = new DataColumn(CT_CsDmd_EditCompanyTelNo1, typeof(String), "", MappingType.Element);
            // 自社電話番号2(印刷用タイトル含む)
            DataColumn EditCompanyTelNo2 = new DataColumn(CT_CsDmd_EditCompanyTelNo2, typeof(String), "", MappingType.Element);
            // 自社電話番号3(印刷用タイトル含む)
            DataColumn EditCompanyTelNo3 = new DataColumn(CT_CsDmd_EditCompanyTelNo3, typeof(String), "", MappingType.Element);
            // 銀行振込案内文
            DataColumn TransferGuidance = new DataColumn(CT_CsDmd_TransferGuidance, typeof(String), "", MappingType.Element);
            // 銀行口座1
            DataColumn AccountNoInfo1 = new DataColumn(CT_CsDmd_AccountNoInfo1, typeof(String), "", MappingType.Element);
            // 銀行口座2
            DataColumn AccountNoInfo2 = new DataColumn(CT_CsDmd_AccountNoInfo2, typeof(String), "", MappingType.Element);
            // 銀行口座3
            DataColumn AccountNoInfo3 = new DataColumn(CT_CsDmd_AccountNoInfo3, typeof(String), "", MappingType.Element);
            // 自社設定摘要1
            DataColumn CompanyProt1 = new DataColumn(CT_CsDmd_CompanyProt1, typeof(String), "", MappingType.Element);
            // 自社設定摘要2
            DataColumn CompanyProt2 = new DataColumn(CT_CsDmd_CompanyProt2, typeof(String), "", MappingType.Element);
            // 請求設定摘要1
            DataColumn BillOutline1 = new DataColumn(CT_CsDmd_CompanySetNote1, typeof(String), "", MappingType.Element);
            // 請求設定摘要2
            DataColumn BillOutline2 = new DataColumn(CT_CsDmd_CompanySetNote2, typeof(String), "", MappingType.Element);
            // 発行年月日
            DataColumn Publication = new DataColumn(CT_CsDmd_Publication, typeof(String), "", MappingType.Element);
            // 請求年月日
            DataColumn TargetAddUpDate = new DataColumn(CT_CsDmd_TargetAddUpDate, typeof(String), "", MappingType.Element);
            // 請求月
            DataColumn TargetAddUpMonth = new DataColumn(CT_CsDmd_TargetAddUpMonth, typeof(System.Int32), "", MappingType.Element);
            // 印刷用請求金額
            DataColumn PrintAfCalDemandPrice = new DataColumn(CT_CsDmd_PrintAfCalDemandPrice, typeof(String), "", MappingType.Element);

            // 自社画像
            DataColumn CampImg = new DataColumn(CT_CsDmd_CampImgID, typeof(Image), "", MappingType.Element);
            DataColumn ImageCommentForPrt1 = new DataColumn(CT_CsDmd_ImageCommentForPrt1, typeof(String), "", MappingType.Element);
            DataColumn ImageCommentForPrt2 = new DataColumn(CT_CsDmd_ImageCommentForPrt2, typeof(String), "", MappingType.Element);

            // 銀行1
            DataColumn AccountNoInfoDsp1 = new DataColumn(CT_CsDmd_AccountNoInfoDsp1, typeof(String), "", MappingType.Element);
            AccountNoInfoDsp1.Caption = "銀行1";
            // 銀行2
            DataColumn AccountNoInfoDsp2 = new DataColumn(CT_CsDmd_AccountNoInfoDsp2, typeof(String), "", MappingType.Element);
            AccountNoInfoDsp2.Caption = "銀行2";
            // 銀行3
            DataColumn AccountNoInfoDsp3 = new DataColumn(CT_CsDmd_AccountNoInfoDsp3, typeof(String), "", MappingType.Element);
            AccountNoInfoDsp3.Caption = "銀行3";
            
            // 2008.09.08 30413 犬飼 項目追加 >>>>>>START
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
            // 2008.09.08 30413 犬飼 項目追加 <<<<<<END

            // --- DEL  大矢睦美  2010/01/25 ---------->>>>>
            // 2009.01.23 30413 犬飼 請求書出力区分を追加 >>>>>>START
            // 請求書出力区分コード
            //DataColumn BillOutputCode = new DataColumn(CT_Blnce_BillOutputCode, typeof(Int32), "", MappingType.Element);
            // 2009.01.23 30413 犬飼 請求書出力区分を追加 <<<<<<END
            // --- DEL  大矢睦美  2010/01/25 ----------<<<<<

            // 領収書出力区分コード
            DataColumn ReceiptOutputCode = new DataColumn(CT_Blnce_ReceiptOutputCode, typeof(Int32), "", MappingType.Element);  // ADD 2009/04/07

            // --- ADD  大矢睦美  2010/01/25 ---------->>>>>
            //合計請求書出力区分コード
            DataColumn TotalBillOutputDiv = new DataColumn(CT_Blnce_TotalBillOutputDiv, typeof(Int32), "", MappingType.Element);
            //明細請求書出力区分コード
            DataColumn DetailBillOutputCode = new DataColumn(CT_Blnce_DetailBillOutputCode, typeof(Int32), "", MappingType.Element);
            //伝票合計請求書出力区分コード
            DataColumn SlipTtlBillOutputDiv = new DataColumn(CT_Blnce_SlipTtlBillOutputDiv, typeof(Int32), "", MappingType.Element);
            // --- ADD  大矢睦美  2010/01/25 ----------<<<<<

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
            //--- ADD 2022/08/24 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
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
            //--- ADD 2022/08/24 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
            _demandDataSet.Tables.AddRange(new DataTable[] { _custDmdPrcDataTable });
            _custDmdPrcDataTable.Columns.AddRange(new DataColumn[]{
                UniqueID,
                    DataType,
                    RecordName,     // ADD 2009/04/20
				    PrintFlag,
				    PrintIndex,
				    AddUpSecCode,
				    AddUpSecName,
                    // 2008.09.05 30413 犬飼 項目追加 >>>>>>START
                    ClaimSectionCode,
                    ClaimSectionName,
                    // 2008.09.05 30413 犬飼 項目追加 <<<<<<END
                    // 2009.01.21 30413 犬飼 項目追加 >>>>>>START
                    ResultsSectCd,
                    // 2009.01.21 30413 犬飼 項目追加 <<<<<<END
                    DemandPtnNo,
                    DmdDtlPtnNo,
                    DemandOrPay,
                    ClaimCode,
                    // 2008.11.19 30413 犬飼 抽出結果表示用 >>>>>>START
                    ClaimCodeDisp,
                    // 2008.11.19 30413 犬飼 抽出結果表示用 <<<<<<END
                    ClaimName,
                    ClaimName2,
                    ClaimSnm,
				    CustomerCode,
                    CustomerName,
                    CustomerName2,
                    CustomerSnm,
                    // 2008.11.19 30413 犬飼 抽出結果表示用 >>>>>>START
                    CustomerCodeDisp,
                    CustomerSnmDisp,
                    // 2008.11.19 30413 犬飼 抽出結果表示用 <<<<<<END
				    // 2008.09.08 30413 犬飼 未使用項目削除 >>>>>>START
                    //EditCustomerName1,
                    //EditCustomerName2,
				    // 2008.09.08 30413 犬飼 未使用項目削除 <<<<<<END
                    AddUpDate,
				    AddUpDateInt,		
				    AddUpYearMonth,
                    LastTimeDemand,
                    // 2008.11.18 30413 犬飼 請求残高を抽出結果グリッドの前回請求金額に置き換えるためテーブル追加位置を変更 >>>>>>START
                    DemandBalance,
                    // 2008.11.18 30413 犬飼 請求残高を抽出結果グリッドの前回請求金額に置き換えるためテーブル追加位置を変更 <<<<<<END
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
                    // 2009.01.21 30413 犬飼 計算後請求金額(フィルター用)を追加 >>>>>>START
                    AfCalDemandPriceFilter,
                    // 2009.01.21 30413 犬飼 計算後請求金額(フィルター用)を追加 <<<<<<END
                    SaleslSlipCount,
                    BillPrintDate,
                    BillPrintDatePrt,
                    ExpectedDepositDate,
                    ExpectedDepositDatePrt,
                    CollectCond,
                    ConsTaxRate,
                    FractionProcCd,
                    CAddUpUpdExecDate,      
                    CAddUpUpdExecDatePrt,   
                    StartCAddUpUpdDate,
                    StartCAddUpUpdDatePrt,
                    LastCAddUpUpdDate,
                    LastCAddUpUpdDatePrt,
                    AddUpADatePrint,
                    PrintTtlConsTaxDmd,
                    CollectMoneyName,
				    CollectMoneyDay,
				    CollectMoneyDayNm,
                    CollectMoneyDate,
                    PaymentMoneyDate,
                    ClaimLastTimeDemand,
                    ClaimThisTimeDmdNrml,
                    ClaimThisTimeTtlBlcDmd,
                    ClaimThisTimeSales,
                    ClaimThisSalesPricRgdsDis,
                    ClaimOfsThisTimeSales,
                    ClaimOfsThisSalesTax,
                    ClaimOfsThisSalesSum,
                    ClaimAfCalDemandPrice,
                    ClaimSaleslSlipCount,
				    Name,
                    Name2,
                    Kana,
                    PostNo,
                    Address1,
                    Address2,
                    Address3,
                    Address4,
                    EditAddress1,
                    EditAddress2,
                    EditAddress3,
                    ListAddress1,
                    ListAddress2,
                    ListAddress3,
                    HomeTelNo,
                    OfficeTelNo,
                    PortableTelNo,
                    HomeFaxNo,
                    OfficeFaxNo,
                    OthersTelNo,
                    MainContactCode,
                    MainContactName,
                    MainContactTelNo,
				    TotalDay,
				    PrintTotalDay,
				    CustomerAgentCd,
				    CustomerAgentNm,
				    BillCollecterCd,
				    BillCollecterNm,
				    EmployeeCd,
				    EmployeeNm,
                    HonorificTitle,
				    OutputNameCode,
				    OutputName,
				    CustAnalysCode1,
				    CustAnalysCode2,
				    CustAnalysCode3,
				    CustAnalysCode4,
				    CustAnalysCode5,
				    CustAnalysCode6,
                    AccountNoInfoTK1,
                    AccountNoInfoTK2,
                    AccountNoInfoTK3,
                    TotalAmountDispWayCd,
                    CompanyPr,
				    CompanyName1,
				    CompanyName2,
				    CompanyPostNo,
				    EditCompanyAddress1,
				    EditCompanyAddress2,
				    EditCompanyTelNo1,
				    EditCompanyTelNo2,
				    EditCompanyTelNo3,
                    CampImg,//20070316 iwa add
                    ImageCommentForPrt1,//20070316 iwa add
                    ImageCommentForPrt2,//20070316 iwa add
				    TransferGuidance,
				    AccountNoInfo1,
				    AccountNoInfo2,
				    AccountNoInfo3,
				    CompanyProt1,
				    CompanyProt2,
				    BillOutline1,
				    BillOutline2,
				    Publication,
				    TargetAddUpDate,
				    TargetAddUpMonth,
				    PrintAfCalDemandPrice,
                    AccountNoInfoDsp1,
                    AccountNoInfoDsp2,
                    AccountNoInfoDsp3,
                    // 2008.09.08 30413 犬飼 項目追加 >>>>>>START
                    // 2008.11.18 30413 犬飼 請求残高を抽出結果グリッドの前回請求金額に置き換えるためテーブル追加位置を変更 >>>>>>START
                    //DemandBalance,
                    // 2008.11.18 30413 犬飼 請求残高を抽出結果グリッドの前回請求金額に置き換えるためテーブル追加位置を変更 <<<<<<END
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
                    // 2009.01.22 30413 犬飼 請求書出力区分追加 >>>>>>START
                    //MoneyKindDiv112
                    MoneyKindDiv112,
                    // --- UPD  大矢睦美  2010/01/25 ---------->>>>>
                    // 2008.09.08 30413 犬飼 項目追加 <<<<<<END
                    //BillOutputCode    // DEL 2009/04/07
                    //BillOutputCode,     // ADD 2009/04/07
                    // 2009.01.22 30413 犬飼 請求書出力区分追加 <<<<<<END                   
                    //ReceiptOutputCode   // ADD 2009/04/07
                    ReceiptOutputCode,
                    TotalBillOutputDiv,
                    DetailBillOutputCode,
                    SlipTtlBillOutputDiv,
                    // --- UPD  大矢睦美  2010/01/25 ----------<<<<<
                　　// --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                　　TotalThisTimeSalesTaxRate1,
                    TotalThisTimeSalesTaxRate2,
                    TotalThisTimeSalesTaxFree,// ADD 2022/08/24 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    TotalThisTimeSalesOther,
                    TotalThisRgdsDisPricTaxRate1,
                    TotalThisRgdsDisPricTaxRate2,
                    TotalThisRgdsDisPricTaxFree,// ADD 2022/08/24 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    TotalThisRgdsDisPricOther,
                    TotalPureSalesTaxRate1,
                    TotalPureSalesTaxRate2,
                    TotalPureSalesTaxFree,// ADD 2022/08/24 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    TotalPureSalesOther,
                    TotalSalesPricTaxTaxRate1,
                    TotalSalesPricTaxTaxRate2,
                    TotalSalesPricTaxTaxFree,// ADD 2022/08/24 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    TotalSalesPricTaxOther,
                    TotalThisSalesSumTaxRate1,
                    TotalThisSalesSumTaxRate2,
                    TotalThisSalesSumTaxFree,// ADD 2022/08/24 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    TotalThisSalesSumTaxOther,
                    TotalSalesSlipCountTaxRate1,
                    TotalSalesSlipCountTaxRate2,
                    TotalSalesSlipCountTaxFree,// ADD 2022/08/24 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正）
                    TotalSalesSlipCountOther,
                    TitleTaxRate1,
                    TitleTaxRate2,
　　　　　　　　　　// --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<

			    });
            // プライマリーキーをユニークIDに設定
            _custDmdPrcDataTable.PrimaryKey = new DataColumn[] { UniqueID };
            _custDmdPrcDataView.Table = _custDmdPrcDataTable;
            // 2009.01.26 30413 犬飼 デフォルトは得意先順とする >>>>>>START
            //_custDmdPrcDataView.Sort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_CustomerCode + "," + CT_CsDmd_AddUpDate;
            // 請求拠点＋請求得意先＋実績拠点＋得意先
            _custDmdPrcDataView.Sort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_CustomerCode;

            // 印刷用DataTable作成
            _custDmdPrcPrintDataTable = _custDmdPrcDataTable.Clone();
            _custDmdPrcDataViewPrint.Table = _custDmdPrcPrintDataTable;
            //_custDmdPrcDataViewPrint.Sort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_CustomerCode + "," + CT_CsDmd_AddUpDate;
            // 請求拠点＋請求得意先＋実績拠点＋得意先
            _custDmdPrcDataViewPrint.Sort = CT_CsDmd_AddUpSecCode + "," + CT_CsDmd_ClaimCode + "," + CT_CsDmd_ResultsSectCd + "," + CT_CsDmd_CustomerCode;
            // 2009.01.26 30413 犬飼 デフォルトは得意先順とする <<<<<<END
            
            _custDmdPrcDataViewPrint.RowFilter = String.Format("{0} = {1}", CT_CsDmd_PrintFlag, true);

        }

        #region 売上明細テーブル情報作成処理
        /// <summary>
        /// 売上明細テーブル情報作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        public void CreateSaleTable(ref DataSet ds)
        {
            DataTable dt = new DataTable(CT_SaleDataTable);
            // データカラム情報作成
            // 請求先コード
            DataColumn ClaimCode = new DataColumn(CT_SaleDepo_ClaimCode, typeof(System.Int32), "", MappingType.Element);
            ClaimCode.Caption = "請求先コード";
            // 請求先名
            DataColumn ClaimName = new DataColumn(CT_SaleDepo_ClaimName, typeof(String), "", MappingType.Element);
            ClaimName.Caption = "請求先名称";
            // 請求先名２
            DataColumn ClaimName2 = new DataColumn(CT_SaleDepo_ClaimName2, typeof(String), "", MappingType.Element);
            ClaimName2.Caption = "請求先名称2";
            // 請求先略称
            DataColumn ClaimSnm = new DataColumn(CT_SaleDepo_ClaimSnm, typeof(String), "", MappingType.Element);
            ClaimSnm.Caption = "請求先略称";
            // 得意先コード
            DataColumn CustomerCode = new DataColumn(CT_SaleDepo_CustomerCode, typeof(System.Int32), "", MappingType.Element);
            CustomerCode.Caption = "得意先コード";
            // 得意先名
            DataColumn CustomerName = new DataColumn(CT_SaleDepo_CustomerName, typeof(String), "", MappingType.Element);
            CustomerName.Caption = "得意先名称";
            // 得意先名2
            DataColumn CustomerName2 = new DataColumn(CT_SaleDepo_CustomerName2, typeof(String), "", MappingType.Element);
            CustomerName2.Caption = "得意先名称2";
            // 得意先略称
            DataColumn CustomerSnm = new DataColumn(CT_SaleDepo_CustomerSnm, typeof(String), "", MappingType.Element);
            CustomerSnm.Caption = "得意先略称";
            // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
            //// 赤伝区分(0:黒,1:赤,2相殺済み黒)       
            //DataColumn DebitNoteDiv = new DataColumn(CT_SaleDepo_DebitNoteDiv, typeof(System.Int32), "", MappingType.Element);
            //DebitNoteDiv.Caption = "赤伝区分";
            // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
            // 計上日付                            
            DataColumn AddUpADate = new DataColumn(CT_SaleDepo_AddUpADate, typeof(System.DateTime), "", MappingType.Element);
            AddUpADate.Caption = "計上日付";
            // 計上日付(表示用)
            DataColumn AddUpADateDisp = new DataColumn(CT_SaleDepo_AddUpADateDisp, typeof(String), "", MappingType.Element);
            AddUpADateDisp.Caption = "計上日付";
            // データ入力システム
            DataColumn DataInputSystem = new DataColumn(CT_SaleDepo_DataInputSystem, typeof(System.Int32), "", MappingType.Element);
            DataInputSystem.Caption = "データ入力システム";
            // 伝票番号・入金番号                          
            DataColumn SalesSlipNum = new DataColumn(CT_SaleDepo_SalesSlipNum, typeof(System.Int32), "", MappingType.Element);
            SalesSlipNum.Caption = "伝票番号";
            // 売上伝票区分                          
            DataColumn SalesSlipCd = new DataColumn(CT_SaleDepo_SalesSlipCd, typeof(String), "", MappingType.Element);
            SalesSlipCd.Caption = "売上伝票区分";
            // 売掛区分                          
            DataColumn AccRecDivCd = new DataColumn(CT_SaleDepo_AccRecDivCd, typeof(String), "", MappingType.Element);
            AccRecDivCd.Caption = "売掛区分";
            // 相手先伝票番号
            DataColumn PartySaleSlipNum = new DataColumn(CT_SaleDepo_PartySaleSlipNum, typeof(String), "", MappingType.Element);
            PartySaleSlipNum.Caption = "相手先伝票番号";
            // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
            // 赤黒連結受注番号
            //DataColumn DebitNLnkAcptAnOdr = new DataColumn(CT_SaleDepo_DebitNLnkAcptAnOdr, typeof(String), "", MappingType.Element);
            //DebitNLnkAcptAnOdr.Caption = "赤黒連結受注番号";
            // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
            // 売上伝票合計（税込み）
            DataColumn SalesTotalTaxInc = new DataColumn(CT_SaleDepo_SalesTotalTaxInc, typeof(System.Int64), "", MappingType.Element);
            SalesTotalTaxInc.Caption = "売上伝票合計(税込み)";
            // 売上金額(税抜き)
            DataColumn SalesTotalTaxExc = new DataColumn(CT_SaleDepo_SalesTotalTaxExc, typeof(System.Int64), "", MappingType.Element);
            SalesTotalTaxExc.Caption = "売上伝票合計(税抜き)";
            // 売上伝票消費税額
            DataColumn SalesTotalTax = new DataColumn(CT_SaleDepo_SalesTotalTax, typeof(System.Int64), "", MappingType.Element);
            SalesTotalTax.Caption = "売上伝票消費税額";
            // 伝票備考
            DataColumn SlipNote = new DataColumn(CT_SaleDepo_SlipNote, typeof(String), "", MappingType.Element);
            SlipNote.Caption = "伝票備考";
            // 伝票備考２
            DataColumn SlipNote2 = new DataColumn(CT_SaleDepo_SlipNote2, typeof(String), "", MappingType.Element);
            SlipNote2.Caption = "伝票備考２";
            // 売上行番号                          
            DataColumn SalesRowNo = new DataColumn(CT_SaleDepo_SalesRowNo, typeof(System.Int32), "", MappingType.Element);
            SalesRowNo.Caption = "売上行番号";
            // 売上伝票区分（明細）                          
            DataColumn SalesSlipCdDtl = new DataColumn(CT_SaleDepo_SalesSlipCdDtl, typeof(String), "", MappingType.Element);
            SalesSlipCdDtl.Caption = "売上伝票区分（明細）";
            // 受注番号                          
            DataColumn AcceptAnOrderNo = new DataColumn(CT_SaleDepo_AcceptAnOrderNo, typeof(String), "", MappingType.Element);
            AcceptAnOrderNo.Caption = "受注番号";
            // メーカーコード                          
            DataColumn GoodsMakerCd = new DataColumn(CT_SaleDepo_GoodsMakerCd, typeof(System.Int32), "", MappingType.Element);
            GoodsMakerCd.Caption = "メーカーコード";
            // メーカー名称                          
            DataColumn MakerName = new DataColumn(CT_SaleDepo_MakerName, typeof(String), "", MappingType.Element);
            MakerName.Caption = "メーカー名称";
            // 商品番号
            DataColumn GoodsNo = new DataColumn(CT_SaleDepo_GoodsNo, typeof(String), "", MappingType.Element);
            GoodsNo.Caption = "商品番号";
            // 商品名
            DataColumn GoodsName = new DataColumn(CT_SaleDepo_GoodsName, typeof(String), "", MappingType.Element);
            GoodsName.Caption = "商品名";
            // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
            //// 商品区分コード
            //DataColumn MediumGoodsGanreCode = new DataColumn(CT_SaleDepo_MediumGoodsGanreCode, typeof(String), "", MappingType.Element);
            //MediumGoodsGanreCode.Caption = "商品区分コード";
            //// 商品区分名
            //DataColumn MediumGoodsGanreName = new DataColumn(CT_SaleDepo_MediumGoodsGanreName, typeof(String), "", MappingType.Element);
            //MediumGoodsGanreName.Caption = "商品区分名";
            //// 商品区分グループコード
            //DataColumn LargeGoodsGanreCode = new DataColumn(CT_SaleDepo_LargeGoodsGanreCode, typeof(String), "", MappingType.Element);
            //LargeGoodsGanreCode.Caption = "商品区分グループコード";
            //// 商品区分グループ名
            //DataColumn LargeGoodsGanreName = new DataColumn(CT_SaleDepo_LargeGoodsGanreName, typeof(String), "", MappingType.Element);
            //LargeGoodsGanreName.Caption = "商品区分グループ名";
            //// 商品区分詳細コード
            //DataColumn DetailGoodsGanreCode = new DataColumn(CT_SaleDepo_DetailGoodsGanreCode, typeof(String), "", MappingType.Element);
            //DetailGoodsGanreCode.Caption = "商品区分詳細コード";
            //// 商品区分詳細名称
            //DataColumn DetailGoodsGanreName = new DataColumn(CT_SaleDepo_DetailGoodsGanreName, typeof(String), "", MappingType.Element);
            //DetailGoodsGanreName.Caption = "商品区分詳細名称";
            // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
            // BL商品コード                          
            DataColumn BLGoodsCode = new DataColumn(CT_SaleDepo_BLGoodsCode, typeof(System.Int32), "", MappingType.Element);
            BLGoodsCode.Caption = "BL商品コード";
            // BL商品コード名称
            DataColumn BLGoodsFullName = new DataColumn(CT_SaleDepo_BLGoodsFullName, typeof(String), "", MappingType.Element);
            BLGoodsFullName.Caption = "BL商品コード名称";
            // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
            //// 自社分類コード
            //DataColumn EnterpriseGanreCode = new DataColumn(CT_SaleDepo_EnterpriseGanreCode, typeof(System.Int32), "", MappingType.Element);
            //EnterpriseGanreCode.Caption = "自社分類コード";
            //// 自社分類名称
            //DataColumn EnterpriseGanreName = new DataColumn(CT_SaleDepo_EnterpriseGanreName, typeof(String), "", MappingType.Element);
            //EnterpriseGanreName.Caption = "自社分類名称";
            //// 単位コード
            //DataColumn UnitCode = new DataColumn(CT_SaleDepo_UnitCode, typeof(System.Int32), "", MappingType.Element);
            //UnitCode.Caption = "単位コード";
            //// 単位名称
            //DataColumn UnitName = new DataColumn(CT_SaleDepo_UnitName, typeof(String), "", MappingType.Element);
            //UnitName.Caption = "単位名称";
            // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
            // 売上単価（税込，浮動）
            DataColumn SalesUnPrcTaxIncFl = new DataColumn(CT_SaleDepo_SalesUnPrcTaxIncFl, typeof(System.Double), "", MappingType.Element);
            SalesUnPrcTaxIncFl.Caption = "売上単価（税込，浮動）";
            // 売上単価（税抜，浮動）
            DataColumn SalesUnPrcTaxExcFl = new DataColumn(CT_SaleDepo_SalesUnPrcTaxExcFl, typeof(System.Double), "", MappingType.Element);
            SalesUnPrcTaxExcFl.Caption = "売上単価（税込，浮動）";
            // 出荷数
            DataColumn ShipmentCnt = new DataColumn(CT_SaleDepo_ShipmentCnt, typeof(System.Double), "", MappingType.Element);
            ShipmentCnt.Caption = "出荷数";
            // 売上金額（税込み）
            DataColumn SalesMoneyTaxInc = new DataColumn(CT_SaleDepo_SalesMoneyTaxInc, typeof(System.Int64), "", MappingType.Element);
            SalesMoneyTaxInc.Caption = "売上金額（税込み）";
            // 売上金額（税抜き）
            DataColumn SalesMoneyTaxExc = new DataColumn(CT_SaleDepo_SalesMoneyTaxExc, typeof(System.Int64), "", MappingType.Element);
            SalesMoneyTaxExc.Caption = "売上金額（税抜き）";
            // 売上金額（税抜き 印刷用）
            DataColumn SalesMoneyTaxExc1 = new DataColumn(CT_SaleDepo_SalesMoneyTaxExc1, typeof(System.Int64), "", MappingType.Element);
            SalesMoneyTaxExc1.Caption = "売上金額（税抜き 印刷用）";
            // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
            //// 消費税調整額
            //DataColumn TaxAdjust = new DataColumn(CT_SaleDepo_TaxAdjust, typeof(System.Int64), "", MappingType.Element);
            //TaxAdjust.Caption = "消費税調整額";
            //// 残高調整額
            //DataColumn BalanceAdjust = new DataColumn(CT_SaleDepo_BalanceAdjust, typeof(System.Int64), "", MappingType.Element);
            //BalanceAdjust.Caption = "残高調整額";
            // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
            // 課税区分
            DataColumn TaxationDivCd = new DataColumn(CT_SaleDepo_TaxationDivCd, typeof(System.Int64), "", MappingType.Element);
            TaxationDivCd.Caption = "課税区分";
            // 相手先伝票番号（明細）
            DataColumn PartySlipNumDtl = new DataColumn(CT_SaleDepo_PartySlipNumDtl, typeof(String), "", MappingType.Element);
            PartySlipNumDtl.Caption = "相手先伝票番号（明細）";
            // 明細備考
            DataColumn DtlNote = new DataColumn(CT_SaleDepo_DtlNote, typeof(String), "", MappingType.Element);
            DtlNote.Caption = "明細備考";
            // 伝票メモ１
            DataColumn SlipMemo1 = new DataColumn(CT_SaleDepo_SlipMemo1, typeof(String), "", MappingType.Element);
            SlipMemo1.Caption = "伝票メモ１";
            // 伝票メモ２
            DataColumn SlipMemo2 = new DataColumn(CT_SaleDepo_SlipMemo2, typeof(String), "", MappingType.Element);
            SlipMemo2.Caption = "伝票メモ２";
            // 伝票メモ３
            DataColumn SlipMemo3 = new DataColumn(CT_SaleDepo_SlipMemo3, typeof(String), "", MappingType.Element);
            SlipMemo3.Caption = "伝票メモ３";
            // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
            //// 伝票メモ４
            //DataColumn SlipMemo4 = new DataColumn(CT_SaleDepo_SlipMemo4, typeof(String), "", MappingType.Element);
            //SlipMemo4.Caption = "伝票メモ４";
            //// 伝票メモ５
            //DataColumn SlipMemo5 = new DataColumn(CT_SaleDepo_SlipMemo5, typeof(String), "", MappingType.Element);
            //SlipMemo5.Caption = "伝票メモ５";
            //// 伝票メモ６
            //DataColumn SlipMemo6 = new DataColumn(CT_SaleDepo_SlipMemo6, typeof(String), "", MappingType.Element);
            //SlipMemo6.Caption = "伝票メモ６";
            //// 印刷用商品番号
            //DataColumn PrtGoodsNo = new DataColumn(CT_SaleDepo_PrtGoodsNo, typeof(String), "", MappingType.Element);
            //PrtGoodsNo.Caption = "印刷用商品番号";
            //// 印刷用商品名称
            //DataColumn PrtGoodsName = new DataColumn(CT_SaleDepo_PrtGoodsName, typeof(String), "", MappingType.Element);
            //PrtGoodsName.Caption = "印刷用商品名称";
            //// 印刷用商品メーカーコード
            //DataColumn PrtGoodsMakerCd = new DataColumn(CT_SaleDepo_PrtGoodsMakerCd, typeof(String), "", MappingType.Element);
            //PrtGoodsMakerCd.Caption = "印刷用商品メーカーコード";
            //// 印刷用商品メーカー名称
            //DataColumn PrtGoodsMakerNm = new DataColumn(CT_SaleDepo_PrtGoodsMakerNm, typeof(String), "", MappingType.Element);
            //PrtGoodsMakerNm.Caption = "印刷用商品メーカー名称";
            // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
            // 計上拠点コード
            DataColumn AddUpSecCode = new DataColumn(CT_SaleDepo_AddUpSecCode, typeof(String), "", MappingType.Element);
            AddUpSecCode.Caption = "計上拠点コード";
            // 計上拠点名称
            DataColumn AddUpSecName = new DataColumn(CT_SaleDepo_AddUpSecName, typeof(String), "", MappingType.Element);
            AddUpSecName.Caption = "計上拠点名称";
            // 計上日付(印刷用)
            DataColumn AddUpADatePrint = new DataColumn(CT_SaleDepo_AddUpADatePrint, typeof(String), "", MappingType.Element);
            AddUpADatePrint.Caption = "計上日付(印刷用)";
            // 印刷用順位(0:プレート番号ヘッダー用,1:それ以外)
            DataColumn PrintDetailHeaderOder = new DataColumn(CT_SaleDepo_PrintDetailHeaderOder, typeof(System.Int32), "", MappingType.Element);
            PrintDetailHeaderOder.Caption = "印刷用順位";

            ds.Tables.AddRange(new DataTable[] { dt });
            dt.Columns.AddRange(new DataColumn[]{
                                                 ClaimCode,
                                                 ClaimName,
                                                 ClaimName2,
                                                 ClaimSnm,
                                                 CustomerCode,
                                                 CustomerName,
                                                 CustomerName2,
                                                 CustomerSnm,
                                                 // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
                                                 //DebitNoteDiv,
                                                 // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
                                                 AddUpADate,
                                                 AddUpADateDisp,
                                                 DataInputSystem,
                                                 SalesSlipNum,
                                                 SalesSlipCd,
                                                 AccRecDivCd,
                                                 PartySaleSlipNum,
                                                 // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
                                                 //DebitNLnkAcptAnOdr,
                                                 // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
                                                 SalesTotalTaxInc,
                                                 SalesTotalTaxExc,
                                                 SalesTotalTax,
                                                 SlipNote,
                                                 SlipNote2,
                                                 SalesRowNo,
                                                 SalesSlipCdDtl,
                                                 AcceptAnOrderNo,
                                                 GoodsMakerCd,
                                                 MakerName,
                                                 GoodsNo,
                                                 GoodsName, 
                                                 // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
                                                 //MediumGoodsGanreCode,
                                                 //MediumGoodsGanreName,
                                                 //LargeGoodsGanreCode,
                                                 //LargeGoodsGanreName,
                                                 //DetailGoodsGanreCode,
                                                 //DetailGoodsGanreName,
                                                 // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
                                                 BLGoodsCode,
                                                 BLGoodsFullName,
                                                 // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
                                                 //EnterpriseGanreCode,
                                                 //EnterpriseGanreName,
                                                 //UnitCode,
                                                 //UnitName,
                                                 // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
                                                 SalesUnPrcTaxIncFl,
                                                 SalesUnPrcTaxExcFl,
                                                 ShipmentCnt,
                                                 SalesMoneyTaxInc,
                                                 SalesMoneyTaxExc,
                                                 SalesMoneyTaxExc1,  
                                                 // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
                                                 //TaxAdjust, 
                                                 //BalanceAdjust,
                                                 // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
                                                 TaxationDivCd,
                                                 PartySlipNumDtl,
                                                 DtlNote,
                                                 SlipMemo1,
                                                 SlipMemo2,
                                                 SlipMemo3,
                                                 // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
                                                 //SlipMemo4,
                                                 //SlipMemo5,
                                                 //SlipMemo6,
                                                 //PrtGoodsNo,
                                                 //PrtGoodsName, 
                                                 //PrtGoodsMakerCd,
                                                 //PrtGoodsMakerNm,
                                                 // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
                                                 AddUpSecCode,
                                                 AddUpSecName,
                                                 AddUpADatePrint,
                                                 PrintDetailHeaderOder
                                               });
        }
        #endregion
        
        #region 入金明細テーブル情報作成処理
        /// <summary>
        /// 入金明細テーブル情報作成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        public void CreateDepoTable(ref DataSet ds)
        {
            DataTable dt = new DataTable(CT_DepoDataTable);

            // データカラム情報作成
            // 請求先コード
            DataColumn ClaimCode = new DataColumn(CT_SaleDepo_ClaimCode, typeof(System.Int32), "", MappingType.Element);
            ClaimCode.Caption = "請求先コード";
            // 請求先名
            DataColumn ClaimName = new DataColumn(CT_SaleDepo_ClaimName, typeof(String), "", MappingType.Element);
            ClaimName.Caption = "請求先名称";
            // 請求先名2
            DataColumn ClaimName2 = new DataColumn(CT_SaleDepo_ClaimName2, typeof(String), "", MappingType.Element);
            ClaimName2.Caption = "請求先名称2";
            // 請求先略称
            DataColumn ClaimSnm = new DataColumn(CT_SaleDepo_ClaimSnm, typeof(String), "", MappingType.Element);
            ClaimSnm.Caption = "請求先略称";
            // 得意先コード
            DataColumn CustomerCode = new DataColumn(CT_SaleDepo_CustomerCode, typeof(System.Int32), "", MappingType.Element);
            CustomerCode.Caption = "得意先コード";
            // 得意先名
            DataColumn CustomerName = new DataColumn(CT_SaleDepo_CustomerName, typeof(String), "", MappingType.Element);
            CustomerName.Caption = "得意先名称";
            // 得意先名2
            DataColumn CustomerName2 = new DataColumn(CT_SaleDepo_CustomerName2, typeof(String), "", MappingType.Element);
            CustomerName2.Caption = "得意先名称2";
            // 得意先略称
            DataColumn CustomerSnm = new DataColumn(CT_SaleDepo_CustomerSnm, typeof(String), "", MappingType.Element);
            CustomerSnm.Caption = "得意先略称";
            // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
            //// 赤伝区分(0:黒,1:赤,2相殺済み黒)
            //DataColumn DebitNoteDiv = new DataColumn(CT_SaleDepo_DebitNoteDiv, typeof(System.Int32), "", MappingType.Element);
            //DebitNoteDiv.Caption = "赤伝区分";
            // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
            // 計上日付
            DataColumn AddUpADate = new DataColumn(CT_SaleDepo_AddUpADate, typeof(System.DateTime), "", MappingType.Element);
            AddUpADate.Caption = "計上日付";
            // 計上日付(表示用)
            DataColumn AddUpADateDisp = new DataColumn(CT_SaleDepo_AddUpADateDisp, typeof(String), "", MappingType.Element);
            AddUpADateDisp.Caption = "計上日付";
            // データ入力システム
            DataColumn DataInputSystem = new DataColumn(CT_SaleDepo_DataInputSystem, typeof(System.Int32), "", MappingType.Element);
            DataInputSystem.Caption = "データ入力システム";
            // 赤黒入金連結番号
            DataColumn DebitNoteLinkDepoNo = new DataColumn(CT_SaleDepo_DebitNoteLinkDepoNo, typeof(System.Int32), "", MappingType.Element);
            DebitNoteLinkDepoNo.Caption = "赤黒入金連結番号";
            // 入金伝票番号
            DataColumn DepositSlipNo = new DataColumn(CT_SaleDepo_DepositSlipNo, typeof(System.Int32), "", MappingType.Element);
            DepositSlipNo.Caption = "入金伝票番号";
            // 入金金種コード
            DataColumn DepositKindCode = new DataColumn(CT_SaleDepo_DepositKindCode, typeof(Int32), "", MappingType.Element);
            DepositKindCode.Caption = "入金金種コード";
            // 入金金種名称
            DataColumn DepositKindName = new DataColumn(CT_SaleDepo_DepositKindName, typeof(String), "", MappingType.Element);
            DepositKindName.Caption = "入金金種名称";
            // 入金計
            DataColumn DepositTotal = new DataColumn(CT_SaleDepo_DepositTotal, typeof(System.Int64), "", MappingType.Element);
            DepositTotal.Caption = "入金計";
            // 伝票摘要
            DataColumn Outline = new DataColumn(CT_SaleDepo_Outline, typeof(String), "", MappingType.Element);
            Outline.Caption = "伝票摘要";
            // 計上拠点コード
            DataColumn AddUpSecCode = new DataColumn(CT_SaleDepo_AddUpSecCode, typeof(String), "", MappingType.Element);
            AddUpSecCode.Caption = "計上拠点コード";
            // 計上拠点名称
            DataColumn AddUpSecName = new DataColumn(CT_SaleDepo_AddUpSecName, typeof(String), "", MappingType.Element);
            AddUpSecName.Caption = "計上拠点名称";
            // 計上日付(印刷用)
            DataColumn AddUpADatePrint = new DataColumn(CT_SaleDepo_AddUpADatePrint, typeof(String), "", MappingType.Element);
            AddUpADatePrint.Caption = "計上日付(印刷用)";
            // 手形種類
            DataColumn DraftKind = new DataColumn(CT_SaleDepo_DraftKind, typeof(System.Int32), "", MappingType.Element);
            DraftKind.Caption = "手形種類";
            // 手形種類名称
            DataColumn DraftKindName = new DataColumn(CT_SaleDepo_DraftKindName, typeof(String), "", MappingType.Element);
            DraftKindName.Caption = "手形種類名称";
            // 手形区分
            DataColumn DraftDivide = new DataColumn(CT_SaleDepo_DraftDivide, typeof(System.Int32), "", MappingType.Element);
            DraftDivide.Caption = "手形区分";
            // 手形区分名称
            DataColumn DraftDivideName = new DataColumn(CT_SaleDepo_DraftDivideName, typeof(String), "", MappingType.Element);
            DraftDivideName.Caption = "手形区分名称";
            // 手形番号
            DataColumn DraftNo = new DataColumn(CT_SaleDepo_DraftNo, typeof(String), "", MappingType.Element);
            DraftNo.Caption = "手形番号";

            ds.Tables.AddRange(new DataTable[] { dt });
            dt.Columns.AddRange(new DataColumn[]{
                                                 ClaimCode,
                                                 ClaimName,
                                                 ClaimName2,
                                                 ClaimSnm,
                                                 CustomerCode,
                                                 CustomerName,
                                                 CustomerName2,
                                                 CustomerSnm,
                                                 // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
                                                 //DebitNoteDiv,
                                                 // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
                                                 AddUpADate,
                                                 AddUpADateDisp,
                                                 DataInputSystem,
                                                 DebitNoteLinkDepoNo,
                                                 DepositSlipNo,
                                                 DepositKindCode,
                                                 DepositKindName,
                                                 DepositTotal,
                                                 Outline,
                                                 AddUpSecCode,
                                                 AddUpSecName,
                                                 AddUpADatePrint,
                                                 DraftKind,
                                                 DraftKindName,
                                                 DraftDivide,
                                                 DraftDivideName,
                                                 DraftNo
                                               });
        }
        #endregion
        
        /// <summary>
        /// 得意先請求金額情報データ行設定処理(請求)
        /// </summary>
        /// <param name="kingetCustDmdPrcWork">請求KINGET戻りパラメータ</param>
        /// <returns>設定されたデータ行</returns>
        /// <remarks>
        /// <br>Note        : 得意先請求金額情報をデータ行へ設定します。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
        /// <br>Note       : Redmine#47028の請求一覧表Out Of Memoryの対応</br>
        /// <br>Programer  : 時シン</br>
        /// <br>Date       : 2015/09/17</br>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private DataRow CustDmdPrcWorkToDataRow(ExtrInfo_DemandTotal extraInfo, RsltInfo_DemandTotalWork rsltInfo_DemandTotalWork)
        {
            DataRow newRow = _custDmdPrcDataTable.NewRow();

            // 2009.01.19 30413 犬飼 親得意先内訳の処理を追加 >>>>>>START
            if (extraInfo.PrCustDtl == 0)
            {
                // 請求先に含む
                if ((extraInfo.DmdDtl == 0) || (extraInfo.DmdDtl == 2))
                {
                    // 2009.02.06 30413 犬飼 計上拠点と実績拠点を比較対象に追加 >>>>>>START
                    // 請求内訳が"両方"または"得意先"
                    //if (rsltInfo_DemandTotalWork.ClaimCode == rsltInfo_DemandTotalWork.CustomerCode)
                    if ((rsltInfo_DemandTotalWork.ClaimCode == rsltInfo_DemandTotalWork.CustomerCode) &&
                        (rsltInfo_DemandTotalWork.AddUpSecCode.TrimEnd().Equals(rsltInfo_DemandTotalWork.ResultsSectCd.TrimEnd())))
                    {
                        // 親レコードは抽出対象外
                        return null;
                    }
                    // 2009.02.06 30413 犬飼 計上拠点と実績拠点を比較対象に追加 <<<<<<END
                }
            }
            // 2009.01.19 30413 犬飼 親得意先内訳の処理を追加 <<<<<<END

            // 2009.03.12 30413 犬飼 売掛区分の処理を追加 >>>>>>START
            if (extraInfo.SlipPrtKind == 0)
            {
                // 発行タイプ：請求一覧表
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
            //------------ADD BY 凌小青 on 2011/11/28 for Redmine#7765 --------->>>>>>>>>>>
            //------------DEL BY 凌小青 on 2011/11/17 for Redmine#7765 --------->>>>>>>>>>>
            else
            {
                // 発行タイプ：請求書／領収書
                if (rsltInfo_DemandTotalWork.AccRecDivCd == 0)
                {
                    // 売掛区分が"売掛"以外は抽出対象外
                    return null;
                }
            }
            //------------DEL BY 凌小青 on 2011/11/17 for Redmine#7765 ---------<<<<<<<<<<<<<
            //------------ADD BY 凌小青 on 2011/11/28 for Redmine#7765 ---------<<<<<<<<<<<<<
            // 2009.03.12 30413 犬飼 売掛区分の処理を追加 <<<<<<END
            
            // レコードタイプ
            if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            {
                newRow[CT_CsDmd_DataType] = true;
            }
            else
            {
                newRow[CT_CsDmd_DataType] = false;
            }

            // ADD 2009/04/20 ------>>>
            if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            {
                newRow[CT_CsDmd_RecordName] = "集計レコード";
            }
            else if ((rsltInfo_DemandTotalWork.ClaimCode == rsltInfo_DemandTotalWork.CustomerCode) && 
                     (rsltInfo_DemandTotalWork.AddUpSecCode.TrimEnd().Equals(rsltInfo_DemandTotalWork.ResultsSectCd.TrimEnd())))
            {
                newRow[CT_CsDmd_RecordName] = "親レコード";
            }
            else
            {
                newRow[CT_CsDmd_RecordName] = "子レコード";
            }
            // ADD 2009/04/20 ------<<<

            // 印刷フラグ
            newRow[CT_CsDmd_PrintFlag] = true;

            string secCode = rsltInfo_DemandTotalWork.AddUpSecCode;

            // 計上拠点コード
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
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //// 請求書パターン番号
            //newRow[CT_CsDmd_DemandPtnNo] = rsltInfo_DemandTotalWork.DemandPtnNo;

            //// 請求明細書パターン番号
            //newRow[CT_CsDmd_DmdDtlPtnNo] = rsltInfo_DemandTotalWork.DmdDtlPtnNo;
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

            string claimSecCode = rsltInfo_DemandTotalWork.ClaimSectionCode;
            // 請求拠点コード
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

            // 2009.01.21 30413 犬飼 項目追加 >>>>>>START
            // 実績拠点コード
            newRow[CT_CsDmd_ResultsSectCd] = rsltInfo_DemandTotalWork.ResultsSectCd;
            // 2009.01.21 30413 犬飼 項目追加 <<<<<<END
        
            // 請求先コード
            newRow[CT_CsDmd_ClaimCode] = rsltInfo_DemandTotalWork.ClaimCode;

            // 2008.11.19 30413 犬飼 抽出結果表示用 >>>>>>START
            // 請求先コード(抽出結果表示用)
            newRow[CT_CsDmd_ClaimCodeDisp] = rsltInfo_DemandTotalWork.ClaimCode.ToString("d08");
            // 2008.11.19 30413 犬飼 抽出結果表示用 <<<<<<END
            
            // 請求先名称
            newRow[CT_CsDmd_ClaimName] = rsltInfo_DemandTotalWork.ClaimName;

            // 請求先名称2
            newRow[CT_CsDmd_ClaimName2] = rsltInfo_DemandTotalWork.ClaimName2;

            // 請求先略称
            // 2010/07/01 >>>
            //newRow[CT_CsDmd_ClaimSnm] = rsltInfo_DemandTotalWork.ClaimSnm;
            newRow[CT_CsDmd_ClaimSnm] = nameJoin(rsltInfo_DemandTotalWork.ClaimName, rsltInfo_DemandTotalWork.ClaimName2);
            // 2010/07/01 <<<

            // 2008.11.14 30413 犬飼 集計レコードの得意先名称と略称は変更しない >>>>>>START
            // 得意先コード
            //if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            //{
            //    newRow[CT_CsDmd_CustomerCode] = rsltInfo_DemandTotalWork.ClaimCode;
            //}
            //else
            //{
            //    newRow[CT_CsDmd_CustomerCode] = rsltInfo_DemandTotalWork.CustomerCode;
            //}
            newRow[CT_CsDmd_CustomerCode] = rsltInfo_DemandTotalWork.CustomerCode;

            // 得意先名称
            newRow[CT_CsDmd_CustomerName] = rsltInfo_DemandTotalWork.CustomerName;

            // 得意先名称2
            newRow[CT_CsDmd_CustomerName2] = rsltInfo_DemandTotalWork.CustomerName2;

            // 得意先略称
            //if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            //{
            //    newRow[CT_CsDmd_CustomerSnm] = rsltInfo_DemandTotalWork.ClaimSnm;
            //}
            //else
            //{
            //    newRow[CT_CsDmd_CustomerSnm] = rsltInfo_DemandTotalWork.CustomerSnm;
            //}
            // 2010/07/01 >>>
            //newRow[CT_CsDmd_CustomerSnm] = rsltInfo_DemandTotalWork.CustomerSnm;
            newRow[CT_CsDmd_CustomerSnm] = nameJoin(rsltInfo_DemandTotalWork.CustomerName, rsltInfo_DemandTotalWork.CustomerName2);
            // 2010/07/01 <<<
            // 2008.11.14 30413 犬飼 集計レコードの得意先名称と略称は変更しない <<<<<<END

            // 2008.11.19 30413 犬飼 抽出結果表示用 >>>>>>START
            // 得意先コード(抽出結果表示用)
            newRow[CT_CsDmd_CustomerCodeDisp] = rsltInfo_DemandTotalWork.CustomerCode.ToString("d08");

            // 得意先略称(抽出結果表示用)
            if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            {
                // 2010/07/01 >>>
                //newRow[CT_CsDmd_CustomerSnmDisp] = rsltInfo_DemandTotalWork.ClaimSnm;
                newRow[CT_CsDmd_CustomerSnmDisp] = nameJoin(rsltInfo_DemandTotalWork.ClaimName, rsltInfo_DemandTotalWork.ClaimName2);
                // 2010/07/01 <<<
            }
            else
            {
                // 2010/07/01 >>>
                //newRow[CT_CsDmd_CustomerSnmDisp] = rsltInfo_DemandTotalWork.CustomerSnm;
                newRow[CT_CsDmd_CustomerSnmDisp] = nameJoin(rsltInfo_DemandTotalWork.CustomerName, rsltInfo_DemandTotalWork.CustomerName2);
                // 2010/07/01 <<<
            }
            // 2008.11.19 30413 犬飼 抽出結果表示用 <<<<<<END
            
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
            // 2009.01.28 30413 犬飼 計算式を変更 >>>>>>START
            // 2009.01.16 30413 犬飼 計算式を変更 >>>>>>START
            // 2008.09.08 30413 犬飼 計算式を変更 >>>>>>START
            //Int64 ofsThisSalesSum = rsltInfo_DemandTotalWork.OfsThisTimeSales + rsltInfo_DemandTotalWork.OfsThisSalesTax;
            // 今回繰越残高(請求計)＋相殺後今回売上金額＋今回売上返品金額＋今回売上値引金額＋相殺後今回売上消費税
            //Int64 ofsThisSalesSum = rsltInfo_DemandTotalWork.ThisTimeTtlBlcDmd + rsltInfo_DemandTotalWork.OfsThisTimeSales
            //                      + rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis
            //                      + rsltInfo_DemandTotalWork.OfsThisSalesTax;
            // 今回繰越残高(請求計)＋相殺後今回売上金額＋相殺後今回売上消費税
            //Int64 ofsThisSalesSum = rsltInfo_DemandTotalWork.ThisTimeTtlBlcDmd + rsltInfo_DemandTotalWork.OfsThisTimeSales
            //                      + rsltInfo_DemandTotalWork.OfsThisSalesTax;
            // 相殺後今回売上金額＋相殺後今回売上消費税
            Int64 ofsThisSalesSum = rsltInfo_DemandTotalWork.OfsThisTimeSales + rsltInfo_DemandTotalWork.OfsThisSalesTax;
            newRow[CT_CsDmd_OfsThisSalesSum] = ofsThisSalesSum;
            // 2008.09.08 30413 犬飼 計算式を変更 <<<<<<END
            // 2009.01.16 30413 犬飼 計算式を変更 <<<<<<END
            // 2009.01.28 30413 犬飼 計算式を変更 <<<<<<END
            
            // 今回売上金額
            newRow[CT_CsDmd_ThisTimeSales] = rsltInfo_DemandTotalWork.ThisTimeSales;

            // 今回売上返品金額
            newRow[CT_CsDmd_ThisSalesPricRgds] = rsltInfo_DemandTotalWork.ThisSalesPricRgds;

            // 今回売上値引金額
            newRow[CT_CsDmd_ThisSalesPricDis] = rsltInfo_DemandTotalWork.ThisSalesPricDis;

            // 2009.02.05 30413 犬飼 符号を逆に修正 >>>>>>START
            // 今回売上返品・値引金額
            //newRow[CT_CsDmd_ThisSalesPricRgdsDis] = (Int64)(rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis);
            long thisSalesPricRgdsDis = (Int64)(rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis);
            newRow[CT_CsDmd_ThisSalesPricRgdsDis] = -thisSalesPricRgdsDis;
            // 2009.02.05 30413 犬飼 符号を逆に修正 <<<<<<END
            
            // 残高調整額
            newRow[CT_CsDmd_BalanceAdjust] = rsltInfo_DemandTotalWork.BalanceAdjust;

            // 計算後請求金額
            newRow[CT_CsDmd_AfCalDemandPrice] = rsltInfo_DemandTotalWork.AfCalDemandPrice;

            // 2009.01.21 30413 犬飼 計算後請求金額(フィルター用)を追加 >>>>>>START
            // 計算後請求金額をキャッシュ登録
            string key = secCode.TrimEnd() + "-" + rsltInfo_DemandTotalWork.ClaimCode.ToString("d08");
            if ((bool)newRow[CT_CsDmd_DataType])
            {
                // 集計レコード
                if (!afCalDemandPriceDic.ContainsKey(key))
                {
                    afCalDemandPriceDic.Add(key, rsltInfo_DemandTotalWork.AfCalDemandPrice);
                }
            }
            // 2009.01.21 30413 犬飼 計算後請求金額(フィルター用)を追加 <<<<<<END
                            
            // 売上伝票枚数
            newRow[CT_CsDmd_SaleslSlipCount] = rsltInfo_DemandTotalWork.SalesSlipCount;

            // 請求書発行日
            newRow[CT_CsDmd_BillPrintDate] = rsltInfo_DemandTotalWork.BillPrintDate;

            // 請求書発行日(印刷用)
            newRow[CT_CsDmd_BillPrintDatePrt] = TDateTime.DateTimeToString("", rsltInfo_DemandTotalWork.BillPrintDate);

            // 入金予定日
            newRow[CT_CsDmd_ExpectedDepositDate] = rsltInfo_DemandTotalWork.ExpectedDepositDate;

            // 入金予定日(印刷用)
            newRow[CT_CsDmd_ExpectedDepositDatePrt] = TDateTime.DateTimeToString("", rsltInfo_DemandTotalWork.ExpectedDepositDate);

            // 回収条件
            switch (rsltInfo_DemandTotalWork.CollectCond)
            {
                case 10:
                    {
                        newRow[CT_CsDmd_CollectCond] = "現金";
                        break;
                    }
                case 20:
                    {
                        newRow[CT_CsDmd_CollectCond] = "振込";
                        break;
                    }
                case 30:
                    {
                        newRow[CT_CsDmd_CollectCond] = "小切手";
                        break;
                    }
                case 40:
                    {
                        newRow[CT_CsDmd_CollectCond] = "手形";
                        break;
                    }
                case 50:
                    {
                        newRow[CT_CsDmd_CollectCond] = "手数料";
                        break;
                    }
                case 60:
                    {
                        newRow[CT_CsDmd_CollectCond] = "相殺";
                        break;
                    }
                case 70:
                    {
                        newRow[CT_CsDmd_CollectCond] = "値引";
                        break;
                    }
                case 80:
                    {
                        newRow[CT_CsDmd_CollectCond] = "その他";
                        break;
                    }
                default:
                    {
                        // 2008.11.05 30413 犬飼 上記以外は"その他"とする >>>>>>START
                        //newRow[CT_CsDmd_CollectCond] = "";
                        newRow[CT_CsDmd_CollectCond] = "その他";
                        // 2008.11.05 30413 犬飼 上記以外は"その他"とする <<<<<<END
                        break;
                    }
            }

            // 消費税率 
            newRow[CT_CsDmd_ConsTaxRate] = rsltInfo_DemandTotalWork.ConsTaxRate;

            // 端数処理区分
            newRow[CT_CsDmd_FractionProcCd] = rsltInfo_DemandTotalWork.FractionProcCd;

            // 締次更新実行年月日
            newRow[CT_CsDmd_CAddUpUpdExecDate] = rsltInfo_DemandTotalWork.CAddUpUpdExecDate;

            // 締次更新実行年月日
            newRow[CT_CsDmd_CAddUpUpdExecDatePrt] = TDateTime.DateTimeToString("", rsltInfo_DemandTotalWork.CAddUpUpdExecDate);

            // 締次更新開始年月日
            newRow[CT_CsDmd_StartCAddUpUpdDate] = rsltInfo_DemandTotalWork.StartCAddUpUpdDate;

            // 締次更新開始年月日(印刷用)
            newRow[CT_CsDmd_StartCAddUpUpdDatePrt] = TDateTime.DateTimeToString("", rsltInfo_DemandTotalWork.StartCAddUpUpdDate);

            // 前回締次更新年月日
            newRow[CT_CsDmd_LastCAddUpUpdDate] = rsltInfo_DemandTotalWork.LastCAddUpUpdDate;

            // 前回締次更新年月日(印刷用)
            newRow[CT_CsDmd_LastCAddUpUpdDatePrt] = TDateTime.DateTimeToString("", rsltInfo_DemandTotalWork.LastCAddUpUpdDate);

            // 計上日付(印刷用)
            newRow[CT_CsDmd_AddUpADatePrint] = TDateTime.DateTimeToString("", rsltInfo_DemandTotalWork.AddUpDate);

            Int64 ttlConsTaxDmd = rsltInfo_DemandTotalWork.OfsThisSalesTax;
            newRow[CT_CsDmd_OfsThisSalesTax] = ttlConsTaxDmd;

            // 2009.01.19 30413 犬飼 抽出結果の親レコードと子レコードの消費税はゼロ固定に変更 >>>>>>START
            //// 今回消費税（受注消費税額＋諸費用消費税額）(印刷用)
            //// 総額表示方法
            //if (_allDefSet.TotalAmountDispWayCd == 0)
            //{
            //    // 総額表示しない税抜き 
            //    newRow[CT_CsDmd_PrintTtlConsTaxDmd] = ttlConsTaxDmd.ToString("#,##0");
            //}
            //else
            //{
            //    // 総額表示する税込み 
            //    newRow[CT_CsDmd_PrintTtlConsTaxDmd] = "(" + ttlConsTaxDmd.ToString("#,##0") + ")";
            //}
            // レコードタイプの判定
            if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            {
                // 集計レコードの場合
                if (_allDefSet.TotalAmountDispWayCd == 0)
                {
                    // 総額表示しない税抜き 
                    newRow[CT_CsDmd_PrintTtlConsTaxDmd] = ttlConsTaxDmd.ToString("#,##0");
                }
                else
                {
                    // 総額表示する税込み 
                    newRow[CT_CsDmd_PrintTtlConsTaxDmd] = "(" + ttlConsTaxDmd.ToString("#,##0") + ")";
                }
            }
            else
            {
                // 親レコードと子レコードの場合
                newRow[CT_CsDmd_PrintTtlConsTaxDmd] = "0";
            }
            // 2009.01.19 30413 犬飼 抽出結果の親レコードと子レコードの消費税はゼロ固定に変更 <<<<<<END
            
            // 印刷用請求金額
            newRow[CT_CsDmd_PrintAfCalDemandPrice] = "\\" + rsltInfo_DemandTotalWork.AfCalDemandPrice.ToString("#,##0");
                    

            if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            {
                // 前回請求額 
                newRow[CT_CsDmd_ClaimLastTimeDemand] = rsltInfo_DemandTotalWork.LastTimeDemand;
                
                // 今回入金金額（通常入金）
                newRow[CT_CsDmd_ClaimThisTimeDmdNrml] = rsltInfo_DemandTotalWork.ThisTimeDmdNrml;
                
                // 今回繰越残高（請求計）
                newRow[CT_CsDmd_ClaimThisTimeTtlBlcDmd] = rsltInfo_DemandTotalWork.ThisTimeTtlBlcDmd;

                // 今回売上金額
                newRow[CT_CsDmd_ClaimThisTimeSales] = rsltInfo_DemandTotalWork.ThisTimeSales;

                // 今回売上返品・値引金額
                newRow[CT_CsDmd_ClaimThisSalesPricRgdsDis] = (Int64)(rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis);

                // 相殺後今回売上金額
                newRow[CT_CsDmd_ClaimOfsThisTimeSales] = rsltInfo_DemandTotalWork.OfsThisTimeSales;

                // 相殺後今回売上消費税
                newRow[CT_CsDmd_ClaimOfsThisSalesTax] = rsltInfo_DemandTotalWork.OfsThisSalesTax;

                // 相殺後今回合計売上金額
                newRow[CT_CsDmd_ClaimOfsThisSalesSum] = ofsThisSalesSum;

                // 計算後請求金額
                newRow[CT_CsDmd_ClaimAfCalDemandPrice] = rsltInfo_DemandTotalWork.AfCalDemandPrice;

                // 売上伝票枚数
                newRow[CT_CsDmd_ClaimSaleslSlipCount] = rsltInfo_DemandTotalWork.SalesSlipCount;
            }

            // *********************
            // 得意先関連項目
            // *********************
            // 得意先コード
            if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            {
                // 名称
                newRow[CT_CsDmd_Name] = rsltInfo_DemandTotalWork.ClaimName;
                // 名称２
                newRow[CT_CsDmd_Name2] = rsltInfo_DemandTotalWork.ClaimName2;
            }
            else
            {
                // 名称
                newRow[CT_CsDmd_Name] = rsltInfo_DemandTotalWork.CustomerName;
                // 名称２
                newRow[CT_CsDmd_Name2] = rsltInfo_DemandTotalWork.CustomerName2;
            }

            // 得意先名称編集処理(印刷用)
            string custName1 = "";
            string custName2 = "";
            string custNameKei = "";
            string honorificTitle = "";
            string wrkCustNm1 = "";
            string wrkCustNm2 = "";

            // 得意先コード
            if (rsltInfo_DemandTotalWork.CustomerCode == 0)
            {
                wrkCustNm1 = rsltInfo_DemandTotalWork.ClaimName;
                wrkCustNm2 = rsltInfo_DemandTotalWork.ClaimName2;
            }
            else
            {
                wrkCustNm1 = rsltInfo_DemandTotalWork.CustomerName;
                wrkCustNm2 = rsltInfo_DemandTotalWork.CustomerName2;
            }

            // 名称２は設定されているか
            if (TStrUtils.TrimAll(wrkCustNm2) != "")
            {
                custName1 = wrkCustNm1;     // 名称１←得意先名称１ 
                custName2 = wrkCustNm2;     // 名称２←得意先名称２
            }
            else
            {
                custName2 = wrkCustNm1;     // 名称２←得意先名称１ 
            }

            // 敬称
            honorificTitle = rsltInfo_DemandTotalWork.HonorificTitle;
            custNameKei = TStrUtils.TrimAllEnd(custName2) + " " + honorificTitle;

            //// 印刷用得意先名称１
            //newRow[CT_CsDmd_EditCustomerName1] = custName1;

            //// 印刷用得意先名称２			
            //if (custName2.Length != 0)
            //{
            //    newRow[CT_CsDmd_EditCustomerName2] = custNameKei;
            //}
            //else
            //{
            //    newRow[CT_CsDmd_EditCustomerName2] = "";
            //}

            // カナ
            newRow[CT_CsDmd_Kana] = rsltInfo_DemandTotalWork.ClaimNameKana;

            // 郵便番号
            newRow[CT_CsDmd_PostNo] = rsltInfo_DemandTotalWork.PostNo;

            // 住所１・２・３・４
            newRow[CT_CsDmd_Address1] = rsltInfo_DemandTotalWork.Address1;
            newRow[CT_CsDmd_Address2] = rsltInfo_DemandTotalWork.Address2;
            newRow[CT_CsDmd_Address3] = rsltInfo_DemandTotalWork.Address3;
            newRow[CT_CsDmd_Address4] = rsltInfo_DemandTotalWork.Address4;

            #region ◆　合計・明細請求書用住所編集
            // 住所編集処理
            this._beforeConvertAddressParam.Address1 = rsltInfo_DemandTotalWork.Address1;
            this._beforeConvertAddressParam.Address2 = rsltInfo_DemandTotalWork.Address2;
            this._beforeConvertAddressParam.Address3 = rsltInfo_DemandTotalWork.Address3;
            this._beforeConvertAddressParam.Address4 = rsltInfo_DemandTotalWork.Address4;

            this._beforeConvertAddressParam.ByteLength1 = 50;
            this._beforeConvertAddressParam.ByteLength2 = 50;
            this._beforeConvertAddressParam.ByteLength3 = 50;

            _beforeConvertAddressParam.LineCount = 3;

            AddressConverter.ConvertAddressForSlipType(this._beforeConvertAddressParam, out this._afterConvertAddressParam);

            newRow[CT_CsDmd_EditAddress1] = this._afterConvertAddressParam.Address1;
            newRow[CT_CsDmd_EditAddress2] = this._afterConvertAddressParam.Address2;
            newRow[CT_CsDmd_EditAddress3] = this._afterConvertAddressParam.Address3;
            #endregion

            #region ◆　一覧表用住所編集
            // 住所編集処理
            this._beforeConvertAddressParam.Address1 = rsltInfo_DemandTotalWork.Address1;
            this._beforeConvertAddressParam.Address2 = rsltInfo_DemandTotalWork.Address2;
            this._beforeConvertAddressParam.Address3 = rsltInfo_DemandTotalWork.Address3;
            this._beforeConvertAddressParam.Address4 = rsltInfo_DemandTotalWork.Address4;

            this._beforeConvertAddressParam.ByteLength1 = 50;
            this._beforeConvertAddressParam.ByteLength2 = 50;
            this._beforeConvertAddressParam.ByteLength3 = 50;

            _beforeConvertAddressParam.LineCount = 3;

            AddressConverter.ConvertAddressForReportType(this._beforeConvertAddressParam, out this._afterConvertAddressParam);

            newRow[CT_CsDmd_ListAddress1] = this._afterConvertAddressParam.Address1;
            newRow[CT_CsDmd_ListAddress2] = this._afterConvertAddressParam.Address2;
            newRow[CT_CsDmd_ListAddress3] = this._afterConvertAddressParam.Address3;
            #endregion

            // 電話番号（自宅
            newRow[CT_CsDmd_HomeTelNo] = rsltInfo_DemandTotalWork.HomeTelNo;

            // 電話番号（勤務先
            newRow[CT_CsDmd_OfficeTelNo] = rsltInfo_DemandTotalWork.OfficeTelNo;

            // 電話番号（携帯
            newRow[CT_CsDmd_PortableTelNo] = rsltInfo_DemandTotalWork.PortableTelNo;

            // FAX番号（自宅）
            newRow[CT_CsDmd_HomeFaxNo] = rsltInfo_DemandTotalWork.HomeFaxNo;

            // FAX番号（勤務先）
            newRow[CT_CsDmd_OfficeFaxNo] = rsltInfo_DemandTotalWork.OfficeFaxNo;

            // 電話番号（その他）
            newRow[CT_CsDmd_OthersTelNo] = rsltInfo_DemandTotalWork.OthersTelNo;

            // 主連絡先区分[0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･]
            newRow[CT_CsDmd_MainContactCode] = rsltInfo_DemandTotalWork.MainContactCode;

            // 主連絡先区分名称
            newRow[CT_CsDmd_MainContactName] = mAlItmDspNmAcs.GetMainContactDspName(rsltInfo_DemandTotalWork.MainContactCode);

            // 主連絡先電話番号
            switch (rsltInfo_DemandTotalWork.MainContactCode)
            {
                case 0:		// 電話番号（自宅）
                    {
                        newRow[CT_CsDmd_MainContactTelNo] = rsltInfo_DemandTotalWork.HomeTelNo;
                        break;
                    }
                case 1:		// 電話番号（勤務先）
                    {
                        newRow[CT_CsDmd_MainContactTelNo] = rsltInfo_DemandTotalWork.OfficeTelNo;
                        break;
                    }
                case 2:		// 電話番号（携帯）
                    {
                        newRow[CT_CsDmd_MainContactTelNo] = rsltInfo_DemandTotalWork.PortableTelNo;
                        break;
                    }
                case 3:		// FAX番号（自宅）
                    {
                        newRow[CT_CsDmd_MainContactTelNo] = rsltInfo_DemandTotalWork.HomeFaxNo;
                        break;
                    }
                case 4:		// FAX番号（勤務先）
                    {
                        newRow[CT_CsDmd_MainContactTelNo] = rsltInfo_DemandTotalWork.OfficeFaxNo;
                        break;
                    }
                case 5:		// 電話番号（その他）
                    {
                        newRow[CT_CsDmd_MainContactTelNo] = rsltInfo_DemandTotalWork.OthersTelNo;
                        break;
                    }
                default:
                    break;
            }
            
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
                DateTime addUpDate = rsltInfo_DemandTotalWork.AddUpDate;
                DateTime addMonthDate = addUpDate.AddMonths(rsltInfo_DemandTotalWork.CollectMoneyCode);
                int calcIntDate = 0;

                // 請求書末日印字区分 = 1(28～31日は末日と印字) で28日以降の場合
                if (rsltInfo_DemandTotalWork.CollectMoneyDay >= 28 && _billPrtSt.BillLastDayPrtDiv == 1)
                {
                    calcIntDate = TDateTime.GetLastDate(TDateTime.DateTimeToLongDate(addMonthDate));
                    newRow[CT_CsDmd_CollectMoneyDayNm] = "末日";
                }
                else
                {
                    calcIntDate = (TDateTime.DateTimeToLongDate(addMonthDate)) / 100 * 100 + rsltInfo_DemandTotalWork.CollectMoneyDay;
                    newRow[CT_CsDmd_CollectMoneyDayNm] = String.Format("{0}日", rsltInfo_DemandTotalWork.CollectMoneyDay);
                }

                // 2008.09.08 30413 犬飼 未使用項目削除 >>>>>>START
                //newRow[CT_CsDmd_CollectMoneyDate] = TDateTime.DateTimeToString("", TDateTime.LongDateToDateTime(calcIntDate));  // 御振込期限(印刷用)
                //newRow[CT_CsDmd_PaymentMoneyDate] = TDateTime.DateTimeToString("", TDateTime.LongDateToDateTime(calcIntDate));  // 御支払期限(印刷用)
                // 2008.09.08 30413 犬飼 未使用項目削除 <<<<<<END
            }
            else
            {
                newRow[CT_CsDmd_CollectMoneyDayNm] = "";
                // 2008.09.08 30413 犬飼 未使用項目削除 >>>>>>START
                //newRow[CT_CsDmd_CollectMoneyDate] = "";  // 御振込期限(印刷用)
                //newRow[CT_CsDmd_PaymentMoneyDate]  = "";  // 御支払期限(印刷用)
                // 2008.09.08 30413 犬飼 未使用項目削除 <<<<<<END
            }

            // 顧客担当従業員コード
            newRow[CT_CsDmd_CustomerAgentCd] = rsltInfo_DemandTotalWork.CustomerAgentCd;

            // 顧客担当従業員名称
            newRow[CT_CsDmd_CustomerAgentNm] = rsltInfo_DemandTotalWork.CustomerAgentNm;

            // 集金担当従業員コード
            newRow[CT_CsDmd_BillCollecterCd] = rsltInfo_DemandTotalWork.BillCollecterCd;

            // 集金担当従業員名称
            newRow[CT_CsDmd_BillCollecterNm] = rsltInfo_DemandTotalWork.BillCollecterNm;

            // 敬称
            newRow[CT_CsDmd_HonorificTitle] = rsltInfo_DemandTotalWork.HonorificTitle;

            // 得意先銀行1
            newRow[CT_CsDmd_AccountNoInfoTK1] = rsltInfo_DemandTotalWork.AccountNoInfo1;
            // 得意先銀行2
            newRow[CT_CsDmd_AccountNoInfoTK2] = rsltInfo_DemandTotalWork.AccountNoInfo2;
            // 得意先銀行3
            newRow[CT_CsDmd_AccountNoInfoTK3] = rsltInfo_DemandTotalWork.AccountNoInfo3;

            // 総額表示区分
            newRow[CT_CsDmd_TotalAmountDispWayCd] = rsltInfo_DemandTotalWork.TotalAmountDispWayCd;

            // 自社名称情報読込
            CompanyNm companyNm;
            secCode = rsltInfo_DemandTotalWork.AddUpSecCode;
            // 出力拠点が「全社」の場合、自拠点情報を取得
            if (secCode == CT_AllSectionCode)
            {
                secCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }

            int status = ReadCompanyName(secCode, SecInfoAcs.CompanyNameCd.CompanyNameCd1, out companyNm);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (companyNm != null)
                {
                    // ------ DEL 2015/09/17 時シン Redmine#47028 請求一覧表Out Of Memoryの対応 ------>>>>>>
                    //// 自社画像情報取得
                    //ReadImageData(companyNm.ImageInfoCode);
                    // ------ DEL 2015/09/17 時シン Redmine#47028 請求一覧表Out Of Memoryの対応 ------<<<<<<
                    // ------ ADD 2015/09/17 時シン Redmine#47028 請求一覧表Out Of Memoryの対応 ------>>>>>>
                    // 請求一覧表以外の場合、自社画像情報を取得する
                    if (extraInfo.SlipPrtKind != 0)
                    {
                        // 自社画像情報取得
                        ReadImageData(companyNm.ImageInfoCode);
                    }
                    // ------ ADD 2015/09/17 時シン Redmine#47028 請求一覧表Out Of Memoryの対応 ------<<<<<<

                    // 自社PR文
                    newRow[CT_CsDmd_CompanyPr] = companyNm.CompanyPr;

                    // 自社名称1
                    newRow[CT_CsDmd_CompanyName1] = companyNm.CompanyName1;

                    // 自社名称2
                    newRow[CT_CsDmd_CompanyName2] = companyNm.CompanyName2;

                    // 郵便番号
                    newRow[CT_CsDmd_CompanyPostNo] = companyNm.PostNo;

                    #region ◆　住所編集
                    // 自社住所編集
                    this._beforeConvertAddressParam.Address1 = companyNm.Address1;
                    // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                    //this._beforeConvertAddressParam.Address2 = companyNm.Address2;
                    // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                    this._beforeConvertAddressParam.Address3 = companyNm.Address3;
                    this._beforeConvertAddressParam.Address4 = companyNm.Address4;

                    this._beforeConvertAddressParam.ByteLength1 = 50;
                    this._beforeConvertAddressParam.ByteLength2 = 50;
                    this._beforeConvertAddressParam.ByteLength3 = 0;

                    _beforeConvertAddressParam.LineCount = 2;

                    AddressConverter.ConvertAddressForSlipType(this._beforeConvertAddressParam, out this._afterConvertAddressParam);

                    // 自社住所１行目(印刷用)
                    newRow[CT_CsDmd_EditCompanyAddress1] = this._afterConvertAddressParam.Address1;

                    // 自社住所２行目(印刷用)
                    newRow[CT_CsDmd_EditCompanyAddress2] = this._afterConvertAddressParam.Address2;
                    #endregion

                    // 自社電話番号1(印刷用タイトル含む)
                    newRow[CT_CsDmd_EditCompanyTelNo1] = companyNm.CompanyTelTitle1 + companyNm.CompanyTelNo1;

                    // 自社電話番号2(印刷用タイトル含む)
                    newRow[CT_CsDmd_EditCompanyTelNo2] = companyNm.CompanyTelTitle2 + companyNm.CompanyTelNo2;

                    // 自社電話番号3(印刷用タイトル含む)
                    newRow[CT_CsDmd_EditCompanyTelNo3] = companyNm.CompanyTelTitle3 + companyNm.CompanyTelNo3;

                    // 銀行振込案内文
                    newRow[CT_CsDmd_TransferGuidance] = companyNm.TransferGuidance;

                    // 銀行口座1
                    newRow[CT_CsDmd_AccountNoInfo1] = companyNm.AccountNoInfo1;

                    // 銀行口座2
                    newRow[CT_CsDmd_AccountNoInfo2] = companyNm.AccountNoInfo2;

                    // 銀行口座3
                    newRow[CT_CsDmd_AccountNoInfo3] = companyNm.AccountNoInfo3;

                    // 請求設定摘要1
                    newRow[CT_CsDmd_CompanySetNote1] = companyNm.CompanySetNote1;

                    // 請求設定摘要2
                    newRow[CT_CsDmd_CompanySetNote2] = companyNm.CompanySetNote2;

                    if (_CampImage != null)//画像ならば
                    {
                        newRow[CT_CsDmd_CampImgID] = _CampImage;
                        newRow[CT_CsDmd_ImageCommentForPrt1] = companyNm.ImageCommentForPrt1;
                        newRow[CT_CsDmd_ImageCommentForPrt2] = companyNm.ImageCommentForPrt2;
                    }
                    else
                    {
                        newRow[CT_CsDmd_CampImgID] = null;
                        newRow[CT_CsDmd_ImageCommentForPrt1] = "";
                        newRow[CT_CsDmd_ImageCommentForPrt2] = "";
                    }
                }
            }
            else
            {
                // 自社PR文
                newRow[CT_CsDmd_CompanyPr] = "";
                // 自社名称1
                newRow[CT_CsDmd_CompanyName1] = "";
                // 自社名称2
                newRow[CT_CsDmd_CompanyName2] = "";
                // 郵便番号
                newRow[CT_CsDmd_CompanyPostNo] = "";
                // 自社住所１行目(印刷用)
                newRow[CT_CsDmd_EditCompanyAddress1] = "";
                // 自社住所２行目(印刷用)
                newRow[CT_CsDmd_EditCompanyAddress2] = "";
                // 自社電話番号1(印刷用タイトル含む)
                newRow[CT_CsDmd_EditCompanyTelNo1] = "";
                // 自社電話番号2(印刷用タイトル含む)
                newRow[CT_CsDmd_EditCompanyTelNo2] = "";
                // 自社電話番号3(印刷用タイトル含む)
                newRow[CT_CsDmd_EditCompanyTelNo3] = "";
                // 銀行振込案内文
                newRow[CT_CsDmd_TransferGuidance] = "";
                // 銀行口座1
                newRow[CT_CsDmd_AccountNoInfo1] = "";
                // 銀行口座2
                newRow[CT_CsDmd_AccountNoInfo2] = "";
                // 銀行口座3
                newRow[CT_CsDmd_AccountNoInfo3] = "";
                // 請求設定摘要1
                newRow[CT_CsDmd_CompanySetNote1] = "";
                // 請求設定摘要2
                newRow[CT_CsDmd_CompanySetNote2] = "";
                // 自社名プロテクト1
                newRow[CT_CsDmd_CompanyProt1] = "";
                // 自社設定摘要2
                newRow[CT_CsDmd_CompanyProt2] = "";

                newRow[CT_CsDmd_CampImgID] = null;
                newRow[CT_CsDmd_ImageCommentForPrt1] = "";
                newRow[CT_CsDmd_ImageCommentForPrt2] = "";
            }

            // 相殺後今回合計売上金額の符号向きにて判定
            if (ofsThisSalesSum >= 0)
            {
                // 請求書・支払書区分
                newRow[CT_CsDmd_DemandOrPay] = 0;  // 請求書

                // 銀行1
                newRow[CT_CsDmd_AccountNoInfoDsp1] = companyNm.AccountNoInfo1;
                // 銀行2
                newRow[CT_CsDmd_AccountNoInfoDsp2] = companyNm.AccountNoInfo2;
                // 銀行3
                newRow[CT_CsDmd_AccountNoInfoDsp3] = companyNm.AccountNoInfo3;
            }
            else
            {
                // 請求書・支払書区分
                newRow[CT_CsDmd_DemandOrPay] = 1;  // 支払書

                // 銀行1
                newRow[CT_CsDmd_AccountNoInfoDsp1] = rsltInfo_DemandTotalWork.AccountNoInfo1;
                // 銀行2
                newRow[CT_CsDmd_AccountNoInfoDsp2] = rsltInfo_DemandTotalWork.AccountNoInfo2;
                // 銀行3
                newRow[CT_CsDmd_AccountNoInfoDsp3] = rsltInfo_DemandTotalWork.AccountNoInfo3;
            }
            
            // 2008.09.08 30413 犬飼 項目追加 >>>>>>START
            // 請求残高
            newRow[CT_CsDmd_DemandBalance] = rsltInfo_DemandTotalWork.LastTimeDemand + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd;

            // 2009.01.16 30413 犬飼 純売上は相殺後今回売上金額に変更 >>>>>>START
            // 純売上額
            //newRow[CT_CsDmd_NetSales] = rsltInfo_DemandTotalWork.OfsThisTimeSales + rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis;
            newRow[CT_CsDmd_NetSales] = rsltInfo_DemandTotalWork.OfsThisTimeSales;
            // 2009.01.16 30413 犬飼 純売上は相殺後今回売上金額に変更 <<<<<<END
            
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
                    // 2009.02.02 30413 犬飼 得意先の締日と集金日で回収月計算を変更 >>>>>>START
                    // 当月
                    //collectDemand = rsltInfo_DemandTotalWork.AcpOdrTtl3TmBfBlDmd + rsltInfo_DemandTotalWork.AcpOdrTtl2TmBfBlDmd
                    //              + rsltInfo_DemandTotalWork.LastTimeDemand + rsltInfo_DemandTotalWork.OfsThisTimeSales
                    //              + rsltInfo_DemandTotalWork.ThisSalesPricRgds + rsltInfo_DemandTotalWork.ThisSalesPricDis
                    //              + rsltInfo_DemandTotalWork.OfsThisSalesTax;
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
                    // 2009.02.02 30413 犬飼 得意先の締日と集金日で回収月計算を変更 <<<<<<END
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

            // 2008.11.11 30413 犬飼 金種の初期値を設定 >>>>>>START
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
            // 2008.11.11 30413 犬飼 金種の初期値を設定 <<<<<<END
            
            foreach (RsltInfo_DepsitTotalWork work in rsltInfo_DemandTotalWork.MoneyKindList)
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
            // 2008.09.08 30413 犬飼 項目追加 <<<<<<END

            // --- DEL  大矢睦美  2010/01/25 ---------->>>>>
            // 2009.01.23 30413 犬飼 請求書出力区分を追加 >>>>>>START
            // 請求書出力区分コード
            //newRow[CT_Blnce_BillOutputCode] = rsltInfo_DemandTotalWork.BillOutputCode;
            // 2009.01.23 30413 犬飼 請求書出力区分を追加 <<<<<<END
            // --- DEL  大矢睦美  2010/01/25 ----------<<<<<
        
            // 領収書出力区分コード
            newRow[CT_Blnce_ReceiptOutputCode] = rsltInfo_DemandTotalWork.ReceiptOutputCode;    // ADD 2009/04/07

            // --- ADD  大矢睦美  2010/01/25 ---------->>>>>
            //合計請求書出力区分コード
            newRow[CT_Blnce_TotalBillOutputDiv] = rsltInfo_DemandTotalWork.TotalBillOutputDiv;
            //明細請求書出力区分コード
            newRow[CT_Blnce_DetailBillOutputCode] = rsltInfo_DemandTotalWork.DetailBillOutputCode;
            //伝票合計請求書出力区分コード
            newRow[CT_Blnce_SlipTtlBillOutputDiv] = rsltInfo_DemandTotalWork.SlipTtlBillOutputDiv;
            // --- ADD  大矢睦美  2010/01/25 ----------<<<<<

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
                //--- ADD 2022/08/24 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
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
                //--- ADD 2022/08/24 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<
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
                //--- ADD 2022/08/24 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） --->>>>>
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
                //--- ADD 2022/08/24 陳艶丹 11800255-00　インボイス対応（税率別合計金額不具合修正） ---<<<<<

                // 税率1タイトル
                newRow[Col_TitleTaxRate1] = string.Empty;
                // 税率2タイトル
                newRow[Col_TitleTaxRate2] = string.Empty;
            }
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<

            newRow.EndEdit();

            return newRow;
        }

        #region 画像読込処理
        /// <summary>
        /// 画像読込処理
        /// </summary>
        /// <param name="takeInImageGroupCd">取込画像グループコード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 画像管理マスタから画像の読み込みを行います</br>
        /// <br>Programmer : 22024 寺坂　誉志</br>
        /// <br>Date       : 2005.10.04</br>
        /// </remarks>
        private int ReadImageData(int imageInfoCode)
        {
            int status = -1;
            //int status = 0;

            if (imageInfoCode != 0)
            {
                try
                {
                    // 画像グループマスタ＆画像管理マスタ検索処理
                    ImageInfo imageInfo;

                    status = this._imageInfoAcs.Read(out imageInfo, LoginInfoAcquisition.EnterpriseCode, ctIMAGEINFODIV_CODE, imageInfoCode);
                    if (status == 0)
                    {
                        if (imageInfo != null)
                        {
                            ImageConverter imgconv = new ImageConverter();
                            this._CampImage = (Image)imgconv.ConvertFrom(imageInfo.ImageInfoData);
                        }
                    }
                    else
                    {
                        _CampImage = null;
                    }
                }
                catch
                {
                    _CampImage = null;
                }
            }

            return status;
        }
        #endregion
        
        /// <summary>
        /// クラスメンバーコピー処理（請求一覧抽出条件クラス⇒請求一覧抽出条件ワーククラス）
        /// </summary>
        /// <param name="lgoodsganre">請求一覧抽出条件クラス</param>
        /// <returns>請求一覧抽出条件ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 請求一覧抽出条件クラスから請求一覧抽出条件ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 980023 飯谷  耕平</br>
        /// <br>Date       : 2006.12.04</br>
        /// <br>UpdateNote : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private ExtrInfo_DemandTotalWork CopyToExtraInfoWorkFromExtraInfo(ExtrInfo_DemandTotal extraInfo)
        {
            ExtrInfo_DemandTotalWork extraInfoWork = new ExtrInfo_DemandTotalWork();

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
                    extraInfoWork.ResultsAddUpSecList = extraInfo.ResultsAddUpSecList;// 拠点コード
                }
            }
            else
            {
                extraInfoWork.ResultsAddUpSecList = new string[0];    // 拠点コード
            }

            // 2008.09.08 30413 犬飼 締日を項目 >>>>>>START
            //extraInfoWork.AddUpDate = TDateTime.LongDateToDateTime(extraInfo.TargetAddUpDate);  // 締日
            extraInfoWork.AddUpDate = extraInfo.AddUpDate;  // 締日
            // 2008.09.08 30413 犬飼 締日を項目 <<<<<<END
            
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

            // 2008.09.10 30413 犬飼 販売エリアコード追加 >>>>>>START
            extraInfoWork.SalesAreaCodeSt = extraInfo.SalesAreaCodeSt;              // 販売エリアコード(開始)
            extraInfoWork.SalesAreaCodeEd = extraInfo.SalesAreaCodeEd;              // 販売エリアコード(終了)
            // 2008.09.10 30413 犬飼 販売エリアコード追加 <<<<<<END
            
            extraInfoWork.CustomerCodeSt = extraInfo.CustomerCodeSt;            // 得意先コード(開始)
            extraInfoWork.CustomerCodeEd = extraInfo.CustomerCodeEd;            // 得意先コード(終了)
            extraInfoWork.EnterpriseCode = extraInfo.EnterpriseCode;            // 企業コード
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //extraInfoWork.IsBillOutputOnly = extraInfo.IsJudgeBillOutputCode;   // 「請求書発行する」請求先のみ出力区分
            //extraInfoWork.IsLastDay = extraInfo.IsLastDay;                      // 得意先締末尾指定(true:28～31全て false:指定締日のみ)
            //extraInfoWork.IsOutputAllSecRec = extraInfo.IsOutputAllSecRec;      // 「全社」選択区分
            //extraInfoWork.IsSelectAllSection = extraInfo.IsSelectAllSection;    // 全ての拠点が選択されたかどうか
            //extraInfoWork.KanaSt = extraInfo.KanaSt;                            // 得意先カナ(開始)
            //extraInfoWork.KanaEd = extraInfo.KanaEd;                            // 得意先カナ(終了)
            //extraInfoWork.ResultsAddUpSecList = (string[])extraInfo.ResultsAddUpSecList.ToArray(typeof(string));  // 選択拠点コードリスト
            //extraInfoWork.TotalDay = extraInfo.TotalDay;                        // 得意先締日
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            extraInfoWork.DmdItems = extraInfo.DmdDtl;                          // 請求内訳
            
            // 2008.10.17 30413 犬飼 伝票印刷種別の追加 >>>>>>START
            extraInfoWork.SlipPrtKind = extraInfo.SlipPrtKind;                  // 伝票印刷種別
            // 2008.10.17 30413 犬飼 伝票印刷種別の追加 <<<<<<END

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

        #region 売上情報から売上明細情報データ行設定処理
        /// <summary>
        /// 売上情報から売上明細情報データ行設定処理
        /// </summary>
        /// <param name="dmd">請求売上データクラス</param>
        /// <param name="dt">設定するDataTable情報</param>
        /// <returns>設定されたデータ行</returns>
        /// <remarks>
        /// <br>Note        : 売上情報から売上明細情報のデータ行へ設定します。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        private void SalesToSaleDtlDataRow(RsltInfo_DemandDetailWork dmd, ref DataTable dt, DmdDtlPrtPtn dmdDtlPrtPtn)
        {
            DataRow row = dt.NewRow();

            // 得意先コード
            row[CT_SaleDepo_CustomerCode] = dmd.CustomerCode;
            // 得意先名称
            row[CT_SaleDepo_CustomerName] = dmd.CustomerName;
            // 得意先名称2
            row[CT_SaleDepo_CustomerName2] = dmd.CustomerName2;
            // 得意先略称
            row[CT_SaleDepo_CustomerSnm] = dmd.CustomerSnm;
            // 請求先コード
            row[CT_SaleDepo_ClaimCode] = dmd.ClaimCode;
            // 請求先名称
            row[CT_SaleDepo_ClaimName] = dmd.ClaimName;
            // 請求先名称2
            row[CT_SaleDepo_ClaimName2] = dmd.ClaimName2;
            // 請求先略称
            row[CT_SaleDepo_ClaimSnm] = dmd.ClaimSnm;
            // 計上日付
            row[CT_SaleDepo_AddUpADate] = dmd.AddUpADate;
            // 計上日付(表示用)
            row[CT_SaleDepo_AddUpADateDisp] = TDateTime.DateTimeToString("YYYY/MM/DD", dmd.AddUpADate);
            // 計上日付(印刷用)
            row[CT_SaleDepo_AddUpADatePrint] = TDateTime.DateTimeToString("", dmd.AddUpADate);
            // 伝票番号・入金番号
            row[CT_SaleDepo_SalesSlipNum] = dmd.SalesSlipNum;

            // 売上伝票区分
            if (dmd.SalesSlipCd == 0)
            {
                row[CT_SaleDepo_SalesSlipCd] = "売上";
            }
            else
            {
                row[CT_SaleDepo_SalesSlipCd] = "返品";
            }

            // 売掛区分
            if (dmd.AccRecDivCd == 0)
            {
                row[CT_SaleDepo_AccRecDivCd] = "現金";
            }
            else
            {
                row[CT_SaleDepo_AccRecDivCd] = "売掛";
            }

            // 相手先伝票番号
            row[CT_SaleDepo_PartySaleSlipNum] = dmd.PartySaleSlipNum;
            // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
            //// 赤黒連結受注番号
            //row[CT_SaleDepo_DebitNLnkAcptAnOdr] = dmd.DebitNLnkAcptAnOdr;
            // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
            // 売上伝票合計（税込み）
            if ((dmd.SalesGoodsCd != 2) && (dmd.SalesGoodsCd != 3))
            {
                row[CT_SaleDepo_SalesTotalTaxInc] = dmd.SalesTotalTaxInc;
            }
            else if (dmd.SalesGoodsCd == 2)
            {
                row[CT_SaleDepo_SalesTotalTaxInc] = dmd.SalesSubtotalTax;  // 消費税
            }
            else if (dmd.SalesGoodsCd == 3)
            {
                row[CT_SaleDepo_SalesTotalTaxInc] = dmd.SalesTotalTaxInc;
            }

            // 売上伝票合計（税抜き）
            if (dmd.SalesGoodsCd == 3)  // 残高調整の場合
            {
                row[CT_SaleDepo_SalesTotalTaxExc] = dmd.SalesTotalTaxInc;
            }
            else
            {
                row[CT_SaleDepo_SalesTotalTaxExc] = dmd.SalesTotalTaxExc;
            }
            // 売上伝票消費税額
            if (dmd.SalesGoodsCd == 2) // 消費税調整の場合
            {
                row[CT_SaleDepo_SalesTotalTax] = dmd.SalesSubtotalTax;
            }
            else if (dmd.SalesGoodsCd == 3) // 残高調整の場合
            {
                row[CT_SaleDepo_SalesTotalTax] = 0;
            }
            else
            {
                row[CT_SaleDepo_SalesTotalTax] = dmd.SalesTotalTax;
            }
            // 伝票備考
            row[CT_SaleDepo_SlipNote] = dmd.SlipNote;
            // 伝票備考２
            row[CT_SaleDepo_SlipNote2] = dmd.SlipNote2;
            // 売上行番号
            row[CT_SaleDepo_SalesRowNo] = dmd.SalesRowNo;
            // 売上伝票区分（明細）
            switch (dmd.SalesSlipCdDtl)
            {
                case 0:
                    {
                        row[CT_SaleDepo_SalesSlipCdDtl] = "売上";
                        break;
                    }
                case 1:
                    {
                        row[CT_SaleDepo_SalesSlipCdDtl] = "返品";
                        break;
                    }
                case 2:
                    {
                        row[CT_SaleDepo_SalesSlipCdDtl] = "値引";
                        break;
                    }
                case 9:
                    {
                        row[CT_SaleDepo_SalesSlipCdDtl] = "一式";
                        break;
                    }
                default:
                    {
                        row[CT_SaleDepo_SalesSlipCdDtl] = "";
                        break;
                    }
            }
            // 受注番号
            row[CT_SaleDepo_AcceptAnOrderNo] = dmd.AcceptAnOrderNo;
            // メーカーコード
            row[CT_SaleDepo_GoodsMakerCd] = dmd.GoodsMakerCd;
            // メーカー名称
            row[CT_SaleDepo_MakerName] = dmd.MakerName;
            // 商品番号
            row[CT_SaleDepo_GoodsNo] = dmd.GoodsNo;
            // 商品名
            row[CT_SaleDepo_GoodsName] = dmd.GoodsName;
            // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
            //// 商品区分コード
            //row[CT_SaleDepo_MediumGoodsGanreCode] = dmd.MediumGoodsGanreCode;
            //// 商品区分名
            //row[CT_SaleDepo_MediumGoodsGanreName] = dmd.MediumGoodsGanreName;
            //// 商品区分グループコード
            //row[CT_SaleDepo_LargeGoodsGanreCode] = dmd.LargeGoodsGanreCode;
            //// 商品区分グループ名
            //row[CT_SaleDepo_LargeGoodsGanreName] = dmd.LargeGoodsGanreName;
            //// 商品区分詳細コード
            //row[CT_SaleDepo_DetailGoodsGanreCode] = dmd.DetailGoodsGanreCode;
            //// 商品区分詳細名称
            //row[CT_SaleDepo_DetailGoodsGanreName] = dmd.DetailGoodsGanreName;
            // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
            // BL商品コード
            row[CT_SaleDepo_BLGoodsCode] = dmd.BLGoodsCode;
            // BL商品コード名称
            row[CT_SaleDepo_BLGoodsFullName] = dmd.BLGoodsFullName;
            // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
            //// 自社分類コード
            //row[CT_SaleDepo_EnterpriseGanreCode] = dmd.EnterpriseGanreCode;
            //// 自社分類名称
            //row[CT_SaleDepo_EnterpriseGanreName] = dmd.EnterpriseGanreName;
            //// 単位コード
            //row[CT_SaleDepo_UnitCode] = dmd.UnitCode;
            //// 単位名称
            //row[CT_SaleDepo_UnitName] = dmd.UnitName;
            // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<ENd
            // 売上単価（税込，浮動）
            row[CT_SaleDepo_SalesUnPrcTaxIncFl] = dmd.SalesUnPrcTaxIncFl;
            // 売上単価（税抜，浮動）
            if ((dmd.SalesGoodsCd != 2) && (dmd.SalesGoodsCd != 3))
            {
                row[CT_SaleDepo_SalesUnPrcTaxExcFl] = dmd.SalesUnPrcTaxExcFl;
            }
            else
            {
                row[CT_SaleDepo_SalesUnPrcTaxExcFl] = 0;
            }
            // 出荷数
            if ((dmd.SalesGoodsCd != 2) && (dmd.SalesGoodsCd != 3))
            {
                row[CT_SaleDepo_ShipmentCnt] = dmd.ShipmentCnt;
            }
            else
            {
                row[CT_SaleDepo_ShipmentCnt] = 0;
            }
            // 売上金額（税込み）
            row[CT_SaleDepo_SalesMoneyTaxInc] = dmd.SalesMoneyTaxInc;
            // 売上金額（税抜き）
            if (dmd.SalesGoodsCd == 2)
            {
                row[CT_SaleDepo_SalesMoneyTaxExc] = dmd.SalesSubtotalTax;
                row[CT_SaleDepo_SalesMoneyTaxExc1] = dmd.SalesSubtotalTax;
            }
            else if (dmd.SalesGoodsCd == 3)
            {
                row[CT_SaleDepo_SalesMoneyTaxExc] = dmd.SalesTotalTaxInc;
                row[CT_SaleDepo_SalesMoneyTaxExc1] = dmd.SalesTotalTaxInc;
            }
            else
            {
                row[CT_SaleDepo_SalesMoneyTaxExc] = dmd.SalesMoneyTaxExc;
                row[CT_SaleDepo_SalesMoneyTaxExc1] = 0;
            }
            // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
            //// 消費税調整額
            //row[CT_SaleDepo_TaxAdjust] = dmd.TaxAdjust;
            //// 残高調整額
            //row[CT_SaleDepo_BalanceAdjust] = dmd.BalanceAdjust;
            // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
            // 課税区分
            row[CT_SaleDepo_TaxationDivCd] = dmd.TaxationDivCd;
            // 相手先伝票番号（明細）
            row[CT_SaleDepo_PartySlipNumDtl] = dmd.PartySlipNumDtl;
            // 明細備考
            row[CT_SaleDepo_DtlNote] = dmd.DtlNote;
            // 伝票メモ１
            row[CT_SaleDepo_SlipMemo1] = dmd.SlipMemo1;
            // 伝票メモ２
            row[CT_SaleDepo_SlipMemo2] = dmd.SlipMemo2;
            // 伝票メモ３
            row[CT_SaleDepo_SlipMemo3] = dmd.SlipMemo3;
            // 2008.09.16 30413 犬飼 未使用項目削除 >>>>>>START
            ///// 伝票メモ４
            //row[CT_SaleDepo_SlipMemo4] = dmd.SlipMemo4;
            //// 伝票メモ５
            //row[CT_SaleDepo_SlipMemo5] = dmd.SlipMemo5;
            //// 伝票メモ６
            //row[CT_SaleDepo_SlipMemo6] = dmd.SlipMemo6;
            //// 印刷用商品番号
            //row[CT_SaleDepo_PrtGoodsNo] = dmd.PrtGoodsNo;
            //// 印刷用商品名称
            //row[CT_SaleDepo_PrtGoodsName] = dmd.PrtGoodsName;
            //// 印刷用商品メーカーコード
            //row[CT_SaleDepo_PrtGoodsMakerCd] = dmd.PrtGoodsMakerCd;
            //// 印刷用商品メーカー名称
            //row[CT_SaleDepo_PrtGoodsMakerNm] = dmd.PrtGoodsMakerNm;
            // 2008.09.16 30413 犬飼 未使用項目削除 <<<<<<END
            /// 計上拠点コード
            row[CT_SaleDepo_AddUpSecCode] = dmd.AddUpSecCode;
            // 計上拠点名称
            string sectionName = "";
            if (sectionTable.ContainsKey(dmd.AddUpSecCode))
            {
                sectionName = sectionTable[dmd.AddUpSecCode].ToString();
            }
            row[CT_SaleDepo_AddUpSecName] = sectionName;
            // 印刷順位
            row[CT_SaleDepo_PrintDetailHeaderOder] = 1;

            if (this.CheckZeroValueDtl(dmd, dmdDtlPrtPtn) == false)
            {
                dt.Rows.Add(row);
            }
        }
        #endregion
        
        #region 売上情報から売上明細情報データ行設定処理
        /// <summary>
        /// 売上情報から売上明細情報データ行設定処理
        /// </summary>
        /// <param name="dmd">請求売上データクラス</param>
        /// <param name="dt">設定するDataTable情報</param>
        /// <returns>設定されたデータ行</returns>
        /// <remarks>
        /// <br>Note        : 売上情報から売上明細情報のデータ行へ設定します。</br>
        /// <br>Programer  : 980023  飯谷 耕平</br>
        /// <br>Date       : 2007.07.09</br>
        /// </remarks>
        private void SalesToDepoDtlDataRow(RsltInfo_DemandDetailWork dmd, ref DataTable dt, DmdDtlPrtPtn dmdDtlPrtPtn)
        {


            DataRow row = dt.NewRow();

            // 請求先コード
            row[CT_SaleDepo_ClaimCode] = dmd.ClaimCode;
            // 請求先名称
            row[CT_SaleDepo_ClaimName] = dmd.ClaimName;
            // 請求先名称2
            row[CT_SaleDepo_ClaimName2] = dmd.ClaimName2;
            // 請求先略称
            row[CT_SaleDepo_ClaimSnm] = dmd.ClaimSnm;
            // 得意先コード
            row[CT_SaleDepo_CustomerCode] = dmd.CustomerCode;
            // 得意先名称
            row[CT_SaleDepo_CustomerName] = dmd.CustomerName;
            // 得意先名称2
            row[CT_SaleDepo_CustomerName2] = dmd.CustomerName2;
            // 得意先略称
            row[CT_SaleDepo_CustomerSnm] = dmd.CustomerSnm;
            // 計上日付
            row[CT_SaleDepo_AddUpADate] = dmd.AddUpADate;
            // 計上日付(表示用)
            row[CT_SaleDepo_AddUpADateDisp] = TDateTime.DateTimeToString("YYYY/MM/DD", dmd.AddUpADate);
            // 計上日付(印刷用)
            row[CT_SaleDepo_AddUpADatePrint] = TDateTime.DateTimeToString("YYYY/MM/DD", dmd.AddUpADate);
            // 赤黒入金連結番号                     
            row[CT_SaleDepo_DebitNoteLinkDepoNo] = dmd.DebitNoteLinkDepoNo;
            // 入金伝票番号                      
            row[CT_SaleDepo_DepositSlipNo] = dmd.DepositSlipNo;
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            ///// 入金金種コード
            //row[CT_SaleDepo_DepositKindCode] = dmd.DepositKindCode;
            //// 入金金種名称
            //row[CT_SaleDepo_DepositKindName] = dmd.DepositKindName;
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            /// 入金計
            row[CT_SaleDepo_DepositTotal] = dmd.DepositTotal;
            // 伝票摘要
            row[CT_SaleDepo_Outline] = dmd.Outline;
            // 手形種類
            row[CT_SaleDepo_DraftKind] = dmd.DraftKind;
            // 手形種類名称
            row[CT_SaleDepo_DraftKindName] = dmd.DraftKindName;
            // 手形区分
            row[CT_SaleDepo_DraftDivide] = dmd.DraftDivide;
            // 手形区分名称
            row[CT_SaleDepo_DraftDivideName] = dmd.DraftDivideName;
            // 手形番号
            row[CT_SaleDepo_DraftNo] = dmd.DraftNo;
            // 計上拠点コード
            row[CT_SaleDepo_AddUpSecCode] = dmd.AddUpSecCode;
            // 計上拠点名称
            string sectionName = "";
            if (sectionTable.ContainsKey(dmd.AddUpSecCode))
            {
                sectionName = sectionTable[dmd.AddUpSecCode].ToString();
            }
            row[CT_SaleDepo_AddUpSecName] = sectionName;

            if (this.CheckZeroValueDtl(dmd, dmdDtlPrtPtn) == false)
            {
                dt.Rows.Add(row);
            }
        }
        #endregion
        
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

        // 2008.09.05 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region 今回請求金額ゼロチェック
        ///// <summary>
        ///// 今回請求金額ゼロチェック
        ///// </summary>
        //private bool CheckTotalZeroValue(RsltInfo_DemandTotalWork dmd, DmdPrtPtn dmdPrtPtn)
        //{
        //    /// 今回請求金額ゼロの請求書は印字しない場合
        //    if (dmdPrtPtn.ThTmDmdZeroPrtDiv == 1)
        //    {
        //        if ((dmd.OfsThisTimeSales == 0) && // 相殺後今回売上金額
        //            (dmd.OfsThisSalesTax == 0))    // 相殺後今回売上消費税
        //        {
        //            return true;
        //        }
        //    }
            
        //    return false;   
        //}
        #endregion
        // 2008.09.05 30413 犬飼 未使用メソッドの削除 <<<<<<END

        #region 明細書明細金額ゼロチェック
        /// <summary>
        /// 明細書明細金額ゼロチェック
        /// </summary>
        private bool CheckZeroValueDtl(RsltInfo_DemandDetailWork dmd, DmdDtlPrtPtn dmdDtlPrtPtn)
        {
            // 金額ゼロ円明細判定
            if (dmdDtlPrtPtn.DtlPrcZeroPrtDiv == 1)
            {
                if ((dmd.ShipmentCnt == 0) &&       // 出荷数
                    (dmd.SalesMoneyTaxInc == 0) &&  // 売上金額（税込み）
                    (dmd.SalesMoneyTaxExc == 0) &&  // 売上金額（税抜き）
                    (dmd.DepositTotal == 0))        // 入金合計
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        
        // 2008.09.05 30413 犬飼 未使用メソッドの削除 >>>>>>START
        #region 請求書パターン設定の取得
        ///// <summary>
        ///// 請求書パターン設定の取得
        ///// </summary>
        ///// <param name="dmdPrtPtn"></param>
        ///// <param name="ttlSetItemDivList"></param>
        ///// <param name="ttlFormTitleList"></param>
        ///// <returns></returns>
        //private int GetDmdPrtPtn(int demandPtnNo, out DmdPrtPtn dmdPrtPtn)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    dmdPrtPtn = new DmdPrtPtn();

        //    // 請求書印刷パターン設定読込
        //    status = _dmdPrtPtnAcs.ReadStaticMemory(out dmdPrtPtn, LoginInfoAcquisition.EnterpriseCode, demandPtnNo);
            
        //    return status;
        //}
        #endregion
        // 2008.09.05 30413 犬飼 未使用メソッドの削除 <<<<<<END

        /// <summary>
        /// フィルター用の計算後請求金額を設定
        /// </summary>
        private void SetAfCalDemandPriceFilter()
        {
            for (int i = 0; i < this._custDmdPrcDataTable.Rows.Count; i++)
            {
                // 計上拠点コードと請求先コードでキー作成
                string sectionCd = (string)this._custDmdPrcDataTable.Rows[i][CT_CsDmd_AddUpSecCode];
                string claimCode = (string)this._custDmdPrcDataTable.Rows[i][CT_CsDmd_ClaimCodeDisp];
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
        /// メッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">ステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">デフォルトフォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : 出力件数の設定を行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.07.10</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "請求書データ抽出処理", iMsg, iSt, iButton, iDefButton);
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
            MAKAU02012UA uiObj = new MAKAU02012UA();
            doneFlag = ContainMember(uiObj, "TaxReductionUIDone");
            if (!doneFlag) return doneFlag;

            // Eクラス
            ExtrInfo_DemandTotal demandTotal = new ExtrInfo_DemandTotal();
            doneFlag = ContainProperty(demandTotal, "TaxPrintDiv");
            if (!doneFlag) return doneFlag;

            // Dクラス
            ExtrInfo_DemandTotalWork demandTotalWork = new ExtrInfo_DemandTotalWork();
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

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由帳票(請求書)印刷データ制御クラス
// プログラム概要   : 自由帳票(請求書)印刷データ制御クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00   作成担当 : 陳艶丹
// 作 成 日  2022/03/07    修正内容 : 請求書発行(電子帳簿連携)新規作成
//----------------------------------------------------------------------------//
// 管理番号  11870080-00   作成担当 : 陳艶丹
// 作 成 日  2022/04/21    修正内容 : 電子帳簿2次対応
//----------------------------------------------------------------------------//
// 管理番号  11870141-00   作成担当 : 田村顕成
// 作 成 日  2022/10/18    修正内容 : インボイス残対応（軽減税率対応）
//----------------------------------------------------------------------------//
// 管理番号  11970040-00   作成担当 : 3H 仰亮亮
// 作 成 日  2023/04/14    修正内容 : 自由帳票項目追加対応
//                                    ①売上伝票計金額(税込み)
//                                    ②消費税(伝票転嫁)/売上伝票計金額(税込み)
//----------------------------------------------------------------------------//
// 管理番号  11900025-00   作成担当 : 田村顕成
// 作 成 日  2023/06/16    修正内容 : 軽減税率不具合対応
//                                    「キャストが有効ではありません」例外発生の修正
//----------------------------------------------------------------------------//
// 管理番号  11900025-00   作成担当 : 3H 仰亮亮
// 作 成 日  2023/06/23    修正内容 : 消費税転嫁「請求子」の税率別税額不具合対応
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
//using System.Windows.Forms;
//using System.Drawing.Printing;
using System.Collections.Generic;
using System.Diagnostics;
//using ar=DataDynamics.ActiveReports;
//using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
//using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 自由帳票(請求書)印刷データ制御クラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 印刷処理に渡すテーブルの生成を行います。（１請求書単位の印刷制御処理）</br>
    /// <br>               staticフィールド／メソッドをこのクラスに実装します。</br>
    /// <br>               【印刷(P)からcallします】</br>
    /// <br>               </br>
    /// <br>Programmer   : 陳艶丹</br>
    /// <br>Date         : 2022/03/07</br>
    /// <br>Update Note  : 2022/04/21 陳艶丹</br>
    /// <br>管理番号     : 11870080-00 電子帳簿2次対応</br>  
    /// <br>Update Note  : 2022/10/18 田村顕成</br>
    /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br> 
    /// <br>Update Note  : 2023/04/14 3H 仰亮亮</br>
    /// <br>管理番号     : 11970040-00 自由帳票項目追加対応</br>
    /// <br>               ①売上伝票計金額(税込み)</br>
    /// <br>               ②消費税(伝票転嫁)/売上伝票計金額(税込み)</br>
    /// <br>Update Note  : 2023/06/23 3H 仰亮亮</br>
    /// <br>管理番号     : 11900025-00 消費税転嫁「請求子」の税率別税額不具合対応</br>
    /// </remarks>
    public class PMKAU01002AC
    {
        # region [private const]
        // 末日文字列
        private const string ct_LastDayString = "末";

        private static int _slipNote2PrtCnt = 0;

        private static bool _modelHalfNameDtl3PrtFlg = false;
        private static string _modelHalfNameDtl1 = "";
        private static bool _carMngNo2PrtFlg = false;
        private static string _carMngNo2Dtl1 = "";

        private static int _pageCount = 0;
        # endregion

        # region [public static readonly]
        /// <summary>請求書印刷データテーブル</summary>
        public static readonly string CT_Tbl_PrintData = "PrintData";
        /// <summary>同一ページ内複写カウント　カラム</summary>
        public static readonly string ct_col_InpageCount = "PMKAU01002AC.InpageCount";
        /// <summary>ページ数</summary>
        public static readonly string ct_col_PageCount = "PAGE.PAGECOUNTRF";
        /// <summary>消費税タイトル</summary>
        public static readonly string ct_col_TaxTitle = "PMKAU01002AC.TAXTITLE";
        /// <summary>相殺後売上合計金額(税込)タイトル </summary>
        public static readonly string ct_col_OfsThisSalesTaxIncTtl = "PMKAU08002C.OFSTHISSALESTAXINCTTL";

        /// <summary>計上年月日(末日)</summary>
        public static readonly string ct_col_Last_AddUpDate = "LAST.ADDUPDATERF";
        /// <summary>締次更新開始年月日(末日)</summary>
        public static readonly string ct_col_Last_StartCAddUpUpdDate = "LAST.STARTCADDUPUPDDATERF";
        /// <summary>請求書発行日(末日)</summary>
        public static readonly string ct_col_Last_BillPrintDate = "LAST.BILLPRINTDATERF";
        /// <summary>入金予定日(末日)</summary>
        public static readonly string ct_col_Last_ExpectedDepositDate = "LAST.EXPECTEDDEPOSITDATERF";
        /// <summary>入力発行日付(末日)</summary>
        public static readonly string ct_col_Last_IssueDay = "LAST.ISSUEDAYRF";
        /// <summary>集金日(末日)</summary>
        public static readonly string ct_col_Last_CollectMoneyDay = "LAST.COLLECTMONEYDAYRF";

        /// <summary>(ソート用)得意先コード</summary>
        public static readonly string ct_col_Sort_CustomerCode = "SORT.CUSTOMERCODE";
        /// <summary>(ソート用)日付</summary>
        public static readonly string ct_col_Sort_Date = "SORT.DATE";
        /// <summary>(ソート用)レコード区分</summary>
        public static readonly string ct_col_Sort_RecordDiv = "SORT.RECORDDIV";
        /// <summary>(ソート用)売上伝票番号</summary>
        public static readonly string ct_col_Sort_SalesSlipNo = "SORT.SALESSLIPNO";
        /// <summary>(ソート用)入金伝票番号</summary>
        public static readonly string ct_col_Sort_DepositSlipNo = "SORT.DEPOSITSLIPNO";
        /// <summary>(ソート用)明細区分</summary>
        public static readonly string ct_col_Sort_DetailDiv = "SORT.DETAILDIV";
        /// <summary>(ソート用)明細行番号</summary>
        public static readonly string ct_col_Sort_DetailRowNo = "SORT.DETAILROWNO";
        /// <summary>(ソート用)レコード区分(空行最後)</summary>
        public static readonly string ct_col_Sort_RecordDiv_EmptyDetail = "SORT.RECORDDIV_EMPTYDETAIL";
        /// <summary>(印刷用)入金フッタ伝票摘要</summary>
        public static readonly string ct_col_DDep_DepFtOutLine = "DDEP.DEPFTOUTLINERF";
        /// <summary>(印刷用)前回請求金額(前回のみ)</summary>
        public static readonly string ct_col_HDmd_LastTimeDemandOrg = "HDMD.LASTTIMEDEMANDORGRF";

        /// <summary>(印刷用)請求明細摘要(定価)</summary>
        public static readonly string ct_col_DAdd_DmdDtlOutLineRF_ListPrice = "DADD.DMDDTLOUTLINERF_LISTPRICE";
      
        /// <summary>今回返品値引額（売上返品＋売上値引）</summary>
        public static readonly string ct_col_ThisTimeRetDis = "HADD.THISTIMERETDISRF";

        /// <summary>入金予定日(年月日 西暦4桁)</summary>
        public static readonly string ct_col_ExpectedDepositDateEx1 = "HADD.EXPECTEDDEPOSITDATEEX1RF";
        /// <summary>入金予定日(年月日 西暦2桁)</summary>
        public static readonly string ct_col_ExpectedDepositDateEx2 = "HADD.EXPECTEDDEPOSITDATEEX2RF";
        /// <summary>入金予定日(/ 西暦4桁)</summary>
        public static readonly string ct_col_ExpectedDepositDateEx3 = "HADD.EXPECTEDDEPOSITDATEEX3RF";
        /// <summary>入金予定日(/ 西暦2桁)</summary>
        public static readonly string ct_col_ExpectedDepositDateEx4 = "HADD.EXPECTEDDEPOSITDATEEX4RF";
        /// <summary>入金予定日(. 西暦4桁)</summary>
        public static readonly string ct_col_ExpectedDepositDateEx5 = "HADD.EXPECTEDDEPOSITDATEEX5RF";
        /// <summary>入金予定日(. 西暦2桁)</summary>
        public static readonly string ct_col_ExpectedDepositDateEx6 = "HADD.EXPECTEDDEPOSITDATEEX6RF";

        /// <summary>計上年月日(年月日 西暦4桁)</summary>
        public static readonly string ct_col_AddUpDateEx1 = "HADD.ADDUPDATEEX1RF";
        /// <summary>計上年月日(年月日 西暦2桁)</summary>
        public static readonly string ct_col_AddUpDateEx2 = "HADD.ADDUPDATEEX2RF";
        /// <summary>計上年月日(/ 西暦4桁)</summary>
        public static readonly string ct_col_AddUpDateEx3 = "HADD.ADDUPDATEEX3RF";
        /// <summary>計上年月日(/ 西暦2桁)</summary>
        public static readonly string ct_col_AddUpDateEx4 = "HADD.ADDUPDATEEX4RF";
        /// <summary>計上年月日(. 西暦4桁)</summary>
        public static readonly string ct_col_AddUpDateEx5 = "HADD.ADDUPDATEEX5RF";
        /// <summary>計上年月日(. 西暦2桁)</summary>
        public static readonly string ct_col_AddUpDateEx6 = "HADD.ADDUPDATEEX6RF";

        /// <summary>締次更新開始年月日(年月日 西暦4桁)</summary>
        public static readonly string ct_col_StartCAddUpUpdDateEx1 = "HADD.STARTCADDUPUPDDATEEX1RF";
        /// <summary>締次更新開始年月日(年月日 西暦2桁)</summary>
        public static readonly string ct_col_StartCAddUpUpdDateEx2 = "HADD.STARTCADDUPUPDDATEEX2RF";
        /// <summary>締次更新開始年月日(/ 西暦4桁)</summary>
        public static readonly string ct_col_StartCAddUpUpdDateEx3 = "HADD.STARTCADDUPUPDDATEEX3RF";
        /// <summary>締次更新開始年月日(/ 西暦2桁)</summary>
        public static readonly string ct_col_StartCAddUpUpdDateEx4 = "HADD.STARTCADDUPUPDDATEEX4RF";
        /// <summary>締次更新開始年月日(. 西暦4桁)</summary>
        public static readonly string ct_col_StartCAddUpUpdDateEx5 = "HADD.STARTCADDUPUPDDATEEX5RF";
        /// <summary>締次更新開始年月日(. 西暦2桁)</summary>
        public static readonly string ct_col_StartCAddUpUpdDateEx6 = "HADD.STARTCADDUPUPDDATEEX6RF";

        /// <summary>請求書発行日(年月日 西暦4桁)</summary>
        public static readonly string ct_col_BillPrintDateEx1 = "HADD.BILLPRINTDATEEX1RF";
        /// <summary>請求書発行日(年月日 西暦2桁)</summary>
        public static readonly string ct_col_BillPrintDateEx2 = "HADD.BILLPRINTDATEEX2RF";
        /// <summary>請求書発行日(/ 西暦4桁)</summary>
        public static readonly string ct_col_BillPrintDateEx3 = "HADD.BILLPRINTDATEEX3RF";
        /// <summary>請求書発行日(/ 西暦2桁)</summary>
        public static readonly string ct_col_BillPrintDateEx4 = "HADD.BILLPRINTDATEEX4RF";
        /// <summary>請求書発行日(. 西暦4桁)</summary>
        public static readonly string ct_col_BillPrintDateEx5 = "HADD.BILLPRINTDATEEX5RF";
        /// <summary>請求書発行日(. 西暦2桁)</summary>
        public static readonly string ct_col_BillPrintDateEx6 = "HADD.BILLPRINTDATEEX6RF";

        /// <summary>入力発行日付(年月日 西暦4桁)</summary>
        public static readonly string ct_col_IssueDayEx1 = "HADD.ISSUEDAYEX1RF";
        /// <summary>入力発行日付(年月日 西暦2桁)</summary>
        public static readonly string ct_col_IssueDayEx2 = "HADD.ISSUEDAYEX2RF";
        /// <summary>入力発行日付(/ 西暦4桁)</summary>
        public static readonly string ct_col_IssueDayEx3 = "HADD.ISSUEDAYEX3RF";
        /// <summary>入力発行日付(/ 西暦2桁)</summary>
        public static readonly string ct_col_IssueDayEx4 = "HADD.ISSUEDAYEX4RF";
        /// <summary>入力発行日付(. 西暦4桁)</summary>
        public static readonly string ct_col_IssueDayEx5 = "HADD.ISSUEDAYEX5RF";
        /// <summary>入力発行日付(. 西暦2桁)</summary>
        public static readonly string ct_col_IssueDayEx6 = "HADD.ISSUEDAYEX6RF";

        /// <summary>金種名称(ｽﾍﾟｰｽ制御)</summary>
        public static readonly string ct_col_DDep_MoneyKindNameSp = "DDEP.MONEYKINDNAMESPRF";

        // --- ADD START 田村顕成 2022/10/18 ----->>>>>
        private static PriceTaxCalculator stc_priceTaxCalculator;
        // --- ADD END   田村顕成 2022/10/18 -----<<<<<

        # endregion

        private static Dictionary<string, string> stc_reportItemDic;

        /// <summary>
        /// ReportItemDic
        /// </summary>
        public static Dictionary<string, string> ReportItemDic
        {
            get
            {
                if (stc_reportItemDic == null)
                {
                    stc_reportItemDic = new Dictionary<string, string>();
                }
                return stc_reportItemDic;
            }
            set { stc_reportItemDic = value; }
        }

        # region [データテーブル生成処理]
        /// <summary>
        /// データテーブル生成処理（印刷テーブルスキーマ定義）
        /// </summary>
        /// <returns>データテーブル</returns>
        /// <remarks>
        /// <br>Note        : データテーブル生成処理（印刷テーブルスキーマ定義）</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note    :  2022/10/18  田村顕成</br>
        /// <br>管理番号   :  11870141-00 インボイス残対応（軽減税率対応）</br>
        /// <br>Update Note  : 2023/04/14 3H 仰亮亮</br>
        /// <br>管理番号     : 11970040-00 自由帳票項目追加対応</br>
        /// <br>               ①売上伝票計金額(税込み)</br>
        /// <br>               ②消費税(伝票転嫁)/売上伝票計金額(税込み)</br>
        /// </remarks>
        public static DataTable CreatePrintDataTable()
        {
            DataTable table = new DataTable( CT_Tbl_PrintData );

            # region [スキーマ定義（ヘッダ情報）]
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ADDUPSECCODERF", typeof( String ) ) ); // 計上拠点コード
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CLAIMCODERF", typeof( Int32 ) ) ); // 請求先コード
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CLAIMNAMERF", typeof( String ) ) ); // 請求先名称
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CLAIMNAME2RF", typeof( String ) ) ); // 請求先名称2
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CLAIMSNMRF", typeof( String ) ) ); // 請求先略称
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CUSTOMERCODERF", typeof( Int32 ) ) ); // 得意先コード
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CUSTOMERNAMERF", typeof( String ) ) ); // 得意先名称
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CUSTOMERNAME2RF", typeof( String ) ) ); // 得意先名称2
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CUSTOMERSNMRF", typeof( String ) ) ); // 得意先略称
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ADDUPDATERF", typeof( Int32 ) ) ); // 計上年月日
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ADDUPYEARMONTHRF", typeof( Int32 ) ) ); // 計上年月
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.LASTTIMEDEMANDRF", typeof( Int64 ) ) ); // 前回請求金額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISTIMEFEEDMDNRMLRF", typeof( Int64 ) ) ); // 今回手数料額（通常入金）
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISTIMEDISDMDNRMLRF", typeof( Int64 ) ) ); // 今回値引額（通常入金）
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISTIMEDMDNRMLRF", typeof( Int64 ) ) ); // 今回入金金額（通常入金）
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISTIMETTLBLCDMDRF", typeof( Int64 ) ) ); // 今回繰越残高（請求計）
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.OFSTHISTIMESALESRF", typeof( Int64 ) ) ); // 相殺後今回売上金額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.OFSTHISSALESTAXRF", typeof( Int64 ) ) ); // 相殺後今回売上消費税
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ITDEDOFFSETOUTTAXRF", typeof( Int64 ) ) ); // 相殺後外税対象額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ITDEDOFFSETINTAXRF", typeof( Int64 ) ) ); // 相殺後内税対象額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ITDEDOFFSETTAXFREERF", typeof( Int64 ) ) ); // 相殺後非課税対象額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.OFFSETOUTTAXRF", typeof( Int64 ) ) ); // 相殺後外税消費税
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.OFFSETINTAXRF", typeof( Int64 ) ) ); // 相殺後内税消費税
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISTIMESALESRF", typeof( Int64 ) ) ); // 今回売上金額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISSALESTAXRF", typeof( Int64 ) ) ); // 今回売上消費税
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ITDEDSALESOUTTAXRF", typeof( Int64 ) ) ); // 売上外税対象額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ITDEDSALESINTAXRF", typeof( Int64 ) ) ); // 売上内税対象額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ITDEDSALESTAXFREERF", typeof( Int64 ) ) ); // 売上非課税対象額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.SALESOUTTAXRF", typeof( Int64 ) ) ); // 売上外税額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.SALESINTAXRF", typeof( Int64 ) ) ); // 売上内税額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISSALESPRICRGDSRF", typeof( Int64 ) ) ); // 今回売上返品金額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISSALESPRCTAXRGDSRF", typeof( Int64 ) ) ); // 今回売上返品消費税
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLITDEDRETOUTTAXRF", typeof( Int64 ) ) ); // 返品外税対象額合計
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLITDEDRETINTAXRF", typeof( Int64 ) ) ); // 返品内税対象額合計
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLITDEDRETTAXFREERF", typeof( Int64 ) ) ); // 返品非課税対象額合計
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLRETOUTERTAXRF", typeof( Int64 ) ) ); // 返品外税額合計
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLRETINNERTAXRF", typeof( Int64 ) ) ); // 返品内税額合計
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISSALESPRICDISRF", typeof( Int64 ) ) ); // 今回売上値引金額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISSALESPRCTAXDISRF", typeof( Int64 ) ) ); // 今回売上値引消費税
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLITDEDDISOUTTAXRF", typeof( Int64 ) ) ); // 値引外税対象額合計
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLITDEDDISINTAXRF", typeof( Int64 ) ) ); // 値引内税対象額合計
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLITDEDDISTAXFREERF", typeof( Int64 ) ) ); // 値引非課税対象額合計
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLDISOUTERTAXRF", typeof( Int64 ) ) ); // 値引外税額合計
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLDISINNERTAXRF", typeof( Int64 ) ) ); // 値引内税額合計
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TAXADJUSTRF", typeof( Int64 ) ) ); // 消費税調整額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.BALANCEADJUSTRF", typeof( Int64 ) ) ); // 残高調整額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.AFCALDEMANDPRICERF", typeof( Int64 ) ) ); // 計算後請求金額
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ACPODRTTL2TMBFBLDMDRF", typeof( Int64 ) ) ); // 受注2回前残高（請求計）
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ACPODRTTL3TMBFBLDMDRF", typeof( Int64 ) ) ); // 受注3回前残高（請求計）
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.STARTCADDUPUPDDATERF", typeof( Int32 ) ) ); // 締次更新開始年月日
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.SALESSLIPCOUNTRF", typeof( Int32 ) ) ); // 売上伝票枚数
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.BILLPRINTDATERF", typeof( Int32 ) ) ); // 請求書発行日
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.EXPECTEDDEPOSITDATERF", typeof( Int32 ) ) ); // 入金予定日
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.COLLECTCONDRF", typeof( Int32 ) ) ); // 回収条件
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CONSTAXLAYMETHODRF", typeof( Int32 ) ) ); // 消費税転嫁方式
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CONSTAXRATERF", typeof( Double ) ) ); // 消費税率
            table.Columns.Add( new DataColumn( "SECHED.SECTIONGUIDENMRF", typeof( String ) ) ); // 拠点ガイド名称
            table.Columns.Add( new DataColumn( "SECHED.SECTIONGUIDESNMRF", typeof( String ) ) ); // 拠点ガイド略称
            table.Columns.Add( new DataColumn( "SECHED.COMPANYNAMECD1RF", typeof( Int32 ) ) ); // 自社名称コード1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYPRRF", typeof( String ) ) ); // 自社PR文
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYNAME1RF", typeof( String ) ) ); // 自社名称1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYNAME2RF", typeof( String ) ) ); // 自社名称2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.POSTNORF", typeof( String ) ) ); // 郵便番号
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS1RF", typeof( String ) ) ); // 住所1（都道府県市区郡・町村・字）
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS3RF", typeof( String ) ) ); // 住所3（番地）
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS4RF", typeof( String ) ) ); // 住所4（アパート名称）
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO1RF", typeof( String ) ) ); // 自社電話番号1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO2RF", typeof( String ) ) ); // 自社電話番号2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO3RF", typeof( String ) ) ); // 自社電話番号3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE1RF", typeof( String ) ) ); // 自社電話番号タイトル1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE2RF", typeof( String ) ) ); // 自社電話番号タイトル2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE3RF", typeof( String ) ) ); // 自社電話番号タイトル3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.TRANSFERGUIDANCERF", typeof( String ) ) ); // 銀行振込案内文
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO1RF", typeof( String ) ) ); // 銀行口座1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO2RF", typeof( String ) ) ); // 銀行口座2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO3RF", typeof( String ) ) ); // 銀行口座3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYSETNOTE1RF", typeof( String ) ) ); // 自社設定摘要1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYSETNOTE2RF", typeof( String ) ) ); // 自社設定摘要2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.IMAGEINFOCODERF", typeof( Int32 ) ) ); // 画像情報コード
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYURLRF", typeof( String ) ) ); // 自社URL
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYPRSENTENCE2RF", typeof( String ) ) ); // 自社PR文2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.IMAGECOMMENTFORPRT1RF", typeof( String ) ) ); // 画像印字用コメント1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.IMAGECOMMENTFORPRT2RF", typeof( String ) ) ); // 画像印字用コメント2
            table.Columns.Add( new DataColumn( "IMAGEINFORF.IMAGEINFODATARF", typeof( Byte[] ) ) ); // 画像情報データ
            table.Columns.Add( new DataColumn( "CSTCST.CUSTOMERSUBCODERF", typeof( String ) ) ); // 得意先サブコード
            table.Columns.Add( new DataColumn( "CSTCST.NAMERF", typeof( String ) ) ); // 得意先名称
            table.Columns.Add( new DataColumn( "CSTCST.NAME2RF", typeof( String ) ) ); // 得意先名称2
            table.Columns.Add( new DataColumn( "CSTCST.HONORIFICTITLERF", typeof( String ) ) ); // 得意先敬称
            table.Columns.Add( new DataColumn( "CSTCST.KANARF", typeof( String ) ) ); // 得意先カナ
            table.Columns.Add( new DataColumn( "CSTCST.CUSTOMERSNMRF", typeof( String ) ) ); // 得意先略称
            table.Columns.Add( new DataColumn( "CSTCST.OUTPUTNAMECODERF", typeof( Int32 ) ) ); // 得意先諸口コード
            table.Columns.Add( new DataColumn( "CSTCST.POSTNORF", typeof( String ) ) ); // 得意先郵便番号
            table.Columns.Add( new DataColumn( "CSTCST.ADDRESS1RF", typeof( String ) ) ); // 得意先住所1（都道府県市区郡・町村・字）
            table.Columns.Add( new DataColumn( "CSTCST.ADDRESS3RF", typeof( String ) ) ); // 得意先住所3（番地）
            table.Columns.Add( new DataColumn( "CSTCST.ADDRESS4RF", typeof( String ) ) ); // 得意先住所4（アパート名称）
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE1RF", typeof( Int32 ) ) ); // 得意先分析コード1
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE2RF", typeof( Int32 ) ) ); // 得意先分析コード2
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE3RF", typeof( Int32 ) ) ); // 得意先分析コード3
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE4RF", typeof( Int32 ) ) ); // 得意先分析コード4
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE5RF", typeof( Int32 ) ) ); // 得意先分析コード5
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE6RF", typeof( Int32 ) ) ); // 得意先分析コード6
            table.Columns.Add( new DataColumn( "CSTCST.NOTE1RF", typeof( String ) ) ); // 得意先備考1
            table.Columns.Add( new DataColumn( "CSTCST.NOTE2RF", typeof( String ) ) ); // 得意先備考2
            table.Columns.Add( new DataColumn( "CSTCST.NOTE3RF", typeof( String ) ) ); // 得意先備考3
            table.Columns.Add( new DataColumn( "CSTCST.NOTE4RF", typeof( String ) ) ); // 得意先備考4
            table.Columns.Add( new DataColumn( "CSTCST.NOTE5RF", typeof( String ) ) ); // 得意先備考5
            table.Columns.Add( new DataColumn( "CSTCST.NOTE6RF", typeof( String ) ) ); // 得意先備考6
            table.Columns.Add( new DataColumn( "CSTCST.NOTE7RF", typeof( String ) ) ); // 得意先備考7
            table.Columns.Add( new DataColumn( "CSTCST.NOTE8RF", typeof( String ) ) ); // 得意先備考8
            table.Columns.Add( new DataColumn( "CSTCST.NOTE9RF", typeof( String ) ) ); // 得意先備考9
            table.Columns.Add( new DataColumn( "CSTCST.NOTE10RF", typeof( String ) ) ); // 得意先備考10
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTOMERSUBCODERF", typeof( String ) ) ); // 請求先サブコード
            table.Columns.Add( new DataColumn( "CSTCLM.NAMERF", typeof( String ) ) ); // 請求先名称
            table.Columns.Add( new DataColumn( "CSTCLM.NAME2RF", typeof( String ) ) ); // 請求先名称2
            table.Columns.Add( new DataColumn( "CSTCLM.HONORIFICTITLERF", typeof( String ) ) ); // 請求先敬称
            table.Columns.Add( new DataColumn( "CSTCLM.KANARF", typeof( String ) ) ); // 請求先カナ
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTOMERSNMRF", typeof( String ) ) ); // 請求先略称
            table.Columns.Add( new DataColumn( "CSTCLM.OUTPUTNAMECODERF", typeof( Int32 ) ) ); // 請求先諸口コード
            table.Columns.Add( new DataColumn( "CSTCLM.POSTNORF", typeof( String ) ) ); // 請求先郵便番号
            table.Columns.Add( new DataColumn( "CSTCLM.ADDRESS1RF", typeof( String ) ) ); // 請求先住所1（都道府県市区郡・町村・字）
            table.Columns.Add( new DataColumn( "CSTCLM.ADDRESS3RF", typeof( String ) ) ); // 請求先住所3（番地）
            table.Columns.Add( new DataColumn( "CSTCLM.ADDRESS4RF", typeof( String ) ) ); // 請求先住所4（アパート名称）
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE1RF", typeof( Int32 ) ) ); // 請求先分析コード1
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE2RF", typeof( Int32 ) ) ); // 請求先分析コード2
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE3RF", typeof( Int32 ) ) ); // 請求先分析コード3
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE4RF", typeof( Int32 ) ) ); // 請求先分析コード4
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE5RF", typeof( Int32 ) ) ); // 請求先分析コード5
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE6RF", typeof( Int32 ) ) ); // 請求先分析コード6
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE1RF", typeof( String ) ) ); // 請求先備考1
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE2RF", typeof( String ) ) ); // 請求先備考2
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE3RF", typeof( String ) ) ); // 請求先備考3
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE4RF", typeof( String ) ) ); // 請求先備考4
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE5RF", typeof( String ) ) ); // 請求先備考5
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE6RF", typeof( String ) ) ); // 請求先備考6
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE7RF", typeof( String ) ) ); // 請求先備考7
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE8RF", typeof( String ) ) ); // 請求先備考8
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE9RF", typeof( String ) ) ); // 請求先備考9
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE10RF", typeof( String ) ) ); // 請求先備考10
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYNAME1RF", typeof( String ) ) ); // 自社名称1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYNAME2RF", typeof( String ) ) ); // 自社名称2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.POSTNORF", typeof( String ) ) ); // 郵便番号
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS1RF", typeof( String ) ) ); // 住所1（都道府県市区郡・町村・字）
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS3RF", typeof( String ) ) ); // 住所3（番地）
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS4RF", typeof( String ) ) ); // 住所4（アパート名称）
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO1RF", typeof( String ) ) ); // 自社電話番号1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO2RF", typeof( String ) ) ); // 自社電話番号2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO3RF", typeof( String ) ) ); // 自社電話番号3
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE1RF", typeof( String ) ) ); // 自社電話番号タイトル1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE2RF", typeof( String ) ) ); // 自社電話番号タイトル2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE3RF", typeof( String ) ) ); // 自社電話番号タイトル3
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD1RF", typeof( Int32 ) ) ); // 入金設定金種コード1
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD2RF", typeof( Int32 ) ) ); // 入金設定金種コード2
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD3RF", typeof( Int32 ) ) ); // 入金設定金種コード3
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD4RF", typeof( Int32 ) ) ); // 入金設定金種コード4
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD5RF", typeof( Int32 ) ) ); // 入金設定金種コード5
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD6RF", typeof( Int32 ) ) ); // 入金設定金種コード6
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD7RF", typeof( Int32 ) ) ); // 入金設定金種コード7
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD8RF", typeof( Int32 ) ) ); // 入金設定金種コード8
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD9RF", typeof( Int32 ) ) ); // 入金設定金種コード9
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD10RF", typeof( Int32 ) ) ); // 入金設定金種コード10
            table.Columns.Add( new DataColumn( "DEPT01.MONEYKINDNAMERF", typeof( String ) ) ); // 入金金種名称1
            table.Columns.Add( new DataColumn( "DEPT01.DEPOSITRF", typeof( Int64 ) ) ); // 入金金額1
            table.Columns.Add( new DataColumn( "DEPT02.MONEYKINDNAMERF", typeof( String ) ) ); // 入金金種名称2
            table.Columns.Add( new DataColumn( "DEPT02.DEPOSITRF", typeof( Int64 ) ) ); // 入金金額2
            table.Columns.Add( new DataColumn( "DEPT03.MONEYKINDNAMERF", typeof( String ) ) ); // 入金金種名称3
            table.Columns.Add( new DataColumn( "DEPT03.DEPOSITRF", typeof( Int64 ) ) ); // 入金金額3
            table.Columns.Add( new DataColumn( "DEPT04.MONEYKINDNAMERF", typeof( String ) ) ); // 入金金種名称4
            table.Columns.Add( new DataColumn( "DEPT04.DEPOSITRF", typeof( Int64 ) ) ); // 入金金額4
            table.Columns.Add( new DataColumn( "DEPT05.MONEYKINDNAMERF", typeof( String ) ) ); // 入金金種名称5
            table.Columns.Add( new DataColumn( "DEPT05.DEPOSITRF", typeof( Int64 ) ) ); // 入金金額5
            table.Columns.Add( new DataColumn( "DEPT06.MONEYKINDNAMERF", typeof( String ) ) ); // 入金金種名称6
            table.Columns.Add( new DataColumn( "DEPT06.DEPOSITRF", typeof( Int64 ) ) ); // 入金金額6
            table.Columns.Add( new DataColumn( "DEPT07.MONEYKINDNAMERF", typeof( String ) ) ); // 入金金種名称7
            table.Columns.Add( new DataColumn( "DEPT07.DEPOSITRF", typeof( Int64 ) ) ); // 入金金額7
            table.Columns.Add( new DataColumn( "DEPT08.MONEYKINDNAMERF", typeof( String ) ) ); // 入金金種名称8
            table.Columns.Add( new DataColumn( "DEPT08.DEPOSITRF", typeof( Int64 ) ) ); // 入金金額8
            table.Columns.Add( new DataColumn( "DEPT09.MONEYKINDNAMERF", typeof( String ) ) ); // 入金金種名称9
            table.Columns.Add( new DataColumn( "DEPT09.DEPOSITRF", typeof( Int64 ) ) ); // 入金金額9
            table.Columns.Add( new DataColumn( "DEPT10.MONEYKINDNAMERF", typeof( String ) ) ); // 入金金種名称10
            table.Columns.Add( new DataColumn( "DEPT10.DEPOSITRF", typeof( Int64 ) ) ); // 入金金額10
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFYRF", typeof( Int32 ) ) ); // 計上年月日西暦年
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFSRF", typeof( Int32 ) ) ); // 計上年月日西暦年略
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFWRF", typeof( Int32 ) ) ); // 計上年月日和暦年
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFMRF", typeof( Int32 ) ) ); // 計上年月日月
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFDRF", typeof( Int32 ) ) ); // 計上年月日日
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFGRF", typeof( String ) ) ); // 計上年月日元号
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFRRF", typeof( String ) ) ); // 計上年月日略号
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFLSRF", typeof( String ) ) ); // 計上年月日リテラル(/)
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFLPRF", typeof( String ) ) ); // 計上年月日リテラル(.)
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFLYRF", typeof( String ) ) ); // 計上年月日リテラル(年)
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFLMRF", typeof( String ) ) ); // 計上年月日リテラル(月)
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFLDRF", typeof( String ) ) ); // 計上年月日リテラル(日)
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFYRF", typeof( Int32 ) ) ); // 計上年月西暦年
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFSRF", typeof( Int32 ) ) ); // 計上年月西暦年略
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFWRF", typeof( Int32 ) ) ); // 計上年月和暦年
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFMRF", typeof( Int32 ) ) ); // 計上年月月
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFGRF", typeof( String ) ) ); // 計上年月元号
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFRRF", typeof( String ) ) ); // 計上年月略号
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFLSRF", typeof( String ) ) ); // 計上年月リテラル(/)
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFLPRF", typeof( String ) ) ); // 計上年月リテラル(.)
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFLYRF", typeof( String ) ) ); // 計上年月リテラル(年)
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFLMRF", typeof( String ) ) ); // 計上年月リテラル(月)
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFYRF", typeof( Int32 ) ) ); // 締次更新開始年月日西暦年
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFSRF", typeof( Int32 ) ) ); // 締次更新開始年月日西暦年略
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFWRF", typeof( Int32 ) ) ); // 締次更新開始年月日和暦年
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFMRF", typeof( Int32 ) ) ); // 締次更新開始年月日月
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFDRF", typeof( Int32 ) ) ); // 締次更新開始年月日日
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFGRF", typeof( String ) ) ); // 締次更新開始年月日元号
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFRRF", typeof( String ) ) ); // 締次更新開始年月日略号
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFLSRF", typeof( String ) ) ); // 締次更新開始年月日リテラル(/)
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFLPRF", typeof( String ) ) ); // 締次更新開始年月日リテラル(.)
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFLYRF", typeof( String ) ) ); // 締次更新開始年月日リテラル(年)
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFLMRF", typeof( String ) ) ); // 締次更新開始年月日リテラル(月)
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFLDRF", typeof( String ) ) ); // 締次更新開始年月日リテラル(日)
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFYRF", typeof( Int32 ) ) ); // 請求書発行日西暦年
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFSRF", typeof( Int32 ) ) ); // 請求書発行日西暦年略
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFWRF", typeof( Int32 ) ) ); // 請求書発行日和暦年
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFMRF", typeof( Int32 ) ) ); // 請求書発行日月
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFDRF", typeof( Int32 ) ) ); // 請求書発行日日
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFGRF", typeof( String ) ) ); // 請求書発行日元号
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFRRF", typeof( String ) ) ); // 請求書発行日略号
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFLSRF", typeof( String ) ) ); // 請求書発行日リテラル(/)
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFLPRF", typeof( String ) ) ); // 請求書発行日リテラル(.)
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFLYRF", typeof( String ) ) ); // 請求書発行日リテラル(年)
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFLMRF", typeof( String ) ) ); // 請求書発行日リテラル(月)
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFLDRF", typeof( String ) ) ); // 請求書発行日リテラル(日)
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFYRF", typeof( Int32 ) ) ); // 入金予定日西暦年
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFSRF", typeof( Int32 ) ) ); // 入金予定日西暦年略
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFWRF", typeof( Int32 ) ) ); // 入金予定日和暦年
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFMRF", typeof( Int32 ) ) ); // 入金予定日月
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFDRF", typeof( Int32 ) ) ); // 入金予定日日
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFGRF", typeof( String ) ) ); // 入金予定日元号
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFRRF", typeof( String ) ) ); // 入金予定日略号
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFLSRF", typeof( String ) ) ); // 入金予定日リテラル(/)
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFLPRF", typeof( String ) ) ); // 入金予定日リテラル(.)
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFLYRF", typeof( String ) ) ); // 入金予定日リテラル(年)
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFLMRF", typeof( String ) ) ); // 入金予定日リテラル(月)
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFLDRF", typeof( String ) ) ); // 入金予定日リテラル(日)
            table.Columns.Add( new DataColumn( "HADD.COLLECTCONDNMRF", typeof( String ) ) ); // 回収条件名称
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE1RF", typeof( String ) ) ); // 請求 鑑タイトル１
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE2RF", typeof( String ) ) ); // 請求 鑑タイトル２
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE3RF", typeof( String ) ) ); // 請求 鑑タイトル３
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE4RF", typeof( String ) ) ); // 請求 鑑タイトル４
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE5RF", typeof( String ) ) ); // 請求 鑑タイトル５
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE6RF", typeof( String ) ) ); // 請求 鑑タイトル６
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE7RF", typeof( String ) ) ); // 請求 鑑タイトル７
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE8RF", typeof( String ) ) ); // 請求 鑑タイトル８
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM1RF", typeof( Int64 ) ) ); // 請求 鑑金額項目１
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM2RF", typeof( Int64 ) ) ); // 請求 鑑金額項目２
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM3RF", typeof( Int64 ) ) ); // 請求 鑑金額項目３
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM4RF", typeof( Int64 ) ) ); // 請求 鑑金額項目４
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM5RF", typeof( Int64 ) ) ); // 請求 鑑金額項目５
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM6RF", typeof( Int64 ) ) ); // 請求 鑑金額項目６
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM7RF", typeof( Int64 ) ) ); // 請求 鑑金額項目７
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM8RF", typeof( Int64 ) ) ); // 請求 鑑金額項目８
            table.Columns.Add( new DataColumn( "HADD.DMDFORMTITLERF", typeof( String ) ) ); // 請求書タイトル
            table.Columns.Add( new DataColumn( "HADD.DMDFORMTITLE2RF", typeof( String ) ) ); // 請求書タイトル２
            table.Columns.Add( new DataColumn( "HADD.DMDFORMCOMENT1RF", typeof( String ) ) ); // 請求書コメント１
            table.Columns.Add( new DataColumn( "HADD.DMDFORMCOMENT2RF", typeof( String ) ) ); // 請求書コメント２
            table.Columns.Add( new DataColumn( "HADD.DMDFORMCOMENT3RF", typeof( String ) ) ); // 請求書コメント３
            table.Columns.Add( new DataColumn( "HADD.DMDNRMLEXDISRF", typeof( Int64 ) ) ); // 入金金額(値引除く)
            table.Columns.Add( new DataColumn( "HADD.DMDNRMLEXFEERF", typeof( Int64 ) ) ); // 入金金額(手数料除く)
            table.Columns.Add( new DataColumn( "HADD.DMDNRMLEXDISFEERF", typeof( Int64 ) ) ); // 入金金額(値引・手数料除く)
            table.Columns.Add( new DataColumn( "HADD.DMDNRMLSAMDISFEERF", typeof( Int64 ) ) ); // 入金金額(値引＋手数料のみ)
            table.Columns.Add( new DataColumn( "HADD.THISSALESANDADJUSTRF", typeof( Int64 ) ) ); // 今回売上額(残高調整含む)
            table.Columns.Add( new DataColumn( "HADD.THISTAXANDADJUSTRF", typeof( Int64 ) ) ); // 今回消費税(消費税調整含む)
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYRF", typeof( Int32 ) ) ); // 入力発行日付
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFYRF", typeof( Int32 ) ) ); // 入力発行日付西暦年
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFSRF", typeof( Int32 ) ) ); // 入力発行日付西暦年略
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFWRF", typeof( Int32 ) ) ); // 入力発行日付和暦年
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFMRF", typeof( Int32 ) ) ); // 入力発行日付月
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFDRF", typeof( Int32 ) ) ); // 入力発行日付日
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFGRF", typeof( String ) ) ); // 入力発行日付元号
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFRRF", typeof( String ) ) ); // 入力発行日付略号
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFLSRF", typeof( String ) ) ); // 入力発行日付リテラル(/)
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFLPRF", typeof( String ) ) ); // 入力発行日付リテラル(.)
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFLYRF", typeof( String ) ) ); // 入力発行日付リテラル(年)
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFLMRF", typeof( String ) ) ); // 入力発行日付リテラル(月)
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFLDRF", typeof( String ) ) ); // 入力発行日付リテラル(日)
            table.Columns.Add( new DataColumn( "CADD.CUSTOMERSUBCODERF", typeof( String ) ) ); // 印刷得意先サブコード
            table.Columns.Add( new DataColumn( "CADD.NAMERF", typeof( String ) ) ); // 印刷得意先名称
            table.Columns.Add( new DataColumn( "CADD.NAME2RF", typeof( String ) ) ); // 印刷得意先名称2
            table.Columns.Add( new DataColumn( "CADD.HONORIFICTITLERF", typeof( String ) ) ); // 印刷得意先敬称
            table.Columns.Add(new DataColumn("CADD.HONORIFICTITLE2RF", typeof(String))); // 印刷得意先敬称（印字位置変更用）
            table.Columns.Add( new DataColumn( "CADD.KANARF", typeof( String ) ) ); // 印刷得意先カナ
            table.Columns.Add( new DataColumn( "CADD.CUSTOMERSNMRF", typeof( String ) ) ); // 印刷得意先略称
            table.Columns.Add( new DataColumn( "CADD.OUTPUTNAMECODERF", typeof( Int32 ) ) ); // 印刷得意先諸口コード
            table.Columns.Add( new DataColumn( "CADD.POSTNORF", typeof( String ) ) ); // 印刷得意先郵便番号
            table.Columns.Add( new DataColumn( "CADD.ADDRESS1RF", typeof( String ) ) ); // 印刷得意先住所1（都道府県市区郡・町村・字）
            table.Columns.Add( new DataColumn( "CADD.ADDRESS3RF", typeof( String ) ) ); // 印刷得意先住所3（番地）
            table.Columns.Add( new DataColumn( "CADD.ADDRESS4RF", typeof( String ) ) ); // 印刷得意先住所4（アパート名称）
            table.Columns.Add(new DataColumn("CADD.ADDRESS123RF", typeof(String))); // 印刷得意先住所1+2+3
            table.Columns.Add(new DataColumn("CADD.POSTNOLRF", typeof(String))); // 印刷得意先郵便番号（中文字用）
            table.Columns.Add(new DataColumn("CADD.POSTNOBRF", typeof(String))); // 印刷得意先郵便番号（大文字用）
            table.Columns.Add(new DataColumn("CADD.ADDRESS1LRF", typeof(String))); // 印刷得意先住所1（中文字用）
            table.Columns.Add(new DataColumn("CADD.ADDRESS1BRF", typeof(String))); // 印刷得意先住所1（大文字用）
            table.Columns.Add(new DataColumn("CADD.ADDRESS3LRF", typeof(String))); // 印刷得意先住所3（中文字用）
            table.Columns.Add(new DataColumn("CADD.ADDRESS3BRF", typeof(String))); // 印刷得意先住所3（大文字用）
            table.Columns.Add(new DataColumn("CADD.ADDRESS4LRF", typeof(String))); // 印刷得意先住所4（中文字用）
            table.Columns.Add(new DataColumn("CADD.ADDRESS4BRF", typeof(String))); // 印刷得意先住所4（大文字用）
            table.Columns.Add( new DataColumn( "CADD.CUSTANALYSCODE1RF", typeof( Int32 ) ) ); // 印刷得意先分析コード1
            table.Columns.Add( new DataColumn( "CADD.CUSTANALYSCODE2RF", typeof( Int32 ) ) ); // 印刷得意先分析コード2
            table.Columns.Add( new DataColumn( "CADD.CUSTANALYSCODE3RF", typeof( Int32 ) ) ); // 印刷得意先分析コード3
            table.Columns.Add( new DataColumn( "CADD.CUSTANALYSCODE4RF", typeof( Int32 ) ) ); // 印刷得意先分析コード4
            table.Columns.Add( new DataColumn( "CADD.CUSTANALYSCODE5RF", typeof( Int32 ) ) ); // 印刷得意先分析コード5
            table.Columns.Add( new DataColumn( "CADD.CUSTANALYSCODE6RF", typeof( Int32 ) ) ); // 印刷得意先分析コード6
            table.Columns.Add( new DataColumn( "CADD.NOTE1RF", typeof( String ) ) ); // 印刷得意先備考1
            table.Columns.Add( new DataColumn( "CADD.NOTE2RF", typeof( String ) ) ); // 印刷得意先備考2
            table.Columns.Add( new DataColumn( "CADD.NOTE3RF", typeof( String ) ) ); // 印刷得意先備考3
            table.Columns.Add( new DataColumn( "CADD.NOTE4RF", typeof( String ) ) ); // 印刷得意先備考4
            table.Columns.Add( new DataColumn( "CADD.NOTE5RF", typeof( String ) ) ); // 印刷得意先備考5
            table.Columns.Add( new DataColumn( "CADD.NOTE6RF", typeof( String ) ) ); // 印刷得意先備考6
            table.Columns.Add( new DataColumn( "CADD.NOTE7RF", typeof( String ) ) ); // 印刷得意先備考7
            table.Columns.Add( new DataColumn( "CADD.NOTE8RF", typeof( String ) ) ); // 印刷得意先備考8
            table.Columns.Add( new DataColumn( "CADD.NOTE9RF", typeof( String ) ) ); // 印刷得意先備考9
            table.Columns.Add( new DataColumn( "CADD.NOTE10RF", typeof( String ) ) ); // 印刷得意先備考10
            table.Columns.Add( new DataColumn( "CADD.PRINTCUSTOMERNAME1RF", typeof( String ) ) ); // 印刷用得意先名称（上段）
            table.Columns.Add( new DataColumn( "CADD.PRINTCUSTOMERNAME2RF", typeof( String ) ) ); // 印刷用得意先名称（下段）
            table.Columns.Add( new DataColumn( "CADD.PRINTCUSTOMERNAME2HNRF", typeof( String ) ) ); // 印刷用得意先名称（下段）＋敬称
            table.Columns.Add( new DataColumn( "CSTCST.COLLECTMONEYNAMERF", typeof( String ) ) ); // 集金月区分名称
            table.Columns.Add( new DataColumn( "CSTCST.COLLECTMONEYDAYRF", typeof( Int32 ) ) ); // 集金日
            table.Columns.Add( new DataColumn( "CADD.CUSTOMERCODERF", typeof( Int32 ) ) ); // 印刷得意先コード
            table.Columns.Add( new DataColumn( "CADD.HOMETELNORF", typeof( String ) ) ); // 印刷得意先電話番号（自宅）
            table.Columns.Add( new DataColumn( "CADD.OFFICETELNORF", typeof( String ) ) ); // 印刷得意先電話番号（勤務先）
            table.Columns.Add( new DataColumn( "CADD.PORTABLETELNORF", typeof( String ) ) ); // 印刷得意先電話番号（携帯）
            table.Columns.Add( new DataColumn( "CADD.HOMEFAXNORF", typeof( String ) ) ); // 印刷得意先FAX番号（自宅）
            table.Columns.Add( new DataColumn( "CADD.OFFICEFAXNORF", typeof( String ) ) ); // 印刷得意先FAX番号（勤務先）
            table.Columns.Add( new DataColumn( "CADD.OTHERSTELNORF", typeof( String ) ) ); // 印刷得意先電話番号（その他）
            table.Columns.Add( new DataColumn( "CSTCST.HOMETELNORF", typeof( String ) ) ); // 得意先電話番号（自宅）
            table.Columns.Add( new DataColumn( "CSTCST.OFFICETELNORF", typeof( String ) ) ); // 得意先電話番号（勤務先）
            table.Columns.Add( new DataColumn( "CSTCST.PORTABLETELNORF", typeof( String ) ) ); // 得意先電話番号（携帯）
            table.Columns.Add( new DataColumn( "CSTCST.HOMEFAXNORF", typeof( String ) ) ); // 得意先FAX番号（自宅）
            table.Columns.Add( new DataColumn( "CSTCST.OFFICEFAXNORF", typeof( String ) ) ); // 得意先FAX番号（勤務先）
            table.Columns.Add( new DataColumn( "CSTCST.OTHERSTELNORF", typeof( String ) ) ); // 得意先電話番号（その他）
            table.Columns.Add( new DataColumn( "CSTCLM.HOMETELNORF", typeof( String ) ) ); // 請求先電話番号（自宅）
            table.Columns.Add( new DataColumn( "CSTCLM.OFFICETELNORF", typeof( String ) ) ); // 請求先電話番号（勤務先）
            table.Columns.Add( new DataColumn( "CSTCLM.PORTABLETELNORF", typeof( String ) ) ); // 請求先電話番号（携帯）
            table.Columns.Add( new DataColumn( "CSTCLM.HOMEFAXNORF", typeof( String ) ) ); // 請求先FAX番号（自宅）
            table.Columns.Add( new DataColumn( "CSTCLM.OFFICEFAXNORF", typeof( String ) ) ); // 請求先FAX番号（勤務先）
            table.Columns.Add( new DataColumn( "CSTCLM.OTHERSTELNORF", typeof( String ) ) ); // 請求先電話番号（その他）
            table.Columns.Add( new DataColumn( "HADD.THISSALESANDADJUSTTAXINCRF", typeof( Int64 ) ) ); // 今回売上額(税込)
            table.Columns.Add( new DataColumn( "HADD.PRINTCUSTOMERNAMEJOIN12RF", typeof( String ) ) ); // 得意先名１＋得意先名２
            table.Columns.Add( new DataColumn( "HADD.PRINTCUSTOMERNAMEJOIN12HNRF", typeof( String ) ) ); // 得意先名１＋得意先名２＋敬称
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12LRF", typeof(String))); // 得意先名１＋得意先名２（中文字用）
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12BRF", typeof(String))); // 得意先名１＋得意先名２（大文字用）
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME1FHRF", typeof( String ) ) ); // 自社名１（前半）
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME1LHRF", typeof( String ) ) ); // 自社名１（後半）
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME2FHRF", typeof( String ) ) ); // 自社名２（前半）
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME2LHRF", typeof( String ) ) ); // 自社名２（後半）
            table.Columns.Add( new DataColumn( "ALITMDSPNMRF.HOMETELNODSPNAMERF", typeof( String ) ) ); // 自宅TEL表示名称
            table.Columns.Add( new DataColumn( "ALITMDSPNMRF.OFFICETELNODSPNAMERF", typeof( String ) ) ); // 勤務先TEL表示名称
            table.Columns.Add( new DataColumn( "ALITMDSPNMRF.MOBILETELNODSPNAMERF", typeof( String ) ) ); // 携帯TEL表示名称
            table.Columns.Add( new DataColumn( "ALITMDSPNMRF.HOMEFAXNODSPNAMERF", typeof( String ) ) ); // 自宅FAX表示名称
            table.Columns.Add( new DataColumn( "ALITMDSPNMRF.OFFICEFAXNODSPNAMERF", typeof( String ) ) ); // 勤務先FAX表示名称
            table.Columns.Add( new DataColumn( "ALITMDSPNMRF.OTHERTELNODSPNAMERF", typeof( String ) ) ); // その他TEL表示名称
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAMEEX1RF", typeof( String ) ) ); // 印刷用自社名（上段）
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAMEEX2RF", typeof( String ) ) ); // 印刷用自社名（下段）
            table.Columns.Add( new DataColumn( "HADD.OFSTHISSALESTAXINCRF", typeof( Int64 ) ) );//相殺後売上合計金額(税込)
            table.Columns.Add( new DataColumn( "CADD.Name2HNRF", typeof( String ) ) );// 印刷得意先名称２＋敬称
            table.Columns.Add( new DataColumn( "CADD.PRINTCUSTOMERNAMEJOIN12UPRF", typeof( String ) ) ); //印刷用得意先名称１＋２(上段)
            table.Columns.Add( new DataColumn( "CADD.PRINTCUSTOMERNAMEJOIN12LOWRF", typeof( String ) ) ); //印刷用得意先名称１＋２(下段)
            table.Columns.Add(new DataColumn("HADD.OFSTHISSALESTAXINC2RF", typeof(Int64)));//相殺後売上合計金額(税込)(非課税・子も印字）
            // 日付関連バリエーション
            table.Columns.Add( new DataColumn( ct_col_ExpectedDepositDateEx1, typeof( string ) ) ); // 入金予定日(年月日 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_ExpectedDepositDateEx2, typeof( string ) ) ); // 入金予定日(年月日 西暦2桁)
            table.Columns.Add( new DataColumn( ct_col_ExpectedDepositDateEx3, typeof( string ) ) ); // 入金予定日(/ 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_ExpectedDepositDateEx4, typeof( string ) ) ); // 入金予定日(/ 西暦2桁)
            table.Columns.Add( new DataColumn( ct_col_ExpectedDepositDateEx5, typeof( string ) ) ); // 入金予定日(. 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_ExpectedDepositDateEx6, typeof( string ) ) ); // 入金予定日(. 西暦2桁)
            table.Columns.Add( new DataColumn( ct_col_AddUpDateEx1, typeof( string ) ) ); // 計上年月日(年月日 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_AddUpDateEx2, typeof( string ) ) ); // 計上年月日(年月日 西暦2桁)
            table.Columns.Add( new DataColumn( ct_col_AddUpDateEx3, typeof( string ) ) ); // 計上年月日(/ 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_AddUpDateEx4, typeof( string ) ) ); // 計上年月日(/ 西暦2桁)
            table.Columns.Add( new DataColumn( ct_col_AddUpDateEx5, typeof( string ) ) ); // 計上年月日(. 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_AddUpDateEx6, typeof( string ) ) ); // 計上年月日(. 西暦2桁)
            table.Columns.Add( new DataColumn( ct_col_StartCAddUpUpdDateEx1, typeof( string ) ) ); // 締次更新開始年月日(年月日 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_StartCAddUpUpdDateEx2, typeof( string ) ) ); // 締次更新開始年月日(年月日 西暦2桁)
            table.Columns.Add( new DataColumn( ct_col_StartCAddUpUpdDateEx3, typeof( string ) ) ); // 締次更新開始年月日(/ 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_StartCAddUpUpdDateEx4, typeof( string ) ) ); // 締次更新開始年月日(/ 西暦2桁)
            table.Columns.Add( new DataColumn( ct_col_StartCAddUpUpdDateEx5, typeof( string ) ) ); // 締次更新開始年月日(. 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_StartCAddUpUpdDateEx6, typeof( string ) ) ); // 締次更新開始年月日(. 西暦2桁)
            table.Columns.Add( new DataColumn( ct_col_BillPrintDateEx1, typeof( string ) ) ); // 請求書発行日(年月日 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_BillPrintDateEx2, typeof( string ) ) ); // 請求書発行日(年月日 西暦2桁)
            table.Columns.Add( new DataColumn( ct_col_BillPrintDateEx3, typeof( string ) ) ); // 請求書発行日(/ 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_BillPrintDateEx4, typeof( string ) ) ); // 請求書発行日(/ 西暦2桁)
            table.Columns.Add( new DataColumn( ct_col_BillPrintDateEx5, typeof( string ) ) ); // 請求書発行日(. 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_BillPrintDateEx6, typeof( string ) ) ); // 請求書発行日(. 西暦2桁)
            table.Columns.Add( new DataColumn( ct_col_IssueDayEx1, typeof( string ) ) ); // 入力発行日付(年月日 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_IssueDayEx2, typeof( string ) ) ); // 入力発行日付(年月日 西暦2桁)
            table.Columns.Add( new DataColumn( ct_col_IssueDayEx3, typeof( string ) ) ); // 入力発行日付(/ 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_IssueDayEx4, typeof( string ) ) ); // 入力発行日付(/ 西暦2桁)
            table.Columns.Add( new DataColumn( ct_col_IssueDayEx5, typeof( string ) ) ); // 入力発行日付(. 西暦4桁)
            table.Columns.Add( new DataColumn( ct_col_IssueDayEx6, typeof( string ) ) ); // 入力発行日付(. 西暦2桁)
            // 鑑項目(印刷用)
            table.Columns.Add( new DataColumn( ct_col_ThisTimeRetDis, typeof( Int64 ) ) ); // 今回返品値引額（売上返品＋売上値引）
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.BILLNORF", typeof( Int32 ) ) ); // 請求書番号
            // 売上合計
            table.Columns.Add( new DataColumn( "HADD.SALESANDRGDSRF", typeof( Int64 ) ) ); // 今回売上（売上－返品）
            table.Columns.Add( new DataColumn( "HADD.SALESANDDISRF", typeof( Int64 ) ) ); // 今回売上（売上－値引）
            // 入金合計
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALCASHRF", typeof( Int64 ) ) ); // 入金合計（現金）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALTRANSFERRF", typeof( Int64 ) ) ); // 入金合計（振込）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALCHECKRF", typeof( Int64 ) ) ); // 入金合計（小切手）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALDRAFTRF", typeof( Int64 ) ) ); // 入金合計（手形）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALOFFSETRF", typeof( Int64 ) ) ); // 入金合計（相殺）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALOTHERSRF", typeof( Int64 ) ) ); // 入金合計（その他）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALACCOUNTRF", typeof( Int64 ) ) ); // 入金合計（口座振込）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALFACTORINGRF", typeof( Int64 ) ) ); // 入金合計（ファクタリング）
            // 入金合計（合算）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALSUM1RF", typeof( Int64 ) ) ); // 入金合計（手数料＋その他）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALSUM2RF", typeof( Int64 ) ) ); // 入金合計（値引＋その他）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALSUM3RF", typeof( Int64 ) ) ); // 入金合計（相殺＋その他）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALSUM4RF", typeof( Int64 ) ) ); // 入金合計（手数料＋相殺＋その他）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALSUM5RF", typeof( Int64 ) ) ); // 入金合計（値引＋手数料＋その他）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALSUM6RF", typeof( Int64 ) ) ); // 入金合計（値引＋相殺＋その他）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALSUM7RF", typeof( Int64 ) ) ); // 入金合計（手数料＋相殺＋値引＋その他）
            table.Columns.Add(new DataColumn("HADD.DEPTTOTALSUM8RF", typeof(Int64))); // 入金合計（現金＋振込＋小切手＋手形）
            // 入金合計（合算分除く）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALEXC1RF", typeof( Int64 ) ) ); // 入金合計（手数料・その他除く）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALEXC2RF", typeof( Int64 ) ) ); // 入金合計（値引・その他除く）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALEXC3RF", typeof( Int64 ) ) ); // 入金合計（相殺・その他除く）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALEXC4RF", typeof( Int64 ) ) ); // 入金合計（手数料・相殺・その他除く）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALEXC5RF", typeof( Int64 ) ) ); // 入金合計（値引・手数料・その他除く）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALEXC6RF", typeof( Int64 ) ) ); // 入金合計（値引・相殺・その他除く）
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALEXC7RF", typeof( Int64 ) ) ); // 入金合計（手数料・相殺・値引・その他除く）
            table.Columns.Add(new DataColumn("HADD.DEPTTOTALEXC8RF", typeof(Int64))); // 入金合計（現金・振込・小切手・手形除く）
            table.Columns.Add(new DataColumn("HADD.SALESEMPLOYEECDRF", typeof(string)));  // 得意先担当者コード
            table.Columns.Add(new DataColumn("HADD.EXPECTEDDEPOSITMONEYRF", typeof(Int64)));    // 入金予定額
            table.Columns.Add(new DataColumn("HADD.LASTPAGECOMMENTRF", typeof(string)));    // 最終頁コメント
            table.Columns.Add(new DataColumn("HADD.TOTALTAXINCTITLERF", typeof(string)));    // 鑑税込計タイトル
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12UP2RF", typeof(String))); // 印刷得意先名称１＋２（10-15：上段）
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12LOW2RF", typeof(String))); // 印刷得意先名称１＋２（10-15：下段）
            table.Columns.Add(new DataColumn("HADD.CALCEXPECTEDDEPOSITDATEFDRF", typeof(Int32))); // 計算入金予定日日
            table.Columns.Add(new DataColumn("LAST.CALCEXPECTEDDEPOSITDATERF", typeof(string))); // 計算入金予定日日（末）
            table.Columns.Add(new DataColumn("HADD.CALCEXPECTEDDEPOSITDATEFMRF", typeof(Int32))); // 計算入金予定日月
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12UP3RF", typeof(String))); // 印刷得意先名称１＋２（15-15：上段）
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12LOW3RF", typeof(String))); // 印刷得意先名称１＋２（15-15：下段）
            table.Columns.Add(new DataColumn("HADD.ADDRESS12UPRF", typeof(String))); // 印刷得意先住所１＋２（上段）
            table.Columns.Add(new DataColumn("HADD.ADDRESS12LOWRF", typeof(String))); // 印刷得意先住所１＋２（下段）
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12UP4RF", typeof(String))); // 印刷得意先名称１＋２（15-15：上段）
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12LOW4RF", typeof(String))); // 印刷得意先名称１＋２（15-15：下段）
            table.Columns.Add(new DataColumn("HADD.SALESMONEYPAGETTLRF", typeof(Int64))); // 売上金額頁計
            table.Columns.Add(new DataColumn("HADD.OFSTHISTIMESALESLASTPAGERF", typeof(Int64))); // 相殺後今回売上金額（最終頁）
            # endregion

            # region [スキーマ定義（明細情報）]
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ACPTANODRSTATUSRF", typeof( Int32 ) ) ); // 受注ステータス
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSLIPNUMRF", typeof( String ) ) ); // 売上伝票番号
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SECTIONCODERF", typeof( String ) ) ); // 拠点コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SUBSECTIONCODERF", typeof( Int32 ) ) ); // 部門コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DEBITNOTEDIVRF", typeof( Int32 ) ) ); // 赤伝区分
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSLIPCDRF", typeof( Int32 ) ) ); // 売上伝票区分
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESGOODSCDRF", typeof( Int32 ) ) ); // 売上商品区分
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ACCRECDIVCDRF", typeof( Int32 ) ) ); // 売掛区分
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DEMANDADDUPSECCDRF", typeof( String ) ) ); // 請求計上拠点コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESDATERF", typeof( Int32 ) ) ); // 売上日付
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDUPADATERF", typeof( Int32 ) ) ); // 計上日付
            table.Columns.Add( new DataColumn( "SALESSLIPRF.INPUTAGENCDRF", typeof( String ) ) ); // 入力担当者コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.INPUTAGENNMRF", typeof( String ) ) ); // 入力担当者名称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESINPUTCODERF", typeof( String ) ) ); // 売上入力者コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESINPUTNAMERF", typeof( String ) ) ); // 売上入力者名称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FRONTEMPLOYEECDRF", typeof( String ) ) ); // 受付従業員コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FRONTEMPLOYEENMRF", typeof( String ) ) ); // 受付従業員名称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESEMPLOYEECDRF", typeof( String ) ) ); // 販売従業員コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESEMPLOYEENMRF", typeof( String ) ) ); // 販売従業員名称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESTOTALTAXINCRF", typeof( Int64 ) ) ); // 売上伝票合計（税込み）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESTOTALTAXEXCRF", typeof( Int64 ) ) ); // 売上伝票合計（税抜き）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESPRTTOTALTAXINCRF", typeof( Int64 ) ) ); // 売上部品合計（税込み）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESPRTTOTALTAXEXCRF", typeof( Int64 ) ) ); // 売上部品合計（税抜き）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESWORKTOTALTAXINCRF", typeof( Int64 ) ) ); // 売上作業合計（税込み）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESWORKTOTALTAXEXCRF", typeof( Int64 ) ) ); // 売上作業合計（税抜き）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSUBTOTALTAXINCRF", typeof( Int64 ) ) ); // 売上小計（税込み）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSUBTOTALTAXEXCRF", typeof( Int64 ) ) ); // 売上小計（税抜き）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESPRTSUBTTLINCRF", typeof( Int64 ) ) ); // 売上部品小計（税込み）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESPRTSUBTTLEXCRF", typeof( Int64 ) ) ); // 売上部品小計（税抜き）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESWORKSUBTTLINCRF", typeof( Int64 ) ) ); // 売上作業小計（税込み）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESWORKSUBTTLEXCRF", typeof( Int64 ) ) ); // 売上作業小計（税抜き）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSUBTOTALTAXRF", typeof( Int64 ) ) ); // 売上小計（税）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ITDEDPARTSDISOUTTAXRF", typeof( Int64 ) ) ); // 部品値引対象額合計（税抜き）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ITDEDPARTSDISINTAXRF", typeof( Int64 ) ) ); // 部品値引対象額合計（税込み）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ITDEDWORKDISOUTTAXRF", typeof( Int64 ) ) ); // 作業値引対象額合計（税抜き）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ITDEDWORKDISINTAXRF", typeof( Int64 ) ) ); // 作業値引対象額合計（税込み）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.PARTSDISCOUNTRATERF", typeof( Double ) ) ); // 部品値引率
            table.Columns.Add( new DataColumn( "SALESSLIPRF.RAVORDISCOUNTRATERF", typeof( Double ) ) ); // 工賃値引率
            table.Columns.Add( new DataColumn( "SALESSLIPRF.TOTALCOSTRF", typeof( Int64 ) ) ); // 原価金額計
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CONSTAXRATERF", typeof( Double ) ) ); // 消費税税率
            table.Columns.Add( new DataColumn( "SALESSLIPRF.AUTODEPOSITCDRF", typeof( Int32 ) ) ); // 自動入金区分
            table.Columns.Add( new DataColumn( "SALESSLIPRF.AUTODEPOSITSLIPNORF", typeof( Int32 ) ) ); // 自動入金伝票番号
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DEPOSITALLOWANCETTLRF", typeof( Int64 ) ) ); // 入金引当合計額
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DEPOSITALWCBLNCERF", typeof( Int64 ) ) ); // 入金引当残高
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CLAIMCODERF", typeof( Int32 ) ) ); // 請求先コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERCODERF", typeof( Int32 ) ) ); // 得意先コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERNAMERF", typeof( String ) ) ); // 得意先名称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERNAME2RF", typeof( String ) ) ); // 得意先名称２
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERSNMRF", typeof( String ) ) ); // 得意先略称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.HONORIFICTITLERF", typeof( String ) ) ); // 得意先敬称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEECODERF", typeof( Int32 ) ) ); // 納品先コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEENAMERF", typeof( String ) ) ); // 納品先名称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEENAME2RF", typeof( String ) ) ); // 納品先名称2
            table.Columns.Add( new DataColumn( "SALESSLIPRF.PARTYSALESLIPNUMRF", typeof( String ) ) ); // 相手先伝票番号
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SLIPNOTERF", typeof( String ) ) ); // 伝票備考
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SLIPNOTE2RF", typeof( String ) ) ); // 伝票備考２
            table.Columns.Add(new DataColumn("SALESSLIPRF.SLIPNOTE2_2RF", typeof(String))); // 伝票備考２－２
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SLIPNOTE3RF", typeof( String ) ) ); // 伝票備考３
            table.Columns.Add( new DataColumn( "SALESSLIPRF.RETGOODSREASONDIVRF", typeof( Int32 ) ) ); // 返品理由コード
            table.Columns.Add( new DataColumn( "SALESSLIPRF.RETGOODSREASONRF", typeof( String ) ) ); // 返品理由
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DETAILROWCOUNTRF", typeof( Int32 ) ) ); // 明細行数
            table.Columns.Add( new DataColumn( "SALESSLIPRF.UOEREMARK1RF", typeof( String ) ) ); // ＵＯＥリマーク１
            table.Columns.Add( new DataColumn( "SALESSLIPRF.UOEREMARK2RF", typeof( String ) ) ); // ＵＯＥリマーク２
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DELIVEREDGOODSDIVRF", typeof( Int32 ) ) ); // 納品区分
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DELIVEREDGOODSDIVNMRF", typeof( String ) ) ); // 納品区分名称
            table.Columns.Add( new DataColumn( "SALESSLIPRF.STOCKGOODSTTLTAXEXCRF", typeof( Int64 ) ) ); // 在庫商品合計金額（税抜）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.PUREGOODSTTLTAXEXCRF", typeof( Int64 ) ) ); // 純正商品合計金額（税抜）
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FOOTNOTES1RF", typeof( String ) ) ); // 脚注１
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FOOTNOTES2RF", typeof( String ) ) ); // 脚注２
            table.Columns.Add( new DataColumn( "SECDTL.SECTIONGUIDENMRF", typeof( String ) ) ); // 拠点ガイド名称
            table.Columns.Add( new DataColumn( "SECDTL.SECTIONGUIDESNMRF", typeof( String ) ) ); // 拠点ガイド略称
            table.Columns.Add( new DataColumn( "SECDTL.COMPANYNAMECD1RF", typeof( Int32 ) ) ); // 自社名称コード1
            table.Columns.Add( new DataColumn( "SUBSAL.SUBSECTIONNAMERF", typeof( String ) ) ); // 売上部門名称
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ACCEPTANORDERNORF", typeof( Int32 ) ) ); // 受注番号
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESROWNORF", typeof( Int32 ) ) ); // 売上行番号
            table.Columns.Add( new DataColumn( "SALESDETAILRF.DELIGDSCMPLTDUEDATERF", typeof( Int32 ) ) ); // 納品完了予定日
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSKINDCODERF", typeof( Int32 ) ) ); // 商品属性
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSMAKERCDRF", typeof( Int32 ) ) ); // 商品メーカーコード
            table.Columns.Add( new DataColumn( "SALESDETAILRF.MAKERNAMERF", typeof( String ) ) ); // メーカー名称
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSNORF", typeof( String ) ) ); // 商品番号
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSNAMERF", typeof( String ) ) ); // 商品名称
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSSHORTNAMERF", typeof( String ) ) ); // 商品名略称
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSLGROUPRF", typeof( Int32 ) ) ); // 商品大分類コード
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSLGROUPNAMERF", typeof( String ) ) ); // 商品大分類名称
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSMGROUPRF", typeof( Int32 ) ) ); // 商品中分類コード
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSMGROUPNAMERF", typeof( String ) ) ); // 商品中分類名称
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BLGROUPCODERF", typeof( Int32 ) ) ); // BLグループコード
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BLGROUPNAMERF", typeof( String ) ) ); // BLグループコード名称
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BLGOODSCODERF", typeof( Int32 ) ) ); // BL商品コード
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BLGOODSFULLNAMERF", typeof( String ) ) ); // BL商品コード名称（全角）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ENTERPRISEGANRECODERF", typeof( Int32 ) ) ); // 自社分類コード
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ENTERPRISEGANRENAMERF", typeof( String ) ) ); // 自社分類名称
            table.Columns.Add( new DataColumn( "SALESDETAILRF.WAREHOUSECODERF", typeof( String ) ) ); // 倉庫コード
            table.Columns.Add( new DataColumn( "SALESDETAILRF.WAREHOUSENAMERF", typeof( String ) ) ); // 倉庫名称
            table.Columns.Add( new DataColumn( "SALESDETAILRF.WAREHOUSESHELFNORF", typeof( String ) ) ); // 倉庫棚番
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESORDERDIVCDRF", typeof( Int32 ) ) ); // 売上在庫取寄せ区分
            table.Columns.Add( new DataColumn( "SALESDETAILRF.OPENPRICEDIVRF", typeof( Int32 ) ) ); // オープン価格区分
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSRATERANKRF", typeof( String ) ) ); // 商品掛率ランク
            table.Columns.Add( new DataColumn( "SALESDETAILRF.LISTPRICERATERF", typeof( Double ) ) ); // 定価率
            table.Columns.Add( new DataColumn( "SALESDETAILRF.LISTPRICETAXINCFLRF", typeof( Double ) ) ); // 定価（税込，浮動）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.LISTPRICETAXEXCFLRF", typeof( Double ) ) ); // 定価（税抜，浮動）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESRATERF", typeof( Double ) ) ); // 売価率
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESUNPRCTAXINCFLRF", typeof( Double ) ) ); // 売上単価（税込，浮動）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESUNPRCTAXEXCFLRF", typeof( Double ) ) ); // 売上単価（税抜，浮動）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.COSTRATERF", typeof( Double ) ) ); // 原価率
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESUNITCOSTRF", typeof( Double ) ) ); // 原価単価
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTBLGOODSCODERF", typeof( Int32 ) ) ); // BL商品コード（印刷）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTBLGOODSNAMERF", typeof( String ) ) ); // BL商品コード名称（印刷）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.WORKMANHOURRF", typeof( Double ) ) ); // 作業工数
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SHIPMENTCNTRF", typeof( Double ) ) ); // 出荷数
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESMONEYTAXINCRF", typeof( Int64 ) ) ); // 売上金額（税込み）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESMONEYTAXEXCRF", typeof( Int64 ) ) ); // 売上金額（税抜き）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.COSTRF", typeof( Int64 ) ) ); // 原価
            table.Columns.Add( new DataColumn( "SALESDETAILRF.TAXATIONDIVCDRF", typeof( Int32 ) ) ); // 課税区分
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PARTYSLIPNUMDTLRF", typeof( String ) ) ); // 相手先伝票番号（明細）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.DTLNOTERF", typeof( String ) ) ); // 明細備考
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SUPPLIERCDRF", typeof( Int32 ) ) ); // 仕入先コード
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SUPPLIERSNMRF", typeof( String ) ) ); // 仕入先略称
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SLIPMEMO1RF", typeof( String ) ) ); // 伝票メモ１
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SLIPMEMO2RF", typeof( String ) ) ); // 伝票メモ２
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SLIPMEMO3RF", typeof( String ) ) ); // 伝票メモ３
            table.Columns.Add( new DataColumn( "SALESDETAILRF.INSIDEMEMO1RF", typeof( String ) ) ); // 社内メモ１
            table.Columns.Add( new DataColumn( "SALESDETAILRF.INSIDEMEMO2RF", typeof( String ) ) ); // 社内メモ２
            table.Columns.Add( new DataColumn( "SALESDETAILRF.INSIDEMEMO3RF", typeof( String ) ) ); // 社内メモ３
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BFLISTPRICERF", typeof( Double ) ) ); // 変更前定価
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BFSALESUNITPRICERF", typeof( Double ) ) ); // 変更前売価
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BFUNITCOSTRF", typeof( Double ) ) ); // 変更前原価
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSALESROWNORF", typeof( Int32 ) ) ); // 一式明細番号
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTGOODSMAKERCDRF", typeof( Int32 ) ) ); // メーカーコード（一式）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTMAKERNAMERF", typeof( String ) ) ); // メーカー名称（一式）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTGOODSNAMERF", typeof( String ) ) ); // 商品名称（一式）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSHIPMENTCNTRF", typeof( Double ) ) ); // 数量（一式）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSALESUNPRCFLRF", typeof( Double ) ) ); // 売上単価（一式）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSALESMONEYRF", typeof( Int64 ) ) ); // 売上金額（一式）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSALESUNITCOSTRF", typeof( Double ) ) ); // 原価単価（一式）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTCOSTRF", typeof( Int64 ) ) ); // 原価金額（一式）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTPARTYSALSLNUMRF", typeof( String ) ) ); // 相手先伝票番号（一式）
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTNOTERF", typeof( String ) ) ); // 一式備考
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.CARMNGNORF", typeof( Int32 ) ) ); // 車両管理番号
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.CARMNGCODERF", typeof( String ) ) ); // 車輌管理コード
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE1CODERF", typeof( Int32 ) ) ); // 陸運事務所番号
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE1NAMERF", typeof( String ) ) ); // 陸運事務局名称
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE2RF", typeof( String ) ) ); // 車両登録番号（種別）
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE3RF", typeof( String ) ) ); // 車両登録番号（カナ）
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE4RF", typeof( Int32 ) ) ); // 車両登録番号（プレート番号）
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.FIRSTENTRYDATERF", typeof( Int32 ) ) ); // 初年度
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MAKERCODERF", typeof( Int32 ) ) ); // メーカーコード
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MAKERFULLNAMERF", typeof( String ) ) ); // メーカー全角名称
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELCODERF", typeof( Int32 ) ) ); // 車種コード
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELSUBCODERF", typeof( Int32 ) ) ); // 車種サブコード
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELFULLNAMERF", typeof( String ) ) ); // 車種全角名称
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.EXHAUSTGASSIGNRF", typeof( String ) ) ); // 排ガス記号
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.SERIESMODELRF", typeof( String ) ) ); // シリーズ型式
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.CATEGORYSIGNMODELRF", typeof( String ) ) ); // 型式（類別記号）
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.FULLMODELRF", typeof( String ) ) ); // 型式（フル型）
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELDESIGNATIONNORF", typeof( Int32 ) ) ); // 型式指定番号
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.CATEGORYNORF", typeof( Int32 ) ) ); // 類別番号
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.FRAMEMODELRF", typeof( String ) ) ); // 車台型式
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.FRAMENORF", typeof( String ) ) ); // 車台番号
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.SEARCHFRAMENORF", typeof( Int32 ) ) ); // 車台番号（検索用）
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.ENGINEMODELNMRF", typeof( String ) ) ); // エンジン型式名称
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.RELEVANCEMODELRF", typeof( String ) ) ); // 関連型式
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.SUBCARNMCDRF", typeof( Int32 ) ) ); // サブ車名コード
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELGRADESNAMERF", typeof( String ) ) ); // 型式グレード略称
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.COLORCODERF", typeof( String ) ) ); // カラーコード
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.COLORNAME1RF", typeof( String ) ) ); // カラー名称1
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.TRIMCODERF", typeof( String ) ) ); // トリムコード
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.TRIMNAMERF", typeof( String ) ) ); // トリム名称
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MILEAGERF", typeof( Int32 ) ) ); // 車両走行距離
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.ACPTANODRSTATUSRF", typeof( Int32 ) ) ); // 受注ステータス
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DEPOSITSLIPNORF", typeof( Int32 ) ) ); // 入金伝票番号
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.SALESSLIPNUMRF", typeof( String ) ) ); // 売上伝票番号
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.ADDUPSECCODERF", typeof( String ) ) ); // 計上拠点コード
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.SUBSECTIONCODERF", typeof( Int32 ) ) ); // 部門コード
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DEPOSITDATERF", typeof( Int32 ) ) ); // 入金日付
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.ADDUPADATERF", typeof( Int32 ) ) ); // 計上日付
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DEPOSITRF", typeof( Int64 ) ) ); // 入金金額
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.FEEDEPOSITRF", typeof( Int64 ) ) ); // 手数料入金額
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DISCOUNTDEPOSITRF", typeof( Int64 ) ) ); // 値引入金額
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.AUTODEPOSITCDRF", typeof( Int32 ) ) ); // 自動入金区分
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DEPOSITCDRF", typeof( Int32 ) ) ); // 預り金区分
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DRAFTDRAWINGDATERF", typeof( Int32 ) ) ); // 手形振出日
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DRAFTKINDRF", typeof( Int32 ) ) ); // 手形種類
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DRAFTKINDNAMERF", typeof( String ) ) ); // 手形種類名称
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DRAFTDIVIDENAMERF", typeof( String ) ) ); // 手形区分名称
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DRAFTNORF", typeof( String ) ) ); // 手形番号
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.CUSTOMERCODERF", typeof( Int32 ) ) ); // 得意先コード
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.CLAIMCODERF", typeof( Int32 ) ) ); // 請求先コード
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.OUTLINERF", typeof( String ) ) ); // 伝票摘要
            table.Columns.Add( new DataColumn( "SUBDEP.SUBSECTIONNAMERF", typeof( String ) ) ); // 入金請求部門名称
            table.Columns.Add( new DataColumn( "DEPSITDTLRF.DEPOSITSLIPNORF", typeof( Int32 ) ) ); // 入金伝票番号
            table.Columns.Add( new DataColumn( "DEPSITDTLRF.DEPOSITROWNORF", typeof( Int32 ) ) ); // 入金行番号
            table.Columns.Add( new DataColumn( "DEPSITDTLRF.MONEYKINDCODERF", typeof( Int32 ) ) ); // 金種コード
            table.Columns.Add( new DataColumn( "DEPSITDTLRF.MONEYKINDNAMERF", typeof( String ) ) ); // 金種名称
            table.Columns.Add( new DataColumn( "DEPSITDTLRF.MONEYKINDDIVRF", typeof( Int32 ) ) ); // 金種区分
            table.Columns.Add( new DataColumn( "DEPSITDTLRF.DEPOSITRF", typeof( Int64 ) ) ); // 入金金額
            table.Columns.Add( new DataColumn( "DEPSITDTLRF.VALIDITYTERMRF", typeof( Int32 ) ) ); // 有効期限
            table.Columns.Add( new DataColumn( "DADD.ACPTANODRSTATUSRF", typeof( Int32 ) ) ); // 受注ステータス名称
            table.Columns.Add( new DataColumn( "DADD.DEBITNOTEDIVRF", typeof( Int32 ) ) ); // 赤伝区分名称
            table.Columns.Add( new DataColumn( "DADD.SALESSLIPCDRF", typeof( Int32 ) ) ); // 売上伝票区分名称
            table.Columns.Add( new DataColumn( "DADD.SALESDATERF", typeof( Int32 ) ) ); // 売上日付
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFYRF", typeof( Int32 ) ) ); // 売上日付西暦年
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFSRF", typeof( Int32 ) ) ); // 売上日付西暦年略
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFWRF", typeof( Int32 ) ) ); // 売上日付和暦年
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFMRF", typeof( Int32 ) ) ); // 売上日付月
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFDRF", typeof( Int32 ) ) ); // 売上日付日
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFGRF", typeof( String ) ) ); // 売上日付元号
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFRRF", typeof( String ) ) ); // 売上日付略号
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFLSRF", typeof( String ) ) ); // 売上日付リテラル(/)
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFLPRF", typeof( String ) ) ); // 売上日付リテラル(.)
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFLYRF", typeof( String ) ) ); // 売上日付リテラル(年)
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFLMRF", typeof( String ) ) ); // 売上日付リテラル(月)
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFLDRF", typeof( String ) ) ); // 売上日付リテラル(日)
            table.Columns.Add( new DataColumn( "DADD.STOCKGOODSTTLTAXEXCRF", typeof( Int64 ) ) ); // 取寄商品合計金額（税抜）
            table.Columns.Add( new DataColumn( "DADD.PUREGOODSTTLTAXEXCRF", typeof( Int64 ) ) ); // 優良商品合計金額（税抜）
            table.Columns.Add( new DataColumn( "DADD.GOODSKINDCODERF", typeof( Int32 ) ) ); // 商品属性名称
            table.Columns.Add( new DataColumn( "DADD.SALESORDERDIVCDRF", typeof( Int32 ) ) ); // 売上在庫取寄せ区分名称
            table.Columns.Add( new DataColumn( "DADD.OPENPRICEDIVRF", typeof( Int32 ) ) ); // オープン価格区分名称
            table.Columns.Add( new DataColumn( "DADD.TAXATIONDIVCDRF", typeof( Int32 ) ) ); // 課税区分名称
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFYRF", typeof( Int32 ) ) ); // 初年度西暦年
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFSRF", typeof( Int32 ) ) ); // 初年度西暦年略
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFWRF", typeof( Int32 ) ) ); // 初年度和暦年
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFMRF", typeof( Int32 ) ) ); // 初年度月
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFGRF", typeof( String ) ) ); // 初年度元号
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFRRF", typeof( String ) ) ); // 初年度略号
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFLSRF", typeof( String ) ) ); // 初年度リテラル(/)
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFLPRF", typeof( String ) ) ); // 初年度リテラル(.)
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFLYRF", typeof( String ) ) ); // 初年度リテラル(年)
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFLMRF", typeof( String ) ) ); // 初年度リテラル(月)
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFYRF", typeof( Int32 ) ) ); // 入金日付西暦年
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFSRF", typeof( Int32 ) ) ); // 入金日付西暦年略
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFWRF", typeof( Int32 ) ) ); // 入金日付和暦年
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFMRF", typeof( Int32 ) ) ); // 入金日付月
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFDRF", typeof( Int32 ) ) ); // 入金日付日
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFGRF", typeof( String ) ) ); // 入金日付元号
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFRRF", typeof( String ) ) ); // 入金日付略号
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFLSRF", typeof( String ) ) ); // 入金日付リテラル(/)
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFLPRF", typeof( String ) ) ); // 入金日付リテラル(.)
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFLYRF", typeof( String ) ) ); // 入金日付リテラル(年)
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFLMRF", typeof( String ) ) ); // 入金日付リテラル(月)
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFLDRF", typeof( String ) ) ); // 入金日付リテラル(日)
            table.Columns.Add( new DataColumn( "DADD.AUTODEPOSITCDRF", typeof( Int32 ) ) ); // 自動入金区分名称
            table.Columns.Add( new DataColumn( "DADD.DEPOSITCDRF", typeof( Int32 ) ) ); // 預り金区分名称
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFYRF", typeof( Int32 ) ) ); // 手形振出日西暦年
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFSRF", typeof( Int32 ) ) ); // 手形振出日西暦年略
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFWRF", typeof( Int32 ) ) ); // 手形振出日和暦年
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFMRF", typeof( Int32 ) ) ); // 手形振出日月
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFDRF", typeof( Int32 ) ) ); // 手形振出日日
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFGRF", typeof( String ) ) ); // 手形振出日元号
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFRRF", typeof( String ) ) ); // 手形振出日略号
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFLSRF", typeof( String ) ) ); // 手形振出日リテラル(/)
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFLPRF", typeof( String ) ) ); // 手形振出日リテラル(.)
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFLYRF", typeof( String ) ) ); // 手形振出日リテラル(年)
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFLMRF", typeof( String ) ) ); // 手形振出日リテラル(月)
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFLDRF", typeof( String ) ) ); // 手形振出日リテラル(日)
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFYRF", typeof( Int32 ) ) ); // 手形支払期日西暦年
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFSRF", typeof( Int32 ) ) ); // 手形支払期日西暦年略
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFWRF", typeof( Int32 ) ) ); // 手形支払期日和暦年
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFMRF", typeof( Int32 ) ) ); // 手形支払期日月
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFDRF", typeof( Int32 ) ) ); // 手形支払期日日
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFGRF", typeof( String ) ) ); // 手形支払期日元号
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFRRF", typeof( String ) ) ); // 手形支払期日略号
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFLSRF", typeof( String ) ) ); // 手形支払期日リテラル(/)
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFLPRF", typeof( String ) ) ); // 手形支払期日リテラル(.)
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFLYRF", typeof( String ) ) ); // 手形支払期日リテラル(年)
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFLMRF", typeof( String ) ) ); // 手形支払期日リテラル(月)
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFLDRF", typeof( String ) ) ); // 手形支払期日リテラル(日)
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFYRF", typeof( Int32 ) ) ); // 有効期限西暦年
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFSRF", typeof( Int32 ) ) ); // 有効期限西暦年略
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFWRF", typeof( Int32 ) ) ); // 有効期限和暦年
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFMRF", typeof( Int32 ) ) ); // 有効期限月
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFDRF", typeof( Int32 ) ) ); // 有効期限日
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFGRF", typeof( String ) ) ); // 有効期限元号
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFRRF", typeof( String ) ) ); // 有効期限略号
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFLSRF", typeof( String ) ) ); // 有効期限リテラル(/)
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFLPRF", typeof( String ) ) ); // 有効期限リテラル(.)
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFLYRF", typeof( String ) ) ); // 有効期限リテラル(年)
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFLMRF", typeof( String ) ) ); // 有効期限リテラル(月)
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFLDRF", typeof( String ) ) ); // 有効期限リテラル(日)
            table.Columns.Add( new DataColumn( "DADD.DMDDTLOUTLINERF", typeof( String ) ) ); // 請求明細摘要
            table.Columns.Add( new DataColumn( "DADD.SALESFTTITLERF", typeof( String ) ) ); // 売上伝票計タイトル
            table.Columns.Add( new DataColumn( "DADD.SALESFTPRICERF", typeof( Int64 ) ) ); // 売上伝票計金額
            table.Columns.Add( new DataColumn( "DADD.SALESFTNOTE1RF", typeof( String ) ) ); // 売上伝票計備考１
            table.Columns.Add( new DataColumn( "DADD.SALESFTNOTE2RF", typeof( String ) ) ); // 売上伝票計備考２
            table.Columns.Add( new DataColumn( "DADD.SALESFTNOTE3RF", typeof( String ) ) ); // 売上伝票計備考３
            table.Columns.Add( new DataColumn( "DSAL.DETAILTITLERF", typeof( String ) ) ); // 明細伝票タイトル(売上/返品)
            table.Columns.Add( new DataColumn( "DSAL.DETAILSUMTITLERF", typeof( String ) ) ); // 売上集計タイトル
            table.Columns.Add( new DataColumn( "DSAL.DETAILSUMPRICERF", typeof( Int64 ) ) ); // 売上集計金額
            table.Columns.Add( new DataColumn( "DDEP.DETAILTITLERF", typeof( String ) ) ); // 明細伝票タイトル(入金)
            table.Columns.Add( new DataColumn( "DDEP.DETAILSUMTITLERF", typeof( String ) ) ); // 入金集計タイトル
            table.Columns.Add( new DataColumn( "DDEP.DETAILSUMPRICERF", typeof( Int64 ) ) ); // 入金集計金額
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSNAMEKANARF", typeof( String ) ) ); // 商品名称カナ
            table.Columns.Add( new DataColumn( "SALESDETAILRF.MAKERKANANAMERF", typeof( String ) ) ); // メーカーカナ名称
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELHALFNAMERF", typeof( String ) ) ); // 車種半角名称
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTGOODSNORF", typeof( String ) ) ); // 印刷用品番
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTMAKERCODERF", typeof( Int32 ) ) ); // 印刷用メーカーコード
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTMAKERNAMERF", typeof( String ) ) ); // 印刷用メーカー名称
            table.Columns.Add( new DataColumn( "DADD.PARTYSALESLIPNUMRF", typeof( String ) ) ); // 相手先伝票番号（ヘッダ用）
            table.Columns.Add( new DataColumn( ct_col_DDep_MoneyKindNameSp, typeof( String ) ) ); // 金種名称(ｽﾍﾟｰｽ制御)
            table.Columns.Add(new DataColumn("DADD.CARMNGCODETITLERF", typeof(String))); //プレート番号タイトル

            table.Columns.Add(new DataColumn("DADD.SLIPTTLTAXRF", typeof(Int64))); // 伝票合計消費税
            table.Columns.Add(new DataColumn("DADD.SLIPTTLTAXTITLERF", typeof(String))); // 伝票合計消費税リテラル

            table.Columns.Add(new DataColumn("DADD.FULLMODELRF", typeof(String)));//(先頭)型式(フル型)
            table.Columns.Add(new DataColumn("DADD.MODELHALFNAMEDTL2RF", typeof(String))); // (先頭)車種名(２行目)
            table.Columns.Add(new DataColumn("DADD.SALESFT2NOTERF", typeof(String))); // 売上伝票計備考(売上フッタ２)
            table.Columns.Add(new DataColumn("DADD.SALESFT2TITLERF", typeof(String))); // 売上伝票計タイトル(売上フッタ２)
            table.Columns.Add(new DataColumn("DADD.SALESFT2PRICERF", typeof(String))); // 売上伝票計金額(売上フッタ２)

            table.Columns.Add(new DataColumn("DADD.SALESFT3NOTERF", typeof(String))); //売上伝票計備考(売上フッタ３)
            table.Columns.Add(new DataColumn("DADD.SALESFT3TITLERF", typeof(String))); //売上伝票計(売上フッタ３)
            table.Columns.Add(new DataColumn("DADD.SALESFT3PRICERF", typeof(Int64))); //売上伝票計金額(売上フッタ３)
            table.Columns.Add(new DataColumn("DADD.FULLMODELHD2RF",typeof(string))); //型式(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.MODELHALFNAMEHD2RF",typeof(String))); //車種名(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.SALESSLIPCDCHANGERF",typeof(Int32))); //売上伝票区分(変換用.売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.MONEYKINDCODEOTHERRF", typeof(Int32))); //入金コード(その他に含む)
            table.Columns.Add(new DataColumn("DADD.DEPOSITOTHERRF", typeof(Int32))); //入金金額(その他に含む)
            table.Columns.Add(new DataColumn("DADD.SALESSLIPNUMHD2RF", typeof(Int32))); //売上伝票番号(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FMRF", typeof(Int32))); //売上日付月(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FDRF", typeof(Int32))); //売上日付日(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FLPRF", typeof(String))); //売上日付リテラル(.)(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2RF", typeof(Int32))); //売上日付(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FYRF", typeof(Int32))); //売上日付西暦年(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FSRF", typeof(Int32))); //売上日付西暦年略(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FWRF", typeof(Int32))); //売上日付和暦年(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FGRF", typeof(String))); // 売上日付元号(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FRRF", typeof(String))); // 売上日付略号(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FLSRF", typeof(String))); // 売上日付リテラル(/)(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FLYRF", typeof(String))); // 売上日付リテラル(年)(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FLMRF", typeof(String))); // 売上日付リテラル(月)(売上ヘッダ２)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FLDRF", typeof(String))); // 売上日付リテラル(日)(売上ヘッダ２)
            //検索用
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFMRF", typeof(object))); //売上日付月(検索用)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFDRF", typeof(object))); //売上日付日(売上検索用２)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFLPRF", typeof(object))); //売上日付リテラル(.)(検索用)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHRF", typeof(object))); //売上日付(検索用)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFYRF", typeof(object))); //売上日付西暦年(検索用)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFSRF", typeof(object))); //売上日付西暦年略(検索用)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFWRF", typeof(object))); //売上日付和暦年(検索用)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFGRF", typeof(object))); // 売上日付元号(検索用)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFRRF", typeof(object))); // 売上日付略号(検索用)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFLSRF", typeof(object))); // 売上日付リテラル(/)(検索用)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFLYRF", typeof(object))); // 売上日付リテラル(年)(検索用)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFLMRF", typeof(object))); // 売上日付リテラル(月)(検索用)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFLDRF", typeof(object))); // 売上日付リテラル(日)(検索用)
            table.Columns.Add(new DataColumn("DADD.FULLMODELHD2SEARCHRF", typeof(object))); // 型式(検索用)
            table.Columns.Add(new DataColumn("DADD.MODELHALFNAMEHD2SEARCHRF", typeof(object))); // 車種(検索用)
            table.Columns.Add(new DataColumn("DADD.SALESSLIPCDCHANGESEARCHRF", typeof(object))); // 売上伝票区分(変換用.検索用)
            table.Columns.Add(new DataColumn("DADD.FOOTER3PRINTRF", typeof(Int32))); //売上フッタ（明細行判定用）
            table.Columns.Add(new DataColumn("DADD.FULLMODELORMODELHALFNAMERF", typeof(object))); // 型式ｏｒ車種名

            table.Columns.Add(new DataColumn("DADD.MODELHALFNAMEDTL3RF", typeof(String))); // (先頭)車種名(２行目)２
            table.Columns.Add(new DataColumn("DADD.SALESFT2TITLE2RF", typeof(String))); // 売上伝票計タイトル(売上フッタ２)２
            table.Columns.Add(new DataColumn("DADD.SALESFT2PRICE2RF", typeof(String))); // 売上伝票計金額(売上フッタ２)２
            table.Columns.Add(new DataColumn("DADD.DEPOSITFTTITLERF", typeof(String))); // 入金計タイトル
            table.Columns.Add(new DataColumn("DADD.DTLTITLERF", typeof(String))); // 備考タイトル
            table.Columns.Add(new DataColumn("DADD.CARMNGNO2RF", typeof(String))); // 備考タイトル
            table.Columns.Add(new DataColumn("DADD.CARMNGCODETITLE2RF", typeof(String))); // 備考タイトル
            table.Columns.Add(new DataColumn("HADD.COMPANYNAMEJOIN12RF", typeof(String))); // 自社名１＋自社名２
            table.Columns.Add(new DataColumn("DADD.DETAILBLANKLINERF", typeof(String))); // 明細フッタ空行
            table.Columns.Add(new DataColumn("DADD.ADDTAXLINERF", typeof(String))); // 消費税行追加
            table.Columns.Add(new DataColumn("DADD.HEADFULLMODEL2RF", typeof(String))); // （先頭）型式（売上フッタ２）
            table.Columns.Add(new DataColumn("DADD.MODELHALFNAME2RF", typeof(String))); // （先頭）車種半角名称２
            table.Columns.Add(new DataColumn("DADD.SALESMONEYALLDETAILTTLRF", typeof(Int64))); // 売上金額明細合計
            # endregion

            # region [スキーマ定義（制御情報）]
            table.Columns.Add( new DataColumn( ct_col_InpageCount, typeof( Int32 ) ) ); // 同一ページ内コピーカウント
            table.Columns.Add( new DataColumn( ct_col_PageCount, typeof( Int32 ) ) ); // 頁数
            table.Columns.Add( new DataColumn( ct_col_TaxTitle, typeof( string ) ) ); // 消費税タイトル
            table.Columns.Add(new DataColumn(ct_col_OfsThisSalesTaxIncTtl, typeof( string ) ) ); // 相殺後売上合計金額(税込)タイトル
            // 末日対応
            table.Columns.Add( new DataColumn( ct_col_Last_AddUpDate, typeof( string ) ) ); // 計上年月日(末日)
            table.Columns.Add( new DataColumn( ct_col_Last_StartCAddUpUpdDate, typeof( string ) ) ); // 締次更新開始年月日(末日)
            table.Columns.Add( new DataColumn( ct_col_Last_BillPrintDate, typeof( string ) ) ); // 請求書発行日(末日)
            table.Columns.Add( new DataColumn( ct_col_Last_ExpectedDepositDate, typeof( string ) ) ); // 入金予定日(末日)
            table.Columns.Add( new DataColumn( ct_col_Last_IssueDay, typeof( string ) ) ); // 入力発行日付(末日)
            table.Columns.Add( new DataColumn( ct_col_Last_CollectMoneyDay, typeof( string ) ) ); // 集金日(末日)
            // ソート/合計対応
            table.Columns.Add( new DataColumn( ct_col_Sort_CustomerCode, typeof( Int32 ) ) ); // (ソート用)得意先コード
            table.Columns.Add( new DataColumn( ct_col_Sort_Date, typeof( Int32 ) ) ); // (ソート用)日付
            table.Columns.Add( new DataColumn( ct_col_Sort_RecordDiv, typeof( Int32 ) ) ); // (ソート用)レコード区分
            table.Columns.Add( new DataColumn( ct_col_Sort_SalesSlipNo, typeof( string ) ) ); // (ソート用)売上伝票番号
            table.Columns.Add( new DataColumn( ct_col_Sort_DepositSlipNo, typeof( Int32 ) ) ); // (ソート用)入金伝票番号
            table.Columns.Add( new DataColumn( ct_col_Sort_DetailDiv, typeof( Int32 ) ) ); // (ソート用)明細区分
            table.Columns.Add( new DataColumn( ct_col_Sort_DetailRowNo, typeof( Int32 ) ) ); // (ソート用)明細行番号
            table.Columns.Add( new DataColumn( ct_col_Sort_RecordDiv_EmptyDetail, typeof( Int32 ) ) );// (ソート用)レコード区分(空行最後)
            // その他
            table.Columns.Add( new DataColumn( ct_col_DDep_DepFtOutLine, typeof( string ) ) ); // (印刷用)入金集計フッタ伝票摘要
            table.Columns.Add( new DataColumn( ct_col_HDmd_LastTimeDemandOrg, typeof( string ) ) ); // (印刷用)前回請求金額(前回のみ)
            table.Columns.Add( new DataColumn( ct_col_DAdd_DmdDtlOutLineRF_ListPrice, typeof( Double ) ) ); // (印刷用)請求明細摘要(定価)
            # endregion
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            # region [軽減税率対応]
            table.Columns.Add(new DataColumn("TAX.DTLTAXRATERF", typeof(String)));                    // 消費税税率(整数)[明細]

            table.Columns.Add(new DataColumn("TAX.DTLTOTALCONSTAXRATETITLERF", typeof(String)));      // 税率別合計タイトル[明細]
            table.Columns.Add(new DataColumn("TAX.DTLTOTALSALESMONEYTAXEXCRF", typeof(String)));      // 税率別合計金額[明細]
            table.Columns.Add(new DataColumn("TAX.DTLTAXRATE1RF", typeof(String)));                   // 税率１[明細]
            table.Columns.Add(new DataColumn("TAX.DTLTAXRATE1SALESTAXEXCRF", typeof(String)));        // 税率１(税抜き)[明細]
            table.Columns.Add(new DataColumn("TAX.DTLTAXRATE1SALESTAXRF", typeof(String)));           // 税率１消費税[明細]
            table.Columns.Add(new DataColumn("TAX.DTLTAXRATE2RF", typeof(String)));                   // 税率２[明細]
            table.Columns.Add(new DataColumn("TAX.DTLTAXRATE2SALESTAXEXCRF", typeof(String)));        // 税率２(税抜き)[明細]
            table.Columns.Add(new DataColumn("TAX.DTLTAXRATE2SALESTAXRF", typeof(String)));           // 税率２消費税[明細]
            table.Columns.Add(new DataColumn("TAX.DTLOTHERTAXRATERF", typeof(String)));               // その他税率[明細]
            table.Columns.Add(new DataColumn("TAX.DTLOTHERTAXRATESALESTAXEXCRF", typeof(String)));    // その他税率(税抜き)[明細]
            table.Columns.Add(new DataColumn("TAX.DTLOTHERTAXRATESALESTAXRF", typeof(String)));       // その他税率消費税[明細]
            table.Columns.Add(new DataColumn("TAX.DTLTAXTITLERF", typeof(String)));                   // 税率別税率タイトル[明細]

            table.Columns.Add(new DataColumn("TAX.HFTOTALCONSTAXRATETITLERF", typeof(String)));       // 税率別合計タイトル[ヘッダ、フッタ]
            table.Columns.Add(new DataColumn("TAX.HFTOTALSALESMONEYTAXEXCRF", typeof(String)));       // 税率別合計金額[ヘッダ、フッタ]
            table.Columns.Add(new DataColumn("TAX.HFTAXRATE1RF", typeof(String)));                    // 税率１[ヘッダ、フッタ]
            table.Columns.Add(new DataColumn("TAX.HFTAXRATE1SALESTAXEXCRF", typeof(String)));         // 税率１(税抜き)[ヘッダ、フッタ]
            table.Columns.Add(new DataColumn("TAX.HFTAXRATE1SALESTAXRF", typeof(String)));            // 税率１消費税[ヘッダ、フッタ]
            table.Columns.Add(new DataColumn("TAX.HFTAXRATE2RF", typeof(String)));                    // 税率２[ヘッダ、フッタ]
            table.Columns.Add(new DataColumn("TAX.HFTAXRATE2SALESTAXEXCRF", typeof(String)));         // 税率２(税抜き)[ヘッダ、フッタ]
            table.Columns.Add(new DataColumn("TAX.HFTAXRATE2SALESTAXRF", typeof(String)));            // 税率２消費税[ヘッダ、フッタ]
            table.Columns.Add(new DataColumn("TAX.HFOTHERTAXRATERF", typeof(String)));                // その他税率[ヘッダ、フッタ]
            table.Columns.Add(new DataColumn("TAX.HFOTHERTAXRATESALESTAXEXCRF", typeof(String)));     // その他税率(税抜き)[ヘッダ、フッタ]
            table.Columns.Add(new DataColumn("TAX.HFOTHERTAXRATESALESTAXRF", typeof(String)));        // その他税率消費税[ヘッダ、フッタ]
            table.Columns.Add(new DataColumn("TAX.HFTAXTITLERF", typeof(String)));                    // 税率別税率タイトル[ヘッダ、フッタ]
            table.Columns.Add(new DataColumn("TAX.DTLTAXOUTITLERF", typeof(String)));                 // 非課税タイトル[明細]
            table.Columns.Add(new DataColumn("TAX.DTLTAXOUTSALESTAXEXCRF", typeof(String)));          // 非課税売上金額(税抜き)[明細]

            table.Columns.Add(new DataColumn("TAX.HFTAXOUTITLERF", typeof(String)));                  // 非課税タイトル[ヘッダ、フッタ]
            table.Columns.Add(new DataColumn("TAX.HFTAXOUTSALESTAXEXCRF", typeof(String)));           // 非課税金額売上金額(税抜き)[ヘッダ、フッタ]
            #endregion
            // --- ADD END   田村顕成 2022/10/18 -----<<<<<
            // --- ADD START 3H 仰亮亮 2023/04/14 ----------------------------------->>>>>
            #region [①売上伝票計金額(税込み) ②消費税(伝票転嫁)/売上伝票計金額(税込み) 追加]
            table.Columns.Add(new DataColumn("DADD.SALESMONEYTAXINCRF", typeof(string)));          // 売上伝票計金額(税込み)
            table.Columns.Add(new DataColumn("DADD.TAXRFANDSALESMONEYTAXINCRF", typeof(string))); // 消費税(伝票転嫁)/売上伝票計金額(税込み)
            #endregion
            // --- ADD END 3H 仰亮亮 2023/04/14  -------------------------------------<<<<<
            return table;
        }
        # endregion

        # region [データ移行（印刷データ）]
        /// <summary>
        /// データ移行（印刷データ　１請求書単位）
        /// </summary>
        /// <param name="targetTable">データテーブル</param>
        /// <param name="jyoken">印刷情報</param>
        /// <param name="sourceRow">データRow</param>
        /// <param name="billDmdPrintParameter">印刷条件</param>
        /// <remarks>
        /// <br>Note        : データ移行（印刷データ　１請求書単位）</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note :  2022/10/18  田村顕成</br>                               // 
        /// <br>管理番号    :  11870141-00 インボイス残対応（軽減税率対応）</br>       //
        /// </remarks>
        public static void CopyToPrintDataTable( ref DataTable targetTable, object jyoken, DataRow sourceRow, BillDmdPrintParameter billDmdPrintParameter )
        {

            EBooksFrePBillHeadWork headWork;
            List<EBooksFrePBillDetailWork> salesList;
            List<EBooksFrePBillDetailWork> depositList;
            DmdPrtPtnWork dmdPrtPtnWork;
            FrePrtPSetWork frePrtPSetWork;
            BillAllStWork billAllStWork;
            BillPrtStWork billPrtStWork;
            AllDefSetWork allDefSetWork;
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            // 売上金額処理区分設定
            List<SalesProcMoneyWork> salesProcMoneyWorkList;

            // 売上金額処理区分設定
            if (sourceRow[PMKAU01002AB.CT_BillList_SalesProcMoneyWork] != DBNull.Value)
            {
                salesProcMoneyWorkList = (List<SalesProcMoneyWork>)sourceRow[PMKAU01002AB.CT_BillList_SalesProcMoneyWork];
            }
            else
            {
                salesProcMoneyWorkList = new List<SalesProcMoneyWork>();
            }
            // --- ADD END   田村顕成 2022/10/18 -----<<<<<

            // 請求書ヘッダ
            if ( sourceRow[PMKAU01002AB.CT_BillList_FrePBillHead] != DBNull.Value )
            {
                headWork = (EBooksFrePBillHeadWork)sourceRow[PMKAU01002AB.CT_BillList_FrePBillHead];
            }
            else
            {
                headWork = new EBooksFrePBillHeadWork();
            }

            // 売上明細リスト
            if ( sourceRow[PMKAU01002AB.CT_BillList_FrePBillSalesList] != DBNull.Value )
            {
                salesList = (List<EBooksFrePBillDetailWork>)sourceRow[PMKAU01002AB.CT_BillList_FrePBillSalesList];
            }
            else
            {
                salesList = new List<EBooksFrePBillDetailWork>();
            }

            // 入金明細リスト
            if ( sourceRow[PMKAU01002AB.CT_BillList_FrePBillDepositList] != DBNull.Value )
            {
                depositList = (List<EBooksFrePBillDetailWork>)sourceRow[PMKAU01002AB.CT_BillList_FrePBillDepositList];
            }
            else
            {
                depositList = new List<EBooksFrePBillDetailWork>();
            }

            // 請求書印刷パターン
            if ( sourceRow[PMKAU01002AB.CT_BillList_DmdPrtPtn] != DBNull.Value )
            {
                dmdPrtPtnWork = (DmdPrtPtnWork)sourceRow[PMKAU01002AB.CT_BillList_DmdPrtPtn];
            }
            else
            {
                dmdPrtPtnWork = new DmdPrtPtnWork();
            }

            // 自由帳票印刷設定
            if ( sourceRow[PMKAU01002AB.CT_BillList_FrePrtPSet] != DBNull.Value )
            {
                frePrtPSetWork = (FrePrtPSetWork)sourceRow[PMKAU01002AB.CT_BillList_FrePrtPSet];
            }
            else
            {
                frePrtPSetWork = new FrePrtPSetWork();
            }

            // 請求全体設定
            if ( sourceRow[PMKAU01002AB.CT_BillList_BillAllSt] != DBNull.Value )
            {
                billAllStWork = (BillAllStWork)sourceRow[PMKAU01002AB.CT_BillList_BillAllSt];
            }
            else
            {
                billAllStWork = new BillAllStWork();
            }

            // 請求印刷設定
            if ( sourceRow[PMKAU01002AB.CT_BillList_BillPrtSt] != DBNull.Value )
            {
                billPrtStWork = (BillPrtStWork)sourceRow[PMKAU01002AB.CT_BillList_BillPrtSt];
            }
            else
            {
                billPrtStWork = new BillPrtStWork();
            }

            // 全体初期表示設定
            if ( sourceRow[PMKAU01002AB.CT_BillList_AllDefSet] != DBNull.Value)
            {
                allDefSetWork = (AllDefSetWork)sourceRow[PMKAU01002AB.CT_BillList_AllDefSet];
            }
            else
            {
                allDefSetWork = new AllDefSetWork();
            }


            // ＵＩ入力条件の取得
            if ( jyoken is ExtrInfo_EBooksDemandTotal )
            {
                if ( headWork != null )
                {
                    // 発行日をセット
                    headWork.HADD_ISSUEDAYRF = GetLongDate( (jyoken as ExtrInfo_EBooksDemandTotal).IssueDay );
                }
            }

            // コピー処理
            // --- DEL START 田村顕成 2022/10/18 ----->>>>>                        
            //CopyToPrintDataTable( ref targetTable, headWork, salesList, depositList, dmdPrtPtnWork, frePrtPSetWork, billAllStWork, billPrtStWork, billDmdPrintParameter, allDefSetWork );
            // --- DEL END 田村顕成 2022/10/18 -----<<<<<
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>            
            CopyToPrintDataTable(ref targetTable, headWork, salesList, depositList, dmdPrtPtnWork, frePrtPSetWork, billAllStWork, billPrtStWork, billDmdPrintParameter, allDefSetWork, salesProcMoneyWorkList);
            // --- ADD END   田村顕成 2022/10/18 -----<<<<<
        }
        /// <summary>
        /// 日付→数値変換
        /// </summary>
        /// <param name="dateTime">日付</param>
        /// <returns>数値日付</returns>
        /// <remarks>
        /// <br>Note        : 日付→数値変換</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int GetLongDate( DateTime dateTime )
        {
            if ( dateTime != DateTime.MinValue )
            {
                return (dateTime.Year * 10000) + (dateTime.Month * 100) + dateTime.Day;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// データ移行（印刷データ　１請求書単位）
        /// </summary>
        /// <param name="table">データテーブル</param>
        /// <param name="headWork">ヘッダワーク</param>
        /// <param name="salesList">売上リスト</param>
        /// <param name="depositList">入金リスト</param>
        /// <param name="dmdPrtPtnWork">請求書印刷パターン設定</param>
        /// <param name="frePrtPSetWork">自由帳票印字位置設定</param>
        /// <param name="billAllStWork">請求全体設定</param>
        /// <param name="billPrtStWork">請求印刷設定</param>
        /// <param name="billDmdPrintParameter">印刷条件</param>
        /// <param name="allDefSet">全体初期表示設定</param>
        /// /// <param name="salesProcMoneyWorkList">売上金額処理区分設定</param>
        /// <remarks>
        /// <br>Note        : データ移行（印刷データ　１請求書単位）</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note : 2022/10/18 田村顕成</br>
        /// <br>管理番号    : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// <br>Update Note : 2023/06/16 田村顕成</br>
        /// <br>管理番号    : 11900025-00 軽減税率不具合対応</br>
        /// </remarks>
        //public static void CopyToPrintDataTable( ref DataTable table, EBooksFrePBillHeadWork headWork, List<EBooksFrePBillDetailWork> salesList, List<EBooksFrePBillDetailWork> depositList, DmdPrtPtnWork dmdPrtPtnWork, FrePrtPSetWork frePrtPSetWork, BillAllStWork billAllStWork, BillPrtStWork billPrtStWork, BillDmdPrintParameter billDmdPrintParameter, AllDefSetWork allDefSet ) // --- DEL 田村顕成 2022/10/18
        public static void CopyToPrintDataTable(ref DataTable table, EBooksFrePBillHeadWork headWork, List<EBooksFrePBillDetailWork> salesList, List<EBooksFrePBillDetailWork> depositList, DmdPrtPtnWork dmdPrtPtnWork, FrePrtPSetWork frePrtPSetWork, BillAllStWork billAllStWork, BillPrtStWork billPrtStWork, BillDmdPrintParameter billDmdPrintParameter, AllDefSetWork allDefSet, List<SalesProcMoneyWork> salesProcMoneyWorkList) // --- ADD 田村顕成 2022/10/18
        {

            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS"); 

            bool printPrice = true;

            // ヘッダ部追加項目適用処理
            ReflectBillHeaderAddtionSet( ref headWork, dmdPrtPtnWork, frePrtPSetWork, billAllStWork, billPrtStWork, allDefSet );

            // クリア
            table.Rows.Clear();
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            // 税率別合計情報
            TaxRateSalesMoney TotalTaxRateSalesMoney = new TaxRateSalesMoney();
            // 消費税転嫁方式「請求子」の消費税
            Dictionary<Int32, TaxRateSalesMoney> dicCustomerCode = new Dictionary<Int32, TaxRateSalesMoney>();
            // 端数処理情報を取得
            if (stc_priceTaxCalculator == null)
            {
                stc_priceTaxCalculator = new PriceTaxCalculator();
            }
            stc_priceTaxCalculator.SalesProcMoneyWorkList = salesProcMoneyWorkList;

            Boolean bChgFlg;                        // 伝票番号変更有無フラグ
            Double lTaxRate1SalesMoneyEx      = 0;  // 税率１  合計金額
            Double lTaxRate1SalesPriceConsTax = 0;  // 税率１  消費税合計
            Double lTaxRate2SalesMoneyEx      = 0;  // 税率２  合計金額
            Double lTaxRate2SalesPriceConsTax = 0;  // 税率２  消費税合計
            Double lOtherSalesMoneyEx         = 0;  // その他  合計金額
            Double lOtherSalesPriceConsTax    = 0;  // その他  消費税合計
            Double lTaxRate1MeisaiTotalTax    = 0;  // 税率１  消費税転嫁方式：「明細転嫁」の消費税金額合計
            Double lTaxRate2MeisaiTotalTax    = 0;  // 税率２  消費税転嫁方式：「明細転嫁」の消費税金額合計
            Double lOtherMeisaiTotalTax       = 0;  // その他  消費税転嫁方式：「明細転嫁」の消費税金額合計
            Double lSalesMoneyEx              = 0;  // 売上金額（税抜き）集計 (商品課税区分「非課税以外」)
            Double lSalesMoneyExTaxOut = 0;  // 売上金額（税抜き）集計 (商品課税区分「非課税」)// ADD 2022/04/21 呉元嘯 PMKOBETSU-4208 非課税品番の金額不具合対応

            
            // XML設定ファイル情報を取得
            PMKAU01002AB.TaxRatePrintInfo taxRatePrintInfo = null;
            string errMsg = string.Empty;
            PMKAU01002AB.Deserialize(out taxRatePrintInfo, out errMsg);
            // 税率設定情報ファイルの印刷用税率
            double dTaxRate1 = 0;                   // 税率1
            double dTaxRate2 = 0;                   // 税率2
            double.TryParse(taxRatePrintInfo.TaxRate1,out dTaxRate1);
            double.TryParse(taxRatePrintInfo.TaxRate2,out dTaxRate2);            
            // --- ADD END   田村顕成 2022/10/18 -----<<<<<


                //********************************************************
                // 明細あり
                //********************************************************

# if DEBUG
                //salesList = new List<EBooksFrePBillDetailWork>();

                //EBooksFrePBillDetailWork dt;

                //for ( int count = 0; count < 50; count++ )
                //{
                //    dt = new EBooksFrePBillDetailWork();

                //    # region [テストデータ]
                //    dt.SALESDETAILRF_GOODSNORF = "22018a";
                //    dt.SALESDETAILRF_GOODSNAMERF = "ひんめい";
                //    dt.SALESSLIPRF_SALESDATERF = 20081001;
                //    dt.SALESDETAILRF_SALESMONEYTAXEXCRF = 1000;
                //    dt.SALESDETAILRF_SALESMONEYTAXINCRF = 1050;
                //    dt.SALESDETAILRF_SALESROWNORF = (count % 5) + 1;
                //    dt.SALESSLIPRF_SALESSLIPNUMRF = ((count / 5) + 1).ToString("000000000");
                //    dt.SALESSLIPRF_SALESSUBTOTALTAXEXCRF = 5000;
                //    dt.SALESSLIPRF_SLIPNOTERF = "備考備考";
                //    # endregion

                //    salesList.Add( dt );
                //}
# endif
                //--------------------------------------------------------
                // 金額ゼロ明細 削除
                //--------------------------------------------------------
                # region [金額ゼロ明細削除]
                List<EBooksFrePBillDetailWork> deleteList;
                // 売上明細削除(マスタ設定に従う)
                if (dmdPrtPtnWork.DtlPrcZeroPrtDiv == 1)
                {
                    deleteList = new List<EBooksFrePBillDetailWork>();
                    foreach (EBooksFrePBillDetailWork detail in salesList)
                    {
                        //注釈行以外
                        if (frePrtPSetWork.FreePrtPprSpPrpseCd == 60 && detail.SALESDETAILRF_SALESMONEYTAXEXCRF == 0 && detail.SALESDETAILRF_SALESSLIPCDDTLRF != 3)
                        {
                            // 明細請求書は明細単位で金額ゼロ判定
                            deleteList.Add(detail);
                        }
                        else if (frePrtPSetWork.FreePrtPprSpPrpseCd == 70 && detail.SALESSLIPRF_SALESSUBTOTALTAXINCRF == 0)
                        {
                            // 伝票合計請求書は伝票単位で金額ゼロ判定
                            deleteList.Add(detail);
                        }
                    }
                    foreach (EBooksFrePBillDetailWork deleteItem in deleteList)
                    {
                        salesList.Remove(deleteItem);
                    }
                }
                //入金明細削除(マスタ設定に従う)
                if (dmdPrtPtnWork.DtlPrcZeroPrtDiv == 1)
                {
                    deleteList = new List<EBooksFrePBillDetailWork>();
                    foreach (EBooksFrePBillDetailWork detail in depositList)
                    {
                        //入金合計がゼロの時は印字しない
                        if (GetDepositTotal(detail) == 0)
                        {
                            deleteList.Add(detail);
                        }
                    }
                    foreach (EBooksFrePBillDetailWork deleteItem in deleteList)
                    {
                        depositList.Remove(deleteItem);
                    }
                }

                #region[山西商会対応]
                //売上ヘッダ２の有無で処理を行うか判定
                if (billDmdPrintParameter.ExistsSalesHeader2)
                {
                    // その他に含まないが貼られている場合は処理を行わない
                    if (!ReportItemDic.ContainsKey("DADD.NOINCOTHERRF"))
                    {
                        //定義する
                        List<EBooksFrePBillDetailWork> deleteRowList = new List<EBooksFrePBillDetailWork>();
                        List<EBooksFrePBillDetailWork> depositList2 = new List<EBooksFrePBillDetailWork>();
                        EBooksFrePBillDetailWork otherDepositRowWork = null;
                        Int64 otherDepositPrice = 0;
                        bool otherRow = false;
                        bool printOther = false;
                        Int64 feeDeposit = 0;

                        //forで処理を行う
                        for (int index = 0; index < depositList.Count; index++)
                        {
                            //伝票番号が変わっている場合
                            # region [伝票番号が変わっている場合]
                            if (index > 0 && depositList[index - 1].DEPSITMAINRF_DEPOSITSLIPNORF != depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF)
                            {
                                //その他があった場合
                                if (depositList.Count > 0 && otherRow)
                                {
                                    //ファクタリング＋口座振替＋手数料の金額を追加
                                    otherDepositRowWork.DEPSITDTLRF_DEPOSITRF += otherDepositPrice + feeDeposit;
                                    depositList2.Add(otherDepositRowWork);
                                }
                                else if (depositList.Count > 0 && printOther)
                                {
                                    //その他がない場合は追加する
                                    depositList2.Add( AddOtherDeposit( depositList[index - 1], otherDepositPrice + feeDeposit ) );
                                }

                                // 初期化
                                otherDepositRowWork = null;
                                otherDepositPrice = 0;
                                feeDeposit = 0;
                                otherRow = false;
                                printOther = false;
                            }
                            # endregion

                            # region ["その他"入金行の退避]
                            //その他の行があるか確認
                            if (depositList[index].DEPSITDTLRF_MONEYKINDCODERF == 58)
                            {
                                //その他の行だったらtrue
                                otherRow = true;
                                //現在の行を退避
                                otherDepositRowWork = depositList[index];
                            }
                            //ファクタリング・口座振替の場合
                            else if ( depositList[index].DEPSITDTLRF_MONEYKINDCODERF == 59 || depositList[index].DEPSITDTLRF_MONEYKINDCODERF == 60 )
                            {
                                //その他の金額に追加する
                                otherDepositPrice += depositList[index].DEPSITDTLRF_DEPOSITRF;
                                printOther = true;
                            }
                            // 手数料のみの場合
                            else if ( depositList[index].DEPSITDTLRF_DEPOSITRF == 0 && depositList[index].DEPSITMAINRF_FEEDEPOSITRF != 0 )
                            {
                                printOther = true;
                            }
                            # endregion

                            //手数料を０にする
                            feeDeposit = depositList[index].DEPSITMAINRF_FEEDEPOSITRF;
                            depositList[index].DEPSITMAINRF_FEEDEPOSITRF = 0;

                            //その他・ファクタリング・口座振替以外 かつ 手数料のみ以外
                            if (depositList[index].DEPSITDTLRF_MONEYKINDCODERF != 59 && 
                                depositList[index].DEPSITDTLRF_MONEYKINDCODERF != 60 && 
                                depositList[index].DEPSITDTLRF_MONEYKINDCODERF != 58 &&
                                (depositList[index].DEPSITDTLRF_DEPOSITRF != 0 || feeDeposit == 0))
                            {
                                depositList2.Add( depositList[index] );
                            }
                        }

                        //最終の伝票のその他の処理を行う
                        # region [最終の伝票のその他]
                        if (depositList.Count > 0 && otherRow)
                        {
                            //ファクタリング＋口座振替＋手数料の金額を追加
                            otherDepositRowWork.DEPSITDTLRF_DEPOSITRF += otherDepositPrice + feeDeposit;
                            depositList2.Add(otherDepositRowWork);
                        }
                        else if (depositList.Count > 0 && printOther)
                        {
                            //その他がない場合は追加する
                            depositList2.Add( AddOtherDeposit( depositList[depositList.Count - 1], otherDepositPrice + feeDeposit ) );
                        }
                        # endregion

                        //リストを差し替える
                        depositList = depositList2;
                    }
                }
                #endregion
                # endregion

                //--------------------------------------------------------
                // 注釈明細 削除
                //--------------------------------------------------------
                #region [注釈明細行　削除]
                //List<EBooksFrePBillDetailWork> deleteList;
                //印刷パターン設定マスタ「注釈印字区分　1：印字しない」
                if (dmdPrtPtnWork.AnnotationPrtCd == 1)
                {
                    //注釈明細行は印字しない
                    deleteList = new List<EBooksFrePBillDetailWork>();
                    foreach (EBooksFrePBillDetailWork detail in salesList)
                    {
                        if (detail.SALESDETAILRF_SALESSLIPCDDTLRF == 3)
                        {
                            deleteList.Add(detail);
                        }
                    }
                    foreach (EBooksFrePBillDetailWork deleteItem in deleteList)
                    {
                        salesList.Remove(deleteItem);
                    }
                }
                #endregion

                //--------------------------------------------------------
                // 売上明細コピー
                //--------------------------------------------------------
                if (salesList != null && salesList.Count > 0)
                {
                    int detailRowCount = 0;
                    # region [売上明細]
                    for (int index = 0; index < salesList.Count; index++)
                    {
                        //新しい伝票かどうか判断するフラグ(山西商会個別)
                        bool newSlip = false;

                        # region [売上明細(伝票計)]
                        if (frePrtPSetWork.FreePrtPprSpPrpseCd == 60)
                        {
                            detailRowCount += 1;
                            
                            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
                            if ((ReportItemDic.ContainsKey("TAX.HFTOTALCONSTAXRATETITLERF") ||
                                ReportItemDic.ContainsKey("TAX.HFTOTALSALESMONEYTAXEXCRF") ||
                                  ReportItemDic.ContainsKey("TAX.HFTAXRATE1RF") ||
                                    ReportItemDic.ContainsKey("TAX.HFTAXRATE1SALESTAXEXCRF") ||
                                      ReportItemDic.ContainsKey("TAX.DTLRTOTALCONSTAXRATETITLERF") ||
                                        ReportItemDic.ContainsKey("TAX.DTLTOTALSALESMONEYTAXEXCRF") ||
                                          ReportItemDic.ContainsKey("TAX.DTLTAXRATE1RF") ||
                                            ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXEXCRF")))
                            {
                                if (index > 0)
                                {
                                    if (salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF != salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                                    {
                                        bChgFlg = true;
                                    }
                                    else
                                    {
                                        bChgFlg = false;
                                    }

                                    EBooksFrePBillDetailWork salesData = salesList[index - 1];
                                    // 税率別情報集計
                                    SalesMeisaiTaxMoneyDiffCalc(index, headWork.CSTCLM_SALESCNSTAXFRCPROCCDRF, salesData, bChgFlg,
                                                       ref lTaxRate1SalesMoneyEx, ref lTaxRate1SalesPriceConsTax,
                                                         ref lTaxRate2SalesMoneyEx, ref lTaxRate2SalesPriceConsTax,
                                                           ref lOtherSalesMoneyEx, ref lOtherSalesPriceConsTax,
                                                             ref lTaxRate1MeisaiTotalTax, ref lTaxRate2MeisaiTotalTax, ref lOtherMeisaiTotalTax,
                                                               ref lSalesMoneyEx, ref lSalesMoneyExTaxOut,
                                                                 ref dicCustomerCode,
                                                                   dTaxRate1, dTaxRate2);
                                }
                            }
                            // --- ADD END   田村顕成 2022/10/18 -----<<<<<
                            // 60:明細請求書
                            if (index > 0 && salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF != salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                            {
                                // (先頭)車種名(２行目のみ印字)　←項目がある時のみ処理を行う
                                if (ReportItemDic.ContainsKey("DADD.MODELHALFNAMEDTL2RF"))
                                {
                                    if (detailRowCount == 2)
                                    {
                                        ReflectModelNameDetailExtra(ref table, salesList[index - 1], dmdPrtPtnWork);
                                    }
                                }
                                if (billDmdPrintParameter.ExistsSalesFooter)
                                {
                                    //売上フッタ
                                    ReflectSalesFooter(ref table, salesList[index - 1], dmdPrtPtnWork, billDmdPrintParameter, headWork);
                                }
                                if (billDmdPrintParameter.ExistsSalesFooter2)
                                {
                                    //売上フッタ２
                                    ReflectSalesFooter2(ref table, salesList[index - 1], dmdPrtPtnWork, billDmdPrintParameter, headWork);
                                }
                                if (billDmdPrintParameter.ExistsSalesFooter3)
                                {
                                    //売上フッタ３
                                    ReflectSalesFooter3(ref table, salesList[index - 1], dmdPrtPtnWork, billDmdPrintParameter,headWork);
                                }

                                if (billDmdPrintParameter.ExistsSalesTotalFooter)
                                {
                                    // 集計行
                                    ReflectSummalyFooters(ref table, salesList[index - 1], dmdPrtPtnWork, SortRecordDivState.Sales, billDmdPrintParameter);
                                }

                                //明細行
                                detailRowCount = 1;
                                //伝票が変わったのでtrue
                                newSlip = true;
                            }


                        }
                        else
                        {
                            // 70:伝票合計請求書

                            if (index > 0)
                            {
                                // --- ADD START 田村顕成 2022/10/18 ----->>>>>
                                if ((ReportItemDic.ContainsKey("TAX.HFTOTALCONSTAXRATETITLERF") ||
                                    ReportItemDic.ContainsKey("TAX.HFTOTALSALESMONEYTAXEXCRF") ||
                                      ReportItemDic.ContainsKey("TAX.HFTAXRATE1RF") ||
                                        ReportItemDic.ContainsKey("TAX.HFTAXRATE1SALESTAXEXCRF") ||
                                          ReportItemDic.ContainsKey("TAX.DTLRTOTALCONSTAXRATETITLERF") ||
                                            ReportItemDic.ContainsKey("TAX.DTLTOTALSALESMONEYTAXEXCRF") ||
                                              ReportItemDic.ContainsKey("TAX.DTLTAXRATE1RF") ||
                                                ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXEXCRF")))
                                {

                                    if (salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF != salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                                    {
                                        bChgFlg = true;
                                    }
                                    else
                                    {
                                        bChgFlg = false;
                                    }

                                    EBooksFrePBillDetailWork salesData = salesList[index - 1];
                                    // 税率別情報集計
                                    SalesMeisaiTaxMoneyDiffCalc(index, headWork.CSTCLM_SALESCNSTAXFRCPROCCDRF, salesData, bChgFlg,
                                                       ref lTaxRate1SalesMoneyEx, ref lTaxRate1SalesPriceConsTax,
                                                         ref lTaxRate2SalesMoneyEx, ref lTaxRate2SalesPriceConsTax,
                                                           ref lOtherSalesMoneyEx, ref lOtherSalesPriceConsTax,
                                                             ref lTaxRate1MeisaiTotalTax, ref lTaxRate2MeisaiTotalTax, ref lOtherMeisaiTotalTax,
                                                               ref lSalesMoneyEx, ref lSalesMoneyExTaxOut,
                                                                 ref dicCustomerCode,
                                                                   dTaxRate1, dTaxRate2);
                                }
                                // --- ADD END   田村顕成 2022/10/18 -----<<<<<

                                // ２行目以降は飛ばす
                                if (salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF == salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                                {
                                    continue;
                                }
                                if (billDmdPrintParameter.ExistsSalesTotalFooter)
                                {
                                    // 集計行
                                    ReflectSummalyFooters(ref table, salesList[index - 1], dmdPrtPtnWork, SortRecordDivState.Sales, billDmdPrintParameter);
                                }
                            }
                        }
                        # endregion

                        #region[山西商会個別内容]
                        if (billDmdPrintParameter.ExistsSalesHeader2)
                        {
                            DataRow headerRow = table.NewRow();

                            //明細の途中でヘッダー行を入れるか判断
                            bool sortDetail = false;
                            if (index > 0 && salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF == salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                            {
                                //同じ伝票内で、型式、年式、車種名が変わった時
                                if (salesList[index - 1].ACCEPTODRCARRF_FULLMODELRF != salesList[index].ACCEPTODRCARRF_FULLMODELRF)
                                {
                                    sortDetail = true;
                                }
                            }
                            //伝票が変わったor車両情報が変わったので売上ヘッダを印刷
                            if (newSlip || sortDetail || index == 0)
                            {
                            	
                            }
                        }
                        #endregion

                        DataRow row = table.NewRow();

                        // "印刷用"項目の適用
                        # region ["印刷用"項目の適用]
                        // ※"印刷用"と付く項目で印字内容を差し替えます。
                        // 品番 ← 印刷用品番
                        salesList[index].SALESDETAILRF_GOODSNORF = salesList[index].SALESDETAILRF_PRTGOODSNORF;
                        // メーカーコード ← 印刷用メーカーコード
                        salesList[index].SALESDETAILRF_GOODSMAKERCDRF = salesList[index].SALESDETAILRF_PRTMAKERCODERF;
                        // メーカー名称 ← 印刷用メーカー名称
                        salesList[index].SALESDETAILRF_MAKERNAMERF = salesList[index].SALESDETAILRF_PRTMAKERNAMERF;
                        # endregion

                        # region [売上明細]
                        row["SALESSLIPRF.ACPTANODRSTATUSRF"] = salesList[index].SALESSLIPRF_ACPTANODRSTATUSRF;
                        row["SALESSLIPRF.SALESSLIPNUMRF"] = salesList[index].SALESSLIPRF_SALESSLIPNUMRF;
                        row["SALESSLIPRF.SECTIONCODERF"] = salesList[index].SALESSLIPRF_SECTIONCODERF;
                        row["SALESSLIPRF.SUBSECTIONCODERF"] = salesList[index].SALESSLIPRF_SUBSECTIONCODERF;
                        row["SALESSLIPRF.DEBITNOTEDIVRF"] = salesList[index].SALESSLIPRF_DEBITNOTEDIVRF;
                        row["SALESSLIPRF.SALESSLIPCDRF"] = salesList[index].SALESSLIPRF_SALESSLIPCDRF;
                        row["SALESSLIPRF.SALESGOODSCDRF"] = salesList[index].SALESSLIPRF_SALESGOODSCDRF;
                        row["SALESSLIPRF.ACCRECDIVCDRF"] = salesList[index].SALESSLIPRF_ACCRECDIVCDRF;
                        row["SALESSLIPRF.DEMANDADDUPSECCDRF"] = salesList[index].SALESSLIPRF_DEMANDADDUPSECCDRF;
                        row["SALESSLIPRF.SALESDATERF"] = salesList[index].SALESSLIPRF_SALESDATERF;
                        row["SALESSLIPRF.ADDUPADATERF"] = salesList[index].SALESSLIPRF_ADDUPADATERF;
                        row["SALESSLIPRF.INPUTAGENCDRF"] = salesList[index].SALESSLIPRF_INPUTAGENCDRF;
                        row["SALESSLIPRF.INPUTAGENNMRF"] = salesList[index].SALESSLIPRF_INPUTAGENNMRF;
                        row["SALESSLIPRF.SALESINPUTCODERF"] = salesList[index].SALESSLIPRF_SALESINPUTCODERF;
                        row["SALESSLIPRF.SALESINPUTNAMERF"] = salesList[index].SALESSLIPRF_SALESINPUTNAMERF;
                        row["SALESSLIPRF.FRONTEMPLOYEECDRF"] = salesList[index].SALESSLIPRF_FRONTEMPLOYEECDRF;
                        row["SALESSLIPRF.FRONTEMPLOYEENMRF"] = salesList[index].SALESSLIPRF_FRONTEMPLOYEENMRF;
                        row["SALESSLIPRF.SALESEMPLOYEECDRF"] = salesList[index].SALESSLIPRF_SALESEMPLOYEECDRF;
                        row["SALESSLIPRF.SALESEMPLOYEENMRF"] = salesList[index].SALESSLIPRF_SALESEMPLOYEENMRF;
                        row["SALESSLIPRF.SALESTOTALTAXINCRF"] = salesList[index].SALESSLIPRF_SALESTOTALTAXINCRF;
                        row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = salesList[index].SALESSLIPRF_SALESTOTALTAXEXCRF;
                        row["SALESSLIPRF.SALESPRTTOTALTAXINCRF"] = salesList[index].SALESSLIPRF_SALESPRTTOTALTAXINCRF;
                        row["SALESSLIPRF.SALESPRTTOTALTAXEXCRF"] = salesList[index].SALESSLIPRF_SALESPRTTOTALTAXEXCRF;
                        row["SALESSLIPRF.SALESWORKTOTALTAXINCRF"] = salesList[index].SALESSLIPRF_SALESWORKTOTALTAXINCRF;
                        row["SALESSLIPRF.SALESWORKTOTALTAXEXCRF"] = salesList[index].SALESSLIPRF_SALESWORKTOTALTAXEXCRF;
                        row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = salesList[index].SALESSLIPRF_SALESSUBTOTALTAXINCRF;
                        row["SALESSLIPRF.SALESPRTSUBTTLINCRF"] = salesList[index].SALESSLIPRF_SALESPRTSUBTTLINCRF;
                        row["SALESSLIPRF.SALESPRTSUBTTLEXCRF"] = salesList[index].SALESSLIPRF_SALESPRTSUBTTLEXCRF;
                        row["SALESSLIPRF.SALESWORKSUBTTLINCRF"] = salesList[index].SALESSLIPRF_SALESWORKSUBTTLINCRF;
                        row["SALESSLIPRF.SALESWORKSUBTTLEXCRF"] = salesList[index].SALESSLIPRF_SALESWORKSUBTTLEXCRF;
                        row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = salesList[index].SALESSLIPRF_SALESSUBTOTALTAXRF;
                        row["SALESSLIPRF.ITDEDPARTSDISOUTTAXRF"] = salesList[index].SALESSLIPRF_ITDEDPARTSDISOUTTAXRF;
                        row["SALESSLIPRF.ITDEDPARTSDISINTAXRF"] = salesList[index].SALESSLIPRF_ITDEDPARTSDISINTAXRF;
                        row["SALESSLIPRF.ITDEDWORKDISOUTTAXRF"] = salesList[index].SALESSLIPRF_ITDEDWORKDISOUTTAXRF;
                        row["SALESSLIPRF.ITDEDWORKDISINTAXRF"] = salesList[index].SALESSLIPRF_ITDEDWORKDISINTAXRF;
                        row["SALESSLIPRF.PARTSDISCOUNTRATERF"] = salesList[index].SALESSLIPRF_PARTSDISCOUNTRATERF;
                        row["SALESSLIPRF.RAVORDISCOUNTRATERF"] = salesList[index].SALESSLIPRF_RAVORDISCOUNTRATERF;
                        row["SALESSLIPRF.TOTALCOSTRF"] = salesList[index].SALESSLIPRF_TOTALCOSTRF;
                        // --- ADD START 田村顕成 2022/10/18 ----->>>>>
                        row["SALESSLIPRF.CONSTAXRATERF"] = 0;
                        if (ReportItemDic.ContainsKey("SALESSLIPRF.CONSTAXRATERF"))
                        {
                            if ((salesList[index].SALESSLIPRF_CONSTAXLAYMETHODRF != 9) && (salesList[index].SALESDETAILRF_SALESSLIPCDDTLRF != 3))
                            {
                                if (salesList[index].SALESDETAILRF_TAXATIONDIVCDRF != 1)
                                {
                                    // 消費税税率「明細」
                                    row["SALESSLIPRF.CONSTAXRATERF"] = salesList[index].SALESSLIPRF_CONSTAXRATERF;
                                }
                            }
                        }
                        // --- ADD END   田村顕成 2022/10/18 -----<<<<<
                        row["SALESSLIPRF.AUTODEPOSITCDRF"] = salesList[index].SALESSLIPRF_AUTODEPOSITCDRF;
                        row["SALESSLIPRF.AUTODEPOSITSLIPNORF"] = salesList[index].SALESSLIPRF_AUTODEPOSITSLIPNORF;
                        row["SALESSLIPRF.DEPOSITALLOWANCETTLRF"] = salesList[index].SALESSLIPRF_DEPOSITALLOWANCETTLRF;
                        row["SALESSLIPRF.DEPOSITALWCBLNCERF"] = salesList[index].SALESSLIPRF_DEPOSITALWCBLNCERF;
                        row["SALESSLIPRF.CLAIMCODERF"] = salesList[index].SALESSLIPRF_CLAIMCODERF;
                        row["SALESSLIPRF.CUSTOMERCODERF"] = salesList[index].SALESSLIPRF_CUSTOMERCODERF;
                        row["SALESSLIPRF.CUSTOMERNAMERF"] = salesList[index].SALESSLIPRF_CUSTOMERNAMERF;
                        row["SALESSLIPRF.CUSTOMERNAME2RF"] = salesList[index].SALESSLIPRF_CUSTOMERNAME2RF;
                        row["SALESSLIPRF.CUSTOMERSNMRF"] = salesList[index].SALESSLIPRF_CUSTOMERSNMRF;
                        row["SALESSLIPRF.HONORIFICTITLERF"] = salesList[index].SALESSLIPRF_HONORIFICTITLERF;
                        row["SALESSLIPRF.ADDRESSEECODERF"] = salesList[index].SALESSLIPRF_ADDRESSEECODERF;
                        row["SALESSLIPRF.ADDRESSEENAMERF"] = salesList[index].SALESSLIPRF_ADDRESSEENAMERF;
                        row["SALESSLIPRF.ADDRESSEENAME2RF"] = salesList[index].SALESSLIPRF_ADDRESSEENAME2RF;
                        row["SALESSLIPRF.SLIPNOTERF"] = salesList[index].SALESSLIPRF_SLIPNOTERF;
                        row["SALESSLIPRF.SLIPNOTE2RF"] = salesList[index].SALESSLIPRF_SLIPNOTE2RF;
                        row["SALESSLIPRF.SLIPNOTE3RF"] = salesList[index].SALESSLIPRF_SLIPNOTE3RF;
                        row["SALESSLIPRF.RETGOODSREASONDIVRF"] = salesList[index].SALESSLIPRF_RETGOODSREASONDIVRF;
                        row["SALESSLIPRF.RETGOODSREASONRF"] = salesList[index].SALESSLIPRF_RETGOODSREASONRF;
                        row["SALESSLIPRF.DETAILROWCOUNTRF"] = salesList[index].SALESSLIPRF_DETAILROWCOUNTRF;
                        row["SALESSLIPRF.UOEREMARK1RF"] = salesList[index].SALESSLIPRF_UOEREMARK1RF;
                        row["SALESSLIPRF.UOEREMARK2RF"] = salesList[index].SALESSLIPRF_UOEREMARK2RF;
                        row["SALESSLIPRF.DELIVEREDGOODSDIVRF"] = salesList[index].SALESSLIPRF_DELIVEREDGOODSDIVRF;
                        row["SALESSLIPRF.DELIVEREDGOODSDIVNMRF"] = salesList[index].SALESSLIPRF_DELIVEREDGOODSDIVNMRF;
                        row["SALESSLIPRF.STOCKGOODSTTLTAXEXCRF"] = salesList[index].SALESSLIPRF_STOCKGOODSTTLTAXEXCRF;
                        row["SALESSLIPRF.PUREGOODSTTLTAXEXCRF"] = salesList[index].SALESSLIPRF_PUREGOODSTTLTAXEXCRF;
                        row["SALESSLIPRF.FOOTNOTES1RF"] = salesList[index].SALESSLIPRF_FOOTNOTES1RF;
                        row["SALESSLIPRF.FOOTNOTES2RF"] = salesList[index].SALESSLIPRF_FOOTNOTES2RF;
                        row["SECDTL.SECTIONGUIDENMRF"] = salesList[index].SECDTL_SECTIONGUIDENMRF;
                        row["SECDTL.SECTIONGUIDESNMRF"] = salesList[index].SECDTL_SECTIONGUIDESNMRF;
                        row["SECDTL.COMPANYNAMECD1RF"] = salesList[index].SECDTL_COMPANYNAMECD1RF;
                        row["SUBSAL.SUBSECTIONNAMERF"] = salesList[index].SUBSAL_SUBSECTIONNAMERF;
                        row["SALESDETAILRF.ACCEPTANORDERNORF"] = salesList[index].SALESDETAILRF_ACCEPTANORDERNORF;
                        row["SALESDETAILRF.SALESROWNORF"] = salesList[index].SALESDETAILRF_SALESROWNORF;
                        row["SALESDETAILRF.DELIGDSCMPLTDUEDATERF"] = salesList[index].SALESDETAILRF_DELIGDSCMPLTDUEDATERF;
                        row["SALESDETAILRF.GOODSKINDCODERF"] = salesList[index].SALESDETAILRF_GOODSKINDCODERF;
                        row["SALESDETAILRF.GOODSMAKERCDRF"] = salesList[index].SALESDETAILRF_GOODSMAKERCDRF;
                        row["SALESDETAILRF.MAKERNAMERF"] = salesList[index].SALESDETAILRF_MAKERNAMERF;
                        row["SALESDETAILRF.GOODSNORF"] = salesList[index].SALESDETAILRF_GOODSNORF;
                        row["SALESDETAILRF.GOODSNAMERF"] = salesList[index].SALESDETAILRF_GOODSNAMERF;
                        row["SALESDETAILRF.GOODSSHORTNAMERF"] = salesList[index].SALESDETAILRF_GOODSSHORTNAMERF;
                        row["SALESDETAILRF.GOODSLGROUPRF"] = salesList[index].SALESDETAILRF_GOODSLGROUPRF;
                        row["SALESDETAILRF.GOODSLGROUPNAMERF"] = salesList[index].SALESDETAILRF_GOODSLGROUPNAMERF;
                        row["SALESDETAILRF.GOODSMGROUPRF"] = salesList[index].SALESDETAILRF_GOODSMGROUPRF;
                        row["SALESDETAILRF.GOODSMGROUPNAMERF"] = salesList[index].SALESDETAILRF_GOODSMGROUPNAMERF;
                        row["SALESDETAILRF.BLGROUPCODERF"] = salesList[index].SALESDETAILRF_BLGROUPCODERF;
                        row["SALESDETAILRF.BLGROUPNAMERF"] = salesList[index].SALESDETAILRF_BLGROUPNAMERF;
                        row["SALESDETAILRF.BLGOODSCODERF"] = salesList[index].SALESDETAILRF_BLGOODSCODERF;
                        row["SALESDETAILRF.BLGOODSFULLNAMERF"] = salesList[index].SALESDETAILRF_BLGOODSFULLNAMERF;
                        row["SALESDETAILRF.ENTERPRISEGANRECODERF"] = salesList[index].SALESDETAILRF_ENTERPRISEGANRECODERF;
                        row["SALESDETAILRF.ENTERPRISEGANRENAMERF"] = salesList[index].SALESDETAILRF_ENTERPRISEGANRENAMERF;
                        row["SALESDETAILRF.WAREHOUSECODERF"] = salesList[index].SALESDETAILRF_WAREHOUSECODERF;
                        row["SALESDETAILRF.WAREHOUSENAMERF"] = salesList[index].SALESDETAILRF_WAREHOUSENAMERF;
                        row["SALESDETAILRF.WAREHOUSESHELFNORF"] = salesList[index].SALESDETAILRF_WAREHOUSESHELFNORF;
                        row["SALESDETAILRF.SALESORDERDIVCDRF"] = salesList[index].SALESDETAILRF_SALESORDERDIVCDRF;
                        row["SALESDETAILRF.OPENPRICEDIVRF"] = salesList[index].SALESDETAILRF_OPENPRICEDIVRF;
                        row["SALESDETAILRF.GOODSRATERANKRF"] = salesList[index].SALESDETAILRF_GOODSRATERANKRF;
                        row["SALESDETAILRF.LISTPRICERATERF"] = salesList[index].SALESDETAILRF_LISTPRICERATERF;
                        row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = salesList[index].SALESDETAILRF_LISTPRICETAXINCFLRF;
                        row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = salesList[index].SALESDETAILRF_LISTPRICETAXEXCFLRF;
                        row["SALESDETAILRF.SALESRATERF"] = salesList[index].SALESDETAILRF_SALESRATERF;
                        row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = salesList[index].SALESDETAILRF_SALESUNPRCTAXINCFLRF;
                        row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = salesList[index].SALESDETAILRF_SALESUNPRCTAXEXCFLRF;
                        row["SALESDETAILRF.COSTRATERF"] = salesList[index].SALESDETAILRF_COSTRATERF;
                        row["SALESDETAILRF.SALESUNITCOSTRF"] = salesList[index].SALESDETAILRF_SALESUNITCOSTRF;
                        row["SALESDETAILRF.PRTBLGOODSCODERF"] = salesList[index].SALESDETAILRF_PRTBLGOODSCODERF;
                        row["SALESDETAILRF.PRTBLGOODSNAMERF"] = salesList[index].SALESDETAILRF_PRTBLGOODSNAMERF;
                        row["SALESDETAILRF.WORKMANHOURRF"] = salesList[index].SALESDETAILRF_WORKMANHOURRF;
                        row["SALESDETAILRF.SHIPMENTCNTRF"] = salesList[index].SALESDETAILRF_SHIPMENTCNTRF;
                        row["SALESDETAILRF.SALESMONEYTAXINCRF"] = salesList[index].SALESDETAILRF_SALESMONEYTAXINCRF;
                        row["SALESDETAILRF.SALESMONEYTAXEXCRF"] = salesList[index].SALESDETAILRF_SALESMONEYTAXEXCRF;
                        row["SALESDETAILRF.COSTRF"] = salesList[index].SALESDETAILRF_COSTRF;
                        row["SALESDETAILRF.TAXATIONDIVCDRF"] = salesList[index].SALESDETAILRF_TAXATIONDIVCDRF;
                        row["SALESDETAILRF.PARTYSLIPNUMDTLRF"] = salesList[index].SALESDETAILRF_PARTYSLIPNUMDTLRF;
                        row["SALESDETAILRF.DTLNOTERF"] = salesList[index].SALESDETAILRF_DTLNOTERF;
                        row["SALESDETAILRF.SUPPLIERCDRF"] = salesList[index].SALESDETAILRF_SUPPLIERCDRF;
                        row["SALESDETAILRF.SUPPLIERSNMRF"] = salesList[index].SALESDETAILRF_SUPPLIERSNMRF;
                        row["SALESDETAILRF.SLIPMEMO1RF"] = salesList[index].SALESDETAILRF_SLIPMEMO1RF;
                        row["SALESDETAILRF.SLIPMEMO2RF"] = salesList[index].SALESDETAILRF_SLIPMEMO2RF;
                        row["SALESDETAILRF.SLIPMEMO3RF"] = salesList[index].SALESDETAILRF_SLIPMEMO3RF;
                        row["SALESDETAILRF.INSIDEMEMO1RF"] = salesList[index].SALESDETAILRF_INSIDEMEMO1RF;
                        row["SALESDETAILRF.INSIDEMEMO2RF"] = salesList[index].SALESDETAILRF_INSIDEMEMO2RF;
                        row["SALESDETAILRF.INSIDEMEMO3RF"] = salesList[index].SALESDETAILRF_INSIDEMEMO3RF;
                        row["SALESDETAILRF.BFLISTPRICERF"] = salesList[index].SALESDETAILRF_BFLISTPRICERF;
                        row["SALESDETAILRF.BFSALESUNITPRICERF"] = salesList[index].SALESDETAILRF_BFSALESUNITPRICERF;
                        row["SALESDETAILRF.BFUNITCOSTRF"] = salesList[index].SALESDETAILRF_BFUNITCOSTRF;
                        row["SALESDETAILRF.CMPLTSALESROWNORF"] = salesList[index].SALESDETAILRF_CMPLTSALESROWNORF;
                        row["SALESDETAILRF.CMPLTGOODSMAKERCDRF"] = salesList[index].SALESDETAILRF_CMPLTGOODSMAKERCDRF;
                        row["SALESDETAILRF.CMPLTMAKERNAMERF"] = salesList[index].SALESDETAILRF_CMPLTMAKERNAMERF;
                        row["SALESDETAILRF.CMPLTGOODSNAMERF"] = salesList[index].SALESDETAILRF_CMPLTGOODSNAMERF;
                        row["SALESDETAILRF.CMPLTSHIPMENTCNTRF"] = salesList[index].SALESDETAILRF_CMPLTSHIPMENTCNTRF;
                        row["SALESDETAILRF.CMPLTSALESUNPRCFLRF"] = salesList[index].SALESDETAILRF_CMPLTSALESUNPRCFLRF;
                        row["SALESDETAILRF.CMPLTSALESMONEYRF"] = salesList[index].SALESDETAILRF_CMPLTSALESMONEYRF;
                        row["SALESDETAILRF.CMPLTSALESUNITCOSTRF"] = salesList[index].SALESDETAILRF_CMPLTSALESUNITCOSTRF;
                        row["SALESDETAILRF.CMPLTCOSTRF"] = salesList[index].SALESDETAILRF_CMPLTCOSTRF;
                        row["SALESDETAILRF.CMPLTPARTYSALSLNUMRF"] = salesList[index].SALESDETAILRF_CMPLTPARTYSALSLNUMRF;
                        row["SALESDETAILRF.CMPLTNOTERF"] = salesList[index].SALESDETAILRF_CMPLTNOTERF;
                        row["ACCEPTODRCARRF.CARMNGNORF"] = salesList[index].ACCEPTODRCARRF_CARMNGNORF;
                        row["ACCEPTODRCARRF.CARMNGCODERF"] = salesList[index].ACCEPTODRCARRF_CARMNGCODERF;
                        row["ACCEPTODRCARRF.NUMBERPLATE1CODERF"] = salesList[index].ACCEPTODRCARRF_NUMBERPLATE1CODERF;
                        row["ACCEPTODRCARRF.NUMBERPLATE1NAMERF"] = salesList[index].ACCEPTODRCARRF_NUMBERPLATE1NAMERF;
                        row["ACCEPTODRCARRF.NUMBERPLATE2RF"] = salesList[index].ACCEPTODRCARRF_NUMBERPLATE2RF;
                        row["ACCEPTODRCARRF.NUMBERPLATE3RF"] = salesList[index].ACCEPTODRCARRF_NUMBERPLATE3RF;
                        row["ACCEPTODRCARRF.NUMBERPLATE4RF"] = salesList[index].ACCEPTODRCARRF_NUMBERPLATE4RF;
                        row["ACCEPTODRCARRF.FIRSTENTRYDATERF"] = salesList[index].ACCEPTODRCARRF_FIRSTENTRYDATERF;
                        row["ACCEPTODRCARRF.MAKERCODERF"] = salesList[index].ACCEPTODRCARRF_MAKERCODERF;
                        row["ACCEPTODRCARRF.MAKERFULLNAMERF"] = salesList[index].ACCEPTODRCARRF_MAKERFULLNAMERF;
                        row["ACCEPTODRCARRF.MODELCODERF"] = salesList[index].ACCEPTODRCARRF_MODELCODERF;
                        row["ACCEPTODRCARRF.MODELSUBCODERF"] = salesList[index].ACCEPTODRCARRF_MODELSUBCODERF;
                        row["ACCEPTODRCARRF.MODELFULLNAMERF"] = salesList[index].ACCEPTODRCARRF_MODELFULLNAMERF;
                        row["ACCEPTODRCARRF.EXHAUSTGASSIGNRF"] = salesList[index].ACCEPTODRCARRF_EXHAUSTGASSIGNRF;
                        row["ACCEPTODRCARRF.SERIESMODELRF"] = salesList[index].ACCEPTODRCARRF_SERIESMODELRF;
                        row["ACCEPTODRCARRF.CATEGORYSIGNMODELRF"] = salesList[index].ACCEPTODRCARRF_CATEGORYSIGNMODELRF;
                        row["ACCEPTODRCARRF.FULLMODELRF"] = salesList[index].ACCEPTODRCARRF_FULLMODELRF;
                        row["ACCEPTODRCARRF.MODELDESIGNATIONNORF"] = salesList[index].ACCEPTODRCARRF_MODELDESIGNATIONNORF;
                        row["ACCEPTODRCARRF.CATEGORYNORF"] = salesList[index].ACCEPTODRCARRF_CATEGORYNORF;
                        row["ACCEPTODRCARRF.FRAMEMODELRF"] = salesList[index].ACCEPTODRCARRF_FRAMEMODELRF;
                        row["ACCEPTODRCARRF.FRAMENORF"] = salesList[index].ACCEPTODRCARRF_FRAMENORF;
                        row["ACCEPTODRCARRF.SEARCHFRAMENORF"] = salesList[index].ACCEPTODRCARRF_SEARCHFRAMENORF;
                        row["ACCEPTODRCARRF.ENGINEMODELNMRF"] = salesList[index].ACCEPTODRCARRF_ENGINEMODELNMRF;
                        row["ACCEPTODRCARRF.RELEVANCEMODELRF"] = salesList[index].ACCEPTODRCARRF_RELEVANCEMODELRF;
                        row["ACCEPTODRCARRF.SUBCARNMCDRF"] = salesList[index].ACCEPTODRCARRF_SUBCARNMCDRF;
                        row["ACCEPTODRCARRF.MODELGRADESNAMERF"] = salesList[index].ACCEPTODRCARRF_MODELGRADESNAMERF;
                        row["ACCEPTODRCARRF.COLORCODERF"] = salesList[index].ACCEPTODRCARRF_COLORCODERF;
                        row["ACCEPTODRCARRF.COLORNAME1RF"] = salesList[index].ACCEPTODRCARRF_COLORNAME1RF;
                        row["ACCEPTODRCARRF.TRIMCODERF"] = salesList[index].ACCEPTODRCARRF_TRIMCODERF;
                        row["ACCEPTODRCARRF.TRIMNAMERF"] = salesList[index].ACCEPTODRCARRF_TRIMNAMERF;
                        row["ACCEPTODRCARRF.MILEAGERF"] = salesList[index].ACCEPTODRCARRF_MILEAGERF;
                        row["SALESDETAILRF.GOODSNAMEKANARF"] = salesList[index].SALESDETAILRF_GOODSNAMEKANARF; // 商品名称カナ
                        row["SALESDETAILRF.MAKERKANANAMERF"] = salesList[index].SALESDETAILRF_MAKERKANANAMERF; // メーカーカナ名称
                        row["ACCEPTODRCARRF.MODELHALFNAMERF"] = salesList[index].ACCEPTODRCARRF_MODELHALFNAMERF; // 車種半角名称
                        row["SALESDETAILRF.PRTGOODSNORF"] = salesList[index].SALESDETAILRF_PRTGOODSNORF; // 印刷用品番
                        row["SALESDETAILRF.PRTMAKERCODERF"] = salesList[index].SALESDETAILRF_PRTMAKERCODERF; // 印刷用メーカーコード
                        row["SALESDETAILRF.PRTMAKERNAMERF"] = salesList[index].SALESDETAILRF_PRTMAKERNAMERF; // 印刷用メーカー名称
                        row["DADD.FULLMODELHD2SEARCHRF"] = GetFullModel(salesList[index]);
                        row["DADD.MODELHALFNAMEHD2SEARCHRF"] = salesList[index].ACCEPTODRCARRF_MODELHALFNAMERF;
                        row["DADD.FOOTER3PRINTRF"] = 1;
                        // --- ADD START 田村顕成 2022/10/18 ----->>>>>
                        // 消費税転嫁方式「非課税、行値引以外の場合、印字する」
                        if (ReportItemDic.ContainsKey("TAX.DTLTAXRATERF"))
                        {
                            if ((salesList[index].SALESSLIPRF_CONSTAXLAYMETHODRF != 9) && (salesList[index].SALESDETAILRF_SALESSLIPCDDTLRF != 3))
                            {
                                if (salesList[index].SALESDETAILRF_TAXATIONDIVCDRF != 1)
                                {
                                    // 消費税税率(整数)「明細」
                                    row["TAX.DTLTAXRATERF"] = Convert.ToString(Convert.ToInt32(salesList[index].SALESSLIPRF_CONSTAXRATERF * 100)) + "%";
                                }
                            }
                        }
                        // --- ADD END   田村顕成 2022/10/18 -----<<<<<
                        //消費税税率「明細」
                        row["SALESSLIPRF.CONSTAXRATERF"] = 0;
                        if (ReportItemDic.ContainsKey("SALESSLIPRF.CONSTAXRATERF"))
                        {
                            if ((salesList[index].SALESSLIPRF_CONSTAXLAYMETHODRF != 9) && (salesList[index].SALESDETAILRF_SALESSLIPCDDTLRF != 3))
                            {
                                if (salesList[index].SALESDETAILRF_TAXATIONDIVCDRF != 1)
                                {
                                    // 消費税税率「明細」
                                    row["SALESSLIPRF.CONSTAXRATERF"] = salesList[index].SALESSLIPRF_CONSTAXRATERF;
                                }
                            }
                        }
                        # endregion

                        # region [売上明細(自動以外)]

                        // 金額項目補正
                        # region [金額項目補正]
                        // 誤って使用すると意図した結果にならない金額項目の補正
                        row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = salesList[index].SALESSLIPRF_SALESTOTALTAXEXCRF;
                        row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = salesList[index].SALESSLIPRF_SALESTOTALTAXINCRF;
                        # endregion

                        // 明細摘要
                        # region [明細摘要]
                        // DmdDtlOutlineCodeRF = 0:印字しない 1:品番 2:定価
                        switch (dmdPrtPtnWork.DmdDtlOutlineCode)
                        {
                            case 1:
                                {
                                    // 品番
                                    row["DADD.DMDDTLOUTLINERF"] = salesList[index].SALESDETAILRF_GOODSNORF;
                                    row[ct_col_DAdd_DmdDtlOutLineRF_ListPrice] = DBNull.Value;
                                }
                                break;
                            case 2:
                                {
                                    // 定価
                                    row["DADD.DMDDTLOUTLINERF"] = DBNull.Value;
                                    row[ct_col_DAdd_DmdDtlOutLineRF_ListPrice] = salesList[index].SALESDETAILRF_LISTPRICETAXEXCFLRF;
                                }
                                break;
                            case 0:
                            default:
                                {
                                    // 印字しない
                                    row["DADD.DMDDTLOUTLINERF"] = DBNull.Value;
                                    row[ct_col_DAdd_DmdDtlOutLineRF_ListPrice] = DBNull.Value;
                                }
                                break;
                        }
                        # endregion

                        // 日付展開
                        # region [日付展開]
                        // (通常)
                        ExtractDate(ref row, allDefSet.EraNameDispCd2, salesList[index].SALESSLIPRF_SALESDATERF, "DADD.SALESDATE", false); // yyyymmdd
                        // (年式)
                        ExtractDate(ref row, allDefSet.EraNameDispCd1, salesList[index].ACCEPTODRCARRF_FIRSTENTRYDATERF, "DADD.FIRSTENTRYDATE", true); // yyyymm
                        //（通常）検索用
                        ExtractDate(ref row, allDefSet.EraNameDispCd1, salesList[index].SALESSLIPRF_SALESDATERF, "DADD.SALESDATEHD2SEARCH", false); //yyyymmdd
                        # endregion

                        // 相手先伝票番号（ヘッダ用）
                        # region [相手先伝票番号（ヘッダ用）]
                        row["DADD.PARTYSALESLIPNUMRF"] = salesList[index].SALESSLIPRF_PARTYSALESLIPNUMRF; // ←内容はフッタ用と同じ
                        # endregion

                        // 半角名対応
                        # region [半角名対応]
                        // 品名カナ
                        if (string.IsNullOrEmpty(salesList[index].SALESDETAILRF_GOODSNAMEKANARF))
                        {
                            row["SALESDETAILRF.GOODSNAMEKANARF"] = salesList[index].SALESDETAILRF_GOODSNAMERF; // ←空白なら品名をセット
                        }
                        // メーカー名カナ
                        if (string.IsNullOrEmpty(salesList[index].SALESDETAILRF_MAKERKANANAMERF))
                        {
                            row["SALESDETAILRF.MAKERKANANAMERF"] = salesList[index].SALESDETAILRF_MAKERNAMERF; // ←空白ならメーカー名をセット
                        }
                        // 車種半角名
                        if (string.IsNullOrEmpty(salesList[index].ACCEPTODRCARRF_MODELHALFNAMERF))
                        {
                            row["ACCEPTODRCARRF.MODELHALFNAMERF"] = GetKanaString(salesList[index].ACCEPTODRCARRF_MODELFULLNAMERF);
                            row["DADD.MODELHALFNAMEHD2SEARCHRF"] = GetKanaString(salesList[index].ACCEPTODRCARRF_MODELFULLNAMERF);
                        }

                        // （先頭）車種半角名称がある時のみ処理を行う
                        if (ReportItemDic.ContainsKey("DADD.MODELHALFNAME2RF"))
                        {
                            if (index == 0 || index > 0 && salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF != salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                            {
                                //明細１行目の車種名を印字する
                                if (string.IsNullOrEmpty(salesList[index].ACCEPTODRCARRF_MODELHALFNAMERF))
                                {
                                    row["DADD.MODELHALFNAME2RF"] = GetKanaString(salesList[index].ACCEPTODRCARRF_MODELFULLNAMERF);
                                }
                                else
                                {
                                    row["DADD.MODELHALFNAME2RF"] = salesList[index].ACCEPTODRCARRF_MODELHALFNAMERF;
                                }
                            }
                        }
                        # endregion

                        //(先頭)型式　←項目がある時のみ処理を行う
                        if (ReportItemDic.ContainsKey("DADD.FULLMODELRF"))
                        {
                            if (index == 0 || index > 0 && salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF != salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                            {
                                //明細１行目の型式を印字する
                                row["DADD.FULLMODELRF"] = salesList[index].ACCEPTODRCARRF_FULLMODELRF;
                            }
                        }

                        //(先頭)車種名(２行目印字)  ←項目がある時のみ処理を行う
                        if (ReportItemDic.ContainsKey("DADD.MODELHALFNAMEDTL2RF"))
                        {
                                //明細行数が2行以上の時、2行目に車種名を印字
                                if (detailRowCount == 2)
                                {
                                    //1行目の車種名を印字する
                                    row["DADD.MODELHALFNAMEDTL2RF"] = salesList[index - 1].ACCEPTODRCARRF_MODELHALFNAMERF;

                                    if (string.IsNullOrEmpty(salesList[index - 1].ACCEPTODRCARRF_MODELHALFNAMERF))
                                    {
                                        row["DADD.MODELHALFNAMEDTL2RF"] = GetKanaString(salesList[index - 1].ACCEPTODRCARRF_MODELFULLNAMERF);
                                    }
                                }
                            }

                        //(先頭)車種名(２行目印字)２  ←項目がある時のみ処理を行う
                        if (ReportItemDic.ContainsKey("DADD.MODELHALFNAMEDTL3RF"))
                        {
                            if (detailRowCount == 1)
                            {
                                if (index == 0 || index > 0 && salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF != salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                                {
                                    //明細１行目の車種名を取得する
                                    _modelHalfNameDtl1 = salesList[index].ACCEPTODRCARRF_MODELHALFNAMERF;
                                    if (string.IsNullOrEmpty(_modelHalfNameDtl1))
                                    {
                                        _modelHalfNameDtl1 = GetKanaString(salesList[index].ACCEPTODRCARRF_MODELFULLNAMERF);
                                    }
                                }
                            }
                            if (detailRowCount == 2)
                            {
                                //1行目の車種名を印字する
                                row["DADD.MODELHALFNAMEDTL3RF"] = _modelHalfNameDtl1;
                                _modelHalfNameDtl3PrtFlg = true;
                            }
                        }
                        // （先頭）車両管理番号（２行目印字）　←項目がある時のみ処理を行う
                        if (ReportItemDic.ContainsKey("DADD.CARMNGNO2RF"))
                        {
                            if (detailRowCount == 1)
                            {
                                if (index == 0 || index > 0 && salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF != salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                                {
                                    //明細１行目の車両管理番号を取得する
                                    _carMngNo2Dtl1 = salesList[index].ACCEPTODRCARRF_CARMNGCODERF;
                                }
                            }
                            if (detailRowCount == 2)
                            {
                                //1行目の車種名を印字する
                                row["DADD.CARMNGNO2RF"] = _carMngNo2Dtl1;
                                if (!string.IsNullOrEmpty(_carMngNo2Dtl1))
                                {
                                    row["DADD.CARMNGCODETITLE2RF"] = "【ﾌﾟﾚｰﾄ】";
                                }
                                _carMngNo2PrtFlg = true;
                            }
                        }

                        if (ReportItemDic.ContainsKey("SALESSLIPRF.SLIPNOTE2_2RF"))
                        {
                            string salesSlipNote2 = salesList[index].SALESSLIPRF_SLIPNOTE2RF;
                            string prtSalesSlipNote2 = "";
                            string targetStr = "";
                            int maxNum = sjisEnc.GetByteCount(salesSlipNote2);
                            int prtCnt = 16;    // 一行に印字するバイト数
                            int cutPoint = 0;
                            int nowNum = 0;
                            if (detailRowCount == 2)
                            {
                                // ２行目なら備考２の頭から16バイト印字
                                if (maxNum > prtCnt)
                                {
                                    while (nowNum < prtCnt)
                                    {
                                        targetStr = salesSlipNote2.Substring(cutPoint, 1);
                                        if (nowNum + sjisEnc.GetByteCount(targetStr) > prtCnt)
                                        {
                                            break;
                                        }
                                        cutPoint++;
                                        nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                                    }
                                    prtSalesSlipNote2 = salesSlipNote2.Substring(0, cutPoint);
                                }
                                else
                                {
                                    prtSalesSlipNote2 = salesSlipNote2;
                                }
                                if (string.IsNullOrEmpty(prtSalesSlipNote2))
                                    row["SALESSLIPRF.SLIPNOTE2_2RF"] = DBNull.Value;
                                else
                                    row["SALESSLIPRF.SLIPNOTE2_2RF"] = prtSalesSlipNote2;
                                _slipNote2PrtCnt++;
                            }
                            else if (detailRowCount == 3)
                            {
                                // ３行目なら備考２の17バイト目から16バイト印字
                                if (maxNum > prtCnt)
                                {
                                    while (nowNum < prtCnt)
                                    {
                                        targetStr = salesSlipNote2.Substring(cutPoint, 1);
                                        if (nowNum + sjisEnc.GetByteCount(targetStr) > prtCnt)
                                        {
                                            break;
                                        }
                                        cutPoint++;
                                        nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                                    }
                                    salesSlipNote2 = salesSlipNote2.Substring(cutPoint, salesSlipNote2.Length - cutPoint);

                                    if (maxNum > prtCnt * 2)
                                    {
                                        maxNum = sjisEnc.GetByteCount(salesSlipNote2);
                                        nowNum = 0;
                                        cutPoint = 0;
                                        while (nowNum < prtCnt)
                                        {
                                            targetStr = salesSlipNote2.Substring(cutPoint, 1);
                                            if (nowNum + sjisEnc.GetByteCount(targetStr) > prtCnt)
                                            {
                                                break;
                                            }
                                            cutPoint++;
                                            nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                                        }
                                        prtSalesSlipNote2 = salesSlipNote2.Substring(0, cutPoint);
                                    }
                                    else
                                    {
                                        prtSalesSlipNote2 = salesSlipNote2;
                                    }
                                }
                                else
                                {
                                    prtSalesSlipNote2 = "";
                                }
                                if (string.IsNullOrEmpty(prtSalesSlipNote2))
                                    row["SALESSLIPRF.SLIPNOTE2_2RF"] = DBNull.Value;
                                else
                                    row["SALESSLIPRF.SLIPNOTE2_2RF"] = prtSalesSlipNote2;
                                _slipNote2PrtCnt++;
                            }
                        }
                        if (ReportItemDic.ContainsKey("DADD.FULLMODELORMODELHALFNAMERF"))
                        {
                            string fllModel = row["ACCEPTODRCARRF.FULLMODELRF"].ToString();
                            string modelHalfName = row["ACCEPTODRCARRF.MODELHALFNAMERF"].ToString();
                            if (string.IsNullOrEmpty(fllModel))
                            {
                                // 型式が空白なら車種半角名称を印字
                                row["DADD.FULLMODELORMODELHALFNAMERF"] = modelHalfName;
                            }
                            else
                            {
                                // 型式がセットされているなら型式を印字
                                row["DADD.FULLMODELORMODELHALFNAMERF"] = fllModel;
                            }
                        }
                        if (billDmdPrintParameter.ExistsSalesHeader2)
                        {
                            //売上伝票区分コード(検索用)
                            if (salesList[index].SALESSLIPRF_SALESSLIPCDRF == 0)
                            {
                                //売上
                                row["DADD.SALESSLIPCDCHANGESEARCHRF"] = 01;
                            }
                            else
                            {
                                //返品
                                row["DADD.SALESSLIPCDCHANGESEARCHRF"] = 02;
                            }
                        }

                        // ソート・合計対応
                        # region [ソート・合計対応]
                        row[ct_col_Sort_CustomerCode] = salesList[index].SALESSLIPRF_CUSTOMERCODERF;
                        row[ct_col_Sort_Date] = salesList[index].SALESSLIPRF_SALESDATERF;
                        row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                        row[ct_col_Sort_SalesSlipNo] = salesList[index].SALESSLIPRF_SALESSLIPNUMRF;
                        row[ct_col_Sort_DepositSlipNo] = 0;
                        row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                        row[ct_col_Sort_DetailRowNo] = salesList[index].SALESDETAILRF_SALESROWNORF * 10;
                        row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                        # endregion

                        // 伝票合計請求書用 明細タイトル
                        # region [伝票合計請求書用 明細タイトル]
                        switch (salesList[index].SALESSLIPRF_SALESSLIPCDRF)
                        {
                            case 0:
                                row["DSAL.DETAILTITLERF"] = "売上";
                                break;
                            case 1:
                                row["DSAL.DETAILTITLERF"] = "返品";
                                break;
                        }

                        # endregion

                        // プレート番号タイトル
                        row["DADD.CARMNGCODETITLERF"] = billDmdPrintParameter.CarmngCodeTitle;

                        // 未設定時 非印字コード
                        # region [未設定]
                        if (IsZero(salesList[index].SALESSLIPRF_SECTIONCODERF)) row["SALESSLIPRF.SECTIONCODERF"] = DBNull.Value; // 拠点コード
                        if (IsZero(salesList[index].SALESSLIPRF_SUBSECTIONCODERF)) row["SALESSLIPRF.SUBSECTIONCODERF"] = DBNull.Value; // 部門コード
                        if (IsZero(salesList[index].SALESSLIPRF_DEMANDADDUPSECCDRF)) row["SALESSLIPRF.DEMANDADDUPSECCDRF"] = DBNull.Value; // 請求計上拠点コード
                        if (IsZero(salesList[index].SALESSLIPRF_INPUTAGENCDRF)) row["SALESSLIPRF.INPUTAGENCDRF"] = DBNull.Value; // 入力担当者コード
                        if (IsZero(salesList[index].SALESSLIPRF_SALESINPUTCODERF)) row["SALESSLIPRF.SALESINPUTCODERF"] = DBNull.Value; // 売上入力者コード
                        if (IsZero(salesList[index].SALESSLIPRF_FRONTEMPLOYEECDRF)) row["SALESSLIPRF.FRONTEMPLOYEECDRF"] = DBNull.Value; // 受付従業員コード
                        if (IsZero(salesList[index].SALESSLIPRF_SALESEMPLOYEECDRF)) row["SALESSLIPRF.SALESEMPLOYEECDRF"] = DBNull.Value; // 販売従業員コード
                        if (IsZero(salesList[index].SALESSLIPRF_CLAIMCODERF)) row["SALESSLIPRF.CLAIMCODERF"] = DBNull.Value; // 請求先コード
                        if (IsZero(salesList[index].SALESSLIPRF_CUSTOMERCODERF)) row["SALESSLIPRF.CUSTOMERCODERF"] = DBNull.Value; // 得意先コード
                        if (IsZero(salesList[index].SALESSLIPRF_ADDRESSEECODERF)) row["SALESSLIPRF.ADDRESSEECODERF"] = DBNull.Value; // 納品先コード
                        if (IsZero(salesList[index].SALESSLIPRF_RETGOODSREASONDIVRF)) row["SALESSLIPRF.RETGOODSREASONDIVRF"] = DBNull.Value; // 返品理由コード
                        if (IsZero(salesList[index].SALESDETAILRF_GOODSMAKERCDRF)) row["SALESDETAILRF.GOODSMAKERCDRF"] = DBNull.Value; // 商品メーカーコード
                        if (IsZero(salesList[index].SALESDETAILRF_GOODSLGROUPRF)) row["SALESDETAILRF.GOODSLGROUPRF"] = DBNull.Value; // 商品大分類コード
                        if (IsZero(salesList[index].SALESDETAILRF_GOODSMGROUPRF)) row["SALESDETAILRF.GOODSMGROUPRF"] = DBNull.Value; // 商品中分類コード
                        if (IsZero(salesList[index].SALESDETAILRF_BLGROUPCODERF)) row["SALESDETAILRF.BLGROUPCODERF"] = DBNull.Value; // BLグループコード
                        if (IsZero(salesList[index].SALESDETAILRF_BLGOODSCODERF)) row["SALESDETAILRF.BLGOODSCODERF"] = DBNull.Value; // BL商品コード
                        if (IsZero(salesList[index].SALESDETAILRF_ENTERPRISEGANRECODERF)) row["SALESDETAILRF.ENTERPRISEGANRECODERF"] = DBNull.Value; // 自社分類コード
                        if (IsZero(salesList[index].SALESDETAILRF_WAREHOUSECODERF)) row["SALESDETAILRF.WAREHOUSECODERF"] = DBNull.Value; // 倉庫コード
                        if (IsZero(salesList[index].SALESDETAILRF_PRTBLGOODSCODERF)) row["SALESDETAILRF.PRTBLGOODSCODERF"] = DBNull.Value; // BL商品コード（印刷）
                        if (IsZero(salesList[index].SALESDETAILRF_SUPPLIERCDRF)) row["SALESDETAILRF.SUPPLIERCDRF"] = DBNull.Value; // 仕入先コード
                        if (IsZero(salesList[index].SALESDETAILRF_CMPLTGOODSMAKERCDRF)) row["SALESDETAILRF.CMPLTGOODSMAKERCDRF"] = DBNull.Value; // メーカーコード（一式）
                        if (IsZero(salesList[index].ACCEPTODRCARRF_MAKERCODERF)) row["ACCEPTODRCARRF.MAKERCODERF"] = DBNull.Value; // メーカーコード
                        if (IsZero(salesList[index].ACCEPTODRCARRF_MODELCODERF)) row["ACCEPTODRCARRF.MODELCODERF"] = DBNull.Value; // 車種コード
                        if (IsZero(salesList[index].ACCEPTODRCARRF_MODELSUBCODERF)) row["ACCEPTODRCARRF.MODELSUBCODERF"] = DBNull.Value; // 車種サブコード
                        if (IsZero(salesList[index].ACCEPTODRCARRF_MODELDESIGNATIONNORF)) row["ACCEPTODRCARRF.MODELDESIGNATIONNORF"] = DBNull.Value; // 型式指定番号
                        if (IsZero(salesList[index].ACCEPTODRCARRF_CATEGORYNORF)) row["ACCEPTODRCARRF.CATEGORYNORF"] = DBNull.Value; // 類別番号
                        # endregion

                        // 明細請求書の行値引
                        # region [明細請求書の行値引]
                        // 60:明細請求書
                        if (frePrtPSetWork.FreePrtPprSpPrpseCd == 60)
                        {
                            // 行値引
                            if (salesList[index].SALESDETAILRF_SALESSLIPCDDTLRF == 2 &&
                                 salesList[index].SALESDETAILRF_SHIPMENTCNTRF == 0)
                            {
                                // 印字項目クリア
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // 定価（税込，浮動）
                                row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // 定価（税抜，浮動）
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // 売上単価（税込，浮動）
                                row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // 売上単価（税抜，浮動）
                                row["SALESDETAILRF.SALESUNITCOSTRF"] = DBNull.Value; // 原価単価
                                row["SALESDETAILRF.SHIPMENTCNTRF"] = DBNull.Value; // 出荷数

                                // 摘要クリア
                                row["DADD.DMDDTLOUTLINERF"] = DBNull.Value;
                                row[ct_col_DAdd_DmdDtlOutLineRF_ListPrice] = DBNull.Value;
                            }
                            // 注釈行
                            else if (salesList[index].SALESDETAILRF_SALESSLIPCDDTLRF == 3)
                            {
                                // 印字項目クリア
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // 定価（税込，浮動）
                                row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // 定価（税抜，浮動）
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // 売上単価（税込，浮動）
                                row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // 売上単価（税抜，浮動）
                                row["SALESDETAILRF.SALESUNITCOSTRF"] = DBNull.Value; // 原価単価
                                row["SALESDETAILRF.SHIPMENTCNTRF"] = DBNull.Value; // 出荷数

                                // 金額クリア 
                                row["SALESDETAILRF.SALESMONEYTAXINCRF"] = DBNull.Value;
                                row["SALESDETAILRF.SALESMONEYTAXEXCRF"] = DBNull.Value;

                                // 摘要クリア
                                row["DADD.DMDDTLOUTLINERF"] = DBNull.Value;
                                row[ct_col_DAdd_DmdDtlOutLineRF_ListPrice] = DBNull.Value;
                            }
                        }
                        # endregion

                        // 請求書印刷パターン設定
                        # region [請求書印刷パターン設定]
                        // 品番印字有無(0:印字しない,1:印字する)
                        if (dmdPrtPtnWork.PartsNoPrtCd == 0)
                        {
                            // 印字しない
                            row["DADD.DMDDTLOUTLINERF"] = DBNull.Value; // 明細摘要(品番)
                            row["SALESDETAILRF.GOODSNORF"] = DBNull.Value; // 品番
                            row["SALESDETAILRF.PRTGOODSNORF"] = DBNull.Value; // 印刷用品番
                        }

                        // 標準価格印字有無(0:印字しない 1:印字する 2:掛率＜１)
                        if (!CheckListPricePrint(salesList[index], dmdPrtPtnWork))
                        {
                            // 印字しない
                            row[ct_col_DAdd_DmdDtlOutLineRF_ListPrice] = DBNull.Value; // 明細摘要(標準価格)
                            row["SALESDETAILRF.LISTPRICERATERF"] = DBNull.Value; // 定価率
                            row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // 定価(税込)
                            row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // 定価(税抜) 
                            row["SALESDETAILRF.BFLISTPRICERF"] = DBNull.Value; // 変更前定価
                        }
                        # endregion

                        # endregion

                        table.Rows.Add(row);
                    }

                    //最後の売上ヘッダを印刷

                    // 60:明細請求書
                    if (frePrtPSetWork.FreePrtPprSpPrpseCd == 60)
                    {
                        // (先頭)車種名(２行目印字)　←項目がある時のみ処理を行う
                        if (ReportItemDic.ContainsKey("DADD.MODELHALFNAMEDTL2RF"))
                        {
                            if (salesList[salesList.Count - 1].SALESSLIPRF_DETAILROWCOUNTRF == 1)
                            {
                                ReflectModelNameDetailExtra(ref table, salesList[salesList.Count - 1], dmdPrtPtnWork);
                            }
                        }

                        if (billDmdPrintParameter.ExistsSalesFooter)
                        {
                            //最後の売上フッタ
                            ReflectSalesFooter(ref table, salesList[salesList.Count - 1], dmdPrtPtnWork, billDmdPrintParameter, headWork);
                        }

                        if (billDmdPrintParameter.ExistsSalesFooter2)
                        {
                            //最後の売上フッタ２
                            ReflectSalesFooter2(ref table, salesList[salesList.Count - 1], dmdPrtPtnWork, billDmdPrintParameter, headWork);
                        }
                        if (billDmdPrintParameter.ExistsSalesFooter3)
                        {
                            //最後の売上フッタ３
                            ReflectSalesFooter3(ref table, salesList[salesList.Count - 1], dmdPrtPtnWork, billDmdPrintParameter, headWork);
                        }
                        if (billDmdPrintParameter.ExistsSalesTotalFooter)
                        {
                            // 最後の伝票計からの集計行
                            ReflectSummalyFooters(ref table, salesList[salesList.Count - 1], dmdPrtPtnWork, SortRecordDivState.Sales, billDmdPrintParameter);
                        }
                        // --- ADD START 田村顕成 2022/10/18 ----->>>>>
                        // 税率別合計タイトル
                        if ((ReportItemDic.ContainsKey("TAX.HFTOTALCONSTAXRATETITLERF") ||
                            ReportItemDic.ContainsKey("TAX.HFTOTALSALESMONEYTAXEXCRF") ||
                              ReportItemDic.ContainsKey("TAX.HFTAXRATE1RF") ||
                                ReportItemDic.ContainsKey("TAX.HFTAXRATE1SALESTAXEXCRF") ||
                                  ReportItemDic.ContainsKey("TAX.DTLRTOTALCONSTAXRATETITLERF") ||
                                    ReportItemDic.ContainsKey("TAX.DTLTOTALSALESMONEYTAXEXCRF") ||
                                      ReportItemDic.ContainsKey("TAX.DTLTAXRATE1RF") ||
                                        ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXEXCRF")))
                        {
                            bChgFlg = true;
                            EBooksFrePBillDetailWork salesData = salesList[salesList.Count - 1];
                            // 税率別情報集計
                            SalesMeisaiTaxMoneyDiffCalc(1, headWork.CSTCLM_SALESCNSTAXFRCPROCCDRF, salesData, bChgFlg,
                                               ref lTaxRate1SalesMoneyEx, ref lTaxRate1SalesPriceConsTax,
                                                 ref lTaxRate2SalesMoneyEx, ref lTaxRate2SalesPriceConsTax,
                                                   ref lOtherSalesMoneyEx, ref lOtherSalesPriceConsTax,
                                                     ref lTaxRate1MeisaiTotalTax, ref lTaxRate2MeisaiTotalTax, ref lOtherMeisaiTotalTax,
                                                       ref lSalesMoneyEx, ref lSalesMoneyExTaxOut,
                                                         ref dicCustomerCode,
                                                           dTaxRate1, dTaxRate2);
                        }
                        // --- ADD END   田村顕成 2022/10/18 -----<<<<<
                    }
                    else
                    {
                        if (billDmdPrintParameter.ExistsSalesTotalFooter)
                        {
                            // 最後の伝票計からの集計行
                            ReflectSummalyFooters(ref table, salesList[salesList.Count - 1], dmdPrtPtnWork, SortRecordDivState.Sales, billDmdPrintParameter);
                        }
                        // --- ADD START 田村顕成 2022/10/18 ----->>>>>
                        // 税率別合計タイトル
                        if ((ReportItemDic.ContainsKey("TAX.HFTOTALCONSTAXRATETITLERF") ||
                            ReportItemDic.ContainsKey("TAX.HFTOTALSALESMONEYTAXEXCRF") ||
                              ReportItemDic.ContainsKey("TAX.HFTAXRATE1RF") ||
                                ReportItemDic.ContainsKey("TAX.HFTAXRATE1SALESTAXEXCRF") ||
                                  ReportItemDic.ContainsKey("TAX.DTLRTOTALCONSTAXRATETITLERF") ||
                                    ReportItemDic.ContainsKey("TAX.DTLTOTALSALESMONEYTAXEXCRF") ||
                                      ReportItemDic.ContainsKey("TAX.DTLTAXRATE1RF") ||
                                        ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXEXCRF")))
                        {
                            bChgFlg = true;
                            EBooksFrePBillDetailWork salesData = salesList[salesList.Count - 1];
                            // 税率別情報集計
                            SalesMeisaiTaxMoneyDiffCalc(1, headWork.CSTCLM_SALESCNSTAXFRCPROCCDRF, salesData, bChgFlg,
                                               ref lTaxRate1SalesMoneyEx, ref lTaxRate1SalesPriceConsTax,
                                                 ref lTaxRate2SalesMoneyEx, ref lTaxRate2SalesPriceConsTax,
                                                   ref lOtherSalesMoneyEx, ref lOtherSalesPriceConsTax,
                                                     ref lTaxRate1MeisaiTotalTax, ref lTaxRate2MeisaiTotalTax, ref lOtherMeisaiTotalTax,
                                                       ref lSalesMoneyEx, ref lSalesMoneyExTaxOut,
                                                         ref dicCustomerCode,
                                                           dTaxRate1, dTaxRate2);
                        }
                        // --- ADD END   田村顕成 2022/10/18 -----<<<<<
                    }
                    # endregion
                }

                //--------------------------------------------------------
                // 入金明細コピー
                //--------------------------------------------------------
                if (depositList != null && depositList.Count > 0)
                {
                    # region [入金明細]
                    switch (dmdPrtPtnWork.DepoDtlPrcPrtDiv)
                    {
                        case 1:
                            {
                                // 印字する（合計）
                                for (int index = 0; index < depositList.Count; index++)
                                {
                                    if (index > 0 && depositList[index - 1].DEPSITMAINRF_DEPOSITSLIPNORF == depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF)
                                    {
                                        // １つ前と同一の入金伝票ならば迂回
                                        continue;
                                    }

                                    DataRow row = table.NewRow();

                                    # region [入金明細(合計)]
                                    row["DEPSITMAINRF.ACPTANODRSTATUSRF"] = depositList[index].DEPSITMAINRF_ACPTANODRSTATUSRF;
                                    row["DEPSITMAINRF.DEPOSITSLIPNORF"] = depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF;
                                    row["DEPSITMAINRF.SALESSLIPNUMRF"] = depositList[index].DEPSITMAINRF_SALESSLIPNUMRF;
                                    row["DEPSITMAINRF.ADDUPSECCODERF"] = depositList[index].DEPSITMAINRF_ADDUPSECCODERF;
                                    row["DEPSITMAINRF.SUBSECTIONCODERF"] = depositList[index].DEPSITMAINRF_SUBSECTIONCODERF;
                                    row["DEPSITMAINRF.DEPOSITDATERF"] = depositList[index].DEPSITMAINRF_DEPOSITDATERF;
                                    row["DEPSITMAINRF.ADDUPADATERF"] = depositList[index].DEPSITMAINRF_ADDUPADATERF;
                                    row["DEPSITMAINRF.DEPOSITRF"] = GetDepositTotal(depositList[index]);//depositList[index].DEPSITMAINRF_DEPOSITRF;
                                    row["DEPSITMAINRF.FEEDEPOSITRF"] = depositList[index].DEPSITMAINRF_FEEDEPOSITRF;
                                    row["DEPSITMAINRF.DISCOUNTDEPOSITRF"] = depositList[index].DEPSITMAINRF_DISCOUNTDEPOSITRF;
                                    row["DEPSITMAINRF.AUTODEPOSITCDRF"] = depositList[index].DEPSITMAINRF_AUTODEPOSITCDRF;
                                    row["DEPSITMAINRF.DEPOSITCDRF"] = depositList[index].DEPSITMAINRF_DEPOSITCDRF;
                                    row["DEPSITMAINRF.DRAFTDRAWINGDATERF"] = depositList[index].DEPSITMAINRF_DRAFTDRAWINGDATERF;
                                    row["DEPSITMAINRF.DRAFTKINDRF"] = depositList[index].DEPSITMAINRF_DRAFTKINDRF;
                                    row["DEPSITMAINRF.DRAFTKINDNAMERF"] = depositList[index].DEPSITMAINRF_DRAFTKINDNAMERF;
                                    row["DEPSITMAINRF.DRAFTDIVIDENAMERF"] = depositList[index].DEPSITMAINRF_DRAFTDIVIDENAMERF;
                                    row["DEPSITMAINRF.DRAFTNORF"] = depositList[index].DEPSITMAINRF_DRAFTNORF;
                                    row["DEPSITMAINRF.CUSTOMERCODERF"] = depositList[index].DEPSITMAINRF_CUSTOMERCODERF;
                                    row["DEPSITMAINRF.CLAIMCODERF"] = depositList[index].DEPSITMAINRF_CLAIMCODERF;
                                    row["DEPSITMAINRF.OUTLINERF"] = depositList[index].DEPSITMAINRF_OUTLINERF;
                                    row["SUBDEP.SUBSECTIONNAMERF"] = depositList[index].SUBDEP_SUBSECTIONNAMERF;
                                    row["DEPSITDTLRF.DEPOSITSLIPNORF"] = depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF;
                                    row["DEPSITDTLRF.DEPOSITROWNORF"] = DBNull.Value;
                                    row["DEPSITDTLRF.MONEYKINDCODERF"] = DBNull.Value;
                                    row["DEPSITDTLRF.MONEYKINDNAMERF"] = "入金";
                                    row["DEPSITDTLRF.MONEYKINDDIVRF"] = DBNull.Value;
                                    row["DEPSITDTLRF.DEPOSITRF"] = row["DEPSITMAINRF.DEPOSITRF"];
                                    row["DEPSITDTLRF.VALIDITYTERMRF"] = DBNull.Value;
                                    row[ct_col_DDep_MoneyKindNameSp] = "入　金";
                                    # endregion

                                    # region [入金明細(合計)(自動以外)]
                                    // 日付展開
                                    # region [日付展開]
                                    // (通常)
                                    ExtractDate(ref row, allDefSet.EraNameDispCd2, depositList[index].DEPSITMAINRF_DEPOSITDATERF, "DADD.DEPOSITDATE", false); // yyyymmdd
                                    ExtractDate(ref row, allDefSet.EraNameDispCd2, depositList[index].DEPSITMAINRF_DRAFTDRAWINGDATERF, "DADD.DRAFTDRAWINGDATE", false); // yyyymmdd
                                    ExtractDate(ref row, allDefSet.EraNameDispCd2, depositList[index].DEPSITDTLRF_VALIDITYTERMRF, "DADD.VALIDITYTERM", false); // yyyymmdd
                                    # endregion

                                    // ソート・合計対応
                                    # region [ソート・合計対応]
                                    row[ct_col_Sort_CustomerCode] = depositList[index].DEPSITMAINRF_CUSTOMERCODERF;
                                    row[ct_col_Sort_Date] = depositList[index].DEPSITMAINRF_DEPOSITDATERF;
                                    row[ct_col_Sort_RecordDiv] = SortRecordDivState.Deposit;
                                    row[ct_col_Sort_SalesSlipNo] = string.Empty;
                                    row[ct_col_Sort_DepositSlipNo] = depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF;
                                    row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                                    row[ct_col_Sort_DetailRowNo] = GetDepositRowNoForSort( depositList[index] );
                                    row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Deposit;
                                    # endregion

                                    // 伝票合計請求書用 明細タイトル
                                    # region [伝票合計請求書用 明細タイトル]
                                    row["DDEP.DETAILTITLERF"] = "入  金";
                                    # endregion

                                    // 未設定時 非印字コード
                                    # region [未設定]
                                    if (IsZero(depositList[index].DEPSITMAINRF_ADDUPSECCODERF)) row["DEPSITMAINRF.ADDUPSECCODERF"] = DBNull.Value; // 計上拠点コード
                                    if (IsZero(depositList[index].DEPSITMAINRF_SUBSECTIONCODERF)) row["DEPSITMAINRF.SUBSECTIONCODERF"] = DBNull.Value; // 部門コード
                                    if (IsZero(depositList[index].DEPSITMAINRF_CUSTOMERCODERF)) row["DEPSITMAINRF.CUSTOMERCODERF"] = DBNull.Value; // 得意先コード
                                    if (IsZero(depositList[index].DEPSITMAINRF_CLAIMCODERF)) row["DEPSITMAINRF.CLAIMCODERF"] = DBNull.Value; // 請求先コード
                                    # endregion
                                    # endregion

                                    table.Rows.Add(row);
                                }
                            }
                            break;
                        case 2:
                            {
                                // 印字する（明細）
                                for (int index = 0; index < depositList.Count; index++)
                                {
                                    # region [入金明細集計行]
                                    if (index > 0 && depositList[index - 1].DEPSITMAINRF_DEPOSITSLIPNORF != depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF)
                                    {
                                        ReflectDepositDetailExtra(ref table, depositList[index - 1], allDefSet);
                                        if (billDmdPrintParameter.ExistsDepositTotalFooter)
                                        {
                                            ReflectDepositSummalyFooters(ref table, depositList[index - 1], dmdPrtPtnWork, SortRecordDivState.Deposit, billDmdPrintParameter, allDefSet);
                                        }
                                    }
                                    # endregion

                                    if (depositList[index].DEPSITDTLRF_DEPOSITRF == 0 && depositList[index].DEPSITMAINRF_FEEDEPOSITRF != 0 ||
                                         depositList[index].DEPSITMAINRF_DEPOSITRF == 0 && depositList[index].DEPSITMAINRF_DISCOUNTDEPOSITRF != 0)
                                    {
                                        // 印字する(明細)の場合は明細単位で金額ゼロ判定    
                                        continue;
                                    }
                                    DataRow row = table.NewRow();

                                    # region [入金明細(明細)]
                                    row["DEPSITMAINRF.ACPTANODRSTATUSRF"] = depositList[index].DEPSITMAINRF_ACPTANODRSTATUSRF;
                                    row["DEPSITMAINRF.DEPOSITSLIPNORF"] = depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF;
                                    row["DEPSITMAINRF.SALESSLIPNUMRF"] = depositList[index].DEPSITMAINRF_SALESSLIPNUMRF;
                                    row["DEPSITMAINRF.ADDUPSECCODERF"] = depositList[index].DEPSITMAINRF_ADDUPSECCODERF;
                                    row["DEPSITMAINRF.SUBSECTIONCODERF"] = depositList[index].DEPSITMAINRF_SUBSECTIONCODERF;
                                    row["DEPSITMAINRF.DEPOSITDATERF"] = depositList[index].DEPSITMAINRF_DEPOSITDATERF;
                                    row["DEPSITMAINRF.ADDUPADATERF"] = depositList[index].DEPSITMAINRF_ADDUPADATERF;
                                    row["DEPSITMAINRF.DEPOSITRF"] = GetDepositTotal(depositList[index]);//depositList[index].DEPSITMAINRF_DEPOSITRF;
                                    row["DEPSITMAINRF.FEEDEPOSITRF"] = depositList[index].DEPSITMAINRF_FEEDEPOSITRF;
                                    row["DEPSITMAINRF.DISCOUNTDEPOSITRF"] = depositList[index].DEPSITMAINRF_DISCOUNTDEPOSITRF;
                                    row["DEPSITMAINRF.AUTODEPOSITCDRF"] = depositList[index].DEPSITMAINRF_AUTODEPOSITCDRF;
                                    row["DEPSITMAINRF.DEPOSITCDRF"] = depositList[index].DEPSITMAINRF_DEPOSITCDRF;
                                    row["DEPSITMAINRF.DRAFTDRAWINGDATERF"] = depositList[index].DEPSITMAINRF_DRAFTDRAWINGDATERF;
                                    row["DEPSITMAINRF.DRAFTKINDRF"] = depositList[index].DEPSITMAINRF_DRAFTKINDRF;
                                    row["DEPSITMAINRF.DRAFTKINDNAMERF"] = depositList[index].DEPSITMAINRF_DRAFTKINDNAMERF;
                                    row["DEPSITMAINRF.DRAFTDIVIDENAMERF"] = depositList[index].DEPSITMAINRF_DRAFTDIVIDENAMERF;
                                    row["DEPSITMAINRF.DRAFTNORF"] = depositList[index].DEPSITMAINRF_DRAFTNORF;
                                    row["DEPSITMAINRF.CUSTOMERCODERF"] = depositList[index].DEPSITMAINRF_CUSTOMERCODERF;
                                    row["DEPSITMAINRF.CLAIMCODERF"] = depositList[index].DEPSITMAINRF_CLAIMCODERF;
                                    row["DEPSITMAINRF.OUTLINERF"] = DBNull.Value;
                                    row["SUBDEP.SUBSECTIONNAMERF"] = depositList[index].SUBDEP_SUBSECTIONNAMERF;
                                    row["DEPSITDTLRF.DEPOSITSLIPNORF"] = depositList[index].DEPSITDTLRF_DEPOSITSLIPNORF;
                                    row["DEPSITDTLRF.DEPOSITROWNORF"] = depositList[index].DEPSITDTLRF_DEPOSITROWNORF;
                                    row["DEPSITDTLRF.MONEYKINDCODERF"] = depositList[index].DEPSITDTLRF_MONEYKINDCODERF;
                                    row["DEPSITDTLRF.MONEYKINDNAMERF"] = depositList[index].DEPSITDTLRF_MONEYKINDNAMERF;
                                    row["DEPSITDTLRF.MONEYKINDDIVRF"] = depositList[index].DEPSITDTLRF_MONEYKINDDIVRF;
                                    row["DEPSITDTLRF.DEPOSITRF"] = depositList[index].DEPSITDTLRF_DEPOSITRF;
                                    row["DEPSITDTLRF.VALIDITYTERMRF"] = depositList[index].DEPSITDTLRF_VALIDITYTERMRF;
                                    row["DADD.FOOTER3PRINTRF"] = 0;
                                    # endregion
     
                                    # region [入金明細(明細)(自動以外)]
                                    // 日付展開
                                    # region [日付展開]
                                    // (通常)
                                    ExtractDate(ref row, allDefSet.EraNameDispCd2, depositList[index].DEPSITMAINRF_DEPOSITDATERF, "DADD.DEPOSITDATE", false); // yyyymmdd
                                    ExtractDate(ref row, allDefSet.EraNameDispCd2, depositList[index].DEPSITMAINRF_DRAFTDRAWINGDATERF, "DADD.DRAFTDRAWINGDATE", false); // yyyymmdd
                                    ExtractDate(ref row, allDefSet.EraNameDispCd2, depositList[index].DEPSITDTLRF_VALIDITYTERMRF, "DADD.VALIDITYTERM", false); // yyyymmdd
                                    # region [有効期限→手形期日]
                                    row["DADD.DRAFTPAYTIMELIMITFYRF"] = row["DADD.VALIDITYTERMFYRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFSRF"] = row["DADD.VALIDITYTERMFSRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFWRF"] = row["DADD.VALIDITYTERMFWRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFMRF"] = row["DADD.VALIDITYTERMFMRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFDRF"] = row["DADD.VALIDITYTERMFDRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFGRF"] = row["DADD.VALIDITYTERMFGRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFRRF"] = row["DADD.VALIDITYTERMFRRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFLSRF"] = row["DADD.VALIDITYTERMFLSRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFLPRF"] = row["DADD.VALIDITYTERMFLPRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFLYRF"] = row["DADD.VALIDITYTERMFLYRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFLMRF"] = row["DADD.VALIDITYTERMFLMRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFLDRF"] = row["DADD.VALIDITYTERMFLDRF"];
                                    # endregion

                                    // 金種区分名(空白制御あり・内容固定)
                                    row[ct_col_DDep_MoneyKindNameSp] = GetDepMoneyKindNameSp(depositList[index]);
                                    //入金コード(その他に含む)<山西商会対応>
                                    row["DADD.MONEYKINDCODEOTHERRF"] = GetDepMoneyKindCdSp(depositList[index]);
                                    # endregion

                                    // ソート・合計対応
                                    # region [ソート・合計対応]
                                    row[ct_col_Sort_CustomerCode] = depositList[index].DEPSITMAINRF_CUSTOMERCODERF;
                                    row[ct_col_Sort_Date] = depositList[index].DEPSITMAINRF_DEPOSITDATERF;
                                    row[ct_col_Sort_RecordDiv] = SortRecordDivState.Deposit;
                                    row[ct_col_Sort_SalesSlipNo] = string.Empty;
                                    row[ct_col_Sort_DepositSlipNo] = depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF;
                                    row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                                    row[ct_col_Sort_DetailRowNo] = GetDepositRowNoForSort( depositList[index] );
                                    row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Deposit;
                                    # endregion

                                    // 伝票合計請求書用 明細タイトル
                                    # region [伝票合計請求書用 明細タイトル]
                                    row["DDEP.DETAILTITLERF"] = depositList[index].DEPSITDTLRF_MONEYKINDNAMERF;
                                    # endregion

                                    // 未設定時 非印字コード
                                    # region [未設定]
                                    if (IsZero(depositList[index].DEPSITMAINRF_ADDUPSECCODERF)) row["DEPSITMAINRF.ADDUPSECCODERF"] = DBNull.Value; // 計上拠点コード
                                    if (IsZero(depositList[index].DEPSITMAINRF_SUBSECTIONCODERF)) row["DEPSITMAINRF.SUBSECTIONCODERF"] = DBNull.Value; // 部門コード
                                    if (IsZero(depositList[index].DEPSITMAINRF_CUSTOMERCODERF)) row["DEPSITMAINRF.CUSTOMERCODERF"] = DBNull.Value; // 得意先コード
                                    if (IsZero(depositList[index].DEPSITMAINRF_CLAIMCODERF)) row["DEPSITMAINRF.CLAIMCODERF"] = DBNull.Value; // 請求先コード
                                    # endregion
                                    # endregion

                                    table.Rows.Add(row);
                                }
                                // 最終明細の集計行
                                # region [最終明細の集計行]
                                // 入金明細（入金値引・入金手数料）追加処理
                                ReflectDepositDetailExtra(ref table, depositList[depositList.Count - 1], allDefSet);
                                if (billDmdPrintParameter.ExistsDepositTotalFooter)
                                {
                                    ReflectDepositSummalyFooters(ref table, depositList[depositList.Count - 1], dmdPrtPtnWork, SortRecordDivState.Deposit, billDmdPrintParameter, allDefSet);
                                }
                                # endregion
                            }
                            break;
                        case 0:
                        default:
                            {
                                // 印字しない
                            }
                            break;
                    }
                    # endregion
                }

                //--------------------------------------------------------
                // 並び替え
                //--------------------------------------------------------
                # region [SortOrder]
                switch (dmdPrtPtnWork.DmdDtlPtnOdrDiv)
                {
                    case 0:
                        {
                            // 0:計上日+伝票番号
                            table.DefaultView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                                           ct_col_Sort_Date,
                                                           ct_col_Sort_RecordDiv,
                                                           ct_col_Sort_SalesSlipNo,
                                                           ct_col_Sort_DepositSlipNo,
                                                           ct_col_Sort_DetailDiv,
                                                           ct_col_Sort_DetailRowNo);
                        }
                        break;
                    case 1:
                        {
                            // 1:得意先+計上日+伝票番号
                            table.DefaultView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                                                          ct_col_Sort_CustomerCode,
                                                          ct_col_Sort_Date,
                                                          ct_col_Sort_RecordDiv,
                                                          ct_col_Sort_SalesSlipNo,
                                                          ct_col_Sort_DepositSlipNo,
                                                          ct_col_Sort_DetailDiv,
                                                          ct_col_Sort_DetailRowNo);
                        }
                        break;
                    case 2:
                        {
                            // 2:売上/入金+計上日+伝票番号
                            table.DefaultView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                                          ct_col_Sort_RecordDiv_EmptyDetail,
                                                          ct_col_Sort_Date,
                                                          ct_col_Sort_SalesSlipNo,
                                                          ct_col_Sort_DepositSlipNo,
                                                          ct_col_Sort_DetailDiv,
                                                          ct_col_Sort_DetailRowNo
                                                         );
                        }
                        break;
                    case 3:
                        {
                            // 3:売上/入金+得意先+計上日+伝票番号
                            table.DefaultView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                                                          ct_col_Sort_RecordDiv_EmptyDetail,
                                                          ct_col_Sort_CustomerCode,
                                                          ct_col_Sort_Date,
                                                          ct_col_Sort_SalesSlipNo,
                                                          ct_col_Sort_DepositSlipNo,
                                                          ct_col_Sort_DetailDiv,
                                                          ct_col_Sort_DetailRowNo);
                        }
                        break;
                }
                # endregion


                ////--------------------------------------------------------
                //// 空行埋め
                ////--------------------------------------------------------
                // レイアウト行数
                int feedCount = frePrtPSetWork.FormFeedLineCount;
                if (feedCount == 0) feedCount = 1;

                //--------------------------------------------------------
                // サプレス処理
                //--------------------------------------------------------
                // ヘッダをコピーする行
                List<int> headCopyRowIndexList = new List<int>();
                // 最初と最後は確実にセット必要
                headCopyRowIndexList.Add(0);

                List<DataRow> addRowList = new List<DataRow>();
                List<DataRow> delRowList = new List<DataRow>();
                int head2RowCount = 0;
                int page = 1;
                int head2RowDelCount = 0;
                int pageCount = 1;
                int prevPageCount = 0;

                // レコード区分間空白行追加が張られている時だけ処理を行う
                if (ReportItemDic.ContainsKey("DADD.RECORDDIVSPACERF"))
                {
                    // データのソート
                    DataTable table2 = table.Clone();
                    DataView dv = new DataView(table);
                    dv.Sort = table.DefaultView.Sort;
                    foreach (DataRowView drv in dv)
                    {
                        table2.ImportRow(drv.Row);
                    }

                    // ソート後のテーブルに書換え
                    table.Clear();
                    table = table2.Copy();

                    // 空白行を挿入するIndexの取得
                    List<int> insIndexList = new List<int>();
                    SortRecordDivState prevSortRecordDivState = SortRecordDivState.Sales;
                    foreach (DataRow dr in table.Rows)
                    {
                        int index = table.Rows.IndexOf(dr);
                        if (index != 0)
                        {
                            if ((SortRecordDivState)dr[ct_col_Sort_RecordDiv] != prevSortRecordDivState)
                            {
                                insIndexList.Add(index + insIndexList.Count);
                                prevSortRecordDivState = (SortRecordDivState)dr[ct_col_Sort_RecordDiv];
                            }
                        }
                        else
                        {
                            prevSortRecordDivState = (SortRecordDivState)table.DefaultView[index].Row[ct_col_Sort_RecordDiv];
                        }
                    }

                    // 空白行の挿入
                    foreach (int insIndex in insIndexList)
                    {
                        DataRow row = table.NewRow();
                        # region [ソート・合計対応]
                        row[ct_col_Sort_CustomerCode] = table.Rows[insIndex][ct_col_Sort_CustomerCode];
                        row[ct_col_Sort_Date] = table.Rows[insIndex][ct_col_Sort_Date];
                        row[ct_col_Sort_RecordDiv] = prevSortRecordDivState;
                        row[ct_col_Sort_SalesSlipNo] = table.Rows[insIndex][ct_col_Sort_SalesSlipNo];
                        row[ct_col_Sort_DepositSlipNo] = 0;
                        row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                        row[ct_col_Sort_DetailRowNo] = 0;
                        row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                        row["DADD.FOOTER3PRINTRF"] = 97;

                        table.Rows.InsertAt(row, insIndex);
                        # endregion
                    }

                    // 頁数再取得
                    // ヘッダをコピーする行
                    headCopyRowIndexList = new List<int>();
                    // 最初と最後は確実にセット必要
                    headCopyRowIndexList.Add(0);
                    for (int index = 0; index < table.DefaultView.Count; index++)
                    {
                        DataRow row = table.DefaultView[index].Row;

                        int indexCount = index + head2RowCount - head2RowDelCount;
                        if (indexCount + 1 <= feedCount)
                        {
                            pageCount = 1;
                        }
                        else
                        {
                            pageCount = (int)((indexCount - feedCount) / (feedCount + billDmdPrintParameter.OtherFeedAddCount)) + 2;
                        }
                        if (pageCount != prevPageCount && indexCount > 0)
                        {
                            headCopyRowIndexList.Add(indexCount - 1);
                            headCopyRowIndexList.Add(indexCount);
                        }
                        row[ct_col_PageCount] = pageCount;
                        prevPageCount = pageCount;
                    }
                }
                if (ReportItemDic.ContainsKey("DADD.SALESMONEYALLDETAILTTLRF"))
                {
                    DataRow row = table.NewRow();
                    Int64 allDetailTtl = 0;
                    foreach (DataRow dr in table.Rows)
                    {
                        if ((SortDetailDivState)dr[ct_col_Sort_DetailDiv] == SortDetailDivState.Detail)
                        {
                            if (dr["SALESDETAILRF.SALESMONEYTAXEXCRF"] != DBNull.Value)
                            {
                                allDetailTtl = allDetailTtl + Convert.ToInt64(dr["SALESDETAILRF.SALESMONEYTAXEXCRF"]); // 売上金額（税抜き）
                            }
                        }
                    }
                    row["DADD.SALESMONEYALLDETAILTTLRF"] = allDetailTtl;
                    row["DADD.SALESFTTITLERF"] = "明細合計";
                    # region [ソート・合計対応]
                    row[ct_col_Sort_CustomerCode] = 999999999;
                    row[ct_col_Sort_Date] = 99999999;
                    row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                    row[ct_col_Sort_SalesSlipNo] = string.Empty;
                    row[ct_col_Sort_DepositSlipNo] = 0;
                    row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                    row[ct_col_Sort_DetailRowNo] = 0;
                    row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.EmptyDetail;
                    row[ct_col_PageCount] = pageCount;
                    # endregion
                    table.Rows.Add(row);
                }

                # region [サプレス]
                GroupSuppressKey keyOfDate;
                GroupSuppressKey keyOfSlipNo;
                GroupSuppressKey keyOfCar;
                GroupSuppressKey prevKeyOfDate = GroupSuppressKey.Create();
                GroupSuppressKey prevKeyOfSlipNo = GroupSuppressKey.Create();
                GroupSuppressKey prevKeyOfCar = GroupSuppressKey.Create();

                GroupSuppressKey keyOfDate2;
                GroupSuppressKey keyOfSlipNo2;
                GroupSuppressKey prevKeyOfDate2 = GroupSuppressKey.Create(); ;
                GroupSuppressKey prevKeyOfSlipNo2 = GroupSuppressKey.Create(); ;

                string note2temp = string.Empty;

                for (int index = 0; index < table.DefaultView.Count; index++)
                {
                    DataRow row = table.DefaultView[index].Row;

                    int indexCount = index + head2RowCount - head2RowDelCount;
                    if (indexCount + 1 <= feedCount)
                    {
                        pageCount = 1;
                    }
                    else
                    {
                        pageCount = (int)((indexCount - feedCount) / (feedCount + billDmdPrintParameter.OtherFeedAddCount)) + 2;
                    }
                    if ( pageCount != prevPageCount && indexCount > 0 )
                    {
                        headCopyRowIndexList.Add(indexCount - 1);
                        headCopyRowIndexList.Add(indexCount);
                    }
                    row[ct_col_PageCount] = pageCount;
                    prevPageCount = pageCount;
                    // 最終ページを取得
                    _pageCount = pageCount;


                    #region[山西商会対応]
                    if (billDmdPrintParameter.ExistsSalesHeader2)
                    {
                        DataRow header2Row = table.NewRow();

                        //今のページ数と比較
                        if (page != 0 && page != pageCount)
                        {
                            //ページの１行目がヘッダ行 or 入金行 
                            if ((SortDetailDivState)row[ct_col_Sort_DetailDiv] != SortDetailDivState.Header && (SortRecordDivState)row[ct_col_Sort_RecordDiv] != SortRecordDivState.Deposit)
                            {
                                if ((SortDetailDivState)row[ct_col_Sort_DetailDiv] == SortDetailDivState.Detail)
                                {
                                    int rowCount;

                                   //明細の途中で追加したヘッダ
                                   if ((int)row["DADD.FOOTER3PRINTRF"] == 0)
                                   {
                                   }
                                   //明細行
                                   else if((int)row["DADD.FOOTER3PRINTRF"] == 1)
                                   {
                                       rowCount = (int)row[ct_col_Sort_DetailRowNo] - 5;
                                       ReflectSalesHeader2NewPage(ref header2Row, row, allDefSet, pageCount, rowCount);
                                       //ヘッダ行を追加したら＋1
                                       head2RowCount += 1;
                                       addRowList.Add(header2Row);
                                   }
                                    //伝票備考行の場合
                                    else if ((int)row["DADD.FOOTER3PRINTRF"] == 96)
                                    {
                                        DataRow prevRow = table.DefaultView[index - 1].Row;
                                        rowCount = (int)prevRow[ct_col_Sort_DetailRowNo] + 5;

                                        //ReflectSalesHeader2NewPage(ref header2Row, prevRow, allDefSet, pageCount, detailRowNo);
                                        ReflectSalesHeader2NewPage(ref header2Row, prevRow, allDefSet, pageCount, rowCount);
                                        //ヘッダ行を追加したら＋1
                                        head2RowCount += 1;
                                        addRowList.Add(header2Row);
                                    }
                                    //伝票計行の場合
                                    else if ((int)row["DADD.FOOTER3PRINTRF"] == 97)
                                    {
                                        DataRow prevRowofSlip = table.DefaultView[index - 2].Row;
                                        rowCount = (int)prevRowofSlip[ct_col_Sort_DetailRowNo] + 15;
                                        ReflectSalesHeader2NewPage(ref header2Row, prevRowofSlip, allDefSet, pageCount, rowCount);
                                        //ヘッダ行を追加したら＋1
                                        head2RowCount += 1;
                                        addRowList.Add(header2Row);
                                    }
                                    //消費税行の場合
                                    else if ((int)row["DADD.FOOTER3PRINTRF"] == 98)
                                    {
                                        DataRow prevRowofTax = table.DefaultView[index - 3].Row;
                                        rowCount = (int)prevRowofTax[ct_col_Sort_DetailRowNo] + 25;
                                        ReflectSalesHeader2NewPage(ref header2Row, prevRowofTax, allDefSet, pageCount, rowCount);
                                        //ヘッダ行を追加したら＋1
                                        head2RowCount += 1;
                                        addRowList.Add(header2Row);
                                    }
                                    //空白行の場合
                                    else if ((int)row["DADD.FOOTER3PRINTRF"] == 99)
                                    {
                                        DataRow prevRowofDel = table.DefaultView[index - 4].Row;
                                        rowCount = (int)prevRowofDel[ct_col_Sort_DetailRowNo] + 35;
                                        ReflectSalesHeader2NewPage(ref header2Row, prevRowofDel, allDefSet, pageCount, rowCount);
                                        delRowList.Add(row);
                                        head2RowDelCount += 1;
                                    }
                                }
                            }                            
                        }
                        //ひとつ前のページ数をとっておく
                        page = pageCount;
                    }
                    #endregion

                    //---------------------------------------
                    // 今回キー取得
                    //---------------------------------------
                    // 日付
                    keyOfDate = GroupSuppressKey.CreateKeyOfDate(row);
                    // 伝票番号
                    keyOfSlipNo = GroupSuppressKey.CreateKeyOfSlipNo(row);
                    // 型式・車種名・年式
                    keyOfCar = GroupSuppressKey.CreateKeyOfCar(row);
                    // 日付２
                    keyOfDate2 = GroupSuppressKey.CreateKeyOfDate2(row);
                    // 伝票番号２
                    keyOfSlipNo2 = GroupSuppressKey.CreateKeyOfSlipNo2(row);

                    //---------------------------------------
                    // サプレス判定・サプレス処理
                    //---------------------------------------
                    if (prevKeyOfDate.CompareTo(keyOfDate) == 0) SuppressOfDate(ref row);
                    if (prevKeyOfSlipNo.CompareTo(keyOfSlipNo) == 0) SuppressOfSlipNo(ref row);
                    if (prevKeyOfCar.CompareTo(keyOfCar) == 0) SuppressOfCar(ref row);
                    if (ReportItemDic.ContainsKey("DADD.CARMNGNO2RF"))
                    {
                        // （先頭）車輌管理番号（明細２行目印字）が存在する場合は日付と伝票番号においてページ数をキーから外す
                        if (prevKeyOfDate2.CompareTo(keyOfDate2) == 0) SuppressOfDate(ref row);
                        if (prevKeyOfSlipNo2.CompareTo(keyOfSlipNo2) == 0) SuppressOfSlipNo(ref row);
                    }
                    // 合計行に日付・伝票番号を印字しない
                    if ((SortDetailDivState)row[ct_col_Sort_DetailDiv] == SortDetailDivState.Footer)
                    {
                        // 売上
                        row["SALESSLIPRF.SALESSLIPNUMRF"] = DBNull.Value;
                        row["SALESSLIPRF.SALESDATERF"] = DBNull.Value;
                        row["SALESSLIPRF.PARTYSALESLIPNUMRF"] = DBNull.Value;
                        // 入金
                        row["DEPSITMAINRF.DEPOSITDATERF"] = DBNull.Value;
                        ExtractDate(ref row, allDefSet.EraNameDispCd2, DateTime.MinValue, "DADD.DEPOSITDATE", false); // yyyymmdd
                        row["DEPSITMAINRF.DEPOSITSLIPNORF"] = DBNull.Value;
                    }

                    //---------------------------------------
                    // 前回情報退避
                    //---------------------------------------
                    prevKeyOfDate = keyOfDate;
                    prevKeyOfSlipNo = keyOfSlipNo;
                    prevKeyOfCar = keyOfCar;
                    prevKeyOfDate2 = keyOfDate2;
                    prevKeyOfSlipNo2 = keyOfSlipNo2;
                }

                //取っておいた行を追加tableに順番に追加
                #region[山西商会個別]
                if (billDmdPrintParameter.ExistsSalesHeader2)
                {
                    //foreachでdatarowのリストをaddする
                    foreach (DataRow headerRow in addRowList)
                    {
                        table.Rows.Add(headerRow);
                    }
                    //空白行がある場合は削除
                    foreach (DataRow headerDelRow in delRowList)
                    {
                        table.Rows.Remove(headerDelRow);
                    }
                }

                #endregion

                # endregion
                // --- ADD START 田村顕成 2022/10/18 ----->>>>>
                if ((ReportItemDic.ContainsKey("TAX.HFTOTALCONSTAXRATETITLERF") ||
                    ReportItemDic.ContainsKey("TAX.HFTOTALSALESMONEYTAXEXCRF") ||
                      ReportItemDic.ContainsKey("TAX.HFTAXRATE1RF") ||
                        ReportItemDic.ContainsKey("TAX.HFTAXRATE1SALESTAXEXCRF") ||
                          ReportItemDic.ContainsKey("TAX.DTLTOTALCONSTAXRATETITLERF") ||
                            ReportItemDic.ContainsKey("TAX.DTLTOTALSALESMONEYTAXEXCRF") ||
                              ReportItemDic.ContainsKey("TAX.DTLTAXRATE1RF") ||
                                ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXEXCRF")))
                {
                    // 売上データ存在の場合
                    if (salesList.Count != 0)
                    {
                        bool isParent = (headWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0);
                      
                        SalesTotalTaxMoneyDiffCalc(headWork.CSTCLM_SALESCNSTAXFRCPROCCDRF, headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF,
                                                    lTaxRate1SalesMoneyEx, lTaxRate1SalesPriceConsTax,
                                                      lTaxRate2SalesMoneyEx, lTaxRate2SalesPriceConsTax,
                                                        lSalesMoneyExTaxOut,
                                                          lOtherSalesMoneyEx, lOtherSalesPriceConsTax,
                                                            dicCustomerCode,
                                                              dTaxRate1, dTaxRate2,
                                                                out TotalTaxRateSalesMoney);
                        #region [税率別合計行を追加]
                        DataRow row = table.NewRow();
                        if (ReportItemDic.ContainsKey("TAX.DTLTOTALCONSTAXRATETITLERF") ||                        // 税率別合計タイトル[明細]
                             ReportItemDic.ContainsKey("TAX.DTLTOTALSALESMONEYTAXEXCRF"))                         // 税率別合計金額[明細]
                        {
                            row["TAX.DTLTOTALCONSTAXRATETITLERF"] = "*合 計*";
                            // 合計金額=税率１金額 + 税率２金額 + 非課税金額 + その他金額
                            row["TAX.DTLTOTALSALESMONEYTAXEXCRF"] = TotalTaxRateSalesMoney.TaxRate1SalesMoney + TotalTaxRateSalesMoney.TaxRate2SalesMoney + TotalTaxRateSalesMoney.TaxOutSalesMoney + TotalTaxRateSalesMoney.OtherSalesMoney;
                            # region [ソート・合計対応]
                            row[ct_col_Sort_CustomerCode] = 999999999;
                            row[ct_col_Sort_Date] = 99999999;
                            row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                            row[ct_col_Sort_SalesSlipNo] = string.Empty;
                            row[ct_col_Sort_DepositSlipNo] = 0;
                            row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                            row[ct_col_Sort_DetailRowNo] = 0;
                            row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.EmptyDetail;
                            row[ct_col_PageCount] = pageCount;
                            # endregion
                            table.Rows.Add(row);
                        }
                        #endregion

                        #region [税率別「税率１」行を追加]
                        if (ReportItemDic.ContainsKey("TAX.DTLTAXTITLERF") ||                                    // 税率別税率タイトル[明細]
                             ReportItemDic.ContainsKey("TAX.DTLTAXRATE1RF") ||                                   // 税率１[明細]
                               ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXEXCRF") ||                      // 税率１(税抜き)[明細]
                                 ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXRF"))                         // 税率１消費税[明細]
                        {
                            row = table.NewRow();
                            row["TAX.DTLTAXRATE1RF"] = Convert.ToString(dTaxRate1 * 100) + "%";
                            row["TAX.DTLTAXRATE1SALESTAXEXCRF"] = TotalTaxRateSalesMoney.TaxRate1SalesMoney;
                            if (isParent)
                            {
                                row["TAX.DTLTAXTITLERF"] = "税";
                                row["TAX.DTLTAXRATE1SALESTAXRF"] = TotalTaxRateSalesMoney.TaxRate1SalesPriceConsTax;
                            }
                            # region [ソート・合計対応]
                            row[ct_col_Sort_CustomerCode] = 999999999;
                            row[ct_col_Sort_Date] = 99999999;
                            row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                            row[ct_col_Sort_SalesSlipNo] = string.Empty;
                            row[ct_col_Sort_DepositSlipNo] = 0;
                            row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                            row[ct_col_Sort_DetailRowNo] = 0;
                            row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.EmptyDetail;
                            row[ct_col_PageCount] = pageCount;
                            # endregion
                            table.Rows.Add(row);
                        }
                        #endregion

                        #region [税率別「税率２」行を追加]
                        if (ReportItemDic.ContainsKey("TAX.DTLTAXTITLERF") ||                                    // 税率別税率タイトル[明細]
                              ReportItemDic.ContainsKey("TAX.DTLTAXRATE2RF") ||                                  // 税率２[明細]
                                ReportItemDic.ContainsKey("TAX.DTLTAXRATE2SALESTAXEXCRF") ||                     // 税率２(税抜き)[明細]
                                  ReportItemDic.ContainsKey("TAX.DTLTAXRATE2SALESTAXRF"))                        // 税率２消費税[明細]
                        {
                            row = table.NewRow();
                            row["TAX.DTLTAXRATE2RF"] = Convert.ToString(dTaxRate2 * 100) + "%";
                            row["TAX.DTLTAXRATE2SALESTAXEXCRF"] = TotalTaxRateSalesMoney.TaxRate2SalesMoney;
                            if (isParent)
                            {
                                row["TAX.DTLTAXTITLERF"] = "税";
                                row["TAX.DTLTAXRATE2SALESTAXRF"] = TotalTaxRateSalesMoney.TaxRate2SalesPriceConsTax; ;
                            }
                            # region [ソート・合計対応]
                            row[ct_col_Sort_CustomerCode] = 999999999;
                            row[ct_col_Sort_Date] = 99999999;
                            row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                            row[ct_col_Sort_SalesSlipNo] = string.Empty;
                            row[ct_col_Sort_DepositSlipNo] = 0;
                            row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                            row[ct_col_Sort_DetailRowNo] = 0;
                            row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.EmptyDetail;
                            row[ct_col_PageCount] = pageCount;
                            # endregion
                            table.Rows.Add(row);
                        }
                        #endregion
                        #region [税率別「非課税」行を追加]
                        if (ReportItemDic.ContainsKey("TAX.DTLTAXOUTITLERF") ||                                     // 非課税タイトル[明細]
                              ReportItemDic.ContainsKey("TAX.DTLTAXOUTSALESTAXEXCRF"))                              // 非課税売上金額(税抜き)
                        {
                            row = table.NewRow();
                            row["TAX.DTLTAXOUTITLERF"] = "非課税";
                            row["TAX.DTLTAXOUTSALESTAXEXCRF"] = TotalTaxRateSalesMoney.TaxOutSalesMoney;
                            # region [ソート・合計対応]
                            row[ct_col_Sort_CustomerCode] = 999999999;
                            row[ct_col_Sort_Date] = 99999999;
                            row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                            row[ct_col_Sort_SalesSlipNo] = string.Empty;
                            row[ct_col_Sort_DepositSlipNo] = 0;
                            row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                            row[ct_col_Sort_DetailRowNo] = 0;
                            row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.EmptyDetail;
                            row[ct_col_PageCount] = pageCount;
                            # endregion
                            table.Rows.Add(row);
                        }
                        #endregion

                        #region [税率別「その他」行を追加]
                        if (ReportItemDic.ContainsKey("TAX.DTLTAXTITLERF") ||                                     // 税率別税率タイトル[明細]
                              ReportItemDic.ContainsKey("TAX.DTLOTHERTAXRATERF") ||                               // その他税率[明細]            
                                ReportItemDic.ContainsKey("TAX.DTLOTHERTAXRATESALESTAXEXCRF") ||                  // その他税率(税抜き)[明細]
                                  ReportItemDic.ContainsKey("TAX.DTLOTHERTAXRATESALESTAXRF"))                     // その他税率消費税[明細]
                        {
                            row = table.NewRow();
                            row["TAX.DTLOTHERTAXRATERF"] = "その他";
                            row["TAX.DTLOTHERTAXRATESALESTAXEXCRF"] = TotalTaxRateSalesMoney.OtherSalesMoney;
                            if (isParent)
                            {
                                row["TAX.DTLTAXTITLERF"] = "税";
                                row["TAX.DTLOTHERTAXRATESALESTAXRF"] = TotalTaxRateSalesMoney.OtherSalesPriceConsTax;
                            }
                            # region [ソート・合計対応]
                            row[ct_col_Sort_CustomerCode] = 999999999;
                            row[ct_col_Sort_Date] = 99999999;
                            row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                            row[ct_col_Sort_SalesSlipNo] = string.Empty;
                            row[ct_col_Sort_DepositSlipNo] = 0;
                            row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                            row[ct_col_Sort_DetailRowNo] = 0;
                            row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.EmptyDetail;
                            row[ct_col_PageCount] = pageCount;
                            # endregion
                            table.Rows.Add(row);
                        }
                        #endregion

                        for (int index = 0; index < table.DefaultView.Count; index++)
                        {
                            row = table.DefaultView[index].Row;
                            List<string> emptyItemList = new List<string>();
                            //int indexCount = index + head2RowCount - head2RowDelCount;// --- DEL  田村顕成  2023/06/16
                            int indexCount = index;// --- ADD  田村顕成  2023/06/16
                            if (indexCount + 1 <= feedCount)
                            {
                                pageCount = 1;
                            }
                            else
                            {
                                pageCount = (int)((indexCount - feedCount) / (feedCount + billDmdPrintParameter.OtherFeedAddCount)) + 2;
                            }
                            if (pageCount != prevPageCount && indexCount > 0)
                            {
                                headCopyRowIndexList.Add(indexCount - 1);
                                headCopyRowIndexList.Add(indexCount);
                            }
                            row[ct_col_PageCount] = pageCount;
                            prevPageCount = pageCount;
                            // 最終ページを取得
                            _pageCount = pageCount;

                        }

                    }
                }
                // --- ADD END   田村顕成 2022/10/18 -----<<<<<

                //--------------------------------------------------------
                // 空行埋め
                //--------------------------------------------------------
                // 全頁総行数
                int billMaxCount = GetAllDetailCount(table.Rows.Count, feedCount, billDmdPrintParameter.OtherFeedAddCount);
                if (billMaxCount <= 0)
                {
                    billMaxCount = feedCount;
                }
                for (int index = table.Rows.Count; index < billMaxCount; index++)
                {
                    DataRow row = table.NewRow();
                    # region [ソート・合計対応]
                    row[ct_col_Sort_CustomerCode] = 999999999;
                    row[ct_col_Sort_Date] = 99999999;
                    row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                    row[ct_col_Sort_SalesSlipNo] = string.Empty;
                    row[ct_col_Sort_DepositSlipNo] = 0;
                    row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                    row[ct_col_Sort_DetailRowNo] = 0;
                    row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.EmptyDetail;
                    row[ct_col_PageCount] = pageCount;
                    # endregion
                    table.Rows.Add(row);
                }

                //最後の行を追加
                headCopyRowIndexList.Add(table.DefaultView.Count - 1);

                Int64 pageTtl = 0;
                Dictionary<int, Int64> pageTtlList = new Dictionary<int, Int64>();
                // 売上金額頁計が張られている時だけ処理を行う
                if (ReportItemDic.ContainsKey("HADD.SALESMONEYPAGETTLRF"))
                {
                    for (int index = 1; index <= _pageCount; index++)
                    {
                        DataRow[] drs = table.Select(ct_col_PageCount + "=" + index.ToString());
                        pageTtl = 0;
                        foreach (DataRow dr in drs)
                        {
                            if ((SortDetailDivState)dr[ct_col_Sort_DetailDiv] == SortDetailDivState.Detail)
                            {
                                if (dr["SALESDETAILRF.SALESMONEYTAXEXCRF"] != DBNull.Value)
                                {
                                    pageTtl = pageTtl + Convert.ToInt64(dr["SALESDETAILRF.SALESMONEYTAXEXCRF"]); // 売上金額（税抜き）
                                }
                            }
                        }
                        pageTtlList.Add(index, pageTtl);
                    }
                }

                //--------------------------------------------------------
                // 改ページ前後に請求書ヘッダ情報をセット
                //--------------------------------------------------------
                // 対象Rowリスト内の全ての行に対してヘッダ情報を適用する
                foreach (int headCopyIndex in headCopyRowIndexList)
                {
                    DataRow row;
                    if ( headCopyIndex <= table.DefaultView.Count - 1 )
                    {
                        row = table.DefaultView[headCopyIndex].Row;
                    }
                    else
                    {
                        row = table.DefaultView[table.DefaultView.Count - 1].Row;
                    }

                    printPrice = (headCopyIndex == 0 || headCopyIndex == feedCount - 1);
                    //ReflectBillHeader(ref row, headWork, dmdPrtPtnWork, frePrtPSetWork, billAllStWork, billPrtStWork, allDefSet, printPrice, billDmdPrintParameter.TaxTitle, billDmdPrintParameter.OfsThisSalesTaxIncTtl, pageTtlList); // DEL    田村顕成 2022/10/18
                    ReflectBillHeader(ref row, headWork, dmdPrtPtnWork, frePrtPSetWork, billAllStWork, billPrtStWork, allDefSet, printPrice, billDmdPrintParameter.TaxTitle, billDmdPrintParameter.OfsThisSalesTaxIncTtl, pageTtlList, TotalTaxRateSalesMoney,dTaxRate1,dTaxRate2); // ADD    田村顕成 2022/10/18
                }
            }

        /// <summary>
        /// 複写タイトルセット処理（複写２枚目の時コールする）
        /// </summary>
        /// <param name="table">データテーブル</param>
        /// <remarks>
        /// <br>Note        : 複写タイトルセット処理（複写２枚目の時コールする）</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static void SetCopyTitle( ref DataTable table )
        {
            if ( table != null && table.Rows.Count > 0 )
            {
                string dmdFormTitle2;
                try
                {
                    // タイトル2を退避
                    dmdFormTitle2 = (string)table.Rows[0]["HADD.DMDFORMTITLE2RF"];
                }
                catch
                {
                    dmdFormTitle2 = string.Empty;
                }

                // タイトル2がセットされている場合のみ差し替える
                if ( !string.IsNullOrEmpty( dmdFormTitle2 ) )
                {
                    foreach ( DataRow row in table.Rows )
                    {
                        // 請求書タイトル(1) ← 請求書タイトル２をセット
                        row["HADD.DMDFORMTITLERF"] = dmdFormTitle2;
                    }
                }
            }
        }

        /// <summary>
        /// ソート用行番号取得処理
        /// </summary>
        /// <param name="deposit">入金データ</param>
        /// <returns>明細行番号</returns>
        /// <remarks>
        /// <br>Note        : ソート用行番号取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int GetDepositRowNoForSort( EBooksFrePBillDetailWork deposit )
        {
            if ( ReportItemDic != null && ReportItemDic.ContainsKey( "DADD.MONEYKINDCODEOTHERRF" ) )
            {
                // 「金種コード(その他に含む)」が存在する場合は、そのコード値を返す
                try
                {
                    return Int32.Parse( GetDepMoneyKindCdSp( deposit ) );
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                // 通常は明細行番号を返す
                return deposit.DEPSITDTLRF_DEPOSITROWNORF;
            }
        }
        /// <summary>
        /// ソート用行番号取得処理
        /// </summary>
        /// <param name="detailRowNo">行番号</param>
        /// <param name="moneyKindCodeOtherIndex">金種コード</param>
        /// <returns>明細行番号</returns>
        /// <remarks>
        /// <br>Note        : ソート用行番号取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int GetDepositRowNoForSort( int detailRowNo, int moneyKindCodeOtherIndex )
        {
            if ( ReportItemDic != null && ReportItemDic.ContainsKey( "DADD.MONEYKINDCODEOTHERRF" ) )
            {
                // 「金種コード(その他に含む)」が存在する場合は、そのコード値を返す
                return moneyKindCodeOtherIndex;
            }
            else
            {
                // 通常は明細行番号を返す
                return detailRowNo;
            }
        }

        /// <summary>
        /// 金額種別名称取得(空白制御あり・内容固定・PM7からｺﾝﾊﾞｰﾄした場合などに使用)
        /// </summary>
        /// <param name="frePBillDetailWork">自由帳票請求書</param>
        /// <returns>金額種別名称</returns>
        /// <remarks>
        /// <br>Note        : 金額種別名称取得</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetDepMoneyKindNameSp( EBooksFrePBillDetailWork frePBillDetailWork )
        {
            switch ( frePBillDetailWork.DEPSITDTLRF_MONEYKINDCODERF )
            {
                case 51: return "現　金";
                case 52: return "振　込";
                case 53: return "小切手";
                case 54: return "手　形";
                case 55: return "手数料";
                case 56: return "相　殺";
                case 57: return "値　引";
                case 58: return "その他";
                case 59: return "口座振替";
                case 60: return "ﾌｧｸﾀﾘﾝｸﾞ";
                default: return frePBillDetailWork.DEPSITDTLRF_MONEYKINDNAMERF;
            }
        }

        /// <summary>
        /// 金額種別コード取得(山西商会対応)
        /// </summary>
        /// <param name="frepBillDetailWork">自由帳票請求書</param>
        /// <returns>金額種別コード</returns>
        /// <remarks>
        /// <br>Note        : 金額種別コード取得</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetDepMoneyKindCdSp(EBooksFrePBillDetailWork frepBillDetailWork)
        {
            switch (frepBillDetailWork.DEPSITDTLRF_MONEYKINDCODERF)
            {
                case 51: return "01"; //現金
                case 52: return "06"; //振り込み
                case 53: return "02"; //小切手
                case 54: return "03"; //手形
                case 55: return "07"; //その他(手数料)
                case 56: return "04"; //相殺
                case 57: return "05"; //値引き
                case 58: return "07"; //その他
                case 59: return "07"; //その他(口座振替)
                case 60: return "07"; //その他(ファクタリング) 
                default: return "07";
            }
        }

        /// <summary>
        /// 定価印字チェック処理（明細毎に判定）
        /// </summary>
        /// <param name="detail">明細データ</param>
        /// <param name="dmdPrtPtnWork">請求書印刷パターン設定</param>
        /// <returns>true:印字する/false:印字しない</returns>
        /// <remarks>
        /// <br>Note        : 定価印字チェック処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static bool CheckListPricePrint( EBooksFrePBillDetailWork detail, DmdPrtPtnWork dmdPrtPtnWork )
        {
            bool result = false;

            switch ( dmdPrtPtnWork.ListPricePrtCd )
            {
                // 0:印字しない
                case 0:
                    {
                        result = false;
                    }
                    break;
                // 1:印字する
                default:
                case 1:
                    {
                        result = true;
                    }
                    break;
                // 2:掛率＜１
                case 2:
                    {
                        // 標準価格(税抜)＞売上単価(税抜)　→　true
                        // 標準価格(税抜)≦売上単価(税抜)　→　false
                        result = (detail.SALESDETAILRF_LISTPRICETAXEXCFLRF > detail.SALESDETAILRF_SALESUNPRCTAXEXCFLRF);
                    }
                    break;
            }
            return result;
        }
        /// <summary>
        /// 入金明細（入金手数料・入金値引）追加処理
        /// </summary>
        /// <param name="table">データテーブル</param>
        /// <param name="frePBillDetailWork">自由帳票請求書</param>
        /// <param name="allDefSet">全体初期表示設定</param>
        /// <remarks>
        /// <br>Note        : 入金手数料と入金値引は明細にデータを持たない為、入金マスタ(ヘッダ)情報から明細を生成する</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectDepositDetailExtra( ref DataTable table, EBooksFrePBillDetailWork frePBillDetailWork, AllDefSetWork allDefSet )
        {
            int detailRowNo = frePBillDetailWork.DEPSITDTLRF_DEPOSITROWNORF;
            DataRow row;

            if ( frePBillDetailWork.DEPSITMAINRF_FEEDEPOSITRF != 0 )
            {
                # region [入金手数料]
                row = table.NewRow();
                detailRowNo++;
                row["DEPSITMAINRF.ACPTANODRSTATUSRF"] = frePBillDetailWork.DEPSITMAINRF_ACPTANODRSTATUSRF;
                row["DEPSITMAINRF.DEPOSITSLIPNORF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row["DEPSITMAINRF.SALESSLIPNUMRF"] = frePBillDetailWork.DEPSITMAINRF_SALESSLIPNUMRF;
                row["DEPSITMAINRF.ADDUPSECCODERF"] = frePBillDetailWork.DEPSITMAINRF_ADDUPSECCODERF;
                row["DEPSITMAINRF.SUBSECTIONCODERF"] = frePBillDetailWork.DEPSITMAINRF_SUBSECTIONCODERF;
                row["DEPSITMAINRF.DEPOSITDATERF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITDATERF;
                row["DEPSITMAINRF.ADDUPADATERF"] = frePBillDetailWork.DEPSITMAINRF_ADDUPADATERF;
                row["DEPSITMAINRF.DEPOSITRF"] = GetDepositTotal( frePBillDetailWork );//frePBillDetailWork.DEPSITMAINRF_DEPOSITRF;
                row["DEPSITMAINRF.FEEDEPOSITRF"] = frePBillDetailWork.DEPSITMAINRF_FEEDEPOSITRF;
                row["DEPSITMAINRF.DISCOUNTDEPOSITRF"] = frePBillDetailWork.DEPSITMAINRF_DISCOUNTDEPOSITRF;
                row["DEPSITMAINRF.AUTODEPOSITCDRF"] = frePBillDetailWork.DEPSITMAINRF_AUTODEPOSITCDRF;
                row["DEPSITMAINRF.DEPOSITCDRF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITCDRF;
                row["DEPSITMAINRF.DRAFTDRAWINGDATERF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTDRAWINGDATERF;
                row["DEPSITMAINRF.DRAFTKINDRF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTKINDRF;
                row["DEPSITMAINRF.DRAFTKINDNAMERF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTKINDNAMERF;
                row["DEPSITMAINRF.DRAFTDIVIDENAMERF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTDIVIDENAMERF;
                row["DEPSITMAINRF.DRAFTNORF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTNORF;
                row["DEPSITMAINRF.CUSTOMERCODERF"] = frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF;
                row["DEPSITMAINRF.CLAIMCODERF"] = frePBillDetailWork.DEPSITMAINRF_CLAIMCODERF;
                row["SUBDEP.SUBSECTIONNAMERF"] = frePBillDetailWork.SUBDEP_SUBSECTIONNAMERF;
                row["DEPSITDTLRF.DEPOSITSLIPNORF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row["DEPSITDTLRF.DEPOSITROWNORF"] = detailRowNo; // ←行番号
                row["DEPSITDTLRF.MONEYKINDCODERF"] = 0;
                row["DEPSITDTLRF.MONEYKINDNAMERF"] = "手数料";
                row["DEPSITDTLRF.MONEYKINDDIVRF"] = 0;
                row["DEPSITDTLRF.DEPOSITRF"] = frePBillDetailWork.DEPSITMAINRF_FEEDEPOSITRF; // 入金金額←手数料入金金額
                row["DEPSITDTLRF.VALIDITYTERMRF"] = DBNull.Value;
                // 日付展開
                // (通常)
                ExtractDate( ref row, allDefSet.EraNameDispCd2, frePBillDetailWork.DEPSITMAINRF_DEPOSITDATERF, "DADD.DEPOSITDATE", false ); // yyyymmdd
                ExtractDate( ref row, allDefSet.EraNameDispCd2, frePBillDetailWork.DEPSITMAINRF_DRAFTDRAWINGDATERF, "DADD.DRAFTDRAWINGDATE", false ); // yyyymmdd
                ExtractDate( ref row, allDefSet.EraNameDispCd2, frePBillDetailWork.DEPSITDTLRF_VALIDITYTERMRF, "DADD.VALIDITYTERM", false ); // yyyymmdd
                // ソート・合計用項目
                row[ct_col_Sort_CustomerCode] = frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF;
                row[ct_col_Sort_Date] = frePBillDetailWork.DEPSITMAINRF_DEPOSITDATERF;
                row[ct_col_Sort_RecordDiv] = SortRecordDivState.Deposit;
                row[ct_col_Sort_SalesSlipNo] = string.Empty;
                row[ct_col_Sort_DepositSlipNo] = frePBillDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                row[ct_col_Sort_DetailRowNo] = GetDepositRowNoForSort( detailRowNo, 7 );
                row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Deposit;
                // 伝票合計請求書用 明細タイトル
                row["DDEP.DETAILTITLERF"] = "手数料";
                // 未設定時 非印字
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_ADDUPSECCODERF ) ) row["DEPSITMAINRF.ADDUPSECCODERF"] = DBNull.Value; // 計上拠点コード
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_SUBSECTIONCODERF ) ) row["DEPSITMAINRF.SUBSECTIONCODERF"] = DBNull.Value; // 部門コード
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF ) ) row["DEPSITMAINRF.CUSTOMERCODERF"] = DBNull.Value; // 得意先コード
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_CLAIMCODERF ) ) row["DEPSITMAINRF.CLAIMCODERF"] = DBNull.Value; // 請求先コード
                row[ct_col_DDep_MoneyKindNameSp] = "手数料";
                row["DADD.MONEYKINDCODEOTHERRF"] = "07";
                row["DADD.FOOTER3PRINTRF"] = 0;
                // 追加
                table.Rows.Add( row );
                # endregion
            }

            if ( frePBillDetailWork.DEPSITMAINRF_DISCOUNTDEPOSITRF != 0 )
            {
                # region [入金値引]
                // コピー項目
                row = table.NewRow();
                detailRowNo++;
                row["DEPSITMAINRF.ACPTANODRSTATUSRF"] = frePBillDetailWork.DEPSITMAINRF_ACPTANODRSTATUSRF;
                row["DEPSITMAINRF.DEPOSITSLIPNORF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row["DEPSITMAINRF.SALESSLIPNUMRF"] = frePBillDetailWork.DEPSITMAINRF_SALESSLIPNUMRF;
                row["DEPSITMAINRF.ADDUPSECCODERF"] = frePBillDetailWork.DEPSITMAINRF_ADDUPSECCODERF;
                row["DEPSITMAINRF.SUBSECTIONCODERF"] = frePBillDetailWork.DEPSITMAINRF_SUBSECTIONCODERF;
                row["DEPSITMAINRF.DEPOSITDATERF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITDATERF;
                row["DEPSITMAINRF.ADDUPADATERF"] = frePBillDetailWork.DEPSITMAINRF_ADDUPADATERF;
                row["DEPSITMAINRF.DEPOSITRF"] = GetDepositTotal( frePBillDetailWork );//frePBillDetailWork.DEPSITMAINRF_DEPOSITRF;
                row["DEPSITMAINRF.FEEDEPOSITRF"] = frePBillDetailWork.DEPSITMAINRF_FEEDEPOSITRF;
                row["DEPSITMAINRF.DISCOUNTDEPOSITRF"] = frePBillDetailWork.DEPSITMAINRF_DISCOUNTDEPOSITRF;
                row["DEPSITMAINRF.AUTODEPOSITCDRF"] = frePBillDetailWork.DEPSITMAINRF_AUTODEPOSITCDRF;
                row["DEPSITMAINRF.DEPOSITCDRF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITCDRF;
                row["DEPSITMAINRF.DRAFTDRAWINGDATERF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTDRAWINGDATERF;
                row["DEPSITMAINRF.DRAFTKINDRF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTKINDRF;
                row["DEPSITMAINRF.DRAFTKINDNAMERF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTKINDNAMERF;
                row["DEPSITMAINRF.DRAFTDIVIDENAMERF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTDIVIDENAMERF;
                row["DEPSITMAINRF.DRAFTNORF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTNORF;
                row["DEPSITMAINRF.CUSTOMERCODERF"] = frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF;
                row["DEPSITMAINRF.CLAIMCODERF"] = frePBillDetailWork.DEPSITMAINRF_CLAIMCODERF;
                row["SUBDEP.SUBSECTIONNAMERF"] = frePBillDetailWork.SUBDEP_SUBSECTIONNAMERF;
                row["DEPSITDTLRF.DEPOSITSLIPNORF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row["DEPSITDTLRF.DEPOSITROWNORF"] = detailRowNo; // ←行番号
                row["DEPSITDTLRF.MONEYKINDCODERF"] = 0;
                row["DEPSITDTLRF.MONEYKINDNAMERF"] = "値引き";
                row["DEPSITDTLRF.MONEYKINDDIVRF"] = 0;
                row["DEPSITDTLRF.DEPOSITRF"] = frePBillDetailWork.DEPSITMAINRF_DISCOUNTDEPOSITRF; // 入金金額←値引き入金金額
                row["DEPSITDTLRF.VALIDITYTERMRF"] = DBNull.Value;
                // 日付展開
                // (通常)
                ExtractDate( ref row, allDefSet.EraNameDispCd2, frePBillDetailWork.DEPSITMAINRF_DEPOSITDATERF, "DADD.DEPOSITDATE", false ); // yyyymmdd
                ExtractDate( ref row, allDefSet.EraNameDispCd2, frePBillDetailWork.DEPSITMAINRF_DRAFTDRAWINGDATERF, "DADD.DRAFTDRAWINGDATE", false ); // yyyymmdd
                ExtractDate( ref row, allDefSet.EraNameDispCd2, frePBillDetailWork.DEPSITDTLRF_VALIDITYTERMRF, "DADD.VALIDITYTERM", false ); // yyyymmdd
                // ソート・合計用項目
                row[ct_col_Sort_CustomerCode] = frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF;
                row[ct_col_Sort_Date] = frePBillDetailWork.DEPSITMAINRF_DEPOSITDATERF;
                row[ct_col_Sort_RecordDiv] = SortRecordDivState.Deposit;
                row[ct_col_Sort_SalesSlipNo] = string.Empty;
                row[ct_col_Sort_DepositSlipNo] = frePBillDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                row[ct_col_Sort_DetailRowNo] = GetDepositRowNoForSort( detailRowNo, 5 );
                row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Deposit;
                // 伝票合計請求書用 明細タイトル
                row["DDEP.DETAILTITLERF"] = "値引き";
                // 未設定時 非印字
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_ADDUPSECCODERF ) ) row["DEPSITMAINRF.ADDUPSECCODERF"] = DBNull.Value; // 計上拠点コード
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_SUBSECTIONCODERF ) ) row["DEPSITMAINRF.SUBSECTIONCODERF"] = DBNull.Value; // 部門コード
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF ) ) row["DEPSITMAINRF.CUSTOMERCODERF"] = DBNull.Value; // 得意先コード
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_CLAIMCODERF ) ) row["DEPSITMAINRF.CLAIMCODERF"] = DBNull.Value; // 請求先コード
                row[ct_col_DDep_MoneyKindNameSp] = "値　引";
                row["DADD.MONEYKINDCODEOTHERRF"] = "05";
                row["DADD.FOOTER3PRINTRF"] = 0;
                // 追加
                table.Rows.Add( row );
                # endregion
            }
        }

        /// <summary>
        /// 入金合計取得処理
        /// </summary>
        /// <param name="frePBillDetailWork">自由帳票請求書</param>
        /// <returns>入金合計</returns>
        /// <remarks>
        /// <br>Note        : 入金合計取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static Int64 GetDepositTotal( EBooksFrePBillDetailWork frePBillDetailWork )
        {
            // 入金金額＋手数料入金額＋値引入金額
            return frePBillDetailWork.DEPSITMAINRF_DEPOSITRF + frePBillDetailWork.DEPSITMAINRF_FEEDEPOSITRF + frePBillDetailWork.DEPSITMAINRF_DISCOUNTDEPOSITRF;
        }

        /// <summary>
        /// 集計フッタ設定処理
        /// </summary>
        /// <param name="table">データテーブル</param>
        /// <param name="detailWork">明細データ</param>
        /// <param name="dmdPrtPtnWork">請求書印刷パターン設定</param>
        /// <param name="sortRecordDivState">ソート用レコード区分</param>
        /// <param name="parameter">請求書印刷レイアウトパラメータ</param>
        /// <remarks>
        /// <br>Note        : 集計フッタ設定処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectSummalyFooters( ref DataTable table, EBooksFrePBillDetailWork detailWork, DmdPrtPtnWork dmdPrtPtnWork, SortRecordDivState sortRecordDivState, BillDmdPrintParameter parameter )
        {
            DataRow row;

            //CustomerTtlPrtDiv 0:印字する 1:印字しない
            //DmdDtlPtnOdrDiv 0:計上日+伝票番号 1:得意先+計上日+伝票番号
            if ( dmdPrtPtnWork.CustomerTtlPrtDiv == 0 && dmdPrtPtnWork.DmdDtlPtnOdrDiv == 1 )
            {
                # region [日計（得意先別）]
                //AddDayTtlPrtDiv 0:印字する 1:印字しない
                if ( dmdPrtPtnWork.AddDayTtlPrtDiv == 0 )
                {
                    row = FindSummalyRow( table, detailWork.SALESSLIPRF_CUSTOMERCODERF, detailWork.SALESSLIPRF_SALESDATERF );

                    if ( row == null )
                    {
                        row = table.NewRow();
                        # region [(追加)]
                        // ソートキー
                        row[ct_col_Sort_CustomerCode] = detailWork.SALESSLIPRF_CUSTOMERCODERF;
                        row[ct_col_Sort_Date] = detailWork.SALESSLIPRF_SALESDATERF;
                        row[ct_col_Sort_RecordDiv] = SortRecordDivState.Daily;
                        row[ct_col_Sort_SalesSlipNo] = string.Empty;
                        row[ct_col_Sort_DepositSlipNo] = 0;
                        row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                        row[ct_col_Sort_DetailRowNo] = 0;
                        row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Daily;

                        // 金額
                        row["DSAL.DETAILSUMTITLERF"] = parameter.FooterTitleOfDaily;//*日計*
                        row["DSAL.DETAILSUMPRICERF"] = detailWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                        # endregion
                        table.Rows.Add( row );
                    }
                    else
                    {
                        # region [(更新)]
                        // 加算する
                        row["DSAL.DETAILSUMPRICERF"] = (Int64)row["DSAL.DETAILSUMPRICERF"] + detailWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                        # endregion
                    }
                }
                # endregion

                # region [得意先計]
                row = FindSummalyRow( table, detailWork.SALESSLIPRF_CUSTOMERCODERF, 99999999 );

                if ( row == null )
                {
                    row = table.NewRow();
                    # region [(追加)]
                    // ソートキー
                    row[ct_col_Sort_CustomerCode] = detailWork.SALESSLIPRF_CUSTOMERCODERF;
                    row[ct_col_Sort_Date] = 99999999;
                    row[ct_col_Sort_RecordDiv] = SortRecordDivState.Daily;
                    row[ct_col_Sort_SalesSlipNo] = string.Empty;
                    row[ct_col_Sort_DepositSlipNo] = 0;
                    row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                    row[ct_col_Sort_DetailRowNo] = 0;
                    row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Daily;
                    // 金額
                    row["DSAL.DETAILSUMTITLERF"] = parameter.FooterTitleOfCustomer;//*得意先計*
                    row["DSAL.DETAILSUMPRICERF"] = detailWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                    # endregion
                    table.Rows.Add( row );
                }
                else
                {
                    # region [(更新)]
                    // 加算する
                    row["DSAL.DETAILSUMPRICERF"] = (Int64)row["DSAL.DETAILSUMPRICERF"] + detailWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                    # endregion
                }
                # endregion
            }
            else
            {
                # region [日計]
                //AddDayTtlPrtDiv 0:印字する 1:印字しない
                if ( dmdPrtPtnWork.AddDayTtlPrtDiv == 0 )
                {
                    if ( dmdPrtPtnWork.DmdDtlPtnOdrDiv == 1 )
                    {
                        // ソート順に得意先が有るので、得意先別日付別に集計
                        row = FindSummalyRow( table, detailWork.SALESSLIPRF_CUSTOMERCODERF, detailWork.SALESSLIPRF_SALESDATERF );
                    }
                    else
                    {
                        // ソート順に得意先が無いので、(得意先別にせず)日付別に集計
                        row = FindSummalyRow( table, 0, detailWork.SALESSLIPRF_SALESDATERF );
                    }

                    if ( row == null )
                    {
                        row = table.NewRow();
                        # region [(追加)]
                        // ソートキー
                        row[ct_col_Sort_CustomerCode] = detailWork.SALESSLIPRF_CUSTOMERCODERF;
                        row[ct_col_Sort_Date] = detailWork.SALESSLIPRF_SALESDATERF;
                        row[ct_col_Sort_RecordDiv] = SortRecordDivState.Daily;
                        row[ct_col_Sort_SalesSlipNo] = string.Empty;
                        row[ct_col_Sort_DepositSlipNo] = 0;
                        row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                        row[ct_col_Sort_DetailRowNo] = 0;
                        row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Daily;
                        // 金額
                        row["DSAL.DETAILSUMTITLERF"] = parameter.FooterTitleOfDaily;//*日計*
                        row["DSAL.DETAILSUMPRICERF"] = detailWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                        # endregion
                        table.Rows.Add( row );
                    }
                    else
                    {
                        # region [(更新)]
                        // 加算する
                        row["DSAL.DETAILSUMPRICERF"] = (Int64)row["DSAL.DETAILSUMPRICERF"] + detailWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                        # endregion
                    }
                }
                # endregion
            }
        }
        /// <summary>
        /// 集計行取得処理
        /// </summary>
        /// <param name="table">データテーブル</param>
        /// <param name="customerCode">得意先</param>
        /// <param name="date">日付</param>
        /// <returns>集計行</returns>
        /// <remarks>
        /// <br>Note        : 集計行取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static DataRow FindSummalyRow( DataTable table, int customerCode, int date )
        {
            DataView view = new DataView( table );
            if ( customerCode == 0 )
            {
                // 得意先未指定
                view.RowFilter = string.Format( "{0}='{1}' AND {2}='{3}'",
                                                ct_col_Sort_Date, date,
                                                ct_col_Sort_RecordDiv, (int)SortRecordDivState.Daily );
            }
            else
            {
                // 得意先指定あり
                view.RowFilter = string.Format( "{0}='{1}' AND {2}='{3}' AND {4}='{5}'",
                                                ct_col_Sort_CustomerCode, customerCode,
                                                ct_col_Sort_Date, date,
                                                ct_col_Sort_RecordDiv, (int)SortRecordDivState.Daily );
            }
            if (view.Count > 0)
            {
                return view[0].Row;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 集計フッタ設定処理(入金用)
        /// </summary>
        /// <param name="table">データテーブル</param>
        /// <param name="detailWork">明細データ</param>
        /// <param name="dmdPrtPtnWork">請求書印刷パターン設定</param>
        /// <param name="sortRecordDivState">ソート用レコード区分</param>
        /// <param name="allDefSet">全体初期表示設定</param>
        /// <param name="parameter">請求書印刷レイアウトパラメータ</param>
        /// <remarks>
        /// <br>Note        : 集計フッタ設定処理(入金用)</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectDepositSummalyFooters( ref DataTable table, EBooksFrePBillDetailWork detailWork, DmdPrtPtnWork dmdPrtPtnWork, SortRecordDivState sortRecordDivState, BillDmdPrintParameter parameter, AllDefSetWork allDefSet )
        {
            // 0:印字する 1:印字しない
            if (dmdPrtPtnWork.SlipTtlPrtDiv == 0)
            {
                DataRow row = table.NewRow();

                # region [(追加)]
                // ソートキー
                row[ct_col_Sort_CustomerCode] = detailWork.DEPSITMAINRF_CUSTOMERCODERF;
                row[ct_col_Sort_Date] = detailWork.DEPSITMAINRF_DEPOSITDATERF;
                row[ct_col_Sort_RecordDiv] = SortRecordDivState.Deposit;
                row[ct_col_Sort_SalesSlipNo] = string.Empty;
                row[ct_col_Sort_DepositSlipNo] = detailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                row[ct_col_Sort_DetailRowNo] = 0;
                row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Deposit;

                // 共通
                row["DEPSITMAINRF.DEPOSITDATERF"] = detailWork.DEPSITMAINRF_DEPOSITDATERF;
                ExtractDate(ref row, allDefSet.EraNameDispCd2, detailWork.DEPSITMAINRF_DEPOSITDATERF, "DADD.DEPOSITDATE", false); // yyyymmdd
                row["DEPSITMAINRF.DEPOSITSLIPNORF"] = detailWork.DEPSITMAINRF_DEPOSITSLIPNORF;

                // 計
                row[ct_col_DDep_DepFtOutLine] = detailWork.DEPSITMAINRF_OUTLINERF;
                row["DDEP.DETAILSUMTITLERF"] = parameter.FooterTitleOfSlip; // *伝票計*
                row["DDEP.DETAILSUMPRICERF"] = GetDepositTotal(detailWork); //detailWork.DEPSITMAINRF_DEPOSITRF;
                # endregion

                if (dmdPrtPtnWork.DepoDtlPrcPrtDiv != 2 || string.IsNullOrEmpty(detailWork.DEPSITMAINRF_OUTLINERF))
                {
                    row["DADD.DTLTITLERF"] = DBNull.Value;
                }
                else
                {
                    row["DADD.DTLTITLERF"] = "<備考>";
                }
                row["DADD.DEPOSITFTTITLERF"] = parameter.DepositFooterTitleOfSlip;

                if (ReportItemDic.ContainsKey("SALESSLIPRF.SLIPNOTE2_2RF"))
                {
                    table.Rows.Add(row);
                    row = table.NewRow();
                    row[ct_col_Sort_CustomerCode] = detailWork.DEPSITMAINRF_CUSTOMERCODERF;
                    row[ct_col_Sort_Date] = detailWork.DEPSITMAINRF_DEPOSITDATERF;
                    row[ct_col_Sort_RecordDiv] = SortRecordDivState.Deposit;
                    row[ct_col_Sort_SalesSlipNo] = string.Empty;
                    row[ct_col_Sort_DepositSlipNo] = detailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                    row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                    row[ct_col_Sort_DetailRowNo] = 0;
                    row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Deposit;
                }

                table.Rows.Add(row);
            }

            if (ReportItemDic.ContainsKey("DADD.DETAILBLANKLINERF"))
            {
                DataRow row = table.NewRow();
                // 明細フッタ空行があるなら空行追加
                row = table.NewRow();
                row[ct_col_Sort_CustomerCode] = detailWork.DEPSITMAINRF_CUSTOMERCODERF;
                row[ct_col_Sort_Date] = detailWork.DEPSITMAINRF_DEPOSITDATERF;
                row[ct_col_Sort_RecordDiv] = SortRecordDivState.Deposit;
                row[ct_col_Sort_SalesSlipNo] = string.Empty;
                row[ct_col_Sort_DepositSlipNo] = detailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                row[ct_col_Sort_DetailRowNo] = 0;
                row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Deposit;
                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// (先頭)車種名(２行目のみ印字)　明細追加処理
        /// </summary>
        /// <param name="table">データテーブル</param>
        /// <param name="frePBillDetailWork">自由帳票請求書</param>
        /// <param name="dmdPrtPtnWork">請求書印刷パターン設定</param>
        /// <remarks>
        /// <br>Note        : (先頭)車種名(２行目のみ印字)　明細追加処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectModelNameDetailExtra(ref DataTable table, EBooksFrePBillDetailWork frePBillDetailWork, DmdPrtPtnWork dmdPrtPtnWork)
        {
            int detailRowNo = frePBillDetailWork.SALESDETAILRF_SALESROWNORF;
            DataRow row;

                row = table.NewRow();
                detailRowNo++;
                row["SALESSLIPRF.SALESDATERF"] = frePBillDetailWork.SALESSLIPRF_SALESDATERF;
                row["SALESSLIPRF.SALESSLIPNUMRF"] = frePBillDetailWork.SALESSLIPRF_SALESSLIPNUMRF;
                row["SALESSLIPRF.SALESSLIPCDRF"] = frePBillDetailWork.SALESSLIPRF_SALESSLIPCDRF;
                row["SALESDETAILRF.SALESMONEYTAXINCRF"] = frePBillDetailWork.SALESDETAILRF_SALESMONEYTAXINCRF;
                row["SALESDETAILRF.SALESROWNORF"] = detailRowNo;//←行番号
                row["ACCEPTODRCARRF.FULLMODELRF"] = frePBillDetailWork.ACCEPTODRCARRF_FULLMODELRF;
                row["DADD.MODELHALFNAMEDTL2RF"] = frePBillDetailWork.ACCEPTODRCARRF_MODELHALFNAMERF;

                if (string.IsNullOrEmpty(frePBillDetailWork.ACCEPTODRCARRF_MODELHALFNAMERF))
                   {
                       row["DADD.MODELHALFNAMEDTL2RF"] = GetKanaString(frePBillDetailWork.ACCEPTODRCARRF_MODELFULLNAMERF);
                   }

                # region [ソート・合計対応]
                row[ct_col_Sort_CustomerCode] = frePBillDetailWork.SALESSLIPRF_CUSTOMERCODERF;
                row[ct_col_Sort_Date] = frePBillDetailWork.SALESSLIPRF_SALESDATERF;
                row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                row[ct_col_Sort_SalesSlipNo] = frePBillDetailWork.SALESSLIPRF_SALESSLIPNUMRF;
                row[ct_col_Sort_DepositSlipNo] = 0;
                row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                row[ct_col_Sort_DetailRowNo] = 0;
                row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                # endregion

                table.Rows.Add(row);
        }

        /// <summary>
        /// 第一型式取得処理 (山西商会対応)
        /// </summary>
        /// <param name="fullModel">型式</param>
        /// <returns>型式</returns>
        /// <remarks>
        /// <br>Note        : 第一型式取得処理 (山西商会対応)</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetFullModel(string fullModel)
        {
            string[] fullModels = fullModel.Split('-');
            string secondModel = string.Empty;

            if (fullModels.Length > 1)
            {
                if ( fullModels[0].Length >= 3 )
                {
                    secondModel = fullModels[0];
                }
                else
                {
                    secondModel = fullModels[1];
                }
            }
            else
            {
                secondModel = fullModel;
            }
            return secondModel;

        }
        /// <summary>
        /// 型式取得
        /// </summary>
        /// <param name="detailWork">明細データ</param>
        /// <returns>型式</returns>
        /// <remarks>
        /// <br>Note        : 型式取得</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetFullModel(EBooksFrePBillDetailWork detailWork)
        {
            string fullModel = null;
            fullModel = GetFullModel(detailWork.ACCEPTODRCARRF_FULLMODELRF);
            return fullModel;
        }

        /// <summary>
        /// 印刷データ展開処理
        /// </summary>
        /// <param name="source">データデーブル</param>
        /// <returns>印刷データリスト</returns>
        /// <remarks>
        /// <br>Note        : 印刷データを１ページ目と２ページ目以降に分けてテーブルのリストを生成します</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static List<DataTable> DevelopPrintDataList( ref DataTable source )
        {
            List<DataTable> printDataList = new List<DataTable>();

            for ( int sourceIndex = 0; sourceIndex < source.DefaultView.Count; sourceIndex++ )
            {
                DataRow row = source.DefaultView[sourceIndex].Row;

                int index;
                if ( row[ct_col_PageCount] != DBNull.Value )
                {
                    if ((int)row[ct_col_PageCount] == 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index = 1;
                    }
                }
                else
                {
                    index = 0;
                }

                if ( printDataList.Count - 1 < index )
                {
                    printDataList.Add( CreatePrintDataTable() );
                    printDataList[index].DefaultView.Sort = source.DefaultView.Sort;
                }
                printDataList[index].ImportRow( row );
            }

            return printDataList;
        }

        /// <summary>
        /// 明細総行数の算出
        /// </summary>
        /// <param name="dataCount">データ数</param>
        /// <param name="feedCount">１ページ行数</param>
        /// <param name="otherFeedAddCount">２ページ目以降の行数</param>
        /// <returns>明細総行数</returns>
        /// <remarks>
        /// <br>Note        : 明細総行数の算出</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int GetAllDetailCount( int dataCount, int feedCount, int otherFeedAddCount )
        {
            if ( dataCount <= feedCount )
            {
                //--------------------------
                // １ページに収まる
                //--------------------------
                return feedCount;
            }
            else
            {
                //--------------------------
                // ２ページ以上ある
                //--------------------------

                // １ページ目の行数を除く
                dataCount -= feedCount;
                // ２ページ目以降の行数を算出して,１ページ目の行数を加える
                return GetAllDetailCountSub( dataCount, (feedCount + otherFeedAddCount) ) + feedCount;
            }

        }
        /// <summary>
        /// 明細総行数の算出Sub
        /// </summary>
        /// <param name="dataCount">データ数</param>
        /// <param name="feedCount">１ページ行数</param>
        /// <returns>明細総行数</returns>
        /// <remarks>
        /// <br>Note        : 明細総行数の算出</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int GetAllDetailCountSub( int dataCount, int feedCount )
        {
            if ( dataCount % feedCount == 0 )
            {
                // 割り切れる → データ行数と明細総行数はイコールでＯＫ
                return dataCount;
            }
            else
            {
                // 割り切れない → 必要な余白を含めた明細行数を返す
                return (dataCount + (feedCount - (dataCount % feedCount)));
            }
        }

        # region [グループサプレス]
        /// <summary>
        /// 日付サプレス
        /// </summary>
        /// <param name="row">データ行</param>
        /// <remarks>
        /// <br>Note        : 日付サプレス</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void SuppressOfDate( ref DataRow row )
        {
            // 売上
            ExtractDate( ref row, 0, 0, "DADD.SALESDATE", false ); // yyyymmdd
            ExtractDate( ref row, 0, 0, "DADD.FIRSTENTRYDATE", true ); // yyyymm
            // 入金
            ExtractDate( ref row, 0, 0, "DADD.DEPOSITDATE", false ); // yyyymmdd
            ExtractDate( ref row, 0, 0, "DADD.DRAFTDRAWINGDATE", false ); // yyyymmdd
            ExtractDate( ref row, 0, 0, "DADD.VALIDITYTERM", false ); // yyyymmdd
        }
        /// <summary>
        /// 伝票番号サプレス
        /// </summary>
        /// <param name="row">データ行</param>
        /// <remarks>
        /// <br>Note        : 伝票番号サプレス</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void SuppressOfSlipNo( ref DataRow row )
        {
            // 売上
            row["SALESSLIPRF.SALESSLIPNUMRF"] = DBNull.Value;
            // 入金
            row["DEPSITMAINRF.DEPOSITSLIPNORF"] = DBNull.Value;
            row["DEPSITDTLRF.DEPOSITSLIPNORF"] = DBNull.Value;
        }
        /// <summary>
        /// 車輌情報サプレス
        /// </summary>
        /// <param name="row">データ行</param>
        /// <remarks>
        /// <br>Note        : 車輌情報サプレス</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void SuppressOfCar( ref DataRow row )
        {
            row["ACCEPTODRCARRF.CARMNGNORF"] = DBNull.Value;
            row["ACCEPTODRCARRF.CARMNGCODERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.NUMBERPLATE1CODERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.NUMBERPLATE1NAMERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.NUMBERPLATE2RF"] = DBNull.Value;
            row["ACCEPTODRCARRF.NUMBERPLATE3RF"] = DBNull.Value;
            row["ACCEPTODRCARRF.NUMBERPLATE4RF"] = DBNull.Value;
            row["ACCEPTODRCARRF.FIRSTENTRYDATERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MAKERCODERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MAKERFULLNAMERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MODELCODERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MODELSUBCODERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MODELFULLNAMERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.EXHAUSTGASSIGNRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.SERIESMODELRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.CATEGORYSIGNMODELRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.FULLMODELRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MODELDESIGNATIONNORF"] = DBNull.Value;
            row["ACCEPTODRCARRF.CATEGORYNORF"] = DBNull.Value;
            row["ACCEPTODRCARRF.FRAMEMODELRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.FRAMENORF"] = DBNull.Value;
            row["ACCEPTODRCARRF.SEARCHFRAMENORF"] = DBNull.Value;
            row["ACCEPTODRCARRF.ENGINEMODELNMRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.RELEVANCEMODELRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.SUBCARNMCDRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MODELGRADESNAMERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.COLORCODERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.COLORNAME1RF"] = DBNull.Value;
            row["ACCEPTODRCARRF.TRIMCODERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.TRIMNAMERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MILEAGERF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFYRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFSRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFWRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFMRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFGRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFRRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFLSRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFLPRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFLYRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFLMRF"] = DBNull.Value;
            row["DADD.CARMNGCODETITLERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MODELHALFNAMERF"] = DBNull.Value;
            row["DADD.FULLMODELORMODELHALFNAMERF"] = DBNull.Value;
        }
        # endregion

        /// <summary>
        /// 請求書 売上明細 適用処理
        /// </summary>
        /// <param name="table">テーブル</param>
        /// <param name="salesWork">売上データ</param>
        /// <param name="dmdPrtPtnWork">印刷条件</param>
        /// <param name="parameter">印刷レイアウトパラメータ</param>
        /// <param name="headWork">ヘッダー情報</param>
        /// <remarks>
        /// <br>Note        : 請求書 売上明細 適用処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note  : 2023/04/14 3H 仰亮亮</br>
        /// <br>管理番号     : 11970040-00 自由帳票項目追加対応</br>
        /// <br>             : ①売上伝票計金額(税込み)</br>
        /// <br>             : ②消費税(伝票転嫁)/売上伝票計金額(税込み)</br>
        /// </remarks>
        private static void ReflectSalesFooter(ref DataTable table, EBooksFrePBillDetailWork salesWork, DmdPrtPtnWork dmdPrtPtnWork, BillDmdPrintParameter parameter, EBooksFrePBillHeadWork headWork)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS"); 
            // 0:印字する 1:印字しない
            if (dmdPrtPtnWork.SlipTtlPrtDiv == 0)
            {
                // 伝票番号が変わったら合計行を追加
                DataRow footerRow = table.NewRow();
                bool isParent = (headWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0);
                if (ReportItemDic.ContainsKey("DADD.ADDTAXLINERF"))
                {
                    // 消費税行を追加
                    if (isParent && (headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF == 0 || headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF == 1))
                    {
                        footerRow["DADD.SALESFTTITLERF"] = parameter.SlipTtlTaxTitle; // 消費税
                        footerRow["DADD.SALESFTPRICERF"] = salesWork.SALESSLIPRF_SALESSUBTOTALTAXRF;
                        footerRow["SALESSLIPRF.SALESSLIPNUMRF"] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                        footerRow["SALESSLIPRF.SALESDATERF"] = salesWork.SALESSLIPRF_SALESDATERF;
                        footerRow["SALESSLIPRF.PARTYSALESLIPNUMRF"] = salesWork.SALESSLIPRF_PARTYSALESLIPNUMRF;
                        # region [ソート・合計対応]
                        footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                        footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                        footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                        footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                        footerRow[ct_col_Sort_DepositSlipNo] = 0;
                        footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                        footerRow[ct_col_Sort_DetailRowNo] = 0;
                        footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                        # endregion
                        table.Rows.Add(footerRow);
                        footerRow = table.NewRow();
                    }
                }

                footerRow["DADD.SALESFTTITLERF"] = parameter.FooterTitleOfSlip;//*伝票計*
                // 消費税行追加が貼られている時のみ処理
                // 消費税行を追加した場合は税込金額を印字する。
                if (ReportItemDic.ContainsKey("DADD.ADDTAXLINERF"))
                {
                    if (isParent && (headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF == 0 || headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF == 1))
                    {
                        footerRow["DADD.SALESFTPRICERF"] = salesWork.SALESSLIPRF_SALESTOTALTAXINCRF;
                    }
                    else
                    {
                        footerRow["DADD.SALESFTPRICERF"] = salesWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                    }
                }
                else
                {
                    footerRow["DADD.SALESFTPRICERF"] = salesWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                } 
                footerRow["DADD.SALESFTNOTE1RF"] = salesWork.SALESSLIPRF_SLIPNOTERF;
                footerRow["DADD.SALESFTNOTE2RF"] = salesWork.SALESSLIPRF_SLIPNOTE2RF;
                footerRow["DADD.SALESFTNOTE3RF"] = salesWork.SALESSLIPRF_SLIPNOTE3RF;

                footerRow["SALESSLIPRF.SALESSLIPNUMRF"] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                footerRow["SALESSLIPRF.SALESDATERF"] = salesWork.SALESSLIPRF_SALESDATERF;
                footerRow["SALESSLIPRF.PARTYSALESLIPNUMRF"] = salesWork.SALESSLIPRF_PARTYSALESLIPNUMRF;
                // 伝票合計消費税
                // 請求先親かつ転嫁方式が伝票単位・明細単位の時のみ印字
                if (isParent && (headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF == 0 || headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF == 1))
                {
                    footerRow["DADD.SLIPTTLTAXTITLERF"] = parameter.SlipTtlTaxTitle; // 消費税
                    footerRow["DADD.SLIPTTLTAXRF"] = salesWork.SALESSLIPRF_SALESSUBTOTALTAXRF;
                }
                else
                {
                    footerRow["DADD.SLIPTTLTAXTITLERF"] = DBNull.Value; // 消費税
                    footerRow["DADD.SLIPTTLTAXRF"] = DBNull.Value;
                }

                // --- ADD START 3H 仰亮亮 2023/04/14 ----------------------------------->>>>>
                #region [①売上伝票計金額(税込み) ②消費税(伝票転嫁)/売上伝票計金額(税込み) 追加]
                // 転嫁方式が伝票単位 且つ 伝票合計金額(税抜) <>0 のみ印字 
                if ((salesWork.SALESSLIPRF_CONSTAXLAYMETHODRF == 0) && (salesWork.SALESSLIPRF_SALESTOTALTAXEXCRF != 0))
                {
                    // 最大印字桁数:12
                    const int iMaxLength = 12;
                    string lSalesMoneyTaxInc = SetFormat(salesWork.SALESSLIPRF_SALESSUBTOTALTAXRF + salesWork.SALESSLIPRF_SALESTOTALTAXEXCRF, iMaxLength);
                    footerRow["DADD.SALESMONEYTAXINCRF"] = lSalesMoneyTaxInc;
                    footerRow["DADD.TAXRFANDSALESMONEYTAXINCRF"] = SetFormat(salesWork.SALESSLIPRF_SALESSUBTOTALTAXRF, iMaxLength) + "/" + lSalesMoneyTaxInc;
                }
                #endregion
                // --- ADD END 3H 仰亮亮 2023/04/14 -------------------------------------<<<<<

                # region [ソート・合計対応]
                footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                footerRow[ct_col_Sort_DepositSlipNo] = 0;
                footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                footerRow[ct_col_Sort_DetailRowNo] = 0;
                footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                # endregion

                if (ReportItemDic.ContainsKey("DADD.MODELHALFNAMEDTL3RF"))
                {
                    if (!_modelHalfNameDtl3PrtFlg)
                    {
                        // 1行目の車種名を印字する
                        footerRow["DADD.MODELHALFNAMEDTL3RF"] = _modelHalfNameDtl1;
                    }
                    _modelHalfNameDtl3PrtFlg = false;
                }

                if (ReportItemDic.ContainsKey("DADD.CARMNGNO2RF"))
                {
                    if (!_carMngNo2PrtFlg)
                    {
                        // １行目の車輌管理番号を印字する
                        footerRow["DADD.CARMNGNO2RF"] = _carMngNo2Dtl1;
                        if (!string.IsNullOrEmpty(_carMngNo2Dtl1))
                        {
                            footerRow["DADD.CARMNGCODETITLE2RF"] = "【ﾌﾟﾚｰﾄ】";
                        }
                    }
                    _carMngNo2PrtFlg = false;
                }

                if (string.IsNullOrEmpty(salesWork.SALESSLIPRF_SLIPNOTERF))
                {
                    footerRow["DADD.DTLTITLERF"] = DBNull.Value;
                }
                else
                {
                    footerRow["DADD.DTLTITLERF"] = "<備考>";
                }

                // 売上フッタで伝票備考２（明細２行目印字）が未印字もしくは1行のみ印字だった場合は印字する
                if (ReportItemDic.ContainsKey("SALESSLIPRF.SLIPNOTE2_2RF"))
                {
                    footerRow["DADD.FOOTER3PRINTRF"] = 97;
                    if (_slipNote2PrtCnt < 2)
                    {
                        bool emptyLineFlg = false;
                        if (_slipNote2PrtCnt == 1)
                            emptyLineFlg = true;
                        string salesSlipNote2 = salesWork.SALESSLIPRF_SLIPNOTE2RF;
                        string prtSalesSlipNote2 = "";
                        string targetStr = "";
                        int maxNum = sjisEnc.GetByteCount(salesSlipNote2);
                        int prtCnt = 16;    // 一行に印字するバイト数
                        int nowNum = 0;
                        int cutPoint = 0;
                        if (_slipNote2PrtCnt == 0)
                        {
                            // ２行目なら備考２の頭から16バイト印字
                            if (maxNum > prtCnt)
                            {
                                if (maxNum > prtCnt)
                                {
                                    while (nowNum < prtCnt)
                                    {
                                        targetStr = salesSlipNote2.Substring(cutPoint, 1);
                                        if (nowNum + sjisEnc.GetByteCount(targetStr) > prtCnt)
                                        {
                                            break;
                                        }
                                        cutPoint++;
                                        nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                                    }
                                    prtSalesSlipNote2 = salesSlipNote2.Substring(0, cutPoint);
                                }
                                else
                                {
                                    prtSalesSlipNote2 = salesSlipNote2;
                                }
                                if (string.IsNullOrEmpty(prtSalesSlipNote2))
                                    footerRow["SALESSLIPRF.SLIPNOTE2_2RF"] = string.Empty;
                                else
                                    footerRow["SALESSLIPRF.SLIPNOTE2_2RF"] = prtSalesSlipNote2;
                            }
                            else
                            {
                                prtSalesSlipNote2 = salesSlipNote2;
                            }
                            if (string.IsNullOrEmpty(prtSalesSlipNote2))
                                footerRow["SALESSLIPRF.SLIPNOTE2_2RF"] = string.Empty;
                            else
                            {
                                footerRow["SALESSLIPRF.SLIPNOTE2_2RF"] = prtSalesSlipNote2;
                            }
                            _slipNote2PrtCnt++;
                            table.Rows.Add(footerRow);

                            footerRow = table.NewRow();
                            # region [ソート・合計対応]
                            footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                            footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                            footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                            footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                            footerRow[ct_col_Sort_DepositSlipNo] = 0;
                            footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                            footerRow[ct_col_Sort_DetailRowNo] = 0;
                            footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                            footerRow["DADD.FOOTER3PRINTRF"] = 97;
                            # endregion
                        }
                        if (_slipNote2PrtCnt == 1)
                        {
                            // ３行目なら備考２の17バイト目から16バイト印字
                            if (maxNum > prtCnt)
                            {
                                while (nowNum < prtCnt)
                                {
                                    targetStr = salesSlipNote2.Substring(cutPoint, 1);
                                    if (nowNum + sjisEnc.GetByteCount(targetStr) > prtCnt)
                                    {
                                        break;
                                    }
                                    cutPoint++;
                                    nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                                }
                                salesSlipNote2 = salesSlipNote2.Substring(cutPoint, salesSlipNote2.Length - cutPoint);

                                if (maxNum > prtCnt * 2)
                                {
                                    maxNum = sjisEnc.GetByteCount(salesSlipNote2);
                                    nowNum = 0;
                                    cutPoint = 0;
                                    while (nowNum < prtCnt)
                                    {
                                        targetStr = salesSlipNote2.Substring(cutPoint, 1);
                                        if (nowNum + sjisEnc.GetByteCount(targetStr) > prtCnt)
                                        {
                                            break;
                                        }
                                        cutPoint++;
                                        nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                                    }
                                    prtSalesSlipNote2 = salesSlipNote2.Substring(0, cutPoint);
                                }
                                else
                                {
                                    prtSalesSlipNote2 = salesSlipNote2;
                                }
                            }
                            else
                            {
                                prtSalesSlipNote2 = "";
                            }
                            if (string.IsNullOrEmpty(prtSalesSlipNote2))
                                footerRow["SALESSLIPRF.SLIPNOTE2_2RF"] = string.Empty;
                            else
                                footerRow["SALESSLIPRF.SLIPNOTE2_2RF"] = prtSalesSlipNote2;

                            if (emptyLineFlg)
                            {
                                table.Rows.Add(footerRow);

                                footerRow = table.NewRow();
                                # region [ソート・合計対応]
                                footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                                footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                                footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                                footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                                footerRow[ct_col_Sort_DepositSlipNo] = 0;
                                footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                                footerRow[ct_col_Sort_DetailRowNo] = 0;
                                footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                                footerRow["DADD.FOOTER3PRINTRF"] = 97;
                                #endregion
                            }
                        }
                    }
                    else
                    {
                        // 空行のみ追加
                        table.Rows.Add(footerRow);

                        footerRow = table.NewRow();
                        # region [ソート・合計対応]
                        footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                        footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                        footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                        footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                        footerRow[ct_col_Sort_DepositSlipNo] = 0;
                        footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                        footerRow[ct_col_Sort_DetailRowNo] = 0;
                        footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                        footerRow["DADD.FOOTER3PRINTRF"] = 97;
                        # endregion
                    }
                }
                _slipNote2PrtCnt = 0;

                table.Rows.Add(footerRow);
            }
            if (ReportItemDic.ContainsKey("DADD.DETAILBLANKLINERF"))
            {
                DataRow footerRow = table.NewRow();
                // 明細フッタ空行があるなら空行追加
                footerRow = table.NewRow();
                # region [ソート・合計対応]
                footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                footerRow[ct_col_Sort_DepositSlipNo] = 0;
                footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                footerRow[ct_col_Sort_DetailRowNo] = 0;
                footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                footerRow["DADD.FOOTER3PRINTRF"] = 97;
                # endregion
                table.Rows.Add(footerRow);
            }
        }
        /// <summary>
        /// 売上フッタ２　売上明細　適用処理(竹田商会個別対応)
        /// </summary>
        /// <param name="table">テーブル</param>
        /// <param name="salesWork">売上データ</param>
        /// <param name="dmdPrtPtnWork">印刷条件</param>
        /// <param name="headWork">ヘッダー情報</param>
        /// <param name="parameter">印刷レイアウトパラメータ</param>
        /// <remarks>
        /// <br>Note        : 売上フッタ２　売上明細　適用処理(竹田商会個別対応)</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectSalesFooter2(ref DataTable table, EBooksFrePBillDetailWork salesWork, DmdPrtPtnWork dmdPrtPtnWork, BillDmdPrintParameter parameter, EBooksFrePBillHeadWork headWork)
        {
            //消費税印字有無フラグ
            bool _salesSubTtlTax = false;
            bool isParent = (headWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0);
            // 売上伝票計金額２が張られている場合、明細転嫁と伝票転嫁以外は売上フッタ２を印字しない
            if (ReportItemDic.ContainsKey("DADD.SALESFT2PRICE2RF"))
            {
                if (salesWork.SALESSLIPRF_CONSTAXLAYMETHODRF != 0 && salesWork.SALESSLIPRF_CONSTAXLAYMETHODRF != 1)
                {
                    return;
                }
            }

            //印字する
            if (dmdPrtPtnWork.SlipTtlPrtDiv == 0)
            {
                DataRow footerRow = table.NewRow();
                //明細転嫁・伝票転嫁の場合は合計消費税を印字する
                if(salesWork.SALESSLIPRF_CONSTAXLAYMETHODRF == 0 || salesWork.SALESSLIPRF_CONSTAXLAYMETHODRF == 1)
                {
                    footerRow["DADD.SALESFT2PRICERF"] = salesWork.SALESSLIPRF_SALESSUBTOTALTAXRF;//消費税
                    _salesSubTtlTax = true;

                    footerRow["DADD.SALESFT2TITLERF"] = parameter.FooterTitleOfTax;//消費税タイトル
                    footerRow["DADD.SALESFT2PRICE2RF"] = salesWork.SALESSLIPRF_SALESSUBTOTALTAXRF;//消費税
                    footerRow["DADD.SALESFT2TITLE2RF"] = parameter.FooterTitleOfTax2;//消費税タイトル２

                    if (string.IsNullOrEmpty(salesWork.SALESSLIPRF_SLIPNOTERF))
                    {
                        //備考１がない場合は備考２を印字
                        footerRow["DADD.SALESFT2NOTERF"] = salesWork.SALESSLIPRF_SLIPNOTE2RF;//伝票備考２
                    }
                    else
                    {
                        footerRow["DADD.SALESFT2NOTERF"] = salesWork.SALESSLIPRF_SLIPNOTERF;//伝票備考１
                    }
                }
                else
                {
                    //請求転嫁・非課税の場合は伝票合計金額(税抜)を印字する
                    footerRow["DADD.SALESFT2PRICERF"] = salesWork.SALESSLIPRF_SALESTOTALTAXEXCRF;//伝票合計金額(税抜)
                    footerRow["DADD.SALESFT2TITLERF"] = parameter.FooterTitleOfSlip;//伝票計タイトル

                    if (string.IsNullOrEmpty(salesWork.SALESSLIPRF_SLIPNOTERF))
                    {
                        //備考１がない場合は備考２を印字
                        footerRow["DADD.SALESFT2NOTERF"] = salesWork.SALESSLIPRF_SLIPNOTE2RF;//伝票備考２
                    }
                    else
                    {
                        footerRow["DADD.SALESFT2NOTERF"] = salesWork.SALESSLIPRF_SLIPNOTERF;//伝票備考１
                    }

                }

                footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                footerRow[ct_col_Sort_DepositSlipNo] = 0;
                footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                footerRow[ct_col_Sort_DetailRowNo] = 0;
                footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;

                table.Rows.Add(footerRow);


                DataRow footer2Row = table.NewRow();

                if (_salesSubTtlTax)
                {
                    // 消費税を印字する場合は、伝票合計金額(税込)を次の行に印字する
                    footer2Row["DADD.SALESFT2PRICERF"] = salesWork.SALESSLIPRF_SALESTOTALTAXINCRF;//伝票合計金額(税込)
                    footer2Row["DADD.SALESFT2TITLERF"] = parameter.FooterTitleOfSlipTaxInc;//課税合計タイトル
                    footer2Row["DADD.SALESFT2PRICE2RF"] = salesWork.SALESSLIPRF_SALESTOTALTAXINCRF;//伝票合計金額(税込)
                    footer2Row["DADD.SALESFT2TITLE2RF"] = parameter.FooterTitleOfSlipTaxInc2;//課税合計タイトル２
                    if (string.IsNullOrEmpty(salesWork.SALESSLIPRF_SLIPNOTERF))
                    {
                        footer2Row["DADD.SALESFT2NOTERF"] = DBNull.Value;
                    }
                    else
                    {
                        footer2Row["DADD.SALESFT2NOTERF"] = salesWork.SALESSLIPRF_SLIPNOTE2RF;//伝票備考２
                    }


                    footer2Row[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                    footer2Row[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                    footer2Row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                    footer2Row[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                    footer2Row[ct_col_Sort_DepositSlipNo] = 0;
                    footer2Row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                    footer2Row[ct_col_Sort_DetailRowNo] = 0;
                    footer2Row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;

                    table.Rows.Add(footer2Row);
                }
                else
                {
                    // 消費税がない場合は、伝票備考１・伝票備考２があるときのみ、伝票備考２の行を追加する
                    if (!string.IsNullOrEmpty(salesWork.SALESSLIPRF_SLIPNOTERF) && !string.IsNullOrEmpty(salesWork.SALESSLIPRF_SLIPNOTE2RF))
                    {
                        footer2Row["DADD.SALESFT2NOTERF"] = salesWork.SALESSLIPRF_SLIPNOTE2RF;//伝票備考２

                        footer2Row[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                        footer2Row[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                        footer2Row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                        footer2Row[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                        footer2Row[ct_col_Sort_DepositSlipNo] = 0;
                        footer2Row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                        footer2Row[ct_col_Sort_DetailRowNo] = 0;
                        footer2Row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;

                        table.Rows.Add(footer2Row);
                    }   
                }
            }
        }
        #region
        /// <summary>
        /// 売上フッタ３　売上明細　摘要処理(山西商会個別対応)
        /// </summary>
        /// <param name="table">テーブル</param>
        /// <param name="salesWork">売上データ</param>
        /// <param name="dmdPrtPtnWork">印刷条件</param>
        /// <param name="parameter">印刷レイアウトパラメータ</param>
        /// <param name="headWork">ヘッダー情報</param>
        /// <remarks>
        /// <br>Note        : 売上フッタ３　売上明細　摘要処理(山西商会個別対応)</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectSalesFooter3(ref DataTable table, EBooksFrePBillDetailWork salesWork, DmdPrtPtnWork dmdPrtPtnWork, BillDmdPrintParameter parameter, EBooksFrePBillHeadWork headWork)
        {
            int RowCount = salesWork.SALESDETAILRF_SALESROWNORF * 10;

            //印字する
            if (dmdPrtPtnWork.SlipTtlPrtDiv == 0)
            {
                //伝票備考行を追加
                DataRow footerNoteRow = table.NewRow();
                footerNoteRow["DADD.SALESFT3NOTERF"] = "（摘要）" + salesWork.SALESSLIPRF_SLIPNOTERF; //伝票備考
                footerNoteRow["DADD.FOOTER3PRINTRF"] = 96; //売上フッタ３（明細行判定用）
                RowCount = RowCount + 10;

                #region [ソート・合計対応]
                footerNoteRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                footerNoteRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                footerNoteRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                footerNoteRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                footerNoteRow[ct_col_Sort_DepositSlipNo] = 0;
                footerNoteRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                footerNoteRow[ct_col_Sort_DetailRowNo] = RowCount.ToString();
                footerNoteRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                #endregion

                table.Rows.Add(footerNoteRow);


                DataRow footerRow = table.NewRow();
                //伝票転嫁・明細転嫁・請求転嫁の場合
                footerRow["DADD.SALESFT3PRICERF"] = salesWork.SALESSLIPRF_SALESPRTTOTALTAXEXCRF;//伝票合計金額(税抜)
                footerRow["DADD.SALESFT3TITLERF"] = parameter.FooterTitleOfSlip;//伝票計タイトル
                footerRow["DADD.SALESFT3NOTERF"] = DBNull.Value;
                footerRow["DADD.FOOTER3PRINTRF"] = 97; //売上フッタ３（明細行判定用）
                RowCount = RowCount + 10;

                #region [ソート・合計対応]
                footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                footerRow[ct_col_Sort_DepositSlipNo] = 0;
                footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                footerRow[ct_col_Sort_DetailRowNo] = RowCount.ToString();
                footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                #endregion

                table.Rows.Add(footerRow);

                DataRow footer2Row = table.NewRow();
                if ( (salesWork.SALESSLIPRF_CONSTAXLAYMETHODRF == 0 || salesWork.SALESSLIPRF_CONSTAXLAYMETHODRF == 1) &&
                     (headWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0))
                {
                    //// 非課税以外の場合は、消費税を次の行に印字する
                    // 伝票転嫁or明細転嫁で、かつ親の場合は、消費税を次の行に印字する
                    footer2Row["DADD.SALESFT3PRICERF"] = salesWork.SALESSLIPRF_SALESSUBTOTALTAXRF;//消費税金額
                    footer2Row["DADD.SALESFT3TITLERF"] = parameter.FooterTitleOfTax;//消費税タイトル
                    footer2Row["DADD.SALESFT3NOTERF"] = DBNull.Value;
                    footer2Row["DADD.FOOTER3PRINTRF"] = 98; //売上フッタ３（明細行判定用）
                    RowCount = RowCount + 10;

                    # region [ソート・合計対応]
                    footer2Row[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                    footer2Row[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                    footer2Row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                    footer2Row[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                    footer2Row[ct_col_Sort_DepositSlipNo] = 0;
                    footer2Row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                    footer2Row[ct_col_Sort_DetailRowNo] = RowCount.ToString();
                    footer2Row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                    #endregion

                    table.Rows.Add(footer2Row);
                }
            }

            int detailRowNo = salesWork.SALESDETAILRF_SALESROWNORF;
            DataRow spacefooter = table.NewRow();
            detailRowNo++;

            spacefooter["SALESSLIPRF.SALESDATERF"] = salesWork.SALESSLIPRF_SALESDATERF;
            spacefooter["SALESSLIPRF.SALESSLIPCDRF"] = salesWork.SALESSLIPRF_SALESSLIPCDRF;
            spacefooter["SALESDETAILRF.SALESMONEYTAXINCRF"] = salesWork.SALESDETAILRF_SALESMONEYTAXINCRF;
            spacefooter["SALESDETAILRF.SALESROWNORF"] = detailRowNo;//←行番号
            spacefooter["DADD.FOOTER3PRINTRF"] = 99; //売上フッタ３（明細行判定用）
            RowCount = RowCount + 10;

            # region [ソート・合計対応]
            spacefooter[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
            spacefooter[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
            spacefooter[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
            spacefooter[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
            spacefooter[ct_col_Sort_DepositSlipNo] = 0;
            spacefooter[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
            spacefooter[ct_col_Sort_DetailRowNo] = RowCount.ToString();
            spacefooter[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
            # endregion

            table.Rows.Add(spacefooter);
        }

        /// <summary>
        /// 売上ヘッダ２  売上明細　摘要処理(山西商会個別対応)
        /// </summary>
        /// <param name="table">テーブル</param>
        /// <param name="salesWork">売上データ</param>
        /// <param name="allDefSet">レポート情報</param>
        /// <param name="headWork">ヘッダー情報</param>
        /// <param name="detailRowCount">明細数</param>
        /// <param name="row">行データ</param>
        /// <param name="sortDetail">ソートフラグ</param>
        /// <remarks>
        /// <br>Note        : 売上ヘッダ２  売上明細　摘要処理(山西商会個別対応)</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectSalesHeader2(ref DataTable table, EBooksFrePBillDetailWork salesWork, EBooksFrePBillHeadWork headWork, bool sortDetail, DataRow row, AllDefSetWork allDefSet, int detailRowCount)
        {

            DataRow headerRow = table.NewRow();

            //日付展開（通常）(売上ヘッダ用)
            ExtractDate(ref headerRow, allDefSet.EraNameDispCd1, salesWork.SALESSLIPRF_SALESDATERF, "DADD.SALESDATEHD2", false);// yyyymmdd

            headerRow["DADD.FULLMODELHD2RF"] = "（型式）" + GetFullModel(salesWork); //型式(売上ヘッダ２)
            headerRow["DADD.MODELHALFNAMEHD2RF"] = "（車名）" + salesWork.ACCEPTODRCARRF_MODELHALFNAMERF;//車種名(売上ヘッダ２)
            if (string.IsNullOrEmpty(salesWork.ACCEPTODRCARRF_MODELHALFNAMERF))
            {
                headerRow["DADD.MODELHALFNAMEHD2RF"] = "（車名）" + GetKanaString(salesWork.ACCEPTODRCARRF_MODELFULLNAMERF);
            }
            headerRow["DADD.SALESSLIPNUMHD2RF"] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;//売上伝票番号

            if (ReportItemDic.ContainsKey("DADD.HEADFULLMODEL2RF"))
            {
                if (detailRowCount == 1)
                {
                    headerRow["DADD.HEADFULLMODEL2RF"] = salesWork.ACCEPTODRCARRF_FULLMODELRF;
                }
                else
                {
                    headerRow["DADD.HEADFULLMODEL2RF"] = DBNull.Value;
                    return;
                }
            }

            //売上伝票区分コード
            switch (salesWork.SALESSLIPRF_SALESSLIPCDRF)
            {
                case 0:
                    //売上
                    headerRow["DADD.SALESSLIPCDCHANGERF"] = 01;
                    break;
                case 1:
                    //返品
                    headerRow["DADD.SALESSLIPCDCHANGERF"] = 02;
                    break;
            }
            headerRow["CUSTDMDPRCRF.CUSTOMERCODERF"] = headWork.CUSTDMDPRCRF_CUSTOMERCODERF;


            if (sortDetail)
            {
                //明細の途中で印字するので削除
                headerRow["DADD.SALESSLIPNUMHD2RF"] = DBNull.Value;
                headerRow["DADD.SALESSLIPCDCHANGERF"] = DBNull.Value;
                headerRow["DADD.SALESDATEHD2FMRF"] = DBNull.Value;
                headerRow["DADD.SALESDATEHD2FDRF"] = DBNull.Value;
                headerRow["DADD.SALESDATEHD2FLPRF"] = DBNull.Value;
                headerRow["DADD.FOOTER3PRINTRF"] = 0;

                headerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                headerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                headerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                headerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                headerRow[ct_col_Sort_DepositSlipNo] = 0;
                headerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                headerRow[ct_col_Sort_DetailRowNo] = salesWork.SALESDETAILRF_SALESROWNORF * 10 - 5;
                headerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
            }
            else
            {
                headerRow["DADD.FOOTER3PRINTRF"] = 0;

                headerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                headerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                headerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                headerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                headerRow[ct_col_Sort_DepositSlipNo] = 0;
                headerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Header;
                //headerRow[ct_col_Sort_DetailRowNo] = 0;
                headerRow[ct_col_Sort_DetailRowNo] = 0;
                headerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
            }

            table.Rows.Add(headerRow);
        }

        /// <summary>
        /// 売上ヘッダ３　売上明細　摘要処理・ページ変更後１行目用(山西商会個別対応)
        /// </summary>
        /// <param name="headerRow">ヘッダー行</param>
        /// <param name="row">行データ</param>
        /// <param name="allDefSet">レポート情報</param>
        /// <param name="pageCount">頁数</param>
        /// <param name="rowCount">明細数</param>
        /// <remarks>
        /// <br>Note        : 売上ヘッダ３　売上明細　摘要処理・ページ変更後１行目用(山西商会個別対応)</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectSalesHeader2NewPage(ref DataRow headerRow, DataRow row, AllDefSetWork allDefSet, Int32 pageCount, Int32 rowCount)
        {
            headerRow["DADD.FULLMODELHD2RF"] = "（型式）" + row["DADD.FULLMODELHD2SEARCHRF"];
            headerRow["DADD.MODELHALFNAMEHD2RF"] = "（車名）" + row["DADD.MODELHALFNAMEHD2SEARCHRF"];
            headerRow["DADD.SALESSLIPNUMHD2RF"] = row[ct_col_Sort_SalesSlipNo];
            headerRow["CUSTDMDPRCRF.CUSTOMERCODERF"] = row[ct_col_Sort_CustomerCode];
            headerRow["DADD.SALESDATEHD2FMRF"] = row["DADD.SALESDATEHD2SEARCHFMRF"];
            headerRow["DADD.SALESDATEHD2FDRF"] = row["DADD.SALESDATEHD2SEARCHFDRF"];
            headerRow["DADD.SALESDATEHD2FLPRF"] = row["DADD.SALESDATEHD2SEARCHFLPRF"];
            headerRow["DADD.SALESSLIPCDCHANGERF"] = row["DADD.SALESSLIPCDCHANGESEARCHRF"];

                headerRow[ct_col_Sort_CustomerCode] = row[ct_col_Sort_CustomerCode];
                headerRow[ct_col_Sort_Date] = row[ct_col_Sort_Date];
                headerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                headerRow[ct_col_Sort_SalesSlipNo] = row[ct_col_Sort_SalesSlipNo];
                headerRow[ct_col_Sort_DepositSlipNo] = 0;
                headerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                headerRow[ct_col_Sort_DetailRowNo] = rowCount.ToString();
                headerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                headerRow[ct_col_PageCount] = pageCount;
        }

        /// <summary>
        /// 金種：その他の行　追加処理
        /// </summary>
        /// <param name="prevDetailWork">更新元明細データ</param>
        /// <param name="otherDepositPrice">金種</param>
        /// <returns>請求明細ワーク</returns>
        /// <remarks>
        /// <br>Note        : 金種：その他の行　追加処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static EBooksFrePBillDetailWork AddOtherDeposit(EBooksFrePBillDetailWork prevDetailWork, Int64 otherDepositPrice)
        {
            EBooksFrePBillDetailWork addWork = new EBooksFrePBillDetailWork();

            addWork.DEPSITMAINRF_ACPTANODRSTATUSRF = prevDetailWork.DEPSITMAINRF_ACPTANODRSTATUSRF;
            addWork.DEPSITMAINRF_ACPTANODRSTATUSRF = prevDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
            addWork.DEPSITMAINRF_SALESSLIPNUMRF = prevDetailWork.DEPSITMAINRF_SALESSLIPNUMRF;
            addWork.DEPSITMAINRF_ADDUPSECCODERF = prevDetailWork.DEPSITMAINRF_ADDUPSECCODERF;
            addWork.DEPSITMAINRF_SUBSECTIONCODERF = prevDetailWork.DEPSITMAINRF_SUBSECTIONCODERF;
            addWork.DEPSITMAINRF_DEPOSITDATERF = prevDetailWork.DEPSITMAINRF_DEPOSITDATERF;
            addWork.DEPSITMAINRF_ADDUPADATERF = prevDetailWork.DEPSITMAINRF_ADDUPADATERF;
            addWork.DEPSITMAINRF_DEPOSITRF = prevDetailWork.DEPSITMAINRF_DEPOSITRF;
            addWork.DEPSITMAINRF_FEEDEPOSITRF = 0;
            addWork.DEPSITMAINRF_DISCOUNTDEPOSITRF = prevDetailWork.DEPSITMAINRF_DISCOUNTDEPOSITRF;
            addWork.DEPSITMAINRF_AUTODEPOSITCDRF = prevDetailWork.DEPSITMAINRF_AUTODEPOSITCDRF;
            addWork.DEPSITMAINRF_DEPOSITCDRF = prevDetailWork.DEPSITMAINRF_DEPOSITCDRF;
            addWork.DEPSITMAINRF_DRAFTDRAWINGDATERF = prevDetailWork.DEPSITMAINRF_DRAFTDRAWINGDATERF;
            addWork.DEPSITMAINRF_DRAFTKINDRF = prevDetailWork.DEPSITMAINRF_DRAFTKINDRF;
            addWork.DEPSITMAINRF_DRAFTKINDNAMERF = prevDetailWork.DEPSITMAINRF_DRAFTKINDNAMERF;
            addWork.DEPSITMAINRF_DRAFTDIVIDENAMERF = prevDetailWork.DEPSITMAINRF_DRAFTDIVIDENAMERF;
            addWork.DEPSITMAINRF_DRAFTNORF = prevDetailWork.DEPSITMAINRF_DRAFTNORF;
            addWork.DEPSITMAINRF_CUSTOMERCODERF = prevDetailWork.DEPSITMAINRF_CUSTOMERCODERF;
            addWork.DEPSITMAINRF_CLAIMCODERF = prevDetailWork.DEPSITMAINRF_CLAIMCODERF;
            addWork.DEPSITMAINRF_OUTLINERF = prevDetailWork.DEPSITMAINRF_OUTLINERF;
            addWork.SUBDEP_SUBSECTIONNAMERF = prevDetailWork.SUBDEP_SUBSECTIONNAMERF;
            addWork.DEPSITMAINRF_DEPOSITSLIPNORF = prevDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
            addWork.DEPSITDTLRF_MONEYKINDNAMERF = "その他";
            addWork.DEPSITDTLRF_MONEYKINDDIVRF = prevDetailWork.DEPSITDTLRF_MONEYKINDDIVRF;
            addWork.DEPSITDTLRF_VALIDITYTERMRF = prevDetailWork.DEPSITDTLRF_VALIDITYTERMRF;
            addWork.DEPSITDTLRF_DEPOSITRF = otherDepositPrice;
            addWork.DEPSITDTLRF_DEPOSITROWNORF = 7;
            addWork.DEPSITDTLRF_MONEYKINDCODERF = 58;
            addWork.DEPSITMAINRF_CUSTOMERCODERF = prevDetailWork.DEPSITMAINRF_CUSTOMERCODERF;

            return addWork;
        }
        #endregion
        /// <summary>
        /// 請求書ヘッダコピー適用処理
        /// </summary>
        /// <param name="row">対象行</param>
        /// <param name="headWork">ヘッダー情報</param>
        /// <param name="dmdPrtPtnWork">印刷条件</param>
        /// <param name="frePrtPSetWork">レポート情報</param>
        /// <param name="billAllStWork">全体設定</param>
        /// <param name="billPrtStWork">印刷設定</param>
        /// <param name="allDefSet">全体初期表示設定</param>
        /// <param name="printPrice">価格印刷区分</param>
        /// <param name="taxTitle">税率タイトル</param>
        /// <param name="ofsThisSalesTaxIncTtl">合計金額(税込)タイトル</param>
        /// <param name="pageTtlList">ページタイトル</param>
        /// <param name="TotalTaxRateSalesMoney">税率別合計金額</param>
        /// <param name="dTaxRate1">税率1</param>
        /// <param name="dTaxRate2">税2</param>
        /// <remarks>
        /// <br>Note        : 請求書ヘッダコピー適用処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note  : 2022/10/18 田村顕成</br>
        /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// </remarks>
        //private static void ReflectBillHeader(ref DataRow row, EBooksFrePBillHeadWork headWork, DmdPrtPtnWork dmdPrtPtnWork, FrePrtPSetWork frePrtPSetWork, BillAllStWork billAllStWork, BillPrtStWork billPrtStWork, AllDefSetWork allDefSet, bool printPrice, string taxTitle, string ofsThisSalesTaxIncTtl, Dictionary<int, Int64> pageTtlList) // DEL 田村顕成 2022/10/18
        private static void ReflectBillHeader(ref DataRow row, EBooksFrePBillHeadWork headWork, DmdPrtPtnWork dmdPrtPtnWork, FrePrtPSetWork frePrtPSetWork, BillAllStWork billAllStWork, BillPrtStWork billPrtStWork, AllDefSetWork allDefSet, bool printPrice, string taxTitle, string ofsThisSalesTaxIncTtl, Dictionary<int, Int64> pageTtlList, TaxRateSalesMoney TotalTaxRateSalesMoney, Double dTaxRate1, Double dTaxRate2) // ADD 田村顕成 2022/10/18
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");   // 2010/10/05 Add
            // 親子判定
            bool isParent = (headWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0);

            # region [請求書ヘッダ]
            row["CUSTDMDPRCRF.ADDUPSECCODERF"] = headWork.CUSTDMDPRCRF_ADDUPSECCODERF;
            row["CUSTDMDPRCRF.CLAIMCODERF"] = headWork.CUSTDMDPRCRF_CLAIMCODERF;
            row["CUSTDMDPRCRF.CLAIMNAMERF"] = headWork.CUSTDMDPRCRF_CLAIMNAMERF;
            row["CUSTDMDPRCRF.CLAIMNAME2RF"] = headWork.CUSTDMDPRCRF_CLAIMNAME2RF;
            row["CUSTDMDPRCRF.CLAIMSNMRF"] = headWork.CUSTDMDPRCRF_CLAIMSNMRF;
            row["CUSTDMDPRCRF.CUSTOMERCODERF"] = headWork.CUSTDMDPRCRF_CUSTOMERCODERF;
            row["CUSTDMDPRCRF.CUSTOMERNAMERF"] = headWork.CUSTDMDPRCRF_CUSTOMERNAMERF;
            row["CUSTDMDPRCRF.CUSTOMERNAME2RF"] = headWork.CUSTDMDPRCRF_CUSTOMERNAME2RF;
            row["CUSTDMDPRCRF.CUSTOMERSNMRF"] = headWork.CUSTDMDPRCRF_CUSTOMERSNMRF;
            row["CUSTDMDPRCRF.ADDUPDATERF"] = headWork.CUSTDMDPRCRF_ADDUPDATERF;
            row["CUSTDMDPRCRF.ADDUPYEARMONTHRF"] = headWork.CUSTDMDPRCRF_ADDUPYEARMONTHRF;
            row["CUSTDMDPRCRF.THISTIMEFEEDMDNRMLRF"] = headWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF;
            row["CUSTDMDPRCRF.THISTIMEDISDMDNRMLRF"] = headWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF;
            row["CUSTDMDPRCRF.THISTIMEDMDNRMLRF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
            row["CUSTDMDPRCRF.THISTIMETTLBLCDMDRF"] = headWork.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF;
            row["CUSTDMDPRCRF.OFSTHISTIMESALESRF"] = headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF;
            row["CUSTDMDPRCRF.OFSTHISSALESTAXRF"] = headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF;
            row["CUSTDMDPRCRF.ITDEDOFFSETOUTTAXRF"] = headWork.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF;
            row["CUSTDMDPRCRF.ITDEDOFFSETINTAXRF"] = headWork.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF;
            row["CUSTDMDPRCRF.ITDEDOFFSETTAXFREERF"] = headWork.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF;
            row["CUSTDMDPRCRF.OFFSETOUTTAXRF"] = headWork.CUSTDMDPRCRF_OFFSETOUTTAXRF;
            row["CUSTDMDPRCRF.OFFSETINTAXRF"] = headWork.CUSTDMDPRCRF_OFFSETINTAXRF;
            row["CUSTDMDPRCRF.THISTIMESALESRF"] = headWork.CUSTDMDPRCRF_THISTIMESALESRF;
            row["CUSTDMDPRCRF.THISSALESTAXRF"] = headWork.CUSTDMDPRCRF_THISSALESTAXRF;
            row["CUSTDMDPRCRF.ITDEDSALESOUTTAXRF"] = headWork.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF;
            row["CUSTDMDPRCRF.ITDEDSALESINTAXRF"] = headWork.CUSTDMDPRCRF_ITDEDSALESINTAXRF;
            row["CUSTDMDPRCRF.ITDEDSALESTAXFREERF"] = headWork.CUSTDMDPRCRF_ITDEDSALESTAXFREERF;
            row["CUSTDMDPRCRF.SALESOUTTAXRF"] = headWork.CUSTDMDPRCRF_SALESOUTTAXRF;
            row["CUSTDMDPRCRF.SALESINTAXRF"] = headWork.CUSTDMDPRCRF_SALESINTAXRF;
            row["CUSTDMDPRCRF.THISSALESPRCTAXRGDSRF"] = headWork.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF;
            row["CUSTDMDPRCRF.TTLITDEDRETOUTTAXRF"] = headWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF;
            row["CUSTDMDPRCRF.TTLITDEDRETINTAXRF"] = headWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF;
            row["CUSTDMDPRCRF.TTLITDEDRETTAXFREERF"] = headWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF;
            row["CUSTDMDPRCRF.TTLRETOUTERTAXRF"] = headWork.CUSTDMDPRCRF_TTLRETOUTERTAXRF;
            row["CUSTDMDPRCRF.TTLRETINNERTAXRF"] = headWork.CUSTDMDPRCRF_TTLRETINNERTAXRF;
            row["CUSTDMDPRCRF.THISSALESPRCTAXDISRF"] = headWork.CUSTDMDPRCRF_THISSALESPRCTAXDISRF;
            row["CUSTDMDPRCRF.TTLITDEDDISOUTTAXRF"] = headWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF;
            row["CUSTDMDPRCRF.TTLITDEDDISINTAXRF"] = headWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF;
            row["CUSTDMDPRCRF.TTLITDEDDISTAXFREERF"] = headWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF;
            row["CUSTDMDPRCRF.TTLDISOUTERTAXRF"] = headWork.CUSTDMDPRCRF_TTLDISOUTERTAXRF;
            row["CUSTDMDPRCRF.TTLDISINNERTAXRF"] = headWork.CUSTDMDPRCRF_TTLDISINNERTAXRF;
            row["CUSTDMDPRCRF.TAXADJUSTRF"] = headWork.CUSTDMDPRCRF_TAXADJUSTRF;
            row["CUSTDMDPRCRF.BALANCEADJUSTRF"] = headWork.CUSTDMDPRCRF_BALANCEADJUSTRF;
            row["CUSTDMDPRCRF.AFCALDEMANDPRICERF"] = headWork.CUSTDMDPRCRF_AFCALDEMANDPRICERF;
            row["CUSTDMDPRCRF.ACPODRTTL2TMBFBLDMDRF"] = headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF;
            row["CUSTDMDPRCRF.ACPODRTTL3TMBFBLDMDRF"] = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF;
            row["CUSTDMDPRCRF.STARTCADDUPUPDDATERF"] = headWork.CUSTDMDPRCRF_STARTCADDUPUPDDATERF;
            row["CUSTDMDPRCRF.SALESSLIPCOUNTRF"] = headWork.CUSTDMDPRCRF_SALESSLIPCOUNTRF;
            row["CUSTDMDPRCRF.BILLPRINTDATERF"] = headWork.CUSTDMDPRCRF_BILLPRINTDATERF;
            row["CUSTDMDPRCRF.EXPECTEDDEPOSITDATERF"] = headWork.CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF;
            row["CUSTDMDPRCRF.COLLECTCONDRF"] = headWork.CUSTDMDPRCRF_COLLECTCONDRF;
            row["CUSTDMDPRCRF.CONSTAXLAYMETHODRF"] = headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF;
            row["CUSTDMDPRCRF.CONSTAXRATERF"] = headWork.CUSTDMDPRCRF_CONSTAXRATERF;
            row["SECHED.SECTIONGUIDENMRF"] = headWork.SECHED_SECTIONGUIDENMRF;
            row["SECHED.SECTIONGUIDESNMRF"] = headWork.SECHED_SECTIONGUIDESNMRF;
            row["SECHED.COMPANYNAMECD1RF"] = headWork.SECHED_COMPANYNAMECD1RF;
            row["COMPANYNMRF.COMPANYPRRF"] = headWork.COMPANYNMRF_COMPANYPRRF;
            row["COMPANYNMRF.COMPANYNAME1RF"] = headWork.COMPANYNMRF_COMPANYNAME1RF;
            row["COMPANYNMRF.COMPANYNAME2RF"] = headWork.COMPANYNMRF_COMPANYNAME2RF;
            row["COMPANYNMRF.POSTNORF"] = headWork.COMPANYNMRF_POSTNORF;
            row["COMPANYNMRF.ADDRESS1RF"] = headWork.COMPANYNMRF_ADDRESS1RF;
            row["COMPANYNMRF.ADDRESS3RF"] = headWork.COMPANYNMRF_ADDRESS3RF;
            row["COMPANYNMRF.ADDRESS4RF"] = headWork.COMPANYNMRF_ADDRESS4RF;
            row["COMPANYNMRF.COMPANYTELNO1RF"] = headWork.COMPANYNMRF_COMPANYTELNO1RF;
            row["COMPANYNMRF.COMPANYTELNO2RF"] = headWork.COMPANYNMRF_COMPANYTELNO2RF;
            row["COMPANYNMRF.COMPANYTELNO3RF"] = headWork.COMPANYNMRF_COMPANYTELNO3RF;
            row["COMPANYNMRF.COMPANYTELTITLE1RF"] = headWork.COMPANYNMRF_COMPANYTELTITLE1RF;
            row["COMPANYNMRF.COMPANYTELTITLE2RF"] = headWork.COMPANYNMRF_COMPANYTELTITLE2RF;
            row["COMPANYNMRF.COMPANYTELTITLE3RF"] = headWork.COMPANYNMRF_COMPANYTELTITLE3RF;
            row["COMPANYNMRF.TRANSFERGUIDANCERF"] = headWork.COMPANYNMRF_TRANSFERGUIDANCERF;
            row["COMPANYNMRF.ACCOUNTNOINFO1RF"] = headWork.COMPANYNMRF_ACCOUNTNOINFO1RF;
            row["COMPANYNMRF.ACCOUNTNOINFO2RF"] = headWork.COMPANYNMRF_ACCOUNTNOINFO2RF;
            row["COMPANYNMRF.ACCOUNTNOINFO3RF"] = headWork.COMPANYNMRF_ACCOUNTNOINFO3RF;
            row["COMPANYNMRF.COMPANYSETNOTE1RF"] = headWork.COMPANYNMRF_COMPANYSETNOTE1RF;
            row["COMPANYNMRF.COMPANYSETNOTE2RF"] = headWork.COMPANYNMRF_COMPANYSETNOTE2RF;
            row["COMPANYNMRF.IMAGEINFOCODERF"] = headWork.COMPANYNMRF_IMAGEINFOCODERF;
            row["COMPANYNMRF.COMPANYURLRF"] = headWork.COMPANYNMRF_COMPANYURLRF;
            row["COMPANYNMRF.COMPANYPRSENTENCE2RF"] = headWork.COMPANYNMRF_COMPANYPRSENTENCE2RF;
            row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = headWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF;
            row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = headWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF;
            row["IMAGEINFORF.IMAGEINFODATARF"] = headWork.IMAGEINFORF_IMAGEINFODATARF;
            row["CSTCST.CUSTOMERSUBCODERF"] = headWork.CSTCST_CUSTOMERSUBCODERF;
            row["CSTCST.NAMERF"] = headWork.CSTCST_NAMERF;
            row["CSTCST.NAME2RF"] = headWork.CSTCST_NAME2RF;
            row["CSTCST.HONORIFICTITLERF"] = headWork.CSTCST_HONORIFICTITLERF;
            row["CSTCST.KANARF"] = headWork.CSTCST_KANARF;
            row["CSTCST.CUSTOMERSNMRF"] = headWork.CSTCST_CUSTOMERSNMRF;
            row["CSTCST.OUTPUTNAMECODERF"] = headWork.CSTCST_OUTPUTNAMECODERF;
            row["CSTCST.POSTNORF"] = headWork.CSTCST_POSTNORF;
            row["CSTCST.ADDRESS1RF"] = headWork.CSTCST_ADDRESS1RF;
            row["CSTCST.ADDRESS3RF"] = headWork.CSTCST_ADDRESS3RF;
            row["CSTCST.ADDRESS4RF"] = headWork.CSTCST_ADDRESS4RF;
            row["CSTCST.CUSTANALYSCODE1RF"] = headWork.CSTCST_CUSTANALYSCODE1RF;
            row["CSTCST.CUSTANALYSCODE2RF"] = headWork.CSTCST_CUSTANALYSCODE2RF;
            row["CSTCST.CUSTANALYSCODE3RF"] = headWork.CSTCST_CUSTANALYSCODE3RF;
            row["CSTCST.CUSTANALYSCODE4RF"] = headWork.CSTCST_CUSTANALYSCODE4RF;
            row["CSTCST.CUSTANALYSCODE5RF"] = headWork.CSTCST_CUSTANALYSCODE5RF;
            row["CSTCST.CUSTANALYSCODE6RF"] = headWork.CSTCST_CUSTANALYSCODE6RF;
            row["CSTCST.NOTE1RF"] = headWork.CSTCST_NOTE1RF;
            row["CSTCST.NOTE2RF"] = headWork.CSTCST_NOTE2RF;
            row["CSTCST.NOTE3RF"] = headWork.CSTCST_NOTE3RF;
            row["CSTCST.NOTE4RF"] = headWork.CSTCST_NOTE4RF;
            row["CSTCST.NOTE5RF"] = headWork.CSTCST_NOTE5RF;
            row["CSTCST.NOTE6RF"] = headWork.CSTCST_NOTE6RF;
            row["CSTCST.NOTE7RF"] = headWork.CSTCST_NOTE7RF;
            row["CSTCST.NOTE8RF"] = headWork.CSTCST_NOTE8RF;
            row["CSTCST.NOTE9RF"] = headWork.CSTCST_NOTE9RF;
            row["CSTCST.NOTE10RF"] = headWork.CSTCST_NOTE10RF;
            row["CSTCLM.CUSTOMERSUBCODERF"] = headWork.CSTCLM_CUSTOMERSUBCODERF;
            row["CSTCLM.NAMERF"] = headWork.CSTCLM_NAMERF;
            row["CSTCLM.NAME2RF"] = headWork.CSTCLM_NAME2RF;
            row["CSTCLM.HONORIFICTITLERF"] = headWork.CSTCLM_HONORIFICTITLERF;
            row["CSTCLM.KANARF"] = headWork.CSTCLM_KANARF;
            row["CSTCLM.CUSTOMERSNMRF"] = headWork.CSTCLM_CUSTOMERSNMRF;
            row["CSTCLM.OUTPUTNAMECODERF"] = headWork.CSTCLM_OUTPUTNAMECODERF;
            row["CSTCLM.POSTNORF"] = headWork.CSTCLM_POSTNORF;
            row["CSTCLM.ADDRESS1RF"] = headWork.CSTCLM_ADDRESS1RF;
            row["CSTCLM.ADDRESS3RF"] = headWork.CSTCLM_ADDRESS3RF;
            row["CSTCLM.ADDRESS4RF"] = headWork.CSTCLM_ADDRESS4RF;
            row["CSTCLM.CUSTANALYSCODE1RF"] = headWork.CSTCLM_CUSTANALYSCODE1RF;
            row["CSTCLM.CUSTANALYSCODE2RF"] = headWork.CSTCLM_CUSTANALYSCODE2RF;
            row["CSTCLM.CUSTANALYSCODE3RF"] = headWork.CSTCLM_CUSTANALYSCODE3RF;
            row["CSTCLM.CUSTANALYSCODE4RF"] = headWork.CSTCLM_CUSTANALYSCODE4RF;
            row["CSTCLM.CUSTANALYSCODE5RF"] = headWork.CSTCLM_CUSTANALYSCODE5RF;
            row["CSTCLM.CUSTANALYSCODE6RF"] = headWork.CSTCLM_CUSTANALYSCODE6RF;
            row["CSTCLM.NOTE1RF"] = headWork.CSTCLM_NOTE1RF;
            row["CSTCLM.NOTE2RF"] = headWork.CSTCLM_NOTE2RF;
            row["CSTCLM.NOTE3RF"] = headWork.CSTCLM_NOTE3RF;
            row["CSTCLM.NOTE4RF"] = headWork.CSTCLM_NOTE4RF;
            row["CSTCLM.NOTE5RF"] = headWork.CSTCLM_NOTE5RF;
            row["CSTCLM.NOTE6RF"] = headWork.CSTCLM_NOTE6RF;
            row["CSTCLM.NOTE7RF"] = headWork.CSTCLM_NOTE7RF;
            row["CSTCLM.NOTE8RF"] = headWork.CSTCLM_NOTE8RF;
            row["CSTCLM.NOTE9RF"] = headWork.CSTCLM_NOTE9RF;
            row["CSTCLM.NOTE10RF"] = headWork.CSTCLM_NOTE10RF;
# if DEBUG
            row["COMPANYINFRF.COMPANYNAME1RF"] = "●●●●●●●●●●";
            row["COMPANYINFRF.COMPANYNAME2RF"] = "●●●●●●●●●●";
            row["COMPANYINFRF.POSTNORF"] = "●●●●●●●●●●";
            row["COMPANYINFRF.ADDRESS1RF"] = "●●●●●●●●●●";
            row["COMPANYINFRF.ADDRESS3RF"] = "●●●●●●●●●●";
            row["COMPANYINFRF.ADDRESS4RF"] = "●●●●●●●●●●";
            row["COMPANYINFRF.COMPANYTELNO1RF"] = "●●●●●●●●●●";
            row["COMPANYINFRF.COMPANYTELNO2RF"] = "●●●●●●●●●●";
            row["COMPANYINFRF.COMPANYTELNO3RF"] = "●●●●●●●●●●";
            row["COMPANYINFRF.COMPANYTELTITLE1RF"] = "●●●●●●●●●●";
            row["COMPANYINFRF.COMPANYTELTITLE2RF"] = "●●●●●●●●●●";
            row["COMPANYINFRF.COMPANYTELTITLE3RF"] = "●●●●●●●●●●";
# endif
            row["DEPOSITSTRF.DEPOSITSTKINDCD1RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD1RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD2RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD2RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD3RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD3RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD4RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD4RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD5RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD5RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD6RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD6RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD7RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD7RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD8RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD8RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD9RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD9RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD10RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD10RF;
            row["DEPT01.MONEYKINDNAMERF"] = headWork.DEPT01_MONEYKINDNAMERF;
            row["DEPT01.DEPOSITRF"] = headWork.DEPT01_DEPOSITRF;
            row["DEPT02.MONEYKINDNAMERF"] = headWork.DEPT02_MONEYKINDNAMERF;
            row["DEPT02.DEPOSITRF"] = headWork.DEPT02_DEPOSITRF;
            row["DEPT03.MONEYKINDNAMERF"] = headWork.DEPT03_MONEYKINDNAMERF;
            row["DEPT03.DEPOSITRF"] = headWork.DEPT03_DEPOSITRF;
            row["DEPT04.MONEYKINDNAMERF"] = headWork.DEPT04_MONEYKINDNAMERF;
            row["DEPT04.DEPOSITRF"] = headWork.DEPT04_DEPOSITRF;
            row["DEPT05.MONEYKINDNAMERF"] = headWork.DEPT05_MONEYKINDNAMERF;
            row["DEPT05.DEPOSITRF"] = headWork.DEPT05_DEPOSITRF;
            row["DEPT06.MONEYKINDNAMERF"] = headWork.DEPT06_MONEYKINDNAMERF;
            row["DEPT06.DEPOSITRF"] = headWork.DEPT06_DEPOSITRF;
            row["DEPT07.MONEYKINDNAMERF"] = headWork.DEPT07_MONEYKINDNAMERF;
            row["DEPT07.DEPOSITRF"] = headWork.DEPT07_DEPOSITRF;
            row["DEPT08.MONEYKINDNAMERF"] = headWork.DEPT08_MONEYKINDNAMERF;
            row["DEPT08.DEPOSITRF"] = headWork.DEPT08_DEPOSITRF;
            row["DEPT09.MONEYKINDNAMERF"] = headWork.DEPT09_MONEYKINDNAMERF;
            row["DEPT09.DEPOSITRF"] = headWork.DEPT09_DEPOSITRF;
            row["DEPT10.MONEYKINDNAMERF"] = headWork.DEPT10_MONEYKINDNAMERF;
            row["DEPT10.DEPOSITRF"] = headWork.DEPT10_DEPOSITRF;
            row["HADD.ADDUPDATEFYRF"] = headWork.HADD_ADDUPDATEFYRF;
            row["HADD.ADDUPDATEFSRF"] = headWork.HADD_ADDUPDATEFSRF;
            row["HADD.ADDUPDATEFWRF"] = headWork.HADD_ADDUPDATEFWRF;
            row["HADD.ADDUPDATEFMRF"] = headWork.HADD_ADDUPDATEFMRF;
            row["HADD.ADDUPDATEFDRF"] = headWork.HADD_ADDUPDATEFDRF;
            row["HADD.ADDUPDATEFGRF"] = headWork.HADD_ADDUPDATEFGRF;
            row["HADD.ADDUPDATEFRRF"] = headWork.HADD_ADDUPDATEFRRF;
            row["HADD.ADDUPDATEFLSRF"] = headWork.HADD_ADDUPDATEFLSRF;
            row["HADD.ADDUPDATEFLPRF"] = headWork.HADD_ADDUPDATEFLPRF;
            row["HADD.ADDUPDATEFLYRF"] = headWork.HADD_ADDUPDATEFLYRF;
            row["HADD.ADDUPDATEFLMRF"] = headWork.HADD_ADDUPDATEFLMRF;
            row["HADD.ADDUPDATEFLDRF"] = headWork.HADD_ADDUPDATEFLDRF;
            row["HADD.ADDUPYEARMONTHFYRF"] = headWork.HADD_ADDUPYEARMONTHFYRF;
            row["HADD.ADDUPYEARMONTHFSRF"] = headWork.HADD_ADDUPYEARMONTHFSRF;
            row["HADD.ADDUPYEARMONTHFWRF"] = headWork.HADD_ADDUPYEARMONTHFWRF;
            row["HADD.ADDUPYEARMONTHFMRF"] = headWork.HADD_ADDUPYEARMONTHFMRF;
            row["HADD.ADDUPYEARMONTHFGRF"] = headWork.HADD_ADDUPYEARMONTHFGRF;
            row["HADD.ADDUPYEARMONTHFRRF"] = headWork.HADD_ADDUPYEARMONTHFRRF;
            row["HADD.ADDUPYEARMONTHFLSRF"] = headWork.HADD_ADDUPYEARMONTHFLSRF;
            row["HADD.ADDUPYEARMONTHFLPRF"] = headWork.HADD_ADDUPYEARMONTHFLPRF;
            row["HADD.ADDUPYEARMONTHFLYRF"] = headWork.HADD_ADDUPYEARMONTHFLYRF;
            row["HADD.ADDUPYEARMONTHFLMRF"] = headWork.HADD_ADDUPYEARMONTHFLMRF;
            row["HADD.STARTCADDUPUPDDATEFYRF"] = headWork.HADD_STARTCADDUPUPDDATEFYRF;
            row["HADD.STARTCADDUPUPDDATEFSRF"] = headWork.HADD_STARTCADDUPUPDDATEFSRF;
            row["HADD.STARTCADDUPUPDDATEFWRF"] = headWork.HADD_STARTCADDUPUPDDATEFWRF;
            row["HADD.STARTCADDUPUPDDATEFMRF"] = headWork.HADD_STARTCADDUPUPDDATEFMRF;
            row["HADD.STARTCADDUPUPDDATEFDRF"] = headWork.HADD_STARTCADDUPUPDDATEFDRF;
            row["HADD.STARTCADDUPUPDDATEFGRF"] = headWork.HADD_STARTCADDUPUPDDATEFGRF;
            row["HADD.STARTCADDUPUPDDATEFRRF"] = headWork.HADD_STARTCADDUPUPDDATEFRRF;
            row["HADD.STARTCADDUPUPDDATEFLSRF"] = headWork.HADD_STARTCADDUPUPDDATEFLSRF;
            row["HADD.STARTCADDUPUPDDATEFLPRF"] = headWork.HADD_STARTCADDUPUPDDATEFLPRF;
            row["HADD.STARTCADDUPUPDDATEFLYRF"] = headWork.HADD_STARTCADDUPUPDDATEFLYRF;
            row["HADD.STARTCADDUPUPDDATEFLMRF"] = headWork.HADD_STARTCADDUPUPDDATEFLMRF;
            row["HADD.STARTCADDUPUPDDATEFLDRF"] = headWork.HADD_STARTCADDUPUPDDATEFLDRF;
            row["HADD.BILLPRINTDATEFYRF"] = headWork.HADD_BILLPRINTDATEFYRF;
            row["HADD.BILLPRINTDATEFSRF"] = headWork.HADD_BILLPRINTDATEFSRF;
            row["HADD.BILLPRINTDATEFWRF"] = headWork.HADD_BILLPRINTDATEFWRF;
            row["HADD.BILLPRINTDATEFMRF"] = headWork.HADD_BILLPRINTDATEFMRF;
            row["HADD.BILLPRINTDATEFDRF"] = headWork.HADD_BILLPRINTDATEFDRF;
            row["HADD.BILLPRINTDATEFGRF"] = headWork.HADD_BILLPRINTDATEFGRF;
            row["HADD.BILLPRINTDATEFRRF"] = headWork.HADD_BILLPRINTDATEFRRF;
            row["HADD.BILLPRINTDATEFLSRF"] = headWork.HADD_BILLPRINTDATEFLSRF;
            row["HADD.BILLPRINTDATEFLPRF"] = headWork.HADD_BILLPRINTDATEFLPRF;
            row["HADD.BILLPRINTDATEFLYRF"] = headWork.HADD_BILLPRINTDATEFLYRF;
            row["HADD.BILLPRINTDATEFLMRF"] = headWork.HADD_BILLPRINTDATEFLMRF;
            row["HADD.BILLPRINTDATEFLDRF"] = headWork.HADD_BILLPRINTDATEFLDRF;
            row["HADD.EXPECTEDDEPOSITDATEFYRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFYRF;
            row["HADD.EXPECTEDDEPOSITDATEFSRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFSRF;
            row["HADD.EXPECTEDDEPOSITDATEFWRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFWRF;
            row["HADD.EXPECTEDDEPOSITDATEFMRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFMRF;
            row["HADD.EXPECTEDDEPOSITDATEFDRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFDRF;
            row["HADD.EXPECTEDDEPOSITDATEFGRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFGRF;
            row["HADD.EXPECTEDDEPOSITDATEFRRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFRRF;
            row["HADD.EXPECTEDDEPOSITDATEFLSRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFLSRF;
            row["HADD.EXPECTEDDEPOSITDATEFLPRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFLPRF;
            row["HADD.EXPECTEDDEPOSITDATEFLYRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFLYRF;
            row["HADD.EXPECTEDDEPOSITDATEFLMRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFLMRF;
            row["HADD.EXPECTEDDEPOSITDATEFLDRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFLDRF;
            row["HADD.COLLECTCONDNMRF"] = headWork.HADD_COLLECTCONDNMRF;
            row["HADD.DMDFORMTITLERF"] = headWork.HADD_DMDFORMTITLERF;
            row["HADD.DMDFORMTITLE2RF"] = headWork.HADD_DMDFORMTITLE2RF;
            row["HADD.DMDFORMCOMENT1RF"] = headWork.HADD_DMDFORMCOMENT1RF;
            row["HADD.DMDFORMCOMENT2RF"] = headWork.HADD_DMDFORMCOMENT2RF;
            row["HADD.DMDFORMCOMENT3RF"] = headWork.HADD_DMDFORMCOMENT3RF;
            row["HADD.DMDNRMLEXDISRF"] = headWork.HADD_DMDNRMLEXDISRF;
            row["HADD.DMDNRMLEXFEERF"] = headWork.HADD_DMDNRMLEXFEERF;
            row["HADD.DMDNRMLEXDISFEERF"] = headWork.HADD_DMDNRMLEXDISFEERF;
            row["HADD.DMDNRMLSAMDISFEERF"] = headWork.HADD_DMDNRMLSAMDISFEERF;
            row["HADD.THISSALESANDADJUSTRF"] = headWork.HADD_THISSALESANDADJUSTRF;
            row["HADD.THISTAXANDADJUSTRF"] = headWork.HADD_THISTAXANDADJUSTRF;
            row["HADD.ISSUEDAYRF"] = headWork.HADD_ISSUEDAYRF; // 入力発行日付
            row["HADD.ISSUEDAYFYRF"] = headWork.HADD_ISSUEDAYFYRF; // 入力発行日付西暦年
            row["HADD.ISSUEDAYFSRF"] = headWork.HADD_ISSUEDAYFSRF; // 入力発行日付西暦年略
            row["HADD.ISSUEDAYFWRF"] = headWork.HADD_ISSUEDAYFWRF; // 入力発行日付和暦年
            row["HADD.ISSUEDAYFMRF"] = headWork.HADD_ISSUEDAYFMRF; // 入力発行日付月
            row["HADD.ISSUEDAYFDRF"] = headWork.HADD_ISSUEDAYFDRF; // 入力発行日付日
            row["HADD.ISSUEDAYFGRF"] = headWork.HADD_ISSUEDAYFGRF; // 入力発行日付元号
            row["HADD.ISSUEDAYFRRF"] = headWork.HADD_ISSUEDAYFRRF; // 入力発行日付略号
            row["HADD.ISSUEDAYFLSRF"] = headWork.HADD_ISSUEDAYFLSRF; // 入力発行日付リテラル(/)
            row["HADD.ISSUEDAYFLPRF"] = headWork.HADD_ISSUEDAYFLPRF; // 入力発行日付リテラル(.)
            row["HADD.ISSUEDAYFLYRF"] = headWork.HADD_ISSUEDAYFLYRF; // 入力発行日付リテラル(年)
            row["HADD.ISSUEDAYFLMRF"] = headWork.HADD_ISSUEDAYFLMRF; // 入力発行日付リテラル(月)
            row["HADD.ISSUEDAYFLDRF"] = headWork.HADD_ISSUEDAYFLDRF; // 入力発行日付リテラル(日)
            row["CSTCST.HOMETELNORF"] = headWork.CSTCST_HOMETELNORF; // 得意先電話番号（自宅）
            row["CSTCST.OFFICETELNORF"] = headWork.CSTCST_OFFICETELNORF; // 得意先電話番号（勤務先）
            row["CSTCST.PORTABLETELNORF"] = headWork.CSTCST_PORTABLETELNORF; // 得意先電話番号（携帯）
            row["CSTCST.HOMEFAXNORF"] = headWork.CSTCST_HOMEFAXNORF; // 得意先FAX番号（自宅）
            row["CSTCST.OFFICEFAXNORF"] = headWork.CSTCST_OFFICEFAXNORF; // 得意先FAX番号（勤務先）
            row["CSTCST.OTHERSTELNORF"] = headWork.CSTCST_OTHERSTELNORF; // 得意先電話番号（その他）
            row["CSTCLM.HOMETELNORF"] = headWork.CSTCLM_HOMETELNORF; // 請求先電話番号（自宅）
            row["CSTCLM.OFFICETELNORF"] = headWork.CSTCLM_OFFICETELNORF; // 請求先電話番号（勤務先）
            row["CSTCLM.PORTABLETELNORF"] = headWork.CSTCLM_PORTABLETELNORF; // 請求先電話番号（携帯）
            row["CSTCLM.HOMEFAXNORF"] = headWork.CSTCLM_HOMEFAXNORF; // 請求先FAX番号（自宅）
            row["CSTCLM.OFFICEFAXNORF"] = headWork.CSTCLM_OFFICEFAXNORF; // 請求先FAX番号（勤務先）
            row["CSTCLM.OTHERSTELNORF"] = headWork.CSTCLM_OTHERSTELNORF; // 請求先電話番号（その他）
            row["ALITMDSPNMRF.HOMETELNODSPNAMERF"] = headWork.ALITMDSPNMRF_HOMETELNODSPNAMERF; // 自宅TEL表示名称
            row["ALITMDSPNMRF.OFFICETELNODSPNAMERF"] = headWork.ALITMDSPNMRF_OFFICETELNODSPNAMERF; // 勤務先TEL表示名称
            row["ALITMDSPNMRF.MOBILETELNODSPNAMERF"] = headWork.ALITMDSPNMRF_MOBILETELNODSPNAMERF; // 携帯TEL表示名称
            row["ALITMDSPNMRF.HOMEFAXNODSPNAMERF"] = headWork.ALITMDSPNMRF_HOMEFAXNODSPNAMERF; // 自宅FAX表示名称
            row["ALITMDSPNMRF.OFFICEFAXNODSPNAMERF"] = headWork.ALITMDSPNMRF_OFFICEFAXNODSPNAMERF; // 勤務先FAX表示名称
            row["ALITMDSPNMRF.OTHERTELNODSPNAMERF"] = headWork.ALITMDSPNMRF_OTHERTELNODSPNAMERF; // その他TEL表示名称
            if (Convert.ToInt32(row["HADD.ISSUEDAYRF"]) < headWork.CSTCLM_CUSTAGENTCHGDATERF)
            {
                row["HADD.SALESEMPLOYEECDRF"] = headWork.CSTCLM_OLDCUSTOMERAGENTCDRF;    // 旧得意先担当者コード
            }
            else
            {
                row["HADD.SALESEMPLOYEECDRF"] = headWork.CSTCLM_CUSTOMERAGENTCDRF;    // 得意先担当者コード
            }

            if (ReportItemDic.ContainsKey("HADD.EXPECTEDDEPOSITMONEYRF"))
            {
                // 入金予定額の項目がある場合のみ計算する。
                row["HADD.EXPECTEDDEPOSITMONEYRF"] = GetExpectedDepositMoney(headWork, billAllStWork);  // 入金予定額
            }
            else
            {
                row["HADD.EXPECTEDDEPOSITMONEYRF"] = DBNull.Value;
            }
            DateTime calcCollectDay;
            calcCollectDay = CalcCollectDate(headWork);
            row["HADD.CALCEXPECTEDDEPOSITDATEFDRF"] = calcCollectDay.Day;
            row["HADD.CALCEXPECTEDDEPOSITDATEFMRF"] = calcCollectDay.Month;
            row["HADD.LASTPAGECOMMENTRF"] = "最終頁";
            row["HADD.TOTALTAXINCTITLERF"] = "税込計";    // 鑑税込計タイトル
            row["HADD.OFSTHISTIMESALESLASTPAGERF"] = headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF;
            # endregion

            # region [集金日]
            // 集金日（←常に請求先の集金日で置き換える）
            row["CSTCST.COLLECTMONEYNAMERF"] = headWork.CSTCLM_COLLECTMONEYNAMERF; // 請求先集金月区分名称
            row["CSTCST.COLLECTMONEYDAYRF"] = headWork.CSTCLM_COLLECTMONEYDAYRF; // 請求先集金日
            if ( IsZero( headWork.CSTCLM_COLLECTMONEYDAYRF ) ) row["CSTCST.COLLECTMONEYDAYRF"] = DBNull.Value;
            # endregion

            # region [鑑項目(自動以外)]
            // 前回請求金額（通常）←前回＋２回前＋３回前
            row["CUSTDMDPRCRF.LASTTIMEDEMANDRF"] = headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF
                                                   + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF
                                                   + headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF;
            // 前回請求金額（前回のみ）←前回のみ
            row[ct_col_HDmd_LastTimeDemandOrg] = headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF;
            // 今回売上額(税込)
            row["HADD.THISSALESANDADJUSTTAXINCRF"] = headWork.HADD_THISSALESANDADJUSTRF 
                                                     + headWork.HADD_THISTAXANDADJUSTRF;
            
            // 相殺後売上金額(税込)
            row["HADD.OFSTHISSALESTAXINCRF"] = headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF 
                                             + headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF;
            row["HADD.OFSTHISSALESTAXINC2RF"] = headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF
                                             + headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF;
            // 転嫁方式＝9:非課税
            if ( headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF == 9 )
            {
                // 消費税・税込金額を印字しない
                row["CUSTDMDPRCRF.OFSTHISSALESTAXRF"] = DBNull.Value; // 相殺後今回売上消費税
                row["CUSTDMDPRCRF.THISSALESTAXRF"] = DBNull.Value; // 今回売上消費税
                row["CUSTDMDPRCRF.THISSALESPRCTAXRGDSRF"] = DBNull.Value; // 今回売上返品消費税
                row["CUSTDMDPRCRF.THISSALESPRCTAXDISRF"] = DBNull.Value; // 今回売上値引消費税
                row["HADD.THISTAXANDADJUSTRF"] = DBNull.Value; // 今回売上調整消費税 
                row["HADD.THISSALESANDADJUSTTAXINCRF"] = DBNull.Value; // 今回売上額(税込)
                row["HADD.OFSTHISSALESTAXINCRF"] = DBNull.Value;// 相殺後売上金額(税込)
                // 非課税は消費税を含まない
                row["HADD.OFSTHISSALESTAXINC2RF"] = headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF;
                row["HADD.TOTALTAXINCTITLERF"] = DBNull.Value;
            }

            // 今回返品値引額（売上返品＋売上値引）←-1を掛けてプラスにする
            row[ct_col_ThisTimeRetDis] = -1 * (
                                                headWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF // 返品外税対象
                                                + headWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF // 返品内税対象
                                                + headWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF // 返品非課税対象
                                                + headWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF // 値引外税対象
                                                + headWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF // 値引内税対象
                                                + headWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF // 値引非課税対象
                                              );
            // 返品のみ（-1かけてプラスにする）
            row["CUSTDMDPRCRF.THISSALESPRICRGDSRF"] = -1 * (
                                                                headWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF // 返品外税対象
                                                                + headWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF // 返品内税対象
                                                                + headWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF // 返品非課税対象
                                                            );
            // 値引のみ（-1かけてプラスにする）
            row["CUSTDMDPRCRF.THISSALESPRICDISRF"] = -1 * (
                                                                headWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF // 値引外税対象
                                                                + headWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF // 値引内税対象
                                                                + headWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF // 値引非課税対象
                                                            );
            // 売上－返品
            row["HADD.SALESANDRGDSRF"] = headWork.HADD_THISSALESANDADJUSTRF - (Int64)row["CUSTDMDPRCRF.THISSALESPRICRGDSRF"];
            // 売上－値引
            row["HADD.SALESANDDISRF"] = headWork.HADD_THISSALESANDADJUSTRF - (Int64)row["CUSTDMDPRCRF.THISSALESPRICDISRF"];

            // (入金合計ディクショナリ生成)
            Dictionary<int, Int64> deptTotalDic = new Dictionary<int, long>();
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD1RF, headWork.DEPT01_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD2RF, headWork.DEPT02_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD3RF, headWork.DEPT03_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD4RF, headWork.DEPT04_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD5RF, headWork.DEPT05_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD6RF, headWork.DEPT06_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD7RF, headWork.DEPT07_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD8RF, headWork.DEPT08_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD9RF, headWork.DEPT09_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD10RF, headWork.DEPT10_DEPOSITRF );

            // ディクショナリからのセット処理
            Int64 dept51 = GetFromDeptTotalDic( deptTotalDic, 51 ); // 入金合計（現金）
            Int64 dept52 = GetFromDeptTotalDic( deptTotalDic, 52 ); // 入金合計（振込）
            Int64 dept53 = GetFromDeptTotalDic( deptTotalDic, 53 ); // 入金合計（小切手）
            Int64 dept54 = GetFromDeptTotalDic( deptTotalDic, 54 ); // 入金合計（手形）
            Int64 dept55 = headWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF; // 入金合計（手数料）
            Int64 dept56 = GetFromDeptTotalDic( deptTotalDic, 56 ); // 入金合計（相殺）
            Int64 dept57 = headWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF; // 入金合計（値引）
            Int64 dept58 = GetFromDeptTotalDic( deptTotalDic, 58 ); // 入金合計（その他）
            Int64 dept59 = GetFromDeptTotalDic( deptTotalDic, 59 ); // 入金合計（口座振込）
            Int64 dept60 = GetFromDeptTotalDic( deptTotalDic, 60 ); // 入金合計（ファクタリング）

            row["HADD.DEPTTOTALCASHRF"] = dept51; // 入金合計（現金）
            row["HADD.DEPTTOTALTRANSFERRF"] = dept52; // 入金合計（振込）
            row["HADD.DEPTTOTALCHECKRF"] = dept53; // 入金合計（小切手）
            row["HADD.DEPTTOTALDRAFTRF"] = dept54; // 入金合計（手形）
            row["HADD.DEPTTOTALOFFSETRF"] = dept56; // 入金合計（相殺）
            row["HADD.DEPTTOTALOTHERSRF"] = dept58; // 入金合計（その他）
            row["HADD.DEPTTOTALACCOUNTRF"] = dept59; // 入金合計（口座振込）
            row["HADD.DEPTTOTALFACTORINGRF"] = dept60; // 入金合計（ファクタリング）

            // (合算項目)
            row["HADD.DEPTTOTALSUM1RF"] = dept55 + dept58; // 入金合計（手数料＋その他）
            row["HADD.DEPTTOTALSUM2RF"] = dept57 + dept58; // 入金合計（値引＋その他）
            row["HADD.DEPTTOTALSUM3RF"] = dept56 + dept58; // 入金合計（相殺＋その他）
            row["HADD.DEPTTOTALSUM4RF"] = dept55 + dept56 + dept58; // 入金合計（手数料＋相殺＋その他）
            row["HADD.DEPTTOTALSUM5RF"] = dept57 + dept55 + dept58; // 入金合計（値引＋手数料＋その他）
            row["HADD.DEPTTOTALSUM6RF"] = dept57 + dept56 + dept58; // 入金合計（値引＋相殺＋その他）
            row["HADD.DEPTTOTALSUM7RF"] = dept55 + dept56 + dept57 + dept58; // 入金合計（手数料＋相殺＋値引＋その他）
            row["HADD.DEPTTOTALSUM8RF"] = dept51 + dept52 + dept53 + dept54; // 入金合計（現金＋振込＋小切手＋手形）
            // (合算項目分を除く合計)
            row["HADD.DEPTTOTALEXC1RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept55 + dept58); // 入金合計（手数料・その他除く）
            row["HADD.DEPTTOTALEXC2RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept57 + dept58); // 入金合計（値引・その他除く）
            row["HADD.DEPTTOTALEXC3RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept56 + dept58); // 入金合計（相殺・その他除く）
            row["HADD.DEPTTOTALEXC4RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept55 + dept56 + dept58); // 入金合計（手数料・相殺・その他除く）
            row["HADD.DEPTTOTALEXC5RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept57 + dept55 + dept58); // 入金合計（値引・手数料・その他除く）
            row["HADD.DEPTTOTALEXC6RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept57 + dept56 + dept58); // 入金合計（値引・相殺・その他除く）
            row["HADD.DEPTTOTALEXC7RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept55 + dept56 + dept57 + dept58); // 入金合計（手数料・相殺・値引・その他除く）
            row["HADD.DEPTTOTALEXC8RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept51 + dept52 + dept53 + dept54); // 入金合計（現金・振込・小切手・手形除く）
            # endregion
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            if ((ReportItemDic.ContainsKey("TAX.HFTOTALCONSTAXRATETITLERF") ||
                 ReportItemDic.ContainsKey("TAX.HFTOTALSALESMONEYTAXEXCRF") ||
                   ReportItemDic.ContainsKey("TAX.HFTAXRATE1RF") ||
                     ReportItemDic.ContainsKey("TAX.HFTAXRATE1SALESTAXEXCRF") ||
                       ReportItemDic.ContainsKey("TAX.DTLRTOTALCONSTAXRATETITLERF") ||
                         ReportItemDic.ContainsKey("TAX.DTLTOTALSALESMONEYTAXEXCRF") ||
                           ReportItemDic.ContainsKey("TAX.DTLTAXRATE1RF") ||
                             ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXEXCRF")))
            {
                if (TotalTaxRateSalesMoney != null)
                {
                    row["TAX.HFTOTALCONSTAXRATETITLERF"] = "*合 計*";
                    // 合計金額=税率１金額 + 税率２金額 + 非課税金額 + その他金額
                    row["TAX.HFTOTALSALESMONEYTAXEXCRF"] = TotalTaxRateSalesMoney.TaxRate1SalesMoney + TotalTaxRateSalesMoney.TaxRate2SalesMoney + TotalTaxRateSalesMoney.TaxOutSalesMoney + TotalTaxRateSalesMoney.OtherSalesMoney;
                    // 税率１
                    row["TAX.HFTAXRATE1RF"] = Convert.ToString(dTaxRate1 * 100) + "%";
                    row["TAX.HFTAXRATE1SALESTAXEXCRF"] = TotalTaxRateSalesMoney.TaxRate1SalesMoney;

                    // 税率２
                    row["TAX.HFTAXRATE2RF"] = Convert.ToString(dTaxRate2 * 100) + "%";
                    row["TAX.HFTAXRATE2SALESTAXEXCRF"] = TotalTaxRateSalesMoney.TaxRate2SalesMoney;

                    // 非課税
                    row["TAX.HFTAXOUTITLERF"] = "非課税";
                    row["TAX.HFTAXOUTSALESTAXEXCRF"] = TotalTaxRateSalesMoney.TaxOutSalesMoney;

                    // その他
                    row["TAX.HFOTHERTAXRATERF"] = "その他";
                    row["TAX.HFOTHERTAXRATESALESTAXEXCRF"] = TotalTaxRateSalesMoney.OtherSalesMoney;

                    if (isParent)
                    {
                        row["TAX.HFTAXTITLERF"] = "税";
                        row["TAX.HFTAXRATE1SALESTAXRF"] = TotalTaxRateSalesMoney.TaxRate1SalesPriceConsTax;     // 税率１　　　消費税金額
                        row["TAX.HFTAXRATE2SALESTAXRF"] = TotalTaxRateSalesMoney.TaxRate2SalesPriceConsTax;     // 税率２　　　消費税金額
                        row["TAX.HFOTHERTAXRATESALESTAXRF"] = TotalTaxRateSalesMoney.OtherSalesPriceConsTax;    // その他税率　消費税金額
                    }
                }
            }
            // --- ADD END   田村顕成 2022/10/18 -----<<<<<

            // 印刷用得意先情報
            # region [印刷用得意先情報]
            if ( isParent )
            {
                // 集計レコード→請求先情報をセット
                # region [請求先毎集計]
                row["CADD.CUSTOMERCODERF"] = headWork.CUSTDMDPRCRF_CLAIMCODERF; // 印刷得意先コード
                row["CADD.CUSTOMERSUBCODERF"] = headWork.CSTCLM_CUSTOMERSUBCODERF; // 印刷得意先サブコード
                row["CADD.NAMERF"] = headWork.CSTCLM_NAMERF; // 印刷得意先名称
                row["CADD.NAME2RF"] = headWork.CSTCLM_NAME2RF; // 印刷得意先名称2
                row["CADD.HONORIFICTITLERF"] = headWork.CSTCLM_HONORIFICTITLERF; // 印刷得意先敬称
                row["CADD.HONORIFICTITLE2RF"] = headWork.CSTCLM_HONORIFICTITLERF; // 印刷得意先敬称（印字位置変更用）
                row["CADD.KANARF"] = headWork.CSTCLM_KANARF; // 印刷得意先カナ
                row["CADD.CUSTOMERSNMRF"] = headWork.CSTCLM_CUSTOMERSNMRF; // 印刷得意先略称
                row["CADD.OUTPUTNAMECODERF"] = headWork.CSTCLM_OUTPUTNAMECODERF; // 印刷得意先諸口コード
                row["CADD.POSTNORF"] = headWork.CSTCLM_POSTNORF; // 印刷得意先郵便番号
                row["CADD.ADDRESS1RF"] = headWork.CSTCLM_ADDRESS1RF; // 印刷得意先住所1（都道府県市区郡・町村・字）
                row["CADD.ADDRESS3RF"] = headWork.CSTCLM_ADDRESS3RF; // 印刷得意先住所3（番地）
                row["CADD.ADDRESS4RF"] = headWork.CSTCLM_ADDRESS4RF; // 印刷得意先住所4（アパート名称）
                row["CADD.ADDRESS123RF"] = headWork.CSTCLM_ADDRESS1RF + headWork.CSTCLM_ADDRESS3RF + headWork.CSTCLM_ADDRESS4RF; // 印刷得意先住所1+2+3
                row["CADD.CUSTANALYSCODE1RF"] = headWork.CSTCLM_CUSTANALYSCODE1RF; // 印刷得意先分析コード1
                row["CADD.CUSTANALYSCODE2RF"] = headWork.CSTCLM_CUSTANALYSCODE2RF; // 印刷得意先分析コード2
                row["CADD.CUSTANALYSCODE3RF"] = headWork.CSTCLM_CUSTANALYSCODE3RF; // 印刷得意先分析コード3
                row["CADD.CUSTANALYSCODE4RF"] = headWork.CSTCLM_CUSTANALYSCODE4RF; // 印刷得意先分析コード4
                row["CADD.CUSTANALYSCODE5RF"] = headWork.CSTCLM_CUSTANALYSCODE5RF; // 印刷得意先分析コード5
                row["CADD.CUSTANALYSCODE6RF"] = headWork.CSTCLM_CUSTANALYSCODE6RF; // 印刷得意先分析コード6
                row["CADD.NOTE1RF"] = headWork.CSTCLM_NOTE1RF; // 印刷得意先備考1
                row["CADD.NOTE2RF"] = headWork.CSTCLM_NOTE2RF; // 印刷得意先備考2
                row["CADD.NOTE3RF"] = headWork.CSTCLM_NOTE3RF; // 印刷得意先備考3
                row["CADD.NOTE4RF"] = headWork.CSTCLM_NOTE4RF; // 印刷得意先備考4
                row["CADD.NOTE5RF"] = headWork.CSTCLM_NOTE5RF; // 印刷得意先備考5
                row["CADD.NOTE6RF"] = headWork.CSTCLM_NOTE6RF; // 印刷得意先備考6
                row["CADD.NOTE7RF"] = headWork.CSTCLM_NOTE7RF; // 印刷得意先備考7
                row["CADD.NOTE8RF"] = headWork.CSTCLM_NOTE8RF; // 印刷得意先備考8
                row["CADD.NOTE9RF"] = headWork.CSTCLM_NOTE9RF; // 印刷得意先備考9
                row["CADD.NOTE10RF"] = headWork.CSTCLM_NOTE10RF; // 印刷得意先備考10

                // 印刷用名称情報
                if ( !string.IsNullOrEmpty( headWork.CSTCLM_NAME2RF ) )
                {
                    row["CADD.PRINTCUSTOMERNAME1RF"] = headWork.CSTCLM_NAMERF; // 印刷用得意先名称（上段）
                    row["CADD.PRINTCUSTOMERNAME2RF"] = headWork.CSTCLM_NAME2RF; // 印刷用得意先名称（下段）
                }
                else
                {
                    row["CADD.PRINTCUSTOMERNAME1RF"] = DBNull.Value; // 印刷用得意先名称（上段）
                    row["CADD.PRINTCUSTOMERNAME2RF"] = headWork.CSTCLM_NAMERF; // 印刷用得意先名称（下段）
                }
                row["CADD.HOMETELNORF"] = headWork.CSTCLM_HOMETELNORF; // 印刷得意先電話番号（自宅）
                row["CADD.OFFICETELNORF"] = headWork.CSTCLM_OFFICETELNORF; // 印刷得意先電話番号（勤務先）
                row["CADD.PORTABLETELNORF"] = headWork.CSTCLM_PORTABLETELNORF; // 印刷得意先電話番号（携帯）
                row["CADD.HOMEFAXNORF"] = headWork.CSTCLM_HOMEFAXNORF; // 印刷得意先FAX番号（自宅）
                row["CADD.OFFICEFAXNORF"] = headWork.CSTCLM_OFFICEFAXNORF; // 印刷得意先FAX番号（勤務先）
                row["CADD.OTHERSTELNORF"] = headWork.CSTCLM_OTHERSTELNORF; // 印刷得意先電話番号（その他）

                // 得意先名１＋得意先名２
                row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = headWork.CSTCLM_NAMERF + headWork.CSTCLM_NAME2RF;
                // 得意先名１＋得意先名２＋敬称
                row["HADD.PRINTCUSTOMERNAMEJOIN12HNRF"] = headWork.CSTCLM_NAMERF + headWork.CSTCLM_NAME2RF + "　" + headWork.CSTCLM_HONORIFICTITLERF;

                //印刷用得意先名称（下段）を10桁まで取得
                string printCustomerName2 = (string)row["CADD.PRINTCUSTOMERNAME2RF"];
                printCustomerName2 = printCustomerName2.PadRight(10, ' ');
                printCustomerName2 = printCustomerName2.Substring(0, 10).TrimEnd();

                //印刷用得意先名称（下段）＋空白＋敬称
                row["CADD.PRINTCUSTOMERNAME2HNRF"] = printCustomerName2 + "  " + (string)row["CSTCST.HONORIFICTITLERF"];

                //印刷用得意先名称２を10桁まで取得
                string name2 = (string)row["CADD.NAME2RF"];
                name2 = name2.PadLeft(10, ' ');
                name2 = name2.Substring(0, 10).TrimEnd();

                //印刷用得意先名称２＋空白＋敬称
                row["CADD.NAME2HNRF"] = name2 + "  " + (string)row["CADD.HONORIFICTITLERF"];

                // 得意先名１＋得意先名２の桁数によって敬称と敬称１のどちらを印字するか制御する
                // 敬称１がある時のみ処理を行う
                if (ReportItemDic.ContainsKey("CADD.HONORIFICTITLE2RF"))
                {
                    int custNameNum = sjisEnc.GetByteCount(headWork.CSTCLM_NAMERF + headWork.CSTCLM_NAME2RF);
                    if (custNameNum > 20)
                    {
                        // 敬称１を印字
                        row["CADD.HONORIFICTITLERF"] = DBNull.Value; // 印刷得意先敬称
                    }
                    else
                    {
                        // 敬称を印字
                        row["CADD.HONORIFICTITLE2RF"] = DBNull.Value; // 印刷得意先敬称（印字位置変更用）
                    }
                }

                # endregion
            }
            else
            {
                // 得意先毎のレコード→得意先情報をセット
                # region [得意先毎]
                row["CADD.CUSTOMERCODERF"] = headWork.CUSTDMDPRCRF_CUSTOMERCODERF; // 印刷得意先コード
                row["CADD.CUSTOMERSUBCODERF"] = headWork.CSTCST_CUSTOMERSUBCODERF; // 印刷得意先サブコード
                row["CADD.NAMERF"] = headWork.CSTCST_NAMERF; // 印刷得意先名称
                row["CADD.NAME2RF"] = headWork.CSTCST_NAME2RF; // 印刷得意先名称2
                row["CADD.HONORIFICTITLERF"] = headWork.CSTCST_HONORIFICTITLERF; // 印刷得意先敬称
                row["CADD.KANARF"] = headWork.CSTCST_KANARF; // 印刷得意先カナ
                row["CADD.CUSTOMERSNMRF"] = headWork.CSTCST_CUSTOMERSNMRF; // 印刷得意先略称
                row["CADD.OUTPUTNAMECODERF"] = headWork.CSTCST_OUTPUTNAMECODERF; // 印刷得意先諸口コード
                row["CADD.POSTNORF"] = headWork.CSTCST_POSTNORF; // 印刷得意先郵便番号
                row["CADD.ADDRESS1RF"] = headWork.CSTCST_ADDRESS1RF; // 印刷得意先住所1（都道府県市区郡・町村・字）
                row["CADD.ADDRESS3RF"] = headWork.CSTCST_ADDRESS3RF; // 印刷得意先住所3（番地）
                row["CADD.ADDRESS4RF"] = headWork.CSTCST_ADDRESS4RF; // 印刷得意先住所4（アパート名称）
                row["CADD.ADDRESS123RF"] = headWork.CSTCST_ADDRESS1RF + headWork.CSTCST_ADDRESS3RF + headWork.CSTCST_ADDRESS4RF; // 印刷得意先住所1+2+3
                row["CADD.CUSTANALYSCODE1RF"] = headWork.CSTCST_CUSTANALYSCODE1RF; // 印刷得意先分析コード1
                row["CADD.CUSTANALYSCODE2RF"] = headWork.CSTCST_CUSTANALYSCODE2RF; // 印刷得意先分析コード2
                row["CADD.CUSTANALYSCODE3RF"] = headWork.CSTCST_CUSTANALYSCODE3RF; // 印刷得意先分析コード3
                row["CADD.CUSTANALYSCODE4RF"] = headWork.CSTCST_CUSTANALYSCODE4RF; // 印刷得意先分析コード4
                row["CADD.CUSTANALYSCODE5RF"] = headWork.CSTCST_CUSTANALYSCODE5RF; // 印刷得意先分析コード5
                row["CADD.CUSTANALYSCODE6RF"] = headWork.CSTCST_CUSTANALYSCODE6RF; // 印刷得意先分析コード6
                row["CADD.NOTE1RF"] = headWork.CSTCST_NOTE1RF; // 印刷得意先備考1
                row["CADD.NOTE2RF"] = headWork.CSTCST_NOTE2RF; // 印刷得意先備考2
                row["CADD.NOTE3RF"] = headWork.CSTCST_NOTE3RF; // 印刷得意先備考3
                row["CADD.NOTE4RF"] = headWork.CSTCST_NOTE4RF; // 印刷得意先備考4
                row["CADD.NOTE5RF"] = headWork.CSTCST_NOTE5RF; // 印刷得意先備考5
                row["CADD.NOTE6RF"] = headWork.CSTCST_NOTE6RF; // 印刷得意先備考6
                row["CADD.NOTE7RF"] = headWork.CSTCST_NOTE7RF; // 印刷得意先備考7
                row["CADD.NOTE8RF"] = headWork.CSTCST_NOTE8RF; // 印刷得意先備考8
                row["CADD.NOTE9RF"] = headWork.CSTCST_NOTE9RF; // 印刷得意先備考9
                row["CADD.NOTE10RF"] = headWork.CSTCST_NOTE10RF; // 印刷得意先備考10

                // 印刷用名称情報
                if ( !string.IsNullOrEmpty( headWork.CSTCST_NAME2RF ) )
                {
                    row["CADD.PRINTCUSTOMERNAME1RF"] = headWork.CSTCST_NAMERF; // 印刷用得意先名称（上段）
                    row["CADD.PRINTCUSTOMERNAME2RF"] = headWork.CSTCST_NAME2RF; // 印刷用得意先名称（下段）
                }
                else
                {
                    row["CADD.PRINTCUSTOMERNAME1RF"] = DBNull.Value; // 印刷用得意先名称（上段）
                    row["CADD.PRINTCUSTOMERNAME2RF"] = headWork.CSTCST_NAMERF; // 印刷用得意先名称（下段）
                }
                row["CADD.HOMETELNORF"] = headWork.CSTCST_HOMETELNORF; // 印刷得意先電話番号（自宅）
                row["CADD.OFFICETELNORF"] = headWork.CSTCST_OFFICETELNORF; // 印刷得意先電話番号（勤務先）
                row["CADD.PORTABLETELNORF"] = headWork.CSTCST_PORTABLETELNORF; // 印刷得意先電話番号（携帯）
                row["CADD.HOMEFAXNORF"] = headWork.CSTCST_HOMEFAXNORF; // 印刷得意先FAX番号（自宅）
                row["CADD.OFFICEFAXNORF"] = headWork.CSTCST_OFFICEFAXNORF; // 印刷得意先FAX番号（勤務先）
                row["CADD.OTHERSTELNORF"] = headWork.CSTCST_OTHERSTELNORF; // 印刷得意先電話番号（その他）

                // 得意先名１＋得意先名２
                row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = headWork.CSTCST_NAMERF + headWork.CSTCST_NAME2RF;
                // 得意先名１＋得意先名２＋敬称
                row["HADD.PRINTCUSTOMERNAMEJOIN12HNRF"] = headWork.CSTCST_NAMERF + headWork.CSTCST_NAME2RF + "　" + headWork.CSTCST_HONORIFICTITLERF;
               
                //印刷用得意先名称（下段）を10桁まで取得
                string printCustomerName2 = (string)row["CADD.PRINTCUSTOMERNAME2RF"];
                printCustomerName2 = printCustomerName2.PadRight(10, ' ');
                printCustomerName2 = printCustomerName2.Substring(0, 10).TrimEnd();

                //印刷用得意先名称（下段）＋空白＋敬称
                row["CADD.PRINTCUSTOMERNAME2HNRF"] = printCustomerName2 + "  " + (string)row["CSTCST.HONORIFICTITLERF"];

                //印刷用得意先名称２を10桁まで取得
                string name2 = (string)row["CADD.NAME2RF"];
                name2 = name2.PadLeft(10, ' ');
                name2 = name2.Substring(0, 10).TrimEnd();

                //印刷用得意先名称２＋空白＋敬称
                row["CADD.NAME2HNRF"] = name2 + "  " + (string)row["CADD.HONORIFICTITLERF"];

                # endregion

                // 子のとき非印字の固定鑑項目
                # region [子のとき非印字の鑑項目]
                row["CUSTDMDPRCRF.LASTTIMEDEMANDRF"] = DBNull.Value; // 前回請求金額
                row["CUSTDMDPRCRF.THISTIMEFEEDMDNRMLRF"] = DBNull.Value; // 今回手数料額（通常入金）
                row["CUSTDMDPRCRF.THISTIMEDISDMDNRMLRF"] = DBNull.Value; // 今回値引額（通常入金）
                row["CUSTDMDPRCRF.THISTIMEDMDNRMLRF"] = DBNull.Value; // 今回入金金額（通常入金）
                row["CUSTDMDPRCRF.THISTIMETTLBLCDMDRF"] = DBNull.Value; // 今回繰越残高（請求計）
                row["CUSTDMDPRCRF.OFSTHISSALESTAXRF"] = DBNull.Value; // 相殺後今回売上消費税
                row["CUSTDMDPRCRF.THISSALESTAXRF"] = DBNull.Value; // 今回売上消費税
                row["CUSTDMDPRCRF.THISSALESPRCTAXRGDSRF"] = DBNull.Value; // 今回売上返品消費税
                row["CUSTDMDPRCRF.THISSALESPRCTAXDISRF"] = DBNull.Value; // 今回売上値引消費税
                row["CUSTDMDPRCRF.BALANCEADJUSTRF"] = DBNull.Value; // 残高調整額
                row["CUSTDMDPRCRF.AFCALDEMANDPRICERF"] = DBNull.Value; // 計算後請求金額
                row["CUSTDMDPRCRF.ACPODRTTL2TMBFBLDMDRF"] = DBNull.Value; // 受注2回前残高（請求計）
                row["CUSTDMDPRCRF.ACPODRTTL3TMBFBLDMDRF"] = DBNull.Value; // 受注3回前残高（請求計）
                row["DEPT01.MONEYKINDNAMERF"] = DBNull.Value; // 入金金種名称1
                row["DEPT01.DEPOSITRF"] = DBNull.Value; // 入金金額1
                row["DEPT02.MONEYKINDNAMERF"] = DBNull.Value; // 入金金種名称2
                row["DEPT02.DEPOSITRF"] = DBNull.Value; // 入金金額2
                row["DEPT03.MONEYKINDNAMERF"] = DBNull.Value; // 入金金種名称3
                row["DEPT03.DEPOSITRF"] = DBNull.Value; // 入金金額3
                row["DEPT04.MONEYKINDNAMERF"] = DBNull.Value; // 入金金種名称4
                row["DEPT04.DEPOSITRF"] = DBNull.Value; // 入金金額4
                row["DEPT05.MONEYKINDNAMERF"] = DBNull.Value; // 入金金種名称5
                row["DEPT05.DEPOSITRF"] = DBNull.Value; // 入金金額5
                row["DEPT06.MONEYKINDNAMERF"] = DBNull.Value; // 入金金種名称6
                row["DEPT06.DEPOSITRF"] = DBNull.Value; // 入金金額6
                row["DEPT07.MONEYKINDNAMERF"] = DBNull.Value; // 入金金種名称7
                row["DEPT07.DEPOSITRF"] = DBNull.Value; // 入金金額7
                row["DEPT08.MONEYKINDNAMERF"] = DBNull.Value; // 入金金種名称8
                row["DEPT08.DEPOSITRF"] = DBNull.Value; // 入金金額8
                row["DEPT09.MONEYKINDNAMERF"] = DBNull.Value; // 入金金種名称9
                row["DEPT09.DEPOSITRF"] = DBNull.Value; // 入金金額9
                row["DEPT10.MONEYKINDNAMERF"] = DBNull.Value; // 入金金種名称10
                row["DEPT10.DEPOSITRF"] = DBNull.Value; // 入金金額10
                row["HADD.DMDNRMLEXDISRF"] = DBNull.Value; // 入金金額(値引除く)
                row["HADD.DMDNRMLEXFEERF"] = DBNull.Value; // 入金金額(手数料除く)
                row["HADD.DMDNRMLEXDISFEERF"] = DBNull.Value; // 入金金額(値引・手数料除く)
                row["HADD.DMDNRMLSAMDISFEERF"] = DBNull.Value; // 入金金額(値引＋手数料)
                row["HADD.THISTAXANDADJUSTRF"] = DBNull.Value; // 今回売上消費税
                row["HADD.THISSALESANDADJUSTTAXINCRF"] = DBNull.Value; // 今回売上額(税込)
                row["HADD.DEPTTOTALCASHRF"] = DBNull.Value; // 入金合計（現金）
                row["HADD.DEPTTOTALTRANSFERRF"] = DBNull.Value; // 入金合計（振込）
                row["HADD.DEPTTOTALCHECKRF"] = DBNull.Value; // 入金合計（小切手）
                row["HADD.DEPTTOTALDRAFTRF"] = DBNull.Value; // 入金合計（手形）
                row["HADD.DEPTTOTALOFFSETRF"] = DBNull.Value; // 入金合計（相殺）
                row["HADD.DEPTTOTALOTHERSRF"] = DBNull.Value; // 入金合計（その他）
                row["HADD.DEPTTOTALACCOUNTRF"] = DBNull.Value; // 入金合計（口座振込）
                row["HADD.DEPTTOTALFACTORINGRF"] = DBNull.Value; // 入金合計（ファクタリング）
                row["HADD.DEPTTOTALSUM1RF"] = DBNull.Value; // 入金合計（手数料＋その他）
                row["HADD.DEPTTOTALSUM2RF"] = DBNull.Value; // 入金合計（値引＋その他）
                row["HADD.DEPTTOTALSUM3RF"] = DBNull.Value; // 入金合計（相殺＋その他）
                row["HADD.DEPTTOTALSUM4RF"] = DBNull.Value; // 入金合計（手数料＋相殺＋その他）
                row["HADD.DEPTTOTALSUM5RF"] = DBNull.Value; // 入金合計（値引＋手数料＋その他）
                row["HADD.DEPTTOTALSUM6RF"] = DBNull.Value; // 入金合計（値引＋相殺＋その他）
                row["HADD.DEPTTOTALSUM7RF"] = DBNull.Value; // 入金合計（手数料＋相殺＋値引＋その他）
                row["HADD.DEPTTOTALSUM8RF"] = DBNull.Value; // 入金合計（現金＋振込＋小切手＋手形）
                row["HADD.DEPTTOTALEXC1RF"] = DBNull.Value; // 入金合計（手数料・その他除く）
                row["HADD.DEPTTOTALEXC2RF"] = DBNull.Value; // 入金合計（値引・その他除く）
                row["HADD.DEPTTOTALEXC3RF"] = DBNull.Value; // 入金合計（相殺・その他除く）
                row["HADD.DEPTTOTALEXC4RF"] = DBNull.Value; // 入金合計（手数料・相殺・その他除く）
                row["HADD.DEPTTOTALEXC5RF"] = DBNull.Value; // 入金合計（値引・手数料・その他除く）
                row["HADD.DEPTTOTALEXC6RF"] = DBNull.Value; // 入金合計（値引・相殺・その他除く）
                row["HADD.DEPTTOTALEXC7RF"] = DBNull.Value; // 入金合計（手数料・相殺・値引・その他除く）
                row["HADD.DEPTTOTALEXC8RF"] = DBNull.Value; // 入金合計（現金・振込・小切手・手形除く）
                row["HADD.OFSTHISSALESTAXINCRF"] = DBNull.Value; // 相殺後売上金額(税込)
                // 子は消費税を含まない
                row["HADD.OFSTHISSALESTAXINC2RF"] = headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF;
                row["HADD.TOTALTAXINCTITLERF"] = DBNull.Value;
                # endregion
            }

            // 印刷得意先住所1+2+3改行処理
            string ADDRESSEEADDR134RF = row["CADD.ADDRESS123RF"].ToString();
            string prtADDRESSEEADDR134RF = "";
            sjisEnc = Encoding.GetEncoding("Shift_JIS");
            int maxNum = sjisEnc.GetByteCount(ADDRESSEEADDR134RF);
            int nowNum = 0;
            int cutPoint = 0;
            string targetStr = "";
            if (maxNum > 40)
            {
                while (nowNum < 40)
                {
                    targetStr = ADDRESSEEADDR134RF.Substring(cutPoint, 1);
                    if (nowNum + sjisEnc.GetByteCount(targetStr) > 40)
                    {
                        break;
                    }
                    cutPoint++;
                    nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                }
                prtADDRESSEEADDR134RF = ADDRESSEEADDR134RF.Substring(0, cutPoint);
                if (sjisEnc.GetByteCount(prtADDRESSEEADDR134RF) < 40)
                {
                    prtADDRESSEEADDR134RF = prtADDRESSEEADDR134RF + " ";
                }
                ADDRESSEEADDR134RF = ADDRESSEEADDR134RF.Substring(cutPoint, ADDRESSEEADDR134RF.Length - cutPoint);

                maxNum = sjisEnc.GetByteCount(ADDRESSEEADDR134RF);
                if (maxNum > 40)
                {
                    nowNum = 0;
                    cutPoint = 0;
                    while (nowNum < 40)
                    {
                        targetStr = ADDRESSEEADDR134RF.Substring(cutPoint, 1);
                        if (nowNum + sjisEnc.GetByteCount(targetStr) > 40)
                        {
                            break;
                        }
                        cutPoint++;
                        nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                    }
                    prtADDRESSEEADDR134RF = prtADDRESSEEADDR134RF + ADDRESSEEADDR134RF.Substring(0, cutPoint);
                    if (sjisEnc.GetByteCount(prtADDRESSEEADDR134RF) < 80)
                    {
                        prtADDRESSEEADDR134RF = prtADDRESSEEADDR134RF + " ";
                    }
                }
                else
                {
                    prtADDRESSEEADDR134RF = prtADDRESSEEADDR134RF + ADDRESSEEADDR134RF;
                }
            }
            else
            {
                prtADDRESSEEADDR134RF = ADDRESSEEADDR134RF;
            }
            row["CADD.ADDRESS123RF"] = prtADDRESSEEADDR134RF;

            // 得意先１＋２大文字用中文字用対応
            // 大文字用・中文字用両方張られている時だけ処理
            if (ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12LRF") && ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12BRF"))
            {
                sjisEnc = Encoding.GetEncoding("Shift_JIS");
                string custName = row["HADD.PrintCustomerNameJoin12RF"].ToString();
                int custNameCnt = sjisEnc.GetByteCount(custName);
                string postNo = row["CADD.POSTNORF"].ToString();
                string address1 = row["CADD.ADDRESS1RF"].ToString();
                string address3 = row["CADD.ADDRESS3RF"].ToString();
                string address4 = row["CADD.ADDRESS4RF"].ToString();
                if (custNameCnt <= 20)
                {
                    // 10文字以下なら大文字用で印字
                    row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = DBNull.Value;   // 得意先名１＋得意先名２
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LRF"] = DBNull.Value;  // 得意先名１＋得意先名２（中文字用）
                    row["HADD.PRINTCUSTOMERNAMEJOIN12BRF"] = custName;      // 得意先名１＋得意先名２（大文字用）
                    if (ReportItemDic.ContainsKey("CADD.POSTNOLRF") && ReportItemDic.ContainsKey("CADD.POSTNOBRF"))
                    {
                        // 郵便番号大文字用・中文字用が張られているなら、名称に合わせて郵便番号を大文字用で印字
                        row["CADD.POSTNORF"] = DBNull.Value;   // 印刷得意先郵便番号
                        row["CADD.POSTNOLRF"] = DBNull.Value;  // 印刷得意先郵便番号（中文字用）
                        row["CADD.POSTNOBRF"] = postNo;        // 印刷得意先郵便番号（大文字用）
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS1LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS1BRF"))
                    {
                        // 得意先住所１大文字用・中文字用が張られているなら、名称に合わせて得意先住所１を大文字用で印字
                        row["CADD.ADDRESS1RF"] = DBNull.Value;   // 印刷得意先住所1（都道府県市区郡・町村・字）
                        row["CADD.ADDRESS1LRF"] = DBNull.Value;  // 印刷得意先住所1（中文字用）
                        row["CADD.ADDRESS1BRF"] = address1;      // 印刷得意先住所1（大文字用）
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS3LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS3BRF"))
                    {
                        // 得意先住所３大文字用・中文字用が張られているなら、名称に合わせて得意先住所３を大文字用で印字
                        row["CADD.ADDRESS3RF"] = DBNull.Value;   // 印刷得意先住所3（番地）
                        row["CADD.ADDRESS3LRF"] = DBNull.Value;  // 印刷得意先住所3（中文字用）
                        row["CADD.ADDRESS3BRF"] = address3;      // 印刷得意先住所3（大文字用）
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS4LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS4BRF"))
                    {
                        // 得意先住所４大文字用・中文字用が張られているなら、名称に合わせて得意先住所４を大文字用で印字
                        row["CADD.ADDRESS4RF"] = DBNull.Value;   // 印刷得意先住所4（アパート名称）
                        row["CADD.ADDRESS4LRF"] = DBNull.Value;  // 印刷得意先住所4（中文字用）
                        row["CADD.ADDRESS4BRF"] = address4;      // 印刷得意先住所4（大文字用）
                    }
                }
                else if (custNameCnt <= 30)
                {
                    // 15文字以下なら中文字用で印字
                    row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = DBNull.Value;   // 得意先名１＋得意先名２
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LRF"] = custName;      // 得意先名１＋得意先名２（中文字用）
                    row["HADD.PRINTCUSTOMERNAMEJOIN12BRF"] = DBNull.Value;  // 得意先名１＋得意先名２（大文字用）
                    if (ReportItemDic.ContainsKey("CADD.POSTNOLRF") && ReportItemDic.ContainsKey("CADD.POSTNOBRF"))
                    {
                        // 郵便番号大文字用・中文字用が張られているなら、名称に合わせて郵便番号を中文字用で印字
                        row["CADD.POSTNORF"] = DBNull.Value;  // 印刷得意先郵便番号
                        row["CADD.POSTNOLRF"] = postNo;       // 印刷得意先郵便番号（中文字用）
                        row["CADD.POSTNOBRF"] = DBNull.Value; // 印刷得意先郵便番号（大文字用）
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS1LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS1BRF"))
                    {
                        // 得意先住所１大文字用・中文字用が張られているなら、名称に合わせて得意先住所１を中文字用で印字
                        row["CADD.ADDRESS1RF"] = DBNull.Value;   // 印刷得意先住所1（都道府県市区郡・町村・字）
                        row["CADD.ADDRESS1LRF"] = address1;      // 印刷得意先住所1（中文字用）
                        row["CADD.ADDRESS1BRF"] = DBNull.Value;  // 印刷得意先住所1（大文字用）
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS3LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS3BRF"))
                    {
                        // 得意先住所３大文字用・中文字用が張られているなら、名称に合わせて得意先住所１を中文字用で印字
                        row["CADD.ADDRESS3RF"] = DBNull.Value;  // 印刷得意先住所3（番地）
                        row["CADD.ADDRESS3LRF"] = address3;     // 印刷得意先住所3（中文字用）
                        row["CADD.ADDRESS3BRF"] = DBNull.Value; // 印刷得意先住所3（大文字用）
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS4LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS4BRF"))
                    {
                        // 得意先住所４大文字用・中文字用が張られているなら、名称に合わせて得意先住所４を中文字用で印字
                        row["CADD.ADDRESS4RF"] = DBNull.Value;  // 印刷得意先住所4（アパート名称）
                        row["CADD.ADDRESS4LRF"] = address4;     // 印刷得意先住所4（中文字用）
                        row["CADD.ADDRESS4BRF"] = DBNull.Value; // 印刷得意先住所4（大文字用）
                    }
                }
                else
                {
                    // 16文字以上なら通常サイズで印字
                    row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = custName;       // 得意先名１＋得意先名２
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LRF"] = DBNull.Value;  // 得意先名１＋得意先名２（中文字用）
                    row["HADD.PRINTCUSTOMERNAMEJOIN12BRF"] = DBNull.Value;  // 得意先名１＋得意先名２（大文字用）
                    if (ReportItemDic.ContainsKey("CADD.POSTNOLRF") && ReportItemDic.ContainsKey("CADD.POSTNOBRF"))
                    {
                        // 郵便番号大文字用・中文字用が張られているなら、名称に合わせて郵便番号を通常サイズで印字
                        row["CADD.POSTNORF"] = postNo;         // 印刷得意先郵便番号
                        row["CADD.POSTNOLRF"] = DBNull.Value;  // 印刷得意先郵便番号（中文字用）
                        row["CADD.POSTNOBRF"] = DBNull.Value;  // 印刷得意先郵便番号（大文字用）
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS1LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS1BRF"))
                    {
                        // 得意先住所１大文字用・中文字用が張られているなら、名称に合わせて得意先住所１を通常サイズで印字
                        row["CADD.ADDRESS1RF"] = address1;      // 印刷得意先住所1（都道府県市区郡・町村・字）
                        row["CADD.ADDRESS1LRF"] = DBNull.Value; // 印刷得意先住所1（中文字用）
                        row["CADD.ADDRESS1BRF"] = DBNull.Value; // 印刷得意先住所1（大文字用）
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS3LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS3BRF"))
                    {
                        // 得意先住所３大文字用・中文字用が張られているなら、名称に合わせて得意先住所１を通常サイズで印字
                        row["CADD.ADDRESS3RF"] = address3;      // 印刷得意先住所3（番地）
                        row["CADD.ADDRESS3LRF"] = DBNull.Value; // 印刷得意先住所3（中文字用）
                        row["CADD.ADDRESS3BRF"] = DBNull.Value; // 印刷得意先住所3（大文字用）
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS4LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS4BRF"))
                    {
                        // 得意先住所４大文字用・中文字用が張られているなら、名称に合わせて得意先住所４を通常サイズで印字
                        row["CADD.ADDRESS4RF"] = address4;      // 印刷得意先住所4（アパート名称）
                        row["CADD.ADDRESS4LRF"] = DBNull.Value; // 印刷得意先住所4（中文字用）
                        row["CADD.ADDRESS4BRF"] = DBNull.Value; // 印刷得意先住所4（大文字用）
                    }
                }
            }

            if (ReportItemDic.ContainsKey("HADD.ADDRESS12UPRF") || ReportItemDic.ContainsKey("HADD.ADDRESS12LOWRF"))
            {
                string prtAddress12 = (string)row["CADD.ADDRESS1RF"] + (string)row["CADD.ADDRESS3RF"];
                Encoding encording = Encoding.GetEncoding("Shift_JIS");
                //得意先住所１＋２のバイト数を取得
                int count = encording.GetByteCount(prtAddress12);

                string prtAddressUp = SubStringOfByte(prtAddress12, 30);
                string prtAddressLow = string.Empty;

                if (count >= 31)
                {
                    //得意先名称１＋２に値がある場合
                    if (!string.IsNullOrEmpty(prtAddress12))
                    {
                        prtAddressLow = prtAddress12.Substring(prtAddressUp.Length, prtAddress12.Length - prtAddressUp.Length);
                        prtAddressLow = SubStringOfByte(prtAddressLow, 30);
                    }

                    row["HADD.ADDRESS12UPRF"] = prtAddressUp;
                    row["HADD.ADDRESS12LOWRF"] = prtAddressLow;
                }
                else
                {
                    row["HADD.ADDRESS12UPRF"] = DBNull.Value;
                    row["HADD.ADDRESS12LOWRF"] = prtAddressUp;
                }
            }

            # region [印刷用得意先名称１＋２(上段・下段)]
            //印刷用得意先名称１＋２(上段・下段)
            if ( ReportItemDic.ContainsKey( "CADD.PRINTCUSTOMERNAMEJOIN12UPRF" ) || ReportItemDic.ContainsKey( "CADD.PRINTCUSTOMERNAMEJOIN12LOWRF" ) )
            {
                string printCustomerNameJoin12 = (string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"];
                Encoding encording = Encoding.GetEncoding( "Shift_JIS" );
                //得意先名称１＋２のバイト数を取得
                int count = encording.GetByteCount( printCustomerNameJoin12 );

                //得意先名称１＋２を40バイト分取得
                string printCustomerNameUpper = SubStringOfByte( printCustomerNameJoin12, 40 );
                string printCustomerNameLower = string.Empty;

                if ( count >= 41 )
                {
                    //得意先名称１＋２に値がある場合
                    if ( !string.IsNullOrEmpty( (string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] ) )
                    {
                        printCustomerNameLower = printCustomerNameJoin12.Substring( printCustomerNameUpper.Length, printCustomerNameJoin12.Length - printCustomerNameUpper.Length );
                        printCustomerNameLower = SubStringOfByte( printCustomerNameLower, 20 );
                    }

                    row["CADD.PRINTCUSTOMERNAMEJOIN12UPRF"] = printCustomerNameUpper;
                    row["CADD.PRINTCUSTOMERNAMEJOIN12LOWRF"] = printCustomerNameLower;
                }
                else
                {
                    row["CADD.PRINTCUSTOMERNAMEJOIN12UPRF"] = DBNull.Value;
                    row["CADD.PRINTCUSTOMERNAMEJOIN12LOWRF"] = printCustomerNameUpper;
                }
            }
            // 得意先名１＋２が15文字以下なら１行で印字
            // 15文字を越えるなら上下10文字ずつ印字
            if (ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12UP2RF") || ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12LOW2RF"))
            {
                string printCustomerNameJoin12 = (string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"];
                Encoding encording = Encoding.GetEncoding("Shift_JIS");
                //得意先名称１＋２のバイト数を取得
                int count = encording.GetByteCount(printCustomerNameJoin12);
                string printCustomerNameUpper = string.Empty;
                string printCustomerNameLower = string.Empty;

                if (count >= 31)
                {
                    //得意先名称１＋２に値がある場合
                    if (!string.IsNullOrEmpty((string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"]))
                    {
                        printCustomerNameUpper = SubStringOfByte(printCustomerNameJoin12, 20);
                        printCustomerNameLower = printCustomerNameJoin12.Substring(printCustomerNameUpper.Length, printCustomerNameJoin12.Length - printCustomerNameUpper.Length);
                        printCustomerNameLower = SubStringOfByte(printCustomerNameLower, 20);
                    }

                    row["HADD.PRINTCUSTOMERNAMEJOIN12UP2RF"] = printCustomerNameUpper;
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LOW2RF"] = printCustomerNameLower;
                }
                else
                {
                    printCustomerNameUpper = SubStringOfByte(printCustomerNameJoin12, 30);
                    row["HADD.PRINTCUSTOMERNAMEJOIN12UP2RF"] = DBNull.Value;
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LOW2RF"] = printCustomerNameUpper;
                }
            }

            // 得意先名１＋２が15文字以下なら１行で印字
            // 15文字を越えるなら上下15文字ずつ印字
            if (ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12UP3RF") || ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12LOW3RF"))
            {
                string printCustomerNameJoin12 = (string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"];
                Encoding encording = Encoding.GetEncoding("Shift_JIS");
                //得意先名称１＋２のバイト数を取得
                int count = encording.GetByteCount(printCustomerNameJoin12);

                //得意先名称１＋２を30バイト分取得
                string printCustomerNameUpper = SubStringOfByte(printCustomerNameJoin12, 30);
                string printCustomerNameLower = string.Empty;

                if (count >= 31)
                {
                    //得意先名称１＋２に値がある場合
                    if (!string.IsNullOrEmpty((string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"]))
                    {
                        printCustomerNameLower = printCustomerNameJoin12.Substring(printCustomerNameUpper.Length, printCustomerNameJoin12.Length - printCustomerNameUpper.Length);
                        printCustomerNameLower = SubStringOfByte(printCustomerNameLower, 30);
                    }

                    row["HADD.PRINTCUSTOMERNAMEJOIN12UP3RF"] = printCustomerNameUpper;
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LOW3RF"] = printCustomerNameLower;
                }
                else
                {
                    row["HADD.PRINTCUSTOMERNAMEJOIN12UP3RF"] = DBNull.Value;
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LOW3RF"] = printCustomerNameUpper;
                }
            }

            // 得意先名１＋２が20文字以下なら１行で印字
            // 20文字を越えるなら上下20文字ずつ印字
            if (ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12UP4RF") || ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12LOW4RF"))
            {
                string printCustomerNameJoin12 = (string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"];
                Encoding encording = Encoding.GetEncoding("Shift_JIS");
                //得意先名称１＋２のバイト数を取得
                int count = encording.GetByteCount(printCustomerNameJoin12);

                //得意先名称１＋２を40バイト分取得
                string printCustomerNameUpper = SubStringOfByte(printCustomerNameJoin12, 40);
                string printCustomerNameLower = string.Empty;

                if (count >= 41)
                {
                    //得意先名称１＋２に値がある場合
                    if (!string.IsNullOrEmpty((string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"]))
                    {
                        printCustomerNameLower = printCustomerNameJoin12.Substring(printCustomerNameUpper.Length, printCustomerNameJoin12.Length - printCustomerNameUpper.Length);
                        printCustomerNameLower = SubStringOfByte(printCustomerNameLower, 40);
                    }

                    row["HADD.PRINTCUSTOMERNAMEJOIN12UP4RF"] = printCustomerNameUpper;
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LOW4RF"] = printCustomerNameLower;
                }
                else
                {
                    row["HADD.PRINTCUSTOMERNAMEJOIN12UP4RF"] = DBNull.Value;
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LOW4RF"] = printCustomerNameUpper;
                }
            }
            # endregion
            # endregion

            // 得意先TEL
            # region [得意先TEL]
            // 0:印字しない,1:印字する
            if ( billPrtStWork.CustTelNoPrtDivCd == 0 )
            {
                // 電話番号
                row["CADD.HOMETELNORF"] = DBNull.Value; // 印刷得意先電話番号（自宅）
                row["CADD.OFFICETELNORF"] = DBNull.Value; // 印刷得意先電話番号（勤務先）
                row["CADD.PORTABLETELNORF"] = DBNull.Value; // 印刷得意先電話番号（携帯）
                row["CADD.HOMEFAXNORF"] = DBNull.Value; // 印刷得意先FAX番号（自宅）
                row["CADD.OFFICEFAXNORF"] = DBNull.Value; // 印刷得意先FAX番号（勤務先）
                row["CADD.OTHERSTELNORF"] = DBNull.Value; // 印刷得意先電話番号（その他）
                row["CSTCST.HOMETELNORF"] = DBNull.Value; // 得意先電話番号（自宅）
                row["CSTCST.OFFICETELNORF"] = DBNull.Value; // 得意先電話番号（勤務先）
                row["CSTCST.PORTABLETELNORF"] = DBNull.Value; // 得意先電話番号（携帯）
                row["CSTCST.HOMEFAXNORF"] = DBNull.Value; // 得意先FAX番号（自宅）
                row["CSTCST.OFFICEFAXNORF"] = DBNull.Value; // 得意先FAX番号（勤務先）
                row["CSTCST.OTHERSTELNORF"] = DBNull.Value; // 得意先電話番号（その他）
                row["CSTCLM.HOMETELNORF"] = DBNull.Value; // 請求先電話番号（自宅）
                row["CSTCLM.OFFICETELNORF"] = DBNull.Value; // 請求先電話番号（勤務先）
                row["CSTCLM.PORTABLETELNORF"] = DBNull.Value; // 請求先電話番号（携帯）
                row["CSTCLM.HOMEFAXNORF"] = DBNull.Value; // 請求先FAX番号（自宅）
                row["CSTCLM.OFFICEFAXNORF"] = DBNull.Value; // 請求先FAX番号（勤務先）
                row["CSTCLM.OTHERSTELNORF"] = DBNull.Value; // 請求先電話番号（その他）

                // タイトル
                row["ALITMDSPNMRF.HOMETELNODSPNAMERF"] = DBNull.Value; // 自宅TEL表示名称
                row["ALITMDSPNMRF.OFFICETELNODSPNAMERF"] = DBNull.Value; // 勤務先TEL表示名称
                row["ALITMDSPNMRF.MOBILETELNODSPNAMERF"] = DBNull.Value; // 携帯TEL表示名称
                row["ALITMDSPNMRF.HOMEFAXNODSPNAMERF"] = DBNull.Value; // 自宅FAX表示名称
                row["ALITMDSPNMRF.OFFICEFAXNODSPNAMERF"] = DBNull.Value; // 勤務先FAX表示名称
                row["ALITMDSPNMRF.OTHERTELNODSPNAMERF"] = DBNull.Value; // その他TEL表示名称
            }
            else
            {
                // タイトル
                if ( IsNullTextCell( row["CADD.HOMETELNORF"] ) ) row["ALITMDSPNMRF.HOMETELNODSPNAMERF"] = DBNull.Value; // 自宅TEL表示名称
                if ( IsNullTextCell( row["CADD.OFFICETELNORF"] ) ) row["ALITMDSPNMRF.OFFICETELNODSPNAMERF"] = DBNull.Value; // 勤務先TEL表示名称
                if ( IsNullTextCell( row["CADD.PORTABLETELNORF"] ) ) row["ALITMDSPNMRF.MOBILETELNODSPNAMERF"] = DBNull.Value; // 携帯TEL表示名称
                if ( IsNullTextCell( row["CADD.HOMEFAXNORF"] ) ) row["ALITMDSPNMRF.HOMEFAXNODSPNAMERF"] = DBNull.Value; // 自宅FAX表示名称
                if ( IsNullTextCell( row["CADD.OFFICEFAXNORF"] ) ) row["ALITMDSPNMRF.OFFICEFAXNODSPNAMERF"] = DBNull.Value; // 勤務先FAX表示名称
                if ( IsNullTextCell( row["CADD.OTHERSTELNORF"] ) ) row["ALITMDSPNMRF.OTHERTELNODSPNAMERF"] = DBNull.Value; // その他TEL表示名称
            }
            # endregion

            // 自社情報(追加分)
            # region [自社情報(追加分)]
            // （使用不可項目の対応）
            row["COMPANYINFRF.COMPANYNAME1RF"] = row["COMPANYNMRF.COMPANYNAME1RF"];
            row["COMPANYINFRF.COMPANYNAME2RF"] = row["COMPANYNMRF.COMPANYNAME2RF"];
            row["COMPANYINFRF.POSTNORF"] = row["COMPANYNMRF.POSTNORF"];
            row["COMPANYINFRF.ADDRESS1RF"] = row["COMPANYNMRF.ADDRESS1RF"];
            row["COMPANYINFRF.ADDRESS3RF"] = row["COMPANYNMRF.ADDRESS3RF"];
            row["COMPANYINFRF.ADDRESS4RF"] = row["COMPANYNMRF.ADDRESS4RF"];
            row["COMPANYINFRF.COMPANYTELNO1RF"] = row["COMPANYNMRF.COMPANYTELNO1RF"];
            row["COMPANYINFRF.COMPANYTELNO2RF"] = row["COMPANYNMRF.COMPANYTELNO2RF"];
            row["COMPANYINFRF.COMPANYTELNO3RF"] = row["COMPANYNMRF.COMPANYTELNO3RF"];
            row["COMPANYINFRF.COMPANYTELTITLE1RF"] = row["COMPANYNMRF.COMPANYTELTITLE1RF"];
            row["COMPANYINFRF.COMPANYTELTITLE2RF"] = row["COMPANYNMRF.COMPANYTELTITLE2RF"];
            row["COMPANYINFRF.COMPANYTELTITLE3RF"] = row["COMPANYNMRF.COMPANYTELTITLE3RF"];

            // 自社名１分割
            if ( !string.IsNullOrEmpty( headWork.COMPANYNMRF_COMPANYNAME1RF ) )
            {
                string firstHalf;
                string lastHalf;
                DivideEnterpriseName( headWork.COMPANYNMRF_COMPANYNAME1RF, out firstHalf, out lastHalf );
                row["HADD.PRINTENTERPRISENAME1FHRF"] = firstHalf;
                row["HADD.PRINTENTERPRISENAME1LHRF"] = lastHalf;
            }
            else
            {
                row["HADD.PRINTENTERPRISENAME1FHRF"] = DBNull.Value;
                row["HADD.PRINTENTERPRISENAME1LHRF"] = DBNull.Value;
            }
            // 自社名２分割
            if ( !string.IsNullOrEmpty( headWork.COMPANYNMRF_COMPANYNAME2RF ) )
            {
                string firstHalf;
                string lastHalf;
                DivideEnterpriseName( headWork.COMPANYNMRF_COMPANYNAME1RF, out firstHalf, out lastHalf );
                row["HADD.PRINTENTERPRISENAME2FHRF"] = firstHalf;
                row["HADD.PRINTENTERPRISENAME2LHRF"] = lastHalf;
            }
            else
            {
                row["HADD.PRINTENTERPRISENAME2FHRF"] = DBNull.Value;
                row["HADD.PRINTENTERPRISENAME2LHRF"] = DBNull.Value;
            }
            // 印刷用自社名（上段/下段）
            if ( !string.IsNullOrEmpty( headWork.COMPANYNMRF_COMPANYNAME2RF ) )
            {
                // 上段：自社名１
                row["HADD.PRINTENTERPRISENAMEEX1RF"] = headWork.COMPANYNMRF_COMPANYNAME1RF; // 印刷用自社名（上段）
                // 下段：自社名２
                row["HADD.PRINTENTERPRISENAMEEX2RF"] = headWork.COMPANYNMRF_COMPANYNAME2RF; // 印刷用自社名（下段）
            }
            else
            {
                // 上段：空白
                row["HADD.PRINTENTERPRISENAMEEX1RF"] = DBNull.Value; // 印刷用自社名（上段）
                // 下段：自社名１
                row["HADD.PRINTENTERPRISENAMEEX2RF"] = headWork.COMPANYNMRF_COMPANYNAME1RF; // 印刷用自社名（下段）
            }

            row["HADD.COMPANYNAMEJOIN12RF"] = headWork.COMPANYNMRF_COMPANYNAME1RF + "　" + headWork.COMPANYNMRF_COMPANYNAME2RF;  // 自社名１＋自社名２
            # endregion

            // 銀行名称
            # region [銀行名称]
            // 0:印字する,1:印字しない
            if ( billPrtStWork.BillBankNmPrintOut != 0 )
            {
                row["COMPANYNMRF.TRANSFERGUIDANCERF"] = DBNull.Value;
                row["COMPANYNMRF.ACCOUNTNOINFO1RF"] = DBNull.Value;
                row["COMPANYNMRF.ACCOUNTNOINFO2RF"] = DBNull.Value;
                row["COMPANYNMRF.ACCOUNTNOINFO3RF"] = DBNull.Value;
            }
            # endregion

            // 日付展開
            # region [日付関連 展開処理]
            // 通常
            ExtractDate( ref row, allDefSet.EraNameDispCd2, headWork.CUSTDMDPRCRF_ADDUPDATERF, "HADD.ADDUPDATE", false ); // yyyymmdd
            ExtractDate( ref row, allDefSet.EraNameDispCd2, headWork.CUSTDMDPRCRF_ADDUPYEARMONTHRF, "HADD.ADDUPYEARMONTH", true ); // yyyymm
            ExtractDate( ref row, allDefSet.EraNameDispCd2, headWork.CUSTDMDPRCRF_STARTCADDUPUPDDATERF, "HADD.STARTCADDUPUPDDATE", false ); // yyyymmdd
            ExtractDate( ref row, allDefSet.EraNameDispCd2, headWork.CUSTDMDPRCRF_BILLPRINTDATERF, "HADD.BILLPRINTDATE", false ); // yyyymmdd
            ExtractDate( ref row, allDefSet.EraNameDispCd2, headWork.CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF, "HADD.EXPECTEDDEPOSITDATE", false ); // yyyymmdd
            ExtractDate( ref row, allDefSet.EraNameDispCd2, headWork.HADD_ISSUEDAYRF, "HADD.ISSUEDAY", false ); // yyyymmdd
            # endregion

            // 末日制御
            # region [末日制御]
            // (0:数値印字,1:28～31日は末日と印字)
            if ( billPrtStWork.BillLastDayPrtDiv == 1 )
            {
                // 計上年月日
                if ( IsLast( row, "HADD.ADDUPDATEFDRF" ) ) 
                {
                    row["HADD.ADDUPDATEFDRF"] = DBNull.Value;
                    row[ct_col_Last_AddUpDate] = ct_LastDayString; // 末
                }
                // 締次更新開始年月日
                if ( IsLast( row, "HADD.STARTCADDUPUPDDATEFDRF" ) )
                {
                    row["HADD.STARTCADDUPUPDDATEFDRF"] = DBNull.Value;
                    row[ct_col_Last_StartCAddUpUpdDate] = ct_LastDayString; // 末
                }
                // 請求書発行日
                if ( IsLast( row, "HADD.BILLPRINTDATEFDRF" ) )
                {
                    row["HADD.BILLPRINTDATEFDRF"] = DBNull.Value;
                    row[ct_col_Last_BillPrintDate] = ct_LastDayString; // 末
                }
                // 入金予定日
                if ( IsLast( row, "HADD.EXPECTEDDEPOSITDATEFDRF" ) )
                {
                    row["HADD.EXPECTEDDEPOSITDATEFDRF"] = DBNull.Value;
                    row[ct_col_Last_ExpectedDepositDate] = ct_LastDayString; // 末
                }
                // 入力発行日付
                if ( IsLast( row, "HADD.ISSUEDAYFDRF" ) )
                {
                    row["HADD.ISSUEDAYFDRF"] = DBNull.Value;
                    row[ct_col_Last_IssueDay] = ct_LastDayString; // 末
                }
                // 集金日
                if ( IsLast( row, "CSTCST.COLLECTMONEYDAYRF" ) )
                {
                    row["CSTCST.COLLECTMONEYDAYRF"] = DBNull.Value;
                    row[ct_col_Last_CollectMoneyDay] = ct_LastDayString; // 末
                }
                // 計算入金予定日
                if (IsLast(row, "HADD.CALCEXPECTEDDEPOSITDATEFDRF"))
                {
                    row["HADD.CALCEXPECTEDDEPOSITDATEFDRF"] = DBNull.Value;
                    row["LAST.CALCEXPECTEDDEPOSITDATERF"] = ct_LastDayString; // 末
                }
            }
            # endregion

            # region [日付関連 展開処理(パターン追加)]
            // 通常(日付Extraパターン)
            ExtractDateOfExtraFormat( ref row, allDefSet.EraNameDispCd2, "HADD.EXPECTEDDEPOSITDATE", false ); // yyyymmdd
            ExtractDateOfExtraFormat( ref row, allDefSet.EraNameDispCd2, "HADD.ADDUPDATE", false ); // yyyymmdd
            ExtractDateOfExtraFormat( ref row, allDefSet.EraNameDispCd2, "HADD.STARTCADDUPUPDDATE", false ); // yyyymmdd
            ExtractDateOfExtraFormat( ref row, allDefSet.EraNameDispCd2, "HADD.BILLPRINTDATE", false ); // yyyymmdd
            ExtractDateOfExtraFormat( ref row, allDefSet.EraNameDispCd2, "HADD.ISSUEDAY", false ); // yyyymmdd
            # endregion
            // 請求書番号
            # region [請求書番号]
            if ( headWork.CUSTDMDPRCRF_BILLNORF != 0 )
            {
                row["CUSTDMDPRCRF.BILLNORF"] = headWork.CUSTDMDPRCRF_BILLNORF; // 請求書番号
            }
            else
            {
                row["CUSTDMDPRCRF.BILLNORF"] = DBNull.Value;
            }
            # endregion

            // 鑑金額を印字しない場合の制御
            # region [鑑金額を印字しない場合の制御]
            if ( !printPrice )
            {
                row["CUSTDMDPRCRF.THISTIMEFEEDMDNRMLRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISTIMEDISDMDNRMLRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISTIMEDMDNRMLRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISTIMETTLBLCDMDRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.OFSTHISTIMESALESRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.OFSTHISSALESTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ITDEDOFFSETOUTTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ITDEDOFFSETINTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ITDEDOFFSETTAXFREERF"] = DBNull.Value;
                row["CUSTDMDPRCRF.OFFSETOUTTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.OFFSETINTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISTIMESALESRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISSALESTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ITDEDSALESOUTTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ITDEDSALESINTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ITDEDSALESTAXFREERF"] = DBNull.Value;
                row["CUSTDMDPRCRF.SALESOUTTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.SALESINTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISSALESPRICRGDSRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISSALESPRCTAXRGDSRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLITDEDRETOUTTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLITDEDRETINTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLITDEDRETTAXFREERF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLRETOUTERTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLRETINNERTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISSALESPRICDISRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISSALESPRCTAXDISRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLITDEDDISOUTTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLITDEDDISINTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLITDEDDISTAXFREERF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLDISOUTERTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLDISINNERTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TAXADJUSTRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.BALANCEADJUSTRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.AFCALDEMANDPRICERF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ACPODRTTL2TMBFBLDMDRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ACPODRTTL3TMBFBLDMDRF"] = DBNull.Value;

                row["CUSTDMDPRCRF.LASTTIMEDEMANDRF"] = DBNull.Value;// 前回請求金額（通常）←前回＋２回前＋３回前
                row[ct_col_HDmd_LastTimeDemandOrg] = DBNull.Value;// 前回請求金額（前回のみ）←前回のみ
                row["HADD.THISSALESANDADJUSTTAXINCRF"] = DBNull.Value;// 今回売上額(税込)
                row["CUSTDMDPRCRF.OFSTHISSALESTAXRF"] = DBNull.Value; // 相殺後今回売上消費税
                row["CUSTDMDPRCRF.THISSALESTAXRF"] = DBNull.Value; // 今回売上消費税
                row["CUSTDMDPRCRF.THISSALESPRCTAXRGDSRF"] = DBNull.Value; // 今回売上返品消費税
                row["CUSTDMDPRCRF.THISSALESPRCTAXDISRF"] = DBNull.Value; // 今回売上値引消費税
                row["HADD.THISTAXANDADJUSTRF"] = DBNull.Value; // 今回売上調整消費税 
                row["HADD.THISSALESANDADJUSTTAXINCRF"] = DBNull.Value; // 今回売上額(税込)

                row[ct_col_TaxTitle] = DBNull.Value; // 消費税タイトル
                row[ct_col_OfsThisSalesTaxIncTtl] = DBNull.Value; //相殺後売上合計金額(税込)タイトル
                row[ct_col_ThisTimeRetDis] = DBNull.Value; // 今回返品値引額（売上返品＋売上値引）
                row["HADD.SALESANDRGDSRF"] = DBNull.Value; // 売上－返品
                row["HADD.SALESANDDISRF"] = DBNull.Value; // 売上－値引
                row["HADD.DEPTTOTALCASHRF"] = DBNull.Value; // 入金合計（現金）
                row["HADD.DEPTTOTALTRANSFERRF"] = DBNull.Value; // 入金合計（振込）
                row["HADD.DEPTTOTALCHECKRF"] = DBNull.Value; // 入金合計（小切手）
                row["HADD.DEPTTOTALDRAFTRF"] = DBNull.Value; // 入金合計（手形）
                row["HADD.DEPTTOTALOFFSETRF"] = DBNull.Value; // 入金合計（相殺）
                row["HADD.DEPTTOTALOTHERSRF"] = DBNull.Value; // 入金合計（その他）
                row["HADD.DEPTTOTALACCOUNTRF"] = DBNull.Value; // 入金合計（口座振込）
                row["HADD.DEPTTOTALFACTORINGRF"] = DBNull.Value; // 入金合計（ファクタリング）
                row["HADD.DEPTTOTALSUM1RF"] = DBNull.Value; // 入金合計（手数料＋その他）
                row["HADD.DEPTTOTALSUM2RF"] = DBNull.Value; // 入金合計（値引＋その他）
                row["HADD.DEPTTOTALSUM3RF"] = DBNull.Value; // 入金合計（相殺＋その他）
                row["HADD.DEPTTOTALSUM4RF"] = DBNull.Value; // 入金合計（手数料＋相殺＋その他）
                row["HADD.DEPTTOTALSUM5RF"] = DBNull.Value; // 入金合計（値引＋手数料＋その他）
                row["HADD.DEPTTOTALSUM6RF"] = DBNull.Value; // 入金合計（値引＋相殺＋その他）
                row["HADD.DEPTTOTALSUM7RF"] = DBNull.Value; // 入金合計（手数料＋相殺＋値引＋その他）
                row["HADD.DEPTTOTALSUM8RF"] = DBNull.Value; // 入金合計（現金＋振込＋小切手＋手形）
                row["HADD.DEPTTOTALEXC1RF"] = DBNull.Value; // 入金合計（手数料・その他除く）
                row["HADD.DEPTTOTALEXC2RF"] = DBNull.Value; // 入金合計（値引・その他除く）
                row["HADD.DEPTTOTALEXC3RF"] = DBNull.Value; // 入金合計（相殺・その他除く）
                row["HADD.DEPTTOTALEXC4RF"] = DBNull.Value; // 入金合計（手数料・相殺・その他除く）
                row["HADD.DEPTTOTALEXC5RF"] = DBNull.Value; // 入金合計（値引・手数料・その他除く）
                row["HADD.DEPTTOTALEXC6RF"] = DBNull.Value; // 入金合計（値引・相殺・その他除く）
                row["HADD.DEPTTOTALEXC7RF"] = DBNull.Value; // 入金合計（手数料・相殺・値引・その他除く）
                row["HADD.DEPTTOTALEXC8RF"] = DBNull.Value; // 入金合計（現金・振込・小切手・手形除く）
                row["DEPT01.DEPOSITRF"] = DBNull.Value; // 入金金種名称1
                row["DEPT01.MONEYKINDNAMERF"] = DBNull.Value; // 入金金額1
                row["DEPT02.DEPOSITRF"] = DBNull.Value; // 入金金種名称2
                row["DEPT02.MONEYKINDNAMERF"] = DBNull.Value; // 入金金額2
                row["DEPT03.DEPOSITRF"] = DBNull.Value; // 入金金種名称3
                row["DEPT03.MONEYKINDNAMERF"] = DBNull.Value; // 入金金額3
                row["DEPT04.DEPOSITRF"] = DBNull.Value; // 入金金種名称4
                row["DEPT04.MONEYKINDNAMERF"] = DBNull.Value; // 入金金額4
                row["DEPT05.DEPOSITRF"] = DBNull.Value; // 入金金種名称5
                row["DEPT05.MONEYKINDNAMERF"] = DBNull.Value; // 入金金額5
                row["DEPT06.DEPOSITRF"] = DBNull.Value; // 入金金種名称6
                row["DEPT06.MONEYKINDNAMERF"] = DBNull.Value; // 入金金額6
                row["DEPT07.DEPOSITRF"] = DBNull.Value; // 入金金種名称7
                row["DEPT07.MONEYKINDNAMERF"] = DBNull.Value; // 入金金額7
                row["DEPT08.DEPOSITRF"] = DBNull.Value; // 入金金種名称8
                row["DEPT08.MONEYKINDNAMERF"] = DBNull.Value; // 入金金額8
                row["DEPT09.DEPOSITRF"] = DBNull.Value; // 入金金種名称9
                row["DEPT09.MONEYKINDNAMERF"] = DBNull.Value; // 入金金額9
                row["DEPT10.DEPOSITRF"] = DBNull.Value; // 入金金種名称10
                row["DEPT10.MONEYKINDNAMERF"] = DBNull.Value; // 入金金額10
                row["HADD.DMDNRMLEXDISFEERF"] = DBNull.Value; // 入金金額(値引・手数料除く)
                row["HADD.DMDNRMLEXDISRF"] = DBNull.Value; // 入金金額(値引除く)
                row["HADD.DMDNRMLEXFEERF"] = DBNull.Value; // 入金金額(手数料除く)
                row["HADD.DMDNRMLSAMDISFEERF"] = DBNull.Value; // 入金金額(値引＋手数料)
                row["HADD.OFSTHISSALESTAXINCRF"] = DBNull.Value; // 相殺後売上金額(税込)
                row["HADD.OFSTHISSALESTAXINC2RF"] = DBNull.Value; // 相殺後売上合計金額(税込)(非課税・子も印字）
            }
            else
            {
                row[ct_col_TaxTitle] = taxTitle; // 消費税タイトル
                row[ct_col_OfsThisSalesTaxIncTtl] = ofsThisSalesTaxIncTtl; //売上合計金額(税込)タイトル
            }
            # endregion

            // 売上頁計
            // 頁計が貼られている時だけ処理を行う
            if (ReportItemDic.ContainsKey("HADD.SALESMONEYPAGETTLRF"))
            {
                // 頁計リストがNULLではない
                if (pageTtlList != null)
                {
                    // 頁数がNULLではない
                    if (row[ct_col_PageCount] != DBNull.Value)
                    {
                        row["HADD.SALESMONEYPAGETTLRF"] = pageTtlList[(int)row[ct_col_PageCount]];
                    }
                }
            }

            // 最終ページのみ印刷項目
            if (row[ct_col_PageCount] != DBNull.Value)
            {
                if ((int)row[ct_col_PageCount] != _pageCount)
                {
                    row["HADD.LASTPAGECOMMENTRF"] = DBNull.Value;
                    row["HADD.OFSTHISTIMESALESLASTPAGERF"] = DBNull.Value;
                }
            }
        }

        /// <summary>
        /// 入金合計ディクショナリ追加処理
        /// </summary>
        /// <param name="deptTotalDic">対象のディクショナリ</param>
        /// <param name="kindCd">金種コード(key)</param>
        /// <param name="deptTotal">金額(value)</param>
        /// <remarks>
        /// <br>Note        : 入金合計ディクショナリ追加処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void AddToDeptTotalDic( ref Dictionary<int, long> deptTotalDic, int kindCd, long deptTotal )
        {
            if ( kindCd != 0 && deptTotalDic.ContainsKey( kindCd ) == false )
            {
                deptTotalDic.Add( kindCd, deptTotal );
            }
        }
        /// <summary>
        /// 入金合計ディクショナリからの取得
        /// </summary>
        /// <param name="deptTotalDic">入金合計ディクショナリ</param>
        /// <param name="kindCd">金種コード</param>
        /// <returns>当金種金額</returns>
        /// <remarks>
        /// <br>Note        : 入金合計ディクショナリからの取得</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static Int64 GetFromDeptTotalDic( Dictionary<int, long> deptTotalDic, int kindCd )
        {
            if ( deptTotalDic.ContainsKey( kindCd ) )
            {
                return deptTotalDic[kindCd];
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 文字列ＮＵＬＬ判定（DataRowセル用）
        /// </summary>
        /// <param name="textObject">判定対象</param>
        /// <returns>文字列ＮＵＬＬ判定結果</returns>
        /// <remarks>
        /// <br>Note        : 文字列ＮＵＬＬ判定（DataRowセル用）</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static bool IsNullTextCell( object textObject )
        {
            return (textObject == DBNull.Value || string.IsNullOrEmpty( (string)textObject ));
        }

        /// <summary>
        /// 全角⇒半角変換
        /// </summary>
        /// <param name="orgString">対象</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note        : 全角⇒半角変換</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetKanaString(string orgString)
        {
            // 全角⇒半角変換（途中に含まれる変換できない文字はそのまま）
            return Microsoft.VisualBasic.Strings.StrConv(orgString, Microsoft.VisualBasic.VbStrConv.Narrow, 0);
        }

        /// <summary>
        /// 回収予定額（回収予定表の対象額）を計算します
        /// </summary>
        /// <param name="headWork">ヘッダー情報</param>
        /// <param name="billAllStWork">請求書全体設定</param>
        /// <returns>回収予定額</returns>
        /// <remarks>
        /// <br>Note        : 回収予定額（回収予定表の対象額）を計算します</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static Int64 GetExpectedDepositMoney(EBooksFrePBillHeadWork headWork, BillAllStWork billAllStWork)
        {
            Int64 expectedDepositMoney = 0;

            if (billAllStWork.CollectPlnDiv == 0)
            {
                // 回収予定区分が区分
                // 補正後集金月の取得
                int correctCollectMoneyCode = CorrectCollectMoneyCode(headWork);

                if (correctCollectMoneyCode == 0)
                {
                    // 当月(受注3回前残高+受注2回前残高+前回請求残高+相殺後今回売上額+相殺後今回売上消費税-今回入金額)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF + headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF +
                                  headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF + headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF - headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
                else if (correctCollectMoneyCode == 1)
                {
                    // 翌月(受注3回前残高+受注2回前残高+前回請求残高-今回入金額)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF + headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF -
                                  headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
                else if (correctCollectMoneyCode == 2)
                {
                    // 翌々月(受注3回前残高+受注2回前残高-今回入金額)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF - headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
                else if (correctCollectMoneyCode == 3)
                {
                    // 翌々々月(受注3回前残高-今回入金額)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF - headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
            }
            else
            {
                // 回収予定区分が日付
                // 締後回収日の算定
                DateTime calcDate = CalcDate(headWork);
                // 経過期間の算出
                int yyyy, mm, dd;
                yyyy = headWork.CUSTDMDPRCRF_ADDUPDATERF / 10000;
                mm = headWork.CUSTDMDPRCRF_ADDUPDATERF % 10000 / 100;
                dd = headWork.CUSTDMDPRCRF_ADDUPDATERF % 100;
                DateTime progreTerm = new DateTime(yyyy, mm, dd);  // 締日

                // 集金月の判定
                if (calcDate < progreTerm)
                {
                    // 当月(受注3回前残高+受注2回前残高+前回請求残高+相殺後今回売上額+相殺後今回売上消費税-今回入金額)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF + headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF +
                                  headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF + headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF - headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
                else if (calcDate < progreTerm.AddMonths(1))
                {
                    // 当月(受注3回前残高+受注2回前残高+前回請求残高+相殺後今回売上額+相殺後今回売上消費税-今回入金額)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF + headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF +
                                  headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF + headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF - headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
                else if (calcDate < progreTerm.AddMonths(2))
                {
                    // 翌月(受注3回前残高+受注2回前残高+前回請求残高-今回入金額)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF + headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF -
                                  headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
                else if (calcDate < progreTerm.AddMonths(3))
                {
                    // 翌々月(受注3回前残高+受注2回前残高-今回入金額)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF - headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
                else
                {
                    // 翌々々月(受注3回前残高-今回入金額)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF - headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
            }
            return expectedDepositMoney;
        }

        /// <summary>
        /// 締後回収日の算定
        /// </summary>
        /// <returns>締後回収日</returns>
        /// <remarks>
        /// <br>Note        : 締後回収日の算定</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static DateTime CalcDate(EBooksFrePBillHeadWork headWork)
        {
            int yyyy, mm, dd;
            yyyy = headWork.CUSTDMDPRCRF_ADDUPDATERF / 10000;
            mm = headWork.CUSTDMDPRCRF_ADDUPDATERF % 10000 / 100;
            dd = headWork.CUSTDMDPRCRF_ADDUPDATERF % 100;
            DateTime custDmdPrcRF_AddUpDateRF = new DateTime(yyyy, mm, dd);
            DateTime calcDate = custDmdPrcRF_AddUpDateRF.AddMonths(headWork.CSTCLM_COLLECTMONEYCODERF);
            double setDays = 0.0;
            int endDays = DateTime.DaysInMonth(calcDate.Year, calcDate.Month);
            if (endDays < headWork.CSTCLM_COLLECTMONEYDAYRF)
            {
                // 集金日が締後回収日の月末を超えている
                setDays = endDays - (double)calcDate.Day;
            }
            else
            {
                // 集金日が締後回収日の月末を超えていない
                setDays = headWork.CSTCLM_COLLECTMONEYDAYRF - (double)calcDate.Day;
            }
            return calcDate.AddDays(setDays);
        }

        /// <summary>
        /// 集金月の補正
        /// </summary>
        /// <returns>補正後集金月</returns>
        /// <remarks>
        /// <br>Note        : 集金月の補正</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int CorrectCollectMoneyCode(EBooksFrePBillHeadWork headWork)
        {
            // 集金月
            int collectMoneyCode = headWork.CSTCLM_COLLECTMONEYCODERF;

            if (collectMoneyCode >= 1)
            {
                // 集金月が翌月以降
                if (headWork.CSTCLM_TOTALDAYRF >= headWork.CSTCLM_COLLECTMONEYDAYRF)
                {
                    // 得意先マスタの締日≧集金日の場合は、集金月を補正
                    collectMoneyCode -= 1;
                }
            }

            return collectMoneyCode;
        }

        /// <summary>
        /// 回収月・回収日の算出
        /// </summary>
        /// <param name="headWork">ヘッダー情報</param>
        /// <returns>回収月・回収日</returns>
        /// <remarks>
        /// <br>Note        : 回収月・回収日の算出</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static DateTime CalcCollectDate(EBooksFrePBillHeadWork headWork)
        {
            // 回収月区分が当月で締日日≧回収日日の場合、回収日を来月とする。
            int yyyy, mm, dd, collectDay, lastDay, bCollectDay;
            bool isLastDay = false;
            yyyy = headWork.CUSTDMDPRCRF_ADDUPDATERF / 10000;
            mm = headWork.CUSTDMDPRCRF_ADDUPDATERF % 10000 / 100;
            dd = headWork.CUSTDMDPRCRF_ADDUPDATERF % 100;
            collectDay = headWork.CSTCLM_COLLECTMONEYDAYRF;
            bCollectDay = collectDay;
            lastDay = DateTime.DaysInMonth(yyyy, mm);
            if (collectDay > lastDay)
            {
                // 回収日が締日の月末より大きかった場合は、締日の月末をセット
                collectDay = lastDay;
                isLastDay = true;
            }
            DateTime collectYYMMDD = new DateTime(yyyy, mm, collectDay);
            collectYYMMDD = collectYYMMDD.AddMonths(headWork.CSTCLM_COLLECTMONEYCODERF);
            if (headWork.CSTCLM_COLLECTMONEYCODERF == 0)
            {
                if (dd >= collectDay)
                {
                    collectYYMMDD = collectYYMMDD.AddMonths(1);
                }
            }
            if (isLastDay)
            {
                // 締日の月末をセットしている場合は元の回収日をセット
                collectDay = bCollectDay;
                lastDay = DateTime.DaysInMonth(collectYYMMDD.Year, collectYYMMDD.Month);
                if (collectDay > lastDay)
                {
                    // 元の回収日が回収日の月末より大きかった場合は、回収日の月末をセット
                    collectDay = lastDay;
                }
                collectYYMMDD = new DateTime(collectYYMMDD.Year, collectYYMMDD.Month, collectDay);
            }
            return collectYYMMDD;
        }

        # region [自社名称分解処理]
        /// <summary>
        /// 自社名称分解処理
        /// </summary>
        /// <param name="originName">元自社名</param>
        /// <param name="firstHalf">自社名前半</param>
        /// <param name="lastHalf">自社名後半</param>
        /// <remarks>
        /// <br>Note        : 自社名称分解処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void DivideEnterpriseName( string originName, out string firstHalf, out string lastHalf )
        {
            // ＮＳはマスタ設定での入力可能桁数が半角・全角区別しない仕様なので
            // バイト数ではなく文字数で分解する。

            const int fullLength = 20;
            const int divideLength = 10;

            // スペースで詰める
            originName = originName.PadRight( fullLength, ' ' );
            // 分解
            firstHalf = originName.Substring( 0, divideLength ).TrimEnd();
            lastHalf = originName.Substring( divideLength, divideLength ).TrimEnd();
        }
        # endregion

        #region[文字列　バイト数指定切り抜き]
        /// <summary>
        /// 文字列　バイト数指定切り抜き
        /// </summary>
        /// <param name="orgString">元の文字列</param>
        /// <param name="byteCount">バイト数</param>
        /// <remarks>
        /// <br>Note        : 指定バイト数で切り抜いた文字列</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        protected static string SubStringOfByte(string orgString, int byteCount)
        {
            if (byteCount <= 0)
            {
                return string.Empty;
            }

            Encoding encoding = Encoding.GetEncoding("Shift_JIS");

            string resultString = string.Empty;

            // あらかじめ「文字数」を指定して切り抜いておく
            // (この段階でbyte数は<文字数>～2*<文字数>の間になる)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // 「文字数」を減らす
                resultString = orgString.Substring(0, i);

                // バイト数を取得して判定
                count = encoding.GetByteCount(resultString);
                if (count <= byteCount) break;
            }

            // 終端の空白は削除
            return resultString;

        }
        #endregion

        # region [末日判定]
        /// <summary>
        /// 末日判定処理
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="columnName">列</param>
        /// <returns>判定結果</returns>
        /// <remarks>
        /// <br>Note        : 末日判定処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static bool IsLast( DataRow row, string columnName )
        {
            if ( row[columnName] == DBNull.Value )
            {
                return false;
            }
            else
            {
                return IsLast( (int)row[columnName] );
            }
        }

        /// <summary>
        /// 末日判定処理（28～31日は末日）
        /// </summary>
        /// <param name="date">日付</param>
        /// <returns>末日判定結果</returns>
        /// <remarks>
        /// <br>Note        : 末日判定処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static bool IsLast( int date )
        {
            return (28 <= date);
        }
        # endregion

        # region [データゼロ判定]
        /// <summary>
        /// 文字列コードのゼロ判定
        /// </summary>
        /// <param name="textValue">判定対象</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note        : 文字列コードのゼロ判定</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static bool IsZero( string textValue )
        {
            if ( textValue == null || textValue.Trim() == string.Empty ) return true;

            try
            {
                return (Int32.Parse( textValue ) == 0);
            }
            catch
            {
                return true;
            }
        }

        /// <summary>
        /// 数値コードのゼロ判定
        /// </summary>
        /// <param name="intValue">判定対象</param>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note        : 数値コードのゼロ判定</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static bool IsZero( int intValue )
        {
            return (intValue == 0);
        }
        # endregion

        // --- ADD START 3H 仰亮亮 2023/04/14 ----------------------------------->>>>>
        #region [①売上伝票計金額(税込み) ②消費税(伝票転嫁)/売上伝票計金額(税込み) 追加対応]
        /// <summary>
        /// フォーマット制御。
        /// </summary>
        /// <param name="number">数値</param>
        /// <param name="iMaxLength">最大印字桁数</param>
        /// <returns>処理結果</returns>
        private static string SetFormat(Int64 number, Int32 iMaxLength)
        {
            string tempSales = number.ToString();

            // フォーマット臨界値を設定
            Int32 iCriticalValue = 10;

            // フォーマット:「####,###,##0」
            // 最大桁数を超えるの場合、「************」を設定
            if (tempSales.Length < iCriticalValue)
            {
                tempSales = number.ToString("###,##0");
            }
            //  フォーマット:「####,###,##0」
            else if (tempSales.Length == iCriticalValue)
            {
                tempSales = number.ToString("#####+###+##0").Replace("+", ",");
            }
            //  フォーマット:「************」
            else if (tempSales.Length > iCriticalValue)
            {
                tempSales = new string('*', iMaxLength);
            }

            return tempSales;
        }
        #endregion
        // --- ADD END 3H 仰亮亮 2023/04/14 -------------------------------------<<<<<

        /// <summary>
        /// 請求書ヘッダ部追加項目適用処理
        /// </summary>
        /// <param name="headWork">ヘッダー情報</param>
        /// <param name="dmdPrtPtnWork">印刷条件</param>
        /// <param name="frePrtPSetWork">レポート情報</param>
        /// <param name="allDefSet">全体初期表示設定</param>
        /// <param name="billAllStWork">請求書全体設定</param>
        /// <param name="billPrtStWork">請求書印刷設定</param>
        /// <remarks>
        /// <br>Note        : 請求書ヘッダ部追加項目適用処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectBillHeaderAddtionSet( ref EBooksFrePBillHeadWork headWork, DmdPrtPtnWork dmdPrtPtnWork, FrePrtPSetWork frePrtPSetWork, BillAllStWork billAllStWork, BillPrtStWork billPrtStWork, AllDefSetWork allDefSet )
        {
            //---------------------------------------------------
            // 請求書パターン設定よりコピー
            //---------------------------------------------------
            headWork.HADD_DMDFORMTITLERF = dmdPrtPtnWork.DmdFormTitle;
            headWork.HADD_DMDFORMTITLE2RF = dmdPrtPtnWork.DmdFormTitle2;
            headWork.HADD_DMDFORMCOMENT1RF = dmdPrtPtnWork.DmdFormComent1;
            headWork.HADD_DMDFORMCOMENT2RF = dmdPrtPtnWork.DmdFormComent2;
            headWork.HADD_DMDFORMCOMENT3RF = dmdPrtPtnWork.DmdFormComent3;

            //---------------------------------------------------
            // 敬称
            //---------------------------------------------------
            // 得意先マスタに敬称が未設定ならば、請求書印刷パターン設定の敬称で書き換える
            if ( string.IsNullOrEmpty( headWork.CSTCLM_HONORIFICTITLERF ) ) headWork.CSTCLM_HONORIFICTITLERF = dmdPrtPtnWork.BillHonorificTtl;
            if ( string.IsNullOrEmpty( headWork.CSTCST_HONORIFICTITLERF ) ) headWork.CSTCST_HONORIFICTITLERF = dmdPrtPtnWork.BillHonorificTtl;

            //---------------------------------------------------
            // 固定名称取得
            //---------------------------------------------------
            headWork.HADD_COLLECTCONDNMRF = GetHADD_COLLECTCONDNM( headWork.CUSTDMDPRCRF_COLLECTCONDRF );

            //---------------------------------------------------
            // 鑑金額算出値
            //---------------------------------------------------
            # region [鑑金額算出値]
            // 入金金額(値引除く)
            headWork.HADD_DMDNRMLEXDISRF = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - headWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF;
            // 入金金額(手数料除く)
            headWork.HADD_DMDNRMLEXFEERF = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - headWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF;
            // 入金金額(値引・手数料除く)
            headWork.HADD_DMDNRMLEXDISFEERF = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - headWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF - headWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF;
            // 入金金額(値引＋手数料)
            headWork.HADD_DMDNRMLSAMDISFEERF = headWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF + headWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF;
            // 今回売上額(税抜)
            headWork.HADD_THISSALESANDADJUSTRF = headWork.CUSTDMDPRCRF_THISTIMESALESRF + headWork.CUSTDMDPRCRF_BALANCEADJUSTRF;
            // 今回売上消費税
            headWork.HADD_THISTAXANDADJUSTRF = headWork.CUSTDMDPRCRF_THISSALESTAXRF + headWork.CUSTDMDPRCRF_TAXADJUSTRF;
            # endregion

            //---------------------------------------------------
            // 自社情報の設定
            //---------------------------------------------------
            # region [自社情報]
            // 0:自社名印字　1:拠点名印字　2:ビットマップを印字　3:印字しない
            switch (dmdPrtPtnWork.CoNmPrintOutCd)
            {
                case 0:
                    {
                        switch (billPrtStWork.BillCoNmPrintOutCd)
                        {
                            // 自社名
                            case 0:
                                {
                                    // 自社情報マスタの内容に差し替える
                                    headWork.COMPANYNMRF_COMPANYNAME1RF = headWork.COMPANYINFRF_COMPANYNAME1RF;// 自社名称1
                                    headWork.COMPANYNMRF_COMPANYNAME2RF = headWork.COMPANYINFRF_COMPANYNAME2RF;// 自社名称2
                                    headWork.COMPANYNMRF_POSTNORF = headWork.COMPANYINFRF_POSTNORF;// 郵便番号
                                    headWork.COMPANYNMRF_ADDRESS1RF = headWork.COMPANYINFRF_ADDRESS1RF;// 住所1（都道府県市区郡・町村・字）
                                    headWork.COMPANYNMRF_ADDRESS3RF = headWork.COMPANYINFRF_ADDRESS3RF;// 住所3（番地）
                                    headWork.COMPANYNMRF_ADDRESS4RF = headWork.COMPANYINFRF_ADDRESS4RF;// 住所4（アパート名称）
                                    headWork.COMPANYNMRF_COMPANYTELNO1RF = headWork.COMPANYINFRF_COMPANYTELNO1RF;// 自社電話番号1
                                    headWork.COMPANYNMRF_COMPANYTELNO2RF = headWork.COMPANYINFRF_COMPANYTELNO2RF;// 自社電話番号2
                                    headWork.COMPANYNMRF_COMPANYTELNO3RF = headWork.COMPANYINFRF_COMPANYTELNO3RF;// 自社電話番号3
                                    headWork.COMPANYNMRF_COMPANYTELTITLE1RF = headWork.COMPANYINFRF_COMPANYTELTITLE1RF;// 自社電話番号タイトル1
                                    headWork.COMPANYNMRF_COMPANYTELTITLE2RF = headWork.COMPANYINFRF_COMPANYTELTITLE2RF;// 自社電話番号タイトル2
                                    headWork.COMPANYNMRF_COMPANYTELTITLE3RF = headWork.COMPANYINFRF_COMPANYTELTITLE3RF;// 自社電話番号タイトル3
                                    // bitmapなし
                                    headWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = string.Empty;// 画像印字用コメント1
                                    headWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = string.Empty;// 画像印字用コメント2
                                    headWork.IMAGEINFORF_IMAGEINFODATARF = null;// 画像情報データ
                                }
                                break;
                            // 拠点名
                            case 1:
                                {
                                    // bitmapなし
                                    headWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = string.Empty;// 画像印字用コメント1
                                    headWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = string.Empty;// 画像印字用コメント2
                                    headWork.IMAGEINFORF_IMAGEINFODATARF = null;// 画像情報データ   
                                }
                                break;
                            case 2:
                                {
                                    // 自社情報文字列を印字しない
                                    headWork.COMPANYNMRF_COMPANYNAME1RF = string.Empty;// 自社名称1
                                    headWork.COMPANYNMRF_COMPANYNAME2RF = string.Empty;// 自社名称2
                                    headWork.COMPANYNMRF_POSTNORF = string.Empty;// 郵便番号
                                    headWork.COMPANYNMRF_ADDRESS1RF = string.Empty;// 住所1（都道府県市区郡・町村・字）
                                    headWork.COMPANYNMRF_ADDRESS3RF = string.Empty;// 住所3（番地）
                                    headWork.COMPANYNMRF_ADDRESS4RF = string.Empty;// 住所4（アパート名称）
                                    headWork.COMPANYNMRF_COMPANYTELNO1RF = string.Empty;// 自社電話番号1
                                    headWork.COMPANYNMRF_COMPANYTELNO2RF = string.Empty;// 自社電話番号2
                                    headWork.COMPANYNMRF_COMPANYTELNO3RF = string.Empty;// 自社電話番号3
                                    headWork.COMPANYNMRF_COMPANYTELTITLE1RF = string.Empty;// 自社電話番号タイトル1
                                    headWork.COMPANYNMRF_COMPANYTELTITLE2RF = string.Empty;// 自社電話番号タイトル2
                                    headWork.COMPANYNMRF_COMPANYTELTITLE3RF = string.Empty;// 自社電話番号タイトル3
                                }
                                break;
                            case 3:
                            default:
                                {
                                    // 自社情報文字列を印字しない
                                    headWork.COMPANYNMRF_COMPANYNAME1RF = string.Empty;// 自社名称1
                                    headWork.COMPANYNMRF_COMPANYNAME2RF = string.Empty;// 自社名称2
                                    headWork.COMPANYNMRF_POSTNORF = string.Empty;// 郵便番号
                                    headWork.COMPANYNMRF_ADDRESS1RF = string.Empty;// 住所1（都道府県市区郡・町村・字）
                                    headWork.COMPANYNMRF_ADDRESS3RF = string.Empty;// 住所3（番地）
                                    headWork.COMPANYNMRF_ADDRESS4RF = string.Empty;// 住所4（アパート名称）
                                    headWork.COMPANYNMRF_COMPANYTELNO1RF = string.Empty;// 自社電話番号1
                                    headWork.COMPANYNMRF_COMPANYTELNO2RF = string.Empty;// 自社電話番号2
                                    headWork.COMPANYNMRF_COMPANYTELNO3RF = string.Empty;// 自社電話番号3
                                    headWork.COMPANYNMRF_COMPANYTELTITLE1RF = string.Empty;// 自社電話番号タイトル1
                                    headWork.COMPANYNMRF_COMPANYTELTITLE2RF = string.Empty;// 自社電話番号タイトル2
                                    headWork.COMPANYNMRF_COMPANYTELTITLE3RF = string.Empty;// 自社電話番号タイトル3
                                    // bitmapなし
                                    headWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = string.Empty;// 画像印字用コメント1
                                    headWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = string.Empty;// 画像印字用コメント2
                                    headWork.IMAGEINFORF_IMAGEINFODATARF = null;// 画像情報データ
                                }
                                break;
                        }
                    }
                    break;
                // 自社名
                case 1:
                    {
                        // 自社情報マスタの内容に差し替える
                        headWork.COMPANYNMRF_COMPANYNAME1RF = headWork.COMPANYINFRF_COMPANYNAME1RF;// 自社名称1
                        headWork.COMPANYNMRF_COMPANYNAME2RF = headWork.COMPANYINFRF_COMPANYNAME2RF;// 自社名称2
                        headWork.COMPANYNMRF_POSTNORF = headWork.COMPANYINFRF_POSTNORF;// 郵便番号
                        headWork.COMPANYNMRF_ADDRESS1RF = headWork.COMPANYINFRF_ADDRESS1RF;// 住所1（都道府県市区郡・町村・字）
                        headWork.COMPANYNMRF_ADDRESS3RF = headWork.COMPANYINFRF_ADDRESS3RF;// 住所3（番地）
                        headWork.COMPANYNMRF_ADDRESS4RF = headWork.COMPANYINFRF_ADDRESS4RF;// 住所4（アパート名称）
                        headWork.COMPANYNMRF_COMPANYTELNO1RF = headWork.COMPANYINFRF_COMPANYTELNO1RF;// 自社電話番号1
                        headWork.COMPANYNMRF_COMPANYTELNO2RF = headWork.COMPANYINFRF_COMPANYTELNO2RF;// 自社電話番号2
                        headWork.COMPANYNMRF_COMPANYTELNO3RF = headWork.COMPANYINFRF_COMPANYTELNO3RF;// 自社電話番号3
                        headWork.COMPANYNMRF_COMPANYTELTITLE1RF = headWork.COMPANYINFRF_COMPANYTELTITLE1RF;// 自社電話番号タイトル1
                        headWork.COMPANYNMRF_COMPANYTELTITLE2RF = headWork.COMPANYINFRF_COMPANYTELTITLE2RF;// 自社電話番号タイトル2
                        headWork.COMPANYNMRF_COMPANYTELTITLE3RF = headWork.COMPANYINFRF_COMPANYTELTITLE3RF;// 自社電話番号タイトル3
                        // bitmapなし
                        headWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = string.Empty;// 画像印字用コメント1
                        headWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = string.Empty;// 画像印字用コメント2
                        headWork.IMAGEINFORF_IMAGEINFODATARF = null;// 画像情報データ
                    }
                    break;
                // 拠点名

                case 2:
                    {
                        // bitmapなし
                        headWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = string.Empty;// 画像印字用コメント1
                        headWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = string.Empty;// 画像印字用コメント2
                        headWork.IMAGEINFORF_IMAGEINFODATARF = null;// 画像情報データ
                    }
                    break;
                // ビットマップ
                case 3:
                    {
                        // 自社情報文字列を印字しない
                        headWork.COMPANYNMRF_COMPANYNAME1RF = string.Empty;// 自社名称1
                        headWork.COMPANYNMRF_COMPANYNAME2RF = string.Empty;// 自社名称2
                        headWork.COMPANYNMRF_POSTNORF = string.Empty;// 郵便番号
                        headWork.COMPANYNMRF_ADDRESS1RF = string.Empty;// 住所1（都道府県市区郡・町村・字）
                        headWork.COMPANYNMRF_ADDRESS3RF = string.Empty;// 住所3（番地）
                        headWork.COMPANYNMRF_ADDRESS4RF = string.Empty;// 住所4（アパート名称）
                        headWork.COMPANYNMRF_COMPANYTELNO1RF = string.Empty;// 自社電話番号1
                        headWork.COMPANYNMRF_COMPANYTELNO2RF = string.Empty;// 自社電話番号2
                        headWork.COMPANYNMRF_COMPANYTELNO3RF = string.Empty;// 自社電話番号3
                        headWork.COMPANYNMRF_COMPANYTELTITLE1RF = string.Empty;// 自社電話番号タイトル1
                        headWork.COMPANYNMRF_COMPANYTELTITLE2RF = string.Empty;// 自社電話番号タイトル2
                        headWork.COMPANYNMRF_COMPANYTELTITLE3RF = string.Empty;// 自社電話番号タイトル3
                    }
                    break;
                // 印字しない
                case 4:
                default:
                    {
                        // 自社情報文字列を印字しない
                        headWork.COMPANYNMRF_COMPANYNAME1RF = string.Empty;// 自社名称1
                        headWork.COMPANYNMRF_COMPANYNAME2RF = string.Empty;// 自社名称2
                        headWork.COMPANYNMRF_POSTNORF = string.Empty;// 郵便番号
                        headWork.COMPANYNMRF_ADDRESS1RF = string.Empty;// 住所1（都道府県市区郡・町村・字）
                        headWork.COMPANYNMRF_ADDRESS3RF = string.Empty;// 住所3（番地）
                        headWork.COMPANYNMRF_ADDRESS4RF = string.Empty;// 住所4（アパート名称）
                        headWork.COMPANYNMRF_COMPANYTELNO1RF = string.Empty;// 自社電話番号1
                        headWork.COMPANYNMRF_COMPANYTELNO2RF = string.Empty;// 自社電話番号2
                        headWork.COMPANYNMRF_COMPANYTELNO3RF = string.Empty;// 自社電話番号3
                        headWork.COMPANYNMRF_COMPANYTELTITLE1RF = string.Empty;// 自社電話番号タイトル1
                        headWork.COMPANYNMRF_COMPANYTELTITLE2RF = string.Empty;// 自社電話番号タイトル2
                        headWork.COMPANYNMRF_COMPANYTELTITLE3RF = string.Empty;// 自社電話番号タイトル3
                        // bitmapなし
                        headWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = string.Empty;// 画像印字用コメント1
                        headWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = string.Empty;// 画像印字用コメント2
                        headWork.IMAGEINFORF_IMAGEINFODATARF = null;// 画像情報データ
                    }
                    break;
            }
            # endregion
        }

        # region [日付関連項目 展開処理]
        /// <summary>
        /// 日付関連項目　展開
        /// </summary>
        /// <param name="targetRow">データロー</param>
        /// <param name="eraNameDispCd">0:西暦　1:和暦</param>
        /// <param name="date">日付</param>
        /// <param name="dateColumnName">日付コントロール</param>
        /// <param name="isMonth">日付フォーマットフラグ</param>
        /// <remarks>
        /// <br>Note        : 日付関連項目　展開</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ExtractDate( ref DataRow targetRow, int eraNameDispCd, DateTime date, string dateColumnName, bool isMonth )
        {
            // DateTimeを対応するInt値に変換
            int dateInt = 0;
            if ( date != DateTime.MinValue )
            {
                if ( !isMonth )
                {
                    dateInt = (date.Year * 10000) + (date.Month * 100) + (date.Day);
                }
                else
                {
                    dateInt = (date.Year * 100) + (date.Month);
                }
            }

            // 日付展開メソッドに渡す
            ExtractDate( ref targetRow, eraNameDispCd, dateInt, dateColumnName, isMonth );
        }

        /// <summary>
        /// 日付関連項目　展開
        /// </summary>
        /// <param name="targetRow">データロー</param>
        /// <param name="eraNameDispCd">0:西暦　1:和暦</param>
        /// <param name="date">日付</param>
        /// <param name="dateColumnName">日付コントロール</param>
        /// <param name="isMonth">日付フォーマットフラグ</param>
        /// <remarks>
        /// <br>Note        : 日付関連項目　展開</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ExtractDate( ref DataRow targetRow, int eraNameDispCd, int date, string dateColumnName, bool isMonth )
        {
            //-------------------------------------------------------------------
            // 【項目の印字有無】
            //         YMD YM Y
            // 2009    ○　○　○
            // 01      ○　○　×
            // 31      ○　×　×
            // 年      ○　○　○
            // 月      ○　○　×
            // 日      ○　×　×
            // /       ○　○　×
            // .       ○　○　×
            // 平成    ○　○　○
            // H       ○　○　○
            // 21      ○　○　○
            //-------------------------------------------------------------------

            // 和暦フラグ
            bool jpEra = (eraNameDispCd == 1);
            // 年のみ判定フラグ
            bool isYear = false;

            bool emptyYear = false;
            if (isMonth)//yyyymm
            {
                if ((date / 100) == 0 && (date % 100) != 0)
                    emptyYear = true;
            }

            if (date != 0 && !emptyYear) 
            {
                // 年月項目の場合は、和暦変換に備えて指定年月の最終日に変換する
                if ( isMonth )
                {
                    // 年のみ判定("200900"→2009年)
                    isYear = (date % 100 == 0);

                    if ( isYear )
                    {
                        //-----------------------------------------------
                        // 年のみ
                        //-----------------------------------------------

                        // 指定年月の日数を求める(=その年の最終日)※12/31ですが念のため…
                        int dd = DateTime.DaysInMonth( date / 100, 12 );

                        // YYYYMMDDにする
                        date = ((int)(date / 100) * 10000) + (12*100) + dd;
                    }
                    else
                    {
                        //-----------------------------------------------
                        // 年月のみ
                        //-----------------------------------------------

                        // 指定年月の日数を求める(=その月の最終日)
                        int dd = DateTime.DaysInMonth( date / 100, date % 100 );

                        // YYYYMMDDにする
                        date = (date * 100) + dd;
                    }
                }

                // 年（和暦or西暦）
                if ( jpEra )
                {
                    // 和暦
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = GetDateFW( date ); // 和暦年
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = TDateTime.LongDateToString( "GG", date ); // 和暦元号
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = TDateTime.LongDateToString( "gg", date ); // 和暦元号略号
                    // クリア
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = DBNull.Value;
                }
                else
                {
                    // 西暦
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = (date / 10000); // 西暦年
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = (date / 10000) % 100; // 西暦年(略)
                    // クリア
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = DBNull.Value;
                }

                // 年リテラル
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLY" )] = "年";

                if ( !isYear )
                {
                    // 月
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] = (date / 100) % 100; // 月

                    // リテラル系
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLS" )] = "/";
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLP" )] = ".";
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLM" )] = "月";

                    if ( !isMonth )
                    {
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FD" )] = (date % 100); // 日
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLD" )] = "日";
                    }
                }
            }
            else
            {
                // 無効な日付ならば空白
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLS" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLP" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLY" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLM" )] = DBNull.Value;

                if ( !isMonth )
                {
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FD" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLD" )] = DBNull.Value;
                }
            }
        }

        /// <summary>
        /// 和暦年取得処理（H20の"20"のみを取得する）
        /// </summary>
        /// <param name="date">日付</param>
        /// <returns>和暦年</returns>
        /// <remarks>
        /// <br>Note        : 和暦年取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int GetDateFW( int date )
        {
            // 和暦略号を取得
            string date_gg = TDateTime.LongDateToString( "gg", date );  // H
            string date_exggyy = TDateTime.LongDateToString( "exggyy", date );  // H20

            // "H20" から "H" を取り除いて "20" を取得する
            return ToInt( date_exggyy.Substring( date_gg.Length, date_exggyy.Length - date_gg.Length ) );

        }

        /// <summary>
        /// 数値変換処理
        /// </summary>
        /// <param name="text">変換前文字列</param>
        /// <returns>変換後数値</returns>
        /// <remarks>
        /// <br>Note        : 数値変換処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int ToInt( string text )
        {
            try
            {
                return Int32.Parse( text );
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 日付Extraフォーマット(印刷用)
        /// </summary>
        /// <param name="targetRow">データロー</param>
        /// <param name="eraNameDispCd">0:西暦　1:和暦</param>
        /// <param name="dateColumnName">日付コントロール</param>
        /// <param name="isMonth">日付フォーマットフラグ</param>
        /// <remarks>
        /// <br>Note        : 日付Extraフォーマット(印刷用)</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ExtractDateOfExtraFormat( ref DataRow targetRow, int eraNameDispCd, string dateColumnName, bool isMonth )
        {
            try
            {
                // セット済み判定(年は西暦/和暦の差し替えがあるので、月項目で判断する)
                if ( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] != DBNull.Value )
                {
                    // 和暦フラグ
                    bool jpEra = (eraNameDispCd == 1);

                    int dtFY = CellToInt( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] ); // 西暦年
                    int dtFS = CellToInt( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] ); // 西暦年(略)
                    int dtFW = CellToInt( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] ); // 和暦年
                    int dtFM = CellToInt( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] ); // 月
                    int dtFD = CellToInt( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FD" )] ); // 日

                    // 日付(末日対応の為)
                    string wkFD;
                    if ( dtFD != 0 )
                    {
                        wkFD = string.Format( "{0:D2}", dtFD );
                    }
                    else
                    {
                        wkFD = ct_LastDayString; // 末日
                    }

                    if ( jpEra )
                    {
                        string dtFG = CellToString( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] ); // 和暦元号
                        string dtFR = CellToString( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] ); // 和暦略号

                        //------------------------------------------------
                        // 和暦
                        //------------------------------------------------
                        // Ex1 (年月日 西暦4桁)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX1" )] = string.Format( "{0}{1:D2}年{2:D2}月{3}日", dtFG, dtFW, dtFM, wkFD );
                        // Ex2 (年月日 西暦2桁)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX2" )] = string.Format( "{0}{1:D2}年{2:D2}月{3}日", dtFG, dtFW, dtFM, wkFD );
                        // Ex3 (/ 西暦4桁)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX3" )] = string.Format( "{0}{1:D2}/{2:D2}/{3}", dtFR, dtFW, dtFM, wkFD );
                        // Ex4 (/ 西暦2桁)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX4" )] = string.Format( "{0}{1:D2}/{2:D2}/{3}", dtFR, dtFW, dtFM, wkFD );
                        // Ex5 (. 西暦4桁)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX5" )] = string.Format( "{0}{1:D2}.{2:D2}.{3}", dtFR, dtFW, dtFM, wkFD );
                        // Ex6 (. 西暦2桁)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX6" )] = string.Format( "{0}{1:D2}.{2:D2}.{3}", dtFR, dtFW, dtFM, wkFD );
                    }
                    else
                    {
                        //------------------------------------------------
                        // 西暦
                        //------------------------------------------------
                        // Ex1 (年月日 西暦4桁)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX1" )] = string.Format( "{0}{1:D4}年{2:D2}月{3}日", string.Empty, dtFY, dtFM, wkFD );
                        // Ex2 (年月日 西暦2桁)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX2" )] = string.Format( "{0}{1:D2}年{2:D2}月{3}日", string.Empty, dtFS, dtFM, wkFD );
                        // Ex3 (/ 西暦4桁)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX3" )] = string.Format( "{0}{1:D4}/{2:D2}/{3}", string.Empty, dtFY, dtFM, wkFD );
                        // Ex4 (/ 西暦2桁)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX4" )] = string.Format( "{0}{1:D2}/{2:D2}/{3}", string.Empty, dtFS, dtFM, wkFD );
                        // Ex5 (. 西暦4桁)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX5" )] = string.Format( "{0}{1:D4}.{2:D2}.{3}", string.Empty, dtFY, dtFM, wkFD );
                        // Ex6 (. 西暦2桁)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX6" )] = string.Format( "{0}{1:D2}.{2:D2}.{3}", string.Empty, dtFS, dtFM, wkFD );
                    }
                }
                else
                {
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX1" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX2" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX3" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX4" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX5" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX6" )] = DBNull.Value;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 数値処理
        /// </summary>
        /// <param name="cell">セル対象</param>
        /// <returns>セル数値</returns>
        /// <remarks>
        /// <br>Note        : 数値処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int CellToInt( object cell )
        {
            if ( cell != DBNull.Value )
            {
                try
                {
                    return (int)cell;
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 文字列変換
        /// </summary>
        /// <param name="cell">セル対象</param>
        /// <returns>セル文字列</returns>
        /// <remarks>
        /// <br>Note        : 文字列変換</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string CellToString( object cell )
        {
            if ( cell != DBNull.Value )
            {
                try
                {
                    return (string)cell;
                }
                catch
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        # endregion

        # region [固定名称取得]
        /// <summary>
        /// 回収条件名称 取得処理
        /// </summary>
        /// <param name="code">回収条件コード</param>
        /// <returns>回収条件名称</returns>
        /// <remarks>
        /// <br>Note        : 回収条件名称 取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetHADD_COLLECTCONDNM( int code )
        {
            // 10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他
            switch ( code )
            {
                case 10:
                    return "現金";
                case 20:
                    return "振込";
                case 30:
                    return "小切手";
                case 40:
                    return "手形";
                case 50:
                    return "手数料";
                case 60:
                    return "相殺";
                case 70:
                    return "値引";
                case 80:
                    return "その他";
                default:
                    return string.Empty;
            }
        }
        # endregion

        # region [明細デザイン対応 対象データフィールドリスト取得処理]
        /// <summary>
        /// 明細デザイン対応　売上ヘッダ項目フィールドリスト
        /// </summary>
        /// <returns>売上ヘッダ項目フィールドリスト</returns>
        /// <remarks>
        /// <br>Note        : 明細デザイン対応　売上ヘッダ項目フィールドリスト</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note  : 2022/10/18 田村顕成</br>
        /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// </remarks>
        public static List<string> GetDesignSalesHeaderList()
        {
            return new List<string>( new string[] 
            { 
                # region [売上ヘッダ項目]
                "SALESSLIPRF.ACPTANODRSTATUSRF",
                "SALESSLIPRF.SALESSLIPNUMRF",
                "SALESSLIPRF.SECTIONCODERF",
                "SALESSLIPRF.SUBSECTIONCODERF",
                "SALESSLIPRF.DEBITNOTEDIVRF",
                "SALESSLIPRF.SALESSLIPCDRF",
                "SALESSLIPRF.SALESGOODSCDRF",
                "SALESSLIPRF.ACCRECDIVCDRF",
                "SALESSLIPRF.DEMANDADDUPSECCDRF",
                "SALESSLIPRF.SALESDATERF",
                "SALESSLIPRF.ADDUPADATERF",
                "SALESSLIPRF.INPUTAGENCDRF",
                "SALESSLIPRF.INPUTAGENNMRF",
                "SALESSLIPRF.SALESINPUTCODERF",
                "SALESSLIPRF.SALESINPUTNAMERF",
                "SALESSLIPRF.FRONTEMPLOYEECDRF",
                "SALESSLIPRF.FRONTEMPLOYEENMRF",
                "SALESSLIPRF.SALESEMPLOYEECDRF",
                "SALESSLIPRF.SALESEMPLOYEENMRF",
                "SALESSLIPRF.SALESTOTALTAXINCRF",
                "SALESSLIPRF.SALESTOTALTAXEXCRF",
                "SALESSLIPRF.SALESPRTTOTALTAXINCRF",
                "SALESSLIPRF.SALESPRTTOTALTAXEXCRF",
                "SALESSLIPRF.SALESWORKTOTALTAXINCRF",
                "SALESSLIPRF.SALESWORKTOTALTAXEXCRF",
                "SALESSLIPRF.SALESSUBTOTALTAXINCRF",
                "SALESSLIPRF.SALESSUBTOTALTAXEXCRF",
                "SALESSLIPRF.SALESPRTSUBTTLINCRF",
                "SALESSLIPRF.SALESPRTSUBTTLEXCRF",
                "SALESSLIPRF.SALESWORKSUBTTLINCRF",
                "SALESSLIPRF.SALESWORKSUBTTLEXCRF",
                "SALESSLIPRF.SALESSUBTOTALTAXRF",
                "SALESSLIPRF.ITDEDPARTSDISOUTTAXRF",
                "SALESSLIPRF.ITDEDPARTSDISINTAXRF",
                "SALESSLIPRF.ITDEDWORKDISOUTTAXRF",
                "SALESSLIPRF.ITDEDWORKDISINTAXRF",
                "SALESSLIPRF.PARTSDISCOUNTRATERF",
                "SALESSLIPRF.RAVORDISCOUNTRATERF",
                "SALESSLIPRF.TOTALCOSTRF",
                "SALESSLIPRF.CONSTAXRATERF",
                "SALESSLIPRF.AUTODEPOSITCDRF",
                "SALESSLIPRF.AUTODEPOSITSLIPNORF",
                "SALESSLIPRF.DEPOSITALLOWANCETTLRF",
                "SALESSLIPRF.DEPOSITALWCBLNCERF",
                "SALESSLIPRF.CLAIMCODERF",
                "SALESSLIPRF.CUSTOMERCODERF",
                "SALESSLIPRF.CUSTOMERNAMERF",
                "SALESSLIPRF.CUSTOMERNAME2RF",
                "SALESSLIPRF.CUSTOMERSNMRF",
                "SALESSLIPRF.HONORIFICTITLERF",
                "SALESSLIPRF.ADDRESSEECODERF",
                "SALESSLIPRF.ADDRESSEENAMERF",
                "SALESSLIPRF.ADDRESSEENAME2RF",
                "SALESSLIPRF.SLIPNOTERF",
                "SALESSLIPRF.SLIPNOTE2RF",
                "SALESSLIPRF.SLIPNOTE3RF",
                "SALESSLIPRF.RETGOODSREASONDIVRF",
                "SALESSLIPRF.RETGOODSREASONRF",
                "SALESSLIPRF.DETAILROWCOUNTRF",
                "SALESSLIPRF.UOEREMARK1RF",
                "SALESSLIPRF.UOEREMARK2RF",
                "SALESSLIPRF.DELIVEREDGOODSDIVRF",
                "SALESSLIPRF.DELIVEREDGOODSDIVNMRF",
                "SALESSLIPRF.STOCKGOODSTTLTAXEXCRF",
                "SALESSLIPRF.PUREGOODSTTLTAXEXCRF",
                "SALESSLIPRF.FOOTNOTES1RF",
                "SALESSLIPRF.FOOTNOTES2RF",
                "SECDTL.SECTIONGUIDENMRF",
                "SECDTL.SECTIONGUIDESNMRF",
                "SECDTL.COMPANYNAMECD1RF",
                "SUBSAL.SUBSECTIONNAMERF",
                "DADD.ACPTANODRSTATUSRF",
                "DADD.DEBITNOTEDIVRF",
                "DADD.SALESSLIPCDRF",
                "DADD.SALESDATERF",
                // --- ADD START 田村顕成 2022/10/18 ----->>>>>
                "TAX.HFTOTALCONSTAXRATETITLERF",
                "TAX.HFTOTALSALESMONEYTAXEXCRF",
                "TAX.HFTAXRATE1RF",
                "TAX.HFTAXRATE1SALESTAXEXCRF",
                "TAX.HFTAXRATE1SALESTAXRF",
                "TAX.HFTAXRATE2RF",
                "TAX.HFTAXRATE2SALESTAXEXCRF",
                "TAX.HFTAXRATE2SALESTAXRF",
                "TAX.HFTAXOUTITLERF",
                "TAX.HFTAXOUTSALESTAXEXCRF",
                "TAX.HFOTHERTAXRATERF",
                "TAX.HFOTHERTAXRATESALESTAXEXCRF",
                "TAX.HFOTHERTAXRATESALESTAXRF",
                "TAX.HFTAXTITLERF",
                // --- ADD END   田村顕成 2022/10/18 -----<<<<<
                "DADD.SALESDATEFYRF",
                "DADD.SALESDATEFSRF",
                "DADD.SALESDATEFWRF",
                "DADD.SALESDATEFMRF",
                "DADD.SALESDATEFDRF",
                "DADD.SALESDATEFGRF",
                "DADD.SALESDATEFRRF",
                "DADD.SALESDATEFLSRF",
                "DADD.SALESDATEFLPRF",
                "DADD.SALESDATEFLYRF",
                "DADD.SALESDATEFLMRF",
                "DADD.SALESDATEFLDRF"    // ←最後の項目はカンマなし
                # endregion
            } );
        }
        /// <summary>
        /// 明細デザイン対応　売上明細項目フィールドリスト
        /// </summary>
        /// <returns>売上明細項目フィールドリスト</returns>
        /// <remarks>
        /// <br>Note        : 明細デザイン対応　売上明細項目フィールドリスト</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note  : 2022/10/18 田村顕成</br>
        /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// </remarks>
        public static List<string> GetDesignSalesDetailList()
        {
            return new List<string>( new string[] 
            { 
                # region [売上明細項目]
                "SALESDETAILRF.ACCEPTANORDERNORF",
                "SALESDETAILRF.SALESROWNORF",
                "SALESDETAILRF.DELIGDSCMPLTDUEDATERF",
                "SALESDETAILRF.GOODSKINDCODERF",
                "SALESDETAILRF.GOODSMAKERCDRF",
                "SALESDETAILRF.MAKERNAMERF",
                "SALESDETAILRF.GOODSNORF",
                "SALESDETAILRF.GOODSNAMERF",
                "SALESDETAILRF.GOODSSHORTNAMERF",
                "SALESDETAILRF.GOODSLGROUPRF",
                "SALESDETAILRF.GOODSLGROUPNAMERF",
                "SALESDETAILRF.GOODSMGROUPRF",
                "SALESDETAILRF.GOODSMGROUPNAMERF",
                "SALESDETAILRF.BLGROUPCODERF",
                "SALESDETAILRF.BLGROUPNAMERF",
                "SALESDETAILRF.BLGOODSCODERF",
                "SALESDETAILRF.BLGOODSFULLNAMERF",
                "SALESDETAILRF.ENTERPRISEGANRECODERF",
                "SALESDETAILRF.ENTERPRISEGANRENAMERF",
                "SALESDETAILRF.WAREHOUSECODERF",
                "SALESDETAILRF.WAREHOUSENAMERF",
                "SALESDETAILRF.WAREHOUSESHELFNORF",
                "SALESDETAILRF.SALESORDERDIVCDRF",
                "SALESDETAILRF.OPENPRICEDIVRF",
                "SALESDETAILRF.GOODSRATERANKRF",
                "SALESDETAILRF.LISTPRICERATERF",
                "SALESDETAILRF.LISTPRICETAXINCFLRF",
                "SALESDETAILRF.LISTPRICETAXEXCFLRF",
                "SALESDETAILRF.SALESRATERF",
                "SALESDETAILRF.SALESUNPRCTAXINCFLRF",
                "SALESDETAILRF.SALESUNPRCTAXEXCFLRF",
                "SALESDETAILRF.COSTRATERF",
                "SALESDETAILRF.SALESUNITCOSTRF",
                "SALESDETAILRF.PRTBLGOODSCODERF",
                "SALESDETAILRF.PRTBLGOODSNAMERF",
                "SALESDETAILRF.WORKMANHOURRF",
                "SALESDETAILRF.SHIPMENTCNTRF",
                "SALESDETAILRF.SALESMONEYTAXINCRF",
                "SALESDETAILRF.SALESMONEYTAXEXCRF",
                "SALESDETAILRF.COSTRF",
                "SALESDETAILRF.TAXATIONDIVCDRF",
                "SALESDETAILRF.PARTYSLIPNUMDTLRF",
                "SALESDETAILRF.DTLNOTERF",
                "SALESDETAILRF.SUPPLIERCDRF",
                "SALESDETAILRF.SUPPLIERSNMRF",
                "SALESDETAILRF.SLIPMEMO1RF",
                "SALESDETAILRF.SLIPMEMO2RF",
                "SALESDETAILRF.SLIPMEMO3RF",
                "SALESDETAILRF.INSIDEMEMO1RF",
                "SALESDETAILRF.INSIDEMEMO2RF",
                "SALESDETAILRF.INSIDEMEMO3RF",
                "SALESDETAILRF.BFLISTPRICERF",
                "SALESDETAILRF.BFSALESUNITPRICERF",
                "SALESDETAILRF.BFUNITCOSTRF",
                "SALESDETAILRF.CMPLTSALESROWNORF",
                "SALESDETAILRF.CMPLTGOODSMAKERCDRF",
                "SALESDETAILRF.CMPLTMAKERNAMERF",
                "SALESDETAILRF.CMPLTGOODSNAMERF",
                "SALESDETAILRF.CMPLTSHIPMENTCNTRF",
                "SALESDETAILRF.CMPLTSALESUNPRCFLRF",
                "SALESDETAILRF.CMPLTSALESMONEYRF",
                "SALESDETAILRF.CMPLTSALESUNITCOSTRF",
                "SALESDETAILRF.CMPLTCOSTRF",
                "SALESDETAILRF.CMPLTPARTYSALSLNUMRF",
                "SALESDETAILRF.CMPLTNOTERF",
                "ACCEPTODRCARRF.CARMNGNORF",
                "ACCEPTODRCARRF.CARMNGCODERF",
                "ACCEPTODRCARRF.NUMBERPLATE1CODERF",
                "ACCEPTODRCARRF.NUMBERPLATE1NAMERF",
                "ACCEPTODRCARRF.NUMBERPLATE2RF",
                "ACCEPTODRCARRF.NUMBERPLATE3RF",
                "ACCEPTODRCARRF.NUMBERPLATE4RF",
                "ACCEPTODRCARRF.FIRSTENTRYDATERF",
                "ACCEPTODRCARRF.MAKERCODERF",
                "ACCEPTODRCARRF.MAKERFULLNAMERF",
                "ACCEPTODRCARRF.MODELCODERF",
                "ACCEPTODRCARRF.MODELSUBCODERF",
                "ACCEPTODRCARRF.MODELFULLNAMERF",
                "ACCEPTODRCARRF.EXHAUSTGASSIGNRF",
                "ACCEPTODRCARRF.SERIESMODELRF",
                "ACCEPTODRCARRF.CATEGORYSIGNMODELRF",
                "ACCEPTODRCARRF.FULLMODELRF",
                "ACCEPTODRCARRF.MODELDESIGNATIONNORF",
                "ACCEPTODRCARRF.CATEGORYNORF",
                "ACCEPTODRCARRF.FRAMEMODELRF",
                "ACCEPTODRCARRF.FRAMENORF",
                "ACCEPTODRCARRF.SEARCHFRAMENORF",
                "ACCEPTODRCARRF.ENGINEMODELNMRF",
                "ACCEPTODRCARRF.RELEVANCEMODELRF",
                "ACCEPTODRCARRF.SUBCARNMCDRF",
                "ACCEPTODRCARRF.MODELGRADESNAMERF",
                "ACCEPTODRCARRF.COLORCODERF",
                "ACCEPTODRCARRF.COLORNAME1RF",
                "ACCEPTODRCARRF.TRIMCODERF",
                "ACCEPTODRCARRF.TRIMNAMERF",
                "ACCEPTODRCARRF.MILEAGERF",
                "DADD.STOCKGOODSTTLTAXEXCRF",
                "DADD.PUREGOODSTTLTAXEXCRF",
                "DADD.GOODSKINDCODERF",
                "DADD.SALESORDERDIVCDRF",
                "DADD.OPENPRICEDIVRF",
                "DADD.TAXATIONDIVCDRF",
                "DADD.FIRSTENTRYDATEFYRF",
                "DADD.FIRSTENTRYDATEFSRF",
                "DADD.FIRSTENTRYDATEFWRF",
                "DADD.FIRSTENTRYDATEFMRF",
                "DADD.FIRSTENTRYDATEFGRF",
                "DADD.FIRSTENTRYDATEFRRF",
                "DADD.FIRSTENTRYDATEFLSRF",
                "DADD.FIRSTENTRYDATEFLPRF",
                "DADD.FIRSTENTRYDATEFLYRF",
                "DADD.FIRSTENTRYDATEFLMRF",
                "DADD.DMDDTLOUTLINERF",
                "DADD.MODELHALFNAME2RF",
                // --- ADD START 田村顕成 2022/10/18 ----->>>>>
                "TAX.DTLTAXRATERF",
                "TAX.DTLTOTALCONSTAXRATETITLERF",
                "TAX.DTLTOTALSALESMONEYTAXEXCRF",
                "TAX.DTLTAXRATE1RF",
                "TAX.DTLTAXRATE1SALESTAXEXCRF",
                "TAX.DTLTAXRATE1SALESTAXRF",
                "TAX.DTLTAXRATE2RF",
                "TAX.DTLTAXRATE2SALESTAXEXCRF",
                "TAX.DTLTAXRATE2SALESTAXRF",
                "TAX.DTLTAXOUTITLERF",
                "TAX.DTLTAXOUTSALESTAXEXCRF",
                "TAX.DTLOTHERTAXRATERF",
                "TAX.DTLOTHERTAXRATESALESTAXEXCRF",
                "TAX.DTLOTHERTAXRATESALESTAXRF",
                "TAX.DTLTAXTITLERF",
                // --- ADD END   田村顕成 2022/10/18 -----<<<<<
                "DSAL.DETAILTITLERF",
                "DADD.MODELHALFNAMEDTL2RF",
                "DADD.FULLMODELRF"
                # endregion
            } );
        }
        /// <summary>
        /// 明細デザイン対応　売上フッタ項目フィールドリスト
        /// </summary>
        /// <returns>売上フッタ項目フィールドリスト</returns>
        /// <remarks>
        /// <br>Note        : 明細デザイン対応　売上フッタ項目フィールドリスト</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note : 2023/04/14 3H 仰亮亮</br>
        /// <br>管理番号    : 11970040-00 自由帳票項目追加対応</br>
        /// <br>              ①売上伝票計金額(税込み)</br>
        /// <br>              ②消費税(伝票転嫁)/売上伝票計金額(税込み)</br>
        /// </remarks>
        public static List<string> GetDesignSalesFooterList()
        {
            return new List<string>( new string[]
            { 
                # region [売上フッタ項目]
                "DADD.DETAILBLANKLINERF", 
                "DADD.SALESMONEYALLDETAILTTLRF", 
                "SALESSLIPRF.PARTYSALESLIPNUMRF",
                "DADD.SALESFTTITLERF",
                "DADD.SALESFTPRICERF",
                "DADD.SALESFTNOTE1RF",
                "DADD.SALESFTNOTE2RF",
                "DADD.SALESFTNOTE3RF",
                "DADD.SLIPTTLTAXTITLERF",
                "DADD.SLIPTTLTAXRF",
                "DADD.ADDTAXLINERF",
                // --- ADD START 3H 仰亮亮 2023/04/14 >>>>>
                "DADD.SALESMONEYTAXINCRF",               // 売上伝票計金額(税込み)
                "DADD.TAXRFANDSALESMONEYTAXINCRF",       // 消費税(伝票転嫁)/売上伝票計金額(税込み)
                // --- ADD END 3H 仰亮亮 2023/04/14  <<<<<
                "DADD.DTLTITLERF"         // ←最後の項目はカンマなし
                #endregion
            } );
        }
        /// <summary>
        /// 明細デザイン対応　売上フッタ２項目フィールドリスト
        /// </summary>
        /// <returns>売上フッタ２項目フィールドリスト</returns>
        /// <remarks>
        /// <br>Note        : 明細デザイン対応　売上フッタ２項目フィールドリスト</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static List<string> GetDesignSalesFooter2List()
        {
            return new List<string>(new string[]
            {
                #region[売上フッタ２項目]
                "DADD.SALESFT2NOTERF",
                "DADD.SALESFT2TITLERF",
                "DADD.SALESFT2PRICERF",
                "DADD.SALESFT2TITLE2RF",
                "DADD.SALESFT2PRICE2RF"      // ←最後の項目はカンマなし
                #endregion
            });
        }
        /// <summary>
        /// 明細デザイン対応　売上フッタ３項目フィールドリスト
        /// </summary>
        /// <returns>売上フッタ３項目フィールドリスト</returns>
        /// <remarks>
        /// <br>Note        : 明細デザイン対応　売上フッタ３項目フィールドリスト</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static List<string> GetDesignSalesFooter3List()
        {
            return new List<string>(new string[]
            {
                #region[売上フッタ３ 項目]
                "DADD.SALESFT3NOTERF",
                "DADD.SALESFT3TITLERF",
                "DADD.SALESFT3PRICERF"      // ←最後の項目はカンマなし
                #endregion
            });
        }
        /// <summary>
        /// 明細デザイン対応　売上ヘッダ２項目フィールドリスト
        /// </summary>
        /// <returns>売上ヘッダ２項目フィールドリスト</returns>
        /// <remarks>
        /// <br>Note        : 明細デザイン対応　売上ヘッダ２項目フィールドリスト</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static List<string> GetDesignSalesHeader2List()
        {
            return new List<string>(new string[]
                {
                    #region[売上ヘッダ２ 項目]
                    "DADD.FULLMODELHD2RF",
                    "DADD.MODELHALFNAMEHD2RF",
                    "DADD.SALESSLIPCDCHANGERF",
                    "DADD.SALESSLIPNUMHD2RF",
                    "DADD.SALESDATEHD2FMRF",
                    "DADD.SALESDATEHD2FDRF",
                    "DADD.SALESDATEHD2FLPRF",
                    "DADD.SALESDATEHD2RF",
                    "DADD.SALESDATEHD2FYRF",
                    "DADD.SALESDATEHD2FSRF",
                    "DADD.SALESDATEHD2FWRF",
                    "DADD.SALESDATEHD2FGRF",
                    "DADD.SALESDATEHD2FRRF",
                    "DADD.SALESDATEHD2FLSRF",
                    "DADD.SALESDATEHD2FLYRF",
                    "DADD.SALESDATEHD2FLMRF",
                    "DADD.HEADFULLMODEL2RF",
                    "DADD.SALESDATEHD2FLDRF"   // ←最後の項目はカンマなし
                    #endregion
                });
        }
        /// <summary>
        /// 明細デザイン対応　売上集計項目フィールドリスト
        /// </summary>
        /// <returns>売上集計項目フィールドリスト</returns>
        /// <remarks>
        /// <br>Note        :  明細デザイン対応　売上集計項目フィールドリスト</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static List<string> GetDesignSalesTotalList()
        {
            return new List<string>( new string[]
            { 
                # region [売上集計項目]
                "DSAL.DETAILSUMTITLERF",
                "DSAL.DETAILSUMPRICERF"    // ←最後の項目はカンマなし
                #endregion
            } );
        }
        /// <summary>
        /// 明細デザイン対応　入金明細項目フィールドリスト
        /// </summary>
        /// <returns>入金明細項目フィールドリスト</returns>
        /// <remarks>
        /// <br>Note        : 明細デザイン対応　入金明細項目フィールドリスト</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static List<string> GetDesignDepositDetailList()
        {
            return new List<string>( new string[]
            { 
                # region [入金明細項目]
                ct_col_DDep_MoneyKindNameSp,
                "DEPSITMAINRF.ACPTANODRSTATUSRF",
                "DEPSITMAINRF.DEPOSITSLIPNORF",
                "DEPSITMAINRF.SALESSLIPNUMRF",
                "DEPSITMAINRF.ADDUPSECCODERF",
                "DEPSITMAINRF.SUBSECTIONCODERF",
                "DEPSITMAINRF.DEPOSITDATERF",
                "DEPSITMAINRF.ADDUPADATERF",
                "DEPSITMAINRF.DEPOSITRF",
                "DEPSITMAINRF.FEEDEPOSITRF",
                "DEPSITMAINRF.DISCOUNTDEPOSITRF",
                "DEPSITMAINRF.AUTODEPOSITCDRF",
                "DEPSITMAINRF.DEPOSITCDRF",
                "DEPSITMAINRF.DRAFTDRAWINGDATERF",
                "DEPSITMAINRF.DRAFTKINDRF",
                "DEPSITMAINRF.DRAFTKINDNAMERF",
                "DEPSITMAINRF.DRAFTDIVIDENAMERF",
                "DEPSITMAINRF.DRAFTNORF",
                "DEPSITMAINRF.CUSTOMERCODERF",
                "DEPSITMAINRF.CLAIMCODERF",
                "DEPSITMAINRF.OUTLINERF",
                "SUBDEP.SUBSECTIONNAMERF",
                "DEPSITDTLRF.DEPOSITSLIPNORF",
                "DEPSITDTLRF.DEPOSITROWNORF",
                "DEPSITDTLRF.MONEYKINDCODERF",
                "DEPSITDTLRF.MONEYKINDNAMERF",
                "DEPSITDTLRF.MONEYKINDDIVRF",
                "DEPSITDTLRF.DEPOSITRF",
                "DEPSITDTLRF.VALIDITYTERMRF",
                "DADD.DEPOSITDATEFYRF",
                "DADD.DEPOSITDATEFSRF",
                "DADD.DEPOSITDATEFWRF",
                "DADD.DEPOSITDATEFMRF",
                "DADD.DEPOSITDATEFDRF",
                "DADD.DEPOSITDATEFGRF",
                "DADD.DEPOSITDATEFRRF",
                "DADD.DEPOSITDATEFLSRF",
                "DADD.DEPOSITDATEFLPRF",
                "DADD.DEPOSITDATEFLYRF",
                "DADD.DEPOSITDATEFLMRF",
                "DADD.DEPOSITDATEFLDRF",
                "DADD.AUTODEPOSITCDRF",
                "DADD.DEPOSITCDRF",
                "DADD.DRAFTDRAWINGDATEFYRF",
                "DADD.DRAFTDRAWINGDATEFSRF",
                "DADD.DRAFTDRAWINGDATEFWRF",
                "DADD.DRAFTDRAWINGDATEFMRF",
                "DADD.DRAFTDRAWINGDATEFDRF",
                "DADD.DRAFTDRAWINGDATEFGRF",
                "DADD.DRAFTDRAWINGDATEFRRF",
                "DADD.DRAFTDRAWINGDATEFLSRF",
                "DADD.DRAFTDRAWINGDATEFLPRF",
                "DADD.DRAFTDRAWINGDATEFLYRF",
                "DADD.DRAFTDRAWINGDATEFLMRF",
                "DADD.DRAFTDRAWINGDATEFLDRF",
                "DADD.DRAFTPAYTIMELIMITFYRF",
                "DADD.DRAFTPAYTIMELIMITFSRF",
                "DADD.DRAFTPAYTIMELIMITFWRF",
                "DADD.DRAFTPAYTIMELIMITFMRF",
                "DADD.DRAFTPAYTIMELIMITFDRF",
                "DADD.DRAFTPAYTIMELIMITFGRF",
                "DADD.DRAFTPAYTIMELIMITFRRF",
                "DADD.DRAFTPAYTIMELIMITFLSRF",
                "DADD.DRAFTPAYTIMELIMITFLPRF",
                "DADD.DRAFTPAYTIMELIMITFLYRF",
                "DADD.DRAFTPAYTIMELIMITFLMRF",
                "DADD.DRAFTPAYTIMELIMITFLDRF",
                "DADD.VALIDITYTERMFYRF",
                "DADD.VALIDITYTERMFSRF",
                "DADD.VALIDITYTERMFWRF",
                "DADD.VALIDITYTERMFMRF",
                "DADD.VALIDITYTERMFDRF",
                "DADD.VALIDITYTERMFGRF",
                "DADD.VALIDITYTERMFRRF",
                "DADD.VALIDITYTERMFLSRF",
                "DADD.VALIDITYTERMFLPRF",
                "DADD.VALIDITYTERMFLYRF",
                "DADD.VALIDITYTERMFLMRF",
                "DADD.VALIDITYTERMFLDRF",
                "DDEP.DETAILTITLERF",    
                "DADD.MONEYKINDCODEOTHERRF"// ←最後の項目はカンマなし
                #endregion
            } );
        }
        /// <summary>
        /// 明細デザイン対応　入金集計項目フィールドリスト
        /// </summary>
        /// <returns>入金集計項目フィールドリスト</returns>
        /// <remarks>
        /// <br>Note        : 明細デザイン対応　入金集計項目フィールドリスト</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static List<string> GetDesignDepositTotalList()
        {
            return new List<string>( new string[]
            { 
                # region [入金集計項目]
                ct_col_DDep_DepFtOutLine,
                "DDEP.DETAILSUMTITLERF",
                "DDEP.DETAILSUMPRICERF",
                "DADD.DEPOSITFTTITLERF",
                "DADD.DTLTITLERF"
                #endregion
            } );
        }

        # endregion

        # region [データテーブルからの情報取得]
        /// <summary>
        /// 親子判定処理
        /// </summary>
        /// <param name="table">データテーブル</param>
        /// <returns>親子判定結果</returns>
        /// <remarks>
        /// <br>Note        : 親子判定処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static bool IsParent( DataTable table )
        {
            try
            {
                if (table != null && table.Rows.Count > 0)
                {
                    // 請求先毎の集計レコードならばtrue
                    return ((int)table.Rows[0]["CUSTDMDPRCRF.CUSTOMERCODERF"] == 0);
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return true;
            }
        }

        /// <summary>
        /// 転嫁方式取得処理
        /// </summary>
        /// <param name="table">データテーブル</param>
        /// <returns>転嫁方式コード</returns>
        /// <remarks>
        /// <br>Note        : 転嫁方式取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static int GetConsTaxLayMethod( DataTable table )
        {
            if ( table != null && table.Rows.Count > 0 )
            {
                // 転嫁方式
                return (int)table.Rows[0]["CUSTDMDPRCRF.CONSTAXLAYMETHODRF"];
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// ドキュメント枝番取得
        /// </summary>
        /// <param name="targetRow">データロー</param>
        /// <returns>ドキュメント枝番</returns>
        /// <remarks>
        /// <br>Note        : ドキュメント枝番取得</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static string GetDocumentDerivedNo( DataRow targetRow )
        {
            string derivedNo = string.Empty;

            // 請求書ヘッダ
            if ( targetRow[PMKAU01002AB.CT_BillList_FrePBillHead] != DBNull.Value )
            {
                EBooksFrePBillHeadWork headWork = (targetRow[PMKAU01002AB.CT_BillList_FrePBillHead] as EBooksFrePBillHeadWork);

                if (headWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0)
                {
                    // 集計レコード
                    derivedNo = string.Format( "{0}_{1}_{2}",
                                                headWork.CUSTDMDPRCRF_ADDUPDATERF.ToString( "00000000" ),
                                                headWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim(),
                                                headWork.CUSTDMDPRCRF_CLAIMCODERF.ToString( "00000000" ) );
                }
                else
                {
                    // 親／子レコード
                    derivedNo = string.Format( "{0}_{1}_{2}_{3}_{4}",
                                                headWork.CUSTDMDPRCRF_ADDUPDATERF.ToString( "00000000" ),
                                                headWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim(),
                                                headWork.CUSTDMDPRCRF_CLAIMCODERF.ToString("00000000"),
                                                headWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim(),
                                                headWork.CUSTDMDPRCRF_CUSTOMERCODERF.ToString("00000000") );
                }
            }

            return derivedNo;
        }

        /// <summary>
        /// ドキュメント枝番取得
        /// </summary>
        /// <param name="targetRow">データロー</param>
        /// <returns>ドキュメント枝番</returns>
        /// <remarks>
        /// <br>Note        : ドキュメント枝番取得</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static string GetDocumentDerivedNoForBatch(DataRow targetRow)
        {
            string derivedNo = string.Empty;

            // 請求書ヘッダ
            if (targetRow[PMKAU01002AB.CT_BillList_FrePBillHead] != DBNull.Value)
            {
                EBooksFrePBillHeadWork headWork = (targetRow[PMKAU01002AB.CT_BillList_FrePBillHead] as EBooksFrePBillHeadWork);

                // 親／子レコード
                derivedNo = string.Format("{0}#{1}",
                                            headWork.CUSTDMDPRCRF_CLAIMCODERF.ToString("00000000"),
                                            headWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim());
            }

            return derivedNo;
        }
        //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ---->>>>>
        /// <summary>
        /// ドキュメント枝番取得
        /// </summary>
        /// <param name="targetRow">データロー</param>
        /// <returns>ドキュメント枝番</returns>
        /// <remarks>
        /// <br>Note        : ドキュメント枝番取得</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/04/21</br>
        /// </remarks>
        public static string GetDocumentDerivedNoForPattern3(DataRow targetRow)
        {
            string derivedNo = string.Empty;

            // 請求書ヘッダ
            if (targetRow[PMKAU01002AB.CT_BillList_FrePBillHead] != DBNull.Value)
            {
                EBooksFrePBillHeadWork headWork = (targetRow[PMKAU01002AB.CT_BillList_FrePBillHead] as EBooksFrePBillHeadWork);
                char[] badChars = new char[] { '\\', '/', ':', '*', '?', '\"', '<', '>', '|' };
                string claimSnm = headWork.CUSTDMDPRCRF_CLAIMSNMRF.Trim();
                StringBuilder claimSnmStr = new StringBuilder();
                string[] result = claimSnm.Split(badChars, StringSplitOptions.RemoveEmptyEntries);
                foreach(string str in result)
                {
                    claimSnmStr.Append(str);
                }
                // 親／子レコード
                derivedNo = string.Format("_{0}_{1}_{2}",
                                            headWork.CUSTDMDPRCRF_ADDUPDATERF.ToString("00000000"),
                                            headWork.CUSTDMDPRCRF_CLAIMCODERF.ToString("00000000"),
                                            claimSnmStr.ToString());
            }

            return derivedNo;
        }
        //---ADD 2022/04/21 陳艶丹 PMKOBETSU-4208 電子帳簿2次対応 ----<<<<<
        # endregion

        # endregion

        # region [グループサプレスキー]
        /// <summary>
        /// グループサプレスキー
        /// </summary>
        /// <remarks>
        /// <br>Note        : グループサプレスキー</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private struct GroupSuppressKey : IComparable<GroupSuppressKey>
        {
            /// <summary>ページ数</summary>
            private int _page;
            /// <summary>日付</summary>
            private int _date;
            /// <summary>売上・入金</summary>
            private int _salesDepoDiv;
            /// <summary>売上伝票番号</summary>
            private string _salesSlipNo;
            /// <summary>入金伝票番号</summary>
            private int _depositSlipNo;
            /// <summary>型式</summary>
            private string _fullModel;
            /// <summary>車種</summary>
            private string _modelFullName;
            /// <summary>年式</summary>
            private int _firstEntryDate;
            /// <summary>
            /// ページ数
            /// </summary>
            public int Page
            {
                get { return _page; }
                set { _page = value; }
            }
            /// <summary>
            /// 日付
            /// </summary>
            public int Date
            {
                get { return _date; }
                set { _date = value; }
            }
            /// <summary>
            /// 売上・入金
            /// </summary>
            /// <remarks>0:売上,1:入金</remarks>
            public int SalesDepoDiv
            {
                get { return _salesDepoDiv; }
                set { _salesDepoDiv = value; }
            }
            /// <summary>
            /// 売上伝票番号
            /// </summary>
            public string SalesSlipNo
            {
                get { return _salesSlipNo; }
                set { _salesSlipNo = value; }
            }
            /// <summary>
            /// 入金伝票番号
            /// </summary>
            public int DepositSlipNo
            {
                get { return _depositSlipNo; }
                set { _depositSlipNo = value; }
            }
            /// <summary>
            /// 型式
            /// </summary>
            /// <remarks>型式・車種・年式でキーとする</remarks>
            public string FullModel
            {
                get { return _fullModel; }
                set { _fullModel = value; }
            }
            /// <summary>
            /// 車種
            /// </summary>
            /// <remarks>型式・車種・年式でキーとする</remarks>
            public string ModelFullName
            {
                get { return _modelFullName; }
                set { _modelFullName = value; }
            }
            /// <summary>
            /// 年式
            /// </summary>
            /// <remarks>型式・車種・年式でキーとする</remarks>
            public int FirstEntryDate
            {
                get { return _firstEntryDate; }
                set { _firstEntryDate = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="page">ページ数</param>
            /// <param name="date">日付</param>
            /// <param name="salesDepoDiv">売上・入金</param>
            /// <param name="salesSlipNo">売上伝票番号</param>
            /// <param name="slipNo">入金伝票番号</param>
            /// <param name="fullModel">型式</param>
            /// <param name="modelFullName">車種</param>
            /// <param name="firstEntryDate">年式</param>
            /// <remarks>
            /// <br>Note        : コンストラクタ</br>
            /// <br>Programmer  : 陳艶丹</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public GroupSuppressKey( int page, int date, int salesDepoDiv, string salesSlipNo, int slipNo, string fullModel, string modelFullName, int firstEntryDate )
            {
                _page = page;
                _date = date;
                _salesDepoDiv = salesDepoDiv;
                _salesSlipNo = salesSlipNo;
                _depositSlipNo = slipNo;
                _fullModel = fullModel;
                _modelFullName = modelFullName;
                _firstEntryDate = firstEntryDate;
            }
            /// <summary>
            /// 初期化済みインスタンス取得
            /// </summary>
            /// <returns>初期化済みインスタンス</returns>
            /// <remarks>
            /// <br>Note        : 初期化済みインスタンス取得</br>
            /// <br>Programmer  : 陳艶丹</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public static GroupSuppressKey Create()
            {
                GroupSuppressKey key = new GroupSuppressKey();
                key.Page = 0;
                key.Date = 0;
                key.SalesDepoDiv = 0;
                key.SalesSlipNo = string.Empty;
                key.DepositSlipNo = 0;
                key.FullModel = string.Empty;
                key.ModelFullName = string.Empty;
                key.FirstEntryDate = 0;
                return key;
            }

            /// <summary>
            /// 日付キー
            /// </summary>
            /// <param name="row">データロー</param>
            /// <returns>日付キー</returns>
            /// <remarks>
            /// <br>Note        : 日付キー</br>
            /// <br>Programmer  : 陳艶丹</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public static GroupSuppressKey CreateKeyOfDate( DataRow row )
            {
                GroupSuppressKey key = Create();

                key.Page = (int)row[ct_col_PageCount];
                if ( row["SALESSLIPRF.SALESSLIPNUMRF"] != DBNull.Value )
                {
                    key.Date = (int)row["SALESSLIPRF.SALESDATERF"];

                    // 伝票番号違いでブレイク
                    key.SalesSlipNo = (string)row["SALESSLIPRF.SALESSLIPNUMRF"];
                    key.DepositSlipNo = 0;
                }
                else if ( row["DEPSITMAINRF.DEPOSITSLIPNORF"] != DBNull.Value )
                {
                    key.Date = (int)row["DEPSITMAINRF.DEPOSITDATERF"];

                    // 伝票番号違いでブレイク
                    key.SalesSlipNo = string.Empty;
                    key.DepositSlipNo = (int)row["DEPSITMAINRF.DEPOSITSLIPNORF"];
                }
                return key;
            }

            /// <summary>
            /// 伝票番号キー
            /// </summary>
            /// <param name="row">データロー</param>
            /// <returns>伝票番号キー</returns>
            /// <remarks>
            /// <br>Note        : 伝票番号キー</br>
            /// <br>Programmer  : 陳艶丹</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public static GroupSuppressKey CreateKeyOfSlipNo( DataRow row )
            {
                GroupSuppressKey key = Create();
                key.Page = (int)row[ct_col_PageCount];
                if ( row["SALESSLIPRF.SALESSLIPNUMRF"] != DBNull.Value )
                {
                    key.Date = (int)row["SALESSLIPRF.SALESDATERF"];
                    key.SalesSlipNo = (string)row["SALESSLIPRF.SALESSLIPNUMRF"];
                    key.DepositSlipNo = 0;
                    key.SalesDepoDiv = 0;
                }
                else if ( row["DEPSITMAINRF.DEPOSITSLIPNORF"] != DBNull.Value )
                {
                    key.Date = (int)row["DEPSITMAINRF.DEPOSITDATERF"];
                    key.SalesSlipNo = string.Empty;
                    key.DepositSlipNo = (int)row["DEPSITMAINRF.DEPOSITSLIPNORF"];
                    key.SalesDepoDiv = 1;
                }
                return key;
            }

            /// <summary>
            /// 車輌情報キー
            /// </summary>
            /// <param name="row">データロー</param>
            /// <returns>車輌情報キー</returns>
            /// <remarks>
            /// <br>Note        : 車輌情報キー</br>
            /// <br>Programmer  : 陳艶丹</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public static GroupSuppressKey CreateKeyOfCar( DataRow row )
            {
                GroupSuppressKey key = Create();
                key.Page = (int)row[ct_col_PageCount];
                if ( row["SALESSLIPRF.SALESSLIPNUMRF"] != DBNull.Value )
                {
                    key.Date = (int)row["SALESSLIPRF.SALESDATERF"];
                    key.SalesSlipNo = (string)row["SALESSLIPRF.SALESSLIPNUMRF"];
                    key.DepositSlipNo = 0;
                    key.SalesDepoDiv = 0;
                    if ( row["ACCEPTODRCARRF.FULLMODELRF"] != DBNull.Value )
                    {
                        key.FullModel = (string)row["ACCEPTODRCARRF.FULLMODELRF"];
                    }
                    if ( row["ACCEPTODRCARRF.MODELFULLNAMERF"] != DBNull.Value )
                    {
                        key.ModelFullName = (string)row["ACCEPTODRCARRF.MODELFULLNAMERF"];
                    }
                    if ( row["ACCEPTODRCARRF.FIRSTENTRYDATERF"] != DBNull.Value )
                    {
                        key.FirstEntryDate = (int)row["ACCEPTODRCARRF.FIRSTENTRYDATERF"];
                    }
                }
                else if ( row["DEPSITMAINRF.DEPOSITSLIPNORF"] != DBNull.Value )
                {
                    key.Date = (int)row["DEPSITMAINRF.DEPOSITDATERF"];
                    key.SalesSlipNo = string.Empty;
                    key.DepositSlipNo = (int)row["DEPSITMAINRF.DEPOSITSLIPNORF"];
                    key.SalesDepoDiv = 1;
                }
                return key;
            }

            /// <summary>
            /// 日付キー２（ページ数なし）
            /// </summary>
            /// <param name="row">データロー</param>
            /// <returns>日付キー２（ページ数なし）</returns>
            /// <remarks>
            /// <br>Note        : 日付キー２（ページ数なし）</br>
            /// <br>Programmer  : 陳艶丹</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public static GroupSuppressKey CreateKeyOfDate2(DataRow row)
            {
                GroupSuppressKey key = Create();

                if (row["SALESSLIPRF.SALESSLIPNUMRF"] != DBNull.Value)
                {
                    key.Date = (int)row["SALESSLIPRF.SALESDATERF"];

                    // 伝票番号違いでブレイク
                    key.SalesSlipNo = (string)row["SALESSLIPRF.SALESSLIPNUMRF"];
                    key.DepositSlipNo = 0;
                }
                else if (row["DEPSITMAINRF.DEPOSITSLIPNORF"] != DBNull.Value)
                {
                    key.Date = (int)row["DEPSITMAINRF.DEPOSITDATERF"];

                    // 伝票番号違いでブレイク
                    key.SalesSlipNo = string.Empty;
                    key.DepositSlipNo = (int)row["DEPSITMAINRF.DEPOSITSLIPNORF"];
                }
                return key;
            }

            /// <summary>
            /// 伝票番号キー２（ページ数なし）
            /// </summary>
            /// <param name="row">データロー</param>
            /// <returns>伝票番号キー２（ページ数なし）</returns>
            /// <remarks>
            /// <br>Note        : 伝票番号キー２（ページ数なし）</br>
            /// <br>Programmer  : 陳艶丹</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public static GroupSuppressKey CreateKeyOfSlipNo2(DataRow row)
            {
                GroupSuppressKey key = Create();
                if (row["SALESSLIPRF.SALESSLIPNUMRF"] != DBNull.Value)
                {
                    key.Date = (int)row["SALESSLIPRF.SALESDATERF"];
                    key.SalesSlipNo = (string)row["SALESSLIPRF.SALESSLIPNUMRF"];
                    key.DepositSlipNo = 0;
                    key.SalesDepoDiv = 0;
                }
                else if (row["DEPSITMAINRF.DEPOSITSLIPNORF"] != DBNull.Value)
                {
                    key.Date = (int)row["DEPSITMAINRF.DEPOSITDATERF"];
                    key.SalesSlipNo = string.Empty;
                    key.DepositSlipNo = (int)row["DEPSITMAINRF.DEPOSITSLIPNORF"];
                    key.SalesDepoDiv = 1;
                }
                return key;
            }

            /// <summary>
            /// 比較処理
            /// </summary>
            /// <param name="other">比較用キー</param>
            /// <returns>比較結果</returns>
            /// <remarks>
            /// <br>Note        : 比較処理</br>
            /// <br>Programmer  : 陳艶丹</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public int CompareTo( GroupSuppressKey other )
            {
                int result;

                result = this.Page.CompareTo( other.Page );
                if ( result != 0 ) return result;

                result = this.Date.CompareTo( other.Date );
                if ( result != 0 ) return result;

                result = this.SalesSlipNo.CompareTo( other.SalesSlipNo );
                if ( result != 0 ) return result;

                result = this.DepositSlipNo.CompareTo( other.DepositSlipNo );
                if ( result != 0 ) return result;

                result = this.SalesDepoDiv.CompareTo( other.SalesDepoDiv );
                if ( result != 0 ) return result;

                result = this.FullModel.CompareTo( other.FullModel );
                if ( result != 0 ) return result;

                result = this.ModelFullName.CompareTo( other.ModelFullName );
                if ( result != 0 ) return result;

                result = this.FirstEntryDate.CompareTo( other.FirstEntryDate );
                
                return result;
            }
        }
        # endregion

        # region [ソート用enum]
        /// <summary>
        /// ソート用レコード区分
        /// </summary>
        internal enum SortRecordDivState
        {
            /// <summary>
            /// 売上
            /// </summary>
            Sales = 0,
            /// <summary>
            /// 入金
            /// </summary>
            Deposit = 1,
            /// <summary>
            /// 日計
            /// </summary>
            Daily = 2,
        }
        /// <summary>
        /// ソート用レコード区分(空行最後)
        /// </summary>
        internal enum SortRecordDiv_EmptyDetailState
        {
            /// <summary>
            /// 売上
            /// </summary>
            Sales = 0,
            /// <summary>
            /// 日計
            /// </summary>
            Daily = 1,
            /// <summary>
            /// 入金
            /// </summary>
            Deposit = 2,
            /// <summary>
            /// 空行
            /// </summary>
            EmptyDetail = 99,    
        }
        /// <summary>
        /// ソート用明細区分状態
        /// </summary>
        internal enum SortDetailDivState
        {
            /// <summary>
            /// ヘッダ
            /// </summary>
            Header = 0,
            /// <summary>
            /// 明細（通常）
            /// </summary>
            Detail = 1,
            /// <summary>
            /// フッタ
            /// </summary>
            Footer = 2,
            /// <summary>
            /// フッタ２
            /// </summary>
            Footer2 = 3,
            /// <summary>
            /// フッタ３
            /// </summary>
            Footer3 = 4,
            /// <summary>
            /// フッタ４
            /// </summary>
            Footer4 = 5,
        }
        # endregion

        # region [請求書印刷レイアウトパラメータ]
        /// <summary>
        /// 請求書印刷レイアウトパラメータ
        /// </summary>
        public struct BillDmdPrintParameter
        {
            /// <summary>２頁目以降加算行数</summary>
            private int _otherFeedAddCount;
            /// <summary>売上集計行有無フラグ</summary>
            private bool _existsSalesTotalFooter;
            /// <summary>入金集計行有無フラグ</summary>
            private bool _existsDepositTotalFooter;
            /// <summary>伝票計タイトル</summary>
            private string _footerTitleOfSlip;
            /// <summary>日計タイトル</summary>
            private string _footerTitleOfDaily;
            /// <summary>得意先計タイトル</summary>
            private string _footerTitleOfCustomer;
            /// <summary>消費税タイトル</summary>
            private string _taxTitle;
            /// <summary>相殺後売上合計金額(税込)タイトル </summary>
            private string _OfsThisSalesTaxIncTtl;
            /// <summary>プレート番号タイトル</summary>
            private string _carmngCodeTitle;
            /// <summary>伝票合計消費税タイトル</summary>
            private string _slipTtlTaxTitle;
            /// <summary>売上伝票計(消費税)</summary>
            private string _footerTitleOfTax;
            /// <summary>売上伝票計(課税合計)</summary>
            private string _footerTitleOfSlipTaxInc;
            /// <summary>売上フッタ行有無フラグ </summary>
            private bool _existsSalesFooter;
            /// <summary>売上フッタ２行有無フラグ </summary>
            private bool _existsSalesFooter2;
            /// <summary>売上フッタ３ 行有無フラグ </summary>
            private bool _existsSalesFooter3;
            /// <summary>売上ヘッダ２ 行有無フラグ </summary>
            private bool _existsSalesHeader2;
            /// <summary>入金計タイトル</summary>
            private string _depositFooterTitleOfSlip;
            /// <summary>売上伝票計(消費税)２</summary>
            private string _footerTitleOfTax2;
            /// <summary>売上伝票計(課税合計)２</summary>
            private string _footerTitleOfSlipTaxInc2;
            /// <summary>
            /// ２頁目以降加算行数
            /// </summary>
            public int OtherFeedAddCount
            {
                get { return _otherFeedAddCount; }
                set { _otherFeedAddCount = value; }
            }
            /// <summary>
            /// 売上集計行有無フラグ
            /// </summary>
            public bool ExistsSalesTotalFooter
            {
                get { return _existsSalesTotalFooter; }
                set { _existsSalesTotalFooter = value; }
            }
            /// <summary>
            /// 入金集計行有無フラグ
            /// </summary>
            public bool ExistsDepositTotalFooter
            {
                get { return _existsDepositTotalFooter; }
                set { _existsDepositTotalFooter = value; }
            }
            /// <summary>
            /// 伝票計タイトル
            /// </summary>
            public string FooterTitleOfSlip
            {
                get { return _footerTitleOfSlip; }
                set { _footerTitleOfSlip = value; }
            }
            /// <summary>
            /// 日計タイトル
            /// </summary>
            public string FooterTitleOfDaily
            {
                get { return _footerTitleOfDaily; }
                set { _footerTitleOfDaily = value; }
            }
            /// <summary>
            /// 得意先計タイトル
            /// </summary>
            public string FooterTitleOfCustomer
            {
                get { return _footerTitleOfCustomer; }
                set { _footerTitleOfCustomer = value; }
            }
            /// <summary>
            /// 消費税タイトル
            /// </summary>
            public string TaxTitle
            {
                get { return _taxTitle; }
                set { _taxTitle = value; }
            }
            /// <summary>
            /// 相殺後売上合計金額(税込)タイトル
            /// </summary>
            public string OfsThisSalesTaxIncTtl
            {
                get { return _OfsThisSalesTaxIncTtl; }
                set { _OfsThisSalesTaxIncTtl = value; }
            }
            /// <summary>
            /// プレート番号タイトル
            /// </summary>
            public string CarmngCodeTitle
            {
                get { return _carmngCodeTitle; }
                set { _carmngCodeTitle = value; }
            }

            /// <summary>
            /// 伝票合計消費税タイトル
            /// </summary>
            public string SlipTtlTaxTitle
            {
                get { return _slipTtlTaxTitle; }
                set { _slipTtlTaxTitle = value; }
            }
            /// <summary>
            /// 伝票計タイトル(消費税) 
            /// </summary>
            public string FooterTitleOfTax
            {
                get { return _footerTitleOfTax; }
                set { _footerTitleOfTax = value; }
            }
            /// <summary>
            /// 伝票計タイトル(課税合計)
            /// </summary>
            public string FooterTitleOfSlipTaxInc
            {
                get { return _footerTitleOfSlipTaxInc; }
                set { _footerTitleOfSlipTaxInc = value; }
            }
            /// <summary>
            /// 売上フッタ有無フラグ
            /// </summary>
            public bool ExistsSalesFooter
            {
                get { return _existsSalesFooter; }
                set { _existsSalesFooter = value; }
            }
            /// <summary>
            /// 売上フッタ２有無フラグ
            /// </summary>
            public bool ExistsSalesFooter2
            {
                get { return _existsSalesFooter2; }
                set { _existsSalesFooter2 = value; }
            }
            /// <summary>
            /// 売上フッタ３ 有無フラグ
            /// </summary>
            public bool ExistsSalesFooter3
            {
                get { return _existsSalesFooter3; }
                set { _existsSalesFooter3 = value; }
            }
            /// <summary>
            /// 売上ヘッダ２　有無フラグ
            /// </summary>
            public bool ExistsSalesHeader2
            {
                get { return _existsSalesHeader2; }
                set { _existsSalesHeader2 = value; }
            }
            /// <summary>
            /// 入金計タイトル
            /// </summary>
            public string DepositFooterTitleOfSlip
            {
                get { return _depositFooterTitleOfSlip; }
                set { _depositFooterTitleOfSlip = value; }
            }
            /// <summary>
            /// 売上伝票計(消費税)２
            /// </summary>
            public string FooterTitleOfTax2
            {
                get { return _footerTitleOfTax2; }
                set { _footerTitleOfTax2 = value; }
            }
            /// <summary>
            /// 伝票計タイトル(課税合計)２
            /// </summary>
            public string FooterTitleOfSlipTaxInc2
            {
                get { return _footerTitleOfSlipTaxInc2; }
                set { _footerTitleOfSlipTaxInc2 = value; }
            }
        }
        # endregion

        // --- ADD START 田村顕成 2022/10/18 ----->>>>>
        #region[税率別情報合計]
        /// <summary>
        /// 税率別情報合計
        /// </summary>
        /// <param name="lSalesCnsTaxFrcProcd">売上消費税端数処理コード</param>
        /// <param name="lConstaxLaymethod">消費税転嫁方式</param>
        /// <param name="lTaxRate1SalesMoneyEx">税率１ 合計金額</param>
        /// <param name="lTaxRate1SalesPriceConsTax">税率１ 消費税</param>
        /// <param name="lTaxRate2SalesMoneyEx">税率２  合計金額</param>
        /// <param name="lTaxRate2SalesPriceConsTax">税率２  消費税</param>
        /// <param name="lTaxOutSalesMoneyEx">非課税 合計金額</param>
        /// <param name="lOtherSalesMoneyEx">その他 合計金額</param>
        /// <param name="lOtherSalesPriceConsTax">その他 消費税</param>
        /// <param name="dicCustomerCode">消費税転嫁方式「請求子」消費税金額集計</param>
        /// <param name="dTaxRate1">税率１(XML設定)</param>
        /// <param name="dTaxRate2">税率２(XML設定)</param>
        /// <param name="TotalTaxRateSalesMoney">税別情報合計</param>
        /// <remarks>
        /// <br>Update Note  : 2022/10/18 田村顕成</br>
        /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// <br>Update Note  : 2023/06/23 3H 仰亮亮</br>
        /// <br>管理番号     : 11900025-00 消費税転嫁「請求子」の税率別税額不具合対応</br>
        /// </remarks> 
        private static void SalesTotalTaxMoneyDiffCalc(Int32 lSalesCnsTaxFrcProcd, Int32 lConstaxLaymethod,
                                       Double lTaxRate1SalesMoneyEx, Double lTaxRate1SalesPriceConsTax,
                                        Double lTaxRate2SalesMoneyEx, Double lTaxRate2SalesPriceConsTax,
                                          Double lTaxOutSalesMoneyEx,
                                            Double lOtherSalesMoneyEx, Double lOtherSalesPriceConsTax,                                            
                                              Dictionary<Int32, TaxRateSalesMoney> dicCustomerCode,
                                                Double dTaxRate1, Double dTaxRate2,
                                                  out TaxRateSalesMoney TotalTaxRateSalesMoney)
        {
            #region 「変数初期化」
            TotalTaxRateSalesMoney = new TaxRateSalesMoney();
            Int64  ltax                  = 0;     // 消費税(端数処理後)
            Double listPriceFrocProcUnit = 0;     // 端数処理単位
            Double lSalesPriceConsTax    = 0;     // 端数処理金額
            Int32  listPriceFrocProcCd   = 0;     // 端数処理コード
            #endregion

            #region 「消費税転嫁方式：請求子消費税額集計」
            // --- DEL START 3H 仰亮亮 2023/06/23 ----------------------------------->>>>>
            //if (lConstaxLaymethod == 3)
            //{
            //    lTaxRate1SalesPriceConsTax = 0;
            //    lTaxRate2SalesPriceConsTax = 0;
            //    lOtherSalesPriceConsTax = 0;
            // --- DEL END 3H 仰亮亮 2023/06/23 -------------------------------------<<<<<
            // --- ADD START 3H 仰亮亮 2023/06/23 ----------------------------------->>>>>
            // [消費税転嫁「請求子」の税率別税額不具合対応]
            if (dicCustomerCode.Count > 0)
            {
            // --- ADD END 3H 仰亮亮 2023/06/23 -------------------------------------<<<<<
                Double tempOtherTaxRateMoney = 0;
                Double tempOtherTaxRateMoneyTotal = 0;
                TaxRateSalesMoney tempTaxRateSalesMoney;
                foreach (Int32 iCustomerCode in dicCustomerCode.Keys)
                {
                    tempTaxRateSalesMoney = new TaxRateSalesMoney();
                    tempOtherTaxRateMoneyTotal = 0;
                    dicCustomerCode.TryGetValue(iCustomerCode, out tempTaxRateSalesMoney);

                    ltax = 0;
                    lSalesPriceConsTax = tempTaxRateSalesMoney.TaxRate1SalesMoney * dTaxRate1;
                    stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
                    FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
                    lTaxRate1SalesPriceConsTax = lTaxRate1SalesPriceConsTax + ltax;

                    ltax = 0;
                    lSalesPriceConsTax = tempTaxRateSalesMoney.TaxRate2SalesMoney * dTaxRate2;
                    stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
                    FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
                    lTaxRate2SalesPriceConsTax = lTaxRate2SalesPriceConsTax + ltax;

                    foreach (Double dTaxRateKey in tempTaxRateSalesMoney.DicOtherTaxRateSalesMoney.Keys)
                    {
                        tempOtherTaxRateMoney = 0;
                        tempTaxRateSalesMoney.DicOtherTaxRateSalesMoney.TryGetValue(dTaxRateKey, out tempOtherTaxRateMoney);
                        tempOtherTaxRateMoneyTotal = tempOtherTaxRateMoneyTotal + tempOtherTaxRateMoney * dTaxRateKey;
                    }

                    ltax = 0;
                    lSalesPriceConsTax = tempOtherTaxRateMoneyTotal;
                    stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
                    FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
                    lOtherSalesPriceConsTax = lOtherSalesPriceConsTax + ltax;
                }
            }
            #endregion

            #region 「税率１」
            // 金額
            TotalTaxRateSalesMoney.TaxRate1SalesMoney = lTaxRate1SalesMoneyEx;
            // 消費税
            ltax = 0;
            lSalesPriceConsTax = lTaxRate1SalesPriceConsTax;
            stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
            FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
            TotalTaxRateSalesMoney.TaxRate1SalesPriceConsTax = ltax;
            #endregion

            #region 「税率２」
            // 金額
            TotalTaxRateSalesMoney.TaxRate2SalesMoney = lTaxRate2SalesMoneyEx;
            // 消費税
            ltax = 0;
            lSalesPriceConsTax = lTaxRate2SalesPriceConsTax;
            stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
            FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
            TotalTaxRateSalesMoney.TaxRate2SalesPriceConsTax = ltax;
            #endregion

            #region「非課税」
            // 金額
            TotalTaxRateSalesMoney.TaxOutSalesMoney = lTaxOutSalesMoneyEx;
            #endregion

            #region「その他」
            // 金額
            TotalTaxRateSalesMoney.OtherSalesMoney = lOtherSalesMoneyEx;
            // 消費税
            ltax = 0;
            lSalesPriceConsTax = lOtherSalesPriceConsTax;
            stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
            FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
            TotalTaxRateSalesMoney.OtherSalesPriceConsTax = ltax;
            #endregion
        }
        #endregion

        #region[明細税率別情報集計]
        /// <summary>
        /// 税率別情報集計
        /// </summary>
        /// <param name="index">売上明細データインデックス</param>
        /// <param name="lSalesCnsTaxFrcProcd">売上消費税端数処理コード</param>
        /// <param name="salesData">売上データ</param>
        /// <param name="bChgFlg">伝票番号変更有無フラグ</param>
        /// <param name="lTaxRate1SalesMoneyEx">税率１ 合計金額</param>
        /// <param name="lTaxRate1SalesPriceConsTax">税率１ 消費税合計</param>
        /// <param name="lTaxRate2SalesMoneyEx">税率２  合計金額</param>
        /// <param name="lTaxRate2SalesPriceConsTax">税率２  消費税合計</param>
        /// <param name="lOtherSalesMoneyEx">その他 合計金額</param>
        /// <param name="lOtherSalesPriceConsTax">その他 消費税合計</param>
        /// <param name="lTaxRate1MeisaiTotalTax">税率１ 消費税転嫁方式：「明細転嫁」の消費税金額合計</param>
        /// <param name="lTaxRate2MeisaiTotalTax">税率２ 消費税転嫁方式：「明細転嫁」の消費税金額合計</param>
        /// <param name="lOtherMeisaiTotalTax">その他 消費税転嫁方式：「明細転嫁」の消費税金額合計</param>
        /// <param name="lSalesMoneyEx">課税区分(1:非課税)以外の商品　売上金額合計</param>
        /// <param name="lSalesMoneyExTaxOut">課税区分(1:非課税)の商品　売上金額合計</param>
        /// <param name="dicCustomerCode">消費税転嫁方式「請求子」消費税金額集計</param>
        /// <param name="dTaxRate1">税率１(XML設定)</param>
        /// <param name="dTaxRate2">税率２(XML設定)</param>
        /// <remarks>
        /// <br>Update Note  : 2022/10/18 田村顕成</br>
        /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// </remarks>
        private static void SalesMeisaiTaxMoneyDiffCalc(Int64 index, Int32 lSalesCnsTaxFrcProcd , EBooksFrePBillDetailWork salesData, bool bChgFlg,
                                              ref Double lTaxRate1SalesMoneyEx, ref Double lTaxRate1SalesPriceConsTax,
                                                ref Double lTaxRate2SalesMoneyEx, ref Double lTaxRate2SalesPriceConsTax,
                                                  ref Double lOtherSalesMoneyEx, ref Double lOtherSalesPriceConsTax,
                                                    ref Double lTaxRate1MeisaiTotalTax, ref Double lTaxRate2MeisaiTotalTax, ref Double lOtherMeisaiTotalTax,
                                                      ref Double lSalesMoneyEx, ref double lSalesMoneyExTaxOut,
                                                        ref Dictionary<Int32, TaxRateSalesMoney> dicCustomerCode,
                                                          Double dTaxRate1, Double dTaxRate2)
        {
            if (index > 0)
            {
                Int64  ltax                  = 0;                                         // 消費税(端数処理後)
                Double listPriceFrocProcUnit = 0;                                         // 端数処理単位                
                Double lSalesPriceConsTax    = 0;                                         // 端数処理金額                
                Int32  listPriceFrocProcCd   = 0;                                         // 端数処理コード
                Double dTaxRate              = salesData.SALESSLIPRF_CONSTAXRATERF;       // 消費税税率
                Int32  iConsTaxlaymethod     = salesData.SALESSLIPRF_CONSTAXLAYMETHODRF;  // 消費税転嫁方式
                Int32  iTaxAtionDivCd        = salesData.SALESDETAILRF_TAXATIONDIVCDRF;   // 課税区分(0:課税,1:非課税,2:課税（内税）)

                #region 「消費税転嫁方式「明細転嫁」且つ　課税区分(1:非課税)以外消費税額集計、」
                if ((iConsTaxlaymethod == 1) && (iTaxAtionDivCd != 1))
                {
                    lSalesPriceConsTax = (salesData.SALESDETAILRF_SALESMONEYTAXEXCRF * salesData.SALESSLIPRF_CONSTAXRATERF);
                    stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
                    FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);

                    // 税率「税率２」且つ消費税転嫁方式「非課税」以外の売上データを集計
                    if ((dTaxRate == dTaxRate2) && (iConsTaxlaymethod != 9))
                    {
                        lTaxRate2MeisaiTotalTax = lTaxRate2MeisaiTotalTax + ltax;
                    }
                    // 税率「税率１」且つ消費税転嫁方式「非課税」以外の売上データを集計
                    else if ((dTaxRate == dTaxRate1) && (iConsTaxlaymethod != 9))
                    {
                        lTaxRate1MeisaiTotalTax = lTaxRate1MeisaiTotalTax + ltax;
                    }
                    // 税率「税率２」「税率１」以外 の売上データ集計
                    else if ((dTaxRate != dTaxRate1) && (dTaxRate != dTaxRate2))
                    {
                        lOtherMeisaiTotalTax = lOtherMeisaiTotalTax + ltax;
                    }
                }
                #endregion
                // 課税区分(1:非課税)以外 且つ　消費税転嫁方式(9:非課税)以外　売上金額を集計
                if ((iTaxAtionDivCd != 1) && (iConsTaxlaymethod != 9))
                {
                    lSalesMoneyEx = lSalesMoneyEx + salesData.SALESDETAILRF_SALESMONEYTAXEXCRF;
                }

                // 非課税売上金額を集計 課税区分(1:非課税) 且つ 消費税転嫁方式(9:非課税)　売上金額を集計
                if (iTaxAtionDivCd == 1 || iConsTaxlaymethod == 9)
                {
                    lSalesMoneyExTaxOut = lSalesMoneyExTaxOut + salesData.SALESDETAILRF_SALESMONEYTAXEXCRF;
                }

                // 伝票番号変更又は最後の売上ヘッダの場合、
                if (bChgFlg)
                {
                    // 初期化処理
                    ltax                  = 0;    // 消費税(端数処理後)
                    listPriceFrocProcUnit = 0;    // 端数処理単位
                    listPriceFrocProcCd   = 0;    // 端数処理コード
                    lSalesPriceConsTax    = lSalesMoneyEx * salesData.SALESSLIPRF_CONSTAXRATERF;
                    stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
                    #region 「税率２計算」
                    // 税率「税率２」且つ消費税転嫁方式「非課税」以外の売上データを集計
                    if ((dTaxRate == dTaxRate2) && (iConsTaxlaymethod != 9))
                    {
                        // 税率２  合計金額(売上小計（税抜き）)
                        lTaxRate2SalesMoneyEx = lTaxRate2SalesMoneyEx + lSalesMoneyEx;

                        // 消費税転嫁方式「伝票転嫁」の場合
                        if (iConsTaxlaymethod == 0)
                        {
                            FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
                            lTaxRate2SalesPriceConsTax = lTaxRate2SalesPriceConsTax + ltax;
                        }
                        // 消費税転嫁方式「明細」の場合
                        else if (iConsTaxlaymethod == 1)
                        {
                            // 税率２  消費税合計
                            lTaxRate2SalesPriceConsTax = lTaxRate2SalesPriceConsTax + lTaxRate2MeisaiTotalTax;
                        }
                        // 消費税転嫁方式「請求親」の場合
                        else if (iConsTaxlaymethod == 2)
                        {
                            lTaxRate2SalesPriceConsTax = lTaxRate2SalesPriceConsTax + lSalesPriceConsTax;
                        }
                        // 消費税転嫁方式「請求子」の場合
                        else if (iConsTaxlaymethod == 3)
                        {
                            TaxRateSalesMoney temptaxRateSale = new TaxRateSalesMoney();
                            temptaxRateSale.DicOtherTaxRateSalesMoney = new Dictionary<Double, Double>();
                            // 税率２  消費税合計
                            if (!dicCustomerCode.ContainsKey(salesData.SALESSLIPRF_CUSTOMERCODERF))
                            {
                                dicCustomerCode.Add(salesData.SALESSLIPRF_CUSTOMERCODERF, temptaxRateSale);
                            }

                            dicCustomerCode.TryGetValue(salesData.SALESSLIPRF_CUSTOMERCODERF, out temptaxRateSale);

                            temptaxRateSale.TaxRate2SalesMoney = temptaxRateSale.TaxRate2SalesMoney + lSalesMoneyEx;

                            dicCustomerCode[salesData.SALESSLIPRF_CUSTOMERCODERF] = temptaxRateSale;

                        }

                    }
                    #endregion

                    #region 「税率１計算」
                    // 税率「税率１」且つ消費税転嫁方式「非課税」以外の売上データを集計
                    else if ((dTaxRate == dTaxRate1) && (iConsTaxlaymethod != 9))
                    {
                        // 税率１  合計金額(売上小計（税抜き）)
                        lTaxRate1SalesMoneyEx = lTaxRate1SalesMoneyEx + lSalesMoneyEx;

                        // 消費税転嫁方式「伝票転嫁」の場合
                        if ((iConsTaxlaymethod == 0))
                        {
                            FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
                            lTaxRate1SalesPriceConsTax = lTaxRate1SalesPriceConsTax + ltax;
                        }
                        // 消費税転嫁方式「明細」の場合
                        else if (iConsTaxlaymethod == 1)
                        {
                            // 税率１  消費税合計
                            lTaxRate1SalesPriceConsTax = lTaxRate1SalesPriceConsTax + lTaxRate1MeisaiTotalTax;
                        }

                        // 消費税転嫁方式「請求親」の場合
                        else if (iConsTaxlaymethod == 2)
                        {
                            lTaxRate1SalesPriceConsTax = lTaxRate1SalesPriceConsTax + lSalesPriceConsTax;
                        }
                        // 消費税転嫁方式「請求子」の場合
                        else if (iConsTaxlaymethod == 3)
                        {
                            TaxRateSalesMoney temptaxRateSale = new TaxRateSalesMoney();
                            temptaxRateSale.DicOtherTaxRateSalesMoney = new Dictionary<Double, Double>();

                            // 税率１  消費税合計
                            if (!dicCustomerCode.ContainsKey(salesData.SALESSLIPRF_CUSTOMERCODERF))
                            {
                                dicCustomerCode.Add(salesData.SALESSLIPRF_CUSTOMERCODERF, temptaxRateSale);
                            }

                            dicCustomerCode.TryGetValue(salesData.SALESSLIPRF_CUSTOMERCODERF, out temptaxRateSale);

                            temptaxRateSale.TaxRate1SalesMoney = temptaxRateSale.TaxRate1SalesMoney + lSalesMoneyEx;

                            dicCustomerCode[salesData.SALESSLIPRF_CUSTOMERCODERF] = temptaxRateSale;
                        }

                    }
                    #endregion

                    #region 「その他計算」
                    // 税率「税率２」「税率１」以外又は消費税転嫁方式「非課税」の売上データ集計
                    if ((dTaxRate != dTaxRate1) && (dTaxRate != dTaxRate2) && (iConsTaxlaymethod != 9))
                    {
                        // その他  合計金額(売上小計（税抜き）) 
                        lOtherSalesMoneyEx = lOtherSalesMoneyEx + lSalesMoneyEx;

                        // 消費税転嫁方式「伝票、請求子」の場合
                        if (iConsTaxlaymethod == 0)
                        {
                            FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
                            lOtherSalesPriceConsTax = lOtherSalesPriceConsTax + ltax;
                        }
                        // 消費税転嫁方式「明細」の場合
                        else if (iConsTaxlaymethod == 1)
                        {
                            // そのた  消費税合計
                            lOtherSalesPriceConsTax = lOtherSalesPriceConsTax + lOtherMeisaiTotalTax;
                        }
                        // 消費税転嫁方式「請求親」の場合
                        else if (iConsTaxlaymethod == 2)
                        {
                            lOtherSalesPriceConsTax = lOtherSalesPriceConsTax + lSalesPriceConsTax;
                        }
                        // 消費税転嫁方式「請求子」の場合
                        else if (iConsTaxlaymethod == 3)
                        {
                            TaxRateSalesMoney temptaxRateSale = new TaxRateSalesMoney();
                            temptaxRateSale.DicOtherTaxRateSalesMoney = new Dictionary<Double, Double>();
                            Double dicOtherRate = 0;
                            // その他　税率  消費税合計
                            if (!dicCustomerCode.ContainsKey(salesData.SALESSLIPRF_CUSTOMERCODERF))
                            {
                                dicCustomerCode.Add(salesData.SALESSLIPRF_CUSTOMERCODERF, temptaxRateSale);
                            }

                            dicCustomerCode.TryGetValue(salesData.SALESSLIPRF_CUSTOMERCODERF, out temptaxRateSale);

                            // 複数税率　税率単位
                            if (!temptaxRateSale.DicOtherTaxRateSalesMoney.ContainsKey(dTaxRate))
                            {
                                temptaxRateSale.DicOtherTaxRateSalesMoney.Add(dTaxRate, 0);
                            }

                            // 複数税率　合計金額(売上小計（税抜き）)
                            temptaxRateSale.DicOtherTaxRateSalesMoney.TryGetValue(dTaxRate, out dicOtherRate);

                            dicOtherRate = dicOtherRate + lSalesMoneyEx;

                            temptaxRateSale.DicOtherTaxRateSalesMoney[dTaxRate] = dicOtherRate;

                            // 得意先コード単位
                            dicCustomerCode[salesData.SALESSLIPRF_CUSTOMERCODERF] = temptaxRateSale;
                        }
                    }
                    #endregion
                    // 伝票単位計算ために、リセット
                    // 消費税転嫁方式：「明細転嫁」
                    lTaxRate1MeisaiTotalTax = 0; // 税率１ 消費税額
                    lTaxRate2MeisaiTotalTax = 0; // 税率２ 消費税額
                    lOtherMeisaiTotalTax = 0; // その他 消費税額
                    lSalesMoneyEx = 0;
                }
            }
        }
        #endregion

        /// <summary>
        /// 税率別合計金額
        /// </summary>
        /// <remarks>
        /// <br>Update Note  : 2022/10/18 田村顕成</br>
        /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// </remarks>
        public class TaxRateSalesMoney 
        {
            /// <summary>税率１ 合計金額</summary>
            private Double _TaxRate1SalesMoney;

            /// <summary>税率１ 消費税額</summary>
            private Double _TaxRate1SalesPriceConsTax;

            /// <summary>税率２合計金額</summary>
            private Double _TaxRate2SalesMoney;

            /// <summary>税率２ 消費税額</summary>
            private Double _TaxRate2SalesPriceConsTax;

            /// <summary>その他 合計金額</summary>
            private Double _OtherSalesMoney;

            /// <summary>その他 消費税額</summary>
            private Double _OtherSalesPriceConsTax;

            /// <summary>その他税率別金額</summary>
            private Dictionary<Double, Double> _dicOtherTaxRateSalesMoney;

            /// <summary>非課税　合計金額</summary>
            private Double _TaxOutSalesMoney;
            /// public propaty name  :  TaxOutSalesMoney
            /// <summary>非課税　合計金額</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   非課税　合計金額プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Double TaxOutSalesMoney
            {
                get { return _TaxOutSalesMoney; }
                set { _TaxOutSalesMoney = value; }
            }

            /// public propaty name  :  TaxRate1SalesMoney
            /// <summary>税率１合計金額</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   税率１合計金額プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Double TaxRate1SalesMoney
            {
                get { return _TaxRate1SalesMoney; }
                set { _TaxRate1SalesMoney = value; }
            }

            /// public propaty name  :  TaxRate1SalesPriceConsTax
            /// <summary>税率１消費税額</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   税率１消費税額プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Double TaxRate1SalesPriceConsTax
            {
                get { return _TaxRate1SalesPriceConsTax; }
                set { _TaxRate1SalesPriceConsTax = value; }
            }

            /// public propaty name  :  TaxRate2SalesMoney
            /// <summary>税率２合計金額</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   税率２合計金額プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Double TaxRate2SalesMoney
            {
                get { return _TaxRate2SalesMoney; }
                set { _TaxRate2SalesMoney = value; }
            }

            /// public propaty name  :  TaxRate2SalesPriceConsTax
            /// <summary>税率２ 消費税額</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   税率２消費税額プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Double TaxRate2SalesPriceConsTax
            {
                get { return _TaxRate2SalesPriceConsTax; }
                set { _TaxRate2SalesPriceConsTax = value; }
            }

            /// public propaty name  :  OtherSalesMoney
            /// <summary>その他合計金額</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   その他合計金額プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Double OtherSalesMoney
            {
                get { return _OtherSalesMoney; }
                set { _OtherSalesMoney = value; }
            }

            /// public propaty name  :  OtherSalesPriceConsTax
            /// <summary>その他 消費税額</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   税率１消費税額プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Double OtherSalesPriceConsTax
            {
                get { return _OtherSalesPriceConsTax; }
                set { _OtherSalesPriceConsTax = value; }
            }

            /// public propaty name  :  DicOtherTaxRateSalesMoney
            /// <summary>その他税率別金額</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   その他税率別金額プロパティ</br>
            /// <br>Programer        :   自動生成</br>
            /// </remarks>
            public Dictionary<Double, Double> DicOtherTaxRateSalesMoney
            {
                get { return _dicOtherTaxRateSalesMoney; }
                set { _dicOtherTaxRateSalesMoney = value; }
            }

        }
        #region[金額・消費税を計算]
        /// <summary>
        /// 金額と消費税を計算
        /// </summary>
        internal class PriceTaxCalculator
        {
            internal const int ctFracProcMoneyDiv_SalesMoney = 0;
            /// <summary>端数処理対象金額区分（消費税）</summary>
            internal const int ctFracProcMoneyDiv_Tax = 1;

            private List<SalesProcMoneyWork> _salesProcMoneyWorkList;

            /// <summary>
            /// 売上金額処理区分
            /// </summary>
            public List<SalesProcMoneyWork> SalesProcMoneyWorkList
            {
                get { return _salesProcMoneyWorkList; }
                set { _salesProcMoneyWorkList = value; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public PriceTaxCalculator()
            {
                _salesProcMoneyWorkList = new List<SalesProcMoneyWork>();
            }

            /// <summary>
            /// 端数処理単位、端数処理区分取得処理
            /// </summary>
            /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
            /// <param name="fractionProcCode">端数処理コード</param>
            /// <param name="targetPrice">対象金額</param>
            /// <param name="fractionProcUnit">端数処理単位</param>
            /// <param name="fractionProcCd">端数処理区分</param>
            public void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
            {
                //-----------------------------------------------------------------------------
                // 初期値
                //-----------------------------------------------------------------------------

                switch (fracProcMoneyDiv)
                {
                    // 端数処理対象金額区分（売上単価）
                    case 2: // 単価は0.01円単位
                        fractionProcUnit = 0.01;
                        break;
                    default:
                        fractionProcUnit = 1;               // 単価以外は1円単位
                        break;
                }

                fractionProcCd = 1;     // 切捨て

                //-----------------------------------------------------------------------------
                // コード該当レコード取得
                //-----------------------------------------------------------------------------
                List<SalesProcMoneyWork> salesProcMoneyList = this._salesProcMoneyWorkList.FindAll(
                    delegate(SalesProcMoneyWork sProcMoney)
                    {
                        if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                            (sProcMoney.FractionProcCode == fractionProcCode))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                //-----------------------------------------------------------------------------
                // ソート（上限金額（昇順））
                //-----------------------------------------------------------------------------
                salesProcMoneyList.Sort(new SalesProcMoneyComparer());

                //-----------------------------------------------------------------------------
                // 上限金額該当レコード取得
                //-----------------------------------------------------------------------------
                SalesProcMoneyWork salesProcMoney = salesProcMoneyList.Find(
                    delegate(SalesProcMoneyWork spm)
                    {
                        if (spm.UpperLimitPrice >= targetPrice)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                //-----------------------------------------------------------------------------
                // 戻り値設定
                //-----------------------------------------------------------------------------
                if (salesProcMoney != null)
                {
                    fractionProcUnit = salesProcMoney.FractionProcUnit;
                    fractionProcCd = salesProcMoney.FractionProcCd;
                }
            }
            /// <summary>
            /// 売上金額処理区分マスタ比較クラス(上限金額(昇順))
            /// </summary>
            private class SalesProcMoneyComparer : Comparer<SalesProcMoneyWork>
            {
                public override int Compare(SalesProcMoneyWork x, SalesProcMoneyWork y)
                {
                    int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                    return result;
                }
            }

        }
        #endregion
        // --- ADD END   田村顕成 2022/10/18 -----<<<<<
    }
}

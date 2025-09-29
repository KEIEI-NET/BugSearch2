//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由帳票(請求書)スキーマ制御クラス
// プログラム概要   : 自由帳票(請求書)スキーマ制御クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00   作成担当 : 陳艶丹
// 作 成 日  2022/03/07    修正内容 : 請求書発行(電子帳簿連携)新規作成
//----------------------------------------------------------------------------//
// 管理番号  11870141-00   作成担当 : 田村顕成
// 作 成 日  2022/10/18    修正内容 : インボイス残対応（軽減税率対応）
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
// --- ADD START 田村顕成 2022/10/18 ----->>>>>
using Broadleaf.Application.Resources;
using System.Text.RegularExpressions;
// --- ADD END   田村顕成 2022/10/18 -----<<<<<

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 自由帳票(請求書)スキーマ制御クラス
	/// </summary>
	/// <remarks>
    /// <br>Note         : 印刷処理に渡すテーブルの生成を行います。（請求書リスト）</br>
    /// <br>               staticフィールド／メソッドをこのクラスに実装します。</br>
    /// <br>               【抽出(E)からcallします】</br>
    /// <br>               </br>
    /// <br>Programmer   : 陳艶丹</br>
    /// <br>Date         : 2022/03/07</br>
    /// <br>Update Note  : 2022/10/18 田村顕成</br>
    /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
    /// </remarks>
	public class PMKAU01002AB
    {
        # region [public static readonly メンバ]

        # region [DataSetに格納するテーブルの名称]
        /// <summary>請求書一覧テーブル</summary>
        public const string CT_Tbl_BillList = "BillList";
        # endregion

        # region [請求書本体から渡されるテーブルのcolumn]
        /// <summary>印刷フラグ</summary>
        public const string CT_CsDmd_PrintFlag = "PrintFlag";
        /// <summary>計上拠点コード</summary>
        public const string CT_CsDmd_AddUpSecCode = "AddUpSecCode";
        /// <summary>請求先コード</summary>
        public const string CT_CsDmd_ClaimCode = "ClaimCode";
        /// <summary>実績拠点コード</summary>
        public const string CT_CsDmd_ResultsSectCd = "ResultsSectCd";
        /// <summary>得意先コード</summary>
        public const string CT_CsDmd_CustomerCode = "CustomerCode";
        /// <summary>計上年月日（int）</summary>
        public const string CT_CsDmd_AddUpDateInt = "AddUpDateInt";
        /// <summary>請求書(総括)抽出データタイプ</summary>
        public const string CT_CsDmd_DataType = "DataType";
        /// <summary>総括得意先コード</summary>
        public const string CT_CsDmd_SumClaimCustCode = "SumClaimCustCode";
        # endregion

        # region [BillListテーブルのcolumn]
        /// <summary>抽出キャンセルフラグ</summary>
        public const string CT_BillList_ExtractCancel = "ExtractCancel";

        /// <summary>データタイプ(請求先ならtrue)</summary>
        public const string CT_BillList_DataType = "DataType";
        /// <summary>計上拠点コード</summary>
        public const string CT_BillList_AddUpSecCode = "AddUpSecCode";
        /// <summary>請求先コード</summary>
        public const string CT_BillList_ClaimCode = "ClaimCode";
        /// <summary>実績拠点コード</summary>
        public const string CT_BillList_ResultsSectCd = "ResultsSectCd";
        /// <summary>得意先コード</summary>
        public const string CT_BillList_CustomerCode = "CustomerCode";
        /// <summary>締日(int)</summary>
        public const string CT_BillList_AddUpDateInt = "AddUpDateInt";
        /// <summary>得意先担当者コード</summary>
        public const string CT_BillList_CustomerAgentCd = "CustomerAgentCd";
        /// <summary>集金担当者コード</summary>
        public const string CT_BillList_BillCollecterCd = "BillCollecterCd";
        /// <summary>地区コード</summary>
        public const string CT_BillList_SalesAreaCode = "SalesAreaCode";

        /// <summary></summary>
        public const string CT_BillList_FrePBillHead = "FrePBillHead";
        /// <summary></summary>
        public const string CT_BillList_FrePBillSalesList = "FrePBillSalesList";
        /// <summary></summary>
        public const string CT_BillList_FrePBillDepositList = "FrePBillDepositList";

        /// <summary></summary>
        public const string CT_BillList_DmdPrtPtn = "DmdPrtPtn";
        /// <summary></summary>
        public const string CT_BillList_FrePrtPSet = "FrePrtPSet";
        /// <summary></summary>
        public const string CT_BillList_PrtManage = "PrtManage";
        /// <summary></summary>
        public const string CT_BillList_BillAllSt = "BillAllSt";
        /// <summary></summary>
        public const string CT_BillList_BillPrtSt = "BillPrtSt";
        /// <summary></summary>
        public const string CT_BillList_AllDefSet = "AllDefSet";
        # endregion

        # endregion

        # region [private const]
        private const string ct_SectionZero = "00";
        private const string ct_WarehouseZero = "0000";
        private const int ct_CustomerZero = 0;
        private const int ct_CashRegisterZero = 0;
        // --- ADD START 田村顕成 2022/10/18 ----->>>>>
        /// <summary>
        /// 売上金額処理区分設定
        /// </summary>
        public const string CT_BillList_SalesProcMoneyWork = "SalesProcMoneyWork";
        // XML名称
        private const string ctPrintXmlFileName = "PMKAU01002A_TaxRateUserSetting.XML";
        // --- ADD END   田村顕成 2022/10/18 -----<<<<<
        # endregion

        # region [データテーブル生成]
        /// <summary>
        /// データテーブル生成処理（請求書リストテーブルスキーマ定義）
        /// </summary>
        /// <returns>データテーブル</returns>
        /// <remarks>
        /// <br>Note        : データテーブル生成処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Note       : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// <br>Programmer : 田村顕成 </br>
        /// <br>Date       : 2022/10/18</br>
        /// </remarks>
        public static DataTable CreateBillListTable()
        {
            DataTable table = new DataTable( CT_Tbl_BillList );

            // キャンセルフラグ
            table.Columns.Add( new DataColumn( CT_BillList_ExtractCancel, typeof( bool ) ) );

            // キー/ソート項目
            table.Columns.Add( new DataColumn( CT_BillList_AddUpDateInt, typeof( int ) ) ); // 計上年月日
            table.Columns.Add( new DataColumn( CT_BillList_AddUpSecCode, typeof( string ) ) ); // 計上拠点コード
            table.Columns.Add( new DataColumn( CT_BillList_ClaimCode, typeof( int ) ) ); // 請求先コード
            table.Columns.Add( new DataColumn( CT_BillList_ResultsSectCd, typeof( string ) ) ); // 実績拠点コード
            table.Columns.Add( new DataColumn( CT_BillList_CustomerCode, typeof( int ) ) ); // 得意先コード
            table.Columns.Add( new DataColumn( CT_BillList_CustomerAgentCd, typeof( string ) ) ); // 得意先担当者コード
            table.Columns.Add( new DataColumn( CT_BillList_BillCollecterCd, typeof( string ) ) ); // 集金担当者コード
            table.Columns.Add( new DataColumn( CT_BillList_SalesAreaCode, typeof( int ) ) ); // 地区コード
            // 印刷情報
            table.Columns.Add( new DataColumn( CT_BillList_FrePBillHead, typeof( EBooksFrePBillHeadWork ) ) ); // 自由帳票請求書ヘッダ（ヘッダ）
            table.Columns.Add( new DataColumn( CT_BillList_FrePBillSalesList, typeof( List<EBooksFrePBillDetailWork> ) ) ); // 自由帳票請求書明細（売上）
            table.Columns.Add( new DataColumn( CT_BillList_FrePBillDepositList, typeof( List<EBooksFrePBillDetailWork> ) ) ); // 自由帳票請求書明細（入金）
            // 設定情報
            table.Columns.Add( new DataColumn( CT_BillList_DmdPrtPtn, typeof( DmdPrtPtnWork ) ) ); // 請求書印刷パターン設定
            table.Columns.Add( new DataColumn( CT_BillList_FrePrtPSet, typeof( FrePrtPSetWork ) ) ); // 自由帳票印字位置設定
            table.Columns.Add( new DataColumn( CT_BillList_PrtManage, typeof( PrtManage ) ) ); // プリンタ管理設定
            table.Columns.Add( new DataColumn( CT_BillList_BillAllSt, typeof( BillAllStWork ) ) ); // 請求全体設定
            table.Columns.Add( new DataColumn( CT_BillList_BillPrtSt, typeof( BillPrtStWork ) ) ); // 請求印刷設定
            table.Columns.Add( new DataColumn( CT_BillList_AllDefSet, typeof( AllDefSetWork ) ) ); // 全体初期表示設定
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            table.Columns.Add(new DataColumn(CT_BillList_SalesProcMoneyWork, typeof(List<SalesProcMoneyWork>))); // 売上金額処理区分設定
            // --- ADD END   田村顕成 2022/10/18 -----<<<<<
            return table;
        }
        # endregion

        # region [データ移行（DataClass→DataTable）]
        /// <summary>
        /// データ移行処理（請求書リスト　全件コピー）
        /// </summary>
        /// <param name="table">データテーブル</param>
        /// <param name="cndtn">検索条件</param>
        /// <param name="paraWork">条件ワーク</param>
        /// <param name="printBillList">印刷請求データリスト</param>
        /// <param name="custDmdSetWorkList">得意先マスタ(請求書管理)</param>
        /// <param name="slipOutputSetWorkList">伝票出力先設定</param>
        /// <param name="dmdPrtPtnWorkList">請求書印刷パターン設定</param>
        /// <param name="frePrtPSetList">自由帳票印字位置設定</param>
        /// <param name="prtManageList">プリンター設定</param>
        /// <param name="billAllStList">請求全体設定</param>
        /// <param name="billPrtStList">請求印刷設定</param>
        /// <param name="regNo">端末番号</param>
        /// <param name="allDefSetList">全体初期値設定</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="salesProcMoneyWorkList">売上金額処理区分設定</param>
        /// <remarks>
        /// <br>Note        : 軽減税率対応</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Note       : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// <br>Programmer : 田村顕成 </br>
        /// <br>Date       : 2022/10/18</br>
        /// </remarks>
        //public static void CopyToBillListTable( ref DataTable table, object cndtn, EBooksFrePBillParaWork paraWork, ArrayList printBillList, List<CustDmdSetWork> custDmdSetWorkList, List<SlipOutputSetWork> slipOutputSetWorkList, List<DmdPrtPtnWork> dmdPrtPtnWorkList, List<FrePrtPSetWork> frePrtPSetList, List<PrtManage> prtManageList, List<BillAllStWork> billAllStList, List<BillPrtStWork> billPrtStList, List<AllDefSetWork> allDefSetList, int regNo, string sectionCode )// --- DEL 田村顕成 2022/10/18
        public static void CopyToBillListTable(ref DataTable table, object cndtn, EBooksFrePBillParaWork paraWork, ArrayList printBillList, List<CustDmdSetWork> custDmdSetWorkList, List<SlipOutputSetWork> slipOutputSetWorkList, List<DmdPrtPtnWork> dmdPrtPtnWorkList, List<FrePrtPSetWork> frePrtPSetList, List<PrtManage> prtManageList, List<BillAllStWork> billAllStList, List<BillPrtStWork> billPrtStList, List<AllDefSetWork> allDefSetList, int regNo, string sectionCode, List<SalesProcMoneyWork> salesProcMoneyWorkList)// --- ADD 田村顕成 2022/10/18
        {
            // 復号化済み自由帳票印字位置設定キーリスト
            Dictionary<string, bool> decryptedFrePrtPSetDic = new Dictionary<string, bool>();

            string enterpriseCode = paraWork.EnterpriseCode;
            int slipPrtKind = paraWork.SlipPrtKind;

            // 請求書リスト展開
            for (int index = 0; index < printBillList.Count; index++)
			{
                DataRow row = table.NewRow();

                //--------------------------------------------------------
                // 印刷情報の格納
                //--------------------------------------------------------
                
                // ※このタイミングでは完全には展開せず、データクラスのまま印刷(P)に渡します。
                //   並び替えや、空白行制御、サプレス制御など、
                //   印刷に必要な残りの処理はすべて印刷(P)に任せます。

                EBooksFrePBillHeadWork headWork = null;
                List<EBooksFrePBillDetailWork> salesList = null;
                List<EBooksFrePBillDetailWork> depositList = null;
                // --- ADD START 田村顕成 2022/10/18 ----->>>>>
                // 売上金額処理区分設定
                row[CT_BillList_SalesProcMoneyWork] = salesProcMoneyWorkList;
                // --- ADD END   田村顕成 2022/10/18 -----<<<<<
                try
                {
                    headWork = (EBooksFrePBillHeadWork)(printBillList[index] as ArrayList)[0];
                    salesList = (List<EBooksFrePBillDetailWork>)(printBillList[index] as ArrayList)[1];
                    depositList = (List<EBooksFrePBillDetailWork>)(printBillList[index] as ArrayList)[2];
                }
                catch
                {
                }

                row[CT_BillList_FrePBillHead] = headWork;
                row[CT_BillList_FrePBillSalesList] = salesList;
                row[CT_BillList_FrePBillDepositList] = depositList;

                // キャンセルフラグ
                row[CT_BillList_ExtractCancel] = false;

                //--------------------------------------------------------
                // キー情報の格納
                //--------------------------------------------------------

                row[CT_BillList_AddUpDateInt] = headWork.CUSTDMDPRCRF_ADDUPDATERF;
                row[CT_BillList_AddUpSecCode] = headWork.CUSTDMDPRCRF_ADDUPSECCODERF;
                row[CT_BillList_ClaimCode] = headWork.CUSTDMDPRCRF_CLAIMCODERF;
                row[CT_BillList_ResultsSectCd] = headWork.CUSTDMDPRCRF_RESULTSSECTCDRF;
                row[CT_BillList_CustomerCode] = headWork.CUSTDMDPRCRF_CUSTOMERCODERF;
                row[CT_BillList_CustomerAgentCd] = headWork.CSTCLM_CUSTOMERAGENTCDRF;
                row[CT_BillList_BillCollecterCd] = headWork.CSTCLM_BILLCOLLECTERCDRF;
                row[CT_BillList_SalesAreaCode] = headWork.CSTCLM_SALESAREACODERF;

                if ( cndtn is ExtrInfo_EBooksDemandTotal )
                {
                    int issueDay = GetLongDate( (cndtn as ExtrInfo_EBooksDemandTotal).IssueDay );

                    if ( issueDay < headWork.CSTCLM_CUSTAGENTCHGDATERF )
                    {
                        // 発行日＜担当者変更日ならば旧担当で書き換える
                        row[CT_BillList_CustomerAgentCd] = headWork.CSTCLM_OLDCUSTOMERAGENTCDRF;
                    }
                }

                string prtSetPaperId = string.Empty;
                prtSetPaperId = (cndtn as ExtrInfo_EBooksDemandTotal).PrtSetPaperId;

                //--------------------------------------------------------
                // 関連マスタ情報の格納
                //--------------------------------------------------------

                // 全体初期表示設定
                row[CT_BillList_AllDefSet] = SearchAllDefSet( allDefSetList, enterpriseCode, sectionCode );

                // 請求全体設定
                row[CT_BillList_BillAllSt] = SearchBillAllSt( billAllStList, enterpriseCode, sectionCode );

                // 請求印刷設定
                row[CT_BillList_BillPrtSt] = SearchBillPrtSt( billPrtStList, enterpriseCode );

                // 得意先マスタ(請求書管理)
                CustDmdSetWork custDmdSet = SearchCustDmdSet( custDmdSetWorkList, enterpriseCode, slipPrtKind, sectionCode, headWork.CUSTDMDPRCRF_CLAIMCODERF );

                if ( custDmdSet != null )
                {
                    // 請求書印刷パターン設定
                    DmdPrtPtnWork dmdPrtPtn = SearchDmdPrtPtn(dmdPrtPtnWorkList, enterpriseCode, 60, prtSetPaperId);
                    row[CT_BillList_DmdPrtPtn] = dmdPrtPtn; // ←該当なければnullが入ります

                    // 伝票出力先設定
                    if ( dmdPrtPtn != null )
                    {
                        SlipOutputSetWork slipOutputSet = SearchSlipOutputSet(slipOutputSetWorkList, enterpriseCode, sectionCode, regNo, prtSetPaperId);
                        if ( slipOutputSet != null )
                        {
                            // プリンタ管理設定
                            row[CT_BillList_PrtManage] = SearchPrtManage( prtManageList, enterpriseCode, slipOutputSet.PrinterMngNo ); // ←該当なければnullが入ります
                        }
                        else if ( prtManageList != null && prtManageList.Count > 0 )
                        {
                            // プリンタ管理設定
                            row[CT_BillList_PrtManage] = prtManageList[0];
                        }
                    }

                    // 自由帳票印字位置設定
                    FrePrtPSetWork frePrtPSet = SearchFrePrtPSet( frePrtPSetList, dmdPrtPtn );    // ←該当なければnullが入ります
                    row[CT_BillList_FrePrtPSet] = frePrtPSet;
                    if ( frePrtPSet != null )
                    {
                        if ( !decryptedFrePrtPSetDic.ContainsKey( dmdPrtPtn.OutputFormFileName) )
                        {
                            // 印字位置データを復号化する
                            //（※注意：frePrtPSet更新はfrePrtPSetListの該当レコード更新を意味します）
                            FrePrtSettingController.DecryptPrintPosClassData( frePrtPSet );
                            // 復号化済みディクショナリに追加する
                            decryptedFrePrtPSetDic.Add( dmdPrtPtn.OutputFormFileName, true );
                        }
                    }
                }
                else
                {
                    row[CT_BillList_DmdPrtPtn] = null;
                    row[CT_BillList_PrtManage] = null;
                    row[CT_BillList_FrePrtPSet] = null;
                }


                // 行追加
                table.Rows.Add( row );
            }
        }

        /// <summary>
        /// 日付LongDate取得
        /// </summary>
        /// <param name="dateTime">日付</param>
        /// <returns>int日付</returns>
        /// <remarks>
        /// <br>Note        : 日付LongDate取得を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int GetLongDate( DateTime dateTime )
        {
            if ( dateTime != DateTime.MinValue )
            {
                return (dateTime.Year * 10000) + (dateTime.Month * 100) + (dateTime.Day);
            }
            else
            {
                return 0;
            }
        }
        # endregion

        # region [マスタSearch]
        /// <summary>
        /// 全体初期表示設定　取得処理
        /// </summary>
        /// <param name="list">全体初期表示設定リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点</param>
        /// <returns>全体初期表示設定</returns>
        /// <remarks>
        /// <br>Note        : 全体初期表示設定取得を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static AllDefSetWork SearchAllDefSet( List<AllDefSetWork> list, string enterpriseCode, string sectionCode )
        {
            AllDefSetWork allDefSetWork = null;

            // 拠点別設定
            allDefSetWork = FindAllDefSetWork( list, enterpriseCode, sectionCode );
            if ( allDefSetWork != null ) return allDefSetWork;

            // 全社設定[拠点=0]
            allDefSetWork = FindAllDefSetWork( list, enterpriseCode, ct_SectionZero );
            if ( allDefSetWork != null ) return allDefSetWork;

            return null;
        }

        /// <summary>
        /// 請求書印刷パターン　取得処理
        /// </summary>
        /// <param name="list">請求書印刷パターンリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="slipPrtKind">伝票印刷種類</param>
        /// <param name="slipPrtSetPaperId">伝票印刷ID</param>
        /// <returns>請求書印刷パターン</returns>
        /// <remarks>
        /// <br>Note        : 請求書印刷パターン取得を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static DmdPrtPtnWork SearchDmdPrtPtn( List<DmdPrtPtnWork> list, string enterpriseCode, int slipPrtKind, string slipPrtSetPaperId )
        {
            if ( list == null || list.Count == 0 ) return null;

            return list.Find(
                delegate( DmdPrtPtnWork target )
                {
                    return (target.EnterpriseCode == enterpriseCode)
                            && (target.SlipPrtKind == slipPrtKind)
                            && (target.SlipPrtSetPaperId == slipPrtSetPaperId);
                }
                );
        }

        /// <summary>
        /// 自由帳票印字位置　取得処理
        /// </summary>
        /// <param name="list">リスト</param>
        /// <param name="dmdPrtPtn">印刷設定ワーク</param>
        /// <returns>自由帳票印字結果ワーク</returns>
        /// <remarks>
        /// <br>Note        : 自由帳票印字位置取得を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static FrePrtPSetWork SearchFrePrtPSet( List<FrePrtPSetWork> list, DmdPrtPtnWork dmdPrtPtn )
        {
            if ( list == null || list.Count == 0 || dmdPrtPtn == null ) return null;

            string outputFileName;
            int userPrtPprIdDerivNo;
            outputFileName = dmdPrtPtn.OutputFormFileName;
            userPrtPprIdDerivNo = 0;

            return list.Find(
                delegate( FrePrtPSetWork target )
                {
                    return (target.EnterpriseCode == dmdPrtPtn.EnterpriseCode)
                            && (target.OutputFormFileName == outputFileName)
                            && (target.UserPrtPprIdDerivNo == userPrtPprIdDerivNo);
                }
                );
        }

        /// <summary>
        /// プリンタ管理設定　取得処理
        /// </summary>
        /// <param name="list">リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="printerMngNo">管理番号</param>
        /// <returns>プリンタ管理設定結果</returns>
        /// <remarks>
        /// <br>Note        : プリンタ管理設定取得を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static PrtManage SearchPrtManage( List<PrtManage> list, string enterpriseCode, int printerMngNo )
        {
            if ( list == null || list.Count == 0 ) return null;

            return list.Find(
                delegate( PrtManage prtManage )
                {
                    return (prtManage.EnterpriseCode == enterpriseCode)
                           && (prtManage.PrinterMngNo == printerMngNo);
                }
                );
        }

        /// <summary>
        /// 得意先マスタ（請求書管理）取得処理
        /// </summary>
        /// <param name="list">得意先マスタ（請求書）設定リスト</param>
        /// <param name="enterpriseCode">>企業コード</param>
        /// <param name="slipPrtKind">伝票印刷種類</param>
        /// <param name="sectionCode">拠点</param>
        /// <param name="customerCode">得意先</param>
        /// <returns>得意先マスタ（請求書管理）結果</returns>
        /// <remarks>
        /// <br>Note        : 得意先マスタ（請求書管理）取得を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static CustDmdSetWork SearchCustDmdSet( List<CustDmdSetWork> list, string enterpriseCode, int slipPrtKind, string sectionCode, int customerCode )
        {
            CustDmdSetWork custDmdSetWork = null;

            // 得意先別設定[拠点=0]
            custDmdSetWork = FindCustDmdSetWork( list, enterpriseCode, slipPrtKind, ct_SectionZero, customerCode );
            if ( custDmdSetWork != null ) return custDmdSetWork;

            // 拠点別設定[得意先=0]
            custDmdSetWork = FindCustDmdSetWork( list, enterpriseCode, slipPrtKind, sectionCode, ct_CustomerZero );
            if ( custDmdSetWork != null ) return custDmdSetWork;

            // 全社設定[拠点=0,得意先=0]
            custDmdSetWork = FindCustDmdSetWork( list, enterpriseCode, slipPrtKind, ct_SectionZero, ct_CustomerZero );
            if ( custDmdSetWork != null ) return custDmdSetWork;

            return null;
        }

        /// <summary>
        /// 伝票出力先設定　取得処理
        /// </summary>
        /// <param name="list">list</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点</param>
        /// <param name="cashRegisterNo">端末コード</param>
        /// <param name="slipPrtSetPaperId">印刷帳票ID</param>
        /// <returns>伝票出力先設定結果</returns>
        /// <remarks>
        /// <br>Note        : 伝票出力先設定取得を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static SlipOutputSetWork SearchSlipOutputSet( List<SlipOutputSetWork> list, string enterpriseCode, string sectionCode, int cashRegisterNo, string slipPrtSetPaperId )
        {
            SlipOutputSetWork slipOutputSetWork = null;

            // レジ番号別設定[拠点=0,倉庫=0]
            slipOutputSetWork = FindSlipOutputSetWork( list, enterpriseCode, ct_SectionZero, ct_WarehouseZero, cashRegisterNo, slipPrtSetPaperId );
            if ( slipOutputSetWork != null ) return slipOutputSetWork;

            // 拠点別設定[倉庫=0,レジ番号=0]
            slipOutputSetWork = FindSlipOutputSetWork( list, enterpriseCode, sectionCode, ct_WarehouseZero, ct_CashRegisterZero, slipPrtSetPaperId );
            if ( slipOutputSetWork != null ) return slipOutputSetWork;

            // 全社設定[拠点=0,倉庫=0,レジ番号=0]
            slipOutputSetWork = FindSlipOutputSetWork( list, enterpriseCode, ct_SectionZero, ct_WarehouseZero, ct_CashRegisterZero, slipPrtSetPaperId );
            if ( slipOutputSetWork != null ) return slipOutputSetWork;

            return null;
        }
        /// <summary>
        /// 請求全体設定　取得処理
        /// </summary>
        /// <param name="list">請求全体設定リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点</param>
        /// <returns>請求全体設定結果</returns>
        /// <remarks>
        /// <br>Note        : 請求全体設定取得を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static BillAllStWork SearchBillAllSt( List<BillAllStWork> list, string enterpriseCode, string sectionCode )
        {
            BillAllStWork billAllStWork = null;

            // 拠点毎
            billAllStWork = FindBillAllStWork( list, enterpriseCode, sectionCode );
            if ( billAllStWork != null ) return billAllStWork;

            // 全社
            billAllStWork = FindBillAllStWork( list, enterpriseCode, ct_SectionZero );
            if ( billAllStWork != null ) return billAllStWork;

            return null;
        }

        /// <summary>
        /// 請求印刷設定　取得処理
        /// </summary>
        /// <param name="list">請求印刷設定リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>請求印刷設定結果</returns>
        /// <remarks>
        /// <br>Note        : 請求印刷設定取得を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static BillPrtStWork SearchBillPrtSt( List<BillPrtStWork> list, string enterpriseCode )
        {
            BillPrtStWork billPrtStWork = null;

            // 全社設定
            billPrtStWork = FindBillPrtStWork( list, enterpriseCode );
            if ( billPrtStWork != null ) return billPrtStWork;

            return null;
        }

        /// <summary>
        /// 得意先マスタ（請求書管理）取得処理
        /// </summary>
        /// <param name="list">得意先マスタ(請求書管理)設定リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="slipPrtKind">印刷種類</param>
        /// <param name="sectionCode">拠点</param>
        /// <param name="customerCode">得意先</param>
        /// <returns>得意先マスタ（請求書管理）結果</returns>
        /// <remarks>
        /// <br>Note        : 得意先マスタ（請求書管理）取得を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static CustDmdSetWork FindCustDmdSetWork( List<CustDmdSetWork> list, string enterpriseCode, int slipPrtKind, string sectionCode, int customerCode )
        {
            if ( list == null || list.Count == 0 ) return null;

            return list.Find(
                delegate( CustDmdSetWork target )
                {
                    return (target.EnterpriseCode.TrimEnd() == enterpriseCode.TrimEnd())
                            && (target.SlipPrtKind == slipPrtKind)
                            && ((target.SectionCode.TrimEnd() == sectionCode.TrimEnd()) ||
                                (target.SectionCode.TrimEnd() == string.Empty) && (sectionCode == ct_SectionZero))
                            && (target.CustomerCode == customerCode);
                }
                );
        }

        /// <summary>
        /// 伝票出力先設定　取得処理
        /// </summary>
        /// <param name="list">伝票出力先設定リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点</param>
        /// <param name="warehouseCode">倉庫</param>
        /// <param name="cashRegisterNo">端末コード</param>
        /// <param name="slipPrtSetPaperId">印刷帳票ID</param>
        /// <returns>伝票出力先設定結果</returns>
        /// <remarks>
        /// <br>Note        : 伝票出力先設定取得を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static SlipOutputSetWork FindSlipOutputSetWork( List<SlipOutputSetWork> list, string enterpriseCode, string sectionCode, string warehouseCode, int cashRegisterNo, string slipPrtSetPaperId )
        {
            if ( list == null || list.Count == 0 ) return null;

            return list.Find(
                delegate( SlipOutputSetWork target )
                {
                    return (target.EnterpriseCode.TrimEnd() == enterpriseCode.TrimEnd())
                        //&& (target.SectionCode == sectionCode)
                            && ((target.WarehouseCode.TrimEnd() == warehouseCode.TrimEnd()) ||
                                ( target.WarehouseCode.TrimEnd() == string.Empty ) && (warehouseCode == ct_WarehouseZero))
                            && (target.CashRegisterNo == cashRegisterNo)
                            && (target.SlipPrtSetPaperId.TrimEnd() == slipPrtSetPaperId.TrimEnd());
                }
                );
        }

        /// <summary>
        /// 請求全体設定
        /// </summary>
        /// <param name="list">請求全体設定リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点</param>
        /// <returns>請求全体設定結果</returns>
        /// <remarks>
        /// <br>Note        : 請求全体設定取得を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static BillAllStWork FindBillAllStWork( List<BillAllStWork> list, string enterpriseCode, string sectionCode )
        {
            if ( list == null || list.Count == 0 ) return null;

            return list.Find(
                delegate( BillAllStWork target )
                {
                    return (target.EnterpriseCode.TrimEnd() == enterpriseCode.TrimEnd() &&
                            ((target.SectionCode.TrimEnd() == sectionCode.TrimEnd()) ||
                              ((target.SectionCode.TrimEnd() == string.Empty) && (sectionCode == ct_SectionZero))));
                }
                );
        }

        /// <summary>
        /// 請求印刷設定
        /// </summary>
        /// <param name="list">請求印刷設定リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>請求印刷設定結果</returns>
        /// <remarks>
        /// <br>Note        : 請求印刷設定取得を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static BillPrtStWork FindBillPrtStWork( List<BillPrtStWork> list, string enterpriseCode )
        {
            if ( list == null || list.Count == 0 ) return null;

            return list.Find(
                delegate( BillPrtStWork target )
                {
                    return (target.EnterpriseCode.TrimEnd() == enterpriseCode.TrimEnd());
                }
                );

        }

        /// <summary>
        /// 全体初期表示設定
        /// </summary>
        /// <param name="list">全体初期値設定リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点</param>
        /// <returns>全体初期表示設定結果</returns>
        /// <remarks>
        /// <br>Note        : 請求印刷設定取得を行う。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static AllDefSetWork FindAllDefSetWork( List<AllDefSetWork> list, string enterpriseCode, string sectionCode )
        {
            if ( list == null || list.Count == 0 ) return null;

            return list.Find(
                delegate( AllDefSetWork target )
                {
                    return (target.EnterpriseCode.TrimEnd() == enterpriseCode.TrimEnd() &&
                            ((target.SectionCode.TrimEnd() == sectionCode.TrimEnd()) ||
                              ((target.SectionCode.TrimEnd() == string.Empty) && (sectionCode == ct_SectionZero))));
                }
                );
        }
        # endregion

        // --- ADD START 田村顕成 2022/10/18 ----->>>>>
        # region [印刷用税率情報XML]
        /// <summary>
        /// 印刷用税率情報
        /// </summary>
        /// <remarks> 
        /// </remarks>
        public class TaxRatePrintInfo
        {
            /// <summary>印刷用税率設定情報税率１</summary>
            private string _taxRate1;
            /// <summary>印刷用税率設定情報税率２</summary>
            private string _taxRate2;

            /// <summary>印刷用税率設定情報税率１</summary>
            public string TaxRate1
            {
                get { return _taxRate1; }
                set { _taxRate1 = value; }
            }

            /// <summary>印刷用税率設定情報税率２</summary>
            public string TaxRate2
            {
                get { return _taxRate2; }
                set { _taxRate2 = value; }
            }
        }
        # endregion

        # region[デシリアライズ処理]
        /// <summary>
        /// デシリアライズ処理
        /// </summary>
        /// <returns>デシリアライズ結果</returns>
        /// <remarks> 
        /// </remarks>
        public static Int32 Deserialize(out TaxRatePrintInfo taxRatePrintInfo, out String errmsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;

            errmsg = string.Empty;
            taxRatePrintInfo = null;

            // 印刷用税率情報XMLファイル存在の判断
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrintXmlFileName)))
            {
                try
                {
                    taxRatePrintInfo = UserSettingController.DeserializeUserSetting<TaxRatePrintInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctPrintXmlFileName));
                    // 税率設定情報税率１
                    double dTaxRate1 = -1;
                    Boolean bTaxRate1 = double.TryParse(taxRatePrintInfo.TaxRate1, out dTaxRate1);
                    // 税率設定情報税率２
                    double dTaxRate2 = -1;
                    Boolean bTaxRate2 = double.TryParse(taxRatePrintInfo.TaxRate2, out dTaxRate2);

                    // 税率未設定の場合、
                    if ((taxRatePrintInfo.TaxRate1 == string.Empty) || (taxRatePrintInfo.TaxRate2 == string.Empty) ||
                        // 同じ税率値の場合
                        (taxRatePrintInfo.TaxRate1 == taxRatePrintInfo.TaxRate2) ||
                        // 数字以外の場合、
                        (!bTaxRate1) || (!bTaxRate2) ||
                        // 税率値はマイナスの場合
                        (dTaxRate1 < 0) || (dTaxRate2 < 0) ||
                        // 税率値は10以上の場合
                        (dTaxRate1 >= 10) || (dTaxRate2 >= 10))
                    {
                        errmsg = "税率設定情報が正しく設定されていません。";
                        return status;
                    }

                }
                catch (System.InvalidOperationException)
                {
                    errmsg = "税率設定情報が正しく設定されていません。";
                    return status;
                }
            }
            else
            {
                errmsg = "税率設定情報ファイル(" + ctPrintXmlFileName + ")が存在しません。";
                return status;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL; ;
        }
        # endregion        
        // --- ADD END   田村顕成 2022/10/18 -----<<<<<
    }
}

using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
//using System.Windows.Forms;
//using System.Drawing.Printing;
using System.Collections.Generic;

//using ar=DataDynamics.ActiveReports;
//using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
//using Broadleaf.Library.Windows.Forms;
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
	/// <br>Programmer   : 22018 鈴木　正臣</br>
	/// <br>Date         : 2008.06.17</br>
	/// <br></br>
	/// <br>Update Note  : 2010.01.06  22018 鈴木 正臣</br>
    /// <br>             : MANTIS 0014863 対応</br>
    /// <br>             : 復号化済みディクショナリにセットするKEYをOutputFormFileNameに修正。</br>
    /// <br></br>
    /// <br>Update Note  : 2010.02.15  22018 鈴木 正臣</br>
    /// <br>             : 請求書(総括)対応</br>
    /// <br>Update Note  : 2022/10/18 田村顕成</br>
    /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
    /// </remarks>
	public class PMKAU08002AB
    {
        # region [public static readonly メンバ]

        # region [DataSetに格納するテーブルの名称]
        /// <summary>請求書一覧テーブル</summary>
        public const string CT_Tbl_BillList = "BillList";
        ///// <summary>各種設定テーブル</summary>
        //public const string CT_Tbl_Settings = "Settings";
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
        // --- ADD m.suzuki 2010/02/18 ---------->>>>>
        /// <summary>請求書(総括)抽出データタイプ</summary>
        public const string CT_CsDmd_DataType = "DataType";
        /// <summary>総括得意先コード</summary>
        public const string CT_CsDmd_SumClaimCustCode = "SumClaimCustCode";
        // --- ADD m.suzuki 2010/02/18 ----------<<<<<
        # endregion

        # region [BillListテーブルのcolumn]
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
        /// <summary>抽出キャンセルフラグ</summary>
        public const string CT_BillList_ExtractCancel = "ExtractCancel";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD

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

        //# region [Settingsテーブルのcolumn]
        ///// <summary>請求全体設定</summary>
        //public const string CT_Settings_BillAllSt = "BillAllSt";
        //# endregion

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
        private const string ctPrintXmlFileName = "PMKAU08002A_TaxRateUserSetting.XML";
        // --- ADD END   田村顕成 2022/10/18 -----<<<<<
        # endregion

        # region [データテーブル生成]
        /// <summary>
        /// データテーブル生成処理（請求書リストテーブルスキーマ定義）
        /// </summary>
        /// <returns></returns>
        /// <br>Note       : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// <br>Programmer : 田村顕成 </br>
        /// <br>Date       : 2022/10/18</br>
        public static DataTable CreateBillListTable()
        {
            DataTable table = new DataTable( CT_Tbl_BillList );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
            // キャンセルフラグ
            table.Columns.Add( new DataColumn( CT_BillList_ExtractCancel, typeof( bool ) ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD

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
            table.Columns.Add( new DataColumn( CT_BillList_FrePBillHead, typeof( FrePBillHeadWork ) ) ); // 自由帳票請求書ヘッダ（ヘッダ）
            table.Columns.Add( new DataColumn( CT_BillList_FrePBillSalesList, typeof( List<FrePBillDetailWork> ) ) ); // 自由帳票請求書明細（売上）
            table.Columns.Add( new DataColumn( CT_BillList_FrePBillDepositList, typeof( List<FrePBillDetailWork> ) ) ); // 自由帳票請求書明細（入金）
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
        ///// <summary>
        ///// データテーブル生成処理（各種設定テーブルスキーマ定義）
        ///// </summary>
        ///// <returns></returns>
        //public static DataTable CreateSettingsTable()
        //{
        //    DataTable table = new DataTable( CT_Tbl_Settings );

        //    table.Columns.Add( new DataColumn( CT_Settings_BillAllSt, typeof( BillAllStWork ) ) );  // 請求全体設定

        //    return table;
        //}
        # endregion

        # region [データ移行（DataClass→DataTable）]
        /// <summary>
        /// データ移行処理（請求書リスト　全件コピー）
        /// </summary>
        /// <param name="table"></param>
        /// <param name="cndtn"></param>
        /// <param name="paraWork"></param>
        /// <param name="printBillList"></param>
        /// <param name="custDmdSetWorkList"></param>
        /// <param name="slipOutputSetWorkList"></param>
        /// <param name="dmdPrtPtnWorkList"></param>
        /// <param name="frePrtPSetList"></param>
        /// <param name="prtManageList"></param>
        /// <param name="billAllStList"></param>
        /// <param name="billPrtStList"></param>
        /// <param name="regNo"></param>
        /// <param name="allDefSetList"></param>
        /// <param name="sectionCode"></param>
        /// <param name="salesProcMoneyWorkList"></param>
        /// <br>Note       : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// <br>Programmer : 田村顕成 </br>
        /// <br>Date       : 2022/10/18</br>
        //public static void CopyToBillListTable( ref DataTable table, object cndtn, FrePBillParaWork paraWork, ArrayList printBillList, List<CustDmdSetWork> custDmdSetWorkList, List<SlipOutputSetWork> slipOutputSetWorkList, List<DmdPrtPtnWork> dmdPrtPtnWorkList, List<FrePrtPSetWork> frePrtPSetList, List<PrtManage> prtManageList, List<BillAllStWork> billAllStList, List<BillPrtStWork> billPrtStList, List<AllDefSetWork> allDefSetList, int regNo, string sectionCode )// --- DEL 田村顕成 2022/10/18
        public static void CopyToBillListTable(ref DataTable table, object cndtn, FrePBillParaWork paraWork, ArrayList printBillList, List<CustDmdSetWork> custDmdSetWorkList, List<SlipOutputSetWork> slipOutputSetWorkList, List<DmdPrtPtnWork> dmdPrtPtnWorkList, List<FrePrtPSetWork> frePrtPSetList, List<PrtManage> prtManageList, List<BillAllStWork> billAllStList, List<BillPrtStWork> billPrtStList, List<AllDefSetWork> allDefSetList, int regNo, string sectionCode, List<SalesProcMoneyWork> salesProcMoneyWorkList)     // --- ADD 田村顕成 2022/10/18
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

                FrePBillHeadWork headWork = null;
                List<FrePBillDetailWork> salesList = null;
                List<FrePBillDetailWork> depositList = null;
                // --- ADD START 田村顕成 2022/10/18 ----->>>>>
                // 売上金額処理区分設定
                row[CT_BillList_SalesProcMoneyWork] = salesProcMoneyWorkList;
                // --- ADD END   田村顕成 2022/10/18 -----<<<<<
                try
                {
                    headWork = (FrePBillHeadWork)(printBillList[index] as ArrayList)[0];
                    salesList = (List<FrePBillDetailWork>)(printBillList[index] as ArrayList)[1];
                    depositList = (List<FrePBillDetailWork>)(printBillList[index] as ArrayList)[2];
                }
                catch
                {
                }

                row[CT_BillList_FrePBillHead] = headWork;
                row[CT_BillList_FrePBillSalesList] = salesList;
                row[CT_BillList_FrePBillDepositList] = depositList;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
                // キャンセルフラグ
                row[CT_BillList_ExtractCancel] = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD

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

                if ( cndtn is ExtrInfo_DemandTotal )
                {
                    int issueDay = GetLongDate( (cndtn as ExtrInfo_DemandTotal).IssueDay );

                    if ( issueDay < headWork.CSTCLM_CUSTAGENTCHGDATERF )
                    {
                        // 発行日＜担当者変更日ならば旧担当で書き換える
                        row[CT_BillList_CustomerAgentCd] = headWork.CSTCLM_OLDCUSTOMERAGENTCDRF;
                    }
                }
                // --- ADD m.suzuki 2010/02/18 ---------->>>>>
                else if ( cndtn is SumExtrInfo_DemandTotal )
                {
                    int issueDay = GetLongDate( (cndtn as SumExtrInfo_DemandTotal).IssueDay );

                    if ( issueDay < headWork.CSTCLM_CUSTAGENTCHGDATERF )
                    {
                        // 発行日＜担当者変更日ならば旧担当で書き換える
                        row[CT_BillList_CustomerAgentCd] = headWork.CSTCLM_OLDCUSTOMERAGENTCDRF;
                    }
                }
                // --- ADD m.suzuki 2010/02/18 ----------<<<<<

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
                    DmdPrtPtnWork dmdPrtPtn = SearchDmdPrtPtn( dmdPrtPtnWorkList, enterpriseCode, custDmdSet.SlipPrtKind, custDmdSet.SlipPrtSetPaperId );
                    row[CT_BillList_DmdPrtPtn] = dmdPrtPtn; // ←該当なければnullが入ります

                    // 伝票出力先設定
                    if ( dmdPrtPtn != null )
                    {
                        SlipOutputSetWork slipOutputSet = SearchSlipOutputSet( slipOutputSetWorkList, enterpriseCode, sectionCode, regNo, custDmdSet.SlipPrtSetPaperId );
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
                        // --- UPD m.suzuki 2010/01/06 ---------->>>>>
                        //if ( !decryptedFrePrtPSetDic.ContainsKey( dmdPrtPtn.SlipPrtSetPaperId ) )
                        if ( !decryptedFrePrtPSetDic.ContainsKey( dmdPrtPtn.OutputFormFileName) )
                        // --- UPD m.suzuki 2010/01/06 ----------<<<<<
                        {
                            // 印字位置データを復号化する
                            //（※注意：frePrtPSet更新はfrePrtPSetListの該当レコード更新を意味します）
                            FrePrtSettingController.DecryptPrintPosClassData( frePrtPSet );
                            // 復号化済みディクショナリに追加する
                            // --- UPD m.suzuki 2010/01/06 ---------->>>>>
                            //decryptedFrePrtPSetDic.Add( dmdPrtPtn.SlipPrtSetPaperId, true );
                            decryptedFrePrtPSetDic.Add( dmdPrtPtn.OutputFormFileName, true );
                            // --- UPD m.suzuki 2010/01/06 ----------<<<<<
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
        /// <param name="dateTime"></param>
        /// <returns></returns>
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
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
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
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="slipPrtKind"></param>
        /// <param name="slipPrtSetPaperId"></param>
        /// <returns></returns>
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
        /// <param name="list"></param>
        /// <param name="dmdPrtPtn"></param>
        /// <returns></returns>
        public static FrePrtPSetWork SearchFrePrtPSet( List<FrePrtPSetWork> list, DmdPrtPtnWork dmdPrtPtn )
        {
            if ( list == null || list.Count == 0 || dmdPrtPtn == null ) return null;

            string outputFileName;
            int userPrtPprIdDerivNo;
            // --- UPD m.suzuki 2010/01/06 ---------->>>>>
            //GetFrePrtPSetReadKey( dmdPrtPtn, out outputFileName, out userPrtPprIdDerivNo );
            outputFileName = dmdPrtPtn.OutputFormFileName;
            userPrtPprIdDerivNo = 0;
            // --- UPD m.suzuki 2010/01/06 ----------<<<<<

            return list.Find(
                delegate( FrePrtPSetWork target )
                {
                    return (target.EnterpriseCode == dmdPrtPtn.EnterpriseCode)
                            && (target.OutputFormFileName == outputFileName)
                            && (target.UserPrtPprIdDerivNo == userPrtPprIdDerivNo);
                }
                );
        }
        // --- DEL m.suzuki 2010/01/06 ---------->>>>>
        ///// <summary>
        ///// 自由帳票印字位置設定 読み込みキー情報取得
        ///// </summary>
        ///// <param name="dmdPrtPtn"></param>
        ///// <param name="outputFormFileName"></param>
        ///// <param name="userPrtPprIdDerivNo"></param>
        //private static void GetFrePrtPSetReadKey( DmdPrtPtnWork dmdPrtPtn, out string outputFormFileName, out int userPrtPprIdDerivNo )
        //{
        //    outputFormFileName = dmdPrtPtn.OutputFormFileName;
        //    userPrtPprIdDerivNo = 0;

        //    if ( dmdPrtPtn.SlipPrtSetPaperId.StartsWith( dmdPrtPtn.OutputFormFileName ) )
        //    {
        //        string derivNoText = dmdPrtPtn.SlipPrtSetPaperId.Substring( dmdPrtPtn.OutputFormFileName.Length, dmdPrtPtn.SlipPrtSetPaperId.Length - dmdPrtPtn.OutputFormFileName.Length );
        //        try
        //        {
        //            userPrtPprIdDerivNo = Int32.Parse( derivNoText );
        //        }
        //        catch
        //        {
        //            userPrtPprIdDerivNo = 0;
        //        }
        //    }
        //}
        // --- DEL m.suzuki 2010/01/06 ----------<<<<<
        /// <summary>
        /// プリンタ管理設定　取得処理
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="printerMngNo"></param>
        /// <returns></returns>
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
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="slipPrtKind"></param>
        /// <param name="sectionCode"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
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
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="cashRegisterNo"></param>
        /// <param name="slipPrtSetPaperId"></param>
        /// <returns></returns>
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
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
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
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private static BillPrtStWork SearchBillPrtSt( List<BillPrtStWork> list, string enterpriseCode )
        {
            BillPrtStWork billPrtStWork = null;

            // 全社設定
            billPrtStWork = FindBillPrtStWork( list, enterpriseCode );
            if ( billPrtStWork != null ) return billPrtStWork;

            return null;
        }

        /// <summary>
        /// find 得意先マスタ（請求書管理）
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="slipPrtKind"></param>
        /// <param name="sectionCode"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
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
        /// find 伝票出力先設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="warehouseCode"></param>
        /// <param name="cashRegisterNo"></param>
        /// <param name="slipPrtSetPaperId"></param>
        /// <returns></returns>
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
        /// find 請求全体設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
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
        /// find 請求印刷設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
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
        /// find 全体初期表示設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
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

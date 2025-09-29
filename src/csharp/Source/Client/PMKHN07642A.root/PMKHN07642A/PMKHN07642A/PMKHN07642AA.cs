//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 得意先マスタ（インポート）
// プログラム概要   : 得意先マスタ（インポート）アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 作 成 日  2010/02/01  修正内容 : MANTIS対応[14952]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 修 正 日  2012/06/12  修正内容 : 10801804-00 大陽案件、Redmine#30393 
//                                  得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/03  修正内容 ：10801804-00 大陽案件、Redmine#30393 
//                                  得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加の改良
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/09  修正内容 ：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.46の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/11  修正内容 ：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.62の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/13  修正内容 ：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.7の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/20  修正内容 ：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.108の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 得意先マスタ（インポート）アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ（インポート）で使用するデータを取得する。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br>Update Note: 2012/06/12 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
    /// <br>Update Note: 2012/07/03 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加の改良</br>
    /// <br>Update Note: 2012/07/09 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.46の対応</br>
    /// <br>Update Note: 2012/07/11 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.62の対応</br>
    /// <br>Update Note: 2012/07/13 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.7の対応</br>
    /// <br>Update Note: 2012/07/20 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.108の対応</br>
    /// </remarks>
    public class CustomerImportAcs
    {
        #region ■ Constructor
		/// <summary>
        /// 得意先マスタ（インポート）アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 得意先マスタ（インポート）アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 劉学智</br>
	    /// <br>Date       : 2009.05.13</br>
        /// </remarks>
		public CustomerImportAcs()
		{
            this._iCustomerImportDB = (ICustomerImportDB)MediationCustomerImportDB.GetCustomerImportDB();
        }

		/// <summary>
        /// 得意先マスタ（インポート）アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 得意先マスタ（インポート）アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static CustomerImportAcs()
		{
		}
		#endregion ■ Constructor

        #region ■ Private Member
        // 得意先マスタ（インポート）のリモートインタフェース
        private ICustomerImportDB _iCustomerImportDB;
        private const string ERROR_LOG_FILENAME = "PMKHN07100U_ERRORLOG.xml";// ADD  2012/06/12  李亜博 Redmine#30393
        #endregion ■ Private Member

        #region ■ Public Method
        #region ◎ インポート処理
        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="importWorkTbl">インポートワーク</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="logCnt">エラーログ件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（インポート）処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.13</br>
        /// <br>Update Note: 2012/06/12 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
        /// </remarks>
        //public int Import(ExtrInfo_CustomerImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)// DEL  2012/06/12  李亜博 Redmine#30393
        public int Import(ExtrInfo_CustomerImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out string errMsg)// ADD  2012/06/12  李亜博 Redmine#30393 
        {
           //return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out errMsg);// DEL  2012/06/12  李亜博 Redmine#30393
            return this.ImportProc(importWorkTbl, out readCnt, out addCnt, out updCnt, out logCnt, out errMsg);// ADD  2012/06/12  李亜博 Redmine#30393	
        }
        #endregion
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◎ 得意先マスタ（インポート）のインポート処理
        /// <summary>
        /// インポート処理
        /// </summary>
        /// <param name="importWorkTbl">インポートワーク</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="logCnt">エラーログ件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（インポート）処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.13</br>
        /// <br>Update Note: 2012/06/12 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
        /// <br>Update Note: 2012/07/03 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加の改良</br>
        /// <br>Update Note: 2012/07/11 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.62の対応</br>
        /// <br>Update Note: 2012/07/13 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.7の対応</br>
        /// <br>Update Note: 2012/07/20 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.108の対応</br>
        /// </remarks>
        //private int ImportProc(ExtrInfo_CustomerImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out string errMsg)// DEL  2012/06/12  李亜博 Redmine#30393
        private int ImportProc(ExtrInfo_CustomerImportWorkTbl importWorkTbl, out Int32 readCnt, out Int32 addCnt, out Int32 updCnt, out Int32 logCnt, out string errMsg)// ADD  2012/06/12  李亜博 Redmine#30393 
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            readCnt = 0;
            addCnt = 0;
            updCnt = 0;
            errMsg = string.Empty;
            // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
            DataTable logTable = new DataTable();
            //ArrayList logList = new ArrayList();// ADD  2012/07/03  李亜博 Redmine#30393// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
            object logList = null;// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
            logCnt = 0;
            // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
            try
            {
                //ArrayList importWorkList = null;// DEL  2012/06/12  李亜博 Redmine#30393
                // インポートワークの変換処理
                //status = ConvertToImportWorkList(importWorkTbl, out importWorkList, out errMsg);// DEL  2012/06/12  李亜博 Redmine#30393
                // --------------- ADD START 2012/07/03 Redmine#30393 李亜博-------->>>>
                ArrayList importWorkList = null;
                 //インポートワークの変換処理
                status = ConvertToImportWorkArrayList(importWorkTbl, out importWorkList, out errMsg);
                // --------------- ADD END 2012/07/03 Redmine#30393 李亜博--------<<<<

                // --------------- DEL START 2012/07/03 Redmine#30393 李亜博-------->>>>
                // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
                //DataTable dataTable = new DataTable();
                // CreateDataTable(ref dataTable);
                //status = ConvertToDataTable(ref dataTable, importWorkTbl, out errMsg);
                // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
                // --------------- DEL END 2012/07/03 Redmine#30393 李亜博--------<<<<
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    //Object objImportWorkList = (object)importWorkList;// DEL  2012/06/12  李亜博 Redmine#30393
                    //Object objImportWorkTable = (object)dataTable;// // ADD  2012/06/12  李亜博 Redmine#30393 // DEL  2012/07/03  李亜博 Redmine#30393
                    Object objImportWorkList = (object)importWorkList;// ADD  2012/07/03  李亜博 Redmine#30393
                    // リモートクラスを呼び出す。
                    // status = this._iCustomerImportDB.Import(importWorkTbl.ProcessKbn, ref objImportWorkList, out readCnt, out addCnt, out updCnt, out errMsg);// DEL  2012/06/12  李亜博 Redmine#30393
                    //status = this._iCustomerImportDB.Import(importWorkTbl.ProcessKbn, ref objImportWorkTable, out readCnt, out addCnt, out updCnt, out logCnt, out logTable, importWorkTbl.EnterpriseCode, out errMsg);// ADD  2012/06/12  李亜博 Redmine#30393 // DEL  2012/07/03  李亜博 Redmine#30393

                    // ------ ADD START 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.62の対応-------->>>>
                     CustomerInputAcs cust = new CustomerInputAcs();
                     Int32 consTaxLay = cust.GetConsTaxLayMethod(importWorkTbl.EnterpriseCode, 0); // 税率マスタから消費税転嫁方式を取得
                    // ------ ADD END 2012/07/11 Redmine#30393 李亜博 for 障害一覧の指摘NO.62の対応--------<<<<

                     //status = this._iCustomerImportDB.Import(importWorkTbl.ProcessKbn, ref objImportWorkList, out readCnt, out addCnt, out updCnt, out logCnt, out logList, importWorkTbl.EnterpriseCode, out errMsg);// ADD  2012/07/03  李亜博 Redmine#30393 // DEL  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応
                     //status = this._iCustomerImportDB.Import(importWorkTbl.ProcessKbn, consTaxLay, ref objImportWorkList, out readCnt, out addCnt, out updCnt, out logCnt, out logList, importWorkTbl.EnterpriseCode, out errMsg);// ADD  2012/07/11  李亜博 Redmine#30393 for 障害一覧の指摘NO.62の対応 // DEL  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                     status = this._iCustomerImportDB.Import(importWorkTbl.ProcessKbn,importWorkTbl.CheckKbn, consTaxLay, ref objImportWorkList, out readCnt, out addCnt, out updCnt, out logCnt, out logList, importWorkTbl.EnterpriseCode, out errMsg);// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                    // --------------- ADD START 2012/07/03 Redmine#30393 李亜博-------->>>>
                    CreateDataTable(ref logTable);
                    //foreach (CustomerGroupWork customerGroupWork in logList)// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
                    // ------ ADD START 2012/07/13 Redmine#30393 李亜博 for 障害一覧の指摘NO.7の対応-------->>>>
                    ArrayList logArrayList = new ArrayList();
                    logArrayList = logList as ArrayList;
                    foreach (CustomerGroupWork customerGroupWork in logArrayList)
                    // ------ ADD END 2012/07/13 Redmine#30393 李亜博 for 障害一覧の指摘NO.7の対応--------<<<<
                    {
                        //ConverToDataSetCustomerLog(customerGroupWork, ref logTable);// DEL  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
                        // ------ ADD START 2012/07/13 Redmine#30393 李亜博 for 障害一覧の指摘NO.7の対応-------->>>>
                        if (!string.IsNullOrEmpty(customerGroupWork.ErrorLog.Trim()))
                        {
                        ConverToDataSetCustomerLog(customerGroupWork, ref logTable);
                        }
                        // ------ ADD END 2012/07/13 Redmine#30393 李亜博 for 障害一覧の指摘NO.7の対応--------<<<<
                    }
                    // --------------- ADD END 2012/07/03 Redmine#30393 李亜博--------<<<<
                    // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
                    if (logTable.Rows.Count > 0)
                    {
                        this.DoOutPut(importWorkTbl.ErrorLogFileName, logTable);
                    }
                    // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
        /// <summary>
        /// インポートワークの変換処理
        /// </summary>
        /// <param name="importWorkTbl">UI抽出条件クラス</param>
        /// <param name="dataTable">インポートテーブル</param>
        /// <param name="errMsg">エラー情報</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : インポートワークの変換処理を行う。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private int ConvertToDataTable(ref DataTable dataTable, ExtrInfo_CustomerImportWorkTbl importWorkTbl, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            DataRow row = null;
            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    row = dataTable.NewRow();
                    row.ItemArray = csvDataArr;
                    dataTable.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion
      
        /// <summary>
        /// CSV出力処理
        /// </summary>
        /// <param name="errorLogFileName">エラーログファイル名</param>
        /// <param name="logTable">データテーブル</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV出力処理を行う。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/06/12</br>
        /// </remarks>
        private int DoOutPut(string errorLogFileName, DataTable logTable)
        {
            int status = 0;

            SFCMN06002C printInfo = new SFCMN06002C();
            printInfo.prpid = ERROR_LOG_FILENAME;
            printInfo.pdfopen = false;
            printInfo.pdftemppath = "";

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return -1;
            }
            CustomTextProviderInfo customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            CustomTextWriter customTextWriter = new CustomTextWriter();
            // 出力パスと名前
            customTextProviderInfo.OutPutFileName = errorLogFileName;

            // 上書き／追加フラグをセット(true:追加する、false:上書きする)
            customTextProviderInfo.AppendMode = false;
            // スキーマ取得
            customTextProviderInfo.SchemaFileName = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, printInfo.prpid);
            // データソースを設定
            DataSet dsOutData = new DataSet();
            DataView dv = logTable.DefaultView;
            dsOutData.Tables.Add(dv.ToTable());

            try
            {
                status = customTextWriter.WriteText(dsOutData, customTextProviderInfo.SchemaFileName, customTextProviderInfo.OutPutFileName, customTextProviderInfo);
            }
            catch
            {
                status = -1;
            }
            dsOutData.Tables.Clear();

            return status;
        }

    
        /// <summary>
        /// エラーログテーブル
        /// </summary>
        /// <param name="dataTable">テーブル</param>
        /// <remarks>
        /// <br>Note	   : エラーログテーブルを行う。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/06/12</br>
        /// <br>Update Note: 2012/07/09 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.46の対応</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("CustomerCodeRF", typeof(string));           //  得意先コード
            dataTable.Columns.Add("CustomerSubCodeRF", typeof(string));	      //  得意先サブコード
            dataTable.Columns.Add("NameRF", typeof(string));	              //  名称
            dataTable.Columns.Add("Name2RF", typeof(string));	              //  名称2
            dataTable.Columns.Add("CustomerSnmRF", typeof(string));	          //  得意先略称
            dataTable.Columns.Add("KanaRF", typeof(string));	              //  カナ
            dataTable.Columns.Add("HonorificTitleRF", typeof(string));	      //  敬称
            dataTable.Columns.Add("OutputNameCodeRF", typeof(string));	      //  諸口コード
            dataTable.Columns.Add("MngSectionCodeRF", typeof(string));	      //  管理拠点コード
            dataTable.Columns.Add("CustomerAgentCdRF", typeof(string));	      //  顧客担当従業員コード
            dataTable.Columns.Add("OldCustomerAgentCdRF", typeof(string));	  //  旧顧客担当従業員コード
            dataTable.Columns.Add("CustAgentChgDateRF", typeof(string));       //  顧客担当変更日
            dataTable.Columns.Add("TransStopDateRF", typeof(string));	      //  取引中止日	
            dataTable.Columns.Add("CarMngDivCdRF", typeof(string));	          //  車輌管理区分
            dataTable.Columns.Add("CorporateDivCodeRF", typeof(string));       //  個人・法人区分
            dataTable.Columns.Add("AcceptWholeSaleRF", typeof(string));	      //  業販先区分
            dataTable.Columns.Add("CustomerAttributeDivRF", typeof(string));	  //  得意先属性区分
            dataTable.Columns.Add("CustWarehouseCdRF", typeof(string));	      //  得意先優先倉庫コード
            dataTable.Columns.Add("BusinessTypeCodeRF", typeof(string));       //  業種コード
            dataTable.Columns.Add("JobTypeCodeRF", typeof(string));	          //  職種コード
            dataTable.Columns.Add("SalesAreaCodeRF", typeof(string));	      //  販売エリアコード
            dataTable.Columns.Add("CustAnalysCode1RF", typeof(string));        //  得意先分析コード1
            dataTable.Columns.Add("CustAnalysCode2RF", typeof(string));	      //  得意先分析コード2
            dataTable.Columns.Add("CustAnalysCode3RF", typeof(string));	      //  得意先分析コード3
            dataTable.Columns.Add("CustAnalysCode4RF", typeof(string));	      //  得意先分析コード4
            dataTable.Columns.Add("CustAnalysCode5RF", typeof(string));	      //  得意先分析コード5
            dataTable.Columns.Add("CustAnalysCode6RF", typeof(string));	      //  得意先分析コード6
            dataTable.Columns.Add("ClaimSectionCodeRF", typeof(string));	  //  請求拠点コード
            dataTable.Columns.Add("ClaimCodeRF", typeof(string));              //  請求先コード
            dataTable.Columns.Add("TotalDayRF", typeof(string));	              //  締日
            dataTable.Columns.Add("CollectMoneyCodeRF", typeof(string));	      //  集金月区分コード
            dataTable.Columns.Add("CollectMoneyDayRF", typeof(string));	      //  集金日
            dataTable.Columns.Add("CollectCondRF", typeof(string));	          //  回収条件
            dataTable.Columns.Add("CollectSightRF", typeof(string));	          //  回収サイト
            dataTable.Columns.Add("NTimeCalcStDateRF", typeof(string));        //  次回勘定開始日
            dataTable.Columns.Add("BillCollecterCdRF", typeof(string));	      //  集金担当従業員コード
            dataTable.Columns.Add("CustCTaXLayRefCdRF", typeof(string));	      //  得意先消費税転嫁方式参照区分
            dataTable.Columns.Add("ConsTaxLayMethodRF", typeof(string));	      //  消費税転嫁方式
            dataTable.Columns.Add("SalesUnPrcFrcProcCdRF", typeof(string));	  //  売上単価端数処理コード
            dataTable.Columns.Add("SalesMoneyFrcProcCdRF", typeof(string));	  //  売上金額端数処理コード
            dataTable.Columns.Add("SalesCnsTaxFrcProcCdRF", typeof(string));   //  売上消費税端数処理コード
            dataTable.Columns.Add("CreditMngCodeRF", typeof(string));	      //  与信管理区分 
            dataTable.Columns.Add("DepoDelCodeRF", typeof(string));	          //  入金消込区分
            dataTable.Columns.Add("AccRecDivCdRF", typeof(string));	          //  売掛区分
            dataTable.Columns.Add("PostNoRF", typeof(string));	              //  郵便番号
            dataTable.Columns.Add("Address1RF", typeof(string));	          //  住所1（都道府県市区郡・町村・字）
            dataTable.Columns.Add("Address3RF", typeof(string));	          //  住所3（番地）
            dataTable.Columns.Add("Address4RF", typeof(string));	          //  住所4（アパート名称）
            dataTable.Columns.Add("CustomerAgentRF", typeof(string));         //  得意先担当者
            dataTable.Columns.Add("HomeTelNoRF", typeof(string));             //  電話番号（自宅）
            dataTable.Columns.Add("OfficeTelNoRF", typeof(string));	          //  電話番号（勤務先）
            dataTable.Columns.Add("PortableTelNoRF", typeof(string));	      //  電話番号（携帯）
            dataTable.Columns.Add("OthersTelNoRF", typeof(string));	          //  電話番号（その他）
            dataTable.Columns.Add("HomeFaxNoRF", typeof(string));	          //  FAX番号（自宅）
            dataTable.Columns.Add("OfficeFaxNoRF", typeof(string));	          //  FAX番号（勤務先）
            dataTable.Columns.Add("SearchTelNoRF", typeof(string));	          //  電話番号（検索用下4桁）
            dataTable.Columns.Add("MainContactCodeRF", typeof(string));	      //  主連絡先区分
            dataTable.Columns.Add("Note1RF", typeof(string));	              //  備考１
            dataTable.Columns.Add("Note2RF", typeof(string));	              //  備考２
            dataTable.Columns.Add("Note3RF", typeof(string));	              //  備考３
            dataTable.Columns.Add("Note4RF", typeof(string));	              //  備考４
            dataTable.Columns.Add("Note5RF", typeof(string));	              //  備考５ 
            dataTable.Columns.Add("Note6RF", typeof(string));	              //  備考６
            dataTable.Columns.Add("Note7RF", typeof(string));	              //  備考７
            dataTable.Columns.Add("Note8RF", typeof(string));	              //  備考８
            dataTable.Columns.Add("Note9RF", typeof(string));	              //  備考９
            dataTable.Columns.Add("Note10RF", typeof(string));	              // 備考１０
            dataTable.Columns.Add("MainSendMailAddrCdRF", typeof(string));	  //  主送信先メールアドレス区分
            dataTable.Columns.Add("MailAddress1RF", typeof(string));	      //  メールアドレス1	
            dataTable.Columns.Add("MailSendCode1RF", typeof(string));	      //  メール送信区分コード1
            dataTable.Columns.Add("MailAddrKindCode1RF", typeof(string));	  //  メールアドレス種別コード1
            dataTable.Columns.Add("MailAddress2RF", typeof(string));	      // メールアドレス２ 
            dataTable.Columns.Add("MailSendCode2RF", typeof(string));	      //  メール送信区分コード２
            dataTable.Columns.Add("MailAddrKindCode2RF", typeof(string));	  //  メールアドレス種別コード２
            dataTable.Columns.Add("AccountNoInfo1RF", typeof(string));	      //  銀行口座１
            dataTable.Columns.Add("AccountNoInfo2RF", typeof(string));	      //  銀行口座２
            dataTable.Columns.Add("AccountNoInfo3RF", typeof(string));	      //  銀行口座３
            dataTable.Columns.Add("ReceiptOutputCodeRF", typeof(string));	  // 領収書出力区分コード
            dataTable.Columns.Add("DmOutCodeRF", typeof(string));	          //  DM出力区分
            dataTable.Columns.Add("SalesSlipPrtDivRF", typeof(string));	      //  売上伝票発行区分
            dataTable.Columns.Add("AcpOdrrSlipPrtDivRF", typeof(string));	  //  受注伝票発行区分
            dataTable.Columns.Add("ShipmSlipPrtDivRF", typeof(string));	      //  出荷伝票発行区分
            dataTable.Columns.Add("EstimatePrtDivRF", typeof(string));	      //  見積書発行区分	
            dataTable.Columns.Add("UOESlipPrtDivRF", typeof(string));	      // UOE伝票発行区分	
            dataTable.Columns.Add("QrcodePrtCdRF", typeof(string));	          //  QRコード印刷
            dataTable.Columns.Add("CustSlipNoMngCdRF", typeof(string));	      //  相手伝票番号管理区分
            dataTable.Columns.Add("CustomerSlipNoDivRF", typeof(string));	  //  得意先伝票番号区分
            dataTable.Columns.Add("TotalBillOutputDivRF", typeof(string));      // 合計請求書出力区分
            dataTable.Columns.Add("DetailBillOutputCodeRF", typeof(string));    // 明細請求書出力区分
            dataTable.Columns.Add("SlipTtlBillOutputDivRF", typeof(string));    // 伝票合計請求書出力区分

            //dataTable.Columns.Add("CustRateGrpFine", typeof(string));          //得意先掛率グループ(優良)// DEL  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
            dataTable.Columns.Add("CustRateGrpFineAll", typeof(string));          //得意先掛率グループ(優良ALL)// ADD  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
            dataTable.Columns.Add("CustRateGrpPureAll", typeof(string));       //得意先掛率グループ(純正ALL)
            dataTable.Columns.Add("CustRateGrpPure1", typeof(string));         //得意先掛率グループ純正１
            dataTable.Columns.Add("CustRateGrpPure2", typeof(string));         //得意先掛率グループ純正2
            dataTable.Columns.Add("CustRateGrpPure3", typeof(string));         //得意先掛率グループ純正3
            dataTable.Columns.Add("CustRateGrpPure4", typeof(string));         //得意先掛率グループ純正4
            dataTable.Columns.Add("CustRateGrpPure5", typeof(string));         //得意先掛率グループ純正5
            dataTable.Columns.Add("CustRateGrpPure6", typeof(string));         //得意先掛率グループ純正6
            dataTable.Columns.Add("CustRateGrpPure7", typeof(string));         //得意先掛率グループ純正7
            dataTable.Columns.Add("CustRateGrpPure8", typeof(string));         //得意先掛率グループ純正8
            dataTable.Columns.Add("CustRateGrpPure9", typeof(string));         //得意先掛率グループ純正9
            dataTable.Columns.Add("CustRateGrpPure10", typeof(string));        //得意先掛率グループ純正１0
            dataTable.Columns.Add("CustRateGrpPure11", typeof(string));        //得意先掛率グループ純正１1
            dataTable.Columns.Add("CustRateGrpPure12", typeof(string));        //得意先掛率グループ純正１2
            dataTable.Columns.Add("CustRateGrpPure13", typeof(string));        //得意先掛率グループ純正１3
            dataTable.Columns.Add("CustRateGrpPure14", typeof(string));        //得意先掛率グループ純正１4
            dataTable.Columns.Add("CustRateGrpPure15", typeof(string));        //得意先掛率グループ純正１5
            dataTable.Columns.Add("CustRateGrpPure16", typeof(string));        //得意先掛率グループ純正１6
            dataTable.Columns.Add("CustRateGrpPure17", typeof(string));        //得意先掛率グループ純正１7
            dataTable.Columns.Add("CustRateGrpPure18", typeof(string));        //得意先掛率グループ純正１8
            dataTable.Columns.Add("CustRateGrpPure19", typeof(string));        //得意先掛率グループ純正１9
            dataTable.Columns.Add("CustRateGrpPure20", typeof(string));        //得意先掛率グループ純正20
            dataTable.Columns.Add("CustRateGrpPure21", typeof(string));        //得意先掛率グループ純正21
            dataTable.Columns.Add("CustRateGrpPure22", typeof(string));        //得意先掛率グループ純正22
            dataTable.Columns.Add("CustRateGrpPure23", typeof(string));        //得意先掛率グループ純正23
            dataTable.Columns.Add("CustRateGrpPure24", typeof(string));        //得意先掛率グループ純正24
            dataTable.Columns.Add("CustRateGrpPure25", typeof(string));        //得意先掛率グループ純正25
            dataTable.Columns.Add("ErrorLog", typeof(string)); // ADD  2012/07/03  李亜博 Redmine#30393
        }
        // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<

        // --------------- ADD START 2012/07/03 Redmine#30393 李亜博-------->>>>
        /// <summary>
        /// インポートワークの変換処理
        /// </summary>
        /// <param name="importWorkTbl">UI抽出条件クラス</param>
        /// <param name="importWorkList">リモート用のインポートワークリスト</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : インポートワークの変換処理を行う。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/03</br>
        /// <br>Update Note: 2012/07/09 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.46の対応</br>
        /// <br>Update Note: 2012/07/13 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.7の対応</br>
        /// </remarks>
        private int ConvertToImportWorkArrayList(ExtrInfo_CustomerImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            CustomerGroupWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new CustomerGroupWork();
                    int index = 0;
                    work.CustomerCode = ConvertToEmpty(csvDataArr, index++);            // 得意先コード
                    work.CustomerSubCode = ConvertToEmpty(csvDataArr, index++);         // サブコード
                    work.Name = ConvertToEmpty(csvDataArr, index++);                    // 得意先名１
                    work.Name2 = ConvertToEmpty(csvDataArr, index++);                   // 得意先名２
                    work.CustomerSnm = ConvertToEmpty(csvDataArr, index++);             // 得意先略称
                    work.Kana = ConvertToEmpty(csvDataArr, index++);                    // 得意先名カナ
                    work.HonorificTitle = ConvertToEmpty(csvDataArr, index++);          // 敬称
                    work.OutputNameCode = ConvertToEmpty(csvDataArr, index++);          // 諸口
                    work.MngSectionCode = ConvertToEmpty(csvDataArr, index++);          // 管理拠点
                    work.CustomerAgentCd = ConvertToEmpty(csvDataArr, index++);         // 得意先担当
                    work.OldCustomerAgentCd = ConvertToEmpty(csvDataArr, index++);      // 旧担当
                    work.CustAgentChgDate = ConvertToEmpty(csvDataArr, index++);        // 担当者変更日
                    work.TransStopDate = ConvertToEmpty(csvDataArr, index++);           // 取引中止日
                    work.CarMngDivCd = ConvertToEmpty(csvDataArr, index++);             // 車輛管理
                    work.CorporateDivCode = ConvertToEmpty(csvDataArr, index++);        // 個人・法人
                    work.AcceptWholeSale = ConvertToEmpty(csvDataArr, index++);         // 得意先種別
                    work.CustomerAttributeDiv = ConvertToEmpty(csvDataArr, index++);    // 得意先属性
                    work.CustWarehouseCd = ConvertToEmpty(csvDataArr, index++);         // 優先倉庫
                    work.BusinessTypeCode = ConvertToEmpty(csvDataArr, index++);        // 業種
                    work.JobTypeCode = ConvertToEmpty(csvDataArr, index++);             // 職種
                    work.SalesAreaCode = ConvertToEmpty(csvDataArr, index++);           // 地区
                    work.CustAnalysCode1 = ConvertToEmpty(csvDataArr, index++);         // 分析コード１
                    work.CustAnalysCode2 = ConvertToEmpty(csvDataArr, index++);         // 分析コード２
                    work.CustAnalysCode3 = ConvertToEmpty(csvDataArr, index++);         // 分析コード３
                    work.CustAnalysCode4 = ConvertToEmpty(csvDataArr, index++);         // 分析コード４
                    work.CustAnalysCode5 = ConvertToEmpty(csvDataArr, index++);         // 分析コード５
                    work.CustAnalysCode6 = ConvertToEmpty(csvDataArr, index++);         // 分析コード６
                    work.ClaimSectionCode = ConvertToEmpty(csvDataArr, index++);        // 請求拠点
                    work.ClaimCode = ConvertToEmpty(csvDataArr, index++);               // 請求コード
                    work.TotalDay = ConvertToEmpty(csvDataArr, index++);                // 締日
                    work.CollectMoneyCode = ConvertToEmpty(csvDataArr, index++);        // 集金月
                    work.CollectMoneyDay = ConvertToEmpty(csvDataArr, index++);         // 集金日
                    work.CollectCond = ConvertToEmpty(csvDataArr, index++);             // 回収条件
                    work.CollectSight = ConvertToEmpty(csvDataArr, index++);            // 回収サイト
                    work.NTimeCalcStDate = ConvertToEmpty(csvDataArr, index++);         // 次回勘定
                    work.BillCollecterCd = ConvertToEmpty(csvDataArr, index++);         // 集金担当
                    work.CustCTaXLayRefCd = ConvertToEmpty(csvDataArr, index++);        // 転嫁方式参照区分
                    work.ConsTaxLayMethod = ConvertToEmpty(csvDataArr, index++);        // 消費税転嫁方式
                    work.SalesUnPrcFrcProcCd = ConvertToEmpty(csvDataArr, index++);     // 単価端数処理
                    work.SalesMoneyFrcProcCd = ConvertToEmpty(csvDataArr, index++);     // 金額端数処理
                    work.SalesCnsTaxFrcProcCd = ConvertToEmpty(csvDataArr, index++);    // 消費税端数処理
                    work.CreditMngCode = ConvertToEmpty(csvDataArr, index++);           // 与信管理
                    work.DepoDelCode = ConvertToEmpty(csvDataArr, index++);             // 入金消込
                    work.AccRecDivCd = ConvertToEmpty(csvDataArr, index++);             // 売掛区分
                    work.PostNo = ConvertToEmpty(csvDataArr, index++);                  // 郵便番号
                    work.Address1 = ConvertToEmpty(csvDataArr, index++);                // 住所
                    work.Address3 = ConvertToEmpty(csvDataArr, index++);                // 住所２
                    work.Address4 = ConvertToEmpty(csvDataArr, index++);                // 住所３
                    work.CustomerAgent = ConvertToEmpty(csvDataArr, index++);           // 得意先担当者
                    work.HomeTelNo = ConvertToEmpty(csvDataArr, index++);               // 自宅ＴＥＬ
                    work.OfficeTelNo = ConvertToEmpty(csvDataArr, index++);             // 勤務先電話１
                    work.PortableTelNo = ConvertToEmpty(csvDataArr, index++);           // 勤務先電話２
                    work.OthersTelNo = ConvertToEmpty(csvDataArr, index++);             // その他電話
                    work.HomeFaxNo = ConvertToEmpty(csvDataArr, index++);               // 自宅ＦＡＸ
                    work.OfficeFaxNo = ConvertToEmpty(csvDataArr, index++);             // 勤務先ＦＡＸ
                    work.SearchTelNo = ConvertToEmpty(csvDataArr, index++);             // 検索番号
                    work.MainContactCode = ConvertToEmpty(csvDataArr, index++);         // 主連絡先
                    work.Note1 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考１
                    work.Note2 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考２
                    work.Note3 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考３
                    work.Note4 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考４
                    work.Note5 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考５
                    work.Note6 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考６
                    work.Note7 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考７
                    work.Note8 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考８
                    work.Note9 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考９
                    work.Note10 = ConvertToEmpty(csvDataArr, index++);                  // 得意先備考１０
                    work.MainSendMailAddrCd = ConvertToEmpty(csvDataArr, index++);      // 主送信先メールアドレス区分
                    work.MailAddress1 = ConvertToEmpty(csvDataArr, index++);            // メールアドレス１
                    work.MailSendCode1 = ConvertToEmpty(csvDataArr, index++);           // メール送信区分コード１
                    work.MailAddrKindCode1 = ConvertToEmpty(csvDataArr, index++);       // メールアドレス種別コード１
                    work.MailAddress2 = ConvertToEmpty(csvDataArr, index++);            // メールアドレス２
                    work.MailSendCode2 = ConvertToEmpty(csvDataArr, index++);           // メール送信区分コード２
                    work.MailAddrKindCode2 = ConvertToEmpty(csvDataArr, index++);       // メールアドレス種別コード２
                    work.AccountNoInfo1 = ConvertToEmpty(csvDataArr, index++);          // 銀行口座１
                    work.AccountNoInfo2 = ConvertToEmpty(csvDataArr, index++);          // 銀行口座２
                    work.AccountNoInfo3 = ConvertToEmpty(csvDataArr, index++);          // 銀行口座３
                    work.ReceiptOutputCode = ConvertToEmpty(csvDataArr, index++);       // 領収書出力
                    work.DmOutCode = ConvertToEmpty(csvDataArr, index++);               // ＤＭ出力
                    work.SalesSlipPrtDiv = ConvertToEmpty(csvDataArr, index++);         // 納品書出力
                    work.AcpOdrrSlipPrtDiv = ConvertToEmpty(csvDataArr, index++);       // 受注伝票出力
                    work.ShipmSlipPrtDiv = ConvertToEmpty(csvDataArr, index++);         // 貸出伝票出力
                    work.EstimatePrtDiv = ConvertToEmpty(csvDataArr, index++);          // 見積伝票出力
                    work.UOESlipPrtDiv = ConvertToEmpty(csvDataArr, index++);           // ＵＯＥ伝票出力
                    work.QrcodePrtCd = ConvertToEmpty(csvDataArr, index++);             // ＱＲコード印刷
                    work.CustSlipNoMngCd = ConvertToEmpty(csvDataArr, index++);         // 相手伝票番号管理
                    work.CustomerSlipNoDiv = ConvertToEmpty(csvDataArr, index++);       // 相手伝票番号区分
                    work.TotalBillOutputDiv = ConvertToEmpty(csvDataArr, index++);      // 合計請求書出力
                    work.DetailBillOutputCode = ConvertToEmpty(csvDataArr, index++);    // 明細請求書出力
                    work.SlipTtlBillOutputDiv = ConvertToEmpty(csvDataArr, index++);    // 伝票合計請求書出力
                    //work.CustRateGrpFine = ConvertToEmpty(csvDataArr, index++);         //得意先掛率グループ(優良) // DEL  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
                    work.CustRateGrpFineAll = ConvertToEmpty(csvDataArr, index++);         //得意先掛率グループ(優良ALL)// ADD  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応 
                    work.CustRateGrpPureAll = ConvertToEmpty(csvDataArr, index++);      //得意先掛率グループ(純正ALL)
                    work.CustRateGrpPure1 = ConvertToEmpty(csvDataArr, index++);        //得意先掛率グループ純正1        
                    work.CustRateGrpPure2 = ConvertToEmpty(csvDataArr, index++);        //得意先掛率グループ純正2  
                    work.CustRateGrpPure3 = ConvertToEmpty(csvDataArr, index++);        //得意先掛率グループ純正3      
                    work.CustRateGrpPure4 = ConvertToEmpty(csvDataArr, index++);        //得意先掛率グループ純正4
                    work.CustRateGrpPure5 = ConvertToEmpty(csvDataArr, index++);        //得意先掛率グループ純正5
                    work.CustRateGrpPure6 = ConvertToEmpty(csvDataArr, index++);        //得意先掛率グループ純正6
                    work.CustRateGrpPure7 = ConvertToEmpty(csvDataArr, index++);        //得意先掛率グループ純正7
                    work.CustRateGrpPure8 = ConvertToEmpty(csvDataArr, index++);        //得意先掛率グループ純正8
                    work.CustRateGrpPure9 = ConvertToEmpty(csvDataArr, index++);        //得意先掛率グループ純正9
                    work.CustRateGrpPure10 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正10
                    work.CustRateGrpPure11 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正11
                    work.CustRateGrpPure12 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正12
                    work.CustRateGrpPure13 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正13
                    work.CustRateGrpPure14 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正14
                    work.CustRateGrpPure15 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正15
                    work.CustRateGrpPure16 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正16
                    work.CustRateGrpPure17 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正17
                    work.CustRateGrpPure18 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正18
                    work.CustRateGrpPure19 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正19
                    work.CustRateGrpPure20 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正20
                    work.CustRateGrpPure21 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正21
                    work.CustRateGrpPure22 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正22
                    work.CustRateGrpPure23 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正23
                    work.CustRateGrpPure24 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正24
                    work.CustRateGrpPure25 = ConvertToEmpty(csvDataArr, index++);       //得意先掛率グループ純正25
                    work.ErrorLog = string.Empty;// ADD  2012/07/13  李亜博 Redmine#30393 for 障害一覧の指摘NO.7の対応
                    importWorkList.Add(work);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// ログテーブル
        /// </summary>
        /// <param name="customerGroupWork">得意先掛率ワーク</param>
        /// <param name="logTable">ログテーブル</param>
        private void ConverToDataSetCustomerLog(CustomerGroupWork customerGroupWork, ref DataTable logTable)
        {
            DataRow dataRow = logTable.NewRow();
            dataRow["CustomerCodeRF"] = customerGroupWork.CustomerCode;
            dataRow["CustomerSubCodeRF"] = customerGroupWork.CustomerSubCode;
            dataRow["NameRF"] = customerGroupWork.Name;
            dataRow["Name2RF"] = customerGroupWork.Name2;
            dataRow["CustomerSnmRF"] = customerGroupWork.CustomerSnm;
            dataRow["KanaRF"] = customerGroupWork.Kana;
            dataRow["HonorificTitleRF"] = customerGroupWork.HonorificTitle;
            dataRow["OutputNameCodeRF"] = customerGroupWork.OutputNameCode;
            dataRow["MngSectionCodeRF"] = customerGroupWork.MngSectionCode;
            dataRow["CustomerAgentCdRF"] = customerGroupWork.CustomerAgentCd;
            dataRow["OldCustomerAgentCdRF"] = customerGroupWork.OldCustomerAgentCd;
            dataRow["CustAgentChgDateRF"] = customerGroupWork.CustAgentChgDate;
            dataRow["TransStopDateRF"] = customerGroupWork.TransStopDate;
            dataRow["CarMngDivCdRF"] = customerGroupWork.CarMngDivCd;
            dataRow["CorporateDivCodeRF"] = customerGroupWork.CorporateDivCode;
            dataRow["AcceptWholeSaleRF"] = customerGroupWork.AcceptWholeSale;
            dataRow["CustomerAttributeDivRF"] = customerGroupWork.CustomerAttributeDiv;
            dataRow["CustWarehouseCdRF"] = customerGroupWork.CustWarehouseCd;
            dataRow["BusinessTypeCodeRF"] = customerGroupWork.BusinessTypeCode;
            dataRow["JobTypeCodeRF"] = customerGroupWork.JobTypeCode;
            dataRow["SalesAreaCodeRF"] = customerGroupWork.SalesAreaCode;
            dataRow["CustAnalysCode1RF"] = customerGroupWork.CustAnalysCode1;
            dataRow["CustAnalysCode2RF"] = customerGroupWork.CustAnalysCode2;
            dataRow["CustAnalysCode3RF"] = customerGroupWork.CustAnalysCode3;
            dataRow["CustAnalysCode4RF"] = customerGroupWork.CustAnalysCode4;
            dataRow["CustAnalysCode5RF"] = customerGroupWork.CustAnalysCode5;
            dataRow["CustAnalysCode6RF"] = customerGroupWork.CustAnalysCode6;
            dataRow["ClaimSectionCodeRF"] = customerGroupWork.ClaimSectionCode;
            dataRow["ClaimCodeRF"] = customerGroupWork.ClaimCode;
            dataRow["TotalDayRF"] = customerGroupWork.TotalDay;
            dataRow["CollectMoneyCodeRF"] = customerGroupWork.CollectMoneyCode;
            dataRow["CollectMoneyDayRF"] = customerGroupWork.CollectMoneyDay;
            dataRow["CollectCondRF"] = customerGroupWork.CollectCond;
            dataRow["CollectSightRF"] = customerGroupWork.CollectSight;
            dataRow["NTimeCalcStDateRF"] = customerGroupWork.NTimeCalcStDate;
            dataRow["BillCollecterCdRF"] = customerGroupWork.BillCollecterCd;
            dataRow["CustCTaXLayRefCdRF"] = customerGroupWork.CustCTaXLayRefCd;
            dataRow["ConsTaxLayMethodRF"] = customerGroupWork.ConsTaxLayMethod;
            dataRow["SalesUnPrcFrcProcCdRF"] = customerGroupWork.SalesUnPrcFrcProcCd;
            dataRow["SalesMoneyFrcProcCdRF"] = customerGroupWork.SalesMoneyFrcProcCd;
            dataRow["SalesCnsTaxFrcProcCdRF"] = customerGroupWork.SalesCnsTaxFrcProcCd;
            dataRow["CreditMngCodeRF"] = customerGroupWork.CreditMngCode;
            dataRow["DepoDelCodeRF"] = customerGroupWork.DepoDelCode;
            dataRow["AccRecDivCdRF"] = customerGroupWork.AccRecDivCd;
            dataRow["PostNoRF"] = customerGroupWork.PostNo;
            dataRow["Address1RF"] = customerGroupWork.Address1;
            dataRow["Address3RF"] = customerGroupWork.Address3;
            dataRow["Address4RF"] = customerGroupWork.Address4;
            dataRow["CustomerAgentRF"] = customerGroupWork.CustomerAgent;
            dataRow["HomeTelNoRF"] = customerGroupWork.HomeTelNo;
            dataRow["OfficeTelNoRF"] = customerGroupWork.OfficeTelNo;
            dataRow["PortableTelNoRF"] = customerGroupWork.PortableTelNo;
            dataRow["OthersTelNoRF"] = customerGroupWork.OthersTelNo;
            dataRow["HomeFaxNoRF"] = customerGroupWork.HomeFaxNo;
            dataRow["OfficeFaxNoRF"] = customerGroupWork.OfficeFaxNo;
            dataRow["SearchTelNoRF"] = customerGroupWork.SearchTelNo;
            dataRow["MainContactCodeRF"] = customerGroupWork.MainContactCode;
            dataRow["Note1RF"] = customerGroupWork.Note1;
            dataRow["Note2RF"] = customerGroupWork.Note2;
            dataRow["Note3RF"] = customerGroupWork.Note3;
            dataRow["Note4RF"] = customerGroupWork.Note4;
            dataRow["Note5RF"] = customerGroupWork.Note5;
            dataRow["Note6RF"] = customerGroupWork.Note6;
            dataRow["Note7RF"] = customerGroupWork.Note7;
            dataRow["Note8RF"] = customerGroupWork.Note8;
            dataRow["Note9RF"] = customerGroupWork.Note9;
            dataRow["Note10RF"] = customerGroupWork.Note10;
            dataRow["MainSendMailAddrCdRF"] = customerGroupWork.MainSendMailAddrCd;
            dataRow["MailAddress1RF"] = customerGroupWork.MailAddress1;
            dataRow["MailSendCode1RF"] = customerGroupWork.MailSendCode1;
            dataRow["MailAddrKindCode1RF"] = customerGroupWork.MailAddrKindCode1;
            dataRow["MailAddress2RF"] = customerGroupWork.MailAddress2;
            dataRow["MailSendCode2RF"] = customerGroupWork.MailSendCode2;
            dataRow["MailAddrKindCode2RF"] = customerGroupWork.MailAddrKindCode2;
            dataRow["AccountNoInfo1RF"] = customerGroupWork.AccountNoInfo1;
            dataRow["AccountNoInfo2RF"] = customerGroupWork.AccountNoInfo2;
            dataRow["AccountNoInfo3RF"] = customerGroupWork.AccountNoInfo3;
            dataRow["ReceiptOutputCodeRF"] = customerGroupWork.ReceiptOutputCode;
            dataRow["DmOutCodeRF"] = customerGroupWork.DmOutCode;
            dataRow["SalesSlipPrtDivRF"] = customerGroupWork.SalesSlipPrtDiv;
            dataRow["AcpOdrrSlipPrtDivRF"] = customerGroupWork.AcpOdrrSlipPrtDiv;
            dataRow["ShipmSlipPrtDivRF"] = customerGroupWork.ShipmSlipPrtDiv;
            dataRow["EstimatePrtDivRF"] = customerGroupWork.EstimatePrtDiv;
            dataRow["UOESlipPrtDivRF"] = customerGroupWork.UOESlipPrtDiv;
            dataRow["QrcodePrtCdRF"] = customerGroupWork.QrcodePrtCd;
            dataRow["CustSlipNoMngCdRF"] = customerGroupWork.CustSlipNoMngCd;
            dataRow["CustomerSlipNoDivRF"] = customerGroupWork.CustomerSlipNoDiv;
            dataRow["TotalBillOutputDivRF"] = customerGroupWork.TotalBillOutputDiv;
            dataRow["DetailBillOutputCodeRF"] = customerGroupWork.DetailBillOutputCode;
            dataRow["SlipTtlBillOutputDivRF"] = customerGroupWork.SlipTtlBillOutputDiv;
            //dataRow["CustRateGrpFine"] = customerGroupWork.CustRateGrpFine;// DEL  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
            dataRow["CustRateGrpFineAll"] = customerGroupWork.CustRateGrpFineAll;// ADD  2012/07/09  李亜博 Redmine#30393 for 障害一覧の指摘NO.46の対応
            dataRow["CustRateGrpPureAll"] = customerGroupWork.CustRateGrpPureAll;
            dataRow["CustRateGrpPure1"] = customerGroupWork.CustRateGrpPure1;
            dataRow["CustRateGrpPure2"] = customerGroupWork.CustRateGrpPure2;
            dataRow["CustRateGrpPure3"] = customerGroupWork.CustRateGrpPure3;
            dataRow["CustRateGrpPure4"] = customerGroupWork.CustRateGrpPure4;
            dataRow["CustRateGrpPure5"] = customerGroupWork.CustRateGrpPure5;
            dataRow["CustRateGrpPure6"] = customerGroupWork.CustRateGrpPure6;
            dataRow["CustRateGrpPure7"] = customerGroupWork.CustRateGrpPure7;
            dataRow["CustRateGrpPure8"] = customerGroupWork.CustRateGrpPure8;
            dataRow["CustRateGrpPure9"] = customerGroupWork.CustRateGrpPure9;
            dataRow["CustRateGrpPure10"] = customerGroupWork.CustRateGrpPure10;
            dataRow["CustRateGrpPure11"] = customerGroupWork.CustRateGrpPure11;
            dataRow["CustRateGrpPure12"] = customerGroupWork.CustRateGrpPure12;
            dataRow["CustRateGrpPure13"] = customerGroupWork.CustRateGrpPure13;
            dataRow["CustRateGrpPure14"] = customerGroupWork.CustRateGrpPure14;
            dataRow["CustRateGrpPure15"] = customerGroupWork.CustRateGrpPure15;
            dataRow["CustRateGrpPure16"] = customerGroupWork.CustRateGrpPure16;
            dataRow["CustRateGrpPure17"] = customerGroupWork.CustRateGrpPure17;
            dataRow["CustRateGrpPure18"] = customerGroupWork.CustRateGrpPure18;
            dataRow["CustRateGrpPure19"] = customerGroupWork.CustRateGrpPure19;
            dataRow["CustRateGrpPure20"] = customerGroupWork.CustRateGrpPure20;
            dataRow["CustRateGrpPure21"] = customerGroupWork.CustRateGrpPure21;
            dataRow["CustRateGrpPure22"] = customerGroupWork.CustRateGrpPure22;
            dataRow["CustRateGrpPure23"] = customerGroupWork.CustRateGrpPure23;
            dataRow["CustRateGrpPure24"] = customerGroupWork.CustRateGrpPure24;
            dataRow["CustRateGrpPure25"] = customerGroupWork.CustRateGrpPure25;
            dataRow["ErrorLog"] = customerGroupWork.ErrorLog;
            logTable.Rows.Add(dataRow);
        }
        // --------------- ADD END 2012/07/03 Redmine#30393 李亜博--------<<<<
        #region ◆ データ変換処理
        #region ◎ インポートワークの変換処理
        /// <summary>
        /// インポートワークの変換処理
        /// </summary>
        /// <param name="importWorkTbl">UI抽出条件クラス</param>
        /// <param name="importWorkList">リモート用のインポートワークリスト</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : インポートワークの変換処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int ConvertToImportWorkList(ExtrInfo_CustomerImportWorkTbl importWorkTbl, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            CustomerWork work = null;

            try
            {
                List<string[]> csvDataInfoList = importWorkTbl.CsvDataInfoList;
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new CustomerWork();
                    int index = 0;
                    work.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;          // 企業コード
                    work.CustomerCode = ConvertToInt32(csvDataArr, index++);            // 得意先コード
                    work.CustomerSubCode = ConvertToEmpty(csvDataArr, index++);         // サブコード
                    work.Name = ConvertToEmpty(csvDataArr, index++);                    // 得意先名１
                    work.Name2 = ConvertToEmpty(csvDataArr, index++);                   // 得意先名２
                    work.CustomerSnm = ConvertToEmpty(csvDataArr, index++);             // 得意先略称
                    work.Kana = ConvertToEmpty(csvDataArr, index++);                    // 得意先名カナ
                    work.HonorificTitle = ConvertToEmpty(csvDataArr, index++);          // 敬称
                    work.OutputNameCode = ConvertToInt32(csvDataArr, index++);          // 諸口
                    work.MngSectionCode = ConvertToStrCode(csvDataArr, index++, 2);     // 管理拠点
                    work.CustomerAgentCd = ConvertToStrCode(csvDataArr, index++, 4);    // 得意先担当
                    work.OldCustomerAgentCd = ConvertToStrCode(csvDataArr, index++, 4); // 旧担当
                    work.CustAgentChgDate = ConvertToDateTime(csvDataArr, index++);     // 担当者変更日
                    work.TransStopDate = ConvertToDateTime(csvDataArr, index++);        // 取引中止日
                    work.CarMngDivCd = ConvertToInt32(csvDataArr, index++);             // 車輛管理
                    work.CorporateDivCode = ConvertToInt32(csvDataArr, index++);        // 個人・法人
                    work.AcceptWholeSale = ConvertToInt32(csvDataArr, index++);         // 得意先種別
                    work.CustomerAttributeDiv = ConvertToInt32(csvDataArr, index++);    // 得意先属性
                    work.CustWarehouseCd = ConvertToStrCode(csvDataArr, index++, 4);    // 優先倉庫
                    work.BusinessTypeCode = ConvertToInt32(csvDataArr, index++);        // 業種
                    work.JobTypeCode = ConvertToInt32(csvDataArr, index++);             // 職種
                    work.SalesAreaCode = ConvertToInt32(csvDataArr, index++);           // 地区
                    work.CustAnalysCode1 = ConvertToInt32(csvDataArr, index++);         // 分析コード１
                    work.CustAnalysCode2 = ConvertToInt32(csvDataArr, index++);         // 分析コード２
                    work.CustAnalysCode3 = ConvertToInt32(csvDataArr, index++);         // 分析コード３
                    work.CustAnalysCode4 = ConvertToInt32(csvDataArr, index++);         // 分析コード４
                    work.CustAnalysCode5 = ConvertToInt32(csvDataArr, index++);         // 分析コード５
                    work.CustAnalysCode6 = ConvertToInt32(csvDataArr, index++);         // 分析コード６
                    work.ClaimSectionCode = ConvertToStrCode(csvDataArr, index++, 2);   // 請求拠点
                    work.ClaimCode = ConvertToInt32(csvDataArr, index++);               // 請求コード
                    work.TotalDay = ConvertToInt32(csvDataArr, index++);                // 締日
                    work.CollectMoneyCode = ConvertToInt32(csvDataArr, index++);        // 集金月
                    work.CollectMoneyDay = ConvertToInt32(csvDataArr, index++);         // 集金日
                    work.CollectCond = ConvertToInt32(csvDataArr, index++);             // 回収条件
                    work.CollectSight = ConvertToInt32(csvDataArr, index++);            // 回収サイト
                    work.NTimeCalcStDate = ConvertToInt32(csvDataArr, index++);         // 次回勘定
                    work.BillCollecterCd = ConvertToStrCode(csvDataArr, index++, 4);    // 集金担当
                    work.CustCTaXLayRefCd = ConvertToInt32(csvDataArr, index++);        // 転嫁方式参照区分
                    work.ConsTaxLayMethod = ConvertToInt32(csvDataArr, index++);        // 消費税転嫁方式
                    work.SalesUnPrcFrcProcCd = ConvertToInt32(csvDataArr, index++);     // 単価端数処理
                    work.SalesMoneyFrcProcCd = ConvertToInt32(csvDataArr, index++);     // 金額端数処理
                    work.SalesCnsTaxFrcProcCd = ConvertToInt32(csvDataArr, index++);    // 消費税端数処理
                    work.CreditMngCode = ConvertToInt32(csvDataArr, index++);           // 与信管理
                    work.DepoDelCode = ConvertToInt32(csvDataArr, index++);             // 入金消込
                    work.AccRecDivCd = ConvertToInt32(csvDataArr, index++);             // 売掛区分
                    work.PostNo = ConvertToEmpty(csvDataArr, index++);                  // 郵便番号
                    work.Address1 = ConvertToEmpty(csvDataArr, index++);                // 住所
                    work.Address3 = ConvertToEmpty(csvDataArr, index++);                // 住所２
                    work.Address4 = ConvertToEmpty(csvDataArr, index++);                // 住所３
                    work.CustomerAgent = ConvertToEmpty(csvDataArr, index++);           // 得意先担当者
                    work.HomeTelNo = ConvertToEmpty(csvDataArr, index++);               // 自宅ＴＥＬ
                    work.OfficeTelNo = ConvertToEmpty(csvDataArr, index++);             // 勤務先電話１
                    work.PortableTelNo = ConvertToEmpty(csvDataArr, index++);           // 勤務先電話２
                    work.OthersTelNo = ConvertToEmpty(csvDataArr, index++);             // その他電話
                    work.HomeFaxNo = ConvertToEmpty(csvDataArr, index++);               // 自宅ＦＡＸ
                    work.OfficeFaxNo = ConvertToEmpty(csvDataArr, index++);             // 勤務先ＦＡＸ
                    work.SearchTelNo = ConvertToEmpty(csvDataArr, index++);             // 検索番号
                    work.MainContactCode = ConvertToInt32(csvDataArr, index++);         // 主連絡先
                    work.Note1 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考１
                    work.Note2 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考２
                    work.Note3 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考３
                    work.Note4 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考４
                    work.Note5 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考５
                    work.Note6 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考６
                    work.Note7 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考７
                    work.Note8 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考８
                    work.Note9 = ConvertToEmpty(csvDataArr, index++);                   // 得意先備考９
                    work.Note10 = ConvertToEmpty(csvDataArr, index++);                  // 得意先備考１０
                    work.MainSendMailAddrCd = ConvertToInt32(csvDataArr, index++);      // 主送信先メールアドレス区分
                    work.MailAddress1 = ConvertToEmpty(csvDataArr, index++);            // メールアドレス１
                    work.MailSendCode1 = ConvertToInt32(csvDataArr, index++);           // メール送信区分コード１
                    work.MailAddrKindCode1 = ConvertToInt32(csvDataArr, index++);       // メールアドレス種別コード１
                    work.MailAddress2 = ConvertToEmpty(csvDataArr, index++);            // メールアドレス２
                    work.MailSendCode2 = ConvertToInt32(csvDataArr, index++);           // メール送信区分コード２
                    work.MailAddrKindCode2 = ConvertToInt32(csvDataArr, index++);       // メールアドレス種別コード２
                    work.AccountNoInfo1 = ConvertToEmpty(csvDataArr, index++);          // 銀行口座１
                    work.AccountNoInfo2 = ConvertToEmpty(csvDataArr, index++);          // 銀行口座２
                    work.AccountNoInfo3 = ConvertToEmpty(csvDataArr, index++);          // 銀行口座３
                    // DEL 2010/02/01 MANTIS対応[14952]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
                    // TODO:使用しない…請求書出力
                    //work.BillOutputCode = ConvertToInt32(csvDataArr, index++);          // 請求書出力
                    // DEL 2010/02/01 MANTIS対応[14952]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<
                    work.ReceiptOutputCode = ConvertToInt32(csvDataArr, index++);       // 領収書出力
                    work.DmOutCode = ConvertToInt32(csvDataArr, index++);               // ＤＭ出力
                    work.SalesSlipPrtDiv = ConvertToInt32(csvDataArr, index++);         // 納品書出力
                    work.AcpOdrrSlipPrtDiv = ConvertToInt32(csvDataArr, index++);       // 受注伝票出力
                    work.ShipmSlipPrtDiv = ConvertToInt32(csvDataArr, index++);         // 貸出伝票出力
                    work.EstimatePrtDiv = ConvertToInt32(csvDataArr, index++);          // 見積伝票出力
                    work.UOESlipPrtDiv = ConvertToInt32(csvDataArr, index++);           // ＵＯＥ伝票出力
                    work.QrcodePrtCd = ConvertToInt32(csvDataArr, index++);             // ＱＲコード印刷
                    work.CustSlipNoMngCd = ConvertToInt32(csvDataArr, index++);         // 相手伝票番号管理
                    work.CustomerSlipNoDiv = ConvertToInt32(csvDataArr, index++);       // 相手伝票番号区分

                    // ADD 2010/02/01 MANTIS対応[14952]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
                    work.TotalBillOutputDiv = ConvertToInt32(csvDataArr, index++);      // 合計請求書出力
                    work.DetailBillOutputCode = ConvertToInt32(csvDataArr, index++);    // 明細請求書出力
                    work.SlipTtlBillOutputDiv = ConvertToInt32(csvDataArr, index++);    // 伝票合計請求書出力
                    // ADD 2010/02/01 MANTIS対応[14952]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

                    importWorkList.Add(work);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion

        #region ◎ 数値項目へ変換処理
        /// <summary>
        /// 数値項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した数値</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合はゼロへ変換処理処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private Int32 ConvertToInt32(string[] csvDataArr, Int32 index)
        {
            Int32 retNum = 0;

            if (index < csvDataArr.Length)
            {
                try
                {
                    retNum = Convert.ToInt32(csvDataArr[index]);
                }
                catch
                {
                    retNum = 0;
                }
            }

            return retNum;
        }
        #endregion


        #region ◎ 日時項目へ変換処理
        /// <summary>
        /// 日時項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した日時</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合は最小日時へ変換処理処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private DateTime ConvertToDateTime(string[] csvDataArr, Int32 index)
        {
            DateTime retDt = DateTime.MinValue;

            if (index < csvDataArr.Length)
            {
                Int32 tmpNumber = ConvertToInt32(csvDataArr, index);
                if (tmpNumber != 0)
                {
                    retDt = TDateTime.LongDateToDateTime(tmpNumber);
                }
            }

            return retDt;
        }
        #endregion

        #region ◎ 空白項目へ変換処理
        /// <summary>
        /// 空白項目へ変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <returns>変更した項目</returns>
        /// <remarks>
        /// <br>Note       : 項目数が足りない場合は空白項目へ変換処理処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private string ConvertToEmpty(string[] csvDataArr, Int32 index)
        {
            string retContent = string.Empty;

            if (index < csvDataArr.Length)
            {
                retContent = csvDataArr[index];
            }

            return retContent;
        }
        #endregion

        #region ◎ コード文字列項目の変換処理
        /// <summary>
        /// コード文字列項目の変換処理
        /// </summary>
        /// <param name="csvDataArr">CSV項目配列</param>
        /// <param name="index">インデックス</param>
        /// <param name="maxLength">MAX桁数</param>
        /// <returns>変更した項目</returns>
        /// <remarks>
        /// <br>Note       : コード文字列項目の変換処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.22</br>
        /// </remarks>
        private string ConvertToStrCode(string[] csvDataArr, Int32 index, Int32 maxLength)
        {
            return ConvertToEmpty(csvDataArr, index).PadLeft(maxLength, '0');
        }
        #endregion
        #endregion

        #endregion ■ Private Method
    }
}

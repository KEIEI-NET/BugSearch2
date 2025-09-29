using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Common;  // ADD 2021/02/15
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 発注一覧表データ更新DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注一覧表データ更新の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2008.10.15</br>
    /// <br></br>
    /// <br>Update Note: ログイン拠点単位で発注データの削除を行うように修正</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/06/08</br>
    /// <br></br>
    /// <br>Update Note: チューニング</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2011/02/24</br>
    /// <br>Note       : redmine#34986の対応 発注一覧表とUOE発送処理のサーバ端で、操作履歴ログ追加</br>
    /// <br>Programmer : pengjie</br>
    /// <br>Date       : 2012.03.14</br>
    /// <br></br>
    /// <br>Update Note: 個別自動発注処理導入時、UOE発注番号採番後のレコード論理削除対象外</br>
    /// <br>Programmer : 佐々木亘</br>
    /// <br>Date       : 2021/02/15</br>
    /// </remarks>
    [Serializable]
    public class OrderListRenewWorkDB : RemoteWithAppLockDB, IOrderListRenewWorkDB
    {

        //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
        #region　Private Const
        private const string UOE_ORDER_SEARCH_BEGIN = "UOE発注データ検索開始";
        private const string UOE_ORDER_SEARCH_END = "UOE発注データ検索終了";
        private const string UOE_ORDER_LOGICALDELETE_BEGIN = "UOE発注データ論理削除開始";
        private const string UOE_ORDER_LOGICALDELETE_END = "UOE発注データ論理削除終了";
        private const string STOCKDETAIL_DELETE_BEGIN = "仕入明細データ削除開始";
        private const string STOCKDETAIL_DELETE_END = "仕入明細データ削除終了";
        private const string UOE_ORDER_WRITE_BEGIN = "UOE発注データ登録開始";
        private const string UOE_ORDER_WRITE_END = "UOE発注データ登録終了";
        private const string STOCKSLIP_WRITE_BEGIN = "仕入データ・明細データ登録開始";
        private const string STOCKSLIP_WRITE_END = "仕入データ・明細データ登録終了";
        #endregion
        //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

        public int Write(ref object List, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //StockSlipDB _stockSlipDB = new StockSlipDB();
            IOWriteMASIRDB _stockSlipDB = new IOWriteMASIRDB();
            IOWriteControlDB _iOWriteControlDB = new IOWriteControlDB();
            
            ArrayList uoeOrderDtlList = new ArrayList();
            ArrayList uoeList = new ArrayList();
            ArrayList stockList = new ArrayList();
            CustomSerializeArrayList stockDataList = new CustomSerializeArrayList();
            ArrayList paramList = new ArrayList();
            //string enterpriseCode;// DEL pengjie 2013/03/14 REDMINE#34986
            string enterpriseCode = string.Empty; // ADD pengjie 2013/03/14 REDMINE#34986

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList operateHisList = new ArrayList(); // ADD pengjie 2013/03/14 REDMINE#34986

            string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());

            ArrayList palamList = List as ArrayList;

            // Listの中身の仕分け
            foreach (object al in palamList)
            {
                if (al is ArrayList)
                {
                    ArrayList alList = al as ArrayList;
                    
                    // 仕入データ＆仕入明細データ
                    if (ListUtils.Find(alList, typeof(StockSlipWork), ListUtils.FindType.Class) != null)
                    {
                        stockDataList.Add(alList);
                        continue;
                    }

                    // UOE発注データ
                    if (ListUtils.Find(alList, typeof(UOEOrderDtlWork), ListUtils.FindType.Class) != null)
                    {
                        uoeList = alList;
                        continue;
                    }

                    // 仕入データ
                    if ((ListUtils.Find(alList, typeof(StockDetailWork), ListUtils.FindType.Class) != null) && (ListUtils.Find(alList, typeof(StockSlipWork), ListUtils.FindType.Class)) == null)
                    {
                        stockList = alList;
                        continue;
                    }
                }
            }
            if (stockDataList.Count == 0 && uoeList.Count == 0 && stockList.Count == 0)
            {
                errmsg += ": List内にUOE発注データ、仕入データ、仕入明細データが入っていません";
                base.WriteErrorLog(errmsg, status);
                return status;
            } 
            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                if (ListUtils.IsNotEmpty(uoeList))
                {
                    // 企業コード取得
                    UOEOrderDtlWork uoeWork = uoeList[0] as UOEOrderDtlWork;

                    enterpriseCode = uoeWork.EnterpriseCode;
                    string sectionCode = uoeWork.SectionCode;  // ADD 2010/06/08

                    //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    // UOE発注データ検索開始
                    operateHisList.Add(UOE_ORDER_SEARCH_BEGIN);
                    //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                    // UOE発注データSearch
                    // -- UPD 2010/06/08 ------------------------------------>>>
                    //status = this.Search(ref uoeOrderDtlList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction, enterpriseCode);
                    status = this.Search(ref uoeOrderDtlList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction, enterpriseCode, sectionCode);
                    // -- UPD 2010/06/08 ------------------------------------<<<

                    //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    // UOE発注データ検索終了
                    operateHisList.Add(UOE_ORDER_SEARCH_END);
                    //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                    if (ListUtils.IsNotEmpty(uoeOrderDtlList))
                    {
                        // 何か入ってる    
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // UOE発注データ論理削除
                            // -- UPD 2010/06/08 ------------------------------------>>>
                            //status = this.UOELogicalDelete(ref sqlConnection, ref sqlTransaction);

                            //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                            // UOE発注データ論理削除開始
                            operateHisList.Add(UOE_ORDER_LOGICALDELETE_BEGIN);
                            //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                            UOEOrderDtlDB uoeOrderDtlDB = new UOEOrderDtlDB();
                            uoeOrderDtlDB.LogicalDelete(ref uoeOrderDtlList, 0, ref sqlConnection, ref sqlTransaction);
                            // -- UPD 2010/06/08 ------------------------------------<<<

                            //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                            // UOE発注データ論理削除終了
                            operateHisList.Add(UOE_ORDER_LOGICALDELETE_END);
                            //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                            // 仕入明細データ削除開始
                            operateHisList.Add(STOCKDETAIL_DELETE_BEGIN);
                            //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                            // 仕入明細データ削除
                            status = this.SuppDelete(uoeOrderDtlList, ref sqlConnection, ref sqlTransaction);

                            //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                            // 仕入明細データ削除終了
                            operateHisList.Add(STOCKDETAIL_DELETE_END);
                            //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
                        }

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            errmsg += ": 未発注データの削除に失敗しました";
                            base.WriteErrorLog(errmsg, status);

                            return status;
                        }
                    }

                    // IOWriterに新しいListを渡す 
                    ArrayList paraList = new ArrayList();
                    IOWriteCtrlOptWork iOWriterCtrlOptWork = new IOWriteCtrlOptWork();

                    // iOWriterCtrlOptWorkの追加
                    iOWriterCtrlOptWork.CtrlStartingPoint = 1; //1:仕入
                    iOWriterCtrlOptWork.EnterpriseCode = enterpriseCode;
                    paraList.Add(iOWriterCtrlOptWork);

                    // UOE発注データListの追加
                    ArrayList uoeAl = new ArrayList();
                    uoeAl.Add(uoeList);
                    paraList.Add(uoeAl);
                    
                    // 仕入明細データの追加
                    ArrayList stockAl = new ArrayList();
                    stockAl.Add(stockList);
                    paraList.Add(stockAl);

                    string retMsg = "";
                    string retItemInfo = "";
                    SqlEncryptInfo encryptinfo = null;

                    //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    // UOE発注データ登録開始
                    operateHisList.Add(UOE_ORDER_WRITE_BEGIN);
                    //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                    status = _iOWriteControlDB.WriteProc(ref paraList, out retMsg, out retItemInfo, ref  sqlConnection, ref sqlTransaction, ref encryptinfo);

                    //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    // UOE発注データ登録終了
                    operateHisList.Add(UOE_ORDER_WRITE_END);
                    //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
                }

                //仕入データ・明細データ
                if (ListUtils.IsNotEmpty(stockDataList))
                {
                    ArrayList paraList = new ArrayList();

                    // データセット
                    paraList = stockDataList;

                    SqlEncryptInfo sqlEncryptInfo = null;

                    string retString = string.Empty;
                    string retItemInfo = string.Empty;

                    //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    ArrayList subList = paraList[0] as ArrayList;
                    if (subList != null && subList.Count > 0)
                    {
                        // 仕入データ
                        StockSlipWork stockSlipWork = ListUtils.Find(subList, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                        if (stockSlipWork != null)
                        {
                            // 企業コード
                            enterpriseCode = stockSlipWork.EnterpriseCode;
                        }
                    }

                    // 仕入データ・明細データ登録開始
                    operateHisList.Add(STOCKSLIP_WRITE_BEGIN);
                    //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                    // MAKON01824R.StockSlipDB.WriteforSalesOrderPrintにStockDataListを渡す
                    status = _stockSlipDB.WriteforSalesOrderPrint(ref paraList, out retString ,out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);

                    //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                    // 仕入データ・明細データ登録終了
                    operateHisList.Add(STOCKSLIP_WRITE_END);
                    //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
                // 操作履歴ログ書き込み処理
                this.WriteOprtnHisLog(sqlConnection, enterpriseCode, operateHisList);
                //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
             return status;
        }

        # region [Search]
        /// <summary>
        /// UOE発注データ情報のリストを取得します。
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE発注データ情報を格納する ArrayList</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注データのキー値が一致する、全てのUOE発注データ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.14</br>
        // -- UPD 2010/06/08 -------------------------------------------------------------->>>
        //public int Search(ref ArrayList uoeOrderDtlList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string enterpriseCode)
        public int Search(ref ArrayList uoeOrderDtlList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,string enterpriseCode, string sectionCode)
        // -- UPD 2010/06/08 --------------------------------------------------------------<<<
        {

            // -- UPD 2010/06/08 -------------------------------------------------------------->>>
            //return SearchProc(ref uoeOrderDtlList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction, enterpriseCode);
            return SearchProc(ref uoeOrderDtlList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction, enterpriseCode, sectionCode);
            // -- UPD 2010/06/08 --------------------------------------------------------------<<<
        }

        /// <summary>
        /// UOE発注データ情報のリストを取得します。
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE発注データ情報を格納する ArrayList</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注データのキー値が一致する、全てのUOE発注データ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.14</br>
        // -- UPD 2010/06/08 -------------------------------------------------------------->>>
        //private int SearchProc(ref ArrayList uoeOrderDtlList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string enterpriseCode)
        private int SearchProc(ref ArrayList uoeOrderDtlList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string enterpriseCode, string sectionCode)
        // -- UPD 2010/06/08 --------------------------------------------------------------<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {

                // -- ADD 2021/02/15 --------------------------------------------->>>
                // 個別UOEオプション判定
                bool optCpmUoeOrderCtl = false;
                try
                {
                    ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();
                    PurchaseStatus ps = loginInfo.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
                    if (ps == PurchaseStatus.Contract)
                    {
                        optCpmUoeOrderCtl = true;
                    }
                    else
                    {
                        optCpmUoeOrderCtl = false;
                    }
                }
                catch
                {
                    // オプション取得できない場合はエラーとせず継続
                }
                finally
                {
                }
                // -- ADD 2021/02/15 ---------------------------------------------<<<

                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                // -- UPD 2011/02/24 ---------------------------->>>
                //sqlText += "  *" + Environment.NewLine;
                sqlText += "   ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,UOEKINDRF" + Environment.NewLine;
                sqlText += "  ,ONLINENORF" + Environment.NewLine;
                sqlText += "  ,ONLINEROWNORF" + Environment.NewLine;
                sqlText += "  ,COMMONSEQNORF" + Environment.NewLine;
                sqlText += "  ,SUPPLIERFORMALRF" + Environment.NewLine;
                sqlText += "  ,STOCKSLIPDTLNUMRF" + Environment.NewLine;
                // -- UPD 2011/02/24 ----------------------------<<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  UOEORDERDTLRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += " AND SYSTEMDIVCDRF = 3" + Environment.NewLine;
                sqlText += " AND DATASENDCODERF = 0" + Environment.NewLine;
                sqlText += " AND DATARECOVERDIVRF = 0" + Environment.NewLine;
                sqlText += " AND LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += " AND SECTIONCODERF = @SECTIONCODERF" + Environment.NewLine;  // ADD 2010/06/08

                // -- ADD 2021/02/15 --------------------------------------------->>>
                if (optCpmUoeOrderCtl)
                {
                    // 個別自動発注処理導入時はUOE発注番号採番後データは論理削除データ抽出対象外
                    sqlText += " AND UOESALESORDERNORF = 0" + Environment.NewLine;
                }
                // -- ADD 2021/02/15 ---------------------------------------------<<<

                sqlCommand.CommandText = sqlText;

                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // -- ADD 2010/06/08 --------------------------------------------->>>
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODERF", SqlDbType.NChar);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
                // -- ADD 2010/06/08 ---------------------------------------------<<<
                # endregion


                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    UOEOrderDtlWork wkuoeOrderDtlList = new UOEOrderDtlWork();
                    
                    #region　格納処理
                    //格納処理
                    wkuoeOrderDtlList.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkuoeOrderDtlList.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkuoeOrderDtlList.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkuoeOrderDtlList.UOEKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOEKINDRF"));
                    wkuoeOrderDtlList.OnlineNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINENORF"));
                    wkuoeOrderDtlList.OnlineRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEROWNORF"));
                    wkuoeOrderDtlList.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                    wkuoeOrderDtlList.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                    wkuoeOrderDtlList.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                    #endregion
                    uoeOrderDtlList.Add(wkuoeOrderDtlList);
                }

                if (uoeOrderDtlList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion

        #region [UOE発注データLogicalDelete]

        /// <summary>
        /// UOE発注データ情報を物理削除します
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE発注データ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns></returns>
        /// <br>Note       : UOE発注データ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井 亮太</br>
        /// <br>Date       : 2008.10.15</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        public int UOELogicalDelete(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.UOELogicalDeleteProc(ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// UOE発注データ情報を物理削除します
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE発注データ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns></returns>
        /// <br>Note       : UOE発注データ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井 亮太</br>
        /// <br>Date       : 2008.10.15</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.08.20 長内 DC.NS用に修正</br>
        private int UOELogicalDeleteProc(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            try
            {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    sqlText = "";
                    sqlText += "UPDATE UOEORDERDTLRF" + Environment.NewLine;
                    sqlText += " SET" + Environment.NewLine;
                    sqlText += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ANd SYSTEMDIVCDRF = 3" + Environment.NewLine;
                    sqlText += " AND DATASENDCODERF = 0" + Environment.NewLine;
                    sqlText += " AND DATARECOVERDIVRF = 0" + Environment.NewLine;
                    sqlText += " AND LOGICALDELETECODERF = 0" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    UOEOrderDtlWork uOEOrderDtlWork = new UOEOrderDtlWork();

                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)uOEOrderDtlWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    //Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uOEOrderDtlWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uOEOrderDtlWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uOEOrderDtlWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uOEOrderDtlWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(1);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEOrderDtlWork.EnterpriseCode);

                    sqlCommand.ExecuteNonQuery();
             
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }        
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region[仕入明細データDelete]
        /// <summary>
        /// 仕入明細データ情報のリストを取得します。
        /// </summary>
        /// <param name="uoeOrderDtlList">仕入明細データ情報を格納する ArrayList</param>
        /// <param name="uoeOrderDtlWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注データのキー値が一致する、全てのUOE発注データ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.15</br>
        public int SuppDelete(ArrayList uoeOrderDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SuppDeleteProc(uoeOrderDtlList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 仕入明細データ情報のリストを取得します。
        /// </summary>
        /// <param name="uoeOrderDtlList">仕入明細データ情報を格納する ArrayList</param>
        /// <param name="uoeOrderDtlWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE発注データのキー値が一致する、全てのUOE発注データ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.10.15</br>
        private int SuppDeleteProc(ArrayList uoeOrderDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlCommand sqlCommand = null;
            string retMsg = "";
            string retItemInfo = "";
            SqlEncryptInfo sqlEncryptInfo = null;
            ArrayList stockDetailList = new ArrayList();
            try
            {

                foreach(UOEOrderDtlWork uoeOrderDtlWork in uoeOrderDtlList)
                {
                    StockDetailWork stockDetailWork = new StockDetailWork();

                    stockDetailWork.EnterpriseCode = uoeOrderDtlWork.EnterpriseCode;
                    // -- UPD 2010/06/08 ------------------------------------>>>
                    //stockDetailWork.DtlRelationGuid = uoeOrderDtlWork.DtlRelationGuid;
                    stockDetailWork.StockSlipDtlNum = uoeOrderDtlWork.StockSlipDtlNum;
                    stockDetailWork.SupplierFormal = 2;
                    // -- UPD 2010/06/08 ------------------------------------<<<

                    stockDetailList.Add(stockDetailWork);
                }

                IOWriteMASIRDB _iOWriteMASIRDB = new IOWriteMASIRDB();

                status = _iOWriteMASIRDB.DeleteforOrderInput(ref stockDetailList, out retMsg, out retItemInfo,ref sqlConnection, ref sqlTransaction,ref  sqlEncryptInfo);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        
        //-----ADD pengjie 2013/03/14 REDMINE#34986 ----->>>>>
        /// <summary>
        /// 操作履歴ログ書き込み処理
        /// </summary>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="operateHisList">操作履歴リスト</param>
        /// <br>Note       : 操作履歴ログ書き込み処理を行います。</br>
        /// <br>Programmer : pengjie</br>
        /// <br>Date       : 2013.03.14</br>
        private void WriteOprtnHisLog(SqlConnection sqlConnection, string enterpriseCode, ArrayList operateHisList)
        {
            if (operateHisList != null && operateHisList.Count > 0)
            {
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                
                foreach (string operateHis in operateHisList)
                {
                    switch (operateHis)
                    {
                        // UOE発注データ検索開始
                        case UOE_ORDER_SEARCH_BEGIN:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "UOE発注データ", "抽出開始", "PMHAT02012R", 0);
                                break;
                            }
                        // UOE発注データ検索終了
                        case UOE_ORDER_SEARCH_END:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "UOE発注データ", "抽出終了", "PMHAT02012R", 0);
                                break;
                            }
                        // UOE発注データ論理削除開始
                        case UOE_ORDER_LOGICALDELETE_BEGIN:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "UOE発注データ", "論理削除開始", "PMHAT02012R", 0);
                                break;
                            }
                        // UOE発注データ論理削除終了
                        case UOE_ORDER_LOGICALDELETE_END:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "UOE発注データ", "論理削除終了", "PMHAT02012R", 0);
                                break;
                            }
                        // 仕入明細データ削除開始
                        case STOCKDETAIL_DELETE_BEGIN:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "仕入明細データ", "削除開始", "PMHAT02012R", 0);
                                break;
                            }
                        // 仕入明細データ削除終了
                        case STOCKDETAIL_DELETE_END:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "仕入明細データ", "削除終了", "PMHAT02012R", 0);
                                break;
                            }
                        // UOE発注データ登録開始
                        case UOE_ORDER_WRITE_BEGIN:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "UOE発注データ", "登録開始", "PMHAT02012R", 0);
                                break;
                            }
                        // UOE発注データ登録終了
                        case UOE_ORDER_WRITE_END:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "UOE発注データ", "登録終了", "PMHAT02012R", 0);
                                break;
                            }
                        // 仕入データ・明細データ登録開始
                        case STOCKSLIP_WRITE_BEGIN:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "仕入データ・明細データ", "登録開始", "PMHAT02012R", 0);
                                break;
                            }
                        // 仕入データ・明細データ登録終了
                        case STOCKSLIP_WRITE_END:
                            {
                                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, enterpriseCode, "仕入データ・明細データ", "登録終了", "PMHAT02012R", 0);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }
        //-----ADD pengjie 2013/03/14 REDMINE#34986 -----<<<<<
        #endregion
    }
}

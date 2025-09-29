//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   同期実行管理 リモートオブジェクト
//                  :   PMSCM00210R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   田建委
// Date             :   2014/08/01
//----------------------------------------------------------------------
// 管理番号  11670219-00 作成担当 : 陳艶丹
// 修 正 日  2020/06/18  修正内容 : PMKOBETSU-4005 ＥＢＥ対策
//----------------------------------------------------------------------
// Update Note      : 
//----------------------------------------------------------------------
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Data.SqlClient;


using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;// ADD 2020/06/18 陳艶丹 PMKOBETSU-4005

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 初回同期実行スレッド
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同期実行スレッド(即時)のオブジェクト</br>
    /// <br>Programmer : zhubj</br>
    /// <br>Date       : 2014/08/07</br>
    /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/06/18</br>
    /// </remarks>
    public class FirstSyncExecThreadDB : RemoteWithAppLockDB
    {
        private SyncExecWorkDB _worker;

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="worker"></param>
        public FirstSyncExecThreadDB(SyncExecWorkDB worker)
        {
            this._worker = worker;
        }

        /// <summary>
        /// 初回同期スレッド処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初回同期スレッド処理を行う。</br>
        /// <br>Programmer : 松本 宏紀</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        public void FirstSyncWork()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            while (this._worker.StaticFirstSyncDiv != 2)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                try
                {
                    //実行時間チェック!
                    if (this._worker.SyncWorkInfo.CheckFirstSyncExecTime())
                    {
                        status = this.SyncExecWorkProc();
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            this._worker.FirstSyncThreadWait();
                        }
                        else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this._worker.FirstSyncThreadWait();
                        }
                    }
                    else
                    {
                        this._worker.FirstSyncThreadWait();
                    }
                }
                catch (ThreadAbortException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    base.WriteErrorLog(e, "FirstSyncExecThreadDB.FirstSyncWork:" + e.Message);
                }
            }
            if (this._worker.StaticFirstSyncDiv == 2)
            {
                this._worker.SyncThreadWakeUp();
                this._worker.SyncBatchThreadWakeUp();
            }
        }

        /// <summary>
        /// 同期処理(初回)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        private int SyncExecWorkProc()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;
            SyncMngWork syncMng;
            ArrayList syncMngList = new ArrayList();
            List<string> keyColumnList = new List<string>();
            List<SyncReqDataWork> sendReqDataList = new List<SyncReqDataWork>();
            Dictionary<string, ColumnType> columnDict = new Dictionary<string, ColumnType>();
            string syncTableId = null;
            string syncTableIdForJson = null;
            long transactionId = 0;
            long dummyTransactionId;
            long updateDateTime = 0;
            int syncStatus = ReplicaDBAccessControl.STATUS_NORMAL;
            string syncMessage = "";
            int retryCount = 0;
            ReplicaDBAccessControl controller = new ReplicaDBAccessControl(this._worker.SyncAuthInfo.ToSyncBasicInfo());
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            // 変換情報呼び出し
            ConvertDoubleRelease convertDoubleRelease = new ConvertDoubleRelease();

            // 変換情報初期化
            convertDoubleRelease.ReleaseInitLib();
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                // トランザクションを開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);
                dummyTransactionId = this._worker.GetTransactionId(sqlConnection, sqlTransaction);
                try
                {
                    //対象テーブル全て処理するためのループ
                    while (syncStatus == ReplicaDBAccessControl.STATUS_NORMAL)
                    {
                        updateDateTime = 0;
                        #region テーブル情報取得
                        status = LoadFirstSyncItem(sqlConnection, sqlTransaction, ref transactionId, ref syncTableId);
                        syncTableIdForJson = this._worker.XmlSetting.GetSyncTableJsonId(syncTableId);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            break;
                        }
                        else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                        status = LoadDefineSchema(sqlConnection, sqlTransaction, syncTableId, keyColumnList, columnDict);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                        else if (columnDict.Count == 0)
                        {
                            return status;
                        }
                        #endregion

                        #region データ同期管理マスタ情報初期セット
                        syncMng = new SyncMngWork();
                        syncMng.EnterpriseCode = this._worker.SyncAuthInfo.EnterpriseCode;
                        syncMng.SyncTableID = syncTableId;
                        syncMng.LogicalDeleteCode = 2;
                        syncMng.LastSyncUpdDtTm = SyncExecWorkDB.DateTimeToYYYYMMDDHHMMSS(DateTime.Now);
                        syncMng.SyncTableName = this._worker.XmlSetting.GetSyncTableNm(syncTableId);
                        syncMng.LastDataUpdDate = updateDateTime;
                        syncMngList.Add(syncMng);
                        #endregion

                        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                        sqlReader = GetTableReader(sqlConnection, sqlTransaction, sqlCommand, transactionId, syncTableId, this._worker.SyncAuthInfo.EnterpriseCode);

                        SyncReqDataWork work = null;
                        bool isReal = false;
                        //行データ送信のためのループ
                        while (syncStatus == ReplicaDBAccessControl.STATUS_NORMAL && sqlReader.Read())
                        {
                            // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                            //work = CopyToSyncReqWorkFromReader(transactionId, syncTableId, keyColumnList, columnDict, ref sqlReader);
                            work = CopyToSyncReqWorkFromReader(transactionId, syncTableId, keyColumnList, columnDict, ref sqlReader, convertDoubleRelease);
                            // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
                            work.SyncTableID = syncTableIdForJson;
                            work.TransctId = dummyTransactionId;
                            retryCount = work.RetryCount;
                            updateDateTime = (updateDateTime < work.UpdateDateTime.Ticks) ? work.UpdateDateTime.Ticks : updateDateTime;
                            #region 最終更新日時取得
                            if (syncMng.LastDataUpdDate < SyncExecWorkDB.DateTimeToYYYYMMDDHHMMSS(work.UpdateDateTime))
                            {
                                syncMng.LastDataUpdDate = SyncExecWorkDB.DateTimeToYYYYMMDDHHMMSS(work.UpdateDateTime);
                            }
                            isReal = (work.SyncTableID == "Stock");
                            #endregion
                            sendReqDataList.Add(work);

                            //分割送信
                            if (sendReqDataList.Count >= this._worker.XmlSetting.DataSendLimitSize)
                            {
                                syncStatus = controller.SyncWrite(dummyTransactionId, sendReqDataList, isReal);
                                if (syncStatus != ReplicaDBAccessControl.STATUS_NORMAL)
                                {
                                    break;
                                }
                                sendReqDataList.Clear();
                            }
                        }
                        if (sendReqDataList.Count > 0)
                        {
                            syncStatus = controller.SyncWrite(dummyTransactionId, sendReqDataList, isReal);
                            sendReqDataList.Clear();
                        }
                        SyncExecWorkDB.CloseQuietly(sqlReader);
                        SyncExecWorkDB.CloseQuietly(sqlCommand);
                    }
                }
                catch (Exception ex2)
                {
                    syncStatus = 3000;
                    syncMessage = ex2.Message;
                    base.WriteErrorLog(ex2, "FirstSyncExecThreadDB.SyncExecWorkProc:" + ex2.Message);
                }
                finally
                {
                    if (sqlReader != null && !sqlReader.IsClosed)
                    {
                        sqlReader.Close();
                    }
                    // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                    // 解放
                    convertDoubleRelease.Dispose();
                    // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
                }
                //レプリカ同期要求

                #region 結果書き戻し
                if (syncStatus == ReplicaDBAccessControl.STATUS_NORMAL)
                {
                    status = SyncSuccessWorkProc(ref sqlConnection, ref sqlTransaction, this._worker.SyncAuthInfo.EnterpriseCode, transactionId, syncMngList);
                }
                else
                {
                    syncMessage = (controller != null) ? controller.ErrorMessage : "";
                    SyncFailWorkProc(ref sqlConnection, ref sqlTransaction, this._worker.SyncAuthInfo.EnterpriseCode, transactionId, syncStatus, syncMessage);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                #endregion
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                try
                {
                    if (sqlTransaction != null) sqlTransaction.Rollback();
                }
                catch
                {
                }
                base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                try
                {
                    if (sqlTransaction != null) sqlTransaction.Rollback();
                }
                catch
                {
                }
                base.WriteErrorLog(ex, "FirstSyncExecThreadDB.SyncExecWorkProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                SyncExecWorkDB.CloseQuietly(sqlReader);
                SyncExecWorkDB.CloseQuietly(sqlCommand);
                SyncExecWorkDB.CommitCloseQuietly(sqlTransaction, 0);//例外発生時以外はコミット
                SyncExecWorkDB.CloseQuietly(sqlConnection);
            }
            return status;
        }

        #region Private Method
        /// <summary>
        /// 同期対象基本情報(トランザクションID、テーブル名)を読み込みます。
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="transactionId"></param>
        /// <param name="syncTableId"></param>
        /// <returns></returns>
        public int LoadFirstSyncItem(SqlConnection sqlConnection, SqlTransaction sqlTransaction, ref long transactionId, ref string syncTableId)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            const string sqlText = " UPDATE SYNCREQDATARF  "
                                 + "   SET SYNCEXECRSLTRF=1 "
                                 + " OUTPUT inserted.SYNCTABLEIDRF,inserted.TRANSCTIDRF "
                                 + " FROM SYNCREQDATARF  AS SUB03 WITH(READUNCOMMITTED) "
                                 + " INNER JOIN ( "
                                 + "     SELECT "
                                 + "     TOP 1 * "
                                 + "     FROM SYNCREQDATARF AS SUB02 WITH(READUNCOMMITTED) "
                                 + "     WHERE SYNCTARGETDIVRF=2 "
                                 + "       AND ENTERPRISECODERF=@FINDENTERPRISECODE "
                                 + "       AND SYNCEXECRSLTRF!=1 "
                                 + "     ORDER BY CREATEDATETIMERF,SYNCTABLEIDRF "
                                 + " ) AS SUB04 ON "
                                 + "       SUB04.CREATEDATETIMERF = SUB03.CREATEDATETIMERF "
                                 + "   AND SUB04.ENTERPRISECODERF = SUB03.ENTERPRISECODERF "
                                 + "   AND SUB04.TRANSCTIDRF      = SUB03.TRANSCTIDRF "
                                 + "   AND SUB04.SYNCTABLEIDRF    = SUB03.SYNCTABLEIDRF "
                                 + "   AND SUB04.SYNCPROCDIVRF    = SUB03.SYNCPROCDIVRF "
                                 + "   AND SUB04.FILEHEADERGUIDRF = SUB03.FILEHEADERGUIDRF";
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;
            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                #region パラメータ設定
                //企業コード
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this._worker.SyncAuthInfo.EnterpriseCode);
                #endregion

                sqlReader = sqlCommand.ExecuteReader();
                if (sqlReader.Read())
                {
                    syncTableId = SqlDataMediator.SqlGetString(sqlReader, sqlReader.GetOrdinal("SYNCTABLEIDRF"));
                    transactionId = SqlDataMediator.SqlGetInt64(sqlReader, sqlReader.GetOrdinal("TRANSCTIDRF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                return status;
            }
            finally
            {
                SyncExecWorkDB.CloseQuietly(sqlReader);
                SyncExecWorkDB.CloseQuietly(sqlCommand);
            }
        }

        /// <summary>
        /// 項目情報取得
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="tableId"></param>
        /// <param name="keyColumnsList"></param>
        /// <param name="columnDict"></param>
        /// <returns></returns>
        public static int LoadDefineSchema(SqlConnection sqlConnection, SqlTransaction sqlTransaction, string tableId, List<string> keyColumnsList, Dictionary<string, ColumnType> columnDict)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            const string sqlText1 = " SELECT  "
                                + " COL.NAME AS COLNAME, "
                                + " TP.NAME  AS TYPENAME "
                                + " FROM sys.columns AS COL "
                                + " INNER JOIN sys.objects AS OBJ ON "
                                + " OBJ.OBJECT_ID = COL.OBJECT_ID "
                                + " INNER JOIN sys.types AS TP ON  "
                                + " TP.USER_TYPE_ID = COL.USER_TYPE_ID "
                                + " WHERE OBJ.NAME=@FINDTABLEID "
                                + " ;";
            const string sqlText2 = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME = @FINDTABLEID";
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;
            try
            {
                columnDict.Clear();
                keyColumnsList.Clear();

                #region 項目取得
                sqlCommand = new SqlCommand(sqlText1, sqlConnection, sqlTransaction);

                #region パラメータ設定
                //企業コード
                SqlParameter paraTableID = sqlCommand.Parameters.Add("@FINDTABLEID", SqlDbType.NVarChar);
                paraTableID.Value = SqlDataMediator.SqlSetString(tableId);
                #endregion

                sqlReader = sqlCommand.ExecuteReader();
                string colName;
                string typeName;
                while (sqlReader.Read())
                {
                    colName = SqlDataMediator.SqlGetString(sqlReader, sqlReader.GetOrdinal("COLNAME"));
                    typeName = SqlDataMediator.SqlGetString(sqlReader, sqlReader.GetOrdinal("TYPENAME"));
                    if (string.IsNullOrEmpty(typeName))
                    {
                        continue;
                    }
                    ////不要な共通ヘッダは無視
                    if (colName == "UPDEMPLOYEECODERF"
                        || colName == "UPDASSEMBLYID1RF"
                        || colName == "UPDASSEMBLYID2RF"
                        || colName == "FILEHEADERGUIDRF")
                    {
                        continue;
                    }
                    //★本当は設定ファイルから動的に読み込んだほうが良いが、ちょっと対応している時間が無い。
                    else if (tableId == "PRMSETTINGURF")
                    {
                        #region PRMSETTINGURF チェック
                        if (!(colName == "CREATEDATETIMERF"
                                || colName == "UPDATEDATETIMERF"
                                || colName == "ENTERPRISECODERF"
                                || colName == "FILEHEADERGUIDRF"
                                || colName == "UPDEMPLOYEECODERF"
                                || colName == "UPDASSEMBLYID1RF"
                                || colName == "UPDASSEMBLYID2RF"
                                || colName == "LOGICALDELETECODERF"
                                || colName == "SECTIONCODERF"
                                || colName == "GOODSMGROUPRF"
                                || colName == "TBSPARTSCODERF"
                                || colName == "TBSPARTSCDDERIVEDNORF"
                                || colName == "MAKERDISPORDERRF"
                                || colName == "PARTSMAKERCDRF"
                                || colName == "PRIMEDISPORDERRF"
                                || colName == "PRMSETDTLNO1RF"
                                || colName == "PRMSETDTLNAME1RF"
                                || colName == "PRMSETDTLNO2RF"
                                || colName == "PRMSETDTLNAME2RF"
                                || colName == "PRIMEDISPLAYCODERF"
                                || colName == "OFFERDATERF"
                                ))
                        {
                            continue;
                        }
                        #endregion
                    }
                    else if (tableId == "STOCKRF")
                    {
                        #region STOCKRF チェック
                        if (!(colName == "CREATEDATETIMERF"
                            || colName == "UPDATEDATETIMERF"
                            || colName == "ENTERPRISECODERF"
                            || colName == "FILEHEADERGUIDRF"
                            || colName == "UPDEMPLOYEECODERF"
                            || colName == "UPDASSEMBLYID1RF"
                            || colName == "UPDASSEMBLYID2RF"
                            || colName == "LOGICALDELETECODERF"
                            || colName == "SECTIONCODERF"
                            || colName == "WAREHOUSECODERF"
                            || colName == "GOODSMAKERCDRF"
                            || colName == "GOODSNORF"
                            || colName == "STOCKUNITPRICEFLRF"
                            || colName == "SUPPLIERSTOCKRF"
                            || colName == "ACPODRCOUNTRF"
                            || colName == "MONTHORDERCOUNTRF"
                            || colName == "SALESORDERCOUNTRF"
                            || colName == "STOCKDIVRF"
                            || colName == "MOVINGSUPLISTOCKRF"
                            || colName == "SHIPMENTPOSCNTRF"
                            || colName == "STOCKTOTALPRICERF"
                            || colName == "LASTSTOCKDATERF"
                            || colName == "LASTSALESDATERF"
                            || colName == "LASTINVENTORYUPDATERF"
                            || colName == "MINIMUMSTOCKCNTRF"
                            || colName == "MAXIMUMSTOCKCNTRF"
                            || colName == "NMLSALODRCOUNTRF"
                            || colName == "SALESORDERUNITRF"
                            || colName == "STOCKSUPPLIERCODERF"
                            || colName == "GOODSNONONEHYPHENRF"
                            || colName == "WAREHOUSESHELFNORF"
                            || colName == "DUPLICATIONSHELFNO1RF"
                            || colName == "DUPLICATIONSHELFNO2RF"
                            || colName == "PARTSMANAGEMENTDIVIDE1RF"
                            || colName == "PARTSMANAGEMENTDIVIDE2RF"
                            || colName == "STOCKNOTE1RF"
                            || colName == "STOCKNOTE2RF"
                            || colName == "SHIPMENTCNTRF"
                            || colName == "ARRIVALCNTRF"
                            || colName == "STOCKCREATEDATERF"
                            || colName == "UPDATEDATERF"))
                        {
                            continue;
                        }
                        #endregion
                    }
                    else if (tableId == "GOODSPRICEURF")
                    {
                        #region GOODSPRICEURF チェック
                        if (!(colName == "CREATEDATETIMERF"
                            || colName == "UPDATEDATETIMERF"
                            || colName == "ENTERPRISECODERF"
                            || colName == "FILEHEADERGUIDRF"
                            || colName == "UPDEMPLOYEECODERF"
                            || colName == "UPDASSEMBLYID1RF"
                            || colName == "UPDASSEMBLYID2RF"
                            || colName == "LOGICALDELETECODERF"
                            || colName == "GOODSMAKERCDRF"
                            || colName == "GOODSNORF"
                            || colName == "PRICESTARTDATERF"
                            || colName == "LISTPRICERF"
                            || colName == "SALESUNITCOSTRF"
                            || colName == "STOCKRATERF"
                            || colName == "OPENPRICEDIVRF"
                            || colName == "OFFERDATERF"
                            || colName == "UPDATEDATERF"
                            ))
                        {
                            continue;
                        }
                        #endregion
                    }
                    else if (tableId == "ISOLISLANDPRCRF")
                    {
                        #region ISOLISLANDPRCRFチェック
                        if (!(colName == "CREATEDATETIMERF"
                            || colName == "UPDATEDATETIMERF"
                            || colName == "ENTERPRISECODERF"
                            || colName == "FILEHEADERGUIDRF"
                            || colName == "UPDEMPLOYEECODERF"
                            || colName == "UPDASSEMBLYID1RF"
                            || colName == "UPDASSEMBLYID2RF"
                            || colName == "LOGICALDELETECODERF"
                            || colName == "SECTIONCODERF"
                            || colName == "MAKERCODERF"
                            || colName == "UPPERLIMITPRICERF"
                            || colName == "FRACTIONPROCUNITRF"
                            || colName == "FRACTIONPROCCDRF"
                            || colName == "UPRATERF"
                            ))
                        {
                            continue;
                        }
                        #endregion
                    }
                    else if (tableId == "AUTOANSITEMSTRF")
                    {
                        #region AUTOANSITEMSTRFチェック
                        if (!(colName == "CREATEDATETIMERF"
                            || colName == "UPDATEDATETIMERF"
                            || colName == "ENTERPRISECODERF"
                            || colName == "FILEHEADERGUIDRF"
                            || colName == "UPDEMPLOYEECODERF"
                            || colName == "UPDASSEMBLYID1RF"
                            || colName == "UPDASSEMBLYID2RF"
                            || colName == "LOGICALDELETECODERF"
                            || colName == "SECTIONCODERF"
                            || colName == "CUSTOMERCODERF"
                            || colName == "GOODSMGROUPRF"
                            || colName == "BLGOODSCODERF"
                            || colName == "GOODSMAKERCDRF"
                            || colName == "PRMSETDTLNO2RF"
                            || colName == "PRMSETDTLNAME2RF"
                            || colName == "AUTOANSWERDIVRF"
                            || colName == "PRIORITYORDERRF"
                            ))
                        {
                            continue;
                        }
                        #endregion
                    }
                    else if (tableId == "CUSTOMERRF")
                    {
                        #region CUSTOMERRFチェック
                        if (!(colName == "CREATEDATETIMERF"
                        || colName == "UPDATEDATETIMERF"
                        || colName == "ENTERPRISECODERF"
                        || colName == "FILEHEADERGUIDRF"
                        || colName == "UPDEMPLOYEECODERF"
                        || colName == "UPDASSEMBLYID1RF"
                        || colName == "UPDASSEMBLYID2RF"
                        || colName == "LOGICALDELETECODERF"
                        || colName == "CUSTOMERCODERF"
                        || colName == "CUSTOMERSUBCODERF"
                        || colName == "NAMERF"
                        || colName == "NAME2RF"
                        || colName == "HONORIFICTITLERF"
                        || colName == "KANARF"
                        || colName == "CUSTOMERSNMRF"
                        || colName == "OUTPUTNAMECODERF"
                        || colName == "OUTPUTNAMERF"
                        || colName == "CORPORATEDIVCODERF"
                        || colName == "CUSTOMERATTRIBUTEDIVRF"
                        || colName == "JOBTYPECODERF"
                        || colName == "BUSINESSTYPECODERF"
                        || colName == "SALESAREACODERF"
                        || colName == "POSTNORF"
                        || colName == "ADDRESS1RF"
                        || colName == "ADDRESS3RF"
                        || colName == "ADDRESS4RF"
                        || colName == "HOMETELNORF"
                        || colName == "OFFICETELNORF"
                        || colName == "PORTABLETELNORF"
                        || colName == "HOMEFAXNORF"
                        || colName == "OFFICEFAXNORF"
                        || colName == "OTHERSTELNORF"
                        || colName == "MAINCONTACTCODERF"
                        || colName == "SEARCHTELNORF"
                        || colName == "MNGSECTIONCODERF"
                        || colName == "INPSECTIONCODERF"
                        || colName == "CUSTANALYSCODE1RF"
                        || colName == "CUSTANALYSCODE2RF"
                        || colName == "CUSTANALYSCODE3RF"
                        || colName == "CUSTANALYSCODE4RF"
                        || colName == "CUSTANALYSCODE5RF"
                        || colName == "CUSTANALYSCODE6RF"
                        || colName == "BILLOUTPUTCODERF"
                        || colName == "BILLOUTPUTNAMERF"
                        || colName == "TOTALDAYRF"
                        || colName == "COLLECTMONEYCODERF"
                        || colName == "COLLECTMONEYNAMERF"
                        || colName == "COLLECTMONEYDAYRF"
                        || colName == "COLLECTCONDRF"
                        || colName == "COLLECTSIGHTRF"
                        || colName == "CLAIMCODERF"
                        || colName == "TRANSSTOPDATERF"
                        || colName == "DMOUTCODERF"
                        || colName == "DMOUTNAMERF"
                        || colName == "MAINSENDMAILADDRCDRF"
                        || colName == "MAILADDRKINDCODE1RF"
                        || colName == "MAILADDRKINDNAME1RF"
                        || colName == "MAILADDRESS1RF"
                        || colName == "MAILSENDCODE1RF"
                        || colName == "MAILSENDNAME1RF"
                        || colName == "MAILADDRKINDCODE2RF"
                        || colName == "MAILADDRKINDNAME2RF"
                        || colName == "MAILADDRESS2RF"
                        || colName == "MAILSENDCODE2RF"
                        || colName == "MAILSENDNAME2RF"
                        || colName == "CUSTOMERAGENTCDRF"
                        || colName == "BILLCOLLECTERCDRF"
                        || colName == "OLDCUSTOMERAGENTCDRF"
                        || colName == "CUSTAGENTCHGDATERF"
                        || colName == "ACCEPTWHOLESALERF"
                        || colName == "CREDITMNGCODERF"
                        || colName == "DEPODELCODERF"
                        || colName == "ACCRECDIVCDRF"
                        || colName == "CUSTSLIPNOMNGCDRF"
                        || colName == "PURECODERF"
                        || colName == "CUSTCTAXLAYREFCDRF"
                        || colName == "CONSTAXLAYMETHODRF"
                        || colName == "TOTALAMOUNTDISPWAYCDRF"
                        || colName == "TOTALAMNTDSPWAYREFRF"
                        || colName == "ACCOUNTNOINFO1RF"
                        || colName == "ACCOUNTNOINFO2RF"
                        || colName == "ACCOUNTNOINFO3RF"
                        || colName == "SALESUNPRCFRCPROCCDRF"
                        || colName == "SALESMONEYFRCPROCCDRF"
                        || colName == "SALESCNSTAXFRCPROCCDRF"
                        || colName == "CUSTOMERSLIPNODIVRF"
                        || colName == "NTIMECALCSTDATERF"
                        || colName == "CUSTOMERAGENTRF"
                        || colName == "CLAIMSECTIONCODERF"
                        || colName == "CARMNGDIVCDRF"
                        || colName == "BILLPARTSNOPRTCDRF"
                        || colName == "DELIPARTSNOPRTCDRF"
                        || colName == "DEFSALESSLIPCDRF"
                        || colName == "LAVORRATERANKRF"
                        || colName == "SLIPTTLPRNRF"
                        || colName == "DEPOBANKCODERF"
                        || colName == "CUSTWAREHOUSECDRF"
                        || colName == "QRCODEPRTCDRF"
                        || colName == "DELIHONORIFICTTLRF"
                        || colName == "BILLHONORIFICTTLRF"
                        || colName == "ESTMHONORIFICTTLRF"
                        || colName == "RECTHONORIFICTTLRF"
                        || colName == "DELIHONORTTLPRTDIVRF"
                        || colName == "BILLHONORTTLPRTDIVRF"
                        || colName == "ESTMHONORTTLPRTDIVRF"
                        || colName == "RECTHONORTTLPRTDIVRF"
                        || colName == "NOTE1RF"
                        || colName == "NOTE2RF"
                        || colName == "NOTE3RF"
                        || colName == "NOTE4RF"
                        || colName == "NOTE5RF"
                        || colName == "NOTE6RF"
                        || colName == "NOTE7RF"
                        || colName == "NOTE8RF"
                        || colName == "NOTE9RF"
                        || colName == "NOTE10RF"
                        || colName == "SALESSLIPPRTDIVRF"
                        || colName == "SHIPMSLIPPRTDIVRF"
                        || colName == "ACPODRRSLIPPRTDIVRF"
                        || colName == "ESTIMATEPRTDIVRF"
                        || colName == "UOESLIPPRTDIVRF"
                        || colName == "RECEIPTOUTPUTCODERF"
                        || colName == "CUSTOMEREPCODERF"
                        || colName == "CUSTOMERSECCODERF"
                        || colName == "ONLINEKINDDIVRF"
                        || colName == "TOTALBILLOUTPUTDIVRF"
                        || colName == "DETAILBILLOUTPUTCODERF"
                        || colName == "SLIPTTLBILLOUTPUTDIVRF"
                        || colName == "SIMPLINQACNTACNTGRIDRF"
                        ))
                        {
                            continue;
                        }
                        #endregion
                    }
                    else if (tableId == "GOODSURF")
                    {
                        #region GOODSURFチェック
                        if (!(colName == "CREATEDATETIMERF"
                            || colName == "UPDATEDATETIMERF"
                            || colName == "ENTERPRISECODERF"
                            || colName == "FILEHEADERGUIDRF"
                            || colName == "UPDEMPLOYEECODERF"
                            || colName == "UPDASSEMBLYID1RF"
                            || colName == "UPDASSEMBLYID2RF"
                            || colName == "LOGICALDELETECODERF"
                            || colName == "GOODSMAKERCDRF"
                            || colName == "GOODSNORF"
                            || colName == "GOODSNAMERF"
                            || colName == "GOODSNAMEKANARF"
                            || colName == "JANRF"
                            || colName == "BLGOODSCODERF"
                            || colName == "DISPLAYORDERRF"
                            || colName == "GOODSRATERANKRF"
                            || colName == "TAXATIONDIVCDRF"
                            || colName == "GOODSNONONEHYPHENRF"
                            || colName == "OFFERDATERF"
                            || colName == "GOODSKINDCODERF"
                            || colName == "GOODSNOTE1RF"
                            || colName == "GOODSNOTE2RF"
                            || colName == "GOODSSPECIALNOTERF"
                            || colName == "ENTERPRISEGANRECODERF"
                            || colName == "UPDATEDATERF"
                            || colName == "OFFERDATADIVRF"
                            ))
                        {
                            continue;
                        }
                        #endregion
                    }
                    else if (tableId == "BLGOODSCDURF")
                    {
                        #region BLGOODSCDURFチェック
                        if (!(colName == "CREATEDATETIMERF"
                            || colName == "UPDATEDATETIMERF"
                            || colName == "ENTERPRISECODERF"
                            || colName == "FILEHEADERGUIDRF"
                            || colName == "UPDEMPLOYEECODERF"
                            || colName == "UPDASSEMBLYID1RF"
                            || colName == "UPDASSEMBLYID2RF"
                            || colName == "LOGICALDELETECODERF"
                            || colName == "BLGROUPCODERF"
                            || colName == "BLGOODSCODERF"
                            || colName == "BLGOODSFULLNAMERF"
                            || colName == "BLGOODSHALFNAMERF"
                            || colName == "BLGOODSGENRECODERF"
                            || colName == "GOODSRATEGRPCODERF"
                            || colName == "OFFERDATERF"
                            || colName == "OFFERDATADIVRF"
                            ))
                        {
                            continue;
                        }
                        #endregion
                    }
                    else if (tableId == "BLGROUPURF")
                    {
                        #region BLGROUPURFチェック
                        if (!(colName == "CREATEDATETIMERF"
                            || colName == "UPDATEDATETIMERF"
                            || colName == "ENTERPRISECODERF"
                            || colName == "FILEHEADERGUIDRF"
                            || colName == "UPDEMPLOYEECODERF"
                            || colName == "UPDASSEMBLYID1RF"
                            || colName == "UPDASSEMBLYID2RF"
                            || colName == "LOGICALDELETECODERF"
                            || colName == "GOODSLGROUPRF"
                            || colName == "GOODSMGROUPRF"
                            || colName == "BLGROUPCODERF"
                            || colName == "BLGROUPNAMERF"
                            || colName == "BLGROUPKANANAMERF"
                            || colName == "SALESCODERF"
                            || colName == "OFFERDATERF"
                            || colName == "OFFERDATADIVRF"
                            ))
                        {
                            continue;
                        }
                        #endregion
                    }
                    else if (tableId == "BLGROUPURF")
                    {
                        #region BLGROUPURFチェック
                        if (!(colName == "CREATEDATETIMERF"
                            || colName == "UPDATEDATETIMERF"
                            || colName == "ENTERPRISECODERF"
                            || colName == "FILEHEADERGUIDRF"
                            || colName == "UPDEMPLOYEECODERF"
                            || colName == "UPDASSEMBLYID1RF"
                            || colName == "UPDASSEMBLYID2RF"
                            || colName == "LOGICALDELETECODERF"
                            || colName == "GOODSLGROUPRF"
                            || colName == "GOODSMGROUPRF"
                            || colName == "BLGROUPCODERF"
                            || colName == "BLGROUPNAMERF"
                            || colName == "BLGROUPKANANAMERF"
                            || colName == "SALESCODERF"
                            || colName == "OFFERDATERF"
                            || colName == "OFFERDATADIVRF"
                            ))
                        {
                            continue;
                        }
                        #endregion
                    }
                    else if (tableId == "SCMDELIDATESTRF")
                    {
                        #region SCMDELIDATESTRFチェック
                        if (!(colName == "CREATEDATETIMERF"
                            || colName == "UPDATEDATETIMERF"
                            || colName == "ENTERPRISECODERF"
                            || colName == "FILEHEADERGUIDRF"
                            || colName == "UPDEMPLOYEECODERF"
                            || colName == "UPDASSEMBLYID1RF"
                            || colName == "UPDASSEMBLYID2RF"
                            || colName == "LOGICALDELETECODERF"
                            || colName == "SECTIONCODERF"
                            || colName == "CUSTOMERCODERF"
                            || colName == "ANSWERDEADTIME1RF"
                            || colName == "ANSWERDEADTIME2RF"
                            || colName == "ANSWERDEADTIME3RF"
                            || colName == "ANSWERDEADTIME4RF"
                            || colName == "ANSWERDEADTIME5RF"
                            || colName == "ANSWERDEADTIME6RF"
                            || colName == "ANSWERDELIVDATE1RF"
                            || colName == "ANSWERDELIVDATE2RF"
                            || colName == "ANSWERDELIVDATE3RF"
                            || colName == "ANSWERDELIVDATE4RF"
                            || colName == "ANSWERDELIVDATE5RF"
                            || colName == "ANSWERDELIVDATE6RF"
                            || colName == "ANSWERDEADTIME1STCRF"
                            || colName == "ANSWERDEADTIME2STCRF"
                            || colName == "ANSWERDEADTIME3STCRF"
                            || colName == "ANSWERDEADTIME4STCRF"
                            || colName == "ANSWERDEADTIME5STCRF"
                            || colName == "ANSWERDEADTIME6STCRF"
                            || colName == "ANSWERDELIVDATE1STCRF"
                            || colName == "ANSWERDELIVDATE2STCRF"
                            || colName == "ANSWERDELIVDATE3STCRF"
                            || colName == "ANSWERDELIVDATE4STCRF"
                            || colName == "ANSWERDELIVDATE5STCRF"
                            || colName == "ANSWERDELIVDATE6STCRF"
                            || colName == "ENTSTCKANSDELIDTDIVRF"
                            || colName == "ENTSTCKANSDELIDATERF"
                            || colName == "PRISTCKANSDELIDTDIVRF"
                            || colName == "PRISTCKANSDELIDATERF"
                            || colName == "ANSDELDATSHORTOFSTCRF"
                            || colName == "ANSDELDATWITHOUTSTCRF"
                            || colName == "ENTSTCANSDELDATSHORTRF"
                            || colName == "ENTSTCANSDELDATWIOUTRF"
                            || colName == "PRISTCANSDELDATSHORTRF"
                            || colName == "PRISTCANSDELDATWIOUTRF"
                            || colName == "ANSDELDTDIV1RF"
                            || colName == "ANSDELDTDIV2RF"
                            || colName == "ANSDELDTDIV3RF"
                            || colName == "ANSDELDTDIV4RF"
                            || colName == "ANSDELDTDIV5RF"
                            || colName == "ANSDELDTDIV6RF"
                            || colName == "ANSDELDTDIV1STCRF"
                            || colName == "ANSDELDTDIV2STCRF"
                            || colName == "ANSDELDTDIV3STCRF"
                            || colName == "ANSDELDTDIV4STCRF"
                            || colName == "ANSDELDTDIV5STCRF"
                            || colName == "ANSDELDTDIV6STCRF"
                            || colName == "ENTANSDELDTSTCDIVRF"
                            || colName == "PRIANSDELDTSTCDIVRF"
                            || colName == "ANSDELDTSHOSTCDIVRF"
                            || colName == "ANSDELDTWIOSTCDIVRF"
                            || colName == "ENTANSDELDTSHODIVRF"
                            || colName == "ENTANSDELDTWIODIVRF"
                            || colName == "PRIANSDELDTSHODIVRF"
                            || colName == "PRIANSDELDTWIODIVRF"
                            ))
                        {
                            continue;
                        }
                        #endregion
                    }
                    typeName = typeName.ToUpper();
                    if (typeName == "INT")
                    {
                        columnDict.Add(colName, ColumnType.INT);
                    }
                    else if (typeName == "SMALLINT")
                    {
                        columnDict.Add(colName, ColumnType.SMALLINT);
                    }
                    else if (typeName == "FLOAT")
                    {
                        columnDict.Add(colName, ColumnType.FLOAT);
                    }
                    else if (typeName == "BIGINT")
                    {
                        columnDict.Add(colName, ColumnType.BIGINT);
                    }
                    else if (typeName == "NVARCHAR")
                    {
                        columnDict.Add(colName, ColumnType.NVARCHAR);
                    }
                    else if (typeName == "NCHAR")
                    {
                        columnDict.Add(colName, ColumnType.NCHAR);
                    }
                    else if (typeName == "UNIQUEIDENTIFIER")
                    {
                        columnDict.Add(colName, ColumnType.UNIQUEIDENTIFIER);
                    }
                    else
                    {
                        continue;
                    }
                }
                sqlReader.Close();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                if (columnDict.Count == 0)
                {
                    return status;
                }
                #endregion

                #region PK項目取得
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = sqlText2;

                #region パラメータ設定
                paraTableID = sqlCommand.Parameters.Add("@FINDTABLEID", SqlDbType.NVarChar);
                paraTableID.Value = SqlDataMediator.SqlSetString(tableId);
                #endregion

                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    keyColumnsList.Add(SqlDataMediator.SqlGetString(sqlReader, sqlReader.GetOrdinal("COLUMN_NAME")));
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                #endregion
                return status;
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }
        }

        /// <summary>
        /// 対象テーブルの全項目を読み込むSqlDataReaderを返します。
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="transactionId"></param>
        /// <param name="tableId"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public static SqlDataReader GetTableReader(SqlConnection sqlConnection, SqlTransaction sqlTransaction, SqlCommand sqlCommand, long transactionId, string tableId, string enterpriseCode)
        {
            // 対象テーブルデータを全て取得
            sqlCommand.CommandText = "SELECT * FROM " + tableId + " WITH(READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";

            //企業コード
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            return sqlCommand.ExecuteReader();
        }

        /// <summary>
        /// 検索結果の格納
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="syncTableId"></param>
        /// <param name="keyColumnList"></param>
        /// <param name="columnDict"></param>
        /// <param name="myReader"></param>
        /// <param name="convertDoubleRelease">数値変換処理</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: PMKOBETSU-4005 ＥＢＥ対策</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/06/18</br>
        /// </remarks>
        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
        //public static SyncReqDataWork CopyToSyncReqWorkFromReader(long transactionId, string syncTableId, List<string> keyColumnList, Dictionary<string, ColumnType> columnDict, ref SqlDataReader myReader)
        public static SyncReqDataWork CopyToSyncReqWorkFromReader(long transactionId, string syncTableId, List<string> keyColumnList, Dictionary<string, ColumnType> columnDict, ref SqlDataReader myReader, ConvertDoubleRelease convertDoubleRelease)
        // --- UPD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
        {
            SyncReqDataWork syncReqWork = new SyncReqDataWork();
            # region クラスへ格納
            syncReqWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            syncReqWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            syncReqWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            syncReqWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            syncReqWork.TransctId = transactionId;
            syncReqWork.SyncTableID = syncTableId;
            syncReqWork.SyncReqDiv = 1;
            ColumnType colType;
            StringBuilder keyItemIdBuilder = new StringBuilder();
            StringBuilder keyItemVlBuilder = new StringBuilder();
            StringBuilder updItemIdBuilder = new StringBuilder();
            StringBuilder updItemVlBuilder = new StringBuilder();
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
            // メーカーコード
            int goodsMakerCd = 0;
            // 品番
            string goodNo = string.Empty;

            // 価格マスタのみの場合
            if (syncTableId.Equals("GOODSPRICEURF"))
            {
                foreach (string columnName in columnDict.Keys)
                {
                    // メーカーコード
                    if (columnName.Equals("GOODSMAKERCDRF"))
                    {
                        goodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    }
                    // 品番
                    else if (columnName.Equals("GOODSNORF"))
                    {
                        goodNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    }
                }
            }
            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
            foreach (string columnName in columnDict.Keys)
            {
                colType = columnDict[columnName];
                if (keyColumnList.Contains(columnName))
                {
                    switch (colType)
                    {
                        case ColumnType.BIGINT:
                            keyItemIdBuilder.Append(columnName).Append('\t');
                            keyItemVlBuilder.Append(SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(columnName))).Append('\t');
                            break;
                        case ColumnType.INT:
                            keyItemIdBuilder.Append(columnName).Append('\t');
                            keyItemVlBuilder.Append(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(columnName))).Append('\t');
                            break;
                        case ColumnType.SMALLINT:
                            keyItemIdBuilder.Append(columnName).Append('\t');
                            keyItemVlBuilder.Append(SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal(columnName))).Append('\t');
                            break;
                        case ColumnType.FLOAT:
                            keyItemIdBuilder.Append(columnName).Append('\t');
                            keyItemVlBuilder.Append(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(columnName))).Append('\t');
                            break;
                        case ColumnType.NVARCHAR:
                        case ColumnType.NCHAR:
                            keyItemIdBuilder.Append(columnName).Append('\t');
                            keyItemVlBuilder.Append('"').Append(SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(columnName)).Replace('\t', ' ').Replace("\"", "\"\"")).Append('"').Append('\t');
                            break;
                        case ColumnType.UNIQUEIDENTIFIER:
                            keyItemIdBuilder.Append(columnName).Append('\t');
                            keyItemVlBuilder.Append('"').Append(SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(columnName)).ToString()).Append('"').Append('\t');
                            break;
                        default:
                            break;
                    }
                }
                switch (colType)
                {
                    case ColumnType.BIGINT:
                        updItemIdBuilder.Append(columnName).Append('\t');
                        updItemVlBuilder.Append(SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(columnName))).Append('\t');
                        break;
                    case ColumnType.INT:
                        updItemIdBuilder.Append(columnName).Append('\t');
                        updItemVlBuilder.Append(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(columnName))).Append('\t');
                        break;
                    case ColumnType.SMALLINT:
                        updItemIdBuilder.Append(columnName).Append('\t');
                        updItemVlBuilder.Append(SqlDataMediator.SqlGetInt16(myReader, myReader.GetOrdinal(columnName))).Append('\t');
                        break;
                    case ColumnType.FLOAT:
                        updItemIdBuilder.Append(columnName).Append('\t');
                        // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ---------->>>>>
                        if (syncTableId.Equals("GOODSPRICEURF") && columnName.Equals("LISTPRICERF"))
                        {
                            convertDoubleRelease.EnterpriseCode = syncReqWork.EnterpriseCode;
                            convertDoubleRelease.GoodsMakerCd = goodsMakerCd;
                            convertDoubleRelease.GoodsNo = goodNo;
                            convertDoubleRelease.ConvertSetParam = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(columnName));

                            // 変換処理実行
                            convertDoubleRelease.ReleaseProc();

                            updItemVlBuilder.Append(convertDoubleRelease.ConvertInfParam.ConvertGetParam).Append('\t');
                        }
                        else
                        {
                            // --- ADD 2020/06/18 陳艶丹 PMKOBETSU-4005 ----------<<<<<
                            updItemVlBuilder.Append(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(columnName))).Append('\t');
                        }// ADD 2020/06/18 陳艶丹 PMKOBETSU-4005
                        break;
                    case ColumnType.NVARCHAR:
                    case ColumnType.NCHAR:
                        updItemIdBuilder.Append(columnName).Append('\t');
                        updItemVlBuilder.Append('"').Append(SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(columnName)).Replace('\t', ' ').Replace("\"", "\"\"")).Append('"').Append('\t');
                        break;
                    case ColumnType.UNIQUEIDENTIFIER:
                        updItemIdBuilder.Append(columnName).Append('\t');
                        updItemVlBuilder.Append('"').Append(SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(columnName)).ToString()).Append('"').Append('\t');
                        break;
                    default:
                        break;
                }
            }
            if (keyItemVlBuilder.Length > 0)
            {
                keyItemVlBuilder.Remove(keyItemVlBuilder.Length - 1, 1);
            }
            if (updItemVlBuilder.Length > 0)
            {
                updItemVlBuilder.Remove(updItemVlBuilder.Length - 1, 1);
            }

            syncReqWork.SyncObjRecKeyItmId = keyItemIdBuilder.ToString();
            syncReqWork.SyncObjRecKeyVal = keyItemVlBuilder.ToString();
            syncReqWork.SyncObjRecUpdItmId = updItemIdBuilder.ToString();
            syncReqWork.SyncObjRecUpdVal = updItemVlBuilder.ToString();
            syncReqWork.SyncExecRslt = 0;
            syncReqWork.SyncProcDiv = 1;
            syncReqWork.SyncTargetDiv = 2;
            syncReqWork.RetryCount = 0;
            syncReqWork.ErrorStatus = 0;
            syncReqWork.ErrorContents = "";
            #endregion
            return syncReqWork;
        }

        /// <summary>
        /// 同期処理成功処理。
        /// 同期要求データを削除します。
        /// そして同期管理マスタの対象レコードを追加します。
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="transactionId"></param>
        /// <param name="dbSyncMngList"></param>
        /// <returns></returns>
        private int SyncSuccessWorkProc(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string enterpriseCode, long transactionId, ArrayList dbSyncMngList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            const string deleteSyncDataSql = "DELETE FROM SYNCREQDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TRANSCTIDRF=@FINDTRANSCTID";
            try
            {
                #region 同期要求データの削除
                sqlCommand = new SqlCommand(deleteSyncDataSql, sqlConnection, sqlTransaction);

                #region パラメータ設定
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaTransctId = sqlCommand.Parameters.Add("@FINDTRANSCTID", SqlDbType.BigInt);

                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaTransctId.Value = SqlDataMediator.SqlSetInt64(transactionId);
                #endregion

                sqlCommand.ExecuteNonQuery();
                #endregion

                #region 同期管理マスタの更新
                // 同期管理マスタ更新
                status = this._worker.WorkerSynchConfirmDB.WriteSyncMngData(ref dbSyncMngList, ref sqlConnection, ref sqlTransaction);
                #endregion

                #region 同期状態更新
                this._worker.UpdateStaticFirstSyncDiv();
                #endregion
            }
            finally
            {
                SyncExecWorkDB.CloseQuietly(sqlCommand);
            }
            return status;
        }

        /// <summary>
        /// 同期処理失敗処理。
        /// 同期要求データにエラー情報を出力します。
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="transactionId"></param>
        /// <param name="errorStatus"></param>
        /// <param name="errorContents"></param>
        /// <returns></returns>
        private int SyncFailWorkProc(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, string enterpriseCode, long transactionId, int errorStatus, string errorContents)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            const string updateSyncDataSql = " UPDATE SYNCREQDATARF "
                                           + "    SET SYNCEXECRSLTRF=2, "
                                           + " RETRYCOUNTRF=RETRYCOUNTRF+1, "
                                           + " ERRORSTATUSRF=@ERRORSTATUS, "
                                           + " ERRORCONTENTSRF=@ERRORCONTENTS "
                                           + " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TRANSCTIDRF=@FINDTRANSCTID ";
            try
            {
                #region 同期要求データの削除
                sqlCommand = new SqlCommand(updateSyncDataSql, sqlConnection, sqlTransaction);

                #region パラメータ設定
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaTransctId = sqlCommand.Parameters.Add("@FINDTRANSCTID", SqlDbType.BigInt);
                SqlParameter paraErrorStatus = sqlCommand.Parameters.Add("@ERRORSTATUS", SqlDbType.Int);
                SqlParameter paraErrorContents = sqlCommand.Parameters.Add("@ERRORCONTENTS", SqlDbType.NVarChar);

                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaTransctId.Value = SqlDataMediator.SqlSetInt64(transactionId);
                paraErrorStatus.Value = SqlDataMediator.SqlSetInt32(errorStatus);
                paraErrorContents.Value = SqlDataMediator.SqlSetString(errorContents);
                #endregion

                sqlCommand.ExecuteNonQuery();
                #endregion

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            finally
            {
                SyncExecWorkDB.CloseQuietly(sqlCommand);
            }
            return status;
        }

        /// <summary>
        /// SqlConnectionオブジェクトを生成します。
        /// </summary>
        /// <returns>SqlConnectionオブジェクト、もしくはnull</returns>
        /// <remarks>
        /// <br>Programmer : 松本宏紀</br>
        /// <br>Date       : 2014/08/25</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            string connectionText = this._worker.SyncAuthInfo.UserDbConnectionText;
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ColumnType
    {
        /// <summary>SMALLINT型</summary>
        SMALLINT,
        /// <summary>INT型</summary>
        INT,
        /// <summary>BIGINT型</summary>
        BIGINT,
        /// <summary>FLOAT型</summary>
        FLOAT,
        /// <summary>NVARCHAR型</summary>
        NVARCHAR,
        /// <summary>NCHAR型</summary>
        NCHAR,
        /// <summary>UNIQUEIDENTIFIER型</summary>
        UNIQUEIDENTIFIER,

    }
}

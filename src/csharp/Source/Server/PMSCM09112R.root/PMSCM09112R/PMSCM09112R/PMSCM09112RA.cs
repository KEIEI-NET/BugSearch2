using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 同期状態表示端末設定DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同期状態表示端末設定の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉超</br>
    /// <br>Date       : 2014/08/18</br>
    /// <br></br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SyncStateDspTermStDB : RemoteDB, ISyncStateDspTermStDB
    {
        /// <summary>
        /// 同期状態表示端末設定DBリモートオブジェクト
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 劉超</br>														   
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        public SyncStateDspTermStDB()
            :
        base("PMSCM09115D", "Broadleaf.Application.Remoting.ParamData.SyncStateDspTermStWork", "SYNCSTATEDSPTERMSTRF")
        {
        }

        #region [Write]
        /// <summary>
        /// 同期状態表示端末設定情報を登録、更新します
        /// </summary>
        /// <param name="syncStateDspTermStWork">SyncStateDspTermStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 同期状態表示端末設定情報を登録、更新します</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        public int Write(ref object syncStateDspTermStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(syncStateDspTermStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSyncStateProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                syncStateDspTermStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SyncStateDspTermStDB.Write(ref object syncStateDspTermStWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 同期状態表示端末設定情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">SyncStateDspTermStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 同期状態表示端末設定情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// <br></br>
        /// <br></br>
        public int WriteSyncStateProc(ref ArrayList syncStateDspTermStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteSyncStateProcProc(ref syncStateDspTermStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 同期状態表示端末設定情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">SyncStateDspTermStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 同期状態表示端末設定情報を登録、更新します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// <br></br>
        private int WriteSyncStateProcProc( ref ArrayList syncStateDspTermStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlText = string.Empty;
            try
            {
                if (syncStateDspTermStWorkList != null)
                {
                    for (int i = 0; i < syncStateDspTermStWorkList.Count; i++)
                    {
                        SyncStateDspTermStWork syncStateDspTermStWork = syncStateDspTermStWorkList[i] as SyncStateDspTermStWork;

                        //  条件から拠点コード(SectionCode)をはずす
                        //Selectコマンドの生成
                        sqlText = string.Empty;
                        sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CASHREGISTERNORF FROM SYNCSTATEDSPTERMSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.SectionCode);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt(syncStateDspTermStWork.CashRegisterNo);
                        //タイムアウト時間の設定（秒）
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != syncStateDspTermStWork.UpdateDateTime)
                            {
                                string _sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); //拠点コード
                                //新規登録で該当データ有りの場合には重複
                                if (syncStateDspTermStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで拠点コード違いの場合は重複 
                                else if (_sectionCode != syncStateDspTermStWork.SectionCode) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlText = string.Empty;
                            sqlText += "UPDATE SYNCSTATEDSPTERMSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , CASHREGISTERNORF=@CASHREGISTERNO WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.SectionCode);
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.CashRegisterNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)syncStateDspTermStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (syncStateDspTermStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO SYNCSTATEDSPTERMSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CASHREGISTERNORF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @CASHREGISTERNO)" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)syncStateDspTermStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncStateDspTermStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncStateDspTermStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(syncStateDspTermStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.SectionCode);
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.CashRegisterNo);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(syncStateDspTermStWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            syncStateDspTermStWorkList = al;

            return status;
        }
        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の同期状態表示端末設定戻りデータ情報LISTを戻します
        /// </summary>
        /// <param name="syncStateDspTermStWork">検索結果</param>
        /// <param name="parseSyncStateDspTermStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の同期状態表示端末設定戻りデータ情報LISTを戻します</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        public int Search(out object syncStateDspTermStWork, object parseSyncStateDspTermStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            syncStateDspTermStWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSyncStateProc(out syncStateDspTermStWork, parseSyncStateDspTermStWork, readMode, logicalMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SyncStateDspTermStDB.Search");
                syncStateDspTermStWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の同期状態表示端末設定戻りデータ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objsyncStateDspTermStWork">検索結果</param>
        /// <param name="parasyncStateDspTermStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の同期状態表示端末設定戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        public int SearchSyncStateProc(out object objsyncStateDspTermStWork, object parasyncStateDspTermStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SyncStateDspTermStWork syncStateDspTermStWork = null;

            ArrayList syncStateDspTermStWorkList = parasyncStateDspTermStWork as ArrayList;
            if (syncStateDspTermStWorkList == null)
            {
                syncStateDspTermStWork = parasyncStateDspTermStWork as SyncStateDspTermStWork;
            }
            else
            {
                if (syncStateDspTermStWorkList.Count > 0)
                    syncStateDspTermStWork = syncStateDspTermStWorkList[0] as SyncStateDspTermStWork;
            }

            int status = SearchSyncStateProc(out syncStateDspTermStWorkList, syncStateDspTermStWork, readMode, logicalMode, ref sqlConnection);
            objsyncStateDspTermStWork = syncStateDspTermStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の同期状態表示端末設定戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">検索結果</param>
        /// <param name="syncStateDspTermStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        public int SearchSyncStateProc(out ArrayList syncStateDspTermStWorkList, SyncStateDspTermStWork syncStateDspTermStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchSyncStateProcProc(out syncStateDspTermStWorkList, syncStateDspTermStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の同期状態表示端末設定戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">検索結果</param>
        /// <param name="syncStateDspTermStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のe-JIBAI戻りデータ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        private int SearchSyncStateProcProc( out ArrayList syncStateDspTermStWorkList, SyncStateDspTermStWork syncStateDspTermStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT SYNCSTATE.CREATEDATETIMERF ,SYNCSTATE.UPDATEDATETIMERF ,SYNCSTATE.ENTERPRISECODERF ,SYNCSTATE.FILEHEADERGUIDRF ,SYNCSTATE.UPDEMPLOYEECODERF ,SYNCSTATE.UPDASSEMBLYID1RF ,SYNCSTATE.UPDASSEMBLYID2RF ,SYNCSTATE.LOGICALDELETECODERF ,SYNCSTATE.SECTIONCODERF ,SYNCSTATE.CASHREGISTERNORF FROM SYNCSTATEDSPTERMSTRF AS SYNCSTATE WITH (READUNCOMMITTED) LEFT JOIN SECINFOSETRF AS SECINF WITH (READUNCOMMITTED) ON SECINF.ENTERPRISECODERF = SYNCSTATE.ENTERPRISECODERF AND SECINF.SECTIONCODERF = SYNCSTATE.SECTIONCODERF  AND SECINF.LOGICALDELETECODERF = 0 LEFT JOIN POSTERMINALMGRF AS POST WITH (READUNCOMMITTED) ON POST.ENTERPRISECODERF = SYNCSTATE.ENTERPRISECODERF AND POST.CASHREGISTERNORF = SYNCSTATE.CASHREGISTERNORF AND POST.LOGICALDELETECODERF = 0 WHERE SYNCSTATE.ENTERPRISECODERF = @FINDENTERPRISECODE ORDER BY SECTIONCODERF, CASHREGISTERNORF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                //タイムアウト時間の設定（秒）
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSyncStateDspTermStWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            syncStateDspTermStWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 同期状態表示端末設定戻りデータ情報を論理削除します
        /// </summary>
        /// <param name="syncStateDspTermStWork">SyncStateDspTermStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 同期状態表示端末設定戻りデータ情報を論理削除します</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        public int LogicalDelete(ref object syncStateDspTermStWork)
        {
            return LogicalDeleteSyncState(ref syncStateDspTermStWork, 0);
        }

        /// <summary>
        /// 論理削除同期状態表示端末設定戻りデータ情報を復活します
        /// </summary>
        /// <param name="syncStateDspTermStWork">SyncStateDspTermStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除同期状態表示端末設定戻りデータ情報を復活します</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        public int RevivalLogicalDelete(ref object syncStateDspTermStWork)
        {
            return LogicalDeleteSyncState(ref syncStateDspTermStWork, 1);
        }

        /// <summary>
        /// 同期状態表示端末設定戻りデータ情報の論理削除を操作します
        /// </summary>
        /// <param name="syncStateDspTermStWork">SyncStateDspTermStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 同期状態表示端末設定戻りデータ情報の論理削除を操作します</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        private int LogicalDeleteSyncState(ref object syncStateDspTermStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(syncStateDspTermStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSyncStateProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "SyncStateDspTermStDB.LogicalDeleteCarrier :" + procModestr);

                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 同期状態表示端末設定戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">SyncStateDspTermStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 同期状態表示端末設定戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        public int LogicalDeleteSyncStateProc(ref ArrayList syncStateDspTermStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSyncStateProcProc(ref syncStateDspTermStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 同期状態表示端末設定戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">SyncStateDspTermStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 同期状態表示端末設定戻りデータ情報の論理削除を操作します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        private int LogicalDeleteSyncStateProcProc( ref ArrayList syncStateDspTermStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlText = string.Empty;
            try
            {
                if (syncStateDspTermStWorkList != null)
                {
                    for (int i = 0; i < syncStateDspTermStWorkList.Count; i++)
                    {
                        SyncStateDspTermStWork syncStateDspTermStWork = syncStateDspTermStWorkList[i] as SyncStateDspTermStWork;

                        //Selectコマンドの生成
                        sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CASHREGISTERNORF FROM SYNCSTATEDSPTERMSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                        sqlText = string.Empty;

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.SectionCode);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.CashRegisterNo);
                        //タイムアウト時間の設定（秒）
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != syncStateDspTermStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlText += "UPDATE SYNCSTATEDSPTERMSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME, UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.SectionCode);
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.CashRegisterNo);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)syncStateDspTermStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) syncStateDspTermStWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else syncStateDspTermStWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) syncStateDspTermStWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncStateDspTermStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(syncStateDspTermStWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            syncStateDspTermStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 同期状態表示端末設定戻りデータ情報を物理削除します
        /// </summary>
        /// <param name="paraobj">同期状態表示端末設定戻りデータ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 同期状態表示端末設定戻りデータ情報を物理削除します</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        public int Delete(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(paraobj);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteSyncStateProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SyncStateDspTermStDB.Delete");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 同期状態表示端末設定戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">同期状態表示端末設定戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 同期状態表示端末設定戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        public int DeleteSyncStateProc(ArrayList syncStateDspTermStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSyncStateProcProc(syncStateDspTermStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 同期状態表示端末設定戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)
        /// </summary>
        /// <param name="syncStateDspTermStWorkList">同期状態表示端末設定戻りデータ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 同期状態表示端末設定戻りデータ情報を物理削除します(外部からのSqlConnection and SqlTranactionを使用)</br>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        private int DeleteSyncStateProcProc( ArrayList syncStateDspTermStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = string.Empty;
            try
            {

                for (int i = 0; i < syncStateDspTermStWorkList.Count; i++)
                {
                    SyncStateDspTermStWork syncStateDspTermStWork = syncStateDspTermStWorkList[i] as SyncStateDspTermStWork;
                    sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CASHREGISTERNORF FROM SYNCSTATEDSPTERMSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                    sqlText = string.Empty;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.SectionCode);
                    findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.CashRegisterNo);
                    //タイムアウト時間の設定（秒）
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != syncStateDspTermStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlText += "DELETE FROM SYNCSTATEDSPTERMSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND CASHREGISTERNORF=@FINDCASHREGISTERNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        sqlText = string.Empty;
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(syncStateDspTermStWork.SectionCode);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(syncStateDspTermStWork.CashRegisterNo);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SyncStateDspTermStWork[] SyncStateDspTermStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is SyncStateDspTermStWork)
                    {
                        SyncStateDspTermStWork wkSyncStateDspTermStWork = paraobj as SyncStateDspTermStWork;
                        if (wkSyncStateDspTermStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSyncStateDspTermStWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SyncStateDspTermStWorkArray = (SyncStateDspTermStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SyncStateDspTermStWork[]));
                        }
                        catch (Exception) { }
                        if (SyncStateDspTermStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SyncStateDspTermStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SyncStateDspTermStWork wkSyncStateDspTermStWork = (SyncStateDspTermStWork)XmlByteSerializer.Deserialize(byteArray, typeof(SyncStateDspTermStWork));
                                if (wkSyncStateDspTermStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSyncStateDspTermStWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SyncStateDspTermStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SyncStateDspTermStWork</returns>
        /// <remarks>
        /// <br>Programmer : 劉超</br>
        /// <br>Date       : 2014/08/18</br>
        /// </remarks>
        private SyncStateDspTermStWork CopyToSyncStateDspTermStWorkFromReader(ref SqlDataReader myReader)
        {
            SyncStateDspTermStWork wkSyncStateDspTermStWork = new SyncStateDspTermStWork();

            #region クラスへ格納
            wkSyncStateDspTermStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkSyncStateDspTermStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSyncStateDspTermStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkSyncStateDspTermStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSyncStateDspTermStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSyncStateDspTermStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSyncStateDspTermStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSyncStateDspTermStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSyncStateDspTermStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkSyncStateDspTermStWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
            #endregion

            return wkSyncStateDspTermStWork;
        }
        #endregion

    }
}
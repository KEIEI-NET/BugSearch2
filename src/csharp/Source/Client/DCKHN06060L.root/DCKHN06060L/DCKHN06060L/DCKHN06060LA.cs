using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.LocalAccess
{
    /// <summary>
    /// 受発注全体設定マスタLCローカルDBオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受発注全体設定マスタLCのローカルDB実データ操作を行うクラスです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2008.01.24</br>
    /// <br></br>
    /// <br>Update Note: 2008.06.09 疋田 勇人</br>
    /// <br>           : ＰＭ.ＮＳ用に変更</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class AcptAnOdrTtlStLcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// 受発注全体設定マスタLCローカルDBオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.24</br>
        /// </remarks>
        public AcptAnOdrTtlStLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の受発注全体設定マスタLC情報LISTを戻します
        /// </summary>
        /// <param name="acptAnOdrTtlStWorkList">検索結果</param>
        /// <param name="paraAcptAnOdrTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタLC情報LISTを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.24</br>
        public int Search(out List<AcptAnOdrTtlStWork> acptAnOdrTtlStWorkList, SearchAcptAnOdrTtlStParaWork paraAcptAnOdrTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            acptAnOdrTtlStWorkList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchAcptAnOdrTtlStProcProc(out acptAnOdrTtlStWorkList, paraAcptAnOdrTtlStWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AcptAnOdrTtlStLcDB.Search", 0);
                acptAnOdrTtlStWorkList = new List<AcptAnOdrTtlStWork>();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// 指定された条件の受発注全体設定マスタLC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="acptAnOdrTtlStWorkList">検索結果</param>
        /// <param name="acptAnOdrTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタLC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.24</br>
        public int SearchAcptAnOdrTtlStProc(out List<AcptAnOdrTtlStWork> acptAnOdrTtlStWorkList, SearchAcptAnOdrTtlStParaWork acptAnOdrTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            status = SearchAcptAnOdrTtlStProcProc(out acptAnOdrTtlStWorkList, acptAnOdrTtlStWork, readMode, logicalMode, ref sqlConnection);

            return status;
        }

        /// <summary>
        /// 指定された条件の受発注全体設定マスタLC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="acptAnOdrTtlStWorkList">検索結果</param>
        /// <param name="acptAnOdrTtlStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタLC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.24</br>
        private int SearchAcptAnOdrTtlStProcProc(out List<AcptAnOdrTtlStWork> acptAnOdrTtlStWorkList, SearchAcptAnOdrTtlStParaWork acptAnOdrTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<AcptAnOdrTtlStWork> listdata = new List<AcptAnOdrTtlStWork>();
            try
            {
                // 2008.06.09 upd start -------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM ACPTANODRTTLSTRF  ", sqlConnection);
                string sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,ESTMCOUNTREFLECTDIVRF" + Environment.NewLine;
                sqlText += "    ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += "    ,FAXORDERDIVRF" + Environment.NewLine;
                sqlText += " FROM ACPTANODRTTLSTRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                // 2008.06.09 upd end ----------------------------------<<

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, acptAnOdrTtlStWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToAcptAnOdrTtlStWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AcptAnOdrTtlStLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            acptAnOdrTtlStWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の受発注全体設定マスタLCを戻します
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">acptAnOdrTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタLCを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.24</br>
        public int Read(ref AcptAnOdrTtlStWork acptAnOdrTtlStWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref acptAnOdrTtlStWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AcptAnOdrTtlStLcDB.Read", 0);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された条件の受発注全体設定マスタLCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">acptAnOdrTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタLCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.24</br>
        public int ReadProc(ref AcptAnOdrTtlStWork acptAnOdrTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            status = ReadProcProc(ref acptAnOdrTtlStWork, readMode, ref sqlConnection);

            return status;
        }

        /// <summary>
        /// 指定された条件の受発注全体設定マスタLCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">acptAnOdrTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受発注全体設定マスタLCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.24</br>
        private int ReadProcProc(ref AcptAnOdrTtlStWork acptAnOdrTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                // 2008.06.09 upd start --------------------------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ACPTANODRTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection))
                string sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,ESTMCOUNTREFLECTDIVRF" + Environment.NewLine;
                sqlText += "    ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += "    ,FAXORDERDIVRF" + Environment.NewLine;
                sqlText += " FROM ACPTANODRTTLSTRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))    
                // 2008.06.09 upd end -----------------------------------------<<
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.06.09 add

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode);              // 2008.06.09 add

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        acptAnOdrTtlStWork = CopyToAcptAnOdrTtlStWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AcptAnOdrTtlStLcDB.Read", 0);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [WriteSyncLocalData]
        /// <summary>
        /// ユーザデータシンク管理マスタ情報を登録、更新します
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWorkオブジェクト</param>
        /// <param name="paraSyncDataList">paraSyncDataListオブジェクト</param>
        /// <param name="readMode">readMode(未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザデータシンク管理マスタ情報を登録、更新します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.24</br>
        public int WriteSyncLocalData(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList syncDataList = new ArrayList();
            try
            {
                if (syncServiceWork == null) return status;
                if (paraSyncDataList == null) return status;

                //使用するパラメータのキャスト
                AcptAnOdrTtlStWork acptAnOdrTtlStWork = new AcptAnOdrTtlStWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == acptAnOdrTtlStWork.GetType())
                    {
                        break;
                    }
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSyncLocalDataProcProc(syncServiceWork, syncDataList, readMode, ref sqlConnection, ref sqlTransaction);

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
                WriteErrorLog(ex, "AcptAnOdrTtlStLcDB.WriteSyncLocalData", 0);
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
        /// ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWorkオブジェクト</param>
        /// <param name="paraSyncDataList">paraSyncDataListオブジェクト</param>
        /// <param name="readMode">readMode(未使用)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.24</br>
        public int WriteSyncLocalDataProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList syncDataList = new ArrayList();
            status = WriteSyncLocalDataProcProc(syncServiceWork, syncDataList, readMode, ref sqlConnection, ref sqlTransaction);
            return status;
        }

        /// <summary>
        /// ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWorkオブジェクト</param>
        /// <param name="paraSyncDataList">paraSyncDataListオブジェクト</param>
        /// <param name="readMode">readMode(未使用)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.24</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlText = string.Empty; // 2008.06.09 add
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        // 2008.06.09 upd start ---------------------------------------->>
                        //sqlCommand = new SqlCommand("DELETE FROM ACPTANODRTTLSTRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += " FROM ACPTANODRTTLSTRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                        // 2008.06.09 upd end ------------------------------------------<<
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        AcptAnOdrTtlStWork acptAnOdrTtlStWork = paraSyncDataList[i] as AcptAnOdrTtlStWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //差分モードのシンク処理
                            case 0:
                                //Selectコマンドの生成
                                // 2008.06.09 upd start ---------------------------------------->>
                                //sqlCommand = new SqlCommand("SELECT * FROM ACPTANODRTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection, sqlTransaction);
                                sqlText = string.Empty;
                                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlText += "    ,ESTMCOUNTREFLECTDIVRF" + Environment.NewLine;
                                sqlText += "    ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                                sqlText += "    ,FAXORDERDIVRF" + Environment.NewLine;
                                sqlText += " FROM ACPTANODRTTLSTRF" + Environment.NewLine;
                                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                                // 2008.06.09 upd end ------------------------------------------<<

                                //Prameterオブジェクトの作成
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.06.09 add

                                //Parameterオブジェクトへ値設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode); // 2008.06.09 add

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    //Updateコマンドの生成
                                    // 2008.06.09 upd start ---------------------------------------->>
                                    //sqlCommand.CommandText = "UPDATE ACPTANODRTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , ORDERNUMBERCOMPORF=@ORDERNUMBERCOMPO , ESTMCOUNTREFLECTDIVRF=@ESTMCOUNTREFLECTDIV , ACPODRRSLIPPRTDIVRF=@ACPODRRSLIPPRTDIV , FAXORDERDIVRF=@FAXORDERDIV , DOTKULORDERDIVRF=@DOTKULORDERDIV ";
                                    sqlText = string.Empty;
                                    sqlText += "UPDATE ACPTANODRTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                                    sqlText += " , ESTMCOUNTREFLECTDIVRF=@ESTMCOUNTREFLECTDIV" + Environment.NewLine;
                                    sqlText += " , ACPODRRSLIPPRTDIVRF=@ACPODRRSLIPPRTDIV" + Environment.NewLine;
                                    sqlText += " , FAXORDERDIVRF=@FAXORDERDIV" + Environment.NewLine;
                                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    // 2008.06.09 upd end ------------------------------------------<<
                                    
                                    //KEYコマンドを再設定
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode); // 2008.06.09 add

                                    //更新ヘッダ情報を設定
                                    //FileHeaderGuidはSelect結果から取得
                                    acptAnOdrTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                    obj = (object)this;
                                    flhd = (IFileHeader)acptAnOdrTtlStWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                }
                                else
                                {
                                    //Insertコマンドの生成
                                    // 2008.06.09 upd start ---------------------------------------->>
                                    //sqlCommand.CommandText = "INSERT INTO ACPTANODRTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ORDERNUMBERCOMPORF,  ESTMCOUNTREFLECTDIVRF, ACPODRRSLIPPRTDIVRF,  FAXORDERDIVRF, DOTKULORDERDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ORDERNUMBERCOMPO, @ESTMCOUNTREFLECTDIV, @ACPODRRSLIPPRTDIV, @FAXORDERDIV, @DOTKULORDERDIV)";
                                    sqlText = string.Empty;
                                    sqlText += "INSERT INTO ACPTANODRTTLSTRF" + Environment.NewLine;
                                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                                    sqlText += "    ,ESTMCOUNTREFLECTDIVRF" + Environment.NewLine;
                                    sqlText += "    ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                                    sqlText += "    ,FAXORDERDIVRF" + Environment.NewLine;
                                    sqlText += " )" + Environment.NewLine;
                                    sqlText += " VALUES" + Environment.NewLine;
                                    sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                                    sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                                    sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                                    sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                                    sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                                    sqlText += "    ,@ESTMCOUNTREFLECTDIV" + Environment.NewLine;
                                    sqlText += "    ,@ACPODRRSLIPPRTDIV" + Environment.NewLine;
                                    sqlText += "    ,@FAXORDERDIV" + Environment.NewLine;
                                    sqlText += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    // 2008.06.09 upd end ------------------------------------------<<
                                    //登録ヘッダ情報を設定
                                    obj = (object)this;
                                    flhd = (IFileHeader)acptAnOdrTtlStWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();
                                break;

                            //全件登録のシンク処理
                            case 1:
                                //Insertコマンドの生成
                                // 2008.06.09 upd start ---------------------------------------->>
                                //sqlCommand = new SqlCommand("INSERT INTO ACPTANODRTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ORDERNUMBERCOMPORF,  ESTMCOUNTREFLECTDIVRF, ACPODRRSLIPPRTDIVRF,  FAXORDERDIVRF, DOTKULORDERDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ORDERNUMBERCOMPO, @ESTMCOUNTREFLECTDIV, @ACPODRRSLIPPRTDIV, @FAXORDERDIV, @DOTKULORDERDIV)", sqlConnection, sqlTransaction);
                                sqlText = string.Empty;
                                sqlText += "INSERT INTO ACPTANODRTTLSTRF" + Environment.NewLine;
                                sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlText += "    ,ESTMCOUNTREFLECTDIVRF" + Environment.NewLine;
                                sqlText += "    ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                                sqlText += "    ,FAXORDERDIVRF" + Environment.NewLine;
                                sqlText += " )" + Environment.NewLine;
                                sqlText += " VALUES" + Environment.NewLine;
                                sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                                sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                                sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                                sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                                sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                                sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                                sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                                sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                                sqlText += "    ,@ESTMCOUNTREFLECTDIV" + Environment.NewLine;
                                sqlText += "    ,@ACPODRRSLIPPRTDIV" + Environment.NewLine;
                                sqlText += "    ,@FAXORDERDIV" + Environment.NewLine;
                                sqlText += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                                // 2008.06.09 upd end ------------------------------------------<<
                                //登録ヘッダ情報を設定
                                obj = (object)this;
                                flhd = (IFileHeader)acptAnOdrTtlStWork;
                                fileHeader = new ClientFileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                                break;
                        }

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        //SqlParameter paraOrderNumberCompo = sqlCommand.Parameters.Add("@ORDERNUMBERCOMPO", SqlDbType.Int); // 2008.06.09 del
                        SqlParameter paraEstmCountReflectDiv = sqlCommand.Parameters.Add("@ESTMCOUNTREFLECTDIV", SqlDbType.Int);
                        SqlParameter paraAcpOdrrSlipPrtDiv = sqlCommand.Parameters.Add("@ACPODRRSLIPPRTDIV", SqlDbType.Int);
                        SqlParameter paraFaxOrderDiv = sqlCommand.Parameters.Add("@FAXORDERDIV", SqlDbType.Int);
                        //SqlParameter paraDotKulOrderDiv = sqlCommand.Parameters.Add("@DOTKULORDERDIV", SqlDbType.Int); // 2008.06.09 del
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar); // 2008.06.09 add
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acptAnOdrTtlStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acptAnOdrTtlStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(acptAnOdrTtlStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.LogicalDeleteCode);
                        //paraOrderNumberCompo.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.OrderNumberCompo);
                        paraEstmCountReflectDiv.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.EstmCountReflectDiv);
                        paraAcpOdrrSlipPrtDiv.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.AcpOdrrSlipPrtDiv);
                        paraFaxOrderDiv.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.FaxOrderDiv);
                        //paraDotKulOrderDiv.Value = SqlDataMediator.SqlSetInt32(acptAnOdrTtlStWork.DotKulOrderDiv);// 2008.06.09 del
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode); // 2008.06.09 add
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }

                    //ユーザデータシンク管理マスタへ更新
                    DataSyncMngWork dataSyncMngWork = new DataSyncMngWork();
                    DataSyncMngLcDB dataSyncMngLcDB = new DataSyncMngLcDB();
                    List<DataSyncMngWork> dataSyncMngWorkList = new List<DataSyncMngWork>();
                    dataSyncMngWork.EnterpriseCode = syncServiceWork.EnterpriseCode;
                    dataSyncMngWork.LastDataUpdDate = syncServiceWork.SyncDateTimeEd;
                    dataSyncMngWork.SyncExecDate = syncServiceWork.SyncExecDate;
                    dataSyncMngWork.ManagementTableName = syncServiceWork.ManagementTableName;
                    dataSyncMngWork.DataDeleteDateTime = syncServiceWork.DataDeleteDateTime;
                    dataSyncMngWorkList.Add(dataSyncMngWork);
                    status = dataSyncMngLcDB.WriteDataSyncMngProc(ref dataSyncMngWorkList, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AcptAnOdrTtlStLcDB.WriteSyncLocalDataProc", 0);
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

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="acptAnOdrTtlStWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.24</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchAcptAnOdrTtlStParaWork acptAnOdrTtlStWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //各マスタのWhere文記述
            // 2008.06.09 del start ----------------------------->>
            //拠点コード
            if (acptAnOdrTtlStWork.SectionCode != "")
            {
                retstring += "AND SECTIONCODERF=@FINDSECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(acptAnOdrTtlStWork.SectionCode);
            }
            // 2008.06.09 del end ------------------------------<<

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → AcptAnOdrTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AcptAnOdrTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.24</br>
        /// </remarks>
        private AcptAnOdrTtlStWork CopyToAcptAnOdrTtlStWorkFromReader(ref SqlDataReader myReader)
        {
            AcptAnOdrTtlStWork wkAcptAnOdrTtlStWork = new AcptAnOdrTtlStWork();

            #region クラスへ格納
            wkAcptAnOdrTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkAcptAnOdrTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkAcptAnOdrTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkAcptAnOdrTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkAcptAnOdrTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkAcptAnOdrTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkAcptAnOdrTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkAcptAnOdrTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //wkAcptAnOdrTtlStWork.OrderNumberCompo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERNUMBERCOMPORF")); // 2008.06.09 del
            wkAcptAnOdrTtlStWork.EstmCountReflectDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMCOUNTREFLECTDIVRF"));
            wkAcptAnOdrTtlStWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));
            wkAcptAnOdrTtlStWork.FaxOrderDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FAXORDERDIVRF"));
            //wkAcptAnOdrTtlStWork.DotKulOrderDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOTKULORDERDIVRF")); // 2008.06.09 del
            wkAcptAnOdrTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // 2008.06.09 add

            #endregion

            return wkAcptAnOdrTtlStWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.24</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            ClientSqlConnectionInfo clientSqlConnectionInfo = new ClientSqlConnectionInfo();
            string connectionText = clientSqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Local_UserDB);
            if (connectionText == null || connectionText == "") return null;
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion

        #region [エラーログ出力処理]
        private void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = "";
            if (ex != null)
            {
                if (ex is SqlException)
                {
                    this.WriteSQLErrorLog((SqlException)ex, errorText, status);
                }
                else
                {
                    message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                    new ClientLogTextOut().Output(ex.Source, message, status, ex);
                }
            }
            else
            {
                new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, errorText, status);
            }
        }

        private int WriteSQLErrorLog(SqlException ex, string errorText, int status)
        {
            string message = "";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                object obj2 = message;
                message = string.Concat(new object[] { obj2, "Index #", i, "\nMessage: ", ex.Errors[i].Message, "\nLineNumber: ", ex.Errors[i].LineNumber, "\nSource: ", ex.Errors[i].Source, "\nProcedure: ", ex.Errors[i].Procedure, "\n" });
            }
            if (!errorText.Trim().Equals(""))
            {
                message = message + errorText + "\n";
            }
            message = message + "Status = " + status.ToString() + "\n";
            new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, message, status);
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
            {
                return (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
            }
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        }
        #endregion

    }
}

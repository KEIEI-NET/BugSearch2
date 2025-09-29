//**********************************************************************//
// システム         ：PM.NS                                             //
// プログラム名称   ：PMTABアップロード排他制御検索マスタDBRemoteObject // 
// プログラム概要   ：PMTABアップロード排他制御検索マスタDBRemoteObject //
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴                                                                 //
//----------------------------------------------------------------------//
// 管理番号  10902622-01 作成担当 : 鄭慕鈞                              //
// 作 成 日  2013/06/24  作成内容 : 新規作成                            //
//----------------------------------------------------------------------//
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
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTABアップロード排他制御検索マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTABアップロード排他制御検索マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 鄭慕鈞 </br>
    /// <br>Date       : 2013/06/24</br>  
    /// </remarks>
    [Serializable]
    public class PmTabUpldExclsvDB : RemoteDB, IPmTabUpldExclsvDB
    {
        /// <summary>
        /// PMTABアップロード排他制御検索マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 鄭慕鈞 </br>
        /// <br>Date       : 2013/06/24</br>
        /// </remarks>
        public PmTabUpldExclsvDB()
            :
            base("PMTAB00186D", "Broadleaf.Application.Remoting.ParamData.PmTabUpldExclsvWork", "PMTABUPLDEXCLSVRF")
        {
        }

        #region [Read]
        /// <summary>
        /// 指定されたPMアップロード排他制御GuidのPMアップロード排他制御を戻します
        /// </summary>
        /// <param name="parabyte">PMEmployeeWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        public int Read(ref object parabyte, int readMode)
        {
            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                sqlConnection.Open();

                PmTabUpldExclsvWork pmTabUpldExclsvWork = parabyte as PmTabUpldExclsvWork;

                return ReadProc(ref pmTabUpldExclsvWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PmTabUpldExclsvDB.Read Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                DisposeSqlConnection(ref sqlConnection);
            }
        }

        /// <summary>
        /// 指定されたPMアップロード排他制御GuidのPMアップロード排他制御を戻します
        /// </summary>
        /// <param name="pmTabUpldExclsvWork">PMEmployeeWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        private int ReadProc(ref PmTabUpldExclsvWork pmTabUpldExclsvWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();

                sqlText.Append("SELECT" + Environment.NewLine);
                sqlText.Append("CREATEDATETIMERF" + Environment.NewLine);
                sqlText.Append(", UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append(", ENTERPRISECODERF" + Environment.NewLine);
                sqlText.Append(", FILEHEADERGUIDRF" + Environment.NewLine);
                sqlText.Append(", UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlText.Append(", UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlText.Append(", UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlText.Append(", LOGICALDELETECODERF" + Environment.NewLine);
                sqlText.Append(", SECTIONCODERF" + Environment.NewLine);
                sqlText.Append(", CLIENTMULTICASTVERRF" + Environment.NewLine);
                sqlText.Append(", UPLOADPROCESSDIVCDRF" + Environment.NewLine);
                sqlText.Append("FROM" + Environment.NewLine);
                sqlText.Append("  PMTABUPLDEXCLSVRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append("WHERE" + Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                sqlText.Append("  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine);
                sqlText.Append("  AND CLIENTMULTICASTVERRF=@FINDCLIENTMULTICASTVER" + Environment.NewLine);

                // Selectコマンドの生成
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectioncode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaClientMultiCastver = sqlCommand.Parameters.Add("@FINDCLIENTMULTICASTVER", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.EnterpriseCode);
                findParaSectioncode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.SectionCode);
                findParaClientMultiCastver.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.ClientMulticastVer);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (myReader.Read())
                {
                    pmTabUpldExclsvWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    pmTabUpldExclsvWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    pmTabUpldExclsvWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    pmTabUpldExclsvWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    pmTabUpldExclsvWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    pmTabUpldExclsvWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    pmTabUpldExclsvWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    pmTabUpldExclsvWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    pmTabUpldExclsvWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    pmTabUpldExclsvWork.ClientMulticastVer = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLIENTMULTICASTVERRF"));
                    pmTabUpldExclsvWork.UploadProcessDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UPLOADPROCESSDIVCDRF"));
                    
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                }
            }

            return status;
        }
        #endregion [Read]

        #region [Write]
        /// <summary>
        /// PMアップロード排他制御情報を登録、更新します
        /// </summary>
        /// <param name="paraobj">PMEmployeeWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMアップロード排他制御情報を登録、更新します</br>
        /// <br>Programmer : 22011 Kashihara</br>
        /// <br>Date       : 2013.05.28</br>
        public int Write(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                PmTabUpldExclsvWork pmTabUpldExclsvWork =  paraobj as PmTabUpldExclsvWork;
                status = WriteProc(pmTabUpldExclsvWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PmTabUpldExclsvDB.Write:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // ●コネクション破棄
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        // ●コミットorロールバック
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            sqlTransaction.Commit();
                        else
                            sqlTransaction.Rollback();
                    }
                    DisposeSqlConnection(ref sqlConnection);
                }
            }
            return status;
        }

        /// <summary>
        /// PMアップロード排他制御情報を登録、更新します
        /// </summary>
        /// <param name="pmTabUpldExclsvWork">pmemployeeWork</param>
        /// <param name="sqlConnection">Sql接続情報</param>
        /// <param name="sqlTransaction">ﾄﾗﾝｻﾞｸｼｮﾝ情報</param>
        /// <returns>STATUS</returns>
        private int WriteProc(PmTabUpldExclsvWork pmTabUpldExclsvWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            
            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlText.Append("SELECT" + Environment.NewLine);
                sqlText.Append(" UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append(" FROM" + Environment.NewLine);
                sqlText.Append(" PMTABUPLDEXCLSVRF" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine);
                sqlText.Append(" AND CLIENTMULTICASTVERRF=@FINDCLIENTMULTICASTVER" + Environment.NewLine);
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectioncode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaClientMultiCastver = sqlCommand.Parameters.Add("@FINDCLIENTMULTICASTVER", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.EnterpriseCode);
                findParaSectioncode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.SectionCode);
                findParaClientMultiCastver.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.ClientMulticastVer);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != pmTabUpldExclsvWork.UpdateDateTime)
                    {
                        //新規登録で該当データ有りの場合には重複
                        if (pmTabUpldExclsvWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //既存データで更新日時違いの場合には排他
                        else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        myReader.Close();
                        return status;
                    }

                    # region [UPDATE文]
                    sqlText = new StringBuilder();
                    sqlText.Append("UPDATE PMTABUPLDEXCLSVRF" + Environment.NewLine);
                    sqlText.Append(" SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine);
                    sqlText.Append(" ,UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine);
                    sqlText.Append(" ,ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine);
                    sqlText.Append(" ,FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine);
                    sqlText.Append(" ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine);
                    sqlText.Append(" ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine);
                    sqlText.Append(" ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine);
                    sqlText.Append(" ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine);
                    sqlText.Append(" ,SECTIONCODERF=@SECTIONCODE" + Environment.NewLine);
                    sqlText.Append(" ,CLIENTMULTICASTVERRF=@CLIENTMULTICASTVER" + Environment.NewLine);
                    sqlText.Append(" ,UPLOADPROCESSDIVCDRF=@UPLOADPROCESSDIVCD" + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                    sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine);
                    sqlText.Append(" AND CLIENTMULTICASTVERRF=@FINDCLIENTMULTICASTVER" + Environment.NewLine);
                    #endregion

                    sqlCommand.CommandText = sqlText.ToString();

                    //KEYコマンドを再設定
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.EnterpriseCode);
                    findParaSectioncode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.SectionCode);
                    findParaClientMultiCastver.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.ClientMulticastVer);

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)pmTabUpldExclsvWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    if (pmTabUpldExclsvWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        myReader.Close();
                        return status;
                    }

                    # region [INSERT文]
                    sqlText = new StringBuilder();
                    sqlText.Append("INSERT INTO PMTABUPLDEXCLSVRF" + Environment.NewLine);
                    sqlText.Append("(CREATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append(",UPDATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append(",ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append(",FILEHEADERGUIDRF" + Environment.NewLine);
                    sqlText.Append(",UPDEMPLOYEECODERF" + Environment.NewLine);
                    sqlText.Append(",UPDASSEMBLYID1RF" + Environment.NewLine);
                    sqlText.Append(",UPDASSEMBLYID2RF" + Environment.NewLine);
                    sqlText.Append(",LOGICALDELETECODERF" + Environment.NewLine);
                    sqlText.Append(",SECTIONCODERF" + Environment.NewLine);
                    sqlText.Append(",CLIENTMULTICASTVERRF" + Environment.NewLine);
                    sqlText.Append(",UPLOADPROCESSDIVCDRF)" + Environment.NewLine);
                    sqlText.Append("VALUES" + Environment.NewLine);
                    sqlText.Append(" (@CREATEDATETIME" + Environment.NewLine);
                    sqlText.Append(",@UPDATEDATETIME" + Environment.NewLine);
                    sqlText.Append(",@ENTERPRISECODE" + Environment.NewLine);
                    sqlText.Append(",@FILEHEADERGUID" + Environment.NewLine);
                    sqlText.Append(",@UPDEMPLOYEECODE" + Environment.NewLine);
                    sqlText.Append(",@UPDASSEMBLYID1" + Environment.NewLine);
                    sqlText.Append(",@UPDASSEMBLYID2" + Environment.NewLine);
                    sqlText.Append(",@LOGICALDELETECODE" + Environment.NewLine);
                    sqlText.Append(",@SECTIONCODE" + Environment.NewLine);
                    sqlText.Append(",@CLIENTMULTICASTVER" + Environment.NewLine);
                    sqlText.Append(",@UPLOADPROCESSDIVCD)" + Environment.NewLine);
                    #endregion

                    //新規作成時のSQL文を生成
                    sqlCommand.CommandText = sqlText.ToString();

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)pmTabUpldExclsvWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }
                myReader.Close();

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraClientMulticastVer = sqlCommand.Parameters.Add("@CLIENTMULTICASTVER", SqlDbType.NVarChar);
                SqlParameter paraUploadProcessDivCd = sqlCommand.Parameters.Add("@UPLOADPROCESSDIVCD", SqlDbType.Int);


                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabUpldExclsvWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabUpldExclsvWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pmTabUpldExclsvWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmTabUpldExclsvWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.SectionCode);
                paraClientMulticastVer.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.ClientMulticastVer);
                paraUploadProcessDivCd.Value = SqlDataMediator.SqlSetInt32(pmTabUpldExclsvWork.UploadProcessDivCd);

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PmTabUpldExclsvDB.Write Exception = " + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion [Write]

        #region [Delete]
        /// <summary>
        /// アップロード排他制御マスタ物理処理
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : アップロード排他制御マスタを物理削除します</br>
        /// <br>Programmer : 鄭慕鈞 </br>
        /// <br>Date       : 2013/06/24</br>
        /// </remarks>
        public int Delete(ref object paraList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string errMsg = string.Empty;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //コネクション生成
                sqlConnection =CreateSqlConnection();

                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                PmTabUpldExclsvWork pmTabUpldExclsvWork  = paraList as PmTabUpldExclsvWork;
                // Delete処理
                status = DeleteProc(pmTabUpldExclsvWork, ref sqlConnection, ref sqlTransaction);
                //正常終了時、コミットします　その他の場合、ロールバックします
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
            catch (SqlException ex)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    errMsg = "アップロード排他制御検索の削除処理中にタイムアウトが発生しました。";
                else
                    errMsg = "アップロード排他制御検索の削除処理に失敗しました。";
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();


                status = base.WriteSQLErrorLog(ex, errMsg, (int)ConstantManagement.DB_Status.ctDB_ERROR);
            }
            catch (Exception ex)
            {
                errMsg = "アップロード排他制御検索の削除処理に失敗しました。";
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                base.WriteErrorLog(ex, errMsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();

                DisposeSqlConnection(ref sqlConnection);
            }

            return status;
        }

        /// <summary>
        /// アップロード排他制御マスタ物理削除処理
        /// </summary>
        /// <param name="pmTabUpldExclsvWork">PmTabUpldExclsvWork</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : アップロード排他制御マスタを物理削除します</br>
        /// <br>Programmer : 鄭慕鈞 </br>
        /// <br>Date       : 2013/06/24</br>
        /// </remarks>
        private int DeleteProc(PmTabUpldExclsvWork pmTabUpldExclsvWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                //Selectコマンドの生成
                #region [SELECT文]
                sqlText.Append("SELECT" + Environment.NewLine);
                sqlText.Append(" UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append(" FROM" + Environment.NewLine);
                sqlText.Append(" PMTABUPLDEXCLSVRF" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                sqlText.Append("AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine);
                sqlText.Append("AND CLIENTMULTICASTVERRF=@FINDCLIENTMULTICASTVER" + Environment.NewLine);

                sqlCommand.CommandText = sqlText.ToString();
                #endregion

                // Prameterオブジェクトの作成
                sqlCommand.Parameters.Clear();
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectioncode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaClientMultiCastver = sqlCommand.Parameters.Add("@FINDCLIENTMULTICASTVER", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.EnterpriseCode);
                findParaSectioncode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.SectionCode);
                findParaClientMultiCastver.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.ClientMulticastVer);
                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != pmTabUpldExclsvWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    //Deleteコマンドの生成
                    #region [DELETE文]
                    sqlText = new StringBuilder();
                    sqlText.Append("DELETE" + Environment.NewLine);
                    sqlText.Append(" FROM PMTABUPLDEXCLSVRF" + Environment.NewLine);
                    sqlText.Append(" WHERE" + Environment.NewLine);
                    sqlText.Append("    ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                    sqlText.Append("AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine);
                    sqlText.Append("AND CLIENTMULTICASTVERRF=@FINDCLIENTMULTICASTVER" + Environment.NewLine);

                    sqlCommand.CommandText = sqlText.ToString();
                    #endregion

                    // KEYコマンドを再設定
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.EnterpriseCode);
                    findParaSectioncode.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.SectionCode);
                    findParaClientMultiCastver.Value = SqlDataMediator.SqlSetString(pmTabUpldExclsvWork.ClientMulticastVer);
                }
                else
                {
                    // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                        myReader.Dispose();
                    }

                    return status;
                }

                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                    myReader.Dispose();
                }

                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "アップロード排他制御マスタの物理削除に失敗しました。", ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "アップロード排他制御マスタの物理削除に失敗しました。", status);
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
        /// <br>Programmer : 許培珠</br>
        /// <br>Date       : 2013/05/31</br>
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

        /// <summary>
        /// SQLコネクションを破棄します
        /// </summary>
        /// <param name="sqlConnection">破棄対象のSQLコネクション</param>
        private void DisposeSqlConnection(ref SqlConnection sqlConnection)
        {
            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
        

    }
}

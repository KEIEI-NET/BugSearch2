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
    /// 車種名称マスタローカルDBアクセスオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車種名称マスタローカルDB実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// </remarks>
    public class ModelNameULcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// 車種名称マスタローカルDBオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        public ModelNameULcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の車種名称マスタLC情報LISTを戻します
        /// </summary>
        /// <param name="modelNameUWorkList">検索結果</param>
        /// <param name="paraModelNameUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の車種名称マスタLC情報LISTを戻します</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(out List<ModelNameUWork> modelNameUWorkList, ModelNameUWork paraModelNameUWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            modelNameUWorkList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchModelNameUProcProc(out modelNameUWorkList, paraModelNameUWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "ModelNameULcDB.Search", 0);
                modelNameUWorkList = new List<ModelNameUWork>();
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
        /// 指定された条件の車種名称マスタLC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="modelNameUWorkList">検索結果</param>
        /// <param name="modelNameUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の車種名称マスタLC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int SearchModelNameUProc(out List<ModelNameUWork> modelNameUWorkList, ModelNameUWork modelNameUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = SearchModelNameUProcProc(out modelNameUWorkList, modelNameUWork, readMode, logicalMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// 指定された条件の車種名称マスタLC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="modelNameUWorkList">検索結果</param>
        /// <param name="modelNameUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の車種名称マスタLC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        private int SearchModelNameUProcProc(out List<ModelNameUWork> modelNameUWorkList, ModelNameUWork modelNameUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<ModelNameUWork> listdata = new List<ModelNameUWork>();
            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,MODELUNIQUECODERF" + Environment.NewLine;
                sqlText += "    ,MAKERCODERF" + Environment.NewLine;
                sqlText += "    ,MODELCODERF" + Environment.NewLine;
                sqlText += "    ,MODELSUBCODERF" + Environment.NewLine;
                sqlText += "    ,MODELFULLNAMERF" + Environment.NewLine;
                sqlText += "    ,MODELHALFNAMERF" + Environment.NewLine;
                sqlText += "    ,MODELALIASNAMERF" + Environment.NewLine;
                sqlText += " FROM MODELNAMEURF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, modelNameUWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToModelNameUWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "ModelNameULcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            modelNameUWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の車種名称マスタLCを戻します
        /// </summary>
        /// <param name="modelNameUWork">ModelNameUWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の車種名称マスタLCを戻します</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref ModelNameUWork modelNameUWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref modelNameUWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "ModelNameULcDB.Read", 0);
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
        /// 指定された条件の車種名称マスタLCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="modelNameUWork">blGoodsCdUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の車種名称マスタLCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int ReadProc(ref ModelNameUWork modelNameUWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref modelNameUWork, readMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// 指定された条件の車種名称マスタLCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="modelNameUWork">blGoodsCdUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の車種名称マスタLCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        private int ReadProcProc(ref ModelNameUWork modelNameUWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                string sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,MODELUNIQUECODERF" + Environment.NewLine;
                sqlText += "    ,MAKERCODERF" + Environment.NewLine;
                sqlText += "    ,MODELCODERF" + Environment.NewLine;
                sqlText += "    ,MODELSUBCODERF" + Environment.NewLine;
                sqlText += "    ,MODELFULLNAMERF" + Environment.NewLine;
                sqlText += "    ,MODELHALFNAMERF" + Environment.NewLine;
                sqlText += "    ,MODELALIASNAMERF" + Environment.NewLine;
                sqlText += " FROM MODELNAMEURF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND MODELUNIQUECODERF=@FINDMODELUNIQUECODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))    

                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaModelUniqueCode = sqlCommand.Parameters.Add("@FINDMODELUNIQUECODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);
                    findParaModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        modelNameUWork = CopyToModelNameUWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "ModelNameULcDB.Read", 0);
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
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
                ModelNameUWork modelNameUWork = new ModelNameUWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == modelNameUWork.GetType())
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
                WriteErrorLog(ex, "ModelNameULcDB.WriteSyncLocalData", 0);
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
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
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlText = string.Empty;
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += " FROM MODELNAMEURF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        ModelNameUWork modelNameUWork = paraSyncDataList[i] as ModelNameUWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //差分モードのシンク処理
                            case 0:
                                //Selectコマンドの生成
                                sqlText = string.Empty;
                                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += "    ,MODELUNIQUECODERF" + Environment.NewLine;
                                sqlText += "    ,MAKERCODERF" + Environment.NewLine;
                                sqlText += "    ,MODELCODERF" + Environment.NewLine;
                                sqlText += "    ,MODELSUBCODERF" + Environment.NewLine;
                                sqlText += "    ,MODELFULLNAMERF" + Environment.NewLine;
                                sqlText += "    ,MODELHALFNAMERF" + Environment.NewLine;
                                sqlText += "    ,MODELALIASNAMERF" + Environment.NewLine;
                                sqlText += " FROM MODELNAMEURF" + Environment.NewLine;
                                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "    AND MODELUNIQUECODERF=@FINDMODELUNIQUECODE" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                                //Prameterオブジェクトの作成
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaModelUniqueCode = sqlCommand.Parameters.Add("@FINDMODELUNIQUECODE", SqlDbType.Int);

                                //Parameterオブジェクトへ値設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);
                                findParaModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    //Updateコマンドの生成
                                    sqlText = string.Empty;
                                    sqlText += "UPDATE MODELNAMEURF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                                    sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlText += " , MODELUNIQUECODERF=@MODELUNIQUECODE" + Environment.NewLine;
                                    sqlText += " , MAKERCODERF=@MAKERCODE" + Environment.NewLine;
                                    sqlText += " , MODELCODERF=@MODELCODE" + Environment.NewLine;
                                    sqlText += " , MODELSUBCODERF=@MODELSUBCODE" + Environment.NewLine;
                                    sqlText += " , MODELFULLNAMERF=@MODELFULLNAME" + Environment.NewLine;
                                    sqlText += " , MODELHALFNAMERF=@MODELHALFNAME" + Environment.NewLine;
                                    sqlText += " , MODELALIASNAMERF=@MODELALIASNAME" + Environment.NewLine;
                                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlText += "    AND MODELUNIQUECODERF=@FINDMODELUNIQUECODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    
                                    //KEYコマンドを再設定
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);
                                    findParaModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);

                                    //更新ヘッダ情報を設定
                                    //FileHeaderGuidはSelect結果から取得
                                    modelNameUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                    obj = (object)this;
                                    flhd = (IFileHeader)modelNameUWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                }
                                else
                                {
                                    //Insertコマンドの生成
                                    sqlText = string.Empty;
                                    sqlText += "INSERT INTO MODELNAMEURF" + Environment.NewLine;
                                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlText += "    ,MODELUNIQUECODERF" + Environment.NewLine;
                                    sqlText += "    ,MAKERCODERF" + Environment.NewLine;
                                    sqlText += "    ,MODELCODERF" + Environment.NewLine;
                                    sqlText += "    ,MODELSUBCODERF" + Environment.NewLine;
                                    sqlText += "    ,MODELFULLNAMERF" + Environment.NewLine;
                                    sqlText += "    ,MODELHALFNAMERF" + Environment.NewLine;
                                    sqlText += "    ,MODELALIASNAMERF" + Environment.NewLine;
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
                                    sqlText += "    ,@MODELUNIQUECODE" + Environment.NewLine;
                                    sqlText += "    ,@MAKERCODE" + Environment.NewLine;
                                    sqlText += "    ,@MODELCODE" + Environment.NewLine;
                                    sqlText += "    ,@MODELSUBCODE" + Environment.NewLine;
                                    sqlText += "    ,@MODELFULLNAME" + Environment.NewLine;
                                    sqlText += "    ,@MODELHALFNAME" + Environment.NewLine;
                                    sqlText += "    ,@MODELALIASNAME" + Environment.NewLine;
                                    sqlText += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;

                                    //登録ヘッダ情報を設定
                                    obj = (object)this;
                                    flhd = (IFileHeader)modelNameUWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();
                                break;

                            //全件登録のシンク処理
                            case 1:
                                //Insertコマンドの生成
                                sqlText = string.Empty;
                                sqlText += "INSERT INTO MODELNAMEURF" + Environment.NewLine;
                                sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += "    ,MODELUNIQUECODERF" + Environment.NewLine;
                                sqlText += "    ,MAKERCODERF" + Environment.NewLine;
                                sqlText += "    ,MODELCODERF" + Environment.NewLine;
                                sqlText += "    ,MODELSUBCODERF" + Environment.NewLine;
                                sqlText += "    ,MODELFULLNAMERF" + Environment.NewLine;
                                sqlText += "    ,MODELHALFNAMERF" + Environment.NewLine;
                                sqlText += "    ,MODELALIASNAMERF" + Environment.NewLine;
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
                                sqlText += "    ,@MODELUNIQUECODE" + Environment.NewLine;
                                sqlText += "    ,@MAKERCODE" + Environment.NewLine;
                                sqlText += "    ,@MODELCODE" + Environment.NewLine;
                                sqlText += "    ,@MODELSUBCODE" + Environment.NewLine;
                                sqlText += "    ,@MODELFULLNAME" + Environment.NewLine;
                                sqlText += "    ,@MODELHALFNAME" + Environment.NewLine;
                                sqlText += "    ,@MODELALIASNAME" + Environment.NewLine;
                                sqlText += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                                //登録ヘッダ情報を設定
                                obj = (object)this;
                                flhd = (IFileHeader)modelNameUWork;
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
                        SqlParameter paraModelUniqueCode = sqlCommand.Parameters.Add("@MODELUNIQUECODE", SqlDbType.Int);
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                        SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);
                        SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);
                        SqlParameter paraModelFullName = sqlCommand.Parameters.Add("@MODELFULLNAME", SqlDbType.NVarChar);
                        SqlParameter paraModelHalfName = sqlCommand.Parameters.Add("@MODELHALFNAME", SqlDbType.NVarChar);
                        SqlParameter paraModelAliasName = sqlCommand.Parameters.Add("@MODELALIASNAME", SqlDbType.NVarChar);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(modelNameUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(modelNameUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(modelNameUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(modelNameUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(modelNameUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.LogicalDeleteCode);
                        paraModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.MakerCode);
                        paraModelCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelCode);
                        paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelSubCode);
                        paraModelFullName.Value = SqlDataMediator.SqlSetString(modelNameUWork.ModelFullName);
                        paraModelHalfName.Value = SqlDataMediator.SqlSetString(modelNameUWork.ModelHalfName);
                        paraModelAliasName.Value = SqlDataMediator.SqlSetString(modelNameUWork.ModelAliasName);
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
                status = WriteSQLErrorLog(ex, "ModelNameULcDB.WriteSyncLocalDataProc", 0);
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
        /// <param name="modelNameUWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ModelNameUWork modelNameUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);

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
            // 車種コード（ユニーク）
            if (modelNameUWork.ModelUniqueCode != 0)
            {
                retstring += "AND MODELUNIQUECODERF=@FINDMODELUNIQUECODE ";
                SqlParameter paraModelUniqueCode = sqlCommand.Parameters.Add("@FINDMODELUNIQUECODE", SqlDbType.Int);
                paraModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);
            }


            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → ModelNameUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ModelNameUWork</returns>
        /// <remarks>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        private ModelNameUWork CopyToModelNameUWorkFromReader(ref SqlDataReader myReader)
        {
            ModelNameUWork wkModelNameUWork = new ModelNameUWork();

            #region クラスへ格納
            wkModelNameUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkModelNameUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkModelNameUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkModelNameUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkModelNameUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkModelNameUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkModelNameUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkModelNameUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkModelNameUWork.ModelUniqueCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELUNIQUECODERF"));
            wkModelNameUWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
            wkModelNameUWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
            wkModelNameUWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
            wkModelNameUWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
            wkModelNameUWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
            wkModelNameUWork.ModelAliasName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELALIASNAMERF"));
            #endregion

            return wkModelNameUWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
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

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
    /// ＢＬ商品コードマスタローカルDBアクセスオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＢＬ商品コードマスタローカルDB実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// </remarks>
    public class BLGoodsCdULcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// ＢＬ商品コードマスタローカルDBオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        public BLGoodsCdULcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件のＢＬ商品コードマスタLC情報LISTを戻します
        /// </summary>
        /// <param name="blGoodsCdUWorkList">検索結果</param>
        /// <param name="paraBLGoodsCdUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のＢＬ商品コードマスタLC情報LISTを戻します</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(out List<BLGoodsCdUWork> blGoodsCdUWorkList, BLGoodsCdUWork paraBLGoodsCdUWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            blGoodsCdUWorkList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchBLGoodsCdUProcProc(out blGoodsCdUWorkList, paraBLGoodsCdUWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "BLGoodsCdULcDB.Search", 0);
                blGoodsCdUWorkList = new List<BLGoodsCdUWork>();
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
        /// 指定された条件のＢＬ商品コードマスタLC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="blGoodsCdUWorkList">検索結果</param>
        /// <param name="blGoodsCdUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のＢＬ商品コードマスタLC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int SearchBLGoodsCdUProc(out List<BLGoodsCdUWork> blGoodsCdUWorkList, BLGoodsCdUWork blGoodsCdUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = SearchBLGoodsCdUProcProc(out blGoodsCdUWorkList, blGoodsCdUWork, readMode, logicalMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// 指定された条件のＢＬ商品コードマスタLC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="blGoodsCdUWorkList">検索結果</param>
        /// <param name="blGoodsCdUWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のＢＬ商品コードマスタLC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        private int SearchBLGoodsCdUProcProc(out List<BLGoodsCdUWork> blGoodsCdUWorkList, BLGoodsCdUWork blGoodsCdUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<BLGoodsCdUWork> listdata = new List<BLGoodsCdUWork>();
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
                sqlText += "    ,BLGROUPCODERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSCODERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSHALFNAMERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSGENRECODERF" + Environment.NewLine;
                sqlText += "    ,GOODSRATEGRPCODERF" + Environment.NewLine;
                sqlText += " FROM BLGOODSCDURF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, blGoodsCdUWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToBLGoodsCdUWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "BLGoodsCdULcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            blGoodsCdUWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件のＢＬ商品コードマスタLCを戻します
        /// </summary>
        /// <param name="blGoodsCdUWork">blGoodsCdUWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のＢＬ商品コードマスタLCを戻します</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref BLGoodsCdUWork blGoodsCdUWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref blGoodsCdUWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "BLGoodsCdULcDB.Read", 0);
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
        /// 指定された条件のＢＬ商品コードマスタLCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="blGoodsCdUWork">blGoodsCdUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のＢＬ商品コードマスタLCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        public int ReadProc(ref BLGoodsCdUWork blGoodsCdUWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref blGoodsCdUWork, readMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// 指定された条件のＢＬ商品コードマスタLCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="blGoodsCdUWork">blGoodsCdUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のＢＬ商品コードマスタLCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        private int ReadProcProc(ref BLGoodsCdUWork blGoodsCdUWork, int readMode, ref SqlConnection sqlConnection)
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
                sqlText += "    ,BLGROUPCODERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSCODERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSFULLNAMERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSHALFNAMERF" + Environment.NewLine;
                sqlText += "    ,BLGOODSGENRECODERF" + Environment.NewLine;
                sqlText += "    ,GOODSRATEGRPCODERF" + Environment.NewLine;
                sqlText += " FROM BLGOODSCDURF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND BLGLOUPCODERF=@FINDBLGLOUPCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))    

                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaBLGloupCode = sqlCommand.Parameters.Add("@FINDBLGLOUPCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.EnterpriseCode);
                    findParaBLGloupCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.BLGroupCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        blGoodsCdUWork = CopyToBLGoodsCdUWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "BLGoodsCdULcDB.Read", 0);
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
                BLGoodsCdUWork blGoodsCdUWork = new BLGoodsCdUWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == blGoodsCdUWork.GetType())
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
                WriteErrorLog(ex, "BLGoodsCdULcDB.WriteSyncLocalData", 0);
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
                        sqlText += " FROM BLGOODSCDURF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        BLGoodsCdUWork blGoodsCdUWork = paraSyncDataList[i] as BLGoodsCdUWork;
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
                                sqlText += "    ,BLGROUPCODERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSCODERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSFULLNAMERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSHALFNAMERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSGENRECODERF" + Environment.NewLine;
                                sqlText += "    ,GOODSRATEGRPCODERF" + Environment.NewLine;
                                sqlText += " FROM BLGOODSCDURF" + Environment.NewLine;
                                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "    AND BLGLOUPCODERF=@FINDBLGLOUPCODE" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                                //Prameterオブジェクトの作成
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaBLGloupCode = sqlCommand.Parameters.Add("@FINDBLGLOUPCODE", SqlDbType.Int);

                                //Parameterオブジェクトへ値設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.EnterpriseCode);
                                findParaBLGloupCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.BLGroupCode);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    //Updateコマンドの生成
                                    sqlText = string.Empty;
                                    sqlText += "UPDATE BLGOODSCDURF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                                    sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlText += " , BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                                    sqlText += " , BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                                    sqlText += " , BLGOODSFULLNAMERF=@BLGOODSFULLNAME" + Environment.NewLine;
                                    sqlText += " , BLGOODSHALFNAMERF=@BLGOODSHALFNAME" + Environment.NewLine;
                                    sqlText += " , BLGOODSGENRECODERF=@BLGOODSGENRECODE" + Environment.NewLine;
                                    sqlText += " , GOODSRATEGRPCODERF=@GOODSRATEGRPCODE" + Environment.NewLine;
                                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlText += "    AND BLGLOUPCODERF=@FINDBLGLOUPCODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    
                                    //KEYコマンドを再設定
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.EnterpriseCode);
                                    findParaBLGloupCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.BLGroupCode);
                                    
                                    //更新ヘッダ情報を設定
                                    //FileHeaderGuidはSelect結果から取得
                                    blGoodsCdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                    obj = (object)this;
                                    flhd = (IFileHeader)blGoodsCdUWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                }
                                else
                                {
                                    //Insertコマンドの生成
                                    sqlText = string.Empty;
                                    sqlText += "INSERT INTO BLGOODSCDURF" + Environment.NewLine;
                                    sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlText += "    ,BLGROUPCODERF" + Environment.NewLine;
                                    sqlText += "    ,BLGOODSCODERF" + Environment.NewLine;
                                    sqlText += "    ,BLGOODSFULLNAMERF" + Environment.NewLine;
                                    sqlText += "    ,BLGOODSHALFNAMERF" + Environment.NewLine;
                                    sqlText += "    ,BLGOODSGENRECODERF" + Environment.NewLine;
                                    sqlText += "    ,GOODSRATEGRPCODERF" + Environment.NewLine;
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
                                    sqlText += "    ,@BLGROUPCODE" + Environment.NewLine;
                                    sqlText += "    ,@BLGOODSCODE" + Environment.NewLine;
                                    sqlText += "    ,@BLGOODSFULLNAME" + Environment.NewLine;
                                    sqlText += "    ,@BLGOODSHALFNAME" + Environment.NewLine;
                                    sqlText += "    ,@BLGOODSGENRECODE" + Environment.NewLine;
                                    sqlText += "    ,@GOODSRATEGRPCODE" + Environment.NewLine;
                                    sqlText += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;

                                    //登録ヘッダ情報を設定
                                    obj = (object)this;
                                    flhd = (IFileHeader)blGoodsCdUWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();
                                break;

                            //全件登録のシンク処理
                            case 1:
                                //Insertコマンドの生成
                                sqlText = string.Empty;
                                sqlText += "INSERT INTO BLGOODSCDURF" + Environment.NewLine;
                                sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += "    ,BLGROUPCODERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSCODERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSFULLNAMERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSHALFNAMERF" + Environment.NewLine;
                                sqlText += "    ,BLGOODSGENRECODERF" + Environment.NewLine;
                                sqlText += "    ,GOODSRATEGRPCODERF" + Environment.NewLine;
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
                                sqlText += "    ,@BLGROUPCODE" + Environment.NewLine;
                                sqlText += "    ,@BLGOODSCODE" + Environment.NewLine;
                                sqlText += "    ,@BLGOODSFULLNAME" + Environment.NewLine;
                                sqlText += "    ,@BLGOODSHALFNAME" + Environment.NewLine;
                                sqlText += "    ,@BLGOODSGENRECODE" + Environment.NewLine;
                                sqlText += "    ,@GOODSRATEGRPCODE" + Environment.NewLine;
                                sqlText += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                                //登録ヘッダ情報を設定
                                obj = (object)this;
                                flhd = (IFileHeader)blGoodsCdUWork;
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
                        SqlParameter paraBLGloupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsHalfName = sqlCommand.Parameters.Add("@BLGOODSHALFNAME", SqlDbType.NVarChar);
                        SqlParameter paraBLGoodsGenreCode = sqlCommand.Parameters.Add("@BLGOODSGENRECODE", SqlDbType.Int);
                        SqlParameter paraGoodsRateGrpCode = sqlCommand.Parameters.Add("@GOODSRATEGRPCODE", SqlDbType.Int);

                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(blGoodsCdUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(blGoodsCdUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(blGoodsCdUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.LogicalDeleteCode);
                        paraBLGloupCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.BLGroupCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.BLGoodsCode);
                        paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.BLGoodsFullName);
                        paraBLGoodsHalfName.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.BLGoodsHalfName);
                        paraBLGoodsGenreCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.BLGoodsGenreCode);
                        paraGoodsRateGrpCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.GoodsRateGrpCode);
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
                status = WriteSQLErrorLog(ex, "BLGoodsCdULcDB.WriteSyncLocalDataProc", 0);
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
        /// <param name="blGoodsCdUWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, BLGoodsCdUWork blGoodsCdUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(blGoodsCdUWork.EnterpriseCode);

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
            // BLグループコード
            if (blGoodsCdUWork.BLGroupCode != 0)
            {
                retstring += "AND BLGROUPCODERF=@FINDBLGLOUPCODE ";
                SqlParameter paraBLGloupCode = sqlCommand.Parameters.Add("@FINDBLGLOUPCODE", SqlDbType.Int);
                paraBLGloupCode.Value = SqlDataMediator.SqlSetInt32(blGoodsCdUWork.BLGroupCode);
            }


            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → BLGoodsCdUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>BLGoodsCdUWork</returns>
        /// <remarks>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        private BLGoodsCdUWork CopyToBLGoodsCdUWorkFromReader(ref SqlDataReader myReader)
        {
            BLGoodsCdUWork wkBLGoodsCdUWork = new BLGoodsCdUWork();

            #region クラスへ格納
            wkBLGoodsCdUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkBLGoodsCdUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkBLGoodsCdUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkBLGoodsCdUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkBLGoodsCdUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkBLGoodsCdUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkBLGoodsCdUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkBLGoodsCdUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkBLGoodsCdUWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            wkBLGoodsCdUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            wkBLGoodsCdUWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            wkBLGoodsCdUWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            wkBLGoodsCdUWork.BLGoodsGenreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSGENRECODERF"));
            wkBLGoodsCdUWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSRATEGRPCODERF"));
            #endregion

            return wkBLGoodsCdUWork;
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

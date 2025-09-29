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
    /// 倉庫LCローカルDBオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 倉庫LCのローカルDB実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20096　村瀬　勝也</br>
    /// <br>Date       : 2007.04.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class WarehouseLcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// 倉庫LCローカルDBオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.04.05</br>
        /// <br></br>
        /// <br>Update Note: 2008.05.30 20081 疋田 勇人 ＰＭ.ＮＳ用に変更</br>
        /// <br></br>
        /// </remarks>
        public WarehouseLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の倉庫LC情報LISTを戻します
        /// </summary>
        /// <param name="wareHouseWorkList">検索結果</param>
        /// <param name="parawareHouseWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の倉庫LC情報LISTを戻します</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.04.05</br>
        public int Search(out List<WarehouseWork> wareHouseWorkList, WarehouseWork parawareHouseWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            wareHouseWorkList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchWarehouseProcProc(out wareHouseWorkList, parawareHouseWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "WarehouseLcDB.Search",0);
                wareHouseWorkList = new List<WarehouseWork>();
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
        /// 指定された条件の倉庫LC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="warehouseWorkList">検索結果</param>
        /// <param name="warehouseWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の倉庫LC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.04.05</br>
        public int SearchWarehouseProc(out List<WarehouseWork> warehouseWorkList, WarehouseWork warehouseWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = SearchWarehouseProcProc(out warehouseWorkList, warehouseWork, readMode, logicalMode, ref sqlConnection);
            return status;

        }

        /// <summary>
        /// 指定された条件の倉庫LC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="warehouseWorkList">検索結果</param>
        /// <param name="warehouseWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の倉庫LC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.04.05</br>
        private int SearchWarehouseProcProc(out List<WarehouseWork> warehouseWorkList, WarehouseWork warehouseWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<WarehouseWork> listdata = new List<WarehouseWork>();
            try
            {
                // 2008.05.30 upd start -------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM WAREHOUSERF  ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                sqlTxt += "    ,WAREHOUSENAMERF" + Environment.NewLine;
                sqlTxt += "    ,WAREHOUSENOTE1RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += "    ,MAINMNGWAREHOUSECDRF" + Environment.NewLine;
                sqlTxt += "    ,STOCKBLNKTREMARKRF" + Environment.NewLine;
                sqlTxt += " FROM WAREHOUSERF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.30 upd end ----------------------------<<

		        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, warehouseWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    listdata.Add(CopyToWarehouseWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "WarehouseLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            warehouseWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の倉庫LCを戻します
        /// </summary>
        /// <param name="warehouseWork">WarehouseWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の倉庫LCを戻します</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.04.05</br>
        public int Read(ref WarehouseWork warehouseWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {

               //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref warehouseWork, readMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "WarehouseLcDB.Read",0);
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
        /// 指定された条件の倉庫LCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="warehouseWork">WarehouseWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の倉庫LCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.04.05</br>
        public int ReadProc(ref WarehouseWork warehouseWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref warehouseWork, readMode, ref sqlConnection);
            return status;

        }

        /// <summary>
        /// 指定された条件の倉庫LCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="warehouseWork">WarehouseWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の倉庫LCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.04.05</br>
        private int ReadProcProc(ref WarehouseWork warehouseWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                SqlDataReader myReader = null;

                try
                {
                    //Selectコマンドの生成
                    // 2008.05.30 upd start ------------------------------------->>
                    //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM WAREHOUSERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection))
                    string sqlTxt = string.Empty;
                    sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                    sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                    sqlTxt += "    ,WAREHOUSENAMERF" + Environment.NewLine;
                    sqlTxt += "    ,WAREHOUSENOTE1RF" + Environment.NewLine;
                    sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                    sqlTxt += "    ,MAINMNGWAREHOUSECDRF" + Environment.NewLine;
                    sqlTxt += "    ,STOCKBLNKTREMARKRF" + Environment.NewLine;
                    sqlTxt += " FROM WAREHOUSERF" + Environment.NewLine;
                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                    using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))    
                    // 2008.05.30 upd end ---------------------------------------<<
                    {

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.05.30 del  
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);
                        //findParaSectionCode.Value = SqlDataMediator.SqlSetString(warehouseWork.SectionCode); // 2008.05.30 del
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        if (myReader.Read())
                        {
                            warehouseWork = CopyToWarehouseWorkFromReader(ref myReader);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    status = WriteSQLErrorLog(ex, "WarehouseLcDB.Read", 0);
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
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
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
                WarehouseWork warehouseWork = new WarehouseWork();
 
                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == warehouseWork.GetType())
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
                //戻り値セット
                //dataSyncMngWorkList = syncDataList;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "WarehouseLcDB.WriteSyncLocalData", 0);
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
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
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
        /// <br>Programmer : 20096　村瀬　勝也</br>
        /// <br>Date       : 2007.05.08</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlTxt = string.Empty; // 2008.05.30 add

            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        // 2008.05.30 upd start -------------------------------->>
                        //sqlCommand = new SqlCommand("DELETE FROM WAREHOUSERF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM WAREHOUSERF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.30 upd end ----------------------------------<<
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        WarehouseWork warehouseWork = paraSyncDataList[i] as WarehouseWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //差分モードのシンク処理
                            case 0:
                                //Selectコマンドの生成
                                // 2008.05.30 upd start -------------------------------->>
                                //sqlCommand = new SqlCommand("SELECT * FROM WAREHOUSERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
                                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                                sqlTxt += "    ,WAREHOUSENAMERF" + Environment.NewLine;
                                sqlTxt += "    ,WAREHOUSENOTE1RF" + Environment.NewLine;
                                sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                                sqlTxt += "    ,MAINMNGWAREHOUSECDRF" + Environment.NewLine;
                                sqlTxt += "    ,STOCKBLNKTREMARKRF" + Environment.NewLine;
                                sqlTxt += " FROM WAREHOUSERF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.30 upd end ----------------------------------<<

                                //Prameterオブジェクトの作成
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.05.30 del
                                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                                //Parameterオブジェクトへ値設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);
                                //findParaSectionCode.Value = SqlDataMediator.SqlSetString(warehouseWork.SectionCode); // 2008.05.30 del
                                findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {

                                    // 2008.05.30 upd start -------------------------------->>
                                    //sqlCommand.CommandText = "UPDATE WAREHOUSERF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , WAREHOUSECODERF=@WAREHOUSECODE , WAREHOUSENAMERF=@WAREHOUSENAME , WAREHOUSENOTE1RF=@WAREHOUSENOTE1 , WAREHOUSENOTE2RF=@WAREHOUSENOTE2 , WAREHOUSENOTE3RF=@WAREHOUSENOTE3 , WAREHOUSENOTE4RF=@WAREHOUSENOTE4 , WAREHOUSENOTE5RF=@WAREHOUSENOTE5 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "UPDATE WAREHOUSERF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                                    sqlTxt += " , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                                    sqlTxt += " , WAREHOUSENAMERF=@WAREHOUSENAME" + Environment.NewLine;
                                    sqlTxt += " , WAREHOUSENOTE1RF=@WAREHOUSENOTE1" + Environment.NewLine;
                                    sqlTxt += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                                    sqlTxt += " , MAINMNGWAREHOUSECDRF=@MAINMNGWAREHOUSECD" + Environment.NewLine;
                                    sqlTxt += " , STOCKBLNKTREMARKRF=@STOCKBLNKTREMARK" + Environment.NewLine;
                                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += "    AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.30 upd end ----------------------------------<<
                                    //KEYコマンドを再設定
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);
                                    //findParaSectionCode.Value = SqlDataMediator.SqlSetString(warehouseWork.SectionCode); // 2008.05.30 del
                                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);

                                    //更新ヘッダ情報を設定
                                    //FileHeaderGuidはSelect結果から取得
                                    warehouseWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                    obj = (object)this;
                                    flhd = (IFileHeader)warehouseWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                }
                                else
                                {
                                    //新規作成時のSQL文を生成
                                    // 2008.05.30 upd start --------------------------------->>
                                    //sqlCommand.CommandText = "INSERT INTO WAREHOUSERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSENOTE1RF, WAREHOUSENOTE2RF, WAREHOUSENOTE3RF, WAREHOUSENOTE4RF, WAREHOUSENOTE5RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSENOTE1, @WAREHOUSENOTE2, @WAREHOUSENOTE3, @WAREHOUSENOTE4, @WAREHOUSENOTE5)";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "INSERT INTO WAREHOUSERF" + Environment.NewLine;
                                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,WAREHOUSENAMERF" + Environment.NewLine;
                                    sqlTxt += "    ,WAREHOUSENOTE1RF" + Environment.NewLine;
                                    sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,MAINMNGWAREHOUSECDRF" + Environment.NewLine;
                                    sqlTxt += "    ,STOCKBLNKTREMARKRF" + Environment.NewLine;
                                    sqlTxt += " )" + Environment.NewLine;
                                    sqlTxt += " VALUES" + Environment.NewLine;
                                    sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                                    sqlTxt += "    ,@UPDATEDATETIME" + Environment.NewLine;
                                    sqlTxt += "    ,@ENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += "    ,@FILEHEADERGUID" + Environment.NewLine;
                                    sqlTxt += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlTxt += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlTxt += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlTxt += "    ,@SECTIONCODE" + Environment.NewLine;
                                    sqlTxt += "    ,@WAREHOUSECODE" + Environment.NewLine;
                                    sqlTxt += "    ,@WAREHOUSENAME" + Environment.NewLine;
                                    sqlTxt += "    ,@WAREHOUSENOTE1" + Environment.NewLine;
                                    sqlTxt += "    ,@CUSTOMERCODE" + Environment.NewLine;
                                    sqlTxt += "    ,@MAINMNGWAREHOUSECD" + Environment.NewLine;
                                    sqlTxt += "    ,@STOCKBLNKTREMARK" + Environment.NewLine;
                                    sqlTxt += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.30 upd end -----------------------------------<<
                                    //登録ヘッダ情報を設定
                                    obj = (object)this;
                                    flhd = (IFileHeader)warehouseWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();
                                break;

                            //全件登録のシンク処理
                            case 1:
                                //新規作成時のSQL文を生成
                                // 2008.05.30 upd start --------------------------------->>
                                //sqlCommand = new SqlCommand("INSERT INTO WAREHOUSERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSENOTE1RF, WAREHOUSENOTE2RF, WAREHOUSENOTE3RF, WAREHOUSENOTE4RF, WAREHOUSENOTE5RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSENOTE1, @WAREHOUSENOTE2, @WAREHOUSENOTE3, @WAREHOUSENOTE4, @WAREHOUSENOTE5)", sqlConnection, sqlTransaction);
                                sqlTxt += "INSERT INTO WAREHOUSERF" + Environment.NewLine;
                                sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,WAREHOUSECODERF" + Environment.NewLine;
                                sqlTxt += "    ,WAREHOUSENAMERF" + Environment.NewLine;
                                sqlTxt += "    ,WAREHOUSENOTE1RF" + Environment.NewLine;
                                sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                                sqlTxt += "    ,MAINMNGWAREHOUSECDRF" + Environment.NewLine;
                                sqlTxt += "    ,STOCKBLNKTREMARKRF" + Environment.NewLine;
                                sqlTxt += " )" + Environment.NewLine;
                                sqlTxt += " VALUES" + Environment.NewLine;
                                sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                                sqlTxt += "    ,@UPDATEDATETIME" + Environment.NewLine;
                                sqlTxt += "    ,@ENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    ,@FILEHEADERGUID" + Environment.NewLine;
                                sqlTxt += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlTxt += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                                sqlTxt += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                                sqlTxt += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += "    ,@SECTIONCODE" + Environment.NewLine;
                                sqlTxt += "    ,@WAREHOUSECODE" + Environment.NewLine;
                                sqlTxt += "    ,@WAREHOUSENAME" + Environment.NewLine;
                                sqlTxt += "    ,@WAREHOUSENOTE1" + Environment.NewLine;
                                sqlTxt += "    ,@CUSTOMERCODE" + Environment.NewLine;
                                sqlTxt += "    ,@MAINMNGWAREHOUSECD" + Environment.NewLine;
                                sqlTxt += "    ,@STOCKBLNKTREMARK" + Environment.NewLine;
                                sqlTxt += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.30 upd end -----------------------------------<<
                                //登録ヘッダ情報を設定
                                obj = (object)this;
                                flhd = (IFileHeader)warehouseWork;
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
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseNote1 = sqlCommand.Parameters.Add("@WAREHOUSENOTE1", SqlDbType.NVarChar);
                        // 2008.05.30 del start --------------------------------->>
                        //SqlParameter paraWarehouseNote2 = sqlCommand.Parameters.Add("@WAREHOUSENOTE2", SqlDbType.NVarChar);
                        //SqlParameter paraWarehouseNote3 = sqlCommand.Parameters.Add("@WAREHOUSENOTE3", SqlDbType.NVarChar);
                        //SqlParameter paraWarehouseNote4 = sqlCommand.Parameters.Add("@WAREHOUSENOTE4", SqlDbType.NVarChar);
                        //SqlParameter paraWarehouseNote5 = sqlCommand.Parameters.Add("@WAREHOUSENOTE5", SqlDbType.NVarChar);
                        // 2008.05.30 del end -----------------------------------<<
                        // 2008.05.30 add start --------------------------------->>
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraMainMngWarehouseCd = sqlCommand.Parameters.Add("@MAINMNGWAREHOUSECD", SqlDbType.NChar);
                        SqlParameter paraStockBlnktRemark = sqlCommand.Parameters.Add("@STOCKBLNKTREMARK", SqlDbType.NChar);
                        // 2008.05.30 add end -----------------------------------<<
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(warehouseWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(warehouseWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(warehouseWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(warehouseWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(warehouseWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(warehouseWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(warehouseWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(warehouseWork.SectionCode);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);
                        paraWarehouseName.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseName);
                        paraWarehouseNote1.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseNote1);
                        // 2008.05.30 del start --------------------------------->>
                        //paraWarehouseNote2.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseNote2);
                        //paraWarehouseNote3.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseNote3);
                        //paraWarehouseNote4.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseNote4);
                        //paraWarehouseNote5.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseNote5);
                        // 2008.05.30 del end -----------------------------------<<
                        // 2008.05.30 add start --------------------------------->>
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(warehouseWork.CustomerCode);
                        paraMainMngWarehouseCd.Value = SqlDataMediator.SqlSetString(warehouseWork.MainMngWarehouseCd);
                        paraStockBlnktRemark.Value = SqlDataMediator.SqlSetString(warehouseWork.StockBlnktRemark);
                        // 2008.05.30 add end -----------------------------------<<
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
                status = WriteSQLErrorLog(ex, "WarehouseLcDB.WriteSyncLocalDataProc", 0);
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
        /// <param name="warehouseWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.04.05</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, WarehouseWork warehouseWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.EnterpriseCode);

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

            // 2008.05.30 del start -------------------------->>
            ////拠点コード
            //if (warehouseWork.SectionCode != "")
            //{
            //    retstring += "AND SECTIONCODERF=@FINDSECTIONCODE ";
            //    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            //    paraSectionCode.Value = SqlDataMediator.SqlSetString(warehouseWork.SectionCode);
            //}
            // 2008.05.30 del end ----------------------------<<

            //倉庫コード
            if (warehouseWork.WarehouseCode != "")
            {
                retstring += "AND WAREHOUSECODERF=@FINDWAREHOUSECODE ";
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseWork.WarehouseCode);
            }


		    return retstring;
		}
	    #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → WarehouseWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>WarehouseWork</returns>
        /// <remarks>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.04.05</br>
        /// </remarks>
        private WarehouseWork CopyToWarehouseWorkFromReader(ref SqlDataReader myReader)
        {
            WarehouseWork wkWarehouseWork = new WarehouseWork();

            #region クラスへ格納
            wkWarehouseWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkWarehouseWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkWarehouseWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkWarehouseWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkWarehouseWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkWarehouseWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkWarehouseWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkWarehouseWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkWarehouseWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkWarehouseWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            wkWarehouseWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            wkWarehouseWork.WarehouseNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE1RF"));
            // 2008.05.30 del start ---------------------------->>
            //wkWarehouseWork.WarehouseNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE2RF"));
            //wkWarehouseWork.WarehouseNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE3RF"));
            //wkWarehouseWork.WarehouseNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE4RF"));
            //wkWarehouseWork.WarehouseNote5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENOTE5RF"));
            // 2008.05.30 del end ------------------------------<<
            // 2008.05.30 add start ---------------------------->>
            wkWarehouseWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkWarehouseWork.MainMngWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAINMNGWAREHOUSECDRF"));
            wkWarehouseWork.StockBlnktRemark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKBLNKTREMARKRF"));
            // 2008.05.30 add end ------------------------------<<
            #endregion

            return wkWarehouseWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 20098　村瀬　勝也</br>
        /// <br>Date       : 2007.04.05</br>
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

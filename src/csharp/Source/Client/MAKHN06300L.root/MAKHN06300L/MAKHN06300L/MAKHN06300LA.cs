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
    /// 税率設定マスタLCローカルDBオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 税率設定マスタLCのローカルDB実データ操作を行うクラスです。</br>
    /// <br>Programmer : 湯山　美樹</br>
    /// <br>Date       : 2007.05.18</br>
    /// <br></br>
    /// <br>Update Note: 2008.01.29 980081 山田 明友</br>
    /// <br>           : 流通基幹対応</br>
    /// <br></br>
    /// <br>Update Note: PM.NS用に変更</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.05.27</br>
    /// </remarks>
    public class TaxRateSetLcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// 税率設定マスタLCローカルDBオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 湯山　美樹</br>
        /// <br>Date       : 2007.05.18</br>
        /// </remarks>
        public TaxRateSetLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の税率設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="taxRateSetWorkList">検索結果</param>
        /// <param name="paraTaxRateSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の税率設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 湯山　美樹</br>
        /// <br>Date       : 2007.05.18</br>
        public int Search(out List<TaxRateSetWork> taxRateSetWorkList, TaxRateSetWork paraTaxRateSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            taxRateSetWorkList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchTaxRateSetProcProc(out taxRateSetWorkList, paraTaxRateSetWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "TaxRateSetLcDB.Search",0);
                taxRateSetWorkList = new List<TaxRateSetWork>();
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
        /// 指定された条件の税率設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="taxRateSetWorkList">検索結果</param>
        /// <param name="taxRateSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の税率設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 湯山　美樹</br>
        /// <br>Date       : 2007.05.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        public int SearchTaxRateSetProc(out List<TaxRateSetWork> taxRateSetWorkList, TaxRateSetWork taxRateSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = SearchTaxRateSetProcProc(out taxRateSetWorkList, taxRateSetWork, readMode, logicalMode, ref sqlConnection);
            return status;

        }


        /// <summary>
        /// 指定された条件の税率設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="taxRateSetWorkList">検索結果</param>
        /// <param name="taxRateSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の税率設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 湯山　美樹</br>
        /// <br>Date       : 2007.05.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        private int SearchTaxRateSetProcProc(out List<TaxRateSetWork> taxRateSetWorkList, TaxRateSetWork taxRateSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<TaxRateSetWork> listdata = new List<TaxRateSetWork>();
            try
            {
                // ↓ 2008.01.29 980081 c
                //sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, FRACTIONPROCCDRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF FROM TAXRATESETRF", sqlConnection);
                // 2008.05.27 upd start -------------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.27 upd end ----------------------------------------<<
                // ↑ 2008.01.29 980081 c

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, taxRateSetWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToTaxRateSetWorkFromReader(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "TaxRateSetLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            taxRateSetWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の税率設定マスタを戻します
        /// </summary>
        /// <param name="taxRateSetWork">TaxRateSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の税率設定マスタを戻します</br>
        /// <br>Programmer : 湯山　美樹</br>
        /// <br>Date       : 2007.05.18</br>
        public int Read(ref TaxRateSetWork taxRateSetWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
               //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref taxRateSetWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "TaxRateSetLcDB.Read",0);
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
        /// 指定された条件の税率設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="taxRateSetWork">TaxRateSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
          /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の税率設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 湯山　美樹</br>
        /// <br>Date       : 2007.05.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        public int ReadProc(ref TaxRateSetWork taxRateSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref taxRateSetWork, readMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// 指定された条件の税率設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="taxRateSetWork">TaxRateSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
          /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の税率設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 湯山　美樹</br>
        /// <br>Date       : 2007.05.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        private int ReadProcProc(ref TaxRateSetWork taxRateSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                // ↓ 2008.01.29 980081 c
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, FRACTIONPROCCDRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection))
                // 2008.05.27 upd start ---------------------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.27 upd end -----------------------------------<<
                    
                // ↑ 2008.01.29 980081 c
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxRateSetWork.EnterpriseCode);
                    findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.TaxRateCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        taxRateSetWork = CopyToTaxRateSetWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "TaxRateSetLcDB.Read", 0);
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
        /// <br>Programmer : 湯山　美樹</br>
        /// <br>Date       : 2007.04.13</br>
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
                TaxRateSetWork taxRateSetWork = new TaxRateSetWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == taxRateSetWork.GetType())
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
                WriteErrorLog(ex, "DataSyncMngLcDB.Write", 0);
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
        /// <br>Programmer : 湯山　美樹</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
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
        /// <br>Programmer : 湯山　美樹</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlTxt = string.Empty; // 2008.05.26 add
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        // 2008.05.27 upd start -------------------------------->>
                        //sqlCommand = new SqlCommand("DELETE FROM TAXRATESETRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.27 upd end ----------------------------------<<
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        TaxRateSetWork taxRateSetWork = paraSyncDataList[i] as TaxRateSetWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //差分モードのシンク処理
                            case 0:
                                //Selectコマンドの生成
                                // ↓ 2008.01.29 980081 c
                                //sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, FRACTIONPROCCDRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection, sqlTransaction);
                                // 2008.05.27 upd start ----------------------------------->>
                                //sqlCommand = new SqlCommand("SELECT * FROM TAXRATESETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
                                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
                                sqlTxt += " FROM TAXRATESETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.27 upd end ----------------------------------<<
                                // ↑ 2008.01.29 980081 c

                                //Prameterオブジェクトの作成
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaTaxRateCode = sqlCommand.Parameters.Add("@FINDTAXRATECODE", SqlDbType.Int);

                                //Parameterオブジェクトへ値設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxRateSetWork.EnterpriseCode);
                                findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.TaxRateCode);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    // ↓ 2008.01.29 980081 c
                                    //sqlCommand.CommandText = "UPDATE TAXRATESETRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , TAXRATECODERF=@TAXRATECODE , TAXRATEPROPERNOUNNMRF=@TAXRATEPROPERNOUNNM , TAXRATENAMERF=@TAXRATENAME , FRACTIONPROCCDRF=@FRACTIONPROCCD , TAXRATESTARTDATERF=@TAXRATESTARTDATE , TAXRATEENDDATERF=@TAXRATEENDDATE , TAXRATERF=@TAXRATE , TAXRATESTARTDATE2RF=@TAXRATESTARTDATE2 , TAXRATEENDDATE2RF=@TAXRATEENDDATE2 , TAXRATE2RF=@TAXRATE2 , TAXRATESTARTDATE3RF=@TAXRATESTARTDATE3 , TAXRATEENDDATE3RF=@TAXRATEENDDATE3 , TAXRATE3RF=@TAXRATE3 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE";
                                    // 2008.05.27 upd start ---------------------------->>
                                    //sqlCommand.CommandText = "UPDATE TAXRATESETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , TAXRATECODERF=@TAXRATECODE , TAXRATEPROPERNOUNNMRF=@TAXRATEPROPERNOUNNM , TAXRATENAMERF=@TAXRATENAME , CONSTAXLAYMETHODRF=@CONSTAXLAYMETHOD , TAXRATESTARTDATERF=@TAXRATESTARTDATE , TAXRATEENDDATERF=@TAXRATEENDDATE , TAXRATERF=@TAXRATE , TAXRATESTARTDATE2RF=@TAXRATESTARTDATE2 , TAXRATEENDDATE2RF=@TAXRATEENDDATE2 , TAXRATE2RF=@TAXRATE2 , TAXRATESTARTDATE3RF=@TAXRATESTARTDATE3 , TAXRATEENDDATE3RF=@TAXRATEENDDATE3 , TAXRATE3RF=@TAXRATE3 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND TAXRATECODERF=@FINDTAXRATECODE";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "UPDATE TAXRATESETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlTxt += " , TAXRATECODERF=@TAXRATECODE" + Environment.NewLine;
                                    sqlTxt += " , TAXRATEPROPERNOUNNMRF=@TAXRATEPROPERNOUNNM" + Environment.NewLine;
                                    sqlTxt += " , TAXRATENAMERF=@TAXRATENAME" + Environment.NewLine;
                                    sqlTxt += " , CONSTAXLAYMETHODRF=@CONSTAXLAYMETHOD" + Environment.NewLine;
                                    sqlTxt += " , TAXRATESTARTDATERF=@TAXRATESTARTDATE" + Environment.NewLine;
                                    sqlTxt += " , TAXRATEENDDATERF=@TAXRATEENDDATE" + Environment.NewLine;
                                    sqlTxt += " , TAXRATERF=@TAXRATE" + Environment.NewLine;
                                    sqlTxt += " , TAXRATESTARTDATE2RF=@TAXRATESTARTDATE2" + Environment.NewLine;
                                    sqlTxt += " , TAXRATEENDDATE2RF=@TAXRATEENDDATE2" + Environment.NewLine;
                                    sqlTxt += " , TAXRATE2RF=@TAXRATE2" + Environment.NewLine;
                                    sqlTxt += " , TAXRATESTARTDATE3RF=@TAXRATESTARTDATE3" + Environment.NewLine;
                                    sqlTxt += " , TAXRATEENDDATE3RF=@TAXRATEENDDATE3" + Environment.NewLine;
                                    sqlTxt += " , TAXRATE3RF=@TAXRATE3" + Environment.NewLine;
                                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += "    AND TAXRATECODERF=@FINDTAXRATECODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.27 upd end ------------------------------<<
                                    // ↑ 2008.01.29 980081 c

                                    //KEYコマンドを再設定
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxRateSetWork.EnterpriseCode);
                                    findParaTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.TaxRateCode);

                                    //更新ヘッダ情報を設定
                                    obj = (object)this;
                                    flhd = (IFileHeader)taxRateSetWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);
                                }
                                else
                                {
                                    //新規作成時のSQL文を生成
                                    // ↓ 2008.01.29 980081 c
                                    //sqlCommand.CommandText = "INSERT INTO TAXRATESETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, FRACTIONPROCCDRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @TAXRATECODE, @TAXRATEPROPERNOUNNM, @TAXRATENAME, @FRACTIONPROCCD, @TAXRATESTARTDATE, @TAXRATEENDDATE, @TAXRATE, @TAXRATESTARTDATE2, @TAXRATEENDDATE2, @TAXRATE2, @TAXRATESTARTDATE3, @TAXRATEENDDATE3, @TAXRATE3)";
                                    // 2008.05.27 upd start ---------------------------->>
                                    //sqlCommand.CommandText = "INSERT INTO TAXRATESETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, CONSTAXLAYMETHODRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @TAXRATECODE, @TAXRATEPROPERNOUNNM, @TAXRATENAME, @CONSTAXLAYMETHOD, @TAXRATESTARTDATE, @TAXRATEENDDATE, @TAXRATE, @TAXRATESTARTDATE2, @TAXRATEENDDATE2, @TAXRATE2, @TAXRATESTARTDATE3, @TAXRATEENDDATE3, @TAXRATE3)";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "INSERT INTO TAXRATESETRF" + Environment.NewLine;
                                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                                    sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                                    sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
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
                                    sqlTxt += "    ,@TAXRATECODE" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATEPROPERNOUNNM" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATENAME" + Environment.NewLine;
                                    sqlTxt += "    ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATESTARTDATE" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATEENDDATE" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATE" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATESTARTDATE2" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATEENDDATE2" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATE2" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATESTARTDATE3" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATEENDDATE3" + Environment.NewLine;
                                    sqlTxt += "    ,@TAXRATE3" + Environment.NewLine;
                                    sqlTxt += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.27 upd end ------------------------------<<
                                    // ↑ 2008.01.29 980081 c

                                    //登録ヘッダ情報を設定
                                    obj = (object)this;
                                    flhd = (IFileHeader)taxRateSetWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();

                                break;

                            //全件登録のシンク処理
                            case 1:
                                //新規作成時のSQL文を生成
                                // ↓ 2008.01.29 980081 c
                                //sqlCommand = new SqlCommand("INSERT INTO TAXRATESETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, FRACTIONPROCCDRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @TAXRATECODE, @TAXRATEPROPERNOUNNM, @TAXRATENAME, @FRACTIONPROCCD, @TAXRATESTARTDATE, @TAXRATEENDDATE, @TAXRATE, @TAXRATESTARTDATE2, @TAXRATEENDDATE2, @TAXRATE2, @TAXRATESTARTDATE3, @TAXRATEENDDATE3, @TAXRATE3)", sqlConnection, sqlTransaction);
                                // 2008.05.27 upd start ---------------------------->>
                                //sqlCommand = new SqlCommand("INSERT INTO TAXRATESETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, TAXRATECODERF, TAXRATEPROPERNOUNNMRF, TAXRATENAMERF, CONSTAXLAYMETHODRF, TAXRATESTARTDATERF, TAXRATEENDDATERF, TAXRATERF, TAXRATESTARTDATE2RF, TAXRATEENDDATE2RF, TAXRATE2RF, TAXRATESTARTDATE3RF, TAXRATEENDDATE3RF, TAXRATE3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @TAXRATECODE, @TAXRATEPROPERNOUNNM, @TAXRATENAME, @CONSTAXLAYMETHOD, @TAXRATESTARTDATE, @TAXRATEENDDATE, @TAXRATE, @TAXRATESTARTDATE2, @TAXRATEENDDATE2, @TAXRATE2, @TAXRATESTARTDATE3, @TAXRATEENDDATE3, @TAXRATE3)", sqlConnection, sqlTransaction);
                                sqlTxt += "INSERT INTO TAXRATESETRF" + Environment.NewLine;
                                sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATECODERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEPROPERNOUNNMRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATENAMERF" + Environment.NewLine;
                                sqlTxt += "    ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATERF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE2RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATESTARTDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATEENDDATE3RF" + Environment.NewLine;
                                sqlTxt += "    ,TAXRATE3RF" + Environment.NewLine;
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
                                sqlTxt += "    ,@TAXRATECODE" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATEPROPERNOUNNM" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATENAME" + Environment.NewLine;
                                sqlTxt += "    ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATESTARTDATE" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATEENDDATE" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATE" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATESTARTDATE2" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATEENDDATE2" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATE2" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATESTARTDATE3" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATEENDDATE3" + Environment.NewLine;
                                sqlTxt += "    ,@TAXRATE3" + Environment.NewLine;
                                sqlTxt += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.27 upd end ------------------------------<<
                                // ↑ 2008.01.29 980081 c

                                //登録ヘッダ情報を設定
                                obj = (object)this;
                                flhd = (IFileHeader)taxRateSetWork;
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
                        SqlParameter paraTaxRateCode = sqlCommand.Parameters.Add("@TAXRATECODE", SqlDbType.Int);
                        SqlParameter paraTaxRateProperNounNm = sqlCommand.Parameters.Add("@TAXRATEPROPERNOUNNM", SqlDbType.NVarChar);
                        SqlParameter paraTaxRateName = sqlCommand.Parameters.Add("@TAXRATENAME", SqlDbType.NVarChar);
                        // ↓ 2008.01.29 980081 c
                        //SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                        SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                        // ↑ 2008.01.29 980081 c
                        SqlParameter paraTaxRateStartDate = sqlCommand.Parameters.Add("@TAXRATESTARTDATE", SqlDbType.Int);
                        SqlParameter paraTaxRateEndDate = sqlCommand.Parameters.Add("@TAXRATEENDDATE", SqlDbType.Int);
                        SqlParameter paraTaxRate = sqlCommand.Parameters.Add("@TAXRATE", SqlDbType.Float);
                        SqlParameter paraTaxRateStartDate2 = sqlCommand.Parameters.Add("@TAXRATESTARTDATE2", SqlDbType.Int);
                        SqlParameter paraTaxRateEndDate2 = sqlCommand.Parameters.Add("@TAXRATEENDDATE2", SqlDbType.Int);
                        SqlParameter paraTaxRate2 = sqlCommand.Parameters.Add("@TAXRATE2", SqlDbType.Float);
                        SqlParameter paraTaxRateStartDate3 = sqlCommand.Parameters.Add("@TAXRATESTARTDATE3", SqlDbType.Int);
                        SqlParameter paraTaxRateEndDate3 = sqlCommand.Parameters.Add("@TAXRATEENDDATE3", SqlDbType.Int);
                        SqlParameter paraTaxRate3 = sqlCommand.Parameters.Add("@TAXRATE3", SqlDbType.Float);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(taxRateSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(taxRateSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxRateSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(taxRateSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(taxRateSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(taxRateSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(taxRateSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.LogicalDeleteCode);
                        paraTaxRateCode.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.TaxRateCode);
                        paraTaxRateProperNounNm.Value = SqlDataMediator.SqlSetString(taxRateSetWork.TaxRateProperNounNm);
                        paraTaxRateName.Value = SqlDataMediator.SqlSetString(taxRateSetWork.TaxRateName);
                        // ↓ 2008.01.29 980081 c
                        //paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.FractionProcCd);
                        paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(taxRateSetWork.ConsTaxLayMethod);
                        // ↑ 2008.01.29 980081 c
                        paraTaxRateStartDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(taxRateSetWork.TaxRateStartDate);
                        paraTaxRateEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(taxRateSetWork.TaxRateEndDate);
                        paraTaxRate.Value = SqlDataMediator.SqlSetDouble(taxRateSetWork.TaxRate);
                        paraTaxRateStartDate2.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(taxRateSetWork.TaxRateStartDate2);
                        paraTaxRateEndDate2.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(taxRateSetWork.TaxRateEndDate2);
                        paraTaxRate2.Value = SqlDataMediator.SqlSetDouble(taxRateSetWork.TaxRate2);
                        paraTaxRateStartDate3.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(taxRateSetWork.TaxRateStartDate3);
                        paraTaxRateEndDate3.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(taxRateSetWork.TaxRateEndDate3);
                        paraTaxRate3.Value = SqlDataMediator.SqlSetDouble(taxRateSetWork.TaxRate3);
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
                status = WriteSQLErrorLog(ex, "DataSyncMngLcDB.WriteDataSyncMngProc", 0);
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
        /// <param name="taxRateSetWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 湯山　美樹</br>
        /// <br>Date       : 2007.05.18</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, TaxRateSetWork taxRateSetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = " WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(taxRateSetWork.EnterpriseCode);

            //論理削除区分
            string wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if    (    (logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → TaxRateSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>TaxRateSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 湯山　美樹</br>
        /// <br>Date       : 2007.05.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        /// </remarks>
        private TaxRateSetWork CopyToTaxRateSetWorkFromReader(ref SqlDataReader myReader)
        {
            TaxRateSetWork taxRateSetWork = new TaxRateSetWork();

            #region クラスへ格納
            taxRateSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            taxRateSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            taxRateSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            taxRateSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            taxRateSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            taxRateSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            taxRateSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            taxRateSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            taxRateSetWork.TaxRateCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXRATECODERF"));
            taxRateSetWork.TaxRateProperNounNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TAXRATEPROPERNOUNNMRF"));
            taxRateSetWork.TaxRateName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TAXRATENAMERF"));
            // ↓ 2008.01.29 980081 c
            //taxRateSetWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
            taxRateSetWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            // ↑ 2008.01.29 980081 c
            taxRateSetWork.TaxRateStartDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATERF"));
            taxRateSetWork.TaxRateEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATERF"));
            taxRateSetWork.TaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATERF"));
            taxRateSetWork.TaxRateStartDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE2RF"));
            taxRateSetWork.TaxRateEndDate2 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE2RF"));
            taxRateSetWork.TaxRate2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE2RF"));
            taxRateSetWork.TaxRateStartDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATESTARTDATE3RF"));
            taxRateSetWork.TaxRateEndDate3 = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TAXRATEENDDATE3RF"));
            taxRateSetWork.TaxRate3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TAXRATE3RF"));
            #endregion

            return taxRateSetWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 湯山　美樹</br>
        /// <br>Date       : 2007.05.18</br>
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

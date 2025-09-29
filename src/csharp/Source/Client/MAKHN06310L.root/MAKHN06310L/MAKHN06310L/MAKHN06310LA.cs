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
    /// 全体初期値設定マスタLCローカルDBオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 全体初期値設定マスタLCのローカルDB実データ操作を行うクラスです。</br>
    /// <br>Programmer : 19026　湯山　美樹</br>
    /// <br>Date       : 2007.05.21</br>
    /// <br></br>
    /// <br>Update Note: 2008.01.29 980081 山田 明友</br>
    /// <br>           : 流通基幹対応</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.30 20081 疋田 勇人</br>
    /// <br>           : PM.NS用に変更</br>
    /// </remarks>
    /// <br>Update Note: 2010.02.05 30531 大矢 睦美</br>
    /// <br>           : 請求書タイプ毎の出力区分の追加(３項目)</br>
    /// </remarks>
    public class AllDefSetLcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// 全体初期値設定マスタLCローカルDBオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
        /// </remarks>
        public AllDefSetLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の全体初期値設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="allDefSetWorkList">検索結果</param>
        /// <param name="paraAllDefSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の全体初期値設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
        public int Search(out List<AllDefSetWork> allDefSetWorkList, AllDefSetWork paraAllDefSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            allDefSetWorkList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchAllDefSetProcProc(out allDefSetWorkList, paraAllDefSetWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AllDefSetLcDB.Search",0);
                allDefSetWorkList = new List<AllDefSetWork>();
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
        /// 指定された条件の全体初期値設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="allDefSetWorkList">検索結果</param>
        /// <param name="allDefSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の全体初期値設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        public int SearchAllDefSetProc(out List<AllDefSetWork> allDefSetWorkList, AllDefSetWork allDefSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = SearchAllDefSetProcProc(out allDefSetWorkList, allDefSetWork, readMode, logicalMode, ref sqlConnection);
            return status;
        }


        /// <summary>
        /// 指定された条件の全体初期値設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="allDefSetWorkList">検索結果</param>
        /// <param name="allDefSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の全体初期値設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        private int SearchAllDefSetProcProc(out List<AllDefSetWork> allDefSetWorkList, AllDefSetWork allDefSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<AllDefSetWork> listdata = new List<AllDefSetWork>();
            try
            {
                // ↓ 2008.01.29 980081 c
                //sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF FROM ALLDEFSETRF", sqlConnection);
                // 2008.05.30 upd start ----------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM ALLDEFSETRF", sqlConnection);
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
                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                // --- ADD  大矢睦美  2010/02/05 ---------->>>>>
                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                // --- ADD  大矢睦美  2010/02/05 ----------<<<<<
                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.30 upd end -------------------------------<<
                // ↑ 2008.01.29 980081 c

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, allDefSetWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToAllDefSetWorkFromReader(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AllDefSetLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            allDefSetWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の全体初期値設定マスタを戻します
        /// </summary>
        /// <param name="allDefSetWork">AllDefSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の全体初期値設定マスタを戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
        public int Read(ref AllDefSetWork allDefSetWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
               //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref allDefSetWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AllDefSetLcDB.Read",0);
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
        /// 指定された条件の全体初期値設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="allDefSetWork">AllDefSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の全体初期値設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        public int ReadProc(ref AllDefSetWork allDefSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref allDefSetWork, readMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// 指定された条件の全体初期値設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="allDefSetWork">AllDefSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の全体初期値設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        private int ReadProcProc(ref AllDefSetWork allDefSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                // ↓ 2008.01.29 980081 c
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
                // 2008.05.30 upd start ------------------------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
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
                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                // --- ADD  大矢睦美  2010/02/05 ---------->>>>>
                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                // --- ADD  大矢睦美  2010/02/05 ----------<<<<<
                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))    
                // 2008.05.30 upd end ---------------------------------------<<
                // ↑ 2008.01.29 980081 c
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        allDefSetWork = CopyToAllDefSetWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AllDefSetLcDB.Read", 0);
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
        /// <br>Programmer : 19026　湯山　美樹</br>
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
                AllDefSetWork allDefSetWork = new AllDefSetWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == allDefSetWork.GetType())
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
        /// <br>Programmer : 19026　湯山　美樹</br>
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
        /// <br>Programmer : 19026　湯山　美樹</br>
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
            string sqlTxt = string.Empty; // 2008.05.30 add
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {   // 2008.05.30 upd start ------------------------------->>
                        //sqlCommand = new SqlCommand("DELETE FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.30 upd end ---------------------------------<<
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        AllDefSetWork allDefSetWork = paraSyncDataList[i] as AllDefSetWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //差分モードのシンク処理
                            case 0:
                                //Selectコマンドの生成
                                // ↓ 2008.01.29 980081 c
                                //sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);
                                // 2008.05.30 upd start ------------------------------->>
                                //sqlCommand = new SqlCommand("SELECT * FROM ALLDEFSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);
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
                                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                                // --- ADD  大矢睦美  2010/02/05 ---------->>>>>
                                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                                // --- ADD  大矢睦美  2010/02/05 ----------<<<<<
                                sqlTxt += " FROM ALLDEFSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction); 
                                // 2008.05.30 upd end ---------------------------------<<
                                // ↑ 2008.01.29 980081 c

                                //Prameterオブジェクトの作成
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                                //Parameterオブジェクトへ値設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.SectionCode);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    // 2008.05.30 upd start ------------------------------->>
                                    // ↓ 2008.01.29 980081 c
                                    //sqlCommand.CommandText = "UPDATE ALLDEFSETRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , TOTALAMOUNTDISPWAYCDRF=@TOTALAMOUNTDISPWAYCD , CUSTOMERDELCHKDIVCDRF=@CUSTOMERDELCHKDIVCD , CUSTCDAUTONUMBERINGRF=@CUSTCDAUTONUMBERING , DEFDSPCUSTTTLDAYRF=@DEFDSPCUSTTTLDAY , DEFDSPCUSTCLCTMNYDAYRF=@DEFDSPCUSTCLCTMNYDAY , DEFDSPCLCTMNYMONTHCDRF=@DEFDSPCLCTMNYMONTHCD , INIDSPPRSLORCORPCDRF=@INIDSPPRSLORCORPCD , INITDSPDMDIVRF=@INITDSPDMDIV , DEFDSPBILLPRTDIVCDRF=@DEFDSPBILLPRTDIVCD , MEMBERINFODISPCDRF=@MEMBERINFODISPCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                                    //sqlCommand.CommandText = "UPDATE ALLDEFSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , TOTALAMOUNTDISPWAYCDRF=@TOTALAMOUNTDISPWAYCD , CUSTOMERDELCHKDIVCDRF=@CUSTOMERDELCHKDIVCD , CUSTCDAUTONUMBERINGRF=@CUSTCDAUTONUMBERING , DEFDSPCUSTTTLDAYRF=@DEFDSPCUSTTTLDAY , DEFDSPCUSTCLCTMNYDAYRF=@DEFDSPCUSTCLCTMNYDAY , DEFDSPCLCTMNYMONTHCDRF=@DEFDSPCLCTMNYMONTHCD , INIDSPPRSLORCORPCDRF=@INIDSPPRSLORCORPCD , INITDSPDMDIVRF=@INITDSPDMDIV , DEFDSPBILLPRTDIVCDRF=@DEFDSPBILLPRTDIVCD , MEMBERINFODISPCDRF=@MEMBERINFODISPCD , ERANAMEDISPCD1RF=@ERANAMEDISPCD1 , ERANAMEDISPCD2RF=@ERANAMEDISPCD2 , ERANAMEDISPCD3RF=@ERANAMEDISPCD3 , GOODSNOINPDIVRF=@GOODSNOINPDIV , JANCODEINPDIVRF=@JANCODEINPDIV , UNCSTLINKDIVRF=@UNCSTLINKDIV , CNSTAXAUTOCORRDIVRF=@CNSTAXAUTOCORRDIV , REMAINCNTMNGDIVRF=@REMAINCNTMNGDIV , MEMOMOVEDIVRF=@MEMOMOVEDIV , REMCNTAUTODSPDIVRF=@REMCNTAUTODSPDIV , TTLAMNTDSPRATEDIVCDRF=@TTLAMNTDSPRATEDIVCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                                    // ↑ 2008.01.29 980081 c
                                    sqlTxt = string.Empty;
                                    sqlTxt += "UPDATE ALLDEFSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                                    sqlTxt += " , TOTALAMOUNTDISPWAYCDRF=@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                                    sqlTxt += " , DEFDSPCUSTTTLDAYRF=@DEFDSPCUSTTTLDAY" + Environment.NewLine;
                                    sqlTxt += " , DEFDSPCUSTCLCTMNYDAYRF=@DEFDSPCUSTCLCTMNYDAY" + Environment.NewLine;
                                    sqlTxt += " , DEFDSPCLCTMNYMONTHCDRF=@DEFDSPCLCTMNYMONTHCD" + Environment.NewLine;
                                    sqlTxt += " , INIDSPPRSLORCORPCDRF=@INIDSPPRSLORCORPCD" + Environment.NewLine;
                                    sqlTxt += " , INITDSPDMDIVRF=@INITDSPDMDIV" + Environment.NewLine;
                                    sqlTxt += " , DEFDSPBILLPRTDIVCDRF=@DEFDSPBILLPRTDIVCD" + Environment.NewLine;
                                    sqlTxt += " , ERANAMEDISPCD1RF=@ERANAMEDISPCD1" + Environment.NewLine;
                                    sqlTxt += " , ERANAMEDISPCD2RF=@ERANAMEDISPCD2" + Environment.NewLine;
                                    sqlTxt += " , ERANAMEDISPCD3RF=@ERANAMEDISPCD3" + Environment.NewLine;
                                    sqlTxt += " , GOODSNOINPDIVRF=@GOODSNOINPDIV" + Environment.NewLine;
                                    sqlTxt += " , CNSTAXAUTOCORRDIVRF=@CNSTAXAUTOCORRDIV" + Environment.NewLine;
                                    sqlTxt += " , REMAINCNTMNGDIVRF=@REMAINCNTMNGDIV" + Environment.NewLine;
                                    sqlTxt += " , MEMOMOVEDIVRF=@MEMOMOVEDIV" + Environment.NewLine;
                                    sqlTxt += " , REMCNTAUTODSPDIVRF=@REMCNTAUTODSPDIV" + Environment.NewLine;
                                    sqlTxt += " , TTLAMNTDSPRATEDIVCDRF=@TTLAMNTDSPRATEDIVCD" + Environment.NewLine;
                                    // --- ADD  大矢睦美  2010/02/05 ---------->>>>>
                                    sqlTxt += " , DEFTTLBILLOUTPUTRF=@DEFTTLBILLOUTPUT" + Environment.NewLine;
                                    sqlTxt += " , DEFDTLBILLOUTPUTRF=@DEFDTLBILLOUTPUT" + Environment.NewLine;
                                    sqlTxt += " , DEFSLTTLBILLOUTPUTRF=@DEFSLTTLBILLOUTPUT" + Environment.NewLine;                                                                        
                                    // --- ADD  大矢睦美  2010/02/05 ----------<<<<<
                                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.30 upd end ---------------------------------<<

                                    //KEYコマンドを再設定
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.EnterpriseCode);
                                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.SectionCode);

                                    //更新ヘッダ情報を設定
                                    obj = (object)this;
                                    flhd = (IFileHeader)allDefSetWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);
                                }
                                else
                                {
                                    //新規作成時のSQL文を生成
                                    // 2008.05.30 upd start ------------------------------->>
                                    // ↓ 2008.01.29 980081 c
                                    //sqlCommand.CommandText = "INSERT INTO ALLDEFSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TOTALAMOUNTDISPWAYCD, @CUSTOMERDELCHKDIVCD, @CUSTCDAUTONUMBERING, @DEFDSPCUSTTTLDAY, @DEFDSPCUSTCLCTMNYDAY, @DEFDSPCLCTMNYMONTHCD, @INIDSPPRSLORCORPCD, @INITDSPDMDIV, @DEFDSPBILLPRTDIVCD, @MEMBERINFODISPCD)";
                                    //sqlCommand.CommandText = "INSERT INTO ALLDEFSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF, ERANAMEDISPCD1RF, ERANAMEDISPCD2RF, ERANAMEDISPCD3RF, GOODSNOINPDIVRF, JANCODEINPDIVRF, UNCSTLINKDIVRF, CNSTAXAUTOCORRDIVRF, REMAINCNTMNGDIVRF, MEMOMOVEDIVRF, REMCNTAUTODSPDIVRF, TTLAMNTDSPRATEDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TOTALAMOUNTDISPWAYCD, @CUSTOMERDELCHKDIVCD, @CUSTCDAUTONUMBERING, @DEFDSPCUSTTTLDAY, @DEFDSPCUSTCLCTMNYDAY, @DEFDSPCLCTMNYMONTHCD, @INIDSPPRSLORCORPCD, @INITDSPDMDIV, @DEFDSPBILLPRTDIVCD, @MEMBERINFODISPCD, @ERANAMEDISPCD1, @ERANAMEDISPCD2, @ERANAMEDISPCD3, @GOODSNOINPDIV, @JANCODEINPDIV, @UNCSTLINKDIV, @CNSTAXAUTOCORRDIV, @REMAINCNTMNGDIV, @MEMOMOVEDIV, @REMCNTAUTODSPDIV, @TTLAMNTDSPRATEDIVCD)";
                                    // ↑ 2008.01.29 980081 c
                                    sqlTxt = string.Empty;
                                    sqlTxt += "INSERT INTO ALLDEFSETRF" + Environment.NewLine;
                                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                                    sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                                    sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                                    sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                                    sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                                    sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                                    sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                                    sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                                    sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                                    sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                                    sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                                    // --- ADD  大矢睦美  2010/02/05 ---------->>>>>
                                    sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                                    sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                                    sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine; 
                                    // --- ADD  大矢睦美  2010/02/05 ----------<<<<<
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
                                    sqlTxt += "    ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                                    sqlTxt += "    ,@DEFDSPCUSTTTLDAY" + Environment.NewLine;
                                    sqlTxt += "    ,@DEFDSPCUSTCLCTMNYDAY" + Environment.NewLine;
                                    sqlTxt += "    ,@DEFDSPCLCTMNYMONTHCD" + Environment.NewLine;
                                    sqlTxt += "    ,@INIDSPPRSLORCORPCD" + Environment.NewLine;
                                    sqlTxt += "    ,@INITDSPDMDIV" + Environment.NewLine;
                                    sqlTxt += "    ,@DEFDSPBILLPRTDIVCD" + Environment.NewLine;
                                    sqlTxt += "    ,@ERANAMEDISPCD1" + Environment.NewLine;
                                    sqlTxt += "    ,@ERANAMEDISPCD2" + Environment.NewLine;
                                    sqlTxt += "    ,@ERANAMEDISPCD3" + Environment.NewLine;
                                    sqlTxt += "    ,@GOODSNOINPDIV" + Environment.NewLine;
                                    sqlTxt += "    ,@CNSTAXAUTOCORRDIV" + Environment.NewLine;
                                    sqlTxt += "    ,@REMAINCNTMNGDIV" + Environment.NewLine;
                                    sqlTxt += "    ,@MEMOMOVEDIV" + Environment.NewLine;
                                    sqlTxt += "    ,@REMCNTAUTODSPDIV" + Environment.NewLine;
                                    sqlTxt += "    ,@TTLAMNTDSPRATEDIVCD" + Environment.NewLine;
                                    // --- ADD  大矢睦美  2010/02/05 ---------->>>>>
                                    sqlTxt += "    ,@DEFTTLBILLOUTPUT" + Environment.NewLine;
                                    sqlTxt += "    ,@DEFDTLBILLOUTPUT" + Environment.NewLine;
                                    sqlTxt += "    ,@DEFSLTTLBILLOUTPUT" + Environment.NewLine;
                                    // --- ADD  大矢睦美  2010/02/05 ----------<<<<<
                                    sqlTxt += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.30 upd end ---------------------------------<<

                                    //登録ヘッダ情報を設定
                                    obj = (object)this;
                                    flhd = (IFileHeader)allDefSetWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();

                                break;

                            //全件登録のシンク処理
                            case 1:
                                //新規作成時のSQL文を生成
                                // 2008.05.30 upd start ------------------------------->>
                                // ↓ 2008.01.29 980081 c
                                //sqlCommand = new SqlCommand("INSERT INTO ALLDEFSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TOTALAMOUNTDISPWAYCD, @CUSTOMERDELCHKDIVCD, @CUSTCDAUTONUMBERING, @DEFDSPCUSTTTLDAY, @DEFDSPCUSTCLCTMNYDAY, @DEFDSPCLCTMNYMONTHCD, @INIDSPPRSLORCORPCD, @INITDSPDMDIV, @DEFDSPBILLPRTDIVCD, @MEMBERINFODISPCD)", sqlConnection, sqlTransaction);
                                //sqlCommand = new SqlCommand("INSERT INTO ALLDEFSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TOTALAMOUNTDISPWAYCDRF, CUSTOMERDELCHKDIVCDRF, CUSTCDAUTONUMBERINGRF, DEFDSPCUSTTTLDAYRF, DEFDSPCUSTCLCTMNYDAYRF, DEFDSPCLCTMNYMONTHCDRF, INIDSPPRSLORCORPCDRF, INITDSPDMDIVRF, DEFDSPBILLPRTDIVCDRF, MEMBERINFODISPCDRF, ERANAMEDISPCD1RF, ERANAMEDISPCD2RF, ERANAMEDISPCD3RF, GOODSNOINPDIVRF, JANCODEINPDIVRF, UNCSTLINKDIVRF, CNSTAXAUTOCORRDIVRF, REMAINCNTMNGDIVRF, MEMOMOVEDIVRF, REMCNTAUTODSPDIVRF, TTLAMNTDSPRATEDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TOTALAMOUNTDISPWAYCD, @CUSTOMERDELCHKDIVCD, @CUSTCDAUTONUMBERING, @DEFDSPCUSTTTLDAY, @DEFDSPCUSTCLCTMNYDAY, @DEFDSPCLCTMNYMONTHCD, @INIDSPPRSLORCORPCD, @INITDSPDMDIV, @DEFDSPBILLPRTDIVCD, @MEMBERINFODISPCD, @ERANAMEDISPCD1, @ERANAMEDISPCD2, @ERANAMEDISPCD3, @GOODSNOINPDIV, @JANCODEINPDIV, @UNCSTLINKDIV, @CNSTAXAUTOCORRDIV, @REMAINCNTMNGDIV, @MEMOMOVEDIV, @REMCNTAUTODSPDIV, @TTLAMNTDSPRATEDIVCD)", sqlConnection, sqlTransaction);
                                // ↑ 2008.01.29 980081 c
                                sqlTxt = string.Empty;
                                sqlTxt += "INSERT INTO ALLDEFSETRF" + Environment.NewLine;
                                sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTTTLDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCUSTCLCTMNYDAYRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPCLCTMNYMONTHCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INIDSPPRSLORCORPCDRF" + Environment.NewLine;
                                sqlTxt += "    ,INITDSPDMDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDSPBILLPRTDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD1RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD2RF" + Environment.NewLine;
                                sqlTxt += "    ,ERANAMEDISPCD3RF" + Environment.NewLine;
                                sqlTxt += "    ,GOODSNOINPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,CNSTAXAUTOCORRDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMAINCNTMNGDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,MEMOMOVEDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,REMCNTAUTODSPDIVRF" + Environment.NewLine;
                                sqlTxt += "    ,TTLAMNTDSPRATEDIVCDRF" + Environment.NewLine;
                                // --- ADD  大矢睦美  2010/02/05 ---------->>>>>
                                sqlTxt += "    ,DEFTTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFDTLBILLOUTPUTRF" + Environment.NewLine;
                                sqlTxt += "    ,DEFSLTTLBILLOUTPUTRF" + Environment.NewLine;
                                // --- ADD  大矢睦美  2010/02/05 ----------<<<<<
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
                                sqlTxt += "    ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                                sqlTxt += "    ,@DEFDSPCUSTTTLDAY" + Environment.NewLine;
                                sqlTxt += "    ,@DEFDSPCUSTCLCTMNYDAY" + Environment.NewLine;
                                sqlTxt += "    ,@DEFDSPCLCTMNYMONTHCD" + Environment.NewLine;
                                sqlTxt += "    ,@INIDSPPRSLORCORPCD" + Environment.NewLine;
                                sqlTxt += "    ,@INITDSPDMDIV" + Environment.NewLine;
                                sqlTxt += "    ,@DEFDSPBILLPRTDIVCD" + Environment.NewLine;
                                sqlTxt += "    ,@ERANAMEDISPCD1" + Environment.NewLine;
                                sqlTxt += "    ,@ERANAMEDISPCD2" + Environment.NewLine;
                                sqlTxt += "    ,@ERANAMEDISPCD3" + Environment.NewLine;
                                sqlTxt += "    ,@GOODSNOINPDIV" + Environment.NewLine;
                                sqlTxt += "    ,@CNSTAXAUTOCORRDIV" + Environment.NewLine;
                                sqlTxt += "    ,@REMAINCNTMNGDIV" + Environment.NewLine;
                                sqlTxt += "    ,@MEMOMOVEDIV" + Environment.NewLine;
                                sqlTxt += "    ,@REMCNTAUTODSPDIV" + Environment.NewLine;
                                sqlTxt += "    ,@TTLAMNTDSPRATEDIVCD" + Environment.NewLine;
                                // --- ADD  大矢睦美  2010/02/05 ---------->>>>>
                                sqlTxt += "    ,@DEFTTLBILLOUTPUT" + Environment.NewLine;
                                sqlTxt += "    ,@DEFDTLBILLOUTPUT" + Environment.NewLine;
                                sqlTxt += "    ,@DEFSLTTLBILLOUTPUT" + Environment.NewLine;
                                // --- ADD  大矢睦美  2010/02/05 ----------<<<<<
                                sqlTxt += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.30 upd end ---------------------------------<<

                                //登録ヘッダ情報を設定
                                obj = (object)this;
                                flhd = (IFileHeader)allDefSetWork;
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
                        SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                        SqlParameter paraDefDspCustTtlDay = sqlCommand.Parameters.Add("@DEFDSPCUSTTTLDAY", SqlDbType.Int);
                        SqlParameter paraDefDspCustClctMnyDay = sqlCommand.Parameters.Add("@DEFDSPCUSTCLCTMNYDAY", SqlDbType.Int);
                        SqlParameter paraDefDspClctMnyMonthCd = sqlCommand.Parameters.Add("@DEFDSPCLCTMNYMONTHCD", SqlDbType.Int);
                        SqlParameter paraIniDspPrslOrCorpCd = sqlCommand.Parameters.Add("@INIDSPPRSLORCORPCD", SqlDbType.Int);
                        SqlParameter paraInitDspDmDiv = sqlCommand.Parameters.Add("@INITDSPDMDIV", SqlDbType.Int);
                        SqlParameter paraDefDspBillPrtDivCd = sqlCommand.Parameters.Add("@DEFDSPBILLPRTDIVCD", SqlDbType.Int);
                        // ↓ 2008.01.29 980081 a
                        SqlParameter paraEraNameDispCd1 = sqlCommand.Parameters.Add("@ERANAMEDISPCD1", SqlDbType.Int);
                        SqlParameter paraEraNameDispCd2 = sqlCommand.Parameters.Add("@ERANAMEDISPCD2", SqlDbType.Int);
                        SqlParameter paraEraNameDispCd3 = sqlCommand.Parameters.Add("@ERANAMEDISPCD3", SqlDbType.Int);
                        SqlParameter paraGoodsNoInpDiv = sqlCommand.Parameters.Add("@GOODSNOINPDIV", SqlDbType.Int);
                        SqlParameter paraCnsTaxAutoCorrDiv = sqlCommand.Parameters.Add("@CNSTAXAUTOCORRDIV", SqlDbType.Int);
                        SqlParameter paraRemainCntMngDiv = sqlCommand.Parameters.Add("@REMAINCNTMNGDIV", SqlDbType.Int);
                        SqlParameter paraMemoMoveDiv = sqlCommand.Parameters.Add("@MEMOMOVEDIV", SqlDbType.Int);
                        SqlParameter paraRemCntAutoDspDiv = sqlCommand.Parameters.Add("@REMCNTAUTODSPDIV", SqlDbType.Int);
                        SqlParameter paraTtlAmntDspRateDivCd = sqlCommand.Parameters.Add("@TTLAMNTDSPRATEDIVCD", SqlDbType.Int);
                        // ↑ 2008.01.29 980081 a
                        // --- ADD  大矢睦美  2010/02/05 ---------->>>>>
                        SqlParameter paraDefTtlBillOutput = sqlCommand.Parameters.Add("@DEFTTLBILLOUTPUT", SqlDbType.Int);
                        SqlParameter paraDefDtlBillOutput = sqlCommand.Parameters.Add("@DEFDTLBILLOUTPUT", SqlDbType.Int);
                        SqlParameter paraDefSlTtlBillOutput = sqlCommand.Parameters.Add("@DEFSLTTLBILLOUTPUT", SqlDbType.Int);
                        // --- ADD  大矢睦美  2010/02/05 ----------<<<<<
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(allDefSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(allDefSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(allDefSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(allDefSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(allDefSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.SectionCode);
                        paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.TotalAmountDispWayCd);
                        paraDefDspCustTtlDay.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.DefDspCustTtlDay);
                        paraDefDspCustClctMnyDay.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.DefDspCustClctMnyDay);
                        paraDefDspClctMnyMonthCd.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.DefDspClctMnyMonthCd);
                        paraIniDspPrslOrCorpCd.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.IniDspPrslOrCorpCd);
                        paraInitDspDmDiv.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.InitDspDmDiv);
                        paraDefDspBillPrtDivCd.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.DefDspBillPrtDivCd);
                        // ↓ 2008.01.29 980081 a
                        paraEraNameDispCd1.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.EraNameDispCd1);
                        paraEraNameDispCd2.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.EraNameDispCd2);
                        paraEraNameDispCd3.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.EraNameDispCd3);
                        paraGoodsNoInpDiv.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.GoodsNoInpDiv);
                        paraCnsTaxAutoCorrDiv.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.CnsTaxAutoCorrDiv);
                        paraRemainCntMngDiv.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.RemainCntMngDiv);
                        paraMemoMoveDiv.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.MemoMoveDiv);
                        paraRemCntAutoDspDiv.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.RemCntAutoDspDiv);
                        paraTtlAmntDspRateDivCd.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.TtlAmntDspRateDivCd);
                        // ↑ 2008.01.29 980081 a
                        // --- ADD  大矢睦美  2010/02/05 ---------->>>>>
                        paraDefTtlBillOutput.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.DefTtlBillOutput);
                        paraDefDtlBillOutput.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.DefDtlBillOutput);
                        paraDefSlTtlBillOutput.Value = SqlDataMediator.SqlSetInt32(allDefSetWork.DefSlTtlBillOutput);
                        // --- ADD  大矢睦美  2010/02/05 ----------<<<<<
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
        /// <param name="allDefSetWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, AllDefSetWork allDefSetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = " WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(allDefSetWork.EnterpriseCode);

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
        /// クラス格納処理 Reader → AllDefSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AllDefSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.29 980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        /// </remarks>
        private AllDefSetWork CopyToAllDefSetWorkFromReader(ref SqlDataReader myReader)
        {
            AllDefSetWork allDefSetWork = new AllDefSetWork();

            #region クラスへ格納
            allDefSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            allDefSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            allDefSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            allDefSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            allDefSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            allDefSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            allDefSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            allDefSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            allDefSetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            allDefSetWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
            allDefSetWork.DefDspCustTtlDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDSPCUSTTTLDAYRF"));
            allDefSetWork.DefDspCustClctMnyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDSPCUSTCLCTMNYDAYRF"));
            allDefSetWork.DefDspClctMnyMonthCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDSPCLCTMNYMONTHCDRF"));
            allDefSetWork.IniDspPrslOrCorpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INIDSPPRSLORCORPCDRF"));
            allDefSetWork.InitDspDmDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INITDSPDMDIVRF"));
            allDefSetWork.DefDspBillPrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDSPBILLPRTDIVCDRF"));
            // ↓ 2008.01.29 980081 a
            allDefSetWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
            allDefSetWork.EraNameDispCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD2RF"));
            allDefSetWork.EraNameDispCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD3RF"));
            allDefSetWork.GoodsNoInpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSNOINPDIVRF"));
            allDefSetWork.CnsTaxAutoCorrDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNSTAXAUTOCORRDIVRF"));
            allDefSetWork.RemainCntMngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REMAINCNTMNGDIVRF"));
            allDefSetWork.MemoMoveDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MEMOMOVEDIVRF"));
            allDefSetWork.RemCntAutoDspDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REMCNTAUTODSPDIVRF"));
            allDefSetWork.TtlAmntDspRateDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDSPRATEDIVCDRF"));
            // ↑ 2008.01.29 980081 a
            // --- ADD  大矢睦美  2010/01/25 ---------->>>>>
            allDefSetWork.DefTtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFTTLBILLOUTPUTRF"));
            allDefSetWork.DefDtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFDTLBILLOUTPUTRF"));
            allDefSetWork.DefSlTtlBillOutput = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSLTTLBILLOUTPUTRF"));
            // --- ADD  大矢睦美  2010/01/25 ----------<<<<<
            #endregion

            return allDefSetWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 19026　湯山　美樹</br>
        /// <br>Date       : 2007.05.21</br>
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

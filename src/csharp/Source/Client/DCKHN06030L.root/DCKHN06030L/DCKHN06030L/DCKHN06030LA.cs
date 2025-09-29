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
    /// 得意先マスタ（伝票管理）LCローカルDBオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ（伝票管理）LCのローカルDB実データ操作を行うクラスです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2008.01.23</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.28 20081 疋田 勇人</br>
    /// <br>           : PM.NS用に変更</br>
    /// <br></br>
    /// </remarks>
    public class CustSlipMngLcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// 得意先マスタ（伝票管理）LCローカルDBオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.23</br>
        /// </remarks>
        public CustSlipMngLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の得意先マスタ（伝票管理）LC情報LISTを戻します
        /// </summary>
        /// <param name="custSlipMngWorkList">検索結果</param>
        /// <param name="paraCustSlipMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ（伝票管理）LC情報LISTを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.23</br>
        public int Search(out List<CustSlipMngWork> custSlipMngWorkList, CustSlipMngWork paraCustSlipMngWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            custSlipMngWorkList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchCustSlipMngProcProc(out custSlipMngWorkList, paraCustSlipMngWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "CustSlipMngLcDB.Search", 0);
                custSlipMngWorkList = new List<CustSlipMngWork>();
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
        /// 指定された条件の得意先マスタ（伝票管理）LC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="custSlipMngWorkList">検索結果</param>
        /// <param name="custSlipMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ（伝票管理）LC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.13</br>
        public int SearchCustSlipMngProc(out List<CustSlipMngWork> custSlipMngWorkList, CustSlipMngWork custSlipMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = SearchCustSlipMngProcProc(out custSlipMngWorkList, custSlipMngWork, readMode, logicalMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// 指定された条件の得意先マスタ（伝票管理）LC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="custSlipMngWorkList">検索結果</param>
        /// <param name="custSlipMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ（伝票管理）LC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.23</br>
        private int SearchCustSlipMngProcProc(out List<CustSlipMngWork> custSlipMngWorkList, CustSlipMngWork custSlipMngWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<CustSlipMngWork> listdata = new List<CustSlipMngWork>();
            try
            {
                // 2008.05.28 upd start ---------------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM CUSTSLIPMNGRF  ", sqlConnection);
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CUSTSLIP.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTKINDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlTxt += " FROM CUSTSLIPMNGRF CUSTSLIP" + Environment.NewLine;
                sqlTxt += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    AND CUST.CUSTOMERCODERF=CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.28 upd end ------------------------------------<<

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, custSlipMngWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToCustSlipMngWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "CustSlipMngLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            custSlipMngWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の得意先マスタ（伝票管理）LCを戻します
        /// </summary>
        /// <param name="custSlipMngWork">custSlipMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ（伝票管理）LCを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.23</br>
        public int Read(ref CustSlipMngWork custSlipMngWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref custSlipMngWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "CustSlipMngLcDB.Read", 0);
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
        /// 指定された条件の得意先マスタ（伝票管理）LCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="custSlipMngWork">custSlipMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ（伝票管理）LCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.13</br>
        public int ReadProc(ref CustSlipMngWork custSlipMngWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref custSlipMngWork, readMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// 指定された条件の得意先マスタ（伝票管理）LCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="custSlipMngWork">custSlipMngWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先マスタ（伝票管理）LCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.23</br>
        private int ReadProcProc(ref CustSlipMngWork custSlipMngWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                // 2008.05.28 upd start -------------------------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CUSTSLIP.CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTKINDRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SECTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += "    ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlTxt += "    ,CUSTSLIP.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlTxt += " FROM CUSTSLIPMNGRF CUSTSLIP" + Environment.NewLine;
                sqlTxt += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    AND CUST.CUSTOMERCODERF=CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))    
                // 2008.05.28 upd end ----------------------------------------<<
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                    SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.05.28 add
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipMngWork.EnterpriseCode);
                    findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.DataInputSystem);
                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.SlipPrtKind);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSlipMngWork.SectionCode); // 2008.05.28 add
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        custSlipMngWork = CopyToCustSlipMngWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "CustSlipMngLcDB.Read", 0);
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
        /// <br>Date       : 2008.01.23</br>
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
                CustSlipMngWork custSlipMngWork = new CustSlipMngWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == custSlipMngWork.GetType())
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
                WriteErrorLog(ex, "CustSlipMngLcDB.WriteSyncLocalData", 0);
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
        /// <br>Date       : 2008.01.23</br>
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
        /// <br>Date       : 2008.01.23</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlTxt = string.Empty;  // 2008.05.28 add
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        // 2008.05.28 upd start --------------------------------->>
                        //sqlCommand = new SqlCommand("DELETE FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM CUSTSLIPMNGRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.28 upd end -----------------------------------<<
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        CustSlipMngWork custSlipMngWork = paraSyncDataList[i] as CustSlipMngWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //差分モードのシンク処理
                            case 0:
                                //Selectコマンドの生成
                                // 2008.05.28 upd start -------------------------->>
                                //sqlCommand = new SqlCommand("SELECT * FROM CUSTSLIPMNGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
                                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                                sqlTxt += " FROM CUSTSLIPMNGRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                                sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                                sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.28 upd end ----------------------------<<

                                //Prameterオブジェクトの作成
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                                SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar); // 2008.05.28 add
                                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                                //Parameterオブジェクトへ値設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipMngWork.EnterpriseCode);
                                findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.DataInputSystem);
                                findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.SlipPrtKind);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSlipMngWork.SectionCode); // 2008.05.28 add
                                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.CustomerCode);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    //Updateコマンドの生成
                                    // 2008.05.28 upd start -------------------------->>
                                    //sqlCommand.CommandText = "UPDATE CUSTSLIPMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM , SLIPPRTKINDRF=@SLIPPRTKIND , CUSTOMERCODERF=@CUSTOMERCODE , CUSTOMERSNMRF=@CUSTOMERSNM , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "UPDATE CUSTSLIPMNGRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlTxt += " , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM" + Environment.NewLine;
                                    sqlTxt += " , SLIPPRTKINDRF=@SLIPPRTKIND" + Environment.NewLine;
                                    sqlTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                                    sqlTxt += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                                    sqlTxt += " , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID" + Environment.NewLine;
                                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                                    sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                                    sqlTxt += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                                    sqlTxt += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.28 upd end ----------------------------<<
                                    //KEYコマンドを再設定
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipMngWork.EnterpriseCode);
                                    findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.DataInputSystem);
                                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.SlipPrtKind);
                                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSlipMngWork.SectionCode); // 2008.05.28 add
                                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.CustomerCode);
                                    //更新ヘッダ情報を設定
                                    //FileHeaderGuidはSelect結果から取得
                                    custSlipMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                    obj = (object)this;
                                    flhd = (IFileHeader)custSlipMngWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                }
                                else
                                {
                                    //Insertコマンドの生成
                                    // 2008.05.28 upd start -------------------------->>
                                    //sqlCommand.CommandText = "INSERT INTO CUSTSLIPMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, CUSTOMERCODERF, CUSTOMERSNMRF, SLIPPRTSETPAPERIDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DATAINPUTSYSTEM, @SLIPPRTKIND, @CUSTOMERCODE, @CUSTOMERSNM, @SLIPPRTSETPAPERID)";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "INSERT INTO CUSTSLIPMNGRF" + Environment.NewLine;
                                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                                    sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
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
                                    sqlTxt += "    ,@DATAINPUTSYSTEM" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPPRTKIND" + Environment.NewLine;
                                    sqlTxt += "    ,@SECTIONCODE" + Environment.NewLine;
                                    sqlTxt += "    ,@CUSTOMERCODE" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPPRTSETPAPERID" + Environment.NewLine;
                                    sqlTxt += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.28 upd end ----------------------------<<
                                    //登録ヘッダ情報を設定
                                    obj = (object)this;
                                    flhd = (IFileHeader)custSlipMngWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();
                                break;

                            //全件登録のシンク処理
                            case 1:
                                //Insertコマンドの生成
                                // 2008.05.28 upd start -------------------------->>
                                //sqlCommand = new SqlCommand("INSERT INTO CUSTSLIPMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, CUSTOMERCODERF, CUSTOMERSNMRF, SLIPPRTSETPAPERIDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DATAINPUTSYSTEM, @SLIPPRTKIND, @CUSTOMERCODE, @CUSTOMERSNM, @SLIPPRTSETPAPERID)", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
                                sqlTxt += "INSERT INTO CUSTSLIPMNGRF" + Environment.NewLine;
                                sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                                sqlTxt += "    ,SECTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,CUSTOMERCODERF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
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
                                sqlTxt += "    ,@DATAINPUTSYSTEM" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPPRTKIND" + Environment.NewLine;
                                sqlTxt += "    ,@SECTIONCODE" + Environment.NewLine;
                                sqlTxt += "    ,@CUSTOMERCODE" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPPRTSETPAPERID" + Environment.NewLine;
                                sqlTxt += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.28 upd end ----------------------------<<
                                //登録ヘッダ情報を設定
                                obj = (object)this;
                                flhd = (IFileHeader)custSlipMngWork;
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
                        SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@SLIPPRTKIND", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar); // 2008.05.28 add
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                        SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custSlipMngWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custSlipMngWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipMngWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(custSlipMngWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custSlipMngWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custSlipMngWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custSlipMngWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.LogicalDeleteCode);
                        paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.DataInputSystem);
                        paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.SlipPrtKind);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(custSlipMngWork.SectionCode); // 2008.05.28 add
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.CustomerCode);
                        paraCustomerSnm.Value = SqlDataMediator.SqlSetString(custSlipMngWork.CustomerSnm);
                        paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(custSlipMngWork.SlipPrtSetPaperId);
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
                status = WriteSQLErrorLog(ex, "CustSlipMngLcDB.WriteSyncLocalDataProc", 0);
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
        /// <param name="custSlipMngWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.23</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustSlipMngWork custSlipMngWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipMngWork.EnterpriseCode);

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
            // データ入力システム
            if (custSlipMngWork.DataInputSystem != 0)
            {
                retstring += "AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM ";
                SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.DataInputSystem);
            }

            // 伝票印刷種別
            if (custSlipMngWork.SlipPrtKind != 0)
            {
                retstring += "AND SLIPPRTKINDRF=@FINDSLIPPRTKIND ";
                SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.SlipPrtKind);
            }

            // 2008.05.28 add start ------------------------------>>
            // 拠点コード
            if (custSlipMngWork.SectionCode != string.Empty)
            {
                retstring += "AND SECTIONCODERF=@FINDSECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(custSlipMngWork.SectionCode);
            }
            // 2008.05.28 add end --------------------------------<<

            // 得意先コード
            if (custSlipMngWork.CustomerCode != 0)
            {
                retstring += "AND CUSTOMERCODERF=@FINDCUSTOMERCODE ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipMngWork.CustomerCode);
            }

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → CustSlipMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustSlipMngWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.23</br>
        /// </remarks>
        private CustSlipMngWork CopyToCustSlipMngWorkFromReader(ref SqlDataReader myReader)
        {
            CustSlipMngWork wkCustSlipMngWork = new CustSlipMngWork();

            #region クラスへ格納
            wkCustSlipMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCustSlipMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCustSlipMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCustSlipMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCustSlipMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCustSlipMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCustSlipMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCustSlipMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCustSlipMngWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
            wkCustSlipMngWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKINDRF"));
            wkCustSlipMngWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // 2008.05.28 add
            wkCustSlipMngWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkCustSlipMngWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkCustSlipMngWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
            #endregion

            return wkCustSlipMngWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.01.23</br>
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

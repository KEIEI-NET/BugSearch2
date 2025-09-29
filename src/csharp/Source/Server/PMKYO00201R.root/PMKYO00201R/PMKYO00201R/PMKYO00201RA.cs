//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 通信テストツール
// プログラム概要   : データセンターに対して追加・検索処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2014/09/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
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
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 通信テストツール処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 通信テストツール処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2014/09/18</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
	public class APNSNetworkTestDB : RemoteDB, IAPNSNetworkTestDB
    {
        /// <summary>
        /// データ送信処理READDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/09/18</br>
        /// </remarks>
        public APNSNetworkTestDB()
        {
        }

        #region ◆ 通信テストツールデータ検索処理 ◆
        /// <summary>
        /// データ送信の画面の初期化データ検索処理
        /// </summary>
        /// <param name="tusinTestLogList">検索パラメータ</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ送信画面の初期化データ検索を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2014/09/18</br>
        /// 
        public int SearchLogData(ArrayList tusinTestLogList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retMessage = string.Empty;

            if (tusinTestLogList == null || tusinTestLogList.Count == 0)
            {
                return status;
            }

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
            if (_connectionText == null || _connectionText == "")
            {
                return status;
            }

            sqlConnection = new SqlConnection(_connectionText);
            sqlConnection.Open();

            sqlCommand = new SqlCommand("", sqlConnection);
            try
            {
                // Selectコマンドの生成
                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, MACHINEIPADDRRF, TESTDATETIMERF, TESTRESULTSRF, TESTERRCONTENTSRF FROM COMMTESTLOGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MACHINEIPADDRRF=@FINDMACHINEIPADDR";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaMachineIPAddr = sqlCommand.Parameters.Add("@FINDMACHINEIPADDR", SqlDbType.NVarChar);

                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(((TusinTestLogWork)tusinTestLogList[0]).EnterpriseCode);
                findParaMachineIPAddr.Value = SqlDataMediator.SqlSetString(((TusinTestLogWork)tusinTestLogList[0]).MachineIPAddr);


                sqlCommand.CommandText = sqlStr;
                sqlCommand.CommandTimeout = 600;

                // 読み込み
                myReader = sqlCommand.ExecuteReader();

				while (myReader.Read())
                {
                    status = status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
                }
                
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APNSNetworkTestDB.SearchLogData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion ◆ データ送信の画面の初期化データ検索処理 ◆

        #region ◆ 通信テストツールデータ登録処理 ◆
        /// <summary>
        /// 通信テストツールデータ登録
        /// </summary>
        /// <param name="tusinTestLogList">登録内容</param>
        /// <param name="message">メッセージ</param>
        /// <returns></returns>
        public int InsertLogData(ArrayList tusinTestLogList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = string.Empty;

            if (tusinTestLogList == null || tusinTestLogList.Count == 0)
            {
                return status;
            }

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
            if (_connectionText == null || _connectionText == "")
            {
                return status;
            }

            sqlConnection = new SqlConnection(_connectionText);
            sqlConnection.Open();

            TusinTestLogWork tusinTestLogWork = (TusinTestLogWork)tusinTestLogList[0];

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, null);

            sqlText = "INSERT INTO COMMTESTLOGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, MACHINEIPADDRRF, TESTDATETIMERF, TESTRESULTSRF, TESTERRCONTENTSRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @MACHINEIPADDR, @TESTDATETIME, @TESTRESULTS, @TESTERRCONTENTS)";

            //登録ヘッダ情報を設定
            object obj = (object)this;
            IFileHeader flhd = (IFileHeader)tusinTestLogWork;
            FileHeader fileHeader = new FileHeader(obj);
            fileHeader.SetInsertHeader(ref flhd, obj);

            //Prameterオブジェクトの作成
            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraMachineIPAddr = sqlCommand.Parameters.Add("@MACHINEIPADDR", SqlDbType.NVarChar);
            SqlParameter paraTestDateTime = sqlCommand.Parameters.Add("@TESTDATETIME", SqlDbType.BigInt);
            SqlParameter paraTestResults = sqlCommand.Parameters.Add("@TESTRESULTS", SqlDbType.Int);
            SqlParameter paraTestErrContents = sqlCommand.Parameters.Add("@TESTERRCONTENTS", SqlDbType.NVarChar);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tusinTestLogWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tusinTestLogWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(tusinTestLogWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(tusinTestLogWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(tusinTestLogWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(tusinTestLogWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(tusinTestLogWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(tusinTestLogWork.LogicalDeleteCode);
            paraMachineIPAddr.Value = SqlDataMediator.SqlSetString(tusinTestLogWork.MachineIPAddr);
            paraTestDateTime.Value = SqlDataMediator.SqlSetLong(tusinTestLogWork.TestDateTime);
            paraTestResults.Value = SqlDataMediator.SqlSetInt32(tusinTestLogWork.TestResults);
            paraTestErrContents.Value = SqlDataMediator.SqlSetString(tusinTestLogWork.TestErrContents);

            sqlCommand.CommandText = sqlText;
            sqlCommand.CommandTimeout = 600;
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (myReader != null)
            {
                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                myReader.Dispose();
            }

            if (sqlCommand != null)
            {
                sqlCommand.Cancel();
                sqlCommand.Dispose();
            }

            return status;
        }
        #endregion
    }
}

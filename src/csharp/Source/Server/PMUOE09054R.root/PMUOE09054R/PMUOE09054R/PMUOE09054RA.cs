//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : UOE接続先情報マスタメンテナンス
// プログラム概要   : UOE接続先情報マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : caowj
// 作 成 日  2010/07/26  修正内容 : 新規作成
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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE接続先情報DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE接続先情報の実データ操作を行うクラスです。</br>
    /// <br>Programmer : caowj</br>
    /// <br>Date       : 2010/07/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class UOEConnectInfoDB : RemoteDB, IUOEConnectInfoDB
    {
        #region constructor
        /// <summary>
        /// UOE接続先情報DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public UOEConnectInfoDB()
            :
            base("PMUOE09056D", "Broadleaf.Application.Remoting.ParamData.UOEConnectInfoWork", "UOECONNECTINFORF")
        {
        }
        #endregion

        #region Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)

        /// <summary>
        /// 指定された企業コードのUOE接続先情報LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードのUOE接続先情報LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public int Search(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            try
            {
                return SearchProc(out retobj, paraobj, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)");
                retobj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// 指定された企業コードのUOE接続先情報LISTを全て戻します
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードのUOE接続先情報LISTを全て戻します</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        private int SearchProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            UOEConnectInfoWork uOEConnectInfoWork = null;
            UOEConnectInfoWork wkUOEConnectInfoWork = null;

            retobj = null;

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                uOEConnectInfoWork = paraobj as UOEConnectInfoWork;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //データ読込
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ", sqlConnection);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ", sqlConnection);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection);
                }
                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    wkUOEConnectInfoWork = new UOEConnectInfoWork();

                    #region 値のセット

                    wkUOEConnectInfoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkUOEConnectInfoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkUOEConnectInfoWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkUOEConnectInfoWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkUOEConnectInfoWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkUOEConnectInfoWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkUOEConnectInfoWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkUOEConnectInfoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkUOEConnectInfoWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
                    wkUOEConnectInfoWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                    wkUOEConnectInfoWork.SocketCommPort = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SOCKETCOMMPORTRF"));
                    wkUOEConnectInfoWork.ReceiveComputerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVECOMPUTERNMRF"));
                    wkUOEConnectInfoWork.ClientTimeOut = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLIENTTIMEOUTRF"));

                    #endregion

                    al.Add(wkUOEConnectInfoWork);

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
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retobj = al;
            return status;
        }
        #endregion

        #region Search(out ArrayList retArray,UOEConnectInfoWork uOEConnectInfoWork, int readMode,ConstantManagement.LogicalMode logicalMode , ref SqlConnection sqlConnection)

        /// <summary>
        /// 指定された企業コードのUOE接続先情報LISTを全て戻します
        /// </summary>
        /// <param name="retArray">検索結果</param>
        /// <param name="uOEConnectInfoWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードのUOE接続先情報LISTを全て戻します</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public int Search(out ArrayList retArray, UOEConnectInfoWork uOEConnectInfoWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            try
            {
                UOEConnectInfoWork wkUOEConnectInfoWork = null;
                retArray = null;

                ArrayList al = new ArrayList();
                try
                {
                    //データ読込
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ", sqlConnection);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ", sqlConnection);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection);
                    }
                    SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        wkUOEConnectInfoWork = new UOEConnectInfoWork();
                        #region 値のセット
                        wkUOEConnectInfoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkUOEConnectInfoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkUOEConnectInfoWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        wkUOEConnectInfoWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                        wkUOEConnectInfoWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                        wkUOEConnectInfoWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                        wkUOEConnectInfoWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                        wkUOEConnectInfoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkUOEConnectInfoWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
                        wkUOEConnectInfoWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                        wkUOEConnectInfoWork.SocketCommPort = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SOCKETCOMMPORTRF"));
                        wkUOEConnectInfoWork.ReceiveComputerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVECOMPUTERNMRF"));
                        wkUOEConnectInfoWork.ClientTimeOut = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLIENTTIMEOUTRF"));

                        #endregion

                        al.Add(wkUOEConnectInfoWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }

                retArray = al;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.Search(out ArrayList retArray,UOEConnectInfoWork uOEConnectInfoWork, int readMode,ConstantManagement.LogicalMode logicalMode , ref SqlConnection sqlConnection)");
                retArray = new ArrayList();
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region Read(ref byte[] parabyte, int readMode)

        /// <summary>
        /// 指定された企業コードのUOE接続先情報を戻します
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードのUOE接続先情報を戻します</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public int Read(ref byte[] parabyte, int readMode)
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                UOEConnectInfoWork uOEConnectInfoWork = new UOEConnectInfoWork();

                try
                {
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    // XMLの読み込み
                    uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    //Selectコマンドの生成
                    using (sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMMASSEMBLYIDRF=@FINDCOMMASSEMBLYID AND CASHREGISTERNORF=@FINDCASHREGISTERNO ", sqlConnection))
                    {
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCommAssemblyId = sqlCommand.Parameters.Add("@FINDCOMMASSEMBLYID", SqlDbType.NVarChar);
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                        findParaCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        if (myReader.Read())
                        {
                            #region 値のセット
                            uOEConnectInfoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                            uOEConnectInfoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                            uOEConnectInfoWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                            uOEConnectInfoWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                            uOEConnectInfoWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                            uOEConnectInfoWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                            uOEConnectInfoWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                            uOEConnectInfoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            uOEConnectInfoWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
                            uOEConnectInfoWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                            uOEConnectInfoWork.SocketCommPort = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SOCKETCOMMPORTRF"));
                            uOEConnectInfoWork.ReceiveComputerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVECOMPUTERNMRF"));
                            uOEConnectInfoWork.ClientTimeOut = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLIENTTIMEOUTRF"));
                            #endregion
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.Read");
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        #endregion

        #region Search(out byte[] retbyte, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        /// <summary>
        /// 指定された企業コードのUOE接続先情報マスタLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retbyte">検索結果</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードのUOE接続先情報マスタLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/27</br>
        /// </remarks>
        public int Search(out byte[] retbyte, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            bool nextData;
            int retTotalCnt;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retbyte = null;
            try
            {
                status = SearchUOEConnectInfoProc(out retbyte, out retTotalCnt, out nextData, parabyte, readMode, logicalMode, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MailInfoSettingDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region SearchUOEConnectInfoProc(out byte[] retbyte, out int retTotalCnt, out bool nextData, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        /// <summary>
        /// 指定された企業コードのUOE接続先情報マスタLISTを全て戻します
        /// </summary>
        /// <param name="retbyte">検索結果</param>
        /// <param name="retTotalCnt">検索対象総件数</param>		
        /// <param name="nextData">次データ有無</param>
        /// <param name="parabyte">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="readCnt">READ件数（0の場合はALL）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードのUOE接続先情報マスタLISTを全て戻します</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/27</br>
        /// </remarks>
        private int SearchUOEConnectInfoProc(out byte[] retbyte, out int retTotalCnt, out bool nextData, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommandCount = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            UOEConnectInfoWork uOEConnectInfoWork = new UOEConnectInfoWork();
            uOEConnectInfoWork = null;

            retbyte = null;

            //総件数を0で初期化
            retTotalCnt = 0;

            //件数指定リードの場合には指定件数＋１件リードする
            int _readCnt = readCnt;
            if (_readCnt > 0) _readCnt += 1;
            //次レコード無しで初期化
            nextData = false;

            ArrayList al = new ArrayList();

            try
            {
                try
                {
                    // XMLの読み込み
                    uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));

                    //※各publicメソッドの開始時にコネクション文字列を取得
                    //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    //SQL文生成
                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    //件数指定リードで一件目リードの場合データ総件数を取得
                    if (readCnt > 0)
                    {
                        if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                        {
                            sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ", sqlConnection);
                            //論理削除区分設定
                            SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                        }
                        else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                        {
                            sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ", sqlConnection);
                            //論理削除区分設定
                            SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                            if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                            else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                        }
                        else
                        {
                            sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection);
                        }
                        SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);

                        retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
                    }

                    //データ読込
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ", sqlConnection);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ", sqlConnection);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection);
                    }
                    SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    int retCnt = 0;
                    while (myReader.Read())
                    {
                        //戻り値カウンタカウント
                        retCnt += 1;
                        if (readCnt > 0)
                        {
                            //戻り値の件数が取得指示件数を超えた場合終了
                            if (readCnt < retCnt)
                            {
                                nextData = true;
                                break;
                            }
                        }

                        al.Add(CopyToUOEConnectInfoWorkFromReader(ref myReader));

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }

                // XMLへ変換し、文字列のバイナリ化
                UOEConnectInfoWork[] UOEConnectInfoWorks = (UOEConnectInfoWork[])al.ToArray(typeof(UOEConnectInfoWork));
                retbyte = XmlByteSerializer.Serialize(UOEConnectInfoWorks);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.SearchUOEConnectInfoProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommandCount != null) sqlCommandCount.Dispose();
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region Write(ref byte[] parabyte)

        /// <summary>
        /// UOE接続先情報を登録、更新します
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE接続先情報を登録、更新します</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public int Write(ref byte[] parabyte)
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                try
                {
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    // XMLの読み込み
                    UOEConnectInfoWork uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    //Selectコマンドの生成
                    using (sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMMASSEMBLYIDRF=@FINDCOMMASSEMBLYID AND CASHREGISTERNORF=@FINDCASHREGISTERNO ", sqlConnection))
                    {

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCommAssemblyId = sqlCommand.Parameters.Add("@FINDCOMMASSEMBLYID", SqlDbType.NVarChar);
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                        findParaCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != uOEConnectInfoWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (uOEConnectInfoWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE UOECONNECTINFORF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , COMMASSEMBLYIDRF=@COMMASSEMBLYID , CASHREGISTERNORF=@CASHREGISTERNO , SOCKETCOMMPORTRF=@SOCKETCOMMPORT , RECEIVECOMPUTERNMRF=@RECEIVECOMPUTERNM , CLIENTTIMEOUTRF=@CLIENTTIMEOUT WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMMASSEMBLYIDRF=@FINDCOMMASSEMBLYID AND CASHREGISTERNORF=@FINDCASHREGISTERNO ";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                            findParaCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);
                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uOEConnectInfoWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (uOEConnectInfoWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = "INSERT INTO UOECONNECTINFORF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, COMMASSEMBLYIDRF, CASHREGISTERNORF, SOCKETCOMMPORTRF, RECEIVECOMPUTERNMRF, CLIENTTIMEOUTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @COMMASSEMBLYID, @CASHREGISTERNO, @SOCKETCOMMPORT, @RECEIVECOMPUTERNM, @CLIENTTIMEOUT) ";

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uOEConnectInfoWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (!myReader.IsClosed) myReader.Close();

                        //Prameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCommAssemblyId = sqlCommand.Parameters.Add("@COMMASSEMBLYID", SqlDbType.NVarChar);
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                        SqlParameter paraSocketCommPort = sqlCommand.Parameters.Add("@SOCKETCOMMPORT", SqlDbType.Int);
                        SqlParameter paraReceiveComputerNm = sqlCommand.Parameters.Add("@RECEIVECOMPUTERNM", SqlDbType.NVarChar);
                        SqlParameter paraClientTimeOut = sqlCommand.Parameters.Add("@CLIENTTIMEOUT", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uOEConnectInfoWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uOEConnectInfoWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(uOEConnectInfoWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.LogicalDeleteCode);
                        paraCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);
                        paraSocketCommPort.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.SocketCommPort);
                        paraReceiveComputerNm.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.ReceiveComputerNm);
                        paraClientTimeOut.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.ClientTimeOut);
                        sqlCommand.ExecuteNonQuery();

                        // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
                        parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);

                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.Write");
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader.IsClosed == false) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region LogicalDelete & RevivalLogicalDelete

        /// <summary>
        /// UOE接続先情報を論理削除します
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE接続先情報を論理削除します</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public int LogicalDelete(ref byte[] parabyte)
        {
            try
            {
                return LogicalDeleteProc(ref parabyte, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.LogicalDelete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// 論理削除UOE接続先情報を復活します
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 論理削除UOE接続先情報を復活します</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref byte[] parabyte)
        {
            try
            {
                return LogicalDeleteProc(ref parabyte, 1);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.RevivalLogicalDelete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// UOE接続先情報の論理削除を操作します
        /// </summary>
        /// <param name="parabyte">UOEConnectInfoWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE接続先情報の論理削除を操作します</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        private int LogicalDeleteProc(ref byte[] parabyte, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // XMLの読み込み
                UOEConnectInfoWork uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                using (sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMMASSEMBLYIDRF=@FINDCOMMASSEMBLYID AND CASHREGISTERNORF=@FINDCASHREGISTERNO ", sqlConnection))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCommAssemblyId = sqlCommand.Parameters.Add("@FINDCOMMASSEMBLYID", SqlDbType.NVarChar);
                    SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                    findParaCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                    findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != uOEConnectInfoWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }
                        //現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlCommand.CommandText = "UPDATE UOECONNECTINFORF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMMASSEMBLYIDRF=@FINDCOMMASSEMBLYID AND CASHREGISTERNORF=@FINDCASHREGISTERNO ";
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                        findParaCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);

                        //更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)uOEConnectInfoWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();

                    //論理削除モードの場合
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }
                        else if (logicalDelCd == 0) uOEConnectInfoWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                        else uOEConnectInfoWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1) uOEConnectInfoWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                        else
                        {
                            if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                            else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
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
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uOEConnectInfoWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();

                    // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
                    parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);
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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader.IsClosed == false) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;

        }
        #endregion

        #region Delete(byte[] parabyte)

        /// <summary>
        /// UOE接続先情報を物理削除します
        /// </summary>
        /// <param name="parabyte">UOE接続先情報オブジェクト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : UOE接続先情報を物理削除します</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/26</br>
        /// </remarks>
        public int Delete(byte[] parabyte)
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                try
                {
                    //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    UOEConnectInfoWork uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    using (sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMMASSEMBLYIDRF=@FINDCOMMASSEMBLYID AND CASHREGISTERNORF=@FINDCASHREGISTERNO ", sqlConnection))
                    {
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCommAssemblyId = sqlCommand.Parameters.Add("@FINDCOMMASSEMBLYID", SqlDbType.NVarChar);
                        SqlParameter findParaCashRegisterNo = sqlCommand.Parameters.Add("@FINDCASHREGISTERNO", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                        findParaCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                        findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != uOEConnectInfoWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "DELETE FROM UOECONNECTINFORF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND COMMASSEMBLYIDRF=@FINDCOMMASSEMBLYID AND CASHREGISTERNORF=@FINDCASHREGISTERNO ";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.EnterpriseCode);
                            findParaCommAssemblyId.Value = SqlDataMediator.SqlSetString(uOEConnectInfoWork.CommAssemblyId);
                            findParaCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uOEConnectInfoWork.CashRegisterNo);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }
                        if (!myReader.IsClosed) myReader.Close();

                        sqlCommand.ExecuteNonQuery();
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UOEConnectInfoDB.Delete");
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader.IsClosed == false) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        # region -- クラスメンバーコピー処理 --
        /// <summary>
        /// UOE接続先情報マスタクラス格納処理 Reader → UOEConnectInfoWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>UOEConnectInfoWork</returns>
        /// <remarks>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/07/27</br>
        /// </remarks>
        private UOEConnectInfoWork CopyToUOEConnectInfoWorkFromReader(ref SqlDataReader myReader)
        {
            UOEConnectInfoWork wkUOEConnectInfoWork = new UOEConnectInfoWork();

            #region クラスへ格納
            wkUOEConnectInfoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkUOEConnectInfoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkUOEConnectInfoWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkUOEConnectInfoWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkUOEConnectInfoWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkUOEConnectInfoWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkUOEConnectInfoWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkUOEConnectInfoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkUOEConnectInfoWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
            wkUOEConnectInfoWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
            wkUOEConnectInfoWork.SocketCommPort = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SOCKETCOMMPORTRF"));
            wkUOEConnectInfoWork.ReceiveComputerNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECEIVECOMPUTERNMRF"));
            wkUOEConnectInfoWork.ClientTimeOut = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLIENTTIMEOUTRF"));
            #endregion

            return wkUOEConnectInfoWork;
        }
        #endregion
    }
}


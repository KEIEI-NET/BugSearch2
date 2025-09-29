//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 接続先情報マスタメンテナンス
// プログラム概要   : 接続先情報マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10901034-00 作成担当 : lyc
// 作 成 日  2013/06/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using System;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using System.Data;
using Broadleaf.Xml.Serialization;
using System.Text;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 接続先情報設定DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 接続先情報設定の実データ操作を行うクラスです。</br>
    /// <br>Programmer : lyc</br>
    /// <br>Date       : 2013/06/26</br>
    /// <br>管理番号   : 10901034-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SAndEConnectInfoPrcPrStDB : RemoteDB, ISAndEConnectInfoPrcPrStDB
    {
        /// <summary>
        /// 接続先情報マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public SAndEConnectInfoPrcPrStDB()
            : base("PMSAE09036D", "Broadleaf.Application.Remoting.ParamData.ConnectInfoWork", "CONNECTINFORF")
        {

        }

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → ConnectInfoWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ConnectInfoWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private ConnectInfoWork CopyToConnectInfoWorkFromReader(ref SqlDataReader myReader)
        {
            ConnectInfoWork connectInfoWork = new ConnectInfoWork();

            this.CopyToConnectInfoWorkFromReader(ref myReader, ref connectInfoWork);

            return connectInfoWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → ConnectInfoWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="connectInfoWork">ConnectInfoWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private void CopyToConnectInfoWorkFromReader(ref SqlDataReader myReader, ref ConnectInfoWork connectInfoWork)
        {
            if (myReader != null && connectInfoWork != null)
            {
                # region クラスへ格納
                connectInfoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                connectInfoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                connectInfoWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                connectInfoWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                connectInfoWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                connectInfoWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                connectInfoWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                connectInfoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                connectInfoWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                connectInfoWork.ConnectPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONNECTPASSWORDRF"));
                connectInfoWork.ConnectUserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONNECTUSERIDRF"));
                connectInfoWork.DaihatsuOrdreDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DAIHATSUORDREDIVRF"));
                connectInfoWork.LoginTimeoutVal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGINTIMEOUTVALRF"));
                connectInfoWork.OrderUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERURLRF"));
                connectInfoWork.StockCheckUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKCHECKURLRF"));
                connectInfoWork.CnectProgramType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNECTPROGRAMTYPERF"));
                connectInfoWork.CnectFileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CNECTFILEIDRF"));
                connectInfoWork.CnectSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNECTSENDDIVRF"));
                connectInfoWork.CnectObjectDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNECTOBJECTDIVRF"));
                connectInfoWork.RetryCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETRYCNTRF"));
                connectInfoWork.AutoSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOSENDDIVRF"));
                connectInfoWork.BootTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOOTTIMERF"));
                connectInfoWork.SendMachineIpAddr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDMACHINEIPADDRRF"));
                connectInfoWork.SendMachineName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDMACHINENAMERF"));
                connectInfoWork.SendMachineIpAddr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDMACHINEIPADDRRF"));
                connectInfoWork.SAndECnctPass = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SANDECNCTPASSRF"));
                connectInfoWork.SAndECnctUserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SANDECNCTUSERIDRF"));
                connectInfoWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                # endregion
            }
        }

        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            if (sqlConnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlConnection.State & ConnectionState.Open) == 0)
                {
                    sqlConnection.Open();
                }

                // トランザクションの生成(開始)
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return sqlTransaction;
        }
        # endregion [コネクション生成処理]

        #region IConnectInfoPrcPrStDB メンバ

        #region Search
        /// <summary>
        /// 指定された企業コードの接続先情報設定LISTを全て戻します。
        /// </summary>
        /// <param name="outConnectInfoPrcPrSt">検索結果</param>
        /// <param name="paraConnectInfoWork">パラメー</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの接続先情報設定LISTを全て戻します。</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public int Search(out object outConnectInfoPrcPrSt, object paraConnectInfoWork, int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode)
        {     
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList connectInfoPrcPrStList = null;
            ConnectInfoWork connectInfoWork = null;

            outConnectInfoPrcPrSt = new CustomSerializeArrayList();

            try
            {
                connectInfoWork = paraConnectInfoWork as ConnectInfoWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = this.SearchProc(out connectInfoPrcPrStList, connectInfoWork, readMode, logicalMode, ref sqlConnection);

                if (connectInfoPrcPrStList != null && connectInfoPrcPrStList.Count != 0)
                {
                    (outConnectInfoPrcPrSt as CustomSerializeArrayList).AddRange(connectInfoPrcPrStList);
                }

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SAndEConnectInfoPrcPrStDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.Search", status);
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
        /// 指定された企業コードの接続先情報設定LISTを全て戻します。
        /// </summary>
        /// <param name="connectInfoPrcPrStList">検索結果</param>
        /// <param name="connectInfoWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの接続先情報設定LISTを全て戻します。</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList connectInfoPrcPrStList, ConnectInfoWork connectInfoWork, int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlText.Append("SELECT CREATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                sqlText.Append("    ,SUPPLIERCDRF" + Environment.NewLine);
                sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);      //接続パスワード
                sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);        //接続ユーザID
                sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);     //発注手配区分（ダイハツ）
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);      //ログインタイムアウト
                sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);             //発注URL
                sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);        //在庫確認URL
                sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);     //接続プログラムタイプ
                sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);          //接続ファイルID
                sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);         //接続送信区分
                sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);       //接続対象区分
                sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);             //リトライ回数
                sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);          //自動送信区分
                sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);             //起動時間
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);    //送信端末(IPアドレス）
                sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);      //送信端末(コンピューター名）
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);
                sqlText.Append("    ,SANDECNCTPASSRF" + Environment.NewLine);        //S&E接続パスワード
                sqlText.Append("    ,SANDECNCTUSERIDRF" + Environment.NewLine);      //S&E接続ユーザID
                sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);       //端末番号
                sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                //----- ADD 2013/07/04 田建委 ----->>>>>
                sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine);
                //----- ADD 2013/07/04 田建委 -----<<<<<
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);

                //----- ADD 2013/07/04 田建委 ----->>>>>
                //Parameterオブジェクトへ値設定
                SqlParameter findParaSupplierCdRF = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);
                findParaSupplierCdRF.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                //----- ADD 2013/07/04 田建委 -----<<<<<

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(this.CopyToConnectInfoWorkFromReader(ref myReader));
                }

                // 検索結果がある場合
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SAndEConnectInfoPrcPrStDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.SearchProc", status);
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

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            connectInfoPrcPrStList = al;

            return status;
        }

        /// <summary>
        /// 指定された接続先情報設定Guidの接続先情報設定を戻します
        /// </summary>
        /// <param name="parabyte">ConnectInfoWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :  指定された接続先情報設定Guidの接続先情報設定を戻します</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public int Read(ref byte[] parabyte, int readMode)
        {
            return this.ReadProc(ref parabyte, readMode);
        }

        /// <summary>
        /// 指定された接続先情報設定Guidの接続先情報設定を戻します
        /// </summary>
        /// <param name="parabyte">ConnectInfoWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :  指定された接続先情報設定Guidの接続先情報設定を戻します</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ConnectInfoWork connectInfoWork = new ConnectInfoWork();
            try
            {
                // XMLの読み込み
                connectInfoWork = (ConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(ConnectInfoWork));

                if (connectInfoWork == null)
                {
                    return status;
                }

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                StringBuilder sqlText = new StringBuilder();

                sqlText.Append("SELECT CREATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                sqlText.Append("    ,SUPPLIERCDRF" + Environment.NewLine);
                sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);      //接続パスワード
                sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);        //接続ユーザID
                sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);     //発注手配区分（ダイハツ）
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);      //ログインタイムアウト
                sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);             //発注URL
                sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);        //在庫確認URL
                sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);     //接続プログラムタイプ
                sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);          //接続ファイルID
                sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);         //接続送信区分
                sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);       //接続対象区分
                sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);             //リトライ回数
                sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);          //自動送信区分
                sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);             //起動時間
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);    //送信端末(IPアドレス）
                sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);      //送信端末(コンピューター名）
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);
                sqlText.Append("    ,SANDECNCTPASSRF" + Environment.NewLine);        //S&E接続パスワード
                sqlText.Append("    ,SANDECNCTUSERIDRF" + Environment.NewLine);      //S&E接続ユーザID
                sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);       //端末番号
                sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine); // ADD 2013/07/04 田建委
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaSupplierCdRF = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                findParaSupplierCdRF.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                //----- ADD 2013/07/04 田建委 ----->>>>>
                SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                //----- ADD 2013/07/04 田建委 -----<<<<<

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    connectInfoWork = CopyToConnectInfoWorkFromReader(ref myReader);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(connectInfoWork);


            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.ReadProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region Delete
        /// <summary>
        /// 接続先情報マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">ConnectInfoWorkブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報マスタ情報を物理削除します</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public int Delete(byte[] parabyte)
        {
            return this.DeleteProc(parabyte);
        }

        /// <summary>
        /// 接続先情報マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">ConnectInfoWorkブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報マスタ情報を物理削除します</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private int DeleteProc(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                // XMLの読み込み
                ConnectInfoWork connectInfoWork = (ConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(ConnectInfoWork));

                if (connectInfoWork == null)
                {
                    return status;
                }
                StringBuilder sqlText = new StringBuilder();
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT文]
                sqlText.Append("SELECT CREATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                sqlText.Append("    ,SUPPLIERCDRF" + Environment.NewLine);
                sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);      //接続パスワード
                sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);        //接続ユーザID
                sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);     //発注手配区分（ダイハツ）
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);      //ログインタイムアウト
                sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);             //発注URL
                sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);        //在庫確認URL
                sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);     //接続プログラムタイプ
                sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);          //接続ファイルID
                sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);         //接続送信区分
                sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);       //接続対象区分
                sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);             //リトライ回数
                sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);          //自動送信区分
                sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);             //起動時間
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);    //送信端末(IPアドレス）
                sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);      //送信端末(コンピューター名）
                sqlText.Append("     ,SENDMACHINEIPADDRRF" + Environment.NewLine);   //IPアドレス
                sqlText.Append("    ,SANDECNCTPASSRF" + Environment.NewLine);        //S&E接続パスワード
                sqlText.Append("    ,SANDECNCTUSERIDRF" + Environment.NewLine);      //S&E接続ユーザID
                sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);       //端末番号
                sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine); // ADD 2013/07/04 田建委
                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                //----- ADD 2013/07/04 田建委 ----->>>>>
                SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                //----- ADD 2013/07/04 田建委 -----<<<<<

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                    if (_updateDateTime != connectInfoWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        return status;
                    }

                    # region [DELETE文]
                    StringBuilder sqlText_DELETE = new StringBuilder();
                    sqlText_DELETE.Append(" DELETE FROM CONNECTINFORF" + Environment.NewLine);
                    sqlText_DELETE.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlText_DELETE.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                    sqlCommand.CommandText = sqlText_DELETE.ToString();
                    # endregion

                    // KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);
                }
                else
                {
                    // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    return status;
                }

                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SAndEConnectInfoPrcPrStDB.DeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.DeleteProc", status);
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

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion Delete

        #region LogicalDelete
        /// <summary>
        /// 接続先情報マスタ情報を論理削除します。
        /// </summary>
        /// <param name="connectInfoWork">論理削除する接続先情報マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報マスタ情報を論理削除します。</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref object connectInfoWork)
        {
            return this.LogicalDeleteProc(ref connectInfoWork, 0);
        }

        /// <summary>
        /// 接続先情報マスタ情報を論理削除します。
        /// </summary>
        /// <param name="connectInfoWork">論理削除する接続先情報マスタ情報</param>
        /// <param name="procMode">論理削除モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報マスタ情報を論理削除します。</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private int LogicalDeleteProc(ref object connectInfoWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ConnectInfoWork paraList = connectInfoWork as ConnectInfoWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化(更新結果を戻す）
                connectInfoWork = paraList;

            }
            catch (SqlException sqex)
            {
                status = base.WriteSQLErrorLog(sqex, "SAndEConnectInfoPrcPrStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.LogicalDeleteProc", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
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

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 接続先情報マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="connectInfoWork">論理削除を解除する接続先情報マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object connectInfoWork)
        {
            return this.LogicalDeleteProc(ref connectInfoWork, 1);
        }

        /// <summary>
        /// 接続先情報マスタ情報を論理削除します。
        /// </summary>
        /// <param name="connectInfoWork">論理削除する接続先情報マスタ情報</param>
        /// <param name="procMode">論理削除モード</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報マスタ情報を論理削除します。</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private int LogicalDeleteProc(ref ConnectInfoWork connectInfoWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (connectInfoWork != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText.Append("SELECT CREATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                    sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                    sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                    sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                    sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                    sqlText.Append("    ,SUPPLIERCDRF" + Environment.NewLine);
                    sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);      //接続パスワード
                    sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);        //接続ユーザID
                    sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);     //発注手配区分（ダイハツ）
                    sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);      //ログインタイムアウト
                    sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);             //発注URL
                    sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);        //在庫確認URL
                    sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);     //接続プログラムタイプ
                    sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);          //接続ファイルID
                    sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);         //接続送信区分
                    sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);       //接続対象区分
                    sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);             //リトライ回数
                    sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);          //自動送信区分
                    sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);             //起動時間
                    sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);    //送信端末(IPアドレス）
                    sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);      //送信端末(コンピューター名）
                    sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);    //IPアドレス
                    sqlText.Append("    ,SANDECNCTPASSRF" + Environment.NewLine);        //S&E接続パスワード
                    sqlText.Append("    ,SANDECNCTUSERIDRF" + Environment.NewLine);      //S&E接続ユーザID
                    sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);       //端末番号
                    sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                    sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine); // ADD 2013/07/04 田建委
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                    //----- ADD 2013/07/04 田建委 ----->>>>>
                    SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                    findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                    //----- ADD 2013/07/04 田建委 -----<<<<<

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != connectInfoWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // 現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        # region [UPDATE文]
                        StringBuilder sqlText_UPDATE = new StringBuilder();
                        sqlText_UPDATE.Append("UPDATE CONNECTINFORF" + Environment.NewLine);
                        sqlText_UPDATE.Append("    SET UPDATEDATETIMERF=@UPDATEDATETIMERF" + Environment.NewLine);
                        sqlText_UPDATE.Append("    ,LOGICALDELETECODERF=@LOGICALDELETECODERF" + Environment.NewLine);
                        sqlText_UPDATE.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                        sqlCommand.CommandText = sqlText_UPDATE.ToString();
                        # endregion

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)connectInfoWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        return status;
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    // 論理削除モードの場合
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;         // 既に削除済みの場合正常
                            return status;
                        }
                        else if (logicalDelCd == 0) connectInfoWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                        else connectInfoWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1)
                        {
                            connectInfoWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
                        }
                        else
                        {
                            if (logicalDelCd == 0)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     // 既に復活している場合はそのまま正常を戻す
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // 完全削除はデータなしを戻す
                            }

                            return status;
                        }
                    }

                    //Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIMERF", SqlDbType.BigInt);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODERF", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(connectInfoWork.UpdateDateTime);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt64(connectInfoWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();
                    al.Add(connectInfoWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqex, "SAndEConnectInfoPrcPrStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.LogicalDeleteProc", status);
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

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion LogicalDelete

        #region Write
        /// <summary>
        /// 接続先情報マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="connectInfoWorkbyte">追加・更新する接続先情報マスタ情報</param>
        /// <param name="writeMode">更新区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報マスタ情報を追加・更新します。</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref object connectInfoWorkbyte, int writeMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ConnectInfoWork connectInfoWork = connectInfoWorkbyte as ConnectInfoWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = WriteProc(ref connectInfoWork, ref sqlConnection, ref sqlTransaction);

                // 戻り値セット
                connectInfoWorkbyte = connectInfoWork;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SAndEConnectInfoPrcPrStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.Write", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
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

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }


        /// <summary>
        /// 接続先情報マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="connectInfoWork">追加・更新する接続先情報マスタ情報</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報マスタ情報を追加・更新します。</br>
        /// <br>Programmer : lyc</br>
        /// <br>Date       : 2013/06/26</br>
        /// <br>管理番号   : 10901034-00</br>
        /// <br></br>
        /// </remarks>
        private int WriteProc(ref ConnectInfoWork connectInfoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ConnectInfoWork al = new ConnectInfoWork();

            try
            {
                if (connectInfoWork != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText.Append("SELECT CREATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                    sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                    sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                    sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                    sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                    sqlText.Append("    ,SUPPLIERCDRF" + Environment.NewLine);
                    sqlText.Append("    ,CONNECTPASSWORDRF" + Environment.NewLine);      //接続パスワード
                    sqlText.Append("    ,CONNECTUSERIDRF" + Environment.NewLine);        //接続ユーザID
                    sqlText.Append("    ,DAIHATSUORDREDIVRF" + Environment.NewLine);     //発注手配区分（ダイハツ）
                    sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);      //ログインタイムアウト
                    sqlText.Append("    ,ORDERURLRF" + Environment.NewLine);             //発注URL
                    sqlText.Append("    ,STOCKCHECKURLRF" + Environment.NewLine);        //在庫確認URL
                    sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);     //接続プログラムタイプ
                    sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);          //接続ファイルID
                    sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);         //接続送信区分
                    sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);       //接続対象区分
                    sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);             //リトライ回数
                    sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);          //自動送信区分
                    sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);             //起動時間
                    sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);    //送信端末(IPアドレス）
                    sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);      //送信端末(コンピューター名）
                    sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);    //IPアドレス
                    sqlText.Append("    ,SANDECNCTPASSRF" + Environment.NewLine);        //S&E接続パスワード
                    sqlText.Append("    ,SANDECNCTUSERIDRF" + Environment.NewLine);      //S&E接続ユーザID
                    sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);       //端末番号
                    sqlText.Append(" FROM CONNECTINFORF WITH (READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlText.Append(" AND SUPPLIERCDRF=@FINDSUPPLIERCDRF " + Environment.NewLine);
                    sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine); // ADD 2013/07/04 田建委
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCDRF", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                    //----- ADD 2013/07/04 田建委 ----->>>>>
                    SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                    findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                    //----- ADD 2013/07/04 田建委 -----<<<<<

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != connectInfoWork.UpdateDateTime)
                        {
                            if (connectInfoWork.UpdateDateTime == DateTime.MinValue)
                            {
                                // 新規登録で該当データ有りの場合には重複
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            else
                            {
                                // 既存データで更新日時違いの場合には排他
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }

                            return status;
                        }

                        # region [UPDATE文]
                        StringBuilder sqlText_UPDATE = new StringBuilder();
                        sqlText_UPDATE.Append("UPDATE CONNECTINFORF SET" + Environment.NewLine);
                        sqlText_UPDATE.Append("    UPDATEDATETIMERF=@UPDATEDATETIME," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CONNECTPASSWORDRF=@CONNECTPASSWORD," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CONNECTUSERIDRF=@CONNECTUSERID," + Environment.NewLine);
                        sqlText_UPDATE.Append("    DAIHATSUORDREDIVRF=@DAIHATSUORDREDIV," + Environment.NewLine);
                        sqlText_UPDATE.Append("    LOGINTIMEOUTVALRF=@LOGINTIMEOUTVAL," + Environment.NewLine);
                        sqlText_UPDATE.Append("    ORDERURLRF=@ORDERURL," + Environment.NewLine);
                        sqlText_UPDATE.Append("    STOCKCHECKURLRF=@STOCKCHECKURL," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CNECTPROGRAMTYPERF=@CNECTPROGRAMTYPE," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CNECTFILEIDRF=@CNECTFILEID," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CNECTSENDDIVRF=@CNECTSENDDIV," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CNECTOBJECTDIVRF=@CNECTOBJECTDIV," + Environment.NewLine);
                        sqlText_UPDATE.Append("    RETRYCNTRF=@RETRYCNT," + Environment.NewLine);
                        sqlText_UPDATE.Append("    AUTOSENDDIVRF=@AUTOSENDDIV," + Environment.NewLine);
                        sqlText_UPDATE.Append("    BOOTTIMERF=@BOOTTIME," + Environment.NewLine);
                        sqlText_UPDATE.Append("    SENDMACHINENAMERF=@SENDMACHINENAME" + Environment.NewLine);
                        sqlText_UPDATE.Append("    ,SENDMACHINEIPADDRRF=@SENDMACHINEIPADDR" + Environment.NewLine);
                        sqlText_UPDATE.Append("    ,SANDECNCTPASSRF=@SANDECNCTPASS" + Environment.NewLine);
                        sqlText_UPDATE.Append("    ,SANDECNCTUSERIDRF=@SANDECNCTUSERID" + Environment.NewLine);
                        sqlText_UPDATE.Append("    ,CASHREGISTERNORF=@CASHREGISTERNORF" + Environment.NewLine);
                        sqlText_UPDATE.Append(" WHERE ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND SUPPLIERCDRF=@SUPPLIERCD " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine); // ADD 2013/07/04 田建委
                        sqlCommand.CommandText = sqlText_UPDATE.ToString();
                        # endregion

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)connectInfoWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (connectInfoWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT文]
                        StringBuilder sqlText_INSERT = new StringBuilder();
                        sqlText_INSERT.Append("INSERT INTO CONNECTINFORF" + Environment.NewLine);
                        sqlText_INSERT.Append(" (CREATEDATETIMERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDATEDATETIMERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  ENTERPRISECODERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  FILEHEADERGUIDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDEMPLOYEECODERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDASSEMBLYID1RF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDASSEMBLYID2RF," + Environment.NewLine);
                        sqlText_INSERT.Append("  LOGICALDELETECODERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  SUPPLIERCDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  CONNECTPASSWORDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  CONNECTUSERIDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  DAIHATSUORDREDIVRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  LOGINTIMEOUTVALRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  ORDERURLRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  STOCKCHECKURLRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  CNECTPROGRAMTYPERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  CNECTFILEIDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  CNECTSENDDIVRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  CNECTOBJECTDIVRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  RETRYCNTRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  AUTOSENDDIVRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  BOOTTIMERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  SENDMACHINENAMERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  SENDMACHINEIPADDRRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  SANDECNCTPASSRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  SANDECNCTUSERIDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  CASHREGISTERNORF)" + Environment.NewLine);
                        sqlText_INSERT.Append("  VALUES (@CREATEDATETIME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDATEDATETIME, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @ENTERPRISECODE, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @FILEHEADERGUID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDEMPLOYEECODE," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDASSEMBLYID1, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDASSEMBLYID2, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @LOGICALDELETECODE, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @SUPPLIERCD, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @CONNECTPASSWORD," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CONNECTUSERID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @DAIHATSUORDREDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @LOGINTIMEOUTVAL," + Environment.NewLine);
                        sqlText_INSERT.Append("     @ORDERURL," + Environment.NewLine);
                        sqlText_INSERT.Append("     @STOCKCHECKURL," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTPROGRAMTYPE," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTFILEID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTSENDDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTOBJECTDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @RETRYCNT," + Environment.NewLine);
                        sqlText_INSERT.Append("     @AUTOSENDDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @BOOTTIME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SENDMACHINENAME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SENDMACHINEIPADDR," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SANDECNCTPASS," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SANDECNCTUSERID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CASHREGISTERNORF)" + Environment.NewLine);
                        sqlCommand.CommandText = sqlText_INSERT.ToString();
                        # endregion

                        // 登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)connectInfoWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    //Prameterオブジェクトの作成
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraPassword = sqlCommand.Parameters.Add("@CONNECTPASSWORD", SqlDbType.NVarChar);
                    SqlParameter paraUserId = sqlCommand.Parameters.Add("@CONNECTUSERID", SqlDbType.NVarChar);
                    SqlParameter paraDaihatsuOrdreDiv = sqlCommand.Parameters.Add("@DAIHATSUORDREDIV", SqlDbType.Int);
                    SqlParameter paraLoginTimeoutVal = sqlCommand.Parameters.Add("@LOGINTIMEOUTVAL", SqlDbType.Int);
                    SqlParameter paraOrderUrl = sqlCommand.Parameters.Add("@ORDERURL", SqlDbType.NVarChar);
                    SqlParameter paraStockCheckUrl = sqlCommand.Parameters.Add("@STOCKCHECKURL", SqlDbType.NVarChar);
                    SqlParameter paraCnectProgramType = sqlCommand.Parameters.Add("@CNECTPROGRAMTYPE", SqlDbType.NVarChar);
                    SqlParameter paraCnectFileId = sqlCommand.Parameters.Add("@CNECTFILEID", SqlDbType.NVarChar);
                    SqlParameter paraCnectSendDiv = sqlCommand.Parameters.Add("@CNECTSENDDIV", SqlDbType.NVarChar);
                    SqlParameter paraCnectObjectDiv = sqlCommand.Parameters.Add("@CNECTOBJECTDIV", SqlDbType.NVarChar);
                    SqlParameter paraRetryCnt = sqlCommand.Parameters.Add("@RETRYCNT", SqlDbType.NVarChar);
                    SqlParameter paraAutoSendDiv = sqlCommand.Parameters.Add("@AUTOSENDDIV", SqlDbType.NVarChar);
                    SqlParameter paraBootTime = sqlCommand.Parameters.Add("@BOOTTIME", SqlDbType.NVarChar);
                    SqlParameter paraSendMachineName = sqlCommand.Parameters.Add("@SENDMACHINENAME", SqlDbType.NVarChar);
                    SqlParameter paraSendMachineIpAddr = sqlCommand.Parameters.Add("@SENDMACHINEIPADDR", SqlDbType.NVarChar);
                    SqlParameter paraSAndECnctPass = sqlCommand.Parameters.Add("@SANDECNCTPASS", SqlDbType.NVarChar);
                    SqlParameter paraSAndECnctUserId = sqlCommand.Parameters.Add("@SANDECNCTUSERID", SqlDbType.NVarChar);
                    SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNORF", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(connectInfoWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(connectInfoWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(connectInfoWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(connectInfoWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(connectInfoWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.LogicalDeleteCode);
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);
                    paraPassword.Value = SqlDataMediator.SqlSetString(connectInfoWork.ConnectPassword);
                    paraUserId.Value = SqlDataMediator.SqlSetString(connectInfoWork.ConnectUserId);
                    paraDaihatsuOrdreDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.DaihatsuOrdreDiv);
                    paraLoginTimeoutVal.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.LoginTimeoutVal);
                    paraOrderUrl.Value = SqlDataMediator.SqlSetString(connectInfoWork.OrderUrl);
                    paraStockCheckUrl.Value = SqlDataMediator.SqlSetString(connectInfoWork.StockCheckUrl);
                    paraCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                    paraCnectFileId.Value = SqlDataMediator.SqlSetString(connectInfoWork.CnectFileId);
                    paraCnectSendDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectSendDiv);
                    paraCnectObjectDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectObjectDiv);
                    paraRetryCnt.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.RetryCnt);
                    paraAutoSendDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.AutoSendDiv);
                    paraBootTime.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.BootTime);
                    paraSendMachineName.Value = SqlDataMediator.SqlSetString(connectInfoWork.SendMachineName);
                    paraSendMachineIpAddr.Value = SqlDataMediator.SqlSetString(connectInfoWork.SendMachineIpAddr);
                    paraSAndECnctPass.Value=SqlDataMediator.SqlSetString(connectInfoWork.SAndECnctPass);
                    paraSAndECnctUserId.Value=SqlDataMediator.SqlSetString(connectInfoWork.SAndECnctUserId);
                    paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CashRegisterNo);

                    sqlCommand.ExecuteNonQuery();
                    al = connectInfoWork;

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SAndEConnectInfoPrcPrStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SAndEConnectInfoPrcPrStDB.WriteProc", status);
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

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            connectInfoWork = al;

            return status;
        }
        #endregion

        #endregion IConnectInfoPrcPrStDB メンバ

    }
}

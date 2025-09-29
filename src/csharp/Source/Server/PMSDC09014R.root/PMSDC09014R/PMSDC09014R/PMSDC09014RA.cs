//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 接続先情報マスタメンテナンス
// プログラム概要   : 接続先情報マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570219-00 作成担当 : 田建委
// 作 成 日  2019/12/03  修正内容 : 新規作成
// 管理番号  11570219-00 作成担当 : 寺田義啓
// 更 新 日  2020/02/04  修正内容 : （修正内容一覧No.２）備考出力設定項目変更対応
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
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/12/03</br>
    /// <br>管理番号   : 11570219-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SalCprtConnectInfoPrcPrStDB : RemoteDB, ISalCprtConnectInfoPrcPrStDB
    {
        /// <summary>
        /// 接続先情報マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public SalCprtConnectInfoPrcPrStDB()
            : base("PMSDC09016D", "Broadleaf.Application.Remoting.ParamData.SalCprtConnectInfoWork", "SALCPRTCNCTINFRF")
        {

        }

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SalCprtConnectInfoWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalCprtConnectInfoWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private SalCprtConnectInfoWork CopyToSalCprtConnectInfoWorkFromReader(ref SqlDataReader myReader)
        {
            SalCprtConnectInfoWork connectInfoWork = new SalCprtConnectInfoWork();

            this.CopyToSalCprtConnectInfoWorkFromReader(ref myReader, ref connectInfoWork);

            return connectInfoWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → ConnectInfoWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="connectInfoWork">ConnectInfoWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>Update Note: 2020/02/04 寺田 義啓</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>           :（修正内容一覧No.2）備考設定変更項目追加</br>
        /// <br></br>
        /// </remarks>
        private void CopyToSalCprtConnectInfoWorkFromReader(ref SqlDataReader myReader, ref SalCprtConnectInfoWork connectInfoWork)
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
                string sectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SECTIONCODERF")).ToString();
                if (sectionCode == "0")
                {
                    connectInfoWork.SectionCode = sectionCode;
                }
                else
                {
                    connectInfoWork.SectionCode = sectionCode.PadLeft(2, '0');
                }              
                connectInfoWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                connectInfoWork.Protocol = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROTOCOLRF"));
                connectInfoWork.LoginTimeoutVal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGINTIMEOUTVALRF"));
                connectInfoWork.CprtDomain = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CPRTDOMAINRF"));
                connectInfoWork.CprtUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CPRTURLRF"));
                connectInfoWork.CnectProgramType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNECTPROGRAMTYPERF"));
                connectInfoWork.CnectFileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CNECTFILEIDRF"));
                connectInfoWork.CnectSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNECTSENDDIVRF"));
                connectInfoWork.CnectObjectDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CNECTOBJECTDIVRF"));
                connectInfoWork.RetryCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETRYCNTRF"));
                connectInfoWork.AutoSendDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOSENDDIVRF"));
                connectInfoWork.BootTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOOTTIMERF"));
                connectInfoWork.EndTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENDTIMERF"));
                connectInfoWork.ExecInterval = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXECINTERVALRF"));
                connectInfoWork.SendMachineIpAddr = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDMACHINEIPADDRRF"));
                connectInfoWork.SendMachineName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDMACHINENAMERF"));
                connectInfoWork.SendCcnctPass = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDCCNCTPASSRF"));
                connectInfoWork.SendCcnctUserid = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDCCNCTUSERIDRF"));
                connectInfoWork.CashregiSterno = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                connectInfoWork.LtAtSadDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("LTATSADDATETIMERF"));
                connectInfoWork.FrstSendDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRSTSENDDATERF"));
                //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                connectInfoWork.Note1SetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NOTE1SETDIVRF"));
                connectInfoWork.Note2SetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NOTE2SETDIVRF"));
                connectInfoWork.Note3SetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NOTE3SETDIVRF"));
                //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int Search(out object outConnectInfoPrcPrSt, object paraConnectInfoWork, int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList connectInfoPrcPrStList = null;
            SalCprtConnectInfoWork connectInfoWork = null;

            outConnectInfoPrcPrSt = new CustomSerializeArrayList();

            try
            {
                connectInfoWork = paraConnectInfoWork as SalCprtConnectInfoWork;

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
                status = base.WriteSQLErrorLog(sqlex, "SalCprtConnectInfoPrcPrStDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.Search", status);
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>Update Note: 2020/02/04 寺田 義啓</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>           :（修正内容一覧No.2）備考設定変更項目追加</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList connectInfoPrcPrStList, SalCprtConnectInfoWork connectInfoWork, int readMode, Broadleaf.Library.Resources.ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
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
                sqlText.Append("    ,SECTIONCODERF" + Environment.NewLine);         //拠点コード
                sqlText.Append("    ,CUSTOMERCODERF" + Environment.NewLine);        //得意先コード
                sqlText.Append("    ,PROTOCOLRF" + Environment.NewLine);            //プロトコル
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);     //ログインタイムアウト
                sqlText.Append("    ,CPRTDOMAINRF" + Environment.NewLine);          //連携先ドメイン
                sqlText.Append("    ,CPRTURLRF" + Environment.NewLine);             //連携先URL
                sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);    //接続プログラムタイプ
                sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);         //接続ファイルID
                sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);        //接続送信区分
                sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);      //接続対象区分
                sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);            //リトライ回数
                sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);         //自動送信区分
                sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);            //起動時間
                sqlText.Append("    ,ENDTIMERF" + Environment.NewLine);             //終了時間
                sqlText.Append("    ,EXECINTERVALRF" + Environment.NewLine);        //実行間隔
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);   //送信端末(IPアドレス）
                sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);     //送信端末(コンピューター名）
                sqlText.Append("    ,SENDCCNCTPASSRF" + Environment.NewLine);       //送信接続パスワード
                sqlText.Append("    ,SENDCCNCTUSERIDRF" + Environment.NewLine);     //送信接続ユーザーコード
                sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);      //レジ番号
                sqlText.Append("    ,LTATSADDATETIMERF" + Environment.NewLine);     //前回自動送信日時
                sqlText.Append("    ,FRSTSENDDATERF" + Environment.NewLine);        //初回送信基準日
                //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                sqlText.Append("    ,NOTE1SETDIVRF" + Environment.NewLine);         //備考１設定区分
                sqlText.Append("    ,NOTE2SETDIVRF" + Environment.NewLine);         //備考２設定区分
                sqlText.Append("    ,NOTE3SETDIVRF" + Environment.NewLine);         //備考３設定区分
                //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                sqlText.Append(" FROM SALCPRTCNCTINFRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND CNECTPROGRAMTYPERF=@FINDCNECTPROGRAMTYPERF " + Environment.NewLine);
                sqlText.Append(" ORDER BY SECTIONCODERF,  CUSTOMERCODERF" + Environment.NewLine);
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);

                //Parameterオブジェクトへ値設定
                SqlParameter findParaSupplierCdRF = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);
                findParaSupplierCdRF.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

                SqlParameter findParaCnectProgramType = sqlCommand.Parameters.Add("@FINDCNECTPROGRAMTYPERF", SqlDbType.Int);
                findParaCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(this.CopyToSalCprtConnectInfoWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "SalCprtConnectInfoPrcPrStDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.SearchProc", status);
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
        /// <br>Note       : 指定された接続先情報設定Guidの接続先情報設定を戻します</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
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
        /// <br>Note       : 指定された接続先情報設定Guidの接続先情報設定を戻します</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>Update Note: 2020/02/04 寺田 義啓</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>           :（修正内容一覧No.2）備考設定変更項目追加</br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            SalCprtConnectInfoWork connectInfoWork = new SalCprtConnectInfoWork();
            try
            {
                // XMLの読み込み
                connectInfoWork = (SalCprtConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(SalCprtConnectInfoWork));

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
                sqlText.Append("    ,SECTIONCODERF" + Environment.NewLine);         //拠点コード
                sqlText.Append("    ,CUSTOMERCODERF" + Environment.NewLine);        //得意先コード
                sqlText.Append("    ,PROTOCOLRF" + Environment.NewLine);            //プロトコル
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);     //ログインタイムアウト
                sqlText.Append("    ,CPRTDOMAINRF" + Environment.NewLine);          //連携先ドメイン
                sqlText.Append("    ,CPRTURLRF" + Environment.NewLine);             //連携先URL
                sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);    //接続プログラムタイプ
                sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);         //接続ファイルID
                sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);        //接続送信区分
                sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);      //接続対象区分
                sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);            //リトライ回数
                sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);         //自動送信区分
                sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);            //起動時間
                sqlText.Append("    ,ENDTIMERF" + Environment.NewLine);             //終了時間
                sqlText.Append("    ,EXECINTERVALRF" + Environment.NewLine);        //実行間隔
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);   //送信端末(IPアドレス）
                sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);     //送信端末(コンピューター名）
                sqlText.Append("    ,SENDCCNCTPASSRF" + Environment.NewLine);       //送信接続パスワード
                sqlText.Append("    ,SENDCCNCTUSERIDRF" + Environment.NewLine);     //送信接続ユーザーコード
                sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);      //レジ番号
                sqlText.Append("    ,LTATSADDATETIMERF" + Environment.NewLine);     //前回自動送信日時
                sqlText.Append("    ,FRSTSENDDATERF" + Environment.NewLine);        //初回送信基準日
                //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                sqlText.Append("    ,NOTE1SETDIVRF" + Environment.NewLine);         //備考１設定区分
                sqlText.Append("    ,NOTE2SETDIVRF" + Environment.NewLine);         //備考２設定区分
                sqlText.Append("    ,NOTE3SETDIVRF" + Environment.NewLine);         //備考３設定区分
                //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                sqlText.Append(" FROM SALCPRTCNCTINFRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine);
                sqlText.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODERF " + Environment.NewLine);
                sqlText.Append(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODERF " + Environment.NewLine);
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaSupplierCdRF = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.Int);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODERF", SqlDbType.Int);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODERF", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                findParaSupplierCdRF.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);
                int sectionCd = 0;
                if (connectInfoWork.SectionCode.Equals(""))
                {
                    sectionCd = 0;
                }
                else
                {
                    sectionCd = Convert.ToInt32(connectInfoWork.SectionCode);
                }
                findParaSectionCode.Value = SqlDataMediator.SqlSetInt32(sectionCd);
                findParaCustomerCode.Value = connectInfoWork.CustomerCode;
                findParaLogicalDeleteCode.Value = 0;

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    connectInfoWork = CopyToSalCprtConnectInfoWorkFromReader(ref myReader);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(connectInfoWork);


            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.ReadProc Exception=" + ex.Message);
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>Update Note: 2020/02/04 寺田 義啓</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>           :（修正内容一覧No.2）備考設定変更項目追加</br>
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
                SalCprtConnectInfoWork connectInfoWork = (SalCprtConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(SalCprtConnectInfoWork));

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
                sqlText.Append("    ,SECTIONCODERF" + Environment.NewLine);         //拠点コード
                sqlText.Append("    ,CUSTOMERCODERF" + Environment.NewLine);        //得意先コード
                sqlText.Append("    ,PROTOCOLRF" + Environment.NewLine);            //プロトコル
                sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);     //ログインタイムアウト
                sqlText.Append("    ,CPRTDOMAINRF" + Environment.NewLine);          //連携先ドメイン
                sqlText.Append("    ,CPRTURLRF" + Environment.NewLine);             //連携先URL
                sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);    //接続プログラムタイプ
                sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);         //接続ファイルID
                sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);        //接続送信区分
                sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);      //接続対象区分
                sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);            //リトライ回数
                sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);         //自動送信区分
                sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);            //起動時間
                sqlText.Append("    ,ENDTIMERF" + Environment.NewLine);             //終了時間
                sqlText.Append("    ,EXECINTERVALRF" + Environment.NewLine);        //実行間隔
                sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);   //送信端末(IPアドレス）
                sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);     //送信端末(コンピューター名）
                sqlText.Append("    ,SENDCCNCTPASSRF" + Environment.NewLine);       //送信接続パスワード
                sqlText.Append("    ,SENDCCNCTUSERIDRF" + Environment.NewLine);     //送信接続ユーザーコード
                sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);      //レジ番号
                sqlText.Append("    ,LTATSADDATETIMERF" + Environment.NewLine);     //前回自動送信日時
                sqlText.Append("    ,FRSTSENDDATERF" + Environment.NewLine);        //初回送信基準日
                //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                sqlText.Append("    ,NOTE1SETDIVRF" + Environment.NewLine);         //備考１設定区分
                sqlText.Append("    ,NOTE2SETDIVRF" + Environment.NewLine);         //備考２設定区分
                sqlText.Append("    ,NOTE3SETDIVRF" + Environment.NewLine);         //備考３設定区分
                //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                sqlText.Append(" FROM SALCPRTCNCTINFRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine);
                sqlText.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODERF " + Environment.NewLine);
                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODERF", SqlDbType.Int);
                findParaSectionCode.Value = connectInfoWork.SectionCode;
                findParaCustomerCode.Value = connectInfoWork.CustomerCode;

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);

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
                    sqlText_DELETE.Append(" DELETE FROM SALCPRTCNCTINFRF" + Environment.NewLine);
                    sqlText_DELETE.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlText_DELETE.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                    sqlText_DELETE.Append(" AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine);
                    sqlText_DELETE.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODERF " + Environment.NewLine);
                    sqlCommand.CommandText = sqlText_DELETE.ToString();
                    # endregion

                    // KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);
                    findParaSectionCode.Value = connectInfoWork.SectionCode;
                    findParaCustomerCode.Value = connectInfoWork.CustomerCode;
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
                status = base.WriteSQLErrorLog(sqlex, "SalCprtConnectInfoPrcPrStDB.DeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.DeleteProc", status);
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private int LogicalDeleteProc(ref object connectInfoWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SalCprtConnectInfoWork paraList = connectInfoWork as SalCprtConnectInfoWork;

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
                status = base.WriteSQLErrorLog(sqex, "SalCprtConnectInfoPrcPrStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.LogicalDeleteProc", status);
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>Update Note: 2020/02/04 寺田 義啓</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>           :（修正内容一覧No.2）備考設定変更項目追加</br>
        /// <br></br>
        /// </remarks>
        private int LogicalDeleteProc(ref SalCprtConnectInfoWork connectInfoWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                    sqlText.Append("    ,SECTIONCODERF" + Environment.NewLine);         //拠点コード
                    sqlText.Append("    ,CUSTOMERCODERF" + Environment.NewLine);        //得意先コード
                    sqlText.Append("    ,PROTOCOLRF" + Environment.NewLine);            //プロトコル
                    sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);     //ログインタイムアウト
                    sqlText.Append("    ,CPRTDOMAINRF" + Environment.NewLine);          //連携先ドメイン
                    sqlText.Append("    ,CPRTURLRF" + Environment.NewLine);             //連携先URL
                    sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);    //接続プログラムタイプ
                    sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);         //接続ファイルID
                    sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);        //接続送信区分
                    sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);      //接続対象区分
                    sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);            //リトライ回数
                    sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);         //自動送信区分
                    sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);            //起動時間
                    sqlText.Append("    ,ENDTIMERF" + Environment.NewLine);             //終了時間
                    sqlText.Append("    ,EXECINTERVALRF" + Environment.NewLine);        //実行間隔
                    sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);   //送信端末(IPアドレス）
                    sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);     //送信端末(コンピューター名）
                    sqlText.Append("    ,SENDCCNCTPASSRF" + Environment.NewLine);       //送信接続パスワード
                    sqlText.Append("    ,SENDCCNCTUSERIDRF" + Environment.NewLine);     //送信接続ユーザーコード
                    sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);      //レジ番号
                    sqlText.Append("    ,LTATSADDATETIMERF" + Environment.NewLine);     //前回自動送信日時
                    sqlText.Append("    ,FRSTSENDDATERF" + Environment.NewLine);        //初回送信基準日
                    //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                    sqlText.Append("    ,NOTE1SETDIVRF" + Environment.NewLine);         //備考１設定区分
                    sqlText.Append("    ,NOTE2SETDIVRF" + Environment.NewLine);         //備考２設定区分
                    sqlText.Append("    ,NOTE3SETDIVRF" + Environment.NewLine);         //備考３設定区分
                    //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                    sqlText.Append(" FROM SALCPRTCNCTINFRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlText.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                    sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine);
                    sqlText.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODERF " + Environment.NewLine);
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCDRF", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODERF", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);
                    findParaSectionCode.Value = connectInfoWork.SectionCode;
                    findParaCustomerCode.Value = connectInfoWork.CustomerCode;

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
                        sqlText_UPDATE.Append("UPDATE SALCPRTCNCTINFRF" + Environment.NewLine);
                        sqlText_UPDATE.Append("    SET UPDATEDATETIMERF=@UPDATEDATETIMERF" + Environment.NewLine);
                        sqlText_UPDATE.Append("    ,LOGICALDELETECODERF=@LOGICALDELETECODERF" + Environment.NewLine);
                        sqlText_UPDATE.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND SUPPLIERCDRF=@SUPPLIERCDRF " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND SECTIONCODERF=@FINDSECTIONCODERF " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODERF " + Environment.NewLine);

                        sqlCommand.CommandText = sqlText_UPDATE.ToString();
                        # endregion

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);
                        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.SupplierCd);
                        findParaSectionCode.Value = connectInfoWork.SectionCode;
                        findParaCustomerCode.Value = connectInfoWork.CustomerCode;

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
                status = base.WriteSQLErrorLog(sqex, "SalCprtConnectInfoPrcPrStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.LogicalDeleteProc", status);
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
        /// <param name="flag">時間更新フラグ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 接続先情報マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref object connectInfoWorkbyte, int writeMode, int flag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                SalCprtConnectInfoWork connectInfoWork = connectInfoWorkbyte as SalCprtConnectInfoWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = WriteProc(ref connectInfoWork, ref sqlConnection, ref sqlTransaction);

                // 全件の起動時間、終了時間、実行間隔を更新
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (flag == 1))
                {
                    status = UpdateDataTime(connectInfoWork, ref sqlConnection, ref sqlTransaction);
                }

                // 戻り値セット
                connectInfoWorkbyte = connectInfoWork;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SalCprtConnectInfoPrcPrStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.Write", status);
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
        /// 全件の起動時間、終了時間、実行間隔を更新
        /// </summary>
        /// <param name="connectInfoWork">追加・更新する接続先情報マスタ情報</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 全件の起動時間、終了時間、実行間隔を更新します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br></br>
        /// </remarks>
        private int UpdateDataTime(SalCprtConnectInfoWork connectInfoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                IFileHeader flhd = (IFileHeader)new SalCprtConnectInfoWork();
                new FileHeader(this).SetUpdateHeader(ref flhd, this);
                string sqlText = string.Empty;
                sqlText += "UPDATE" + Environment.NewLine;
                sqlText += "  SALCPRTCNCTINFRF " + Environment.NewLine;
                sqlText += "SET" + Environment.NewLine;
                sqlText += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                sqlText += "  ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                sqlText += "  ,BOOTTIMERF=@BOOTTIME" + Environment.NewLine;
                sqlText += "  ,ENDTIMERF=@ENDTIME" + Environment.NewLine;
                sqlText += "  ,EXECINTERVALRF=@EXECINTERVAL" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraBootTime = sqlCommand.Parameters.Add("@BOOTTIME", SqlDbType.Int);
                    SqlParameter paraEndTime = sqlCommand.Parameters.Add("@ENDTIME", SqlDbType.Int);
                    SqlParameter paraExecInterval = sqlCommand.Parameters.Add("@EXECINTERVAL", SqlDbType.Int);

                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                    //KEYコマンドを再設定
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(flhd.UpdateDateTime);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(flhd.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(flhd.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(flhd.UpdAssemblyId2);
                    paraBootTime.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.BootTime);
                    paraEndTime.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.EndTime);
                    paraExecInterval.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.ExecInterval);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.EnterpriseCode);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SalCprtConnectInfoPrcPrStDB.UpdateDataTime", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.UpdateDataTime", status);
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/03</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>Update Note: 2020/02/04 寺田 義啓</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>           :（修正内容一覧No.2）備考設定変更項目追加</br>
        /// <br></br>
        /// </remarks>
        private int WriteProc(ref SalCprtConnectInfoWork connectInfoWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            SalCprtConnectInfoWork al = new SalCprtConnectInfoWork();

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
                    sqlText.Append("    ,SECTIONCODERF" + Environment.NewLine);         //拠点コード
                    sqlText.Append("    ,CUSTOMERCODERF" + Environment.NewLine);        //得意先コード
                    sqlText.Append("    ,PROTOCOLRF" + Environment.NewLine);            //プロトコル
                    sqlText.Append("    ,LOGINTIMEOUTVALRF" + Environment.NewLine);     //ログインタイムアウト
                    sqlText.Append("    ,CPRTDOMAINRF" + Environment.NewLine);          //連携先ドメイン
                    sqlText.Append("    ,CPRTURLRF" + Environment.NewLine);             //連携先URL
                    sqlText.Append("    ,CNECTPROGRAMTYPERF" + Environment.NewLine);    //接続プログラムタイプ
                    sqlText.Append("    ,CNECTFILEIDRF" + Environment.NewLine);         //接続ファイルID
                    sqlText.Append("    ,CNECTSENDDIVRF" + Environment.NewLine);        //接続送信区分
                    sqlText.Append("    ,CNECTOBJECTDIVRF" + Environment.NewLine);      //接続対象区分
                    sqlText.Append("    ,RETRYCNTRF" + Environment.NewLine);            //リトライ回数
                    sqlText.Append("    ,AUTOSENDDIVRF" + Environment.NewLine);         //自動送信区分
                    sqlText.Append("    ,BOOTTIMERF" + Environment.NewLine);            //起動時間
                    sqlText.Append("    ,ENDTIMERF" + Environment.NewLine);             //終了時間
                    sqlText.Append("    ,EXECINTERVALRF" + Environment.NewLine);        //実行間隔
                    sqlText.Append("    ,SENDMACHINEIPADDRRF" + Environment.NewLine);   //送信端末(IPアドレス）
                    sqlText.Append("    ,SENDMACHINENAMERF" + Environment.NewLine);     //送信端末(コンピューター名）
                    sqlText.Append("    ,SENDCCNCTPASSRF" + Environment.NewLine);       //送信接続パスワード
                    sqlText.Append("    ,SENDCCNCTUSERIDRF" + Environment.NewLine);     //送信接続ユーザーコード
                    sqlText.Append("    ,CASHREGISTERNORF" + Environment.NewLine);      //レジ番号
                    sqlText.Append("    ,LTATSADDATETIMERF" + Environment.NewLine);     //前回自動送信日時
                    sqlText.Append("    ,FRSTSENDDATERF" + Environment.NewLine);        //初回送信基準日
                    //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                    sqlText.Append("    ,NOTE1SETDIVRF" + Environment.NewLine);         //備考１設定区分
                    sqlText.Append("    ,NOTE2SETDIVRF" + Environment.NewLine);         //備考２設定区分
                    sqlText.Append("    ,NOTE3SETDIVRF" + Environment.NewLine);         //備考３設定区分
                    //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                    sqlText.Append(" FROM SALCPRTCNCTINFRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlText.Append(" AND SUPPLIERCDRF=@FINDSUPPLIERCDRF " + Environment.NewLine);
                    sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE " + Environment.NewLine);
                    sqlText.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE " + Environment.NewLine);
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCDRF", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    
                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = connectInfoWork.EnterpriseCode;
                    findParaSupplierCd.Value = connectInfoWork.SupplierCd;
                    findParaSectionCode.Value = connectInfoWork.SectionCode;
                    findParaCustomerCode.Value = connectInfoWork.CustomerCode;

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
                        sqlText_UPDATE.Append("UPDATE SALCPRTCNCTINFRF SET" + Environment.NewLine);
                        sqlText_UPDATE.Append("    UPDATEDATETIMERF=@UPDATEDATETIME," + Environment.NewLine);
                        sqlText_UPDATE.Append("    PROTOCOLRF=@PROTOCOL," + Environment.NewLine);                    //プロトコル
                        sqlText_UPDATE.Append("    LOGINTIMEOUTVALRF=@LOGINTIMEOUTVAL," + Environment.NewLine);      //ログインタイムアウト
                        sqlText_UPDATE.Append("    CPRTDOMAINRF=@CPRTDOMAIN," + Environment.NewLine);                //連携先ドメイン
                        sqlText_UPDATE.Append("    CPRTURLRF=@CPRTURL," + Environment.NewLine);                      //連携先URL
                        sqlText_UPDATE.Append("    CNECTPROGRAMTYPERF=@CNECTPROGRAMTYPE," + Environment.NewLine);    //接続プログラムタイプ
                        sqlText_UPDATE.Append("    CNECTFILEIDRF=@CNECTFILEID," + Environment.NewLine);              //接続ファイルID
                        sqlText_UPDATE.Append("    CNECTSENDDIVRF=@CNECTSENDDIV," + Environment.NewLine);            //接続送信区分
                        sqlText_UPDATE.Append("    CNECTOBJECTDIVRF=@CNECTOBJECTDIV," + Environment.NewLine);        //接続対象区分
                        sqlText_UPDATE.Append("    RETRYCNTRF=@RETRYCNT," + Environment.NewLine);                    //リトライ回数
                        sqlText_UPDATE.Append("    AUTOSENDDIVRF=@AUTOSENDDIV," + Environment.NewLine);              //自動送信区分
                        sqlText_UPDATE.Append("    BOOTTIMERF=@BOOTTIME," + Environment.NewLine);                    //起動時間
                        sqlText_UPDATE.Append("    ENDTIMERF=@ENDTIME," + Environment.NewLine);                      //終了時間
                        sqlText_UPDATE.Append("    EXECINTERVALRF=@EXECINTERVAL," + Environment.NewLine);            //実行間隔
                        sqlText_UPDATE.Append("    SENDMACHINEIPADDRRF=@SENDMACHINEIPADDR," + Environment.NewLine);  //送信端末(IPアドレス）
                        sqlText_UPDATE.Append("    SENDMACHINENAMERF=@SENDMACHINENAME," + Environment.NewLine);      //送信端末(コンピューター名）
                        sqlText_UPDATE.Append("    SENDCCNCTPASSRF=@SENDCCNCTPASS," + Environment.NewLine);           //送信接続パスワード
                        sqlText_UPDATE.Append("    SENDCCNCTUSERIDRF=@SENDCCNCTUSERID," + Environment.NewLine);       //送信接続ユーザーコード
                        sqlText_UPDATE.Append("    CASHREGISTERNORF=@CASHREGISTERNO," + Environment.NewLine);         //レジ番号
                        sqlText_UPDATE.Append("    LTATSADDATETIMERF=@LTATSADDATETIME," + Environment.NewLine);       //前回自動送信日時
                        sqlText_UPDATE.Append("    FRSTSENDDATERF=@FRSTSENDDATE" + Environment.NewLine);              //初回送信基準日
                        //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                        sqlText_UPDATE.Append("    ,NOTE1SETDIVRF=@NOTE1SETDIV" + Environment.NewLine);               //備考１設定区分
                        sqlText_UPDATE.Append("    ,NOTE2SETDIVRF=@NOTE2SETDIV" + Environment.NewLine);               //備考２設定区分
                        sqlText_UPDATE.Append("    ,NOTE3SETDIVRF=@NOTE3SETDIV" + Environment.NewLine);               //備考３設定区分
                        //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                        sqlText_UPDATE.Append(" WHERE ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND SUPPLIERCDRF=@SUPPLIERCD " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND SECTIONCODERF=@FINDSECTIONCODE " + Environment.NewLine);
                        sqlText_UPDATE.Append(" AND CUSTOMERCODERF=@FINDCUSTOMERCODE " + Environment.NewLine);
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
                        sqlText_INSERT.Append("INSERT INTO SALCPRTCNCTINFRF" + Environment.NewLine);
                        sqlText_INSERT.Append(" (CREATEDATETIMERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDATEDATETIMERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  ENTERPRISECODERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  FILEHEADERGUIDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDEMPLOYEECODERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDASSEMBLYID1RF," + Environment.NewLine);
                        sqlText_INSERT.Append("  UPDASSEMBLYID2RF," + Environment.NewLine);
                        sqlText_INSERT.Append("  LOGICALDELETECODERF," + Environment.NewLine);
                        sqlText_INSERT.Append("  SUPPLIERCDRF," + Environment.NewLine);
                        sqlText_INSERT.Append("    SECTIONCODERF," + Environment.NewLine);         //拠点コード
                        sqlText_INSERT.Append("    CUSTOMERCODERF," + Environment.NewLine);        //得意先コード
                        sqlText_INSERT.Append("    PROTOCOLRF," + Environment.NewLine);            //プロトコル
                        sqlText_INSERT.Append("    LOGINTIMEOUTVALRF," + Environment.NewLine);     //ログインタイムアウト
                        sqlText_INSERT.Append("    CPRTDOMAINRF," + Environment.NewLine);          //連携先ドメイン
                        sqlText_INSERT.Append("    CPRTURLRF," + Environment.NewLine);             //連携先URL
                        sqlText_INSERT.Append("    CNECTPROGRAMTYPERF," + Environment.NewLine);    //接続プログラムタイプ
                        sqlText_INSERT.Append("    CNECTFILEIDRF," + Environment.NewLine);         //接続ファイルID
                        sqlText_INSERT.Append("    CNECTSENDDIVRF," + Environment.NewLine);        //接続送信区分
                        sqlText_INSERT.Append("    CNECTOBJECTDIVRF," + Environment.NewLine);      //接続対象区分
                        sqlText_INSERT.Append("    RETRYCNTRF," + Environment.NewLine);            //リトライ回数
                        sqlText_INSERT.Append("    AUTOSENDDIVRF," + Environment.NewLine);         //自動送信区分
                        sqlText_INSERT.Append("    BOOTTIMERF," + Environment.NewLine);            //起動時間
                        sqlText_INSERT.Append("    ENDTIMERF," + Environment.NewLine);             //終了時間
                        sqlText_INSERT.Append("    EXECINTERVALRF," + Environment.NewLine);        //実行間隔
                        sqlText_INSERT.Append("    SENDMACHINEIPADDRRF," + Environment.NewLine);   //送信端末(IPアドレス）
                        sqlText_INSERT.Append("    SENDMACHINENAMERF," + Environment.NewLine);     //送信端末(コンピューター名）
                        sqlText_INSERT.Append("    SENDCCNCTPASSRF," + Environment.NewLine);       //送信接続パスワード
                        sqlText_INSERT.Append("    SENDCCNCTUSERIDRF," + Environment.NewLine);     //送信接続ユーザーコード
                        sqlText_INSERT.Append("    CASHREGISTERNORF," + Environment.NewLine);      //レジ番号
                        sqlText_INSERT.Append("    LTATSADDATETIMERF," + Environment.NewLine);     //前回自動送信日時
                        //↓ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
                        //sqlText_INSERT.Append("    FRSTSENDDATERF)" + Environment.NewLine);        //初回送信基準日
                        sqlText_INSERT.Append("    FRSTSENDDATERF," + Environment.NewLine);        //初回送信基準日
                        sqlText_INSERT.Append("    NOTE1SETDIVRF," + Environment.NewLine);         //備考１設定区分
                        sqlText_INSERT.Append("    NOTE2SETDIVRF," + Environment.NewLine);         //備考２設定区分
                        sqlText_INSERT.Append("    NOTE3SETDIVRF)" + Environment.NewLine);         //備考３設定区分
                        //↑ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
                        sqlText_INSERT.Append("  VALUES (@CREATEDATETIME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDATEDATETIME, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @ENTERPRISECODE, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @FILEHEADERGUID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDEMPLOYEECODE," + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDASSEMBLYID1, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @UPDASSEMBLYID2, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @LOGICALDELETECODE, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @SUPPLIERCD, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @SECTIONCODE, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @CUSTOMERCODE, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @PROTOCOL, " + Environment.NewLine);
                        sqlText_INSERT.Append("     @LOGINTIMEOUTVAL," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CPRTDOMAIN," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CPRTURL," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTPROGRAMTYPE," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTFILEID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTSENDDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CNECTOBJECTDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @RETRYCNT," + Environment.NewLine);
                        sqlText_INSERT.Append("     @AUTOSENDDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @BOOTTIME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @ENDTIME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @EXECINTERVAL," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SENDMACHINEIPADDR," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SENDMACHINENAME," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SENDCCNCTPASS," + Environment.NewLine);
                        sqlText_INSERT.Append("     @SENDCCNCTUSERID," + Environment.NewLine);
                        sqlText_INSERT.Append("     @CASHREGISTERNO," + Environment.NewLine);
                        sqlText_INSERT.Append("     @LTATSADDATETIME," + Environment.NewLine);
                        //↓ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
                        //sqlText_INSERT.Append("     @FRSTSENDDATE)" + Environment.NewLine);
                        sqlText_INSERT.Append("     @FRSTSENDDATE," + Environment.NewLine);
                        sqlText_INSERT.Append("     @NOTE1SETDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @NOTE2SETDIV," + Environment.NewLine);
                        sqlText_INSERT.Append("     @NOTE3SETDIV)" + Environment.NewLine);
                        //↑ UPD 2020/02/04 Y.Terada  修正内容一覧No.2
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
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraProtocol = sqlCommand.Parameters.Add("@PROTOCOL", SqlDbType.Int);
                    SqlParameter paraLoginTimeoutVal = sqlCommand.Parameters.Add("@LOGINTIMEOUTVAL", SqlDbType.Int);
                    SqlParameter paraCprtDomain = sqlCommand.Parameters.Add("@CPRTDOMAIN", SqlDbType.NVarChar);
                    SqlParameter paraCprtUrl = sqlCommand.Parameters.Add("@CPRTURL", SqlDbType.NVarChar);
                    SqlParameter paraCnectProgramType = sqlCommand.Parameters.Add("@CNECTPROGRAMTYPE", SqlDbType.Int);
                    SqlParameter paraCnectFileId = sqlCommand.Parameters.Add("@CNECTFILEID", SqlDbType.NVarChar);
                    SqlParameter paraCnectSendDiv = sqlCommand.Parameters.Add("@CNECTSENDDIV", SqlDbType.Int);
                    SqlParameter paraCnectObjectDiv = sqlCommand.Parameters.Add("@CNECTOBJECTDIV", SqlDbType.Int);
                    SqlParameter paraRetryCnt = sqlCommand.Parameters.Add("@RETRYCNT", SqlDbType.Int);
                    SqlParameter paraAutoSendDiv = sqlCommand.Parameters.Add("@AUTOSENDDIV", SqlDbType.Int);
                    SqlParameter paraBootTime = sqlCommand.Parameters.Add("@BOOTTIME", SqlDbType.Int);
                    SqlParameter paraEndTime = sqlCommand.Parameters.Add("@ENDTIME", SqlDbType.Int);
                    SqlParameter paraExecInterval = sqlCommand.Parameters.Add("@EXECINTERVAL", SqlDbType.Int);
                    SqlParameter paraSendMachineIpAddr = sqlCommand.Parameters.Add("@SENDMACHINEIPADDR", SqlDbType.NVarChar);
                    SqlParameter paraSendMachineName = sqlCommand.Parameters.Add("@SENDMACHINENAME", SqlDbType.NVarChar);
                    SqlParameter paraSendCcnctPass = sqlCommand.Parameters.Add("@SENDCCNCTPASS", SqlDbType.NVarChar);
                    SqlParameter paraSendCcnctUserid = sqlCommand.Parameters.Add("@SENDCCNCTUSERID", SqlDbType.NVarChar);
                    SqlParameter paraCashregiSterno = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                    SqlParameter paraLtAtSadDateTime = sqlCommand.Parameters.Add("@LTATSADDATETIME", SqlDbType.BigInt);
                    SqlParameter paraFrstSendDate = sqlCommand.Parameters.Add("@FRSTSENDDATE", SqlDbType.Int);
                    //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                    SqlParameter paraNote1SetDiv = sqlCommand.Parameters.Add("@NOTE1SETDIV", SqlDbType.Int);
                    SqlParameter paraNote2SetDiv = sqlCommand.Parameters.Add("@NOTE2SETDIV", SqlDbType.Int);
                    SqlParameter paraNote3SetDiv = sqlCommand.Parameters.Add("@NOTE3SETDIV", SqlDbType.Int);
                    //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2


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
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(connectInfoWork.SectionCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CustomerCode);
                    paraProtocol.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.Protocol);
                    paraLoginTimeoutVal.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.LoginTimeoutVal);
                    paraCprtDomain.Value = SqlDataMediator.SqlSetString(connectInfoWork.CprtDomain);
                    paraCprtUrl.Value = SqlDataMediator.SqlSetString(connectInfoWork.CprtUrl);
                    paraCnectProgramType.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectProgramType);
                    paraCnectFileId.Value = SqlDataMediator.SqlSetString(connectInfoWork.CnectFileId);
                    paraCnectSendDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectSendDiv);
                    paraCnectObjectDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CnectObjectDiv);
                    paraRetryCnt.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.RetryCnt);
                    paraAutoSendDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.AutoSendDiv);
                    paraBootTime.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.BootTime);
                    paraEndTime.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.EndTime);
                    paraExecInterval.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.ExecInterval);
                    paraSendMachineIpAddr.Value = SqlDataMediator.SqlSetString(connectInfoWork.SendMachineIpAddr);
                    paraSendMachineName.Value = SqlDataMediator.SqlSetString(connectInfoWork.SendMachineName);
                    paraSendCcnctPass.Value = SqlDataMediator.SqlSetString(connectInfoWork.SendCcnctPass);
                    paraSendCcnctUserid.Value = SqlDataMediator.SqlSetString(connectInfoWork.SendCcnctUserid);
                    paraCashregiSterno.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.CashregiSterno);
                    paraLtAtSadDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(connectInfoWork.LtAtSadDateTime);
                    paraFrstSendDate.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.FrstSendDate);
                    //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                    paraNote1SetDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.Note1SetDiv);
                    paraNote2SetDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.Note2SetDiv);
                    paraNote3SetDiv.Value = SqlDataMediator.SqlSetInt32(connectInfoWork.Note3SetDiv);
                    //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2


                    sqlCommand.ExecuteNonQuery();
                    al = connectInfoWork;

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SalCprtConnectInfoPrcPrStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalCprtConnectInfoPrcPrStDB.WriteProc", status);
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

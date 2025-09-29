//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送信ログ表示
// プログラム概要   : 送信ログ表示DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2019/12/02  修正内容 : 新規作成
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 送信ログ表示リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送信ログ表示の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/12/02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SalCprtSndLogDB : RemoteDB, ISalCprtSndLogDB
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public SalCprtSndLogDB() : base("PMSDC04007D", "Broadleaf.Application.Remoting.ParamData.SalCprtSndLogListCndtnWork", "SALCPRTSNDLOGRF")
        {
        }

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        #region [トランザクション生成処理]
        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <returns>SqlTransaction</returns>
        /// <remarks>
        /// <br>Note       : SqlTransaction生成処理</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //トランザクション生成処理

        #region ISalCprtSndLogDB メンバ
        /// <summary>
        /// 売上データ送信ログテーブルのログ情報取得
        /// </summary>
        /// <param name="salCprtSndLogListResultWork">売上データ送信ログ抽出結果</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="salCprtSndLogListCondPara">売上データ送信ログ抽出条件パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public int SearchSalCprtSndLog(out object salCprtSndLogListResultWork, out string errMessage, ref object salCprtSndLogListCondPara, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            salCprtSndLogListResultWork = null;
            errMessage = null;
            SqlConnection sqlConnection = null;
            SalCprtSndLogListCndtnWork _salCprtSndLogListCndtnWork = salCprtSndLogListCondPara as SalCprtSndLogListCndtnWork;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchSalCprtSndLogProc(out salCprtSndLogListResultWork, out errMessage, ref _salCprtSndLogListCndtnWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "SalCprtSndLogDB.SearchSalCprtSndLog Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// 売上データ送信ログテーブルのログ情報を削除する
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public int ResetSalCprtSndLog(out string errMessage, string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = null;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ResetSalCprtSndLogProc(out errMessage, enterpriseCode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "SalCprtSndLogDB.ResetSalCprtSndLog Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// 売上データ送信ログテーブルのログ情報取得
        /// </summary>
        /// <param name="salCprtSndLogListResultWork">売上データ送信ログ抽出結果</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="salCprtSndLogListCondPara">売上データ送信ログ抽出条件パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private int SearchSalCprtSndLogProc(out object salCprtSndLogListResultWork, out string errMessage, ref SalCprtSndLogListCndtnWork salCprtSndLogListCondPara, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            salCprtSndLogListResultWork = null;
            errMessage = null;
            ArrayList al = new ArrayList(); // 抽出結果

            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string selectText = string.Empty;

                #region Select文作成
                selectText += "SELECT" + Environment.NewLine;
                selectText += " SAESL.CREATEDATETIMERF" + Environment.NewLine;
                selectText += " ,SAESL.UPDATEDATETIMERF" + Environment.NewLine;
                selectText += " ,SAESL.ENTERPRISECODERF" + Environment.NewLine;
                selectText += " ,SAESL.FILEHEADERGUIDRF" + Environment.NewLine;
                selectText += " ,SAESL.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectText += " ,SAESL.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectText += " ,SAESL.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectText += " ,SAESL.LOGICALDELETECODERF" + Environment.NewLine;
                selectText += " ,SAESL.SECTIONCODERF" + Environment.NewLine;
                selectText += " ,SAESL.AUTOSENDDIVRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDDATETIMESTARTRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDDATETIMEENDRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDOBJDATESTARTRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDOBJDATEENDRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDOBJCUSTSTARTRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDOBJCUSTENDRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDOBJDIVRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDRESULTSRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDERRORCONTENTSRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDSLIPCOUNTRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDSLIPDTLCNTRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDSLIPTOTALMNYRF FROM SALCPRTSNDLOGRF AS SAESL" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectText, sqlConnection);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, salCprtSndLogListCondPara, logicalMode);

                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    if (salCprtSndLogListCondPara.MaxSearchCt == 0)
                    {
                        al.Add(this.CopyToSalCprtSndLogListResultWorkFromReader(ref sqlDataReader));
                    }
                    else
                    {
                        if (al.Count < salCprtSndLogListCondPara.MaxSearchCt)
                        {
                            al.Add(this.CopyToSalCprtSndLogListResultWorkFromReader(ref sqlDataReader));
                        }
                        else
                        {
                            salCprtSndLogListCondPara.SearchOverFlg = true;
                            break;
                        }
                    }
                }

                // 検索結果がある場合
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalCprtSndLogDB.SearchSalCprtSndLogProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!sqlDataReader.IsClosed) sqlDataReader.Close();
            }

            salCprtSndLogListResultWork = al;
            return status;
        }

        /// <summary>
        /// 売上データ送信ログテーブルのログ情報を削除する
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private int ResetSalCprtSndLogProc(out string errMessage, string enterpriseCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            errMessage = null;
            SqlCommand sqlCommand = null;
            try
            {
                string selectText = string.Empty;

                #region DELETE文作成
                selectText += "DELETE FROM SALCPRTSNDLOGRF " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectText, sqlConnection);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereStringForReset(ref sqlCommand, enterpriseCode);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalCprtSndLogDB.ResetSalCprtSndLogProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
            }
            return status;
        }
        #endregion

        #region 内部処理
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_salCprtSndLogListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalCprtSndLogListCndtnWork _salCprtSndLogListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            // WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            // 企業コード
            retstring += " SAESL.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_salCprtSndLogListCndtnWork.EnterpriseCode);

            // 論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND SAESL.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND SAESL.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            // 拠点コード
            if ((_salCprtSndLogListCndtnWork.SectionCodes != null) && (_salCprtSndLogListCndtnWork.SectionCodes.Length > 0))
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _salCprtSndLogListCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND SAESL.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            // 開始送信日時
            if (_salCprtSndLogListCndtnWork.SendDateTimeStart != 0)
            {
                retstring += " AND SAESL.SENDDATETIMESTARTRF >= @SENDDATETIMESTART" + Environment.NewLine;
                SqlParameter paraSendDateTimeStart = sqlCommand.Parameters.Add("@SENDDATETIMESTART", SqlDbType.BigInt);
                paraSendDateTimeStart.Value = SqlDataMediator.SqlSetInt64(_salCprtSndLogListCndtnWork.SendDateTimeStart);

            }
            // 終了送信日時
            if (_salCprtSndLogListCndtnWork.SendDateTimeEnd != 0)
            {
                if (_salCprtSndLogListCndtnWork.SendDateTimeStart == 0)
                {
                    retstring += " AND (SAESL.SENDDATETIMESTARTRF IS NULL OR";
                }
                else
                {
                    retstring += " AND (";
                }

                retstring += " SAESL.SENDDATETIMESTARTRF <= @SENDDATETIMEEND)" + Environment.NewLine;
                SqlParameter paraSendDateTimeEnd = sqlCommand.Parameters.Add("@SENDDATETIMEEND", SqlDbType.BigInt);
                paraSendDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(_salCprtSndLogListCndtnWork.SendDateTimeEnd);
            }

            // 自動送信区分(0:手動,1:自動)
            if (_salCprtSndLogListCndtnWork.SAndEAutoSendDiv == 0)
            {
                // 0:手動
                retstring += " AND SAESL.AUTOSENDDIVRF=0" + Environment.NewLine;
            }
            else if (_salCprtSndLogListCndtnWork.SAndEAutoSendDiv == 1)
            {
                // 1:自動
                retstring += " AND SAESL.AUTOSENDDIVRF=1" + Environment.NewLine;
            }

            // ソート順（送信日時（開始）降順）
            retstring += " ORDER BY SAESL.SENDDATETIMESTARTRF DESC" + Environment.NewLine;

            return retstring;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereStringForReset(ref SqlCommand sqlCommand, string enterpriseCode)
        {
            // WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            // 企業コード
            retstring += " ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            return retstring;
        }

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 SqlDataReader → ScmInqLogWork
        /// </summary>
        /// <param name="sqlDataReader">SqlDataReader</param>
        /// <returns>SalCprtSndLogListResultWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private SalCprtSndLogListResultWork CopyToSalCprtSndLogListResultWorkFromReader(ref SqlDataReader sqlDataReader)
        {
            // 売上データ送信ログワーク
            SalCprtSndLogListResultWork wkSalCprtSndLogListResultWork = new SalCprtSndLogListResultWork();

            # region クラスへ格納
            //売上データ送信ログデータ格納項目
            wkSalCprtSndLogListResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));
            wkSalCprtSndLogListResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSalCprtSndLogListResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));
            wkSalCprtSndLogListResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSalCprtSndLogListResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSalCprtSndLogListResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSalCprtSndLogListResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSalCprtSndLogListResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSalCprtSndLogListResultWork.SectionCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SECTIONCODERF"));
            wkSalCprtSndLogListResultWork.SAndEAutoSendDiv = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("AUTOSENDDIVRF"));
            wkSalCprtSndLogListResultWork.SendDateTimeStart = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("SENDDATETIMESTARTRF"));
            wkSalCprtSndLogListResultWork.SendDateTimeEnd = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("SENDDATETIMEENDRF"));
            wkSalCprtSndLogListResultWork.SendObjDateStart = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJDATESTARTRF"));
            wkSalCprtSndLogListResultWork.SendObjDateEnd = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJDATEENDRF"));
            wkSalCprtSndLogListResultWork.SendObjCustStart = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJCUSTSTARTRF"));
            wkSalCprtSndLogListResultWork.SendObjCustEnd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJCUSTENDRF"));
            wkSalCprtSndLogListResultWork.SendObjDiv = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJDIVRF"));
            wkSalCprtSndLogListResultWork.SendResults = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDRESULTSRF"));
            wkSalCprtSndLogListResultWork.SendErrorContents = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SENDERRORCONTENTSRF"));
            wkSalCprtSndLogListResultWork.SendSlipCount = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDSLIPCOUNTRF"));
            wkSalCprtSndLogListResultWork.SendSlipDtlCnt = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDSLIPDTLCNTRF"));
            wkSalCprtSndLogListResultWork.SendSlipTotalMny = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("SENDSLIPTOTALMNYRF"));
            # endregion

            return wkSalCprtSndLogListResultWork;
        }
        # endregion
        #endregion

    }
}

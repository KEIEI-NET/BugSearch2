//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送信ログ表示
// プログラム概要   : 送信ログ表示DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhaimm
// 作 成 日  2013.06.26  修正内容 : 新規作成
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
    /// <br>Programmer : zhaimm</br>
    /// <br>Date       : 2013.06.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SAndESalSndLogDB : RemoteDB, ISAndESalSndLogDB
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        public SAndESalSndLogDB() : base("PMSAE04007D", "Broadleaf.Application.Remoting.ParamData.SAndESalSndLogListCndtnWork", "SANDESALSNDLOGRF")
        {
        }

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
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
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //トランザクション生成処理

        #region ISAndESalSndLogDB メンバ
        /// <summary>
        /// 売上データ送信ログテーブルのログ情報取得
        /// </summary>
        /// <param name="sAndESalSndLogListResultWork">売上データ送信ログ抽出結果</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="sAndESalSndLogListCondPara">売上データ送信ログ抽出条件パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        public int SearchSAndESalSndLog(out object sAndESalSndLogListResultWork, out string errMessage, ref object sAndESalSndLogListCondPara, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            sAndESalSndLogListResultWork = null;
            errMessage = null;
            SqlConnection sqlConnection = null;
            SAndESalSndLogListCndtnWork _sAndESalSndLogListCndtnWork = sAndESalSndLogListCondPara as SAndESalSndLogListCndtnWork;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchSAndESalSndLogProc(out sAndESalSndLogListResultWork, out errMessage, ref _sAndESalSndLogListCndtnWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "SAndESalSndLogDB.SearchSAndESalSndLog Exception=" + ex.Message);
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
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        public int ResetSAndESalSndLog(out string errMessage, string enterpriseCode)
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

                status = ResetSAndESalSndLogProc(out errMessage, enterpriseCode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "SAndESalSndLogDB.ResetSAndESalSndLog Exception=" + ex.Message);
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
        /// <param name="sAndESalSndLogListResultWork">売上データ送信ログ抽出結果</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="sAndESalSndLogListCondPara">売上データ送信ログ抽出条件パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        private int SearchSAndESalSndLogProc(out object sAndESalSndLogListResultWork, out string errMessage, ref SAndESalSndLogListCndtnWork sAndESalSndLogListCondPara, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            sAndESalSndLogListResultWork = null;
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
                selectText += " ,SAESL.SANDEAUTOSENDDIVRF" + Environment.NewLine;
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
                selectText += " ,SAESL.SENDSLIPTOTALMNYRF FROM SANDESALSNDLOGRF AS SAESL" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectText, sqlConnection);

                //WHERE文の作成
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, sAndESalSndLogListCondPara, logicalMode);

                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    if (sAndESalSndLogListCondPara.MaxSearchCt == 0)
                    {
                        al.Add(this.CopyToSAndESalSndLogListResultWorkFromReader(ref sqlDataReader));
                    }
                    else
                    {
                        if (al.Count < sAndESalSndLogListCondPara.MaxSearchCt)
                        {
                            al.Add(this.CopyToSAndESalSndLogListResultWorkFromReader(ref sqlDataReader));
                        }
                        else
                        {
                            sAndESalSndLogListCondPara.SearchOverFlg = true;
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
                base.WriteErrorLog(ex, "StockMoveListWorkDB.SearchSAndESalSndLogProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!sqlDataReader.IsClosed) sqlDataReader.Close();
            }

            sAndESalSndLogListResultWork = al;
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
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        private int ResetSAndESalSndLogProc(out string errMessage, string enterpriseCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            errMessage = null;
            SqlCommand sqlCommand = null;
            try
            {
                string selectText = string.Empty;

                #region DELETE文作成
                selectText += "DELETE FROM SANDESALSNDLOGRF " + Environment.NewLine;
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
                base.WriteErrorLog(ex, "StockMoveListWorkDB.ResetSAndESalSndLogProc Exception=" + ex.Message);
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
        /// <param name="_sAndESalSndLogListCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SAndESalSndLogListCndtnWork _sAndESalSndLogListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            // WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;

            // 企業コード
            retstring += " SAESL.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_sAndESalSndLogListCndtnWork.EnterpriseCode);

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
            if ((_sAndESalSndLogListCndtnWork.SectionCodes != null) && (_sAndESalSndLogListCndtnWork.SectionCodes.Length > 0))
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _sAndESalSndLogListCndtnWork.SectionCodes)
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
            if (_sAndESalSndLogListCndtnWork.SendDateTimeStart != 0)
            {
                retstring += " AND SAESL.SENDDATETIMESTARTRF >= @SENDDATETIMESTART" + Environment.NewLine;
                SqlParameter paraSendDateTimeStart = sqlCommand.Parameters.Add("@SENDDATETIMESTART", SqlDbType.BigInt);
                paraSendDateTimeStart.Value = SqlDataMediator.SqlSetInt64(_sAndESalSndLogListCndtnWork.SendDateTimeStart);

            }
            // 終了送信日時
            if (_sAndESalSndLogListCndtnWork.SendDateTimeEnd != 0)
            {
                if (_sAndESalSndLogListCndtnWork.SendDateTimeStart == 0)
                {
                    retstring += " AND (SAESL.SENDDATETIMESTARTRF IS NULL OR";
                }
                else
                {
                    retstring += " AND (";
                }

                retstring += " SAESL.SENDDATETIMESTARTRF <= @SENDDATETIMEEND)" + Environment.NewLine;
                SqlParameter paraSendDateTimeEnd = sqlCommand.Parameters.Add("@SENDDATETIMEEND", SqlDbType.BigInt);
                paraSendDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(_sAndESalSndLogListCndtnWork.SendDateTimeEnd);
            }

            // S&E自動送信区分(0:手動,1:自動)
            if (_sAndESalSndLogListCndtnWork.SAndEAutoSendDiv == 0)
            {
                // 0:手動
                retstring += " AND SAESL.SANDEAUTOSENDDIVRF=0" + Environment.NewLine;
            }
            else if (_sAndESalSndLogListCndtnWork.SAndEAutoSendDiv == 1)
            {
                // 1:自動
                retstring += " AND SAESL.SANDEAUTOSENDDIVRF=1" + Environment.NewLine;
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
        /// <returns>SAndESalSndLogListResultWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        private SAndESalSndLogListResultWork CopyToSAndESalSndLogListResultWorkFromReader(ref SqlDataReader sqlDataReader)
        {
            // 売上データ送信ログワーク
            SAndESalSndLogListResultWork wkSAndESalSndLogListResultWork = new SAndESalSndLogListResultWork();

            # region クラスへ格納
            //売上データ送信ログデータ格納項目
            wkSAndESalSndLogListResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));
            wkSAndESalSndLogListResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSAndESalSndLogListResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));
            wkSAndESalSndLogListResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSAndESalSndLogListResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSAndESalSndLogListResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSAndESalSndLogListResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSAndESalSndLogListResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSAndESalSndLogListResultWork.SectionCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SECTIONCODERF"));
            wkSAndESalSndLogListResultWork.SAndEAutoSendDiv = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SANDEAUTOSENDDIVRF"));
            wkSAndESalSndLogListResultWork.SendDateTimeStart = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("SENDDATETIMESTARTRF"));
            wkSAndESalSndLogListResultWork.SendDateTimeEnd = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("SENDDATETIMEENDRF"));
            wkSAndESalSndLogListResultWork.SendObjDateStart = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJDATESTARTRF"));
            wkSAndESalSndLogListResultWork.SendObjDateEnd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJDATEENDRF"));
            wkSAndESalSndLogListResultWork.SendObjCustStart = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJCUSTSTARTRF"));
            wkSAndESalSndLogListResultWork.SendObjCustEnd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJCUSTENDRF"));
            wkSAndESalSndLogListResultWork.SendObjDiv = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJDIVRF"));
            wkSAndESalSndLogListResultWork.SendResults = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDRESULTSRF"));
            wkSAndESalSndLogListResultWork.SendErrorContents = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SENDERRORCONTENTSRF"));
            wkSAndESalSndLogListResultWork.SendSlipCount = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDSLIPCOUNTRF"));
            wkSAndESalSndLogListResultWork.SendSlipDtlCnt = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDSLIPDTLCNTRF"));
            wkSAndESalSndLogListResultWork.SendSlipTotalMny = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("SENDSLIPTOTALMNYRF"));
            # endregion

            return wkSAndESalSndLogListResultWork;
        }
        # endregion
        #endregion

    }
}

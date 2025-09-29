//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : TSP連携マスタ設定
// プログラム概要   : TSP連携マスタ設定を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11670305-00  作成担当 : 3H 劉星光
// 作 成 日 : 2020/11/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Resources;
using System.Text;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    ///  TSP連携マスタ設定　リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : TSP連携マスタ設定マスタ取得を行うクラスです。</br>
    /// <br>Programmer : 3H 劉星光</br>
    /// <br>Date       : 2020/11/23</br>
    /// <br>依頼番号   : 11670305-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class TspCprtStDB : RemoteDB, ITspCprtStDB
    {
        #region [コンストラクタ]
        /// <summary>
        ///  TSP連携マスタ設定　リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : TSP連携マスタ設定　リモートオブジェクトクラスコンストラクタ</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public TspCprtStDB()
        {
            // なし
        }
        #endregion

        #region [Search処理]
        /// <summary>
        /// 指定された条件のTSP連携マスタ設定情報LISTの件数を戻します。
        /// </summary>
        /// <param name="tspCprtStWork">検索条件</param>
        /// <param name="tspCprtStWorkList">TSP連携マスタ設定情報LIST</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のTSP連携マスタ設定情報LISTの件数を戻します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int Search(object tspCprtStWork, out object tspCprtStWorkList, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            tspCprtStWorkList = null;
            ArrayList retList = null;
            SqlConnection sqlConnection = null;

            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    // 検索条件
                    TspCprtStWork param = tspCprtStWork as TspCprtStWork;

                    // 検索
                    status = SearchProc(param, out retList, logicalMode, ref sqlConnection);
                    // 戻り値セット
                    tspCprtStWorkList = retList;
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "TspCprtStDB.Search", status);
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された条件のTSP連携マスタ設定情報LISTの件数を戻します。
        /// </summary>
        /// <param name="param">検索条件</param>
        /// <param name="tspCprtStWorkList">TSP連携マスタ設定情報LIST</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="sqlConnection">クエリコネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のTSP連携マスタ設定情報LISTの件数を戻します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int SearchProc(TspCprtStWork param, out ArrayList tspCprtStWorkList, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            tspCprtStWorkList = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            ArrayList al = new ArrayList();

            try
            {
                using (sqlCommand = new SqlCommand("", sqlConnection))
                {
                    // 検索クエリの作成
                    string selectSqlText = MakeSelectSqlText(param, logicalMode, ref sqlCommand);
                    sqlCommand.CommandText = selectSqlText;
                    // 検索タイムアウトの設定(600秒)
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInquiry);

                    using (myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            // 検索結果の格納
                            al.Add(CopyToTspCprtStWorkFromReader(ref myReader));
                        }
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
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "TspCprtStDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TspCprtStDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            tspCprtStWorkList = al;

            return status;
        }

        /// <summary>
        /// 検索クエリ文の作成
        /// </summary>
        /// <param name="param">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="sqlCommand">クエリコマンド</param>
        /// <returns>検索クエリ文</returns>
        /// <remarks>
        /// <br>Note       : 検索クエリ文の作成</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private string MakeSelectSqlText(TspCprtStWork param, ConstantManagement.LogicalMode logicalMode, ref SqlCommand sqlCommand)
        {
            StringBuilder sqlText = new StringBuilder();
            sqlText.AppendLine(" SELECT ");
            sqlText.AppendLine("  CREATEDATETIMERF ");                      // 作成日時
            sqlText.AppendLine("  ,UPDATEDATETIMERF ");                     // 更新日時
            sqlText.AppendLine("  ,ENTERPRISECODERF ");                     // 企業コード
            sqlText.AppendLine("  ,FILEHEADERGUIDRF ");                     // GUID
            sqlText.AppendLine("  ,UPDEMPLOYEECODERF ");                    // 更新従業員コード
            sqlText.AppendLine("  ,UPDASSEMBLYID1RF ");                     // 更新アセンブリID1
            sqlText.AppendLine("  ,UPDASSEMBLYID2RF ");                     // 更新アセンブリID2
            sqlText.AppendLine("  ,LOGICALDELETECODERF ");                  // 論理削除区分
            sqlText.AppendLine("  ,CUSTOMERCODERF ");                       // 得意先コード
            sqlText.AppendLine("  ,SENDCODERF ");                           // 送信区分
            sqlText.AppendLine("  ,DEBITNSENDCODERF ");                     // 赤伝送信区分
            sqlText.AppendLine("  ,SENDENTERPRISECODERF ");                 // 送信企業コード
            sqlText.AppendLine(" FROM TSPCPRTRF WITH (READUNCOMMITTED) ");
            // Where文
            sqlText.AppendLine(MakeWhereString(param, logicalMode, ref sqlCommand));

            return sqlText.ToString();
        }

        /// <summary>
        /// 検索Where文の作成
        /// </summary>
        /// <param name="param">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="sqlCommand">クエリコマンド</param>
        /// <returns>検索Where文</returns>
        /// <remarks>
        /// <br>Note       : 検索Where文の作成</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private string MakeWhereString(TspCprtStWork param, ConstantManagement.LogicalMode logicalMode, ref SqlCommand sqlCommand)
        {
            StringBuilder sqlText = new StringBuilder();

            sqlText.AppendLine(" WHERE ");

            // 企業コード
            sqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(param.EnterpriseCode);

            // 論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                   (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                   (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                   (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                sqlText.AppendLine(" AND LOGICALDELETECODERF=@LOGICALDELETECODE ");
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                sqlText.AppendLine(" AND LOGICALDELETECODERF<@LOGICALDELETECODE ");
            }
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

            // 得意先コード
            if (param.CustomerCode > 0)
            {
                sqlText.AppendLine(" AND CUSTOMERCODERF=@CUSTOMERCODE ");
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(param.CustomerCode);
            }

            return sqlText.ToString();
        }

        /// <summary>
        /// 検索結果の格納
        /// </summary>
        /// <param name="myReader">結果リーダ</param>
        /// <returns>検索結果</returns>
        /// <remarks>
        /// <br>Note       : 検索結果の格納</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private TspCprtStWork CopyToTspCprtStWorkFromReader(ref SqlDataReader myReader)
        {
            TspCprtStWork resultWork = new TspCprtStWork();
            resultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));      // 作成日時
            resultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));      // 更新日時
            resultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                 // 企業コード
            resultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                   // GUID
            resultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));               // 更新従業員コード
            resultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                 // 更新アセンブリID1
            resultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                 // 更新アセンブリID2
            resultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));            // 論理削除区分
            resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));                      // 得意先コード
            resultWork.SendCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SENDCODERF"));                              // 送信区分
            resultWork.DebitNSendCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNSENDCODERF"));                  // 赤伝送信区分
            resultWork.SendEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDENTERPRISECODERF")).Trim();  // 送信企業コード
            
            return resultWork;
        }
        #endregion

        #region [Write処理]
        /// <summary>
        /// TSP連携マスタ設定情報を登録、更新します。
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携マスタ設定情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP連携マスタ設定情報を登録、更新します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int Write(ref object tspCprtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            using (sqlConnection = CreateSqlConnection(true))
            {
                using (sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default))
                {
                    try
                    {
                        // 登録データ
                        TspCprtStWork writeWork = tspCprtStWork as TspCprtStWork;

                        // 登録
                        status = WriteProc(ref writeWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            if (sqlTransaction.Connection != null)
                            {
                                sqlTransaction.Rollback();
                            }
                        }
                        //戻り値セット
                        tspCprtStWork = writeWork;
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        base.WriteErrorLog(ex, "TspCprtSDB.Write", status);
                        // ロールバック
                        if (sqlTransaction.Connection != null)
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// TSP連携マスタ設定情報を登録、更新します。
        /// </summary>
        /// <param name="tspCprtStWork">登録データ</param>
        /// <param name="sqlConnection">クエリコネクション</param>
        /// <param name="sqlTransaction">クエリトランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP連携マスタ設定情報を登録、更新します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int WriteProc(ref TspCprtStWork tspCprtStWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (tspCprtStWork != null)
                {
                    using (sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
                    {
                        string sqlText = string.Empty;

                        // 排他用検索クエリ
                        sqlText = MakeSelectSqlTextBeforeUpdateDB(tspCprtStWork, ref sqlCommand);

                        sqlCommand.CommandText = sqlText.ToString();
                        using (myReader = sqlCommand.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF")); //更新日時
                                if (updateDateTime != tspCprtStWork.UpdateDateTime)
                                {
                                    // 新規登録で該当データ有りの場合には重複
                                    if (tspCprtStWork.UpdateDateTime == DateTime.MinValue)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                    }
                                    // 既存データで更新日時違いの場合には排他
                                    else
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    }
                                    return status;
                                }

                                #region 更新時のSQL文生成
                                sqlText = MakeUpdateSqlText();
                                #endregion

                                // KEYコマンドを再設定(WHERE条件用)
                                // 企業コード
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@UPDATEENTERPRISECODE", SqlDbType.NChar);
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tspCprtStWork.EnterpriseCode);

                                // 得意先コード
                                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@UPDATECUSTOMERCODE", SqlDbType.Int);
                                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(tspCprtStWork.CustomerCode);

                                sqlCommand.CommandText = sqlText;

                                // 更新ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)tspCprtStWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);
                            }
                            else
                            {
                                // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                if (tspCprtStWork.UpdateDateTime > DateTime.MinValue)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    return status;
                                }

                                #region 新規作成時のSQL文を生成
                                sqlText = MakeInsertSqlText();
                                #endregion

                                sqlCommand.CommandText = sqlText;

                                // 登録ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)tspCprtStWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                            }
                        }

                        #region Parameterオブジェクトの作成と値設定
                        SetParameterForUpdateDB(tspCprtStWork, ref sqlCommand);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "TspCprtStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TspCprtStDB.WriteProc", status);
            }

            return status;
        }

        /// <summary>
        /// 排他用検索クエリ文の作成
        /// </summary>
        /// <param name="param">検索条件</param>
        /// <param name="sqlCommand">クエリコマンド</param>
        /// <returns>排他用検索クエリ文</returns>
        /// <remarks>
        /// <br>Note       : 排他用検索クエリ文の作成</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private string MakeSelectSqlTextBeforeUpdateDB(TspCprtStWork param, ref SqlCommand sqlCommand)
        {
            string sqlText = "SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM TSPCPRTRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";

            // 企業コード
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(param.EnterpriseCode);

            // 得意先コード
            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(param.CustomerCode);

            return sqlText;
        }

        /// <summary>
        /// 更新クエリ文の作成
        /// </summary>
        /// <returns>更新クエリ文</returns>
        /// <remarks>
        /// <br>Note       : 更新クエリ文の作成</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private string MakeUpdateSqlText()
        {
            StringBuilder sqlText = new StringBuilder();

            sqlText.AppendLine(" UPDATE TSPCPRTRF SET ");
            sqlText.AppendLine(" CREATEDATETIMERF=@CREATEDATETIME ");                 // 作成日時
            sqlText.AppendLine(" ,UPDATEDATETIMERF=@UPDATEDATETIME ");                // 更新日時
            sqlText.AppendLine(" ,ENTERPRISECODERF=@ENTERPRISECODE ");                // 企業コード
            sqlText.AppendLine(" ,FILEHEADERGUIDRF=@FILEHEADERGUID ");                // GUID
            sqlText.AppendLine(" ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE ");              // 更新従業員コード
            sqlText.AppendLine(" ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1 ");                // 更新アセンブリID1
            sqlText.AppendLine(" ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2 ");                // 更新アセンブリID2
            sqlText.AppendLine(" ,LOGICALDELETECODERF=@LOGICALDELETECODE ");          // 論理削除区分
            sqlText.AppendLine(" ,CUSTOMERCODERF=@CUSTOMERCODE ");                    // 得意先コード
            sqlText.AppendLine(" ,SENDCODERF=@SENDCODE ");                            // 送信区分
            sqlText.AppendLine(" ,DEBITNSENDCODERF=@DEBITNSENDCODE ");                // 赤伝送信区分
            sqlText.AppendLine(" ,SENDENTERPRISECODERF=@SENDENTERPRISECODE ");        // 送信企業コード
            sqlText.AppendLine(" WHERE ENTERPRISECODERF=@UPDATEENTERPRISECODE ");
            sqlText.AppendLine(" AND CUSTOMERCODERF=@UPDATECUSTOMERCODE ");

            return sqlText.ToString();
        }

        /// <summary>
        /// 新規クエリ文の作成
        /// </summary>
        /// <returns>新規クエリ文</returns>
        /// <remarks>
        /// <br>Note       : 新規クエリ文の作成</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private string MakeInsertSqlText()
        {
            StringBuilder sqlText = new StringBuilder();

            sqlText.AppendLine(" INSERT INTO TSPCPRTRF ( ");
            sqlText.AppendLine(" CREATEDATETIMERF ");                  // 作成日時
            sqlText.AppendLine(" ,UPDATEDATETIMERF ");                 // 更新日時
            sqlText.AppendLine(" ,ENTERPRISECODERF ");                 // 企業コード
            sqlText.AppendLine(" ,FILEHEADERGUIDRF ");                 // GUID
            sqlText.AppendLine(" ,UPDEMPLOYEECODERF ");                // 更新従業員コード
            sqlText.AppendLine(" ,UPDASSEMBLYID1RF ");                 // 更新アセンブリID1
            sqlText.AppendLine(" ,UPDASSEMBLYID2RF ");                 // 更新アセンブリID2
            sqlText.AppendLine(" ,LOGICALDELETECODERF ");              // 論理削除区分
            sqlText.AppendLine(" ,CUSTOMERCODERF ");                   // 得意先コード
            sqlText.AppendLine(" ,SENDCODERF ");                       // 送信区分
            sqlText.AppendLine(" ,DEBITNSENDCODERF ");                 // 赤伝送信区分
            sqlText.AppendLine(" ,SENDENTERPRISECODERF ");             // 送信企業コード
            sqlText.AppendLine(" ) VALUES ( ");
            sqlText.AppendLine(" @CREATEDATETIME ");                   // 作成日時
            sqlText.AppendLine(" ,@UPDATEDATETIME ");                  // 更新日時
            sqlText.AppendLine(" ,@ENTERPRISECODE ");                  // 企業コード
            sqlText.AppendLine(" ,@FILEHEADERGUID ");                  // GUID
            sqlText.AppendLine(" ,@UPDEMPLOYEECODE ");                 // 更新従業員コード
            sqlText.AppendLine(" ,@UPDASSEMBLYID1 ");                  // 更新アセンブリID1
            sqlText.AppendLine(" ,@UPDASSEMBLYID2 ");                  // 更新アセンブリID2
            sqlText.AppendLine(" ,@LOGICALDELETECODE ");               // 論理削除区分
            sqlText.AppendLine(" ,@CUSTOMERCODE ");                    // 得意先コード
            sqlText.AppendLine(" ,@SENDCODE ");                        // 送信区分
            sqlText.AppendLine(" ,@DEBITNSENDCODE ");                  // 赤伝送信区分
            sqlText.AppendLine(" ,@SENDENTERPRISECODE ");              // 送信企業コード
            sqlText.AppendLine(" ) ");

            return sqlText.ToString();
        }

        /// <summary>
        /// 更新DB用コマンドパラメータの作成
        /// </summary>
        /// <param name="param">更新データ</param>
        /// <param name="sqlCommand">クエリコマンド</param>
        /// <remarks>
        /// <br>Note       : 更新DB用コマンドパラメータの作成</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private void SetParameterForUpdateDB(TspCprtStWork param, ref SqlCommand sqlCommand)
        {
            #region Parameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
            SqlParameter paraSendCode = sqlCommand.Parameters.Add("@SENDCODE", SqlDbType.Int);
            SqlParameter paraDebitNSendCode = sqlCommand.Parameters.Add("@DEBITNSENDCODE", SqlDbType.Int);
            SqlParameter paraSendEnterpriseCode = sqlCommand.Parameters.Add("@SENDENTERPRISECODE", SqlDbType.NChar);
            #endregion

            #region Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(param.CreateDateTime);          // 作成日時
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(param.UpdateDateTime);          // 更新日時
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(param.EnterpriseCode);                     // 企業コード
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(param.FileHeaderGuid);                       // GUID
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(param.UpdEmployeeCode);                   // 更新従業員コード
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(param.UpdAssemblyId1);                     // 更新アセンブリID1
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(param.UpdAssemblyId2);                     // 更新アセンブリID2
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(param.LogicalDeleteCode);                // 論理削除区分
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(param.CustomerCode);                          // 得意先コード
            paraSendCode.Value = SqlDataMediator.SqlSetInt32(param.SendCode);                                  // 送信区分
            paraDebitNSendCode.Value = SqlDataMediator.SqlSetInt32(param.DebitNSendCode);                      // 赤伝送信区分
            paraSendEnterpriseCode.Value = SqlDataMediator.SqlSetString(param.SendEnterpriseCode);             // 送信企業コード
            #endregion
        }
        #endregion

        #region [Delete処理]
        /// <summary>
        /// TSP連携マスタ設定情報を完全削除します。
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携マスタ設定情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP連携マスタ設定情報を完全削除します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int Delete(object tspCprtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            using (sqlConnection = CreateSqlConnection(true))
            {
                using (sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default))
                {
                    try
                    {
                        // 削除データ
                        TspCprtStWork deleteWork = tspCprtStWork as TspCprtStWork;

                        // 削除
                        status = DeleteProc(deleteWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            if (sqlTransaction.Connection != null)
                            {
                                sqlTransaction.Rollback();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        base.WriteErrorLog(ex, "tspCprtStDB.Delete", status);
                        // ロールバック
                        if (sqlTransaction.Connection != null)
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// TSP連携マスタ設定情報を完全削除します。
        /// </summary>
        /// <param name="tspCprtStWork">削除データ</param>
        /// <param name="sqlConnection">クエリコネクション</param>
        /// <param name="sqlTransaction">クエリトランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP連携マスタ設定情報を完全削除します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int DeleteProc(TspCprtStWork tspCprtStWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (tspCprtStWork != null)
                {
                    using (sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
                    {
                        string sqlText = string.Empty;

                        // 排他用検索クエリ
                        sqlText = MakeSelectSqlTextBeforeUpdateDB(tspCprtStWork, ref sqlCommand);

                        sqlCommand.CommandText = sqlText.ToString();
                        using (myReader = sqlCommand.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF")); //更新日時
                                if (updateDateTime != tspCprtStWork.UpdateDateTime)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    return status;
                                }

                                #region 削除時のSQL文生成
                                sqlText = "DELETE FROM TSPCPRTRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE AND CUSTOMERCODERF=@DELCUSTOMERCODE";
                                #endregion

                                // KEYコマンドを再設定(WHERE条件用)
                                // 企業コード
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tspCprtStWork.EnterpriseCode);

                                // 得意先コード
                                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@DELCUSTOMERCODE", SqlDbType.Int);
                                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(tspCprtStWork.CustomerCode);

                                sqlCommand.CommandText = sqlText;
                            }
                            else
                            {
                                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }
                        }

                        sqlCommand.ExecuteNonQuery();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "TspCprtStDB.WriteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TspCprtStDB.WriteProc", status);
            }

            return status;
        }
        #endregion

        #region [LogicalDelete処理]
        /// <summary>
        /// TSP連携マスタ設定情報を論理削除します。
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携マスタ設定情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP連携マスタ設定情報を論理削除します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int LogicalDelete(ref object tspCprtStWork)
        {
            // 論理削除
            return LogicalDeleteOrRelive(ref tspCprtStWork, 0);
        }
        #endregion

        #region [Revival処理]
        /// <summary>
        /// TSP連携マスタ設定情報を復活します。
        /// </summary>
        /// <param name="tspCprtStWork">TSP連携マスタ設定情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP連携マスタ設定情報を復活します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        public int Revival(ref object tspCprtStWork)
        {
            // 復活
            return LogicalDeleteOrRelive(ref tspCprtStWork, 1);
        }

        /// <summary>
        /// TSP連携マスタ設定情報を論理削除、復活します。
        /// </summary>
        /// <param name="tspCprtStWork">更新データ</param>
        /// <param name="mode">モード（0:論理削除 1:復活）</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP連携マスタ設定情報を論理削除、復活します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int LogicalDeleteOrRelive(ref object tspCprtStWork, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            using (sqlConnection = CreateSqlConnection(true))
            {
                using (sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default))
                {
                    try
                    {
                        // 更新データ
                        TspCprtStWork updateWork = tspCprtStWork as TspCprtStWork;

                        // 更新
                        status = LogicalDeleteOrReliveProc(ref updateWork, mode, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            if (sqlTransaction.Connection != null)
                            {
                                sqlTransaction.Rollback();
                            }
                        }
                        //戻り値セット
                        tspCprtStWork = updateWork;
                    }
                    catch (Exception ex)
                    {
                        string procModestr = mode == 0 ? "LogicalDelete" : "Revival";
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        base.WriteErrorLog(ex, "TspCprtStDB.LogicalDeleteOrRelive: " + procModestr, status);
                        // ロールバック
                        if (sqlTransaction.Connection != null)
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// TSP連携マスタ設定情報を論理削除、復活します。
        /// </summary>
        /// <param name="tspCprtStWork">更新データ</param>
        /// <param name="mode">モード（0:論理削除 1:復活）</param>
        /// <param name="sqlConnection">クエリコネクション</param>
        /// <param name="sqlTransaction">クエリトランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP連携マスタ設定情報を論理削除、復活します。</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
        /// </remarks>
        private int LogicalDeleteOrReliveProc(ref TspCprtStWork tspCprtStWork, int mode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            int logicalDelCd = 0;
            string procModestr = mode == 0 ? "LogicalDelete" : "Revival";

            try
            {
                if (tspCprtStWork != null)
                {
                    using (sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
                    {
                        string sqlText = string.Empty;

                        // 排他用検索クエリ
                        sqlText = MakeSelectSqlTextBeforeUpdateDB(tspCprtStWork, ref sqlCommand);

                        sqlCommand.CommandText = sqlText.ToString();
                        using (myReader = sqlCommand.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF")); // 更新日時
                                if (updateDateTime != tspCprtStWork.UpdateDateTime)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                    return status;
                                }

                                // 現在の論理削除区分を取得
                                logicalDelCd =  SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                                #region 更新時のSQL文生成
                                sqlText = MakeUpdateSqlText();
                                #endregion

                                // KEYコマンドを再設定(WHERE条件用)
                                // 企業コード
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@UPDATEENTERPRISECODE", SqlDbType.NChar);
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tspCprtStWork.EnterpriseCode);

                                // 得意先コード
                                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@UPDATECUSTOMERCODE", SqlDbType.Int);
                                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(tspCprtStWork.CustomerCode);

                                sqlCommand.CommandText = sqlText;

                                // 更新ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)tspCprtStWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);
                            }
                            else
                            {
                                // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }
                        }

                        // 論理削除モードの場合
                        if (mode == 0)
                        {
                            tspCprtStWork.LogicalDeleteCode = 1; // 論理削除フラグをセット
                        }
                        // 復活モードの場合
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                tspCprtStWork.LogicalDeleteCode = 0; // 論理削除フラグを解除
                            }
                            else
                            {
                                // 既に復活している場合はそのまま正常を戻す
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; // 完全削除はデータなしを戻す
                                }
                                return status;
                            }
                        }

                        #region Parameterオブジェクトの作成と値設定
                        SetParameterForUpdateDB(tspCprtStWork, ref sqlCommand);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "TspCprtStDB.LogicalDeleteOrReliveProc: " + procModestr, status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TspCprtStDB.LogicalDeleteOrReliveProcc: " + procModestr, status);
            }

            return status;
        }
        #endregion

        # region [コネクション生成処理]

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection生成処理</br>
        /// <br>Programmer : 3H 劉星光</br>
        /// <br>Date       : 2020/11/23</br>
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
        # endregion [コネクション生成処理]
    }
}
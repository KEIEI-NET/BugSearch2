//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PMTAB初期表示従業員設定マスタDBリモートオブジェクト
// プログラム概要   : PMTAB初期表示従業員設定マスタDBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/08/18  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/10/23  修正内容 : ログイン担当者に0000共通を設定できない件の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 作 成 日  2014/10/28  修正内容 : 論理削除したデータが表示されない件の対応
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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Data.SqlClient;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTAB初期表示従業員設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB初期表示従業員設定マスタの実データ操作を行うクラスです。</br>
    /// </remarks>
    [Serializable]
    public class PmtDefEmpDB : RemoteDB, IPmtDefEmpDB
    {
        /// <summary>
        /// PMTAB初期表示従業員設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// </remarks>
        public PmtDefEmpDB()
            : base("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork", "PmtDefEmpRF")
        {
        }

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_UserDB);
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
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //トランザクション生成処理

        # region [Read]
        /// <summary>
        /// 単一のPMTAB初期表示従業員設定マスタ情報を取得します。
        /// </summary>
        /// <param name="pmtDefEmpObj">PmtDefEmpWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB初期表示従業員設定マスタのキー値が一致するPMTAB初期表示従業員設定マスタ情報を取得します。</br>
        public int Read(ref object pmtDefEmpObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            try
            {
                PmtDefEmpWork pmtDefEmpWork = pmtDefEmpObj as PmtDefEmpWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = this.Read(ref pmtDefEmpWork, sqlConnection);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// 単一のPMTAB初期表示従業員設定マスタ情報を取得します。
        /// </summary>
        /// <param name="pmtDefEmpWork">PmtDefEmpWorkオブジェクト</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB初期表示従業員設定マスタのキー値が一致するPMTAB初期表示従業員設定マスタ情報を取得します。</br>
        public int Read(ref PmtDefEmpWork pmtDefEmpWork, SqlConnection sqlConnection)
        {
            return this.ReadProc(ref pmtDefEmpWork, sqlConnection);
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報リストを取得します。
        /// </summary>
        /// <param name="pmtDefEmpObj">抽出条件リスト(PmtDefEmpWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB初期表示従業員設定マスタのキー値が一致するPMTAB初期表示従業員設定マスタ情報を取得します。</br>
        public int ReadAll(ref object pmtDefEmpObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList paraList = pmtDefEmpObj as ArrayList;
                ArrayList pmtDefEmpList = new ArrayList();

                // コネクション生成
                sqlConnection = this.CreateSqlConnection();

                status = this.ReadAll(ref pmtDefEmpList, paraList, sqlConnection);

                pmtDefEmpObj = pmtDefEmpList;

            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
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
        /// 単一のPMTAB初期表示従業員設定マスタ情報を取得します。
        /// </summary>
        /// <param name="pmtDefEmpList">抽出結果リスト(PmtDefEmpWork)</param>
        /// <param name="paraList">抽出条件リスト(PmtDefEmpWork)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB初期表示従業員設定マスタのキー値が一致するPMTAB初期表示従業員設定マスタ情報を取得します。</br>
        public int ReadAll(ref ArrayList pmtDefEmpList, ArrayList paraList, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            foreach (PmtDefEmpWork pmtDefEmpWork in paraList)
            {
                PmtDefEmpWork pararetWork = pmtDefEmpWork;

                status = this.ReadProc(ref pararetWork, sqlConnection);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    pmtDefEmpList.Add(pararetWork);
                }
                else
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND && status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        return status;
                    }
            }

            //件数の有無は関係無しで異常系以外はノーマルとする
            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;
        }

        /// <summary>
        /// 単一のPMTAB初期表示従業員設定マスタ情報を取得します。
        /// </summary>
        /// <param name="pmtDefEmpWork">PmtDefEmpWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB初期表示従業員設定マスタのキー値が一致するPMTAB初期表示従業員設定マスタ情報を取得します。</br>
        private int ReadProc(ref PmtDefEmpWork pmtDefEmpWork, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sb = new StringBuilder();
                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);

                # region [SELECT文]

                sb.AppendLine("SELECT");
                sb.AppendLine("  CREATEDATETIMERF");            // 作成日時
                sb.AppendLine("  , UPDATEDATETIMERF");          // 更新日時
                sb.AppendLine("  , ENTERPRISECODERF");          // 企業コード
                sb.AppendLine("  , FILEHEADERGUIDRF");          // GUID
                sb.AppendLine("  , UPDEMPLOYEECODERF");         // 更新従業員コード
                sb.AppendLine("  , UPDASSEMBLYID1RF");          // 更新アセンブリID1
                sb.AppendLine("  , UPDASSEMBLYID2RF");          // 更新アセンブリID2
                sb.AppendLine("  , LOGICALDELETECODERF");       // 論理削除区分
                sb.AppendLine("  , LOGINAGENCODERF");           // ログイン担当者コード
                sb.AppendLine("  , SALESEMPDIVRF");             // 担当者区分
                sb.AppendLine("  , SALESEMPLOYEECDRF");         // 販売従業員コード
                sb.AppendLine("  , FRONTEMPDIVRF");             // 受注者区分
                sb.AppendLine("  , FRONTEMPLOYEECDRF");         // 受付従業員コード
                sb.AppendLine("  , SALESINPUTDIVRF");           // 発行者区分
                sb.AppendLine("  , SALESINPUTCODERF");          // 売上入力者コード
                sb.AppendLine("FROM");
                sb.AppendLine("  PMTDEFEMPRF ");

                sqlCommand.CommandText = sb.ToString();
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmtDefEmpWork);

                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToRecieveSecTableWorkFromReader(ref myReader, ref pmtDefEmpWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
        # endregion

        # region [Delete]
        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="pmtDefEmpList">物理削除するPMTAB初期表示従業員設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB初期表示従業員設定マスタのキー値が一致するPMTAB初期表示従業員設定マスタ情報を物理削除します。</br>
        public int Delete(object pmtDefEmpList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = pmtDefEmpList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = this.Delete(paraList, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// PMTAB初期表示従業員設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="pmtDefEmpList">PMTAB初期表示従業員設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList に格納されているPMTAB初期表示従業員設定マスタ情報を物理削除します。</br>
        public int Delete(ArrayList pmtDefEmpList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(pmtDefEmpList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="pmtDefEmpList">PMTAB初期表示従業員設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList に格納されているPMTAB初期表示従業員設定マスタ情報を物理削除します。</br>
        private int DeleteProc(ArrayList pmtDefEmpList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pmtDefEmpList != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmtDefEmpList.Count; i++)
                    {
                        PmtDefEmpWork pmtDefEmpWork = pmtDefEmpList[i] as PmtDefEmpWork;

                        # region [SELECT文]

                        sb.AppendLine("SELECT");
                        sb.AppendLine("  UPDATEDATETIMERF");          // 更新日時
                        sb.AppendLine("FROM");
                        sb.AppendLine("  PMTDEFEMPRF ");

                        sqlCommand.CommandText = sb.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmtDefEmpWork);

                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (pmtDefEmpWork.LoginAgenCode != "" && _updateDateTime != pmtDefEmpWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]

                            sb = new StringBuilder();
                            sb.AppendLine("DELETE FROM");
                            sb.AppendLine("  PMTDEFEMPRF ");

                            bool isWhere = false;
                            if (pmtDefEmpWork.EnterpriseCode != "")
                            {
                                isWhere = true;
                                sb.AppendLine("WHERE");
                                sb.AppendLine("  ENTERPRISECODERF = @DELETEENTERPRISECODE ");

                                sqlCommand.Parameters.Clear();
                                // Prameterオブジェクトの作成
                                SqlParameter updateParaEnterpriseCode = sqlCommand.Parameters.Add("@DELETEENTERPRISECODE", SqlDbType.NChar);
                                //Parameterオブジェクトへ値設定
                                updateParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.EnterpriseCode);
                            }


                            if (pmtDefEmpWork.LoginAgenCode != "")
                            {
                                if (isWhere)
                                {
                                    sb.AppendLine("  AND LOGINAGENCODERF = @DELETELOGINAGENCODE ");
                                }
                                else
                                {
                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("  LOGINAGENCODERF = @DELETELOGINAGENCODE ");
                                }
                                // Prameterオブジェクトの作成
                                SqlParameter updateParaDbIdGuid = sqlCommand.Parameters.Add("@DELETELOGINAGENCODE", SqlDbType.NChar);
                                //Parameterオブジェクトへ値設定
                                updateParaDbIdGuid.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.LoginAgenCode);
                            }

                            sqlCommand.CommandText = sb.ToString();

                            # endregion
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
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
        # endregion

        # region [Search]
        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="pmtDefEmpList">検索結果</param>
        /// <param name="pmtDefEmpObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB初期表示従業員設定マスタのキー値が一致する、全てのPMTAB初期表示従業員設定マスタ情報を取得します。</br>
        public int Search(ref object pmtDefEmpList, object pmtDefEmpObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            try
            {
                ArrayList pmtDefEmpArray = pmtDefEmpList as ArrayList;
                PmtDefEmpWork pmtDefEmpWork = pmtDefEmpObj as PmtDefEmpWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = this.Search(ref pmtDefEmpArray, pmtDefEmpWork, readMode, logicalMode, sqlConnection);

                if (status == 0)
                {
                    pmtDefEmpList = pmtDefEmpArray as object;
                }
                else
                {
                    ArrayList workArray = new ArrayList();
                    pmtDefEmpList = workArray as object;
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// PMTAB初期表示従業員設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="pmtDefEmpList">PMTAB初期表示従業員設定マスタ情報を格納する ArrayList</param>
        /// <param name="pmtDefEmpWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB初期表示従業員設定マスタのキー値が一致する、全てのPMTAB初期表示従業員設定マスタ情報が格納されている ArrayList を取得します。</br>
        public int Search(ref ArrayList pmtDefEmpList, PmtDefEmpWork pmtDefEmpWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)
        {
            return this.SearchProc(ref pmtDefEmpList, pmtDefEmpWork, readMode, logicalMode, sqlConnection);
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="pmtDefEmpList">PMTAB初期表示従業員設定マスタ情報を格納する ArrayList</param>
        /// <param name="pmtDefEmpWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB初期表示従業員設定マスタのキー値が一致する、全てのPMTAB初期表示従業員設定マスタ情報が格納されている ArrayList を取得します。</br>
        private int SearchProc(ref ArrayList pmtDefEmpList, PmtDefEmpWork pmtDefEmpWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pmtDefEmpList = new ArrayList();
            try
            {
                StringBuilder sb = new StringBuilder();
                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);

                # region [SELECT文]

                sb.AppendLine("SELECT");
                sb.AppendLine("  CREATEDATETIMERF");            // 作成日時
                sb.AppendLine("  , UPDATEDATETIMERF");          // 更新日時
                sb.AppendLine("  , ENTERPRISECODERF");          // 企業コード
                sb.AppendLine("  , FILEHEADERGUIDRF");          // GUID
                sb.AppendLine("  , UPDEMPLOYEECODERF");         // 更新従業員コード
                sb.AppendLine("  , UPDASSEMBLYID1RF");          // 更新アセンブリID1
                sb.AppendLine("  , UPDASSEMBLYID2RF");          // 更新アセンブリID2
                sb.AppendLine("  , LOGICALDELETECODERF");       // 論理削除区分
                sb.AppendLine("  , LOGINAGENCODERF");           // ログイン担当者コード
                sb.AppendLine("  , SALESEMPDIVRF");             // 担当者区分
                sb.AppendLine("  , SALESEMPLOYEECDRF");         // 販売従業員コード
                sb.AppendLine("  , FRONTEMPDIVRF");             // 受注者区分
                sb.AppendLine("  , FRONTEMPLOYEECDRF");         // 受付従業員コード
                sb.AppendLine("  , SALESINPUTDIVRF");           // 発行者区分
                sb.AppendLine("  , SALESINPUTCODERF");          // 売上入力者コード
                sb.AppendLine("FROM");
                sb.AppendLine("  PMTDEFEMPRF ");

                sqlCommand.CommandText = sb.ToString();
                // DEL 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 --->>>>>>
                //sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmtDefEmpWork);
                // DEL 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 ---<<<<<<
                // ADD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 --->>>>>>
                string str = MakeWhereString(ref sqlCommand, ref pmtDefEmpWork);
                string delFlagSql = string.Empty;
                if (string.IsNullOrEmpty(str))
                {
                    delFlagSql = "WHERE"  + Environment.NewLine;
                    delFlagSql = "  ";
                }
                else
                {
                    sqlCommand.CommandText += str;
                    delFlagSql = "  AND ";
                }
                int logicalDeleteCode = -1;

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    delFlagSql += "LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                    logicalDeleteCode = (int)logicalMode;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    // UPD 2014/10/28 k.toyosawa 論理削除したデータが表示されない件の対応 --->>>>>>
                    delFlagSql += "LOGICALDELETECODERF <= @FINDLOGICALDELETECODE" + Environment.NewLine;
                    // UPD 2014/10/28 k.toyosawa 論理削除したデータが表示されない件の対応 ---<<<<<<
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01)
                    {
                        logicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData1;
                    }
                    if (logicalMode == ConstantManagement.LogicalMode.GetData012)
                    {
                        logicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData2;
                    }
                }

                if (logicalDeleteCode != -1)
                {
                    sqlCommand.CommandText += delFlagSql;
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalDeleteCode);
                }
                // ADD 2014/10/23 k.toyosawa ログイン担当者に0000共通を設定できない件の対応 ---<<<<<<
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    pmtDefEmpList.Add(this.CopyToRecieveSecTableWorkFromReader(ref myReader));
                }

                if (pmtDefEmpList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
        # endregion

        # region [Write]
        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="pmtDefEmpList">追加・更新するPMTAB初期表示従業員設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList に格納されているPMTAB初期表示従業員設定マスタ情報を追加・更新します。</br>
        public int Write(ref object pmtDefEmpList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = pmtDefEmpList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // write実行
                status = this.Write(ref paraList, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// PMTAB初期表示従業員設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="pmtDefEmpList">追加・更新するPMTAB初期表示従業員設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList に格納されているPMTAB初期表示従業員設定マスタ情報を追加・更新します。</br>
        public int Write(ref ArrayList pmtDefEmpList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref pmtDefEmpList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="pmtDefEmpList">追加・更新するPMTAB初期表示従業員設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList に格納されているPMTAB初期表示従業員設定マスタ情報を追加・更新します。</br>
        private int WriteProc(ref ArrayList pmtDefEmpList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pmtDefEmpList != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmtDefEmpList.Count; i++)
                    {
                        PmtDefEmpWork pmtDefEmpWork = pmtDefEmpList[i] as PmtDefEmpWork;

                        # region [SELECT文]
                        sb.AppendLine("SELECT");
                        sb.AppendLine("  CREATEDATETIMERF");            // 作成日時
                        sb.AppendLine("  , UPDATEDATETIMERF");          // 更新日時
                        sb.AppendLine("  , ENTERPRISECODERF");          // 企業コード
                        sb.AppendLine("  , FILEHEADERGUIDRF");          // GUID
                        sb.AppendLine("  , UPDEMPLOYEECODERF");         // 更新従業員コード
                        sb.AppendLine("  , UPDASSEMBLYID1RF");          // 更新アセンブリID1
                        sb.AppendLine("  , UPDASSEMBLYID2RF");          // 更新アセンブリID2
                        sb.AppendLine("  , LOGICALDELETECODERF");       // 論理削除区分
                        sb.AppendLine("  , LOGINAGENCODERF");           // ログイン担当者コード
                        sb.AppendLine("  , SALESEMPDIVRF");             // 担当者区分
                        sb.AppendLine("  , SALESEMPLOYEECDRF");         // 販売従業員コード
                        sb.AppendLine("  , FRONTEMPDIVRF");             // 受注者区分
                        sb.AppendLine("  , FRONTEMPLOYEECDRF");         // 受付従業員コード
                        sb.AppendLine("  , SALESINPUTDIVRF");           // 発行者区分
                        sb.AppendLine("  , SALESINPUTCODERF");          // 売上入力者コード
                        sb.AppendLine("FROM");
                        sb.AppendLine("  PMTDEFEMPRF ");
                        sqlCommand.Parameters.Clear();

                        sqlCommand.CommandText = sb.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmtDefEmpWork);
                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            pmtDefEmpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時

                            # region [UPDATE文]

                            sb = new StringBuilder();

                            sb.AppendLine("UPDATE PMTDEFEMPRF ");
                            sb.AppendLine("SET");
                            sb.AppendLine("  CREATEDATETIMERF = @CREATEDATETIME");
                            sb.AppendLine("  , UPDATEDATETIMERF = @UPDATEDATETIME");
                            sb.AppendLine("  , ENTERPRISECODERF = @ENTERPRISECODE");
                            sb.AppendLine("  , FILEHEADERGUIDRF = @FILEHEADERGUID");
                            sb.AppendLine("  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE");
                            sb.AppendLine("  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1");
                            sb.AppendLine("  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2");
                            sb.AppendLine("  , LOGICALDELETECODERF = @LOGICALDELETECODE");
                            sb.AppendLine("  , LOGINAGENCODERF = @LOGINAGENCODE");
                            sb.AppendLine("  , SALESEMPDIVRF = @SALESEMPDIV");
                            sb.AppendLine("  , SALESEMPLOYEECDRF = @SALESEMPLOYEECD");
                            sb.AppendLine("  , FRONTEMPDIVRF = @FRONTEMPDIV");
                            sb.AppendLine("  , FRONTEMPLOYEECDRF = @FRONTEMPLOYEECD");
                            sb.AppendLine("  , SALESINPUTDIVRF = @SALESINPUTDIV");
                            sb.AppendLine("  , SALESINPUTCODERF = @SALESINPUTCODE");

                            bool isWhere = false;
                            if (pmtDefEmpWork.EnterpriseCode != "")
                            {
                                isWhere = true;
                                sb.AppendLine("WHERE");
                                sb.AppendLine("  ENTERPRISECODERF = @UPDATEENTERPRISECODE ");

                                sqlCommand.Parameters.Clear();
                                // Prameterオブジェクトの作成
                                SqlParameter updateParaEnterpriseCode = sqlCommand.Parameters.Add("@UPDATEENTERPRISECODE", SqlDbType.NChar);
                                //Parameterオブジェクトへ値設定
                                updateParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.EnterpriseCode);
                            }


                            if (pmtDefEmpWork.LoginAgenCode != "")
                            {
                                if (isWhere)
                                {
                                    sb.AppendLine("  AND LOGINAGENCODERF = @UPDATELOGINAGENCODE ");
                                }
                                else
                                {
                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("  LOGINAGENCODERF = @UPDATELOGINAGENCODE ");
                                }
                                // Prameterオブジェクトの作成
                                SqlParameter updateParaDbIdGuid = sqlCommand.Parameters.Add("@UPDATELOGINAGENCODE", SqlDbType.NChar);
                                //Parameterオブジェクトへ値設定
                                updateParaDbIdGuid.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.LoginAgenCode);
                            }

                            #endregion

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmtDefEmpWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            sqlCommand.CommandText = sb.ToString();

                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (pmtDefEmpWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            #region INSERT文

                            sb = new StringBuilder();
                            sb.AppendLine("INSERT ");
                            sb.AppendLine("INTO PMTDEFEMPRF( ");
                            sb.AppendLine("  CREATEDATETIMERF");
                            sb.AppendLine("  , UPDATEDATETIMERF");
                            sb.AppendLine("  , ENTERPRISECODERF");
                            sb.AppendLine("  , FILEHEADERGUIDRF");
                            sb.AppendLine("  , UPDEMPLOYEECODERF");
                            sb.AppendLine("  , UPDASSEMBLYID1RF");
                            sb.AppendLine("  , UPDASSEMBLYID2RF");
                            sb.AppendLine("  , LOGICALDELETECODERF");
                            sb.AppendLine("  , LOGINAGENCODERF");
                            sb.AppendLine("  , SALESEMPDIVRF");
                            sb.AppendLine("  , SALESEMPLOYEECDRF");
                            sb.AppendLine("  , FRONTEMPDIVRF");
                            sb.AppendLine("  , FRONTEMPLOYEECDRF");
                            sb.AppendLine("  , SALESINPUTDIVRF");
                            sb.AppendLine("  , SALESINPUTCODERF");
                            sb.AppendLine(") ");
                            sb.AppendLine("VALUES ( ");
                            sb.AppendLine("  @CREATEDATETIME");
                            sb.AppendLine("  , @UPDATEDATETIME");
                            sb.AppendLine("  , @ENTERPRISECODE");
                            sb.AppendLine("  , @FILEHEADERGUID");
                            sb.AppendLine("  , @UPDEMPLOYEECODE");
                            sb.AppendLine("  , @UPDASSEMBLYID1");
                            sb.AppendLine("  , @UPDASSEMBLYID2");
                            sb.AppendLine("  , @LOGICALDELETECODE");
                            sb.AppendLine("  , @LOGINAGENCODE");
                            sb.AppendLine("  , @SALESEMPDIV");
                            sb.AppendLine("  , @SALESEMPLOYEECD");
                            sb.AppendLine("  , @FRONTEMPDIV");
                            sb.AppendLine("  , @FRONTEMPLOYEECD");
                            sb.AppendLine("  , @SALESINPUTDIV");
                            sb.AppendLine("  , @SALESINPUTCODE");
                            sb.AppendLine(") ");
                            #endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmtDefEmpWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            sqlCommand.CommandText = sb.ToString();
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        #region //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraLoginAgenCode = sqlCommand.Parameters.Add("@LOGINAGENCODE", SqlDbType.NChar);
                        SqlParameter paraSalesEmpDiv = sqlCommand.Parameters.Add("@SALESEMPDIV", SqlDbType.Int);
                        SqlParameter paraSalesEmployeeCd = sqlCommand.Parameters.Add("@SALESEMPLOYEECD", SqlDbType.NChar);
                        SqlParameter paraFrontEmpDiv = sqlCommand.Parameters.Add("@FRONTEMPDIV", SqlDbType.Int);
                        SqlParameter paraFrontEmployeeCd = sqlCommand.Parameters.Add("@FRONTEMPLOYEECD", SqlDbType.NChar);
                        SqlParameter paraSalesInputDiv = sqlCommand.Parameters.Add("@SALESINPUTDIV", SqlDbType.Int);
                        SqlParameter paraSalesInputCode = sqlCommand.Parameters.Add("@SALESINPUTCODE", SqlDbType.NChar);
                        #endregion

                        #region //Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmtDefEmpWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmtDefEmpWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pmtDefEmpWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmtDefEmpWork.LogicalDeleteCode);
                        paraLoginAgenCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.LoginAgenCode);
                        paraSalesEmpDiv.Value = SqlDataMediator.SqlSetInt32(pmtDefEmpWork.SalesEmpDiv);
                        paraSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.SalesEmployeeCd);
                        paraFrontEmpDiv.Value = SqlDataMediator.SqlSetInt32(pmtDefEmpWork.FrontEmpDiv);
                        paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.FrontEmployeeCd);
                        paraSalesInputDiv.Value = SqlDataMediator.SqlSetInt32(pmtDefEmpWork.SalesInputDiv);
                        paraSalesInputCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.SalesInputCode);
                        #endregion

                        int cnt = sqlCommand.ExecuteNonQuery();
                        al.Add(pmtDefEmpWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
                    sqlCommand.Dispose();
                }
            }

            pmtDefEmpList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="pmtDefEmpList">論理削除するPMTAB初期表示従業員設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpWork に格納されているPMTAB初期表示従業員設定マスタ情報を論理削除します。</br>
        public int LogicalDelete(ref object pmtDefEmpList)
        {
            return this.LogicalDelete(ref pmtDefEmpList, 0);
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="pmtDefEmpList">論理削除を解除するPMTAB初期表示従業員設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpWork に格納されているPMTAB初期表示従業員設定マスタ情報の論理削除を解除します。</br>
        public int RevivalLogicalDelete(ref object pmtDefEmpList)
        {
            return this.LogicalDelete(ref pmtDefEmpList, 1);
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="pmtDefEmpList">論理削除を操作するPMTAB初期表示従業員設定マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList に格納されているPMTAB初期表示従業員設定マスタ情報の論理削除を操作します。</br>
        private int LogicalDelete(ref object pmtDefEmpList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = pmtDefEmpList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();


                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, sqlConnection, sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// PMTAB初期表示従業員設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="pmtDefEmpList">論理削除を操作するPMTAB初期表示従業員設定マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sCMRcveTgtInfWork に格納されているPMTAB初期表示従業員設定マスタ情報の論理削除を操作します。</br>
        public int LogicalDelete(ref ArrayList pmtDefEmpList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref pmtDefEmpList, procMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// PMTAB初期表示従業員設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="pmtDefEmpList">論理削除を操作するPMTAB初期表示従業員設定マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList に格納されているPMTAB初期表示従業員設定マスタ情報の論理削除を操作します。</br>
        private int LogicalDeleteProc(ref ArrayList pmtDefEmpList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pmtDefEmpList != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmtDefEmpList.Count; i++)
                    {
                        PmtDefEmpWork pmtDefEmpWork = pmtDefEmpList[i] as PmtDefEmpWork;

                        # region [SELECT文]

                        sb.AppendLine("SELECT");
                        sb.AppendLine("  CREATEDATETIMERF");            // 作成日時
                        sb.AppendLine("  , UPDATEDATETIMERF");          // 更新日時
                        sb.AppendLine("  , FILEHEADERGUIDRF");          // GUID
                        sb.AppendLine("  , LOGICALDELETECODERF");       // 論理削除区分
                        sb.AppendLine("FROM");
                        sb.AppendLine("  PMTDEFEMPRF ");

                        sqlCommand.CommandText = sb.ToString();
                        sqlCommand.CommandText += MakeWhereString(ref sqlCommand, ref pmtDefEmpWork);

                        # endregion

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (updateDateTime != pmtDefEmpWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sb = new StringBuilder();

                            sb.AppendLine("UPDATE PMTDEFEMPRF  ");
                            sb.AppendLine("SET");
                            sb.AppendLine("    UPDATEDATETIMERF = @UPDATEDATETIME");
                            sb.AppendLine("  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE");
                            sb.AppendLine("  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1");
                            sb.AppendLine("  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2");
                            sb.AppendLine("  , LOGICALDELETECODERF = @LOGICALDELETECODE");

                            bool isWhere = false;
                            if (pmtDefEmpWork.EnterpriseCode != "")
                            {
                                isWhere = true;
                                sb.AppendLine("WHERE");
                                sb.AppendLine("  ENTERPRISECODERF = @UPDATEENTERPRISECODE ");

                                sqlCommand.Parameters.Clear();
                                // Prameterオブジェクトの作成
                                SqlParameter updateParaEnterpriseCode = sqlCommand.Parameters.Add("@UPDATEENTERPRISECODE", SqlDbType.NChar);
                                //Parameterオブジェクトへ値設定
                                updateParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.EnterpriseCode);
                            }


                            if (pmtDefEmpWork.LoginAgenCode != "")
                            {
                                if (isWhere)
                                {
                                    sb.AppendLine("  AND LOGINAGENCODERF = @UPDATELOGINAGENCODE ");
                                }
                                else
                                {
                                    sb.AppendLine("WHERE");
                                    sb.AppendLine("  LOGINAGENCODERF = @UPDATELOGINAGENCODE ");
                                }
                                // Prameterオブジェクトの作成
                                SqlParameter updateParaDbIdGuid = sqlCommand.Parameters.Add("@UPDATELOGINAGENCODE", SqlDbType.NChar);
                                //Parameterオブジェクトへ値設定
                                updateParaDbIdGuid.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.LoginAgenCode);
                            }
                            # endregion

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pmtDefEmpWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            sqlCommand.CommandText = sb.ToString();
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
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // 既に削除済みの場合正常
                                return status;
                            }
                            else if (logicalDelCd == 0) pmtDefEmpWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else pmtDefEmpWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                pmtDefEmpWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // 既に復活している場合はそのまま正常を戻す
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // 完全削除はデータなしを戻す
                                }

                                return status;
                            }
                        }

                        // Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmtDefEmpWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmtDefEmpWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pmtDefEmpWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
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

            pmtDefEmpList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="pmtDefEmpWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ref PmtDefEmpWork pmtDefEmpWork)
        {
            StringBuilder sb = new StringBuilder();
            bool isWhere = false;

            if (pmtDefEmpWork.EnterpriseCode != "")
            {
                isWhere = true;
                sb.AppendLine("WHERE");
                sb.AppendLine("  ENTERPRISECODERF = @FINDENTERPRISECODE ");

                sqlCommand.Parameters.Clear();
                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.EnterpriseCode);
            }

            if (pmtDefEmpWork.LoginAgenCode != "")
            {
                if (isWhere)
                {
                    sb.AppendLine("  AND LOGINAGENCODERF = @FINDLOGINAGENCODE ");
                }
                else
                {
                    sb.AppendLine("WHERE");
                    sb.AppendLine("  LOGINAGENCODERF = @FINDLOGINAGENCODE ");
                }
                // Prameterオブジェクトの作成
                SqlParameter findLoginAgenCode = sqlCommand.Parameters.Add("@FINDLOGINAGENCODE", SqlDbType.NChar);
                //Parameterオブジェクトへ値設定
                findLoginAgenCode.Value = SqlDataMediator.SqlSetString(pmtDefEmpWork.LoginAgenCode);
            }

            return sb.ToString();
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → PmtDefEmpWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PmtDefEmpWork オブジェクト</returns>
        /// <remarks>
        /// </remarks>
        private PmtDefEmpWork CopyToRecieveSecTableWorkFromReader(ref SqlDataReader myReader)
        {
            PmtDefEmpWork pmtDefEmpWork = new PmtDefEmpWork();

            this.CopyToRecieveSecTableWorkFromReader(ref myReader, ref pmtDefEmpWork);

            return pmtDefEmpWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → PmtDefEmpWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="pmtDefEmpWork">PmtDefEmpWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// </remarks>
        private void CopyToRecieveSecTableWorkFromReader(ref SqlDataReader myReader, ref PmtDefEmpWork pmtDefEmpWork)
        {
            if (myReader != null && pmtDefEmpWork != null)
            {
                # region クラスへ格納
                pmtDefEmpWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
                pmtDefEmpWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
                pmtDefEmpWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));             // 企業コード
                pmtDefEmpWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
                pmtDefEmpWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));           // 更新従業員コード
                pmtDefEmpWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));             // 更新アセンブリID1
                pmtDefEmpWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));             // 更新アセンブリID2
                pmtDefEmpWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));        // 論理削除区分
                pmtDefEmpWork.LoginAgenCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINAGENCODERF"));               // ログイン担当者コード
                pmtDefEmpWork.SalesEmpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESEMPDIVRF"));                    // 担当者区分
                pmtDefEmpWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));           // 販売従業員コード
                pmtDefEmpWork.FrontEmpDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTEMPDIVRF"));                    // 受注者区分
                pmtDefEmpWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));           // 受付従業員コード
                pmtDefEmpWork.SalesInputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESINPUTDIVRF"));                // 発行者区分
                pmtDefEmpWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));             // 売上入力者コード            }
                # endregion
            }
        }
        # endregion
    }
}
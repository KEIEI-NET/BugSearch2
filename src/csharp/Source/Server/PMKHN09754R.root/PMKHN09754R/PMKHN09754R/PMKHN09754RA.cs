//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 優先倉庫マスタ
// プログラム概要   : 優先倉庫の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : huangt
// 作 成 日  K2013/09/10  修正内容 : 新規作成
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 優先倉庫設定DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 優先倉庫設定の実データ操作を行うクラスです。</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : K2013/09/10</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ProtyWarehouseDB : RemoteWithAppLockDB, IProtyWarehouseDB
    {
        /// <summary>
        /// 優先倉庫設定DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        public ProtyWarehouseDB() : base("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork", "WAREHECHSLIPSTRF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一の優先倉庫設定情報を取得します。
        /// </summary>
        /// <param name="protyWarehouseList">検索結果</param>
        /// <param name="protyWarehouseObj">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する優先倉庫設定情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Read(ref object protyWarehouseList, object protyWarehouseObj, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList protyWarehouseArray = new ArrayList();
            ProtyWarehouseWork protyWarehouseWork = protyWarehouseObj as ProtyWarehouseWork;
            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref protyWarehouseArray, protyWarehouseWork, logicalMode, ref sqlConnection, ref sqlTransaction);
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
            protyWarehouseList = (object)protyWarehouseArray;

            return status;
        }

        /// <summary>
        /// 単一の優先倉庫設定情報を取得します。
        /// </summary>
        /// <param name="protyWarehouseList">検索結果</param>
        /// <param name="protyWarehouseWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する優先倉庫設定情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Read(ref ArrayList protyWarehouseList, ProtyWarehouseWork protyWarehouseWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref protyWarehouseList, protyWarehouseWork, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一の優先倉庫設定情報を取得します。
        /// </summary>
        /// <param name="protyWarehouseList">検索結果</param>
        /// <param name="protyWarehouseWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する優先倉庫設定情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private int ReadProc(ref ArrayList protyWarehouseList, ProtyWarehouseWork protyWarehouseWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                # region [SELECT文]

                sqlText.Append("SELECT ").AppendLine();
                sqlText.Append("PW.CREATEDATETIMERF, ").AppendLine();
                sqlText.Append("PW.UPDATEDATETIMERF, ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF, ").AppendLine();
                sqlText.Append("PW.FILEHEADERGUIDRF, ").AppendLine();
                sqlText.Append("PW.UPDEMPLOYEECODERF, ").AppendLine();
                sqlText.Append("PW.UPDASSEMBLYID1RF, ").AppendLine();
                sqlText.Append("PW.UPDASSEMBLYID2RF, ").AppendLine();
                sqlText.Append("PW.LOGICALDELETECODERF, ").AppendLine();
                sqlText.Append("PW.SECTIONCODERF, ").AppendLine();
                sqlText.Append("SEC.SECTIONGUIDENMRF, ").AppendLine();
                sqlText.Append("PW.WAREHOUSECODERF, ").AppendLine();
                sqlText.Append("WH.WAREHOUSENAMERF, ").AppendLine();
                sqlText.Append("PW.WAREHPROTYODRRF ").AppendLine();
                sqlText.Append("FROM ").AppendLine();
                sqlText.Append("PROTYWAREHOUSERF AS PW WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("LEFT JOIN ").AppendLine();
                sqlText.Append("SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("ON ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF = SEC.ENTERPRISECODERF ").AppendLine();
                sqlText.Append("AND PW.SECTIONCODERF = SEC.SECTIONCODERF ").AppendLine();
                sqlText.Append("AND SEC.LOGICALDELETECODERF = 0 ").AppendLine();
                sqlText.Append("LEFT JOIN ").AppendLine();
                sqlText.Append("WAREHOUSERF AS WH WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("ON ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF = WH.ENTERPRISECODERF ").AppendLine();
                sqlText.Append("AND PW.WAREHOUSECODERF = WH.WAREHOUSECODERF ").AppendLine();
                sqlText.Append("AND WH.LOGICALDELETECODERF = 0 ").AppendLine();

                // 検索条件文字列生成＋条件値設定
                MakeWhereString(ref sqlCommand, ref sqlText, protyWarehouseWork, logicalMode);

                sqlText.Append("ORDER BY ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF, ").AppendLine();
                sqlText.Append("PW.SECTIONCODERF, ").AppendLine();
                sqlText.Append("PW.WAREHPROTYODRRF ").AppendLine();
                
                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    protyWarehouseList.Add(this.CopyToProtyWarehouseWorkFromReader(ref myReader));
                }

                if (protyWarehouseList.Count > 0)
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

        # region [ReadWithWarehouse]
        /// <summary>
        /// 単一の優先倉庫設定情報を取得します(売伝からの指示書印刷制御の際に使用)。
        /// </summary>
        /// <param name="protyWarehouseList">検索結果</param>
        /// <param name="protyWarehouseObj">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する優先倉庫設定情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int ReadWithWarehouse(ref object protyWarehouseList, object protyWarehouseObj, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList protyWarehouseArray = new ArrayList();
            ProtyWarehouseWork protyWarehouseWork = protyWarehouseObj as ProtyWarehouseWork;
            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.ReadWithWarehouse(ref protyWarehouseArray, protyWarehouseWork, logicalMode, ref sqlConnection, ref sqlTransaction);
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
            protyWarehouseList = (object)protyWarehouseArray;

            return status;
        }

        /// <summary>
        /// 単一の優先倉庫設定情報を取得します(売伝からの指示書印刷制御の際に使用)。
        /// </summary>
        /// <param name="protyWarehouseList">検索結果</param>
        /// <param name="protyWarehouseWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する優先倉庫設定情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int ReadWithWarehouse(ref ArrayList protyWarehouseList, ProtyWarehouseWork protyWarehouseWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadWithWarehouseProc(ref protyWarehouseList, protyWarehouseWork, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一の優先倉庫設定情報を取得します(売伝からの指示書印刷制御の際に使用)。
        /// </summary>
        /// <param name="protyWarehouseList">検索結果</param>
        /// <param name="protyWarehouseWork">検索条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する優先倉庫設定情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private int ReadWithWarehouseProc(ref ArrayList protyWarehouseList, ProtyWarehouseWork protyWarehouseWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                # region [SELECT文]

                sqlText.Append("SELECT ").AppendLine();
                sqlText.Append("PW.CREATEDATETIMERF, ").AppendLine();
                sqlText.Append("PW.UPDATEDATETIMERF, ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF, ").AppendLine();
                sqlText.Append("PW.FILEHEADERGUIDRF, ").AppendLine();
                sqlText.Append("PW.UPDEMPLOYEECODERF, ").AppendLine();
                sqlText.Append("PW.UPDASSEMBLYID1RF, ").AppendLine();
                sqlText.Append("PW.UPDASSEMBLYID2RF, ").AppendLine();
                sqlText.Append("PW.LOGICALDELETECODERF, ").AppendLine();
                sqlText.Append("PW.SECTIONCODERF, ").AppendLine();
                sqlText.Append("SEC.SECTIONGUIDENMRF, ").AppendLine();
                sqlText.Append("PW.WAREHOUSECODERF, ").AppendLine();
                sqlText.Append("WH.WAREHOUSENAMERF, ").AppendLine();
                sqlText.Append("PW.WAREHPROTYODRRF ").AppendLine();
                sqlText.Append("FROM ").AppendLine();
                sqlText.Append("PROTYWAREHOUSERF AS PW WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("LEFT JOIN ").AppendLine();
                sqlText.Append("SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("ON ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF = SEC.ENTERPRISECODERF ").AppendLine();
                sqlText.Append("AND PW.SECTIONCODERF = SEC.SECTIONCODERF ").AppendLine();
                sqlText.Append("AND SEC.LOGICALDELETECODERF = 0 ").AppendLine();
                sqlText.Append("LEFT JOIN ").AppendLine();
                sqlText.Append("WAREHOUSERF AS WH WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("ON ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF = WH.ENTERPRISECODERF ").AppendLine();
                sqlText.Append("AND PW.WAREHOUSECODERF = WH.WAREHOUSECODERF ").AppendLine();
                sqlText.Append("AND WH.LOGICALDELETECODERF = 0 ").AppendLine();

                // 検索条件文字列生成＋条件値設定
                MakeWhereStringWithWarehouse(ref sqlCommand, ref sqlText, protyWarehouseWork, logicalMode);

                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    protyWarehouseList.Add(this.CopyToProtyWarehouseWorkFromReader(ref myReader));
                }

                if (protyWarehouseList.Count > 0)
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

        # region [Delete]
        /// <summary>
        /// 優先倉庫設定情報を物理削除します
        /// </summary>
        /// <param name="protyWarehouseList">物理削除する優先倉庫設定情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する優先倉庫設定情報を物理削除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Delete(object protyWarehouseList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = protyWarehouseList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, ref sqlConnection, ref sqlTransaction);
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
        /// 優先倉庫設定情報を物理削除します
        /// </summary>
        /// <param name="protyWarehouseList">優先倉庫設定情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : protyWarehouseList に格納されている優先倉庫設定情報を物理削除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Delete(ArrayList protyWarehouseList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(protyWarehouseList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 優先倉庫設定情報を物理削除します
        /// </summary>
        /// <param name="protyWarehouseList">優先倉庫設定情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : protyWarehouseList に格納されている優先倉庫設定情報を物理削除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private int DeleteProc(ArrayList protyWarehouseList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (protyWarehouseList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    #region [排他用]
                    ProtyWarehouseWork protyWarehouseWorkTemp = protyWarehouseList[0] as ProtyWarehouseWork;

                    sqlText.Remove(0, sqlText.Length);
                    sqlText.Append("SELECT ").AppendLine();
                    sqlText.Append("MAX(UPDATEDATETIMERF) AS UPDATEDATETIMERF").AppendLine();
                    sqlText.Append("FROM ").AppendLine();
                    sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                    sqlText.Append("WHERE ").AppendLine();
                    sqlText.Append("ENTERPRISECODERF = @CONDENTERPRISECODE ").AppendLine();
                    sqlText.Append("AND SECTIONCODERF = @CONDSECTIONCODE ").AppendLine();
                    sqlCommand.CommandText = sqlText.ToString();

                    // Prameterオブジェクトの作成
                    sqlCommand.Parameters.Clear();
                    SqlParameter condEnterpriseCode = sqlCommand.Parameters.Add("@CONDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter condSectionCode = sqlCommand.Parameters.Add("@CONDSECTIONCODE", SqlDbType.NChar);

                    // Parameterオブジェクトへ値設定
                    condEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWorkTemp.EnterpriseCode);
                    condSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWorkTemp.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _maxUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時
                        if (_maxUpdateDateTime != protyWarehouseWorkTemp.MaxUpdateDateTime)
                        {
                            if (protyWarehouseWorkTemp.MaxUpdateDateTime != DateTime.MinValue)
                            {
                                // 既存データで更新日時違いの場合には排他
                                return (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }
                        }
                    }

                    #endregion

                    for (int i = 0; i < protyWarehouseList.Count; i++)
                    {
                        ProtyWarehouseWork protyWarehouseWork = protyWarehouseList[i] as ProtyWarehouseWork;

                        # region [SELECT文]

                        sqlText.Remove(0, sqlText.Length);
                        sqlText.Append("SELECT ").AppendLine();
                        sqlText.Append("UPDATEDATETIMERF ").AppendLine();
                        sqlText.Append("FROM ").AppendLine();
                        sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                        sqlText.Append("WHERE ").AppendLine();
                        sqlText.Append("ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
                        sqlText.Append("AND SECTIONCODERF = @FINDSECTIONCODE ").AppendLine();
                        sqlText.Append("AND WAREHOUSECODERF = @FINDWAREHOUSECODE ").AppendLine();

                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
                        findWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != protyWarehouseWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText.Remove(0, sqlText.Length);
                            sqlText.Append("DELETE ").AppendLine();
                            sqlText.Append("FROM ").AppendLine();
                            sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                            sqlText.Append("WHERE ").AppendLine();
                            sqlText.Append("ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
                            sqlText.Append("AND SECTIONCODERF = @FINDSECTIONCODE ").AppendLine();
                            sqlText.Append("AND WAREHOUSECODERF = @FINDWAREHOUSECODE ").AppendLine();

                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);
                            findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
                            findWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);
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
        /// 優先倉庫設定情報のリストを取得します。
        /// </summary>
        /// <param name="protyWarehouseList">検索結果</param>
        /// <param name="protyWarehouseObj">検索条件</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する、全ての優先倉庫設定情報を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Search(ref object protyWarehouseList, object protyWarehouseObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;


            ArrayList protyWarehouseArray = new ArrayList();
            ProtyWarehouseWork protyWarehouseWork = protyWarehouseObj as ProtyWarehouseWork;
            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref protyWarehouseArray, protyWarehouseWork, ref sqlConnection, ref sqlTransaction);
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
            protyWarehouseList = (object)protyWarehouseArray;

            return status;
        }

        /// <summary>
        /// 優先倉庫設定情報のリストを取得します。
        /// </summary>
        /// <param name="protyWarehouseList">優先倉庫設定情報を格納する ArrayList</param>
        /// <param name="protyWarehouseWork">検索条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する、全ての優先倉庫設定情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Search(ref ArrayList protyWarehouseList, ProtyWarehouseWork protyWarehouseWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref protyWarehouseList, protyWarehouseWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 優先倉庫設定情報のリストを取得します。
        /// </summary>
        /// <param name="protyWarehouseList">優先倉庫設定情報を格納する ArrayList</param>
        /// <param name="protyWarehouseWork">検索条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 優先倉庫設定のキー値が一致する、全ての優先倉庫設定情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private int SearchProc(ref ArrayList protyWarehouseList, ProtyWarehouseWork protyWarehouseWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                # region [SELECT文]

                sqlText.Append("SELECT ").AppendLine();
                sqlText.Append("PW.CREATEDATETIMERF, ").AppendLine();
                sqlText.Append("PW.UPDATEDATETIMERF, ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF, ").AppendLine();
                sqlText.Append("PW.FILEHEADERGUIDRF, ").AppendLine();
                sqlText.Append("PW.UPDEMPLOYEECODERF, ").AppendLine();
                sqlText.Append("PW.UPDASSEMBLYID1RF, ").AppendLine();
                sqlText.Append("PW.UPDASSEMBLYID2RF, ").AppendLine();
                sqlText.Append("PW.LOGICALDELETECODERF, ").AppendLine();
                sqlText.Append("PW.SECTIONCODERF, ").AppendLine();
                sqlText.Append("SEC.SECTIONGUIDENMRF, ").AppendLine();
                sqlText.Append("PW.WAREHOUSECODERF, ").AppendLine();
                sqlText.Append("WH.WAREHOUSENAMERF, ").AppendLine();
                sqlText.Append("PW.WAREHPROTYODRRF ").AppendLine();
                sqlText.Append("FROM ").AppendLine();
                sqlText.Append("PROTYWAREHOUSERF AS PW WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("LEFT JOIN ").AppendLine();
                sqlText.Append("SECINFOSETRF AS SEC WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("ON ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF = SEC.ENTERPRISECODERF ").AppendLine();
                sqlText.Append("AND PW.SECTIONCODERF = SEC.SECTIONCODERF ").AppendLine();
                sqlText.Append("AND SEC.LOGICALDELETECODERF = 0 ").AppendLine();
                sqlText.Append("LEFT JOIN ").AppendLine();
                sqlText.Append("WAREHOUSERF AS WH WITH (READUNCOMMITTED) ").AppendLine();
                sqlText.Append("ON ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF = WH.ENTERPRISECODERF ").AppendLine();
                sqlText.Append("AND PW.WAREHOUSECODERF = WH.WAREHOUSECODERF ").AppendLine();
                sqlText.Append("AND WH.LOGICALDELETECODERF = 0 ").AppendLine();
                sqlText.Append("WHERE ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
                sqlText.Append("ORDER BY ").AppendLine();
                sqlText.Append("PW.ENTERPRISECODERF, ").AppendLine();
                sqlText.Append("PW.SECTIONCODERF, ").AppendLine();
                sqlText.Append("PW.WAREHPROTYODRRF ").AppendLine();

                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                // Parameterオブジェクトへ値設定
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    protyWarehouseList.Add(this.CopyToProtyWarehouseWorkFromReader(ref myReader));
                }

                if (protyWarehouseList.Count > 0)
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
        /// 優先倉庫設定情報を追加・更新します。
        /// </summary>
        /// <param name="protyWarehouseList">追加・更新する優先倉庫設定情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : protyWarehouseList に格納されている優先倉庫設定情報を追加・更新します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Write(ref object protyWarehouseList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = protyWarehouseList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);
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
        /// 優先倉庫設定情報を追加・更新します。
        /// </summary>
        /// <param name="protyWarehouseList">追加・更新する優先倉庫設定情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : protyWarehouseList に格納されている優先倉庫設定情報を追加・更新します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int Write(ref ArrayList protyWarehouseList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref protyWarehouseList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 優先倉庫設定情報を追加・更新します。
        /// </summary>
        /// <param name="protyWarehouseList">追加・更新する優先倉庫設定情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : protyWarehouseList に格納されている優先倉庫設定情報を追加・更新します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private int WriteProc(ref ArrayList protyWarehouseList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (protyWarehouseList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    # region 排他用
                    ProtyWarehouseWork protyWarehouseWorkTemp = protyWarehouseList[0] as ProtyWarehouseWork;

                    sqlText.Remove(0, sqlText.Length);
                    sqlText.Append("SELECT ").AppendLine();
                    sqlText.Append("MAX(UPDATEDATETIMERF) AS UPDATEDATETIMERF").AppendLine();
                    sqlText.Append("FROM ").AppendLine();
                    sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                    sqlText.Append("WHERE ").AppendLine();
                    sqlText.Append("ENTERPRISECODERF = @CONDENTERPRISECODE ").AppendLine();
                    sqlText.Append("AND SECTIONCODERF = @CONDSECTIONCODE ").AppendLine();
                    sqlCommand.CommandText = sqlText.ToString();

                    // Prameterオブジェクトの作成
                    sqlCommand.Parameters.Clear();
                    SqlParameter condEnterpriseCode = sqlCommand.Parameters.Add("@CONDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter condSectionCode = sqlCommand.Parameters.Add("@CONDSECTIONCODE", SqlDbType.NChar);

                    // Parameterオブジェクトへ値設定
                    condEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWorkTemp.EnterpriseCode);
                    condSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWorkTemp.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _maxUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時
                        if (_maxUpdateDateTime != protyWarehouseWorkTemp.MaxUpdateDateTime)
                        {
                            if (protyWarehouseWorkTemp.MaxUpdateDateTime == DateTime.MinValue)
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
                    }

                    # endregion

                    for (int i = 0; i < protyWarehouseList.Count; i++)
                    {
                        ProtyWarehouseWork protyWarehouseWork = protyWarehouseList[i] as ProtyWarehouseWork;

                        # region [SELECT文]

                        sqlText.Remove(0, sqlText.Length);
                        sqlText.Append("SELECT ").AppendLine();
                        sqlText.Append("CREATEDATETIMERF, ").AppendLine();
                        sqlText.Append("UPDATEDATETIMERF ").AppendLine();
                        sqlText.Append("FROM ").AppendLine();
                        sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                        sqlText.Append("WHERE ").AppendLine();
                        sqlText.Append("ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
                        sqlText.Append("AND SECTIONCODERF = @FINDSECTIONCODE ").AppendLine();
                        sqlText.Append("AND WAREHOUSECODERF = @FINDWAREHOUSECODE ").AppendLine();

                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
                        findWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ヘッダ情報の作成日時を取得
                            DateTime _createDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));// 作成日時

                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != protyWarehouseWork.UpdateDateTime)
                            {
                                if (protyWarehouseWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText.Remove(0, sqlText.Length);
                            sqlText.Append("UPDATE ").AppendLine();
                            sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                            sqlText.Append("SET ").AppendLine();
                            sqlText.Append("CREATEDATETIMERF = @CREATEDATETIME, ").AppendLine();
                            sqlText.Append("UPDATEDATETIMERF = @UPDATEDATETIME, ").AppendLine();
                            sqlText.Append("ENTERPRISECODERF = @ENTERPRISECODE, ").AppendLine();
                            sqlText.Append("FILEHEADERGUIDRF = @FILEHEADERGUID, ").AppendLine();
                            sqlText.Append("UPDEMPLOYEECODERF = @UPDEMPLOYEECODE, ").AppendLine();
                            sqlText.Append("UPDASSEMBLYID1RF = @UPDASSEMBLYID1, ").AppendLine();
                            sqlText.Append("UPDASSEMBLYID2RF = @UPDASSEMBLYID2, ").AppendLine();
                            sqlText.Append("LOGICALDELETECODERF = @LOGICALDELETECODE, ").AppendLine();
                            sqlText.Append("SECTIONCODERF = @SECTIONCODE, ").AppendLine();
                            sqlText.Append("WAREHOUSECODERF = @WAREHOUSECODE, ").AppendLine();
                            sqlText.Append("WAREHPROTYODRRF = @WAREHPROTYODR ").AppendLine();
                            sqlText.Append("WHERE ").AppendLine();
                            sqlText.Append("ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
                            sqlText.Append("AND SECTIONCODERF = @FINDSECTIONCODE ").AppendLine();
                            sqlText.Append("AND WAREHOUSECODERF = @FINDWAREHOUSECODE ").AppendLine();
                            
                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);
                            findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
                            findWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)protyWarehouseWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                            protyWarehouseWork.CreateDateTime = _createDateTime;
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (protyWarehouseWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText.Remove(0, sqlText.Length);
                            sqlText.Append("INSERT INTO ").AppendLine();
                            sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                            sqlText.Append("(").AppendLine();
                            sqlText.Append("CREATEDATETIMERF, ").AppendLine();
                            sqlText.Append("UPDATEDATETIMERF, ").AppendLine();
                            sqlText.Append("ENTERPRISECODERF, ").AppendLine();
                            sqlText.Append("FILEHEADERGUIDRF, ").AppendLine();
                            sqlText.Append("UPDEMPLOYEECODERF, ").AppendLine();
                            sqlText.Append("UPDASSEMBLYID1RF, ").AppendLine();
                            sqlText.Append("UPDASSEMBLYID2RF, ").AppendLine();
                            sqlText.Append("LOGICALDELETECODERF, ").AppendLine();
                            sqlText.Append("SECTIONCODERF, ").AppendLine();
                            sqlText.Append("WAREHOUSECODERF, ").AppendLine();
                            sqlText.Append("WAREHPROTYODRRF ").AppendLine();
                            sqlText.Append(") ").AppendLine();
                            sqlText.Append("VALUES ").AppendLine();
                            sqlText.Append("(").AppendLine();
                            sqlText.Append("@CREATEDATETIME, ").AppendLine();
                            sqlText.Append("@UPDATEDATETIME, ").AppendLine();
                            sqlText.Append("@ENTERPRISECODE, ").AppendLine();
                            sqlText.Append("@FILEHEADERGUID, ").AppendLine();
                            sqlText.Append("@UPDEMPLOYEECODE, ").AppendLine();
                            sqlText.Append("@UPDASSEMBLYID1, ").AppendLine();
                            sqlText.Append("@UPDASSEMBLYID2, ").AppendLine();
                            sqlText.Append("@LOGICALDELETECODE, ").AppendLine();
                            sqlText.Append("@SECTIONCODE, ").AppendLine();
                            sqlText.Append("@WAREHOUSECODE, ").AppendLine();
                            sqlText.Append("@WAREHPROTYODR ").AppendLine();
                            sqlText.Append(")").AppendLine();

                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)protyWarehouseWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraWarehProtyOdr = sqlCommand.Parameters.Add("@WAREHPROTYODR", SqlDbType.Int);

                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(protyWarehouseWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(protyWarehouseWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(protyWarehouseWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(protyWarehouseWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);
                        paraWarehProtyOdr.Value = SqlDataMediator.SqlSetInt32(protyWarehouseWork.WarehProtyOdr);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(protyWarehouseWork);
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
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            protyWarehouseList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// 優先倉庫設定情報を論理削除します。
        /// </summary>
        /// <param name="protyWarehouseList">論理削除する優先倉庫設定情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ProtyWarehouseWork に格納されている優先倉庫設定情報を論理削除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int LogicalDelete(ref object protyWarehouseList)
        {
            return this.LogicalDelete(ref protyWarehouseList, 0);
        }

        /// <summary>
        /// 優先倉庫設定情報の論理削除を解除します。
        /// </summary>
        /// <param name="protyWarehouseList">論理削除を解除する優先倉庫設定情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ProtyWarehouseWork に格納されている優先倉庫設定情報の論理削除を解除します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int RevivalLogicalDelete(ref object protyWarehouseList)
        {
            return this.LogicalDelete(ref protyWarehouseList, 1);
        }

        /// <summary>
        /// 優先倉庫設定情報の論理削除を操作します。
        /// </summary>
        /// <param name="protyWarehouseList">論理削除を操作する優先倉庫設定情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ProtyWarehouseWork に格納されている優先倉庫設定情報の論理削除を操作します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private int LogicalDelete(ref object protyWarehouseList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = protyWarehouseList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
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
        /// 優先倉庫設定情報の論理削除を操作します。
        /// </summary>
        /// <param name="protyWarehouseList">論理削除を操作する優先倉庫設定情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ProtyWarehouseWork に格納されている優先倉庫設定情報の論理削除を操作します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        public int LogicalDelete(ref ArrayList protyWarehouseList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref protyWarehouseList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 優先倉庫設定情報の論理削除を操作します。
        /// </summary>
        /// <param name="protyWarehouseList">論理削除を操作する優先倉庫設定情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ProtyWarehouseWork に格納されている優先倉庫設定情報の論理削除を操作します。</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private int LogicalDeleteProc(ref ArrayList protyWarehouseList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (protyWarehouseList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < protyWarehouseList.Count; i++)
                    {
                        ProtyWarehouseWork protyWarehouseWork = protyWarehouseList[i] as ProtyWarehouseWork;

                        # region [SELECT文]
                        sqlText.Remove(0, sqlText.Length);
                        sqlText.Append("SELECT ").AppendLine();
                        sqlText.Append("UPDATEDATETIMERF, ").AppendLine();
                        sqlText.Append("LOGICALDELETECODERF ").AppendLine();
                        sqlText.Append("FROM ").AppendLine();
                        sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                        sqlText.Append("WHERE ").AppendLine();
                        sqlText.Append("ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
                        sqlText.Append("AND SECTIONCODERF = @FINDSECTIONCODE ").AppendLine();
                        sqlText.Append("AND WAREHOUSECODERF = @FINDWAREHOUSECODE ").AppendLine();
                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
                        findWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != protyWarehouseWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText.Remove(0, sqlText.Length);
                            sqlText.Append("UPDATE ").AppendLine();
                            sqlText.Append("PROTYWAREHOUSERF ").AppendLine();
                            sqlText.Append("SET ").AppendLine();
                            sqlText.Append("UPDATEDATETIMERF = @UPDATEDATETIME, ").AppendLine();
                            sqlText.Append("UPDEMPLOYEECODERF = @UPDEMPLOYEECODE, ").AppendLine();
                            sqlText.Append("UPDASSEMBLYID1RF = @UPDASSEMBLYID1, ").AppendLine();
                            sqlText.Append("UPDASSEMBLYID2RF = @UPDASSEMBLYID2, ").AppendLine();
                            sqlText.Append("LOGICALDELETECODERF = @LOGICALDELETECODE ").AppendLine();
                            sqlText.Append("WHERE ").AppendLine();
                            sqlText.Append("ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
                            sqlText.Append("AND SECTIONCODERF = @FINDSECTIONCODE ").AppendLine();
                            sqlText.Append("AND WAREHOUSECODERF = @FINDWAREHOUSECODE ").AppendLine();

                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);
                            findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
                            findWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)protyWarehouseWork;
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
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // 既に削除済みの場合正常
                                return status;
                            }
                            else if (logicalDelCd == 0) protyWarehouseWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else protyWarehouseWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                protyWarehouseWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(protyWarehouseWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(protyWarehouseWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(protyWarehouseWork);
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

            protyWarehouseList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="sqlText">SQL文</param>
        /// <param name="protyWarehouseWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private void MakeWhereString(ref SqlCommand sqlCommand, ref StringBuilder sqlText, ProtyWarehouseWork protyWarehouseWork, ConstantManagement.LogicalMode logicalMode)
        {
            string tempString = string.Empty;
            sqlText.Append("WHERE ").AppendLine();

            // 企業コード
            sqlText.Append("PW.ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                tempString = "AND PW.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                tempString = "AND PW.LOGICALDELETECODERF < @FINDLOGICALDELETECODE ";
            }
            if (!string.IsNullOrEmpty(tempString))
            {
                sqlText.Append(tempString).AppendLine();
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // 拠点コード
            if (!string.IsNullOrEmpty(protyWarehouseWork.SectionCode))
            {
                sqlText.Append("AND PW.SECTIONCODERF = @FINDSECTIONCODERF ").AppendLine();
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
            }
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定(売伝からの指示書印刷制御の際に使用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="sqlText">SQL文</param>
        /// <param name="protyWarehouseWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        private void MakeWhereStringWithWarehouse(ref SqlCommand sqlCommand, ref StringBuilder sqlText, ProtyWarehouseWork protyWarehouseWork, ConstantManagement.LogicalMode logicalMode)
        {
            string tempString = string.Empty;
            sqlText.Append("WHERE ").AppendLine();

            // 企業コード
            sqlText.Append("PW.ENTERPRISECODERF = @FINDENTERPRISECODE ").AppendLine();
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                tempString = "AND PW.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                tempString = "AND PW.LOGICALDELETECODERF < @FINDLOGICALDELETECODE ";
            }
            if (!string.IsNullOrEmpty(tempString))
            {
                sqlText.Append(tempString).AppendLine();
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // 拠点コード
            if (!string.IsNullOrEmpty(protyWarehouseWork.SectionCode))
            {
                sqlText.Append("AND PW.SECTIONCODERF = @FINDSECTIONCODE ").AppendLine();
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.SectionCode);
            }

            // 倉庫コード
            if (!string.IsNullOrEmpty(protyWarehouseWork.WarehouseCode))
            {
                sqlText.Append("AND PW.WAREHOUSECODERF = @FINDWAREHOUSECODE ").AppendLine();
                SqlParameter findWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                findWarehouseCode.Value = SqlDataMediator.SqlSetString(protyWarehouseWork.WarehouseCode);
            }
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → ProtyWarehouseWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ProtyWarehouseWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private ProtyWarehouseWork CopyToProtyWarehouseWorkFromReader(ref SqlDataReader myReader)
        {
            ProtyWarehouseWork protyWarehouseWork = new ProtyWarehouseWork();

            this.CopyToProtyWarehouseWorkFromReader(ref myReader, ref protyWarehouseWork);

            return protyWarehouseWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → ProtyWarehouseWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="protyWarehouseWork">ProtyWarehouseWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        /// </remarks>
        private void CopyToProtyWarehouseWorkFromReader(ref SqlDataReader myReader, ref ProtyWarehouseWork protyWarehouseWork)
        {
            if (myReader != null && protyWarehouseWork != null)
            {
                # region クラスへ格納
                protyWarehouseWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                protyWarehouseWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                protyWarehouseWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                protyWarehouseWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                protyWarehouseWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                protyWarehouseWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                protyWarehouseWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                protyWarehouseWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                protyWarehouseWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                protyWarehouseWork.SectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                protyWarehouseWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                protyWarehouseWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                protyWarehouseWork.WarehProtyOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAREHPROTYODRRF"));
                # endregion
            }
        }
        # endregion
    }
}

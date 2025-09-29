//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   車種名称マスタDBリモートオブジェクト
//                  :   PMKHN09034R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008　長内 数馬
// Date             :   2008.06.10
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 車種名称マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車種名称マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class ModelNameUDB : RemoteWithAppLockDB, IModelNameUDB, IGetSyncdataList
    {
        /// <summary>
        /// 車種名称マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        public ModelNameUDB() : base("PMKHN09036D", "Broadleaf.Application.Remoting.ParamData.ModelNameUWork", "MODELNAMEURF")
        {

        }

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }
        
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のBLコードマスタLISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "*" + Environment.NewLine;
                sqlTxt += " FROM MODELNAMEURF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToModelNameUWorkFromReader(ref myReader));

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
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [シンク用Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion


        # region [Read]
        /// <summary>
        /// 単一の車種名称マスタ情報を取得します。
        /// </summary>
        /// <param name="modelNameUObj">ModelNameUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車種名称マスタのキー値が一致する車種名称マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Read(ref object modelNameUObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ModelNameUWork modelNameUWork = modelNameUObj as ModelNameUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref modelNameUWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一の車種名称マスタ情報を取得します。
        /// </summary>
        /// <param name="modelNameUWork">ModelNameUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車種名称マスタのキー値が一致する車種名称マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Read(ref ModelNameUWork modelNameUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref modelNameUWork, readMode, ref sqlConnection, ref sqlTransaction);
        }
        
        /// <summary>
        /// 単一の車種名称マスタ情報を取得します。
        /// </summary>
        /// <param name="modelNameUWork">ModelNameUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車種名称マスタのキー値が一致する車種名称マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int ReadProc(ref ModelNameUWork modelNameUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  *" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  MODELNAMEURF" + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MODELUNIQUECODERF=@FINDMODELUNIQUECODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaModelUniqueCode = sqlCommand.Parameters.Add("@FINDMODELUNIQUECODE", SqlDbType.Int);


                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);
                
                //ユニークコード設定
                GetModelUniqueCode(ref modelNameUWork);
                findParaModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);


#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToModelNameUWorkFromReader(ref myReader, ref modelNameUWork);
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
        /// 車種名称マスタ情報を物理削除します
        /// </summary>
        /// <param name="modelNameUList">物理削除する車種名称マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車種名称マスタのキー値が一致する車種名称マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Delete(object modelNameUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = modelNameUList as ArrayList;

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
        /// 車種名称マスタ情報を物理削除します
        /// </summary>
        /// <param name="modelNameUList">車種名称マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUList に格納されている車種名称マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Delete(ArrayList modelNameUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(modelNameUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 車種名称マスタ情報を物理削除します
        /// </summary>
        /// <param name="modelNameUList">車種名称マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUList に格納されている車種名称マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int DeleteProc(ArrayList modelNameUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (modelNameUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < modelNameUList.Count; i++)
                    {
                        ModelNameUWork modelNameUWork = modelNameUList[i] as ModelNameUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  MODELNAMEURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MODELUNIQUECODERF=@FINDMODELUNIQUECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaModelUniqueCode = sqlCommand.Parameters.Add("@FINDMODELUNIQUECODE", SqlDbType.Int);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);

                        //ユニークコード設定
                        GetModelUniqueCode(ref modelNameUWork);
                        findParaModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != modelNameUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  MODELNAMEURF" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MODELUNIQUECODERF=@FINDMODELUNIQUECODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);
                            findParaModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);

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
        /// 車種名称マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="modelNameUList">検索結果</param>
        /// <param name="modelNameUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車種名称マスタのキー値が一致する、全ての車種名称マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Search(ref object modelNameUList, object modelNameUObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

      
            try
            {
                ArrayList modelNameUArray = modelNameUList as ArrayList;
                ModelNameUWork modelNameUWork = modelNameUObj as ModelNameUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref modelNameUArray, modelNameUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// 車種名称マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="modelNameUList">車種名称マスタ情報を格納する ArrayList</param>
        /// <param name="modelNameUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車種名称マスタのキー値が一致する、全ての車種名称マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Search(ref ArrayList modelNameUList, ModelNameUWork modelNameUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref modelNameUList, modelNameUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 車種名称マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="modelNameUList">車種名称マスタ情報を格納する ArrayList</param>
        /// <param name="modelNameUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車種名称マスタのキー値が一致する、全ての車種名称マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int SearchProc(ref ArrayList modelNameUList, ModelNameUWork modelNameUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  *" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  MODELNAMEURF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, modelNameUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    modelNameUList.Add(this.CopyToModelNameUWorkFromReader(ref myReader));
                }

                if (modelNameUList.Count > 0)
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
        /// 車種名称マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="modelNameUList">追加・更新する車種名称マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUList に格納されている車種名称マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Write(ref object modelNameUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = modelNameUList as ArrayList;

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
        /// 車種名称マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="modelNameUList">追加・更新する車種名称マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUList に格納されている車種名称マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Write(ref ArrayList modelNameUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref modelNameUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 車種名称マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="modelNameUList">追加・更新する車種名称マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUList に格納されている車種名称マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int WriteProc(ref ArrayList modelNameUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (modelNameUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < modelNameUList.Count; i++)
                    {
                        ModelNameUWork modelNameUWork = modelNameUList[i] as ModelNameUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  MODELNAMEURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MODELUNIQUECODERF=@FINDMODELUNIQUECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaModelUniqueCode = sqlCommand.Parameters.Add("@FINDMODELUNIQUECODE", SqlDbType.Int);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);

                        GetModelUniqueCode(ref modelNameUWork);
                        findParaModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != modelNameUWork.UpdateDateTime)
                            {
                                if (modelNameUWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText = string.Empty;
                            sqlText = "UPDATE MODELNAMEURF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , MODELUNIQUECODERF=@MODELUNIQUECODE , MAKERCODERF=@MAKERCODE , MODELCODERF=@MODELCODE , MODELSUBCODERF=@MODELSUBCODE , MODELFULLNAMERF=@MODELFULLNAME , MODELHALFNAMERF=@MODELHALFNAME , MODELALIASNAMERF=@MODELALIASNAME , OFFERDATERF=@OFFERDATE , OFFERDATADIVRF=@OFFERDATADIV WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MODELUNIQUECODERF=@FINDMODELUNIQUECODE";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);
                            findParaModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)modelNameUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (modelNameUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO MODELNAMEURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, MODELUNIQUECODERF, MAKERCODERF, MODELCODERF, MODELSUBCODERF, MODELFULLNAMERF, MODELHALFNAMERF, MODELALIASNAMERF, OFFERDATERF, OFFERDATADIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @MODELUNIQUECODE, @MAKERCODE, @MODELCODE, @MODELSUBCODE, @MODELFULLNAME, @MODELHALFNAME, @MODELALIASNAME, @OFFERDATE, @OFFERDATADIV)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;

                            IFileHeader flhd = (IFileHeader)modelNameUWork;
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
                        SqlParameter paraModelUniqueCode = sqlCommand.Parameters.Add("@MODELUNIQUECODE", SqlDbType.Int);
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                        SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);
                        SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);
                        SqlParameter paraModelFullName = sqlCommand.Parameters.Add("@MODELFULLNAME", SqlDbType.NVarChar);
                        SqlParameter paraModelHalfName = sqlCommand.Parameters.Add("@MODELHALFNAME", SqlDbType.NVarChar);
                        SqlParameter paraModelAliasName = sqlCommand.Parameters.Add("@MODELALIASNAME", SqlDbType.NVarChar);
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.BigInt);
                        SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);

                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(modelNameUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(modelNameUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(modelNameUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(modelNameUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(modelNameUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.LogicalDeleteCode);
                        paraModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.MakerCode);
                        paraModelCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelCode);
                        paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelSubCode);
                        paraModelFullName.Value = SqlDataMediator.SqlSetString(modelNameUWork.ModelFullName);
                        paraModelHalfName.Value = SqlDataMediator.SqlSetString(modelNameUWork.ModelHalfName);
                        paraModelAliasName.Value = SqlDataMediator.SqlSetString(modelNameUWork.ModelAliasName);
                        paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(modelNameUWork.OfferDate);
                        paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.OfferDataDiv);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(modelNameUWork);
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

            modelNameUList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// 車種名称マスタ情報を論理削除します。
        /// </summary>
        /// <param name="modelNameUList">論理削除する車種名称マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUWork に格納されている車種名称マスタ情報を論理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int LogicalDelete(ref object modelNameUList)
        {
            return this.LogicalDelete(ref modelNameUList, 0);
        }

        /// <summary>
        /// 車種名称マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="modelNameUList">論理削除を解除する車種名称マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUWork に格納されている車種名称マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int RevivalLogicalDelete(ref object modelNameUList)
        {
            return this.LogicalDelete(ref modelNameUList, 1);
        }

        /// <summary>
        /// 車種名称マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="modelNameUList">論理削除を操作する車種名称マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUWork に格納されている車種名称マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int LogicalDelete(ref object modelNameUList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = modelNameUList as ArrayList;

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
        /// 車種名称マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="modelNameUList">論理削除を操作する車種名称マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUWork に格納されている車種名称マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int LogicalDelete(ref ArrayList modelNameUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref modelNameUList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 車種名称マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="modelNameUList">論理削除を操作する車種名称マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUWork に格納されている車種名称マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int LogicalDeleteProc(ref ArrayList modelNameUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (modelNameUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < modelNameUList.Count; i++)
                    {
                        ModelNameUWork modelNameUWork = modelNameUList[i] as ModelNameUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  MODELNAMEURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MODELUNIQUECODERF=@FINDMODELUNIQUECODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaModelUniqueCode = sqlCommand.Parameters.Add("@FINDMODELUNIQUECODE", SqlDbType.Int);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);

                        GetModelUniqueCode(ref modelNameUWork);
                        findParaModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != modelNameUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  MODELNAMEURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MODELUNIQUECODERF=@FINDMODELUNIQUECODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);
                            findParaModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)modelNameUWork;
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
                            else if (logicalDelCd == 0) modelNameUWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else modelNameUWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                modelNameUWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(modelNameUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(modelNameUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(modelNameUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(modelNameUWork);
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

            modelNameUList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="modelNameUWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ModelNameUWork modelNameUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(modelNameUWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //車種コード
            int stunique,edunique = 0;

            GetModelUniqueCode(ref modelNameUWork);
            
            if (modelNameUWork.MakerCode != 0)
            {
                if (modelNameUWork.ModelSubCode == 0)
                {
                    retstring += "  AND MODELUNIQUECODERF >= @STMODELUNIQUECODE" + Environment.NewLine;
                    retstring += "  AND MODELUNIQUECODERF <= @EDMODELUNIQUECODE" + Environment.NewLine;

                    if (modelNameUWork.ModelCode == 0)
                    {
                        //メーカーコードのみの指定
                        stunique = modelNameUWork.MakerCode * 1000000;
                        edunique = stunique + 999999;
                    }
                    else 
                    {   
                        //メーカーコード＆モデルコードの指定
                        stunique = modelNameUWork.MakerCode * 1000000 + modelNameUWork.ModelCode * 1000;
                        edunique = stunique + 999;
                    }

                    SqlParameter findStModelUniqueCode = sqlCommand.Parameters.Add("@STMODELUNIQUECODE", SqlDbType.Int);
                    SqlParameter findEdModelUniqueCode = sqlCommand.Parameters.Add("@EDMODELUNIQUECODE", SqlDbType.Int);

                    findStModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(stunique);
                    findEdModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(edunique);

                }
                else
                {
                    //メーカーコード＆モデルコード＆サブコードの指定
                    retstring += "  AND MODELUNIQUECODERF = @FINDMODELUNIQUECODE" + Environment.NewLine;
                    SqlParameter findModelUniqueCode = sqlCommand.Parameters.Add("@FINDMODELUNIQUECODE", SqlDbType.Int);
                    findModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameUWork.ModelUniqueCode);
                }
            }
            
            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → ModelNameUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ModelNameUWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        private ModelNameUWork CopyToModelNameUWorkFromReader(ref SqlDataReader myReader)
        {
            ModelNameUWork modelNameUWork = new ModelNameUWork();

            this.CopyToModelNameUWorkFromReader(ref myReader, ref modelNameUWork);

            return modelNameUWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → ModelNameUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="modelNameUWork">ModelNameUWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        private void CopyToModelNameUWorkFromReader(ref SqlDataReader myReader, ref ModelNameUWork modelNameUWork)
        {
            if (myReader != null && modelNameUWork != null)
            {
                # region クラスへ格納
                modelNameUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                modelNameUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                modelNameUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                modelNameUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                modelNameUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                modelNameUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                modelNameUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                modelNameUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                modelNameUWork.ModelUniqueCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MODELUNIQUECODERF"));
                modelNameUWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MAKERCODERF"));
                modelNameUWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MODELCODERF"));
                modelNameUWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MODELSUBCODERF"));
                modelNameUWork.ModelFullName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MODELFULLNAMERF"));
                modelNameUWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MODELHALFNAMERF"));
                modelNameUWork.ModelAliasName = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("MODELALIASNAMERF"));
                modelNameUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                modelNameUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));

                # endregion
            }
        }
        # endregion

        # region [ユニークコード設定処理]
        private void GetModelUniqueCode(ref ModelNameUWork modelNameUWork)
        {
            modelNameUWork.ModelUniqueCode = modelNameUWork.MakerCode * 1000000
                                             + modelNameUWork.ModelCode * 1000
                                             + modelNameUWork.ModelSubCode;
        }
        
        # endregion
    }
}

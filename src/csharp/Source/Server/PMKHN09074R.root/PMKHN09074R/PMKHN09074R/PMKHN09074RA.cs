//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   商品中分類マスタDBリモートオブジェクト
//                  :   PMKHN09074R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.06.05
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品中分類マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品中分類マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.06.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class GoodsGroupUDB : RemoteWithAppLockDB, IGoodsGroupUDB
    {
        /// <summary>
        /// 商品中分類マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        public GoodsGroupUDB() : base("PMKHN09076D", "Broadleaf.Application.Remoting.ParamData.GoodsGroupUWork", "GOODSGROUPURF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一の商品中分類マスタ情報を取得します。
        /// </summary>
        /// <param name="goodsGroupUObj">GoodsGroupUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品中分類マスタのキー値が一致する商品中分類マスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Read(ref object goodsGroupUObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                GoodsGroupUWork goodsGroupUWork = goodsGroupUObj as GoodsGroupUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref goodsGroupUWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一の商品中分類マスタ情報を取得します。
        /// </summary>
        /// <param name="goodsGroupUWork">GoodsGroupUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品中分類マスタのキー値が一致する商品中分類マスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Read(ref GoodsGroupUWork goodsGroupUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref goodsGroupUWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一の商品中分類マスタ情報を取得します。
        /// </summary>
        /// <param name="goodsGroupUWork">GoodsGroupUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品中分類マスタのキー値が一致する商品中分類マスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int ReadProc(ref GoodsGroupUWork goodsGroupUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "  GOODSGROUPURF" + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.EnterpriseCode);
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsGroupUWork.GoodsMGroup);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToGoodsGroupUWorkFromReader(ref myReader, ref goodsGroupUWork);
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
        /// 商品中分類マスタ情報を物理削除します
        /// </summary>
        /// <param name="goodsGroupUList">物理削除する商品中分類マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品中分類マスタのキー値が一致する商品中分類マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Delete(object goodsGroupUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = goodsGroupUList as ArrayList;

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
        /// 商品中分類マスタ情報を物理削除します
        /// </summary>
        /// <param name="goodsGroupUList">商品中分類マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUList に格納されている商品中分類マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Delete(ArrayList goodsGroupUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(goodsGroupUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 商品中分類マスタ情報を物理削除します
        /// </summary>
        /// <param name="goodsGroupUList">商品中分類マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUList に格納されている商品中分類マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int DeleteProc(ArrayList goodsGroupUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (goodsGroupUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < goodsGroupUList.Count; i++)
                    {
                        GoodsGroupUWork goodsGroupUWork = goodsGroupUList[i] as GoodsGroupUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  GOODSGROUPURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.EnterpriseCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsGroupUWork.GoodsMGroup);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != goodsGroupUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  GOODSGROUPURF" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.EnterpriseCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsGroupUWork.GoodsMGroup);
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
        /// 商品中分類マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="goodsGroupUList">検索結果</param>
        /// <param name="goodsGroupUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品中分類マスタのキー値が一致する、全ての商品中分類マスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Search(ref object goodsGroupUList, object goodsGroupUObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList goodsGroupUArray = goodsGroupUList as ArrayList;
                GoodsGroupUWork goodsGroupUWork = goodsGroupUObj as GoodsGroupUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref goodsGroupUArray, goodsGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// 商品中分類マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="goodsGroupUList">商品中分類マスタ情報を格納する ArrayList</param>
        /// <param name="goodsGroupUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品中分類マスタのキー値が一致する、全ての商品中分類マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Search(ref ArrayList goodsGroupUList, GoodsGroupUWork goodsGroupUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref goodsGroupUList, goodsGroupUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 商品中分類マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="goodsGroupUList">商品中分類マスタ情報を格納する ArrayList</param>
        /// <param name="goodsGroupUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品中分類マスタのキー値が一致する、全ての商品中分類マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int SearchProc(ref ArrayList goodsGroupUList, GoodsGroupUWork goodsGroupUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "  GOODSGROUPURF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, goodsGroupUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    goodsGroupUList.Add(this.CopyToGoodsGroupUWorkFromReader(ref myReader));
                }

                if (goodsGroupUList.Count > 0)
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
        /// 商品中分類マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="goodsGroupUList">追加・更新する商品中分類マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUList に格納されている商品中分類マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Write(ref object goodsGroupUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = goodsGroupUList as ArrayList;

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
        /// 商品中分類マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="goodsGroupUList">追加・更新する商品中分類マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUList に格納されている商品中分類マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Write(ref ArrayList goodsGroupUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref goodsGroupUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 商品中分類マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="goodsGroupUList">追加・更新する商品中分類マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUList に格納されている商品中分類マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int WriteProc(ref ArrayList goodsGroupUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (goodsGroupUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < goodsGroupUList.Count; i++)
                    {
                        GoodsGroupUWork goodsGroupUWork = goodsGroupUList[i] as GoodsGroupUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  GOODSGROUPURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.EnterpriseCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsGroupUWork.GoodsMGroup);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != goodsGroupUWork.UpdateDateTime)
                            {
                                if (goodsGroupUWork.UpdateDateTime == DateTime.MinValue)
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

                            //提供データを修正した場合は提供データ区分に１をセットする
                            if ((goodsGroupUWork.OfferDate != DateTime.MinValue) && (goodsGroupUWork.OfferDataDiv == 0))
                            {
                                goodsGroupUWork.OfferDataDiv = 1;
                            }

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText = "UPDATE GOODSGROUPURF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , GOODSMGROUPRF=@GOODSMGROUP , GOODSMGROUPNAMERF=@GOODSMGROUPNAME, OFFERDATERF=@OFFERDATE, OFFERDATADIVRF=@OFFERDATADIV WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMGROUPRF=@FINDGOODSMGROUP";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.EnterpriseCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsGroupUWork.GoodsMGroup);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsGroupUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (goodsGroupUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO GOODSGROUPURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, OFFERDATERF, OFFERDATADIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @GOODSMGROUP, @GOODSMGROUPNAME, @OFFERDATE, @OFFERDATADIV)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsGroupUWork;
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
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraGoodsMGroupName = sqlCommand.Parameters.Add("@GOODSMGROUPNAME", SqlDbType.NVarChar);
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                            SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsGroupUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsGroupUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(goodsGroupUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsGroupUWork.LogicalDeleteCode);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsGroupUWork.GoodsMGroup);
                        paraGoodsMGroupName.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.GoodsMGroupName);
                        paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(goodsGroupUWork.OfferDate);
                        paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(goodsGroupUWork.OfferDataDiv);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsGroupUWork);
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

            goodsGroupUList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// 商品中分類マスタ情報を論理削除します。
        /// </summary>
        /// <param name="goodsGroupUList">論理削除する商品中分類マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUWork に格納されている商品中分類マスタ情報を論理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int LogicalDelete(ref object goodsGroupUList)
        {
            return this.LogicalDelete(ref goodsGroupUList, 0);
        }

        /// <summary>
        /// 商品中分類マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="goodsGroupUList">論理削除を解除する商品中分類マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUWork に格納されている商品中分類マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int RevivalLogicalDelete(ref object goodsGroupUList)
        {
            return this.LogicalDelete(ref goodsGroupUList, 1);
        }

        /// <summary>
        /// 商品中分類マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="goodsGroupUList">論理削除を操作する商品中分類マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUWork に格納されている商品中分類マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int LogicalDelete(ref object goodsGroupUList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = goodsGroupUList as ArrayList;

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
        /// 商品中分類マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="goodsGroupUList">論理削除を操作する商品中分類マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUWork に格納されている商品中分類マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int LogicalDelete(ref ArrayList goodsGroupUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref goodsGroupUList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 商品中分類マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="goodsGroupUList">論理削除を操作する商品中分類マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUWork に格納されている商品中分類マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int LogicalDeleteProc(ref ArrayList goodsGroupUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (goodsGroupUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < goodsGroupUList.Count; i++)
                    {
                        GoodsGroupUWork goodsGroupUWork = goodsGroupUList[i] as GoodsGroupUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  GOODSGROUPURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.EnterpriseCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsGroupUWork.GoodsMGroup);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != goodsGroupUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  GOODSGROUPURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.EnterpriseCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsGroupUWork.GoodsMGroup);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)goodsGroupUWork;
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
                            else if (logicalDelCd == 0) goodsGroupUWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else goodsGroupUWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                goodsGroupUWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(goodsGroupUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(goodsGroupUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(goodsGroupUWork);
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

            goodsGroupUList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="goodsGroupUWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, GoodsGroupUWork goodsGroupUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsGroupUWork.EnterpriseCode);

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
            
            if (goodsGroupUWork.GoodsMGroup != 0)
            {
                retstring += "AND GOODSMGROUPRF = @FINDGOODSMGROUP"  + Environment.NewLine;
                SqlParameter findGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(goodsGroupUWork.GoodsMGroup);
            }

            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → GoodsGroupUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>GoodsGroupUWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        private GoodsGroupUWork CopyToGoodsGroupUWorkFromReader(ref SqlDataReader myReader)
        {
            GoodsGroupUWork goodsGroupUWork = new GoodsGroupUWork();

            this.CopyToGoodsGroupUWorkFromReader(ref myReader, ref goodsGroupUWork);

            return goodsGroupUWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → GoodsGroupUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="goodsGroupUWork">GoodsGroupUWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        private void CopyToGoodsGroupUWorkFromReader(ref SqlDataReader myReader, ref GoodsGroupUWork goodsGroupUWork)
        {
            if (myReader != null && goodsGroupUWork != null)
            {
                # region クラスへ格納

                goodsGroupUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                goodsGroupUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                goodsGroupUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                goodsGroupUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                goodsGroupUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                goodsGroupUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                goodsGroupUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                goodsGroupUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                goodsGroupUWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                goodsGroupUWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                goodsGroupUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));
                goodsGroupUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));

                # endregion
            }
        }
        # endregion
    }
}

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
    /// BLコードガイドマスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコードガイドマスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23015　森本 大輝</br>
    /// <br>Date       : 2008.09.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class BLCodeGuideDB : RemoteWithAppLockDB, IBLCodeGuideDB
    {
        /// <summary>
        /// BLコードガイドマスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        /// </remarks>
        public BLCodeGuideDB()
            : base("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.BLCodeGuideWork", "BLCODEGUIDERF")
        {

        }

        #region [Read]
        /// <summary>
        /// 単一のBLコードガイドマスタ情報を取得します。
        /// </summary>
        /// <param name="bLCodeGuideObj">BLCodeGuideWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードガイドマスタのキー値が一致するBLコードガイドマスタ情報を取得します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        public int Read(ref object bLCodeGuideObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                BLCodeGuideWork bLCodeGuideWork = bLCodeGuideObj as BLCodeGuideWork;

                //コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref bLCodeGuideWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一のBLコードガイドマスタ情報を取得します。
        /// </summary>
        /// <param name="bLCodeGuideWork">BLCodeGuideWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードガイドマスタのキー値が一致するBLコードガイドマスタ情報を取得します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        public int Read(ref BLCodeGuideWork bLCodeGuideWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref bLCodeGuideWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一のBLコードガイドマスタ情報を取得します。
        /// </summary>
        /// <param name="bLCodeGuideWork">BLCodeGuideWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードガイドマスタのキー値が一致するBLコードガイドマスタ情報を取得します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        private int ReadProc(ref BLCodeGuideWork bLCodeGuideWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = string.Empty;
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                #region [SELECT文]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,BLCODEDSPPAGERF" + Environment.NewLine;
                selectTxt += "  ,BLCODEDSPROWRF" + Environment.NewLine;
                selectTxt += "  ,BLCODEDSPCOLRF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSNAMERF" + Environment.NewLine;
                selectTxt += " FROM BLCODEGUIDERF" + Environment.NewLine;
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                selectTxt += "  AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE" + Environment.NewLine;
                selectTxt += "  AND BLCODEDSPROWRF=@FINDBLCODEDSPROW" + Environment.NewLine;
                selectTxt += "  AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL" + Environment.NewLine;
                selectTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;
                #endregion  //[SELECT文]

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaBLCodeDspPage = sqlCommand.Parameters.Add("@FINDBLCODEDSPPAGE", SqlDbType.Int);
                SqlParameter findParaBLCodeDspRow = sqlCommand.Parameters.Add("@FINDBLCODEDSPROW", SqlDbType.Int);
                SqlParameter findParaBLCodeDspCol = sqlCommand.Parameters.Add("@FINDBLCODEDSPCOL", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToBLCodeGuideWorkFromReader(ref myReader, ref bLCodeGuideWork);
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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLCodeGuideDB.ReadProc Exception=" + ex.Message);
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
        #endregion  //[Read]

        #region [Search]
        /// <summary>
        /// BLコードガイドマスタ情報のリストを取得します。
        /// </summary>
        /// <param name="bLCodeGuideList">検索結果</param>
        /// <param name="bLCodeGuideObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードガイドマスタのキー値が一致する、全てのBLコードガイドマスタ情報を取得します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        public int Search(ref object bLCodeGuideList, object bLCodeGuideObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList bLCodeGuideArray = new ArrayList();

            try
            {
                BLCodeGuideWork bLCodeGuideWork = bLCodeGuideObj as BLCodeGuideWork;

                //コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref bLCodeGuideArray, bLCodeGuideWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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

            bLCodeGuideList = bLCodeGuideArray;

            return status;
        }

        /// <summary>
        /// BLコードガイドマスタ情報のリストを取得します。
        /// </summary>
        /// <param name="bLCodeGuideList">BLコードガイドマスタ情報を格納する ArrayList</param>
        /// <param name="bLCodeGuideWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードガイドマスタのキー値が一致する、全てのBLコードガイドマスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        public int Search(ref ArrayList bLCodeGuideList, BLCodeGuideWork bLCodeGuideWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref bLCodeGuideList, bLCodeGuideWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// BLコードガイドマスタ情報のリストを取得します。
        /// </summary>
        /// <param name="bLCodeGuideList">BLコードガイドマスタ情報を格納する ArrayList</param>
        /// <param name="bLCodeGuideWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードガイドマスタのキー値が一致する、全てのBLコードガイドマスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        private int SearchProc(ref ArrayList bLCodeGuideList, BLCodeGuideWork bLCodeGuideWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = string.Empty;
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                #region [SELECT文]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,BLCODEDSPPAGERF" + Environment.NewLine;
                selectTxt += "  ,BLCODEDSPROWRF" + Environment.NewLine;
                selectTxt += "  ,BLCODEDSPCOLRF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSNAMERF" + Environment.NewLine;
                selectTxt += " FROM BLCODEGUIDERF" + Environment.NewLine;
                selectTxt += MakeWhereString(ref sqlCommand, bLCodeGuideWork, logicalMode);

                sqlCommand.CommandText = selectTxt;
                #endregion  //[SELECT文]

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    bLCodeGuideList.Add(this.CopyToBLCodeGuideWorkFromReader(ref myReader));
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
                base.WriteErrorLog(ex, "BLCodeGuideDB.SearchProc Exception=" + ex.Message);
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
        #endregion  //[Search]

        #region [Write]
        /// <summary>
        /// BLコードガイドマスタ情報を追加・更新します。
        /// </summary>
        /// <param name="bLCodeGuideList">追加・更新するBLコードガイドマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideList に格納されているBLコードガイドマスタ情報を追加・更新します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        public int Write(ref object bLCodeGuideList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータのキャスト
                ArrayList paraList = bLCodeGuideList as ArrayList;

                //コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                //トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //write実行
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
                            //コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //ロールバック
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
        /// BLコードガイドマスタ情報を追加・更新します。
        /// </summary>
        /// <param name="bLCodeGuideList">追加・更新するBLコードガイドマスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideList に格納されているBLコードガイドマスタ情報を追加・更新します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        public int Write(ref ArrayList bLCodeGuideList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref bLCodeGuideList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// BLコードガイドマスタ情報を追加・更新します。
        /// </summary>
        /// <param name="bLCodeGuideList">追加・更新するBLコードガイドマスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideList に格納されているBLコードガイドマスタ情報を追加・更新します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        private int WriteProc(ref ArrayList bLCodeGuideList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (bLCodeGuideList != null)
                {
                    string selectTxt = string.Empty;
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    for (int i = 0; i < bLCodeGuideList.Count; i++)
                    {
                        BLCodeGuideWork bLCodeGuideWork = bLCodeGuideList[i] as BLCodeGuideWork;

                        #region [SELECT文]
                        selectTxt = string.Empty;

                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "   UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " FROM BLCODEGUIDERF" + Environment.NewLine;
                        selectTxt += " WHERE" + Environment.NewLine;
                        selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPROWRF=@FINDBLCODEDSPROW" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL" + Environment.NewLine;
                        selectTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        #endregion  //[SELECT文]

                        sqlCommand.Parameters.Clear();

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaBLCodeDspPage = sqlCommand.Parameters.Add("@FINDBLCODEDSPPAGE", SqlDbType.Int);
                        SqlParameter findParaBLCodeDspRow = sqlCommand.Parameters.Add("@FINDBLCODEDSPROW", SqlDbType.Int);
                        SqlParameter findParaBLCodeDspCol = sqlCommand.Parameters.Add("@FINDBLCODEDSPCOL", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                        findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                        findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                        findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //更新日時

                            if (_updateDateTime != bLCodeGuideWork.UpdateDateTime)
                            {
                                if (bLCodeGuideWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    //新規登録で該当データ有りの場合には重複
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    //既存データで更新日時違いの場合には排他
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            #region [UPDATE文]
                            selectTxt = string.Empty;

                            selectTxt += "UPDATE BLCODEGUIDERF SET" + Environment.NewLine;
                            selectTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,BLCODEDSPPAGERF=@BLCODEDSPPAGE" + Environment.NewLine;
                            selectTxt += "  ,BLCODEDSPROWRF=@BLCODEDSPROW" + Environment.NewLine;
                            selectTxt += "  ,BLCODEDSPCOLRF=@BLCODEDSPCOL" + Environment.NewLine;
                            selectTxt += "  ,BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            selectTxt += "  ,BLGOODSNAMERF=@BLGOODSNAME" + Environment.NewLine;
                            selectTxt += " WHERE" + Environment.NewLine;
                            selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPROWRF=@FINDBLCODEDSPROW" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL" + Environment.NewLine;
                            selectTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            #endregion  //[UPDATE文]

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                            findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                            findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                            findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)bLCodeGuideWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (bLCodeGuideWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            #region [INSERT文]
                            selectTxt = string.Empty;

                            selectTxt += "INSERT INTO BLCODEGUIDERF" + Environment.NewLine;
                            selectTxt += " ( CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,BLCODEDSPPAGERF" + Environment.NewLine;
                            selectTxt += "  ,BLCODEDSPROWRF" + Environment.NewLine;
                            selectTxt += "  ,BLCODEDSPCOLRF" + Environment.NewLine;
                            selectTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                            selectTxt += "  ,BLGOODSNAMERF" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;
                            selectTxt += " VALUES" + Environment.NewLine;
                            selectTxt += " ( @CREATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@BLCODEDSPPAGE" + Environment.NewLine;
                            selectTxt += "  ,@BLCODEDSPROW" + Environment.NewLine;
                            selectTxt += "  ,@BLCODEDSPCOL" + Environment.NewLine;
                            selectTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                            selectTxt += "  ,@BLGOODSNAME" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            #endregion  //[INSERT文]

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)bLCodeGuideWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraBLCodeDspPage = sqlCommand.Parameters.Add("@BLCODEDSPPAGE", SqlDbType.Int);
                        SqlParameter paraBLCodeDspRow = sqlCommand.Parameters.Add("@BLCODEDSPROW", SqlDbType.Int);
                        SqlParameter paraBLCodeDspCol = sqlCommand.Parameters.Add("@BLCODEDSPCOL", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsName = sqlCommand.Parameters.Add("@BLGOODSNAME", SqlDbType.NVarChar);
                        #endregion  //Parameterオブジェクトの作成(更新用)

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(bLCodeGuideWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(bLCodeGuideWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(bLCodeGuideWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                        paraBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                        paraBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                        paraBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);
                        paraBLGoodsName.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.BLGoodsName);
                        #endregion  //Parameterオブジェクトへ値設定(更新用)

                        sqlCommand.ExecuteNonQuery();
                        al.Add(bLCodeGuideWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLCodeGuideDB.WriteProc Exception=" + ex.Message);
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

            bLCodeGuideList = al;

            return status;
        }
        #endregion  //[Write]

        #region [Delete]
        /// <summary>
        /// BLコードガイドマスタ情報を物理削除します
        /// </summary>
        /// <param name="bLCodeGuideList">物理削除するBLコードガイドマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLコードガイドマスタのキー値が一致するBLコードガイドマスタ情報を物理削除します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        public int Delete(object bLCodeGuideList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータのキャスト
                ArrayList paraList = bLCodeGuideList as ArrayList;

                //コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                //トランザクション開始
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
                            //コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //ロールバック
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
        /// BLコードガイドマスタ情報を物理削除します
        /// </summary>
        /// <param name="bLCodeGuideList">BLコードガイドマスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideList に格納されているBLコードガイドマスタ情報を物理削除します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        public int Delete(ArrayList bLCodeGuideList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(bLCodeGuideList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// BLコードガイドマスタ情報を物理削除します
        /// </summary>
        /// <param name="bLCodeGuideList">BLコードガイドマスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideList に格納されているBLコードガイドマスタ情報を物理削除します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        private int DeleteProc(ArrayList bLCodeGuideList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (bLCodeGuideList != null)
                {
                    string selectTxt = string.Empty;
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    for (int i = 0; i < bLCodeGuideList.Count; i++)
                    {
                        BLCodeGuideWork bLCodeGuideWork = bLCodeGuideList[i] as BLCodeGuideWork;

                        #region [SELECT文]
                        selectTxt = string.Empty;

                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "   UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " FROM BLCODEGUIDERF" + Environment.NewLine;
                        selectTxt += " WHERE" + Environment.NewLine;
                        selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPROWRF=@FINDBLCODEDSPROW" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL" + Environment.NewLine;
                        selectTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        
                        sqlCommand.CommandText = selectTxt;
                        #endregion  //[SELECT文]

                        sqlCommand.Parameters.Clear();

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaBLCodeDspPage = sqlCommand.Parameters.Add("@FINDBLCODEDSPPAGE", SqlDbType.Int);
                        SqlParameter findParaBLCodeDspRow = sqlCommand.Parameters.Add("@FINDBLCODEDSPROW", SqlDbType.Int);
                        SqlParameter findParaBLCodeDspCol = sqlCommand.Parameters.Add("@FINDBLCODEDSPCOL", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                        findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                        findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                        findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //更新日時

                            if (_updateDateTime != bLCodeGuideWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            #region [DELETE文]
                            selectTxt = string.Empty;

                            selectTxt += "DELETE" + Environment.NewLine;
                            selectTxt += " FROM BLCODEGUIDERF" + Environment.NewLine;
                            selectTxt += " WHERE" + Environment.NewLine;
                            selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPROWRF=@FINDBLCODEDSPROW" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL" + Environment.NewLine;
                            selectTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                            
                            sqlCommand.CommandText = selectTxt;
                            #endregion  //[DELETE文]

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                            findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                            findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                            findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLCodeGuideDB.DeleteProc Exception=" + ex.Message);
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
        #endregion  //[DELETE]

        #region [LogicalDelete]
        /// <summary>
        /// BLコードガイドマスタ情報を論理削除します。
        /// </summary>
        /// <param name="bLCodeGuideList">論理削除するBLコードガイドマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideWork に格納されているBLコードガイドマスタ情報を論理削除します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        public int LogicalDelete(ref object bLCodeGuideList)
        {
            return this.LogicalDelete(ref bLCodeGuideList, 0);
        }

        /// <summary>
        /// BLコードガイドマスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="bLCodeGuideList">論理削除を解除するBLコードガイドマスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideWork に格納されているBLコードガイドマスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        public int RevivalLogicalDelete(ref object bLCodeGuideList)
        {
            return this.LogicalDelete(ref bLCodeGuideList, 1);
        }

        /// <summary>
        /// BLコードガイドマスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="bLCodeGuideList">論理削除を操作するBLコードガイドマスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideWork に格納されているBLコードガイドマスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        private int LogicalDelete(ref object bLCodeGuideList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータのキャスト
                ArrayList paraList = bLCodeGuideList as ArrayList;

                //コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                //トランザクション開始
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
                            //コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //ロールバック
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
        /// BLコードガイドマスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="bLCodeGuideList">論理削除を操作するBLコードガイドマスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideWork に格納されているBLコードガイドマスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        public int LogicalDelete(ref ArrayList bLCodeGuideList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref bLCodeGuideList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// BLコードガイドマスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="bLCodeGuideList">論理削除を操作するBLコードガイドマスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideWork に格納されているBLコードガイドマスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        private int LogicalDeleteProc(ref ArrayList bLCodeGuideList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (bLCodeGuideList != null)
                {
                    string selectTxt = string.Empty;
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    for (int i = 0; i < bLCodeGuideList.Count; i++)
                    {
                        BLCodeGuideWork bLCodeGuideWork = bLCodeGuideList[i] as BLCodeGuideWork;

                        #region [SELECT文]
                        selectTxt = string.Empty;

                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "   UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += " FROM BLCODEGUIDERF" + Environment.NewLine;
                        selectTxt += " WHERE" + Environment.NewLine;
                        selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPROWRF=@FINDBLCODEDSPROW" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL" + Environment.NewLine;
                        selectTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        
                        sqlCommand.CommandText = selectTxt;
                        #endregion  //[SELECT文]

                        sqlCommand.Parameters.Clear();

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaBLCodeDspPage = sqlCommand.Parameters.Add("@FINDBLCODEDSPPAGE", SqlDbType.Int);
                        SqlParameter findParaBLCodeDspRow = sqlCommand.Parameters.Add("@FINDBLCODEDSPROW", SqlDbType.Int);
                        SqlParameter findParaBLCodeDspCol = sqlCommand.Parameters.Add("@FINDBLCODEDSPCOL", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                        findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                        findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                        findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //更新日時

                            if (_updateDateTime != bLCodeGuideWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            #region [UPDATE文]
                            selectTxt = string.Empty;

                            selectTxt += "UPDATE BLCODEGUIDERF SET" + Environment.NewLine;
                            selectTxt += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += " WHERE" + Environment.NewLine;
                            selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPROWRF=@FINDBLCODEDSPROW" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL" + Environment.NewLine;
                            selectTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            #endregion  //[UPDATE文]

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                            findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                            findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                            findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)bLCodeGuideWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        //論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;         //既に削除済みの場合正常
                                return status;
                            }
                            else if (logicalDelCd == 0) bLCodeGuideWork.LogicalDeleteCode = 1;  //論理削除フラグをセット
                            else bLCodeGuideWork.LogicalDeleteCode = 3;                         //完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                bLCodeGuideWork.LogicalDeleteCode = 0;                          //論理削除フラグを解除
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //既に復活している場合はそのまま正常を戻す
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //完全削除はデータなしを戻す
                                }

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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(bLCodeGuideWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(bLCodeGuideWork);
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
                base.WriteErrorLog(ex, "BLCodeGuideDB.LogicalDeleteProc Exception=" + ex.Message);
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

            bLCodeGuideList = al;

            return status;
        }
        #endregion  //[LogicalDelete]

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="bLCodeGuideWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, BLCodeGuideWork bLCodeGuideWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string wkstring = "";
            string retstring = " WHERE" + Environment.NewLine;;

            //企業コード
            retstring += " ENTERPRISECODERF=@FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (bLCodeGuideWork.SectionCode != "")
            {
                retstring += " AND SECTIONCODERF=@FINDSECTIONCODE";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
            }

            //BLコード表示頁
            if (bLCodeGuideWork.BLCodeDspPage != 0)
            {
                retstring += " AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE";
                SqlParameter paraBLCodeDspPage = sqlCommand.Parameters.Add("@FINDBLCODEDSPPAGE", SqlDbType.Int);
                paraBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
            }

            //BLコード表示行
            if (bLCodeGuideWork.BLCodeDspRow != 0)
            {
                retstring += " AND BLCODEDSPROWRF=@FINDBLCODEDSPROW";
                SqlParameter paraBLCodeDspRow = sqlCommand.Parameters.Add("@FINDBLCODEDSPROW", SqlDbType.Int);
                paraBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
            }

            //BLコード表示列
            if (bLCodeGuideWork.BLCodeDspCol != 0)
            {
                retstring += " AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL";
                SqlParameter paraBLCodeDspCol = sqlCommand.Parameters.Add("@FINDBLCODEDSPCOL", SqlDbType.Int);
                paraBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
            }

            //BL商品コード
            if (bLCodeGuideWork.BLGoodsCode != 0)
            {
                retstring += " AND BLGOODSCODERF=@FINDBLGOODSCODE";
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);
            }
            #endregion  //WHERE文作成

            return retstring;
        }
        #endregion  //[Where文作成処理]

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → BLCodeGuideWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>BLCodeGuideWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        /// </remarks>
        private BLCodeGuideWork CopyToBLCodeGuideWorkFromReader(ref SqlDataReader myReader)
        {
            BLCodeGuideWork bLCodeGuideWork = new BLCodeGuideWork();

            this.CopyToBLCodeGuideWorkFromReader(ref myReader, ref bLCodeGuideWork);

            return bLCodeGuideWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → BLCodeGuideWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="bLCodeGuideWork">BLCodeGuideWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 23015　森本 大輝</br>
        /// <br>Date       : 2008.09.26</br>
        /// </remarks>
        private void CopyToBLCodeGuideWorkFromReader(ref SqlDataReader myReader, ref BLCodeGuideWork bLCodeGuideWork)
        {
            if (myReader != null && bLCodeGuideWork != null)
            {
                #region クラスへ格納
                bLCodeGuideWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                bLCodeGuideWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                bLCodeGuideWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                bLCodeGuideWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                bLCodeGuideWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                bLCodeGuideWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                bLCodeGuideWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                bLCodeGuideWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                bLCodeGuideWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                bLCodeGuideWork.BLCodeDspPage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCODEDSPPAGERF"));
                bLCodeGuideWork.BLCodeDspRow = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCODEDSPROWRF"));
                bLCodeGuideWork.BLCodeDspCol = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCODEDSPCOLRF"));
                bLCodeGuideWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                bLCodeGuideWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSNAMERF"));
                #endregion  //クラスへ格納
            }
        }
        #endregion  //[クラス格納処理]
    }
}

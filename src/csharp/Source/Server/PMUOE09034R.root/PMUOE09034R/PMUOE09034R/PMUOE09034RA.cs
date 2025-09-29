//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE ガイド名称マスタDBリモートオブジェクト
//                  :   PMUOE09034R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 疋田 勇人
// Date             :   2008.06.06
//----------------------------------------------------------------------
// Update Note      :   2008/12/11 30365 宮津銀次郎 UOEGuideCodeについて空文字での登録に対応
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
    /// UOE ガイド名称マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE ガイド名称マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class UOEGuideNameDB : RemoteWithAppLockDB, IUOEGuideNameDB, IGetSyncdataList
    {
        /// <summary>
        /// UOE ガイド名称マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public UOEGuideNameDB() : base("PMUOE09036D", "Broadleaf.Application.Remoting.ParamData.UOEGuideNameWork", "UOEGuideNameRF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一のUOE ガイド名称マスタ情報を取得します。
        /// </summary>
        /// <param name="uoeGuideNameObj">UOEGuideNameWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ガイド名称マスタのキー値が一致するUOE ガイド名称マスタ情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Read(ref object uoeGuideNameObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                UOEGuideNameWork uoeGuideNameWork = uoeGuideNameObj as UOEGuideNameWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref uoeGuideNameWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一のUOE ガイド名称マスタ情報を取得します。
        /// </summary>
        /// <param name="uoeGuideNameWork">UOEGuideNameWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ガイド名称マスタのキー値が一致するUOE ガイド名称マスタ情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Read(ref UOEGuideNameWork uoeGuideNameWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref uoeGuideNameWork, readMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 単一のUOE ガイド名称マスタ情報を取得します。
        /// </summary>
        /// <param name="uoeGuideNameWork">UOEGuideNameWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ガイド名称マスタのキー値が一致するUOE ガイド名称マスタ情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private int ReadProc(ref UOEGuideNameWork uoeGuideNameWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT UOEGUID.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOEGUIDEDIVCDRF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOEGUIDECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOEGUIDENAMERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUP.UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += " FROM UOEGUIDENAMERF UOEGUID" + Environment.NewLine;
                sqlText += " LEFT JOIN UOESUPPLIERRF UOESUP ON UOEGUID.ENTERPRISECODERF=UOESUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOEGUID.UOESUPPLIERCDRF=UOESUP.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += " WHERE UOEGUID.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND UOEGUID.UOEGUIDEDIVCDRF=@FINDUOEGUIDEDIVCD" + Environment.NewLine;
                sqlText += "    AND UOEGUID.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlText += "    AND UOEGUID.UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                sqlText += "    AND UOEGUID.UOEGUIDECODERF=@FINDUOEGUIDECODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUOEGuideDivCd = sqlCommand.Parameters.Add("@FINDUOEGUIDEDIVCD", SqlDbType.Int);
                SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                SqlParameter findParaUOEGuideCode = sqlCommand.Parameters.Add("@FINDUOEGUIDECODE", SqlDbType.NVarChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                findParaUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                findParaUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToUOEGuideNameWorkFromReader(ref myReader, ref uoeGuideNameWork);
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
        /// UOE ガイド名称マスタ情報を物理削除します
        /// </summary>
        /// <param name="uoeGuideNameList">物理削除するUOE ガイド名称マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ガイド名称マスタのキー値が一致するUOE ガイド名称マスタ情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Delete(object uoeGuideNameList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = uoeGuideNameList as ArrayList;

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
        /// UOE ガイド名称マスタ情報を物理削除します
        /// </summary>
        /// <param name="uoeGuideNameList">UOE ガイド名称マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeGuideNameList に格納されているUOE ガイド名称マスタ情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Delete(ArrayList uoeGuideNameList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(uoeGuideNameList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE ガイド名称マスタ情報を物理削除します
        /// </summary>
        /// <param name="uoeGuideNameList">UOE ガイド名称マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeGuideNameList に格納されているUOE ガイド名称マスタ情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private int DeleteProc(ArrayList uoeGuideNameList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (uoeGuideNameList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeGuideNameList.Count; i++)
                    {
                        UOEGuideNameWork uoeGuideNameWork = uoeGuideNameList[i] as UOEGuideNameWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM UOEGUIDENAMERF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND UOEGUIDEDIVCDRF=@FINDUOEGUIDEDIVCD" + Environment.NewLine;
                        sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                        sqlText += "    AND UOEGUIDECODERF=@FINDUOEGUIDECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOEGuideDivCd = sqlCommand.Parameters.Add("@FINDUOEGUIDEDIVCD", SqlDbType.Int);
                        SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaUOEGuideCode = sqlCommand.Parameters.Add("@FINDUOEGUIDECODE", SqlDbType.NVarChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                        findParaUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                        findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                        //findParaUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode);
                        findParaUOEGuideCode.Value = uoeGuideNameWork.UOEGuideCode;
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != uoeGuideNameWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM UOEGUIDENAMERF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND UOEGUIDEDIVCDRF=@FINDUOEGUIDEDIVCD" + Environment.NewLine;
                            sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    AND UOEGUIDECODERF=@FINDUOEGUIDECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                            findParaUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                            findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                            //findParaUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode);
                            findParaUOEGuideCode.Value = uoeGuideNameWork.UOEGuideCode;
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);
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
        /// UOE ガイド名称マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="uoeGuideNameList">検索結果</param>
        /// <param name="uoeGuideNameObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ガイド名称マスタのキー値が一致する、全てのUOE ガイド名称マスタ情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Search(ref object uoeGuideNameList, object uoeGuideNameObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList uoeGuideNameArray = uoeGuideNameList as ArrayList;

                if (uoeGuideNameArray == null)
                {
                    uoeGuideNameArray = new ArrayList();
                }
                
                UOEGuideNameWork uoeGuideNameWork = uoeGuideNameObj as UOEGuideNameWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref uoeGuideNameArray, uoeGuideNameWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// UOE ガイド名称マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="uoeGuideNameList">UOE ガイド名称マスタ情報を格納する ArrayList</param>
        /// <param name="uoeGuideNameWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ガイド名称マスタのキー値が一致する、全てのUOE ガイド名称マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Search(ref ArrayList uoeGuideNameList, UOEGuideNameWork uoeGuideNameWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref uoeGuideNameList, uoeGuideNameWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE ガイド名称マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="uoeGuideNameList">UOE ガイド名称マスタ情報を格納する ArrayList</param>
        /// <param name="uoeGuideNameWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE ガイド名称マスタのキー値が一致する、全てのUOE ガイド名称マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private int SearchProc(ref ArrayList uoeGuideNameList, UOEGuideNameWork uoeGuideNameWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT   UOEGUID.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.SECTIONCODERF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UOEGUIDEDIVCDRF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UOEGUIDECODERF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UOEGUIDENAMERF" + Environment.NewLine;
                sqlText += "        ,UOESUP.UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += " FROM UOEGUIDENAMERF UOEGUID" + Environment.NewLine;
                sqlText += " LEFT JOIN UOESUPPLIERRF UOESUP ON UOEGUID.ENTERPRISECODERF=UOESUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOEGUID.UOESUPPLIERCDRF=UOESUP.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    AND UOEGUID.SECTIONCODERF=UOESUP.SECTIONCODERF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, uoeGuideNameWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    uoeGuideNameList.Add(this.CopyToUOEGuideNameWorkFromReader(ref myReader));
                }

                if (uoeGuideNameList.Count > 0)
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
        /// UOE ガイド名称マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="uoeGuideNameList">追加・更新するUOE ガイド名称マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameList に格納されているUOE ガイド名称マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Write(ref object uoeGuideNameList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = uoeGuideNameList as ArrayList;

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
        /// UOE ガイド名称マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="uoeGuideNameList">追加・更新するUOE ガイド名称マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeGuideNameList に格納されているUOE ガイド名称マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Write(ref ArrayList uoeGuideNameList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref uoeGuideNameList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE ガイド名称マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="uoeGuideNameList">追加・更新するUOE ガイド名称マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeGuideNameList に格納されているUOE ガイド名称マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private int WriteProc(ref ArrayList uoeGuideNameList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (uoeGuideNameList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeGuideNameList.Count; i++)
                    {
                        UOEGuideNameWork uoeGuideNameWork = uoeGuideNameList[i] as UOEGuideNameWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM UOEGUIDENAMERF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND UOEGUIDEDIVCDRF=@FINDUOEGUIDEDIVCD" + Environment.NewLine;
                        sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                        sqlText += "    AND UOEGUIDECODERF=@FINDUOEGUIDECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOEGuideDivCd = sqlCommand.Parameters.Add("@FINDUOEGUIDEDIVCD", SqlDbType.Int);
                        SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaUOEGuideCode = sqlCommand.Parameters.Add("@FINDUOEGUIDECODE", SqlDbType.NVarChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                        findParaUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                        findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                        //findParaUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode); // 2008/12/11 G.Miyatsu DEL
                        findParaUOEGuideCode.Value = uoeGuideNameWork.UOEGuideCode; // 2008/12/11 G.Miyatsu ADD
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != uoeGuideNameWork.UpdateDateTime)
                            {
                                if (uoeGuideNameWork.UpdateDateTime == DateTime.MinValue)
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
              
                            sqlText += "UPDATE UOEGUIDENAMERF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , UOEGUIDEDIVCDRF=@UOEGUIDEDIVCD" + Environment.NewLine;
                            sqlText += " , UOESUPPLIERCDRF=@UOESUPPLIERCD" + Environment.NewLine;
                            sqlText += " , UOEGUIDECODERF=@UOEGUIDECODE" + Environment.NewLine;
                            sqlText += " , UOEGUIDENAMERF=@UOEGUIDENAME" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND UOEGUIDEDIVCDRF=@FINDUOEGUIDEDIVCD" + Environment.NewLine;
                            sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    AND UOEGUIDECODERF=@FINDUOEGUIDECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                            findParaUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                            findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                            //findParaUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode);
                            findParaUOEGuideCode.Value = uoeGuideNameWork.UOEGuideCode;
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeGuideNameWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (uoeGuideNameWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO UOEGUIDENAMERF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,UOEGUIDEDIVCDRF" + Environment.NewLine;
                            sqlText += "    ,UOESUPPLIERCDRF" + Environment.NewLine;
                            sqlText += "    ,UOEGUIDECODERF" + Environment.NewLine;
                            sqlText += "    ,UOEGUIDENAMERF" + Environment.NewLine;
                            sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,@UOEGUIDEDIVCD" + Environment.NewLine;
                            sqlText += "    ,@UOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    ,@UOEGUIDECODE" + Environment.NewLine;
                            sqlText += "    ,@UOEGUIDENAME" + Environment.NewLine;
                            sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeGuideNameWork;
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
                        SqlParameter paraUOEGuideDivCd = sqlCommand.Parameters.Add("@UOEGUIDEDIVCD", SqlDbType.Int);
                        SqlParameter paraUOESupplierCd = sqlCommand.Parameters.Add("@UOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraUOEGuideCode = sqlCommand.Parameters.Add("@UOEGUIDECODE", SqlDbType.NVarChar);
                        SqlParameter paraUOEGuideName = sqlCommand.Parameters.Add("@UOEGUIDENAME", SqlDbType.NVarChar);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeGuideNameWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeGuideNameWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(uoeGuideNameWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.LogicalDeleteCode);
                        paraUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                        paraUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                        //paraUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode); // 2008/12/11 G.Miyatsu DEL
                        paraUOEGuideCode.Value = uoeGuideNameWork.UOEGuideCode; // 2008/12/11 G.Miyatsu ADD
                        paraUOEGuideName.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideName);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(uoeGuideNameWork);
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

            uoeGuideNameList = al;

            return status;
        }
        # endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のUOEガイド名称マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081  疋田　勇人</br>
        /// <br>Date       : 2008.06.06</br>
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
        /// <br>Note       : 指定された条件のUOEガイド名称マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081  疋田　勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT UOEGUID.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOEGUIDEDIVCDRF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOEGUIDECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOEGUIDENAMERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUP.UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += " FROM UOEGUIDENAMERF UOEGUID" + Environment.NewLine;
                sqlText += " LEFT JOIN UOESUPPLIERRF UOESUP ON UOEGUID.ENTERPRISECODERF=UOESUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOEGUID.UOESUPPLIERCDRF=UOESUP.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToUOEGuideNameWorkFromReader(ref myReader));

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

        # region [LogicalDelete]
        /// <summary>
        /// UOE ガイド名称マスタ情報を論理削除します。
        /// </summary>
        /// <param name="uoeGuideNameList">論理削除するUOE ガイド名称マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameWork に格納されているUOE ガイド名称マスタ情報を論理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int LogicalDelete(ref object uoeGuideNameList)
        {
            return this.LogicalDelete(ref uoeGuideNameList, 0);
        }

        /// <summary>
        /// UOE ガイド名称マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="uoeGuideNameList">論理削除を解除するUOE ガイド名称マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameWork に格納されているUOE ガイド名称マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int RevivalLogicalDelete(ref object uoeGuideNameList)
        {
            return this.LogicalDelete(ref uoeGuideNameList, 1);
        }

        /// <summary>
        /// UOE ガイド名称マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="uoeGuideNameList">論理削除を操作するUOE ガイド名称マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameWork に格納されているUOE ガイド名称マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private int LogicalDelete(ref object uoeGuideNameList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = uoeGuideNameList as ArrayList;

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
        /// UOE ガイド名称マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="uoeGuideNameList">論理削除を操作するUOE ガイド名称マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameWork に格納されているUOE ガイド名称マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int LogicalDelete(ref ArrayList uoeGuideNameList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref uoeGuideNameList, procMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE ガイド名称マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="uoeGuideNameList">論理削除を操作するUOE ガイド名称マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameWork に格納されているUOE ガイド名称マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private int LogicalDeleteProc(ref ArrayList uoeGuideNameList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (uoeGuideNameList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeGuideNameList.Count; i++)
                    {
                        UOEGuideNameWork uoeGuideNameWork = uoeGuideNameList[i] as UOEGuideNameWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM UOEGUIDENAMERF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND UOEGUIDEDIVCDRF=@FINDUOEGUIDEDIVCD" + Environment.NewLine;
                        sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                        sqlText += "    AND UOEGUIDECODERF=@FINDUOEGUIDECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOEGuideDivCd = sqlCommand.Parameters.Add("@FINDUOEGUIDEDIVCD", SqlDbType.Int);
                        SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaUOEGuideCode = sqlCommand.Parameters.Add("@FINDUOEGUIDECODE", SqlDbType.NVarChar);
                        SqlParameter findParaSectioncode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                        findParaUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                        findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                        //findParaUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode);
                        findParaUOEGuideCode.Value = uoeGuideNameWork.UOEGuideCode;
                        findParaSectioncode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != uoeGuideNameWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                             sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  UOEGUIDENAMERF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND UOEGUIDEDIVCDRF=@FINDUOEGUIDEDIVCD" + Environment.NewLine;
                            sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    AND UOEGUIDECODERF=@FINDUOEGUIDECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                            findParaUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                            findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                            //findParaUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode);
                            findParaUOEGuideCode.Value = uoeGuideNameWork.UOEGuideCode;
                            findParaSectioncode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeGuideNameWork;
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
                            else if (logicalDelCd == 0) uoeGuideNameWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else uoeGuideNameWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                uoeGuideNameWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeGuideNameWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(uoeGuideNameWork);
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

            uoeGuideNameList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="uoeGuideNameWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, UOEGuideNameWork uoeGuideNameWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  UOEGUID.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);

            // 拠点コード
            retstring += " AND UOEGUID.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
            SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            findSectionCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND UOEGUID.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND UOEGUID.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // UOEガイド区分
            if (uoeGuideNameWork.UOEGuideDivCd != 0)
            {
                retstring += "  AND UOEGUID.UOEGUIDEDIVCDRF = @FINDUOEGUIDEDIVCD" + Environment.NewLine;
                SqlParameter findUOEGuideDivCd = sqlCommand.Parameters.Add("@FINDUOEGUIDEDIVCD", SqlDbType.Int);
                findUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
            }

            // UOE発注先コード
            if (uoeGuideNameWork.UOESupplierCd != 0)
            {
                retstring += "  AND UOEGUID.UOESUPPLIERCDRF = @FINDUOESUPPLIERCD" + Environment.NewLine;
                SqlParameter findUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                findUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
            }

            // UOEガイド区分
            if (uoeGuideNameWork.UOEGuideCode != string.Empty)
            {
                retstring += "  AND UOEGUID.UOEGUIDECODERF = @FINDUOEGUIDECODE" + Environment.NewLine;
                SqlParameter findUOEGuideCode = sqlCommand.Parameters.Add("@FINDUOEGUIDECODE", SqlDbType.NVarChar);
                findUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode);
            }

            return retstring;
        }
        # endregion

        #region [シンク用Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="syncServiceWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20081  疋田　勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "UOEGUID.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
            
            // 拠点コード
            retstring += "  UOEGUID.SECTIONCODERF = @FINDSECTIONCODOE" + Environment.NewLine;
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            paraSectionCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.SectionCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UOEGUID.UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UOEGUID.UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UOEGUID.UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → UOEGuideNameWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>UOEGuideNameWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        private UOEGuideNameWork CopyToUOEGuideNameWorkFromReader(ref SqlDataReader myReader)
        {
            UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();

            this.CopyToUOEGuideNameWorkFromReader(ref myReader, ref uoeGuideNameWork);

            return uoeGuideNameWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → UOEGuideNameWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="uoeGuideNameWork">UOEGuideNameWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        private void CopyToUOEGuideNameWorkFromReader(ref SqlDataReader myReader, ref UOEGuideNameWork uoeGuideNameWork)
        {
            if (myReader != null && uoeGuideNameWork != null)
            {
                # region クラスへ格納
                uoeGuideNameWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                uoeGuideNameWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                uoeGuideNameWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                uoeGuideNameWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                uoeGuideNameWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                uoeGuideNameWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                uoeGuideNameWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                uoeGuideNameWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                uoeGuideNameWork.UOEGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOEGUIDEDIVCDRF"));
                uoeGuideNameWork.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESUPPLIERCDRF"));
                uoeGuideNameWork.UOEGuideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEGUIDECODERF"));
                uoeGuideNameWork.UOEGuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEGUIDENAMERF"));
                uoeGuideNameWork.UOESupplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUPPLIERNAMERF"));
                uoeGuideNameWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                # endregion
            }
        }
        # endregion

        # region [コネクション生成処理]
        /*
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
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
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // トランザクションの生成(開始)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        */
        # endregion
    }
}

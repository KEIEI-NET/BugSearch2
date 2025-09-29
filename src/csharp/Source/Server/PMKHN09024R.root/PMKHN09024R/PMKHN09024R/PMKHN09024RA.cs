//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   仕入先マスタDBリモートオブジェクト
//                  :   PMKHN09024R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田　誠
// Date             :   2008.4.24
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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入先マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2008.4.24</br>
    /// <br></br>
    /// <br>Update Note: 2009.05.27  22018 鈴木 正臣</br>
    /// <br>           : SearchWithChildrenメソッドを追加。(マスメンにて親更新時に子も更新する必要がある為)</br>
    /// </remarks>
    [Serializable]
    public class SupplierDB : RemoteDB, ISupplierDB
    {
        /// <summary>
        /// 仕入先マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        /// </remarks>
        public SupplierDB() : base("PMKHN09026D", "Broadleaf.Application.Remoting.ParamData.SupplierWork", "SUPPLIERRF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一の仕入先マスタ情報を取得します。
        /// </summary>
        /// <param name="parabyte">SupplierWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタのキー値が一致する仕入先マスタ情報を取得します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                SupplierWork supplierWork = new SupplierWork();

                // XMLの読み込み
                supplierWork = (SupplierWork)XmlByteSerializer.Deserialize(parabyte, typeof(SupplierWork));

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref supplierWork, readMode, ref sqlConnection, ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(supplierWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SupplierDB.Read(ref byte[], int)", status);
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
        /// 単一の仕入先マスタ情報を取得します。
        /// </summary>
        /// <param name="supplierWork">SupplierWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタのキー値が一致する仕入先マスタ情報を取得します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        public int Read(ref SupplierWork supplierWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref supplierWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一の仕入先マスタ情報を取得します。
        /// </summary>
        /// <param name="supplierWork">SupplierWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタのキー値が一致する仕入先マスタ情報を取得します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        private int ReadProc(ref SupplierWork supplierWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "  SUPL.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SUPL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,SUPL.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SUPL.INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYMENTSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPHONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERKANARF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += " ,SUPL.ORDERHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,SUPL.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERPOSTNORF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERADDR1RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERADDR3RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERADDR4RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERTELNORF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERTELNO1RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERTELNO2RF" + Environment.NewLine;
                sqlText += " ,SUPL.PURECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYMENTMONTHCODERF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYMENTMONTHNAMERF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYMENTDAYRF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPCTAXLAYCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPCTAXATIONCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPENTERPRISECDRF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYEECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.STCKTTLAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYMENTCONDRF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYMENTTOTALDAYRF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYMENTSIGHTRF" + Environment.NewLine;
                sqlText += " ,SUPL.STOCKAGENTCODERF" + Environment.NewLine;
                sqlText += " ,SUPL.STOCKUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.STOCKMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.STOCKCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERNOTE1RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERNOTE2RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERNOTE3RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERNOTE4RF" + Environment.NewLine;
                sqlText += " ,SAGT.NAMERF AS STOCKAGENTNAMERF" + Environment.NewLine;
                sqlText += " ,MGSC.SECTIONGUIDENMRF AS MNGSECTIONNAMERF" + Environment.NewLine;
                sqlText += " ,INSC.SECTIONGUIDENMRF AS INPSECTIONNAMERF" + Environment.NewLine;
                sqlText += " ,PYSC.SECTIONGUIDENMRF AS PAYMENTSECTIONNAMERF" + Environment.NewLine;
                sqlText += " ,BSTP.GUIDENAMERF AS BUSINESSTYPENAMERF" + Environment.NewLine;
                sqlText += " ,AREA.GUIDENAMERF AS SALESAREANAMERF" + Environment.NewLine;
                sqlText += " ,PAYE.SUPPLIERNM1RF AS PAYEENAMERF" + Environment.NewLine;
                sqlText += " ,PAYE.SUPPLIERNM2RF AS PAYEENAME2RF" + Environment.NewLine;
                sqlText += " ,PAYE.SUPPLIERSNMRF AS PAYEESNMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SUPPLIERRF AS SUPL" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SUPPLIERRF AS PAYE" + Environment.NewLine;
                sqlText += "    ON  SUPL.ENTERPRISECODERF = PAYE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPL.PAYEECODERF = PAYE.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS SAGT" + Environment.NewLine;
                sqlText += "    ON  SUPL.ENTERPRISECODERF = SAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPL.STOCKAGENTCODERF = SAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS MGSC" + Environment.NewLine;
                sqlText += "    ON  SUPL.ENTERPRISECODERF = MGSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPL.MNGSECTIONCODERF = MGSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS INSC" + Environment.NewLine;
                sqlText += "    ON  SUPL.ENTERPRISECODERF = INSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPL.INPSECTIONCODERF = INSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS PYSC" + Environment.NewLine;
                sqlText += "    ON  SUPL.ENTERPRISECODERF = PYSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPL.PAYMENTSECTIONCODERF = PYSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS AREA" + Environment.NewLine;
                sqlText += "    ON  SUPL.ENTERPRISECODERF = AREA.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPL.SALESAREACODERF = AREA.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND AREA.USERGUIDEDIVCDRF = 21  -- 販売エリア区分" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS BSTP" + Environment.NewLine;
                sqlText += "    ON  SUPL.ENTERPRISECODERF = BSTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPL.BUSINESSTYPECODERF = BSTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND BSTP.USERGUIDEDIVCDRF = 33  -- 業種区分" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  SUPL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SUPL.SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                sqlCommand.CommandText += sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(supplierWork.EnterpriseCode);
                findSupplierCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.SupplierCd);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToSupplierWorkFromReader(ref myReader, ref supplierWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "SupplierDB.Read(ref SupplierWork, int, ref SqlConnection, ref SqlTransaction)", ex.Number);
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
        /// 仕入先マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">SupplierWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタのキー値が一致する仕入先マスタ情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(parabyte);

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SupplierDB.Delete(byte[])", status);
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
        /// 仕入先マスタ情報を物理削除します
        /// </summary>
        /// <param name="supplierList">仕入先マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierList に格納されている仕入先マスタ情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        public int Delete(ArrayList supplierList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(supplierList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 仕入先マスタ情報を物理削除します
        /// </summary>
        /// <param name="supplierList">仕入先マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierList に格納されている仕入先マスタ情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        private int DeleteProc(ArrayList supplierList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (supplierList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < supplierList.Count; i++)
                    {
                        SupplierWork supplierWork = supplierList[i] as SupplierWork;

                        # region [SELECT文]
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  SUPPLIERRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(supplierWork.EnterpriseCode);
                        findSupplierCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.SupplierCd);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != supplierWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  SUPPLIERRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(supplierWork.EnterpriseCode);
                            findSupplierCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.SupplierCd);
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
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "SupplierDB.Delete(ref ArrayList, ref SqlConnection, ref SqlTransaction)", ex.Number);
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
        /// 仕入先マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outsupplierList">検索結果</param>
        /// <param name="parasupplierWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタのキー値が一致する、全ての仕入先マスタ情報を取得します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        public int Search(out object outsupplierList, object parasupplierWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList _supplierList = null;
            SupplierWork supplierWork = null;

            outsupplierList = new CustomSerializeArrayList();

            try
            {
                if (parasupplierWork is SupplierWork)
                {
                    supplierWork = parasupplierWork as SupplierWork;
                }
                else if (parasupplierWork is ArrayList)
                {
                    if ((parasupplierWork as ArrayList).Count > 0)
                    {
                        supplierWork = (parasupplierWork as ArrayList)[0] as SupplierWork;
                    }
                }

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(out _supplierList, supplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);

                if (_supplierList != null)
                {
                    (outsupplierList as CustomSerializeArrayList).AddRange(_supplierList);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SupplierDB.Search(out object, object, int, LogicalMode)", status);
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
        /// 仕入先マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="supplierList">仕入先マスタ情報を格納する ArrayList</param>
        /// <param name="supplierWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタのキー値が一致する、全ての仕入先マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        public int Search(out ArrayList supplierList, SupplierWork supplierWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 DEL
            //return this.SearchProc(out supplierList, supplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
            return this.SearchProc(out supplierList, supplierWork, readMode, logicalMode, false, ref sqlConnection, ref sqlTransaction);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
        /// <summary>
        /// 仕入先マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outsupplierList">検索結果</param>
        /// <param name="parasupplierWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払先コードが一致する、全ての仕入先マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22018　鈴木 正臣</br>
        /// <br>Date       : 2009.5.27</br>
        public int SearchWithChildren( out object outsupplierList, object parasupplierWork, int readMode, ConstantManagement.LogicalMode logicalMode )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList _supplierList = null;
            SupplierWork supplierWork = null;

            outsupplierList = new CustomSerializeArrayList();

            try
            {
                if ( parasupplierWork is SupplierWork )
                {
                    supplierWork = parasupplierWork as SupplierWork;
                }
                else if ( parasupplierWork is ArrayList )
                {
                    if ( (parasupplierWork as ArrayList).Count > 0 )
                    {
                        supplierWork = (parasupplierWork as ArrayList)[0] as SupplierWork;
                    }
                }

                // コネクション生成
                sqlConnection = this.CreateSqlConnection( true );

                status = this.SearchWithChildren( out _supplierList, supplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction );

                if ( _supplierList != null )
                {
                    (outsupplierList as CustomSerializeArrayList).AddRange( _supplierList );
                }
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "SupplierDB.SearchWithChildren(out object, object, int, LogicalMode)", status );
            }
            finally
            {
                if ( sqlTransaction != null )
                {
                    if ( sqlTransaction.Connection != null )
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if ( sqlConnection != null )
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        /// <summary>
        /// 仕入先マスタ情報のリストを取得します。（親仕入先＋全ての子仕入先）
        /// </summary>
        /// <param name="supplierList">仕入先マスタ情報を格納する ArrayList</param>
        /// <param name="supplierWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 支払先コードが一致する、全ての仕入先マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22018　鈴木 正臣</br>
        /// <br>Date       : 2009.5.27</br>
        public int SearchWithChildren( out ArrayList supplierList, SupplierWork supplierWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            return this.SearchProc( out supplierList, supplierWork, readMode, logicalMode, true, ref sqlConnection, ref sqlTransaction );
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD

        /// <summary>
        /// 仕入先マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="supplierList">仕入先マスタ情報を格納する ArrayList</param>
        /// <param name="supplierWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="isSearchPayeeWithChildren"></param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入先マスタのキー値が一致する、全ての仕入先マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 DEL
        //private int SearchProc(out ArrayList supplierList, SupplierWork supplierWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
        private int SearchProc( out ArrayList supplierList, SupplierWork supplierWork, int readMode, ConstantManagement.LogicalMode logicalMode, bool isSearchPayeeWithChildren, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  SUPL.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,SUPL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,SUPL.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,SUPL.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SUPL.INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYMENTSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERNM1RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERNM2RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPHONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERKANARF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += " ,SUPL.ORDERHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,SUPL.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERPOSTNORF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERADDR1RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERADDR3RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERADDR4RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERTELNORF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERTELNO1RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERTELNO2RF" + Environment.NewLine;
                sqlText += " ,SUPL.PURECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYMENTMONTHCODERF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYMENTMONTHNAMERF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYMENTDAYRF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPCTAXLAYCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPCTAXATIONCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPENTERPRISECDRF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYEECODERF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.STCKTTLAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYMENTCONDRF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYMENTTOTALDAYRF" + Environment.NewLine;
                sqlText += " ,SUPL.PAYMENTSIGHTRF" + Environment.NewLine;
                sqlText += " ,SUPL.STOCKAGENTCODERF" + Environment.NewLine;
                sqlText += " ,SUPL.STOCKUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.STOCKMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.STOCKCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,SUPL.NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERNOTE1RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERNOTE2RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERNOTE3RF" + Environment.NewLine;
                sqlText += " ,SUPL.SUPPLIERNOTE4RF" + Environment.NewLine;
                sqlText += " ,SAGT.NAMERF AS STOCKAGENTNAMERF" + Environment.NewLine;
                sqlText += " ,MGSC.SECTIONGUIDENMRF AS MNGSECTIONNAMERF" + Environment.NewLine;
                sqlText += " ,INSC.SECTIONGUIDENMRF AS INPSECTIONNAMERF" + Environment.NewLine;
                sqlText += " ,PYSC.SECTIONGUIDENMRF AS PAYMENTSECTIONNAMERF" + Environment.NewLine;
                sqlText += " ,BSTP.GUIDENAMERF AS BUSINESSTYPENAMERF" + Environment.NewLine;
                sqlText += " ,AREA.GUIDENAMERF AS SALESAREANAMERF" + Environment.NewLine;
                sqlText += " ,PAYE.SUPPLIERNM1RF AS PAYEENAMERF" + Environment.NewLine;
                sqlText += " ,PAYE.SUPPLIERNM2RF AS PAYEENAME2RF" + Environment.NewLine;
                sqlText += " ,PAYE.SUPPLIERSNMRF AS PAYEESNMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SUPPLIERRF AS SUPL" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SUPPLIERRF AS PAYE" + Environment.NewLine;
                sqlText += "    ON  SUPL.ENTERPRISECODERF = PAYE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPL.PAYEECODERF = PAYE.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS SAGT" + Environment.NewLine;
                sqlText += "    ON  SUPL.ENTERPRISECODERF = SAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPL.STOCKAGENTCODERF = SAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS MGSC" + Environment.NewLine;
                sqlText += "    ON  SUPL.ENTERPRISECODERF = MGSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPL.MNGSECTIONCODERF = MGSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS INSC" + Environment.NewLine;
                sqlText += "    ON  SUPL.ENTERPRISECODERF = INSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPL.INPSECTIONCODERF = INSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS PYSC" + Environment.NewLine;
                sqlText += "    ON  SUPL.ENTERPRISECODERF = PYSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPL.PAYMENTSECTIONCODERF = PYSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS AREA" + Environment.NewLine;
                sqlText += "    ON  SUPL.ENTERPRISECODERF = AREA.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPL.SALESAREACODERF = AREA.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND AREA.USERGUIDEDIVCDRF = 21  -- 販売エリア区分" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS BSTP" + Environment.NewLine;
                sqlText += "    ON  SUPL.ENTERPRISECODERF = BSTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND SUPL.BUSINESSTYPECODERF = BSTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND BSTP.USERGUIDEDIVCDRF = 33  -- 業種区分" + Environment.NewLine;
                sqlCommand.CommandText += sqlText;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 DEL
                //sqlCommand.CommandText += MakeWhereString(ref sqlCommand, supplierWork, logicalMode);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
                sqlCommand.CommandText += MakeWhereString( ref sqlCommand, supplierWork, logicalMode, isSearchPayeeWithChildren );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToSupplierWorkFromReader(ref myReader));
                }

                if (al.Count > 0)
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
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "SupplierDB.Search(out ArrayList, SupplierWork, int, LogicalMode, ref SqlConnection, ref SqlTransaction)", ex.Number);
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

            supplierList = al;

            return status;
        }
        # endregion

        # region [Write]
        /// <summary>
        /// 仕入先マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="supplierWork">追加・更新する仕入先マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork に格納されている仕入先マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        public int Write(ref object supplierWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = this.CastToArrayListFromPara(supplierWork);

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);

                // 戻り値セット
                supplierWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SupplierDB.Write(ref object)", status);
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
        /// 仕入先マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="supplierList">追加・更新する仕入先マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierList に格納されている仕入先マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        public int Write(ref ArrayList supplierList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref supplierList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 仕入先マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="supplierList">追加・更新する仕入先マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierList に格納されている仕入先マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        private int WriteProc(ref ArrayList supplierList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (supplierList != null)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 DEL
                    //string sqlText = string.Empty;
                    //sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 DEL

                    for (int i = 0; i < supplierList.Count; i++)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
                        string sqlText = string.Empty;
                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD

                        SupplierWork supplierWork = supplierList[i] as SupplierWork;

                        # region [SELECT文]
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  SUPPLIERRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
                        SqlParameter findSupplierCd = sqlCommand.Parameters.Add( "@FINDSUPPLIERCD", SqlDbType.Int );

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(supplierWork.EnterpriseCode);
                        findSupplierCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.SupplierCd);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != supplierWork.UpdateDateTime)
                            {
                                if (supplierWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  SUPPLIERRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,SUPPLIERCDRF = @SUPPLIERCD" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF = @MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF = @INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,PAYMENTSECTIONCODERF = @PAYMENTSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,SUPPLIERNM1RF = @SUPPLIERNM1" + Environment.NewLine;
                            sqlText += " ,SUPPLIERNM2RF = @SUPPLIERNM2" + Environment.NewLine;
                            sqlText += " ,SUPPHONORIFICTITLERF = @SUPPHONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,SUPPLIERKANARF = @SUPPLIERKANA" + Environment.NewLine;
                            sqlText += " ,SUPPLIERSNMRF = @SUPPLIERSNM" + Environment.NewLine;
                            sqlText += " ,ORDERHONORIFICTTLRF = @ORDERHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF = @BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF = @SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,SUPPLIERPOSTNORF = @SUPPLIERPOSTNO" + Environment.NewLine;
                            sqlText += " ,SUPPLIERADDR1RF = @SUPPLIERADDR1" + Environment.NewLine;
                            sqlText += " ,SUPPLIERADDR3RF = @SUPPLIERADDR3" + Environment.NewLine;
                            sqlText += " ,SUPPLIERADDR4RF = @SUPPLIERADDR4" + Environment.NewLine;
                            sqlText += " ,SUPPLIERTELNORF = @SUPPLIERTELNO" + Environment.NewLine;
                            sqlText += " ,SUPPLIERTELNO1RF = @SUPPLIERTELNO1" + Environment.NewLine;
                            sqlText += " ,SUPPLIERTELNO2RF = @SUPPLIERTELNO2" + Environment.NewLine;
                            sqlText += " ,PURECODERF = @PURECODE" + Environment.NewLine;
                            sqlText += " ,PAYMENTMONTHCODERF = @PAYMENTMONTHCODE" + Environment.NewLine;
                            sqlText += " ,PAYMENTMONTHNAMERF = @PAYMENTMONTHNAME" + Environment.NewLine;
                            sqlText += " ,PAYMENTDAYRF = @PAYMENTDAY" + Environment.NewLine;
                            sqlText += " ,SUPPCTAXLAYREFCDRF = @SUPPCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,SUPPCTAXLAYCDRF = @SUPPCTAXLAYCD" + Environment.NewLine;
                            sqlText += " ,SUPPCTAXATIONCDRF = @SUPPCTAXATIONCD" + Environment.NewLine;
                            sqlText += " ,SUPPENTERPRISECDRF = @SUPPENTERPRISECD" + Environment.NewLine;
                            sqlText += " ,PAYEECODERF = @PAYEECODE" + Environment.NewLine;
                            sqlText += " ,SUPPLIERATTRIBUTEDIVRF = @SUPPLIERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,SUPPTTLAMNTDSPWAYCDRF = @SUPPTTLAMNTDSPWAYCD" + Environment.NewLine;
                            sqlText += " ,STCKTTLAMNTDSPWAYREFRF = @STCKTTLAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,PAYMENTCONDRF = @PAYMENTCOND" + Environment.NewLine;
                            sqlText += " ,PAYMENTTOTALDAYRF = @PAYMENTTOTALDAY" + Environment.NewLine;
                            sqlText += " ,PAYMENTSIGHTRF = @PAYMENTSIGHT" + Environment.NewLine;
                            sqlText += " ,STOCKAGENTCODERF = @STOCKAGENTCODE" + Environment.NewLine;
                            sqlText += " ,STOCKUNPRCFRCPROCCDRF = @STOCKUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,STOCKMONEYFRCPROCCDRF = @STOCKMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,STOCKCNSTAXFRCPROCCDRF = @STOCKCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF = @NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,SUPPLIERNOTE1RF = @SUPPLIERNOTE1" + Environment.NewLine;
                            sqlText += " ,SUPPLIERNOTE2RF = @SUPPLIERNOTE2" + Environment.NewLine;
                            sqlText += " ,SUPPLIERNOTE3RF = @SUPPLIERNOTE3" + Environment.NewLine;
                            sqlText += " ,SUPPLIERNOTE4RF = @SUPPLIERNOTE4" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(supplierWork.EnterpriseCode);
                            findSupplierCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.SupplierCd);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)supplierWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (supplierWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO SUPPLIERRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                            sqlText += " ,MNGSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,INPSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,PAYMENTSECTIONCODERF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERNM1RF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERNM2RF" + Environment.NewLine;
                            sqlText += " ,SUPPHONORIFICTITLERF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERKANARF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERSNMRF" + Environment.NewLine;
                            sqlText += " ,ORDERHONORIFICTTLRF" + Environment.NewLine;
                            sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                            sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERPOSTNORF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERADDR1RF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERADDR3RF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERADDR4RF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERTELNORF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERTELNO1RF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERTELNO2RF" + Environment.NewLine;
                            sqlText += " ,PURECODERF" + Environment.NewLine;
                            sqlText += " ,PAYMENTMONTHCODERF" + Environment.NewLine;
                            sqlText += " ,PAYMENTMONTHNAMERF" + Environment.NewLine;
                            sqlText += " ,PAYMENTDAYRF" + Environment.NewLine;
                            sqlText += " ,SUPPCTAXLAYREFCDRF" + Environment.NewLine;
                            sqlText += " ,SUPPCTAXLAYCDRF" + Environment.NewLine;
                            sqlText += " ,SUPPCTAXATIONCDRF" + Environment.NewLine;
                            sqlText += " ,SUPPENTERPRISECDRF" + Environment.NewLine;
                            sqlText += " ,PAYEECODERF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERATTRIBUTEDIVRF" + Environment.NewLine;
                            sqlText += " ,SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
                            sqlText += " ,STCKTTLAMNTDSPWAYREFRF" + Environment.NewLine;
                            sqlText += " ,PAYMENTCONDRF" + Environment.NewLine;
                            sqlText += " ,PAYMENTTOTALDAYRF" + Environment.NewLine;
                            sqlText += " ,PAYMENTSIGHTRF" + Environment.NewLine;
                            sqlText += " ,STOCKAGENTCODERF" + Environment.NewLine;
                            sqlText += " ,STOCKUNPRCFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,STOCKMONEYFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,STOCKCNSTAXFRCPROCCDRF" + Environment.NewLine;
                            sqlText += " ,NTIMECALCSTDATERF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERNOTE1RF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERNOTE2RF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERNOTE3RF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERNOTE4RF" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                            sqlText += " ,@MNGSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@INPSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@PAYMENTSECTIONCODE" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERNM1" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERNM2" + Environment.NewLine;
                            sqlText += " ,@SUPPHONORIFICTITLE" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERKANA" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERSNM" + Environment.NewLine;
                            sqlText += " ,@ORDERHONORIFICTTL" + Environment.NewLine;
                            sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                            sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERPOSTNO" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERADDR1" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERADDR3" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERADDR4" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERTELNO" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERTELNO1" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERTELNO2" + Environment.NewLine;
                            sqlText += " ,@PURECODE" + Environment.NewLine;
                            sqlText += " ,@PAYMENTMONTHCODE" + Environment.NewLine;
                            sqlText += " ,@PAYMENTMONTHNAME" + Environment.NewLine;
                            sqlText += " ,@PAYMENTDAY" + Environment.NewLine;
                            sqlText += " ,@SUPPCTAXLAYREFCD" + Environment.NewLine;
                            sqlText += " ,@SUPPCTAXLAYCD" + Environment.NewLine;
                            sqlText += " ,@SUPPCTAXATIONCD" + Environment.NewLine;
                            sqlText += " ,@SUPPENTERPRISECD" + Environment.NewLine;
                            sqlText += " ,@PAYEECODE" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERATTRIBUTEDIV" + Environment.NewLine;
                            sqlText += " ,@SUPPTTLAMNTDSPWAYCD" + Environment.NewLine;
                            sqlText += " ,@STCKTTLAMNTDSPWAYREF" + Environment.NewLine;
                            sqlText += " ,@PAYMENTCOND" + Environment.NewLine;
                            sqlText += " ,@PAYMENTTOTALDAY" + Environment.NewLine;
                            sqlText += " ,@PAYMENTSIGHT" + Environment.NewLine;
                            sqlText += " ,@STOCKAGENTCODE" + Environment.NewLine;
                            sqlText += " ,@STOCKUNPRCFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@STOCKMONEYFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@STOCKCNSTAXFRCPROCCD" + Environment.NewLine;
                            sqlText += " ,@NTIMECALCSTDATE" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERNOTE1" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERNOTE2" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERNOTE3" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERNOTE4" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)supplierWork;
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
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraInpSectionCode = sqlCommand.Parameters.Add("@INPSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraPaymentSectionCode = sqlCommand.Parameters.Add("@PAYMENTSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraSupplierNm1 = sqlCommand.Parameters.Add("@SUPPLIERNM1", SqlDbType.NVarChar);
                        SqlParameter paraSupplierNm2 = sqlCommand.Parameters.Add("@SUPPLIERNM2", SqlDbType.NVarChar);
                        SqlParameter paraSuppHonorificTitle = sqlCommand.Parameters.Add("@SUPPHONORIFICTITLE", SqlDbType.NVarChar);
                        SqlParameter paraSupplierKana = sqlCommand.Parameters.Add("@SUPPLIERKANA", SqlDbType.NVarChar);
                        SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                        SqlParameter paraOrderHonorificTtl = sqlCommand.Parameters.Add("@ORDERHONORIFICTTL", SqlDbType.NVarChar);
                        SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                        SqlParameter paraSupplierPostNo = sqlCommand.Parameters.Add("@SUPPLIERPOSTNO", SqlDbType.NVarChar);
                        SqlParameter paraSupplierAddr1 = sqlCommand.Parameters.Add("@SUPPLIERADDR1", SqlDbType.NVarChar);
                        SqlParameter paraSupplierAddr3 = sqlCommand.Parameters.Add("@SUPPLIERADDR3", SqlDbType.NVarChar);
                        SqlParameter paraSupplierAddr4 = sqlCommand.Parameters.Add("@SUPPLIERADDR4", SqlDbType.NVarChar);
                        SqlParameter paraSupplierTelNo = sqlCommand.Parameters.Add("@SUPPLIERTELNO", SqlDbType.NVarChar);
                        SqlParameter paraSupplierTelNo1 = sqlCommand.Parameters.Add("@SUPPLIERTELNO1", SqlDbType.NVarChar);
                        SqlParameter paraSupplierTelNo2 = sqlCommand.Parameters.Add("@SUPPLIERTELNO2", SqlDbType.NVarChar);
                        SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
                        SqlParameter paraPaymentMonthCode = sqlCommand.Parameters.Add("@PAYMENTMONTHCODE", SqlDbType.Int);
                        SqlParameter paraPaymentMonthName = sqlCommand.Parameters.Add("@PAYMENTMONTHNAME", SqlDbType.NVarChar);
                        SqlParameter paraPaymentDay = sqlCommand.Parameters.Add("@PAYMENTDAY", SqlDbType.Int);
                        SqlParameter paraSuppCTaxLayRefCd = sqlCommand.Parameters.Add("@SUPPCTAXLAYREFCD", SqlDbType.Int);
                        SqlParameter paraSuppCTaxLayCd = sqlCommand.Parameters.Add("@SUPPCTAXLAYCD", SqlDbType.Int);
                        SqlParameter paraSuppCTaxationCd = sqlCommand.Parameters.Add("@SUPPCTAXATIONCD", SqlDbType.Int);
                        SqlParameter paraSuppEnterpriseCd = sqlCommand.Parameters.Add("@SUPPENTERPRISECD", SqlDbType.NChar);
                        SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                        SqlParameter paraSupplierAttributeDiv = sqlCommand.Parameters.Add("@SUPPLIERATTRIBUTEDIV", SqlDbType.Int);
                        SqlParameter paraSuppTtlAmntDspWayCd = sqlCommand.Parameters.Add("@SUPPTTLAMNTDSPWAYCD", SqlDbType.Int);
                        SqlParameter paraStckTtlAmntDspWayRef = sqlCommand.Parameters.Add("@STCKTTLAMNTDSPWAYREF", SqlDbType.Int);
                        SqlParameter paraPaymentCond = sqlCommand.Parameters.Add("@PAYMENTCOND", SqlDbType.Int);
                        SqlParameter paraPaymentTotalDay = sqlCommand.Parameters.Add("@PAYMENTTOTALDAY", SqlDbType.Int);
                        SqlParameter paraPaymentSight = sqlCommand.Parameters.Add("@PAYMENTSIGHT", SqlDbType.Int);
                        SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
                        SqlParameter paraStockUnPrcFrcProcCd = sqlCommand.Parameters.Add("@STOCKUNPRCFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraStockMoneyFrcProcCd = sqlCommand.Parameters.Add("@STOCKMONEYFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraStockCnsTaxFrcProcCd = sqlCommand.Parameters.Add("@STOCKCNSTAXFRCPROCCD", SqlDbType.Int);
                        SqlParameter paraNTimeCalcStDate = sqlCommand.Parameters.Add("@NTIMECALCSTDATE", SqlDbType.Int);
                        SqlParameter paraSupplierNote1 = sqlCommand.Parameters.Add("@SUPPLIERNOTE1", SqlDbType.NVarChar);
                        SqlParameter paraSupplierNote2 = sqlCommand.Parameters.Add("@SUPPLIERNOTE2", SqlDbType.NVarChar);
                        SqlParameter paraSupplierNote3 = sqlCommand.Parameters.Add("@SUPPLIERNOTE3", SqlDbType.NVarChar);
                        SqlParameter paraSupplierNote4 = sqlCommand.Parameters.Add("@SUPPLIERNOTE4", SqlDbType.NVarChar);
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(supplierWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(supplierWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(supplierWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(supplierWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(supplierWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(supplierWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(supplierWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(supplierWork.LogicalDeleteCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.SupplierCd);
                        paraMngSectionCode.Value = SqlDataMediator.SqlSetString(supplierWork.MngSectionCode);
                        paraInpSectionCode.Value = SqlDataMediator.SqlSetString(supplierWork.InpSectionCode);
                        paraPaymentSectionCode.Value = SqlDataMediator.SqlSetString(supplierWork.PaymentSectionCode);
                        paraSupplierNm1.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierNm1);
                        paraSupplierNm2.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierNm2);
                        paraSuppHonorificTitle.Value = SqlDataMediator.SqlSetString(supplierWork.SuppHonorificTitle);
                        paraSupplierKana.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierKana);
                        paraSupplierSnm.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierSnm);
                        paraOrderHonorificTtl.Value = SqlDataMediator.SqlSetString(supplierWork.OrderHonorificTtl);
                        paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(supplierWork.BusinessTypeCode);
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(supplierWork.SalesAreaCode);
                        paraSupplierPostNo.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierPostNo);
                        paraSupplierAddr1.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierAddr1);
                        paraSupplierAddr3.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierAddr3);
                        paraSupplierAddr4.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierAddr4);
                        paraSupplierTelNo.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierTelNo);
                        paraSupplierTelNo1.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierTelNo1);
                        paraSupplierTelNo2.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierTelNo2);
                        paraPureCode.Value = SqlDataMediator.SqlSetInt32(supplierWork.PureCode);
                        paraPaymentMonthCode.Value = SqlDataMediator.SqlSetInt32(supplierWork.PaymentMonthCode);
                        paraPaymentMonthName.Value = SqlDataMediator.SqlSetString(supplierWork.PaymentMonthName);
                        paraPaymentDay.Value = SqlDataMediator.SqlSetInt32(supplierWork.PaymentDay);
                        paraSuppCTaxLayRefCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.SuppCTaxLayRefCd);
                        paraSuppCTaxLayCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.SuppCTaxLayCd);
                        paraSuppCTaxationCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.SuppCTaxationCd);
                        paraSuppEnterpriseCd.Value = SqlDataMediator.SqlSetString(supplierWork.SuppEnterpriseCd);
                        paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(supplierWork.PayeeCode);
                        paraSupplierAttributeDiv.Value = SqlDataMediator.SqlSetInt32(supplierWork.SupplierAttributeDiv);
                        paraSuppTtlAmntDspWayCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.SuppTtlAmntDspWayCd);
                        paraStckTtlAmntDspWayRef.Value = SqlDataMediator.SqlSetInt32(supplierWork.StckTtlAmntDspWayRef);
                        paraPaymentCond.Value = SqlDataMediator.SqlSetInt32(supplierWork.PaymentCond);
                        paraPaymentTotalDay.Value = SqlDataMediator.SqlSetInt32(supplierWork.PaymentTotalDay);
                        paraPaymentSight.Value = SqlDataMediator.SqlSetInt32(supplierWork.PaymentSight);
                        paraStockAgentCode.Value = SqlDataMediator.SqlSetString(supplierWork.StockAgentCode);
                        paraStockUnPrcFrcProcCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.StockUnPrcFrcProcCd);
                        paraStockMoneyFrcProcCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.StockMoneyFrcProcCd);
                        paraStockCnsTaxFrcProcCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.StockCnsTaxFrcProcCd);
                        paraNTimeCalcStDate.Value = SqlDataMediator.SqlSetInt32(supplierWork.NTimeCalcStDate);
                        paraSupplierNote1.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierNote1);
                        paraSupplierNote2.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierNote2);
                        paraSupplierNote3.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierNote3);
                        paraSupplierNote4.Value = SqlDataMediator.SqlSetString(supplierWork.SupplierNote4);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(supplierWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "SupplierDB.Write(ref ArrayList, ref SqlConnection, ref SqlTransaction)", ex.Number);
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

            supplierList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// 仕入先マスタ情報を論理削除します。
        /// </summary>
        /// <param name="supplierWork">論理削除する仕入先マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork に格納されている仕入先マスタ情報を論理削除します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        public int LogicalDelete(ref object supplierWork)
        {
            return this.LogicalDelete(ref supplierWork, 0);
        }

        /// <summary>
        /// 仕入先マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="supplierWork">論理削除を解除する仕入先マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork に格納されている仕入先マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        public int RevivalLogicalDelete(ref object supplierWork)
        {
            return this.LogicalDelete(ref supplierWork, 1);
        }

        /// <summary>
        /// 仕入先マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="supplierWork">論理削除を操作する仕入先マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork に格納されている仕入先マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        private int LogicalDelete(ref object supplierWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(supplierWork);

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SupplierDB.LogicalDelete(ref object, int[" + procMode.ToString() + "])", status);
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
        /// 仕入先マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="supplierList">論理削除を操作する仕入先マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork に格納されている仕入先マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        public int LogicalDelete(ref ArrayList supplierList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref supplierList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 仕入先マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="supplierList">論理削除を操作する仕入先マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : supplierWork に格納されている仕入先マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        private int LogicalDeleteProc(ref ArrayList supplierList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (supplierList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < supplierList.Count; i++)
                    {
                        SupplierWork supplierWork = supplierList[i] as SupplierWork;

                        # region [SELECT文]
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  SUPPLIERRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(supplierWork.EnterpriseCode);
                        findSupplierCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.SupplierCd);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != supplierWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  SUPPLIERRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(supplierWork.EnterpriseCode);
                            findSupplierCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.SupplierCd);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)supplierWork;
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
                            else if (logicalDelCd == 0) supplierWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else supplierWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                supplierWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(supplierWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(supplierWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(supplierWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(supplierWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(supplierWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(supplierWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "SupplierDB.LogicalDelete(ref ArrayList, ref SqlConnection, ref SqlTransaction)", ex.Number);
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

            supplierList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="supplierWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 DEL
        //private string MakeWhereString(ref SqlCommand sqlCommand, SupplierWork supplierWork, ConstantManagement.LogicalMode logicalMode)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
        private string MakeWhereString(ref SqlCommand sqlCommand, SupplierWork supplierWork, ConstantManagement.LogicalMode logicalMode, bool isSearchPayeeWithChildren)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  SUPL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(supplierWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND SUPL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND SUPL.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }


            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 DEL
            //// 仕入先コード
            //if (supplierWork.SupplierCd > 0)
            //{
            //    retstring += "  SUPL.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
            //    SqlParameter findSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
            //    findSupplierCd.Value = SqlDataMediator.SqlSetInt32(supplierWork.SupplierCd);
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
            // 仕入先コード
            if ( supplierWork.SupplierCd > 0 )
            {
                if ( isSearchPayeeWithChildren == false )
                {
                    // 通常の仕入先検索(Readと同じ機能)
                    retstring += "  AND SUPL.SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                    SqlParameter findSupplierCd = sqlCommand.Parameters.Add( "@FINDSUPPLIERCD", SqlDbType.Int );
                    findSupplierCd.Value = SqlDataMediator.SqlSetInt32( supplierWork.SupplierCd );
                }
                else
                {
                    // 支払先(親)+子検索
                    retstring += "  AND SUPL.PAYEECODERF = @FINDSUPPLIERCD" + Environment.NewLine;
                    SqlParameter findSupplierCd = sqlCommand.Parameters.Add( "@FINDSUPPLIERCD", SqlDbType.Int );
                    findSupplierCd.Value = SqlDataMediator.SqlSetInt32( supplierWork.SupplierCd );
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD

            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SupplierWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SupplierWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        /// </remarks>
        private SupplierWork CopyToSupplierWorkFromReader(ref SqlDataReader myReader)
        {
            SupplierWork supplierWork = new SupplierWork();

            this.CopyToSupplierWorkFromReader(ref myReader, ref supplierWork);

            return supplierWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → SupplierWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="supplierWork">SupplierWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        /// </remarks>
        private void CopyToSupplierWorkFromReader(ref SqlDataReader myReader, ref SupplierWork supplierWork)
        {
            if (myReader != null && supplierWork != null)
            {
                # region クラスへ格納
                supplierWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                supplierWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                supplierWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                supplierWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                supplierWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                supplierWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                supplierWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                supplierWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                supplierWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                supplierWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                supplierWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
                supplierWork.PaymentSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTSECTIONCODERF"));
                supplierWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                supplierWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                supplierWork.SuppHonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPHONORIFICTITLERF"));
                supplierWork.SupplierKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERKANARF"));
                supplierWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                supplierWork.OrderHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERHONORIFICTTLRF"));
                supplierWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                supplierWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                supplierWork.SupplierPostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERPOSTNORF"));
                supplierWork.SupplierAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR1RF"));
                supplierWork.SupplierAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR3RF"));
                supplierWork.SupplierAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERADDR4RF"));
                supplierWork.SupplierTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNORF"));
                supplierWork.SupplierTelNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNO1RF"));
                supplierWork.SupplierTelNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERTELNO2RF"));
                supplierWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                supplierWork.PaymentMonthCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONTHCODERF"));
                supplierWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
                supplierWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
                supplierWork.SuppCTaxLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYREFCDRF"));
                supplierWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
                supplierWork.SuppCTaxationCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXATIONCDRF"));
                supplierWork.SuppEnterpriseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPENTERPRISECDRF"));
                supplierWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                supplierWork.SupplierAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERATTRIBUTEDIVRF"));
                supplierWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
                supplierWork.StckTtlAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STCKTTLAMNTDSPWAYREFRF"));
                supplierWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));
                supplierWork.PaymentTotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTTOTALDAYRF"));
                supplierWork.PaymentSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSIGHTRF"));
                supplierWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                supplierWork.StockUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNPRCFRCPROCCDRF"));
                supplierWork.StockMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMONEYFRCPROCCDRF"));
                supplierWork.StockCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKCNSTAXFRCPROCCDRF"));
                supplierWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
                supplierWork.SupplierNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE1RF"));
                supplierWork.SupplierNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE2RF"));
                supplierWork.SupplierNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE3RF"));
                supplierWork.SupplierNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNOTE4RF"));
                supplierWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                supplierWork.MngSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONNAMERF"));
                supplierWork.InpSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONNAMERF"));
                supplierWork.PaymentSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTSECTIONNAMERF"));
                supplierWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
                supplierWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                supplierWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
                supplierWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
                supplierWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                # endregion
            }
        }
        # endregion

        # region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SupplierWork[] SupplierWorkArray = null;

            if (paraobj != null)
                try
                {
                    // ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    // パラメータクラスの場合
                    if (paraobj is SupplierWork)
                    {
                        SupplierWork wkSupplierWork = paraobj as SupplierWork;
                        if (wkSupplierWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSupplierWork);
                        }
                    }

                    // byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SupplierWorkArray = (SupplierWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SupplierWork[]));
                        }
                        catch (Exception) { }
                        if (SupplierWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SupplierWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SupplierWork wkSupplierWork = (SupplierWork)XmlByteSerializer.Deserialize(byteArray, typeof(SupplierWork));
                                if (wkSupplierWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSupplierWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    // 特に何もしない
                }

            return retal;
        }
        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
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
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2008.4.24</br>
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
        # endregion
    }
}

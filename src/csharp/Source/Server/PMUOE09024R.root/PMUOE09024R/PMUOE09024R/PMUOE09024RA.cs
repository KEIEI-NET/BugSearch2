//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE 発注先マスタDBリモートオブジェクト
//                  :   PMUOE09024R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 疋田 勇人
// Date             :   2008.06.06
//----------------------------------------------------------------------
// Update Note      :   2011/12/15 yangmj Redmine#27386トヨタUOEWebタクティー品番の発注対応
//----------------------------------------------------------------------
// Update Note      :   2012/09/10 高川 悟
//                  :   BL管理ユーザーコード対応
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
    /// UOE 発注先マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE 発注先マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: e-Parts対応</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2009.05.29</br>
    /// </remarks>
    [Serializable]
    public class UOESupplierDB : RemoteWithAppLockDB, IUOESupplierDB, IGetSyncdataList
    {
        /// <summary>
        /// UOE 発注先マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public UOESupplierDB() : base("PMUOE09026D", "Broadleaf.Application.Remoting.ParamData.UOESupplierWork", "UOESupplierRF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一のUOE 発注先マスタ情報を取得します。
        /// </summary>
        /// <param name="uoeSupplierObj">UOESupplierWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE 発注先マスタのキー値が一致するUOE 発注先マスタ情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Read(ref object uoeSupplierObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                UOESupplierWork uoeSupplierWork = uoeSupplierObj as UOESupplierWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref uoeSupplierWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一のUOE 発注先マスタ情報を取得します。
        /// </summary>
        /// <param name="uoeSupplierWork">UOESupplierWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE 発注先マスタのキー値が一致するUOE 発注先マスタ情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Read(ref UOESupplierWork uoeSupplierWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref uoeSupplierWork, readMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 単一のUOE 発注先マスタ情報を取得します。
        /// </summary>
        /// <param name="uoeSupplierWork">UOESupplierWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE 発注先マスタのキー値が一致するUOE 発注先マスタ情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private int ReadProc(ref UOESupplierWork uoeSupplierWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT UOESUPP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.TELNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETERMINALCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEHOSTCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTPASSWORDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEIDNUMRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.COMMASSEMBLYIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CONNECTVERSIONDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESHIPSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESALSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESERVSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.RECEIVECONDITIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUBSTPARTSNODIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.PARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LISTPRICEUSEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.STOCKSLIPDTRECVDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CHECKCODEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BUSINESSCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESVDSECTIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEDELIGOODSDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BOCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERRATERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD3RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD4RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD5RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD6RF" + Environment.NewLine;
                //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD3RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD4RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD5RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD6RF" + Environment.NewLine;
                //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
                sqlText += "    ,UOESUPP.INSTRUMENTNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETESTMODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEITEMCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.HONDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ANSWERSAVEFOLDERRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.MAZDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMERGENCYDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.DAIHATSUORDREDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUPPLIERCDRF" + Environment.NewLine;

                // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                sqlText += "    ,UOESUPP.LOGINTIMEOUTVALRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESTOCKCHECKURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEFORCEDTERMURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOELOGINURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.INQORDDIVCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSPASSWORDRF" + Environment.NewLine;
                // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                sqlText += "    ,SECINFO.SECTIONGUIDENMRF SHIPSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO1.SECTIONGUIDENMRF SALSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO2.SECTIONGUIDENMRF RESERVSECTNM" + Environment.NewLine;
                sqlText += "    ,MAKERU.MAKERNAMERF MAKERNM" + Environment.NewLine;
                sqlText += "    ,MAKERU1.MAKERNAMERF ENABLEODRMAKERNM1" + Environment.NewLine;
                sqlText += "    ,MAKERU2.MAKERNAMERF ENABLEODRMAKERNM2" + Environment.NewLine;
                sqlText += "    ,MAKERU3.MAKERNAMERF ENABLEODRMAKERNM3" + Environment.NewLine;
                sqlText += "    ,MAKERU4.MAKERNAMERF ENABLEODRMAKERNM4" + Environment.NewLine;
                sqlText += "    ,MAKERU5.MAKERNAMERF ENABLEODRMAKERNM5" + Environment.NewLine;
                sqlText += "    ,MAKERU6.MAKERNAMERF ENABLEODRMAKERNM6" + Environment.NewLine;
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                sqlText += "    ,UOESUPP.BLMNGUSERCODERF" + Environment.NewLine;
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
                sqlText += " FROM UOESUPPLIERRF UOESUPP" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO ON UOESUPP.ENTERPRISECODERF=SECINFO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO1 ON UOESUPP.ENTERPRISECODERF=SECINFO1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO1.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO2 ON UOESUPP.ENTERPRISECODERF=SECINFO2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO2.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU ON UOESUPP.ENTERPRISECODERF=MAKERU.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.GOODSMAKERCDRF=MAKERU.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU1 ON UOESUPP.ENTERPRISECODERF=MAKERU1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD1RF=MAKERU1.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU2 ON UOESUPP.ENTERPRISECODERF=MAKERU2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD2RF=MAKERU2.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU3 ON UOESUPP.ENTERPRISECODERF=MAKERU3.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD3RF=MAKERU3.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU4 ON UOESUPP.ENTERPRISECODERF=MAKERU4.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD4RF=MAKERU4.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU5 ON UOESUPP.ENTERPRISECODERF=MAKERU5.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD5RF=MAKERU5.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU6 ON UOESUPP.ENTERPRISECODERF=MAKERU6.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD6RF=MAKERU6.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " WHERE UOESUPP.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                sqlText += "    AND UOESUPP.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);
#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToUOESupplierWorkFromReader(ref myReader, ref uoeSupplierWork);
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
        /// UOE 発注先マスタ情報を物理削除します
        /// </summary>
        /// <param name="uoeSupplierList">物理削除するUOE 発注先マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE 発注先マスタのキー値が一致するUOE 発注先マスタ情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Delete(object uoeSupplierList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = uoeSupplierList as ArrayList;

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
        /// UOE 発注先マスタ情報を物理削除します
        /// </summary>
        /// <param name="uoeSupplierList">UOE 発注先マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierList に格納されているUOE 発注先マスタ情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Delete(ArrayList uoeSupplierList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(uoeSupplierList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE 発注先マスタ情報を物理削除します
        /// </summary>
        /// <param name="uoeSupplierList">UOE 発注先マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierList に格納されているUOE 発注先マスタ情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private int DeleteProc(ArrayList uoeSupplierList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (uoeSupplierList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeSupplierList.Count; i++)
                    {
                        UOESupplierWork uoeSupplierWork = uoeSupplierList[i] as UOESupplierWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM UOESUPPLIERRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                        findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != uoeSupplierWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM UOESUPPLIERRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                            findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);
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
        /// UOE 発注先マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="uoeSupplierList">検索結果</param>
        /// <param name="uoeSupplierObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE 発注先マスタのキー値が一致する、全てのUOE 発注先マスタ情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        /// <br>Update Note  : 2013/04/15 donggy</br>
        /// <br>管理番号     : 10900691-00 2013/05/15配信分</br>
        /// <br>               Redmine#35020　検索見積」の「発注検索画面」のレスポンス低下のトリガーの排除</br>
        public int Search(ref object uoeSupplierList, object uoeSupplierObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList uoeSupplierArray = uoeSupplierList as ArrayList;

                if (uoeSupplierArray == null)
                {
                    uoeSupplierArray = new ArrayList();
                }
                // --- DEL donggy 2013/04/15 --->>>>>>>>
                //UOESupplierWork uoeSupplierWork = uoeSupplierObj as UOESupplierWork;
                //// コネクション生成
                //sqlConnection = this.CreateSqlConnection(true);

                //status = this.Search(ref uoeSupplierArray, uoeSupplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction); 
                // --- DEL donggy 2013/04/15 ---<<<<<<<<

                // --- ADD donggy 2013/04/15 --->>>>>>>>
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);
                if (uoeSupplierObj is UOESupplierWork)
                {
                    // UOE 発注先マスタ情報のリストを取得します
                    UOESupplierWork uoeSupplierWork = uoeSupplierObj as UOESupplierWork;
                status = this.Search(ref uoeSupplierArray, uoeSupplierWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
                else if (uoeSupplierObj is System.Collections.Generic.List<UOESupplierWork>)
                {
                    // UOE 発注先マスタ情報のリストを取得します(発注先コードにより）
                    System.Collections.Generic.List<UOESupplierWork> uoeSupplierWorkList = uoeSupplierObj as System.Collections.Generic.List<UOESupplierWork>;
                    status = this.SearchBySupplierCds(ref uoeSupplierArray, uoeSupplierWorkList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                }
                // --- ADD donggy 2013/04/15 ---<<<<<<<<<
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
        /// UOE 発注先マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="uoeSupplierList">UOE 発注先マスタ情報を格納する ArrayList</param>
        /// <param name="uoeSupplierWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE 発注先マスタのキー値が一致する、全てのUOE 発注先マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Search(ref ArrayList uoeSupplierList, UOESupplierWork uoeSupplierWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref uoeSupplierList, uoeSupplierWork, readMode, logicalMode,ref sqlConnection,ref sqlTransaction);
        }

        // --- ADD donggy 2013/04/15 for Redmine#35020 --->>>>>>>>>
        /// <summary>
        /// UOE 発注先マスタ情報のリストを取得します。(発注先コードにより）
        /// </summary>
        /// <param name="uoeSupplierList">UOE 発注先マスタ情報を格納する ArrayList</param>
        /// <param name="uoeSupplierWorkList">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE 発注先マスタのキー値が一致する、全てのUOE 発注先マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : donggy</br>
        /// <br>Date       : 2013/04/15</br>
        private int SearchBySupplierCds(ref ArrayList uoeSupplierList, System.Collections.Generic.List<UOESupplierWork> uoeSupplierWorkList,
                                       int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT UOESUPP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.TELNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETERMINALCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEHOSTCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTPASSWORDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEIDNUMRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.COMMASSEMBLYIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CONNECTVERSIONDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESHIPSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESALSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESERVSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.RECEIVECONDITIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUBSTPARTSNODIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.PARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LISTPRICEUSEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.STOCKSLIPDTRECVDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CHECKCODEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BUSINESSCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESVDSECTIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEDELIGOODSDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BOCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERRATERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD3RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD4RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD5RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD6RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD3RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD4RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD5RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD6RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.INSTRUMENTNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETESTMODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEITEMCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.HONDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ANSWERSAVEFOLDERRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.MAZDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMERGENCYDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.DAIHATSUORDREDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LOGINTIMEOUTVALRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESTOCKCHECKURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEFORCEDTERMURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOELOGINURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.INQORDDIVCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSPASSWORDRF" + Environment.NewLine;
                sqlText += "    ,SECINFO.SECTIONGUIDENMRF SHIPSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO1.SECTIONGUIDENMRF SALSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO2.SECTIONGUIDENMRF RESERVSECTNM" + Environment.NewLine;
                sqlText += "    ,MAKERU.MAKERNAMERF MAKERNM" + Environment.NewLine;
                sqlText += "    ,MAKERU1.MAKERNAMERF ENABLEODRMAKERNM1" + Environment.NewLine;
                sqlText += "    ,MAKERU2.MAKERNAMERF ENABLEODRMAKERNM2" + Environment.NewLine;
                sqlText += "    ,MAKERU3.MAKERNAMERF ENABLEODRMAKERNM3" + Environment.NewLine;
                sqlText += "    ,MAKERU4.MAKERNAMERF ENABLEODRMAKERNM4" + Environment.NewLine;
                sqlText += "    ,MAKERU5.MAKERNAMERF ENABLEODRMAKERNM5" + Environment.NewLine;
                sqlText += "    ,MAKERU6.MAKERNAMERF ENABLEODRMAKERNM6" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BLMNGUSERCODERF" + Environment.NewLine;
                sqlText += " FROM UOESUPPLIERRF UOESUPP WITH (READUNCOMMITTED) " + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=SECINFO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO1 WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=SECINFO1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO1.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO2 WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=SECINFO2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO2.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=MAKERU.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.GOODSMAKERCDRF=MAKERU.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU1 WITH (READUNCOMMITTED)  ON UOESUPP.ENTERPRISECODERF=MAKERU1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD1RF=MAKERU1.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU2 WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=MAKERU2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD2RF=MAKERU2.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU3 WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=MAKERU3.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD3RF=MAKERU3.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU4 WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=MAKERU4.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD4RF=MAKERU4.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU5 WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=MAKERU5.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD5RF=MAKERU5.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU6 WITH (READUNCOMMITTED) ON UOESUPP.ENTERPRISECODERF=MAKERU6.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD6RF=MAKERU6.GOODSMAKERCDRF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, uoeSupplierWorkList, logicalMode);
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    uoeSupplierList.Add(this.CopyToUOESupplierWorkFromReader(ref myReader));
                }

                if (uoeSupplierList.Count > 0)
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
        // --- ADD donggy 2013/04/15 for Redmine#35020 ---<<<<<<<<<

        /// <summary>
        /// UOE 発注先マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="uoeSupplierList">UOE 発注先マスタ情報を格納する ArrayList</param>
        /// <param name="uoeSupplierWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE 発注先マスタのキー値が一致する、全てのUOE 発注先マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private int SearchProc(ref ArrayList uoeSupplierList, UOESupplierWork uoeSupplierWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT UOESUPP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.TELNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETERMINALCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEHOSTCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTPASSWORDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEIDNUMRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.COMMASSEMBLYIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CONNECTVERSIONDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESHIPSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESALSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESERVSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.RECEIVECONDITIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUBSTPARTSNODIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.PARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LISTPRICEUSEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.STOCKSLIPDTRECVDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CHECKCODEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BUSINESSCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESVDSECTIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEDELIGOODSDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BOCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERRATERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD3RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD4RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD5RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD6RF" + Environment.NewLine;
                //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD3RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD4RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD5RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ODRPRTSNOHYPHENCD6RF" + Environment.NewLine;
                //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
                sqlText += "    ,UOESUPP.INSTRUMENTNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETESTMODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEITEMCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.HONDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ANSWERSAVEFOLDERRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.MAZDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMERGENCYDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.DAIHATSUORDREDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUPPLIERCDRF" + Environment.NewLine;

                // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                sqlText += "    ,UOESUPP.LOGINTIMEOUTVALRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESTOCKCHECKURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEFORCEDTERMURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOELOGINURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.INQORDDIVCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSPASSWORDRF" + Environment.NewLine;
                // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                
                sqlText += "    ,SECINFO.SECTIONGUIDENMRF SHIPSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO1.SECTIONGUIDENMRF SALSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO2.SECTIONGUIDENMRF RESERVSECTNM" + Environment.NewLine;
                sqlText += "    ,MAKERU.MAKERNAMERF MAKERNM" + Environment.NewLine;
                sqlText += "    ,MAKERU1.MAKERNAMERF ENABLEODRMAKERNM1" + Environment.NewLine;
                sqlText += "    ,MAKERU2.MAKERNAMERF ENABLEODRMAKERNM2" + Environment.NewLine;
                sqlText += "    ,MAKERU3.MAKERNAMERF ENABLEODRMAKERNM3" + Environment.NewLine;
                sqlText += "    ,MAKERU4.MAKERNAMERF ENABLEODRMAKERNM4" + Environment.NewLine;
                sqlText += "    ,MAKERU5.MAKERNAMERF ENABLEODRMAKERNM5" + Environment.NewLine;
                sqlText += "    ,MAKERU6.MAKERNAMERF ENABLEODRMAKERNM6" + Environment.NewLine;
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                sqlText += "    ,UOESUPP.BLMNGUSERCODERF" + Environment.NewLine;
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
                sqlText += " FROM UOESUPPLIERRF UOESUPP" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO ON UOESUPP.ENTERPRISECODERF=SECINFO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO1 ON UOESUPP.ENTERPRISECODERF=SECINFO1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO1.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO2 ON UOESUPP.ENTERPRISECODERF=SECINFO2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO2.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU ON UOESUPP.ENTERPRISECODERF=MAKERU.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.GOODSMAKERCDRF=MAKERU.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU1 ON UOESUPP.ENTERPRISECODERF=MAKERU1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD1RF=MAKERU1.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU2 ON UOESUPP.ENTERPRISECODERF=MAKERU2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD2RF=MAKERU2.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU3 ON UOESUPP.ENTERPRISECODERF=MAKERU3.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD3RF=MAKERU3.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU4 ON UOESUPP.ENTERPRISECODERF=MAKERU4.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD4RF=MAKERU4.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU5 ON UOESUPP.ENTERPRISECODERF=MAKERU5.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD5RF=MAKERU5.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU6 ON UOESUPP.ENTERPRISECODERF=MAKERU6.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD6RF=MAKERU6.GOODSMAKERCDRF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, uoeSupplierWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    uoeSupplierList.Add(this.CopyToUOESupplierWorkFromReader(ref myReader));
                }

                if (uoeSupplierList.Count > 0)
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
        /// UOE 発注先マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="uoeSupplierList">追加・更新するUOE 発注先マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeSupplierList に格納されているUOE 発注先マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Write(ref object uoeSupplierList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = uoeSupplierList as ArrayList;

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
        /// UOE 発注先マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="uoeSupplierList">追加・更新するUOE 発注先マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeSupplierList に格納されているUOE 発注先マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int Write(ref ArrayList uoeSupplierList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteProc(ref uoeSupplierList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE 発注先マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="uoeSupplierList">追加・更新するUOE 発注先マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeSupplierList に格納されているUOE 発注先マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private int WriteProc(ref ArrayList uoeSupplierList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (uoeSupplierList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeSupplierList.Count; i++)
                    {
                        UOESupplierWork uoeSupplierWork = uoeSupplierList[i] as UOESupplierWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM UOESUPPLIERRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                        findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != uoeSupplierWork.UpdateDateTime)
                            {
                                if (uoeSupplierWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText += "UPDATE UOESUPPLIERRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , UOESUPPLIERCDRF=@UOESUPPLIERCD" + Environment.NewLine;
                            sqlText += " , UOESUPPLIERNAMERF=@UOESUPPLIERNAME" + Environment.NewLine;
                            sqlText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            sqlText += " , TELNORF=@TELNO" + Environment.NewLine;
                            sqlText += " , UOETERMINALCDRF=@UOETERMINALCD" + Environment.NewLine;
                            sqlText += " , UOEHOSTCODERF=@UOEHOSTCODE" + Environment.NewLine;
                            sqlText += " , UOECONNECTPASSWORDRF=@UOECONNECTPASSWORD" + Environment.NewLine;
                            sqlText += " , UOECONNECTUSERIDRF=@UOECONNECTUSERID" + Environment.NewLine;
                            sqlText += " , UOEIDNUMRF=@UOEIDNUM" + Environment.NewLine;
                            sqlText += " , COMMASSEMBLYIDRF=@COMMASSEMBLYID" + Environment.NewLine;
                            sqlText += " , CONNECTVERSIONDIVRF=@CONNECTVERSIONDIV" + Environment.NewLine;
                            sqlText += " , UOESHIPSECTCDRF=@UOESHIPSECTCD" + Environment.NewLine;
                            sqlText += " , UOESALSECTCDRF=@UOESALSECTCD" + Environment.NewLine;
                            sqlText += " , UOERESERVSECTCDRF=@UOERESERVSECTCD" + Environment.NewLine;
                            sqlText += " , RECEIVECONDITIONRF=@RECEIVECONDITION" + Environment.NewLine;
                            sqlText += " , SUBSTPARTSNODIVRF=@SUBSTPARTSNODIV" + Environment.NewLine;
                            sqlText += " , PARTSNOPRTCDRF=@PARTSNOPRTCD" + Environment.NewLine;
                            sqlText += " , LISTPRICEUSEDIVRF=@LISTPRICEUSEDIV" + Environment.NewLine;
                            sqlText += " , STOCKSLIPDTRECVDIVRF=@STOCKSLIPDTRECVDIV" + Environment.NewLine;
                            sqlText += " , CHECKCODEDIVRF=@CHECKCODEDIV" + Environment.NewLine;
                            sqlText += " , BUSINESSCODERF=@BUSINESSCODE" + Environment.NewLine;
                            sqlText += " , UOERESVDSECTIONRF=@UOERESVDSECTION" + Environment.NewLine;
                            sqlText += " , EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UOEDELIGOODSDIVRF=@UOEDELIGOODSDIV" + Environment.NewLine;
                            sqlText += " , BOCODERF=@BOCODE" + Environment.NewLine;
                            sqlText += " , UOEORDERRATERF=@UOEORDERRATE" + Environment.NewLine;
                            sqlText += " , ENABLEODRMAKERCD1RF=@ENABLEODRMAKERCD1" + Environment.NewLine;
                            sqlText += " , ENABLEODRMAKERCD2RF=@ENABLEODRMAKERCD2" + Environment.NewLine;
                            sqlText += " , ENABLEODRMAKERCD3RF=@ENABLEODRMAKERCD3" + Environment.NewLine;
                            sqlText += " , ENABLEODRMAKERCD4RF=@ENABLEODRMAKERCD4" + Environment.NewLine;
                            sqlText += " , ENABLEODRMAKERCD5RF=@ENABLEODRMAKERCD5" + Environment.NewLine;
                            sqlText += " , ENABLEODRMAKERCD6RF=@ENABLEODRMAKERCD6" + Environment.NewLine;
                            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                            sqlText += " , ODRPRTSNOHYPHENCD1RF=@ODRPRTSNOHYPHENCD1" + Environment.NewLine;
                            sqlText += " , ODRPRTSNOHYPHENCD2RF=@ODRPRTSNOHYPHENCD2" + Environment.NewLine;
                            sqlText += " , ODRPRTSNOHYPHENCD3RF=@ODRPRTSNOHYPHENCD3" + Environment.NewLine;
                            sqlText += " , ODRPRTSNOHYPHENCD4RF=@ODRPRTSNOHYPHENCD4" + Environment.NewLine;
                            sqlText += " , ODRPRTSNOHYPHENCD5RF=@ODRPRTSNOHYPHENCD5" + Environment.NewLine;
                            sqlText += " , ODRPRTSNOHYPHENCD6RF=@ODRPRTSNOHYPHENCD6" + Environment.NewLine;
                            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
                            sqlText += " , INSTRUMENTNORF=@INSTRUMENTNO" + Environment.NewLine;
                            sqlText += " , UOETESTMODERF=@UOETESTMODE" + Environment.NewLine;
                            sqlText += " , UOEITEMCDRF=@UOEITEMCD" + Environment.NewLine;
                            sqlText += " , HONDASECTIONCODERF=@HONDASECTIONCODE" + Environment.NewLine;
                            sqlText += " , ANSWERSAVEFOLDERRF=@ANSWERSAVEFOLDER" + Environment.NewLine;
                            sqlText += " , MAZDASECTIONCODERF=@MAZDASECTIONCODE" + Environment.NewLine;
                            sqlText += " , EMERGENCYDIVRF=@EMERGENCYDIV" + Environment.NewLine;
                            sqlText += " , DAIHATSUORDREDIVRF=@DAIHATSUORDREDIV" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;

                            // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            sqlText += " ,LOGINTIMEOUTVALRF = @LOGINTIMEOUTVAL" + Environment.NewLine;
                            sqlText += " ,UOEORDERURLRF = @UOEORDERURL" + Environment.NewLine;
                            sqlText += " ,UOESTOCKCHECKURLRF = @UOESTOCKCHECKURL" + Environment.NewLine;
                            sqlText += " ,UOEFORCEDTERMURLRF = @UOEFORCEDTERMURL" + Environment.NewLine;
                            sqlText += " ,UOELOGINURLRF = @UOELOGINURL" + Environment.NewLine;
                            sqlText += " ,INQORDDIVCDRF = @INQORDDIVCD" + Environment.NewLine;
                            sqlText += " ,EPARTSUSERIDRF = @EPARTSUSERID" + Environment.NewLine;
                            sqlText += " ,EPARTSPASSWORDRF = @EPARTSPASSWORD" + Environment.NewLine;
                            // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                            sqlText += " ,BLMNGUSERCODERF = @BLMNGUSERCODE" + Environment.NewLine;
                            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                            findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeSupplierWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (uoeSupplierWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO UOESUPPLIERRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,UOESUPPLIERCDRF" + Environment.NewLine;
                            sqlText += "    ,UOESUPPLIERNAMERF" + Environment.NewLine;
                            sqlText += "    ,GOODSMAKERCDRF" + Environment.NewLine;
                            sqlText += "    ,TELNORF" + Environment.NewLine;
                            sqlText += "    ,UOETERMINALCDRF" + Environment.NewLine;
                            sqlText += "    ,UOEHOSTCODERF" + Environment.NewLine;
                            sqlText += "    ,UOECONNECTPASSWORDRF" + Environment.NewLine;
                            sqlText += "    ,UOECONNECTUSERIDRF" + Environment.NewLine;
                            sqlText += "    ,UOEIDNUMRF" + Environment.NewLine;
                            sqlText += "    ,COMMASSEMBLYIDRF" + Environment.NewLine;
                            sqlText += "    ,CONNECTVERSIONDIVRF" + Environment.NewLine;
                            sqlText += "    ,UOESHIPSECTCDRF" + Environment.NewLine;
                            sqlText += "    ,UOESALSECTCDRF" + Environment.NewLine;
                            sqlText += "    ,UOERESERVSECTCDRF" + Environment.NewLine;
                            sqlText += "    ,RECEIVECONDITIONRF" + Environment.NewLine;
                            sqlText += "    ,SUBSTPARTSNODIVRF" + Environment.NewLine;
                            sqlText += "    ,PARTSNOPRTCDRF" + Environment.NewLine;
                            sqlText += "    ,LISTPRICEUSEDIVRF" + Environment.NewLine;
                            sqlText += "    ,STOCKSLIPDTRECVDIVRF" + Environment.NewLine;
                            sqlText += "    ,CHECKCODEDIVRF" + Environment.NewLine;
                            sqlText += "    ,BUSINESSCODERF" + Environment.NewLine;
                            sqlText += "    ,UOERESVDSECTIONRF" + Environment.NewLine;
                            sqlText += "    ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UOEDELIGOODSDIVRF" + Environment.NewLine;
                            sqlText += "    ,BOCODERF" + Environment.NewLine;
                            sqlText += "    ,UOEORDERRATERF" + Environment.NewLine;
                            sqlText += "    ,ENABLEODRMAKERCD1RF" + Environment.NewLine;
                            sqlText += "    ,ENABLEODRMAKERCD2RF" + Environment.NewLine;
                            sqlText += "    ,ENABLEODRMAKERCD3RF" + Environment.NewLine;
                            sqlText += "    ,ENABLEODRMAKERCD4RF" + Environment.NewLine;
                            sqlText += "    ,ENABLEODRMAKERCD5RF" + Environment.NewLine;
                            sqlText += "    ,ENABLEODRMAKERCD6RF" + Environment.NewLine;
                            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                            sqlText += "    ,ODRPRTSNOHYPHENCD1RF" + Environment.NewLine;
                            sqlText += "    ,ODRPRTSNOHYPHENCD2RF" + Environment.NewLine;
                            sqlText += "    ,ODRPRTSNOHYPHENCD3RF" + Environment.NewLine;
                            sqlText += "    ,ODRPRTSNOHYPHENCD4RF" + Environment.NewLine;
                            sqlText += "    ,ODRPRTSNOHYPHENCD5RF" + Environment.NewLine;
                            sqlText += "    ,ODRPRTSNOHYPHENCD6RF" + Environment.NewLine;
                            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
                            sqlText += "    ,INSTRUMENTNORF" + Environment.NewLine;
                            sqlText += "    ,UOETESTMODERF" + Environment.NewLine;
                            sqlText += "    ,UOEITEMCDRF" + Environment.NewLine;
                            sqlText += "    ,HONDASECTIONCODERF" + Environment.NewLine;
                            sqlText += "    ,ANSWERSAVEFOLDERRF" + Environment.NewLine;
                            sqlText += "    ,MAZDASECTIONCODERF" + Environment.NewLine;
                            sqlText += "    ,EMERGENCYDIVRF" + Environment.NewLine;
                            sqlText += "    ,DAIHATSUORDREDIVRF" + Environment.NewLine;
                            sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "    ,SUPPLIERCDRF" + Environment.NewLine;
                            // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            sqlText += "    ,LOGINTIMEOUTVALRF" + Environment.NewLine;
                            sqlText += "    ,UOEORDERURLRF" + Environment.NewLine;
                            sqlText += "    ,UOESTOCKCHECKURLRF " + Environment.NewLine;
                            sqlText += "    ,UOEFORCEDTERMURLRF" + Environment.NewLine;
                            sqlText += "    ,UOELOGINURLRF" + Environment.NewLine;
                            sqlText += "    ,INQORDDIVCDRF" + Environment.NewLine;
                            sqlText += "    ,EPARTSUSERIDRF" + Environment.NewLine;
                            sqlText += "    ,EPARTSPASSWORDRF" + Environment.NewLine;
                            // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                            sqlText += "    ,BLMNGUSERCODERF" + Environment.NewLine;
                            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
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
                            sqlText += "    ,@UOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    ,@UOESUPPLIERNAME" + Environment.NewLine;
                            sqlText += "    ,@GOODSMAKERCD" + Environment.NewLine;
                            sqlText += "    ,@TELNO" + Environment.NewLine;
                            sqlText += "    ,@UOETERMINALCD" + Environment.NewLine;
                            sqlText += "    ,@UOEHOSTCODE" + Environment.NewLine;
                            sqlText += "    ,@UOECONNECTPASSWORD" + Environment.NewLine;
                            sqlText += "    ,@UOECONNECTUSERID" + Environment.NewLine;
                            sqlText += "    ,@UOEIDNUM" + Environment.NewLine;
                            sqlText += "    ,@COMMASSEMBLYID" + Environment.NewLine;
                            sqlText += "    ,@CONNECTVERSIONDIV" + Environment.NewLine;
                            sqlText += "    ,@UOESHIPSECTCD" + Environment.NewLine;
                            sqlText += "    ,@UOESALSECTCD" + Environment.NewLine;
                            sqlText += "    ,@UOERESERVSECTCD" + Environment.NewLine;
                            sqlText += "    ,@RECEIVECONDITION" + Environment.NewLine;
                            sqlText += "    ,@SUBSTPARTSNODIV" + Environment.NewLine;
                            sqlText += "    ,@PARTSNOPRTCD" + Environment.NewLine;
                            sqlText += "    ,@LISTPRICEUSEDIV" + Environment.NewLine;
                            sqlText += "    ,@STOCKSLIPDTRECVDIV" + Environment.NewLine;
                            sqlText += "    ,@CHECKCODEDIV" + Environment.NewLine;
                            sqlText += "    ,@BUSINESSCODE" + Environment.NewLine;
                            sqlText += "    ,@UOERESVDSECTION" + Environment.NewLine;
                            sqlText += "    ,@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UOEDELIGOODSDIV" + Environment.NewLine;
                            sqlText += "    ,@BOCODE" + Environment.NewLine;
                            sqlText += "    ,@UOEORDERRATE" + Environment.NewLine;
                            sqlText += "    ,@ENABLEODRMAKERCD1" + Environment.NewLine;
                            sqlText += "    ,@ENABLEODRMAKERCD2" + Environment.NewLine;
                            sqlText += "    ,@ENABLEODRMAKERCD3" + Environment.NewLine;
                            sqlText += "    ,@ENABLEODRMAKERCD4" + Environment.NewLine;
                            sqlText += "    ,@ENABLEODRMAKERCD5" + Environment.NewLine;
                            sqlText += "    ,@ENABLEODRMAKERCD6" + Environment.NewLine;
                            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                            sqlText += "    ,@ODRPRTSNOHYPHENCD1" + Environment.NewLine;
                            sqlText += "    ,@ODRPRTSNOHYPHENCD2" + Environment.NewLine;
                            sqlText += "    ,@ODRPRTSNOHYPHENCD3" + Environment.NewLine;
                            sqlText += "    ,@ODRPRTSNOHYPHENCD4" + Environment.NewLine;
                            sqlText += "    ,@ODRPRTSNOHYPHENCD5" + Environment.NewLine;
                            sqlText += "    ,@ODRPRTSNOHYPHENCD6" + Environment.NewLine;
                            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
                            sqlText += "    ,@INSTRUMENTNO" + Environment.NewLine;
                            sqlText += "    ,@UOETESTMODE" + Environment.NewLine;
                            sqlText += "    ,@UOEITEMCD" + Environment.NewLine;
                            sqlText += "    ,@HONDASECTIONCODE" + Environment.NewLine;
                            sqlText += "    ,@ANSWERSAVEFOLDER" + Environment.NewLine;
                            sqlText += "    ,@MAZDASECTIONCODE" + Environment.NewLine;
                            sqlText += "    ,@EMERGENCYDIV" + Environment.NewLine;
                            sqlText += "    ,@DAIHATSUORDREDIV" + Environment.NewLine;
                            sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "    ,@SUPPLIERCD" + Environment.NewLine;
                            // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            sqlText += "    ,@LOGINTIMEOUTVAL" + Environment.NewLine;
                            sqlText += "    ,@UOEORDERURL" + Environment.NewLine;
                            sqlText += "    ,@UOESTOCKCHECKURL" + Environment.NewLine;
                            sqlText += "    ,@UOEFORCEDTERMURL" + Environment.NewLine;
                            sqlText += "    ,@UOELOGINURL" + Environment.NewLine;
                            sqlText += "    ,@INQORDDIVCD" + Environment.NewLine;
                            sqlText += "    ,@EPARTSUSERID" + Environment.NewLine;
                            sqlText += "    ,@EPARTSPASSWORD" + Environment.NewLine;
                            // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                            sqlText += "    ,@BLMNGUSERCODE" + Environment.NewLine;
                            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeSupplierWork;
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
                        SqlParameter paraUOESupplierCd = sqlCommand.Parameters.Add("@UOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraUOESupplierName = sqlCommand.Parameters.Add("@UOESUPPLIERNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraTelNo = sqlCommand.Parameters.Add("@TELNO", SqlDbType.NVarChar);
                        SqlParameter paraUOETerminalCd = sqlCommand.Parameters.Add("@UOETERMINALCD", SqlDbType.NVarChar);
                        SqlParameter paraUOEHostCode = sqlCommand.Parameters.Add("@UOEHOSTCODE", SqlDbType.NVarChar);
                        SqlParameter paraUOEConnectPassword = sqlCommand.Parameters.Add("@UOECONNECTPASSWORD", SqlDbType.NVarChar);
                        SqlParameter paraUOEConnectUserId = sqlCommand.Parameters.Add("@UOECONNECTUSERID", SqlDbType.NVarChar);
                        SqlParameter paraUOEIDNum = sqlCommand.Parameters.Add("@UOEIDNUM", SqlDbType.NVarChar);
                        SqlParameter paraCommAssemblyId = sqlCommand.Parameters.Add("@COMMASSEMBLYID", SqlDbType.NVarChar);
                        SqlParameter paraConnectVersionDiv = sqlCommand.Parameters.Add("@CONNECTVERSIONDIV", SqlDbType.Int);
                        SqlParameter paraUOEShipSectCd = sqlCommand.Parameters.Add("@UOESHIPSECTCD", SqlDbType.NVarChar);
                        SqlParameter paraUOESalSectCd = sqlCommand.Parameters.Add("@UOESALSECTCD", SqlDbType.NVarChar);
                        SqlParameter paraUOEReservSectCd = sqlCommand.Parameters.Add("@UOERESERVSECTCD", SqlDbType.NVarChar);
                        SqlParameter paraReceiveCondition = sqlCommand.Parameters.Add("@RECEIVECONDITION", SqlDbType.Int);
                        SqlParameter paraSubstPartsNoDiv = sqlCommand.Parameters.Add("@SUBSTPARTSNODIV", SqlDbType.Int);
                        SqlParameter paraPartsNoPrtCd = sqlCommand.Parameters.Add("@PARTSNOPRTCD", SqlDbType.Int);
                        SqlParameter paraListPriceUseDiv = sqlCommand.Parameters.Add("@LISTPRICEUSEDIV", SqlDbType.Int);
                        SqlParameter paraStockSlipDtRecvDiv = sqlCommand.Parameters.Add("@STOCKSLIPDTRECVDIV", SqlDbType.Int);
                        SqlParameter paraCheckCodeDiv = sqlCommand.Parameters.Add("@CHECKCODEDIV", SqlDbType.Int);
                        SqlParameter paraBusinessCode = sqlCommand.Parameters.Add("@BUSINESSCODE", SqlDbType.Int);
                        SqlParameter paraUOEResvdSection = sqlCommand.Parameters.Add("@UOERESVDSECTION", SqlDbType.NVarChar);
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUOEDeliGoodsDiv = sqlCommand.Parameters.Add("@UOEDELIGOODSDIV", SqlDbType.NVarChar);
                        SqlParameter paraBoCode = sqlCommand.Parameters.Add("@BOCODE", SqlDbType.NChar);
                        SqlParameter paraUOEOrderRate = sqlCommand.Parameters.Add("@UOEORDERRATE", SqlDbType.NVarChar);
                        SqlParameter paraEnableOdrMakerCd1 = sqlCommand.Parameters.Add("@ENABLEODRMAKERCD1", SqlDbType.Int);
                        SqlParameter paraEnableOdrMakerCd2 = sqlCommand.Parameters.Add("@ENABLEODRMAKERCD2", SqlDbType.Int);
                        SqlParameter paraEnableOdrMakerCd3 = sqlCommand.Parameters.Add("@ENABLEODRMAKERCD3", SqlDbType.Int);
                        SqlParameter paraEnableOdrMakerCd4 = sqlCommand.Parameters.Add("@ENABLEODRMAKERCD4", SqlDbType.Int);
                        SqlParameter paraEnableOdrMakerCd5 = sqlCommand.Parameters.Add("@ENABLEODRMAKERCD5", SqlDbType.Int);
                        SqlParameter paraEnableOdrMakerCd6 = sqlCommand.Parameters.Add("@ENABLEODRMAKERCD6", SqlDbType.Int);

                        //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                        SqlParameter paraOdrPrtsNoHyphenCd1 = sqlCommand.Parameters.Add("@ODRPRTSNOHYPHENCD1", SqlDbType.Int);
                        SqlParameter paraOdrPrtsNoHyphenCd2 = sqlCommand.Parameters.Add("@ODRPRTSNOHYPHENCD2", SqlDbType.Int);
                        SqlParameter paraOdrPrtsNoHyphenCd3 = sqlCommand.Parameters.Add("@ODRPRTSNOHYPHENCD3", SqlDbType.Int);
                        SqlParameter paraOdrPrtsNoHyphenCd4 = sqlCommand.Parameters.Add("@ODRPRTSNOHYPHENCD4", SqlDbType.Int);
                        SqlParameter paraOdrPrtsNoHyphenCd5 = sqlCommand.Parameters.Add("@ODRPRTSNOHYPHENCD5", SqlDbType.Int);
                        SqlParameter paraOdrPrtsNoHyphenCd6 = sqlCommand.Parameters.Add("@ODRPRTSNOHYPHENCD6", SqlDbType.Int);
                        //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<

                        SqlParameter parainstrumentNo = sqlCommand.Parameters.Add("@INSTRUMENTNO", SqlDbType.NVarChar);
                        SqlParameter paraUOETestMode = sqlCommand.Parameters.Add("@UOETESTMODE", SqlDbType.NVarChar);
                        SqlParameter paraUOEItemCd = sqlCommand.Parameters.Add("@UOEITEMCD", SqlDbType.NVarChar);
                        SqlParameter paraHondaSectionCode = sqlCommand.Parameters.Add("@HONDASECTIONCODE", SqlDbType.NVarChar);
                        SqlParameter paraAnswerSaveFolder = sqlCommand.Parameters.Add("@ANSWERSAVEFOLDER", SqlDbType.NVarChar);
                        SqlParameter paraMazdaSectionCode = sqlCommand.Parameters.Add("@MAZDASECTIONCODE", SqlDbType.NVarChar);
                        SqlParameter paraEmergencyDiv = sqlCommand.Parameters.Add("@EMERGENCYDIV", SqlDbType.NVarChar);
                        SqlParameter paraDaihatsuOrdreDiv = sqlCommand.Parameters.Add("@DAIHATSUORDREDIV", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        SqlParameter paraLoginTimeoutVal = sqlCommand.Parameters.Add("@LOGINTIMEOUTVAL", SqlDbType.Int);  // ログインタイムアウト
                        SqlParameter paraUOEOrderUrl = sqlCommand.Parameters.Add("@UOEORDERURL", SqlDbType.NVarChar);  // UOE発注URL
                        SqlParameter paraUOEStockCheckUrl = sqlCommand.Parameters.Add("@UOESTOCKCHECKURL", SqlDbType.NVarChar);  // UOE在庫確認URL
                        SqlParameter paraUOEForcedTermUrl = sqlCommand.Parameters.Add("@UOEFORCEDTERMURL", SqlDbType.NVarChar);  // UOE強制終了URL
                        SqlParameter paraUOELoginUrl = sqlCommand.Parameters.Add("@UOELOGINURL", SqlDbType.NVarChar);  // UOEログインURL
                        SqlParameter paraInqOrdDivCd = sqlCommand.Parameters.Add("@INQORDDIVCD", SqlDbType.Int);  // 問合せ・発注種別
                        SqlParameter paraEPartsUserId = sqlCommand.Parameters.Add("@EPARTSUSERID", SqlDbType.NVarChar);  // e-PartsユーザID
                        SqlParameter paraEPartsPassWord = sqlCommand.Parameters.Add("@EPARTSPASSWORD", SqlDbType.NVarChar);  // e-Partsパスワード
                        // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                        SqlParameter paraBLMngUserCode = sqlCommand.Parameters.Add("@BLMNGUSERCODE", SqlDbType.NVarChar); //BL管理ユーザーコード
                        // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
                        // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeSupplierWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeSupplierWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(uoeSupplierWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.LogicalDeleteCode);
                        paraUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                        paraUOESupplierName.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOESupplierName);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.GoodsMakerCd);
                        paraTelNo.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.TelNo);
                        paraUOETerminalCd.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOETerminalCd);
                        paraUOEHostCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEHostCode);
                        paraUOEConnectPassword.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEConnectPassword);
                        paraUOEConnectUserId.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEConnectUserId);
                        paraUOEIDNum.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEIDNum);
                        paraCommAssemblyId.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.CommAssemblyId);
                        paraConnectVersionDiv.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.ConnectVersionDiv);
                        paraUOEShipSectCd.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEShipSectCd);
                        paraUOESalSectCd.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOESalSectCd);
                        paraUOEReservSectCd.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEReservSectCd);
                        paraReceiveCondition.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.ReceiveCondition);
                        paraSubstPartsNoDiv.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.SubstPartsNoDiv);
                        paraPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.PartsNoPrtCd);
                        paraListPriceUseDiv.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.ListPriceUseDiv);
                        paraStockSlipDtRecvDiv.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.StockSlipDtRecvDiv);
                        paraCheckCodeDiv.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.CheckCodeDiv);
                        paraBusinessCode.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.BusinessCode);
                        paraUOEResvdSection.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEResvdSection);
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EmployeeCode);
                        paraUOEDeliGoodsDiv.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEDeliGoodsDiv);
                        paraBoCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.BoCode);
                        paraUOEOrderRate.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEOrderRate);
                        paraEnableOdrMakerCd1.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.EnableOdrMakerCd1);
                        paraEnableOdrMakerCd2.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.EnableOdrMakerCd2);
                        paraEnableOdrMakerCd3.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.EnableOdrMakerCd3);
                        paraEnableOdrMakerCd4.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.EnableOdrMakerCd4);
                        paraEnableOdrMakerCd5.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.EnableOdrMakerCd5);
                        paraEnableOdrMakerCd6.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.EnableOdrMakerCd6);

                        //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                        paraOdrPrtsNoHyphenCd1.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.OdrPrtsNoHyphenCd1);
                        paraOdrPrtsNoHyphenCd2.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.OdrPrtsNoHyphenCd2);
                        paraOdrPrtsNoHyphenCd3.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.OdrPrtsNoHyphenCd3);
                        paraOdrPrtsNoHyphenCd4.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.OdrPrtsNoHyphenCd4);
                        paraOdrPrtsNoHyphenCd5.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.OdrPrtsNoHyphenCd5);
                        paraOdrPrtsNoHyphenCd6.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.OdrPrtsNoHyphenCd6);
                        //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
                        parainstrumentNo.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.instrumentNo);
                        paraUOETestMode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOETestMode);
                        paraUOEItemCd.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEItemCd);
                        paraHondaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.HondaSectionCode);
                        paraAnswerSaveFolder.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.AnswerSaveFolder);
                        paraMazdaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.MazdaSectionCode);
                        paraEmergencyDiv.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EmergencyDiv);
                        paraDaihatsuOrdreDiv.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.DaihatsuOrdreDiv);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.SupplierCd);
                        // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        paraLoginTimeoutVal.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.LoginTimeoutVal);  // ログインタイムアウト
                        paraUOEOrderUrl.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEOrderUrl);  // UOE発注URL
                        paraUOEStockCheckUrl.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEStockCheckUrl);  // UOE在庫確認URL
                        paraUOEForcedTermUrl.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOEForcedTermUrl);  // UOE強制終了URL
                        paraUOELoginUrl.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UOELoginUrl);  // UOEログインURL
                        paraInqOrdDivCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.InqOrdDivCd);  // 問合せ・発注種別
                        paraEPartsUserId.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EPartsUserId);  // e-PartsユーザID
                        paraEPartsPassWord.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EPartsPassWord);  // e-Partsパスワード
                        // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                        paraBLMngUserCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.BLMngUserCode); //BL管理ユーザーコード
                        // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(uoeSupplierWork);
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

            uoeSupplierList = al;

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
        /// <br>Note       : 指定された条件のUOE発注先マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081  疋田　勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のUOE発注先マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
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
                sqlText += "SELECT UOESUPP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.TELNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETERMINALCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEHOSTCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTPASSWORDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOECONNECTUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEIDNUMRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.COMMASSEMBLYIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CONNECTVERSIONDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESHIPSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESALSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESERVSECTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.RECEIVECONDITIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUBSTPARTSNODIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.PARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.LISTPRICEUSEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.STOCKSLIPDTRECVDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.CHECKCODEDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BUSINESSCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOERESVDSECTIONRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEDELIGOODSDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.BOCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERRATERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD1RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD2RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD3RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD4RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD5RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ENABLEODRMAKERCD6RF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.INSTRUMENTNORF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOETESTMODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEITEMCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.HONDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.ANSWERSAVEFOLDERRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.MAZDASECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EMERGENCYDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.DAIHATSUORDREDIVRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.SUPPLIERCDRF" + Environment.NewLine;
                // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                sqlText += "    ,UOESUPP.LOGINTIMEOUTVALRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEORDERURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOESTOCKCHECKURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOEFORCEDTERMURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.UOELOGINURLRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.INQORDDIVCDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSUSERIDRF" + Environment.NewLine;
                sqlText += "    ,UOESUPP.EPARTSPASSWORDRF" + Environment.NewLine;
                // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                sqlText += "    ,SECINFO.SECTIONGUIDENMRF SHIPSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO1.SECTIONGUIDENMRF SALSECTNM" + Environment.NewLine;
                sqlText += "    ,SECINFO2.SECTIONGUIDENMRF RESERVSECTNM" + Environment.NewLine;
                sqlText += "    ,MAKERU.MAKERNAMERF MAKERNM" + Environment.NewLine;
                sqlText += "    ,MAKERU1.MAKERNAMERF ENABLEODRMAKERNM1" + Environment.NewLine;
                sqlText += "    ,MAKERU2.MAKERNAMERF ENABLEODRMAKERNM2" + Environment.NewLine;
                sqlText += "    ,MAKERU3.MAKERNAMERF ENABLEODRMAKERNM3" + Environment.NewLine;
                sqlText += "    ,MAKERU4.MAKERNAMERF ENABLEODRMAKERNM4" + Environment.NewLine;
                sqlText += "    ,MAKERU5.MAKERNAMERF ENABLEODRMAKERNM5" + Environment.NewLine;
                sqlText += "    ,MAKERU6.MAKERNAMERF ENABLEODRMAKERNM6" + Environment.NewLine;
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                sqlText += "    , UOESUPP.BLMNGUSERCODERF" + Environment.NewLine;
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
                sqlText += " FROM UOESUPPLIERRF UOESUPP" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO ON UOESUPP.ENTERPRISECODERF=SECINFO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESHIPSECTCDRF=SECINFO.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO1 ON UOESUPP.ENTERPRISECODERF=SECINFO1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOESALSECTCDRF=SECINFO1.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF SECINFO2 ON UOESUPP.ENTERPRISECODERF=SECINFO2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.UOERESERVSECTCDRF=SECINFO2.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU ON UOESUPP.ENTERPRISECODERF=MAKERU.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.GOODSMAKERCDRF=MAKERU.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU1 ON UOESUPP.ENTERPRISECODERF=MAKERU1.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD1RF=MAKERU1.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU2 ON UOESUPP.ENTERPRISECODERF=MAKERU2.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD2RF=MAKERU2.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU3 ON UOESUPP.ENTERPRISECODERF=MAKERU3.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD3RF=MAKERU3.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU4 ON UOESUPP.ENTERPRISECODERF=MAKERU4.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD4RF=MAKERU4.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU5 ON UOESUPP.ENTERPRISECODERF=MAKERU5.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD5RF=MAKERU5.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN MAKERURF MAKERU6 ON UOESUPP.ENTERPRISECODERF=MAKERU6.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOESUPP.ENABLEODRMAKERCD6RF=MAKERU6.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToUOESupplierWorkFromReader(ref myReader));

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
        /// UOE 発注先マスタ情報を論理削除します。
        /// </summary>
        /// <param name="uoeSupplierList">論理削除するUOE 発注先マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierWork に格納されているUOE 発注先マスタ情報を論理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int LogicalDelete(ref object uoeSupplierList)
        {
            return this.LogicalDelete(ref uoeSupplierList, 0);
        }

        /// <summary>
        /// UOE 発注先マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="uoeSupplierList">論理削除を解除するUOE 発注先マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierWork に格納されているUOE 発注先マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int RevivalLogicalDelete(ref object uoeSupplierList)
        {
            return this.LogicalDelete(ref uoeSupplierList, 1);
        }

        /// <summary>
        /// UOE 発注先マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="uoeSupplierList">論理削除を操作するUOE 発注先マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierWork に格納されているUOE 発注先マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private int LogicalDelete(ref object uoeSupplierList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = uoeSupplierList as ArrayList;

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
        /// UOE 発注先マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="uoeSupplierList">論理削除を操作するUOE 発注先マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierWork に格納されているUOE 発注先マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        public int LogicalDelete(ref ArrayList uoeSupplierList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref uoeSupplierList, procMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE 発注先マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="uoeSupplierList">論理削除を操作するUOE 発注先マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOESupplierWork に格納されているUOE 発注先マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private int LogicalDeleteProc(ref ArrayList uoeSupplierList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (uoeSupplierList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeSupplierList.Count; i++)
                    {
                        UOESupplierWork uoeSupplierWork = uoeSupplierList[i] as UOESupplierWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM UOESUPPLIERRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                        findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);
                        
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != uoeSupplierWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  UOESUPPLIERRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);
                            findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeSupplierWork;
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
                            else if (logicalDelCd == 0) uoeSupplierWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else uoeSupplierWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                uoeSupplierWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeSupplierWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(uoeSupplierWork);
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

            uoeSupplierList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="uoeSupplierWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, UOESupplierWork uoeSupplierWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  UOESUPP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND UOESUPP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND UOESUPP.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // UOE発注先コード
            if (uoeSupplierWork.UOESupplierCd != 0)
            {
                retstring += "  AND UOESUPP.UOESUPPLIERCDRF = @FINDUOESUPPLIERCD" + Environment.NewLine;
                SqlParameter findUOESupplier = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                findUOESupplier.Value = SqlDataMediator.SqlSetInt32(uoeSupplierWork.UOESupplierCd);
            }

            // 拠点コード
            if (uoeSupplierWork.SectionCode != "")
            {
                retstring += "  AND UOESUPP.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWork.SectionCode);
            }
            return retstring;
        }

        // --- ADD donggy 2013/04/15 for Redmine#35020 --->>>>>>>>
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="uoeSupplierWorkList">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : donggy</br>
        /// <br>Date       : 2013/04/15</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, System.Collections.Generic.List<UOESupplierWork> uoeSupplierWorkList, ConstantManagement.LogicalMode logicalMode)
        {
            if (uoeSupplierWorkList.Count == 0)
            {
                return string.Empty;
            }
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // 企業コード
            retstring += "  UOESUPP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWorkList[0].EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND UOESUPP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND UOESUPP.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // UOE発注先コード
            for (int i = 0; i < uoeSupplierWorkList.Count; i++)
            {
                if (uoeSupplierWorkList.Count > 1)
                {
                    if (uoeSupplierWorkList[i].UOESupplierCd != 0)
                    {
                        if (i == 0)
                        {
                            retstring += "  AND (  UOESUPP.UOESUPPLIERCDRF =  " + uoeSupplierWorkList[i].UOESupplierCd + Environment.NewLine;
                        }
                        else if (i < uoeSupplierWorkList.Count - 1)
                        {
                            retstring += "      OR UOESUPP.UOESUPPLIERCDRF =  " + uoeSupplierWorkList[i].UOESupplierCd + Environment.NewLine;
                        }
                        else
                        {
                            retstring += "     OR UOESUPP.UOESUPPLIERCDRF =  " + uoeSupplierWorkList[i].UOESupplierCd + " )" + Environment.NewLine;
                        }
                    }
                }
                else if (uoeSupplierWorkList.Count == 1)
                {
                    if (uoeSupplierWorkList[i].UOESupplierCd != 0)
                    {
                        retstring += "  AND  UOESUPP.UOESUPPLIERCDRF =  " + uoeSupplierWorkList[i].UOESupplierCd + Environment.NewLine;
                    }
                }

            }
            // 拠点コード
            if (uoeSupplierWorkList[0].SectionCode != "")
            {
                retstring += "  AND UOESUPP.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(uoeSupplierWorkList[0].SectionCode);
            }
            return retstring;
        }
        // --- ADD donggy 2013/04/15 for Redmine#35020 ---<<<<<<<<
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
            retstring += "UOESUPP.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //差分シンクの場合は更新日付の範囲指定
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UOESUPP.UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UOESUPP.UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UOESUPP.UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → UOESupplierWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>uoeSupplierWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        private UOESupplierWork CopyToUOESupplierWorkFromReader(ref SqlDataReader myReader)
        {
            UOESupplierWork uoeSupplierWork = new UOESupplierWork();

            this.CopyToUOESupplierWorkFromReader(ref myReader, ref uoeSupplierWork);

            return uoeSupplierWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → UOESupplierWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="uoeSupplierWork">UOESupplierWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        private void CopyToUOESupplierWorkFromReader(ref SqlDataReader myReader, ref UOESupplierWork uoeSupplierWork)
        {
            if (myReader != null && uoeSupplierWork != null)
            {
                # region クラスへ格納
                uoeSupplierWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                uoeSupplierWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                uoeSupplierWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                uoeSupplierWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                uoeSupplierWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                uoeSupplierWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                uoeSupplierWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                uoeSupplierWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                uoeSupplierWork.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESUPPLIERCDRF"));
                uoeSupplierWork.UOESupplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUPPLIERNAMERF"));
                uoeSupplierWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                uoeSupplierWork.TelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TELNORF"));
                uoeSupplierWork.UOETerminalCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOETERMINALCDRF"));
                uoeSupplierWork.UOEHostCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEHOSTCODERF"));
                uoeSupplierWork.UOEConnectPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOECONNECTPASSWORDRF"));
                uoeSupplierWork.UOEConnectUserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOECONNECTUSERIDRF"));
                uoeSupplierWork.UOEIDNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEIDNUMRF"));
                uoeSupplierWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
                uoeSupplierWork.ConnectVersionDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONNECTVERSIONDIVRF"));
                uoeSupplierWork.UOEShipSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESHIPSECTCDRF"));
                uoeSupplierWork.UOESalSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESALSECTCDRF"));
                uoeSupplierWork.UOEReservSectCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOERESERVSECTCDRF"));
                uoeSupplierWork.ReceiveCondition = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIVECONDITIONRF"));
                uoeSupplierWork.SubstPartsNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSTPARTSNODIVRF"));
                uoeSupplierWork.PartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSNOPRTCDRF"));
                uoeSupplierWork.ListPriceUseDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEUSEDIVRF"));
                uoeSupplierWork.StockSlipDtRecvDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPDTRECVDIVRF"));
                uoeSupplierWork.CheckCodeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKCODEDIVRF"));
                uoeSupplierWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSCODERF"));
                uoeSupplierWork.UOEResvdSection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOERESVDSECTIONRF"));
                uoeSupplierWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                uoeSupplierWork.UOEDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEDELIGOODSDIVRF"));
                uoeSupplierWork.BoCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOCODERF"));
                uoeSupplierWork.UOEOrderRate = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEORDERRATERF"));
                uoeSupplierWork.EnableOdrMakerCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENABLEODRMAKERCD1RF"));
                uoeSupplierWork.EnableOdrMakerCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENABLEODRMAKERCD2RF"));
                uoeSupplierWork.EnableOdrMakerCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENABLEODRMAKERCD3RF"));
                uoeSupplierWork.EnableOdrMakerCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENABLEODRMAKERCD4RF"));
                uoeSupplierWork.EnableOdrMakerCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENABLEODRMAKERCD5RF"));
                uoeSupplierWork.EnableOdrMakerCd6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENABLEODRMAKERCD6RF"));
                //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
                uoeSupplierWork.OdrPrtsNoHyphenCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ODRPRTSNOHYPHENCD1RF"));
                uoeSupplierWork.OdrPrtsNoHyphenCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ODRPRTSNOHYPHENCD2RF"));
                uoeSupplierWork.OdrPrtsNoHyphenCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ODRPRTSNOHYPHENCD3RF"));
                uoeSupplierWork.OdrPrtsNoHyphenCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ODRPRTSNOHYPHENCD4RF"));
                uoeSupplierWork.OdrPrtsNoHyphenCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ODRPRTSNOHYPHENCD5RF"));
                uoeSupplierWork.OdrPrtsNoHyphenCd6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ODRPRTSNOHYPHENCD6RF"));
                //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
                uoeSupplierWork.instrumentNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSTRUMENTNORF"));
                uoeSupplierWork.UOETestMode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOETESTMODERF"));
                uoeSupplierWork.UOEItemCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEITEMCDRF"));
                uoeSupplierWork.HondaSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONDASECTIONCODERF"));
                uoeSupplierWork.AnswerSaveFolder = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERSAVEFOLDERRF"));
                uoeSupplierWork.MazdaSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDASECTIONCODERF"));
                uoeSupplierWork.EmergencyDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMERGENCYDIVRF"));
                uoeSupplierWork.DaihatsuOrdreDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DAIHATSUORDREDIVRF"));
                uoeSupplierWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                uoeSupplierWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                // 2009/05/29 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                uoeSupplierWork.LoginTimeoutVal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGINTIMEOUTVALRF"));  // ログインタイムアウト
                uoeSupplierWork.UOEOrderUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEORDERURLRF"));  // UOE発注URL
                uoeSupplierWork.UOEStockCheckUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESTOCKCHECKURLRF"));  // UOE在庫確認URL
                uoeSupplierWork.UOEForcedTermUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEFORCEDTERMURLRF"));  // UOE強制終了URL
                uoeSupplierWork.UOELoginUrl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOELOGINURLRF"));  // UOEログインURL
                uoeSupplierWork.InqOrdDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQORDDIVCDRF"));  // 問合せ・発注種別
                uoeSupplierWork.EPartsUserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EPARTSUSERIDRF"));  // e-PartsユーザID
                uoeSupplierWork.EPartsPassWord = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EPARTSPASSWORDRF"));  // e-Partsパスワード
                // 2009/05/29 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                uoeSupplierWork.BLMngUserCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLMNGUSERCODERF")); //BL管理ユーザーコード
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<
                
                // ここから下は実テーブルにない、追加項目
                uoeSupplierWork.UOEShipSectNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPSECTNM"));
                uoeSupplierWork.UOESalSectNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALSECTNM"));
                uoeSupplierWork.UOEReservSectNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESERVSECTNM"));
                uoeSupplierWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNM"));
                uoeSupplierWork.EnableOdrMakerName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENABLEODRMAKERNM1"));
                uoeSupplierWork.EnableOdrMakerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENABLEODRMAKERNM2"));
                uoeSupplierWork.EnableOdrMakerName3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENABLEODRMAKERNM3"));
                uoeSupplierWork.EnableOdrMakerName4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENABLEODRMAKERNM4"));
                uoeSupplierWork.EnableOdrMakerName5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENABLEODRMAKERNM5"));
                uoeSupplierWork.EnableOdrMakerName6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENABLEODRMAKERNM6"));
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

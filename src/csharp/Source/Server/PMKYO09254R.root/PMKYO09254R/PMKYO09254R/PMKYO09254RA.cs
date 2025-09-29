//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理接続先設定マスタメンテナンス
// プログラム概要   : 拠点管理接続先設定マスタの登録・変更を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data;
using Microsoft.Win32;
using System.IO;
using System.Security;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 接続先設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 接続先設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.04.23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SecMngConnectStDB : RemoteDB, ISecMngConnectStDB
    {
        /// <summary>
        /// 接続先設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public SecMngConnectStDB()
            : base("PMKYO09256D", "Broadleaf.Application.Remoting.ParamData.SecMngConnectStWork", "SecMngConnectStRF")
        {

        }

        # region [Search]
        /// <summary>
        /// 接続先設定マスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outSecMngConnectStWorkList">検索結果</param>
        /// <param name="paraObjSecMngConnectStWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 接続先設定マスタのキー値が一致する、全ての接続先設定マスタ情報を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int Search(out object outSecMngConnectStWorkList, object paraObjSecMngConnectStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _secMngConnectStWorkList = null;
            SecMngConnectStWork secMngConnectStWork = null;

            outSecMngConnectStWorkList = new CustomSerializeArrayList();

            try
            {
                secMngConnectStWork = paraObjSecMngConnectStWork as SecMngConnectStWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = SearchProc(out _secMngConnectStWorkList, secMngConnectStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SecMngConnectStDB.Search", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SecMngConnectStDB.Search", status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            outSecMngConnectStWorkList = _secMngConnectStWorkList;

            return status;
        }

        /// <summary>
        /// 接続先設定マスタ情報を取得します。
        /// </summary>
        /// <remarks>
        /// <param name="secMngConnectStWorkList">検索結果</param>
        /// <param name="secMngConnectStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 接続先設定マスタのキー値が一致する、全ての接続先設定マスタ情報を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        private int SearchProc(out ArrayList secMngConnectStWorkList, SecMngConnectStWork secMngConnectStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                # region [SELECT文]
                sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CONNECTPOINTDIVRF, APSERVERIPADDRESSRF, DBSERVERIPADDRESSRF" + Environment.NewLine;
                sqlText += "FROM SECMNGCONNECTSTRF " + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                //sqlText += "ORDER BY PATTERNNODERIVEDNORF";
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = secMngConnectStWork.EnterpriseCode;
                findParaSectionCode.Value = secMngConnectStWork.SectionCode;

                sqlCommand.CommandText += sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToSecMngConnectStWorkFromReader(ref myReader));
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
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SecMngConnectStDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SecMngConnectStDB.SearchProc" + status);
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

            secMngConnectStWorkList = al;

            return status;
        }
        # endregion

        # region [Write]
        /// <summary>
        /// 接続先設定マスタ情報を追加・更新します。
        /// </summary>
        /// <remarks>
        /// <param name="objSecMngConnectStWork">SecMngConnectStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 接続先設定マスタを追加・更新します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        public int Write(ref object objSecMngConnectStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                SecMngConnectStWork secMngConnectStWork = objSecMngConnectStWork as SecMngConnectStWork;

                status = WriteProc(ref secMngConnectStWork, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    objSecMngConnectStWork = secMngConnectStWork;
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SecMngConnectStDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SecMngConnectStDB.Write", status);
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
        /// 接続先設定マスタ情報を登録、更新します
        /// </summary>
        /// <remarks>
        /// <param name="secMngConnectStWork">接続先設定マスタ情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 接続先設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        private int WriteProc(ref SecMngConnectStWork secMngConnectStWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF, UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "FROM SECMNGCONNECTSTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion


                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = secMngConnectStWork.EnterpriseCode;
                findParaSectionCode.Value = secMngConnectStWork.SectionCode;

                sqlCommand.CommandText += sqlText;

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    DateTime comUpDateTime = secMngConnectStWork.UpdateDateTime;

                    // 排他チェック
                    if (_updateDateTime != comUpDateTime)
                    {
                        //既存データで更新日時違いの場合には排他
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }
                        return status;
                    }

                    # region [UPDATE文]
                    sqlText = string.Empty;
                    sqlText += "UPDATE SECMNGCONNECTSTRF " + Environment.NewLine;
                    sqlText += "SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , CONNECTPOINTDIVRF=@CONNECTPOINTDIV , APSERVERIPADDRESSRF=@APSERVERIPADDRESS , DBSERVERIPADDRESSRF=@DBSERVERIPADDRESS" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = secMngConnectStWork.EnterpriseCode;
                    findParaSectionCode.Value = secMngConnectStWork.SectionCode;

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)secMngConnectStWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    if (secMngConnectStWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }

                    //　画面のデータ、insert処理
                    # region [INSERT文]
                    sqlText = string.Empty;
                    sqlText = "INSERT INTO SECMNGCONNECTSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, CONNECTPOINTDIVRF, APSERVERIPADDRESSRF, DBSERVERIPADDRESSRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @CONNECTPOINTDIV, @APSERVERIPADDRESS, @DBSERVERIPADDRESS)";
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)secMngConnectStWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }

                if (myReader.IsClosed == false) myReader.Close();

                //Parameterオブジェクトの作成(更新用)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraConnectPointDiv = sqlCommand.Parameters.Add("@CONNECTPOINTDIV", SqlDbType.Int);
                SqlParameter paraApServerIpAddress = sqlCommand.Parameters.Add("@APSERVERIPADDRESS", SqlDbType.NVarChar);
                SqlParameter paraDbServerIpAddress = sqlCommand.Parameters.Add("@DBSERVERIPADDRESS", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定(更新用)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngConnectStWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(secMngConnectStWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(secMngConnectStWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(secMngConnectStWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(secMngConnectStWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(secMngConnectStWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(secMngConnectStWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(secMngConnectStWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(secMngConnectStWork.SectionCode);
                paraConnectPointDiv.Value = SqlDataMediator.SqlSetInt32(secMngConnectStWork.ConnectPointDiv);
                paraApServerIpAddress.Value = SqlDataMediator.SqlSetString(secMngConnectStWork.ApServerIpAddress);
                paraDbServerIpAddress.Value = SqlDataMediator.SqlSetString(secMngConnectStWork.DbServerIpAddress);

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SecMngConnectStDB.Write", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SecMngConnectStDB.Write" + status);
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

        # region UpdateRegistryKeyValue
        /// <summary>
        /// レジストリのキー項目を更新処理
        /// </summary>
        /// <remarks>
        /// <param name="objSecMngConnectStWork">接続先設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : レジストリのキー項目を更新します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        public int UpdateRegistryKeyValue(ref object objSecMngConnectStWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                SecMngConnectStWork secMngConnectStWork = objSecMngConnectStWork as SecMngConnectStWork;

                string rKeyName1 = @String.Format("SOFTWARE\\Broadleaf\\Service\\Partsman\\SUMMARY_AP");
                string rKeyName2 = @String.Format("SOFTWARE\\Broadleaf\\Service\\Partsman\\SUMMARY_AP\\SUMMARY_DB");
                RegistryKey rKey1 = Registry.LocalMachine.OpenSubKey(rKeyName1, true);
                RegistryKey rKey2 = Registry.LocalMachine.OpenSubKey(rKeyName2, true);

                if (rKey1 == null)
                {
                    rKey1 = Registry.LocalMachine.CreateSubKey(rKeyName1);
                }

                if (rKey2 == null)
                {
                    rKey2 = Registry.LocalMachine.CreateSubKey(rKeyName2);
                }

                if (rKey1 != null && rKey2 != null)
                {
                    rKey1.SetValue("%Domain%", secMngConnectStWork.ApServerIpAddress, RegistryValueKind.String);
                    rKey2.SetValue("%DataSource%", secMngConnectStWork.DbServerIpAddress, RegistryValueKind.String);

                    // 既に%RequiredServerVersion%が存在時には更新対象外
                    if (rKey1.GetValue("RequiredServerVersion") == null)
                    {
                        rKey1.SetValue("RequiredServerVersion", "0", RegistryValueKind.DWord);
                    }
                }

                objSecMngConnectStWork = secMngConnectStWork;
            }
            catch (IOException)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            catch (SecurityException)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, "SecMngConnectStDB.UpdateRegistryKeyValue", status);
            }
            return status;
        }

        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → SecMngSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SecMngConnectStWork</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        private SecMngConnectStWork CopyToSecMngConnectStWorkFromReader(ref SqlDataReader myReader)
        {
            SecMngConnectStWork secMngConnectStWork = new SecMngConnectStWork();

            if (myReader != null && secMngConnectStWork != null)
            {
                # region クラスへ格納
                secMngConnectStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                secMngConnectStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                secMngConnectStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                secMngConnectStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                secMngConnectStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                secMngConnectStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                secMngConnectStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                secMngConnectStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                secMngConnectStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                secMngConnectStWork.ConnectPointDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONNECTPOINTDIVRF"));
                secMngConnectStWork.ApServerIpAddress = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("APSERVERIPADDRESSRF"));
                secMngConnectStWork.DbServerIpAddress = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DBSERVERIPADDRESSRF"));

                # endregion
            }
            return secMngConnectStWork;
        }
        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
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
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
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

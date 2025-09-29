//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   受注マスタ(車両)DBリモートオブジェクト
//                  :   PMJUT01811R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田
// Date             :   2008.05.28
//----------------------------------------------------------------------
// Update Note      :   張莉莉　2009/09/07　
//                      車輌備考の追加
// Update Note      :   2010/04/27 gaoyh
//                  :   受注マスタ（車両）に自由検索型式固定番号配列の追加
// Update Note      :   SPK車台番号文字列対応に伴う国産/外車区分の追加 
// Programmer       :   FSI厚川 宏
// Date             :   2013/03/21
// 管理番号         :   10900269-00
// Update Note      :   PMKOBETSU-4076 タイムアウト設定
// Programmer       :   田建委
// Date             :   2020/08/28
// 管理番号         :   11600006-00
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
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
using System.IO;
using System.Xml;
using Microsoft.Win32;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 受注マスタ(車両)DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受注マスタ(車両)の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田</br>
    /// <br>Date       : 2008.05.28</br>
    /// <br></br>
    /// <br>Update Note: 2009/09/07 張莉莉</br>
    /// <br>              車輌備考の追加</br>
    /// <br>Update Note      :   2010/04/27 gaoyh</br>
    /// <br>                 :   受注マスタ（車両）に自由検索型式固定番号配列の追加</br>
    /// <br>Update Note: 2020/08/28 田建委</br>
    /// <br>             PMKOBETSU-4076 タイムアウト設定</br>
    /// </remarks>
    [Serializable]
    public class AcceptOdrCarDB : RemoteWithAppLockDB, IAcceptOdrCarDB
    {
        private bool _CompulsoryDataOverride = false;
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>> 
        // 伝票更新タイムアウト時間設定ファイル
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XMLファイルが無い時のデフォルト値
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

        /// <summary>
        /// 受注マスタ(車両)DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        /// <br></br>
        /// <br>Update Note: UOEWEB e-Parts対応</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2009.05.28</br>
        /// </remarks>
        public AcceptOdrCarDB() : base("PMJUT01813D", "Broadleaf.Application.Remoting.ParamData.AcceptOdrCarWork", "ACCEPTODRCARRF")
        {
            this._CompulsoryDataOverride = false;

        }

        /// <summary>
        /// 受注マスタ(車両)DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <param name="compulsoryDataOverride">false(標準):更新日付等を考慮してデータの更新を行う。　true:更新日付などを無視してデータの更新を行う。</param>
        /// <remarks>
        /// <br>Note       : 本コンストラクタを使用する際は、CompulsoryDataOverrideの取扱いに十分注意する事</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        /// </remarks>
        public AcceptOdrCarDB(bool compulsoryDataOverride)
            : base("PMJUT01813D", "Broadleaf.Application.Remoting.ParamData.AcceptOdrCarWork", "ACCEPTODRCARRF")
        {
            this._CompulsoryDataOverride = true;
        }

        # region [Read]
        /// <summary>
        /// 単一の受注マスタ(車両)情報を取得します。
        /// </summary>
        /// <param name="acceptOdrCarObj">AcceptOdrCarWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        public int Read(ref object acceptOdrCarObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                AcceptOdrCarWork acceptOdrCarWork = acceptOdrCarObj as AcceptOdrCarWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref acceptOdrCarWork, readMode, sqlConnection, sqlTransaction);
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
        /// 単一の受注マスタ(車両)情報を取得します。
        /// </summary>
        /// <param name="acceptOdrCarWork">AcceptOdrCarWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        public int Read(ref AcceptOdrCarWork acceptOdrCarWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref acceptOdrCarWork, readMode, sqlConnection, sqlTransaction);
        }

        // 2009/05/28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 受注マスタ(車両)情報リストを取得します。
        /// </summary>
        /// <param name="acceptOdrCarObj">抽出条件リスト(AcceptOdrCarWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : 22008　長内</br>
        /// <br>Date       : 2009.05.28</br>
        public int ReadAll(ref object acceptOdrCarObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList paraList = acceptOdrCarObj as ArrayList;
                ArrayList acceptOdrCarList = new ArrayList();

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.ReadAll(ref acceptOdrCarList, paraList ,sqlConnection, sqlTransaction);

                acceptOdrCarObj = acceptOdrCarList;

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
        /// 単一の受注マスタ(車両)情報を取得します。
        /// </summary>
        /// <param name="acceptOdrCarList">抽出結果リスト(AcceptOdrCarWork)</param>
        /// <param name="paraList">抽出条件リスト(AcceptOdrCarWork)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : 22008　長内</br>
        /// <br>Date       : 2009.05.28</br>
        public int ReadAll(ref ArrayList acceptOdrCarList, ArrayList paraList ,SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            foreach (AcceptOdrCarWork acceptOdrCarWork in paraList)
            {
                AcceptOdrCarWork pararetWork = acceptOdrCarWork;

                status = this.ReadProc(ref pararetWork, 0, sqlConnection, sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    acceptOdrCarList.Add(pararetWork);
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
        // 2009/05/28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 単一の受注マスタ(車両)情報を取得します。
        /// </summary>
        /// <param name="acceptOdrCarWork">AcceptOdrCarWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        /// <br>Update Note: SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/21</br>
        private int ReadProc(ref AcceptOdrCarWork acceptOdrCarWork, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
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
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  ACAR.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ACAR.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,ACAR.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,ACAR.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,ACAR.ACCEPTANORDERNORF" + Environment.NewLine;
                sqlText += " ,ACAR.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += " ,ACAR.DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlText += " ,ACAR.CARMNGNORF" + Environment.NewLine;
                sqlText += " ,ACAR.CARMNGCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE1CODERF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE1NAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE2RF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE3RF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE4RF" + Environment.NewLine;
                sqlText += " ,ACAR.FIRSTENTRYDATERF" + Environment.NewLine;
                sqlText += " ,ACAR.MAKERCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.MAKERFULLNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.MAKERHALFNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELSUBCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELFULLNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELHALFNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.EXHAUSTGASSIGNRF" + Environment.NewLine;
                sqlText += " ,ACAR.SERIESMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.CATEGORYSIGNMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.FULLMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELDESIGNATIONNORF" + Environment.NewLine;
                sqlText += " ,ACAR.CATEGORYNORF" + Environment.NewLine;
                sqlText += " ,ACAR.FRAMEMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.FRAMENORF" + Environment.NewLine;
                sqlText += " ,ACAR.SEARCHFRAMENORF" + Environment.NewLine;
                sqlText += " ,ACAR.ENGINEMODELNMRF" + Environment.NewLine;
                sqlText += " ,ACAR.RELEVANCEMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.SUBCARNMCDRF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELGRADESNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.COLORCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.COLORNAME1RF" + Environment.NewLine;
                sqlText += " ,ACAR.TRIMCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.TRIMNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.MILEAGERF" + Environment.NewLine;
                sqlText += " ,ACAR.FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                sqlText += " ,ACAR.CATEGORYOBJARYRF" + Environment.NewLine;

                sqlText += " ,ACAR.CARNOTERF " + Environment.NewLine;  // ADD 2009/09/07

                sqlText += " ,ACAR.FREESRCHMDLFXDNOARYRF " + Environment.NewLine;  // ADD 2010/04/27
                sqlText += " ,ACAR.DOMESTICFOREIGNCODERF " + Environment.NewLine;  // ADD 2013/03/21

                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  ACCEPTODRCARRF AS ACAR" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ACAR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND ACAR.ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                sqlText += "  AND ACAR.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                sqlText += "  AND ACAR.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);
                findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
                findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToAcceptOdrCarWorkFromReader(ref myReader, ref acceptOdrCarWork);
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
        /// 受注マスタ(車両)情報を物理削除します
        /// </summary>
        /// <param name="acceptOdrCarList">物理削除する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する受注マスタ(車両)情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        public int Delete(object acceptOdrCarList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = acceptOdrCarList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

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
        /// 受注マスタ(車両)情報を物理削除します
        /// </summary>
        /// <param name="acceptOdrCarList">受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarList に格納されている受注マスタ(車両)情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        public int Delete(ArrayList acceptOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(acceptOdrCarList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// 受注マスタ(車両)情報を物理削除します
        /// </summary>
        /// <param name="acceptOdrCarList">受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarList に格納されている受注マスタ(車両)情報を物理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        private int DeleteProc(ArrayList acceptOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (acceptOdrCarList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < acceptOdrCarList.Count; i++)
                    {
                        AcceptOdrCarWork acceptOdrCarWork = acceptOdrCarList[i] as AcceptOdrCarWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  ACCEPTODRCARRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                        sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                        SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);                        

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);
                        findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
                        findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != acceptOdrCarWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  ACCEPTODRCARRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                            sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);
                            findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
                            findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);
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
        /// 受注マスタ(車両)情報のリストを取得します。
        /// </summary>
        /// <param name="acceptOdrCarList">検索結果</param>
        /// <param name="acceptOdrCarObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する、全ての受注マスタ(車両)情報を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        public int Search(ref object acceptOdrCarList, object acceptOdrCarObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList acceptOdrCarArray = acceptOdrCarList as ArrayList;
                AcceptOdrCarWork acceptOdrCarWork = acceptOdrCarObj as AcceptOdrCarWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref acceptOdrCarArray, acceptOdrCarWork, readMode, logicalMode, sqlConnection, sqlTransaction);
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
        /// 受注マスタ(車両)情報のリストを取得します。
        /// </summary>
        /// <param name="acceptOdrCarList">受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="acceptOdrCarWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する、全ての受注マスタ(車両)情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        public int Search(ref ArrayList acceptOdrCarList, AcceptOdrCarWork acceptOdrCarWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref acceptOdrCarList, acceptOdrCarWork, readMode, logicalMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// 受注マスタ(車両)情報のリストを取得します。
        /// </summary>
        /// <param name="acceptOdrCarList">受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="acceptOdrCarWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ(車両)のキー値が一致する、全ての受注マスタ(車両)情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        /// <br>Update Note: SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/21</br>
        private int SearchProc(ref ArrayList acceptOdrCarList, AcceptOdrCarWork acceptOdrCarWork, int readMode, ConstantManagement.LogicalMode logicalMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
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
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  ACAR.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,ACAR.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,ACAR.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,ACAR.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,ACAR.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,ACAR.ACCEPTANORDERNORF" + Environment.NewLine;
                sqlText += " ,ACAR.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += " ,ACAR.DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlText += " ,ACAR.CARMNGNORF" + Environment.NewLine;
                sqlText += " ,ACAR.CARMNGCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE1CODERF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE1NAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE2RF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE3RF" + Environment.NewLine;
                sqlText += " ,ACAR.NUMBERPLATE4RF" + Environment.NewLine;
                sqlText += " ,ACAR.FIRSTENTRYDATERF" + Environment.NewLine;
                sqlText += " ,ACAR.MAKERCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.MAKERFULLNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELSUBCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELFULLNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.EXHAUSTGASSIGNRF" + Environment.NewLine;
                sqlText += " ,ACAR.SERIESMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.CATEGORYSIGNMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.FULLMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELDESIGNATIONNORF" + Environment.NewLine;
                sqlText += " ,ACAR.CATEGORYNORF" + Environment.NewLine;
                sqlText += " ,ACAR.FRAMEMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.FRAMENORF" + Environment.NewLine;
                sqlText += " ,ACAR.SEARCHFRAMENORF" + Environment.NewLine;
                sqlText += " ,ACAR.ENGINEMODELNMRF" + Environment.NewLine;
                sqlText += " ,ACAR.RELEVANCEMODELRF" + Environment.NewLine;
                sqlText += " ,ACAR.SUBCARNMCDRF" + Environment.NewLine;
                sqlText += " ,ACAR.MODELGRADESNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.COLORCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.COLORNAME1RF" + Environment.NewLine;
                sqlText += " ,ACAR.TRIMCODERF" + Environment.NewLine;
                sqlText += " ,ACAR.TRIMNAMERF" + Environment.NewLine;
                sqlText += " ,ACAR.MILEAGERF" + Environment.NewLine;
                sqlText += " ,ACAR.FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                sqlText += " ,ACAR.CARNOTERF " + Environment.NewLine;  // ADD 2009/09/07
                sqlText += " ,ACAR.FREESRCHMDLFXDNOARYRF " + Environment.NewLine;  // ADD 2010/04/27
                sqlText += " ,ACAR.DOMESTICFOREIGNCODERF " + Environment.NewLine;  // ADD 2013/03/21
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  ACCEPTODRCARRF AS ACAR" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, acceptOdrCarWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    acceptOdrCarList.Add(this.CopyToAcceptOdrCarWorkFromReader(ref myReader));
                }

                if (acceptOdrCarList.Count > 0)
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
        /// 受注マスタ(車両)情報を追加・更新します。
        /// </summary>
        /// <param name="acceptOdrCarList">追加・更新する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarList に格納されている受注マスタ(車両)情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        public int Write(ref object acceptOdrCarList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = acceptOdrCarList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

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
        /// 受注マスタ(車両)情報を追加・更新します。
        /// </summary>
        /// <param name="acceptOdrCarList">追加・更新する受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarList に格納されている受注マスタ(車両)情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        public int Write(ref ArrayList acceptOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref acceptOdrCarList, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// 受注マスタ(車両)情報を追加・更新します。
        /// </summary>
        /// <param name="acceptOdrCarList">追加・更新する受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarList に格納されている受注マスタ(車両)情報を追加・更新します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        /// <br>Update Note: SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/21</br>
        /// <br>Update Note: PMKOBETSU-4076 タイムアウト設定</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/08/28</br>
        private int WriteProc(ref ArrayList acceptOdrCarList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // コマンドタイムアウト（秒）
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

            try
            {
                if (acceptOdrCarList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < acceptOdrCarList.Count; i++)
                    {
                        AcceptOdrCarWork acceptOdrCarWork = acceptOdrCarList[i] as AcceptOdrCarWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  ACAR.CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ACAR.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ACAR.FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  ACCEPTODRCARRF AS ACAR" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ACAR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACAR.ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                        sqlText += "  AND ACAR.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND ACAR.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                        SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);
                        findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
                        findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);

                        sqlCommand.CommandTimeout = dbCommandTimeout; //ADD 田建委 2020/08/28 PMKOBETSU-4076の対応
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            if (!this._CompulsoryDataOverride)
                            {
                                // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                                if (_updateDateTime != acceptOdrCarWork.UpdateDateTime)
                                {
                                    if (acceptOdrCarWork.UpdateDateTime == DateTime.MinValue)
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
                            else
                            {
                                // 強制的にデータを上書きをする為、作成日時やファイルヘッダーGUIDを上書きしておく
                                // ※fileHeader.SetUpdateHeader ではこれらの項目がセットされない為
                                acceptOdrCarWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
                                acceptOdrCarWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
                            }                                                                                     

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE ACCEPTODRCARRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,ACCEPTANORDERNORF = @ACCEPTANORDERNO" + Environment.NewLine;
                            sqlText += " ,ACPTANODRSTATUSRF = @ACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += " ,DATAINPUTSYSTEMRF = @DATAINPUTSYSTEM" + Environment.NewLine;
                            sqlText += " ,CARMNGNORF = @CARMNGNO" + Environment.NewLine;
                            sqlText += " ,CARMNGCODERF = @CARMNGCODE" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1CODERF = @NUMBERPLATE1CODE" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1NAMERF = @NUMBERPLATE1NAME" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE2RF = @NUMBERPLATE2" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE3RF = @NUMBERPLATE3" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE4RF = @NUMBERPLATE4" + Environment.NewLine;
                            sqlText += " ,FIRSTENTRYDATERF = @FIRSTENTRYDATE" + Environment.NewLine;
                            sqlText += " ,MAKERCODERF = @MAKERCODE" + Environment.NewLine;
                            sqlText += " ,MAKERFULLNAMERF = @MAKERFULLNAME" + Environment.NewLine;
                            sqlText += " ,MAKERHALFNAMERF = @MAKERHALFNAME" + Environment.NewLine;
                            sqlText += " ,MODELCODERF = @MODELCODE" + Environment.NewLine;
                            sqlText += " ,MODELSUBCODERF = @MODELSUBCODE" + Environment.NewLine;
                            sqlText += " ,MODELFULLNAMERF = @MODELFULLNAME" + Environment.NewLine;
                            sqlText += " ,MODELHALFNAMERF = @MODELHALFNAME" + Environment.NewLine;
                            sqlText += " ,EXHAUSTGASSIGNRF = @EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += " ,SERIESMODELRF = @SERIESMODEL" + Environment.NewLine;
                            sqlText += " ,CATEGORYSIGNMODELRF = @CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += " ,FULLMODELRF = @FULLMODEL" + Environment.NewLine;
                            sqlText += " ,MODELDESIGNATIONNORF = @MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += " ,CATEGORYNORF = @CATEGORYNO" + Environment.NewLine;
                            sqlText += " ,FRAMEMODELRF = @FRAMEMODEL" + Environment.NewLine;
                            sqlText += " ,FRAMENORF = @FRAMENO" + Environment.NewLine;
                            sqlText += " ,SEARCHFRAMENORF = @SEARCHFRAMENO" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELNMRF = @ENGINEMODELNM" + Environment.NewLine;
                            sqlText += " ,RELEVANCEMODELRF = @RELEVANCEMODEL" + Environment.NewLine;
                            sqlText += " ,SUBCARNMCDRF = @SUBCARNMCD" + Environment.NewLine;
                            sqlText += " ,MODELGRADESNAMERF = @MODELGRADESNAME" + Environment.NewLine;
                            sqlText += " ,COLORCODERF = @COLORCODE" + Environment.NewLine;
                            sqlText += " ,COLORNAME1RF = @COLORNAME1" + Environment.NewLine;
                            sqlText += " ,TRIMCODERF = @TRIMCODE" + Environment.NewLine;
                            sqlText += " ,TRIMNAMERF = @TRIMNAME" + Environment.NewLine;
                            sqlText += " ,MILEAGERF = @MILEAGE" + Environment.NewLine;
                            sqlText += " ,FULLMODELFIXEDNOARYRF = @FULLMODELFIXEDNOARY" + Environment.NewLine;
                            sqlText += " ,CATEGORYOBJARYRF = @CATEGORYOBJARY" + Environment.NewLine;
                            sqlText += " ,CARNOTERF = @CARNOTE" + Environment.NewLine; // ADD 2009/09/07
                            sqlText += " ,FREESRCHMDLFXDNOARYRF = @FREESRCHMDLFXDNOARY" + Environment.NewLine; // ADD 2010/04/27
                            sqlText += " ,DOMESTICFOREIGNCODERF = @DOMESTICFOREIGNCODE" + Environment.NewLine;  // ADD 2013/03/21
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                            sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);
                            findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
                            findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)acceptOdrCarWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (acceptOdrCarWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO ACCEPTODRCARRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,ACCEPTANORDERNORF" + Environment.NewLine;
                            sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                            sqlText += " ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                            sqlText += " ,CARMNGNORF" + Environment.NewLine;
                            sqlText += " ,CARMNGCODERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1CODERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE1NAMERF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE2RF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE3RF" + Environment.NewLine;
                            sqlText += " ,NUMBERPLATE4RF" + Environment.NewLine;
                            sqlText += " ,FIRSTENTRYDATERF" + Environment.NewLine;
                            sqlText += " ,MAKERCODERF" + Environment.NewLine;
                            sqlText += " ,MAKERFULLNAMERF" + Environment.NewLine;
                            sqlText += " ,MAKERHALFNAMERF" + Environment.NewLine;
                            sqlText += " ,MODELCODERF" + Environment.NewLine;
                            sqlText += " ,MODELSUBCODERF" + Environment.NewLine;
                            sqlText += " ,MODELFULLNAMERF" + Environment.NewLine;
                            sqlText += " ,MODELHALFNAMERF" + Environment.NewLine;
                            sqlText += " ,EXHAUSTGASSIGNRF" + Environment.NewLine;
                            sqlText += " ,SERIESMODELRF" + Environment.NewLine;
                            sqlText += " ,CATEGORYSIGNMODELRF" + Environment.NewLine;
                            sqlText += " ,FULLMODELRF" + Environment.NewLine;
                            sqlText += " ,MODELDESIGNATIONNORF" + Environment.NewLine;
                            sqlText += " ,CATEGORYNORF" + Environment.NewLine;
                            sqlText += " ,FRAMEMODELRF" + Environment.NewLine;
                            sqlText += " ,FRAMENORF" + Environment.NewLine;
                            sqlText += " ,SEARCHFRAMENORF" + Environment.NewLine;
                            sqlText += " ,ENGINEMODELNMRF" + Environment.NewLine;
                            sqlText += " ,RELEVANCEMODELRF" + Environment.NewLine;
                            sqlText += " ,SUBCARNMCDRF" + Environment.NewLine;
                            sqlText += " ,MODELGRADESNAMERF" + Environment.NewLine;
                            sqlText += " ,COLORCODERF" + Environment.NewLine;
                            sqlText += " ,COLORNAME1RF" + Environment.NewLine;
                            sqlText += " ,TRIMCODERF" + Environment.NewLine;
                            sqlText += " ,TRIMNAMERF" + Environment.NewLine;
                            sqlText += " ,MILEAGERF" + Environment.NewLine;
                            sqlText += " ,FULLMODELFIXEDNOARYRF" + Environment.NewLine;
                            sqlText += " ,CATEGORYOBJARYRF" + Environment.NewLine;
                            sqlText += " ,CARNOTERF " + Environment.NewLine;  // ADD 2009/09/07
                            sqlText += " ,DOMESTICFOREIGNCODERF " + Environment.NewLine;  // ADD 2013/03/21
                            sqlText += " ,FREESRCHMDLFXDNOARYRF) " + Environment.NewLine;  // ADD 2010/04/27
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@ACCEPTANORDERNO" + Environment.NewLine;
                            sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += " ,@DATAINPUTSYSTEM" + Environment.NewLine;
                            sqlText += " ,@CARMNGNO" + Environment.NewLine;
                            sqlText += " ,@CARMNGCODE" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE1CODE" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE1NAME" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE2" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE3" + Environment.NewLine;
                            sqlText += " ,@NUMBERPLATE4" + Environment.NewLine;
                            sqlText += " ,@FIRSTENTRYDATE" + Environment.NewLine;
                            sqlText += " ,@MAKERCODE" + Environment.NewLine;
                            sqlText += " ,@MAKERFULLNAME" + Environment.NewLine;
                            sqlText += " ,@MAKERHALFNAME" + Environment.NewLine;
                            sqlText += " ,@MODELCODE" + Environment.NewLine;
                            sqlText += " ,@MODELSUBCODE" + Environment.NewLine;
                            sqlText += " ,@MODELFULLNAME" + Environment.NewLine;
                            sqlText += " ,@MODELHALFNAME" + Environment.NewLine;
                            sqlText += " ,@EXHAUSTGASSIGN" + Environment.NewLine;
                            sqlText += " ,@SERIESMODEL" + Environment.NewLine;
                            sqlText += " ,@CATEGORYSIGNMODEL" + Environment.NewLine;
                            sqlText += " ,@FULLMODEL" + Environment.NewLine;
                            sqlText += " ,@MODELDESIGNATIONNO" + Environment.NewLine;
                            sqlText += " ,@CATEGORYNO" + Environment.NewLine;
                            sqlText += " ,@FRAMEMODEL" + Environment.NewLine;
                            sqlText += " ,@FRAMENO" + Environment.NewLine;
                            sqlText += " ,@SEARCHFRAMENO" + Environment.NewLine;
                            sqlText += " ,@ENGINEMODELNM" + Environment.NewLine;
                            sqlText += " ,@RELEVANCEMODEL" + Environment.NewLine;
                            sqlText += " ,@SUBCARNMCD" + Environment.NewLine;
                            sqlText += " ,@MODELGRADESNAME" + Environment.NewLine;
                            sqlText += " ,@COLORCODE" + Environment.NewLine;
                            sqlText += " ,@COLORNAME1" + Environment.NewLine;
                            sqlText += " ,@TRIMCODE" + Environment.NewLine;
                            sqlText += " ,@TRIMNAME" + Environment.NewLine;
                            sqlText += " ,@MILEAGE" + Environment.NewLine;
                            sqlText += " ,@FULLMODELFIXEDNOARY" + Environment.NewLine;
                            sqlText += " ,@CATEGORYOBJARY" + Environment.NewLine;
                            sqlText += " ,@CARNOTE" + Environment.NewLine;  // ADD 2009/09/07
                            sqlText += " ,@DOMESTICFOREIGNCODE" + Environment.NewLine;  // ADD 2013/03/21
                            sqlText += " ,@FREESRCHMDLFXDNOARY" + Environment.NewLine;  // ADD 2010/04/27
                            sqlText += ")" + Environment.NewLine;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)acceptOdrCarWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }
                        
                        sqlCommand.CommandText = sqlText;

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);               // 作成日時
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);               // 更新日時
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);                // 企業コード
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);     // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);              // 更新従業員コード
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);             // 更新アセンブリID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);             // 更新アセンブリID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);            // 論理削除区分
                        SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);                // 受注番号
                        SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);                // 受注ステータス
                        SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);                // データ入力システム
                        SqlParameter paraCarMngNo = sqlCommand.Parameters.Add("@CARMNGNO", SqlDbType.Int);                              // 車両管理番号
                        SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@CARMNGCODE", SqlDbType.NVarChar);                     // 車輌管理コード
                        SqlParameter paraNumberPlate1Code = sqlCommand.Parameters.Add("@NUMBERPLATE1CODE", SqlDbType.Int);              // 陸運事務所番号
                        SqlParameter paraNumberPlate1Name = sqlCommand.Parameters.Add("@NUMBERPLATE1NAME", SqlDbType.NVarChar);         // 陸運事務局名称
                        SqlParameter paraNumberPlate2 = sqlCommand.Parameters.Add("@NUMBERPLATE2", SqlDbType.NVarChar);                 // 車両登録番号（種別）
                        SqlParameter paraNumberPlate3 = sqlCommand.Parameters.Add("@NUMBERPLATE3", SqlDbType.NVarChar);                 // 車両登録番号（カナ）
                        SqlParameter paraNumberPlate4 = sqlCommand.Parameters.Add("@NUMBERPLATE4", SqlDbType.Int);                      // 車両登録番号（プレート番号）
                        SqlParameter paraFirstEntryDate = sqlCommand.Parameters.Add("@FIRSTENTRYDATE", SqlDbType.Int);                  // 初年度
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);                            // メーカーコード
                        SqlParameter paraMakerFullName = sqlCommand.Parameters.Add("@MAKERFULLNAME", SqlDbType.NVarChar);               // メーカー全角名称
                        SqlParameter paraMakerHalfName = sqlCommand.Parameters.Add("@MAKERHALFNAME", SqlDbType.NVarChar);               // メーカー半角名称
                        SqlParameter paraModelCode = sqlCommand.Parameters.Add("@MODELCODE", SqlDbType.Int);                            // 車種コード
                        SqlParameter paraModelSubCode = sqlCommand.Parameters.Add("@MODELSUBCODE", SqlDbType.Int);                      // 車種サブコード
                        SqlParameter paraModelFullName = sqlCommand.Parameters.Add("@MODELFULLNAME", SqlDbType.NVarChar);               // 車種全角名称
                        SqlParameter paraModelHalfName = sqlCommand.Parameters.Add("@MODELHALFNAME", SqlDbType.NVarChar);               // 車種半角名称
                        SqlParameter paraExhaustGasSign = sqlCommand.Parameters.Add("@EXHAUSTGASSIGN", SqlDbType.NVarChar);             // 排ガス記号
                        SqlParameter paraSeriesModel = sqlCommand.Parameters.Add("@SERIESMODEL", SqlDbType.NVarChar);                   // シリーズ型式
                        SqlParameter paraCategorySignModel = sqlCommand.Parameters.Add("@CATEGORYSIGNMODEL", SqlDbType.NVarChar);       // 型式（類別記号）
                        SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FULLMODEL", SqlDbType.NVarChar);                       // 型式（フル型）
                        SqlParameter paraModelDesignationNo = sqlCommand.Parameters.Add("@MODELDESIGNATIONNO", SqlDbType.Int);          // 型式指定番号
                        SqlParameter paraCategoryNo = sqlCommand.Parameters.Add("@CATEGORYNO", SqlDbType.Int);                          // 類別番号
                        SqlParameter paraFrameModel = sqlCommand.Parameters.Add("@FRAMEMODEL", SqlDbType.NVarChar);                     // 車台型式
                        SqlParameter paraFrameNo = sqlCommand.Parameters.Add("@FRAMENO", SqlDbType.NVarChar);                           // 車台番号
                        SqlParameter paraSearchFrameNo = sqlCommand.Parameters.Add("@SEARCHFRAMENO", SqlDbType.Int);                    // 車台番号（検索用）
                        SqlParameter paraEngineModelNm = sqlCommand.Parameters.Add("@ENGINEMODELNM", SqlDbType.NVarChar);               // エンジン型式名称
                        SqlParameter paraRelevanceModel = sqlCommand.Parameters.Add("@RELEVANCEMODEL", SqlDbType.NVarChar);             // 関連型式
                        SqlParameter paraSubCarNmCd = sqlCommand.Parameters.Add("@SUBCARNMCD", SqlDbType.Int);                          // サブ車名コード
                        SqlParameter paraModelGradeSname = sqlCommand.Parameters.Add("@MODELGRADESNAME", SqlDbType.NVarChar);           // 型式グレード略称
                        SqlParameter paraColorCode = sqlCommand.Parameters.Add("@COLORCODE", SqlDbType.NVarChar);                       // カラーコード
                        SqlParameter paraColorName1 = sqlCommand.Parameters.Add("@COLORNAME1", SqlDbType.NVarChar);                     // カラー名称1
                        SqlParameter paraTrimCode = sqlCommand.Parameters.Add("@TRIMCODE", SqlDbType.NVarChar);                         // トリムコード
                        SqlParameter paraTrimName = sqlCommand.Parameters.Add("@TRIMNAME", SqlDbType.NVarChar);                         // トリム名称
                        SqlParameter paraMileage = sqlCommand.Parameters.Add("@MILEAGE", SqlDbType.Int);                                // 車両走行距離
                        SqlParameter paraFullModelFixedNoAry = sqlCommand.Parameters.Add("@FULLMODELFIXEDNOARY", SqlDbType.VarBinary);  // フル型式固定番号配列
                        SqlParameter paraCategoryObjAry = sqlCommand.Parameters.Add("@CATEGORYOBJARY", SqlDbType.VarBinary);            // 装備オブジェクト配列
                        SqlParameter paraCarNote = sqlCommand.Parameters.Add("@CARNOTE", SqlDbType.NVarChar);            // 車輌備考    // ADD 2009/09/07
                        SqlParameter paraFreeSrchMdlFxdNoAry = sqlCommand.Parameters.Add("@FREESRCHMDLFXDNOARY", SqlDbType.VarBinary);  // 自由検索型式固定番号配列 // ADD 2010/04/27
                        SqlParameter paraDomesticForeignCode = sqlCommand.Parameters.Add("@DOMESTICFOREIGNCODE", SqlDbType.Int);        //国産/外車区分 // ADD 2013/03/21
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptOdrCarWork.CreateDateTime);   // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptOdrCarWork.UpdateDateTime);   // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);              // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(acceptOdrCarWork.FileHeaderGuid);                // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.UpdEmployeeCode);            // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.UpdAssemblyId1);              // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.UpdAssemblyId2);              // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.LogicalDeleteCode);         // 論理削除区分
                        paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);             // 受注番号
                        paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);             // 受注ステータス
                        paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);             // データ入力システム
                        paraCarMngNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.CarMngNo);                           // 車両管理番号
                        paraCarMngCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.CarMngCode);                      // 車輌管理コード
                        paraNumberPlate1Code.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.NumberPlate1Code);           // 陸運事務所番号
                        paraNumberPlate1Name.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.NumberPlate1Name);          // 陸運事務局名称
                        paraNumberPlate2.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.NumberPlate2);                  // 車両登録番号（種別）
                        paraNumberPlate3.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.NumberPlate3);                  // 車両登録番号（カナ）
                        paraNumberPlate4.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.NumberPlate4);                   // 車両登録番号（プレート番号）
                       // paraFirstEntryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(acceptOdrCarWork.FirstEntryDate);  // 初年度
                        paraFirstEntryDate.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.FirstEntryDate);               // 初年度
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.MakerCode);                         // メーカーコード
                        paraMakerFullName.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.MakerFullName);                // メーカー全角名称
                        paraMakerHalfName.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.MakerHalfName);                // メーカー半角名称
                        paraModelCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.ModelCode);                         // 車種コード
                        paraModelSubCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.ModelSubCode);                   // 車種サブコード
                        paraModelFullName.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.ModelFullName);                // 車種全角名称
                        paraModelHalfName.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.ModelHalfName);                // 車種半角名称
                        paraExhaustGasSign.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.ExhaustGasSign);              // 排ガス記号
                        paraSeriesModel.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.SeriesModel);                    // シリーズ型式
                        paraCategorySignModel.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.CategorySignModel);        // 型式（類別記号）
                        paraFullModel.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.FullModel);                        // 型式（フル型）
                        paraModelDesignationNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.ModelDesignationNo);       // 型式指定番号
                        paraCategoryNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.CategoryNo);                       // 類別番号
                        paraFrameModel.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.FrameModel);                      // 車台型式
                        paraFrameNo.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.FrameNo);                            // 車台番号
                        paraSearchFrameNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.SearchFrameNo);                 // 車台番号（検索用）
                        paraEngineModelNm.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EngineModelNm);                // エンジン型式名称
                        paraRelevanceModel.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.RelevanceModel);              // 関連型式
                        paraSubCarNmCd.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.SubCarNmCd);                       // サブ車名コード
                        paraModelGradeSname.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.ModelGradeSname);            // 型式グレード略称
                        paraColorCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.ColorCode);                        // カラーコード
                        paraColorName1.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.ColorName1);                      // カラー名称1
                        paraTrimCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.TrimCode);                          // トリムコード
                        paraTrimName.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.TrimName);                          // トリム名称
                        paraMileage.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.Mileage);                             // 車両走行距離

                        paraCarNote.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.CarNote);      // ADD 2009/09/07                        // 車輌備考
                        // int[] → byte[] に変換
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        foreach (int item in acceptOdrCarWork.FullModelFixedNoAry)
                            ms.Write(BitConverter.GetBytes(item), 0, sizeof(int));
                        byte[] verbinary = ms.ToArray();
                        ms.Close();

                        paraFullModelFixedNoAry.Value = SqlDataMediator.SqlSetBinary(verbinary);                               // フル型式固定番号配列

                        paraCategoryObjAry.Value = SqlDataMediator.SqlSetBinary(acceptOdrCarWork.CategoryObjAry);              // 装備オブジェクト配列

                        // --- ADD 2010/04/27 ---------->>>>>
                        // 自由検索型式固定番号配列
                        paraFreeSrchMdlFxdNoAry.Value = SqlDataMediator.SqlSetBinary(acceptOdrCarWork.FreeSrchMdlFxdNoAry);
                        // --- ADD 2010/04/27 ----------<<<<<
                        paraDomesticForeignCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DomesticForeignCode);    // 国産/外車区分 // ADD 2013/03/21
                        # endregion

                        int cnt = sqlCommand.ExecuteNonQuery();
                        al.Add(acceptOdrCarWork);
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
                    //sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            acceptOdrCarList = al;

            return status;
        }

        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
        #region 設定ファイル取得
        /// <summary>
        /// 設定ファイル取得
        /// </summary>
        /// <param name="dbCommandTimeout">タイムアウト時間</param>
        /// <remarks>
        /// <br>Note         : 設定ファイル取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // 初期値設定
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //タイムアウト時間を取得
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "設定ファイル取得エラー");
                }
            }

        }
        #endregion // 設定ファイル取得

        #region XMLファイル操作
        /// <summary>
        /// XMLファイル名取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名を連結
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // ファイルが存在しない場合は空白にする
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XMLファイル操作

        #region カレントフォルダ
        /// <summary>
        /// カレントフォルダ取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : カレントフォルダ処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML格納ディレクトリ取得
            try
            {
                // dll格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // レジストリ情報を取得できない場合は初期ディレクトリ // 運用上ありえないケース
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_APのLOGフォルダにログ出力
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // カレントフォルダ
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// 受注マスタ(車両)情報を論理削除します。
        /// </summary>
        /// <param name="acceptOdrCarList">論理削除する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarWork に格納されている受注マスタ(車両)情報を論理削除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        public int LogicalDelete(ref object acceptOdrCarList)
        {
            return this.LogicalDelete(ref acceptOdrCarList, 0);
        }

        /// <summary>
        /// 受注マスタ(車両)情報の論理削除を解除します。
        /// </summary>
        /// <param name="acceptOdrCarList">論理削除を解除する受注マスタ(車両)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarWork に格納されている受注マスタ(車両)情報の論理削除を解除します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        public int RevivalLogicalDelete(ref object acceptOdrCarList)
        {
            return this.LogicalDelete(ref acceptOdrCarList, 1);
        }

        /// <summary>
        /// 受注マスタ(車両)情報の論理削除を操作します。
        /// </summary>
        /// <param name="acceptOdrCarList">論理削除を操作する受注マスタ(車両)情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarWork に格納されている受注マスタ(車両)情報の論理削除を操作します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        private int LogicalDelete(ref object acceptOdrCarList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = acceptOdrCarList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

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
        /// 受注マスタ(車両)情報の論理削除を操作します。
        /// </summary>
        /// <param name="acceptOdrCarList">論理削除を操作する受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarWork に格納されている受注マスタ(車両)情報の論理削除を操作します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        public int LogicalDelete(ref ArrayList acceptOdrCarList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref acceptOdrCarList, procMode, sqlConnection, sqlTransaction);
        }

        /// <summary>
        /// 受注マスタ(車両)情報の論理削除を操作します。
        /// </summary>
        /// <param name="acceptOdrCarList">論理削除を操作する受注マスタ(車両)情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarWork に格納されている受注マスタ(車両)情報の論理削除を操作します。</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        private int LogicalDeleteProc(ref ArrayList acceptOdrCarList, int procMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (acceptOdrCarList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < acceptOdrCarList.Count; i++)
                    {
                        AcceptOdrCarWork acceptOdrCarWork = acceptOdrCarList[i] as AcceptOdrCarWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  ACAR.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ACAR.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  ACCEPTODRCARRF AS ACAR" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ACAR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ACAR.ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                        sqlText += "  AND ACAR.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND ACAR.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                        SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);
                        findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
                        findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != acceptOdrCarWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  ACCEPTODRCARRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                            sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);
                            findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
                            findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)acceptOdrCarWork;
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
                            else if (logicalDelCd == 0) acceptOdrCarWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else acceptOdrCarWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                acceptOdrCarWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptOdrCarWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(acceptOdrCarWork);
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

            acceptOdrCarList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="acceptOdrCarWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, AcceptOdrCarWork acceptOdrCarWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  ACAR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptOdrCarWork.EnterpriseCode);

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

            // 受注番号
            if (acceptOdrCarWork.AcceptAnOrderNo > 0)
            {
                retstring += "  AND ACAR.ACCEPTANORDERNORF = @FINDACCEPTANORDERNO" + Environment.NewLine;
                SqlParameter findAcceptAnOrderNo = sqlCommand.Parameters.Add("@FINDACCEPTANORDERNO", SqlDbType.Int);
                findAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcceptAnOrderNo);
            }

            // 受注ステータス
            if (acceptOdrCarWork.AcptAnOdrStatus > 0)
            {
                retstring += "  AND ACAR.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.AcptAnOdrStatus);
            }

            // データ入力システム
            if (acceptOdrCarWork.DataInputSystem > -1)
            {
                retstring += "  AND ACAR.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptOdrCarWork.DataInputSystem);
            }

            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → AcceptOdrCarWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AcceptOdrCarWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        /// </remarks>
        private AcceptOdrCarWork CopyToAcceptOdrCarWorkFromReader(ref SqlDataReader myReader)
        {
            AcceptOdrCarWork acceptOdrCarWork = new AcceptOdrCarWork();

            this.CopyToAcceptOdrCarWorkFromReader(ref myReader, ref acceptOdrCarWork);

            return acceptOdrCarWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → AcceptOdrCarWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="acceptOdrCarWork">AcceptOdrCarWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田</br>
        /// <br>Date       : 2008.05.28</br>
        /// <br>Update Note: SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/21</br>
        /// </remarks>
        private void CopyToAcceptOdrCarWorkFromReader(ref SqlDataReader myReader, ref AcceptOdrCarWork acceptOdrCarWork)
        {
            if (myReader != null && acceptOdrCarWork != null)
            {
                # region クラスへ格納
                acceptOdrCarWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
                acceptOdrCarWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
                acceptOdrCarWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));             // 企業コード
                acceptOdrCarWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
                acceptOdrCarWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));           // 更新従業員コード
                acceptOdrCarWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));             // 更新アセンブリID1
                acceptOdrCarWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));             // 更新アセンブリID2
                acceptOdrCarWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));        // 論理削除区分
                acceptOdrCarWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));            // 受注番号
                acceptOdrCarWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));            // 受注ステータス
                acceptOdrCarWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));            // データ入力システム
                acceptOdrCarWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));                          // 車両管理番号
                acceptOdrCarWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));                     // 車輌管理コード
                acceptOdrCarWork.NumberPlate1Code = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE1CODERF"));          // 陸運事務所番号
                acceptOdrCarWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));         // 陸運事務局名称
                acceptOdrCarWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));                 // 車両登録番号（種別）
                acceptOdrCarWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));                 // 車両登録番号（カナ）
                acceptOdrCarWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));                  // 車両登録番号（プレート番号）
                //acceptOdrCarWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF")); // 初年度
                acceptOdrCarWork.FirstEntryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));              // 初年度
                acceptOdrCarWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));                        // メーカーコード
                acceptOdrCarWork.MakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERFULLNAMERF"));               // メーカー全角名称
                acceptOdrCarWork.MakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERHALFNAMERF"));               // メーカー半角名称
                acceptOdrCarWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));                        // 車種コード
                acceptOdrCarWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));                  // 車種サブコード
                acceptOdrCarWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));               // 車種全角名称
                acceptOdrCarWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));               // 車種半角名称
                acceptOdrCarWork.ExhaustGasSign = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXHAUSTGASSIGNRF"));             // 排ガス記号
                acceptOdrCarWork.SeriesModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERIESMODELRF"));                   // シリーズ型式
                acceptOdrCarWork.CategorySignModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYSIGNMODELRF"));       // 型式（類別記号）
                acceptOdrCarWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));                       // 型式（フル型）
                acceptOdrCarWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));      // 型式指定番号
                acceptOdrCarWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));                      // 類別番号
                acceptOdrCarWork.FrameModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMEMODELRF"));                     // 車台型式
                acceptOdrCarWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));                           // 車台番号
                acceptOdrCarWork.SearchFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHFRAMENORF"));                // 車台番号（検索用）
                acceptOdrCarWork.EngineModelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENGINEMODELNMRF"));               // エンジン型式名称
                acceptOdrCarWork.RelevanceModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RELEVANCEMODELRF"));             // 関連型式
                acceptOdrCarWork.SubCarNmCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBCARNMCDRF"));                      // サブ車名コード
                acceptOdrCarWork.ModelGradeSname = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELGRADESNAMERF"));           // 型式グレード略称
                acceptOdrCarWork.ColorCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORCODERF"));                       // カラーコード
                acceptOdrCarWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));                     // カラー名称1
                acceptOdrCarWork.TrimCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMCODERF"));                         // トリムコード
                acceptOdrCarWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));                         // トリム名称
                acceptOdrCarWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF"));                            // 車両走行距離
                acceptOdrCarWork.CarNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNOTERF"));                         // 車輌備考   // ADD 2009/09/07
                byte[] varbinary = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FULLMODELFIXEDNOARYRF"));                       // フル型式固定番号配列

                acceptOdrCarWork.FullModelFixedNoAry = new int[(int)varbinary.Length / sizeof(int)];

                for (int idx = 0; idx < acceptOdrCarWork.FullModelFixedNoAry.Length; idx++)
                {
                    acceptOdrCarWork.FullModelFixedNoAry[idx] = BitConverter.ToInt32(varbinary, idx * sizeof(int));
                }

                acceptOdrCarWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("CATEGORYOBJARYRF"));             // 装備オブジェクト配列
                // --- ADD 2010/04/27 ---------->>>>>
                // 自由検索型式固定番号配列
                acceptOdrCarWork.FreeSrchMdlFxdNoAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FREESRCHMDLFXDNOARYRF"));
                // --- ADD 2010/04/27 ----------<<<<<
                acceptOdrCarWork.DomesticForeignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DOMESTICFOREIGNCODERF"));    // 国産/外車区分 // ADD 2013/03/21
                # endregion
            }
        }
        # endregion
    }
}

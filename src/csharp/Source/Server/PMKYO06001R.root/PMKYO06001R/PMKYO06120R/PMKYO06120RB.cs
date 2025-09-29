//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : FSI東 隆史
// 修 正 日  2012/07/26  修正内容 : 拠点管理 抽出条件追加対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;

using Broadleaf.Library.Data;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 従業員詳細マスタREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員詳細マスタ処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APEmployeeDtlDB : RemoteDB
    {
        #region [Private]
        // --- ADD 2012/07/26 ----------->>>>>
        private int _createDateTime = 0;
        private int _updateDateTime = 0;
        private int _enterpriseCode = 0;
        private int _fileHeaderGuid = 0;
        private int _updEmployeeCode = 0;
        private int _updAssemblyId1 = 0;
        private int _updAssemblyId2 = 0;
        private int _logicalDeleteCode = 0;
        private int _employeeCode = 0;
        private int _belongSubSectionCode = 0;
        private int _employAnalysCode1 = 0;
        private int _employAnalysCode2 = 0;
        private int _employAnalysCode3 = 0;
        private int _employAnalysCode4 = 0;
        private int _employAnalysCode5 = 0;
        private int _employAnalysCode6 = 0;
        private int _uoeSnmDiv = 0;
        private int _mailAddrKindCode1 = 0;
        private int _mailAddrKindName1 = 0;
        private int _mailAddress1 = 0;
        private int _mailSendCode1 = 0;
        private int _mailAddrKindCode2 = 0;
        private int _mailAddrKindName2 = 0;
        private int _mailAddress2 = 0;
        private int _mailSendCode2 = 0;
        // --- ADD 2012/07/26 -----------<<<<<
        #endregion

        /// <summary>
        /// 従業員詳細マスタREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APEmployeeDtlDB()
            : base("PMKYO06121D", "Broadleaf.Application.Remoting.ParamData.APEmployeeDtlWork", "EMPLOYEEDTLRF")
        {

        }

        #region [Read]
        /// <summary>
        /// 従業員詳細マスタの検索処理（日付指定）
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="employeeDtlArrList">従業員詳細マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchEmployeeDtl(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList employeeDtlArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            employeeDtlArrList = new ArrayList();
            APEmployeeDtlWork employeeDtlWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, EMPLOYEECODERF, BELONGSUBSECTIONCODERF, EMPLOYANALYSCODE1RF, EMPLOYANALYSCODE2RF, EMPLOYANALYSCODE3RF, EMPLOYANALYSCODE4RF, EMPLOYANALYSCODE5RF, EMPLOYANALYSCODE6RF, UOESNMDIVRF, MAILADDRKINDCODE1RF, MAILADDRKINDNAME1RF, MAILADDRESS1RF, MAILSENDCODE1RF, MAILADDRKINDCODE2RF, MAILADDRKINDNAME2RF, MAILADDRESS2RF, MAILSENDCODE2RF FROM EMPLOYEEDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 従業員詳細マスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    employeeDtlWork = new APEmployeeDtlWork();

                    employeeDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    employeeDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    employeeDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    employeeDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    employeeDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    employeeDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    employeeDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    employeeDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    employeeDtlWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    employeeDtlWork.BelongSubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BELONGSUBSECTIONCODERF"));
                    employeeDtlWork.EmployAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE1RF"));
                    employeeDtlWork.EmployAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE2RF"));
                    employeeDtlWork.EmployAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE3RF"));
                    employeeDtlWork.EmployAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE4RF"));
                    employeeDtlWork.EmployAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE5RF"));
                    employeeDtlWork.EmployAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYANALYSCODE6RF"));
                    employeeDtlWork.UOESnmDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESNMDIVRF"));
                    employeeDtlWork.MailAddrKindCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE1RF"));
                    employeeDtlWork.MailAddrKindName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME1RF"));
                    employeeDtlWork.MailAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS1RF"));
                    employeeDtlWork.MailSendCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE1RF"));
                    employeeDtlWork.MailAddrKindCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE2RF"));
                    employeeDtlWork.MailAddrKindName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME2RF"));
                    employeeDtlWork.MailAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS2RF"));
                    employeeDtlWork.MailSendCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE2RF"));

                    employeeDtlArrList.Add(employeeDtlWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APEmployeeDtlDB.SearchEmployeeDtl Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// 従業員詳細マスタの計数検索処理
        /// </summary>
        /// <param name="employeeDtlWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタデータ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchEmployeeDtlCount(APEmployeeDtlWork employeeDtlWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM EMPLOYEEDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);


                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeDtlWork.EnterpriseCode);
                findParaEmployeeCode.Value = employeeDtlWork.EmployeeCode;

                // 拠点情報設定マスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APSecInfoSetDB.SearchSecInfoSet Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        #endregion

        # region [Delete]
        /// <summary>
        ///  従業員詳細マスタデータ削除
        /// </summary>
        /// <param name="apEmployeeDtlWork">従業員詳細マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 従業員詳細マスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(APEmployeeDtlWork apEmployeeDtlWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM EMPLOYEEDTLRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = apEmployeeDtlWork.EnterpriseCode;
            findParaEmployeeCode.Value = apEmployeeDtlWork.EmployeeCode;

            // 従業員詳細マスタデータを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 従業員詳細マスタ登録
        /// </summary>
        /// <param name="apEmployeeDtlWork">従業員詳細マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 従業員詳細マスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(APEmployeeDtlWork apEmployeeDtlWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO EMPLOYEEDTLRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, EMPLOYEECODERF, BELONGSUBSECTIONCODERF, EMPLOYANALYSCODE1RF, EMPLOYANALYSCODE2RF, EMPLOYANALYSCODE3RF, EMPLOYANALYSCODE4RF, EMPLOYANALYSCODE5RF, EMPLOYANALYSCODE6RF, UOESNMDIVRF, MAILADDRKINDCODE1RF, MAILADDRKINDNAME1RF, MAILADDRESS1RF, MAILSENDCODE1RF, MAILADDRKINDCODE2RF, MAILADDRKINDNAME2RF, MAILADDRESS2RF, MAILSENDCODE2RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @EMPLOYEECODE, @BELONGSUBSECTIONCODE, @EMPLOYANALYSCODE1, @EMPLOYANALYSCODE2, @EMPLOYANALYSCODE3, @EMPLOYANALYSCODE4, @EMPLOYANALYSCODE5, @EMPLOYANALYSCODE6, @UOESNMDIV, @MAILADDRKINDCODE1, @MAILADDRKINDNAME1, @MAILADDRESS1, @MAILSENDCODE1, @MAILADDRKINDCODE2, @MAILADDRKINDNAME2, @MAILADDRESS2, @MAILSENDCODE2)";

            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraBelongSubSectionCode = sqlCommand.Parameters.Add("@BELONGSUBSECTIONCODE", SqlDbType.Int);
            SqlParameter paraEmployAnalysCode1 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE1", SqlDbType.Int);
            SqlParameter paraEmployAnalysCode2 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE2", SqlDbType.Int);
            SqlParameter paraEmployAnalysCode3 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE3", SqlDbType.Int);
            SqlParameter paraEmployAnalysCode4 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE4", SqlDbType.Int);
            SqlParameter paraEmployAnalysCode5 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE5", SqlDbType.Int);
            SqlParameter paraEmployAnalysCode6 = sqlCommand.Parameters.Add("@EMPLOYANALYSCODE6", SqlDbType.Int);
            SqlParameter paraUOESnmDiv = sqlCommand.Parameters.Add("@UOESNMDIV", SqlDbType.NChar);
            SqlParameter paraMailAddrKindCode1 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE1", SqlDbType.Int);
            SqlParameter paraMailAddrKindName1 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME1", SqlDbType.NVarChar);
            SqlParameter paraMailAddress1 = sqlCommand.Parameters.Add("@MAILADDRESS1", SqlDbType.NVarChar);
            SqlParameter paraMailSendCode1 = sqlCommand.Parameters.Add("@MAILSENDCODE1", SqlDbType.Int);
            SqlParameter paraMailAddrKindCode2 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE2", SqlDbType.Int);
            SqlParameter paraMailAddrKindName2 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME2", SqlDbType.NVarChar);
            SqlParameter paraMailAddress2 = sqlCommand.Parameters.Add("@MAILADDRESS2", SqlDbType.NVarChar);
            SqlParameter paraMailSendCode2 = sqlCommand.Parameters.Add("@MAILSENDCODE2", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apEmployeeDtlWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apEmployeeDtlWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apEmployeeDtlWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apEmployeeDtlWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apEmployeeDtlWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apEmployeeDtlWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apEmployeeDtlWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apEmployeeDtlWork.LogicalDeleteCode);
            if (string.IsNullOrEmpty(apEmployeeDtlWork.EmployeeCode.Trim()))
            {
                paraEmployeeCode.Value = apEmployeeDtlWork.EmployeeCode;
            }
            else
            {
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(apEmployeeDtlWork.EmployeeCode);
            }
            paraBelongSubSectionCode.Value = SqlDataMediator.SqlSetInt32(apEmployeeDtlWork.BelongSubSectionCode);
            paraEmployAnalysCode1.Value = SqlDataMediator.SqlSetInt32(apEmployeeDtlWork.EmployAnalysCode1);
            paraEmployAnalysCode2.Value = SqlDataMediator.SqlSetInt32(apEmployeeDtlWork.EmployAnalysCode2);
            paraEmployAnalysCode3.Value = SqlDataMediator.SqlSetInt32(apEmployeeDtlWork.EmployAnalysCode3);
            paraEmployAnalysCode4.Value = SqlDataMediator.SqlSetInt32(apEmployeeDtlWork.EmployAnalysCode4);
            paraEmployAnalysCode5.Value = SqlDataMediator.SqlSetInt32(apEmployeeDtlWork.EmployAnalysCode5);
            paraEmployAnalysCode6.Value = SqlDataMediator.SqlSetInt32(apEmployeeDtlWork.EmployAnalysCode6);
            paraUOESnmDiv.Value = SqlDataMediator.SqlSetString(apEmployeeDtlWork.UOESnmDiv);
            paraMailAddrKindCode1.Value = SqlDataMediator.SqlSetInt32(apEmployeeDtlWork.MailAddrKindCode1);
            paraMailAddrKindName1.Value = SqlDataMediator.SqlSetString(apEmployeeDtlWork.MailAddrKindName1);
            paraMailAddress1.Value = SqlDataMediator.SqlSetString(apEmployeeDtlWork.MailAddress1);
            paraMailSendCode1.Value = SqlDataMediator.SqlSetInt32(apEmployeeDtlWork.MailSendCode1);
            paraMailAddrKindCode2.Value = SqlDataMediator.SqlSetInt32(apEmployeeDtlWork.MailAddrKindCode2);
            paraMailAddrKindName2.Value = SqlDataMediator.SqlSetString(apEmployeeDtlWork.MailAddrKindName2);
            paraMailAddress2.Value = SqlDataMediator.SqlSetString(apEmployeeDtlWork.MailAddress2);
            paraMailSendCode2.Value = SqlDataMediator.SqlSetInt32(apEmployeeDtlWork.MailSendCode2);

            // 従業員詳細マスタデータを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region [Read][拠点管理 抽出条件追加対応]
        // --- ADD 2012/07/26 ------------------------------------->>>>>
        /// <summary>
        /// 従業員詳細マスタの検索処理（コード指定）
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="employeeArrList">従業員詳細マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/07/26</br>
        public int SearchEmployeeDtl(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList employeeArrList, out string retMessage)
        {
            return SearchEmployeeDtlProc(enterpriseCodes, paramList, sqlConnection, sqlTransaction, out employeeArrList, out retMessage);
        }

        /// <summary>
        /// 従業員詳細マスタの検索処理（コード指定）
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="employeeArrList">従業員詳細マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員詳細マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/07/26</br>
        private int SearchEmployeeDtlProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList employeeArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            employeeArrList = new ArrayList();
            retMessage = string.Empty;
            StringBuilder sqlStr = new StringBuilder();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            APEmployeeProcParamWork param = paramList as APEmployeeProcParamWork;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr.AppendLine("SELECT");
                sqlStr.AppendLine("    EMPLOYEEDTLRF.CREATEDATETIMERF,");
                sqlStr.AppendLine("    EMPLOYEEDTLRF.UPDATEDATETIMERF,");
                sqlStr.AppendLine("    EMPLOYEEDTLRF.ENTERPRISECODERF,");
                sqlStr.AppendLine("    EMPLOYEEDTLRF.FILEHEADERGUIDRF,");
                sqlStr.AppendLine("    EMPLOYEEDTLRF.UPDEMPLOYEECODERF,");
                sqlStr.AppendLine("    EMPLOYEEDTLRF.UPDASSEMBLYID1RF,");
                sqlStr.AppendLine("    EMPLOYEEDTLRF.UPDASSEMBLYID2RF,");
                sqlStr.AppendLine("    EMPLOYEEDTLRF.LOGICALDELETECODERF,");
                sqlStr.AppendLine("    EMPLOYEEDTLRF.EMPLOYEECODERF,");
                sqlStr.AppendLine("    BELONGSUBSECTIONCODERF,");
                sqlStr.AppendLine("    EMPLOYANALYSCODE1RF,");
                sqlStr.AppendLine("    EMPLOYANALYSCODE2RF,");
                sqlStr.AppendLine("    EMPLOYANALYSCODE3RF,");
                sqlStr.AppendLine("    EMPLOYANALYSCODE4RF,");
                sqlStr.AppendLine("    EMPLOYANALYSCODE5RF,");
                sqlStr.AppendLine("    EMPLOYANALYSCODE6RF,");
                sqlStr.AppendLine("    UOESNMDIVRF,");
                sqlStr.AppendLine("    MAILADDRKINDCODE1RF,");
                sqlStr.AppendLine("    MAILADDRKINDNAME1RF,");
                sqlStr.AppendLine("    MAILADDRESS1RF,");
                sqlStr.AppendLine("    MAILSENDCODE1RF,");
                sqlStr.AppendLine("    MAILADDRKINDCODE2RF,");
                sqlStr.AppendLine("    MAILADDRKINDNAME2RF,");
                sqlStr.AppendLine("    MAILADDRESS2RF,");
                sqlStr.AppendLine("    MAILSENDCODE2RF");
                sqlStr.AppendLine("FROM");
                sqlStr.AppendLine("    EMPLOYEEDTLRF");
                sqlStr.AppendLine("        INNER JOIN EMPLOYEERF ON EMPLOYEEDTLRF.ENTERPRISECODERF = EMPLOYEERF.ENTERPRISECODERF");
                sqlStr.AppendLine("            AND EMPLOYEEDTLRF.EMPLOYEECODERF = EMPLOYEERF.EMPLOYEECODERF");
                sqlStr.AppendLine("WHERE");
                sqlStr.AppendLine("        EMPLOYEEDTLRF.ENTERPRISECODERF = @FINDENTERPRISECODE");

                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND EMPLOYEEDTLRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                }

                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND EMPLOYEEDTLRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                }

                // 拠点コード
                if (!string.IsNullOrEmpty(param.BelongSectionCdBeginRF))
                {
                    sqlStr.Append(" AND BELONGSECTIONCODERF >= @BELONGSECTIONCODEBEGRF");
                    SqlParameter belongSectionCdBeginRF = sqlCommand.Parameters.Add("@BELONGSECTIONCODEBEGRF", SqlDbType.NChar);
                    belongSectionCdBeginRF.Value = SqlDataMediator.SqlSetString(param.BelongSectionCdBeginRF);
                }

                if (!string.IsNullOrEmpty(param.BelongSectionCdEndRF))
                {
                    sqlStr.Append(" AND BELONGSECTIONCODERF <= @BELONGSECTIONCODEENDRF");
                    SqlParameter belongSectionCdEndRF = sqlCommand.Parameters.Add("@BELONGSECTIONCODEENDRF", SqlDbType.NChar);
                    belongSectionCdEndRF.Value = SqlDataMediator.SqlSetString(param.BelongSectionCdEndRF);
                }

                // 従業員コード
                if (!string.IsNullOrEmpty(param.EmployeeCdBeginRF))
                {
                    sqlStr.Append(" AND EMPLOYEEDTLRF.EMPLOYEECODERF >= @EMPLOYEECODEBEGRF");
                    SqlParameter employeeCdBeginRF = sqlCommand.Parameters.Add("@EMPLOYEECODEBEGRF", SqlDbType.NChar);
                    employeeCdBeginRF.Value = SqlDataMediator.SqlSetString(param.EmployeeCdBeginRF);
                }

                if (!string.IsNullOrEmpty(param.EmployeeCdEndRF))
                {
                    sqlStr.Append(" AND EMPLOYEEDTLRF.EMPLOYEECODERF <= @EMPLOYEECODEENDRF");
                    SqlParameter employeeCdEndRF = sqlCommand.Parameters.Add("@EMPLOYEECODEENDRF", SqlDbType.NChar);
                    employeeCdEndRF.Value = SqlDataMediator.SqlSetString(param.EmployeeCdEndRF);
                }

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);

                //従業員詳細マスタデータ用SQL
                sqlCommand.CommandText = sqlStr.ToString();
                // 読み込み
                myReader = sqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    SetIndex(myReader);
                }

                while (myReader.Read())
                {
                    employeeArrList.Add(CopyFromMyReaderToAPEmployeeDtlWork(myReader));
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APEmployeeDB.SearchEmployee Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        /// <summary>
        /// インデックス格納処理
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : カラムインデックス格納処理を行う</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/07/26</br>
        /// </remarks>
        private void SetIndex(SqlDataReader myReader)
        {
            _createDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
            _updateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
            _enterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
            _fileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
            _updEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
            _updAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
            _updAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
            _logicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
            _employeeCode = myReader.GetOrdinal("EMPLOYEECODERF");
            _belongSubSectionCode = myReader.GetOrdinal("BELONGSUBSECTIONCODERF");
            _employAnalysCode1 = myReader.GetOrdinal("EMPLOYANALYSCODE1RF");
            _employAnalysCode2 = myReader.GetOrdinal("EMPLOYANALYSCODE2RF");
            _employAnalysCode3 = myReader.GetOrdinal("EMPLOYANALYSCODE3RF");
            _employAnalysCode4 = myReader.GetOrdinal("EMPLOYANALYSCODE4RF");
            _employAnalysCode5 = myReader.GetOrdinal("EMPLOYANALYSCODE5RF");
            _employAnalysCode6 = myReader.GetOrdinal("EMPLOYANALYSCODE6RF");
            _uoeSnmDiv = myReader.GetOrdinal("UOESNMDIVRF");
            _mailAddrKindCode1 = myReader.GetOrdinal("MAILADDRKINDCODE1RF");
            _mailAddrKindName1 = myReader.GetOrdinal("MAILADDRKINDNAME1RF");
            _mailAddress1 = myReader.GetOrdinal("MAILADDRESS1RF");
            _mailSendCode1 = myReader.GetOrdinal("MAILSENDCODE1RF");
            _mailAddrKindCode2 = myReader.GetOrdinal("MAILADDRKINDCODE2RF");
            _mailAddrKindName2 = myReader.GetOrdinal("MAILADDRKINDNAME2RF");
            _mailAddress2 = myReader.GetOrdinal("MAILADDRESS2RF");
            _mailSendCode2 = myReader.GetOrdinal("MAILSENDCODE2RF");
        }

        /// <summary>
        /// 従業員詳細マスタデータを取得
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>従業員詳細マスタデータ</returns>
        /// <br>Note       : 従業員詳細マスタデータを戻します</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/07/26</br>
        private APEmployeeDtlWork CopyFromMyReaderToAPEmployeeDtlWork(SqlDataReader myReader)
        {
            APEmployeeDtlWork employeeDtlWork = new APEmployeeDtlWork();

            employeeDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _createDateTime);
            employeeDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _updateDateTime);
            employeeDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _enterpriseCode);
            employeeDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _fileHeaderGuid);
            employeeDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _updEmployeeCode);
            employeeDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _updAssemblyId1);
            employeeDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _updAssemblyId2);
            employeeDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _logicalDeleteCode);
            employeeDtlWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, _employeeCode);
            employeeDtlWork.BelongSubSectionCode = SqlDataMediator.SqlGetInt32(myReader, _belongSubSectionCode);
            employeeDtlWork.EmployAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, _employAnalysCode1);
            employeeDtlWork.EmployAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, _employAnalysCode2);
            employeeDtlWork.EmployAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, _employAnalysCode3);
            employeeDtlWork.EmployAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, _employAnalysCode4);
            employeeDtlWork.EmployAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, _employAnalysCode5);
            employeeDtlWork.EmployAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, _employAnalysCode6);
            employeeDtlWork.UOESnmDiv = SqlDataMediator.SqlGetString(myReader, _uoeSnmDiv);
            employeeDtlWork.MailAddrKindCode1 = SqlDataMediator.SqlGetInt32(myReader, _mailAddrKindCode1);
            employeeDtlWork.MailAddrKindName1 = SqlDataMediator.SqlGetString(myReader, _mailAddrKindName1);
            employeeDtlWork.MailAddress1 = SqlDataMediator.SqlGetString(myReader, _mailAddress1);
            employeeDtlWork.MailSendCode1 = SqlDataMediator.SqlGetInt32(myReader, _mailSendCode1);
            employeeDtlWork.MailAddrKindCode2 = SqlDataMediator.SqlGetInt32(myReader, _mailAddrKindCode2);
            employeeDtlWork.MailAddrKindName2 = SqlDataMediator.SqlGetString(myReader, _mailAddrKindName2);
            employeeDtlWork.MailAddress2 = SqlDataMediator.SqlGetString(myReader, _mailAddress2);
            employeeDtlWork.MailSendCode2 = SqlDataMediator.SqlGetInt32(myReader, _mailSendCode2);

            return employeeDtlWork;
        }
        // --- ADD 2012/07/26 -------------------------------------<<<<<
        #endregion
    }
}

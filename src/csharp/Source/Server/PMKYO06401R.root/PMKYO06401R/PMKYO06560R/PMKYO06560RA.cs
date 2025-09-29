//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   マスタ送受信処理                           　　 //
// Name Space       :   Broadleaf.Application.Remoting           	    //
//                  :   PMKYO06560R.DLL							        //
// Programmer       :   呉元嘯	                                        //
// Date             :   2009.04.30                                      //
//----------------------------------------------------------------------//
// Update Note      :   張莉莉　2009.06.12　							//
//                  :   public MethodでSQL文字が駄目対応について        //
//----------------------------------------------------------------------//
// Update Note      :   張莉莉　2011.08.26　							//
//                  :   DC履歴ログとDC各データのクリア処理を追加        //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 従業員別売上目標設定マスタリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員別売上目標設定マスタデータの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCEmpSalesTargetDB : RemoteDB
    {
        /// <summary>
        /// 従業員別売上目標設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCEmpSalesTargetDB()
            : base("PMKYO06561D", "Broadleaf.Application.Remoting.ParamData.DCEmpSalesTargetWork", "EMPSALESTARGETRF")
        {

        }

        #region [Read]
        /// <summary>
        /// 従業員別売上目標設定マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="empSalesTargetArrList">従業員別売上目標設定マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員別売上目標設定マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchEmpSalesTarget(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList empSalesTargetArrList, out string retMessage)
        {
            return SearchEmpSalesTargetProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                                 sqlTransaction, out empSalesTargetArrList, out retMessage);
        }
        /// <summary>
        /// 従業員別売上目標設定マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="empSalesTargetArrList">従業員別売上目標設定マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員別売上目標設定マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchEmpSalesTargetProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList empSalesTargetArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            empSalesTargetArrList = new ArrayList();
            DCEmpSalesTargetWork empSalesTargetWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TARGETSETCDRF, TARGETCONTRASTCDRF, TARGETDIVIDECODERF, TARGETDIVIDENAMERF, EMPLOYEEDIVCDRF, SUBSECTIONCODERF, EMPLOYEECODERF, APPLYSTADATERF, APPLYENDDATERF, SALESTARGETMONEYRF, SALESTARGETPROFITRF, SALESTARGETCOUNTRF FROM EMPSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //従業員別売上目標設定マスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    empSalesTargetWork = new DCEmpSalesTargetWork();

                    empSalesTargetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    empSalesTargetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    empSalesTargetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    empSalesTargetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    empSalesTargetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    empSalesTargetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    empSalesTargetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    empSalesTargetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    empSalesTargetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    empSalesTargetWork.TargetSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETSETCDRF"));
                    empSalesTargetWork.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF"));
                    empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                    empSalesTargetWork.TargetDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDENAMERF"));
                    empSalesTargetWork.EmployeeDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYEEDIVCDRF"));
                    empSalesTargetWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    empSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    empSalesTargetWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
                    empSalesTargetWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
                    empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEYRF"));
                    empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFITRF"));
                    empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNTRF"));

                    empSalesTargetArrList.Add(empSalesTargetWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCEmpSalesTargetDB.SearchEmpSalesTarget Exception=" + ex.Message);
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
        #endregion

        # region [Delete]
        /// <summary>
        ///  従業員別売上目標設定マスタデータ削除
        /// </summary>
        /// <param name="dcEmpSalesTargetWork">従業員別売上目標設定マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 従業員別売上目標設定マスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(DCEmpSalesTargetWork dcEmpSalesTargetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcEmpSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  従業員別売上目標設定マスタデータ削除
        /// </summary>
        /// <param name="dcEmpSalesTargetWork">従業員別売上目標設定マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 従業員別売上目標設定マスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(DCEmpSalesTargetWork dcEmpSalesTargetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM EMPSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";

            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
            SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
            SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
            SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
            SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
            SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = dcEmpSalesTargetWork.EnterpriseCode;
            findParaSectionCode.Value = dcEmpSalesTargetWork.SectionCode;
            findParaTargetSetCd.Value = dcEmpSalesTargetWork.TargetSetCd;
            findParaTargetContrastCd.Value = dcEmpSalesTargetWork.TargetContrastCd;
            findParaTargetDivideCode.Value = dcEmpSalesTargetWork.TargetDivideCode;
            findParaEmployeeDivCd.Value = dcEmpSalesTargetWork.EmployeeDivCd;
            findParaSubSectionCode.Value = dcEmpSalesTargetWork.SubSectionCode;
            findParaEmployeeCode.Value = dcEmpSalesTargetWork.EmployeeCode;


            // 従業員別売上目標設定マスタデータを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 従業員別売上目標設定マスタ登録
        /// </summary>
        /// <param name="dcEmpSalesTargetWork">従業員別売上目標設定マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 従業員別売上目標設定マスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(DCEmpSalesTargetWork dcEmpSalesTargetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcEmpSalesTargetWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 従業員別売上目標設定マスタ登録
        /// </summary>
        /// <param name="dcEmpSalesTargetWork">従業員別売上目標設定マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 従業員別売上目標設定マスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(DCEmpSalesTargetWork dcEmpSalesTargetWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO EMPSALESTARGETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TARGETSETCDRF, TARGETCONTRASTCDRF, TARGETDIVIDECODERF, TARGETDIVIDENAMERF, EMPLOYEEDIVCDRF, SUBSECTIONCODERF, EMPLOYEECODERF, APPLYSTADATERF, APPLYENDDATERF, SALESTARGETMONEYRF, SALESTARGETPROFITRF, SALESTARGETCOUNTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TARGETSETCD, @TARGETCONTRASTCD, @TARGETDIVIDECODE, @TARGETDIVIDENAME, @EMPLOYEEDIVCD, @SUBSECTIONCODE, @EMPLOYEECODE, @APPLYSTADATE, @APPLYENDDATE, @SALESTARGETMONEY, @SALESTARGETPROFIT, @SALESTARGETCOUNT)";

            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            SqlParameter paraTargetSetCd = sqlCommand.Parameters.Add("@TARGETSETCD", SqlDbType.Int);
            SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
            SqlParameter paraTargetDivideCode = sqlCommand.Parameters.Add("@TARGETDIVIDECODE", SqlDbType.NChar);
            SqlParameter paraTargetDivideName = sqlCommand.Parameters.Add("@TARGETDIVIDENAME", SqlDbType.NVarChar);
            SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
            SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
            SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
            SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);
            SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);
            SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcEmpSalesTargetWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcEmpSalesTargetWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcEmpSalesTargetWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcEmpSalesTargetWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcEmpSalesTargetWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcEmpSalesTargetWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcEmpSalesTargetWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcEmpSalesTargetWork.LogicalDeleteCode);
            if (string.IsNullOrEmpty(dcEmpSalesTargetWork.SectionCode.Trim()))
            {
                paraSectionCode.Value = dcEmpSalesTargetWork.SectionCode;
            }
            else
            {
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcEmpSalesTargetWork.SectionCode);
            }
            paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(dcEmpSalesTargetWork.TargetSetCd);
            paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(dcEmpSalesTargetWork.TargetContrastCd);
            if (string.IsNullOrEmpty(dcEmpSalesTargetWork.TargetDivideCode.Trim()))
            {
                paraTargetDivideCode.Value = dcEmpSalesTargetWork.TargetDivideCode;
            }
            else
            {
                paraTargetDivideCode.Value = SqlDataMediator.SqlSetString(dcEmpSalesTargetWork.TargetDivideCode);
            }
            paraTargetDivideName.Value = SqlDataMediator.SqlSetString(dcEmpSalesTargetWork.TargetDivideName);
            paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(dcEmpSalesTargetWork.EmployeeDivCd);
            paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(dcEmpSalesTargetWork.SubSectionCode);
            if (string.IsNullOrEmpty(dcEmpSalesTargetWork.EmployeeCode.Trim()))
            {
                paraEmployeeCode.Value = dcEmpSalesTargetWork.EmployeeCode;
            }
            else
            {
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(dcEmpSalesTargetWork.EmployeeCode);
            }
            paraApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcEmpSalesTargetWork.ApplyStaDate);
            paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcEmpSalesTargetWork.ApplyEndDate);
            paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(dcEmpSalesTargetWork.SalesTargetMoney);
            paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(dcEmpSalesTargetWork.SalesTargetProfit);
            paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(dcEmpSalesTargetWork.SalesTargetCount);

            // 従業員別売上目標設定マスタデータを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        // ADD 2011.08.26 ---------->>>>>
        # region [Clear]DEL by Liangsd     2011/09/06
        //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
        //// Rクラスの MethodでSQL文字が駄目
        ///// <summary>
        ///// データクリア
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sqlConnection">データベース接続情報</param>
        ///// <param name="sqlTransaction">トランザクション情報</param>
        ///// <param name="sqlCommand">SQLコメント</param>
        ///// <returns></returns>
        //public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    ClearProc(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        //}
        ///// <summary>
        ///// データクリア
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sqlConnection">データベース接続情報</param>
        ///// <param name="sqlTransaction">トランザクション情報</param>
        ///// <param name="sqlCommand">SQLコメント</param>
        ///// <returns></returns>
        //private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        //{
        //    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

        //    // Deleteコマンドの生成
        //    sqlCommand.CommandText = "DELETE FROM EMPSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
        //    //Prameterオブジェクトの作成
        //    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //    //Parameterオブジェクトへ値設定
        //    findParaEnterpriseCode.Value = enterpriseCode;

        //    // 拠点情報設定マスタデータを削除する
        //    sqlCommand.ExecuteNonQuery();
        //}
        //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
        #endregion
        // ADD 2011.08.26 ----------<<<<<
    }
}
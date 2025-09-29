//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   マスタ送受信処理　                           　 //
// Name Space       :   Broadleaf.Application.Remoting           	    //
//                  :   PMKYO06430R.DLL							        //
// Programmer       :   呉元嘯	                                        //
// Date             :   2009.04.30                                      //
//----------------------------------------------------------------------//
// Update Note      :   張莉莉　2009.06.12　							//
//                  :   public MethodでSQL文字が駄目対応について        //
//----------------------------------------------------------------------//
// Update Note      :   張莉莉　2011.08.26　							//
//                  :   DC履歴ログとDC各データのクリア処理を追加        //
//----------------------------------------------------------------------//
// Update Note      :   FSI東 隆史　2012.07.26　						//
//                  :   拠点管理 抽出条件追加対応                       //
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
    /// 従業員マスタリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員マスタデータの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.4.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCEmployeeDB : RemoteDB
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
        private int _name = 0;
        private int _kana = 0;
        private int _shortName = 0;
        private int _sexCode = 0;
        private int _sexName = 0;
        private int _birthday = 0;
        private int _companyTelNo = 0;
        private int _portableTelNo = 0;
        private int _postCode = 0;
        private int _businessCode = 0;
        private int _frontMechaCode = 0;
        private int _inOutsideCompanyCode = 0;
        private int _belongSectionCode = 0;
        private int _lvrRtCstGeneral = 0;
        private int _lvrRtCstCarInspect = 0;
        private int _lvrRtCstBodyPaint = 0;
        private int _lvrRtCstBodyRepair = 0;
        private int _loginId = 0;
        private int _loginPassword = 0;
        private int _userAdminFlag = 0;
        private int _enterCompanyDate = 0;
        private int _retirementDate = 0;
        private int _authorityLevel1 = 0;
        private int _authorityLevel2 = 0;
        // --- ADD 2012/07/26 -----------<<<<<
        #endregion

        /// <summary>
        /// 従業員マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.4.30</br>
        /// </remarks>
        public DCEmployeeDB()
            : base("PMKYO06431D", "Broadleaf.Application.Remoting.ParamData.DCEmployeeWork", "EMPLOYEERF")
        {

        }

        #region [Read]
        /// <summary>
        /// 従業員マスタの検索処理（日付指定）
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="employeeArrList">従業員マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchEmployee(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
           SqlTransaction sqlTransaction, out ArrayList employeeArrList, out string retMessage)
        {
            return SearchEmployeeProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
                              sqlTransaction, out employeeArrList, out retMessage);
        }
        /// <summary>
        /// 従業員マスタの検索処理（日付指定）
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="employeeArrList">従業員マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchEmployeeProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList employeeArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            employeeArrList = new ArrayList();
            DCEmployeeWork employeeWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, EMPLOYEECODERF, NAMERF, KANARF, SHORTNAMERF, SEXCODERF, SEXNAMERF, BIRTHDAYRF, COMPANYTELNORF, PORTABLETELNORF, POSTCODERF, BUSINESSCODERF, FRONTMECHACODERF, INOUTSIDECOMPANYCODERF, BELONGSECTIONCODERF, LVRRTCSTGENERALRF, LVRRTCSTCARINSPECTRF, LVRRTCSTBODYPAINTRF, LVRRTCSTBODYREPAIRRF, LOGINIDRF, LOGINPASSWORDRF, USERADMINFLAGRF, ENTERCOMPANYDATERF, RETIREMENTDATERF, AUTHORITYLEVEL1RF, AUTHORITYLEVEL2RF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //従業員マスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    employeeWork = new DCEmployeeWork();

                    employeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    employeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    employeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    employeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    employeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    employeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    employeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    employeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    employeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    employeeWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                    employeeWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                    employeeWork.ShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
                    employeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEXCODERF"));
                    employeeWork.SexName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEXNAMERF"));
                    employeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BIRTHDAYRF"));
                    employeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNORF"));
                    employeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                    employeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSTCODERF"));
                    employeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSCODERF"));
                    employeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTMECHACODERF"));
                    employeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
                    employeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSECTIONCODERF"));
                    employeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTGENERALRF"));
                    employeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
                    employeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
                    employeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
                    employeeWork.LoginId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINIDRF"));
                    employeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINPASSWORDRF"));
                    employeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERADMINFLAGRF"));
                    employeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ENTERCOMPANYDATERF"));
                    employeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RETIREMENTDATERF"));
                    employeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL1RF"));
                    employeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVEL2RF"));

                    employeeArrList.Add(employeeWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCEmployeeDB.SearchEmployee Exception=" + ex.Message);
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
        ///  従業員マスタデータ削除
        /// </summary>
        /// <param name="dcEmployeeWork">従業員マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 従業員マスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(DCEmployeeWork dcEmployeeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcEmployeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  従業員マスタデータ削除
        /// </summary>
        /// <param name="dcEmployeeWork">従業員マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 従業員マスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void DeleteProc(DCEmployeeWork dcEmployeeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = dcEmployeeWork.EnterpriseCode;
            findParaEmployeeCode.Value = dcEmployeeWork.EmployeeCode;


            // 従業員マスタデータを削除する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 従業員マスタ登録
        /// </summary>
        /// <param name="dcEmployeeWork">従業員マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 従業員マスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Insert(DCEmployeeWork dcEmployeeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcEmployeeWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 従業員マスタ登録
        /// </summary>
        /// <param name="dcEmployeeWork">従業員マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 従業員マスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private void InsertProc(DCEmployeeWork dcEmployeeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO EMPLOYEERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, EMPLOYEECODERF, NAMERF, KANARF, SHORTNAMERF, SEXCODERF, SEXNAMERF, BIRTHDAYRF, COMPANYTELNORF, PORTABLETELNORF, POSTCODERF, BUSINESSCODERF, FRONTMECHACODERF, INOUTSIDECOMPANYCODERF, BELONGSECTIONCODERF, LVRRTCSTGENERALRF, LVRRTCSTCARINSPECTRF, LVRRTCSTBODYPAINTRF, LVRRTCSTBODYREPAIRRF, LOGINIDRF, LOGINPASSWORDRF, USERADMINFLAGRF, ENTERCOMPANYDATERF, RETIREMENTDATERF, AUTHORITYLEVEL1RF, AUTHORITYLEVEL2RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @EMPLOYEECODE, @NAME, @KANA, @SHORTNAME, @SEXCODE, @SEXNAME, @BIRTHDAY, @COMPANYTELNO, @PORTABLETELNO, @POSTCODE, @BUSINESSCODE, @FRONTMECHACODE, @INOUTSIDECOMPANYCODE, @BELONGSECTIONCODE, @LVRRTCSTGENERAL, @LVRRTCSTCARINSPECT, @LVRRTCSTBODYPAINT, @LVRRTCSTBODYREPAIR, @LOGINID, @LOGINPASSWORD, @USERADMINFLAG, @ENTERCOMPANYDATE, @RETIREMENTDATE, @AUTHORITYLEVEL1, @AUTHORITYLEVEL2)";

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
            SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
            SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
            SqlParameter paraShortName = sqlCommand.Parameters.Add("@SHORTNAME", SqlDbType.NVarChar);
            SqlParameter paraSexCode = sqlCommand.Parameters.Add("@SEXCODE", SqlDbType.Int);
            SqlParameter paraSexName = sqlCommand.Parameters.Add("@SEXNAME", SqlDbType.NVarChar);
            SqlParameter paraBirthday = sqlCommand.Parameters.Add("@BIRTHDAY", SqlDbType.Int);
            SqlParameter paraCompanyTelNo = sqlCommand.Parameters.Add("@COMPANYTELNO", SqlDbType.NVarChar);
            SqlParameter paraPortableTelNo = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
            SqlParameter paraPostCode = sqlCommand.Parameters.Add("@POSTCODE", SqlDbType.Int);
            SqlParameter paraBusinessCode = sqlCommand.Parameters.Add("@BUSINESSCODE", SqlDbType.Int);
            SqlParameter paraFrontMechaCode = sqlCommand.Parameters.Add("@FRONTMECHACODE", SqlDbType.Int);
            SqlParameter paraInOutsideCompanyCode = sqlCommand.Parameters.Add("@INOUTSIDECOMPANYCODE", SqlDbType.Int);
            SqlParameter paraBelongSectionCode = sqlCommand.Parameters.Add("@BELONGSECTIONCODE", SqlDbType.NChar);
            SqlParameter paraLvrRtCstGeneral = sqlCommand.Parameters.Add("@LVRRTCSTGENERAL", SqlDbType.BigInt);
            SqlParameter paraLvrRtCstCarInspect = sqlCommand.Parameters.Add("@LVRRTCSTCARINSPECT", SqlDbType.BigInt);
            SqlParameter paraLvrRtCstBodyPaint = sqlCommand.Parameters.Add("@LVRRTCSTBODYPAINT", SqlDbType.BigInt);
            SqlParameter paraLvrRtCstBodyRepair = sqlCommand.Parameters.Add("@LVRRTCSTBODYREPAIR", SqlDbType.BigInt);
            SqlParameter paraLoginId = sqlCommand.Parameters.Add("@LOGINID", SqlDbType.NVarChar);
            SqlParameter paraLoginPassword = sqlCommand.Parameters.Add("@LOGINPASSWORD", SqlDbType.NVarChar);
            SqlParameter paraUserAdminFlag = sqlCommand.Parameters.Add("@USERADMINFLAG", SqlDbType.Int);
            SqlParameter paraEnterCompanyDate = sqlCommand.Parameters.Add("@ENTERCOMPANYDATE", SqlDbType.Int);
            SqlParameter paraRetirementDate = sqlCommand.Parameters.Add("@RETIREMENTDATE", SqlDbType.Int);
            SqlParameter paraAuthorityLevel1 = sqlCommand.Parameters.Add("@AUTHORITYLEVEL1", SqlDbType.Int);
            SqlParameter paraAuthorityLevel2 = sqlCommand.Parameters.Add("@AUTHORITYLEVEL2", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcEmployeeWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcEmployeeWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcEmployeeWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcEmployeeWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcEmployeeWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcEmployeeWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcEmployeeWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcEmployeeWork.LogicalDeleteCode);
            if (string.IsNullOrEmpty(dcEmployeeWork.EmployeeCode.Trim()))
            {
                paraEmployeeCode.Value = dcEmployeeWork.EmployeeCode;
            }
            else
            {
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(dcEmployeeWork.EmployeeCode);
            }
            paraName.Value = SqlDataMediator.SqlSetString(dcEmployeeWork.Name);
            paraKana.Value = SqlDataMediator.SqlSetString(dcEmployeeWork.Kana);
            paraShortName.Value = SqlDataMediator.SqlSetString(dcEmployeeWork.ShortName);
            paraSexCode.Value = SqlDataMediator.SqlSetInt32(dcEmployeeWork.SexCode);
            paraSexName.Value = SqlDataMediator.SqlSetString(dcEmployeeWork.SexName);
            paraBirthday.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcEmployeeWork.Birthday);
            paraCompanyTelNo.Value = SqlDataMediator.SqlSetString(dcEmployeeWork.CompanyTelNo);
            paraPortableTelNo.Value = SqlDataMediator.SqlSetString(dcEmployeeWork.PortableTelNo);
            paraPostCode.Value = SqlDataMediator.SqlSetInt32(dcEmployeeWork.PostCode);
            paraBusinessCode.Value = SqlDataMediator.SqlSetInt32(dcEmployeeWork.BusinessCode);
            paraFrontMechaCode.Value = SqlDataMediator.SqlSetInt32(dcEmployeeWork.FrontMechaCode);
            paraInOutsideCompanyCode.Value = SqlDataMediator.SqlSetInt32(dcEmployeeWork.InOutsideCompanyCode);
            paraBelongSectionCode.Value = SqlDataMediator.SqlSetString(dcEmployeeWork.BelongSectionCode);
            paraLvrRtCstGeneral.Value = SqlDataMediator.SqlSetInt64(dcEmployeeWork.LvrRtCstGeneral);
            paraLvrRtCstCarInspect.Value = SqlDataMediator.SqlSetInt64(dcEmployeeWork.LvrRtCstCarInspect);
            paraLvrRtCstBodyPaint.Value = SqlDataMediator.SqlSetInt64(dcEmployeeWork.LvrRtCstBodyPaint);
            paraLvrRtCstBodyRepair.Value = SqlDataMediator.SqlSetInt64(dcEmployeeWork.LvrRtCstBodyRepair);
            paraLoginId.Value = SqlDataMediator.SqlSetString(dcEmployeeWork.LoginId);
            paraLoginPassword.Value = SqlDataMediator.SqlSetString(dcEmployeeWork.LoginPassword);
            paraUserAdminFlag.Value = SqlDataMediator.SqlSetInt32(dcEmployeeWork.UserAdminFlag);
            paraEnterCompanyDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcEmployeeWork.EnterCompanyDate);
            paraRetirementDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(dcEmployeeWork.RetirementDate);
            paraAuthorityLevel1.Value = SqlDataMediator.SqlSetInt32(dcEmployeeWork.AuthorityLevel1);
            paraAuthorityLevel2.Value = SqlDataMediator.SqlSetInt32(dcEmployeeWork.AuthorityLevel2);

            // 従業員マスタデータを登録する
            sqlCommand.ExecuteNonQuery();
        }
        #endregion

        #region [Read][拠点管理 抽出条件追加対応]
        // --- ADD 2012/07/26 ------------------------------------->>>>>
        /// <summary>
        /// 従業員マスタの検索処理（コード指定）
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="employeeArrList">従業員マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/07/26</br>
        public int SearchEmployee(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList employeeArrList, out string retMessage)
        {
            return SearchEmployeeProc(enterpriseCodes, paramList, sqlConnection, sqlTransaction, out employeeArrList, out retMessage);
        }

        /// <summary>
        /// 従業員マスタの検索処理（コード指定）
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="employeeArrList">従業員マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/07/26</br>
        private int SearchEmployeeProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList employeeArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            employeeArrList = new ArrayList();
            retMessage = string.Empty;
            StringBuilder sqlStr = new StringBuilder();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            EmployeeProcParamWork param = paramList as EmployeeProcParamWork;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr.AppendLine("SELECT");
                sqlStr.AppendLine("    CREATEDATETIMERF,");
                sqlStr.AppendLine("    UPDATEDATETIMERF,");
                sqlStr.AppendLine("    ENTERPRISECODERF,");
                sqlStr.AppendLine("    FILEHEADERGUIDRF,");
                sqlStr.AppendLine("    UPDEMPLOYEECODERF,");
                sqlStr.AppendLine("    UPDASSEMBLYID1RF,");
                sqlStr.AppendLine("    UPDASSEMBLYID2RF,");
                sqlStr.AppendLine("    LOGICALDELETECODERF,");
                sqlStr.AppendLine("    EMPLOYEECODERF,");
                sqlStr.AppendLine("    NAMERF,");
                sqlStr.AppendLine("    KANARF,");
                sqlStr.AppendLine("    SHORTNAMERF,");
                sqlStr.AppendLine("    SEXCODERF,");
                sqlStr.AppendLine("    SEXNAMERF,");
                sqlStr.AppendLine("    BIRTHDAYRF,");
                sqlStr.AppendLine("    COMPANYTELNORF,");
                sqlStr.AppendLine("    PORTABLETELNORF,");
                sqlStr.AppendLine("    POSTCODERF,");
                sqlStr.AppendLine("    BUSINESSCODERF,");
                sqlStr.AppendLine("    FRONTMECHACODERF,");
                sqlStr.AppendLine("    INOUTSIDECOMPANYCODERF,");
                sqlStr.AppendLine("    BELONGSECTIONCODERF,");
                sqlStr.AppendLine("    LVRRTCSTGENERALRF,");
                sqlStr.AppendLine("    LVRRTCSTCARINSPECTRF,");
                sqlStr.AppendLine("    LVRRTCSTBODYPAINTRF,");
                sqlStr.AppendLine("    LVRRTCSTBODYREPAIRRF,");
                sqlStr.AppendLine("    LOGINIDRF,");
                sqlStr.AppendLine("    LOGINPASSWORDRF,");
                sqlStr.AppendLine("    USERADMINFLAGRF,");
                sqlStr.AppendLine("    ENTERCOMPANYDATERF,");
                sqlStr.AppendLine("    RETIREMENTDATERF,");
                sqlStr.AppendLine("    AUTHORITYLEVEL1RF,");
                sqlStr.AppendLine("    AUTHORITYLEVEL2RF");
                sqlStr.AppendLine("FROM");
                sqlStr.AppendLine("    EMPLOYEERF");
                sqlStr.AppendLine("WHERE");
                sqlStr.AppendLine("        ENTERPRISECODERF = @FINDENTERPRISECODE");

                if (param.UpdateDateTimeBegin != 0)
                {
                    sqlStr.Append(" AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                }

                if (param.UpdateDateTimeEnd != 0)
                {
                    sqlStr.Append(" AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                }

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

                if (!string.IsNullOrEmpty(param.EmployeeCdBeginRF))
                {
                    sqlStr.Append(" AND EMPLOYEECODERF >= @EMPLOYEECODEBEGRF");
                    SqlParameter employeeCdBeginRF = sqlCommand.Parameters.Add("@EMPLOYEECODEBEGRF", SqlDbType.NChar);
                    employeeCdBeginRF.Value = SqlDataMediator.SqlSetString(param.EmployeeCdBeginRF);
                }

                if (!string.IsNullOrEmpty(param.EmployeeCdEndRF))
                {
                    sqlStr.Append(" AND EMPLOYEECODERF <= @EMPLOYEECODEENDRF");
                    SqlParameter employeeCdEndRF = sqlCommand.Parameters.Add("@EMPLOYEECODEENDRF", SqlDbType.NChar);
                    employeeCdEndRF.Value = SqlDataMediator.SqlSetString(param.EmployeeCdEndRF);
                }

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);

                //従業員マスタデータ用SQL
                sqlCommand.CommandText = sqlStr.ToString();
                // 読み込み
                myReader = sqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    SetIndex(myReader);
                }

                while (myReader.Read())
                {
                    employeeArrList.Add(CopyFromMyReaderToDCEmployeeWork(myReader));
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCEmployeeDB.SearchEmployee Exception=" + ex.Message);
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
            _name = myReader.GetOrdinal("NAMERF");
            _kana = myReader.GetOrdinal("KANARF");
            _shortName = myReader.GetOrdinal("SHORTNAMERF");
            _sexCode = myReader.GetOrdinal("SEXCODERF");
            _sexName = myReader.GetOrdinal("SEXNAMERF");
            _birthday = myReader.GetOrdinal("BIRTHDAYRF");
            _companyTelNo = myReader.GetOrdinal("COMPANYTELNORF");
            _portableTelNo = myReader.GetOrdinal("PORTABLETELNORF");
            _postCode = myReader.GetOrdinal("POSTCODERF");
            _businessCode = myReader.GetOrdinal("BUSINESSCODERF");
            _frontMechaCode = myReader.GetOrdinal("FRONTMECHACODERF");
            _inOutsideCompanyCode = myReader.GetOrdinal("INOUTSIDECOMPANYCODERF");
            _belongSectionCode = myReader.GetOrdinal("BELONGSECTIONCODERF");
            _lvrRtCstGeneral = myReader.GetOrdinal("LVRRTCSTGENERALRF");
            _lvrRtCstCarInspect = myReader.GetOrdinal("LVRRTCSTCARINSPECTRF");
            _lvrRtCstBodyPaint = myReader.GetOrdinal("LVRRTCSTBODYPAINTRF");
            _lvrRtCstBodyRepair = myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF");
            _loginId = myReader.GetOrdinal("LOGINIDRF");
            _loginPassword = myReader.GetOrdinal("LOGINPASSWORDRF");
            _userAdminFlag = myReader.GetOrdinal("USERADMINFLAGRF");
            _enterCompanyDate = myReader.GetOrdinal("ENTERCOMPANYDATERF");
            _retirementDate = myReader.GetOrdinal("RETIREMENTDATERF");
            _authorityLevel1 = myReader.GetOrdinal("AUTHORITYLEVEL1RF");
            _authorityLevel2 = myReader.GetOrdinal("AUTHORITYLEVEL2RF");
        }

        /// <summary>
        /// 従業員マスタデータを取得
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>従業員マスタデータ</returns>
        /// <br>Note       : 従業員マスタデータを戻します</br>
        /// <br>Programmer : FSI東 隆史</br>
        /// <br>Date       : 2012/07/26</br>
        private DCEmployeeWork CopyFromMyReaderToDCEmployeeWork(SqlDataReader myReader)
        {
            DCEmployeeWork employeeWork = new DCEmployeeWork();

            employeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _createDateTime);
            employeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _updateDateTime);
            employeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _enterpriseCode);
            employeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _fileHeaderGuid);
            employeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _updEmployeeCode);
            employeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _updAssemblyId1);
            employeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _updAssemblyId2);
            employeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _logicalDeleteCode);
            employeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, _employeeCode);
            employeeWork.Name = SqlDataMediator.SqlGetString(myReader, _name);
            employeeWork.Kana = SqlDataMediator.SqlGetString(myReader, _kana);
            employeeWork.ShortName = SqlDataMediator.SqlGetString(myReader, _shortName);
            employeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader, _sexCode);
            employeeWork.SexName = SqlDataMediator.SqlGetString(myReader, _sexName);
            employeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _birthday);
            employeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader, _companyTelNo);
            employeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, _portableTelNo);
            employeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader, _postCode);
            employeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, _businessCode);
            employeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader, _frontMechaCode);
            employeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader, _inOutsideCompanyCode);
            employeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, _belongSectionCode);
            employeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader, _lvrRtCstGeneral);
            employeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader, _lvrRtCstCarInspect);
            employeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader, _lvrRtCstBodyPaint);
            employeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader, _lvrRtCstBodyRepair);
            employeeWork.LoginId = SqlDataMediator.SqlGetString(myReader, _loginId);
            employeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader, _loginPassword);
            employeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader, _userAdminFlag);
            employeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _enterCompanyDate);
            employeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _retirementDate);
            employeeWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, _authorityLevel1);
            employeeWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, _authorityLevel2);

            return employeeWork;
        }
        // --- ADD 2012/07/26 -------------------------------------<<<<<
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
        //    sqlCommand.CommandText = "DELETE FROM EMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";
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
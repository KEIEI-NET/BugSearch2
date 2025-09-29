using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ネットワーク通信処理リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ネットワーク通信処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2019.01.02</br>
    /// <br>Update Note: 2019.02.07 前田　崇</br>
    /// <br>           : ファイルレイアウト項目追加に伴う修正</br>
    /// <br>Update Note: 2020.04.16 志賀　紀之</br>
    /// <br>           : 通信先情報暗号化機能解除に伴う修正</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class AWSCommTstRsltDB : RemoteDB, IAWSCommTstRsltDB
    {
        /// <summary>
        /// ネットワーク通信処理リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        public AWSCommTstRsltDB()
            :
            base("NsNetworkChkAwsD", "Broadleaf.Application.Remoting.ParamData.AWSComRsltWork", "AWSCOMRSLTRF") //基底クラスのコンストラクタ
        {
        }

        /// <summary>
        /// ネットワーク通信テスト結果登録処理
        /// </summary>
        /// <param name="aWSCommTstRsltWorkList">ネットワーク通信テスト結果パラメータリスト</param>
        /// <param name="msgDiv">メッセージ表示区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ネットワーク通信テスト結果登録処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        public int WriteDBData(ref object aWSCommTstRsltWorkList, out bool msgDiv, out string errMsg)
        {
            msgDiv = false;
            errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            NSServiceJobAccess jobAcs = null;
            AWSComRsltWork excAWSCommTstRsltWork = null;
            ArrayList awsCommTstRsltWorkList = new ArrayList();
            try
            {

                awsCommTstRsltWorkList = aWSCommTstRsltWorkList as ArrayList;

                excAWSCommTstRsltWork = awsCommTstRsltWorkList[0] as AWSComRsltWork;

                //メソッド開始時にコネクション文字列を取得
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
                if (connectionText == null || connectionText == "")
                {
                    msgDiv = true;
                    errMsg = "コネクション文字列取得失敗。";
                    return status;
                }

                //●SQLコネクションオブジェクト作成
                sqlConnection = new SqlConnection(connectionText);
                SqlDataReader myReader = null;
                //SqlEncryptInfo sqlEncryptInfo = null;
                sqlConnection.Open();

                try
                {
                    jobAcs = new NSServiceJobAccess("NsNetworkTestAwsR", "AWSCommTstRsltDB.WriteDBData");
                    string paraStr = string.Format("EnterpriseCode={0},SectionCode={0}",
                        excAWSCommTstRsltWork.EnterpriseCode,   //企業コード
                        excAWSCommTstRsltWork.SectionCode);     //拠点コード

                    //------ UPD 2020.04.16 ------>>>>
                    //jobAcs.StartWriteServiceJob("Para(AWS通信テスト結果マスタ):" + paraStr);
                    jobAcs.StartWriteServiceJob("Para(AWS通信テスト結果マスタ):" + paraStr, sqlConnection);
                    //------ UPD 2020.04.16 ------<<<<
                }
                catch (Exception)
                {
                    //エラーでもスルー（更新に影響させない）
                }
                finally
                {
                }

                //------ DEL 2020.04.16 ------>>>>
                // テスト結果の保存先がBL管轄にあるためテスト対象アドレスの暗号化はしない。
                ////●暗号化キーOPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "AWSCOMRSLTRF" });
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);
                //------ DEL 2020.04.16 ------<<<<

                try
                {
                    //●トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    for (int iCnt = 0; iCnt < awsCommTstRsltWorkList.Count; iCnt++)
                    {
                        AWSComRsltWork aWSCommTstRsltWork = (AWSComRsltWork)awsCommTstRsltWorkList[iCnt];
                        //検索
                        using (SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, FILEHEADERGUIDRF FROM AWSCOMRSLTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND USERSETDISCIDRF=@FINDUSERSETDISCID AND TESTNAMERF=@FINDTESTNAME", sqlConnection, sqlTransaction))
                        {
                            //Prameterオブジェクトの作成
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                            SqlParameter findParaUserSetDiscId = sqlCommand.Parameters.Add("@FINDUSERSETDISCID", SqlDbType.NVarChar);
                            SqlParameter findParaTestName = sqlCommand.Parameters.Add("@FINDTESTNAME", SqlDbType.NVarChar);

                            //Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.SectionCode);
                            findParaUserSetDiscId.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.UserSetDiscId);
                            findParaTestName.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.TestName);
                            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                aWSCommTstRsltWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                                aWSCommTstRsltWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                aWSCommTstRsltWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));

                                //------ UPD 2020.04.16 ------>>>>
                                //sqlCommand.CommandText = "UPDATE AWSCOMRSLTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , USERSETDISCIDRF=@USERSETDISCID , CHECKDATERF=@CHECKDATE , CHECKTIMERF=@CHECKTIME , COMPUTERNAMERF=@COMPUTERNAME , TESTNAMERF=@TESTNAME , SERVERTYPERF=@SERVERTYPE , TESTTYPERF=@TESTTYPE , TESTOBJADDRRF=ENCRYPTBYKEY(KEY_GUID(@AWSCOMRSLTRF_ENCRYPTKEY),@TESTOBJADDR) , CHECKRSLTRF=@CHECKRSLT , REQUESTSTATUSNORF=@REQUESTSTATUSNO , REQUESTMESSAGERF=@REQUESTMESSAGE, WINDOWSVERSIONRF=@WINDOWSVERSION, WINDOWSOSNAMERF=@WINDOWSOSNAME, AWSRESERVED1RF=@AWSRESERVED1, AWSRESERVED2RF=@AWSRESERVED2, AWSRESERVED3RF=@AWSRESERVED3 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND USERSETDISCIDRF=@FINDUSERSETDISCID AND TESTNAMERF=@FINDTESTNAME";
                                sqlCommand.CommandText = "UPDATE AWSCOMRSLTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , USERSETDISCIDRF=@USERSETDISCID , CHECKDATERF=@CHECKDATE , CHECKTIMERF=@CHECKTIME , COMPUTERNAMERF=@COMPUTERNAME , TESTNAMERF=@TESTNAME , SERVERTYPERF=@SERVERTYPE , TESTTYPERF=@TESTTYPE , TESTOBJADDRRF=@TESTOBJADDR, CHECKRSLTRF=@CHECKRSLT , REQUESTSTATUSNORF=@REQUESTSTATUSNO , REQUESTMESSAGERF=@REQUESTMESSAGE, WINDOWSVERSIONRF=@WINDOWSVERSION, WINDOWSOSNAMERF=@WINDOWSOSNAME, AWSRESERVED1RF=@AWSRESERVED1, AWSRESERVED2RF=@AWSRESERVED2, AWSRESERVED3RF=@AWSRESERVED3 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND USERSETDISCIDRF=@FINDUSERSETDISCID AND TESTNAMERF=@FINDTESTNAME";
                                //------ UPD 2020.04.16 ------<<<<

                                //KEYコマンドを再設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.SectionCode);
                                findParaUserSetDiscId.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.UserSetDiscId);
                                findParaTestName.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.TestName);

                                //登録ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)aWSCommTstRsltWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetUpdateHeader(ref flhd, obj);


                            }
                            else
                            {
                                //新規作成時のSQL文を生成
                                //------ UPD 2020.04.16 ------>>>>
                                //sqlCommand.CommandText = "INSERT INTO AWSCOMRSLTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, USERSETDISCIDRF, CHECKDATERF, CHECKTIMERF, COMPUTERNAMERF, TESTNAMERF, SERVERTYPERF, TESTTYPERF, TESTOBJADDRRF, CHECKRSLTRF, REQUESTSTATUSNORF, REQUESTMESSAGERF, WINDOWSVERSIONRF, WINDOWSOSNAMERF, AWSRESERVED1RF, AWSRESERVED2RF, AWSRESERVED3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @USERSETDISCID, @CHECKDATE, @CHECKTIME, @COMPUTERNAME, @TESTNAME, @SERVERTYPE, @TESTTYPE, ENCRYPTBYKEY(KEY_GUID(@AWSCOMRSLTRF_ENCRYPTKEY),@TESTOBJADDR), @CHECKRSLT, @REQUESTSTATUSNO, @REQUESTMESSAGE, @WINDOWSVERSION, @WINDOWSOSNAME, @AWSRESERVED1, @AWSRESERVED2, @AWSRESERVED3)";
                                sqlCommand.CommandText = "INSERT INTO AWSCOMRSLTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, USERSETDISCIDRF, CHECKDATERF, CHECKTIMERF, COMPUTERNAMERF, TESTNAMERF, SERVERTYPERF, TESTTYPERF, TESTOBJADDRRF, CHECKRSLTRF, REQUESTSTATUSNORF, REQUESTMESSAGERF, WINDOWSVERSIONRF, WINDOWSOSNAMERF, AWSRESERVED1RF, AWSRESERVED2RF, AWSRESERVED3RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @USERSETDISCID, @CHECKDATE, @CHECKTIME, @COMPUTERNAME, @TESTNAME, @SERVERTYPE, @TESTTYPE, @TESTOBJADDR, @CHECKRSLT, @REQUESTSTATUSNO, @REQUESTMESSAGE, @WINDOWSVERSION, @WINDOWSOSNAME, @AWSRESERVED1, @AWSRESERVED2, @AWSRESERVED3)";
                                //------ UPD 2020.04.16 ------<<<<

                                //登録ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)aWSCommTstRsltWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                            }

                            if (myReader.IsClosed == false)
                            {
                                myReader.Close();
                            }
                            
                            //Parameterオブジェクトの作成
                            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                            SqlParameter paraUserSetDiscId = sqlCommand.Parameters.Add("@USERSETDISCID", SqlDbType.NVarChar);
                            SqlParameter paraCheckDate = sqlCommand.Parameters.Add("@CHECKDATE", SqlDbType.Int);
                            SqlParameter paraCheckTime = sqlCommand.Parameters.Add("@CHECKTIME", SqlDbType.Int);
                            SqlParameter paraComputerName = sqlCommand.Parameters.Add("@COMPUTERNAME", SqlDbType.NVarChar);
                            SqlParameter paraTestName = sqlCommand.Parameters.Add("@TESTNAME", SqlDbType.NVarChar);
                            SqlParameter paraServerType = sqlCommand.Parameters.Add("@SERVERTYPE", SqlDbType.SmallInt);
                            SqlParameter paraTestType = sqlCommand.Parameters.Add("@TESTTYPE", SqlDbType.SmallInt);
                            SqlParameter paraTestObjAddr = sqlCommand.Parameters.Add("@TESTOBJADDR", SqlDbType.NVarChar);
                            SqlParameter paraCheckRslt = sqlCommand.Parameters.Add("@CHECKRSLT", SqlDbType.SmallInt);
                            SqlParameter paraRequestStatusNo = sqlCommand.Parameters.Add("@REQUESTSTATUSNO", SqlDbType.Int);
                            SqlParameter paraRequestMessage = sqlCommand.Parameters.Add("@REQUESTMESSAGE", SqlDbType.NVarChar);
                            SqlParameter paraWindowsVersion = sqlCommand.Parameters.Add("@WINDOWSVERSION", SqlDbType.NVarChar);
                            SqlParameter paraWindowsOSName = sqlCommand.Parameters.Add("@WINDOWSOSNAME", SqlDbType.NVarChar);
                            SqlParameter paraAwsReserved1 = sqlCommand.Parameters.Add("@AWSRESERVED1", SqlDbType.NVarChar);
                            SqlParameter paraAwsReserved2 = sqlCommand.Parameters.Add("@AWSRESERVED2", SqlDbType.NVarChar);
                            SqlParameter paraAwsReserved3 = sqlCommand.Parameters.Add("@AWSRESERVED3", SqlDbType.NVarChar);

                            //Parameterオブジェクトへ値設定
                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(aWSCommTstRsltWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(aWSCommTstRsltWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(aWSCommTstRsltWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(aWSCommTstRsltWork.LogicalDeleteCode);
                            paraSectionCode.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.SectionCode);
                            paraUserSetDiscId.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.UserSetDiscId);
                            paraCheckDate.Value = SqlDataMediator.SqlSetInt32(aWSCommTstRsltWork.CheckDate);
                            paraCheckTime.Value = SqlDataMediator.SqlSetInt32(aWSCommTstRsltWork.CheckTime);
                            paraComputerName.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.ComputerName);
                            paraTestName.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.TestName);
                            paraServerType.Value = SqlDataMediator.SqlSetInt32(aWSCommTstRsltWork.ServerType);
                            paraTestType.Value = SqlDataMediator.SqlSetInt32(aWSCommTstRsltWork.TestType);
                            paraTestObjAddr.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.TestObjAddr);
                            paraCheckRslt.Value = SqlDataMediator.SqlSetInt32(aWSCommTstRsltWork.CheckRslt);
                            paraRequestStatusNo.Value = SqlDataMediator.SqlSetInt32(aWSCommTstRsltWork.RequestStatusNo);
                            paraRequestMessage.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.RequestMessage);
                            paraWindowsVersion.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.WindowsVersion);
                            paraWindowsOSName.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.WindowsOSName);
                            paraAwsReserved1.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.AwsReserved1);
                            paraAwsReserved2.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.AwsReserved2);
                            paraAwsReserved3.Value = SqlDataMediator.SqlSetString(aWSCommTstRsltWork.AwsReserved3);

                            //------ DEL 2020.04.16 ------>>>>
                            // テスト結果の保存先がBL管轄にあるためテスト対象アドレスの暗号化はしない。
                            ////暗号化キーパラメータ設定
                            //SqlParameter encKeyAWSComRsltRF = sqlCommand.Parameters.Add("@AWSCOMRSLTRF_ENCRYPTKEY", SqlDbType.Char);
                            //encKeyAWSComRsltRF.Value = sqlEncryptInfo.GetSymKeyName("AWSCOMRSLTRF");
                            //------ DEL 2020.04.16 ------<<<<

                            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitLockwait);
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                //●例外処理
                catch (SqlException ex)
                {
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "AWSCommTstRsltDB.Write Exception=" + ex.Message);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                finally
                {
                    //●コミットorロールバック
                    //正常更新時コミット、異常発生時ロールバック
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) sqlTransaction.Commit();
                    else sqlTransaction.Rollback();

                    //●暗号化キーCLOSE
                    //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AWSCommTstRsltDB.Write Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // ステータス、メッセージ、メソッド固有情報を渡してサービスジョブテーブルへ書き込み
                //------ UPD 2020.04.16 ------>>>>
                //if (jobAcs != null)
                //    jobAcs.EndWriteServiceJob(status, errMsg, string.Empty);
                if (jobAcs != null)
                    jobAcs.EndWriteServiceJob(status, errMsg, string.Empty, sqlConnection);
                //------ UPD 2020.04.16 ------<<<<

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }

            }

            return status;
        }
    }
}

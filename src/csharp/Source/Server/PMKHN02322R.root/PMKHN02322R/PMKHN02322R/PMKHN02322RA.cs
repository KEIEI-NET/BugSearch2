//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : テキスト出力操作ログ登録処理DBリモートオブジェクト
// プログラム概要   : テキスト出力操作ログ登録処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570163-00       作成担当 : 田建委
// 作 成 日  2019/08/12        修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11570163-00       作成担当 : 岸
// 作 成 日  2019/09/12        修正内容 : テキスト出力ログ№採番処理廃止
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Library.Data;
using Microsoft.Win32;
using System.IO;
using System.Net;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// テキスト出力操作ログ登録処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : テキスト出力操作ログ登録処理を行う</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/08/12</br>
    /// <br>Note       : テキスト出力ログ№採番処理廃止</br>
    /// <br>Programmer : 岸</br>
    /// <br>Date       : 2019/09/12</br>
    /// </remarks>
    [Serializable]
    public class TextOutPutOprtnHisLogDB : RemoteDB, ITextOutPutOprtnHisLogDB
    {
        /// <summary>
        /// テキスト出力操作ログ登録処理DBリモートオブジェクトクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力操作ログ登録処理DBリモートオブジェクトクラス</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/08/12</br>
        /// </remarks>
        public TextOutPutOprtnHisLogDB()
        {

        }

        #region テキスト出力操作ログ登録
        /// <summary>
        /// テキスト出力操作ログを登録する
        /// </summary>
        /// <param name="textOutPutOprtnHisLogWorkObj">登録用対象ワーク</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>実行結果状態</returns>
        /// <remarks>
        /// <br>Note       : テキスト出力操作ログ登録処理を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/08/12</br>
        /// </remarks>
        public int Write(ref object textOutPutOprtnHisLogWorkObj, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // コネクション生成
                using (sqlConnection = this.CreateSqlConnection(true))
                {
                    // トランザクション生成
                    using (sqlTransaction = this.CreateTransaction(ref sqlConnection))
                    {
                        TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWork = (TextOutPutOprtnHisLogWork)textOutPutOprtnHisLogWorkObj;
                        // 登録処理を行う
                        status = this.WriteTextOutPutOprtnHisLogProc(ref textOutPutOprtnHisLogWork, ref sqlConnection, ref sqlTransaction, out errMsg);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                            textOutPutOprtnHisLogWorkObj = (object)textOutPutOprtnHisLogWork;
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TextOutPutOprtnHisLogDB.Write");
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// テキスト出力操作ログを登録する
        /// </summary>
        /// <param name="textOutPutOprtnHisLogWork">登録用対象ワーク</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>実行結果状態</returns>
        /// <remarks>
        /// <br>Note       : テキスト出力操作ログ登録処理を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/08/12</br>
        /// <br>Note       : テキスト出力ログ№採番処理廃止</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2019/09/12</br>
        /// </remarks>
        private int WriteTextOutPutOprtnHisLogProc(ref TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            errMsg = string.Empty;

            try
            {
                if (textOutPutOprtnHisLogWork != null)
                {
                    string sqlText = string.Empty;
                    #region
                    sqlText += " SELECT " + Environment.NewLine;
                    sqlText += " UPDATEDATETIMERF " + Environment.NewLine;
                    sqlText += " FROM " + Environment.NewLine; ;
                    // --- MOD 2019/09/12 ---------->>>>>
                    // テキスト出力ログ№採番処理廃止
                    //sqlText += " TEXTOUTHISLOGRF " + Environment.NewLine;
                    sqlText += " TEXTOUTHISLOGRF WITH(NOLOCK)" + Environment.NewLine;
                    // --- MOD 2019/09/12 ----------<<<<<
                    sqlText += " WHERE " + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += " AND TEXTOUTLOGNORF=@FINDTEXTOUTLOGNORF " + Environment.NewLine;
                    #endregion
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findTextOutLogNo = sqlCommand.Parameters.Add("@FINDTEXTOUTLOGNORF", SqlDbType.BigInt);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.EnterpriseCode);
                    findTextOutLogNo.Value = SqlDataMediator.SqlSetInt64(textOutPutOprtnHisLogWork.TextOutLogNo);

                    myReader = sqlCommand.ExecuteReader();

                    // DBにデータが存在するか
                    bool existFlag = myReader.Read();

                    if (existFlag)
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (updateDateTime != textOutPutOprtnHisLogWork.UpdateDateTime)
                        {
                            if (textOutPutOprtnHisLogWork.UpdateDateTime == DateTime.MinValue)
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

                        sqlText = string.Empty;
                        #region
                        sqlText += " UPDATE " + Environment.NewLine;
                        sqlText += " TEXTOUTHISLOGRF " + Environment.NewLine;
                        sqlText += " SET " + Environment.NewLine;
                        sqlText += " CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                        sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME " + Environment.NewLine;
                        sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
                        sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID " + Environment.NewLine;
                        sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE " + Environment.NewLine;
                        sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 " + Environment.NewLine;
                        sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 " + Environment.NewLine;
                        sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " , LOGDATACOUNTRF=@LOGDATACOUNTRF " + Environment.NewLine;
                        sqlText += " WHERE " + Environment.NewLine;
                        sqlText += " ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                        sqlText += " AND TEXTOUTLOGNORF=@FINDTEXTOUTLOGNORF " + Environment.NewLine;
                        #endregion
                        sqlCommand.CommandText = sqlText.ToString();

                        // KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.EnterpriseCode);
                        findTextOutLogNo.Value = SqlDataMediator.SqlSetInt64(textOutPutOprtnHisLogWork.TextOutLogNo);

                        // コンマ配列
                        string[] commaArray = null;
                        // コロン配列
                        string[] colonArray = null;
                        // 出力件数
                        string count = string.Empty;

                        // コンマで分ける
                        commaArray = textOutPutOprtnHisLogWork.LogOperationData.Split(',');
                        if (commaArray != null && commaArray.Length > 0)
                        {
                            // コロンで分ける
                            colonArray = commaArray[0].Split(':');
                        }
                        // 出力件数取得
                        if (colonArray != null && colonArray.Length > 0)
                        {
                            count = colonArray[1].ToString();
                        }

                        int result;
                        if (Int32.TryParse(count, out result)) textOutPutOprtnHisLogWork.LogDataCount = result;

                        // 更新ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)textOutPutOprtnHisLogWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        if (myReader != null)
                        {
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                        }

                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (textOutPutOprtnHisLogWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        // --- DEL 2019/09/12 ---------->>>>>
                        // テキスト出力ログ№採番処理廃止
                        // テキスト出力ログNo採番処理
                        //#region 採番
                        //status = this.GetMaxTextOutLogNo(ref textOutPutOprtnHisLogWork, ref sqlConnection, ref sqlTransaction, out errMsg);

                        //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    return status;
                        //}
                        //#endregion
                        // --- DEL 2019/09/12 ----------<<<<<

                        //Insertコマンドの生成
                        #region [INSERT文]
                        sqlText = string.Empty;
                        sqlText += "INSERT INTO TEXTOUTHISLOGRF" + Environment.NewLine;
                        sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        // --- DEL 2019/09/12 ---------->>>>>
                        // テキスト出力ログ№採番処理廃止
                        //sqlText += " ,TEXTOUTLOGNORF" + Environment.NewLine;
                        // --- DEL 2019/09/12 ----------<<<<<
                        sqlText += " ,LOGDATACREATEDATERF" + Environment.NewLine;
                        sqlText += " ,LOGDATACREATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGINSECTIONCDRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAKINDCDRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAMACHINENAMERF" + Environment.NewLine;
                        sqlText += " ,LOGDATAAGENTCDRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAAGENTNMRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAOBJBOOTPROGRAMNMRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAOBJASSEMBLYIDRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAOBJASSEMBLYNMRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAOBJPROCNMRF" + Environment.NewLine;
                        sqlText += " ,LOGDATAOPERATIONCDRF" + Environment.NewLine;
                        sqlText += " ,LOGOPERATERDTPROCLVLRF" + Environment.NewLine;
                        sqlText += " ,LOGOPERATERFUNCLVLRF" + Environment.NewLine;
                        sqlText += " ,LOGDATASYSTEMVERSIONRF" + Environment.NewLine;
                        sqlText += " ,LOGOPERATIONSTATUSRF" + Environment.NewLine;
                        sqlText += " ,LOGDATACOUNTRF" + Environment.NewLine;
                        sqlText += " ,LOGOPERATIONDATARF" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        sqlText += " VALUES" + Environment.NewLine;
                        sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                        // --- DEL 2019/09/12 ---------->>>>>
                        // テキスト出力ログ№採番処理廃止
                        //sqlText += " ,@TEXTOUTLOGNO" + Environment.NewLine;
                        // --- DEL 2019/09/12 ----------<<<<<
                        sqlText += " ,@LOGDATACREATEDATE" + Environment.NewLine;
                        sqlText += " ,@LOGDATACREATETIME" + Environment.NewLine;
                        sqlText += " ,@LOGINSECTIONCD" + Environment.NewLine;
                        sqlText += " ,@LOGDATAKINDCD" + Environment.NewLine;
                        sqlText += " ,@LOGDATAMACHINENAME" + Environment.NewLine;
                        sqlText += " ,@LOGDATAAGENTCD" + Environment.NewLine;
                        sqlText += " ,@LOGDATAAGENTNM" + Environment.NewLine;
                        sqlText += " ,@LOGDATAOBJBOOTPROGRAMNM" + Environment.NewLine;
                        sqlText += " ,@LOGDATAOBJASSEMBLYID" + Environment.NewLine;
                        sqlText += " ,@LOGDATAOBJASSEMBLYNM" + Environment.NewLine;
                        sqlText += " ,@LOGDATAOBJPROCNM" + Environment.NewLine;
                        sqlText += " ,@LOGDATAOPERATIONCD" + Environment.NewLine;
                        sqlText += " ,@LOGOPERATERDTPROCLVL" + Environment.NewLine;
                        sqlText += " ,@LOGOPERATERFUNCLVL" + Environment.NewLine;
                        sqlText += " ,@LOGDATASYSTEMVERSION" + Environment.NewLine;
                        sqlText += " ,@LOGOPERATIONSTATUS" + Environment.NewLine;
                        sqlText += " ,@LOGDATACOUNTRF" + Environment.NewLine;
                        sqlText += " ,@LOGOPERATIONDATA" + Environment.NewLine;
                        sqlText += " )" + Environment.NewLine;
                        // --- ADD 2019/09/12 ---------->>>>>
                        // テキスト出力ログ№採番処理廃止
                        // 最後にIDENTITYの取得SELECTを追加
                        sqlText += ";SELECT SCOPE_IDENTITY() as ID" + Environment.NewLine;
                        // --- ADD 2019/09/12 ----------<<<<<

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)textOutPutOprtnHisLogWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
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
                   SqlParameter paraTextOutLogNo = sqlCommand.Parameters.Add("@TEXTOUTLOGNO", SqlDbType.BigInt);
                   SqlParameter paraLogDataCreateDate = sqlCommand.Parameters.Add("@LOGDATACREATEDATE", SqlDbType.Int);
                   SqlParameter paraLogDataCreateTime = sqlCommand.Parameters.Add("@LOGDATACREATETIME", SqlDbType.Int);
                   SqlParameter paraLoginSectionCd = sqlCommand.Parameters.Add("@LOGINSECTIONCD", SqlDbType.NChar);
                   SqlParameter paraLogDataKindCd = sqlCommand.Parameters.Add("@LOGDATAKINDCD", SqlDbType.Int);
                   SqlParameter paraLogDataMachineName = sqlCommand.Parameters.Add("@LOGDATAMACHINENAME", SqlDbType.NVarChar);
                   SqlParameter paraLogDataAgentCd = sqlCommand.Parameters.Add("@LOGDATAAGENTCD", SqlDbType.NChar);
                   SqlParameter paraLogDataAgentNm = sqlCommand.Parameters.Add("@LOGDATAAGENTNM", SqlDbType.NVarChar);
                   SqlParameter paraLogDataObjBootProgramNm = sqlCommand.Parameters.Add("@LOGDATAOBJBOOTPROGRAMNM", SqlDbType.NVarChar);
                   SqlParameter paraLogDataObjAssemblyID = sqlCommand.Parameters.Add("@LOGDATAOBJASSEMBLYID", SqlDbType.NVarChar);
                   SqlParameter paraLogDataObjAssemblyNm = sqlCommand.Parameters.Add("@LOGDATAOBJASSEMBLYNM", SqlDbType.NVarChar);
                   SqlParameter paraLogDataObjProcNm = sqlCommand.Parameters.Add("@LOGDATAOBJPROCNM", SqlDbType.NVarChar);
                   SqlParameter paraLogDataOperationCd = sqlCommand.Parameters.Add("@LOGDATAOPERATIONCD", SqlDbType.Int);
                   SqlParameter paraLogOperaterDtProcLvl = sqlCommand.Parameters.Add("@LOGOPERATERDTPROCLVL", SqlDbType.NVarChar);
                   SqlParameter paraLogOperaterFuncLvl = sqlCommand.Parameters.Add("@LOGOPERATERFUNCLVL", SqlDbType.NVarChar);
                   SqlParameter paraLogDataSystemVersion = sqlCommand.Parameters.Add("@LOGDATASYSTEMVERSION", SqlDbType.NVarChar);
                   SqlParameter paraLogOperationStatus = sqlCommand.Parameters.Add("@LOGOPERATIONSTATUS", SqlDbType.Int);
                   SqlParameter paraLogDataCount = sqlCommand.Parameters.Add("@LOGDATACOUNTRF", SqlDbType.Int);
                   SqlParameter paraLogOperationData = sqlCommand.Parameters.Add("@LOGOPERATIONDATA", SqlDbType.NVarChar);
                   #endregion

                   #region Parameterオブジェクトへ値設定(更新用)
                   paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(textOutPutOprtnHisLogWork.CreateDateTime);
                   paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(textOutPutOprtnHisLogWork.UpdateDateTime);
                   paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.EnterpriseCode);
                   paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(textOutPutOprtnHisLogWork.FileHeaderGuid);
                   paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.UpdEmployeeCode);
                   paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.UpdAssemblyId1);
                   paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.UpdAssemblyId2);
                   paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(textOutPutOprtnHisLogWork.LogicalDeleteCode);
                   paraTextOutLogNo.Value = SqlDataMediator.SqlSetInt64(textOutPutOprtnHisLogWork.TextOutLogNo);
                   int logDataCreateDateInt = textOutPutOprtnHisLogWork.LogDataCreateDateTime.Year * 10000 + textOutPutOprtnHisLogWork.LogDataCreateDateTime.Month * 100 + textOutPutOprtnHisLogWork.LogDataCreateDateTime.Day;
                   int logDataCreateTimeInt = textOutPutOprtnHisLogWork.LogDataCreateDateTime.Hour * 10000 + textOutPutOprtnHisLogWork.LogDataCreateDateTime.Minute * 100 + textOutPutOprtnHisLogWork.LogDataCreateDateTime.Second;
                   paraLogDataCreateDate.Value = SqlDataMediator.SqlSetInt32(logDataCreateDateInt);
                   paraLogDataCreateTime.Value = SqlDataMediator.SqlSetInt32(logDataCreateTimeInt);
                   paraLoginSectionCd.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LoginSectionCd);
                   paraLogDataKindCd.Value = SqlDataMediator.SqlSetInt32(textOutPutOprtnHisLogWork.LogDataKindCd);
                   paraLogDataMachineName.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataMachineName);
                   paraLogDataAgentCd.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataAgentCd);
                   paraLogDataAgentNm.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataAgentNm);
                   paraLogDataObjBootProgramNm.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataObjBootProgramNm);
                   paraLogDataObjAssemblyID.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataObjAssemblyID);
                   paraLogDataObjAssemblyNm.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataObjAssemblyNm);
                   paraLogDataObjProcNm.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataObjProcNm);
                   paraLogDataOperationCd.Value = SqlDataMediator.SqlSetInt32(textOutPutOprtnHisLogWork.LogDataOperationCd);
                   paraLogOperaterDtProcLvl.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogOperaterDtProcLvl);
                   paraLogOperaterFuncLvl.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogOperaterFuncLvl);
                   paraLogDataSystemVersion.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogDataSystemVersion);
                   paraLogOperationStatus.Value = SqlDataMediator.SqlSetInt32(textOutPutOprtnHisLogWork.LogOperationStatus);
                   paraLogDataCount.Value = SqlDataMediator.SqlSetInt32(textOutPutOprtnHisLogWork.LogDataCount);
                   paraLogOperationData.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.LogOperationData);
                   #endregion

                    if (myReader != null)
                    {
                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }
                    }

                    // --- MOD 2019/09/12 ---------->>>>>
                    // テキスト出力ログ№採番処理廃止
                    // IDを取得し引数に設定
                    //sqlCommand.ExecuteNonQuery();

                    if (existFlag)
                    {
                        // Update
                        sqlCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        // Insert

                        // ExecuteScalarで先頭行、先頭項目を取得
                        object newId = sqlCommand.ExecuteScalar();

                        // 返却値をログNoに設定
                        Int64 resId = 0;
                        Int64.TryParse(newId.ToString(), out resId);
                        textOutPutOprtnHisLogWork.TextOutLogNo = resId;

                    }
                    // --- MOD 2019/09/12 ----------<<<<<

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex);
                errMsg = sqlex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TextOutPutOprtnHisLogDB.WriteTextOutPutOprtnHisLogProc");
                errMsg = ex.Message;
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
        #endregion

        #region テキスト出力ログNo採番
        /// <summary>
        /// テキスト出力ログNo採番
        /// </summary>
        /// <param name="textOutPutOprtnHisLogWork">登録用対象ワーク</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>実行結果状態</returns>
        /// <remarks>
        /// <br>Note       : テキスト出力ログNo採番処理を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/08/12</br>
        /// </remarks>
        private int GetMaxTextOutLogNo(ref TextOutPutOprtnHisLogWork textOutPutOprtnHisLogWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            errMsg = string.Empty;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT MAX(TEXTOUTLOGNORF) TEXTOUTLOGNO_MAX FROM TEXTOUTHISLOGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE_MAX", sqlConnection, sqlTransaction))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE_MAX", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(textOutPutOprtnHisLogWork.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        textOutPutOprtnHisLogWork.TextOutLogNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TEXTOUTLOGNO_MAX")) + 1;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                errMsg = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TextOutPutOprtnHisLogDB.GetMaxTextOutLogNo");
                errMsg = ex.Message;
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        # region [コネクション・トランザクション生成処理]
        /// <summary>
        /// コネクション生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたコネクション、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Note       : コネクション生成処理を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/08/12</br>
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
        /// トランザクション生成処理
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたトランザクション、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Note       : トランザクション生成処理を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/08/12</br>
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

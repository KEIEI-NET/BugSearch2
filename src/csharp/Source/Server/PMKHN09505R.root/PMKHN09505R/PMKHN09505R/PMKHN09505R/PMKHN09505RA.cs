//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 返品不可設定
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 修 正 日  2010/04/06  修正内容 : 拠点情報マスタ結合時のキー修正
//----------------------------------------------------------------------------//
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
using Broadleaf.Library.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 返品不可設定処理READDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 返品不可設定処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    [Serializable]
    public class GoodsNotReturnProcDB : RemoteDB, IGoodsNotReturnProcDB
    {

        # region ■ Constructor
        /// <summary>
        /// 返品不可設定処理READDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 返品不可設定処理READの実データ操作を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public GoodsNotReturnProcDB()
        {
        }
        #endregion

        #region ■返品不可設定の画面検索処理

        /// <summary>
        /// 返品不可設定の画面検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="goodsNotReturnList">検索パラメータ</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 返品不可設定画面検索を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int ReadDBData(string enterpriseCodes, string salesSlipNum, out ArrayList goodsNotReturnList, out string retMessage)
        {
            return ReadDBDataProc(enterpriseCodes, salesSlipNum, out goodsNotReturnList, out retMessage);
        }

        /// <summary>
        /// 返品不可設定の画面検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="goodsNotReturnList">検索パラメータ</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 返品不可設定画面検索を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int ReadDBDataProc(string enterpriseCodes, string salesSlipNum, out ArrayList goodsNotReturnList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retMessage = string.Empty;
            goodsNotReturnList = new ArrayList();
            GoodsNotReturnWork goodsNotReturnWork = null;

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (_connectionText == null || _connectionText == "")
            {
                return status;
            }

            sqlConnection = new SqlConnection(_connectionText);
            sqlConnection.Open();

            sqlCommand = new SqlCommand("", sqlConnection);
            try
            {
                // Selectコマンドの生成
                sqlStr = " SELECT SALESSLIPRF.CUSTOMERSNMRF, SALESSLIPRF.RESULTSADDUPSECCDRF, SALESSLIPRF.LOGICALDELETECODERF, SALESDETAILRF.LOGICALDELETECODERF AS DTLLOGICALDELETECODERF, SALESSLIPRF.SECTIONCODERF, SALESSLIPRF.CUSTOMERCODERF, "
                + " SALESSLIPRF.CUSTOMERNAMERF, SALESSLIPRF.SALESDATERF, SALESSLIPRF.SALESSLIPCDRF, SALESSLIPRF.ACPTANODRSTATUSRF, "
                + " SECINFOSETRF.SECTIONGUIDENMRF, SALESDETAILRF.SALESSLIPCDDTLRF, SALESDETAILRF.SALESSLIPDTLNUMRF, SALESDETAILRF.GOODSNORF, SALESDETAILRF.GOODSNORF, "
                + " SALESDETAILRF.GOODSNAMERF, SALESDETAILRF.MAKERNAMERF, SALESDETAILRF.SHIPMENTCNTRF, "
                + " SALESDETAILRF.ACCEPTANORDERCNTRF, SALESDETAILRF.ACPTANODRADJUSTCNTRF, "
                + " SALESDETAILRF.ACPTANODRREMAINCNTRF, RETURNUPPERSTRF.RETUPPERCNTRF, RETURNUPPERSTRF.UPDATEDATETIMERF "
                + " FROM SALESSLIPRF WITH (READUNCOMMITTED) "
                + " INNER JOIN SALESDETAILRF WITH (READUNCOMMITTED) ON ( "
                + " SALESSLIPRF.ACPTANODRSTATUSRF = SALESDETAILRF.ACPTANODRSTATUSRF "
                + " AND SALESSLIPRF.ENTERPRISECODERF = SALESDETAILRF.ENTERPRISECODERF "
                + " AND SALESSLIPRF.SALESSLIPNUMRF = SALESDETAILRF.SALESSLIPNUMRF) "
                + " LEFT JOIN SECINFOSETRF WITH (READUNCOMMITTED) ON ( "
                + " SECINFOSETRF.LOGICALDELETECODERF = 0 "
                // -- ADD 2010/04/06 ------------------->>>
                + " AND SECINFOSETRF.ENTERPRISECODERF = SALESSLIPRF.ENTERPRISECODERF "
                // -- ADD 2010/04/06 -------------------<<<
                + " AND SECINFOSETRF.SECTIONCODERF = SALESSLIPRF.RESULTSADDUPSECCDRF ) "
                + " LEFT JOIN RETURNUPPERSTRF WITH (READUNCOMMITTED) ON ( "
                + " RETURNUPPERSTRF.LOGICALDELETECODERF = 0 "
                + " AND SALESDETAILRF.ENTERPRISECODERF = RETURNUPPERSTRF.ENTERPRISECODERF "
                + " AND SALESDETAILRF.ACPTANODRSTATUSRF = RETURNUPPERSTRF.ACPTANODRSTATUSRF "
                + " AND SALESDETAILRF.SALESSLIPDTLNUMRF = RETURNUPPERSTRF.SALESSLIPDTLNUMRF) "
                + " WHERE "
                + " SALESSLIPRF.DEBITNOTEDIVRF = 0 "
                + " AND SALESSLIPRF.ENTERPRISECODERF = @FINDENTERPRISECODERF "
                + " AND SALESSLIPRF.SALESSLIPNUMRF = @FINDSALESSLIPNUMRF "
                + " AND SALESSLIPRF.ACPTANODRSTATUSRF = @ACPTANODRSTATUS ";

                // Prameterオブジェクトの作成
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUMRF", SqlDbType.NChar);
                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                // Parameterオブジェクトへ値設定
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesSlipNum);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(30);

                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    goodsNotReturnWork = new GoodsNotReturnWork();
                    goodsNotReturnWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    goodsNotReturnWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    goodsNotReturnWork.DtlLogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLLOGICALDELETECODERF"));
                    goodsNotReturnWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                    goodsNotReturnWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    goodsNotReturnWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                    goodsNotReturnWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                    goodsNotReturnWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    goodsNotReturnWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    goodsNotReturnWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    goodsNotReturnWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                    goodsNotReturnWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    goodsNotReturnWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsNotReturnWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    goodsNotReturnWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    goodsNotReturnWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    goodsNotReturnWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
                    goodsNotReturnWork.AcptAnOdrAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRADJUSTCNTRF"));
                    goodsNotReturnWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
                    goodsNotReturnWork.RetUpperCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETUPPERCNTRF"));
                    
                    goodsNotReturnList.Add(goodsNotReturnWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region ■返品不可設定の画面更新処理
        /// <summary>
        /// 返品不可設定の画面更新処理
        /// </summary>
        /// <param name="goodsNotReturnList">更新パラメータ</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 返品不可設定画面更新を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int UpdateReturnUpper(ref ArrayList goodsNotReturnList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retMessage = string.Empty;
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();



#if DEBUG
                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif

                string retSql = string.Empty;
                DateTime updateTime = new DateTime();

                // 更新ヘッダ情報
                ReturnUpperStWork returnUpperStWork = new ReturnUpperStWork();
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)returnUpperStWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
                // 登録ヘッダ情報
                ReturnUpperStWork ReturnInsertStWork = new ReturnUpperStWork();
                object objInsert = (object)this;
                IFileHeader insertIf = (IFileHeader)ReturnInsertStWork;
                FileHeader fileInsert = new FileHeader(objInsert);
                fileInsert.SetInsertHeader(ref insertIf, objInsert);

                foreach (GoodsNotReturnWork goodsNotReturnWork in goodsNotReturnList) 
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 返品上限数未入力の場合、更新しない
                        if (goodsNotReturnWork.RetUpperCnt == -1)
                        {
                            continue;
                        }
                        // もう一度返品上限設定マスタの更新日時検索処理
                        status = SearchReturnUpperSt(goodsNotReturnWork.EnterpriseCode, goodsNotReturnWork.AcptAnOdrStatus,
                            goodsNotReturnWork.SalesSlipDtlNum, ref sqlConnection, ref sqlTransaction, ref sqlCommand,
                            out retMessage, out updateTime);


                        // 返品上限数初めで更新の場合、新規処理
                        if (goodsNotReturnWork.UpdateDateTime == DateTime.MinValue)
                        {
                            // 既に他端末より更新されています。
                            //status = SearchReturnUpperStCount(goodsNotReturnWork.EnterpriseCode, goodsNotReturnWork.AcptAnOdrStatus,
                            //    goodsNotReturnWork.SalesSlipDtlNum, ref sqlConnection, ref sqlTransaction, ref sqlCommand,
                            //    out retMessage);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                status = InsertReturnUpperSt(goodsNotReturnWork, ReturnInsertStWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand, out retMessage);
                            }
                            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                                return status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }
                            else
                            {
                                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                                return status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                        }
                        else
                        {
                            // 検索エラーの場合、ロールバックする
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                            {
                                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                                return status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                            }
                            // 検索結果がないの場合、既に他端末より削除されています。
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                            {
                                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                                return status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            }
                            // 検索結果の更新日時と初期検索結果の更新日時が違い場合、既に他端末より更新されています。
                            if (updateTime != goodsNotReturnWork.UpdateDateTime)
                            {
                                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                                return status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }
                            // エラーがないの場合、更新する。
                            status = UpdateReturnUpperSt(goodsNotReturnWork, returnUpperStWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        }
                    }
                }
                // エラーがないの場合、コミットする。
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Commit();

                }
                // エラーがあるの場合、ロールバックする。
                else
                {
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (SqlException ex)
            {
                // エラーがあるの場合、ロールバックする。
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.ShipmentDirections Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception e)
            {
                // エラーがあるの場合、ロールバックする。
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "DispatchInstsWorkReadDB.UpdateShipmentDir Exception=" + e.Message);
                retMessage = e.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
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

        #region ■返品不可設定の画面追加処理
        /// <summary>
        /// 返品不可設定の画面追加処理
        /// </summary>
        /// <param name="goodsNotReturnWork">追加パラメータ</param>
        /// <param name="ReturnInsertStWork">共通域パラメータ</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">sqlCommandオブジェクト</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 返品不可設定画面追加を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int InsertReturnUpperSt(GoodsNotReturnWork goodsNotReturnWork, ReturnUpperStWork ReturnInsertStWork,
            ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            retMessage = string.Empty;
            string retSql = string.Empty;
            try
            {

                retSql = "INSERT INTO RETURNUPPERSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, SALESSLIPDTLNUMRF, RETUPPERCNTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACPTANODRSTATUS, @SALESSLIPDTLNUM, @RETUPPERCNT)";

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter paraSalesSlipDtlNum = sqlCommand.Parameters.Add("@SALESSLIPDTLNUM", SqlDbType.BigInt);
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@RETUPPERCNT", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(ReturnInsertStWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(ReturnInsertStWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ReturnInsertStWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(ReturnInsertStWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(ReturnInsertStWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(ReturnInsertStWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(ReturnInsertStWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(ReturnInsertStWork.LogicalDeleteCode);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(goodsNotReturnWork.AcptAnOdrStatus);
                paraSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(goodsNotReturnWork.SalesSlipDtlNum);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetDouble(goodsNotReturnWork.RetUpperCnt);

                // 返品上限設定マスタ用SQL
                sqlCommand.CommandText = retSql;
                // 返品上限設定マスタを登録する
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.ShipmentDataAllSearch Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region ■返品上限設定マスタの更新日時の取得処理
        /// <summary>
        /// 返品上限設定マスタの更新日時の取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipDtlNum">売上明細通番</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">sqlCommandオブジェクト</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <param name="updateDateTime">更新日時</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 返品上限設定マスタの更新日時の取得処理を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int SearchReturnUpperSt(string enterpriseCode, Int32 acptAnOdrStatus, Int64 salesSlipDtlNum,
                    ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    ref SqlCommand sqlCommand, out string retMessage, out DateTime updateDateTime)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            updateDateTime = new DateTime();

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                retMessage = string.Empty;
                string sqlStr = string.Empty;

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACPTANODRSTATUSRF, SALESSLIPDTLNUMRF, RETUPPERCNTRF FROM RETURNUPPERSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUM";


                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter findParaSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acptAnOdrStatus);
                findParaSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(salesSlipDtlNum);

                // 返品上限設定マスタ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.ShipmentDataAllSearch Exception=" + ex.Message);
                retMessage = ex.Message;
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

        #region ■返品上限設定マスタの更新処理
        /// <summary>
        /// 返品上限設定マスタの更新処理
        /// </summary>
        /// <param name="goodsNotReturnWork">更新パラメータ</param>
        /// <param name="returnUpperStWork">更新共通域パラメータ</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">sqlCommandオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 返品上限設定マスタの更新処理を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int UpdateReturnUpperSt(GoodsNotReturnWork goodsNotReturnWork, ReturnUpperStWork returnUpperStWork,
                    ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            string retSql = string.Empty;

            retSql = "UPDATE RETURNUPPERSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , ACPTANODRSTATUSRF=@ACPTANODRSTATUS , SALESSLIPDTLNUMRF=@SALESSLIPDTLNUM , RETUPPERCNTRF=@RETUPPERCNT WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS AND SALESSLIPDTLNUMRF=@FINDSALESSLIPDTLNUM";

            //Parameterオブジェクトの作成(更新用)
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
            SqlParameter paraSalesSlipDtlNum = sqlCommand.Parameters.Add("@SALESSLIPDTLNUM", SqlDbType.BigInt);
            SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@RETUPPERCNT", SqlDbType.Int);

            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(returnUpperStWork.UpdateDateTime);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(returnUpperStWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(returnUpperStWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(returnUpperStWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(returnUpperStWork.LogicalDeleteCode);
            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(goodsNotReturnWork.AcptAnOdrStatus);
            paraSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(goodsNotReturnWork.SalesSlipDtlNum);
            paraDebitNoteDiv.Value = SqlDataMediator.SqlSetDouble(goodsNotReturnWork.RetUpperCnt);


            //Parameterオブジェクトの作成(検索用)
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
            SqlParameter findParaSalesSlipDtlNum = sqlCommand.Parameters.Add("@FINDSALESSLIPDTLNUM", SqlDbType.BigInt);

            //Parameterオブジェクトへ値設定(検索用)
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(goodsNotReturnWork.EnterpriseCode);
            findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(goodsNotReturnWork.AcptAnOdrStatus);
            findParaSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(goodsNotReturnWork.SalesSlipDtlNum);

            // 返品上限設定マスタ用SQL
            sqlCommand.CommandText = retSql;
            // 返品上限設定マスタを更新する
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }
        #endregion
    }
}

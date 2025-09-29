//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 検品データ DBリモートオブジェクト
// プログラム概要   : 検品データテーブルに対して削除処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊
// 作 成 日  2017/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 陳艶丹
// 作 成 日  2017/06/30  修正内容 : 検品データ登録の対応
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 陳艶丹
// 作 成 日  2017/07/20  修正内容 : 検品ガイドデータ検索の対応
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 3H 張小磊                               
// 修 正 日  2017/09/07  修正内容 : 検品照会の変更対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 検品データ DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品データテーブルの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 3H 張小磊</br>
    /// <br>Date       : 2017/05/22</br>
    /// </remarks>
    [Serializable]
    public class InspectDataDB : RemoteDB, IInspectDataDB
    {
        /// <summary>
        /// 検品データ DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検品データテーブルの実データ操作を行うクラスです。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/05/22</br>
        /// <br>UpdateNote : 2017/06/30 陳艶丹</br>
        /// <br>           : 検品データ登録の対応</br>
        /// </remarks>
        public InspectDataDB()
            :
            base("PMHND00213D", "Broadleaf.Application.Remoting.ParamData.InspectDataWork", "INSPECTDATARF")
        {
        }

        #region const
        /// <summary>ゼロ</summary>
        private const int Zero = 0;
        /// <summary>受払元伝票区分（20：売上）</summary>
        private const int SalesAcPaySlipCd = 20;
        /// <summary>受払元取引区分(11:返品)</summary>
        private const int RetAcPayTransCd = 11;
        #endregion

        #region [検品データ削除処理]
        /// <summary>
        /// 検品データを削除する
        /// </summary>
        /// <param name="inspectDataObj">検品データパラメータ</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 検品データテーブルの実データ削除を行う。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/05/22</br>
        /// </remarks>
        public int DeleteInspectData(ref object inspectDataObj, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMessage = string.Empty;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // 検品データを削除する
                status = this.DeleteInspectDataProc(ref inspectDataObj, ref sqlConnection, ref sqlTransaction, out retMessage);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                // ロールバック
                if (sqlTransaction.Connection != null)
                {
                    sqlTransaction.Rollback();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "InspectDataDB.DeleteInspectData Exception=" + ex.Message, status);

            }
            finally
            {
                if (sqlTransaction != null)
                {
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
        /// 検品データを削除する
        /// </summary>
        /// <param name="inspectDataObj">検品データパラメータ</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SQLトランザクション</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 検品データテーブルの実データ削除を行う。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/05/22</br>
        /// </remarks>
        public int DeleteInspectDataProc(ref object inspectDataObj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            InspectDataWork inspectDataWork = null;
            retMessage = string.Empty;

            //ArrayListの場合
            if (inspectDataObj is ArrayList)
            {
                ArrayList inspectDataWorkList = inspectDataObj as ArrayList;

                if (inspectDataWorkList.Count > 0)
                    inspectDataWork = inspectDataWorkList[0] as InspectDataWork;
            }

            //パラメータクラスの場合
            if (inspectDataObj is InspectDataWork)
            {
                inspectDataWork = inspectDataObj as InspectDataWork;
            }

            if (inspectDataWork == null)
            {
                return status;
            }

            status = DeleteInspectDataProc(ref inspectDataWork, ref sqlConnection, ref sqlTransaction, out retMessage);
            return status;
        }

        /// <summary>
        /// 検品データを削除する
        /// </summary>
        /// <param name="inspectDataWork">検品データパラメータ</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SQLトランザクション</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 検品データテーブルの実データ削除を行う。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/05/22</br>
        /// </remarks>
        public int DeleteInspectDataProc(ref InspectDataWork inspectDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMessage = string.Empty;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                # region [DELETE文]
                sqlText.Append(
                    "DELETE " +
                    " FROM INSPECTDATARF" +
                    " WHERE " +
                    " ENTERPRISECODERF = @FINDENTERPRISECODE" +
                    " AND CREATEDATETIMERF < @FINDCREATEDATETIME"
                    );
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findCreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATETIME", SqlDbType.BigInt);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inspectDataWork.EnterpriseCode);
                findCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inspectDataWork.CreateDateTime);

                sqlCommand.CommandText = sqlText.ToString();
                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                sqlCommand.ExecuteNonQuery();
                
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "InspectDataDB.DeleteInspectDataProc" + ex.Message, status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        #endregion

        // ----------- ADD 2017/06/30 陳艶丹 ---------------->>>>
        #region [検品データ登録（同一キーで物理削除）]
        /// <summary>
        /// 検品データ登録（同一キーで物理削除）
        /// </summary>
        /// <param name="inspectDataObj">HandyInspectDataWorkオブジェクト</param>
        /// <param name="mode">0:検品データ登録、1:検品データ登録(先行検品)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品データ情報を登録します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        public int WriteInspectData(ref object inspectDataObj, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(inspectDataObj);
                if (paraList == null)
                {
                    return status;
                }
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteInspectDataProc(ref paraList, ref sqlConnection, ref sqlTransaction, mode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "InspectDataDB.WriteInspectData Exception=" + ex.Message, status);
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 検品データ情報を登録します。
        /// </summary>
        /// <param name="inspectDataWorkList">HandyInspectDataWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <param name="mode">0:検品データ登録、1:検品データ登録(先行検品)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品データ情報を登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        public int WriteInspectDataProc(ref ArrayList inspectDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                if (mode == 0)
                {
                    // 全てデータを削除する
                    status = DeleteInspectData(ref inspectDataWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 登録処理
                        status = InsertInspectData(ref inspectDataWorkList, ref sqlConnection, ref sqlTransaction, mode);
                    }
                }
                else
                {
                    // 登録処理
                    status = InsertInspectData(ref inspectDataWorkList, ref sqlConnection, ref sqlTransaction, mode);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "InspectDataDB.WriteInspectDataProc Exception=" + ex.Message, status);
            }

            return status;
        }

        /// <summary>
        /// 検品データ情報を削除します。
        /// </summary>
        /// <param name="inspectDataWorkList">検品データ情報</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品データ情報を削除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        public int DeleteInspectData(ref ArrayList inspectDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (inspectDataWorkList != null)
                {
                    for (int i = 0; i < inspectDataWorkList.Count; i++)
                    {
                        HandyInspectDataWork inspectDataWork = inspectDataWorkList[i] as HandyInspectDataWork;
                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("DELETE FROM INSPECTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPAYSLIPCDRF=@FINDACPAYSLIPCD AND ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM AND ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO AND ACPAYTRANSCDRF=@FINDACPAYTRANSCD ", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCD", SqlDbType.Int);
                        SqlParameter findParaAcPaySlipNum = sqlCommand.Parameters.Add("@FINDACPAYSLIPNUM", SqlDbType.NVarChar);
                        SqlParameter findParaAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNO", SqlDbType.Int);
                        SqlParameter findParaAcPayTransCd = sqlCommand.Parameters.Add("@FINDACPAYTRANSCD", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inspectDataWork.EnterpriseCode);
                        findParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.AcPaySlipCd);
                        findParaAcPaySlipNum.Value = SqlDataMediator.SqlSetString(inspectDataWork.AcPaySlipNum);
                        findParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.AcPaySlipRowNo);
                        findParaAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.AcPayTransCd);

                        myReader = sqlCommand.ExecuteReader();
                        myReader.Close();
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "InspectDataDB.DeleteInspectData" + ex.Message, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
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

        /// <summary>
        /// 検品データ情報を登録します。
        /// </summary>
        /// <param name="inspectDataWorkList">検品データ情報</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <param name="mode">0:検品データ登録、1:検品データ登録(先行検品)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品データ情報を登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        public int InsertInspectData(ref ArrayList inspectDataWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            StringBuilder sb = new StringBuilder();
            try
            {
                if (inspectDataWorkList != null)
                {
                    NumberingManager numberingManager = new NumberingManager();
                    for (int i = 0; i < inspectDataWorkList.Count; i++)
                    {
                        HandyInspectDataWork inspectDataWork = inspectDataWorkList[i] as HandyInspectDataWork;
                        
                        if (mode == 1)
                        {
                            // 通番を採番
                            long no;
                            
                            //番号採番
                            status = numberingManager.GetSerialNumber(inspectDataWork.EnterpriseCode, "000000", (SerialNumberCode)4000, out no);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return status;  // → 採番に失敗したら処理終了
                            }
                            inspectDataWork.AcPaySlipNum = System.Convert.ToString(no);
                        }
                        else
                        {
                            //検品ステータスが「1,2,3」以外の場合、処理をスキップします。
                            if (inspectDataWork.InspectStatus != 1 &&
                                inspectDataWork.InspectStatus != 2 &&
                                inspectDataWork.InspectStatus != 3)
                            {
                                continue;
                            }
                        }
                        sb = new StringBuilder();
                        # region SELECT句生成
                        sb.AppendLine(" INSERT INTO ");
                        sb.AppendLine(" INSPECTDATARF ");
                        sb.AppendLine(" (CREATEDATETIMERF, ");
                        sb.AppendLine(" UPDATEDATETIMERF, ");
                        sb.AppendLine(" ENTERPRISECODERF, ");
                        sb.AppendLine(" FILEHEADERGUIDRF, ");
                        sb.AppendLine(" UPDEMPLOYEECODERF, ");
                        sb.AppendLine(" UPDASSEMBLYID1RF, ");
                        sb.AppendLine(" UPDASSEMBLYID2RF, ");
                        sb.AppendLine(" LOGICALDELETECODERF, ");
                        sb.AppendLine(" ACPAYSLIPCDRF, ");
                        sb.AppendLine(" ACPAYSLIPNUMRF, ");
                        sb.AppendLine(" ACPAYSLIPROWNORF, ");
                        sb.AppendLine(" ACPAYTRANSCDRF, ");
                        sb.AppendLine(" GOODSMAKERCDRF, ");
                        sb.AppendLine(" GOODSNORF, ");
                        sb.AppendLine(" WAREHOUSECODERF, ");
                        sb.AppendLine(" INSPECTDATETIMERF, ");
                        sb.AppendLine(" INSPECTSTATUSRF, ");
                        sb.AppendLine(" INSPECTCODERF, ");
                        sb.AppendLine(" INSPECTCNTRF, ");
                        sb.AppendLine(" HANDTERMINALCODERF, ");
                        sb.AppendLine(" MACHINENAMERF, ");
                        sb.AppendLine(" EMPLOYEECODERF ");
                        sb.AppendLine(" ) VALUES ( ");
                        sb.AppendLine(" @CREATEDATETIME, ");
                        sb.AppendLine(" @UPDATEDATETIME, ");
                        sb.AppendLine(" @ENTERPRISECODE, ");
                        sb.AppendLine(" @FILEHEADERGUID, ");
                        sb.AppendLine(" @UPDEMPLOYEECODE, ");
                        sb.AppendLine(" @UPDASSEMBLYID1, ");
                        sb.AppendLine(" @UPDASSEMBLYID2, ");
                        sb.AppendLine(" @LOGICALDELETECODE, ");
                        sb.AppendLine(" @ACPAYSLIPCD, ");
                        sb.AppendLine(" @ACPAYSLIPNUM, ");
                        sb.AppendLine(" @ACPAYSLIPROWNO, ");
                        sb.AppendLine(" @ACPAYTRANSCD, ");
                        sb.AppendLine(" @GOODSMAKERCD, ");
                        sb.AppendLine(" @GOODSNO, ");
                        sb.AppendLine(" @WAREHOUSECODE, ");
                        sb.AppendLine(" @INSPECTDATETIME, ");
                        sb.AppendLine(" @INSPECTSTATUS, ");
                        sb.AppendLine(" @INSPECTCODE, ");
                        sb.AppendLine(" @INSPECTCNT, ");
                        sb.AppendLine(" @HANDTERMINALCODE, ");
                        sb.AppendLine(" @MACHINENAME, ");
                        sb.AppendLine(" @EMPLOYEECODE) ");
                        # endregion

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)inspectDataWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        if (inspectDataWork.InspectDateTime == DateTime.MinValue)
                        {
                            inspectDataWork.InspectDateTime = DateTime.Now;
                        }
                        inspectDataWork.UpdEmployeeCode = inspectDataWork.EmployeeCode;
                        sqlCommand = new SqlCommand(sb.ToString(), sqlConnection, sqlTransaction);
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                        SqlParameter paraAcPaySlipNum = sqlCommand.Parameters.Add("@ACPAYSLIPNUM", SqlDbType.NVarChar);
                        SqlParameter paraAcPaySlipRowNo = sqlCommand.Parameters.Add("@ACPAYSLIPROWNO", SqlDbType.Int);
                        SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraInspectDateTime = sqlCommand.Parameters.Add("@INSPECTDATETIME", SqlDbType.BigInt);
                        SqlParameter paraInspectStatus = sqlCommand.Parameters.Add("@INSPECTSTATUS", SqlDbType.Int);
                        SqlParameter paraInspectCode = sqlCommand.Parameters.Add("@INSPECTCODE", SqlDbType.Int);
                        SqlParameter paraInspectCnt = sqlCommand.Parameters.Add("@INSPECTCNT", SqlDbType.Float);
                        SqlParameter paraHandTerminalCode = sqlCommand.Parameters.Add("@HANDTERMINALCODE", SqlDbType.Int);
                        SqlParameter paraMachineName = sqlCommand.Parameters.Add("@MACHINENAME", SqlDbType.NVarChar);
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inspectDataWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inspectDataWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inspectDataWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inspectDataWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inspectDataWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inspectDataWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inspectDataWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.LogicalDeleteCode);
                        paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.AcPaySlipCd);
                        paraAcPaySlipNum.Value = SqlDataMediator.SqlSetString(inspectDataWork.AcPaySlipNum);
                        paraAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.AcPaySlipRowNo);
                        paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.AcPayTransCd);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.GoodsMakerCd);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(inspectDataWork.GoodsNo);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(inspectDataWork.WarehouseCode);
                        paraInspectDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inspectDataWork.InspectDateTime);
                        paraInspectStatus.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.InspectStatus);
                        paraInspectCode.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.InspectCode);
                        paraInspectCnt.Value = SqlDataMediator.SqlSetDouble(inspectDataWork.InspectCnt);
                        paraHandTerminalCode.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.HandTerminalCode);
                        paraMachineName.Value = SqlDataMediator.SqlSetString(inspectDataWork.MachineName);
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(inspectDataWork.EmployeeCode);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "InspectDataDB.InsertInspectData" + ex.Message, status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            HandyInspectDataWork[] inspectDataWorkArray = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (paraobj == null)
            {
                base.WriteErrorLog("InspectDataDB.CastToArrayListFromPara" + "カスタムシリアライザ失敗");
                return retal;
            }

            try
            {
                //ArrayListの場合
                if (paraobj is ArrayList)
                {
                    retal = paraobj as ArrayList;
                }
                //パラメータクラスの場合
                else if (paraobj is HandyInspectDataWork)
                {
                    HandyInspectDataWork wkInspectDataWork = paraobj as HandyInspectDataWork;
                    if (wkInspectDataWork != null)
                    {
                        retal = new ArrayList();
                        retal.Add(wkInspectDataWork);
                    }
                    else
                    {
                        base.WriteErrorLog("InspectDataDB.CastToArrayListFromPara" + "カスタムシリアライザ失敗");
                    }
                }
                //byte[]の場合
                else if (paraobj is byte[])
                {
                    byte[] byteArray = paraobj as byte[];
                    try
                    {
                        inspectDataWorkArray = (HandyInspectDataWork[])XmlByteSerializer.Deserialize(byteArray, typeof(HandyInspectDataWork[]));
                    }
                    catch (Exception ex)
                    {
                        base.WriteErrorLog(ex, "InspectDataDB.CastToArrayListFromPara" + ex.Message, status);
                    }
                    if (inspectDataWorkArray != null)
                    {
                        retal = new ArrayList();
                        retal.AddRange(inspectDataWorkArray);
                    }
                    else
                    {
                        try
                        {
                            HandyInspectDataWork wkInspectDataWork = (HandyInspectDataWork)XmlByteSerializer.Deserialize(byteArray, typeof(HandyInspectDataWork));
                            if (wkInspectDataWork != null)
                            {
                                retal = new ArrayList();
                                retal.Add(wkInspectDataWork);
                            }
                            else
                            {
                                base.WriteErrorLog("InspectDataDB.CastToArrayListFromPara" + "カスタムシリアライザ失敗");
                            }
                        }
                        catch (Exception ex)
                        {
                            base.WriteErrorLog(ex, "InspectDataDB.CastToArrayListFromPara" + ex.Message, status);
                        }
                    }
                }
                // paraobjがArrayListでもHandyInspectDataWorkでもbyte[]でもない場合、エラーログを出力します
                else
                {
                    base.WriteErrorLog("InspectDataDB.CastToArrayListFromPara" + "カスタムシリアライザ失敗");
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InspectDataDB.CastToArrayListFromPara" + ex.Message, status);
            }

            return retal;
        }
        #endregion
        // ----------- ADD 2017/06/30 陳艶丹 ----------------<<<<

        // ----------- ADD 2017/07/20 陳艶丹 ---------------->>>>
        #region [Search]
        /// <summary>
        /// 指定された条件の検品データ情報LISTを戻します
        /// </summary>
        /// <param name="paraInspectDataWork">検索パラメータ</param>
        /// <param name="inspectDataObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の検品データ情報LISTを戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public int Search(object paraInspectDataWork, out object inspectDataObj)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection Connection = null;
            inspectDataObj = null;
             // コネクション生成
            using (Connection = CreateSqlConnection(true))
            {
                try
                {
                    return SearchProc(paraInspectDataWork, out inspectDataObj, ref Connection);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "InspectDataDB.Search" + ex.Message, Status);
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
        }

        /// <summary>
        /// 指定された条件の検品データ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="paraInspectDataWork">検索パラメータ</param>
        /// <param name="inspectDataWorkObj">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の検品データ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public int SearchProc(object paraInspectDataWork, out object inspectDataWorkObj, ref SqlConnection sqlConnection)
        {
            HandyInspectDataWork InspectDataWork = paraInspectDataWork as HandyInspectDataWork;
            ArrayList InspectDataList = new ArrayList();
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                Status = SearchInspectDataProc(InspectDataWork, out InspectDataList, ref sqlConnection);
            }
            catch (Exception ex)
            {
                Status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, "InspectDataDB.SearchProc" + ex.Message, Status);
            }

            inspectDataWorkObj = InspectDataList;

            return Status;
        }

        /// <summary>
        /// 指定された条件の検品データ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="inspectDataWork">検索パラメータ</param>
        /// <param name="inspectDataList">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の検品データ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private int SearchInspectDataProc(HandyInspectDataWork inspectDataWork, out ArrayList inspectDataList, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader MyReader = null;
            SqlCommand　Command = null;

            ArrayList RetList = new ArrayList();
            using (Command = new SqlCommand("", sqlConnection))
            {
                try
                {
                    // 検索クエリ文の構築
                    Command.CommandText = MkSelectSql(ref Command, inspectDataWork);
                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    Command.CommandTimeout = 3600;

                    using (MyReader = Command.ExecuteReader())
                    {
                        while (MyReader.Read())
                        {
                            // 抽出結果-値セット
                            RetList.Add(CopyToInspectDataWorkFromReader(ref MyReader));
                            Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        if (RetList.Count == 0)
                        {
                            Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    Status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    inspectDataList = new ArrayList();
                    Status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    base.WriteErrorLog(ex, "InspectDataDB.SearchInspectDataProc" + ex.Message, Status);
                }

                inspectDataList = RetList;
            }

            return Status;
        }

        /// <summary>
        /// 出力データの検索クエリの構築
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="inspectDataWork">検索条件</param>
        /// <returns>クエリ文</returns>
        /// <remarks>
        /// <br>Note       : 出力データの検索クエリの構築を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private string MkSelectSql(ref SqlCommand sqlCommand, HandyInspectDataWork inspectDataWork)
        {
            StringBuilder SqlText = new StringBuilder();
            SqlText.AppendLine("SELECT ");
            SqlText.AppendLine("UPDATEDATETIMERF, ");
            SqlText.AppendLine("EMPLOYEECODERF, ");
            SqlText.AppendLine("ENTERPRISECODERF, ");
            SqlText.AppendLine("LOGICALDELETECODERF, ");
            SqlText.AppendLine("ACPAYSLIPCDRF, ");
            SqlText.AppendLine("ACPAYSLIPNUMRF, ");
            SqlText.AppendLine("ACPAYSLIPROWNORF, ");
            SqlText.AppendLine("ACPAYTRANSCDRF, ");
            SqlText.AppendLine("GOODSMAKERCDRF, ");
            SqlText.AppendLine("WAREHOUSECODERF, ");
            SqlText.AppendLine("GOODSNORF, ");
            SqlText.AppendLine("INSPECTDATETIMERF, ");
            SqlText.AppendLine("INSPECTSTATUSRF, ");
            SqlText.AppendLine("INSPECTCODERF, ");
            SqlText.AppendLine("INSPECTCNTRF, ");
            SqlText.AppendLine("HANDTERMINALCODERF, ");
            SqlText.AppendLine("MACHINENAMERF ");
            SqlText.AppendLine("FROM INSPECTDATARF ");
            // WHERE文
            SqlText.AppendLine(MakeWhereSql(ref sqlCommand, inspectDataWork));
            SqlText.AppendLine(" ORDER BY INSPECTDATETIMERF ASC ");
            return SqlText.ToString();

        }

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="inspectDataWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private string MakeWhereSql(ref SqlCommand sqlCommand, HandyInspectDataWork inspectDataWork)
        {
            StringBuilder SqlText = new StringBuilder();

            SqlText.AppendLine("WHERE ");

            // 企業コード
            SqlText.AppendLine(" ENTERPRISECODERF=@ENTERPRISECODE");
            SqlParameter ParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            ParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inspectDataWork.EnterpriseCode);

            // 論理削除区分:0
            SqlText.AppendLine(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODERF");
            SqlParameter FindParaLogicalDeleteCd = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODERF", SqlDbType.Int);
            FindParaLogicalDeleteCd.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

            if (!String.IsNullOrEmpty(inspectDataWork.GoodsNo))
            {
                // 商品番号
                SqlText.AppendLine(" AND GOODSNORF=@FINDGOODSNO");
                SqlParameter FindParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                FindParaGoodsNo.Value = SqlDataMediator.SqlSetString(inspectDataWork.GoodsNo);
            }

            // 受払元行番号
            SqlText.AppendLine(" AND ACPAYSLIPROWNORF = @FINDACPAYSLIPROWNORF");
            SqlParameter ParaAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNORF", SqlDbType.Int);
            ParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(Zero);

            // 受払元伝票区分
            SqlText.AppendLine(" AND ACPAYSLIPCDRF = @FINDACPAYSLIPCDRF");
            SqlParameter ParaAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCDRF", SqlDbType.Int);
            ParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(SalesAcPaySlipCd);

            // 受払元取引区分
            SqlText.AppendLine(" AND ACPAYTRANSCDRF = @FINDACPAYTRANSCDRF");
            SqlParameter ParaAcPayTransCd = sqlCommand.Parameters.Add("@FINDACPAYTRANSCDRF", SqlDbType.Int);
            ParaAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(RetAcPayTransCd);

            // 倉庫コード
            if (!String.IsNullOrEmpty(inspectDataWork.WarehouseCode))
            {
                SqlText.AppendLine(" AND WAREHOUSECODERF=@FINDWAREHOUSECODE");
                SqlParameter FindParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                FindParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inspectDataWork.WarehouseCode);
            }

            // 商品メーカーコード
            if (inspectDataWork.GoodsMakerCd != 0)
            {
                SqlText.AppendLine(" AND GOODSMAKERCDRF=@FINDGOODSMAKERCDRF");
                SqlParameter FindParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDRF", SqlDbType.Int);
                FindParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.GoodsMakerCd);
            }
            return SqlText.ToString();
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → HandyInspectDataWork
        /// </summary>
        /// <param name="myReader">SQL実行結果</param>
        /// <returns>検品データ</returns>
        /// <remarks>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private HandyInspectDataWork CopyToInspectDataWorkFromReader(ref SqlDataReader myReader)
        {
            HandyInspectDataWork WkInspectDataWork = new HandyInspectDataWork();

            #region クラスへ格納
            WkInspectDataWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            WkInspectDataWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            WkInspectDataWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            WkInspectDataWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            WkInspectDataWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            WkInspectDataWork.AcPaySlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACPAYSLIPNUMRF"));
            WkInspectDataWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPROWNORF"));
            WkInspectDataWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            WkInspectDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            WkInspectDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            WkInspectDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            WkInspectDataWork.InspectDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("INSPECTDATETIMERF"));
            WkInspectDataWork.InspectStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTSTATUSRF"));
            WkInspectDataWork.InspectCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTCODERF"));
            WkInspectDataWork.InspectCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INSPECTCNTRF"));
            WkInspectDataWork.HandTerminalCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDTERMINALCODERF"));
            WkInspectDataWork.MachineName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MACHINENAMERF"));
            #endregion

            return WkInspectDataWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Note        : SqlConnection生成処理。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/07/20</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection RetSqlConnection = null;

            // SqlConnection生成
            SqlConnectionInfo ConnectionInfo = new SqlConnectionInfo();

            // SqlConnection接続
            string ConnectionText = ConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(ConnectionText))
            {
                RetSqlConnection = new SqlConnection(ConnectionText);

                if (open)
                {
                    RetSqlConnection.Open();
                }
            }
            else
            {
                base.WriteErrorLog("InspectDataDB.CreateSqlConnection" + "コネクション取得失敗");
            }

            // SqlConnection返す
            return RetSqlConnection;
        }
        #endregion 
        #endregion
        // ----------- ADD 2017/07/20 陳艶丹 ----------------<<<<

        // ----------- ADD 2017/09/07 3H 張小磊 ---------------->>>>
        #region [SearchGuid]
        /// <summary>
        /// 指定された条件の検品データ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="paraInspectDataWork">検索パラメータ</param>
        /// <param name="inspectDataWorkObj">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>ステータス</returns>
        /// <br>Note       : 指定された条件の検品データ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        public int SearchGuidProc(object paraInspectDataWork, out object inspectDataWorkObj, ref SqlConnection sqlConnection)
        {
            HandyInspectDataWork InspectDataWork = paraInspectDataWork as HandyInspectDataWork;
            ArrayList InspectDataList = new ArrayList();
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                Status = SearchGuidInspectDataProc(InspectDataWork, out InspectDataList, ref sqlConnection);
            }
            catch (Exception ex)
            {
                Status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, "InspectDataDB.SearchGuidProc" + ex.Message, Status);
            }

            inspectDataWorkObj = InspectDataList;

            return Status;
        }

        /// <summary>
        /// 指定された条件の検品データ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="inspectDataWork">検索パラメータ</param>
        /// <param name="inspectDataList">検索結果</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の検品データ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        private int SearchGuidInspectDataProc(HandyInspectDataWork inspectDataWork, out ArrayList inspectDataList, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader MyReader = null;
            SqlCommand Command = null;

            ArrayList RetList = new ArrayList();
            using (Command = new SqlCommand("", sqlConnection))
            {
                try
                {
                    // 検索クエリ文の構築
                    Command.CommandText = MkGuidSelectSql(ref Command, inspectDataWork);
                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    Command.CommandTimeout = 3600;

                    using (MyReader = Command.ExecuteReader())
                    {
                        while (MyReader.Read())
                        {
                            // 抽出結果-値セット
                            RetList.Add(CopyToInspectDataWorkFromReader(ref MyReader));
                            Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        if (RetList.Count == 0)
                        {
                            Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    Status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    inspectDataList = new ArrayList();
                    Status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    base.WriteErrorLog(ex, "InspectDataDB.SearchGuidInspectDataProc" + ex.Message, Status);
                }

                inspectDataList = RetList;
            }

            return Status;
        }

        /// <summary>
        /// 出力データの検索クエリの構築
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="inspectDataWork">検索条件</param>
        /// <returns>クエリ文</returns>
        /// <remarks>
        /// <br>Note       : 出力データの検索クエリの構築を行う。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private string MkGuidSelectSql(ref SqlCommand sqlCommand, HandyInspectDataWork inspectDataWork)
        {
            StringBuilder SqlText = new StringBuilder();
            SqlText.AppendLine("SELECT ");
            SqlText.AppendLine("UPDATEDATETIMERF, ");
            SqlText.AppendLine("EMPLOYEECODERF, ");
            SqlText.AppendLine("ENTERPRISECODERF, ");
            SqlText.AppendLine("LOGICALDELETECODERF, ");
            SqlText.AppendLine("ACPAYSLIPCDRF, ");
            SqlText.AppendLine("ACPAYSLIPNUMRF, ");
            SqlText.AppendLine("ACPAYSLIPROWNORF, ");
            SqlText.AppendLine("ACPAYTRANSCDRF, ");
            SqlText.AppendLine("GOODSMAKERCDRF, ");
            SqlText.AppendLine("WAREHOUSECODERF, ");
            SqlText.AppendLine("GOODSNORF, ");
            SqlText.AppendLine("INSPECTDATETIMERF, ");
            SqlText.AppendLine("INSPECTSTATUSRF, ");
            SqlText.AppendLine("INSPECTCODERF, ");
            SqlText.AppendLine("INSPECTCNTRF, ");
            SqlText.AppendLine("HANDTERMINALCODERF, ");
            SqlText.AppendLine("MACHINENAMERF ");
            SqlText.AppendLine("FROM INSPECTDATARF ");
            // WHERE文
            SqlText.AppendLine(MakeGuidWhereSql(ref sqlCommand, inspectDataWork));
            SqlText.AppendLine(" ORDER BY INSPECTDATETIMERF ASC ");
            return SqlText.ToString();

        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="inspectDataWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        private string MakeGuidWhereSql(ref SqlCommand sqlCommand, HandyInspectDataWork inspectDataWork)
        {
            StringBuilder SqlText = new StringBuilder();

            SqlText.AppendLine("WHERE ");

            // 企業コード
            SqlText.AppendLine(" ENTERPRISECODERF=@ENTERPRISECODE");
            SqlParameter ParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            ParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inspectDataWork.EnterpriseCode);

            // 論理削除区分:0
            SqlText.AppendLine(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODERF");
            SqlParameter FindParaLogicalDeleteCd = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODERF", SqlDbType.Int);
            FindParaLogicalDeleteCd.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

            if (!String.IsNullOrEmpty(inspectDataWork.GoodsNo))
            {
                // 商品番号
                SqlText.AppendLine(" AND GOODSNORF=@FINDGOODSNO");
                SqlParameter FindParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                FindParaGoodsNo.Value = SqlDataMediator.SqlSetString(inspectDataWork.GoodsNo);
            }

            // 受払元行番号
            SqlText.AppendLine(" AND ACPAYSLIPROWNORF = @FINDACPAYSLIPROWNORF");
            SqlParameter ParaAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNORF", SqlDbType.Int);
            ParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(Zero);

            // 受払元伝票区分
            if (inspectDataWork.AcPaySlipCd != 0)
            {
                SqlText.AppendLine(" AND ACPAYSLIPCDRF = @FINDACPAYSLIPCDRF");
                SqlParameter ParaAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCDRF", SqlDbType.Int);
                ParaAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.AcPaySlipCd);
            }

            // 受払元取引区分
            if (inspectDataWork.AcPayTransCd != 0)
            {
                SqlText.AppendLine(" AND ACPAYTRANSCDRF = @FINDACPAYTRANSCDRF");
                SqlParameter ParaAcPayTransCd = sqlCommand.Parameters.Add("@FINDACPAYTRANSCDRF", SqlDbType.Int);
                ParaAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.AcPayTransCd);
            }

            // 倉庫コード
            if (!String.IsNullOrEmpty(inspectDataWork.WarehouseCode))
            {
                SqlText.AppendLine(" AND WAREHOUSECODERF=@FINDWAREHOUSECODE");
                SqlParameter FindParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                FindParaWarehouseCode.Value = SqlDataMediator.SqlSetString(inspectDataWork.WarehouseCode);
            }

            // 商品メーカーコード
            if (inspectDataWork.GoodsMakerCd != 0)
            {
                SqlText.AppendLine(" AND GOODSMAKERCDRF=@FINDGOODSMAKERCDRF");
                SqlParameter FindParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDRF", SqlDbType.Int);
                FindParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(inspectDataWork.GoodsMakerCd);
            }
            return SqlText.ToString();
        }
        #endregion
        // ----------- ADD 2017/09/07 3H 張小磊 ----------------<<<<

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/05/22</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion  //[コネクション生成処理]
    }
}

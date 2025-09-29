//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン目標設定マスタ
// プログラム概要   : キャンペーン目標設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 徐佳
// 作 成 日  2011/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/05  修正内容 : Redmine#22750 フォーカス制御障害の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using Broadleaf.Library.Data;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// キャンペーン目標設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン目標設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 徐佳</br>
    /// <br>Date       : 2011/04/27</br>
    /// <br></br>
    /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
    /// </remarks>
    [Serializable]
    public class CampaignTargetUDB : RemoteWithAppLockDB, ICampaignTargetUDB
    {
        /// <summary>
        /// キャンペーン目標設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        /// </remarks>
        public CampaignTargetUDB()
            : base("PMKHN09657D", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork", "CAMPAIGNTARGETRF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一のキャンペーン目標設定マスタ情報を取得します。
        /// </summary>
        /// <param name="campaignTargetObj">CampaignTargetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン目標設定マスタのキー値が一致するキャンペーン目標設定マスタ情報を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        public int Read(ref object campaignTargetObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                CampaignTargetWork campaignTargetWork = campaignTargetObj as CampaignTargetWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref campaignTargetWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一のキャンペーン目標設定マスタ情報を取得します。
        /// </summary>
        /// <param name="campaignTargetWork">CampaignTargetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン目標設定マスタのキー値が一致するキャンペーン目標設定マスタ情報を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        public int Read(ref CampaignTargetWork campaignTargetWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref campaignTargetWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一のキャンペーン目標設定マスタ情報を取得します。
        /// </summary>
        /// <param name="campaignTargetWork">CampaignTargetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン目標設定マスタのキー値が一致するキャンペーン目標設定マスタ情報を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        private int ReadProc(ref CampaignTargetWork campaignTargetWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  ,TARGETCONTRASTCDRF" + Environment.NewLine;
                sqlText += "  ,EMPLOYEEDIVCDRF" + Environment.NewLine;
                sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,SALESAREACODERF" + Environment.NewLine;
                sqlText += "  ,BLGROUPCODERF" + Environment.NewLine;
                sqlText += "  ,BLGOODSCODERF" + Environment.NewLine;
                sqlText += "  ,SALESCODERF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY1RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY2RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY3RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY4RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY5RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY6RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY7RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY8RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY9RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY10RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY11RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY12RF" + Environment.NewLine;
                sqlText += "  ,MONTHLYSALESTARGETRF" + Environment.NewLine;
                sqlText += "  ,TERMSALESTARGETRF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT1RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT2RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT3RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT4RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT5RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT6RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT7RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT8RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT9RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT10RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT11RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT12RF" + Environment.NewLine;
                sqlText += "  ,MONTHLYSALESTARGETPROFITRF" + Environment.NewLine;
                sqlText += "  ,TERMSALESTARGETPROFITRF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT1RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT2RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT3RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT4RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT5RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT6RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT7RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT8RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT9RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT10RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT11RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT12RF" + Environment.NewLine;
                sqlText += "  ,MONTHLYSALESTARGETCOUNTRF" + Environment.NewLine;
                sqlText += "  ,TERMSALESTARGETCOUNTRF" + Environment.NewLine;
                sqlText += " FROM CAMPAIGNTARGETRF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CAMPAIGNCODERF=@FINDPARACAMPAIGNCODE" + Environment.NewLine;
                sqlText += "  AND TARGETCONTRASTCDRF=@FINDPARATARGETCONTRASTCD" + Environment.NewLine;
                sqlText += "  AND EMPLOYEEDIVCDRF=@FINDPARAEMPLOYEEDIVCD" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF=@FINDPARASECTIONCODE" + Environment.NewLine;
                sqlText += "  AND EMPLOYEECODERF=@FINDPARAEMPLOYEECODE" + Environment.NewLine;
                sqlText += "  AND CUSTOMERCODERF=@FINDPARACUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND SALESAREACODERF=@FINDPARASALESAREACODE" + Environment.NewLine;
                sqlText += "  AND BLGROUPCODERF=@FINDPARABLGROUPCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDPARACAMPAIGNCODE", SqlDbType.Int);
                SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDPARATARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEEDIVCD", SqlDbType.Int);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDPARASECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDPARACUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDPARASALESAREACODE", SqlDbType.Int);
                SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDPARABLGROUPCODE", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDPARABLGOODSCODE", SqlDbType.Int);
                SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDPARASALESCODE", SqlDbType.Int);


                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                findParaEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToCampaignTargetWorkFromReader(ref myReader, ref campaignTargetWork);
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
        /// キャンペーン目標設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">物理削除するキャンペーン目標設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン目標設定マスタのキー値が一致するキャンペーン目標設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection(true);
                if (sqlConnection == null) return status;

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteCampaignTargetProc(paraList, ref sqlConnection, ref sqlTransaction);
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
        /// キャンペーン目標設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="campaignTargetList">キャンペーン目標設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetList に格納されているキャンペーン目標設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        public int DeleteCampaignTargetProc(ArrayList campaignTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(campaignTargetList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// キャンペーン目標設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="campaignTargetList">キャンペーン目標設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetList に格納されているキャンペーン目標設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        private int DeleteProc(ArrayList campaignTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (campaignTargetList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < campaignTargetList.Count; i++)
                    {
                        CampaignTargetWork campaignTargetWork = campaignTargetList[i] as CampaignTargetWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "   UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM CAMPAIGNTARGETRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CAMPAIGNCODERF=@FINDPARACAMPAIGNCODE" + Environment.NewLine;
                        sqlText += "  AND TARGETCONTRASTCDRF=@FINDPARATARGETCONTRASTCD" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEEDIVCDRF=@FINDPARAEMPLOYEEDIVCD" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF=@FINDPARASECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEECODERF=@FINDPARAEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDPARACUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SALESAREACODERF=@FINDPARASALESAREACODE" + Environment.NewLine;
                        sqlText += "  AND BLGROUPCODERF=@FINDPARABLGROUPCODE" + Environment.NewLine;
                        sqlText += "  AND BLGOODSCODERF=@FINDPARABLGOODSCODE" + Environment.NewLine;
                        sqlText += "  AND SALESCODERF=@FINDPARASALESCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDPARACAMPAIGNCODE", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDPARATARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEEDIVCD", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDPARASECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDPARACUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDPARASALESAREACODE", SqlDbType.Int);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDPARABLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDPARABLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDPARASALESCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                        findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                        findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                        findParaEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                        findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != campaignTargetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  CAMPAIGNTARGETRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CAMPAIGNCODERF=@FINDPARACAMPAIGNCODE" + Environment.NewLine;
                            sqlText += "  AND TARGETCONTRASTCDRF=@FINDPARATARGETCONTRASTCD" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEEDIVCDRF=@FINDPARAEMPLOYEEDIVCD" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDPARASECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEECODERF=@FINDPARAEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDPARACUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND SALESAREACODERF=@FINDPARASALESAREACODE" + Environment.NewLine;
                            sqlText += "  AND BLGROUPCODERF=@FINDPARABLGROUPCODE" + Environment.NewLine;
                            sqlText += "  AND BLGOODSCODERF=@FINDPARABLGOODSCODE" + Environment.NewLine;
                            sqlText += "  AND SALESCODERF=@FINDPARASALESCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                            findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                            findParaEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                            findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                            findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);
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
        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            CampaignTargetWork[] CampaignTargetWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is CampaignTargetWork)
                    {
                        CampaignTargetWork wkCampaignTargetWork = paraobj as CampaignTargetWork;
                        if (wkCampaignTargetWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkCampaignTargetWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            CampaignTargetWorkArray = (CampaignTargetWork[])XmlByteSerializer.Deserialize(byteArray, typeof(CampaignTargetWork[]));
                        }
                        catch (Exception) { }
                        if (CampaignTargetWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(CampaignTargetWorkArray);
                        }
                        else
                        {
                            try
                            {
                                CampaignTargetWork wkCampaignTargetWork = (CampaignTargetWork)XmlByteSerializer.Deserialize(byteArray, typeof(CampaignTargetWork));
                                if (wkCampaignTargetWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkCampaignTargetWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion
        # region [Search]
        /// <summary>
        /// キャンペーン目標設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="campaignTargetList">検索結果</param>
        /// <param name="campaignTargetObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン目標設定マスタのキー値が一致する、全てのキャンペーン目標設定マスタ情報を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        public int Search(ref object campaignTargetList, object campaignTargetObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList campaignTargetArray = campaignTargetList as ArrayList;
                CampaignTargetWork campaignTargetUWork = campaignTargetObj as CampaignTargetWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref campaignTargetArray, campaignTargetUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);

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
        /// キャンペーン目標設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="campaignTargetList">キャンペーン目標設定マスタ情報を格納する ArrayList</param>
        /// <param name="campaignTargetWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン目標設定マスタのキー値が一致する、全てのキャンペーン目標設定マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        public int Search(ref ArrayList campaignTargetList, CampaignTargetWork campaignTargetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref campaignTargetList, campaignTargetWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// キャンペーン目標設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="campaignTargetList">キャンペーン目標設定マスタ情報を格納する ArrayList</param>
        /// <param name="campaignTargetWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン目標設定マスタのキー値が一致する、全てのキャンペーン目標設定マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        private int SearchProc(ref ArrayList campaignTargetList, CampaignTargetWork campaignTargetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,CAMPAIGNCODERF" + Environment.NewLine;
                sqlText += "  ,TARGETCONTRASTCDRF" + Environment.NewLine;
                sqlText += "  ,EMPLOYEEDIVCDRF" + Environment.NewLine;
                sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,SALESAREACODERF" + Environment.NewLine;
                sqlText += "  ,BLGROUPCODERF" + Environment.NewLine;
                sqlText += "  ,BLGOODSCODERF" + Environment.NewLine;
                sqlText += "  ,SALESCODERF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY1RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY2RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY3RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY4RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY5RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY6RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY7RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY8RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY9RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY10RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY11RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETMONEY12RF" + Environment.NewLine;
                sqlText += "  ,MONTHLYSALESTARGETRF" + Environment.NewLine;
                sqlText += "  ,TERMSALESTARGETRF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT1RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT2RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT3RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT4RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT5RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT6RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT7RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT8RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT9RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT10RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT11RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETPROFIT12RF" + Environment.NewLine;
                sqlText += "  ,MONTHLYSALESTARGETPROFITRF" + Environment.NewLine;
                sqlText += "  ,TERMSALESTARGETPROFITRF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT1RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT2RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT3RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT4RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT5RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT6RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT7RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT8RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT9RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT10RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT11RF" + Environment.NewLine;
                sqlText += "  ,SALESTARGETCOUNT12RF" + Environment.NewLine;
                sqlText += "  ,MONTHLYSALESTARGETCOUNTRF" + Environment.NewLine;
                sqlText += "  ,TERMSALESTARGETCOUNTRF" + Environment.NewLine;
                sqlText += " FROM CAMPAIGNTARGETRF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, campaignTargetWork, logicalMode);
                # endregion


                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    campaignTargetList.Add(this.CopyToCampaignTargetWorkFromReader(ref myReader));
                }

                if (campaignTargetList.Count > 0)
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
        /// キャンペーン目標設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="campaignTargetList">追加・更新するキャンペーン目標設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetList に格納されているキャンペーン目標設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        public int Write(ref object campaignTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = campaignTargetList as ArrayList;

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
        /// キャンペーン目標設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="campaignTargetList">追加・更新するキャンペーン目標設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetList に格納されているキャンペーン目標設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        public int Write(ref ArrayList campaignTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref campaignTargetList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// キャンペーン目標設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="campaignTargetList">追加・更新するキャンペーン目標設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetList に格納されているキャンペーン目標設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        private int WriteProc(ref ArrayList campaignTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (campaignTargetList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < campaignTargetList.Count; i++)
                    {
                        CampaignTargetWork campaignTargetWork = campaignTargetList[i] as CampaignTargetWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CAMPAIGNTARGETRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CAMPAIGNCODERF=@FINDPARACAMPAIGNCODE" + Environment.NewLine;
                        sqlText += "  AND TARGETCONTRASTCDRF=@FINDPARATARGETCONTRASTCD" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEEDIVCDRF=@FINDPARAEMPLOYEEDIVCD" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF=@FINDPARASECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEECODERF=@FINDPARAEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDPARACUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SALESAREACODERF=@FINDPARASALESAREACODE" + Environment.NewLine;
                        sqlText += "  AND BLGROUPCODERF=@FINDPARABLGROUPCODE" + Environment.NewLine;
                        sqlText += "  AND BLGOODSCODERF=@FINDPARABLGOODSCODE" + Environment.NewLine;
                        sqlText += "  AND SALESCODERF=@FINDPARASALESCODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDPARACAMPAIGNCODE", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDPARATARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEEDIVCD", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDPARASECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDPARACUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDPARASALESAREACODE", SqlDbType.Int);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDPARABLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDPARABLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDPARASALESCODE", SqlDbType.Int);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                        findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                        findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                        findParaEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                        findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != campaignTargetWork.UpdateDateTime)
                            {
                                if (campaignTargetWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText += "UPDATE CAMPAIGNTARGETRF SET" + Environment.NewLine;
                            sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  ,FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "  ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  ,CAMPAIGNCODERF=@CAMPAIGNCODE" + Environment.NewLine;
                            sqlText += "  ,TARGETCONTRASTCDRF=@TARGETCONTRASTCD" + Environment.NewLine;
                            sqlText += "  ,EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD" + Environment.NewLine;
                            sqlText += "  ,SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += "  ,EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  ,SALESAREACODERF=@SALESAREACODE" + Environment.NewLine;
                            sqlText += "  ,BLGROUPCODERF=@BLGROUPCODE" + Environment.NewLine;
                            sqlText += "  ,BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            sqlText += "  ,SALESCODERF=@SALESCODE" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY1RF=@SALESTARGETMONEY1" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY2RF=@SALESTARGETMONEY2" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY3RF=@SALESTARGETMONEY3" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY4RF=@SALESTARGETMONEY4" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY5RF=@SALESTARGETMONEY5" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY6RF=@SALESTARGETMONEY6" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY7RF=@SALESTARGETMONEY7" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY8RF=@SALESTARGETMONEY8" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY9RF=@SALESTARGETMONEY9" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY10RF=@SALESTARGETMONEY10" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY11RF=@SALESTARGETMONEY11" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY12RF=@SALESTARGETMONEY12" + Environment.NewLine;
                            sqlText += "  ,MONTHLYSALESTARGETRF=@MONTHLYSALESTARGET" + Environment.NewLine;
                            sqlText += "  ,TERMSALESTARGETRF=@TERMSALESTARGET" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT1RF=@SALESTARGETPROFIT1" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT2RF=@SALESTARGETPROFIT2" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT3RF=@SALESTARGETPROFIT3" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT4RF=@SALESTARGETPROFIT4" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT5RF=@SALESTARGETPROFIT5" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT6RF=@SALESTARGETPROFIT6" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT7RF=@SALESTARGETPROFIT7" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT8RF=@SALESTARGETPROFIT8" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT9RF=@SALESTARGETPROFIT9" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT10RF=@SALESTARGETPROFIT10" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT11RF=@SALESTARGETPROFIT11" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT12RF=@SALESTARGETPROFIT12" + Environment.NewLine;
                            sqlText += "  ,MONTHLYSALESTARGETPROFITRF=@MONTHLYSALESTARGETPROFIT" + Environment.NewLine;
                            sqlText += "  ,TERMSALESTARGETPROFITRF=@TERMSALESTARGETPROFIT" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT1RF=@SALESTARGETCOUNT1" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT2RF=@SALESTARGETCOUNT2" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT3RF=@SALESTARGETCOUNT3" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT4RF=@SALESTARGETCOUNT4" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT5RF=@SALESTARGETCOUNT5" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT6RF=@SALESTARGETCOUNT6" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT7RF=@SALESTARGETCOUNT7" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT8RF=@SALESTARGETCOUNT8" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT9RF=@SALESTARGETCOUNT9" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT10RF=@SALESTARGETCOUNT10" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT11RF=@SALESTARGETCOUNT11" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT12RF=@SALESTARGETCOUNT12" + Environment.NewLine;
                            sqlText += "  ,MONTHLYSALESTARGETCOUNTRF=@MONTHLYSALESTARGETCOUNT" + Environment.NewLine;
                            sqlText += "  ,TERMSALESTARGETCOUNTRF=@TERMSALESTARGETCOUNT" + Environment.NewLine;
                            sqlText += " FROM CAMPAIGNTARGETRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CAMPAIGNCODERF=@FINDPARACAMPAIGNCODE" + Environment.NewLine;
                            sqlText += "  AND TARGETCONTRASTCDRF=@FINDPARATARGETCONTRASTCD" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEEDIVCDRF=@FINDPARAEMPLOYEEDIVCD" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDPARASECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEECODERF=@FINDPARAEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDPARACUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND SALESAREACODERF=@FINDPARASALESAREACODE" + Environment.NewLine;
                            sqlText += "  AND BLGROUPCODERF=@FINDPARABLGROUPCODE" + Environment.NewLine;
                            sqlText += "  AND BLGOODSCODERF=@FINDPARABLGOODSCODE" + Environment.NewLine;
                            sqlText += "  AND SALESCODERF=@FINDPARASALESCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                            findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                            findParaEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                            findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                            findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignTargetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (campaignTargetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO CAMPAIGNTARGETRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "  ,CAMPAIGNCODERF" + Environment.NewLine;
                            sqlText += "  ,TARGETCONTRASTCDRF" + Environment.NewLine;
                            sqlText += "  ,EMPLOYEEDIVCDRF" + Environment.NewLine;
                            sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "  ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += "  ,SALESAREACODERF" + Environment.NewLine;
                            sqlText += "  ,BLGROUPCODERF" + Environment.NewLine;
                            sqlText += "  ,BLGOODSCODERF" + Environment.NewLine;
                            sqlText += "  ,SALESCODERF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY1RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY2RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY3RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY4RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY5RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY6RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY7RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY8RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY9RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY10RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY11RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETMONEY12RF" + Environment.NewLine;
                            sqlText += "  ,MONTHLYSALESTARGETRF" + Environment.NewLine;
                            sqlText += "  ,TERMSALESTARGETRF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT1RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT2RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT3RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT4RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT5RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT6RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT7RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT8RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT9RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT10RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT11RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETPROFIT12RF" + Environment.NewLine;
                            sqlText += "  ,MONTHLYSALESTARGETPROFITRF" + Environment.NewLine;
                            sqlText += "  ,TERMSALESTARGETPROFITRF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT1RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT2RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT3RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT4RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT5RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT6RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT7RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT8RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT9RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT10RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT11RF" + Environment.NewLine;
                            sqlText += "  ,SALESTARGETCOUNT12RF" + Environment.NewLine;
                            sqlText += "  ,MONTHLYSALESTARGETCOUNTRF" + Environment.NewLine;
                            sqlText += "  ,TERMSALESTARGETCOUNTRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  ,@CAMPAIGNCODE" + Environment.NewLine;
                            sqlText += "  ,@TARGETCONTRASTCD" + Environment.NewLine;
                            sqlText += "  ,@EMPLOYEEDIVCD" + Environment.NewLine;
                            sqlText += "  ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "  ,@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  ,@SALESAREACODE" + Environment.NewLine;
                            sqlText += "  ,@BLGROUPCODE" + Environment.NewLine;
                            sqlText += "  ,@BLGOODSCODE" + Environment.NewLine;
                            sqlText += "  ,@SALESCODE" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY1" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY2" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY3" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY4" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY5" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY6" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY7" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY8" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY9" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY10" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY11" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETMONEY12" + Environment.NewLine;
                            sqlText += "  ,@MONTHLYSALESTARGET" + Environment.NewLine;
                            sqlText += "  ,@TERMSALESTARGET" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT1" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT2" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT3" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT4" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT5" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT6" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT7" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT8" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT9" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT10" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT11" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETPROFIT12" + Environment.NewLine;
                            sqlText += "  ,@MONTHLYSALESTARGETPROFIT" + Environment.NewLine;
                            sqlText += "  ,@TERMSALESTARGETPROFIT" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT1" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT2" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT3" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT4" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT5" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT6" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT7" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT8" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT9" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT10" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT11" + Environment.NewLine;
                            sqlText += "  ,@SALESTARGETCOUNT12" + Environment.NewLine;
                            sqlText += "  ,@MONTHLYSALESTARGETCOUNT" + Environment.NewLine;
                            sqlText += "  ,@TERMSALESTARGETCOUNT)" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignTargetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameterオブジェクトの作成(更新用)
                        //Prameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
                        SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                        SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@SALESCODE", SqlDbType.Int);
                        SqlParameter paraSalesTargetMoney1 = sqlCommand.Parameters.Add("@SALESTARGETMONEY1", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney2 = sqlCommand.Parameters.Add("@SALESTARGETMONEY2", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney3 = sqlCommand.Parameters.Add("@SALESTARGETMONEY3", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney4 = sqlCommand.Parameters.Add("@SALESTARGETMONEY4", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney5 = sqlCommand.Parameters.Add("@SALESTARGETMONEY5", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney6 = sqlCommand.Parameters.Add("@SALESTARGETMONEY6", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney7 = sqlCommand.Parameters.Add("@SALESTARGETMONEY7", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney8 = sqlCommand.Parameters.Add("@SALESTARGETMONEY8", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney9 = sqlCommand.Parameters.Add("@SALESTARGETMONEY9", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney10 = sqlCommand.Parameters.Add("@SALESTARGETMONEY10", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney11 = sqlCommand.Parameters.Add("@SALESTARGETMONEY11", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetMoney12 = sqlCommand.Parameters.Add("@SALESTARGETMONEY12", SqlDbType.BigInt);
                        SqlParameter paraMonthlySalesTarget = sqlCommand.Parameters.Add("@MONTHLYSALESTARGET", SqlDbType.BigInt);
                        SqlParameter paraTermSalesTarget = sqlCommand.Parameters.Add("@TERMSALESTARGET", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit1 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT1", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit2 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT2", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit3 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT3", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit4 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT4", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit5 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT5", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit6 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT6", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit7 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT7", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit8 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT8", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit9 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT9", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit10 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT10", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit11 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT11", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit12 = sqlCommand.Parameters.Add("@SALESTARGETPROFIT12", SqlDbType.BigInt);
                        SqlParameter paraMonthlySalesTargetProfit = sqlCommand.Parameters.Add("@MONTHLYSALESTARGETPROFIT", SqlDbType.BigInt);
                        SqlParameter paraTermSalesTargetProfit = sqlCommand.Parameters.Add("@TERMSALESTARGETPROFIT", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetCount1 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT1", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount2 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT2", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount3 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT3", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount4 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT4", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount5 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT5", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount6 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT6", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount7 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT7", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount8 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT8", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount9 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT9", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount10 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT10", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount11 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT11", SqlDbType.Float);
                        SqlParameter paraSalesTargetCount12 = sqlCommand.Parameters.Add("@SALESTARGETCOUNT12", SqlDbType.Float);
                        SqlParameter paraMonthlySalesTargetCount = sqlCommand.Parameters.Add("@MONTHLYSALESTARGETCOUNT", SqlDbType.Float);
                        SqlParameter paraTermSalesTargetCount = sqlCommand.Parameters.Add("@TERMSALESTARGETCOUNT", SqlDbType.Float);
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        //Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignTargetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignTargetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignTargetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignTargetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignTargetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.LogicalDeleteCode);
                        paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                        paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                        paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                        paraEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                        paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                        paraSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);
                        paraSalesTargetMoney1.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney1);
                        paraSalesTargetMoney2.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney2);
                        paraSalesTargetMoney3.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney3);
                        paraSalesTargetMoney4.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney4);
                        paraSalesTargetMoney5.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney5);
                        paraSalesTargetMoney6.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney6);
                        paraSalesTargetMoney7.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney7);
                        paraSalesTargetMoney8.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney8);
                        paraSalesTargetMoney9.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney9);
                        paraSalesTargetMoney10.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney10);
                        paraSalesTargetMoney11.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney11);
                        paraSalesTargetMoney12.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetMoney12);
                        paraMonthlySalesTarget.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.MonthlySalesTarget);
                        paraTermSalesTarget.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.TermSalesTarget);
                        paraSalesTargetProfit1.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit1);
                        paraSalesTargetProfit2.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit2);
                        paraSalesTargetProfit3.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit3);
                        paraSalesTargetProfit4.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit4);
                        paraSalesTargetProfit5.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit5);
                        paraSalesTargetProfit6.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit6);
                        paraSalesTargetProfit7.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit7);
                        paraSalesTargetProfit8.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit8);
                        paraSalesTargetProfit9.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit9);
                        paraSalesTargetProfit10.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit10);
                        paraSalesTargetProfit11.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit11);
                        paraSalesTargetProfit12.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.SalesTargetProfit12);
                        paraMonthlySalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.MonthlySalesTargetProfit);
                        paraTermSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(campaignTargetWork.TermSalesTargetProfit);
                        paraSalesTargetCount1.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount1);
                        paraSalesTargetCount2.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount2);
                        paraSalesTargetCount3.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount3);
                        paraSalesTargetCount4.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount4);
                        paraSalesTargetCount5.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount5);
                        paraSalesTargetCount6.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount6);
                        paraSalesTargetCount7.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount7);
                        paraSalesTargetCount8.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount8);
                        paraSalesTargetCount9.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount9);
                        paraSalesTargetCount10.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount10);
                        paraSalesTargetCount11.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount11);
                        paraSalesTargetCount12.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.SalesTargetCount12);
                        paraMonthlySalesTargetCount.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.MonthlySalesTargetCount);
                        paraTermSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(campaignTargetWork.TermSalesTargetCount);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(campaignTargetWork);
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

            campaignTargetList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// キャンペーン目標設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="campaignTargetList">論理削除するキャンペーン目標設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetWork に格納されているキャンペーン目標設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        public int LogicalDelete(ref object campaignTargetList)
        {
            return this.LogicalDelete(ref campaignTargetList, 0);
        }

        /// <summary>
        /// キャンペーン目標設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="campaignTargetList">論理削除を解除するキャンペーン目標設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetWork に格納されているキャンペーン目標設定マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        public int RevivalLogicalDelete(ref object campaignTargetList)
        {
            return this.LogicalDelete(ref campaignTargetList, 1);
        }

        /// <summary>
        /// キャンペーン目標設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="campaignTargetList">論理削除を操作するキャンペーン目標設定マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetWork に格納されているキャンペーン目標設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        private int LogicalDelete(ref object campaignTargetList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = campaignTargetList as ArrayList;

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
        /// キャンペーン目標設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="campaignTargetList">論理削除を操作するキャンペーン目標設定マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetWork に格納されているキャンペーン目標設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        public int LogicalDelete(ref ArrayList campaignTargetList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref campaignTargetList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// キャンペーン目標設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="campaignTargetList">論理削除を操作するキャンペーン目標設定マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetWork に格納されているキャンペーン目標設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        /// <br>Update Note: 2011/07/05 譚洪 Redmine#22750 フォーカス制御障害の対応</br>
        private int LogicalDeleteProc(ref ArrayList campaignTargetList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (campaignTargetList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < campaignTargetList.Count; i++)
                    {
                        CampaignTargetWork campaignTargetWork = campaignTargetList[i] as CampaignTargetWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "   UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM CAMPAIGNTARGETRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CAMPAIGNCODERF=@FINDPARACAMPAIGNCODE" + Environment.NewLine;
                        sqlText += "  AND TARGETCONTRASTCDRF=@FINDPARATARGETCONTRASTCD" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEEDIVCDRF=@FINDPARAEMPLOYEEDIVCD" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF=@FINDPARASECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEECODERF=@FINDPARAEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDPARACUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SALESAREACODERF=@FINDPARASALESAREACODE" + Environment.NewLine;
                        sqlText += "  AND BLGROUPCODERF=@FINDPARABLGROUPCODE" + Environment.NewLine;
                        sqlText += "  AND BLGOODSCODERF=@FINDPARABLGOODSCODE" + Environment.NewLine;   // ADD K2011/07/05 
                        sqlText += "  AND SALESCODERF=@FINDPARASALESCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDPARACAMPAIGNCODE", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDPARATARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEEDIVCD", SqlDbType.Int);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDPARASECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDPARAEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDPARACUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDPARASALESAREACODE", SqlDbType.Int);
                        SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDPARABLGROUPCODE", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDPARABLGOODSCODE", SqlDbType.Int);
                        SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDPARASALESCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                        findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                        findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                        findParaEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                        findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                        findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != campaignTargetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE CAMPAIGNTARGETRF SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " FROM CAMPAIGNTARGETRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CAMPAIGNCODERF=@FINDPARACAMPAIGNCODE" + Environment.NewLine;
                            sqlText += "  AND TARGETCONTRASTCDRF=@FINDPARATARGETCONTRASTCD" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEEDIVCDRF=@FINDPARAEMPLOYEEDIVCD" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDPARASECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEECODERF=@FINDPARAEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDPARACUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND SALESAREACODERF=@FINDPARASALESAREACODE" + Environment.NewLine;
                            sqlText += "  AND BLGROUPCODERF=@FINDPARABLGROUPCODE" + Environment.NewLine;
                            sqlText += "  AND BLGOODSCODERF=@FINDPARABLGOODSCODE" + Environment.NewLine;
                            sqlText += "  AND SALESCODERF=@FINDPARASALESCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            // Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);
                            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);
                            findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.SectionCode);
                            findParaEmployeeCode.Value = campaignTargetWork.EmployeeCode;
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);
                            findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                            findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                            findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignTargetWork;
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
                            else if (logicalDelCd == 0) campaignTargetWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else campaignTargetWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                campaignTargetWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignTargetWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignTargetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignTargetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(campaignTargetWork);
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

            campaignTargetList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="campaignTargetWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CampaignTargetWork campaignTargetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // 企業コード
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EnterpriseCode);

            // キャンペーンコード
            retstring += "  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE" + Environment.NewLine;
            SqlParameter findCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CampaignCode);

            // 目標対比区分
            retstring += "  AND TARGETCONTRASTCDRF = @FINDTARGETCONTRASTCD" + Environment.NewLine;
            SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
            findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.TargetContrastCd);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            if (campaignTargetWork.TargetContrastCd == 10)
            {
                // 拠点コード
                if (string.IsNullOrEmpty(campaignTargetWork.SectionCode) == false)
                {
                    retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = campaignTargetWork.SectionCode;
                }
            }

            if (campaignTargetWork.TargetContrastCd == 22)
            {
                // 拠点コード
                if (string.IsNullOrEmpty(campaignTargetWork.SectionCode) == false)
                {
                    retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = campaignTargetWork.SectionCode;
                }

                // 従業員コード
                if (string.IsNullOrEmpty(campaignTargetWork.EmployeeCode) == false)
                {
                    retstring += "AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                    SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                    findEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignTargetWork.EmployeeCode);
                }

                // 従業員区分
                if (campaignTargetWork.EmployeeDivCd != 0)
                {
                    retstring += "AND EMPLOYEEDIVCDRF = @FINDEMPLOYEEDIVCD" + Environment.NewLine;
                    SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
                    findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.EmployeeDivCd);
                }
            }

            if (campaignTargetWork.TargetContrastCd == 30)
            {
                // 拠点コード
                if (string.IsNullOrEmpty(campaignTargetWork.SectionCode) == false)
                {
                    retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = campaignTargetWork.SectionCode;
                }

                // 得意先コード
                if (campaignTargetWork.CustomerCode != 0)
                {
                    retstring += "AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.CustomerCode);

                }
            }

            if (campaignTargetWork.TargetContrastCd == 32)
            {
                // 拠点コード
                if (string.IsNullOrEmpty(campaignTargetWork.SectionCode) == false)
                {
                    retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = campaignTargetWork.SectionCode;
                }
                 
                // 販売エリアコード
                if (campaignTargetWork.SalesAreaCode != 0)
                {
                    retstring += "AND SALESAREACODERF = @FINDSALESAREACODE" + Environment.NewLine;
                    SqlParameter findSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);
                    findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesAreaCode);
                }
            }

            if (campaignTargetWork.TargetContrastCd == 44)
            {
                // 拠点コード
                if (string.IsNullOrEmpty(campaignTargetWork.SectionCode) == false)
                {
                    retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = campaignTargetWork.SectionCode;
                }

                // 販売区分コード
                if (campaignTargetWork.SalesCode != 0)
                {                                   
                    retstring += "AND SALESCODERF = @FINDSALESCODE" + Environment.NewLine;
                    SqlParameter findSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                    findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.SalesCode);
                }
            }

            if (campaignTargetWork.TargetContrastCd == 50)
            {
                // 拠点コード
                if (string.IsNullOrEmpty(campaignTargetWork.SectionCode) == false)
                {
                    retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = campaignTargetWork.SectionCode;
                }

                // BLグループコード
                if (campaignTargetWork.BLGroupCode != 0)
                {
                    retstring += "AND BLGROUPCODERF = @FINDBLGROUPCODE" + Environment.NewLine;
                    SqlParameter findBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    findBLGroupCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGroupCode);
                }
            }

            if (campaignTargetWork.TargetContrastCd == 60)
            {
                // 拠点コード
                if (string.IsNullOrEmpty(campaignTargetWork.SectionCode) == false)
                {
                    retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = campaignTargetWork.SectionCode;
                }

                // BLコード
                if (campaignTargetWork.BLGoodsCode != 0)
                {
                    retstring += "AND BLGOODSCODERF = @FINDBLGOODSCODE" + Environment.NewLine;
                    SqlParameter findBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(campaignTargetWork.BLGoodsCode);
                }
            }

            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → CampaignTargetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PartsPosCodeUWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        /// </remarks>
        private CampaignTargetWork CopyToCampaignTargetWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignTargetWork campaignTargetWork = new CampaignTargetWork();

            this.CopyToCampaignTargetWorkFromReader(ref myReader, ref campaignTargetWork);

            return campaignTargetWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → CampaignTargetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="campaignTargetWork">PartsPosCodeUWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 徐佳</br>
        /// <br>Date       : 2011/04/27</br>
        /// </remarks>
        private void CopyToCampaignTargetWorkFromReader(ref SqlDataReader myReader, ref CampaignTargetWork campaignTargetWork)
        {
            if (myReader != null && campaignTargetWork != null)
            {
                # region クラスへ格納
                campaignTargetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                campaignTargetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                campaignTargetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                campaignTargetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                campaignTargetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                campaignTargetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                campaignTargetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                campaignTargetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                campaignTargetWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));
                campaignTargetWork.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF"));
                campaignTargetWork.EmployeeDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYEEDIVCDRF"));
                campaignTargetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                campaignTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                campaignTargetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                campaignTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                campaignTargetWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                campaignTargetWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                campaignTargetWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                campaignTargetWork.SalesTargetMoney1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY1RF"));
                campaignTargetWork.SalesTargetMoney2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY2RF"));
                campaignTargetWork.SalesTargetMoney3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY3RF"));
                campaignTargetWork.SalesTargetMoney4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY4RF"));
                campaignTargetWork.SalesTargetMoney5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY5RF"));
                campaignTargetWork.SalesTargetMoney6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY6RF"));
                campaignTargetWork.SalesTargetMoney7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY7RF"));
                campaignTargetWork.SalesTargetMoney8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY8RF"));
                campaignTargetWork.SalesTargetMoney9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY9RF"));
                campaignTargetWork.SalesTargetMoney10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY10RF"));
                campaignTargetWork.SalesTargetMoney11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY11RF"));
                campaignTargetWork.SalesTargetMoney12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY12RF"));
                campaignTargetWork.MonthlySalesTarget = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETRF"));
                campaignTargetWork.TermSalesTarget = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTARGETRF"));
                campaignTargetWork.SalesTargetProfit1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT1RF"));
                campaignTargetWork.SalesTargetProfit2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT2RF"));
                campaignTargetWork.SalesTargetProfit3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT3RF"));
                campaignTargetWork.SalesTargetProfit4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT4RF"));
                campaignTargetWork.SalesTargetProfit5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT5RF"));
                campaignTargetWork.SalesTargetProfit6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT6RF"));
                campaignTargetWork.SalesTargetProfit7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT7RF"));
                campaignTargetWork.SalesTargetProfit8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT8RF"));
                campaignTargetWork.SalesTargetProfit9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT9RF"));
                campaignTargetWork.SalesTargetProfit10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT10RF"));
                campaignTargetWork.SalesTargetProfit11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT11RF"));
                campaignTargetWork.SalesTargetProfit12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT12RF"));
                campaignTargetWork.MonthlySalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETPROFITRF"));
                campaignTargetWork.TermSalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTARGETPROFITRF"));
                campaignTargetWork.SalesTargetCount1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT1RF"));
                campaignTargetWork.SalesTargetCount2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT2RF"));
                campaignTargetWork.SalesTargetCount3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT3RF"));
                campaignTargetWork.SalesTargetCount4 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT4RF"));
                campaignTargetWork.SalesTargetCount5 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT5RF"));
                campaignTargetWork.SalesTargetCount6 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT6RF"));
                campaignTargetWork.SalesTargetCount7 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT7RF"));
                campaignTargetWork.SalesTargetCount8 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT8RF"));
                campaignTargetWork.SalesTargetCount9 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT9RF"));
                campaignTargetWork.SalesTargetCount10 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT10RF"));
                campaignTargetWork.SalesTargetCount11 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT11RF"));
                campaignTargetWork.SalesTargetCount12 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT12RF"));
                campaignTargetWork.MonthlySalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETCOUNTRF"));
                campaignTargetWork.TermSalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TERMSALESTARGETCOUNTRF"));
                # endregion
            }
        }
        # endregion
    }
}


//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 検品対象取得リモートオブジェクト
// プログラム概要   : 検品対象取得を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 朱宝軍
// 作 成 日  2017/06/12  修正内容 : 新規作成
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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 検品対象取得リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品対象取得リモートオブジェクトです。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2017/06/12</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class HandyInspectDB : RemoteDB, IHandyInspectDB
    {
        #region [コンストラクタ]
        /// <summary>
        /// 検品対象取得リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public HandyInspectDB()
        {
        }
        #endregion

        #region [Public Methods]
        /// <summary>
        /// 検品対象(伝票番号)取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品対象(伝票番号)情報を検索します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public int SearchSlipNum(byte[] condByte, out object retListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            retListObj = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // sqlConnectionがnullの場合
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                HandyInspectCondWork condWork = (HandyInspectCondWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyInspectCondWork));
                // condWorkがnullの場合
                if (condWork == null)
                {
                    base.WriteErrorLog("HandyInspectDB.SearchSlipNum" + "カスタムシリアライザ失敗");
                    return status;
                } 

                // 取寄検品区分を取得
                int orderInspectCode = 0;
                status = SearchOrderInspectCode(condWork, out orderInspectCode, ref sqlConnection);
                // ステータスが正常ではない場合
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }

                // 出荷データ計上残区分を取得
                int shipmAddUpRemDiv = -1;
                status = SearchShipmAddUpRemDiv(condWork, out shipmAddUpRemDiv, ref sqlConnection);
                // ステータスが正常ではない場合
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    return status;
                }

                ArrayList handyInspectWorkList = null;
                status = SearchProc(condWork, orderInspectCode, shipmAddUpRemDiv, out handyInspectWorkList, ref sqlConnection);
                // ステータスが正常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retListObj = handyInspectWorkList as object;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInspectDB.SearchSlipNum" + ex.Message, status);
            }
            finally
            {
                // sqlConnectionがnullではない場合
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 検品対象(一括検品)取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品対象(一括検品)情報を検索します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public int SearchTotal(byte[] condByte, out object retListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            retListObj = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // sqlConnectionがnullの場合
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                HandyInspectCondWork condWork = (HandyInspectCondWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyInspectCondWork));
                // condWorkがnullの場合
                if (condWork == null)
                {
                    base.WriteErrorLog("HandyInspectDB.SearchTotal" + "カスタムシリアライザ失敗");
                    return status;
                } 

                ArrayList handyInspectWorkList = null;
                // 検品対象(一括検品)の場合、検品全体設定マスタ.取寄検品区分が「0：しない」を固定でセットする。
                // 検品対象(一括検品)の場合、売上全体設定マスタ.出荷データ計上残区分が使用しない、「0:残す」を固定でセットする。
                status = SearchProc(condWork, 0, 0, out handyInspectWorkList, ref sqlConnection);
                // ステータスが正常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retListObj = handyInspectWorkList as object;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInspectDB.SearchTotal" + ex.Message, status);
            }
            finally
            {
                // sqlConnectionがnullではない場合
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Private Methods]
        /// <summary>
        /// 指定された条件の取寄検品区分を戻します
        /// </summary>
        /// <param name="condWork">検索条件</param>
        /// <param name="orderInspectCode">取寄検品区分</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の取寄検品区分を戻します</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int SearchOrderInspectCode(HandyInspectCondWork condWork, out int orderInspectCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            orderInspectCode = -1;

            try
            {
                // SQL文を生成
                StringBuilder sb = new StringBuilder();

                # region SELECT句生成
                sb.AppendLine("SELECT TOP 1 A.ORDERINSPECTCODERF FROM (");
                sb.AppendLine("SELECT");
                sb.AppendLine(" I.ORDERINSPECTCODERF,");
                sb.AppendLine(" 0 ORDERRF ");
                sb.AppendLine("FROM");
                sb.AppendLine(" EMPLOYEERF E WITH (READUNCOMMITTED)");
                sb.AppendLine(" INNER JOIN INSPECTTTLSTRF I WITH (READUNCOMMITTED) ");
                sb.AppendLine("ON");
                sb.AppendLine(" E.ENTERPRISECODERF = I.ENTERPRISECODERF");
                sb.AppendLine(" AND E.LOGICALDELETECODERF = I.LOGICALDELETECODERF");
                sb.AppendLine(" AND E.BELONGSECTIONCODERF = I.SECTIONCODERF ");
                sb.AppendLine("WHERE");
                sb.AppendLine(" E.ENTERPRISECODERF = @FINDENTERPRISECODE");
                sb.AppendLine(" AND E.LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                sb.AppendLine(" AND E.EMPLOYEECODERF = @FINDEMPLOYEECODE ");
                sb.AppendLine("UNION SELECT");
                sb.AppendLine(" ORDERINSPECTCODERF,");
                sb.AppendLine(" 1 ORDERRF ");
                sb.AppendLine("FROM");
                sb.AppendLine(" INSPECTTTLSTRF WITH (READUNCOMMITTED) ");
                sb.AppendLine("WHERE");
                sb.AppendLine(" ENTERPRISECODERF = @FINDENTERPRISECODE");
                sb.AppendLine(" AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                sb.AppendLine(" AND SECTIONCODERF = @FINDSECTIONCODE) A ");
                sb.AppendLine("ORDER BY A.ORDERRF");
                # endregion

                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                #region パラメータ設定
                // 企業コード
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                // 論理削除区分
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 従業員コード
                SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                findEmployeeCode.Value = SqlDataMediator.SqlSetString(condWork.EmployeeCode);
                // 拠点コード
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString("00");
                #endregion

                myReader = sqlCommand.ExecuteReader();

                // データが存在する場合
                while (myReader.Read())
                {
                    orderInspectCode = SqlDataMediator.SqlGetInt32(myReader, 0);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInspectDB.SearchOrderInspectCode" + ex.Message, status);
            }
            finally
            {
                // myReaderがnullではない場合
                if (myReader != null)
                {
                    // myReaderが閉じていない場合、
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                // sqlCommandがnullではない場合
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された条件の出荷データ計上残区分を戻します
        /// </summary>
        /// <param name="condWork">検索条件</param>
        /// <param name="shipmAddUpRemDiv">出荷データ計上残区分</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の出荷データ計上残区分を戻します</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int SearchShipmAddUpRemDiv(HandyInspectCondWork condWork, out int shipmAddUpRemDiv, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            shipmAddUpRemDiv = -1;
            // 処理区分が「1,3」の場合
            if (condWork.ProcDiv == 1 || condWork.ProcDiv == 3)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                return status;
            }

            try
            {
                // SQL文を生成
                StringBuilder sb = new StringBuilder();

                # region SELECT句生成
                sb.AppendLine("SELECT TOP 1 A.SHIPMADDUPREMDIVRF FROM (");
                sb.AppendLine("SELECT");
                sb.AppendLine(" S.SHIPMADDUPREMDIVRF,");
                sb.AppendLine(" 0 ORDERRF ");
                sb.AppendLine("FROM");
                sb.AppendLine(" EMPLOYEERF E WITH (READUNCOMMITTED)");
                sb.AppendLine(" INNER JOIN SALESTTLSTRF S WITH (READUNCOMMITTED) ");
                sb.AppendLine("ON");
                sb.AppendLine(" E.ENTERPRISECODERF = S.ENTERPRISECODERF");
                sb.AppendLine(" AND E.LOGICALDELETECODERF = S.LOGICALDELETECODERF");
                sb.AppendLine(" AND E.BELONGSECTIONCODERF = S.SECTIONCODERF ");
                sb.AppendLine("WHERE");
                sb.AppendLine(" E.ENTERPRISECODERF = @FINDENTERPRISECODE");
                sb.AppendLine(" AND E.LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                sb.AppendLine(" AND E.EMPLOYEECODERF = @FINDEMPLOYEECODE ");
                sb.AppendLine("UNION SELECT");
                sb.AppendLine(" SHIPMADDUPREMDIVRF,");
                sb.AppendLine(" 1 ORDERRF ");
                sb.AppendLine("FROM");
                sb.AppendLine(" SALESTTLSTRF WITH (READUNCOMMITTED) ");
                sb.AppendLine("WHERE");
                sb.AppendLine(" ENTERPRISECODERF = @FINDENTERPRISECODE");
                sb.AppendLine(" AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                sb.AppendLine(" AND SECTIONCODERF = @FINDSECTIONCODE) A ");
                sb.AppendLine("ORDER BY A.ORDERRF");
                # endregion

                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                #region パラメータ設定
                // 企業コード
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                // 論理削除区分
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 従業員コード
                SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                findEmployeeCode.Value = SqlDataMediator.SqlSetString(condWork.EmployeeCode);
                // 拠点コード
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString("00");
                #endregion

                myReader = sqlCommand.ExecuteReader();

                // データが存在する場合
                while (myReader.Read())
                {
                    shipmAddUpRemDiv = SqlDataMediator.SqlGetInt32(myReader, 0);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInspectDB.SearchShipmAddUpRemDiv" + ex.Message, status);
            }
            finally
            {
                // myReaderがnullではない場合
                if (myReader != null)
                {
                    // myReaderが閉じていない場合、
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                // sqlCommandがnullではない場合
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された条件の検品対象情報LISTを戻します
        /// </summary>
        /// <param name="condWork">検索条件</param>
        /// <param name="orderInspectCode">取寄検品区分</param>
        /// <param name="shipmAddUpRemDiv">出荷データ計上残区分</param>
        /// <param name="handyInspectWorkList">検索結果</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の検品対象情報LISTを戻します</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int SearchProc(HandyInspectCondWork condWork, int orderInspectCode, int shipmAddUpRemDiv, out ArrayList handyInspectWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            handyInspectWorkList = null;

            try
            {
                #region SQL文を生成
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SELECT");
                sb.AppendLine(" A.CUSTOMERSNMRF,");
                sb.AppendLine(" A.SALESSLIPNUMRF,");
                sb.AppendLine(" A.SALESROWNORF,");
                sb.AppendLine(" A.GOODSMAKERCDRF,");
                sb.AppendLine(" A.GOODSNORF,");
                sb.AppendLine(" A.GOODSNAMEKANARF,");
                sb.AppendLine(" A.SHIPMENTCNTRF,");
                sb.AppendLine(" A.WAREHOUSESHELFNORF,");
                sb.AppendLine(" A.WAREHOUSECODERF,");
                sb.AppendLine(" A.SALESORDERDIVCDRF,");
                sb.AppendLine(" G.GOODSBARCODERF,");
                sb.AppendLine(" I.INSPECTSTATUSRF,");
                sb.AppendLine(" I.INSPECTCODERF,");
                sb.AppendLine(" I.INSPECTCNTRF ");
                sb.AppendLine("FROM (SELECT");
                sb.AppendLine(" S.ENTERPRISECODERF,");
                sb.AppendLine(" S.LOGICALDELETECODERF,");
                sb.AppendLine(" S.SALESSLIPNUMRF,");
                sb.AppendLine(" S.ACPTANODRSTATUSRF,");
                sb.AppendLine(" S.CUSTOMERSNMRF,");
                sb.AppendLine(" D.SALESROWNORF,");
                sb.AppendLine(" D.GOODSMAKERCDRF,");
                sb.AppendLine(" D.GOODSNORF,");
                sb.AppendLine(" D.GOODSNAMEKANARF,");
                // 処理区分が「1,2」の場合
                if (condWork.ProcDiv == 1 || condWork.ProcDiv == 2)
                {
                    sb.AppendLine(" D.SHIPMENTCNTRF,");
                }
                // 処理区分が「3」の場合
                else if (condWork.ProcDiv == 3)
                {
                    sb.AppendLine(" D.SHIPMENTCNTRF * -1 SHIPMENTCNTRF,");
                }
                // 処理区分が「4」の場合
                else
                {
                    sb.AppendLine(" D.SHIPMENTCNTRF * -1 SHIPMENTCNTRF,");
                }
                sb.AppendLine(" D.WAREHOUSESHELFNORF,");
                sb.AppendLine(" D.SALESORDERDIVCDRF,");
                sb.AppendLine(" CASE WHEN (D.SALESORDERDIVCDRF = 0) THEN '0'");
                sb.AppendLine(" ELSE D.WAREHOUSECODERF END WAREHOUSECODERF ");
                sb.AppendLine("FROM");
                sb.AppendLine(" SALESSLIPRF S WITH (READUNCOMMITTED)");
                sb.AppendLine(" INNER JOIN SALESDETAILRF D WITH (READUNCOMMITTED)");
                sb.AppendLine(" ON S.ENTERPRISECODERF = D.ENTERPRISECODERF");
                sb.AppendLine(" AND S.LOGICALDELETECODERF = D.LOGICALDELETECODERF");
                sb.AppendLine(" AND S.ACPTANODRSTATUSRF = D.ACPTANODRSTATUSRF");
                sb.AppendLine(" AND S.SALESSLIPNUMRF = D.SALESSLIPNUMRF ");
                sb.AppendLine("WHERE");
                sb.AppendLine(" S.ENTERPRISECODERF = @FINDENTERPRISECODE");
                sb.AppendLine(" AND S.LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                sb.AppendLine(" AND S.SALESSLIPNUMRF = @FINDSALESSLIPNUM");
                sb.AppendLine(" AND S.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS");
                sb.AppendLine(" AND S.DEBITNOTEDIVRF = @FINDDEBITNOTEDIV");
                sb.AppendLine(" AND D.GOODSMAKERCDRF <> 0");
                sb.AppendLine(" AND D.GOODSNORF IS NOT NULL");
                // 取寄検品区分が「0：しない」の場合
                if (orderInspectCode == 0)
                    sb.AppendLine(" AND D.SALESORDERDIVCDRF = @FINDSALESORDERDIVCD");
                sb.AppendLine(" AND D.SALESSLIPCDDTLRF = @FINDSALESSLIPCDDTL");

                // 処理区分が1の場合
                if (condWork.ProcDiv == 1)
                {
                    sb.AppendLine(" AND D.ACPTANODRSTATUSSRCRF <> @FINDACPTANODRSTATUSSRC");
                    sb.AppendLine(" AND D.SHIPMENTCNTRF > @FINDSHIPMENTCNT");
                }
                // 処理区分が2の場合
                else if (condWork.ProcDiv == 2)
                {
                    sb.AppendLine(" AND D.SHIPMENTCNTRF > @FINDSHIPMENTCNT");
                }
                // 処理区分が3の場合
                else if (condWork.ProcDiv == 3)
                {
                    sb.AppendLine(" AND D.SHIPMENTCNTRF * -1 > @FINDSHIPMENTCNT");
                }
                // 処理区分が4の場合
                else
                {
                    // 貸出残区分が「0:残す」の場合
                    if (shipmAddUpRemDiv == 0)
                        sb.AppendLine(" AND D.SHIPMENTCNTRF * -1 > @FINDSHIPMENTCNT");
                    // 貸出残区分が「1:残さない」の場合
                    else
                    {
                        sb.AppendLine(" AND D.SHIPMENTCNTRF * -1 > @FINDSHIPMENTCNT ");
                        sb.AppendLine("UNION SELECT");
                        sb.AppendLine(" S.ENTERPRISECODERF,");
                        sb.AppendLine(" S.LOGICALDELETECODERF,");
                        sb.AppendLine(" S.SALESSLIPNUMRF,");
                        sb.AppendLine(" S.ACPTANODRSTATUSRF,");
                        sb.AppendLine(" S.CUSTOMERSNMRF,");
                        sb.AppendLine(" D.SALESROWNORF,");
                        sb.AppendLine(" D.GOODSMAKERCDRF,");
                        sb.AppendLine(" D.GOODSNORF,");
                        sb.AppendLine(" D.GOODSNAMEKANARF,");
                        sb.AppendLine(" CASE WHEN (E.SHIPMENTCNTRF IS NOT NULL) THEN (D.SHIPMENTCNTRF - E.SHIPMENTCNTRF)");
                        sb.AppendLine(" ELSE D.SHIPMENTCNTRF END SHIPMENTCNTRF,");
                        sb.AppendLine(" D.WAREHOUSESHELFNORF,");
                        sb.AppendLine(" D.SALESORDERDIVCDRF,");
                        sb.AppendLine(" CASE WHEN (D.SALESORDERDIVCDRF=0) THEN '0'");
                        sb.AppendLine(" ELSE D.WAREHOUSECODERF END WAREHOUSECODERF ");
                        sb.AppendLine("FROM");
                        sb.AppendLine(" SALESSLIPRF S WITH (READUNCOMMITTED)");
                        sb.AppendLine(" INNER JOIN SALESDETAILRF D WITH (READUNCOMMITTED)");
                        sb.AppendLine(" ON S.ENTERPRISECODERF = D.ENTERPRISECODERF");
                        sb.AppendLine(" AND S.LOGICALDELETECODERF = D.LOGICALDELETECODERF");
                        sb.AppendLine(" AND S.ACPTANODRSTATUSRF = D.ACPTANODRSTATUSRF");
                        sb.AppendLine(" AND S.SALESSLIPNUMRF = D.SALESSLIPNUMRF");
                        sb.AppendLine(" LEFT JOIN SALESDETAILRF E WITH (READUNCOMMITTED)");
                        sb.AppendLine(" ON D.ENTERPRISECODERF = E.ENTERPRISECODERF");
                        sb.AppendLine(" AND D.ACPTANODRSTATUSRF = E.ACPTANODRSTATUSSRCRF");
                        sb.AppendLine(" AND D.SALESSLIPDTLNUMRF = E.SALESSLIPDTLNUMSRCRF");
                        sb.AppendLine(" AND E.LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                        sb.AppendLine(" AND E.ACPTANODRSTATUSRF = @FINDRENTACPTANODRSTATUS ");
                        sb.AppendLine("WHERE");
                        sb.AppendLine(" S.ENTERPRISECODERF=@FINDENTERPRISECODE");
                        sb.AppendLine(" AND S.LOGICALDELETECODERF = @FINDRENTLOGICALDELETECODE");
                        sb.AppendLine(" AND S.SALESSLIPNUMRF = @FINDSALESSLIPNUM");
                        sb.AppendLine(" AND S.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS");
                        sb.AppendLine(" AND S.DEBITNOTEDIVRF = @FINDDEBITNOTEDIV");
                        sb.AppendLine(" AND D.GOODSMAKERCDRF <> 0");
                        sb.AppendLine(" AND D.GOODSNORF IS NOT NULL");
                        // 取寄検品区分が「0：しない」の場合
                        if (orderInspectCode == 0)
                            sb.AppendLine(" AND D.SALESORDERDIVCDRF = @FINDSALESORDERDIVCD");
                        sb.AppendLine(" AND D.SALESSLIPCDDTLRF = @FINDRENTSALESSLIPCDDTL");
                        sb.AppendLine(" AND ((E.SHIPMENTCNTRF IS NOT NULL AND D.SHIPMENTCNTRF - E.SHIPMENTCNTRF > 0)");
                        sb.AppendLine(" OR (E.SHIPMENTCNTRF IS NULL AND D.SHIPMENTCNTRF > 0))");
                    }
                }
                sb.AppendLine(") A ");
                sb.AppendLine("LEFT JOIN GOODSBARCODEREVNRF G WITH (READUNCOMMITTED)");
                sb.AppendLine(" ON A.ENTERPRISECODERF = G.ENTERPRISECODERF");
                sb.AppendLine(" AND G.LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                sb.AppendLine(" AND A.GOODSMAKERCDRF = G.GOODSMAKERCDRF");
                sb.AppendLine(" AND A.GOODSNORF = G.GOODSNORF ");
                sb.AppendLine("LEFT JOIN INSPECTDATARF I WITH (READUNCOMMITTED)");
                sb.AppendLine(" ON A.ENTERPRISECODERF = I.ENTERPRISECODERF");
                sb.AppendLine(" AND I.LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                sb.AppendLine(" AND A.SALESSLIPNUMRF = I.ACPAYSLIPNUMRF");
                sb.AppendLine(" AND A.SALESROWNORF = I.ACPAYSLIPROWNORF");
                sb.AppendLine(" AND A.GOODSMAKERCDRF = I.GOODSMAKERCDRF");
                sb.AppendLine(" AND A.GOODSNORF = I.GOODSNORF");
                sb.AppendLine(" AND A.WAREHOUSECODERF = I.WAREHOUSECODERF");
                sb.AppendLine(" AND I.ACPAYSLIPCDRF = @FINDACPAYSLIPCD");
                sb.AppendLine(" AND I.ACPAYTRANSCDRF = @FINDACPAYTRANSCD");
                sb.AppendLine("ORDER BY");
                sb.AppendLine(" A.ACPTANODRSTATUSRF,");
                sb.AppendLine(" A.SALESSLIPNUMRF,");
                sb.AppendLine(" A.SALESROWNORF");
                #endregion

                #region パラメータ設定
                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                this.SetSqlCommand(condWork, orderInspectCode, ref sqlCommand);

                // 論理削除区分
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                // 受注ステータス
                SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                // 売上伝票区分（明細）
                SqlParameter findSalesSlipCdDtl = sqlCommand.Parameters.Add("@FINDSALESSLIPCDDTL", SqlDbType.Int);
                // 受払元伝票区分
                SqlParameter findAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCD", SqlDbType.Int);
                // 受払元取引区分
                SqlParameter findAcPayTransCd = sqlCommand.Parameters.Add("@FINDACPAYTRANSCD", SqlDbType.Int);

                switch (condWork.ProcDiv)
                {
                    case 1:

                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);   // 論理削除区分
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(30);    // 受注ステータス
                        findSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(0);      // 売上伝票区分（明細）
                        findAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(20);        // 受払元伝票区分
                        findAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(10);       // 受払元取引区分
                        // 受注ステータス（元）
                        SqlParameter findAcptAnOdrStatusSrc = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUSSRC", SqlDbType.Int);
                        findAcptAnOdrStatusSrc.Value = SqlDataMediator.SqlSetInt32(40);

                        break;

                    case 2:

                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);   // 論理削除区分
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(40);    // 受注ステータス
                        findSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(0);      // 売上伝票区分（明細）
                        findAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(22);        // 受払元伝票区分
                        findAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(10);       // 受払元取引区分

                        break;

                    case 3:

                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);   // 論理削除区分
                        findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(30);    // 受注ステータス
                        findSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(1);      // 売上伝票区分（明細）
                        findAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(20);        // 受払元伝票区分
                        findAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(11);       // 受払元取引区分

                        break;

                    case 4:

                        // 貸出残区分が「0:残す」の場合
                        if (shipmAddUpRemDiv == 0)
                        {
                            findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);   // 論理削除区分
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(40);    // 受注ステータス
                            findSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(1);      // 売上伝票区分（明細）
                            findAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(22);        // 受払元伝票区分
                            findAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(11);       // 受払元取引区分
                        }
                        // 貸出残区分が「1:残さない」の場合
                        else
                        {
                            findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);   // 論理削除区分
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(40);    // 受注ステータス
                            findSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(1);      // 売上伝票区分（明細）
                            findAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(22);        // 受払元伝票区分
                            findAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(11);       // 受払元取引区分

                            // 論理削除区分
                            SqlParameter findRentLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDRENTLOGICALDELETECODE", SqlDbType.Int);
                            findRentLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(1);
                            // 受注ステータス
                            SqlParameter findRentAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDRENTACPTANODRSTATUS", SqlDbType.Int);
                            findRentAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(30);
                            // 売上伝票区分（明細）
                            SqlParameter findRentSalesSlipCdDtl = sqlCommand.Parameters.Add("@FINDRENTSALESSLIPCDDTL", SqlDbType.Int);
                            findRentSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(0);
                        }
                        break;

                }
                #endregion

                myReader = sqlCommand.ExecuteReader();

                int[] indexs = new int[14];
                // データが存在する場合
                if (myReader.HasRows)
                {
                    int i = -1;
                    indexs[++i] = myReader.GetOrdinal("CUSTOMERSNMRF");
                    indexs[++i] = myReader.GetOrdinal("SALESSLIPNUMRF");
                    indexs[++i] = myReader.GetOrdinal("SALESROWNORF");
                    indexs[++i] = myReader.GetOrdinal("GOODSMAKERCDRF");
                    indexs[++i] = myReader.GetOrdinal("GOODSNORF");
                    indexs[++i] = myReader.GetOrdinal("GOODSNAMEKANARF");
                    indexs[++i] = myReader.GetOrdinal("SHIPMENTCNTRF");
                    indexs[++i] = myReader.GetOrdinal("WAREHOUSESHELFNORF");
                    indexs[++i] = myReader.GetOrdinal("WAREHOUSECODERF");
                    indexs[++i] = myReader.GetOrdinal("SALESORDERDIVCDRF");
                    indexs[++i] = myReader.GetOrdinal("GOODSBARCODERF");
                    indexs[++i] = myReader.GetOrdinal("INSPECTSTATUSRF");
                    indexs[++i] = myReader.GetOrdinal("INSPECTCODERF");
                    indexs[++i] = myReader.GetOrdinal("INSPECTCNTRF");

                    handyInspectWorkList = new ArrayList();
                }

                while (myReader.Read())
                {
                    handyInspectWorkList.Add(CopyToHandyLoginInfoWorkFromReader(indexs, ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInspectDB.SearchProc" + ex.Message, status);
            }
            finally
            {
                // myReaderがnullではない場合
                if (myReader != null)
                {
                    // myReaderが閉じていない場合、
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                // sqlCommandがnullではない場合
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        private void SetSqlCommand(HandyInspectCondWork condWork, int orderInspectCode, ref SqlCommand sqlCommand)
        {
            // 企業コード
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
            // 伝票番号
            SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
            findSalesSlipNum.Value = SqlDataMediator.SqlSetString(condWork.SlipNum);
            // 赤伝区分
            SqlParameter findDebitNoteDiv = sqlCommand.Parameters.Add("@FINDDEBITNOTEDIV", SqlDbType.Int);
            findDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(0);
            // 取寄検品区分が「0：しない」の場合
            if (orderInspectCode == 0)
            {
                // 売上在庫取寄せ区分
                SqlParameter findSalesOrderDivDd = sqlCommand.Parameters.Add("@FINDSALESORDERDIVCD", SqlDbType.Int);
                findSalesOrderDivDd.Value = SqlDataMediator.SqlSetInt32(1);
            }
            // 出荷数
            SqlParameter findShipmentCnt = sqlCommand.Parameters.Add("@FINDSHIPMENTCNT", SqlDbType.Float);
            findShipmentCnt.Value = SqlDataMediator.SqlSetDouble(0);
        }

        /// <summary>
        /// クラス格納処理 Reader → HandyInspectWork
        /// </summary>
        /// <param name="indexs">列の序数配列</param>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>HandyInspectWork</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理を行います。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private HandyInspectWork CopyToHandyLoginInfoWorkFromReader(int[] indexs, ref SqlDataReader myReader)
        {
            HandyInspectWork handyInspectWork = new HandyInspectWork();

            #region クラスへ格納
            int i = -1;
            handyInspectWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyInspectWork.SlipNum = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyInspectWork.RowNo = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyInspectWork.MakerCd = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyInspectWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyInspectWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyInspectWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, indexs[++i]);
            handyInspectWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyInspectWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyInspectWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyInspectWork.GoodsBarCode = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyInspectWork.InspectStatus = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyInspectWork.InspectCode = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyInspectWork.InspectCnt = SqlDataMediator.SqlGetDouble(myReader, indexs[++i]);
            #endregion

            return handyInspectWork;
        }

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Note       : SqlConnectionを生成します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            // connectionTextが存在しない場合
            if (String.IsNullOrEmpty(connectionText))
            {
                base.WriteErrorLog("HandyInspectDB.CreateSqlConnection" + "コネクション取得失敗");
                return null;
            } 

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}

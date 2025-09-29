//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン目標設定マスタ（印刷）
// プログラム概要   : キャンペーン目標設定マスタで設定した内容を一覧出力し
//                    確認する
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// キャンペーン目標設定マスタ印刷DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン目標設定マスタ印刷の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 楊明俊</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class CampTrgtPrintResultDB : RemoteDB, ICampTrgtPrintResultDB
    {
        /// <summary>
        /// キャンペーン目標設定マスタ印刷DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note:</br>
        /// </remarks>
        public CampTrgtPrintResultDB()
            :
            base("PMKHN08717D", "Broadleaf.Application.Remoting.ParamData.CampTrgtPrintResultWork", "CAMPAIGNTARGETRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件のキャンペーン目標設定マスタ印刷データを戻します
        /// </summary>
        /// <param name="campTrgtPrintResultWork">検索結果</param>
        /// <param name="campTrgtPrintParamWork">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のキャンペーン目標設定マスタ印刷データを戻します</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note:</br>
        /// </remarks>
        public int Search(out object campTrgtPrintResultWork, object campTrgtPrintParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            campTrgtPrintResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchCampTrgtListData(out campTrgtPrintResultWork, campTrgtPrintParamWork, ref sqlConnection, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampTrgtPrintResultDB.Search");
                campTrgtPrintResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件のキャンペーン目標設定マスタ印刷データを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objCampTrgtPrintResultWork">検索結果</param>
        /// <param name="objCampTrgtPrintParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のキャンペーン目標設定マスタ印刷データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note:</br>
        /// </remarks>
        private int SearchCampTrgtListData(out object objCampTrgtPrintResultWork, object objCampTrgtPrintParamWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            objCampTrgtPrintResultWork = null;

            if (objCampTrgtPrintParamWork == null)
            {
                return status;
            }

            ArrayList al = new ArrayList();

            CampTrgtPrintParamWork CndtnWork = objCampTrgtPrintParamWork as CampTrgtPrintParamWork;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = MakeSelectString(ref sqlCommand, CndtnWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(this.CopyToCampTrgtRsltListResultWork(ref myReader, CndtnWork));

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
                base.WriteErrorLog(ex, "CampTrgtPrintResultDB.SearchCampTargetDataProc");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            objCampTrgtPrintResultWork = al;

            return status;

        }

        /// <summary>
        /// SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>SELECT文</returns>
        /// <br>Note       : SELECT文を作成して戻します</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note:</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, CampTrgtPrintParamWork CndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";

            #region [Select文作成]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += " CAMP.UPDATEDATETIMERF" + Environment.NewLine;
            selectTxt += " ,CAMP.CAMPAIGNCODERF" + Environment.NewLine;  
            selectTxt += " ,CAMP.SECTIONCODERF" + Environment.NewLine;
            selectTxt += " ,CAMP.EMPLOYEEDIVCDRF" + Environment.NewLine;
            selectTxt += " ,CAMP.EMPLOYEECODERF" + Environment.NewLine;
            selectTxt += " ,CAMP.CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESAREACODERF" + Environment.NewLine;
            selectTxt += " ,CAMP.BLGROUPCODERF" + Environment.NewLine;
            selectTxt += " ,CAMP.BLGOODSCODERF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESCODERF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETMONEY1RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETMONEY2RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETMONEY3RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETMONEY4RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETMONEY5RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETMONEY6RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETMONEY7RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETMONEY8RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETMONEY9RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETMONEY10RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETMONEY11RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETMONEY12RF" + Environment.NewLine;
            selectTxt += " ,CAMP.MONTHLYSALESTARGETRF" + Environment.NewLine;
            selectTxt += " ,CAMP.TERMSALESTARGETRF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETPROFIT1RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETPROFIT2RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETPROFIT3RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETPROFIT4RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETPROFIT5RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETPROFIT6RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETPROFIT7RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETPROFIT8RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETPROFIT9RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETPROFIT10RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETPROFIT11RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETPROFIT12RF" + Environment.NewLine;
            selectTxt += " ,CAMP.MONTHLYSALESTARGETPROFITRF" + Environment.NewLine;
            selectTxt += " ,CAMP.TERMSALESTARGETPROFITRF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETCOUNT1RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETCOUNT2RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETCOUNT3RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETCOUNT4RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETCOUNT5RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETCOUNT6RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETCOUNT7RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETCOUNT8RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETCOUNT9RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETCOUNT10RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETCOUNT11RF" + Environment.NewLine;
            selectTxt += " ,CAMP.SALESTARGETCOUNT12RF" + Environment.NewLine;
            selectTxt += " ,CAMP.MONTHLYSALESTARGETCOUNTRF" + Environment.NewLine;
            selectTxt += " ,CAMP.TERMSALESTARGETCOUNTRF" + Environment.NewLine;
            selectTxt += " ,CAMPST.CAMPAIGNNAMERF" + Environment.NewLine; // キャンペーン名称
            selectTxt += " ,CAMPST.APPLYSTADATERF" + Environment.NewLine; // 適用開始日
            selectTxt += " ,CAMPST.APPLYENDDATERF" + Environment.NewLine; // 適用終了日
            selectTxt += " ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine; // 拠点ガイド略称
            if (CndtnWork.PrintType == 22)
            {
                selectTxt += " ,EMPLOYEE.NAMERF" + Environment.NewLine; // 従業員名称
            }
            else if (CndtnWork.PrintType == 30)
            {
                selectTxt += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine; // 意先略称
            }
            else if (CndtnWork.PrintType == 32 || CndtnWork.PrintType == 44)
            {
                selectTxt += " ,USERGD.GUIDENAMERF" + Environment.NewLine; // ガイド名称
            }
            else if (CndtnWork.PrintType == 50)
            {
                selectTxt += " ,BLGROUP.BLGROUPKANANAMERF" + Environment.NewLine; // BLグループコードカナ名称
            }
            else if (CndtnWork.PrintType == 60)
            {
                selectTxt += " ,BL.BLGOODSHALFNAMERF" + Environment.NewLine; // BL商品コード名称（半角）
            }
            selectTxt += " FROM CAMPAIGNTARGETRF AS CAMP" + Environment.NewLine;
            #endregion

            #region [LEFT JION文作成]
            //キャンペーン設定マスタ
            selectTxt += " LEFT JOIN CAMPAIGNSTRF AS CAMPST" + Environment.NewLine;
            selectTxt += " ON CAMPST.ENTERPRISECODERF = CAMP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND CAMPST.CAMPAIGNCODERF = CAMP.CAMPAIGNCODERF" + Environment.NewLine;
            selectTxt += " AND CAMPST.LOGICALDELETECODERF = 0" + Environment.NewLine;

            //キャンペーン設定マスタ
            selectTxt += " LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
            selectTxt += " ON SEC.ENTERPRISECODERF = CAMP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND SEC.SECTIONCODERF = CAMP.SECTIONCODERF" + Environment.NewLine;
            selectTxt += " AND SEC.LOGICALDELETECODERF = 0" + Environment.NewLine;

            if (CndtnWork.PrintType == 22)
            {
                //22:拠点+従業員
                //従業員マスタ
                selectTxt += " LEFT JOIN EMPLOYEERF AS EMPLOYEE" + Environment.NewLine;
                selectTxt += " ON EMPLOYEE.ENTERPRISECODERF = CAMP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND EMPLOYEE.EMPLOYEECODERF = CAMP.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += " AND EMPLOYEE.LOGICALDELETECODERF = 0" + Environment.NewLine;
            }
            else if (CndtnWork.PrintType == 30)
            {
                //30:拠点+得意先
                //得意先マスタ
                selectTxt += " LEFT JOIN CUSTOMERRF AS CUST" + Environment.NewLine;
                selectTxt += " ON CUST.ENTERPRISECODERF = CAMP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUST.CUSTOMERCODERF = CAMP.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " AND CUST.LOGICALDELETECODERF = 0" + Environment.NewLine;
            }
            else if (CndtnWork.PrintType == 32)
            {
                //32:拠点+販売ｴﾘｱ
                //ユーザーガイドマスタ
                selectTxt += " LEFT JOIN USERGDBDURF AS USERGD" + Environment.NewLine;
                selectTxt += " ON USERGD.ENTERPRISECODERF = CAMP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND USERGD.GUIDECODERF = CAMP.SALESAREACODERF" + Environment.NewLine;
                selectTxt += " AND USERGD.LOGICALDELETECODERF = 0" + Environment.NewLine;
                selectTxt += " AND USERGD.USERGUIDEDIVCDRF = 21" + Environment.NewLine;
            }
            else if (CndtnWork.PrintType == 44)
            {
                //44:拠点+販売区分
                //ユーザーガイドマスタ
                selectTxt += " LEFT JOIN USERGDBDURF AS USERGD" + Environment.NewLine;
                selectTxt += " ON USERGD.ENTERPRISECODERF = CAMP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND USERGD.GUIDECODERF = CAMP.SALESCODERF" + Environment.NewLine;
                selectTxt += " AND USERGD.LOGICALDELETECODERF = 0" + Environment.NewLine;
                selectTxt += " AND USERGD.USERGUIDEDIVCDRF = 71" + Environment.NewLine;
            }
            else if (CndtnWork.PrintType == 50)
            {
                //50:拠点+ｸﾞﾙｰﾌﾟｺｰﾄ
                //BLグループマスタ
                selectTxt += " LEFT JOIN BLGROUPURF AS BLGROUP" + Environment.NewLine;
                selectTxt += " ON BLGROUP.ENTERPRISECODERF = CAMP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGROUP.BLGROUPCODERF = CAMP.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += " AND BLGROUP.LOGICALDELETECODERF = 0" + Environment.NewLine;
            }
            else if (CndtnWork.PrintType == 60)
            {
                //60:拠点+BLｺｰﾄﾞ
                //ＢＬ商品コードマスタ(
                selectTxt += " LEFT JOIN BLGOODSCDURF AS BL" + Environment.NewLine;
                selectTxt += " ON BL.ENTERPRISECODERF = CAMP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BL.BLGOODSCODERF = CAMP.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " AND BL.LOGICALDELETECODERF = 0" + Environment.NewLine;
            }
            #endregion

            #region [WHERE文作成]
            //WHERE句
            selectTxt += MakeWhereString(ref sqlCommand, CndtnWork, logicalMode);
            #endregion

            #region [ORDER BY 文作成]
            selectTxt += " ORDER BY CAMP.CAMPAIGNCODERF, CAMP.SECTIONCODERF" + Environment.NewLine;
            if (CndtnWork.PrintType == 22)
            {
                selectTxt += " ,CAMP.EMPLOYEECODERF" + Environment.NewLine;
            }
            else if (CndtnWork.PrintType == 30)
            {
                //30:拠点+得意先
                selectTxt += " ,CAMP.CUSTOMERCODERF" + Environment.NewLine;
            }
            else if (CndtnWork.PrintType == 32)
            {
                //32:拠点+販売ｴﾘｱ
                selectTxt += " ,CAMP.SALESAREACODERF" + Environment.NewLine;
            }
            else if (CndtnWork.PrintType == 44)
            {
                //44:拠点+販売区分
                selectTxt += " ,CAMP.SALESCODERF" + Environment.NewLine;
            }
            else if (CndtnWork.PrintType == 50)
            {
                //50:拠点+ｸﾞﾙｰﾌﾟｺｰﾄ
                selectTxt += " ,CAMP.BLGROUPCODERF" + Environment.NewLine;
            }
            else if (CndtnWork.PrintType == 60)
            {
                //60:拠点+BLｺｰﾄﾞ
                selectTxt += " ,CAMP.BLGOODSCODERF" + Environment.NewLine;
            }
            #endregion

            return selectTxt;
        }

        /// <summary>
        /// WHERE句 生成処理 (月計用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>WHERE句</returns>
        /// <br>Note       : キャンペーン目標設定マスタ用WHERE句を作成して戻します</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note:</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CampTrgtPrintParamWork CndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;
            #endregion

            //企業コード
            retstring += " CAMP.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND CAMP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND CAMP.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //目標対比区分
            retstring += " AND CAMP.TARGETCONTRASTCDRF=@TARGETCONTRASTCD" + Environment.NewLine;
            SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
            paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintType);

            //従業員区分
            retstring += " AND CAMP.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD" + Environment.NewLine;
            SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
            paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.EmployeeDivCd);

            // キャンペーンコード
            if (CndtnWork.CampaignCodeSt != 0)
            {
                retstring += " AND CAMP.CAMPAIGNCODERF>=@CAMPAIGNCODEST" + Environment.NewLine;
                SqlParameter paraCampaignCodeSt = sqlCommand.Parameters.Add("@CAMPAIGNCODEST", SqlDbType.Int);
                paraCampaignCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCodeSt);
            }
            if (CndtnWork.CampaignCodeEd != 0 && CndtnWork.CampaignCodeEd != 999999)
            {
                retstring += " AND CAMP.CAMPAIGNCODERF<=@CAMPAIGNCODEED" + Environment.NewLine;
                SqlParameter paraCampaignCodeEd = sqlCommand.Parameters.Add("@CAMPAIGNCODEED", SqlDbType.Int);
                paraCampaignCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCodeEd);
            }

            // 拠点
            if (!string.IsNullOrEmpty(CndtnWork.SectionCodeSt))
            {
                retstring += " AND CAMP.SECTIONCODERF>=@SECTIONCODEST" + Environment.NewLine;
                SqlParameter paraSectionCodeSt = sqlCommand.Parameters.Add("@SECTIONCODEST", SqlDbType.NChar);
                paraSectionCodeSt.Value = SqlDataMediator.SqlSetString(CndtnWork.SectionCodeSt);
            }
            if (!string.IsNullOrEmpty(CndtnWork.SectionCodeEd))
            {
                retstring += " AND CAMP.SECTIONCODERF<=@SECTIONCODEED" + Environment.NewLine;
                SqlParameter paraSectionCodeEd = sqlCommand.Parameters.Add("@SECTIONCODEED", SqlDbType.NChar);
                paraSectionCodeEd.Value = SqlDataMediator.SqlSetString(CndtnWork.SectionCodeEd);
            }
            
            //得意先
            if (CndtnWork.CustomerCodeSt != 0)
            {
                retstring += " AND CAMP.CUSTOMERCODERF>=@CUSTOMERCODEST" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CustomerCodeSt);
            }
            if (CndtnWork.CustomerCodeEd != 0 && CndtnWork.CustomerCodeEd != 99999999)
            {
                retstring += " AND CAMP.CUSTOMERCODERF<=@CUSTOMERCODEED" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CustomerCodeEd);
            }

            //従業員
            if (!string.IsNullOrEmpty(CndtnWork.EmployeeCodeSt))
            {
                retstring += " AND CAMP.EMPLOYEECODERF>=@EMPLOYEECODEST" + Environment.NewLine;
                SqlParameter paraEmployeeCodeSt = sqlCommand.Parameters.Add("@EMPLOYEECODEST", SqlDbType.NChar);
                paraEmployeeCodeSt.Value = SqlDataMediator.SqlSetString(CndtnWork.EmployeeCodeSt);
            }
            if (!string.IsNullOrEmpty(CndtnWork.EmployeeCodeEd))
            {
                retstring += " AND CAMP.EMPLOYEECODERF<=@EMPLOYEECODEED" + Environment.NewLine;
                SqlParameter paraEmployeeCodeEd = sqlCommand.Parameters.Add("@EMPLOYEECODEED", SqlDbType.NChar);
                paraEmployeeCodeEd.Value = SqlDataMediator.SqlSetString(CndtnWork.EmployeeCodeEd);
            }
            
            //地区
            if (CndtnWork.SalesAreaCodeSt != 0)
            {
                retstring += " AND CAMP.SALESAREACODERF>=@SALESAREACODEST" + Environment.NewLine;
                SqlParameter paraSalesAreaCodeSt = sqlCommand.Parameters.Add("@SALESAREACODEST", SqlDbType.Int);
                paraSalesAreaCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SalesAreaCodeSt);
            }
            if (CndtnWork.SalesAreaCodeEd != 0 && CndtnWork.SalesAreaCodeEd != 9999)
            {
                retstring += " AND CAMP.SALESAREACODERF<=@SALESAREACODEED" + Environment.NewLine;
                SqlParameter paraSalesAreaCodeEd = sqlCommand.Parameters.Add("@SALESAREACODEED", SqlDbType.Int);
                paraSalesAreaCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SalesAreaCodeEd);
            }

            //BLグループコード
            if (CndtnWork.BlGroupCodeSt != 0)
            {
                retstring += " AND CAMP.BLGROUPCODERF>=@BLGROUPCODEST" + Environment.NewLine;
                SqlParameter paraBlGroupCodeSt = sqlCommand.Parameters.Add("@BLGROUPCODEST", SqlDbType.Int);
                paraBlGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BlGroupCodeSt);
            }
            if (CndtnWork.BlGroupCodeEd != 0 && CndtnWork.BlGroupCodeEd != 99999)
            {
                retstring += " AND CAMP.BLGROUPCODERF<=@BLGROUPCODEED" + Environment.NewLine;
                SqlParameter paraBlGroupCodeEd = sqlCommand.Parameters.Add("@BLGROUPCODEED", SqlDbType.Int);
                paraBlGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BlGroupCodeEd);
            }

            //BL商品コード
            if (CndtnWork.BlGoodsCdSt != 0)
            {
                retstring += " AND CAMP.BLGOODSCODERF>=@BLGOODSCODEST" + Environment.NewLine;
                SqlParameter paraBlGoodsCdSt = sqlCommand.Parameters.Add("@BLGOODSCODEST", SqlDbType.Int);
                paraBlGoodsCdSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BlGoodsCdSt);
            }
            if (CndtnWork.BlGoodsCdEd != 0 && CndtnWork.BlGoodsCdEd != 99999999)
            {
                retstring += " AND CAMP.BLGOODSCODERF<=@BLGOODSCODEED" + Environment.NewLine;
                SqlParameter paraBlGoodsCdEd = sqlCommand.Parameters.Add("@BLGOODSCODEED", SqlDbType.Int);
                paraBlGoodsCdEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BlGoodsCdEd);
            }

            //販売区分開始
            if (CndtnWork.SalesCodeSt != 0)
            {
                retstring += " AND CAMP.SALESCODERF>=@SALESCODEST" + Environment.NewLine;
                SqlParameter paraSalesCodeSt = sqlCommand.Parameters.Add("@SALESCODEST", SqlDbType.Int);
                paraSalesCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SalesCodeSt);
            }
            if ((CndtnWork.SalesCodeEd != 9999) && (CndtnWork.SalesCodeEd != 0))
            {
                retstring += " AND CAMP.SALESCODERF<=@SALESCODEED" + Environment.NewLine;
                SqlParameter paraSalesCodeEd = sqlCommand.Parameters.Add("@SALESCODEED", SqlDbType.Int);
                paraSalesCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SalesCodeEd);
            }

            return retstring;
        }

        #region [CopyToCampTrgtPrintResultWorkFromReader処理]
                /// <summary>
        /// クラス格納処理 Reader → CopyToCampTrgtRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToCampTrgtRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note:</br>
        /// </remarks>
        private CampTrgtPrintResultWork CopyToCampTrgtRsltListResultWork(ref SqlDataReader myReader, CampTrgtPrintParamWork CndtnWork)
        {
            CampTrgtPrintResultWork ResultWork = new CampTrgtPrintResultWork();
            ResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            ResultWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));
            ResultWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));
            ResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));

            if (CndtnWork.PrintType == 22)
            {
                ResultWork.EmployeeDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYEEDIVCDRF"));
                ResultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                ResultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
            }
            else if (CndtnWork.PrintType == 30)
            {
                ResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                ResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            }
            else if (CndtnWork.PrintType == 32)
            {
                ResultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                ResultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
            }
            else if (CndtnWork.PrintType == 44)
            {
                ResultWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                ResultWork.SalesCodeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
            }
            else if (CndtnWork.PrintType == 50)
            {
                ResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                ResultWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
            }
            else if (CndtnWork.PrintType == 60)
            {
                ResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                ResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            }

            DateTime _startMonth = CndtnWork.StartMonth;

            ResultWork.SalesTargetMoney1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY" + _startMonth.Month+ "RF"));
            ResultWork.SalesTargetMoney2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY" + _startMonth.AddMonths(1).Month + "RF"));
            ResultWork.SalesTargetMoney3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY" + _startMonth.AddMonths(2).Month + "RF"));
            ResultWork.SalesTargetMoney4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY" + _startMonth.AddMonths(3).Month + "RF"));
            ResultWork.SalesTargetMoney5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY" + _startMonth.AddMonths(4).Month + "RF"));
            ResultWork.SalesTargetMoney6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY" + _startMonth.AddMonths(5).Month + "RF"));
            ResultWork.SalesTargetMoney7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY" + _startMonth.AddMonths(6).Month + "RF"));
            ResultWork.SalesTargetMoney8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY" + _startMonth.AddMonths(7).Month + "RF"));
            ResultWork.SalesTargetMoney9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY" + _startMonth.AddMonths(8).Month + "RF"));
            ResultWork.SalesTargetMoney10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY" + _startMonth.AddMonths(9).Month + "RF"));
            ResultWork.SalesTargetMoney11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY" + _startMonth.AddMonths(10).Month + "RF"));
            ResultWork.SalesTargetMoney12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY" + _startMonth.AddMonths(11).Month + "RF"));
            ResultWork.MonthlySalesTarget = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETRF"));
            ResultWork.TermSalesTarget = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTARGETRF"));

            ResultWork.SalesTargetProfit1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT" + _startMonth.Month + "RF"));
            ResultWork.SalesTargetProfit2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT" + _startMonth.AddMonths(1).Month + "RF"));
            ResultWork.SalesTargetProfit3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT" + _startMonth.AddMonths(2).Month + "RF"));
            ResultWork.SalesTargetProfit4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT" + _startMonth.AddMonths(3).Month + "RF"));
            ResultWork.SalesTargetProfit5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT" + _startMonth.AddMonths(4).Month + "RF"));
            ResultWork.SalesTargetProfit6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT" + _startMonth.AddMonths(5).Month + "RF"));
            ResultWork.SalesTargetProfit7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT" + _startMonth.AddMonths(6).Month + "RF"));
            ResultWork.SalesTargetProfit8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT" + _startMonth.AddMonths(7).Month + "RF"));
            ResultWork.SalesTargetProfit9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT" + _startMonth.AddMonths(8).Month + "RF"));
            ResultWork.SalesTargetProfit10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT" + _startMonth.AddMonths(9).Month + "RF"));
            ResultWork.SalesTargetProfit11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT" + _startMonth.AddMonths(10).Month + "RF"));
            ResultWork.SalesTargetProfit12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT" + _startMonth.AddMonths(11).Month + "RF"));
            ResultWork.MonthlySalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETPROFITRF"));
            ResultWork.TermSalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTARGETPROFITRF"));

            ResultWork.SalesTargetCount1 = Int64.Parse(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT" + _startMonth.Month + "RF")).ToString());
            ResultWork.SalesTargetCount2 = Int64.Parse(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT" + _startMonth.AddMonths(1).Month + "RF")).ToString());
            ResultWork.SalesTargetCount3 = Int64.Parse(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT" + _startMonth.AddMonths(2).Month + "RF")).ToString());
            ResultWork.SalesTargetCount4 = Int64.Parse(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT" + _startMonth.AddMonths(3).Month + "RF")).ToString());
            ResultWork.SalesTargetCount5 = Int64.Parse(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT" + _startMonth.AddMonths(4).Month + "RF")).ToString());
            ResultWork.SalesTargetCount6 = Int64.Parse(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT" + _startMonth.AddMonths(5).Month + "RF")).ToString());
            ResultWork.SalesTargetCount7 = Int64.Parse(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT" + _startMonth.AddMonths(6).Month + "RF")).ToString());
            ResultWork.SalesTargetCount8 = Int64.Parse(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT" + _startMonth.AddMonths(7).Month + "RF")).ToString());
            ResultWork.SalesTargetCount9 = Int64.Parse(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT" + _startMonth.AddMonths(8).Month + "RF")).ToString());
            ResultWork.SalesTargetCount10 = Int64.Parse(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT" + _startMonth.AddMonths(9).Month + "RF")).ToString());
            ResultWork.SalesTargetCount11 = Int64.Parse(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT" + _startMonth.AddMonths(10).Month + "RF")).ToString());
            ResultWork.SalesTargetCount12 = Int64.Parse(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT" + _startMonth.AddMonths(11).Month + "RF")).ToString());
            ResultWork.MonthlySalesTargetCount = Int64.Parse(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETCOUNTRF")).ToString());
            ResultWork.TermSalesTargetCount = Int64.Parse(SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TERMSALESTARGETCOUNTRF")).ToString());

            ResultWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
            ResultWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));

            return ResultWork;
        }
        #endregion

        #endregion  //Search

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note:</br>
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
        #endregion  //コネクション生成処理
    }
}

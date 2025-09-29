using System;
using System.Collections;
using System.Collections.Generic;
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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    class MTtlSaSlipEmp : MTtlSaSlipBase, IMTtlSaSlip
    {
        #region [担当者別用 Select文]
        /// <summary>
        /// 担当者別用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>担当者別用SELECT文</returns>
        /// <br>Note       : 担当者別用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalTrgtPrintParamWork CndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            return this.MakeSelectStringProc(ref sqlCommand, CndtnWork, logicalMode);
        }
        #endregion  //[担当者別用 Select文]

        #region [担当者別用 Select文生成処理]
        /// <summary>
        /// 担当者別用SELECT文 生成処理
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <returns>担当者別用SELECT文</returns>
        /// <br>Note       : 担当者別用SELECT文を作成して戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SalTrgtPrintParamWork CndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";
            string Tblnm = "SCINF";

            switch (CndtnWork.PrintType)
            {
                case 10://拠点
                    {
                        Tblnm = "SCINF";
                        break;
                    }
                case 20://拠点+部門
                    {
                        Tblnm = "SBSEC";
                        break;
                    }
                case 22://拠点+従業員
                    {
                        Tblnm = "EMPLY";
                        break;
                    }
            }

            #region [Select文作成]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "   "+Tblnm+".UPDATEDATETIMERF" + Environment.NewLine;
            selectTxt += "  ,ESLST.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "  ,SCINF.SECTIONGUIDESNMRF" + Environment.NewLine;
            selectTxt += "  ,ESLST.SUBSECTIONCODERF" + Environment.NewLine;
            selectTxt += "  ,SBSEC.SUBSECTIONNAMERF" + Environment.NewLine;
            selectTxt += "  ,(CASE WHEN ESLST.EMPLOYEEDIVCDRF=10 THEN ESLST.EMPLOYEECODERF ELSE '' END) AS SALESEMPLOYEECD" + Environment.NewLine;
            selectTxt += "  ,(CASE WHEN ESLST.EMPLOYEEDIVCDRF=10 THEN EMPLY.NAMERF         ELSE '' END) AS SALESEMPLOYEENM" + Environment.NewLine;
            selectTxt += "  ,(CASE WHEN ESLST.EMPLOYEEDIVCDRF=20 THEN ESLST.EMPLOYEECODERF ELSE '' END) AS FRONTEMPLOYEECD" + Environment.NewLine;
            selectTxt += "  ,(CASE WHEN ESLST.EMPLOYEEDIVCDRF=20 THEN EMPLY.NAMERF         ELSE '' END) AS FRONTEMPLOYEENM" + Environment.NewLine;
            selectTxt += "  ,(CASE WHEN ESLST.EMPLOYEEDIVCDRF=30 THEN ESLST.EMPLOYEECODERF ELSE '' END) AS SALESINPUTCODE" + Environment.NewLine;
            selectTxt += "  ,(CASE WHEN ESLST.EMPLOYEEDIVCDRF=30 THEN EMPLY.NAMERF         ELSE '' END) AS SALESINPUTNAME" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETMONEY1" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETMONEY2" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETMONEY3" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETMONEY4" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETMONEY5" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETMONEY6" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETMONEY7" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETMONEY8" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETMONEY9" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETMONEY10" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETMONEY11" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETMONEY12" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETPROFIT1" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETPROFIT2" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETPROFIT3" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETPROFIT4" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETPROFIT5" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETPROFIT6" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETPROFIT7" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETPROFIT8" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETPROFIT9" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETPROFIT10" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETPROFIT11" + Environment.NewLine;
            selectTxt += "  ,ESLST.SALESTARGETPROFIT12" + Environment.NewLine;
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            //従業員別売上目標設定マスタ
            selectTxt += "  SELECT" + Environment.NewLine;
            selectTxt += "    ESLSTSUB.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "   ,ESLSTSUB.UPDATEDATETIMERF" + Environment.NewLine;
            selectTxt += "   ,ESLSTSUB.LOGICALDELETECODERF" + Environment.NewLine;
            selectTxt += "   ,ESLSTSUB.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "   ,ESLSTSUB.SUBSECTIONCODERF" + Environment.NewLine;
            selectTxt += "   ,ESLSTSUB.EMPLOYEEDIVCDRF" + Environment.NewLine;
            selectTxt += "   ,ESLSTSUB.EMPLOYEECODERF" + Environment.NewLine;
            int setDate = CndtnWork.TargetDivideCodeSt;
            for (int i = 1; i <= 12; i++)
            {
                //売上目標金額
                selectTxt += "   ,SUM((CASE WHEN ESLSTSUB.TARGETDIVIDECODERF=" + setDate.ToString() + " THEN ESLSTSUB.SALESTARGETMONEYRF ELSE 0 END)) AS SALESTARGETMONEY" + i.ToString() + Environment.NewLine;
                //売上目標粗利額
                selectTxt += "   ,SUM((CASE WHEN ESLSTSUB.TARGETDIVIDECODERF=" + setDate.ToString() + " THEN ESLSTSUB.SALESTARGETPROFITRF ELSE 0 END)) AS SALESTARGETPROFIT" + i.ToString() + Environment.NewLine;

                if (setDate % 100 >= 12)
                {
                    setDate = (setDate + 100) / 100 * 100 + 1;
                }
                else
                {
                    setDate = setDate + 1;
                }
            }
            selectTxt += "  FROM EMPSALESTARGETRF AS ESLSTSUB" + Environment.NewLine;

            //WHERE句
            selectTxt += MakeWhereString(ref sqlCommand, CndtnWork, "ESLSTSUB", "", logicalMode);

            selectTxt += " GROUP BY" + Environment.NewLine;
            selectTxt += "  ESLSTSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " ,ESLSTSUB.LOGICALDELETECODERF" + Environment.NewLine;
            selectTxt += " ,ESLSTSUB.SECTIONCODERF" + Environment.NewLine;
            selectTxt += " ,ESLSTSUB.SUBSECTIONCODERF" + Environment.NewLine;
            selectTxt += " ,ESLSTSUB.EMPLOYEEDIVCDRF" + Environment.NewLine;
            selectTxt += " ,ESLSTSUB.EMPLOYEECODERF" + Environment.NewLine;


            selectTxt += " ) AS ESLST" + Environment.NewLine;

            #region [JOIN]
            //拠点情報設定マスタ
            selectTxt += " LEFT JOIN SECINFOSETRF SCINF" + Environment.NewLine;
            selectTxt += " ON  SCINF.ENTERPRISECODERF=ESLST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND SCINF.SECTIONCODERF=ESLST.SECTIONCODERF" + Environment.NewLine;

            //従業員マスタ
            selectTxt += " LEFT JOIN EMPLOYEERF EMPLY" + Environment.NewLine;
            selectTxt += " ON  EMPLY.ENTERPRISECODERF=ESLST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND EMPLY.EMPLOYEECODERF=ESLST.EMPLOYEECODERF" + Environment.NewLine;

            //部門マスタ
            selectTxt += " LEFT JOIN SUBSECTIONRF SBSEC" + Environment.NewLine;
            selectTxt += " ON  SBSEC.ENTERPRISECODERF=ESLST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND SBSEC.SUBSECTIONCODERF=ESLST.SUBSECTIONCODERF" + Environment.NewLine;
            #endregion  //[JOIN]
            #endregion  //[Select文作成]

            return selectTxt;
        }
        #endregion  //[得意先別用 Select文生成処理]


        #region [Where句 生成処理]
        /// <summary>
        /// 担当者別用WHERE句 生成処理 (月計用)
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="CndtnWork">検索条件</param>
        /// <param name="sGSMSLP">テーブル名略称：商品別売上月次集計データ</param>
        /// <param name="sBLGCDU">テーブル名略称：BL商品コードマスタ</param>
        /// <param name="sBLGRPU">テーブル名略称：BLグループマスタ</param>
        /// <param name="iRsltTtlDivCd">在庫取寄せ区分</param>
        /// <returns>担当者別用WHERE句</returns>
        /// <br>Note       : 担当者別用WHERE句を作成して戻します</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalTrgtPrintParamWork CndtnWork, string TblNm1, string TblNm2, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = " WHERE" + Environment.NewLine;
            #region [担当者別売上目標設定マスタ]
            //企業コード
            retstring += " " + TblNm1 + ".ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //論理削除区分
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND " + TblNm1 + ".LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND " + TblNm1 + ".LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //拠点コード
            if (CndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in CndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND " + TblNm1 + ".SECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //目標対比区分
            retstring += " AND " + TblNm1 + ".TARGETCONTRASTCDRF=@TARGETCONTRASTCD" + Environment.NewLine;
            SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
            paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintType);

            //目標設定区分　
            retstring += " AND " + TblNm1 + ".TARGETSETCDRF= 10" + Environment.NewLine;

            //従業員区分
            if (CndtnWork.EmployeeDivCd != 0)
            {
                retstring += " AND " + TblNm1 + ".EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD" + Environment.NewLine;
                SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.EmployeeDivCd);
            }

            //対象年月開始
            if (CndtnWork.TargetDivideCodeSt != 0)
            {
                retstring += " AND " + TblNm1 + ".TARGETDIVIDECODERF>=@TARGETDIVIDECODERFST" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeSt = sqlCommand.Parameters.Add("@TARGETDIVIDECODERFST", SqlDbType.NChar);
                paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetString(Convert.ToString(CndtnWork.TargetDivideCodeSt));
            }
            //対象年月終了
            if (CndtnWork.TargetDivideCodeEd != 0)
            {
                retstring += " AND " + TblNm1 + ".TARGETDIVIDECODERF<=@TARGETDIVIDECODERFED" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeEd = sqlCommand.Parameters.Add("@TARGETDIVIDECODERFED", SqlDbType.NChar);
                paraTargetDivideCodeEd.Value = SqlDataMediator.SqlSetString(Convert.ToString(CndtnWork.TargetDivideCodeEd));
            }

            //部門
            if (CndtnWork.SubSectionCodeSt != 0)
            {
                retstring += " AND " + TblNm1 + ".SUBSECTIONCODERF>=@SUBSECTIONCODEST" + Environment.NewLine;
                SqlParameter paraSubSectionCodeSt = sqlCommand.Parameters.Add("@SUBSECTIONCODEST", SqlDbType.Int);
                paraSubSectionCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SubSectionCodeSt);
            }
            if ((CndtnWork.SubSectionCodeEd != 99) && (CndtnWork.SubSectionCodeEd != 0))
            {
                retstring += " AND " + TblNm1 + ".SUBSECTIONCODERF<=@SUBSECTIONCODEED" + Environment.NewLine;
                SqlParameter paraSubSectionCodeEd = sqlCommand.Parameters.Add("@SUBSECTIONCODEED", SqlDbType.Int);
                paraSubSectionCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SubSectionCodeEd);
            }

            //従業員コード開始
            if (CndtnWork.EmployeeCodeSt != "")
            {
                retstring += " AND " + TblNm1 + ".EMPLOYEECODERF>=@EMPLOYEECODEST" + Environment.NewLine;
                SqlParameter paraEmployeeCodeSt = sqlCommand.Parameters.Add("@EMPLOYEECODEST", SqlDbType.Int);
                paraEmployeeCodeSt.Value = SqlDataMediator.SqlSetString(CndtnWork.EmployeeCodeSt);
            }
            if (CndtnWork.EmployeeCodeEd != "")
            {
                retstring += " AND " + TblNm1 + ".EMPLOYEECODERF<=@EMPLOYEECODEED" + Environment.NewLine;
                SqlParameter paraEmployeeCodeEd = sqlCommand.Parameters.Add("@EMPLOYEECODEED", SqlDbType.Int);
                paraEmployeeCodeEd.Value = SqlDataMediator.SqlSetString(CndtnWork.EmployeeCodeEd);
            }
            #endregion  
            #endregion  //WHERE文作成

            return retstring;
        }
        #endregion  //[商品別売上月次集計データ用 Where句 生成処理]

        #region [CopyToSalesRsltListResultWorkFromReader処理 呼出]
        /// <summary>
        /// クラス格納処理 Reader → CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.09.08</br>
        /// </remarks>
        public SalTrgtPrintResultWork CopyToSalesRsltListResultWorkFromReader(ref SqlDataReader myReader, SalTrgtPrintParamWork CndtnWork)
        {
            return this.CopyToSalesRsltListResultWorkFromReaderProc(ref myReader, CndtnWork);
        }
        #endregion  //[CopyToSalesRsltListResultWorkFromReader処理 呼出]

        #region [CopyToSalesRsltListResultWorkFromReader処理]
        /// <summary>
        /// クラス格納処理 Reader → CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        private SalTrgtPrintResultWork CopyToSalesRsltListResultWorkFromReaderProc(ref SqlDataReader myReader, SalTrgtPrintParamWork CndtnWork)
        {
            #region [抽出結果-値セット]
            SalTrgtPrintResultWork ResultWork = new SalTrgtPrintResultWork();
            ResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            ResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            ResultWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            ResultWork.SubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
            ResultWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECD"));
            ResultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENM"));
            ResultWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECD"));
            ResultWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENM"));
            ResultWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODE"));
            ResultWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAME"));
            ResultWork.SalesTargetMoney1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY1"));
            ResultWork.SalesTargetMoney2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY2"));
            ResultWork.SalesTargetMoney3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY3"));
            ResultWork.SalesTargetMoney4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY4"));
            ResultWork.SalesTargetMoney5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY5"));
            ResultWork.SalesTargetMoney6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY6"));
            ResultWork.SalesTargetMoney7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY7"));
            ResultWork.SalesTargetMoney8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY8"));
            ResultWork.SalesTargetMoney9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY9"));
            ResultWork.SalesTargetMoney10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY10"));
            ResultWork.SalesTargetMoney11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY11"));
            ResultWork.SalesTargetMoney12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY12"));
            ResultWork.SalesTargetProfit1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT1"));
            ResultWork.SalesTargetProfit2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT2"));
            ResultWork.SalesTargetProfit3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT3"));
            ResultWork.SalesTargetProfit4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT4"));
            ResultWork.SalesTargetProfit5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT5"));
            ResultWork.SalesTargetProfit6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT6"));
            ResultWork.SalesTargetProfit7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT7"));
            ResultWork.SalesTargetProfit8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT8"));
            ResultWork.SalesTargetProfit9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT9"));
            ResultWork.SalesTargetProfit10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT10"));
            ResultWork.SalesTargetProfit11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT11"));
            ResultWork.SalesTargetProfit12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT12"));
            #endregion  //[抽出結果-値セット]

            return ResultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader処理]
    }
}

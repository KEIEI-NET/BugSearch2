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
    class MTtlSaSlipCust : MTtlSaSlipBase, IMTtlSaSlip
    {        
        #region [���Ӑ�ʗp Select��]
        /// <summary>
        /// ���Ӑ�ʗpSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="ParamWork">��������</param>
        /// <returns>���Ӑ�ʗpSELECT��</returns>
        /// <br>Note       : ���Ӑ�ʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.21</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, CustSalesDistributionReportParamWork ParamWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, ParamWork);
        }
        #endregion  //[���Ӑ�ʗp Select��]

        #region [���Ӑ�ʗp Select����������]
        /// <summary>
        /// ���Ӑ�ʗpSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="ParamWork">��������</param>
        /// <returns>���Ӑ�ʗpSELECT��</returns>
        /// <br>Note       : ���Ӑ�ʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.21</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, CustSalesDistributionReportParamWork ParamWork)
        {
            string selectTxt = "";
            #region [Select���쐬]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "   CUST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   ,CUST.SECTIONCODE" + Environment.NewLine;
            selectTxt += "   ,SECINF.SECTIONGUIDESNMRF" + Environment.NewLine;
            selectTxt += "   ,CUST.CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "   ,CUSTOMER.CUSTOMERSNMRF" + Environment.NewLine;
            selectTxt += "   ,SALES.SALESCOUNT " + Environment.NewLine;
            selectTxt += "   ,SALES.SALESMONEY" + Environment.NewLine;
            selectTxt += "   ,SALES.TOTALCOST" + Environment.NewLine;
            selectTxt += "   ,SALES.SALESDATERF" + Environment.NewLine;

            #region
            selectTxt += "FROM" + Environment.NewLine;
            selectTxt += "(" + Environment.NewLine;
            if (ParamWork.SearchDiv == 0)
            {
                selectTxt += " SELECT" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,MNGSECTIONCODERF AS SECTIONCODE" + Environment.NewLine;
                selectTxt += "  ,CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += " FROM " + Environment.NewLine;
                selectTxt += "  CUSTOMERRF AS CUSTM" + Environment.NewLine;
                selectTxt += MakeWhereString(ref sqlCommand, ParamWork, "CUSTM", 0);
                selectTxt += " UNION" + Environment.NewLine;
            }

            selectTxt += " SELECT DISTINCT " + Environment.NewLine;
            selectTxt += "  ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  ,RESULTSADDUPSECCDRF AS SECTIONCODE" + Environment.NewLine;
            selectTxt += "  ,CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += "   SALESHISTORYRF AS SELCUST" + Environment.NewLine;
            selectTxt += MakeWhereString(ref sqlCommand, ParamWork, "SELCUST", 1);
            selectTxt += "   AND ACPTANODRSTATUSRF = 30" + Environment.NewLine;
            selectTxt += "   AND (SALESSLIPCDRF = 0 OR SALESSLIPCDRF = 1 )" + Environment.NewLine;
            selectTxt += " " + Environment.NewLine;
            selectTxt += ") AS CUST" + Environment.NewLine;


            selectTxt += "LEFT JOIN" + Environment.NewLine;
            selectTxt += "(" + Environment.NewLine;
            selectTxt += "  SELECT" + Environment.NewLine;
            selectTxt += "   ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   ,RESULTSADDUPSECCDRF" + Environment.NewLine;
            selectTxt += "   ,CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "   ,SALESDATERF" + Environment.NewLine;
            selectTxt += "   ,COUNT(SALESSLIPNUMRF) AS SALESCOUNT " + Environment.NewLine;
            //selectTxt += "   ,SUM(SALESSUBTOTALTAXEXCRF) AS SALESMONEY" + Environment.NewLine;
            selectTxt += "   ,SUM(SALESTOTALTAXEXCRF) AS SALESMONEY" + Environment.NewLine;
            selectTxt += "   ,SUM(TOTALCOSTRF) AS TOTALCOST" + Environment.NewLine;
            selectTxt += "  FROM" + Environment.NewLine;
            selectTxt += "   SALESHISTORYRF AS SALHIS " + Environment.NewLine;
            selectTxt += MakeWhereString(ref sqlCommand, ParamWork, "SALHIS", 1);
            selectTxt += "   AND ACPTANODRSTATUSRF = 30" + Environment.NewLine;
            selectTxt += "   AND (SALESSLIPCDRF = 0 OR SALESSLIPCDRF = 1 )" + Environment.NewLine;
            selectTxt += "  GROUP BY" + Environment.NewLine;
            selectTxt += "   ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   ,RESULTSADDUPSECCDRF" + Environment.NewLine;
            selectTxt += "   ,CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "   ,SALESDATERF" + Environment.NewLine;
            selectTxt += ") AS SALES" + Environment.NewLine;
            selectTxt += "ON CUST.ENTERPRISECODERF = SALES.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "AND CUST.SECTIONCODE = SALES.RESULTSADDUPSECCDRF" + Environment.NewLine;
            selectTxt += "AND CUST.CUSTOMERCODERF = SALES.CUSTOMERCODERF" + Environment.NewLine;
            #endregion

            #region [JOIN]
            selectTxt += "LEFT JOIN  SECINFOSETRF AS SECINF" + Environment.NewLine;
            selectTxt += "ON CUST.ENTERPRISECODERF = SECINF.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "AND CUST.SECTIONCODE = SECINF.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "LEFT JOIN CUSTOMERRF AS CUSTOMER" + Environment.NewLine;
            selectTxt += "ON CUST.ENTERPRISECODERF = CUSTOMER.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "AND CUST.CUSTOMERCODERF = CUSTOMER.CUSTOMERCODERF" + Environment.NewLine;
            #endregion  //[JOIN]


            #endregion  //[Select���쐬]

            return selectTxt;
        }
        #endregion  //[���Ӑ�ʗp Select����������]
        
        #region [���Ӑ�ʏW�v�f�[�^�p Where�� ��������]
        /// <summary>
        /// ���Ӑ�ʏW�v�f�[�^�pWHERE�� �������� (���v�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="ParamWork">��������</param>
        /// <param name="sGSMSLP">�e�[�u�������́F���Ӑ�ʏW�v�f�[�^</param>
        /// <param name="iRsltTtlDivCd">�݌Ɏ�񂹋敪</param>
        /// <returns>���Ӑ�ʏW�v�f�[�^�pWHERE��</returns>
        /// <br>Note       : ���Ӑ�ʔ��㌎���W�v�f�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.21</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustSalesDistributionReportParamWork ParamWork, string sGSMSLP,int iMakeDiv)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += sGSMSLP + ".ENTERPRISECODERF=@" + sGSMSLP + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(ParamWork.EnterpriseCode);

            //�_���폜�敪
            retstring += " AND " + sGSMSLP + ".LOGICALDELETECODERF=0 " + Environment.NewLine;

            if (iMakeDiv == 1)
            {
                //���_�R�[�h
                if (ParamWork.SectionCode != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in ParamWork.SectionCode)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        retstring += " AND " + sGSMSLP + ".RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                    }
                    retstring += Environment.NewLine;
                }

                //�Ώۓ��t
                if (ParamWork.StSalesDate != 0)
                {
                    retstring += " AND " + sGSMSLP + ".SALESDATERF>=@" + sGSMSLP + "SALESDATEST" + Environment.NewLine;
                    SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "SALESDATEST", SqlDbType.Int);
                    paraSalesDateSt.Value = SqlDataMediator.SqlSetInt32(ParamWork.StSalesDate);
                }
                if (ParamWork.EdSalesDate != 0)
                {
                    retstring += " AND " + sGSMSLP + ".SALESDATERF<=@" + sGSMSLP + "SALESDATEED" + Environment.NewLine;
                    SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "SALESDATEED", SqlDbType.Int);
                    paraSalesDateEd.Value = SqlDataMediator.SqlSetInt32(ParamWork.EdSalesDate);
                }

                //�S���҃R�[�h
                if (ParamWork.StSalesEmployeeCd != "")
                {
                    retstring += " AND " + sGSMSLP + ".SALESEMPLOYEECDRF>=@" + sGSMSLP + "SALESEMPLOYEECDST" + Environment.NewLine;
                    SqlParameter paraStSalesEmployeeCd = sqlCommand.Parameters.Add("@" + sGSMSLP + "SALESEMPLOYEECDST", SqlDbType.NChar);
                    paraStSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(ParamWork.StSalesEmployeeCd);
                }
                if (ParamWork.EdSalesEmployeeCd != "")
                {
                    retstring += " AND " + sGSMSLP + ".SALESEMPLOYEECDRF<=@" + sGSMSLP + "SALESEMPLOYEECDED" + Environment.NewLine;
                    SqlParameter paraEdSalesEmployeeCd = sqlCommand.Parameters.Add("@" + sGSMSLP + "SALESEMPLOYEECDED", SqlDbType.NChar);
                    paraEdSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(ParamWork.EdSalesEmployeeCd);
                }

                //�n��R�[�h
                if (ParamWork.StSalesAreaCode != 0)
                {
                    retstring += " AND " + sGSMSLP + ".SALESAREACODERF>=@" + sGSMSLP + "SALESAREACODEST" + Environment.NewLine;
                    SqlParameter paraStSalesAreaCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "SALESAREACODEST", SqlDbType.Int);
                    paraStSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(ParamWork.StSalesAreaCode);
                }
                if (ParamWork.EdSalesAreaCode != 9999)
                {
                    retstring += " AND " + sGSMSLP + ".SALESAREACODERF<=@" + sGSMSLP + "SALESAREACODEED" + Environment.NewLine;
                    SqlParameter paraEdSalesAreaCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "SALESAREACODEED", SqlDbType.Int);
                    paraEdSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(ParamWork.EdSalesAreaCode);
                }

                //���Ӑ�R�[�h
                if (ParamWork.StCustomerCode != 0)
                {
                    retstring += " AND " + sGSMSLP + ".CUSTOMERCODERF>=@" + sGSMSLP + "CUSTOMERCODEST" + Environment.NewLine;
                    SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "CUSTOMERCODEST", SqlDbType.Int);
                    paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(ParamWork.StCustomerCode);
                }
                if (ParamWork.EdCustomerCode != 99999999)
                {
                    retstring += " AND " + sGSMSLP + ".CUSTOMERCODERF<=@" + sGSMSLP + "CUSTOMERCODEED" + Environment.NewLine;
                    SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "CUSTOMERCODEED", SqlDbType.Int);
                    paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(ParamWork.EdCustomerCode);
                }
            }
            else
            {
                //���_�R�[�h
                if (ParamWork.SectionCode != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in ParamWork.SectionCode)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        retstring += " AND " + sGSMSLP + ".MNGSECTIONCODERF IN (" + sectionCodestr + ") ";
                    }
                    retstring += Environment.NewLine;
                }
                //���Ӑ�R�[�h
                if (ParamWork.StCustomerCode != 0)
                {
                    retstring += " AND " + sGSMSLP + ".CUSTOMERCODERF>=@" + sGSMSLP + "CUSTOMERCODEST" + Environment.NewLine;
                    SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "CUSTOMERCODEST", SqlDbType.Int);
                    paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(ParamWork.StCustomerCode);
                }
                if (ParamWork.EdCustomerCode != 99999999)
                {
                    retstring += " AND " + sGSMSLP + ".CUSTOMERCODERF<=@" + sGSMSLP + "CUSTOMERCODEED" + Environment.NewLine;
                    SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "CUSTOMERCODEED", SqlDbType.Int);
                    paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(ParamWork.EdCustomerCode);
                }
            }


            #endregion  //WHERE���쐬

            return retstring;
        }
        #endregion  //[���Ӑ�ʔ��㌎���W�v�f�[�^�p Where�� ��������]

        #region [CopyToSalesRsltListResultWorkFromReader���� �ďo]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.21</br>
        /// </remarks>
        public CustSalesDistributionReportResultWork CopyToSalesRsltListResultWorkFromReader(ref SqlDataReader myReader, CustSalesDistributionReportParamWork ParamWork)
        {
            return this.CopyToSalesRsltListResultWorkFromReaderProc(ref myReader, ParamWork);
        }
        #endregion  //[CopyToSalesRsltListResultWorkFromReader���� �ďo]

        #region [CopyToSalesRsltListResultWorkFromReader����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.21</br>
        /// </remarks>
        private CustSalesDistributionReportResultWork CopyToSalesRsltListResultWorkFromReaderProc(ref SqlDataReader myReader, CustSalesDistributionReportParamWork ParamWork)
        {

            #region [���o����-�l�Z�b�g]
            CustSalesDistributionReportResultWork ResultWork = new CustSalesDistributionReportResultWork();
            ResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            ResultWork.SecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODE"));
            ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            ResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            ResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            //ResultWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            //ResultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
            //ResultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            //ResultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            ResultWork.SalesCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCOUNT"));
            ResultWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY"));
            ResultWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOST"));
            ResultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            #endregion  //[���o����-�l�Z�b�g]

            return ResultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader����]
    }
}

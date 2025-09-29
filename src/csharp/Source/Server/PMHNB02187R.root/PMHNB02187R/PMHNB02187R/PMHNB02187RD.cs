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
        #region [�S���ҕʗp Select��]
        /// <summary>
        /// �S���ҕʗpSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="ParamWork">��������</param>
        /// <returns>�S���ҕʗpSELECT��</returns>
        /// <br>Note       : �S���ҕʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.21</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, CustSalesDistributionReportParamWork ParamWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, ParamWork);
        }
        #endregion  //[�S���ҕʗp Select��]

        #region [�S���ҕʗp Select����������]
        /// <summary>
        /// �S���ҕʗpSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="ParamWork">��������</param>
        /// <returns>�S���ҕʗpSELECT��</returns>
        /// <br>Note       : �S���ҕʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.21</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, CustSalesDistributionReportParamWork ParamWork)
        {

            string selectTxt = "";
            #region [Select���쐬]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "   EMP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   ,EMP.SECTIONCODE" + Environment.NewLine;
            selectTxt += "   ,SECINF.SECTIONGUIDESNMRF" + Environment.NewLine;
            selectTxt += "   ,EMP.EMPLOYEECODE" + Environment.NewLine;
            selectTxt += "   ,EMPLOYEE.NAMERF" + Environment.NewLine;
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
                selectTxt += "  ,BELONGSECTIONCODERF AS SECTIONCODE" + Environment.NewLine;
                selectTxt += "  ,EMPLOYEECODERF AS EMPLOYEECODE" + Environment.NewLine;
                selectTxt += " FROM" + Environment.NewLine;
                selectTxt += "  EMPLOYEERF AS EMPL" + Environment.NewLine;
                selectTxt += MakeWhereString(ref sqlCommand, ParamWork, "EMPL", 0);
                selectTxt += " UNION" + Environment.NewLine;
            }

            selectTxt += " SELECT DISTINCT" + Environment.NewLine;
            selectTxt += "  ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  ,RESULTSADDUPSECCDRF AS SECTIONCODE" + Environment.NewLine;
            selectTxt += "  ,SALESEMPLOYEECDRF AS EMPLOYEECODE" + Environment.NewLine;
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += "   SALESHISTORYRF AS SALEMP" + Environment.NewLine;
            selectTxt += MakeWhereString(ref sqlCommand, ParamWork, "SALEMP", 1);
            selectTxt += "   AND ACPTANODRSTATUSRF = 30" + Environment.NewLine;
            selectTxt += "   AND (SALESSLIPCDRF = 0 OR SALESSLIPCDRF = 1 )" + Environment.NewLine;
            selectTxt += ") AS EMP" + Environment.NewLine;


            selectTxt += "LEFT JOIN" + Environment.NewLine;
            selectTxt += "(" + Environment.NewLine;
            selectTxt += "  SELECT" + Environment.NewLine;
            selectTxt += "   ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   ,RESULTSADDUPSECCDRF" + Environment.NewLine;
            selectTxt += "   ,SALESEMPLOYEECDRF  " + Environment.NewLine;
            selectTxt += "   ,SALESDATERF" + Environment.NewLine;
            selectTxt += "   ,COUNT(SALESSLIPNUMRF) AS SALESCOUNT " + Environment.NewLine;
            //selectTxt += "   ,SUM(SALESSUBTOTALTAXEXCRF) AS SALESMONEY" + Environment.NewLine;
            selectTxt += "   ,SUM(SALESTOTALTAXEXCRF) AS SALESMONEY" + Environment.NewLine;
            selectTxt += "   ,SUM(TOTALCOSTRF) AS TOTALCOST" + Environment.NewLine;
            selectTxt += "  FROM" + Environment.NewLine;
            selectTxt += "   SALESHISTORYRF AS SALHIS" + Environment.NewLine;
            selectTxt += MakeWhereString(ref sqlCommand, ParamWork, "SALHIS", 1);
            selectTxt += "   AND ACPTANODRSTATUSRF = 30" + Environment.NewLine;
            selectTxt += "   AND (SALESSLIPCDRF = 0 OR SALESSLIPCDRF = 1 )" + Environment.NewLine;
            selectTxt += "  GROUP BY" + Environment.NewLine;
            selectTxt += "   ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   ,RESULTSADDUPSECCDRF" + Environment.NewLine;
            selectTxt += "   ,SALESEMPLOYEECDRF" + Environment.NewLine;
            selectTxt += "   ,SALESDATERF" + Environment.NewLine;
            selectTxt += ") AS SALES" + Environment.NewLine;
            selectTxt += "ON EMP.ENTERPRISECODERF = SALES.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "AND EMP.SECTIONCODE = SALES.RESULTSADDUPSECCDRF" + Environment.NewLine;
            selectTxt += "AND EMP.EMPLOYEECODE = SALES.SALESEMPLOYEECDRF" + Environment.NewLine;
            #endregion

            #region [JOIN]
            selectTxt += "LEFT JOIN SECINFOSETRF AS SECINF" + Environment.NewLine;
            selectTxt += "ON EMP.ENTERPRISECODERF = SECINF.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "AND EMP.SECTIONCODE = SECINF.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "LEFT JOIN EMPLOYEERF AS EMPLOYEE" + Environment.NewLine;
            selectTxt += "ON EMP.ENTERPRISECODERF = EMPLOYEE.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "AND EMP.EMPLOYEECODE = EMPLOYEE.EMPLOYEECODERF" + Environment.NewLine;
            selectTxt += "WHERE" + Environment.NewLine;
            selectTxt += "EMPLOYEE.EMPLOYEECODERF <= '9999'" + Environment.NewLine;
            #endregion  //[JOIN]
            #endregion  //[Select���쐬]

            return selectTxt;
        }
        #endregion  //[�n��ʗp Select����������]
        
        #region [�n��ʏW�v�f�[�^�p Where�� ��������]
        /// <summary>
        /// ���i�ʔ��㌎���W�v�f�[�^�pWHERE�� �������� (���v�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="ParamWork">��������</param>
        /// <param name="sGSMSLP">�e�[�u�������́F���i�ʔ��㌎���W�v�f�[�^</param>
        /// <returns>���i�ʔ��㌎���W�v�f�[�^�pWHERE��</returns>
        /// <br>Note       : ���i�ʔ��㌎���W�v�f�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.21</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustSalesDistributionReportParamWork ParamWork, string sGSMSLP, int iMakeDiv)
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
                        retstring += " AND " + sGSMSLP + ".BELONGSECTIONCODERF IN (" + sectionCodestr + ") ";
                    }
                    retstring += Environment.NewLine;
                }
                //�S���҃R�[�h
                if (ParamWork.StSalesEmployeeCd != "")
                {
                    retstring += " AND " + sGSMSLP + ".EMPLOYEECODERF>=@" + sGSMSLP + "EMPLOYEECODEST" + Environment.NewLine;
                    SqlParameter paraStSalesEmployeeCd = sqlCommand.Parameters.Add("@" + sGSMSLP + "EMPLOYEECODEST", SqlDbType.NChar);
                    paraStSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(ParamWork.StSalesEmployeeCd);
                }
                if (ParamWork.EdSalesEmployeeCd != "")
                {
                    retstring += " AND " + sGSMSLP + ".EMPLOYEECODERF<=@" + sGSMSLP + "EMPLOYEECODEED" + Environment.NewLine;
                    SqlParameter paraEdSalesEmployeeCd = sqlCommand.Parameters.Add("@" + sGSMSLP + "EMPLOYEECODEED", SqlDbType.NChar);
                    paraEdSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(ParamWork.EdSalesEmployeeCd);
                }
            }


            #endregion  //WHERE���쐬

            return retstring;
        }
        #endregion  //[���i�ʔ��㌎���W�v�f�[�^�p Where�� ��������]

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
            //ResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            //ResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            ResultWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODE"));
            ResultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
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

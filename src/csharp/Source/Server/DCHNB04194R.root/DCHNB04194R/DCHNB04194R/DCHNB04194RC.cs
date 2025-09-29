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
        Boolean bSection = false;

        #region [Emp�p Select����������]
        /// <summary>
        /// ����N�Ԏ��уf�[�^�pSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">���������i�[�N���X</param>
        /// <returns>����N�Ԏ��уf�[�^�pSELECT��</returns>
        /// <br>Note       : ����N�Ԏ��уf�[�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 2010/08/25�A2010/09/10 chenyd</br>
        /// <br>            �E��QID:13278 �e�L�X�g�o�͑Ή�</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesAnnualDataSelectParamWork paramWork, int paratotalDiv)
        {
            if (paramWork.SectionCode != "")
                bSection = true;
            string Text = "";
            
            // �C�� 2008/09/22 >>>
            #region �C���O
            /*
            Text += "SELECT "
                + "ID.YEARMONTH AS YEARMONTH, "
                + "SL.SALESORDERDIVCDRF AS SALESORDERDIVCD, "
                + "SL.GOODSKINDCODERF AS GOODSKINDCODE, "
                + "SL.SUM_SALESTOTALTAXEXC AS SUM_SALESTOTALTAXEXC, "
                + "SL.SUM_SALESRETGOODSPRICE AS SUM_SALESRETGOODSPRICE, "
                + "SL.SUM_DISCOUNTPRICE AS SUM_DISCOUNTPRICE, "
                + "SL.SUM_GROSSPROFIT AS SUM_GROSSPROFIT, "
                + "ET.T_SALESTARGETMONEYRF AS SUM_SALESTARGETMONEY, "
                + "ET.T_SALESTARGETPROFITRF AS SUM_SALESTARGETPROFIT "
                + "FROM "
                + "(SELECT DISTINCT ADDUPYEARMONTHRF AS YEARMONTH FROM EMPMTTLSASLIPRF "
                + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Slip)
                + "UNION "
                + "SELECT DISTINCT CAST(TARGETDIVIDECODERF AS INT) AS YEARMONTH FROM EMPSALESTARGETRF "
                + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Target)
                + ") ID ";
            Text += "LEFT JOIN "
                + "(SELECT "
                + "ENTERPRISECODERF AS ENTERPRISECODERF, "
                + IFBy(bSection, "ADDUPSECCODERF AS ADDUPSECCODERF, ")
                + "ADDUPYEARMONTHRF AS ADDUPYEARMONTHRF, "
                + "SALESORDERDIVCDRF AS SALESORDERDIVCDRF, "
                + "GOODSKINDCODERF AS GOODSKINDCODERF, "
                + "SUM(SALESTOTALTAXEXCRF) AS SUM_SALESTOTALTAXEXC, "
                + "SUM(SALESRETGOODSPRICERF) AS SUM_SALESRETGOODSPRICE, "
                + "SUM(DISCOUNTPRICERF) AS SUM_DISCOUNTPRICE, "
                + "SUM(GROSSPROFITRF) AS SUM_GROSSPROFIT "
                + "FROM "
                + "EMPMTTLSASLIPRF "	        //�S���ҕʔ��㌎���W�v�f�[�^
                + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Slip)
                + "GROUP BY "
                + "ENTERPRISECODERF "
                + IFBy(bSection, ", ADDUPSECCODERF ")
                + ", ADDUPYEARMONTHRF "
                + ", SALESORDERDIVCDRF "
                + ", GOODSKINDCODERF "
                + ") SL "
                + "ON ID.YEARMONTH=SL.ADDUPYEARMONTHRF ";
            */ 
            #endregion
            // --- ADD 2010/09/10 -------------------------------->>>>>
            if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
            {
               Text += "SELECT " + Environment.NewLine
                + "A.YEARMONTH AS YEARMONTH, " + Environment.NewLine;
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += "A.EMPLOYEECODERF AS EMPLOYEECODERF, " + Environment.NewLine;
                    Text += "A.ENTERPRISECODERF, " + Environment.NewLine;
                }
                Text += "A.RSLTTTLDIVCDRF AS RSLTTTLDIVCDRF," + Environment.NewLine                // ���яW�v�敪( 0:���i���v1:�݌�2:����3:��� )
                    + "A.SUM_SALESMONEYRF, " + Environment.NewLine               // ������z(�Ŕ��@�ԕi/�l���͊܂܂Ȃ�)
                    + "A.SUM_SALESRETGOODSPRICE, " + Environment.NewLine
                    + "A.SUM_DISCOUNTPRICE, " + Environment.NewLine
                    + "A.SUM_GROSSPROFIT, " + Environment.NewLine
                    + "A.SUM_SALESTIMESRF, " + Environment.NewLine
                    + "A.SUM_SALESTARGETMONEY, " + Environment.NewLine
                    + "A.SUM_SALESTARGETPROFIT " + Environment.NewLine;

                Text += "FROM ( " + Environment.NewLine;
            }
            // --- ADD 2010/09/10 --------------------------------<<<<<
            Text += "SELECT " + Environment.NewLine
                + "ID.YEARMONTH AS YEARMONTH, " + Environment.NewLine;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += "ID.EMPLOYEECODERF AS EMPLOYEECODERF, " + Environment.NewLine;
                    // --- ADD 2010/09/10 -------------------------------->>>>>
                    Text += "ID.ENTERPRISECODERF, " + Environment.NewLine;
                    // --- ADD 2010/09/10 --------------------------------<<<<<
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += "SL.RSLTTTLDIVCDRF AS RSLTTTLDIVCDRF," + Environment.NewLine                // ���яW�v�敪( 0:���i���v1:�݌�2:����3:��� )
                    + "SUM(SL.SUM_SALESMONEYRF) AS SUM_SALESMONEYRF, " + Environment.NewLine               // ������z(�Ŕ��@�ԕi/�l���͊܂܂Ȃ�)
                    + "SUM(SL.SUM_SALESRETGOODSPRICE) AS SUM_SALESRETGOODSPRICE, " + Environment.NewLine
                    + "SUM(SL.SUM_DISCOUNTPRICE) AS SUM_DISCOUNTPRICE, " + Environment.NewLine
                    + "SUM(SL.SUM_GROSSPROFIT) AS SUM_GROSSPROFIT, " + Environment.NewLine
                    + "SUM(SL.SUM_SALESTIMESRF) AS SUM_SALESTIMESRF, " + Environment.NewLine
                    + "ET.T_SALESTARGETMONEYRF AS SUM_SALESTARGETMONEY, " + Environment.NewLine
                    + "ET.T_SALESTARGETPROFITRF AS SUM_SALESTARGETPROFIT " + Environment.NewLine
                    + "FROM " + Environment.NewLine
                //+ "(SELECT DISTINCT ADDUPYEARMONTHRF AS YEARMONTH FROM MTTLSALESSLIPRF " + Environment.NewLine
                + "(SELECT DISTINCT ADDUPYEARMONTHRF AS YEARMONTH  " + Environment.NewLine;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += ",  EMPLOYEECODERF AS EMPLOYEECODERF " + Environment.NewLine;
                    // --- ADD 2010/09/10 -------------------------------->>>>>
                    Text += ",  ENTERPRISECODERF " + Environment.NewLine;
                    // --- ADD 2010/09/10 --------------------------------<<<<<
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += " FROM MTTLSALESSLIPRF " + Environment.NewLine
                    + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Slip, 0);
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += " AND  EMPLOYEECODERF != '    '  " + Environment.NewLine;
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += "UNION " + Environment.NewLine
                        //+ "SELECT DISTINCT CAST(TARGETDIVIDECODERF AS INT) AS YEARMONTH FROM EMPSALESTARGETRF " + Environment.NewLine
                    + "SELECT DISTINCT CAST(TARGETDIVIDECODERF AS INT) AS YEARMONTH  " + Environment.NewLine;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += ",  EMPLOYEECODERF AS EMPLOYEECODERF " + Environment.NewLine;
                    // --- ADD 2010/09/10 -------------------------------->>>>>
                    Text += ",  ENTERPRISECODERF " + Environment.NewLine;
                    // --- ADD 2010/09/10 --------------------------------<<<<<
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += " FROM EMPSALESTARGETRF " + Environment.NewLine
                    + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Target,0)
                    + ") ID " + Environment.NewLine;

                Text += "LEFT JOIN " + Environment.NewLine
                    + "(SELECT " + Environment.NewLine
                    + "ENTERPRISECODERF AS ENTERPRISECODERF, " + Environment.NewLine;               // ��ƃR�[�h
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += " EMPLOYEECODERF AS EMPLOYEECODERF, " + Environment.NewLine;
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += IFBy(bSection, "ADDUPSECCODERF AS ADDUPSECCODERF, ")                          // �v�㋒�_
                    + "ADDUPYEARMONTHRF AS ADDUPYEARMONTHRF, " + Environment.NewLine                // �v��N��
                    + "RSLTTTLDIVCDRF AS RSLTTTLDIVCDRF," + Environment.NewLine                     // ���яW�v�敪( 0:���i���v1:�݌�2:����3:��� )
                    + "SUM(SALESMONEYRF) AS SUM_SALESMONEYRF, " + Environment.NewLine               // ������z(�Ŕ��@�ԕi/�l���͊܂܂Ȃ�)
                    + "SUM(SALESRETGOODSPRICERF) AS SUM_SALESRETGOODSPRICE, " + Environment.NewLine // �ԕi�z
                    + "SUM(DISCOUNTPRICERF) AS SUM_DISCOUNTPRICE, " + Environment.NewLine           // �l�����z
                    + "SUM(GROSSPROFITRF) AS SUM_GROSSPROFIT, " + Environment.NewLine               // �e�����z
                    + "SUM(SALESTIMESRF) AS SUM_SALESTIMESRF " + Environment.NewLine                // �����
                    + "FROM " + Environment.NewLine
                    + "MTTLSALESSLIPRF " + Environment.NewLine	                                    //���㌎���W�v�f�[�^
                    + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Slip, 0)
                    + "GROUP BY " + Environment.NewLine
                    + "ENTERPRISECODERF " + Environment.NewLine;// ��ƃR�[�h
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += " ,EMPLOYEECODERF " + Environment.NewLine;
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += IFBy(bSection, ", ADDUPSECCODERF ")                                           // �v�㋒�_
                    + ", ADDUPYEARMONTHRF " + Environment.NewLine                                   // �v��N��
                    + ", RSLTTTLDIVCDRF " + Environment.NewLine                                     // ���яW�v�敪( 0:���i���v1:�݌�2:����3:��� )
                    + ") SL " + Environment.NewLine
                    + "ON ID.YEARMONTH=SL.ADDUPYEARMONTHRF " + Environment.NewLine;
                // �C�� 2008/09/22 <<<
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += " AND ID.EMPLOYEECODERF=SL.EMPLOYEECODERF " + Environment.NewLine;
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += "LEFT JOIN " + Environment.NewLine
                    + "(SELECT " + Environment.NewLine
                    + "ENTERPRISECODERF AS ENTERPRISECODERF, " + Environment.NewLine;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += " EMPLOYEECODERF AS EMPLOYEECODERF, " + Environment.NewLine;
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                //+ IFBy(bSection, "SECTIONCODERF AS SECTIONCODERF, ") + Environment.NewLine
                Text += "CAST(TARGETDIVIDECODERF AS INT) AS TARGETDIVIDECODE, " + Environment.NewLine
                    + "SUM(SALESTARGETMONEYRF) AS T_SALESTARGETMONEYRF, " + Environment.NewLine
                    + "SUM(SALESTARGETPROFITRF) AS T_SALESTARGETPROFITRF " + Environment.NewLine
                    + "FROM EMPSALESTARGETRF " + Environment.NewLine;      //�]�ƈ��ʔ���ڕW�ݒ�}�X�^
                if (paramWork.TotalDiv == (int)TotalDivs.Section) 
                {
                    paramWork.EmployeeDivCd = 0;
                }
                Text += MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Target, 0)
                   + IFBy(paramWork.TotalDiv == (int)TotalDivs.Section, "AND TARGETCONTRASTCDRF=10 ")		// 10:���_
                    //+ IFBy(paramWork.TotalDiv == (int)TotalDivs.SubSect, "AND TARGETCONTRASTCDRF=20 ")	// 20:���_+����
                    //+ IFBy(paramWork.TotalDiv == (int)TotalDivs.MinSect, "AND TARGETCONTRASTCDRF=21 ")	// 21:���_+����+��
                   + IFBy(paramWork.TotalDiv == (int)TotalDivs.SalesEmp, "AND TARGETCONTRASTCDRF=22 ")	    // 22:���_+�]�ƈ�
                    //+ IFBy(paramWork.TotalDiv == (int)TotalDivs.SalesEmp, "AND EMPLOYEEDIVCDRF=10 ")	    // 10:�̔��S����
                   + "GROUP BY " + Environment.NewLine
                   + "ENTERPRISECODERF " + Environment.NewLine;
                 //+ IFBy(bSection, " , SECTIONCODERF ") + Environment.NewLine
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
                {
                    Text += " ,EMPLOYEECODERF " + Environment.NewLine;
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += ", TARGETDIVIDECODERF " + Environment.NewLine
                    + ") ET " + Environment.NewLine
                    + "ON ID.YEARMONTH=ET.TARGETDIVIDECODE "+ Environment.NewLine;
             // --- ADD 2010/08/25 -------------------------------->>>>>
             if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
             {
                 Text += " AND ID.EMPLOYEECODERF=ET.EMPLOYEECODERF " + Environment.NewLine;
             }
             if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
             {
                 // --- UPD 2010/09/10 -------------------------------->>>>>
                 Text += " GROUP BY ID.YEARMONTH,ID.EMPLOYEECODERF, ID.ENTERPRISECODERF, SL.RSLTTTLDIVCDRF,ET.T_SALESTARGETMONEYRF,ET.T_SALESTARGETPROFITRF" + Environment.NewLine;
                 Text += " ) AS A " + Environment.NewLine;
                 Text += " INNER JOIN EMPLOYEERF ON " + Environment.NewLine;
                 Text += " EMPLOYEERF.ENTERPRISECODERF = A. ENTERPRISECODERF " + Environment.NewLine;
                 Text += " AND EMPLOYEERF.EMPLOYEECODERF = A. EMPLOYEECODERF " + Environment.NewLine;
                 Text += " AND EMPLOYEERF.LOGICALDELETECODERF = 0 " + Environment.NewLine;

                 //Text += "ORDER BY ID.EMPLOYEECODERF,ID.YEARMONTH, SL.RSLTTTLDIVCDRF " + Environment.NewLine;
                 Text += "ORDER BY A.EMPLOYEECODERF,A.YEARMONTH, A.RSLTTTLDIVCDRF " + Environment.NewLine;
                 // --- UPD 2010/09/10 --------------------------------<<<<<
             }
             else
             {
                 // --- ADD 2010/08/25 --------------------------------<<<<<
                 Text += "GROUP BY ID.YEARMONTH,SL.RSLTTTLDIVCDRF,ET.T_SALESTARGETMONEYRF,ET.T_SALESTARGETPROFITRF" + Environment.NewLine;
                 Text += "ORDER BY ID.YEARMONTH, SL.RSLTTTLDIVCDRF " + Environment.NewLine;
             }
             
            return Text;
        }
        #endregion  //[Emp�p Select����������]

        #region [Emp�p Where�吶������]
        /// <summary>
        /// ����N�Ԏ��уf�[�^�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">���������i�[�N���X</param>
        /// <returns>����N�Ԏ��уf�[�^�pWHERE��</returns>
        /// <br>Note       : ����N�Ԏ��уf�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 2010/08/25 chenyd</br>
        /// <br>            �E��QID:13278 �e�L�X�g�o�͑Ή�</br>
        public string MakeWhereString(ref SqlCommand sqlCommand, SalesAnnualDataSelectParamWork paramWork, string prefName,
            SlipTargetDiv slipTargetDiv, int SubSlip)
        {

            string refName = prefName;
            if (prefName != "")
                refName += ".";

            string text = "WHERE " + Environment.NewLine;
            //�Œ����
            //��ƃR�[�h
            text += refName + "ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine;
            if (sqlCommand.Parameters.IndexOf("@ENTERPRISECODE") < 0)
            {
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
            }
            //�_���폜�敪
            //text += "AND " + refName + ".LOGICALDELETECODERF=0 ";

            //������p�����[�^�̒l�ɂ�蓮�I�ω��̍���
            //���_�R�[�h
            string secCode = "ADDUPSECCODERF";
            if (slipTargetDiv == SlipTargetDiv.Target)
                secCode = "SECTIONCODERF";

            // �C�� 2008/09/22 ���_�R�[�h'00'�͑S���_�ɕύX >>>
            #region �C���O
            //if (paramWork.SectionCode!=null && paramWork.SectionCode != "")
            //{
            //    text += "AND " + refName + secCode + "='" + paramWork.SectionCode + "' ";
            //}
            #endregion
            if (paramWork.SectionCode != null && paramWork.SectionCode != "" && paramWork.SectionCode != "00")
            {
                text += "AND " + refName + secCode + "='" + paramWork.SectionCode + "' " + Environment.NewLine;
            }
            // --- ADD 2010/09/20 ---------->>>>>
            else
            {
                text += "AND " + refName + secCode + " IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine;
            }
            // --- ADD 2010/09/20 ----------<<<<<
            // �C�� 2008/09/22 <<<
            if (slipTargetDiv == SlipTargetDiv.Slip)
            {
                // ���̌`���́A����N�Ԏ��уf�[�^�n��ΏۂƂ��Ă��܂��B
                if (paramWork.YearMonthSt != 0)
                {
                    text += "AND " + refName + "ADDUPYEARMONTHRF>=" + paramWork.YearMonthSt.ToString() + " " + Environment.NewLine;
                }
                if (paramWork.YearMonthEd != 0)
                {
                    text += "AND " + refName + "ADDUPYEARMONTHRF<=" + paramWork.YearMonthEd.ToString() + " " + Environment.NewLine;
                }
            }

            if (slipTargetDiv == SlipTargetDiv.Target)
            {
                // ���̌`���͔���ڕW�ݒ�}�X�^�n��ΏۂƂ��Ă��܂��B
                text += "AND " + refName + "TARGETSETCDRF=10 ";        //�ڕW�ݒ�敪 10:���ԖڕW
                if (paramWork.YearMonthSt != 0)
                {
                    text += "AND " + refName + "TARGETDIVIDECODERF>='" + paramWork.YearMonthSt.ToString() + "' " + Environment.NewLine;
                }
                if (paramWork.YearMonthEd != 0)
                {
                    text += "AND " + refName + "TARGETDIVIDECODERF<='" + paramWork.YearMonthEd.ToString() + "' " + Environment.NewLine;
                }
            }
            // --- ADD 2010/08/25 -------------------------------->>>>>
            //�]�ƈ��R�[�h
            if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
            {
                if (paramWork.St_SelectionCode != "")
                {
                    text += "AND " + refName + "EMPLOYEECODERF >=@EMPLOYEECODE " + Environment.NewLine;
                    if (sqlCommand.Parameters.IndexOf("@EMPLOYEECODE") < 0)
                    {
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(paramWork.St_SelectionCode);
                    }
                }
                if (paramWork.Ed_SelectionCode != "")
                {
                    text += "AND " + refName + "EMPLOYEECODERF <=@EMPLOYEECODEED " + Environment.NewLine;
                    if (sqlCommand.Parameters.IndexOf("@EMPLOYEECODEED") < 0)
                    {
                        SqlParameter paraEmployeeCodeed = sqlCommand.Parameters.Add("@EMPLOYEECODEED", SqlDbType.NChar);
                        paraEmployeeCodeed.Value = SqlDataMediator.SqlSetString(paramWork.Ed_SelectionCode);
                    }
                }
                text += "AND EMPLOYEECODERF IN (SELECT EMPLOYEECODERF FROM EMPLOYEERF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine; // ADD 2010/09/20
            }
            // --- ADD 2010/08/25 --------------------------------<<<<<
            else if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp) 
            {
                if (paramWork.EmployeeCode != "")
                {
                    text += "AND " + refName + "EMPLOYEECODERF=@EMPLOYEECODE " + Environment.NewLine;
                    if (sqlCommand.Parameters.IndexOf("@EMPLOYEECODE") < 0)
                    {
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(paramWork.EmployeeCode);
                    }
                }
            }
            //�]�ƈ��敪
            if (paramWork.EmployeeDivCd > 0)
            {
                text += "AND " + refName + "EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD " + Environment.NewLine;
                if (sqlCommand.Parameters.IndexOf("@EMPLOYEEDIVCD") < 0)
                {
                    SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);

                    //if ((paramWork.TotalDiv == (int)TotalDivs.Section) && (i == 3)) 
                    //{
                    //    paraEmployeeDivCd.Value = 0;
                    //}
                    //else
                    //{
                        paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(paramWork.EmployeeDivCd);
                    //}
                }

            }
            //i++;
            return text;

        }
        #endregion //[Emp�p Where�吶������]

        #region [CopyToResultWorkFromReader����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToSalesAnnualDataSelectResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesAnnualDataSelectResultWork</returns>
        /// <remarks>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public SalesAnnualDataSelectResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader, SalesAnnualDataSelectParamWork paramWork)
        {
            // �C�� 2008/09/22 >>>
            #region �C���O
            /*
            resultWork.AUPYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("YEARMONTH"));
            resultWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCD"));
            resultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODE"));
            resultWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESTOTALTAXEXC"));
            resultWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESRETGOODSPRICE"));
            resultWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_DISCOUNTPRICE"));
            resultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_GROSSPROFIT"));
            resultWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESTARGETMONEY"));
            resultWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESTARGETPROFIT"));
            */ 
            #endregion
            SalesAnnualDataSelectResultWork resultWork = new SalesAnnualDataSelectResultWork();
            resultWork.AUPYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("YEARMONTH"));                      // �v��N��
            resultWork.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RSLTTTLDIVCDRF"));                 // ���яW�v�敪( 0:���i���v1:�݌�2:����3:��� )
            resultWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESMONEYRF"));                 // ������z(�Ŕ��@�ԕi/�l���͊܂܂Ȃ�)
            resultWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUM_SALESTIMESRF"));                 // �����   
            resultWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESRETGOODSPRICE"));   // �ԕi�z
            resultWork.DiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_DISCOUNTPRICE"));             // �l�����z
            resultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_GROSSPROFIT"));                 // �e���z
            resultWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESTARGETMONEY"));       // ����ڕW�z
            resultWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESTARGETPROFIT"));     // �e���ڕW�z
            //resultWork.TermSalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(""));         // ���ԓ`�[���� ��
            // --- ADD 2010/08/25 -------------------------------->>>>>
            if (paramWork.TotalDiv == (int)TotalDivs.SalesEmp && paramWork.SearDiv == 1)
            {
                resultWork.SelectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            }
            // --- ADD 2010/08/25 --------------------------------<<<<<
            // �C�� 2008/09/22 <<<
            return resultWork;
        }
        #endregion //[CopyToResultWorkFromReader����]

    }
}

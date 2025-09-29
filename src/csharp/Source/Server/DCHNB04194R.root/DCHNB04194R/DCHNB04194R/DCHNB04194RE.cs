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
    class MTtlSaSlipAreaBizType : MTtlSaSlipBase, IMTtlSaSlip
    {
        Boolean bSection = false;

        #region [AreaBizType�p Select����������]
        /// <summary>
        /// �n��/�Ǝ�ʔ���N�Ԏ��уf�[�^�pSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">���������i�[�N���X</param>
        /// <param name="termDiv">�W�v���ԋ敪  0:�w�茎�͈�  1:�����͈�</param>
        /// <returns>�n��/�Ǝ�ʔ���N�Ԏ��уf�[�^�pSELECT��</returns>
        /// <br>Note       : �n��/�Ǝ�ʔ���N�Ԏ��уf�[�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���� �[���N</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br>Update Note: 2010/09/10 �k���r</br>
        /// <br>            �E��QID:13278 �e�L�X�g�o�͑Ή�</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesAnnualDataSelectParamWork paramWork, int paratotalDiv)
        {
            if (paramWork.SectionCode != "")
                bSection = true;

            string Text = "";
            //-----ADD 2010/09/09---------->>>>>
            //if (paramWork.TotalDiv == (int)TotalDivs.Area && paramWork.SearDiv == 1 // DEL 2010/09/20
            //    || paramWork.TotalDiv == (int)TotalDivs.BizType && paramWork.SearDiv == 1) // DEL 2010/09/20
            //{ // DEL 2010/09/20
                Text += " SELECT * ";
                Text += " FROM ( ";
                //} // DEL 2010/09/20
            //-----ADD 2010/09/09----------<<<<<
            Text += "SELECT "
                + "ID.YEARMONTH AS YEARMONTH, " + Environment.NewLine;
            //if (paramWork.TotalDiv == (int)TotalDivs.Area && paramWork.SearDiv == 1) // DEL 2010/09/20
            if (paramWork.TotalDiv == (int)TotalDivs.Area) // ADD 2010/09/20
            {
                Text += "SL.SALESAREACODERF, " + Environment.NewLine;
                //-----ADD 2010/09/09---------->>>>>
                Text += "ID.ENTERPRISECODERF, " + Environment.NewLine;
                //-----ADD 2010/09/09----------<<<<<
            }
            //if (paramWork.TotalDiv == (int)TotalDivs.BizType && paramWork.SearDiv == 1) // DEL 2010/09/20
            if (paramWork.TotalDiv == (int)TotalDivs.BizType) // ADD 2010/09/20
            {
                Text += "SL.BUSINESSTYPECODERF, " + Environment.NewLine;
                //-----ADD 2010/09/09---------->>>>>
                Text += "ID.ENTERPRISECODERF, " + Environment.NewLine;
                //-----ADD 2010/09/09----------<<<<<
            }
            Text += "SL.RSLTTTLDIVCDRF AS RSLTTTLDIVCDRF, " + Environment.NewLine
                + "SUM(SL.SUM_SALESMONEYRF) AS SUM_SALESMONEYRF, " + Environment.NewLine
                + "SUM(SL.SUM_SALESRETGOODSPRICE) AS SUM_SALESRETGOODSPRICE, " + Environment.NewLine
                + "SUM(SL.SUM_DISCOUNTPRICE) AS SUM_DISCOUNTPRICE, " + Environment.NewLine
                + "SUM(SL.SUM_GROSSPROFIT) AS SUM_GROSSPROFIT, " + Environment.NewLine
                + "SUM(SL.SUM_SALESTIMESRF) AS SUM_SALESTIMESRF, " + Environment.NewLine
                + "ET.T_SALESTARGETMONEYRF AS SUM_SALESTARGETMONEY, " + Environment.NewLine
                + "ET.T_SALESTARGETPROFITRF AS SUM_SALESTARGETPROFIT " + Environment.NewLine
                + "FROM " + Environment.NewLine;
                //+ "(SELECT DISTINCT ADDUPYEARMONTHRF AS YEARMONTH FROM MTTLSALESSLIPRF " + Environment.NewLine

                //-----ADD 2010/09/02---------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.Area && paramWork.SearDiv == 1)
                {
                    Text += "(SELECT DISTINCT SUB.ADDUPYEARMONTHRF AS YEARMONTH, " + Environment.NewLine;
                    Text += "CUST.SALESAREACODERF, SUB.ENTERPRISECODERF FROM MTTLSALESSLIPRF AS SUB " + Environment.NewLine;
                    Text += "LEFT JOIN CUSTOMERRF AS CUST " + Environment.NewLine;
                    Text += "ON SUB.ENTERPRISECODERF=CUST.ENTERPRISECODERF " + Environment.NewLine;
                    Text += "AND SUB.CUSTOMERCODERF=CUST.CUSTOMERCODERF " + Environment.NewLine;
                    Text += MakeWhereString(ref sqlCommand, paramWork, "SUB", SlipTargetDiv.Slip, 1);
                }
                else if (paramWork.TotalDiv == (int)TotalDivs.BizType && paramWork.SearDiv == 1)
                {
                    Text += "(SELECT DISTINCT SUB.ADDUPYEARMONTHRF AS YEARMONTH, " + Environment.NewLine;
                    Text += "CUST.BUSINESSTYPECODERF, SUB.ENTERPRISECODERF FROM MTTLSALESSLIPRF AS SUB " + Environment.NewLine;
                    Text += "LEFT JOIN CUSTOMERRF AS CUST " + Environment.NewLine;
                    Text += "ON SUB.ENTERPRISECODERF=CUST.ENTERPRISECODERF " + Environment.NewLine;
                    Text += "AND SUB.CUSTOMERCODERF=CUST.CUSTOMERCODERF " + Environment.NewLine;
                    Text += MakeWhereString(ref sqlCommand, paramWork, "SUB", SlipTargetDiv.Slip, 1);
                }
                else
                {
                    //Text += "(SELECT DISTINCT ADDUPYEARMONTHRF AS YEARMONTH FROM MTTLSALESSLIPRF " + Environment.NewLine // DEL 2010/09/20
                    Text += "(SELECT DISTINCT ADDUPYEARMONTHRF AS YEARMONTH, ENTERPRISECODERF FROM MTTLSALESSLIPRF " + Environment.NewLine // ADD 2010/09/20
                        + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Slip, 0);
                }
                //-----ADD 2010/09/02----------<<<<<

                //+ MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Slip,0)
                Text += " AND EMPLOYEEDIVCDRF = @EMPLOYEEDIVCD" + Environment.NewLine
                + " AND (RSLTTTLDIVCDRF != 2 AND RSLTTTLDIVCDRF !=3)" + Environment.NewLine
                + " AND ADDUPSECCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine // ADD 2010/09/20
                + "UNION " + Environment.NewLine;
                //+ "SELECT DISTINCT CAST(TARGETDIVIDECODERF AS INT) AS YEARMONTH FROM CUSTSALESTARGETRF " + Environment.NewLine
                //+ MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Target,1)
 
                //-----ADD 2010/09/02---------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.Area && paramWork.SearDiv == 1)
                {
                    Text += "SELECT DISTINCT CAST(TARGETDIVIDECODERF AS INT) AS YEARMONTH, " + Environment.NewLine;
                    Text += "SALESAREACODERF, ENTERPRISECODERF FROM CUSTSALESTARGETRF " + Environment.NewLine;
                    Text += MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Target, 1);
                }
                else if (paramWork.TotalDiv == (int)TotalDivs.BizType && paramWork.SearDiv == 1)
                {
                    Text += "SELECT DISTINCT CAST(TARGETDIVIDECODERF AS INT) AS YEARMONTH, " + Environment.NewLine;
                    Text += "BUSINESSTYPECODERF, ENTERPRISECODERF FROM CUSTSALESTARGETRF " + Environment.NewLine;
                    Text += MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Target, 1);
                }
                else
                {
                    //Text += "SELECT DISTINCT CAST(TARGETDIVIDECODERF AS INT) AS YEARMONTH FROM CUSTSALESTARGETRF " + Environment.NewLine // DEL 2010/09/20
                    Text += "SELECT DISTINCT CAST(TARGETDIVIDECODERF AS INT) AS YEARMONTH, ENTERPRISECODERF FROM CUSTSALESTARGETRF " + Environment.NewLine // ADD 2010/09/20
                        + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Target, 1);
                }
                //-----ADD 2010/09/02----------<<<<<
                Text += " AND SECTIONCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine; // ADD 2010/09/20
                Text += ") ID " + Environment.NewLine;
                Text += "LEFT JOIN " + Environment.NewLine
                    + "(" + Environment.NewLine
                    + "SELECT " + Environment.NewLine
                    + "ENTERPRISECODERF AS ENTERPRISECODERF, " + Environment.NewLine;
                //if (paramWork.TotalDiv == (int)TotalDivs.Area && paramWork.SearDiv == 1) // DEL 2010/09/20
                if (paramWork.TotalDiv == (int)TotalDivs.Area) // ADD 2010/09/20
                {
                    Text += "SALESAREACODERF AS SALESAREACODERF, " + Environment.NewLine;
                }
                //if (paramWork.TotalDiv == (int)TotalDivs.BizType && paramWork.SearDiv == 1) // DEL 2010/09/20
                if (paramWork.TotalDiv == (int)TotalDivs.BizType) // ADD 2010/09/20
                {
                    Text += "BUSINESSTYPECODERF AS BUSINESSTYPECODERF, " + Environment.NewLine;
                }
                Text += "ADDUPSECCODERF AS ADDUPSECCODERF, " + Environment.NewLine
                + "ADDUPYEARMONTHRF AS ADDUPYEARMONTHRF, " + Environment.NewLine
                + "RSLTTTLDIVCDRF AS RSLTTTLDIVCDRF," + Environment.NewLine
                + "SUM(SALESMONEYRF) AS SUM_SALESMONEYRF, " + Environment.NewLine
                + "SUM(SALESRETGOODSPRICERF) AS SUM_SALESRETGOODSPRICE, " + Environment.NewLine
                + "SUM(DISCOUNTPRICERF) AS SUM_DISCOUNTPRICE, " + Environment.NewLine
                + "SUM(GROSSPROFITRF) AS SUM_GROSSPROFIT, " + Environment.NewLine
                + "SUM(SALESTIMESRF) AS SUM_SALESTIMESRF " + Environment.NewLine
                + "FROM " + Environment.NewLine
                + "(" + Environment.NewLine
                + "SELECT" + Environment.NewLine
                + "SUB.ENTERPRISECODERF AS ENTERPRISECODERF," + Environment.NewLine
                + "SUB.ADDUPSECCODERF AS ADDUPSECCODERF," + Environment.NewLine
                + "SUB.ADDUPYEARMONTHRF AS ADDUPYEARMONTHRF," + Environment.NewLine
                + "SUB.RSLTTTLDIVCDRF AS RSLTTTLDIVCDRF," + Environment.NewLine
                + "SUB.SALESMONEYRF AS SALESMONEYRF," + Environment.NewLine
                + "SUB.SALESRETGOODSPRICERF AS SALESRETGOODSPRICERF," + Environment.NewLine
                + "SUB.DISCOUNTPRICERF AS DISCOUNTPRICERF," + Environment.NewLine
                + "SUB.GROSSPROFITRF AS GROSSPROFITRF, " + Environment.NewLine
                + "SUB.SALESTIMESRF AS SALESTIMESRF, " + Environment.NewLine
                + "CUST.BUSINESSTYPECODERF AS BUSINESSTYPECODERF," + Environment.NewLine
                + "CUST.SALESAREACODERF AS SALESAREACODERF" + Environment.NewLine
                + "FROM MTTLSALESSLIPRF AS SUB" + Environment.NewLine
                + "LEFT JOIN CUSTOMERRF AS CUST" + Environment.NewLine
                + "ON SUB.ENTERPRISECODERF=CUST.ENTERPRISECODERF " + Environment.NewLine
                + "AND SUB.CUSTOMERCODERF=CUST.CUSTOMERCODERF" + Environment.NewLine
                + "WHERE EMPLOYEEDIVCDRF = @EMPLOYEEDIVCD" + Environment.NewLine
                + "AND ADDUPSECCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine // ADD 2010/09/20
                + ") AS CUSTOMER" + Environment.NewLine
                + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Slip, 1)
                + "GROUP BY " + Environment.NewLine
                + "ENTERPRISECODERF " + Environment.NewLine;
                //if (paramWork.TotalDiv == (int)TotalDivs.Area && paramWork.SearDiv == 1) // DEL 2010/09/20
                if (paramWork.TotalDiv == (int)TotalDivs.Area) // ADD 2010/09/20
                {
                    Text += ",SALESAREACODERF " + Environment.NewLine;
                }
                //if (paramWork.TotalDiv == (int)TotalDivs.BizType && paramWork.SearDiv == 1) // DEL 2010/09/20
                if (paramWork.TotalDiv == (int)TotalDivs.BizType) // ADD 2010/09/20
                {
                    Text += ",BUSINESSTYPECODERF " + Environment.NewLine;
                }
                Text += IFBy(bSection, ", ADDUPSECCODERF ") + Environment.NewLine                     // �v�㋒�_
                + ", ADDUPYEARMONTHRF " + Environment.NewLine
                + ", RSLTTTLDIVCDRF " + Environment.NewLine
                + ") SL " + Environment.NewLine
                + "ON ID.YEARMONTH=SL.ADDUPYEARMONTHRF" + Environment.NewLine;

                //-----ADD 2010/09/02---------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.Area && paramWork.SearDiv == 1)
                {
                    Text += "AND ID.SALESAREACODERF = SL.SALESAREACODERF " + Environment.NewLine;
                }
                else if (paramWork.TotalDiv == (int)TotalDivs.BizType && paramWork.SearDiv == 1)
                {
                    Text += "AND ID.BUSINESSTYPECODERF = SL.BUSINESSTYPECODERF " + Environment.NewLine;
                }
                //-----ADD 2010/09/02----------<<<<<

                Text += "LEFT JOIN " + Environment.NewLine
                    + "(SELECT " + Environment.NewLine
                    + "ENTERPRISECODERF AS ENTERPRISECODERF, " + Environment.NewLine;
                if (paramWork.TotalDiv == (int)TotalDivs.Area && paramWork.SearDiv == 1)
                {
                    Text += "SALESAREACODERF AS SALESAREACODERF, " + Environment.NewLine;
                }
                if (paramWork.TotalDiv == (int)TotalDivs.BizType && paramWork.SearDiv == 1)
                {
                    Text += "BUSINESSTYPECODERF AS BUSINESSTYPECODERF, " + Environment.NewLine;
                }
                //+ IFBy(bSection, "SECTIONCODERF AS SECTIONCODERF, ")
                Text += "CAST(TARGETDIVIDECODERF AS INT) AS TARGETDIVIDECODE, " + Environment.NewLine
                + "SUM(SALESTARGETMONEYRF) AS T_SALESTARGETMONEYRF, " + Environment.NewLine
                + "SUM(SALESTARGETPROFITRF) AS T_SALESTARGETPROFITRF " + Environment.NewLine
                + "FROM CUSTSALESTARGETRF " + Environment.NewLine     //���Ӑ�ʔ���ڕW�ݒ�}�X�^
                + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Target, 1)
                + "AND SECTIONCODERF IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine // ADD 2010/09/20
                + IFBy(paramWork.TotalDiv == (int)TotalDivs.Customer, "AND TARGETCONTRASTCDRF=30 ")		  // 30:���_+���Ӑ�
                + IFBy(paramWork.TotalDiv == (int)TotalDivs.BizType, "AND TARGETCONTRASTCDRF=31 ")		  // 31:���_+�Ǝ�
                + IFBy(paramWork.TotalDiv == (int)TotalDivs.Area, "AND TARGETCONTRASTCDRF=32 ")		      // 32:���_+�̔��G���A
                + "GROUP BY " + Environment.NewLine
                + "ENTERPRISECODERF " + Environment.NewLine;
                //+ IFBy(bSection, ", SECTIONCODERF ")
                if (paramWork.TotalDiv == (int)TotalDivs.Area && paramWork.SearDiv == 1)
                {
                    Text += ",SALESAREACODERF " + Environment.NewLine;
                }
                if (paramWork.TotalDiv == (int)TotalDivs.BizType && paramWork.SearDiv == 1)
                {
                    Text += " ,BUSINESSTYPECODERF " + Environment.NewLine;
                }
                Text += ", TARGETDIVIDECODERF " + Environment.NewLine
                + ") ET " + Environment.NewLine
                + "ON ID.YEARMONTH=ET.TARGETDIVIDECODE " + Environment.NewLine;
                //-----ADD 2010/09/02---------->>>>>
                if (paramWork.TotalDiv == (int)TotalDivs.Area && paramWork.SearDiv == 1)
                {
                    Text += "AND ID.SALESAREACODERF = ET.SALESAREACODERF " + Environment.NewLine;
                }
                else if (paramWork.TotalDiv == (int)TotalDivs.BizType && paramWork.SearDiv == 1)
                {
                    Text += "AND ID.BUSINESSTYPECODERF = ET.BUSINESSTYPECODERF " + Environment.NewLine;
                }
                //-----ADD 2010/09/02----------<<<<<

            Text+= "GROUP BY " + Environment.NewLine;
            if (paramWork.TotalDiv == (int)TotalDivs.Area && paramWork.SearDiv == 1)
            {
                //-----UPD 2010/09/09---------->>>>>
                ////-----ADD 2010/09/02---------->>>>>
                ////Text += "YEARMONTH,SL.SALESAREACODERF ,RSLTTTLDIVCDRF,ET.T_SALESTARGETMONEYRF,ET.T_SALESTARGETPROFITRF" + Environment.NewLine;
                ////Text += "ORDER BY SL.SALESAREACODERF ,ID.YEARMONTH, SL.RSLTTTLDIVCDRF " + Environment.NewLine;
                //Text += "ID.YEARMONTH, SL.SALESAREACODERF, RSLTTTLDIVCDRF, ET.T_SALESTARGETMONEYRF, ET.T_SALESTARGETPROFITRF" + Environment.NewLine;
                //Text += "ORDER BY SL.SALESAREACODERF, ID.YEARMONTH, SL.RSLTTTLDIVCDRF " + Environment.NewLine;
                ////-----ADD 2010/09/02----------<<<<<
                Text += "ID.YEARMONTH, SL.SALESAREACODERF,ID.ENTERPRISECODERF, RSLTTTLDIVCDRF, ET.T_SALESTARGETMONEYRF, ET.T_SALESTARGETPROFITRF" + Environment.NewLine;
                Text += " ) AS A";
                Text += " JOIN " + Environment.NewLine
                     + " USERGDBDURF" + Environment.NewLine
                     + " ON A.ENTERPRISECODERF = USERGDBDURF.ENTERPRISECODERF" + Environment.NewLine
                     + " AND A.SALESAREACODERF = USERGDBDURF.GUIDECODERF" + Environment.NewLine
                     + " AND USERGDBDURF.USERGUIDEDIVCDRF = 21 " + Environment.NewLine
                     + " AND USERGDBDURF.LOGICALDELETECODERF = 0" + Environment.NewLine;

                Text += "ORDER BY A.SALESAREACODERF, A.YEARMONTH, A.RSLTTTLDIVCDRF " + Environment.NewLine;
                //-----UPD 2010/09/09----------<<<<<
            }
            else if (paramWork.TotalDiv == (int)TotalDivs.BizType && paramWork.SearDiv == 1)
            {
                //-----UPD 2010/09/09---------->>>>>
                //Text += "YEARMONTH,SL.BUSINESSTYPECODERF , RSLTTTLDIVCDRF,ET.T_SALESTARGETMONEYRF,ET.T_SALESTARGETPROFITRF" + Environment.NewLine;
                //Text += "ORDER BY SL.BUSINESSTYPECODERF ,ID.YEARMONTH, SL.RSLTTTLDIVCDRF " + Environment.NewLine;
                Text += "YEARMONTH,SL.BUSINESSTYPECODERF, ID.ENTERPRISECODERF , RSLTTTLDIVCDRF,ET.T_SALESTARGETMONEYRF,ET.T_SALESTARGETPROFITRF" + Environment.NewLine;
                Text += " ) AS A";
                Text += " JOIN " + Environment.NewLine
                      + " USERGDBDURF" + Environment.NewLine
                      + " ON A.ENTERPRISECODERF = USERGDBDURF.ENTERPRISECODERF" + Environment.NewLine
                      + " AND A.BUSINESSTYPECODERF = USERGDBDURF.GUIDECODERF" + Environment.NewLine
                      + " AND USERGDBDURF.USERGUIDEDIVCDRF = 33 " + Environment.NewLine
                      + " AND USERGDBDURF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                Text += "ORDER BY A.BUSINESSTYPECODERF ,A.YEARMONTH, A.RSLTTTLDIVCDRF " + Environment.NewLine;
                //-----UPD 2010/09/09----------<<<<<
            }
            else
            {
                //-----UPD 2010/09/20---------->>>>>
                //Text += "YEARMONTH,RSLTTTLDIVCDRF,ET.T_SALESTARGETMONEYRF,ET.T_SALESTARGETPROFITRF" + Environment.NewLine;
                //Text += "ORDER BY ID.YEARMONTH, SL.RSLTTTLDIVCDRF " + Environment.NewLine;
                if (paramWork.TotalDiv == (int)TotalDivs.Area)
                {
                    Text += "YEARMONTH,ID.ENTERPRISECODERF,SL.SALESAREACODERF,RSLTTTLDIVCDRF,ET.T_SALESTARGETMONEYRF,ET.T_SALESTARGETPROFITRF" + Environment.NewLine;
                    Text += " ) AS A";
                    Text += " JOIN " + Environment.NewLine
                         + " USERGDBDURF" + Environment.NewLine
                         + " ON A.ENTERPRISECODERF = USERGDBDURF.ENTERPRISECODERF" + Environment.NewLine
                         + " AND A.SALESAREACODERF = USERGDBDURF.GUIDECODERF" + Environment.NewLine
                         + " AND USERGDBDURF.USERGUIDEDIVCDRF = 21 " + Environment.NewLine
                         + " AND USERGDBDURF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                }
                else if (paramWork.TotalDiv == (int)TotalDivs.BizType)
                {
                    Text += "YEARMONTH,ID.ENTERPRISECODERF,SL.BUSINESSTYPECODERF,RSLTTTLDIVCDRF,ET.T_SALESTARGETMONEYRF,ET.T_SALESTARGETPROFITRF" + Environment.NewLine;
                    Text += " ) AS A";
                    Text += " JOIN " + Environment.NewLine
                          + " USERGDBDURF" + Environment.NewLine
                          + " ON A.ENTERPRISECODERF = USERGDBDURF.ENTERPRISECODERF" + Environment.NewLine
                          + " AND A.BUSINESSTYPECODERF = USERGDBDURF.GUIDECODERF" + Environment.NewLine
                          + " AND USERGDBDURF.USERGUIDEDIVCDRF = 33 " + Environment.NewLine
                          + " AND USERGDBDURF.LOGICALDELETECODERF = 0" + Environment.NewLine;
                }

                Text += "ORDER BY A.YEARMONTH, A.RSLTTTLDIVCDRF " + Environment.NewLine;
                //-----UPD 2010/09/20----------<<<<<
            }
           
            if (sqlCommand.Parameters.IndexOf("@EMPLOYEEDIVCD") < 0)
            {
                SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(paramWork.EmployeeDivCd);
            }

            return Text;
        }
        #endregion  //[AreaBizType�p Select����������]

        #region [AreaBizType�p Where�吶������]
        /// <summary>
        /// ���Ӑ�ʔ���N�Ԏ��уf�[�^�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">���������i�[�N���X</param>
        /// <param name="termDiv">�W�v���ԋ敪  0:�w�茎�͈�  1:�����͈�</param>
        /// <returns>���Ӑ�ʔ���N�Ԏ��уf�[�^�pWHERE��</returns>
        /// <br>Note       : ���Ӑ�ʔ���N�Ԏ��уf�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 2010/09/10 �k���r</br>
        /// <br>            �E��QID:13278 �e�L�X�g�o�͑Ή�</br>
        public string MakeWhereString(ref SqlCommand sqlCommand, SalesAnnualDataSelectParamWork paramWork, string prefName,
            SlipTargetDiv slipTargetDiv, int SubSlip)
        {
            string refName = prefName;
            //-----UPD 2010/09/02---------->>>>>
            //if (prefName != "")
            //    refName += ".";
            string refNameCust = "";
            if (prefName != "")
            {
                refName += ".";
                refNameCust = "CUST.";
            }
            //-----UPD 2010/09/02----------<<<<<
            string text = "WHERE ";
            //�Œ����
            //��ƃR�[�h
            text += refName + "ENTERPRISECODERF=@ENTERPRISECODE ";
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

            //  ���_�R�[�h[00]�͑S���_�w��
            if (paramWork.SectionCode != null && paramWork.SectionCode != "" && paramWork.SectionCode != "00")
            {
                text += "AND " + refName + secCode + "='" + paramWork.SectionCode + "' ";
            }

            if (slipTargetDiv == SlipTargetDiv.Slip)
            {
                // ���̌`���́A����N�Ԏ��уf�[�^�n��ΏۂƂ��Ă��܂��B
                if (paramWork.YearMonthSt != 0)
                {
                    text += "AND " + refName + "ADDUPYEARMONTHRF>=" + paramWork.YearMonthSt.ToString() + " ";
                }
                if (paramWork.YearMonthEd != 0)
                {
                    text += "AND " + refName + "ADDUPYEARMONTHRF<=" + paramWork.YearMonthEd.ToString() + " ";
                }
            }

            if (slipTargetDiv == SlipTargetDiv.Target)
            {
                // ���̌`���͔���ڕW�ݒ�}�X�^�n��ΏۂƂ��Ă��܂��B
                text += "AND " + refName + "TARGETSETCDRF=10 ";        //�ڕW�ݒ�敪 10:���ԖڕW
                if (paramWork.YearMonthSt != 0)
                {
                    text += "AND " + refName + "TARGETDIVIDECODERF>='" + paramWork.YearMonthSt.ToString() + "' ";
                }
                if (paramWork.YearMonthEd != 0)
                {
                    text += "AND " + refName + "TARGETDIVIDECODERF<='" + paramWork.YearMonthEd.ToString() + "' ";
                }
            }
            //if (paramWork.EmployeeDivCd > 0)
            //{
            //    text += "AND " + refName + "EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD " + Environment.NewLine;
            //    if (sqlCommand.Parameters.IndexOf("@EMPLOYEEDIVCD") < 0)
            //    {
            //        SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
            //        paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(paramWork.EmployeeDivCd);
            //    }

            //}
            /*
            //���Ӑ�R�[�h
            if (paramWork.TotalDiv == (int)TotalDivs.Customer)
            {
                if (paramWork.CustomerCode != 0)
                {
                    text += "AND " + refName + "CUSTOMERCODERF=@CUSTOMERCODE ";
                    if (sqlCommand.Parameters.IndexOf("@CUSTOMERCODE") < 0)
                    {
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCode);
                    }
                }
            }
            */

            if (SubSlip == 1)
            {
                //�̔��G���A�R�[�h 
                if (paramWork.TotalDiv == (int)TotalDivs.Area && paramWork.SearDiv == 1)
                {
                    if (paramWork.St_SelectionCode != string.Empty)
                    {
                        //-----UPD 2010/09/02---------->>>>>
                        //text += " AND " + refName + "SALESAREACODERF >= " + Convert.ToInt32(paramWork.St_SelectionCode) ;
                        text += " AND " + refNameCust + "SALESAREACODERF >= " + Convert.ToInt32(paramWork.St_SelectionCode);
                        //-----UPD 2010/09/02----------<<<<<
                    }

                    if (paramWork.Ed_SelectionCode != string.Empty)
                    {
                        //-----UPD 2010/09/02---------->>>>>
                        //text += " AND " + refName + "SALESAREACODERF <= " + Convert.ToInt32(paramWork.Ed_SelectionCode);
                        text += " AND " + refNameCust + "SALESAREACODERF <= " + Convert.ToInt32(paramWork.Ed_SelectionCode);
                        //-----UPD 2010/09/02----------<<<<<<
                    }
                }
                else if (paramWork.TotalDiv == (int)TotalDivs.Area)
                {
                    //-----DEL 2010/09/02---------->>>>>
                    //if (paramWork.SalesAreaCode != 0)
                    //{
                    //-----DEL 2010/09/02----------<<<<<
                        //-----UPD 2010/09/02---------->>>>>
                        //text += " AND " + refName + "SALESAREACODERF=@SALESAREACODE ";
                        text += " AND " + refNameCust + "SALESAREACODERF=@SALESAREACODE ";
                        //-----UPD 2010/09/02----------<<<<<
                        if (sqlCommand.Parameters.IndexOf("@SALESAREACODE") < 0)
                        {
                            SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                            paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(paramWork.SalesAreaCode);
                        }
                    //-----DEL 2010/09/02---------->>>>>
                    //}
                    //-----DEL 2010/09/02----------<<<<<
                }

                //�Ǝ�R�[�h
                if (paramWork.TotalDiv == (int)TotalDivs.BizType && paramWork.SearDiv == 1)
                {
                    //-----UPD 2010/09/10---------->>>>>
                    //if (paramWork.St_SelectionCode != string.Empty)
                    if (paramWork.St_SelectionCode != string.Empty && (!"0000".Equals(paramWork.St_SelectionCode)))
                    {
                        //text += " AND " + refName + "BUSINESSTYPECODERF >= " + Convert.ToInt32(paramWork.St_SelectionCode);
                        text += " AND " + refNameCust + "BUSINESSTYPECODERF >= " + Convert.ToInt32(paramWork.St_SelectionCode);
                        //-----UPD 2010/09/10----------<<<<<
                    }
                    //-----UPD 2010/09/10---------->>>>>
                    //if (paramWork.Ed_SelectionCode != string.Empty)
                    if (paramWork.Ed_SelectionCode != string.Empty && (!"0000".Equals(paramWork.St_SelectionCode)))
                    {
                        //text += " AND " + refName + "BUSINESSTYPECODERF <= " + Convert.ToInt32(paramWork.Ed_SelectionCode);
                        text += " AND " + refNameCust + "BUSINESSTYPECODERF <= " + Convert.ToInt32(paramWork.Ed_SelectionCode);
                        //-----UPD 2010/09/10----------<<<<<
                    }
                }
                else if (paramWork.TotalDiv == (int)TotalDivs.BizType)
                {
                    //-----UPD 2010/09/10---------->>>>>
                    ////-----DEL 2010/09/02---------->>>>>
                    ////if (paramWork.BusinessTypeCode != 0)
                    ////{
                    ////-----DEL 2010/09/02----------<<<<<
                    if (paramWork.BusinessTypeCode != 0)
                    {
                    //-----UPD 2010/09/10----------<<<<<
                        text += " AND " + refName + "BUSINESSTYPECODERF=@BUSINESSTYPECODE ";
                        if (sqlCommand.Parameters.IndexOf("@BUSINESSTYPECODE") < 0)
                        {
                            SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                            paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.BusinessTypeCode);
                        }
                        //-----UPD 2010/09/10---------->>>>>
                    }
                    ////-----DEL 2010/09/02---------->>>>>
                    ////}
                    ////-----DEL 2010/09/02----------<<<<<
                    //-----UPD 2010/09/10----------<<<<<
                }
            }
            //-----ADD 2010/09/02---------->>>>>
            text += " ";
            //-----ADD 2010/09/02----------<<<<<
            return text;
        }
        #endregion //[AreaBizType�p Where�吶������]

        #region [CopyToResultWorkFromReader����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesAnnualDataSelectResultWork</returns>
        /// <remarks>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public SalesAnnualDataSelectResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader, SalesAnnualDataSelectParamWork paramWork)
        {
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
            if (paramWork.TotalDiv == (int)TotalDivs.Area && paramWork.SearDiv == 1)
            {
                resultWork.SelectionCode = Convert.ToString(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF")));
            }
            //-----UPD 2010/09/02---------->>>>>
            if (paramWork.TotalDiv == (int)TotalDivs.BizType && paramWork.SearDiv == 1)
            {
                resultWork.SelectionCode = Convert.ToString(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF")));
            }
            //-----UPD 2010/09/02----------<<<<<
            return resultWork;
        }
        #endregion //[CopyToSalesAnnualDataSelectResultWorkFromReader����]

    }
}

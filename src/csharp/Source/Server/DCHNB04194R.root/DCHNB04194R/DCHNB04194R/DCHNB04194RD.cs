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
        Boolean bSection = false;

        #region [Cust�p Select����������]
        /// <summary>
        /// ���Ӑ�ʔ���N�Ԏ��уf�[�^�pSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">���������i�[�N���X</param>
        /// <param name="termDiv">�W�v���ԋ敪  0:�w�茎�͈�  1:�����͈�</param>
        /// <returns>���Ӑ�ʔ���N�Ԏ��уf�[�^�pSELECT��</returns>
        /// <br>Note       : ���Ӑ�ʔ���N�Ԏ��уf�[�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 2010/08/25�A2010/09/10 chenyd</br>
        /// <br>            �E��QID:13278 �e�L�X�g�o�͑Ή�</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesAnnualDataSelectParamWork paramWork, int paratotalDiv)
        {
            if(paramWork.SectionCode != "")
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
                + "(SELECT DISTINCT ADDUPYEARMONTHRF AS YEARMONTH FROM CUSTMTTLSALSLIPRF "
                + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Slip)
                + "UNION "
                + "SELECT DISTINCT CAST(TARGETDIVIDECODERF AS INT) AS YEARMONTH FROM CUSTSALESTARGETRF "
                + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Target)
                + ") ID ";

            Text += "LEFT JOIN (SELECT "
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
                + "CUSTMTTLSALSLIPRF "	        //���Ӑ�ʔ��㌎���W�v�f�[�^
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
            //0:�N�x����,1:�c���Ɖ�(��������),2:�c���Ɖ�(��������)
            if (paramWork.SearchDiv == 0) 
            {
                #region [Select���쐬]

                // --- ADD 2010/09/10 -------------------------------->>>>>
                if (paramWork.SearDiv == 1)
                {
                    Text += " Select DISTINCT * " + Environment.NewLine;
                    Text += "FROM ( " + Environment.NewLine;
                }
                // --- ADD 2010/09/10 --------------------------------<<<<<

                Text += "Select" + Environment.NewLine;
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.SearDiv == 1)
                {
                    Text += "YM.CUSTOMERCODERF AS CUSTOMERCODERF," + Environment.NewLine;
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<
                Text += "YM.YEARMONTH AS ADDUPYEARMONTHRF," + Environment.NewLine
                    + "ET.T_SALESTARGETMONEYRF AS SUM_SALESTARGETMONEY," + Environment.NewLine
                    + "ET.T_SALESTARGETPROFITRF AS SUM_SALESTARGETPROFIT" + Environment.NewLine;
                    // --- ADD 2010/09/10 -------------------------------->>>>>
                    if (paramWork.SearDiv == 1)
                    {
                        Text += ",YM.ENTERPRISECODERF" + Environment.NewLine;
                    }
                    // --- ADD 2010/09/10 --------------------------------<<<<<
                    Text += "From" + Environment.NewLine
                    + "(" + Environment.NewLine
                    + "SELECT DISTINCT " + Environment.NewLine
                    + "ADDUPYEARMONTHRF AS YEARMONTH  " + Environment.NewLine;
                    // --- ADD 2010/08/25 -------------------------------->>>>>
                    if (paramWork.SearDiv == 1)
                    {
                        Text += " ,CUSTOMERCODERF as CUSTOMERCODERF " + Environment.NewLine;
                        // --- ADD 2010/09/10 -------------------------------->>>>>
                        Text += ",ENTERPRISECODERF" + Environment.NewLine;
                        // --- ADD 2010/09/10 --------------------------------<<<<<
                    }
                    // --- ADD 2010/08/25 --------------------------------<<<<<
                    Text += "FROM MTTLSALESSLIPRF " + Environment.NewLine
                    + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Slip, 0)
                    + " UNION" + Environment.NewLine
                    + "SELECT DISTINCT " + Environment.NewLine
                    + "CAST(TARGETDIVIDECODERF AS INT) AS YEARMONTH  " + Environment.NewLine;
                    // --- ADD 2010/08/25 -------------------------------->>>>>
                    if (paramWork.SearDiv == 1)
                    {
                        Text += " ,CUSTOMERCODERF as CUSTOMERCODERF " + Environment.NewLine;
                        // --- ADD 2010/09/10 -------------------------------->>>>>
                        Text += ",ENTERPRISECODERF" + Environment.NewLine;
                        // --- ADD 2010/09/10 --------------------------------<<<<<
                    }
                    // --- ADD 2010/08/25 --------------------------------<<<<<
                    Text += "FROM CUSTSALESTARGETRF" + Environment.NewLine
                    + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Target, 0)
                    + ") YM" + Environment.NewLine
                    + "LEFT JOIN " + Environment.NewLine
                    + "(" + Environment.NewLine
                    + "SELECT" + Environment.NewLine
                    + "ENTERPRISECODERF AS ENTERPRISECODERF,  " + Environment.NewLine;
                    // --- ADD 2010/08/25 -------------------------------->>>>>
                    if (paramWork.SearDiv == 1)
                    {
                        Text += " CUSTOMERCODERF  AS CUSTOMERCODERF,  " + Environment.NewLine;

                    }
                    // --- ADD 2010/08/25 --------------------------------<<<<<
                    //+ "SECTIONCODERF AS SECTIONCODERF," + Environment.NewLine
                    Text += "CAST(TARGETDIVIDECODERF AS INT) AS TARGETDIVIDECODE," + Environment.NewLine
                     + "SUM(SALESTARGETMONEYRF) AS T_SALESTARGETMONEYRF, " + Environment.NewLine
                     + "SUM(SALESTARGETPROFITRF) AS T_SALESTARGETPROFITRF " + Environment.NewLine
                     + "FROM CUSTSALESTARGETRF" + Environment.NewLine
                     + MakeWhereString(ref sqlCommand, paramWork, "", SlipTargetDiv.Target, 0)
                     + IFBy(paramWork.TotalDiv == (int)TotalDivs.Customer, "AND TARGETCONTRASTCDRF=30 ")		  // 30:���_+���Ӑ�
                     + "GROUP BY " + Environment.NewLine;
                    // --- ADD 2010/08/25 -------------------------------->>>>>
                     if (paramWork.SearDiv == 1)
                     {
                         Text += "CUSTOMERCODERF, " + Environment.NewLine;
                     }
                     // --- ADD 2010/08/25 --------------------------------<<<<<
                     Text += "ENTERPRISECODERF," + Environment.NewLine
                        //+ "SECTIONCODERF," + Environment.NewLine
                     + "TARGETDIVIDECODERF " + Environment.NewLine
                     +  ") AS ET" + Environment.NewLine;
                   // --- ADD 2010/08/25 -------------------------------->>>>>
                   if (paramWork.SearDiv == 1)
                   {
                       // --- UPD 2010/09/10 -------------------------------->>>>>
                       //Text += "ON YM.YEARMONTH=ET.TARGETDIVIDECODE AND YM.CUSTOMERCODERF=ET.CUSTOMERCODERF  ORDER BY YM.CUSTOMERCODERF, YM.YEARMONTH" + Environment.NewLine;

                       Text += " ON YM.YEARMONTH=ET.TARGETDIVIDECODE AND YM.CUSTOMERCODERF=ET.CUSTOMERCODERF ) AS A" + Environment.NewLine;
                       Text += " INNER JOIN CUSTOMERRF ON " + Environment.NewLine;
                       Text += " CUSTOMERRF.ENTERPRISECODERF = A. ENTERPRISECODERF " + Environment.NewLine;
                       Text += " AND CUSTOMERRF.CUSTOMERCODERF = A. CUSTOMERCODERF " + Environment.NewLine;
                       Text += " AND CUSTOMERRF.LOGICALDELETECODERF = 0 " + Environment.NewLine;

                       Text += "ORDER BY A.CUSTOMERCODERF, A.ADDUPYEARMONTHRF" + Environment.NewLine;
                       // --- UPD 2010/09/10 --------------------------------<<<<<

                   }
                   else
                   {
                       // --- ADD 2010/08/25 --------------------------------<<<<<
                       Text += "ON YM.YEARMONTH=ET.TARGETDIVIDECODE " + Environment.NewLine;
                   }
                #endregion
            }
            // �C�� 2008/09/22 <<<
            return Text;
        }
        #endregion  //[Cust�p Select����������]

        #region [Cust�p Where�吶������]
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
        /// <br>Update Note: 2010/08/25 chenyd</br>
        /// <br>            �E��QID:13278 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: 2013/06/28 liusy</br>
        /// <br>             #35128 ����N�Ԏ��яƉ��ʂ̒��o�f�[�^���s��</br>
        public string MakeWhereString(ref SqlCommand sqlCommand, SalesAnnualDataSelectParamWork paramWork, string prefName,
            SlipTargetDiv slipTargetDiv, int SubSlip)
        {
            string refName = prefName;
            string wkrefName = prefName;
            if (prefName != "")
                refName += ".";

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

            // -- 2009/04/30 -- >>>>>>>
            //���̉e�����l�����ē����f�[�^�̎��̂ݘ_���폜�敪�𔻒�
            if (prefName == "DEPMIN")
            {
                text += "AND " + refName + "LOGICALDELETECODERF=0 ";
            }
            // -- 2009/04/30 -- <<<<<<<

            //������p�����[�^�̒l�ɂ�蓮�I�ω��̍���
            //���_�R�[�h
            string secCode = "ADDUPSECCODERF";
            if (slipTargetDiv == SlipTargetDiv.Target)
                secCode = "SECTIONCODERF";

            // -- UPD 2010/05/10 ---------------------->>>
            //if (slipTargetDiv == SlipTargetDiv.SalesHist)
                //secCode = "SECTIONCODERF";
            if (slipTargetDiv == SlipTargetDiv.SalesHist)
            {
                //�����v�㋒�_�R�[�h
                //secCode = "DEMANDADDUPSECCDRF";   //del by liusy 2013/06/28 #35128
                secCode = "RESULTSADDUPSECCDRF";    //add by liusy 2013/06/28 #35128

                //���㗚���f�[�^�ǂݍ��݂̏ꍇ�͎󒍃X�e�[�^�X��ǉ�
                text += "AND " + refName + "ACPTANODRSTATUSRF=30 ";
            }

            // -- UPD 2010/05/10 ----------------------<<<

            // �C�� 2008/09/22 ���_�R�[�h[00]�͑S���_�w��ɕύX >>>
            #region �C���O
            /*
            if (paramWork.SectionCode != null && paramWork.SectionCode != "")
            {
                text += "AND " + refName + secCode + "='" + paramWork.SectionCode + "' ";
            }
            */
            #endregion
            if (SubSlip != 1 && SubSlip != 2 && SubSlip != 3)
            {
                if (paramWork.SectionCode != null && paramWork.SectionCode != "" && paramWork.SectionCode != "00")
                {
                    text += "AND " + refName + secCode + "='" + paramWork.SectionCode + "' ";
                }
                // --- ADD 2010/09/20 ---------->>>>>
                else
                {
                    text += "AND " + refName + secCode + " IN (SELECT SECTIONCODERF FROM SECINFOSETRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine;
                }
                // --- ADD 2010/09/20 ----------<<<<<
            }
            // �C�� 2008/09/22 <<<

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
            
            if (slipTargetDiv == SlipTargetDiv.TargetDay)
            {
                if (SubSlip == 0)
                {
                    text += "AND " + refName + "ADDUPDATERF>=@STADDUPDATE ";
                    if (sqlCommand.Parameters.IndexOf("@STADDUPDATE") < 0)
                    {
                        SqlParameter paraSTAddUpDate = sqlCommand.Parameters.Add("@STADDUPDATE", SqlDbType.Int);
                        paraSTAddUpDate.Value = paramWork.StAddUpDate;
                    }
                    text += "AND " + refName + "ADDUPDATERF<=@EDADDUPDATE ";
                    if (sqlCommand.Parameters.IndexOf("@EDADDUPDATE") < 0)
                    {
                        SqlParameter paraEdAddUpDate = sqlCommand.Parameters.Add("@EDADDUPDATE", SqlDbType.Int);
                        paraEdAddUpDate.Value = paramWork.EdAddUpDate;
                    }

                }
                if (SubSlip == 1)
                {
                    text += "AND " + refName + "ADDUPDATERF=@" + wkrefName + "ADDUPDATE ";
                    if (sqlCommand.Parameters.IndexOf("@" + wkrefName + "ADDUPDATE") < 0)
                    {
                        SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@" + wkrefName + "ADDUPDATE", SqlDbType.Int);
                        paraAddUpDate.Value = paramWork.EdAddUpDate;
                    }
                    //if (paramWork.CustomerCode != 0)
                    //{
                    //    text += "AND " + refName + "CUSTOMERCODERF=@CUSTOMERCODE ";
                    //    if (sqlCommand.Parameters.IndexOf("@CUSTOMERCODE") < 0)
                    //    {
                    //        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    //        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCode);
                    //    }
                    // }
                }
                if (SubSlip == 2)
                {
                    text += "AND " + refName + "ADDUPDATERF=@" + wkrefName + "ADDUPDATE ";
                    if (sqlCommand.Parameters.IndexOf("@" + wkrefName + "ADDUPDATE") < 0)
                    {
                        SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@" + wkrefName + "ADDUPDATE", SqlDbType.Int);
                        paraAddUpDate.Value = paramWork.EdSecAddUpDate;
                    }
                }
                if (SubSlip == 3)
                {
                    text += "AND " + refName + "ADDUPADATERF>@STADDUPDATE ";
                    if (sqlCommand.Parameters.IndexOf("@STADDUPDATE") < 0)
                    {
                        SqlParameter paraSTAddUpDate = sqlCommand.Parameters.Add("@STADDUPDATE", SqlDbType.Int);
                        // -- UPD 2009/09/07 --------------------->>>
                        //paraSTAddUpDate.Value = paramWork.EdAddUpDate;
                        paraSTAddUpDate.Value = paramWork.EdSecAddUpDate;
                        // -- UPD 2009/09/07 ---------------------<<<
                    }
                    text += "AND " + refName + "ADDUPADATERF<=@EDADDUPDATE ";
                    if (sqlCommand.Parameters.IndexOf("@EDADDUPDATE") < 0)
                    {
                        SqlParameter paraEdAddUpDate = sqlCommand.Parameters.Add("@EDADDUPDATE", SqlDbType.Int);
                        // -- UPD 2009/09/07 --------------------->>>
                        //paraEdAddUpDate.Value = paramWork.CustTotalDay;
                        paraEdAddUpDate.Value = paramWork.SecTotalDay;
                        // -- UPD 2009/09/07 ---------------------<<<
                    }

                }


            }
            //���Ӑ�R�[�h
            String cusCode = "CUSTOMERCODERF ";
            if (slipTargetDiv == SlipTargetDiv.TargetDay)
                cusCode = "CLAIMCODERF ";
            // --- ADD 2010/08/25 -------------------------------->>>>>
            if (paramWork.TotalDiv == (int)TotalDivs.Customer && paramWork.SearDiv == 1)
            {
                if (paramWork.St_SelectionCode != string.Empty)
                {
                    text += "  AND " + refName +"CUSTOMERCODERF>= " + Convert.ToInt32(paramWork.St_SelectionCode);
                    //SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODERF", SqlDbType.Int);
                    //paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paramWork.St_SelectionCode));
                }
                if (paramWork.Ed_SelectionCode != string.Empty)
                {
                    text += "  AND " + refName + "CUSTOMERCODERF<= " + Convert.ToInt32(paramWork.Ed_SelectionCode);
                    //SqlParameter paraCustomerCode2 = sqlCommand.Parameters.Add("@CUSTOMERCODERFED", SqlDbType.Int);
                    //paraCustomerCode2.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paramWork.Ed_SelectionCode));
                }
                text += "  AND " + refName + " CUSTOMERCODERF IN (SELECT CUSTOMERCODERF FROM CUSTOMERRF WHERE ENTERPRISECODERF=@ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine; // ADD 2010/09/20
            }
            // --- ADD 2010/08/25 --------------------------------<<<<<
            else if (paramWork.TotalDiv == (int)TotalDivs.Customer)
            {
                if (paramWork.CustomerCode != 0)
                {
                    text += "  AND " + refName + cusCode + "=@" + cusCode;
                    if (sqlCommand.Parameters.IndexOf("@" + cusCode) < 0)
                    {
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@" + cusCode, SqlDbType.Int);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCode);
                    }
                }
            }

            return text;
        }
        #endregion //[Cust�p Where�吶������]

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
            // �C�� 2008/09/22 >>>
            #region �C���O
            /*
            SalesAnnualDataSelectResultWork resultWork = new SalesAnnualDataSelectResultWork();

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
            if (paramWork.SearchDiv == 0) //0:�N�x����,1:�c���Ɖ�(�����E����),2:�c���Ɖ�(��������)
            {
                resultWork.AUPYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                resultWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESTARGETMONEY"));
                resultWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUM_SALESTARGETPROFIT"));
                // --- ADD 2010/08/25 -------------------------------->>>>>
                if (paramWork.SearDiv == 1)
                {
                    resultWork.SelectionCode = Convert.ToString(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")));
                }
                // --- ADD 2010/08/25 --------------------------------<<<<<

            }
            return resultWork;
        }
        #endregion //[CopyToSalesAnnualDataSelectResultWorkFromReader����]

    }
}

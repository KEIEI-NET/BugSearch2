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
    class MTtlSaSlip_Gcd : MTtlSaSlipBase, IMTtlSaSlip
    {
        #region [GcdSalesTarget�p Select��]
        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^�W�v�pSELECT�� �쐬����
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <returns>���i�ʔ���ڕW�ݒ�}�X�^�W�v�pSELECT��</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�W�v�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.06</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, paramWork);
        }
        #endregion  //[GcdSalesTarget�p Select��]

        #region [GcdSalesTarget�p Select����������]
        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^�W�v�pSELECT�� �쐬����
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <returns>���i�ʔ���ڕW�ݒ�}�X�^�W�v�pSELECT��</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�W�v�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.06</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork)
        {
            #region [���ʗp�t���O]
            //���_�R�[�h�����t���O
            bool bAddUpSecCode = false;
            if (paramWork.TtlType == 1)
            {
                bAddUpSecCode = true;
            }
            #endregion

            string selectTxt = "";

            // �Ώۃe�[�u��
            // MTTLSALESSLIPRF  MTSSLP ���㌎���W�v�f�[�^
            // GCDSALESTARGETRF GCSTGT ���i�ʔ���ڕW�ݒ�}�X�^
            // USERGDBDURF      USRGBU ���[�U�[�K�C�h�}�X�^(�{�f�B)
            // SECINFOSETRF     SCINST ���_���ݒ�}�X�^

            #region [Select���쐬]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  MTSSLP.ENTERPRISECODERF" + Environment.NewLine;
            //����^�C�v�ɂ���Ē��o���ڂ𓮓I��������
            switch (paramWork.PrintType)
            {
                #region [����^�C�v����]

                case (int)PrintType.Month:
                    #region [����]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLP");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "MTSSLP");
                    #endregion
                    break;
                case (int)PrintType.Annual:
                    #region [����]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLP");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "MTSSLP");
                    #endregion
                    break;
                case (int)PrintType.All:
                    #region [����������]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLP");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "MTSSLP");
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLP");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "MTSSLP");
                    #endregion
                    break;
                default:
                    break;

                #endregion  //[����^�C�v����]
            }
            //�o�͏��ɂ���Ē��o���ڂ𓮓I��������
            selectTxt += IFBy(bAddUpSecCode, " ,MTSSLP.ADDUPSECCODERF" + Environment.NewLine);
            selectTxt += IFBy(bAddUpSecCode, " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
            selectTxt += " ,MTSSLP.SALESCODERF" + Environment.NewLine;
            selectTxt += " ,USRGBU.GUIDENAMERF" + Environment.NewLine;

            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            #region [���㌎���W�v�f�[�^�{���i�ʔ���ڕW�ݒ�}�X�^���o�p�T�u�N�G��]
            selectTxt += " SELECT" + Environment.NewLine;
            selectTxt += "   MTSSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bAddUpSecCode, " ,MTSSLPSUB.ADDUPSECCODERF" + Environment.NewLine);
            selectTxt += "  ,MTSSLPSUB.SALESCODERF" + Environment.NewLine;
            //����^�C�v�ɂ���Ē��o���ڂ𓮓I��������
            switch (paramWork.PrintType)
            {
                #region [����^�C�v����]

                case (int)PrintType.Month:
                    #region [����]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLPM");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "GCSTGTM");
                    #endregion
                    break;
                case (int)PrintType.Annual:
                    #region [����]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLPA");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "GCSTGTA");
                    #endregion
                    break;
                case (int)PrintType.All:
                    #region [����������]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLPM");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "GCSTGTM");
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLPA");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "GCSTGTA");
                    #endregion
                    break;
                default:
                    break;

                #endregion  //[����^�C�v����]
            }

            //FROM
            // 2011/07/29 >>>
            //selectTxt += "  FROM MTTLSALESSLIPRF AS MTSSLPSUB" + Environment.NewLine;
            selectTxt += "  FROM MTTLSALESSLIPRF AS MTSSLPSUB WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<

            #region [�f�[�^���o���C��Query]

            //�������𒊏o���邩�ǂ���
            if (paramWork.PrintType != (int)PrintType.Annual)  //PrintType -> 0:���� 1:���� 2:����������
            {
                //�������W�v

                #region [���㌎���W�v�f�[�^]
                selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,MTSSLPSUB1.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += "    ,MTSSLPSUB1.SALESCODERF" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB1.SALESMONEYRF)" + Environment.NewLine;
                selectTxt += "      AS MONTHSALESMONEY" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB1.SALESRETGOODSPRICERF)" + Environment.NewLine;
                selectTxt += "      AS MONTHSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB1.DISCOUNTPRICERF)" + Environment.NewLine;
                selectTxt += "      AS MONTHDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB1.GROSSPROFITRF)" + Environment.NewLine;
                selectTxt += "      AS MONTHGROSSPROFIT" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB1" + Environment.NewLine;
                selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Month, "MTSSLPSUB1");
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,MTSSLPSUB1.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += "    ,MTSSLPSUB1.SALESCODERF" + Environment.NewLine;
                selectTxt += "  ) AS MTSSLPM" + Environment.NewLine;
                selectTxt += "  ON  MTSSLPM.ENTERPRISECODERF=MTSSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND MTSSLPM.SALESCODERF=MTSSLPSUB.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "  AND MTSSLPM.ADDUPSECCODERF=MTSSLPSUB.ADDUPSECCODERF" + Environment.NewLine);
                #endregion  //[���㌎���W�v�f�[�^]

                #region [���i�ʔ���ڕW�ݒ�}�X�^]
                selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     GCSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,GCSTGTSUB1.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,GCSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                selectTxt += "    ,SUM(GCSTGTSUB1.SALESTARGETMONEYRF)" + Environment.NewLine;
                selectTxt += "      AS MONTHSALESTARGETMONEY" + Environment.NewLine;
                selectTxt += "    ,SUM(GCSTGTSUB1.SALESTARGETPROFITRF)" + Environment.NewLine;
                selectTxt += "      AS MONTHSALESTARGETPROFIT" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB1" + Environment.NewLine;
                selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += MakeWhereString_GcdTgt(ref sqlCommand, paramWork, (int)PrintType.Month, "GCSTGTSUB1");
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     GCSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,GCSTGTSUB1.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,GCSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
                selectTxt += "  ) AS GCSTGTM" + Environment.NewLine;
                selectTxt += "  ON  GCSTGTM.ENTERPRISECODERF=MTSSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GCSTGTM.SALESCODERF=MTSSLPSUB.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "  AND GCSTGTM.SECTIONCODERF=MTSSLPSUB.ADDUPSECCODERF" + Environment.NewLine);
                #endregion  //[���i�ʔ���ڕW�ݒ�}�X�^]
            }

            //�������𒊏o���邩�ǂ���
            if (paramWork.PrintType != (int)PrintType.Month)  //PrintType -> 0:���� 1:���� 2:����������
            {
                //�������W�v]

                #region [���㌎���W�v�f�[�^]
                //selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                selectTxt += "  RIGHT JOIN (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,MTSSLPSUB2.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += "    ,MTSSLPSUB2.SALESCODERF" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB2.SALESMONEYRF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALSALESMONEY" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB2.SALESRETGOODSPRICERF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB2.DISCOUNTPRICERF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "    ,SUM(MTSSLPSUB2.GROSSPROFITRF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALGROSSPROFIT" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB2" + Environment.NewLine;
                selectTxt += "   FROM MTTLSALESSLIPRF AS MTSSLPSUB2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.Annual, "MTSSLPSUB2");
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     MTSSLPSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,MTSSLPSUB2.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += "    ,MTSSLPSUB2.SALESCODERF" + Environment.NewLine;
                selectTxt += "  ) AS MTSSLPA" + Environment.NewLine;
                selectTxt += "  ON  MTSSLPA.ENTERPRISECODERF=MTSSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND MTSSLPA.SALESCODERF=MTSSLPSUB.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "  AND MTSSLPA.ADDUPSECCODERF=MTSSLPSUB.ADDUPSECCODERF" + Environment.NewLine);
                #endregion  //[���㌎���W�v�f�[�^]

                #region [���i�ʔ���ڕW�ݒ�}�X�^]
                selectTxt += "  LEFT JOIN (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     GCSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,GCSTGTSUB2.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,GCSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                selectTxt += "    ,SUM(GCSTGTSUB2.SALESTARGETMONEYRF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALSALESTARGETMONEY" + Environment.NewLine;
                selectTxt += "    ,SUM(GCSTGTSUB2.SALESTARGETPROFITRF)" + Environment.NewLine;
                selectTxt += "      AS ANNUALSALESTARGETPROFIT" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB2" + Environment.NewLine;
                selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += MakeWhereString_GcdTgt(ref sqlCommand, paramWork, (int)PrintType.Annual, "GCSTGTSUB2");
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     GCSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,GCSTGTSUB2.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,GCSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
                selectTxt += "  ) AS GCSTGTA" + Environment.NewLine;
                selectTxt += "  ON  GCSTGTA.ENTERPRISECODERF=MTSSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GCSTGTA.SALESCODERF=MTSSLPSUB.SALESCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "  AND GCSTGTA.SECTIONCODERF=MTSSLPSUB.ADDUPSECCODERF" + Environment.NewLine);
                #endregion  //[���i�ʔ���ڕW�ݒ�}�X�^]
            }

            #endregion  //[�f�[�^���o���C��Query]

            //WHERE��
            selectTxt += MakeWhereString(ref sqlCommand, paramWork, (int)PrintType.All, "MTSSLPSUB");

            //GROUP BY
            selectTxt += " GROUP BY" + Environment.NewLine;
            selectTxt += "   MTSSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bAddUpSecCode,
                         "  ,MTSSLPSUB.ADDUPSECCODERF" + Environment.NewLine);
            selectTxt += "  ,MTSSLPSUB.SALESCODERF" + Environment.NewLine;
            switch (paramWork.PrintType)
            {
                #region [����^�C�v����]

                case (int)PrintType.Month:
                    #region [����]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLPM");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "GCSTGTM");
                    #endregion
                    break;
                case (int)PrintType.Annual:
                    #region [����]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLPA");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "GCSTGTA");
                    #endregion
                    break;
                case (int)PrintType.All:
                    #region [����������]
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Month, "MTSSLPM");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Month, "GCSTGTM");
                    selectTxt += GetPrintType_SQLCMD_MT((int)PrintType.Annual, "MTSSLPA");
                    selectTxt += GetPrintType_SQLCMD_ST((int)PrintType.Annual, "GCSTGTA");
                    #endregion
                    break;
                default:
                    break;

                #endregion  //[����^�C�v����]
            }

            #endregion  // [���㌎���W�v�f�[�^�{���i�ʔ���ڕW�ݒ�}�X�^���o�p�T�u�N�G��]

            selectTxt += " ) AS MTSSLP" + Environment.NewLine;

            #region [JOIN]
            //���[�U�[�K�C�h�}�X�^(�{�f�B)
            int iSalesCode = (int)UserGuideDivCd.SalesCode;
            // 2011/07/29 >>>
            //selectTxt += " LEFT JOIN USERGDBDURF USRGBU" + Environment.NewLine;
            selectTxt += " LEFT JOIN USERGDBDURF USRGBU WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            selectTxt += " ON  USRGBU.ENTERPRISECODERF=MTSSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USRGBU.USERGUIDEDIVCDRF=" + iSalesCode.ToString();
            selectTxt += " AND USRGBU.GUIDECODERF=MTSSLP.SALESCODERF";

            if (bAddUpSecCode)
            {
                //���_���ݒ�}�X�^
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  SCINST.ENTERPRISECODERF=MTSSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=MTSSLP.ADDUPSECCODERF" + Environment.NewLine;
            }
            #endregion  //[JOIN]

            #endregion  //[Select���쐬]

            return selectTxt;
        }
        #endregion  //[GcdSalesTarget�p Select����������]

        #region [MTtlSalesSlip�p Where�吶������]
        /// <summary>
        /// ���㌎���W�v�f�[�^�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="iPrintType">����^�C�v</param>
        /// <param name="sTblNm">�e�[�u����</param>
        /// <returns>���㌎���W�v�f�[�^�pWHERE��</returns>
        /// <br>Note       : ���㌎���W�v�f�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.06</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork, Int32 iPrintType, string sTblNm)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            retstring += " AND " + sTblNm + ".LOGICALDELETECODERF=0 " + Environment.NewLine;

            //���яW�v�敪
            retstring += " AND " + sTblNm + ".RSLTTTLDIVCDRF=0" + Environment.NewLine;

            //�]�ƈ��敪
            retstring += " AND " + sTblNm + ".EMPLOYEEDIVCDRF=@" + sTblNm + "EMPLOYEEDIVCD" + Environment.NewLine;
            SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@" + sTblNm + "EMPLOYEEDIVCD", SqlDbType.Int);
            paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)EmployeeDivCd.Agent);

            //���_�R�[�h
            if (paramWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in paramWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND " + sTblNm + ".ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�Ώ۔N��
            if (iPrintType == (int)PrintType.Month)
            {
                //����
                retstring += " AND " + sTblNm + ".ADDUPYEARMONTHRF>=@" + sTblNm + "ADDUPYEARMONTHST" + Environment.NewLine;
                SqlParameter paraAddUpYearMonthSt = sqlCommand.Parameters.Add("@" + sTblNm + "ADDUPYEARMONTHST", SqlDbType.Int);
                paraAddUpYearMonthSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AddUpYearMonthSt);

                retstring += " AND " + sTblNm + ".ADDUPYEARMONTHRF<=@" + sTblNm + "ADDUPYEARMONTHED" + Environment.NewLine;
                SqlParameter paraAddUpYearMonthEd = sqlCommand.Parameters.Add("@" + sTblNm + "ADDUPYEARMONTHED", SqlDbType.Int);
                paraAddUpYearMonthEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AddUpYearMonthEd);
            }
            if (iPrintType == (int)PrintType.Annual)
            {
                //����
                retstring += " AND " + sTblNm + ".ADDUPYEARMONTHRF>=@AN" + sTblNm + "ADDUPYEARMONTHST" + Environment.NewLine;
                SqlParameter paraANAddUpYearMonthSt = sqlCommand.Parameters.Add("@AN" + sTblNm + "ADDUPYEARMONTHST", SqlDbType.Int);
                paraANAddUpYearMonthSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AnnualAddUpYearMonthSt);

                retstring += " AND " + sTblNm + ".ADDUPYEARMONTHRF<=@AN" + sTblNm + "ADDUPYEARMONTHED" + Environment.NewLine;
                SqlParameter paraANAddUpYearMonthEd = sqlCommand.Parameters.Add("@AN" + sTblNm + "ADDUPYEARMONTHED", SqlDbType.Int);
                paraANAddUpYearMonthEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AnnualAddUpYaerMonthEd);
            }

            //���Ӑ�R�[�h
            if (paramWork.CustomerCodeSt != 0)
            {
                retstring += " AND " + sTblNm + ".CUSTOMERCODERF>=@" + sTblNm + "CUSTOMERCODEST" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeSt);
            }
            if (paramWork.CustomerCodeEd != 999999999)
            {
                retstring += " AND " + sTblNm + ".CUSTOMERCODERF<=@" + sTblNm + "CUSTOMERCODEED" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeEd);
            }

            //�̔��敪�R�[�h
            //if (paramWork.SrchCodeSt != "")// DEL 2008.12.08
            if (paramWork.SrchCodeSt != "" && paramWork.SrchCodeSt != null) // ADD 2008.12.08
            {
                Int32 iSalesCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //�p�����[�^�̃L���X�g
                retstring += " AND " + sTblNm + ".SALESCODERF>=@" + sTblNm + "SALESCODEST" + Environment.NewLine;
                SqlParameter paraSrchCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEST", SqlDbType.Int);
                paraSrchCodeSt.Value = SqlDataMediator.SqlSetInt32(iSalesCodeSt);
            }
            //if ((paramWork.SrchCodeEd != ""))// DEL 2008.12.08
            if ((paramWork.SrchCodeEd != "") && (paramWork.SrchCodeEd != null))// ADD 2008.12.08
            {
                Int32 iSalesCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //�p�����[�^�̃L���X�g
                retstring += " AND " + sTblNm + ".SALESCODERF<=@" + sTblNm + "SALESCODEED" + Environment.NewLine;
                SqlParameter paraSrchCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEED", SqlDbType.Int);
                paraSrchCodeEd.Value = SqlDataMediator.SqlSetInt32(iSalesCodeEd);
            }
            #endregion

            return retstring;
        }
        #endregion  //[MTtlSalesSlip�p Where�吶������]

        #region [GcdSalesTarget�p Where�吶������]
        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">��������</param>
        /// <returns>���i�ʔ���ڕW�ݒ�}�X�^�pWHERE��</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.06</br>
        private string MakeWhereString_GcdTgt(ref SqlCommand sqlCommand, SalesMonthYearReportParamWork paramWork, Int32 iPrintType, string sTblNm)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�̔��敪�R�[�h
            //if (paramWork.SrchCodeSt != "") // DEL 2008.12.08
            if (paramWork.SrchCodeSt != "" && paramWork.SrchCodeSt != null) // ADD 2008.12.08 
            {
                Int32 iSalesCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //�p�����[�^�̃L���X�g
                retstring += " AND " + sTblNm + ".SALESCODERF>=@" + sTblNm + "SALESCODEST" + Environment.NewLine;
                SqlParameter paraSrchCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEST", SqlDbType.Int);
                paraSrchCodeSt.Value = SqlDataMediator.SqlSetInt32(iSalesCodeSt);
            }
            //if ((paramWork.SrchCodeEd != "")) // DEL 2008.12.08
            if ((paramWork.SrchCodeEd != "") && (paramWork.SrchCodeEd != null)) // ADD 2008.12.08
            {
                Int32 iSalesCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //�p�����[�^�̃L���X�g
                retstring += " AND " + sTblNm + ".SALESCODERF<=@" + sTblNm + "SALESCODEED" + Environment.NewLine;
                SqlParameter paraSrchCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEED", SqlDbType.Int);
                paraSrchCodeEd.Value = SqlDataMediator.SqlSetInt32(iSalesCodeEd);
            }
            // ADD 2008.12.08 >>>
            retstring += " AND " + sTblNm + ".TARGETCONTRASTCDRF=44" + Environment.NewLine;

            //�Ώ۔N��
            if (iPrintType == (int)PrintType.Month)
            {
                //����
                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF>=@" + sTblNm + "TARGETDIVIDECODEST" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "TARGETDIVIDECODEST", SqlDbType.Int);
                paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AddUpYearMonthSt);

                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF<=@" + sTblNm + "TARGETDIVIDECODEED" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "TARGETDIVIDECODEED", SqlDbType.Int);
                paraTargetDivideCodeEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AddUpYearMonthEd);
            }
            if (iPrintType == (int)PrintType.Annual)
            {
                //����
                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF>=@AN" + sTblNm + "TARGETDIVIDECODEST" + Environment.NewLine;
                SqlParameter paraANTargetDivideCodeSt = sqlCommand.Parameters.Add("@AN" + sTblNm + "TARGETDIVIDECODEST", SqlDbType.Int);
                paraANTargetDivideCodeSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AnnualAddUpYearMonthSt);

                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF<=@AN" + sTblNm + "TARGETDIVIDECODEED" + Environment.NewLine;
                SqlParameter paraANTargetDivideCodeEd = sqlCommand.Parameters.Add("@AN" + sTblNm + "TARGETDIVIDECODEED", SqlDbType.Int);
                paraANTargetDivideCodeEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.AnnualAddUpYaerMonthEd);
            }
            // ADD 2008.12.08 <<<
            #endregion

            return retstring;
        }
        #endregion  //[GcdSalesTarget�p Where�吶������]

        #region [SalesMonthYearReportResultWork���� �ďo]
        /// <summary>
        /// �N���X�i�[���� Reader �� SalesMonthYearReportResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesMonthYearReportResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.06</br>
        /// <br></br>
        /// </remarks>
        public SalesMonthYearReportResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader, SalesMonthYearReportParamWork paramWork)
        {
            return this.CopyToResultWorkFromReaderProc(ref myReader, paramWork);
        }
        #endregion  //[SalesMonthYearReportResultWork���� �ďo]

        #region [SalesMonthYearReportResultWork����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SalesMonthYearReportResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesMonthYearReportResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.06</br>
        /// <br></br>
        /// </remarks>
        private SalesMonthYearReportResultWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, SalesMonthYearReportParamWork paramWork)
        {
            #region [���o����-�l�Z�b�g]
            SalesMonthYearReportResultWork resultWork = new SalesMonthYearReportResultWork();

            Int32 iSalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
            resultWork.Code = iSalesCode.ToString();
            resultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));

            if (paramWork.TtlType == 1)
            {
                resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                resultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            }

            if (paramWork.PrintType != (int)PrintType.Annual)  //PrintType -> 0:���� 1:���� 2:����������
            {
                //������
                resultWork.MonthSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESMONEY"));
                resultWork.MonthSalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESRETGOODSPRICE"));
                resultWork.MonthDiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHDISCOUNTPRICE"));
                resultWork.MonthSalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESTARGETMONEY"));
                resultWork.MonthGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHGROSSPROFIT"));
                resultWork.MonthSalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESTARGETPROFIT"));
            }
            if (paramWork.PrintType != (int)PrintType.Month)  //PrintType -> 0:���� 1:���� 2:����������
            {
                //������
                resultWork.AnnualSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALSALESMONEY"));
                resultWork.AnnualSalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALSALESRETGOODSPRICE"));
                resultWork.AnnualDiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALDISCOUNTPRICE"));
                resultWork.AnnualSalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALSALESTARGETMONEY"));
                resultWork.AnnualGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALGROSSPROFIT"));
                resultWork.AnnualSalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALSALESTARGETPROFIT"));
            }
            #endregion

            return resultWork;
        }
        #endregion  //[SalesMonthYearReportResultWork����]
    }
}


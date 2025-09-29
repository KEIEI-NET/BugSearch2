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
    class SalesSlipReport_Gcd : SalesSlipReportBase, ISalesSlipReport
    {
        #region [���ʗp�t���O�錾]
        private bool bSectionCode = false;  //���_�R�[�h�����t���O
        #endregion  //[���ʗp�t���O�錾]

        #region [GcdSalesTarget�p Select��]
        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^�pSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">������</param>
        /// <returns>���i�ʔ���ڕW�ݒ�}�X�^�pSELECT��</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.06</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, paramWork);
        }
        #endregion  //[GcdSalesTarget�p Select��]

        #region [GcdSalesTarget�p Select����������]
        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^�pSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">������</param>
        /// <returns>���i�ʔ���ڕW�ݒ�}�X�^�pSELECT��</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.06</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork)
        {
            #region [���ʗp�t���O]
            //���_�R�[�h�����t���O
            if (paramWork.TtlType == 1)
            {
                bSectionCode = true;
            }
            #endregion

            // �Ώۃe�[�u��
            // SALESHISTORYRF   SALHIS ���㗚���f�[�^
            // SALESHISTDTLRF   SALHID ���㗚�𖾍׃f�[�^
            // GCDSALESTARGETRF GCSTGT ���i�ʔ���ڕW�ݒ�}�X�^
            // USERGDBDURF      USRGBU ���[�U�[�K�C�h�}�X�^(�{�f�B)
            // SECINFOSETRF     SCINST ���_���ݒ�}�X�^

            string selectTxt = "";

            #region [Select���쐬]

            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  SALHIS.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " ,SALHIS.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += " ,SALHIS.TERMSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += " ,SALHIS.TERMSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += " ,SALHIS.TERMSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += " ,SALHIS.TERMSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += " ,SALHIS.TERMTOTALCOST" + Environment.NewLine;
            selectTxt += " ,SALHIS.TERMSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += " ,SALHIS.TERMSALESTARGETPROFIT" + Environment.NewLine;
            selectTxt += " ,SALHIS.MONTHSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += " ,SALHIS.MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += " ,SALHIS.MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += " ,SALHIS.MONTHSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += " ,SALHIS.MONTHTOTALCOST" + Environment.NewLine;
            selectTxt += " ,SALHIS.MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += " ,SALHIS.MONTHSALESTARGETPROFIT" + Environment.NewLine;
            selectTxt += " ,SALHIS.SALESCODERF" + Environment.NewLine;
            selectTxt += " ,USRGBU.GUIDENAMERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode, " ,SALHIS.SECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bSectionCode, " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);

            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            #region [���㗚�𖾍׃f�[�^�{���i�ʔ���ڕW�ݒ�}�X�^���o�p�T�u�N�G��]
            selectTxt += "  SELECT" + Environment.NewLine;
            //selectTxt += "   SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  ,SALHIST.SALESSLIPCDRF" + Environment.NewLine;
            //selectTxt += "  ,SALHIST.SALESCODERF" + Environment.NewLine;
            selectTxt += "   SALHISMSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.SALESCODERF" + Environment.NewLine;

            selectTxt += "  ,SALHIST.TERMSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMTOTALCOST" + Environment.NewLine;
            selectTxt += "  ,GCSTGTT.TERMSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "  ,GCSTGTT.TERMSALESTARGETPROFIT" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHTOTALCOST" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += IFBy(bSectionCode,
            //             "  ,SALHIST.SECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bSectionCode,
                         "  ,SALHISMSUB.SECTIONCODERF" + Environment.NewLine);

            //FROM
            selectTxt += "  FROM" + Environment.NewLine;
            selectTxt += "  (" + Environment.NewLine;

            #region [�f�[�^���o���C��Query]

            #region [���ԕ����oQuery]
            //���㗚�𖾍׃f�[�^
            selectTxt += MakeSubQueryString(ref sqlCommand, paramWork, "SALHISSUB1", 0);
            selectTxt += "  ) AS SALHIST" + Environment.NewLine;

            //���i�ʔ���ڕW�ݒ�}�X�^
            selectTxt += "  LEFT JOIN (" + Environment.NewLine;
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     GCSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,GCSTGTSUB1.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,GCSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "    ,SUM(GCSTGTSUB1.SALESTARGETMONEYRF)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,SUM(GCSTGTSUB1.SALESTARGETPROFITRF)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB1" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB1 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            selectTxt += MakeWhereString_Gcd(ref sqlCommand, paramWork, "GCSTGTSUB1",0);
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     GCSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,GCSTGTSUB1.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,GCSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "  ) AS GCSTGTT" + Environment.NewLine;
            selectTxt += "  ON  GCSTGTT.ENTERPRISECODERF=SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND GCSTGTT.SALESCODERF=SALHIST.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "  AND GCSTGTT.SECTIONCODERF=SALHIST.SECTIONCODERF" + Environment.NewLine);
            #endregion  //[���ԕ����oQuery]

            #region [���������oQuery]
            //���㗚�𖾍׃f�[�^
            //selectTxt += "  LEFT JOIN (" + Environment.NewLine;
            selectTxt += "  RIGHT JOIN (" + Environment.NewLine;
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     SALHISM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISM.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "    ,SALHISM.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,SALHISM.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "    ,SALHISM.MONTHSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHTOTALCOST" + Environment.NewLine;
            selectTxt += "    ,GCSTGTM.MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,GCSTGTM.MONTHSALESTARGETPROFIT" + Environment.NewLine;
            selectTxt += "   FROM" + Environment.NewLine;
            selectTxt += "   (" + Environment.NewLine;
            selectTxt += MakeSubQueryString(ref sqlCommand, paramWork, "SALHISSUB2", 1);
            selectTxt += "  ) AS SALHISM" + Environment.NewLine;

            //���i�ʔ���ڕW�ݒ�}�X�^
            selectTxt += "  LEFT JOIN (" + Environment.NewLine;
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     GCSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,GCSTGTSUB2.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,GCSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "    ,SUM(GCSTGTSUB2.SALESTARGETMONEYRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,SUM(GCSTGTSUB2.SALESTARGETPROFITRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB2" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += "   FROM GCDSALESTARGETRF AS GCSTGTSUB2 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            selectTxt += MakeWhereString_Gcd(ref sqlCommand, paramWork, "GCSTGTSUB2",1);
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     GCSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,GCSTGTSUB2.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,GCSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "  ) AS GCSTGTM" + Environment.NewLine;
            selectTxt += "  ON  GCSTGTM.ENTERPRISECODERF=SALHISM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND GCSTGTM.SALESCODERF=SALHISM.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "  AND GCSTGTM.SECTIONCODERF=SALHISM.SECTIONCODERF" + Environment.NewLine);
            #endregion  //[���������oQuery]

            #endregion  //[�f�[�^���o���C��Query]

            //���ԕ��Ɠ������̌�������
            selectTxt += "  ) AS SALHISMSUB" + Environment.NewLine;
            selectTxt += "  ON  SALHISMSUB.ENTERPRISECODERF=SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SALHISMSUB.SALESSLIPCDRF=SALHIST.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "  AND SALHISMSUB.SALESCODERF=SALHIST.SALESCODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "  AND SALHISMSUB.SECTIONCODERF=SALHIST.SECTIONCODERF" + Environment.NewLine);

            #endregion //[���㗚�𖾍׃f�[�^�{���i�ʔ���ڕW�ݒ�}�X�^���o�p�T�u�N�G��]

            selectTxt += " ) AS SALHIS" + Environment.NewLine;

            #region [JOIN]
            //���[�U�[�K�C�h�}�X�^(�{�f�B)
            int iSalesCode = (int)UserGuideDivCd.SalesCode;
            //selectTxt += " LEFT JOIN USERGDBDURF USRGBU" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += " LEFT JOIN USERGDBDURF USRGBU WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            selectTxt += " ON  USRGBU.ENTERPRISECODERF=SALHIS.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USRGBU.USERGUIDEDIVCDRF=" + iSalesCode.ToString();
            selectTxt += " AND USRGBU.GUIDECODERF=SALHIS.SALESCODERF";

            if (bSectionCode)
            {
                //���_���ݒ�}�X�^
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " ON  SCINST.ENTERPRISECODERF=SALHIS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=SALHIS.SECTIONCODERF" + Environment.NewLine;
            }
            #endregion  //[JOIN]

            #endregion  //[Select���쐬]

            return selectTxt;
        }
        #endregion  //[GcdSalesTarget�p Select����������]

        #region [���㗚�𖾍׃f�[�^�p SubQuery��������]
        /// <summary>
        /// ���㗚�𖾍׃f�[�^�pSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">������</param>
        /// <param name="sTblNm">�e�[�u������</param>
        /// <param name="iType">0:���� 1:����</param>
        /// <returns>���㗚�𖾍׃f�[�^�pSELECT��</returns>
        /// <br>Note       : ���㗚�𖾍׃f�[�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.06</br>
        private string MakeSubQueryString(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork, string sTblNm, int iType)
        {
            string sType = "";
            if (iType == 0)
                sType = "TERM";
            else
                sType = "MONTH";

            string retstring = "";

            #region [���㗚�𖾍׃f�[�^���o�T�uQuery]
            retstring += " SELECT" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".SALESSLIPCDRF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".SALESCODERF" + Environment.NewLine;
            retstring += IFBy(bSectionCode,
                         "  ," + sTblNm + ".SECTIONCODERF" + Environment.NewLine);
            retstring += "  ,COUNT(" + sTblNm + ".SALESSLIPNUMRF) AS " + sType + "SALESSLIPCOUNT" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".SALESTOTALTAXEXC + " + sTblNm + ".SALESDISTTLTAXEXCGYO ) AS " + sType + "SALESTOTALTAXEXC" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".SALESBACKTOTALTAXEXC + " + sTblNm + ".RETSALESDISTTLTAXEXCGYO ) AS " + sType + "SALESBACKTOTALTAXEXC" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".SALESDISTTLTAXEXC) AS " + sType + "SALESDISTTLTAXEXC" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".TOTALCOST) AS " + sType + "TOTALCOST" + Environment.NewLine;
            retstring += " FROM" + Environment.NewLine;
            retstring += " (" + Environment.NewLine;

            #region [���㗚�𖾍׃f�[�^���o]
            retstring += "  SELECT" + Environment.NewLine;
            retstring += "    " + sTblNm + "SUB.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "   ," + sTblNm + "SUB.SALESSLIPCDRF" + Environment.NewLine;
            retstring += "   ," + sTblNm + "SUB.CUSTOMERCODERF" + Environment.NewLine;
            //retstring += "   ,SALHID" + sTblNm + ".SECTIONCODERF" + Environment.NewLine;// DEL 2008.12.08
            retstring += "   ," + sTblNm + "SUB.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine; // ADD 2008.12.08
            retstring += "   ,SALHID" + sTblNm + ".SALESCODERF" + Environment.NewLine;
            retstring += "   ,SALHID" + sTblNm + ".SALESSLIPNUMRF" + Environment.NewLine;
            //retstring += "   ,(CASE WHEN " + sTblNm + "SUB.SALESSLIPCDRF=0 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //retstring += "   ,(CASE WHEN SALHID" + sTblNm + ".SALESSLIPCDDTLRF=0 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "   ,(CASE WHEN " + sTblNm + "SUB.SALESSLIPCDRF=0 AND SALHID" + sTblNm + ".SALESSLIPCDDTLRF!=2 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "    AS SALESTOTALTAXEXC" + Environment.NewLine;
            //retstring += "   ,(CASE WHEN " + sTblNm + "SUB.SALESSLIPCDRF=1 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //retstring += "   ,(CASE WHEN SALHID" + sTblNm + ".SALESSLIPCDDTLRF=1 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "   ,(CASE WHEN " + sTblNm + "SUB.SALESSLIPCDRF=1 AND SALHID" + sTblNm + ".SALESSLIPCDDTLRF!=2 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "    AS SALESBACKTOTALTAXEXC" + Environment.NewLine;
            //retstring += "   ,(CASE WHEN " + sTblNm + "SUB.SALESSLIPCDRF=2 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "   ,(CASE WHEN SALHID" + sTblNm + ".SALESSLIPCDDTLRF=2 AND SALHID" + sTblNm + ".SHIPMENTCNTRF != 0 THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "    AS SALESDISTTLTAXEXC" + Environment.NewLine;

            retstring += "   ,(CASE WHEN " + sTblNm + "SUB.SALESSLIPCDRF=0 AND SALHID" + sTblNm + ".SALESSLIPCDDTLRF=2 AND SALHID" + sTblNm + ".SHIPMENTCNTRF = 0 " + Environment.NewLine;
            retstring += "     THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "    AS SALESDISTTLTAXEXCGYO" + Environment.NewLine;
            retstring += "   ,(CASE WHEN " + sTblNm + "SUB.SALESSLIPCDRF=1 AND SALHID" + sTblNm + ".SALESSLIPCDDTLRF=2 AND SALHID" + sTblNm + ".SHIPMENTCNTRF = 0 " + Environment.NewLine;
            retstring += "     THEN SALHID" + sTblNm + ".SALESMONEYTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            retstring += "    AS RETSALESDISTTLTAXEXCGYO" + Environment.NewLine;

            // �C�� 2009.02.06 >>>
            //retstring += "   ,SALHID" + sTblNm + ".SALESMONEYTAXEXCRF-SALHID" + sTblNm + ".COSTRF" + Environment.NewLine;
            retstring += "   ,SALHID" + sTblNm + ".COSTRF" + Environment.NewLine;
            // �C�� 2009.02.06 <<<            
            retstring += "    AS TOTALCOST" + Environment.NewLine;
            //----- Del 2012/02/28 zhangyong for Redmine#28712----->>>>>>>
            //retstring += "  FROM SALESHISTORYRF AS " + sTblNm + "SUB" + Environment.NewLine;
            //retstring += "  LEFT JOIN SALESHISTDTLRF SALHID" + sTblNm + Environment.NewLine;
            //----- Del 2012/02/28 zhangyong for Redmine#28712-----<<<<<<<
            //----- Add 2012/02/28 zhangyong for Redmine#28712----->>>>>>>
            retstring += "  FROM SALESHISTORYRF AS " + sTblNm + "SUB WITH (READUNCOMMITTED)" + Environment.NewLine;
            retstring += "  LEFT JOIN SALESHISTDTLRF SALHID" + sTblNm + " WITH (READUNCOMMITTED)" + Environment.NewLine;
            //----- Add 2012/02/28 zhangyong for Redmine#28712-----<<<<<<<
            retstring += "  ON  SALHID" + sTblNm + ".ENTERPRISECODERF=" + sTblNm + "SUB.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  AND SALHID" + sTblNm + ".ACPTANODRSTATUSRF=" + sTblNm + "SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
            retstring += "  AND SALHID" + sTblNm + ".SALESSLIPNUMRF=" + sTblNm + "SUB.SALESSLIPNUMRF" + Environment.NewLine;
            retstring += MakeWhereString(ref sqlCommand, paramWork, sTblNm, iType);
            #endregion  //[���㗚�𖾍׃f�[�^���o]

            retstring += " ) AS " + sTblNm + Environment.NewLine;

            #region [GROUP BY]
            retstring += " GROUP BY" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".SALESSLIPCDRF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".SALESCODERF" + Environment.NewLine;
            retstring += IFBy(bSectionCode,
                         "  ," + sTblNm + ".SECTIONCODERF" + Environment.NewLine);
            #endregion  //[GROUP BY]

            #endregion  //[���㗚�𖾍׃f�[�^���o�T�uQuery]

            return retstring;
        }
        #endregion  //[���㗚�𖾍׃f�[�^�p SubQuery��������]

        #region [SalesHistory�p Where�吶������]
        /// <summary>
        /// ���㗚���f�[�^�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">��������</param>
        /// <param name="sTblNm">�e�[�u������</param>
        /// <param name="iType">0:���� 1:����</param>
        /// <returns>���㗚���f�[�^�pWHERE��</returns>
        /// <br>Note       : ���㗚���f�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.13</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork, string sTblNm, int iType)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " " + sTblNm + "SUB.ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            retstring += " AND " + sTblNm + "SUB.LOGICALDELETECODERF=0 " + Environment.NewLine;

            //�󒍃X�e�[�^�X
            retstring += " AND " + sTblNm + "SUB.ACPTANODRSTATUSRF=30" + Environment.NewLine;

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
                    //retstring += " AND " + sTblNm + "SUB.SECTIONCODERF IN (" + sectionCodestr + ") "; // DEL 2008.12.08
                    retstring += " AND " + sTblNm + "SUB.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";// ADD 2008.12.08
                }
                retstring += Environment.NewLine;
            }

            //�Ώۓ��t
            if (iType == 0)
            {
                //�J�n�Ώ۔N����(����)
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //retstring += " AND " + sTblNm + "SUB.SALESDATERF>=@" + sTblNm + "SALESDATEST" + Environment.NewLine;
                retstring += " AND " + sTblNm + "SUB.SALESDATERF>=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateSt).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESDATEST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateSt);
                
                //�I���Ώ۔N����(����)
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //retstring += " AND " + sTblNm + "SUB.SALESDATERF<=@" + sTblNm + "SALESDATEED" + Environment.NewLine;
                retstring += " AND " + sTblNm + "SUB.SALESDATERF<=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateEd).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESDATEED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateEd);

            }
            else
            {
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //�J�n�Ώ۔N����(����)
                //retstring += " AND " + sTblNm + "SUB.SALESDATERF>=@MO" + sTblNm + "SALESDATEST" + Environment.NewLine;
                retstring += " AND " + sTblNm + "SUB.SALESDATERF>=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateSt).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraMOSalesDateSt = sqlCommand.Parameters.Add("@MO" + sTblNm + "SALESDATEST", SqlDbType.Int);
                paraMOSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateSt);

                //�I���Ώ۔N����(����)
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //retstring += " AND " + sTblNm + "SUB.SALESDATERF<=@MO" + sTblNm + "SALESDATEED" + Environment.NewLine;
                retstring += " AND " + sTblNm + "SUB.SALESDATERF<=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateEd).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraMOSalesDateEd = sqlCommand.Parameters.Add("@MO" + sTblNm + "SALESDATEED", SqlDbType.Int);
                paraMOSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateEd);

            }

            //���Ӑ�R�[�h
            if (paramWork.CustomerCodeSt != 0)
            {
                retstring += " AND " + sTblNm + "SUB.CUSTOMERCODERF>=@" + sTblNm + "CUSTOMERCODEST" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeSt);
            }
            if (paramWork.CustomerCodeEd != 99999999)
            {
                retstring += " AND " + sTblNm + "SUB.CUSTOMERCODERF<=@" + sTblNm + "CUSTOMERCODEED" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeEd);
            }

            //�̔��敪�R�[�h
            if (paramWork.SrchCodeSt != "")
            {
                Int32 iSalesCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //�p�����[�^�̃L���X�g
                retstring += " AND SALHID" + sTblNm + ".SALESCODERF>=@" + sTblNm + "SALESCODEST" + Environment.NewLine;
                SqlParameter paraSrchCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEST", SqlDbType.Int);
                paraSrchCodeSt.Value = SqlDataMediator.SqlSetInt32(iSalesCodeSt);
            }
            if ((paramWork.SrchCodeEd != ""))
            {
                Int32 iSalesCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //�p�����[�^�̃L���X�g
                retstring += " AND SALHID" + sTblNm + ".SALESCODERF<=@" + sTblNm + "SALESCODEED" + Environment.NewLine;
                SqlParameter paraSrchCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEED", SqlDbType.Int);
                paraSrchCodeEd.Value = SqlDataMediator.SqlSetInt32(iSalesCodeEd);
            }
            #endregion

            return retstring;
        }
        #endregion  //[SalesHistory�p Where�吶������]

        #region [GcdSalesTarget�p Where�吶������]
        /// <summary>
        /// ���i�ʔ���ڕW�ݒ�}�X�^�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">��������</param>
        /// <returns>���i�ʔ���ڕW�ݒ�}�X�^�pWHERE��</returns>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.13</br>
        /// <br>UpdateNote : 2012/05/22 ������ </br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 06/27�z�M��</br>
        /// <br>             Redmine#29898 ������񌎕� �i�����Z�o���ɉc�Ɠ����Q�Ƃ��Ă��Ȃ��p�^�[�������݂���</br> 
        private string MakeWhereString_Gcd(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork, string sTblNm, Int32 iPrintType)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�̔��敪�R�[�h
            if (paramWork.SrchCodeSt != "")
            {
                Int32 iSalesCodeSt = Int32.Parse(paramWork.SrchCodeSt);  //�p�����[�^�̃L���X�g
                retstring += " AND " + sTblNm + ".SALESCODERF>=@" + sTblNm + "SALESCODEST" + Environment.NewLine;
                SqlParameter paraSrchCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEST", SqlDbType.Int);
                paraSrchCodeSt.Value = SqlDataMediator.SqlSetInt32(iSalesCodeSt);
            }
            if ((paramWork.SrchCodeEd != ""))
            {
                Int32 iSalesCodeEd = Int32.Parse(paramWork.SrchCodeEd);  //�p�����[�^�̃L���X�g
                retstring += " AND " + sTblNm + ".SALESCODERF<=@" + sTblNm + "SALESCODEED" + Environment.NewLine;
                SqlParameter paraSrchCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESCODEED", SqlDbType.Int);
                paraSrchCodeEd.Value = SqlDataMediator.SqlSetInt32(iSalesCodeEd);
            }
            // --------------- ADD START 2012/05/22 Redmine#29898 ������-------->>>>
            if (paramWork.TtlType == 0)
            {
                //�W�v���@�F�S��
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
                    retstring += " AND " + sTblNm + ".SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }
            // --------------- ADD END 2012/05/22 Redmine#29898 ������--------<<<<
            // ADD 2008.12.26 >>>
            if (iPrintType == 0) // �Ώۊ���
            {
                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF>=@" + sTblNm + "TARGETDIVIDECODEST" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "TARGETDIVIDECODEST", SqlDbType.Int);
                // �C�� 2009.01.16 >>>
                //paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.SalesDateSt);
                paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.TargetYearMonthSt);
                // �C�� 2009.01.16 <<<

                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF<=@" + sTblNm + "TARGETDIVIDECODEED" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "TARGETDIVIDECODEED", SqlDbType.Int);
                // �C�� 2009.01.16 >>>
                //paraTargetDivideCodeEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.SalesDateEd);
                paraTargetDivideCodeEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.TargetYearMonthEd);
                // �C�� 2009.01.16 <<<
            }
            else if (iPrintType == 1) // ����
            {
                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF>=@" + sTblNm + "TARGETDIVIDECODEST" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "TARGETDIVIDECODEST", SqlDbType.Int);
                // �C�� 2009.01.16 >>>
                //paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.MonthReportDateSt);
                paraTargetDivideCodeSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.TargetYearMonthSt);
                // �C�� 2009.01.16 <<<

                retstring += " AND " + sTblNm + ".TARGETDIVIDECODERF<=@" + sTblNm + "TARGETDIVIDECODEED" + Environment.NewLine;
                SqlParameter paraTargetDivideCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "TARGETDIVIDECODEED", SqlDbType.Int);
                // �C�� 2009.01.16 >>>
                //paraTargetDivideCodeEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.MonthReportDateEd);
                paraTargetDivideCodeEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paramWork.TargetYearMonthEd);
                // �C�� 2009.01.16 <<<
            }
            // ADD 2008.12.26 <<<

            #endregion

            return retstring;
        }
        #endregion  //[GcdSalesTarget�p Where�吶������]

        #region [SalesDayMonthReportResultWork���� �ďo]
        /// <summary>
        /// �N���X�i�[���� Reader �� SalesDayMonthReportResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesDayMonthReportResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.13</br>
        /// </remarks>
        public SalesDayMonthReportResultWork CopyToResultWorkFromReader(ref SqlDataReader myReader, SalesDayMonthReportParamWork paramWork)
        {
            return this.CopyToResultWorkFromReaderProc(ref myReader, paramWork);
        }
        #endregion  //[SalesDayMonthReportResultWork���� �ďo]

        #region [SalesDayMonthReportResultWork����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SalesDayMonthReportResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesDayMonthReportResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.13</br>
        /// </remarks>
        private SalesDayMonthReportResultWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, SalesDayMonthReportParamWork paramWork)
        {
            #region [���o����-�l�Z�b�g]
            SalesDayMonthReportResultWork resultWork = new SalesDayMonthReportResultWork();

            Int32 iSalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
            resultWork.Code = iSalesCode.ToString();
            resultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));

            if (paramWork.TtlType == 1)
            {
                resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                resultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            }

            resultWork.TermSalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TERMSALESSLIPCOUNT"));
            resultWork.TermSalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTOTALTAXEXC"));
            resultWork.TermSalesBackTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESBACKTOTALTAXEXC"));
            resultWork.TermSalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESDISTTLTAXEXC"));
            resultWork.TermTotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMTOTALCOST"));
            resultWork.TermSalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTARGETMONEY"));
            resultWork.TermSalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTARGETPROFIT"));
            resultWork.MonthSalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHSALESSLIPCOUNT"));
            resultWork.MonthSalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESTOTALTAXEXC"));
            resultWork.MonthSalesBackTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESBACKTOTALTAXEXC"));
            resultWork.MonthSalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESDISTTLTAXEXC"));
            resultWork.MonthTotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHTOTALCOST"));
            resultWork.MonthSalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESTARGETMONEY"));
            resultWork.MonthSalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESTARGETPROFIT"));
            #endregion

            return resultWork;
        }
        #endregion  //[SalesDayMonthReportResultWork����]
    }
}

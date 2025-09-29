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
    /// <summary>
    /// �]�ƈ��ʗp
    /// </summary>
    /// <remarks>
    /// <br>Update Note: ���x�A�b�v�Ή�</br>
    /// <br>           : 22008 ���� ���n</br>
    /// <br>           : 2009/10/09</br>
    /// <br>Update Note: Redmine#28712 ReadUnCommitted�Ή�</br>
    /// <br>           : zhangyong</br>
    /// <br>           : 2012/02/28</br>
    /// <br>Update Note: 2012/05/22 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 06/27�z�M��</br>
    /// <br>             Redmine#29898   ������񌎕� �i�����Z�o���ɉc�Ɠ����Q�Ƃ��Ă��Ȃ��p�^�[�������݂���</br>
    /// <br>Update Note: 2013/02/06 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 03/13�z�M��</br>
    /// <br>             Redmine#34586   No.1158�@�O�a���i�@������񌎕�i�󒍎ҕʁj</br>
    /// <br>Update Note: 2015/12/21 �������n</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00 </br>
    /// <br>             �C�X�R�̊��ɂē��Ӑ�ʂőS�Ѓf�[�^�𒊏o���ɃC�X�R�ʗp�̃C���f�b�N�X���Q�Ƃ���A�x�����������錏�̏C��</br>
    /// </remarks>
    class SalesSlipReport_Emp : SalesSlipReportBase, ISalesSlipReport
    {
        #region [EmpSalesTarget�p Select��]
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^�pSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">��������</param>
        /// <returns>�]�ƈ��ʔ���ڕW�ݒ�}�X�^�pSELECT��</returns>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.13</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, paramWork);
        }
        #endregion  //[EmpSalesTarget�p Select��]

        #region [EmpSalesTarget�p Select����������]
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^�pSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">��������</param>
        /// <returns>�]�ƈ��ʔ���ڕW�ݒ�}�X�^�pSELECT��</returns>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.13</br>
        /// <br>UpdateNote : 2012/05/22 ������ </br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 06/27�z�M��</br>
        /// <br>             Redmine#29898 ������񌎕� �i�����Z�o���ɉc�Ɠ����Q�Ƃ��Ă��Ȃ��p�^�[�������݂���</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork)
        {
            #region [���ʗp�t���O]
            //���Ӑ�R�[�h�����t���O
            bool bCustomerCode = false;
            if (paramWork.OutType == 1)
            {
                bCustomerCode = true;
            }

            //���_�R�[�h�����t���O
            bool bSectionCode = false;
            if (((paramWork.TtlType == 1) && (paramWork.OutType == 0)) ||
                ((paramWork.TtlType == 1) && (paramWork.OutType == 1)) ||
                ((paramWork.TtlType == 1) && (paramWork.OutType == 2)))
            {
                bSectionCode = true;
            }

            //�Ǘ����_�R�[�h�����t���O
            bool bMngSectionCode = false;
            if ((paramWork.TtlType == 1) && (paramWork.OutType == 3))
            {
                bMngSectionCode = true;
            }

            //���Ӑ�}�X�^�����t���O
            bool bCustomerRF = false;
            if (paramWork.OutType == 1)
            {
                bCustomerRF = true;
            }

            //���Ж��̃}�X�^�����t���O
            bool bCompanyNmRF = false;
            if (paramWork.TtlType == 1)
            {
                bCompanyNmRF = true;
            }

            //�]�ƈ��R�[�h����
            string sEmployeeCode = "";
            if (paramWork.TotalType == (int)TotalType.Agent)
                sEmployeeCode = "SALESEMPLOYEECDRF";
            else if (paramWork.TotalType == (int)TotalType.AcpOdr)
                sEmployeeCode = "FRONTEMPLOYEECDRF";
            else if (paramWork.TotalType == (int)TotalType.Pblsher)
                sEmployeeCode = "SALESINPUTCODERF";

            //WHERE��̋��_�R�[�h����(���_�ƊǗ����_)RESULTSADDUPSECCDRF
            //string sSecName = "SECTIONCODERF"; // DEL 2008.12.08
            string sSecName = "RESULTSADDUPSECCDRF"; // ADD 2008.12.08
            #endregion  //[���ʗp�t���O]

            string selectTxt = "";

            // �Ώۃe�[�u��
            // SALESHISTORYRF   SALHIS ���㗚���f�[�^
            // EMPSALESTARGETRF EMSTGT �]�ƈ��ʔ���ڕW�ݒ�}�X�^
            // CUSTOMERRF       CUTMER ���Ӑ�}�X�^
            // SECINFOSETRF     SCINST ���_���ݒ�}�X�^
            // EMPLOYEERF       EMPLOY �]�ƈ��}�X�^

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
            //�o�͏��ɂ���Ē��o���ڂ𓮓I��������
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHIS");
            selectTxt += " ,EMPLOY.NAMERF" + Environment.NewLine;
            selectTxt += " ,EMPLOY.BELONGSECTIONCODERF" + Environment.NewLine;//ADD 2012/05/22 Redmine#29898 ������
            selectTxt += IFBy(bCustomerRF, " ,CUTMER.CUSTOMERSNMRF" + Environment.NewLine);
            selectTxt += IFBy(bCompanyNmRF, " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
            selectTxt += IFBy(bMngSectionCode, " ,SALHIS.MNGSECTIONCODERF" + Environment.NewLine);

            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            #region [���㗚���f�[�^�{�]�ƈ��ʔ���ڕW�ݒ�}�X�^���o�p�T�u�N�G��]
            selectTxt += "  SELECT" + Environment.NewLine;
            //selectTxt += "   SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  ,SALHIST.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "   SALHISMSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHIST.TERMTOTALCOST" + Environment.NewLine;
            selectTxt += "  ,EMSTGTT.TERMSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "  ,EMSTGTT.TERMSALESTARGETPROFIT" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHTOTALCOST" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "  ,SALHISMSUB.MONTHSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += IFBy(bMngSectionCode,
            //             "  ,SALHIST.MNGSECTIONCODERF" + Environment.NewLine);
            //selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHIST");
            selectTxt += IFBy(bMngSectionCode,
                         "  ,SALHISMSUB.MNGSECTIONCODERF" + Environment.NewLine);
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISMSUB");

            //FROM
            selectTxt += "  FROM" + Environment.NewLine;
            selectTxt += "  (" + Environment.NewLine;

            #region [�f�[�^���o���C��Query]

            //���ԕ��W�v
            #region [���ԕ����oQuery]

            #region [���㗚���f�[�^]
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     SALHISSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISSUB1.SALESSLIPCDRF" + Environment.NewLine;
            //selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISSUB1");//DEL ������ 2013/02/06   Redmine#34586
            selectTxt += GetOutType_SQLCMD_MT2(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISSUB1");//ADD  ������ 2013/02/06   Redmine#34586
            selectTxt += "    ,COUNT(SALHISSUB1.SALESSLIPNUMRF)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESSLIPCOUNT" + Environment.NewLine;
            // DEL 2008.12.08 >>>
            //selectTxt += "    ,SUM(CASE WHEN SALHISSUB1.SALESSLIPCDRF=0" + Environment.NewLine;
            //selectTxt += "         THEN SALHISSUB1.SALESTOTALTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //selectTxt += "      AS TERMSALESTOTALTAXEXC" + Environment.NewLine;
            //selectTxt += "    ,SUM(CASE WHEN SALHISSUB1.SALESSLIPCDRF=1" + Environment.NewLine;
            //selectTxt += "         THEN SALHISSUB1.SALESTOTALTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //selectTxt += "      AS TERMSALESBACKTOTALTAXEXC" + Environment.NewLine;
            // DEL 2008.12.08 <<<
            // ADD 2008.12.08 >>>
            selectTxt += "    ,SUM(CASE WHEN SALHISSUB1.SALESSLIPCDRF=0" + Environment.NewLine;
            selectTxt += "         THEN SALHISSUB1.SALESNETPRICERF + DTL.SALESMONEYTAXEXC ELSE 0 END)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SUM(CASE WHEN SALHISSUB1.SALESSLIPCDRF=1" + Environment.NewLine;
            selectTxt += "         THEN SALHISSUB1.SALESNETPRICERF + DTL.SALESMONEYTAXEXC ELSE 0 END)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESBACKTOTALTAXEXC" + Environment.NewLine;
            // ADD 2008.12.08 <<<
            //selectTxt += "    ,SUM(SALHISSUB1.SALESDISTTLTAXEXCRF)" + Environment.NewLine;
            selectTxt += "    ,SUM(DTL.SALESMONEYTAXEXCGOODS)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SUM(SALHISSUB1.TOTALCOSTRF)" + Environment.NewLine;
            selectTxt += "      AS TERMTOTALCOST" + Environment.NewLine;
            selectTxt += IFBy(bMngSectionCode,
                         "    ,SALHISSUB1.MNGSECTIONCODERF" + Environment.NewLine);

            if (bMngSectionCode)
            {
                #region [�Ǘ����_���i���ݗp�T�u�N�G��]
                selectTxt += "   FROM" + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                selectTxt += "    SELECT" + Environment.NewLine;
                selectTxt += "      SALHISSUB1_1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.SALESTOTALTAXEXCRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.TOTALCOSTRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.SALESSLIPCDRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.SALESDATERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1." + sEmployeeCode + Environment.NewLine;
                selectTxt += "     ,CUTMERSUB1_1.MNGSECTIONCODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB1_1.SALESNETPRICERF" + Environment.NewLine;
                //----- Del 2012/02/28 zhangyong for Redmine#28712----->>>>>>>
                //selectTxt += "    FROM SALESHISTORYRF AS SALHISSUB1_1" + Environment.NewLine;
                //selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB1_1" + Environment.NewLine;
                //----- Del 2012/02/28 zhangyong for Redmine#28712-----<<<<<<<
                //----- Add 2012/02/28 zhangyong for Redmine#28712----->>>>>>>
                selectTxt += "    FROM SALESHISTORYRF AS SALHISSUB1_1 WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB1_1 WITH (READUNCOMMITTED)" + Environment.NewLine;
                //----- Add 2012/02/28 zhangyong for Redmine#28712-----<<<<<<<
                selectTxt += "    ON  CUTMERSUB1_1.ENTERPRISECODERF=SALHISSUB1_1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    AND CUTMERSUB1_1.CUSTOMERCODERF=SALHISSUB1_1.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += MakeWhereString(ref sqlCommand, paramWork, 0, "SALHISSUB1_1", sSecName);
                selectTxt += "   ) AS SALHISSUB1" + Environment.NewLine;
                #endregion  //[�Ǘ����_���i���ݗp�T�u�N�G��]

                //����WHERE��p�ɋ��_�R�[�h�c�c����ύX
                sSecName = "MNGSECTIONCODERF";
            }
            else
            {
                //�Ǘ����_���ȊO
                //selectTxt += "   FROM SALESHISTORYRF AS SALHISSUB1" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
                selectTxt += "   FROM SALESHISTORYRF AS SALHISSUB1 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            }
            selectTxt += "   LEFT JOIN " + Environment.NewLine;
            selectTxt += "     (" + Environment.NewLine;
            selectTxt += "       SELECT " + Environment.NewLine;
            selectTxt += "        ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "        ,ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "        ,SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "        ,SUM( CASE WHEN SALESSLIPCDDTLRF = 2 AND SHIPMENTCNTRF =0 THEN SALESMONEYTAXEXCRF ELSE 0 END ) AS SALESMONEYTAXEXC" + Environment.NewLine;
            selectTxt += "        ,SUM( CASE WHEN SALESSLIPCDDTLRF = 2 AND SHIPMENTCNTRF!=0 THEN SALESMONEYTAXEXCRF ELSE 0 END ) AS SALESMONEYTAXEXCGOODS" + Environment.NewLine;
            selectTxt += "       FROM          " + Environment.NewLine;
            //selectTxt += "        SALESHISTDTLRF " + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            //selectTxt += "        SALESHISTDTLRF WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712  //DEL 2015/12/21 osanai
            selectTxt += "        SALESHISTDTLRF WITH (READUNCOMMITTED,INDEX(SALESHISTDTLRF_IDX1))" + Environment.NewLine;  // ADD 2015/12/21 osanai �C�X�R�p�̌ʃC���f�b�N�X���Q�Ƃ��Ȃ��悤�Ƀp�b�P�[�W���l�N���X�^�C���f�b�N�X�Œ艻
            //selectTxt += "       WHERE" + Environment.NewLine;
            //selectTxt += "        SALESSLIPCDDTLRF = 2  -- �l��" + Environment.NewLine;
            // -- ADD 2009/10/09 ------------------------->>>
            selectTxt += "       WHERE" + Environment.NewLine;
            selectTxt += "            SALESHISTDTLRF.ENTERPRISECODERF = @SALHISSUB1ENTERPRISECODE" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.SALESDATERF>=@SALHISSUB1SALESDATEST" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.SALESDATERF<=@SALHISSUB1SALESDATEED" + Environment.NewLine;
            // -- ADD 2009/10/09 -------------------------<<<
            selectTxt += "       GROUP BY" + Environment.NewLine;
            selectTxt += "        ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "        ,ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "        ,SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "     ) AS DTL" + Environment.NewLine;
            selectTxt += "   ON ( SALHISSUB1.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   AND SALHISSUB1.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "   AND SALHISSUB1.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF)" + Environment.NewLine;

            selectTxt += MakeWhereString(ref sqlCommand, paramWork, 0, "SALHISSUB1", sSecName); 
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     SALHISSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISSUB1.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISSUB1");
            selectTxt += IFBy(bMngSectionCode,
                         "    ,SALHISSUB1.MNGSECTIONCODERF" + Environment.NewLine);
            selectTxt += "  ) AS SALHIST" + Environment.NewLine;

            //����WHERE��p�ɋ��_�R�[�h�c�c����ύX
            sSecName = "SECTIONCODERF";
            #endregion  //[���㗚���f�[�^]

            #region [�]�ƈ��ʔ���ڕW�ݒ�}�X�^]
            selectTxt += "  LEFT JOIN (" + Environment.NewLine;
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     EMSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,EMSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bMngSectionCode,
                         "    ,EMSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "    ,EMSTGTSUB1.EMPLOYEECODERF" + Environment.NewLine;
            selectTxt += "    ,SUM(EMSTGTSUB1.SALESTARGETMONEYRF)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,SUM(EMSTGTSUB1.SALESTARGETPROFITRF)" + Environment.NewLine;
            selectTxt += "      AS TERMSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += "   FROM EMPSALESTARGETRF AS EMSTGTSUB1" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += "   FROM EMPSALESTARGETRF AS EMSTGTSUB1 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            selectTxt += MakeWhereString_Emp(ref sqlCommand, paramWork, "EMSTGTSUB1",0);
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     EMSTGTSUB1.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,EMSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bMngSectionCode,
                         "    ,EMSTGTSUB1.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "    ,EMSTGTSUB1.EMPLOYEECODERF" + Environment.NewLine;
            selectTxt += "  ) AS EMSTGTT" + Environment.NewLine;
            selectTxt += "  ON  EMSTGTT.ENTERPRISECODERF=SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND EMSTGTT.EMPLOYEECODERF=SALHIST." + sEmployeeCode + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         //"  AND EMSTGTT.SECTIONCODERF=SALHIST.SECTIONCODERF" + Environment.NewLine);// DEL 2008.12.08
                         "  AND EMSTGTT.SECTIONCODERF=SALHIST.RESULTSADDUPSECCDRF" + Environment.NewLine); // ADD 2008.12.08
            selectTxt += IFBy(bMngSectionCode,
                         "  AND EMSTGTT.SECTIONCODERF=SALHIST.MNGSECTIONCODERF" + Environment.NewLine);
            #endregion  //[�]�ƈ��ʔ���ڕW�ݒ�}�X�^]

            #endregion  //[���ԕ����oQuery]

            //�������W�v
            #region [���������oQuery]

            #region [���㗚���f�[�^]
            //selectTxt += "  LEFT JOIN (" + Environment.NewLine;
            selectTxt += "  RIGHT JOIN (" + Environment.NewLine;
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     SALHISM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISM.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISM");
            selectTxt += "    ,SALHISM.MONTHSALESSLIPCOUNT" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SALHISM.MONTHTOTALCOST" + Environment.NewLine;
            selectTxt += "    ,EMSTGTM.MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,EMSTGTM.MONTHSALESTARGETPROFIT" + Environment.NewLine;
            selectTxt += IFBy(bMngSectionCode,
                         "    ,SALHISM.MNGSECTIONCODERF" + Environment.NewLine);
            selectTxt += "   FROM" + Environment.NewLine;
            selectTxt += "   (" + Environment.NewLine;

            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     SALHISSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISSUB2.SALESSLIPCDRF" + Environment.NewLine;
            //selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISSUB2");//DEL  ������ 2013/02/06   Redmine#34586
            selectTxt += GetOutType_SQLCMD_MT2(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISSUB2");//ADD   ������ 2013/02/06   Redmine#34586
            selectTxt += "    ,COUNT(SALHISSUB2.SALESSLIPNUMRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESSLIPCOUNT" + Environment.NewLine;
            // DEL 2008.12.08 >>>
            //selectTxt += "    ,SUM(CASE WHEN SALHISSUB2.SALESSLIPCDRF=0" + Environment.NewLine;
            //selectTxt += "         THEN SALHISSUB2.SALESTOTALTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //selectTxt += "      AS MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            //selectTxt += "    ,SUM(CASE WHEN SALHISSUB2.SALESSLIPCDRF=1" + Environment.NewLine;
            //selectTxt += "         THEN SALHISSUB2.SALESTOTALTAXEXCRF ELSE 0 END)" + Environment.NewLine;
            //selectTxt += "      AS MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            // DEL 2008.12.08 <<<
            // ADD 2008.12.08 >>>
            selectTxt += "    ,SUM(CASE WHEN SALHISSUB2.SALESSLIPCDRF=0 " + Environment.NewLine;
            selectTxt += "         THEN SALHISSUB2.SALESNETPRICERF + DTL2.SALESMONEYTAXEXC  ELSE 0 END)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESTOTALTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SUM(CASE WHEN SALHISSUB2.SALESSLIPCDRF=1" + Environment.NewLine;
            selectTxt += "         THEN SALHISSUB2.SALESNETPRICERF + DTL2.SALESMONEYTAXEXC  ELSE 0 END)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESBACKTOTALTAXEXC" + Environment.NewLine;
            // ADD 2008.12.08 <<<
            //selectTxt += "    ,SUM(SALHISSUB2.SALESDISTTLTAXEXCRF)" + Environment.NewLine;
            selectTxt += "    ,SUM(DTL2.SALESMONEYTAXEXCGOODS)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESDISTTLTAXEXC" + Environment.NewLine;
            selectTxt += "    ,SUM(SALHISSUB2.TOTALCOSTRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHTOTALCOST" + Environment.NewLine;
            selectTxt += IFBy(bMngSectionCode,
                         "    ,SALHISSUB2.MNGSECTIONCODERF" + Environment.NewLine);

            if (bMngSectionCode)
            {
                #region [�Ǘ����_���i���ݗp�T�u�N�G��]
                selectTxt += "   FROM" + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                selectTxt += "    SELECT" + Environment.NewLine;
                selectTxt += "      SALHISSUB2_1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.SALESTOTALTAXEXCRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.SALESDISTTLTAXEXCRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.TOTALCOSTRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.SALESSLIPCDRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.SALESDATERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1." + sEmployeeCode + Environment.NewLine;
                selectTxt += "     ,CUTMERSUB2_1.MNGSECTIONCODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.SALESNETPRICERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUB2_1.RESULTSADDUPSECCDRF" + Environment.NewLine;
                //----- Del 2012/02/28 zhangyong for Redmine#28712----->>>>>>>
                //selectTxt += "    FROM SALESHISTORYRF AS SALHISSUB2_1" + Environment.NewLine;
                //selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB2_1" + Environment.NewLine;
                //----- Del 2012/02/28 zhangyong for Redmine#28712-----<<<<<<<
                //----- Add 2012/02/28 zhangyong for Redmine#28712----->>>>>>>
                selectTxt += "    FROM SALESHISTORYRF AS SALHISSUB2_1 WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "    LEFT JOIN CUSTOMERRF CUTMERSUB2_1 WITH (READUNCOMMITTED)" + Environment.NewLine;
                //----- Add 2012/02/28 zhangyong for Redmine#28712-----<<<<<<<
                selectTxt += "    ON  CUTMERSUB2_1.ENTERPRISECODERF=SALHISSUB2_1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    AND CUTMERSUB2_1.CUSTOMERCODERF=SALHISSUB2_1.CUSTOMERCODERF" + Environment.NewLine;
                //selectTxt += MakeWhereString(ref sqlCommand, paramWork, 1, "SALHISSUB2_1", sSecName);// DEL 2008.12.08
                selectTxt += MakeWhereString(ref sqlCommand, paramWork, 1, "SALHISSUB2_1", "RESULTSADDUPSECCDRF"); // ADD 2008.12.08
                selectTxt += "   ) AS SALHISSUB2" + Environment.NewLine;
                #endregion  //[�Ǘ����_���i���ݗp�T�u�N�G��]

                //����WHERE��p�ɋ��_�R�[�h�c�c����ύX
                sSecName = "MNGSECTIONCODERF";
            }
            else
            {
                //�Ǘ����_���ȊO
                //selectTxt += "   FROM SALESHISTORYRF AS SALHISSUB2" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
                selectTxt += "   FROM SALESHISTORYRF AS SALHISSUB2 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            }
            selectTxt += "   LEFT JOIN " + Environment.NewLine;
            selectTxt += "     (" + Environment.NewLine;
            selectTxt += "       SELECT " + Environment.NewLine;
            selectTxt += "        ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "        ,ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "        ,SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "        ,SUM( CASE WHEN SALESSLIPCDDTLRF = 2 AND SHIPMENTCNTRF =0 THEN SALESMONEYTAXEXCRF ELSE 0 END ) AS SALESMONEYTAXEXC" + Environment.NewLine;
            selectTxt += "        ,SUM( CASE WHEN SALESSLIPCDDTLRF = 2 AND SHIPMENTCNTRF!=0 THEN SALESMONEYTAXEXCRF ELSE 0 END ) AS SALESMONEYTAXEXCGOODS" + Environment.NewLine;
            selectTxt += "       FROM          " + Environment.NewLine;
            //selectTxt += "        SALESHISTDTLRF " + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            //selectTxt += "        SALESHISTDTLRF WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712  // DEL 2015/12/21 osanai
            selectTxt += "        SALESHISTDTLRF WITH (READUNCOMMITTED,INDEX(SALESHISTDTLRF_IDX1))" + Environment.NewLine; // ADD 2015/12/21 osanai �C�X�R�p�̌ʃC���f�b�N�X���Q�Ƃ��Ȃ��悤�Ƀp�b�P�[�W���l�N���X�^�C���f�b�N�X�Œ艻
            //selectTxt += "       WHERE" + Environment.NewLine;
            //selectTxt += "        SALESSLIPCDDTLRF = 2  -- �l��" + Environment.NewLine;
            // -- ADD 2009/10/09 ------------------------->>>
            selectTxt += "       WHERE" + Environment.NewLine;
            selectTxt += "            SALESHISTDTLRF.ENTERPRISECODERF = @SALHISSUB2ENTERPRISECODE" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.SALESDATERF>=@MOSALHISSUB2SALESDATEST" + Environment.NewLine;
            selectTxt += "        AND SALESHISTDTLRF.SALESDATERF<=@MOSALHISSUB2SALESDATEED" + Environment.NewLine;
            // -- ADD 2009/10/09 -------------------------<<<
            selectTxt += "       GROUP BY" + Environment.NewLine;
            selectTxt += "        ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "        ,ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "        ,SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "     ) AS DTL2" + Environment.NewLine;
            selectTxt += "   ON ( SALHISSUB2.ENTERPRISECODERF = DTL2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   AND SALHISSUB2.ACPTANODRSTATUSRF = DTL2.ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "   AND SALHISSUB2.SALESSLIPNUMRF = DTL2.SALESSLIPNUMRF)" + Environment.NewLine;

            //selectTxt += MakeWhereString(ref sqlCommand, paramWork, 1, "SALHISSUB2", sSecName);// DEL 2008.12.08
            selectTxt += MakeWhereString(ref sqlCommand, paramWork, 1, "SALHISSUB2", "RESULTSADDUPSECCDRF"); // ADD 2008.12.08
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     SALHISSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,SALHISSUB2.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += GetOutType_SQLCMD_MT(paramWork.TotalType, paramWork.OutType, paramWork.TtlType, "SALHISSUB2");
            selectTxt += IFBy(bMngSectionCode,
                         "    ,SALHISSUB2.MNGSECTIONCODERF" + Environment.NewLine);
            selectTxt += "  ) AS SALHISM" + Environment.NewLine;

            //����WHERE��p�ɋ��_�R�[�h�c�c����ύX
            sSecName = "SECTIONCODERF";
            #endregion  //[���㗚���f�[�^]

            #region [�]�ƈ��ʔ���ڕW�ݒ�}�X�^]
            selectTxt += "  LEFT JOIN (" + Environment.NewLine;
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     EMSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,EMSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bMngSectionCode,
                         "    ,EMSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "    ,EMSTGTSUB2.EMPLOYEECODERF" + Environment.NewLine;
            selectTxt += "    ,SUM(EMSTGTSUB2.SALESTARGETMONEYRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESTARGETMONEY" + Environment.NewLine;
            selectTxt += "    ,SUM(EMSTGTSUB2.SALESTARGETPROFITRF)" + Environment.NewLine;
            selectTxt += "      AS MONTHSALESTARGETPROFIT" + Environment.NewLine;
            //selectTxt += "   FROM EMPSALESTARGETRF AS EMSTGTSUB2" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += "   FROM EMPSALESTARGETRF AS EMSTGTSUB2 WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            selectTxt += MakeWhereString_Emp(ref sqlCommand, paramWork, "EMSTGTSUB2",1);
            selectTxt += "   GROUP BY" + Environment.NewLine;
            selectTxt += "     EMSTGTSUB2.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         "    ,EMSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
            selectTxt += IFBy(bMngSectionCode,
                         "    ,EMSTGTSUB2.SECTIONCODERF" + Environment.NewLine);
            selectTxt += "    ,EMSTGTSUB2.EMPLOYEECODERF" + Environment.NewLine;
            selectTxt += "  ) AS EMSTGTM" + Environment.NewLine;
            selectTxt += "  ON  EMSTGTM.ENTERPRISECODERF=SALHISM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND EMSTGTM.EMPLOYEECODERF=SALHISM." + sEmployeeCode + Environment.NewLine;
            selectTxt += IFBy(bSectionCode,
                         //"  AND EMSTGTM.SECTIONCODERF=SALHISM.SECTIONCODERF" + Environment.NewLine);// DEL 2008.12.08
                         "  AND EMSTGTM.SECTIONCODERF=SALHISM.RESULTSADDUPSECCDRF" + Environment.NewLine); // ADD 2008.12.08
            selectTxt += IFBy(bMngSectionCode,
                         "  AND EMSTGTM.SECTIONCODERF=SALHISM.MNGSECTIONCODERF" + Environment.NewLine);
            #endregion  //[�]�ƈ��ʔ���ڕW�ݒ�}�X�^]

            #endregion  //[���������oQuery]

            #endregion  //[�f�[�^���o���C��Query]

            //���ԕ��Ɠ������̌�������
            selectTxt += "  ) AS SALHISMSUB" + Environment.NewLine;
            selectTxt += "  ON  SALHISMSUB.ENTERPRISECODERF=SALHIST.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SALHISMSUB.SALESSLIPCDRF=SALHIST.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "  AND SALHISMSUB." + sEmployeeCode + "=SALHIST." + sEmployeeCode + Environment.NewLine;
            selectTxt += IFBy(bCustomerCode,
                         "  AND SALHISMSUB.CUSTOMERCODERF=SALHIST.CUSTOMERCODERF" + Environment.NewLine);
            selectTxt += IFBy(bSectionCode,
                         //"  AND SALHISMSUB.SECTIONCODERF=SALHIST.SECTIONCODERF" + Environment.NewLine);// DEL 2008.12.08
                         "  AND SALHISMSUB.RESULTSADDUPSECCDRF=SALHIST.RESULTSADDUPSECCDRF" + Environment.NewLine); // ADD 2008.12.08
            selectTxt += IFBy(bMngSectionCode,
                         "  AND SALHISMSUB.MNGSECTIONCODERF=SALHIST.MNGSECTIONCODERF" + Environment.NewLine);

            #endregion  //[���㗚���f�[�^�{�]�ƈ��ʔ���ڕW�ݒ�}�X�^���o�p�T�u�N�G��]

            selectTxt += " ) AS SALHIS" + Environment.NewLine;

            #region [JOIN]
            //�]�ƈ��}�X�^
            //selectTxt += " LEFT JOIN EMPLOYEERF EMPLOY" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
            selectTxt += " LEFT JOIN EMPLOYEERF EMPLOY WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
            selectTxt += " ON  EMPLOY.ENTERPRISECODERF=SALHIS.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND EMPLOY.EMPLOYEECODERF=SALHIS." + sEmployeeCode + Environment.NewLine;

            if (bCustomerRF)
            {
                //���Ӑ�}�X�^
                //selectTxt += " LEFT JOIN CUSTOMERRF CUTMER" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " LEFT JOIN CUSTOMERRF CUTMER WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " ON  CUTMER.ENTERPRISECODERF=SALHIS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUTMER.CUSTOMERCODERF=SALHIS.CUSTOMERCODERF" + Environment.NewLine;
            }
            if (bCompanyNmRF)
            {
                //���_���ݒ�}�X�^
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;//Del 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST  WITH (READUNCOMMITTED)" + Environment.NewLine;//Add 2012/02/28 zhangyong for Redmine#28712
                selectTxt += " ON  SCINST.ENTERPRISECODERF=SALHIS.ENTERPRISECODERF" + Environment.NewLine;
                if (bMngSectionCode)
                    selectTxt += " AND SCINST.SECTIONCODERF=SALHIS.MNGSECTIONCODERF" + Environment.NewLine;
                else
                    //selectTxt += " AND SCINST.SECTIONCODERF=SALHIS.SECTIONCODERF" + Environment.NewLine;// DEL 2008.12.08
                    selectTxt += " AND SCINST.SECTIONCODERF=SALHIS.RESULTSADDUPSECCDRF" + Environment.NewLine; // ADD 2008.12.08
            }
            #endregion  //[JOIN]

            #endregion  //[Select���쐬]

            return selectTxt;
        }
        #endregion  //[EmpSalesTarget�p Select����������]

        #region [SalesHistory�p Where�吶������]
        /// <summary>
        /// ���㗚���f�[�^�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">��������</param>
        /// <param name="iType">����^�C�v 0:���� 1:����</param>
        /// <param name="sTblNm">�e�[�u������</param>
        /// <param name="sSecName">���_�R�[�h���ږ�</param>
        /// <returns>���㗚���f�[�^�pWHERE��</returns>
        /// <br>Note       : ���㗚���f�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.13</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork, int iType, string sTblNm, string sSecName)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            retstring += " AND " + sTblNm + ".LOGICALDELETECODERF=0 " + Environment.NewLine;

            //�󒍃X�e�[�^�X
            retstring += " AND " + sTblNm + ".ACPTANODRSTATUSRF=30" + Environment.NewLine;

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
                    retstring += " AND " + sTblNm + "." + sSecName + " IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�Ώۓ��t
            if (iType == 0)
            {
                //�J�n�Ώ۔N����(����)
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //retstring += " AND " + sTblNm + ".SALESDATERF>=@" + sTblNm + "SALESDATEST" + Environment.NewLine;
                retstring += " AND " + sTblNm + ".SALESDATERF>=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateSt).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESDATEST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateSt);

                //�I���Ώ۔N����(����)
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //retstring += " AND " + sTblNm + ".SALESDATERF<=@" + sTblNm + "SALESDATEED" + Environment.NewLine;
                retstring += " AND " + sTblNm + ".SALESDATERF<=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateEd).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESDATEED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.SalesDateEd);
            }
            else
            {
                //�J�n�Ώ۔N����(����)
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //retstring += " AND " + sTblNm + ".SALESDATERF>=@MO" + sTblNm + "SALESDATEST" + Environment.NewLine;
                retstring += " AND " + sTblNm + ".SALESDATERF>=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateSt).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraMOSalesDateSt = sqlCommand.Parameters.Add("@MO" + sTblNm + "SALESDATEST", SqlDbType.Int);
                paraMOSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateSt);

                //�I���Ώ۔N����(����)
                // -- UPD 2010/05/10 ------------------------------------------------->>>
                //retstring += " AND " + sTblNm + ".SALESDATERF<=@MO" + sTblNm + "SALESDATEED" + Environment.NewLine;
                retstring += " AND " + sTblNm + ".SALESDATERF<=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateEd).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 -------------------------------------------------<<<
                SqlParameter paraMOSalesDateEd = sqlCommand.Parameters.Add("@MO" + sTblNm + "SALESDATEED", SqlDbType.Int);
                paraMOSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.MonthReportDateEd);

            }

            //���Ӑ�R�[�h
            if (paramWork.CustomerCodeSt != 0)
            {
                retstring += " AND " + sTblNm + ".CUSTOMERCODERF>=@" + sTblNm + "CUSTOMERCODEST" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeSt);
            }
            if (paramWork.CustomerCodeEd != 99999999)
            {
                retstring += " AND " + sTblNm + ".CUSTOMERCODERF<=@" + sTblNm + "CUSTOMERCODEED" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCodeEd);
            }

            //�]�ƈ��R�[�h����
            string sEmployeeCode = "";
            if (paramWork.TotalType == (int)TotalType.Agent)
                sEmployeeCode = "SALESEMPLOYEECDRF";
            else if (paramWork.TotalType == (int)TotalType.AcpOdr)
                sEmployeeCode = "FRONTEMPLOYEECDRF";
            else if (paramWork.TotalType == (int)TotalType.Pblsher)
                sEmployeeCode = "SALESINPUTCODERF";
            //�]�ƈ��R�[�h
            if (paramWork.SrchCodeSt != "")
            {
                retstring += " AND " + sTblNm + "." + sEmployeeCode + ">=@" + sTblNm + sEmployeeCode + "ST" + Environment.NewLine;
                SqlParameter paraSrchCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + sEmployeeCode + "ST", SqlDbType.NChar);
                paraSrchCodeSt.Value = SqlDataMediator.SqlSetString(paramWork.SrchCodeSt);
            }
            if ((paramWork.SrchCodeEd != ""))
            {
                retstring += " AND ( " + sTblNm + "." + sEmployeeCode + "<=@" + sTblNm + sEmployeeCode + "ED OR " + sTblNm + "." + sEmployeeCode + " IS NULL )" + Environment.NewLine;
                SqlParameter paraSrchCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + sEmployeeCode + "ED", SqlDbType.NChar);
                paraSrchCodeEd.Value = SqlDataMediator.SqlSetString(paramWork.SrchCodeEd);
            }
            #endregion

            return retstring;
        }
        #endregion  //[SalesHistory�p Where�吶������]

        #region [EmpSalesTarget�p Where�吶������]
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="shipmentListParamWork">��������</param>
        /// <returns>�]�ƈ��ʔ���ڕW�ݒ�}�X�^�pWHERE��</returns>
        /// <br>Note       : ���㗚���f�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.13</br>
        /// <br>UpdateNote : 2012/05/22 ������ </br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 06/27�z�M��</br>
        /// <br>             Redmine#29898 ������񌎕� �i�����Z�o���ɉc�Ɠ����Q�Ƃ��Ă��Ȃ��p�^�[�������݂���</br> 
        private string MakeWhereString_Emp(ref SqlCommand sqlCommand, SalesDayMonthReportParamWork paramWork, string sTblNm, Int32 iPrintType)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�]�ƈ��敪
            retstring += " AND " + sTblNm + ".EMPLOYEEDIVCDRF=@" + sTblNm + "EMPLOYEEDIVCD" + Environment.NewLine;
            SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@" + sTblNm + "EMPLOYEEDIVCD", SqlDbType.Int);
            switch ((int)paramWork.TotalType)
            {
                case (int)TotalType.Agent:    //Agent   -> �S���ҕ�
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)EmployeeDivCd.Agent);
                    break;
                case (int)TotalType.AcpOdr:   //AcpOdr  -> �󒍎ҕ�
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)EmployeeDivCd.AcpOdr);
                    break;
                case (int)TotalType.Pblsher:  //Pblsher -> ���s�ҕ�
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32((int)EmployeeDivCd.Pblsher);
                    break;
                default:
                    break;
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
            else if (iPrintType ==1) // ����
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
        #endregion  //[EmpSalesTarget�p Where�吶������]

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

            if (paramWork.TotalType == (int)TotalType.Agent)
                resultWork.Code = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            if (paramWork.TotalType == (int)TotalType.AcpOdr)
                resultWork.Code = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
            if (paramWork.TotalType == (int)TotalType.Pblsher)
                resultWork.Code = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
            resultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));

            if (paramWork.TtlType == 1)
            {
                if (paramWork.OutType == 3)
                    resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                else
                    //resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // DEL 2008.12.08
                    resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF")); // ADD 2008.12.08
                resultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            }

            if (paramWork.OutType == 1)
            {
                resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            }

            resultWork.SectionMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSECTIONCODERF"));//ADD 2012/05/22 Redmine#29898 ������
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

        #region [�W�v�P�ʂƏo�͏�����Ή�����SQL���𐶐����܂��B(���ԕ��W�v�Ɠ������W�v��SELECT�@��p)]
        // --------------- ADD START 2013/02/06 Redmine#34586 ������-------->>>>
        /// <summary>
        /// �W�v�P�ʂƏo�͏�����Ή�����SQL���𐶐����܂��B(���ԕ��W�v�Ɠ������W�v��SELECT�@��p)
        /// </summary>
        /// <param name="iTotalType">�W�v�P��</param>
        /// <param name="iOutType">�o�͏�</param>
        /// <param name="iTtlType">�W�v���@</param>
        /// <param name="sTblNm">�e�[�u��������</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �W�v�P�ʂƏo�͏�����Ή�����SQL���𐶐����܂��B(���ԕ��W�v�Ɠ������W�v��SELECT�@��p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2013/02/06</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 03/13�z�M��</br>
        /// <br>             Redmine#34586   No.1158�@�O�a���i�@������񌎕�i�󒍎ҕʁj</br>
        /// </remarks>
        private string GetOutType_SQLCMD_MT2(Int32 iTotalType, Int32 iOutType, Int32 iTtlType, string sTblNm)
        {
            string sRetBuf = null;

            #region [�W�v�P�ʊm�F]
            switch (iTotalType)
            {
                case (int)TotalType.Customer:  //0:���Ӑ��
                    #region [�o�͏��m�F]
                    if ((iTtlType == 1) && (iOutType != 3))
                        sRetBuf += "," + sTblNm + ".RESULTSADDUPSECCDRF" + Environment.NewLine;   //���_�R�[�h
                    if ((iOutType == 0) ||
                        (iOutType == 2) ||
                        (iOutType == 3))
                    {
                        sRetBuf += "," + sTblNm + ".CUSTOMERCODERF" + Environment.NewLine;  //���Ӑ�R�[�h
                    }
                    #endregion
                    break;
                case (int)TotalType.Agent:     //1:�S���ҕ�
                case (int)TotalType.AcpOdr:    //2:�󒍎ҕ�
                case (int)TotalType.Pblsher:   //3:���s�ҕ�
                    #region [�o�͏��m�F]
                    //���ʎg�p
                    sRetBuf += IFBy(iTotalType == (int)TotalType.Agent,
                               "," + sTblNm + ".SALESEMPLOYEECDRF" + Environment.NewLine);  //�̔��]�ƈ��R�[�h
                    sRetBuf += IFBy(iTotalType == (int)TotalType.AcpOdr,
                                " , ISNULL(" + sTblNm + ".FRONTEMPLOYEECDRF ,0) AS FRONTEMPLOYEECDRF " + Environment.NewLine);  //��t�]�ƈ��R�[�h
                    sRetBuf += IFBy(iTotalType == (int)TotalType.Pblsher,
                               " ,  ISNULL(" + sTblNm + ".SALESINPUTCODERF ,0) AS SALESINPUTCODERF " + Environment.NewLine);   //������͎҃R�[�h
                    if ((iTtlType == 1) && (iOutType != 3))
                        sRetBuf += "," + sTblNm + ".RESULTSADDUPSECCDRF" + Environment.NewLine;   //���_�R�[�h 
                    if (iOutType == 1)
                        sRetBuf += "," + sTblNm + ".CUSTOMERCODERF" + Environment.NewLine;  //���Ӑ�R�[�h
                    #endregion
                    break;
                case (int)TotalType.Area:      //4:�n���
                case (int)TotalType.BzType:    //5:�Ǝ��
                    #region [�o�͏��m�F]
                    if (iTtlType == 1)
                        sRetBuf += "," + sTblNm + ".RESULTSADDUPSECCDRF" + Environment.NewLine;   //���_�R�[�h
                    if (iOutType == 1)
                        sRetBuf += "," + sTblNm + ".CUSTOMERCODERF" + Environment.NewLine;  //���Ӑ�R�[�h
                    #endregion
                    break;
                case (int)TotalType.SaleCd:    //6:�̔��敪��
                    //�̔��敪�ʂ̏ꍇ�͂Ȃ�
                    break;
                default:
                    break;
            }
            #endregion

            return sRetBuf;
        }
        // --------------- ADD END 2013/02/06 Redmine#34586 ������--------<<<<
        #endregion //[�W�v�P�ʂƏo�͏�����Ή�����SQL���𐶐����܂��B(���ԕ��W�v�Ɠ������W�v��SELECT�@��p)]
    }
}

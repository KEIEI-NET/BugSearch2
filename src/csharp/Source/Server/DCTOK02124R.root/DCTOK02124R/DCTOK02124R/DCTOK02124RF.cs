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
    class MTtlSaSlipWhouse : MTtlSaSlipBase, IMTtlSaSlip
    {
        #region [���ʗp�t���O�錾]
        private bool bSectionCode = false;    //���_�R�[�h
        private bool bWarehouseCode = false;  //�q�ɃR�[�h
        private bool bCustomerCode = false;   //���Ӑ�R�[�h
        private bool bGoodsMakerCd = false;   //���i���[�J�[�R�[�h
        private bool bBLGoodsCode = false;    //BL���i�R�[�h
        private bool bGoodsNo = false;        //���i�ԍ�
        private bool bBLGroupCode = false;    //BL�O���[�v�R�[�h
        private bool bGoodsMGroup = false;    //���i�����ރR�[�h
        private bool bGoodsLGroup = false;    //���i�啪�ރR�[�h
        private bool bAnnual = false;        //�������
        #endregion  //[���ʗp�t���O�錾]

        #region [�q�ɗp Select��]
        /// <summary>
        /// �q�ɗpSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>�q�ɗpSELECT��</returns>
        /// <br>Note       : �q�ɗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.02</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, CndtnWork);
        }
        #endregion  //[�q�ɗp Select��]

        #region [�q�ɗp Select����������]
        /// <summary>
        /// �q�ɗpSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>�q�ɗpSELECT��</returns>
        /// <br>Note       : �q�ɗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.02</br>
        /// <br>Update Note: 2009.04.28 ����</br>
        /// <br>            �E���[�J�[����==>���[�J�[����
        /// <br>Update Note: 2012/03/30 �s�i�� </br>
        /// <br>�Ǘ��ԍ�   �F10801804-00 2012/05/24�z�M��</br>
        /// <br>             Redmine#29142 �u���i�l���v�̏ꍇ�͏W�v�ΏۊO�ƂȂ�悤�ɏC������</br>�B
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork)
        {
            #region [���ʗp�t���O]
            //���_�R�[�h
            if (((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.TtlType == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.TtlType == 1) && (CndtnWork.Detail != 7)))
            {
                bSectionCode = true;
            }

            //�q�ɃR�[�h
            if (((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 6)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 6)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 7)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 6)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 7)))
            {
                bWarehouseCode = true;
            }

            //���Ӑ�R�[�h
            if (((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 6)))
            {
                bCustomerCode = true;
            }

            //���i�ԍ�
            if (CndtnWork.Detail == 0)
            {
                bGoodsNo = true;
            }

            //���i���[�J�[�R�[�h
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 5) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 4)))
            {
                bGoodsMakerCd = true;
            }

            //BL���i�R�[�h
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1))
            {
                bBLGoodsCode = true;
            }

            //BL�O���[�v�R�[�h
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2))
            {
                bBLGroupCode = true;
            }

            //���i�����ރR�[�h
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2) ||
                (CndtnWork.Detail == 3))
            {
                bGoodsMGroup = true;
            }

            //���i�啪�ރR�[�h
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2) ||
                (CndtnWork.Detail == 3) ||
                (CndtnWork.Detail == 4))
            {
                bGoodsLGroup = true;
            }

            //�������
            if (CndtnWork.AnnualPrintDiv == 1)
            {
                bAnnual = true;
            }
            #endregion  //[���ʗp�t���O]

            string selectTxt = "";

            // �Ώۃe�[�u��
            // SALESHISTORYRF    SALHIS ���㗚���f�[�^
            // SALESHISTDTLRF    SALDTL ���㗚�𖾍׃f�[�^
            // GOODSURF          GOODSU ���i�}�X�^(���[�U�[)
            // BLGOODSCDURF      BLGCDU BL���i�R�[�h�}�X�^(���[�U�[)
            // BLGROUPURF        BLGRPU BL�O���[�v�}�X�^(���[�U�[)
            // MAKERURF          MAKERU ���[�J�[�}�X�^(���[�U�[�o�^��)
            // USERGDBDURF       USGDBU ���[�U�[�K�C�h�}�X�^(�{�f�B)(���[�U�ύX��)
            // SECINFOSETRF      SCINST ���_���ݒ�}�X�^
            // WAREHOUSERF       WARHUS �q�Ƀ}�X�^
            // CUSTOMERRF        CUSTMR ���Ӑ�}�X�^
            // GOODSGROUPURF     GSGRPU ���i�����ރ}�X�^(���[�U�[�o�^��)

            #region [Select���쐬]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bWarehouseCode,
                         " ,SALDTL.WAREHOUSECODERF" + Environment.NewLine);
            selectTxt += IFBy(bWarehouseCode,
                         " ,WARHUS.WAREHOUSENAMERF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerCode,
                         " ,SALDTL.CUSTOMERCODERF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerCode,
                         " ,CUSTMR.CUSTOMERSNMRF" + Environment.NewLine);
            selectTxt += IFBy(bSectionCode,
                         //" ,SALDTL.SECTIONCODERF" + Environment.NewLine);      // DEL 2011/04/21
                         " ,SALDTL.RESULTSADDUPSECCDRF" + Environment.NewLine);  // ADD 2011/04/21
            selectTxt += IFBy(bSectionCode,
                         " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMakerCd,
                         " ,SALDTL.GOODSMAKERCDRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMakerCd,
                         " ,MAKERU.MAKERNAMERF" + Environment.NewLine);  // Update 2009/04/28
            selectTxt += IFBy(bBLGoodsCode,
                         " ,SALDTL.BLGOODSCODERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGoodsCode,
                         " ,BLGCDU.BLGOODSHALFNAMERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGroupCode,
                         " ,SALDTL.BLGROUPCODERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGroupCode,
                         " ,BLGRPU.BLGROUPKANANAMERF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMGroup,
                         " ,SALDTL.GOODSMGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMGroup,
                         " ,GSGRPU.GOODSMGROUPNAMERF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsLGroup,
                         " ,SALDTL.GOODSLGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsLGroup,
                         " ,USGDBUL.GUIDENAMERF AS GOODSLGROUPNAME" + Environment.NewLine);
            selectTxt += IFBy(bGoodsNo,
                         " ,SALDTL.GOODSNORF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsNo,
                         " ,GOODSU.GOODSNAMEKANARF" + Environment.NewLine);
            //����
            selectTxt += " ,SALDTL.MONTHTOTALSALESCOUNT" + Environment.NewLine;
            selectTxt += " ,SALDTL.MONTHSALESMONEY" + Environment.NewLine;
            selectTxt += " ,SALDTL.MONTHGROSSPROFIT" + Environment.NewLine;
            //����
            if (bAnnual)
            {
                selectTxt += " ,SALDTL.ANNUALTOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += " ,SALDTL.ANNUALSALESMONEY" + Environment.NewLine;
                selectTxt += " ,SALDTL.ANNUALGROSSPROFIT" + Environment.NewLine;
            }
            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            #region [�f�[�^���o���C��Query]
            selectTxt += "  SELECT" + Environment.NewLine;
            selectTxt += "    SALDTLSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bWarehouseCode,
                         "   ,SALDTLSUB.WAREHOUSECODERF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerCode,
                         "   ,SALDTLSUB.CUSTOMERCODERF" + Environment.NewLine);
            selectTxt += IFBy(bSectionCode,
                         //"   ,SALDTLSUB.SECTIONCODERF" + Environment.NewLine);   // DEL 2011/04/21 
                         "   ,SALDTLSUB.RESULTSADDUPSECCDRF" + Environment.NewLine);   // ADD 2011/04/21 
            selectTxt += IFBy(bGoodsMakerCd,
                         "   ,SALDTLSUB.GOODSMAKERCDRF" + Environment.NewLine);
            selectTxt += IFBy(bBLGoodsCode,
                         "   ,SALDTLSUB.BLGOODSCODERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGroupCode,
                         "   ,SALDTLSUB.BLGROUPCODERF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMGroup,
                         "   ,SALDTLSUB.GOODSMGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsLGroup,
                         "   ,SALDTLSUB.GOODSLGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsNo,
                         "   ,SALDTLSUB.GOODSNORF" + Environment.NewLine);
            selectTxt += "   ,SUM(SALDTLSUB.M_TOTALSALESCOUNTRF) AS MONTHTOTALSALESCOUNT" + Environment.NewLine;
            selectTxt += "   ,SUM(SALDTLSUB.M_SALESMONEYRF) AS MONTHSALESMONEY" + Environment.NewLine;
            selectTxt += "   ,SUM(SALDTLSUB.M_GROSSPROFITRF) AS MONTHGROSSPROFIT" + Environment.NewLine;
            if (bAnnual)
            {
                selectTxt += "   ,SUM(SALDTLSUB.A_TOTALSALESCOUNTRF) AS ANNUALTOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += "   ,SUM(SALDTLSUB.A_SALESMONEYRF) AS ANNUALSALESMONEY" + Environment.NewLine;
                selectTxt += "   ,SUM(SALDTLSUB.A_GROSSPROFITRF) AS ANNUALGROSSPROFIT" + Environment.NewLine;
            }
            selectTxt += "  FROM" + Environment.NewLine;
            selectTxt += "  (" + Environment.NewLine;

            #region [���㗚�𖾍׃f�[�^���o]

            if (bAnnual)
            {
                #region [�������𒊏o����]

                #region [���������o]
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     SALHISSUBA.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,SALHISSUBA.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.SALESSLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALHISSUBA.SALESDATERF" + Environment.NewLine;
                selectTxt += "    ,SALHISSUBA.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.WAREHOUSECODERF" + Environment.NewLine;
                //selectTxt += "    ,SALDTLSUBA.SECTIONCODERF" + Environment.NewLine;  // DEL 2011/04/21
                selectTxt += "    ,SALHISSUBA.RESULTSADDUPSECCDRF" + Environment.NewLine;  // ADD 2011/04/21
                selectTxt += "    ,SALDTLSUBA.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.GOODSNORF" + Environment.NewLine;
                //selectTxt += "    ,(CASE WHEN SALDTLSUBA.SHIPMENTCNTRF IS NULL THEN 0 ELSE" + Environment.NewLine;  //DEL �s�i�� 2012/03/30 Redmine#29142�@
                selectTxt += "    ,(CASE WHEN SALDTLSUBA.SHIPMENTCNTRF IS NULL OR (SALDTLSUBA.SHIPMENTCNTRF != 0 AND SALDTLSUBA.SALESSLIPCDDTLRF = 2) THEN 0 ELSE" + Environment.NewLine;  //ADD �s�i�� 2012/03/30 Redmine#29142
                selectTxt += "      SALDTLSUBA.SHIPMENTCNTRF END) AS A_TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBA.SALESMONEYTAXEXCRF AS A_SALESMONEYRF" + Environment.NewLine;
                selectTxt += "    ,(SALDTLSUBA.SALESMONEYTAXEXCRF-SALDTLSUBA.COSTRF) AS A_GROSSPROFITRF" + Environment.NewLine;
                //selectTxt += "    ,(CASE WHEN SALDTLSUBM.M_TOTALSALESCOUNTRF IS NULL THEN 0 ELSE" + Environment.NewLine;  //DEL �s�i�� 2012/03/30 Redmine#29142
                selectTxt += "    ,(CASE WHEN SALDTLSUBM.M_TOTALSALESCOUNTRF IS NULL OR (SALDTLSUBM.M_TOTALSALESCOUNTRF != 0 AND SALDTLSUBM.SALESSLIPCDDTLRF = 2) THEN 0 ELSE" + Environment.NewLine;  //ADD �s�i�� 2012/03/30 Redmine#29142
                selectTxt += "      SALDTLSUBM.M_TOTALSALESCOUNTRF END) AS M_TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.M_SALESMONEYRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.M_GROSSPROFITRF" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "   FROM SALESHISTORYRF AS SALHISSUBA" + Environment.NewLine;
                //selectTxt += "   LEFT JOIN SALESHISTDTLRF SALDTLSUBA" + Environment.NewLine;
                selectTxt += "   FROM SALESHISTORYRF AS SALHISSUBA WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "   LEFT JOIN SALESHISTDTLRF SALDTLSUBA WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += "   ON  SALDTLSUBA.ENTERPRISECODERF=SALHISSUBA.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   AND SALDTLSUBA.ACPTANODRSTATUSRF=SALHISSUBA.ACPTANODRSTATUSRF" + Environment.NewLine;  // ADD 2011/04/21
                selectTxt += "   AND SALDTLSUBA.SALESSLIPNUMRF=SALHISSUBA.SALESSLIPNUMRF" + Environment.NewLine;
                #endregion  //[���������o]

                #region [���������o]
                selectTxt += "   LEFT JOIN" + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                selectTxt += "    SELECT" + Environment.NewLine;
                selectTxt += "      SALHISSUBM2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUBM2.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.SALESSLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUBM2.SALESDATERF" + Environment.NewLine;
                selectTxt += "     ,SALHISSUBM2.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.WAREHOUSECODERF" + Environment.NewLine;
                //selectTxt += "     ,SALDTLSUBM2.SECTIONCODERF" + Environment.NewLine;    // DEL 2011/04/21
                selectTxt += "     ,SALHISSUBM2.RESULTSADDUPSECCDRF" + Environment.NewLine;  // ADD 2011/04/21
                selectTxt += "     ,SALDTLSUBM2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.GOODSNORF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.SHIPMENTCNTRF AS M_TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.SALESMONEYTAXEXCRF AS M_SALESMONEYRF" + Environment.NewLine;
                selectTxt += "     ,(SALDTLSUBM2.SALESMONEYTAXEXCRF-SALDTLSUBM2.COSTRF) AS M_GROSSPROFITRF" + Environment.NewLine;
                selectTxt += "     ,SALDTLSUBM2.SALESSLIPCDDTLRF" + Environment.NewLine;//ADD �s�i�� 2012/03/30 Redmine#29142
                // 2011/07/29 >>>
                //selectTxt += "    FROM SALESHISTORYRF AS SALHISSUBM2" + Environment.NewLine;
                //selectTxt += "    LEFT JOIN SALESHISTDTLRF SALDTLSUBM2" + Environment.NewLine;
                selectTxt += "    FROM SALESHISTORYRF AS SALHISSUBM2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "    LEFT JOIN SALESHISTDTLRF SALDTLSUBM2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += "    ON  SALDTLSUBM2.ENTERPRISECODERF=SALHISSUBM2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    AND SALDTLSUBM2.ACPTANODRSTATUSRF=SALHISSUBM2.ACPTANODRSTATUSRF" + Environment.NewLine;  // ADD 2011/04/21
                selectTxt += "    AND SALDTLSUBM2.SALESSLIPNUMRF=SALHISSUBM2.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += MakeWhereString(ref sqlCommand, CndtnWork, "SALHISSUBM2", "SALDTLSUBM2", 0);
                selectTxt += "   ) AS SALDTLSUBM" + Environment.NewLine;
                selectTxt += "   ON  SALDTLSUBM.ENTERPRISECODERF=SALHISSUBA.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   AND SALDTLSUBM.SALESSLIPNUMRF=SALHISSUBA.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "   AND SALDTLSUBM.SALESSLIPDTLNUMRF=SALDTLSUBA.SALESSLIPDTLNUMRF" + Environment.NewLine;
                #endregion  //[���������o]

                //��������WHERE��
                selectTxt += MakeWhereString(ref sqlCommand, CndtnWork, "SALHISSUBA", "SALDTLSUBA", 1);

                #endregion  //[�������𒊏o����]
            }
            else
            {
                #region [�������̂ݒ��o]
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     SALHISSUBM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,SALHISSUBM.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.SALESSLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALHISSUBM.SALESDATERF" + Environment.NewLine;
                selectTxt += "    ,SALHISSUBM.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.WAREHOUSECODERF" + Environment.NewLine;
                //selectTxt += "    ,SALDTLSUBM.SECTIONCODERF" + Environment.NewLine;  // DEL 2011/04/21
                selectTxt += "    ,SALHISSUBM.RESULTSADDUPSECCDRF" + Environment.NewLine;    // ADD 2011/04/21
                selectTxt += "    ,SALDTLSUBM.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.GOODSNORF" + Environment.NewLine;
                //selectTxt += "    ,(CASE WHEN SALDTLSUBM.SHIPMENTCNTRF IS NULL THEN 0 ELSE" + Environment.NewLine;  //DEL �s�i�� 2012/03/30 Redmine#29142
                selectTxt += "    ,(CASE WHEN SALDTLSUBM.SHIPMENTCNTRF IS NULL OR (SALDTLSUBM.SHIPMENTCNTRF != 0 AND SALDTLSUBM.SALESSLIPCDDTLRF = 2) THEN 0 ELSE" + Environment.NewLine;  //ADD �s�i�� 2012/03/30 Redmine#29142
                selectTxt += "      SALDTLSUBM.SHIPMENTCNTRF END) AS M_TOTALSALESCOUNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTLSUBM.SALESMONEYTAXEXCRF AS M_SALESMONEYRF" + Environment.NewLine;
                selectTxt += "    ,(SALDTLSUBM.SALESMONEYTAXEXCRF-SALDTLSUBM.COSTRF) AS M_GROSSPROFITRF" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "   FROM SALESHISTORYRF AS SALHISSUBM" + Environment.NewLine;
                //selectTxt += "   LEFT JOIN SALESHISTDTLRF SALDTLSUBM" + Environment.NewLine;
                selectTxt += "   FROM SALESHISTORYRF AS SALHISSUBM WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "   LEFT JOIN SALESHISTDTLRF SALDTLSUBM WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += "   ON  SALDTLSUBM.ENTERPRISECODERF=SALHISSUBM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   AND SALDTLSUBM.SALESSLIPNUMRF=SALHISSUBM.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += MakeWhereString(ref sqlCommand, CndtnWork, "SALHISSUBM", "SALDTLSUBM", 0);
                #endregion  //[�������̂ݒ��o]
            }

            #endregion  //[���㗚�𖾍׃f�[�^���o]

            selectTxt += "  ) AS SALDTLSUB" + Environment.NewLine;

            #region [GROUP BY]
            selectTxt += "  GROUP BY" + Environment.NewLine;
            selectTxt += "    SALDTLSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bWarehouseCode,
                         "   ,SALDTLSUB.WAREHOUSECODERF" + Environment.NewLine);
            selectTxt += IFBy(bCustomerCode,
                         "   ,SALDTLSUB.CUSTOMERCODERF" + Environment.NewLine);
            selectTxt += IFBy(bSectionCode,
                         //"   ,SALDTLSUB.SECTIONCODERF" + Environment.NewLine);  // DEL 2011/04/21
                         "   ,SALDTLSUB.RESULTSADDUPSECCDRF" + Environment.NewLine);  // ADD 2011/04/21
            selectTxt += IFBy(bGoodsMakerCd,
                         "   ,SALDTLSUB.GOODSMAKERCDRF" + Environment.NewLine);
            selectTxt += IFBy(bBLGoodsCode,
                         "   ,SALDTLSUB.BLGOODSCODERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGroupCode,
                         "   ,SALDTLSUB.BLGROUPCODERF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMGroup,
                         "   ,SALDTLSUB.GOODSMGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsLGroup,
                         "   ,SALDTLSUB.GOODSLGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsNo,
                         "   ,SALDTLSUB.GOODSNORF" + Environment.NewLine);
            #endregion  //[GROUP BY]

            #endregion  //[�f�[�^���o���C��Query]

            selectTxt += " ) AS SALDTL" + Environment.NewLine;

            #region [JOIN]
            if (bWarehouseCode)
            {
                //�q�Ƀ}�X�^
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN WAREHOUSERF WARHUS" + Environment.NewLine;
                selectTxt += " LEFT JOIN WAREHOUSERF WARHUS WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  WARHUS.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND WARHUS.WAREHOUSECODERF=SALDTL.WAREHOUSECODERF" + Environment.NewLine;
            }
            if (bCustomerCode)
            {
                //���Ӑ�}�X�^
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN CUSTOMERRF CUSTMR" + Environment.NewLine;
                selectTxt += " LEFT JOIN CUSTOMERRF CUSTMR WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  CUSTMR.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUSTMR.CUSTOMERCODERF=SALDTL.CUSTOMERCODERF" + Environment.NewLine;
            }
            if (bSectionCode)
            {
                //���_���ݒ�}�X�^
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  SCINST.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND SCINST.SECTIONCODERF=SALDTL.SECTIONCODERF" + Environment.NewLine;  // DEL 2011/04/21
                selectTxt += " AND SCINST.SECTIONCODERF=SALDTL.RESULTSADDUPSECCDRF" + Environment.NewLine;  // ADD 2011/04/21
            }
            if (bGoodsMakerCd)
            {
                //���[�J�[�}�X�^(���[�U�[�o�^��)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN MAKERURF MAKERU" + Environment.NewLine;
                selectTxt += " LEFT JOIN MAKERURF MAKERU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  MAKERU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MAKERU.GOODSMAKERCDRF=SALDTL.GOODSMAKERCDRF" + Environment.NewLine;
            }
            if (bGoodsMGroup)
            {
                //���i�����ރ}�X�^(���[�U�[�o�^��)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN GOODSGROUPURF GSGRPU" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSGROUPURF GSGRPU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  GSGRPU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GSGRPU.GOODSMGROUPRF=SALDTL.GOODSMGROUPRF" + Environment.NewLine;
            }
            if (bGoodsLGroup)
            {
                //���[�U�[�K�C�h�}�X�^ �����i�啪�ރK�C�h���̎擾�p
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN USERGDBDURF USGDBUL" + Environment.NewLine;
                selectTxt += " LEFT JOIN USERGDBDURF USGDBUL WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  USGDBUL.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND USGDBUL.GUIDECODERF=SALDTL.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += " AND USGDBUL.USERGUIDEDIVCDRF=70" + Environment.NewLine;
            }
            if (bBLGroupCode)
            {
                //BL�O���[�v�}�X�^(���[�U�[)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN BLGROUPURF BLGRPU" + Environment.NewLine;
                selectTxt += " LEFT JOIN BLGROUPURF BLGRPU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  BLGRPU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGRPU.BLGROUPCODERF=SALDTL.BLGROUPCODERF" + Environment.NewLine;
            }
            if (bBLGoodsCode)
            {
                //BL���i�R�[�h�}�X�^(���[�U�[)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN BLGOODSCDURF BLGCDU" + Environment.NewLine;
                selectTxt += " LEFT JOIN BLGOODSCDURF BLGCDU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  BLGCDU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGCDU.BLGOODSCODERF=SALDTL.BLGOODSCODERF" + Environment.NewLine;
            }
            if (bGoodsNo)
            {
                //���i�}�X�^(���[�U�[)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN GOODSURF GOODSU" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSURF GOODSU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  GOODSU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GOODSU.GOODSMAKERCDRF=SALDTL.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GOODSU.GOODSNORF=SALDTL.GOODSNORF" + Environment.NewLine;
            }
            #endregion  //[JOIN]

            #region [WHERE��]
            selectTxt += " WHERE" + Environment.NewLine;
            selectTxt += " SALDTL.ENTERPRISECODERF=@SALDTLENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@SALDTLENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //�o�׎w��敪����
            string sFstNm = "";
            if (CndtnWork.PrintRangeDiv == 0)
                sFstNm = "MONTH";
            else
                sFstNm = "ANNUAL";

            //����͈͎w��
            if (CndtnWork.PrintRangeSt != -99999999)
            {
                selectTxt += " AND SALDTL." + sFstNm + "TOTALSALESCOUNT>=@TOTALSALESCOUNTST" + Environment.NewLine;
                SqlParameter paraPrintRangeSt = sqlCommand.Parameters.Add("@TOTALSALESCOUNTST", SqlDbType.Int);
                paraPrintRangeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintRangeSt);
            }
            if (CndtnWork.PrintRangeEd != 999999999)
            {
                selectTxt += " AND SALDTL." + sFstNm + "TOTALSALESCOUNT<=@TOTALSALESCOUNTED" + Environment.NewLine;
                SqlParameter paraPrintRangeEd = sqlCommand.Parameters.Add("@TOTALSALESCOUNTED", SqlDbType.Int);
                paraPrintRangeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintRangeEd);
            }
            #endregion  //[WHERE��]

            #endregion  //[Select���쐬]

            return selectTxt;
        }
        #endregion  //[�q�ɗp Select����������]

        #region [���㗚�𖾍׃f�[�^�p Where�� ��������]
        /// <summary>
        /// ���㗚�𖾍׃f�[�^�pWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <param name="sSALHIS">�e�[�u�������́F���㗚���f�[�^</param>
        /// <param name="sSALDTL">�e�[�u�������́F���㗚�𖾍׃f�[�^</param>
        /// <param name="iType">�Ώ۔N�� 0:���� 1:����</param>
        /// <returns>���㗚�𖾍׃f�[�^�pWHERE��</returns>
        /// <br>Note       : ���㗚�𖾍׃f�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.02</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork, string sSALHIS, string sSALDTL, int iType)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " " + sSALHIS + ".ENTERPRISECODERF=@" + sSALHIS + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sSALHIS + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //�_���폜�敪
            retstring += " AND " + sSALDTL + ".LOGICALDELETECODERF=0 " + Environment.NewLine;

            //���_�R�[�h
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
                    // -- UPD 2011/04/21 ------------------------------->>>
                    //retstring += " AND " + sSALDTL + ".SECTIONCODERF IN (" + sectionCodestr + ") ";
                    retstring += " AND " + sSALHIS + ".RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                    // -- UPD 2011/04/21 -------------------------------<<<
                }
                retstring += Environment.NewLine;
            }

            //����`�[�敪(����)
            retstring += " AND " + sSALDTL + ".SALESSLIPCDDTLRF IN ( 0, 1, 2 )" + Environment.NewLine;

            //�Ώ۔N��
            if (iType == 0)
            {
                //����
                retstring += " AND " + sSALHIS + ".SALESDATERF>=@" + sSALHIS + "SALESDATEST" + Environment.NewLine;
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sSALHIS + "SALESDATEST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.SalesDateSt);

                retstring += " AND " + sSALHIS + ".SALESDATERF<=@" + sSALHIS + "SALESDATEHED" + Environment.NewLine;
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sSALHIS + "SALESDATEHED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.SalesDateEd);

                // -- ADD 2011/04/21 -------------------------------------------------->>>
                //���㗚�𖾍׃f�[�^�����t���w�肷��B
                retstring += " AND " + sSALDTL + ".SALESDATERF>=@" + sSALHIS + "SALESDATEST" + Environment.NewLine;

                retstring += " AND " + sSALDTL + ".SALESDATERF<=@" + sSALHIS + "SALESDATEHED" + Environment.NewLine;
                // -- ADD 2011/04/21 --------------------------------------------------<<<
            }
            else
            {
                //����
                retstring += " AND " + sSALHIS + ".SALESDATERF>=@" + sSALHIS + "SALESDATEST" + Environment.NewLine;
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sSALHIS + "SALESDATEST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AnnualSalesDateSt);

                retstring += " AND " + sSALHIS + ".SALESDATERF<=@" + sSALHIS + "SALESDATEHED" + Environment.NewLine;
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sSALHIS + "SALESDATEHED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AnnualSalesDateEd);

                // -- ADD 2011/04/21 -------------------------------------------------->>>
                //���㗚�𖾍׃f�[�^�����t���w�肷��B
                retstring += " AND " + sSALDTL + ".SALESDATERF>=@" + sSALHIS + "SALESDATEST" + Environment.NewLine;

                retstring += " AND " + sSALDTL + ".SALESDATERF<=@" + sSALHIS + "SALESDATEHED" + Environment.NewLine;
                // -- ADD 2011/04/21 --------------------------------------------------<<<
            }

            //�q�ɃR�[�h
            if (CndtnWork.WarehouseCodeSt != "")
            {
                retstring += " AND " + sSALDTL + ".WAREHOUSECODERF>=@" + sSALDTL + "WAREHOUSECODEST" + Environment.NewLine;
                SqlParameter paraWarehouseCodeSt = sqlCommand.Parameters.Add("@" + sSALDTL + "WAREHOUSECODEST", SqlDbType.NChar);
                paraWarehouseCodeSt.Value = SqlDataMediator.SqlSetString(CndtnWork.WarehouseCodeSt);
            }
            if (CndtnWork.WarehouseCodeEd != "")
            {
                retstring += " AND " + sSALDTL + ".WAREHOUSECODERF<=@" + sSALDTL + "WAREHOUSECODEED" + Environment.NewLine;
                SqlParameter paraWarehouseCodeEd = sqlCommand.Parameters.Add("@" + sSALDTL + "WAREHOUSECODEED", SqlDbType.NChar);
                paraWarehouseCodeEd.Value = SqlDataMediator.SqlSetString(CndtnWork.WarehouseCodeEd);
            }

            // 2010/01/07 Add >>>
            retstring += " AND " + sSALDTL + ".WAREHOUSECODERF<>0" + Environment.NewLine;
            // 2010/01/07 Add <<<

            //���Ӑ�R�[�h
            if (CndtnWork.CustomerCodeSt != 0)
            {
                retstring += " AND " + sSALHIS + ".CUSTOMERCODERF>=@" + sSALHIS + "CUSTOMERCODEST" + Environment.NewLine;
                SqlParameter paraCustomerCodeSt = sqlCommand.Parameters.Add("@" + sSALHIS + "CUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CustomerCodeSt);
            }
            // -- UPD 2011/04/21 ------------------------------->>>
            //if (CndtnWork.CustomerCodeEd != 999999999)
            if (CndtnWork.CustomerCodeEd != 99999999)
            // -- UPD 2011/04/21 -------------------------------<<<
            {
                retstring += " AND " + sSALHIS + ".CUSTOMERCODERF<=@" + sSALHIS + "CUSTOMERCODEED" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@" + sSALHIS + "CUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CustomerCodeEd);
            }

            //���i���[�J�[�R�[�h
            if (CndtnWork.GoodsMakerCdSt != 0)
            {
                retstring += " AND " + sSALDTL + ".GOODSMAKERCDRF>=@" + sSALDTL + "GOODSMAKERCDST" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSMAKERCDST", SqlDbType.Int);
                paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMakerCdSt);
            }
            // -- UPD 2011/04/21 ---------------------------->>>
            //if (CndtnWork.GoodsMakerCdEd != 999999)
            if (CndtnWork.GoodsMakerCdEd != 9999)
            // -- UPD 2011/04/21 ----------------------------<<<
            {
                retstring += " AND " + sSALDTL + ".GOODSMAKERCDRF<=@" + sSALDTL + "GOODSMAKERCDED" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSMAKERCDED", SqlDbType.Int);
                paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMakerCdEd);
            }

            //BL���i�R�[�h
            if (CndtnWork.BLGoodsCodeSt != 0)
            {
                retstring += " AND " + sSALDTL + ".BLGOODSCODERF>=@" + sSALDTL + "BLGOODSCODEST" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@" + sSALDTL + "BLGOODSCODEST", SqlDbType.Int);
                paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeSt);
            }
            // -- UPD 2011/04/24 -------------------------->>>
            //if (CndtnWork.BLGoodsCodeEd != 99999999)
            if (CndtnWork.BLGoodsCodeEd != 99999)
            // -- UPD 2011/04/24 --------------------------<<<
            {
                retstring += " AND " + sSALDTL + ".BLGOODSCODERF<=@" + sSALDTL + "BLGOODSCODEED" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@" + sSALDTL + "BLGOODSCODEED", SqlDbType.Int);
                paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeEd);
            }

            //���i�ԍ�
            if (CndtnWork.GoodsNoSt != "")
            {
                retstring += " AND " + sSALDTL + ".GOODSNORF>=@" + sSALDTL + "GOODSNOST" + Environment.NewLine;
                SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSNOST", SqlDbType.NVarChar);
                paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoSt);
            }
            if (CndtnWork.GoodsNoEd != "")
            {
                retstring += " AND " + sSALDTL + ".GOODSNORF<=@" + sSALDTL + "GOODSNOED" + Environment.NewLine;
                SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSNOED", SqlDbType.NVarChar);
                paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoEd);
            }

            //BL�O���[�v�R�[�h
            if (CndtnWork.BLGroupCodeSt != 0)
            {
                retstring += " AND " + sSALDTL + ".BLGROUPCODERF>=@" + sSALDTL + "BLGROUPCODEST" + Environment.NewLine;
                SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@" + sSALDTL + "BLGROUPCODEST", SqlDbType.Int);
                paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeSt);
            }
            if (CndtnWork.BLGroupCodeEd != 99999)
            {
                retstring += " AND ( " + sSALDTL + ".BLGROUPCODERF<=@" + sSALDTL + "BLGROUPCODEED OR " + sSALDTL + ".BLGROUPCODERF IS NULL )" + Environment.NewLine;
                SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@" + sSALDTL + "BLGROUPCODEED", SqlDbType.Int);
                paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeEd);
            }

            //�J�n���i�啪�ރR�[�h
            if (CndtnWork.GoodsLGroupSt != 0)
            {
                retstring += " AND " + sSALDTL + ".GOODSLGROUPRF>=@" + sSALDTL + "GOODSLGROUPST" + Environment.NewLine;
                SqlParameter paraGoodsLGroupSt = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSLGROUPST", SqlDbType.Int);
                paraGoodsLGroupSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsLGroupSt);
            }
            if (CndtnWork.GoodsLGroupEd != 9999)
            {
                retstring += " AND ( " + sSALDTL + ".GOODSLGROUPRF<=@" + sSALDTL + "GOODSLGROUPED OR " + sSALDTL + ".GOODSLGROUPRF IS NULL)" + Environment.NewLine;
                SqlParameter paraGoodsLGroupEd = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSLGROUPED", SqlDbType.Int);
                paraGoodsLGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsLGroupEd);
            }

            //�J�n���i�����ރR�[�h
            if (CndtnWork.GoodsMGroupSt != 0)
            {
                retstring += " AND " + sSALDTL + ".GOODSMGROUPRF>=@" + sSALDTL + "GOODSMGROUPST" + Environment.NewLine;
                SqlParameter paraGoodsMGroupSt = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSMGROUPST", SqlDbType.Int);
                paraGoodsMGroupSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupSt);
            }
            if (CndtnWork.GoodsMGroupEd != 9999)
            {
                retstring += " AND ( " + sSALDTL + ".GOODSMGROUPRF<=@" + sSALDTL + "GOODSMGROUPED OR " + sSALDTL + ".GOODSMGROUPRF IS NULL)" + Environment.NewLine;
                SqlParameter paraGoodsMGroupEd = sqlCommand.Parameters.Add("@" + sSALDTL + "GOODSMGROUPED", SqlDbType.Int);
                paraGoodsMGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupEd);
            }
            #endregion  //WHERE���쐬

            return retstring;
        }
        #endregion  //[���㗚�𖾍׃f�[�^�p Where�� ��������]

        #region [CopyToSalesRsltListResultWorkFromReader���� �ďo]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        public SalesRsltListResultWork CopyToSalesRsltListResultWorkFromReader(ref SqlDataReader myReader, SalesRsltListCndtnWork CndtnWork)
        {
            return this.CopyToSalesRsltListResultWorkFromReaderProc(ref myReader, CndtnWork);
        }
        #endregion  //[CopyToSalesRsltListResultWorkFromReader���� �ďo]

        #region [CopyToSalesRsltListResultWorkFromReader����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToSalesRsltListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CopyToSalesRsltListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.02</br>
        /// <br>Update Note: 2009.04.28 ����</br>
        /// <br>            �E���[�J�[����==>���[�J�[����
        /// </remarks>
        private SalesRsltListResultWork CopyToSalesRsltListResultWorkFromReaderProc(ref SqlDataReader myReader, SalesRsltListCndtnWork CndtnWork)
        {
            #region [���ʗp�t���O]
            //���_�R�[�h
            if (((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.TtlType == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.TtlType == 1) && (CndtnWork.Detail != 7)))
            {
                bSectionCode = true;
            }

            //�q�ɃR�[�h
            if (((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.SecWhous) && (CndtnWork.Detail == 6)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 6)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousSec) && (CndtnWork.Detail == 7)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 6)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 7)))
            {
                bWarehouseCode = true;
            }

            //���Ӑ�R�[�h
            if (((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 0)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 4)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 5)) ||
                ((CndtnWork.PrintType == (int)PrintType.WhousCstm) && (CndtnWork.Detail == 6)))
            {
                bCustomerCode = true;
            }

            //���i�ԍ�
            if (CndtnWork.Detail == 0)
            {
                bGoodsNo = true;
            }

            //���i���[�J�[�R�[�h
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 5) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 1)) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 2)) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 3)) ||
                ((CndtnWork.MakerPrintDiv == 1) && (CndtnWork.Detail == 4)))
            {
                bGoodsMakerCd = true;
            }

            //BL���i�R�[�h
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1))
            {
                bBLGoodsCode = true;
            }

            //BL�O���[�v�R�[�h
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2))
            {
                bBLGroupCode = true;
            }

            //���i�����ރR�[�h
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2) ||
                (CndtnWork.Detail == 3))
            {
                bGoodsMGroup = true;
            }

            //���i�啪�ރR�[�h
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2) ||
                (CndtnWork.Detail == 3) ||
                (CndtnWork.Detail == 4))
            {
                bGoodsLGroup = true;
            }

            //�������
            if (CndtnWork.AnnualPrintDiv == 1)
            {
                bAnnual = true;
            }
            #endregion  //[���ʗp�t���O]

            #region [���o����-�l�Z�b�g]
            SalesRsltListResultWork ResultWork = new SalesRsltListResultWork();

            if (bWarehouseCode)
            {
                ResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                ResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            }
            if (bCustomerCode)
            {
                ResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                ResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            }
            if (bSectionCode)
            {
                //ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // DEL 2011/04/21
                ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));  // ADD 2011/04/21
                ResultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            }
            if (bGoodsMakerCd)
            {
                ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));  // Update 2009/04/28
            }
            if (bGoodsLGroup)
            {
                ResultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                ResultWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAME"));
            }
            if (bGoodsMGroup)
            {
                ResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                ResultWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
            }
            if (bBLGroupCode)
            {
                ResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                ResultWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
            }
            if (bBLGoodsCode)
            {
                ResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                ResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            }
            if (bGoodsNo)
            {
                ResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                ResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            }

            //����
            ResultWork.MonthTotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHTOTALSALESCOUNT"));
            ResultWork.MonthSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESMONEY"));
            ResultWork.MonthGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHGROSSPROFIT"));
            //����
            if (bAnnual)
            {
                ResultWork.AnnualTotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANNUALTOTALSALESCOUNT"));
                ResultWork.AnnualSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALSALESMONEY"));
                ResultWork.AnnualGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALGROSSPROFIT"));
            }
            #endregion  //[���o����-�l�Z�b�g]

            return ResultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader����]
    }
}


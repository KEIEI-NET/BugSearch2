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
    class MTtlSaSlipGoods : MTtlSaSlipBase, IMTtlSaSlip
    {
        #region [���ʗp�t���O�錾]
        private bool bAddUpSecCode = false;  //�v�㋒�_�R�[�h
        private bool bGoodsMakerCd = false;  //���i���[�J�[�R�[�h
        private bool bBLGoodsCode = false;   //BL���i�R�[�h
        private bool bGoodsNo = false;       //���i�ԍ�
        private bool bBLGroupCode = false;   //BL�O���[�v�R�[�h
        private bool bGoodsMGroup = false;   //���i�����ރR�[�h
        private bool bGoodsLGroup = false;   //���i�啪�ރR�[�h
        // --- DEL 2015/05/08 zhujc �O���[�o���ϐ��폜 ------>>>>>>
        // --- ADD START 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX-------------------------------->>>>>
        //private bool oldGoodsPrint = false;   //���Z�̏ꍇ�A�����i�\��
        //private bool newGoodsPrint = false;   //���Z�̏ꍇ�A�V���i�\��
        // --- ADD END 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX--------------------------------<<<<<
        // --- DEL 2015/05/08 zhujc �O���[�o���ϐ��폜 ------<<<<<<
        #endregion  //[���ʗp�t���O�錾]

        #region [���i�ʗp Select��]
        /// <summary>
        /// ���i�ʗpSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>���i�ʗpSELECT��</returns>
        /// <br>Note       : ���i�ʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.02</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, CndtnWork);
        }
        #endregion  //[���i�ʗp Select��]

        #region [���i�ʗp Select����������]
        /// <summary>
        /// ���i�ʗpSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>���i�ʗpSELECT��</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.02</br>
        /// <br>Update Note: 2009.04.28 ����</br>
        /// <br>            �E���[�J�[����==>���[�J�[����
        /// <br>Update Note: 2010/05/13 �������n</br>
        /// <br>            �E�i���̎擾���@��ύX
        /// <br>Update Note: 2014/12/16 �� ��</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           : �����Y�ƗlSeiken�i�ԕύX</br>
        /// <br>Update Note: 2015/04/01 zhangll</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           : Redmine#44209��#434 �i�ԏ������w�肵���ꍇ�APM7�����Q�̑Ή�</br>
        /// <br>Update Note: 2015/05/08 zhujc</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           : �O���[�o���ϐ��폜</br>
        /// </remarks>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork)
        {
            #region [���ʗp�t���O]
            //�v�㋒�_�R�[�h
            if (CndtnWork.TtlType == 1)
            {
                bAddUpSecCode = true;
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

            // --- ADD 2015/05/08 zhujc �O���[�o���ϐ��폜 ------>>>>>>
            bool oldGoodsPrint = false;   //���Z�̏ꍇ�A�����i�\��
            bool newGoodsPrint = false;   //���Z�̏ꍇ�A�V���i�\��
            // --- ADD 2015/05/08 zhujc �O���[�o���ϐ��폜 ------<<<<<<

            // --- ADD START 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX-------------------------------->>>>>
            //�V���i�Ԃ̕\��
            //���Z�̏ꍇ�A���i�Ԃ̕\��
            if ((CndtnWork.GoodsNoSumDiv == 1) &&
               (CndtnWork.GoodsNoDisDiv == 1))
            {
                oldGoodsPrint = true;
                newGoodsPrint = false;
            }
            //���Z�̏ꍇ�A�V�i�Ԃ̕\��
            else if ((CndtnWork.GoodsNoSumDiv == 1) &&
                    (CndtnWork.GoodsNoDisDiv == 0))
            {
                oldGoodsPrint = false;
                newGoodsPrint = true;
            }
            //�ʁX�̏ꍇ�A�����̏����Ɠ���
            else
            {
                oldGoodsPrint = false;
                newGoodsPrint = false;
            }
            // --- ADD END 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX--------------------------------<<<<<
            #endregion  //[���ʗp�t���O]

            string selectTxt = "";

            // �Ώۃe�[�u��
            // GOODSMTTLSASLIPRF GSMSLP ���i�ʔ��㌎���W�v�f�[�^
            // GOODSURF          GOODSU ���i�}�X�^(���[�U�[)
            // BLGOODSCDURF      BLGCDU BL���i�R�[�h�}�X�^(���[�U�[)
            // BLGROUPURF        BLGRPU BL�O���[�v�}�X�^(���[�U�[)
            // MAKERURF          MAKERU ���[�J�[�}�X�^(���[�U�[�o�^��)
            // USERGDBDURF       USGDBU ���[�U�[�K�C�h�}�X�^(�{�f�B)(���[�U�ύX��)
            // SECINFOSETRF      SCINST ���_���ݒ�}�X�^
            // GOODSGROUPURF     GSGRPU ���i�����ރ}�X�^(���[�U�[�o�^��)

            #region [Select���쐬]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bAddUpSecCode,
                         " ,GSMSLP.ADDUPSECCODERF" + Environment.NewLine);
            selectTxt += IFBy(bAddUpSecCode,
                         " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMakerCd,
                         " ,GSMSLP.GOODSMAKERCDRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMakerCd,
                         " ,MAKERU.MAKERNAMERF" + Environment.NewLine);  // Update 2009/04/28
            selectTxt += IFBy(bBLGoodsCode,
                         " ,GSMSLP.BLGOODSCODERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGoodsCode,
                         " ,BLGCDU.BLGOODSHALFNAMERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGroupCode,
                         " ,GSMSLP.BLGROUPCODERF" + Environment.NewLine);
            selectTxt += IFBy(bBLGroupCode,
                         " ,BLGRPU.BLGROUPKANANAMERF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMGroup,
                         " ,GSMSLP.GOODSMGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMGroup,
                         " ,GSGRPU.GOODSMGROUPNAMERF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsLGroup,
                         " ,GSMSLP.GOODSLGROUPRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsLGroup,
                         " ,USGDBUL.GUIDENAMERF AS GOODSLGROUPNAME" + Environment.NewLine);
            selectTxt += IFBy(bGoodsNo,
                         " ,GSMSLP.GOODSNORF" + Environment.NewLine);
            // -- UPD 2010/05/13 ------------------------------------------>>>
            //selectTxt += IFBy(bGoodsNo,
            //             " ,GOODSU.GOODSNAMEKANARF" + Environment.NewLine);
            //selectTxt += IFBy(bGoodsNo,
            //                 " ,(CASE WHEN GOODSU.GOODSNAMEKANARF IS NULL THEN GSMSLP2.GOODSNAMEKANARF ELSE GOODSU.GOODSNAMEKANARF END) AS GOODSNAMEKANARF" + Environment.NewLine); // DEL 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX
            // --- ADD START 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX-------------------------------->>>>>
            //���Z�̏ꍇ�A�i���̎擾
            if (newGoodsPrint || oldGoodsPrint)
            {
                // �V�i�Ԃ̂Ƃ��́A�V�i�ԃ}�X�^���V�i�ԏW�v�f�[�^�����i�ԃ}�X�^�����i�ԏW�v�f�[�^�̗D�揇�ʂŎ擾
                // ���i�Ԃ̂Ƃ��́A���i�ԃ}�X�^�����i�ԏW�v�f�[�^���V�i�ԃ}�X�^���V�i�ԏW�v�f�[�^�̗D�揇�ʂŎ擾
                selectTxt += IFBy(bGoodsNo,
                             " ,(CASE WHEN GOODSU.GOODSNAMEKANARF IS NULL THEN"
                               +  "(CASE WHEN GSMSLP2.GOODSNAMEKANARF IS NULL THEN"
                               +   "(CASE WHEN GOODSU2.GOODSNAMEKANARF IS NULL THEN GSMSLP3.GOODSNAMEKANARF ELSE GOODSU2.GOODSNAMEKANARF END)"
                               +  "ELSE GSMSLP2.GOODSNAMEKANARF END) "
                               +"ELSE GOODSU.GOODSNAMEKANARF END) AS GOODSNAMEKANARF" + Environment.NewLine);
            }
            else
            {
                selectTxt += IFBy(bGoodsNo,
                             " ,(CASE WHEN GOODSU.GOODSNAMEKANARF IS NULL THEN GSMSLP2.GOODSNAMEKANARF ELSE GOODSU.GOODSNAMEKANARF END) AS GOODSNAMEKANARF" + Environment.NewLine);
            }
            // --- ADD END 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX--------------------------------<<<<<
            // -- UPD 2010/05/13 ------------------------------------------<<<
            //����
            selectTxt += " ,GSMSLP.MONTHTOTALSALESCOUNT" + Environment.NewLine;
            selectTxt += " ,GSMSLP.MONTHSALESMONEY" + Environment.NewLine;
            selectTxt += " ,GSMSLP.MONTHSALESRETGOODSPRICE" + Environment.NewLine;
            selectTxt += " ,GSMSLP.MONTHDISCOUNTPRICE" + Environment.NewLine;
            selectTxt += " ,GSMSLP.MONTHGROSSPROFIT" + Environment.NewLine;
            //����
            selectTxt += " ,GSMSLP.ANNUALTOTALSALESCOUNT" + Environment.NewLine;
            selectTxt += " ,GSMSLP.ANNUALSALESMONEY" + Environment.NewLine;
            selectTxt += " ,GSMSLP.ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
            selectTxt += " ,GSMSLP.ANNUALDISCOUNTPRICE" + Environment.NewLine;
            selectTxt += " ,GSMSLP.ANNUALGROSSPROFIT" + Environment.NewLine;
            //FROM
            selectTxt += " FROM" + Environment.NewLine;
            selectTxt += " (" + Environment.NewLine;

            #region [�f�[�^���o���C��Query]
            //�݌Ɏ�񂹋敪�ŕς�鍀�ڂ𓮓I����
            if (CndtnWork.RsltTtlDivCd == (int)RsltTtlDivCd.Order)
            {
                #region [��񂹂̏ꍇ]

                #region [���v�����o]
                selectTxt += "  SELECT" + Environment.NewLine;
                selectTxt += "    GSMSLPP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "   ,GSMSLPP.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMakerCd,
                             "   ,GSMSLPP.GOODSMAKERCDRF" + Environment.NewLine);
                selectTxt += IFBy(bBLGoodsCode,
                             "   ,GSMSLPP.BLGOODSCODERF" + Environment.NewLine);
                selectTxt += IFBy(bBLGroupCode,
                             "   ,GSMSLPP.BLGROUPCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMGroup,
                             "   ,GSMSLPP.GOODSMGROUPRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsLGroup,
                             "   ,GSMSLPP.GOODSLGROUPRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsNo,
                             "   ,GSMSLPP.GOODSNORF" + Environment.NewLine);
                //����
                selectTxt += "   ,(CASE WHEN GSMSLPP.MONTHTOTALSALESCOUNT<>0 THEN (CASE WHEN GSMSLPS.MONTHTOTALSALESCOUNT<>0 THEN (GSMSLPP.MONTHTOTALSALESCOUNT-GSMSLPS.MONTHTOTALSALESCOUNT) ELSE GSMSLPP.MONTHTOTALSALESCOUNT END) ELSE 0 END) AS MONTHTOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.MONTHSALESMONEY<>0 THEN (CASE WHEN GSMSLPS.MONTHSALESMONEY<>0 THEN (GSMSLPP.MONTHSALESMONEY-GSMSLPS.MONTHSALESMONEY) ELSE GSMSLPP.MONTHSALESMONEY END) ELSE 0 END) AS MONTHSALESMONEY" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.MONTHSALESRETGOODSPRICE<>0 THEN (CASE WHEN GSMSLPS.MONTHSALESRETGOODSPRICE<>0 THEN (GSMSLPP.MONTHSALESRETGOODSPRICE-GSMSLPS.MONTHSALESRETGOODSPRICE) ELSE GSMSLPP.MONTHSALESRETGOODSPRICE END) ELSE 0 END) AS MONTHSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.MONTHDISCOUNTPRICE<>0 THEN (CASE WHEN GSMSLPS.MONTHDISCOUNTPRICE<>0 THEN (GSMSLPP.MONTHDISCOUNTPRICE-GSMSLPS.MONTHDISCOUNTPRICE) ELSE GSMSLPP.MONTHDISCOUNTPRICE END) ELSE 0 END) AS MONTHDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.MONTHGROSSPROFIT<>0 THEN (CASE WHEN GSMSLPS.MONTHGROSSPROFIT<>0 THEN (GSMSLPP.MONTHGROSSPROFIT-GSMSLPS.MONTHGROSSPROFIT) ELSE GSMSLPP.MONTHGROSSPROFIT END) ELSE 0 END) AS MONTHGROSSPROFIT" + Environment.NewLine;
                //����
                selectTxt += "   ,(CASE WHEN GSMSLPP.ANNUALTOTALSALESCOUNT<>0 THEN (CASE WHEN GSMSLPS.ANNUALTOTALSALESCOUNT<>0 THEN (GSMSLPP.ANNUALTOTALSALESCOUNT-GSMSLPS.ANNUALTOTALSALESCOUNT) ELSE GSMSLPP.ANNUALTOTALSALESCOUNT END) ELSE 0 END) AS ANNUALTOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.ANNUALSALESMONEY<>0 THEN (CASE WHEN GSMSLPS.ANNUALSALESMONEY<>0 THEN (GSMSLPP.ANNUALSALESMONEY-GSMSLPS.ANNUALSALESMONEY) ELSE GSMSLPP.ANNUALSALESMONEY END) ELSE 0 END) AS ANNUALSALESMONEY" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.ANNUALSALESRETGOODSPRICE<>0 THEN (CASE WHEN GSMSLPS.ANNUALSALESRETGOODSPRICE<>0 THEN (GSMSLPP.ANNUALSALESRETGOODSPRICE-GSMSLPS.ANNUALSALESRETGOODSPRICE) ELSE GSMSLPP.ANNUALSALESRETGOODSPRICE END) ELSE 0 END) AS ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.ANNUALDISCOUNTPRICE<>0 THEN (CASE WHEN GSMSLPS.ANNUALDISCOUNTPRICE<>0 THEN (GSMSLPP.ANNUALDISCOUNTPRICE-GSMSLPS.ANNUALDISCOUNTPRICE) ELSE GSMSLPP.ANNUALDISCOUNTPRICE END) ELSE 0 END) AS ANNUALDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.ANNUALGROSSPROFIT<>0 THEN (CASE WHEN GSMSLPS.ANNUALGROSSPROFIT<>0 THEN (GSMSLPP.ANNUALGROSSPROFIT-GSMSLPS.ANNUALGROSSPROFIT) ELSE GSMSLPP.ANNUALGROSSPROFIT END) ELSE 0 END) AS ANNUALGROSSPROFIT" + Environment.NewLine;
                selectTxt += "  FROM" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                //���v�����o�T�uQuery
                //selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPPSUB", (int)RsltTtlDivCd.PrtTtl);//DEL 2015/05/08 zhujc �O���[�o���ϐ��폜
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPPSUB", (int)RsltTtlDivCd.PrtTtl, oldGoodsPrint, newGoodsPrint);//ADD 2015/05/08 zhujc �O���[�o���ϐ��폜

                selectTxt += "  ) AS GSMSLPP" + Environment.NewLine;
                #endregion  //[���v�����o]

                #region [�݌ɕ����o]
                selectTxt += "  LEFT JOIN" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     GSMSLPSSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,GSMSLPSSUB.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMakerCd,
                             "    ,GSMSLPSSUB.GOODSMAKERCDRF" + Environment.NewLine);
                selectTxt += IFBy(bBLGoodsCode,
                             "    ,GSMSLPSSUB.BLGOODSCODERF" + Environment.NewLine);
                // 2010/01/13 >>>
                //selectTxt += IFBy(bBLGroupCode,
                //             "    ,GSMSLPSSUB.BLGROUPCODERF" + Environment.NewLine);
                //selectTxt += IFBy(bGoodsMGroup,
                //             "    ,GSMSLPSSUB.GOODSMGROUPRF" + Environment.NewLine);
                //selectTxt += IFBy(bGoodsLGroup,
                //             "    ,GSMSLPSSUB.GOODSLGROUPRF" + Environment.NewLine);
                selectTxt += IFBy(bBLGroupCode,
                             "    ,(CASE WHEN GSMSLPSSUB.BLGROUPCODERF IS NULL THEN 0 ELSE GSMSLPSSUB.BLGROUPCODERF END) AS BLGROUPCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMGroup,
                             "    ,(CASE WHEN GSMSLPSSUB.GOODSMGROUPRF IS NULL THEN 0 ELSE GSMSLPSSUB.GOODSMGROUPRF END) AS GOODSMGROUPRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsLGroup,
                             "    ,(CASE WHEN GSMSLPSSUB.GOODSLGROUPRF IS NULL THEN 0 ELSE GSMSLPSSUB.GOODSLGROUPRF END) AS GOODSLGROUPRF" + Environment.NewLine);
                // 2010/01/13 <<<
                selectTxt += IFBy(bGoodsNo,
                             "    ,GSMSLPSSUB.GOODSNORF" + Environment.NewLine);
                //����
                selectTxt += "    ,GSMSLPSSUB.MONTHTOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.MONTHSALESMONEY" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.MONTHSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.MONTHDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.MONTHGROSSPROFIT" + Environment.NewLine;
                //����
                selectTxt += "    ,GSMSLPSSUB.ANNUALTOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.ANNUALSALESMONEY" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.ANNUALDISCOUNTPRICE" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.ANNUALGROSSPROFIT" + Environment.NewLine;
                selectTxt += "   FROM" + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                //�݌ɕ����o�T�uQuery
                //selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPSSUB2", (int)RsltTtlDivCd.Stock);//DEL 2015/05/08 zhujc �O���[�o���ϐ��폜
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPSSUB2", (int)RsltTtlDivCd.Stock, oldGoodsPrint, newGoodsPrint);//ADD 2015/05/08 zhujc �O���[�o���ϐ��폜

                selectTxt += "   ) AS GSMSLPSSUB" + Environment.NewLine;
                selectTxt += "  ) AS GSMSLPS" + Environment.NewLine;
                selectTxt += "  ON  GSMSLPS.ENTERPRISECODERF=GSMSLPP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "  AND GSMSLPS.ADDUPSECCODERF=GSMSLPP.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMakerCd,
                             "  AND GSMSLPS.GOODSMAKERCDRF=GSMSLPP.GOODSMAKERCDRF" + Environment.NewLine);
                selectTxt += IFBy(bBLGoodsCode,
                             "  AND GSMSLPS.BLGOODSCODERF=GSMSLPP.BLGOODSCODERF" + Environment.NewLine);
                selectTxt += IFBy(bBLGroupCode,
                             "  AND GSMSLPS.BLGROUPCODERF=GSMSLPP.BLGROUPCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMGroup,
                             "  AND GSMSLPS.GOODSMGROUPRF=GSMSLPP.GOODSMGROUPRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsLGroup,
                             "  AND GSMSLPS.GOODSLGROUPRF=GSMSLPP.GOODSLGROUPRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsNo,
                             "  AND GSMSLPS.GOODSNORF=GSMSLPP.GOODSNORF" + Environment.NewLine);
                #endregion  //[�݌ɕ����o]

                #endregion  //[��񂹂̏ꍇ]
            }
            else
            {
                //���vor�݌ɂ̏ꍇ
                //selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPSUB", CndtnWork.RsltTtlDivCd);//DEL 2015/05/08 zhujc �O���[�o���ϐ��폜
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPSUB", CndtnWork.RsltTtlDivCd, oldGoodsPrint, newGoodsPrint);//ADD 2015/05/08 zhujc �O���[�o���ϐ��폜
            }
            #endregion  //[�f�[�^���o���C��Query]

            selectTxt += " ) AS GSMSLP" + Environment.NewLine;

            #region [JOIN]
            if (bAddUpSecCode)
            {
                //���_���ݒ�}�X�^
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  SCINST.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=GSMSLP.ADDUPSECCODERF" + Environment.NewLine;
            }
            if (bGoodsMakerCd)
            {
                //���[�J�[�}�X�^(���[�U�[�o�^��)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN MAKERURF MAKERU" + Environment.NewLine;
                selectTxt += " LEFT JOIN MAKERURF MAKERU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  MAKERU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MAKERU.GOODSMAKERCDRF=GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
            }
            if (bGoodsMGroup)
            {
                //���i�����ރ}�X�^(���[�U�[�o�^��)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN GOODSGROUPURF GSGRPU" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSGROUPURF GSGRPU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  GSGRPU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GSGRPU.GOODSMGROUPRF=GSMSLP.GOODSMGROUPRF" + Environment.NewLine;
            }
            if (bGoodsLGroup)
            {
                //���[�U�[�K�C�h�}�X�^ �����i�啪�ރK�C�h���̎擾�p
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN USERGDBDURF USGDBUL" + Environment.NewLine;
                selectTxt += " LEFT JOIN USERGDBDURF USGDBUL WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  USGDBUL.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND USGDBUL.GUIDECODERF=GSMSLP.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += " AND USGDBUL.USERGUIDEDIVCDRF=70" + Environment.NewLine;
            }
            if (bBLGroupCode)
            {
                //BL�O���[�v�}�X�^(���[�U�[)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN BLGROUPURF BLGRPU" + Environment.NewLine;
                selectTxt += " LEFT JOIN BLGROUPURF BLGRPU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  BLGRPU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGRPU.BLGROUPCODERF=GSMSLP.BLGROUPCODERF" + Environment.NewLine;
            }
            if (bBLGoodsCode)
            {
                //BL���i�R�[�h�}�X�^(���[�U�[)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN BLGOODSCDURF BLGCDU" + Environment.NewLine;
                selectTxt += " LEFT JOIN BLGOODSCDURF BLGCDU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  BLGCDU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGCDU.BLGOODSCODERF=GSMSLP.BLGOODSCODERF" + Environment.NewLine;
            }
            if ((bGoodsNo))
            {
                //���i�}�X�^(���[�U�[)
                // 2011/07/29 >>>
                //selectTxt += " LEFT JOIN GOODSURF GOODSU" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSURF GOODSU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += " ON  GOODSU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GOODSU.GOODSMAKERCDRF=GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GOODSU.GOODSNORF=GSMSLP.GOODSNORF" + Environment.NewLine;

                //-- ADD 2010/05/13 -------------------------------------------->>>
                selectTxt += " LEFT JOIN " + Environment.NewLine;
                selectTxt += " ( " + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "     ,GOODSNORF" + Environment.NewLine;
                selectTxt += "     ,MAX(GOODSNAMEKANARF) AS GOODSNAMEKANARF" + Environment.NewLine;
                selectTxt += "   FROM" + Environment.NewLine;
                // 2011/07/29 >>>
                //selectTxt += "     GOODSMTTLSASLIPRF" + Environment.NewLine;
                selectTxt += "     GOODSMTTLSASLIPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/07/29 <<<
                selectTxt += "   WHERE" + Environment.NewLine;
                selectTxt += "         ENTERPRISECODERF=@GSMSLP2ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     AND ADDUPYEARMONTHRF>=@GSMSLP2ADDUPYEARMONTHST" + Environment.NewLine;
                selectTxt += "     AND ADDUPYEARMONTHRF<=@GSMSLP2ADDUPYEARMONTHED" + Environment.NewLine;
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "     ,GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "     ,GOODSNORF" + Environment.NewLine;
                selectTxt += " ) AS GSMSLP2 " + Environment.NewLine;
                selectTxt += " ON  GSMSLP2.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GSMSLP2.GOODSMAKERCDRF=GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GSMSLP2.GOODSNORF=GSMSLP.GOODSNORF" + Environment.NewLine;

                SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@GSMSLP2ENTERPRISECODERF", SqlDbType.NChar);
                paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@GSMSLP2ADDUPYEARMONTHST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AnnualAddUpYearMonthSt);

                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@GSMSLP2ADDUPYEARMONTHED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AnnualAddUpYaerMonthEd);
                //-- ADD 2010/05/13 --------------------------------------------<<<
                // --- ADD START 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX-------------------------------->>>>>
                //���Z�ŐV�i�Ԃ̂Ƃ��́A���i�ԃ}�X�^�����i�ԏW�v�f�[�^�̕i�������
                //���Z�ŋ��i�Ԃ̂Ƃ��́A�V�i�ԃ}�X�^���V�i�ԏW�v�f�[�^�̕i�������
                if (newGoodsPrint || oldGoodsPrint)
                {
                    selectTxt += " LEFT JOIN " + Environment.NewLine;
                    selectTxt += " ( " + Environment.NewLine;
                    selectTxt += "   SELECT" + Environment.NewLine;
                    selectTxt += "      GOODSNOCHANGE1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE1.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE1.CHGSRCGOODSNORF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE1.CHGDESTGOODSNORF" + Environment.NewLine;
                    selectTxt += "     ,MAX(GOODSU3.GOODSNAMEKANARF) AS GOODSNAMEKANARF" + Environment.NewLine;
                    selectTxt += "   FROM GOODSNOCHANGERF AS GOODSNOCHANGE1 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   LEFT JOIN GOODSURF GOODSU3 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  GOODSU3.ENTERPRISECODERF=GOODSNOCHANGE1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND GOODSU3.GOODSMAKERCDRF=GOODSNOCHANGE1.GOODSMAKERCDRF" + Environment.NewLine;
                    if (newGoodsPrint)
                    {
                        selectTxt += "   AND GOODSU3.GOODSNORF=GOODSNOCHANGE1.CHGSRCGOODSNORF" + Environment.NewLine;
                    }
                    else
                    {
                        selectTxt += "   AND GOODSU3.GOODSNORF=GOODSNOCHANGE1.CHGDESTGOODSNORF" + Environment.NewLine;
                    }
                    selectTxt += "   AND GOODSNOCHANGE1.LOGICALDELETECODERF=0" + Environment.NewLine;
                    selectTxt += "   GROUP BY" + Environment.NewLine;
                    selectTxt += "      GOODSNOCHANGE1.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE1.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE1.CHGSRCGOODSNORF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE1.CHGDESTGOODSNORF" + Environment.NewLine;
                    selectTxt += " ) GOODSU2 " + Environment.NewLine;
                    selectTxt += " ON  GOODSU2.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " AND GOODSU2.GOODSMAKERCDRF=GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                    if (newGoodsPrint)
                    {
                        selectTxt += " AND GOODSU2.CHGDESTGOODSNORF=GSMSLP.GOODSNORF" + Environment.NewLine;
                    }
                    else
                    {
                        selectTxt += " AND GOODSU2.CHGSRCGOODSNORF=GSMSLP.GOODSNORF" + Environment.NewLine;
                    }

                    selectTxt += " LEFT JOIN " + Environment.NewLine;
                    selectTxt += " ( " + Environment.NewLine;
                    selectTxt += "   SELECT" + Environment.NewLine;
                    selectTxt += "      GOODSNOCHANGE2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE2.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE2.CHGSRCGOODSNORF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE2.CHGDESTGOODSNORF" + Environment.NewLine;
                    selectTxt += "     ,MAX(MTL.GOODSNAMEKANARF) AS GOODSNAMEKANARF" + Environment.NewLine;
                    selectTxt += "   FROM GOODSNOCHANGERF AS GOODSNOCHANGE2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   LEFT JOIN GOODSMTTLSASLIPRF MTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                    selectTxt += "   ON  MTL.ENTERPRISECODERF=GOODSNOCHANGE2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "   AND MTL.GOODSMAKERCDRF=GOODSNOCHANGE2.GOODSMAKERCDRF" + Environment.NewLine;
                    if (newGoodsPrint)
                    {
                        selectTxt += "   AND MTL.GOODSNORF=GOODSNOCHANGE2.CHGSRCGOODSNORF" + Environment.NewLine;
                    }
                    else
                    {
                        selectTxt += "   AND MTL.GOODSNORF=GOODSNOCHANGE2.CHGDESTGOODSNORF" + Environment.NewLine;
                    }
                    selectTxt += "   AND GOODSNOCHANGE2.LOGICALDELETECODERF=0" + Environment.NewLine;
                    selectTxt += "   WHERE" + Environment.NewLine;
                    selectTxt += "         MTL.ENTERPRISECODERF=@GNOCGEENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     AND MTL.ADDUPYEARMONTHRF>=@GNOCGEADDUPYEARMONTHST" + Environment.NewLine;
                    selectTxt += "     AND MTL.ADDUPYEARMONTHRF<=@GNOCGEADDUPYEARMONTHED" + Environment.NewLine;
                    selectTxt += "   GROUP BY" + Environment.NewLine;
                    selectTxt += "      GOODSNOCHANGE2.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE2.GOODSMAKERCDRF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE2.CHGSRCGOODSNORF" + Environment.NewLine;
                    selectTxt += "     ,GOODSNOCHANGE2.CHGDESTGOODSNORF" + Environment.NewLine;
                    selectTxt += " ) GSMSLP3 " + Environment.NewLine;
                    selectTxt += " ON  GSMSLP3.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                    selectTxt += " AND GSMSLP3.GOODSMAKERCDRF=GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
                    if (newGoodsPrint)
                    {
                        selectTxt += " AND GSMSLP3.CHGDESTGOODSNORF=GSMSLP.GOODSNORF" + Environment.NewLine;
                    }
                    else
                    {
                        selectTxt += " AND GSMSLP3.CHGSRCGOODSNORF=GSMSLP.GOODSNORF" + Environment.NewLine;
                    }
                    SqlParameter paraNEnterpriseCode = sqlCommand.Parameters.Add("@GNOCGEENTERPRISECODERF", SqlDbType.NChar);
                    paraNEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

                    SqlParameter paraNSalesDateSt = sqlCommand.Parameters.Add("@GNOCGEADDUPYEARMONTHST", SqlDbType.Int);
                    paraNSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AnnualAddUpYearMonthSt);

                    SqlParameter paraNSalesDateEd = sqlCommand.Parameters.Add("@GNOCGEADDUPYEARMONTHED", SqlDbType.Int);
                    paraNSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AnnualAddUpYaerMonthEd);                  
                }
                // --- ADD END 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX--------------------------------<<<<<
            }
            #endregion  //[JOIN]

            #region [WHERE��]
            selectTxt += " WHERE" + Environment.NewLine;
            selectTxt += " GSMSLP.ENTERPRISECODERF=@GSMSLPENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@GSMSLPENTERPRISECODE", SqlDbType.NChar);
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
                selectTxt += " AND GSMSLP." + sFstNm + "TOTALSALESCOUNT>=@TOTALSALESCOUNTST" + Environment.NewLine;
                SqlParameter paraPrintRangeSt = sqlCommand.Parameters.Add("@TOTALSALESCOUNTST", SqlDbType.Int);
                paraPrintRangeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintRangeSt);
            }
            if (CndtnWork.PrintRangeEd != 999999999)
            {
                selectTxt += " AND GSMSLP." + sFstNm + "TOTALSALESCOUNT<=@TOTALSALESCOUNTED" + Environment.NewLine;
                SqlParameter paraPrintRangeEd = sqlCommand.Parameters.Add("@TOTALSALESCOUNTED", SqlDbType.Int);
                paraPrintRangeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintRangeEd);
            }
            #endregion  //[WHERE��]

            #endregion  //[Select���쐬]

            return selectTxt;
        }
        #endregion  //[���i�ʗp Select����������]

        #region [���i�ʔ��㌎���W�v�f�[�^�p SubQuery��������]
        /// <summary>
        /// ���i�ʔ��㌎���W�v�f�[�^�p SubQuery��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <param name="sTblNm">�e�[�u������</param>
        /// <param name="iRsltTtlDivCd">�݌Ɏ�񂹋敪</param>
        /// <param name="oldGoodsPrint">�����i�\���敪</param>
        /// <param name="newGoodsPrint">�V���i�\���敪</param>
        /// <returns>���i�ʔ��㌎���W�v�f�[�^�pSELECT��</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʔ��㌎���W�v�f�[�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.02</br>
        /// <br>Update Note: 2014/12/16 �� ��</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           : �����Y�ƗlSeiken�i�ԕύX</br>
        /// <br>Update Note: 2015/05/08 zhujc</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           : �O���[�o���ϐ��폜</br>
        /// </remarks>
        //private string MakeSubQueryString(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork, string sTblNm, int iRsltTtlDivCd)// DEL 2015/05/08 zhujc �O���[�o���ϐ��폜 
        private string MakeSubQueryString(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork, string sTblNm, int iRsltTtlDivCd, bool oldGoodsPrint, bool newGoodsPrint)// ADD 2015/05/08 zhujc �O���[�o���ϐ��폜
        {
            string retstring = "";

            #region [���i�ʔ��㌎���W�v�f�[�^���oQuery]
            retstring += " SELECT" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += IFBy(bAddUpSecCode,
                         "  ," + sTblNm + ".ADDUPSECCODERF" + Environment.NewLine);
            retstring += IFBy(bGoodsMakerCd,
                         "  ," + sTblNm + ".GOODSMAKERCDRF" + Environment.NewLine);
            retstring += IFBy(bBLGoodsCode,
                         "  ," + sTblNm + ".BLGOODSCODERF" + Environment.NewLine);
            // 2010/01/13 Add >>>
            if (sTblNm == "GSMSLPPSUB")
            {
                retstring += IFBy(bBLGroupCode,
                             "  ,(CASE WHEN " + sTblNm + ".BLGROUPCODERF IS NULL THEN 0 ELSE " + sTblNm + ".BLGROUPCODERF END) AS BLGROUPCODERF" + Environment.NewLine);
                retstring += IFBy(bGoodsMGroup,
                             "  ,(CASE WHEN " + sTblNm + ".GOODSMGROUPRF IS NULL THEN 0 ELSE " + sTblNm + ".GOODSMGROUPRF END) AS GOODSMGROUPRF" + Environment.NewLine);
                retstring += IFBy(bGoodsLGroup,
                             "  ,(CASE WHEN " + sTblNm + ".GOODSLGROUPRF IS NULL THEN 0 ELSE " + sTblNm + ".GOODSLGROUPRF END) AS GOODSLGROUPRF" + Environment.NewLine);
            }
            else
            {
            // 2010/01/13 Add <<<
                retstring += IFBy(bBLGroupCode,
                             "  ," + sTblNm + ".BLGROUPCODERF" + Environment.NewLine);
                retstring += IFBy(bGoodsMGroup,
                             "  ," + sTblNm + ".GOODSMGROUPRF" + Environment.NewLine);
                retstring += IFBy(bGoodsLGroup,
                             "  ," + sTblNm + ".GOODSLGROUPRF" + Environment.NewLine);
            }   // 2010/01/13 Add
            retstring += IFBy(bGoodsNo,
                         "  ," + sTblNm + ".GOODSNORF" + Environment.NewLine);
            //����
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTRF)" + Environment.NewLine;
            retstring += "    AS MONTHTOTALSALESCOUNT" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEYRF)" + Environment.NewLine;
            retstring += "    AS MONTHSALESMONEY" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESRETGOODSPRICERF)" + Environment.NewLine;
            retstring += "    AS MONTHSALESRETGOODSPRICE" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_DISCOUNTPRICERF)" + Environment.NewLine;
            retstring += "    AS MONTHDISCOUNTPRICE" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_GROSSPROFITRF)" + Environment.NewLine;
            retstring += "    AS MONTHGROSSPROFIT" + Environment.NewLine;
            //����
            retstring += "  ,SUM(" + sTblNm + ".A_TOTALSALESCOUNTRF)" + Environment.NewLine;
            retstring += "    AS ANNUALTOTALSALESCOUNT" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".A_SALESMONEYRF)" + Environment.NewLine;
            retstring += "    AS ANNUALSALESMONEY" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".A_SALESRETGOODSPRICERF)" + Environment.NewLine;
            retstring += "    AS ANNUALSALESRETGOODSPRICE" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".A_DISCOUNTPRICERF)" + Environment.NewLine;
            retstring += "    AS ANNUALDISCOUNTPRICE" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".A_GROSSPROFITRF)" + Environment.NewLine;
            retstring += "    AS ANNUALGROSSPROFIT" + Environment.NewLine;

            retstring += " FROM" + Environment.NewLine;
            retstring += " (" + Environment.NewLine;

            #region [���i�ʔ��㌎���W�v�f�[�^+BL���i�R�[�h�}�X�^+BL�O���[�v�}�X�^���o]

            #region [���������o]
            retstring += "   SELECT" + Environment.NewLine;
            retstring += "     " + sTblNm + "A.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.ADDUPSECCODERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.ADDUPYEARMONTHRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.GOODSMAKERCDRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.BLGOODSCODERF" + Environment.NewLine;
            //retstring += "    ," + sTblNm + "A.GOODSNORF" + Environment.NewLine; // DEL 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX
            // --- ADD START 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX-------------------------------->>>>>
            if (oldGoodsPrint)
            {
                retstring += "    ,(CASE WHEN GOODSNOCON.CHGSRCGOODSNORF IS NULL THEN " + sTblNm + "A.GOODSNORF" + Environment.NewLine;
                retstring += "      ELSE  GOODSNOCON.CHGSRCGOODSNORF END) AS GOODSNORF" + Environment.NewLine;
            }
            else if (newGoodsPrint)
            {
                retstring += "    ,(CASE WHEN GOODSNOCON.CHGDESTGOODSNORF IS NULL THEN " + sTblNm + "A.GOODSNORF" + Environment.NewLine;
                retstring += "           ELSE GOODSNOCON.CHGDESTGOODSNORF END) AS GOODSNORF" + Environment.NewLine;
            }
            else
            {
                retstring += "    ," + sTblNm + "A.GOODSNORF" + Environment.NewLine;
            }
            // --- ADD END 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX--------------------------------<<<<<
            retstring += "    ,(CASE WHEN " + sTblNm + "A.TOTALSALESCOUNTRF IS NULL THEN 0 ELSE" + Environment.NewLine;
            retstring += "     " + sTblNm + "A.TOTALSALESCOUNTRF END) AS A_TOTALSALESCOUNTRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.SALESMONEYRF" + Environment.NewLine;
            retstring += "     AS A_SALESMONEYRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.SALESRETGOODSPRICERF" + Environment.NewLine;
            retstring += "     AS A_SALESRETGOODSPRICERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.DISCOUNTPRICERF" + Environment.NewLine;
            retstring += "     AS A_DISCOUNTPRICERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "A.GROSSPROFITRF" + Environment.NewLine;
            retstring += "     AS A_GROSSPROFITRF" + Environment.NewLine;
            retstring += "    ,(CASE WHEN " + sTblNm + "M.TOTALSALESCOUNTRF IS NULL THEN 0 ELSE" + Environment.NewLine;
            retstring += "     " + sTblNm + "M.TOTALSALESCOUNTRF END) AS M_TOTALSALESCOUNTRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "M.SALESMONEYRF" + Environment.NewLine;
            retstring += "     AS M_SALESMONEYRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "M.SALESRETGOODSPRICERF" + Environment.NewLine;
            retstring += "     AS M_SALESRETGOODSPRICERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "M.DISCOUNTPRICERF" + Environment.NewLine;
            retstring += "     AS M_DISCOUNTPRICERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "M.GROSSPROFITRF" + Environment.NewLine;
            retstring += "     AS M_GROSSPROFITRF" + Environment.NewLine;
            retstring += "    ,BLGCDUA" + sTblNm + ".BLGROUPCODERF" + Environment.NewLine;
            retstring += "    ,BLGRPUA" + sTblNm + ".GOODSMGROUPRF" + Environment.NewLine;
            retstring += "    ,BLGRPUA" + sTblNm + ".GOODSLGROUPRF" + Environment.NewLine;
            // 2011/07/29 >>>
            //retstring += "   FROM GOODSMTTLSASLIPRF AS " + sTblNm + "A" + Environment.NewLine;
            retstring += "   FROM GOODSMTTLSASLIPRF AS " + sTblNm + "A WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            //BL���i�R�[�h�}�X�^(���[�U�[)
            // 2011/07/29 >>>
            //retstring += "   LEFT JOIN BLGOODSCDURF BLGCDUA" + sTblNm + Environment.NewLine;
            retstring += "   LEFT JOIN BLGOODSCDURF BLGCDUA" + sTblNm + " WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            retstring += "   ON  BLGCDUA" + sTblNm + ".ENTERPRISECODERF=" + sTblNm + "A.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "   AND BLGCDUA" + sTblNm + ".BLGOODSCODERF=" + sTblNm + "A.BLGOODSCODERF" + Environment.NewLine;
            //BL�O���[�v�}�X�^(���[�U�[)
            // 2011/07/29 >>>
            //retstring += "   LEFT JOIN BLGROUPURF BLGRPUA" + sTblNm + Environment.NewLine;
            retstring += "   LEFT JOIN BLGROUPURF BLGRPUA" + sTblNm + " WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            retstring += "   ON  BLGRPUA" + sTblNm + ".ENTERPRISECODERF=BLGCDUA" + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "   AND BLGRPUA" + sTblNm + ".BLGROUPCODERF=BLGCDUA" + sTblNm + ".BLGROUPCODERF" + Environment.NewLine;
            #endregion  //[���������o]

            #region [���������o]
            retstring += "   LEFT JOIN" + Environment.NewLine;
            retstring += "   (" + Environment.NewLine;
            retstring += "    SELECT" + Environment.NewLine;
            retstring += "      " + sTblNm + "M2.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.ADDUPSECCODERF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.ADDUPYEARMONTHRF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.GOODSMAKERCDRF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.BLGOODSCODERF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.GOODSNORF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.TOTALSALESCOUNTRF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.SALESMONEYRF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.SALESRETGOODSPRICERF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.DISCOUNTPRICERF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.GROSSPROFITRF" + Environment.NewLine;
            retstring += "     ,BLGCDUM" + sTblNm + ".BLGROUPCODERF" + Environment.NewLine;
            retstring += "     ,BLGRPUM" + sTblNm + ".GOODSMGROUPRF" + Environment.NewLine;
            retstring += "     ,BLGRPUM" + sTblNm + ".GOODSLGROUPRF" + Environment.NewLine;
            // ADD sakurai 2009/02/11 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            retstring += "     ," + sTblNm + "M2.CUSTOMERCODERF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.SUPPLIERCDRF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.RSLTTTLDIVCDRF" + Environment.NewLine;
            retstring += "     ," + sTblNm + "M2.EMPLOYEECODERF" + Environment.NewLine;
            // ADD sakurai 2009/2/11 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2011/07/29 >>>
            //retstring += "    FROM GOODSMTTLSASLIPRF AS " + sTblNm + "M2" + Environment.NewLine;
            retstring += "    FROM GOODSMTTLSASLIPRF AS " + sTblNm + "M2 WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            //BL���i�R�[�h�}�X�^(���[�U�[)
            // 2011/07/29 >>>
            //retstring += "    LEFT JOIN BLGOODSCDURF BLGCDUM" + sTblNm + Environment.NewLine;
            retstring += "    LEFT JOIN BLGOODSCDURF BLGCDUM" + sTblNm + " WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            retstring += "    ON  BLGCDUM" + sTblNm + ".ENTERPRISECODERF=" + sTblNm + "M2.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "    AND BLGCDUM" + sTblNm + ".BLGOODSCODERF=" + sTblNm + "M2.BLGOODSCODERF" + Environment.NewLine;
            //BL�O���[�v�}�X�^(���[�U�[)
            // 2011/07/29 >>>
            //retstring += "    LEFT JOIN BLGROUPURF BLGRPUM" + sTblNm + Environment.NewLine;
            retstring += "    LEFT JOIN BLGROUPURF BLGRPUM" + sTblNm + " WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/07/29 <<<
            retstring += "    ON  BLGRPUM" + sTblNm + ".ENTERPRISECODERF=BLGCDUM" + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "    AND BLGRPUM" + sTblNm + ".BLGROUPCODERF=BLGCDUM" + sTblNm + ".BLGROUPCODERF" + Environment.NewLine;
            retstring += MakeWhereString(ref sqlCommand, CndtnWork, sTblNm + "M2", "BLGCDUM" + sTblNm, "BLGRPUM" + sTblNm, iRsltTtlDivCd, 0);
            retstring += "   ) AS " + sTblNm + "M" + Environment.NewLine;
            retstring += "   ON  " + sTblNm + "M.ENTERPRISECODERF=" + sTblNm + "A.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.ADDUPSECCODERF=" + sTblNm + "A.ADDUPSECCODERF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.ADDUPYEARMONTHRF=" + sTblNm + "A.ADDUPYEARMONTHRF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.GOODSMAKERCDRF=" + sTblNm + "A.GOODSMAKERCDRF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.BLGOODSCODERF=" + sTblNm + "A.BLGOODSCODERF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.GOODSNORF=" + sTblNm + "A.GOODSNORF" + Environment.NewLine;
            // ADD sakurai 2009/02/11 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            retstring += "   AND " + sTblNm + "M.RSLTTTLDIVCDRF=" + sTblNm + "A.RSLTTTLDIVCDRF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.EMPLOYEECODERF=" + sTblNm + "A.EMPLOYEECODERF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.CUSTOMERCODERF=" + sTblNm + "A.CUSTOMERCODERF" + Environment.NewLine;
            retstring += "   AND " + sTblNm + "M.SUPPLIERCDRF=" + sTblNm + "A.SUPPLIERCDRF" + Environment.NewLine;
            // ADD sakurai 2009/2/11 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // --- ADD START 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX-------------------------------->>>>>
            if (oldGoodsPrint)
            {
                retstring += "    LEFT JOIN GOODSNOCHANGERF GOODSNOCON WITH (READUNCOMMITTED) " + Environment.NewLine;
                retstring += "    ON  GOODSNOCON.ENTERPRISECODERF=" + sTblNm + "A.ENTERPRISECODERF" + Environment.NewLine;
                retstring += "    AND GOODSNOCON.GOODSMAKERCDRF=" + sTblNm + "A.GOODSMAKERCDRF" + Environment.NewLine;
                retstring += "    AND GOODSNOCON.CHGDESTGOODSNORF=" + sTblNm + "A.GOODSNORF" + Environment.NewLine;
                retstring += "    AND GOODSNOCON.LOGICALDELETECODERF=0" + Environment.NewLine;
            }
            else if (newGoodsPrint)
            {
                retstring += "    LEFT JOIN GOODSNOCHANGERF GOODSNOCON WITH (READUNCOMMITTED) " + Environment.NewLine;
                retstring += "    ON  GOODSNOCON.ENTERPRISECODERF=" + sTblNm + "A.ENTERPRISECODERF" + Environment.NewLine;
                retstring += "    AND GOODSNOCON.GOODSMAKERCDRF=" + sTblNm + "A.GOODSMAKERCDRF" + Environment.NewLine;
                retstring += "    AND GOODSNOCON.CHGSRCGOODSNORF=" + sTblNm + "A.GOODSNORF" + Environment.NewLine;
                retstring += "    AND GOODSNOCON.LOGICALDELETECODERF=0" + Environment.NewLine;
            }
            // --- ADD END 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX--------------------------------<<<<<
            #endregion  //[���������o]

            //��������WHERE��
            retstring += MakeWhereString(ref sqlCommand, CndtnWork, sTblNm + "A", "BLGCDUA" + sTblNm, "BLGRPUA" + sTblNm, iRsltTtlDivCd, 1);

            #endregion  //[���i�ʔ��㌎���W�v�f�[�^+BL���i�R�[�h�}�X�^+BL�O���[�v�}�X�^���o]

            retstring += " ) AS " + sTblNm + Environment.NewLine;

            // ADD ST By zhangll 2015/04/01 Redmine#44209��#434 �i�ԏ������w�肵���ꍇ�APM7�����Q�̑Ή� ---------->>>>>
            if ((CndtnWork.GoodsNoSumDiv == 1) && (CndtnWork.GoodsNoSt != "" || CndtnWork.GoodsNoEd != ""))
            {
                retstring += GoodsNoMakeWhereString(ref sqlCommand, CndtnWork, sTblNm);
            }
            // ADD ED By zhangll 2015/04/01 Redmine#44209��#434 �i�ԏ������w�肵���ꍇ�APM7�����Q�̑Ή� ----------<<<<<

            #region [GROUP BY]
            retstring += " GROUP BY" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += IFBy(bAddUpSecCode,
                         "  ," + sTblNm + ".ADDUPSECCODERF" + Environment.NewLine);
            retstring += IFBy(bGoodsMakerCd,
                         "  ," + sTblNm + ".GOODSMAKERCDRF" + Environment.NewLine);
            retstring += IFBy(bBLGoodsCode,
                         "  ," + sTblNm + ".BLGOODSCODERF" + Environment.NewLine);
            retstring += IFBy(bBLGroupCode,
                         "  ," + sTblNm + ".BLGROUPCODERF" + Environment.NewLine);
            retstring += IFBy(bGoodsMGroup,
                         "  ," + sTblNm + ".GOODSMGROUPRF" + Environment.NewLine);
            retstring += IFBy(bGoodsLGroup,
                         "  ," + sTblNm + ".GOODSLGROUPRF" + Environment.NewLine);
            retstring += IFBy(bGoodsNo,
                         "  ," + sTblNm + ".GOODSNORF" + Environment.NewLine);
            #endregion  //[GROUP BY]

            #endregion  //[���i�ʔ��㌎���W�v�f�[�^���oQuery]

            return retstring;
        }
        #endregion //���i�ʔ��㌎���W�v�f�[�^�p SubQuery��������

        #region [���i�ʔ��㌎���W�v�f�[�^�p Where�� ��������]
        /// <summary>
        /// ���i�ʔ��㌎���W�v�f�[�^�pWHERE�� �������� (���v�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <param name="sGSMSLP">�e�[�u�������́F���i�ʔ��㌎���W�v�f�[�^</param>
        /// <param name="sBLGCDU">�e�[�u�������́FBL���i�R�[�h�}�X�^</param>
        /// <param name="sBLGRPU">�e�[�u�������́FBL�O���[�v�}�X�^</param>
        /// <param name="iRsltTtlDivCd">�݌Ɏ�񂹋敪</param>
        /// <param name="iType">�Ώ۔N�� 0:���� 1:����</param>
        /// <returns>���i�ʔ��㌎���W�v�f�[�^�pWHERE��</returns>
        /// <br>Note       : ���i�ʔ��㌎���W�v�f�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.02</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork, string sGSMSLP, string sBLGCDU, string sBLGRPU, int iRsltTtlDivCd, int iType)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            #region [���i�ʔ��㌎���W�v�f�[�^]
            //��ƃR�[�h
            retstring += " " + sGSMSLP + ".ENTERPRISECODERF=@" + sGSMSLP + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sGSMSLP + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //�_���폜�敪
            retstring += " AND " + sGSMSLP + ".LOGICALDELETECODERF=0 " + Environment.NewLine;

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
                    retstring += " AND " + sGSMSLP + ".ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //���яW�v�敪
            retstring += " AND " + sGSMSLP + ".RSLTTTLDIVCDRF=@" + sGSMSLP + "RSLTTTLDIVCD" + Environment.NewLine;
            SqlParameter paraRsltTtlDivCd = sqlCommand.Parameters.Add("@" + sGSMSLP + "RSLTTTLDIVCD", SqlDbType.Int);
            paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(iRsltTtlDivCd);

            //�Ώ۔N��
            if (iType == 0)
            {
                //����
                retstring += " AND " + sGSMSLP + ".ADDUPYEARMONTHRF>=@" + sGSMSLP + "ADDUPYEARMONTHST" + Environment.NewLine;
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "ADDUPYEARMONTHST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AddUpYearMonthSt);

                retstring += " AND " + sGSMSLP + ".ADDUPYEARMONTHRF<=@" + sGSMSLP + "ADDUPYEARMONTHED" + Environment.NewLine;
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "ADDUPYEARMONTHED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AddUpYearMonthEd);
            }
            else
            {
                //����
                retstring += " AND " + sGSMSLP + ".ADDUPYEARMONTHRF>=@" + sGSMSLP + "ADDUPYEARMONTHST" + Environment.NewLine;
                SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "ADDUPYEARMONTHST", SqlDbType.Int);
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AnnualAddUpYearMonthSt);

                retstring += " AND " + sGSMSLP + ".ADDUPYEARMONTHRF<=@" + sGSMSLP + "ADDUPYEARMONTHED" + Environment.NewLine;
                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "ADDUPYEARMONTHED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AnnualAddUpYaerMonthEd);
            }

            //���i���[�J�[�R�[�h
            if (CndtnWork.GoodsMakerCdSt != 0)
            {
                retstring += " AND " + sGSMSLP + ".GOODSMAKERCDRF>=@" + sGSMSLP + "GOODSMAKERCDST" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "GOODSMAKERCDST", SqlDbType.Int);
                paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMakerCdSt);
            }
            if (CndtnWork.GoodsMakerCdEd != 999999)
            {
                retstring += " AND " + sGSMSLP + ".GOODSMAKERCDRF<=@" + sGSMSLP + "GOODSMAKERCDED" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "GOODSMAKERCDED", SqlDbType.Int);
                paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMakerCdEd);
            }

            //BL���i�R�[�h
            if (CndtnWork.BLGoodsCodeSt != 0)
            {
                retstring += " AND " + sGSMSLP + ".BLGOODSCODERF>=@" + sGSMSLP + "BLGOODSCODEST" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "BLGOODSCODEST", SqlDbType.Int);
                paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeSt);
            }
            if (CndtnWork.BLGoodsCodeEd != 99999999)
            {
                retstring += " AND " + sGSMSLP + ".BLGOODSCODERF<=@" + sGSMSLP + "BLGOODSCODEED" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "BLGOODSCODEED", SqlDbType.Int);
                paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeEd);
            }

            // �ʁX�̏ꍇ
            if (CndtnWork.GoodsNoSumDiv == 0) // ADD By zhangll 2015/04/01 Redmine#44209��#434 �i�ԏ������w�肵���ꍇ�APM7�����Q�̑Ή�
            {
                //���i�ԍ�
                if (CndtnWork.GoodsNoSt != "")
                {
                    retstring += " AND " + sGSMSLP + ".GOODSNORF>=@" + sGSMSLP + "GOODSNOST" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoSt);
                }
                if (CndtnWork.GoodsNoEd != "")
                {
                    retstring += " AND " + sGSMSLP + ".GOODSNORF<=@" + sGSMSLP + "GOODSNOED" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoEd);
                }
            }

            #endregion  //[���i�ʔ��㌎���W�v�f�[�^]

            #region [BL���i�R�[�h�}�X�^�EBL�O���[�v�}�X�^]
            //BL�O���[�v�R�[�h
            if (CndtnWork.BLGroupCodeSt != 0)
            {
                retstring += " AND " + sBLGCDU + ".BLGROUPCODERF>=@" + sBLGCDU + "BLGROUPCODEST" + Environment.NewLine;
                SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@" + sBLGCDU + "BLGROUPCODEST", SqlDbType.Int);
                paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeSt);
            }
            if (CndtnWork.BLGroupCodeEd != 99999)
            {
                retstring += " AND ( " + sBLGCDU + ".BLGROUPCODERF<=@" + sBLGCDU + "BLGROUPCODEED OR " + sBLGCDU + ".BLGROUPCODERF IS NULL )" + Environment.NewLine;
                SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@" + sBLGCDU + "BLGROUPCODEED", SqlDbType.Int);
                paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeEd);
            }

            //�J�n���i�啪�ރR�[�h
            if (CndtnWork.GoodsLGroupSt != 0)
            {
                retstring += " AND " + sBLGRPU + ".GOODSLGROUPRF>=@" + sBLGRPU + "GOODSLGROUPST" + Environment.NewLine;
                SqlParameter paraGoodsLGroupSt = sqlCommand.Parameters.Add("@" + sBLGRPU + "GOODSLGROUPST", SqlDbType.Int);
                paraGoodsLGroupSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsLGroupSt);
            }
            if (CndtnWork.GoodsLGroupEd != 9999)
            {
                retstring += " AND ( " + sBLGRPU + ".GOODSLGROUPRF<=@" + sBLGRPU + "GOODSLGROUPED OR " + sBLGRPU + ".GOODSLGROUPRF IS NULL )" + Environment.NewLine;
                SqlParameter paraGoodsLGroupEd = sqlCommand.Parameters.Add("@" + sBLGRPU + "GOODSLGROUPED", SqlDbType.Int);
                paraGoodsLGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsLGroupEd);
            }

            //�J�n���i�����ރR�[�h
            if (CndtnWork.GoodsMGroupSt != 0)
            {
                retstring += " AND " + sBLGRPU + ".GOODSMGROUPRF>=@" + sBLGRPU + "GOODSMGROUPST" + Environment.NewLine;
                SqlParameter paraGoodsMGroupSt = sqlCommand.Parameters.Add("@" + sBLGRPU + "GOODSMGROUPST", SqlDbType.Int);
                paraGoodsMGroupSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupSt);
            }
            if (CndtnWork.GoodsMGroupEd != 9999)
            {
                retstring += " AND ( " + sBLGRPU + ".GOODSMGROUPRF<=@" + sBLGRPU + "GOODSMGROUPED OR " + sBLGRPU + ".GOODSMGROUPRF IS NULL )" + Environment.NewLine;
                SqlParameter paraGoodsMGroupEd = sqlCommand.Parameters.Add("@" + sBLGRPU + "GOODSMGROUPED", SqlDbType.Int);
                paraGoodsMGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupEd);
            }
            #endregion  //[BL���i�R�[�h�}�X�^�EBL�O���[�v�}�X�^]

            #endregion  //WHERE���쐬

            return retstring;
        }
        #endregion  //[���i�ʔ��㌎���W�v�f�[�^�p Where�� ��������]

        // ADD ST By zhangll 2015/04/01 Redmine#44209��#434 �i�ԏ������w�肵���ꍇ�APM7�����Q�̑Ή� ---------->>>>>
        #region [�i�ԏ��� Where�� ��������]
        private string GoodsNoMakeWhereString(ref SqlCommand sqlCommand, SalesRsltListCndtnWork CndtnWork, string tableNm)
        {
            string retstring = " WHERE" + Environment.NewLine;

            //���i�ԍ�
            if (CndtnWork.GoodsNoSt != "")
            {
                retstring += tableNm + ".GOODSNORF>=@" + tableNm + "GOODSNOST" + Environment.NewLine;
                SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@" + tableNm + "GOODSNOST", SqlDbType.NVarChar);
                paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoSt);
            }

            if (CndtnWork.GoodsNoSt != "" && CndtnWork.GoodsNoEd != "")
            {
                retstring += " AND " + Environment.NewLine;
            }

            if (CndtnWork.GoodsNoEd != "")
            {
                retstring += tableNm + ".GOODSNORF<=@" + tableNm + "GOODSNOED" + Environment.NewLine;
                SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@" + tableNm + "GOODSNOED", SqlDbType.NVarChar);
                paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoEd);
            }

            return retstring;
        }
        #endregion
        // ADD ED By zhangll 2015/04/01 Redmine#44209��#434 �i�ԏ������w�肵���ꍇ�APM7�����Q�̑Ή� ----------<<<<<

        #region [CopyToSalesRsltListResultWorkFromReader���� �ďo]
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
        /// </remarks>
        private SalesRsltListResultWork CopyToSalesRsltListResultWorkFromReaderProc(ref SqlDataReader myReader, SalesRsltListCndtnWork CndtnWork)
        {
            #region [���ʗp�t���O]
            //�v�㋒�_�R�[�h
            if (CndtnWork.TtlType == 1)
            {
                bAddUpSecCode = true;
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
            #endregion  //[���ʗp�t���O]

            #region [���o����-�l�Z�b�g]
            SalesRsltListResultWork ResultWork = new SalesRsltListResultWork();

            if (bAddUpSecCode)
            {
                ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                ResultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            }
            if (bGoodsMakerCd)
            {
                ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF")); // Update 2009/04/28
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
            ResultWork.MonthSalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESRETGOODSPRICE"));
            ResultWork.MonthDiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHDISCOUNTPRICE"));
            ResultWork.MonthGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHGROSSPROFIT"));
            //����
            ResultWork.AnnualTotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANNUALTOTALSALESCOUNT"));
            ResultWork.AnnualSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALSALESMONEY"));
            ResultWork.AnnualSalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALSALESRETGOODSPRICE"));
            ResultWork.AnnualDiscountPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALDISCOUNTPRICE"));
            ResultWork.AnnualGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ANNUALGROSSPROFIT"));
            #endregion  //[���o����-�l�Z�b�g]

            return ResultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader����]
    }
}

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
        #region [���ʗp�t���O�錾]
        private bool bAddUpSecCode = false;  //�v�㋒�_�R�[�h
        private bool bEmployeeCode = false;  //�]�ƈ��R�[�h
        private bool bGoodsMakerCd = false;  //���i���[�J�[�R�[�h
        private bool bBLGoodsCode = false;   //BL���i�R�[�h
        private bool bGoodsNo = false;       //���i�ԍ�
        private bool bBLGroupCode = false;   //BL�O���[�v�R�[�h
        private bool bGoodsMGroup = false;   //���i�����ރR�[�h
        private bool bGoodsLGroup = false;   //���i�啪�ރR�[�h
        #endregion  //[���ʗp�t���O�錾]

        #region [�S���ҕʗp Select��]
        /// <summary>
        /// �S���ҕʗpSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>�S���ҕʗpSELECT��</returns>
        /// <br>Note       : �S���ҕʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.08</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, SalesTransListCndtnWork CndtnWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, CndtnWork);
        }
        #endregion  //[�S���ҕʗp Select��]

        #region [�S���ҕʗp Select����������]
        /// <summary>
        /// �S���ҕʗpSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>�S���ҕʗpSELECT��</returns>
        /// <br>Note       : �S���ҕʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.08</br>
        /// <br>Update Note: 2009.04.28 ����</br>
        /// <br>            �E���[�J�[����==>���[�J�[����
        /// <br>Update Note: 2010/05/13 �������n</br>
        /// <br>            �E�i���̎擾���@��ύX
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, SalesTransListCndtnWork CndtnWork)
        {
            #region [���ʗp�t���O]
            //�v�㋒�_�R�[�h
            if (CndtnWork.TtlType == 1)
            {
                bAddUpSecCode = true;
            }

            //�]�ƈ��R�[�h
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2) ||
                (CndtnWork.Detail == 3) ||
                (CndtnWork.Detail == 4) ||
                (CndtnWork.Detail == 5) ||
                (CndtnWork.Detail == 6))
            {
                bEmployeeCode = true;
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

            string selectTxt = "";

            // �Ώۃe�[�u��
            // GOODSMTTLSASLIPRF GSMSLP ���i�ʔ��㌎���W�v�f�[�^
            // GOODSURF          GOODSU ���i�}�X�^(���[�U�[)
            // BLGOODSCDURF      BLGCDU BL���i�R�[�h�}�X�^(���[�U�[)
            // BLGROUPURF        BLGRPU BL�O���[�v�}�X�^(���[�U�[)
            // MAKERURF          MAKERU ���[�J�[�}�X�^(���[�U�[�o�^��)
            // USERGDBDURF       USGDBU ���[�U�[�K�C�h�}�X�^(�{�f�B)(���[�U�ύX��)
            // SECINFOSETRF      SCINST ���_���ݒ�}�X�^
            // EMPLOYEERF        EMPLYE �]�ƈ��}�X�^
            // GOODSGROUPURF     GSGRPU ���i�����ރ}�X�^(���[�U�[�o�^��)

            #region [Select���쐬]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += IFBy(bEmployeeCode,
                         " ,GSMSLP.EMPLOYEECODERF" + Environment.NewLine);
            selectTxt += IFBy(bEmployeeCode,
                         " ,EMPLYE.NAMERF" + Environment.NewLine);
            selectTxt += IFBy(bAddUpSecCode,
                         " ,GSMSLP.ADDUPSECCODERF" + Environment.NewLine);
            selectTxt += IFBy(bAddUpSecCode,
                         " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMakerCd,
                         " ,GSMSLP.GOODSMAKERCDRF" + Environment.NewLine);
            selectTxt += IFBy(bGoodsMakerCd,
                         " ,MAKERU.MAKERNAMERF" + Environment.NewLine);   // Update 2009/04/28
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
            selectTxt += IFBy(bGoodsNo,
                         " ,(CASE WHEN GOODSU.GOODSNAMEKANARF IS NULL THEN GSMSLP2.GOODSNAMEKANARF ELSE GOODSU.GOODSNAMEKANARF END) AS GOODSNAMEKANARF" + Environment.NewLine);
            // -- UPD 2010/05/13 ------------------------------------------<<<
            //���v(����)
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT1" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT2" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT3" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT4" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT5" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT6" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT7" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT8" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT9" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT10" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT11" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT12" + Environment.NewLine;
            //���v(���z)
            selectTxt += " ,GSMSLP.SALESMONEY1" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY2" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY3" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY4" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY5" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY6" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY7" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY8" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY9" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY10" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY11" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SALESMONEY12" + Environment.NewLine;
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
                selectTxt += IFBy(bEmployeeCode,
                             "   ,GSMSLPP.EMPLOYEECODERF" + Environment.NewLine);
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
                //���v(����)
                selectTxt += "   ,(CASE WHEN GSMSLPP.TOTALSALESCOUNT1<>0.0 THEN (CASE WHEN GSMSLPS.TOTALSALESCOUNT1<>0.0 THEN (GSMSLPP.TOTALSALESCOUNT1-GSMSLPS.TOTALSALESCOUNT1) ELSE GSMSLPP.TOTALSALESCOUNT1 END) ELSE 0.0 END) AS TOTALSALESCOUNT1" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.TOTALSALESCOUNT2<>0.0 THEN (CASE WHEN GSMSLPS.TOTALSALESCOUNT2<>0.0 THEN (GSMSLPP.TOTALSALESCOUNT2-GSMSLPS.TOTALSALESCOUNT2) ELSE GSMSLPP.TOTALSALESCOUNT2 END) ELSE 0.0 END) AS TOTALSALESCOUNT2" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.TOTALSALESCOUNT3<>0.0 THEN (CASE WHEN GSMSLPS.TOTALSALESCOUNT3<>0.0 THEN (GSMSLPP.TOTALSALESCOUNT3-GSMSLPS.TOTALSALESCOUNT3) ELSE GSMSLPP.TOTALSALESCOUNT3 END) ELSE 0.0 END) AS TOTALSALESCOUNT3" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.TOTALSALESCOUNT4<>0.0 THEN (CASE WHEN GSMSLPS.TOTALSALESCOUNT4<>0.0 THEN (GSMSLPP.TOTALSALESCOUNT4-GSMSLPS.TOTALSALESCOUNT4) ELSE GSMSLPP.TOTALSALESCOUNT4 END) ELSE 0.0 END) AS TOTALSALESCOUNT4" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.TOTALSALESCOUNT5<>0.0 THEN (CASE WHEN GSMSLPS.TOTALSALESCOUNT5<>0.0 THEN (GSMSLPP.TOTALSALESCOUNT5-GSMSLPS.TOTALSALESCOUNT5) ELSE GSMSLPP.TOTALSALESCOUNT5 END) ELSE 0.0 END) AS TOTALSALESCOUNT5" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.TOTALSALESCOUNT6<>0.0 THEN (CASE WHEN GSMSLPS.TOTALSALESCOUNT6<>0.0 THEN (GSMSLPP.TOTALSALESCOUNT6-GSMSLPS.TOTALSALESCOUNT6) ELSE GSMSLPP.TOTALSALESCOUNT6 END) ELSE 0.0 END) AS TOTALSALESCOUNT6" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.TOTALSALESCOUNT7<>0.0 THEN (CASE WHEN GSMSLPS.TOTALSALESCOUNT7<>0.0 THEN (GSMSLPP.TOTALSALESCOUNT7-GSMSLPS.TOTALSALESCOUNT7) ELSE GSMSLPP.TOTALSALESCOUNT7 END) ELSE 0.0 END) AS TOTALSALESCOUNT7" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.TOTALSALESCOUNT8<>0.0 THEN (CASE WHEN GSMSLPS.TOTALSALESCOUNT8<>0.0 THEN (GSMSLPP.TOTALSALESCOUNT8-GSMSLPS.TOTALSALESCOUNT8) ELSE GSMSLPP.TOTALSALESCOUNT8 END) ELSE 0.0 END) AS TOTALSALESCOUNT8" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.TOTALSALESCOUNT9<>0.0 THEN (CASE WHEN GSMSLPS.TOTALSALESCOUNT9<>0.0 THEN (GSMSLPP.TOTALSALESCOUNT9-GSMSLPS.TOTALSALESCOUNT9) ELSE GSMSLPP.TOTALSALESCOUNT9 END) ELSE 0.0 END) AS TOTALSALESCOUNT9" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.TOTALSALESCOUNT10<>0.0 THEN (CASE WHEN GSMSLPS.TOTALSALESCOUNT10<>0.0 THEN (GSMSLPP.TOTALSALESCOUNT10-GSMSLPS.TOTALSALESCOUNT10) ELSE GSMSLPP.TOTALSALESCOUNT10 END) ELSE 0.0 END) AS TOTALSALESCOUNT10" + Environment.NewLine;
                // 2010/01/13 >>>
                //selectTxt += "   ,(CASE WHEN GSMSLPP.TOTALSALESCOUNT11<>0.0 THEN (CASE WHEN GSMSLPS.TOTALSALESCOUNT11<>0.0 THEN (GSMSLPP.TOTALSALESCOUNT11-GSMSLPS.TOTALSALESCOUNT10) ELSE GSMSLPP.TOTALSALESCOUNT11 END) ELSE 0.0 END) AS TOTALSALESCOUNT11" + Environment.NewLine;
                //selectTxt += "   ,(CASE WHEN GSMSLPP.TOTALSALESCOUNT12<>0.0 THEN (CASE WHEN GSMSLPS.TOTALSALESCOUNT12<>0.0 THEN (GSMSLPP.TOTALSALESCOUNT12-GSMSLPS.TOTALSALESCOUNT10) ELSE GSMSLPP.TOTALSALESCOUNT12 END) ELSE 0.0 END) AS TOTALSALESCOUNT12" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.TOTALSALESCOUNT11<>0.0 THEN (CASE WHEN GSMSLPS.TOTALSALESCOUNT11<>0.0 THEN (GSMSLPP.TOTALSALESCOUNT11-GSMSLPS.TOTALSALESCOUNT11) ELSE GSMSLPP.TOTALSALESCOUNT11 END) ELSE 0.0 END) AS TOTALSALESCOUNT11" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.TOTALSALESCOUNT12<>0.0 THEN (CASE WHEN GSMSLPS.TOTALSALESCOUNT12<>0.0 THEN (GSMSLPP.TOTALSALESCOUNT12-GSMSLPS.TOTALSALESCOUNT12) ELSE GSMSLPP.TOTALSALESCOUNT12 END) ELSE 0.0 END) AS TOTALSALESCOUNT12" + Environment.NewLine;
                // 2010/01/13 <<<
                //���v(���z)
                selectTxt += "   ,(CASE WHEN GSMSLPP.SALESMONEY1<>0 THEN (CASE WHEN GSMSLPS.SALESMONEY1<>0 THEN (GSMSLPP.SALESMONEY1-GSMSLPS.SALESMONEY1) ELSE GSMSLPP.SALESMONEY1 END) ELSE 0 END) AS SALESMONEY1" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.SALESMONEY2<>0 THEN (CASE WHEN GSMSLPS.SALESMONEY2<>0 THEN (GSMSLPP.SALESMONEY2-GSMSLPS.SALESMONEY2) ELSE GSMSLPP.SALESMONEY2 END) ELSE 0 END) AS SALESMONEY2" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.SALESMONEY3<>0 THEN (CASE WHEN GSMSLPS.SALESMONEY3<>0 THEN (GSMSLPP.SALESMONEY3-GSMSLPS.SALESMONEY3) ELSE GSMSLPP.SALESMONEY3 END) ELSE 0 END) AS SALESMONEY3" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.SALESMONEY4<>0 THEN (CASE WHEN GSMSLPS.SALESMONEY4<>0 THEN (GSMSLPP.SALESMONEY4-GSMSLPS.SALESMONEY4) ELSE GSMSLPP.SALESMONEY4 END) ELSE 0 END) AS SALESMONEY4" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.SALESMONEY5<>0 THEN (CASE WHEN GSMSLPS.SALESMONEY5<>0 THEN (GSMSLPP.SALESMONEY5-GSMSLPS.SALESMONEY5) ELSE GSMSLPP.SALESMONEY5 END) ELSE 0 END) AS SALESMONEY5" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.SALESMONEY6<>0 THEN (CASE WHEN GSMSLPS.SALESMONEY6<>0 THEN (GSMSLPP.SALESMONEY6-GSMSLPS.SALESMONEY6) ELSE GSMSLPP.SALESMONEY6 END) ELSE 0 END) AS SALESMONEY6" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.SALESMONEY7<>0 THEN (CASE WHEN GSMSLPS.SALESMONEY7<>0 THEN (GSMSLPP.SALESMONEY7-GSMSLPS.SALESMONEY7) ELSE GSMSLPP.SALESMONEY7 END) ELSE 0 END) AS SALESMONEY7" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.SALESMONEY8<>0 THEN (CASE WHEN GSMSLPS.SALESMONEY8<>0 THEN (GSMSLPP.SALESMONEY8-GSMSLPS.SALESMONEY8) ELSE GSMSLPP.SALESMONEY8 END) ELSE 0 END) AS SALESMONEY8" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.SALESMONEY9<>0 THEN (CASE WHEN GSMSLPS.SALESMONEY9<>0 THEN (GSMSLPP.SALESMONEY9-GSMSLPS.SALESMONEY9) ELSE GSMSLPP.SALESMONEY9 END) ELSE 0 END) AS SALESMONEY9" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.SALESMONEY10<>0 THEN (CASE WHEN GSMSLPS.SALESMONEY10<>0 THEN (GSMSLPP.SALESMONEY10-GSMSLPS.SALESMONEY10) ELSE GSMSLPP.SALESMONEY10 END) ELSE 0 END) AS SALESMONEY10" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.SALESMONEY11<>0 THEN (CASE WHEN GSMSLPS.SALESMONEY11<>0 THEN (GSMSLPP.SALESMONEY11-GSMSLPS.SALESMONEY11) ELSE GSMSLPP.SALESMONEY11 END) ELSE 0 END) AS SALESMONEY11" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPP.SALESMONEY12<>0 THEN (CASE WHEN GSMSLPS.SALESMONEY12<>0 THEN (GSMSLPP.SALESMONEY12-GSMSLPS.SALESMONEY12) ELSE GSMSLPP.SALESMONEY12 END) ELSE 0 END) AS SALESMONEY12" + Environment.NewLine;

                selectTxt += "  FROM" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                //���v�����o�T�uQuery
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPPSUB", (int)RsltTtlDivCd.PrtTtl);
                selectTxt += "  ) AS GSMSLPP" + Environment.NewLine;
                #endregion  //[���v�����o]

                #region [�݌ɕ����o]
                selectTxt += "  LEFT JOIN" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     GSMSLPSSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bEmployeeCode,
                             "    ,GSMSLPSSUB.EMPLOYEECODERF" + Environment.NewLine);
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,GSMSLPSSUB.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMakerCd,
                             "    ,GSMSLPSSUB.GOODSMAKERCDRF" + Environment.NewLine);
                selectTxt += IFBy(bBLGoodsCode,
                             "    ,GSMSLPSSUB.BLGOODSCODERF" + Environment.NewLine);
                selectTxt += IFBy(bBLGroupCode,
                             "    ,GSMSLPSSUB.BLGROUPCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMGroup,
                             "    ,GSMSLPSSUB.GOODSMGROUPRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsLGroup,
                             "    ,GSMSLPSSUB.GOODSLGROUPRF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsNo,
                             "    ,GSMSLPSSUB.GOODSNORF" + Environment.NewLine);
                //���v(����)
                selectTxt += "    ,GSMSLPSSUB.TOTALSALESCOUNT1" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.TOTALSALESCOUNT2" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.TOTALSALESCOUNT3" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.TOTALSALESCOUNT4" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.TOTALSALESCOUNT5" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.TOTALSALESCOUNT6" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.TOTALSALESCOUNT7" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.TOTALSALESCOUNT8" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.TOTALSALESCOUNT9" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.TOTALSALESCOUNT10" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.TOTALSALESCOUNT11" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.TOTALSALESCOUNT12" + Environment.NewLine;
                //���v(���z)
                selectTxt += "    ,GSMSLPSSUB.SALESMONEY1" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.SALESMONEY2" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.SALESMONEY3" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.SALESMONEY4" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.SALESMONEY5" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.SALESMONEY6" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.SALESMONEY7" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.SALESMONEY8" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.SALESMONEY9" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.SALESMONEY10" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.SALESMONEY11" + Environment.NewLine;
                selectTxt += "    ,GSMSLPSSUB.SALESMONEY12" + Environment.NewLine;
                selectTxt += "   FROM" + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                //�݌ɕ����o�T�uQuery
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPSSUB2", (int)RsltTtlDivCd.Stock);
                selectTxt += "   ) AS GSMSLPSSUB" + Environment.NewLine;
                selectTxt += "  ) AS GSMSLPS" + Environment.NewLine;
                selectTxt += "  ON  GSMSLPS.ENTERPRISECODERF=GSMSLPP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(bEmployeeCode,
                             "  AND GSMSLPS.EMPLOYEECODERF=GSMSLPP.EMPLOYEECODERF" + Environment.NewLine);
                selectTxt += IFBy(bAddUpSecCode,
                             "  AND GSMSLPS.ADDUPSECCODERF=GSMSLPP.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += IFBy(bGoodsMakerCd,
                             "  AND GSMSLPS.GOODSMAKERCDRF=GSMSLPP.GOODSMAKERCDRF" + Environment.NewLine);
                selectTxt += IFBy(bBLGoodsCode,
                             "  AND GSMSLPS.BLGOODSCODERF=GSMSLPP.BLGOODSCODERF" + Environment.NewLine);
                selectTxt += IFBy(bBLGroupCode,
                             "  AND GSMSLPS.BLGROUPCODERF=GSMSLPP.BLGROUPCODERF" + Environment.NewLine);
                // DEL 2008.11.05  ��ٰ�ߺ���(BLGROUPCODERF)�̈�v�ŏ\���Ȃ̂ō폜>>>                 
                //selectTxt += IFBy(bGoodsMGroup,
                //             "  AND GSMSLPS.GOODSMGROUPRF=GSMSLPP.GOODSMGROUPRF" + Environment.NewLine);
                //selectTxt += IFBy(bGoodsLGroup,
                //             "  AND GSMSLPS.GOODSLGROUPRF=GSMSLPP.GOODSLGROUPRF" + Environment.NewLine);
                // DEL 2008.11.05 <<<
                selectTxt += IFBy(bGoodsNo,
                             "  AND GSMSLPS.GOODSNORF=GSMSLPP.GOODSNORF" + Environment.NewLine);
                #endregion  //[�݌ɕ����o]

                #endregion  //[��񂹂̏ꍇ]
            }
            else
            {
                //���vor�݌ɂ̏ꍇ
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPSUB", CndtnWork.RsltTtlDivCd);
            }
            #endregion  //[�f�[�^���o���C��Query]

            selectTxt += " ) AS GSMSLP" + Environment.NewLine;

            #region [JOIN]
            if (bEmployeeCode)
            {
                //�]�ƈ��}�X�^
                // 2011/08/01 >>>
                //selectTxt += " LEFT JOIN EMPLOYEERF EMPLYE" + Environment.NewLine;
                selectTxt += " LEFT JOIN EMPLOYEERF EMPLYE WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += " ON  EMPLYE.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND EMPLYE.EMPLOYEECODERF=GSMSLP.EMPLOYEECODERF" + Environment.NewLine;
            }
            if (bAddUpSecCode)
            {
                //���_���ݒ�}�X�^
                // 2011/08/01 >>>
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += " ON  SCINST.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=GSMSLP.ADDUPSECCODERF" + Environment.NewLine;
            }
            if (bGoodsMakerCd)
            {
                //���[�J�[�}�X�^(���[�U�[�o�^��)
                // 2011/08/01 >>>
                //selectTxt += " LEFT JOIN MAKERURF MAKERU" + Environment.NewLine;
                selectTxt += " LEFT JOIN MAKERURF MAKERU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += " ON  MAKERU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MAKERU.GOODSMAKERCDRF=GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
            }
            if (bGoodsMGroup)
            {
                //���i�����ރ}�X�^(���[�U�[�o�^��)
                // 2011/08/01 >>>
                //selectTxt += " LEFT JOIN GOODSGROUPURF GSGRPU" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSGROUPURF GSGRPU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += " ON  GSGRPU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GSGRPU.GOODSMGROUPRF=GSMSLP.GOODSMGROUPRF" + Environment.NewLine;
            }
            if (bGoodsLGroup)
            {
                //���[�U�[�K�C�h�}�X�^ �����i�啪�ރK�C�h���̎擾�p
                // 2011/08/01 >>>
                //selectTxt += " LEFT JOIN USERGDBDURF USGDBUL" + Environment.NewLine;
                selectTxt += " LEFT JOIN USERGDBDURF USGDBUL WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += " ON  USGDBUL.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND USGDBUL.GUIDECODERF=GSMSLP.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += " AND USGDBUL.USERGUIDEDIVCDRF=70" + Environment.NewLine;
            }
            if (bBLGroupCode)
            {
                //BL�O���[�v�}�X�^(���[�U�[)
                // 2011/08/01 >>>
                //selectTxt += " LEFT JOIN BLGROUPURF BLGRPU" + Environment.NewLine;
                selectTxt += " LEFT JOIN BLGROUPURF BLGRPU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += " ON  BLGRPU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGRPU.BLGROUPCODERF=GSMSLP.BLGROUPCODERF" + Environment.NewLine;
            }
            if (bBLGoodsCode)
            {
                //BL���i�R�[�h�}�X�^(���[�U�[)
                // 2011/08/01 >>>
                //selectTxt += " LEFT JOIN BLGOODSCDURF BLGCDU" + Environment.NewLine;
                selectTxt += " LEFT JOIN BLGOODSCDURF BLGCDU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
                selectTxt += " ON  BLGCDU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGCDU.BLGOODSCODERF=GSMSLP.BLGOODSCODERF" + Environment.NewLine;
            }
            if ((bGoodsNo))
            {
                //���i�}�X�^(���[�U�[)
                // 2011/08/01 >>>
                //selectTxt += " LEFT JOIN GOODSURF GOODSU" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSURF GOODSU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
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
                // 2011/08/01 >>>
                //selectTxt += "     GOODSMTTLSASLIPRF" + Environment.NewLine;
                selectTxt += "     GOODSMTTLSASLIPRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                // 2011/08/01 <<<
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
                paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AddUpYearMonthSt);

                SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@GSMSLP2ADDUPYEARMONTHED", SqlDbType.Int);
                paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AddUpYearMonthEd);
                //-- ADD 2010/05/13 --------------------------------------------<<<

            }
            #endregion  //[JOIN]

            #region [WHERE��]
            selectTxt += " WHERE" + Environment.NewLine;
            selectTxt += " GSMSLP.ENTERPRISECODERF=@GSMSLPENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@GSMSLPENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //����͈͎w��
            //if (CndtnWork.PrintRangeSt != 0)
            if (CndtnWork.PrintRangeSt != -99999999)
            {
                selectTxt += " AND ((" + Environment.NewLine;
                for (int i = 1; i <= 12; i++)
                {
                    selectTxt += " GSMSLP.TOTALSALESCOUNT" + i.ToString();
                    if (i <= 11)
                        selectTxt += " + " + Environment.NewLine;
                }
                selectTxt += ") >=@TOTALSALESCOUNTST )" + Environment.NewLine;
                SqlParameter paraPrintRangeSt = sqlCommand.Parameters.Add("@TOTALSALESCOUNTST", SqlDbType.Int);
                paraPrintRangeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintRangeSt);
            }
            if (CndtnWork.PrintRangeEd != 999999999)
            {
                selectTxt += " AND ((" + Environment.NewLine;
                for (int i = 1; i <= 12; i++)
                {
                    selectTxt += " GSMSLP.TOTALSALESCOUNT" + i.ToString();
                    if (i <= 11)
                        selectTxt += " + " + Environment.NewLine;
                }
                selectTxt += ") <=@TOTALSALESCOUNTED )" + Environment.NewLine;
                SqlParameter paraPrintRangeEd = sqlCommand.Parameters.Add("@TOTALSALESCOUNTED", SqlDbType.Int);
                paraPrintRangeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.PrintRangeEd);
            }
            // ADD 2008.11.05  >>>
            selectTxt += " AND (" + Environment.NewLine;
            for (int cnt = 1; cnt <= 12; cnt++)
            {
                selectTxt += " TOTALSALESCOUNT" + cnt.ToString() + "!=0 " + Environment.NewLine;
                selectTxt += " OR ";
                selectTxt += " SALESMONEY" + cnt.ToString() + " !=0 " + Environment.NewLine;
                if (cnt != 12) selectTxt += " OR ";
            }
            selectTxt += " )" + Environment.NewLine;
            // ADD 2008.11.05 <<<

            #endregion  //[WHERE��]

            #endregion  //[Select���쐬]

            return selectTxt;
        }
        #endregion  //[���Ӑ�ʗp Select����������]

        #region [���i�ʔ��㌎���W�v�f�[�^�p SubQuery��������]
        /// <summary>
        /// ���i�ʔ��㌎���W�v�f�[�^�p SubQuery��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <param name="sTblNm">�e�[�u������</param>
        /// <param name="iRsltTtlDivCd">�݌Ɏ�񂹋敪</param>
        /// <returns>���i�ʔ��㌎���W�v�f�[�^�pSELECT��</returns>
        /// <br>Note       : ���i�ʔ��㌎���W�v�f�[�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.08</br>
        private string MakeSubQueryString(ref SqlCommand sqlCommand, SalesTransListCndtnWork CndtnWork, string sTblNm, int iRsltTtlDivCd)
        {
            string retstring = "";
            DateTime stDate = CndtnWork.AddUpYearMonthSt;
            DateTime edDate = CndtnWork.AddUpYearMonthEd;
            Int32 setDate = stDate.Year * 100 + stDate.Month;

            #region [���i�ʔ��㌎���W�v�f�[�^���oQuery]
            retstring += " SELECT" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += IFBy(bEmployeeCode,
                         "  ," + sTblNm + ".EMPLOYEECODERF" + Environment.NewLine);
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
            //���v(����)
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR1) AS TOTALSALESCOUNT1" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR2) AS TOTALSALESCOUNT2" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR3) AS TOTALSALESCOUNT3" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR4) AS TOTALSALESCOUNT4" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR5) AS TOTALSALESCOUNT5" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR6) AS TOTALSALESCOUNT6" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR7) AS TOTALSALESCOUNT7" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR8) AS TOTALSALESCOUNT8" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR9) AS TOTALSALESCOUNT9" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR10) AS TOTALSALESCOUNT10" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR11) AS TOTALSALESCOUNT11" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_TOTALSALESCOUNTR12) AS TOTALSALESCOUNT12" + Environment.NewLine;
            //���v(���z)
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY1) AS SALESMONEY1" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY2) AS SALESMONEY2" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY3) AS SALESMONEY3" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY4) AS SALESMONEY4" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY5) AS SALESMONEY5" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY6) AS SALESMONEY6" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY7) AS SALESMONEY7" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY8) AS SALESMONEY8" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY9) AS SALESMONEY9" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY10) AS SALESMONEY10" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY11) AS SALESMONEY11" + Environment.NewLine;
            retstring += "  ,SUM(" + sTblNm + ".M_SALESMONEY12) AS SALESMONEY12" + Environment.NewLine;

            retstring += " FROM" + Environment.NewLine;
            retstring += " (" + Environment.NewLine;

            #region [���v�W�v]
            retstring += "  SELECT" + Environment.NewLine;
            retstring += "    " + sTblNm + "SUB.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "   ," + sTblNm + "SUB.ADDUPYEARMONTHRF" + Environment.NewLine;
            retstring += IFBy(bEmployeeCode,
                         "   ," + sTblNm + "SUB.EMPLOYEECODERF" + Environment.NewLine);
            retstring += IFBy(bAddUpSecCode,
                         "   ," + sTblNm + "SUB.ADDUPSECCODERF" + Environment.NewLine);
            retstring += IFBy(bGoodsMakerCd,
                         "   ," + sTblNm + "SUB.GOODSMAKERCDRF" + Environment.NewLine);
            retstring += IFBy(bBLGoodsCode,
                         "   ," + sTblNm + "SUB.BLGOODSCODERF" + Environment.NewLine);
            retstring += IFBy(bBLGroupCode,
                         "   ," + sTblNm + "SUB.BLGROUPCODERF" + Environment.NewLine);
            retstring += IFBy(bGoodsMGroup,
                         "   ," + sTblNm + "SUB.GOODSMGROUPRF" + Environment.NewLine);
            retstring += IFBy(bGoodsLGroup,
                         "   ," + sTblNm + "SUB.GOODSLGROUPRF" + Environment.NewLine);
            retstring += IFBy(bGoodsNo,
                         "   ," + sTblNm + "SUB.GOODSNORF" + Environment.NewLine);

            for (int i = 1; i <= 12; i++)
            {
                //���v(����)
                retstring += "   ,CASE WHEN " + sTblNm + "SUB.ADDUPYEARMONTHRF=" + setDate.ToString() + " THEN " + sTblNm + "SUB.TOTALSALESCOUNTRF ELSE 0.0 END AS M_TOTALSALESCOUNTR" + i.ToString() + Environment.NewLine;
                //���v(���z)
                //retstring += "   ,CASE WHEN " + sTblNm + "SUB.ADDUPYEARMONTHRF=" + setDate.ToString() + " THEN " + sTblNm + "SUB.SALESMONEYRF ELSE 0 END AS M_SALESMONEY" + i.ToString() + Environment.NewLine; // DEL 2008.11.05
                retstring += "   ,CASE WHEN " + sTblNm + "SUB.ADDUPYEARMONTHRF=" + setDate.ToString() + " THEN  (" + sTblNm + "SUB.SALESMONEYRF + " + sTblNm + "SUB.SALESRETGOODSPRICERF + " + sTblNm + "SUB.DISCOUNTPRICERF ) " + " ELSE 0 END AS M_SALESMONEY" + i.ToString() + Environment.NewLine; // ADD 2008.11.05

                if (setDate % 100 >= 12)
                {
                    setDate = (setDate + 100) / 100 * 100 + 1;
                }
                else
                {
                    setDate = setDate + 1;
                }
            }

            retstring += "  FROM" + Environment.NewLine;
            retstring += "  (" + Environment.NewLine;

            #region [���i�ʔ��㌎���W�v�f�[�^���o]
            retstring += "   SELECT" + Environment.NewLine;
            retstring += "     " + sTblNm + "SUB2.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.ADDUPSECCODERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.ADDUPYEARMONTHRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.EMPLOYEECODERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.GOODSNORF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.BLGOODSCODERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.GOODSMAKERCDRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.TOTALSALESCOUNTRF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.SALESMONEYRF" + Environment.NewLine;
            // ADD 2008.11.05 >>>
            retstring += "    ," + sTblNm + "SUB2.SALESRETGOODSPRICERF" + Environment.NewLine;
            retstring += "    ," + sTblNm + "SUB2.DISCOUNTPRICERF" + Environment.NewLine;
            // ADD 2008.11.05 <<<
            
            // 2008/12/10 >>>>>>>>>>>>>>>>>
            //retstring += "    ,BLGCDU" + sTblNm + ".BLGROUPCODERF" + Environment.NewLine;
            //retstring += "    ,BLGRPU" + sTblNm + ".GOODSMGROUPRF" + Environment.NewLine;
            //retstring += "    ,BLGRPU" + sTblNm + ".GOODSLGROUPRF" + Environment.NewLine;
            retstring += "    ,(CASE WHEN BLGCDU" + sTblNm + ".BLGROUPCODERF IS NULL THEN 0 ELSE BLGCDU" + sTblNm + ".BLGROUPCODERF END) AS BLGROUPCODERF" + Environment.NewLine;
            retstring += "    ,(CASE WHEN BLGRPU" + sTblNm + ".GOODSMGROUPRF IS NULL THEN 0 ELSE BLGRPU" + sTblNm + ".GOODSMGROUPRF END) AS GOODSMGROUPRF" + Environment.NewLine;
            retstring += "    ,(CASE WHEN BLGRPU" + sTblNm + ".GOODSLGROUPRF IS NULL THEN 0 ELSE BLGRPU" + sTblNm + ".GOODSLGROUPRF END) AS GOODSLGROUPRF" + Environment.NewLine;
            // 2008/12/10 <<<<<<<<<<<<<<<<<
            // 2011/08/01 >>>
            //retstring += "   FROM GOODSMTTLSASLIPRF AS " + sTblNm + "SUB2" + Environment.NewLine;
            //retstring += "   LEFT JOIN BLGOODSCDURF BLGCDU" + sTblNm + Environment.NewLine;
            retstring += "   FROM GOODSMTTLSASLIPRF AS " + sTblNm + "SUB2 WITH (READUNCOMMITTED) " + Environment.NewLine;
            retstring += "   LEFT JOIN BLGOODSCDURF BLGCDU" + sTblNm + " WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            retstring += "   ON  BLGCDU" + sTblNm + ".ENTERPRISECODERF=" + sTblNm + "SUB2.ENTERPRISECODERF" + Environment.NewLine;
            retstring += "   AND BLGCDU" + sTblNm + ".BLGOODSCODERF=" + sTblNm + "SUB2.BLGOODSCODERF" + Environment.NewLine;
            // 2011/08/01 >>>
            //retstring += "   LEFT JOIN BLGROUPURF BLGRPU" + sTblNm + Environment.NewLine;
            retstring += "   LEFT JOIN BLGROUPURF BLGRPU" + sTblNm + " WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            retstring += "   ON  BLGRPU" + sTblNm + ".ENTERPRISECODERF=BLGCDU" + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "   AND BLGRPU" + sTblNm + ".BLGROUPCODERF=BLGCDU" + sTblNm + ".BLGROUPCODERF" + Environment.NewLine;
            retstring += MakeWhereString(ref sqlCommand, CndtnWork, sTblNm + "SUB2", "BLGCDU" + sTblNm, "BLGRPU" + sTblNm, iRsltTtlDivCd);
            #endregion  //[���i�ʔ��㌎���W�v�f�[�^���o]

            retstring += "  ) AS " + sTblNm + "SUB" + Environment.NewLine;

            #endregion  //[���v�W�v]

            retstring += " ) AS " + sTblNm + Environment.NewLine;

            #region [GROUP BY]
            retstring += " GROUP BY" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += IFBy(bEmployeeCode,
                         "  ," + sTblNm + ".EMPLOYEECODERF" + Environment.NewLine);
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
        /// <returns>���i�ʔ��㌎���W�v�f�[�^�pWHERE��</returns>
        /// <br>Note       : ���i�ʔ��㌎���W�v�f�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.08</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesTransListCndtnWork CndtnWork, string sGSMSLP, string sBLGCDU, string sBLGRPU, int iRsltTtlDivCd)
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
            retstring += " AND " + sGSMSLP + ".ADDUPYEARMONTHRF>=@" + sGSMSLP + "ADDUPYEARMONTHST" + Environment.NewLine;
            SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "ADDUPYEARMONTHST", SqlDbType.Int);
            paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AddUpYearMonthSt);

            retstring += " AND " + sGSMSLP + ".ADDUPYEARMONTHRF<=@" + sGSMSLP + "ADDUPYEARMONTHED" + Environment.NewLine;
            SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "ADDUPYEARMONTHED", SqlDbType.Int);
            paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.AddUpYearMonthEd);

            //�]�ƈ��R�[�h
            if (CndtnWork.EmployeeCodeSt != "")
            {
                retstring += " AND " + sGSMSLP + ".EMPLOYEECODERF>=@" + sGSMSLP + "EMPLOYEECODEST" + Environment.NewLine;
                SqlParameter paraEmployeeCodeSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "EMPLOYEECODEST", SqlDbType.NChar);
                paraEmployeeCodeSt.Value = SqlDataMediator.SqlSetString(CndtnWork.EmployeeCodeSt);
            }
            if (CndtnWork.EmployeeCodeEd != "")
            {
                retstring += " AND " + sGSMSLP + ".EMPLOYEECODERF<=@" + sGSMSLP + "EMPLOYEECODEED" + Environment.NewLine;
                SqlParameter paraEmployeeCodeEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "EMPLOYEECODEED", SqlDbType.NChar);
                paraEmployeeCodeEd.Value = SqlDataMediator.SqlSetString(CndtnWork.EmployeeCodeEd);
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

            //���i�ԍ�
            if (CndtnWork.GoodsNoSt != "")
            {
                // ADD 2008.11.05 >>>
                if (CndtnWork.GoodsNoSt.LastIndexOf("*") >= 0)
                {
                    String[] GoodsNoSt = CndtnWork.GoodsNoSt.Split(new Char[] { '*' });

                    retstring += " AND (" + sGSMSLP + ".GOODSNORF>=@" + sGSMSLP + "GOODSNOST OR " + sGSMSLP + ".GOODSNORF LIKE @" + sGSMSLP + "GOODSNOST )" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(GoodsNoSt[0] + "%");
                }
                else
                {
                    // ADD 2008.11.05 <<<

                    retstring += " AND " + sGSMSLP + ".GOODSNORF>=@" + sGSMSLP + "GOODSNOST" + Environment.NewLine;
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@" + sGSMSLP + "GOODSNOST", SqlDbType.NVarChar);
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoSt);
                } // ADD 2008.11.05 
            }
            if (CndtnWork.GoodsNoEd != "")
            {
                // ADD 2008.11.05 >>>
                if (CndtnWork.GoodsNoEd.LastIndexOf("*") >= 0)
                {
                    String[] GoodsNoEd = CndtnWork.GoodsNoEd.Split(new Char[] { '*' });
                    retstring += " AND ( " + sGSMSLP + ".GOODSNORF<=@" + sGSMSLP + "GOODSNOED OR " + sGSMSLP + ".GOODSNORF LIKE @" + sGSMSLP + "GOODSNOED )" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(GoodsNoEd[0] + "%");
                }
                else
                {
                    // ADD 2008.11.05 <<<

                    retstring += " AND " + sGSMSLP + ".GOODSNORF<=@" + sGSMSLP + "GOODSNOED" + Environment.NewLine;
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@" + sGSMSLP + "GOODSNOED", SqlDbType.NVarChar);
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoEd);
                } // ADD 2008.11.05 
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
                //�J�n���ŏ��`�̏ꍇ�͂m�t�k�k���ΏۂƂ���
                if (CndtnWork.BLGroupCodeSt == 0)
                {
                    retstring += " AND (" + sBLGCDU + ".BLGROUPCODERF<=@" + sBLGCDU + "BLGROUPCODEED" + " OR " + sBLGCDU + ".BLGROUPCODERF IS NULL)" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND " + sBLGCDU + ".BLGROUPCODERF<=@" + sBLGCDU + "BLGROUPCODEED" + Environment.NewLine;
                }

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
                //�J�n���ŏ��`�̏ꍇ�͂m�t�k�k���ΏۂƂ���
                if (CndtnWork.GoodsLGroupSt == 0)
                {
                    retstring += " AND (" + sBLGRPU + ".GOODSLGROUPRF<=@" + sBLGRPU + "GOODSLGROUPED" + " OR " + sBLGRPU + ".GOODSLGROUPRF IS NULL)" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND " + sBLGRPU + ".GOODSLGROUPRF<=@" + sBLGRPU + "GOODSLGROUPED" + Environment.NewLine;
                }

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
                //�J�n���ŏ��`�̏ꍇ�͂m�t�k�k���ΏۂƂ���
                if (CndtnWork.GoodsMGroupSt == 0)
                {
                    retstring += " AND (" + sBLGRPU + ".GOODSMGROUPRF<=@" + sBLGRPU + "GOODSMGROUPED" + " OR " + sBLGRPU + ".GOODSMGROUPRF IS NULL)" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND " + sBLGRPU + ".GOODSMGROUPRF<=@" + sBLGRPU + "GOODSMGROUPED" + Environment.NewLine;
                }

                SqlParameter paraGoodsMGroupEd = sqlCommand.Parameters.Add("@" + sBLGRPU + "GOODSMGROUPED", SqlDbType.Int);
                paraGoodsMGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupEd);
            }
            #endregion  //[BL���i�R�[�h�}�X�^�EBL�O���[�v�}�X�^]

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
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.08</br>
        /// </remarks>
        public SalesTransListResultWork CopyToSalesRsltListResultWorkFromReader(ref SqlDataReader myReader, SalesTransListCndtnWork CndtnWork)
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
        /// <br>Date       : 2008.09.08</br>
        /// <br>Update Note: 2009.04.28 ����</br>
        /// <br>            �E���[�J�[����==>���[�J�[����
        /// </remarks>
        private SalesTransListResultWork CopyToSalesRsltListResultWorkFromReaderProc(ref SqlDataReader myReader, SalesTransListCndtnWork CndtnWork)
        {
            #region [���ʗp�t���O]
            //�v�㋒�_�R�[�h
            if (CndtnWork.TtlType == 1)
            {
                bAddUpSecCode = true;
            }

            //�]�ƈ��R�[�h
            if ((CndtnWork.Detail == 0) ||
                (CndtnWork.Detail == 1) ||
                (CndtnWork.Detail == 2) ||
                (CndtnWork.Detail == 3) ||
                (CndtnWork.Detail == 4) ||
                (CndtnWork.Detail == 5) ||
                (CndtnWork.Detail == 6))
            {
                bEmployeeCode = true;
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
            SalesTransListResultWork ResultWork = new SalesTransListResultWork();

            if (bEmployeeCode)
            {
                ResultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                ResultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
            }
            if (bAddUpSecCode)
            {
                ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
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

            ResultWork.TotalSalesCount1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT1"));
            ResultWork.TotalSalesCount2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT2"));
            ResultWork.TotalSalesCount3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT3"));
            ResultWork.TotalSalesCount4 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT4"));
            ResultWork.TotalSalesCount5 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT5"));
            ResultWork.TotalSalesCount6 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT6"));
            ResultWork.TotalSalesCount7 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT7"));
            ResultWork.TotalSalesCount8 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT8"));
            ResultWork.TotalSalesCount9 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT9"));
            ResultWork.TotalSalesCount10 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT10"));
            ResultWork.TotalSalesCount11 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT11"));
            ResultWork.TotalSalesCount12 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT12"));
            ResultWork.SalesMoney1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY1"));
            ResultWork.SalesMoney2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY2"));
            ResultWork.SalesMoney3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY3"));
            ResultWork.SalesMoney4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY4"));
            ResultWork.SalesMoney5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY5"));
            ResultWork.SalesMoney6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY6"));
            ResultWork.SalesMoney7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY7"));
            ResultWork.SalesMoney8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY8"));
            ResultWork.SalesMoney9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY9"));
            ResultWork.SalesMoney10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY10"));
            ResultWork.SalesMoney11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY11"));
            ResultWork.SalesMoney12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY12"));
            #endregion  //[���o����-�l�Z�b�g]

            return ResultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader����]
    }
}

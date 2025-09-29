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
    class MTtlSaSlipBLCd : MTtlSaSlipBase, IMTtlSaSlip
    {
        #region [���ʗp�t���O�錾]
        private bool bAddUpSecCode = false;  //�v�㋒�_�R�[�h
        #endregion  //[���ʗp�t���O�錾]

        #region [BL�R�[�h�ʗp Select��]
        /// <summary>
        /// BL�R�[�h�ʗpSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>BL�R�[�h�ʗpSELECT��</returns>
        /// <br>Note       : BL�R�[�h�ʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.25</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, ShipmGoodsOdrReportParamWork CndtnWork)
        {
            return this.MakeSelectStringProc(ref sqlCommand, CndtnWork);
        }
        #endregion  //[BL�R�[�h�ʗp Select��]

        #region [BL�R�[�h�ʗp Select����������]
        /// <summary>
        /// BL�R�[�h�ʗpSELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>BL�R�[�h�ʗpSELECT��</returns>
        /// <br>Note       : BL�R�[�h�ʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.25</br>
        private string MakeSelectStringProc(ref SqlCommand sqlCommand, ShipmGoodsOdrReportParamWork CndtnWork)
        {
            #region [���ʗp�t���O]
            //�v�㋒�_�R�[�h
            if (CndtnWork.TtlType == 1)
            {
                bAddUpSecCode = true;
            }
            #endregion  //[���ʗp�t���O]

            string selectTxt = "";

            // �Ώۃe�[�u��
            // GOODSMTTLSASLIPRF GSMSLP ���i�ʔ��㌎���W�v�f�[�^
            // MAKERURF          MAKERU ���[�J�[�}�X�^(���[�U�[�o�^��)
            // BLGOODSCDURF      BLGCDU BL���i�R�[�h�}�X�^(���[�U�[)
            // BLGROUPURF        BLGRPU BL�O���[�v�}�X�^(���[�U�[)
            // USERGDBDURF       USGDBU ���[�U�[�K�C�h�}�X�^(�{�f�B)(���[�U�ύX��)
            // SECINFOSETRF      SCINST ���_���ݒ�}�X�^
            // SUPPLIERRF        SUPLER �d����}�X�^
            // GOODSGROUPURF     GSGRPU ���i�����ރ}�X�^(���[�U�[�o�^��)

            #region [Select���쐬]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " ,GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;
            selectTxt += " ,GSMSLP.SUPPLIERCDRF" + Environment.NewLine;
            selectTxt += " ,SUPLER.SUPPLIERSNMRF" + Environment.NewLine;
            selectTxt += " ,GSMSLP.BLGOODSCODERF" + Environment.NewLine;
            selectTxt += " ,BLGCDU.BLGOODSHALFNAMERF" + Environment.NewLine;
            //selectTxt += " ,MAKERU.MAKERSHORTNAMERF" + Environment.NewLine;
            selectTxt += " ,MAKERU.MAKERNAMERF" + Environment.NewLine;
            selectTxt += " ,BLGRPU.GOODSLGROUPRF" + Environment.NewLine;
            selectTxt += " ,USGDBUL.GUIDENAMERF AS GOODSLGROUPNAME" + Environment.NewLine;
            selectTxt += " ,BLGRPU.GOODSMGROUPRF" + Environment.NewLine;
            selectTxt += " ,GSGRPU.GOODSMGROUPNAMERF" + Environment.NewLine;
            selectTxt += " ,BLGCDU.BLGROUPCODERF" + Environment.NewLine;
            selectTxt += " ,BLGRPU.BLGROUPKANANAMERF" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESCOUNT" + Environment.NewLine;
            selectTxt += " ,GSMSLP.TOTALSALESMONEY" + Environment.NewLine;
            selectTxt += " ,GSMSLP.GROSSPROFIT" + Environment.NewLine;
            selectTxt += IFBy(bAddUpSecCode,
                         " ,GSMSLP.ADDUPSECCODERF" + Environment.NewLine);
            selectTxt += IFBy(bAddUpSecCode,
                         " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
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
                selectTxt += "    GSMSLPM1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   ,GSMSLPM1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "   ,GSMSLPM1.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "   ,GSMSLPM1.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "   ,GSMSLPM1.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESCOUNT<>0.0 THEN (CASE WHEN GSMSLPM2.TOTALSALESCOUNT<>0.0 THEN (GSMSLPM1.TOTALSALESCOUNT-GSMSLPM2.TOTALSALESCOUNT) ELSE GSMSLPM1.TOTALSALESCOUNT END) ELSE 0.0 END) AS TOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.TOTALSALESMONEY<>0 THEN (CASE WHEN GSMSLPM2.TOTALSALESMONEY<>0 THEN (GSMSLPM1.TOTALSALESMONEY-GSMSLPM2.TOTALSALESMONEY) ELSE GSMSLPM1.TOTALSALESMONEY END) ELSE 0 END) AS TOTALSALESMONEY" + Environment.NewLine;
                selectTxt += "   ,(CASE WHEN GSMSLPM1.GROSSPROFIT<>0 THEN (CASE WHEN GSMSLPM2.GROSSPROFIT<>0 THEN (GSMSLPM1.GROSSPROFIT-GSMSLPM2.GROSSPROFIT) ELSE GSMSLPM1.GROSSPROFIT END) ELSE 0 END) AS GROSSPROFIT" + Environment.NewLine;
                selectTxt += "  FROM" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                //���v�����o�T�uQuery
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPM1SUB", (int)RsltTtlDivCd.PrtTtl);
                selectTxt += "  ) AS GSMSLPM1" + Environment.NewLine;
                #endregion  //[���v�����o]

                #region [�݌ɕ����o]
                selectTxt += "  LEFT JOIN" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     GSMSLPM2SUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESCOUNT" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.TOTALSALESMONEY" + Environment.NewLine;
                selectTxt += "    ,GSMSLPM2SUB.GROSSPROFIT" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "    ,GSMSLPM2SUB.ADDUPSECCODERF" + Environment.NewLine);
                selectTxt += "   FROM" + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                //�݌ɕ����o�T�uQuery
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPM2SUB", (int)RsltTtlDivCd.Stock);
                selectTxt += "   ) AS GSMSLPM2SUB" + Environment.NewLine;
                selectTxt += "  ) AS GSMSLPM2" + Environment.NewLine;
                selectTxt += "  ON  GSMSLPM2.ENTERPRISECODERF=GSMSLPM1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GSMSLPM2.GOODSMAKERCDRF=GSMSLPM1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND GSMSLPM2.SUPPLIERCDRF=GSMSLPM1.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  AND GSMSLPM2.BLGOODSCODERF=GSMSLPM1.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += IFBy(bAddUpSecCode,
                             "  AND GSMSLPM2.ADDUPSECCODERF=GSMSLPM1.ADDUPSECCODERF" + Environment.NewLine);
                #endregion  //[�݌ɕ����o]

                #endregion  //[��񂹂̏ꍇ]
            }
            else
            {
                //���vor�݌ɂ̏ꍇ
                selectTxt += MakeSubQueryString(ref sqlCommand, CndtnWork, "GSMSLPM", CndtnWork.RsltTtlDivCd);
            }
            #endregion  //[�f�[�^���o���C��Query]

            selectTxt += " ) AS GSMSLP" + Environment.NewLine;

            #region [JOIN]
            //���[�J�[�}�X�^(���[�U�[�o�^��)
            // 2011/08/01 >>>
            //selectTxt += " LEFT JOIN MAKERURF MAKERU" + Environment.NewLine;
            selectTxt += " LEFT JOIN MAKERURF MAKERU WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            selectTxt += " ON  MAKERU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND MAKERU.GOODSMAKERCDRF=GSMSLP.GOODSMAKERCDRF" + Environment.NewLine;

            //BL���i�R�[�h�}�X�^(���[�U�[)
            // 2011/08/01 >>>
            //selectTxt += " LEFT JOIN BLGOODSCDURF BLGCDU" + Environment.NewLine;
            selectTxt += " LEFT JOIN BLGOODSCDURF BLGCDU WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            selectTxt += " ON  BLGCDU.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND BLGCDU.BLGOODSCODERF=GSMSLP.BLGOODSCODERF" + Environment.NewLine;

            //BL�O���[�v�}�X�^(���[�U�[)
            // 2011/08/01 >>>
            //selectTxt += " LEFT JOIN BLGROUPURF BLGRPU" + Environment.NewLine;
            selectTxt += " LEFT JOIN BLGROUPURF BLGRPU WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            selectTxt += " ON  BLGRPU.ENTERPRISECODERF=BLGCDU.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND BLGRPU.BLGROUPCODERF=BLGCDU.BLGROUPCODERF" + Environment.NewLine;

            //���[�U�[�K�C�h�}�X�^ �����i�啪�ރK�C�h���̎擾�p
            // 2011/08/01 >>>
            //selectTxt += " LEFT JOIN USERGDBDURF USGDBUL" + Environment.NewLine;
            selectTxt += " LEFT JOIN USERGDBDURF USGDBUL WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            selectTxt += " ON  USGDBUL.ENTERPRISECODERF=BLGRPU.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USGDBUL.GUIDECODERF=BLGRPU.GOODSLGROUPRF" + Environment.NewLine;
            selectTxt += " AND USGDBUL.USERGUIDEDIVCDRF=70" + Environment.NewLine;

            //���i�����ރ}�X�^(���[�U�[�o�^��)
            // 2011/08/01 >>>
            //selectTxt += " LEFT JOIN GOODSGROUPURF GSGRPU" + Environment.NewLine;
            selectTxt += " LEFT JOIN GOODSGROUPURF GSGRPU WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            selectTxt += " ON  GSGRPU.ENTERPRISECODERF=BLGRPU.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND GSGRPU.GOODSMGROUPRF=BLGRPU.GOODSMGROUPRF" + Environment.NewLine;

            //�d����}�X�^
            // 2011/08/01 >>>
            //selectTxt += " LEFT JOIN SUPPLIERRF SUPLER" + Environment.NewLine;
            selectTxt += " LEFT JOIN SUPPLIERRF SUPLER WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            selectTxt += " ON  SUPLER.ENTERPRISECODERF=GSMSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND SUPLER.SUPPLIERCDRF=GSMSLP.SUPPLIERCDRF" + Environment.NewLine;

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
            #endregion  //[JOIN]

            //WHERE��
            selectTxt += MakeWhereString(ref sqlCommand, CndtnWork);

            #endregion  //[Select���쐬]

            return selectTxt;
        }
        #endregion  //[BL�R�[�h�ʗp Select����������]

        #region [���v���o�p SubQuery��������]
        /// <summary>
        /// ���v���o�p SubQuery��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>���v���o�pSELECT��</returns>
        /// <br>Note       : ���v���o�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.25</br>
        private string MakeSubQueryString(ref SqlCommand sqlCommand, ShipmGoodsOdrReportParamWork CndtnWork, string sTblNm, int iRsltTtlDivCd)
        {
            string retstring = "";

            #region [���i�ʔ��㌎���W�v�f�[�^���oQuery]
            retstring += " SELECT" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".GOODSMAKERCDRF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".SUPPLIERCDRF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".BLGOODSCODERF" + Environment.NewLine;
            retstring += IFBy(bAddUpSecCode,
                         "  ," + sTblNm + ".ADDUPSECCODERF" + Environment.NewLine);
            retstring += "  ,SUM(" + sTblNm + ".TOTALSALESCOUNTRF) AS TOTALSALESCOUNT" + Environment.NewLine;

             retstring += "  ,(SUM(" + sTblNm + ".SALESMONEYRF) + SUM(" + sTblNm + ".SALESRETGOODSPRICERF) + SUM(" + sTblNm + ".DISCOUNTPRICERF)) AS TOTALSALESMONEY" + Environment.NewLine; // DEL 2008.11.04
            retstring += "  ,SUM(" + sTblNm + ".GROSSPROFITRF) AS GROSSPROFIT" + Environment.NewLine;
            // 2011/08/01 >>>
            //retstring += " FROM GOODSMTTLSASLIPRF AS " + sTblNm + Environment.NewLine;
            retstring += " FROM GOODSMTTLSASLIPRF AS " + sTblNm + " WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2011/08/01 <<<
            retstring += MakeWhereString_GSMSLP(ref sqlCommand, CndtnWork, sTblNm, iRsltTtlDivCd);
            retstring += " GROUP BY" + Environment.NewLine;
            retstring += "   " + sTblNm + ".ENTERPRISECODERF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".GOODSMAKERCDRF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".SUPPLIERCDRF" + Environment.NewLine;
            retstring += "  ," + sTblNm + ".BLGOODSCODERF" + Environment.NewLine;
            retstring += IFBy(bAddUpSecCode,
                         "  ," + sTblNm + ".ADDUPSECCODERF" + Environment.NewLine);
            #endregion  //[���i�ʔ��㌎���W�v�f�[�^���oQuery]

            return retstring;
        }
        #endregion //���v���o�p SubQuery��������

        #region [BL�R�[�h�ʗp Where�� ��������]
        /// <summary>
        /// BL�R�[�h�ʗpWHERE�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������<��������/param>
        /// <returns>BL�R�[�h�ʗpWHERE��</returns>
        /// <br>Note       : BL�R�[�h�ʗpWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.25</br>
        public string MakeWhereString(ref SqlCommand sqlCommand, ShipmGoodsOdrReportParamWork CndtnWork)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " GSMSLP.ENTERPRISECODERF=@GSMSLPENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@GSMSLPENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //BL�O���[�v�R�[�h
            string groupString = string.Empty;
            string stString = string.Empty;
            string edString = string.Empty;

            if (CndtnWork.BLGroupCodeAry != null && CndtnWork.BLGroupCodeAry.Length != 0)
            {
                string BLGroupCodeArystr = "";
                foreach (int BLGCAry in CndtnWork.BLGroupCodeAry)
                {
                    if (BLGroupCodeArystr != "")
                    {
                        BLGroupCodeArystr += ",";
                    }
                    BLGroupCodeArystr += BLGCAry.ToString();
                }
                if (BLGroupCodeArystr != "")
                {
                    groupString += " BLGCDU.BLGROUPCODERF IN (" + BLGroupCodeArystr + ") ";
                }
                groupString += Environment.NewLine;
            }

            if (CndtnWork.BLGroupCodeSt != 0)
            {
                stString += " BLGCDU.BLGROUPCODERF>=@BLGROUPCODEST" + Environment.NewLine;
                SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@BLGROUPCODEST", SqlDbType.Int);
                paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeSt);
            }

            if (CndtnWork.BLGroupCodeEd != 99999)
            {
                edString += " BLGCDU.BLGROUPCODERF<=@BLGROUPCODEED" + Environment.NewLine;
                SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@BLGROUPCODEED", SqlDbType.Int);
                paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeEd);
            }

            //�O���[�v�R�[�h�p�����񐶐�
            if ((groupString != string.Empty) || (stString != string.Empty) || (edString != string.Empty))
            {
                retstring += " AND (";

                if (groupString != string.Empty)
                {
                    retstring += groupString;
                }

                if (stString != string.Empty)
                {
                    if (groupString != string.Empty)
                    {
                        retstring += " OR" + stString;
                    }
                    else
                    {
                        retstring += stString;
                    }
                }

                if (edString != string.Empty)
                {
                    if (stString != string.Empty)
                    {
                        retstring += " AND" + edString;
                    }
                    else
                    {
                        if (groupString != string.Empty)
                        {
                            retstring += " OR" + edString;
                        }
                        else
                        {
                            retstring += edString;
                            retstring += " OR BLGCDU.BLGROUPCODERF IS NULL " + Environment.NewLine;
                        }
                    }
                }

                retstring += " )" + Environment.NewLine;
            }

            //�J�n���i�啪�ރR�[�h
            if (CndtnWork.GoodsLGroupSt != 0)
            {
                retstring += " AND  BLGRPU.GOODSLGROUPRF>=@GOODSLGROUPST" + Environment.NewLine;
                SqlParameter paraGoodsLGroupSt = sqlCommand.Parameters.Add("@GOODSLGROUPST", SqlDbType.Int);
                paraGoodsLGroupSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsLGroupSt);
            }
            if (CndtnWork.GoodsLGroupEd != 9999)
            {
                retstring += " AND ( BLGRPU.GOODSLGROUPRF<=@GOODSLGROUPED OR BLGRPU.GOODSLGROUPRF IS NULL ) " + Environment.NewLine;
                SqlParameter paraGoodsLGroupEd = sqlCommand.Parameters.Add("@GOODSLGROUPED", SqlDbType.Int);
                paraGoodsLGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsLGroupEd);
            }

            //�J�n���i�����ރR�[�h
            if (CndtnWork.GoodsMGroupSt != 0)
            {
                retstring += " AND BLGRPU.GOODSMGROUPRF>=@GOODSMGROUPST" + Environment.NewLine;
                SqlParameter paraGoodsMGroupSt = sqlCommand.Parameters.Add("@GOODSMGROUPST", SqlDbType.Int);
                paraGoodsMGroupSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupSt);
            }
            if (CndtnWork.GoodsMGroupEd != 9999)
            {
                retstring += " AND ( BLGRPU.GOODSMGROUPRF<=@GOODSMGROUPED OR BLGRPU.GOODSMGROUPRF IS NULL )" + Environment.NewLine;
                SqlParameter paraGoodsMGroupEd = sqlCommand.Parameters.Add("@GOODSMGROUPED", SqlDbType.Int);
                paraGoodsMGroupEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMGroupEd);
            }
            #endregion  //WHERE���쐬

            return retstring;
        }
        #endregion //[BL�R�[�h�ʗp Where�吶������]

        #region [���i�ʔ��㌎���W�v�f�[�^�p Where�� ��������]
        /// <summary>
        /// ���i�ʔ��㌎���W�v�f�[�^�pWHERE�� �������� (���v�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <param name="sTblNm">�e�[�u��������</param>
        /// <returns>���i�ʔ��㌎���W�v�f�[�^�pWHERE��</returns>
        /// <br>Note       : ���i�ʔ��㌎���W�v�f�[�^�pWHERE����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.25</br>
        private string MakeWhereString_GSMSLP(ref SqlCommand sqlCommand, ShipmGoodsOdrReportParamWork CndtnWork, string sTblNm, int iRsltTtlDivCd)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " " + sTblNm + ".ENTERPRISECODERF=@" + sTblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + sTblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            //�_���폜�敪
            retstring += " AND " + sTblNm + ".LOGICALDELETECODERF=0 " + Environment.NewLine;

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
                    retstring += " AND " + sTblNm + ".ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //���яW�v�敪
            retstring += " AND " + sTblNm + ".RSLTTTLDIVCDRF=@" + sTblNm + "RSLTTTLDIVCD" + Environment.NewLine;
            SqlParameter paraRsltTtlDivCd = sqlCommand.Parameters.Add("@" + sTblNm + "RSLTTTLDIVCD", SqlDbType.Int);
            paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(iRsltTtlDivCd);

            //�Ώ۔N��
            retstring += " AND " + sTblNm + ".ADDUPYEARMONTHRF>=@" + sTblNm + "SALESDATEST" + Environment.NewLine;
            SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@" + sTblNm + "SALESDATEST", SqlDbType.Int);
            paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.SalesDateSt);

            retstring += " AND " + sTblNm + ".ADDUPYEARMONTHRF<=@" + sTblNm + "SALESDATEED" + Environment.NewLine;
            SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@" + sTblNm + "SALESDATEED", SqlDbType.Int);
            paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(CndtnWork.SalesDateEd);

            //�d����R�[�h
            if (CndtnWork.SupplierCdSt != 0)
            {
                retstring += " AND " + sTblNm + ".SUPPLIERCDRF>=@" + sTblNm + "SUPPLIERCDST" + Environment.NewLine;
                SqlParameter paraSupplierCdSt = sqlCommand.Parameters.Add("@" + sTblNm + "SUPPLIERCDST", SqlDbType.Int);
                paraSupplierCdSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SupplierCdSt);
            }
            if (CndtnWork.SupplierCdEd != 999999)
            {
                retstring += " AND " + sTblNm + ".SUPPLIERCDRF<=@" + sTblNm + "SUPPLIERCDED" + Environment.NewLine;
                SqlParameter paraCustomerCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "SUPPLIERCDED", SqlDbType.Int);
                paraCustomerCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SupplierCdEd);
            }

            //���i���[�J�[�R�[�h
            if (CndtnWork.GoodsMakerCdSt != 0)
            {
                retstring += " AND " + sTblNm + ".GOODSMAKERCDRF>=@" + sTblNm + "GOODSMAKERCDST" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@" + sTblNm + "GOODSMAKERCDST", SqlDbType.Int);
                paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMakerCdSt);
            }
            if (CndtnWork.GoodsMakerCdEd != 9999)
            {
                retstring += " AND " + sTblNm + ".GOODSMAKERCDRF<=@" + sTblNm + "GOODSMAKERCDED" + Environment.NewLine;
                SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@" + sTblNm + "GOODSMAKERCDED", SqlDbType.Int);
                paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.GoodsMakerCdEd);
            }

            //BL���i�R�[�h
            if (CndtnWork.BLGoodsCodeSt != 0)
            {
                retstring += " AND " + sTblNm + ".BLGOODSCODERF>=@" + sTblNm + "BLGOODSCODEST" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@" + sTblNm + "BLGOODSCODEST", SqlDbType.Int);
                paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeSt);
            }
            if (CndtnWork.BLGoodsCodeEd != 99999999)
            {
                retstring += " AND " + sTblNm + ".BLGOODSCODERF<=@" + sTblNm + "BLGOODSCODEED" + Environment.NewLine;
                SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@" + sTblNm + "BLGOODSCODEED", SqlDbType.Int);
                paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeEd);
            }

            //���i�ԍ�
            if (CndtnWork.GoodsNoSt != "")
            {
                retstring += " AND " + sTblNm + ".GOODSNORF>=@" + sTblNm + "GOODSNOST" + Environment.NewLine;
                SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@" + sTblNm + "GOODSNOST", SqlDbType.NVarChar);
                paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoSt);
            }
            if (CndtnWork.GoodsNoEd != "")
            {
                retstring += " AND " + sTblNm + ".GOODSNORF<=@" + sTblNm + "GOODSNOED" + Environment.NewLine;
                SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@" + sTblNm + "GOODSNOED", SqlDbType.NVarChar);
                paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(CndtnWork.GoodsNoEd);
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
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.25</br>
        /// </remarks>
        public ShipmGoodsOdrReportResultWork CopyToSalesRsltListResultWorkFromReader(ref SqlDataReader myReader, ShipmGoodsOdrReportParamWork CndtnWork)
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
        /// <br>Date       : 2008.08.25</br>
        /// </remarks>
        private ShipmGoodsOdrReportResultWork CopyToSalesRsltListResultWorkFromReaderProc(ref SqlDataReader myReader, ShipmGoodsOdrReportParamWork CndtnWork)
        {
            #region [���o����-�l�Z�b�g]
            ShipmGoodsOdrReportResultWork ResultWork = new ShipmGoodsOdrReportResultWork();

            if (CndtnWork.TtlType == 1)
            {
                ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                ResultWork.CompanyName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            }
            ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            ResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            ResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            ResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            ResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
            ResultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            ResultWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAME"));
            ResultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            ResultWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
            ResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            ResultWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));
            //ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERSHORTNAMERF"));
            ResultWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            ResultWork.TotalSalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSALESCOUNT"));
            ResultWork.TotalSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALSALESMONEY"));
            ResultWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFIT"));
            #endregion  //[���o����-�l�Z�b�g]

            return ResultWork;
        }
        #endregion //[CopyToSalesRsltListResultWorkFromReader����]
    }
}
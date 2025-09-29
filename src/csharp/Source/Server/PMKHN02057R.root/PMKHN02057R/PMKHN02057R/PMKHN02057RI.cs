//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[�����ѕ\
// �v���O�����T�v   : �L�����y�[�����ѕ\�@�̔��敪�ʗp������
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/05/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/07/05  �C�����e : Redmine ��Q�� #22746 �̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/07/07  �C�����e : Redmine �d�l�A�� #22792 �̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/07/11  �C�����e : Redmine �d�l�ύX #22860 �̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/07/27  �C�����e : Redmine ��Q�� #23232 �̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : chenyd
// �� �� ��  2012/04/09  �C�����e : 2012/05/24�z�M���ARedmine#29314           
//                                  �^�C���A�E�g�G���[�̑Ή�
//----------------------------------------------------------------------------//
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    class MTtlCampaignGuide : MTtlCampaignBase, IMTtlCampaign
    {
        #region [���ʗp�t���O�錾]
        private bool bBLGroupCode = false;   // BL�O���[�v�R�[�h
        private bool bBLGoodsCode = false;   // BL���i�R�[�h
        private bool bGoodsNo = false;       // ���i�ԍ�
        private bool bMakerCode = false;     // ���[�J�[�R�[�h
        private FinYearTableGenerator _finYearTableGenerator;
        private int _monthCount = 0;
        #endregion  //[���ʗp�t���O�錾]

        /// <summary>
        /// ��v�N�x�e�[�u���������i�擾
        /// </summary>
        /// <returns></returns>
        private FinYearTableGenerator GetFinYearTableGenerator(string enterpriseCode, ref SqlConnection sqlConnection)
        {
            FinYearTableGenerator finYearTableGenerator = null;

            // ���Џ�񃌃R�[�h�擾
            CompanyInfDB companyInfDB = new CompanyInfDB();
            CompanyInfWork paraWork = new CompanyInfWork();
            paraWork.EnterpriseCode = enterpriseCode;
            ArrayList retList;
            companyInfDB.Search(out retList, paraWork, ref sqlConnection);
            if (retList != null && retList.Count > 0)
            {
                // ��v�N�x���i����
                finYearTableGenerator = new FinYearTableGenerator((CompanyInfWork)retList[0]);
            }

            return finYearTableGenerator;
        }

        /// <summary>
        /// �����Z�o
        /// </summary>
        /// <param name="edDate"></param>
        /// <param name="stDate"></param>
        /// <returns></returns>
        private int GetMonthsCount(DateTime edDate, DateTime stDate)
        {
            int difOfYear = edDate.Year - stDate.Year;
            int difOfMonth = edDate.Month - stDate.Month;

            return ((difOfYear * 12) + (difOfMonth)) + 1;
        }

        #region [�̔��敪�ʗp����Select��]
        /// <summary>
        /// �̔��敪�ʗp����SELECT�� ��������
        /// </summary>
        /// <param name="sqlConnection">sqlConnection�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>�̔��敪�ʗpSELECT��</returns>
        /// <br>Note       : �̔��敪�ʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        public string MakeSalesSelectString(ref SqlConnection sqlConnection, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            return this.MakeSalesSelectStringProc(ref sqlConnection, ref sqlCommand, CndtnWork);
        }
        #endregion  // �̔��敪�ʗp����Select��

        #region [�̔��敪�ʗp����Select����������]
        /// <summary>
        /// �̔��敪�ʗp����SELECT�� ��������
        /// </summary>
        /// <param name="sqlConnection">sqlConnection�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>�̔��敪�ʗp����SELECT��</returns>
        /// <br>Note       : �̔��敪�ʗp����SELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        private string MakeSalesSelectStringProc(ref SqlConnection sqlConnection, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            #region [���ʗp�t���O]
            // BL�O���[�v�R�[�h
            if ((CndtnWork.Detail == 0 && CndtnWork.Total == 0) || CndtnWork.Detail == 2)
            {
                bBLGroupCode = true;
            }

            // BL���i�R�[�h
            if ((CndtnWork.Detail == 0 && CndtnWork.Total == 1) || CndtnWork.Detail == 1)
            {
                bBLGoodsCode = true;
            }

            if (CndtnWork.Detail == 0)
            {
                bGoodsNo = true;
            }

            // ���[�J�[�R�[�h
            if (CndtnWork.PrintType != 1)
            {
                bMakerCode = true;
            }
            #endregion

            string selectTxt = string.Empty;

            if (CndtnWork.PrintType == 1)
            {
                _finYearTableGenerator = this.GetFinYearTableGenerator(CndtnWork.EnterpriseCode, ref sqlConnection);
                //���t�擾���i
                _monthCount = GetMonthsCount(CndtnWork.AddUpYearMonthEd, CndtnWork.AddUpYearMonthSt);
            }
            #region SELECT��
            selectTxt += "SELECT DISTINCT " + Environment.NewLine;
            selectTxt += "  B.SALESSLIPNUMRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESROWNORF " + Environment.NewLine;
            selectTxt += "  ,B.SALESSLIPCDDTLRF " + Environment.NewLine; // ADD 2011/07/27
            selectTxt += "  ,A.RESULTSADDUPSECCDRF AS RESULTSADDUPSECCD " + Environment.NewLine;//���ьv�㋒�_�R�[�h
            selectTxt += "  ,A.SALESDATERF " + Environment.NewLine;
            selectTxt += "  ,B. SALESCODERF AS SALESCODE " + Environment.NewLine;//�̔��敪�R�[�h
            selectTxt += "  ,B. GOODSMAKERCDRF AS GOODSMAKERCD " + Environment.NewLine;//���i���[�J�[�R�[�h
            selectTxt += "  ,B. GOODSNORF AS GOODSNO" + Environment.NewLine;//���i�ԍ�
            selectTxt += "  ,B. GOODSNAMEKANARF AS GOODSNAMEKANA" + Environment.NewLine;//���i���̃J�i
            selectTxt += "  ,B. BLGOODSCODERF AS BLGOODSCODE" + Environment.NewLine;//BL���i�R�[�h
            selectTxt += "  ,B. BLGROUPCODERF AS BLGROUPCODE" + Environment.NewLine;//BL�O���[�v�R�[�h            
            selectTxt += "  ,B.SHIPMENTCNTRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESMONEYTAXEXCRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESMONEYTAXEXCRF - B.COSTRF AS GRSPROFITRF " + Environment.NewLine;
            selectTxt += "  ,CAMPST.CAMPAIGNCODERF " + Environment.NewLine;
            selectTxt += "  ,CAMPST.CAMPAIGNNAMERF " + Environment.NewLine;
            selectTxt += "  ,CAMPST.CAMPAIGNOBJDIVRF " + Environment.NewLine;
            selectTxt += "  ,CAMPST.APPLYSTADATERF " + Environment.NewLine;
            selectTxt += "  ,CAMPST.APPLYENDDATERF " + Environment.NewLine;
            //selectTxt += "  ,CAMPMNG.SECTIONCODERF " + Environment.NewLine; // DEL 2011/07/05
            selectTxt += "  ,SEC.SECTIONGUIDESNMRF AS SECTIONGUIDESNM1 " + Environment.NewLine;//���_�K�C�h����
            selectTxt += "  ,USERGD.GUIDENAMERF AS GUIDENAME " + Environment.NewLine;//���_�K�C�h����
            selectTxt += "  ,MAKER.MAKERNAMERF AS MAKERKANANAME" + Environment.NewLine;
            selectTxt += " ,BLGROUP.BLGROUPKANANAMERF AS BLGROUPKANANAME" + Environment.NewLine;
            selectTxt += " ,BL.BLGOODSHALFNAMERF AS BLGOODSHALFNAME" + Environment.NewLine;

            //���㗚���f�[�^
            selectTxt += "FROM SALESHISTORYRF AS A WITH (READUNCOMMITTED)" + Environment.NewLine;

            #region ���㗚�𖾍׃f�[�^
            selectTxt += "LEFT JOIN SALESHISTDTLRF AS B WITH (READUNCOMMITTED)" + Environment.NewLine;
            selectTxt += "ON A.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF" + Environment.NewLine;// �󒍃X�e�[�^�X
            selectTxt += "AND A.SALESSLIPNUMRF = B.SALESSLIPNUMRF" + Environment.NewLine;//����`�[�ԍ�
            #endregion

            #region ���_���ݒ�}�X�^
            //selectTxt += " LEFT JOIN SECINFOSETRF AS " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += " LEFT JOIN SECINFOSETRF AS SEC WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += " ON SEC.ENTERPRISECODERF = A.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND SEC.SECTIONCODERF = A.RESULTSADDUPSECCDRF" + Environment.NewLine;// ���ьv�㋒�_�R�[�h 
            selectTxt += " AND SEC.LOGICALDELETECODERF = 0" + Environment.NewLine;
            #endregion

            #region ���[�U�[�K�C�h�}�X�^
            //selectTxt += " LEFT JOIN USERGDBDURF AS USERGD " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += " LEFT JOIN USERGDBDURF AS USERGD WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += " ON USERGD.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USERGD.GUIDECODERF = B.SALESCODERF" + Environment.NewLine;// �̔��敪�R�[�h
            selectTxt += " AND USERGD.LOGICALDELETECODERF = 0" + Environment.NewLine;
            selectTxt += " AND USERGD.USERGUIDEDIVCDRF = 71" + Environment.NewLine;            
            #endregion

            #region �a�k���i�R�[�h�}�X�^
            //selectTxt += " LEFT JOIN BLGOODSCDURF AS BL " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += " LEFT JOIN BLGOODSCDURF AS BL WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += " ON BL.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND BL.BLGOODSCODERF = B.BLGOODSCODERF" + Environment.NewLine;//BL���i�R�[�h
            selectTxt += " AND BL.LOGICALDELETECODERF = 0" + Environment.NewLine;
            #endregion

            #region BL�O���[�v�}�X�^�i���[�U�[�o�^���j
            //selectTxt += " LEFT JOIN BLGROUPURF AS BLGROUP " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += " LEFT JOIN BLGROUPURF AS BLGROUP WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += " ON BLGROUP.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND BLGROUP.BLGROUPCODERF = B.BLGROUPCODERF" + Environment.NewLine;//BL�O���[�v�}�X�^
            selectTxt += " AND BLGROUP.LOGICALDELETECODERF = 0" + Environment.NewLine;
            #endregion

            #region ���[�J�[�}�X�^
            //selectTxt += " LEFT JOIN MAKERURF AS MAKER " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += " LEFT JOIN MAKERURF AS MAKER WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += " ON MAKER.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND MAKER.GOODSMAKERCDRF = B.GOODSMAKERCDRF" + Environment.NewLine;//���[�J�[
            selectTxt += " AND MAKER.LOGICALDELETECODERF = 0" + Environment.NewLine;
            #endregion

            //selectTxt += "LEFT JOIN CAMPAIGNSTRF CAMPST " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CAMPAIGNSTRF CAMPST WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON A.ENTERPRISECODERF = CAMPST.ENTERPRISECODERF " + Environment.NewLine;
            // ----- ADD 2012/04/09 chenyd for Redmine#29314 ----- >>>>>
            // �L�����y�[���R�[�h
            selectTxt += "AND CAMPST.CAMPAIGNCODERF = @FINDCAMPAIGNCODE2  " + Environment.NewLine;
            SqlParameter paraCampaignCode2 = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE2", SqlDbType.Int);
            paraCampaignCode2.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);
            // ----- ADD 2012/04/09 chenyd for Redmine#29314 ----- <<<<<
            //selectTxt += "LEFT JOIN CAMPAIGNMNGRF CAMPMNG " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CAMPAIGNMNGRF CAMPMNG WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON CAMPST.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND CAMPST.CAMPAIGNCODERF = CAMPMNG.CAMPAIGNCODERF " + Environment.NewLine;            

            #endregion

            #region WHERE��
            selectTxt += MakeWhereString(ref sqlCommand, CndtnWork);

            selectTxt += " AND ((CAMPMNG.CAMPAIGNSETTINGKINDRF = 1 AND CAMPMNG.GOODSNORF = B.GOODSNORF AND CAMPMNG.GOODSMAKERCDRF = B.GOODSMAKERCDRF)" + Environment.NewLine;
            selectTxt += "   OR (CAMPMNG.CAMPAIGNSETTINGKINDRF = 2 AND CAMPMNG.GOODSMAKERCDRF = B.GOODSMAKERCDRF AND CAMPMNG.BLGOODSCODERF = B.BLGOODSCODERF)  " + Environment.NewLine;
            selectTxt += "   OR (CAMPMNG.CAMPAIGNSETTINGKINDRF = 3 AND CAMPMNG.GOODSMAKERCDRF = B.GOODSMAKERCDRF AND CAMPMNG.BLGROUPCODERF = B.BLGROUPCODERF)  " + Environment.NewLine;
            selectTxt += "   OR (CAMPMNG.CAMPAIGNSETTINGKINDRF = 4 AND CAMPMNG.GOODSMAKERCDRF = B.GOODSMAKERCDRF)  " + Environment.NewLine;
            selectTxt += "   OR (CAMPMNG.CAMPAIGNSETTINGKINDRF = 5 AND CAMPMNG.BLGOODSCODERF = B.BLGOODSCODERF)  " + Environment.NewLine;
            selectTxt += "   OR (CAMPMNG.CAMPAIGNSETTINGKINDRF = 6 AND CAMPMNG.SALESCODERF = B.SALESCODERF)  " + Environment.NewLine;
            selectTxt += " ) " + Environment.NewLine;

            // ----- ADD 2011/07/11 ----->>>>>
            selectTxt += " AND ((CAMPMNG.SECTIONCODERF <> '00' AND A.RESULTSADDUPSECCDRF = CAMPMNG.SECTIONCODERF) OR (CAMPMNG.SECTIONCODERF = '00')) " + Environment.NewLine;
            // ----- ADD 2011/07/11 -----<<<<<

            selectTxt += " AND ((CAMPST.CAMPAIGNOBJDIVRF = 1 " + Environment.NewLine;
            selectTxt += "   AND A.CUSTOMERCODERF IN ( " + Environment.NewLine;
            selectTxt += "     SELECT CUSTOMERCODERF " + Environment.NewLine;
            //selectTxt += "     FROM CAMPAIGNLINKRF " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "     FROM CAMPAIGNLINKRF WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "     WHERE " + Environment.NewLine;
            selectTxt += "       ENTERPRISECODERF = @FINDENTERPRISECODE1 " + Environment.NewLine;
            SqlParameter paraEnterpriseCode1 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE1", SqlDbType.NChar);
            paraEnterpriseCode1.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);
            selectTxt += "       AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE1 " + Environment.NewLine;
            SqlParameter paraCampaignCode1 = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE1", SqlDbType.Int);
            paraCampaignCode1.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);

            selectTxt += "       AND LOGICALDELETECODERF = 0)) " + Environment.NewLine;
            selectTxt += "    OR (CAMPST.CAMPAIGNOBJDIVRF <> 1)) " + Environment.NewLine;

            #region ORDER BY
            selectTxt += "  ORDER BY " + Environment.NewLine;
            selectTxt += "    A.RESULTSADDUPSECCDRF " + Environment.NewLine;
            selectTxt += "    ,B.SALESCODERF " + Environment.NewLine;
            if (bBLGroupCode == true)
            {
                selectTxt += "    ,B.BLGROUPCODERF " + Environment.NewLine;
            }
            if (bBLGoodsCode == true)
            {
                selectTxt += "    ,B.BLGOODSCODERF " + Environment.NewLine;
            }
            if (bMakerCode == true)
            {
                selectTxt += "   ,B.GOODSMAKERCDRF " + Environment.NewLine;
            }
            if (bGoodsNo == true)
            {
                selectTxt += "   ,B.GOODSNORF " + Environment.NewLine;
            }
            #endregion
            #endregion

            return selectTxt;
        }
        #endregion  // �̔��敪�ʗp����Select����������

        #region [Where���̍쐬]
        /// <summary>
        /// Where���̍쐬
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="CndtnWork"></param>
        /// <returns></returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            string selectTxt = string.Empty;
            selectTxt += "WHERE " + Environment.NewLine;
            // ��ƃR�[�h
            selectTxt += "  A.ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            // �_���폜�敪
            selectTxt += "  AND A.LOGICALDELETECODERF=0 " + Environment.NewLine;
            selectTxt += "  AND B.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            selectTxt += "  AND CAMPMNG.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            // �󒍃X�e�[�^�X
            selectTxt += "  AND A.ACPTANODRSTATUSRF=30 " + Environment.NewLine;

            // �L�����y�[���R�[�h
            selectTxt += "  AND CAMPST.CAMPAIGNCODERF=@FINDCAMPAIGNCODE " + Environment.NewLine;
            SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);

            // ���ьv�㋒�_�R�[�h
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
                    selectTxt += " AND A.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                }
                selectTxt += Environment.NewLine;
            }

            // ���Ӑ�R�[�h
            if (CndtnWork.CustomerCodeSt != 0)
            {
                selectTxt += "  AND A.CUSTOMERCODERF >= @FINDCUSTOMERCODEST " + Environment.NewLine;
                SqlParameter paraCustomerCdSt = sqlCommand.Parameters.Add("@FINDCUSTOMERCODEST", SqlDbType.Int);
                paraCustomerCdSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CustomerCodeSt);
            }

            if (CndtnWork.CustomerCodeEd != 0)
            {
                selectTxt += "  AND A.CUSTOMERCODERF <= @FINDCUSTOMERCODEED " + Environment.NewLine;
                SqlParameter paraCustomerCdEd = sqlCommand.Parameters.Add("@FINDCUSTOMERCODEED", SqlDbType.Int);
                paraCustomerCdEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CustomerCodeEd);
            }

            // �̔��敪�R�[�h
            if (CndtnWork.SalesCodeSt != 0)
            {
                selectTxt += "  AND B.SALESCODERF >= @FINDSALESCODEST " + Environment.NewLine;
                SqlParameter paraSaleCodeSt = sqlCommand.Parameters.Add("@FINDSALESCODEST", SqlDbType.Int);
                paraSaleCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SalesCodeSt);
            }

            if (CndtnWork.SalesCodeEd != 0)
            {
                selectTxt += "  AND B.SALESCODERF <= @FINDSALESCODESTED " + Environment.NewLine;
                SqlParameter paraSaleCodeEd = sqlCommand.Parameters.Add("@FINDSALESCODESTED", SqlDbType.Int);
                paraSaleCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.SalesCodeEd);
            }

            // ����`�[�敪�i���ׁj
            //selectTxt += "  AND (B.SALESSLIPCDDTLRF = 0 OR B.SALESSLIPCDDTLRF = 1) " + Environment.NewLine; // DEL 2011/07/27
            selectTxt += "  AND (B.SALESSLIPCDDTLRF = 0 OR B.SALESSLIPCDDTLRF = 1 OR B.SALESSLIPCDDTLRF = 2) " + Environment.NewLine; // ADD 2011/07/27

            // ----- UPD 2011/07/27 ----- >>>>>
            //// ���㗚���f�[�^�̔�����t
            //if (CndtnWork.ApplyStaDate != 0)
            //{
            //    selectTxt += "  AND A.SALESDATERF >= @FINDSTSALESDATEST " + Environment.NewLine;
            //    SqlParameter paraStSalesDateSt = sqlCommand.Parameters.Add("@FINDSTSALESDATEST", SqlDbType.Int);
            //    paraStSalesDateSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyStaDate);
            //}

            //if (CndtnWork.ApplyEndDate != 0)
            //{
            //    selectTxt += "  AND A.SALESDATERF <= @FINDSTSALESDATEED " + Environment.NewLine;
            //    SqlParameter paraStSalesDateEd = sqlCommand.Parameters.Add("@FINDSTSALESDATEED", SqlDbType.Int);
            //    paraStSalesDateEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyEndDate);
            //}

            //selectTxt += "  AND A.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine;

            //selectTxt += "  AND A.SALESDATERF <= @FINDSALESDTED " + Environment.NewLine;

            //selectTxt += "  AND B.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine;
            //SqlParameter paraSeSalesDtSt = sqlCommand.Parameters.Add("@FINDSALESDTST", SqlDbType.Int);
            //paraSeSalesDtSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AddUpYearMonthDaySt);

            //selectTxt += "  AND B.SALESDATERF <= @FINDSALESDTED " + Environment.NewLine;
            //SqlParameter paraSeSalesDtEd = sqlCommand.Parameters.Add("@FINDSALESDTED", SqlDbType.Int);
            //paraSeSalesDtEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AddUpYearMonthDayEd);

            //// ���㗚�𖾍׃f�[�^�̔�����t
            //if (CndtnWork.ApplyStaDate != 0)
            //{
            //    selectTxt += "  AND B.SALESDATERF >= @FINDDTSALESDATEST " + Environment.NewLine;
            //    SqlParameter paraDtSalesDateSt = sqlCommand.Parameters.Add("@FINDDTSALESDATEST", SqlDbType.Int);
            //    paraDtSalesDateSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyStaDate);
            //}

            //if (CndtnWork.ApplyEndDate != 0)
            //{
            //    selectTxt += "  AND B.SALESDATERF <= @FINDDTSALESDATEED " + Environment.NewLine;
            //    SqlParameter paraDtSalesDateEd = sqlCommand.Parameters.Add("@FINDDTSALESDATEED", SqlDbType.Int);
            //    paraDtSalesDateEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyEndDate);
            //}

            // ���㗚���f�[�^�̔�����t
            if (CndtnWork.ApplyStaDate != 0)
            {
                selectTxt += "  AND ((A.SALESDATERF >= @FINDSTSALESDATEST " + Environment.NewLine;
                SqlParameter paraStSalesDateSt = sqlCommand.Parameters.Add("@FINDSTSALESDATEST", SqlDbType.Int);
                paraStSalesDateSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyStaDate);
            }

            if (CndtnWork.ApplyEndDate != 0)
            {
                selectTxt += "  AND A.SALESDATERF <= @FINDSTSALESDATEED) " + Environment.NewLine;
                SqlParameter paraStSalesDateEd = sqlCommand.Parameters.Add("@FINDSTSALESDATEED", SqlDbType.Int);
                paraStSalesDateEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyEndDate);
            }

            selectTxt += "  OR (A.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine;

            selectTxt += "  AND A.SALESDATERF <= @FINDSALESDTED)) " + Environment.NewLine;

            selectTxt += "  AND ((B.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine;
            SqlParameter paraSeSalesDtSt = sqlCommand.Parameters.Add("@FINDSALESDTST", SqlDbType.Int);
            paraSeSalesDtSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AddUpYearMonthDaySt);

            selectTxt += "  AND B.SALESDATERF <= @FINDSALESDTED) " + Environment.NewLine;
            SqlParameter paraSeSalesDtEd = sqlCommand.Parameters.Add("@FINDSALESDTED", SqlDbType.Int);
            paraSeSalesDtEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AddUpYearMonthDayEd);

            // ���㗚�𖾍׃f�[�^�̔�����t
            if (CndtnWork.ApplyStaDate != 0)
            {
                selectTxt += "  OR (B.SALESDATERF >= @FINDDTSALESDATEST " + Environment.NewLine;
                SqlParameter paraDtSalesDateSt = sqlCommand.Parameters.Add("@FINDDTSALESDATEST", SqlDbType.Int);
                paraDtSalesDateSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyStaDate);
            }

            if (CndtnWork.ApplyEndDate != 0)
            {
                selectTxt += "  AND B.SALESDATERF <= @FINDDTSALESDATEED)) " + Environment.NewLine;
                SqlParameter paraDtSalesDateEd = sqlCommand.Parameters.Add("@FINDDTSALESDATEED", SqlDbType.Int);
                paraDtSalesDateEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyEndDate);
            }
            // ----- UPD 2011/07/27 ----- <<<<<

            return selectTxt;
        }
        #endregion // Where���̍쐬

        #region [CopyToCampaignSalesWorkFromReader���� �ďo]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToCampaignSalesWorkFromReader
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="CndtnWork">CndtnWork</param>
        /// <returns>CopyToCampaignResultWork</returns>
        /// <remarks>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        public CampaignstRsltListResultWork CopyToCampaignSalesWorkFromReader(ref SqlDataReader myReader, CampaignstRsltListPrtWork CndtnWork)
        {
            return this.CopyToCampaignSalesWorkFromReaderProc(ref myReader, CndtnWork);
        }
        #endregion  // CopyToCampaignSalesWorkFromReader���� �ďo

        #region [CopyToCampaignSalesWorkFromReaderProc����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToCampaignSalesWorkFromReaderProc
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="CndtnWork">CndtnWork</param>
        /// <returns>CopyToCampaignResultWork</returns>
        /// <remarks>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private CampaignstRsltListResultWork CopyToCampaignSalesWorkFromReaderProc(ref SqlDataReader myReader, CampaignstRsltListPrtWork CndtnWork)
        {
            CampaignstRsltListResultWork wkCampaignstRsltListResultWork = new CampaignstRsltListResultWork();

            #region �N���X�֊i�[
            wkCampaignstRsltListResultWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCD")); // ���ьv�㋒�_�R�[�h
            wkCampaignstRsltListResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNM1")); // ���_�K�C�h����
            wkCampaignstRsltListResultWork.SalesEmployeeCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODE")).ToString("0000"); // �̔��敪�R�[�h
            wkCampaignstRsltListResultWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAME")); // ����
            wkCampaignstRsltListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD")); // ���i���[�J�[�R�[�h
            wkCampaignstRsltListResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAME")); // ���i���[�J�[����
            wkCampaignstRsltListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNO")); // ���i�ԍ�
            wkCampaignstRsltListResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANA")); // ���i���̃J�i
            wkCampaignstRsltListResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODE")); // BL���i�R�[�h
            wkCampaignstRsltListResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAME")); // BL���i�R�[�h���́i���p�j
            wkCampaignstRsltListResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODE")); // BL�O���[�v�R�[�h
            wkCampaignstRsltListResultWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAME")); // BL�O���[�v�R�[�h�J�i����
            wkCampaignstRsltListResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF")); // �Ώۏo�א�
            wkCampaignstRsltListResultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF")); // ������z�i�Ŕ����j
            wkCampaignstRsltListResultWork.SalesProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GRSPROFITRF")); // �e�����z
            wkCampaignstRsltListResultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF")); // �v����t
            wkCampaignstRsltListResultWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF")); // �L�����y�[���R�[�h
            wkCampaignstRsltListResultWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF")); // �L�����y�[���R�[�h����
            wkCampaignstRsltListResultWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF")); // �K�p�J�n��
            wkCampaignstRsltListResultWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF")); // �K�p�I����
            wkCampaignstRsltListResultWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF")); // ����`�[�敪�i���ׁj // ADD 2011/07/27
            #endregion

            return wkCampaignstRsltListResultWork;
        }
        #endregion // CopyToCampaignSalesWorkFromReaderProc����



        #region [�̔��敪�ʗp�ڕW�ݒ�Select��]
        /// <summary>
        /// �̔��敪�ʗp�ڕW�ݒ�SELECT�� ��������
        /// <summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>�̔��敪�ʗp�ڕW�ݒ�SELECT��</returns>
        /// <br>Note       : �̔��敪�ʗp�ڕW�ݒ�SELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        /// </summary>
        /// </summary>
        public string MakeTargetSelectString(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            return this.MakeTargetSelectStringProc(ref sqlCommand, CndtnWork);
        }
        #endregion // �̔��敪�ʗp�ڕW�ݒ�Select��

        #region [�̔��敪�ʗp�ڕW�ݒ�Select����������]
        /// <summary>
        /// �̔��敪�ʗp�ڕW�ݒ�SELECT�� ��������
        /// <summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>�̔��敪�ʗp�ڕW�ݒ�SELECT��</returns>
        /// <br>Note       : �̔��敪�ʗp�ڕW�ݒ�SELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        /// </summary>
        /// </summary>
        private string MakeTargetSelectStringProc(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            string selectTxt = string.Empty;

            #region SELECT��
            selectTxt += "SELECT " + Environment.NewLine;
            selectTxt += "  CAMPTAR.CAMPAIGNCODERF " + Environment.NewLine;              // �L�����y�[���R�[�h
            selectTxt += "  ,CAMPTAR.TARGETCONTRASTCDRF " + Environment.NewLine;         // �ڕW�Δ�敪
            selectTxt += "  ,CAMPTAR.SECTIONCODERF " + Environment.NewLine;              // ���_�R�[�h
            selectTxt += "  ,CAMPTAR.SALESCODERF " + Environment.NewLine;                // �̔��敪�R�[�h
            selectTxt += "  ,CAMPTAR.BLGROUPCODERF " + Environment.NewLine;              // BL�O���[�v�R�[�h
            selectTxt += "  ,CAMPTAR.BLGOODSCODERF " + Environment.NewLine;              // BL���i�R�[�h
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY1RF " + Environment.NewLine;        // ����ڕW���z1
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY2RF " + Environment.NewLine;        // ����ڕW���z2
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY3RF " + Environment.NewLine;        // ����ڕW���z3
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY4RF " + Environment.NewLine;        // ����ڕW���z4
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY5RF " + Environment.NewLine;        // ����ڕW���z5
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY6RF " + Environment.NewLine;        // ����ڕW���z6
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY7RF " + Environment.NewLine;        // ����ڕW���z7
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY8RF " + Environment.NewLine;        // ����ڕW���z8
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY9RF " + Environment.NewLine;        // ����ڕW���z9
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY10RF " + Environment.NewLine;       // ����ڕW���z10
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY11RF " + Environment.NewLine;       // ����ڕW���z11
            selectTxt += "  ,CAMPTAR.SALESTARGETMONEY12RF " + Environment.NewLine;       // ����ڕW���z12
            selectTxt += "  ,CAMPTAR.MONTHLYSALESTARGETRF " + Environment.NewLine;       // ���㌎�ԖڕW���z
            selectTxt += "  ,CAMPTAR.TERMSALESTARGETRF " + Environment.NewLine;          // ������ԖڕW���z
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT1RF " + Environment.NewLine;       // ����ڕW�e���z1
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT2RF " + Environment.NewLine;       // ����ڕW�e���z2
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT3RF " + Environment.NewLine;       // ����ڕW�e���z3
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT4RF " + Environment.NewLine;       // ����ڕW�e���z4
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT5RF " + Environment.NewLine;       // ����ڕW�e���z5
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT6RF " + Environment.NewLine;       // ����ڕW�e���z6
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT7RF " + Environment.NewLine;       // ����ڕW�e���z7
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT8RF " + Environment.NewLine;       // ����ڕW�e���z8
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT9RF " + Environment.NewLine;       // ����ڕW�e���z9
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT10RF " + Environment.NewLine;      // ����ڕW�e���z10
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT11RF " + Environment.NewLine;      // ����ڕW�e���z11
            selectTxt += "  ,CAMPTAR.SALESTARGETPROFIT12RF " + Environment.NewLine;      // ����ڕW�e���z12
            selectTxt += "  ,CAMPTAR.MONTHLYSALESTARGETPROFITRF " + Environment.NewLine; // ���㌎�ԖڕW�e���z
            selectTxt += "  ,CAMPTAR.TERMSALESTARGETPROFITRF " + Environment.NewLine;    // ������ԖڕW�e���z
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT1RF " + Environment.NewLine;        // ����ڕW����1
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT2RF " + Environment.NewLine;        // ����ڕW����2
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT3RF " + Environment.NewLine;        // ����ڕW����3
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT4RF " + Environment.NewLine;        // ����ڕW����4
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT5RF " + Environment.NewLine;        // ����ڕW����5
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT6RF " + Environment.NewLine;        // ����ڕW����6
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT7RF " + Environment.NewLine;        // ����ڕW����7
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT8RF " + Environment.NewLine;        // ����ڕW����8
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT9RF " + Environment.NewLine;        // ����ڕW����9
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT10RF " + Environment.NewLine;       // ����ڕW����10
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT11RF " + Environment.NewLine;       // ����ڕW����11
            selectTxt += "  ,CAMPTAR.SALESTARGETCOUNT12RF " + Environment.NewLine;       // ����ڕW����12
            selectTxt += "  ,CAMPTAR.MONTHLYSALESTARGETCOUNTRF " + Environment.NewLine;  // ���㌎�ԖڕW����
            selectTxt += "  ,CAMPTAR.TERMSALESTARGETCOUNTRF " + Environment.NewLine;     // ������ԖڕW����
            //selectTxt += "FROM CAMPAIGNTARGETRF AS CAMPTAR " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "FROM CAMPAIGNTARGETRF AS CAMPTAR WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07

            selectTxt += "WHERE " + Environment.NewLine;
            // ��ƃR�[�h
            selectTxt += "  CAMPTAR.ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            // �_���폜�敪
            selectTxt += "  AND CAMPTAR.LOGICALDELETECODERF=0 " + Environment.NewLine;

            // �L�����y�[���R�[�h
            selectTxt += "  AND CAMPTAR.CAMPAIGNCODERF=@FINDCAMPAIGNCODE " + Environment.NewLine;
            SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);

            selectTxt += "  AND ( " + Environment.NewLine;

            selectTxt += "  CAMPTAR.TARGETCONTRASTCDRF=44 " + Environment.NewLine;

            selectTxt += "  OR CAMPTAR.TARGETCONTRASTCDRF=10) " + Environment.NewLine;
            #endregion

            return selectTxt;
        }
        #endregion // �̔��敪�ʗp�ڕW�ݒ�Select����������

        #region [CopyToCampaignTargetWorkFromReader���� �ďo]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToCampaignTargetWorkFromReader
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">paramWork</param>
        /// <returns>CopyToCampaignResultWork</returns>
        /// <remarks>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        public CampaignstRsltListResultWork CopyToCampaignTargetWorkFromReader(ref SqlDataReader myReader, CampaignstRsltListPrtWork paramWork)
        {
            return this.CopyToCampaignTargetWorkFromReaderProc(ref myReader, paramWork);
        }
        #endregion  // CopyToCampaignTargetWorkFromReader���� �ďo

        #region [CopyToCampaignTargetWorkFromReaderProc����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToCampaignTargetWorkFromReaderProc
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">paramWork</param>
        /// <returns>CopyToCampaignResultWork</returns>
        /// <remarks>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private CampaignstRsltListResultWork CopyToCampaignTargetWorkFromReaderProc(ref SqlDataReader myReader, CampaignstRsltListPrtWork paramWork)
        {
            CampaignstRsltListResultWork CampaignTargetWork = new CampaignstRsltListResultWork();

            #region �N���X�֊i�[
            CampaignTargetWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF")); // �L�����y�[���R�[�h
            CampaignTargetWork.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF")); // �ڕW�Δ�敪
            CampaignTargetWork.ManageSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // ���_�R�[�h
            CampaignTargetWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF")); // BL�O���[�v�R�[�h
            CampaignTargetWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL���i�R�[�h
            CampaignTargetWork.EmployeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF")).ToString("0000"); // �̔��敪�R�[�h
            CampaignTargetWork.SalesTargetMoney1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY1RF")); // ����ڕW���z1
            CampaignTargetWork.SalesTargetMoney2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY2RF")); // ����ڕW���z2
            CampaignTargetWork.SalesTargetMoney3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY3RF")); // ����ڕW���z3
            CampaignTargetWork.SalesTargetMoney4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY4RF")); // ����ڕW���z4
            CampaignTargetWork.SalesTargetMoney5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY5RF")); // ����ڕW���z5
            CampaignTargetWork.SalesTargetMoney6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY6RF")); // ����ڕW���z6
            CampaignTargetWork.SalesTargetMoney7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY7RF")); // ����ڕW���z7
            CampaignTargetWork.SalesTargetMoney8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY8RF")); // ����ڕW���z8
            CampaignTargetWork.SalesTargetMoney9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY9RF")); // ����ڕW���z9
            CampaignTargetWork.SalesTargetMoney10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY10RF")); // ����ڕW���z10
            CampaignTargetWork.SalesTargetMoney11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY11RF")); // ����ڕW���z11
            CampaignTargetWork.SalesTargetMoney12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEY12RF")); // ����ڕW���z12
            CampaignTargetWork.MonthlySalesTarget = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETRF")); // ���㌎�ԖڕW���z
            CampaignTargetWork.TermSalesTarget = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTARGETRF")); // ������ԖڕW���z
            CampaignTargetWork.SalesTargetProfit1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT1RF")); // ����ڕW�e���z1
            CampaignTargetWork.SalesTargetProfit2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT2RF")); // ����ڕW�e���z2
            CampaignTargetWork.SalesTargetProfit3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT3RF")); // ����ڕW�e���z3
            CampaignTargetWork.SalesTargetProfit4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT4RF")); // ����ڕW�e���z4
            CampaignTargetWork.SalesTargetProfit5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT5RF")); // ����ڕW�e���z5
            CampaignTargetWork.SalesTargetProfit6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT6RF")); // ����ڕW�e���z6
            CampaignTargetWork.SalesTargetProfit7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT7RF")); // ����ڕW�e���z7
            CampaignTargetWork.SalesTargetProfit8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT8RF")); // ����ڕW�e���z8
            CampaignTargetWork.SalesTargetProfit9 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT9RF")); // ����ڕW�e���z9
            CampaignTargetWork.SalesTargetProfit10 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT10RF")); // ����ڕW�e���z10
            CampaignTargetWork.SalesTargetProfit11 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT11RF")); // ����ڕW�e���z11
            CampaignTargetWork.SalesTargetProfit12 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFIT12RF")); // ����ڕW�e���z12
            CampaignTargetWork.MonthlySalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETPROFITRF")); // ���㌎�ԖڕW�e���z
            CampaignTargetWork.TermSalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TERMSALESTARGETPROFITRF")); // ������ԖڕW�e���z
            CampaignTargetWork.SalesTargetCount1 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT1RF")); // ����ڕW����1
            CampaignTargetWork.SalesTargetCount2 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT2RF")); // ����ڕW����2
            CampaignTargetWork.SalesTargetCount3 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT3RF")); // ����ڕW����3
            CampaignTargetWork.SalesTargetCount4 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT4RF")); // ����ڕW����4
            CampaignTargetWork.SalesTargetCount5 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT5RF")); // ����ڕW����5
            CampaignTargetWork.SalesTargetCount6 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT6RF")); // ����ڕW����6
            CampaignTargetWork.SalesTargetCount7 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT7RF")); // ����ڕW����7
            CampaignTargetWork.SalesTargetCount8 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT8RF")); // ����ڕW����8
            CampaignTargetWork.SalesTargetCount9 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT9RF")); // ����ڕW����9
            CampaignTargetWork.SalesTargetCount10 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT10RF")); // ����ڕW����10
            CampaignTargetWork.SalesTargetCount11 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT11RF")); // ����ڕW����11
            CampaignTargetWork.SalesTargetCount12 = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNT12RF")); // ����ڕW����12
            CampaignTargetWork.MonthlySalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHLYSALESTARGETCOUNTRF")); // ���㌎�ԖڕW����
            CampaignTargetWork.TermSalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TERMSALESTARGETCOUNTRF")); // ������ԖڕW����
            #endregion

            return CampaignTargetWork;
        }
        #endregion // CopyToCampaignTargetWorkFromReaderProc����

    }
}

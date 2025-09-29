//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[�����ѕ\
// �v���O�����T�v   : �L�����y�[�����ѕ\�@�n��ʗp������
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/05/19  �C�����e : �V�K�쐬
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
    class MTtlCampaignArea : MTtlCampaignBase, IMTtlCampaign
    {
        #region [���ʗp�t���O�錾]
        private bool bAddUpSecCode = false;  // ���ьv�㋒�_�R�[�h
        private bool bBelongSecCode = false; // �Ǘ����_�R�[�h
        private bool bCustomerCode = false;  // ���Ӑ�R�[�h
        private bool bBLGroupCode = false;   // BL�O���[�v�R�[�h
        private bool bBLGoodsCode = false;   // BL���i�R�[�h
        private bool bGoodsMakerCd = false;  // ���i���[�J�[�R�[�h
        private bool bGoodsNo = false;       // ���i�ԍ�
        #endregion  //[���ʗp�t���O�錾]

        #region [��v�N�x�e�[�u���������i�擾]
        private FinYearTableGenerator _finYearTableGenerator;

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
        #endregion

        #region [�n��ʗp����Select��]
        /// <summary>
        /// �n��ʗp����SELECT�� ��������
        /// </summary>
        /// <param name="sqlConnection">sqlConnection�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>�n��ʗpSELECT��</returns>
        /// <br>Note       : �n��ʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/05/19</br>

        public string MakeSalesSelectString(ref SqlConnection sqlConnection, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            return this.MakeSalesSelectStringProc(ref sqlConnection, ref sqlCommand, CndtnWork);
        }
        #endregion  // �n��ʗp����Select��

        #region [�n��ʗp����Select����������]
        /// <summary>
        /// �n��ʗp����SELECT�� ��������
        /// </summary>
        /// <param name="sqlConnection">sqlConnection�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>�n��ʗp����SELECT��</returns>
        /// <br>Note       : �n��ʗp����SELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/05/19</br>
        private string MakeSalesSelectStringProc(ref SqlConnection sqlConnection, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            #region [���ʗp�t���O]
            //���ьv�㋒�_�R�[�h
            if (CndtnWork.OutputSort != 3)
            {
                bAddUpSecCode = true;
            }

            // �Ǘ����_�R�[�h
            if (CndtnWork.OutputSort == 3)
            {
                bBelongSecCode = true;
            }

            // ���Ӑ�R�[�h
            if (CndtnWork.OutputSort == 1)
            {
                bCustomerCode = true;
            }

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

            // ���i���[�J�[�R�[�h
            if (CndtnWork.PrintType != 1)
            {
                bGoodsMakerCd = true;
            }

            // ���i�ԍ�
            if (CndtnWork.Detail == 0)
            {
                bGoodsNo = true;
            }
            #endregion

            string selectTxt = string.Empty;

            if (CndtnWork.PrintType == 1)
            {
                _finYearTableGenerator = this.GetFinYearTableGenerator(CndtnWork.EnterpriseCode, ref sqlConnection);
            }

            #region SELECT��
            selectTxt += "SELECT DISTINCT " + Environment.NewLine;
            selectTxt += "  B.SALESSLIPNUMRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESROWNORF " + Environment.NewLine;
            selectTxt += "  ,B.SALESSLIPCDDTLRF " + Environment.NewLine; // ADD 2011/07/27
            selectTxt += "  ,A.RESULTSADDUPSECCDRF " + Environment.NewLine;
            selectTxt += "  ,C.SECTIONGUIDESNMRF AS SECTIONGUIDESNMRF1" + Environment.NewLine;
            selectTxt += "  ,A.CUSTOMERCODERF " + Environment.NewLine;
            selectTxt += "  ,E.CUSTOMERSNMRF " + Environment.NewLine;
            selectTxt += "  ,A.SALESDATERF " + Environment.NewLine;
            selectTxt += "  ,E.MNGSECTIONCODERF " + Environment.NewLine;
            selectTxt += "  ,G.SECTIONGUIDESNMRF AS SECTIONGUIDESNMRF2" + Environment.NewLine;
            selectTxt += "  ,A.SALESAREACODERF " + Environment.NewLine;
            selectTxt += "  ,R.GUIDENAMERF " + Environment.NewLine;
            selectTxt += "  ,B.GOODSMAKERCDRF " + Environment.NewLine;
            selectTxt += "  ,B.GOODSNORF " + Environment.NewLine;
            selectTxt += "  ,B.GOODSNAMEKANARF " + Environment.NewLine;
            selectTxt += "  ,B.BLGOODSCODERF " + Environment.NewLine;
            selectTxt += "  ,D.BLGOODSHALFNAMERF " + Environment.NewLine;
            selectTxt += "  ,B.BLGROUPCODERF " + Environment.NewLine;
            selectTxt += "  ,F.BLGROUPKANANAMERF " + Environment.NewLine;
            selectTxt += "  ,B.SHIPMENTCNTRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESMONEYTAXEXCRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESMONEYTAXEXCRF - B.COSTRF AS GRSPROFITRF " + Environment.NewLine;
            selectTxt += "  ,J.CAMPAIGNCODERF " + Environment.NewLine;
            selectTxt += "  ,J.CAMPAIGNNAMERF " + Environment.NewLine;
            selectTxt += "  ,H.MAKERNAMERF " + Environment.NewLine;
            selectTxt += "  ,J.APPLYSTADATERF " + Environment.NewLine;
            selectTxt += "  ,J.APPLYENDDATERF " + Environment.NewLine;

            selectTxt += "FROM SALESHISTORYRF AS A WITH (READUNCOMMITTED) " + Environment.NewLine;
            selectTxt += "LEFT JOIN SALESHISTDTLRF AS B WITH (READUNCOMMITTED) " + Environment.NewLine;
            selectTxt += "ON A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF " + Environment.NewLine;
            selectTxt += "AND A.SALESSLIPNUMRF = B.SALESSLIPNUMRF " + Environment.NewLine;

            //selectTxt += "LEFT JOIN CUSTOMERRF AS E " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CUSTOMERRF AS E WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON E.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND E.CUSTOMERCODERF = A.CUSTOMERCODERF " + Environment.NewLine;
            selectTxt += "AND E.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //selectTxt += "LEFT JOIN SECINFOSETRF AS C " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN SECINFOSETRF AS C WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON A.ENTERPRISECODERF = C.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND C.SECTIONCODERF = A.RESULTSADDUPSECCDRF " + Environment.NewLine;
            selectTxt += "AND C.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //selectTxt += "LEFT JOIN BLGOODSCDURF AS D " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN BLGOODSCDURF AS D WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON D.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND D.BLGOODSCODERF = B.BLGOODSCODERF " + Environment.NewLine;
            selectTxt += "AND D.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //selectTxt += "LEFT JOIN BLGROUPURF AS F " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN BLGROUPURF AS F WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON F.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND F.BLGROUPCODERF = B.BLGROUPCODERF " + Environment.NewLine;
            selectTxt += "AND F.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //selectTxt += "LEFT JOIN SECINFOSETRF AS G " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN SECINFOSETRF AS G WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON G.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND G.SECTIONCODERF = E.MNGSECTIONCODERF " + Environment.NewLine;
            selectTxt += "AND G.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            selectTxt += "LEFT JOIN MAKERURF AS H " + Environment.NewLine;
            selectTxt += "ON H.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND H.GOODSMAKERCDRF = B.GOODSMAKERCDRF " + Environment.NewLine;
            selectTxt += "AND H.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //selectTxt += "LEFT JOIN USERGDBDURF AS R " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN USERGDBDURF AS R WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON R.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND R.GUIDECODERF = A.SALESAREACODERF " + Environment.NewLine;
            selectTxt += "AND R.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //selectTxt += "LEFT JOIN CAMPAIGNSTRF AS J " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CAMPAIGNSTRF AS J WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON J.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            // ----- ADD 2012/04/09 chenyd for Redmine#29314 ----- >>>>>
            // �L�����y�[���R�[�h
            selectTxt += "AND J.CAMPAIGNCODERF = @FINDCAMPAIGNCODE1  " + Environment.NewLine;
            SqlParameter paraCampaignCode1 = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE1", SqlDbType.Int);
            paraCampaignCode1.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);
            // ----- ADD 2012/04/09 chenyd for Redmine#29314 ----- <<<<<
            //selectTxt += "LEFT JOIN CAMPAIGNMNGRF AS L " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CAMPAIGNMNGRF AS L WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "ON L.ENTERPRISECODERF = A.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += "AND L.CAMPAIGNCODERF = J.CAMPAIGNCODERF " + Environment.NewLine;            

            #region WHERE
            selectTxt += MakeWhereString(ref sqlCommand, CndtnWork) + Environment.NewLine;
            #endregion

            selectTxt += " AND ((J.CAMPAIGNOBJDIVRF = 1 " + Environment.NewLine;
            selectTxt += " AND A.CUSTOMERCODERF IN(  " + Environment.NewLine;
            selectTxt += " SELECT  " + Environment.NewLine;
            selectTxt += " CUSTOMERCODERF " + Environment.NewLine;
            selectTxt += " FROM " + Environment.NewLine;
            //selectTxt += " CAMPAIGNLINKRF " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += " CAMPAIGNLINKRF WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += " WHERE " + Environment.NewLine;

            selectTxt += " ENTERPRISECODERF = @FINDENTERPRISECODE3 " + Environment.NewLine;
            SqlParameter paraEnterpriseCode3 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE3", SqlDbType.NChar);
            paraEnterpriseCode3.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            // �L�����y�[���R�[�h
            selectTxt += "  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE3 " + Environment.NewLine;
            SqlParameter paraCampaignCd3 = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE3", SqlDbType.Int);
            paraCampaignCd3.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);

            selectTxt += " AND LOGICALDELETECODERF = 0)) " + Environment.NewLine;
            selectTxt += " OR (J.CAMPAIGNOBJDIVRF <> 1)) " + Environment.NewLine;

            selectTxt += " AND ((L.CAMPAIGNSETTINGKINDRF = 1 AND L.GOODSNORF = B.GOODSNORF AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF)" + Environment.NewLine;
            selectTxt += "   OR (L.CAMPAIGNSETTINGKINDRF = 2 AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF AND L.BLGOODSCODERF = B.BLGOODSCODERF)  " + Environment.NewLine;
            selectTxt += "   OR (L.CAMPAIGNSETTINGKINDRF = 3 AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF AND L.BLGROUPCODERF = B.BLGROUPCODERF)  " + Environment.NewLine;
            selectTxt += "   OR (L.CAMPAIGNSETTINGKINDRF = 4 AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF)  " + Environment.NewLine;
            selectTxt += "   OR (L.CAMPAIGNSETTINGKINDRF = 5 AND L.BLGOODSCODERF = B.BLGOODSCODERF)  " + Environment.NewLine;
            selectTxt += "   OR (L.CAMPAIGNSETTINGKINDRF = 6 AND L.SALESCODERF = B.SALESCODERF)  " + Environment.NewLine;
            selectTxt += " ) " + Environment.NewLine;

            // ----- ADD 2011/07/11 ----->>>>>
            if (CndtnWork.OutputSort == 3)
            {
                selectTxt += " AND ((L.SECTIONCODERF <> '00' AND E.MNGSECTIONCODERF = L.SECTIONCODERF) OR (L.SECTIONCODERF = '00')) " + Environment.NewLine;
            }
            else
            {
                selectTxt += " AND ((L.SECTIONCODERF <> '00' AND A.RESULTSADDUPSECCDRF = L.SECTIONCODERF) OR (L.SECTIONCODERF = '00')) " + Environment.NewLine;
            }
            // ----- ADD 2011/07/11 -----<<<<<

            #region ORDER BY
            selectTxt += "  ORDER BY " + Environment.NewLine;
            if (bBelongSecCode == true)
            {
                selectTxt += "    E.MNGSECTIONCODERF, " + Environment.NewLine;
            }
            if (CndtnWork.OutputSort == 2)
            {
                selectTxt += "    A.SALESAREACODERF " + Environment.NewLine;
                selectTxt += "    ,A.RESULTSADDUPSECCDRF " + Environment.NewLine;
            }
            else
            {
                if (bAddUpSecCode == true)
                {
                    selectTxt += "    A.RESULTSADDUPSECCDRF, " + Environment.NewLine;
                }
                selectTxt += "    A.SALESAREACODERF " + Environment.NewLine;
            }
            if (bCustomerCode == true)
            {
                selectTxt += "    ,A.CUSTOMERCODERF " + Environment.NewLine;
            }
            if (bBLGroupCode == true)
            {
                selectTxt += "    ,B.BLGROUPCODERF " + Environment.NewLine;
            }
            if (bBLGoodsCode == true)
            {
                selectTxt += "    ,B.BLGOODSCODERF " + Environment.NewLine;
            }
            if (bGoodsMakerCd == true)
            {
                selectTxt += "    ,B.GOODSMAKERCDRF " + Environment.NewLine;
            }
            if (bGoodsNo == true)
            {
                selectTxt += "    ,B.GOODSNORF " + Environment.NewLine;
            }
            #endregion
            #endregion

            return selectTxt;
        }
        #endregion  // �S���ҕʗp����Select����������

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
            #region WHERE
            // ��ƃR�[�h
            selectTxt += "WHERE " + Environment.NewLine;
            selectTxt += "  A.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            // �_���폜�敪
            selectTxt += "  AND A.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            selectTxt += "  AND B.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            selectTxt += "  AND L.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            // �󒍃X�e�[�^�X
            selectTxt += "  AND A.ACPTANODRSTATUSRF = 30 " + Environment.NewLine;

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

            // �n��R�[�h
            if (CndtnWork.AreaCodeSt != 0)
            {
                selectTxt += "  AND A.SALESAREACODERF >= @FINDEAREACDST " + Environment.NewLine;
                SqlParameter paraAreaCdSt = sqlCommand.Parameters.Add("@FINDEAREACDST", SqlDbType.Int);
                paraAreaCdSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.AreaCodeSt);
            }

            if (CndtnWork.AreaCodeEd != 0)
            {
                selectTxt += "  AND A.SALESAREACODERF <= @FINDEAREACDED " + Environment.NewLine;
                SqlParameter paraAreaCdEd = sqlCommand.Parameters.Add("@FINDEAREACDED", SqlDbType.Int);
                paraAreaCdEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.AreaCodeEd);
            }

            // �L�����y�[���R�[�h
            selectTxt += "  AND J.CAMPAIGNCODERF = @FINDCAMPAIGNCD " + Environment.NewLine;
            SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCD", SqlDbType.Int);
            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);

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

            // �K�C�h�敪
            selectTxt += "  AND R.USERGUIDEDIVCDRF = 21 " + Environment.NewLine;

            #endregion
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
        /// <br>Programmer : �����Y</br>
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
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private CampaignstRsltListResultWork CopyToCampaignSalesWorkFromReaderProc(ref SqlDataReader myReader, CampaignstRsltListPrtWork CndtnWork)
        {
            CampaignstRsltListResultWork wkCampaignstRsltListResultWork = new CampaignstRsltListResultWork();

            #region �N���X�֊i�[
            wkCampaignstRsltListResultWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF")); // ���ьv�㋒�_�R�[�h
            wkCampaignstRsltListResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF1")); // ���_�K�C�h����
            wkCampaignstRsltListResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")); // ���Ӑ�R�[�h
            wkCampaignstRsltListResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF")); // ���Ӑ旪��
            wkCampaignstRsltListResultWork.ManageSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF")); // �Ǘ����_�R�[�h
            wkCampaignstRsltListResultWork.ManageSectionSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF2")); // ���_�K�C�h����
            wkCampaignstRsltListResultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF")); // �̔��G���A�R�[�h
            wkCampaignstRsltListResultWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF")); // ���[�U�[�K�C�h����
            wkCampaignstRsltListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")); // ���i���[�J�[�R�[�h
            wkCampaignstRsltListResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF")); // ���i���[�J�[����
            wkCampaignstRsltListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF")); // ���i�ԍ�
            wkCampaignstRsltListResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF")); // ���i���̃J�i
            wkCampaignstRsltListResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL���i�R�[�h
            wkCampaignstRsltListResultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF")); // BL���i�R�[�h���́i���p�j
            wkCampaignstRsltListResultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF")); // BL�O���[�v�R�[�h
            wkCampaignstRsltListResultWork.BLGroupKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF")); // BL�O���[�v�R�[�h�J�i����
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



        #region [�n��ʗp�ڕW�ݒ�Select��]
        /// <summary>
        /// �n��ʗp�ڕW�ݒ�SELECT�� ��������
        /// <summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>�n��ʗp�ڕW�ݒ�SELECT��</returns>
        /// <br>Note       : �n��ʗp�ڕW�ݒ�SELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/05/19</br>
        /// </summary>
        /// </summary>
        public string MakeTargetSelectString(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            return this.MakeTargetSelectStringProc(ref sqlCommand, CndtnWork);
        }
        #endregion // �n��ʗp�ڕW�ݒ�Select��

        #region [�n��ʗp�ڕW�ݒ�Select����������]
        /// <summary>
        /// �n��ʗp�ڕW�ݒ�SELECT�� ��������
        /// <summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>�n��ʗp�ڕW�ݒ�SELECT��</returns>
        /// <br>Note       : �n��ʗp�ڕW�ݒ�SELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/05/19</br>
        /// </summary>
        /// </summary>
        private string MakeTargetSelectStringProc(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            string selectTxt = string.Empty;

            #region SELECT��
            selectTxt += "SELECT " + Environment.NewLine;
            selectTxt += "  CAMPTAR.CAMPAIGNCODERF " + Environment.NewLine;             // �L�����y�[���R�[�h
            selectTxt += "  ,CAMPTAR.TARGETCONTRASTCDRF " + Environment.NewLine;         // �ڕW�Δ�敪
            selectTxt += "  ,CAMPTAR.SECTIONCODERF " + Environment.NewLine;              // ���_�R�[�h
            selectTxt += "  ,CAMPTAR.CUSTOMERCODERF " + Environment.NewLine;             // ���Ӑ�R�[�h
            selectTxt += "  ,CAMPTAR.SALESAREACODERF " + Environment.NewLine;             // �̔��G���A�R�[�h
            selectTxt += "  ,CAMPTAR.BLGROUPCODERF " + Environment.NewLine;             // BL�O���[�v�R�[�h
            selectTxt += "  ,CAMPTAR.BLGOODSCODERF " + Environment.NewLine;             // BL���i�R�[�h
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
            selectTxt += "  ,CAMPTAR.MONTHLYSALESTARGETPROFITRF " + Environment.NewLine;       // ���㌎�ԖڕW�e���z
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

            selectTxt += "  (CAMPTAR.TARGETCONTRASTCDRF=32) " + Environment.NewLine;

            selectTxt += "  OR CAMPTAR.TARGETCONTRASTCDRF=10) " + Environment.NewLine;
            #endregion

            return selectTxt;
        }
        #endregion // �n��ʗp�ڕW�ݒ�Select����������

        #region [CopyToCampaignTargetWorkFromReader���� �ďo]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToCampaignTargetWorkFromReader
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">paramWork</param>
        /// <returns>CopyToCampaignResultWork</returns>
        /// <remarks>
        /// <br>Programmer : �����Y</br>
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
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private CampaignstRsltListResultWork CopyToCampaignTargetWorkFromReaderProc(ref SqlDataReader myReader, CampaignstRsltListPrtWork paramWork)
        {
            CampaignstRsltListResultWork CampaignTargetWork = new CampaignstRsltListResultWork();

            #region �N���X�֊i�[
            CampaignTargetWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF")); // �L�����y�[���R�[�h
            CampaignTargetWork.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF")); // �ڕW�Δ�敪
            CampaignTargetWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // ���_�R�[�h
            CampaignTargetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")); // ���Ӑ�R�[�h
            CampaignTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF")); // �̔��G���A�R�[�h
            CampaignTargetWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF")); // BL�O���[�v�R�[�h
            CampaignTargetWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL���i�R�[�h
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

        #region Private Method
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
        #endregion
    }
}

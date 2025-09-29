//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[�����ѕ\
// �v���O�����T�v   : �L�����y�[�����ѕ\�@���i�ʗp������
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
// �� �� ��  2011/07/11  �C�����e : Redmine �d�l�ύX #22860,#22915 �̑Ή�
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
    class MTtlCampaignGoods : MTtlCampaignBase, IMTtlCampaign
    {
        #region [���ʗp�t���O�錾]
        private bool bBLGroupCode = false;   // BL�O���[�v�R�[�h
        private bool bBLGoodsCode = false;   // BL���i�R�[�h
        private bool bGoodsNo = false;       // ���i�ԍ�
        private bool bGoodsMakerCd = false;  // ���i���[�J�[�R�[�h
        private FinYearTableGenerator _finYearTableGenerator = null;
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

        #region [���i�ʗp����Select��]
        /// <summary>
        /// ���i�ʗp����SELECT�� ��������
        /// </summary>
        /// <param name="sqlConnection">SqlConnection�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>���i�ʗpSELECT��</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʗpSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        public string MakeSalesSelectString(ref SqlConnection sqlConnection, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            return this.MakeSalesSelectStringProc(ref sqlConnection, ref sqlCommand, CndtnWork);
        }
        #endregion  // ���i�ʗp����Select��

        #region [���i�ʗp����Select����������]
        /// <summary>
        /// ���i�ʗp����SELECT�� ��������
        /// </summary>
        /// <param name="sqlConnection">SqlConnection�I�u�W�F�N�g</param>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>���i�ʗp����SELECT��</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʗp����SELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private string MakeSalesSelectStringProc(ref SqlConnection sqlConnection, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            // ����^�C�v���u���ԁv�̏ꍇ
            if (CndtnWork.PrintType == 1)
            {
                // ��v�N�x�e�[�u���������i�擾
                _finYearTableGenerator = this.GetFinYearTableGenerator(CndtnWork.EnterpriseCode, ref sqlConnection);
            }

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

            // ���i���[�J�[�R�[�h
            if (CndtnWork.PrintType != 1)
            {
                bGoodsMakerCd = true;
            }
            #endregion

            string selectTxt = string.Empty;

            #region SELECT��
            selectTxt += "SELECT DISTINCT " + Environment.NewLine;
            selectTxt += "  B.SALESSLIPNUMRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESROWNORF " + Environment.NewLine;
            selectTxt += "  ,B.SALESSLIPCDDTLRF " + Environment.NewLine; // ADD 2011/07/27
            selectTxt += "  ,A.RESULTSADDUPSECCDRF " + Environment.NewLine;              // ���ьv�㋒�_�R�[�h
            selectTxt += "  ,A.CUSTOMERCODERF " + Environment.NewLine;              // ���Ӑ�R�[�h
            selectTxt += "  ,A.SALESDATERF " + Environment.NewLine;
            selectTxt += "  ,B.GOODSMAKERCDRF " + Environment.NewLine;             // ���i���[�J�[�R�[�h
            selectTxt += "  ,B.GOODSNORF " + Environment.NewLine;              // ���i�ԍ�
            selectTxt += "  ,B.GOODSNAMEKANARF " + Environment.NewLine;              // ���i���̃J�i
            selectTxt += "  ,B.BLGOODSCODERF " + Environment.NewLine;        // BL���i�R�[�h
            selectTxt += "  ,B.BLGROUPCODERF " + Environment.NewLine;        // BL�O���[�v�R�[�h
            selectTxt += "  ,B.SHIPMENTCNTRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESMONEYTAXEXCRF " + Environment.NewLine;
            selectTxt += "  ,B.SALESMONEYTAXEXCRF - B.COSTRF AS GRSPROFITRF " + Environment.NewLine;             
            selectTxt += "  ,C.SECTIONGUIDESNMRF AS SECTIONGUIDESNMRF1 " + Environment.NewLine;        // ���_�K�C�h����
            selectTxt += "  ,D.CUSTOMERSNMRF " + Environment.NewLine;       // ���Ӑ旪��
            selectTxt += "  ,G.BLGOODSHALFNAMERF " + Environment.NewLine;          // BL���i�R�[�h���́i���p�j
            selectTxt += "  ,H.BLGROUPKANANAMERF " + Environment.NewLine;       // BL�O���[�v�R�[�h�J�i����
            selectTxt += "  ,I.MAKERNAMERF " + Environment.NewLine;       // Ұ������
            selectTxt += "  ,J.CAMPAIGNCODERF " + Environment.NewLine;       // �L�����y�[���R�[�h
            selectTxt += "  ,J.CAMPAIGNNAMERF " + Environment.NewLine;       // �L�����y�[���R�[�h����
            selectTxt += "  ,J.CAMPEXECSECCODERF " + Environment.NewLine;       // �L�����y�[�����{���_�R�[�h
            selectTxt += "  ,J.CAMPAIGNOBJDIVRF " + Environment.NewLine;       // �L�����y�[���Ώۋ敪
            selectTxt += "  ,J.APPLYSTADATERF " + Environment.NewLine;       // �K�p�J�n��
            selectTxt += "  ,J.APPLYENDDATERF " + Environment.NewLine;       // �K�p�I����
            //selectTxt += "  ,L.SECTIONCODERF " + Environment.NewLine;      // �L�����y�[�����{���_�R�[�h�@// DEL 2011/07/05
            // ���㗚���f�[�^
            selectTxt += "FROM SALESHISTORYRF AS A WITH (READUNCOMMITTED) " + Environment.NewLine;
            
            #region ���㗚�𖾍׃f�[�^
            // ���㗚�𖾍׃f�[�^
            selectTxt += "LEFT JOIN SALESHISTDTLRF AS B WITH (READUNCOMMITTED) " + Environment.NewLine;
            // ��ƃR�[�h
            selectTxt += "ON A.ENTERPRISECODERF = B.ENTERPRISECODERF " + Environment.NewLine;
            // �󒍃X�e�[�^�X
            selectTxt += "AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF " + Environment.NewLine;
            // ����`�[�ԍ�
            selectTxt += "AND A.SALESSLIPNUMRF = B.SALESSLIPNUMRF " + Environment.NewLine;
            // �_���폜�敪
            selectTxt += "AND A.LOGICALDELETECODERF = B.LOGICALDELETECODERF " + Environment.NewLine;
            #endregion

            #region ���_���ݒ�}�X�^
            // ���_���ݒ�}�X�^
            //selectTxt += "LEFT JOIN  SECINFOSETRF AS C " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN  SECINFOSETRF AS C WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            // ��ƃR�[�h
            selectTxt += "ON A.ENTERPRISECODERF = C.ENTERPRISECODERF " + Environment.NewLine;
            // ���_�R�[�h
            selectTxt += "AND A.RESULTSADDUPSECCDRF = C.SECTIONCODERF " + Environment.NewLine;
            // �_���폜�敪
            selectTxt += "AND A.LOGICALDELETECODERF = C.LOGICALDELETECODERF " + Environment.NewLine;
            #endregion

            #region ���Ӑ�}�X�^
            // ���Ӑ�}�X�^
            //selectTxt += "LEFT JOIN CUSTOMERRF AS D " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CUSTOMERRF AS D WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            // ��ƃR�[�h
            selectTxt += "ON A.ENTERPRISECODERF = D.ENTERPRISECODERF " + Environment.NewLine;
            // ���Ӑ�R�[�h
            selectTxt += "AND A.CUSTOMERCODERF = D.CUSTOMERCODERF " + Environment.NewLine;
            // �_���폜�敪
            selectTxt += "AND A.LOGICALDELETECODERF = D.LOGICALDELETECODERF " + Environment.NewLine;
            #endregion

            #region �a�k���i�R�[�h�}�X�^(���[�U�[)
            // �a�k���i�R�[�h�}�X�^(���[�U�[)
            //selectTxt += "LEFT JOIN BLGOODSCDURF AS G " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN BLGOODSCDURF AS G WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            // ��ƃR�[�h
            selectTxt += "ON B.ENTERPRISECODERF = G.ENTERPRISECODERF " + Environment.NewLine;
            // BL���i�R�[�h
            selectTxt += "AND B.BLGOODSCODERF = G.BLGOODSCODERF " + Environment.NewLine;
            // �_���폜�敪
            selectTxt += "AND B.LOGICALDELETECODERF = G.LOGICALDELETECODERF " + Environment.NewLine;
            #endregion

            #region BL�O���[�v�}�X�^�i���[�U�[�o�^���j
            // BL�O���[�v�}�X�^�i���[�U�[�o�^���j
            //selectTxt += "LEFT JOIN BLGROUPURF AS H " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN BLGROUPURF AS H WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            // ��ƃR�[�h
            selectTxt += "ON B.ENTERPRISECODERF = H.ENTERPRISECODERF " + Environment.NewLine;
            // BL�O���[�v�R�[�h
            selectTxt += "AND B.BLGROUPCODERF = H.BLGROUPCODERF " + Environment.NewLine;
            // �_���폜�敪
            selectTxt += "AND B.LOGICALDELETECODERF = H.LOGICALDELETECODERF " + Environment.NewLine;
            #endregion

            #region ���[�J�[�}�X�^
            // ���[�J�[�}�X�^
            //selectTxt += "LEFT JOIN MAKERURF AS I " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN MAKERURF AS I WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            // ��ƃR�[�h
            selectTxt += "ON B.ENTERPRISECODERF = I.ENTERPRISECODERF " + Environment.NewLine;
            // ���i���[�J�[�R�[�h
            selectTxt += "AND B.GOODSMAKERCDRF = I.GOODSMAKERCDRF " + Environment.NewLine;
            // �_���폜�敪
            selectTxt += "AND B.LOGICALDELETECODERF = I.LOGICALDELETECODERF " + Environment.NewLine;
            #endregion

            #region �L�����y�[���ݒ�}�X�^
            // �L�����y�[���ݒ�}�X�^
            //selectTxt += "LEFT JOIN CAMPAIGNSTRF AS J " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CAMPAIGNSTRF AS J WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            // ��ƃR�[�h
            selectTxt += "ON A.ENTERPRISECODERF = J.ENTERPRISECODERF " + Environment.NewLine;
            // �_���폜�敪
            selectTxt += "AND A.LOGICALDELETECODERF = J.LOGICALDELETECODERF " + Environment.NewLine;
            // ----- ADD 2012/04/09 chenyd for Redmine#29314 ----- >>>>>
            // �L�����y�[���R�[�h
            selectTxt += "AND J.CAMPAIGNCODERF = @FINDCAMPAIGNCODE1  " + Environment.NewLine;
            SqlParameter paraCampaignCode1 = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE1", SqlDbType.Int);
            paraCampaignCode1.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);
            // ----- ADD 2012/04/09 chenyd for Redmine#29314 ----- <<<<<
            #endregion

            #region �L�����y�[���Ǘ��}�X�^
            //�L�����y�[���Ǘ��}�X�^ 
            //selectTxt += "LEFT JOIN CAMPAIGNMNGRF AS L " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "LEFT JOIN CAMPAIGNMNGRF AS L WITH (READUNCOMMITTED) " + Environment.NewLine; // ADD 2011/07/07
            // ��ƃR�[�h
            selectTxt += "ON J.ENTERPRISECODERF = L.ENTERPRISECODERF " + Environment.NewLine;
            // �L�����y�[���R�[�h 
            selectTxt += "AND J.CAMPAIGNCODERF = L.CAMPAIGNCODERF " + Environment.NewLine;
            // �_���폜�敪
            selectTxt += "AND J.LOGICALDELETECODERF = L.LOGICALDELETECODERF " + Environment.NewLine;
            #endregion

            // Where��
            selectTxt += MakeWhereString(ref sqlCommand, CndtnWork);

            #region ORDER BY
            selectTxt += "  ORDER BY " + Environment.NewLine;

            selectTxt += "    A.RESULTSADDUPSECCDRF " + Environment.NewLine;
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
        #endregion  // ���i�ʗp����Select����������

        #region [GroupBy�̍쐬]
        /// <summary>
        /// GroupBy�̍쐬
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="CndtnWork"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���i�ʗp����GroupBy�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private string GroupByString(int flag, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            string groupByTxt = string.Empty;

            string tableNm = string.Empty;
            if (flag == 0)
            {
                tableNm = "SUB_C";
            }
            else
            {
                tableNm = "SUB_D";
            }

            #region GroupBy��
            groupByTxt += "  GROUP BY " + Environment.NewLine;
            // ���ьv�㋒�_�R�[�h
            groupByTxt += tableNm + ".RESULTSADDUPSECCDRF " + Environment.NewLine;

            if (bBLGroupCode == true)
            {
                // �O���[�v�R�[�h
                groupByTxt += "," + tableNm + ".BLGROUPCODERF " + Environment.NewLine;
            }
            if (bBLGoodsCode == true)
            {
                // �a�k�R�[�h
                groupByTxt += "," + tableNm + ".BLGOODSCODERF " + Environment.NewLine;
            }
            if (bGoodsMakerCd == true)
            {
                // ���i���[�J�[�R�[�h
                groupByTxt += "," + tableNm + ".GOODSMAKERCDRF " + Environment.NewLine;
            }
            if (bGoodsNo == true)
            {
                // ���i�ԍ�
                groupByTxt += "," + tableNm + ".GOODSNORF" + Environment.NewLine;
            }
            #endregion GroupBy��

            return groupByTxt;
        }
        #endregion // GroupBy�̍쐬

        #region [���������̍쐬]
        /// <summary>
        /// ���������̍쐬
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="CndtnWork"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���i�ʗp���㌋���������쐬���Ė߂��܂�</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private string JoinOnString(int flag, ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            string joinOnTxt = string.Empty;

            string tableNm = string.Empty;
            if (flag == 0)
            {
                tableNm = "O";
            }
            else
            {
                tableNm = "P";
            }

            #region ��������
            // ���_�R�[�h
            joinOnTxt += " ON A.RESULTSADDUPSECCDRF = " + tableNm + ".RESULTSADDUPSECCDRF " + Environment.NewLine;
            if (bBLGroupCode == true)
            {
                // �O���[�v�R�[�h
                joinOnTxt += " AND B.BLGROUPCODERF = " + tableNm + ".BLGROUPCODERF " + Environment.NewLine;
            }
            if (bBLGoodsCode == true)
            {
                // BL�R�[�h
                joinOnTxt += " AND B.BLGOODSCODERF = " + tableNm + ".BLGOODSCODERF " + Environment.NewLine;
            }
            if (bGoodsMakerCd == true)
            {
                // ���i���[�J�[�R�[�h
                joinOnTxt += " AND B.GOODSMAKERCDRF = " + tableNm + ".GOODSMAKERCDRF " + Environment.NewLine;
            }
            if (bGoodsNo == true)
            {
                // ���i�ԍ�
                joinOnTxt += " AND B.GOODSNORF = " + tableNm + ".GOODSNORF " + Environment.NewLine;
            }
            #endregion ��������

            return joinOnTxt;
        }
        #endregion // ���������̍쐬

        #region [Where���̍쐬]
        /// <summary>
        /// Where���̍쐬
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="CndtnWork"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���i�ʗp���㌋���������쐬���Ė߂��܂�</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            string selectTxt = string.Empty;

            #region Where��
            selectTxt += "WHERE " + Environment.NewLine;
            // ��ƃR�[�h
            selectTxt += "A.ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(CndtnWork.EnterpriseCode);

            // �_���폜�敪
            selectTxt += "  AND A.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            // �󒍃X�e�[�^�X = 30(����)
            selectTxt += "  AND A.ACPTANODRSTATUSRF = 30 " + Environment.NewLine;
            // ���_�R�[�h
            if (CndtnWork.SectionCodes != null)
            {
                string strSec = string.Empty;
                foreach (string secCode in CndtnWork.SectionCodes)
                {
                    if (!strSec.Equals(string.Empty))
                    {
                        strSec += ",";
                    }
                    strSec += "'" + secCode + "'";
                }

                if (!strSec.Equals(string.Empty))
                {
                    selectTxt += "  AND A.RESULTSADDUPSECCDRF IN (" + strSec + ")" + Environment.NewLine;
                }
            }
            // ���㗚���f�[�^�̔�����t
            

            // ���㗚�𖾍׃f�[�^�̔�����t
            
            // ������t(�L�����y�[���K�p��)
            // ----- UPD 2011/07/27 ----- >>>>>
            //if (CndtnWork.ApplyStaDate != 0)
            //{
            //    selectTxt += "  AND A.SALESDATERF >=@FINDSTAPPLYDATERF " + Environment.NewLine;
            //}
            //if (CndtnWork.ApplyEndDate != 0)
            //{
            //    selectTxt += "  AND A.SALESDATERF <=@FINDEDAPPLYDATERF " + Environment.NewLine;
            //}

            //selectTxt += "  AND A.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine;

            //selectTxt += "  AND A.SALESDATERF <= @FINDSALESDTED " + Environment.NewLine;

            if (CndtnWork.ApplyStaDate != 0)
            {
                selectTxt += "  AND ((A.SALESDATERF >=@FINDSTAPPLYDATERF " + Environment.NewLine;
            }
            if (CndtnWork.ApplyEndDate != 0)
            {
                selectTxt += "  AND A.SALESDATERF <=@FINDEDAPPLYDATERF) " + Environment.NewLine;
            }

            selectTxt += "  OR (A.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine;

            selectTxt += "  AND A.SALESDATERF <= @FINDSALESDTED)) " + Environment.NewLine;

            //if (CndtnWork.ApplyStaDate != 0)
            //{
            //    selectTxt += "  AND B.SALESDATERF >=@FINDSTAPPLYDATERF " + Environment.NewLine;
            //}
            //if (CndtnWork.ApplyEndDate != 0)
            //{
            //    selectTxt += "  AND B.SALESDATERF <=@FINDEDAPPLYDATERF " + Environment.NewLine;   
            //}

            if (CndtnWork.ApplyStaDate != 0)
            {
                selectTxt += "  AND ((B.SALESDATERF >=@FINDSTAPPLYDATERF " + Environment.NewLine;
            }
            if (CndtnWork.ApplyEndDate != 0)
            {
                selectTxt += "  AND B.SALESDATERF <=@FINDEDAPPLYDATERF) " + Environment.NewLine;
            }
            selectTxt += "  OR (B.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine;
            selectTxt += "  AND B.SALESDATERF <= @FINDSALESDTED)) " + Environment.NewLine;

            // ----- UPD 2011/07/27 ----- <<<<<

            //selectTxt += "  AND B.SALESDATERF >= @FINDSALESDTST " + Environment.NewLine; // ADD 2011/07/27
            SqlParameter paraSeSalesDtSt = sqlCommand.Parameters.Add("@FINDSALESDTST", SqlDbType.Int);
            paraSeSalesDtSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AddUpYearMonthDaySt);

            //selectTxt += "  AND B.SALESDATERF <= @FINDSALESDTED " + Environment.NewLine; // ADD 2011/07/27
            SqlParameter paraSeSalesDtEd = sqlCommand.Parameters.Add("@FINDSALESDTED", SqlDbType.Int);
            paraSeSalesDtEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(CndtnWork.AddUpYearMonthDayEd);

            SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@FINDEDAPPLYDATERF", SqlDbType.Int);
            paraSalesDateEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyEndDate);
            SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@FINDSTAPPLYDATERF", SqlDbType.Int);
            paraSalesDateSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.ApplyStaDate);
            
            //�O���[�v�R�[�h
            if (CndtnWork.BLGroupCodeSt != 0)
            {
                selectTxt += "  AND B.BLGROUPCODERF>=@FINDSTGROUPCODE " + Environment.NewLine;
                SqlParameter paraGroupCodeSt = sqlCommand.Parameters.Add("@FINDSTGROUPCODE", SqlDbType.Int);
                paraGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeSt);
            }
            if (CndtnWork.BLGroupCodeEd != 0)
            {
                selectTxt += "  AND B.BLGROUPCODERF<=@FINDEDGROUPCODE " + Environment.NewLine;
                SqlParameter paraGroupCodeEd = sqlCommand.Parameters.Add("@FINDEDGROUPCODE", SqlDbType.Int);
                paraGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGroupCodeEd);
            }
            //BL�R�[�h
            if (CndtnWork.BLGoodsCodeSt != 0)
            {
                selectTxt += "  AND B.BLGOODSCODERF>=@FINDSTGOODSCODERF " + Environment.NewLine;
                SqlParameter paraGoodsCodeSt = sqlCommand.Parameters.Add("@FINDSTGOODSCODERF", SqlDbType.Int);
                paraGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeSt);
            }
            if (CndtnWork.BLGoodsCodeEd != 0)
            {
                selectTxt += "  AND B.BLGOODSCODERF<=@FINDEDGOODSCODERF " + Environment.NewLine;
                SqlParameter paraGoodsCodeEd = sqlCommand.Parameters.Add("@FINDEDGOODSCODERF", SqlDbType.Int);
                paraGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(CndtnWork.BLGoodsCodeEd);
            }

            // ----- ADD 2011/07/11 ----- >>>>>
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
            // ----- ADD 2011/07/11 ----- <<<<<

            // ����`�[�敪�i���ׁj�� 0(����),1(�ԕi)
            //selectTxt += "  AND (B.SALESSLIPCDDTLRF = 0 OR B.SALESSLIPCDDTLRF = 1)" + Environment.NewLine; // DEL 2011/07/27
            selectTxt += "  AND (B.SALESSLIPCDDTLRF = 0 OR B.SALESSLIPCDDTLRF = 1 OR B.SALESSLIPCDDTLRF = 2)" + Environment.NewLine; // ADD 2011/07/27
            // �L�����y�[���R�[�h
            selectTxt += "  AND J.CAMPAIGNCODERF=@FINDCAMPAIGNCODE " + Environment.NewLine;
            SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(CndtnWork.CampaignCode);
            //���Ӑ�
            selectTxt += "  AND ((J.CAMPAIGNOBJDIVRF = 1 " + Environment.NewLine;
            selectTxt += "      AND A.CUSTOMERCODERF IN  " + Environment.NewLine;
            //selectTxt += "      (SELECT CUSTOMERCODERF FROM CAMPAIGNLINKRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND LOGICALDELETECODERF = 0 AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE) " + Environment.NewLine; // DEL 2011/07/07
            selectTxt += "      (SELECT CUSTOMERCODERF FROM CAMPAIGNLINKRF WITH (READUNCOMMITTED) WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND LOGICALDELETECODERF = 0 AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE) " + Environment.NewLine; // ADD 2011/07/07
            selectTxt += "      )  OR (J.CAMPAIGNOBJDIVRF <> 1)) " + Environment.NewLine;
            //�ݒ���
            selectTxt += "  AND ( " + Environment.NewLine;
            selectTxt += "  (L.CAMPAIGNSETTINGKINDRF = 1 AND L.GOODSNORF = B.GOODSNORF AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF) " + Environment.NewLine;
            selectTxt += "  OR (L.CAMPAIGNSETTINGKINDRF = 2 AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF AND L.BLGOODSCODERF = B.BLGOODSCODERF) " + Environment.NewLine;
            selectTxt += "  OR (L.CAMPAIGNSETTINGKINDRF = 3 AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF AND L.BLGROUPCODERF = B.BLGROUPCODERF) " + Environment.NewLine;
            selectTxt += "  OR (L.CAMPAIGNSETTINGKINDRF = 4 AND L.GOODSMAKERCDRF = B.GOODSMAKERCDRF ) " + Environment.NewLine;
            selectTxt += "  OR (L.CAMPAIGNSETTINGKINDRF = 5 AND L.BLGOODSCODERF = B.BLGOODSCODERF ) " + Environment.NewLine;
            selectTxt += "  OR (L.CAMPAIGNSETTINGKINDRF = 6 AND L.SALESCODERF = B.SALESCODERF ) " + Environment.NewLine;
            selectTxt += "  ) " + Environment.NewLine;

            // ----- ADD 2011/07/11 ----->>>>>
            selectTxt += " AND ((L.SECTIONCODERF <> '00' AND A.RESULTSADDUPSECCDRF = L.SECTIONCODERF) OR (L.SECTIONCODERF = '00')) " + Environment.NewLine;
            // ----- ADD 2011/07/11 -----<<<<<
            
            #endregion Where��

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
        /// <br>Note       : �N���X�i�[�������܂�</br>
        /// <br>Programmer : caohh</br>
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
        /// <br>Note       : �N���X�i�[�������܂�</br>
        /// <br>Programmer : caohh</br>
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

        #region [���i�ʗp�ڕW�ݒ�Select��]
        /// <summary>
        /// ���i�ʗp�ڕW�ݒ�SELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>���i�ʗp�ڕW�ݒ�SELECT��</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʗp�ڕW�ݒ�SELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        public string MakeTargetSelectString(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            return this.MakeTargetSelectStringProc(ref sqlCommand, CndtnWork);
        }
        #endregion // ���i�ʗp�ڕW�ݒ�Select��

        #region [���i�ʗp�ڕW�ݒ�Select����������]
        /// <summary>
        /// ���i�ʗp�ڕW�ݒ�SELECT�� ��������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="CndtnWork">��������</param>
        /// <returns>���i�ʗp�ڕW�ݒ�SELECT��</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʗp�ڕW�ݒ�SELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private string MakeTargetSelectStringProc(ref SqlCommand sqlCommand, CampaignstRsltListPrtWork CndtnWork)
        {
            string selectTxt = string.Empty;

            #region SELECT��
            selectTxt += "SELECT " + Environment.NewLine;
            selectTxt += "  CAMPTAR.CAMPAIGNCODERF " + Environment.NewLine;              // �L�����y�[���R�[�h
            selectTxt += "  ,CAMPTAR.TARGETCONTRASTCDRF " + Environment.NewLine;         // �ڕW�Δ�敪
            selectTxt += "  ,CAMPTAR.SECTIONCODERF " + Environment.NewLine;              // ���_�R�[�h
            selectTxt += "  ,CAMPTAR.CUSTOMERCODERF " + Environment.NewLine;             // ���Ӑ�R�[�h
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

            selectTxt += "  AND (" + Environment.NewLine;

            selectTxt += "  CAMPTAR.TARGETCONTRASTCDRF=10 " + Environment.NewLine;

            // ���v�P�ʂ��u�O���[�v�R�[�h�v�ꍇ
            if ((CndtnWork.Detail == 0 && CndtnWork.Total == 0) || CndtnWork.Detail == 2)
            {
                selectTxt += "  OR CAMPTAR.TARGETCONTRASTCDRF=50 " + Environment.NewLine;
            }
            else if ((CndtnWork.Detail == 0 && CndtnWork.Total == 1) || CndtnWork.Detail == 1)
            {
                selectTxt += "  OR CAMPTAR.TARGETCONTRASTCDRF=60 " + Environment.NewLine;
            }
            else
            {
                selectTxt += string.Empty;
            }
            selectTxt += "  )" + Environment.NewLine;
            #endregion

            return selectTxt;
        }
        #endregion // ���i�ʗp�ڕW�ݒ�Select����������

        #region [CopyToCampaignTargetWorkFromReader���� �ďo]
        /// <summary>
        /// �N���X�i�[���� Reader �� CopyToCampaignTargetWorkFromReader
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">paramWork</param>
        /// <returns>CopyToCampaignResultWork</returns>
        /// <remarks>
        /// <br>Note       : �N���X�i�[�������܂�</br>
        /// <br>Programmer : caohh</br>
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
        /// <br>Note       : �N���X�i�[�������܂�</br>
        /// <br>Programmer : caohh</br>
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
    }
}

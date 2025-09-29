//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d���ԕi�\����DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : �d���ԕi�\��ꗗ�\�̃f�[�^������s���N���X�ł��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI��c �W�v
// �C �� ��  2013/01/21  �C�����e : �d���ԕi�\��@�\�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI�֓� �a�G
// �C �� ��  2013/02/18  �C�����e : �d�����̃Z�b�g���e�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : FSI�y�~ �їR��
// �C �� ��  2013/02/21  �C�����e : �V�X�e���e�X�g��QNo105�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
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
    /// �d���ԕi�\���� �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���ԕi�\���񃊃��[�g�I�u�W�F�N�g�B</br>
    /// <br>Programmer : FSI��c �W�v</br>
    /// <br>Date       : 2013/01/21</br>
    /// <br></br>
    /// </remarks>

    class SuppPrtPprRetSchStcTblRsltQuery : ISuppPrtPprRetSch
    {
        private const string HORIZONTAL_LINE = "-";
        #region [SuppPrtPprStcTblRsltWork�p SELECT��]
        /// <summary>
        /// �d���ԕi�\����\���̃��X�g���o�N�G���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalDelDiv">�폜�w��敪(0:�ʏ� 1:�폜���̂�)</param>
        /// <returns>�d���ԕi�\����\���̃��X�g���oSELECT��</returns>
        /// <remarks>
        /// <br>Note       : �d���ԕi�\����\���̃��X�g���o�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        public string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int logicalDelDiv)
        {
            string selectTxt = "";
            SuppPrtPprWork _suppPrtPprWork = paramWork as SuppPrtPprWork;

            selectTxt = MakeTypeStcSlpQuery(ref sqlCommand, _suppPrtPprWork, logicalDelDiv);

            return selectTxt;
        }

        #endregion  //[SuppPrtPprStcTblRsltWork�p SELECT��]

        #region [�d���f�[�^�p SELECT����������]
        /// <summary>
        /// �d���ԕi�\����pSELECT���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalDelDiv">�폜�w��敪(0:�ʏ� 1:�폜���̂�)</param>
        /// <returns>�d���ԕi�\����pSELECT��</returns>
        /// <remarks>
        /// <br>Note       : �d���ԕi�\����pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        private string MakeTypeStcSlpQuery(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, int logicalDelDiv)
        {
            StringBuilder sqlText = new StringBuilder();

            // �Ώۃe�[�u��
            // STOCKSLIPRF     STCSLP   �d���f�[�^
            // STOCKDETAILRF   STCDTL   �d�����׃f�[�^
            // SALESSLIPRF     SALSLP   ����f�[�^
            // SALESDETAILRF   SALDTL   ���㖾�׃f�[�^
            // SECINFOSETRF    SCINFS   ���_���ݒ�}�X�^

            #region [Select���쐬]

            sqlText.Append("SELECT").Append(Environment.NewLine);
            sqlText.Append("   ROW_NUMBER() OVER(ORDER BY STCTBL.SUPPLIERSLIPNORF) AS ROWNUM ").Append(Environment.NewLine);
            sqlText.Append(" , STCTBL.* ").Append(Environment.NewLine);
            sqlText.Append("FROM ").Append(Environment.NewLine);
            sqlText.Append("( ").Append(Environment.NewLine);

            #region [�f�[�^���o���C��Query]
            //������������𒴂���܂Ŏ擾
            sqlText.Append("SELECT TOP ").Append(paramWork.SearchCnt).Append(Environment.NewLine);
            sqlText.Append("    STCSLP.ENTERPRISECODERF").Append(Environment.NewLine);
            // --- DEL 2013/02/18 ---------->>>>>
            //sqlText.Append("  , STCSLP.STOCKDATERF").Append(Environment.NewLine);
            // --- DEL 2013/02/18 ----------<<<<<
            // --- ADD 2013/02/18 ---------->>>>>
            // �d�����ł͂Ȃ��A�d���`�[���s�����g�p
            sqlText.Append("  , STCSLP.STOCKSLIPPRINTDATERF").Append(Environment.NewLine);
            // --- ADD 2013/02/18 ----------<<<<<
            sqlText.Append("  , STCSLP.PARTYSALESLIPNUMRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKROWNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERFORMALRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERSLIPCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKAGENTNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKTTLPRICTAXEXCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSMAKERCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.MAKERNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.BLGOODSCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.BLGROUPCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKCOUNTRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.LISTPRICETAXEXCFLRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.OPENPRICEDIVRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPCTAXLAYCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKTTLPRICTAXINCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKPRICECONSTAXRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERSLIPNOTE1RF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERSLIPNOTE2RF").Append(Environment.NewLine);
            sqlText.Append("  , SCINFS.SECTIONCODERF").Append(Environment.NewLine);
            sqlText.Append("  , SCINFS.SECTIONGUIDENMRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKINPUTNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERSNMRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKORDERDIVCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.WAREHOUSECODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.WAREHOUSENAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.WAREHOUSESHELFNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.UOEREMARK1RF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.UOEREMARK2RF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERSLIPNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKADDUPADATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ACCPAYDIVCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.DEBITNOTEDIVRF").Append(Environment.NewLine);
            sqlText.Append("  , SALSLP.SALESSLIPNUMRF").Append(Environment.NewLine);
            sqlText.Append("  , SALSLP.SALESDATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SALESCUSTOMERCODERF AS CUSTOMERCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SALESCUSTOMERSNMRF AS CUSTOMERSNMRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPTTLAMNTDSPWAYCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.TAXATIONCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STCKPRCCONSTAXINCLURF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STCKDISTTLTAXINCLURF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKUNITPRICEFLRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ARRIVALGOODSDAYRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKTOTALPRICERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKSUBTTLPRICERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKGOODSCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKPRICETAXEXCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKPRICETAXINCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKPRICECONSTAXRF AS DTLSTOCKPRICECONSTAXRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKSLIPCDDTLRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.BFSTOCKUNITPRICEFLRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.BFLISTPRICERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.LOGICALDELETECODERF AS SLPDELETECODE").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.LOGICALDELETECODERF AS DTLDELETECODE").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUBSECTIONCODERF AS SLPSUBSECTIONCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKSECTIONCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SUPPLIERCONSTAXRATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.INPUTDAYRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SUBSECTIONCODERF AS DTLSUBSECTIONCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ACCEPTANORDERNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.COMMONSEQNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKSLIPDTLNUMRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SUPPLIERFORMALSRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKSLIPDTLNUMSRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ACPTANODRSTATUSSYNCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SALESSLIPDTLNUMSYNCRF").Append(Environment.NewLine);

            sqlText.Append("  , STCDTL.SUBSECTIONCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKINPUTCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKAGENTCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSKINDCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.MAKERKANANAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.CMPLTMAKERKANANAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSNAMEKANARF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSLGROUPRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSLGROUPNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSMGROUPRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSMGROUPNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.BLGROUPNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.BLGOODSFULLNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ENTERPRISEGANRECODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATESECTSTCKUNPRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATEDIVSTCKUNPRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.UNPRCCALCCDSTCKUNPRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.PRICECDSTCKUNPRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STDUNPRCSTCKUNPRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.FRACPROCUNITSTCUNPRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.FRACPROCSTCKUNPRCRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKUNITTAXPRICEFLRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKUNITCHNGDIVRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATEBLGOODSCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATEBLGOODSNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATEGOODSRATEGRPCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATEGOODSRATEGRPNMRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATEBLGROUPCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.RATEBLGROUPNAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ORDERCNTRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ORDERADJUSTCNTRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ORDERREMAINCNTRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.REMAINCNTUPDDATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKDTISLIPNOTE1RF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SALESCUSTOMERCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SALESCUSTOMERSNMRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SLIPMEMO1RF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SLIPMEMO2RF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SLIPMEMO3RF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.INSIDEMEMO1RF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.INSIDEMEMO2RF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.INSIDEMEMO3RF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ADDRESSEECODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ADDRESSEENAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.DIRECTSENDINGCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ORDERNUMBERRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.WAYTOORDERRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.DELIGDSCMPLTDUEDATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.EXPECTDELIVERYDATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ORDERDATACREATEDIVRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ORDERDATACREATEDATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.ORDERFORMISSUEDDIVRF").Append(Environment.NewLine);

            sqlText.Append("  , STCDTL.ENTERPRISEGANRENAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.GOODSRATERANKRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.CUSTRATEGRPCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.SUPPRATEGRPCODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.LISTPRICETAXINCFLRF").Append(Environment.NewLine);
            sqlText.Append("  , STCDTL.STOCKRATERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKADDUPSECTIONCDRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.BUSINESSTYPECODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.BUSINESSTYPENAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SALESAREACODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.SALESAREANAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.TTLAMNTDISPRATEAPYRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.STOCKFRACTIONPROCCDRF").Append(Environment.NewLine);

            sqlText.Append("  , STCSLP.SLIPADDRESSDIVRF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEECODERF AS SLPADDRESSEECODERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEENAMERF AS SLPADDRESSEENAMERF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEENAME2RF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEEPOSTNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEEADDR1RF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEEADDR3RF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEEADDR4RF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEETELNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.ADDRESSEEFAXNORF").Append(Environment.NewLine);
            sqlText.Append("  , STCSLP.DIRECTSENDINGCDRF AS SLPDIRECTSENDINGCDRF").Append(Environment.NewLine);

            sqlText.Append("  FROM ").Append(Environment.NewLine);
            sqlText.Append("    STOCKSLIPRF AS STCSLP WITH (READUNCOMMITTED) ").Append(Environment.NewLine);

            #region [JOIN]
            //�d�����׃f�[�^
            sqlText.Append("    LEFT JOIN STOCKDETAILRF STCDTL WITH (READUNCOMMITTED)").Append(Environment.NewLine);
            sqlText.Append("      ON STCDTL.ENTERPRISECODERF = STCSLP.ENTERPRISECODERF").Append(Environment.NewLine);
            sqlText.Append("     AND STCDTL.SUPPLIERFORMALRF = STCSLP.SUPPLIERFORMALRF").Append(Environment.NewLine);
            sqlText.Append("     AND STCDTL.SUPPLIERSLIPNORF = STCSLP.SUPPLIERSLIPNORF").Append(Environment.NewLine);

            //���_���ݒ�}�X�^
            sqlText.Append("    LEFT JOIN SECINFOSETRF SCINFS WITH (READUNCOMMITTED)").Append(Environment.NewLine);
            sqlText.Append("      ON SCINFS.ENTERPRISECODERF = STCSLP.ENTERPRISECODERF").Append(Environment.NewLine);
            sqlText.Append("     AND SCINFS.SECTIONCODERF = STCSLP.STOCKSECTIONCDRF").Append(Environment.NewLine);

            //���㖾�׃f�[�^
            sqlText.Append("    LEFT JOIN SALESDETAILRF SALDTL WITH (READUNCOMMITTED)").Append(Environment.NewLine);
            sqlText.Append("      ON SALDTL.ENTERPRISECODERF = STCDTL.ENTERPRISECODERF").Append(Environment.NewLine);
            sqlText.Append("     AND SALDTL.SALESSLIPDTLNUMRF = STCDTL.SALESSLIPDTLNUMSYNCRF").Append(Environment.NewLine);

            //����f�[�^
            sqlText.Append("    LEFT JOIN SALESSLIPRF SALSLP WITH (READUNCOMMITTED)").Append(Environment.NewLine);
            sqlText.Append("      ON SALSLP.ENTERPRISECODERF = SALDTL.ENTERPRISECODERF").Append(Environment.NewLine);
            sqlText.Append("     AND SALSLP.ACPTANODRSTATUSRF = SALDTL.ACPTANODRSTATUSRF").Append(Environment.NewLine);
            sqlText.Append("     AND SALSLP.SALESSLIPNUMRF = SALDTL.SALESSLIPNUMRF").Append(Environment.NewLine);

            #endregion  //[JOIN]

            //WHERE��
            sqlText.Append(MakeWhereString_STCDTL(ref sqlCommand, paramWork, logicalDelDiv));

            #endregion  //[�f�[�^���o���C��Query]

            sqlText.Append(" ORDER BY").Append(Environment.NewLine);

            // --- DEL 2013/02/18 ---------->>>>>
            //sqlText.Append("     STCSLP.STOCKDATERF").Append(Environment.NewLine);
            // --- DEL 2013/02/18 ----------<<<<<
            // --- ADD 2013/02/18 ---------->>>>>
            // �d�����ł͂Ȃ��A�d���`�[���s�����g�p
            sqlText.Append("     STCSLP.STOCKSLIPPRINTDATERF").Append(Environment.NewLine);
            // --- ADD 2013/02/18 ----------<<<<<
            sqlText.Append("   , STCSLP.PARTYSALESLIPNUMRF").Append(Environment.NewLine);
            sqlText.Append("   , STCSLP.SUPPLIERFORMALRF").Append(Environment.NewLine);
            sqlText.Append("   , STCSLP.SUPPLIERSLIPCDRF").Append(Environment.NewLine);
            sqlText.Append("   , STCDTL.STOCKROWNORF").Append(Environment.NewLine);

            sqlText.Append(" ) AS STCTBL ").Append(Environment.NewLine);

            //ODER BY
            sqlText.Append(" ORDER BY ROWNUM DESC");

            #endregion

            return sqlText.ToString();

        }
        #endregion  //[SuppPrtPprSalTblRsltWork�p SELECT����������]


        #region [SuppPrtPprStcTblRsltWork�p WHERE���������� (�d���ԕi�\����SELECT�p)]
        /// <summary>
        /// �d���ԕi�\����\���̃��X�g���o�pWHERE�� �������� (�d���ԕi�\����SELECT�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalDelDiv">�폜�w��敪(0:�ʏ� 1:�폜���̂�)</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Note       : �d���ԕi�\�����WHERE����쐬</br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        private StringBuilder MakeWhereString_STCDTL(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, int logicalDelDiv)
        {
            #region WHERE���쐬

            StringBuilder retstring = new StringBuilder();

            retstring.Append(" WHERE ").Append(Environment.NewLine);

            #region �d���f�[�^��������
            //��ƃR�[�h
            retstring.Append(" STCSLP.ENTERPRISECODERF=@ENTERPRISECODE").Append(Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            retstring.Append(" AND STCSLP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE").Append(Environment.NewLine);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalDelDiv);

            //���_�R�[�h
            if (paramWork.SectionCode != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in paramWork.SectionCode)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring.Append(" AND STCSLP.STOCKSECTIONCDRF IN (").Append(sectionCodestr).Append(") ");
                }
                retstring.Append(Environment.NewLine);
            }

            //�d���`��
            retstring.Append(" AND STCSLP.SUPPLIERFORMALRF = 3 ").Append(Environment.NewLine);

            //�d����R�[�h
            if (paramWork.SupplierCd != 0)
            {
                retstring.Append(" AND STCSLP.SUPPLIERCDRF=@FINDSUPPLIERCD").Append(Environment.NewLine);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCd);
            }

            //�x����R�[�h
            if (paramWork.PayeeCode != 0)
            {
                retstring.Append(" AND STCSLP.PAYEECODERF=@FINDPAYEECODE").Append(Environment.NewLine);
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.PayeeCode);
            }

            //�d����
            if (paramWork.St_StockDate != DateTime.MinValue)
            {
                // --- DEL 2013/02/18 ---------->>>>>
                //retstring.Append(" AND STCSLP.STOCKDATERF>=@STSTOCKDATE ").Append(Environment.NewLine);
                // --- DEL 2013/02/18 ----------<<<<<
                // --- ADD 2013/02/18 ---------->>>>>
                // �d�����ł͂Ȃ��A�d���`�[���s�����g�p
                retstring.Append(" AND STCSLP.STOCKSLIPPRINTDATERF>=@STSTOCKDATE ").Append(Environment.NewLine);
                // --- ADD 2013/02/18 ----------<<<<<
                SqlParameter paraStStockDate = sqlCommand.Parameters.Add("@STSTOCKDATE", SqlDbType.Int);
                paraStStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_StockDate);
            }
            if (paramWork.Ed_StockDate != DateTime.MinValue)
            {
                // --- DEL 2013/02/18 ---------->>>>>
                //retstring.Append(" AND STCSLP.STOCKDATERF<=@EDSTOCKDATE ").Append(Environment.NewLine);
                // --- DEL 2013/02/18 ----------<<<<<
                // --- ADD 2013/02/18 ---------->>>>>
                // �d�����ł͂Ȃ��A�d���`�[���s�����g�p
                retstring.Append(" AND STCSLP.STOCKSLIPPRINTDATERF<=@EDSTOCKDATE ").Append(Environment.NewLine);
                // --- ADD 2013/02/18 ----------<<<<<
                SqlParameter paraEdStockDate = sqlCommand.Parameters.Add("@EDSTOCKDATE", SqlDbType.Int);
                paraEdStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_StockDate);
            }

            //���͓�
            if (paramWork.St_InputDay != DateTime.MinValue)
            {
                retstring.Append(" AND STCSLP.INPUTDAYRF>=@STINPUTDAY").Append(Environment.NewLine);
                SqlParameter paraStInputDay = sqlCommand.Parameters.Add("@STINPUTDAY", SqlDbType.Int);
                paraStInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_InputDay);
            }
            if (paramWork.Ed_InputDay != DateTime.MinValue)
            {
                retstring.Append(" AND STCSLP.INPUTDAYRF<=@EDINPUTDAY").Append(Environment.NewLine);
                SqlParameter paraEdInputDay = sqlCommand.Parameters.Add("@EDINPUTDAY", SqlDbType.Int);
                paraEdInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_InputDay);
            }

            //�`�[�敪
            if (paramWork.SupplierSlipCd != null)
            {
                string supplierSlipCdstr = "";
                foreach (Int32 isupSlpCd in paramWork.SupplierSlipCd)
                {
                    if (supplierSlipCdstr != "")
                    {
                        supplierSlipCdstr += ",";
                    }
                    supplierSlipCdstr += isupSlpCd.ToString();
                }
                if (supplierSlipCdstr != "")
                {
                    retstring.Append(" AND STCSLP.SUPPLIERSLIPCDRF IN (").Append(supplierSlipCdstr).Append(")").Append(Environment.NewLine);
                }
            }

            //�`�[�ԍ�(�����`�[�ԍ�) �������܂���������
            if (paramWork.PartySaleSlipNum != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.PartySaleSlipNum, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring.Append(" AND STCSLP.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUM").Append(Environment.NewLine);
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring.Append(" AND STCSLP.PARTYSALESLIPNUMRF=@FINDPARTYSALESLIPNUM").Append(Environment.NewLine);
                }
                SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUM", SqlDbType.NVarChar);
                paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(paramWork.PartySaleSlipNum);
            }

            //�d��SEQ/�x����(�d���`�[�ԍ�)
            if (paramWork.PaymentSlipNo != 0)
            {
                retstring.Append(" AND STCSLP.SUPPLIERSLIPNORF>=@FINDSUPPLIERSLIPNO").Append(Environment.NewLine);
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(paramWork.PaymentSlipNo);
            }

            //�S����(�d���S���҃R�[�h)
            if (paramWork.StockAgentCode != "")
            {
                retstring.Append(" AND STCSLP.STOCKAGENTCODERF=@FINDSTOCKAGENTCODE").Append(Environment.NewLine);
                SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODE", SqlDbType.NChar);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(paramWork.StockAgentCode);
            }

            //���l�P(�d���`�[���l1) �������܂���������
            if (paramWork.SupplierSlipNote1 != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SupplierSlipNote1, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring.Append(" AND STCSLP.SUPPLIERSLIPNOTE1RF LIKE @FINDSUPPLIERSLIPNOTE1").Append(Environment.NewLine);
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring.Append(" AND STCSLP.SUPPLIERSLIPNOTE1RF=@FINDSUPPLIERSLIPNOTE1").Append(Environment.NewLine);
                }
                SqlParameter paraSupplierSlipNote1 = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOTE1", SqlDbType.NVarChar);
                paraSupplierSlipNote1.Value = SqlDataMediator.SqlSetString(paramWork.SupplierSlipNote1);
            }

            //���l�Q(�d���`�[���l2) �������܂���������
            if (paramWork.SupplierSlipNote2 != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SupplierSlipNote2, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring.Append(" AND STCSLP.SUPPLIERSLIPNOTE2RF LIKE @FINDSUPPLIERSLIPNOTE2").Append(Environment.NewLine);
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring.Append(" AND STCSLP.SUPPLIERSLIPNOTE2RF=@FINDSUPPLIERSLIPNOTE2").Append(Environment.NewLine);
                }
                SqlParameter paraSupplierSlipNote2 = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNOTE2", SqlDbType.NVarChar);
                paraSupplierSlipNote2.Value = SqlDataMediator.SqlSetString(paramWork.SupplierSlipNote2);
            }

            //�t�n�d���}�[�N�P �������܂���������
            if (paramWork.UoeRemark1 != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.UoeRemark1, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring.Append(" AND STCSLP.UOEREMARK1RF LIKE @FINDUOEREMARK1").Append(Environment.NewLine);
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring.Append(" AND STCSLP.UOEREMARK1RF=@FINDUOEREMARK1").Append(Environment.NewLine);
                }
                SqlParameter paraUoeRemark1 = sqlCommand.Parameters.Add("@FINDUOEREMARK1", SqlDbType.NVarChar);
                paraUoeRemark1.Value = SqlDataMediator.SqlSetString(paramWork.UoeRemark1);
            }

            //�t�n�d���}�[�N�Q �������܂���������
            if (paramWork.UoeRemark2 != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.UoeRemark2, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring.Append(" AND STCSLP.UOEREMARK2RF LIKE @FINDUOEREMARK2").Append(Environment.NewLine);
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring.Append(" AND STCSLP.UOEREMARK2RF=@FINDUOEREMARK2").Append(Environment.NewLine);
                }
                SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@FINDUOEREMARK2", SqlDbType.NVarChar);
                paraUoeRemark2.Value = SqlDataMediator.SqlSetString(paramWork.UoeRemark2);
            }

            #endregion

            #region �d�����׃f�[�^��������

            //��ƃR�[�h
            retstring.Append(" AND STCDTL.ENTERPRISECODERF=@ENTERPRISECODE2").Append(Environment.NewLine);
            SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@ENTERPRISECODE2", SqlDbType.NChar);
            paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            if (logicalDelDiv == 0)
            {
                // �ʏ�
                retstring.Append(" AND STCDTL.LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);
                retstring.Append(" AND STCDTL.SALESSLIPDTLNUMSYNCRF <> 0 ").Append(Environment.NewLine);
            }
            else
            {
                // �폜���̂�
                retstring.Append(" AND STCDTL.LOGICALDELETECODERF = 1 ").Append(Environment.NewLine);
                retstring.Append(" AND STCDTL.SALESSLIPDTLNUMSYNCRF <> 0 ").Append(Environment.NewLine);
            }

            // ���׋敪
            if (paramWork.StockSlipCdDtl == 1)
            {
                // 1:�l������
                retstring.Append(" AND STCDTL.STOCKSLIPCDDTLRF<>@FINDSTOCKSLIPCDDTL").Append(Environment.NewLine);
                SqlParameter paraStockSlipCdDtl = sqlCommand.Parameters.Add("@FINDSTOCKSLIPCDDTL", SqlDbType.Int);
                paraStockSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(2);
            }
            else if (paramWork.StockSlipCdDtl == 2)
            {
                // 2:�l���̂�
                retstring.Append(" AND STCDTL.STOCKSLIPCDDTLRF=@FINDSTOCKSLIPCDDTL").Append(Environment.NewLine);
                SqlParameter paraStockSlipCdDtl = sqlCommand.Parameters.Add("@FINDSTOCKSLIPCDDTL", SqlDbType.Int);
                paraStockSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(2);
            }

            //�t�n�d����(�������@)
            if (paramWork.WayToOrder != 0)
            {
                if (paramWork.WayToOrder == 2)
                {
                    //UOE���M -> UOE���M�̂�
                    retstring.Append(" AND STCDTL.WAYTOORDERRF=2").Append(Environment.NewLine);
                }
                else
                {
                    //�ʏ� -> UOE���M�ȊO
                    retstring.Append("AND STCDTL.WAYTOORDERRF<>2 ").Append(Environment.NewLine);
                }
            }

            //�O���[�v�R�[�h(BL�O���[�v�R�[�h)
            if (paramWork.BLGroupCode != 0)
            {
                retstring.Append(" AND STCDTL.BLGROUPCODERF=@FINDBLGROUPCODE").Append(Environment.NewLine);
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGroupCode);
            }

            //BL�R�[�h(BL���i�R�[�h)
            if (paramWork.BLGoodsCode != 0)
            {
                retstring.Append(" AND STCDTL.BLGOODSCODERF=@FINDBLGOODSCODE").Append(Environment.NewLine);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGoodsCode);
            }

            //�i��(���i����) �������܂���������
            if (paramWork.GoodsName != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.GoodsName, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring.Append(" AND STCDTL.GOODSNAMERF LIKE @FINDGOODSNAME").Append(Environment.NewLine);
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring.Append(" AND STCDTL.GOODSNAMERF=@FINDGOODSNAME").Append(Environment.NewLine);
                }
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAME", SqlDbType.NVarChar);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(paramWork.GoodsName);
            }

            //�i��(���i�ԍ�) �������܂���������
            if (paramWork.GoodsNo != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.GoodsNo, "(%)").Success == true)
                {
                    //�����܂�����
                    if (paramWork.GoodsNo.Contains(HORIZONTAL_LINE))
                    {
                        retstring.Append(" AND STCDTL.GOODSNORF LIKE @FINDGOODSNO").Append(Environment.NewLine);
                    }
                    else
                    {
                        retstring.Append(" AND REPLACE(STCDTL.GOODSNORF, '" + HORIZONTAL_LINE + "', '') LIKE @FINDGOODSNO").Append(Environment.NewLine);
                    }
                }
                else
                {
                    //�����܂���������Ȃ�
                    if (paramWork.GoodsNo.Contains(HORIZONTAL_LINE))
                    {
                        retstring.Append(" AND STCDTL.GOODSNORF = @FINDGOODSNO").Append(Environment.NewLine);
                    }
                    else
                    {
                        retstring.Append(" AND REPLACE(STCDTL.GOODSNORF, '" + HORIZONTAL_LINE + "', '') = @FINDGOODSNO").Append(Environment.NewLine);
                    }
                }
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNo);
            }

            //���[�J�[(���i���[�J�[�R�[�h)
            if (paramWork.GoodsMakerCd != 0)
            {
                retstring.Append("AND STCDTL.GOODSMAKERCDRF=@FINDGOODSMAKERCD ").Append(Environment.NewLine);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCd);
            }

            //�݌Ɏ��敪(�d���݌Ɏ�񂹋敪)
            if (paramWork.StockOrderDivCd != -1)
            {
                retstring.Append("AND STCDTL.STOCKORDERDIVCDRF=@FINDSTOCKORDERDIVCD").Append(Environment.NewLine);
                SqlParameter paraStockOrderDivCd = sqlCommand.Parameters.Add("@FINDSTOCKORDERDIVCD", SqlDbType.Int);
                paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(paramWork.StockOrderDivCd);
            }

            //�q�ɃR�[�h
            if (paramWork.WarehouseCode != "")
            {
                retstring.Append("AND STCDTL.WAREHOUSECODERF=@FINDWAREHOUSECODE ").Append(Environment.NewLine);
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
            }

            #endregion
            #endregion

            return retstring;
        }
        #endregion  //[SuppPrtPprStcTblRsltWork�p WHERE���������� (�d���f�[�^SELECT�p)]


        #region [SuppPrtPprStcTblRsltWork���� �ďo]
        /// <summary>
        /// �N���X�i�[���� Reader �� SuppPrtPprStcTblRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">SuppPrtPprWork</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        public object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork)
        {
            SuppPrtPprWork _suppPrtPprWork = paramWork as SuppPrtPprWork;
            return this.CopyToResultWorkFromReaderProc(ref myReader);
        }
        #endregion  //[SuppPrtPprStcTblRsltWork���� �ďo]

        #region [SuppPrtPprStcTblRsltWork����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SuppPrtPprStcTblRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI��c �W�v</br>
        /// <br>Date       : 2013/01/21</br>
        /// <br>�Ǘ��ԍ�   : </br>
        /// </remarks>
        private SuppPrtPprStcTblRsltWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader)
        {
            #region ���o����-�l�Z�b�g
            SuppPrtPprStcTblRsltWork resultWork = new SuppPrtPprStcTblRsltWork();

            resultWork.DataDiv = 0;
            // --- DEL 2013/02/18 ---------->>>>>
            //resultWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
            // --- DEL 2013/02/18 ----------<<<<<
            // --- ADD 2013/02/18 ---------->>>>>
            // �d���`�[���s�����d�����Ƃ��Ďg�p
            resultWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));
            // --- ADD 2013/02/18 ----------<<<<<
            resultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
            resultWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            resultWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            resultWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
            resultWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            resultWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            resultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
            resultWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            resultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            resultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
            resultWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
            resultWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            resultWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
            resultWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
            resultWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            resultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            resultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            resultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            resultWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
            resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            resultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            resultWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
            resultWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
            resultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
            resultWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
            resultWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
            resultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
            resultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            resultWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
            resultWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
            resultWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
            resultWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
            resultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            resultWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
            resultWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
            resultWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
            resultWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
            resultWork.StockPriceConsTaxDtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTLSTOCKPRICECONSTAXRF"));
            //resultWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));  // DEL 2013/02/21
            resultWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
            resultWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));// ADD 2013/02/21

            resultWork.SlpLogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLPDELETECODE"));
            resultWork.DtlLogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLDELETECODE"));
            resultWork.SlpSubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLPSUBSECTIONCODERF"));
            resultWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
            resultWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
            resultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
            resultWork.DtlSubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLSUBSECTIONCODERF"));
            resultWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
            resultWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            resultWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
            resultWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
            resultWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
            resultWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSYNCRF"));
            resultWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNCRF"));

            resultWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
            resultWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            resultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
            resultWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
            resultWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));
            resultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
            resultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
            resultWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
            resultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
            resultWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
            resultWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
            resultWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
            resultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
            resultWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSTCKUNPRCRF"));
            resultWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSTCKUNPRCRF"));
            resultWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSTCKUNPRCRF"));
            resultWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSTCKUNPRCRF"));
            resultWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSTCKUNPRCRF"));
            resultWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSTCUNPRCRF"));
            resultWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSTCKUNPRCRF"));
            resultWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
            resultWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNITCHNGDIVRF"));
            resultWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
            resultWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
            resultWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));
            resultWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));
            resultWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));
            resultWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));
            resultWork.OrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERCNTRF"));
            resultWork.OrderAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERADJUSTCNTRF"));
            resultWork.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERREMAINCNTRF"));
            resultWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));
            resultWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
            resultWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
            resultWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
            resultWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
            resultWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
            resultWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
            resultWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
            resultWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
            resultWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
            resultWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
            resultWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
            resultWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));
            resultWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
            resultWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));
            resultWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
            resultWork.ExpectDeliveryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EXPECTDELIVERYDATERF"));
            resultWork.OrderDataCreateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERDATACREATEDIVRF"));
            resultWork.OrderDataCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ORDERDATACREATEDATERF"));
            resultWork.OrderFormIssuedDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERFORMISSUEDDIVRF"));

            resultWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
            resultWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
            resultWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
            resultWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPRATEGRPCODERF"));
            resultWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
            resultWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
            resultWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
            resultWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            resultWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
            resultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            resultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
            resultWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
            resultWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));

            resultWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
            resultWork.SlpAddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLPADDRESSEECODERF"));
            resultWork.SlpAddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLPADDRESSEENAMERF"));
            resultWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
            resultWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
            resultWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
            resultWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
            resultWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
            resultWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
            resultWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
            resultWork.SlpDirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLPDIRECTSENDINGCDRF"));

            #endregion

            return resultWork;
        }
        #endregion  //[SuppPrtPprStcTblRsltWork����]

    }
}

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
    /// </summary>
    /// <remarks>
    /// <br>Update Note: 2009/09/08 ���̕�</br>
    /// <br>           : PM.NS-2-B�E�o�l�D�m�r�ێ�˗��@</br>
    /// <br>           : �ߋ����\���Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2010/05/10 �������n</br>
    /// <br>           : ���x�`���[�j���O</br>
    /// <br>Update Note: 2011/11/29 yangmj redmine#8195 �d����d�q�����ɓ��Ӑ�R�[�h�Ɨ��̂̕ύX</br>
    /// <br>Update Note: 2011/12/09 ������</br>
    /// <br>           : Redmine#8195 �d����d�q�����ɓ��Ӑ�R�[�h�Ɨ��̂̕ύX</br>
    /// <br>Update Note: 2012/06/26 20008 �ɓ� �L</br>
    /// <br>           : READUNCOMMITTED�Ή�</br>
    /// <br>Update Note: 2012/07/05 20008 �ɓ� �L</br>
    /// <br>           : �����̓x�ɕ��я����قȂ錻�ۂ��C��</br>
    /// <br>Update Note: 2012/08/09 wangf </br>
    /// <br>           : 10801804-00�A9/12�z�M���ARedmine#31533 �d����d�q���� �i�Ԏw�莞�̒��o�s���̑Ή�</br>
    /// <br>           : �i�Ԃ��n�C�t�������œ��͂����ꍇ�A�d����d�q�����͓��Ӑ�d�q�����Ɠ����悤�ɒ��o�\�ɂȂ�܂��B</br>
    /// <br>Update Note: 2012/10/15 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00�A2012/11/14�z�M��</br>
    /// <br>             Redmine#32862 ���i�ύX�������ׁA�F��ς���悤�ɏC��</br>
    //----------------------------------------------------------------------------//
    // �Ǘ��ԍ�              �쐬�S�� : FSI��c �W�v
    // �C �� ��  2013/01/21  �C�����e : �d���ԕi�\��@�\�Ή�
    //----------------------------------------------------------------------------//
    // �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
    // �C �� ��  2013/02/07  �C�����e : 2013/03/13�z�M���ً̋}�Ή�
    //                                  Redmine #34611 �d����d�q������UOE���f�[�^����s��
    //----------------------------------------------------------------------------//
    /// </remarks>
    class SuppPrtPprStcTblRsltQuery : ISuppPrtPpr
    {
        private const string HORIZONTAL_LINE = "-";  //ADD wangf 2012/08/09 FOR Redmine#31533
        #region [SuppPrtPprStcTblRsltWork�p SELECT��]
        /// <summary>
        /// �`�[�\���E���ו\���̃��X�g���o�N�G���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="iType">�����^�C�v 0:�d���f�[�^ 1:�x���f�[�^</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�`�[�\���E���ו\���̃��X�g���oSELECT��</returns>
        /// <br>Note       : �`�[�\���E���ו\���̃��X�g���o�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br>Update Note: 2009/09/08 ���̕��@�ߋ����\���Ή�</br>
        public string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int iType, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";
            SuppPrtPprWork _suppPrtPprWork = paramWork as SuppPrtPprWork;

            switch (iType)
            {
                case (int)iSrcType.StcTbl:  //�d���f�[�^
                    // -------------ADD 2009/09/08 ------------>>>>>
                    if (_suppPrtPprWork.SupplierFormal != null)
                    {
                        // 0:�d���̏ꍇ:�����\���Ή����߁A�V�K����
                        if (_suppPrtPprWork.SupplierFormal.Length == 1 && _suppPrtPprWork.SupplierFormal[0] == 0)
                        {
                            selectTxt = MakeTypeStcSlpQuery2(ref sqlCommand, _suppPrtPprWork, logicalMode);
                        }
                        // 1:����,2:�����̏ꍇ:���������𗘗p����B
                        else
                        {
                            selectTxt = MakeTypeStcSlpQuery(ref sqlCommand, _suppPrtPprWork, logicalMode);
                        }
                    }
                    // -------------ADD 2009/09/08 ------------<<<<<
                    // selectTxt = MakeTypeStcSlpQuery(ref sqlCommand, _suppPrtPprWork, logicalMode);  // DEL 2009/09/08
                    break;
                case (int)iSrcType.PayTbl:  //�x���f�[�^
                    selectTxt = MakeTypePaySlpQuery(ref sqlCommand, _suppPrtPprWork, logicalMode);
                    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                case (int)iSrcType.StcTblOdr: // (�d��)�����f�[�^
                    selectTxt = MakeTypeStcSlpOdrQuery(ref sqlCommand, _suppPrtPprWork, logicalMode);
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                default:
                    break;
            }

            return selectTxt;
        }

        #endregion  //[SuppPrtPprStcTblRsltWork�p SELECT��]

        #region [�d���f�[�^�p SELECT����������]
        /// <summary>
        /// �d���f�[�^�pSELECT���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�d���f�[�^�pSELECT��</returns>
        /// <remarks>
        /// <br>Note       : �d���f�[�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br>Update Note: 2011/11/29 yangmj redmine#8195 �d����d�q�����ɓ��Ӑ�R�[�h�Ɨ��̂̕ύX</br>
        /// <br>Update Note: 2012/10/15 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A2012/11/14�z�M��</br>
        /// <br>             Redmine#32862 ���i�ύX�������ׁA�F��ς���悤�ɏC��</br>
        /// <br>Update Note: 2020/03/11 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 �y���ŗ��Ή�</br>
        /// <br>           : �`�[�^�u�A���׃^�u�Ɂu����ŗ��v���ڂ�ǉ�</br>
        /// </remarks>
        private string MakeTypeStcSlpQuery(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";

            // �Ώۃe�[�u��
            // STOCKSLIPRF     STCSLP   �d���f�[�^
            // STOCKDETAILRF   STCDTL   �d�����׃f�[�^
            // SALESSLIPRF     SALSLP   ����f�[�^
            // SALESDETAILRF   SALDTL   ���㖾�׃f�[�^
            // SECINFOSETRF    SCINFS   ���_���ݒ�}�X�^

            #region [Select���쐬]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  ROW_NUMBER()" + Environment.NewLine;
            selectTxt += "   OVER(ORDER BY STCTBL.SUPPLIERSLIPNORF)" + Environment.NewLine;
            selectTxt += "   AS ROWNUM" + Environment.NewLine;
            selectTxt += " ,*" + Environment.NewLine;
            selectTxt += " FROM (" + Environment.NewLine;

            #region [�f�[�^���o���C��Query]
            //������������𒴂���܂Ŏ擾
            selectTxt += "  SELECT TOP " + paramWork.SearchCnt + Environment.NewLine;
            selectTxt += "    STCSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKDATERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.PARTYSALESLIPNUMRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKROWNORF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERFORMALRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERSLIPCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKAGENTNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.GOODSNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.GOODSNORF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.GOODSMAKERCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.MAKERNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.BLGOODSCODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.BLGROUPCODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKCOUNTRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.OPENPRICEDIVRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPCTAXLAYCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKPRICECONSTAXRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
            selectTxt += "   ,SCINFS.SECTIONCODERF" + Environment.NewLine; // ADD 2008.10.21
            selectTxt += "   ,SCINFS.SECTIONGUIDENMRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKINPUTNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERSNMRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKORDERDIVCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.WAREHOUSECODERF" + Environment.NewLine; // ADD 2008.10.21
            selectTxt += "   ,STCDTL.WAREHOUSENAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.WAREHOUSESHELFNORF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.UOEREMARK1RF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.UOEREMARK2RF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERSLIPNORF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKADDUPADATERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.ACCPAYDIVCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.DEBITNOTEDIVRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESDATERF" + Environment.NewLine;
            //-----UPD 2011/11/29----->>>>>
            //selectTxt += "   ,SALSLP.CUSTOMERCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.CUSTOMERSNMRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.SALESCUSTOMERCODERF AS CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.SALESCUSTOMERSNMRF AS CUSTOMERSNMRF" + Environment.NewLine;
            //-----UPD 2011/11/29-----<<<<<
            selectTxt += "   ,STCSLP.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine; // ADD 2008.10.30
            selectTxt += "   ,STCDTL.TAXATIONCODERF" + Environment.NewLine; // ADD 2008.10.30
            selectTxt += "   ,STCSLP.STCKPRCCONSTAXINCLURF" + Environment.NewLine; // ADD 2008.10.30
            selectTxt += "   ,STCSLP.STCKDISTTLTAXINCLURF" + Environment.NewLine; // ADD 2008.10.30
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
            selectTxt += "   ,STCDTL.STOCKUNITPRICEFLRF" + Environment.NewLine;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
            selectTxt += "   ,STCSLP.ARRIVALGOODSDAYRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKTOTALPRICERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKSUBTTLPRICERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKGOODSCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKPRICETAXEXCRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKPRICETAXINCRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKPRICECONSTAXRF AS DTLSTOCKPRICECONSTAXRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKSLIPCDDTLRF" + Environment.NewLine;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
            // ----------- ADD 2012/10/15 �c���� ------------>>>>>
            selectTxt += "   ,STCDTL.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.BFLISTPRICERF" + Environment.NewLine;
            // ----------- ADD 2012/10/15 �c���� ------------<<<<<
            selectTxt += "   ,STCSLP.SUPPLIERCONSTAXRATERF" + Environment.NewLine; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
            selectTxt += "  FROM (" + Environment.NewLine;

            #region [�d���f�[�^���oQuery]
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     STCSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/25 DEL
            //selectTxt += "    ,STCSLPSUB.SECTIONCODERF" + Environment.NewLine;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/25 DEL
            selectTxt += "    ,STCSLPSUB.STOCKDATERF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.PARTYSALESLIPNUMRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPLIERFORMALRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPLIERSLIPCDRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.STOCKAGENTNAMERF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPCTAXLAYCDRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.STOCKPRICECONSTAXRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.STOCKINPUTNAMERF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPLIERCDRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPLIERSNMRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.UOEREMARK1RF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.UOEREMARK2RF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPLIERSLIPNORF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.STOCKADDUPADATERF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.ACCPAYDIVCDRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.DEBITNOTEDIVRF" + Environment.NewLine;
            selectTxt += "   ,STCSLPSUB.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine; // ADD 2008.10.30
            selectTxt += "   ,STCSLPSUB.STCKPRCCONSTAXINCLURF" + Environment.NewLine; // ADD 2008.10.30
            selectTxt += "   ,STCSLPSUB.STCKDISTTLTAXINCLURF" + Environment.NewLine; // ADD 2008.10.30
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
            selectTxt += "   ,STCSLPSUB.ARRIVALGOODSDAYRF" + Environment.NewLine;
            selectTxt += "   ,STCSLPSUB.STOCKTOTALPRICERF" + Environment.NewLine;
            selectTxt += "   ,STCSLPSUB.STOCKSUBTTLPRICERF" + Environment.NewLine;
            selectTxt += "   ,STCSLPSUB.STOCKSECTIONCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLPSUB.STOCKGOODSCDRF" + Environment.NewLine;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
            selectTxt += "   ,STCSLPSUB.SUPPLIERCONSTAXRATERF" + Environment.NewLine; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "   FROM STOCKSLIPRF AS STCSLPSUB " + Environment.NewLine;
            selectTxt += "   FROM STOCKSLIPRF AS STCSLPSUB WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            selectTxt += MakeWhereString_STCSLPSUB(ref sqlCommand, paramWork, logicalMode);
            #endregion  //[�d���f�[�^���oQuery]

            selectTxt += "  ) AS STCSLP" + Environment.NewLine;

            #region [JOIN]
            //�d�����׃f�[�^
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "  LEFT JOIN STOCKDETAILRF STCDTL" + Environment.NewLine;
            selectTxt += "  LEFT JOIN STOCKDETAILRF STCDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += "  ON  STCDTL.ENTERPRISECODERF=STCSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND STCDTL.SUPPLIERFORMALRF=STCSLP.SUPPLIERFORMALRF" + Environment.NewLine;
            selectTxt += "  AND STCDTL.SUPPLIERSLIPNORF=STCSLP.SUPPLIERSLIPNORF" + Environment.NewLine;

            //���㖾�׃f�[�^(����)
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL" + Environment.NewLine;
            selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += "  ON  SALDTL.ENTERPRISECODERF=STCDTL.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SALDTL.ACPTANODRSTATUSRF=STCDTL.ACPTANODRSTATUSSYNCRF" + Environment.NewLine;
            selectTxt += "  AND SALDTL.SALESSLIPDTLNUMRF=STCDTL.SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;

            //����f�[�^(����)
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "  LEFT JOIN SALESSLIPRF SALSLP" + Environment.NewLine;
            selectTxt += "  LEFT JOIN SALESSLIPRF SALSLP WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += "  ON  SALSLP.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SALSLP.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "  AND SALSLP.SALESSLIPNUMRF=SALDTL.SALESSLIPNUMRF" + Environment.NewLine;

            //���_���ݒ�}�X�^
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS" + Environment.NewLine;
            selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += "  ON  SCINFS.ENTERPRISECODERF=STCSLP.ENTERPRISECODERF" + Environment.NewLine;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/25 DEL
            //selectTxt += "  AND SCINFS.SECTIONCODERF=STCSLP.SECTIONCODERF" + Environment.NewLine;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/25 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/25 ADD
            selectTxt += "  AND SCINFS.SECTIONCODERF=STCSLP.STOCKSECTIONCDRF" + Environment.NewLine;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/25 ADD
            #endregion  //[JOIN]

            //WHERE��
            selectTxt += MakeWhereString_STCDTL(ref sqlCommand, paramWork, logicalMode);

            #endregion  //[�f�[�^���o���C��Query]

            // 2012/07/05 Y.Ito ADD START �����̓x�ɕ��я����قȂ錻�ۂ��C��
            selectTxt += " ORDER BY STCSLP.STOCKDATERF, STCSLP.PARTYSALESLIPNUMRF, STCSLP.SUPPLIERFORMALRF, STCSLP.SUPPLIERSLIPCDRF, STCDTL.STOCKROWNORF" + Environment.NewLine;
            // 2012.07.05 Y.Ito ADD END �����̓x�ɕ��я����قȂ錻�ۂ��C��

            selectTxt += " ) AS STCTBL" + Environment.NewLine;

            //ODER BY
            selectTxt += " ORDER BY ROWNUM DESC";
            #endregion

            return selectTxt;
        }
        #endregion  //[SuppPrtPprSalTblRsltWork�p SELECT����������]

        // ------------Add 2009/09/08------------->>>>>
        #region [�d���f�[�^�p SELECT���������� �ߋ����\���Ή�]
        /// <summary>
        /// �d���f�[�^�pSELECT���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�d���f�[�^�pSELECT��</returns>
        /// <remarks>
        /// <br>Note       : �d���f�[�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer :  ���̕�</br>
        /// <br>Date       : 2009/09/08</br>
        /// <br>Update Note: 2011/11/29 yangmj redmine#8195 �d����d�q�����ɓ��Ӑ�R�[�h�Ɨ��̂̕ύX</br>
        /// <br>Update Note: 2012/10/15 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A2012/11/14�z�M��</br>
        /// <br>             Redmine#32862 ���i�ύX�������ׁA�F��ς���悤�ɏC��</br>
        /// <br>Update Note: 2020/03/11 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 �y���ŗ��Ή�</br>
        /// <br>           : �`�[�^�u�A���׃^�u�Ɂu����ŗ��v���ڂ�ǉ�</br>
        /// </remarks>
        private string MakeTypeStcSlpQuery2(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";

            // �Ώۃe�[�u��
            // STOCKSLIPHISTRF     STCSLP   �d�������f�[�^
            // STOCKSLHISTDTLRF   STCDTL   �d�����𖾍׃f�[�^
            // SALESHISTORYRF     SALSLP   ���㗚���f�[�^
            // SALESHISTDTLRF   SALDTL   ���㗚�𖾍׃f�[�^
            // SECINFOSETRF    SCINFS   ���_���ݒ�}�X�^

            #region [Select���쐬]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  ROW_NUMBER()" + Environment.NewLine;
            selectTxt += "   OVER(ORDER BY STCTBL.SUPPLIERSLIPNORF)" + Environment.NewLine;
            selectTxt += "   AS ROWNUM" + Environment.NewLine;
            selectTxt += " ,*" + Environment.NewLine;
            selectTxt += " FROM (" + Environment.NewLine;

            #region [�f�[�^���o���C��Query]
            //������������𒴂���܂Ŏ擾
            selectTxt += "  SELECT TOP " + paramWork.SearchCnt + Environment.NewLine;
            selectTxt += "    STCSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKDATERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.PARTYSALESLIPNUMRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKROWNORF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERFORMALRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERSLIPCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKAGENTNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.GOODSNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.GOODSNORF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.GOODSMAKERCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.MAKERNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.BLGOODSCODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.BLGROUPCODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKCOUNTRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.OPENPRICEDIVRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPCTAXLAYCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKPRICECONSTAXRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
            selectTxt += "   ,SCINFS.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "   ,SCINFS.SECTIONGUIDENMRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERSNMRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKORDERDIVCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.WAREHOUSECODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.WAREHOUSENAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.WAREHOUSESHELFNORF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.UOEREMARK1RF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.UOEREMARK2RF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERSLIPNORF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKADDUPADATERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.ACCPAYDIVCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.DEBITNOTEDIVRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESDATERF" + Environment.NewLine;
            //-----UPD 2011/11/29----->>>>>
            //selectTxt += "   ,SALSLP.CUSTOMERCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.CUSTOMERSNMRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.SALESCUSTOMERCODERF AS CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.SALESCUSTOMERSNMRF AS CUSTOMERSNMRF" + Environment.NewLine;
            //-----UPD 2011/11/29-----<<<<<
            selectTxt += "   ,STCSLP.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.TAXATIONCODERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STCKPRCCONSTAXINCLURF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STCKDISTTLTAXINCLURF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKUNITPRICEFLRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.ARRIVALGOODSDAYRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKTOTALPRICERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKSUBTTLPRICERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKGOODSCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKPRICETAXEXCRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKPRICETAXINCRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKPRICECONSTAXRF AS DTLSTOCKPRICECONSTAXRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKSLIPCDDTLRF" + Environment.NewLine;
            // ----------- ADD 2012/10/15 �c���� ------------>>>>>
            selectTxt += "   ,STCDTL.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.BFLISTPRICERF" + Environment.NewLine;
            // ----------- ADD 2012/10/15 �c���� ------------<<<<<
            selectTxt += "   ,STCSLP.SUPPLIERCONSTAXRATERF" + Environment.NewLine; // ADD ���V�� 2020/03/11 PMKOBETSU-2912

            selectTxt += "  FROM (" + Environment.NewLine;

            #region [�d���f�[�^���oQuery]
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     STCSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.STOCKDATERF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.PARTYSALESLIPNUMRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPLIERFORMALRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPLIERSLIPCDRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.STOCKAGENTNAMERF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPCTAXLAYCDRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.STOCKPRICECONSTAXRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPLIERCDRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPLIERSNMRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.UOEREMARK1RF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.UOEREMARK2RF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.SUPPLIERSLIPNORF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.STOCKADDUPADATERF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.ACCPAYDIVCDRF" + Environment.NewLine;
            selectTxt += "    ,STCSLPSUB.DEBITNOTEDIVRF" + Environment.NewLine;
            selectTxt += "   ,STCSLPSUB.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLPSUB.STCKPRCCONSTAXINCLURF" + Environment.NewLine;
            selectTxt += "   ,STCSLPSUB.STCKDISTTLTAXINCLURF" + Environment.NewLine;
            selectTxt += "   ,STCSLPSUB.ARRIVALGOODSDAYRF" + Environment.NewLine;
            selectTxt += "   ,STCSLPSUB.STOCKTOTALPRICERF" + Environment.NewLine;
            selectTxt += "   ,STCSLPSUB.STOCKSUBTTLPRICERF" + Environment.NewLine;
            selectTxt += "   ,STCSLPSUB.STOCKSECTIONCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLPSUB.STOCKGOODSCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLPSUB.SUPPLIERCONSTAXRATERF" + Environment.NewLine; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "   FROM STOCKSLIPHISTRF AS STCSLPSUB " + Environment.NewLine;
            selectTxt += "   FROM STOCKSLIPHISTRF AS STCSLPSUB WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += MakeWhereString_STCSLPSUB2(ref sqlCommand, paramWork, logicalMode);
            #endregion  //[�d���f�[�^���oQuery]

            selectTxt += "  ) AS STCSLP" + Environment.NewLine;

            #region [JOIN]
            // //�d�����𖾍׃f�[�^
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "  LEFT JOIN STOCKSLHISTDTLRF STCDTL" + Environment.NewLine;
            selectTxt += "  LEFT JOIN STOCKSLHISTDTLRF STCDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += "  ON  STCDTL.ENTERPRISECODERF=STCSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND STCDTL.SUPPLIERFORMALRF=STCSLP.SUPPLIERFORMALRF" + Environment.NewLine;
            selectTxt += "  AND STCDTL.SUPPLIERSLIPNORF=STCSLP.SUPPLIERSLIPNORF" + Environment.NewLine;

            //���㗚�𖾍׃f�[�^(����)
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL" + Environment.NewLine;
            selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += "  ON  SALDTL.ENTERPRISECODERF=STCDTL.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SALDTL.ACPTANODRSTATUSRF=STCDTL.ACPTANODRSTATUSSYNCRF" + Environment.NewLine;
            selectTxt += "  AND SALDTL.SALESSLIPDTLNUMRF=STCDTL.SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;

            //���㗚���f�[�^(����)
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "  LEFT JOIN SALESHISTORYRF SALSLP" + Environment.NewLine;
            selectTxt += "  LEFT JOIN SALESHISTORYRF SALSLP WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += "  ON  SALSLP.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SALSLP.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "  AND SALSLP.SALESSLIPNUMRF=SALDTL.SALESSLIPNUMRF" + Environment.NewLine;

            //���_���ݒ�}�X�^
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS" + Environment.NewLine;
            selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += "  ON  SCINFS.ENTERPRISECODERF=STCSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SCINFS.SECTIONCODERF=STCSLP.STOCKSECTIONCDRF" + Environment.NewLine;

            #endregion  //[JOIN]

            //WHERE��
            selectTxt += MakeWhereString_STCDTL2(ref sqlCommand, paramWork, logicalMode);

            #endregion  //[�f�[�^���o���C��Query]

            // 2012/07/05 Y.Ito ADD START �����̓x�ɕ��я����قȂ錻�ۂ��C��
            selectTxt += " ORDER BY STCSLP.STOCKDATERF, STCSLP.PARTYSALESLIPNUMRF, STCSLP.SUPPLIERFORMALRF, STCSLP.SUPPLIERSLIPCDRF, STCDTL.STOCKROWNORF" + Environment.NewLine;
            // 2012/07/05 Y.Ito ADD END �����̓x�ɕ��я����قȂ錻�ۂ��C��

            selectTxt += " ) AS STCTBL" + Environment.NewLine;

            //ODER BY
            selectTxt += " ORDER BY ROWNUM DESC";
            #endregion

            return selectTxt;
        }
        #endregion  //[SuppPrtPprSalTblRsltWork�p SELECT���������� �ߋ����\���Ή�]
        // ------------Add 2009/09/08-------------<<<<<

        #region [�x���f�[�^�p SELECT����������]
        /// <summary>
        /// �x���f�[�^�pSELECT���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�x���f�[�^�pSELECT��</returns>
        /// <br>Note       : �x���f�[�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        private string MakeTypePaySlpQuery(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";

            // �Ώۃe�[�u��
            // PAYMENTSLPRF  PAYSLP �x���`�[�}�X�^
            // PAYMENTDTLRF  PAYDTL �x�����׃f�[�^

            #region [Select���쐬]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  ROW_NUMBER()" + Environment.NewLine;
            selectTxt += "   OVER(ORDER BY PAYTBL.PAYMENTDATERF)" + Environment.NewLine;
            selectTxt += "   AS ROWNUM" + Environment.NewLine;
            selectTxt += " ,*" + Environment.NewLine;
            selectTxt += " FROM (" + Environment.NewLine;

            #region [�f�[�^���o���C��Query]
            //������������𒴂���܂Ŏ擾
            selectTxt += "  SELECT TOP " + paramWork.SearchCnt + Environment.NewLine;
            selectTxt += "    PAYSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   ,PAYSLP.PAYMENTDATERF" + Environment.NewLine;
            selectTxt += "   ,PAYDTL.PAYMENTROWNORF" + Environment.NewLine;
            selectTxt += "   ,PAYSLP.PAYMENTAGENTNAMERF" + Environment.NewLine;
            selectTxt += "   ,PAYDTL.MONEYKINDNAMERF" + Environment.NewLine;
            selectTxt += "   ,PAYSLP.PAYMENTRF" + Environment.NewLine;
            selectTxt += "   ,PAYSLP.OUTLINERF" + Environment.NewLine;
            selectTxt += "   ,PAYDTL.VALIDITYTERMRF" + Environment.NewLine;
            selectTxt += "   ,PAYSLP.ADDUPSECCODERF" + Environment.NewLine;
            selectTxt += "   ,PAYSLP.PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
            selectTxt += "   ,PAYSLP.SUPPLIERCDRF" + Environment.NewLine;
            selectTxt += "   ,PAYSLP.SUPPLIERSNMRF" + Environment.NewLine;
            selectTxt += "   ,PAYSLP.PAYMENTSLIPNORF" + Environment.NewLine;
            selectTxt += "   ,PAYSLP.ADDUPADATERF" + Environment.NewLine;
            selectTxt += "   ,PAYSLP.DEBITNOTEDIVRF" + Environment.NewLine;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
            selectTxt += "   ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
            selectTxt += "   ,PAYSLP.PAYMENTTOTALRF" + Environment.NewLine;
            selectTxt += "   ,PAYSLP.FEEPAYMENTRF" + Environment.NewLine;
            selectTxt += "   ,PAYSLP.DISCOUNTPAYMENTRF" + Environment.NewLine;
            selectTxt += "   ,PAYDTL.PAYMENTRF AS DTLPAYMENTRF" + Environment.NewLine;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD
            selectTxt += "  FROM (" + Environment.NewLine;

            #region [�x���`�[�}�X�^���oQuery]
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     PAYSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,PAYSLPSUB.PAYMENTDATERF" + Environment.NewLine;
            selectTxt += "    ,PAYSLPSUB.PAYMENTAGENTNAMERF" + Environment.NewLine;
            selectTxt += "    ,PAYSLPSUB.PAYMENTRF" + Environment.NewLine;
            selectTxt += "    ,PAYSLPSUB.OUTLINERF" + Environment.NewLine;
            selectTxt += "    ,PAYSLPSUB.ADDUPSECCODERF" + Environment.NewLine;
            selectTxt += "    ,PAYSLPSUB.PAYMENTINPUTAGENTNMRF" + Environment.NewLine;
            selectTxt += "    ,PAYSLPSUB.SUPPLIERCDRF" + Environment.NewLine;
            selectTxt += "    ,PAYSLPSUB.SUPPLIERSNMRF" + Environment.NewLine;
            selectTxt += "    ,PAYSLPSUB.PAYMENTSLIPNORF" + Environment.NewLine;
            selectTxt += "    ,PAYSLPSUB.ADDUPADATERF" + Environment.NewLine;
            selectTxt += "    ,PAYSLPSUB.DEBITNOTEDIVRF" + Environment.NewLine;
            selectTxt += "    ,PAYSLPSUB.SUPPLIERFORMALRF" + Environment.NewLine;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
            selectTxt += "    ,PAYSLPSUB.PAYMENTTOTALRF" + Environment.NewLine;
            selectTxt += "    ,PAYSLPSUB.FEEPAYMENTRF" + Environment.NewLine;
            selectTxt += "    ,PAYSLPSUB.DISCOUNTPAYMENTRF" + Environment.NewLine;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "   FROM PAYMENTSLPRF AS PAYSLPSUB" + Environment.NewLine;
            selectTxt += "   FROM PAYMENTSLPRF AS PAYSLPSUB WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += MakeWhereString_PAYSLPSUB(ref sqlCommand, paramWork, logicalMode);
            #endregion  //[�x���`�[�}�X�^���oQuery]

            selectTxt += "  ) AS PAYSLP" + Environment.NewLine;

            //JOIN
            //�x�����׃f�[�^
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "  LEFT JOIN PAYMENTDTLRF PAYDTL" + Environment.NewLine;
            selectTxt += "  LEFT JOIN PAYMENTDTLRF PAYDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += "  ON  PAYDTL.ENTERPRISECODERF=PAYSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND PAYDTL.SUPPLIERFORMALRF=PAYSLP.SUPPLIERFORMALRF" + Environment.NewLine;
            selectTxt += "  AND PAYDTL.PAYMENTSLIPNORF=PAYSLP.PAYMENTSLIPNORF" + Environment.NewLine;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
            //JOIN
            //���_�}�X�^
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "  LEFT JOIN SECINFOSETRF SEC" + Environment.NewLine;
            selectTxt += "  LEFT JOIN SECINFOSETRF SEC WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += "  ON  SEC.ENTERPRISECODERF=PAYSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SEC.SECTIONCODERF=PAYSLP.ADDUPSECCODERF" + Environment.NewLine;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD

            #endregion  //[�f�[�^���o���C��Query]

            // 2012/07/05 Y.Ito ADD START �����̓x�ɕ��я����قȂ錻�ۂ��C��
            selectTxt += " ORDER BY PAYSLP.PAYMENTDATERF, PAYSLP.PAYMENTSLIPNORF, PAYSLP.SUPPLIERFORMALRF, PAYDTL.PAYMENTROWNORF" + Environment.NewLine;
            // 2012/07/05 Y.Ito ADD END �����̓x�ɕ��я����قȂ錻�ۂ��C��

            selectTxt += " ) AS PAYTBL" + Environment.NewLine;

            //ORDER BY
            selectTxt += " ORDER BY ROWNUM DESC";
            #endregion

            return selectTxt;
        }
        #endregion  //[SuppPrtPprSalTblRsltWork�p SELECT����������]

        #region [SuppPrtPprStcTblRsltWork�p WHERE���������� (�d���f�[�^SELECT�p)]
        /// <summary>
        /// �`�[�\���E���ו\���̃��X�g���o�pWHERE�� �������� (�d���f�[�^SELECT�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br></br>
        private string MakeWhereString_STCSLPSUB(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " STCSLPSUB.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STCSLPSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STCSLPSUB.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

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
                    //retstring += " AND STCSLPSUB.SECTIONCODERF IN (" + sectionCodestr + ") "; // DEL 2008.11.26
                    retstring += " AND STCSLPSUB.STOCKSECTIONCDRF IN (" + sectionCodestr + ") "; // ADD 2008.11.26 
                }
                retstring += Environment.NewLine;
            }

            //�d����R�[�h
            if (paramWork.SupplierCd != 0)
            {
                retstring += " AND STCSLPSUB.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCd);
            }

            //�x����R�[�h
            if (paramWork.PayeeCode != 0)
            {
                retstring += " AND STCSLPSUB.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.PayeeCode);
            }

            //�d����
            if (paramWork.St_StockDate != DateTime.MinValue)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                //retstring += " AND STCSLPSUB.STOCKDATERF>=@STSTOCKDATE" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                retstring += " AND ((SUPPLIERFORMALRF='0' AND STCSLPSUB.STOCKDATERF>=@STSTOCKDATE) OR (SUPPLIERFORMALRF='1' AND STCSLPSUB.ARRIVALGOODSDAYRF>=@STSTOCKDATE))" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                SqlParameter paraStStockDate = sqlCommand.Parameters.Add("@STSTOCKDATE", SqlDbType.Int);
                paraStStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_StockDate);
            }
            if (paramWork.Ed_StockDate != DateTime.MinValue)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                //retstring += " AND STCSLPSUB.STOCKDATERF<=@EDSTOCKDATE" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                retstring += " AND ((SUPPLIERFORMALRF='0' AND STCSLPSUB.STOCKDATERF<=@EDSTOCKDATE) OR (SUPPLIERFORMALRF='1' AND STCSLPSUB.ARRIVALGOODSDAYRF<=@EDSTOCKDATE))" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                SqlParameter paraEdStockDate = sqlCommand.Parameters.Add("@EDSTOCKDATE", SqlDbType.Int);
                paraEdStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_StockDate);
            }

            //���͓�
            if (paramWork.St_InputDay != DateTime.MinValue)
            {
                retstring += " AND STCSLPSUB.INPUTDAYRF>=@STINPUTDAY" + Environment.NewLine;
                SqlParameter paraStInputDay = sqlCommand.Parameters.Add("@STINPUTDAY", SqlDbType.Int);
                paraStInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_InputDay);
            }
            if (paramWork.Ed_InputDay != DateTime.MinValue)
            {
                retstring += " AND STCSLPSUB.INPUTDAYRF<=@EDINPUTDAY" + Environment.NewLine;
                SqlParameter paraEdInputDay = sqlCommand.Parameters.Add("@EDINPUTDAY", SqlDbType.Int);
                paraEdInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_InputDay);
            }

            //�d���`��
            if (paramWork.SupplierFormal != null)
            {
                string supplierFormalstr = "";
                foreach (Int32 isupFor in paramWork.SupplierFormal)
                {
                    if (supplierFormalstr != "")
                    {
                        supplierFormalstr += ",";
                    }
                    supplierFormalstr += isupFor.ToString();
                }
                if (supplierFormalstr != "")
                {
                    retstring += " AND STCSLPSUB.SUPPLIERFORMALRF IN (" + supplierFormalstr + ") ";
                }
                retstring += Environment.NewLine;
            }
            // ----------ADD 2013/01/21----------->>>>>
            retstring += " AND STCSLPSUB.SUPPLIERFORMALRF <> 3" + Environment.NewLine;
            // ----------ADD 2013/01/21-----------<<<<<

            // �C�� 2009/05/26 >>>
            // �����f�[�^�̒��o�͂����ł͍s��Ȃ�
            retstring += " AND STCSLPSUB.SUPPLIERFORMALRF != 2" + Environment.NewLine;
            // �C�� 2009/05/26 <<<
            //�d���`�[�敪
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
                    retstring += " AND STCSLPSUB.SUPPLIERSLIPCDRF IN (" + supplierSlipCdstr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�`�[�ԍ�(�����`�[�ԍ�) �������܂���������
            if (paramWork.PartySaleSlipNum != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.PartySaleSlipNum, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND STCSLPSUB.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUM" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCSLPSUB.PARTYSALESLIPNUMRF=@FINDPARTYSALESLIPNUM" + Environment.NewLine;
                }
                SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUM", SqlDbType.NVarChar);
                paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(paramWork.PartySaleSlipNum);
            }

            //�d��SEQ/�x����(�d���`�[�ԍ�)
            if (paramWork.PaymentSlipNo != 0)
            {
                retstring += " AND STCSLPSUB.SUPPLIERSLIPNORF>=@FINDSUPPLIERSLIPNO" + Environment.NewLine;
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(paramWork.PaymentSlipNo);
            }

            //�S����(�d���S���҃R�[�h)
            if (paramWork.StockAgentCode != "")
            {
                retstring += " AND STCSLPSUB.STOCKAGENTCODERF=@FINDSTOCKAGENTCODE" + Environment.NewLine;
                SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODE", SqlDbType.NChar);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(paramWork.StockAgentCode);
            }

            //���s��(�d�����͎҃R�[�h)
            if (paramWork.StockInputCode != "")
            {
                retstring += " AND STCSLPSUB.STOCKINPUTCODERF=@FINDSTOCKINPUTCODE" + Environment.NewLine;
                SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@FINDSTOCKINPUTCODE", SqlDbType.NChar);
                paraStockInputCode.Value = SqlDataMediator.SqlSetString(paramWork.StockInputCode);
            }

            //���l�P(�d���`�[���l1) �������܂���������
            if (paramWork.SupplierSlipNote1 != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SupplierSlipNote1, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND STCSLPSUB.SUPPLIERSLIPNOTE1RF LIKE @FINDSUPPLIERSLIPNOTE1" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCSLPSUB.SUPPLIERSLIPNOTE1RF=@FINDSUPPLIERSLIPNOTE1" + Environment.NewLine;
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
                    retstring += " AND STCSLPSUB.SUPPLIERSLIPNOTE2RF LIKE @FINDSUPPLIERSLIPNOTE2" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCSLPSUB.SUPPLIERSLIPNOTE2RF=@FINDSUPPLIERSLIPNOTE2" + Environment.NewLine;
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
                    retstring += " AND STCSLPSUB.UOEREMARK1RF LIKE @FINDUOEREMARK1" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCSLPSUB.UOEREMARK1RF=@FINDUOEREMARK1" + Environment.NewLine;
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
                    retstring += " AND STCSLPSUB.UOEREMARK2RF LIKE @FINDUOEREMARK2" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCSLPSUB.UOEREMARK2RF=@FINDUOEREMARK2" + Environment.NewLine;
                }
                SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@FINDUOEREMARK2", SqlDbType.NVarChar);
                paraUoeRemark2.Value = SqlDataMediator.SqlSetString(paramWork.UoeRemark2);
            }
            #endregion

            return retstring;
        }
        #endregion  //[SuppPrtPprSalTblRsltWork�p WHERE���������� (�d���f�[�^SELECT�p)]

        // ------------Add 2009/09/08------------->>>>>
        #region [SuppPrtPprStcTblRsltWork�p WHERE���������� (�d���f�[�^SELECT�p) �ߋ����\���Ή�]
        /// <summary>
        /// �`�[�\���E���ו\���̃��X�g���o�pWHERE�� �������� (�d���f�[�^SELECT�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ���̕�</br>
        /// <br>Date       : 2009/09/08</br>
        /// <br></br>
        /// </remarks>
        private string MakeWhereString_STCSLPSUB2(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " STCSLPSUB.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STCSLPSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STCSLPSUB.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

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
                    retstring += " AND STCSLPSUB.STOCKSECTIONCDRF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�d����R�[�h
            if (paramWork.SupplierCd != 0)
            {
                retstring += " AND STCSLPSUB.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCd);
            }

            //�x����R�[�h
            if (paramWork.PayeeCode != 0)
            {
                retstring += " AND STCSLPSUB.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.PayeeCode);
            }

            //�d����
            if (paramWork.St_StockDate != DateTime.MinValue)
            {
                // -- UPD 2010/05/10 --------------------------------------->>>
                //retstring += " AND ((SUPPLIERFORMALRF='0' AND STCSLPSUB.STOCKDATERF>=@STSTOCKDATE) OR (SUPPLIERFORMALRF='1' AND STCSLPSUB.ARRIVALGOODSDAYRF>=@STSTOCKDATE))" + Environment.NewLine;
                //SqlParameter paraStStockDate = sqlCommand.Parameters.Add("@STSTOCKDATE", SqlDbType.Int);
                //paraStStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_StockDate);

                retstring += " AND STCSLPSUB.STOCKDATERF>=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_StockDate).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 ---------------------------------------<<<
            }
            if (paramWork.Ed_StockDate != DateTime.MinValue)
            {
                // -- UPD 2010/05/10 --------------------------------------->>>
                //retstring += " AND ((SUPPLIERFORMALRF='0' AND STCSLPSUB.STOCKDATERF<=@EDSTOCKDATE) OR (SUPPLIERFORMALRF='1' AND STCSLPSUB.ARRIVALGOODSDAYRF<=@EDSTOCKDATE))" + Environment.NewLine;
                //SqlParameter paraEdStockDate = sqlCommand.Parameters.Add("@EDSTOCKDATE", SqlDbType.Int);
                //paraEdStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_StockDate);

                retstring += " AND STCSLPSUB.STOCKDATERF<=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_StockDate).ToString() + Environment.NewLine;
                // -- UPD 2010/05/10 ---------------------------------------<<<
            }

            //���͓�
            if (paramWork.St_InputDay != DateTime.MinValue)
            {
                retstring += " AND STCSLPSUB.INPUTDAYRF>=@STINPUTDAY" + Environment.NewLine;
                SqlParameter paraStInputDay = sqlCommand.Parameters.Add("@STINPUTDAY", SqlDbType.Int);
                paraStInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_InputDay);
            }
            if (paramWork.Ed_InputDay != DateTime.MinValue)
            {
                retstring += " AND STCSLPSUB.INPUTDAYRF<=@EDINPUTDAY" + Environment.NewLine;
                SqlParameter paraEdInputDay = sqlCommand.Parameters.Add("@EDINPUTDAY", SqlDbType.Int);
                paraEdInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_InputDay);
            }

            //�d���`��
            if (paramWork.SupplierFormal != null)
            {
                string supplierFormalstr = "";
                foreach (Int32 isupFor in paramWork.SupplierFormal)
                {
                    if (supplierFormalstr != "")
                    {
                        supplierFormalstr += ",";
                    }
                    supplierFormalstr += isupFor.ToString();
                }
                if (supplierFormalstr != "")
                {
                    retstring += " AND STCSLPSUB.SUPPLIERFORMALRF IN (" + supplierFormalstr + ") ";
                }
                retstring += Environment.NewLine;
            }
            // ----------ADD 2013/01/21----------->>>>>
            retstring += " AND STCSLPSUB.SUPPLIERFORMALRF <> 3" + Environment.NewLine;
            // ----------ADD 2013/01/21-----------<<<<<

            // �����f�[�^�̒��o�͂����ł͍s��Ȃ�
            retstring += " AND STCSLPSUB.SUPPLIERFORMALRF != 2" + Environment.NewLine;
            //�d���`�[�敪
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
                    retstring += " AND STCSLPSUB.SUPPLIERSLIPCDRF IN (" + supplierSlipCdstr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�`�[�ԍ�(�����`�[�ԍ�) �������܂���������
            if (paramWork.PartySaleSlipNum != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.PartySaleSlipNum, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND STCSLPSUB.PARTYSALESLIPNUMRF LIKE @FINDPARTYSALESLIPNUM" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCSLPSUB.PARTYSALESLIPNUMRF=@FINDPARTYSALESLIPNUM" + Environment.NewLine;
                }
                SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUM", SqlDbType.NVarChar);
                paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(paramWork.PartySaleSlipNum);
            }

            //�d��SEQ/�x����(�d���`�[�ԍ�)
            if (paramWork.PaymentSlipNo != 0)
            {
                retstring += " AND STCSLPSUB.SUPPLIERSLIPNORF>=@FINDSUPPLIERSLIPNO" + Environment.NewLine;
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(paramWork.PaymentSlipNo);
            }

            //�S����(�d���S���҃R�[�h)
            if (paramWork.StockAgentCode != "")
            {
                retstring += " AND STCSLPSUB.STOCKAGENTCODERF=@FINDSTOCKAGENTCODE" + Environment.NewLine;
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
                    retstring += " AND STCSLPSUB.SUPPLIERSLIPNOTE1RF LIKE @FINDSUPPLIERSLIPNOTE1" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCSLPSUB.SUPPLIERSLIPNOTE1RF=@FINDSUPPLIERSLIPNOTE1" + Environment.NewLine;
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
                    retstring += " AND STCSLPSUB.SUPPLIERSLIPNOTE2RF LIKE @FINDSUPPLIERSLIPNOTE2" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCSLPSUB.SUPPLIERSLIPNOTE2RF=@FINDSUPPLIERSLIPNOTE2" + Environment.NewLine;
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
                    retstring += " AND STCSLPSUB.UOEREMARK1RF LIKE @FINDUOEREMARK1" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCSLPSUB.UOEREMARK1RF=@FINDUOEREMARK1" + Environment.NewLine;
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
                    retstring += " AND STCSLPSUB.UOEREMARK2RF LIKE @FINDUOEREMARK2" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCSLPSUB.UOEREMARK2RF=@FINDUOEREMARK2" + Environment.NewLine;
                }
                SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@FINDUOEREMARK2", SqlDbType.NVarChar);
                paraUoeRemark2.Value = SqlDataMediator.SqlSetString(paramWork.UoeRemark2);
            }
            #endregion

            return retstring;
        }
        #endregion  //[SuppPrtPprSalTblRsltWork�p WHERE���������� (�d���f�[�^SELECT�p) �ߋ����\���Ή�]
        // ------------Add 2009/09/08-------------<<<<<

        #region [SuppPrtPprStcTblRsltWork�p WHERE���������� (�d�����׃f�[�^SELECT�p)]
        /// <summary>
        /// �`�[�\���E���ו\���̃��X�g���o�pWHERE�� �������� (�d�����׃f�[�^SELECT�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br>Update Note: 2012/08/09 wangf </br>
        /// <br>           : 10801804-00�A9/12�z�M���ARedmine#31533 �d����d�q���� �i�Ԏw�莞�̒��o�s���̑Ή�</br>
        /// <br>           : �i�Ԃ��n�C�t�������œ��͂����ꍇ�A�d����d�q�����͓��Ӑ�d�q�����Ɠ����悤�ɒ��o�\�ɂȂ�܂��B</br>
        /// <br></br>
        private string MakeWhereString_STCDTL(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " STCDTL.ENTERPRISECODERF=@ENTERPRISECODE2" + Environment.NewLine;
            SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@ENTERPRISECODE2", SqlDbType.NChar);
            paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�t�n�d����(�������@)
            if (paramWork.WayToOrder != 0)
            {
                if (paramWork.WayToOrder == 2)
                {
                    //UOE���M -> UOE���M�̂�
                    retstring += " AND STCDTL.WAYTOORDERRF=2" + Environment.NewLine;
                }
                else
                {
                    //�ʏ� -> UOE���M�ȊO
                    retstring += "AND STCDTL.WAYTOORDERRF<>2 " + Environment.NewLine;
                }
            }

            //�a�k�O���[�v(BL�O���[�v�R�[�h)
            if (paramWork.BLGroupCode != 0)
            {
                retstring += " AND STCDTL.BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGroupCode);
            }

            //�a�k�R�[�h(BL���i�R�[�h)
            if (paramWork.BLGoodsCode != 0)
            {
                retstring += " AND STCDTL.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
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
                    retstring += " AND STCDTL.GOODSNAMERF LIKE @FINDGOODSNAME" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCDTL.GOODSNAMERF=@FINDGOODSNAME" + Environment.NewLine;
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
                    //retstring += " AND STCDTL.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine; // DEL wangf 2012/08/09 FOR Redmine#31533
                    // ------------ADD wangf 2012/08/09 FOR Redmine#31533--------->>>>
                    if (paramWork.GoodsNo.Contains(HORIZONTAL_LINE))
                    {
                        retstring += " AND STCDTL.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND REPLACE(STCDTL.GOODSNORF, '" + HORIZONTAL_LINE + "', '') LIKE @FINDGOODSNO" + Environment.NewLine;
                    }
                    // ------------ADD wangf 2012/08/09 FOR Redmine#31533---------<<<<
                }
                else
                {
                    //�����܂���������Ȃ�
                    //retstring += " AND STCDTL.GOODSNORF=@FINDGOODSNO" + Environment.NewLine; // DEL wangf 2012/08/09 FOR Redmine#31533
                    // ------------ADD wangf 2012/08/09 FOR Redmine#31533--------->>>>
                    if (paramWork.GoodsNo.Contains(HORIZONTAL_LINE))
                    {
                        retstring += " AND STCDTL.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND REPLACE(STCDTL.GOODSNORF, '" + HORIZONTAL_LINE + "', '') = @FINDGOODSNO" + Environment.NewLine;
                    }
                    // ------------ADD wangf 2012/08/09 FOR Redmine#31533---------<<<<
                }
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNo);
            }

            //���[�J�[(���i���[�J�[�R�[�h)
            if (paramWork.GoodsMakerCd != 0)
            {
                retstring += "AND STCDTL.GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCd);
            }

            //�݌Ɏ��敪(�d���݌Ɏ�񂹋敪)
            if (paramWork.StockOrderDivCd != -1)
            {
                retstring += "AND STCDTL.STOCKORDERDIVCDRF=@FINDSTOCKORDERDIVCD" + Environment.NewLine;
                SqlParameter paraStockOrderDivCd = sqlCommand.Parameters.Add("@FINDSTOCKORDERDIVCD", SqlDbType.Int);
                paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(paramWork.StockOrderDivCd);
            }

            //�q�ɃR�[�h
            if (paramWork.WarehouseCode != "")
            {
                retstring += "AND STCDTL.WAREHOUSECODERF=@FINDWAREHOUSECODE " + Environment.NewLine;
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
            // �l���敪
            if (paramWork.StockSlipCdDtl == 1)
            {
                // 1:�l������
                retstring += " AND STCDTL.STOCKSLIPCDDTLRF<>@FINDSTOCKSLIPCDDTL" + Environment.NewLine;
                SqlParameter paraStockSlipCdDtl = sqlCommand.Parameters.Add("@FINDSTOCKSLIPCDDTL", SqlDbType.Int);
                paraStockSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(2);
            }
            else if (paramWork.StockSlipCdDtl == 2)
            {
                // 2:�l���̂�
                retstring += " AND STCDTL.STOCKSLIPCDDTLRF=@FINDSTOCKSLIPCDDTL" + Environment.NewLine;
                SqlParameter paraStockSlipCdDtl = sqlCommand.Parameters.Add("@FINDSTOCKSLIPCDDTL", SqlDbType.Int);
                paraStockSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(2);
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD
            #endregion

            return retstring;
        }
        #endregion  //[SuppPrtPprStcTblRsltWork�p WHERE���������� (�d���f�[�^SELECT�p)]

        // ------------Add 2009/09/08------------->>>>>
        #region [SuppPrtPprStcTblRsltWork�p WHERE���������� (�d�����׃f�[�^SELECT�p) �ߋ����\���Ή�]
        /// <summary>
        /// �`�[�\���E���ו\���̃��X�g���o�pWHERE�� �������� (�d�����׃f�[�^SELECT�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>Where����������</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ���̕�</br>
        /// <br>Date       : 2009/09/08</br>
        /// <br>Update Note: 2012/08/09 wangf </br>
        /// <br>           : 10801804-00�A9/12�z�M���ARedmine#31533 �d����d�q���� �i�Ԏw�莞�̒��o�s���̑Ή�</br>
        /// <br>           : �i�Ԃ��n�C�t�������œ��͂����ꍇ�A�d����d�q�����͓��Ӑ�d�q�����Ɠ����悤�ɒ��o�\�ɂȂ�܂��B</br>
        /// <br></br>
        /// </remarks>
        private string MakeWhereString_STCDTL2(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " STCDTL.ENTERPRISECODERF=@ENTERPRISECODE2" + Environment.NewLine;
            SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@ENTERPRISECODE2", SqlDbType.NChar);
            paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�t�n�d����(�������@)
            if (paramWork.WayToOrder != 0)
            {
                if (paramWork.WayToOrder == 2)
                {
                    //UOE���M -> UOE���M�̂�
                    #region DEL 2013/02/07 BY ������ For Redmine#34611
                    // --- DEL 2013/02/07 BY ������ For Redmine#34611 -------------------------------->>>>>
                    //retstring += " AND EXISTS ( SELECT * " + Environment.NewLine;
                    //// 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
                    ////retstring += " FROM UOEORDERDTLRF " + Environment.NewLine;
                    //retstring += " FROM UOEORDERDTLRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    //// 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
                    //retstring += " WHERE " + Environment.NewLine;
                    //retstring += " UOEORDERDTLRF.COMMONSEQNORF = STCDTL.COMMONSEQNORF " + Environment.NewLine;
                    //retstring += " AND UOEORDERDTLRF.ENTERPRISECODERF = STCDTL.ENTERPRISECODERF " + Environment.NewLine;
                    //retstring += " AND UOEORDERDTLRF.LOGICALDELETECODERF = 0)" + Environment.NewLine;
                    // --- DEL 2013/02/07 BY ������ For Redmine#34611 --------------------------------<<<<<
                    #endregion
                    retstring += " AND EXISTS ( " + GetOnLineOrder() + ")";// ADD 2013/02/07 BY ������ For Redmine#34611
                }
                else
                {
                    //�ʏ� -> UOE���M�ȊO
                    #region DEL 2013/02/07 BY ������ For Redmine#34611
                    // --- DEL 2013/02/07 BY ������ For Redmine#34611 -------------------------------->>>>>
                    //retstring += " AND NOT EXISTS ( SELECT * " + Environment.NewLine;
                    //// 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
                    ////retstring += " FROM UOEORDERDTLRF " + Environment.NewLine;
                    //retstring += " FROM UOEORDERDTLRF WITH (READUNCOMMITTED) " + Environment.NewLine;
                    //// 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
                    //retstring += " WHERE " + Environment.NewLine;
                    //retstring += " UOEORDERDTLRF.COMMONSEQNORF = STCDTL.COMMONSEQNORF " + Environment.NewLine;
                    //retstring += " AND UOEORDERDTLRF.ENTERPRISECODERF = STCDTL.ENTERPRISECODERF " + Environment.NewLine;
                    //retstring += " AND UOEORDERDTLRF.LOGICALDELETECODERF = 0)" + Environment.NewLine;
                    // --- DEL 2013/02/07 BY ������ For Redmine#34611 --------------------------------<<<<<
                    #endregion
                    retstring += " AND NOT EXISTS ( " + GetOnLineOrder() + ")";// ADD 2013/02/07 BY ������ For Redmine#34611
                }
            }

            //�a�k�O���[�v(BL�O���[�v�R�[�h)
            if (paramWork.BLGroupCode != 0)
            {
                retstring += " AND STCDTL.BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGroupCode);
            }

            //�a�k�R�[�h(BL���i�R�[�h)
            if (paramWork.BLGoodsCode != 0)
            {
                retstring += " AND STCDTL.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
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
                    retstring += " AND STCDTL.GOODSNAMERF LIKE @FINDGOODSNAME" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCDTL.GOODSNAMERF=@FINDGOODSNAME" + Environment.NewLine;
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
                    //retstring += " AND STCDTL.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine; // DEL wangf 2012/08/09 FOR Redmine#31533
                    // ------------ADD wangf 2012/08/09 FOR Redmine#31533--------->>>>
                    if (paramWork.GoodsNo.Contains(HORIZONTAL_LINE))
                    {
                        retstring += " AND STCDTL.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND REPLACE(STCDTL.GOODSNORF, '" + HORIZONTAL_LINE + "', '') LIKE @FINDGOODSNO" + Environment.NewLine;
                    }
                    // ------------ADD wangf 2012/08/09 FOR Redmine#31533---------<<<<
                }
                else
                {
                    //�����܂���������Ȃ�
                    //retstring += " AND STCDTL.GOODSNORF=@FINDGOODSNO" + Environment.NewLine; // DEL wangf 2012/08/09 FOR Redmine#31533
                    // ------------ADD wangf 2012/08/09 FOR Redmine#31533--------->>>>
                    if (paramWork.GoodsNo.Contains(HORIZONTAL_LINE))
                    {
                        retstring += " AND STCDTL.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND REPLACE(STCDTL.GOODSNORF, '" + HORIZONTAL_LINE + "', '') = @FINDGOODSNO" + Environment.NewLine;
                    }
                    // ------------ADD wangf 2012/08/09 FOR Redmine#31533---------<<<<
                }
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNo);
            }

            //���[�J�[(���i���[�J�[�R�[�h)
            if (paramWork.GoodsMakerCd != 0)
            {
                retstring += "AND STCDTL.GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCd);
            }

            //�݌Ɏ��敪(�d���݌Ɏ�񂹋敪)
            if (paramWork.StockOrderDivCd != -1)
            {
                retstring += "AND STCDTL.STOCKORDERDIVCDRF=@FINDSTOCKORDERDIVCD" + Environment.NewLine;
                SqlParameter paraStockOrderDivCd = sqlCommand.Parameters.Add("@FINDSTOCKORDERDIVCD", SqlDbType.Int);
                paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(paramWork.StockOrderDivCd);
            }

            //�q�ɃR�[�h
            if (paramWork.WarehouseCode != "")
            {
                retstring += "AND STCDTL.WAREHOUSECODERF=@FINDWAREHOUSECODE " + Environment.NewLine;
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
            }

            // �l���敪
            if (paramWork.StockSlipCdDtl == 1)
            {
                // 1:�l������
                retstring += " AND STCDTL.STOCKSLIPCDDTLRF<>@FINDSTOCKSLIPCDDTL" + Environment.NewLine;
                SqlParameter paraStockSlipCdDtl = sqlCommand.Parameters.Add("@FINDSTOCKSLIPCDDTL", SqlDbType.Int);
                paraStockSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(2);
            }
            else if (paramWork.StockSlipCdDtl == 2)
            {
                // 2:�l���̂�
                retstring += " AND STCDTL.STOCKSLIPCDDTLRF=@FINDSTOCKSLIPCDDTL" + Environment.NewLine;
                SqlParameter paraStockSlipCdDtl = sqlCommand.Parameters.Add("@FINDSTOCKSLIPCDDTL", SqlDbType.Int);
                paraStockSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(2);
            }
            #endregion

            return retstring;
        }

        // --- ADD 2013/02/07 BY ������ For Redmine#34611 -------------------------------->>>>>
        /// <summary>
        /// �I�����C�����������N�G���̎擾
        /// </summary>
        ///<returns>�I�����C�������̌����N�G��</returns>
        private string GetOnLineOrder()
        {
            // UOE�f�[�^�̌���
            // ���������͈ȉ��ł��B
            // �d�����𖾍׃f�[�^�D��ƃR�[�h=�d�����׃f�[�^�D��ƃR�[�h 
            // �d�����𖾍׃f�[�^�D�d���`���i���j=�d�����׃f�[�^�D�d���`��
            // �d�����𖾍׃f�[�^�D�d�����גʔԁi���j=�d�����׃f�[�^�D�d�����גʔ� 
            // �d�����׃f�[�^.�������@ = 2
            // �d�����׃f�[�^.�_���폜�敪 = 0

            StringBuilder sqlStringBulid = new StringBuilder();
            sqlStringBulid.Append(" SELECT * ").Append(Environment.NewLine);
            sqlStringBulid.Append(" FROM STOCKDETAILRF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
            sqlStringBulid.Append(" WHERE ENTERPRISECODERF = STCDTL.ENTERPRISECODERF ").Append(Environment.NewLine);
            sqlStringBulid.Append(" AND STOCKSLIPDTLNUMRF = STCDTL.STOCKSLIPDTLNUMSRCRF ").Append(Environment.NewLine);
            sqlStringBulid.Append(" AND SUPPLIERFORMALRF = STCDTL.SUPPLIERFORMALSRCRF ").Append(Environment.NewLine);
            sqlStringBulid.Append(" AND WAYTOORDERRF = 2 ").Append(Environment.NewLine);
            sqlStringBulid.Append(" AND LOGICALDELETECODERF = 0 ").Append(Environment.NewLine);

            return sqlStringBulid.ToString();
        }
        // --- ADD 2013/02/07 BY ������ For Redmine#34611 --------------------------------<<<<<
        #endregion  //[SuppPrtPprStcTblRsltWork�p WHERE���������� (�d���f�[�^SELECT�p) �ߋ����\���Ή�]
        // ------------Add 2009/09/08-------------<<<<<

        #region [SuppPrtPprStcTblRsltWork�p WHERE���������� (�x���f�[�^SELECT�p)]
        /// <summary>
        /// �`�[�\���E���ו\���̃��X�g���o�pWHERE�� �������� (�x���f�[�^SELECT�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br></br>
        private string MakeWhereString_PAYSLPSUB(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " PAYSLPSUB.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND PAYSLPSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND PAYSLPSUB.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

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

                    retstring += " AND PAYSLPSUB.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�d����R�[�h
            if (paramWork.SupplierCd != 0)
            {
                retstring += " AND PAYSLPSUB.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCd);
            }

            //�x����R�[�h
            if (paramWork.PayeeCode != 0)
            {
                retstring += " AND PAYSLPSUB.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.PayeeCode);
            }

            //�`�[���t(�x�����t)
            if (paramWork.St_StockDate != DateTime.MinValue)
            {
                retstring += " AND PAYSLPSUB.PAYMENTDATERF>=@STPAYMENTDATE" + Environment.NewLine;
                SqlParameter paraStPaymentDate = sqlCommand.Parameters.Add("@STPAYMENTDATE", SqlDbType.Int);
                paraStPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_StockDate);
            }
            if (paramWork.Ed_StockDate != DateTime.MinValue)
            {
                retstring += " AND PAYSLPSUB.PAYMENTDATERF<=@EDPAYMENTDATE" + Environment.NewLine;
                SqlParameter paraEdPaymentDate = sqlCommand.Parameters.Add("@EDPAYMENTDATE", SqlDbType.Int);
                paraEdPaymentDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_StockDate);
            }

            // �C�� 2009/05/26 >>>
            if (paramWork.St_InputDay != DateTime.MinValue)
            {
                retstring += " AND PAYSLPSUB.INPUTDAYRF>=@STINPUTDAYRF" + Environment.NewLine;
                SqlParameter paraStInputDay = sqlCommand.Parameters.Add("@STINPUTDAYRF", SqlDbType.Int);
                paraStInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_InputDay);

            }
            if (paramWork.Ed_InputDay != DateTime.MinValue)
            {
                retstring += " AND PAYSLPSUB.INPUTDAYRF<=@EDINPUTDAYRF" + Environment.NewLine;
                SqlParameter paraEdInputDay = sqlCommand.Parameters.Add("@EDINPUTDAYRF", SqlDbType.Int);
                paraEdInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_InputDay);

            }
            // �C�� 2009/05/26 <<<

            //�d��SEQ/�x����(�d���`�[�ԍ�/�x���`�[�ԍ�)
            if (paramWork.PaymentSlipNo != 0)
            {
                retstring += " AND PAYSLPSUB.SUPPLIERSLIPNORF>=@FINDSUPPLIERSLIPNO" + Environment.NewLine;
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(paramWork.PaymentSlipNo);

                retstring += " AND PAYSLPSUB.PAYMENTSLIPNORF>=@FINDPAYMENTSLIPNO" + Environment.NewLine;
                SqlParameter paraPaymentSlipNo = sqlCommand.Parameters.Add("@FINDPAYMENTSLIPNO", SqlDbType.Int);
                paraPaymentSlipNo.Value = SqlDataMediator.SqlSetInt32(paramWork.PaymentSlipNo);
            }

            //�S����(�x���S���҃R�[�h)
            if (paramWork.StockAgentCode != "")
            {
                retstring += " AND PAYSLPSUB.PAYMENTAGENTCODERF=@FINDPAYMENTAGENTCODE" + Environment.NewLine;
                SqlParameter paraPaymentAgentCode = sqlCommand.Parameters.Add("@FINDPAYMENTAGENTCODE", SqlDbType.NChar);
                paraPaymentAgentCode.Value = SqlDataMediator.SqlSetString(paramWork.StockAgentCode);
            }

            //���s��(�x�����͎҃R�[�h)
            if (paramWork.StockInputCode != "")
            {
                retstring += "AND PAYSLPSUB.PAYMENTINPUTAGENTCDRF=@FINDPAYMENTINPUTAGENTCD" + Environment.NewLine;
                SqlParameter paraPaymentInputAgentCd = sqlCommand.Parameters.Add("@FINDPAYMENTINPUTAGENTCD", SqlDbType.NChar);
                paraPaymentInputAgentCd.Value = SqlDataMediator.SqlSetString(paramWork.StockInputCode);
            }

            //���l�P(�`�[�E�v) �������܂���������
            if (paramWork.SupplierSlipNote1 != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SupplierSlipNote1, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += "AND PAYSLPSUB.OUTLINERF LIKE @FINDOUTLINE" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += "AND PAYSLPSUB.OUTLINERF=@FINDOUTLINE" + Environment.NewLine;
                }
                SqlParameter paraOutline = sqlCommand.Parameters.Add("@FINDOUTLINE", SqlDbType.NVarChar);
                paraOutline.Value = SqlDataMediator.SqlSetString(paramWork.SupplierSlipNote1);
            }
            #endregion

            return retstring;
        }
        #endregion  //[SuppPrtPprStcTblRsltWork�p WHERE���������� (�x���f�[�^SELECT�p)]

        #region [SuppPrtPprStcTblRsltWork���� �ďo]
        /// <summary>
        /// �N���X�i�[���� Reader �� SuppPrtPprStcTblRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">SuppPrtPprWork</param>
        /// <param name="iParam">�����^�C�v 0:�d���f�[�^ 1:�x���f�[�^</param>
        /// <returns></returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        public object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork, int iParam)
        {
            SuppPrtPprWork _suppPrtPprWork = paramWork as SuppPrtPprWork;
            return this.CopyToResultWorkFromReaderProc(ref myReader, _suppPrtPprWork, iParam);
        }
        #endregion  //[SuppPrtPprStcTblRsltWork���� �ďo]

        #region [SuppPrtPprStcTblRsltWork����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SuppPrtPprStcTblRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">SuppPrtPprWork</param>
        /// <param name="iType">�����^�C�v 0:�d���f�[�^ 1:�x���f�[�^</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.08.18</br>
        /// <br>Update Note: 2009/09/08 ���̕� �ߋ����\���Ή�</br>
        /// <br>Update Note: 2012/10/15 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A2012/11/14�z�M��</br>
        /// <br>             Redmine#32862 ���i�ύX�������ׁA�F��ς���悤�ɏC��</br>
        /// <br>Update Note: 2020/03/11 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 �y���ŗ��Ή�</br>
        /// <br>           : �`�[�^�u�A���׃^�u�Ɂu����ŗ��v���ڂ�ǉ�</br>
        /// </remarks>
        private SuppPrtPprStcTblRsltWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, SuppPrtPprWork paramWork, int iType)
        {
            #region ���o����-�l�Z�b�g
            SuppPrtPprStcTblRsltWork resultWork = new SuppPrtPprStcTblRsltWork();

            if (iType == (int)iSrcType.StcTbl)
            {
                #region [�d���f�[�^]
                resultWork.DataDiv = 0;
                resultWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
                resultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                resultWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
                resultWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                resultWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
                resultWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/25 DEL
                //resultWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/25 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/25 ADD
                resultWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/25 ADD
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
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/25 DEL
                //resultWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/25 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/25 ADD
                resultWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF")); // ���v���z(�ō�)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/25 ADD
                resultWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
                resultWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));// ADD ���V�� 2020/03/11 PMKOBETSU-2912
                resultWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
                resultWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
                resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // ADD 2008.10.21
                resultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                // resultWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF")); // DEL 2009/09/08
                resultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                resultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                resultWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
                resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF")); // ADD 2008.10.21
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
                // ADD 2008.10.30 >>>
                resultWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
                resultWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
                resultWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
                resultWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
                // ADD 2008.10.30 <<<
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
                resultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                resultWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                resultWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
                resultWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                resultWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
                resultWork.StockPriceConsTaxDtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTLSTOCKPRICECONSTAXRF"));
                resultWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
                // ----------- ADD 2012/10/15 �c���� ------------>>>>>
                resultWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
                resultWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
                // ----------- ADD 2012/10/15 �c���� ------------<<<<<

                // ���ׂ̏ꍇ�͓��ד��ŏ���������
                if (resultWork.SupplierFormal == 1)
                {
                    resultWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD


                // ----------ADD 2013/01/21----------->>>>>
                resultWork.StockSectionCd = resultWork.StockSectionCd ?? string.Empty;
                resultWork.StockInputCode = resultWork.StockInputCode ?? string.Empty;
                resultWork.StockAgentCode = resultWork.StockAgentCode ?? string.Empty;
                resultWork.MakerKanaName = resultWork.MakerKanaName ?? string.Empty;
                resultWork.CmpltMakerKanaName = resultWork.CmpltMakerKanaName ?? string.Empty;
                resultWork.GoodsNameKana = resultWork.GoodsNameKana ?? string.Empty;
                resultWork.GoodsLGroupName = resultWork.GoodsLGroupName ?? string.Empty;
                resultWork.GoodsMGroupName = resultWork.GoodsMGroupName ?? string.Empty;
                resultWork.BLGroupName = resultWork.BLGroupName ?? string.Empty;
                resultWork.BLGoodsFullName = resultWork.BLGoodsFullName ?? string.Empty;
                resultWork.RateSectStckUnPrc = resultWork.RateSectStckUnPrc ?? string.Empty;
                resultWork.RateDivStckUnPrc = resultWork.RateDivStckUnPrc ?? string.Empty;
                resultWork.RateBLGoodsName = resultWork.RateBLGoodsName ?? string.Empty;
                resultWork.RateGoodsRateGrpNm = resultWork.RateGoodsRateGrpNm ?? string.Empty;
                resultWork.RateBLGroupName = resultWork.RateBLGroupName ?? string.Empty;
                resultWork.StockDtiSlipNote1 = resultWork.StockDtiSlipNote1 ?? string.Empty;
                resultWork.SalesCustomerSnm = resultWork.SalesCustomerSnm ?? string.Empty;
                resultWork.SlipMemo1 = resultWork.SlipMemo1 ?? string.Empty;
                resultWork.SlipMemo2 = resultWork.SlipMemo2 ?? string.Empty;
                resultWork.SlipMemo3 = resultWork.SlipMemo3 ?? string.Empty;
                resultWork.InsideMemo1 = resultWork.InsideMemo1 ?? string.Empty;
                resultWork.InsideMemo2 = resultWork.InsideMemo2 ?? string.Empty;
                resultWork.InsideMemo3 = resultWork.InsideMemo3 ?? string.Empty;
                resultWork.AddresseeName = resultWork.AddresseeName ?? string.Empty;
                resultWork.OrderNumber = resultWork.OrderNumber ?? string.Empty;

                resultWork.EnterpriseGanreName = resultWork.EnterpriseGanreName ?? string.Empty;
                resultWork.GoodsRateRank = resultWork.GoodsRateRank ?? string.Empty;
                resultWork.StockAddUpSectionCd = resultWork.StockAddUpSectionCd ?? string.Empty;
                resultWork.BusinessTypeName = resultWork.BusinessTypeName ?? string.Empty;
                resultWork.SalesAreaName = resultWork.SalesAreaName ?? string.Empty;
                resultWork.SlpAddresseeName = resultWork.SlpAddresseeName ?? string.Empty;
                resultWork.AddresseeName2 =resultWork.AddresseeName2 ?? string.Empty;
                resultWork.AddresseePostNo = resultWork.AddresseePostNo ?? string.Empty;
                resultWork.AddresseeAddr1 = resultWork.AddresseeAddr1 ?? string.Empty;
                resultWork.AddresseeAddr3 = resultWork.AddresseeAddr3 ?? string.Empty;
                resultWork.AddresseeAddr4 = resultWork.AddresseeAddr4 ?? string.Empty;
                resultWork.AddresseeTelNo = resultWork.AddresseeTelNo ?? string.Empty;
                resultWork.AddresseeFaxNo = resultWork.AddresseeFaxNo ?? string.Empty;

                // ----------ADD 2013/01/21-----------<<<<<

                #endregion  //[�d���f�[�^]
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
            else if (iType == (int)iSrcType.StcTblOdr)
            {
                # region [�d���f�[�^(����)]
                resultWork.DataDiv = 0;
                //resultWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "STOCKDATERF" ) );
                //resultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTYSALESLIPNUMRF" ) );
                resultWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
                //resultWork.SupplierFormal = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPLIERFORMALRF" ) );
                resultWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
                resultWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/25 DEL
                //resultWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/25 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/25 ADD
                resultWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/25 ADD
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
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/25 DEL
                //resultWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/25 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/25 ADD
                resultWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF")); // ���v���z(�ō�)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/25 ADD
                resultWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
                resultWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));// ADD ���V�� 2020/03/11 PMKOBETSU-2912
                resultWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
                resultWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
                resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                resultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                // resultWork.StockInputName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STOCKINPUTNAMERF" ) ); DEL 2009/09/08
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
                //resultWork.SalesSlipNum = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESSLIPNUMRF" ) );
                //resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "SALESDATERF" ) );
                //resultWork.CustomerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );
                //resultWork.CustomerSnm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERSNMRF" ) );
                resultWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
                resultWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
                resultWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
                resultWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
                resultWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));

                resultWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
                resultWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                resultWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
                resultWork.StockPriceConsTaxDtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTLSTOCKPRICECONSTAXRF"));
                //-----ADD 2011/12/09----->>>>>
                resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                //-----ADD 2011/12/09-----<<<<<
                // ----------- ADD 2012/10/15 �c���� ------------>>>>>
                resultWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
                resultWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
                // ----------- ADD 2012/10/15 �c���� ------------<<<<<
                // �`�[�ԍ�
                resultWork.PartySaleSlipNum = string.Empty;

                // �d���敪���u2:�����v�Œ�
                resultWork.SupplierFormal = 2;

                // �`�[���t�������f�[�^�쐬��
                resultWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ORDERDATACREATEDATERF"));

                // ----------ADD 2013/01/21----------->>>>>
                resultWork.StockSectionCd = resultWork.StockSectionCd ?? string.Empty;
                resultWork.StockInputCode = resultWork.StockInputCode ?? string.Empty;
                resultWork.StockAgentCode = resultWork.StockAgentCode ?? string.Empty;
                resultWork.MakerKanaName = resultWork.MakerKanaName ?? string.Empty;
                resultWork.CmpltMakerKanaName = resultWork.CmpltMakerKanaName ?? string.Empty;
                resultWork.GoodsNameKana = resultWork.GoodsNameKana ?? string.Empty;
                resultWork.GoodsLGroupName = resultWork.GoodsLGroupName ?? string.Empty;
                resultWork.GoodsMGroupName = resultWork.GoodsMGroupName ?? string.Empty;
                resultWork.BLGroupName = resultWork.BLGroupName ?? string.Empty;
                resultWork.BLGoodsFullName = resultWork.BLGoodsFullName ?? string.Empty;
                resultWork.RateSectStckUnPrc = resultWork.RateSectStckUnPrc ?? string.Empty;
                resultWork.RateDivStckUnPrc = resultWork.RateDivStckUnPrc ?? string.Empty;
                resultWork.RateBLGoodsName = resultWork.RateBLGoodsName ?? string.Empty;
                resultWork.RateGoodsRateGrpNm = resultWork.RateGoodsRateGrpNm ?? string.Empty;
                resultWork.RateBLGroupName = resultWork.RateBLGroupName ?? string.Empty;
                resultWork.StockDtiSlipNote1 = resultWork.StockDtiSlipNote1 ?? string.Empty;
                resultWork.SalesCustomerSnm = resultWork.SalesCustomerSnm ?? string.Empty;
                resultWork.SlipMemo1 = resultWork.SlipMemo1 ?? string.Empty;
                resultWork.SlipMemo2 = resultWork.SlipMemo2 ?? string.Empty;
                resultWork.SlipMemo3 = resultWork.SlipMemo3 ?? string.Empty;
                resultWork.InsideMemo1 = resultWork.InsideMemo1 ?? string.Empty;
                resultWork.InsideMemo2 = resultWork.InsideMemo2 ?? string.Empty;
                resultWork.InsideMemo3 = resultWork.InsideMemo3 ?? string.Empty;
                resultWork.AddresseeName = resultWork.AddresseeName ?? string.Empty;
                resultWork.OrderNumber = resultWork.OrderNumber ?? string.Empty;

                resultWork.EnterpriseGanreName = resultWork.EnterpriseGanreName ?? string.Empty;
                resultWork.GoodsRateRank = resultWork.GoodsRateRank ?? string.Empty;
                resultWork.StockAddUpSectionCd = resultWork.StockAddUpSectionCd ?? string.Empty;
                resultWork.BusinessTypeName = resultWork.BusinessTypeName ?? string.Empty;
                resultWork.SalesAreaName = resultWork.SalesAreaName ?? string.Empty;
                resultWork.SlpAddresseeName = resultWork.SlpAddresseeName ?? string.Empty;
                resultWork.AddresseeName2 = resultWork.AddresseeName2 ?? string.Empty;
                resultWork.AddresseePostNo = resultWork.AddresseePostNo ?? string.Empty;
                resultWork.AddresseeAddr1 = resultWork.AddresseeAddr1 ?? string.Empty;
                resultWork.AddresseeAddr3 = resultWork.AddresseeAddr3 ?? string.Empty;
                resultWork.AddresseeAddr4 = resultWork.AddresseeAddr4 ?? string.Empty;
                resultWork.AddresseeTelNo = resultWork.AddresseeTelNo ?? string.Empty;
                resultWork.AddresseeFaxNo = resultWork.AddresseeFaxNo ?? string.Empty;
                // ----------ADD 2013/01/21-----------<<<<<

                # endregion
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
            else if (iType == (int)iSrcType.PayTbl)
            {
                #region [�x���f�[�^]
                resultWork.DataDiv = 1;
                resultWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("PAYMENTDATERF"));
                resultWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTROWNORF"));
                resultWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTAGENTNAMERF"));
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                //resultWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "PAYMENTRF" ) );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                resultWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTTOTALRF"));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                resultWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                Int32 iValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
                resultWork.SupplierSlipNote2 = iValidityTerm.ToString();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
                //resultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
                resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                resultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD
                // resultWork.StockInputName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PAYMENTINPUTAGENTNMRF" ) ); // DEL 2009/09/08
                resultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                resultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                resultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSLIPNORF"));
                resultWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                resultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                resultWork.FeePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEPAYMENTRF"));
                resultWork.DiscountPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPAYMENTRF"));
                resultWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTLPAYMENTRF"));
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

                // ----------ADD 2013/01/21----------->>>>>
                resultWork.StockSectionCd = resultWork.StockSectionCd ?? string.Empty;
                resultWork.StockInputCode = resultWork.StockInputCode ?? string.Empty;
                resultWork.StockAgentCode = resultWork.StockAgentCode ?? string.Empty;
                resultWork.MakerKanaName = resultWork.MakerKanaName ?? string.Empty;
                resultWork.CmpltMakerKanaName = resultWork.CmpltMakerKanaName ?? string.Empty;
                resultWork.GoodsNameKana = resultWork.GoodsNameKana ?? string.Empty;
                resultWork.GoodsLGroupName = resultWork.GoodsLGroupName ?? string.Empty;
                resultWork.GoodsMGroupName = resultWork.GoodsMGroupName ?? string.Empty;
                resultWork.BLGroupName = resultWork.BLGroupName ?? string.Empty;
                resultWork.BLGoodsFullName = resultWork.BLGoodsFullName ?? string.Empty;
                resultWork.RateSectStckUnPrc = resultWork.RateSectStckUnPrc ?? string.Empty;
                resultWork.RateDivStckUnPrc = resultWork.RateDivStckUnPrc ?? string.Empty;
                resultWork.RateBLGoodsName = resultWork.RateBLGoodsName ?? string.Empty;
                resultWork.RateGoodsRateGrpNm = resultWork.RateGoodsRateGrpNm ?? string.Empty;
                resultWork.RateBLGroupName = resultWork.RateBLGroupName ?? string.Empty;
                resultWork.StockDtiSlipNote1 = resultWork.StockDtiSlipNote1 ?? string.Empty;
                resultWork.SalesCustomerSnm = resultWork.SalesCustomerSnm ?? string.Empty;
                resultWork.SlipMemo1 = resultWork.SlipMemo1 ?? string.Empty;
                resultWork.SlipMemo2 = resultWork.SlipMemo2 ?? string.Empty;
                resultWork.SlipMemo3 = resultWork.SlipMemo3 ?? string.Empty;
                resultWork.InsideMemo1 = resultWork.InsideMemo1 ?? string.Empty;
                resultWork.InsideMemo2 = resultWork.InsideMemo2 ?? string.Empty;
                resultWork.InsideMemo3 = resultWork.InsideMemo3 ?? string.Empty;
                resultWork.AddresseeName = resultWork.AddresseeName ?? string.Empty;
                resultWork.OrderNumber = resultWork.OrderNumber ?? string.Empty;

                resultWork.EnterpriseGanreName = resultWork.EnterpriseGanreName ?? string.Empty;
                resultWork.GoodsRateRank = resultWork.GoodsRateRank ?? string.Empty;
                resultWork.StockAddUpSectionCd = resultWork.StockAddUpSectionCd ?? string.Empty;
                resultWork.BusinessTypeName = resultWork.BusinessTypeName ?? string.Empty;
                resultWork.SalesAreaName = resultWork.SalesAreaName ?? string.Empty;
                resultWork.SlpAddresseeName = resultWork.SlpAddresseeName ?? string.Empty;
                resultWork.AddresseeName2 = resultWork.AddresseeName2 ?? string.Empty;
                resultWork.AddresseePostNo = resultWork.AddresseePostNo ?? string.Empty;
                resultWork.AddresseeAddr1 = resultWork.AddresseeAddr1 ?? string.Empty;
                resultWork.AddresseeAddr3 = resultWork.AddresseeAddr3 ?? string.Empty;
                resultWork.AddresseeAddr4 = resultWork.AddresseeAddr4 ?? string.Empty;
                resultWork.AddresseeTelNo = resultWork.AddresseeTelNo ?? string.Empty;
                resultWork.AddresseeFaxNo = resultWork.AddresseeFaxNo ?? string.Empty;

                // ----------ADD 2013/01/21-----------<<<<<

                #endregion  //[�x���f�[�^]
            }
            #endregion

            return resultWork;
        }
        #endregion  //[SuppPrtPprStcTblRsltWork����]

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
        # region [�����f�[�^�p SELECT����������]
        /// <summary>
        /// �����f�[�^����
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="paramWork"></param>
        /// <param name="logicalMode"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2012/10/15 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A2012/11/14�z�M��</br>
        /// <br>             Redmine#32862 ���i�ύX�������ׁA�F��ς���悤�ɏC��</br>
        /// </remarks>
        private string MakeTypeStcSlpOdrQuery(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";

            // �Ώۃe�[�u��
            // STOCKSLIPRF     STCSLP   �d���f�[�^
            // STOCKDETAILRF   STCDTL   �d�����׃f�[�^
            // SALESSLIPRF     SALSLP   ����f�[�^
            // SALESDETAILRF   SALDTL   ���㖾�׃f�[�^
            // SECINFOSETRF    SCINFS   ���_���ݒ�}�X�^

            #region [Select���쐬]
            selectTxt += "SELECT" + Environment.NewLine;
            selectTxt += "  ROW_NUMBER()" + Environment.NewLine;
            selectTxt += "   OVER(ORDER BY STCTBL.SUPPLIERSLIPNORF)" + Environment.NewLine;
            selectTxt += "   AS ROWNUM" + Environment.NewLine;
            selectTxt += " ,*" + Environment.NewLine;
            selectTxt += " FROM (" + Environment.NewLine;

            #region [�f�[�^���o���C��Query]
            //������������𒴂���܂Ŏ擾
            selectTxt += "  SELECT TOP " + paramWork.SearchCnt + Environment.NewLine;

            selectTxt += "    STCSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKDATERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.PARTYSALESLIPNUMRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKROWNORF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.SUPPLIERFORMALRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERSLIPCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKAGENTNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.GOODSNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.GOODSNORF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.GOODSMAKERCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.MAKERNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.BLGOODSCODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.BLGROUPCODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKCOUNTRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.OPENPRICEDIVRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPCTAXLAYCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKPRICECONSTAXRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
            selectTxt += "   ,SCINFS.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "   ,SCINFS.SECTIONGUIDENMRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKINPUTNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.SUPPLIERCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.SUPPLIERSNMRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKORDERDIVCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.WAREHOUSECODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.WAREHOUSENAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.WAREHOUSESHELFNORF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.UOEREMARK1RF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.UOEREMARK2RF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKADDUPADATERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.ACCPAYDIVCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.DEBITNOTEDIVRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SALESSLIPNUMRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SALESDATERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.CUSTOMERCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.CUSTOMERSNMRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.TAXATIONCODERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STCKPRCCONSTAXINCLURF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STCKDISTTLTAXINCLURF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKUNITPRICEFLRF" + Environment.NewLine;
            //selectTxt += "   ,STCSLP.ARRIVALGOODSDAYRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.ORDERDATACREATEDATERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.ORDERNUMBERRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKTOTALPRICERF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKSUBTTLPRICERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKPRICETAXEXCRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.STOCKPRICETAXINCRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.STOCKGOODSCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.DTLSTOCKPRICECONSTAXRF" + Environment.NewLine;
            //-----ADD 2011/12/09----->>>>>
            selectTxt += "   ,STCDTL.SALESCUSTOMERCODERF AS CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.SALESCUSTOMERSNMRF AS CUSTOMERSNMRF" + Environment.NewLine;
            //-----ADD 2011/12/09-----<<<<<
            // ----------- ADD 2012/10/15 �c���� ------------>>>>>
            selectTxt += "   ,STCDTL.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.BFLISTPRICERF" + Environment.NewLine;
            // ----------- ADD 2012/10/15 �c���� ------------<<<<<
            selectTxt += "   ,STCSLP.SUPPLIERCONSTAXRATERF" + Environment.NewLine; // ADD ���V�� 2020/03/11 PMKOBETSU-2912

            selectTxt += "  FROM (" + Environment.NewLine;

            #region [�d�����׃f�[�^���oQuery]
            selectTxt += "   SELECT" + Environment.NewLine;

            selectTxt += "    STCDTLSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.SUPPLIERFORMALRF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.SUPPLIERSLIPNORF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.STOCKROWNORF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.GOODSNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.GOODSNORF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.GOODSMAKERCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.MAKERNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.BLGOODSCODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.BLGROUPCODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.STOCKCOUNTRF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.LISTPRICETAXEXCFLRF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.OPENPRICEDIVRF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.STOCKORDERDIVCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.WAREHOUSECODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.WAREHOUSENAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.WAREHOUSESHELFNORF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.TAXATIONCODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.STOCKUNITPRICEFLRF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.ORDERDATACREATEDATERF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.ORDERNUMBERRF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.SUPPLIERCDRF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.SUPPLIERSNMRF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.STOCKAGENTNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.STOCKINPUTNAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.STOCKPRICETAXEXCRF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.STOCKPRICETAXINCRF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.STOCKPRICECONSTAXRF AS DTLSTOCKPRICECONSTAXRF" + Environment.NewLine;
            //-----ADD 2011/12/09----->>>>>
            selectTxt += "   ,STCDTLSUB.SALESCUSTOMERCODERF " + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.SALESCUSTOMERSNMRF " + Environment.NewLine;
            //-----ADD 2011/12/09-----<<<<<
            // ----------- ADD 2012/10/15 �c���� ------------>>>>>
            selectTxt += "   ,STCDTLSUB.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
            selectTxt += "   ,STCDTLSUB.BFLISTPRICERF" + Environment.NewLine;
            // ----------- ADD 2012/10/15 �c���� ------------<<<<<
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "   FROM STOCKDETAILRF AS STCDTLSUB " + Environment.NewLine;
            selectTxt += "   FROM STOCKDETAILRF AS STCDTLSUB WITH (READUNCOMMITTED) " + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += MakeWhereString_STCDTLOdr(ref sqlCommand, paramWork, logicalMode);
            #endregion  //[�d�����׃f�[�^���oQuery]

            selectTxt += "  ) AS STCDTL" + Environment.NewLine;

            #region [JOIN]
            // �d���f�[�^
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "  LEFT JOIN STOCKSLIPRF STCSLP" + Environment.NewLine;
            selectTxt += "  LEFT JOIN STOCKSLIPRF STCSLP WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += "  ON  STCSLP.ENTERPRISECODERF=STCDTL.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND STCSLP.SUPPLIERFORMALRF=STCDTL.SUPPLIERFORMALRF" + Environment.NewLine;
            selectTxt += "  AND STCSLP.SUPPLIERSLIPNORF=STCDTL.SUPPLIERSLIPNORF" + Environment.NewLine;

            //���_���ݒ�}�X�^
            // 2012/06/26 Y.Ito MOD START READUNCOMMITTED�Ή�
            //selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS" + Environment.NewLine;
            selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS WITH (READUNCOMMITTED)" + Environment.NewLine;
            // 2012/06/26 Y.Ito MOD END READUNCOMMITTED�Ή�
            selectTxt += "  ON  SCINFS.ENTERPRISECODERF=STCDTL.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SCINFS.SECTIONCODERF=STCDTL.SECTIONCODERF" + Environment.NewLine;
            #endregion  //[JOIN]

            //WHERE��
            selectTxt += MakeWhereString_STCSLPOdr(ref sqlCommand, paramWork, logicalMode);

            #endregion  //[�f�[�^���o���C��Query]

            // 2012/07/05 Y.Ito ADD START �����̓x�ɕ��я����قȂ錻�ۂ��C��
            selectTxt += " ORDER BY STCSLP.STOCKDATERF, STCSLP.PARTYSALESLIPNUMRF, STCSLP.SUPPLIERFORMALRF, STCSLP.SUPPLIERSLIPCDRF, STCDTL.STOCKROWNORF" + Environment.NewLine;
            // 2012/07/05 Y.Ito ADD END �����̓x�ɕ��я����قȂ錻�ۂ��C��

            selectTxt += " ) AS STCTBL" + Environment.NewLine;

            //ODER BY
            selectTxt += " ORDER BY ROWNUM DESC";
            #endregion

            return selectTxt;
        }
        # endregion

        #region [SuppPrtPprStcTblRsltWork�p WHERE���������� (�d�����׃f�[�^(����)SELECT�p)]
        /// <summary>
        /// �`�[�\���E���ו\���̃��X�g���o�pWHERE�� �������� (�d�����׃f�[�^(����)SELECT�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009.02.25</br>
        /// <br>Update Note: 2012/08/09 wangf </br>
        /// <br>           : 10801804-00�A9/12�z�M���ARedmine#31533 �d����d�q���� �i�Ԏw�莞�̒��o�s���̑Ή�</br>
        /// <br>           : �i�Ԃ��n�C�t�������œ��͂����ꍇ�A�d����d�q�����͓��Ӑ�d�q�����Ɠ����悤�ɒ��o�\�ɂȂ�܂��B</br>
        /// <br></br>
        private string MakeWhereString_STCDTLOdr(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " STCDTLSUB.ENTERPRISECODERF=@ENTERPRISECODE2" + Environment.NewLine;
            SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@ENTERPRISECODE2", SqlDbType.NChar);
            paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STCDTLSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STCDTLSUB.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

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
                    retstring += " AND STCDTLSUB.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�d����R�[�h
            if (paramWork.SupplierCd != 0)
            {
                retstring += " AND STCDTLSUB.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCd);
            }

            //�d�����������f�[�^�쐬��
            if (paramWork.St_StockDate != DateTime.MinValue)
            {
                retstring += " AND STCDTLSUB.ORDERDATACREATEDATERF>=@STSTOCKDATE" + Environment.NewLine;
                SqlParameter paraStStockDate = sqlCommand.Parameters.Add("@STSTOCKDATE", SqlDbType.Int);
                paraStStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_StockDate);
            }
            if (paramWork.Ed_StockDate != DateTime.MinValue)
            {
                retstring += " AND STCDTLSUB.ORDERDATACREATEDATERF<=@EDSTOCKDATE" + Environment.NewLine;
                SqlParameter paraEdStockDate = sqlCommand.Parameters.Add("@EDSTOCKDATE", SqlDbType.Int);
                paraEdStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_StockDate);
            }
            // �C�� 2009/05/26 >>>
            if (paramWork.St_InputDay != DateTime.MinValue)
            {
                retstring += " AND STCDTLSUB.ORDERDATACREATEDATERF>=@STINPUTDAYRF" + Environment.NewLine;
                SqlParameter paraStInputDay = sqlCommand.Parameters.Add("@STINPUTDAYRF", SqlDbType.Int);
                paraStInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_InputDay);

            }
            if (paramWork.Ed_InputDay != DateTime.MinValue)
            {
                retstring += " AND STCDTLSUB.ORDERDATACREATEDATERF<=@EDINPUTDAYRF" + Environment.NewLine;
                SqlParameter paraEdInputDay = sqlCommand.Parameters.Add("@EDINPUTDAYRF", SqlDbType.Int);
                paraEdInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_InputDay);
            }
            // �C�� 2009/05/26 <<<

            // �󒍃X�e�[�^�X=2:����
            retstring += " AND STCDTLSUB.SUPPLIERFORMALRF=2" + Environment.NewLine;

            ////�`�[�ԍ�(�����`�[�ԍ�) �������ԍ��@�������܂���������
            //if ( paramWork.PartySaleSlipNum != "" )
            //{
            //    //�����܂��������ǂ������`�F�b�N
            //    if ( System.Text.RegularExpressions.Regex.Match( paramWork.PartySaleSlipNum, "(%)" ).Success == true )
            //    {
            //        //�����܂�����
            //        retstring += " AND STCDTLSUB.ORDERNUMBERRF LIKE @FINDPARTYSALESLIPNUM" + Environment.NewLine;
            //    }
            //    else
            //    {
            //        //�����܂���������Ȃ�
            //        retstring += " AND STCDTLSUB.ORDERNUMBERRF=@FINDPARTYSALESLIPNUM" + Environment.NewLine;
            //    }
            //    SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add( "@FINDPARTYSALESLIPNUM", SqlDbType.NVarChar );
            //    paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString( paramWork.PartySaleSlipNum );
            //}

            //�d��SEQ/�x����(�d���`�[�ԍ�)
            if (paramWork.PaymentSlipNo != 0)
            {
                retstring += " AND STCDTLSUB.SUPPLIERSLIPNORF>=@FINDSUPPLIERSLIPNO" + Environment.NewLine;
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(paramWork.PaymentSlipNo);
            }

            //�S����(�d���S���҃R�[�h)
            if (paramWork.StockAgentCode != "")
            {
                retstring += " AND STCDTLSUB.STOCKAGENTCODERF=@FINDSTOCKAGENTCODE" + Environment.NewLine;
                SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@FINDSTOCKAGENTCODE", SqlDbType.NChar);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(paramWork.StockAgentCode);
            }

            //���s��(�d�����͎҃R�[�h)
            if (paramWork.StockInputCode != "")
            {
                retstring += " AND STCDTLSUB.STOCKINPUTCODERF=@FINDSTOCKINPUTCODE" + Environment.NewLine;
                SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@FINDSTOCKINPUTCODE", SqlDbType.NChar);
                paraStockInputCode.Value = SqlDataMediator.SqlSetString(paramWork.StockInputCode);
            }

            //�t�n�d����(�������@)
            if (paramWork.WayToOrder != 0)
            {
                if (paramWork.WayToOrder == 2)
                {
                    //UOE���M -> UOE���M�̂�
                    retstring += " AND STCDTLSUB.WAYTOORDERRF=2" + Environment.NewLine;
                }
                else
                {
                    //�ʏ� -> UOE���M�ȊO
                    retstring += "AND STCDTLSUB.WAYTOORDERRF<>2 " + Environment.NewLine;
                }
            }

            //�a�k�O���[�v(BL�O���[�v�R�[�h)
            if (paramWork.BLGroupCode != 0)
            {
                retstring += " AND STCDTLSUB.BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGroupCode);
            }

            //�a�k�R�[�h(BL���i�R�[�h)
            if (paramWork.BLGoodsCode != 0)
            {
                retstring += " AND STCDTLSUB.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
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
                    retstring += " AND STCDTLSUB.GOODSNAMERF LIKE @FINDGOODSNAME" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCDTLSUB.GOODSNAMERF=@FINDGOODSNAME" + Environment.NewLine;
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
                    //retstring += " AND STCDTLSUB.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine; // DEL wangf 2012/08/09 FOR Redmine#31533
                    // ------------ADD wangf 2012/08/09 FOR Redmine#31533--------->>>>
                    if (paramWork.GoodsNo.Contains(HORIZONTAL_LINE))
                    {
                        retstring += " AND STCDTLSUB.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND REPLACE(STCDTLSUB.GOODSNORF, '" + HORIZONTAL_LINE + "', '') LIKE @FINDGOODSNO" + Environment.NewLine;
                    }
                    // ------------ADD wangf 2012/08/09 FOR Redmine#31533---------<<<<
                }
                else
                {
                    //�����܂���������Ȃ�
                    //retstring += " AND STCDTLSUB.GOODSNORF=@FINDGOODSNO" + Environment.NewLine; // DEL wangf 2012/08/09 FOR Redmine#31533
                    // ------------ADD wangf 2012/08/09 FOR Redmine#31533--------->>>>
                    if (paramWork.GoodsNo.Contains(HORIZONTAL_LINE))
                    {
                        retstring += " AND STCDTLSUB.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND REPLACE(STCDTLSUB.GOODSNORF, '" + HORIZONTAL_LINE + "' , '') = @FINDGOODSNO" + Environment.NewLine;
                    }
                    // ------------ADD wangf 2012/08/09 FOR Redmine#31533---------<<<<
                }
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNo);
            }

            //���[�J�[(���i���[�J�[�R�[�h)
            if (paramWork.GoodsMakerCd != 0)
            {
                retstring += "AND STCDTLSUB.GOODSMAKERCDRF=@FINDGOODSMAKERCD " + Environment.NewLine;
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCd);
            }

            //�݌Ɏ��敪(�d���݌Ɏ�񂹋敪)
            if (paramWork.StockOrderDivCd != -1)
            {
                retstring += "AND STCDTLSUB.STOCKORDERDIVCDRF=@FINDSTOCKORDERDIVCD" + Environment.NewLine;
                SqlParameter paraStockOrderDivCd = sqlCommand.Parameters.Add("@FINDSTOCKORDERDIVCD", SqlDbType.Int);
                paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(paramWork.StockOrderDivCd);
            }

            //�q�ɃR�[�h
            if (paramWork.WarehouseCode != "")
            {
                retstring += "AND STCDTLSUB.WAREHOUSECODERF=@FINDWAREHOUSECODE " + Environment.NewLine;
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
            }
            #endregion

            return retstring;
        }
        #endregion  //[SuppPrtPprStcTblRsltWork�p WHERE���������� (�d���f�[�^SELECT�p)]

        #region [SuppPrtPprStcTblRsltWork�p WHERE���������� (�d���f�[�^SELECT�p)]
        /// <summary>
        /// �`�[�\���E���ו\���̃��X�g���o�pWHERE�� �������� (�d���f�[�^SELECT�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009.02.25</br>
        /// <br></br>
        private string MakeWhereString_STCSLPOdr(ref SqlCommand sqlCommand, SuppPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            // STCSLP.ENTERPRISECODERF��NULL�̏ꍇ������@������
            retstring += " (STCSLP.ENTERPRISECODERF IS NULL) OR (" + Environment.NewLine;


            //��ƃR�[�h
            retstring += " STCSLP.ENTERPRISECODERF=@ENTERPRISECODE1" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE1", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STCSLP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE1" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE1", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STCSLP.LOGICALDELETECODERF<@FINDLOGICALDELETECODE1" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE1", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            // �󒍃X�e�[�^�X=2:����
            retstring += " AND STCSLP.SUPPLIERFORMALRF=2" + Environment.NewLine;

            //���l�P(�d���`�[���l1) �������܂���������
            if (paramWork.SupplierSlipNote1 != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SupplierSlipNote1, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND STCSLP.SUPPLIERSLIPNOTE1RF LIKE @FINDSUPPLIERSLIPNOTE1" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCSLP.SUPPLIERSLIPNOTE1RF=@FINDSUPPLIERSLIPNOTE1" + Environment.NewLine;
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
                    retstring += " AND STCSLP.SUPPLIERSLIPNOTE2RF LIKE @FINDSUPPLIERSLIPNOTE2" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCSLP.SUPPLIERSLIPNOTE2RF=@FINDSUPPLIERSLIPNOTE2" + Environment.NewLine;
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
                    retstring += " AND STCSLP.UOEREMARK1RF LIKE @FINDUOEREMARK1" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCSLP.UOEREMARK1RF=@FINDUOEREMARK1" + Environment.NewLine;
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
                    retstring += " AND STCSLP.UOEREMARK2RF LIKE @FINDUOEREMARK2" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND STCSLP.UOEREMARK2RF=@FINDUOEREMARK2" + Environment.NewLine;
                }
                SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@FINDUOEREMARK2", SqlDbType.NVarChar);
                paraUoeRemark2.Value = SqlDataMediator.SqlSetString(paramWork.UoeRemark2);
            }

            // STCSLP.ENTERPRISECODERF��NULL�̏ꍇ������@������
            retstring += " )" + Environment.NewLine;

            #endregion

            return retstring;
        }
        #endregion  //[SuppPrtPprSalTblRsltWork�p WHERE���������� (�d���f�[�^SELECT�p)]

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
    }
}

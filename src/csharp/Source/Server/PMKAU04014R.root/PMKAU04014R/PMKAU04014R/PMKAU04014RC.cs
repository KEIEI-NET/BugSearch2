/// <br>Update Note: 2011/08/18 �A��729 ����g 10704766-00 </br>
/// <br>             ���ד\�t�t�@���N�V�����{�^����ǉ�</br>
/// <br>Update Note: 2012/04/01 Redmine#29250 </br>
/// <br>             ���Ӑ�d�q�����@�f�[�^�X�V�����̒ǉ��ɂ���(���׍X�V�����̒ǉ�)</br>
/// <br>Update Note: 2013/03/18 zhaimm </br>
/// <br>�Ǘ��ԍ�   : 10800003-00 2013/05/15�z�M��</br>
/// <br>           : Redmine#34807 ��703 ���Ӑ�d�q����</br>
/// <br>           : �������F���`�ԍ���0�l�߃f�[�^��0�l�߂Ȃ��f�[�^�����o�ΏۂƂ���</br>
/// <br>Update Note: 2014/12/28 �i�N</br>
/// <br>�Ǘ��ԍ�   : 11070263-00</br>
/// <br>           : �ϊ���i�Ԃ̒ǉ��Ή�</br>
/// <br>Update Note: 2015/02/05 ������</br>
/// <br>           : �e�L�X�g�o�͌��������Ȃ����[�h�̒ǉ�</br>
/// <br>UpdateNote : 2015/03/03 ������ Redmine#44701</br>
/// <br>           : ��ʂ̔�������w�肳��Ȃ��ꍇ�A�����f�[�^����J�n�E�I������������������</br>
/// <br>Update Note: K2015/06/16 鸏�</br>
/// <br>�Ǘ��ԍ�   : 11101427-00</br>
/// <br>           : ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B ���C�S���I�v�V�������L���̏ꍇ�̂�</br>
/// <br>UpdateNote : 2016/01/21 �e�c ���V</br>
/// <br>�Ǘ��ԍ�   : 11270007-00 �d�|�ꗗ��2808 �ݏo�󒍑Ή�</br>
/// <br>           : �@���������Ɂu�o�׏󋵁v���ڂ�ǉ�</br>
/// <br>           : �A���ו\���Ɍv�㐔�A���v�㐔���ڂ�ǉ�</br>
/// <br>Update Note: K2016/02/23 ���V��</br>
/// <br>�Ǘ��ԍ�   : 11200090-00 �C�P�� ���Ӑ�d�q����</br>
/// <br>             ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή�</br>
/// <br>Update Note: 2020/03/11 ���V��</br>
/// <br>�Ǘ��ԍ�   : 11570208-00</br>
/// <br>           : PMKOBETSU-2912 �y���ŗ��Ή�</br>
/// <br>           : �`�[�^�u�A���׃^�u�Ɂu����ŗ��v���ڂ�ǉ�</br>
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
// -- DEL 2009/09/04 ------------------------------------->>>
//using System.Collections.Generic; //  m.suzuki 2009.08.24 ADD 
// -- DEL 2009/09/04 -------------------------------------<<<

namespace Broadleaf.Application.Remoting
{
    class CustPrtPprSalTblRsltQuery : ICustPrtPpr
    {
        #region [DEL 2009/09/04]
        // -- DEL 2009/09/04 ------------------------------------->>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
        ///// <summary>�`�[���ޔ��f�B�N�V���i��</summary>
        //private Dictionary<string, string> _salesSlipHisKeyDic;
        ///// <summary>
        ///// �`�[���ޔ��f�B�N�V���i��
        ///// </summary>
        //public Dictionary<string, string> SalesSlipHisKeyDic
        //{
        //    get { return _salesSlipHisKeyDic; }
        //    set { _salesSlipHisKeyDic = value; }
        //}

        ///// <summary>
        ///// �R���X�g���N�^
        ///// </summary>
        //public CustPrtPprSalTblRsltQuery()
        //{
        //    _salesSlipHisKeyDic = new Dictionary<string, string>();
        //}
        ///// <summary>
        ///// �L�[�����񐶐�
        ///// </summary>
        ///// <param name="acptAnOdrStatus"></param>
        ///// <param name="salesSlipNum"></param>
        ///// <param name="salesRowNo"></param>
        ///// <param name="salesDate"></param>
        ///// <returns></returns>
        //private string CreateKeyString( int acptAnOdrStatus, string salesSlipNum, int salesRowNo, DateTime salesDate )
        //{
        //    return string.Format( "{0:D2}-{1}-{2:D3}-{3:yyyyMMdd}", acptAnOdrStatus, salesSlipNum.Trim(), salesRowNo, salesDate );
        //}
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
        // -- DEL 2009/09/04 ---------------------------------------<<<
        #endregion[DEL 2009/09/04]

        #region [CustPrtPprSalTblRsltWork�p SELECT��]
        /// <summary>
        /// �`�[�\���E���ו\���̃��X�g���o�N�G���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="iType">�����^�C�v 0:����f�[�^ 1:�����f�[�^</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�`�[�\���E���ו\���̃��X�g���oSELECT��</returns>
        /// <remarks>
        /// <br>Note       : �`�[�\���E���ו\���̃��X�g���o�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>�ݏo�`�[���o�s��̏C��</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.12.24</br>
        /// <br></br>
        /// <br>UpdateNote : 2009.02.19 22018 ��ؐ��b</br>
        /// <br>             �@�ԓ`���s�\�`�F�b�N�Ɏg�p���Ă���󒍎c���̎擾���@�ɂ��ďC���B</br>
        /// <br>               ���㗚�𖾍׃f�[�^���g�p����͖̂������o�Ă����̂ŁA���㖾�ׂ���Ɏg�p����悤�ύX�B</br>
        /// <br></br>
        /// <br>UpdateNote : 2009.08.24 22018 ��ؐ��b</br>
        /// <br>             �ߋ����\���Ή��i����f�[�^���o��ɁA���㗚���f�[�^���o����ǉ��j</br>
        /// <br></br>
        /// <br>UpdateNote : 2009.09.04 22008 ���� ���n</br>
        /// <br>             �ߋ����\�����x�A�b�v�Ή�</br>
        /// <br>UpdateNote : 2009/09/07 ����</br>
        /// <br>             ���q���l�Ǝԗ����s�����̒ǉ�</br>
        /// <br>Update Note: 2015/02/05 ������</br>
        /// <br>           : �e�L�X�g�o�͌��������Ȃ����[�h�̒ǉ�</br>
        /// <br></br>
        /// </remarks>
        public string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, int iType, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";
            CustPrtPprWork _custPrtPprWork = paramWork as CustPrtPprWork;

            switch (iType)
            {
                case (int)iSrcType.SalTbl:  //����f�[�^
                    selectTxt = MakeTypeSalSlpQuery(ref sqlCommand, _custPrtPprWork, logicalMode);
                    break;
                // -- DEL 2009/09/04 ------------------------------>>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                //case (int)iSrcType.SalHisTbl:  //���㗚���f�[�^
                //    selectTxt = MakeTypeSalSlpHisQuery( ref sqlCommand, _custPrtPprWork, logicalMode );
                //    break;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                // -- DEL 2009/09/04 ------------------------------<<<
                case (int)iSrcType.DepTbl:  //�����f�[�^
                    selectTxt = MakeTypeDepSitQuery(ref sqlCommand, _custPrtPprWork, logicalMode);
                    break;
                //----- ADD 2015/02/05 ������ -------------------->>>>>
                case (int)iSrcType.SalDate:  // �e�L�X�g�o�͗p������̌���
                    selectTxt = MakeTypeSalDate4Text(ref sqlCommand, _custPrtPprWork, logicalMode);
                    break;
                //----- ADD 2015/02/05 ������ --------------------<<<<<
                default:
                    break;
            }

            return selectTxt;
        }
        #endregion  //[CustPrtPprSalTblRsltWork�p SELECT��]

        #region [�e�L�X�g�o�͗p������̌��� SELECT����������]
        //----- ADD 2015/02/05 ������ -------------------->>>>>
        /// <summary>
        /// ��������w�肳��Ȃ��ꍇ�ADB����J�n�E�I�����������������
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : ��������w�肳��Ȃ��ꍇ�ADB����J�n�E�I�����������������</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2015/02/05</br>
        /// <br>UpdateNote  : 2015/03/03 ������ Redmine#44701</br>
        /// <br>            : ��ʂ̔�������w�肳��Ȃ��ꍇ�A�����f�[�^����J�n�E�I������������������</br>
        /// </remarks>
        private string MakeTypeSalDate4Text(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder selectTxt = new StringBuilder();

            //----- ADD 2015/03/03 ������ Redmine#44701 ---------->>>>>
            if (paramWork.SearchSalDateType == 0) // ����f�[�^������t������
            {
            //----- ADD 2015/03/03 ������ Redmine#44701 ----------<<<<<
                selectTxt.Append("SELECT TOP 1 ").Append(Environment.NewLine);
                selectTxt.Append(" CASE WHEN (SALSLP.ACPTANODRSTATUSRF=30) THEN SALSLP.SALESDATERF ELSE SALSLP.SHIPMENTDAYRF END SALESDATE ").Append(Environment.NewLine);
                selectTxt.Append(" ,SALSLP.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                selectTxt.Append(" ,SALSLP.SECTIONCODERF ").Append(Environment.NewLine);
                selectTxt.Append("FROM ( ").Append(Environment.NewLine);

                bool salSlipFlg = false;  //���オ�܂܂�邩
                bool acpSlipFlg = false;  //�ݏo or �󒍂��܂܂�邩
                //�󒍁A�ݏo�̎w�肪���݂��邩���`�F�b�N
                foreach (Int32 iacptSt in paramWork.AcptAnOdrStatus)
                {
                    if (iacptSt == 30)
                    {
                        salSlipFlg = true;
                    }
                    if (iacptSt != 30)
                    {
                        acpSlipFlg = true;
                    }
                }

                if (salSlipFlg)
                {
                    // �P�E���オ�܂܂�邩
                    selectTxt.Append(" SELECT ").Append(Environment.NewLine);
                    selectTxt.Append("  SALSLPSUB.ENTERPRISECODERF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALSLPSUB.SALESDATERF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALSLPSUB.SALESSLIPNUMRF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALSLPSUB.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALSLPSUB.RESULTSADDUPSECCDRF AS SECTIONCODERF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALSLPSUB.SHIPMENTDAYRF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALDTL.COMMONSEQNORF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALDTL.SUPPLIERFORMALSYNCRF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALDTL.STOCKSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALDTL.SALESCODERF ").Append(Environment.NewLine);
                    selectTxt.Append("  ,SALDTL.ACCEPTANORDERNORF AS ACCEPTANORDERNORF_1 ").Append(Environment.NewLine);
                    selectTxt.Append(" FROM SALESHISTORYRF AS SALSLPSUB WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    selectTxt.Append(" LEFT JOIN SALESHISTDTLRF SALDTL WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    selectTxt.Append(" ON  SALDTL.ENTERPRISECODERF=SALSLPSUB.ENTERPRISECODERF ").Append(Environment.NewLine);
                    selectTxt.Append(" AND SALDTL.ACPTANODRSTATUSRF=SALSLPSUB.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                    selectTxt.Append(" AND SALDTL.SALESSLIPNUMRF=SALSLPSUB.SALESSLIPNUMRF ").Append(Environment.NewLine);
                    selectTxt.Append(" LEFT JOIN SALESHISTDTLRF SALDTL2 WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    selectTxt.Append(" ON  SALDTL2.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF ").Append(Environment.NewLine);
                    selectTxt.Append(" AND SALDTL2.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF ").Append(Environment.NewLine);
                    selectTxt.Append(" AND SALDTL2.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF ").Append(Environment.NewLine);

                    sqlCommand.Parameters.Clear();
                    selectTxt.Append(MakeWhereString_SALSLPSUB(ref sqlCommand, paramWork, logicalMode, 0));
                }

                if ((salSlipFlg) && (acpSlipFlg))
                {
                    selectTxt.Append("UNION ALL ").Append(Environment.NewLine);
                }

                if (acpSlipFlg)
                {
                    // �Q�E�ݏo or �󒍂��܂܂�邩
                    selectTxt.Append("SELECT ").Append(Environment.NewLine);
                    selectTxt.Append(" SALSLPSUB.ENTERPRISECODERF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALSLPSUB.SALESDATERF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALSLPSUB.SALESSLIPNUMRF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALSLPSUB.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALSLPSUB.RESULTSADDUPSECCDRF AS SECTIONCODERF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALSLPSUB.SHIPMENTDAYRF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALDTL.COMMONSEQNORF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALDTL.SUPPLIERFORMALSYNCRF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALDTL.STOCKSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALDTL.SALESCODERF ").Append(Environment.NewLine);
                    selectTxt.Append(" ,SALDTL.ACCEPTANORDERNORF AS ACCEPTANORDERNORF_1 ").Append(Environment.NewLine);
                    selectTxt.Append("FROM SALESSLIPRF AS SALSLPSUB WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    selectTxt.Append("LEFT JOIN SALESDETAILRF SALDTL WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    selectTxt.Append("ON  SALDTL.ENTERPRISECODERF=SALSLPSUB.ENTERPRISECODERF ").Append(Environment.NewLine);
                    selectTxt.Append("AND SALDTL.ACPTANODRSTATUSRF=SALSLPSUB.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                    selectTxt.Append("AND SALDTL.SALESSLIPNUMRF=SALSLPSUB.SALESSLIPNUMRF ").Append(Environment.NewLine);
                    selectTxt.Append("LEFT JOIN SALESDETAILRF SALDTL2 WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                    selectTxt.Append("ON  SALDTL2.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF ").Append(Environment.NewLine);
                    selectTxt.Append("AND SALDTL2.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF ").Append(Environment.NewLine);
                    selectTxt.Append("AND SALDTL2.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF ").Append(Environment.NewLine);

                    sqlCommand.Parameters.Clear();
                    selectTxt.Append(MakeWhereString_SALSLPSUB(ref sqlCommand, paramWork, logicalMode, 1));
                }

                selectTxt.Append(") AS SALSLP ").Append(Environment.NewLine);

                // �󒍃}�X�^(�ԗ�)
                selectTxt.Append("LEFT JOIN ACCEPTODRCARRF AODCAR WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  AODCAR.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND AODCAR.ACCEPTANORDERNORF=SALSLP.ACCEPTANORDERNORF_1 ").Append(Environment.NewLine);
                selectTxt.Append("AND ( ").Append(Environment.NewLine);
                selectTxt.Append(" (SALSLP.ACPTANODRSTATUSRF = 10 AND AODCAR.ACPTANODRSTATUSRF = 1)  --�@���� ").Append(Environment.NewLine);
                selectTxt.Append(" OR (SALSLP.ACPTANODRSTATUSRF = 20 AND AODCAR.ACPTANODRSTATUSRF = 3) -- �� ").Append(Environment.NewLine);
                selectTxt.Append(" OR (SALSLP.ACPTANODRSTATUSRF = 30 AND AODCAR.ACPTANODRSTATUSRF = 7) -- ���� ").Append(Environment.NewLine);
                selectTxt.Append(" OR (SALSLP.ACPTANODRSTATUSRF = 40 AND AODCAR.ACPTANODRSTATUSRF = 5) -- �o�� ").Append(Environment.NewLine);
                selectTxt.Append(") ").Append(Environment.NewLine);
                // UOE�����f�[�^
                selectTxt.Append("LEFT JOIN UOEORDERDTLRF UOEODR WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  UOEODR.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND UOEODR.COMMONSEQNORF=SALSLP.COMMONSEQNORF ").Append(Environment.NewLine);
                selectTxt.Append("AND UOEODR.UOEKINDRF=0 ").Append(Environment.NewLine);
                // ���_���ݒ�}�X�^
                selectTxt.Append("LEFT JOIN SECINFOSETRF SCINFS WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  SCINFS.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND SCINFS.SECTIONCODERF=SALSLP.SECTIONCODERF ").Append(Environment.NewLine);
                // �d�����׃f�[�^
                selectTxt.Append("LEFT JOIN STOCKSLHISTDTLRF STCDTL WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  STCDTL.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND STCDTL.SUPPLIERFORMALRF=SALSLP.SUPPLIERFORMALSYNCRF ").Append(Environment.NewLine);
                selectTxt.Append("AND STCDTL.STOCKSLIPDTLNUMRF=SALSLP.STOCKSLIPDTLNUMSYNCRF ").Append(Environment.NewLine);
                // �d���f�[�^
                selectTxt.Append("LEFT JOIN STOCKSLIPHISTRF STCSLP WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  STCSLP.ENTERPRISECODERF=STCDTL.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND STCSLP.SUPPLIERFORMALRF=STCDTL.SUPPLIERFORMALRF ").Append(Environment.NewLine);
                selectTxt.Append("AND STCSLP.SUPPLIERSLIPNORF=STCDTL.SUPPLIERSLIPNORF ").Append(Environment.NewLine);
                // ���[�U�[�K�C�h�}�X�^(�{�f�B)
                selectTxt.Append("LEFT JOIN USERGDBDURF USRGBU WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  USRGBU.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND USRGBU.USERGUIDEDIVCDRF=71 ").Append(Environment.NewLine);
                selectTxt.Append("AND USRGBU.GUIDECODERF=SALSLP.SALESCODERF ").Append(Environment.NewLine);

                //WHERE��
                selectTxt.Append(MakeWhereString_SALTBL(ref sqlCommand, paramWork, logicalMode));

                selectTxt.Append("ORDER BY CASE WHEN (SALSLP.ACPTANODRSTATUSRF=30) THEN SALSLP.SALESDATERF ELSE SALSLP.SHIPMENTDAYRF END ").Append(Environment.NewLine);
                if (paramWork.SearchSalDateStEd == 0)
                {
                    selectTxt.Append("ASC ").Append(Environment.NewLine);
                }
                else
                {
                    selectTxt.Append("DESC ").Append(Environment.NewLine);
                }
            //----- ADD 2015/03/03 ������ Redmine#44701 ---------->>>>>
            }
            else // �����f�[�^������t������
            {
                selectTxt.Append("SELECT TOP 1 ").Append(Environment.NewLine);
                selectTxt.Append(" DEPSM.DEPOSITDATERF AS SALESDATE ").Append(Environment.NewLine);
                selectTxt.Append("FROM ( ").Append(Environment.NewLine);
                selectTxt.Append(" SELECT ").Append(Environment.NewLine);
                selectTxt.Append("  DEPSMSUB.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("  ,DEPSMSUB.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                selectTxt.Append("  ,DEPSMSUB.DEPOSITDATERF ").Append(Environment.NewLine);
                selectTxt.Append("  ,DEPSMSUB.DEPOSITSLIPNORF ").Append(Environment.NewLine);
                selectTxt.Append("  ,DEPSMSUB.ADDUPSECCODERF ").Append(Environment.NewLine);
                selectTxt.Append(" FROM DEPSITMAINRF AS DEPSMSUB WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                // WHERE
                selectTxt.Append(MakeWhereString_DEPSMSUB(ref sqlCommand, paramWork, logicalMode));

                selectTxt.Append(") AS DEPSM ").Append(Environment.NewLine);
                selectTxt.Append("LEFT JOIN DEPSITDTLRF DEPSD WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  DEPSD.ENTERPRISECODERF=DEPSM.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND DEPSD.ACPTANODRSTATUSRF=DEPSM.ACPTANODRSTATUSRF ").Append(Environment.NewLine);
                selectTxt.Append("AND DEPSD.DEPOSITSLIPNORF=DEPSM.DEPOSITSLIPNORF ").Append(Environment.NewLine);
                selectTxt.Append("LEFT JOIN SECINFOSETRF SCINFS WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                selectTxt.Append("ON  SCINFS.ENTERPRISECODERF=DEPSM.ENTERPRISECODERF ").Append(Environment.NewLine);
                selectTxt.Append("AND SCINFS.SECTIONCODERF=DEPSM.ADDUPSECCODERF ").Append(Environment.NewLine);
                if (paramWork.SearchSalDateStEd == 0)
                {
                    selectTxt.Append("ORDER BY DEPSM.DEPOSITDATERF ASC ").Append(Environment.NewLine);
                }
                else
                {
                    selectTxt.Append("ORDER BY DEPSM.DEPOSITDATERF DESC ").Append(Environment.NewLine);
                }
            }
            //----- ADD 2015/03/03 ������ Redmine#44701 ----------<<<<<

            return selectTxt.ToString();
        }
        //----- ADD 2015/02/05 ������ --------------------<<<<<
        #endregion

        #region [����f�[�^�p SELECT����������]
        /// <summary>
        /// �d���f�[�^�pSELECT���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�d���f�[�^�pSELECT��</returns>
        /// <br>Note       : �d���f�[�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br></br>
        /// <br>UpdateNote : 2009/09/04 22008 ���� ���n</br>
        /// <br>             �ߋ����\�����x�A�b�v�Ή�</br>
        /// <br></br>
        /// <br>UpdateNote : 2009/10/05 22008 ���� ���n</br>
        /// <br>             �\�����x�A�b�v�Ή�</br>
        /// <br></br>
        /// <br>UpdateNote : 2009/12/28 ������</br>
        /// <br>             PM.NS�ێ�˗��C</br>
        /// <br>             �i�Ԃ̒��o�����ŁA�n�C�t�������œ��͂��ꂽ�ꍇ�Ƀn�C�t���t���ΏۂƂ���悤�ɏC��</br>
        /// <br></br>
        /// <br>UpdateNote : 2010/01/12 ������</br>
        /// <br>             PM.NS�ێ�˗��C</br>
        /// <br>             �N�̂ݓ��͂����N���̓`�[�𔄏�`�[���͂Ő���Ɍ��o�\�t�ł���悤�ɕύX����</br>
        /// <br></br>
        /// <br>UpdateNote : 2010/01/29 �k���r</br>
        /// <br>             4������</br>
        /// <br>             �ԓ`���s���ɁA�ԕi���̏���𐧌����\�ƂȂ�悤�ɁA�ԕi�s�ݒ�@�\�̒ǉ����s��</br>
        /// <br></br>
        /// <br>UpdateNote : 2010/03/11 22018 ��� ���b</br>
        /// <br>             �ߋ���(���㗚�𖾍ׂ������Ĕ��㖾�ׂ������Ƃ�)�̏ꍇ�A�n�C�t�����i�Ԍ����Ƀq�b�g���Ȃ����̏C��</br>
        /// <br>UpdateNote : 2010/04/27 gaoyh</br>
        /// <br>             �󒍃}�X�^�i�ԗ��j�Ɏ��R�����^���Œ�ԍ��z��̒ǉ�</br>  
        /// <br></br>
        /// <br>Update Note: ���x�`���[�j���O</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2010/05/10</br>
        /// <br></br>
        /// <br>Update Note: UOE�����f�[�^�̌��������s��Ή�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2010/06/07</br>
        /// <br></br>
        /// <br>Update Note: READUNCOMMITTED�Ή�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2010/06/09</br>
        /// <br></br>
        /// <br>Update Note: ��Q�E���ǑΉ�8�������[�X���̑Ή�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/08/05</br>
        /// <br>Update Note: �v�㌳�󒍇��E�v�㌳�ݏo���̕\�����e�C��</br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2010/12/20</br>
        /// <br>Update Note: ���Ӑ�d�q����/(BL�߰µ��ް����)�⍇���ԍ��̒ǉ�</br>
        /// <br>Programmer : �k�m</br>
        /// <br>Date       : 2011/11/28</br>
        /// <br>Update Note: 2014/12/28 �i�N</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           : �ϊ���i�Ԃ̒ǉ��Ή�</br>
        /// <br>Update Note: 2015/02/05 ������</br>
        /// <br>           : �e�L�X�g�o�͌��������Ȃ����[�h�̒ǉ�</br>
        /// <br>Update Note: K2015/06/16 鸏�</br>
        /// <br>�Ǘ��ԍ�   : 11101427-00</br>
        /// <br>           : ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
        /// <br>Update Note: 2020/03/11 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 �y���ŗ��Ή�</br>
        /// <br>           : �`�[�^�u�A���׃^�u�Ɂu����ŗ��v���ڂ�ǉ�</br>
        private string MakeTypeSalSlpQuery(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";

            // �Ώۃe�[�u��
            // SALESSLIPRF     SALSLP   ����f�[�^
            // SALESDETAILRF   SALDTL   ���㖾�׃f�[�^�@
            // SALESDETAILRF   SALDTL2  ���㖾�׃f�[�^�A
            // ACCEPTODRCARRF  AODCAR   �󒍃}�X�^(�ԗ�)
            // UOEORDERDTLRF   UOEODR   UOE�����f�[�^
            // SECINFOSETRF    SCINFS   ���_���ݒ�}�X�^
            // STOCKDETAILRF   STCDTL   �d�����׃f�[�^
            // STOCKSLIPRF     STCSLP   �d���f�[�^
            // BLGROUPURF    �@BLGRPU   BL�O���[�v�}�X�^
            // USERGDBDURF     USRGBU   ���[�U�[�K�C�h�}�X�^(�{�f�B)

            #region [Select���쐬]
            // -- DEL 2009/10/05 ------------------------------->>>
            //���x�A�b�v�̂��ߍ폜
            //selectTxt += "SELECT" + Environment.NewLine;
            //selectTxt += "  ROW_NUMBER()" + Environment.NewLine;
            //selectTxt += "   OVER(ORDER BY SALTBL.SALESSLIPNUMRF)" + Environment.NewLine;
            //selectTxt += "   AS ROWNUM" + Environment.NewLine;
            //selectTxt += " ,*" + Environment.NewLine;
            //selectTxt += " FROM (" + Environment.NewLine;
            // -- DEL 2009/10/05 -------------------------------<<<

            #region [�f�[�^���o���C��Query]

            #region [DEL 2009/09/04]
            // -- DEL 2009/09/04 ------------------------------------->>>
            ////������������𒴂���܂Ŏ擾
            //selectTxt += "  SELECT TOP " + paramWork.SearchCnt + Environment.NewLine;
            //selectTxt += "    SALSLP.SALESDATERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SALESSLIPNUMRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SALESROWNORF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.ACPTANODRSTATUSRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SALESSLIPCDRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SALESEMPLOYEENMRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SALESTOTALTAXEXCRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SALESTOTALTAXINCRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.GOODSNAMERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.GOODSNORF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.BLGOODSCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.BLGROUPCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SHIPMENTCNTRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.OPENPRICEDIVRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SALESUNITCOSTRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SALESMONEYTAXEXCRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.CONSTAXLAYMETHODRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SALESPRICECONSTAXRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.TOTALCOSTRF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.MODELDESIGNATIONNORF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.CATEGORYNORF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.MODELFULLNAMERF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.FIRSTENTRYDATERF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.SEARCHFRAMENORF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.FULLMODELRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SLIPNOTERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SLIPNOTE2RF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SLIPNOTE3RF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.FRONTEMPLOYEENMRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SALESINPUTNAMERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.CUSTOMERCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.CUSTOMERSNMRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SUPPLIERCDRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SUPPLIERSNMRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.PARTYSALESLIPNUMRF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.CARMNGCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL2.ACCEPTANORDERNORF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL2.SALESSLIPNUMRF AS SHIPMSALESSLIPNUM" + Environment.NewLine;
            //selectTxt += "   ,SALDTL2.SALESSLIPNUMRF AS SRCSALESSLIPNUM" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SALESORDERDIVCDRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.WAREHOUSENAMERF" + Environment.NewLine;
            //selectTxt += "   ,STCDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
            //selectTxt += "   ,UOEODR.SUPPLIERCDRF AS UOESUPPLIERCD" + Environment.NewLine;
            //selectTxt += "   ,UOEODR.SUPPLIERSNMRF AS UOESUPPLIERSNM" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.UOEREMARK1RF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.UOEREMARK2RF" + Environment.NewLine;
            //selectTxt += "   ,USRGBU.GUIDENAMERF" + Environment.NewLine;
            //selectTxt += "   ,SCINFS.SECTIONGUIDENMRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.DTLNOTERF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.COLORNAME1RF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.TRIMNAMERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.STDUNPRCLPRICERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.STDUNPRCSALUNPRCRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.STDUNPRCUNCSTRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.GOODSMAKERCDRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.MAKERNAMERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.COSTRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.CUSTSLIPNORF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.ADDUPADATERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.ACCRECDIVCDRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.DEBITNOTEDIVRF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.SECTIONCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.WAREHOUSECODERF" + Environment.NewLine;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
            ////if (paramWork.AcptAnOdrStatus[0] != 30)
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
            //selectTxt += "   ,SALDTL.ACPTANODRREMAINCNTRF" + Environment.NewLine; // ADD 2009.01.30
            //// ADD 2008.12.09 >>>
            //selectTxt += "   ,SALSLP.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.TAXATIONDIVCDRF" + Environment.NewLine;
            //selectTxt += "   ,STCSLP.PARTYSALESLIPNUMRF AS STOCKPARTYSALESLIPNUMRF" + Environment.NewLine;
            //// ADD 2008.12.09 <<<
            //selectTxt += "   ,SALSLP.SHIPMENTDAYRF" + Environment.NewLine;
            
            //// ADD 2009.01.06 >>>
            //selectTxt += "   ,SALSLP.ADDRESSEECODERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.ADDRESSEENAMERF" + Environment.NewLine;
            //selectTxt += "   ,SALSLP.ADDRESSEENAME2RF" + Environment.NewLine;
            //selectTxt += "   ,AODCAR.FRAMENORF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.ENTERPRISEGANRECODERF" + Environment.NewLine;
            //// ADD 2009.01.06 <<<
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
            //selectTxt += "   ,SALSLP.SEARCHSLIPDATERF" + Environment.NewLine;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
            //selectTxt += "   ,SALDTL.GOODSKINDCODERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.GOODSLGROUPRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.GOODSMGROUPRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.WAREHOUSESHELFNORF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.SALESSLIPCDDTLRF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.GOODSLGROUPNAMERF" + Environment.NewLine;
            //selectTxt += "   ,SALDTL.GOODSMGROUPNAMERF" + Environment.NewLine;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
            //selectTxt += "   ,SALSLP.DELIVEREDGOODSDIVRF" + Environment.NewLine; // �[�i�敪
            //selectTxt += "   ,AODCAR.CARMNGNORF" + Environment.NewLine; // �ԗ��Ǘ�SEQ
            //selectTxt += "   ,AODCAR.MAKERCODERF" + Environment.NewLine; // �Ԏ탁�[�J�[�R�[�h
            //selectTxt += "   ,AODCAR.MODELCODERF" + Environment.NewLine; // �Ԏ�R�[�h
            //selectTxt += "   ,AODCAR.MODELSUBCODERF" + Environment.NewLine; // �Ԏ�T�u�R�[�h
            //selectTxt += "   ,AODCAR.ENGINEMODELNMRF" + Environment.NewLine; // �G���W���^������
            //selectTxt += "   ,AODCAR.COLORCODERF" + Environment.NewLine; // �J���[�R�[�h
            //selectTxt += "   ,AODCAR.TRIMCODERF" + Environment.NewLine; // �g�����R�[�h
            //selectTxt += "   ,AODCAR.FULLMODELFIXEDNOARYRF" + Environment.NewLine; // �t���^���Œ�ԍ��z��
            //selectTxt += "   ,AODCAR.CATEGORYOBJARYRF" + Environment.NewLine; // �����I�u�W�F�N�g�z��
            //selectTxt += "   ,SALSLP.SALESINPUTCODERF" + Environment.NewLine; // ������͎҃R�[�h�i���s�ҁj
            //selectTxt += "   ,SALSLP.FRONTEMPLOYEECDRF" + Environment.NewLine; // ��t�]�ƈ��R�[�h�i�󒍎ҁj
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD

            //selectTxt += "  FROM (" + Environment.NewLine;

            //#region [����f�[�^���oQuery]
            //selectTxt += "   SELECT" + Environment.NewLine;
            //selectTxt += "     SALSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SALESDATERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SALESSLIPNUMRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.ACPTANODRSTATUSRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SALESSLIPCDRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SALESEMPLOYEENMRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SALESTOTALTAXEXCRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SALESTOTALTAXINCRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.CONSTAXLAYMETHODRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.TOTALCOSTRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SLIPNOTERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SLIPNOTE2RF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SLIPNOTE3RF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEENMRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.SALESINPUTNAMERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.CUSTOMERCODERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.CUSTOMERSNMRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.PARTYSALESLIPNUMRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.UOEREMARK1RF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.UOEREMARK2RF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.CUSTSLIPNORF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.ADDUPADATERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.ACCRECDIVCDRF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.DEBITNOTEDIVRF" + Environment.NewLine;
            //// �C�� 2009.01.16 >>>
            ////selectTxt += "    ,SALSLPSUB.SECTIONCODERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine;
            //// �C�� 2009.01.16 <<<
            //selectTxt += "    ,SALSLPSUB.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine; // ADD 2008.12.09
            //selectTxt += "    ,SALSLPSUB.SHIPMENTDAYRF" + Environment.NewLine;
            //// ADD 2009.01.06 >>>
            //selectTxt += "    ,SALSLPSUB.ADDRESSEECODERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.ADDRESSEENAMERF" + Environment.NewLine;
            //selectTxt += "    ,SALSLPSUB.ADDRESSEENAME2RF" + Environment.NewLine;
            //// ADD 2009.01.06 <<<
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
            //selectTxt += "    ,SALSLPSUB.SEARCHSLIPDATERF" + Environment.NewLine;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
            //selectTxt += "    ,SALSLPSUB.DELIVEREDGOODSDIVRF" + Environment.NewLine; // �[�i�敪
            //selectTxt += "    ,SALSLPSUB.SALESINPUTCODERF" + Environment.NewLine; // ������͎҃R�[�h�i���s�ҁj
            //selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEECDRF" + Environment.NewLine; // ��t�]�ƈ��R�[�h�i�󒍎ҁj
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
            ////if (paramWork.AcptAnOdrStatus != null)
            ////{
            ////    if (paramWork.AcptAnOdrStatus[0] == 30)  //�󒍃X�e�[�^�X=30  -> ���㗚���f�[�^����擾
            ////        selectTxt += "   FROM SALESHISTORYRF AS SALSLPSUB " + Environment.NewLine;
            ////    else                                     //�󒍃X�e�[�^�X!=30 -> ����f�[�^����擾
            ////        selectTxt += "   FROM SALESSLIPRF AS SALSLPSUB " + Environment.NewLine;
            ////}
            ////else
            ////{
            ////    //�w��Ȃ��͔���f�[�^����擾
            ////    selectTxt += "   FROM SALESSLIPRF AS SALSLPSUB " + Environment.NewLine;
            ////}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
            //selectTxt += "   FROM SALESSLIPRF AS SALSLPSUB " + Environment.NewLine;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD

            //selectTxt += MakeWhereString_SALSLPSUB(ref sqlCommand, paramWork, logicalMode);
            //#endregion  //[����f�[�^���oQuery]

            //selectTxt += "  ) AS SALSLP" + Environment.NewLine;

            //#region [JOIN]
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
            //////���㖾�׃f�[�^ or ���㗚�𖾍׃f�[�^
            ////if (paramWork.AcptAnOdrStatus != null)
            ////{
            ////    if (paramWork.AcptAnOdrStatus[0] == 30)  //�󒍃X�e�[�^�X=30  -> ���㗚�𖾍׃f�[�^����擾
            ////        selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL" + Environment.NewLine;
            ////    else                                     //�󒍃X�e�[�^�X!=30 -> ���㖾�׃f�[�^����擾
            ////        selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL" + Environment.NewLine;
            ////}
            ////else
            ////{
            ////    //�w��Ȃ��͔��㖾�׃f�[�^����擾
            ////    selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL" + Environment.NewLine;
            ////}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
            //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL" + Environment.NewLine;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD
            //selectTxt += "  ON  SALDTL.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND SALDTL.ACPTANODRSTATUSRF=SALSLP.ACPTANODRSTATUSRF" + Environment.NewLine;
            //selectTxt += "  AND SALDTL.SALESSLIPNUMRF=SALSLP.SALESSLIPNUMRF" + Environment.NewLine;

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
            //////���㖾�׃f�[�^ or ���㗚�𖾍׃f�[�^(���`�[)
            ////if (paramWork.AcptAnOdrStatus != null)
            ////{
            ////    if (paramWork.AcptAnOdrStatus[0] == 30)  //�󒍃X�e�[�^�X=30  -> ���㗚�𖾍׃f�[�^����擾
            ////        selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL2" + Environment.NewLine;
            ////    else                                     //�󒍃X�e�[�^�X!=30 -> ���㖾�׃f�[�^����擾
            ////        selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL2" + Environment.NewLine;
            ////}
            ////else
            ////{
            ////    //�w��Ȃ��͔��㖾�׃f�[�^����擾
            ////    selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL2" + Environment.NewLine;
            ////}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
            //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL2" + Environment.NewLine;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD
            //selectTxt += "  ON  SALDTL2.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND SALDTL2.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
            //selectTxt += "  AND SALDTL2.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;

            ////�󒍃}�X�^(�ԗ�)
            //selectTxt += "  LEFT JOIN ACCEPTODRCARRF AODCAR" + Environment.NewLine;
            //selectTxt += "  ON  AODCAR.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND AODCAR.ACCEPTANORDERNORF=SALDTL.ACCEPTANORDERNORF" + Environment.NewLine;

            //// ADD 2008.12.09 >>>
            ////selectTxt += "  AND AODCAR.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
            //selectTxt += "  AND (" + Environment.NewLine;
            //selectTxt += "         (SALDTL.ACPTANODRSTATUSRF = 10 AND AODCAR.ACPTANODRSTATUSRF = 1) " + Environment.NewLine; //�@����
            //selectTxt += "      OR (SALDTL.ACPTANODRSTATUSRF = 20 AND AODCAR.ACPTANODRSTATUSRF = 3)" + Environment.NewLine; // ��
            //selectTxt += "      OR (SALDTL.ACPTANODRSTATUSRF = 30 AND AODCAR.ACPTANODRSTATUSRF = 7)" + Environment.NewLine; // ����
            //selectTxt += "      OR (SALDTL.ACPTANODRSTATUSRF = 40 AND AODCAR.ACPTANODRSTATUSRF = 5)" + Environment.NewLine; // �o�ׁ@
            //selectTxt += "    )" + Environment.NewLine;
            //// ADD 2008.12.09 <<<

            ////UOE�����f�[�^
            //selectTxt += "  LEFT JOIN UOEORDERDTLRF UOEODR" + Environment.NewLine;
            //selectTxt += "  ON  UOEODR.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND UOEODR.COMMONSEQNORF=SALDTL.COMMONSEQNORF" + Environment.NewLine;

            ////���_���ݒ�}�X�^
            //selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS" + Environment.NewLine;
            //selectTxt += "  ON  SCINFS.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND SCINFS.SECTIONCODERF=SALSLP.SECTIONCODERF" + Environment.NewLine;
            ////�d�����׃f�[�^
            //selectTxt += "  LEFT JOIN STOCKDETAILRF STCDTL" + Environment.NewLine;
            //selectTxt += "  ON  STCDTL.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND STCDTL.SUPPLIERFORMALRF=SALDTL.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
            //selectTxt += "  AND STCDTL.STOCKSLIPDTLNUMRF=SALDTL.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;

            ////�d���f�[�^
            //selectTxt += "  LEFT JOIN STOCKSLIPRF STCSLP" + Environment.NewLine;
            //selectTxt += "  ON  STCSLP.ENTERPRISECODERF=STCDTL.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND STCSLP.SUPPLIERFORMALRF=STCDTL.SUPPLIERFORMALRF" + Environment.NewLine;
            //selectTxt += "  AND STCSLP.SUPPLIERSLIPNORF=STCDTL.SUPPLIERSLIPNORF" + Environment.NewLine;

            ////BL�O���[�v�}�X�^
            //selectTxt += "  LEFT JOIN BLGROUPURF BLGRPU" + Environment.NewLine;
            //selectTxt += "  ON  BLGRPU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND BLGRPU.BLGROUPCODERF=SALDTL.BLGROUPCODERF" + Environment.NewLine;

            ////���[�U�[�K�C�h�}�X�^(�{�f�B)
            //// �C�� 2009/05/12 >>>
            //#region DEL
            ////selectTxt += "  LEFT JOIN USERGDBDURF USRGBU" + Environment.NewLine;
            ////selectTxt += "  ON  USRGBU.ENTERPRISECODERF=BLGRPU.ENTERPRISECODERF" + Environment.NewLine;
            ////selectTxt += "  AND USRGBU.USERGUIDEDIVCDRF=71" + Environment.NewLine;
            ////selectTxt += "  AND USRGBU.GUIDECODERF=BLGRPU.SALESCODERF" + Environment.NewLine;
            //#endregion
            //selectTxt += "  LEFT JOIN USERGDBDURF USRGBU" + Environment.NewLine;
            //selectTxt += "  ON  USRGBU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND USRGBU.USERGUIDEDIVCDRF=71" + Environment.NewLine;
            //selectTxt += "  AND USRGBU.GUIDECODERF=SALDTL.SALESCODERF" + Environment.NewLine;
            //// �C�� 2009/05/12 <<<
            // -- DEL 2009/09/04 --------------------------------------------<<<
            //#endregion  //[JOIN]
            #endregion [DEL 2009/09/04]

            // -- ADD 2009/09/04 ------------------------------------------->>>
            //������������𒴂���܂Ŏ擾
            //selectTxt += "  SELECT TOP " + paramWork.SearchCnt + Environment.NewLine; // DEL 2015/02/05 ������
            //----- ADD 2015/02/05 ������ -------------------->>>>>
            if (paramWork.SearchCountCtrl == 1)
            {
                // ���o���������Ȃ��̏ꍇ
                selectTxt += "  SELECT " + Environment.NewLine;
            }
            else
            {
            selectTxt += "  SELECT TOP " + paramWork.SearchCnt + Environment.NewLine;
            }
            //----- ADD 2015/02/05 ������ --------------------<<<<<
            selectTxt += "    SALSLP.SALESDATERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESSLIPNUMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESROWNORF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESSLIPCDRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESEMPLOYEENMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESTOTALTAXEXCRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESTOTALTAXINCRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSNAMERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSNORF" + Environment.NewLine;
            selectTxt += "   ,GDSCHG.CHGDESTGOODSNORF" + Environment.NewLine; //�ϊ���i�ԁ@//ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�
            // -------------ADD 2009/12/28-------------->>>>>
            selectTxt += "   ,SALSLP.GOODSNORF_NOHALF" + Environment.NewLine;//�n�C�t��������̕i��
            // -------------ADD 2009/12/28--------------<<<<<
            selectTxt += "   ,SALSLP.BLGOODSCODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.BLGROUPCODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SHIPMENTCNTRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.LISTPRICETAXEXCFLRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.COSTRATERF" + Environment.NewLine;   // ADD �A��729 2011/08/18
            selectTxt += "   ,SALSLP.SALESRATERF" + Environment.NewLine;   // ADD �A��729 2011/08/18
            selectTxt += "   ,SALSLP.CONSTAXRATERF" + Environment.NewLine; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
            selectTxt += "   ,SALSLP.OPENPRICEDIVRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESUNITCOSTRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESMONEYTAXEXCRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.CONSTAXLAYMETHODRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESPRICECONSTAXRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.TOTALCOSTRF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.MODELDESIGNATIONNORF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.CATEGORYNORF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.MODELFULLNAMERF" + Environment.NewLine;
            // --- ADD m.suzuki 2010/04/02 ---------->>>>>
            selectTxt += "   ,AODCAR.MODELHALFNAMERF" + Environment.NewLine;
            // --- ADD m.suzuki 2010/04/02 ----------<<<<<
            selectTxt += "   ,AODCAR.FIRSTENTRYDATERF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.SEARCHFRAMENORF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.FULLMODELRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SLIPNOTERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SLIPNOTE2RF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SLIPNOTE3RF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.FRONTEMPLOYEENMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESINPUTNAMERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.CUSTOMERSNMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SUPPLIERCDRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SUPPLIERSNMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.PARTYSALESLIPNUMRF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.CARMNGCODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ACCEPTANORDERNORF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SHIPMSALESSLIPNUM" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SRCSALESSLIPNUM" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESORDERDIVCDRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.WAREHOUSENAMERF" + Environment.NewLine;
            selectTxt += "   ,STCDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
            selectTxt += "   ,UOEODR.SUPPLIERCDRF AS UOESUPPLIERCD" + Environment.NewLine;
            selectTxt += "   ,UOEODR.SUPPLIERSNMRF AS UOESUPPLIERSNM" + Environment.NewLine;
            selectTxt += "   ,SALSLP.UOEREMARK1RF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.UOEREMARK2RF" + Environment.NewLine;
            selectTxt += "   ,USRGBU.GUIDENAMERF" + Environment.NewLine;
            selectTxt += "   ,SCINFS.SECTIONGUIDENMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.DTLNOTERF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.COLORNAME1RF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.TRIMNAMERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.STDUNPRCLPRICERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.STDUNPRCSALUNPRCRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.STDUNPRCUNCSTRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSMAKERCDRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.MAKERNAMERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.COSTRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.CUSTSLIPNORF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ADDUPADATERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ACCRECDIVCDRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.DEBITNOTEDIVRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SECTIONCODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.WAREHOUSECODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ACPTANODRREMAINCNTRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.TAXATIONDIVCDRF" + Environment.NewLine;
            selectTxt += "   ,STCSLP.PARTYSALESLIPNUMRF AS STOCKPARTYSALESLIPNUMRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SHIPMENTDAYRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ADDRESSEECODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ADDRESSEENAMERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ADDRESSEENAME2RF" + Environment.NewLine;
            selectTxt += "   ,AODCAR.FRAMENORF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.ENTERPRISEGANRECODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SEARCHSLIPDATERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSKINDCODERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSLGROUPRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSMGROUPRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.WAREHOUSESHELFNORF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.SALESSLIPCDDTLRF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSLGROUPNAMERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.GOODSMGROUPNAMERF" + Environment.NewLine;
            selectTxt += "   ,SALSLP.DELIVEREDGOODSDIVRF" + Environment.NewLine; // �[�i�敪
            selectTxt += "   ,AODCAR.CARMNGNORF" + Environment.NewLine; // �ԗ��Ǘ�SEQ
            selectTxt += "   ,AODCAR.MAKERCODERF" + Environment.NewLine; // �Ԏ탁�[�J�[�R�[�h
            selectTxt += "   ,AODCAR.MODELCODERF" + Environment.NewLine; // �Ԏ�R�[�h
            selectTxt += "   ,AODCAR.MODELSUBCODERF" + Environment.NewLine; // �Ԏ�T�u�R�[�h
            selectTxt += "   ,AODCAR.ENGINEMODELNMRF" + Environment.NewLine; // �G���W���^������
            selectTxt += "   ,AODCAR.COLORCODERF" + Environment.NewLine; // �J���[�R�[�h
            selectTxt += "   ,AODCAR.TRIMCODERF" + Environment.NewLine; // �g�����R�[�h
            selectTxt += "   ,AODCAR.FULLMODELFIXEDNOARYRF" + Environment.NewLine; // �t���^���Œ�ԍ��z��
            selectTxt += "   ,AODCAR.FREESRCHMDLFXDNOARYRF" + Environment.NewLine; // ���R�����^���Œ�ԍ��z�� // ADD 2010/04/27
            selectTxt += "   ,AODCAR.CATEGORYOBJARYRF" + Environment.NewLine; // �����I�u�W�F�N�g�z��
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  ���� 2009/09/07 ADD
            selectTxt += "   ,AODCAR.MILEAGERF" + Environment.NewLine; // �ԗ����s����
            selectTxt += "   ,AODCAR.CARNOTERF" + Environment.NewLine; // ���q���l
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  ���� 2009/09/07 ADD
            selectTxt += "   ,SALSLP.SALESINPUTCODERF" + Environment.NewLine; // ������͎҃R�[�h�i���s�ҁj
            selectTxt += "   ,SALSLP.FRONTEMPLOYEECDRF" + Environment.NewLine; // ��t�]�ƈ��R�[�h�i�󒍎ҁj
            selectTxt += "   ,SALSLP.HISTORYDIVRF" + Environment.NewLine;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
            selectTxt += "   ,SALSLP.UPDATEDATETIMERF" + Environment.NewLine; // �X�V����
            selectTxt += "   ,SALSLP.UPDATEDATETIME" + Environment.NewLine; // �X�V����(����)  // ADD 2012/04/01 gezh Redmine#29250
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
            // -------------ADD 2009/12/28-------------->>>>>
            selectTxt += "    ,SALSLP.BFSALESUNITPRICERF" + Environment.NewLine;
            selectTxt += "    ,SALSLP.BFUNITCOSTRF" + Environment.NewLine;
            // -------------ADD 2009/12/28--------------<<<<<
            // -------------ADD 2010/08/05-------------->>>>>
            selectTxt += "    ,SALSLP.BFLISTPRICERF" + Environment.NewLine;
            // -------------ADD 2010/08/05--------------<<<<<
            // -------------ADD 2011/07/18-------------->>>>>
            selectTxt += "    ,SALSLP.AUTOANSWERDIVSCMRF" + Environment.NewLine;
            // -------------ADD 2011/07/18--------------<<<<<

            //---ADD START 2011/11/28 �k�m ----------------------------------->>>>>
            selectTxt += "    ,SALSLP.INQUIRYNUMBERRF" + Environment.NewLine;
            //---ADD END 2011/11/28 �k�m -----------------------------------<<<<<

            // -------------ADD 2010/01/29 ---------->>>>>
            selectTxt += "    ,SALSLP.RETUPPERCNTRF" + Environment.NewLine;
            selectTxt += "    ,SALSLP.RETUPPERCNTDIVRF" + Environment.NewLine;
            // -------------ADD 2010/01/29 ----------<<<<<
            // -----ADD 2010/12/20 ----->>>>>
            selectTxt += "    ,SALSLP.HISDTLSLIPNUMRF" + Environment.NewLine;
            selectTxt += "    ,SALSLP.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
            // -----ADD 2010/12/20 -----<<<<<

            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
            selectTxt += "    ,USRGBUF.GUIDENAMERF AS SALESAREANAMERF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE1RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE2RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE3RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE4RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE5RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE6RF" + Environment.NewLine;
            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<
 
            selectTxt += "  FROM (" + Environment.NewLine;

            #region [����f�[�^���oQuery]
            // -- ADD 2009/10/05 --------------------------------->>>
            bool SalSlipFlg = false;  //���オ�܂܂�邩
            bool AcpSlipFlg = false;  //�ݏo or �󒍂��܂܂�邩
            //�󒍁A�ݏo�̎w�肪���݂��邩���`�F�b�N
            foreach (Int32 iacptSt in paramWork.AcptAnOdrStatus)
            {
                if (iacptSt == 30)
                {
                    SalSlipFlg = true;
                }
                if (iacptSt != 30)
                {
                    AcpSlipFlg = true;
                }
            }
            // -- ADD 2009/10/05 ---------------------------------<<<

            // -- ADD 2009/10/05 --------------------------------->>>
            if (SalSlipFlg)
            {
            // -- ADD 2009/10/05 ---------------------------------<<<
                //���㒊�o�p(���㗚���f�[�^���璊�o)
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     SALSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESDATERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESSLIPCDRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESTOTALTAXEXCRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESTOTALTAXINCRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CONSTAXLAYMETHODRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.TOTALCOSTRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CONSTAXRATERF" + Environment.NewLine; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                selectTxt += "    ,SALSLPSUB.SLIPNOTERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SLIPNOTE2RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SLIPNOTE3RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESINPUTNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.PARTYSALESLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.UOEREMARK1RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.UOEREMARK2RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CUSTSLIPNORF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDUPADATERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ACCRECDIVCDRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.DEBITNOTEDIVRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SHIPMENTDAYRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDRESSEECODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDRESSEENAMERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDRESSEENAME2RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SEARCHSLIPDATERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.DELIVEREDGOODSDIVRF" + Environment.NewLine; // �[�i�敪
                selectTxt += "    ,SALSLPSUB.SALESINPUTCODERF" + Environment.NewLine; // ������͎҃R�[�h�i���s�ҁj
                selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEECDRF" + Environment.NewLine; // ��t�]�ƈ��R�[�h�i�󒍎ҁj
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                selectTxt += "    ,SALSLPSUB.UPDATEDATETIMERF" + Environment.NewLine; // �X�V����
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
                selectTxt += "    ,SALDTL.SALESROWNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSNORF" + Environment.NewLine;
                // --- UPD m.suzuki 2010/03/11 ---------->>>>>
                //// -------------ADD 2009/12/28-------------->>>>>
                //selectTxt += "    ,REPLACE (SALDTL3.GOODSNORF, '-', '') AS GOODSNORF_NOHALF" + Environment.NewLine;//�n�C�t��������̕i��
                //// -------------ADD 2009/12/28--------------<<<<<
                selectTxt += "    ,REPLACE (SALDTL.GOODSNORF, '-', '') AS GOODSNORF_NOHALF" + Environment.NewLine;//�n�C�t��������̕i�ԁi���㗚�𖾍ׂ���擾����j
                // --- UPD m.suzuki 2010/03/11 ----------<<<<<
                selectTxt += "    ,SALDTL.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.COSTRATERF" + Environment.NewLine;   // ADD �A��729 2011/08/18
                selectTxt += "    ,SALDTL.SALESRATERF" + Environment.NewLine;   // ADD �A��729 2011/08/18
                selectTxt += "    ,SALDTL.OPENPRICEDIVRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESMONEYTAXEXCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESPRICECONSTAXRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL2.ACCEPTANORDERNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL2.SALESSLIPNUMRF AS SHIPMSALESSLIPNUM" + Environment.NewLine;
                selectTxt += "    ,SALDTL2.SALESSLIPNUMRF AS SRCSALESSLIPNUM" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESORDERDIVCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.DTLNOTERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STDUNPRCLPRICERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STDUNPRCSALUNPRCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STDUNPRCUNCSTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.COSTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL3.ACPTANODRREMAINCNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.TAXATIONDIVCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSKINDCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESSLIPCDDTLRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSLGROUPNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSMGROUPNAMERF" + Environment.NewLine;

                selectTxt += "    ,SALDTL.COMMONSEQNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.ACCEPTANORDERNORF AS ACCEPTANORDERNORF_1" + Environment.NewLine; // �󒍃}�X�^�i�ԗ��j��JOIN�o���Ȃ��������ߒǉ�
                // -----ADD 2010/12/20 ----->>>>>
                selectTxt += "    ,SALDTL4.SALESSLIPNUMRF AS HISDTLSLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.ACPTANODRSTATUSSRCRF AS ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                // -----ADD 2010/12/20 -----<<<<<
                selectTxt += "    ,(CASE WHEN SALDTL3.ACPTANODRREMAINCNTRF IS NULL THEN 1 ELSE 0 END) AS HISTORYDIVRF" + Environment.NewLine;
                // -------------ADD 2009/12/28-------------->>>>>
                selectTxt += "    ,SALDTL.BFSALESUNITPRICERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.BFUNITCOSTRF" + Environment.NewLine;
                // -------------ADD 2009/12/28--------------<<<<<
                // -------------ADD 2010/08/05-------------->>>>>
                selectTxt += "    ,SALDTL.BFLISTPRICERF" + Environment.NewLine;
                // -------------ADD 2010/08/05--------------<<<<<
                // -------------ADD 2011/07/18-------------->>>>>
                selectTxt += "    ,SALDTL.AUTOANSWERDIVSCMRF" + Environment.NewLine;
                // -------------ADD 2011/07/18--------------<<<<<

                //---ADD START 2011/11/28 �k�m ----------------------------------->>>>>
                selectTxt += "    ,SALDTL.INQUIRYNUMBERRF" + Environment.NewLine;
                //---ADD END 2011/11/28 �k�m -----------------------------------<<<<<

                // -------------ADD 2010/01/29 ---------->>>>>
                selectTxt += "    ,RETURNU.RETUPPERCNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.UPDATEDATETIMERF AS UPDATEDATETIME" + Environment.NewLine; // �X�V�����i���㗚�𖾍ׂ���擾����j // ADD 2012/04/01 gezh Redmine#29250
                selectTxt += "    ,(CASE WHEN RETURNU.RETUPPERCNTRF IS NULL THEN 1 ELSE 0 END) AS RETUPPERCNTDIVRF" + Environment.NewLine;
                // -------------ADD 2010/01/29 ----------<<<<<
                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "   FROM SALESHISTORYRF AS SALSLPSUB " + Environment.NewLine;
                selectTxt += "   FROM SALESHISTORYRF AS SALSLPSUB WITH (READUNCOMMITTED) " + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<

                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL" + Environment.NewLine;
                selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<
                selectTxt += "  ON  SALDTL.ENTERPRISECODERF=SALSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SALDTL.ACPTANODRSTATUSRF=SALSLPSUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "  AND SALDTL.SALESSLIPNUMRF=SALSLPSUB.SALESSLIPNUMRF" + Environment.NewLine;

                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL2" + Environment.NewLine;
                selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL2 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<
                selectTxt += "  ON  SALDTL2.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SALDTL2.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                selectTxt += "  AND SALDTL2.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;

                //�󒍎c���͔��㖾�׃f�[�^�ɂ̂ݑ��݂��邽�ߌ���
                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL3" + Environment.NewLine;
                selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL3 WITH (READUNCOMMITTED) " + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<
                selectTxt += "  ON  SALDTL3.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SALDTL3.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "  AND SALDTL3.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMRF" + Environment.NewLine;
                // -------------ADD 2010/01/29 ---------->>>>>
                // -----ADD 2010/12/20 ----->>>>>
                selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL4 WITH (READUNCOMMITTED) " + Environment.NewLine;
                selectTxt += "  ON  SALDTL4.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SALDTL4.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                selectTxt += "  AND SALDTL4.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;
                // -----ADD 2010/12/20 -----<<<<<
                //�ԕi����ݒ�}�X�^
                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "  LEFT JOIN RETURNUPPERSTRF RETURNU" + Environment.NewLine;
                selectTxt += "  LEFT JOIN RETURNUPPERSTRF RETURNU WITH (READUNCOMMITTED) " + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<
                selectTxt += "  ON  RETURNU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND RETURNU.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "  AND RETURNU.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMRF" + Environment.NewLine;
                // -------------ADD 2010/01/29 ----------<<<<<
                sqlCommand.Parameters.Clear();  // ADD 2009/10/05

                selectTxt += MakeWhereString_SALSLPSUB(ref sqlCommand, paramWork, logicalMode, 0);
            }  // ADD 2009/10/05 

            // -- DEL 2009/10/05 ----------------------------->>>
            //bool SalSlipFlg = false;
            ////�󒍁A�ݏo�̎w�肪���݂��邩���`�F�b�N
            //foreach (Int32 iacptSt in paramWork.AcptAnOdrStatus)
            //{
            //    if (iacptSt != 30)
            //    {
            //        SalSlipFlg = true;
            //        break;
            //    }
            //}
            // -- DEL 2009/10/05 -----------------------------<<<

            // -- UPD 2009/10/05 ----------------------------->>>
            //if (SalSlipFlg)
            //{
            //    selectTxt += "UNION ALL" + Environment.NewLine;

            if ((SalSlipFlg) && (AcpSlipFlg))
            {
                selectTxt += "UNION ALL" + Environment.NewLine;
            }
            // -- UPD 2009/10/05 -----------------------------<<<

            // -- ADD 2009/10/05 ----------------------------->>>
            if (AcpSlipFlg)
            {
            // -- ADD 2009/10/05 -----------------------------<<<
                //�󒍁A�ݏo�f�[�^�p�i����f�[�^���璊�o�j
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     SALSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESDATERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESSLIPCDRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESTOTALTAXEXCRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESTOTALTAXINCRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CONSTAXLAYMETHODRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.TOTALCOSTRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CONSTAXRATERF" + Environment.NewLine; // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                selectTxt += "    ,SALSLPSUB.SLIPNOTERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SLIPNOTE2RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SLIPNOTE3RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEENMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SALESINPUTNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.PARTYSALESLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.UOEREMARK1RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.UOEREMARK2RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.CUSTSLIPNORF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDUPADATERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ACCRECDIVCDRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.DEBITNOTEDIVRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SHIPMENTDAYRF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDRESSEECODERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDRESSEENAMERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.ADDRESSEENAME2RF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.SEARCHSLIPDATERF" + Environment.NewLine;
                selectTxt += "    ,SALSLPSUB.DELIVEREDGOODSDIVRF" + Environment.NewLine; // �[�i�敪
                selectTxt += "    ,SALSLPSUB.SALESINPUTCODERF" + Environment.NewLine; // ������͎҃R�[�h�i���s�ҁj
                selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEECDRF" + Environment.NewLine; // ��t�]�ƈ��R�[�h�i�󒍎ҁj
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                selectTxt += "    ,SALSLPSUB.UPDATEDATETIMERF" + Environment.NewLine; // �X�V����
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
                selectTxt += "    ,SALDTL.SALESROWNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSNORF" + Environment.NewLine;
                // -------------ADD 2009/12/28-------------->>>>>
                selectTxt += "    ,REPLACE (SALDTL.GOODSNORF, '-', '') AS GOODSNORF_NOHALF" + Environment.NewLine;//�n�C�t��������̕i��
                // -------------ADD 2009/12/28--------------<<<<<
                selectTxt += "    ,SALDTL.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.COSTRATERF" + Environment.NewLine;   // ADD �A��729 2011/08/18
                selectTxt += "    ,SALDTL.SALESRATERF" + Environment.NewLine;   // ADD �A��729 2011/08/18
                selectTxt += "    ,SALDTL.OPENPRICEDIVRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESMONEYTAXEXCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESPRICECONSTAXRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL2.ACCEPTANORDERNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL2.SALESSLIPNUMRF AS SHIPMSALESSLIPNUM" + Environment.NewLine;
                selectTxt += "    ,SALDTL2.SALESSLIPNUMRF AS SRCSALESSLIPNUM" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESORDERDIVCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.DTLNOTERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STDUNPRCLPRICERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STDUNPRCSALUNPRCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STDUNPRCUNCSTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.COSTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.ACPTANODRREMAINCNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.TAXATIONDIVCDRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSKINDCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESSLIPCDDTLRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSLGROUPNAMERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.GOODSMGROUPNAMERF" + Environment.NewLine;

                selectTxt += "    ,SALDTL.COMMONSEQNORF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.SALESCODERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.ACCEPTANORDERNORF AS ACCEPTANORDERNORF_1" + Environment.NewLine; // �󒍃}�X�^�i�ԗ��j��JOIN�o���Ȃ��������ߒǉ�
                // -----ADD 2010/12/20 ----->>>>>
                selectTxt += "    ,'' AS HISDTLSLIPNUMRF" + Environment.NewLine;
                selectTxt += "    ,0 AS ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                // -----ADD 2010/12/20 -----<<<<<
                selectTxt += "    ,0 AS HISTORYDIVRF" + Environment.NewLine;
                // -------------ADD 2009/12/28-------------->>>>>
                selectTxt += "    ,SALDTL.BFSALESUNITPRICERF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.BFUNITCOSTRF" + Environment.NewLine;
                // -------------ADD 2009/12/28--------------<<<<<
                // -------------ADD 2010/08/05-------------->>>>>
                selectTxt += "    ,SALDTL.BFLISTPRICERF" + Environment.NewLine;
                // -------------ADD 2010/08/05--------------<<<<<
                // -------------ADD 2011/07/18-------------->>>>>
                selectTxt += "    ,SALDTL.AUTOANSWERDIVSCMRF" + Environment.NewLine;
                // -------------ADD 2011/07/18--------------<<<<<

                //---ADD START 2011/11/28 �k�m ----------------------------------->>>>>
                selectTxt += "    ,SALDTL.INQUIRYNUMBERRF" + Environment.NewLine;
                //---ADD END 2011/11/28 �k�m -----------------------------------<<<<<

                // -------------ADD 2010/01/29 ---------->>>>>
                selectTxt += "    ,RETURNU.RETUPPERCNTRF" + Environment.NewLine;
                selectTxt += "    ,SALDTL.UPDATEDATETIMERF AS UPDATEDATETIME" + Environment.NewLine;  // �X�V�����i���㖾�ׂ���擾����j // ADD 2012/04/01 gezh Redmine#29250 
                selectTxt += "    ,(CASE WHEN RETURNU.RETUPPERCNTRF IS NULL THEN 1 ELSE 0 END) AS RETUPPERCNTDIVRF" + Environment.NewLine;
                // -------------ADD 2010/01/29 ----------<<<<<

                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "   FROM SALESSLIPRF AS SALSLPSUB " + Environment.NewLine;
                selectTxt += "   FROM SALESSLIPRF AS SALSLPSUB WITH (READUNCOMMITTED) " + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<

                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL" + Environment.NewLine;
                selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL WITH (READUNCOMMITTED) " + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<
                selectTxt += "  ON  SALDTL.ENTERPRISECODERF=SALSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SALDTL.ACPTANODRSTATUSRF=SALSLPSUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "  AND SALDTL.SALESSLIPNUMRF=SALSLPSUB.SALESSLIPNUMRF" + Environment.NewLine;
                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL2" + Environment.NewLine;
                selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL2 WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<
                selectTxt += "  ON  SALDTL2.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SALDTL2.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
                selectTxt += "  AND SALDTL2.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;
                // -------------ADD 2010/01/29 ---------->>>>>
                //�ԕi����ݒ�}�X�^
                // -- UPD 2010/06/09 ----------------------------------------->>>
                //selectTxt += "  LEFT JOIN RETURNUPPERSTRF RETURNU" + Environment.NewLine;
                selectTxt += "  LEFT JOIN RETURNUPPERSTRF RETURNU WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2010/06/09 -----------------------------------------<<<
                selectTxt += "  ON  RETURNU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND RETURNU.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "  AND RETURNU.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMRF" + Environment.NewLine;
                // -------------ADD 2010/01/29 ----------<<<<<
                //�p�����[�^�̏d���w���h�����߁A��x�N���A
                sqlCommand.Parameters.Clear();
                selectTxt += MakeWhereString_SALSLPSUB(ref sqlCommand, paramWork, logicalMode, 1);
            }
            #endregion  //[����f�[�^���oQuery]

            selectTxt += "  ) AS SALSLP" + Environment.NewLine;

            #region [JOIN]

            //�󒍃}�X�^(�ԗ�)
            // -- UPD 2010/06/09 ----------------------------------------->>>
            //selectTxt += "  LEFT JOIN ACCEPTODRCARRF AODCAR" + Environment.NewLine;
            selectTxt += "  LEFT JOIN ACCEPTODRCARRF AODCAR WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------------<<<
            selectTxt += "  ON  AODCAR.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND AODCAR.ACCEPTANORDERNORF=SALSLP.ACCEPTANORDERNORF_1" + Environment.NewLine;
            selectTxt += "  AND (" + Environment.NewLine;
            selectTxt += "         (SALSLP.ACPTANODRSTATUSRF = 10 AND AODCAR.ACPTANODRSTATUSRF = 1) " + Environment.NewLine; //�@����
            selectTxt += "      OR (SALSLP.ACPTANODRSTATUSRF = 20 AND AODCAR.ACPTANODRSTATUSRF = 3)" + Environment.NewLine; // ��
            selectTxt += "      OR (SALSLP.ACPTANODRSTATUSRF = 30 AND AODCAR.ACPTANODRSTATUSRF = 7)" + Environment.NewLine; // ����
            selectTxt += "      OR (SALSLP.ACPTANODRSTATUSRF = 40 AND AODCAR.ACPTANODRSTATUSRF = 5)" + Environment.NewLine; // �o�ׁ@
            selectTxt += "    )" + Environment.NewLine;

            //UOE�����f�[�^
            // -- UPD 2010/06/09 ----------------------------------------->>>
            //selectTxt += "  LEFT JOIN UOEORDERDTLRF UOEODR" + Environment.NewLine;
            selectTxt += "  LEFT JOIN UOEORDERDTLRF UOEODR WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------------<<<
            selectTxt += "  ON  UOEODR.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND UOEODR.COMMONSEQNORF=SALSLP.COMMONSEQNORF" + Environment.NewLine;
            // -- ADD 2010/06/07 -------------------------------->>>
            selectTxt += "  AND UOEODR.UOEKINDRF=0" + Environment.NewLine;
            // -- ADD 2010/06/07 --------------------------------<<<

            //���_���ݒ�}�X�^
            // -- UPD 2010/06/09 ----------------------------------------->>>
            //selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS" + Environment.NewLine;
            selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------------<<<
            selectTxt += "  ON  SCINFS.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SCINFS.SECTIONCODERF=SALSLP.SECTIONCODERF" + Environment.NewLine;
            //�d�����׃f�[�^
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
            //selectTxt += "  LEFT JOIN STOCKDETAILRF STCDTL" + Environment.NewLine;
            // -- UPD 2010/06/09 ----------------------------------------->>>
            //selectTxt += "  LEFT JOIN STOCKSLHISTDTLRF STCDTL" + Environment.NewLine;
            selectTxt += "  LEFT JOIN STOCKSLHISTDTLRF STCDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------------<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
            selectTxt += "  ON  STCDTL.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND STCDTL.SUPPLIERFORMALRF=SALSLP.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
            selectTxt += "  AND STCDTL.STOCKSLIPDTLNUMRF=SALSLP.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;

            //�d���f�[�^
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
            //selectTxt += "  LEFT JOIN STOCKSLIPRF STCSLP" + Environment.NewLine;
            // -- UPD 2010/06/09 ----------------------------------------->>>
            //selectTxt += "  LEFT JOIN STOCKSLIPHISTRF STCSLP" + Environment.NewLine;
            selectTxt += "  LEFT JOIN STOCKSLIPHISTRF STCSLP WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------------<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
            selectTxt += "  ON  STCSLP.ENTERPRISECODERF=STCDTL.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND STCSLP.SUPPLIERFORMALRF=STCDTL.SUPPLIERFORMALRF" + Environment.NewLine;
            selectTxt += "  AND STCSLP.SUPPLIERSLIPNORF=STCDTL.SUPPLIERSLIPNORF" + Environment.NewLine;

            //BL�O���[�v�}�X�^
            // -- DEL 2009/10/05 -------------------------------------->>>
            //selectTxt += "  LEFT JOIN BLGROUPURF BLGRPU" + Environment.NewLine;
            //selectTxt += "  ON  BLGRPU.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            //selectTxt += "  AND BLGRPU.BLGROUPCODERF=SALSLP.BLGROUPCODERF" + Environment.NewLine;
            // -- DEL 2009/10/05 --------------------------------------<<<

            //���[�U�[�K�C�h�}�X�^(�{�f�B)
            // -- UPD 2010/06/09 ----------------------------------------->>>
            //selectTxt += "  LEFT JOIN USERGDBDURF USRGBU" + Environment.NewLine;
            selectTxt += "  LEFT JOIN USERGDBDURF USRGBU WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------------<<<
            selectTxt += "  ON  USRGBU.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND USRGBU.USERGUIDEDIVCDRF=71" + Environment.NewLine;
            selectTxt += "  AND USRGBU.GUIDECODERF=SALSLP.SALESCODERF" + Environment.NewLine;

            //--- ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή� ----->>>>>
            selectTxt += "  LEFT JOIN GOODSNOCHANGERF GDSCHG WITH (READUNCOMMITTED)" + Environment.NewLine;
            selectTxt += "  ON  GDSCHG.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND GDSCHG.GOODSMAKERCDRF=SALSLP.GOODSMAKERCDRF" + Environment.NewLine;
            selectTxt += "  AND GDSCHG.CHGSRCGOODSNORF=SALSLP.GOODSNORF" + Environment.NewLine;
            //--- ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή� -----<<<<<
            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
            selectTxt += " LEFT JOIN CUSTOMERRF CUSTOMER WITH (READUNCOMMITTED)" + Environment.NewLine;
            selectTxt += " ON  CUSTOMER.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND CUSTOMER.CUSTOMERCODERF=SALSLP.CUSTOMERCODERF" + Environment.NewLine;

            selectTxt += " LEFT JOIN USERGDBDURF USRGBUF WITH (READUNCOMMITTED)" + Environment.NewLine;
            selectTxt += " ON  USRGBUF.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USRGBUF.USERGUIDEDIVCDRF=21" + Environment.NewLine;
            selectTxt += " AND USRGBUF.LOGICALDELETECODERF=0" + Environment.NewLine;
            selectTxt += " AND USRGBUF.GUIDECODERF=CUSTOMER.SALESAREACODERF" + Environment.NewLine;
            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<
            #endregion  //[JOIN]
            // -- ADD 2009/09/04 -------------------------------------------<<<

            //WHERE��
            selectTxt += MakeWhereString_SALTBL(ref sqlCommand, paramWork, logicalMode);

            #endregion  //[�f�[�^���o���C��Query]

            // -- DEL 2009/10/05 ----------------------->>>
            //selectTxt += " ) AS SALTBL" + Environment.NewLine;

            ////ORDER BY
            //selectTxt += " ORDER BY ROWNUM DESC";
            // -- DEL 2009/10/05 -----------------------<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
            //selectTxt += " ORDER BY SALSLP.SALESDATERF, SALSLP.SALESSLIPNUMRF" + Environment.NewLine; // DEL 2015/02/05 ������
            //----- ADD 2015/02/05 ������ -------------------->>>>>
            if (paramWork.SearchCountCtrl == 1)
            {
                // ���o���������Ȃ��̏ꍇ
                selectTxt += " ORDER BY SALSLP.SALESDATERF, SALSLP.SALESSLIPNUMRF, SALSLP.SALESROWNORF" + Environment.NewLine;
            }
            else
            {
            selectTxt += " ORDER BY SALSLP.SALESDATERF, SALSLP.SALESSLIPNUMRF" + Environment.NewLine;
            }
            //----- ADD 2015/02/05 ������ --------------------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
            #endregion

            return selectTxt;
        }
        #endregion  //[CustPrtPprSalTblRsltWork�p SELECT����������]

        #region [DEL 2009/09/04]
        // -- DEL 2009/09/04 ------------------------------>>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
        //#region [���㗚���f�[�^�p SELECT����������]
        ///// <summary>
        ///// ���㗚���f�[�^�pSELECT���쐬
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        ///// <param name="paramWork">��������</param>
        ///// <param name="logicalMode">�_���폜�敪</param>
        ///// <returns>���㗚���f�[�^�pSELECT��</returns>
        ///// <br>Note       : ���㗚���f�[�^�pSELECT�����쐬���Ė߂��܂�</br>
        ///// <br>Programmer : 22018 ��� ���b</br>
        ///// <br>Date       : 2009.08.24</br>
        //private string MakeTypeSalSlpHisQuery( ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode )
        //{
        //    string selectTxt = "";

        //    // �Ώۃe�[�u��
        //    // SALESHISTORYRF    SALSLP   ���㗚���f�[�^ 
        //    // SALESHISTDTLRF    SALDTL   ���㗚�𖾍׃f�[�^�@ 
        //    // SALESHISTDTLRF    SALDTL2  ���㗚�𖾍׃f�[�^�A 
        //    // ACCEPTODRCARRF    AODCAR   �󒍃}�X�^(�ԗ�)
        //    // UOEORDERDTLRF     UOEODR   UOE�����f�[�^
        //    // SECINFOSETRF      SCINFS   ���_���ݒ�}�X�^
        //    // STOCKSLHISTDTLRF  STCDTL   �d�����𖾍׃f�[�^ 
        //    // STOCKSLIPHISTRF   STCSLP   �d�������f�[�^ 
        //    // BLGROUPURF        BLGRPU   BL�O���[�v�}�X�^
        //    // USERGDBDURF       USRGBU   ���[�U�[�K�C�h�}�X�^(�{�f�B)

        //    #region [Select���쐬]
        //    selectTxt += "SELECT" + Environment.NewLine;
        //    selectTxt += "  ROW_NUMBER()" + Environment.NewLine;
        //    selectTxt += "   OVER(ORDER BY SALTBL.SALESSLIPNUMRF)" + Environment.NewLine;
        //    selectTxt += "   AS ROWNUM" + Environment.NewLine;
        //    selectTxt += " ,*" + Environment.NewLine;
        //    selectTxt += " FROM (" + Environment.NewLine;

        //    #region [�f�[�^���o���C��Query]
        //    //������������𒴂���܂Ŏ擾
        //    selectTxt += "  SELECT TOP " + paramWork.SearchCnt + Environment.NewLine;
        //    selectTxt += "    SALSLP.SALESDATERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SALESSLIPNUMRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SALESROWNORF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.ACPTANODRSTATUSRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SALESSLIPCDRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SALESEMPLOYEENMRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SALESTOTALTAXEXCRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SALESTOTALTAXINCRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSNAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSNORF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.BLGOODSCODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.BLGROUPCODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SHIPMENTCNTRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.OPENPRICEDIVRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SALESUNITCOSTRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SALESMONEYTAXEXCRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.CONSTAXLAYMETHODRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SALESPRICECONSTAXRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.TOTALCOSTRF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.MODELDESIGNATIONNORF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.CATEGORYNORF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.MODELFULLNAMERF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.FIRSTENTRYDATERF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.SEARCHFRAMENORF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.FULLMODELRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SLIPNOTERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SLIPNOTE2RF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SLIPNOTE3RF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.FRONTEMPLOYEENMRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SALESINPUTNAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.CUSTOMERCODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.CUSTOMERSNMRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SUPPLIERCDRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SUPPLIERSNMRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.PARTYSALESLIPNUMRF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.CARMNGCODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL2.ACCEPTANORDERNORF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL2.SALESSLIPNUMRF AS SHIPMSALESSLIPNUM" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL2.SALESSLIPNUMRF AS SRCSALESSLIPNUM" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SALESORDERDIVCDRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.WAREHOUSENAMERF" + Environment.NewLine;
        //    selectTxt += "   ,STCDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
        //    selectTxt += "   ,UOEODR.SUPPLIERCDRF AS UOESUPPLIERCD" + Environment.NewLine;
        //    selectTxt += "   ,UOEODR.SUPPLIERSNMRF AS UOESUPPLIERSNM" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.UOEREMARK1RF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.UOEREMARK2RF" + Environment.NewLine;
        //    selectTxt += "   ,USRGBU.GUIDENAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SCINFS.SECTIONGUIDENMRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.DTLNOTERF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.COLORNAME1RF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.TRIMNAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.STDUNPRCLPRICERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.STDUNPRCSALUNPRCRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.STDUNPRCUNCSTRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSMAKERCDRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.MAKERNAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.COSTRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.CUSTSLIPNORF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.ADDUPADATERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.ACCRECDIVCDRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.DEBITNOTEDIVRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SECTIONCODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.WAREHOUSECODERF" + Environment.NewLine;
        //    //selectTxt += "   ,SALDTL.ACPTANODRREMAINCNTRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.TAXATIONDIVCDRF" + Environment.NewLine;
        //    selectTxt += "   ,STCSLP.PARTYSALESLIPNUMRF AS STOCKPARTYSALESLIPNUMRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SHIPMENTDAYRF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.ADDRESSEECODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.ADDRESSEENAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.ADDRESSEENAME2RF" + Environment.NewLine;
        //    selectTxt += "   ,AODCAR.FRAMENORF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.ENTERPRISEGANRECODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.SEARCHSLIPDATERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSKINDCODERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSLGROUPRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSMGROUPRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.WAREHOUSESHELFNORF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.SALESSLIPCDDTLRF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSLGROUPNAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SALDTL.GOODSMGROUPNAMERF" + Environment.NewLine;
        //    selectTxt += "   ,SALSLP.DELIVEREDGOODSDIVRF" + Environment.NewLine; // �[�i�敪
        //    selectTxt += "   ,AODCAR.CARMNGNORF" + Environment.NewLine; // �ԗ��Ǘ�SEQ
        //    selectTxt += "   ,AODCAR.MAKERCODERF" + Environment.NewLine; // �Ԏ탁�[�J�[�R�[�h
        //    selectTxt += "   ,AODCAR.MODELCODERF" + Environment.NewLine; // �Ԏ�R�[�h
        //    selectTxt += "   ,AODCAR.MODELSUBCODERF" + Environment.NewLine; // �Ԏ�T�u�R�[�h
        //    selectTxt += "   ,AODCAR.ENGINEMODELNMRF" + Environment.NewLine; // �G���W���^������
        //    selectTxt += "   ,AODCAR.COLORCODERF" + Environment.NewLine; // �J���[�R�[�h
        //    selectTxt += "   ,AODCAR.TRIMCODERF" + Environment.NewLine; // �g�����R�[�h
        //    selectTxt += "   ,AODCAR.FULLMODELFIXEDNOARYRF" + Environment.NewLine; // �t���^���Œ�ԍ��z��
        //    selectTxt += "   ,AODCAR.CATEGORYOBJARYRF" + Environment.NewLine; // �����I�u�W�F�N�g�z��
        //    selectTxt += "   ,SALSLP.SALESINPUTCODERF" + Environment.NewLine; // ������͎҃R�[�h�i���s�ҁj
        //    selectTxt += "   ,SALSLP.FRONTEMPLOYEECDRF" + Environment.NewLine; // ��t�]�ƈ��R�[�h�i�󒍎ҁj

        //    selectTxt += "  FROM (" + Environment.NewLine;

        //    #region [���㗚���f�[�^���oQuery]
        //    selectTxt += "   SELECT" + Environment.NewLine;
        //    selectTxt += "     SALSLPSUB.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SALESDATERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SALESSLIPNUMRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.ACPTANODRSTATUSRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SALESSLIPCDRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SALESEMPLOYEENMRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SALESTOTALTAXEXCRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SALESTOTALTAXINCRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.CONSTAXLAYMETHODRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.TOTALCOSTRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SLIPNOTERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SLIPNOTE2RF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SLIPNOTE3RF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEENMRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SALESINPUTNAMERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.CUSTOMERCODERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.CUSTOMERSNMRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.PARTYSALESLIPNUMRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.UOEREMARK1RF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.UOEREMARK2RF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.CUSTSLIPNORF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.ADDUPADATERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.ACCRECDIVCDRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.DEBITNOTEDIVRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SHIPMENTDAYRF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.ADDRESSEECODERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.ADDRESSEENAMERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.ADDRESSEENAME2RF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.SEARCHSLIPDATERF" + Environment.NewLine;
        //    selectTxt += "    ,SALSLPSUB.DELIVEREDGOODSDIVRF" + Environment.NewLine; // �[�i�敪
        //    selectTxt += "    ,SALSLPSUB.SALESINPUTCODERF" + Environment.NewLine; // ������͎҃R�[�h�i���s�ҁj
        //    selectTxt += "    ,SALSLPSUB.FRONTEMPLOYEECDRF" + Environment.NewLine; // ��t�]�ƈ��R�[�h�i�󒍎ҁj

        //    //selectTxt += "   FROM SALESSLIPRF AS SALSLPSUB " + Environment.NewLine;
        //    selectTxt += "   FROM SALESHISTORYRF AS SALSLPSUB " + Environment.NewLine;

        //    selectTxt += MakeWhereString_SALSLPSUB( ref sqlCommand, paramWork, logicalMode );
        //    #endregion

        //    selectTxt += "  ) AS SALSLP" + Environment.NewLine;

        //    #region [JOIN]
        //    //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL" + Environment.NewLine;
        //    selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL" + Environment.NewLine;
        //    selectTxt += "  ON  SALDTL.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND SALDTL.ACPTANODRSTATUSRF=SALSLP.ACPTANODRSTATUSRF" + Environment.NewLine;
        //    selectTxt += "  AND SALDTL.SALESSLIPNUMRF=SALSLP.SALESSLIPNUMRF" + Environment.NewLine;

        //    //selectTxt += "  LEFT JOIN SALESDETAILRF SALDTL2" + Environment.NewLine;
        //    selectTxt += "  LEFT JOIN SALESHISTDTLRF SALDTL2" + Environment.NewLine;
        //    selectTxt += "  ON  SALDTL2.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND SALDTL2.ACPTANODRSTATUSRF=SALDTL.ACPTANODRSTATUSSRCRF" + Environment.NewLine;
        //    selectTxt += "  AND SALDTL2.SALESSLIPDTLNUMRF=SALDTL.SALESSLIPDTLNUMSRCRF" + Environment.NewLine;

        //    //�󒍃}�X�^(�ԗ�)
        //    selectTxt += "  LEFT JOIN ACCEPTODRCARRF AODCAR" + Environment.NewLine;
        //    selectTxt += "  ON  AODCAR.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND AODCAR.ACCEPTANORDERNORF=SALDTL.ACCEPTANORDERNORF" + Environment.NewLine;
        //    selectTxt += "  AND (" + Environment.NewLine;
        //    selectTxt += "         (SALDTL.ACPTANODRSTATUSRF = 10 AND AODCAR.ACPTANODRSTATUSRF = 1) " + Environment.NewLine; //�@����
        //    selectTxt += "      OR (SALDTL.ACPTANODRSTATUSRF = 20 AND AODCAR.ACPTANODRSTATUSRF = 3)" + Environment.NewLine; // ��
        //    selectTxt += "      OR (SALDTL.ACPTANODRSTATUSRF = 30 AND AODCAR.ACPTANODRSTATUSRF = 7)" + Environment.NewLine; // ����
        //    selectTxt += "      OR (SALDTL.ACPTANODRSTATUSRF = 40 AND AODCAR.ACPTANODRSTATUSRF = 5)" + Environment.NewLine; // �o�ׁ@
        //    selectTxt += "    )" + Environment.NewLine;

        //    //UOE�����f�[�^
        //    selectTxt += "  LEFT JOIN UOEORDERDTLRF UOEODR" + Environment.NewLine;
        //    selectTxt += "  ON  UOEODR.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND UOEODR.COMMONSEQNORF=SALDTL.COMMONSEQNORF" + Environment.NewLine;

        //    //���_���ݒ�}�X�^
        //    selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS" + Environment.NewLine;
        //    selectTxt += "  ON  SCINFS.ENTERPRISECODERF=SALSLP.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND SCINFS.SECTIONCODERF=SALSLP.SECTIONCODERF" + Environment.NewLine;
        //    //�d�����׃f�[�^
        //    //selectTxt += "  LEFT JOIN STOCKDETAILRF STCDTL" + Environment.NewLine;
        //    selectTxt += "  LEFT JOIN STOCKSLHISTDTLRF STCDTL" + Environment.NewLine;
        //    selectTxt += "  ON  STCDTL.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND STCDTL.SUPPLIERFORMALRF=SALDTL.SUPPLIERFORMALSYNCRF" + Environment.NewLine;
        //    selectTxt += "  AND STCDTL.STOCKSLIPDTLNUMRF=SALDTL.STOCKSLIPDTLNUMSYNCRF" + Environment.NewLine;

        //    //�d���f�[�^
        //    //selectTxt += "  LEFT JOIN STOCKSLIPRF STCSLP" + Environment.NewLine;
        //    selectTxt += "  LEFT JOIN STOCKSLIPHISTRF STCSLP" + Environment.NewLine;
        //    selectTxt += "  ON  STCSLP.ENTERPRISECODERF=STCDTL.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND STCSLP.SUPPLIERFORMALRF=STCDTL.SUPPLIERFORMALRF" + Environment.NewLine;
        //    selectTxt += "  AND STCSLP.SUPPLIERSLIPNORF=STCDTL.SUPPLIERSLIPNORF" + Environment.NewLine;

        //    //BL�O���[�v�}�X�^
        //    selectTxt += "  LEFT JOIN BLGROUPURF BLGRPU" + Environment.NewLine;
        //    selectTxt += "  ON  BLGRPU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND BLGRPU.BLGROUPCODERF=SALDTL.BLGROUPCODERF" + Environment.NewLine;

        //    //���[�U�[�K�C�h�}�X�^(�{�f�B)
        //    selectTxt += "  LEFT JOIN USERGDBDURF USRGBU" + Environment.NewLine;
        //    selectTxt += "  ON  USRGBU.ENTERPRISECODERF=SALDTL.ENTERPRISECODERF" + Environment.NewLine;
        //    selectTxt += "  AND USRGBU.USERGUIDEDIVCDRF=71" + Environment.NewLine;
        //    selectTxt += "  AND USRGBU.GUIDECODERF=SALDTL.SALESCODERF" + Environment.NewLine;
        //    #endregion

        //    //WHERE��
        //    selectTxt += MakeWhereString_SALTBL( ref sqlCommand, paramWork, logicalMode );

        //    #endregion  //[�f�[�^���o���C��Query]

        //    selectTxt += " ) AS SALTBL" + Environment.NewLine;

        //    //ORDER BY
        //    selectTxt += " ORDER BY ROWNUM DESC";
        //    #endregion

        //    return selectTxt;
        //}
        //#endregion
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
        // -- DEL 2009/09/04 ------------------------------<<<
        #endregion [DEL 2009/09/04]


        #region [�����f�[�^�p SELECT����������]
        /// <summary>
        /// �x���f�[�^�pSELECT���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�x���f�[�^�pSELECT��</returns>
        /// <br>Note       : �x���f�[�^�pSELECT�����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>Update Note: K2015/06/16 鸏�</br>
        /// <br>�Ǘ��ԍ�   : 11101427-00</br>
        /// <br>           : ���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
        private string MakeTypeDepSitQuery(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            string selectTxt = "";

            // �Ώۃe�[�u��
            // DEPSITMAINRF  DEPSM  �����}�X�^
            // DEPSITDTLRF   DEPSD  �������׃f�[�^

            #region [Select���쐬]
            // -- DEL 2009/10/05 -------------------------------------->>>
            // ���o���x�A�b�v�̂��ߍ폜
            //selectTxt += "SELECT" + Environment.NewLine;
            //selectTxt += "  ROW_NUMBER()" + Environment.NewLine;
            //selectTxt += "   OVER(ORDER BY SALTBL.DEPOSITSLIPNORF)" + Environment.NewLine;
            //selectTxt += "   AS ROWNUM" + Environment.NewLine;
            //selectTxt += " ,*" + Environment.NewLine;
            //selectTxt += " FROM (" + Environment.NewLine;
            // -- DEL 2009/10/05 --------------------------------------<<<

            #region [�f�[�^���o���C��Query]
            //������������𒴂���܂Ŏ擾
            selectTxt += "  SELECT TOP " + paramWork.SearchCnt + Environment.NewLine;
            selectTxt += "    DEPSM.DEPOSITDATERF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.DEPOSITSLIPNORF" + Environment.NewLine;
            selectTxt += "   ,DEPSD.DEPOSITROWNORF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.DEPOSITAGENTNMRF" + Environment.NewLine;
            selectTxt += "   ,(DEPSM.DEPOSITRF+DEPSM.DISCOUNTDEPOSITRF+DEPSM.FEEDEPOSITRF)" + Environment.NewLine;
            selectTxt += "    AS DEPOSPRICTOTAL" + Environment.NewLine;
            selectTxt += "   ,DEPSD.MONEYKINDNAMERF" + Environment.NewLine;
            selectTxt += "   ,DEPSD.DEPOSITRF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.OUTLINERF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.DEPOSITINPUTAGENTNMRF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.CUSTOMERSNMRF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.ADDUPSECCODERF" + Environment.NewLine;
            selectTxt += "   ,SCINFS.SECTIONGUIDENMRF" + Environment.NewLine; // ADD 2009.01.14  
            selectTxt += "   ,DEPSD.VALIDITYTERMRF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.ADDUPADATERF" + Environment.NewLine;
            selectTxt += "   ,DEPSM.DEPOSITDEBITNOTECDRF" + Environment.NewLine;
            // ADD 2009.02.13 >>>
            selectTxt += "    ,DEPSM.FEEDEPOSITRF" + Environment.NewLine;
            selectTxt += "    ,DEPSM.DISCOUNTDEPOSITRF" + Environment.NewLine;
            // ADD 2009.02.13 <<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
            selectTxt += "    ,DEPSM.INPUTDAYRF" + Environment.NewLine;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
            selectTxt += "    ,DEPSM.UPDATEDATETIMERF" + Environment.NewLine; // �X�V����
            selectTxt += "    ,DEPSD.UPDATEDATETIMERF AS UPDATEDATETIME" + Environment.NewLine; // �X�V�����i�������ׂ���擾����j // ADD 2012/04/01 gezh Redmine#29250 
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
            selectTxt += "    ,USRGBUF.GUIDENAMERF AS SALESAREANAMERF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE1RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE2RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE3RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE4RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE5RF" + Environment.NewLine;
            selectTxt += "    ,CUSTOMER.CUSTANALYSCODE6RF" + Environment.NewLine;
            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

            selectTxt += "  FROM (" + Environment.NewLine;

            #region [�����f�[�^���oQuery]
            selectTxt += "   SELECT" + Environment.NewLine;
            selectTxt += "     DEPSMSUB.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.DEPOSITDATERF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.DEPOSITSLIPNORF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.DEPOSITAGENTNMRF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.DEPOSITRF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.DISCOUNTDEPOSITRF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.FEEDEPOSITRF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.OUTLINERF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.DEPOSITINPUTAGENTNMRF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.CUSTOMERCODERF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.CUSTOMERSNMRF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.ADDUPSECCODERF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.ADDUPADATERF" + Environment.NewLine;
            selectTxt += "    ,DEPSMSUB.DEPOSITDEBITNOTECDRF" + Environment.NewLine;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
            selectTxt += "    ,DEPSMSUB.INPUTDAYRF" + Environment.NewLine;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
            selectTxt += "    ,DEPSMSUB.UPDATEDATETIMERF" + Environment.NewLine; // �X�V����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
            // -- UPD 2010/06/09 ----------------------------------->>>
            //selectTxt += "   FROM DEPSITMAINRF AS DEPSMSUB" + Environment.NewLine;
            selectTxt += "   FROM DEPSITMAINRF AS DEPSMSUB WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------<<<
            selectTxt += MakeWhereString_DEPSMSUB(ref sqlCommand, paramWork, logicalMode);
            #endregion  //[�����f�[�^���oQuery]

            selectTxt += "  ) AS DEPSM" + Environment.NewLine;

            //JOIN
            //�������׃f�[�^
            // -- UPD 2010/06/09 ----------------------------------->>>
            //selectTxt += "  LEFT JOIN DEPSITDTLRF DEPSD" + Environment.NewLine;
            selectTxt += "  LEFT JOIN DEPSITDTLRF DEPSD WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------<<<
            selectTxt += "  ON  DEPSD.ENTERPRISECODERF=DEPSM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND DEPSD.ACPTANODRSTATUSRF=DEPSM.ACPTANODRSTATUSRF" + Environment.NewLine;
            selectTxt += "  AND DEPSD.DEPOSITSLIPNORF=DEPSM.DEPOSITSLIPNORF" + Environment.NewLine;
            // ADD 2009.01.14 >>>
            //���_���ݒ�}�X�^
            // -- UPD 2010/06/09 ----------------------------------->>>
            //selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS" + Environment.NewLine;
            selectTxt += "  LEFT JOIN SECINFOSETRF SCINFS WITH (READUNCOMMITTED)" + Environment.NewLine;
            // -- UPD 2010/06/09 -----------------------------------<<<
            selectTxt += "  ON  SCINFS.ENTERPRISECODERF=DEPSM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += "  AND SCINFS.SECTIONCODERF=DEPSM.ADDUPSECCODERF" + Environment.NewLine;
             // ADD 2009.01.14 <<<
            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
            selectTxt += " LEFT JOIN CUSTOMERRF CUSTOMER WITH (READUNCOMMITTED)" + Environment.NewLine;
            selectTxt += " ON  CUSTOMER.ENTERPRISECODERF=DEPSM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND CUSTOMER.CUSTOMERCODERF=DEPSM.CUSTOMERCODERF" + Environment.NewLine;

            selectTxt += " LEFT JOIN USERGDBDURF USRGBUF WITH (READUNCOMMITTED)" + Environment.NewLine;
            selectTxt += " ON  USRGBUF.ENTERPRISECODERF=DEPSM.ENTERPRISECODERF" + Environment.NewLine;
            selectTxt += " AND USRGBUF.USERGUIDEDIVCDRF=21" + Environment.NewLine;
            selectTxt += " AND USRGBUF.LOGICALDELETECODERF=0" + Environment.NewLine;
            selectTxt += " AND USRGBUF.GUIDECODERF=CUSTOMER.SALESAREACODERF" + Environment.NewLine;

            selectTxt += MakeWhereString_DEPSM(ref sqlCommand, paramWork, logicalMode);
            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<
            #endregion  //[�f�[�^���o���C��Query]

            //  -- UPD 2009/10/05 --------------------------->>>
            //selectTxt += " ) AS SALTBL" + Environment.NewLine;

            ////ORDER BY
            //selectTxt += " ORDER BY ROWNUM DESC";
            //  -- UPD 2009/10/05 ---------------------------<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
            selectTxt += " ORDER BY DEPSM.DEPOSITDATERF, DEPSM.DEPOSITSLIPNORF";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
            #endregion

            return selectTxt;
        }
        #endregion  //[CustPrtPprSalTblRsltWork�p SELECT����������]

        #region [CustPrtPprSalTblRsltWork�p WHERE���������� (�d���f�[�^SELECT�p)]
        /// <summary>
        /// �`�[�\���E���ו\���̃��X�g���o�pWHERE�� �������� (�d���f�[�^SELECT�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="mode">0:���㒊�o(���㗚��ǂݍ���),1:�󒍑ݏo���o(����f�[�^�ǂݍ���)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br></br>
        private string MakeWhereString_SALSLPSUB(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode, int mode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " SALSLPSUB.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND SALSLPSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND SALSLPSUB.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //���_�R�[�h
            if (paramWork.SectionCode != null)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 DEL
                //string sectionCodestr = "";
                //foreach ( string seccdstr in paramWork.SectionCode )
                //{
                //    if ( sectionCodestr != "" )
                //    {
                //        sectionCodestr += ",";
                //    }
                //    sectionCodestr += "'" + seccdstr + "'";
                //}
                //if ( sectionCodestr != "" )
                //{
                //    // �C�� 2009.01.16 >>>
                //    //retstring += " AND SALSLPSUB.SECTIONCODERF IN (" + sectionCodestr + ") ";
                //    retstring += " AND SALSLPSUB.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                //    // �C�� 2009.01.16 <<<
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                if (paramWork.SectionCode.Length == 1)
                {
                    // -- UPD 2009/10/05 ---------------------------->>>
                    //�u@FINDRESULTSADDUPSECCD�v�̖��O�ɂ���Ƌ��_�L��w���CPU��100%�ɂȂ錻�ۂ������������߉���
                    //retstring += " AND SALSLPSUB.RESULTSADDUPSECCDRF=@FINDRESULTSADDUPSECCD ";
                    //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCD", SqlDbType.NChar);
                    retstring += " AND SALSLPSUB.RESULTSADDUPSECCDRF=@RESULTSADDUPSECCD " + Environment.NewLine;
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@RESULTSADDUPSECCD", SqlDbType.NChar);
                    // -- UPD 2009/10/05 ----------------------------<<<


                    paraSectionCode.Value = SqlDataMediator.SqlSetString(paramWork.SectionCode[0]);
                }
                else
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
                        retstring += " AND SALSLPSUB.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                retstring += Environment.NewLine;
            }
            // ADD 2009/10/05 ------------------------->>>
            else
            {
                retstring += " AND SALSLPSUB.RESULTSADDUPSECCDRF=SALSLPSUB.RESULTSADDUPSECCDRF " + Environment.NewLine;
            }
            // ADD 2009/10/05 -------------------------<<<

            //���Ӑ�R�[�h
            if ( paramWork.CustomerCode != 0 )
            {
                retstring += " AND SALSLPSUB.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32( paramWork.CustomerCode );
            }

            //������R�[�h
            if ( paramWork.ClaimCode != 0 )
            {
                retstring += " AND SALSLPSUB.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add( "@FINDCLAIMCODE", SqlDbType.Int );
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32( paramWork.ClaimCode );
            }


            //������t
            if (paramWork.St_SalesDate != DateTime.MinValue)
            {
                // 2008/12/24 DEL >>> 
                //retstring += " AND SALSLPSUB.SALESDATERF>=@STSALESDATE" + Environment.NewLine;
                // 2008/12/24 DEL <<<
                // -- UPD 2010/05/10 ------------------------------------>>>
                //// 2008/12/24 ADD >>>
                //retstring += " AND ((SALSLPSUB.SALESDATERF>=@STSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF<>40) OR (SALSLPSUB.SHIPMENTDAYRF>=@STSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF=40))" + Environment.NewLine;
                //// 2008/12/24 ADD <<<
                if (mode == 0)
                {
                    //���㗚���f�[�^�̒��o�̏ꍇ
                    retstring += " AND SALSLPSUB.SALESDATERF>=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_SalesDate).ToString() + Environment.NewLine;
                }
                else
                {
                    //����f�[�^�̒��o�̏ꍇ
                    retstring += " AND ((SALSLPSUB.SALESDATERF>=@STSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF<>40) OR (SALSLPSUB.SHIPMENTDAYRF>=@STSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF=40))" + Environment.NewLine;
                }

                // -- UPD 2010/05/10 ------------------------------------<<<
                SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@STSALESDATE", SqlDbType.Int);
                paraStSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_SalesDate);

            }
            if (paramWork.Ed_SalesDate != DateTime.MinValue)
            {
                // 2008.12.24 DEL >>>
                //retstring += " AND SALSLPSUB.SALESDATERF<=@EDSALESDATE" + Environment.NewLine;
                // 2008.12.24 DEL <<<

                // -- UPD 2010/05/10 ------------------------------------>>>
                //// 2008.12.24 ADD >>>
                //retstring += " AND ((SALSLPSUB.SALESDATERF<=@EDSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF<>40) OR (SALSLPSUB.SHIPMENTDAYRF<=@EDSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF=40))" + Environment.NewLine;
                //// 2008.12.24 ADD <<<
                if (mode == 0)
                {
                    //���㗚���f�[�^�̒��o�̏ꍇ
                    retstring += " AND SALSLPSUB.SALESDATERF<=" + SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_SalesDate).ToString() + Environment.NewLine;
                }
                else
                {
                    //����f�[�^�̒��o�̏ꍇ
                    retstring += " AND ((SALSLPSUB.SALESDATERF<=@EDSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF<>40) OR (SALSLPSUB.SHIPMENTDAYRF<=@EDSALESDATE AND SALSLPSUB.ACPTANODRSTATUSRF=40))" + Environment.NewLine;
                }
                // -- UPD 2010/05/10 ------------------------------------<<<
                SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDSALESDATE", SqlDbType.Int);
                paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_SalesDate);

            }

            //���͓��t(�`�[�������t)
            if (paramWork.St_AddUpADate != DateTime.MinValue)
            {
                retstring += " AND SALSLPSUB.SEARCHSLIPDATERF>=@STSEARCHSLIPDATE" + Environment.NewLine;
                SqlParameter paraStAddUpADate = sqlCommand.Parameters.Add("@STSEARCHSLIPDATE", SqlDbType.Int);
                paraStAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_AddUpADate);
            }
            if (paramWork.Ed_AddUpADate != DateTime.MinValue)
            {
                retstring += " AND SALSLPSUB.SEARCHSLIPDATERF<=@EDSEARCHSLIPDATE" + Environment.NewLine;
                SqlParameter paraEdAddUpADate = sqlCommand.Parameters.Add("@EDSEARCHSLIPDATE", SqlDbType.Int);
                paraEdAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_AddUpADate);
            }

            //�󒍃X�e�[�^�X
            if (paramWork.AcptAnOdrStatus != null)
            {
                string acptAnOdrStatusstr = "";
                foreach (Int32 iacptSt in paramWork.AcptAnOdrStatus)
                {
                    // -- ADD 2009/09/04 ---------------------------->>>
                    //�󒍑ݏo�p�̔���f�[�^�̒��o�̏ꍇ�A30:����͒��o�ΏۊO�Ƃ���
                    if ((mode == 1) && (iacptSt == 30)) continue;
                    // -- ADD 2009/09/04 ----------------------------<<<
                    // -- ADD 2009/10/05 ----------------------------->>>
                    if ((mode == 0) && ((iacptSt == 20) || (iacptSt == 40))) continue;
                    // -- ADD 2009/10/05 -----------------------------<<<

                    if (acptAnOdrStatusstr != "")
                    {
                        acptAnOdrStatusstr += ",";
                    }
                    acptAnOdrStatusstr += iacptSt.ToString();
                }
                if (acptAnOdrStatusstr != "")
                {
                    retstring += " AND SALSLPSUB.ACPTANODRSTATUSRF IN (" + acptAnOdrStatusstr + ") ";
                }

                retstring += Environment.NewLine;
            }

            //����`�[�敪
            if (paramWork.SalesSlipCd != null)
            {
                string salesSlipCdstr = "";
                foreach (Int32 isalCd in paramWork.SalesSlipCd)
                {
                    if (salesSlipCdstr != "")
                    {
                        salesSlipCdstr += ",";
                    }
                    salesSlipCdstr += isalCd.ToString();
                }
                if (salesSlipCdstr != "")
                {
                    retstring += " AND SALSLPSUB.SALESSLIPCDRF IN (" + salesSlipCdstr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //����`�[�ԍ�
            if (paramWork.SalesSlipNum != "")
            {
                retstring += " AND SALSLPSUB.SALESSLIPNUMRF>=@FINDSALESSLIPNUM" + Environment.NewLine;
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(paramWork.SalesSlipNum);
            }

            //�S����(�̔��]�ƈ��R�[�h)
            if (paramWork.SalesEmployeeCd != "")
            {
                retstring += " AND SALSLPSUB.SALESEMPLOYEECDRF=@FINDSALESEMPLOYEECD" + Environment.NewLine;
                SqlParameter paraSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDSALESEMPLOYEECD", SqlDbType.NChar);
                paraSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(paramWork.SalesEmployeeCd);
            }

            //�󒍎�(��t�]�ƈ��R�[�h)
            if (paramWork.FrontEmployeeCd != "")
            {
                retstring += " AND SALSLPSUB.FRONTEMPLOYEECDRF=@FINDFRONTEMPLOYEECD" + Environment.NewLine;
                SqlParameter paraFrontEmployeeCd = sqlCommand.Parameters.Add("@FINDFRONTEMPLOYEECD", SqlDbType.NChar);
                paraFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(paramWork.FrontEmployeeCd);
            }

            //���s��(������͎҃R�[�h)
            if (paramWork.SalesInputCode != "")
            {
                retstring += " AND SALSLPSUB.SALESINPUTCODERF=@FINDSALESINPUTCODE" + Environment.NewLine;
                SqlParameter paraSalesInputCode = sqlCommand.Parameters.Add("@FINDSALESINPUTCODE", SqlDbType.NChar);
                paraSalesInputCode.Value = SqlDataMediator.SqlSetString(paramWork.SalesInputCode);
            }

            //���Ӑ撍��(�����`�[�ԍ�)
            if (paramWork.PartySaleSlipNum != "")
            {
                // ----- DEL 2013/03/18 zhaimm Redmine#34807 --------------------------------------------------------------->>>>>
                //retstring += " AND SALSLPSUB.PARTYSALESLIPNUMRF=@FINDPARTYSALESLIPNUM" + Environment.NewLine;
                //SqlParameter paraPartySaleSlipNum = sqlCommand.Parameters.Add("@FINDPARTYSALESLIPNUM", SqlDbType.NVarChar);
                //paraPartySaleSlipNum.Value = SqlDataMediator.SqlSetString(paramWork.PartySaleSlipNum);
                // ----- DEL 2013/03/18 zhaimm Redmine#34807 ---------------------------------------------------------------<<<<<
                retstring += " AND SALSLPSUB.PARTYSALESLIPNUMRF IN (" + paramWork.PartySaleSlipNum + ")" + Environment.NewLine; // ADD 2013/03/18 zhaimm Redmine#34807
            }

            //���l�P(�`�[���l) �������܂���������
            if (paramWork.SlipNote != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SlipNote, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND SALSLPSUB.SLIPNOTERF LIKE @FINDSLIPNOTE" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND SALSLPSUB.SLIPNOTERF=@FINDSLIPNOTE" + Environment.NewLine;
                }
                SqlParameter paraSlipNote = sqlCommand.Parameters.Add("@FINDSLIPNOTE", SqlDbType.NVarChar);
                paraSlipNote.Value = SqlDataMediator.SqlSetString(paramWork.SlipNote);
            }

            //���l�Q(�`�[���l�Q) �������܂���������
            if (paramWork.SlipNote2 != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SlipNote2, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND SALSLPSUB.SLIPNOTE2RF LIKE @FINDSLIPNOTE2" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND SALSLPSUB.SLIPNOTE2RF=@FINDSLIPNOTE2" + Environment.NewLine;
                }
                SqlParameter paraSlipNote2 = sqlCommand.Parameters.Add("@FINDSLIPNOTE2", SqlDbType.NVarChar);
                paraSlipNote2.Value = SqlDataMediator.SqlSetString(paramWork.SlipNote2);
            }

            //���l�R(�`�[���l�R) �������܂���������
            if (paramWork.SlipNote3 != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SlipNote3, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND SALSLPSUB.SLIPNOTE3RF LIKE @FINDSLIPNOTE3" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND SALSLPSUB.SLIPNOTE3RF=@FINDSLIPNOTE3" + Environment.NewLine;
                }
                SqlParameter paraSlipNote3 = sqlCommand.Parameters.Add("@FINDSLIPNOTE3", SqlDbType.NVarChar);
                paraSlipNote3.Value = SqlDataMediator.SqlSetString(paramWork.SlipNote3);
            }

            //�t�n�d���}�[�N�P �������܂���������
            if (paramWork.UoeRemark1 != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.UoeRemark1, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND SALSLPSUB.UOEREMARK1RF LIKE @FINDUOEREMARK1" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND SALSLPSUB.UOEREMARK1RF=@FINDUOEREMARK1" + Environment.NewLine;
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
                    retstring += " AND SALSLPSUB.UOEREMARK2RF LIKE @FINDUOEREMARK2" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND SALSLPSUB.UOEREMARK2RF=@FINDUOEREMARK2" + Environment.NewLine;
                }
                SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@FINDUOEREMARK2", SqlDbType.NVarChar);
                paraUoeRemark2.Value = SqlDataMediator.SqlSetString(paramWork.UoeRemark2);
            }
            #endregion

            return retstring;
        }
        #endregion  //[CustPrtPprSalTblRsltWork�p WHERE���������� (�d���f�[�^SELECT�p)]

        #region [CustPrtPprSalTblRsltWork�p WHERE���������� (�d�����׃f�[�^SELECT�p)]
        /// <summary>
        /// �`�[�\���E���ו\���̃��X�g���o�pWHERE�� �������� (�d�����׃f�[�^SELECT�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>UpdateNote : ���� 2009/10/22 /br>
        /// <br>           : Mentis�F0014427 �d�l�ύX:���o�����̊Ǘ��ԍ��𕶎�����͉\�ɕύX�A�܂��A�Ǘ��ԍ����������̒ǉ�����</br>
        /// <br>Update Note :2010/08/05 ������ ��Q�E���ǑΉ�8�������[�X��</br>
        /// <br>             �ԑ�ԍ����������ύX</br>
        /// <br>Update Note :2011/07/18 zhubj �񓚋敪�ǉ��Ή�</br>
        /// <br>Update Note :2011/11/28 �k�m redmine#8172�̒ǉ��Ή�</br>
        /// <br>Update Note :K2015/06/16 鸏�</br>
        /// <br>�Ǘ��ԍ�    :11101427-00</br>
        /// <br>            :���C�S�����Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
        /// <br>UpdateNote : 2016/01/21 �e�c ���V</br>
        /// <br>�Ǘ��ԍ�   : 11270007-00 �d�|�ꗗ��2808 �ݏo�󒍑Ή�</br>
        /// <br>           : �@���������Ɂu�o�׏󋵁v���ڂ�ǉ�</br>
        /// <br>           : �A���ו\���Ɍv�㐔�A���v�㐔���ڂ�ǉ�</br>
        /// <br>Update Note :K2016/02/23 ���V��</br>
        /// <br>             ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή�</br>
        /// <br></br>
        private string MakeWhereString_SALTBL(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " SALSLP.ENTERPRISECODERF=@ENTERPRISECODE2" + Environment.NewLine;
            SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@ENTERPRISECODE2", SqlDbType.NChar);
            paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�Ǘ��ԍ�(���q�Ǘ��R�[�h)
            if (paramWork.CarMngCode != "")
            {
                // --- ADD 2009/10/22 Mentis�F0014427----->>>>>
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.CarMngCode, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND AODCAR.CARMNGCODERF LIKE @FINDCARMNGCODE" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND AODCAR.CARMNGCODERF=@FINDCARMNGCODE" + Environment.NewLine;
                }
                //retstring += " AND AODCAR.CARMNGCODERF=@FINDCARMNGCODE" + Environment.NewLine;
                // --- ADD 2009/10/22 Mentis�F0014427-----<<<<<
                SqlParameter paraCarMngCode = sqlCommand.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NVarChar);
                paraCarMngCode.Value = SqlDataMediator.SqlSetString(paramWork.CarMngCode);
            }

            //�Ԏ햼��(�Ԏ�S�p����) �������܂���������
            if (paramWork.ModelFullName != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.ModelFullName, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND AODCAR.MODELFULLNAMERF LIKE @FINDMODELFULLNAME" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND AODCAR.MODELFULLNAMERF=@FINDMODELFULLNAME" + Environment.NewLine;
                }
                SqlParameter paraModelFullName = sqlCommand.Parameters.Add("@FINDMODELFULLNAME", SqlDbType.NVarChar);
                paraModelFullName.Value = SqlDataMediator.SqlSetString(paramWork.ModelFullName);
            }

            //�^��(�^��(�t���^)) �������܂���������
            if (paramWork.FullModel != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.FullModel, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND AODCAR.FULLMODELRF LIKE @FINDFULLMODEL" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND AODCAR.FULLMODELRF=@FINDFULLMODEL" + Environment.NewLine;
                }
                SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FINDFULLMODEL", SqlDbType.NVarChar);
                paraFullModel.Value = SqlDataMediator.SqlSetString(paramWork.FullModel);
            }

            // -----------UPD 2010/08/05------------>>>>>
            ////�ԑ䇂(�ԑ�ԍ�(�����p))
            //if (paramWork.SearchFrameNo != 0)
            //{
            //    retstring += " AND AODCAR.SEARCHFRAMENORF>=@FINDSEARCHFRAMENO" + Environment.NewLine;
            //    SqlParameter paraSearchFrameNo = sqlCommand.Parameters.Add("@FINDSEARCHFRAMENO", SqlDbType.Int);
            //    paraSearchFrameNo.Value = SqlDataMediator.SqlSetInt32(paramWork.SearchFrameNo);
            //}
            //�ԑ䇂
            if (paramWork.FrameNo != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.FrameNo, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND AODCAR.FRAMENORF LIKE @FINDFRAMENO" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND AODCAR.FRAMENORF=@FINDFRAMENO" + Environment.NewLine;
                }
                SqlParameter paraFrameNo = sqlCommand.Parameters.Add("@FINDFRAMENO", SqlDbType.NVarChar);
                paraFrameNo.Value = SqlDataMediator.SqlSetString(paramWork.FrameNo);
            }
            // -----------UPD 2010/08/05------------<<<<<
            // ---------------------- ADD START 2011/07/18 zhubj ----------------->>>>>
            //������
            if (paramWork.AutoAnswerDivSCM != 0)
            {
                retstring += " AND SALSLP.AUTOANSWERDIVSCMRF =@FINDAUTOANSWERDIVSCM" + Environment.NewLine;
                SqlParameter paraAutoAnswerDivSCM = sqlCommand.Parameters.Add("@FINDAUTOANSWERDIVSCM", SqlDbType.Int);
                paraAutoAnswerDivSCM.Value = SqlDataMediator.SqlSetInt32(paramWork.AutoAnswerDivSCM - 1);
            }
            // ---------------------- ADD END   2011/07/18 zhubj -----------------<<<<<
            
            //---ADD START 2011/11/28 �k�m ----------------------------------->>>>>
            //�⍇���ԍ�
            if (paramWork.InquiryNumber != 0)
            {
                retstring += " AND SALSLP.INQUIRYNUMBERRF =@FINDSTINQUIRYNUMBER" + Environment.NewLine;
                SqlParameter paraStInquiryNumber = sqlCommand.Parameters.Add("@FINDSTINQUIRYNUMBER", SqlDbType.BigInt);
                paraStInquiryNumber.Value = SqlDataMediator.SqlSetInt64(paramWork.InquiryNumber);
            }
            //---ADD END 2011/11/28 �k�m -----------------------------------<<<<<

            //�J���[����(�J���[����1) �������܂���������
            if (paramWork.ColorName1 != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.ColorName1, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND AODCAR.COLORNAME1RF LIKE @FINDCOLORNAME1" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND AODCAR.COLORNAME1RF=@FINDCOLORNAME1" + Environment.NewLine;
                }
                SqlParameter paraColorName1 = sqlCommand.Parameters.Add("@FINDCOLORNAME1", SqlDbType.NVarChar);
                paraColorName1.Value = SqlDataMediator.SqlSetString(paramWork.ColorName1);
            }

            //�g�������� �������܂���������
            if (paramWork.TrimName != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.TrimName, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND AODCAR.TRIMNAMERF LIKE @FINDTRIMNAME" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND AODCAR.TRIMNAMERF=@FINDTRIMNAME" + Environment.NewLine;
                }
                SqlParameter paraTrimName = sqlCommand.Parameters.Add("@FINDTRIMNAME", SqlDbType.NVarChar);
                paraTrimName.Value = SqlDataMediator.SqlSetString(paramWork.TrimName);
            }

            //UOE���M(�f�[�^���M�敪)
            if (paramWork.DataSendCode != 0)
            {
                if (paramWork.DataSendCode == 9)
                {
                    //UOE���M -> UOE���M�̂�
                    retstring += " AND UOEODR.UOEKINDRF = 0" + Environment.NewLine;
                    retstring += " AND UOEODR.DATASENDCODERF=9" + Environment.NewLine;
                }
                else
                {
                    //�ʏ� -> UOE���M�ȊO
                    //retstring += " AND UOEODR.DATASENDCODERF<>9" + Environment.NewLine;
                    retstring += " AND ((UOEODR.DATASENDCODERF IS NULL) OR UOEODR.DATASENDCODERF<>9)" + Environment.NewLine;

                }
            }

            //�a�k�O���[�v(BL�O���[�v�R�[�h)
            if (paramWork.BLGroupCode != 0)
            {
                // -- UPD 2009/09/04 ------------------------------------------->>>
                //retstring += " AND SALDTL.BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                retstring += " AND SALSLP.BLGROUPCODERF=@FINDBLGROUPCODE" + Environment.NewLine;
                // -- UPD 2009/09/04 -------------------------------------------<<<
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGroupCode);
            }

            //�a�k�R�[�h(BL���i�R�[�h)
            if (paramWork.BLGoodsCode != 0)
            {
                // -- UPD 2009/09/04 ------------------------------------------->>>
                //retstring += " AND SALDTL.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                retstring += " AND SALSLP.BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                // -- UPD 2009/09/04 -------------------------------------------<<<
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
                    // -- UPD 2009/09/04 ---------------------------------------->>>
                    //retstring += " AND SALDTL.GOODSNAMERF LIKE @FINDGOODSNAME" + Environment.NewLine;
                    retstring += " AND SALSLP.GOODSNAMERF LIKE @FINDGOODSNAME" + Environment.NewLine;
                    // -- UPD 2009/09/04 ----------------------------------------<<<

                }
                else
                {
                    //�����܂���������Ȃ�
                    // -- UPD 2009/09/04 ---------------------------------------->>>
                    //retstring += " AND SALDTL.GOODSNAMERF=@FINDGOODSNAME" + Environment.NewLine;
                    retstring += " AND SALSLP.GOODSNAMERF=@FINDGOODSNAME" + Environment.NewLine;
                    // -- UPD 2009/09/04 ----------------------------------------<<<
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
                    // -- UPD 2009/09/04 ---------------------------------------->>>
                    //retstring += " AND SALDTL.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                    //retstring += " AND SALSLP.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;// DEL 2009/12/28
                    // -- UPD 2009/09/04 ----------------------------------------<<<
                    // -------------ADD 2009/12/28-------------->>>>>
                    if (paramWork.GoodsNo.Contains("-"))
                    {
                        retstring += " AND SALSLP.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND SALSLP.GOODSNORF_NOHALF LIKE @FINDGOODSNO" + Environment.NewLine;
                    }
                    // -------------ADD 2009/12/28--------------<<<<<
                 }
                else
                {
                    //�����܂���������Ȃ�
                    // -- UPD 2009/09/04 ---------------------------------------->>>
                    //retstring += " AND SALDTL.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;
                    //retstring += " AND SALSLP.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;// DEL 2009/12/28
                    // -- UPD 2009/09/04 ----------------------------------------<<<
                    // -------------ADD 2009/12/28-------------->>>>>
                    if (paramWork.GoodsNo.Contains("-"))
                    {
                        retstring += " AND SALSLP.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    }
                    else
                    {
                        retstring += " AND SALSLP.GOODSNORF_NOHALF = @FINDGOODSNO" + Environment.NewLine;
                    }
                    // -------------ADD 2009/12/28--------------<<<<<

                }
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNo);
            }

            //���[�J�[(���i���[�J�[�R�[�h)
            if (paramWork.GoodsMakerCd != 0)
            {
                // -- UPD 2009/09/04 -------------------------------------------->>>
                //retstring += " AND SALDTL.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                retstring += " AND SALSLP.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                // -- UPD 2009/09/04 --------------------------------------------<<<
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCd);
            }

            //�̔��敪�R�[�h
            if (paramWork.SalesCode != 0)
            {
                // -- UPD 2009/09/04 -------------------------------------------->>>
                //retstring += " AND SALDTL.SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                retstring += " AND SALSLP.SALESCODERF=@FINDSALESCODE" + Environment.NewLine;
                // -- UPD 2009/09/04 --------------------------------------------<<<
                SqlParameter paraSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                paraSalesCode.Value = SqlDataMediator.SqlSetInt32(paramWork.SalesCode);
            }

            //���Е��ރR�[�h
            if (paramWork.EnterpriseGanreCode != 0)
            {
                // -- UPD 2009/09/04 -------------------------------------------->>>
                //retstring += " AND SALDTL.ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE" + Environment.NewLine;
                retstring += " AND SALSLP.ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE" + Environment.NewLine;
                // -- UPD 2009/09/04 --------------------------------------------<<<
                SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@FINDENTERPRISEGANRECODE", SqlDbType.Int);
                paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(paramWork.EnterpriseGanreCode);
            }

            //�݌Ɏ��敪(����݌Ɏ�񂹋敪)
            if (paramWork.SalesOrderDivCd != -1)
            {
                // -- UPD 2009/09/04 -------------------------------------------->>>
                //retstring += " AND SALDTL.SALESORDERDIVCDRF=@FINDSALESORDERDIVCD" + Environment.NewLine;
                retstring += " AND SALSLP.SALESORDERDIVCDRF=@FINDSALESORDERDIVCD" + Environment.NewLine;
                // -- UPD 2009/09/04 --------------------------------------------<<<
                SqlParameter paraSalesOrderDivCd = sqlCommand.Parameters.Add("@FINDSALESORDERDIVCD", SqlDbType.Int);
                paraSalesOrderDivCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SalesOrderDivCd);
            }

            //�q�ɃR�[�h
            if (paramWork.WarehouseCode != "")
            {
                // -- UPD 2009/09/04 -------------------------------------------->>>
                //retstring += " AND SALDTL.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                retstring += " AND SALSLP.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                // -- UPD 2009/09/04 --------------------------------------------<<<
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
            }

            //�d���`�[�ԍ�
            if (paramWork.SupplierSlipNo != "")
            {
                retstring += " AND STCSLP.PARTYSALESLIPNUMRF=@FINDSUPPLIERSLIPNO" + Environment.NewLine;
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.NVarChar);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetString(paramWork.SupplierSlipNo);
            }

            //�d����(�d����R�[�h)
            if (paramWork.SupplierCd != 0)
            {
                // -- UPD 2009/09/04 --------------------------------------------->>>
                //retstring += " AND SALDTL.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                retstring += " AND SALSLP.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                // -- UPD 2009/09/04 ---------------------------------------------<<<
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.SupplierCd);
            }

            //������
            if (paramWork.UOESupplierCd != 0)
            {
                retstring += " AND UOEODR.SUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                SqlParameter paraUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                paraUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(paramWork.UOESupplierCd);
            }


            //���ה��l �������܂���������
            if (paramWork.DtlNote != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.DtlNote, "(%)").Success == true)
                {
                    //�����܂�����
                    // -- UPD 2009/09/04 ----------------------------------------->>>
                    //retstring += " AND SALDTL.DTLNOTERF LIKE @FINDDTLNOTE" + Environment.NewLine;
                    retstring += " AND SALSLP.DTLNOTERF LIKE @FINDDTLNOTE" + Environment.NewLine;
                    // -- UPD 2009/09/04 -----------------------------------------<<<
                }
                else
                {
                    //�����܂���������Ȃ�
                    // -- UPD 2009/09/04 ----------------------------------------->>>
                    //retstring += " AND SALDTL.DTLNOTERF=@FINDDTLNOTE" + Environment.NewLine;
                    retstring += " AND SALSLP.DTLNOTERF=@FINDDTLNOTE" + Environment.NewLine;
                    // -- UPD 2009/09/04 -----------------------------------------<<<
                }
                SqlParameter paraDtlNote = sqlCommand.Parameters.Add("@FINDDTLNOTE", SqlDbType.NVarChar);
                paraDtlNote.Value = SqlDataMediator.SqlSetString(paramWork.DtlNote);
            }

            //�[�i��R�[�h
            if (paramWork.AddresseeCode != 0)
            {
                retstring += " AND SALSLP.ADDRESSEECODERF=@FINDADDRESSEECODE" + Environment.NewLine;
                SqlParameter paraAddresseeCode = sqlCommand.Parameters.Add("@FINDADDRESSEECODE", SqlDbType.Int);
                paraAddresseeCode.Value = SqlDataMediator.SqlSetInt32(paramWork.AddresseeCode);
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 ADD
            // ���i����
            if ( paramWork.GoodsKindCode != -1 )
            {
                // -- UPD 2009/09/04 --------------------------------------------->>>
                //retstring += " AND SALDTL.GOODSKINDCODERF=@FINDGOODSKINDCODE" + Environment.NewLine;
                retstring += " AND SALSLP.GOODSKINDCODERF=@FINDGOODSKINDCODE" + Environment.NewLine;
                // -- UPD 2009/09/04 ---------------------------------------------<<<
                SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@FINDGOODSKINDCODE", SqlDbType.Int);
                paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32( paramWork.GoodsKindCode );
            }

            // ���i�啪�ރR�[�h
            if ( paramWork.GoodsLGroup != 0 )
            {
                // -- UPD 2009/09/04 --------------------------------------------->>>
                //retstring += " AND SALDTL.GOODSLGROUPRF=@FINDGOODSLGROUP" + Environment.NewLine;
                retstring += " AND SALSLP.GOODSLGROUPRF=@FINDGOODSLGROUP" + Environment.NewLine;
                // -- UPD 2009/09/04 ---------------------------------------------<<<
                SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@FINDGOODSLGROUP", SqlDbType.Int);
                paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32( paramWork.GoodsLGroup );
            }

            // ���i�����ރR�[�h
            if ( paramWork.GoodsMGroup != 0 )
            {
                // -- UPD 2009/09/04 --------------------------------------------->>>
                //retstring += " AND SALDTL.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                retstring += " AND SALSLP.GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                // -- UPD 2009/09/04 ---------------------------------------------<<<
                SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32( paramWork.GoodsMGroup );
            }
            
            // �I��
            if ( paramWork.WarehouseShelfNo != string.Empty )
            {
                //�����܂��������ǂ������`�F�b�N
                if ( System.Text.RegularExpressions.Regex.Match( paramWork.WarehouseShelfNo, "(%)" ).Success == true )
                {
                    //�����܂�����
                    // -- UPD 2009/09/04 ----------------------------------------->>>
                    //retstring += " AND SALDTL.WAREHOUSESHELFNORF LIKE @FINDWAREHOUSESHELFNO" + Environment.NewLine;
                    retstring += " AND SALSLP.WAREHOUSESHELFNORF LIKE @FINDWAREHOUSESHELFNO" + Environment.NewLine;
                    // -- UPD 2009/09/04 -----------------------------------------<<<
                }
                else
                {
                    //�����܂���������Ȃ�
                    // -- UPD 2009/09/04 ----------------------------------------->>>
                    //retstring += " AND SALDTL.WAREHOUSESHELFNORF=@FINDWAREHOUSESHELFNO" + Environment.NewLine;
                    retstring += " AND SALSLP.WAREHOUSESHELFNORF=@FINDWAREHOUSESHELFNO" + Environment.NewLine;
                    // -- UPD 2009/09/04 -----------------------------------------<<<
                }
                SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add( "@FINDWAREHOUSESHELFNO", SqlDbType.NVarChar );
                paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString( paramWork.WarehouseShelfNo );
            }
            
            // ����`�[�敪(����)
            switch(paramWork.SalesSlipCdDtl)
            {
                // 1:�l������
                case 1:
                    {
                        // -- UPD 2009/09/04 -------------------------------------->>>
                        //retstring += " AND SALDTL.SALESSLIPCDDTLRF<>@FINDSALESSLIPCDDTL" + Environment.NewLine;
                        retstring += " AND SALSLP.SALESSLIPCDDTLRF<>@FINDSALESSLIPCDDTL" + Environment.NewLine;
                        // -- UPD 2009/09/04 --------------------------------------<<<
                        SqlParameter paraSalesSlipCdDtl = sqlCommand.Parameters.Add("@FINDSALESSLIPCDDTL", SqlDbType.Int);
                        paraSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32( 2 );
                    }
                    break;
                // 2:�l���̂�
                case 2:
                    {
                        // -- UPD 2009/09/04 -------------------------------------->>>
                        //retstring += " AND SALDTL.SALESSLIPCDDTLRF=@FINDSALESSLIPCDDTL" + Environment.NewLine;
                        retstring += " AND SALSLP.SALESSLIPCDDTLRF=@FINDSALESSLIPCDDTL" + Environment.NewLine;
                        // -- UPD 2009/09/04 --------------------------------------<<<
                        SqlParameter paraSalesSlipCdDtl = sqlCommand.Parameters.Add("@FINDSALESSLIPCDDTL", SqlDbType.Int);
                        paraSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32( 2 );
                    }
                    break;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 ADD

            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
            //�n��R�[�h
            if (paramWork.SalesAreaCode != 0)
            {
                retstring += " AND CUSTOMER.SALESAREACODERF=@SALESAREACODE" + Environment.NewLine;
                SqlParameter salesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                salesAreaCode.Value = SqlDataMediator.SqlSetInt32(paramWork.SalesAreaCode);
            }
            //���̓R�[�h1
            if (paramWork.CustAnalysCode1 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE1RF=@CUSTANALYSCODE1RF" + Environment.NewLine;
                SqlParameter custAnalysCode1RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE1RF", SqlDbType.Int);
                custAnalysCode1RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode1);
            }
            //���̓R�[�h2
            if (paramWork.CustAnalysCode2 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE2RF=@CUSTANALYSCODE2RF" + Environment.NewLine;
                SqlParameter custAnalysCode2RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE2RF", SqlDbType.Int);
                custAnalysCode2RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode2);
            }
            //���̓R�[�h3
            if (paramWork.CustAnalysCode3 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE3RF=@CUSTANALYSCODE3RF" + Environment.NewLine;
                SqlParameter custAnalysCode3RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE3RF", SqlDbType.Int);
                custAnalysCode3RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode3);
            }
            //���̓R�[�h4
            if (paramWork.CustAnalysCode4 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE4RF=@CUSTANALYSCODE4RF" + Environment.NewLine;
                SqlParameter custAnalysCode4RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE4RF", SqlDbType.Int);
                custAnalysCode4RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode4);
            }
            //���̓R�[�h5
            if (paramWork.CustAnalysCode5 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE5RF=@CUSTANALYSCODE5RF" + Environment.NewLine;
                SqlParameter custAnalysCode5RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE5RF", SqlDbType.Int);
                custAnalysCode5RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode5);
            }
            //���̓R�[�h6
            if (paramWork.CustAnalysCode6 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE6RF=@CUSTANALYSCODE6RF" + Environment.NewLine;
                SqlParameter custAnalysCode6RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE6RF", SqlDbType.Int);
                custAnalysCode6RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode6);
            }
            //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

           //----- ADD K2016/02/23 ���V�� ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή� ----->>>>>
            // �󒍍쐬�敪:�ʏ�󒍓`�[
            if (paramWork.AcptAnOdrMakeDiv == 2)
            {
                retstring += " AND SALSLP.ACPTANODRSTATUSRF = 20" + Environment.NewLine;
                retstring += " AND UOEODR.DATASENDCODERF IS NULL" + Environment.NewLine;
            }
            // �󒍍쐬�敪:�`��UOE�󒍓`�[
            else if (paramWork.AcptAnOdrMakeDiv == 3)
            {
                retstring += " AND SALSLP.ACPTANODRSTATUSRF = 20" + Environment.NewLine;
                retstring += " AND UOEODR.DATASENDCODERF IS NOT NULL" + Environment.NewLine;
            }
            //----- ADD K2016/02/23 ���V�� ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή� -----<<<<<

            // ---------- ADD 2016/01/21 Y.Wakita ---------->>>>>
            //�o�׏�(�v��c�敪)
            if (paramWork.AddUpRemDiv != 0)
            {
                if (paramWork.AddUpRemDiv == 1)
                {   //�c����
                    retstring += " AND SALSLP.ACPTANODRREMAINCNTRF>0" + Environment.NewLine;
                }
                else if (paramWork.AddUpRemDiv == 2)
                {   //�v��ς�
                    retstring += " AND SALSLP.ACPTANODRREMAINCNTRF<=0" + Environment.NewLine;
                }
            }
            // ---------- ADD 2016/01/21 Y.Wakita ----------<<<<<

            #endregion

            return retstring;
        }
        #endregion  //[CustPrtPprSalTblRsltWork�p WHERE���������� (�d���f�[�^SELECT�p)]

        #region [CustPrtPprSalTblRsltWork�p WHERE���������� (�x���f�[�^SELECT�p)]
        /// <summary>
        /// �`�[�\���E���ו\���̃��X�g���o�pWHERE�� �������� (�x���f�[�^SELECT�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br></br>
        private string MakeWhereString_DEPSMSUB(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " DEPSMSUB.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND DEPSMSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND DEPSMSUB.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
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
                    retstring += " AND DEPSMSUB.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //���Ӑ�R�[�h
            if (paramWork.CustomerCode != 0)
            {
                retstring += " AND DEPSMSUB.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(paramWork.CustomerCode);
            }
            // ADD 2009.02.09 >>>
            //������R�[�h
            if (paramWork.ClaimCode != 0)
            {
                retstring += " AND DEPSMSUB.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(paramWork.ClaimCode);
            }
            // ADD 2009.02.09 <<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
            ////�`�[���t(�������t)
            //if (paramWork.St_SalesDate != DateTime.MinValue)
            //{
            //    retstring += " AND DEPSMSUB.DEPOSITDATERF>=@STDEPOSITDATE" + Environment.NewLine;
            //    SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@STDEPOSITDATE", SqlDbType.Int);
            //    paraStSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.St_SalesDate);
            //}
            //if (paramWork.Ed_SalesDate != DateTime.MinValue)
            //{
            //    retstring += " AND DEPSMSUB.DEPOSITDATERF<=@EDDEPOSITDATE" + Environment.NewLine;
            //    SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDDEPOSITDATE", SqlDbType.Int);
            //    paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paramWork.Ed_SalesDate);
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
            // �`�[���t(�������t)��SalesDate:ADDUPADATERF
            if ( paramWork.St_SalesDate != DateTime.MinValue )
            {
                retstring += " AND DEPSMSUB.ADDUPADATERF>=@STADDUPADATE" + Environment.NewLine;
                SqlParameter paraStAddUpADate = sqlCommand.Parameters.Add( "@STADDUPADATE", SqlDbType.Int );
                paraStAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( paramWork.St_SalesDate );
            }
            if ( paramWork.Ed_SalesDate != DateTime.MinValue )
            {
                retstring += " AND DEPSMSUB.ADDUPADATERF<=@EDADDUPADATE" + Environment.NewLine;
                SqlParameter paraEdAddUpADate = sqlCommand.Parameters.Add( "@EDADDUPADATE", SqlDbType.Int );
                paraEdAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( paramWork.Ed_SalesDate );
            }
            // ���͓��t��AddUpADate:DEPOSITDATERF // m.suzuki 2009/04/09 DEPOSITDATERF��INPUTDAYRF(�ǉ�����)�֕ύX
            if ( paramWork.St_AddUpADate != DateTime.MinValue )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 DEL
                //retstring += " AND DEPSMSUB.DEPOSITDATERF>=@STDEPOSITDATE" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                retstring += " AND DEPSMSUB.INPUTDAYRF>=@STDEPOSITDATE" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
                SqlParameter paraStDepositDate = sqlCommand.Parameters.Add( "@STDEPOSITDATE", SqlDbType.Int );
                paraStDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( paramWork.St_AddUpADate );
            }
            if ( paramWork.Ed_AddUpADate != DateTime.MinValue )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 DEL
                //retstring += " AND DEPSMSUB.DEPOSITDATERF<=@EDDEPOSITDATE" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                retstring += " AND DEPSMSUB.INPUTDAYRF<=@EDDEPOSITDATE" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
                SqlParameter paraEdDepositDate = sqlCommand.Parameters.Add( "@EDDEPOSITDATE", SqlDbType.Int );
                paraEdDepositDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( paramWork.Ed_AddUpADate );
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
            ////�󒍃X�e�[�^�X
            //if (paramWork.AcptAnOdrStatus != null)
            //{
            //    string acptAnOdrStatusstr = "";
            //    foreach (Int32 iacptSt in paramWork.AcptAnOdrStatus)
            //    {
            //        if (acptAnOdrStatusstr != "")
            //        {
            //            acptAnOdrStatusstr += ",";
            //        }
            //        acptAnOdrStatusstr += iacptSt.ToString();
            //    }
            //    if (acptAnOdrStatusstr != "")
            //    {
            //        retstring += " AND DEPSMSUB.ACPTANODRSTATUSRF IN (" + acptAnOdrStatusstr + ") ";
            //    }
            //    retstring += Environment.NewLine;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL

            //�S����(�����S���҃R�[�h)
            if (paramWork.SalesEmployeeCd != "")
            {
                retstring += " AND DEPSMSUB.DEPOSITAGENTCODERF=@FINDDEPOSITAGENTCODE" + Environment.NewLine;
                SqlParameter paraSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDDEPOSITAGENTCODE", SqlDbType.NChar);
                paraSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(paramWork.SalesEmployeeCd);
            }

            //���l�P(�`�[�E�v) �������܂���������
            if (paramWork.SlipNote != "")
            {
                //�����܂��������ǂ������`�F�b�N
                if (System.Text.RegularExpressions.Regex.Match(paramWork.SlipNote, "(%)").Success == true)
                {
                    //�����܂�����
                    retstring += " AND DEPSMSUB.OUTLINERF LIKE @FINDOUTLINE" + Environment.NewLine;
                }
                else
                {
                    //�����܂���������Ȃ�
                    retstring += " AND DEPSMSUB.OUTLINERF=@FINDOUTLINE" + Environment.NewLine;
                }
                SqlParameter paraSlipNote = sqlCommand.Parameters.Add("@FINDOUTLINE", SqlDbType.NVarChar);
                paraSlipNote.Value = SqlDataMediator.SqlSetString(paramWork.SlipNote);
            }

            //���s��(�������͎҃R�[�h)
            if (paramWork.SalesInputCode != "")
            {
                retstring += " AND DEPSMSUB.DEPOSITINPUTAGENTCDRF=@FINDDEPOSITINPUTAGENTCD" + Environment.NewLine;
                SqlParameter paraSalesInputCode = sqlCommand.Parameters.Add("@FINDDEPOSITINPUTAGENTCD", SqlDbType.NChar);
                paraSalesInputCode.Value = SqlDataMediator.SqlSetString(paramWork.SalesInputCode);
            }
            #endregion

            return retstring;
        }
        #endregion  //[CustPrtPprSalTblRsltWork�p WHERE���������� (�x���f�[�^SELECT�p)]
       
        
       //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
       #region [CustPrtPprSalTblRsltWork�p WHERE���������� (�����f�[�^SELECT�p)]
        /// <summary>
        /// �`�[�\���E���ו\���̃��X�g���o�pWHERE�� �������� (�����f�[�^SELECT�p)
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>Where����������</returns>        
        /// <br>Note		: ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����</br>
        /// <br>�Ǘ��ԍ�    : 11101427-00</br>
        /// <br>Programmer	: 鸏�</br>
        /// <br>Date		: K2015/06/16</br>
        /// <br></br>
        private string MakeWhereString_DEPSM(ref SqlCommand sqlCommand, CustPrtPprWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;
            
            //��ƃR�[�h
            retstring += " DEPSM.ENTERPRISECODERF=@ENTERPRISECODE2" + Environment.NewLine;
            SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@ENTERPRISECODE2", SqlDbType.NChar);
            paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
            //�n��R�[�h
            if (paramWork.SalesAreaCode != 0)
            {
                retstring += " AND CUSTOMER.SALESAREACODERF=@SALESAREACODE" + Environment.NewLine;
                SqlParameter salesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                salesAreaCode.Value = SqlDataMediator.SqlSetInt32(paramWork.SalesAreaCode);
            }
            //���̓R�[�h1
            if (paramWork.CustAnalysCode1 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE1RF=@CUSTANALYSCODE1RF" + Environment.NewLine;
                SqlParameter custAnalysCode1RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE1RF", SqlDbType.Int);
                custAnalysCode1RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode1);
            }
            //���̓R�[�h2
            if (paramWork.CustAnalysCode2 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE2RF=@CUSTANALYSCODE2RF" + Environment.NewLine;
                SqlParameter custAnalysCode2RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE2RF", SqlDbType.Int);
                custAnalysCode2RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode2);
            }
            //���̓R�[�h3
            if (paramWork.CustAnalysCode3 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE3RF=@CUSTANALYSCODE3RF" + Environment.NewLine;
                SqlParameter custAnalysCode3RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE3RF", SqlDbType.Int);
                custAnalysCode3RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode3);
            }
            //���̓R�[�h4
            if (paramWork.CustAnalysCode4 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE4RF=@CUSTANALYSCODE4RF" + Environment.NewLine;
                SqlParameter custAnalysCode4RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE4RF", SqlDbType.Int);
                custAnalysCode4RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode4);
            }
            //���̓R�[�h5
            if (paramWork.CustAnalysCode5 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE5RF=@CUSTANALYSCODE5RF" + Environment.NewLine;
                SqlParameter custAnalysCode5RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE5RF", SqlDbType.Int);
                custAnalysCode5RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode5);
            }
            //���̓R�[�h6
            if (paramWork.CustAnalysCode6 != 0)
            {
                retstring += " AND CUSTOMER.CUSTANALYSCODE6RF=@CUSTANALYSCODE6RF" + Environment.NewLine;
                SqlParameter custAnalysCode6RF = sqlCommand.Parameters.Add("@CUSTANALYSCODE6RF", SqlDbType.Int);
                custAnalysCode6RF.Value = SqlDataMediator.SqlSetInt32(paramWork.CustAnalysCode6);
            }
            return retstring;
            #endregion  
        }
        #endregion [CustPrtPprSalTblRsltWork�p WHERE���������� (�����f�[�^SELECT�p)]
        //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

        #region [CustPrtPprSalTblRsltWork���� �ďo]
        /// <summary>
        /// �N���X�i�[���� Reader �� CustPrtPprSalTblRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">CustPrtPprWork</param>
        /// <param name="iParam">�����^�C�v 0:����f�[�^ 1:�����f�[�^</param>
        /// <returns></returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        public object CopyToResultWorkFromReader(ref SqlDataReader myReader, object paramWork, int iParam)
        {
            CustPrtPprWork _custPrtPprWork = paramWork as CustPrtPprWork;
            return this.CopyToResultWorkFromReaderProc(ref myReader, _custPrtPprWork, iParam);
        }
        #endregion  //[CustPrtPprSalTblRsltWork���� �ďo]

        #region [CustPrtPprSalTblRsltWork����]
        /// <summary>
        /// �N���X�i�[���� Reader �� SuppPrtPprStcTblRsltWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">CustPrtPprWork</param>
        /// <param name="iType">�����^�C�v 0:����f�[�^ 1:�����f�[�^</param>
        /// <returns></returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.30</br>
        /// <br>Update Note : 2009/12/28 ������ PM.NS�ێ�˗��C</br>
        /// <br>              �ύX�O�P���A�����̒ǉ�</br>
        /// <br>Update Note : 2010/01/29 �k���r 4������</br>
        /// <br>              �ԕi������A�ԕi��������݃t���O�̒ǉ�</br>
        /// <br>Update Note : 2010/08/05 ������ ��Q�E���ǑΉ�8�������[�X��</br>
        /// <br>              �ύX�O�艿�̒ǉ�</br>
        /// <br>Update Note : 2010/12/20 yangmj �v�㌳�󒍇��E�v�㌳�ݏo���̕\�����e�C��</br>
        /// <br>Update Note : 2011/11/28 �k�m ���Ӑ�d�q����/(BL�߰µ��ް����)�⍇���ԍ��̒ǉ�</br>
        /// <br>Update Note : 2014/12/28 �i�N</br>
        /// <br>�Ǘ��ԍ�    : 11070263-00</br>
        /// <br>            : �ϊ���i�Ԃ̒ǉ��Ή�(�ϊ���i��)</br>
        /// <br>Update Note :  K2015/06/16 鸏� </br>
        /// <br>            :  ���C�S���̌ʊJ���˗� </br>
        /// <br>            :  ���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����B</br>
        /// <br>Update Note: 2015/02/05 ������</br>
        /// <br>           : �e�L�X�g�o�͌��������Ȃ����[�h�̒ǉ�</br>
        /// <br>Update Note :K2016/02/23 ���V��</br>
        /// <br>             ���C�P���g ���o�����ɂĎ󒍍쐬�敪��ǉ�����Ή�</br>
        /// <br>Update Note: 2020/03/11 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 �y���ŗ��Ή�</br>
        /// <br>           : �`�[�^�u�A���׃^�u�Ɂu����ŗ��v���ڂ�ǉ�</br>
        private CustPrtPprSalTblRsltWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, CustPrtPprWork paramWork, int iType)
        {
            #region ���o����-�l�Z�b�g
            CustPrtPprSalTblRsltWork resultWork = new CustPrtPprSalTblRsltWork();

            if (iType == (int)iSrcType.SalTbl)
            {
                #region [����f�[�^]
                resultWork.DataDiv = 0;
                // -------------ADD 2009/12/28-------------->>>>>
                resultWork.BfUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFUNITCOSTRF"));
                resultWork.BfSalesUnitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSALESUNITPRICERF"));
                // -------------ADD 2009/12/28--------------<<<<<
                // -------------ADD 2010/08/05-------------->>>>>
                resultWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
                // -------------ADD 2010/08/05--------------<<<<<
                resultWork.AutoAnswerDivSCM = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOANSWERDIVSCMRF"));// add 2011/07/18 zhubj
                
                //---ADD START 2011/11/28 �k�m ----------------------------------->>>>>
                resultWork.InquiryNumber = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("INQUIRYNUMBERRF"));
                //---ADD END 2011/11/28 �k�m -----------------------------------<<<<<
                
                resultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                resultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                resultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                resultWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                resultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
                resultWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
                resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                resultWork.ChangeGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF")); //ADD �i�N 2014/12/28 �ϊ���i�Ԃ̒ǉ��Ή�
                resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                resultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                resultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                resultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                resultWork.CostRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("COSTRATERF"));  //������ ADD �A��729 2011/08/18
                resultWork.SalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRATERF"));  //������ ADD �A��729 2011/08/18
                resultWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));  //����ŗ� // ADD ���V�� 2020/03/11 PMKOBETSU-2912
                resultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                resultWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                resultWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                resultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                resultWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                resultWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
                resultWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRICECONSTAXRF"));
                resultWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
                resultWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
                resultWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
                resultWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                // --- ADD m.suzuki 2010/04/02 ---------->>>>>
                resultWork.ModelHalfName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELHALFNAMERF" ) );
                // --- ADD m.suzuki 2010/04/02 ----------<<<<<
                //resultWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));// DEL 2010/01/12
                resultWork.FirstEntryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF"));// ADD 2010/01/12
                resultWork.SearchFrameNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHFRAMENORF"));
                resultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                resultWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                resultWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
                resultWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
                resultWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
                resultWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
                resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                resultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                resultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                resultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                resultWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
                resultWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                resultWork.ShipmSalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHIPMSALESSLIPNUM"));
                resultWork.SrcSalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SRCSALESSLIPNUM"));
                resultWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                resultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                resultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                resultWork.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESUPPLIERCD"));
                resultWork.UOESupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUPPLIERSNM"));
                resultWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                resultWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                resultWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                resultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                resultWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
                resultWork.ColorName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLORNAME1RF"));
                resultWork.TrimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRIMNAMERF"));
                resultWork.StdUnPrcLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCLPRICERF"));
                resultWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSALUNPRCRF"));
                resultWork.StdUnPrcUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCUNCSTRF"));
                resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                resultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                resultWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                resultWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
                resultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                resultWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                resultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                // ADD 2008.12.09 >>>
                resultWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                resultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                resultWork.StockPartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKPARTYSALESLIPNUMRF"));
                // ADD 2008.12.09 <<<
                // ADD 2009.01.06 >>>
                resultWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
                resultWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
                resultWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
                resultWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));
                resultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));                    
                // ADD 2009.01.06 <<<
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
                //if (paramWork.AcptAnOdrStatus[0] != 30)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
                    resultWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF")); // ADD 2009.01.30

                if (resultWork.AcptAnOdrStatus != 40)
                {
                    resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                }
                else
                {
                    resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                resultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "SEARCHSLIPDATERF" ) ); // ���͓�
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                resultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSKINDCODERF" ) ); // ���i����[����]
                resultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSLGROUPRF" ) ); // ���i�啪�ރR�[�h[����]
                resultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMGROUPRF" ) ); // ���i�����ރR�[�h[����]
                resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSESHELFNORF" ) ); // �q�ɒI��[����]
                resultWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCDDTLRF" ) ); // ����`�[�敪�i���ׁj[����]
                resultWork.GoodsLGroupName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSLGROUPNAMERF" ) ); // ���i�啪�ޖ���[����]
                resultWork.GoodsMGroupName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSMGROUPNAMERF" ) ); // ���i�����ޖ���[����]
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
                // �����o�\�t�p
                resultWork.CarMngNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CARMNGNORF" ) ); // �ԗ��Ǘ�SEQ
                resultWork.MakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKERCODERF" ) ); // �Ԏ탁�[�J�[�R�[�h
                resultWork.ModelCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELCODERF" ) ); // �Ԏ�R�[�h
                resultWork.ModelSubCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELSUBCODERF" ) ); // �Ԏ�T�u�R�[�h
                resultWork.EngineModelNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENGINEMODELNMRF" ) ); // �G���W���^������
                resultWork.ColorCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COLORCODERF" ) ); // �J���[�R�[�h
                resultWork.TrimCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRIMCODERF" ) ); // �g�����R�[�h
                resultWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DELIVEREDGOODSDIVRF" ) ); // �[�i�敪
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  ���� 2009/09/07 ADD
                resultWork.Mileage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MILEAGERF")); // �ԗ����s����
                resultWork.CarNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARNOTERF")); // ���q���l
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  ���� 2009/09/07 ADD
                // -------------ADD 2010/01/29 ---------->>>>>
                resultWork.Retuppercnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RETUPPERCNTRF")); // �ԕi�����
                resultWork.RetuppercntDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETUPPERCNTDIVRF")); // �ԕi��������݃t���O
                // -------------ADD 2010/01/29 ----------<<<<<
                try
                {
                    byte[] varbinary = SqlDataMediator.SqlGetBinaly( myReader, myReader.GetOrdinal( "FULLMODELFIXEDNOARYRF" ) ); // �t���^���Œ�ԍ��z��
                    resultWork.FullModelFixedNoAry = new int[(int)varbinary.Length / sizeof( int )];
                    for ( int idx = 0; idx < resultWork.FullModelFixedNoAry.Length; idx++ )
                    {
                        resultWork.FullModelFixedNoAry[idx] = BitConverter.ToInt32( varbinary, idx * sizeof( int ) );
                    }
                }
                catch
                {
                    resultWork.FullModelFixedNoAry = new int[0];
                }

                // ------------- ADD 2010/04/27 ---------------->>>>>
                try
                {
                    resultWork.FreeSrchMdlFxdNoAry = SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("FREESRCHMDLFXDNOARYRF")); // ���R�����^���Œ�ԍ��z��
                }
                catch
                {
                    resultWork.FreeSrchMdlFxdNoAry = new byte[0];
                }
                // ------------- ADD 2010/04/27 ----------------<<<<<

                try
                {
                    resultWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly( myReader, myReader.GetOrdinal( "CATEGORYOBJARYRF" ) ); // �����I�u�W�F�N�g�z��
                }
                catch
                {
                    resultWork.CategoryObjAry = new byte[0];
                }
                resultWork.SalesInputCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESINPUTCODERF" ) ); // ������͎҃R�[�h�i���s�ҁj
                resultWork.FrontEmployeeCd = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRONTEMPLOYEECDRF" ) ); // ��t�]�ƈ��R�[�h�i�󒍎ҁj
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                // �����敪=0:�ʏ�
                resultWork.HistoryDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HISTORYDIVRF")); ;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                resultWork.UpdateDateTime = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "UPDATEDATETIMERF" ) ); // �X�V����
                resultWork.UpdateDateTimeDetail = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UPDATEDATETIME")); // �X�V����  // ADD 2012/04/01 gezh Redmine#29250
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

                // --- ADD 2010/12/20 ---------->>>>>
                resultWork.HisDtlSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HISDTLSLIPNUMRF")); // ����`�[�ԍ�
                resultWork.AcptAnOdrStatusSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSRCRF")); // �󒍃X�e�[�^�X�i���j
                // --- ADD 2010/12/20 ----------<<<<<

                //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
                resultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                resultWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                resultWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                resultWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                resultWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                resultWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                resultWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
                //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

                #endregion

                // -- DEL 2009/09/04 ------------------------------>>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                //// ���㗚���f�[�^�\������ׁ̈A�ޔ�
                //string key = CreateKeyString( resultWork.AcptAnOdrStatus, resultWork.SalesSlipNum, resultWork.SalesRowNo, resultWork.SalesDate );
                //if ( !_salesSlipHisKeyDic.ContainsKey( key ) )
                //{
                //    _salesSlipHisKeyDic.Add( key, string.Empty );
                //}
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                // -- DEL 2009/09/04 ------------------------------<<<
            }
            #region [DEL 2009/09/04]
            // -- DEL 2009/09/04 ----------------------------->>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
            //else if ( iType == (int)iSrcType.SalHisTbl )
            //{
            //    # region [���㗚���f�[�^�\�����菈��]
            //    // ���㗚���f�[�^�L�[����
            //    int acptAnOdrStatus = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPTANODRSTATUSRF" ) );
            //    string salesSlipNum = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESSLIPNUMRF" ) );
            //    int salesRowNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESROWNORF" ) );
            //    DateTime salesDate;
            //    if ( acptAnOdrStatus != 40 )
            //    {
            //        salesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "SALESDATERF" ) );
            //    }
            //    else
            //    {
            //        salesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "SHIPMENTDAYRF" ) );
            //    }
            //    string key = CreateKeyString( acptAnOdrStatus, salesSlipNum, salesRowNo, salesDate );
            //    // �����Ȃ�ǉ����Ȃ�
            //    if ( _salesSlipHisKeyDic.ContainsKey( key ) )
            //    {
            //        return null;
            //    }
            //    # endregion

            //    # region [���㗚���f�[�^]
            //    resultWork.DataDiv = 0;
            //    resultWork.SalesSlipNum = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESSLIPNUMRF" ) );
            //    resultWork.SalesRowNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESROWNORF" ) );
            //    resultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPTANODRSTATUSRF" ) );
            //    resultWork.SalesSlipCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCDRF" ) );
            //    resultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESEMPLOYEENMRF" ) );
            //    resultWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESTOTALTAXEXCRF" ) );
            //    resultWork.GoodsName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNAMERF" ) );
            //    resultWork.GoodsNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNORF" ) );
            //    resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BLGOODSCODERF" ) );
            //    resultWork.BLGroupCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BLGROUPCODERF" ) );
            //    resultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SHIPMENTCNTRF" ) );
            //    resultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "LISTPRICETAXEXCFLRF" ) );
            //    resultWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "OPENPRICEDIVRF" ) );
            //    resultWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESUNPRCTAXEXCFLRF" ) );
            //    resultWork.SalesUnitCost = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESUNITCOSTRF" ) );
            //    resultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESMONEYTAXEXCRF" ) );
            //    resultWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CONSTAXLAYMETHODRF" ) );
            //    resultWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESTOTALTAXINCRF" ) );
            //    resultWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESPRICECONSTAXRF" ) );
            //    resultWork.TotalCost = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TOTALCOSTRF" ) );
            //    resultWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELDESIGNATIONNORF" ) );
            //    resultWork.CategoryNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CATEGORYNORF" ) );
            //    resultWork.ModelFullName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELFULLNAMERF" ) );
            //    resultWork.FirstEntryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMM( myReader, myReader.GetOrdinal( "FIRSTENTRYDATERF" ) );
            //    resultWork.SearchFrameNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SEARCHFRAMENORF" ) );
            //    resultWork.FullModel = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FULLMODELRF" ) );
            //    resultWork.SlipNote = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTERF" ) );
            //    resultWork.SlipNote2 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTE2RF" ) );
            //    resultWork.SlipNote3 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTE3RF" ) );
            //    resultWork.FrontEmployeeNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRONTEMPLOYEENMRF" ) );
            //    resultWork.SalesInputName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESINPUTNAMERF" ) );
            //    resultWork.CustomerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );
            //    resultWork.CustomerSnm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERSNMRF" ) );
            //    resultWork.SupplierCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPLIERCDRF" ) );
            //    resultWork.SupplierSnm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPPLIERSNMRF" ) );
            //    resultWork.PartySaleSlipNum = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTYSALESLIPNUMRF" ) );
            //    resultWork.CarMngCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CARMNGCODERF" ) );
            //    resultWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACCEPTANORDERNORF" ) );
            //    resultWork.ShipmSalesSlipNum = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SHIPMSALESSLIPNUM" ) );
            //    resultWork.SrcSalesSlipNum = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SRCSALESSLIPNUM" ) );
            //    resultWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESORDERDIVCDRF" ) );
            //    resultWork.WarehouseName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSENAMERF" ) );
            //    resultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPLIERSLIPNORF" ) );
            //    resultWork.UOESupplierCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "UOESUPPLIERCD" ) );
            //    resultWork.UOESupplierSnm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UOESUPPLIERSNM" ) );
            //    resultWork.UoeRemark1 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UOEREMARK1RF" ) );
            //    resultWork.UoeRemark2 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UOEREMARK2RF" ) );
            //    resultWork.GuideName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GUIDENAMERF" ) );
            //    resultWork.SectionGuideNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECTIONGUIDENMRF" ) );
            //    resultWork.DtlNote = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DTLNOTERF" ) );
            //    resultWork.ColorName1 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COLORNAME1RF" ) );
            //    resultWork.TrimName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRIMNAMERF" ) );
            //    resultWork.StdUnPrcLPrice = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "STDUNPRCLPRICERF" ) );
            //    resultWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "STDUNPRCSALUNPRCRF" ) );
            //    resultWork.StdUnPrcUnCst = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "STDUNPRCUNCSTRF" ) );
            //    resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMAKERCDRF" ) );
            //    resultWork.MakerName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERNAMERF" ) );
            //    resultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESMONEYTAXEXCRF" ) );
            //    resultWork.Cost = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "COSTRF" ) );
            //    resultWork.CustSlipNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTSLIPNORF" ) );
            //    resultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "ADDUPADATERF" ) );
            //    resultWork.AccRecDivCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACCRECDIVCDRF" ) );
            //    resultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEBITNOTEDIVRF" ) );
            //    resultWork.SectionCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECTIONCODERF" ) );
            //    resultWork.WarehouseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSECODERF" ) );
            //    resultWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TOTALAMOUNTDISPWAYCDRF" ) );
            //    resultWork.TaxationDivCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TAXATIONDIVCDRF" ) );
            //    resultWork.StockPartySaleSlipNum = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "STOCKPARTYSALESLIPNUMRF" ) );
            //    resultWork.AddresseeCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDRESSEECODERF" ) );
            //    resultWork.AddresseeName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEENAMERF" ) );
            //    resultWork.AddresseeName2 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEENAME2RF" ) );
            //    resultWork.FrameNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRAMENORF" ) );
            //    resultWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ENTERPRISEGANRECODERF" ) );
            //    //resultWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "ACPTANODRREMAINCNTRF" ) );
            //    resultWork.AcptAnOdrRemainCnt = 0;
            //    if ( resultWork.AcptAnOdrStatus != 40 )
            //    {
            //        resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "SALESDATERF" ) );
            //    }
            //    else
            //    {
            //        resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "SHIPMENTDAYRF" ) );
            //    }
            //    resultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "SEARCHSLIPDATERF" ) ); // ���͓�
            //    resultWork.GoodsKindCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSKINDCODERF" ) ); // ���i����[����]
            //    resultWork.GoodsLGroup = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSLGROUPRF" ) ); // ���i�啪�ރR�[�h[����]
            //    resultWork.GoodsMGroup = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMGROUPRF" ) ); // ���i�����ރR�[�h[����]
            //    resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSESHELFNORF" ) ); // �q�ɒI��[����]
            //    resultWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCDDTLRF" ) ); // ����`�[�敪�i���ׁj[����]
            //    resultWork.GoodsLGroupName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSLGROUPNAMERF" ) ); // ���i�啪�ޖ���[����]
            //    resultWork.GoodsMGroupName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSMGROUPNAMERF" ) ); // ���i�����ޖ���[����]
            //    // �����o�\�t�p
            //    resultWork.CarMngNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CARMNGNORF" ) ); // �ԗ��Ǘ�SEQ
            //    resultWork.MakerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKERCODERF" ) ); // �Ԏ탁�[�J�[�R�[�h
            //    resultWork.ModelCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELCODERF" ) ); // �Ԏ�R�[�h
            //    resultWork.ModelSubCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELSUBCODERF" ) ); // �Ԏ�T�u�R�[�h
            //    resultWork.EngineModelNm = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENGINEMODELNMRF" ) ); // �G���W���^������
            //    resultWork.ColorCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COLORCODERF" ) ); // �J���[�R�[�h
            //    resultWork.TrimCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRIMCODERF" ) ); // �g�����R�[�h
            //    resultWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DELIVEREDGOODSDIVRF" ) ); // �[�i�敪
            //    try
            //    {
            //        byte[] varbinary = SqlDataMediator.SqlGetBinaly( myReader, myReader.GetOrdinal( "FULLMODELFIXEDNOARYRF" ) ); // �t���^���Œ�ԍ��z��
            //        resultWork.FullModelFixedNoAry = new int[(int)varbinary.Length / sizeof( int )];
            //        for ( int idx = 0; idx < resultWork.FullModelFixedNoAry.Length; idx++ )
            //        {
            //            resultWork.FullModelFixedNoAry[idx] = BitConverter.ToInt32( varbinary, idx * sizeof( int ) );
            //        }
            //    }
            //    catch
            //    {
            //        resultWork.FullModelFixedNoAry = new int[0];
            //    }

            //    try
            //    {
            //        resultWork.CategoryObjAry = SqlDataMediator.SqlGetBinaly( myReader, myReader.GetOrdinal( "CATEGORYOBJARYRF" ) ); // �����I�u�W�F�N�g�z��
            //    }
            //    catch
            //    {
            //        resultWork.CategoryObjAry = new byte[0];
            //    }
            //    resultWork.SalesInputCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESINPUTCODERF" ) ); // ������͎҃R�[�h�i���s�ҁj
            //    resultWork.FrontEmployeeCd = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRONTEMPLOYEECDRF" ) ); // ��t�]�ƈ��R�[�h�i�󒍎ҁj
            //    // �����敪=1:����
            //    resultWork.HistoryDiv = 1;
            //    # endregion
            //}
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
            // -- DEL 2009/09/04 -----------------------------<<<
            #endregion [2009/09/04]
            else if (iType == (int)iSrcType.DepTbl)
            {
                #region [�����f�[�^]
                resultWork.DataDiv = 1;
                resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DEPOSITDATERF"));
                Int32 iDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPNORF"));
                resultWork.SalesSlipNum = iDepositSlipNo.ToString();
                resultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITROWNORF"));
                resultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITAGENTNMRF"));
                resultWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSPRICTOTAL"));
                resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MONEYKINDNAMERF"));
                resultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));
                resultWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTLINERF"));
                resultWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOSITINPUTAGENTNMRF"));
                resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                // �C�� 2009.01.14 >>>
                //resultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                resultWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));                
                // �C�� 2009.01.14 <<<
                Int32 iValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
                resultWork.DtlNote = iValidityTerm.ToString();

                resultWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                
                resultWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITDEBITNOTECDRF"));
                resultWork.FeeDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FEEDEPOSITRF"));
                resultWork.DiscountDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTDEPOSITRF"));
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                resultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "INPUTDAYRF" ) ); // ���͓�
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                // �����敪=0:�ʏ�
                resultWork.HistoryDiv = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                resultWork.UpdateDateTime = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "UPDATEDATETIMERF" ) ); // �X�V����
                resultWork.UpdateDateTimeDetail = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UPDATEDATETIME")); // �X�V����  // ADD 2012/04/01 gezh Redmine#29250
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

                //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����----->>>>>
                resultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                resultWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                resultWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                resultWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                resultWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                resultWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                resultWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
                //----- ADD K2015/06/16 鸏� ���C�S���̌ʊJ���˗�:���Ӑ�d�q�����u�n��v�Ɓu���̓R�[�h�v��ǉ�����-----<<<<<

                #endregion  //[�����f�[�^]
            }
            #endregion
            //----- ADD 2015/02/05 ������ -------------------->>>>>
            #region [�e�L�X�g�o�͗p�����]
            else if (iType == (int)iSrcType.SalDate)
            {
                resultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATE"));
            }
            #endregion
            //----- ADD 2015/02/05 ������ --------------------<<<<<

            return resultWork;
        }
        #endregion  //[CustPrtPprSalTblRsltWork����]
    }
}

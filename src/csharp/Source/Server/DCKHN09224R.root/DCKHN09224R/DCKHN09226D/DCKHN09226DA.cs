using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalesTtlStWork
	/// <summary>
	///                      ����S�̐ݒ胏�[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ����S�̐ݒ胏�[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/28</br>
	/// <br>Genarated Date   :   2008/09/29  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br></br>
    /// <br>Update Note     :    2009/10/19 ��r��</br>
    /// <br>                     PM.NS-3-A�E�ێ�˗��A</br>
    /// <br>                     �\���敪�v���Z�X��ǉ�</br>
    /// <br>Update Note     :    2010/01/29 ����</br>
    /// <br>                     PM1003�E�l������</br>
    /// <br>                     �󒍐����͂�ǉ�</br>
    /// <br>Update Note     :    2010/04/30 �I�M</br>
    /// <br>                     PM1007D�E���R����</br>
    /// <br>                     ���R�������i�����o�^�敪��ǉ�</br>    
    /// <br>Update Note     :    2010/05/04 ���C��</br>
    /// <br>                     PM1007�E6������</br>
    /// <br>                     ���s�҃`�F�b�N�敪�A���͑q�Ƀ`�F�b�N�敪��ǉ�</br>
    /// <br>Update Note     :    2010/05/14 21024 ���X�� ��</br>
    /// <br>                     �E�U������</br>
    /// <br>                     �@BL�R�[�h�����i���\���敪�P�`�S�A�i�Ԍ����i���\���敪�P�`�S�A�D�Ǖ��i�����i���g�p�敪��ǉ�</br>   
    /// <br>Update Note     :    2010/08/04 �k���r</br>
    /// <br>                     PM1012</br>
    /// <br>                     �����_�\���敪��ǉ�</br>
    /// <br>Update Note     :    2011/06/06 �������n</br>
    /// <br>                     �̔��敪�\���敪��ǉ�</br>
    /// <br>Update Note     :    2012/04/13 ���c�N�v</br>
    /// <br>                     �ݏo�d���敪��ǉ�</br>
    /// <br>Update Note     :    2012/12/27 �e�c���V</br>
    /// <br>                     ���Еi�Ԉ󎚑Ή�</br>
    /// <br>Update Note     :    2013/01/15 FSI���� ���</br>
    /// <br>                     �d���ԕi�\��@�\�敪��ǉ�</br>
    /// <br>Update Note     :    2013/01/16 �e�c���V</br>
    /// <br>                     ���Еi�Ԉ󎚑Ή��d�l�ύX�Ή�</br>
    /// <br>Update Note     :    2013/01/21 cheq</br>
    /// <br>�Ǘ��ԍ�        :    10806793-00 2013/03/13�z�M��</br>
    /// <br>                     Redmine#33797 �����������l�敪��ǉ�</br>
    /// <br>Update Note     :    2013/02/05 �e�c���V</br>
    /// <br>                :    �a�k�R�[�h�O�Ή�</br>
    /// <br>Update Note     :    2017/04/13 杍^</br>
    /// <br>                     ����`�[���͉�ʂ̎d���S���҃Z�b�g���@��ύX</br>
    /// <br>                     �d���S���Q�Ƌ敪�̒ǉ�</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalesTtlStWork : IFileHeader
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>�X�V�]�ƈ��R�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private string _updEmployeeCode = "";

		/// <summary>�X�V�A�Z���u��ID1</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>�X�V�A�Z���u��ID2</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>���_�R�[�h</summary>
		/// <remarks>�I�[���O�͑S��</remarks>
		private string _sectionCode = "";

		/// <summary>���_�K�C�h����</summary>
		private string _sectionGuideNm = "";

		/// <summary>����`�[���s�敪</summary>
		/// <remarks>0:����@1:���Ȃ�</remarks>
		private Int32 _salesSlipPrtDiv;

		/// <summary>�o�ד`�[���s�敪</summary>
		/// <remarks>0:����@1:���Ȃ�</remarks>
		private Int32 _shipmSlipPrtDiv;

		/// <summary>�o�ד`�[�P������敪</summary>
		/// <remarks>0:���Ȃ��@1:����</remarks>
		private Int32 _shipmSlipUnPrcPrtDiv;

		/// <summary>�e���`�F�b�N����</summary>
		/// <remarks>�e���`�F�b�N�̉����l�i���œ��́j�@XX.X���@�ȏ�</remarks>
		private Double _grsProfitCheckLower;

		/// <summary>�e���`�F�b�N�K��</summary>
		/// <remarks>�e���`�F�b�N�̓K���l�i���œ��́j�@XX.X���@�ȏ�</remarks>
		private Double _grsProfitCheckBest;

		/// <summary>�e���`�F�b�N���</summary>
		/// <remarks>�e���`�F�b�N�̏���l�i���œ��́j�@XX.X���@�ȏ�</remarks>
		private Double _grsProfitCheckUpper;

		/// <summary>�e���`�F�b�N�����L��</summary>
		/// <remarks>�e���`�F�b�N�̉����l�����̋L��</remarks>
		private string _grsProfitChkLowSign = "";

		/// <summary>�e���`�F�b�N�K���L��</summary>
		/// <remarks>�e���`�F�b�N�̓K���l���牺���l�܂ł̋L��</remarks>
		private string _grsProfitChkBestSign = "";

		/// <summary>�e���`�F�b�N����L��</summary>
		/// <remarks>�e���`�F�b�N�̏���l����K���l�܂ł̋L��</remarks>
		private string _grsProfitChkUprSign = "";

		/// <summary>�e���`�F�b�N�ő�L��</summary>
		/// <remarks>�e���`�F�b�N�̏���l�I�[�o�[�̋L��</remarks>
		private string _grsProfitChkMaxSign = "";

		/// <summary>����S���ύX�敪</summary>
		/// <remarks>0:�\�@1:�ύX���x���@2:�s��</remarks>
		private Int32 _salesAgentChngDiv;

		/// <summary>�󒍎ҕ\���敪</summary>
		/// <remarks>0:�L��@1:�����@ 2:�K�{�@�i�����̏ꍇ�A��ʍ��ڂ��\��) </remarks>
		private Int32 _acpOdrAgentDispDiv;

		/// <summary>�`�[���l�Q�\���敪</summary>
		/// <remarks>0:�L��@1:�����@�i�����̏ꍇ�A��ʍ��ڂ��\��) </remarks>
		private Int32 _brSlipNote2DispDiv;

		/// <summary>���ה��l�\���敪</summary>
		/// <remarks>0:�L��@1:�����@�i�����̏ꍇ�A��ʍ��ڂ��\��) </remarks>
		private Int32 _dtlNoteDispDiv;

		/// <summary>�������ݒ莞�敪</summary>
		/// <remarks>0:�[����\���@1:�艿��\��</remarks>
		private Int32 _unPrcNonSettingDiv;

		/// <summary>���σf�[�^�v��c�敪</summary>
		/// <remarks>0:�c���@1:�c���Ȃ�</remarks>
		private Int32 _estmateAddUpRemDiv;

		/// <summary>�󒍃f�[�^�v��c�敪</summary>
		/// <remarks>0:�c���@1:�c���Ȃ�</remarks>
		private Int32 _acpOdrrAddUpRemDiv;

		/// <summary>�o�׃f�[�^�v��c�敪</summary>
		/// <remarks>0:�c���@1:�c���Ȃ�</remarks>
		private Int32 _shipmAddUpRemDiv;

		/// <summary>�ԕi���݌ɓo�^�敪</summary>
		/// <remarks>0:����@1:���Ȃ�</remarks>
		private Int32 _retGoodsStockEtyDiv;

		/// <summary>�艿�I���敪</summary>
		/// <remarks>0:���Ȃ� 1:����</remarks>
		private Int32 _listPriceSelectDiv;

		/// <summary>���[�J�[���͋敪</summary>
		/// <remarks>0:�C�Ӂ@1:�K�{</remarks>
		private Int32 _makerInpDiv;

		/// <summary>BL���i�R�[�h���͋敪</summary>
		/// <remarks>0:�C�Ӂ@1:�K�{</remarks>
		private Int32 _bLGoodsCdInpDiv;

		/// <summary>�d������͋敪</summary>
		/// <remarks>0:�C�Ӂ@1:�K�{</remarks>
		private Int32 _supplierInpDiv;

		/// <summary>�d���`�[�폜�敪</summary>
		/// <remarks>0:���Ȃ��@1:�m�F�@2:����i����:���d�������v��̎d���`�[�𔄓`�폜���ɓ����폜�j</remarks>
		private Int32 _supplierSlipDelDiv;

		/// <summary>���Ӑ�K�C�h�����\���敪</summary>
		/// <remarks>1:�����_�̂ݕ\���@0:�S�ĕ\�� </remarks>
		private Int32 _custGuideDispDiv;

		/// <summary>�`�[�C���敪�i���t�j</summary>
		/// <remarks>0:�\�@1:�ԕi�`�[�ȊO�� 2:�ԕi�`�[�̂݉� 3:�s��</remarks>
		private Int32 _slipChngDivDate;

		/// <summary>�`�[�C���敪�i�����j</summary>
		/// <remarks>0:�\�@1:�ԕi�`�[�ȊO�� 2:�ԕi�`�[�̂݉� 3:�s��</remarks>
		private Int32 _slipChngDivCost;

		/// <summary>�`�[�C���敪�i�����j</summary>
		/// <remarks>0:�\�@1:�ԕi�`�[�ȊO�� 2:�ԕi�`�[�̂݉� 3:�s��</remarks>
		private Int32 _slipChngDivUnPrc;

		/// <summary>�`�[�C���敪�i�艿�j</summary>
		/// <remarks>0:�\�@1:�s�@2:�݌ɂ�����ꍇ�C���s�@�i�ԕi�`�[�ȊO�j</remarks>
		private Int32 _slipChngDivLPrice;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/09 G.Miyatsu ADD
        /// <summary>�ԕi�`�[�C���敪�i�����j</summary>
        /// <remarks>0:�\�@1:�s�@2:���g�p�@3:�݌Ɏ��s��</remarks>
        private Int32 _retSlipChngDivCost;

        /// <summary>�ԕi�`�[�C���敪�i�����j</summary>
        /// <remarks>0:�\�@1:�s�@2:���g�p�@3:�݌Ɏ��s��</remarks>
        private Int32 _retSlipChngDivUnPrc;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/09 G.Miyatsu ADD

		/// <summary>������������R�[�h</summary>
		/// <remarks>�G���g���ł̎��������̋���</remarks>
		private Int32 _autoDepoKindCode;

		/// <summary>�����������햼��</summary>
		/// <remarks>�G���g���ł̎��������̋���</remarks>
		private string _autoDepoKindName = "";

		/// <summary>������������敪</summary>
		/// <remarks>�G���g���ł̎��������̋���</remarks>
		private Int32 _autoDepoKindDivCd;

		/// <summary>�l������</summary>
		private string _discountName = "";

		/// <summary>���s�ҕ\���敪</summary>
		/// <remarks>0:����@1:���Ȃ��@ 2:�K�{�@�i�����̏ꍇ�A��ʍ��ڂ��\��) </remarks>
		private Int32 _inpAgentDispDiv;

		/// <summary>���Ӑ撍�ԕ\���敪</summary>
		/// <remarks>0:���Ȃ��@1:����</remarks>
		private Int32 _custOrderNoDispDiv;

		/// <summary>���q�Ǘ��ԍ��\���敪</summary>
		/// <remarks>0:���Ȃ��@1:����</remarks>
		private Int32 _carMngNoDispDiv;

        // --- ADD 2009/10/19 ---------->>>>>
        /// <summary>�\���敪�v���Z�X</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _priceSelectDispDiv;
        // --- ADD 2009/10/19 ----------<<<<<

        // --- ADD 2010/01/29 ---------->>>>>
        /// <summary>�󒍐�����</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _acpOdrInputDiv;
        // --- ADD 2010/01/29 ----------<<<<<

        // --- ADD 2010/05/04 ---------->>>>>
        /// <summary>���s�҃`�F�b�N�敪</summary>
        /// <remarks>0:���� 1:�ē��� 2:�x��</remarks>
        private Int32 _inpAgentChkDiv;

        /// <summary>���͑q�Ƀ`�F�b�N�敪</summary>
        /// <remarks>0:���� 1:�ē��� 2:�x��</remarks>
        private Int32 _inpWarehChkDiv;
        // --- ADD 2010/05/04 ----------<<<<<

		/// <summary>�`�[���l�R�\���敪</summary>
		/// <remarks>0:����@1:���Ȃ��@�i�����̏ꍇ�A��ʍ��ڂ��\��) </remarks>
		private Int32 _brSlipNote3DispDiv;

		/// <summary>�`�[���t�N���A�敪</summary>
		/// <remarks>0:�V�X�e�����t 1:���͓��t</remarks>
		private Int32 _slipDateClrDivCd;

		/// <summary>���i�����o�^</summary>
		/// <remarks>0:�Ȃ��@1:����</remarks>
		private Int32 _autoEntryGoodsDivCd;

		/// <summary>�����`�F�b�N�敪</summary>
		/// <remarks>0:�����@1:�ē��́@2:�x��MSG�@�i�艿���P���̏ꍇ�j</remarks>
		private Int32 _costCheckDivCd;

		/// <summary>���������\���敪</summary>
		/// <remarks>0:�\���� 1:�݌ɏ�</remarks>
		private Int32 _joinInitDispDiv;

		/// <summary>���������敪</summary>
		/// <remarks>0:���Ȃ�,1:����</remarks>
		private Int32 _autoDepositCd;

		/// <summary>��֏����敪</summary>
		/// <remarks>0:��ւ��Ȃ� 1:��ւ���(�݌ɖ�) 2:��ւ���i�݌ɖ����j</remarks>
		private Int32 _substCondDivCd;

		/// <summary>�`�[�쐬���@</summary>
		/// <remarks>0:���͏� 1:�݌ɕ� 2:�q�ɕ� 3:�o�͐��</remarks>
		private Int32 _slipCreateProcess;

		/// <summary>�q�Ƀ`�F�b�N�敪</summary>
		/// <remarks>0:�x���@1:����</remarks>
		private Int32 _warehouseChkDiv;

		/// <summary>���i�����敪</summary>
		/// <remarks>0:���i����,1:�i�Ԍ���</remarks>
		private Int32 _partsSearchDivCd;

		/// <summary>�e���\���敪</summary>
		/// <remarks>0:���� 1:���Ȃ�,</remarks>
		private Int32 _grsProfitDspCd;

		/// <summary>���i�����D�揇�敪</summary>
		/// <remarks>0:�����@1:�D��</remarks>
		private Int32 _partsSearchPriDivCd;

		/// <summary>����d���敪</summary>
		/// <remarks>0:���Ȃ��@1:����@2:�K�{����</remarks>
		private Int32 _salesStockDiv;

		/// <summary>����pBL���i�R�[�h�敪</summary>
		/// <remarks>0:���i,1:����</remarks>
		private Int32 _prtBLGoodsCodeDiv;

		/// <summary>���_�\���敪</summary>
		/// <remarks>0:�W���@1:�����_�@2:�\�������@���W���� ���Ӑ�̊Ǘ����_</remarks>
		private Int32 _sectDspDivCd;

		/// <summary>���i���ĕ\���敪</summary>
		/// <remarks>0:���Ȃ��@1:���� ��BL���ޕύX����BL���̂ŏ㏑��</remarks>
		private Int32 _goodsNmReDispDivCd;

		/// <summary>�����\���敪</summary>
		/// <remarks>0:���Ȃ� 1:����@</remarks>
		private Int32 _costDspDivCd;

		/// <summary>�����`�[���t�N���A�敪</summary>
		/// <remarks>0:�V�X�e�����t 1:���͓��t</remarks>
		private Int32 _depoSlipDateClrDiv;

		/// <summary>�����`�[���t�͈͋敪</summary>
		/// <remarks>0:�����Ȃ� 1:�V�X�e�����t�ȍ~���͕s��</remarks>
		private Int32 _depoSlipDateAmbit;

		/// <summary>���͑e���`�F�b�N����</summary>
		/// <remarks>���͑e���`�F�b�N�̉����l�i���œ��́j�@XX.X���@�ȏ�</remarks>
		private Double _inpGrsProfChkLower;

		/// <summary>���͑e���`�F�b�N���</summary>
		/// <remarks>���͑e���`�F�b�N�̏���l�i���œ��́j�@XX.X���@����</remarks>
		private Double _inpGrsProfChkUpper;

		/// <summary>���͑e���`�F�b�N�����敪</summary>
		/// <remarks>0:�ē���,1:�x��,2:����</remarks>
		private Int32 _inpGrsPrfChkLowDiv;

		/// <summary>���͑e���`�F�b�N����敪</summary>
		/// <remarks>0:�ē���,1:�x��,2:����</remarks>
		private Int32 _inpGrsPrfChkUppDiv;

		/// <summary>�D�Ǒ�֏����敪</summary>
		/// <remarks>0:��ւ��Ȃ� 1:��ւ���(�݌ɖ�) 2:��ւ���i�݌ɖ����j</remarks>
		private Int32 _prmSubstCondDivCd;

		/// <summary>��֓K�p�敪</summary>
		/// <remarks>0:���Ȃ�, 1:����(�����A�Z�b�g), 2:�S�āi�����A�Z�b�g�A�����j</remarks>
		private Int32 _substApplyDivCd;

        /// <summary>�i���\���敪</summary>
        /// <remarks>0:���i�D��, 1:�񋟗D��</remarks>
        private Int32 _partsNameDspDivCd;

        // --- ADD 2010/04/30-------------------------------->>>>>
        /// <summary>���R�������i�����o�^�敪</summary>
        /// <remarks>0:���Ȃ��@1:���� </remarks>
        private Int32 _frSrchPrtAutoEntDiv;
        // --- ADD 2010/04/30 --------------------------------<<<<<

        /// <summary>BL�R�[�h�}�ԋ敪</summary>
        /// <remarks>0:�}�ԂȂ�, 1:�}�Ԃ���</remarks>
        private Int32 _bLGoodsCdDerivNoDiv;

        // 2010/05/14 Add >>>
        /// <summary>BL�R�[�h�����i���\���敪�P</summary>
        /// <remarks>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</remarks>
        private Int32 _bLCdPrtsNmDspDivCd1;

        /// <summary>BL�R�[�h�����i���\���敪�Q</summary>
        /// <remarks>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</remarks>
        private Int32 _bLCdPrtsNmDspDivCd2;

        /// <summary>BL�R�[�h�����i���\���敪�R</summary>
        /// <remarks>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</remarks>
        private Int32 _bLCdPrtsNmDspDivCd3;

        /// <summary>BL�R�[�h�����i���\���敪�S</summary>
        /// <remarks>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</remarks>
        private Int32 _bLCdPrtsNmDspDivCd4;

        /// <summary>�i�Ԍ����i���\���敪�P</summary>
        /// <remarks>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</remarks>
        private Int32 _gdNoPrtsNmDspDivCd1;

        /// <summary>�i�Ԍ����i���\���敪�Q</summary>
        /// <remarks>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</remarks>
        private Int32 _gdNoPrtsNmDspDivCd2;

        /// <summary>�i�Ԍ����i���\���敪�R</summary>
        /// <remarks>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</remarks>
        private Int32 _gdNoPrtsNmDspDivCd3;

        /// <summary>�i�Ԍ����i���\���敪�S</summary>
        /// <remarks>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</remarks>
        private Int32 _gdNoPrtsNmDspDivCd4;

        /// <summary>�D�Ǖ��i�����i���g�p�敪</summary>
        /// <remarks>0:�g�p 1:���g�p</remarks>
        private Int32 _prmPrtsNmUseDivCd;
        // 2010/05/14 Add <<<

        // --- ADD 2010/08/04 ---------->>>>>
        /// <summary>�����_�\���敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _dwnPLCdSpDivCd;
        // --- ADD 2010/08/04 ----------<<<<<

        // --- ADD 2011/06/06 ---------->>>>>
        /// <summary>�̔��敪�\���敪</summary>
        /// <remarks>0:����, 1:���Ȃ�, 2:�K�{</remarks>
        private Int32 _salesCdDspDivCd;
        // --- ADD 2011/06/06 ----------<<<<<

        // --- ADD 2012/04/13 ---------->>>>>
        /// <summary>�ݏo�d���敪</summary>
        /// <remarks>0:���Ȃ�, 1:����, 2:�K�{����</remarks>
        private Int32 _rentStockDiv;  
        // --- ADD 2012/04/13 ----------<<<<<

        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        /// <summary>���Еi�Ԉ󎚋敪</summary>
        /// <remarks>0:���Ȃ�, 1:����</remarks>
        private Int32 _EpPartsNoPrtCd;

        /// <summary>���Еi�ԕt������</summary>
        private string _EpPartsNoAddChar;
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

        // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
        /// <summary>�󎚕i�ԏ����l</summary>
        /// <remarks>0:�D��, 1:����, 2:����</remarks>
        private Int32 _PrintGoodsNoDef;
        // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
		// --- ADD 2013/01/15 ---------->>>>>
        /// <summary>�d���ԕi�\��@�\�敪</summary>
        private Int32 _stockRetGoodsPlnDiv;
        // --- ADD 2013/01/15 ----------<<<<<

        // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
        /// <summary>�����������l�敪</summary>
        /// <remarks>0:����`�[�ԍ� 1:����`�[���l 2:����</remarks>
        private Int32 _autoDepositNoteDiv;
        // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<

        // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
        /// <summary>BL�R�[�h�O�Ή�</summary>
        /// <remarks>0:���Ȃ�, 1:����</remarks>
        private Int32 _BLGoodsCdZeroSuprt;

        /// <summary>�ϊ��R�[�h</summary>
        private Int32 _BLGoodsCdChange;
        // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

        // --- ADD 2017/04/13 杍^ Redmine#49283---------->>>>>
        /// <summary>�d���S���Q�Ƌ敪</summary>
        private Int32 _stockEmpRefDiv;
        // --- ADD 2017/04/13 杍^ Redmine#49283----------<<<<<

        /// public propaty name  :  CreateDateTime
		/// <summary>�쐬�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>�X�V�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

		/// public propaty name  :  EnterpriseCode
		/// <summary>��ƃR�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUID�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>�_���폜�敪�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_���폜�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>�I�[���O�͑S��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  SectionGuideNm
		/// <summary>���_�K�C�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionGuideNm
		{
			get{return _sectionGuideNm;}
			set{_sectionGuideNm = value;}
		}

		/// public propaty name  :  SalesSlipPrtDiv
		/// <summary>����`�[���s�敪�v���p�e�B</summary>
		/// <value>0:����@1:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[���s�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesSlipPrtDiv
		{
			get{return _salesSlipPrtDiv;}
			set{_salesSlipPrtDiv = value;}
		}

		/// public propaty name  :  ShipmSlipPrtDiv
		/// <summary>�o�ד`�[���s�敪�v���p�e�B</summary>
		/// <value>0:����@1:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�ד`�[���s�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShipmSlipPrtDiv
		{
			get{return _shipmSlipPrtDiv;}
			set{_shipmSlipPrtDiv = value;}
		}

		/// public propaty name  :  ShipmSlipUnPrcPrtDiv
		/// <summary>�o�ד`�[�P������敪�v���p�e�B</summary>
		/// <value>0:���Ȃ��@1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�ד`�[�P������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShipmSlipUnPrcPrtDiv
		{
			get{return _shipmSlipUnPrcPrtDiv;}
			set{_shipmSlipUnPrcPrtDiv = value;}
		}

		/// public propaty name  :  GrsProfitCheckLower
		/// <summary>�e���`�F�b�N�����v���p�e�B</summary>
		/// <value>�e���`�F�b�N�̉����l�i���œ��́j�@XX.X���@�ȏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double GrsProfitCheckLower
		{
			get{return _grsProfitCheckLower;}
			set{_grsProfitCheckLower = value;}
		}

		/// public propaty name  :  GrsProfitCheckBest
		/// <summary>�e���`�F�b�N�K���v���p�e�B</summary>
		/// <value>�e���`�F�b�N�̓K���l�i���œ��́j�@XX.X���@�ȏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N�K���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double GrsProfitCheckBest
		{
			get{return _grsProfitCheckBest;}
			set{_grsProfitCheckBest = value;}
		}

		/// public propaty name  :  GrsProfitCheckUpper
		/// <summary>�e���`�F�b�N����v���p�e�B</summary>
		/// <value>�e���`�F�b�N�̏���l�i���œ��́j�@XX.X���@�ȏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double GrsProfitCheckUpper
		{
			get{return _grsProfitCheckUpper;}
			set{_grsProfitCheckUpper = value;}
		}

		/// public propaty name  :  GrsProfitChkLowSign
		/// <summary>�e���`�F�b�N�����L���v���p�e�B</summary>
		/// <value>�e���`�F�b�N�̉����l�����̋L��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N�����L���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GrsProfitChkLowSign
		{
			get{return _grsProfitChkLowSign;}
			set{_grsProfitChkLowSign = value;}
		}

		/// public propaty name  :  GrsProfitChkBestSign
		/// <summary>�e���`�F�b�N�K���L���v���p�e�B</summary>
		/// <value>�e���`�F�b�N�̓K���l���牺���l�܂ł̋L��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N�K���L���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GrsProfitChkBestSign
		{
			get{return _grsProfitChkBestSign;}
			set{_grsProfitChkBestSign = value;}
		}

		/// public propaty name  :  GrsProfitChkUprSign
		/// <summary>�e���`�F�b�N����L���v���p�e�B</summary>
		/// <value>�e���`�F�b�N�̏���l����K���l�܂ł̋L��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N����L���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GrsProfitChkUprSign
		{
			get{return _grsProfitChkUprSign;}
			set{_grsProfitChkUprSign = value;}
		}

		/// public propaty name  :  GrsProfitChkMaxSign
		/// <summary>�e���`�F�b�N�ő�L���v���p�e�B</summary>
		/// <value>�e���`�F�b�N�̏���l�I�[�o�[�̋L��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N�ő�L���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GrsProfitChkMaxSign
		{
			get{return _grsProfitChkMaxSign;}
			set{_grsProfitChkMaxSign = value;}
		}

		/// public propaty name  :  SalesAgentChngDiv
		/// <summary>����S���ύX�敪�v���p�e�B</summary>
		/// <value>0:�\�@1:�ύX���x���@2:�s��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����S���ύX�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesAgentChngDiv
		{
			get{return _salesAgentChngDiv;}
			set{_salesAgentChngDiv = value;}
		}

		/// public propaty name  :  AcpOdrAgentDispDiv
		/// <summary>�󒍎ҕ\���敪�v���p�e�B</summary>
		/// <value>0:�L��@1:�����@ 2:�K�{�@�i�����̏ꍇ�A��ʍ��ڂ��\��) </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍎ҕ\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcpOdrAgentDispDiv
		{
			get{return _acpOdrAgentDispDiv;}
			set{_acpOdrAgentDispDiv = value;}
		}

		/// public propaty name  :  BrSlipNote2DispDiv
		/// <summary>�`�[���l�Q�\���敪�v���p�e�B</summary>
		/// <value>0:�L��@1:�����@�i�����̏ꍇ�A��ʍ��ڂ��\��) </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[���l�Q�\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BrSlipNote2DispDiv
		{
			get{return _brSlipNote2DispDiv;}
			set{_brSlipNote2DispDiv = value;}
		}

		/// public propaty name  :  DtlNoteDispDiv
		/// <summary>���ה��l�\���敪�v���p�e�B</summary>
		/// <value>0:�L��@1:�����@�i�����̏ꍇ�A��ʍ��ڂ��\��) </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ה��l�\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DtlNoteDispDiv
		{
			get{return _dtlNoteDispDiv;}
			set{_dtlNoteDispDiv = value;}
		}

		/// public propaty name  :  UnPrcNonSettingDiv
		/// <summary>�������ݒ莞�敪�v���p�e�B</summary>
		/// <value>0:�[����\���@1:�艿��\��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������ݒ莞�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UnPrcNonSettingDiv
		{
			get{return _unPrcNonSettingDiv;}
			set{_unPrcNonSettingDiv = value;}
		}

		/// public propaty name  :  EstmateAddUpRemDiv
		/// <summary>���σf�[�^�v��c�敪�v���p�e�B</summary>
		/// <value>0:�c���@1:�c���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���σf�[�^�v��c�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EstmateAddUpRemDiv
		{
			get{return _estmateAddUpRemDiv;}
			set{_estmateAddUpRemDiv = value;}
		}

		/// public propaty name  :  AcpOdrrAddUpRemDiv
		/// <summary>�󒍃f�[�^�v��c�敪�v���p�e�B</summary>
		/// <value>0:�c���@1:�c���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃f�[�^�v��c�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcpOdrrAddUpRemDiv
		{
			get{return _acpOdrrAddUpRemDiv;}
			set{_acpOdrrAddUpRemDiv = value;}
		}

		/// public propaty name  :  ShipmAddUpRemDiv
		/// <summary>�o�׃f�[�^�v��c�敪�v���p�e�B</summary>
		/// <value>0:�c���@1:�c���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�׃f�[�^�v��c�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShipmAddUpRemDiv
		{
			get{return _shipmAddUpRemDiv;}
			set{_shipmAddUpRemDiv = value;}
		}

		/// public propaty name  :  RetGoodsStockEtyDiv
		/// <summary>�ԕi���݌ɓo�^�敪�v���p�e�B</summary>
		/// <value>0:����@1:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi���݌ɓo�^�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RetGoodsStockEtyDiv
		{
			get{return _retGoodsStockEtyDiv;}
			set{_retGoodsStockEtyDiv = value;}
		}

		/// public propaty name  :  ListPriceSelectDiv
		/// <summary>�艿�I���敪�v���p�e�B</summary>
		/// <value>0:���Ȃ� 1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�I���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ListPriceSelectDiv
		{
			get{return _listPriceSelectDiv;}
			set{_listPriceSelectDiv = value;}
		}

		/// public propaty name  :  MakerInpDiv
		/// <summary>���[�J�[���͋敪�v���p�e�B</summary>
		/// <value>0:�C�Ӂ@1:�K�{</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[���͋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MakerInpDiv
		{
			get{return _makerInpDiv;}
			set{_makerInpDiv = value;}
		}

		/// public propaty name  :  BLGoodsCdInpDiv
		/// <summary>BL���i�R�[�h���͋敪�v���p�e�B</summary>
		/// <value>0:�C�Ӂ@1:�K�{</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h���͋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGoodsCdInpDiv
		{
			get{return _bLGoodsCdInpDiv;}
			set{_bLGoodsCdInpDiv = value;}
		}

		/// public propaty name  :  SupplierInpDiv
		/// <summary>�d������͋敪�v���p�e�B</summary>
		/// <value>0:�C�Ӂ@1:�K�{</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d������͋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierInpDiv
		{
			get{return _supplierInpDiv;}
			set{_supplierInpDiv = value;}
		}

		/// public propaty name  :  SupplierSlipDelDiv
		/// <summary>�d���`�[�폜�敪�v���p�e�B</summary>
		/// <value>0:���Ȃ��@1:�m�F�@2:����i����:���d�������v��̎d���`�[�𔄓`�폜���ɓ����폜�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���`�[�폜�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierSlipDelDiv
		{
			get{return _supplierSlipDelDiv;}
			set{_supplierSlipDelDiv = value;}
		}

		/// public propaty name  :  CustGuideDispDiv
		/// <summary>���Ӑ�K�C�h�����\���敪�v���p�e�B</summary>
		/// <value>1:�����_�̂ݕ\���@0:�S�ĕ\�� </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�K�C�h�����\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustGuideDispDiv
		{
			get{return _custGuideDispDiv;}
			set{_custGuideDispDiv = value;}
		}

		/// public propaty name  :  SlipChngDivDate
		/// <summary>�`�[�C���敪�i���t�j�v���p�e�B</summary>
		/// <value>0:�\�@1:�ԕi�`�[�ȊO�� 2:�ԕi�`�[�̂݉� 3:�s��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�C���敪�i���t�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipChngDivDate
		{
			get{return _slipChngDivDate;}
			set{_slipChngDivDate = value;}
		}

		/// public propaty name  :  SlipChngDivCost
		/// <summary>�`�[�C���敪�i�����j�v���p�e�B</summary>
		/// <value>0:�\�@1:�ԕi�`�[�ȊO�� 2:�ԕi�`�[�̂݉� 3:�s��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�C���敪�i�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipChngDivCost
		{
			get{return _slipChngDivCost;}
			set{_slipChngDivCost = value;}
		}

		/// public propaty name  :  SlipChngDivUnPrc
		/// <summary>�`�[�C���敪�i�����j�v���p�e�B</summary>
		/// <value>0:�\�@1:�ԕi�`�[�ȊO�� 2:�ԕi�`�[�̂݉� 3:�s��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�C���敪�i�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipChngDivUnPrc
		{
			get{return _slipChngDivUnPrc;}
			set{_slipChngDivUnPrc = value;}
		}

		/// public propaty name  :  SlipChngDivLPrice
		/// <summary>�`�[�C���敪�i�艿�j�v���p�e�B</summary>
		/// <value>0:�\�@1:�s�@2:�݌ɂ�����ꍇ�C���s�@�i�ԕi�`�[�ȊO�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�C���敪�i�艿�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipChngDivLPrice
		{
			get{return _slipChngDivLPrice;}
			set{_slipChngDivLPrice = value;}
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/09 G.Miyatsu ADD
        /// public propaty name  :  RetSlipChngDivCost
        /// <summary>�ԕi�`�[�C���敪�i�����j�v���p�e�B</summary>
        /// <value>0:�\�@1:�s�@2:���g�p�@3:�݌Ɏ��s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�C���敪�i�艿�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RetSlipChngDivCost
        {
            get { return _retSlipChngDivCost; }
            set { _retSlipChngDivCost = value; }
        }

        /// public propaty name  :  RetSlipChngDivUnPrc
        /// <summary>�ԕi�`�[�C���敪�i�����j�v���p�e�B</summary>
        /// <value>0:�\�@1:�s�@2:���g�p�@3:�݌Ɏ��s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�C���敪�i�艿�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RetSlipChngDivUnPrc
        {
            get { return _retSlipChngDivUnPrc; }
            set { _retSlipChngDivUnPrc = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/09 G.Miyatsu ADD

		/// public propaty name  :  AutoDepoKindCode
		/// <summary>������������R�[�h�v���p�e�B</summary>
		/// <value>�G���g���ł̎��������̋���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AutoDepoKindCode
		{
			get{return _autoDepoKindCode;}
			set{_autoDepoKindCode = value;}
		}

		/// public propaty name  :  AutoDepoKindName
		/// <summary>�����������햼�̃v���p�e�B</summary>
		/// <value>�G���g���ł̎��������̋���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����������햼�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AutoDepoKindName
		{
			get{return _autoDepoKindName;}
			set{_autoDepoKindName = value;}
		}

		/// public propaty name  :  AutoDepoKindDivCd
		/// <summary>������������敪�v���p�e�B</summary>
		/// <value>�G���g���ł̎��������̋���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AutoDepoKindDivCd
		{
			get{return _autoDepoKindDivCd;}
			set{_autoDepoKindDivCd = value;}
		}

		/// public propaty name  :  DiscountName
		/// <summary>�l�����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �l�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DiscountName
		{
			get{return _discountName;}
			set{_discountName = value;}
		}

		/// public propaty name  :  InpAgentDispDiv
		/// <summary>���s�ҕ\���敪�v���p�e�B</summary>
		/// <value>0:����@1:���Ȃ��@ 2:�K�{�@�i�����̏ꍇ�A��ʍ��ڂ��\��) </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���s�ҕ\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InpAgentDispDiv
		{
			get{return _inpAgentDispDiv;}
			set{_inpAgentDispDiv = value;}
		}

		/// public propaty name  :  CustOrderNoDispDiv
		/// <summary>���Ӑ撍�ԕ\���敪�v���p�e�B</summary>
		/// <value>0:���Ȃ��@1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ撍�ԕ\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustOrderNoDispDiv
		{
			get{return _custOrderNoDispDiv;}
			set{_custOrderNoDispDiv = value;}
		}

		/// public propaty name  :  CarMngNoDispDiv
		/// <summary>���q�Ǘ��ԍ��\���敪�v���p�e�B</summary>
		/// <value>0:���Ȃ��@1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���q�Ǘ��ԍ��\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CarMngNoDispDiv
		{
			get{return _carMngNoDispDiv;}
			set{_carMngNoDispDiv = value;}
		}

        // --- ADD 2009/10/19 ---------->>>>>
        /// public propaty name  :  PriceSelectDispDiv
        /// <summary>�\���敪�v���Z�X�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\���敪�v���Z�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceSelectDispDiv
        {
            get { return _priceSelectDispDiv; }
            set { _priceSelectDispDiv = value; }
        }
        // --- ADD 2009/10/19 ----------<<<<<

        // --- ADD 2010/01/29 ---------->>>>>
        /// public propaty name  :  AcpOdrInputDiv
        /// <summary>�󒍐����̓v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍐����̓v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcpOdrInputDiv
        {
            get { return _acpOdrInputDiv; }
            set { _acpOdrInputDiv = value; }
        }
        // --- ADD 2010/01/29 ----------<<<<<

        // --- ADD 2010/05/04 ---------->>>>>
        /// public propaty name  :  InpAgentChkDiv
        /// <summary>���s�҃`�F�b�N�敪�v���p�e�B</summary>
        /// <value>0:���� 1:�ē��� 2:�x��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�҃`�F�b�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InpAgentChkDiv
        {
            get { return _inpAgentChkDiv; }
            set { _inpAgentChkDiv = value; }
        }

        /// public propaty name  :  InpWarehChkDiv
        /// <summary>���͑q�Ƀ`�F�b�N�敪�v���p�e�B</summary>
        /// <value>0:���� 1:�ē��� 2:�x��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͑q�Ƀ`�F�b�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InpWarehChkDiv
        {
            get { return _inpWarehChkDiv; }
            set { _inpWarehChkDiv = value; }
        }
        // --- ADD 2010/05/04 ----------<<<<<

		/// public propaty name  :  BrSlipNote3DispDiv
		/// <summary>�`�[���l�R�\���敪�v���p�e�B</summary>
		/// <value>0:����@1:���Ȃ��@�i�����̏ꍇ�A��ʍ��ڂ��\��) </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[���l�R�\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BrSlipNote3DispDiv
		{
			get{return _brSlipNote3DispDiv;}
			set{_brSlipNote3DispDiv = value;}
		}

		/// public propaty name  :  SlipDateClrDivCd
		/// <summary>�`�[���t�N���A�敪�v���p�e�B</summary>
		/// <value>0:�V�X�e�����t 1:���͓��t</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[���t�N���A�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipDateClrDivCd
		{
			get{return _slipDateClrDivCd;}
			set{_slipDateClrDivCd = value;}
		}

		/// public propaty name  :  AutoEntryGoodsDivCd
		/// <summary>���i�����o�^�v���p�e�B</summary>
		/// <value>0:�Ȃ��@1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����o�^�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AutoEntryGoodsDivCd
		{
			get{return _autoEntryGoodsDivCd;}
			set{_autoEntryGoodsDivCd = value;}
		}

		/// public propaty name  :  CostCheckDivCd
		/// <summary>�����`�F�b�N�敪�v���p�e�B</summary>
		/// <value>0:�����@1:�ē��́@2:�x��MSG�@�i�艿���P���̏ꍇ�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����`�F�b�N�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CostCheckDivCd
		{
			get{return _costCheckDivCd;}
			set{_costCheckDivCd = value;}
		}

		/// public propaty name  :  JoinInitDispDiv
		/// <summary>���������\���敪�v���p�e�B</summary>
		/// <value>0:�\���� 1:�݌ɏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 JoinInitDispDiv
		{
			get{return _joinInitDispDiv;}
			set{_joinInitDispDiv = value;}
		}

		/// public propaty name  :  AutoDepositCd
		/// <summary>���������敪�v���p�e�B</summary>
		/// <value>0:���Ȃ�,1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AutoDepositCd
		{
			get{return _autoDepositCd;}
			set{_autoDepositCd = value;}
		}

		/// public propaty name  :  SubstCondDivCd
		/// <summary>��֏����敪�v���p�e�B</summary>
		/// <value>0:��ւ��Ȃ� 1:��ւ���(�݌ɖ�) 2:��ւ���i�݌ɖ����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��֏����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SubstCondDivCd
		{
			get{return _substCondDivCd;}
			set{_substCondDivCd = value;}
		}

		/// public propaty name  :  SlipCreateProcess
		/// <summary>�`�[�쐬���@�v���p�e�B</summary>
		/// <value>0:���͏� 1:�݌ɕ� 2:�q�ɕ� 3:�o�͐��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�[�쐬���@�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SlipCreateProcess
		{
			get{return _slipCreateProcess;}
			set{_slipCreateProcess = value;}
		}

		/// public propaty name  :  WarehouseChkDiv
		/// <summary>�q�Ƀ`�F�b�N�敪�v���p�e�B</summary>
		/// <value>0:�x���@1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�Ƀ`�F�b�N�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 WarehouseChkDiv
		{
			get{return _warehouseChkDiv;}
			set{_warehouseChkDiv = value;}
		}

		/// public propaty name  :  PartsSearchDivCd
		/// <summary>���i�����敪�v���p�e�B</summary>
		/// <value>0:���i����,1:�i�Ԍ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PartsSearchDivCd
		{
			get{return _partsSearchDivCd;}
			set{_partsSearchDivCd = value;}
		}

		/// public propaty name  :  GrsProfitDspCd
		/// <summary>�e���\���敪�v���p�e�B</summary>
		/// <value>0:���� 1:���Ȃ�,</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GrsProfitDspCd
		{
			get{return _grsProfitDspCd;}
			set{_grsProfitDspCd = value;}
		}

		/// public propaty name  :  PartsSearchPriDivCd
		/// <summary>���i�����D�揇�敪�v���p�e�B</summary>
		/// <value>0:�����@1:�D��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�����D�揇�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PartsSearchPriDivCd
		{
			get{return _partsSearchPriDivCd;}
			set{_partsSearchPriDivCd = value;}
		}

		/// public propaty name  :  SalesStockDiv
		/// <summary>����d���敪�v���p�e�B</summary>
		/// <value>0:���Ȃ��@1:����@2:�K�{����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����d���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesStockDiv
		{
			get{return _salesStockDiv;}
			set{_salesStockDiv = value;}
		}

		/// public propaty name  :  PrtBLGoodsCodeDiv
		/// <summary>����pBL���i�R�[�h�敪�v���p�e�B</summary>
		/// <value>0:���i,1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����pBL���i�R�[�h�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrtBLGoodsCodeDiv
		{
			get{return _prtBLGoodsCodeDiv;}
			set{_prtBLGoodsCodeDiv = value;}
		}

		/// public propaty name  :  SectDspDivCd
		/// <summary>���_�\���敪�v���p�e�B</summary>
		/// <value>0:�W���@1:�����_�@2:�\�������@���W���� ���Ӑ�̊Ǘ����_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SectDspDivCd
		{
			get{return _sectDspDivCd;}
			set{_sectDspDivCd = value;}
		}

		/// public propaty name  :  GoodsNmReDispDivCd
		/// <summary>���i���ĕ\���敪�v���p�e�B</summary>
		/// <value>0:���Ȃ��@1:���� ��BL���ޕύX����BL���̂ŏ㏑��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���ĕ\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsNmReDispDivCd
		{
			get{return _goodsNmReDispDivCd;}
			set{_goodsNmReDispDivCd = value;}
		}

		/// public propaty name  :  CostDspDivCd
		/// <summary>�����\���敪�v���p�e�B</summary>
		/// <value>0:���Ȃ� 1:����@</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����\���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CostDspDivCd
		{
			get{return _costDspDivCd;}
			set{_costDspDivCd = value;}
		}

		/// public propaty name  :  DepoSlipDateClrDiv
		/// <summary>�����`�[���t�N���A�敪�v���p�e�B</summary>
		/// <value>0:�V�X�e�����t 1:���͓��t</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����`�[���t�N���A�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DepoSlipDateClrDiv
		{
			get{return _depoSlipDateClrDiv;}
			set{_depoSlipDateClrDiv = value;}
		}

		/// public propaty name  :  DepoSlipDateAmbit
		/// <summary>�����`�[���t�͈͋敪�v���p�e�B</summary>
		/// <value>0:�����Ȃ� 1:�V�X�e�����t�ȍ~���͕s��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����`�[���t�͈͋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DepoSlipDateAmbit
		{
			get{return _depoSlipDateAmbit;}
			set{_depoSlipDateAmbit = value;}
		}

		/// public propaty name  :  InpGrsProfChkLower
		/// <summary>���͑e���`�F�b�N�����v���p�e�B</summary>
		/// <value>���͑e���`�F�b�N�̉����l�i���œ��́j�@XX.X���@�ȏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͑e���`�F�b�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double InpGrsProfChkLower
		{
			get{return _inpGrsProfChkLower;}
			set{_inpGrsProfChkLower = value;}
		}

		/// public propaty name  :  InpGrsProfChkUpper
		/// <summary>���͑e���`�F�b�N����v���p�e�B</summary>
		/// <value>���͑e���`�F�b�N�̏���l�i���œ��́j�@XX.X���@����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͑e���`�F�b�N����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double InpGrsProfChkUpper
		{
			get{return _inpGrsProfChkUpper;}
			set{_inpGrsProfChkUpper = value;}
		}

		/// public propaty name  :  InpGrsPrfChkLowDiv
		/// <summary>���͑e���`�F�b�N�����敪�v���p�e�B</summary>
		/// <value>0:�ē���,1:�x��,2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͑e���`�F�b�N�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InpGrsPrfChkLowDiv
		{
			get{return _inpGrsPrfChkLowDiv;}
			set{_inpGrsPrfChkLowDiv = value;}
		}

		/// public propaty name  :  InpGrsPrfChkUppDiv
		/// <summary>���͑e���`�F�b�N����敪�v���p�e�B</summary>
		/// <value>0:�ē���,1:�x��,2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͑e���`�F�b�N����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InpGrsPrfChkUppDiv
		{
			get{return _inpGrsPrfChkUppDiv;}
			set{_inpGrsPrfChkUppDiv = value;}
		}

		/// public propaty name  :  PrmSubstCondDivCd
		/// <summary>�D�Ǒ�֏����敪�v���p�e�B</summary>
		/// <value>0:��ւ��Ȃ� 1:��ւ���(�݌ɖ�) 2:��ւ���i�݌ɖ����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �D�Ǒ�֏����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrmSubstCondDivCd
		{
			get{return _prmSubstCondDivCd;}
			set{_prmSubstCondDivCd = value;}
		}

		/// public propaty name  :  SubstApplyDivCd
		/// <summary>��֓K�p�敪�v���p�e�B</summary>
		/// <value>0:���Ȃ�, 1:����(�����A�Z�b�g), 2:�S�āi�����A�Z�b�g�A�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��֓K�p�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SubstApplyDivCd
		{
			get{return _substApplyDivCd;}
			set{_substApplyDivCd = value;}
		}

        /// public propaty name  :  PartsNameDspDivCd
        /// <summary>�i���\���敪�v���p�e�B</summary>
        /// <value>0:���i�D��, 1:�񋟗D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i���\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsNameDspDivCd
        {
            get { return _partsNameDspDivCd; }
            set { _partsNameDspDivCd = value; }
        }

        // --- ADD 2010/04/30-------------------------------->>>>>
        /// public propaty name  :  FrSrchPrtAutoEntDiv
        /// <summary>���R�������i�����o�^�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:���� </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���R�������i�����o�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FrSrchPrtAutoEntDiv
        {
            get { return _frSrchPrtAutoEntDiv; }
            set { _frSrchPrtAutoEntDiv = value; }
        }
        // --- ADD 2010/04/30 --------------------------------<<<<<


        /// public propaty name  :  BLGoodsCdDerivNoDiv
        /// <summary>BL�R�[�h�}�ԋ敪�v���p�e�B</summary>
        /// <value>0:�}�ԂȂ�, 1:�}�Ԃ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�}�ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCdDerivNoDiv
        {
            get { return _bLGoodsCdDerivNoDiv; }
            set { _bLGoodsCdDerivNoDiv = value; }
        }

        // 2010/05/14 Add >>>
        /// public propaty name  :  BLCdPrtsNmDspDivCd1
        /// <summary>BL�R�[�h�����i���\���敪�P�v���p�e�B</summary>
        /// <value>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�����i���\���敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLCdPrtsNmDspDivCd1
        {
            get { return _bLCdPrtsNmDspDivCd1; }
            set { _bLCdPrtsNmDspDivCd1 = value; }
        }

        /// public propaty name  :  BLCdPrtsNmDspDivCd2
        /// <summary>BL�R�[�h�����i���\���敪�Q�v���p�e�B</summary>
        /// <value>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�����i���\���敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLCdPrtsNmDspDivCd2
        {
            get { return _bLCdPrtsNmDspDivCd2; }
            set { _bLCdPrtsNmDspDivCd2 = value; }
        }

        /// public propaty name  :  BLCdPrtsNmDspDivCd3
        /// <summary>BL�R�[�h�����i���\���敪�R�v���p�e�B</summary>
        /// <value>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�����i���\���敪�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLCdPrtsNmDspDivCd3
        {
            get { return _bLCdPrtsNmDspDivCd3; }
            set { _bLCdPrtsNmDspDivCd3 = value; }
        }

        /// public propaty name  :  BLCdPrtsNmDspDivCd4
        /// <summary>BL�R�[�h�����i���\���敪�S�v���p�e�B</summary>
        /// <value>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�����i���\���敪�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLCdPrtsNmDspDivCd4
        {
            get { return _bLCdPrtsNmDspDivCd4; }
            set { _bLCdPrtsNmDspDivCd4 = value; }
        }

        /// public propaty name  :  GdNoPrtsNmDspDivCd1
        /// <summary>�i�Ԍ����i���\���敪�P�v���p�e�B</summary>
        /// <value>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԍ����i���\���敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GdNoPrtsNmDspDivCd1
        {
            get { return _gdNoPrtsNmDspDivCd1; }
            set { _gdNoPrtsNmDspDivCd1 = value; }
        }

        /// public propaty name  :  GdNoPrtsNmDspDivCd2
        /// <summary>�i�Ԍ����i���\���敪�Q�v���p�e�B</summary>
        /// <value>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԍ����i���\���敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GdNoPrtsNmDspDivCd2
        {
            get { return _gdNoPrtsNmDspDivCd2; }
            set { _gdNoPrtsNmDspDivCd2 = value; }
        }

        /// public propaty name  :  GdNoPrtsNmDspDivCd3
        /// <summary>�i�Ԍ����i���\���敪�R�v���p�e�B</summary>
        /// <value>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԍ����i���\���敪�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GdNoPrtsNmDspDivCd3
        {
            get { return _gdNoPrtsNmDspDivCd3; }
            set { _gdNoPrtsNmDspDivCd3 = value; }
        }

        /// public propaty name  :  GdNoPrtsNmDspDivCd4
        /// <summary>�i�Ԍ����i���\���敪�S�v���p�e�B</summary>
        /// <value>0:�����@1:���i�}�X�^�@2:���i�}�X�^�@3:�����i���}�X�^�@4:BL�R�[�h�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԍ����i���\���敪�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GdNoPrtsNmDspDivCd4
        {
            get { return _gdNoPrtsNmDspDivCd4; }
            set { _gdNoPrtsNmDspDivCd4 = value; }
        }

        /// public propaty name  :  PrmPrtsNmUseDivCd
        /// <summary>�D�Ǖ��i�����i���g�p�敪�v���p�e�B</summary>
        /// <value>0:�g�p 1:���g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�Ǖ��i�����i���g�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmPrtsNmUseDivCd
        {
            get { return _prmPrtsNmUseDivCd; }
            set { _prmPrtsNmUseDivCd = value; }
        }
        // 2010/05/14 Add <<<

        // --- ADD 2010/08/04 ---------->>>>>
        /// public propaty name  :  DwnPLCdSpDivCd
        /// <summary>�����_�\���敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����_�\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DwnPLCdSpDivCd
        {
            get { return _dwnPLCdSpDivCd; }
            set { _dwnPLCdSpDivCd = value; }
        }
        // --- ADD 2010/08/04 ----------<<<<<

        // --- ADD 2011/06/06 ---------->>>>>
        /// public propaty name  :  SalesCdDspDivCd
        /// <summary>�̔��敪�\���敪�v���p�e�B</summary>
        /// <value>0:����, 1:���Ȃ�, 2:�K�{</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCdDspDivCd
        {
            get { return _salesCdDspDivCd; }
            set { _salesCdDspDivCd = value; }
        }
        // --- ADD 2011/06/06 ----------<<<<<

        // --- ADD 2012/04/13 ---------->>>>>
        /// public propaty name  :  RentStockDiv
        /// <summary>�ݏo�d���敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�, 1:����, 2:�K�{����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݏo�d���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RentStockDiv
        {
            get { return _rentStockDiv; }
            set { _rentStockDiv = value; }
        }
        // --- ADD 2012/04/13 ----------<<<<<

        // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
        /// public propaty name  :  EpPartsNoPrtCd
        /// <summary>���Еi�Ԉ󎚋敪�v���p�e�B</summary>
        /// <value>0:���Ȃ�, 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Еi�Ԉ󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EpPartsNoPrtCd
        {
            get { return _EpPartsNoPrtCd; }
            set { _EpPartsNoPrtCd = value; }
        }

        /// public propaty name  :  EpPartsNoAddChar
        /// <summary>���Еi�ԕt�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Еi�ԕt�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String EpPartsNoAddChar
        {
            get { return _EpPartsNoAddChar; }
            set { _EpPartsNoAddChar = value; }
        }
        // --- ADD 2012/12/27 Y.Wakita ----------<<<<<

        // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
        /// public propaty name  :  PrintGoodsNoDef
        /// <summary>�󎚕i�ԏ����l�v���p�e�B</summary>
        /// <value>0:�D��, 1:����, 2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󎚕i�ԏ����l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintGoodsNoDef
        {
            get { return _PrintGoodsNoDef; }
            set { _PrintGoodsNoDef = value; }
        }
        // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
		
		// --- ADD 2013/01/15 ---------->>>>>
        /// public propaty name  :  StockRetGoodsPlnDiv
        /// <summary>�d���ԕi�\��@�\�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���ԕi�\��@�\�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockRetGoodsPlnDiv
        {
            get { return _stockRetGoodsPlnDiv; }
            set { _stockRetGoodsPlnDiv = value; }
        }
        // --- ADD 2013/01/15 ----------<<<<<

        // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
        /// public propaty name  :  AutoDepositNoteDiv
        /// <summary>�����������l�敪�v���p�e�B</summary>
        /// <value>0:����`�[�ԍ� 1:����`�[���l 2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������l�敪�v���p�e�B</br>
        /// <br>Programer        :   cheq</br>
        /// </remarks>
        public Int32 AutoDepositNoteDiv
        {
            get { return _autoDepositNoteDiv; }
            set { _autoDepositNoteDiv = value; }
        }
        // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<

        // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
        /// public propaty name  :  BLGoodsCdZeroSuprt
        /// <summary>BL�R�[�h�O�Ή��v���p�e�B</summary>
        /// <value>0:���Ȃ�, 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�O�Ή��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCdZeroSuprt
        {
            get { return _BLGoodsCdZeroSuprt; }
            set { _BLGoodsCdZeroSuprt = value; }
        }

        /// public propaty name  :  BLGoodsCdChange
        /// <summary>�ϊ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϊ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCdChange
        {
            get { return _BLGoodsCdChange; }
            set { _BLGoodsCdChange = value; }
        }
        // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

        // --- ADD 2017/04/13 杍^ Redmine#49283---------->>>>>
        /// public propaty name  :  StockEmpRefDivRF
        /// <summary>�d���S���Q�Ƌ敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���Q�Ƌ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockEmpRefDiv
        {
            get { return _stockEmpRefDiv; }
            set { _stockEmpRefDiv = value; }
        }
        // --- ADD 2017/04/13 杍^ Redmine#49283----------<<<<<

        /// <summary>
		/// ����S�̐ݒ胏�[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SalesTtlStWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesTtlStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesTtlStWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalesTtlStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalesTtlStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalesTtlStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesTtlStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2009/10/19 ��r�� �\���敪�v���Z�X��ǉ�</br>
        /// <br>Update Note      :   2010/01/29 ���� �󒍐����͂�ǉ�</br>
        /// <br>Update Note      :   2010/04/30 �I�M ���R�������i�����o�^�敪��ǉ�</br>        
        /// <br>Update Note      :   2010/05/04 ���C�� ���s�҃`�F�b�N�敪�A���͑q�Ƀ`�F�b�N�敪��ǉ�</br>
        /// <br>Update Note      :   2010/08/04 �k���r �����_�\���敪��ǉ�</br>
        /// <br>Update Note      :   2011/06/06 �������n �����_�\���敪��ǉ�</br>
        /// <br>Update Note      :   2012/04/13 ���c�N�v �ݏo�d���敪��ǉ�</br>
        /// <br>Update Note      :   2013/01/21 cheq</br>   
        /// <br>�Ǘ��ԍ�         :   10806793-00 2013/03/13�z�M��</br>
        /// <br>                     Redmine#33797 �����������l�敪��ǉ�</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesTtlStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesTtlStWork || graph is ArrayList || graph is SalesTtlStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalesTtlStWork).FullName));

            if (graph != null && graph is SalesTtlStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesTtlStWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesTtlStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesTtlStWork[])graph).Length;
            }
            else if (graph is SalesTtlStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //����`�[���s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipPrtDiv
            //�o�ד`�[���s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmSlipPrtDiv
            //�o�ד`�[�P������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmSlipUnPrcPrtDiv
            //�e���`�F�b�N����
            serInfo.MemberInfo.Add(typeof(Double)); //GrsProfitCheckLower
            //�e���`�F�b�N�K��
            serInfo.MemberInfo.Add(typeof(Double)); //GrsProfitCheckBest
            //�e���`�F�b�N���
            serInfo.MemberInfo.Add(typeof(Double)); //GrsProfitCheckUpper
            //�e���`�F�b�N�����L��
            serInfo.MemberInfo.Add(typeof(string)); //GrsProfitChkLowSign
            //�e���`�F�b�N�K���L��
            serInfo.MemberInfo.Add(typeof(string)); //GrsProfitChkBestSign
            //�e���`�F�b�N����L��
            serInfo.MemberInfo.Add(typeof(string)); //GrsProfitChkUprSign
            //�e���`�F�b�N�ő�L��
            serInfo.MemberInfo.Add(typeof(string)); //GrsProfitChkMaxSign
            //����S���ύX�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAgentChngDiv
            //�󒍎ҕ\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcpOdrAgentDispDiv
            //�`�[���l�Q�\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //BrSlipNote2DispDiv
            //���ה��l�\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlNoteDispDiv
            //�������ݒ莞�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcNonSettingDiv
            //���σf�[�^�v��c�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EstmateAddUpRemDiv
            //�󒍃f�[�^�v��c�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AcpOdrrAddUpRemDiv
            //�o�׃f�[�^�v��c�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmAddUpRemDiv
            //�ԕi���݌ɓo�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RetGoodsStockEtyDiv
            //�艿�I���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPriceSelectDiv
            //���[�J�[���͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerInpDiv
            //BL���i�R�[�h���͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCdInpDiv
            //�d������͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierInpDiv
            //�d���`�[�폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipDelDiv
            //���Ӑ�K�C�h�����\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CustGuideDispDiv
            //�`�[�C���敪�i���t�j
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipChngDivDate
            //�`�[�C���敪�i�����j
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipChngDivCost
            //�`�[�C���敪�i�����j
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipChngDivUnPrc
            //�`�[�C���敪�i�艿�j
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipChngDivLPrice
            //�ԕi�`�[�C���敪�i�����j
            serInfo.MemberInfo.Add(typeof(Int32)); //RetSlipChngDivCost
            //�ԕi�`�[�C���敪�i�����j
            serInfo.MemberInfo.Add(typeof(Int32)); //RetSlipChngDivUnPrc
            //������������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepoKindCode
            //�����������햼��
            serInfo.MemberInfo.Add(typeof(string)); //AutoDepoKindName
            //������������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepoKindDivCd
            //�l������
            serInfo.MemberInfo.Add(typeof(string)); //DiscountName
            //���s�ҕ\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InpAgentDispDiv
            //���Ӑ撍�ԕ\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CustOrderNoDispDiv
            //���q�Ǘ��ԍ��\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CarMngNoDispDiv
            // --- ADD 2009/10/19 ---------->>>>>
            // �\���敪�v���Z�X
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceSelectDispDiv
            // --- ADD 2009/10/19 ----------<<<<<
            // --- ADD 2010/01/29 ---------->>>>>
            // �󒍐�����
            serInfo.MemberInfo.Add(typeof(Int32)); //AcpOdrInputDiv
            // --- ADD 2010/01/29 ----------<<<<<
            // --- ADD 2010/05/04 ---------->>>>>
            //���s�҃`�F�b�N�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InpAgentChkDiv
            //���͑q�Ƀ`�F�b�N�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InpWarehChkDiv
            // --- ADD 2010/05/04 ----------<<<<<
            //�`�[���l�R�\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //BrSlipNote3DispDiv
            //�`�[���t�N���A�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipDateClrDivCd
            //���i�����o�^
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoEntryGoodsDivCd
            //�����`�F�b�N�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CostCheckDivCd
            //���������\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinInitDispDiv
            //���������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepositCd
            //��֏����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SubstCondDivCd
            //�`�[�쐬���@
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipCreateProcess
            //�q�Ƀ`�F�b�N�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //WarehouseChkDiv
            //���i�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsSearchDivCd
            //�e���\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GrsProfitDspCd
            //���i�����D�揇�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsSearchPriDivCd
            //����d���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesStockDiv
            //����pBL���i�R�[�h�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtBLGoodsCodeDiv
            //���_�\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SectDspDivCd
            //���i���ĕ\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNmReDispDivCd
            //�����\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CostDspDivCd
            //�����`�[���t�N���A�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DepoSlipDateClrDiv
            //�����`�[���t�͈͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DepoSlipDateAmbit
            //���͑e���`�F�b�N����
            serInfo.MemberInfo.Add(typeof(Double)); //InpGrsProfChkLower
            //���͑e���`�F�b�N���
            serInfo.MemberInfo.Add(typeof(Double)); //InpGrsProfChkUpper
            //���͑e���`�F�b�N�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InpGrsPrfChkLowDiv
            //���͑e���`�F�b�N����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //InpGrsPrfChkUppDiv
            //�D�Ǒ�֏����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSubstCondDivCd
            //��֓K�p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SubstApplyDivCd
            //�i���\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsNameDspDivCd
            //BL�R�[�h�}�ԋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCdDerivNoDiv
            // --- ADD 2010/04/30-------------------------------->>>>>
            //���R�������i�����o�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //FrSrchPrtAutoEntDiv
            // --- ADD 2010/04/30 --------------------------------<<<<<

            // 2010/05/14 Add >>>
            //BL�R�[�h�����i���\���敪�P
            serInfo.MemberInfo.Add(typeof(Int32)); //BLCdPrtsNmDspDivCd1
            //BL�R�[�h�����i���\���敪�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //BLCdPrtsNmDspDivCd2
            //BL�R�[�h�����i���\���敪�R
            serInfo.MemberInfo.Add(typeof(Int32)); //BLCdPrtsNmDspDivCd3
            //BL�R�[�h�����i���\���敪�S
            serInfo.MemberInfo.Add(typeof(Int32)); //BLCdPrtsNmDspDivCd4
            //�i�Ԍ����i���\���敪�P
            serInfo.MemberInfo.Add(typeof(Int32)); //GdNoPrtsNmDspDivCd1
            //�i�Ԍ����i���\���敪�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //GdNoPrtsNmDspDivCd2
            //�i�Ԍ����i���\���敪�R
            serInfo.MemberInfo.Add(typeof(Int32)); //GdNoPrtsNmDspDivCd3
            //�i�Ԍ����i���\���敪�S
            serInfo.MemberInfo.Add(typeof(Int32)); //GdNoPrtsNmDspDivCd4
            //�D�Ǖ��i�����i���g�p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmPrtsNmUseDivCd
            // 2010/05/14 Add <<<

            // --- ADD 2010/08/04 ---------->>>>>
            // �����_�\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DwnPLCdSpDivCd
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/06 ---------->>>>>
            // �̔��敪�\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCdDspDivCd
            // --- ADD 2011/06/06 ----------<<<<<
            // --- ADD 2012/04/13 ---------->>>>>
            // �ݏo�d���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RentStockDiv
            // --- ADD 2012/04/13 ----------<<<<<
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // ���Еi�Ԉ󎚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //EpPartsNoPrtCd
            // ���Еi�ԕt������
            serInfo.MemberInfo.Add(typeof(String)); //EpPartsNoAddChar
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            // �󎚕i�ԏ����l
            serInfo.MemberInfo.Add(typeof(Int32)); //PrintGoodsNoDef
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
			// --- ADD 2013/01/15 ---------->>>>>
            // �d���ԕi�\��@�\�敪
            serInfo.MemberInfo.Add(typeof(Int32));
            // --- ADD 2013/01/15 ----------<<<<<
            // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
            // �����������l�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepositNoteDiv
            // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            // BL�R�[�h�O�Ή�
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCdZeroSuprt
            // �ϊ��R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCdChange
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

            // --- ADD 2017/04/13 杍^ Redmine#49283---------->>>>>
            // �d���S���Q�Ƌ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockEmpRefDiv
            // --- ADD 2017/04/13 杍^ Redmine#49283----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SalesTtlStWork)
            {
                SalesTtlStWork temp = (SalesTtlStWork)graph;

                SetSalesTtlStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesTtlStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesTtlStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesTtlStWork temp in lst)
                {
                    SetSalesTtlStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesTtlStWork�����o��(public�v���p�e�B��)
        /// </summary>
        // --- UPD 2010/01/29 ---------->>>>>
        //private const int currentMemberCount = 75;
        //private const int currentMemberCount = 76;
        // --- UPD 2010/05/04 ---------->>>>>
        // --- UPD 2010/04/30 ---------->>>>>
        // private const int currentMemberCount = 78;
        // 2010/05/14 >>>
        //private const int currentMemberCount = 79;

        // --- UPD 2013/01/16 Y.Wakita ---------->>>>>
        //// --- UPD 2012/12/27 Y.Wakita ---------->>>>>
        ////// -- UPD 2012/04/13 ------------------>>>
        ////// -- UPD 2011/06/06 ------------------>>>
        //////// --- UPD 2010/08/04 ---------->>>>>
        ////////private const int currentMemberCount = 88;
        //////private const int currentMemberCount = 89;  
        //////// --- UPD 2010/08/04 ----------<<<<<
        //////private const int currentMemberCount = 90;
        ////// -- UPD 2011/06/06 ------------------<<<
        ////private const int currentMemberCount = 91;
        ////// -- UPD 2012/04/13 ------------------<<<
        //private const int currentMemberCount = 93;
        //// --- UPD 2012/12/27 Y.Wakita ----------<<<<<
        //private const int currentMemberCount = 94;
        // --- UPD 2013/01/16 Y.Wakita ----------<<<<<
		// --- UPD 2013/01/18 ---------->>>>>
		//private const int currentMemberCount = 95; // DEL cheq 2013/01/21 Redmine#33797 
        //private const int currentMemberCount = 96; // ADD cheq 2013/01/21 Redmine#33797 DEL 2013/02/05 Y.Wakita
        //private const int currentMemberCount = 98; // ADD 2013/02/05 Y.Wakita // DEL 2017/04/13 杍^ Redmine#49283
        private const int currentMemberCount = 99; // ADD 2017/04/13 杍^ Redmine#49283
        // --- UPD 2013/01/18 ----------<<<<<
        // 2010/05/14 <<<
        // --- UPD 2010/04/30 ----------<<<<<

		// --- UPD 2010/05/04 ----------<<<<<
        // --- UPD 2010/01/29 ----------<<<<<

        /// <summary>
        ///  SalesTtlStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesTtlStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2009/10/19 ��r�� �\���敪�v���Z�X��ǉ�</br>
        /// <br>Update Note      :   2010/01/29 ���� �󒍐����͂�ǉ�</br>
        /// <br>Update Note      :   2010/04/30 �I�M ���R�������i�����o�^�敪��ǉ�</br>        
        /// <br>Update Note      :   2010/05/04 ���C�� ���s�҃`�F�b�N�敪�A���͑q�Ƀ`�F�b�N�敪��ǉ�</br>
        /// <br>Update Note      :   2010/08/04 �k���r �����_�\���敪��ǉ�</br>
        /// <br>Update Note      :   2011/06/06 �������n �̔��敪�\���敪��ǉ�</br>
        /// <br>Update Note      :   2012/04/13 ���c�N�v �ݏo�d���敪��ǉ�</br>
        /// <br>Update Note      :   2013/01/21 cheq</br>
        /// <br>�Ǘ��ԍ�         :   10806793-00 2013/03/13�z�M��</br>
        /// <br>                     Redmine#33797 �����������l�敪��ǉ�</br>
        /// </remarks>
        private void SetSalesTtlStWork(System.IO.BinaryWriter writer, SalesTtlStWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //����`�[���s�敪
            writer.Write(temp.SalesSlipPrtDiv);
            //�o�ד`�[���s�敪
            writer.Write(temp.ShipmSlipPrtDiv);
            //�o�ד`�[�P������敪
            writer.Write(temp.ShipmSlipUnPrcPrtDiv);
            //�e���`�F�b�N����
            writer.Write(temp.GrsProfitCheckLower);
            //�e���`�F�b�N�K��
            writer.Write(temp.GrsProfitCheckBest);
            //�e���`�F�b�N���
            writer.Write(temp.GrsProfitCheckUpper);
            //�e���`�F�b�N�����L��
            writer.Write(temp.GrsProfitChkLowSign);
            //�e���`�F�b�N�K���L��
            writer.Write(temp.GrsProfitChkBestSign);
            //�e���`�F�b�N����L��
            writer.Write(temp.GrsProfitChkUprSign);
            //�e���`�F�b�N�ő�L��
            writer.Write(temp.GrsProfitChkMaxSign);
            //����S���ύX�敪
            writer.Write(temp.SalesAgentChngDiv);
            //�󒍎ҕ\���敪
            writer.Write(temp.AcpOdrAgentDispDiv);
            //�`�[���l�Q�\���敪
            writer.Write(temp.BrSlipNote2DispDiv);
            //���ה��l�\���敪
            writer.Write(temp.DtlNoteDispDiv);
            //�������ݒ莞�敪
            writer.Write(temp.UnPrcNonSettingDiv);
            //���σf�[�^�v��c�敪
            writer.Write(temp.EstmateAddUpRemDiv);
            //�󒍃f�[�^�v��c�敪
            writer.Write(temp.AcpOdrrAddUpRemDiv);
            //�o�׃f�[�^�v��c�敪
            writer.Write(temp.ShipmAddUpRemDiv);
            //�ԕi���݌ɓo�^�敪
            writer.Write(temp.RetGoodsStockEtyDiv);
            //�艿�I���敪
            writer.Write(temp.ListPriceSelectDiv);
            //���[�J�[���͋敪
            writer.Write(temp.MakerInpDiv);
            //BL���i�R�[�h���͋敪
            writer.Write(temp.BLGoodsCdInpDiv);
            //�d������͋敪
            writer.Write(temp.SupplierInpDiv);
            //�d���`�[�폜�敪
            writer.Write(temp.SupplierSlipDelDiv);
            //���Ӑ�K�C�h�����\���敪
            writer.Write(temp.CustGuideDispDiv);
            //�`�[�C���敪�i���t�j
            writer.Write(temp.SlipChngDivDate);
            //�`�[�C���敪�i�����j
            writer.Write(temp.SlipChngDivCost);
            //�`�[�C���敪�i�����j
            writer.Write(temp.SlipChngDivUnPrc);
            //�`�[�C���敪�i�艿�j
            writer.Write(temp.SlipChngDivLPrice);
            //�ԕi�`�[�C���敪�i�����j
            writer.Write(temp.RetSlipChngDivCost);
            //�ԕi�`�[�C���敪�i�����j
            writer.Write(temp.RetSlipChngDivUnPrc);
            //������������R�[�h
            writer.Write(temp.AutoDepoKindCode);
            //�����������햼��
            writer.Write(temp.AutoDepoKindName);
            //������������敪
            writer.Write(temp.AutoDepoKindDivCd);
            //�l������
            writer.Write(temp.DiscountName);
            //���s�ҕ\���敪
            writer.Write(temp.InpAgentDispDiv);
            //���Ӑ撍�ԕ\���敪
            writer.Write(temp.CustOrderNoDispDiv);
            //���q�Ǘ��ԍ��\���敪
            writer.Write(temp.CarMngNoDispDiv);
            // --- ADD 2009/10/19 ---------->>>>>
            // �\���敪�v���Z�X
            writer.Write(temp.PriceSelectDispDiv);
            // --- ADD 2009/10/19 ----------<<<<<
            // --- ADD 2010/01/29 ---------->>>>>
            // �󒍐�����
            writer.Write(temp.AcpOdrInputDiv);
            // --- ADD 2010/01/29 ----------<<<<<
            // --- ADD 2010/05/04 ---------->>>>>
            //���s�҃`�F�b�N�敪
            writer.Write(temp.InpAgentChkDiv);
            //���͑q�Ƀ`�F�b�N�敪
            writer.Write(temp.InpWarehChkDiv);
            // --- ADD 2010/05/04 ----------<<<<<
            //�`�[���l�R�\���敪
            writer.Write(temp.BrSlipNote3DispDiv);
            //�`�[���t�N���A�敪
            writer.Write(temp.SlipDateClrDivCd);
            //���i�����o�^
            writer.Write(temp.AutoEntryGoodsDivCd);
            //�����`�F�b�N�敪
            writer.Write(temp.CostCheckDivCd);
            //���������\���敪
            writer.Write(temp.JoinInitDispDiv);
            //���������敪
            writer.Write(temp.AutoDepositCd);
            //��֏����敪
            writer.Write(temp.SubstCondDivCd);
            //�`�[�쐬���@
            writer.Write(temp.SlipCreateProcess);
            //�q�Ƀ`�F�b�N�敪
            writer.Write(temp.WarehouseChkDiv);
            //���i�����敪
            writer.Write(temp.PartsSearchDivCd);
            //�e���\���敪
            writer.Write(temp.GrsProfitDspCd);
            //���i�����D�揇�敪
            writer.Write(temp.PartsSearchPriDivCd);
            //����d���敪
            writer.Write(temp.SalesStockDiv);
            //����pBL���i�R�[�h�敪
            writer.Write(temp.PrtBLGoodsCodeDiv);
            //���_�\���敪
            writer.Write(temp.SectDspDivCd);
            //���i���ĕ\���敪
            writer.Write(temp.GoodsNmReDispDivCd);
            //�����\���敪
            writer.Write(temp.CostDspDivCd);
            //�����`�[���t�N���A�敪
            writer.Write(temp.DepoSlipDateClrDiv);
            //�����`�[���t�͈͋敪
            writer.Write(temp.DepoSlipDateAmbit);
            //���͑e���`�F�b�N����
            writer.Write(temp.InpGrsProfChkLower);
            //���͑e���`�F�b�N���
            writer.Write(temp.InpGrsProfChkUpper);
            //���͑e���`�F�b�N�����敪
            writer.Write(temp.InpGrsPrfChkLowDiv);
            //���͑e���`�F�b�N����敪
            writer.Write(temp.InpGrsPrfChkUppDiv);
            //�D�Ǒ�֏����敪
            writer.Write(temp.PrmSubstCondDivCd);
            //��֓K�p�敪
            writer.Write(temp.SubstApplyDivCd);
            //�i���\���敪
            writer.Write(temp.PartsNameDspDivCd);
            //BL�R�[�h�}�ԋ敪
            writer.Write(temp.BLGoodsCdDerivNoDiv);
            // --- ADD 2010/04/30-------------------------------->>>>>
            //���R�������i�����o�^�敪
            writer.Write(temp.FrSrchPrtAutoEntDiv);
            // --- ADD 2010/04/30 --------------------------------<<<<<

            // 2010/05/14 Add >>>
            //BL�R�[�h�����i���\���敪�P
            writer.Write(temp.BLCdPrtsNmDspDivCd1);
            //BL�R�[�h�����i���\���敪�Q
            writer.Write(temp.BLCdPrtsNmDspDivCd2);
            //BL�R�[�h�����i���\���敪�R
            writer.Write(temp.BLCdPrtsNmDspDivCd3);
            //BL�R�[�h�����i���\���敪�S
            writer.Write(temp.BLCdPrtsNmDspDivCd4);
            //�i�Ԍ����i���\���敪�P
            writer.Write(temp.GdNoPrtsNmDspDivCd1);
            //�i�Ԍ����i���\���敪�Q
            writer.Write(temp.GdNoPrtsNmDspDivCd2);
            //�i�Ԍ����i���\���敪�R
            writer.Write(temp.GdNoPrtsNmDspDivCd3);
            //�i�Ԍ����i���\���敪�S
            writer.Write(temp.GdNoPrtsNmDspDivCd4);
            //�D�Ǖ��i�����i���g�p�敪
            writer.Write(temp.PrmPrtsNmUseDivCd);
            // 2010/05/14 Add <<<

            // --- ADD 2010/08/04 ---------->>>>>
            // �����_�\���敪
            writer.Write(temp.DwnPLCdSpDivCd);
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/06 ---------->>>>>
            // �̔��敪�\���敪
            writer.Write(temp.SalesCdDspDivCd);
            // --- ADD 2011/06/06 ----------<<<<<
            // --- ADD 2012/04/13 ---------->>>>>
            // �ݏo�d���敪
            writer.Write(temp.RentStockDiv);
            // --- ADD 2012/04/13 ----------<<<<< 
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            // ���Еi�Ԉ󎚋敪
            writer.Write(temp.EpPartsNoPrtCd);
            // ���Еi�ԕt������
            writer.Write(temp.EpPartsNoAddChar);
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            // �󎚕i�ԏ����l
            writer.Write(temp.PrintGoodsNoDef);
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/15 ---------->>>>>
            // �d���ԕi�\��@�\�敪
            writer.Write(temp.StockRetGoodsPlnDiv);
            // --- ADD 2013/01/15 ----------<<<<<
            // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
            // �����������l�敪
            writer.Write(temp.AutoDepositNoteDiv);
            // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<
            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            // BL�R�[�h�O�Ή�
            writer.Write(temp.BLGoodsCdZeroSuprt);
            // �ϊ��R�[�h
            writer.Write(temp.BLGoodsCdChange);
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

            // --- ADD 2017/04/13 杍^ Redmine#49283---------->>>>>
            // �d���S���Q�Ƌ敪
            writer.Write(temp.StockEmpRefDiv);
            // --- ADD 2017/04/13 杍^ Redmine#49283----------<<<<<
        }

        /// <summary>
        ///  SalesTtlStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalesTtlStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesTtlStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2009/10/19 ��r�� �\���敪�v���Z�X��ǉ�</br>
        /// <br>Update Note      :   2010/01/29 ���� �󒍐����͂�ǉ�</br>
        /// <br>Update Note      :   2010/04/30 �I�M ���R�������i�����o�^�敪��ǉ�</br>        
        /// <br>Update Note      :   2010/05/04 ���C�� ���s�҃`�F�b�N�敪�A���͑q�Ƀ`�F�b�N�敪��ǉ�</br>
        /// <br>Update Note      :   2010/08/04 �k���r �����_�\���敪��ǉ�</br>
        /// <br>Update Note      :   2011/06/06 �������n �̔��敪�\���敪��ǉ�</br>
        /// <br>Update Note      :   2012/04/13 ���c�N�v �ݏo�d���敪��ǉ�</br>
        /// <br>Update Note      :   2013/01/21 cheq</br>
        /// <br>�Ǘ��ԍ�         :   10806793-00 2013/03/13�z�M��</br>
        /// <br>                     Redmine#33797 �����������l�敪��ǉ�</br>
        /// </remarks>
        private SalesTtlStWork GetSalesTtlStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalesTtlStWork temp = new SalesTtlStWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //����`�[���s�敪
            temp.SalesSlipPrtDiv = reader.ReadInt32();
            //�o�ד`�[���s�敪
            temp.ShipmSlipPrtDiv = reader.ReadInt32();
            //�o�ד`�[�P������敪
            temp.ShipmSlipUnPrcPrtDiv = reader.ReadInt32();
            //�e���`�F�b�N����
            temp.GrsProfitCheckLower = reader.ReadDouble();
            //�e���`�F�b�N�K��
            temp.GrsProfitCheckBest = reader.ReadDouble();
            //�e���`�F�b�N���
            temp.GrsProfitCheckUpper = reader.ReadDouble();
            //�e���`�F�b�N�����L��
            temp.GrsProfitChkLowSign = reader.ReadString();
            //�e���`�F�b�N�K���L��
            temp.GrsProfitChkBestSign = reader.ReadString();
            //�e���`�F�b�N����L��
            temp.GrsProfitChkUprSign = reader.ReadString();
            //�e���`�F�b�N�ő�L��
            temp.GrsProfitChkMaxSign = reader.ReadString();
            //����S���ύX�敪
            temp.SalesAgentChngDiv = reader.ReadInt32();
            //�󒍎ҕ\���敪
            temp.AcpOdrAgentDispDiv = reader.ReadInt32();
            //�`�[���l�Q�\���敪
            temp.BrSlipNote2DispDiv = reader.ReadInt32();
            //���ה��l�\���敪
            temp.DtlNoteDispDiv = reader.ReadInt32();
            //�������ݒ莞�敪
            temp.UnPrcNonSettingDiv = reader.ReadInt32();
            //���σf�[�^�v��c�敪
            temp.EstmateAddUpRemDiv = reader.ReadInt32();
            //�󒍃f�[�^�v��c�敪
            temp.AcpOdrrAddUpRemDiv = reader.ReadInt32();
            //�o�׃f�[�^�v��c�敪
            temp.ShipmAddUpRemDiv = reader.ReadInt32();
            //�ԕi���݌ɓo�^�敪
            temp.RetGoodsStockEtyDiv = reader.ReadInt32();
            //�艿�I���敪
            temp.ListPriceSelectDiv = reader.ReadInt32();
            //���[�J�[���͋敪
            temp.MakerInpDiv = reader.ReadInt32();
            //BL���i�R�[�h���͋敪
            temp.BLGoodsCdInpDiv = reader.ReadInt32();
            //�d������͋敪
            temp.SupplierInpDiv = reader.ReadInt32();
            //�d���`�[�폜�敪
            temp.SupplierSlipDelDiv = reader.ReadInt32();
            //���Ӑ�K�C�h�����\���敪
            temp.CustGuideDispDiv = reader.ReadInt32();
            //�`�[�C���敪�i���t�j
            temp.SlipChngDivDate = reader.ReadInt32();
            //�`�[�C���敪�i�����j
            temp.SlipChngDivCost = reader.ReadInt32();
            //�`�[�C���敪�i�����j
            temp.SlipChngDivUnPrc = reader.ReadInt32();
            //�`�[�C���敪�i�艿�j
            temp.SlipChngDivLPrice = reader.ReadInt32();
            //�ԕi�`�[�C���敪�i�����j
            temp.RetSlipChngDivCost = reader.ReadInt32();
            //�ԕi�`�[�C���敪�i�����j
            temp.RetSlipChngDivUnPrc = reader.ReadInt32();
            //������������R�[�h
            temp.AutoDepoKindCode = reader.ReadInt32();
            //�����������햼��
            temp.AutoDepoKindName = reader.ReadString();
            //������������敪
            temp.AutoDepoKindDivCd = reader.ReadInt32();
            //�l������
            temp.DiscountName = reader.ReadString();
            //���s�ҕ\���敪
            temp.InpAgentDispDiv = reader.ReadInt32();
            //���Ӑ撍�ԕ\���敪
            temp.CustOrderNoDispDiv = reader.ReadInt32();
            //���q�Ǘ��ԍ��\���敪
            temp.CarMngNoDispDiv = reader.ReadInt32();
            // --- ADD 2009/10/19 ---------->>>>>
            // �\���敪�v���Z�X
            temp.PriceSelectDispDiv = reader.ReadInt32();
            // --- ADD 2009/10/19 ----------<<<<<
            // --- ADD 2010/01/29 ---------->>>>>
            // �󒍐�����
            temp.AcpOdrInputDiv = reader.ReadInt32();
            // --- ADD 2010/01/29 ----------<<<<<
            // --- ADD 2010/05/04 ---------->>>>>
            //���s�҃`�F�b�N�敪
            temp.InpAgentChkDiv = reader.ReadInt32();
            //���͑q�Ƀ`�F�b�N�敪
            temp.InpWarehChkDiv = reader.ReadInt32();
            // --- ADD 2010/05/04 ----------<<<<<
            //�`�[���l�R�\���敪
            temp.BrSlipNote3DispDiv = reader.ReadInt32();
            //�`�[���t�N���A�敪
            temp.SlipDateClrDivCd = reader.ReadInt32();
            //���i�����o�^
            temp.AutoEntryGoodsDivCd = reader.ReadInt32();
            //�����`�F�b�N�敪
            temp.CostCheckDivCd = reader.ReadInt32();
            //���������\���敪
            temp.JoinInitDispDiv = reader.ReadInt32();
            //���������敪
            temp.AutoDepositCd = reader.ReadInt32();
            //��֏����敪
            temp.SubstCondDivCd = reader.ReadInt32();
            //�`�[�쐬���@
            temp.SlipCreateProcess = reader.ReadInt32();
            //�q�Ƀ`�F�b�N�敪
            temp.WarehouseChkDiv = reader.ReadInt32();
            //���i�����敪
            temp.PartsSearchDivCd = reader.ReadInt32();
            //�e���\���敪
            temp.GrsProfitDspCd = reader.ReadInt32();
            //���i�����D�揇�敪
            temp.PartsSearchPriDivCd = reader.ReadInt32();
            //����d���敪
            temp.SalesStockDiv = reader.ReadInt32();
            //����pBL���i�R�[�h�敪
            temp.PrtBLGoodsCodeDiv = reader.ReadInt32();
            //���_�\���敪
            temp.SectDspDivCd = reader.ReadInt32();
            //���i���ĕ\���敪
            temp.GoodsNmReDispDivCd = reader.ReadInt32();
            //�����\���敪
            temp.CostDspDivCd = reader.ReadInt32();
            //�����`�[���t�N���A�敪
            temp.DepoSlipDateClrDiv = reader.ReadInt32();
            //�����`�[���t�͈͋敪
            temp.DepoSlipDateAmbit = reader.ReadInt32();
            //���͑e���`�F�b�N����
            temp.InpGrsProfChkLower = reader.ReadDouble();
            //���͑e���`�F�b�N���
            temp.InpGrsProfChkUpper = reader.ReadDouble();
            //���͑e���`�F�b�N�����敪
            temp.InpGrsPrfChkLowDiv = reader.ReadInt32();
            //���͑e���`�F�b�N����敪
            temp.InpGrsPrfChkUppDiv = reader.ReadInt32();
            //�D�Ǒ�֏����敪
            temp.PrmSubstCondDivCd = reader.ReadInt32();
            //��֓K�p�敪
            temp.SubstApplyDivCd = reader.ReadInt32();
            //�i���\���敪
            temp.PartsNameDspDivCd = reader.ReadInt32();
            //BL�R�[�h�}�ԋ敪
            temp.BLGoodsCdDerivNoDiv = reader.ReadInt32();
            // --- ADD 2010/04/30-------------------------------->>>>>
            //���R�������i�����o�^�敪
            temp.FrSrchPrtAutoEntDiv = reader.ReadInt32();
            // --- ADD 2010/04/30 --------------------------------<<<<<
            // 2010/05/14 Add >>>
            //BL�R�[�h�����i���\���敪�P
            temp.BLCdPrtsNmDspDivCd1 = reader.ReadInt32();
            //BL�R�[�h�����i���\���敪�Q
            temp.BLCdPrtsNmDspDivCd2 = reader.ReadInt32();
            //BL�R�[�h�����i���\���敪�R
            temp.BLCdPrtsNmDspDivCd3 = reader.ReadInt32();
            //BL�R�[�h�����i���\���敪�S
            temp.BLCdPrtsNmDspDivCd4 = reader.ReadInt32();
            //�i�Ԍ����i���\���敪�P
            temp.GdNoPrtsNmDspDivCd1 = reader.ReadInt32();
            //�i�Ԍ����i���\���敪�Q
            temp.GdNoPrtsNmDspDivCd2 = reader.ReadInt32();
            //�i�Ԍ����i���\���敪�R
            temp.GdNoPrtsNmDspDivCd3 = reader.ReadInt32();
            //�i�Ԍ����i���\���敪�S
            temp.GdNoPrtsNmDspDivCd4 = reader.ReadInt32();
            //�D�Ǖ��i�����i���g�p�敪
            temp.PrmPrtsNmUseDivCd = reader.ReadInt32();
            // 2010/05/14 Add <<<

            // --- ADD 2010/08/04 ---------->>>>>
            // �����_�\���敪
            temp.DwnPLCdSpDivCd = reader.ReadInt32();
            // --- ADD 2010/08/04 ----------<<<<<
            // --- ADD 2011/06/06 ---------->>>>>
            // �̔��敪�\���敪
            temp.SalesCdDspDivCd = reader.ReadInt32();
            // --- ADD 2011/06/06 ----------<<<<<
            // --- ADD 2012/04/13 ---------->>>>>
            // �ݏo�d���敪
            temp.RentStockDiv = reader.ReadInt32();
            // --- ADD 2012/04/13 ----------<<<<<
            // --- ADD 2012/12/27 Y.Wakita ---------->>>>>
            temp.EpPartsNoPrtCd = reader.ReadInt32();
            temp.EpPartsNoAddChar = reader.ReadString();
            // --- ADD 2012/12/27 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/16 Y.Wakita ---------->>>>>
            temp.PrintGoodsNoDef = reader.ReadInt32();
            // --- ADD 2013/01/16 Y.Wakita ----------<<<<<
            // --- ADD 2013/01/15 ---------->>>>>
            // �d���ԕi�\��@�\�敪
            temp.StockRetGoodsPlnDiv = reader.ReadInt32();
            // --- ADD 2013/01/15 ----------<<<<<
            // --- ADD cheq 2013/01/21 Redmine#33797 ----->>>>>
            // �����������l�敪
            temp.AutoDepositNoteDiv = reader.ReadInt32();
            // --- ADD cheq 2013/01/21 Redmine#33797 -----<<<<<

            // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
            temp.BLGoodsCdZeroSuprt = reader.ReadInt32();
            temp.BLGoodsCdChange = reader.ReadInt32();
            // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

            // --- ADD 2017/04/13 杍^ Redmine#49283---------->>>>>
            temp.StockEmpRefDiv = reader.ReadInt32();
            // --- ADD 2017/04/13 杍^ Redmine#49283----------<<<<<

            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>SalesTtlStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesTtlStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesTtlStWork temp = GetSalesTtlStWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SalesTtlStWork[])lst.ToArray(typeof(SalesTtlStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

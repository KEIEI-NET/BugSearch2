using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockTtlStWork
	/// <summary>
	///                      �d���݌ɑS�̐ݒ胏�[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d���݌ɑS�̐ݒ胏�[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2008/3/17</br>
	/// <br>Genarated Date   :   2008/06/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockTtlStWork : IFileHeader
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

		/// <summary>�d���l������</summary>
		private string _stockDiscountName = "";

		/// <summary>�ԕi�`�[���s�敪</summary>
		/// <remarks>0:���Ȃ��@1:����</remarks>
		private Int32 _rgdsSlipPrtDiv;

		/// <summary>�ԕi���P������敪</summary>
		/// <remarks>0:����@1:���Ȃ�</remarks>
		private Int32 _rgdsUnPrcPrtDiv;

		/// <summary>�ԕi���[���~����敪</summary>
		/// <remarks>0:����@1:���Ȃ�</remarks>
		private Int32 _rgdsZeroPrtDiv;

		/// <summary>�艿���͋敪</summary>
		/// <remarks>0:�\�@1:�s��  (�d�����ׂ̒艿���́j</remarks>
		private Int32 _listPriceInpDiv;

		/// <summary>�P�����͋敪</summary>
		/// <remarks>0:�\�@1:�s��  (�d�����ׂ̎d���P�����́j</remarks>
		private Int32 _unitPriceInpDiv;

		/// <summary>���ה��l�\���敪</summary>
		/// <remarks>0:�L��@1:�����@�i�����̏ꍇ�A��ʍ��ڂ��\��) </remarks>
		private Int32 _dtlNoteDispDiv;

		/// <summary>�����x������R�[�h</summary>
		/// <remarks>�G���g���ł̎����x���̋���</remarks>
		private Int32 _autoPayMoneyKindCode;

		/// <summary>�����x�����햼��</summary>
		/// <remarks>�G���g���ł̎����x���̋���</remarks>
		private string _autoPayMoneyKindName = "";

		/// <summary>�����x������敪</summary>
		/// <remarks>�G���g���ł̎����x���̋���</remarks>
		private Int32 _autoPayMoneyKindDiv;

		/// <summary>�����x���敪</summary>
		/// <remarks>0:�ʏ�x��,1:�����x���i�x���`�[���͂��甭���j</remarks>
		private Int32 _autoPayment;

		/// <summary>�艿�����X�V�敪</summary>
		/// <remarks>0:��X�V�@1:�������X�V�@2:�m�F�X�V</remarks>
		private Int32 _priceCostUpdtDiv;

		/// <summary>���i�����o�^</summary>
		/// <remarks>0:�Ȃ��@1:����</remarks>
		private Int32 _autoEntryGoodsDivCd;

		/// <summary>�艿�`�F�b�N�敪</summary>
		/// <remarks>0:�����@1:�ē��́@2:�x��MSG�@�i�艿���P���̏ꍇ�j</remarks>
		private Int32 _priceCheckDivCd;

		/// <summary>�d���P���`�F�b�N�敪</summary>
		/// <remarks>0:�����@1:�ē��́@2:�x��MSG�@�i�P���������̏ꍇ�j</remarks>
		private Int32 _stockUnitChgDivCd;

		/// <summary>���_�\���敪</summary>
		/// <remarks>0:�W���@1:����Ͻ��@2:�\������</remarks>
		private Int32 _sectDspDivCd;

		/// <summary>�`�[���t�N���A�敪</summary>
		/// <remarks>0:�V�X�e�����t 1:���͓��t</remarks>
		private Int32 _slipDateClrDivCd;

		/// <summary>�x���`�[���t�N���A�敪</summary>
		/// <remarks>0:�V�X�e�����t�ɖ߂� 1:���͓��t�̂܂�</remarks>
		private Int32 _paySlipDateClrDiv;

		/// <summary>�x���`�[���t�͈͋敪</summary>
		/// <remarks>0:�����Ȃ� 1:�V�X�e�����t�ȍ~���͕s��</remarks>
		private Int32 _paySlipDateAmbit;

        /// <summary>�݌Ɍ����敪</summary>
        /// <remarks>0:�D��q��,1:�w��q��</remarks>
        private Int32 _stockSearchDiv;

        /// <summary>���i���ĕ\���敪</summary>
        /// <remarks>0:���Ȃ��@1:����</remarks>
        private Int32 _goodsNmReDispDivCd;
        
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

		/// public propaty name  :  StockDiscountName
		/// <summary>�d���l�����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���l�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StockDiscountName
		{
			get{return _stockDiscountName;}
			set{_stockDiscountName = value;}
		}

		/// public propaty name  :  RgdsSlipPrtDiv
		/// <summary>�ԕi�`�[���s�敪�v���p�e�B</summary>
		/// <value>0:���Ȃ��@1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi�`�[���s�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RgdsSlipPrtDiv
		{
			get{return _rgdsSlipPrtDiv;}
			set{_rgdsSlipPrtDiv = value;}
		}

		/// public propaty name  :  RgdsUnPrcPrtDiv
		/// <summary>�ԕi���P������敪�v���p�e�B</summary>
		/// <value>0:����@1:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi���P������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RgdsUnPrcPrtDiv
		{
			get{return _rgdsUnPrcPrtDiv;}
			set{_rgdsUnPrcPrtDiv = value;}
		}

		/// public propaty name  :  RgdsZeroPrtDiv
		/// <summary>�ԕi���[���~����敪�v���p�e�B</summary>
		/// <value>0:����@1:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԕi���[���~����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RgdsZeroPrtDiv
		{
			get{return _rgdsZeroPrtDiv;}
			set{_rgdsZeroPrtDiv = value;}
		}

		/// public propaty name  :  ListPriceInpDiv
		/// <summary>�艿���͋敪�v���p�e�B</summary>
		/// <value>0:�\�@1:�s��  (�d�����ׂ̒艿���́j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿���͋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ListPriceInpDiv
		{
			get{return _listPriceInpDiv;}
			set{_listPriceInpDiv = value;}
		}

		/// public propaty name  :  UnitPriceInpDiv
		/// <summary>�P�����͋敪�v���p�e�B</summary>
		/// <value>0:�\�@1:�s��  (�d�����ׂ̎d���P�����́j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P�����͋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UnitPriceInpDiv
		{
			get{return _unitPriceInpDiv;}
			set{_unitPriceInpDiv = value;}
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

		/// public propaty name  :  AutoPayMoneyKindCode
		/// <summary>�����x������R�[�h�v���p�e�B</summary>
		/// <value>�G���g���ł̎����x���̋���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����x������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AutoPayMoneyKindCode
		{
			get{return _autoPayMoneyKindCode;}
			set{_autoPayMoneyKindCode = value;}
		}

		/// public propaty name  :  AutoPayMoneyKindName
		/// <summary>�����x�����햼�̃v���p�e�B</summary>
		/// <value>�G���g���ł̎����x���̋���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����x�����햼�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AutoPayMoneyKindName
		{
			get{return _autoPayMoneyKindName;}
			set{_autoPayMoneyKindName = value;}
		}

		/// public propaty name  :  AutoPayMoneyKindDiv
		/// <summary>�����x������敪�v���p�e�B</summary>
		/// <value>�G���g���ł̎����x���̋���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����x������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AutoPayMoneyKindDiv
		{
			get{return _autoPayMoneyKindDiv;}
			set{_autoPayMoneyKindDiv = value;}
		}

		/// public propaty name  :  AutoPayment
		/// <summary>�����x���敪�v���p�e�B</summary>
		/// <value>0:�ʏ�x��,1:�����x���i�x���`�[���͂��甭���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����x���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AutoPayment
		{
			get{return _autoPayment;}
			set{_autoPayment = value;}
		}

		/// public propaty name  :  PriceCostUpdtDiv
		/// <summary>�艿�����X�V�敪�v���p�e�B</summary>
		/// <value>0:��X�V�@1:�������X�V�@2:�m�F�X�V</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�����X�V�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PriceCostUpdtDiv
		{
			get{return _priceCostUpdtDiv;}
			set{_priceCostUpdtDiv = value;}
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

		/// public propaty name  :  PriceCheckDivCd
		/// <summary>�艿�`�F�b�N�敪�v���p�e�B</summary>
		/// <value>0:�����@1:�ē��́@2:�x��MSG�@�i�艿���P���̏ꍇ�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�`�F�b�N�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PriceCheckDivCd
		{
			get{return _priceCheckDivCd;}
			set{_priceCheckDivCd = value;}
		}

		/// public propaty name  :  StockUnitChgDivCd
		/// <summary>�d���P���`�F�b�N�敪�v���p�e�B</summary>
		/// <value>0:�����@1:�ē��́@2:�x��MSG�@�i�P���������̏ꍇ�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d���P���`�F�b�N�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockUnitChgDivCd
		{
			get{return _stockUnitChgDivCd;}
			set{_stockUnitChgDivCd = value;}
		}

		/// public propaty name  :  SectDspDivCd
		/// <summary>���_�\���敪�v���p�e�B</summary>
		/// <value>0:�W���@1:����Ͻ��@2:�\������</value>
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

		/// public propaty name  :  PaySlipDateClrDiv
		/// <summary>�x���`�[���t�N���A�敪�v���p�e�B</summary>
		/// <value>0:�V�X�e�����t�ɖ߂� 1:���͓��t�̂܂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���`�[���t�N���A�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PaySlipDateClrDiv
		{
			get{return _paySlipDateClrDiv;}
			set{_paySlipDateClrDiv = value;}
		}

		/// public propaty name  :  PaySlipDateAmbit
		/// <summary>�x���`�[���t�͈͋敪�v���p�e�B</summary>
		/// <value>0:�����Ȃ� 1:�V�X�e�����t�ȍ~���͕s��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x���`�[���t�͈͋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PaySlipDateAmbit
		{
			get{return _paySlipDateAmbit;}
			set{_paySlipDateAmbit = value;}
		}

        /// public propaty name  :  PaySlipDateAmbit
        /// <summary>�݌Ɍ����敪�v���p�e�B</summary>
        /// <value>0:�D��q��,1:�w��q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɍ����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockSearchDiv
        {
            get { return _stockSearchDiv; }
            set { _stockSearchDiv = value; }
        }

        /// public propaty name  :  GoodsNmReDispDivCd
        /// <summary>���i���ĕ\���敪�v���p�e�B</summary>
        /// <value>0:���Ȃ��@1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���ĕ\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNmReDispDivCd
        {
            get { return _goodsNmReDispDivCd; }
            set { _goodsNmReDispDivCd = value; }
        }
        
        /// <summary>
		/// �d���݌ɑS�̐ݒ胏�[�N�R���X�g���N�^
		/// </summary>
		/// <returns>StockTtlStWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockTtlStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockTtlStWork()
		{
		}

	}

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>StockTtlStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   StockTtlStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class StockTtlStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTtlStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockTtlStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockTtlStWork || graph is ArrayList || graph is StockTtlStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(StockTtlStWork).FullName));

            if (graph != null && graph is StockTtlStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockTtlStWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockTtlStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockTtlStWork[])graph).Length;
            }
            else if (graph is StockTtlStWork)
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
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //�d���l������
            serInfo.MemberInfo.Add(typeof(string)); //StockDiscountName
            //�ԕi�`�[���s�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RgdsSlipPrtDiv
            //�ԕi���P������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RgdsUnPrcPrtDiv
            //�ԕi���[���~����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //RgdsZeroPrtDiv
            //�艿���͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPriceInpDiv
            //�P�����͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //UnitPriceInpDiv
            //���ה��l�\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlNoteDispDiv
            //�����x������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPayMoneyKindCode
            //�����x�����햼��
            serInfo.MemberInfo.Add(typeof(string)); //AutoPayMoneyKindName
            //�����x������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPayMoneyKindDiv
            //�����x���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPayment
            //�艿�����X�V�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCostUpdtDiv
            //���i�����o�^
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoEntryGoodsDivCd
            //�艿�`�F�b�N�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCheckDivCd
            //�d���P���`�F�b�N�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockUnitChgDivCd
            //���_�\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SectDspDivCd
            //�`�[���t�N���A�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipDateClrDivCd
            //�x���`�[���t�N���A�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PaySlipDateClrDiv
            //�x���`�[���t�͈͋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PaySlipDateAmbit
            //�݌Ɍ����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StockSearchDiv
            //���i���ĕ\���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNmReDispDivCd


            serInfo.Serialize(writer, serInfo);
            if (graph is StockTtlStWork)
            {
                StockTtlStWork temp = (StockTtlStWork)graph;

                SetStockTtlStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockTtlStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockTtlStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockTtlStWork temp in lst)
                {
                    SetStockTtlStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockTtlStWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 31;

        /// <summary>
        ///  StockTtlStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTtlStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockTtlStWork(System.IO.BinaryWriter writer, StockTtlStWork temp)
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
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //�d���l������
            writer.Write(temp.StockDiscountName);
            //�ԕi�`�[���s�敪
            writer.Write(temp.RgdsSlipPrtDiv);
            //�ԕi���P������敪
            writer.Write(temp.RgdsUnPrcPrtDiv);
            //�ԕi���[���~����敪
            writer.Write(temp.RgdsZeroPrtDiv);
            //�艿���͋敪
            writer.Write(temp.ListPriceInpDiv);
            //�P�����͋敪
            writer.Write(temp.UnitPriceInpDiv);
            //���ה��l�\���敪
            writer.Write(temp.DtlNoteDispDiv);
            //�����x������R�[�h
            writer.Write(temp.AutoPayMoneyKindCode);
            //�����x�����햼��
            writer.Write(temp.AutoPayMoneyKindName);
            //�����x������敪
            writer.Write(temp.AutoPayMoneyKindDiv);
            //�����x���敪
            writer.Write(temp.AutoPayment);
            //�艿�����X�V�敪
            writer.Write(temp.PriceCostUpdtDiv);
            //���i�����o�^
            writer.Write(temp.AutoEntryGoodsDivCd);
            //�艿�`�F�b�N�敪
            writer.Write(temp.PriceCheckDivCd);
            //�d���P���`�F�b�N�敪
            writer.Write(temp.StockUnitChgDivCd);
            //���_�\���敪
            writer.Write(temp.SectDspDivCd);
            //�`�[���t�N���A�敪
            writer.Write(temp.SlipDateClrDivCd);
            //�x���`�[���t�N���A�敪
            writer.Write(temp.PaySlipDateClrDiv);
            //�x���`�[���t�͈͋敪
            writer.Write(temp.PaySlipDateAmbit);
            //�݌Ɍ����敪
            writer.Write(temp.StockSearchDiv);
            //���i���ĕ\���敪
            writer.Write(temp.GoodsNmReDispDivCd);

        }

        /// <summary>
        ///  StockTtlStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>StockTtlStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTtlStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private StockTtlStWork GetStockTtlStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            StockTtlStWork temp = new StockTtlStWork();

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
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //�d���l������
            temp.StockDiscountName = reader.ReadString();
            //�ԕi�`�[���s�敪
            temp.RgdsSlipPrtDiv = reader.ReadInt32();
            //�ԕi���P������敪
            temp.RgdsUnPrcPrtDiv = reader.ReadInt32();
            //�ԕi���[���~����敪
            temp.RgdsZeroPrtDiv = reader.ReadInt32();
            //�艿���͋敪
            temp.ListPriceInpDiv = reader.ReadInt32();
            //�P�����͋敪
            temp.UnitPriceInpDiv = reader.ReadInt32();
            //���ה��l�\���敪
            temp.DtlNoteDispDiv = reader.ReadInt32();
            //�����x������R�[�h
            temp.AutoPayMoneyKindCode = reader.ReadInt32();
            //�����x�����햼��
            temp.AutoPayMoneyKindName = reader.ReadString();
            //�����x������敪
            temp.AutoPayMoneyKindDiv = reader.ReadInt32();
            //�����x���敪
            temp.AutoPayment = reader.ReadInt32();
            //�艿�����X�V�敪
            temp.PriceCostUpdtDiv = reader.ReadInt32();
            //���i�����o�^
            temp.AutoEntryGoodsDivCd = reader.ReadInt32();
            //�艿�`�F�b�N�敪
            temp.PriceCheckDivCd = reader.ReadInt32();
            //�d���P���`�F�b�N�敪
            temp.StockUnitChgDivCd = reader.ReadInt32();
            //���_�\���敪
            temp.SectDspDivCd = reader.ReadInt32();
            //�`�[���t�N���A�敪
            temp.SlipDateClrDivCd = reader.ReadInt32();
            //�x���`�[���t�N���A�敪
            temp.PaySlipDateClrDiv = reader.ReadInt32();
            //�x���`�[���t�͈͋敪
            temp.PaySlipDateAmbit = reader.ReadInt32();
            //�݌Ɍ����敪
            temp.StockSearchDiv = reader.ReadInt32();
            //���i���ĕ\���敪
            temp.GoodsNmReDispDivCd = reader.ReadInt32();


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
        /// <returns>StockTtlStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTtlStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockTtlStWork temp = GetStockTtlStWork(reader, serInfo);
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
                    retValue = (StockTtlStWork[])lst.ToArray(typeof(StockTtlStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

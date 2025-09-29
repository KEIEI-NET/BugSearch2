using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData.StubDB
{
	/// public class name:   ScmOdDtInq
	/// <summary>
	///                      SCM�󔭒����׃f�[�^�i�⍇���E�����j
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�󔭒����׃f�[�^�i�⍇���E�����j�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/2/20</br>
	/// <br>Genarated Date   :   2009/06/15  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/5/7  ����@�_�u</br>
	/// <br>                 :   �Y�t�t�@�C��(����),�Y�t�t�@�C����(����)</br>
	/// <br>                 :   �폜</br>
	/// <br>                 :   �⍇���E�������</br>
	/// <br>                 :   �ǉ�</br>
	/// <br>Update Note      :   2009/5/15  �����@���l</br>
	/// <br>                 :   �\�����ʂ�ǉ�</br>
	/// <br>Update Note      :   2009/5/19  ��{�@�E</br>
	/// <br>                 :   ���i��ʂ̔��l�ύX�A���T�C�N�����i��ʁA</br>
	/// <br>                 :   ���T�C�N�����i��ʖ��̒ǉ��A���׎捞�敪�폜</br>
	/// <br>                 :   �񓚔[���ǉ�</br>
	/// <br>Update Note      :   2009/5/22  ��{�@�E</br>
	/// <br>                 :   ���i��ʂ̔��l���폜</br>
	/// <br>Update Note      :   2009/5/22  ����@�_�u</br>
	/// <br>                 :   �ŐV���ʋ敪</br>
	/// <br>                 :   �ǉ�</br>
    /// <br>Update Note      :   2014/06/04  30744 ����</br>
    /// <br>                 :   SCM�d�|�ꗗ��10659�Ή�</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �D�ǐݒ�ڍ׃R�[�h�Q</br>
    /// <br>                 :   �D�ǐݒ�ڍז��̂Q</br>
    /// <br>                 :   �݌ɏ󋵋敪</br>
    /// <br>Update Note      :   2014/12/19  30744 ����</br>
    /// <br>�Ǘ��ԍ�         :   11070266-00</br>
    /// <br>                 :   SCM������ PMNS�Ή�</br>
    /// <br>                 :   ���ڒǉ��@�ݏo�敪�A���[�J�[��]�������i�A�I�[�v�����i�敪</br>
    /// <br>Update Note      :   2015/01/19  31065 �L�� ���O</br>
    /// <br>�Ǘ��ԍ�         :   11070266-00</br>
    /// <br>                 :   ���R�����h�Ή�</br>
    /// <br>Update Note      :   2015/01/30  30744 ����</br>
    /// <br>�Ǘ��ԍ�         :   11070266-00</br>
    /// <br>                 :   SCM������ ���Y�N���A�ԑ�ԍ��Ή�</br>
    /// <br>                 :   ���ڒǉ��@�^���ʕ��i�̗p�N���A�^���ʕ��i�p�~�N���A�^���ʕ��i�̗p�ԑ�ԍ��A�^���ʕ��i�p�~�ԑ�ԍ�</br>
    /// <br>Update Note      :   2015/02/10  30745 �g��</br>
    /// <br>�Ǘ��ԍ�         :   11070266-00</br>
    /// <br>                 :   SCM������ �񓚔[���敪�Ή� ���ڒǉ�</br>
    /// <br>Update Note      :   2015/02/10  30746 ���� ��</br>
    /// <br>�Ǘ��ԍ�         :   11070266-00</br>
    /// <br>                 :   SCM������ C������ʁE���L�����Ή�</br>
    /// <br>Update Note      :   �����ڒǉ�</br>
    /// <br>                 :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</br>
    /// <br>                 :   �┭BL���ꕔ�i�T�u�R�[�h</br>
    /// <br>                 :   ��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</br>
    /// <br>                 :   ��BL���ꕔ�i�T�u�R�[�h</br>
    /// <br>                 :   ��BL���i�R�[�h</br>
    /// <br>                 :   ��BL���i�R�[�h�}��</br>
    /// <br>�Ǘ��ԍ�         :   11470007-00</br>
    /// <br>                 :   2018/04/16 �c����</br>
    /// </remarks>
	public class ScmOdDtInq
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>�⍇������ƃR�[�h</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>�⍇�������_�R�[�h</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>�⍇�����ƃR�[�h</summary>
		private string _inqOtherEpCd = "";

		/// <summary>�⍇���拒�_�R�[�h</summary>
		private string _inqOtherSecCd = "";

		/// <summary>�⍇���ԍ�</summary>
		private Int64 _inquiryNumber;

		/// <summary>�X�V�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>�X�V�����b�~���b</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>�⍇���s�ԍ�</summary>
		private Int32 _inqRowNumber;

		/// <summary>�⍇���s�ԍ��}��</summary>
		private Int32 _inqRowNumDerivedNo;

		/// <summary>�⍇�������׎���GUID</summary>
		private Guid _inqOrgDtlDiscGuid;

		/// <summary>�⍇���斾�׎���GUID</summary>
		/// <remarks>�񓚃f�[�^�̏ꍇ�L���A�⍇���^�������̖���GUID��ݒ�</remarks>
		private Guid _inqOthDtlDiscGuid;

		/// <summary>���i���</summary>
		/// <remarks>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ���</remarks>
		private Int32 _goodsDivCd;

		/// <summary>���T�C�N�����i���</summary>
		private Int32 _recyclePrtKindCode;

		/// <summary>���T�C�N�����i��ʖ���</summary>
		private string _recyclePrtKindName = "";

		/// <summary>�[�i�敪</summary>
		/// <remarks>0:�z��,1:����</remarks>
		private Int32 _deliveredGoodsDiv;

		/// <summary>�戵�敪</summary>
		/// <remarks>0:��舵���i,1:�[���m�F��,2:����舵���i</remarks>
		private Int32 _handleDivCode;

		/// <summary>���i�`��</summary>
		/// <remarks>1:���i,2:�p�i</remarks>
		private Int32 _goodsShape;

		/// <summary>�[�i�m�F�敪</summary>
		/// <remarks>0:���m�F,1:�m�F</remarks>
		private Int32 _delivrdGdsConfCd;

		/// <summary>�[�i�����\���</summary>
		/// <remarks>�[�i�\����t YYYYMMDD</remarks>
		private DateTime _deliGdsCmpltDueDate;

		/// <summary>�񓚔[��</summary>
		private string _answerDeliveryDate = "";

		/// <summary>BL���i�R�[�h</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL���i�R�[�h�}��</summary>
		private Int32 _bLGoodsDrCode;

		/// <summary>�┭���i��</summary>
		/// <remarks>(���p�S�p����)</remarks>
		private string _inqGoodsName = "";

		/// <summary>�񓚏��i��</summary>
		/// <remarks>(���p�S�p����)</remarks>
		private string _ansGoodsName = "";

		/// <summary>������</summary>
		private Double _salesOrderCount;

		/// <summary>�[�i��</summary>
		private Double _deliveredGoodsCount;

		/// <summary>���i�ԍ�</summary>
		private string _goodsNo = "";

		/// <summary>���i���[�J�[�R�[�h</summary>
		private Int32 _goodsMakerCd;

		/// <summary>���i���[�J�[����</summary>
		private string _goodsMakerNm = "";

		/// <summary>�������i���[�J�[�R�[�h</summary>
		private Int32 _pureGoodsMakerCd;

		/// <summary>�┭�������i�ԍ�</summary>
		/// <remarks>(���p�̂�)</remarks>
		private string _inqPureGoodsNo = "";

		/// <summary>�񓚏������i�ԍ�</summary>
		/// <remarks>(���p�̂�)</remarks>
		private string _ansPureGoodsNo = "";

		/// <summary>�艿</summary>
		/// <remarks>0:�I�[�v�����i</remarks>
		private Int64 _listPrice;

		/// <summary>�P��</summary>
		private Int64 _unitPrice;

		/// <summary>���i�⑫���</summary>
		private string _goodsAddInfo = "";

		/// <summary>�e���z</summary>
		private Int64 _roughRrofit;

		/// <summary>�e����</summary>
		private Double _roughRate;

		/// <summary>�񓚊���</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _answerLimitDate;

		/// <summary>���l(����)</summary>
		private string _commentDtl = "";

		/// <summary>�I��</summary>
		private string _shelfNo = "";

		/// <summary>�ǉ��敪</summary>
		private Int32 _additionalDivCd;

		/// <summary>�����敪</summary>
		private Int32 _correctDivCD;

		/// <summary>�⍇���E�������</summary>
		/// <remarks>1:�⍇�� 2:����</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>�\������</summary>
		private Int32 _displayOrder;

		/// <summary>�ŐV���ʋ敪</summary>
		/// <remarks>0:�ŐV�f�[�^ 1:���f�[�^</remarks>
		private Int16 _latestDiscCode;

		/// <summary>BL���i�R�[�h����</summary>
		private string _bLGoodsName = "";

        // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q</summary>
        /// <remarks>�D�ǐݒ�}�X�^���擾�@��ʃR�[�h</remarks>
        private Int32 _prmSetDtlNo2 = 0;

        /// <summary>�D�ǐݒ�ڍז��̂Q</summary>
        /// <remarks>�D�ǐݒ�}�X�^���擾</remarks>
        private string _prmSetDtlName2 = "";

        /// <summary>�݌ɏ󋵋敪</summary>
        private Int16 _stockStatusDiv = 0;
        // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<

        // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
        /// <summary>�ݏo�敪</summary>
        /// <remarks></remarks>
        private Int16 _rentDiv = 0;
        /// <summary>���[�J�[��]�������i</summary>
        /// <remarks></remarks>
        private Int64 _mkrSuggestRtPric = 0;
        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks></remarks>
        private Int32 _openPriceDiv = 0;
        // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<

        // ADD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
        /// <summary>���������i�I���敪</summary>
        private Int16 _bgnGoodsDiv = 0;
        // ADD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<

        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
        /// <summary>�^���ʕ��i�̗p�N��</summary>
        private Int32 _modelPrtsAdptYm;
        /// <summary>�^���ʕ��i�p�~�N��</summary>
        private Int32 _modelPrtsAblsYm;
        /// <summary>�^���ʕ��i�̗p�ԑ�ԍ�</summary>
        private Int32 _modelPrtsAdptFrameNo = 0;
        /// <summary>�^���ʕ��i�p�~�ԑ�ԍ�</summary>
        private Int32 _modelPrtsAblsFrameNo = 0;
        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<

        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> �񓚔[���敪���擾�܂��͐ݒ肵�܂��B</summary>
        private Int16 _ansDeliDateDiv = 0;
        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
        /// <summary>���i�K�i�E���L����(�H�����)</summary>
        /// <remarks>�����H��E����H��Ȃǂ������\�Ȑ����������� (���p�S�p����)</remarks>
        private string _goodsSpecialNtForFac = "";

        /// <summary>���i�K�i�E���L����(�J�[�I�[�i�[����)</summary>
        /// <remarks>�J�[�I�[�i�[�������\�Ȑ����������� (���p�S�p����)</remarks>
        private string _goodsSpecialNtForCOw = "";

        /// <summary>�D�ǐݒ�ڍז��̂Q(�H�����)</summary>
        /// <remarks>�����H��E����H��Ȃǂ������\�Ȑ����������� (���p�S�p����)</remarks>
        private string _prmSetDtlName2ForFac = "";

        /// <summary>�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)</summary>
        /// <remarks>�J�[�I�[�i�[�������\�Ȑ����������� (���p�S�p����)</remarks>
        private string _prmSetDtlName2ForCOw = "";
        // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<

        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</summary>
        /// <remarks>.C �R�[�h�̌n����</remarks>
        private string _inqBlUtyPtThCd = "";

        /// <summary>�┭BL���ꕔ�i�T�u�R�[�h</summary>
        /// <remarks>.C �R�[�h�̌n����</remarks>
        private Int32 _inqBlUtyPtSbCd;

        /// <summary>��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</summary>
        /// <remarks>.C �R�[�h�̌n����</remarks>
        private string _ansBlUtyPtThCd = "";

        /// <summary>��BL���ꕔ�i�T�u�R�[�h</summary>
        /// <remarks>.C �R�[�h�̌n����</remarks>
        private Int32 _ansBlUtyPtSbCd;

        /// <summary>��BL���i�R�[�h</summary>
        private Int32 _ansBLGoodsCode;

        /// <summary>��BL���i�R�[�h�}��</summary>
        private Int32 _ansBLGoodsDrCode;
        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>�쐬���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>�쐬���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>�쐬���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
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

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>�X�V���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>�X�V���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>�X�V���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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

		/// public propaty name  :  InqOriginalEpCd
		/// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOriginalEpCd
		{
			get{return _inqOriginalEpCd;}
			set{_inqOriginalEpCd = value;}
		}

		/// public propaty name  :  InqOriginalSecCd
		/// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOriginalSecCd
		{
			get{return _inqOriginalSecCd;}
			set{_inqOriginalSecCd = value;}
		}

		/// public propaty name  :  InqOtherEpCd
		/// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOtherEpCd
		{
			get{return _inqOtherEpCd;}
			set{_inqOtherEpCd = value;}
		}

		/// public propaty name  :  InqOtherSecCd
		/// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOtherSecCd
		{
			get{return _inqOtherSecCd;}
			set{_inqOtherSecCd = value;}
		}

		/// public propaty name  :  InquiryNumber
		/// <summary>�⍇���ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 InquiryNumber
		{
			get{return _inquiryNumber;}
			set{_inquiryNumber = value;}
		}

		/// public propaty name  :  UpdateDate
		/// <summary>�X�V�N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDate
		{
			get{return _updateDate;}
			set{_updateDate = value;}
		}

		/// public propaty name  :  UpdateDateJpFormal
		/// <summary>�X�V�N���� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateJpInFormal
		/// <summary>�X�V�N���� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateAdFormal
		/// <summary>�X�V�N���� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateDateAdInFormal
		/// <summary>�X�V�N���� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDate);}
			set{}
		}

		/// public propaty name  :  UpdateTime
		/// <summary>�X�V�����b�~���b�v���p�e�B</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����b�~���b�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UpdateTime
		{
			get{return _updateTime;}
			set{_updateTime = value;}
		}

		/// public propaty name  :  InqRowNumber
		/// <summary>�⍇���s�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqRowNumber
		{
			get{return _inqRowNumber;}
			set{_inqRowNumber = value;}
		}

		/// public propaty name  :  InqRowNumDerivedNo
		/// <summary>�⍇���s�ԍ��}�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���s�ԍ��}�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqRowNumDerivedNo
		{
			get{return _inqRowNumDerivedNo;}
			set{_inqRowNumDerivedNo = value;}
		}

		/// public propaty name  :  InqOrgDtlDiscGuid
		/// <summary>�⍇�������׎���GUID�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�������׎���GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid InqOrgDtlDiscGuid
		{
			get{return _inqOrgDtlDiscGuid;}
			set{_inqOrgDtlDiscGuid = value;}
		}

		/// public propaty name  :  InqOthDtlDiscGuid
		/// <summary>�⍇���斾�׎���GUID�v���p�e�B</summary>
		/// <value>�񓚃f�[�^�̏ꍇ�L���A�⍇���^�������̖���GUID��ݒ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���斾�׎���GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid InqOthDtlDiscGuid
		{
			get{return _inqOthDtlDiscGuid;}
			set{_inqOthDtlDiscGuid = value;}
		}

		/// public propaty name  :  GoodsDivCd
		/// <summary>���i��ʃv���p�e�B</summary>
		/// <value>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsDivCd
		{
			get{return _goodsDivCd;}
			set{_goodsDivCd = value;}
		}

		/// public propaty name  :  RecyclePrtKindCode
		/// <summary>���T�C�N�����i��ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���T�C�N�����i��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RecyclePrtKindCode
		{
			get{return _recyclePrtKindCode;}
			set{_recyclePrtKindCode = value;}
		}

		/// public propaty name  :  RecyclePrtKindName
		/// <summary>���T�C�N�����i��ʖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���T�C�N�����i��ʖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string RecyclePrtKindName
		{
			get{return _recyclePrtKindName;}
			set{_recyclePrtKindName = value;}
		}

		/// public propaty name  :  DeliveredGoodsDiv
		/// <summary>�[�i�敪�v���p�e�B</summary>
		/// <value>0:�z��,1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DeliveredGoodsDiv
		{
			get{return _deliveredGoodsDiv;}
			set{_deliveredGoodsDiv = value;}
		}

		/// public propaty name  :  HandleDivCode
		/// <summary>�戵�敪�v���p�e�B</summary>
		/// <value>0:��舵���i,1:�[���m�F��,2:����舵���i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �戵�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 HandleDivCode
		{
			get{return _handleDivCode;}
			set{_handleDivCode = value;}
		}

		/// public propaty name  :  GoodsShape
		/// <summary>���i�`�ԃv���p�e�B</summary>
		/// <value>1:���i,2:�p�i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�`�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsShape
		{
			get{return _goodsShape;}
			set{_goodsShape = value;}
		}

		/// public propaty name  :  DelivrdGdsConfCd
		/// <summary>�[�i�m�F�敪�v���p�e�B</summary>
		/// <value>0:���m�F,1:�m�F</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�m�F�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DelivrdGdsConfCd
		{
			get{return _delivrdGdsConfCd;}
			set{_delivrdGdsConfCd = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDate
		/// <summary>�[�i�����\����v���p�e�B</summary>
		/// <value>�[�i�\����t YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime DeliGdsCmpltDueDate
		{
			get{return _deliGdsCmpltDueDate;}
			set{_deliGdsCmpltDueDate = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpFormal
		/// <summary>�[�i�����\��� �a��v���p�e�B</summary>
		/// <value>�[�i�\����t YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpInFormal
		/// <summary>�[�i�����\��� �a��(��)�v���p�e�B</summary>
		/// <value>�[�i�\����t YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdFormal
		/// <summary>�[�i�����\��� ����v���p�e�B</summary>
		/// <value>�[�i�\����t YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdInFormal
		/// <summary>�[�i�����\��� ����(��)�v���p�e�B</summary>
		/// <value>�[�i�\����t YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i�����\��� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  AnswerDeliveryDate
		/// <summary>�񓚔[���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚔[���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnswerDeliveryDate
		{
			get{return _answerDeliveryDate;}
			set{_answerDeliveryDate = value;}
		}

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL���i�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  BLGoodsDrCode
		/// <summary>BL���i�R�[�h�}�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h�}�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLGoodsDrCode
		{
			get{return _bLGoodsDrCode;}
			set{_bLGoodsDrCode = value;}
		}

		/// public propaty name  :  InqGoodsName
		/// <summary>�┭���i���v���p�e�B</summary>
		/// <value>(���p�S�p����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �┭���i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqGoodsName
		{
			get{return _inqGoodsName;}
			set{_inqGoodsName = value;}
		}

		/// public propaty name  :  AnsGoodsName
		/// <summary>�񓚏��i���v���p�e�B</summary>
		/// <value>(���p�S�p����)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏��i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsGoodsName
		{
			get{return _ansGoodsName;}
			set{_ansGoodsName = value;}
		}

		/// public propaty name  :  SalesOrderCount
		/// <summary>�������v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double SalesOrderCount
		{
			get{return _salesOrderCount;}
			set{_salesOrderCount = value;}
		}

		/// public propaty name  :  DeliveredGoodsCount
		/// <summary>�[�i���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�i���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double DeliveredGoodsCount
		{
			get{return _deliveredGoodsCount;}
			set{_deliveredGoodsCount = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>���i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  GoodsMakerNm
		/// <summary>���i���[�J�[���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i���[�J�[���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsMakerNm
		{
			get{return _goodsMakerNm;}
			set{_goodsMakerNm = value;}
		}

		/// public propaty name  :  PureGoodsMakerCd
		/// <summary>�������i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PureGoodsMakerCd
		{
			get{return _pureGoodsMakerCd;}
			set{_pureGoodsMakerCd = value;}
		}

		/// public propaty name  :  InqPureGoodsNo
		/// <summary>�┭�������i�ԍ��v���p�e�B</summary>
		/// <value>(���p�̂�)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �┭�������i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqPureGoodsNo
		{
			get{return _inqPureGoodsNo;}
			set{_inqPureGoodsNo = value;}
		}

		/// public propaty name  :  AnsPureGoodsNo
		/// <summary>�񓚏������i�ԍ��v���p�e�B</summary>
		/// <value>(���p�̂�)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏������i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsPureGoodsNo
		{
			get{return _ansPureGoodsNo;}
			set{_ansPureGoodsNo = value;}
		}

		/// public propaty name  :  ListPrice
		/// <summary>�艿�v���p�e�B</summary>
		/// <value>0:�I�[�v�����i</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ListPrice
		{
			get{return _listPrice;}
			set{_listPrice = value;}
		}

		/// public propaty name  :  UnitPrice
		/// <summary>�P���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �P���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 UnitPrice
		{
			get{return _unitPrice;}
			set{_unitPrice = value;}
		}

		/// public propaty name  :  GoodsAddInfo
		/// <summary>���i�⑫���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�⑫���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GoodsAddInfo
		{
			get{return _goodsAddInfo;}
			set{_goodsAddInfo = value;}
		}

		/// public propaty name  :  RoughRrofit
		/// <summary>�e���z�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 RoughRrofit
		{
			get{return _roughRrofit;}
			set{_roughRrofit = value;}
		}

		/// public propaty name  :  RoughRate
		/// <summary>�e�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double RoughRate
		{
			get{return _roughRate;}
			set{_roughRate = value;}
		}

		/// public propaty name  :  AnswerLimitDate
		/// <summary>�񓚊����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚊����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime AnswerLimitDate
		{
			get{return _answerLimitDate;}
			set{_answerLimitDate = value;}
		}

		/// public propaty name  :  CommentDtl
		/// <summary>���l(����)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���l(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CommentDtl
		{
			get{return _commentDtl;}
			set{_commentDtl = value;}
		}

		/// public propaty name  :  ShelfNo
		/// <summary>�I�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ShelfNo
		{
			get{return _shelfNo;}
			set{_shelfNo = value;}
		}

		/// public propaty name  :  AdditionalDivCd
		/// <summary>�ǉ��敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ǉ��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AdditionalDivCd
		{
			get{return _additionalDivCd;}
			set{_additionalDivCd = value;}
		}

		/// public propaty name  :  CorrectDivCD
		/// <summary>�����敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CorrectDivCD
		{
			get{return _correctDivCD;}
			set{_correctDivCD = value;}
		}

		/// public propaty name  :  InqOrdDivCd
		/// <summary>�⍇���E������ʃv���p�e�B</summary>
		/// <value>1:�⍇�� 2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���E������ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqOrdDivCd
		{
			get{return _inqOrdDivCd;}
			set{_inqOrdDivCd = value;}
		}

		/// public propaty name  :  DisplayOrder
		/// <summary>�\�����ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DisplayOrder
		{
			get{return _displayOrder;}
			set{_displayOrder = value;}
		}

		/// public propaty name  :  LatestDiscCode
		/// <summary>�ŐV���ʋ敪�v���p�e�B</summary>
		/// <value>0:�ŐV�f�[�^ 1:���f�[�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŐV���ʋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int16 LatestDiscCode
		{
			get{return _latestDiscCode;}
			set{_latestDiscCode = value;}
		}

		/// public propaty name  :  BLGoodsName
		/// <summary>BL���i�R�[�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL���i�R�[�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BLGoodsName
		{
			get{return _bLGoodsName;}
			set{_bLGoodsName = value;}
		}

        // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>�D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</summary>
        /// <value>�D�ǐݒ�}�X�^���擾�@��ʃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍ׃R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  PrmSetDtlName2
        /// <summary>�D�ǐݒ�ڍז��̂Q�v���p�e�B</summary>
        /// <value>�D�ǐݒ�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍז��̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrmSetDtlName2
        {
            get { return _prmSetDtlName2; }
            set { _prmSetDtlName2 = value; }
        }

        /// public propaty name  :  StockStatusDiv
        /// <summary>�݌ɏ󋵋敪�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 StockStatusDiv
        {
            get { return _stockStatusDiv; }
            set { _stockStatusDiv = value; }
        }
        // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<

        // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
        /// public propaty name  :  RentDiv
        /// <summary>�ݏo�敪�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݏo�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 RentDiv
        {
            get { return _rentDiv; }
            set { _rentDiv = value; }
        }
        /// public propaty name  :  MkrSuggestRtPric
        /// <summary>���[�J�[��]�������i�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[��]�������i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MkrSuggestRtPric
        {
            get { return _mkrSuggestRtPric; }
            set { _mkrSuggestRtPric = value; }
        }
        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }
        // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<

        // ADD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
        /// public propaty name  :  BgnGoodsDiv
        /// <summary>���������i�I���敪�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������i�I���敪�v���p�e�B�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 BgnGoodsDiv
        {
            get { return _bgnGoodsDiv; }
            set { _bgnGoodsDiv = value; }
        }
        // ADD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<

        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
        /// public propaty name  :  ModelPrtsAdptYm
        /// <summary>�^���ʕ��i�̗p�N���v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���ʕ��i�̗p�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelPrtsAdptYm
        {
            get { return _modelPrtsAdptYm; }
            set { _modelPrtsAdptYm = value; }
        }

        /// public propaty name  :  ModelPrtsAblsYm
        /// <summary>�^���ʕ��i�p�~�N���v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���ʕ��i�p�~�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelPrtsAblsYm
        {
            get { return _modelPrtsAblsYm; }
            set { _modelPrtsAblsYm = value; }
        }

        /// public propaty name  :  ModelPrtsAdptFrameNo
        /// <summary>�^���ʕ��i�̗p�ԑ�ԍ��v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���ʕ��i�̗p�ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelPrtsAdptFrameNo
        {
            get { return _modelPrtsAdptFrameNo; }
            set { _modelPrtsAdptFrameNo = value; }
        }

        /// public propaty name  :  ModelPrtsAblsFrameNo
        /// <summary>�^���ʕ��i�p�~�ԑ�ԍ��v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���ʕ��i�p�~�ԑ�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelPrtsAblsFrameNo
        {
            get { return _modelPrtsAblsFrameNo; }
            set { _modelPrtsAblsFrameNo = value; }
        }
        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<

        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  AnsDeliDateDiv
        /// <summary>�񓚔[���敪�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚔[���敪�v���p�e�B</br>
        /// </remarks>
        public Int16 AnsDeliDateDiv
        {
            get { return _ansDeliDateDiv; }
            set { _ansDeliDateDiv = value; }
        }
        // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
        /// public propaty name  :  GoodsSpecialNtForFac
        /// <summary>���i�K�i�E���L����(�H�����)�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�K�i�E���L����(�H�����)�v���p�e�B</br>
        /// </remarks>
        public string GoodsSpecialNtForFac
        {
            get { return _goodsSpecialNtForFac; }
            set { _goodsSpecialNtForFac = value; }
        }

        /// public propaty name  :  GoodsSpecialNtForCOw
        /// <summary>���i�K�i�E���L����(�J�[�I�[�i�[����)�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�K�i�E���L����(�J�[�I�[�i�[����)�v���p�e�B</br>
        /// </remarks>
        public string GoodsSpecialNtForCOw
        {
            get { return _goodsSpecialNtForCOw; }
            set { _goodsSpecialNtForCOw = value; }
        }

        /// public propaty name  :  PrmSetDtlName2ForFac
        /// <summary>�D�ǐݒ�ڍז��̂Q(�H�����)�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍז��̂Q(�H�����)�v���p�e�B</br>
        /// </remarks>
        public string PrmSetDtlName2ForFac
        {
            get { return _prmSetDtlName2ForFac; }
            set { _prmSetDtlName2ForFac = value; }
        }

        /// public propaty name  :  PrmSetDtlName2ForCOw
        /// <summary>�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�v���p�e�B</br>
        /// </remarks>
        public string PrmSetDtlName2ForCOw
        {
            get { return _prmSetDtlName2ForCOw; }
            set { _prmSetDtlName2ForCOw = value; }
        }
        // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<
        
        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  InqBlUtyPtThCd
        /// <summary>�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�v���p�e�B</summary>
        /// <value>.C �R�[�h�̌n����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqBlUtyPtThCd
        {
            get { return _inqBlUtyPtThCd; }
            set { _inqBlUtyPtThCd = value; }
        }

        /// public propaty name  :  InqBlUtyPtSbCd
        /// <summary>�┭BL���ꕔ�i�T�u�R�[�h�v���p�e�B</summary>
        /// <value>.C �R�[�h�̌n����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �┭BL���ꕔ�i�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InqBlUtyPtSbCd
        {
            get { return _inqBlUtyPtSbCd; }
            set { _inqBlUtyPtSbCd = value; }
        }

        /// public propaty name  :  AnsBlUtyPtThCd
        /// <summary>��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�v���p�e�B</summary>
        /// <value>.C �R�[�h�̌n����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnsBlUtyPtThCd
        {
            get { return _ansBlUtyPtThCd; }
            set { _ansBlUtyPtThCd = value; }
        }

        /// public propaty name  :  AnsBlUtyPtSbCd
        /// <summary>��BL���ꕔ�i�T�u�R�[�h�v���p�e�B</summary>
        /// <value>.C �R�[�h�̌n����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��BL���ꕔ�i�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnsBlUtyPtSbCd
        {
            get { return _ansBlUtyPtSbCd; }
            set { _ansBlUtyPtSbCd = value; }
        }

        /// public propaty name  :  AnsBLGoodsCode
        /// <summary>��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnsBLGoodsCode
        {
            get { return _ansBLGoodsCode; }
            set { _ansBLGoodsCode = value; }
        }

        /// public propaty name  :  AnsBLGoodsDrCode
        /// <summary>��BL���i�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��BL���i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AnsBLGoodsDrCode
        {
            get { return _ansBLGoodsDrCode; }
            set { _ansBLGoodsDrCode = value; }
        }
        // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        
        /// <summary>
		/// SCM�󔭒����׃f�[�^�i�⍇���E�����j�R���X�g���N�^
		/// </summary>
		/// <returns>ScmOdDtInq�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdDtInq�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmOdDtInq()
		{
		}

		/// <summary>
		/// SCM�󔭒����׃f�[�^�i�⍇���E�����j�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
		/// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
		/// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
		/// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
		/// <param name="inquiryNumber">�⍇���ԍ�</param>
		/// <param name="updateDate">�X�V�N����(YYYYMMDD)</param>
		/// <param name="updateTime">�X�V�����b�~���b(HHMMSSXXX)</param>
		/// <param name="inqRowNumber">�⍇���s�ԍ�</param>
		/// <param name="inqRowNumDerivedNo">�⍇���s�ԍ��}��</param>
		/// <param name="inqOrgDtlDiscGuid">�⍇�������׎���GUID</param>
		/// <param name="inqOthDtlDiscGuid">�⍇���斾�׎���GUID(�񓚃f�[�^�̏ꍇ�L���A�⍇���^�������̖���GUID��ݒ�)</param>
		/// <param name="goodsDivCd">���i���(0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ���)</param>
		/// <param name="recyclePrtKindCode">���T�C�N�����i���</param>
		/// <param name="recyclePrtKindName">���T�C�N�����i��ʖ���</param>
		/// <param name="deliveredGoodsDiv">�[�i�敪(0:�z��,1:����)</param>
		/// <param name="handleDivCode">�戵�敪(0:��舵���i,1:�[���m�F��,2:����舵���i)</param>
		/// <param name="goodsShape">���i�`��(1:���i,2:�p�i)</param>
		/// <param name="delivrdGdsConfCd">�[�i�m�F�敪(0:���m�F,1:�m�F)</param>
		/// <param name="deliGdsCmpltDueDate">�[�i�����\���(�[�i�\����t YYYYMMDD)</param>
		/// <param name="answerDeliveryDate">�񓚔[��</param>
		/// <param name="bLGoodsCode">BL���i�R�[�h</param>
		/// <param name="bLGoodsDrCode">BL���i�R�[�h�}��</param>
		/// <param name="inqGoodsName">�┭���i��((���p�S�p����))</param>
		/// <param name="ansGoodsName">�񓚏��i��((���p�S�p����))</param>
		/// <param name="salesOrderCount">������</param>
		/// <param name="deliveredGoodsCount">�[�i��</param>
		/// <param name="goodsNo">���i�ԍ�</param>
		/// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
		/// <param name="goodsMakerNm">���i���[�J�[����</param>
		/// <param name="pureGoodsMakerCd">�������i���[�J�[�R�[�h</param>
		/// <param name="inqPureGoodsNo">�┭�������i�ԍ�((���p�̂�))</param>
		/// <param name="ansPureGoodsNo">�񓚏������i�ԍ�((���p�̂�))</param>
		/// <param name="listPrice">�艿(0:�I�[�v�����i)</param>
		/// <param name="unitPrice">�P��</param>
		/// <param name="goodsAddInfo">���i�⑫���</param>
		/// <param name="roughRrofit">�e���z</param>
		/// <param name="roughRate">�e����</param>
		/// <param name="answerLimitDate">�񓚊���(YYYYMMDD)</param>
		/// <param name="commentDtl">���l(����)</param>
		/// <param name="shelfNo">�I��</param>
		/// <param name="additionalDivCd">�ǉ��敪</param>
		/// <param name="correctDivCD">�����敪</param>
		/// <param name="inqOrdDivCd">�⍇���E�������(1:�⍇�� 2:����)</param>
		/// <param name="displayOrder">�\������</param>
		/// <param name="latestDiscCode">�ŐV���ʋ敪(0:�ŐV�f�[�^ 1:���f�[�^)</param>
		/// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <param name="prmSetDtlNo2">�D�ǐݒ�ڍ׃R�[�h�Q</param>
        /// <param name="prmSetDtlName2">�D�ǐݒ�ڍז��̂Q</param>
        /// <param name="stockStatusDiv">�݌ɏ󋵋敪</param>
        /// <param name="rentDiv">�ݏo�敪</param>
        /// <param name="mkrSuggestRtPric">���[�J�[��]�������i</param>
        /// <param name="openPriceDiv">�I�[�v�����i�敪</param>
        /// <param name="bgnGoodsDiv">���������i�I���敪</param>
        /// <param name="modelPrtsAdptYm">�^���ʕ��i�̗p�N��</param>
        /// <param name="modelPrtsAblsYm">�^���ʕ��i�p�~�N��</param>
        /// <param name="modelPrtsAdptFrameNo">�^���ʕ��i�̗p�ԑ�ԍ�</param>
        /// <param name="modelPrtsAblsFrameNo">�^���ʕ��i�p�~�ԑ�ԍ�</param>
        /// <param name="ansDeliDateDiv">�񓚔[���敪</param>
        /// <param name="goodsSpecialNtForCOw">���i�K�i�E���L����(�H�����)</param>
        /// <param name="goodsSpecialNtForFac">���i�K�i�E���L����(�J�[�I�[�i�[����)</param>
        /// <param name="prmSetDtlName2ForCOw">�D�ǐݒ�ڍז��̂Q(�H�����)</param>
        /// <param name="prmSetDtlName2ForFac">�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)</param>
        /// <param name="inqBlUtyPtThCd">�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)(.C �R�[�h�̌n����)</param>
        /// <param name="inqBlUtyPtSbCd">�┭BL���ꕔ�i�T�u�R�[�h(.C �R�[�h�̌n����)</param>
        /// <param name="ansBlUtyPtThCd">��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)(.C �R�[�h�̌n����)</param>
        /// <param name="ansBlUtyPtSbCd">��BL���ꕔ�i�T�u�R�[�h(.C �R�[�h�̌n����)</param>
        /// <param name="ansBLGoodsCode">��BL���i�R�[�h</param>
        /// <param name="ansBLGoodsDrCode">��BL���i�R�[�h�}��</param>
        /// <returns>ScmOdDtInq�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdDtInq�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
		/// </remarks>
        // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region ���\�[�X
        //// UPD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
        ////public ScmOdDtInq(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, Guid inqOrgDtlDiscGuid, Guid inqOthDtlDiscGuid, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, string shelfNo, Int32 additionalDivCd, Int32 correctDivCD, Int32 inqOrdDivCd, Int32 displayOrder, Int16 latestDiscCode, string bLGoodsName)
        //// UPD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
        ////public ScmOdDtInq(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, Guid inqOrgDtlDiscGuid, Guid inqOthDtlDiscGuid, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, string shelfNo, Int32 additionalDivCd, Int32 correctDivCD, Int32 inqOrdDivCd, Int32 displayOrder, Int16 latestDiscCode, string bLGoodsName, Int32 prmSetDtlNo2, string prmSetDtlName2, Int16 stockStatusDiv)
        //// UPD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
        ////public ScmOdDtInq(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, Guid inqOrgDtlDiscGuid, Guid inqOthDtlDiscGuid, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, string shelfNo, Int32 additionalDivCd, Int32 correctDivCD, Int32 inqOrdDivCd, Int32 displayOrder, Int16 latestDiscCode, string bLGoodsName, Int32 prmSetDtlNo2, string prmSetDtlName2, Int16 stockStatusDiv, Int16 rentDiv, Int64 mkrSuggestRtPric, Int32 openPriceDiv)
        //// UPD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
        ////public ScmOdDtInq(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, Guid inqOrgDtlDiscGuid, Guid inqOthDtlDiscGuid, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, string shelfNo, Int32 additionalDivCd, Int32 correctDivCD, Int32 inqOrdDivCd, Int32 displayOrder, Int16 latestDiscCode, string bLGoodsName, Int32 prmSetDtlNo2, string prmSetDtlName2, Int16 stockStatusDiv, Int16 rentDiv, Int64 mkrSuggestRtPric, Int32 openPriceDiv, Int16 bgnGoodsDiv)
        //public ScmOdDtInq(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, Guid inqOrgDtlDiscGuid, Guid inqOthDtlDiscGuid, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, string shelfNo, Int32 additionalDivCd, Int32 correctDivCD, Int32 inqOrdDivCd, Int32 displayOrder, Int16 latestDiscCode, string bLGoodsName, Int32 prmSetDtlNo2, string prmSetDtlName2, Int16 stockStatusDiv, Int16 rentDiv, Int64 mkrSuggestRtPric, Int32 openPriceDiv, Int16 bgnGoodsDiv, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo, Int32 modelPrtsAblsFrameNo)
        //// UPD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<
        //// UPD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<
        //// UPD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
        //// UPD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<
        #endregion
        public ScmOdDtInq(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, Guid inqOrgDtlDiscGuid, Guid inqOthDtlDiscGuid, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, string shelfNo, Int32 additionalDivCd, Int32 correctDivCD, Int32 inqOrdDivCd, Int32 displayOrder, Int16 latestDiscCode, string bLGoodsName, Int32 prmSetDtlNo2, string prmSetDtlName2, Int16 stockStatusDiv, Int16 rentDiv, Int64 mkrSuggestRtPric, Int32 openPriceDiv, Int16 bgnGoodsDiv, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo, Int32 modelPrtsAblsFrameNo
            , Int16 ansDeliDateDiv
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
            , string goodsSpecialNtForFac
            , string goodsSpecialNtForCOw
            , string prmSetDtlName2ForFac
            , string prmSetDtlName2ForCOw
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            , string inqBlUtyPtThCd
            , Int32 inqBlUtyPtSbCd
            , string ansBlUtyPtThCd
            , Int32 ansBlUtyPtSbCd
            , Int32 ansBLGoodsCode
            , Int32 ansBLGoodsDrCode
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            )
        // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._logicalDeleteCode = logicalDeleteCode;
			this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this._inquiryNumber = inquiryNumber;
			this.UpdateDate = updateDate;
			this._updateTime = updateTime;
			this._inqRowNumber = inqRowNumber;
			this._inqRowNumDerivedNo = inqRowNumDerivedNo;
			this._inqOrgDtlDiscGuid = inqOrgDtlDiscGuid;
			this._inqOthDtlDiscGuid = inqOthDtlDiscGuid;
			this._goodsDivCd = goodsDivCd;
			this._recyclePrtKindCode = recyclePrtKindCode;
			this._recyclePrtKindName = recyclePrtKindName;
			this._deliveredGoodsDiv = deliveredGoodsDiv;
			this._handleDivCode = handleDivCode;
			this._goodsShape = goodsShape;
			this._delivrdGdsConfCd = delivrdGdsConfCd;
			this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
			this._answerDeliveryDate = answerDeliveryDate;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsDrCode = bLGoodsDrCode;
			this._inqGoodsName = inqGoodsName;
			this._ansGoodsName = ansGoodsName;
			this._salesOrderCount = salesOrderCount;
			this._deliveredGoodsCount = deliveredGoodsCount;
			this._goodsNo = goodsNo;
			this._goodsMakerCd = goodsMakerCd;
			this._goodsMakerNm = goodsMakerNm;
			this._pureGoodsMakerCd = pureGoodsMakerCd;
			this._inqPureGoodsNo = inqPureGoodsNo;
			this._ansPureGoodsNo = ansPureGoodsNo;
			this._listPrice = listPrice;
			this._unitPrice = unitPrice;
			this._goodsAddInfo = goodsAddInfo;
			this._roughRrofit = roughRrofit;
			this._roughRate = roughRate;
			this._answerLimitDate = answerLimitDate;
			this._commentDtl = commentDtl;
			this._shelfNo = shelfNo;
			this._additionalDivCd = additionalDivCd;
			this._correctDivCD = correctDivCD;
			this._inqOrdDivCd = inqOrdDivCd;
			this._displayOrder = displayOrder;
			this._latestDiscCode = latestDiscCode;
			this._bLGoodsName = bLGoodsName;
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
            this._prmSetDtlNo2 = prmSetDtlNo2;
            this._prmSetDtlName2 = prmSetDtlName2;
            this._stockStatusDiv = stockStatusDiv;
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<
            // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            this._rentDiv = rentDiv;
            this._mkrSuggestRtPric = mkrSuggestRtPric;
            this._openPriceDiv = openPriceDiv;
            // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
            this._bgnGoodsDiv = bgnGoodsDiv; // ADD 2015/01/19 �L�� ���R�����h�Ή�
            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
            this._modelPrtsAdptYm = modelPrtsAdptYm;
            this._modelPrtsAblsYm = modelPrtsAblsYm;
            this._modelPrtsAdptFrameNo = modelPrtsAdptFrameNo;
            this._modelPrtsAblsFrameNo = modelPrtsAblsFrameNo;
            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._ansDeliDateDiv = ansDeliDateDiv;
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
            this._goodsSpecialNtForFac = goodsSpecialNtForFac;
            this._goodsSpecialNtForCOw = goodsSpecialNtForCOw;
            this._prmSetDtlName2ForFac = prmSetDtlName2ForFac;
            this._prmSetDtlName2ForCOw = prmSetDtlName2ForCOw;
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._inqBlUtyPtThCd = inqBlUtyPtThCd;
            this._inqBlUtyPtSbCd = inqBlUtyPtSbCd;
            this._ansBlUtyPtThCd = ansBlUtyPtThCd;
            this._ansBlUtyPtSbCd = ansBlUtyPtSbCd;
            this._ansBLGoodsCode = ansBLGoodsCode;
            this._ansBLGoodsDrCode = ansBLGoodsDrCode;
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

		/// <summary>
		/// SCM�󔭒����׃f�[�^�i�⍇���E�����j��������
		/// </summary>
		/// <returns>ScmOdDtInq�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ScmOdDtInq�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
		/// </remarks>
		public ScmOdDtInq Clone()
		{
            // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //// UPD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
            ////return new ScmOdDtInq(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._inqRowNumber, this._inqRowNumDerivedNo, this._inqOrgDtlDiscGuid, this._inqOthDtlDiscGuid, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._shelfNo, this._additionalDivCd, this._correctDivCD, this._inqOrdDivCd, this._displayOrder, this._latestDiscCode, this._bLGoodsName);
            //// ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            ////return new ScmOdDtInq(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._inqRowNumber, this._inqRowNumDerivedNo, this._inqOrgDtlDiscGuid, this._inqOthDtlDiscGuid, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._shelfNo, this._additionalDivCd, this._correctDivCD, this._inqOrdDivCd, this._displayOrder, this._latestDiscCode, this._bLGoodsName, this._prmSetDtlNo2, this._prmSetDtlName2, this._stockStatusDiv);
            //// UPD 2015/01/19 �L�� ���R�����h�Ή� --------------------->>>>>
            ////return new ScmOdDtInq(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._inqRowNumber, this._inqRowNumDerivedNo, this._inqOrgDtlDiscGuid, this._inqOthDtlDiscGuid, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._shelfNo, this._additionalDivCd, this._correctDivCD, this._inqOrdDivCd, this._displayOrder, this._latestDiscCode, this._bLGoodsName, this._prmSetDtlNo2, this._prmSetDtlName2, this._stockStatusDiv, this._rentDiv, this._mkrSuggestRtPric, this._openPriceDiv);
            //// UPD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
            ////return new ScmOdDtInq(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._inqRowNumber, this._inqRowNumDerivedNo, this._inqOrgDtlDiscGuid, this._inqOthDtlDiscGuid, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._shelfNo, this._additionalDivCd, this._correctDivCD, this._inqOrdDivCd, this._displayOrder, this._latestDiscCode, this._bLGoodsName, this._prmSetDtlNo2, this._prmSetDtlName2, this._stockStatusDiv, this._rentDiv, this._mkrSuggestRtPric, this._openPriceDiv, this._bgnGoodsDiv);
            //return new ScmOdDtInq(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._inqRowNumber, this._inqRowNumDerivedNo, this._inqOrgDtlDiscGuid, this._inqOthDtlDiscGuid, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._shelfNo, this._additionalDivCd, this._correctDivCD, this._inqOrdDivCd, this._displayOrder, this._latestDiscCode, this._bLGoodsName, this._prmSetDtlNo2, this._prmSetDtlName2, this._stockStatusDiv, this._rentDiv, this._mkrSuggestRtPric, this._openPriceDiv, this._bgnGoodsDiv, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo);
            //// UPD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<
            //// UPD 2015/01/19 �L�� ���R�����h�Ή� ---------------------<<<<<
            //// ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
            //// UPD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<
            #endregion 
            return new ScmOdDtInq(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._inqRowNumber, this._inqRowNumDerivedNo, this._inqOrgDtlDiscGuid, this._inqOthDtlDiscGuid, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._shelfNo, this._additionalDivCd, this._correctDivCD, this._inqOrdDivCd, this._displayOrder, this._latestDiscCode, this._bLGoodsName, this._prmSetDtlNo2, this._prmSetDtlName2, this._stockStatusDiv, this._rentDiv, this._mkrSuggestRtPric, this._openPriceDiv, this._bgnGoodsDiv, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo//@@@@20230303
                ,this._ansDeliDateDiv
                // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
                , this._goodsSpecialNtForFac
                , this._goodsSpecialNtForCOw
                , this._prmSetDtlName2ForFac
                , this._prmSetDtlName2ForCOw
                // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                , this._inqBlUtyPtThCd
                , this._inqBlUtyPtSbCd
                , this._ansBlUtyPtThCd
                , this._ansBlUtyPtSbCd
                , this._ansBLGoodsCode
                , this._ansBLGoodsDrCode
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                );
            // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
		}

		/// <summary>
		/// SCM�󔭒����׃f�[�^�i�⍇���E�����j��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmOdDtInq�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdDtInq�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
		/// </remarks>
		public bool Equals(ScmOdDtInq target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InqOtherEpCd == target.InqOtherEpCd)
				 && (this.InqOtherSecCd == target.InqOtherSecCd)
				 && (this.InquiryNumber == target.InquiryNumber)
				 && (this.UpdateDate == target.UpdateDate)
				 && (this.UpdateTime == target.UpdateTime)
				 && (this.InqRowNumber == target.InqRowNumber)
				 && (this.InqRowNumDerivedNo == target.InqRowNumDerivedNo)
				 && (this.InqOrgDtlDiscGuid == target.InqOrgDtlDiscGuid)
				 && (this.InqOthDtlDiscGuid == target.InqOthDtlDiscGuid)
				 && (this.GoodsDivCd == target.GoodsDivCd)
				 && (this.RecyclePrtKindCode == target.RecyclePrtKindCode)
				 && (this.RecyclePrtKindName == target.RecyclePrtKindName)
				 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
				 && (this.HandleDivCode == target.HandleDivCode)
				 && (this.GoodsShape == target.GoodsShape)
				 && (this.DelivrdGdsConfCd == target.DelivrdGdsConfCd)
				 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
				 && (this.AnswerDeliveryDate == target.AnswerDeliveryDate)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsDrCode == target.BLGoodsDrCode)
				 && (this.InqGoodsName == target.InqGoodsName)
				 && (this.AnsGoodsName == target.AnsGoodsName)
				 && (this.SalesOrderCount == target.SalesOrderCount)
				 && (this.DeliveredGoodsCount == target.DeliveredGoodsCount)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.GoodsMakerNm == target.GoodsMakerNm)
				 && (this.PureGoodsMakerCd == target.PureGoodsMakerCd)
				 && (this.InqPureGoodsNo == target.InqPureGoodsNo)
				 && (this.AnsPureGoodsNo == target.AnsPureGoodsNo)
				 && (this.ListPrice == target.ListPrice)
				 && (this.UnitPrice == target.UnitPrice)
				 && (this.GoodsAddInfo == target.GoodsAddInfo)
				 && (this.RoughRrofit == target.RoughRrofit)
				 && (this.RoughRate == target.RoughRate)
				 && (this.AnswerLimitDate == target.AnswerLimitDate)
				 && (this.CommentDtl == target.CommentDtl)
				 && (this.ShelfNo == target.ShelfNo)
				 && (this.AdditionalDivCd == target.AdditionalDivCd)
				 && (this.CorrectDivCD == target.CorrectDivCD)
				 && (this.InqOrdDivCd == target.InqOrdDivCd)
				 && (this.DisplayOrder == target.DisplayOrder)
				 && (this.LatestDiscCode == target.LatestDiscCode)
				 && (this.BLGoodsName == target.BLGoodsName)
                // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
                 && (this.PrmSetDtlNo2 == target.PrmSetDtlNo2)
                 && (this.PrmSetDtlName2 == target.PrmSetDtlName2)
                 && (this.StockStatusDiv == target.StockStatusDiv)
                // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<
                // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
                 && (this.RentDiv == target.RentDiv)
                 && (this.MkrSuggestRtPric == target.MkrSuggestRtPric)
                 && (this.OpenPriceDiv == target.OpenPriceDiv)
                // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
                 && (this.BgnGoodsDiv == target.BgnGoodsDiv) // ADD 2015/01/19 �L�� ���R�����h�Ή�
                // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
                 && (this.ModelPrtsAdptYm == target.ModelPrtsAdptYm)
                 && (this.ModelPrtsAblsYm == target.ModelPrtsAblsYm)
                 && (this.ModelPrtsAdptFrameNo == target.ModelPrtsAdptFrameNo)
                 && (this.ModelPrtsAblsFrameNo == target.ModelPrtsAblsFrameNo)
                // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (this.AnsDeliDateDiv == target.AnsDeliDateDiv)
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
                 && (this.GoodsSpecialNtForFac == target.GoodsSpecialNtForFac)
                 && (this.GoodsSpecialNtForCOw == target.GoodsSpecialNtForCOw)
                 && (this.PrmSetDtlName2ForFac == target.PrmSetDtlName2ForFac)
                 && (this.PrmSetDtlName2ForCOw == target.PrmSetDtlName2ForCOw)
                // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (this.InqBlUtyPtThCd == target.InqBlUtyPtThCd)
                 && (this.InqBlUtyPtSbCd == target.InqBlUtyPtSbCd)
                 && (this.AnsBlUtyPtThCd == target.AnsBlUtyPtThCd)
                 && (this.AnsBlUtyPtSbCd == target.AnsBlUtyPtSbCd)
                 && (this.AnsBLGoodsCode == target.AnsBLGoodsCode)
                 && (this.AnsBLGoodsDrCode == target.AnsBLGoodsDrCode)
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                 );
		}

		/// <summary>
		/// SCM�󔭒����׃f�[�^�i�⍇���E�����j��r����
		/// </summary>
		/// <param name="scmOdDtInq1">
		///                    ��r����ScmOdDtInq�N���X�̃C���X�^���X
		/// </param>
		/// <param name="scmOdDtInq2">��r����ScmOdDtInq�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdDtInq�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
		/// </remarks>
		public static bool Equals(ScmOdDtInq scmOdDtInq1, ScmOdDtInq scmOdDtInq2)
		{
			return ((scmOdDtInq1.CreateDateTime == scmOdDtInq2.CreateDateTime)
				 && (scmOdDtInq1.UpdateDateTime == scmOdDtInq2.UpdateDateTime)
				 && (scmOdDtInq1.LogicalDeleteCode == scmOdDtInq2.LogicalDeleteCode)
				 && (scmOdDtInq1.InqOriginalEpCd.Trim() == scmOdDtInq2.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (scmOdDtInq1.InqOriginalSecCd == scmOdDtInq2.InqOriginalSecCd)
				 && (scmOdDtInq1.InqOtherEpCd == scmOdDtInq2.InqOtherEpCd)
				 && (scmOdDtInq1.InqOtherSecCd == scmOdDtInq2.InqOtherSecCd)
				 && (scmOdDtInq1.InquiryNumber == scmOdDtInq2.InquiryNumber)
				 && (scmOdDtInq1.UpdateDate == scmOdDtInq2.UpdateDate)
				 && (scmOdDtInq1.UpdateTime == scmOdDtInq2.UpdateTime)
				 && (scmOdDtInq1.InqRowNumber == scmOdDtInq2.InqRowNumber)
				 && (scmOdDtInq1.InqRowNumDerivedNo == scmOdDtInq2.InqRowNumDerivedNo)
				 && (scmOdDtInq1.InqOrgDtlDiscGuid == scmOdDtInq2.InqOrgDtlDiscGuid)
				 && (scmOdDtInq1.InqOthDtlDiscGuid == scmOdDtInq2.InqOthDtlDiscGuid)
				 && (scmOdDtInq1.GoodsDivCd == scmOdDtInq2.GoodsDivCd)
				 && (scmOdDtInq1.RecyclePrtKindCode == scmOdDtInq2.RecyclePrtKindCode)
				 && (scmOdDtInq1.RecyclePrtKindName == scmOdDtInq2.RecyclePrtKindName)
				 && (scmOdDtInq1.DeliveredGoodsDiv == scmOdDtInq2.DeliveredGoodsDiv)
				 && (scmOdDtInq1.HandleDivCode == scmOdDtInq2.HandleDivCode)
				 && (scmOdDtInq1.GoodsShape == scmOdDtInq2.GoodsShape)
				 && (scmOdDtInq1.DelivrdGdsConfCd == scmOdDtInq2.DelivrdGdsConfCd)
				 && (scmOdDtInq1.DeliGdsCmpltDueDate == scmOdDtInq2.DeliGdsCmpltDueDate)
				 && (scmOdDtInq1.AnswerDeliveryDate == scmOdDtInq2.AnswerDeliveryDate)
				 && (scmOdDtInq1.BLGoodsCode == scmOdDtInq2.BLGoodsCode)
				 && (scmOdDtInq1.BLGoodsDrCode == scmOdDtInq2.BLGoodsDrCode)
				 && (scmOdDtInq1.InqGoodsName == scmOdDtInq2.InqGoodsName)
				 && (scmOdDtInq1.AnsGoodsName == scmOdDtInq2.AnsGoodsName)
				 && (scmOdDtInq1.SalesOrderCount == scmOdDtInq2.SalesOrderCount)
				 && (scmOdDtInq1.DeliveredGoodsCount == scmOdDtInq2.DeliveredGoodsCount)
				 && (scmOdDtInq1.GoodsNo == scmOdDtInq2.GoodsNo)
				 && (scmOdDtInq1.GoodsMakerCd == scmOdDtInq2.GoodsMakerCd)
				 && (scmOdDtInq1.GoodsMakerNm == scmOdDtInq2.GoodsMakerNm)
				 && (scmOdDtInq1.PureGoodsMakerCd == scmOdDtInq2.PureGoodsMakerCd)
				 && (scmOdDtInq1.InqPureGoodsNo == scmOdDtInq2.InqPureGoodsNo)
				 && (scmOdDtInq1.AnsPureGoodsNo == scmOdDtInq2.AnsPureGoodsNo)
				 && (scmOdDtInq1.ListPrice == scmOdDtInq2.ListPrice)
				 && (scmOdDtInq1.UnitPrice == scmOdDtInq2.UnitPrice)
				 && (scmOdDtInq1.GoodsAddInfo == scmOdDtInq2.GoodsAddInfo)
				 && (scmOdDtInq1.RoughRrofit == scmOdDtInq2.RoughRrofit)
				 && (scmOdDtInq1.RoughRate == scmOdDtInq2.RoughRate)
				 && (scmOdDtInq1.AnswerLimitDate == scmOdDtInq2.AnswerLimitDate)
				 && (scmOdDtInq1.CommentDtl == scmOdDtInq2.CommentDtl)
				 && (scmOdDtInq1.ShelfNo == scmOdDtInq2.ShelfNo)
				 && (scmOdDtInq1.AdditionalDivCd == scmOdDtInq2.AdditionalDivCd)
				 && (scmOdDtInq1.CorrectDivCD == scmOdDtInq2.CorrectDivCD)
				 && (scmOdDtInq1.InqOrdDivCd == scmOdDtInq2.InqOrdDivCd)
				 && (scmOdDtInq1.DisplayOrder == scmOdDtInq2.DisplayOrder)
				 && (scmOdDtInq1.LatestDiscCode == scmOdDtInq2.LatestDiscCode)
				 && (scmOdDtInq1.BLGoodsName == scmOdDtInq2.BLGoodsName)
                // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
                 && (scmOdDtInq1.PrmSetDtlNo2 == scmOdDtInq2.PrmSetDtlNo2)
                 && (scmOdDtInq1.PrmSetDtlName2 == scmOdDtInq2.PrmSetDtlName2)
                 && (scmOdDtInq1.StockStatusDiv == scmOdDtInq2.StockStatusDiv)
                // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<
                // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
                 && (scmOdDtInq1.RentDiv == scmOdDtInq2.RentDiv)
                 && (scmOdDtInq1.MkrSuggestRtPric == scmOdDtInq2.MkrSuggestRtPric)
                 && (scmOdDtInq1.OpenPriceDiv == scmOdDtInq2.OpenPriceDiv)
                // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
                 && (scmOdDtInq1.BgnGoodsDiv == scmOdDtInq2.BgnGoodsDiv) // ADD 2015/01/19 �L�� ���R�����h�Ή�
                // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
                 && (scmOdDtInq1.ModelPrtsAdptYm == scmOdDtInq2.ModelPrtsAdptYm)
                 && (scmOdDtInq1.ModelPrtsAblsYm == scmOdDtInq2.ModelPrtsAblsYm)
                 && (scmOdDtInq1.ModelPrtsAdptFrameNo == scmOdDtInq2.ModelPrtsAdptFrameNo)
                 && (scmOdDtInq1.ModelPrtsAblsFrameNo == scmOdDtInq2.ModelPrtsAblsFrameNo)
                // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (scmOdDtInq1.AnsDeliDateDiv == scmOdDtInq2.AnsDeliDateDiv)
                // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
                 && (scmOdDtInq1.GoodsSpecialNtForFac == scmOdDtInq2.GoodsSpecialNtForFac)
                 && (scmOdDtInq1.GoodsSpecialNtForCOw == scmOdDtInq2.GoodsSpecialNtForCOw)
                 && (scmOdDtInq1.PrmSetDtlName2ForFac == scmOdDtInq2.PrmSetDtlName2ForFac)
                 && (scmOdDtInq1.PrmSetDtlName2ForCOw == scmOdDtInq2.PrmSetDtlName2ForCOw)
                // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (scmOdDtInq1.InqBlUtyPtThCd == scmOdDtInq2.InqBlUtyPtThCd)
                 && (scmOdDtInq1.InqBlUtyPtSbCd == scmOdDtInq2.InqBlUtyPtSbCd)
                 && (scmOdDtInq1.AnsBlUtyPtThCd == scmOdDtInq2.AnsBlUtyPtThCd)
                 && (scmOdDtInq1.AnsBlUtyPtSbCd == scmOdDtInq2.AnsBlUtyPtSbCd)
                 && (scmOdDtInq1.AnsBLGoodsCode == scmOdDtInq2.AnsBLGoodsCode)
                 && (scmOdDtInq1.AnsBLGoodsDrCode == scmOdDtInq2.AnsBLGoodsDrCode)
                // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                 );
		}
		/// <summary>
		/// SCM�󔭒����׃f�[�^�i�⍇���E�����j��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmOdDtInq�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdDtInq�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
		/// </remarks>
		public ArrayList Compare(ScmOdDtInq target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(this.InqOriginalSecCd != target.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(this.InqOtherEpCd != target.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(this.InqOtherSecCd != target.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(this.InquiryNumber != target.InquiryNumber)resList.Add("InquiryNumber");
			if(this.UpdateDate != target.UpdateDate)resList.Add("UpdateDate");
			if(this.UpdateTime != target.UpdateTime)resList.Add("UpdateTime");
			if(this.InqRowNumber != target.InqRowNumber)resList.Add("InqRowNumber");
			if(this.InqRowNumDerivedNo != target.InqRowNumDerivedNo)resList.Add("InqRowNumDerivedNo");
			if(this.InqOrgDtlDiscGuid != target.InqOrgDtlDiscGuid)resList.Add("InqOrgDtlDiscGuid");
			if(this.InqOthDtlDiscGuid != target.InqOthDtlDiscGuid)resList.Add("InqOthDtlDiscGuid");
			if(this.GoodsDivCd != target.GoodsDivCd)resList.Add("GoodsDivCd");
			if(this.RecyclePrtKindCode != target.RecyclePrtKindCode)resList.Add("RecyclePrtKindCode");
			if(this.RecyclePrtKindName != target.RecyclePrtKindName)resList.Add("RecyclePrtKindName");
			if(this.DeliveredGoodsDiv != target.DeliveredGoodsDiv)resList.Add("DeliveredGoodsDiv");
			if(this.HandleDivCode != target.HandleDivCode)resList.Add("HandleDivCode");
			if(this.GoodsShape != target.GoodsShape)resList.Add("GoodsShape");
			if(this.DelivrdGdsConfCd != target.DelivrdGdsConfCd)resList.Add("DelivrdGdsConfCd");
			if(this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(this.AnswerDeliveryDate != target.AnswerDeliveryDate)resList.Add("AnswerDeliveryDate");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsDrCode != target.BLGoodsDrCode)resList.Add("BLGoodsDrCode");
			if(this.InqGoodsName != target.InqGoodsName)resList.Add("InqGoodsName");
			if(this.AnsGoodsName != target.AnsGoodsName)resList.Add("AnsGoodsName");
			if(this.SalesOrderCount != target.SalesOrderCount)resList.Add("SalesOrderCount");
			if(this.DeliveredGoodsCount != target.DeliveredGoodsCount)resList.Add("DeliveredGoodsCount");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.GoodsMakerNm != target.GoodsMakerNm)resList.Add("GoodsMakerNm");
			if(this.PureGoodsMakerCd != target.PureGoodsMakerCd)resList.Add("PureGoodsMakerCd");
			if(this.InqPureGoodsNo != target.InqPureGoodsNo)resList.Add("InqPureGoodsNo");
			if(this.AnsPureGoodsNo != target.AnsPureGoodsNo)resList.Add("AnsPureGoodsNo");
			if(this.ListPrice != target.ListPrice)resList.Add("ListPrice");
			if(this.UnitPrice != target.UnitPrice)resList.Add("UnitPrice");
			if(this.GoodsAddInfo != target.GoodsAddInfo)resList.Add("GoodsAddInfo");
			if(this.RoughRrofit != target.RoughRrofit)resList.Add("RoughRrofit");
			if(this.RoughRate != target.RoughRate)resList.Add("RoughRate");
			if(this.AnswerLimitDate != target.AnswerLimitDate)resList.Add("AnswerLimitDate");
			if(this.CommentDtl != target.CommentDtl)resList.Add("CommentDtl");
			if(this.ShelfNo != target.ShelfNo)resList.Add("ShelfNo");
			if(this.AdditionalDivCd != target.AdditionalDivCd)resList.Add("AdditionalDivCd");
			if(this.CorrectDivCD != target.CorrectDivCD)resList.Add("CorrectDivCD");
			if(this.InqOrdDivCd != target.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(this.DisplayOrder != target.DisplayOrder)resList.Add("DisplayOrder");
			if(this.LatestDiscCode != target.LatestDiscCode)resList.Add("LatestDiscCode");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
            if (this.PrmSetDtlNo2 != target.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (this.PrmSetDtlName2 != target.PrmSetDtlName2) resList.Add("PrmSetDtlName2");
            if (this.StockStatusDiv != target.StockStatusDiv) resList.Add("StockStatusDiv");
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<
            // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            if (this.RentDiv != target.RentDiv) resList.Add("RentDiv");
            if (this.MkrSuggestRtPric != target.MkrSuggestRtPric) resList.Add("MkrSuggestRtPric");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");
            // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
            if (this.BgnGoodsDiv != target.BgnGoodsDiv) resList.Add("BgnGoodsDiv"); // ADD 2015/01/19 �L�� ���R�����h�Ή�
            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
            if (this.ModelPrtsAdptYm != target.ModelPrtsAdptYm) resList.Add("ModelPrtsAdptYm");
            if (this.ModelPrtsAblsYm != target.ModelPrtsAblsYm) resList.Add("ModelPrtsAblsYm");
            if (this.ModelPrtsAdptFrameNo != target.ModelPrtsAdptFrameNo) resList.Add("ModelPrtsAdptFrameNo");
            if (this.ModelPrtsAblsFrameNo != target.ModelPrtsAblsFrameNo) resList.Add("ModelPrtsAblsFrameNo");
            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.AnsDeliDateDiv != target.AnsDeliDateDiv) resList.Add("AnsDeliDateDiv");
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
            if (this.GoodsSpecialNtForFac != target.GoodsSpecialNtForFac) resList.Add("GoodsSpecialNtForFac");
            if (this.GoodsSpecialNtForCOw != target.GoodsSpecialNtForCOw) resList.Add("GoodsSpecialNtForCOw");
            if (this.PrmSetDtlName2ForFac != target.PrmSetDtlName2ForFac) resList.Add("PrmSetDtlName2ForFac");
            if (this.PrmSetDtlName2ForCOw != target.PrmSetDtlName2ForCOw) resList.Add("PrmSetDtlName2ForCOw");
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.InqBlUtyPtThCd != target.InqBlUtyPtThCd) resList.Add("InqBlUtyPtThCd");
            if (this.InqBlUtyPtSbCd != target.InqBlUtyPtSbCd) resList.Add("InqBlUtyPtSbCd");
            if (this.AnsBlUtyPtThCd != target.AnsBlUtyPtThCd) resList.Add("AnsBlUtyPtThCd");
            if (this.AnsBlUtyPtSbCd != target.AnsBlUtyPtSbCd) resList.Add("AnsBlUtyPtSbCd");
            if (this.AnsBLGoodsCode != target.AnsBLGoodsCode) resList.Add("AnsBLGoodsCode");
            if (this.AnsBLGoodsDrCode != target.AnsBLGoodsDrCode) resList.Add("AnsBLGoodsDrCode");
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

			return resList;
		}

		/// <summary>
		/// SCM�󔭒����׃f�[�^�i�⍇���E�����j��r����
		/// </summary>
		/// <param name="scmOdDtInq1">��r����ScmOdDtInq�N���X�̃C���X�^���X</param>
		/// <param name="scmOdDtInq2">��r����ScmOdDtInq�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdDtInq�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2018/04/16 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
		/// </remarks>
		public static ArrayList Compare(ScmOdDtInq scmOdDtInq1, ScmOdDtInq scmOdDtInq2)
		{
			ArrayList resList = new ArrayList();
			if(scmOdDtInq1.CreateDateTime != scmOdDtInq2.CreateDateTime)resList.Add("CreateDateTime");
			if(scmOdDtInq1.UpdateDateTime != scmOdDtInq2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(scmOdDtInq1.LogicalDeleteCode != scmOdDtInq2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(scmOdDtInq1.InqOriginalEpCd.Trim() != scmOdDtInq2.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(scmOdDtInq1.InqOriginalSecCd != scmOdDtInq2.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(scmOdDtInq1.InqOtherEpCd != scmOdDtInq2.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(scmOdDtInq1.InqOtherSecCd != scmOdDtInq2.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(scmOdDtInq1.InquiryNumber != scmOdDtInq2.InquiryNumber)resList.Add("InquiryNumber");
			if(scmOdDtInq1.UpdateDate != scmOdDtInq2.UpdateDate)resList.Add("UpdateDate");
			if(scmOdDtInq1.UpdateTime != scmOdDtInq2.UpdateTime)resList.Add("UpdateTime");
			if(scmOdDtInq1.InqRowNumber != scmOdDtInq2.InqRowNumber)resList.Add("InqRowNumber");
			if(scmOdDtInq1.InqRowNumDerivedNo != scmOdDtInq2.InqRowNumDerivedNo)resList.Add("InqRowNumDerivedNo");
			if(scmOdDtInq1.InqOrgDtlDiscGuid != scmOdDtInq2.InqOrgDtlDiscGuid)resList.Add("InqOrgDtlDiscGuid");
			if(scmOdDtInq1.InqOthDtlDiscGuid != scmOdDtInq2.InqOthDtlDiscGuid)resList.Add("InqOthDtlDiscGuid");
			if(scmOdDtInq1.GoodsDivCd != scmOdDtInq2.GoodsDivCd)resList.Add("GoodsDivCd");
			if(scmOdDtInq1.RecyclePrtKindCode != scmOdDtInq2.RecyclePrtKindCode)resList.Add("RecyclePrtKindCode");
			if(scmOdDtInq1.RecyclePrtKindName != scmOdDtInq2.RecyclePrtKindName)resList.Add("RecyclePrtKindName");
			if(scmOdDtInq1.DeliveredGoodsDiv != scmOdDtInq2.DeliveredGoodsDiv)resList.Add("DeliveredGoodsDiv");
			if(scmOdDtInq1.HandleDivCode != scmOdDtInq2.HandleDivCode)resList.Add("HandleDivCode");
			if(scmOdDtInq1.GoodsShape != scmOdDtInq2.GoodsShape)resList.Add("GoodsShape");
			if(scmOdDtInq1.DelivrdGdsConfCd != scmOdDtInq2.DelivrdGdsConfCd)resList.Add("DelivrdGdsConfCd");
			if(scmOdDtInq1.DeliGdsCmpltDueDate != scmOdDtInq2.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(scmOdDtInq1.AnswerDeliveryDate != scmOdDtInq2.AnswerDeliveryDate)resList.Add("AnswerDeliveryDate");
			if(scmOdDtInq1.BLGoodsCode != scmOdDtInq2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(scmOdDtInq1.BLGoodsDrCode != scmOdDtInq2.BLGoodsDrCode)resList.Add("BLGoodsDrCode");
			if(scmOdDtInq1.InqGoodsName != scmOdDtInq2.InqGoodsName)resList.Add("InqGoodsName");
			if(scmOdDtInq1.AnsGoodsName != scmOdDtInq2.AnsGoodsName)resList.Add("AnsGoodsName");
			if(scmOdDtInq1.SalesOrderCount != scmOdDtInq2.SalesOrderCount)resList.Add("SalesOrderCount");
			if(scmOdDtInq1.DeliveredGoodsCount != scmOdDtInq2.DeliveredGoodsCount)resList.Add("DeliveredGoodsCount");
			if(scmOdDtInq1.GoodsNo != scmOdDtInq2.GoodsNo)resList.Add("GoodsNo");
			if(scmOdDtInq1.GoodsMakerCd != scmOdDtInq2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(scmOdDtInq1.GoodsMakerNm != scmOdDtInq2.GoodsMakerNm)resList.Add("GoodsMakerNm");
			if(scmOdDtInq1.PureGoodsMakerCd != scmOdDtInq2.PureGoodsMakerCd)resList.Add("PureGoodsMakerCd");
			if(scmOdDtInq1.InqPureGoodsNo != scmOdDtInq2.InqPureGoodsNo)resList.Add("InqPureGoodsNo");
			if(scmOdDtInq1.AnsPureGoodsNo != scmOdDtInq2.AnsPureGoodsNo)resList.Add("AnsPureGoodsNo");
			if(scmOdDtInq1.ListPrice != scmOdDtInq2.ListPrice)resList.Add("ListPrice");
			if(scmOdDtInq1.UnitPrice != scmOdDtInq2.UnitPrice)resList.Add("UnitPrice");
			if(scmOdDtInq1.GoodsAddInfo != scmOdDtInq2.GoodsAddInfo)resList.Add("GoodsAddInfo");
			if(scmOdDtInq1.RoughRrofit != scmOdDtInq2.RoughRrofit)resList.Add("RoughRrofit");
			if(scmOdDtInq1.RoughRate != scmOdDtInq2.RoughRate)resList.Add("RoughRate");
			if(scmOdDtInq1.AnswerLimitDate != scmOdDtInq2.AnswerLimitDate)resList.Add("AnswerLimitDate");
			if(scmOdDtInq1.CommentDtl != scmOdDtInq2.CommentDtl)resList.Add("CommentDtl");
			if(scmOdDtInq1.ShelfNo != scmOdDtInq2.ShelfNo)resList.Add("ShelfNo");
			if(scmOdDtInq1.AdditionalDivCd != scmOdDtInq2.AdditionalDivCd)resList.Add("AdditionalDivCd");
			if(scmOdDtInq1.CorrectDivCD != scmOdDtInq2.CorrectDivCD)resList.Add("CorrectDivCD");
			if(scmOdDtInq1.InqOrdDivCd != scmOdDtInq2.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(scmOdDtInq1.DisplayOrder != scmOdDtInq2.DisplayOrder)resList.Add("DisplayOrder");
			if(scmOdDtInq1.LatestDiscCode != scmOdDtInq2.LatestDiscCode)resList.Add("LatestDiscCode");
			if(scmOdDtInq1.BLGoodsName != scmOdDtInq2.BLGoodsName)resList.Add("BLGoodsName");
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------------------->>>>>
            if (scmOdDtInq1.PrmSetDtlNo2 != scmOdDtInq2.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (scmOdDtInq1.PrmSetDtlName2 != scmOdDtInq2.PrmSetDtlName2) resList.Add("PrmSetDtlName2");
            if (scmOdDtInq1.StockStatusDiv != scmOdDtInq2.StockStatusDiv) resList.Add("StockStatusDiv");
            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------------------<<<<<
            // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            if (scmOdDtInq1.RentDiv != scmOdDtInq2.RentDiv) resList.Add("RentDiv");
            if (scmOdDtInq1.MkrSuggestRtPric != scmOdDtInq2.MkrSuggestRtPric) resList.Add("MkrSuggestRtPric");
            if (scmOdDtInq1.OpenPriceDiv != scmOdDtInq2.OpenPriceDiv) resList.Add("OpenPriceDiv");
            // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
            if (scmOdDtInq1.BgnGoodsDiv != scmOdDtInq2.BgnGoodsDiv) resList.Add("BgnGoodsDiv"); // ADD 2015/01/19 �L�� ���R�����h�Ή�
            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
            if (scmOdDtInq1.ModelPrtsAdptYm != scmOdDtInq2.ModelPrtsAdptYm) resList.Add("ModelPrtsAdptYm");
            if (scmOdDtInq1.ModelPrtsAblsYm != scmOdDtInq2.ModelPrtsAblsYm) resList.Add("ModelPrtsAblsYm");
            if (scmOdDtInq1.ModelPrtsAdptFrameNo != scmOdDtInq2.ModelPrtsAdptFrameNo) resList.Add("ModelPrtsAdptFrameNo");
            if (scmOdDtInq1.ModelPrtsAblsFrameNo != scmOdDtInq2.ModelPrtsAblsFrameNo) resList.Add("ModelPrtsAblsFrameNo");
            // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (scmOdDtInq1.AnsDeliDateDiv != scmOdDtInq2.AnsDeliDateDiv) resList.Add("AnsDeliDateDiv");
            // ADD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ---------->>>>>>>>>>
            if (scmOdDtInq1.GoodsSpecialNtForFac != scmOdDtInq2.GoodsSpecialNtForFac) resList.Add("GoodsSpecialNtForFac");
            if (scmOdDtInq1.GoodsSpecialNtForCOw != scmOdDtInq2.GoodsSpecialNtForCOw) resList.Add("GoodsSpecialNtForCOw");
            if (scmOdDtInq1.PrmSetDtlName2ForFac != scmOdDtInq2.PrmSetDtlName2ForFac) resList.Add("PrmSetDtlName2ForFac");
            if (scmOdDtInq1.PrmSetDtlName2ForCOw != scmOdDtInq2.PrmSetDtlName2ForCOw) resList.Add("PrmSetDtlName2ForCOw");
            // 2015/02/20 ADD TAKAGAWA SCM������ C������ʁE���L�����Ή� ----------<<<<<<<<<<
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (scmOdDtInq1.InqBlUtyPtThCd != scmOdDtInq2.InqBlUtyPtThCd) resList.Add("InqBlUtyPtThCd");
            if (scmOdDtInq1.InqBlUtyPtSbCd != scmOdDtInq2.InqBlUtyPtSbCd) resList.Add("InqBlUtyPtSbCd");
            if (scmOdDtInq1.AnsBlUtyPtThCd != scmOdDtInq2.AnsBlUtyPtThCd) resList.Add("AnsBlUtyPtThCd");
            if (scmOdDtInq1.AnsBlUtyPtSbCd != scmOdDtInq2.AnsBlUtyPtSbCd) resList.Add("AnsBlUtyPtSbCd");
            if (scmOdDtInq1.AnsBLGoodsCode != scmOdDtInq2.AnsBLGoodsCode) resList.Add("AnsBLGoodsCode");
            if (scmOdDtInq1.AnsBLGoodsDrCode != scmOdDtInq2.AnsBLGoodsDrCode) resList.Add("AnsBLGoodsDrCode");
            // ADD 2018/04/16 �c���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

			return resList;
		}
	}
}

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmOdDtInq
	/// <summary>
	///                      SCM�󔭒����׃f�[�^�i�⍇���E�����j
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�󔭒����׃f�[�^�i�⍇���E�����j�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/2/20</br>
	/// <br>Genarated Date   :   2011/08/05  (CSharp File Generated Date)</br>
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
	/// <br>Update Note      :   2009/6/1  ��{�@�E</br>
	/// <br>                 :   ���i���[�J�[���̒ǉ��A�������i���[�J�[</br>
	/// <br>                 :   �R�[�h�̌����ύX</br>
	/// <br>Update Note      :   2009/6/11  ����@�_�u</br>
	/// <br>                 :   ���i���i�J�i�j�A�������i�ԍ�</br>
	/// <br>                 :   �폜</br>
	/// <br>                 :   �┭���i���A�񓚏��i���A�┭�������i�ԍ�</br>
	/// <br>                 :   �񓚏������i�ԍ�</br>
	/// <br>                 :   �ǉ�</br>
	/// <br>Update Note      :   2010/5/17  �����@���l</br>
	/// <br>                 :   �L�����Z����ԋ敪�APM�󒍃X�e�[�^�X</br>
	/// <br>                 :   PM����`�[�ԍ��APM����s�ԍ�</br>
	/// <br>                 :   �ǉ�</br>
	/// <br>                 :   ���i��ʂ̔��l�ɒl������ǉ�</br>
	/// <br>Update Note      :   2011/2/1  ����@�_�u</br>
	/// <br>                 :   ���׎捞�敪</br>
	/// <br>                 :   �ǉ�</br>
	/// <br>Update Note      :   2011/4/19  �����@���l</br>
	/// <br>                 :   PM�q�ɃR�[�h</br>
	/// <br>                 :   PM�q�ɖ���</br>
	/// <br>                 :   PM�I��</br>
	/// <br>                 :   �ǉ�</br>
	/// <br>Update Note      :   2011/8/1  �A�c�@�m�O</br>
	/// <br>                 :   PM���݌�</br>
	/// <br>                 :   �Z�b�g���i���[�J�[�R�[�h</br>
	/// <br>                 :   �Z�b�g���i�ԍ�</br>
	/// <br>                 :   �Z�b�g���i�e�q�ԍ�</br>
	/// <br>                 :   �ǉ�</br>
	/// </remarks>
	[Serializable]
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
		/// <remarks>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ��� 99:�l����</remarks>
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

		/// <summary>�L�����Z����ԋ敪</summary>
		/// <remarks>0:�L�����Z���Ȃ� 10:�L�����Z���v�� 20:�L�����Z���p�� 30:�L�����Z���m��</remarks>
		private Int16 _cancelCndtinDiv;

		/// <summary>PM�󒍃X�e�[�^�X</summary>
		/// <remarks>10�F���� 20:�� 30:���� 40:�o��</remarks>
		private Int32 _pMAcptAnOdrStatus;

		/// <summary>PM����`�[�ԍ�</summary>
		/// <remarks>PM�̔���`�[�ԍ�</remarks>
		private Int32 _pMSalesSlipNum;

		/// <summary>PM����s�ԍ�</summary>
		private Int32 _pMSalesRowNo;

		/// <summary>���׎捞�敪</summary>
		/// <remarks>0:���捞 1:�捞��</remarks>
		private Int32 _dtlTakeinDivCd;

		/// <summary>PM�q�ɃR�[�h</summary>
		private string _pmWarehouseCd = "";

		/// <summary>PM�q�ɖ���</summary>
		private string _pmWarehouseName = "";

		/// <summary>PM�I��</summary>
		private string _pmShelfNo = "";

		/// <summary>PM���݌�</summary>
		private Double _pmPrsntCount;

		/// <summary>�Z�b�g���i���[�J�[�R�[�h</summary>
		private Int32 _setPartsMkrCd;

		/// <summary>�Z�b�g���i�ԍ�</summary>
		private string _setPartsNumber = "";

		/// <summary>�Z�b�g���i�e�q�ԍ�</summary>
		/// <remarks>0:�e,1-*:�q</remarks>
		private Int32 _setPartsMainSubNo;


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
			get { return _createDateTime; }
			set { _createDateTime = value; }
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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
			set { }
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
			get { return _updateDateTime; }
			set { _updateDateTime = value; }
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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
			set { }
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
			get { return _logicalDeleteCode; }
			set { _logicalDeleteCode = value; }
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
			get { return _inqOriginalEpCd; }
			set { _inqOriginalEpCd = value; }
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
			get { return _inqOriginalSecCd; }
			set { _inqOriginalSecCd = value; }
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
			get { return _inqOtherEpCd; }
			set { _inqOtherEpCd = value; }
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
			get { return _inqOtherSecCd; }
			set { _inqOtherSecCd = value; }
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
			get { return _inquiryNumber; }
			set { _inquiryNumber = value; }
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
			get { return _updateDate; }
			set { _updateDate = value; }
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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDate); }
			set { }
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
			get { return _updateTime; }
			set { _updateTime = value; }
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
			get { return _inqRowNumber; }
			set { _inqRowNumber = value; }
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
			get { return _inqRowNumDerivedNo; }
			set { _inqRowNumDerivedNo = value; }
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
			get { return _inqOrgDtlDiscGuid; }
			set { _inqOrgDtlDiscGuid = value; }
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
			get { return _inqOthDtlDiscGuid; }
			set { _inqOthDtlDiscGuid = value; }
		}

		/// public propaty name  :  GoodsDivCd
		/// <summary>���i��ʃv���p�e�B</summary>
		/// <value>0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ��� 99:�l����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GoodsDivCd
		{
			get { return _goodsDivCd; }
			set { _goodsDivCd = value; }
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
			get { return _recyclePrtKindCode; }
			set { _recyclePrtKindCode = value; }
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
			get { return _recyclePrtKindName; }
			set { _recyclePrtKindName = value; }
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
			get { return _deliveredGoodsDiv; }
			set { _deliveredGoodsDiv = value; }
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
			get { return _handleDivCode; }
			set { _handleDivCode = value; }
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
			get { return _goodsShape; }
			set { _goodsShape = value; }
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
			get { return _delivrdGdsConfCd; }
			set { _delivrdGdsConfCd = value; }
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
			get { return _deliGdsCmpltDueDate; }
			set { _deliGdsCmpltDueDate = value; }
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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _deliGdsCmpltDueDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _deliGdsCmpltDueDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _deliGdsCmpltDueDate); }
			set { }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _deliGdsCmpltDueDate); }
			set { }
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
			get { return _answerDeliveryDate; }
			set { _answerDeliveryDate = value; }
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
			get { return _bLGoodsCode; }
			set { _bLGoodsCode = value; }
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
			get { return _bLGoodsDrCode; }
			set { _bLGoodsDrCode = value; }
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
			get { return _inqGoodsName; }
			set { _inqGoodsName = value; }
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
			get { return _ansGoodsName; }
			set { _ansGoodsName = value; }
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
			get { return _salesOrderCount; }
			set { _salesOrderCount = value; }
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
			get { return _deliveredGoodsCount; }
			set { _deliveredGoodsCount = value; }
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
			get { return _goodsNo; }
			set { _goodsNo = value; }
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
			get { return _goodsMakerCd; }
			set { _goodsMakerCd = value; }
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
			get { return _goodsMakerNm; }
			set { _goodsMakerNm = value; }
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
			get { return _pureGoodsMakerCd; }
			set { _pureGoodsMakerCd = value; }
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
			get { return _inqPureGoodsNo; }
			set { _inqPureGoodsNo = value; }
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
			get { return _ansPureGoodsNo; }
			set { _ansPureGoodsNo = value; }
		}

		/// public propaty name  :  ListPrice
		/// <summary>�艿�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �艿�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 ListPrice
		{
			get { return _listPrice; }
			set { _listPrice = value; }
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
			get { return _unitPrice; }
			set { _unitPrice = value; }
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
			get { return _goodsAddInfo; }
			set { _goodsAddInfo = value; }
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
			get { return _roughRrofit; }
			set { _roughRrofit = value; }
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
			get { return _roughRate; }
			set { _roughRate = value; }
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
			get { return _answerLimitDate; }
			set { _answerLimitDate = value; }
		}

		/// public propaty name  :  AnswerLimitDateJpFormal
		/// <summary>�񓚊��� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚊��� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnswerLimitDateJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _answerLimitDate); }
			set { }
		}

		/// public propaty name  :  AnswerLimitDateJpInFormal
		/// <summary>�񓚊��� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚊��� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnswerLimitDateJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _answerLimitDate); }
			set { }
		}

		/// public propaty name  :  AnswerLimitDateAdFormal
		/// <summary>�񓚊��� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚊��� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnswerLimitDateAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _answerLimitDate); }
			set { }
		}

		/// public propaty name  :  AnswerLimitDateAdInFormal
		/// <summary>�񓚊��� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚊��� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnswerLimitDateAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _answerLimitDate); }
			set { }
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
			get { return _commentDtl; }
			set { _commentDtl = value; }
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
			get { return _shelfNo; }
			set { _shelfNo = value; }
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
			get { return _additionalDivCd; }
			set { _additionalDivCd = value; }
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
			get { return _correctDivCD; }
			set { _correctDivCD = value; }
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
			get { return _inqOrdDivCd; }
			set { _inqOrdDivCd = value; }
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
			get { return _displayOrder; }
			set { _displayOrder = value; }
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
			get { return _latestDiscCode; }
			set { _latestDiscCode = value; }
		}

		/// public propaty name  :  CancelCndtinDiv
		/// <summary>�L�����Z����ԋ敪�v���p�e�B</summary>
		/// <value>0:�L�����Z���Ȃ� 10:�L�����Z���v�� 20:�L�����Z���p�� 30:�L�����Z���m��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�����Z����ԋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int16 CancelCndtinDiv
		{
			get { return _cancelCndtinDiv; }
			set { _cancelCndtinDiv = value; }
		}

		/// public propaty name  :  PMAcptAnOdrStatus
		/// <summary>PM�󒍃X�e�[�^�X�v���p�e�B</summary>
		/// <value>10�F���� 20:�� 30:���� 40:�o��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM�󒍃X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PMAcptAnOdrStatus
		{
			get { return _pMAcptAnOdrStatus; }
			set { _pMAcptAnOdrStatus = value; }
		}

		/// public propaty name  :  PMSalesSlipNum
		/// <summary>PM����`�[�ԍ��v���p�e�B</summary>
		/// <value>PM�̔���`�[�ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PMSalesSlipNum
		{
			get { return _pMSalesSlipNum; }
			set { _pMSalesSlipNum = value; }
		}

		/// public propaty name  :  PMSalesRowNo
		/// <summary>PM����s�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM����s�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PMSalesRowNo
		{
			get { return _pMSalesRowNo; }
			set { _pMSalesRowNo = value; }
		}

		/// public propaty name  :  DtlTakeinDivCd
		/// <summary>���׎捞�敪�v���p�e�B</summary>
		/// <value>0:���捞 1:�捞��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���׎捞�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DtlTakeinDivCd
		{
			get { return _dtlTakeinDivCd; }
			set { _dtlTakeinDivCd = value; }
		}

		/// public propaty name  :  PmWarehouseCd
		/// <summary>PM�q�ɃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM�q�ɃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PmWarehouseCd
		{
			get { return _pmWarehouseCd; }
			set { _pmWarehouseCd = value; }
		}

		/// public propaty name  :  PmWarehouseName
		/// <summary>PM�q�ɖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM�q�ɖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PmWarehouseName
		{
			get { return _pmWarehouseName; }
			set { _pmWarehouseName = value; }
		}

		/// public propaty name  :  PmShelfNo
		/// <summary>PM�I�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM�I�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PmShelfNo
		{
			get { return _pmShelfNo; }
			set { _pmShelfNo = value; }
		}

		/// public propaty name  :  PmPrsntCount
		/// <summary>PM���݌��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   PM���݌��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double PmPrsntCount
		{
			get{return _pmPrsntCount;}
			set{_pmPrsntCount = value;}
		}

		/// public propaty name  :  SetPartsMkrCd
		/// <summary>�Z�b�g���i���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g���i���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SetPartsMkrCd
		{
			get{return _setPartsMkrCd;}
			set{_setPartsMkrCd = value;}
		}

		/// public propaty name  :  SetPartsNumber
		/// <summary>�Z�b�g���i�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g���i�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SetPartsNumber
		{
			get{return _setPartsNumber;}
			set{_setPartsNumber = value;}
		}

		/// public propaty name  :  SetPartsMainSubNo
		/// <summary>�Z�b�g���i�e�q�ԍ��v���p�e�B</summary>
		/// <value>0:�e,1-*:�q</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�b�g���i�e�q�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SetPartsMainSubNo
		{
			get{return _setPartsMainSubNo;}
			set{_setPartsMainSubNo = value;}
		}


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
		/// <param name="goodsDivCd">���i���(0:�������i 1:�D�Ǖ��i 2:���T�C�N�����i 3:���ϑ��� 99:�l����)</param>
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
		/// <param name="listPrice">�艿</param>
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
		/// <param name="cancelCndtinDiv">�L�����Z����ԋ敪(0:�L�����Z���Ȃ� 10:�L�����Z���v�� 20:�L�����Z���p�� 30:�L�����Z���m��)</param>
		/// <param name="pMAcptAnOdrStatus">PM�󒍃X�e�[�^�X(10�F���� 20:�� 30:���� 40:�o��)</param>
		/// <param name="pMSalesSlipNum">PM����`�[�ԍ�(PM�̔���`�[�ԍ�)</param>
		/// <param name="pMSalesRowNo">PM����s�ԍ�</param>
		/// <param name="dtlTakeinDivCd">���׎捞�敪(0:���捞 1:�捞��)</param>
		/// <param name="pmWarehouseCd">PM�q�ɃR�[�h</param>
		/// <param name="pmWarehouseName">PM�q�ɖ���</param>
		/// <param name="pmShelfNo">PM�I��</param>
		/// <param name="pmPrsntCount">PM���݌�</param>
		/// <param name="setPartsMkrCd">�Z�b�g���i���[�J�[�R�[�h</param>
		/// <param name="setPartsNumber">�Z�b�g���i�ԍ�</param>
		/// <param name="setPartsMainSubNo">�Z�b�g���i�e�q�ԍ�(0:�e,1-*:�q)</param>
		/// <returns>ScmOdDtInq�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdDtInq�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmOdDtInq(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, Guid inqOrgDtlDiscGuid, Guid inqOthDtlDiscGuid, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, string shelfNo, Int32 additionalDivCd, Int32 correctDivCD, Int32 inqOrdDivCd, Int32 displayOrder, Int16 latestDiscCode, Int16 cancelCndtinDiv, Int32 pMAcptAnOdrStatus, Int32 pMSalesSlipNum, Int32 pMSalesRowNo, Int32 dtlTakeinDivCd, string pmWarehouseCd, string pmWarehouseName, string pmShelfNo,Double pmPrsntCount,Int32 setPartsMkrCd,string setPartsNumber,Int32 setPartsMainSubNo)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._logicalDeleteCode = logicalDeleteCode;
			this._inqOriginalEpCd = inqOriginalEpCd;
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
			this.AnswerLimitDate = answerLimitDate;
			this._commentDtl = commentDtl;
			this._shelfNo = shelfNo;
			this._additionalDivCd = additionalDivCd;
			this._correctDivCD = correctDivCD;
			this._inqOrdDivCd = inqOrdDivCd;
			this._displayOrder = displayOrder;
			this._latestDiscCode = latestDiscCode;
			this._cancelCndtinDiv = cancelCndtinDiv;
			this._pMAcptAnOdrStatus = pMAcptAnOdrStatus;
			this._pMSalesSlipNum = pMSalesSlipNum;
			this._pMSalesRowNo = pMSalesRowNo;
			this._dtlTakeinDivCd = dtlTakeinDivCd;
			this._pmWarehouseCd = pmWarehouseCd;
			this._pmWarehouseName = pmWarehouseName;
			this._pmShelfNo = pmShelfNo;
			this._pmPrsntCount = pmPrsntCount;
			this._setPartsMkrCd = setPartsMkrCd;
			this._setPartsNumber = setPartsNumber;
			this._setPartsMainSubNo = setPartsMainSubNo;

		}

		/// <summary>
		/// SCM�󔭒����׃f�[�^�i�⍇���E�����j��������
		/// </summary>
		/// <returns>ScmOdDtInq�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ScmOdDtInq�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmOdDtInq Clone()
		{
			return new ScmOdDtInq(this._createDateTime,this._updateDateTime,this._logicalDeleteCode,this._inqOriginalEpCd,this._inqOriginalSecCd,this._inqOtherEpCd,this._inqOtherSecCd,this._inquiryNumber,this._updateDate,this._updateTime,this._inqRowNumber,this._inqRowNumDerivedNo,this._inqOrgDtlDiscGuid,this._inqOthDtlDiscGuid,this._goodsDivCd,this._recyclePrtKindCode,this._recyclePrtKindName,this._deliveredGoodsDiv,this._handleDivCode,this._goodsShape,this._delivrdGdsConfCd,this._deliGdsCmpltDueDate,this._answerDeliveryDate,this._bLGoodsCode,this._bLGoodsDrCode,this._inqGoodsName,this._ansGoodsName,this._salesOrderCount,this._deliveredGoodsCount,this._goodsNo,this._goodsMakerCd,this._goodsMakerNm,this._pureGoodsMakerCd,this._inqPureGoodsNo,this._ansPureGoodsNo,this._listPrice,this._unitPrice,this._goodsAddInfo,this._roughRrofit,this._roughRate,this._answerLimitDate,this._commentDtl,this._shelfNo,this._additionalDivCd,this._correctDivCD,this._inqOrdDivCd,this._displayOrder,this._latestDiscCode,this._cancelCndtinDiv,this._pMAcptAnOdrStatus,this._pMSalesSlipNum,this._pMSalesRowNo,this._dtlTakeinDivCd,this._pmWarehouseCd,this._pmWarehouseName,this._pmShelfNo,this._pmPrsntCount,this._setPartsMkrCd,this._setPartsNumber,this._setPartsMainSubNo);
		}

		/// <summary>
		/// SCM�󔭒����׃f�[�^�i�⍇���E�����j��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmOdDtInq�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdDtInq�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ScmOdDtInq target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.InqOriginalEpCd == target.InqOriginalEpCd)
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
				 && (this.CancelCndtinDiv == target.CancelCndtinDiv)
				 && (this.PMAcptAnOdrStatus == target.PMAcptAnOdrStatus)
				 && (this.PMSalesSlipNum == target.PMSalesSlipNum)
				 && (this.PMSalesRowNo == target.PMSalesRowNo)
				 && (this.DtlTakeinDivCd == target.DtlTakeinDivCd)
				 && (this.PmWarehouseCd == target.PmWarehouseCd)
				 && (this.PmWarehouseName == target.PmWarehouseName)
				 && (this.PmShelfNo == target.PmShelfNo)
				 && (this.PmPrsntCount == target.PmPrsntCount)
				 && (this.SetPartsMkrCd == target.SetPartsMkrCd)
				 && (this.SetPartsNumber == target.SetPartsNumber)
				 && (this.SetPartsMainSubNo == target.SetPartsMainSubNo));
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
		/// </remarks>
		public static bool Equals(ScmOdDtInq scmOdDtInq1, ScmOdDtInq scmOdDtInq2)
		{
			return ((scmOdDtInq1.CreateDateTime == scmOdDtInq2.CreateDateTime)
				 && (scmOdDtInq1.UpdateDateTime == scmOdDtInq2.UpdateDateTime)
				 && (scmOdDtInq1.LogicalDeleteCode == scmOdDtInq2.LogicalDeleteCode)
				 && (scmOdDtInq1.InqOriginalEpCd == scmOdDtInq2.InqOriginalEpCd)
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
				 && (scmOdDtInq1.CancelCndtinDiv == scmOdDtInq2.CancelCndtinDiv)
				 && (scmOdDtInq1.PMAcptAnOdrStatus == scmOdDtInq2.PMAcptAnOdrStatus)
				 && (scmOdDtInq1.PMSalesSlipNum == scmOdDtInq2.PMSalesSlipNum)
				 && (scmOdDtInq1.PMSalesRowNo == scmOdDtInq2.PMSalesRowNo)
				 && (scmOdDtInq1.DtlTakeinDivCd == scmOdDtInq2.DtlTakeinDivCd)
				 && (scmOdDtInq1.PmWarehouseCd == scmOdDtInq2.PmWarehouseCd)
				 && (scmOdDtInq1.PmWarehouseName == scmOdDtInq2.PmWarehouseName)
				 && (scmOdDtInq1.PmShelfNo == scmOdDtInq2.PmShelfNo)
				 && (scmOdDtInq1.PmPrsntCount == scmOdDtInq2.PmPrsntCount)
				 && (scmOdDtInq1.SetPartsMkrCd == scmOdDtInq2.SetPartsMkrCd)
				 && (scmOdDtInq1.SetPartsNumber == scmOdDtInq2.SetPartsNumber)
				 && (scmOdDtInq1.SetPartsMainSubNo == scmOdDtInq2.SetPartsMainSubNo));
		}
		/// <summary>
		/// SCM�󔭒����׃f�[�^�i�⍇���E�����j��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmOdDtInq�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdDtInq�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ScmOdDtInq target)
		{
			ArrayList resList = new ArrayList();
			if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
			if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
			if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
			if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
			if (this.UpdateTime != target.UpdateTime) resList.Add("UpdateTime");
			if (this.InqRowNumber != target.InqRowNumber) resList.Add("InqRowNumber");
			if (this.InqRowNumDerivedNo != target.InqRowNumDerivedNo) resList.Add("InqRowNumDerivedNo");
			if (this.InqOrgDtlDiscGuid != target.InqOrgDtlDiscGuid) resList.Add("InqOrgDtlDiscGuid");
			if (this.InqOthDtlDiscGuid != target.InqOthDtlDiscGuid) resList.Add("InqOthDtlDiscGuid");
			if (this.GoodsDivCd != target.GoodsDivCd) resList.Add("GoodsDivCd");
			if (this.RecyclePrtKindCode != target.RecyclePrtKindCode) resList.Add("RecyclePrtKindCode");
			if (this.RecyclePrtKindName != target.RecyclePrtKindName) resList.Add("RecyclePrtKindName");
			if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
			if (this.HandleDivCode != target.HandleDivCode) resList.Add("HandleDivCode");
			if (this.GoodsShape != target.GoodsShape) resList.Add("GoodsShape");
			if (this.DelivrdGdsConfCd != target.DelivrdGdsConfCd) resList.Add("DelivrdGdsConfCd");
			if (this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
			if (this.AnswerDeliveryDate != target.AnswerDeliveryDate) resList.Add("AnswerDeliveryDate");
			if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
			if (this.BLGoodsDrCode != target.BLGoodsDrCode) resList.Add("BLGoodsDrCode");
			if (this.InqGoodsName != target.InqGoodsName) resList.Add("InqGoodsName");
			if (this.AnsGoodsName != target.AnsGoodsName) resList.Add("AnsGoodsName");
			if (this.SalesOrderCount != target.SalesOrderCount) resList.Add("SalesOrderCount");
			if (this.DeliveredGoodsCount != target.DeliveredGoodsCount) resList.Add("DeliveredGoodsCount");
			if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
			if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
			if (this.GoodsMakerNm != target.GoodsMakerNm) resList.Add("GoodsMakerNm");
			if (this.PureGoodsMakerCd != target.PureGoodsMakerCd) resList.Add("PureGoodsMakerCd");
			if (this.InqPureGoodsNo != target.InqPureGoodsNo) resList.Add("InqPureGoodsNo");
			if (this.AnsPureGoodsNo != target.AnsPureGoodsNo) resList.Add("AnsPureGoodsNo");
			if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");
			if (this.UnitPrice != target.UnitPrice) resList.Add("UnitPrice");
			if (this.GoodsAddInfo != target.GoodsAddInfo) resList.Add("GoodsAddInfo");
			if (this.RoughRrofit != target.RoughRrofit) resList.Add("RoughRrofit");
			if (this.RoughRate != target.RoughRate) resList.Add("RoughRate");
			if (this.AnswerLimitDate != target.AnswerLimitDate) resList.Add("AnswerLimitDate");
			if (this.CommentDtl != target.CommentDtl) resList.Add("CommentDtl");
			if (this.ShelfNo != target.ShelfNo) resList.Add("ShelfNo");
			if (this.AdditionalDivCd != target.AdditionalDivCd) resList.Add("AdditionalDivCd");
			if (this.CorrectDivCD != target.CorrectDivCD) resList.Add("CorrectDivCD");
			if (this.InqOrdDivCd != target.InqOrdDivCd) resList.Add("InqOrdDivCd");
			if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
			if (this.LatestDiscCode != target.LatestDiscCode) resList.Add("LatestDiscCode");
			if (this.CancelCndtinDiv != target.CancelCndtinDiv) resList.Add("CancelCndtinDiv");
			if (this.PMAcptAnOdrStatus != target.PMAcptAnOdrStatus) resList.Add("PMAcptAnOdrStatus");
			if (this.PMSalesSlipNum != target.PMSalesSlipNum) resList.Add("PMSalesSlipNum");
			if (this.PMSalesRowNo != target.PMSalesRowNo) resList.Add("PMSalesRowNo");
			if (this.DtlTakeinDivCd != target.DtlTakeinDivCd) resList.Add("DtlTakeinDivCd");
			if (this.PmWarehouseCd != target.PmWarehouseCd) resList.Add("PmWarehouseCd");
			if (this.PmWarehouseName != target.PmWarehouseName) resList.Add("PmWarehouseName");
			if (this.PmShelfNo != target.PmShelfNo) resList.Add("PmShelfNo");
			if(this.PmPrsntCount != target.PmPrsntCount)resList.Add("PmPrsntCount");
			if(this.SetPartsMkrCd != target.SetPartsMkrCd)resList.Add("SetPartsMkrCd");
			if(this.SetPartsNumber != target.SetPartsNumber)resList.Add("SetPartsNumber");
			if(this.SetPartsMainSubNo != target.SetPartsMainSubNo)resList.Add("SetPartsMainSubNo");

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
		/// </remarks>
		public static ArrayList Compare(ScmOdDtInq scmOdDtInq1, ScmOdDtInq scmOdDtInq2)
		{
			ArrayList resList = new ArrayList();
			if (scmOdDtInq1.CreateDateTime != scmOdDtInq2.CreateDateTime) resList.Add("CreateDateTime");
			if (scmOdDtInq1.UpdateDateTime != scmOdDtInq2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (scmOdDtInq1.LogicalDeleteCode != scmOdDtInq2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (scmOdDtInq1.InqOriginalEpCd != scmOdDtInq2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (scmOdDtInq1.InqOriginalSecCd != scmOdDtInq2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (scmOdDtInq1.InqOtherEpCd != scmOdDtInq2.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (scmOdDtInq1.InqOtherSecCd != scmOdDtInq2.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (scmOdDtInq1.InquiryNumber != scmOdDtInq2.InquiryNumber) resList.Add("InquiryNumber");
			if (scmOdDtInq1.UpdateDate != scmOdDtInq2.UpdateDate) resList.Add("UpdateDate");
			if (scmOdDtInq1.UpdateTime != scmOdDtInq2.UpdateTime) resList.Add("UpdateTime");
			if (scmOdDtInq1.InqRowNumber != scmOdDtInq2.InqRowNumber) resList.Add("InqRowNumber");
			if (scmOdDtInq1.InqRowNumDerivedNo != scmOdDtInq2.InqRowNumDerivedNo) resList.Add("InqRowNumDerivedNo");
			if (scmOdDtInq1.InqOrgDtlDiscGuid != scmOdDtInq2.InqOrgDtlDiscGuid) resList.Add("InqOrgDtlDiscGuid");
			if (scmOdDtInq1.InqOthDtlDiscGuid != scmOdDtInq2.InqOthDtlDiscGuid) resList.Add("InqOthDtlDiscGuid");
			if (scmOdDtInq1.GoodsDivCd != scmOdDtInq2.GoodsDivCd) resList.Add("GoodsDivCd");
			if (scmOdDtInq1.RecyclePrtKindCode != scmOdDtInq2.RecyclePrtKindCode) resList.Add("RecyclePrtKindCode");
			if (scmOdDtInq1.RecyclePrtKindName != scmOdDtInq2.RecyclePrtKindName) resList.Add("RecyclePrtKindName");
			if (scmOdDtInq1.DeliveredGoodsDiv != scmOdDtInq2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
			if (scmOdDtInq1.HandleDivCode != scmOdDtInq2.HandleDivCode) resList.Add("HandleDivCode");
			if (scmOdDtInq1.GoodsShape != scmOdDtInq2.GoodsShape) resList.Add("GoodsShape");
			if (scmOdDtInq1.DelivrdGdsConfCd != scmOdDtInq2.DelivrdGdsConfCd) resList.Add("DelivrdGdsConfCd");
			if (scmOdDtInq1.DeliGdsCmpltDueDate != scmOdDtInq2.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
			if (scmOdDtInq1.AnswerDeliveryDate != scmOdDtInq2.AnswerDeliveryDate) resList.Add("AnswerDeliveryDate");
			if (scmOdDtInq1.BLGoodsCode != scmOdDtInq2.BLGoodsCode) resList.Add("BLGoodsCode");
			if (scmOdDtInq1.BLGoodsDrCode != scmOdDtInq2.BLGoodsDrCode) resList.Add("BLGoodsDrCode");
			if (scmOdDtInq1.InqGoodsName != scmOdDtInq2.InqGoodsName) resList.Add("InqGoodsName");
			if (scmOdDtInq1.AnsGoodsName != scmOdDtInq2.AnsGoodsName) resList.Add("AnsGoodsName");
			if (scmOdDtInq1.SalesOrderCount != scmOdDtInq2.SalesOrderCount) resList.Add("SalesOrderCount");
			if (scmOdDtInq1.DeliveredGoodsCount != scmOdDtInq2.DeliveredGoodsCount) resList.Add("DeliveredGoodsCount");
			if (scmOdDtInq1.GoodsNo != scmOdDtInq2.GoodsNo) resList.Add("GoodsNo");
			if (scmOdDtInq1.GoodsMakerCd != scmOdDtInq2.GoodsMakerCd) resList.Add("GoodsMakerCd");
			if (scmOdDtInq1.GoodsMakerNm != scmOdDtInq2.GoodsMakerNm) resList.Add("GoodsMakerNm");
			if (scmOdDtInq1.PureGoodsMakerCd != scmOdDtInq2.PureGoodsMakerCd) resList.Add("PureGoodsMakerCd");
			if (scmOdDtInq1.InqPureGoodsNo != scmOdDtInq2.InqPureGoodsNo) resList.Add("InqPureGoodsNo");
			if (scmOdDtInq1.AnsPureGoodsNo != scmOdDtInq2.AnsPureGoodsNo) resList.Add("AnsPureGoodsNo");
			if (scmOdDtInq1.ListPrice != scmOdDtInq2.ListPrice) resList.Add("ListPrice");
			if (scmOdDtInq1.UnitPrice != scmOdDtInq2.UnitPrice) resList.Add("UnitPrice");
			if (scmOdDtInq1.GoodsAddInfo != scmOdDtInq2.GoodsAddInfo) resList.Add("GoodsAddInfo");
			if (scmOdDtInq1.RoughRrofit != scmOdDtInq2.RoughRrofit) resList.Add("RoughRrofit");
			if (scmOdDtInq1.RoughRate != scmOdDtInq2.RoughRate) resList.Add("RoughRate");
			if (scmOdDtInq1.AnswerLimitDate != scmOdDtInq2.AnswerLimitDate) resList.Add("AnswerLimitDate");
			if (scmOdDtInq1.CommentDtl != scmOdDtInq2.CommentDtl) resList.Add("CommentDtl");
			if (scmOdDtInq1.ShelfNo != scmOdDtInq2.ShelfNo) resList.Add("ShelfNo");
			if (scmOdDtInq1.AdditionalDivCd != scmOdDtInq2.AdditionalDivCd) resList.Add("AdditionalDivCd");
			if (scmOdDtInq1.CorrectDivCD != scmOdDtInq2.CorrectDivCD) resList.Add("CorrectDivCD");
			if (scmOdDtInq1.InqOrdDivCd != scmOdDtInq2.InqOrdDivCd) resList.Add("InqOrdDivCd");
			if (scmOdDtInq1.DisplayOrder != scmOdDtInq2.DisplayOrder) resList.Add("DisplayOrder");
			if (scmOdDtInq1.LatestDiscCode != scmOdDtInq2.LatestDiscCode) resList.Add("LatestDiscCode");
			if (scmOdDtInq1.CancelCndtinDiv != scmOdDtInq2.CancelCndtinDiv) resList.Add("CancelCndtinDiv");
			if (scmOdDtInq1.PMAcptAnOdrStatus != scmOdDtInq2.PMAcptAnOdrStatus) resList.Add("PMAcptAnOdrStatus");
			if (scmOdDtInq1.PMSalesSlipNum != scmOdDtInq2.PMSalesSlipNum) resList.Add("PMSalesSlipNum");
			if (scmOdDtInq1.PMSalesRowNo != scmOdDtInq2.PMSalesRowNo) resList.Add("PMSalesRowNo");
			if (scmOdDtInq1.DtlTakeinDivCd != scmOdDtInq2.DtlTakeinDivCd) resList.Add("DtlTakeinDivCd");
			if (scmOdDtInq1.PmWarehouseCd != scmOdDtInq2.PmWarehouseCd) resList.Add("PmWarehouseCd");
			if (scmOdDtInq1.PmWarehouseName != scmOdDtInq2.PmWarehouseName) resList.Add("PmWarehouseName");
			if (scmOdDtInq1.PmShelfNo != scmOdDtInq2.PmShelfNo) resList.Add("PmShelfNo");
			if(scmOdDtInq1.PmPrsntCount != scmOdDtInq2.PmPrsntCount)resList.Add("PmPrsntCount");
			if(scmOdDtInq1.SetPartsMkrCd != scmOdDtInq2.SetPartsMkrCd)resList.Add("SetPartsMkrCd");
			if(scmOdDtInq1.SetPartsNumber != scmOdDtInq2.SetPartsNumber)resList.Add("SetPartsNumber");
			if(scmOdDtInq1.SetPartsMainSubNo != scmOdDtInq2.SetPartsMainSubNo)resList.Add("SetPartsMainSubNo");

			return resList;
		}
	}
}

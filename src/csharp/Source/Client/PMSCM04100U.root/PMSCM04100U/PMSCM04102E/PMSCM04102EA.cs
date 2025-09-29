//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : SCM����񓚗����Ɖ�
// �v���O�����T�v   : ��ʃf�[�^��ێ�����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �� �� ��  2009/05/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SCMAnsHistInquiryInfo
	/// <summary>
	///                      SCM����񓚗����Ɖ��ʏ��ێ��N���X
	/// </summary>
	/// <remarks>
    /// <br>note             :   SCM����񓚗����Ɖ�o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :    2009/4/13</br>
	/// <br>Genarated Date   :   2009/05/26  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SCMAnsHistInquiryInfo
	{
		/// <summary>�⍇������ƃR�[�h</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>�⍇�������_�R�[�h</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>�⍇�����ƃR�[�h</summary>
		private string _inqOtherEpCd = "";

		/// <summary>�⍇���拒�_�R�[�h</summary>
		private string _inqOtherSecCd = "";

		/// <summary>�J�n�⍇���ԍ�</summary>
		private Int64 _st_InquiryNumber;

		/// <summary>�I���⍇���ԍ�</summary>
		private Int64 _ed_InquiryNumber;

		/// <summary>�X�V�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>�X�V�����b�~���b</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>�⍇���E�������</summary>
		/// <remarks>1:�⍇�� 2:����</remarks>
		private Int32[] _inqOrdDivCd;

		/// <summary>�m���</summary>
		/// <remarks>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</remarks>
		private Int32 _judgementDate;

		/// <summary>�⍇���E�������l</summary>
		private string _inqOrdNote;

		/// <summary>�⍇���]�ƈ��R�[�h</summary>
		/// <remarks>�⍇�������]�ƈ��R�[�h</remarks>
		private string _inqEmployeeCd = "";

		/// <summary>�⍇���]�ƈ�����</summary>
		/// <remarks>�⍇�������]�ƈ�����</remarks>
		private string _inqEmployeeNm = "";

		/// <summary>�񓚏]�ƈ��R�[�h</summary>
		private string _ansEmployeeCd = "";

		/// <summary>�񓚏]�ƈ�����</summary>
		private string _ansEmployeeNm = "";

		/// <summary>�J�n�⍇����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _st_InquiryDate;

		/// <summary>�I���⍇����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _ed_InquiryDate;

		/// <summary>�J�n���Ӑ�R�[�h</summary>
		private Int32 _st_CustomerCode;

		/// <summary>�I�����Ӑ�R�[�h</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>�J�n����`�[�ԍ�</summary>
		/// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
		private string _st_SalesSlipNum = "";

		/// <summary>�I������`�[�ԍ�</summary>
		/// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
		private string _ed_SalesSlipNum = "";

		/// <summary>�󒍃X�e�[�^�X</summary>
		/// <remarks>10:����,20:��,30:����,40:�o��</remarks>
		private Int32[] _acptAnOdrStatus;

		/// <summary>�񓚕��@</summary>
		private Int32[] _awnserMethod;

		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>����`�[���v�i�ō��݁j</summary>
		/// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
		private Int64 _salesTotalTaxInc;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        /// <summary>�ԗ��o�^�ԍ��i�J�i�j</summary>
        private string _numberPlate3;

        /// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</summary>
        private Int32 _numberPlate4;

        /// <summary>�^���i�t���^�j</summary>
        private string _fullModel;

        /// <summary>���[�J�[�R�[�h(�ԗ����)</summary>
        private Int32 _carMakerCode;

        /// <summary>�Ԏ�R�[�h</summary>
        private Int32 _modelCode;

        /// <summary>�Ԏ�T�u�R�[�h</summary>
        private Int32 _modelSubCode;

        /// <summary>���[�J�[�R�[�h(����)</summary>
        private Int32 _detailMakerCode;

        /// <summary>BL�R�[�h</summary>
        private Int32 _blGoodsCode;

        /// <summary>�i��</summary>
        private string _goodsNo;

        /// <summary>�����i��</summary>
        private string _pureGoodsNo;

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

		/// public propaty name  :  St_InquiryNumber
		/// <summary>�J�n�⍇���ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�⍇���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 St_InquiryNumber
		{
			get{return _st_InquiryNumber;}
			set{_st_InquiryNumber = value;}
		}

		/// public propaty name  :  Ed_InquiryNumber
		/// <summary>�I���⍇���ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���⍇���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 Ed_InquiryNumber
		{
			get{return _ed_InquiryNumber;}
			set{_ed_InquiryNumber = value;}
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

		/// public propaty name  :  InqOrdDivCd
		/// <summary>�⍇���E������ʃv���p�e�B</summary>
		/// <value>1:�⍇�� 2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���E������ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32[] InqOrdDivCd
		{
			get{return _inqOrdDivCd;}
			set{_inqOrdDivCd = value;}
		}

		/// public propaty name  :  JudgementDate
		/// <summary>�m����v���p�e�B</summary>
		/// <value>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �m����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 JudgementDate
		{
			get{return _judgementDate;}
			set{_judgementDate = value;}
		}

		/// public propaty name  :  InqOrdNote
		/// <summary>�⍇���E�������l�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���E�������l�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOrdNote
		{
			get{return _inqOrdNote;}
			set{_inqOrdNote = value;}
		}

		/// public propaty name  :  InqEmployeeCd
		/// <summary>�⍇���]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>�⍇�������]�ƈ��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqEmployeeCd
		{
			get{return _inqEmployeeCd;}
			set{_inqEmployeeCd = value;}
		}

		/// public propaty name  :  InqEmployeeNm
		/// <summary>�⍇���]�ƈ����̃v���p�e�B</summary>
		/// <value>�⍇�������]�ƈ�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqEmployeeNm
		{
			get{return _inqEmployeeNm;}
			set{_inqEmployeeNm = value;}
		}

		/// public propaty name  :  AnsEmployeeCd
		/// <summary>�񓚏]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsEmployeeCd
		{
			get{return _ansEmployeeCd;}
			set{_ansEmployeeCd = value;}
		}

		/// public propaty name  :  AnsEmployeeNm
		/// <summary>�񓚏]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsEmployeeNm
		{
			get{return _ansEmployeeNm;}
			set{_ansEmployeeNm = value;}
		}

		/// public propaty name  :  St_InquiryDate
		/// <summary>�J�n�⍇�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�⍇�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_InquiryDate
		{
			get{return _st_InquiryDate;}
			set{_st_InquiryDate = value;}
		}

		/// public propaty name  :  Ed_InquiryDate
		/// <summary>�I���⍇�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���⍇�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_InquiryDate
		{
			get{return _ed_InquiryDate;}
			set{_ed_InquiryDate = value;}
		}

		/// public propaty name  :  St_CustomerCode
		/// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_CustomerCode
		{
			get{return _st_CustomerCode;}
			set{_st_CustomerCode = value;}
		}

		/// public propaty name  :  Ed_CustomerCode
		/// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_CustomerCode
		{
			get{return _ed_CustomerCode;}
			set{_ed_CustomerCode = value;}
		}

		/// public propaty name  :  St_SalesSlipNum
		/// <summary>�J�n����`�[�ԍ��v���p�e�B</summary>
		/// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_SalesSlipNum
		{
			get{return _st_SalesSlipNum;}
			set{_st_SalesSlipNum = value;}
		}

		/// public propaty name  :  Ed_SalesSlipNum
		/// <summary>�I������`�[�ԍ��v���p�e�B</summary>
		/// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I������`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_SalesSlipNum
		{
			get{return _ed_SalesSlipNum;}
			set{_ed_SalesSlipNum = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
		/// <value>10:����,20:��,30:����,40:�o��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32[] AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  AwnserMethod
		/// <summary>�񓚕��@�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚕��@�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32[] AwnserMethod
		{
			get{return _awnserMethod;}
			set{_awnserMethod = value;}
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

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  SalesTotalTaxInc
		/// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
		/// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTotalTaxInc
		{
			get{return _salesTotalTaxInc;}
			set{_salesTotalTaxInc = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>��Ɩ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��Ɩ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

        /// public propaty name  :  NumberPlate3
        /// <summary>�ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��o�^�ԍ��i�J�i�j���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NumberPlate3
        {
            get { return _numberPlate3; }
            set { _numberPlate3 = value; }
        }

        /// public propaty name  :  NumberPlate4
        /// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��o�^�ԍ��i�v���[�g�ԍ��j���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NumberPlate4
        {
            get { return _numberPlate4; }
            set { _numberPlate4 = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>�^���i�t���^�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���i�t���^�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  CarMakerCode
        /// <summary>���[�J�[�R�[�h(�ԗ����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h(�ԗ����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarMakerCode
        {
            get { return _carMakerCode; }
            set { _carMakerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>�Ԏ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>�Ԏ�T�u�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�T�u�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  DetailMakerCode
        /// <summary>���[�J�[�R�[�h(����)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h(����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DetailMakerCode
        {
            get { return _detailMakerCode; }
            set { _detailMakerCode = value; }
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
            get { return _blGoodsCode; }
            set { _blGoodsCode = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  PureGoodsNo
        /// <summary>�����i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PureGoodsNo
        {
            get { return _pureGoodsNo; }
            set { _pureGoodsNo = value; }
        }

		/// <summary>
		/// SCM�₢���킹�ꗗ���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>SCMAnsHistInquiryInfo�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAnsHistInquiryInfo�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAnsHistInquiryInfo()
		{
		}

		/// <summary>
		/// SCM�₢���킹�ꗗ���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
		/// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
		/// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
		/// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
		/// <param name="st_InquiryNumber">�J�n�⍇���ԍ�</param>
		/// <param name="ed_InquiryNumber">�I���⍇���ԍ�</param>
		/// <param name="updateDate">�X�V�N����(YYYYMMDD)</param>
		/// <param name="updateTime">�X�V�����b�~���b(HHMMSSXXX)</param>
		/// <param name="inqOrdDivCd">�⍇���E�������(1:�⍇�� 2:����)</param>
		/// <param name="answerDivCd">�񓚋敪(0:�A�N�V�����Ȃ� 1:�񓚒� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��)</param>
		/// <param name="judgementDate">�m���(YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B)</param>
		/// <param name="inqOrdNote">�⍇���E�������l</param>
		/// <param name="inqEmployeeCd">�⍇���]�ƈ��R�[�h(�⍇�������]�ƈ��R�[�h)</param>
		/// <param name="inqEmployeeNm">�⍇���]�ƈ�����(�⍇�������]�ƈ�����)</param>
		/// <param name="ansEmployeeCd">�񓚏]�ƈ��R�[�h</param>
		/// <param name="ansEmployeeNm">�񓚏]�ƈ�����</param>
		/// <param name="st_InquiryDate">�J�n�⍇����(YYYYMMDD)</param>
		/// <param name="ed_InquiryDate">�I���⍇����(YYYYMMDD)</param>
		/// <param name="st_CustomerCode">�J�n���Ӑ�R�[�h</param>
		/// <param name="ed_CustomerCode">�I�����Ӑ�R�[�h</param>
		/// <param name="st_SalesSlipNum">�J�n����`�[�ԍ�(���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B)</param>
		/// <param name="ed_SalesSlipNum">�I������`�[�ԍ�(���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B)</param>
		/// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:����,20:��,30:����,40:�o��)</param>
		/// <param name="awnserMethod">�񓚕��@</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="salesTotalTaxInc">����`�[���v�i�ō��݁j(���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>SCMAnsHistInquiryInfo�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAnsHistInquiryInfo�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public SCMAnsHistInquiryInfo(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 st_InquiryNumber, Int64 ed_InquiryNumber, DateTime updateDate, Int32 updateTime, Int32[] inqOrdDivCd, Int32 judgementDate, string inqOrdNote, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, Int32 st_InquiryDate, Int32 ed_InquiryDate, Int32 st_CustomerCode, Int32 ed_CustomerCode, string st_SalesSlipNum, string ed_SalesSlipNum, Int32[] acptAnOdrStatus, Int32[] awnserMethod, string enterpriseCode, Int32 customerCode, Int64 salesTotalTaxInc, string enterpriseName, string numberPlate3, Int32 numberPlate4, string fullModel, Int32 carMakerCode, Int32 modelCode, Int32 modelSubCode, Int32 detailMakerCode, Int32 blGoodsCode, string goodsNo, string pureGoodsNo)
		{
			this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this._st_InquiryNumber = st_InquiryNumber;
			this._ed_InquiryNumber = ed_InquiryNumber;
			this.UpdateDate = updateDate;
			this._updateTime = updateTime;
			this._inqOrdDivCd = inqOrdDivCd;
			this._judgementDate = judgementDate;
			this._inqOrdNote = inqOrdNote;
			this._inqEmployeeCd = inqEmployeeCd;
			this._inqEmployeeNm = inqEmployeeNm;
			this._ansEmployeeCd = ansEmployeeCd;
			this._ansEmployeeNm = ansEmployeeNm;
			this._st_InquiryDate = st_InquiryDate;
			this._ed_InquiryDate = ed_InquiryDate;
			this._st_CustomerCode = st_CustomerCode;
			this._ed_CustomerCode = ed_CustomerCode;
			this._st_SalesSlipNum = st_SalesSlipNum;
			this._ed_SalesSlipNum = ed_SalesSlipNum;
			this._acptAnOdrStatus = acptAnOdrStatus;
			this._awnserMethod = awnserMethod;
			this._enterpriseCode = enterpriseCode;
			this._customerCode = customerCode;
			this._salesTotalTaxInc = salesTotalTaxInc;
			this._enterpriseName = enterpriseName;
            this._numberPlate3 = numberPlate3;
            this._numberPlate4 = numberPlate4;
            this._fullModel = fullModel;
            this._carMakerCode = carMakerCode;
            this._modelCode = modelCode;
            this._modelSubCode = modelSubCode;
            this._detailMakerCode = detailMakerCode;
            this._blGoodsCode = blGoodsCode;
            this._goodsNo = goodsNo;
            this._pureGoodsNo = pureGoodsNo;

		}

		/// <summary>
		/// SCM�₢���킹�ꗗ���o�����N���X��������
		/// </summary>
		/// <returns>SCMAnsHistInquiryInfo�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SCMAnsHistInquiryInfo�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAnsHistInquiryInfo Clone()
		{
			return new SCMAnsHistInquiryInfo(this._inqOriginalEpCd.Trim(),this._inqOriginalSecCd,this._inqOtherEpCd,this._inqOtherSecCd,this._st_InquiryNumber,this._ed_InquiryNumber,this._updateDate,this._updateTime,this._inqOrdDivCd,this._judgementDate,this._inqOrdNote,this._inqEmployeeCd,this._inqEmployeeNm,this._ansEmployeeCd,this._ansEmployeeNm,this._st_InquiryDate,this._ed_InquiryDate,this._st_CustomerCode,this._ed_CustomerCode,this._st_SalesSlipNum,this._ed_SalesSlipNum,this._acptAnOdrStatus,this._awnserMethod,this._enterpriseCode,this._customerCode,this._salesTotalTaxInc,this._enterpriseName, this._numberPlate3, this._numberPlate4, this._fullModel, this._carMakerCode, this._modelCode, this._modelSubCode, this._detailMakerCode, this._blGoodsCode, this._goodsNo, this._pureGoodsNo);//@@@@20230303
		}

		/// <summary>
		/// SCM�₢���킹�ꗗ���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SCMAnsHistInquiryInfo�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAnsHistInquiryInfo�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public bool Equals(SCMAnsHistInquiryInfo target)
        {
            return ((this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim()) //@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.St_InquiryNumber == target.St_InquiryNumber)
                 && (this.Ed_InquiryNumber == target.Ed_InquiryNumber)
                 && (this.UpdateDate == target.UpdateDate)
                 && (this.UpdateTime == target.UpdateTime)
                 && (this.InqOrdDivCd == target.InqOrdDivCd)
                 && (this.JudgementDate == target.JudgementDate)
                 && (this.InqOrdNote == target.InqOrdNote)
                 && (this.InqEmployeeCd == target.InqEmployeeCd)
                 && (this.InqEmployeeNm == target.InqEmployeeNm)
                 && (this.AnsEmployeeCd == target.AnsEmployeeCd)
                 && (this.AnsEmployeeNm == target.AnsEmployeeNm)
                 && (this.St_InquiryDate == target.St_InquiryDate)
                 && (this.Ed_InquiryDate == target.Ed_InquiryDate)
                 && (this.St_CustomerCode == target.St_CustomerCode)
                 && (this.Ed_CustomerCode == target.Ed_CustomerCode)
                 && (this.St_SalesSlipNum == target.St_SalesSlipNum)
                 && (this.Ed_SalesSlipNum == target.Ed_SalesSlipNum)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.AwnserMethod == target.AwnserMethod)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.SalesTotalTaxInc == target.SalesTotalTaxInc)
                 && (this.EnterpriseName == target.EnterpriseName)
                && (this.NumberPlate3 == target.NumberPlate3)
                && (this.NumberPlate4 == target.NumberPlate4)
                && (this.FullModel == target.FullModel)
                && (this.CarMakerCode == target.CarMakerCode)
                && (this.ModelCode == target.ModelCode)
                && (this.ModelSubCode == target.ModelSubCode)
                && (this.DetailMakerCode == target.DetailMakerCode)
                && (this.BLGoodsCode == target.BLGoodsCode)
                && (this.GoodsNo == target.GoodsNo)
                && (this.PureGoodsNo == target.PureGoodsNo)
                 );
        }

		/// <summary>
		/// SCM�₢���킹�ꗗ���o�����N���X��r����
		/// </summary>
		/// <param name="SCMAnsHistInquiryInfo1">
		///                    ��r����SCMAnsHistInquiryInfo�N���X�̃C���X�^���X
		/// </param>
		/// <param name="SCMAnsHistInquiryInfo2">��r����SCMAnsHistInquiryInfo�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAnsHistInquiryInfo�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public static bool Equals(SCMAnsHistInquiryInfo SCMAnsHistInquiryInfo1, SCMAnsHistInquiryInfo SCMAnsHistInquiryInfo2)
        {
            return ((SCMAnsHistInquiryInfo1.InqOriginalEpCd.Trim() == SCMAnsHistInquiryInfo2.InqOriginalEpCd.Trim()) //@@@@20230303
                 && (SCMAnsHistInquiryInfo1.InqOriginalSecCd == SCMAnsHistInquiryInfo2.InqOriginalSecCd)
                 && (SCMAnsHistInquiryInfo1.InqOtherEpCd == SCMAnsHistInquiryInfo2.InqOtherEpCd)
                 && (SCMAnsHistInquiryInfo1.InqOtherSecCd == SCMAnsHistInquiryInfo2.InqOtherSecCd)
                 && (SCMAnsHistInquiryInfo1.St_InquiryNumber == SCMAnsHistInquiryInfo2.St_InquiryNumber)
                 && (SCMAnsHistInquiryInfo1.Ed_InquiryNumber == SCMAnsHistInquiryInfo2.Ed_InquiryNumber)
                 && (SCMAnsHistInquiryInfo1.UpdateDate == SCMAnsHistInquiryInfo2.UpdateDate)
                 && (SCMAnsHistInquiryInfo1.UpdateTime == SCMAnsHistInquiryInfo2.UpdateTime)
                 && (SCMAnsHistInquiryInfo1.InqOrdDivCd == SCMAnsHistInquiryInfo2.InqOrdDivCd)
                 && (SCMAnsHistInquiryInfo1.JudgementDate == SCMAnsHistInquiryInfo2.JudgementDate)
                 && (SCMAnsHistInquiryInfo1.InqOrdNote == SCMAnsHistInquiryInfo2.InqOrdNote)
                 && (SCMAnsHistInquiryInfo1.InqEmployeeCd == SCMAnsHistInquiryInfo2.InqEmployeeCd)
                 && (SCMAnsHistInquiryInfo1.InqEmployeeNm == SCMAnsHistInquiryInfo2.InqEmployeeNm)
                 && (SCMAnsHistInquiryInfo1.AnsEmployeeCd == SCMAnsHistInquiryInfo2.AnsEmployeeCd)
                 && (SCMAnsHistInquiryInfo1.AnsEmployeeNm == SCMAnsHistInquiryInfo2.AnsEmployeeNm)
                 && (SCMAnsHistInquiryInfo1.St_InquiryDate == SCMAnsHistInquiryInfo2.St_InquiryDate)
                 && (SCMAnsHistInquiryInfo1.Ed_InquiryDate == SCMAnsHistInquiryInfo2.Ed_InquiryDate)
                 && (SCMAnsHistInquiryInfo1.St_CustomerCode == SCMAnsHistInquiryInfo2.St_CustomerCode)
                 && (SCMAnsHistInquiryInfo1.Ed_CustomerCode == SCMAnsHistInquiryInfo2.Ed_CustomerCode)
                 && (SCMAnsHistInquiryInfo1.St_SalesSlipNum == SCMAnsHistInquiryInfo2.St_SalesSlipNum)
                 && (SCMAnsHistInquiryInfo1.Ed_SalesSlipNum == SCMAnsHistInquiryInfo2.Ed_SalesSlipNum)
                 && (SCMAnsHistInquiryInfo1.AcptAnOdrStatus == SCMAnsHistInquiryInfo2.AcptAnOdrStatus)
                 && (SCMAnsHistInquiryInfo1.AwnserMethod == SCMAnsHistInquiryInfo2.AwnserMethod)
                 && (SCMAnsHistInquiryInfo1.EnterpriseCode == SCMAnsHistInquiryInfo2.EnterpriseCode)
                 && (SCMAnsHistInquiryInfo1.CustomerCode == SCMAnsHistInquiryInfo2.CustomerCode)
                 && (SCMAnsHistInquiryInfo1.SalesTotalTaxInc == SCMAnsHistInquiryInfo2.SalesTotalTaxInc)
                 && (SCMAnsHistInquiryInfo1.EnterpriseName == SCMAnsHistInquiryInfo2.EnterpriseName)
                && (SCMAnsHistInquiryInfo1.NumberPlate3 == SCMAnsHistInquiryInfo2.NumberPlate3)
                && (SCMAnsHistInquiryInfo1.NumberPlate4 == SCMAnsHistInquiryInfo2.NumberPlate4)
                && (SCMAnsHistInquiryInfo1.FullModel == SCMAnsHistInquiryInfo2.FullModel)
                && (SCMAnsHistInquiryInfo1.CarMakerCode == SCMAnsHistInquiryInfo2.CarMakerCode)
                && (SCMAnsHistInquiryInfo1.ModelCode == SCMAnsHistInquiryInfo2.ModelCode)
                && (SCMAnsHistInquiryInfo1.ModelSubCode == SCMAnsHistInquiryInfo2.ModelSubCode)
                && (SCMAnsHistInquiryInfo1.DetailMakerCode == SCMAnsHistInquiryInfo2.DetailMakerCode)
                && (SCMAnsHistInquiryInfo1.BLGoodsCode == SCMAnsHistInquiryInfo2.BLGoodsCode)
                && (SCMAnsHistInquiryInfo1.GoodsNo == SCMAnsHistInquiryInfo2.GoodsNo)
                && (SCMAnsHistInquiryInfo1.PureGoodsNo == SCMAnsHistInquiryInfo2.PureGoodsNo)
                 );
        }

		/// <summary>
		/// SCM�₢���킹�ꗗ���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SCMAnsHistInquiryInfo�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAnsHistInquiryInfo�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SCMAnsHistInquiryInfo target)
		{
			ArrayList resList = new ArrayList();
			if(this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(this.InqOriginalSecCd != target.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(this.InqOtherEpCd != target.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(this.InqOtherSecCd != target.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(this.St_InquiryNumber != target.St_InquiryNumber)resList.Add("St_InquiryNumber");
			if(this.Ed_InquiryNumber != target.Ed_InquiryNumber)resList.Add("Ed_InquiryNumber");
			if(this.UpdateDate != target.UpdateDate)resList.Add("UpdateDate");
			if(this.UpdateTime != target.UpdateTime)resList.Add("UpdateTime");
			if(this.InqOrdDivCd != target.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(this.JudgementDate != target.JudgementDate)resList.Add("JudgementDate");
			if(this.InqOrdNote != target.InqOrdNote)resList.Add("InqOrdNote");
			if(this.InqEmployeeCd != target.InqEmployeeCd)resList.Add("InqEmployeeCd");
			if(this.InqEmployeeNm != target.InqEmployeeNm)resList.Add("InqEmployeeNm");
			if(this.AnsEmployeeCd != target.AnsEmployeeCd)resList.Add("AnsEmployeeCd");
			if(this.AnsEmployeeNm != target.AnsEmployeeNm)resList.Add("AnsEmployeeNm");
			if(this.St_InquiryDate != target.St_InquiryDate)resList.Add("St_InquiryDate");
			if(this.Ed_InquiryDate != target.Ed_InquiryDate)resList.Add("Ed_InquiryDate");
			if(this.St_CustomerCode != target.St_CustomerCode)resList.Add("St_CustomerCode");
			if(this.Ed_CustomerCode != target.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(this.St_SalesSlipNum != target.St_SalesSlipNum)resList.Add("St_SalesSlipNum");
			if(this.Ed_SalesSlipNum != target.Ed_SalesSlipNum)resList.Add("Ed_SalesSlipNum");
			if(this.AcptAnOdrStatus != target.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(this.AwnserMethod != target.AwnserMethod)resList.Add("AwnserMethod");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.SalesTotalTaxInc != target.SalesTotalTaxInc)resList.Add("SalesTotalTaxInc");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.NumberPlate3 != target.NumberPlate3) resList.Add("NumberPlate3");
            if (this.NumberPlate4 != target.NumberPlate4) resList.Add("NumberPlate4");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.CarMakerCode != target.CarMakerCode) resList.Add("CarMakerCode");
            if (this.ModelCode != target.ModelCode) resList.Add("ModelCode");
            if (this.ModelSubCode != target.ModelSubCode) resList.Add("ModelSubCode");
            if (this.DetailMakerCode != target.DetailMakerCode) resList.Add("DetailMakerCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.PureGoodsNo != target.PureGoodsNo) resList.Add("PureGoodsNo");

			return resList;
		}

		/// <summary>
		/// SCM�₢���킹�ꗗ���o�����N���X��r����
		/// </summary>
		/// <param name="SCMAnsHistInquiryInfo1">��r����SCMAnsHistInquiryInfo�N���X�̃C���X�^���X</param>
		/// <param name="SCMAnsHistInquiryInfo2">��r����SCMAnsHistInquiryInfo�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAnsHistInquiryInfo�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SCMAnsHistInquiryInfo SCMAnsHistInquiryInfo1, SCMAnsHistInquiryInfo SCMAnsHistInquiryInfo2)
		{
			ArrayList resList = new ArrayList();
			if(SCMAnsHistInquiryInfo1.InqOriginalEpCd.Trim() != SCMAnsHistInquiryInfo2.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(SCMAnsHistInquiryInfo1.InqOriginalSecCd != SCMAnsHistInquiryInfo2.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(SCMAnsHistInquiryInfo1.InqOtherEpCd != SCMAnsHistInquiryInfo2.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(SCMAnsHistInquiryInfo1.InqOtherSecCd != SCMAnsHistInquiryInfo2.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(SCMAnsHistInquiryInfo1.St_InquiryNumber != SCMAnsHistInquiryInfo2.St_InquiryNumber)resList.Add("St_InquiryNumber");
			if(SCMAnsHistInquiryInfo1.Ed_InquiryNumber != SCMAnsHistInquiryInfo2.Ed_InquiryNumber)resList.Add("Ed_InquiryNumber");
			if(SCMAnsHistInquiryInfo1.UpdateDate != SCMAnsHistInquiryInfo2.UpdateDate)resList.Add("UpdateDate");
			if(SCMAnsHistInquiryInfo1.UpdateTime != SCMAnsHistInquiryInfo2.UpdateTime)resList.Add("UpdateTime");
			if(SCMAnsHistInquiryInfo1.InqOrdDivCd != SCMAnsHistInquiryInfo2.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(SCMAnsHistInquiryInfo1.JudgementDate != SCMAnsHistInquiryInfo2.JudgementDate)resList.Add("JudgementDate");
			if(SCMAnsHistInquiryInfo1.InqOrdNote != SCMAnsHistInquiryInfo2.InqOrdNote)resList.Add("InqOrdNote");
			if(SCMAnsHistInquiryInfo1.InqEmployeeCd != SCMAnsHistInquiryInfo2.InqEmployeeCd)resList.Add("InqEmployeeCd");
			if(SCMAnsHistInquiryInfo1.InqEmployeeNm != SCMAnsHistInquiryInfo2.InqEmployeeNm)resList.Add("InqEmployeeNm");
			if(SCMAnsHistInquiryInfo1.AnsEmployeeCd != SCMAnsHistInquiryInfo2.AnsEmployeeCd)resList.Add("AnsEmployeeCd");
			if(SCMAnsHistInquiryInfo1.AnsEmployeeNm != SCMAnsHistInquiryInfo2.AnsEmployeeNm)resList.Add("AnsEmployeeNm");
			if(SCMAnsHistInquiryInfo1.St_InquiryDate != SCMAnsHistInquiryInfo2.St_InquiryDate)resList.Add("St_InquiryDate");
			if(SCMAnsHistInquiryInfo1.Ed_InquiryDate != SCMAnsHistInquiryInfo2.Ed_InquiryDate)resList.Add("Ed_InquiryDate");
			if(SCMAnsHistInquiryInfo1.St_CustomerCode != SCMAnsHistInquiryInfo2.St_CustomerCode)resList.Add("St_CustomerCode");
			if(SCMAnsHistInquiryInfo1.Ed_CustomerCode != SCMAnsHistInquiryInfo2.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(SCMAnsHistInquiryInfo1.St_SalesSlipNum != SCMAnsHistInquiryInfo2.St_SalesSlipNum)resList.Add("St_SalesSlipNum");
			if(SCMAnsHistInquiryInfo1.Ed_SalesSlipNum != SCMAnsHistInquiryInfo2.Ed_SalesSlipNum)resList.Add("Ed_SalesSlipNum");
			if(SCMAnsHistInquiryInfo1.AcptAnOdrStatus != SCMAnsHistInquiryInfo2.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(SCMAnsHistInquiryInfo1.AwnserMethod != SCMAnsHistInquiryInfo2.AwnserMethod)resList.Add("AwnserMethod");
			if(SCMAnsHistInquiryInfo1.EnterpriseCode != SCMAnsHistInquiryInfo2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(SCMAnsHistInquiryInfo1.CustomerCode != SCMAnsHistInquiryInfo2.CustomerCode)resList.Add("CustomerCode");
			if(SCMAnsHistInquiryInfo1.SalesTotalTaxInc != SCMAnsHistInquiryInfo2.SalesTotalTaxInc)resList.Add("SalesTotalTaxInc");
			if(SCMAnsHistInquiryInfo1.EnterpriseName != SCMAnsHistInquiryInfo2.EnterpriseName)resList.Add("EnterpriseName");
            if (SCMAnsHistInquiryInfo1.NumberPlate3 != SCMAnsHistInquiryInfo2.NumberPlate3) resList.Add("NumberPlate3");
            if (SCMAnsHistInquiryInfo1.NumberPlate4 != SCMAnsHistInquiryInfo2.NumberPlate4) resList.Add("NumberPlate4");
            if (SCMAnsHistInquiryInfo1.FullModel != SCMAnsHistInquiryInfo2.FullModel) resList.Add("FullModel");
            if (SCMAnsHistInquiryInfo1.CarMakerCode != SCMAnsHistInquiryInfo2.CarMakerCode) resList.Add("CarMakerCode");
            if (SCMAnsHistInquiryInfo1.ModelCode != SCMAnsHistInquiryInfo2.ModelCode) resList.Add("ModelCode");
            if (SCMAnsHistInquiryInfo1.ModelSubCode != SCMAnsHistInquiryInfo2.ModelSubCode) resList.Add("ModelSubCode");
            if (SCMAnsHistInquiryInfo1.DetailMakerCode != SCMAnsHistInquiryInfo2.DetailMakerCode) resList.Add("DetailMakerCode");
            if (SCMAnsHistInquiryInfo1.BLGoodsCode != SCMAnsHistInquiryInfo2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (SCMAnsHistInquiryInfo1.GoodsNo != SCMAnsHistInquiryInfo2.GoodsNo) resList.Add("GoodsNo");
            if (SCMAnsHistInquiryInfo1.PureGoodsNo != SCMAnsHistInquiryInfo2.PureGoodsNo) resList.Add("PureGoodsNo");

			return resList;
		}

        /// <summary>
        /// �񓚋敪
        /// </summary>
        public enum AnswerDivState
        {
            /// <summary>�A�N�V�����Ȃ�(�񓚒�)</summary>
            Non = 0,
            /// <summary>�ꕔ��</summary>
            Part = 10,
            /// <summary>�񓚊���</summary>
            Complete = 20,
            /// <summary>�L�����Z��</summary>
            Cancel = 99
        }

        /// <summary>
        /// �񓚕��@
        /// </summary>
        public enum AnswerMethodState
        {
            /// <summary>����</summary>
            Auto = 0,
            /// <summary>�蓮(Web)</summary>
            ManualWeb = 1,
            /// <summary>�蓮(���̑�)</summary>
            ManualOther = 2
        }

        /// <summary>
        /// �󒍃X�e�[�^�X
        /// </summary>
        public enum AcptAnOdrStatusState
        {
            /// <summary>���ݒ�</summary>
            NotSet = 0,
            /// <summary>����</summary>
            Estimate = 10,
            /// <summary>��</summary>
            Accept = 20,
            /// <summary>����</summary>
            Sales = 30,
        }

        /// <summary>
        /// �⍇���E�����敪
        /// </summary>
        public enum InqOrdDivState
        {
            /// <summary>�⍇��</summary>
            Estimate = 1,
            /// <summary>����</summary>
            Accept = 2
        }
	}
}

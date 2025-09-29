//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �⍇���ꗗ/�󒍌����E�B���h�E
// �v���O�����T�v   : ��ʃf�[�^��ێ�����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �� �� ��  2009/05/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/05/09  �C�����e : SCM��Q��10384�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SCMInquiryOrder
	/// <summary>
	///                      SCM�₢���킹�ꗗ��ʏ��ێ��N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�₢���킹�ꗗ���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/4/13</br>
	/// <br>Genarated Date   :   2009/05/26  (CSharp File Generated Date)</br>
    /// <br></br>
	/// <br>Update Note      :   ����`�[�ԍ���ǉ��i���׌����Ɏg�p�j</br>
    /// <br>Programmer       :   21024�@���X�� ��</br>
    /// <br>Date             :   2010/05/27</br>
    /// <br>Update Note      :   Redmine 26534 �󔭒���ʂ�ǉ����APCCforNS��BL�p�[�c�I�[�_�[�V�X�e���̔��f���\�Ƃ���</br>
    /// <br>Programmer       :   ������</br>
    /// <br>Date             :   2011/11/12</br>
    /// </remarks>
	public class SCMInquiryOrder
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

		/// <summary>�񓚋敪</summary>
		/// <remarks>0:�A�N�V�����Ȃ� 1:�񓚒� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</remarks>
		private Int32[] _answerDivCd;

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

        // 2010/05/27 Add >>>
        /// <summary>����`�[�ԍ�</summary>
        private string _salesSlipNum = "";
        // 2010/05/27 Add <<<

        // ---- ADD gezh 2011/11/12 -------->>>>>
        /// <summary>�A�g�Ώۋ敪</summary>
        private Int16[] _cooperationOptionDiv;
        // ---- ADD gezh 2011/11/12 --------<<<<<

        // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
        /// <summary>�J�n���ɗ\���</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _st_ExpectedCeDate;

        /// <summary>�I�����ɗ\���</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _ed_ExpectedCeDate;
        // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
        
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

		/// public propaty name  :  AnswerDivCd
		/// <summary>�񓚋敪�v���p�e�B</summary>
		/// <value>0:�A�N�V�����Ȃ� 1:�񓚒� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32[] AnswerDivCd
		{
			get{return _answerDivCd;}
			set{_answerDivCd = value;}
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

        // 2010/05/27 Add >>>
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }
        // 2010/05/27 Add <<<
        // ---- ADD gezh 2011/11/12 --------------------------------------->>>>>
        /// public propaty name  :  CooperationOptionDiv
        /// <summary>�A�g�Ώۋ敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�g�Ώۋ敪�v���p�e�B</br>
        /// <br>Programer        :   ������</br>
        /// </remarks>
        public Int16[] CooperationOptionDiv
        {
            get { return _cooperationOptionDiv; }
            set { _cooperationOptionDiv = value; }
        }
        // ---- ADD gezh 2011/11/12 ---------------------------------------<<<<<

        // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
        /// public propaty name  :  St_ExpectedCeDate
        /// <summary>�J�n���ɗ\����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���ɗ\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_ExpectedCeDate
        {
            get { return _st_ExpectedCeDate; }
            set { _st_ExpectedCeDate = value; }
        }

        /// public propaty name  :  Ed_ExpectedCeDate
        /// <summary>�I�����ɗ\����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����ɗ\����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_ExpectedCeDate
        {
            get { return _ed_ExpectedCeDate; }
            set { _ed_ExpectedCeDate = value; }
        }
        // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<

		/// <summary>
		/// SCM�₢���킹�ꗗ���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>SCMInquiryOrder�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMInquiryOrder�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMInquiryOrder()
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
        /// <param name="st_ExpectedCeDate">�J�n���ɗ\���(YYYYMMDD)</param>  // ADD yugami 2013/05/10
        /// <param name="ed_ExpectedCeDate">�I�����ɗ\���(YYYYMMDD)</param>  // ADD yugami 2013/05/10
        /// <param name="salesSlipNum">�A�g�Ώۋ敪</param> // ADD gezh 2011/11/12
		/// <returns>SCMInquiryOrder�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMInquiryOrder�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Note�@�@�@�@�@�@ :   Redmine 26534 �󔭒���ʂ�ǉ����APCCforNS��BL�p�[�c�I�[�_�[�V�X�e���̔��f���\�Ƃ���</br>
        /// <br>Programer        :   ������</br>
		/// </remarks>
        // 2010/05/27 >>>
        //public SCMInquiryOrder(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 st_InquiryNumber, Int64 ed_InquiryNumber, DateTime updateDate, Int32 updateTime, Int32[] inqOrdDivCd, Int32[] answerDivCd, Int32 judgementDate, string inqOrdNote, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, Int32 st_InquiryDate, Int32 ed_InquiryDate, Int32 st_CustomerCode, Int32 ed_CustomerCode, string st_SalesSlipNum, string ed_SalesSlipNum, Int32[] acptAnOdrStatus, Int32[] awnserMethod, string enterpriseCode, Int32 customerCode, Int64 salesTotalTaxInc, string enterpriseName)
        //public SCMInquiryOrder(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 st_InquiryNumber, Int64 ed_InquiryNumber, DateTime updateDate, Int32 updateTime, Int32[] inqOrdDivCd, Int32[] answerDivCd, Int32 judgementDate, string inqOrdNote, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, Int32 st_InquiryDate, Int32 ed_InquiryDate, Int32 st_CustomerCode, Int32 ed_CustomerCode, string st_SalesSlipNum, string ed_SalesSlipNum, Int32[] acptAnOdrStatus, Int32[] awnserMethod, string enterpriseCode, Int32 customerCode, Int64 salesTotalTaxInc, string enterpriseName, string salesSlipNum) // DEL gezh 2011/11/12
        // UPD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
        //public SCMInquiryOrder(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 st_InquiryNumber, Int64 ed_InquiryNumber, DateTime updateDate, Int32 updateTime, Int32[] inqOrdDivCd, Int32[] answerDivCd, Int32 judgementDate, string inqOrdNote, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, Int32 st_InquiryDate, Int32 ed_InquiryDate, Int32 st_CustomerCode, Int32 ed_CustomerCode, string st_SalesSlipNum, string ed_SalesSlipNum, Int32[] acptAnOdrStatus, Int32[] awnserMethod, string enterpriseCode, Int32 customerCode, Int64 salesTotalTaxInc, string enterpriseName, string salesSlipNum, Int16[] cooperationOptionDiv) // ADD gezh 2011/11/12
        public SCMInquiryOrder(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 st_InquiryNumber, Int64 ed_InquiryNumber, DateTime updateDate, Int32 updateTime, Int32[] inqOrdDivCd, Int32[] answerDivCd, Int32 judgementDate, string inqOrdNote, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, Int32 st_InquiryDate, Int32 ed_InquiryDate, Int32 st_CustomerCode, Int32 ed_CustomerCode, string st_SalesSlipNum, string ed_SalesSlipNum, Int32[] acptAnOdrStatus, Int32[] awnserMethod, string enterpriseCode, Int32 customerCode, Int64 salesTotalTaxInc, string enterpriseName, string salesSlipNum, Int16[] cooperationOptionDiv, Int32 st_ExpectedCeDate, Int32 ed_ExpectedCeDate)
        // UPD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
        // 2010/05/27 <<<
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
			this._answerDivCd = answerDivCd;
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
            // 2010/05/27 Add >>>
            this._salesSlipNum = salesSlipNum;
            // 2010/05/27 Add <<<
            // ----ADD gezh 2011/11/12 ---------------------------------->>>>>
            this._cooperationOptionDiv = cooperationOptionDiv;
            // ----ADD gezh 2011/11/12 ----------------------------------<<<<<
            // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
            this._st_ExpectedCeDate = st_ExpectedCeDate;
            this._ed_ExpectedCeDate = ed_ExpectedCeDate;
            // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
        }

		/// <summary>
		/// SCM�₢���킹�ꗗ���o�����N���X��������
		/// </summary>
		/// <returns>SCMInquiryOrder�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SCMInquiryOrder�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Note�@�@�@�@�@�@ :   Redmine 26534 �󔭒���ʂ�ǉ����APCCforNS��BL�p�[�c�I�[�_�[�V�X�e���̔��f���\�Ƃ���</br>
        /// <br>Programer        :   ������</br>
		/// </remarks>
		public SCMInquiryOrder Clone()
		{
            // 2010/05/27 >>>
            //return new SCMInquiryOrder(this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._st_InquiryNumber, this._ed_InquiryNumber, this._updateDate, this._updateTime, this._inqOrdDivCd, this._answerDivCd, this._judgementDate, this._inqOrdNote, this._inqEmployeeCd, this._inqEmployeeNm, this._ansEmployeeCd, this._ansEmployeeNm, this._st_InquiryDate, this._ed_InquiryDate, this._st_CustomerCode, this._ed_CustomerCode, this._st_SalesSlipNum, this._ed_SalesSlipNum, this._acptAnOdrStatus, this._awnserMethod, this._enterpriseCode, this._customerCode, this._salesTotalTaxInc, this._enterpriseName);
            //return new SCMInquiryOrder(this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._st_InquiryNumber, this._ed_InquiryNumber, this._updateDate, this._updateTime, this._inqOrdDivCd, this._answerDivCd, this._judgementDate, this._inqOrdNote, this._inqEmployeeCd, this._inqEmployeeNm, this._ansEmployeeCd, this._ansEmployeeNm, this._st_InquiryDate, this._ed_InquiryDate, this._st_CustomerCode, this._ed_CustomerCode, this._st_SalesSlipNum, this._ed_SalesSlipNum, this._acptAnOdrStatus, this._awnserMethod, this._enterpriseCode, this._customerCode, this._salesTotalTaxInc, this._enterpriseName, this._salesSlipNum); // DEL gezh 2011/11/12
            // UPD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
            //return new SCMInquiryOrder(this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._st_InquiryNumber, this._ed_InquiryNumber, this._updateDate, this._updateTime, this._inqOrdDivCd, this._answerDivCd, this._judgementDate, this._inqOrdNote, this._inqEmployeeCd, this._inqEmployeeNm, this._ansEmployeeCd, this._ansEmployeeNm, this._st_InquiryDate, this._ed_InquiryDate, this._st_CustomerCode, this._ed_CustomerCode, this._st_SalesSlipNum, this._ed_SalesSlipNum, this._acptAnOdrStatus, this._awnserMethod, this._enterpriseCode, this._customerCode, this._salesTotalTaxInc, this._enterpriseName, this._salesSlipNum, this._cooperationOptionDiv); // ADD gezh 2011/11/12
            return new SCMInquiryOrder(this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._st_InquiryNumber, this._ed_InquiryNumber, this._updateDate, this._updateTime, this._inqOrdDivCd, this._answerDivCd, this._judgementDate, this._inqOrdNote, this._inqEmployeeCd, this._inqEmployeeNm, this._ansEmployeeCd, this._ansEmployeeNm, this._st_InquiryDate, this._ed_InquiryDate, this._st_CustomerCode, this._ed_CustomerCode, this._st_SalesSlipNum, this._ed_SalesSlipNum, this._acptAnOdrStatus, this._awnserMethod, this._enterpriseCode, this._customerCode, this._salesTotalTaxInc, this._enterpriseName, this._salesSlipNum, this._cooperationOptionDiv, this._st_ExpectedCeDate, this._ed_ExpectedCeDate);//@@@@20230303
            // UPD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
            // 2010/05/27 <<<
        }

		/// <summary>
		/// SCM�₢���킹�ꗗ���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SCMInquiryOrder�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMInquiryOrder�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Note�@�@�@�@�@�@ :   Redmine 26534 �󔭒���ʂ�ǉ����APCCforNS��BL�p�[�c�I�[�_�[�V�X�e���̔��f���\�Ƃ���</br>
        /// <br>Programer        :   ������</br>
		/// </remarks>
		public bool Equals(SCMInquiryOrder target)
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
				 && (this.AnswerDivCd == target.AnswerDivCd)
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
                // 2010/05/27 Add >>>
                && ( this.SalesSlipNum == target.SalesSlipNum )
                // 2010/05/27 Add <<<
                // ----ADD gezh 2011/11/12 -------------------------------->>>>>
                && (this.CooperationOptionDiv == target.CooperationOptionDiv)
                // ----ADD gezh 2011/11/12 --------------------------------<<<<<
                // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
                && (this.St_ExpectedCeDate == target.St_ExpectedCeDate)
                && (this.Ed_ExpectedCeDate == target.Ed_ExpectedCeDate)
                // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
                 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// SCM�₢���킹�ꗗ���o�����N���X��r����
		/// </summary>
		/// <param name="sCMInquiryOrder1">
		///                    ��r����SCMInquiryOrder�N���X�̃C���X�^���X
		/// </param>
		/// <param name="sCMInquiryOrder2">��r����SCMInquiryOrder�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMInquiryOrder�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Note�@�@�@�@�@�@ :   Redmine 26534 �󔭒���ʂ�ǉ����APCCforNS��BL�p�[�c�I�[�_�[�V�X�e���̔��f���\�Ƃ���</br>
        /// <br>Programer        :   ������</br>
		/// </remarks>
		public static bool Equals(SCMInquiryOrder sCMInquiryOrder1, SCMInquiryOrder sCMInquiryOrder2)
		{
			return ((sCMInquiryOrder1.InqOriginalEpCd.Trim() == sCMInquiryOrder2.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (sCMInquiryOrder1.InqOriginalSecCd == sCMInquiryOrder2.InqOriginalSecCd)
				 && (sCMInquiryOrder1.InqOtherEpCd == sCMInquiryOrder2.InqOtherEpCd)
				 && (sCMInquiryOrder1.InqOtherSecCd == sCMInquiryOrder2.InqOtherSecCd)
				 && (sCMInquiryOrder1.St_InquiryNumber == sCMInquiryOrder2.St_InquiryNumber)
				 && (sCMInquiryOrder1.Ed_InquiryNumber == sCMInquiryOrder2.Ed_InquiryNumber)
				 && (sCMInquiryOrder1.UpdateDate == sCMInquiryOrder2.UpdateDate)
				 && (sCMInquiryOrder1.UpdateTime == sCMInquiryOrder2.UpdateTime)
				 && (sCMInquiryOrder1.InqOrdDivCd == sCMInquiryOrder2.InqOrdDivCd)
				 && (sCMInquiryOrder1.AnswerDivCd == sCMInquiryOrder2.AnswerDivCd)
				 && (sCMInquiryOrder1.JudgementDate == sCMInquiryOrder2.JudgementDate)
				 && (sCMInquiryOrder1.InqOrdNote == sCMInquiryOrder2.InqOrdNote)
				 && (sCMInquiryOrder1.InqEmployeeCd == sCMInquiryOrder2.InqEmployeeCd)
				 && (sCMInquiryOrder1.InqEmployeeNm == sCMInquiryOrder2.InqEmployeeNm)
				 && (sCMInquiryOrder1.AnsEmployeeCd == sCMInquiryOrder2.AnsEmployeeCd)
				 && (sCMInquiryOrder1.AnsEmployeeNm == sCMInquiryOrder2.AnsEmployeeNm)
				 && (sCMInquiryOrder1.St_InquiryDate == sCMInquiryOrder2.St_InquiryDate)
				 && (sCMInquiryOrder1.Ed_InquiryDate == sCMInquiryOrder2.Ed_InquiryDate)
				 && (sCMInquiryOrder1.St_CustomerCode == sCMInquiryOrder2.St_CustomerCode)
				 && (sCMInquiryOrder1.Ed_CustomerCode == sCMInquiryOrder2.Ed_CustomerCode)
				 && (sCMInquiryOrder1.St_SalesSlipNum == sCMInquiryOrder2.St_SalesSlipNum)
				 && (sCMInquiryOrder1.Ed_SalesSlipNum == sCMInquiryOrder2.Ed_SalesSlipNum)
				 && (sCMInquiryOrder1.AcptAnOdrStatus == sCMInquiryOrder2.AcptAnOdrStatus)
				 && (sCMInquiryOrder1.AwnserMethod == sCMInquiryOrder2.AwnserMethod)
				 && (sCMInquiryOrder1.EnterpriseCode == sCMInquiryOrder2.EnterpriseCode)
				 && (sCMInquiryOrder1.CustomerCode == sCMInquiryOrder2.CustomerCode)
				 && (sCMInquiryOrder1.SalesTotalTaxInc == sCMInquiryOrder2.SalesTotalTaxInc)
                // 2010/05/27 Add >>>
                && ( sCMInquiryOrder1.SalesSlipNum == sCMInquiryOrder2.SalesSlipNum )
                // 2010/05/27 Add <<<
                // ----ADD gezh 2011/11/12 -------------------------------->>>>>
                && (sCMInquiryOrder1.CooperationOptionDiv == sCMInquiryOrder2.CooperationOptionDiv)
                // ----ADD gezh 2011/11/12 --------------------------------<<<<<
                // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
                && (sCMInquiryOrder1.St_ExpectedCeDate == sCMInquiryOrder2.St_ExpectedCeDate)
                && (sCMInquiryOrder1.Ed_ExpectedCeDate == sCMInquiryOrder2.Ed_ExpectedCeDate)
                // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
                 && ( sCMInquiryOrder1.EnterpriseName == sCMInquiryOrder2.EnterpriseName ) );
		}
		/// <summary>
		/// SCM�₢���킹�ꗗ���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SCMInquiryOrder�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMInquiryOrder�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Note�@�@�@�@�@�@ :   Redmine 26534 �󔭒���ʂ�ǉ����APCCforNS��BL�p�[�c�I�[�_�[�V�X�e���̔��f���\�Ƃ���</br>
        /// <br>Programer        :   ������</br>
		/// </remarks>
		public ArrayList Compare(SCMInquiryOrder target)
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
			if(this.AnswerDivCd != target.AnswerDivCd)resList.Add("AnswerDivCd");
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
            // 2010/05/27 Add >>>
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            // 2010/05/27 Add <<<
            // ----ADD gezh 2011/11/12 ----------------------------------------------------------------->>>>>
            if (this.CooperationOptionDiv != target.CooperationOptionDiv) resList.Add("CooperationOptionDiv");
            // ----ADD gezh 2011/11/12 -----------------------------------------------------------------<<<<<
            // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
            if (this.St_ExpectedCeDate != target.St_ExpectedCeDate) resList.Add("St_ExpectedCeDate");
            if (this.Ed_ExpectedCeDate != target.Ed_ExpectedCeDate) resList.Add("Ed_ExpectedCeDate");
            // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
            return resList;
		}

		/// <summary>
		/// SCM�₢���킹�ꗗ���o�����N���X��r����
		/// </summary>
		/// <param name="sCMInquiryOrder1">��r����SCMInquiryOrder�N���X�̃C���X�^���X</param>
		/// <param name="sCMInquiryOrder2">��r����SCMInquiryOrder�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMInquiryOrder�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Note�@�@�@�@�@�@ :   Redmine 26534 �󔭒���ʂ�ǉ����APCCforNS��BL�p�[�c�I�[�_�[�V�X�e���̔��f���\�Ƃ���</br>
        /// <br>Programer        :   ������</br>
		/// </remarks>
		public static ArrayList Compare(SCMInquiryOrder sCMInquiryOrder1, SCMInquiryOrder sCMInquiryOrder2)
		{
			ArrayList resList = new ArrayList();
			if(sCMInquiryOrder1.InqOriginalEpCd.Trim() != sCMInquiryOrder2.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(sCMInquiryOrder1.InqOriginalSecCd != sCMInquiryOrder2.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(sCMInquiryOrder1.InqOtherEpCd != sCMInquiryOrder2.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(sCMInquiryOrder1.InqOtherSecCd != sCMInquiryOrder2.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(sCMInquiryOrder1.St_InquiryNumber != sCMInquiryOrder2.St_InquiryNumber)resList.Add("St_InquiryNumber");
			if(sCMInquiryOrder1.Ed_InquiryNumber != sCMInquiryOrder2.Ed_InquiryNumber)resList.Add("Ed_InquiryNumber");
			if(sCMInquiryOrder1.UpdateDate != sCMInquiryOrder2.UpdateDate)resList.Add("UpdateDate");
			if(sCMInquiryOrder1.UpdateTime != sCMInquiryOrder2.UpdateTime)resList.Add("UpdateTime");
			if(sCMInquiryOrder1.InqOrdDivCd != sCMInquiryOrder2.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(sCMInquiryOrder1.AnswerDivCd != sCMInquiryOrder2.AnswerDivCd)resList.Add("AnswerDivCd");
			if(sCMInquiryOrder1.JudgementDate != sCMInquiryOrder2.JudgementDate)resList.Add("JudgementDate");
			if(sCMInquiryOrder1.InqOrdNote != sCMInquiryOrder2.InqOrdNote)resList.Add("InqOrdNote");
			if(sCMInquiryOrder1.InqEmployeeCd != sCMInquiryOrder2.InqEmployeeCd)resList.Add("InqEmployeeCd");
			if(sCMInquiryOrder1.InqEmployeeNm != sCMInquiryOrder2.InqEmployeeNm)resList.Add("InqEmployeeNm");
			if(sCMInquiryOrder1.AnsEmployeeCd != sCMInquiryOrder2.AnsEmployeeCd)resList.Add("AnsEmployeeCd");
			if(sCMInquiryOrder1.AnsEmployeeNm != sCMInquiryOrder2.AnsEmployeeNm)resList.Add("AnsEmployeeNm");
			if(sCMInquiryOrder1.St_InquiryDate != sCMInquiryOrder2.St_InquiryDate)resList.Add("St_InquiryDate");
			if(sCMInquiryOrder1.Ed_InquiryDate != sCMInquiryOrder2.Ed_InquiryDate)resList.Add("Ed_InquiryDate");
			if(sCMInquiryOrder1.St_CustomerCode != sCMInquiryOrder2.St_CustomerCode)resList.Add("St_CustomerCode");
			if(sCMInquiryOrder1.Ed_CustomerCode != sCMInquiryOrder2.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(sCMInquiryOrder1.St_SalesSlipNum != sCMInquiryOrder2.St_SalesSlipNum)resList.Add("St_SalesSlipNum");
			if(sCMInquiryOrder1.Ed_SalesSlipNum != sCMInquiryOrder2.Ed_SalesSlipNum)resList.Add("Ed_SalesSlipNum");
			if(sCMInquiryOrder1.AcptAnOdrStatus != sCMInquiryOrder2.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(sCMInquiryOrder1.AwnserMethod != sCMInquiryOrder2.AwnserMethod)resList.Add("AwnserMethod");
			if(sCMInquiryOrder1.EnterpriseCode != sCMInquiryOrder2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(sCMInquiryOrder1.CustomerCode != sCMInquiryOrder2.CustomerCode)resList.Add("CustomerCode");
			if(sCMInquiryOrder1.SalesTotalTaxInc != sCMInquiryOrder2.SalesTotalTaxInc)resList.Add("SalesTotalTaxInc");
			if(sCMInquiryOrder1.EnterpriseName != sCMInquiryOrder2.EnterpriseName)resList.Add("EnterpriseName");
            // 2010/05/27 Add >>>
            if (sCMInquiryOrder1.SalesSlipNum != sCMInquiryOrder2.SalesSlipNum) resList.Add("SalesSlipNum");
            // 2010/05/27 Add <<<
            // ----ADD gezh 2011/11/12 ----------------------------------------------------------------------------------------->>>>>
            if (sCMInquiryOrder1.CooperationOptionDiv != sCMInquiryOrder2.CooperationOptionDiv) resList.Add("CooperationOptionDiv");
            // ----ADD gezh 2011/11/12 -----------------------------------------------------------------------------------------<<<<<
            // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
            if (sCMInquiryOrder1.St_ExpectedCeDate != sCMInquiryOrder2.St_ExpectedCeDate) resList.Add("St_ExpectedCeDate");
            if (sCMInquiryOrder1.Ed_ExpectedCeDate != sCMInquiryOrder2.Ed_ExpectedCeDate) resList.Add("Ed_ExpectedCeDate");
            // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
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
        // ADD gezh 2011/11/12 -------->>>>>
        /// <summary>
        /// �A�g�Ώۋ敪
        /// </summary>
        public enum CooperationOptionDivState
        {
            /// <summary>PCCforNS</summary>
            PCCNS = 0,
            /// <summary>BL�߰µ��ް</summary>
            BL = 1
        }
        // ADD gezh 2011/11/12 --------<<<<<
	}
}

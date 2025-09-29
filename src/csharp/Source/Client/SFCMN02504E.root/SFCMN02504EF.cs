using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmOdSrchParam
	/// <summary>
	///                      SCM�󔭒����������N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�󔭒����������N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/4/30</br>
	/// <br>Genarated Date   :   2011/05/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2011/5/19  �{���@���[</br>
	/// <br>                 :   SCM�I�v�V����(PM�A�g 3������)�Ή�</br>
	/// <br>                 :   �ESF-PM�A�g�w�����ԍ�</br>
	/// <br>                 :   �E��������敪</br>
	/// <br>                 :   ���ڒǉ�</br>
	/// <br>Update Note      :   2011/5/24  �����@���l</br>
	/// <br>                 :   SCM�I�v�V����(PM�A�g 3������)�Ή�</br>
	/// <br>                 :   �E�X�V�N�����i�I���j</br>
	/// <br>                 :   �E�X�V�����~���b�i�I���j</br>
	/// <br>                 :   ���ڒǉ�</br>
	/// <br>                 :   �X�V�N�����i�J�n�j</br>
	/// <br>                 :   �X�V�����b�~���b�i�J�n�j</br>
	/// <br>                 :   ���̕ύX</br>
	/// </remarks>
	[Serializable]
	public class ScmOdSrchParam
	{
		/// <summary>�⍇������ƃR�[�h</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>�⍇�������_�R�[�h</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>�⍇�����ƃR�[�h</summary>
		private string _inqOtherEpCd = "";

		/// <summary>�⍇���拒�_�R�[�h</summary>
		private string _inqOtherSecCd = "";

		/// <summary>�⍇���ԍ�</summary>
		/// <remarks>�z��^</remarks>
		private Int64[] _inquiryNumber;

		/// <summary>�⍇���ԍ�(�J�n)</summary>
		private Int64 _inquiryNumberSt;

		/// <summary>�⍇���ԍ�(�I��)</summary>
		private Int64 _inquiryNumberEd;

		/// <summary>�X�V�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDateSt;

		/// <summary>�X�V�����b�~���b�i�J�n�j</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTimeSt;

		/// <summary>�⍇���]�ƈ��R�[�h</summary>
		/// <remarks>�⍇�������]�ƈ��R�[�h</remarks>
		private string _inqEmployeeCd = "";

		/// <summary>�񓚏]�ƈ��R�[�h</summary>
		private string _ansEmployeeCd = "";

		/// <summary>�⍇���E�������</summary>
		/// <remarks>1:�⍇�� 2:����</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>�ŐV���ʋ敪</summary>
		/// <remarks>0:�ŐV�f�[�^ 1:���f�[�^</remarks>
		private Int16 _latestDiscCode;

		/// <summary>SF-PM�A�g�w�����ԍ�</summary>
		private string _sfPmCprtInstSlipNo = "";

		/// <summary>��������敪</summary>
		/// <remarks>0:������ 1:����</remarks>
		private Int32 _transCmpltDivCd;

		/// <summary>�X�V�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDateEd;

		/// <summary>�X�V�����~���b�i�I���j</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTimeEd;


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
		/// <value>�z��^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64[] InquiryNumber
		{
			get { return _inquiryNumber; }
			set { _inquiryNumber = value; }
		}

		/// public propaty name  :  InquiryNumberSt
		/// <summary>�⍇���ԍ�(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���ԍ�(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 InquiryNumberSt
		{
			get { return _inquiryNumberSt; }
			set { _inquiryNumberSt = value; }
		}

		/// public propaty name  :  InquiryNumberEd
		/// <summary>�⍇���ԍ�(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���ԍ�(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 InquiryNumberEd
		{
			get { return _inquiryNumberEd; }
			set { _inquiryNumberEd = value; }
		}

		/// public propaty name  :  UpdateDateSt
		/// <summary>�X�V�N�����i�J�n�j�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����i�J�n�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDateSt
		{
			get { return _updateDateSt; }
			set { _updateDateSt = value; }
		}

		/// public propaty name  :  UpdateDateStJpFormal
		/// <summary>�X�V�N�����i�J�n�j �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����i�J�n�j �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateStJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateSt); }
			set { }
		}

		/// public propaty name  :  UpdateDateStJpInFormal
		/// <summary>�X�V�N�����i�J�n�j �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����i�J�n�j �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateStJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateSt); }
			set { }
		}

		/// public propaty name  :  UpdateDateStAdFormal
		/// <summary>�X�V�N�����i�J�n�j ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����i�J�n�j ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateStAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateSt); }
			set { }
		}

		/// public propaty name  :  UpdateDateStAdInFormal
		/// <summary>�X�V�N�����i�J�n�j ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����i�J�n�j ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateStAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateSt); }
			set { }
		}

		/// public propaty name  :  UpdateTimeSt
		/// <summary>�X�V�����b�~���b�i�J�n�j�v���p�e�B</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����b�~���b�i�J�n�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UpdateTimeSt
		{
			get { return _updateTimeSt; }
			set { _updateTimeSt = value; }
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
			get { return _inqEmployeeCd; }
			set { _inqEmployeeCd = value; }
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
			get { return _ansEmployeeCd; }
			set { _ansEmployeeCd = value; }
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

		/// public propaty name  :  SfPmCprtInstSlipNo
		/// <summary>SF-PM�A�g�w�����ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   SF-PM�A�g�w�����ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SfPmCprtInstSlipNo
		{
			get { return _sfPmCprtInstSlipNo; }
			set { _sfPmCprtInstSlipNo = value; }
		}

		/// public propaty name  :  TransCmpltDivCd
		/// <summary>��������敪�v���p�e�B</summary>
		/// <value>0:������ 1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TransCmpltDivCd
		{
			get { return _transCmpltDivCd; }
			set { _transCmpltDivCd = value; }
		}

		/// public propaty name  :  UpdateDateEd
		/// <summary>�X�V�N�����i�I���j�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����i�I���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDateEd
		{
			get { return _updateDateEd; }
			set { _updateDateEd = value; }
		}

		/// public propaty name  :  UpdateDateEdJpFormal
		/// <summary>�X�V�N�����i�I���j �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����i�I���j �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateEdJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateEd); }
			set { }
		}

		/// public propaty name  :  UpdateDateEdJpInFormal
		/// <summary>�X�V�N�����i�I���j �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����i�I���j �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateEdJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateEd); }
			set { }
		}

		/// public propaty name  :  UpdateDateEdAdFormal
		/// <summary>�X�V�N�����i�I���j ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����i�I���j ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateEdAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateEd); }
			set { }
		}

		/// public propaty name  :  UpdateDateEdAdInFormal
		/// <summary>�X�V�N�����i�I���j ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����i�I���j ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateEdAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateEd); }
			set { }
		}

		/// public propaty name  :  UpdateTimeEd
		/// <summary>�X�V�����~���b�i�I���j�v���p�e�B</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����~���b�i�I���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UpdateTimeEd
		{
			get { return _updateTimeEd; }
			set { _updateTimeEd = value; }
		}


		/// <summary>
		/// SCM�󔭒����������N���X�R���X�g���N�^
		/// </summary>
		/// <returns>ScmOdSrchParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdSrchParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmOdSrchParam()
		{
		}

		/// <summary>
		/// SCM�󔭒����������N���X�R���X�g���N�^
		/// </summary>
		/// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
		/// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
		/// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
		/// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
		/// <param name="inquiryNumber">�⍇���ԍ�(�z��^)</param>
		/// <param name="inquiryNumberSt">�⍇���ԍ�(�J�n)</param>
		/// <param name="inquiryNumberEd">�⍇���ԍ�(�I��)</param>
		/// <param name="updateDateSt">�X�V�N�����i�J�n�j(YYYYMMDD)</param>
		/// <param name="updateTimeSt">�X�V�����b�~���b�i�J�n�j(HHMMSSXXX)</param>
		/// <param name="inqEmployeeCd">�⍇���]�ƈ��R�[�h(�⍇�������]�ƈ��R�[�h)</param>
		/// <param name="ansEmployeeCd">�񓚏]�ƈ��R�[�h</param>
		/// <param name="inqOrdDivCd">�⍇���E�������(1:�⍇�� 2:����)</param>
		/// <param name="latestDiscCode">�ŐV���ʋ敪(0:�ŐV�f�[�^ 1:���f�[�^)</param>
		/// <param name="sfPmCprtInstSlipNo">SF-PM�A�g�w�����ԍ�</param>
		/// <param name="transCmpltDivCd">��������敪(0:������ 1:����)</param>
		/// <param name="updateDateEd">�X�V�N�����i�I���j(YYYYMMDD)</param>
		/// <param name="updateTimeEd">�X�V�����~���b�i�I���j(HHMMSSXXX)</param>
		/// <returns>ScmOdSrchParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdSrchParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmOdSrchParam(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64[] inquiryNumber, Int64 inquiryNumberSt, Int64 inquiryNumberEd, DateTime updateDateSt, Int32 updateTimeSt, string inqEmployeeCd, string ansEmployeeCd, Int32 inqOrdDivCd, Int16 latestDiscCode, string sfPmCprtInstSlipNo, Int32 transCmpltDivCd, DateTime updateDateEd, Int32 updateTimeEd)
		{
			this._inqOriginalEpCd = inqOriginalEpCd;
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this._inquiryNumber = inquiryNumber;
			this._inquiryNumberSt = inquiryNumberSt;
			this._inquiryNumberEd = inquiryNumberEd;
			this.UpdateDateSt = updateDateSt;
			this._updateTimeSt = updateTimeSt;
			this._inqEmployeeCd = inqEmployeeCd;
			this._ansEmployeeCd = ansEmployeeCd;
			this._inqOrdDivCd = inqOrdDivCd;
			this._latestDiscCode = latestDiscCode;
			this._sfPmCprtInstSlipNo = sfPmCprtInstSlipNo;
			this._transCmpltDivCd = transCmpltDivCd;
			this.UpdateDateEd = updateDateEd;
			this._updateTimeEd = updateTimeEd;

		}

		/// <summary>
		/// SCM�󔭒����������N���X��������
		/// </summary>
		/// <returns>ScmOdSrchParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ScmOdSrchParam�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmOdSrchParam Clone()
		{
			return new ScmOdSrchParam(this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._inquiryNumberSt, this._inquiryNumberEd, this._updateDateSt, this._updateTimeSt, this._inqEmployeeCd, this._ansEmployeeCd, this._inqOrdDivCd, this._latestDiscCode, this._sfPmCprtInstSlipNo, this._transCmpltDivCd, this._updateDateEd, this._updateTimeEd);
		}

		/// <summary>
		/// SCM�󔭒����������N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmOdSrchParam�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdSrchParam�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ScmOdSrchParam target)
		{
			return ((this.InqOriginalEpCd == target.InqOriginalEpCd)
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InqOtherEpCd == target.InqOtherEpCd)
				 && (this.InqOtherSecCd == target.InqOtherSecCd)
				 && (this.InquiryNumber == target.InquiryNumber)
				 && (this.InquiryNumberSt == target.InquiryNumberSt)
				 && (this.InquiryNumberEd == target.InquiryNumberEd)
				 && (this.UpdateDateSt == target.UpdateDateSt)
				 && (this.UpdateTimeSt == target.UpdateTimeSt)
				 && (this.InqEmployeeCd == target.InqEmployeeCd)
				 && (this.AnsEmployeeCd == target.AnsEmployeeCd)
				 && (this.InqOrdDivCd == target.InqOrdDivCd)
				 && (this.LatestDiscCode == target.LatestDiscCode)
				 && (this.SfPmCprtInstSlipNo == target.SfPmCprtInstSlipNo)
				 && (this.TransCmpltDivCd == target.TransCmpltDivCd)
				 && (this.UpdateDateEd == target.UpdateDateEd)
				 && (this.UpdateTimeEd == target.UpdateTimeEd));
		}

		/// <summary>
		/// SCM�󔭒����������N���X��r����
		/// </summary>
		/// <param name="scmOdSrchParam1">
		///                    ��r����ScmOdSrchParam�N���X�̃C���X�^���X
		/// </param>
		/// <param name="scmOdSrchParam2">��r����ScmOdSrchParam�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdSrchParam�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(ScmOdSrchParam scmOdSrchParam1, ScmOdSrchParam scmOdSrchParam2)
		{
			return ((scmOdSrchParam1.InqOriginalEpCd == scmOdSrchParam2.InqOriginalEpCd)
				 && (scmOdSrchParam1.InqOriginalSecCd == scmOdSrchParam2.InqOriginalSecCd)
				 && (scmOdSrchParam1.InqOtherEpCd == scmOdSrchParam2.InqOtherEpCd)
				 && (scmOdSrchParam1.InqOtherSecCd == scmOdSrchParam2.InqOtherSecCd)
				 && (scmOdSrchParam1.InquiryNumber == scmOdSrchParam2.InquiryNumber)
				 && (scmOdSrchParam1.InquiryNumberSt == scmOdSrchParam2.InquiryNumberSt)
				 && (scmOdSrchParam1.InquiryNumberEd == scmOdSrchParam2.InquiryNumberEd)
				 && (scmOdSrchParam1.UpdateDateSt == scmOdSrchParam2.UpdateDateSt)
				 && (scmOdSrchParam1.UpdateTimeSt == scmOdSrchParam2.UpdateTimeSt)
				 && (scmOdSrchParam1.InqEmployeeCd == scmOdSrchParam2.InqEmployeeCd)
				 && (scmOdSrchParam1.AnsEmployeeCd == scmOdSrchParam2.AnsEmployeeCd)
				 && (scmOdSrchParam1.InqOrdDivCd == scmOdSrchParam2.InqOrdDivCd)
				 && (scmOdSrchParam1.LatestDiscCode == scmOdSrchParam2.LatestDiscCode)
				 && (scmOdSrchParam1.SfPmCprtInstSlipNo == scmOdSrchParam2.SfPmCprtInstSlipNo)
				 && (scmOdSrchParam1.TransCmpltDivCd == scmOdSrchParam2.TransCmpltDivCd)
				 && (scmOdSrchParam1.UpdateDateEd == scmOdSrchParam2.UpdateDateEd)
				 && (scmOdSrchParam1.UpdateTimeEd == scmOdSrchParam2.UpdateTimeEd));
		}
		/// <summary>
		/// SCM�󔭒����������N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmOdSrchParam�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdSrchParam�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ScmOdSrchParam target)
		{
			ArrayList resList = new ArrayList();
			if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
			if (this.InquiryNumberSt != target.InquiryNumberSt) resList.Add("InquiryNumberSt");
			if (this.InquiryNumberEd != target.InquiryNumberEd) resList.Add("InquiryNumberEd");
			if (this.UpdateDateSt != target.UpdateDateSt) resList.Add("UpdateDateSt");
			if (this.UpdateTimeSt != target.UpdateTimeSt) resList.Add("UpdateTimeSt");
			if (this.InqEmployeeCd != target.InqEmployeeCd) resList.Add("InqEmployeeCd");
			if (this.AnsEmployeeCd != target.AnsEmployeeCd) resList.Add("AnsEmployeeCd");
			if (this.InqOrdDivCd != target.InqOrdDivCd) resList.Add("InqOrdDivCd");
			if (this.LatestDiscCode != target.LatestDiscCode) resList.Add("LatestDiscCode");
			if (this.SfPmCprtInstSlipNo != target.SfPmCprtInstSlipNo) resList.Add("SfPmCprtInstSlipNo");
			if (this.TransCmpltDivCd != target.TransCmpltDivCd) resList.Add("TransCmpltDivCd");
			if (this.UpdateDateEd != target.UpdateDateEd) resList.Add("UpdateDateEd");
			if (this.UpdateTimeEd != target.UpdateTimeEd) resList.Add("UpdateTimeEd");

			return resList;
		}

		/// <summary>
		/// SCM�󔭒����������N���X��r����
		/// </summary>
		/// <param name="scmOdSrchParam1">��r����ScmOdSrchParam�N���X�̃C���X�^���X</param>
		/// <param name="scmOdSrchParam2">��r����ScmOdSrchParam�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdSrchParam�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ScmOdSrchParam scmOdSrchParam1, ScmOdSrchParam scmOdSrchParam2)
		{
			ArrayList resList = new ArrayList();
			if (scmOdSrchParam1.InqOriginalEpCd != scmOdSrchParam2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (scmOdSrchParam1.InqOriginalSecCd != scmOdSrchParam2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (scmOdSrchParam1.InqOtherEpCd != scmOdSrchParam2.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (scmOdSrchParam1.InqOtherSecCd != scmOdSrchParam2.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (scmOdSrchParam1.InquiryNumber != scmOdSrchParam2.InquiryNumber) resList.Add("InquiryNumber");
			if (scmOdSrchParam1.InquiryNumberSt != scmOdSrchParam2.InquiryNumberSt) resList.Add("InquiryNumberSt");
			if (scmOdSrchParam1.InquiryNumberEd != scmOdSrchParam2.InquiryNumberEd) resList.Add("InquiryNumberEd");
			if (scmOdSrchParam1.UpdateDateSt != scmOdSrchParam2.UpdateDateSt) resList.Add("UpdateDateSt");
			if (scmOdSrchParam1.UpdateTimeSt != scmOdSrchParam2.UpdateTimeSt) resList.Add("UpdateTimeSt");
			if (scmOdSrchParam1.InqEmployeeCd != scmOdSrchParam2.InqEmployeeCd) resList.Add("InqEmployeeCd");
			if (scmOdSrchParam1.AnsEmployeeCd != scmOdSrchParam2.AnsEmployeeCd) resList.Add("AnsEmployeeCd");
			if (scmOdSrchParam1.InqOrdDivCd != scmOdSrchParam2.InqOrdDivCd) resList.Add("InqOrdDivCd");
			if (scmOdSrchParam1.LatestDiscCode != scmOdSrchParam2.LatestDiscCode) resList.Add("LatestDiscCode");
			if (scmOdSrchParam1.SfPmCprtInstSlipNo != scmOdSrchParam2.SfPmCprtInstSlipNo) resList.Add("SfPmCprtInstSlipNo");
			if (scmOdSrchParam1.TransCmpltDivCd != scmOdSrchParam2.TransCmpltDivCd) resList.Add("TransCmpltDivCd");
			if (scmOdSrchParam1.UpdateDateEd != scmOdSrchParam2.UpdateDateEd) resList.Add("UpdateDateEd");
			if (scmOdSrchParam1.UpdateTimeEd != scmOdSrchParam2.UpdateTimeEd) resList.Add("UpdateTimeEd");

			return resList;
		}
	}
}

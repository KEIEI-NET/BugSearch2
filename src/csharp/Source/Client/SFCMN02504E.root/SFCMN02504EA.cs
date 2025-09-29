using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmOdrData
	/// <summary>
	///                      SCM�󔭒��f�[�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�󔭒��f�[�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/2/20</br>
	/// <br>Genarated Date   :   2011/08/10  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/5/7  ����@�_�u</br>
	/// <br>                 :   �⍇���E�������,�Y�t�t�@�C��,</br>
	/// <br>                 :   �Y�t�t�@�C����,������</br>
	/// <br>                 :   �폜</br>
	/// <br>Update Note      :   2009/5/19  ��{�@�E</br>
	/// <br>                 :   ��M�����ǉ�</br>
	/// <br>Update Note      :   2009/5/22  ����@�_�u</br>
	/// <br>                 :   �ŐV���ʋ敪</br>
	/// <br>                 :   �ǉ�</br>
	/// <br>Update Note      :   2010/5/17  �����@���l</br>
	/// <br>                 :   �L�����Z���敪�ACMT�A�g�敪</br>
	/// <br>                 :   �ǉ�</br>
	/// <br>Update Note      :   2011/2/7  ����@�_�u</br>
	/// <br>                 :   CMT�A�g�敪</br>
	/// <br>                 :   �⑫�����̓��e���C��</br>
	/// <br>Update Note      :   2011/4/19  �����@���l</br>
	/// <br>                 :   SF-PM�A�g�w�����ԍ�</br>
	/// <br>                 :   �ǉ�</br>
	/// <br>                 :   �񓚋敪</br>
	/// <br>                 :   �⑫�����̓��e���C��</br>
	/// <br>Update Note      :   2011/7/25  ���Ԍ��@�[</br>
	/// <br>                 :   �󔭒����</br>
	/// <br>                 :   �ǉ�</br>
	/// </remarks>
	[Serializable]
	public class ScmOdrData
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

		/// <summary>�񓚋敪</summary>
		/// <remarks>0:�A�N�V�����Ȃ� 1:�񓚒� 2:��t�ς� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</remarks>
		private Int32 _answerDivCd;

		/// <summary>�m���</summary>
		/// <remarks>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</remarks>
		private DateTime _judgementDate;

		/// <summary>�⍇���E�������l</summary>
		private string _inqOrdNote = "";

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

		/// <summary>�⍇����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _inquiryDate;

		/// <summary>�⍇���E�������</summary>
		/// <remarks>1:�⍇�� 2:����</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>�┭�E�񓚎��</summary>
		/// <remarks>1:�⍇���E���� 2:��</remarks>
		private Int32 _inqOrdAnsDivCd;

		/// <summary>��M����</summary>
		/// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _receiveDateTime;

		/// <summary>�ŐV���ʋ敪</summary>
		/// <remarks>0:�ŐV�f�[�^ 1:���f�[�^</remarks>
		private Int16 _latestDiscCode;

		/// <summary>�L�����Z���敪</summary>
		/// <remarks>0:�L�����Z���Ȃ� 1:�L�����Z������</remarks>
		private Int16 _cancelDiv;

		/// <summary>CMT�A�g�敪</summary>
		/// <remarks>0:�A�g�Ȃ� 1:�A�g���� 11:�⍇�������� 12:����������</remarks>
		private Int16 _cMTCooprtDiv;

		/// <summary>SF-PM�A�g�w�����ԍ�</summary>
		/// <remarks>(���p�S�p����)</remarks>
		private string _sfPmCprtInstSlipNo = "";

		/// <summary>�󔭒����</summary>
		/// <remarks>0:�ʏ�,1:PCC-UOE</remarks>
		private Int16 _acceptOrOrderKind;


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

		/// public propaty name  :  AnswerDivCd
		/// <summary>�񓚋敪�v���p�e�B</summary>
		/// <value>0:�A�N�V�����Ȃ� 1:�񓚒� 2:��t�ς� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AnswerDivCd
		{
			get { return _answerDivCd; }
			set { _answerDivCd = value; }
		}

		/// public propaty name  :  JudgementDate
		/// <summary>�m����v���p�e�B</summary>
		/// <value>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �m����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime JudgementDate
		{
			get { return _judgementDate; }
			set { _judgementDate = value; }
		}

		/// public propaty name  :  JudgementDateJpFormal
		/// <summary>�m��� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �m��� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string JudgementDateJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _judgementDate); }
			set { }
		}

		/// public propaty name  :  JudgementDateJpInFormal
		/// <summary>�m��� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �m��� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string JudgementDateJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _judgementDate); }
			set { }
		}

		/// public propaty name  :  JudgementDateAdFormal
		/// <summary>�m��� ����v���p�e�B</summary>
		/// <value>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �m��� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string JudgementDateAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _judgementDate); }
			set { }
		}

		/// public propaty name  :  JudgementDateAdInFormal
		/// <summary>�m��� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �m��� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string JudgementDateAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _judgementDate); }
			set { }
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
			get { return _inqOrdNote; }
			set { _inqOrdNote = value; }
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
			get { return _inqEmployeeNm; }
			set { _inqEmployeeNm = value; }
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

		/// public propaty name  :  AnsEmployeeNm
		/// <summary>�񓚏]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsEmployeeNm
		{
			get { return _ansEmployeeNm; }
			set { _ansEmployeeNm = value; }
		}

		/// public propaty name  :  InquiryDate
		/// <summary>�⍇�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime InquiryDate
		{
			get { return _inquiryDate; }
			set { _inquiryDate = value; }
		}

		/// public propaty name  :  InquiryDateJpFormal
		/// <summary>�⍇���� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InquiryDateJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _inquiryDate); }
			set { }
		}

		/// public propaty name  :  InquiryDateJpInFormal
		/// <summary>�⍇���� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InquiryDateJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _inquiryDate); }
			set { }
		}

		/// public propaty name  :  InquiryDateAdFormal
		/// <summary>�⍇���� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InquiryDateAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _inquiryDate); }
			set { }
		}

		/// public propaty name  :  InquiryDateAdInFormal
		/// <summary>�⍇���� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InquiryDateAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _inquiryDate); }
			set { }
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

		/// public propaty name  :  InqOrdAnsDivCd
		/// <summary>�┭�E�񓚎�ʃv���p�e�B</summary>
		/// <value>1:�⍇���E���� 2:��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �┭�E�񓚎�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqOrdAnsDivCd
		{
			get { return _inqOrdAnsDivCd; }
			set { _inqOrdAnsDivCd = value; }
		}

		/// public propaty name  :  ReceiveDateTime
		/// <summary>��M�����v���p�e�B</summary>
		/// <value>�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��M�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime ReceiveDateTime
		{
			get { return _receiveDateTime; }
			set { _receiveDateTime = value; }
		}

		/// public propaty name  :  ReceiveDateTimeJpFormal
		/// <summary>��M���� �a��v���p�e�B</summary>
		/// <value>�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��M���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ReceiveDateTimeJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _receiveDateTime); }
			set { }
		}

		/// public propaty name  :  ReceiveDateTimeJpInFormal
		/// <summary>��M���� �a��(��)�v���p�e�B</summary>
		/// <value>�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��M���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ReceiveDateTimeJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _receiveDateTime); }
			set { }
		}

		/// public propaty name  :  ReceiveDateTimeAdFormal
		/// <summary>��M���� ����v���p�e�B</summary>
		/// <value>�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��M���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ReceiveDateTimeAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _receiveDateTime); }
			set { }
		}

		/// public propaty name  :  ReceiveDateTimeAdInFormal
		/// <summary>��M���� ����(��)�v���p�e�B</summary>
		/// <value>�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��M���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ReceiveDateTimeAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _receiveDateTime); }
			set { }
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

		/// public propaty name  :  CancelDiv
		/// <summary>�L�����Z���敪�v���p�e�B</summary>
		/// <value>0:�L�����Z���Ȃ� 1:�L�����Z������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�����Z���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int16 CancelDiv
		{
			get { return _cancelDiv; }
			set { _cancelDiv = value; }
		}

		/// public propaty name  :  CMTCooprtDiv
		/// <summary>CMT�A�g�敪�v���p�e�B</summary>
		/// <value>0:�A�g�Ȃ� 1:�A�g���� 11:�⍇�������� 12:����������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   CMT�A�g�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int16 CMTCooprtDiv
		{
			get { return _cMTCooprtDiv; }
			set { _cMTCooprtDiv = value; }
		}

		/// public propaty name  :  SfPmCprtInstSlipNo
		/// <summary>SF-PM�A�g�w�����ԍ��v���p�e�B</summary>
		/// <value>(���p�S�p����)</value>
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

		/// public propaty name  :  AcceptOrOrderKind
		/// <summary>�󔭒���ʃv���p�e�B</summary>
		/// <value>0:�ʏ�,1:PCC-UOE</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󔭒���ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int16 AcceptOrOrderKind
		{
			get { return _acceptOrOrderKind; }
			set { _acceptOrOrderKind = value; }
		}


		/// <summary>
		/// SCM�󔭒��f�[�^�R���X�g���N�^
		/// </summary>
		/// <returns>ScmOdrData�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdrData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmOdrData()
		{
		}

		/// <summary>
		/// SCM�󔭒��f�[�^�R���X�g���N�^
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
		/// <param name="answerDivCd">�񓚋敪(0:�A�N�V�����Ȃ� 1:�񓚒� 2:��t�ς� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��)</param>
		/// <param name="judgementDate">�m���(YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B)</param>
		/// <param name="inqOrdNote">�⍇���E�������l</param>
		/// <param name="inqEmployeeCd">�⍇���]�ƈ��R�[�h(�⍇�������]�ƈ��R�[�h)</param>
		/// <param name="inqEmployeeNm">�⍇���]�ƈ�����(�⍇�������]�ƈ�����)</param>
		/// <param name="ansEmployeeCd">�񓚏]�ƈ��R�[�h</param>
		/// <param name="ansEmployeeNm">�񓚏]�ƈ�����</param>
		/// <param name="inquiryDate">�⍇����(YYYYMMDD)</param>
		/// <param name="inqOrdDivCd">�⍇���E�������(1:�⍇�� 2:����)</param>
		/// <param name="inqOrdAnsDivCd">�┭�E�񓚎��(1:�⍇���E���� 2:��)</param>
		/// <param name="receiveDateTime">��M����(�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="latestDiscCode">�ŐV���ʋ敪(0:�ŐV�f�[�^ 1:���f�[�^)</param>
		/// <param name="cancelDiv">�L�����Z���敪(0:�L�����Z���Ȃ� 1:�L�����Z������)</param>
		/// <param name="cMTCooprtDiv">CMT�A�g�敪(0:�A�g�Ȃ� 1:�A�g���� 11:�⍇�������� 12:����������)</param>
		/// <param name="sfPmCprtInstSlipNo">SF-PM�A�g�w�����ԍ�((���p�S�p����))</param>
		/// <param name="acceptOrOrderKind">�󔭒����(0:�ʏ�,1:PCC-UOE)</param>
		/// <returns>ScmOdrData�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdrData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmOdrData(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 answerDivCd, DateTime judgementDate, string inqOrdNote, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, DateTime inquiryDate, Int32 inqOrdDivCd, Int32 inqOrdAnsDivCd, DateTime receiveDateTime, Int16 latestDiscCode, Int16 cancelDiv, Int16 cMTCooprtDiv, string sfPmCprtInstSlipNo, Int16 acceptOrOrderKind)
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
			this._answerDivCd = answerDivCd;
			this.JudgementDate = judgementDate;
			this._inqOrdNote = inqOrdNote;
			this._inqEmployeeCd = inqEmployeeCd;
			this._inqEmployeeNm = inqEmployeeNm;
			this._ansEmployeeCd = ansEmployeeCd;
			this._ansEmployeeNm = ansEmployeeNm;
			this.InquiryDate = inquiryDate;
			this._inqOrdDivCd = inqOrdDivCd;
			this._inqOrdAnsDivCd = inqOrdAnsDivCd;
			this.ReceiveDateTime = receiveDateTime;
			this._latestDiscCode = latestDiscCode;
			this._cancelDiv = cancelDiv;
			this._cMTCooprtDiv = cMTCooprtDiv;
			this._sfPmCprtInstSlipNo = sfPmCprtInstSlipNo;
			this._acceptOrOrderKind = acceptOrOrderKind;

		}

		/// <summary>
		/// SCM�󔭒��f�[�^��������
		/// </summary>
		/// <returns>ScmOdrData�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ScmOdrData�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmOdrData Clone()
		{
			return new ScmOdrData(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._answerDivCd, this._judgementDate, this._inqOrdNote, this._inqEmployeeCd, this._inqEmployeeNm, this._ansEmployeeCd, this._ansEmployeeNm, this._inquiryDate, this._inqOrdDivCd, this._inqOrdAnsDivCd, this._receiveDateTime, this._latestDiscCode, this._cancelDiv, this._cMTCooprtDiv, this._sfPmCprtInstSlipNo, this._acceptOrOrderKind);
		}

		/// <summary>
		/// SCM�󔭒��f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmOdrData�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdrData�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ScmOdrData target)
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
				 && (this.AnswerDivCd == target.AnswerDivCd)
				 && (this.JudgementDate == target.JudgementDate)
				 && (this.InqOrdNote == target.InqOrdNote)
				 && (this.InqEmployeeCd == target.InqEmployeeCd)
				 && (this.InqEmployeeNm == target.InqEmployeeNm)
				 && (this.AnsEmployeeCd == target.AnsEmployeeCd)
				 && (this.AnsEmployeeNm == target.AnsEmployeeNm)
				 && (this.InquiryDate == target.InquiryDate)
				 && (this.InqOrdDivCd == target.InqOrdDivCd)
				 && (this.InqOrdAnsDivCd == target.InqOrdAnsDivCd)
				 && (this.ReceiveDateTime == target.ReceiveDateTime)
				 && (this.LatestDiscCode == target.LatestDiscCode)
				 && (this.CancelDiv == target.CancelDiv)
				 && (this.CMTCooprtDiv == target.CMTCooprtDiv)
				 && (this.SfPmCprtInstSlipNo == target.SfPmCprtInstSlipNo)
				 && (this.AcceptOrOrderKind == target.AcceptOrOrderKind));
		}

		/// <summary>
		/// SCM�󔭒��f�[�^��r����
		/// </summary>
		/// <param name="scmOdrData1">
		///                    ��r����ScmOdrData�N���X�̃C���X�^���X
		/// </param>
		/// <param name="scmOdrData2">��r����ScmOdrData�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdrData�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(ScmOdrData scmOdrData1, ScmOdrData scmOdrData2)
		{
			return ((scmOdrData1.CreateDateTime == scmOdrData2.CreateDateTime)
				 && (scmOdrData1.UpdateDateTime == scmOdrData2.UpdateDateTime)
				 && (scmOdrData1.LogicalDeleteCode == scmOdrData2.LogicalDeleteCode)
				 && (scmOdrData1.InqOriginalEpCd == scmOdrData2.InqOriginalEpCd)
				 && (scmOdrData1.InqOriginalSecCd == scmOdrData2.InqOriginalSecCd)
				 && (scmOdrData1.InqOtherEpCd == scmOdrData2.InqOtherEpCd)
				 && (scmOdrData1.InqOtherSecCd == scmOdrData2.InqOtherSecCd)
				 && (scmOdrData1.InquiryNumber == scmOdrData2.InquiryNumber)
				 && (scmOdrData1.UpdateDate == scmOdrData2.UpdateDate)
				 && (scmOdrData1.UpdateTime == scmOdrData2.UpdateTime)
				 && (scmOdrData1.AnswerDivCd == scmOdrData2.AnswerDivCd)
				 && (scmOdrData1.JudgementDate == scmOdrData2.JudgementDate)
				 && (scmOdrData1.InqOrdNote == scmOdrData2.InqOrdNote)
				 && (scmOdrData1.InqEmployeeCd == scmOdrData2.InqEmployeeCd)
				 && (scmOdrData1.InqEmployeeNm == scmOdrData2.InqEmployeeNm)
				 && (scmOdrData1.AnsEmployeeCd == scmOdrData2.AnsEmployeeCd)
				 && (scmOdrData1.AnsEmployeeNm == scmOdrData2.AnsEmployeeNm)
				 && (scmOdrData1.InquiryDate == scmOdrData2.InquiryDate)
				 && (scmOdrData1.InqOrdDivCd == scmOdrData2.InqOrdDivCd)
				 && (scmOdrData1.InqOrdAnsDivCd == scmOdrData2.InqOrdAnsDivCd)
				 && (scmOdrData1.ReceiveDateTime == scmOdrData2.ReceiveDateTime)
				 && (scmOdrData1.LatestDiscCode == scmOdrData2.LatestDiscCode)
				 && (scmOdrData1.CancelDiv == scmOdrData2.CancelDiv)
				 && (scmOdrData1.CMTCooprtDiv == scmOdrData2.CMTCooprtDiv)
				 && (scmOdrData1.SfPmCprtInstSlipNo == scmOdrData2.SfPmCprtInstSlipNo)
				 && (scmOdrData1.AcceptOrOrderKind == scmOdrData2.AcceptOrOrderKind));
		}
		/// <summary>
		/// SCM�󔭒��f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmOdrData�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdrData�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ScmOdrData target)
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
			if (this.AnswerDivCd != target.AnswerDivCd) resList.Add("AnswerDivCd");
			if (this.JudgementDate != target.JudgementDate) resList.Add("JudgementDate");
			if (this.InqOrdNote != target.InqOrdNote) resList.Add("InqOrdNote");
			if (this.InqEmployeeCd != target.InqEmployeeCd) resList.Add("InqEmployeeCd");
			if (this.InqEmployeeNm != target.InqEmployeeNm) resList.Add("InqEmployeeNm");
			if (this.AnsEmployeeCd != target.AnsEmployeeCd) resList.Add("AnsEmployeeCd");
			if (this.AnsEmployeeNm != target.AnsEmployeeNm) resList.Add("AnsEmployeeNm");
			if (this.InquiryDate != target.InquiryDate) resList.Add("InquiryDate");
			if (this.InqOrdDivCd != target.InqOrdDivCd) resList.Add("InqOrdDivCd");
			if (this.InqOrdAnsDivCd != target.InqOrdAnsDivCd) resList.Add("InqOrdAnsDivCd");
			if (this.ReceiveDateTime != target.ReceiveDateTime) resList.Add("ReceiveDateTime");
			if (this.LatestDiscCode != target.LatestDiscCode) resList.Add("LatestDiscCode");
			if (this.CancelDiv != target.CancelDiv) resList.Add("CancelDiv");
			if (this.CMTCooprtDiv != target.CMTCooprtDiv) resList.Add("CMTCooprtDiv");
			if (this.SfPmCprtInstSlipNo != target.SfPmCprtInstSlipNo) resList.Add("SfPmCprtInstSlipNo");
			if (this.AcceptOrOrderKind != target.AcceptOrOrderKind)resList.Add("AcceptOrOrderKind");

			return resList;
		}

		/// <summary>
		/// SCM�󔭒��f�[�^��r����
		/// </summary>
		/// <param name="scmOdrData1">��r����ScmOdrData�N���X�̃C���X�^���X</param>
		/// <param name="scmOdrData2">��r����ScmOdrData�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmOdrData�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ScmOdrData scmOdrData1, ScmOdrData scmOdrData2)
		{
			ArrayList resList = new ArrayList();
			if (scmOdrData1.CreateDateTime != scmOdrData2.CreateDateTime) resList.Add("CreateDateTime");
			if (scmOdrData1.UpdateDateTime != scmOdrData2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (scmOdrData1.LogicalDeleteCode != scmOdrData2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (scmOdrData1.InqOriginalEpCd != scmOdrData2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (scmOdrData1.InqOriginalSecCd != scmOdrData2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (scmOdrData1.InqOtherEpCd != scmOdrData2.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (scmOdrData1.InqOtherSecCd != scmOdrData2.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (scmOdrData1.InquiryNumber != scmOdrData2.InquiryNumber) resList.Add("InquiryNumber");
			if (scmOdrData1.UpdateDate != scmOdrData2.UpdateDate) resList.Add("UpdateDate");
			if (scmOdrData1.UpdateTime != scmOdrData2.UpdateTime) resList.Add("UpdateTime");
			if (scmOdrData1.AnswerDivCd != scmOdrData2.AnswerDivCd) resList.Add("AnswerDivCd");
			if (scmOdrData1.JudgementDate != scmOdrData2.JudgementDate) resList.Add("JudgementDate");
			if (scmOdrData1.InqOrdNote != scmOdrData2.InqOrdNote) resList.Add("InqOrdNote");
			if (scmOdrData1.InqEmployeeCd != scmOdrData2.InqEmployeeCd) resList.Add("InqEmployeeCd");
			if (scmOdrData1.InqEmployeeNm != scmOdrData2.InqEmployeeNm) resList.Add("InqEmployeeNm");
			if (scmOdrData1.AnsEmployeeCd != scmOdrData2.AnsEmployeeCd) resList.Add("AnsEmployeeCd");
			if (scmOdrData1.AnsEmployeeNm != scmOdrData2.AnsEmployeeNm) resList.Add("AnsEmployeeNm");
			if (scmOdrData1.InquiryDate != scmOdrData2.InquiryDate) resList.Add("InquiryDate");
			if (scmOdrData1.InqOrdDivCd != scmOdrData2.InqOrdDivCd) resList.Add("InqOrdDivCd");
			if (scmOdrData1.InqOrdAnsDivCd != scmOdrData2.InqOrdAnsDivCd) resList.Add("InqOrdAnsDivCd");
			if (scmOdrData1.ReceiveDateTime != scmOdrData2.ReceiveDateTime) resList.Add("ReceiveDateTime");
			if (scmOdrData1.LatestDiscCode != scmOdrData2.LatestDiscCode) resList.Add("LatestDiscCode");
			if (scmOdrData1.CancelDiv != scmOdrData2.CancelDiv) resList.Add("CancelDiv");
			if (scmOdrData1.CMTCooprtDiv != scmOdrData2.CMTCooprtDiv) resList.Add("CMTCooprtDiv");
			if (scmOdrData1.SfPmCprtInstSlipNo != scmOdrData2.SfPmCprtInstSlipNo) resList.Add("SfPmCprtInstSlipNo");
			if (scmOdrData1.AcceptOrOrderKind != scmOdrData2.AcceptOrOrderKind)resList.Add("AcceptOrOrderKind");

			return resList;
		}
	}
}

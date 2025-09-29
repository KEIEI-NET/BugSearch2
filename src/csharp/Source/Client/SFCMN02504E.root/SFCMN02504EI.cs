using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SCMAnsListSrchRst
	/// <summary>
	///                      SCM�񓚈ꗗ�������ʃN���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�񓚈ꗗ�������ʃN���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/05/25</br>
	/// <br>Genarated Date   :   2011/05/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/7/17  �����@���l</br>
	/// <br>                 :   �┭�E�񓚎�ʁA��M������ǉ�</br>
	/// <br>Update Note      :   2010/5/31  �����@���l</br>
	/// <br>                 :   �L�����Z���敪��ǉ�</br>
	/// <br>Update Note      :   2011/5/19  ���{�@�T�B</br>
	/// <br>                 :   ���������敪�A�m����A�⍇���E�������l�A</br>
	/// <br>                 :   SF-PM�A�g�w�����ԍ���ǉ�</br>
	/// <br>                 :   �񓚋敪�̕⑫�����̓��e���C��</br>
    /// <br>Update Note      :   2011/7/25  ���Ԍ��@�[</br>
    /// <br>                 :   �󔭒���ʂ�ǉ�</br>
	/// </remarks>
	[Serializable]
	public class SCMAnsListSrchRst
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

		/// <summary>���^�������ԍ�</summary>
		private Int32 _numberPlate1Code;

		/// <summary>���^�����ǖ���</summary>
		private string _numberPlate1Name = "";

		/// <summary>�ԗ��o�^�ԍ��i��ʁj</summary>
		private string _numberPlate2 = "";

		/// <summary>�ԗ��o�^�ԍ��i�J�i�j</summary>
		private string _numberPlate3 = "";

		/// <summary>�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</summary>
		private Int32 _numberPlate4;

		/// <summary>�^���w��ԍ�</summary>
		private Int32 _modelDesignationNo;

		/// <summary>�ޕʔԍ�</summary>
		private Int32 _categoryNo;

		/// <summary>���[�J�[�R�[�h</summary>
		/// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _makerCode;

		/// <summary>�Ԏ햼</summary>
		private string _modelName = "";

		/// <summary>�Ԍ��،^��</summary>
		private string _carInspectCertModel = "";

		/// <summary>�ԑ�ԍ�</summary>
		private string _frameNo = "";

		/// <summary>�ԑ�^��</summary>
		private string _frameModel = "";

		/// <summary>�┭�E�񓚎��</summary>
		/// <remarks>1:�⍇���E���� 2:��</remarks>
		private Int32 _inqOrdAnsDivCd;

		/// <summary>��M����</summary>
		/// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _receiveDateTime;

		/// <summary>�L�����Z���敪</summary>
		/// <remarks>0:�L�����Z���Ȃ� 1:�L�����Z������</remarks>
		private Int16 _cancelDiv;

		/// <summary>�m���</summary>
		/// <remarks>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</remarks>
		private DateTime _judgementDate;

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

		/// public propaty name  :  NumberPlate1Code
		/// <summary>���^�������ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���^�������ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NumberPlate1Code
		{
			get { return _numberPlate1Code; }
			set { _numberPlate1Code = value; }
		}

		/// public propaty name  :  NumberPlate1Name
		/// <summary>���^�����ǖ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���^�����ǖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string NumberPlate1Name
		{
			get { return _numberPlate1Name; }
			set { _numberPlate1Name = value; }
		}

		/// public propaty name  :  NumberPlate2
		/// <summary>�ԗ��o�^�ԍ��i��ʁj�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ��o�^�ԍ��i��ʁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string NumberPlate2
		{
			get { return _numberPlate2; }
			set { _numberPlate2 = value; }
		}

		/// public propaty name  :  NumberPlate3
		/// <summary>�ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԗ��o�^�ԍ��i�J�i�j�v���p�e�B</br>
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
		/// <br>note             :   �ԗ��o�^�ԍ��i�v���[�g�ԍ��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NumberPlate4
		{
			get { return _numberPlate4; }
			set { _numberPlate4 = value; }
		}

		/// public propaty name  :  ModelDesignationNo
		/// <summary>�^���w��ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �^���w��ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ModelDesignationNo
		{
			get { return _modelDesignationNo; }
			set { _modelDesignationNo = value; }
		}

		/// public propaty name  :  CategoryNo
		/// <summary>�ޕʔԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ޕʔԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CategoryNo
		{
			get { return _categoryNo; }
			set { _categoryNo = value; }
		}

		/// public propaty name  :  MakerCode
		/// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
		/// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MakerCode
		{
			get { return _makerCode; }
			set { _makerCode = value; }
		}

		/// public propaty name  :  ModelName
		/// <summary>�Ԏ햼�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ԏ햼�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ModelName
		{
			get { return _modelName; }
			set { _modelName = value; }
		}

		/// public propaty name  :  CarInspectCertModel
		/// <summary>�Ԍ��،^���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ԍ��،^���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CarInspectCertModel
		{
			get { return _carInspectCertModel; }
			set { _carInspectCertModel = value; }
		}

		/// public propaty name  :  FrameNo
		/// <summary>�ԑ�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԑ�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrameNo
		{
			get { return _frameNo; }
			set { _frameNo = value; }
		}

		/// public propaty name  :  FrameModel
		/// <summary>�ԑ�^���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԑ�^���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FrameModel
		{
			get { return _frameModel; }
			set { _frameModel = value; }
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
		/// SCM�񓚈ꗗ�������ʃN���X�R���X�g���N�^
		/// </summary>
		/// <returns>SCMAnsListSrchRst�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAnsListSrchRst�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAnsListSrchRst()
		{
		}

		/// <summary>
		/// SCM�񓚈ꗗ�������ʃN���X�R���X�g���N�^
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
		/// <param name="inqOrdNote">�⍇���E�������l</param>
		/// <param name="inqEmployeeCd">�⍇���]�ƈ��R�[�h(�⍇�������]�ƈ��R�[�h)</param>
		/// <param name="inqEmployeeNm">�⍇���]�ƈ�����(�⍇�������]�ƈ�����)</param>
		/// <param name="ansEmployeeCd">�񓚏]�ƈ��R�[�h</param>
		/// <param name="ansEmployeeNm">�񓚏]�ƈ�����</param>
		/// <param name="inquiryDate">�⍇����(YYYYMMDD)</param>
		/// <param name="inqOrdDivCd">�⍇���E�������(1:�⍇�� 2:����)</param>
		/// <param name="numberPlate1Code">���^�������ԍ�</param>
		/// <param name="numberPlate1Name">���^�����ǖ���</param>
		/// <param name="numberPlate2">�ԗ��o�^�ԍ��i��ʁj</param>
		/// <param name="numberPlate3">�ԗ��o�^�ԍ��i�J�i�j</param>
		/// <param name="numberPlate4">�ԗ��o�^�ԍ��i�v���[�g�ԍ��j</param>
		/// <param name="modelDesignationNo">�^���w��ԍ�</param>
		/// <param name="categoryNo">�ޕʔԍ�</param>
		/// <param name="makerCode">���[�J�[�R�[�h(1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
		/// <param name="modelName">�Ԏ햼</param>
		/// <param name="carInspectCertModel">�Ԍ��،^��</param>
		/// <param name="frameNo">�ԑ�ԍ�</param>
		/// <param name="frameModel">�ԑ�^��</param>
		/// <param name="inqOrdAnsDivCd">�┭�E�񓚎��(1:�⍇���E���� 2:��)</param>
		/// <param name="receiveDateTime">��M����(�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="cancelDiv">�L�����Z���敪(0:�L�����Z���Ȃ� 1:�L�����Z������)</param>
		/// <param name="judgementDate">�m���(YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B)</param>
		/// <param name="sfPmCprtInstSlipNo">SF-PM�A�g�w�����ԍ�((���p�S�p����))</param>
        /// <param name="acceptOrOrderKind ">�󔭒����(0:�ʏ�,1:PCC-UOE)</param>
		/// <returns>SCMAnsListSrchRst�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAnsListSrchRst�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public SCMAnsListSrchRst(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 answerDivCd, string inqOrdNote, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, DateTime inquiryDate, Int32 inqOrdDivCd, Int32 numberPlate1Code, string numberPlate1Name, string numberPlate2, string numberPlate3, Int32 numberPlate4, Int32 modelDesignationNo, Int32 categoryNo, Int32 makerCode, string modelName, string carInspectCertModel, string frameNo, string frameModel, Int32 inqOrdAnsDivCd, DateTime receiveDateTime, Int16 cancelDiv, DateTime judgementDate, string sfPmCprtInstSlipNo, Int16 acceptOrOrderKind)
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
			this._inqOrdNote = inqOrdNote;
			this._inqEmployeeCd = inqEmployeeCd;
			this._inqEmployeeNm = inqEmployeeNm;
			this._ansEmployeeCd = ansEmployeeCd;
			this._ansEmployeeNm = ansEmployeeNm;
			this.InquiryDate = inquiryDate;
			this._inqOrdDivCd = inqOrdDivCd;
			this._numberPlate1Code = numberPlate1Code;
			this._numberPlate1Name = numberPlate1Name;
			this._numberPlate2 = numberPlate2;
			this._numberPlate3 = numberPlate3;
			this._numberPlate4 = numberPlate4;
			this._modelDesignationNo = modelDesignationNo;
			this._categoryNo = categoryNo;
			this._makerCode = makerCode;
			this._modelName = modelName;
			this._carInspectCertModel = carInspectCertModel;
			this._frameNo = frameNo;
			this._frameModel = frameModel;
			this._inqOrdAnsDivCd = inqOrdAnsDivCd;
			this.ReceiveDateTime = receiveDateTime;
			this._cancelDiv = cancelDiv;
			this.JudgementDate = judgementDate;
			this._sfPmCprtInstSlipNo = sfPmCprtInstSlipNo;
            this._acceptOrOrderKind = acceptOrOrderKind;

		}

		/// <summary>
		/// SCM�񓚈ꗗ�������ʃN���X��������
		/// </summary>
		/// <returns>SCMAnsListSrchRst�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SCMAnsListSrchRst�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAnsListSrchRst Clone()
		{
            return new SCMAnsListSrchRst(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._answerDivCd, this._inqOrdNote, this._inqEmployeeCd, this._inqEmployeeNm, this._ansEmployeeCd, this._ansEmployeeNm, this._inquiryDate, this._inqOrdDivCd, this._numberPlate1Code, this._numberPlate1Name, this._numberPlate2, this._numberPlate3, this._numberPlate4, this._modelDesignationNo, this._categoryNo, this._makerCode, this._modelName, this._carInspectCertModel, this._frameNo, this._frameModel, this._inqOrdAnsDivCd, this._receiveDateTime, this._cancelDiv, this._judgementDate, this._sfPmCprtInstSlipNo, this._acceptOrOrderKind);
		}

		/// <summary>
		/// SCM�񓚈ꗗ�������ʃN���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SCMAnsListSrchRst�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAnsListSrchRst�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SCMAnsListSrchRst target)
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
				 && (this.InqOrdNote == target.InqOrdNote)
				 && (this.InqEmployeeCd == target.InqEmployeeCd)
				 && (this.InqEmployeeNm == target.InqEmployeeNm)
				 && (this.AnsEmployeeCd == target.AnsEmployeeCd)
				 && (this.AnsEmployeeNm == target.AnsEmployeeNm)
				 && (this.InquiryDate == target.InquiryDate)
				 && (this.InqOrdDivCd == target.InqOrdDivCd)
				 && (this.NumberPlate1Code == target.NumberPlate1Code)
				 && (this.NumberPlate1Name == target.NumberPlate1Name)
				 && (this.NumberPlate2 == target.NumberPlate2)
				 && (this.NumberPlate3 == target.NumberPlate3)
				 && (this.NumberPlate4 == target.NumberPlate4)
				 && (this.ModelDesignationNo == target.ModelDesignationNo)
				 && (this.CategoryNo == target.CategoryNo)
				 && (this.MakerCode == target.MakerCode)
				 && (this.ModelName == target.ModelName)
				 && (this.CarInspectCertModel == target.CarInspectCertModel)
				 && (this.FrameNo == target.FrameNo)
				 && (this.FrameModel == target.FrameModel)
				 && (this.InqOrdAnsDivCd == target.InqOrdAnsDivCd)
				 && (this.ReceiveDateTime == target.ReceiveDateTime)
				 && (this.CancelDiv == target.CancelDiv)
				 && (this.JudgementDate == target.JudgementDate)
				 && (this.SfPmCprtInstSlipNo == target.SfPmCprtInstSlipNo)
                 && (this.AcceptOrOrderKind == target.AcceptOrOrderKind));
		}

		/// <summary>
		/// SCM�񓚈ꗗ�������ʃN���X��r����
		/// </summary>
		/// <param name="sCMAnsListSrchRst1">
		///                    ��r����SCMAnsListSrchRst�N���X�̃C���X�^���X
		/// </param>
		/// <param name="sCMAnsListSrchRst2">��r����SCMAnsListSrchRst�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAnsListSrchRst�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SCMAnsListSrchRst sCMAnsListSrchRst1, SCMAnsListSrchRst sCMAnsListSrchRst2)
		{
			return ((sCMAnsListSrchRst1.CreateDateTime == sCMAnsListSrchRst2.CreateDateTime)
				 && (sCMAnsListSrchRst1.UpdateDateTime == sCMAnsListSrchRst2.UpdateDateTime)
				 && (sCMAnsListSrchRst1.LogicalDeleteCode == sCMAnsListSrchRst2.LogicalDeleteCode)
				 && (sCMAnsListSrchRst1.InqOriginalEpCd == sCMAnsListSrchRst2.InqOriginalEpCd)
				 && (sCMAnsListSrchRst1.InqOriginalSecCd == sCMAnsListSrchRst2.InqOriginalSecCd)
				 && (sCMAnsListSrchRst1.InqOtherEpCd == sCMAnsListSrchRst2.InqOtherEpCd)
				 && (sCMAnsListSrchRst1.InqOtherSecCd == sCMAnsListSrchRst2.InqOtherSecCd)
				 && (sCMAnsListSrchRst1.InquiryNumber == sCMAnsListSrchRst2.InquiryNumber)
				 && (sCMAnsListSrchRst1.UpdateDate == sCMAnsListSrchRst2.UpdateDate)
				 && (sCMAnsListSrchRst1.UpdateTime == sCMAnsListSrchRst2.UpdateTime)
				 && (sCMAnsListSrchRst1.AnswerDivCd == sCMAnsListSrchRst2.AnswerDivCd)
				 && (sCMAnsListSrchRst1.InqOrdNote == sCMAnsListSrchRst2.InqOrdNote)
				 && (sCMAnsListSrchRst1.InqEmployeeCd == sCMAnsListSrchRst2.InqEmployeeCd)
				 && (sCMAnsListSrchRst1.InqEmployeeNm == sCMAnsListSrchRst2.InqEmployeeNm)
				 && (sCMAnsListSrchRst1.AnsEmployeeCd == sCMAnsListSrchRst2.AnsEmployeeCd)
				 && (sCMAnsListSrchRst1.AnsEmployeeNm == sCMAnsListSrchRst2.AnsEmployeeNm)
				 && (sCMAnsListSrchRst1.InquiryDate == sCMAnsListSrchRst2.InquiryDate)
				 && (sCMAnsListSrchRst1.InqOrdDivCd == sCMAnsListSrchRst2.InqOrdDivCd)
				 && (sCMAnsListSrchRst1.NumberPlate1Code == sCMAnsListSrchRst2.NumberPlate1Code)
				 && (sCMAnsListSrchRst1.NumberPlate1Name == sCMAnsListSrchRst2.NumberPlate1Name)
				 && (sCMAnsListSrchRst1.NumberPlate2 == sCMAnsListSrchRst2.NumberPlate2)
				 && (sCMAnsListSrchRst1.NumberPlate3 == sCMAnsListSrchRst2.NumberPlate3)
				 && (sCMAnsListSrchRst1.NumberPlate4 == sCMAnsListSrchRst2.NumberPlate4)
				 && (sCMAnsListSrchRst1.ModelDesignationNo == sCMAnsListSrchRst2.ModelDesignationNo)
				 && (sCMAnsListSrchRst1.CategoryNo == sCMAnsListSrchRst2.CategoryNo)
				 && (sCMAnsListSrchRst1.MakerCode == sCMAnsListSrchRst2.MakerCode)
				 && (sCMAnsListSrchRst1.ModelName == sCMAnsListSrchRst2.ModelName)
				 && (sCMAnsListSrchRst1.CarInspectCertModel == sCMAnsListSrchRst2.CarInspectCertModel)
				 && (sCMAnsListSrchRst1.FrameNo == sCMAnsListSrchRst2.FrameNo)
				 && (sCMAnsListSrchRst1.FrameModel == sCMAnsListSrchRst2.FrameModel)
				 && (sCMAnsListSrchRst1.InqOrdAnsDivCd == sCMAnsListSrchRst2.InqOrdAnsDivCd)
				 && (sCMAnsListSrchRst1.ReceiveDateTime == sCMAnsListSrchRst2.ReceiveDateTime)
				 && (sCMAnsListSrchRst1.CancelDiv == sCMAnsListSrchRst2.CancelDiv)
				 && (sCMAnsListSrchRst1.JudgementDate == sCMAnsListSrchRst2.JudgementDate)
				 && (sCMAnsListSrchRst1.SfPmCprtInstSlipNo == sCMAnsListSrchRst2.SfPmCprtInstSlipNo)
                 && (sCMAnsListSrchRst1.AcceptOrOrderKind == sCMAnsListSrchRst2.AcceptOrOrderKind));
		}
		/// <summary>
		/// SCM�񓚈ꗗ�������ʃN���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SCMAnsListSrchRst�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAnsListSrchRst�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SCMAnsListSrchRst target)
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
			if (this.InqOrdNote != target.InqOrdNote) resList.Add("InqOrdNote");
			if (this.InqEmployeeCd != target.InqEmployeeCd) resList.Add("InqEmployeeCd");
			if (this.InqEmployeeNm != target.InqEmployeeNm) resList.Add("InqEmployeeNm");
			if (this.AnsEmployeeCd != target.AnsEmployeeCd) resList.Add("AnsEmployeeCd");
			if (this.AnsEmployeeNm != target.AnsEmployeeNm) resList.Add("AnsEmployeeNm");
			if (this.InquiryDate != target.InquiryDate) resList.Add("InquiryDate");
			if (this.InqOrdDivCd != target.InqOrdDivCd) resList.Add("InqOrdDivCd");
			if (this.NumberPlate1Code != target.NumberPlate1Code) resList.Add("NumberPlate1Code");
			if (this.NumberPlate1Name != target.NumberPlate1Name) resList.Add("NumberPlate1Name");
			if (this.NumberPlate2 != target.NumberPlate2) resList.Add("NumberPlate2");
			if (this.NumberPlate3 != target.NumberPlate3) resList.Add("NumberPlate3");
			if (this.NumberPlate4 != target.NumberPlate4) resList.Add("NumberPlate4");
			if (this.ModelDesignationNo != target.ModelDesignationNo) resList.Add("ModelDesignationNo");
			if (this.CategoryNo != target.CategoryNo) resList.Add("CategoryNo");
			if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
			if (this.ModelName != target.ModelName) resList.Add("ModelName");
			if (this.CarInspectCertModel != target.CarInspectCertModel) resList.Add("CarInspectCertModel");
			if (this.FrameNo != target.FrameNo) resList.Add("FrameNo");
			if (this.FrameModel != target.FrameModel) resList.Add("FrameModel");
			if (this.InqOrdAnsDivCd != target.InqOrdAnsDivCd) resList.Add("InqOrdAnsDivCd");
			if (this.ReceiveDateTime != target.ReceiveDateTime) resList.Add("ReceiveDateTime");
			if (this.CancelDiv != target.CancelDiv) resList.Add("CancelDiv");
			if (this.JudgementDate != target.JudgementDate) resList.Add("JudgementDate");
			if (this.SfPmCprtInstSlipNo != target.SfPmCprtInstSlipNo) resList.Add("SfPmCprtInstSlipNo");
            if (this.AcceptOrOrderKind != target.AcceptOrOrderKind) resList.Add("AcceptOrOrderKind");

			return resList;
		}

		/// <summary>
		/// SCM�񓚈ꗗ�������ʃN���X��r����
		/// </summary>
		/// <param name="sCMAnsListSrchRst1">��r����SCMAnsListSrchRst�N���X�̃C���X�^���X</param>
		/// <param name="sCMAnsListSrchRst2">��r����SCMAnsListSrchRst�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAnsListSrchRst�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SCMAnsListSrchRst sCMAnsListSrchRst1, SCMAnsListSrchRst sCMAnsListSrchRst2)
		{
			ArrayList resList = new ArrayList();
			if (sCMAnsListSrchRst1.CreateDateTime != sCMAnsListSrchRst2.CreateDateTime) resList.Add("CreateDateTime");
			if (sCMAnsListSrchRst1.UpdateDateTime != sCMAnsListSrchRst2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (sCMAnsListSrchRst1.LogicalDeleteCode != sCMAnsListSrchRst2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (sCMAnsListSrchRst1.InqOriginalEpCd != sCMAnsListSrchRst2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (sCMAnsListSrchRst1.InqOriginalSecCd != sCMAnsListSrchRst2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (sCMAnsListSrchRst1.InqOtherEpCd != sCMAnsListSrchRst2.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (sCMAnsListSrchRst1.InqOtherSecCd != sCMAnsListSrchRst2.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (sCMAnsListSrchRst1.InquiryNumber != sCMAnsListSrchRst2.InquiryNumber) resList.Add("InquiryNumber");
			if (sCMAnsListSrchRst1.UpdateDate != sCMAnsListSrchRst2.UpdateDate) resList.Add("UpdateDate");
			if (sCMAnsListSrchRst1.UpdateTime != sCMAnsListSrchRst2.UpdateTime) resList.Add("UpdateTime");
			if (sCMAnsListSrchRst1.AnswerDivCd != sCMAnsListSrchRst2.AnswerDivCd) resList.Add("AnswerDivCd");
			if (sCMAnsListSrchRst1.InqOrdNote != sCMAnsListSrchRst2.InqOrdNote) resList.Add("InqOrdNote");
			if (sCMAnsListSrchRst1.InqEmployeeCd != sCMAnsListSrchRst2.InqEmployeeCd) resList.Add("InqEmployeeCd");
			if (sCMAnsListSrchRst1.InqEmployeeNm != sCMAnsListSrchRst2.InqEmployeeNm) resList.Add("InqEmployeeNm");
			if (sCMAnsListSrchRst1.AnsEmployeeCd != sCMAnsListSrchRst2.AnsEmployeeCd) resList.Add("AnsEmployeeCd");
			if (sCMAnsListSrchRst1.AnsEmployeeNm != sCMAnsListSrchRst2.AnsEmployeeNm) resList.Add("AnsEmployeeNm");
			if (sCMAnsListSrchRst1.InquiryDate != sCMAnsListSrchRst2.InquiryDate) resList.Add("InquiryDate");
			if (sCMAnsListSrchRst1.InqOrdDivCd != sCMAnsListSrchRst2.InqOrdDivCd) resList.Add("InqOrdDivCd");
			if (sCMAnsListSrchRst1.NumberPlate1Code != sCMAnsListSrchRst2.NumberPlate1Code) resList.Add("NumberPlate1Code");
			if (sCMAnsListSrchRst1.NumberPlate1Name != sCMAnsListSrchRst2.NumberPlate1Name) resList.Add("NumberPlate1Name");
			if (sCMAnsListSrchRst1.NumberPlate2 != sCMAnsListSrchRst2.NumberPlate2) resList.Add("NumberPlate2");
			if (sCMAnsListSrchRst1.NumberPlate3 != sCMAnsListSrchRst2.NumberPlate3) resList.Add("NumberPlate3");
			if (sCMAnsListSrchRst1.NumberPlate4 != sCMAnsListSrchRst2.NumberPlate4) resList.Add("NumberPlate4");
			if (sCMAnsListSrchRst1.ModelDesignationNo != sCMAnsListSrchRst2.ModelDesignationNo) resList.Add("ModelDesignationNo");
			if (sCMAnsListSrchRst1.CategoryNo != sCMAnsListSrchRst2.CategoryNo) resList.Add("CategoryNo");
			if (sCMAnsListSrchRst1.MakerCode != sCMAnsListSrchRst2.MakerCode) resList.Add("MakerCode");
			if (sCMAnsListSrchRst1.ModelName != sCMAnsListSrchRst2.ModelName) resList.Add("ModelName");
			if (sCMAnsListSrchRst1.CarInspectCertModel != sCMAnsListSrchRst2.CarInspectCertModel) resList.Add("CarInspectCertModel");
			if (sCMAnsListSrchRst1.FrameNo != sCMAnsListSrchRst2.FrameNo) resList.Add("FrameNo");
			if (sCMAnsListSrchRst1.FrameModel != sCMAnsListSrchRst2.FrameModel) resList.Add("FrameModel");
			if (sCMAnsListSrchRst1.InqOrdAnsDivCd != sCMAnsListSrchRst2.InqOrdAnsDivCd) resList.Add("InqOrdAnsDivCd");
			if (sCMAnsListSrchRst1.ReceiveDateTime != sCMAnsListSrchRst2.ReceiveDateTime) resList.Add("ReceiveDateTime");
			if (sCMAnsListSrchRst1.CancelDiv != sCMAnsListSrchRst2.CancelDiv) resList.Add("CancelDiv");
			if (sCMAnsListSrchRst1.JudgementDate != sCMAnsListSrchRst2.JudgementDate) resList.Add("JudgementDate");
			if (sCMAnsListSrchRst1.SfPmCprtInstSlipNo != sCMAnsListSrchRst2.SfPmCprtInstSlipNo) resList.Add("SfPmCprtInstSlipNo");
            if (sCMAnsListSrchRst1.AcceptOrOrderKind != sCMAnsListSrchRst2.AcceptOrOrderKind) resList.Add("AcceptOrOrderKind");

			return resList;
		}
	}
}

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SCMAcOdrData
	/// <summary>
	///                      SCM�󒍃f�[�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�󒍃f�[�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/04/30</br>
	/// <br>Genarated Date   :   2009/08/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/05/18  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �󒍃X�e�[�^�X</br>
	/// <br>                 :   ����`�[�ԍ�</br>
	/// <br>                 :   ����`�[���v�i�ō��݁j</br>
	/// <br>                 :   ���㏬�v�i�Łj</br>
	/// <br>Update Note      :   2009/05/26  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   ������</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �⍇���E�������</br>
	/// <br>                 :   �┭�E�񓚎��</br>
	/// <br>                 :   ��M����</br>
	/// <br>Update Note      :   2009/05/29  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �񓚍쐬�敪</br>
	/// <br>Update Note      :   2009/06/15  ����</br>
	/// <br>                 :   ���L�[�ύX</br>
	/// <br>                 :   3,9,11,13,14,15,17,18��3,9,11,13,14,15,17,18,29,30</br>
	/// <br>Update Note      :   2009/06/16  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   �⍇������Ɩ���</br>
	/// <br>                 :   �⍇�������_����</br>
	/// <br>                 :   �������ύX</br>
	/// <br>                 :   �⍇�������_�R�[�h�@16��6</br>
	/// <br>                 :   ���L�[�ύX</br>
	/// <br>                 :   3,9,11,13,14,15,17,18,29,30��3,9,10,11,12,13,15,16,27,28</br>
    /// <br>Update Note      :   2010/06/22  �H��</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �L�����Z���敪</br>
    /// <br>                 :   CMT�A�g�敪</br>
	/// </remarks>
	public class SCMAcOdrData
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

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>�X�V�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>�X�V�����b�~���b</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>�񓚋敪</summary>
		/// <remarks>0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</remarks>
		private Int32 _answerDivCd;

		/// <summary>�m���</summary>
		/// <remarks>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</remarks>
		private DateTime _judgementDate;

		/// <summary>�⍇���E�������l</summary>
		private string _inqOrdNote = "";

		/// <summary>�Y�t�t�@�C��</summary>
		private Byte[] _appendingFile = new Byte[0];

		/// <summary>�Y�t�t�@�C����</summary>
		private string _appendingFileNm = "";

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

		/// <summary>�󒍃X�e�[�^�X</summary>
		/// <remarks>10:����,20:��,30:����</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>����`�[�ԍ�</summary>
		/// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
		private string _salesSlipNum = "";

		/// <summary>����`�[���v�i�ō��݁j</summary>
		/// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
		private Int64 _salesTotalTaxInc;

		/// <summary>���㏬�v�i�Łj</summary>
		/// <remarks>�l����̐Ŋz�i�O�ŕ��A���ŕ��̍��v�j</remarks>
		private Int64 _salesSubtotalTax;

		/// <summary>�⍇���E�������</summary>
		/// <remarks>1:�⍇�� 2:����</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>�┭�E�񓚎��</summary>
		/// <remarks>1:�⍇���E���� 2:��</remarks>
		private Int32 _inqOrdAnsDivCd;

		/// <summary>��M����</summary>
		/// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _receiveDateTime;

		/// <summary>�񓚍쐬�敪</summary>
		/// <remarks>0:����, 1:�蓮�iWeb�j, 2:�蓮�i���̑��j</remarks>
		private Int32 _answerCreateDiv;

		/// <summary>�T�[�o�[�ԍ�</summary>
		/// <remarks>PM7����</remarks>
		private Int32 _serverNumber;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

        // ADD 2010/06/22 NS�ҋ@�����Ή� ---------->>>>>
        /// <summary>�L�����Z���敪</summary>
        private short _cancelDiv;
        /// <summary>�L�����Z���敪</summary>
        /// <remarks>0:�L�����Z���Ȃ� 1:�L�����Z������</remarks>
        public short CancelDiv
        {
            get { return _cancelDiv; }
            set { _cancelDiv = value; }
        }

        /// <summary>CMT�A�g�敪</summary>
        private short _CMTCooprtDiv;
        /// <summary>CMT�A�g�敪</summary>
        /// <remarks>0:�A�g�Ȃ� 1:�A�g����</remarks>
        public short CMTCooprtDiv
        {
            get { return _CMTCooprtDiv; }
            set { _CMTCooprtDiv = value; }
        }
        // ADD 2010/06/22 NS�ҋ@�����Ή� ----------<<<<<

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

		/// public propaty name  :  AnswerDivCd
		/// <summary>�񓚋敪�v���p�e�B</summary>
		/// <value>0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AnswerDivCd
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
		public DateTime JudgementDate
		{
			get{return _judgementDate;}
			set{_judgementDate = value;}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _judgementDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _judgementDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _judgementDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _judgementDate);}
			set{}
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

		/// public propaty name  :  AppendingFile
		/// <summary>�Y�t�t�@�C���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Y�t�t�@�C���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Byte[] AppendingFile
		{
			get{return _appendingFile;}
			set{_appendingFile = value;}
		}

		/// public propaty name  :  AppendingFileNm
		/// <summary>�Y�t�t�@�C�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Y�t�t�@�C�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AppendingFileNm
		{
			get{return _appendingFileNm;}
			set{_appendingFileNm = value;}
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
			get{return _inquiryDate;}
			set{_inquiryDate = value;}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _inquiryDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _inquiryDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _inquiryDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _inquiryDate);}
			set{}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
		/// <value>10:����,20:��,30:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>����`�[�ԍ��v���p�e�B</summary>
		/// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
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

		/// public propaty name  :  SalesSubtotalTax
		/// <summary>���㏬�v�i�Łj�v���p�e�B</summary>
		/// <value>�l����̐Ŋz�i�O�ŕ��A���ŕ��̍��v�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㏬�v�i�Łj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesSubtotalTax
		{
			get{return _salesSubtotalTax;}
			set{_salesSubtotalTax = value;}
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
			get{return _inqOrdAnsDivCd;}
			set{_inqOrdAnsDivCd = value;}
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
			get{return _receiveDateTime;}
			set{_receiveDateTime = value;}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _receiveDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _receiveDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _receiveDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _receiveDateTime);}
			set{}
		}

		/// public propaty name  :  AnswerCreateDiv
		/// <summary>�񓚍쐬�敪�v���p�e�B</summary>
		/// <value>0:����, 1:�蓮�iWeb�j, 2:�蓮�i���̑��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚍쐬�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AnswerCreateDiv
		{
			get{return _answerCreateDiv;}
			set{_answerCreateDiv = value;}
		}

		/// public propaty name  :  ServerNumber
		/// <summary>�T�[�o�[�ԍ��v���p�e�B</summary>
		/// <value>PM7����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �T�[�o�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ServerNumber
		{
			get{return _serverNumber;}
			set{_serverNumber = value;}
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

		/// public propaty name  :  UpdEmployeeName
		/// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}


		/// <summary>
		/// SCM�󒍃f�[�^�R���X�g���N�^
		/// </summary>
		/// <returns>SCMAcOdrData�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAcOdrData()
		{
		}

		/// <summary>
		/// SCM�󒍃f�[�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
		/// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
		/// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
		/// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
		/// <param name="inquiryNumber">�⍇���ԍ�</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="updateDate">�X�V�N����(YYYYMMDD)</param>
		/// <param name="updateTime">�X�V�����b�~���b(HHMMSSXXX)</param>
		/// <param name="answerDivCd">�񓚋敪(0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��)</param>
		/// <param name="judgementDate">�m���(YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B)</param>
		/// <param name="inqOrdNote">�⍇���E�������l</param>
		/// <param name="appendingFile">�Y�t�t�@�C��</param>
		/// <param name="appendingFileNm">�Y�t�t�@�C����</param>
		/// <param name="inqEmployeeCd">�⍇���]�ƈ��R�[�h(�⍇�������]�ƈ��R�[�h)</param>
		/// <param name="inqEmployeeNm">�⍇���]�ƈ�����(�⍇�������]�ƈ�����)</param>
		/// <param name="ansEmployeeCd">�񓚏]�ƈ��R�[�h</param>
		/// <param name="ansEmployeeNm">�񓚏]�ƈ�����</param>
		/// <param name="inquiryDate">�⍇����(YYYYMMDD)</param>
		/// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:����,20:��,30:����)</param>
		/// <param name="salesSlipNum">����`�[�ԍ�(���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B)</param>
		/// <param name="salesTotalTaxInc">����`�[���v�i�ō��݁j(���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz)</param>
		/// <param name="salesSubtotalTax">���㏬�v�i�Łj(�l����̐Ŋz�i�O�ŕ��A���ŕ��̍��v�j)</param>
		/// <param name="inqOrdDivCd">�⍇���E�������(1:�⍇�� 2:����)</param>
		/// <param name="inqOrdAnsDivCd">�┭�E�񓚎��(1:�⍇���E���� 2:��)</param>
		/// <param name="receiveDateTime">��M����(�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="answerCreateDiv">�񓚍쐬�敪(0:����, 1:�蓮�iWeb�j, 2:�蓮�i���̑��j)</param>
		/// <param name="serverNumber">�T�[�o�[�ԍ�(PM7����)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>SCMAcOdrData�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public SCMAcOdrData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, Int32 customerCode, DateTime updateDate, Int32 updateTime, Int32 answerDivCd, DateTime judgementDate, string inqOrdNote, Byte[] appendingFile, string appendingFileNm, string inqEmployeeCd, string inqEmployeeNm, string ansEmployeeCd, string ansEmployeeNm, DateTime inquiryDate, Int32 acptAnOdrStatus, string salesSlipNum, Int64 salesTotalTaxInc, Int64 salesSubtotalTax, Int32 inqOrdDivCd, Int32 inqOrdAnsDivCd, DateTime receiveDateTime, Int32 answerCreateDiv, Int32 serverNumber, string enterpriseName, string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
			this._inqOriginalSecCd = inqOriginalSecCd;
			this._inqOtherEpCd = inqOtherEpCd;
			this._inqOtherSecCd = inqOtherSecCd;
			this._inquiryNumber = inquiryNumber;
			this._customerCode = customerCode;
			this.UpdateDate = updateDate;
			this._updateTime = updateTime;
			this._answerDivCd = answerDivCd;
			this.JudgementDate = judgementDate;
			this._inqOrdNote = inqOrdNote;
			this._appendingFile = appendingFile;
			this._appendingFileNm = appendingFileNm;
			this._inqEmployeeCd = inqEmployeeCd;
			this._inqEmployeeNm = inqEmployeeNm;
			this._ansEmployeeCd = ansEmployeeCd;
			this._ansEmployeeNm = ansEmployeeNm;
			this.InquiryDate = inquiryDate;
			this._acptAnOdrStatus = acptAnOdrStatus;
			this._salesSlipNum = salesSlipNum;
			this._salesTotalTaxInc = salesTotalTaxInc;
			this._salesSubtotalTax = salesSubtotalTax;
			this._inqOrdDivCd = inqOrdDivCd;
			this._inqOrdAnsDivCd = inqOrdAnsDivCd;
			this.ReceiveDateTime = receiveDateTime;
			this._answerCreateDiv = answerCreateDiv;
			this._serverNumber = serverNumber;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// SCM�󒍃f�[�^��������
		/// </summary>
		/// <returns>SCMAcOdrData�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SCMAcOdrData�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAcOdrData Clone()
		{
			return new SCMAcOdrData(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._inqOriginalEpCd.Trim(),this._inqOriginalSecCd,this._inqOtherEpCd,this._inqOtherSecCd,this._inquiryNumber,this._customerCode,this._updateDate,this._updateTime,this._answerDivCd,this._judgementDate,this._inqOrdNote,this._appendingFile,this._appendingFileNm,this._inqEmployeeCd,this._inqEmployeeNm,this._ansEmployeeCd,this._ansEmployeeNm,this._inquiryDate,this._acptAnOdrStatus,this._salesSlipNum,this._salesTotalTaxInc,this._salesSubtotalTax,this._inqOrdDivCd,this._inqOrdAnsDivCd,this._receiveDateTime,this._answerCreateDiv,this._serverNumber,this._enterpriseName,this._updEmployeeName);//@@@@20230303
		}

		/// <summary>
		/// SCM�󒍃f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SCMAcOdrData�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrData�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SCMAcOdrData target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
				 && (this.InqOtherEpCd == target.InqOtherEpCd)
				 && (this.InqOtherSecCd == target.InqOtherSecCd)
				 && (this.InquiryNumber == target.InquiryNumber)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.UpdateDate == target.UpdateDate)
				 && (this.UpdateTime == target.UpdateTime)
				 && (this.AnswerDivCd == target.AnswerDivCd)
				 && (this.JudgementDate == target.JudgementDate)
				 && (this.InqOrdNote == target.InqOrdNote)
				 && (this.AppendingFile == target.AppendingFile)
				 && (this.AppendingFileNm == target.AppendingFileNm)
				 && (this.InqEmployeeCd == target.InqEmployeeCd)
				 && (this.InqEmployeeNm == target.InqEmployeeNm)
				 && (this.AnsEmployeeCd == target.AnsEmployeeCd)
				 && (this.AnsEmployeeNm == target.AnsEmployeeNm)
				 && (this.InquiryDate == target.InquiryDate)
				 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
				 && (this.SalesSlipNum == target.SalesSlipNum)
				 && (this.SalesTotalTaxInc == target.SalesTotalTaxInc)
				 && (this.SalesSubtotalTax == target.SalesSubtotalTax)
				 && (this.InqOrdDivCd == target.InqOrdDivCd)
				 && (this.InqOrdAnsDivCd == target.InqOrdAnsDivCd)
				 && (this.ReceiveDateTime == target.ReceiveDateTime)
				 && (this.AnswerCreateDiv == target.AnswerCreateDiv)
				 && (this.ServerNumber == target.ServerNumber)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// SCM�󒍃f�[�^��r����
		/// </summary>
		/// <param name="sCMAcOdrData1">
		///                    ��r����SCMAcOdrData�N���X�̃C���X�^���X
		/// </param>
		/// <param name="sCMAcOdrData2">��r����SCMAcOdrData�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrData�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SCMAcOdrData sCMAcOdrData1, SCMAcOdrData sCMAcOdrData2)
		{
			return ((sCMAcOdrData1.CreateDateTime == sCMAcOdrData2.CreateDateTime)
				 && (sCMAcOdrData1.UpdateDateTime == sCMAcOdrData2.UpdateDateTime)
				 && (sCMAcOdrData1.EnterpriseCode == sCMAcOdrData2.EnterpriseCode)
				 && (sCMAcOdrData1.FileHeaderGuid == sCMAcOdrData2.FileHeaderGuid)
				 && (sCMAcOdrData1.UpdEmployeeCode == sCMAcOdrData2.UpdEmployeeCode)
				 && (sCMAcOdrData1.UpdAssemblyId1 == sCMAcOdrData2.UpdAssemblyId1)
				 && (sCMAcOdrData1.UpdAssemblyId2 == sCMAcOdrData2.UpdAssemblyId2)
				 && (sCMAcOdrData1.LogicalDeleteCode == sCMAcOdrData2.LogicalDeleteCode)
				 && (sCMAcOdrData1.InqOriginalEpCd.Trim() == sCMAcOdrData2.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (sCMAcOdrData1.InqOriginalSecCd == sCMAcOdrData2.InqOriginalSecCd)
				 && (sCMAcOdrData1.InqOtherEpCd == sCMAcOdrData2.InqOtherEpCd)
				 && (sCMAcOdrData1.InqOtherSecCd == sCMAcOdrData2.InqOtherSecCd)
				 && (sCMAcOdrData1.InquiryNumber == sCMAcOdrData2.InquiryNumber)
				 && (sCMAcOdrData1.CustomerCode == sCMAcOdrData2.CustomerCode)
				 && (sCMAcOdrData1.UpdateDate == sCMAcOdrData2.UpdateDate)
				 && (sCMAcOdrData1.UpdateTime == sCMAcOdrData2.UpdateTime)
				 && (sCMAcOdrData1.AnswerDivCd == sCMAcOdrData2.AnswerDivCd)
				 && (sCMAcOdrData1.JudgementDate == sCMAcOdrData2.JudgementDate)
				 && (sCMAcOdrData1.InqOrdNote == sCMAcOdrData2.InqOrdNote)
				 && (sCMAcOdrData1.AppendingFile == sCMAcOdrData2.AppendingFile)
				 && (sCMAcOdrData1.AppendingFileNm == sCMAcOdrData2.AppendingFileNm)
				 && (sCMAcOdrData1.InqEmployeeCd == sCMAcOdrData2.InqEmployeeCd)
				 && (sCMAcOdrData1.InqEmployeeNm == sCMAcOdrData2.InqEmployeeNm)
				 && (sCMAcOdrData1.AnsEmployeeCd == sCMAcOdrData2.AnsEmployeeCd)
				 && (sCMAcOdrData1.AnsEmployeeNm == sCMAcOdrData2.AnsEmployeeNm)
				 && (sCMAcOdrData1.InquiryDate == sCMAcOdrData2.InquiryDate)
				 && (sCMAcOdrData1.AcptAnOdrStatus == sCMAcOdrData2.AcptAnOdrStatus)
				 && (sCMAcOdrData1.SalesSlipNum == sCMAcOdrData2.SalesSlipNum)
				 && (sCMAcOdrData1.SalesTotalTaxInc == sCMAcOdrData2.SalesTotalTaxInc)
				 && (sCMAcOdrData1.SalesSubtotalTax == sCMAcOdrData2.SalesSubtotalTax)
				 && (sCMAcOdrData1.InqOrdDivCd == sCMAcOdrData2.InqOrdDivCd)
				 && (sCMAcOdrData1.InqOrdAnsDivCd == sCMAcOdrData2.InqOrdAnsDivCd)
				 && (sCMAcOdrData1.ReceiveDateTime == sCMAcOdrData2.ReceiveDateTime)
				 && (sCMAcOdrData1.AnswerCreateDiv == sCMAcOdrData2.AnswerCreateDiv)
				 && (sCMAcOdrData1.ServerNumber == sCMAcOdrData2.ServerNumber)
				 && (sCMAcOdrData1.EnterpriseName == sCMAcOdrData2.EnterpriseName)
				 && (sCMAcOdrData1.UpdEmployeeName == sCMAcOdrData2.UpdEmployeeName));
		}
		/// <summary>
		/// SCM�󒍃f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SCMAcOdrData�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrData�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SCMAcOdrData target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(this.InqOriginalSecCd != target.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(this.InqOtherEpCd != target.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(this.InqOtherSecCd != target.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(this.InquiryNumber != target.InquiryNumber)resList.Add("InquiryNumber");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.UpdateDate != target.UpdateDate)resList.Add("UpdateDate");
			if(this.UpdateTime != target.UpdateTime)resList.Add("UpdateTime");
			if(this.AnswerDivCd != target.AnswerDivCd)resList.Add("AnswerDivCd");
			if(this.JudgementDate != target.JudgementDate)resList.Add("JudgementDate");
			if(this.InqOrdNote != target.InqOrdNote)resList.Add("InqOrdNote");
			if(this.AppendingFile != target.AppendingFile)resList.Add("AppendingFile");
			if(this.AppendingFileNm != target.AppendingFileNm)resList.Add("AppendingFileNm");
			if(this.InqEmployeeCd != target.InqEmployeeCd)resList.Add("InqEmployeeCd");
			if(this.InqEmployeeNm != target.InqEmployeeNm)resList.Add("InqEmployeeNm");
			if(this.AnsEmployeeCd != target.AnsEmployeeCd)resList.Add("AnsEmployeeCd");
			if(this.AnsEmployeeNm != target.AnsEmployeeNm)resList.Add("AnsEmployeeNm");
			if(this.InquiryDate != target.InquiryDate)resList.Add("InquiryDate");
			if(this.AcptAnOdrStatus != target.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(this.SalesSlipNum != target.SalesSlipNum)resList.Add("SalesSlipNum");
			if(this.SalesTotalTaxInc != target.SalesTotalTaxInc)resList.Add("SalesTotalTaxInc");
			if(this.SalesSubtotalTax != target.SalesSubtotalTax)resList.Add("SalesSubtotalTax");
			if(this.InqOrdDivCd != target.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(this.InqOrdAnsDivCd != target.InqOrdAnsDivCd)resList.Add("InqOrdAnsDivCd");
			if(this.ReceiveDateTime != target.ReceiveDateTime)resList.Add("ReceiveDateTime");
			if(this.AnswerCreateDiv != target.AnswerCreateDiv)resList.Add("AnswerCreateDiv");
			if(this.ServerNumber != target.ServerNumber)resList.Add("ServerNumber");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// SCM�󒍃f�[�^��r����
		/// </summary>
		/// <param name="sCMAcOdrData1">��r����SCMAcOdrData�N���X�̃C���X�^���X</param>
		/// <param name="sCMAcOdrData2">��r����SCMAcOdrData�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrData�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SCMAcOdrData sCMAcOdrData1, SCMAcOdrData sCMAcOdrData2)
		{
			ArrayList resList = new ArrayList();
			if(sCMAcOdrData1.CreateDateTime != sCMAcOdrData2.CreateDateTime)resList.Add("CreateDateTime");
			if(sCMAcOdrData1.UpdateDateTime != sCMAcOdrData2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(sCMAcOdrData1.EnterpriseCode != sCMAcOdrData2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(sCMAcOdrData1.FileHeaderGuid != sCMAcOdrData2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(sCMAcOdrData1.UpdEmployeeCode != sCMAcOdrData2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(sCMAcOdrData1.UpdAssemblyId1 != sCMAcOdrData2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(sCMAcOdrData1.UpdAssemblyId2 != sCMAcOdrData2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(sCMAcOdrData1.LogicalDeleteCode != sCMAcOdrData2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(sCMAcOdrData1.InqOriginalEpCd.Trim() != sCMAcOdrData2.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(sCMAcOdrData1.InqOriginalSecCd != sCMAcOdrData2.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(sCMAcOdrData1.InqOtherEpCd != sCMAcOdrData2.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(sCMAcOdrData1.InqOtherSecCd != sCMAcOdrData2.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(sCMAcOdrData1.InquiryNumber != sCMAcOdrData2.InquiryNumber)resList.Add("InquiryNumber");
			if(sCMAcOdrData1.CustomerCode != sCMAcOdrData2.CustomerCode)resList.Add("CustomerCode");
			if(sCMAcOdrData1.UpdateDate != sCMAcOdrData2.UpdateDate)resList.Add("UpdateDate");
			if(sCMAcOdrData1.UpdateTime != sCMAcOdrData2.UpdateTime)resList.Add("UpdateTime");
			if(sCMAcOdrData1.AnswerDivCd != sCMAcOdrData2.AnswerDivCd)resList.Add("AnswerDivCd");
			if(sCMAcOdrData1.JudgementDate != sCMAcOdrData2.JudgementDate)resList.Add("JudgementDate");
			if(sCMAcOdrData1.InqOrdNote != sCMAcOdrData2.InqOrdNote)resList.Add("InqOrdNote");
			if(sCMAcOdrData1.AppendingFile != sCMAcOdrData2.AppendingFile)resList.Add("AppendingFile");
			if(sCMAcOdrData1.AppendingFileNm != sCMAcOdrData2.AppendingFileNm)resList.Add("AppendingFileNm");
			if(sCMAcOdrData1.InqEmployeeCd != sCMAcOdrData2.InqEmployeeCd)resList.Add("InqEmployeeCd");
			if(sCMAcOdrData1.InqEmployeeNm != sCMAcOdrData2.InqEmployeeNm)resList.Add("InqEmployeeNm");
			if(sCMAcOdrData1.AnsEmployeeCd != sCMAcOdrData2.AnsEmployeeCd)resList.Add("AnsEmployeeCd");
			if(sCMAcOdrData1.AnsEmployeeNm != sCMAcOdrData2.AnsEmployeeNm)resList.Add("AnsEmployeeNm");
			if(sCMAcOdrData1.InquiryDate != sCMAcOdrData2.InquiryDate)resList.Add("InquiryDate");
			if(sCMAcOdrData1.AcptAnOdrStatus != sCMAcOdrData2.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(sCMAcOdrData1.SalesSlipNum != sCMAcOdrData2.SalesSlipNum)resList.Add("SalesSlipNum");
			if(sCMAcOdrData1.SalesTotalTaxInc != sCMAcOdrData2.SalesTotalTaxInc)resList.Add("SalesTotalTaxInc");
			if(sCMAcOdrData1.SalesSubtotalTax != sCMAcOdrData2.SalesSubtotalTax)resList.Add("SalesSubtotalTax");
			if(sCMAcOdrData1.InqOrdDivCd != sCMAcOdrData2.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(sCMAcOdrData1.InqOrdAnsDivCd != sCMAcOdrData2.InqOrdAnsDivCd)resList.Add("InqOrdAnsDivCd");
			if(sCMAcOdrData1.ReceiveDateTime != sCMAcOdrData2.ReceiveDateTime)resList.Add("ReceiveDateTime");
			if(sCMAcOdrData1.AnswerCreateDiv != sCMAcOdrData2.AnswerCreateDiv)resList.Add("AnswerCreateDiv");
			if(sCMAcOdrData1.ServerNumber != sCMAcOdrData2.ServerNumber)resList.Add("ServerNumber");
			if(sCMAcOdrData1.EnterpriseName != sCMAcOdrData2.EnterpriseName)resList.Add("EnterpriseName");
			if(sCMAcOdrData1.UpdEmployeeName != sCMAcOdrData2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}

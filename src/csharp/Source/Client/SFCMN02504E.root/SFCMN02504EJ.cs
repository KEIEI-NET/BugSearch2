using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ScmJudgeDtUpdParam
	/// <summary>
	///                      SCM�m����X�V�p�����[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�m����X�V�p�����[�^�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2011/05/19</br>
	/// <br>Genarated Date   :   2011/05/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	public class ScmJudgeDtUpdParam
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

		/// <summary>�m���</summary>
		/// <remarks>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</remarks>
		private DateTime _judgementDate;


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


		/// <summary>
		/// SCM�m����X�V�p�����[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>ScmJudgeDtUpdParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmJudgeDtUpdParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmJudgeDtUpdParam()
		{
		}

		/// <summary>
		/// SCM�m����X�V�p�����[�^�N���X�R���X�g���N�^
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
		/// <param name="judgementDate">�m���(YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B)</param>
		/// <returns>ScmJudgeDtUpdParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmJudgeDtUpdParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmJudgeDtUpdParam(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, DateTime judgementDate)
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
			this.JudgementDate = judgementDate;

		}

		/// <summary>
		/// SCM�m����X�V�p�����[�^�N���X��������
		/// </summary>
		/// <returns>ScmJudgeDtUpdParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ScmJudgeDtUpdParam�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ScmJudgeDtUpdParam Clone()
		{
			return new ScmJudgeDtUpdParam(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._judgementDate);
		}

		/// <summary>
		/// SCM�m����X�V�p�����[�^�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmJudgeDtUpdParam�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmJudgeDtUpdParam�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ScmJudgeDtUpdParam target)
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
				 && (this.JudgementDate == target.JudgementDate));
		}

		/// <summary>
		/// SCM�m����X�V�p�����[�^�N���X��r����
		/// </summary>
		/// <param name="scmJudgeDtUpdParam1">
		///                    ��r����ScmJudgeDtUpdParam�N���X�̃C���X�^���X
		/// </param>
		/// <param name="scmJudgeDtUpdParam2">��r����ScmJudgeDtUpdParam�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmJudgeDtUpdParam�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(ScmJudgeDtUpdParam scmJudgeDtUpdParam1, ScmJudgeDtUpdParam scmJudgeDtUpdParam2)
		{
			return ((scmJudgeDtUpdParam1.CreateDateTime == scmJudgeDtUpdParam2.CreateDateTime)
				 && (scmJudgeDtUpdParam1.UpdateDateTime == scmJudgeDtUpdParam2.UpdateDateTime)
				 && (scmJudgeDtUpdParam1.LogicalDeleteCode == scmJudgeDtUpdParam2.LogicalDeleteCode)
				 && (scmJudgeDtUpdParam1.InqOriginalEpCd == scmJudgeDtUpdParam2.InqOriginalEpCd)
				 && (scmJudgeDtUpdParam1.InqOriginalSecCd == scmJudgeDtUpdParam2.InqOriginalSecCd)
				 && (scmJudgeDtUpdParam1.InqOtherEpCd == scmJudgeDtUpdParam2.InqOtherEpCd)
				 && (scmJudgeDtUpdParam1.InqOtherSecCd == scmJudgeDtUpdParam2.InqOtherSecCd)
				 && (scmJudgeDtUpdParam1.InquiryNumber == scmJudgeDtUpdParam2.InquiryNumber)
				 && (scmJudgeDtUpdParam1.UpdateDate == scmJudgeDtUpdParam2.UpdateDate)
				 && (scmJudgeDtUpdParam1.UpdateTime == scmJudgeDtUpdParam2.UpdateTime)
				 && (scmJudgeDtUpdParam1.JudgementDate == scmJudgeDtUpdParam2.JudgementDate));
		}
		/// <summary>
		/// SCM�m����X�V�p�����[�^�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ScmJudgeDtUpdParam�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmJudgeDtUpdParam�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ScmJudgeDtUpdParam target)
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
			if (this.JudgementDate != target.JudgementDate) resList.Add("JudgementDate");

			return resList;
		}

		/// <summary>
		/// SCM�m����X�V�p�����[�^�N���X��r����
		/// </summary>
		/// <param name="scmJudgeDtUpdParam1">��r����ScmJudgeDtUpdParam�N���X�̃C���X�^���X</param>
		/// <param name="scmJudgeDtUpdParam2">��r����ScmJudgeDtUpdParam�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ScmJudgeDtUpdParam�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ScmJudgeDtUpdParam scmJudgeDtUpdParam1, ScmJudgeDtUpdParam scmJudgeDtUpdParam2)
		{
			ArrayList resList = new ArrayList();
			if (scmJudgeDtUpdParam1.CreateDateTime != scmJudgeDtUpdParam2.CreateDateTime) resList.Add("CreateDateTime");
			if (scmJudgeDtUpdParam1.UpdateDateTime != scmJudgeDtUpdParam2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (scmJudgeDtUpdParam1.LogicalDeleteCode != scmJudgeDtUpdParam2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (scmJudgeDtUpdParam1.InqOriginalEpCd != scmJudgeDtUpdParam2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
			if (scmJudgeDtUpdParam1.InqOriginalSecCd != scmJudgeDtUpdParam2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
			if (scmJudgeDtUpdParam1.InqOtherEpCd != scmJudgeDtUpdParam2.InqOtherEpCd) resList.Add("InqOtherEpCd");
			if (scmJudgeDtUpdParam1.InqOtherSecCd != scmJudgeDtUpdParam2.InqOtherSecCd) resList.Add("InqOtherSecCd");
			if (scmJudgeDtUpdParam1.InquiryNumber != scmJudgeDtUpdParam2.InquiryNumber) resList.Add("InquiryNumber");
			if (scmJudgeDtUpdParam1.UpdateDate != scmJudgeDtUpdParam2.UpdateDate) resList.Add("UpdateDate");
			if (scmJudgeDtUpdParam1.UpdateTime != scmJudgeDtUpdParam2.UpdateTime) resList.Add("UpdateTime");
			if (scmJudgeDtUpdParam1.JudgementDate != scmJudgeDtUpdParam2.JudgementDate) resList.Add("JudgementDate");

			return resList;
		}
	}
}

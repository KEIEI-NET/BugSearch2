using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   TaxRateSet
	/// <summary>
	///                      �ŗ��ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �ŗ��ݒ�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/04/30</br>
	/// <br>Genarated Date   :   2005/05/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2007.08.16 980035 ���� ��`</br>
    /// <br>			         �E�[�������敪���폜���ď���œ]�ŕ�����ǉ�</br>
    /// </remarks>
	public class TaxRateSet
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
		private string _updEmployeeCode;

		/// <summary>�X�V�A�Z���u��ID1</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId1;

		/// <summary>�X�V�A�Z���u��ID2</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId2;

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>�ŗ��R�[�h</summary>
		/// <remarks>0:��ʏ����,1:����p�����</remarks>
		private Int32 _taxRateCode;

		/// <summary>�ŗ��ŗL����</summary>
		/// <remarks>�ŗ��R�[�h�ŗL�̖���(�ύX�s��)</remarks>
		private string _taxRateProperNounNm;

		/// <summary>�ŗ�����</summary>
		private string _taxRateName;

        /// <summary>����œ]�ŕ���</summary>
		private Int32 _consTaxLayMethod;

		/// <summary>�ŗ��J�n��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _taxRateStartDate;

		/// <summary>�ŗ��J�n�� �a��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDateJpFormal;

		/// <summary>�ŗ��J�n�� �a��(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDateJpInFormal;

		/// <summary>�ŗ��J�n�� ����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDateAdFormal;

		/// <summary>�ŗ��J�n�� ����(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDateAdInFormal;

		/// <summary>�ŗ��I����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _taxRateEndDate;

		/// <summary>�ŗ��I���� �a��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDateJpFormal;

		/// <summary>�ŗ��I���� �a��(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDateJpInFormal;

		/// <summary>�ŗ��I���� ����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDateAdFormal;

		/// <summary>�ŗ��I���� ����(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDateAdInFormal;

		/// <summary>�ŗ�</summary>
		private Double _taxRate;

		/// <summary>�ŗ��J�n��2</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _taxRateStartDate2;

		/// <summary>�ŗ��J�n��2 �a��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate2JpFormal;

		/// <summary>�ŗ��J�n��2 �a��(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate2JpInFormal;

		/// <summary>�ŗ��J�n��2 ����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate2AdFormal;

		/// <summary>�ŗ��J�n��2 ����(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate2AdInFormal;

		/// <summary>�ŗ��I����2</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _taxRateEndDate2;

		/// <summary>�ŗ��I����2 �a��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate2JpFormal;

		/// <summary>�ŗ��I����2 �a��(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate2JpInFormal;

		/// <summary>�ŗ��I����2 ����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate2AdFormal;

		/// <summary>�ŗ��I����2 ����(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate2AdInFormal;

		/// <summary>�ŗ�2</summary>
		private Double _taxRate2;

		/// <summary>�ŗ��J�n��3</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _taxRateStartDate3;

		/// <summary>�ŗ��J�n��3 �a��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate3JpFormal;

		/// <summary>�ŗ��J�n��3 �a��(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate3JpInFormal;

		/// <summary>�ŗ��J�n��3 ����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate3AdFormal;

		/// <summary>�ŗ��J�n��3 ����(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateStartDate3AdInFormal;

		/// <summary>�ŗ��I����3</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _taxRateEndDate3;

		/// <summary>�ŗ��I����3 �a��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate3JpFormal;

		/// <summary>�ŗ��I����3 �a��(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate3JpInFormal;

		/// <summary>�ŗ��I����3 ����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate3AdFormal;

		/// <summary>�ŗ��I����3 ����(��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private string _taxRateEndDate3AdInFormal;

		/// <summary>�ŗ�3</summary>
		private Double _taxRate3;

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName;


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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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

		/// public propaty name  :  TaxRateCode
		/// <summary>�ŗ��R�[�h�v���p�e�B</summary>
		/// <value>0:��ʏ����,1:����p�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TaxRateCode
		{
			get{return _taxRateCode;}
			set{_taxRateCode = value;}
		}

		/// public propaty name  :  TaxRateProperNounNm
		/// <summary>�ŗ��ŗL���̃v���p�e�B</summary>
		/// <value>�ŗ��R�[�h�ŗL�̖���(�ύX�s��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��ŗL���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateProperNounNm
		{
			get{return _taxRateProperNounNm;}
			set{_taxRateProperNounNm = value;}
		}

		/// public propaty name  :  TaxRateName
		/// <summary>�ŗ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateName
		{
			get{return _taxRateName;}
			set{_taxRateName = value;}
		}

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>����œ]�ŕ����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
        /// <br>note             :   ����œ]�ŕ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32 ConsTaxLayMethod
		{
            get{return _consTaxLayMethod;}
            set{_consTaxLayMethod = value;}
		}

        /// public propaty name  :  TaxRateStartDate
		/// <summary>�ŗ��J�n���v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime TaxRateStartDate
		{
			get{return _taxRateStartDate;}
			set
			{
				_taxRateStartDate = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._taxRateStartDateJpFormal = dateTimes[0];
				this._taxRateStartDateJpInFormal = dateTimes[1];
				this._taxRateStartDateAdFormal = dateTimes[2];
				this._taxRateStartDateAdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  TaxRateStartDateJpFormal
		/// <summary>�ŗ��J�n�� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n�� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateStartDateJpFormal
		{
			get{return _taxRateStartDateJpFormal;}
		}

		/// public propaty name  :  TaxRateStartDateJpInFormal
		/// <summary>�ŗ��J�n�� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n�� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateStartDateJpInFormal
		{
			get{return _taxRateStartDateJpInFormal;}
		}

		/// public propaty name  :  TaxRateStartDateAdFormal
		/// <summary>�ŗ��J�n�� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n�� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateStartDateAdFormal
		{
			get{return _taxRateStartDateAdFormal;}
		}

		/// public propaty name  :  TaxRateStartDateAdInFormal
		/// <summary>�ŗ��J�n�� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n�� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateStartDateAdInFormal
		{
			get{return _taxRateStartDateAdInFormal;}
		}

		/// public propaty name  :  TaxRateEndDate
		/// <summary>�ŗ��I�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime TaxRateEndDate
		{
			get{return _taxRateEndDate;}
			set
			{
				_taxRateEndDate = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._taxRateEndDateJpFormal = dateTimes[0];
				this._taxRateEndDateJpInFormal = dateTimes[1];
				this._taxRateEndDateAdFormal = dateTimes[2];
				this._taxRateEndDateAdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  TaxRateEndDateJpFormal
		/// <summary>�ŗ��I���� �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateEndDateJpFormal
		{
			get{return _taxRateEndDateJpFormal;}
		}

		/// public propaty name  :  TaxRateEndDateJpInFormal
		/// <summary>�ŗ��I���� �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateEndDateJpInFormal
		{
			get{return _taxRateEndDateJpInFormal;}
		}

		/// public propaty name  :  TaxRateEndDateAdFormal
		/// <summary>�ŗ��I���� ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateEndDateAdFormal
		{
			get{return _taxRateEndDateAdFormal;}
		}

		/// public propaty name  :  TaxRateEndDateAdInFormal
		/// <summary>�ŗ��I���� ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateEndDateAdInFormal
		{
			get{return _taxRateEndDateAdInFormal;}
		}

		/// public propaty name  :  TaxRate
		/// <summary>�ŗ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double TaxRate
		{
			get{return _taxRate;}
			set{_taxRate = value;}
		}

		/// public propaty name  :  TaxRateStartDate2
		/// <summary>�ŗ��J�n��2�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n��2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime TaxRateStartDate2
		{
			get{return _taxRateStartDate2;}
			set
			{
				_taxRateStartDate2 = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._taxRateStartDate2JpFormal = dateTimes[0];
				this._taxRateStartDate2JpInFormal = dateTimes[1];
				this._taxRateStartDate2AdFormal = dateTimes[2];
				this._taxRateStartDate2AdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  TaxRateStartDate2JpFormal
		/// <summary>�ŗ��J�n��2 �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n��2 �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateStartDate2JpFormal
		{
			get{return _taxRateStartDate2JpFormal;}
		}

		/// public propaty name  :  TaxRateStartDate2JpInFormal
		/// <summary>�ŗ��J�n��2 �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n��2 �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateStartDate2JpInFormal
		{
			get{return _taxRateStartDate2JpInFormal;}
		}

		/// public propaty name  :  TaxRateStartDate2AdFormal
		/// <summary>�ŗ��J�n��2 ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n��2 ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateStartDate2AdFormal
		{
			get{return _taxRateStartDate2AdFormal;}
		}

		/// public propaty name  :  TaxRateStartDate2AdInFormal
		/// <summary>�ŗ��J�n��2 ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n��2 ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateStartDate2AdInFormal
		{
			get{return _taxRateStartDate2AdInFormal;}
		}

		/// public propaty name  :  TaxRateEndDate2
		/// <summary>�ŗ��I����2�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I����2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime TaxRateEndDate2
		{
			get{return _taxRateEndDate2;}
			set
			{
				_taxRateEndDate2 = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._taxRateEndDate2JpFormal = dateTimes[0];
				this._taxRateEndDate2JpInFormal = dateTimes[1];
				this._taxRateEndDate2AdFormal = dateTimes[2];
				this._taxRateEndDate2AdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  TaxRateEndDate2JpFormal
		/// <summary>�ŗ��I����2 �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I����2 �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateEndDate2JpFormal
		{
			get{return _taxRateEndDate2JpFormal;}
		}

		/// public propaty name  :  TaxRateEndDate2JpInFormal
		/// <summary>�ŗ��I����2 �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I����2 �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateEndDate2JpInFormal
		{
			get{return _taxRateEndDate2JpInFormal;}
		}

		/// public propaty name  :  TaxRateEndDate2AdFormal
		/// <summary>�ŗ��I����2 ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I����2 ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateEndDate2AdFormal
		{
			get{return _taxRateEndDate2AdFormal;}
		}

		/// public propaty name  :  TaxRateEndDate2AdInFormal
		/// <summary>�ŗ��I����2 ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I����2 ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateEndDate2AdInFormal
		{
			get{return _taxRateEndDate2AdInFormal;}
		}

		/// public propaty name  :  TaxRate2
		/// <summary>�ŗ�2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ�2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double TaxRate2
		{
			get{return _taxRate2;}
			set{_taxRate2 = value;}
		}

		/// public propaty name  :  TaxRateStartDate3
		/// <summary>�ŗ��J�n��3�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n��3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime TaxRateStartDate3
		{
			get{return _taxRateStartDate3;}
			set
			{
				_taxRateStartDate3 = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._taxRateStartDate3JpFormal = dateTimes[0];
				this._taxRateStartDate3JpInFormal = dateTimes[1];
				this._taxRateStartDate3AdFormal = dateTimes[2];
				this._taxRateStartDate3AdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  TaxRateStartDate3JpFormal
		/// <summary>�ŗ��J�n��3 �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n��3 �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateStartDate3JpFormal
		{
			get{return _taxRateStartDate3JpFormal;}
		}

		/// public propaty name  :  TaxRateStartDate3JpInFormal
		/// <summary>�ŗ��J�n��3 �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n��3 �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateStartDate3JpInFormal
		{
			get{return _taxRateStartDate3JpInFormal;}
		}

		/// public propaty name  :  TaxRateStartDate3AdFormal
		/// <summary>�ŗ��J�n��3 ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n��3 ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateStartDate3AdFormal
		{
			get{return _taxRateStartDate3AdFormal;}
		}

		/// public propaty name  :  TaxRateStartDate3AdInFormal
		/// <summary>�ŗ��J�n��3 ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��J�n��3 ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateStartDate3AdInFormal
		{
			get{return _taxRateStartDate3AdInFormal;}
		}

		/// public propaty name  :  TaxRateEndDate3
		/// <summary>�ŗ��I����3�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I����3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime TaxRateEndDate3
		{
			get{return _taxRateEndDate3;}
			set
			{
				_taxRateEndDate3 = value;
				string[] dateTimes = TDateTime.DateTimeToStringArray("YYYYMMDD", value);
				this._taxRateEndDate3JpFormal = dateTimes[0];
				this._taxRateEndDate3JpInFormal = dateTimes[1];
				this._taxRateEndDate3AdFormal = dateTimes[2];
				this._taxRateEndDate3AdInFormal = dateTimes[3];
			}
		}

		/// public propaty name  :  TaxRateEndDate3JpFormal
		/// <summary>�ŗ��I����3 �a��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I����3 �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateEndDate3JpFormal
		{
			get{return _taxRateEndDate3JpFormal;}
		}

		/// public propaty name  :  TaxRateEndDate3JpInFormal
		/// <summary>�ŗ��I����3 �a��(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I����3 �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateEndDate3JpInFormal
		{
			get{return _taxRateEndDate3JpInFormal;}
		}

		/// public propaty name  :  TaxRateEndDate3AdFormal
		/// <summary>�ŗ��I����3 ����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I����3 ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateEndDate3AdFormal
		{
			get{return _taxRateEndDate3AdFormal;}
		}

		/// public propaty name  :  TaxRateEndDate3AdInFormal
		/// <summary>�ŗ��I����3 ����(��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ��I����3 ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TaxRateEndDate3AdInFormal
		{
			get{return _taxRateEndDate3AdInFormal;}
		}

		/// public propaty name  :  TaxRate3
		/// <summary>�ŗ�3�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŗ�3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double TaxRate3
		{
			get{return _taxRate3;}
			set{_taxRate3 = value;}
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


		/// <summary>
		/// �ŗ��ݒ�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>TaxRateSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TaxRateSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public TaxRateSet()
		{
		}

        /// <summary>
		/// �ŗ��ݒ�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="taxRateCode">�ŗ��R�[�h(0:��ʏ����,1:����p�����)</param>
		/// <param name="taxRateProperNounNm">�ŗ��ŗL����(�ŗ��R�[�h�ŗL�̖���(�ύX�s��))</param>
		/// <param name="taxRateName">�ŗ�����</param>
        /// <param name="fractionProcCd">����œ]�ŕ���</param>
		/// <param name="taxRateStartDate">�ŗ��J�n��(YYYYMMDD)</param>
		/// <param name="taxRateEndDate">�ŗ��I����(YYYYMMDD)</param>
		/// <param name="taxRate">�ŗ�</param>
		/// <param name="taxRateStartDate2">�ŗ��J�n��2(YYYYMMDD)</param>
		/// <param name="taxRateEndDate2">�ŗ��I����2(YYYYMMDD)</param>
		/// <param name="taxRate2">�ŗ�2</param>
		/// <param name="taxRateStartDate3">�ŗ��J�n��3(YYYYMMDD)</param>
		/// <param name="taxRateEndDate3">�ŗ��I����3(YYYYMMDD)</param>
		/// <param name="taxRate3">�ŗ�3</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>TaxRateSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TaxRateSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public TaxRateSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 taxRateCode, string taxRateProperNounNm, string taxRateName, Int32 consTaxLayMethod, DateTime taxRateStartDate, DateTime taxRateEndDate, Double taxRate, DateTime taxRateStartDate2, DateTime taxRateEndDate2, Double taxRate2, DateTime taxRateStartDate3, DateTime taxRateEndDate3, Double taxRate3, string updEmployeeName, string enterpriseName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._taxRateCode = taxRateCode;
			this._taxRateProperNounNm = taxRateProperNounNm;
			this._taxRateName = taxRateName;
            this._consTaxLayMethod = consTaxLayMethod;
			this.TaxRateStartDate = taxRateStartDate;
			this.TaxRateEndDate = taxRateEndDate;
			this._taxRate = taxRate;
			this.TaxRateStartDate2 = taxRateStartDate2;
			this.TaxRateEndDate2 = taxRateEndDate2;
			this._taxRate2 = taxRate2;
			this.TaxRateStartDate3 = taxRateStartDate3;
			this.TaxRateEndDate3 = taxRateEndDate3;
			this._taxRate3 = taxRate3;
			this._updEmployeeName = updEmployeeName;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// �ŗ��ݒ�N���X��������
		/// </summary>
		/// <returns>TaxRateSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����TaxRateSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public TaxRateSet Clone()
		{
            return new TaxRateSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._taxRateCode, this._taxRateProperNounNm, this._taxRateName, this._consTaxLayMethod, this._taxRateStartDate, this._taxRateEndDate, this._taxRate, this._taxRateStartDate2, this._taxRateEndDate2, this._taxRate2, this._taxRateStartDate3, this._taxRateEndDate3, this._taxRate3, this._updEmployeeName, this._enterpriseName);
		}

		/// <summary>
		/// �ŗ��ݒ�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�TaxRateSet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TaxRateSet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(TaxRateSet target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				&& (this.UpdateDateTime == target.UpdateDateTime)
				&& (this.EnterpriseCode == target.EnterpriseCode)
				&& (this.FileHeaderGuid == target.FileHeaderGuid)
				&& (this.UpdEmployeeCode == target.UpdEmployeeCode)
				&& (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				&& (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				&& (this.LogicalDeleteCode == target.LogicalDeleteCode)
				&& (this.TaxRateCode == target.TaxRateCode)
				&& (this.TaxRateProperNounNm == target.TaxRateProperNounNm)
				&& (this.TaxRateName == target.TaxRateName)
                && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
				&& (this.TaxRateStartDate == target.TaxRateStartDate)
				&& (this.TaxRateEndDate == target.TaxRateEndDate)
				&& (this.TaxRate == target.TaxRate)
				&& (this.TaxRateStartDate2 == target.TaxRateStartDate2)
				&& (this.TaxRateEndDate2 == target.TaxRateEndDate2)
				&& (this.TaxRate2 == target.TaxRate2)
				&& (this.TaxRateStartDate3 == target.TaxRateStartDate3)
				&& (this.TaxRateEndDate3 == target.TaxRateEndDate3)
				&& (this.TaxRate3 == target.TaxRate3)
				&& (this.UpdEmployeeName == target.UpdEmployeeName)
				&& (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// �ŗ��ݒ�N���X��r����
		/// </summary>
		/// <param name="taxrateset1">
		///                    ��r����TaxRateSet�N���X�̃C���X�^���X
		/// </param>
		/// <param name="taxrateset2">��r����TaxRateSet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TaxRateSet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(TaxRateSet taxrateset1, TaxRateSet taxrateset2)
		{
			return ((taxrateset1.CreateDateTime == taxrateset2.CreateDateTime)
				&& (taxrateset1.UpdateDateTime == taxrateset2.UpdateDateTime)
				&& (taxrateset1.EnterpriseCode == taxrateset2.EnterpriseCode)
				&& (taxrateset1.FileHeaderGuid == taxrateset2.FileHeaderGuid)
				&& (taxrateset1.UpdEmployeeCode == taxrateset2.UpdEmployeeCode)
				&& (taxrateset1.UpdAssemblyId1 == taxrateset2.UpdAssemblyId1)
				&& (taxrateset1.UpdAssemblyId2 == taxrateset2.UpdAssemblyId2)
				&& (taxrateset1.LogicalDeleteCode == taxrateset2.LogicalDeleteCode)
				&& (taxrateset1.TaxRateCode == taxrateset2.TaxRateCode)
				&& (taxrateset1.TaxRateProperNounNm == taxrateset2.TaxRateProperNounNm)
				&& (taxrateset1.TaxRateName == taxrateset2.TaxRateName)
                && (taxrateset1.ConsTaxLayMethod == taxrateset2.ConsTaxLayMethod)
				&& (taxrateset1.TaxRateStartDate == taxrateset2.TaxRateStartDate)
				&& (taxrateset1.TaxRateEndDate == taxrateset2.TaxRateEndDate)
				&& (taxrateset1.TaxRate == taxrateset2.TaxRate)
				&& (taxrateset1.TaxRateStartDate2 == taxrateset2.TaxRateStartDate2)
				&& (taxrateset1.TaxRateEndDate2 == taxrateset2.TaxRateEndDate2)
				&& (taxrateset1.TaxRate2 == taxrateset2.TaxRate2)
				&& (taxrateset1.TaxRateStartDate3 == taxrateset2.TaxRateStartDate3)
				&& (taxrateset1.TaxRateEndDate3 == taxrateset2.TaxRateEndDate3)
				&& (taxrateset1.TaxRate3 == taxrateset2.TaxRate3)
				&& (taxrateset1.UpdEmployeeName == taxrateset2.UpdEmployeeName)
				&& (taxrateset1.EnterpriseName == taxrateset2.EnterpriseName));
		}
		/// <summary>
		/// �ŗ��ݒ�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�TaxRateSet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TaxRateSet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(TaxRateSet target)
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
			if(this.TaxRateCode != target.TaxRateCode)resList.Add("TaxRateCode");
			if(this.TaxRateProperNounNm != target.TaxRateProperNounNm)resList.Add("TaxRateProperNounNm");
			if(this.TaxRateName != target.TaxRateName)resList.Add("TaxRateName");
            if(this.ConsTaxLayMethod != target.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(this.TaxRateStartDate != target.TaxRateStartDate)resList.Add("TaxRateStartDate");
			if(this.TaxRateEndDate != target.TaxRateEndDate)resList.Add("TaxRateEndDate");
			if(this.TaxRate != target.TaxRate)resList.Add("TaxRate");
			if(this.TaxRateStartDate2 != target.TaxRateStartDate2)resList.Add("TaxRateStartDate2");
			if(this.TaxRateEndDate2 != target.TaxRateEndDate2)resList.Add("TaxRateEndDate2");
			if(this.TaxRate2 != target.TaxRate2)resList.Add("TaxRate2");
			if(this.TaxRateStartDate3 != target.TaxRateStartDate3)resList.Add("TaxRateStartDate3");
			if(this.TaxRateEndDate3 != target.TaxRateEndDate3)resList.Add("TaxRateEndDate3");
			if(this.TaxRate3 != target.TaxRate3)resList.Add("TaxRate3");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// �ŗ��ݒ�N���X��r����
		/// </summary>
		/// <param name="taxrateset1">��r����TaxRateSet�N���X�̃C���X�^���X</param>
		/// <param name="taxrateset2">��r����TaxRateSet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   TaxRateSet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(TaxRateSet taxrateset1, TaxRateSet taxrateset2)
		{
			ArrayList resList = new ArrayList();
			if(taxrateset1.CreateDateTime != taxrateset2.CreateDateTime)resList.Add("CreateDateTime");
			if(taxrateset1.UpdateDateTime != taxrateset2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(taxrateset1.EnterpriseCode != taxrateset2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(taxrateset1.FileHeaderGuid != taxrateset2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(taxrateset1.UpdEmployeeCode != taxrateset2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(taxrateset1.UpdAssemblyId1 != taxrateset2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(taxrateset1.UpdAssemblyId2 != taxrateset2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(taxrateset1.LogicalDeleteCode != taxrateset2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(taxrateset1.TaxRateCode != taxrateset2.TaxRateCode)resList.Add("TaxRateCode");
			if(taxrateset1.TaxRateProperNounNm != taxrateset2.TaxRateProperNounNm)resList.Add("TaxRateProperNounNm");
			if(taxrateset1.TaxRateName != taxrateset2.TaxRateName)resList.Add("TaxRateName");
            if(taxrateset1.ConsTaxLayMethod != taxrateset2.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(taxrateset1.TaxRateStartDate != taxrateset2.TaxRateStartDate)resList.Add("TaxRateStartDate");
			if(taxrateset1.TaxRateEndDate != taxrateset2.TaxRateEndDate)resList.Add("TaxRateEndDate");
			if(taxrateset1.TaxRate != taxrateset2.TaxRate)resList.Add("TaxRate");
			if(taxrateset1.TaxRateStartDate2 != taxrateset2.TaxRateStartDate2)resList.Add("TaxRateStartDate2");
			if(taxrateset1.TaxRateEndDate2 != taxrateset2.TaxRateEndDate2)resList.Add("TaxRateEndDate2");
			if(taxrateset1.TaxRate2 != taxrateset2.TaxRate2)resList.Add("TaxRate2");
			if(taxrateset1.TaxRateStartDate3 != taxrateset2.TaxRateStartDate3)resList.Add("TaxRateStartDate3");
			if(taxrateset1.TaxRateEndDate3 != taxrateset2.TaxRateEndDate3)resList.Add("TaxRateEndDate3");
			if(taxrateset1.TaxRate3 != taxrateset2.TaxRate3)resList.Add("TaxRate3");
			if(taxrateset1.UpdEmployeeName != taxrateset2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(taxrateset1.EnterpriseName != taxrateset2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}

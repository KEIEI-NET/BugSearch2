using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:	 CustSalesTarget
    /// <summary>
    /// 					 ���Ӑ�ʔ���ڕW�ݒ�}�X�^
    /// </summary>
    /// <remarks>
	/// <br>note			 :	 ���Ӑ�ʔ���ڕW�ݒ�}�X�^�t�@�C��</br>
    /// <br>Programmer		 :	 30167 ���@�O�M</br>
    /// <br>Date			 :	 </br>
    /// <br>Genarated Date	 :	 2007.11.21  (CSharp File Generated Date)</br>
    /// <br>Update Note 	 :	 </br>
    /// <br></br>
    /// </remarks>
    public class CustSalesTarget
    {
        #region Private Member

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

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�ڕW�ݒ�敪</summary>
        private Int32 _targetSetCd;

        /// <summary>�ڕW�Δ�敪</summary>
        private Int32 _targetContrastCd;

        /// <summary>�ڕW�敪�R�[�h</summary>
        private string _targetDivideCode = "";

        /// <summary>�ڕW�敪����</summary>
        private string _targetDivideName = "";

		/// <summary>�Ǝ�R�[�h</summary>
		private Int32 _businessTypeCode;

		/// <summary>�̔��G���A�R�[�h</summary>
		private Int32 _salesAreaCode;

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

        /// <summary>�K�p�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyStaDate;

        /// <summary>�K�p�I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyEndDate;

        /// <summary>����ڕW���z</summary>
        private Int64 _salesTargetMoney;

        /// <summary>����ڕW�e���z</summary>
        private Int64 _salesTargetProfit;

        /// <summary>����ڕW����</summary>
        private Double _salesTargetCount;

        #endregion Private Member

        #region Public Propaty

        /// public propaty name  :	CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �쐬�����v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get
            {
                return _createDateTime;
            }
            set
            {
                _createDateTime = value;
            }
        }

        /// public propaty name  :	CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �쐬���� �a��v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get
            {
                return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �쐬���� ����v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �X�V�����v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get
            {
                return _updateDateTime;
            }
            set
            {
                _updateDateTime = value;
            }
        }

        /// public propaty name  :	UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �X�V���� �a��v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get
            {
                return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �X�V���� ����v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);
            }
            set
            {
            }
        }

        /// public propaty name  :	EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get
            {
                return _enterpriseCode;
            }
            set
            {
                _enterpriseCode = value;
            }
        }

        /// public propaty name  :	FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 GUID�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get
            {
                return _fileHeaderGuid;
            }
            set
            {
                _fileHeaderGuid = value;
            }
        }

        /// public propaty name  :	UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get
            {
                return _updEmployeeCode;
            }
            set
            {
                _updEmployeeCode = value;
            }
        }

        /// public propaty name  :	UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get
            {
                return _updAssemblyId1;
            }
            set
            {
                _updAssemblyId1 = value;
            }
        }

        /// public propaty name  :	UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get
            {
                return _updAssemblyId2;
            }
            set
            {
                _updAssemblyId2 = value;
            }
        }

        /// public propaty name  :	LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �_���폜�敪�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get
            {
                return _logicalDeleteCode;
            }
            set
            {
                _logicalDeleteCode = value;
            }
        }

        /// public propaty name  :	SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string SectionCode
        {
            get
            {
                return _sectionCode;
            }
            set
            {
                _sectionCode = value;
            }
        }

        /// public propaty name  :	TargetSetCd
        /// <summary>�ڕW�ݒ�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �ڕW�ݒ�敪�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 TargetSetCd
        {
            get
            {
                return _targetSetCd;
            }
            set
            {
                _targetSetCd = value;
            }
        }

        /// public propaty name  :	TargetContrastCd
        /// <summary>�ڕW�Δ�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �ڕW�Δ�敪�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 TargetContrastCd
        {
            get
            {
                return _targetContrastCd;
            }
            set
            {
                _targetContrastCd = value;
            }
        }

        /// public propaty name  :	TargetDivideCode
        /// <summary>�ڕW�敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �ڕW�敪�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string TargetDivideCode
        {
            get
            {
                return _targetDivideCode;
            }
            set
            {
                _targetDivideCode = value;
            }
        }

        /// public propaty name  :	TargetDivideName
        /// <summary>�ڕW�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �ڕW�敪���̃v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string TargetDivideName
        {
            get
            {
                return _targetDivideName;
            }
            set
            {
                _targetDivideName = value;
            }
        }

		/// public propaty name  :	BusinessTypeCode
		/// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �Ǝ�R�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
		/// </remarks>
		public Int32 BusinessTypeCode
		{
			get
			{
				return _businessTypeCode;
			}
			set
			{
				_businessTypeCode = value;
			}
		}

		/// public propaty name  :	SalesAreaCode
		/// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �̔��G���A�R�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
		/// </remarks>
		public Int32 SalesAreaCode
		{
			get
			{
				return _salesAreaCode;
			}
			set
			{
				_salesAreaCode = value;
			}
		}

		/// public propaty name  :	CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get
			{
				return _customerCode;
			}
			set
			{
				_customerCode = value;
			}
		}

        /// public propaty name  :	ApplyStaDate
        /// <summary>�K�p�J�n���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�J�n���v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime ApplyStaDate
        {
            get
            {
                return _applyStaDate;
            }
            set
            {
                _applyStaDate = value;
            }
        }

        /// public propaty name  :	ApplyStaDateJpFormal
        /// <summary>�K�p�J�n�� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�J�n�� �a��v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyStaDateJpFormal
        {
            get
            {
                return TDateTime.DateTimeToString("GGYYMMDD", _applyStaDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyStaDateJpInFormal
        /// <summary>�K�p�J�n�� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�J�n�� �a��(��)�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyStaDateJpInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("ggYY/MM/DD", _applyStaDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyStaDateAdFormal
        /// <summary>�K�p�J�n�� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�J�n�� ����v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyStaDateAdFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YYYY/MM/DD", _applyStaDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyStaDateAdInFormal
        /// <summary>�K�p�J�n�� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�J�n�� ����(��)�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyStaDateAdInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YY/MM/DD", _applyStaDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyEndDate
        /// <summary>�K�p�I�����v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�I�����v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime ApplyEndDate
        {
            get
            {
                return _applyEndDate;
            }
            set
            {
                _applyEndDate = value;
            }
        }

        /// public propaty name  :	ApplyEndDateJpFormal
        /// <summary>�K�p�I���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�I���� �a��v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyEndDateJpFormal
        {
            get
            {
                return TDateTime.DateTimeToString("GGYYMMDD", _applyEndDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyEndDateJpInFormal
        /// <summary>�K�p�I���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�I���� �a��(��)�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyEndDateJpInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("ggYY/MM/DD", _applyEndDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyEndDateAdFormal
        /// <summary>�K�p�I���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�I���� ����v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyEndDateAdFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YYYY/MM/DD", _applyEndDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	ApplyEndDateAdInFormal
        /// <summary>�K�p�I���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �K�p�I���� ����(��)�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string ApplyEndDateAdInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YY/MM/DD", _applyEndDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	SalesTargetMoney
        /// <summary>����ڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	����ڕW���z�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get
            {
                return _salesTargetMoney;
            }
            set
            {
                _salesTargetMoney = value;
            }
        }

        /// public propaty name  :	SalesTargetProfit
        /// <summary>����ڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ����ڕW�e���z�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get
            {
                return _salesTargetProfit;
            }
            set
            {
                _salesTargetProfit = value;
            }
        }

        /// public propaty name  :	SalesTargetCount
        /// <summary>����ڕW���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ����ڕW���ʃv���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Double SalesTargetCount
        {
            get
            {
                return _salesTargetCount;
            }
            set
            {
                _salesTargetCount = value;
            }
        }

        #endregion Public Propaty

        #region �R���X�g���N�^
        /// <summary>
		/// ���Ӑ�ʔ���ڕW�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>CustSalesTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 CustSalesTarget�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public CustSalesTarget()
        {
        }


        /// <summary>
		/// ���Ӑ�ʔ���ڕW�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="targetSetCd">�ڕW�ݒ�敪</param>
        /// <param name="targetContrastCd">�ڕW�Δ�敪</param>
        /// <param name="targetDivideCode">�ڕW�敪�R�[�h</param>
        /// <param name="targetDivideName">�ڕW�敪����</param>
		/// <param name="businessTypeCode">�Ǝ�R�[�h</param>
		/// <param name="salesAreaCode">�̔��G���A�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="applyStaDate">�K�p�J�n��(YYYYMMDD)</param>
        /// <param name="applyEndDate">�K�p�I����(YYYYMMDD)</param>
        /// <param name="salesTargetMoney">����ڕW���z</param>
        /// <param name="salesTargetProfit">����ڕW�e���z</param>
        /// <param name="salesTargetCount">����ڕW����</param>
        /// <returns>CustSalesTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 CustSalesTarget�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public CustSalesTarget(
            DateTime createDateTime,
            DateTime updateDateTime,
            string enterpriseCode,
            Guid fileHeaderGuid,
            string updEmployeeCode,
            string updAssemblyId1,
            string updAssemblyId2,
            Int32 logicalDeleteCode,
            string sectionCode,
            Int32 targetSetCd,
            Int32 targetContrastCd,
            string targetDivideCode,
            string targetDivideName,
			Int32 businessTypeCode,
			Int32 salesAreaCode,
			Int32 customerCode,
            DateTime applyStaDate,
            DateTime applyEndDate,
            Int64 salesTargetMoney,
            Int64 salesTargetProfit,
            Double salesTargetCount
			)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._targetSetCd = targetSetCd;
            this._targetContrastCd = targetContrastCd;
            this._targetDivideCode = targetDivideCode;
            this._targetDivideName = targetDivideName;
			this._businessTypeCode = businessTypeCode;
			this._salesAreaCode = salesAreaCode;
			this._customerCode = customerCode;
            this._applyStaDate = applyStaDate;
            this._applyEndDate = applyEndDate;
            this._salesTargetMoney = salesTargetMoney;
            this._salesTargetProfit = salesTargetProfit;
            this._salesTargetCount = salesTargetCount;
		}

        #endregion �R���X�g���N�^

        #region Public Method

		#region ���@���Ӑ�ʔ���ڕW�ݒ�}�X�^��������
		/// <summary>
		/// ���Ӑ�ʔ���ڕW�ݒ�}�X�^��������
        /// </summary>
        /// <returns>CustSalesTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 ���g�̓��e�Ɠ�����CustSalesTarget�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer		 :	 30167 ���@�O�M</br>
        /// </remarks>
        public CustSalesTarget Clone()
        {
            return new CustSalesTarget(this._createDateTime,
                               this._updateDateTime,
                               this._enterpriseCode,
                               this._fileHeaderGuid,
                               this._updEmployeeCode,
                               this._updAssemblyId1,
                               this._updAssemblyId2,
                               this._logicalDeleteCode,
                               this._sectionCode,
                               this._targetSetCd,
                               this._targetContrastCd,
                               this._targetDivideCode,
                               this._targetDivideName,
							   this._businessTypeCode,
							   this._salesAreaCode,
							   this._customerCode,
                               this._applyStaDate,
                               this._applyEndDate,
                               this._salesTargetMoney,
                               this._salesTargetProfit,
                               this._salesTargetCount
							   );
		}
		#endregion ���@���Ӑ�ʔ���ڕW�ݒ�}�X�^��������

		#region ���@���Ӑ�ʔ���ڕW�ݒ�}�X�^��r����(CustSalesTarget)
		/// <summary>
		/// ���Ӑ�ʔ���ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 CustSalesTarget�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer		 :	 30167 ���@�O�M</br>
        /// </remarks>
        public bool Equals(CustSalesTarget target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.TargetSetCd == target.TargetSetCd)
                 && (this.TargetContrastCd == target.TargetContrastCd)
                 && (this.TargetDivideCode == target.TargetDivideCode)
                 && (this.TargetDivideName == target.TargetDivideName)
				 && (this.BusinessTypeCode == target.BusinessTypeCode)
				 && (this.SalesAreaCode == target.SalesAreaCode)
				 && (this.CustomerCode == target.CustomerCode)
                 && (this.ApplyStaDate == target.ApplyStaDate)
                 && (this.ApplyEndDate == target.ApplyEndDate)
                 && (this.SalesTargetMoney == target.SalesTargetMoney)
                 && (this.SalesTargetProfit == target.SalesTargetProfit)
                 && (this.SalesTargetCount == target.SalesTargetCount)
				 );
		}
		#endregion ���@���Ӑ�ʔ���ڕW�ݒ�}�X�^��r����

		#region ���@���Ӑ�ʔ���ڕW�ݒ�}�X�^��r����(CustSalesTarget,ResvdDT)
		/// <summary>
		/// ���Ӑ�ʔ���ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="salesMonTarget1">
        /// 				   ��r����CustSalesTarget�N���X�̃C���X�^���X
        /// </param>
        /// <param name="salesMonTarget2">��r����CustSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 CustSalesTarget�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer		 :	 30167 ���@�O�M</br>
        /// </remarks>
        public static bool Equals(CustSalesTarget salesMonTarget1, CustSalesTarget salesMonTarget2)
        {
            return ((salesMonTarget1.CreateDateTime == salesMonTarget2.CreateDateTime)
                 && (salesMonTarget1.UpdateDateTime == salesMonTarget2.UpdateDateTime)
                 && (salesMonTarget1.EnterpriseCode == salesMonTarget2.EnterpriseCode)
                 && (salesMonTarget1.FileHeaderGuid == salesMonTarget2.FileHeaderGuid)
                 && (salesMonTarget1.UpdEmployeeCode == salesMonTarget2.UpdEmployeeCode)
                 && (salesMonTarget1.UpdAssemblyId1 == salesMonTarget2.UpdAssemblyId1)
                 && (salesMonTarget1.UpdAssemblyId2 == salesMonTarget2.UpdAssemblyId2)
                 && (salesMonTarget1.LogicalDeleteCode == salesMonTarget2.LogicalDeleteCode)
                 && (salesMonTarget1.SectionCode == salesMonTarget2.SectionCode)
                 && (salesMonTarget1.TargetSetCd == salesMonTarget2.TargetSetCd)
                 && (salesMonTarget1.TargetContrastCd == salesMonTarget2.TargetContrastCd)
                 && (salesMonTarget1.TargetDivideCode == salesMonTarget2.TargetDivideCode)
                 && (salesMonTarget1.TargetDivideName == salesMonTarget2.TargetDivideName)
				 && (salesMonTarget1.BusinessTypeCode == salesMonTarget2.BusinessTypeCode)
				 && (salesMonTarget1.SalesAreaCode == salesMonTarget2.SalesAreaCode)
				 && (salesMonTarget1.CustomerCode == salesMonTarget2.CustomerCode)
                 && (salesMonTarget1.ApplyStaDate == salesMonTarget2.ApplyStaDate)
                 && (salesMonTarget1.ApplyEndDate == salesMonTarget2.ApplyEndDate)
                 && (salesMonTarget1.SalesTargetMoney == salesMonTarget2.SalesTargetMoney)
                 && (salesMonTarget1.SalesTargetProfit == salesMonTarget2.SalesTargetProfit)
                 && (salesMonTarget1.SalesTargetCount == salesMonTarget2.SalesTargetCount)
				 );
		}
		#endregion ���@���Ӑ�ʔ���ڕW�ݒ�}�X�^��r����(CustSalesTarget,ResvdDT)

		#region ���@���Ӑ�ʔ���ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����(CustSalesTarget)
		/// <summary>
		/// ���Ӑ�ʔ���ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 CustSalesTarget�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer		 :	 30167 ���@�O�M</br>
        /// </remarks>
        public ArrayList Compare(CustSalesTarget target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.TargetSetCd != target.TargetSetCd) resList.Add("TargetSetCd");
            if (this.TargetContrastCd != target.TargetContrastCd) resList.Add("TargetContrastCd");
            if (this.TargetDivideCode != target.TargetDivideCode) resList.Add("TargetDivideCode");
            if (this.TargetDivideName != target.TargetDivideName) resList.Add("TargetDivideName");
			if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
			if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
			if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.ApplyStaDate != target.ApplyStaDate) resList.Add("ApplyStaDate");
            if (this.ApplyEndDate != target.ApplyEndDate) resList.Add("ApplyEndDate");
            if (this.SalesTargetMoney != target.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (this.SalesTargetProfit != target.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (this.SalesTargetCount != target.SalesTargetCount) resList.Add("SalesTargetCount");

            return resList;
		}
		#endregion ���@���Ӑ�ʔ���ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����(CustSalesTarget)

		#region ���@���Ӑ�ʔ���ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����(CustSalesTarget,CustSalesTarget)
		/// <summary>
		/// ���Ӑ�ʔ���ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="salesMonTarget1">��r����CustSalesTarget�N���X�̃C���X�^���X</param>
        /// <param name="salesMonTarget2">��r����CustSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 CustSalesTarget�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer		 :	 30167 ���@�O�M</br>
        /// </remarks>
        public static ArrayList Compare(CustSalesTarget salesMonTarget1, CustSalesTarget salesMonTarget2)
        {
            ArrayList resList = new ArrayList();
            if (salesMonTarget1.CreateDateTime != salesMonTarget2.CreateDateTime) resList.Add("CreateDateTime");
            if (salesMonTarget1.UpdateDateTime != salesMonTarget2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (salesMonTarget1.EnterpriseCode != salesMonTarget2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesMonTarget1.FileHeaderGuid != salesMonTarget2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (salesMonTarget1.UpdEmployeeCode != salesMonTarget2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (salesMonTarget1.UpdAssemblyId1 != salesMonTarget2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (salesMonTarget1.UpdAssemblyId2 != salesMonTarget2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (salesMonTarget1.LogicalDeleteCode != salesMonTarget2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (salesMonTarget1.SectionCode != salesMonTarget2.SectionCode) resList.Add("SectionCode");
            if (salesMonTarget1.TargetSetCd != salesMonTarget2.TargetSetCd) resList.Add("TargetSetCd");
            if (salesMonTarget1.TargetContrastCd != salesMonTarget2.TargetContrastCd) resList.Add("TargetContrastCd");
            if (salesMonTarget1.TargetDivideCode != salesMonTarget2.TargetDivideCode) resList.Add("TargetDivideCode");
            if (salesMonTarget1.TargetDivideName != salesMonTarget2.TargetDivideName) resList.Add("TargetDivideName");
			if (salesMonTarget1.BusinessTypeCode != salesMonTarget2.BusinessTypeCode) resList.Add("BusinessTypeCode");
			if (salesMonTarget1.SalesAreaCode != salesMonTarget2.SalesAreaCode) resList.Add("SalesAreaCode");
			if (salesMonTarget1.CustomerCode != salesMonTarget2.CustomerCode) resList.Add("CustomerCode");
            if (salesMonTarget1.ApplyStaDate != salesMonTarget2.ApplyStaDate) resList.Add("ApplyStaDate");
            if (salesMonTarget1.ApplyEndDate != salesMonTarget2.ApplyEndDate) resList.Add("ApplyEndDate");
            if (salesMonTarget1.SalesTargetMoney != salesMonTarget2.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (salesMonTarget1.SalesTargetProfit != salesMonTarget2.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (salesMonTarget1.SalesTargetCount != salesMonTarget2.SalesTargetCount) resList.Add("SalesTargetCount");

            return resList;
		}
		#endregion ���@���Ӑ�ʔ���ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����(CustSalesTarget,CustSalesTarget)

		#endregion Public Method

	}
}

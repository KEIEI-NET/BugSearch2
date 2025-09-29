using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:	 EmpSalesTarget
    /// <summary>
    /// 					 �]�ƈ��ʔ���ڕW�ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note			 :	 �]�ƈ��ʔ���ڕW�ݒ�}�X�^�t�@�C��</br>
    /// <br>Programmer		 :	 NEPCO</br>
    /// <br>Date			 :	 </br>
    /// <br>Genarated Date	 :	 2007.05.08  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note 	 :	 2007.10.01 ��� ���b</br>
    /// <br>                 ����.DC�p�ɕύX�i���ڂ̒ǉ��E�폜�j</br>
	/// <br>                     2007.11.21 ��� �O�M</br>
	/// <br>                 �]�ƈ��ʔ���ڕW�ݒ�}�X�^�C���i���ڂ̒ǉ��E�폜�j</br>
    /// </remarks>
    public class EmpSalesTarget
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

        /// <summary>�K�p�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyStaDate;

        /// <summary>�K�p�I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyEndDate;

		//----- ueno add---------- start 2007.11.21
		/// <summary>�]�ƈ��敪</summary>
		private Int32 _employeeDivCd;
		//----- ueno add---------- end   2007.11.21
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>�ۃR�[�h</summary>
        private Int32 _minSectionCode;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>�]�ƈ��R�[�h</summary>
        private string _employeeCode = "";

        /// <summary>�]�ƈ�����</summary>
        private string _employeeName = "";

        /// <summary>����ڕW���z</summary>
        private Int64 _salesTargetMoney;

        /// <summary>����ڕW�e���z</summary>
        private Int64 _salesTargetProfit;

        /// <summary>����ڕW����</summary>
        private Double _salesTargetCount;

		//----- ueno del---------- start 2007.11.21
		///// <summary>�����䗦</summary>
		//private Double _weekdayRatio;

		///// <summary>�y���䗦</summary>
		//private Double _satSunRatio;
		//----- ueno del---------- end   2007.11.21

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

        /// public propaty name  :	EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string EmployeeCode
        {
            get
            {
                return _employeeCode;
            }
            set
            {
                _employeeCode = value;
            }
        }

        /// public propaty name  :	Name
        /// <summary>�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �]�ƈ����̃v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string EmployeeName
        {
            get
            {
                return _employeeName;
            }
            set
            {
                _employeeName = value;
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

		//----- ueno del---------- start 2007.11.21
		///// public propaty name  :	WeekdayRatio
		///// <summary>�����䗦�v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 �����䗦�v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Double WeekdayRatio
		//{
		//    get
		//    {
		//        return _weekdayRatio;
		//    }
		//    set
		//    {
		//        _weekdayRatio = value;
		//    }
		//}

		///// public propaty name  :	SatSunRatio
		///// <summary>�y���䗦�v���p�e�B</summary>
		///// <value>�����i���ԁA���j���i���ח\���</value>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 �y���䗦�v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Double SatSunRatio
		//{
		//    get
		//    {
		//        return _satSunRatio;
		//    }
		//    set
		//    {
		//        _satSunRatio = value;
		//    }
		//}
		//----- ueno del---------- end   2007.11.21

		//----- ueno add---------- start 2007.11.21
		/// public propaty name  :	EmployeeDivCd
		/// <summary>�]�ƈ��敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �]�ƈ��敪�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
		/// </remarks>
		public Int32 EmployeeDivCd
		{
			get
			{
				return _employeeDivCd;
			}
			set
			{
				_employeeDivCd = value;
			}
		}
		//----- ueno add---------- end   2007.11.21
        
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// public propaty name  :	SubSectionCode
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ����R�[�h</br>
        /// <br>Programer		 :	 22018 ��� ���b</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get
            {
                return _subSectionCode;
            }
            set
            {
                _subSectionCode = value;
            }
        }
        /// public propaty name  :	MinSectionCode
        /// <summary>�ۃR�[�h�v���p�e�B</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 �ۃR�[�h</br>
        /// <br>Programer		 :	 22018 ��� ���b</br>
        /// </remarks>
        public Int32 MinSectionCode
        {
            get
            {
                return _minSectionCode;
            }
            set
            {
                _minSectionCode = value;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        #endregion Public Propaty

        #region �R���X�g���N�^
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>EmpSalesTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 EmpSalesTarget�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public EmpSalesTarget()
        {
        }


        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^�R���X�g���N�^
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
        /// <param name="applyStaDate">�K�p�J�n��(YYYYMMDD)</param>
        /// <param name="applyEndDate">�K�p�I����(YYYYMMDD)</param>
		/// <param name="employeeDivCd">�]�ƈ��敪</param>
		/// <param name="subSectionCode">����R�[�h</param>
        /// <param name="minSectionCode">�ۃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="employeeName">�]�ƈ�����</param>
        /// <param name="salesTargetMoney">����ڕW���z</param>
        /// <param name="salesTargetProfit">����ڕW�e���z</param>
        /// <param name="salesTargetCount">����ڕW����</param>
        /// <param name="weekdayRatio">�����䗦</param>
        /// <param name="satSunRatio">�y���䗦</param>
        /// <returns>EmpSalesTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 EmpSalesTarget�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public EmpSalesTarget(
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
            DateTime applyStaDate,
            DateTime applyEndDate,
			//----- ueno add---------- start 2007.11.21
			Int32 employeeDivCd,
			//----- ueno add---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            Int32 subSectionCode,
            Int32 minSectionCode,
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            string employeeCode,
            string employeeName,
            Int64 salesTargetMoney,
            Int64 salesTargetProfit,
            Double salesTargetCount
			//----- ueno del---------- start 2007.11.21
			//Double weekdayRatio,
			//Double satSunRatio
			//----- ueno del---------- end   2007.11.21
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
            this._applyStaDate = applyStaDate;
            this._applyEndDate = applyEndDate;
			//----- ueno add---------- start 2007.11.21
			this._employeeDivCd = employeeDivCd;
			//----- ueno add---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._subSectionCode = subSectionCode;
            this._minSectionCode = minSectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._employeeCode = employeeCode;
            this._employeeName = employeeName;
            this._salesTargetMoney = salesTargetMoney;
            this._salesTargetProfit = salesTargetProfit;
            this._salesTargetCount = salesTargetCount;
			//----- ueno del---------- start 2007.11.21
			//this._weekdayRatio = weekdayRatio;
			//this._satSunRatio = satSunRatio;
			//----- ueno del---------- end   2007.11.21
		}

        #endregion �R���X�g���N�^

        #region Public Method

        #region ���@�]�ƈ��ʔ���ڕW�ݒ�}�X�^��������
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^��������
        /// </summary>
        /// <returns>EmpSalesTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 ���g�̓��e�Ɠ�����EmpSalesTarget�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public EmpSalesTarget Clone()
        {
            return new EmpSalesTarget(this._createDateTime,
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
                               this._applyStaDate,
                               this._applyEndDate,
							   //----- ueno add---------- start 2007.11.21
							   this._employeeDivCd,
							   //----- ueno add---------- end   2007.11.21                               
                               // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                               this._subSectionCode,
                               this._minSectionCode,
                               // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                               this._employeeCode,
                               this._employeeName,
                               this._salesTargetMoney,
                               this._salesTargetProfit,
                               this._salesTargetCount
							   //----- ueno del---------- start 2007.11.21
							   //this._weekdayRatio,
                               //this._satSunRatio
							   //----- ueno del---------- end   2007.11.21
							   );
        }
        #endregion ���@�]�ƈ��ʔ���ڕW�ݒ�}�X�^��������

        #region ���@�]�ƈ��ʔ���ڕW�ݒ�}�X�^��r����(EmpSalesTarget)
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�EmpSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 EmpSalesTarget�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public bool Equals(EmpSalesTarget target)
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
                 && (this.ApplyStaDate == target.ApplyStaDate)
                 && (this.ApplyEndDate == target.ApplyEndDate)
				 //----- ueno add---------- start 2007.11.21
				 && (this.EmployeeDivCd == target.EmployeeDivCd)
				 //----- ueno add---------- end   2007.11.21
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (this.SubSectionCode == target.SubSectionCode )
                 && (this.MinSectionCode == target.MinSectionCode )
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.EmployeeName == target.EmployeeName)
                 && (this.SalesTargetMoney == target.SalesTargetMoney)
                 && (this.SalesTargetProfit == target.SalesTargetProfit)
                 && (this.SalesTargetCount == target.SalesTargetCount)
				 //----- ueno del---------- start 2007.11.21
				 //&& (this.WeekdayRatio == target.WeekdayRatio)
                 //&& ( this.SatSunRatio == target.SatSunRatio )
				 //----- ueno del---------- end   2007.11.21
				 );
        }
        #endregion ���@�]�ƈ��ʔ���ڕW�ݒ�}�X�^��r����

        #region ���@�]�ƈ��ʔ���ڕW�ݒ�}�X�^��r����(EmpSalesTarget,ResvdDT)
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="salesMonTarget1">
        /// 				   ��r����EmpSalesTarget�N���X�̃C���X�^���X
        /// </param>
        /// <param name="salesMonTarget2">��r����EmpSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 EmpSalesTarget�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public static bool Equals(EmpSalesTarget salesMonTarget1, EmpSalesTarget salesMonTarget2)
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
                 && (salesMonTarget1.ApplyStaDate == salesMonTarget2.ApplyStaDate)
                 && (salesMonTarget1.ApplyEndDate == salesMonTarget2.ApplyEndDate)
				 //----- ueno add---------- start 2007.11.21
				 && (salesMonTarget1.EmployeeDivCd == salesMonTarget2.EmployeeDivCd)
				 //----- ueno add---------- end   2007.11.21
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (salesMonTarget1.SubSectionCode == salesMonTarget2.SubSectionCode )
                 && (salesMonTarget1.MinSectionCode == salesMonTarget2.MinSectionCode )
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                 && ( salesMonTarget1.EmployeeCode == salesMonTarget2.EmployeeCode )
                 && (salesMonTarget1.EmployeeName == salesMonTarget2.EmployeeName)
                 && (salesMonTarget1.SalesTargetMoney == salesMonTarget2.SalesTargetMoney)
                 && (salesMonTarget1.SalesTargetProfit == salesMonTarget2.SalesTargetProfit)
                 && (salesMonTarget1.SalesTargetCount == salesMonTarget2.SalesTargetCount)
				 //----- ueno del---------- start 2007.11.21
				 //&& (salesMonTarget1.WeekdayRatio == salesMonTarget2.WeekdayRatio)
                 //&& ( salesMonTarget1.SatSunRatio == salesMonTarget2.SatSunRatio )
				 //----- ueno del---------- end   2007.11.21
				 );
        }
        #endregion ���@�]�ƈ��ʔ���ڕW�ݒ�}�X�^��r����(EmpSalesTarget,ResvdDT)

        #region ���@�]�ƈ��ʔ���ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����(EmpSalesTarget)
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����
        /// </summary>
        /// <param name="target">��r�Ώۂ�EmpSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 EmpSalesTarget�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public ArrayList Compare(EmpSalesTarget target)
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
            if (this.ApplyStaDate != target.ApplyStaDate) resList.Add("ApplyStaDate");
            if (this.ApplyEndDate != target.ApplyEndDate) resList.Add("ApplyEndDate");
			//----- ueno add---------- start 2007.11.21
			if (this.EmployeeDivCd != target.EmployeeDivCd) resList.Add("EmployeeDivCd");
			//----- ueno add---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if ( this.SubSectionCode != target.SubSectionCode ) resList.Add("SubSectionCode");
            if ( this.MinSectionCode != target.MinSectionCode ) resList.Add("MinSectionCode");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            if ( this.EmployeeCode != target.EmployeeCode ) resList.Add("EmployeeCode");
            if (this.EmployeeName != target.EmployeeName) resList.Add("EmployeeName");
            if (this.SalesTargetMoney != target.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (this.SalesTargetProfit != target.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (this.SalesTargetCount != target.SalesTargetCount) resList.Add("SalesTargetCount");
			//----- ueno del---------- start 2007.11.21
			//if (this.WeekdayRatio != target.WeekdayRatio) resList.Add("WeekdayRatio");
            //if ( this.SatSunRatio != target.SatSunRatio ) resList.Add("SatSunRatio");
			//----- ueno del---------- end   2007.11.21

            return resList;
        }
        #endregion ���@�]�ƈ��ʔ���ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����(EmpSalesTarget)

        #region ���@�]�ƈ��ʔ���ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����(EmpSalesTarget,EmpSalesTarget)
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="salesMonTarget1">��r����EmpSalesTarget�N���X�̃C���X�^���X</param>
        /// <param name="salesMonTarget2">��r����EmpSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 EmpSalesTarget�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public static ArrayList Compare(EmpSalesTarget salesMonTarget1, EmpSalesTarget salesMonTarget2)
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
            if (salesMonTarget1.ApplyStaDate != salesMonTarget2.ApplyStaDate) resList.Add("ApplyStaDate");
            if (salesMonTarget1.ApplyEndDate != salesMonTarget2.ApplyEndDate) resList.Add("ApplyEndDate");
			//----- ueno add---------- start 2007.11.21
			if (salesMonTarget1.EmployeeDivCd != salesMonTarget2.EmployeeDivCd) resList.Add("EmployeeDivCd");
			//----- ueno add---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if (salesMonTarget1.SubSectionCode != salesMonTarget2.SubSectionCode ) resList.Add("SubSectionCode");
            if (salesMonTarget1.MinSectionCode != salesMonTarget2.MinSectionCode ) resList.Add("MinSectionCode");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            if ( salesMonTarget1.EmployeeCode != salesMonTarget2.EmployeeCode ) resList.Add("EmployeeCode");
            if (salesMonTarget1.EmployeeName != salesMonTarget2.EmployeeName) resList.Add("EmployeeName");
            if (salesMonTarget1.SalesTargetMoney != salesMonTarget2.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (salesMonTarget1.SalesTargetProfit != salesMonTarget2.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (salesMonTarget1.SalesTargetCount != salesMonTarget2.SalesTargetCount) resList.Add("SalesTargetCount");
			//----- ueno del---------- start 2007.11.21
			//if (salesMonTarget1.WeekdayRatio != salesMonTarget2.WeekdayRatio) resList.Add("WeekdayRatio");
            //if ( salesMonTarget1.SatSunRatio != salesMonTarget2.SatSunRatio ) resList.Add("SatSunRatio");
			//----- ueno del---------- end   2007.11.21

            return resList;
        }
        #endregion ���@�]�ƈ��ʔ���ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����(EmpSalesTarget,EmpSalesTarget)

        #endregion Public Method

//----- ueno add---------- start 2007.11.21

		/// <summary>�]�ƈ��敪���X�g</summary>
		public static SortedList _employeeDivCdSList;

		/// <summary>
		/// �ÓI�R���X�g���N�^
		/// </summary>
		static EmpSalesTarget()
		{
			_employeeDivCdSList = MakeEmployeeDivCd();
		}

		/// <summary>
		/// �]�ƈ��敪���X�g����
		/// </summary>
		/// <returns>�]�ƈ��敪�̃��X�g</returns>
		/// <remarks>
		/// <br>Note	   : �]�ƈ��敪�̃��X�g�𐶐����܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private static SortedList MakeEmployeeDivCd()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(10, "�̔��S����");
			retSortedList.Add(20, "��t�S����");
			retSortedList.Add(30, "���͒S����");
			return retSortedList;
		}

		/// <summary>
		/// �]�ƈ��敪���̎擾����
		/// </summary>
		/// <param name="employeeDivCd">�]�ƈ��敪�R�[�h</param>
		/// <returns>�]�ƈ��敪����</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ��敪�R�[�h����]�ƈ��敪���̂��擾���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public static string GetEmployeeDivNm(int employeeDivCd)
		{
			string retStr = "";

			if (_employeeDivCdSList.ContainsKey((object)employeeDivCd))
			{
				retStr = _employeeDivCdSList[employeeDivCd].ToString();
			}
			return retStr;
		}
//----- ueno add---------- end   2007.11.21

    }
}

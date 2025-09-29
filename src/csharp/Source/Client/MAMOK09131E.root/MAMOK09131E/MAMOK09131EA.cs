using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:	 GcdSalesTarget
    /// <summary>
    /// 					 ���i�ʔ���ڕW�ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note			 :	 ���i�ʔ���ڕW�ݒ�}�X�^�t�@�C��</br>
    /// <br>Programmer		 :	 NEPCO</br>
    /// <br>Date			 :	 </br>
    /// <br>Genarated Date	 :	 2007.05.08  (CSharp File Generated Date)</br>
	/// <br>Update Note		 :   2007.11.21 ��� �O�M</br>
	/// <br>                     ����.DC�p�ɕύX�i���ڒǉ��E�폜�j</br>
    /// <br></br>
    /// </remarks>
    public class GcdSalesTarget
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

		//----- ueno del---------- start 2007.11.21
		///// <summary>�L�����A�R�[�h</summary>
		//private Int32 _carrierCode;

		///// <summary>�L�����A����</summary>
		//private string _carrierName = "";

		///// <summary>�@��R�[�h</summary>
		//private string _cellphoneModelCode = "";

		///// <summary>�@�햼��</summary>
		//private string _cellphoneModelName = "";
		//----- ueno del---------- end   2007.11.21

        /// <summary>���[�J�[�R�[�h</summary>
        private Int32 _makerCode;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i�R�[�h</summary>
        private string _goodsCode = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>����ڕW���z</summary>
        private Int64 _gcdSalesTargetMoney;

        /// <summary>����ڕW�e���z</summary>
        private Int64 _gcdSalesTargetProfit;

        /// <summary>����ڕW����</summary>
        private Double _gcdSalesTargetCount;

		//----- ueno del---------- start 2007.11.21
		///// <summary>�����䗦</summary>
		//private Double _weekdayRatio;

		///// <summary>�y���䗦</summary>
		//private Double _satSunRatio;
		//----- ueno del---------- end   2007.11.21

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
        // BL�O���[�v�R�[�h
        private Int32 _bLGroupCode;
        // BL�O���[�v��
        private string _bLGroupName;
        // BL�R�[�h
        private Int32 _bLGoodsCode;
        // BL�R�[�h��
        private string _bLCodeName;
        // �̔��敪
        private Int32 _salesCode;
        // �̔��敪��
        private string _salesCdNm;
        // ���i�敪
        private Int32 _enterpriseGanreCode;
        // ���i�敪��
        private string _enterpriseGanreName;

        // �Ǝ햼
        private string _businessTypeName;
        // �̔��G���A��
        private string _salesAreaName;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

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

		//----- ueno del---------- start 2007.11.21
		///// public propaty name  :	CarrierCode
		///// <summary>�L�����A�R�[�h�v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 �]�ƈ��R�[�h�v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Int32 CarrierCode
		//{
		//    get
		//    {
		//        return _carrierCode;
		//    }
		//    set
		//    {
		//        _carrierCode = value;
		//    }
		//}

		///// public propaty name  :	CarrierName
		///// <summary>�L�����A���̃v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 �L�����A���̃v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public string CarrierName
		//{
		//    get
		//    {
		//        return _carrierName;
		//    }
		//    set
		//    {
		//        _carrierName = value;
		//    }
		//}

		///// public propaty name  :	CellphoneModelCode
		///// <summary>�@��R�[�h�v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 �@��R�[�h�v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public string CellphoneModelCode
		//{
		//    get
		//    {
		//        return _cellphoneModelCode;
		//    }
		//    set
		//    {
		//        _cellphoneModelCode = value;
		//    }
		//}

		///// public propaty name  :	CellphoneModelName
		///// <summary>�@�햼�̃v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 �@�햼�̃v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public string CellphoneModelName
		//{
		//    get
		//    {
		//        return _cellphoneModelName;
		//    }
		//    set
		//    {
		//        _cellphoneModelName = value;
		//    }
		//}
		//----- ueno del---------- end   2007.11.21

        /// public propaty name  :	MakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get
            {
                return _makerCode;
            }
            set
            {
                _makerCode = value;
            }
        }

        /// public propaty name  :	MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string MakerName
        {
            get
            {
                return _makerName;
            }
            set
            {
                _makerName = value;
            }
        }

        /// public propaty name  :	GoodsCode
        /// <summary>���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ���i�R�[�h�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string GoodsCode
        {
            get
            {
                return _goodsCode;
            }
            set
            {
                _goodsCode = value;
            }
        }

        /// public propaty name  :	GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ���i���̃v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string GoodsName
        {
            get
            {
                return _goodsName;
            }
            set
            {
                _goodsName = value;
            }
        }

        /// public propaty name  :	GcdSalesTargetMoney
        /// <summary>����ڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	����ڕW���z�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int64 GcdSalesTargetMoney
        {
            get
            {
                return _gcdSalesTargetMoney;
            }
            set
            {
                _gcdSalesTargetMoney = value;
            }
        }

        /// public propaty name  :	GcdSalesTargetProfit
        /// <summary>����ڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ����ڕW�e���z�v���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int64 GcdSalesTargetProfit
        {
            get
            {
                return _gcdSalesTargetProfit;
            }
            set
            {
                _gcdSalesTargetProfit = value;
            }
        }

        /// public propaty name  :	GcdSalesTargetCount
        /// <summary>����ڕW���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 ����ڕW���ʃv���p�e�B</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Double GcdSalesTargetCount
        {
            get
            {
                return _gcdSalesTargetCount;
            }
            set
            {
                _gcdSalesTargetCount = value;
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { this._bLGroupCode = value; }
        }
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { this._bLGroupName = value; }
        }

        public Int32 BLCode
        {
            get { return _bLGoodsCode; }
            set { this._bLGoodsCode = value; }
        }

        public string BLCodeName
        {
            get { return _bLCodeName; }
            set { this._bLCodeName = value; }
        }

        public Int32 SalesTypeCode
        {
            get { return _salesCode; }
            set { this._salesCode = value; }
        }

        public string SalesTypeName
        {
            get { return _salesCdNm; }
            set { this._salesCdNm = value; }
        }

        public Int32 ItemTypeCode
        {
            get { return _enterpriseGanreCode; }
            set { this._enterpriseGanreCode = value; }
        }

        public string ItemTypeName
        {
            get { return _enterpriseGanreName; }
            set { this._enterpriseGanreName = value; }
        }

        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { this._businessTypeName = value; }
        }

        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { this._salesAreaName = value; }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

        #endregion Public Propaty

        #region �R���X�g���N�^
        /// <summary>
        /// ����ڕW�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>GcdSalesTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 GcdSalesTarget�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public GcdSalesTarget()
        {
        }

        /// <summary>
        /// ����ڕW�ݒ�}�X�^�R���X�g���N�^
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
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="goodsCode">���i�R�[�h</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="gcdSalesTargetMoney">����ڕW���z</param>
        /// <param name="gcdSalesTargetProfit">����ڕW�e���z</param>
        /// <param name="gcdSalesTargetCount">����ڕW����</param>
        /// <returns>GcdSalesTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 GcdSalesTarget�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public GcdSalesTarget(
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
			//----- ueno del---------- start 2007.11.21
            //Int32 carrierCode,
            //string carrierName,
            //string cellphoneModelCode,
            //string cellphoneModelName,
			//----- ueno del---------- end   2007.11.21
            Int32 makerCode,
            string makerName,
            string goodsCode,
            string goodsName,
            Int64 gcdSalesTargetMoney,
            Int64 gcdSalesTargetProfit,
            Double gcdSalesTargetCount,
			//----- ueno del---------- start 2007.11.21
			//Double weekdayRatio,
            //Double satSunRatio
			//----- ueno del---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            Int32 blGroupCode,
            string blGroupName,
            Int32 blCode,
            string blCodeName,
            Int32 salesTypeCode,
            string salesTypeName,
            Int32 itemTypeCode,
            string itemTypeName,
            string businessTypeName,
            string salesAreaName
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
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
			//----- ueno del---------- start 2007.11.21
			//this._carrierCode = carrierCode;
            //this._carrierName = carrierName;
            //this._cellphoneModelCode = cellphoneModelCode;
            //this._cellphoneModelName = cellphoneModelName;
			//----- ueno del---------- end   2007.11.21
            this._makerCode = makerCode;
            this._makerName = makerName;
            this._goodsCode = goodsCode;
            this._goodsName = goodsName;
            this._gcdSalesTargetMoney = gcdSalesTargetMoney;
            this._gcdSalesTargetProfit = gcdSalesTargetProfit;
            this._gcdSalesTargetCount = gcdSalesTargetCount;
			//----- ueno del---------- start 2007.11.21
			//this._weekdayRatio = weekdayRatio;
            //this._satSunRatio = satSunRatio;
			//----- ueno del---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            this._bLGroupCode = blGroupCode;
            this._bLGroupName = blGroupName;
            this._bLGoodsCode = blCode;
            this._bLCodeName = blCodeName;
            this._salesCode = salesTypeCode;
            this._salesCdNm = salesTypeName;
            this._enterpriseGanreCode = itemTypeCode;
            this._enterpriseGanreName = itemTypeName;
            this._businessTypeName = businessTypeName;
            this._salesAreaName = salesAreaName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
		}

        #endregion �R���X�g���N�^

        #region Public Method
        #region ���@����ڕW�ݒ�}�X�^��������
        /// <summary>
        /// ����ڕW�ݒ�}�X�^��������
        /// </summary>
        /// <returns>GcdSalesTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 ���g�̓��e�Ɠ�����GcdSalesTarget�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public GcdSalesTarget Clone()
        {
            return new GcdSalesTarget(this._createDateTime,
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
							   //----- ueno del---------- start 2007.11.21
							   //this._carrierCode,
                               //this._carrierName,
                               //this._cellphoneModelCode,
                               //this._cellphoneModelName,
							   //----- ueno del---------- end   2007.11.21
                               this._makerCode,
                               this._makerName,
                               this._goodsCode,
                               this._goodsName,
                               this._gcdSalesTargetMoney,
                               this._gcdSalesTargetProfit,
                               this._gcdSalesTargetCount,
							   //----- ueno del---------- start 2007.11.21
							   //this._weekdayRatio,
                               //this._satSunRatio
							   //----- ueno del---------- end   2007.11.21
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
                               this._bLGroupCode,
                               this._bLGroupName,
                               this._bLGoodsCode,
                               this._bLCodeName,
                               this._salesCode,
                               this._salesCdNm,
                               this._enterpriseGanreCode,
                               this._enterpriseGanreName,
                               this._businessTypeName,
                               this._salesAreaName
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
							   );
        }
        #endregion ���@����ڕW�ݒ�}�X�^��������

        #region ���@����ڕW�ݒ�}�X�^��r����(GcdSalesTarget)
        /// <summary>
        /// ����ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�GcdSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 GcdSalesTarget�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public bool Equals(GcdSalesTarget target)
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
				 //----- ueno del---------- start 2007.11.21
				 //&& (this.CarrierCode == target.CarrierCode)
                 //&& (this.CarrierName == target.CarrierName)
                 //&& (this.CellphoneModelCode == target.CellphoneModelCode)
                 //&& (this.CellphoneModelName == target.CellphoneModelName)
				 //----- ueno del---------- end   2007.11.21
                 && (this.MakerCode == target.MakerCode)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsCode == target.GoodsCode)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GcdSalesTargetMoney == target.GcdSalesTargetMoney)
                 && (this.GcdSalesTargetProfit == target.GcdSalesTargetProfit)
                 && (this.GcdSalesTargetCount == target.GcdSalesTargetCount)
				 //----- ueno del---------- start 2007.11.21
				 //&& (this.WeekdayRatio == target.WeekdayRatio)
                 //&& (this.SatSunRatio == target.SatSunRatio)
				 //----- ueno del---------- end   2007.11.21
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGroupName == target.BLGroupName)
                 && (this.BLCode == target.BLCode)
                 && (this.BLCodeName == target.BLCodeName)
                 && (this.SalesTypeCode == target.SalesTypeCode)
                 && (this.SalesTypeName == target.SalesTypeName)
                 && (this.ItemTypeCode == target.ItemTypeCode)
                 && (this.ItemTypeName == target.ItemTypeName)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.SalesAreaName == target.SalesAreaName)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
				 );
        }
        #endregion ���@����ڕW�ݒ�}�X�^��r����

        #region ���@����ڕW�ݒ�}�X�^��r����(GcdSalesTarget,ResvdDT)
        /// <summary>
        /// ����ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="salesMonTarget1">
        /// 				   ��r����GcdSalesTarget�N���X�̃C���X�^���X
        /// </param>
        /// <param name="salesMonTarget2">��r����GcdSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 GcdSalesTarget�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public static bool Equals(GcdSalesTarget salesMonTarget1, GcdSalesTarget salesMonTarget2)
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
				 //----- ueno del---------- start 2007.11.21
				 //&& (salesMonTarget1.CarrierCode == salesMonTarget2.CarrierCode)
                 //&& (salesMonTarget1.CarrierName == salesMonTarget2.CarrierName)
                 //&& (salesMonTarget1.CellphoneModelCode == salesMonTarget2.CellphoneModelCode)
                 //&& (salesMonTarget1.CellphoneModelName == salesMonTarget2.CellphoneModelName)
				 //----- ueno del---------- start 2007.11.21
                 && (salesMonTarget1.MakerCode == salesMonTarget2.MakerCode)
                 && (salesMonTarget1.MakerName == salesMonTarget2.MakerName)
                 && (salesMonTarget1.GoodsCode == salesMonTarget2.GoodsCode)
                 && (salesMonTarget1.GoodsName == salesMonTarget2.GoodsName)
                 && (salesMonTarget1.GcdSalesTargetMoney == salesMonTarget2.GcdSalesTargetMoney)
                 && (salesMonTarget1.GcdSalesTargetProfit == salesMonTarget2.GcdSalesTargetProfit)
                 && (salesMonTarget1.GcdSalesTargetCount == salesMonTarget2.GcdSalesTargetCount)
				 //----- ueno del---------- start 2007.11.21
				 //&& (salesMonTarget1.WeekdayRatio == salesMonTarget2.WeekdayRatio)
                 //&& (salesMonTarget1.SatSunRatio == salesMonTarget2.SatSunRatio)
				 //----- ueno del---------- end   2007.11.21
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
                 && (salesMonTarget1.BLGroupCode == salesMonTarget2.BLGroupCode)
                 && (salesMonTarget1.BLGroupName == salesMonTarget2.BLGroupName)
                 && (salesMonTarget1.BLCode == salesMonTarget2.BLCode)
                 && (salesMonTarget1.BLCodeName == salesMonTarget2.BLCodeName)
                 && (salesMonTarget1.SalesTypeCode == salesMonTarget2.SalesTypeCode)
                 && (salesMonTarget1.SalesTypeName == salesMonTarget2.SalesTypeName)
                 && (salesMonTarget1.ItemTypeCode == salesMonTarget2.ItemTypeCode)
                 && (salesMonTarget1.ItemTypeName == salesMonTarget2.ItemTypeName)
                 && (salesMonTarget1.BusinessTypeName == salesMonTarget2.BusinessTypeName)
                 && (salesMonTarget1.SalesAreaName == salesMonTarget2.SalesAreaName)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
				 );
        }
        #endregion ���@����ڕW�ݒ�}�X�^��r����(GcdSalesTarget,ResvdDT)

        #region ���@����ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����(GcdSalesTarget)
        /// <summary>
        /// ����ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����
        /// </summary>
        /// <param name="target">��r�Ώۂ�GcdSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 GcdSalesTarget�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public ArrayList Compare(GcdSalesTarget target)
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
			//----- ueno del---------- start 2007.11.21
			//if (this.CarrierCode != target.CarrierCode) resList.Add("CarrierCode");
            //if (this.CarrierName != target.CarrierName) resList.Add("CarrierName");
            //if (this.CellphoneModelCode != target.CellphoneModelCode) resList.Add("CellphoneModelCode");
            //if (this.CellphoneModelName != target.CellphoneModelName) resList.Add("CellphoneModelName");
			//----- ueno del---------- end   2007.11.21           
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsCode != target.GoodsCode) resList.Add("GoodsCode");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GcdSalesTargetMoney != target.GcdSalesTargetMoney) resList.Add("GcdSalesTargetMoney");
            if (this.GcdSalesTargetProfit != target.GcdSalesTargetProfit) resList.Add("GcdSalesTargetProfit");
            if (this.GcdSalesTargetCount != target.GcdSalesTargetCount) resList.Add("GcdSalesTargetCount");
			//----- ueno del---------- start 2007.11.21
			//if (this.WeekdayRatio != target.WeekdayRatio) resList.Add("WeekdayRatio");
            //if (this.SatSunRatio != target.SatSunRatio) resList.Add("SatSunRatio");
			//----- ueno del---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGroupName != target.BLGroupName) resList.Add("BLGroupName");
            if (this.BLCode != target.BLCode) resList.Add("BLCode");
            if (this.BLCodeName != target.BLCodeName) resList.Add("BLCodeName");
            if (this.SalesTypeCode != target.SalesTypeCode) resList.Add("SalesTypeCode");
            if (this.SalesTypeName != target.SalesTypeName) resList.Add("SalesTypeName");
            if (this.ItemTypeCode != target.ItemTypeCode) resList.Add("ItemTypeCode");
            if (this.ItemTypeName != target.ItemTypeName) resList.Add("ItemTypeName");
            if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");
            if (this.SalesAreaName != target.SalesAreaName) resList.Add("SalesAreaName");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

            return resList;
        }
        #endregion ���@����ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����(GcdSalesTarget)

        #region ���@����ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����(GcdSalesTarget,GcdSalesTarget)
        /// <summary>
        /// ����ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="salesMonTarget1">��r����GcdSalesTarget�N���X�̃C���X�^���X</param>
        /// <param name="salesMonTarget2">��r����GcdSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :	 GcdSalesTarget�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public static ArrayList Compare(GcdSalesTarget salesMonTarget1, GcdSalesTarget salesMonTarget2)
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
			//----- ueno del---------- start 2007.11.21
			//if (salesMonTarget1.CarrierCode != salesMonTarget2.CarrierCode) resList.Add("CarrierCode");
			//if (salesMonTarget1.CarrierName != salesMonTarget2.CarrierName) resList.Add("CarrierName");
			//if (salesMonTarget1.CellphoneModelCode != salesMonTarget2.CellphoneModelCode) resList.Add("CellphoneModelCode");
			//if (salesMonTarget1.CellphoneModelName != salesMonTarget2.CellphoneModelName) resList.Add("CellphoneModelName");
			//----- ueno del---------- end   2007.11.21           
            if (salesMonTarget1.MakerCode != salesMonTarget2.MakerCode) resList.Add("MakerCode");
            if (salesMonTarget1.MakerName != salesMonTarget2.MakerName) resList.Add("MakerName");
            if (salesMonTarget1.GoodsCode != salesMonTarget2.GoodsCode) resList.Add("GoodsCode");
            if (salesMonTarget1.GoodsName != salesMonTarget2.GoodsName) resList.Add("GoodsName");
            if (salesMonTarget1.GcdSalesTargetMoney != salesMonTarget2.GcdSalesTargetMoney) resList.Add("GcdSalesTargetMoney");
            if (salesMonTarget1.GcdSalesTargetProfit != salesMonTarget2.GcdSalesTargetProfit) resList.Add("GcdSalesTargetProfit");
            if (salesMonTarget1.GcdSalesTargetCount != salesMonTarget2.GcdSalesTargetCount) resList.Add("GcdSalesTargetCount");
			//----- ueno del---------- start 2007.11.21
			//if (salesMonTarget1.WeekdayRatio != salesMonTarget2.WeekdayRatio) resList.Add("WeekdayRatio");
            //if (salesMonTarget1.SatSunRatio != salesMonTarget2.SatSunRatio) resList.Add("SatSunRatio");
			//----- ueno del---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            if (salesMonTarget1.BLGroupCode != salesMonTarget2.BLGroupCode) resList.Add("BLGroupCode");
            if (salesMonTarget1.BLGroupName != salesMonTarget2.BLGroupName) resList.Add("BLGroupName");
            if (salesMonTarget1.BLCode != salesMonTarget2.BLCode) resList.Add("BLCode");
            if (salesMonTarget1.BLCodeName != salesMonTarget2.BLCodeName) resList.Add("BLCodeName");
            if (salesMonTarget1.SalesTypeCode != salesMonTarget2.SalesTypeCode) resList.Add("SalesTypeCode");
            if (salesMonTarget1.SalesTypeName != salesMonTarget2.SalesTypeName) resList.Add("SalesTypeName");
            if (salesMonTarget1.ItemTypeCode != salesMonTarget2.ItemTypeCode) resList.Add("ItemTypeCode");
            if (salesMonTarget1.ItemTypeName != salesMonTarget2.ItemTypeName) resList.Add("ItemTypeName");
            if (salesMonTarget1.BusinessTypeName != salesMonTarget2.BusinessTypeName) resList.Add("BusinessTypeName");
            if (salesMonTarget1.SalesAreaName != salesMonTarget2.SalesAreaName) resList.Add("SalesAreaName");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

            return resList;
        }
        #endregion ���@����ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����(GcdSalesTarget,GcdSalesTarget)

        #endregion Public Method
    }
}

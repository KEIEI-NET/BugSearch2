using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:	 SalesTarget
	/// <summary>
	/// 					 ����ڕW�ݒ�}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note			 :	 ����ڕW�ݒ�}�X�^�t�@�C��</br>
	/// <br>Programmer		 :	 NEPCO</br>
	/// <br>Date			 :	 </br>
	/// <br>Genarated Date	 :	 2007/05/08</br>
	/// <br>Update Note		 :   2007.11.21 ��� �O�M</br>
	/// <br>                     ����.DC�p�ɕύX�i���ڒǉ��E�폜�j</br>
	/// <br></br>
	/// </remarks>
	public class SalesTarget
    {
        #region Public Enum

        /// <summary>�ڕW�Δ�敪</summary>
        public enum ConstrastCd
        {
//----- ueno upd---------- start 2007.11.21
			Section					= 10,	// ���_
			SecAndSubSec			= 20,	// ���_�{����
			//SecAndSubSecAndMinSec	= 21,	// ���_�{����{��
			SecAndEmp				= 22,	// ���_�{�]�ƈ�
			SecAndCust				= 30,	// ���_�{���Ӑ�
			SecAndBusinessType		= 31,	// ���_�{�Ǝ�
			SecAndSalesArea			= 32,	// ���_�{�̔��G���A
			SecAndMaker				= 40,	// ���_�{���[�J�[
			SecAndMakerAndGoods		= 41,	// ���_�{���[�J�[�{���i
            SecAndBLGroup           = 42,   // ���_�{BL�O���[�v
            SecAndBlCode            = 43,   // ���_�{BL�R�[�h
            SecAndSalesType         = 44,   // ���_�{�̔��敪
            SecAndItemType          = 45    // ���_�{���i�敪
//----- ueno upd---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//SalesFormal = 81,
            //SalesForm = 82
			//----- ueno del---------- end   2007.11.21
		}

        #endregion Public Enum

        #region Public Const

        /// <summary>����ڕW�ݒ�}�X�^�Z�b�g��</summary>
		public const string CT_CsSalesTargetDataTable = "CsSalesTargetDataTable";
		/// <summary>����ڕW�o�b�t�@�f�[�^�e�[�u����</summary>
		public const string CT_CsSalesTargetBuffDataTable = "CsSalesTargetBuffDataTable";

        //--------------------------------------------------------
        // ����`��
        //--------------------------------------------------------
		//----- ueno del---------- start 2007.11.21
		//public static string SALESFORMAL_COUNTER_SALES = "�X������";
		//public static string SALESFORMAL_OUTSIDE_SALES = "�O��";
		//public static string SALESFORMAL_BUSINESS_SALES = "�Ɩ��̔�";
		//public static string SALESFORMAL_OTHERS_SALES = "���̑�";
		//----- ueno del---------- end   2007.11.21

		#endregion Public Const

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

		/// <summary>�]�ƈ��R�[�h</summary>
		private string _employeeCode = "";

		/// <summary>�]�ƈ�����</summary>
		private string _employeeName = "";

//----- ueno add---------- start 2007.11.21
		/// <summary>�]�ƈ��敪</summary>
		private Int32 _employeeDivCd;

		/// <summary>����R�[�h</summary>
		private Int32 _subSectionCode;

		/// <summary>�ۃR�[�h</summary>
		private Int32 _minSectionCode;

		/// <summary>�Ǝ�R�[�h</summary>
		private Int32 _businessTypeCode;

		/// <summary>�̔��G���A�R�[�h</summary>
		private Int32 _salesAreaCode;

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;
//----- ueno add---------- end   2007.11.21

		//----- ueno del---------- start 2007.11.21
		///// <summary>����`��</summary>
		//private Int32 _salesFormal;

		///// <summary>�̔��`�ԃR�[�h</summary>
		//private Int32 _salesFormCode;

		///// <summary>�̔��`�Ԗ���</summary>
		//private string _salesFormName = "";

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

		/// public propaty name  :	SubSectionCode
		/// <summary>����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 ����R�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �ۃR�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
//----- ueno add---------- end   2007.11.21

		//----- ueno del---------- start 2007.11.21
		#region del
		///// public propaty name  :	SalesFormal
		///// <summary>����`���v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 ����`���v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public int SalesFormal
		//{
		//    get
		//    {
		//        return _salesFormal;
		//    }
		//    set
		//    {
		//        _salesFormal = value;
		//    }
		//}

		/// public propaty name  :	SalesFormCode
		///// <summary>�̔��`�ԃR�[�h�v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 �̔��`�ԃR�[�h�v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public int SalesFormCode
		//{
		//    get
		//    {
		//        return _salesFormCode;
		//    }
		//    set
		//    {
		//        _salesFormCode = value;
		//    }

		//}

		/// public propaty name  :	SalesFormName
		///// <summary>�̔��`�Ԗ��̃v���p�e�B</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 �̔��`�Ԗ��̃v���p�e�B</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public string SalesFormName
		//{
		//    get
		//    {
		//        return _salesFormName;
		//    }
		//    set
		//    {
		//        _salesFormName = value;
		//    }
		//}

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

		/// public propaty name  :	CarrierName
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
		#endregion del
		//----- ueno del---------- end   2007.11.21

		/// public propaty name  :	MakerCode
		/// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 ���[�J�[�R�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public int MakerCode
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
		#region del
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
		#endregion del
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
		/// <returns>SalesTarget�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :	 SalesTarget�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public SalesTarget()
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
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <param name="employeeName">�]�ƈ�����</param>
		/// <param name="employeeDivCd">�]�ƈ��敪</param>
		/// <param name="subSectionCode">����R�[�h</param>
		/// <param name="minSectionCode">�ۃR�[�h</param>
		/// <param name="businessTypeCode">�Ǝ�R�[�h</param>
		/// <param name="salesAreaCode">�̔��G���A�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="makerCode">���[�J�[�R�[�h</param>
		/// <param name="makerName">���[�J�[����</param>
		/// <param name="goodsCode">���i�R�[�h</param>
		/// <param name="goodsName">���i����</param>
		/// <param name="salesTargetMoney">����ڕW���z</param>
		/// <param name="salesTargetProfit">����ڕW�e���z</param>
		/// <param name="salesTargetCount">����ڕW����</param>
		/// <returns>SalesTarget�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :	 SalesTarget�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public SalesTarget(
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
			string employeeCode,
			string employeeName,
//----- ueno add---------- start 2007.11.21
			Int32 employeeDivCd,
			Int32 subSectionCode,
			Int32 minSectionCode,
			Int32 businessTypeCode,
			Int32 salesAreaCode,
			Int32 customerCode,
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//int salesFormal,
			//int salesFormCode,
			//string salesFormName,
			//Int32 carrierCode,
			//string carrierName,
			//string cellphoneModelCode,
			//string cellphoneModelName,
			//----- ueno del---------- end   2007.11.21
			int makerCode,
			string makerName,
			string goodsCode,
			string goodsName,
			Int64 salesTargetMoney,
			Int64 salesTargetProfit,
			Double salesTargetCount,
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
			this.CreateDateTime 	= createDateTime;
			this.UpdateDateTime 	= updateDateTime;
			this._enterpriseCode	= enterpriseCode;
			this._fileHeaderGuid	= fileHeaderGuid;
			this._updEmployeeCode	= updEmployeeCode;
			this._updAssemblyId1	= updAssemblyId1;
			this._updAssemblyId2	= updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._sectionCode		= sectionCode;
			this._targetSetCd		= targetSetCd;
			this._targetContrastCd	= targetContrastCd;
			this._targetDivideCode	= targetDivideCode;
			this._targetDivideName	= targetDivideName;
			this._applyStaDate		= applyStaDate;
			this._applyEndDate		= applyEndDate;
			this._employeeCode		= employeeCode;
			this._employeeName		= employeeName;
//----- ueno add---------- start 2007.11.21
			this._employeeDivCd = employeeDivCd;
			this._subSectionCode = subSectionCode;
			this._minSectionCode = minSectionCode;
			this._businessTypeCode = businessTypeCode;
			this._salesAreaCode = salesAreaCode;
			this._customerCode = customerCode;
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//this._salesFormal = salesFormal;
			//this._salesFormCode 	= salesFormCode;
			//this._salesFormName 	= salesFormName;
			//this._carrierCode		= carrierCode;
			//this._carrierName		= carrierName;
			//this._cellphoneModelCode = cellphoneModelCode;
			//this._cellphoneModelName = cellphoneModelName;
			//----- ueno del---------- end   2007.11.21
			this._makerCode 		= makerCode;
			this._makerName 		= makerName;
			this._goodsCode 		= goodsCode;
			this._goodsName 		= goodsName;
			this._salesTargetMoney	= salesTargetMoney;
			this._salesTargetProfit = salesTargetProfit;
			this._salesTargetCount	= salesTargetCount;
			//----- ueno del---------- start 2007.11.21
			//this._weekdayRatio = weekdayRatio;
			//this._satSunRatio		= satSunRatio;
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

		/// <summary>
		/// ����ڕW�ݒ�}�X�^��������
		/// </summary>
		/// <returns>SalesTarget�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :	 ���g�̓��e�Ɠ�����SalesTarget�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public SalesTarget Clone()
		{
			return new SalesTarget(this._createDateTime,
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
							   this._employeeCode,
							   this._employeeName,
//----- ueno add---------- start 2007.11.21
							   this._employeeDivCd,
							   this._subSectionCode,
							   this._minSectionCode,
							   this._businessTypeCode,
							   this._salesAreaCode,
							   this._customerCode,
//----- ueno add---------- end   2007.11.21
							   //----- ueno del---------- start 2007.11.21
							   //this._salesFormal,
							   //this._salesFormCode,
							   //this._salesFormName,
							   //this._carrierCode,
							   //this._carrierName,
							   //this._cellphoneModelCode,
							   //this._cellphoneModelName,
							   //----- ueno del---------- end   2007.11.21
							   this._makerCode,
							   this._makerName,
							   this._goodsCode,
							   this._goodsName,
							   this._salesTargetMoney,
							   this._salesTargetProfit,
							   this._salesTargetCount,
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

        /// <summary>
		/// ����ڕW�ݒ�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SalesTarget�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :	 SalesTarget�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public bool Equals(SalesTarget target)
		{
			return ((this.CreateDateTime	== target.CreateDateTime)
				 && (this.UpdateDateTime	== target.UpdateDateTime)
				 && (this.EnterpriseCode	== target.EnterpriseCode)
				 && (this.FileHeaderGuid	== target.FileHeaderGuid)
				 && (this.UpdEmployeeCode	== target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1	== target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2	== target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SectionCode		== target.SectionCode)
				 && (this.TargetSetCd		== target.TargetSetCd)
				 && (this.TargetContrastCd	== target.TargetContrastCd)
				 && (this.TargetDivideCode	== target.TargetDivideCode)
				 && (this.TargetDivideName	== target.TargetDivideName)
				 && (this.ApplyStaDate		== target.ApplyStaDate)
				 && (this.ApplyEndDate		== target.ApplyEndDate)
				 && (this.EmployeeCode		== target.EmployeeCode)
				 && (this.EmployeeName		== target.EmployeeName)
//----- ueno add---------- start 2007.11.21
				 && (this.EmployeeDivCd == target.EmployeeDivCd)
				 && (this.SubSectionCode == target.SubSectionCode)
				 && (this.MinSectionCode == target.MinSectionCode)
				 && (this.BusinessTypeCode == target.BusinessTypeCode)
				 && (this.SalesAreaCode == target.SalesAreaCode)
				 && (this.CustomerCode == target.CustomerCode)
//----- ueno add---------- end   2007.11.21
				 //----- ueno del---------- start 2007.11.21
				 //&& (this.SalesFormal == target.SalesFormal)
				 //&& (this.SalesFormCode == target.SalesFormCode)
				 //&& (this.SalesFormName 	== target.SalesFormName)
				 //&& (this.CarrierCode		== target.CarrierCode)
				 //&& (this.CarrierName		== target.CarrierName)
				 //&& (this.CellphoneModelCode == target.CellphoneModelCode)
				 //&& (this.CellphoneModelName == target.CellphoneModelName)
				 //----- ueno del---------- end   2007.11.21
				 && (this.MakerCode 		== target.MakerCode)
				 && (this.MakerName 		== target.MakerName)
				 && (this.GoodsCode 		== target.GoodsCode)
				 && (this.GoodsName 		== target.GoodsName)
				 && (this.SalesTargetMoney	== target.SalesTargetMoney)
				 && (this.SalesTargetProfit == target.SalesTargetProfit)
				 && (this.SalesTargetCount	== target.SalesTargetCount)
				 //----- ueno del---------- start 2007.11.21
				 //&& (this.WeekdayRatio == target.WeekdayRatio)
				 //&& (this.SatSunRatio		== target.SatSunRatio)
				 //----- ueno del---------- end   2007.11.21
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
                 && (this.BLGroupCode   == target.BLGroupCode)
                 && (this.BLGroupName   == target.BLGroupName)
                 && (this.BLCode        == target.BLCode)
                 && (this.BLCodeName    == target.BLCodeName)
                 && (this.SalesTypeCode == target.SalesTypeCode)
                 && (this.SalesTypeName == target.SalesTypeName)
                 && (this.ItemTypeCode  == target.ItemTypeCode)
                 && (this.ItemTypeName  == target.ItemTypeName)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.SalesAreaName == target.SalesAreaName)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
				 );
		}

        /// <summary>
		/// ����ڕW�ݒ�}�X�^��r����
		/// </summary>
		/// <param name="salesMonTarget1">��r����SalesTarget�N���X�̃C���X�^���X</param>
		/// <param name="salesMonTarget2">��r����SalesTarget�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :	 SalesTarget�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public static bool Equals(SalesTarget salesMonTarget1, SalesTarget salesMonTarget2)
		{
			return ((salesMonTarget1.CreateDateTime    == salesMonTarget2.CreateDateTime)
				 && (salesMonTarget1.UpdateDateTime    == salesMonTarget2.UpdateDateTime)
				 && (salesMonTarget1.EnterpriseCode    == salesMonTarget2.EnterpriseCode)
				 && (salesMonTarget1.FileHeaderGuid    == salesMonTarget2.FileHeaderGuid)
				 && (salesMonTarget1.UpdEmployeeCode   == salesMonTarget2.UpdEmployeeCode)
				 && (salesMonTarget1.UpdAssemblyId1    == salesMonTarget2.UpdAssemblyId1)
				 && (salesMonTarget1.UpdAssemblyId2    == salesMonTarget2.UpdAssemblyId2)
				 && (salesMonTarget1.LogicalDeleteCode == salesMonTarget2.LogicalDeleteCode)
				 && (salesMonTarget1.SectionCode	   == salesMonTarget2.SectionCode)
				 && (salesMonTarget1.TargetSetCd	   == salesMonTarget2.TargetSetCd)
				 && (salesMonTarget1.TargetContrastCd  == salesMonTarget2.TargetContrastCd)
				 && (salesMonTarget1.TargetDivideCode  == salesMonTarget2.TargetDivideCode)
				 && (salesMonTarget1.TargetDivideName  == salesMonTarget2.TargetDivideName)
				 && (salesMonTarget1.ApplyStaDate	   == salesMonTarget2.ApplyStaDate)
				 && (salesMonTarget1.ApplyEndDate	   == salesMonTarget2.ApplyEndDate)
				 && (salesMonTarget1.EmployeeCode	   == salesMonTarget2.EmployeeCode)
				 && (salesMonTarget1.EmployeeName	   == salesMonTarget2.EmployeeName)
//----- ueno add---------- start 2007.11.21
				 && (salesMonTarget1.EmployeeDivCd	   == salesMonTarget2.EmployeeDivCd)
				 && (salesMonTarget1.SubSectionCode    == salesMonTarget2.SubSectionCode)
				 && (salesMonTarget1.MinSectionCode    == salesMonTarget2.MinSectionCode)
				 && (salesMonTarget1.BusinessTypeCode  == salesMonTarget2.BusinessTypeCode)
				 && (salesMonTarget1.SalesAreaCode     == salesMonTarget2.SalesAreaCode)
				 && (salesMonTarget1.CustomerCode      == salesMonTarget2.CustomerCode)
//----- ueno add---------- end   2007.11.21
				 //----- ueno del---------- start 2007.11.21
				 //&& (salesMonTarget1.SalesFormal == salesMonTarget2.SalesFormal)
				 //&& (salesMonTarget1.SalesFormCode	   == salesMonTarget2.SalesFormCode)
				 //&& (salesMonTarget1.SalesFormName	   == salesMonTarget2.SalesFormName)
				 //&& (salesMonTarget1.CarrierCode	   == salesMonTarget2.CarrierCode)
				 //&& (salesMonTarget1.CarrierName	   == salesMonTarget2.CarrierName)
				 //&& (salesMonTarget1.CellphoneModelCode == salesMonTarget2.CellphoneModelCode)
				 //&& (salesMonTarget1.CellphoneModelName == salesMonTarget2.CellphoneModelName)
				 //----- ueno del---------- end   2007.11.21
				 && (salesMonTarget1.MakerCode == salesMonTarget2.MakerCode)
				 && (salesMonTarget1.MakerName		   == salesMonTarget2.MakerName)
				 && (salesMonTarget1.GoodsCode		   == salesMonTarget2.GoodsCode)
				 && (salesMonTarget1.GoodsName		   == salesMonTarget2.GoodsName)
				 && (salesMonTarget1.SalesTargetMoney  == salesMonTarget2.SalesTargetMoney)
				 && (salesMonTarget1.SalesTargetProfit == salesMonTarget2.SalesTargetProfit)
				 && (salesMonTarget1.SalesTargetCount  == salesMonTarget2.SalesTargetCount)
				 //----- ueno del---------- start 2007.11.21
				 //&& (salesMonTarget1.WeekdayRatio == salesMonTarget2.WeekdayRatio)
				 //&& (salesMonTarget1.SatSunRatio	   == salesMonTarget2.SatSunRatio)
				 //----- ueno del---------- end   2007.11.21
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
                 && (salesMonTarget1.BLGroupCode    == salesMonTarget2.BLGroupCode)
                 && (salesMonTarget1.BLGroupName    == salesMonTarget2.BLGroupName)
                 && (salesMonTarget1.BLCode         == salesMonTarget2.BLCode)
                 && (salesMonTarget1.BLCodeName     == salesMonTarget2.BLCodeName)
                 && (salesMonTarget1.SalesTypeCode  == salesMonTarget2.SalesTypeCode)
                 && (salesMonTarget1.SalesTypeName  == salesMonTarget2.SalesTypeName)
                 && (salesMonTarget1.ItemTypeCode   == salesMonTarget2.ItemTypeCode)
                 && (salesMonTarget1.ItemTypeName   == salesMonTarget2.ItemTypeName)
                 && (salesMonTarget1.BusinessTypeName == salesMonTarget2.BusinessTypeName)
                 && (salesMonTarget1.SalesAreaName == salesMonTarget2.SalesAreaName)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
				 );
		}

        /// <summary>
		/// ����ڕW�ݒ�}�X�^��r���ʃ��X�g�쐬����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SalesTarget�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :	 SalesTarget�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public ArrayList Compare(SalesTarget target)
		{
			ArrayList resList = new ArrayList();
			if (this.CreateDateTime    != target.CreateDateTime)	resList.Add("CreateDateTime");
			if (this.UpdateDateTime    != target.UpdateDateTime)	resList.Add("UpdateDateTime");
			if (this.EnterpriseCode    != target.EnterpriseCode)	resList.Add("EnterpriseCode");
			if (this.FileHeaderGuid    != target.FileHeaderGuid)	resList.Add("FileHeaderGuid");
			if (this.UpdEmployeeCode   != target.UpdEmployeeCode)	resList.Add("UpdEmployeeCode");
			if (this.UpdAssemblyId1    != target.UpdAssemblyId1)	resList.Add("UpdAssemblyId1");
			if (this.UpdAssemblyId2    != target.UpdAssemblyId2)	resList.Add("UpdAssemblyId2");
			if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (this.SectionCode	   != target.SectionCode)		resList.Add("SectionCode");
			if (this.TargetSetCd	   != target.TargetSetCd)		resList.Add("TargetSetCd");
			if (this.TargetContrastCd  != target.TargetContrastCd)	resList.Add("TargetContrastCd");
			if (this.TargetDivideCode  != target.TargetDivideCode)	resList.Add("TargetDivideCode");
			if (this.TargetDivideName  != target.TargetDivideName)	resList.Add("TargetDivideName");
			if (this.ApplyStaDate	   != target.ApplyStaDate)		resList.Add("ApplyStaDate");
			if (this.ApplyEndDate	   != target.ApplyEndDate)		resList.Add("ApplyEndDate");
			if (this.EmployeeCode	   != target.EmployeeCode)		resList.Add("EmployeeCode");
			if (this.EmployeeName	   != target.EmployeeName)		resList.Add("Name");
//----- ueno add---------- start 2007.11.21
			if (this.EmployeeDivCd     != target.EmployeeDivCd)     resList.Add("EmployeeDivCd");
			if (this.SubSectionCode    != target.SubSectionCode)    resList.Add("SubSectionCode");
			if (this.MinSectionCode    != target.MinSectionCode)    resList.Add("MinSectionCode");
			if (this.BusinessTypeCode  != target.BusinessTypeCode)  resList.Add("BusinessTypeCode");
			if (this.SalesAreaCode     != target.SalesAreaCode)     resList.Add("SalesAreaCode");
			if (this.CustomerCode      != target.CustomerCode)      resList.Add("CustomerCode");
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//if (this.SalesFormal != target.SalesFormal) resList.Add("SalesFormal");
			//if (this.SalesFormCode	   != target.SalesFormCode) 	resList.Add("SalesFormCode");
			//if (this.SalesFormName	   != target.SalesFormName) 	resList.Add("SalesFormName");
			//if (this.CarrierCode	   != target.CarrierCode)		resList.Add("CarrierCode");
			//if (this.CarrierName	   != target.CarrierName)		resList.Add("CarrierName");
			//if (this.CellphoneModelCode != target.CellphoneModelCode) resList.Add("CellphoneModelCode");
			//if (this.CellphoneModelName != target.CellphoneModelName) resList.Add("CellphoneModelName");
			//----- ueno del---------- end   2007.11.21
			if (this.MakerCode		   != target.MakerCode) 		resList.Add("MakerCode");
			if (this.MakerName		   != target.MakerName) 		resList.Add("MakerName");
			if (this.GoodsCode		   != target.GoodsCode) 		resList.Add("GoodsCode");
			if (this.GoodsName		   != target.GoodsName) 		resList.Add("GoodsName");
			if (this.SalesTargetMoney  != target.SalesTargetMoney)	resList.Add("SalesTargetMoney");
			if (this.SalesTargetProfit != target.SalesTargetProfit) resList.Add("SalesTargetProfit");
			if (this.SalesTargetCount  != target.SalesTargetCount)	resList.Add("SalesTargetCount");
			//----- ueno del---------- start 2007.11.21
			//if (this.WeekdayRatio != target.WeekdayRatio) resList.Add("WeekdayRatio");
			//if (this.SatSunRatio	   != target.SatSunRatio)		resList.Add("SatSunRatio");
			//----- ueno del---------- end 2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            if (this.BLGroupCode        != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGroupName        != target.BLGroupName) resList.Add("BLGroupName");
            if (this.BLCode             != target.BLCode) resList.Add("BLCode");
            if (this.BLCodeName         != target.BLCodeName) resList.Add("BLCodeName");
            if (this.SalesTypeCode      != target.SalesTypeCode) resList.Add("SalesTypeCode");
            if (this.SalesTypeName      != target.SalesTypeName) resList.Add("SalesTypeName");
            if (this.ItemTypeCode       != target.ItemTypeCode) resList.Add("ItemTypeCode");
            if (this.ItemTypeName       != target.ItemTypeName) resList.Add("ItemTypeName");
            if (this.BusinessTypeName   != target.BusinessTypeName) resList.Add("BusinessTypeName");
            if (this.SalesAreaName      != target.SalesAreaName) resList.Add("SalesAreaName");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

			return resList;
		}

        /// <summary>
		/// ����ڕW�ݒ�}�X�^��r����
		/// </summary>
		/// <param name="salesMonTarget1">��r����SalesTarget�N���X�̃C���X�^���X</param>
		/// <param name="salesMonTarget2">��r����SalesTarget�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :	 SalesTarget�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public static ArrayList Compare(SalesTarget salesMonTarget1, SalesTarget salesMonTarget2)
		{
			ArrayList resList = new ArrayList();
			if (salesMonTarget1.CreateDateTime	  != salesMonTarget2.CreateDateTime)	resList.Add("CreateDateTime");
			if (salesMonTarget1.UpdateDateTime	  != salesMonTarget2.UpdateDateTime)	resList.Add("UpdateDateTime");
			if (salesMonTarget1.EnterpriseCode	  != salesMonTarget2.EnterpriseCode)	resList.Add("EnterpriseCode");
			if (salesMonTarget1.FileHeaderGuid	  != salesMonTarget2.FileHeaderGuid)	resList.Add("FileHeaderGuid");
			if (salesMonTarget1.UpdEmployeeCode   != salesMonTarget2.UpdEmployeeCode)	resList.Add("UpdEmployeeCode");
			if (salesMonTarget1.UpdAssemblyId1	  != salesMonTarget2.UpdAssemblyId1)	resList.Add("UpdAssemblyId1");
			if (salesMonTarget1.UpdAssemblyId2	  != salesMonTarget2.UpdAssemblyId2)	resList.Add("UpdAssemblyId2");
			if (salesMonTarget1.LogicalDeleteCode != salesMonTarget2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (salesMonTarget1.SectionCode 	  != salesMonTarget2.SectionCode)		resList.Add("SectionCode");
			if (salesMonTarget1.TargetSetCd 	  != salesMonTarget2.TargetSetCd)		resList.Add("TargetSetCd");
			if (salesMonTarget1.TargetContrastCd  != salesMonTarget2.TargetContrastCd)	resList.Add("TargetContrastCd");
			if (salesMonTarget1.TargetDivideCode  != salesMonTarget2.TargetDivideCode)	resList.Add("TargetDivideCode");
			if (salesMonTarget1.TargetDivideName  != salesMonTarget2.TargetDivideName)	resList.Add("TargetDivideName");
			if (salesMonTarget1.ApplyStaDate	  != salesMonTarget2.ApplyStaDate)		resList.Add("ApplyStaDate");
			if (salesMonTarget1.ApplyEndDate	  != salesMonTarget2.ApplyEndDate)		resList.Add("ApplyEndDate");
			if (salesMonTarget1.EmployeeCode	  != salesMonTarget2.EmployeeCode)		resList.Add("EmployeeCode");
			if (salesMonTarget1.EmployeeName	  != salesMonTarget2.EmployeeName)		resList.Add("EmployeeName");
//----- ueno add---------- start 2007.11.21
			if (salesMonTarget1.EmployeeDivCd     != salesMonTarget2.EmployeeDivCd)     resList.Add("EmployeeDivCd");
			if (salesMonTarget1.SubSectionCode    != salesMonTarget2.SubSectionCode)    resList.Add("SubSectionCode");
			if (salesMonTarget1.MinSectionCode    != salesMonTarget2.MinSectionCode)    resList.Add("MinSectionCode");
			if (salesMonTarget1.BusinessTypeCode  != salesMonTarget2.BusinessTypeCode)  resList.Add("BusinessTypeCode");
			if (salesMonTarget1.SalesAreaCode     != salesMonTarget2.SalesAreaCode)     resList.Add("SalesAreaCode");
			if (salesMonTarget1.CustomerCode      != salesMonTarget2.CustomerCode)      resList.Add("CustomerCode");
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//if (salesMonTarget1.SalesFormal != salesMonTarget2.SalesFormal) resList.Add("SalesFormal");
			//if (salesMonTarget1.SalesFormCode	  != salesMonTarget2.SalesFormCode) 	resList.Add("SalesFormCode");
			//if (salesMonTarget1.SalesFormName	  != salesMonTarget2.SalesFormName) 	resList.Add("SalesFormName");
			//if (salesMonTarget1.CarrierCode 	  != salesMonTarget2.CarrierCode)		resList.Add("CarrierCode");
			//if (salesMonTarget1.CarrierName 	  != salesMonTarget2.CarrierName)		resList.Add("CarrierName");
			//if (salesMonTarget1.CellphoneModelCode != salesMonTarget2.CellphoneModelCode) resList.Add("CellphoneModelCode");
			//if (salesMonTarget1.CellphoneModelName != salesMonTarget2.CellphoneModelName) resList.Add("CellphoneModelName");
			//----- ueno del---------- end   2007.11.21
			if (salesMonTarget1.MakerCode		  != salesMonTarget2.MakerCode) 		resList.Add("MakerCode");
			if (salesMonTarget1.MakerName		  != salesMonTarget2.MakerName) 		resList.Add("MakerName");
			if (salesMonTarget1.GoodsCode		  != salesMonTarget2.GoodsCode) 		resList.Add("GoodsCode");
			if (salesMonTarget1.GoodsName		  != salesMonTarget2.GoodsName) 		resList.Add("GoodsName");
			if (salesMonTarget1.SalesTargetMoney  != salesMonTarget2.SalesTargetMoney)	resList.Add("SalesTargetMoney");
			if (salesMonTarget1.SalesTargetProfit != salesMonTarget2.SalesTargetProfit) resList.Add("SalesTargetProfit");
			if (salesMonTarget1.SalesTargetCount  != salesMonTarget2.SalesTargetCount)	resList.Add("SalesTargetCount");
			//----- ueno del---------- start 2007.11.21
			//if (salesMonTarget1.WeekdayRatio != salesMonTarget2.WeekdayRatio) resList.Add("WeekdayRatio");
			//if (salesMonTarget1.SatSunRatio 	  != salesMonTarget2.SatSunRatio)		resList.Add("SatSunRatio");
			//----- ueno del---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            if (salesMonTarget1.BLGroupCode         != salesMonTarget2.BLGroupCode) resList.Add("BLGroupCode");
            if (salesMonTarget1.BLGroupName         != salesMonTarget2.BLGroupName) resList.Add("BLGroupName");
            if (salesMonTarget1.BLCode              != salesMonTarget2.BLCode) resList.Add("BLCode");
            if (salesMonTarget1.BLCodeName          != salesMonTarget2.BLCodeName) resList.Add("BLCodeName");
            if (salesMonTarget1.SalesTypeCode       != salesMonTarget2.SalesTypeCode) resList.Add("SalesTypeCode");
            if (salesMonTarget1.SalesTypeName       != salesMonTarget2.SalesTypeName) resList.Add("SalesTypeName");
            if (salesMonTarget1.ItemTypeCode        != salesMonTarget2.ItemTypeCode) resList.Add("ItemTypeCode");
            if (salesMonTarget1.ItemTypeName        != salesMonTarget2.ItemTypeName) resList.Add("ItemTypeName");
            if (salesMonTarget1.BusinessTypeName    != salesMonTarget2.BusinessTypeName) resList.Add("BusinessTypeName");
            if (salesMonTarget1.SalesAreaName       != salesMonTarget2.SalesAreaName) resList.Add("SalesAreaName");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

			return resList;
		}

        /// <summary>
        /// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
        /// </summary>
        /// <param name="ds">�f�[�^�Z�b�g</param>
        /// <remarks>
        /// <br>Note	   : </br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2006.05.08</br>
        /// </remarks>
        public static void SettingDataSet(ref DataSet ds)
        {
            // �e�[�u�������݂��邩�ǂ������`�F�b�N
            if ((ds.Tables.Contains(CT_CsSalesTargetDataTable)))
            {
                // TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
                // �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[CT_CsSalesTargetDataTable].Clear();
            }
            else
            {
                CreateSalesTargetDataTable(ref ds, 0);

            }

            // ����`�F�b�N���X�g�o�b�t�@�f�[�^�e�[�u��------------------------------------------
            // �e�[�u�������݂��邩�ǂ������`�F�b�N
            if ((ds.Tables.Contains(CT_CsSalesTargetBuffDataTable)))
            {
                // TODO:�e�[�u�������݂���Ƃ��̓N���A�[����̂�
                // �X�L�[�}��������x�ݒ肷��悤�Ȃ��Ƃ͂��Ȃ��B
                ds.Tables[CT_CsSalesTargetBuffDataTable].Clear();
            }
            else
            {
                CreateSalesTargetDataTable(ref ds, 1);
            }
        }

        ///// <summary>
        ///// ���ʔ���ڕW�v�Z����
        ///// </summary>
        ///// <param name="salesTargetWeekday">��������ڕW</param>
        ///// <param name="salesTargetSatSunday">�y������ڕW</param>
        ///// <param name="salesTarget">����ڕW</param>
        ///// <param name="weekdayRatio">�����䗦</param>
        ///// <param name="satSunRatio">�y���䗦</param>
        ///// <param name="targetDateSt">�J�n��</param>
        ///// <param name="targetDateEd">�I����</param>
        ///// <remarks>
        ///// <br>Note	   : ��������ѓy����1���̔���ڕW���v�Z����</br>
        ///// <br>Programmer : NEPCO</br>
        ///// <br>Date	   : 2007.05.08</br>
        ///// </remarks>
        //public static void CalcDaySalesTargetFromRatio(
        //    out double salesTargetWeekday,
        //    out double salesTargetSatSunday,
        //    double salesTarget,
        //    double weekdayRatio,
        //    double satSunRatio,
        //    DateTime targetDateSt,
        //    DateTime targetDateEd)
        //{
        //    CalcDaySalesTargetFromRatio(
        //        out salesTargetWeekday,
        //        out salesTargetSatSunday,
        //        salesTarget,
        //        weekdayRatio,
        //        satSunRatio,
        //        targetDateSt,
        //        targetDateEd,
        //        true);
        //}

        ///// <summary>
        ///// ���ʔ���ڕW�v�Z����
        ///// </summary>
        ///// <param name="salesTargetWeekday">��������ڕW</param>
        ///// <param name="salesTargetSatSunday">�y������ڕW</param>
        ///// <param name="salesTarget">����ڕW</param>
        ///// <param name="weekdayRatio">�����䗦</param>
        ///// <param name="satSunRatio">�y���䗦</param>
        ///// <param name="targetDateSt">�J�n��</param>
        ///// <param name="targetDateEd">�I����</param>
        ///// <param name="round">�����_�ȉ��̂܂�߂��s�Ȃ���</param>
        ///// <remarks>
        ///// <br>Note	   : ��������ѓy����1���̔���ڕW���v�Z����</br>
        ///// <br>Programmer : NEPCO</br>
        ///// <br>Date	   : 2007.05.08</br>
        ///// </remarks>
        //public static void CalcDaySalesTargetFromRatio(
        //    out double salesTargetWeekday,
        //    out double salesTargetSatSunday,
        //    double salesTarget,
        //    double weekdayRatio,
        //    double satSunRatio,
        //    DateTime targetDateSt,
        //    DateTime targetDateEd,
        //    bool round)
        //{
        //    double totalRatio = 0;
        //    salesTargetWeekday = 0;
        //    salesTargetSatSunday = 0;

        //    // �Ώۊ��Ԃ̔䗦���v
        //    totalRatio = CalcTotalRatio(weekdayRatio, satSunRatio, targetDateSt, targetDateEd);

        //    // ����
        //    salesTargetWeekday = salesTarget * weekdayRatio / totalRatio;
        //    if (round)
        //    {
        //        salesTargetWeekday = Math.Round(salesTargetWeekday, MidpointRounding.AwayFromZero);
        //    }

        //    // �y��
        //    salesTargetSatSunday = salesTarget * satSunRatio / totalRatio;
        //    if (round)
        //    {
        //        salesTargetSatSunday = Math.Round(salesTargetSatSunday, MidpointRounding.AwayFromZero);
        //    }
        //}

        ///// <summary>
        ///// �i�����v�Z����
        ///// </summary>
        ///// <param name="salesResult">����f�[�^</param>
        ///// <param name="salesTarget">�ڕW�f�[�^</param>
        ///// <param name="weekdayRatio">�����䗦</param>
        ///// <param name="satSunRatio">�y���䗦</param>
        ///// <param name="targetDateSt">�J�n��</param>
        ///// <param name="targetDateEd">�I����</param>
        ///// <param name="salesFixedDate">�ŏI�����(�{��)</param>
        ///// <returns>�i����</returns>
        ///// <remarks>
        ///// <br>Note	   : ���エ��іڕW�f�[�^���i�������v�Z����</br>
        ///// <br>Programmer : NEPCO</br>
        ///// <br>Date	   : 2007.05.08</br>
        ///// </remarks>
        //public static double CalcProgressRatio(
        //    double salesResult,
        //    double salesTarget,
        //    double weekdayRatio,
        //    double satSunRatio,
        //    DateTime targetDateSt,
        //    DateTime targetDateEd,
        //    DateTime salesFixedDate)
        //{
        //    double totalRatio = 0;
        //    double totalRatioNow = 0;
        //    DateTime targetDate;
        //    double salesTargetNow;

        //    if (salesTarget <= 0)
        //    {
        //        return (0.0);
        //    }
        //    if (salesFixedDate <= targetDateEd)
        //    {
        //        targetDate = salesFixedDate;
        //    }
        //    else
        //    {
        //        targetDate = targetDateEd;
        //    }

        //    // �ڕW���Ԃ̔䗦���v
        //    totalRatio = CalcTotalRatio(weekdayRatio, satSunRatio, targetDateSt, targetDateEd);
        //    // �Ώۊ��Ԃ̔䗦���v
        //    totalRatioNow = CalcTotalRatio(weekdayRatio, satSunRatio, targetDateSt, targetDate);
        //    // �Ώۂ̖ڕW�l�v�Z
        //    salesTargetNow = salesTarget * (totalRatioNow / totalRatio);

        //    return (salesResult / salesTargetNow);

        //}

        ///// <summary>
        ///// ���n����v�Z����
        ///// </summary>
        ///// <param name="salesResult">����f�[�^</param>
        ///// <param name="weekdayRatio">�����䗦</param>
        ///// <param name="satSunRatio">�y���䗦</param>
        ///// <param name="targetDateSt">�J�n��</param>
        ///// <param name="targetDateEd">�I����</param>
        ///// <param name="salesFixedDate">�ŏI�����(�{��)</param>
        ///// <returns>���n����f�[�^</returns>
        ///// <remarks>
        ///// <br>Note	   : ����f�[�^���I�����̒��n����f�[�^���v�Z����</br>
        ///// <br>Programmer : NEPCO</br>
        ///// <br>Date	   : 2007.05.08</br>
        ///// </remarks>
        //public static double CalcLanding(
        //    double salesResult,
        //    double weekdayRatio,
        //    double satSunRatio,
        //    DateTime targetDateSt,
        //    DateTime targetDateEd,
        //    DateTime salesFixedDate)
        //{
        //    double totalRatio = 0;
        //    double totalRatioNow = 0;
        //    DateTime targetDate;

        //    if (salesFixedDate <= targetDateEd)
        //    {
        //        targetDate = salesFixedDate;
        //    }
        //    else
        //    {
        //        targetDate = targetDateEd;
        //    }

        //    // �ڕW���Ԃ̔䗦���v
        //    totalRatio = CalcTotalRatio(weekdayRatio, satSunRatio, targetDateSt, targetDateEd);
        //    // �Ώۊ��Ԃ̔䗦���v
        //    totalRatioNow = CalcTotalRatio(weekdayRatio, satSunRatio, targetDateSt, targetDate);

        //    return (salesResult * (totalRatio / totalRatioNow));

        //}

        ///// <summary>
        ///// �䗦�v�Z����
        ///// </summary>
        ///// <param name="weekdayRatio">�����䗦</param>
        ///// <param name="satSunRatio">�y���䗦</param>
        ///// <param name="targetDateSt">�J�n��</param>
        ///// <param name="targetDateEd">�I����</param>
        ///// <returns>�Ώۊ��Ԃ̔䗦���v</returns>
        ///// <remarks>
        ///// <br>Note	   : �Ώۊ��Ԃ̔䗦�̍��v���v�Z����</br>
        ///// <br>Programmer : NEPCO</br>
        ///// <br>Date	   : 2007.05.08</br>
        ///// </remarks>
        //public static double CalcTotalRatio(
        //    double weekdayRatio,
        //    double satSunRatio,
        //    DateTime targetDateSt,
        //    DateTime targetDateEd)
        //{
        //    int weekdayCount = 0;
        //    int satSunCount = 0;

        //    for (DateTime date = targetDateSt; date <= targetDateEd; date = date.AddDays(1))
        //    {
        //        // �y���̏ꍇ
        //        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        //        {
        //            satSunCount++;
        //        }
        //        // �����̏ꍇ
        //        else
        //        {
        //            weekdayCount++;
        //        }
        //    }

        //    // �Ώۊ��Ԃ̔䗦���v
        //    return (weekdayRatio * weekdayCount + satSunRatio * satSunCount);

        //}

        #region �����񑀍�

        /// <summary>
        /// ������̍��[����w�肵���o�C�g�����̕������Ԃ�
        /// </summary>
        /// <param name="targetString">�Ώە�����</param>
        /// <param name="byteSize">���o���o�C�g��</param>
        /// <returns>���o����������</returns>
        /// <remarks>
        /// <br>Note	   : Encoding:Shift_JIS</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public static string LeftB(string targetString, int byteSize)
        {
            System.Text.Encoding shiftjisEncoding = System.Text.Encoding.GetEncoding("Shift_JIS");
            byte[] bytes = shiftjisEncoding.GetBytes(targetString);

            return (MidB(targetString, 0, byteSize));

        }

        /// <summary>
        /// ������̉E�[����w�肵���o�C�g�����̕������Ԃ�
        /// </summary>
        /// <param name="targetString">�Ώە�����</param>
        /// <param name="byteSize">���o���o�C�g��</param>
        /// <returns>���o����������</returns>
        /// <remarks>
        /// <br>Note	   : Encoding:Shift_JIS</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public static string RightB(string targetString, int byteSize)
        {
            System.Text.Encoding shiftjisEncoding = System.Text.Encoding.GetEncoding("Shift_JIS");
            int targetLength = shiftjisEncoding.GetBytes(targetString).Length;
            int startIndex = targetLength - byteSize;
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            return (MidB(targetString, startIndex, byteSize));

        }

        /// <summary>
        /// ������̎w�肳�ꂽ�o�C�g�ʒu�ȍ~�̂��ׂĂ̕������Ԃ�
        /// </summary>
        /// <param name="targetString">�Ώە�����</param>
        /// <param name="startIndex">�J�n�����ʒu</param>
        /// <returns>���o����������</returns>
        /// <remarks>
        /// <br>Note	   : Encoding:Shift_JIS</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public static string MidB(string targetString, int startIndex)
        {
            System.Text.Encoding shiftjisEncoding = System.Text.Encoding.GetEncoding("Shift_JIS");
            return (MidB(targetString, startIndex, shiftjisEncoding.GetBytes(targetString).Length));
        }

        /// <summary>
        /// ������̎w�肳�ꂽ�o�C�g�ʒu����A�w�肳�ꂽ�o�C�g�����̕������Ԃ�
        /// </summary>
        /// <param name="targetString">�Ώە�����</param>
        /// <param name="startIndex">�J�n�����ʒu</param>
        /// <param name="byteSize">���o���o�C�g��</param>
        /// <returns>���o����������</returns>
        /// <remarks>
        /// <br>Note	   : Encoding:Shift_JIS</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public static string MidB(string targetString, int startIndex, int byteSize)
        {
            System.Text.Encoding shiftjisEncoding = System.Text.Encoding.GetEncoding("Shift_JIS");
            byte[] bytes = shiftjisEncoding.GetBytes(targetString);
            string returnString;

            if (startIndex >= bytes.Length)
            {
                return ("");
            }

            // 2�o�C�g�����Ή�
            if (startIndex > 0)
            {
                if (startIndex <= bytes.Length)
                {
                    if (0x81 <= bytes[startIndex - 1] && bytes[startIndex - 1] <= 0x9f ||
                        0xe0 <= bytes[startIndex - 1] && bytes[startIndex - 1] <= 0x9f)
                    {
                        startIndex++;
                    }
                }
            }
            if (startIndex + byteSize <= bytes.Length)
            {
                if (0x81 <= bytes[startIndex + byteSize - 1] && bytes[startIndex + byteSize - 1] <= 0x9f ||
                    0xe0 <= bytes[startIndex + byteSize - 1] && bytes[startIndex + byteSize - 1] <= 0x9f)
                {
                    byteSize--;
                }
            }

            // �T�C�Y����
            if (startIndex + byteSize > bytes.Length)
            {
                byteSize = bytes.Length - startIndex;
            }

            returnString = shiftjisEncoding.GetString(bytes, startIndex, byteSize);

            return (returnString);

        }

        #endregion �����񑀍�

//----- ueno add---------- start 2007.11.21

		/// <summary>�S�ڕW�Δ�敪���X�g</summary>
		public static SortedList _targetContrastCdAllSList;

		/// <summary>�]�ƈ��ڕW�Δ�敪���X�g</summary>
		public static SortedList _targetContrastCdEmpSList;

		/// <summary>���i�ڕW�Δ�敪���X�g</summary>
		public static SortedList _targetContrastCdGoodsSList;

		/// <summary>���Ӑ�ڕW�Δ�敪���X�g</summary>
		public static SortedList _targetContrastCdCustSList;

		/// <summary>
		/// �ÓI�R���X�g���N�^
		/// </summary>
		static SalesTarget()
		{
			_targetContrastCdAllSList = MakeTargetContrastCdAll();
			_targetContrastCdEmpSList = MakeTargetContrastCdEmp();
			_targetContrastCdGoodsSList = MakeTargetContrastCdGoods();
			_targetContrastCdCustSList = MakeTargetContrastCdCust();
		}

		/// <summary>
		/// �ڕW�Δ�敪���̎擾����
		/// </summary>
		/// <param name="targetContrastCd">�ڕW�Δ�敪�R�[�h</param>
		/// <returns>�ڕW�Δ�敪����</returns>
		/// <remarks>
		/// <br>Note       : �ڕW�Δ�敪�R�[�h����ڕW�Δ�敪���̂��擾���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public static string GetTargetContrastNm(int targetContrastCd)
		{
			string retStr = "";

			if (_targetContrastCdAllSList.ContainsKey((object)targetContrastCd))
			{
				retStr = _targetContrastCdAllSList[targetContrastCd].ToString();
			}
			return retStr;
		}
		
//----- ueno add---------- end   2007.11.21

        #endregion Public Method

        #region Private Methods

        /// <summary>
		/// �ڕW���o���ʍ쐬����
		/// </summary>
        /// <param name="ds">�f�[�^�Z�b�g</param>
        /// <param name="buffCheck">�o�b�t�@�`�F�b�N</param>
		/// <remarks>
		/// <br>Note	   : </br>
		/// <br>Programmer : NEPCO</br>
		/// <br>Date	   : 2006.05.08</br>
		/// </remarks>
		private static void CreateSalesTargetDataTable(ref DataSet ds, int buffCheck)
		{
			DataTable dt = null;
			if (buffCheck == 0)
			{
				// �X�L�[�}�ݒ�
				ds.Tables.Add(CT_CsSalesTargetDataTable);
				dt = ds.Tables[CT_CsSalesTargetDataTable];
			}
			else
			{
				// �X�L�[�}�ݒ�
				ds.Tables.Add(CT_CsSalesTargetBuffDataTable);
				dt = ds.Tables[CT_CsSalesTargetBuffDataTable];
			}

			//			  // �V�X�e���R�[�h
			//			  dt.Columns.Add(CT_CsSaleChkList_SystemCodeHd, typeof(Int32));
			//			  dt.Columns[CT_CsSaleChkList_SystemCodeHd].DefaultValue = 0;
			//			  // �V�X�e������
			//			  dt.Columns.Add(CT_CsSaleChkList_SystemName, typeof(string));
			//			  dt.Columns[CT_CsSaleChkList_SystemName].DefaultValue = "";
			//			  // ���_�R�[�h
			//			  dt.Columns.Add(CT_CsSaleChkList_SectionCode, typeof(string));
			//			  dt.Columns[CT_CsSaleChkList_SectionCode].DefaultValue = "";
		}

//----- ueno add---------- start 2007.11.21

		/// <summary>
		/// �]�ƈ��ڕW�Δ�敪���X�g����
		/// </summary>
		/// <returns>�]�ƈ��ڕW�Δ�敪�̃��X�g</returns>
		/// <remarks>
		/// <br>Note	   : �]�ƈ��ڕW�Δ�敪�̃��X�g�𐶐����܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private static SortedList MakeTargetContrastCdEmp()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(20, "���_�{����");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
            // ���͗��u�ۃR�[�h�v�폜�ɂ��C��
			//retSortedList.Add(21, "���_�{����{��");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
            retSortedList.Add(22, "���_�{�]�ƈ�");
			return retSortedList;
		}

		/// <summary>
		/// ���Ӑ�ڕW�Δ�敪���X�g����
		/// </summary>
		/// <returns>���Ӑ�ڕW�Δ�敪�̃��X�g</returns>
		/// <remarks>
		/// <br>Note	   : ���Ӑ�ڕW�Δ�敪�̃��X�g�𐶐����܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private static SortedList MakeTargetContrastCdCust()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(30, "���_�{���Ӑ�");
			retSortedList.Add(31, "���_�{�Ǝ�");
			retSortedList.Add(32, "���_�{�̔��G���A");
			return retSortedList;
		}

		/// <summary>
		/// ���i�ڕW�Δ�敪���X�g����
		/// </summary>
		/// <returns>���i�ڕW�Δ�敪�̃��X�g</returns>
		/// <remarks>
		/// <br>Note	   : ���i�ڕW�Δ�敪�̃��X�g�𐶐����܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private static SortedList MakeTargetContrastCdGoods()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(40, "���_�{���[�J�[");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA MODIFY START
			retSortedList.Add(41, "���_�{���[�J�[�{�i��");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
            // �ݒ荀�ڒǉ��ɂ��C��
            retSortedList.Add(42, "���_�{BL��ٰ��");
            retSortedList.Add(43, "���_�{BL����");
            retSortedList.Add(44, "���_�{�̔��敪");
            retSortedList.Add(45, "���_�{���i�敪");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END
            return retSortedList;
		}

		/// <summary>
		/// �S�ڕW�Δ�敪���X�g����
		/// </summary>
		/// <returns>�S�ڕW�Δ�敪�̃��X�g</returns>
		/// <remarks>
		/// <br>Note	   : �S�ڕW�Δ�敪�̃��X�g�𐶐����܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private static SortedList MakeTargetContrastCdAll()
		{
			SortedList retSortedList = new SortedList();
			retSortedList.Add(10, "���_");
			retSortedList.Add(20, "���_�{����");
			retSortedList.Add(21, "���_�{����{��");
			retSortedList.Add(22, "���_�{�]�ƈ�");
			retSortedList.Add(30, "���_�{���Ӑ�");
			retSortedList.Add(31, "���_�{�Ǝ�");
			retSortedList.Add(32, "���_�{�̔��G���A");
			retSortedList.Add(40, "���_�{���[�J�[");
            retSortedList.Add(41, "���_�{���[�J�[�{�i��");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
            // �ݒ荀�ڒǉ��ɂ��C��
            retSortedList.Add(42, "���_�{BL��ٰ��");
            retSortedList.Add(43, "���_�{BL����");
            retSortedList.Add(44, "���_�{�̔��敪");
            retSortedList.Add(45, "���_�{���i�敪");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END
			return retSortedList;
		}

//----- ueno add---------- end   2007.11.21

		#endregion

	}
}

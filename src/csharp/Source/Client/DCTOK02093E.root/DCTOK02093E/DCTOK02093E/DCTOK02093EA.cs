using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_DCTOK02093E
	/// <summary>
	///                      �O�N�Δ�\���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �O�N�Δ�\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008.11.25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class ExtrInfo_DCTOK02093E
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�o�͑Ώۋ��_</summary>
		/// <remarks>null�̏ꍇ�͑S���_</remarks>
		private String[] _secCodeList;

		/// <summary>�W�v���@</summary>
		/// <remarks>0:�S�ЏW�v 1:���_�ʏW�v</remarks>
        private Int32 _totalWay;

		/// <summary>���[�^�C�v</summary>
		/// <remarks>0:���Ӑ�� 1:�S���ҕ� 2:�󒍎ҕ� 3:�n��� 4:�Ǝ�� 5:�O���[�v�R�[�h�� 6:BL�R�[�h��</remarks>
		private Int32 _listType;

		/// <summary>���z�P��</summary>
		/// <remarks>0:��~�P�� 1:��~�P��</remarks>
		private Int32 _moneyUnit;

		/// <summary>�J�n�Ώ۔N��</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _st_AddUpYearMonth;

		/// <summary>�I���Ώ۔N��</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _ed_AddUpYearMonth;

		/// <summary>�O�N��(�J�n����������)</summary>
		/// <remarks>%�w��</remarks>
		private Double _st_MonthSalesRatio;

		/// <summary>�O�N��(�I������������)</summary>
		/// <remarks>%�w��</remarks>
		private Double _ed_MonthSalesRatio;

		/// <summary>�O�N��(�J�n���N������)</summary>
		/// <remarks>%�w��</remarks>
		private Double _st_YearSalesRatio;

		/// <summary>�O�N��(�I�����N������)</summary>
		/// <remarks>%�w��</remarks>
		private Double _ed_YearSalesRatio;

		/// <summary>�O�N��(�J�n�����e��)</summary>
		/// <remarks>%�w��</remarks>
		private Double _st_MonthGrossRatio;

		/// <summary>�O�N��(�I�������e��)</summary>
		/// <remarks>%�w��</remarks>
		private Double _ed_MonthGrossRatio;

		/// <summary>�O�N��(�J�n���N�e��)</summary>
		/// <remarks>%�w��</remarks>
		private Double _st_YearGrossRatio;

		/// <summary>�O�N��(�I�����N�e��)</summary>
		/// <remarks>%�w��</remarks>
		private Double _ed_YearGrossRatio;

		/// <summary>�J�n�]�ƈ��R�[�h(�󒍎҃R�[�h�����˂�)</summary>
		/// <remarks>�S���ҕʂŎg�p</remarks>
		private string _st_EmployeeCode = "";

        /// <summary>�I���]�ƈ��R�[�h(�󒍎҃R�[�h�����˂�)</summary>
		/// <remarks>�S���ҕʂŎg�p</remarks>
		private string _ed_EmployeeCode = "";

		/// <summary>�J�n���Ӑ�R�[�h</summary>
		/// <remarks>���Ӑ�ʁE�n��ʁE�Ǝ�ʂŎg�p</remarks>
		private Int32 _st_CustomerCode;

		/// <summary>�I�����Ӑ�R�[�h</summary>
		/// <remarks>���Ӑ�ʁE�n��ʁE�Ǝ�ʂŎg�p</remarks>
		private Int32 _ed_CustomerCode;

		/// <summary>�J�n�̔��G���A�R�[�h</summary>
		/// <remarks>�n��ʂŎg�p</remarks>
		private Int32 _st_SalesAreaCode;

		/// <summary>�I���̔��G���A�R�[�h</summary>
		/// <remarks>�n��ʂŎg�p</remarks>
		private Int32 _ed_SalesAreaCode;

		/// <summary>�J�n�Ǝ�R�[�h</summary>
		/// <remarks>�Ǝ�ʂŎg�p</remarks>
		private Int32 _st_BusinessTypeCode;

		/// <summary>�I���Ǝ�R�[�h</summary>
		/// <remarks>�Ǝ�ʂŎg�p</remarks>
		private Int32 _ed_BusinessTypeCode;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�o�͏�</summary>
		private Int32 _sortOrder;

		/// <summary>����^�C�v</summary>
		/// <remarks>0:���� 1:�e�� 2:���さ�e�� </remarks>
		private Int32 _printType;

		/// <summary>����</summary>
		/// <remarks>True:���� False:���Ȃ�</remarks>
		private Boolean _newPage;

        /// <summary>����2</summary>
        /// <remarks>True:���� False:���Ȃ�</remarks>
        private Boolean _newPage2;

        /// <summary>���s�^�C�v</summary>
        /// <remarks>
        /// ���Ӑ�ʁF 0:���Ӑ�� 1:���_�� 2:���Ӑ�ʋ��_�� 3:�Ǘ����_�� 4:������� 
        /// �S���ҕʁF 0:�S���ҕ� 1:���Ӑ�� 2:�S���ҕʋ��_�� 3:�Ǘ����_��
        /// �󒍎ҕʁF 0:�󒍎ҕ� 1:���Ӑ�� 2:�󒍎ҕʋ��_�� 3:�Ǘ����_��
        /// �n��ʁF   0:�n��� 1:���Ӑ�� 2:�n��ʋ��_�� 3:�Ǘ����_��
        /// �Ǝ�ʁF�@ 0:�Ǝ�� 1:���Ӑ�� 2:�Ǝ�ʋ��_�� 3:�Ǘ����_��
        /// �O���[�v�R�[�h�ʁF 0:�O���[�v�R�[�h�� 1:���i�����ޕ� 2:���i�啪�ޕ�
        /// BL�R�[�h�� 0:BL�R�[�h�� 1:BL�R�[�h���Ӑ�� 2:BL�R�[�g�S���ҕ�
        /// </remarks>
        private Int32 _issueType;

        /// <summary>BL�R�[�h�J�n</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>BL�R�[�h�I��</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>���i�啪�ރR�[�h�J�n</summary>
        private Int32 _st_GoodsLGroup;

        /// <summary>���i�啪�ރR�[�h�I��</summary>
        private Int32 _ed_GoodsLGroup;

        /// <summary>���i�����ރR�[�h�J�n</summary>
        private Int32 _st_GoodsMGroup;

        /// <summary>���i�����ރR�[�h�I��</summary>
        private Int32 _ed_GoodsMGroup;

        /// <summary>�O���[�v�R�[�h�J�n</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>�O���[�v�R�[�h�I��</summary>
        private Int32 _ed_BLGroupCode;
        
        /// <summary>�O�N��(�J�n����������)���͔���</summary>
        /// <remarks>%�w��</remarks>
        private Boolean _st_MonthSalesRatio_ck;

        /// <summary>�O�N��(�I������������)���͔���</summary>
        /// <remarks>%�w��</remarks>
        private Boolean _ed_MonthSalesRatio_ck;

        /// <summary>�O�N��(�J�n���N������)���͔���</summary>
        /// <remarks>%�w��</remarks>
        private Boolean _st_YearSalesRatio_ck;

        /// <summary>�O�N��(�I�����N������)���͔���</summary>
        /// <remarks>%�w��</remarks>
        private Boolean _ed_YearSalesRatio_ck;

        /// <summary>�O�N��(�J�n�����e��)���͔���</summary>
        /// <remarks>%�w��</remarks>
        private Boolean _st_MonthGrossRatio_ck;

        /// <summary>�O�N��(�I�������e��)���͔���</summary>
        /// <remarks>%�w��</remarks>
        private Boolean _ed_MonthGrossRatio_ck;

        /// <summary>�O�N��(�J�n���N�e��)���͔���</summary>
        /// <remarks>%�w��</remarks>
        private Boolean _st_YearGrossRatio_ck;

        /// <summary>�O�N��(�I�����N�e��)���͔���</summary>
        /// <remarks>%�w��</remarks>
        private Boolean _ed_YearGrossRatio_ck;

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

		/// public propaty name  :  SecCodeList
		/// <summary>�o�͑Ώۋ��_�v���p�e�B</summary>
		/// <value>null�̏ꍇ�͑S���_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͑Ώۋ��_�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public String[] SecCodeList
		{
			get { return _secCodeList; }
			set { _secCodeList = value; }
		}

		/// public propaty name  :  TotalWay
		/// <summary>�W�v���@�v���p�e�B</summary>
		/// <value>True:�S�ЏW�v False:���_�ʏW�v</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W�v���@�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32 TotalWay
		{
			get { return _totalWay; }
			set { _totalWay = value; }
		}

		/// public propaty name  :  ListType
		/// <summary>���[�^�C�v�v���p�e�B</summary>
		/// <value>0:���_�� 1:���Ӑ�� 2:�S���ҕ� 3:�n��� 4:�Ǝ�� 5:������(�����Ǘ��ݒ�ˑ�)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ListType
		{
			get { return _listType; }
			set { _listType = value; }
		}

		/// public propaty name  :  MoneyUnit
		/// <summary>���z�P�ʃv���p�e�B</summary>
		/// <value>True:�~ False:��~</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���z�P�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MoneyUnit
		{
			get { return _moneyUnit; }
			set { _moneyUnit = value; }
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>�J�n�Ώ۔N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ώ۔N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_AddUpYearMonth
		{
			get { return _st_AddUpYearMonth; }
			set { _st_AddUpYearMonth = value; }
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>�I���Ώ۔N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ώ۔N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_AddUpYearMonth
		{
			get { return _ed_AddUpYearMonth; }
			set { _ed_AddUpYearMonth = value; }
		}

		/// public propaty name  :  St_MonthSalesRatio
		/// <summary>�O�N��(�J�n����������)�v���p�e�B</summary>
		/// <value>%�w��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�N��(�J�n����������)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double St_MonthSalesRatio
		{
			get { return _st_MonthSalesRatio; }
			set { _st_MonthSalesRatio = value; }
		}

		/// public propaty name  :  Ed_MonthSalesRatio
		/// <summary>�O�N��(�I������������)�v���p�e�B</summary>
		/// <value>%�w��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�N��(�I������������)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double Ed_MonthSalesRatio
		{
			get { return _ed_MonthSalesRatio; }
			set { _ed_MonthSalesRatio = value; }
		}

		/// public propaty name  :  St_YearSalesRatio
		/// <summary>�O�N��(�J�n���N������)�v���p�e�B</summary>
		/// <value>%�w��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�N��(�J�n���N������)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double St_YearSalesRatio
		{
			get { return _st_YearSalesRatio; }
			set { _st_YearSalesRatio = value; }
		}

		/// public propaty name  :  Ed_YearSalesRatio
		/// <summary>�O�N��(�I�����N������)�v���p�e�B</summary>
		/// <value>%�w��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�N��(�I�����N������)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double Ed_YearSalesRatio
		{
			get { return _ed_YearSalesRatio; }
			set { _ed_YearSalesRatio = value; }
		}

		/// public propaty name  :  St_MonthGrossRatio
		/// <summary>�O�N��(�J�n�����e��)�v���p�e�B</summary>
		/// <value>%�w��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�N��(�J�n�����e��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double St_MonthGrossRatio
		{
			get { return _st_MonthGrossRatio; }
			set { _st_MonthGrossRatio = value; }
		}

		/// public propaty name  :  Ed_MonthGrossRatio
		/// <summary>�O�N��(�I�������e��)�v���p�e�B</summary>
		/// <value>%�w��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�N��(�I�������e��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double Ed_MonthGrossRatio
		{
			get { return _ed_MonthGrossRatio; }
			set { _ed_MonthGrossRatio = value; }
		}

		/// public propaty name  :  St_YearGrossRatio
		/// <summary>�O�N��(�J�n���N�e��)�v���p�e�B</summary>
		/// <value>%�w��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�N��(�J�n���N�e��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double St_YearGrossRatio
		{
			get { return _st_YearGrossRatio; }
			set { _st_YearGrossRatio = value; }
		}

		/// public propaty name  :  Ed_YearGrossRatio
		/// <summary>�O�N��(�I�����N�e��)�v���p�e�B</summary>
		/// <value>%�w��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O�N��(�I�����N�e��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double Ed_YearGrossRatio
		{
			get { return _ed_YearGrossRatio; }
			set { _ed_YearGrossRatio = value; }
		}

		/// public propaty name  :  St_EmployeeCode
		/// <summary>�J�n�]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>�S���ҕʂŎg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_EmployeeCode
		{
			get { return _st_EmployeeCode; }
			set { _st_EmployeeCode = value; }
		}

		/// public propaty name  :  Ed_EmployeeCode
		/// <summary>�I���]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>�S���ҕʂŎg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_EmployeeCode
		{
			get { return _ed_EmployeeCode; }
			set { _ed_EmployeeCode = value; }
		}

		/// public propaty name  :  St_CustomerCode
		/// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
		/// <value>���Ӑ�ʁE�n��ʁE�Ǝ�ʂŎg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_CustomerCode
		{
			get { return _st_CustomerCode; }
			set { _st_CustomerCode = value; }
		}

		/// public propaty name  :  Ed_CustomerCode
		/// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
		/// <value>���Ӑ�ʁE�n��ʁE�Ǝ�ʂŎg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_CustomerCode
		{
			get { return _ed_CustomerCode; }
			set { _ed_CustomerCode = value; }
		}

		/// public propaty name  :  St_SalesAreaCode
		/// <summary>�J�n�̔��G���A�R�[�h�v���p�e�B</summary>
		/// <value>�n��ʂŎg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�̔��G���A�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_SalesAreaCode
		{
			get { return _st_SalesAreaCode; }
			set { _st_SalesAreaCode = value; }
		}

		/// public propaty name  :  Ed_SalesAreaCode
		/// <summary>�I���̔��G���A�R�[�h�v���p�e�B</summary>
		/// <value>�n��ʂŎg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���̔��G���A�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_SalesAreaCode
		{
			get { return _ed_SalesAreaCode; }
			set { _ed_SalesAreaCode = value; }
		}

		/// public propaty name  :  St_BusinessTypeCode
		/// <summary>�J�n�Ǝ�R�[�h�v���p�e�B</summary>
		/// <value>�Ǝ�ʂŎg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ǝ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_BusinessTypeCode
		{
			get { return _st_BusinessTypeCode; }
			set { _st_BusinessTypeCode = value; }
		}

		/// public propaty name  :  Ed_BusinessTypeCode
		/// <summary>�I���Ǝ�R�[�h�v���p�e�B</summary>
		/// <value>�Ǝ�ʂŎg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ǝ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_BusinessTypeCode
		{
			get { return _ed_BusinessTypeCode; }
			set { _ed_BusinessTypeCode = value; }
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
			get { return _enterpriseName; }
			set { _enterpriseName = value; }
		}

		/// public propaty name  :  SortOrder
		/// <summary>�o�͏��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͏��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SortOrder
		{
			get { return _sortOrder; }
			set { _sortOrder = value; }
		}

		/// public propaty name  :  PrintType
		/// <summary>����^�C�v�v���p�e�B</summary>
		/// <value>0:���� 1:�e�� 2:���さ�e��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintType
		{
			get { return _printType; }
			set { _printType = value; }
		}

		/// public propaty name  :  NewPage
		/// <summary>���Ńv���p�e�B</summary>
		/// <value>True:���� False:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ńv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean NewPage
		{
			get { return _newPage; }
			set { _newPage = value; }
		}

        /// public propaty name  :  NewPage2
        /// <summary>����2�v���p�e�B</summary>
        /// <value>True:���� False:���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean NewPage2
        {
            get { return _newPage2; }
            set { _newPage2 = value; }
        }
        
        /// public propaty name  :  IssueType
		/// <summary>���s�^�C�v�v���p�e�B</summary>
        /// <value>
        /// ���Ӑ�ʁF 0:���Ӑ�� 1:���_�� 2:���Ӑ�ʋ��_�� 3:�Ǘ����_�� 4:������� 
        /// �S���ҕʁF 0:�S���ҕ� 1:���Ӑ�� 2:�S���ҕʋ��_�� 3:�Ǘ����_��
        /// �󒍎ҕʁF 0:�󒍎ҕ� 1:���Ӑ�� 2:�󒍎ҕʋ��_�� 3:�Ǘ����_��
        /// �n��ʁF   0:�n��� 1:���Ӑ�� 2:�n��ʋ��_�� 3:�Ǘ����_��
        /// �Ǝ�ʁF�@ 0:�Ǝ�� 1:���Ӑ�� 2:�Ǝ�ʋ��_�� 3:�Ǘ����_��
        /// �O���[�v�R�[�h�ʁF 0:�O���[�v�R�[�h�� 1:���i�����ޕ� 2:���i�啪�ޕ�
        /// BL�R�[�h�� 0:BL�R�[�h�� 1:BL�R�[�h���Ӑ�� 2:BL�R�[�g�S���ҕ�
        /// </value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Int32 IssueType
		{
            get { return _issueType; }
            set { _issueType = value; }
		}

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>BL�R�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>BL�R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  St_GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsLGroup
        {
            get { return _st_GoodsLGroup; }
            set { _st_GoodsLGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsLGroup
        {
            get { return _ed_GoodsLGroup; }
            set { _ed_GoodsLGroup = value; }
        }

        /// public propaty name  :  St_GoodsMGroup
        /// <summary>���i�����ރR�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsMGroup
        {
            get { return _st_GoodsMGroup; }
            set { _st_GoodsMGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsMGroup
        /// <summary>���i�����ރR�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsMGroup
        {
            get { return _ed_GoodsMGroup; }
            set { _ed_GoodsMGroup = value; }
        }

        /// public propaty name  :  St_BLGroupCode
        /// <summary>�O���[�v�R�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O���[�v�R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGroupCode
        {
            get { return _st_BLGroupCode; }
            set { _st_BLGroupCode = value; }
        }

        /// public propaty name  :  Ed_BLGroupCode
        /// <summary>�O���[�v�R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O���[�v�R�[�h�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGroupCode
        {
            get { return _ed_BLGroupCode; }
            set { _ed_BLGroupCode = value; }
        }

        /// public propaty name  :  St_MonthSalesRatio_ck
        /// <summary>�O�N��(�J�n����������)�v���p�e�B</summary>
        /// <value>%�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�J�n����������)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean St_MonthSalesRatio_ck
        {
            get { return _st_MonthSalesRatio_ck; }
            set { _st_MonthSalesRatio_ck = value; }
        }

        /// public propaty name  :  Ed_MonthSalesRatio_ck
        /// <summary>�O�N��(�I������������)�v���p�e�B</summary>
        /// <value>%�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�I������������)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean Ed_MonthSalesRatio_ck
        {
            get { return _ed_MonthSalesRatio_ck; }
            set { _ed_MonthSalesRatio_ck = value; }
        }

        /// public propaty name  :  St_YearSalesRatio_ck
        /// <summary>�O�N��(�J�n���N������)�v���p�e�B</summary>
        /// <value>%�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�J�n���N������)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean St_YearSalesRatio_ck
        {
            get { return _st_YearSalesRatio_ck; }
            set { _st_YearSalesRatio_ck = value; }
        }

        /// public propaty name  :  Ed_YearSalesRatio_ck
        /// <summary>�O�N��(�I�����N������)�v���p�e�B</summary>
        /// <value>%�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�I�����N������)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean Ed_YearSalesRatio_ck
        {
            get { return _ed_YearSalesRatio_ck; }
            set { _ed_YearSalesRatio_ck = value; }
        }

        /// public propaty name  :  St_MonthGrossRatio_ck
        /// <summary>�O�N��(�J�n�����e��)�v���p�e�B</summary>
        /// <value>%�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�J�n�����e��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean St_MonthGrossRatio_ck
        {
            get { return _st_MonthGrossRatio_ck; }
            set { _st_MonthGrossRatio_ck = value; }
        }

        /// public propaty name  :  Ed_MonthGrossRatio_ck
        /// <summary>�O�N��(�I�������e��)�v���p�e�B</summary>
        /// <value>%�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�I�������e��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean Ed_MonthGrossRatio_ck
        {
            get { return _ed_MonthGrossRatio_ck; }
            set { _ed_MonthGrossRatio_ck = value; }
        }

        /// public propaty name  :  St_YearGrossRatio_ck
        /// <summary>�O�N��(�J�n���N�e��)�v���p�e�B</summary>
        /// <value>%�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�J�n���N�e��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean St_YearGrossRatio_ck
        {
            get { return _st_YearGrossRatio_ck; }
            set { _st_YearGrossRatio_ck = value; }
        }

        /// public propaty name  :  Ed_YearGrossRatio_ck
        /// <summary>�O�N��(�I�����N�e��)�v���p�e�B</summary>
        /// <value>%�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�N��(�I�����N�e��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean Ed_YearGrossRatio_ck
        {
            get { return _ed_YearGrossRatio_ck; }
            set { _ed_YearGrossRatio_ck = value; }
        }

		/// <summary>
		/// �O�N�Δ�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_DCTOK02093E�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DCTOK02093E�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_DCTOK02093E()
		{
		}

		/// <summary>
		/// �O�N�Δ�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="secCodeList">�o�͑Ώۋ��_(null�̏ꍇ�͑S���_)</param>
		/// <param name="totalWay">�W�v���@(True:�S�ЏW�v False:���_�ʏW�v)</param>
		/// <param name="listType">���[�^�C�v(0:���_�� 1:���Ӑ�� 2:�S���ҕ� 3:�n��� 4:�Ǝ�� 5:������(�����Ǘ��ݒ�ˑ�))</param>
		/// <param name="moneyUnit">���z�P��(True:�~ False:��~)</param>
		/// <param name="st_AddUpYearMonth">�J�n�Ώ۔N��(YYYYMM)</param>
		/// <param name="ed_AddUpYearMonth">�I���Ώ۔N��(YYYYMM)</param>
		/// <param name="st_MonthSalesRatio">�O�N��(�J�n����������)(%�w��)</param>
		/// <param name="ed_MonthSalesRatio">�O�N��(�I������������)(%�w��)</param>
		/// <param name="st_YearSalesRatio">�O�N��(�J�n���N������)(%�w��)</param>
		/// <param name="ed_YearSalesRatio">�O�N��(�I�����N������)(%�w��)</param>
		/// <param name="st_MonthGrossRatio">�O�N��(�J�n�����e��)(%�w��)</param>
		/// <param name="ed_MonthGrossRatio">�O�N��(�I�������e��)(%�w��)</param>
		/// <param name="st_YearGrossRatio">�O�N��(�J�n���N�e��)(%�w��)</param>
		/// <param name="ed_YearGrossRatio">�O�N��(�I�����N�e��)(%�w��)</param>		
		/// <param name="st_EmployeeCode">�J�n�]�ƈ��R�[�h(�S���ҕʂŎg�p)</param>
		/// <param name="ed_EmployeeCode">�I���]�ƈ��R�[�h(�S���ҕʂŎg�p)</param>
		/// <param name="st_CustomerCode">�J�n���Ӑ�R�[�h(���Ӑ�ʁE�n��ʁE�Ǝ�ʂŎg�p)</param>
		/// <param name="ed_CustomerCode">�I�����Ӑ�R�[�h(���Ӑ�ʁE�n��ʁE�Ǝ�ʂŎg�p)</param>
		/// <param name="st_SalesAreaCode">�J�n�̔��G���A�R�[�h(�n��ʂŎg�p)</param>
		/// <param name="ed_SalesAreaCode">�I���̔��G���A�R�[�h(�n��ʂŎg�p)</param>
		/// <param name="st_BusinessTypeCode">�J�n�Ǝ�R�[�h(�Ǝ�ʂŎg�p)</param>
		/// <param name="ed_BusinessTypeCode">�I���Ǝ�R�[�h(�Ǝ�ʂŎg�p)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="sortOrder">�o�͏�</param>
		/// <param name="printType">����^�C�v(0:���� 1:�e�� 2:���さ�e��)</param>
		/// <param name="newPage">����(True:���� False:���Ȃ�)</param>
        /// <param name="newPage2">����2(True:���� False:���Ȃ�)</param>
        /// <param name="IssueType">���s�^�C�v</param>
        /// <param name="St_BLGoodsCode">�J�nBL�R�[�h</param>
        /// <param name="Ed_BLGoodsCode">�I��BL�R�[�h</param>
        /// <param name="St_GoodsLGroup">�J�n���i�啪��</param>
        /// <param name="Ed_GoodsLGroup">�I�����i�啪��</param>
        /// <param name="St_GoodsMGroup">�J�n���i������</param>
        /// <param name="Ed_GoodsMGroup">�I�����i������</param>
        /// <param name="St_BLGroupCode">�J�n�O���[�v�R�[�h</param>
        /// <param name="Ed_BLGroupCode">�I���O���[�v�R�[�h</param>
        /// <param name="st_MonthSalesRatio_ck">�O�N��(�J�n����������)(���͔���)</param>
        /// <param name="ed_MonthSalesRatio_ck">�O�N��(�I������������)(���͔���)</param>
        /// <param name="st_YearSalesRatio_ck">�O�N��(�J�n���N������)(���͔���)</param>
        /// <param name="ed_YearSalesRatio_ck">�O�N��(�I�����N������)(���͔���)</param>
        /// <param name="st_MonthGrossRatio_ck">�O�N��(�J�n�����e��)(���͔���)</param>
        /// <param name="ed_MonthGrossRatio_ck">�O�N��(�I�������e��)(���͔���)</param>
        /// <param name="st_YearGrossRatio_ck">�O�N��(�J�n���N�e��)(���͔���)</param>
        /// <param name="ed_YearGrossRatio_ck">�O�N��(�I�����N�e��)(���͔���)</param>		
		/// <returns>ExtrInfo_DCTOK02093E�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DCTOK02093E�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public ExtrInfo_DCTOK02093E(string enterpriseCode, String[] secCodeList, Int32 totalWay, Int32 listType, Int32 moneyUnit, Int32 st_AddUpYearMonth, Int32 ed_AddUpYearMonth, Double st_MonthSalesRatio, Double ed_MonthSalesRatio, Double st_YearSalesRatio, Double ed_YearSalesRatio, Double st_MonthGrossRatio, Double ed_MonthGrossRatio, Double st_YearGrossRatio, Double ed_YearGrossRatio, string st_EmployeeCode, string ed_EmployeeCode, Int32 st_CustomerCode, Int32 ed_CustomerCode, Int32 st_SalesAreaCode, Int32 ed_SalesAreaCode, Int32 st_BusinessTypeCode, Int32 ed_BusinessTypeCode, string enterpriseName, Int32 sortOrder, Int32 printType, Boolean newPage, Boolean newPage2, Int32 IssueType, Int32 St_BLGoodsCode, Int32 Ed_BLGoodsCode, Int32 St_GoodsLGroup, Int32 Ed_GoodsLGroup, Int32 St_GoodsMGroup, Int32 Ed_GoodsMGroup, Int32 St_BLGroupCode, Int32 Ed_BLGroupCode,Boolean st_MonthSalesRatio_ck, Boolean ed_MonthSalesRatio_ck, Boolean st_YearSalesRatio_ck, Boolean ed_YearSalesRatio_ck, Boolean st_MonthGrossRatio_ck, Boolean ed_MonthGrossRatio_ck, Boolean st_YearGrossRatio_ck, Boolean ed_YearGrossRatio_ck)
		{
			this._enterpriseCode = enterpriseCode;
			this._secCodeList = secCodeList;
			this._totalWay = totalWay;
			this._listType = listType;
			this._moneyUnit = moneyUnit;
			this._st_AddUpYearMonth = st_AddUpYearMonth;
			this._ed_AddUpYearMonth = ed_AddUpYearMonth;
			this._st_MonthSalesRatio = st_MonthSalesRatio;
			this._ed_MonthSalesRatio = ed_MonthSalesRatio;
			this._st_YearSalesRatio = st_YearSalesRatio;
			this._ed_YearSalesRatio = ed_YearSalesRatio;
			this._st_MonthGrossRatio = st_MonthGrossRatio;
			this._ed_MonthGrossRatio = ed_MonthGrossRatio;
			this._st_YearGrossRatio = st_YearGrossRatio;
			this._ed_YearGrossRatio = ed_YearGrossRatio;
			this._st_EmployeeCode = st_EmployeeCode;
			this._ed_EmployeeCode = ed_EmployeeCode;
			this._st_CustomerCode = st_CustomerCode;
			this._ed_CustomerCode = ed_CustomerCode;
			this._st_SalesAreaCode = st_SalesAreaCode;
			this._ed_SalesAreaCode = ed_SalesAreaCode;
			this._st_BusinessTypeCode = st_BusinessTypeCode;
			this._ed_BusinessTypeCode = ed_BusinessTypeCode;
			this._enterpriseName = enterpriseName;
			this._sortOrder = sortOrder;
			this._printType = printType;
			this._newPage = newPage;
            this._newPage2 = newPage2;
            this._issueType = IssueType;
            this._st_BLGoodsCode = St_BLGoodsCode;
            this._ed_BLGoodsCode = Ed_BLGoodsCode;
            this._st_GoodsLGroup = St_GoodsLGroup;
            this._ed_GoodsLGroup = Ed_GoodsLGroup;
            this._st_GoodsMGroup = St_GoodsMGroup;
            this._ed_GoodsMGroup = Ed_GoodsMGroup;
            this._st_BLGroupCode = St_BLGroupCode;
            this._ed_BLGroupCode = Ed_BLGroupCode;
            this._st_MonthSalesRatio_ck = st_MonthSalesRatio_ck;
            this._ed_MonthSalesRatio_ck = ed_MonthSalesRatio_ck;
            this._st_YearSalesRatio_ck = st_YearSalesRatio_ck;
            this._ed_YearSalesRatio_ck = ed_YearSalesRatio_ck;
            this._st_MonthGrossRatio_ck = st_MonthGrossRatio_ck;
            this._ed_MonthGrossRatio_ck = ed_MonthGrossRatio_ck;
            this._st_YearGrossRatio_ck = st_YearGrossRatio_ck;
            this._ed_YearGrossRatio_ck = ed_YearGrossRatio_ck;

		}

		/// <summary>
		/// �O�N�Δ�\���o�����N���X��������
		/// </summary>
		/// <returns>ExtrInfo_DCTOK02093E�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ExtrInfo_DCTOK02093E�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public ExtrInfo_DCTOK02093E Clone()
        {
            return new ExtrInfo_DCTOK02093E(this._enterpriseCode, this._secCodeList, this._totalWay, this._listType, this._moneyUnit, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._st_MonthSalesRatio, this._ed_MonthSalesRatio, this._st_YearSalesRatio, this._ed_YearSalesRatio, this._st_MonthGrossRatio, this._ed_MonthGrossRatio, this._st_YearGrossRatio, this._ed_YearGrossRatio, this._st_EmployeeCode, this._ed_EmployeeCode, this._st_CustomerCode, this._ed_CustomerCode, this._st_SalesAreaCode, this._ed_SalesAreaCode, this._st_BusinessTypeCode, this._ed_BusinessTypeCode, this._enterpriseName, this._sortOrder, this._printType, this._newPage, this._newPage2, this._issueType, this._st_BLGoodsCode, this._ed_BLGoodsCode, this._st_GoodsLGroup, this._ed_GoodsLGroup, this._st_GoodsMGroup, this._ed_GoodsMGroup, this._st_BLGroupCode, this._ed_BLGroupCode, this._st_MonthSalesRatio_ck, this._ed_MonthSalesRatio_ck, this._st_YearSalesRatio_ck, this._ed_YearSalesRatio_ck, this._st_MonthGrossRatio_ck, this._ed_MonthGrossRatio_ck, this._st_YearGrossRatio_ck, this._ed_YearGrossRatio_ck);

        }

		/// <summary>
		/// �O�N�Δ�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_DCTOK02093E�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DCTOK02093E�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public bool Equals(ExtrInfo_DCTOK02093E target)
        {
            return (
                (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SecCodeList == target.SecCodeList)
                 && (this.TotalWay == target.TotalWay)
                 && (this.ListType == target.ListType)
                 && (this.MoneyUnit == target.MoneyUnit)
                 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
                 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
                 && (this.St_MonthSalesRatio == target.St_MonthSalesRatio)
                 && (this.Ed_MonthSalesRatio == target.Ed_MonthSalesRatio)
                 && (this.St_YearSalesRatio == target.St_YearSalesRatio)
                 && (this.Ed_YearSalesRatio == target.Ed_YearSalesRatio)
                 && (this.St_MonthGrossRatio == target.St_MonthGrossRatio)
                 && (this.Ed_MonthGrossRatio == target.Ed_MonthGrossRatio)
                 && (this.St_YearGrossRatio == target.St_YearGrossRatio)
                 && (this.Ed_YearGrossRatio == target.Ed_YearGrossRatio)
                 && (this.St_EmployeeCode == target.St_EmployeeCode)
                 && (this.Ed_EmployeeCode == target.Ed_EmployeeCode)
                 && (this.St_CustomerCode == target.St_CustomerCode)
                 && (this.Ed_CustomerCode == target.Ed_CustomerCode)
                 && (this.St_SalesAreaCode == target.St_SalesAreaCode)
                 && (this.Ed_SalesAreaCode == target.Ed_SalesAreaCode)
                 && (this.St_BusinessTypeCode == target.St_BusinessTypeCode)
                 && (this.Ed_BusinessTypeCode == target.Ed_BusinessTypeCode)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.SortOrder == target.SortOrder)
                 && (this.PrintType == target.PrintType)
                 && (this.NewPage == target.NewPage)
                 && (this.NewPage2 == target.NewPage2)
                 && (this.IssueType == target.IssueType)
                 && (this.St_BLGoodsCode == target.St_BLGoodsCode)
                 && (this.Ed_BLGoodsCode == target.Ed_BLGoodsCode)
                 && (this.St_GoodsLGroup == target.St_GoodsLGroup)
                 && (this.Ed_GoodsLGroup == target.Ed_GoodsLGroup)
                 && (this.St_GoodsMGroup == target.St_GoodsMGroup)
                 && (this.Ed_GoodsMGroup == target.Ed_GoodsMGroup)
                 && (this.St_BLGroupCode == target.St_BLGroupCode)
                 && (this.Ed_BLGroupCode == target.Ed_BLGroupCode)
                 && (this.St_MonthSalesRatio_ck == target.St_MonthSalesRatio_ck)
                 && (this.Ed_MonthSalesRatio_ck == target.Ed_MonthSalesRatio_ck)
                 && (this.St_YearSalesRatio_ck == target.St_YearSalesRatio_ck)
                 && (this.Ed_YearSalesRatio_ck == target.Ed_YearSalesRatio_ck)
                 && (this.St_MonthGrossRatio_ck == target.St_MonthGrossRatio_ck)
                 && (this.Ed_MonthGrossRatio_ck == target.Ed_MonthGrossRatio_ck)
                 && (this.St_YearGrossRatio_ck == target.St_YearGrossRatio_ck)
                 && (this.Ed_YearGrossRatio_ck == target.Ed_YearGrossRatio_ck)
                 );
        }

		/// <summary>
		/// �O�N�Δ�\���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_DCTOK02093E1">
		///                    ��r����ExtrInfo_DCTOK02093E�N���X�̃C���X�^���X
		/// </param>
		/// <param name="extrInfo_DCTOK02093E2">��r����ExtrInfo_DCTOK02093E�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DCTOK02093E�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public static bool Equals(ExtrInfo_DCTOK02093E extrInfo_DCTOK02093E1, ExtrInfo_DCTOK02093E extrInfo_DCTOK02093E2)
        {
            return (
                (extrInfo_DCTOK02093E1.EnterpriseCode == extrInfo_DCTOK02093E2.EnterpriseCode)
                 && (extrInfo_DCTOK02093E1.SecCodeList == extrInfo_DCTOK02093E2.SecCodeList)
                 && (extrInfo_DCTOK02093E1.TotalWay == extrInfo_DCTOK02093E2.TotalWay)
                 && (extrInfo_DCTOK02093E1.ListType == extrInfo_DCTOK02093E2.ListType)
                 && (extrInfo_DCTOK02093E1.MoneyUnit == extrInfo_DCTOK02093E2.MoneyUnit)
                 && (extrInfo_DCTOK02093E1.St_AddUpYearMonth == extrInfo_DCTOK02093E2.St_AddUpYearMonth)
                 && (extrInfo_DCTOK02093E1.Ed_AddUpYearMonth == extrInfo_DCTOK02093E2.Ed_AddUpYearMonth)
                 && (extrInfo_DCTOK02093E1.St_MonthSalesRatio == extrInfo_DCTOK02093E2.St_MonthSalesRatio)
                 && (extrInfo_DCTOK02093E1.Ed_MonthSalesRatio == extrInfo_DCTOK02093E2.Ed_MonthSalesRatio)
                 && (extrInfo_DCTOK02093E1.St_YearSalesRatio == extrInfo_DCTOK02093E2.St_YearSalesRatio)
                 && (extrInfo_DCTOK02093E1.Ed_YearSalesRatio == extrInfo_DCTOK02093E2.Ed_YearSalesRatio)
                 && (extrInfo_DCTOK02093E1.St_MonthGrossRatio == extrInfo_DCTOK02093E2.St_MonthGrossRatio)
                 && (extrInfo_DCTOK02093E1.Ed_MonthGrossRatio == extrInfo_DCTOK02093E2.Ed_MonthGrossRatio)
                 && (extrInfo_DCTOK02093E1.St_YearGrossRatio == extrInfo_DCTOK02093E2.St_YearGrossRatio)
                 && (extrInfo_DCTOK02093E1.Ed_YearGrossRatio == extrInfo_DCTOK02093E2.Ed_YearGrossRatio)
                 && (extrInfo_DCTOK02093E1.St_EmployeeCode == extrInfo_DCTOK02093E2.St_EmployeeCode)
                 && (extrInfo_DCTOK02093E1.Ed_EmployeeCode == extrInfo_DCTOK02093E2.Ed_EmployeeCode)
                 && (extrInfo_DCTOK02093E1.St_CustomerCode == extrInfo_DCTOK02093E2.St_CustomerCode)
                 && (extrInfo_DCTOK02093E1.Ed_CustomerCode == extrInfo_DCTOK02093E2.Ed_CustomerCode)
                 && (extrInfo_DCTOK02093E1.St_SalesAreaCode == extrInfo_DCTOK02093E2.St_SalesAreaCode)
                 && (extrInfo_DCTOK02093E1.Ed_SalesAreaCode == extrInfo_DCTOK02093E2.Ed_SalesAreaCode)
                 && (extrInfo_DCTOK02093E1.St_BusinessTypeCode == extrInfo_DCTOK02093E2.St_BusinessTypeCode)
                 && (extrInfo_DCTOK02093E1.Ed_BusinessTypeCode == extrInfo_DCTOK02093E2.Ed_BusinessTypeCode)
                 && (extrInfo_DCTOK02093E1.EnterpriseName == extrInfo_DCTOK02093E2.EnterpriseName)
                 && (extrInfo_DCTOK02093E1.SortOrder == extrInfo_DCTOK02093E2.SortOrder)
                 && (extrInfo_DCTOK02093E1.PrintType == extrInfo_DCTOK02093E2.PrintType)
                 && (extrInfo_DCTOK02093E1.NewPage == extrInfo_DCTOK02093E2.NewPage)
                 && (extrInfo_DCTOK02093E1.NewPage2 == extrInfo_DCTOK02093E2.NewPage2)
                 && (extrInfo_DCTOK02093E1.IssueType == extrInfo_DCTOK02093E2.IssueType)
                 && (extrInfo_DCTOK02093E1.St_BLGoodsCode == extrInfo_DCTOK02093E2.St_BLGoodsCode)
                 && (extrInfo_DCTOK02093E1.Ed_BLGoodsCode == extrInfo_DCTOK02093E2.Ed_BLGoodsCode)
                 && (extrInfo_DCTOK02093E1.St_GoodsLGroup == extrInfo_DCTOK02093E2.St_GoodsLGroup)
                 && (extrInfo_DCTOK02093E1.Ed_GoodsLGroup == extrInfo_DCTOK02093E2.Ed_GoodsLGroup)
                 && (extrInfo_DCTOK02093E1.St_GoodsMGroup == extrInfo_DCTOK02093E2.St_GoodsMGroup)
                 && (extrInfo_DCTOK02093E1.Ed_GoodsMGroup == extrInfo_DCTOK02093E2.Ed_GoodsMGroup)
                 && (extrInfo_DCTOK02093E1.St_BLGroupCode == extrInfo_DCTOK02093E2.St_BLGroupCode)
                 && (extrInfo_DCTOK02093E1.Ed_BLGroupCode == extrInfo_DCTOK02093E2.Ed_BLGroupCode)
                 && (extrInfo_DCTOK02093E1.St_MonthSalesRatio_ck == extrInfo_DCTOK02093E2.St_MonthSalesRatio_ck)
                 && (extrInfo_DCTOK02093E1.Ed_MonthSalesRatio_ck == extrInfo_DCTOK02093E2.Ed_MonthSalesRatio_ck)
                 && (extrInfo_DCTOK02093E1.St_YearSalesRatio_ck == extrInfo_DCTOK02093E2.St_YearSalesRatio_ck)
                 && (extrInfo_DCTOK02093E1.Ed_YearSalesRatio_ck == extrInfo_DCTOK02093E2.Ed_YearSalesRatio_ck)
                 && (extrInfo_DCTOK02093E1.St_MonthGrossRatio_ck == extrInfo_DCTOK02093E2.St_MonthGrossRatio_ck)
                 && (extrInfo_DCTOK02093E1.Ed_MonthGrossRatio_ck == extrInfo_DCTOK02093E2.Ed_MonthGrossRatio_ck)
                 && (extrInfo_DCTOK02093E1.St_YearGrossRatio_ck == extrInfo_DCTOK02093E2.St_YearGrossRatio_ck)
                 && (extrInfo_DCTOK02093E1.Ed_YearGrossRatio_ck == extrInfo_DCTOK02093E2.Ed_YearGrossRatio_ck)
                 );
        }
		/// <summary>
		/// �O�N�Δ�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_DCTOK02093E�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DCTOK02093E�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public ArrayList Compare(ExtrInfo_DCTOK02093E target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SecCodeList != target.SecCodeList) resList.Add("SecCodeList");
            if (this.TotalWay != target.TotalWay) resList.Add("TotalWay");
            if (this.ListType != target.ListType) resList.Add("ListType");
            if (this.MoneyUnit != target.MoneyUnit) resList.Add("MoneyUnit");
            if (this.St_AddUpYearMonth != target.St_AddUpYearMonth) resList.Add("St_AddUpYearMonth");
            if (this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth) resList.Add("Ed_AddUpYearMonth");
            if (this.St_MonthSalesRatio != target.St_MonthSalesRatio) resList.Add("St_MonthSalesRatio");
            if (this.Ed_MonthSalesRatio != target.Ed_MonthSalesRatio) resList.Add("Ed_MonthSalesRatio");
            if (this.St_YearSalesRatio != target.St_YearSalesRatio) resList.Add("St_YearSalesRatio");
            if (this.Ed_YearSalesRatio != target.Ed_YearSalesRatio) resList.Add("Ed_YearSalesRatio");
            if (this.St_MonthGrossRatio != target.St_MonthGrossRatio) resList.Add("St_MonthGrossRatio");
            if (this.Ed_MonthGrossRatio != target.Ed_MonthGrossRatio) resList.Add("Ed_MonthGrossRatio");
            if (this.St_YearGrossRatio != target.St_YearGrossRatio) resList.Add("St_YearGrossRatio");
            if (this.Ed_YearGrossRatio != target.Ed_YearGrossRatio) resList.Add("Ed_YearGrossRatio");
            if (this.St_EmployeeCode != target.St_EmployeeCode) resList.Add("St_EmployeeCode");
            if (this.Ed_EmployeeCode != target.Ed_EmployeeCode) resList.Add("Ed_EmployeeCode");
            if (this.St_CustomerCode != target.St_CustomerCode) resList.Add("St_CustomerCode");
            if (this.Ed_CustomerCode != target.Ed_CustomerCode) resList.Add("Ed_CustomerCode");
            if (this.St_SalesAreaCode != target.St_SalesAreaCode) resList.Add("St_SalesAreaCode");
            if (this.Ed_SalesAreaCode != target.Ed_SalesAreaCode) resList.Add("Ed_SalesAreaCode");
            if (this.St_BusinessTypeCode != target.St_BusinessTypeCode) resList.Add("St_BusinessTypeCode");
            if (this.Ed_BusinessTypeCode != target.Ed_BusinessTypeCode) resList.Add("Ed_BusinessTypeCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");
            if (this.PrintType != target.PrintType) resList.Add("PrintType");
            if (this.NewPage != target.NewPage) resList.Add("NewPage");
            if (this.NewPage2 != target.NewPage2) resList.Add("NewPage2");
            if (this.IssueType != target.IssueType) resList.Add("IssueType");
            if (this.St_BLGoodsCode != target.St_BLGoodsCode) resList.Add("St_BLGoodsCode");
            if (this.Ed_BLGoodsCode != target.Ed_BLGoodsCode) resList.Add("Ed_BLGoodsCode");
            if (this.St_GoodsLGroup != target.St_GoodsLGroup) resList.Add("St_GoodsLGroup");
            if (this.Ed_GoodsLGroup != target.Ed_GoodsLGroup) resList.Add("Ed_GoodsLGroup");
            if (this.St_GoodsMGroup != target.St_GoodsMGroup) resList.Add("St_GoodsMGroup");
            if (this.Ed_GoodsMGroup != target.Ed_GoodsMGroup) resList.Add("Ed_GoodsMGroup");
            if (this.St_BLGroupCode != target.St_BLGroupCode) resList.Add("St_BLGroupCode");
            if (this.Ed_BLGroupCode != target.Ed_BLGroupCode) resList.Add("Ed_BLGroupCode");
            if (this.St_MonthSalesRatio_ck != target.St_MonthSalesRatio_ck) resList.Add("St_MonthSalesRatio_ck");
            if (this.Ed_MonthSalesRatio_ck != target.Ed_MonthSalesRatio_ck) resList.Add("Ed_MonthSalesRatio_ck");
            if (this.St_YearSalesRatio_ck != target.St_YearSalesRatio_ck) resList.Add("St_YearSalesRatio_ck");
            if (this.Ed_YearSalesRatio_ck != target.Ed_YearSalesRatio_ck) resList.Add("Ed_YearSalesRatio_ck");
            if (this.St_MonthGrossRatio_ck != target.St_MonthGrossRatio_ck) resList.Add("St_MonthGrossRatio_ck");
            if (this.Ed_MonthGrossRatio_ck != target.Ed_MonthGrossRatio_ck) resList.Add("Ed_MonthGrossRatio_ck");
            if (this.St_YearGrossRatio_ck != target.St_YearGrossRatio_ck) resList.Add("St_YearGrossRatio_ck");
            if (this.Ed_YearGrossRatio_ck != target.Ed_YearGrossRatio_ck) resList.Add("Ed_YearGrossRatio_ck");
            return resList;
        }

		/// <summary>
		/// �O�N�Δ�\���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_DCTOK02093E1">��r����ExtrInfo_DCTOK02093E�N���X�̃C���X�^���X</param>
		/// <param name="extrInfo_DCTOK02093E2">��r����ExtrInfo_DCTOK02093E�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DCTOK02093E�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public static ArrayList Compare(ExtrInfo_DCTOK02093E extrInfo_DCTOK02093E1, ExtrInfo_DCTOK02093E extrInfo_DCTOK02093E2)
        {
            ArrayList resList = new ArrayList();
            if (extrInfo_DCTOK02093E1.EnterpriseCode != extrInfo_DCTOK02093E2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (extrInfo_DCTOK02093E1.SecCodeList != extrInfo_DCTOK02093E2.SecCodeList) resList.Add("SecCodeList");
            if (extrInfo_DCTOK02093E1.TotalWay != extrInfo_DCTOK02093E2.TotalWay) resList.Add("TotalWay");
            if (extrInfo_DCTOK02093E1.ListType != extrInfo_DCTOK02093E2.ListType) resList.Add("ListType");
            if (extrInfo_DCTOK02093E1.MoneyUnit != extrInfo_DCTOK02093E2.MoneyUnit) resList.Add("MoneyUnit");
            if (extrInfo_DCTOK02093E1.St_AddUpYearMonth != extrInfo_DCTOK02093E2.St_AddUpYearMonth) resList.Add("St_AddUpYearMonth");
            if (extrInfo_DCTOK02093E1.Ed_AddUpYearMonth != extrInfo_DCTOK02093E2.Ed_AddUpYearMonth) resList.Add("Ed_AddUpYearMonth");
            if (extrInfo_DCTOK02093E1.St_MonthSalesRatio != extrInfo_DCTOK02093E2.St_MonthSalesRatio) resList.Add("St_MonthSalesRatio");
            if (extrInfo_DCTOK02093E1.Ed_MonthSalesRatio != extrInfo_DCTOK02093E2.Ed_MonthSalesRatio) resList.Add("Ed_MonthSalesRatio");
            if (extrInfo_DCTOK02093E1.St_YearSalesRatio != extrInfo_DCTOK02093E2.St_YearSalesRatio) resList.Add("St_YearSalesRatio");
            if (extrInfo_DCTOK02093E1.Ed_YearSalesRatio != extrInfo_DCTOK02093E2.Ed_YearSalesRatio) resList.Add("Ed_YearSalesRatio");
            if (extrInfo_DCTOK02093E1.St_MonthGrossRatio != extrInfo_DCTOK02093E2.St_MonthGrossRatio) resList.Add("St_MonthGrossRatio");
            if (extrInfo_DCTOK02093E1.Ed_MonthGrossRatio != extrInfo_DCTOK02093E2.Ed_MonthGrossRatio) resList.Add("Ed_MonthGrossRatio");
            if (extrInfo_DCTOK02093E1.St_YearGrossRatio != extrInfo_DCTOK02093E2.St_YearGrossRatio) resList.Add("St_YearGrossRatio");
            if (extrInfo_DCTOK02093E1.Ed_YearGrossRatio != extrInfo_DCTOK02093E2.Ed_YearGrossRatio) resList.Add("Ed_YearGrossRatio");
            if (extrInfo_DCTOK02093E1.St_EmployeeCode != extrInfo_DCTOK02093E2.St_EmployeeCode) resList.Add("St_EmployeeCode");
            if (extrInfo_DCTOK02093E1.Ed_EmployeeCode != extrInfo_DCTOK02093E2.Ed_EmployeeCode) resList.Add("Ed_EmployeeCode");
            if (extrInfo_DCTOK02093E1.St_CustomerCode != extrInfo_DCTOK02093E2.St_CustomerCode) resList.Add("St_CustomerCode");
            if (extrInfo_DCTOK02093E1.Ed_CustomerCode != extrInfo_DCTOK02093E2.Ed_CustomerCode) resList.Add("Ed_CustomerCode");
            if (extrInfo_DCTOK02093E1.St_SalesAreaCode != extrInfo_DCTOK02093E2.St_SalesAreaCode) resList.Add("St_SalesAreaCode");
            if (extrInfo_DCTOK02093E1.Ed_SalesAreaCode != extrInfo_DCTOK02093E2.Ed_SalesAreaCode) resList.Add("Ed_SalesAreaCode");
            if (extrInfo_DCTOK02093E1.St_BusinessTypeCode != extrInfo_DCTOK02093E2.St_BusinessTypeCode) resList.Add("St_BusinessTypeCode");
            if (extrInfo_DCTOK02093E1.Ed_BusinessTypeCode != extrInfo_DCTOK02093E2.Ed_BusinessTypeCode) resList.Add("Ed_BusinessTypeCode");
            if (extrInfo_DCTOK02093E1.EnterpriseName != extrInfo_DCTOK02093E2.EnterpriseName) resList.Add("EnterpriseName");
            if (extrInfo_DCTOK02093E1.SortOrder != extrInfo_DCTOK02093E2.SortOrder) resList.Add("SortOrder");
            if (extrInfo_DCTOK02093E1.PrintType != extrInfo_DCTOK02093E2.PrintType) resList.Add("PrintType");
            if (extrInfo_DCTOK02093E1.NewPage != extrInfo_DCTOK02093E2.NewPage) resList.Add("NewPage");
            if (extrInfo_DCTOK02093E1.NewPage2 != extrInfo_DCTOK02093E2.NewPage2) resList.Add("NewPage2");
            if (extrInfo_DCTOK02093E1.IssueType != extrInfo_DCTOK02093E2.IssueType) resList.Add("IssueType");
            if (extrInfo_DCTOK02093E1.St_BLGoodsCode != extrInfo_DCTOK02093E2.St_BLGoodsCode) resList.Add("St_BLGoodsCode");
            if (extrInfo_DCTOK02093E1.Ed_BLGoodsCode != extrInfo_DCTOK02093E2.Ed_BLGoodsCode) resList.Add("Ed_BLGoodsCode");
            if (extrInfo_DCTOK02093E1.St_GoodsLGroup != extrInfo_DCTOK02093E2.St_GoodsLGroup) resList.Add("St_GoodsLGroup");
            if (extrInfo_DCTOK02093E1.Ed_GoodsLGroup != extrInfo_DCTOK02093E2.Ed_GoodsLGroup) resList.Add("Ed_GoodsLGroup");
            if (extrInfo_DCTOK02093E1.St_GoodsMGroup != extrInfo_DCTOK02093E2.St_GoodsMGroup) resList.Add("St_GoodsMGroup");
            if (extrInfo_DCTOK02093E1.Ed_GoodsMGroup != extrInfo_DCTOK02093E2.Ed_GoodsMGroup) resList.Add("Ed_GoodsMGroup");
            if (extrInfo_DCTOK02093E1.St_BLGroupCode != extrInfo_DCTOK02093E2.St_BLGroupCode) resList.Add("St_BLGroupCode");
            if (extrInfo_DCTOK02093E1.Ed_BLGroupCode != extrInfo_DCTOK02093E2.Ed_BLGroupCode) resList.Add("Ed_BLGroupCode");
            if (extrInfo_DCTOK02093E1.St_MonthSalesRatio_ck != extrInfo_DCTOK02093E2.St_MonthSalesRatio_ck) resList.Add("St_MonthSalesRatio_ck");
            if (extrInfo_DCTOK02093E1.Ed_MonthSalesRatio_ck != extrInfo_DCTOK02093E2.Ed_MonthSalesRatio_ck) resList.Add("Ed_MonthSalesRatio_ck");
            if (extrInfo_DCTOK02093E1.St_YearSalesRatio_ck != extrInfo_DCTOK02093E2.St_YearSalesRatio_ck) resList.Add("St_YearSalesRatio_ck");
            if (extrInfo_DCTOK02093E1.Ed_YearSalesRatio_ck != extrInfo_DCTOK02093E2.Ed_YearSalesRatio_ck) resList.Add("Ed_YearSalesRatio_ck");
            if (extrInfo_DCTOK02093E1.St_MonthGrossRatio_ck != extrInfo_DCTOK02093E2.St_MonthGrossRatio_ck) resList.Add("St_MonthGrossRatio_ck");
            if (extrInfo_DCTOK02093E1.Ed_MonthGrossRatio_ck != extrInfo_DCTOK02093E2.Ed_MonthGrossRatio_ck) resList.Add("Ed_MonthGrossRatio_ck");
            if (extrInfo_DCTOK02093E1.St_YearGrossRatio_ck != extrInfo_DCTOK02093E2.St_YearGrossRatio_ck) resList.Add("St_YearGrossRatio_ck");
            if (extrInfo_DCTOK02093E1.Ed_YearGrossRatio_ck != extrInfo_DCTOK02093E2.Ed_YearGrossRatio_ck) resList.Add("Ed_YearGrossRatio_ck");

            return resList;
        }
	}
}

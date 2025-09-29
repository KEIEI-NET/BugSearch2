using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SuppPrtPprBlnce
	/// <summary>
	///                      �d����d�q������������(�c���ꗗ)
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d����d�q������������(�c���ꗗ)�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/07/20 chenyd</br>
    /// <br>           �@        �e�L�X�g�o�͑Ή�</br>
	/// </remarks>
	public class SuppPrtPprBlnce
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _sectionCode;

		/// <summary>�d����R�[�h</summary>
		private Int32 _supplierCd;
        // ---------------------- ADD 2010/07/20 -------------->>>>>
        /// <summary>�J�n�d����R�[�h</summary>
        private Int32 _st_supplierCd;

        /// <summary>�I���d����R�[�h</summary>
        private Int32 _ed_supplierCd;
        // ---------------------- ADD 2010/07/20 ---------------<<<<<
        /// <summary>�����敪</summary>
        private Int32 _searchDiv;

		/// <summary>�x����R�[�h</summary>
		private Int32 _payeeCode;

		/// <summary>�J�n�Ώ۔N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>�I���Ώ۔N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _ed_AddUpYearMonth;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";


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

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>(�z��)�@�S�Ўw���{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>�d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}
        // ---------------------- ADD 2010/07/20 --------------->>>>>
        /// public propaty name  :  St_SupplierCd
        /// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SupplierCd
        {
            get { return _st_supplierCd; }
            set { _st_supplierCd = value; }
        }

        /// public propaty name  :  Ed_SupplierCd
        /// <summary>�I���d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SupplierCd
        {
            get { return _ed_supplierCd; }
            set { _ed_supplierCd = value; }
        }
        // ---------------------- ADD 2010/07/20 ---------------<<<<<
        /// public propaty name  :  SearchDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchDiv
        {
            get { return _searchDiv; }
            set { _searchDiv = value; }
        }

		/// public propaty name  :  PayeeCode
		/// <summary>�x����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �x����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PayeeCode
		{
			get{return _payeeCode;}
			set{_payeeCode = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>�J�n�Ώ۔N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ώ۔N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>�I���Ώ۔N���v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ώ۔N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
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
		/// �d����d�q������������(�c���ꗗ)�R���X�g���N�^
		/// </summary>
		/// <returns>SuppPrtPprBlnce�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlnce�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SuppPrtPprBlnce()
		{
		}

		/// <summary>
		/// �d����d�q������������(�c���ꗗ)�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="sectionCode">���_�R�[�h((�z��)�@�S�Ўw���{""})</param>
		/// <param name="supplierCd">�d����R�[�h</param>
		/// <param name="payeeCode">�x����R�[�h</param>
		/// <param name="st_AddUpYearMonth">�J�n�Ώ۔N��(YYYYMM)</param>
		/// <param name="ed_AddUpYearMonth">�I���Ώ۔N��(YYYYMM)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>SuppPrtPprBlnce�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlnce�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public SuppPrtPprBlnce(string enterpriseCode, string[] sectionCode, Int32 supplierCd, Int32 payeeCode, DateTime st_AddUpYearMonth, DateTime ed_AddUpYearMonth, string enterpriseName)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._supplierCd = supplierCd;
			this._payeeCode = payeeCode;
			this._st_AddUpYearMonth = st_AddUpYearMonth;
			this._ed_AddUpYearMonth = ed_AddUpYearMonth;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// �d����d�q������������(�c���ꗗ)��������
		/// </summary>
		/// <returns>SuppPrtPprBlnce�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SuppPrtPprBlnce�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SuppPrtPprBlnce Clone()
		{
			return new SuppPrtPprBlnce(this._enterpriseCode,this._sectionCode,this._supplierCd,this._payeeCode,this._st_AddUpYearMonth,this._ed_AddUpYearMonth,this._enterpriseName);
		}

		/// <summary>
		/// �d����d�q������������(�c���ꗗ)��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SuppPrtPprBlnce�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlnce�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SuppPrtPprBlnce target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.PayeeCode == target.PayeeCode)
				 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
				 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// �d����d�q������������(�c���ꗗ)��r����
		/// </summary>
		/// <param name="suppPrtPprBlnce1">
		///                    ��r����SuppPrtPprBlnce�N���X�̃C���X�^���X
		/// </param>
		/// <param name="suppPrtPprBlnce2">��r����SuppPrtPprBlnce�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlnce�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SuppPrtPprBlnce suppPrtPprBlnce1, SuppPrtPprBlnce suppPrtPprBlnce2)
		{
			return ((suppPrtPprBlnce1.EnterpriseCode == suppPrtPprBlnce2.EnterpriseCode)
				 && (suppPrtPprBlnce1.SectionCode == suppPrtPprBlnce2.SectionCode)
				 && (suppPrtPprBlnce1.SupplierCd == suppPrtPprBlnce2.SupplierCd)
				 && (suppPrtPprBlnce1.PayeeCode == suppPrtPprBlnce2.PayeeCode)
				 && (suppPrtPprBlnce1.St_AddUpYearMonth == suppPrtPprBlnce2.St_AddUpYearMonth)
				 && (suppPrtPprBlnce1.Ed_AddUpYearMonth == suppPrtPprBlnce2.Ed_AddUpYearMonth)
				 && (suppPrtPprBlnce1.EnterpriseName == suppPrtPprBlnce2.EnterpriseName));
		}
		/// <summary>
		/// �d����d�q������������(�c���ꗗ)��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SuppPrtPprBlnce�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlnce�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SuppPrtPprBlnce target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.PayeeCode != target.PayeeCode)resList.Add("PayeeCode");
			if(this.St_AddUpYearMonth != target.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// �d����d�q������������(�c���ꗗ)��r����
		/// </summary>
		/// <param name="suppPrtPprBlnce1">��r����SuppPrtPprBlnce�N���X�̃C���X�^���X</param>
		/// <param name="suppPrtPprBlnce2">��r����SuppPrtPprBlnce�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SuppPrtPprBlnce�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SuppPrtPprBlnce suppPrtPprBlnce1, SuppPrtPprBlnce suppPrtPprBlnce2)
		{
			ArrayList resList = new ArrayList();
			if(suppPrtPprBlnce1.EnterpriseCode != suppPrtPprBlnce2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(suppPrtPprBlnce1.SectionCode != suppPrtPprBlnce2.SectionCode)resList.Add("SectionCode");
			if(suppPrtPprBlnce1.SupplierCd != suppPrtPprBlnce2.SupplierCd)resList.Add("SupplierCd");
			if(suppPrtPprBlnce1.PayeeCode != suppPrtPprBlnce2.PayeeCode)resList.Add("PayeeCode");
			if(suppPrtPprBlnce1.St_AddUpYearMonth != suppPrtPprBlnce2.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(suppPrtPprBlnce1.Ed_AddUpYearMonth != suppPrtPprBlnce2.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(suppPrtPprBlnce1.EnterpriseName != suppPrtPprBlnce2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustPrtPprBlnce
	/// <summary>
	///                      ���Ӑ�d�q������������(�c���ꗗ)
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ӑ�d�q������������(�c���ꗗ)�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2012/06/01 30744 ���� ����q ���͋��_�R�[�h�A���_���̂̒ǉ�</br>
    /// <br>Update Note      :   2013/03/13 30744 ���� ����q �^�M�c���̏o�̓t���O��ǉ�</br>
    /// <br>Update Note      :   </br>
	/// </remarks>
	public class CustPrtPprBlnce
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
		private string[] _sectionCode;

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>������R�[�h</summary>
		private Int32 _claimCode;

		/// <summary>�J�n�Ώ۔N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>�I���Ώ۔N��</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _ed_AddUpYearMonth;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        // ADD 2012/06/01 ----------------------->>>>>
        /// <summary>���͋��_�R�[�h</summary>
        private string _inputSectionCode = "";

        /// <summary>���͋��_����</summary>
        private string _inputSectionName = "";

        /// <summary>���o���_���</summary>
        private Int32 _remainSectionType;
        // ADD 2012/06/01 -----------------------<<<<<
        // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
        /// <summary>�^�M�c���o�̓t���O</summary>
        private bool _creditMoneyOutputDiv;
        /// <summary>���͊J�n�N��</summary>
        private DateTime _input_St_AddUpYearMonth;
        // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<




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

		/// public propaty name  :  ClaimCode
		/// <summary>������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ClaimCode
		{
			get{return _claimCode;}
			set{_claimCode = value;}
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


        // ADD 2012/06/01 ----------------------->>>>>
        /// public propaty name  :  InputSectionCode
        /// <summary>���͋��_�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputSectionCode
        {
            get { return _inputSectionCode; }
            set { _inputSectionCode = value; }
        }

        /// public propaty name  :  InputSectionName
        /// <summary>���͋��_����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputSectionName
        {
            get { return _inputSectionName; }
            set { _inputSectionName = value; }
        }

        /// public propaty name  :  RemainSectionType
        /// <summary>���o���_���</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o���_��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RemainSectionType
        {
            get { return _remainSectionType; }
            set { _remainSectionType = value; }
        }

        // ADD 2012/06/01 -----------------------<<<<<

        // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
        /// public propaty name  :  CreditMoneyOutputDiv
        /// <summary>�^�M�c���o�̓t���O</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�M�c���o�̓t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool CreditMoneyOutputDiv
        {
            get { return _creditMoneyOutputDiv; }
            set { _creditMoneyOutputDiv = value; }
        }

        /// public propaty name  :  Input_St_AddUpYearMonth
        /// <summary>���͊J�n�N��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͊J�n�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Input_St_AddUpYearMonth
        {
            get { return _input_St_AddUpYearMonth; }
            set { _input_St_AddUpYearMonth = value; }
        }
        
        // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

		/// <summary>
		/// ���Ӑ�d�q������������(�c���ꗗ)�R���X�g���N�^
		/// </summary>
		/// <returns>CustPrtPprBlnce�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlnce�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustPrtPprBlnce()
		{
		}

		/// <summary>
		/// ���Ӑ�d�q������������(�c���ꗗ)�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="sectionCode">���_�R�[�h((�z��)�@�S�Ўw���{""})</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="claimCode">������R�[�h</param>
		/// <param name="st_AddUpYearMonth">�J�n�Ώ۔N��(YYYYMM)</param>
		/// <param name="ed_AddUpYearMonth">�I���Ώ۔N��(YYYYMM)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>CustPrtPprBlnce�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlnce�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        // UPD 2012/06/01 ----------------------->>>>>
        //public CustPrtPprBlnce(string enterpriseCode, string[] sectionCode, Int32 customerCode, Int32 claimCode, DateTime st_AddUpYearMonth, DateTime ed_AddUpYearMonth, string enterpriseName)
        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
        //public CustPrtPprBlnce(string enterpriseCode, string[] sectionCode, Int32 customerCode, Int32 claimCode, DateTime st_AddUpYearMonth, DateTime ed_AddUpYearMonth, string enterpriseName, string inputSectionCode, string inputSectionName, int remainSectionType)
        public CustPrtPprBlnce(string enterpriseCode, string[] sectionCode, Int32 customerCode, Int32 claimCode, DateTime st_AddUpYearMonth, DateTime ed_AddUpYearMonth, string enterpriseName, string inputSectionCode, string inputSectionName, int remainSectionType, bool creditMoneyOutputDiv, DateTime input_St_AddUpYearMonth)
        // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
        // UPD 2012/06/01 -----------------------<<<<<
        {
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._customerCode = customerCode;
			this._claimCode = claimCode;
			this._st_AddUpYearMonth = st_AddUpYearMonth;
			this._ed_AddUpYearMonth = ed_AddUpYearMonth;
			this._enterpriseName = enterpriseName;
            // ADD 2012/06/01 ----------------------->>>>>
            this._inputSectionCode = inputSectionCode;
            this._inputSectionName = inputSectionName;
            this._remainSectionType = remainSectionType;
            // ADD 2012/06/01 -----------------------<<<<<
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            this._creditMoneyOutputDiv = creditMoneyOutputDiv;
            this.Input_St_AddUpYearMonth = input_St_AddUpYearMonth;
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

        }

		/// <summary>
		/// ���Ӑ�d�q������������(�c���ꗗ)��������
		/// </summary>
		/// <returns>CustPrtPprBlnce�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustPrtPprBlnce�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustPrtPprBlnce Clone()
		{
            // UPD 2012/06/01 ----------------------->>>>>
			//return new CustPrtPprBlnce(this._enterpriseCode,this._sectionCode,this._customerCode,this._claimCode,this._st_AddUpYearMonth,this._ed_AddUpYearMonth,this._enterpriseName);
            // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            //return new CustPrtPprBlnce(this._enterpriseCode, this._sectionCode, this._customerCode, this._claimCode, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._enterpriseName, this._inputSectionCode, this._inputSectionName, this._remainSectionType);
            return new CustPrtPprBlnce(this._enterpriseCode, this._sectionCode, this._customerCode, this._claimCode, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._enterpriseName, this._inputSectionCode, this._inputSectionName, this._remainSectionType, this._creditMoneyOutputDiv, this.Input_St_AddUpYearMonth);
            // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
            // UPD 2012/06/01 -----------------------<<<<<
        }

		/// <summary>
		/// ���Ӑ�d�q������������(�c���ꗗ)��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustPrtPprBlnce�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlnce�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(CustPrtPprBlnce target)
		{
            // UPD 2012/06/01 ----------------------->>>>>
            //return ((this.EnterpriseCode == target.EnterpriseCode)
            //     && (this.SectionCode == target.SectionCode)
            //     && (this.CustomerCode == target.CustomerCode)
            //     && (this.ClaimCode == target.ClaimCode)
            //     && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
            //     && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
            //     && (this.EnterpriseName == target.EnterpriseName));
            // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            //return ((this.EnterpriseCode == target.EnterpriseCode)
            //     && (this.SectionCode == target.SectionCode)
            //     && (this.CustomerCode == target.CustomerCode)
            //     && (this.ClaimCode == target.ClaimCode)
            //     && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
            //     && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
            //     && (this.EnterpriseName == target.EnterpriseName)
            //     && (this.InputSectionCode == target.InputSectionCode)
            //     && (this.InputSectionName == target.InputSectionName)
            //     && (this.RemainSectionType == target.RemainSectionType));
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
                 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.InputSectionCode == target.InputSectionCode)
                 && (this.InputSectionName == target.InputSectionName)
                 && (this.RemainSectionType == target.RemainSectionType)
                 && (this.CreditMoneyOutputDiv == target.CreditMoneyOutputDiv)
                 && (this.Input_St_AddUpYearMonth == target.Input_St_AddUpYearMonth)
                 );
            // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
            // UPD 2012/06/01 -----------------------<<<<<
        }

		/// <summary>
		/// ���Ӑ�d�q������������(�c���ꗗ)��r����
		/// </summary>
		/// <param name="custPrtPprBlnce1">
		///                    ��r����CustPrtPprBlnce�N���X�̃C���X�^���X
		/// </param>
		/// <param name="custPrtPprBlnce2">��r����CustPrtPprBlnce�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlnce�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(CustPrtPprBlnce custPrtPprBlnce1, CustPrtPprBlnce custPrtPprBlnce2)
		{
            // UPD 2012/06/01 ----------------------->>>>>
            //return ((custPrtPprBlnce1.EnterpriseCode == custPrtPprBlnce2.EnterpriseCode)
            //     && (custPrtPprBlnce1.SectionCode == custPrtPprBlnce2.SectionCode)
            //     && (custPrtPprBlnce1.CustomerCode == custPrtPprBlnce2.CustomerCode)
            //     && (custPrtPprBlnce1.ClaimCode == custPrtPprBlnce2.ClaimCode)
            //     && (custPrtPprBlnce1.St_AddUpYearMonth == custPrtPprBlnce2.St_AddUpYearMonth)
            //     && (custPrtPprBlnce1.Ed_AddUpYearMonth == custPrtPprBlnce2.Ed_AddUpYearMonth)
            //     && (custPrtPprBlnce1.EnterpriseName == custPrtPprBlnce2.EnterpriseName));
            // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            //return ((custPrtPprBlnce1.EnterpriseCode == custPrtPprBlnce2.EnterpriseCode)
            //     && (custPrtPprBlnce1.SectionCode == custPrtPprBlnce2.SectionCode)
            //     && (custPrtPprBlnce1.CustomerCode == custPrtPprBlnce2.CustomerCode)
            //     && (custPrtPprBlnce1.ClaimCode == custPrtPprBlnce2.ClaimCode)
            //     && (custPrtPprBlnce1.St_AddUpYearMonth == custPrtPprBlnce2.St_AddUpYearMonth)
            //     && (custPrtPprBlnce1.Ed_AddUpYearMonth == custPrtPprBlnce2.Ed_AddUpYearMonth)
            //     && (custPrtPprBlnce1.EnterpriseName == custPrtPprBlnce2.EnterpriseName)
            //     && (custPrtPprBlnce1.InputSectionCode == custPrtPprBlnce2.InputSectionCode)
            //     && (custPrtPprBlnce1.InputSectionName == custPrtPprBlnce2.InputSectionName)
            //     && (custPrtPprBlnce1.RemainSectionType == custPrtPprBlnce2.RemainSectionType));
            return ((custPrtPprBlnce1.EnterpriseCode == custPrtPprBlnce2.EnterpriseCode)
                 && (custPrtPprBlnce1.SectionCode == custPrtPprBlnce2.SectionCode)
                 && (custPrtPprBlnce1.CustomerCode == custPrtPprBlnce2.CustomerCode)
                 && (custPrtPprBlnce1.ClaimCode == custPrtPprBlnce2.ClaimCode)
                 && (custPrtPprBlnce1.St_AddUpYearMonth == custPrtPprBlnce2.St_AddUpYearMonth)
                 && (custPrtPprBlnce1.Ed_AddUpYearMonth == custPrtPprBlnce2.Ed_AddUpYearMonth)
                 && (custPrtPprBlnce1.EnterpriseName == custPrtPprBlnce2.EnterpriseName)
                 && (custPrtPprBlnce1.InputSectionCode == custPrtPprBlnce2.InputSectionCode)
                 && (custPrtPprBlnce1.InputSectionName == custPrtPprBlnce2.InputSectionName)
                 && (custPrtPprBlnce1.RemainSectionType == custPrtPprBlnce2.RemainSectionType)
                 && (custPrtPprBlnce1.CreditMoneyOutputDiv == custPrtPprBlnce2.CreditMoneyOutputDiv)
                 && (custPrtPprBlnce1.Input_St_AddUpYearMonth == custPrtPprBlnce2.Input_St_AddUpYearMonth)
                 );
            // UPD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<
            // UPD 2012/06/01 -----------------------<<<<<
        }
		/// <summary>
		/// ���Ӑ�d�q������������(�c���ꗗ)��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustPrtPprBlnce�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlnce�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(CustPrtPprBlnce target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.ClaimCode != target.ClaimCode)resList.Add("ClaimCode");
			if(this.St_AddUpYearMonth != target.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            // ADD 2012/06/01 ----------------------->>>>>
            if(this.InputSectionCode != target.InputSectionCode) resList.Add("InputSectionCode");
            if(this.InputSectionName != target.InputSectionName) resList.Add("InputSectionName");
            if(this.RemainSectionType != target.RemainSectionType) resList.Add("RemainSectionType");
            // ADD 2012/06/01 -----------------------<<<<<
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            if (this.CreditMoneyOutputDiv != target.CreditMoneyOutputDiv) resList.Add("CreditMoneyOutputDiv");
            if (this.Input_St_AddUpYearMonth != target.Input_St_AddUpYearMonth) resList.Add("Input_St_AddUpYearMonth");
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

			return resList;
		}

		/// <summary>
		/// ���Ӑ�d�q������������(�c���ꗗ)��r����
		/// </summary>
		/// <param name="custPrtPprBlnce1">��r����CustPrtPprBlnce�N���X�̃C���X�^���X</param>
		/// <param name="custPrtPprBlnce2">��r����CustPrtPprBlnce�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustPrtPprBlnce�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(CustPrtPprBlnce custPrtPprBlnce1, CustPrtPprBlnce custPrtPprBlnce2)
		{
			ArrayList resList = new ArrayList();
			if(custPrtPprBlnce1.EnterpriseCode != custPrtPprBlnce2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(custPrtPprBlnce1.SectionCode != custPrtPprBlnce2.SectionCode)resList.Add("SectionCode");
			if(custPrtPprBlnce1.CustomerCode != custPrtPprBlnce2.CustomerCode)resList.Add("CustomerCode");
			if(custPrtPprBlnce1.ClaimCode != custPrtPprBlnce2.ClaimCode)resList.Add("ClaimCode");
			if(custPrtPprBlnce1.St_AddUpYearMonth != custPrtPprBlnce2.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(custPrtPprBlnce1.Ed_AddUpYearMonth != custPrtPprBlnce2.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(custPrtPprBlnce1.EnterpriseName != custPrtPprBlnce2.EnterpriseName)resList.Add("EnterpriseName");
            // ADD 2012/06/01 ----------------------->>>>>
            if(custPrtPprBlnce1.InputSectionCode != custPrtPprBlnce2.InputSectionCode) resList.Add("InputSectionCode");
            if(custPrtPprBlnce1.InputSectionName != custPrtPprBlnce2.InputSectionName) resList.Add("InputSectionName");
            if(custPrtPprBlnce1.RemainSectionType != custPrtPprBlnce2.RemainSectionType) resList.Add("RemainSectionType");
            // ADD 2012/06/01 -----------------------<<<<<
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�----------------------------------------->>>>>
            if (custPrtPprBlnce1.CreditMoneyOutputDiv != custPrtPprBlnce2.CreditMoneyOutputDiv) resList.Add("CreditMoneyOutputDiv");
            if (custPrtPprBlnce1.Input_St_AddUpYearMonth != custPrtPprBlnce2.Input_St_AddUpYearMonth) resList.Add("Input_St_AddUpYearMonth");
            // ADD 2013/03/13 �_�P�Y��-�^�M���� �Ή�-----------------------------------------<<<<<

			return resList;
		}
	}
}

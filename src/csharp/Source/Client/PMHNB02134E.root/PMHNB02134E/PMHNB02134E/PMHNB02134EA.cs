using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustFinancialListCndtn
	/// <summary>
	///                      ���Ӑ�ߔN�x���v�\���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ӑ�ߔN�x���v�\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/31  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class CustFinancialListCndtn
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�v�㋒�_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string[] _addUpSecCodes;

		/// <summary>�J�n���Ӑ�R�[�h</summary>
		private Int32 _st_CustomerCode;

		/// <summary>�I�����Ӑ�R�[�h</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>�J�n�N�x</summary>
		private DateTime _st_Year;

		/// <summary>�I���N�x</summary>
		private DateTime _ed_Year;

		/// <summary>�J�n�v��N��</summary>
		/// <remarks>�I���N�x�̊J�n�N���x���Z�b�g</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>�I���v��N��</summary>
		/// <remarks>�I���N�x�̏I���N���x���Z�b�g</remarks>
		private DateTime _ed_AddUpYearMonth;

		/// <summary>���s�^�C�v</summary>
		/// <remarks>0:���Ӑ��,1:���_��,2:���Ӑ�ʋ��_��,3:�Ǘ����_��,4:�������</remarks>
		private PrintDivState _printDiv;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        // ���������ȊO
        /// <summary>���_�I�v�V�����敪</summary>
        private bool _isOptSection = false;

        /// <summary>�S���_�I���敪</summary>
        private bool _isSelectAllSection = false;

        /// <summary>���z�P��</summary>
        /// <remarks>0:�~ 1:��~</remarks>
        private MoneyUnitState _moneyUnit;

        /// <summary>���ŋ敪</summary>
        /// <remarks>0:���Ȃ� 1:���_�� 2:���Ӑ斈</remarks>
        private NewPageDivState _newPageDiv;

        /// <summary>����^�C�v</summary>
        /// <remarks>0:���さ�e�� 1:���� 2:�e��</remarks>
        private PrintMoneyDivState _printMoneyDiv;

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

		/// public propaty name  :  AddUpSecCodes
		/// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
		/// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] AddUpSecCodes
		{
			get{return _addUpSecCodes;}
			set{_addUpSecCodes = value;}
		}

		/// public propaty name  :  St_CustomerCode
		/// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_CustomerCode
		{
			get{return _st_CustomerCode;}
			set{_st_CustomerCode = value;}
		}

		/// public propaty name  :  Ed_CustomerCode
		/// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_CustomerCode
		{
			get{return _ed_CustomerCode;}
			set{_ed_CustomerCode = value;}
		}

		/// public propaty name  :  St_Year
		/// <summary>�J�n�N�x�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�N�x�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime St_Year
		{
			get{return _st_Year;}
			set{_st_Year = value;}
		}

		/// public propaty name  :  Ed_Year
		/// <summary>�I���N�x�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���N�x�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ed_Year
		{
			get{return _ed_Year;}
			set{_ed_Year = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>�J�n�v��N���v���p�e�B</summary>
		/// <value>�I���N�x�̊J�n�N���x���Z�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�v��N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>�I���v��N���v���p�e�B</summary>
		/// <value>�I���N�x�̏I���N���x���Z�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���v��N���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
		}

		/// public propaty name  :  PrintDiv
		/// <summary>���s�^�C�v�v���p�e�B</summary>
		/// <value>0:���Ӑ��,1:���_��,2:���Ӑ�ʋ��_��,3:�Ǘ����_��,4:�������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���s�^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public PrintDivState PrintDiv
		{
			get{return _printDiv;}
			set{_printDiv = value;}
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
        /// ���_�I�v�V�����敪�v���p�e�B
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }

        /// <summary>
        /// �S���_�I���敪�v���p�e�B
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }

        /// <summary>
        /// ���z�P�ʁ@�v���p�e�B
        /// </summary>
        public MoneyUnitState MoneyUnit
        {
            get { return this._moneyUnit; }
            set { this._moneyUnit = value; }
        }

        /// <summary>
        /// ���y�[�W�敪�@�v���p�e�B
        /// </summary>
        public NewPageDivState NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }

        /// <summary>
        /// ����^�C�v�@�v���p�e�B
        /// </summary>
        public PrintMoneyDivState PrintMoneyDiv
        {
            get { return this._printMoneyDiv;}
            set { this._printMoneyDiv = value; }
        }

		/// <summary>
		/// ���Ӑ�ߔN�x���v�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>CustFinancialListCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustFinancialListCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustFinancialListCndtn()
		{
		}

		/// <summary>
		/// ���Ӑ�ߔN�x���v�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="addUpSecCodes">�v�㋒�_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
		/// <param name="st_CustomerCode">�J�n���Ӑ�R�[�h</param>
		/// <param name="ed_CustomerCode">�I�����Ӑ�R�[�h</param>
		/// <param name="st_Year">�J�n�N�x</param>
		/// <param name="ed_Year">�I���N�x</param>
		/// <param name="st_AddUpYearMonth">�J�n�v��N��(�I���N�x�̊J�n�N���x���Z�b�g)</param>
		/// <param name="ed_AddUpYearMonth">�I���v��N��(�I���N�x�̏I���N���x���Z�b�g)</param>
		/// <param name="printDiv">���s�^�C�v(0:���Ӑ��,1:���_��,2:���Ӑ�ʋ��_��,3:�Ǘ����_��,4:�������)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="isOptSection">���_�I�v�V�����L��</param>
        /// <param name="moneyUnit">���z�P��</param>
        /// <param name="newPageDiv">����</param>
        /// <param name="printMoneyDiv">����^�C�v</param>
        /// <param name="st_IntYear">�J�n�Ώۊ���(���[�󎚈ʒu����p)</param>
        /// <param name="ed_IntYear">�I���Ώۊ���(���[�󎚈ʒu����p)</param>
		/// <returns>CustFinancialListCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustFinancialListCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public CustFinancialListCndtn(string enterpriseCode, string[] addUpSecCodes, Int32 st_CustomerCode, Int32 ed_CustomerCode, DateTime st_Year, DateTime ed_Year, DateTime st_AddUpYearMonth, DateTime ed_AddUpYearMonth, PrintDivState printDiv, string enterpriseName, bool isOptSection, MoneyUnitState moneyUnit, NewPageDivState newPageDiv, PrintMoneyDivState printMoneyDiv)
		{
			this._enterpriseCode = enterpriseCode;
			this._addUpSecCodes = addUpSecCodes;
			this._st_CustomerCode = st_CustomerCode;
			this._ed_CustomerCode = ed_CustomerCode;
			this._st_Year = st_Year;
			this._ed_Year = ed_Year;
			this._st_AddUpYearMonth = st_AddUpYearMonth;
			this._ed_AddUpYearMonth = ed_AddUpYearMonth;
			this._printDiv = printDiv;
			this._enterpriseName = enterpriseName;
            this._isOptSection = isOptSection;
            this._moneyUnit = moneyUnit;
            this._newPageDiv = newPageDiv;
            this._printMoneyDiv = printMoneyDiv;
		}

		/// <summary>
		/// ���Ӑ�ߔN�x���v�\���o�����N���X��������
		/// </summary>
		/// <returns>CustFinancialListCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustFinancialListCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustFinancialListCndtn Clone()
		{
            return new CustFinancialListCndtn(this._enterpriseCode, this._addUpSecCodes, this._st_CustomerCode, this._ed_CustomerCode, this._st_Year, this._ed_Year, this._st_AddUpYearMonth, this._ed_AddUpYearMonth, this._printDiv, this._enterpriseName, this._isOptSection, this._moneyUnit, this._newPageDiv, this._printMoneyDiv);
		}

		/// <summary>
		/// ���Ӑ�ߔN�x���v�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustFinancialListCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustFinancialListCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(CustFinancialListCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.AddUpSecCodes == target.AddUpSecCodes)
				 && (this.St_CustomerCode == target.St_CustomerCode)
				 && (this.Ed_CustomerCode == target.Ed_CustomerCode)
				 && (this.St_Year == target.St_Year)
				 && (this.Ed_Year == target.Ed_Year)
				 && (this.St_AddUpYearMonth == target.St_AddUpYearMonth)
				 && (this.Ed_AddUpYearMonth == target.Ed_AddUpYearMonth)
				 && (this.PrintDiv == target.PrintDiv)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsOptSection == target.IsOptSection)
                 && (this.MoneyUnit == target.MoneyUnit)
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.PrintMoneyDiv == target.PrintMoneyDiv)
                 );
		}

		/// <summary>
		/// ���Ӑ�ߔN�x���v�\���o�����N���X��r����
		/// </summary>
		/// <param name="custFinancialListCndtn1">
		///                    ��r����CustFinancialListCndtn�N���X�̃C���X�^���X
		/// </param>
		/// <param name="custFinancialListCndtn2">��r����CustFinancialListCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustFinancialListCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(CustFinancialListCndtn custFinancialListCndtn1, CustFinancialListCndtn custFinancialListCndtn2)
		{
			return ((custFinancialListCndtn1.EnterpriseCode == custFinancialListCndtn2.EnterpriseCode)
				 && (custFinancialListCndtn1.AddUpSecCodes == custFinancialListCndtn2.AddUpSecCodes)
				 && (custFinancialListCndtn1.St_CustomerCode == custFinancialListCndtn2.St_CustomerCode)
				 && (custFinancialListCndtn1.Ed_CustomerCode == custFinancialListCndtn2.Ed_CustomerCode)
				 && (custFinancialListCndtn1.St_Year == custFinancialListCndtn2.St_Year)
				 && (custFinancialListCndtn1.Ed_Year == custFinancialListCndtn2.Ed_Year)
				 && (custFinancialListCndtn1.St_AddUpYearMonth == custFinancialListCndtn2.St_AddUpYearMonth)
				 && (custFinancialListCndtn1.Ed_AddUpYearMonth == custFinancialListCndtn2.Ed_AddUpYearMonth)
				 && (custFinancialListCndtn1.PrintDiv == custFinancialListCndtn2.PrintDiv)
				 && (custFinancialListCndtn1.EnterpriseName == custFinancialListCndtn2.EnterpriseName)
                 && (custFinancialListCndtn1.IsOptSection == custFinancialListCndtn2.IsOptSection)
                 && (custFinancialListCndtn1.MoneyUnit == custFinancialListCndtn2.MoneyUnit)
                 && (custFinancialListCndtn1.NewPageDiv == custFinancialListCndtn2.NewPageDiv)
                 && (custFinancialListCndtn1.PrintMoneyDiv == custFinancialListCndtn2.PrintMoneyDiv)
                 );
		}
		/// <summary>
		/// ���Ӑ�ߔN�x���v�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustFinancialListCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustFinancialListCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(CustFinancialListCndtn target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.AddUpSecCodes != target.AddUpSecCodes)resList.Add("AddUpSecCodes");
			if(this.St_CustomerCode != target.St_CustomerCode)resList.Add("St_CustomerCode");
			if(this.Ed_CustomerCode != target.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(this.St_Year != target.St_Year)resList.Add("St_Year");
			if(this.Ed_Year != target.Ed_Year)resList.Add("Ed_Year");
			if(this.St_AddUpYearMonth != target.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(this.Ed_AddUpYearMonth != target.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(this.PrintDiv != target.PrintDiv)resList.Add("PrintDiv");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.MoneyUnit != target.MoneyUnit) resList.Add("MoneyUnit");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.PrintMoneyDiv != target.PrintMoneyDiv) resList.Add("PrintMoneyDiv");

			return resList;
		}

		/// <summary>
		/// ���Ӑ�ߔN�x���v�\���o�����N���X��r����
		/// </summary>
		/// <param name="custFinancialListCndtn1">��r����CustFinancialListCndtn�N���X�̃C���X�^���X</param>
		/// <param name="custFinancialListCndtn2">��r����CustFinancialListCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustFinancialListCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(CustFinancialListCndtn custFinancialListCndtn1, CustFinancialListCndtn custFinancialListCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(custFinancialListCndtn1.EnterpriseCode != custFinancialListCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(custFinancialListCndtn1.AddUpSecCodes != custFinancialListCndtn2.AddUpSecCodes)resList.Add("AddUpSecCodes");
			if(custFinancialListCndtn1.St_CustomerCode != custFinancialListCndtn2.St_CustomerCode)resList.Add("St_CustomerCode");
			if(custFinancialListCndtn1.Ed_CustomerCode != custFinancialListCndtn2.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(custFinancialListCndtn1.St_Year != custFinancialListCndtn2.St_Year)resList.Add("St_Year");
			if(custFinancialListCndtn1.Ed_Year != custFinancialListCndtn2.Ed_Year)resList.Add("Ed_Year");
			if(custFinancialListCndtn1.St_AddUpYearMonth != custFinancialListCndtn2.St_AddUpYearMonth)resList.Add("St_AddUpYearMonth");
			if(custFinancialListCndtn1.Ed_AddUpYearMonth != custFinancialListCndtn2.Ed_AddUpYearMonth)resList.Add("Ed_AddUpYearMonth");
			if(custFinancialListCndtn1.PrintDiv != custFinancialListCndtn2.PrintDiv)resList.Add("PrintDiv");
			if(custFinancialListCndtn1.EnterpriseName != custFinancialListCndtn2.EnterpriseName)resList.Add("EnterpriseName");
            if (custFinancialListCndtn1.IsOptSection != custFinancialListCndtn2.IsOptSection) resList.Add("IsOptSection");
            if (custFinancialListCndtn1.MoneyUnit != custFinancialListCndtn2.MoneyUnit) resList.Add("MoneyUnit");
            if (custFinancialListCndtn1.NewPageDiv != custFinancialListCndtn2.NewPageDiv) resList.Add("NewPageDiv");
            if (custFinancialListCndtn1.PrintMoneyDiv != custFinancialListCndtn2.PrintMoneyDiv) resList.Add("PrintMoneyDiv");

			return resList;
        }

        #region �����ږ��̃v���p�e�B
        /// <summary>
        /// ���z�P�ʃ^�C�g���@�v���p�e�B
        /// </summary>
        public string MoneyUnitStateTitle
        {
            get
            {
                switch (this._moneyUnit)
                {
                    case MoneyUnitState.One: return ct_MoneyUnitState_One;
                    case MoneyUnitState.Thousand: return ct_MoneyUnitState_Thousand;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// ���y�[�W�敪�^�C�g���@�v���p�e�B
        /// </summary>
        public string NewPageDivStateTitle
        {
            get
            {
                switch (this._newPageDiv)
                {
                    case NewPageDivState.Section: return ct_NewPageDivState_Section;
                    case NewPageDivState.Customer: return ct_NewPageDivState_Customer;
                    case NewPageDivState.None: return ct_NewPageDivState_None;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// ����^�C�v�^�C�g���@�v���p�e�B
        /// </summary>
        public string PrintMoneyDivStateTitle
        {
            get
            {
                switch (this._printMoneyDiv)
                {
                    case PrintMoneyDivState.SalesAndGross: return ct_PrintMoneyDivState_SalesAndGross;
                    case PrintMoneyDivState.SalesMoney: return ct_PrintMoneyDivState_SalesMoney;
                    case PrintMoneyDivState.GrossProfit: return ct_PrintMoneyDivState_GrossProfit;
                    default: return "";
                }
            }
        }

        #endregion

        #region ���񋓑�
        /// <summary>
        /// ���z�P�ʁ@�񋓑�
        /// </summary>
        public enum MoneyUnitState
        {
            /// <summary>�~</summary>
            One = 0,
            /// <summary>��~</summary>
            Thousand = 1
        }

        /// <summary>
        /// ���y�[�W�敪�@�񋓑�
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>���Ȃ�</summary>
            None = 0,
            /// <summary>���_��</summary>
            Section = 1,
            /// <summary>���Ӑ斈</summary>
            Customer = 2,
        }

        public enum PrintDivState
        {
            /// <summary>���Ӑ��</summary>
            Customer = 0,
            /// <summary>���_��</summary>
            Section = 1,
            /// <summary>���Ӑ�ʋ��_��</summary>
            CustomerSection = 2,
            /// <summary>�Ǘ����_��</summary>
            ManageSection = 3,
            /// <summary>�������</summary>
            Clame = 4,
        }

        /// <summary>
        /// ����^�C�v�@�񋓑�
        /// </summary>
        public enum PrintMoneyDivState
        {
            /// <summary>���さ�e��</summary>
            SalesAndGross = 0,
            /// <summary>����</summary>
            SalesMoney = 1,
            /// <summary>�e��</summary>
            GrossProfit = 2,
        }
        #endregion

        #region �����ږ���
        /// <summary>���z�P�ʁ@�~</summary>
        private const string ct_MoneyUnitState_One = "�~";
        /// <summary>���z�P�ʁ@��~</summary>
        private const string ct_MoneyUnitState_Thousand = "��~";

        /// <summary>���y�[�W�敪 ���_��</summary>
        private const string ct_NewPageDivState_Section = "���_�P��";
        /// <summary>���y�[�W�敪 �d���斈</summary>
        private const string ct_NewPageDivState_Customer = "���Ӑ�P��";
        /// <summary>���y�[�W�敪 ���Ȃ�</summary>
        private const string ct_NewPageDivState_None = "���Ȃ�";

        /// <summary>����^�C�v ���さ�e��</summary>
        private const string ct_PrintMoneyDivState_SalesAndGross = "���さ�e��";
        private const string ct_PrintMoneyDivState_SalesMoney = "����";
        private const string ct_PrintMoneyDivState_GrossProfit = "�e��";
        #endregion
    }
}

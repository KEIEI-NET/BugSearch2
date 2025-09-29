using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SlipHistAnalyzeParam
	/// <summary>
	///                      �d�����͕\���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �d�����͕\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/19  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SlipHistAnalyzeParam
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>(�z��)�@�S�Ўw���null</remarks>
		private string[] _sectionCodes;

		/// <summary>�J�n�v��N��(����)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _stAddUpYearMonth;

		/// <summary>�I���v��N��(����)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _edAddUpYearMonth;

		/// <summary>�J�n�v��N��(����)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _stAnnualAddUpYearMonth;

		/// <summary>�I���v��N��(����)</summary>
		/// <remarks>YYYYMM</remarks>
		private Int32 _edAnnualAddUpYearMonth;

		/// <summary>�J�n�d����R�[�h</summary>
		private Int32 _stSupplierCd;

		/// <summary>�I���d����R�[�h</summary>
		private Int32 _edSupplierCd;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        // ���������ȊO
        /// <summary>���_�I�v�V�����敪</summary>
        private bool _isOptSection = false;

        /// <summary>�S���_�I���敪</summary>
        private bool _isSelectAllSection = false;

        /// <summary>�\����P��</summary>
        private ConstUnitDivState _constUnitDiv;

        /// <summary>���z�P��</summary>
        private MoneyUnitDivState _moneyUnitDiv;

        /// <summary>���ŒP��</summary>
        private NewPageDivState _newPageDiv;

        /// <summary>���s�^�C�v</summary>
        private PrintTypeState _printType;

        /// <summary>����^�C�v</summary>
        private PrintTermTypeState _printTermType;


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

		/// public propaty name  :  SectionCodes
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>(�z��)�@�S�Ўw���null</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  StAddUpYearMonth
		/// <summary>�J�n�v��N��(����)�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�v��N��(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StAddUpYearMonth
		{
			get{return _stAddUpYearMonth;}
			set{_stAddUpYearMonth = value;}
		}

		/// public propaty name  :  EdAddUpYearMonth
		/// <summary>�I���v��N��(����)�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���v��N��(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdAddUpYearMonth
		{
			get{return _edAddUpYearMonth;}
			set{_edAddUpYearMonth = value;}
		}

		/// public propaty name  :  StAnnualAddUpYearMonth
		/// <summary>�J�n�v��N��(����)�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�v��N��(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StAnnualAddUpYearMonth
		{
			get{return _stAnnualAddUpYearMonth;}
			set{_stAnnualAddUpYearMonth = value;}
		}

		/// public propaty name  :  EdAnnualAddUpYearMonth
		/// <summary>�I���v��N��(����)�v���p�e�B</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���v��N��(����)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdAnnualAddUpYearMonth
		{
			get{return _edAnnualAddUpYearMonth;}
			set{_edAnnualAddUpYearMonth = value;}
		}

		/// public propaty name  :  StSupplierCd
		/// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StSupplierCd
		{
			get{return _stSupplierCd;}
			set{_stSupplierCd = value;}
		}

		/// public propaty name  :  EdSupplierCd
		/// <summary>�I���d����R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdSupplierCd
		{
			get{return _edSupplierCd;}
			set{_edSupplierCd = value;}
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
		/// �d�����͕\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>SlipHistAnalyzeParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SlipHistAnalyzeParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SlipHistAnalyzeParam()
		{
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
        /// �\����P�ʃv���p�e�B
        /// </summary>
        public ConstUnitDivState ConstUnitDiv
        {
            get { return this._constUnitDiv; }
            set { this._constUnitDiv = value; }
        }

        /// <summary>
        /// ���z�P�ʃv���p�e�B
        /// </summary>
        public MoneyUnitDivState MoneyUnitDiv
        {
            get { return this._moneyUnitDiv; }
            set { this._moneyUnitDiv = value; }
        }

        /// <summary>
        /// ���Ńv���p�e�B
        /// </summary>
        public NewPageDivState NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }

        /// <summary>
        /// ���s�^�C�v�v���p�e�B
        /// </summary>
        public PrintTypeState PrintType
        {
            get { return this._printType; }
            set { this._printType = value; }
        }

        /// <summary>
        /// ����^�C�v�v���p�e�B
        /// </summary>
        public PrintTermTypeState PrintTermType
        {
            get { return this._printTermType; }
            set { this._printTermType = value; }
        }

		/// <summary>
		/// �d�����͕\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="sectionCodes">���_�R�[�h((�z��)�@�S�Ўw���null)</param>
		/// <param name="stAddUpYearMonth">�J�n�v��N��(����)(YYYYMM)</param>
		/// <param name="edAddUpYearMonth">�I���v��N��(����)(YYYYMM)</param>
		/// <param name="stAnnualAddUpYearMonth">�J�n�v��N��(����)(YYYYMM)</param>
		/// <param name="edAnnualAddUpYearMonth">�I���v��N��(����)(YYYYMM)</param>
		/// <param name="stSupplierCd">�J�n�d����R�[�h</param>
		/// <param name="edSupplierCd">�I���d����R�[�h</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>SlipHistAnalyzeParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SlipHistAnalyzeParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SlipHistAnalyzeParam(string enterpriseCode, string[] sectionCodes,Int32 stAddUpYearMonth,Int32 edAddUpYearMonth,Int32 stAnnualAddUpYearMonth,Int32 edAnnualAddUpYearMonth,Int32 stSupplierCd,Int32 edSupplierCd,string enterpriseName,
            bool isOptSection, bool isSelectAllSection, ConstUnitDivState constUnitDiv, MoneyUnitDivState moneyUnitDiv, NewPageDivState newPageDiv, PrintTypeState printType, PrintTermTypeState printTermType)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCodes = sectionCodes;
			this._stAddUpYearMonth = stAddUpYearMonth;
			this._edAddUpYearMonth = edAddUpYearMonth;
			this._stAnnualAddUpYearMonth = stAnnualAddUpYearMonth;
			this._edAnnualAddUpYearMonth = edAnnualAddUpYearMonth;
			this._stSupplierCd = stSupplierCd;
			this._edSupplierCd = edSupplierCd;
			this._enterpriseName = enterpriseName;
            this._isOptSection = isOptSection;
            this._isSelectAllSection = isSelectAllSection;
            this._constUnitDiv = constUnitDiv;
            this._moneyUnitDiv = moneyUnitDiv;
            this._newPageDiv = newPageDiv;
            this._printType = printType;
            this._printTermType = printTermType;
		}

		/// <summary>
		/// �d�����͕\���o�����N���X��������
		/// </summary>
		/// <returns>SlipHistAnalyzeParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SlipHistAnalyzeParam�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SlipHistAnalyzeParam Clone()
		{
			return new SlipHistAnalyzeParam(this._enterpriseCode,this._sectionCodes,this._stAddUpYearMonth,this._edAddUpYearMonth,this._stAnnualAddUpYearMonth,this._edAnnualAddUpYearMonth,this._stSupplierCd,this._edSupplierCd,this._enterpriseName,
                this._isOptSection, this._isSelectAllSection, this._constUnitDiv, this._moneyUnitDiv, this._newPageDiv, this._printType, this._printTermType);
		}

		/// <summary>
		/// �d�����͕\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SlipHistAnalyzeParam�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SlipHistAnalyzeParam�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public bool Equals(SlipHistAnalyzeParam target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCodes == target.SectionCodes)
                 && (this.StAddUpYearMonth == target.StAddUpYearMonth)
                 && (this.EdAddUpYearMonth == target.EdAddUpYearMonth)
                 && (this.StAnnualAddUpYearMonth == target.StAnnualAddUpYearMonth)
                 && (this.EdAnnualAddUpYearMonth == target.EdAnnualAddUpYearMonth)
                 && (this.StSupplierCd == target.StSupplierCd)
                 && (this.EdSupplierCd == target.EdSupplierCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsOptSection == target.IsOptSection)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (this.ConstUnitDiv == target.ConstUnitDiv)
                 && (this.MoneyUnitDiv == target.MoneyUnitDiv)
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.PrintType == target.PrintType)
                 && (this.PrintTermType == target.PrintTermType)
                 );
        }

		/// <summary>
		/// �d�����͕\���o�����N���X��r����
		/// </summary>
		/// <param name="slipHistAnalyzeParam1">
		///                    ��r����SlipHistAnalyzeParam�N���X�̃C���X�^���X
		/// </param>
		/// <param name="slipHistAnalyzeParam2">��r����SlipHistAnalyzeParam�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SlipHistAnalyzeParam�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SlipHistAnalyzeParam slipHistAnalyzeParam1, SlipHistAnalyzeParam slipHistAnalyzeParam2)
		{
			return ((slipHistAnalyzeParam1.EnterpriseCode == slipHistAnalyzeParam2.EnterpriseCode)
				 && (slipHistAnalyzeParam1.SectionCodes == slipHistAnalyzeParam2.SectionCodes)
				 && (slipHistAnalyzeParam1.StAddUpYearMonth == slipHistAnalyzeParam2.StAddUpYearMonth)
				 && (slipHistAnalyzeParam1.EdAddUpYearMonth == slipHistAnalyzeParam2.EdAddUpYearMonth)
				 && (slipHistAnalyzeParam1.StAnnualAddUpYearMonth == slipHistAnalyzeParam2.StAnnualAddUpYearMonth)
				 && (slipHistAnalyzeParam1.EdAnnualAddUpYearMonth == slipHistAnalyzeParam2.EdAnnualAddUpYearMonth)
				 && (slipHistAnalyzeParam1.StSupplierCd == slipHistAnalyzeParam2.StSupplierCd)
				 && (slipHistAnalyzeParam1.EdSupplierCd == slipHistAnalyzeParam2.EdSupplierCd)
				 && (slipHistAnalyzeParam1.EnterpriseName == slipHistAnalyzeParam2.EnterpriseName)
                 && (slipHistAnalyzeParam1.IsOptSection == slipHistAnalyzeParam2.IsOptSection)
                 && (slipHistAnalyzeParam1.IsSelectAllSection == slipHistAnalyzeParam2.IsSelectAllSection)
                 && (slipHistAnalyzeParam1.ConstUnitDiv == slipHistAnalyzeParam2.ConstUnitDiv)
                 && (slipHistAnalyzeParam1.MoneyUnitDiv == slipHistAnalyzeParam2.MoneyUnitDiv)
                 && (slipHistAnalyzeParam1.NewPageDiv == slipHistAnalyzeParam2.NewPageDiv)
                 && (slipHistAnalyzeParam1.PrintType == slipHistAnalyzeParam2.PrintType)
                 && (slipHistAnalyzeParam1.PrintTermType == slipHistAnalyzeParam2.PrintTermType)
                 );
		}
		/// <summary>
		/// �d�����͕\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SlipHistAnalyzeParam�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SlipHistAnalyzeParam�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SlipHistAnalyzeParam target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
			if(this.StAddUpYearMonth != target.StAddUpYearMonth)resList.Add("StAddUpYearMonth");
			if(this.EdAddUpYearMonth != target.EdAddUpYearMonth)resList.Add("EdAddUpYearMonth");
			if(this.StAnnualAddUpYearMonth != target.StAnnualAddUpYearMonth)resList.Add("StAnnualAddUpYearMonth");
			if(this.EdAnnualAddUpYearMonth != target.EdAnnualAddUpYearMonth)resList.Add("EdAnnualAddUpYearMonth");
			if(this.StSupplierCd != target.StSupplierCd)resList.Add("StSupplierCd");
			if(this.EdSupplierCd != target.EdSupplierCd)resList.Add("EdSupplierCd");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (this.ConstUnitDiv != target.ConstUnitDiv) resList.Add("ConstUnitDiv");
            if (this.MoneyUnitDiv != target.MoneyUnitDiv) resList.Add("MoneyUnitDiv");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.PrintType != target.PrintType) resList.Add("PrintType");
            if (this.PrintTermType != target.PrintTermType) resList.Add("PrintTermType");
			return resList;
		}

		/// <summary>
		/// �d�����͕\���o�����N���X��r����
		/// </summary>
		/// <param name="slipHistAnalyzeParam1">��r����SlipHistAnalyzeParam�N���X�̃C���X�^���X</param>
		/// <param name="slipHistAnalyzeParam2">��r����SlipHistAnalyzeParam�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SlipHistAnalyzeParam�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SlipHistAnalyzeParam slipHistAnalyzeParam1, SlipHistAnalyzeParam slipHistAnalyzeParam2)
		{
			ArrayList resList = new ArrayList();
			if(slipHistAnalyzeParam1.EnterpriseCode != slipHistAnalyzeParam2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(slipHistAnalyzeParam1.SectionCodes != slipHistAnalyzeParam2.SectionCodes)resList.Add("SectionCodes");
			if(slipHistAnalyzeParam1.StAddUpYearMonth != slipHistAnalyzeParam2.StAddUpYearMonth)resList.Add("StAddUpYearMonth");
			if(slipHistAnalyzeParam1.EdAddUpYearMonth != slipHistAnalyzeParam2.EdAddUpYearMonth)resList.Add("EdAddUpYearMonth");
			if(slipHistAnalyzeParam1.StAnnualAddUpYearMonth != slipHistAnalyzeParam2.StAnnualAddUpYearMonth)resList.Add("StAnnualAddUpYearMonth");
			if(slipHistAnalyzeParam1.EdAnnualAddUpYearMonth != slipHistAnalyzeParam2.EdAnnualAddUpYearMonth)resList.Add("EdAnnualAddUpYearMonth");
			if(slipHistAnalyzeParam1.StSupplierCd != slipHistAnalyzeParam2.StSupplierCd)resList.Add("StSupplierCd");
			if(slipHistAnalyzeParam1.EdSupplierCd != slipHistAnalyzeParam2.EdSupplierCd)resList.Add("EdSupplierCd");
			if(slipHistAnalyzeParam1.EnterpriseName != slipHistAnalyzeParam2.EnterpriseName)resList.Add("EnterpriseName");
            if (slipHistAnalyzeParam1.IsOptSection != slipHistAnalyzeParam2.IsOptSection) resList.Add("IsOptSection");
            if (slipHistAnalyzeParam1.IsSelectAllSection != slipHistAnalyzeParam2.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (slipHistAnalyzeParam1.ConstUnitDiv != slipHistAnalyzeParam2.ConstUnitDiv) resList.Add("ConstUnitDiv");
            if (slipHistAnalyzeParam1.MoneyUnitDiv != slipHistAnalyzeParam2.MoneyUnitDiv) resList.Add("MoneyUnitDiv");
            if (slipHistAnalyzeParam1.NewPageDiv != slipHistAnalyzeParam2.NewPageDiv) resList.Add("NewPageDiv");
            if (slipHistAnalyzeParam1.PrintType != slipHistAnalyzeParam2.PrintType) resList.Add("PrintType");
            if (slipHistAnalyzeParam1.PrintTermType != slipHistAnalyzeParam2.PrintTermType) resList.Add("PrintTermType");

			return resList;
		}

        #region �����ږ��̃v���p�e�B
        /// <summary>
        /// �\����P�ʃ^�C�g���@�v���p�e�B
        /// </summary>
        public string ConstUnitDivStateTitle
        {
            get
            {
                switch (this._constUnitDiv)
                {
                    case ConstUnitDivState.Total: return ct_ConstUnitDivState_Total;
                    case ConstUnitDivState.SubTotal: return ct_ConstUnitDivState_SubTotal;

                    default: return "";
                }
            }
        }

        /// <summary>
        /// ���z�P�ʃ^�C�g���@�v���p�e�B
        /// </summary>
        public string MoneyUnitDivStateTitle
        {
            get
            {
                switch (this._moneyUnitDiv)
                {
                    case MoneyUnitDivState.One: return ct_MoneyUnitDivState_One;
                    case MoneyUnitDivState.Thousand: return ct_MoneyUnitDivState_Thousand;

                    default: return "";
                }
            }
        }

        /// <summary>
        /// ���s�^�C�v�^�C�g���@�v���p�e�B
        /// </summary>
        public string PrintTypeStateTitle
        {
            get
            {
                switch (this._printType)
                {
                    case PrintTypeState.Section: return ct_PrintTypeState_Section;
                    case PrintTypeState.Supplier: return ct_PrintTypeState_Supplier;

                    default: return "";
                }
            }
        }

        /// <summary>
        /// ����^�C�v�^�C�g���@�v���p�e�B
        /// </summary>
        public string PrintTermTypeStateTitle
        {
            get
            {
                switch (this._printTermType)
                {
                    case PrintTermTypeState.MonthAndTerm: return ct_PrintTermType_MonthAndTerm;
                    case PrintTermTypeState.Month: return ct_PrintTermType_Month;
                    case PrintTermTypeState.Term: return ct_PrintTermType_Term;

                    default: return "";
                }
            }
        }

        #endregion

        #region ���񋓑�

        /// <summary>
        /// �\����P�ʁ@�񋓑�
        /// </summary>
        public enum ConstUnitDivState
        {
            /// <summary>�����v</summary>
            Total = 0,
            /// <summary>���v</summary>
            SubTotal = 1,
        }

        /// <summary>
        /// ���z�P�ʁ@�񋓑�
        /// </summary>
        public enum MoneyUnitDivState
        {
            /// <summary>�~</summary>
            One = 0,
            /// <summary>��~</summary>
            Thousand = 1,
        }

        /// <summary>
        /// ���y�[�W�敪�@�񋓑�
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>����</summary>
            Do = 0,
            /// <summary>���Ȃ�</summary>
            None = 1,
        }

        /// <summary>
        /// ���s�^�C�v �񋓑�
        /// </summary>
        public enum PrintTypeState
        {
            /// <summary>���_��</summary>
            Section = 0,
            /// <summary>�d���斈</summary>
            Supplier = 1,
        }

        /// <summary>
        /// ����^�C�v �񋓑�
        /// </summary>
        public enum PrintTermTypeState
        {
            /// <summary>����������</summary>
            MonthAndTerm = 0,
            /// <summary>����</summary>
            Month = 1,
            /// <summary>����</summary>
            Term = 2,

        }
        #endregion

        #region �����ږ���

        /// <summary>�\����P�� �����v</summary>
        private const string ct_ConstUnitDivState_Total = "�����v";
        /// <summary>�\����P�� ���v</summary>
        private const string ct_ConstUnitDivState_SubTotal = "���v";

        /// <summary>���z�P�� �~</summary>
        private const string ct_MoneyUnitDivState_One = "�~";
        /// <summary>���z�P�� ��~</summary>
        private const string ct_MoneyUnitDivState_Thousand = "��~";

        /// <summary>���s�^�C�v�@���_��</summary>
        private const string ct_PrintTypeState_Section = "���_��";
        /// <summary>���s�^�C�v�@�d���斈</summary>
        private const string ct_PrintTypeState_Supplier = "�d���斈";

        /// <summary>����^�C�v�@����������</summary>
        private const string ct_PrintTermType_MonthAndTerm = "����������";
        /// <summary>����^�C�v�@����</summary>
        private const string ct_PrintTermType_Month = "����";
        /// <summary>����^�C�v�@����</summary>
        private const string ct_PrintTermType_Term = "����";

        #endregion
	}
}

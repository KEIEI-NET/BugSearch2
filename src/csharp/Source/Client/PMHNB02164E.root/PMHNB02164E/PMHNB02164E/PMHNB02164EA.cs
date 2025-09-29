using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SalesHistAnalyzeCndtn
	/// <summary>
	///                      ������e���͕\���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ������e���͕\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SalesHistAnalyzeCndtn
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string[] _sectionCode;

		/// <summary>�J�n�Ώۓ��t</summary>
		private Int32 _st_SalesDate;

		/// <summary>�I���Ώۓ��t</summary>
		private Int32 _ed_SalesDate;

		/// <summary>�J�n�Ώۓ��t(�݌v)</summary>
		/// <remarks>�݌v���o�͈͂̊J�n���t���Z�b�g</remarks>
		private Int32 _st_MonthReportDate;

		/// <summary>�I���Ώۓ��t(�݌v)</summary>
		/// <remarks>�I�����t���Z�b�g</remarks>
		private Int32 _ed_MonthReportDate;

		/// <summary>�J�n���Ӑ�R�[�h</summary>
		private Int32 _st_CustomerCode;

		/// <summary>�I�����Ӑ�R�[�h</summary>
		private Int32 _ed_CustomerCode;

		/// <summary>�J�n�̔��]�ƈ��R�[�h</summary>
		private string _st_SalesEmployeeCd = "";

		/// <summary>�I���̔��]�ƈ��R�[�h</summary>
		private string _ed_SalesEmployeeCd = "";

		/// <summary>�J�n�̔��G���A�R�[�h</summary>
		/// <remarks>�n��R�[�h</remarks>
		private Int32 _st_SalesAreaCode;

		/// <summary>�I���̔��G���A�R�[�h</summary>
		/// <remarks>�n��R�[�h</remarks>
		private Int32 _ed_SalesAreaCode;

		/// <summary>���s�^�C�v</summary>
		/// <remarks>0:���Ӑ��,1:�S���ҕ�,2:�n���</remarks>
        private PrintDivState _printDiv;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        // ���������ȊO
        /// <summary>���_�I�v�V�����敪</summary>
        private bool _isOptSection = false;

        /// <summary>�S���_�I���敪</summary>
        private bool _isSelectAllSection = false;

        /// <summary>�݌v���</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private MonthReportDivState _monthReportDiv;

        /// <summary>���ŋ敪</summary>
        /// <remarks>0:���Ȃ� 1:���_�� 2:���Ӑ斈</remarks>
        private NewPageDivState _newPageDiv;

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
		/// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
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

		/// public propaty name  :  St_SalesDate
		/// <summary>�J�n�Ώۓ��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ώۓ��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_SalesDate
		{
			get{return _st_SalesDate;}
			set{_st_SalesDate = value;}
		}

		/// public propaty name  :  Ed_SalesDate
		/// <summary>�I���Ώۓ��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ώۓ��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_SalesDate
		{
			get{return _ed_SalesDate;}
			set{_ed_SalesDate = value;}
		}

		/// public propaty name  :  St_MonthReportDate
		/// <summary>�J�n�Ώۓ��t(�݌v)�v���p�e�B</summary>
		/// <value>�݌v���o�͈͂̊J�n���t���Z�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ώۓ��t(�݌v)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_MonthReportDate
		{
			get{return _st_MonthReportDate;}
			set{_st_MonthReportDate = value;}
		}

		/// public propaty name  :  Ed_MonthReportDate
		/// <summary>�I���Ώۓ��t(�݌v)�v���p�e�B</summary>
		/// <value>�I�����t���Z�b�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ώۓ��t(�݌v)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_MonthReportDate
		{
			get{return _ed_MonthReportDate;}
			set{_ed_MonthReportDate = value;}
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

		/// public propaty name  :  St_SalesEmployeeCd
		/// <summary>�J�n�̔��]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�̔��]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_SalesEmployeeCd
		{
			get{return _st_SalesEmployeeCd;}
			set{_st_SalesEmployeeCd = value;}
		}

		/// public propaty name  :  Ed_SalesEmployeeCd
		/// <summary>�I���̔��]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���̔��]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_SalesEmployeeCd
		{
			get{return _ed_SalesEmployeeCd;}
			set{_ed_SalesEmployeeCd = value;}
		}

		/// public propaty name  :  St_SalesAreaCode
		/// <summary>�J�n�̔��G���A�R�[�h�v���p�e�B</summary>
		/// <value>�n��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�̔��G���A�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_SalesAreaCode
		{
			get{return _st_SalesAreaCode;}
			set{_st_SalesAreaCode = value;}
		}

		/// public propaty name  :  Ed_SalesAreaCode
		/// <summary>�I���̔��G���A�R�[�h�v���p�e�B</summary>
		/// <value>�n��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���̔��G���A�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_SalesAreaCode
		{
			get{return _ed_SalesAreaCode;}
			set{_ed_SalesAreaCode = value;}
		}

		/// public propaty name  :  PrintDiv
		/// <summary>���s�^�C�v�v���p�e�B</summary>
		/// <value>0:���Ӑ��,1:�S���ҕ�,2:�n���</value>
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
        /// �݌v����@�v���p�e�B
        /// </summary>
        public MonthReportDivState MonthReportDiv
        {
            get { return this._monthReportDiv; }
            set { this._monthReportDiv = value; }
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
		/// ������e���͕\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>SalesHistAnalyzeCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesHistAnalyzeCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesHistAnalyzeCndtn()
		{
		}

		/// <summary>
		/// ������e���͕\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="sectionCode">���_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
		/// <param name="st_SalesDate">�J�n�Ώۓ��t</param>
		/// <param name="ed_SalesDate">�I���Ώۓ��t</param>
		/// <param name="st_MonthReportDate">�J�n�Ώۓ��t(�݌v)(�݌v���o�͈͂̊J�n���t���Z�b�g)</param>
		/// <param name="ed_MonthReportDate">�I���Ώۓ��t(�݌v)(�I�����t���Z�b�g)</param>
		/// <param name="st_CustomerCode">�J�n���Ӑ�R�[�h</param>
		/// <param name="ed_CustomerCode">�I�����Ӑ�R�[�h</param>
		/// <param name="st_SalesEmployeeCd">�J�n�̔��]�ƈ��R�[�h</param>
		/// <param name="ed_SalesEmployeeCd">�I���̔��]�ƈ��R�[�h</param>
		/// <param name="st_SalesAreaCode">�J�n�̔��G���A�R�[�h(�n��R�[�h)</param>
		/// <param name="ed_SalesAreaCode">�I���̔��G���A�R�[�h(�n��R�[�h)</param>
		/// <param name="printDiv">���s�^�C�v(0:���Ӑ��,1:�S���ҕ�,2:�n���)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>SalesHistAnalyzeCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesHistAnalyzeCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public SalesHistAnalyzeCndtn(string enterpriseCode, string[] sectionCode, Int32 st_SalesDate, Int32 ed_SalesDate, Int32 st_MonthReportDate, Int32 ed_MonthReportDate, Int32 st_CustomerCode, Int32 ed_CustomerCode, string st_SalesEmployeeCd, string ed_SalesEmployeeCd, Int32 st_SalesAreaCode, Int32 ed_SalesAreaCode, PrintDivState printDiv, string enterpriseName, bool isOptSection, bool isSelectAllSection, MonthReportDivState monthReportDiv, NewPageDivState newPageDiv)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._st_SalesDate = st_SalesDate;
			this._ed_SalesDate = ed_SalesDate;
			this._st_MonthReportDate = st_MonthReportDate;
			this._ed_MonthReportDate = ed_MonthReportDate;
			this._st_CustomerCode = st_CustomerCode;
			this._ed_CustomerCode = ed_CustomerCode;
			this._st_SalesEmployeeCd = st_SalesEmployeeCd;
			this._ed_SalesEmployeeCd = ed_SalesEmployeeCd;
			this._st_SalesAreaCode = st_SalesAreaCode;
			this._ed_SalesAreaCode = ed_SalesAreaCode;
			this._printDiv = printDiv;
			this._enterpriseName = enterpriseName;
            this._isOptSection = isOptSection;
            this._isSelectAllSection = isSelectAllSection;
            this._monthReportDiv = monthReportDiv;
            this._newPageDiv = newPageDiv;
		}

		/// <summary>
		/// ������e���͕\���o�����N���X��������
		/// </summary>
		/// <returns>SalesHistAnalyzeCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesHistAnalyzeCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesHistAnalyzeCndtn Clone()
		{
            return new SalesHistAnalyzeCndtn(this._enterpriseCode, this._sectionCode, this._st_SalesDate, this._ed_SalesDate, this._st_MonthReportDate, this._ed_MonthReportDate, this._st_CustomerCode, this._ed_CustomerCode, this._st_SalesEmployeeCd, this._ed_SalesEmployeeCd, this._st_SalesAreaCode, this._ed_SalesAreaCode, this._printDiv, this._enterpriseName, this._isOptSection, this._isSelectAllSection, this._monthReportDiv, this._newPageDiv);
		}

		/// <summary>
		/// ������e���͕\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SalesHistAnalyzeCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesHistAnalyzeCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SalesHistAnalyzeCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.St_SalesDate == target.St_SalesDate)
				 && (this.Ed_SalesDate == target.Ed_SalesDate)
				 && (this.St_MonthReportDate == target.St_MonthReportDate)
				 && (this.Ed_MonthReportDate == target.Ed_MonthReportDate)
				 && (this.St_CustomerCode == target.St_CustomerCode)
				 && (this.Ed_CustomerCode == target.Ed_CustomerCode)
				 && (this.St_SalesEmployeeCd == target.St_SalesEmployeeCd)
				 && (this.Ed_SalesEmployeeCd == target.Ed_SalesEmployeeCd)
				 && (this.St_SalesAreaCode == target.St_SalesAreaCode)
				 && (this.Ed_SalesAreaCode == target.Ed_SalesAreaCode)
				 && (this.PrintDiv == target.PrintDiv)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsOptSection == target.IsOptSection)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (this.MonthReportDiv == target.MonthReportDiv)
                 && (this.NewPageDiv == target.NewPageDiv));

		}

		/// <summary>
		/// ������e���͕\���o�����N���X��r����
		/// </summary>
		/// <param name="salesHistAnalyzeCndtn1">
		///                    ��r����SalesHistAnalyzeCndtn�N���X�̃C���X�^���X
		/// </param>
		/// <param name="salesHistAnalyzeCndtn2">��r����SalesHistAnalyzeCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesHistAnalyzeCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SalesHistAnalyzeCndtn salesHistAnalyzeCndtn1, SalesHistAnalyzeCndtn salesHistAnalyzeCndtn2)
		{
			return ((salesHistAnalyzeCndtn1.EnterpriseCode == salesHistAnalyzeCndtn2.EnterpriseCode)
				 && (salesHistAnalyzeCndtn1.SectionCode == salesHistAnalyzeCndtn2.SectionCode)
				 && (salesHistAnalyzeCndtn1.St_SalesDate == salesHistAnalyzeCndtn2.St_SalesDate)
				 && (salesHistAnalyzeCndtn1.Ed_SalesDate == salesHistAnalyzeCndtn2.Ed_SalesDate)
				 && (salesHistAnalyzeCndtn1.St_MonthReportDate == salesHistAnalyzeCndtn2.St_MonthReportDate)
				 && (salesHistAnalyzeCndtn1.Ed_MonthReportDate == salesHistAnalyzeCndtn2.Ed_MonthReportDate)
				 && (salesHistAnalyzeCndtn1.St_CustomerCode == salesHistAnalyzeCndtn2.St_CustomerCode)
				 && (salesHistAnalyzeCndtn1.Ed_CustomerCode == salesHistAnalyzeCndtn2.Ed_CustomerCode)
				 && (salesHistAnalyzeCndtn1.St_SalesEmployeeCd == salesHistAnalyzeCndtn2.St_SalesEmployeeCd)
				 && (salesHistAnalyzeCndtn1.Ed_SalesEmployeeCd == salesHistAnalyzeCndtn2.Ed_SalesEmployeeCd)
				 && (salesHistAnalyzeCndtn1.St_SalesAreaCode == salesHistAnalyzeCndtn2.St_SalesAreaCode)
				 && (salesHistAnalyzeCndtn1.Ed_SalesAreaCode == salesHistAnalyzeCndtn2.Ed_SalesAreaCode)
				 && (salesHistAnalyzeCndtn1.PrintDiv == salesHistAnalyzeCndtn2.PrintDiv)
				 && (salesHistAnalyzeCndtn1.EnterpriseName == salesHistAnalyzeCndtn2.EnterpriseName)
                 && (salesHistAnalyzeCndtn1.IsOptSection == salesHistAnalyzeCndtn2.IsOptSection)
                 && (salesHistAnalyzeCndtn1.IsSelectAllSection == salesHistAnalyzeCndtn2.IsSelectAllSection)
                 && (salesHistAnalyzeCndtn1.MonthReportDiv == salesHistAnalyzeCndtn2.MonthReportDiv)
                 && (salesHistAnalyzeCndtn1.NewPageDiv == salesHistAnalyzeCndtn2.NewPageDiv)
                 );
		}
		/// <summary>
		/// ������e���͕\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SalesHistAnalyzeCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesHistAnalyzeCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SalesHistAnalyzeCndtn target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.St_SalesDate != target.St_SalesDate)resList.Add("St_SalesDate");
			if(this.Ed_SalesDate != target.Ed_SalesDate)resList.Add("Ed_SalesDate");
			if(this.St_MonthReportDate != target.St_MonthReportDate)resList.Add("St_MonthReportDate");
			if(this.Ed_MonthReportDate != target.Ed_MonthReportDate)resList.Add("Ed_MonthReportDate");
			if(this.St_CustomerCode != target.St_CustomerCode)resList.Add("St_CustomerCode");
			if(this.Ed_CustomerCode != target.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(this.St_SalesEmployeeCd != target.St_SalesEmployeeCd)resList.Add("St_SalesEmployeeCd");
			if(this.Ed_SalesEmployeeCd != target.Ed_SalesEmployeeCd)resList.Add("Ed_SalesEmployeeCd");
			if(this.St_SalesAreaCode != target.St_SalesAreaCode)resList.Add("St_SalesAreaCode");
			if(this.Ed_SalesAreaCode != target.Ed_SalesAreaCode)resList.Add("Ed_SalesAreaCode");
			if(this.PrintDiv != target.PrintDiv)resList.Add("PrintDiv");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.IsOptSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (this.MonthReportDiv != target.MonthReportDiv) resList.Add("MonthReportDiv");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");

			return resList;
		}

		/// <summary>
		/// ������e���͕\���o�����N���X��r����
		/// </summary>
		/// <param name="salesHistAnalyzeCndtn1">��r����SalesHistAnalyzeCndtn�N���X�̃C���X�^���X</param>
		/// <param name="salesHistAnalyzeCndtn2">��r����SalesHistAnalyzeCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesHistAnalyzeCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SalesHistAnalyzeCndtn salesHistAnalyzeCndtn1, SalesHistAnalyzeCndtn salesHistAnalyzeCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(salesHistAnalyzeCndtn1.EnterpriseCode != salesHistAnalyzeCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(salesHistAnalyzeCndtn1.SectionCode != salesHistAnalyzeCndtn2.SectionCode)resList.Add("SectionCode");
			if(salesHistAnalyzeCndtn1.St_SalesDate != salesHistAnalyzeCndtn2.St_SalesDate)resList.Add("St_SalesDate");
			if(salesHistAnalyzeCndtn1.Ed_SalesDate != salesHistAnalyzeCndtn2.Ed_SalesDate)resList.Add("Ed_SalesDate");
			if(salesHistAnalyzeCndtn1.St_MonthReportDate != salesHistAnalyzeCndtn2.St_MonthReportDate)resList.Add("St_MonthReportDate");
			if(salesHistAnalyzeCndtn1.Ed_MonthReportDate != salesHistAnalyzeCndtn2.Ed_MonthReportDate)resList.Add("Ed_MonthReportDate");
			if(salesHistAnalyzeCndtn1.St_CustomerCode != salesHistAnalyzeCndtn2.St_CustomerCode)resList.Add("St_CustomerCode");
			if(salesHistAnalyzeCndtn1.Ed_CustomerCode != salesHistAnalyzeCndtn2.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
			if(salesHistAnalyzeCndtn1.St_SalesEmployeeCd != salesHistAnalyzeCndtn2.St_SalesEmployeeCd)resList.Add("St_SalesEmployeeCd");
			if(salesHistAnalyzeCndtn1.Ed_SalesEmployeeCd != salesHistAnalyzeCndtn2.Ed_SalesEmployeeCd)resList.Add("Ed_SalesEmployeeCd");
			if(salesHistAnalyzeCndtn1.St_SalesAreaCode != salesHistAnalyzeCndtn2.St_SalesAreaCode)resList.Add("St_SalesAreaCode");
			if(salesHistAnalyzeCndtn1.Ed_SalesAreaCode != salesHistAnalyzeCndtn2.Ed_SalesAreaCode)resList.Add("Ed_SalesAreaCode");
			if(salesHistAnalyzeCndtn1.PrintDiv != salesHistAnalyzeCndtn2.PrintDiv)resList.Add("PrintDiv");
			if(salesHistAnalyzeCndtn1.EnterpriseName != salesHistAnalyzeCndtn2.EnterpriseName)resList.Add("EnterpriseName");
            if (salesHistAnalyzeCndtn1.IsOptSection != salesHistAnalyzeCndtn2.IsOptSection) resList.Add("IsOptSection");
            if (salesHistAnalyzeCndtn1.IsSelectAllSection != salesHistAnalyzeCndtn2.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (salesHistAnalyzeCndtn1.MonthReportDiv != salesHistAnalyzeCndtn2.MonthReportDiv) resList.Add("MoneyUnit");
            if (salesHistAnalyzeCndtn1.NewPageDiv != salesHistAnalyzeCndtn2.NewPageDiv) resList.Add("NewPageDiv");

			return resList;
		}
        #region �����ږ��̃v���p�e�B
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
                    case NewPageDivState.None: return ct_NewPageDivState_None;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// ���s�^�C�v�^�C�g���@�v���p�e�B
        /// </summary>
        public string PrintDivStateTitle
        {
            get
            {
                switch (this._printDiv)
                {
                    case PrintDivState.Customer: return ct_PrintDivState_Customer;
                    case PrintDivState.Employee: return ct_PrintDivState_Employee;
                    case PrintDivState.SalesArea: return ct_PrintDivState_SalesArea;
                    default: return "";
                }
            }
        }

        #endregion

        #region ���񋓑�
        /// <summary>
        /// �݌v����@�񋓑�
        /// </summary>
        public enum MonthReportDivState
        {
            /// <summary>����</summary>
            Do = 0,
            /// <summary>���Ȃ�</summary>
            None = 1
        }

        /// <summary>
        /// ���y�[�W�敪�@�񋓑�
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>���Ȃ�</summary>
            None = 1,
            /// <summary>���_��</summary>
            Section = 0,
        }

        /// <summary>
        /// ���s�^�C�v�񋓑�
        /// </summary>
        public enum PrintDivState
        {
            /// <summary>���Ӑ��</summary>
            Customer = 0,
            /// <summary>�S���ҕ�</summary>
            Employee = 1,
            /// <summary>�n���</summary>
            SalesArea = 2,

        }
        #endregion

        #region �����ږ���
        /// <summary>���y�[�W�敪 ���_��</summary>
        private const string ct_NewPageDivState_Section = "���_�P��";
        /// <summary>���y�[�W�敪 ���Ȃ�</summary>
        private const string ct_NewPageDivState_None = "���Ȃ�";

        /// <summary>���s�^�C�v</summary>
        private const string ct_PrintDivState_Customer = "���Ӑ�";
        private const string ct_PrintDivState_Employee = "�S����";
        private const string ct_PrintDivState_SalesArea = "�n��";
        #endregion
	}
}

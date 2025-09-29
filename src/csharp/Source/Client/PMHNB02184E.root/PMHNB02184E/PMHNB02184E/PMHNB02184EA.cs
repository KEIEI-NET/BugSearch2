using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustSalesDistributionReportParam
	/// <summary>
	///                      ���Ӑ�ʎ�����z�\���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ӑ�ʎ�����z�\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/11/21  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class CustSalesDistributionReportParam
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
		private string[] _sectionCode;

		/// <summary>�J�n�Ώۓ��t</summary>
		private Int32 _stSalesDate;

		/// <summary>�I���Ώۓ��t</summary>
		private Int32 _edSalesDate;

		/// <summary>�J�n�̔��]�ƈ��R�[�h</summary>
		private string _stSalesEmployeeCd = "";

		/// <summary>�I���̔��]�ƈ��R�[�h</summary>
		private string _edSalesEmployeeCd = "";

		/// <summary>�̔��G���A�R�[�h</summary>
		/// <remarks>�n��R�[�h</remarks>
		private Int32 _stSalesAreaCode;

		/// <summary>�̔��G���A�R�[�h</summary>
		/// <remarks>�n��R�[�h</remarks>
		private Int32 _edSalesAreaCode;

		/// <summary>�J�n���Ӑ�R�[�h</summary>
		private Int32 _stCustomerCode;

		/// <summary>�I�����Ӑ�R�[�h</summary>
		private Int32 _edCustomerCode;

		/// <summary>���s�^�C�v</summary>
		/// <remarks>0:���Ӑ� 1:�S���� 2:�n��</remarks>
        private PrintTypeState _printType;

		/// <summary>���і�����敪</summary>
		/// <remarks>0:���� 1:���Ȃ�</remarks>
		private Int32 _searchDiv;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        // ���������ȊO
        /// <summary>���_�I�v�V�����敪</summary>
        private bool _isOptSection = false;

        /// <summary>�S���_�I���敪</summary>
        private bool _isSelectAllSection = false;

        /// <summary>����</summary>
        /// <remarks>0:���_ 1:���Ȃ�</remarks>
        private NewPageDivState _newPageDiv;

        /// <summary>���ʕt�ݒ�@�P��</summary>
        /// <remarks>0:�S���_ 1:���_��</remarks>
        private RankSectionState _rankSection;

        /// <summary>���ʕt�ݒ�@��ʁE����</summary>
        /// <remarks>0:��� 1:����</remarks>
        private RankHighLowState _rankHighLow;

        /// <summary>���ʕt�ݒ�@�ő�l</summary>
        private Int32 _rankOrderMax;

        /// <summary>���ʎw��</summary>
        /// <remarks>0:������ 1:�e��</remarks>
        private RankStandardState _rankStandard;

        /// <summary>�����</summary>
        private PrintOrderState _printOrder;
        
        /// <summary>����N����</summary>
		private DateTime _startDate;

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

		/// public propaty name  :  StSalesDate
		/// <summary>�J�n�Ώۓ��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�Ώۓ��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StSalesDate
		{
			get{return _stSalesDate;}
			set{_stSalesDate = value;}
		}

		/// public propaty name  :  EdSalesDate
		/// <summary>�I���Ώۓ��t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���Ώۓ��t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdSalesDate
		{
			get{return _edSalesDate;}
			set{_edSalesDate = value;}
		}

		/// public propaty name  :  StSalesEmployeeCd
		/// <summary>�J�n�̔��]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�̔��]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StSalesEmployeeCd
		{
			get{return _stSalesEmployeeCd;}
			set{_stSalesEmployeeCd = value;}
		}

		/// public propaty name  :  EdSalesEmployeeCd
		/// <summary>�I���̔��]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���̔��]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EdSalesEmployeeCd
		{
			get{return _edSalesEmployeeCd;}
			set{_edSalesEmployeeCd = value;}
		}

		/// public propaty name  :  StSalesAreaCode
		/// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
		/// <value>�n��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StSalesAreaCode
		{
			get{return _stSalesAreaCode;}
			set{_stSalesAreaCode = value;}
		}

		/// public propaty name  :  EdSalesAreaCode
		/// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
		/// <value>�n��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdSalesAreaCode
		{
			get{return _edSalesAreaCode;}
			set{_edSalesAreaCode = value;}
		}

		/// public propaty name  :  StCustomerCode
		/// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StCustomerCode
		{
			get{return _stCustomerCode;}
			set{_stCustomerCode = value;}
		}

		/// public propaty name  :  EdCustomerCode
		/// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdCustomerCode
		{
			get{return _edCustomerCode;}
			set{_edCustomerCode = value;}
		}

		/// public propaty name  :  PrintType
		/// <summary>���s�^�C�v�v���p�e�B</summary>
		/// <value>0:���Ӑ� 1:�S���� 2:�n��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���s�^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public PrintTypeState PrintType
		{
			get{return _printType;}
            set{ _printType = value; }
		}

		/// public propaty name  :  SearchDiv
		/// <summary>���і�����敪�v���p�e�B</summary>
		/// <value>0:���� 1:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���і�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SearchDiv
		{
			get{return _searchDiv;}
			set{_searchDiv = value;}
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
        /// ���ʕt�ݒ�@�P�ʃv���p�e�B
        /// </summary>
        public RankSectionState RankSection
        {
            get { return this._rankSection; }
            set { this._rankSection = value; }
        }

        /// <summary>
        /// ���ʕt�ݒ�@��ʁE���ʃv���p�e�B
        /// </summary>
        public RankHighLowState RankHighLow
        {
            get { return this._rankHighLow; }
            set { this._rankHighLow = value; }
        }

        /// <summary>
        /// ���ʕt�ݒ�@�ő�l�v���p�e�B
        /// </summary>
        public Int32 RankOrderMax
        {
            get { return this._rankOrderMax; }
            set { this._rankOrderMax = value; }
        }

        /// <summary>
        /// ���ʎw��@�v���p�e�B
        /// </summary>
        public RankStandardState RankStandard
        {
            get { return this._rankStandard; }
            set { this._rankStandard = value; }
        }

        /// <summary>
        /// ������@�v���p�e�B
        /// </summary>
        public PrintOrderState PrintOrder
        {
            get { return this._printOrder; }
            set { this._printOrder = value; }
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
        /// ������@�v���p�e�B
        /// </summary>
        public DateTime StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }


		/// <summary>
		/// ���Ӑ�ʎ�����z�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>CustSalesDistributionReportParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustSalesDistributionReportParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustSalesDistributionReportParam()
		{
		}

		/// <summary>
		/// ���Ӑ�ʎ�����z�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="sectionCode">���_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
		/// <param name="stSalesDate">�J�n�Ώۓ��t</param>
		/// <param name="edSalesDate">�I���Ώۓ��t</param>
		/// <param name="stSalesEmployeeCd">�J�n�̔��]�ƈ��R�[�h</param>
		/// <param name="edSalesEmployeeCd">�I���̔��]�ƈ��R�[�h</param>
		/// <param name="stSalesAreaCode">�̔��G���A�R�[�h(�n��R�[�h)</param>
		/// <param name="edSalesAreaCode">�̔��G���A�R�[�h(�n��R�[�h)</param>
		/// <param name="stCustomerCode">�J�n���Ӑ�R�[�h</param>
		/// <param name="edCustomerCode">�I�����Ӑ�R�[�h</param>
		/// <param name="printType">���s�^�C�v(0:���Ӑ� 1:�S���� 2:�n��)</param>
		/// <param name="searchDiv">���і�����敪(0:���� 1:���Ȃ�)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>CustSalesDistributionReportParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustSalesDistributionReportParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public CustSalesDistributionReportParam(string enterpriseCode, string[] sectionCode, Int32 stSalesDate, Int32 edSalesDate, string stSalesEmployeeCd, string edSalesEmployeeCd, Int32 stSalesAreaCode, Int32 edSalesAreaCode, Int32 stCustomerCode, Int32 edCustomerCode, PrintTypeState printType, Int32 searchDiv, string enterpriseName,
            bool isOptSection, bool isSelectAllSection, RankSectionState rankSection, RankHighLowState rankHighLow, Int32 rankOrderMax, RankStandardState rankStandard, PrintOrderState printOrder, NewPageDivState newPageDiv, DateTime startDate)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._stSalesDate = stSalesDate;
			this._edSalesDate = edSalesDate;
			this._stSalesEmployeeCd = stSalesEmployeeCd;
			this._edSalesEmployeeCd = edSalesEmployeeCd;
			this._stSalesAreaCode = stSalesAreaCode;
			this._edSalesAreaCode = edSalesAreaCode;
			this._stCustomerCode = stCustomerCode;
			this._edCustomerCode = edCustomerCode;
			this._printType = printType;
			this._searchDiv = searchDiv;
			this._enterpriseName = enterpriseName;

            this._isOptSection = isOptSection;
            this._isSelectAllSection = isSelectAllSection;
            this._rankSection = rankSection;
            this._rankHighLow = rankHighLow;
            this._rankOrderMax = rankOrderMax;
            this._rankStandard = rankStandard;
            this._printOrder = printOrder;
            this._newPageDiv = newPageDiv;
            this._startDate = startDate;
		}

		/// <summary>
		/// ���Ӑ�ʎ�����z�\���o�����N���X��������
		/// </summary>
		/// <returns>CustSalesDistributionReportParam�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustSalesDistributionReportParam�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustSalesDistributionReportParam Clone()
		{
			return new CustSalesDistributionReportParam(this._enterpriseCode,this._sectionCode,this._stSalesDate,this._edSalesDate,this._stSalesEmployeeCd,this._edSalesEmployeeCd,this._stSalesAreaCode,this._edSalesAreaCode,this._stCustomerCode,this._edCustomerCode,this._printType,this._searchDiv,this._enterpriseName,
                this._isOptSection, this._isSelectAllSection, this._rankSection, this._rankHighLow, this._rankOrderMax, this._rankStandard, this._printOrder, this._newPageDiv, this._startDate);
		}

		/// <summary>
		/// ���Ӑ�ʎ�����z�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustSalesDistributionReportParam�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustSalesDistributionReportParam�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(CustSalesDistributionReportParam target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.StSalesDate == target.StSalesDate)
				 && (this.EdSalesDate == target.EdSalesDate)
				 && (this.StSalesEmployeeCd == target.StSalesEmployeeCd)
				 && (this.EdSalesEmployeeCd == target.EdSalesEmployeeCd)
				 && (this.StSalesAreaCode == target.StSalesAreaCode)
				 && (this.EdSalesAreaCode == target.EdSalesAreaCode)
				 && (this.StCustomerCode == target.StCustomerCode)
				 && (this.EdCustomerCode == target.EdCustomerCode)
				 && (this.PrintType == target.PrintType)
				 && (this.SearchDiv == target.SearchDiv)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsOptSection == target.IsOptSection)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (this.RankSection == target.RankSection)
                 && (this.RankHighLow == target.RankHighLow)
                 && (this.RankOrderMax == target.RankOrderMax)
                 && (this.RankStandard == target.RankStandard)
                 && (this.PrintOrder == target.PrintOrder)
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.StartDate == target.StartDate)  
                 );
		}

		/// <summary>
		/// ���Ӑ�ʎ�����z�\���o�����N���X��r����
		/// </summary>
		/// <param name="custSalesDistributionReportParam1">
		///                    ��r����CustSalesDistributionReportParam�N���X�̃C���X�^���X
		/// </param>
		/// <param name="custSalesDistributionReportParam2">��r����CustSalesDistributionReportParam�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustSalesDistributionReportParam�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(CustSalesDistributionReportParam custSalesDistributionReportParam1, CustSalesDistributionReportParam custSalesDistributionReportParam2)
		{
			return ((custSalesDistributionReportParam1.EnterpriseCode == custSalesDistributionReportParam2.EnterpriseCode)
				 && (custSalesDistributionReportParam1.SectionCode == custSalesDistributionReportParam2.SectionCode)
				 && (custSalesDistributionReportParam1.StSalesDate == custSalesDistributionReportParam2.StSalesDate)
				 && (custSalesDistributionReportParam1.EdSalesDate == custSalesDistributionReportParam2.EdSalesDate)
				 && (custSalesDistributionReportParam1.StSalesEmployeeCd == custSalesDistributionReportParam2.StSalesEmployeeCd)
				 && (custSalesDistributionReportParam1.EdSalesEmployeeCd == custSalesDistributionReportParam2.EdSalesEmployeeCd)
				 && (custSalesDistributionReportParam1.StSalesAreaCode == custSalesDistributionReportParam2.StSalesAreaCode)
				 && (custSalesDistributionReportParam1.EdSalesAreaCode == custSalesDistributionReportParam2.EdSalesAreaCode)
				 && (custSalesDistributionReportParam1.StCustomerCode == custSalesDistributionReportParam2.StCustomerCode)
				 && (custSalesDistributionReportParam1.EdCustomerCode == custSalesDistributionReportParam2.EdCustomerCode)
				 && (custSalesDistributionReportParam1.PrintType == custSalesDistributionReportParam2.PrintType)
				 && (custSalesDistributionReportParam1.SearchDiv == custSalesDistributionReportParam2.SearchDiv)
				 && (custSalesDistributionReportParam1.EnterpriseName == custSalesDistributionReportParam2.EnterpriseName)
                 && (custSalesDistributionReportParam1.IsOptSection == custSalesDistributionReportParam2.IsOptSection)
                 && (custSalesDistributionReportParam1.IsSelectAllSection == custSalesDistributionReportParam2.IsSelectAllSection)
                 && (custSalesDistributionReportParam1.RankSection == custSalesDistributionReportParam2.RankSection)
                 && (custSalesDistributionReportParam1.RankHighLow == custSalesDistributionReportParam2.RankHighLow)
                 && (custSalesDistributionReportParam1.RankOrderMax == custSalesDistributionReportParam2.RankOrderMax)
                 && (custSalesDistributionReportParam1.RankStandard == custSalesDistributionReportParam2.RankStandard)
                 && (custSalesDistributionReportParam1.PrintOrder == custSalesDistributionReportParam2.PrintOrder)
                 && (custSalesDistributionReportParam1.NewPageDiv == custSalesDistributionReportParam2.NewPageDiv)
                 && (custSalesDistributionReportParam1.StartDate == custSalesDistributionReportParam2.StartDate)

                 );
		}
		/// <summary>
		/// ���Ӑ�ʎ�����z�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustSalesDistributionReportParam�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustSalesDistributionReportParam�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(CustSalesDistributionReportParam target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.StSalesDate != target.StSalesDate)resList.Add("StSalesDate");
			if(this.EdSalesDate != target.EdSalesDate)resList.Add("EdSalesDate");
			if(this.StSalesEmployeeCd != target.StSalesEmployeeCd)resList.Add("StSalesEmployeeCd");
			if(this.EdSalesEmployeeCd != target.EdSalesEmployeeCd)resList.Add("EdSalesEmployeeCd");
			if(this.StSalesAreaCode != target.StSalesAreaCode)resList.Add("StSalesAreaCode");
			if(this.EdSalesAreaCode != target.EdSalesAreaCode)resList.Add("EdSalesAreaCode");
			if(this.StCustomerCode != target.StCustomerCode)resList.Add("StCustomerCode");
			if(this.EdCustomerCode != target.EdCustomerCode)resList.Add("EdCustomerCode");
            if (this.PrintType != target.PrintType) resList.Add("PrintType");
			if(this.SearchDiv != target.SearchDiv)resList.Add("SearchDiv");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (this.RankSection != target.RankSection) resList.Add("RankSection");
            if (this.RankHighLow != target.RankHighLow) resList.Add("RankHighLow");
            if (this.RankOrderMax != target.RankOrderMax) resList.Add("RankOrderMax");
            if (this.RankStandard != target.RankStandard) resList.Add("RankStandard");
            if (this.PrintOrder != target.PrintOrder) resList.Add("PrintOrder");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.StartDate != target.StartDate) resList.Add("StartDate");


			return resList;
		}

		/// <summary>
		/// ���Ӑ�ʎ�����z�\���o�����N���X��r����
		/// </summary>
		/// <param name="custSalesDistributionReportParam1">��r����CustSalesDistributionReportParam�N���X�̃C���X�^���X</param>
		/// <param name="custSalesDistributionReportParam2">��r����CustSalesDistributionReportParam�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustSalesDistributionReportParam�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(CustSalesDistributionReportParam custSalesDistributionReportParam1, CustSalesDistributionReportParam custSalesDistributionReportParam2)
		{
			ArrayList resList = new ArrayList();
			if(custSalesDistributionReportParam1.EnterpriseCode != custSalesDistributionReportParam2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(custSalesDistributionReportParam1.SectionCode != custSalesDistributionReportParam2.SectionCode)resList.Add("SectionCode");
			if(custSalesDistributionReportParam1.StSalesDate != custSalesDistributionReportParam2.StSalesDate)resList.Add("StSalesDate");
			if(custSalesDistributionReportParam1.EdSalesDate != custSalesDistributionReportParam2.EdSalesDate)resList.Add("EdSalesDate");
			if(custSalesDistributionReportParam1.StSalesEmployeeCd != custSalesDistributionReportParam2.StSalesEmployeeCd)resList.Add("StSalesEmployeeCd");
			if(custSalesDistributionReportParam1.EdSalesEmployeeCd != custSalesDistributionReportParam2.EdSalesEmployeeCd)resList.Add("EdSalesEmployeeCd");
			if(custSalesDistributionReportParam1.StSalesAreaCode != custSalesDistributionReportParam2.StSalesAreaCode)resList.Add("StSalesAreaCode");
			if(custSalesDistributionReportParam1.EdSalesAreaCode != custSalesDistributionReportParam2.EdSalesAreaCode)resList.Add("EdSalesAreaCode");
			if(custSalesDistributionReportParam1.StCustomerCode != custSalesDistributionReportParam2.StCustomerCode)resList.Add("StCustomerCode");
			if(custSalesDistributionReportParam1.EdCustomerCode != custSalesDistributionReportParam2.EdCustomerCode)resList.Add("EdCustomerCode");
            if (custSalesDistributionReportParam1.PrintType != custSalesDistributionReportParam2.PrintType) resList.Add("PrintType");
			if(custSalesDistributionReportParam1.SearchDiv != custSalesDistributionReportParam2.SearchDiv)resList.Add("SearchDiv");
			if(custSalesDistributionReportParam1.EnterpriseName != custSalesDistributionReportParam2.EnterpriseName)resList.Add("EnterpriseName");
            if (custSalesDistributionReportParam1.IsOptSection != custSalesDistributionReportParam2.IsOptSection) resList.Add("IsOptSection");
            if (custSalesDistributionReportParam1.IsSelectAllSection != custSalesDistributionReportParam2.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (custSalesDistributionReportParam1.RankSection != custSalesDistributionReportParam2.RankSection) resList.Add("RankSection");
            if (custSalesDistributionReportParam1.RankHighLow != custSalesDistributionReportParam2.RankHighLow) resList.Add("RankHighLow");
            if (custSalesDistributionReportParam1.RankOrderMax != custSalesDistributionReportParam2.RankOrderMax) resList.Add("RankOrderMax");
            if (custSalesDistributionReportParam1.RankStandard != custSalesDistributionReportParam2.RankStandard) resList.Add("RankStandard");
            if (custSalesDistributionReportParam1.PrintOrder != custSalesDistributionReportParam2.PrintOrder) resList.Add("PrintOrder");
            if (custSalesDistributionReportParam1.NewPageDiv != custSalesDistributionReportParam2.NewPageDiv) resList.Add("NewPageDiv");
            if (custSalesDistributionReportParam1.StartDate != custSalesDistributionReportParam2.StartDate) resList.Add("StartDate"); 

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
        /// ���ʕt�ݒ�P�ʁ@�v���p�e�B
        /// </summary>
        public string RankSectionStateTitle
        {
            get
            {
                switch (this._rankSection)
                {
                    case RankSectionState.All: return ct_RankSectionState_All;
                    case RankSectionState.Section: return ct_RankSectionState_Section;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// ���ʕt�ݒ� ��ʁE���ʁ@�v���p�e�B
        /// </summary>
        public string RankHighLowStateTitle
        {
            get
            {
                switch (this._rankHighLow)
                {
                    case RankHighLowState.High: return ct_RankHighLowState_High;
                    case RankHighLowState.Low: return ct_RankHighLowState_Low;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// ���ʎw��@�v���p�e�B
        /// </summary>
        public string RankStandardStateTitle
        {
            get
            {
                switch (this._rankStandard)
                {
                    case RankStandardState.Sales: return ct_RankStandardState_Sales;
                    case RankStandardState.Gross: return ct_RankStandardState_Gross;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// ������@�v���p�e�B
        /// </summary>
        public string PrintOrderStateTitle
        {
            get
            {
                switch (this._printOrder)
                {
                    case PrintOrderState.Code: return ct_PrintOrderState_Code;
                    case PrintOrderState.Order: return ct_PrintOrderState_Order;
                    default: return "";
                }
            }
        }

        /// <summary>
        /// ���s�^�C�v�@�v���p�e�B
        /// </summary>
        public string PrintTypeStateTitle
        {
            get
            {
                switch (this._printType)
                {
                    case PrintTypeState.Customer: return ct_PrintTypeState_Customer;
                    case PrintTypeState.Employee: return ct_PrintTypeState_Employee;
                    case PrintTypeState.Area: return ct_PrintTypeState_Area;
                    default: return "";
                }
            }
        }
        #endregion

        #region ���񋓑�

        /// <summary>
        /// ���y�[�W�敪�@�񋓑�
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>���_��</summary>
            Section = 0,
            /// <summary>���Ȃ�</summary>
            None = 1,
        }

        /// <summary>
        /// ���ʕt�ݒ�P�ʁ@�񋓑�
        /// </summary>
        public enum RankSectionState
        {
            /// <summary>�S���_</summary>
            All = 0,
            /// <summary>���_��</summary>
            Section = 1,
        }

        /// <summary>
        /// ���ʕt�ݒ��ʉ��ʁ@�񋓑�
        /// </summary>
        public enum RankHighLowState
        {
            /// <summary>���</summary>
            High = 0,
            /// <summary>����</summary>
            Low = 1,
        }

        /// <summary>
        /// ���ʎw�� �񋓑�
        /// </summary>
        public enum RankStandardState
        {
            /// <summary>������</summary>
            Sales = 0,
            /// <summary>�e��</summary>
            Gross = 1,
        }

        /// <summary>
        /// ����� �񋓑�
        /// </summary>
        public enum PrintOrderState
        {
            /// <summary>�R�[�h</summary>
            Code = 0,
            /// <summary>����</summary>
            Order = 1,
        }

        /// <summary>
        /// ���s�^�C�v �񋓑�
        /// </summary>
        public enum PrintTypeState
        {
            /// <summary>���Ӑ�</summary>
            Customer = 0,
            /// <summary>�S����</summary>
            Employee = 1,
            /// <summary>�n��</summary>
            Area = 2,
        }
        #endregion

        #region �����ږ���

        /// <summary>���y�[�W�敪 ���_��</summary>
        private const string ct_NewPageDivState_Section = "���_�P��";
        /// <summary>���y�[�W�敪 ���Ȃ�</summary>
        private const string ct_NewPageDivState_None = "���Ȃ�";

        /// <summary>���ʕt�ݒ�P�� �S���_</summary>
        private const string ct_RankSectionState_All = "�S���_��";
        /// <summary>���ʕt�ݒ�P�� ���_��</summary>
        private const string ct_RankSectionState_Section = "���_����";

        /// <summary>���ʕt�ݒ��ʉ��� ���</summary>
        private const string ct_RankHighLowState_High = "���";
        /// <summary>���ʕt�ݒ��ʉ��� ����</summary>
        private const string ct_RankHighLowState_Low = "����";

        /// <summary>���ʎw�� ������</summary>
        private const string ct_RankStandardState_Sales = "������";
        /// <summary>���ʎw�� �e��</summary>
        private const string ct_RankStandardState_Gross = "�e��";

        /// <summary>����� �R�[�h</summary>
        private const string ct_PrintOrderState_Code = "�R�[�h";
        /// <summary>����� ����</summary>
        private const string ct_PrintOrderState_Order = "����";

        /// <summary>���s�^�C�v ���Ӑ�</summary>
        private const string ct_PrintTypeState_Customer = "���Ӑ�";
        /// <summary>���s�^�C�v �S����</summary>
        private const string ct_PrintTypeState_Employee = "�S����";
        /// <summary>���s�^�C�v �n��</summary>
        private const string ct_PrintTypeState_Area = "�n��";
        #endregion
	}
}

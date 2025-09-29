//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���������s(����)
// �v���O�����T�v   : ���������s(����)�̈󎚂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SumExtrInfo_DemandTotal
	/// <summary>
    ///                      ���������s(����)���o�����N���X
	/// </summary>
	/// <remarks>
    /// <br>note             :   ���������s(����)���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/04/21  (CSharp File Generated Date)</br>
    /// <br>Note             : 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer       : ���O</br>
    /// <br>Date             : 2020/04/13</br>
	/// </remarks>
	public class SumExtrInfo_DemandTotal
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�S�БI��</summary>
		/// <remarks>true:�S�БI�� false:�e���_�I��</remarks>
		private bool _isSelectAllSection;

		/// <summary>�S���_���R�[�h�o��</summary>
		/// <remarks>true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�</remarks>
		private bool _isOutputAllSecRec;

        /// <summary>���ьv�㋒�_�R�[�h���X�g</summary>
        /// <remarks>�����^�@���z�񍀖� �S�Ўw���{""}</remarks>
        private string[] _resultsAddUpSecList;
        
		/// <summary>���_�I�v�V���������敪</summary>
		/// <remarks>true:������, false:������</remarks>
		private bool _isOptSection;

		/// <summary>�{�Ћ@�\�v���p�e�B</summary>
		/// <remarks>true:�{��, false:���_</remarks>
		private bool _isMainOfficeFunc;

        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD ���������s�Ȃ������i������j</remarks>
        private DateTime _addUpDate;
        
        /// <summary>���Ӑ�R�[�h(�J�n)</summary>
		private Int32 _customerCodeSt;

		/// <summary>���Ӑ�R�[�h(�I��)</summary>
		private Int32 _customerCodeEd;

        /// <summary>�S���敪</summary>
		private Int32 _customerAgentDivCd;

		/// <summary>�W���S���R�[�h(�J�n)</summary>
		/// <remarks>�����^</remarks>
		private string _billCollecterCdSt = "";

		/// <summary>�W���S���R�[�h(�I��)</summary>
		/// <remarks>�����^</remarks>
		private string _billCollecterCdEd = "";

		/// <summary>�ڋq�S���R�[�h(�J�n)</summary>
		/// <remarks>�����^</remarks>
		private string _customerAgentCdSt = "";

		/// <summary>�ڋq�S���R�[�h(�I��)</summary>
		/// <remarks>�����^</remarks>
		private string _customerAgentCdEd = "";

        /// <summary>�o�͏�</summary>
		private Int32 _sortOrder;

        /// <summary>�o�͋��z����</summary>
		private Int32 _outPutPriceCond;

        /// <summary>����</summary>
        private Int32 _newPageDiv;

        /// <summary>�̔��G���A�R�[�h(�J�n)</summary>
        private Int32 _salesAreaCodeSt;

        /// <summary>�̔��G���A�R�[�h(�I��)</summary>
        private Int32 _salesAreaCodeEd;

        /// <summary>�������</summary>
        private Int32 _collectRatePrtDiv;

        /// <summary>�c����������</summary>
        private Int32 _balanceDepositDtl;

        /// <summary>���������s���Ӑ�t���O</summary>
        private bool _isBillOutputOnly;

        /// <summary>�`�[������</summary>
        private Int32 _slipPrtKind;

        /// <summary>���s��</summary>
        private DateTime _issueDay;
        
        /// <summary>�������Ӑ����</summary>
        private Int32 _sumCustDtl;

        /// <summary>���|�敪</summary>
        private Int32 _accRecDivCd;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
        /// <summary>����ŕʂ̓���敪</summary>
        /// <remarks>0:�󎚂��� 1:�󎚂��Ȃ�</remarks>
        private Int32 _taxPrintDiv;

        /// <summary>�ŗ�1</summary>
        /// <remarks>�ŗ�1</remarks>
        private Double _taxRate1;

        /// <summary>�ŗ�2</summary>
        /// <remarks>�ŗ�2</remarks>
        private Double _taxRate2;
        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<


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

		/// public propaty name  :  IsSelectAllSection
		/// <summary>�S�БI���v���p�e�B</summary>
		/// <value>true:�S�БI�� false:�e���_�I��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S�БI���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsSelectAllSection
		{
			get{return _isSelectAllSection;}
			set{_isSelectAllSection = value;}
		}

		/// public propaty name  :  IsOutputAllSecRec
		/// <summary>�S���_���R�[�h�o�̓v���p�e�B</summary>
		/// <value>true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S���_���R�[�h�o�̓v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsOutputAllSecRec
		{
			get{return _isOutputAllSecRec;}
			set{_isOutputAllSecRec = value;}
		}

        /// public propaty name  :  ResultsAddUpSecList
        /// <summary>���ьv�㋒�_�R�[�h���X�g�v���p�e�B</summary>
        /// <value>�����^�@���z�񍀖� �S�Ўw���{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ьv�㋒�_�R�[�h���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] ResultsAddUpSecList
        {
            get { return _resultsAddUpSecList; }
            set { _resultsAddUpSecList = value; }
        }
        
		/// public propaty name  :  IsOptSection
		/// <summary>���_�I�v�V���������敪�v���p�e�B</summary>
		/// <value>true:������, false:������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�I�v�V���������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsOptSection
		{
			get{return _isOptSection;}
			set{_isOptSection = value;}
		}

		/// public propaty name  :  IsMainOfficeFunc
		/// <summary>�{�Ћ@�\�v���p�e�B�v���p�e�B</summary>
		/// <value>true:�{��, false:���_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �{�Ћ@�\�v���p�e�B�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsMainOfficeFunc
		{
			get{return _isMainOfficeFunc;}
			set{_isMainOfficeFunc = value;}
		}

        /// public propaty name  :  AddUpDate
        /// <summary>�v��N�����v���p�e�B</summary>
        /// <value>YYYYMMDD ���������s�Ȃ�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }
        
		/// public propaty name  :  CustomerCodeSt
		/// <summary>���Ӑ�R�[�h(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCodeSt
		{
			get{return _customerCodeSt;}
			set{_customerCodeSt = value;}
		}

		/// public propaty name  :  CustomerCodeEd
		/// <summary>���Ӑ�R�[�h(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCodeEd
		{
			get{return _customerCodeEd;}
			set{_customerCodeEd = value;}
		}

        /// public propaty name  :  CustomerAgentDivCd
		/// <summary>�S���敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerAgentDivCd
		{
			get{return _customerAgentDivCd;}
			set{_customerAgentDivCd = value;}
		}

		/// public propaty name  :  BillCollecterCdSt
		/// <summary>�W���S���R�[�h(�J�n)�v���p�e�B</summary>
		/// <value>�����^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W���S���R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BillCollecterCdSt
		{
			get{return _billCollecterCdSt;}
			set{_billCollecterCdSt = value;}
		}

		/// public propaty name  :  BillCollecterCdEd
		/// <summary>�W���S���R�[�h(�I��)�v���p�e�B</summary>
		/// <value>�����^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W���S���R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BillCollecterCdEd
		{
			get{return _billCollecterCdEd;}
			set{_billCollecterCdEd = value;}
		}

		/// public propaty name  :  CustomerAgentCdSt
		/// <summary>�ڋq�S���R�[�h(�J�n)�v���p�e�B</summary>
		/// <value>�����^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ڋq�S���R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerAgentCdSt
		{
			get{return _customerAgentCdSt;}
			set{_customerAgentCdSt = value;}
		}

		/// public propaty name  :  CustomerAgentCdEd
		/// <summary>�ڋq�S���R�[�h(�I��)�v���p�e�B</summary>
		/// <value>�����^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ڋq�S���R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerAgentCdEd
		{
			get{return _customerAgentCdEd;}
			set{_customerAgentCdEd = value;}
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
			get{return _sortOrder;}
			set{_sortOrder = value;}
		}

        /// public propaty name  :  OutPutPriceCond
		/// <summary>�o�͋��z�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͋��z�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OutPutPriceCond
		{
			get{return _outPutPriceCond;}
			set{_outPutPriceCond = value;}
		}

        /// public propaty name  :  NewPageDiv
        /// <summary>���Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NewPageDiv
        {
            get { return _newPageDiv; }
            set { _newPageDiv = value; }
        }

        /// public propaty name  :  SalesAreaCodeSt
        /// <summary>�̔��G���A�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCodeSt
        {
            get { return _salesAreaCodeSt; }
            set { _salesAreaCodeSt = value; }
        }

        /// public propaty name  :  SalesAreaCodeEd
        /// <summary>�̔��G���A�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCodeEd
        {
            get { return _salesAreaCodeEd; }
            set { _salesAreaCodeEd = value; }
        }

        /// public propaty name  :  CollectRatePrtDiv
        /// <summary>������󎚃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������󎚃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectRatePrtDiv
        {
            get { return _collectRatePrtDiv; }
            set { _collectRatePrtDiv = value; }
        }

        /// public propaty name  :  BalanceDepositDtl
        /// <summary>�c����������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �c����������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BalanceDepositDtl
        {
            get { return _balanceDepositDtl; }
            set { _balanceDepositDtl = value; }
        }

        /// public propaty name  :  IsBillOutputOnly
        /// <summary>���������s���Ӑ�t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������s���Ӑ�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsBillOutputOnly
        {
            get { return _isBillOutputOnly; }
            set { _isBillOutputOnly = value; }
        }

        /// public propaty name  :  SlipPrtKind
        /// <summary>�`�[�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipPrtKind
        {
            get { return _slipPrtKind; }
            set { _slipPrtKind = value; }
        }

        /// public propaty name  :  IssueDay
        /// <summary>���s���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime IssueDay
        {
            get { return _issueDay; }
            set { _issueDay = value; }
        }
        
        /// public propaty name  :  SumCustDtl
        /// <summary>�e���Ӑ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���Ӑ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SumCustDtl
        {
            get { return _sumCustDtl; }
            set { _sumCustDtl = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>���|�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���|�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
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

        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
        /// public propaty name  :  TaxPrintDiv
        /// <summary>�ŕʓ���󎚋敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŕʓ���󎚋敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxPrintDiv
        {
            get { return _taxPrintDiv; }
            set { _taxPrintDiv = value; }
        }

        /// public propaty name  :  TaxRate1
        /// <summary>�ŗ�1</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�1</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate1
        {
            get { return _taxRate1; }
            set { _taxRate1 = value; }
        }

        /// public propaty name  :  TaxRate2
        /// <summary>�ŗ�2</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�2</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }
        // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<


		/// <summary>
        /// ���������s(����)���o�����N���X�R���X�g���N�^
		/// </summary>
        /// <returns>SumExtrInfo_DemandTotal�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandTotal�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SumExtrInfo_DemandTotal()
		{
		}

		/// <summary>
        /// ���������s(����)���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="isSelectAllSection">�S�БI��(true:�S�БI�� false:�e���_�I��)</param>
		/// <param name="isOutputAllSecRec">�S���_���R�[�h�o��(true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�)</param>
		/// <param name="resultsAddUpSecList">���ьv�㋒�_�R�[�h���X�g(�����^�@���z�񍀖�)</param>
		/// <param name="isOptSection">���_�I�v�V���������敪(true:������, false:������)</param>
		/// <param name="isMainOfficeFunc">�{�Ћ@�\�v���p�e�B(true:�{��, false:���_)</param>
        /// <param name="addUpDate">�v��N����</param>
		/// <param name="customerCodeSt">���Ӑ�R�[�h(�J�n)</param>
		/// <param name="customerCodeEd">���Ӑ�R�[�h(�I��)</param>
		/// <param name="customerAgentDivCd">�S���敪</param>
		/// <param name="billCollecterCdSt">�W���S���R�[�h(�J�n)(�����^)</param>
		/// <param name="billCollecterCdEd">�W���S���R�[�h(�I��)(�����^)</param>
		/// <param name="customerAgentCdSt">�ڋq�S���R�[�h(�J�n)(�����^)</param>
		/// <param name="customerAgentCdEd">�ڋq�S���R�[�h(�I��)(�����^)</param>
		/// <param name="sortOrder">�o�͏�</param>
		/// <param name="outPutPriceCond">�o�͋��z����</param>
        /// <param name="newPageDiv">����</param>
        /// <param name="salesAreaCodeSt">�n��R�[�h(�J�n)</param>
        /// <param name="salesAreaCodeEd">�n��R�[�h(�I��)</param>
        /// <param name="collectRatePrtDiv">�������</param>
        /// <param name="balanceDepositDtl">�c����������</param>
        /// <param name="isBillOutputOnly">���������s���Ӑ�t���O</param>
        /// <param name="slipPrtKind">�`�[������</param>
        /// <param name="issueDay">���s��</param>
        /// <param name="sumCustDtl">�������Ӑ����</param>
        /// <param name="accRecDivCd">���|�敪</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="taxPrintDiv">�ŕʓ���󎚋敪</param>
        /// <param name="taxRate1">�ŗ�1</param>
        /// <param name="taxRate2">�ŗ�2</param>
        /// <returns>SumExtrInfo_DemandTotal�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandTotal�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        // --- UPD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
        //public SumExtrInfo_DemandTotal(string enterpriseCode, bool isSelectAllSection, bool isOutputAllSecRec, string[] resultsAddUpSecList, bool isOptSection, bool isMainOfficeFunc, DateTime addUpDate, Int32 customerCodeSt, Int32 customerCodeEd, Int32 customerAgentDivCd, string billCollecterCdSt, string billCollecterCdEd, string customerAgentCdSt, string customerAgentCdEd, Int32 sortOrder, Int32 outPutPriceCond, Int32 newPageDiv, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 collectRatePrtDiv, Int32 balanceDepositDtl, bool isBillOutputOnly, Int32 slipPrtKind, DateTime issueDay, Int32 sumCustDtl, Int32 accRecDivCd, string enterpriseName)
        public SumExtrInfo_DemandTotal(string enterpriseCode, bool isSelectAllSection, bool isOutputAllSecRec, string[] resultsAddUpSecList, bool isOptSection, bool isMainOfficeFunc, DateTime addUpDate, Int32 customerCodeSt, Int32 customerCodeEd, Int32 customerAgentDivCd, string billCollecterCdSt, string billCollecterCdEd, string customerAgentCdSt, string customerAgentCdEd, Int32 sortOrder, Int32 outPutPriceCond, Int32 newPageDiv, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 collectRatePrtDiv, Int32 balanceDepositDtl, bool isBillOutputOnly, Int32 slipPrtKind, DateTime issueDay, Int32 sumCustDtl, Int32 accRecDivCd, string enterpriseName, Int32 taxPrintDiv, double taxRate1, double taxRate2)
        // --- UPD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
        {
			this._enterpriseCode = enterpriseCode;
			this._isSelectAllSection = isSelectAllSection;
			this._isOutputAllSecRec = isOutputAllSecRec;
			this._resultsAddUpSecList = resultsAddUpSecList;
			this._isOptSection = isOptSection;
			this._isMainOfficeFunc = isMainOfficeFunc;
            this._addUpDate = addUpDate;
            this._customerCodeSt = customerCodeSt;
			this._customerCodeEd = customerCodeEd;
            this._customerAgentDivCd = customerAgentDivCd;
			this._billCollecterCdSt = billCollecterCdSt;
			this._billCollecterCdEd = billCollecterCdEd;
			this._customerAgentCdSt = customerAgentCdSt;
			this._customerAgentCdEd = customerAgentCdEd;
            this._sortOrder = sortOrder;
			this._outPutPriceCond = outPutPriceCond;
            this._newPageDiv = newPageDiv;
            this._salesAreaCodeSt = salesAreaCodeSt;
            this._salesAreaCodeEd = salesAreaCodeEd;
            this._collectRatePrtDiv = collectRatePrtDiv;
            this._balanceDepositDtl = balanceDepositDtl;
            this._isBillOutputOnly = isBillOutputOnly;
            this._slipPrtKind = slipPrtKind;
            this._issueDay = issueDay;
            this._sumCustDtl = sumCustDtl;
            this._accRecDivCd = accRecDivCd;
            this._enterpriseName = enterpriseName;
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
            this._taxPrintDiv = taxPrintDiv;
            this._taxRate1 = taxRate1;
            this._taxRate2 = taxRate2;
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<

		}

		/// <summary>
        /// ���������s(����)���o�����N���X��������
		/// </summary>
        /// <returns>SumExtrInfo_DemandTotal�N���X�̃C���X�^���X</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SumExtrInfo_DemandTotal�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public SumExtrInfo_DemandTotal Clone()
		{
            // --- UPD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
            //return new SumExtrInfo_DemandTotal(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._isOptSection, this._isMainOfficeFunc, this._addUpDate, this._customerCodeSt, this._customerCodeEd, this._customerAgentDivCd, this._billCollecterCdSt, this._billCollecterCdEd, this._customerAgentCdSt, this._customerAgentCdEd, this._sortOrder, this._outPutPriceCond, this._newPageDiv, this._salesAreaCodeSt, this._salesAreaCodeEd, this._collectRatePrtDiv, this._balanceDepositDtl, this._isBillOutputOnly, this._slipPrtKind, this._issueDay, this._sumCustDtl, this._accRecDivCd, this._enterpriseName);
            return new SumExtrInfo_DemandTotal(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._isOptSection, this._isMainOfficeFunc, this._addUpDate, this._customerCodeSt, this._customerCodeEd, this._customerAgentDivCd, this._billCollecterCdSt, this._billCollecterCdEd, this._customerAgentCdSt, this._customerAgentCdEd, this._sortOrder, this._outPutPriceCond, this._newPageDiv, this._salesAreaCodeSt, this._salesAreaCodeEd, this._collectRatePrtDiv, this._balanceDepositDtl, this._isBillOutputOnly, this._slipPrtKind, this._issueDay, this._sumCustDtl, this._accRecDivCd, this._enterpriseName, this._taxPrintDiv, this._taxRate1, this._taxRate2);
            // --- UPD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
        }

		/// <summary>
        /// ���������s(����)���o�����N���X��r����
		/// </summary>
        /// <param name="target">��r�Ώۂ�SumExtrInfo_DemandTotal�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SumExtrInfo_DemandTotal�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SumExtrInfo_DemandTotal target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsSelectAllSection == target.IsSelectAllSection)
				 && (this.IsOutputAllSecRec == target.IsOutputAllSecRec)
                 && (EqualsStrList(this.ResultsAddUpSecList, target.ResultsAddUpSecList))
				 && (this.IsOptSection == target.IsOptSection)
				 && (this.IsMainOfficeFunc == target.IsMainOfficeFunc)
                 && (this.AddUpDate == target.AddUpDate)
                 && (this.CustomerCodeSt == target.CustomerCodeSt)
				 && (this.CustomerCodeEd == target.CustomerCodeEd)
                 && (this.CustomerAgentDivCd == target.CustomerAgentDivCd)
				 && (this.BillCollecterCdSt == target.BillCollecterCdSt)
				 && (this.BillCollecterCdEd == target.BillCollecterCdEd)
				 && (this.CustomerAgentCdSt == target.CustomerAgentCdSt)
				 && (this.CustomerAgentCdEd == target.CustomerAgentCdEd)
                 && (this.SortOrder == target.SortOrder)
				 && (this.OutPutPriceCond == target.OutPutPriceCond)
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.SalesAreaCodeSt == target.SalesAreaCodeSt)
                 && (this.SalesAreaCodeEd == target.SalesAreaCodeEd)
                 && (this.CollectRatePrtDiv == target.CollectRatePrtDiv)
                 && (this.BalanceDepositDtl == target.BalanceDepositDtl)
                 && (this.IsBillOutputOnly == target.IsBillOutputOnly)
                 && (this.SlipPrtKind == target.SlipPrtKind)
                 && (this.IssueDay == target.IssueDay)
                 && (this.SumCustDtl == target.SumCustDtl)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
                && (this.TaxPrintDiv == target.TaxPrintDiv)
                && (this.TaxRate1 == target.TaxRate1)
                && (this.TaxRate2 == target.TaxRate2)
                // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
                 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
        /// ���������s(����)���o�����N���X��r����
		/// </summary>
        /// <param name="sumExtrInfo_DemandTotal1">
        ///                    ��r����SumExtrInfo_DemandTotal�N���X�̃C���X�^���X
		/// </param>
        /// <param name="sumExtrInfo_DemandTotal2">��r����SumExtrInfo_DemandTotal�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SumExtrInfo_DemandTotal�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SumExtrInfo_DemandTotal sumExtrInfo_DemandTotal1, SumExtrInfo_DemandTotal sumExtrInfo_DemandTotal2)
		{
			return ((sumExtrInfo_DemandTotal1.EnterpriseCode == sumExtrInfo_DemandTotal2.EnterpriseCode)
				 && (sumExtrInfo_DemandTotal1.IsSelectAllSection == sumExtrInfo_DemandTotal2.IsSelectAllSection)
				 && (sumExtrInfo_DemandTotal1.IsOutputAllSecRec == sumExtrInfo_DemandTotal2.IsOutputAllSecRec)
                 && (sumExtrInfo_DemandTotal1.ResultsAddUpSecList == sumExtrInfo_DemandTotal2.ResultsAddUpSecList)
                 && (sumExtrInfo_DemandTotal1.IsOptSection == sumExtrInfo_DemandTotal2.IsOptSection)
				 && (sumExtrInfo_DemandTotal1.IsMainOfficeFunc == sumExtrInfo_DemandTotal2.IsMainOfficeFunc)
                 && (sumExtrInfo_DemandTotal1.AddUpDate == sumExtrInfo_DemandTotal2.AddUpDate)
                 && (sumExtrInfo_DemandTotal1.CustomerCodeSt == sumExtrInfo_DemandTotal2.CustomerCodeSt)
				 && (sumExtrInfo_DemandTotal1.CustomerCodeEd == sumExtrInfo_DemandTotal2.CustomerCodeEd)
                 && (sumExtrInfo_DemandTotal1.CustomerAgentDivCd == sumExtrInfo_DemandTotal2.CustomerAgentDivCd)
				 && (sumExtrInfo_DemandTotal1.BillCollecterCdSt == sumExtrInfo_DemandTotal2.BillCollecterCdSt)
				 && (sumExtrInfo_DemandTotal1.BillCollecterCdEd == sumExtrInfo_DemandTotal2.BillCollecterCdEd)
				 && (sumExtrInfo_DemandTotal1.CustomerAgentCdSt == sumExtrInfo_DemandTotal2.CustomerAgentCdSt)
				 && (sumExtrInfo_DemandTotal1.CustomerAgentCdEd == sumExtrInfo_DemandTotal2.CustomerAgentCdEd)
                 && (sumExtrInfo_DemandTotal1.SortOrder == sumExtrInfo_DemandTotal2.SortOrder)
				 && (sumExtrInfo_DemandTotal1.OutPutPriceCond == sumExtrInfo_DemandTotal2.OutPutPriceCond)
                 && (sumExtrInfo_DemandTotal1.NewPageDiv == sumExtrInfo_DemandTotal2.NewPageDiv)
                 && (sumExtrInfo_DemandTotal1.SalesAreaCodeSt == sumExtrInfo_DemandTotal2.SalesAreaCodeSt)
                 && (sumExtrInfo_DemandTotal1.SalesAreaCodeEd == sumExtrInfo_DemandTotal2.SalesAreaCodeEd)
                 && (sumExtrInfo_DemandTotal1.CollectRatePrtDiv == sumExtrInfo_DemandTotal2.CollectRatePrtDiv)
                 && (sumExtrInfo_DemandTotal1.BalanceDepositDtl == sumExtrInfo_DemandTotal2.BalanceDepositDtl)
                 && (sumExtrInfo_DemandTotal1.IsBillOutputOnly == sumExtrInfo_DemandTotal2.IsBillOutputOnly)
                 && (sumExtrInfo_DemandTotal1.SlipPrtKind == sumExtrInfo_DemandTotal2.SlipPrtKind)
                 && (sumExtrInfo_DemandTotal1.IssueDay == sumExtrInfo_DemandTotal2.IssueDay)
                 && (sumExtrInfo_DemandTotal1.SumCustDtl == sumExtrInfo_DemandTotal2.SumCustDtl)
                 && (sumExtrInfo_DemandTotal1.AccRecDivCd == sumExtrInfo_DemandTotal2.AccRecDivCd)
                 // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
                 && (sumExtrInfo_DemandTotal1.TaxPrintDiv == sumExtrInfo_DemandTotal2.TaxPrintDiv)
                 && (sumExtrInfo_DemandTotal1.TaxRate1 == sumExtrInfo_DemandTotal2.TaxRate1)
                 && (sumExtrInfo_DemandTotal1.TaxRate2 == sumExtrInfo_DemandTotal2.TaxRate2)
                 // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
                 && (sumExtrInfo_DemandTotal1.EnterpriseName == sumExtrInfo_DemandTotal2.EnterpriseName));
		}
		/// <summary>
        /// ���������s(����)���o�����N���X��r����
		/// </summary>
        /// <param name="target">��r�Ώۂ�SumExtrInfo_DemandTotal�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SumExtrInfo_DemandTotal�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SumExtrInfo_DemandTotal target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if (this.IsSelectAllSection != target.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if (this.IsOutputAllSecRec != target.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if (this.ResultsAddUpSecList != target.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if (this.IsOptSection != target.IsOptSection)resList.Add("IsOptSection");
			if (this.IsMainOfficeFunc != target.IsMainOfficeFunc)resList.Add("IsMainOfficeFunc");
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if (this.CustomerCodeEd != target.CustomerCodeEd)resList.Add("CustomerCodeEd");
            if (this.CustomerAgentDivCd != target.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if (this.BillCollecterCdSt != target.BillCollecterCdSt)resList.Add("BillCollecterCdSt");
			if (this.BillCollecterCdEd != target.BillCollecterCdEd)resList.Add("BillCollecterCdEd");
			if (this.CustomerAgentCdSt != target.CustomerAgentCdSt)resList.Add("CustomerAgentCdSt");
			if (this.CustomerAgentCdEd != target.CustomerAgentCdEd)resList.Add("CustomerAgentCdEd");
            if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");
			if (this.OutPutPriceCond != target.OutPutPriceCond) resList.Add("OutPutPriceCond");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.SalesAreaCodeSt != target.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (this.SalesAreaCodeEd != target.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (this.CollectRatePrtDiv != target.CollectRatePrtDiv) resList.Add("CollectRatePrtDiv");
            if (this.BalanceDepositDtl != target.BalanceDepositDtl) resList.Add("BalanceDepositDtl");
            if (this.IsBillOutputOnly != target.IsBillOutputOnly) resList.Add("IsBillOutputOnly");
            if (this.SlipPrtKind != target.SlipPrtKind) resList.Add("SlipPrtKind");
            if (this.IssueDay != target.IssueDay) resList.Add("IssueDay");
            if (this.SumCustDtl != target.SumCustDtl) resList.Add("SumCustDtl");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
            if (this.TaxPrintDiv != target.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (this.TaxRate1 != target.TaxRate1) resList.Add("TaxRate1");
            if (this.TaxRate2 != target.TaxRate2) resList.Add("TaxRate2");
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<

			return resList;
		}

		/// <summary>
        /// ���������s(����)���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_DemandTotal1">��r����ExtrInfo_DemandTotal�N���X�̃C���X�^���X</param>
		/// <param name="extrInfo_DemandTotal2">��r����ExtrInfo_DemandTotal�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SumExtrInfo_DemandTotal�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SumExtrInfo_DemandTotal sumExtrInfo_DemandTotal1, SumExtrInfo_DemandTotal sumExtrInfo_DemandTotal2)
		{
			ArrayList resList = new ArrayList();
			if (sumExtrInfo_DemandTotal1.EnterpriseCode != sumExtrInfo_DemandTotal2.EnterpriseCode)resList.Add("EnterpriseCode");
			if (sumExtrInfo_DemandTotal1.IsSelectAllSection != sumExtrInfo_DemandTotal2.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if (sumExtrInfo_DemandTotal1.IsOutputAllSecRec != sumExtrInfo_DemandTotal2.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if (sumExtrInfo_DemandTotal1.ResultsAddUpSecList != sumExtrInfo_DemandTotal2.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if (sumExtrInfo_DemandTotal1.IsOptSection != sumExtrInfo_DemandTotal2.IsOptSection)resList.Add("IsOptSection");
            if (sumExtrInfo_DemandTotal1.IsMainOfficeFunc != sumExtrInfo_DemandTotal2.IsMainOfficeFunc) resList.Add("IsMainOfficeFunc");
            if (sumExtrInfo_DemandTotal1.AddUpDate != sumExtrInfo_DemandTotal2.AddUpDate) resList.Add("AddUpDate");
            if (sumExtrInfo_DemandTotal1.CustomerCodeSt != sumExtrInfo_DemandTotal2.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if (sumExtrInfo_DemandTotal1.CustomerCodeEd != sumExtrInfo_DemandTotal2.CustomerCodeEd)resList.Add("CustomerCodeEd");
            if (sumExtrInfo_DemandTotal1.CustomerAgentDivCd != sumExtrInfo_DemandTotal2.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if (sumExtrInfo_DemandTotal1.BillCollecterCdSt != sumExtrInfo_DemandTotal2.BillCollecterCdSt)resList.Add("BillCollecterCdSt");
			if (sumExtrInfo_DemandTotal1.BillCollecterCdEd != sumExtrInfo_DemandTotal2.BillCollecterCdEd)resList.Add("BillCollecterCdEd");
			if (sumExtrInfo_DemandTotal1.CustomerAgentCdSt != sumExtrInfo_DemandTotal2.CustomerAgentCdSt)resList.Add("CustomerAgentCdSt");
			if (sumExtrInfo_DemandTotal1.CustomerAgentCdEd != sumExtrInfo_DemandTotal2.CustomerAgentCdEd)resList.Add("CustomerAgentCdEd");
            if (sumExtrInfo_DemandTotal1.SortOrder != sumExtrInfo_DemandTotal2.SortOrder) resList.Add("SortOrder");
			if (sumExtrInfo_DemandTotal1.OutPutPriceCond != sumExtrInfo_DemandTotal2.OutPutPriceCond)resList.Add("OutPutPriceCond");
            if (sumExtrInfo_DemandTotal1.NewPageDiv != sumExtrInfo_DemandTotal2.NewPageDiv) resList.Add("NewPageDiv");
            if (sumExtrInfo_DemandTotal1.SalesAreaCodeSt != sumExtrInfo_DemandTotal2.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (sumExtrInfo_DemandTotal1.SalesAreaCodeEd != sumExtrInfo_DemandTotal2.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (sumExtrInfo_DemandTotal1.CollectRatePrtDiv != sumExtrInfo_DemandTotal2.CollectRatePrtDiv) resList.Add("CollectRatePrtDiv");
            if (sumExtrInfo_DemandTotal1.BalanceDepositDtl != sumExtrInfo_DemandTotal2.BalanceDepositDtl) resList.Add("BalanceDepositDtl");
            if (sumExtrInfo_DemandTotal1.IsBillOutputOnly != sumExtrInfo_DemandTotal2.IsBillOutputOnly) resList.Add("IsBillOutputOnly");
            if (sumExtrInfo_DemandTotal1.SlipPrtKind != sumExtrInfo_DemandTotal2.SlipPrtKind) resList.Add("SlipPrtKind");
            if (sumExtrInfo_DemandTotal1.IssueDay != sumExtrInfo_DemandTotal2.IssueDay) resList.Add("IssueDay");
            if (sumExtrInfo_DemandTotal1.SumCustDtl != sumExtrInfo_DemandTotal2.SumCustDtl) resList.Add("SumCustDtl");
            if (sumExtrInfo_DemandTotal1.AccRecDivCd != sumExtrInfo_DemandTotal2.AccRecDivCd) resList.Add("AccRecDivCd");
            if (sumExtrInfo_DemandTotal1.EnterpriseName != sumExtrInfo_DemandTotal2.EnterpriseName) resList.Add("EnterpriseName");
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
            if (sumExtrInfo_DemandTotal1.TaxPrintDiv != sumExtrInfo_DemandTotal2.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (sumExtrInfo_DemandTotal1.TaxRate1 != sumExtrInfo_DemandTotal2.TaxRate1) resList.Add("TaxRate1");
            if (sumExtrInfo_DemandTotal1.TaxRate2 != sumExtrInfo_DemandTotal2.TaxRate2) resList.Add("TaxRate2");
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<

			return resList;
		}

        private bool CompareArrayStr(ArrayList cmpString1, ArrayList cmpString2)
        {
            // �܂��͗v�f���Ŕ�r
            if (cmpString1.Count != cmpString2.Count)
            {
                return false;
            }

            // �l���̔�r(�l�̏��Ԃ���v���Ă��Ȃ���false�ɂȂ�)
            for (int i = 0; i < cmpString1.Count; i++)
            {
                if (cmpString1[i] != cmpString2[i])
                {
                    return false;
                }
            }

            return true;
        }
        
        private bool EqualsStrList(string[] strList1, string[] strList2)
        {
            // �v�f���Ŕ�r
            if (strList1.Length != strList2.Length)
            {
                return false;
            }

            // �l���̔�r(�l�̏��Ԃ���v���Ă��Ȃ���false�ɂȂ�)
            for (int i = 0; i < strList1.Length; i++)
            {
                if (strList1[i] != strList2[i])
                {
                    return false;
                }
            }

            return true;
        }
	}
}

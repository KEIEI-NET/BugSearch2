//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ������(�ӕ�)���o�����N���X
// �v���O�����T�v   : ������(�ӕ�)���o�����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright 2022 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00   �쐬�S�� : ���O
// �� �� ��  2022/03/07    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_EBooksDemandTotal
	/// <summary>
	///                      ������(�ӕ�)���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ������(�ӕ�)���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
    /// <br>Genarated Date   :   2022/03/07  (CSharp File Generated Date)</br>
    /// </remarks>
	public class ExtrInfo_EBooksDemandTotal
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

        /// <summary>�̔��G���A�R�[�h(�J�n)</summary>
        private Int32 _salesAreaCodeSt;

        /// <summary>�̔��G���A�R�[�h(�I��)</summary>
        private Int32 _salesAreaCodeEd;

        /// <summary>���s��</summary>
        private DateTime _issueDay;

		/// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�d�q����o�͑Ώ�</summary>
        private Int32 _eBooksOutMode;

        /// <summary>����o�͑Ώ�</summary>
        private Int32 _printOutMode;

        /// <summary>���������敪</summary>
        private Int32 _eBooksFlg;

        /// <summary>�`�[����ݒ�p���[ID</summary>
        private string _prtSetPaperId = "";

        /// <summary>�t�@�C�����p�^�[��</summary>
        private Int32 _outPutPattern;

        /// <summary>�`�[������</summary>
        private Int32 _slipPrtKind;

        /// <summary>����</summary>
        private Int32 _newPageDiv;
        
        /// <summary>�������</summary>
        private Int32 _collectRatePrtDiv;

        /// <summary>�c����������</summary>
        private Int32 _balanceDepositDtl;

        /// <summary>�󔒍s��</summary>
        private Int32 _printBlLiDiv;

        /// <summary>�r����</summary>
        private Int32 _lineMaSqOfChDiv;

        /// <summary>���|�敪</summary>
        private Int32 _accRecDivCd;

        /// <summary>����ŕʂ̓���敪</summary>
        /// <remarks>0:�󎚂��� 1:�󎚂��Ȃ�</remarks>
        private Int32 _taxPrintDiv;

        /// <summary>�ŗ�1</summary>
        /// <remarks>�ŗ�1</remarks>
        private Double _taxRate1;

        /// <summary>�ŗ�2</summary>
        /// <remarks>�ŗ�2</remarks>
        private Double _taxRate2;

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

        /// public propaty name  :  EBooksOutMode
        /// <summary>�d�q����o�͑Ώۃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�q����o�͑Ώۃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EBooksOutMode
        {
            get { return _eBooksOutMode; }
            set { _eBooksOutMode = value; }
        }

        /// public propaty name  :  PrintOutMode
        /// <summary>����o�͑Ώۃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����o�͑Ώۃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintOutMode
        {
            get { return _printOutMode; }
            set { _printOutMode = value; }
        }

        /// public propaty name  :  EBookFlg
        /// <summary>���������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EBooksFlg
        {
            get { return _eBooksFlg; }
            set { _eBooksFlg = value; }
        }

        /// public propaty name  :  PrtSetPaperId
        /// <summary>�`�[����ݒ�p���[ID�v���p�e�B</summary>
        /// <value>�`�[����ݒ�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[����ݒ�p���[ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrtSetPaperId
        {
            get { return _prtSetPaperId; }
            set { _prtSetPaperId = value; }
        }

        /// public propaty name  :  OutPutPattern
        /// <summary>�t�@�C�����p�^�[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C�����p�^�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OutPutPattern
        {
            get { return _outPutPattern; }
            set { _outPutPattern = value; }
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

        /// public propaty name  :  PrintBlLiDiv
        /// <summary>�󔒍s�󎚃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󔒍s�󎚃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintBlLiDiv
        {
            get { return _printBlLiDiv; }
            set { _printBlLiDiv = value; }
        }

        /// public propaty name  :  LineMaSqOfChDiv
        /// <summary>�r���󎚃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r���󎚃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LineMaSqOfChDiv
        {
            get { return _lineMaSqOfChDiv; }
            set { _lineMaSqOfChDiv = value; }
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

		/// <summary>
		/// ������(�ӕ�)���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_EBooksDemandTotal�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_EBooksDemandTotal�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_EBooksDemandTotal()
		{
		}

		/// <summary>
		/// ������(�ӕ�)���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="isSelectAllSection">�S�БI��(true:�S�БI�� false:�e���_�I��)</param>
		/// <param name="isOutputAllSecRec">�S���_���R�[�h�o��(true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�)</param>
		/// <param name="resultsAddUpSecList">���ьv�㋒�_�R�[�h���X�g(�����^�@���z�񍀖�)</param>
		/// <param name="isOptSection">���_�I�v�V���������敪(true:������, false:������)</param>
		/// <param name="isMainOfficeFunc">�{�Ћ@�\�v���p�e�B(true:�{��, false:���_)</param>
		/// <param name="targetAddUpDate">�v��N����(YYYYMMDD ���������s�Ȃ������i������j)</param>
		/// <param name="totalDay">����(DD)</param>
		/// <param name="isLastDay">���Ӑ�������w��(true:28�`31�S�� false:�w������̂�)</param>
		/// <param name="customerCodeSt">���Ӑ�R�[�h(�J�n)</param>
		/// <param name="customerCodeEd">���Ӑ�R�[�h(�I��)</param>
		/// <param name="kanaSt">���Ӑ�J�i(�J�n)</param>
		/// <param name="kanaEd">���Ӑ�J�i(�I��)</param>
		/// <param name="isEmployeeNextPage">�S���Җ����y�[�W�敪((�����ꗗ�\�̂�)true:�S���҂ŉ��y�[�W false:�S���҂ŉ��y�[�W���Ȃ�)</param>
		/// <param name="isJudgeBillOutputCode">�������o�͋敪(true:�u���������s����v���Ӑ�̂� false:�S��)</param>
		/// <param name="customerAgentDivCd">�S���敪</param>
		/// <param name="billCollecterCdSt">�W���S���R�[�h(�J�n)(�����^)</param>
		/// <param name="billCollecterCdEd">�W���S���R�[�h(�I��)(�����^)</param>
		/// <param name="customerAgentCdSt">�ڋq�S���R�[�h(�J�n)(�����^)</param>
		/// <param name="customerAgentCdEd">�ڋq�S���R�[�h(�I��)(�����^)</param>
		/// <param name="isBillOutputOnly">���������s���Ӑ�t���O</param>
		/// <param name="sortOrder">�o�͏�</param>
		/// <param name="outPutPriceCond">�o�͋��z����</param>
        /// <param name="dmdDtl">��������</param>
        /// <param name="slipTotalPrt">�`�[�v�󎚑I��</param>
		/// <param name="addUpDateTotalPrt">������v�󎚑I��</param>
		/// <param name="customerTotalPrt">���Ӑ�v�󎚑I��</param>
        /// <param name="newPageDiv">����</param>
        /// <param name="collectRatePrtDiv">�������</param>
        /// <param name="balanceDepositDtl">�c����������</param>
        /// <param name="printBlLiDiv">�󔒍s�󎚋敪</param>
        /// <param name="lineMaSqOfChDiv">�r���󎚋敪</param>
        /// <param name="taxPrintDiv">�ŕʓ���󎚋敪</param>
        /// <param name="taxRate1">�ŗ�1</param>
        /// <param name="taxRate2">�ŗ�2</param>
        /// <param name="slipPrtKind">���</param>
		/// <returns>ExtrInfo_EBooksDemandTotal�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_EBooksDemandTotal�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public ExtrInfo_EBooksDemandTotal(string enterpriseCode, bool isSelectAllSection, bool isOutputAllSecRec, string[] resultsAddUpSecList, bool isOptSection, bool isMainOfficeFunc, DateTime addUpDate, Int32 customerCodeSt, Int32 customerCodeEd, Int32 customerAgentDivCd, string billCollecterCdSt, string billCollecterCdEd, string customerAgentCdSt, string customerAgentCdEd, Int32 sortOrder, Int32 outPutPriceCond, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, DateTime issueDay, string enterpriseName, Int32 eBooksOutMode, Int32 printOutMode, Int32 eBooksFlg, string prtSetPaperId, Int32 outPutPattern, Int32 slipPrtKind, Int32 newPageDiv, Int32 collectRatePrtDiv, Int32 balanceDepositDtl, Int32 printBlLiDiv, Int32 lineMaSqOfChDiv, Int32 accRecDivCd, Int32 taxPrintDiv, double taxRate1, double taxRate2)
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
            this._salesAreaCodeSt = salesAreaCodeSt;
            this._salesAreaCodeEd = salesAreaCodeEd;
            this._issueDay = issueDay;
            this._enterpriseName = enterpriseName;
            this._eBooksOutMode = eBooksOutMode;
            this._printOutMode = printOutMode;
            this._eBooksFlg = eBooksFlg;
            this._prtSetPaperId = prtSetPaperId;
            this._outPutPattern = outPutPattern;
            this._slipPrtKind = slipPrtKind;
            this._newPageDiv = newPageDiv;
            this._collectRatePrtDiv = collectRatePrtDiv;
            this._balanceDepositDtl = balanceDepositDtl;
            this._printBlLiDiv = printBlLiDiv;
            this._lineMaSqOfChDiv = lineMaSqOfChDiv;
            this._accRecDivCd = accRecDivCd;
            this._taxPrintDiv = taxPrintDiv;
            this._taxRate1 = taxRate1;
            this._taxRate2 = taxRate2;

		}

		/// <summary>
		/// ������(�ӕ�)���o�����N���X��������
		/// </summary>
		/// <returns>ExtrInfo_EBooksDemandTotal�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ExtrInfo_EBooksDemandTotal�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_EBooksDemandTotal Clone()
		{
            return new ExtrInfo_EBooksDemandTotal(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._isOptSection, this._isMainOfficeFunc, this._addUpDate, this._customerCodeSt, this._customerCodeEd, this._customerAgentDivCd, this._billCollecterCdSt, this._billCollecterCdEd, this._customerAgentCdSt, this._customerAgentCdEd, this._sortOrder, this._outPutPriceCond, this._salesAreaCodeSt, this._salesAreaCodeEd, this._issueDay, this._enterpriseName, this._eBooksOutMode, this.PrintOutMode, this.EBooksFlg, this._prtSetPaperId, this._outPutPattern, this._slipPrtKind, this._newPageDiv, this._collectRatePrtDiv, this._balanceDepositDtl, this._printBlLiDiv, this._lineMaSqOfChDiv, this._accRecDivCd, this._taxPrintDiv, this._taxRate1, this._taxRate2);
        }

		/// <summary>
		/// ������(�ӕ�)���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_EBooksDemandTotal�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_EBooksDemandTotal�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ExtrInfo_EBooksDemandTotal target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsSelectAllSection == target.IsSelectAllSection)
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
                 && (this.SalesAreaCodeSt == target.SalesAreaCodeSt)
                 && (this.SalesAreaCodeEd == target.SalesAreaCodeEd)
                 && (this.IssueDay == target.IssueDay)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.EBooksOutMode == target.EBooksOutMode)
                 && (this.PrintOutMode == target.PrintOutMode)
                 && (this.SlipPrtKind == target.SlipPrtKind)
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.CollectRatePrtDiv == target.CollectRatePrtDiv)
                 && (this.BalanceDepositDtl == target.BalanceDepositDtl)
                 && (this.PrintBlLiDiv == target.PrintBlLiDiv)
                 && (this.LineMaSqOfChDiv == target.LineMaSqOfChDiv)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                 && (this.TaxPrintDiv == target.TaxPrintDiv)
                 && (this.TaxRate1 == target.TaxRate1)
                 && (this.TaxRate2 == target.TaxRate2)
                 );
		}

		/// <summary>
		/// ������(�ӕ�)���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_DemandTotal1">
		///                    ��r����ExtrInfo_EBooksDemandTotal�N���X�̃C���X�^���X
		/// </param>
		/// <param name="extrInfo_DemandTotal2">��r����ExtrInfo_EBooksDemandTotal�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_EBooksDemandTotal�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_EBooksDemandTotal extrInfo_DemandTotal1, ExtrInfo_EBooksDemandTotal extrInfo_DemandTotal2)
		{
			return ((extrInfo_DemandTotal1.EnterpriseCode == extrInfo_DemandTotal2.EnterpriseCode)
				 && (extrInfo_DemandTotal1.IsSelectAllSection == extrInfo_DemandTotal2.IsSelectAllSection)
                 && (extrInfo_DemandTotal1.ResultsAddUpSecList == extrInfo_DemandTotal2.ResultsAddUpSecList)
                 && (extrInfo_DemandTotal1.IsOptSection == extrInfo_DemandTotal2.IsOptSection)
				 && (extrInfo_DemandTotal1.IsMainOfficeFunc == extrInfo_DemandTotal2.IsMainOfficeFunc)
                 && (extrInfo_DemandTotal1.AddUpDate == extrInfo_DemandTotal2.AddUpDate)
                 && (extrInfo_DemandTotal1.CustomerCodeSt == extrInfo_DemandTotal2.CustomerCodeSt)
				 && (extrInfo_DemandTotal1.CustomerCodeEd == extrInfo_DemandTotal2.CustomerCodeEd)
                 && (extrInfo_DemandTotal1.CustomerAgentDivCd == extrInfo_DemandTotal2.CustomerAgentDivCd)
				 && (extrInfo_DemandTotal1.BillCollecterCdSt == extrInfo_DemandTotal2.BillCollecterCdSt)
				 && (extrInfo_DemandTotal1.BillCollecterCdEd == extrInfo_DemandTotal2.BillCollecterCdEd)
				 && (extrInfo_DemandTotal1.CustomerAgentCdSt == extrInfo_DemandTotal2.CustomerAgentCdSt)
				 && (extrInfo_DemandTotal1.CustomerAgentCdEd == extrInfo_DemandTotal2.CustomerAgentCdEd)
                 && (extrInfo_DemandTotal1.SortOrder == extrInfo_DemandTotal2.SortOrder)
				 && (extrInfo_DemandTotal1.OutPutPriceCond == extrInfo_DemandTotal2.OutPutPriceCond)
                 && (extrInfo_DemandTotal1.SalesAreaCodeSt == extrInfo_DemandTotal2.SalesAreaCodeSt)
                 && (extrInfo_DemandTotal1.SalesAreaCodeEd == extrInfo_DemandTotal2.SalesAreaCodeEd)
                 && (extrInfo_DemandTotal1.IssueDay == extrInfo_DemandTotal2.IssueDay)
                 && (extrInfo_DemandTotal1.EnterpriseName == extrInfo_DemandTotal2.EnterpriseName)
                 && (extrInfo_DemandTotal1.EBooksOutMode == extrInfo_DemandTotal2.EBooksOutMode)
                 && (extrInfo_DemandTotal1.PrintOutMode == extrInfo_DemandTotal2.PrintOutMode)
                 && (extrInfo_DemandTotal1.SlipPrtKind == extrInfo_DemandTotal2.SlipPrtKind)
                 && (extrInfo_DemandTotal1.NewPageDiv == extrInfo_DemandTotal2.NewPageDiv)
                 && (extrInfo_DemandTotal1.CollectRatePrtDiv == extrInfo_DemandTotal2.CollectRatePrtDiv)
                 && (extrInfo_DemandTotal1.BalanceDepositDtl == extrInfo_DemandTotal2.BalanceDepositDtl)
                 && (extrInfo_DemandTotal1.PrintBlLiDiv == extrInfo_DemandTotal2.PrintBlLiDiv)
                 && (extrInfo_DemandTotal1.LineMaSqOfChDiv == extrInfo_DemandTotal2.LineMaSqOfChDiv)
                 && (extrInfo_DemandTotal1.AccRecDivCd == extrInfo_DemandTotal2.AccRecDivCd)
                 && (extrInfo_DemandTotal1.TaxPrintDiv == extrInfo_DemandTotal2.TaxPrintDiv)
                 && (extrInfo_DemandTotal1.TaxRate1 == extrInfo_DemandTotal2.TaxRate1)
                 && (extrInfo_DemandTotal1.TaxRate2 == extrInfo_DemandTotal2.TaxRate2)
                 );
		}
		/// <summary>
		/// ������(�ӕ�)���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_EBooksDemandTotal�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_EBooksDemandTotal�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_EBooksDemandTotal target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.IsSelectAllSection != target.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(this.IsOutputAllSecRec != target.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if(this.ResultsAddUpSecList != target.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if(this.IsOptSection != target.IsOptSection)resList.Add("IsOptSection");
			if(this.IsMainOfficeFunc != target.IsMainOfficeFunc)resList.Add("IsMainOfficeFunc");
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if(this.CustomerCodeEd != target.CustomerCodeEd)resList.Add("CustomerCodeEd");
            if (this.CustomerAgentDivCd != target.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if(this.BillCollecterCdSt != target.BillCollecterCdSt)resList.Add("BillCollecterCdSt");
			if(this.BillCollecterCdEd != target.BillCollecterCdEd)resList.Add("BillCollecterCdEd");
			if(this.CustomerAgentCdSt != target.CustomerAgentCdSt)resList.Add("CustomerAgentCdSt");
			if(this.CustomerAgentCdEd != target.CustomerAgentCdEd)resList.Add("CustomerAgentCdEd");
            if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");
            if (this.OutPutPriceCond != target.OutPutPriceCond) resList.Add("OutPutPriceCond");
            if (this.SalesAreaCodeSt != target.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (this.SalesAreaCodeEd != target.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (this.IssueDay != target.IssueDay) resList.Add("IssueDay");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.EBooksOutMode != target.EBooksOutMode) resList.Add("EBooksOutMode");
            if (this.PrintOutMode != target.PrintOutMode) resList.Add("PrintOutMode");
            if (this.EBooksFlg != target.EBooksFlg) resList.Add("EBooksFlg");
            if (this.PrtSetPaperId != target.PrtSetPaperId) resList.Add("PrtSetPaperId");
            if (this.OutPutPattern != target.OutPutPattern) resList.Add("OutPutPattern");
            if (this.SlipPrtKind != target.SlipPrtKind) resList.Add("SlipPrtKind");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.CollectRatePrtDiv != target.CollectRatePrtDiv) resList.Add("CollectRatePrtDiv");
            if (this.BalanceDepositDtl != target.BalanceDepositDtl) resList.Add("BalanceDepositDtl");
            if (this.PrintBlLiDiv != target.PrintBlLiDiv) resList.Add("PrintBlLiDiv");
            if (this.LineMaSqOfChDiv != target.LineMaSqOfChDiv) resList.Add("LineMaSqOfChDiv");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            if (this.TaxPrintDiv != target.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (this.TaxRate1 != target.TaxRate1) resList.Add("TaxRate1");
            if (this.TaxRate2 != target.TaxRate2) resList.Add("TaxRate2");
			return resList;
		}

		/// <summary>
		/// ������(�ӕ�)���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_DemandTotal1">��r����ExtrInfo_EBooksDemandTotal�N���X�̃C���X�^���X</param>
		/// <param name="extrInfo_DemandTotal2">��r����ExtrInfo_EBooksDemandTotal�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_EBooksDemandTotal�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_EBooksDemandTotal extrInfo_DemandTotal1, ExtrInfo_EBooksDemandTotal extrInfo_DemandTotal2)
		{
			ArrayList resList = new ArrayList();
			if(extrInfo_DemandTotal1.EnterpriseCode != extrInfo_DemandTotal2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(extrInfo_DemandTotal1.IsSelectAllSection != extrInfo_DemandTotal2.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(extrInfo_DemandTotal1.IsOutputAllSecRec != extrInfo_DemandTotal2.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if(extrInfo_DemandTotal1.ResultsAddUpSecList != extrInfo_DemandTotal2.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if(extrInfo_DemandTotal1.IsOptSection != extrInfo_DemandTotal2.IsOptSection)resList.Add("IsOptSection");
			if(extrInfo_DemandTotal1.IsMainOfficeFunc != extrInfo_DemandTotal2.IsMainOfficeFunc)resList.Add("IsMainOfficeFunc");
            if (extrInfo_DemandTotal1.AddUpDate != extrInfo_DemandTotal2.AddUpDate) resList.Add("AddUpDate");
            if (extrInfo_DemandTotal1.CustomerCodeSt != extrInfo_DemandTotal2.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if(extrInfo_DemandTotal1.CustomerCodeEd != extrInfo_DemandTotal2.CustomerCodeEd)resList.Add("CustomerCodeEd");
            if (extrInfo_DemandTotal1.CustomerAgentDivCd != extrInfo_DemandTotal2.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if(extrInfo_DemandTotal1.BillCollecterCdSt != extrInfo_DemandTotal2.BillCollecterCdSt)resList.Add("BillCollecterCdSt");
			if(extrInfo_DemandTotal1.BillCollecterCdEd != extrInfo_DemandTotal2.BillCollecterCdEd)resList.Add("BillCollecterCdEd");
			if(extrInfo_DemandTotal1.CustomerAgentCdSt != extrInfo_DemandTotal2.CustomerAgentCdSt)resList.Add("CustomerAgentCdSt");
			if(extrInfo_DemandTotal1.CustomerAgentCdEd != extrInfo_DemandTotal2.CustomerAgentCdEd)resList.Add("CustomerAgentCdEd");
            if (extrInfo_DemandTotal1.SortOrder != extrInfo_DemandTotal2.SortOrder) resList.Add("SortOrder");
			if(extrInfo_DemandTotal1.OutPutPriceCond != extrInfo_DemandTotal2.OutPutPriceCond)resList.Add("OutPutPriceCond");
            if (extrInfo_DemandTotal1.SalesAreaCodeSt != extrInfo_DemandTotal2.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (extrInfo_DemandTotal1.SalesAreaCodeEd != extrInfo_DemandTotal2.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (extrInfo_DemandTotal1.IssueDay != extrInfo_DemandTotal2.IssueDay) resList.Add("IssueDay");
            if (extrInfo_DemandTotal1.EnterpriseName != extrInfo_DemandTotal2.EnterpriseName) resList.Add("EnterpriseName");
            if (extrInfo_DemandTotal1.EBooksOutMode != extrInfo_DemandTotal2.EBooksOutMode) resList.Add("EBooksOutMode");
            if (extrInfo_DemandTotal1.PrintOutMode != extrInfo_DemandTotal2.PrintOutMode) resList.Add("PrintOutMode");
            if (extrInfo_DemandTotal1.EBooksFlg != extrInfo_DemandTotal2.EBooksFlg) resList.Add("EBooksFlg");
            if (extrInfo_DemandTotal1.PrtSetPaperId != extrInfo_DemandTotal2.PrtSetPaperId) resList.Add("PrtSetPaperId");
            if (extrInfo_DemandTotal1.OutPutPattern != extrInfo_DemandTotal2.OutPutPattern) resList.Add("OutPutPattern");
            if (extrInfo_DemandTotal1.SlipPrtKind != extrInfo_DemandTotal2.SlipPrtKind) resList.Add("SlipPrtKind");
            if (extrInfo_DemandTotal1.NewPageDiv != extrInfo_DemandTotal2.NewPageDiv) resList.Add("NewPageDiv");
            if (extrInfo_DemandTotal1.CollectRatePrtDiv != extrInfo_DemandTotal2.CollectRatePrtDiv) resList.Add("CollectRatePrtDiv");
            if (extrInfo_DemandTotal1.BalanceDepositDtl != extrInfo_DemandTotal2.BalanceDepositDtl) resList.Add("BalanceDepositDtl");
            if (extrInfo_DemandTotal1.PrintBlLiDiv != extrInfo_DemandTotal2.PrintBlLiDiv) resList.Add("PrintBlLiDiv");
            if (extrInfo_DemandTotal1.LineMaSqOfChDiv != extrInfo_DemandTotal2.LineMaSqOfChDiv) resList.Add("LineMaSqOfChDiv");
            if (extrInfo_DemandTotal1.AccRecDivCd != extrInfo_DemandTotal2.AccRecDivCd) resList.Add("AccRecDivCd");
            if (extrInfo_DemandTotal1.TaxPrintDiv != extrInfo_DemandTotal2.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (extrInfo_DemandTotal1.TaxRate1 != extrInfo_DemandTotal2.TaxRate1) resList.Add("TaxRate1");
            if (extrInfo_DemandTotal1.TaxRate2 != extrInfo_DemandTotal2.TaxRate2) resList.Add("TaxRate2");
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

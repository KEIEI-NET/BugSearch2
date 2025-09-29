using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_DemandTotal
	/// <summary>
	///                      ������(�ӕ�)���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ������(�ӕ�)���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/07/17  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   20081 �D�c �E�l</br>
    /// <br>                 :   2007.10.15 DC.NS�p�ɕύX</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote       : PM.NS�Ή�</br>
    /// <br>Programmer       : ����</br>
    /// <br>Date	         : 2008.09.04</br>
    /// <br>Note             : 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer       : ���O</br>
    /// <br>Date             : 2020/04/13</br>
    /// </remarks>
	public class ExtrInfo_DemandTotal
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

        // 2008.10.17 30413 ���� ���ьv�㋒�_�R�[�h���X�g�̌^��ύX >>>>>>START
        ///// <summary>���ьv�㋒�_�R�[�h���X�g</summary>
        ///// <remarks>�����^�@���z�񍀖�</remarks>
        //private ArrayList _resultsAddUpSecList;
        /// <summary>���ьv�㋒�_�R�[�h���X�g</summary>
        /// <remarks>�����^�@���z�񍀖� �S�Ўw���{""}</remarks>
        private string[] _resultsAddUpSecList;
        // 2008.10.17 30413 ���� ���ьv�㋒�_�R�[�h���X�g�̌^��ύX <<<<<<END
        
		/// <summary>���_�I�v�V���������敪</summary>
		/// <remarks>true:������, false:������</remarks>
		private bool _isOptSection;

		/// <summary>�{�Ћ@�\�v���p�e�B</summary>
		/// <remarks>true:�{��, false:���_</remarks>
		private bool _isMainOfficeFunc;

        // 2008.09.08 30413 ���� �v��N�����̌^��ύX >>>>>>START
        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD ���������s�Ȃ������i������j</remarks>
        private DateTime _addUpDate;
        // 2008.09.08 30413 ���� �v��N�����̌^��ύX <<<<<<END
        
        // 2008.09.05 30413 ���� �폜���� >>>>>>START
        ///// <summary>�v��N����</summary>
        ///// <remarks>YYYYMMDD ���������s�Ȃ������i������j</remarks>
        //private Int32 _targetAddUpDate;

        ///// <summary>����</summary>
        ///// <remarks>DD</remarks>
        //private Int32 _totalDay;

        ///// <summary>���Ӑ�������w��</summary>
        ///// <remarks>true:28�`31�S�� false:�w������̂�</remarks>
        //private bool _isLastDay;
        // 2008.09.05 30413 ���� �폜���� <<<<<<END
            
		/// <summary>���Ӑ�R�[�h(�J�n)</summary>
		private Int32 _customerCodeSt;

		/// <summary>���Ӑ�R�[�h(�I��)</summary>
		private Int32 _customerCodeEd;

        // 2008.09.05 30413 ���� �폜���� >>>>>>START
        ///// <summary>���Ӑ�J�i(�J�n)</summary>
        //private string _kanaSt = "";

        ///// <summary>���Ӑ�J�i(�I��)</summary>
        //private string _kanaEd = "";
        // 2008.09.05 30413 ���� �폜���� <<<<<<END
        
        // 2007.10.15 hikita del start -------------------------------------->>
        ///// <summary>�l�E�@�l�敪���X�g</summary>
        ///// <remarks>�l�E�@�l�敪�R�[�h�z��</remarks>
        //private Int32[] _corporateDivCodeList;           

        ///// <summary>�l�E�@�l�敪�S�I��</summary>
        ///// <remarks>true:�S�I�� false:�e�I��</remarks>
        //private bool _isSelectAllCorporateDiv;           
        // 2007.10.15 hikita del end ----------------------------------------<<

        // 2008.09.05 30413 ���� �폜���� >>>>>>START
        ///// <summary>�S���Җ����y�[�W�敪</summary>
        ///// <remarks>(�����ꗗ�\�̂�)true:�S���҂ŉ��y�[�W false:�S���҂ŉ��y�[�W���Ȃ�</remarks>
        //private bool _isEmployeeNextPage;

        ///// <summary>�������o�͋敪</summary>
        ///// <remarks>true:�u���������s����v���Ӑ�̂� false:�S��</remarks>
        //private bool _isJudgeBillOutputCode;
        // 2008.09.05 30413 ���� �폜���� <<<<<<END
        
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

        // 2007.10.15 hikita del start -------------------------------------->>
        ///// <summary>���Ӑ敪�̓R�[�h1(�J�n)</summary>
        //private Int32 _custAnalysCode1St;

        ///// <summary>���Ӑ敪�̓R�[�h1(�I��)</summary>
        //private Int32 _custAnalysCode1Ed;

        ///// <summary>���Ӑ敪�̓R�[�h2(�J�n)</summary>
        //private Int32 _custAnalysCode2St;

        ///// <summary>���Ӑ敪�̓R�[�h2(�I��)</summary>
        //private Int32 _custAnalysCode2Ed;

        ///// <summary>���Ӑ敪�̓R�[�h3(�J�n)</summary>
        //private Int32 _custAnalysCode3St;

        ///// <summary>���Ӑ敪�̓R�[�h3(�I��)</summary>
        //private Int32 _custAnalysCode3Ed;

        ///// <summary>���Ӑ敪�̓R�[�h4(�J�n)</summary>
        //private Int32 _custAnalysCode4St;

        ///// <summary>���Ӑ敪�̓R�[�h4(�I��)</summary>
        //private Int32 _custAnalysCode4Ed;

        ///// <summary>���Ӑ敪�̓R�[�h5(�J�n)</summary>
        //private Int32 _custAnalysCode5St;

        ///// <summary>���Ӑ敪�̓R�[�h5(�I��)</summary>
        //private Int32 _custAnalysCode5Ed;

        ///// <summary>���Ӑ敪�̓R�[�h6(�J�n)</summary>
        //private Int32 _custAnalysCode6St;

        ///// <summary>���Ӑ敪�̓R�[�h6(�I��)</summary>
        //private Int32 _custAnalysCode6Ed;
        // 2007.10.15 hikita del end ----------------------------------------<<

        // 2008.09.05 30413 ���� �폜���� >>>>>>START
        ///// <summary>���������s���Ӑ�t���O</summary>
        //private bool _isBillOutputOnly;
        // 2008.09.05 30413 ���� �폜���� <<<<<<END
        
		/// <summary>�o�͏�</summary>
		private Int32 _sortOrder;

        ///// <summary>�l�E�@�l�敪���̃��X�g</summary>
        //private ArrayList _corporateDivNameList;         // 2007.10.15 hikita del

        /// <summary>�o�͋��z����</summary>
		private Int32 _outPutPriceCond;

        // 2007.10.15 hikita add start ------------------------------------------>>
        /// <summary>��������</summary>
        private Int32 _dmdDtl;
        // 2007.10.15 hikita add end --------------------------------------------<<

        // 2008.09.05 30413 ���� �폜���� >>>>>>START
        ///// <summary>�`�[�v�󎚑I��</summary>
        //private bool _slipTotalPrt;

        ///// <summary>������v�󎚑I��</summary>
        //private bool _addUpDateTotalPrt;

        ///// <summary>���Ӑ�v�󎚑I��</summary>
        //private bool _customerTotalPrt;
        // 2008.09.05 30413 ���� �폜���� <<<<<<END
        
        ///// <summary>�L�����A�v�󎚑I��</summary>
        //private bool _carrierTotalPrt;                   // 2007.10.15 hikita del 

        // 2008.09.05 30413 ���� ���ڒǉ� >>>>>>START
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
        // 2008.09.05 30413 ���� ���ڒǉ� <<<<<<END

        /// <summary>�e���Ӑ����</summary>
        private Int32 _prCustDtl;

        /// <summary>���|�敪</summary>
        private Int32 _accRecDivCd;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        //---ADD 2011/03/14------------->>>>>
        /// <summary>
        /// �󔒍s��
        /// </summary>
        private Int32 _printBlLiDiv;

        /// <summary>
        /// �r����
        /// </summary>
        private Int32 _lineMaSqOfChDiv;
        //---ADD 2011/03/14-------------<<<<<

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

        // 2008.10.17 30413 ���� ���ьv�㋒�_�R�[�h���X�g�̌^��ύX >>>>>>START
        ///// public propaty name  :  ResultsAddUpSecList
        ///// <summary>���ьv�㋒�_�R�[�h���X�g�v���p�e�B</summary>
        ///// <value>�����^�@���z�񍀖�</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���ьv�㋒�_�R�[�h���X�g�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public ArrayList ResultsAddUpSecList
        //{
        //    get{return _resultsAddUpSecList;}
        //    set{_resultsAddUpSecList = value;}
        //}
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
        // 2008.10.17 30413 ���� ���ьv�㋒�_�R�[�h���X�g�̌^��ύX <<<<<<END
        
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

        // 2008.09.08 30413 ���� �v��N�����̌^��ύX >>>>>>START
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
        // 2008.09.08 30413 ���� �v��N�����̌^��ύX <<<<<<END
        
        // 2008.09.05 30413 ���� �폜���� >>>>>>START
        ///// public propaty name  :  TargetAddUpDate
        ///// <summary>�v��N�����v���p�e�B</summary>
        ///// <value>YYYYMMDD ���������s�Ȃ������i������j</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �v��N�����v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 TargetAddUpDate
        //{
        //    get { return _targetAddUpDate; }
        //    set { _targetAddUpDate = value; }
        //}

        ///// public propaty name  :  TotalDay
        ///// <summary>�����v���p�e�B</summary>
        ///// <value>DD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �����v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 TotalDay
        //{
        //    get{return _totalDay;}
        //    set{_totalDay = value;}
        //}

        ///// public propaty name  :  IsLastDay
        ///// <summary>���Ӑ�������w��v���p�e�B</summary>
        ///// <value>true:28�`31�S�� false:�w������̂�</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�������w��v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public bool IsLastDay
        //{
        //    get{return _isLastDay;}
        //    set{_isLastDay = value;}
        //}
        // 2008.09.05 30413 ���� �폜���� <<<<<<END
        
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

        // 2008.09.05 30413 ���� �폜���� >>>>>>START
        ///// public propaty name  :  KanaSt
        ///// <summary>���Ӑ�J�i(�J�n)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�J�i(�J�n)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string KanaSt
        //{
        //    get{return _kanaSt;}
        //    set{_kanaSt = value;}
        //}

        ///// public propaty name  :  KanaEd
        ///// <summary>���Ӑ�J�i(�I��)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�J�i(�I��)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string KanaEd
        //{
        //    get{return _kanaEd;}
        //    set{_kanaEd = value;}
        //}
        // 2008.09.05 30413 ���� �폜���� <<<<<<END
        
        // 2007.10.15 hikita del start --------------------------------------------->>
        ///// public propaty name  :  CorporateDivCodeList
        ///// <summary>�l�E�@�l�敪���X�g�v���p�e�B</summary>
        ///// <value>�l�E�@�l�敪�R�[�h�z��</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �l�E�@�l�敪���X�g�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32[] CorporateDivCodeList
        //{
        //    get{return _corporateDivCodeList;}
        //    set{_corporateDivCodeList = value;}
        //}

        ///// public propaty name  :  IsSelectAllCorporateDiv
        ///// <summary>�l�E�@�l�敪�S�I���v���p�e�B</summary>
        ///// <value>true:�S�I�� false:�e�I��</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �l�E�@�l�敪�S�I���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public bool IsSelectAllCorporateDiv
        //{
        //    get{return _isSelectAllCorporateDiv;}
        //    set{_isSelectAllCorporateDiv = value;}
        //}
        // 2007.10.15 hikita del end ------------------------------------------------<<

        // 2008.09.05 30413 ���� �폜���� >>>>>>START
        ///// public propaty name  :  IsEmployeeNextPage
        ///// <summary>�S���Җ����y�[�W�敪�v���p�e�B</summary>
        ///// <value>(�����ꗗ�\�̂�)true:�S���҂ŉ��y�[�W false:�S���҂ŉ��y�[�W���Ȃ�</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �S���Җ����y�[�W�敪�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public bool IsEmployeeNextPage
        //{
        //    get{return _isEmployeeNextPage;}
        //    set{_isEmployeeNextPage = value;}
        //}

        ///// public propaty name  :  IsJudgeBillOutputCode
        ///// <summary>�������o�͋敪�v���p�e�B</summary>
        ///// <value>true:�u���������s����v���Ӑ�̂� false:�S��</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �������o�͋敪�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public bool IsJudgeBillOutputCode
        //{
        //    get{return _isJudgeBillOutputCode;}
        //    set{_isJudgeBillOutputCode = value;}
        //}
        // 2008.09.05 30413 ���� �폜���� <<<<<<END
        
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

        // 2007.10.15 hikita del start ---------------------------------------------->>
        ///// public propaty name  :  CustAnalysCode1St
        ///// <summary>���Ӑ敪�̓R�[�h1(�J�n)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ敪�̓R�[�h1(�J�n)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustAnalysCode1St
        //{
        //    get{return _custAnalysCode1St;}
        //    set{_custAnalysCode1St = value;}
        //}

        ///// public propaty name  :  CustAnalysCode1Ed
        ///// <summary>���Ӑ敪�̓R�[�h1(�I��)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ敪�̓R�[�h1(�I��)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustAnalysCode1Ed
        //{
        //    get{return _custAnalysCode1Ed;}
        //    set{_custAnalysCode1Ed = value;}
        //}

        ///// public propaty name  :  CustAnalysCode2St
        ///// <summary>���Ӑ敪�̓R�[�h2(�J�n)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ敪�̓R�[�h2(�J�n)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustAnalysCode2St
        //{
        //    get{return _custAnalysCode2St;}
        //    set{_custAnalysCode2St = value;}
        //}

        ///// public propaty name  :  CustAnalysCode2Ed
        ///// <summary>���Ӑ敪�̓R�[�h2(�I��)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ敪�̓R�[�h2(�I��)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustAnalysCode2Ed
        //{
        //    get{return _custAnalysCode2Ed;}
        //    set{_custAnalysCode2Ed = value;}
        //}

        ///// public propaty name  :  CustAnalysCode3St
        ///// <summary>���Ӑ敪�̓R�[�h3(�J�n)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ敪�̓R�[�h3(�J�n)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustAnalysCode3St
        //{
        //    get{return _custAnalysCode3St;}
        //    set{_custAnalysCode3St = value;}
        //}

        ///// public propaty name  :  CustAnalysCode3Ed
        ///// <summary>���Ӑ敪�̓R�[�h3(�I��)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ敪�̓R�[�h3(�I��)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustAnalysCode3Ed
        //{
        //    get{return _custAnalysCode3Ed;}
        //    set{_custAnalysCode3Ed = value;}
        //}

        ///// public propaty name  :  CustAnalysCode4St
        ///// <summary>���Ӑ敪�̓R�[�h4(�J�n)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ敪�̓R�[�h4(�J�n)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustAnalysCode4St
        //{
        //    get{return _custAnalysCode4St;}
        //    set{_custAnalysCode4St = value;}
        //}

        ///// public propaty name  :  CustAnalysCode4Ed
        ///// <summary>���Ӑ敪�̓R�[�h4(�I��)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ敪�̓R�[�h4(�I��)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustAnalysCode4Ed
        //{
        //    get{return _custAnalysCode4Ed;}
        //    set{_custAnalysCode4Ed = value;}
        //}

        ///// public propaty name  :  CustAnalysCode5St
        ///// <summary>���Ӑ敪�̓R�[�h5(�J�n)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ敪�̓R�[�h5(�J�n)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustAnalysCode5St
        //{
        //    get{return _custAnalysCode5St;}
        //    set{_custAnalysCode5St = value;}
        //}

        ///// public propaty name  :  CustAnalysCode5Ed
        ///// <summary>���Ӑ敪�̓R�[�h5(�I��)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ敪�̓R�[�h5(�I��)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustAnalysCode5Ed
        //{
        //    get{return _custAnalysCode5Ed;}
        //    set{_custAnalysCode5Ed = value;}
        //}

        ///// public propaty name  :  CustAnalysCode6St
        ///// <summary>���Ӑ敪�̓R�[�h6(�J�n)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ敪�̓R�[�h6(�J�n)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustAnalysCode6St
        //{
        //    get{return _custAnalysCode6St;}
        //    set{_custAnalysCode6St = value;}
        //}

        ///// public propaty name  :  CustAnalysCode6Ed
        ///// <summary>���Ӑ敪�̓R�[�h6(�I��)�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ敪�̓R�[�h6(�I��)�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustAnalysCode6Ed
        //{
        //    get{return _custAnalysCode6Ed;}
        //    set{_custAnalysCode6Ed = value;}
        //}
        // 2007.10.15 hikita del end ------------------------------------------------<<

        // 2008.09.05 30413 ���� �폜���� >>>>>>START
        ///// public propaty name  :  IsBillOutputOnly
        ///// <summary>���������s���Ӑ�t���O�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���������s���Ӑ�t���O�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public bool IsBillOutputOnly
        //{
        //    get{return _isBillOutputOnly;}
        //    set{_isBillOutputOnly = value;}
        //}
        // 2008.09.05 30413 ���� �폜���� <<<<<<END
        
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

        // 2007.10.15 hikita del start ---------------------------------------------------->>
        ///// public propaty name  :  CorporateDivNameList
        ///// <summary>�l�E�@�l�敪���̃��X�g�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �l�E�@�l�敪���̃��X�g�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public ArrayList CorporateDivNameList
        //{
        //    get{return _corporateDivNameList;}
        //    set{_corporateDivNameList = value;}
        //}
        // 2007.10.15 hikita del end ------------------------------------------------------<<

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

        // 2007.10.15 hikita add start ----------------------------------------------------->>
        /// public propaty name  :  DmdDtl
        /// <summary>��������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DmdDtl
        {
            get { return _dmdDtl; }
            set { _dmdDtl = value; }
        }
        // 2007.10.15 hikita add end -------------------------------------------------------<<

        // 2008.09.05 30413 ���� �폜���� >>>>>>START
        ///// public propaty name  :  SlipTotalPrt
        ///// <summary>�`�[�v�󎚑I���v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �`�[�v�󎚑I���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public bool SlipTotalPrt
        //{
        //    get{return _slipTotalPrt;}
        //    set{_slipTotalPrt = value;}
        //}

        ///// public propaty name  :  AddUpDateTotalPrt
        ///// <summary>������v�󎚑I���v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ������v�󎚑I���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public bool AddUpDateTotalPrt
        //{
        //    get{return _addUpDateTotalPrt;}
        //    set{_addUpDateTotalPrt = value;}
        //}

        ///// public propaty name  :  CustomerTotalPrt
        ///// <summary>���Ӑ�v�󎚑I���v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�v�󎚑I���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public bool CustomerTotalPrt
        //{
        //    get{return _customerTotalPrt;}
        //    set{_customerTotalPrt = value;}
        //}
        // 2008.09.05 30413 ���� �폜���� <<<<<<END
        
        // 2007.10.15 hikita del start -------------------------------------------------->>
        ///// public propaty name  :  CarrierTotalPrt
        ///// <summary>�L�����A�v�󎚑I���v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �L�����A�v�󎚑I���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public bool CarrierTotalPrt
        //{
        //    get{return _carrierTotalPrt;}
        //    set{_carrierTotalPrt = value;}
        //}
        // 2007.10.15 hikita del end ----------------------------------------------------<<

        // 2008.09.05 30413 ���� ���ڒǉ� >>>>>>START
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
        // 2008.09.05 30413 ���� ���ڒǉ� <<<<<<END

        /// public propaty name  :  PrCustDtl
        /// <summary>�e���Ӑ����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���Ӑ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrCustDtl
        {
            get { return _prCustDtl; }
            set { _prCustDtl = value; }
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

        //---ADD 2011/03/14------------->>>>>

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
        //---ADD 2011/03/14-------------<<<<<

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
		/// ������(�ӕ�)���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_DemandTotal�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandTotal�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_DemandTotal()
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
		/// <returns>ExtrInfo_DemandTotal�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandTotal�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        // 2008.09.05 30413 ���� ���ڕύX >>>>>>START
        //public ExtrInfo_DemandTotal(string enterpriseCode, bool isSelectAllSection, bool isOutputAllSecRec, ArrayList resultsAddUpSecList, bool isOptSection, bool isMainOfficeFunc, Int32 targetAddUpDate, Int32 totalDay, bool isLastDay, Int32 customerCodeSt, Int32 customerCodeEd, string kanaSt, string kanaEd, bool isEmployeeNextPage, bool isJudgeBillOutputCode, Int32 customerAgentDivCd, string billCollecterCdSt, string billCollecterCdEd, string customerAgentCdSt, string customerAgentCdEd, bool isBillOutputOnly, Int32 sortOrder, Int32 outPutPriceCond, Int32 dmdDtl, bool slipTotalPrt, bool addUpDateTotalPrt, bool customerTotalPrt, string enterpriseName)
        //---UPD 2011/03/14------------->>>>>
        //public ExtrInfo_DemandTotal(string enterpriseCode, bool isSelectAllSection, bool isOutputAllSecRec, string[] resultsAddUpSecList, bool isOptSection, bool isMainOfficeFunc, DateTime addUpDate, Int32 customerCodeSt, Int32 customerCodeEd, Int32 customerAgentDivCd, string billCollecterCdSt, string billCollecterCdEd, string customerAgentCdSt, string customerAgentCdEd, Int32 sortOrder, Int32 outPutPriceCond, Int32 dmdDtl, Int32 newPageDiv, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 collectRatePrtDiv, Int32 balanceDepositDtl, bool isBillOutputOnly, Int32 slipPrtKind, DateTime issueDay, Int32 prCustDtl, Int32 accRecDivCd, string enterpriseName)
        // --- UPD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
        //public ExtrInfo_DemandTotal(string enterpriseCode, bool isSelectAllSection, bool isOutputAllSecRec, string[] resultsAddUpSecList, bool isOptSection, bool isMainOfficeFunc, DateTime addUpDate, Int32 customerCodeSt, Int32 customerCodeEd, Int32 customerAgentDivCd, string billCollecterCdSt, string billCollecterCdEd, string customerAgentCdSt, string customerAgentCdEd, Int32 sortOrder, Int32 outPutPriceCond, Int32 dmdDtl, Int32 newPageDiv, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 collectRatePrtDiv, Int32 balanceDepositDtl, bool isBillOutputOnly, Int32 slipPrtKind, DateTime issueDay, Int32 prCustDtl, Int32 accRecDivCd, string enterpriseName, Int32 printBlLiDiv, Int32 lineMaSqOfChDiv)
        public ExtrInfo_DemandTotal(string enterpriseCode, bool isSelectAllSection, bool isOutputAllSecRec, string[] resultsAddUpSecList, bool isOptSection, bool isMainOfficeFunc, DateTime addUpDate, Int32 customerCodeSt, Int32 customerCodeEd, Int32 customerAgentDivCd, string billCollecterCdSt, string billCollecterCdEd, string customerAgentCdSt, string customerAgentCdEd, Int32 sortOrder, Int32 outPutPriceCond, Int32 dmdDtl, Int32 newPageDiv, Int32 salesAreaCodeSt, Int32 salesAreaCodeEd, Int32 collectRatePrtDiv, Int32 balanceDepositDtl, bool isBillOutputOnly, Int32 slipPrtKind, DateTime issueDay, Int32 prCustDtl, Int32 accRecDivCd, string enterpriseName, Int32 printBlLiDiv, Int32 lineMaSqOfChDiv, Int32 taxPrintDiv, double taxRate1, double taxRate2)
        // --- UPD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
        //---UPD 2011/03/14-------------<<<<<
       // 2008.09.05 30413 ���� ���ڕύX <<<<<<END
        {
			this._enterpriseCode = enterpriseCode;
			this._isSelectAllSection = isSelectAllSection;
			this._isOutputAllSecRec = isOutputAllSecRec;
			this._resultsAddUpSecList = resultsAddUpSecList;
			this._isOptSection = isOptSection;
			this._isMainOfficeFunc = isMainOfficeFunc;
            // 2008.09.08 30413 ���� �v��N�����̌^��ύX >>>>>>START
            this._addUpDate = addUpDate;
            // 2008.09.08 30413 ���� �v��N�����̌^��ύX <<<<<<END
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //this._targetAddUpDate = targetAddUpDate;
            //this._totalDay = totalDay;
            //this._isLastDay = isLastDay;
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            this._customerCodeSt = customerCodeSt;
			this._customerCodeEd = customerCodeEd;
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //this._kanaSt = kanaSt;
            //this._kanaEd = kanaEd;
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            // 2007.10.15 hikita del start ----------------------------->>
            //this._corporateDivCodeList = corporateDivCodeList;
            //this._isSelectAllCorporateDiv = isSelectAllCorporateDiv;
            // 2007.10.15 hikita del end -------------------------------<<
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //this._isEmployeeNextPage = isEmployeeNextPage;
            //this._isJudgeBillOutputCode = isJudgeBillOutputCode;
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            this._customerAgentDivCd = customerAgentDivCd;
			this._billCollecterCdSt = billCollecterCdSt;
			this._billCollecterCdEd = billCollecterCdEd;
			this._customerAgentCdSt = customerAgentCdSt;
			this._customerAgentCdEd = customerAgentCdEd;
            // 2007.10.15 hikita del start ----------------------------->>
            //this._custAnalysCode1St = custAnalysCode1St;
            //this._custAnalysCode1Ed = custAnalysCode1Ed;
            //this._custAnalysCode2St = custAnalysCode2St;
            //this._custAnalysCode2Ed = custAnalysCode2Ed;
            //this._custAnalysCode3St = custAnalysCode3St;
            //this._custAnalysCode3Ed = custAnalysCode3Ed;
            //this._custAnalysCode4St = custAnalysCode4St;
            //this._custAnalysCode4Ed = custAnalysCode4Ed;
            //this._custAnalysCode5St = custAnalysCode5St;
            //this._custAnalysCode5Ed = custAnalysCode5Ed;
            //this._custAnalysCode6St = custAnalysCode6St;
            //this._custAnalysCode6Ed = custAnalysCode6Ed;
            // 2007.10.15 hikita del end -------------------------------<<
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //this._isBillOutputOnly = isBillOutputOnly;
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            this._sortOrder = sortOrder;
			//this._corporateDivNameList = corporateDivNameList;   // 2007.10.15 hikita del
			this._outPutPriceCond = outPutPriceCond;
            this._dmdDtl = dmdDtl;                                 // 2007.10.15 hikita add
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //this._slipTotalPrt = slipTotalPrt;
            //this._addUpDateTotalPrt = addUpDateTotalPrt;
            //this._customerTotalPrt = customerTotalPrt;
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            //this._carrierTotalPrt = carrierTotalPrt;             // 2007.10.15 hikita del
            // 2008.09.05 30413 ���� ���ڒǉ� >>>>>>START
            this._newPageDiv = newPageDiv;
            this._salesAreaCodeSt = salesAreaCodeSt;
            this._salesAreaCodeEd = salesAreaCodeEd;
            this._collectRatePrtDiv = collectRatePrtDiv;
            this._balanceDepositDtl = balanceDepositDtl;
            this._isBillOutputOnly = isBillOutputOnly;
            this._slipPrtKind = slipPrtKind;
            this._issueDay = issueDay;
            // 2008.09.05 30413 ���� ���ڒǉ� <<<<<<END
            this._prCustDtl = prCustDtl;
            this._accRecDivCd = accRecDivCd;
            this._enterpriseName = enterpriseName;
            //---ADD 2011/03/14------------->>>>>
            this.PrintBlLiDiv = printBlLiDiv;
            this.LineMaSqOfChDiv = lineMaSqOfChDiv;
            //---ADD 2011/03/14-------------<<<<<

            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
            this._taxPrintDiv = taxPrintDiv;
            this._taxRate1 = taxRate1;
            this._taxRate2 = taxRate2;
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
		}

		/// <summary>
		/// ������(�ӕ�)���o�����N���X��������
		/// </summary>
		/// <returns>ExtrInfo_DemandTotal�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ExtrInfo_DemandTotal�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_DemandTotal Clone()
		{
            // 2008.09.05 30413 ���� ���ڕύX >>>>>>START
            //return new ExtrInfo_DemandTotal(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._isOptSection, this._isMainOfficeFunc, this._targetAddUpDate, this._totalDay, this._isLastDay, this._customerCodeSt, this._customerCodeEd, this._kanaSt, this._kanaEd, this._isEmployeeNextPage, this._isJudgeBillOutputCode, this._customerAgentDivCd, this._billCollecterCdSt, this._billCollecterCdEd, this._customerAgentCdSt, this._customerAgentCdEd, this._isBillOutputOnly, this._sortOrder, this._outPutPriceCond, this._dmdDtl, this._slipTotalPrt, this._addUpDateTotalPrt, this._customerTotalPrt, this._enterpriseName);
            //---UPD 2011/03/14------------->>>>>
            //return new ExtrInfo_DemandTotal(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._isOptSection, this._isMainOfficeFunc, this._addUpDate, this._customerCodeSt, this._customerCodeEd, this._customerAgentDivCd, this._billCollecterCdSt, this._billCollecterCdEd, this._customerAgentCdSt, this._customerAgentCdEd, this._sortOrder, this._outPutPriceCond, this._dmdDtl, this._newPageDiv, this._salesAreaCodeSt, this._salesAreaCodeEd, this._collectRatePrtDiv, this._balanceDepositDtl, this._isBillOutputOnly, this._slipPrtKind, this._issueDay, this._prCustDtl, this._accRecDivCd, this._enterpriseName);
            // --- UPD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
            //return new ExtrInfo_DemandTotal(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._isOptSection, this._isMainOfficeFunc, this._addUpDate, this._customerCodeSt, this._customerCodeEd, this._customerAgentDivCd, this._billCollecterCdSt, this._billCollecterCdEd, this._customerAgentCdSt, this._customerAgentCdEd, this._sortOrder, this._outPutPriceCond, this._dmdDtl, this._newPageDiv, this._salesAreaCodeSt, this._salesAreaCodeEd, this._collectRatePrtDiv, this._balanceDepositDtl, this._isBillOutputOnly, this._slipPrtKind, this._issueDay, this._prCustDtl, this._accRecDivCd, this._enterpriseName, this._printBlLiDiv, this._lineMaSqOfChDiv);
            return new ExtrInfo_DemandTotal(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._isOptSection, this._isMainOfficeFunc, this._addUpDate, this._customerCodeSt, this._customerCodeEd, this._customerAgentDivCd, this._billCollecterCdSt, this._billCollecterCdEd, this._customerAgentCdSt, this._customerAgentCdEd, this._sortOrder, this._outPutPriceCond, this._dmdDtl, this._newPageDiv, this._salesAreaCodeSt, this._salesAreaCodeEd, this._collectRatePrtDiv, this._balanceDepositDtl, this._isBillOutputOnly, this._slipPrtKind, this._issueDay, this._prCustDtl, this._accRecDivCd, this._enterpriseName, this._printBlLiDiv, this._lineMaSqOfChDiv, this._taxPrintDiv, this._taxRate1, this._taxRate2);
            // --- UPD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
            //---UPD 2011/03/14-------------<<<<<
            // 2008.09.05 30413 ���� ���ڕύX <<<<<<END
        }

		/// <summary>
		/// ������(�ӕ�)���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_DemandTotal�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandTotal�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ExtrInfo_DemandTotal target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsSelectAllSection == target.IsSelectAllSection)
				 && (this.IsOutputAllSecRec == target.IsOutputAllSecRec)
                 //&& (this.ResultsAddUpSecList == target.ResultsAddUpSecList)
                 && (EqualsStrList(this.ResultsAddUpSecList, target.ResultsAddUpSecList))
				 && (this.IsOptSection == target.IsOptSection)
				 && (this.IsMainOfficeFunc == target.IsMainOfficeFunc)
                 // 2008.09.08 30413 ���� �v��N�����̌^��ύX >>>>>>START
                 && (this.AddUpDate == target.AddUpDate)
                 // 2008.09.08 30413 ���� �v��N�����̌^��ύX <<<<<<END
                 // 2008.09.05 30413 ���� �폜���� >>>>>>START
                 //&& (this.TargetAddUpDate == target.TargetAddUpDate)
                 //&& (this.TotalDay == target.TotalDay)
                 //&& (this.IsLastDay == target.IsLastDay)
                 // 2008.09.05 30413 ���� �폜���� <<<<<<END
                 && (this.CustomerCodeSt == target.CustomerCodeSt)
				 && (this.CustomerCodeEd == target.CustomerCodeEd)
                 // 2008.09.05 30413 ���� �폜���� >>>>>>START
                 //&& (this.KanaSt == target.KanaSt)
                 //&& (this.KanaEd == target.KanaEd)
                 // 2008.09.05 30413 ���� �폜���� <<<<<<END
                 // 2007.10.15 hikita del start ------------------------------------------->>
                 //&& (this.CorporateDivCodeList == target.CorporateDivCodeList)
                 //&& (this.IsSelectAllCorporateDiv == target.IsSelectAllCorporateDiv)
                 // 2007.10.15 hikita del end ---------------------------------------------<<
                 // 2008.09.05 30413 ���� �폜���� >>>>>>START
                 //&& (this.IsEmployeeNextPage == target.IsEmployeeNextPage)
                 //&& (this.IsJudgeBillOutputCode == target.IsJudgeBillOutputCode)
                 // 2008.09.05 30413 ���� �폜���� <<<<<<END
                 && (this.CustomerAgentDivCd == target.CustomerAgentDivCd)
				 && (this.BillCollecterCdSt == target.BillCollecterCdSt)
				 && (this.BillCollecterCdEd == target.BillCollecterCdEd)
				 && (this.CustomerAgentCdSt == target.CustomerAgentCdSt)
				 && (this.CustomerAgentCdEd == target.CustomerAgentCdEd)
                 // 2007.10.15 hikita del start ------------------------------------------->>
                 //&& (this.CustAnalysCode1St == target.CustAnalysCode1St)
                 //&& (this.CustAnalysCode1Ed == target.CustAnalysCode1Ed)
                 //&& (this.CustAnalysCode2St == target.CustAnalysCode2St)
                 //&& (this.CustAnalysCode2Ed == target.CustAnalysCode2Ed)
                 //&& (this.CustAnalysCode3St == target.CustAnalysCode3St)
                 //&& (this.CustAnalysCode3Ed == target.CustAnalysCode3Ed)
                 //&& (this.CustAnalysCode4St == target.CustAnalysCode4St)
                 //&& (this.CustAnalysCode4Ed == target.CustAnalysCode4Ed)
                 //&& (this.CustAnalysCode5St == target.CustAnalysCode5St)
                 //&& (this.CustAnalysCode5Ed == target.CustAnalysCode5Ed)
                 //&& (this.CustAnalysCode6St == target.CustAnalysCode6St)
                 //&& (this.CustAnalysCode6Ed == target.CustAnalysCode6Ed)
                 // 2007.10.15 hikita del end ---------------------------------------------<<
                 // 2008.09.05 30413 ���� �폜���� >>>>>>START
                 //&& (this.IsBillOutputOnly == target.IsBillOutputOnly)
                 // 2008.09.05 30413 ���� �폜���� <<<<<<END
                 && (this.SortOrder == target.SortOrder)
				 //&& (this.CorporateDivNameList == target.CorporateDivNameList)    // 2007.10.15 hikita del
				 && (this.OutPutPriceCond == target.OutPutPriceCond)
                 && (this.DmdDtl == target.DmdDtl)                                  // 2007.10.15 hikita add
                 // 2008.09.05 30413 ���� �폜���� >>>>>>START
                 //&& (this.SlipTotalPrt == target.SlipTotalPrt)
                 //&& (this.AddUpDateTotalPrt == target.AddUpDateTotalPrt)
                 //&& (this.CustomerTotalPrt == target.CustomerTotalPrt)
                 // 2008.09.05 30413 ���� �폜���� <<<<<<END
                 //&& (this.CarrierTotalPrt == target.CarrierTotalPrt)              // 2007.10.15 hikita del
                 // 2008.09.05 30413 ���� ���ڒǉ� >>>>>>START
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.SalesAreaCodeSt == target.SalesAreaCodeSt)
                 && (this.SalesAreaCodeEd == target.SalesAreaCodeEd)
                 && (this.CollectRatePrtDiv == target.CollectRatePrtDiv)
                 && (this.BalanceDepositDtl == target.BalanceDepositDtl)
                 && (this.IsBillOutputOnly == target.IsBillOutputOnly)
                 && (this.SlipPrtKind == target.SlipPrtKind)
                 && (this.IssueDay == target.IssueDay)
                 // 2008.09.05 30413 ���� ���ڒǉ� <<<<<<END
                 && (this.PrCustDtl == target.PrCustDtl)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                 //---ADD 2011/03/14------------->>>>>
                 && (this.PrintBlLiDiv == target.PrintBlLiDiv)
                 && (this.LineMaSqOfChDiv == target.LineMaSqOfChDiv)
                 //---ADD 2011/03/14-------------<<<<<
                // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
                && (this.TaxPrintDiv == target.TaxPrintDiv)
                && (this.TaxRate1 == target.TaxRate1)
                && (this.TaxRate2 == target.TaxRate2)
                // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
                 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// ������(�ӕ�)���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_DemandTotal1">
		///                    ��r����ExtrInfo_DemandTotal�N���X�̃C���X�^���X
		/// </param>
		/// <param name="extrInfo_DemandTotal2">��r����ExtrInfo_DemandTotal�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandTotal�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_DemandTotal extrInfo_DemandTotal1, ExtrInfo_DemandTotal extrInfo_DemandTotal2)
		{
			return ((extrInfo_DemandTotal1.EnterpriseCode == extrInfo_DemandTotal2.EnterpriseCode)
				 && (extrInfo_DemandTotal1.IsSelectAllSection == extrInfo_DemandTotal2.IsSelectAllSection)
				 && (extrInfo_DemandTotal1.IsOutputAllSecRec == extrInfo_DemandTotal2.IsOutputAllSecRec)
                 && (extrInfo_DemandTotal1.ResultsAddUpSecList == extrInfo_DemandTotal2.ResultsAddUpSecList)
                 && (extrInfo_DemandTotal1.IsOptSection == extrInfo_DemandTotal2.IsOptSection)
				 && (extrInfo_DemandTotal1.IsMainOfficeFunc == extrInfo_DemandTotal2.IsMainOfficeFunc)
                 // 2008.09.08 30413 ���� �v��N�����̌^��ύX >>>>>>START
                 && (extrInfo_DemandTotal1.AddUpDate == extrInfo_DemandTotal2.AddUpDate)
                 // 2008.09.08 30413 ���� �v��N�����̌^��ύX <<<<<<END
                 // 2008.09.05 30413 ���� �폜���� >>>>>>START
                 //&& (extrInfo_DemandTotal1.TargetAddUpDate == extrInfo_DemandTotal2.TargetAddUpDate)
                 //&& (extrInfo_DemandTotal1.TotalDay == extrInfo_DemandTotal2.TotalDay)
                 //&& (extrInfo_DemandTotal1.IsLastDay == extrInfo_DemandTotal2.IsLastDay)
                 // 2008.09.05 30413 ���� �폜���� <<<<<<END
                 && (extrInfo_DemandTotal1.CustomerCodeSt == extrInfo_DemandTotal2.CustomerCodeSt)
				 && (extrInfo_DemandTotal1.CustomerCodeEd == extrInfo_DemandTotal2.CustomerCodeEd)
                 // 2008.09.05 30413 ���� �폜���� >>>>>>START
                 //&& (extrInfo_DemandTotal1.KanaSt == extrInfo_DemandTotal2.KanaSt)
                 //&& (extrInfo_DemandTotal1.KanaEd == extrInfo_DemandTotal2.KanaEd)
                 // 2008.09.05 30413 ���� �폜���� <<<<<<END
                 // 2007.10.15 hikita del start ---------------------------------------------------------------------->>
                 //&& (extrInfo_DemandTotal1.CorporateDivCodeList == extrInfo_DemandTotal2.CorporateDivCodeList)
                 //&& (extrInfo_DemandTotal1.IsSelectAllCorporateDiv == extrInfo_DemandTotal2.IsSelectAllCorporateDiv)
                 // 2007.10.15 hikita del end ------------------------------------------------------------------------<<
                 // 2008.09.05 30413 ���� �폜���� >>>>>>START
                 //&& (extrInfo_DemandTotal1.IsEmployeeNextPage == extrInfo_DemandTotal2.IsEmployeeNextPage)
                 //&& (extrInfo_DemandTotal1.IsJudgeBillOutputCode == extrInfo_DemandTotal2.IsJudgeBillOutputCode)
                 // 2008.09.05 30413 ���� �폜���� <<<<<<END
                 && (extrInfo_DemandTotal1.CustomerAgentDivCd == extrInfo_DemandTotal2.CustomerAgentDivCd)
				 && (extrInfo_DemandTotal1.BillCollecterCdSt == extrInfo_DemandTotal2.BillCollecterCdSt)
				 && (extrInfo_DemandTotal1.BillCollecterCdEd == extrInfo_DemandTotal2.BillCollecterCdEd)
				 && (extrInfo_DemandTotal1.CustomerAgentCdSt == extrInfo_DemandTotal2.CustomerAgentCdSt)
				 && (extrInfo_DemandTotal1.CustomerAgentCdEd == extrInfo_DemandTotal2.CustomerAgentCdEd)
                 // 2007.10.15 hikita del start ---------------------------------------------------------------------->>
                 //&& (extrInfo_DemandTotal1.CustAnalysCode1St == extrInfo_DemandTotal2.CustAnalysCode1St)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode1Ed == extrInfo_DemandTotal2.CustAnalysCode1Ed)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode2St == extrInfo_DemandTotal2.CustAnalysCode2St)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode2Ed == extrInfo_DemandTotal2.CustAnalysCode2Ed)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode3St == extrInfo_DemandTotal2.CustAnalysCode3St)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode3Ed == extrInfo_DemandTotal2.CustAnalysCode3Ed)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode4St == extrInfo_DemandTotal2.CustAnalysCode4St)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode4Ed == extrInfo_DemandTotal2.CustAnalysCode4Ed)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode5St == extrInfo_DemandTotal2.CustAnalysCode5St)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode5Ed == extrInfo_DemandTotal2.CustAnalysCode5Ed)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode6St == extrInfo_DemandTotal2.CustAnalysCode6St)
                 //&& (extrInfo_DemandTotal1.CustAnalysCode6Ed == extrInfo_DemandTotal2.CustAnalysCode6Ed)
                 // 2007.10.15 hikita del end ------------------------------------------------------------------------<<
                 // 2008.09.05 30413 ���� �폜���� >>>>>>START
                 //&& (extrInfo_DemandTotal1.IsBillOutputOnly == extrInfo_DemandTotal2.IsBillOutputOnly)
                 // 2008.09.05 30413 ���� �폜���� <<<<<<END
                 && (extrInfo_DemandTotal1.SortOrder == extrInfo_DemandTotal2.SortOrder)
				 //&& (extrInfo_DemandTotal1.CorporateDivNameList == extrInfo_DemandTotal2.CorporateDivNameList)   // 2007.10.15 hikita del
				 && (extrInfo_DemandTotal1.OutPutPriceCond == extrInfo_DemandTotal2.OutPutPriceCond)
                 && (extrInfo_DemandTotal1.DmdDtl == extrInfo_DemandTotal2.DmdDtl)                                 // 2007.10.15 hikita add
                 // 2008.09.05 30413 ���� �폜���� >>>>>>START
                 //&& (extrInfo_DemandTotal1.SlipTotalPrt == extrInfo_DemandTotal2.SlipTotalPrt)
                 //&& (extrInfo_DemandTotal1.AddUpDateTotalPrt == extrInfo_DemandTotal2.AddUpDateTotalPrt)
                 //&& (extrInfo_DemandTotal1.CustomerTotalPrt == extrInfo_DemandTotal2.CustomerTotalPrt)
                 // 2008.09.05 30413 ���� �폜���� <<<<<<END
                 //&& (extrInfo_DemandTotal1.CarrierTotalPrt == extrInfo_DemandTotal2.CarrierTotalPrt)             // 2007.10.15 hikita del 
				 // 2008.09.05 30413 ���� ���ڒǉ� >>>>>>START
                 && (extrInfo_DemandTotal1.NewPageDiv == extrInfo_DemandTotal2.NewPageDiv)
                 && (extrInfo_DemandTotal1.SalesAreaCodeSt == extrInfo_DemandTotal2.SalesAreaCodeSt)
                 && (extrInfo_DemandTotal1.SalesAreaCodeEd == extrInfo_DemandTotal2.SalesAreaCodeEd)
                 && (extrInfo_DemandTotal1.CollectRatePrtDiv == extrInfo_DemandTotal2.CollectRatePrtDiv)
                 && (extrInfo_DemandTotal1.BalanceDepositDtl == extrInfo_DemandTotal2.BalanceDepositDtl)
                 && (extrInfo_DemandTotal1.IsBillOutputOnly == extrInfo_DemandTotal2.IsBillOutputOnly)
                 && (extrInfo_DemandTotal1.SlipPrtKind == extrInfo_DemandTotal2.SlipPrtKind)
                 && (extrInfo_DemandTotal1.IssueDay == extrInfo_DemandTotal2.IssueDay)
                 // 2008.09.05 30413 ���� ���ڒǉ� <<<<<<END
                 && (extrInfo_DemandTotal1.PrCustDtl == extrInfo_DemandTotal2.PrCustDtl)
                 && (extrInfo_DemandTotal1.AccRecDivCd == extrInfo_DemandTotal2.AccRecDivCd)
                 //---ADD 2011/03/14------------->>>>>
                 && (extrInfo_DemandTotal1.PrintBlLiDiv == extrInfo_DemandTotal2.PrintBlLiDiv)
                 && (extrInfo_DemandTotal1.LineMaSqOfChDiv == extrInfo_DemandTotal2.LineMaSqOfChDiv)
                 //---ADD 2011/03/14-------------<<<<<
                // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
                 && (extrInfo_DemandTotal1.TaxPrintDiv == extrInfo_DemandTotal2.TaxPrintDiv)
                 && (extrInfo_DemandTotal1.TaxRate1 == extrInfo_DemandTotal2.TaxRate1)
                 && (extrInfo_DemandTotal1.TaxRate2 == extrInfo_DemandTotal2.TaxRate2)
                // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
                 && (extrInfo_DemandTotal1.EnterpriseName == extrInfo_DemandTotal2.EnterpriseName));
		}
		/// <summary>
		/// ������(�ӕ�)���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_DemandTotal�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandTotal�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_DemandTotal target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.IsSelectAllSection != target.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(this.IsOutputAllSecRec != target.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if(this.ResultsAddUpSecList != target.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if(this.IsOptSection != target.IsOptSection)resList.Add("IsOptSection");
			if(this.IsMainOfficeFunc != target.IsMainOfficeFunc)resList.Add("IsMainOfficeFunc");
            // 2008.09.08 30413 ���� �v��N�����̌^��ύX >>>>>>START
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            // 2008.09.08 30413 ���� �v��N�����̌^��ύX <<<<<<END
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //if (this.TargetAddUpDate != target.TargetAddUpDate) resList.Add("TargetAddUpDate");
            //if(this.TotalDay != target.TotalDay)resList.Add("TotalDay");
            //if (this.IsLastDay != target.IsLastDay) resList.Add("IsLastDay");
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if(this.CustomerCodeEd != target.CustomerCodeEd)resList.Add("CustomerCodeEd");
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //if (this.KanaSt != target.KanaSt) resList.Add("KanaSt");
            //if(this.KanaEd != target.KanaEd)resList.Add("KanaEd");
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            // 2007.10.15 hikita del start ----------------------------------------------------------------------------->>
            //if(this.CorporateDivCodeList != target.CorporateDivCodeList)resList.Add("CorporateDivCodeList");
            //if(this.IsSelectAllCorporateDiv != target.IsSelectAllCorporateDiv)resList.Add("IsSelectAllCorporateDiv");
            // 2007.10.15 hikita del end -------------------------------------------------------------------------------<<
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //if (this.IsEmployeeNextPage != target.IsEmployeeNextPage) resList.Add("IsEmployeeNextPage");
            //if(this.IsJudgeBillOutputCode != target.IsJudgeBillOutputCode)resList.Add("IsJudgeBillOutputCode");
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            if (this.CustomerAgentDivCd != target.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if(this.BillCollecterCdSt != target.BillCollecterCdSt)resList.Add("BillCollecterCdSt");
			if(this.BillCollecterCdEd != target.BillCollecterCdEd)resList.Add("BillCollecterCdEd");
			if(this.CustomerAgentCdSt != target.CustomerAgentCdSt)resList.Add("CustomerAgentCdSt");
			if(this.CustomerAgentCdEd != target.CustomerAgentCdEd)resList.Add("CustomerAgentCdEd");
            // 2007.10.15 hikita del start ----------------------------------------------------------------------------->>
            //if(this.CustAnalysCode1St != target.CustAnalysCode1St)resList.Add("CustAnalysCode1St");
            //if(this.CustAnalysCode1Ed != target.CustAnalysCode1Ed)resList.Add("CustAnalysCode1Ed");
            //if(this.CustAnalysCode2St != target.CustAnalysCode2St)resList.Add("CustAnalysCode2St");
            //if(this.CustAnalysCode2Ed != target.CustAnalysCode2Ed)resList.Add("CustAnalysCode2Ed");
            //if(this.CustAnalysCode3St != target.CustAnalysCode3St)resList.Add("CustAnalysCode3St");
            //if(this.CustAnalysCode3Ed != target.CustAnalysCode3Ed)resList.Add("CustAnalysCode3Ed");
            //if(this.CustAnalysCode4St != target.CustAnalysCode4St)resList.Add("CustAnalysCode4St");
            //if(this.CustAnalysCode4Ed != target.CustAnalysCode4Ed)resList.Add("CustAnalysCode4Ed");
            //if(this.CustAnalysCode5St != target.CustAnalysCode5St)resList.Add("CustAnalysCode5St");
            //if(this.CustAnalysCode5Ed != target.CustAnalysCode5Ed)resList.Add("CustAnalysCode5Ed");
            //if(this.CustAnalysCode6St != target.CustAnalysCode6St)resList.Add("CustAnalysCode6St");
            //if(this.CustAnalysCode6Ed != target.CustAnalysCode6Ed)resList.Add("CustAnalysCode6Ed");
            // 2007.10.15 hikita del end -------------------------------------------------------------------------------<<
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //if (this.IsBillOutputOnly != target.IsBillOutputOnly) resList.Add("IsBillOutputOnly");
            // 2008.09.05 30413 ���� �폜���� <<<<<<<END
            if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");
			//if(this.CorporateDivNameList != target.CorporateDivNameList)resList.Add("CorporateDivNameList");  // 2007.10.15 hikita del
            if (this.OutPutPriceCond != target.OutPutPriceCond) resList.Add("OutPutPriceCond");
            if (this.DmdDtl != target.DmdDtl) resList.Add("DmdDtl");                                            // 2007.10.15 hikita add   
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //if (this.SlipTotalPrt != target.SlipTotalPrt) resList.Add("SlipTotalPrt");
            //if(this.AddUpDateTotalPrt != target.AddUpDateTotalPrt)resList.Add("AddUpDateTotalPrt");
            //if(this.CustomerTotalPrt != target.CustomerTotalPrt)resList.Add("CustomerTotalPrt");
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            //if(this.CarrierTotalPrt != target.CarrierTotalPrt)resList.Add("CarrierTotalPrt");                 // 2007.10.15 hikita del
            // 2008.09.05 30413 ���� ���ڒǉ� >>>>>>START
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.SalesAreaCodeSt != target.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (this.SalesAreaCodeEd != target.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (this.CollectRatePrtDiv != target.CollectRatePrtDiv) resList.Add("CollectRatePrtDiv");
            if (this.BalanceDepositDtl != target.BalanceDepositDtl) resList.Add("BalanceDepositDtl");
            if (this.IsBillOutputOnly != target.IsBillOutputOnly) resList.Add("IsBillOutputOnly");
            if (this.SlipPrtKind != target.SlipPrtKind) resList.Add("SlipPrtKind");
            if (this.IssueDay != target.IssueDay) resList.Add("IssueDay");
            // 2008.09.05 30413 ���� ���ڒǉ� <<<<<<END
            if (this.PrCustDtl != target.PrCustDtl) resList.Add("PrCustDtl");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            //---ADD 2011/03/14------------->>>>>
            if (this.PrintBlLiDiv != target.PrintBlLiDiv) resList.Add("PrintBlLiDiv");
            if (this.LineMaSqOfChDiv != target.LineMaSqOfChDiv) resList.Add("LineMaSqOfChDiv");
            //---ADD 2011/03/14-------------<<<<<
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
            if (this.TaxPrintDiv != target.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (this.TaxRate1 != target.TaxRate1) resList.Add("TaxRate1");
            if (this.TaxRate2 != target.TaxRate2) resList.Add("TaxRate2");
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
			return resList;
		}

		/// <summary>
		/// ������(�ӕ�)���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_DemandTotal1">��r����ExtrInfo_DemandTotal�N���X�̃C���X�^���X</param>
		/// <param name="extrInfo_DemandTotal2">��r����ExtrInfo_DemandTotal�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DemandTotal�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_DemandTotal extrInfo_DemandTotal1, ExtrInfo_DemandTotal extrInfo_DemandTotal2)
		{
			ArrayList resList = new ArrayList();
			if(extrInfo_DemandTotal1.EnterpriseCode != extrInfo_DemandTotal2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(extrInfo_DemandTotal1.IsSelectAllSection != extrInfo_DemandTotal2.IsSelectAllSection)resList.Add("IsSelectAllSection");
			if(extrInfo_DemandTotal1.IsOutputAllSecRec != extrInfo_DemandTotal2.IsOutputAllSecRec)resList.Add("IsOutputAllSecRec");
			if(extrInfo_DemandTotal1.ResultsAddUpSecList != extrInfo_DemandTotal2.ResultsAddUpSecList)resList.Add("ResultsAddUpSecList");
			if(extrInfo_DemandTotal1.IsOptSection != extrInfo_DemandTotal2.IsOptSection)resList.Add("IsOptSection");
			if(extrInfo_DemandTotal1.IsMainOfficeFunc != extrInfo_DemandTotal2.IsMainOfficeFunc)resList.Add("IsMainOfficeFunc");
            // 2008.09.08 30413 ���� �v��N�����̌^��ύX >>>>>>START
            if (extrInfo_DemandTotal1.AddUpDate != extrInfo_DemandTotal2.AddUpDate) resList.Add("AddUpDate");
            // 2008.09.08 30413 ���� �v��N�����̌^��ύX <<<<<<END
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //if (extrInfo_DemandTotal1.TargetAddUpDate != extrInfo_DemandTotal2.TargetAddUpDate) resList.Add("TargetAddUpDate");
            //if(extrInfo_DemandTotal1.TotalDay != extrInfo_DemandTotal2.TotalDay)resList.Add("TotalDay");
            //if (extrInfo_DemandTotal1.IsLastDay != extrInfo_DemandTotal2.IsLastDay) resList.Add("IsLastDay");
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            if (extrInfo_DemandTotal1.CustomerCodeSt != extrInfo_DemandTotal2.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if(extrInfo_DemandTotal1.CustomerCodeEd != extrInfo_DemandTotal2.CustomerCodeEd)resList.Add("CustomerCodeEd");
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //if (extrInfo_DemandTotal1.KanaSt != extrInfo_DemandTotal2.KanaSt) resList.Add("KanaSt");
            //if(extrInfo_DemandTotal1.KanaEd != extrInfo_DemandTotal2.KanaEd)resList.Add("KanaEd");
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            // 2007.10.15 hikita del start ------------------------------------------------------------------------------------------------->>
            //if(extrInfo_DemandTotal1.CorporateDivCodeList != extrInfo_DemandTotal2.CorporateDivCodeList)resList.Add("CorporateDivCodeList");
            //if(extrInfo_DemandTotal1.IsSelectAllCorporateDiv != extrInfo_DemandTotal2.IsSelectAllCorporateDiv)resList.Add("IsSelectAllCorporateDiv");
            // 2007.10.15 hikita del end ---------------------------------------------------------------------------------------------------<<
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //if (extrInfo_DemandTotal1.IsEmployeeNextPage != extrInfo_DemandTotal2.IsEmployeeNextPage) resList.Add("IsEmployeeNextPage");
            //if(extrInfo_DemandTotal1.IsJudgeBillOutputCode != extrInfo_DemandTotal2.IsJudgeBillOutputCode)resList.Add("IsJudgeBillOutputCode");
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            if (extrInfo_DemandTotal1.CustomerAgentDivCd != extrInfo_DemandTotal2.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if(extrInfo_DemandTotal1.BillCollecterCdSt != extrInfo_DemandTotal2.BillCollecterCdSt)resList.Add("BillCollecterCdSt");
			if(extrInfo_DemandTotal1.BillCollecterCdEd != extrInfo_DemandTotal2.BillCollecterCdEd)resList.Add("BillCollecterCdEd");
			if(extrInfo_DemandTotal1.CustomerAgentCdSt != extrInfo_DemandTotal2.CustomerAgentCdSt)resList.Add("CustomerAgentCdSt");
			if(extrInfo_DemandTotal1.CustomerAgentCdEd != extrInfo_DemandTotal2.CustomerAgentCdEd)resList.Add("CustomerAgentCdEd");
            // 2007.10.15 hikita del start ------------------------------------------------------------------------------------------------->>
            //if(extrInfo_DemandTotal1.CustAnalysCode1St != extrInfo_DemandTotal2.CustAnalysCode1St)resList.Add("CustAnalysCode1St");
            //if(extrInfo_DemandTotal1.CustAnalysCode1Ed != extrInfo_DemandTotal2.CustAnalysCode1Ed)resList.Add("CustAnalysCode1Ed");
            //if(extrInfo_DemandTotal1.CustAnalysCode2St != extrInfo_DemandTotal2.CustAnalysCode2St)resList.Add("CustAnalysCode2St");
            //if(extrInfo_DemandTotal1.CustAnalysCode2Ed != extrInfo_DemandTotal2.CustAnalysCode2Ed)resList.Add("CustAnalysCode2Ed");
            //if(extrInfo_DemandTotal1.CustAnalysCode3St != extrInfo_DemandTotal2.CustAnalysCode3St)resList.Add("CustAnalysCode3St");
            //if(extrInfo_DemandTotal1.CustAnalysCode3Ed != extrInfo_DemandTotal2.CustAnalysCode3Ed)resList.Add("CustAnalysCode3Ed");
            //if(extrInfo_DemandTotal1.CustAnalysCode4St != extrInfo_DemandTotal2.CustAnalysCode4St)resList.Add("CustAnalysCode4St");
            //if(extrInfo_DemandTotal1.CustAnalysCode4Ed != extrInfo_DemandTotal2.CustAnalysCode4Ed)resList.Add("CustAnalysCode4Ed");
            //if(extrInfo_DemandTotal1.CustAnalysCode5St != extrInfo_DemandTotal2.CustAnalysCode5St)resList.Add("CustAnalysCode5St");
            //if(extrInfo_DemandTotal1.CustAnalysCode5Ed != extrInfo_DemandTotal2.CustAnalysCode5Ed)resList.Add("CustAnalysCode5Ed");
            //if(extrInfo_DemandTotal1.CustAnalysCode6St != extrInfo_DemandTotal2.CustAnalysCode6St)resList.Add("CustAnalysCode6St");
            //if(extrInfo_DemandTotal1.CustAnalysCode6Ed != extrInfo_DemandTotal2.CustAnalysCode6Ed)resList.Add("CustAnalysCode6Ed");
            // 2007.10.15 hikita del end ---------------------------------------------------------------------------------------------------<<
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //if (extrInfo_DemandTotal1.IsBillOutputOnly != extrInfo_DemandTotal2.IsBillOutputOnly) resList.Add("IsBillOutputOnly");
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            if (extrInfo_DemandTotal1.SortOrder != extrInfo_DemandTotal2.SortOrder) resList.Add("SortOrder");
			//if(extrInfo_DemandTotal1.CorporateDivNameList != extrInfo_DemandTotal2.CorporateDivNameList)resList.Add("CorporateDivNameList");    // 2007.10.15 hiktia del
			if(extrInfo_DemandTotal1.OutPutPriceCond != extrInfo_DemandTotal2.OutPutPriceCond)resList.Add("OutPutPriceCond");
            if (extrInfo_DemandTotal1.DmdDtl != extrInfo_DemandTotal2.DmdDtl) resList.Add("DmdDtl");                                              // 2007.10.15 hikita add
            // 2008.09.05 30413 ���� �폜���� >>>>>>START
            //if (extrInfo_DemandTotal1.SlipTotalPrt != extrInfo_DemandTotal2.SlipTotalPrt) resList.Add("SlipTotalPrt");
            //if(extrInfo_DemandTotal1.AddUpDateTotalPrt != extrInfo_DemandTotal2.AddUpDateTotalPrt)resList.Add("AddUpDateTotalPrt");
            //if(extrInfo_DemandTotal1.CustomerTotalPrt != extrInfo_DemandTotal2.CustomerTotalPrt)resList.Add("CustomerTotalPrt");
            // 2008.09.05 30413 ���� �폜���� <<<<<<END
            //if(extrInfo_DemandTotal1.CarrierTotalPrt != extrInfo_DemandTotal2.CarrierTotalPrt)resList.Add("CarrierTotalPrt");                   // 2007.10.15 hiktia del
            // 2008.09.05 30413 ���� ���ڒǉ� >>>>>>START
            if (extrInfo_DemandTotal1.NewPageDiv != extrInfo_DemandTotal2.NewPageDiv) resList.Add("NewPageDiv");
            if (extrInfo_DemandTotal1.SalesAreaCodeSt != extrInfo_DemandTotal2.SalesAreaCodeSt) resList.Add("SalesAreaCodeSt");
            if (extrInfo_DemandTotal1.SalesAreaCodeEd != extrInfo_DemandTotal2.SalesAreaCodeEd) resList.Add("SalesAreaCodeEd");
            if (extrInfo_DemandTotal1.CollectRatePrtDiv != extrInfo_DemandTotal2.CollectRatePrtDiv) resList.Add("CollectRatePrtDiv");
            if (extrInfo_DemandTotal1.BalanceDepositDtl != extrInfo_DemandTotal2.BalanceDepositDtl) resList.Add("BalanceDepositDtl");
            if (extrInfo_DemandTotal1.IsBillOutputOnly != extrInfo_DemandTotal2.IsBillOutputOnly) resList.Add("IsBillOutputOnly");
            if (extrInfo_DemandTotal1.SlipPrtKind != extrInfo_DemandTotal2.SlipPrtKind) resList.Add("SlipPrtKind");
            if (extrInfo_DemandTotal1.IssueDay != extrInfo_DemandTotal2.IssueDay) resList.Add("IssueDay");
            // 2008.09.05 30413 ���� ���ڒǉ� <<<<<<END
            if (extrInfo_DemandTotal1.PrCustDtl != extrInfo_DemandTotal2.PrCustDtl) resList.Add("PrCustDtl");
            if (extrInfo_DemandTotal1.AccRecDivCd != extrInfo_DemandTotal2.AccRecDivCd) resList.Add("AccRecDivCd");
            if (extrInfo_DemandTotal1.EnterpriseName != extrInfo_DemandTotal2.EnterpriseName) resList.Add("EnterpriseName");
            //---ADD 2011/03/14------------->>>>>
            if (extrInfo_DemandTotal1.PrintBlLiDiv != extrInfo_DemandTotal2.PrintBlLiDiv) resList.Add("PrintBlLiDiv");
            if (extrInfo_DemandTotal1.LineMaSqOfChDiv != extrInfo_DemandTotal2.LineMaSqOfChDiv) resList.Add("LineMaSqOfChDiv");
            //---ADD 2011/03/14-------------<<<<<
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ---------->>>>>
            if (extrInfo_DemandTotal1.TaxPrintDiv != extrInfo_DemandTotal2.TaxPrintDiv) resList.Add("TaxPrintDiv");
            if (extrInfo_DemandTotal1.TaxRate1 != extrInfo_DemandTotal2.TaxRate1) resList.Add("TaxRate1");
            if (extrInfo_DemandTotal1.TaxRate2 != extrInfo_DemandTotal2.TaxRate2) resList.Add("TaxRate2");
            // --- ADD 2020/04/13 ���O �y���ŗ��Ή� ----------<<<<<
			return resList;
		}

        // ----- iitani a ---------- start 2007.05.14
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
        // ----- iitani a ---------- end 2007.05.14

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

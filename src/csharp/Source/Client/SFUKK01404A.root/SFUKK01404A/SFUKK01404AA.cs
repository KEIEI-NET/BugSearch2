using System;
using System.Data;
using System.Collections;

using Broadleaf.Library.Globarization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using System.Collections.Generic;
using System.Collections.Specialized;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �������́i�����^�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �������́i�����^�j�t�h�N���X�̃A�N�Z�X�N���X�ł��B</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
    /// <br>Update Note: 2007.01.18 T.Kimura MA.NS�p�ɕύX</br>
    /// <br>               �E�󒍁E����p���ڂ͎g�p���Ȃ��̂ō폜</br>
    /// <br>               �E�C���Z���e�B�u��ǉ�</br>
    /// <br>             2007.01.22 T.Kimura</br>
    /// <br>             2007.03.27 T.Kimura SetClaimSales�ŁA��������ԍ��敪��null������s����C��</br>
    /// <br>                                 �i�f�[�^�������������炩������Ȃ��j</br>
    /// <br>             2007.04.18 T.Kimura ���Ӑ搿�����z�}�X�^�̕ύX�ɔ����C��</br>
    /// <br>             2007.10.05 20081 �D�c �E�l �����f�[�^�̕ύX�ɔ����C��</br>
    /// <br>             2008/06/26 30414 �E �K�j Partsman�p�ɏC��</br>
    /// <br>UpdateNote : 2009/12/16 ����� �o�l�D�m�r�ێ�˗��C</br>
    /// <br>             ���쐫/���͑��x����̂��߂Ɉȉ��̉��ǂ��s��</br>
    /// <br>UpdateNote : 2010/03/25 �H�� MANTIS�Ή�[15195]</br>
    /// <br>             0�~�����ۑ����ɢ�����ʣ��\�����A�I����ɓo�^�֕ύX</br>
    /// <br>UpdateNote : 2010/03/25 �H�� MANTIS�Ή�[15196]</br>
    /// <br>             �����ꗗ��ʂɢ���͒S���ң��\���֕ύX</br>
    /// <br>UpdateNote : 2010/05/12 �H�� MANTIS�Ή�[15195]</br>
    /// <br>             ����0���C���ďo������̕ۑ����s���Ȃ�</br>
    /// <br>Update Note : 2010.05.06 gejun</br>
    /// <br>              M1007A-�x����`�f�[�^�X�V�ǉ�</br>
    /// <br>Update Note : 2010/12/20 ����� PM.NS��Q���ǑΉ�(12����)</br>
    /// <br>              �@�ӕ��̏W�v���Ԃ̏I������MAX�ɕύX����B</br>
    /// <br>              �A�������\���̉���</br>
    /// <br>Update Note : 2011/02/09 ����� Redmine#18848�̏C��</br>
    /// <br>Update Note : 2011.07.22 �{�z��</br>
    /// <br>              �\���s��̈׉��P�肢�܂��C�Ή��A��850�B</br>
    /// <br>Update Note : 2011/12/15 tianjw</br>
    /// <br>              Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
    /// <br>Update Note : K2012/07/13 FSI���� �R�`���i�ʈ˗�</br>
    /// <br>              �U�����z���͎��͓Ǝ��̋�s�R�[�h�̓��͂��\�ɏC��</br>
    /// <br>Update Note : 2012/09/21 �c����</br>
    /// <br>�Ǘ��ԍ�    : 2012/10/17�z�M��</br>
    /// <br>              Redmine#32415 ���s�҂̒ǉ��Ή�</br>
    /// <br>Update Note : 2012/10/05 ���� ��</br>
    /// <br>              2012/10/17�z�M�V�X�e���e�X�g��QNo24</br>
    /// <br>              �ԓ����`�[���폜����ƁA�����̔��s�҂��N���A�����</br>
    /// <br>Update Note : 2012/12/24 ���N</br>
    /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
    /// <br>              Redmine#33741�̑Ή�</br>
    /// <br>Update Note : 2013/01/31 �c����</br>
    /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
    /// <br>              Redmine#34506 ��������^�u�����������ƁA�����ꗗ�ň�����"��"�A�������z���[���ɂȂ�Ȃ��Ή�</br>
    /// <br>Update Note : 2015/07/16 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�    : 11100068-00</br>
    /// <br>              ���C�����ԍH�Ɖۑ�Ή��ꗗ��1</br>
    /// <br>              �@�ꊇ�����{�^���������A�����������z�E�����z�E���㖢�����z�ɕs���Ȓl���\�������</br>
    /// <br>              ������Q�@</br>
    /// <br>              �@�ꊇ�����{�^���������̖��׃`�F�b�N�L���ł̓���s��v</br>
    /// <br>              ������Q�A</br>
    /// <br>              �@�ԓ`���s�ɃA�v���P�[�V�����G���[����������</br>
    /// <br>              ������Q�B</br>
    /// <br>              �@�ꕔ�������s���������`�[���Ăяo���������z���C�����ۑ����s���ƁA�`�[�̖������z���Ԉ�����z�ŕ\�������</br>
    /// <br>              ������Q�C</br>
    /// <br>              �@�ꕔ�������s���������`�[�ɑ΂��ē`�[���v��葽�����z�������z�ɓ��͂���Ɖߏ���������</br>
    /// <br></br>
	/// </remarks>
	public class InputDepositNormalTypeAcs
	{
		# region Constructor
		/// <summary>
		/// �������́i���^�j�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �g�p���郁���o�̏��������s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public InputDepositNormalTypeAcs()
		{
			// ������� DataSet
			this._dsDepositInfo = new DataSet();

			// ���������� DataSet
			this._dsDmdSalesInfo = new DataSet();

			// �������Ӑ���N���X
			this._depositCustomer = new DepositCustomer();

			// �������Ӑ搿�����z���N���X
			this._depositCustDmdPrc = new DepositCustDmdPrc();

			// �����}�X�^�N���X
			this._depsitMain = new Hashtable();

			// ���������}�X�^�N���X(�����ԍ����x���ň��k)
			this._depositAlw = new Hashtable();

			// ��������}�X�^�N���X(���񌟍���)
			this._dmdSales = new ArrayList();

			// ��������}�X�^�N���X(���񌟍��œǂݍ���łȂ���)
			this._dmdSalesSecond = new ArrayList();

			// �������͐ݒ�f�[�^�n�A�N�Z�X�N���X
			this.depositRelDataAcs = new DepositRelDataAcs();

			// ���������A�N�Z�X�N���X
			this._searchDepsitAcs = new SearchDepsitAcs();
			
            // �� 20070122 18322 c
			//// �������㌟���A�N�Z�X�N���X(SFUKK01461A)
			//this._searchDmdSalesAcs = new SearchDmdSalesAcs();

			// �������㌟���A�N�Z�X�N���X
			this._searchClaimSalesAcs = new SearchClaimSalesAcs();
            // �� 20070122 18322 c
			
			// �����X�V�A�N�Z�X�N���X
			this._depsitMainAcs = new DepsitMainAcs();

			// ����KINGET�A�N�Z�X�N���X
			this._kingetCustDmdPrcAcs = new KingetCustDmdPrcAcs();

            this._employeeAcs = new EmployeeAcs();

            ReadEmployee();
            
            // �� 20070518 18322 d �g�p���Ȃ��̂ō폜
			//// �����X�V�����擾�A�N�Z�X�N���X
			//this._cAddUpHisAcs = new CAddUpHisAcs();
            // �� 20070518 18322 d

            //// �� 20070801 18322 a
            //// �������ߏ����̃����[�g�I�u�W�F�N�g
            //this._iMonthlyAddUpDB = (IMonthlyAddUpDB)MediationMonthlyAddUpDB.GetCustMonthlyAddUpDB();

            //this._lastMonthlyAddUpHis = null;
            //// �� 20070801 18322 a

            this._totalDayCalculator = TotalDayCalculator.GetInstance();
            //----- ADD K2013/03/22 ���� Redmine#35063 ----->>>>>
            // �I�v�V�������L���b�V��
            CacheOptionInfo();
            //----- ADD K2013/03/22 ���� Redmine#35063 -----<<<<<
		}
		# endregion

		# region Private Menbers
		//***************************************************************
		// ��ʃo�C���h�p DataSet
		//***************************************************************
		/// <summary>������� DataSet</summary>
		private DataSet _dsDepositInfo;

		/// <summary>���������� DataSet</summary>
		private DataSet _dsDmdSalesInfo;

		/// <summary>�������Ӑ���N���X</summary>
		private DepositCustomer _depositCustomer;

		/// <summary>�������Ӑ搿�����z���N���X</summary>
		private DepositCustDmdPrc _depositCustDmdPrc;

		//***************************************************************
		// �f�[�^�ێ��p �f�[�^�N���X
		//***************************************************************
		/// <summary>�����}�X�^�N���X</summary>
		private Hashtable _depsitMain;

		/// <summary>���������}�X�^�N���X(�����ԍ����x���ň��k)</summary>
		private Hashtable _depositAlw;

		/// <summary>��������}�X�^�N���X(���񌟍���)</summary>
		private ArrayList _dmdSales;

		/// <summary>��������}�X�^�N���X(���񌟍��œǂݍ���łȂ���)</summary>
		private ArrayList _dmdSalesSecond;

		//***************************************************************
		// �����o�[
		//***************************************************************
		/// <summary>�������͐ݒ�f�[�^�n�A�N�Z�X�N���X</summary>
		private DepositRelDataAcs depositRelDataAcs;

		/// <summary>���������A�N�Z�X�N���X</summary>
		private SearchDepsitAcs _searchDepsitAcs;

        // �� 20070122 18322 c
		///// <summary>�������㌟���A�N�Z�X�N���X</summary>
		//private SearchDmdSalesAcs _searchDmdSalesAcs;

		/// <summary>�������㌟���A�N�Z�X�N���X</summary>
		private SearchClaimSalesAcs _searchClaimSalesAcs;
        // �� 20070122 18322 c

		/// <summary>�����X�V�A�N�Z�X�N���X</summary>
		private DepsitMainAcs _depsitMainAcs;

		/// <summary>����KINGET�A�N�Z�X�N���X</summary>
		private KingetCustDmdPrcAcs _kingetCustDmdPrcAcs;

        ///// <summary>�����������[�g�N���X</summary>
        //private IMonthlyAddUpDB     _iMonthlyAddUpDB = null;
        ///// <summary>�����������N���X</summary>
        //private MonthlyAddUpHisWork _lastMonthlyAddUpHis = null;

        // �O�񌎎�����
        private DateTime _lastMonthlyAddUpDay;
        // �O�����
        private DateTime _lastAddUpDay;

        /// <summary>�����Z�o���W���[��</summary>
        private TotalDayCalculator _totalDayCalculator;

        private int _consTaxLayMethod;

        private EmployeeAcs _employeeAcs;

        private Dictionary<string, EmployeeDtl> _emoloyeeDtlDic;

        // �� 20070518 18322 d �g�p���Ȃ��̂ō폜
		///// <summary>�����X�V�A�N�Z�X�N���X</summary>
		//private CAddUpHisAcs _cAddUpHisAcs;
        // �� 20070518 18322 d
        // --- ADD K2013/03/22 ���� Redmine#35063 ---------->>>>>
        /// <summary> �R�`���i�I�v�V�����t���O</summary>
        private int _opt_YamagataCtrl;
        // --- ADD K2013/03/22 ���� Redmine#35063 ----------<<<<<
		# endregion

		# region public const Menbers
		//***************************************************************
		// �������DataSet�p�萔�錾(�������)
		//***************************************************************
		/// <summary>�������Table����</summary>
		public const string ctDepositDataTable = "DepositTable";

        // ----- ADD ���N�@2012/12/24 Redmine#33741 ----- >>>>>
        /// <summary>����Guid���Table����</summary>
        public const string ctDepositGuidDataTable = "DepositGuidTable";
        // ----- ADD ���N�@2012/12/24 Redmine#33741 ----- <<<<<

		/// <summary>�����ԍ��敪</summary>
		public const string ctDepositDebitNoteCd = "ctDepositDebitNoteCd";

		/// <summary>�����ԍ�����</summary>
		public const string ctDepositDebitNoteNm = "ctDepositDebitNoteNm";

		/// <summary>�����`�[�ԍ�</summary>
		public const string ctDepositSlipNo = "DepositSlipNo";

		/// <summary>�ԍ������A���ԍ�</summary>
		public const string ctDebitNoteLinkDepoNo = "DebitNoteLinkDepoNo";

		/// <summary>�������t(�\���p)</summary>
		public const string ctDepositDateDisp = "DepositDateDisp";
		
		/// <summary>�������t</summary>
		public const string ctDepositDate = "DepositDate";
		
		/// <summary>�v����t</summary>
		public const string ctDepositAddUpADate = "AddUpADate";

        /// <summary>�v����t(�\���p)</summary>
        public const string ctDepositAddUpADateDisp = "AddUpADateDisp";   // 2007.10.05 add

        /// <summary>�󒍃X�e�[�^�X</summary>
        public const string ctDepositAcptAnOdrStatus = "AcptAnOdrStatus"; // 2007.10.05 add

		/// <summary>���������敪</summary>
		public const string ctAutoDepositCd = "AutoDepositCd";

        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
        ///// <summary>�a����敪�R�[�h</summary>
        //public const string ctDepositCd = "DepositCd";
		
        /// <summary>�a����敪����</summary>
        public const string ctDepositNm = "DepositNm";
		
        ///// <summary>��������敪</summary>
        //public const string ctDepositKindDivCd = "DepositKindDivCd";
		
        ///// <summary>��������R�[�h</summary>
        //public const string ctDepositKindCode = "DepositKindCode";
        
        /// <summary>�������햼��</summary>
		public const string ctDepositKindName = "DepositKindName";
        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

        // �� 20070118 18322 d MA.NS�p�ɕύX
        #region SF �󒍁E����p�i�S�ăR�����g�A�E�g�j
        ///// <summary>�� �����z</summary>
		//public const string ctAcpOdrDeposit = "AcpOdrDeposit";
		//
		///// <summary>�� �萔��</summary>
		//public const string ctAcpOdrChargeDeposit = "AcpOdrChargeDeposit";
		//
		///// <summary>�� �l��</summary>
		//public const string ctAcpOdrDisDeposit = "AcpOdrDisDeposit";
		//
		///// <summary>�� �����v</summary>
		//public const string ctAcpOdrDepositTotal = "AcpOdrDepositTotal";
	
		///// <summary>����p �����z</summary>
		//public const string ctVariousCostDeposit = "VariousCostDeposit";
		//
		///// <summary>����p �萔��</summary>
		//public const string ctVarCostChargeDeposit = "VarCostChargeDeposit";
		//
		///// <summary>����p �l��</summary>
		//public const string ctVarCostDisDeposit = "VarCostDisDeposit";
        //
		///// <summary>����p �����v</summary>
        //public const string ctVariousCostDepositTotal = "VariousCostDepositTotal";
        #endregion
        // �� 20070118 18322 d
		
		/// <summary>���� �����z</summary>
		public const string ctDeposit = "Deposit";
		
		/// <summary>���� �萔��</summary>
		public const string ctFeeDeposit = "FeeDeposit";
		
		/// <summary>���� �l��</summary>
		public const string ctDiscountDeposit = "DiscountDeposit";

        // �� 20070118 18322 a
		//// <summary>���� �C���Z���e�B�u</summary>
		// public const string ctRebateDeposit = "RebateDeposit";  // 2007.10.05 del
        // �� 20070118 18322 a

		/// <summary>���� �����v</summary>
		public const string ctDepositTotal = "DepositTotal";

        // --- ADD 2010/12/20 ---------->>>>>
        /// <summary>����</summary>
        public const string ctAllowDiv = "AllowDiv";
        // --- ADD 2010/12/20  ----------<<<<<

        // --- ADD 2010/12/20 ---------->>>>>
        /// <summary>����`�[�ԍ�</summary>
        public const string ctDepSaleSlipNum = "DepSaleSlipNum";
        // --- ADD 2010/12/20  ----------<<<<<

        // �� 20070118 18322 d MA.NS�p�ɕύX
        #region SF ���������z�E���������c �󒍁E����p�i�S�ăR�����g�A�E�g�j
        ///// <summary>���������z ��</summary>
		//public const string ctAcpOdrDepositAlwc_Deposit = "AcpOdrDepositAlwc";
		//
		///// <summary>���������c ��</summary>
		//public const string ctAcpOdrDepoAlwcBlnce_Deposit = "AcpOdrDepoAlwcBlnce";
        //	
		///// <summary>���������z ����p</summary>
		//public const string ctVarCostDepoAlwc_Deposit = "VarCostDepoAlwc";
		//
		///// <summary>���������c ����p</summary>
        //public const string ctVarCostDepoAlwcBlnce_Deposit = "VarCostDepoAlwcBlnce";
        #endregion
        // �� 20070118 18322 d

		/// <summary>���������z ����</summary>
		public const string ctDepositAllowance_Deposit = "DepositAllowance";
		
		/// <summary>���������c ����</summary>
		public const string ctDepositAlwcBlnce_Deposit = "DepositAlwcBlnce";
		
        // 2007.10.05 del start ------------------------------------->>
        ///// <summary>�N���W�b�g/���[���敪</summary>
        //public const string ctCreditOrLoanCd = "CreditOrLoanCd";�@�@
		
        ///// <summary>�N���W�b�g��ЃR�[�h</summary>
        //public const string ctCreditCompanyCode = "CreditCompanyCode";
        // 2007.10.05 del end ---------------------------------------<<
		
		/// <summary>��`�U�o��</summary>
		public const string ctDraftDrawingDate = "DraftDrawingDate";

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>��`�x������</summary>
        public const string ctDraftPayTimeLimit = "DraftPayTimeLimit";
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        // 2007.10.05 add start -------------------------------------->>
        /// <summary>��s�R�[�h</summary>
        public const string ctBankCode = "BankCode";
        /// <summary>��s����</summary>
        public const string ctBankName = "BankName";
        /// <summary>��`�ԍ�</summary>
        public const string ctDraftNo = "DraftNo";
        /// <summary>��`���</summary>
        public const string ctDraftKind = "DraftKind";
        /// <summary>��`��ޖ���</summary>
        public const string ctDraftKindName = "DraftKindName";
        /// <summary>��`�敪</summary>
        public const string ctDraftDivide = "DraftDivide";
        /// <summary>��`�敪����</summary>
        public const string ctDraftDivideName = "DraftDivideName";
        // 2007.10.05 add end ----------------------------------------<<

		/// <summary>�E�v</summary>
		public const string ctOutline = "Outline";

		/// <summary>���ߏ��</summary>
		public const string ctDepositClosedFlg = "ClosedFlg";

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>�����s�ԍ�1</summary>
        public const string ctDepositRowNo1 = "DepositRowNo1";
        /// <summary>����R�[�h1</summary>
        public const string ctMoneyKindCode1 = "MoneyKindCode1";
        /// <summary>���햼��1</summary>
        public const string ctMoneyKindName1 = "MoneyKindName1";
        /// <summary>����敪1</summary>
        public const string ctMoneyKindDiv1 = "MoneyKindDiv1";
        /// <summary>�������z1</summary>
        public const string ctDeposit1 = "Deposit1";
        /// <summary>�L������1</summary>
        public const string ctValidityTerm1 = "ValidityTerm1";
        /// <summary>�����s�ԍ�2</summary>
        public const string ctDepositRowNo2 = "DepositRowNo2";
        /// <summary>����R�[�h2</summary>
        public const string ctMoneyKindCode2 = "MoneyKindCode2";
        /// <summary>���햼��2</summary>
        public const string ctMoneyKindName2 = "MoneyKindName2";
        /// <summary>����敪2</summary>
        public const string ctMoneyKindDiv2 = "MoneyKindDiv2";
        /// <summary>�������z2</summary>
        public const string ctDeposit2 = "Deposit2";
        /// <summary>�L������2</summary>
        public const string ctValidityTerm2 = "ValidityTerm2";
        /// <summary>�����s�ԍ�3</summary>
        public const string ctDepositRowNo3 = "DepositRowNo3";
        /// <summary>����R�[�h3</summary>
        public const string ctMoneyKindCode3 = "MoneyKindCode3";
        /// <summary>���햼��3</summary>
        public const string ctMoneyKindName3 = "MoneyKindName3";
        /// <summary>����敪3</summary>
        public const string ctMoneyKindDiv3 = "MoneyKindDiv3";
        /// <summary>�������z3</summary>
        public const string ctDeposit3 = "Deposit3";
        /// <summary>�L������3</summary>
        public const string ctValidityTerm3 = "ValidityTerm3";
        /// <summary>�����s�ԍ�4</summary>
        public const string ctDepositRowNo4 = "DepositRowNo4";
        /// <summary>����R�[�h4</summary>
        public const string ctMoneyKindCode4 = "MoneyKindCode4";
        /// <summary>���햼��4</summary>
        public const string ctMoneyKindName4 = "MoneyKindName4";
        /// <summary>����敪4</summary>
        public const string ctMoneyKindDiv4 = "MoneyKindDiv4";
        /// <summary>�������z4</summary>
        public const string ctDeposit4 = "Deposit4";
        /// <summary>�L������4</summary>
        public const string ctValidityTerm4 = "ValidityTerm4";
        /// <summary>�����s�ԍ�5</summary>
        public const string ctDepositRowNo5 = "DepositRowNo5";
        /// <summary>����R�[�h5</summary>
        public const string ctMoneyKindCode5 = "MoneyKindCode5";
        /// <summary>���햼��5</summary>
        public const string ctMoneyKindName5 = "MoneyKindName5";
        /// <summary>����敪5</summary>
        public const string ctMoneyKindDiv5 = "MoneyKindDiv5";
        /// <summary>�������z5</summary>
        public const string ctDeposit5 = "Deposit5";
        /// <summary>�L������5</summary>
        public const string ctValidityTerm5 = "ValidityTerm5";
        /// <summary>�����s�ԍ�6</summary>
        public const string ctDepositRowNo6 = "DepositRowNo6";
        /// <summary>����R�[�h6</summary>
        public const string ctMoneyKindCode6 = "MoneyKindCode6";
        /// <summary>���햼��6</summary>
        public const string ctMoneyKindName6 = "MoneyKindName6";
        /// <summary>����敪6</summary>
        public const string ctMoneyKindDiv6 = "MoneyKindDiv6";
        /// <summary>�������z6</summary>
        public const string ctDeposit6 = "Deposit6";
        /// <summary>�L������6</summary>
        public const string ctValidityTerm6 = "ValidityTerm6";
        /// <summary>�����s�ԍ�7</summary>
        public const string ctDepositRowNo7 = "DepositRowNo7";
        /// <summary>����R�[�h7</summary>
        public const string ctMoneyKindCode7 = "MoneyKindCode7";
        /// <summary>���햼��7</summary>
        public const string ctMoneyKindName7 = "MoneyKindName7";
        /// <summary>����敪7</summary>
        public const string ctMoneyKindDiv7 = "MoneyKindDiv7";
        /// <summary>�������z7</summary>
        public const string ctDeposit7 = "Deposit7";
        /// <summary>�L������7</summary>
        public const string ctValidityTerm7 = "ValidityTerm7";
        /// <summary>�����s�ԍ�8</summary>
        public const string ctDepositRowNo8 = "DepositRowNo8";
        /// <summary>����R�[�h8</summary>
        public const string ctMoneyKindCode8 = "MoneyKindCode8";
        /// <summary>���햼��8</summary>
        public const string ctMoneyKindName8 = "MoneyKindName8";
        /// <summary>����敪8</summary>
        public const string ctMoneyKindDiv8 = "MoneyKindDiv8";
        /// <summary>�������z8</summary>
        public const string ctDeposit8 = "Deposit8";
        /// <summary>�L������8</summary>
        public const string ctValidityTerm8 = "ValidityTerm8";
        /// <summary>�����s�ԍ�9</summary>
        public const string ctDepositRowNo9 = "DepositRowNo9";
        /// <summary>����R�[�h9</summary>
        public const string ctMoneyKindCode9 = "MoneyKindCode9";
        /// <summary>���햼��9</summary>
        public const string ctMoneyKindName9 = "MoneyKindName9";
        /// <summary>����敪9</summary>
        public const string ctMoneyKindDiv9 = "MoneyKindDiv9";
        /// <summary>�������z9</summary>
        public const string ctDeposit9 = "Deposit9";
        /// <summary>�L������9</summary>
        public const string ctValidityTerm9 = "ValidityTerm9";
        /// <summary>�����s�ԍ�10</summary>
        public const string ctDepositRowNo10 = "DepositRowNo10";
        /// <summary>����R�[�h10</summary>
        public const string ctMoneyKindCode10 = "MoneyKindCode10";
        /// <summary>���햼��10</summary>
        public const string ctMoneyKindName10 = "MoneyKindName10";
        /// <summary>����敪10</summary>
        public const string ctMoneyKindDiv10 = "MoneyKindDiv10";
        /// <summary>�������z10</summary>
        public const string ctDeposit10 = "Deposit10";
        /// <summary>�L������10</summary>
        public const string ctValidityTerm10 = "ValidityTerm10";
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        // ADD 2010/03/25 MANTIS[15196]�F�����ꗗ��ʂɢ���͒S���ң��\���֕ύX ---------->>>>>
        /// <summary>�������͎Җ���</summary>
        public const string ctDepositInputAgentNm = "DepositAgentNm";
        // ADD 2010/03/25 MANTIS[15196]�F�����ꗗ��ʂɢ���͒S���ң��\���֕ύX ----------<<<<<

        //----- ADD 2012/09/21 �c���� redmine#32415 ---------->>>>>
        /// <summary>���s�҃R�[�h</summary>
        public const string ctDepositInputEmpCd = "ctDepositInputEmpCd";
        /// <summary>���s�Җ�</summary>
        public const string ctDepositInputEmpNm = "ctDepositInputEmpNm";
        //----- ADD 2012/09/21 �c���� redmine#32415 ----------<<<<<

		/// <summary>���g��DataRow</summary>
		public const string ctDepositDataRow = "DepositDataRow";

		//***************************************************************
		// �������DataSet�p�萔�錾(�������)
		//***************************************************************
		/// <summary>�������Table����</summary>
		public const string ctAllowanceDataTable = "AllowanceTable";

		/// <summary>�����`�[�ԍ�</summary>
		public const string ctDepositSlipNo_Alw = "DepositSlipNo";

        ///// <summary>�󒍓`�[�ԍ�</summary>
        //public const string ctAcceptAnOrderNo_Alw = "AcceptAnOrderNo";     // 2007.10.05 del

        /// <summary>�󒍃X�e�[�^�X</summary>
        public const string ctAcptAnOdrStatus_Alw = "AcptAnOdrStatus";       // 2007.10.05 add

        /// <summary>����`�[�ԍ�</summary>
        public const string ctSalesSlipNum_Alw = "SalesSlipNum";             // 2007.10.05 add

        // �� 20070118 18322 d MA.NS�p�ɕύX
        #region SF ���������z �󒍁E����p�i�S�ăR�����g�A�E�g�j
        ///// <summary>���������z ��</summary>
		//public const string ctAcpOdrDepositAlwc = "AcpOdrDepositAlwc";
		//
		///// <summary>���������z ����p</summary>
        //public const string ctVarCostDepoAlwc = "VarCostDepoAlwc";
        #endregion
        // �� 20070118 18322 d

		/// <summary>���������z ����</summary>
		public const string ctDepositAllowance = "DepositAllowance";

		/// <summary>������(�\���p)</summary>
		public const string ctReconcileDateDisp = "ReconcileDateDisp";

		/// <summary>������</summary>
		public const string ctReconcileDate = "ReconcileDate";

		/// <summary>�����v����t</summary>
		public const string ctReconcileAddUpDate = "ReconcileAddUpDate";
		
		//***************************************************************
		// ����������DataSet�p�萔�錾
		//***************************************************************
		/// <summary>����������Table����</summary>
		public const string ctDmdSalesDataTable = "DmdSalesTable";

		/// <summary>��</summary>
		public const string ctAlwCheck = "AlwCheck";

		/// <summary>��������ԍ��敪</summary>
		public const string ctDmdSalesDebitNoteCd = "DmdSalesDebitNoteCd";

		/// <summary>��������ԍ�����</summary>
		public const string ctDmdSalesDebitNoteNm = "DmdSalesDebitNoteNm";

        ///// <summary>�󒍔ԍ�</summary>
        //public const string ctAcceptAnOrderNo = "AcceptAnOrderNo";�@�@// 2007.10.05 del

        // �� 20070122 18322 c MA.NS�p�ɕύX
		///// <summary>�`�[�ԍ�</summary>
		//public const string ctSlipNo = "SlipNo";

        /// <summary>����`�[�ԍ�</summary>
        public const string ctSalesSlipNum = "SalesSlipNum";
        // �� 20070122 18322 c

		/// <summary>�`�[���t(�\���p)</summary>
		public const string ctSearchSlipDateDisp = "SearchSlipDateDisp";

		/// <summary>�`�[���t</summary>
		public const string ctSearchSlipDate = "SearchSlipDate";

		/// <summary>�v����t</summary>
		public const string ctAddUpADate = "AddUpADate";

		/// <summary>�󒍃X�e�[�^�X</summary>
		public const string ctAcptAnOdrStatus = "AcptAnOdrStatus";

        // �� 20070129 18322 a MA.NS�p�ɕύX
		/// <summary>�󒍃X�e�[�^�X��</summary>
		public const string ctAcptAnOdrStatusNm = "AcptAnOdrStatusNm";
        // �� 20070129 18322 a

		/// <summary>�`�[���</summary>
		public const string ctSalesKind = "SalesKind";

        // ---ADD 2011/07/22 -------->>>>>>>
        /// <summary>�`�[���l</summary>
        public const string ctSlipNote = "SlipNote";

        /// <summary>�ŏI���������X�V��(�\���p)</summary>
        public const string ctLastMonthlyDateDisp = "LastMonthlyDateDisp";

        /// <summary>�ŏI�����X�V��</summary>
        public const string ctLastMonthlyDate = "LastMonthlyDate";

        // ---ADD 2011/07/22 -------- <<<<<<

		/// <summary>���㖼��</summary>
		public const string ctSalesName = "SalesName";

        // �� 20070122 18322 d MA.NS�p�ɕύX.
        #region SF �ԗ��o�^�ԍ��E�󒍔���z�E����p�z�i�S�ăR�����g�A�E�g�j
        ///// <summary>�ԗ��o�^�ԍ�</summary>
		//public const string ctNumberPlate = "NumberPlate";
        //
		///// <summary>�󒍔���z</summary>
		//public const string ctAcceptAnOrderSales = "AcceptAnOrderSales";
        //
        ///// <summary>����p�z</summary>
        //public const string ctTotalVariousCost = "TotalVariousCost";
        #endregion
        // �� 20070122 18322 d

		/// <summary>�`�[���v(�ō�)</summary>
		public const string ctTotalSales = "TotalSales";

        // �� 20070118 18322 d MA.NS�p�ɕύX
        #region SF �����z�E�����c�E������ �󒍁E����p�i�S�ăR�����g�A�E�g�j
        ///// <summary>�����z �� (���������}�X�^)</summary>
		//public const string ctAcpOdrDepositAlwc_Alw = "AcpOdrDepositAlwc_Alw";
        //
		///// <summary>�����c �� (��������}�X�^)</summary>
		//public const string ctAcpOdrDepoAlwcBlnce_Sales = "AcpOdrDepoAlwcBlnce_Sales";
        //
		///// <summary>������ �� (��������}�X�^)</summary>
		//public const string ctAcpOdrDepositAlwc_Sales = "AcpOdrDepositAlwc_Sales";
        //
		///// <summary>�����z ����p (���������}�X�^)</summary>
		//public const string ctVarCostDepoAlwc_Alw = "VarCostDepoAlwc_Alw";
        //
		///// <summary>�����c ����p (��������}�X�^)</summary>
		//public const string ctVarCostDepoAlwcBlnce_Sales = "VarCostDepoAlwcBlnce_Sales";
        //
		///// <summary>������ ����p (��������}�X�^)</summary>
        //public const string ctVarCostDepoAlwc_Sales = "VarCostDepoAlwc_Sales";
        #endregion
        // �� 20070118 18322 d

		/// <summary>�����z ���� (���������}�X�^)</summary>
		public const string ctDepositAllowance_Alw = "DepositAllowance_Alw";

		/// <summary>�����c ���� (��������}�X�^)</summary>
		public const string ctDepositAlwcBlnce_Sales = "DepositAlwcBlnce_Sales";

		/// <summary>������ ���� (��������}�X�^)</summary>
		public const string ctDepositAllowance_Sales = "DepositAllowance_Sales";

		/// <summary>��������</summary>
		public const string ctDepositAlwBtn = "DepositAlwBtn";

		/// <summary>���ߏ��</summary>
		public const string ctSalesClosedFlg = "ClosedFlg";

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>�ύX�O�����c(��������}�X�^)</summary>
        public const string ctBfDepositAlwcBlnce_Sales = "BfDepositAlwcBlnce_Sales";

        /// <summary>�ύX�O������(��������}�X�^)</summary>
        public const string ctBfDepositAllowance_Sales = "BfDepositAllowance_Sales";
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        // 2007.10.05 add start ------------------------------------>>
        /// <summary>������R�[�h</summary>
        public const string ctClaimCode = "ClaimCode";
        /// <summary>�����於��</summary>
        public const string ctClaimName = "ClaimName";
        /// <summary>�����於��2</summary>
        public const string ctClaimName2 = "ClaimName2";
        /// <summary>�����旪��</summary>
        public const string ctClaimSnm = "ClaimSnm";
        // 2007.10.05 add end --------------------------------------<<

        // �� 20070131 18322 a MA.NS�p�ɕύX
		/// <summary>���Ӑ�R�[�h</summary>
		public const string ctCustomerCode = "CustomerCode";
		/// <summary>���Ӑ於��</summary>
		public const string ctCustomerName = "CustomerName";
		/// <summary>���Ӑ於��2</summary>
		public const string ctCustomerName2 = "CustomerName2";
        // �� 20070131 18322 a

        /// <summary>���Ӑ旪��</summary>
        public const string ctCustomerSnm = "CustomerSnm";  // 2007.10.05 add

        // �� 20070525 18322 a
		/// <summary>���|�敪(0:���|�Ȃ�,1:���|)</summary>
        public const string ctAccRecDivCd = "AccRecDivCd";
        // 2007.10.05 hikita del start ------------------------------------>>
        ///// <summary>���W������</summary>
        //public const string ctRegiProcDate = "RegiProcDate";
        ///// <summary>���W�ԍ�</summary>
        //public const string ctCashRegisterNo = "CashRegisterNo";
        ///// <summary>POS���V�[�g�ԍ�</summary>
        //public const string ctPosReceiptNo = "PosReceiptNo";
        // 2007.10.05 hikita del end --------------------------------------<<
        // �� 20070525 18322 a
        
		/// <summary>���g��DataRow</summary>
		public const string ctSalesDataRow = "SalesDataRow";

		//***************************************************************
		// �����[�V�������
		//***************************************************************
		/// <summary>�������--������񃊃��[�V��������</summary>
		public const string ctRelation_DepositAllowance = "Relation_DepositAllowance";
		# endregion

		# region public property
		# endregion

		# region public Methods
		/// <summary>
		/// �������͉��(�����^)�A�N�Z�X�N���X ����������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : �A�N�Z�X�N���X�����������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void Initialize()
		{
		}

		/// <summary>
		/// �������DataSet����������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : DataSet�����������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void ClearDsDepositInfo()
		{
			// DataSet������
			this._dsDepositInfo.Clear();

			// �����}�X�^�N���X
			this._depsitMain.Clear();

			// ���������}�X�^�N���X(�����ԍ����x���ň��k)
            this._depositAlw.Clear();
		}

        // ----- ADD ���N 2012/12/24 Redmine#33741 ----->>>>>
        /// <summary>
        /// �������DataSet����������(����������ʗp)
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : DataSet�����������܂��B</br>
        /// <br>Programmer  : ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        public void ClearDsDepositInfoUE()
        {
            // DataSet������
            int i = this._dsDepositInfo.Tables.Count;
            for (int k = 0; k < i; k++)
            {
                if (this._dsDepositInfo.Tables[k].TableName != "DepositGuidTable" && this._dsDepositInfo.Tables[k].TableName != "DepositTable")
                {
                    this._dsDepositInfo.Tables[k].Clear();
                }
            }

            this._dsDepositInfo.Tables[ctDepositDataTable].Clear();
            // �����}�X�^�N���X
            this._depsitMain.Clear();
            // ���������}�X�^�N���X(�����ԍ����x���ň��k)
            this._depositAlw.Clear();
        }

        /// <summary>
        /// �������DataSet����������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : DataSet�����������܂��B</br>
        /// <br>Programmer  : ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        public void ClearDsGuidDepositInfo()
        {
            // DataSet������
            this._dsDepositInfo.Tables[ctDepositGuidDataTable].Clear();

            // �����}�X�^�N���X
            this._depsitMain.Clear();

            // ���������}�X�^�N���X(�����ԍ����x���ň��k)
            this._depositAlw.Clear();
        }
        // ----- ADD ���N 2012/12/24 Redmine#33741 -----<<<<<

		/// <summary>
		/// ����������DataSet����������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : DataSet�����������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void ClearDmdSalesInfo()
		{
			// DataSet������
			this._dsDmdSalesInfo.Clear();

			// ��������}�X�^�N���X(���񌟍���)
			this._dmdSales.Clear();

			// ��������}�X�^�N���X(���񌟍��œǂݍ���łȂ���)
			this._dmdSalesSecond.Clear();
		}
		
		/// <summary>
		/// �������Ӑ���N���X����������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : �������Ӑ���N���X�����������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void ClearDepositCustomer()
		{
			this._depositCustomer = new DepositCustomer();
		}

		/// <summary>
		/// �������Ӑ搿�����z���N���X����������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : �������Ӑ搿�����z���N���X�����������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void ClearDepositCustDmdPrc()
		{
			this._depositCustDmdPrc = new DepositCustDmdPrc();
		}
		
		/// <summary>
		/// �������DataSet�擾����
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : DataSet���擾���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public DataSet GetDsDepositInfo()
		{
			return this._dsDepositInfo;
		}

		/// <summary>
		/// ����������DataSet�擾����
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : DataSet���擾���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public DataSet GetDsDmdSalesInfo()
		{
			return this._dsDmdSalesInfo;
		}
		
		/// <summary>
		/// �������Ӑ���N���X�擾����
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : �������Ӑ���N���X���擾���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public DepositCustomer GetDepositCustomer()
		{
			return this._depositCustomer;
		}

		/// <summary>
		/// �������Ӑ搿�����z���N���X�擾����
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : �������Ӑ搿�����z���N���X���擾���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public DepositCustDmdPrc GetDepositCustDmdPrc()
		{
			return this._depositCustDmdPrc;
		}
		
		/// <summary>
		/// �ŏI�������ߓ��擾����
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : �ŏI�������ߓ��擾���擾���܂��B</br>
		/// <br>Programmer  : 18322 T.Kimura</br>
		/// <br>Date        : 2007.08.01</br>
		/// </remarks>
		public int GetLastMonthlyDate()
		{
            int result = 0;

            //if (this._lastMonthlyAddUpHis != null)
            //{
            //    result = TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpHis.MonthlyAddUpDate);
            //}

            if (this._lastMonthlyAddUpDay != null)
            {
                result = TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpDay);
            }

            return result;
        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ������� DataSet Table �쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �������f�[�^�Z�b�g�̃e�[�u�����쐬���܂��B
		///	               :   �� Method : GetDsDepositInfo ��茋�ʎ擾</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public void CreateDepositDataTable()
		{
            // �� 20070131 18322 c MA.NS�p�ɕύX
            #region SF ������� ��ݒ�i�S�ăR�����g�A�E�g�j
			//// �f�[�^�e�[�u���̗��`
			//DataTable dtDepositTable = new DataTable(ctDepositDataTable);
            //
			//dtDepositTable.Columns.Add(ctDepositDebitNoteCd, typeof(int));				// �����ԍ��敪
			//dtDepositTable.Columns.Add(ctDepositDebitNoteNm, typeof(string));			// �����ԍ�����
			//dtDepositTable.Columns.Add(ctDepositSlipNo, typeof(int));					// �����`�[�ԍ�
			//dtDepositTable.Columns.Add(ctDebitNoteLinkDepoNo, typeof(int));				// �ԍ������A���ԍ�
			//dtDepositTable.Columns.Add(ctDepositDateDisp, typeof(string));				// �������t(�\���p)
			//dtDepositTable.Columns.Add(ctDepositDate, typeof(int));						// �������t
			//dtDepositTable.Columns.Add(ctDepositAddUpADate, typeof(int));				// �v����t
			//dtDepositTable.Columns.Add(ctAutoDepositCd, typeof(int));					// ���������敪
			//dtDepositTable.Columns.Add(ctDepositCd, typeof(int));						// �a����敪�R�[�h
			//dtDepositTable.Columns.Add(ctDepositNm, typeof(string));					// �a����敪����
			//dtDepositTable.Columns.Add(ctDepositKindDivCd, typeof(int));				// ��������敪
			//dtDepositTable.Columns.Add(ctDepositKindCode, typeof(int));					// ��������R�[�h
			//dtDepositTable.Columns.Add(ctDepositKindName, typeof(string));				// �������햼��
			//dtDepositTable.Columns.Add(ctAcpOdrDeposit, typeof(Int64));					// �� �����z
			//dtDepositTable.Columns.Add(ctAcpOdrChargeDeposit, typeof(Int64));			// �� �萔��
			//dtDepositTable.Columns.Add(ctAcpOdrDisDeposit, typeof(Int64));				// �� �l��
			//dtDepositTable.Columns.Add(ctAcpOdrDepositTotal, typeof(Int64));			// �� �����v
			//dtDepositTable.Columns.Add(ctVariousCostDeposit, typeof(Int64));			// ����p �����z
			//dtDepositTable.Columns.Add(ctVarCostChargeDeposit, typeof(Int64));			// ����p �萔��
			//dtDepositTable.Columns.Add(ctVarCostDisDeposit, typeof(Int64));				// ����p �l��
			//dtDepositTable.Columns.Add(ctVariousCostDepositTotal, typeof(Int64));		// ����p �����v
			//dtDepositTable.Columns.Add(ctDeposit, typeof(Int64));						// ���� �����z
			//dtDepositTable.Columns.Add(ctFeeDeposit, typeof(Int64));					// ���� �萔��
			//dtDepositTable.Columns.Add(ctDiscountDeposit, typeof(Int64));				// ���� �l��
			//dtDepositTable.Columns.Add(ctDepositTotal, typeof(Int64));					// ���� �����v
			//dtDepositTable.Columns.Add(ctAcpOdrDepositAlwc_Deposit, typeof(Int64));		// ���������z ��
			//dtDepositTable.Columns.Add(ctAcpOdrDepoAlwcBlnce_Deposit, typeof(Int64));	// ���������c ��
			//dtDepositTable.Columns.Add(ctVarCostDepoAlwc_Deposit, typeof(Int64));		// ���������z ����p
			//dtDepositTable.Columns.Add(ctVarCostDepoAlwcBlnce_Deposit, typeof(Int64));	// ���������c ����p
			//dtDepositTable.Columns.Add(ctDepositAllowance_Deposit, typeof(Int64));		// ���������z ����
			//dtDepositTable.Columns.Add(ctDepositAlwcBlnce_Deposit, typeof(Int64));		// ���������c ����
			//dtDepositTable.Columns.Add(ctCreditOrLoanCd, typeof(int));					// �N���W�b�g/���[���敪
			//dtDepositTable.Columns.Add(ctCreditCompanyCode, typeof(string));			// �N���W�b�g��ЃR�[�h
			//dtDepositTable.Columns.Add(ctDraftDrawingDate, typeof(int));				// ��`�U�o��
			//dtDepositTable.Columns.Add(ctDraftPayTimeLimit, typeof(int));				// ��`�x������
			//dtDepositTable.Columns.Add(ctOutline, typeof(string));						// �E�v
			//dtDepositTable.Columns.Add(ctDepositClosedFlg, typeof(string));				// ���t���O
			//dtDepositTable.Columns.Add(ctDepositDataRow, typeof(DataRow));				// ���g��DataRow
			//
			//// �f�[�^�Z�b�g�ɒǉ�
			//_dsDepositInfo.Tables.Add(dtDepositTable.Clone());
			//
			//
			//// �f�[�^�e�[�u���̗��`
			//DataTable dtAllowanceTable = new DataTable(ctAllowanceDataTable);
			//
			//// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			//dtAllowanceTable.Columns.Add(ctDepositSlipNo_Alw, typeof(int));				// �����`�[�ԍ�
			//dtAllowanceTable.Columns.Add(ctAcceptAnOrderNo_Alw, typeof(int));			// �󒍓`�[�ԍ�
			//dtAllowanceTable.Columns.Add(ctAcpOdrDepositAlwc, typeof(Int64));			// ���������z ��
			//dtAllowanceTable.Columns.Add(ctVarCostDepoAlwc, typeof(Int64));				// ���������z ����p
			//dtAllowanceTable.Columns.Add(ctDepositAllowance, typeof(Int64));			// ���������z ����
			//dtAllowanceTable.Columns.Add(ctReconcileDateDisp, typeof(string));			// ������(�\���p)
			//dtAllowanceTable.Columns.Add(ctReconcileDate, typeof(int));					// ������
			//dtAllowanceTable.Columns.Add(ctReconcileAddUpDate, typeof(int));			// �����v����t
			//
			//// �f�[�^�Z�b�g�ɒǉ�
			//_dsDepositInfo.Tables.Add(dtAllowanceTable.Clone());
            #endregion

            //---------------------------------
            // �����e�[�u��
            //---------------------------------
            // �f�[�^�e�[�u���̗��`
			DataTable dtDepositTable = new DataTable(ctDepositDataTable);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			dtDepositTable.Columns.Add(ctDepositDebitNoteCd, typeof(int));				// �����ԍ��敪
			dtDepositTable.Columns.Add(ctDepositDebitNoteNm, typeof(string));			// �����ԍ�����
			dtDepositTable.Columns.Add(ctDepositSlipNo, typeof(int));					// �����`�[�ԍ�
			//dtDepositTable.Columns.Add(ctAcceptAnOrderNo, typeof(int));	        	// �󒍓`�[�ԍ�         // 2007.10.05 del
            dtDepositTable.Columns.Add(ctSalesSlipNum, typeof(string));	        		// ����`�[�ԍ�         // 2007.10.05 add
			dtDepositTable.Columns.Add(ctDebitNoteLinkDepoNo, typeof(int));				// �ԍ������A���ԍ�
			dtDepositTable.Columns.Add(ctDepositDateDisp, typeof(string));				// �������t(�\���p)
			dtDepositTable.Columns.Add(ctDepositDate, typeof(int));						// �������t
			dtDepositTable.Columns.Add(ctDepositAddUpADate, typeof(int));				// �v����t
            dtDepositTable.Columns.Add(ctDepositAddUpADateDisp, typeof(string));		// �v����t(�\���p)     // 2007.10.05 add
            dtDepositTable.Columns.Add(ctDepositAcptAnOdrStatus, typeof(int));			// �󒍃X�e�[�^�X       // 2007.10.05 add
            dtDepositTable.Columns.Add(ctAutoDepositCd, typeof(int));					// ���������敪

            dtDepositTable.Columns.Add(ctDepositCd, typeof(int));						// �a����敪�R�[�h
			dtDepositTable.Columns.Add(ctDepositNm, typeof(string));					// �a����敪����
            dtDepositTable.Columns.Add(ctDepositKindDivCd, typeof(int));				// ��������敪
            dtDepositTable.Columns.Add(ctDepositKindCode, typeof(int));					// ��������R�[�h
            
            dtDepositTable.Columns.Add(ctDepositKindName, typeof(string));				// �������햼��
			dtDepositTable.Columns.Add(ctDeposit, typeof(Int64));						// ���� �����z
			dtDepositTable.Columns.Add(ctFeeDeposit, typeof(Int64));					// ���� �萔��
			dtDepositTable.Columns.Add(ctDiscountDeposit, typeof(Int64));				// ���� �l��
			// dtDepositTable.Columns.Add(ctRebateDeposit, typeof(Int64));                 // ���� �C���Z���e�B�u     // 2007.10.05 del
			dtDepositTable.Columns.Add(ctDepositTotal, typeof(Int64));					// ���� �����v
			dtDepositTable.Columns.Add(ctDepositAllowance_Deposit, typeof(Int64));		// ���������z ����
			dtDepositTable.Columns.Add(ctDepositAlwcBlnce_Deposit, typeof(Int64));		// ���������c ����
            // dtDepositTable.Columns.Add(ctCreditOrLoanCd, typeof(int));					// �N���W�b�g/���[���敪  // 2007.10.05 del
            // dtDepositTable.Columns.Add(ctCreditCompanyCode, typeof(string));			// �N���W�b�g��ЃR�[�h       // 2007.10.05 del
			dtDepositTable.Columns.Add(ctDraftDrawingDate, typeof(int));				// ��`�U�o��

			dtDepositTable.Columns.Add(ctDraftPayTimeLimit, typeof(int));				// ��`�x������

            // 2007.10.05 hikita add start -------------------------------------------------------------------->>
            dtDepositTable.Columns.Add(ctBankCode, typeof(int));                        // ��s�R�[�h
            dtDepositTable.Columns.Add(ctBankName, typeof(string));                     // ��s����
            dtDepositTable.Columns.Add(ctDraftNo, typeof(string));                      // ��`�ԍ�
            dtDepositTable.Columns.Add(ctDraftKind, typeof(int));                       // ��`��ރR�[�h 
            dtDepositTable.Columns.Add(ctDraftKindName, typeof(string));                // ��`��ޖ���
            dtDepositTable.Columns.Add(ctDraftDivide, typeof(int));                     // ��`�敪�R�[�h 
            dtDepositTable.Columns.Add(ctDraftDivideName, typeof(string));              // ��`�敪����
            // 2007.10.05 hikita add end ----------------------------------------------------------------------<<
			dtDepositTable.Columns.Add(ctOutline, typeof(string));						// �E�v
			dtDepositTable.Columns.Add(ctDepositClosedFlg, typeof(string));				// ���t���O
            dtDepositTable.Columns.Add(ctDepositDataRow, typeof(DataRow));				// ���g��DataRow

			// �f�[�^�Z�b�g�ɒǉ�
			_dsDepositInfo.Tables.Add(dtDepositTable.Clone());

            //---------------------------------
            // ���������e�[�u��
            //---------------------------------
			// �f�[�^�e�[�u���̗��`
			DataTable dtAllowanceTable = new DataTable(ctAllowanceDataTable);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			dtAllowanceTable.Columns.Add(ctDepositSlipNo_Alw, typeof(int));				// �����`�[�ԍ�
			// dtAllowanceTable.Columns.Add(ctAcceptAnOrderNo_Alw, typeof(int));		// �󒍓`�[�ԍ�    // 2007.10.05 del
            dtAllowanceTable.Columns.Add(ctAcptAnOdrStatus_Alw, typeof(int));			// �󒍃X�e�[�^�X  // 2007.10.05 add
            dtAllowanceTable.Columns.Add(ctSalesSlipNum,typeof(string));                // ����`�[�ԍ�
			dtAllowanceTable.Columns.Add(ctDepositAllowance, typeof(Int64));			// ���������z ����
			dtAllowanceTable.Columns.Add(ctReconcileDateDisp, typeof(string));			// ������(�\���p)
			dtAllowanceTable.Columns.Add(ctReconcileDate, typeof(int));					// ������
			dtAllowanceTable.Columns.Add(ctReconcileAddUpDate, typeof(int));			// �����v����t

			// �f�[�^�Z�b�g�ɒǉ�
			_dsDepositInfo.Tables.Add(dtAllowanceTable.Clone());
            // �� 20070131 18322 c

			// �����[�V�����ݒ�
			DataRelation re = new DataRelation(ctRelation_DepositAllowance, _dsDepositInfo.Tables[ctDepositDataTable].Columns[ctDepositSlipNo], _dsDepositInfo.Tables[ctAllowanceDataTable].Columns[ctDepositSlipNo_Alw]);
			_dsDepositInfo.Relations.Add(re);
		}

		/// <summary>
		/// ���������� DataSet Table �쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����������f�[�^�Z�b�g�̃e�[�u�����쐬���܂��B
		///	               :   �� Method : GetDsDepositInfo ��茋�ʎ擾</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public void CreateDmdSalesDataTable()
		{
			// �f�[�^�e�[�u���̗��`
			DataTable dtDmdSalesTable = new DataTable(ctDmdSalesDataTable);

            // �� 20070131 18322 c MA.NS�p�ɕύX
            #region SF ���������� ��ݒ�i�S�ăR�����g�A�E�g�j
			//// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			//dtDmdSalesTable.Columns.Add(ctAlwCheck, typeof(bool));						// ��
			//dtDmdSalesTable.Columns.Add(ctAcpOdrDepositAlwc_Alw, typeof(Int64));		// �����z �� (���������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctAcpOdrDepoAlwcBlnce_Sales, typeof(Int64));	// �����c �� (��������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctAcpOdrDepositAlwc_Sales, typeof(Int64));		// ������ �� (��������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctVarCostDepoAlwc_Alw, typeof(Int64));			// �����z ����p (���������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctVarCostDepoAlwcBlnce_Sales, typeof(Int64));	// �����c ����p (��������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctVarCostDepoAlwc_Sales, typeof(Int64));		// ������ ����p (��������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctDepositAllowance_Alw, typeof(Int64));			// �����z ���� (���������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctDepositAlwcBlnce_Sales, typeof(Int64));		// �����c ���� (��������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctDepositAllowance_Sales, typeof(Int64));		// ������ ���� (��������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctDmdSalesDebitNoteCd, typeof(int));			// ��������ԍ��敪
			//dtDmdSalesTable.Columns.Add(ctDmdSalesDebitNoteNm, typeof(string));			// ��������ԍ�����
			//dtDmdSalesTable.Columns.Add(ctSlipNo, typeof(string));						// �`�[�ԍ�
			//dtDmdSalesTable.Columns.Add(ctAcceptAnOrderNo, typeof(int));				// �󒍔ԍ�
			//dtDmdSalesTable.Columns.Add(ctSearchSlipDateDisp, typeof(string));			// �`�[���t(�\���p)
			//dtDmdSalesTable.Columns.Add(ctSearchSlipDate, typeof(int));					// �`�[���t
			//dtDmdSalesTable.Columns.Add(ctAddUpADate, typeof(int));						// �����
			//dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatus, typeof(int));				// �`�[�X�e�[�^�X
			//dtDmdSalesTable.Columns.Add(ctSalesKind, typeof(string));					// �`�[���
			//dtDmdSalesTable.Columns.Add(ctSalesName, typeof(string));					// ���㖼��
			//dtDmdSalesTable.Columns.Add(ctNumberPlate, typeof(string));					// �o�^�ԍ�
			//dtDmdSalesTable.Columns.Add(ctAcceptAnOrderSales, typeof(Int64));			// �󒍔���z
			//dtDmdSalesTable.Columns.Add(ctTotalVariousCost, typeof(Int64));				// ����p�z
			//dtDmdSalesTable.Columns.Add(ctTotalSales, typeof(Int64));					// �󒍍��v�z
			//dtDmdSalesTable.Columns.Add(ctSalesClosedFlg, typeof(string));				// ���t���O
			//dtDmdSalesTable.Columns.Add(ctDepositAlwBtn, typeof(string));				// ���������{�^��
			//dtDmdSalesTable.Columns.Add(ctSalesDataRow, typeof(DataRow));				// ���g��DataRow
            #endregion

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			dtDmdSalesTable.Columns.Add(ctAlwCheck, typeof(bool));						// ��
			dtDmdSalesTable.Columns.Add(ctDepositAllowance_Alw, typeof(Int64));			// �����z ���� (���������}�X�^)
			dtDmdSalesTable.Columns.Add(ctDepositAlwcBlnce_Sales, typeof(Int64));		// �����c ���� (��������}�X�^)
			dtDmdSalesTable.Columns.Add(ctDepositAllowance_Sales, typeof(Int64));		// ������ ���� (��������}�X�^)
			dtDmdSalesTable.Columns.Add(ctDmdSalesDebitNoteCd, typeof(int));			// ��������ԍ��敪
			dtDmdSalesTable.Columns.Add(ctDmdSalesDebitNoteNm, typeof(string));			// ��������ԍ�����
			// dtDmdSalesTable.Columns.Add(ctAcceptAnOrderNo, typeof(int));				// �󒍔ԍ�             // 2007.10.05 hikita del
            dtDmdSalesTable.Columns.Add(ctSalesSlipNum, typeof(string));                // ����`�[�ԍ�
			dtDmdSalesTable.Columns.Add(ctSearchSlipDateDisp, typeof(string));			// �`�[���t(�\���p)
			dtDmdSalesTable.Columns.Add(ctSearchSlipDate, typeof(int));					// �`�[���t
			dtDmdSalesTable.Columns.Add(ctAddUpADate, typeof(int));						// �����
   			dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatus, typeof(int));				// �󒍃X�e�[�^�X
            dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatusNm, typeof(string));           // �󒍃X�e�[�^�X��
   			dtDmdSalesTable.Columns.Add(ctSalesKind, typeof(string));					// �`�[���
			dtDmdSalesTable.Columns.Add(ctSalesName, typeof(string));					// ���㖼��
			dtDmdSalesTable.Columns.Add(ctTotalSales, typeof(Int64));					// �`�[���v(�ō�)
			dtDmdSalesTable.Columns.Add(ctSalesClosedFlg, typeof(string));				// ���t���O
			dtDmdSalesTable.Columns.Add(ctDepositAlwBtn, typeof(string));				// ���������{�^��
            dtDmdSalesTable.Columns.Add(ctClaimCode, typeof(int));				        // ������R�[�h
            dtDmdSalesTable.Columns.Add(ctClaimName, typeof(string));				    // �����於��
            dtDmdSalesTable.Columns.Add(ctClaimName2, typeof(string));				    // �����於��2
            dtDmdSalesTable.Columns.Add(ctClaimSnm, typeof(string));				    // �����旪��
			dtDmdSalesTable.Columns.Add(ctCustomerCode , typeof(int));				    // ���Ӑ�R�[�h
            dtDmdSalesTable.Columns.Add(ctCustomerName , typeof(string));				// ���Ӑ於��
			dtDmdSalesTable.Columns.Add(ctCustomerName2, typeof(string));				// ���Ӑ於��2
            dtDmdSalesTable.Columns.Add(ctCustomerSnm, typeof(string));				    // ���Ӑ旪��

            // �� 20070525 18322 a
            dtDmdSalesTable.Columns.Add(ctAccRecDivCd   , typeof(int));				// �|���敪
            // 2007.10.05 hikita del start -------------------------------------------------------------->>
            // dtDmdSalesTable.Columns.Add(ctRegiProcDate  , typeof(string));  	    // ���W������
            // dtDmdSalesTable.Columns.Add(ctCashRegisterNo, typeof(int));				// ���W�ԍ�
            // dtDmdSalesTable.Columns.Add(ctPosReceiptNo  , typeof(int));				// POS���V�[�g�ԍ�
            // 2007.10.05 hikita del end ----------------------------------------------------------------<<
            // �� 20070525 18322 a
           
            dtDmdSalesTable.Columns.Add(ctSalesDataRow, typeof(DataRow));				// ���g��DataRow
            // �� 20070131 18322 c
			
			// �f�[�^�Z�b�g�ɒǉ�
			_dsDmdSalesInfo.Tables.Add(dtDmdSalesTable.Clone());
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        /// <summary>
        /// ������� DataSet Table �쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������f�[�^�Z�b�g�̃e�[�u�����쐬���܂��B
        ///	               :   �� Method : GetDsDepositInfo ��茋�ʎ擾</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// <br>Update Note: 2012/09/21 �c����</br>
        /// <br>�Ǘ��ԍ�   : 2012/10/17�z�M��</br>
        /// <br>             Redmine#32415 ���s�҂̒ǉ��Ή�</br>
        /// <br>Update Note: 2012/12/24 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// </remarks>
        public void CreateDepositDataTable()
        {
            //---------------------------------
            // �����e�[�u��
            //---------------------------------
            // �f�[�^�e�[�u���̗��`
            DataTable dtDepositTable = new DataTable(ctDepositDataTable);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            dtDepositTable.Columns.Add(ctDepositDebitNoteCd, typeof(Int32));			// �����ԍ��敪
            dtDepositTable.Columns.Add(ctDepositDebitNoteNm, typeof(string));			// �����ԍ�����
            dtDepositTable.Columns.Add(ctDepositSlipNo, typeof(Int32));					// �����`�[�ԍ�
            dtDepositTable.Columns.Add(ctSalesSlipNum, typeof(string));	        		// ����`�[�ԍ�
            dtDepositTable.Columns.Add(ctDebitNoteLinkDepoNo, typeof(Int32));			// �ԍ������A���ԍ�
            dtDepositTable.Columns.Add(ctDepositDateDisp, typeof(string));				// �������t(�\���p)
            dtDepositTable.Columns.Add(ctDepositDate, typeof(Int32));					// �������t
            dtDepositTable.Columns.Add(ctDepositAddUpADate, typeof(Int32));				// �v����t
            dtDepositTable.Columns.Add(ctDepositAddUpADateDisp, typeof(string));		// �v����t(�\���p)
            dtDepositTable.Columns.Add(ctDepositAcptAnOdrStatus, typeof(Int32));		// �󒍃X�e�[�^�X
            dtDepositTable.Columns.Add(ctAutoDepositCd, typeof(Int32));					// ���������敪
            dtDepositTable.Columns.Add(ctDepositNm, typeof(string));					// �a����敪����
            dtDepositTable.Columns.Add(ctDepositKindName, typeof(string));				// �������햼��(�\���p)
            dtDepositTable.Columns.Add(ctDeposit, typeof(Int64));						// ���� �����z
            dtDepositTable.Columns.Add(ctFeeDeposit, typeof(Int64));					// ���� �萔��
            dtDepositTable.Columns.Add(ctDiscountDeposit, typeof(Int64));				// ���� �l��
            dtDepositTable.Columns.Add(ctDepositTotal, typeof(Int64));					// ���� �����v
            dtDepositTable.Columns.Add(ctAllowDiv, typeof(string));					    // ����  // ADD 2010/12/20
            dtDepositTable.Columns.Add(ctDepositAllowance_Deposit, typeof(Int64));		// ���������z ����
            dtDepositTable.Columns.Add(ctDepositAlwcBlnce_Deposit, typeof(Int64));		// ���������c ����
            dtDepositTable.Columns.Add(ctDraftDrawingDate, typeof(Int32));				// ��`�U�o��
            dtDepositTable.Columns.Add(ctBankCode, typeof(Int32));                      // ��s�R�[�h
            dtDepositTable.Columns.Add(ctBankName, typeof(string));                     // ��s����
            dtDepositTable.Columns.Add(ctDraftNo, typeof(string));                      // ��`�ԍ�
            dtDepositTable.Columns.Add(ctDraftKind, typeof(Int32));                     // ��`��ރR�[�h 
            dtDepositTable.Columns.Add(ctDraftKindName, typeof(string));                // ��`��ޖ���
            dtDepositTable.Columns.Add(ctDraftDivide, typeof(Int32));                   // ��`�敪�R�[�h 
            dtDepositTable.Columns.Add(ctDraftDivideName, typeof(string));              // ��`�敪����
            dtDepositTable.Columns.Add(ctOutline, typeof(string));						// �E�v
            dtDepositTable.Columns.Add(ctDepositClosedFlg, typeof(string));				// ���t���O
            dtDepositTable.Columns.Add(ctDepositRowNo1, typeof(Int32));				    // �����s�ԍ�1
            dtDepositTable.Columns.Add(ctMoneyKindCode1, typeof(Int32));				// ����R�[�h1
            dtDepositTable.Columns.Add(ctMoneyKindName1, typeof(string));				// ���햼��1
            dtDepositTable.Columns.Add(ctMoneyKindDiv1, typeof(Int32));				    // ����敪1
            dtDepositTable.Columns.Add(ctDeposit1, typeof(Int64));				        // �������z1
            dtDepositTable.Columns.Add(ctValidityTerm1, typeof(DateTime));				// �L������1
            dtDepositTable.Columns.Add(ctDepositRowNo2, typeof(Int32));				    // �����s�ԍ�2
            dtDepositTable.Columns.Add(ctMoneyKindCode2, typeof(Int32));				// ����R�[�h2
            dtDepositTable.Columns.Add(ctMoneyKindName2, typeof(string));				// ���햼��2
            dtDepositTable.Columns.Add(ctMoneyKindDiv2, typeof(Int32));				    // ����敪2
            dtDepositTable.Columns.Add(ctDeposit2, typeof(Int64));				        // �������z2
            dtDepositTable.Columns.Add(ctValidityTerm2, typeof(DateTime));				// �L������2
            dtDepositTable.Columns.Add(ctDepositRowNo3, typeof(Int32));				    // �����s�ԍ�3
            dtDepositTable.Columns.Add(ctMoneyKindCode3, typeof(Int32));				// ����R�[�h3
            dtDepositTable.Columns.Add(ctMoneyKindName3, typeof(string));				// ���햼��3
            dtDepositTable.Columns.Add(ctMoneyKindDiv3, typeof(Int32));				    // ����敪3
            dtDepositTable.Columns.Add(ctDeposit3, typeof(Int64));				        // �������z3
            dtDepositTable.Columns.Add(ctValidityTerm3, typeof(DateTime));				// �L������3
            dtDepositTable.Columns.Add(ctDepositRowNo4, typeof(Int32));				    // �����s�ԍ�4
            dtDepositTable.Columns.Add(ctMoneyKindCode4, typeof(Int32));				// ����R�[�h4
            dtDepositTable.Columns.Add(ctMoneyKindName4, typeof(string));				// ���햼��4
            dtDepositTable.Columns.Add(ctMoneyKindDiv4, typeof(Int32));				    // ����敪4
            dtDepositTable.Columns.Add(ctDeposit4, typeof(Int64));				        // �������z4
            dtDepositTable.Columns.Add(ctValidityTerm4, typeof(DateTime));				// �L������4
            dtDepositTable.Columns.Add(ctDepositRowNo5, typeof(Int32));				    // �����s�ԍ�5
            dtDepositTable.Columns.Add(ctMoneyKindCode5, typeof(Int32));				// ����R�[�h5
            dtDepositTable.Columns.Add(ctMoneyKindName5, typeof(string));				// ���햼��5
            dtDepositTable.Columns.Add(ctMoneyKindDiv5, typeof(Int32));				    // ����敪5
            dtDepositTable.Columns.Add(ctDeposit5, typeof(Int64));				        // �������z5
            dtDepositTable.Columns.Add(ctValidityTerm5, typeof(DateTime));				// �L������5
            dtDepositTable.Columns.Add(ctDepositRowNo6, typeof(Int32));				    // �����s�ԍ�6
            dtDepositTable.Columns.Add(ctMoneyKindCode6, typeof(Int32));				// ����R�[�h6
            dtDepositTable.Columns.Add(ctMoneyKindName6, typeof(string));				// ���햼��6
            dtDepositTable.Columns.Add(ctMoneyKindDiv6, typeof(Int32));				    // ����敪6
            dtDepositTable.Columns.Add(ctDeposit6, typeof(Int64));				        // �������z6
            dtDepositTable.Columns.Add(ctValidityTerm6, typeof(DateTime));				// �L������6
            dtDepositTable.Columns.Add(ctDepositRowNo7, typeof(Int32));				    // �����s�ԍ�7
            dtDepositTable.Columns.Add(ctMoneyKindCode7, typeof(Int32));				// ����R�[�h7
            dtDepositTable.Columns.Add(ctMoneyKindName7, typeof(string));				// ���햼��7
            dtDepositTable.Columns.Add(ctMoneyKindDiv7, typeof(Int32));				    // ����敪7
            dtDepositTable.Columns.Add(ctDeposit7, typeof(Int64));				        // �������z7
            dtDepositTable.Columns.Add(ctValidityTerm7, typeof(DateTime));				// �L������7
            dtDepositTable.Columns.Add(ctDepositRowNo8, typeof(Int32));				    // �����s�ԍ�8
            dtDepositTable.Columns.Add(ctMoneyKindCode8, typeof(Int32));				// ����R�[�h8
            dtDepositTable.Columns.Add(ctMoneyKindName8, typeof(string));				// ���햼��8
            dtDepositTable.Columns.Add(ctMoneyKindDiv8, typeof(Int32));				    // ����敪8
            dtDepositTable.Columns.Add(ctDeposit8, typeof(Int64));				        // �������z8
            dtDepositTable.Columns.Add(ctValidityTerm8, typeof(DateTime));				// �L������8
            dtDepositTable.Columns.Add(ctDepositRowNo9, typeof(Int32));				    // �����s�ԍ�9
            dtDepositTable.Columns.Add(ctMoneyKindCode9, typeof(Int32));				// ����R�[�h9
            dtDepositTable.Columns.Add(ctMoneyKindName9, typeof(string));				// ���햼��9
            dtDepositTable.Columns.Add(ctMoneyKindDiv9, typeof(Int32));				    // ����敪9
            dtDepositTable.Columns.Add(ctDeposit9, typeof(Int64));				        // �������z9
            dtDepositTable.Columns.Add(ctValidityTerm9, typeof(DateTime));				// �L������9
            dtDepositTable.Columns.Add(ctDepositRowNo10, typeof(Int32));				// �����s�ԍ�10
            dtDepositTable.Columns.Add(ctMoneyKindCode10, typeof(Int32));				// ����R�[�h10
            dtDepositTable.Columns.Add(ctMoneyKindName10, typeof(string));				// ���햼��10
            dtDepositTable.Columns.Add(ctMoneyKindDiv10, typeof(Int32));				// ����敪10
            dtDepositTable.Columns.Add(ctDeposit10, typeof(Int64));				        // �������z10
            dtDepositTable.Columns.Add(ctValidityTerm10, typeof(DateTime));				// �L������10

            // ADD 2010/03/25 MANTIS[15196]�F�����ꗗ��ʂɢ���͒S���ң��\���֕ύX ---------->>>>>
            dtDepositTable.Columns.Add(ctDepositInputAgentNm, typeof(string));          // �������͎Җ���
            // ADD 2010/03/25 MANTIS[15196]�F�����ꗗ��ʂɢ���͒S���ң��\���֕ύX ----------<<<<<

            //----- ADD 2012/09/21 �c���� redmine#32415 ---------->>>>>
            dtDepositTable.Columns.Add(ctDepositInputEmpCd, typeof(string));          // ���s�҃R�[�h
            dtDepositTable.Columns.Add(ctDepositInputEmpNm, typeof(string));          // ���s�Җ�
            //----- ADD 2012/09/21 �c���� redmine#32415 ----------<<<<<
            // ---- ADD 2012/12/24 ���N Redmine#33741 ----------->>>>>
            dtDepositTable.Columns.Add(ctCustomerCode, typeof(Int32));   // ���Ӑ�R�[�h
            dtDepositTable.Columns.Add(ctCustomerName, typeof(string));  // ���Ӑ於��
            // ---- ADD 2012/12/24 ���N Redmine#33741 -----------<<<<<
            
            dtDepositTable.Columns.Add(ctDepositDataRow, typeof(DataRow));				// ���g��DataRow

            // �f�[�^�Z�b�g�ɒǉ�
            this._dsDepositInfo.Tables.Add(dtDepositTable.Clone());

            //---------------------------------
            // ���������e�[�u��
            //---------------------------------
            // �f�[�^�e�[�u���̗��`
            DataTable dtAllowanceTable = new DataTable(ctAllowanceDataTable);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            dtAllowanceTable.Columns.Add(ctDepositSlipNo_Alw, typeof(int));				// �����`�[�ԍ�
            dtAllowanceTable.Columns.Add(ctAcptAnOdrStatus_Alw, typeof(int));			// �󒍃X�e�[�^�X
            dtAllowanceTable.Columns.Add(ctSalesSlipNum, typeof(string));               // ����`�[�ԍ�
            dtAllowanceTable.Columns.Add(ctDepositAllowance, typeof(Int64));			// ���������z ����
            dtAllowanceTable.Columns.Add(ctReconcileDateDisp, typeof(string));			// ������(�\���p)
            dtAllowanceTable.Columns.Add(ctReconcileDate, typeof(int));					// ������
            dtAllowanceTable.Columns.Add(ctReconcileAddUpDate, typeof(int));			// �����v����t

            // �f�[�^�Z�b�g�ɒǉ�
            this._dsDepositInfo.Tables.Add(dtAllowanceTable.Clone());

            // �����[�V�����ݒ�
            DataRelation re = new DataRelation(ctRelation_DepositAllowance, this._dsDepositInfo.Tables[ctDepositDataTable].Columns[ctDepositSlipNo], this._dsDepositInfo.Tables[ctAllowanceDataTable].Columns[ctDepositSlipNo_Alw]);
            this._dsDepositInfo.Relations.Add(re);
        }

        /// <summary>
        /// ���������� DataSet Table �쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����������f�[�^�Z�b�g�̃e�[�u�����쐬���܂��B
        ///	               :   �� Method : GetDsDepositInfo ��茋�ʎ擾</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        public void CreateDmdSalesDataTable()
        {
            // �f�[�^�e�[�u���̗��`
            DataTable dtDmdSalesTable = new DataTable(ctDmdSalesDataTable);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            dtDmdSalesTable.Columns.Add(ctAlwCheck, typeof(bool));						// ��
            dtDmdSalesTable.Columns.Add(ctDepositAllowance_Alw, typeof(Int64));			// �����z ���� (���������}�X�^)
            dtDmdSalesTable.Columns.Add(ctDepositAlwcBlnce_Sales, typeof(Int64));		// �����c ���� (��������}�X�^)
            // ---ADD 2011/07/22 -------->>>>>>> 
            dtDmdSalesTable.Columns.Add(ctAllowDiv, typeof(string));                    // ����
            dtDmdSalesTable.Columns.Add(ctSalesSlipNum, typeof(string));                // ����`�[�ԍ�
            dtDmdSalesTable.Columns.Add(ctSearchSlipDateDisp, typeof(string));			// �`�[���t(�\���p)
            dtDmdSalesTable.Columns.Add(ctCustomerName, typeof(string));				// ���Ӑ於��
            dtDmdSalesTable.Columns.Add(ctSalesKind, typeof(string));					// �`�[���
            dtDmdSalesTable.Columns.Add(ctSlipNote, typeof(string));					// �`�[���l
            dtDmdSalesTable.Columns.Add(ctTotalSales, typeof(Int64));					// �`�[���v(�ō�)
            dtDmdSalesTable.Columns.Add(ctLastMonthlyDateDisp, typeof(string));         // �ŏI�������ߓ�(�\���p)
            dtDmdSalesTable.Columns.Add(ctLastMonthlyDate, typeof(string));         // �ŏI�������ߓ�
            
            // ---ADD 2011/07/22 --------<<<<<<
            dtDmdSalesTable.Columns.Add(ctBfDepositAlwcBlnce_Sales, typeof(Int64));		// �ύX�O�����c(��������}�X�^)
            dtDmdSalesTable.Columns.Add(ctDepositAllowance_Sales, typeof(Int64));		// ������ ���� (��������}�X�^)
            dtDmdSalesTable.Columns.Add(ctBfDepositAllowance_Sales, typeof(Int64));		// �ύX�O������(��������}�X�^)
            dtDmdSalesTable.Columns.Add(ctDmdSalesDebitNoteCd, typeof(int));			// ��������ԍ��敪
            dtDmdSalesTable.Columns.Add(ctDmdSalesDebitNoteNm, typeof(string));			// ��������ԍ�����
            // ---DEL 2011/07/22 -------->>>>>
            // dtDmdSalesTable.Columns.Add(ctAllowDiv, typeof(string));                    // ���� // ADD 2010/12/20
            // dtDmdSalesTable.Columns.Add(ctSalesSlipNum, typeof(string));                // ����`�[�ԍ�
            // dtDmdSalesTable.Columns.Add(ctSearchSlipDateDisp, typeof(string));			// �`�[���t(�\���p)
            // ---DEL 2011/07/22 --------<<<<<<
            dtDmdSalesTable.Columns.Add(ctSearchSlipDate, typeof(int));					// �`�[���t
            dtDmdSalesTable.Columns.Add(ctAddUpADate, typeof(int));						// �����
            dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatus, typeof(int));				// �󒍃X�e�[�^�X
            dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatusNm, typeof(string));           // �󒍃X�e�[�^�X��
            // ---ADD 2011/07/22 -------->>>>>
            //dtDmdSalesTable.Columns.Add(ctSalesKind, typeof(string));					// �`�[���
            // ---ADD 2011/07/22 --------<<<<<<
            dtDmdSalesTable.Columns.Add(ctSalesName, typeof(string));					// ���㖼��
            // ---DEL 2011/07/22 -------->>>>>
            //  dtDmdSalesTable.Columns.Add(ctTotalSales, typeof(Int64));					// �`�[���v(�ō�)
            // ---DEL 2011/07/22 --------<<<<<<
            dtDmdSalesTable.Columns.Add(ctSalesClosedFlg, typeof(string));				// ���t���O
            dtDmdSalesTable.Columns.Add(ctDepositAlwBtn, typeof(string));				// ���������{�^��
            dtDmdSalesTable.Columns.Add(ctClaimCode, typeof(int));				        // ������R�[�h
            // ---DEL 2011/07/22 -------->>>>>
            dtDmdSalesTable.Columns.Add(ctClaimName, typeof(string));				    // �����於��
            // ---DEL 2011/07/22 --------<<<<<<
            dtDmdSalesTable.Columns.Add(ctClaimName2, typeof(string));				    // �����於��2
            dtDmdSalesTable.Columns.Add(ctClaimSnm, typeof(string));				    // �����旪��
            dtDmdSalesTable.Columns.Add(ctCustomerCode, typeof(int));				    // ���Ӑ�R�[�h
            // ---DEL 2011/07/22 -------->>>>>
            // dtDmdSalesTable.Columns.Add(ctCustomerName, typeof(string));				// ���Ӑ於��
            // ---ADD 2011/07/22 --------<<<<<<
            dtDmdSalesTable.Columns.Add(ctCustomerName2, typeof(string));				// ���Ӑ於��2
            dtDmdSalesTable.Columns.Add(ctCustomerSnm, typeof(string));				    // ���Ӑ旪��
            dtDmdSalesTable.Columns.Add(ctAccRecDivCd, typeof(int));				    // �|���敪
            dtDmdSalesTable.Columns.Add(ctDepSaleSlipNum, typeof(string));				// ����`�[�ԍ�  // ADD 2010/12/20
            dtDmdSalesTable.Columns.Add(ctSalesDataRow, typeof(DataRow));				// ���g��DataRow

            // �f�[�^�Z�b�g�ɒǉ�
            _dsDmdSalesInfo.Tables.Add(dtDmdSalesTable.Clone());
        }


        // ----- ADD ���N 2012/12/24 Redmine#33741 ----->>>>>
        /// <summary>
        /// ����Guid��� DataSet Table �쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����Guid���f�[�^�Z�b�g�̃e�[�u�����쐬���܂��B
        ///	               :   �� Method : GetDsDepositInfo ��茋�ʎ擾</br>
        /// <br>Programmer : ���N</br>
        /// <br>Date       : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// </remarks>
        public void CreateDepositGuidDataTable()
        {
            //---------------------------------
            // �����e�[�u��
            //---------------------------------
            // �f�[�^�e�[�u���̗��`
            DataTable dtDepositTable = new DataTable(ctDepositGuidDataTable);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            dtDepositTable.Columns.Add(ctDepositDebitNoteCd, typeof(Int32));			// �����ԍ��敪
            dtDepositTable.Columns.Add(ctDepositDebitNoteNm, typeof(string));			// �����ԍ�����
            dtDepositTable.Columns.Add(ctDepositSlipNo, typeof(Int32));					// �����`�[�ԍ�
            dtDepositTable.Columns.Add(ctSalesSlipNum, typeof(string));	        		// ����`�[�ԍ�
            dtDepositTable.Columns.Add(ctDebitNoteLinkDepoNo, typeof(Int32));			// �ԍ������A���ԍ�
            dtDepositTable.Columns.Add(ctDepositDateDisp, typeof(string));				// �������t(�\���p)
            dtDepositTable.Columns.Add(ctDepositDate, typeof(Int32));					// �������t
            dtDepositTable.Columns.Add(ctDepositAddUpADate, typeof(Int32));				// �v����t
            dtDepositTable.Columns.Add(ctDepositAddUpADateDisp, typeof(string));		// �v����t(�\���p)
            dtDepositTable.Columns.Add(ctDepositAcptAnOdrStatus, typeof(Int32));		// �󒍃X�e�[�^�X
            dtDepositTable.Columns.Add(ctAutoDepositCd, typeof(Int32));					// ���������敪
            dtDepositTable.Columns.Add(ctDepositNm, typeof(string));					// �a����敪����
            dtDepositTable.Columns.Add(ctDepositKindName, typeof(string));				// �������햼��(�\���p)
            dtDepositTable.Columns.Add(ctDeposit, typeof(Int64));						// ���� �����z
            dtDepositTable.Columns.Add(ctFeeDeposit, typeof(Int64));					// ���� �萔��
            dtDepositTable.Columns.Add(ctDiscountDeposit, typeof(Int64));				// ���� �l��
            dtDepositTable.Columns.Add(ctDepositTotal, typeof(Int64));					// ���� �����v
            dtDepositTable.Columns.Add(ctAllowDiv, typeof(string));					    // ����  // ADD 2010/12/20
            dtDepositTable.Columns.Add(ctDepositAllowance_Deposit, typeof(Int64));		// ���������z ����
            dtDepositTable.Columns.Add(ctDepositAlwcBlnce_Deposit, typeof(Int64));		// ���������c ����
            dtDepositTable.Columns.Add(ctDraftDrawingDate, typeof(Int32));				// ��`�U�o��
            dtDepositTable.Columns.Add(ctBankCode, typeof(Int32));                      // ��s�R�[�h
            dtDepositTable.Columns.Add(ctBankName, typeof(string));                     // ��s����
            dtDepositTable.Columns.Add(ctDraftNo, typeof(string));                      // ��`�ԍ�
            dtDepositTable.Columns.Add(ctDraftKind, typeof(Int32));                     // ��`��ރR�[�h 
            dtDepositTable.Columns.Add(ctDraftKindName, typeof(string));                // ��`��ޖ���
            dtDepositTable.Columns.Add(ctDraftDivide, typeof(Int32));                   // ��`�敪�R�[�h 
            dtDepositTable.Columns.Add(ctDraftDivideName, typeof(string));              // ��`�敪����
            dtDepositTable.Columns.Add(ctOutline, typeof(string));						// �E�v
            dtDepositTable.Columns.Add(ctDepositClosedFlg, typeof(string));				// ���t���O
            dtDepositTable.Columns.Add(ctDepositRowNo1, typeof(Int32));				    // �����s�ԍ�1
            dtDepositTable.Columns.Add(ctMoneyKindCode1, typeof(Int32));				// ����R�[�h1
            dtDepositTable.Columns.Add(ctMoneyKindName1, typeof(string));				// ���햼��1
            dtDepositTable.Columns.Add(ctMoneyKindDiv1, typeof(Int32));				    // ����敪1
            dtDepositTable.Columns.Add(ctDeposit1, typeof(Int64));				        // �������z1
            dtDepositTable.Columns.Add(ctValidityTerm1, typeof(DateTime));				// �L������1
            dtDepositTable.Columns.Add(ctDepositRowNo2, typeof(Int32));				    // �����s�ԍ�2
            dtDepositTable.Columns.Add(ctMoneyKindCode2, typeof(Int32));				// ����R�[�h2
            dtDepositTable.Columns.Add(ctMoneyKindName2, typeof(string));				// ���햼��2
            dtDepositTable.Columns.Add(ctMoneyKindDiv2, typeof(Int32));				    // ����敪2
            dtDepositTable.Columns.Add(ctDeposit2, typeof(Int64));				        // �������z2
            dtDepositTable.Columns.Add(ctValidityTerm2, typeof(DateTime));				// �L������2
            dtDepositTable.Columns.Add(ctDepositRowNo3, typeof(Int32));				    // �����s�ԍ�3
            dtDepositTable.Columns.Add(ctMoneyKindCode3, typeof(Int32));				// ����R�[�h3
            dtDepositTable.Columns.Add(ctMoneyKindName3, typeof(string));				// ���햼��3
            dtDepositTable.Columns.Add(ctMoneyKindDiv3, typeof(Int32));				    // ����敪3
            dtDepositTable.Columns.Add(ctDeposit3, typeof(Int64));				        // �������z3
            dtDepositTable.Columns.Add(ctValidityTerm3, typeof(DateTime));				// �L������3
            dtDepositTable.Columns.Add(ctDepositRowNo4, typeof(Int32));				    // �����s�ԍ�4
            dtDepositTable.Columns.Add(ctMoneyKindCode4, typeof(Int32));				// ����R�[�h4
            dtDepositTable.Columns.Add(ctMoneyKindName4, typeof(string));				// ���햼��4
            dtDepositTable.Columns.Add(ctMoneyKindDiv4, typeof(Int32));				    // ����敪4
            dtDepositTable.Columns.Add(ctDeposit4, typeof(Int64));				        // �������z4
            dtDepositTable.Columns.Add(ctValidityTerm4, typeof(DateTime));				// �L������4
            dtDepositTable.Columns.Add(ctDepositRowNo5, typeof(Int32));				    // �����s�ԍ�5
            dtDepositTable.Columns.Add(ctMoneyKindCode5, typeof(Int32));				// ����R�[�h5
            dtDepositTable.Columns.Add(ctMoneyKindName5, typeof(string));				// ���햼��5
            dtDepositTable.Columns.Add(ctMoneyKindDiv5, typeof(Int32));				    // ����敪5
            dtDepositTable.Columns.Add(ctDeposit5, typeof(Int64));				        // �������z5
            dtDepositTable.Columns.Add(ctValidityTerm5, typeof(DateTime));				// �L������5
            dtDepositTable.Columns.Add(ctDepositRowNo6, typeof(Int32));				    // �����s�ԍ�6
            dtDepositTable.Columns.Add(ctMoneyKindCode6, typeof(Int32));				// ����R�[�h6
            dtDepositTable.Columns.Add(ctMoneyKindName6, typeof(string));				// ���햼��6
            dtDepositTable.Columns.Add(ctMoneyKindDiv6, typeof(Int32));				    // ����敪6
            dtDepositTable.Columns.Add(ctDeposit6, typeof(Int64));				        // �������z6
            dtDepositTable.Columns.Add(ctValidityTerm6, typeof(DateTime));				// �L������6
            dtDepositTable.Columns.Add(ctDepositRowNo7, typeof(Int32));				    // �����s�ԍ�7
            dtDepositTable.Columns.Add(ctMoneyKindCode7, typeof(Int32));				// ����R�[�h7
            dtDepositTable.Columns.Add(ctMoneyKindName7, typeof(string));				// ���햼��7
            dtDepositTable.Columns.Add(ctMoneyKindDiv7, typeof(Int32));				    // ����敪7
            dtDepositTable.Columns.Add(ctDeposit7, typeof(Int64));				        // �������z7
            dtDepositTable.Columns.Add(ctValidityTerm7, typeof(DateTime));				// �L������7
            dtDepositTable.Columns.Add(ctDepositRowNo8, typeof(Int32));				    // �����s�ԍ�8
            dtDepositTable.Columns.Add(ctMoneyKindCode8, typeof(Int32));				// ����R�[�h8
            dtDepositTable.Columns.Add(ctMoneyKindName8, typeof(string));				// ���햼��8
            dtDepositTable.Columns.Add(ctMoneyKindDiv8, typeof(Int32));				    // ����敪8
            dtDepositTable.Columns.Add(ctDeposit8, typeof(Int64));				        // �������z8
            dtDepositTable.Columns.Add(ctValidityTerm8, typeof(DateTime));				// �L������8
            dtDepositTable.Columns.Add(ctDepositRowNo9, typeof(Int32));				    // �����s�ԍ�9
            dtDepositTable.Columns.Add(ctMoneyKindCode9, typeof(Int32));				// ����R�[�h9
            dtDepositTable.Columns.Add(ctMoneyKindName9, typeof(string));				// ���햼��9
            dtDepositTable.Columns.Add(ctMoneyKindDiv9, typeof(Int32));				    // ����敪9
            dtDepositTable.Columns.Add(ctDeposit9, typeof(Int64));				        // �������z9
            dtDepositTable.Columns.Add(ctValidityTerm9, typeof(DateTime));				// �L������9
            dtDepositTable.Columns.Add(ctDepositRowNo10, typeof(Int32));				// �����s�ԍ�10
            dtDepositTable.Columns.Add(ctMoneyKindCode10, typeof(Int32));				// ����R�[�h10
            dtDepositTable.Columns.Add(ctMoneyKindName10, typeof(string));				// ���햼��10
            dtDepositTable.Columns.Add(ctMoneyKindDiv10, typeof(Int32));				// ����敪10
            dtDepositTable.Columns.Add(ctDeposit10, typeof(Int64));				        // �������z10
            dtDepositTable.Columns.Add(ctValidityTerm10, typeof(DateTime));				// �L������10
            dtDepositTable.Columns.Add(ctDepositInputAgentNm, typeof(string));          // �������͎Җ���
            dtDepositTable.Columns.Add(ctDepositInputEmpCd, typeof(string));            // ���s�҃R�[�h
            dtDepositTable.Columns.Add(ctDepositInputEmpNm, typeof(string));            // ���s�Җ�
            dtDepositTable.Columns.Add(ctCustomerCode, typeof(Int32));                  // ���Ӑ�R�[�h
            dtDepositTable.Columns.Add(ctCustomerName, typeof(string));                 // ���Ӑ於��
            dtDepositTable.Columns.Add(ctDepositDataRow, typeof(DataRow));				// ���g��DataRow
            // �f�[�^�Z�b�g�ɒǉ�
            this._dsDepositInfo.Tables.Add(dtDepositTable.Clone());
        }
        // ----- ADD ���N 2012/12/24 Redmine#33741 -----<<<<<
		/// <summary>
		/// �����֘A�f�[�^�擾�����i���Ӑ�R�[�h�w��j
		/// </summary>
		/// <param name="searchCustomerParameter">���Ӑ���/���Ӑ���z���擾�p�p�����[�^ �N���X</param>
		/// <param name="searchDepositParameter">�������/�������擾�p�p�����[�^ �N���X</param>
		/// <param name="searchSalesParameter">����������擾�p�p�����[�^ �N���X</param>
		/// <param name="getAllowanceDiv">����/��������擾�敪</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���</param>
		/// <param name="depositCustomer">�������Ӑ���N���X</param>
		/// <param name="depositCustDmdPrc">�������Ӑ搿�����z���N���X</param>
		/// <param name="message">�G���[���������b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�p�����[�^�̓��Ӑ���/�������z�����擾���Ԃ��܂��B
		///	                : �܂��A�������/������������擾���A�ȉ��̃f�[�^�Z�b�g�ɂĕԂ��܂��B
		///					:   �� �������Ӑ���         : Method : GetDepositCustomer
		///					:   �� �������Ӑ搿�����z��� : Method : GetDepositCustDmdPrc
		///					:   �� �������     : Method : GetDsDepositInfo
		///					:   �� ���������� : Method : GetDsDmdSalesInfo</br>
		/// <br>Programmer  : 30414 �E �K�j</br>
		/// <br>Date        : 2008/06/26</br>
        /// <br>UpdateNote  : 2009/12/16 ����� �o�l�D�m�r�ێ�˗��C</br>
        /// <br>              ���Ӑ���͌�ɓ����ꗗ�������\�����Ȃ��悤�ɕύX</br>
		/// </remarks>
		public int SearchCustomerMode(SearchCustomerParameter searchCustomerParameter, 
                                      SearchDepositParameter searchDepositParameter, 
                                      SearchSalesParameter searchSalesParameter, 
                                      bool getAllowanceDiv, 
                                      int consTaxLayMethod,
                                      out DepositCustomer depositCustomer, 
                                      out DepositCustDmdPrc depositCustDmdPrc, 
                                      out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";
			depositCustDmdPrc = null;
			depositCustomer = null;

            // ����œ]�ŕ���
            this._consTaxLayMethod = consTaxLayMethod;

			try
			{
				int customerCode;
                int claimCode;
			
				// �������Ӑ���N���X����������
				ClearDepositCustomer();

				// �������Ӑ搿�����z���N���X����������
				ClearDepositCustDmdPrc();

				// �������DataSet����������
				ClearDsDepositInfo();

				// �󒍏��DataSet����������
				ClearDmdSalesInfo();

                // ���Ӑ���/�������z���擾����
                status = GetCustomDemandInfo1(searchCustomerParameter, out depositCustomer, out depositCustDmdPrc, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "���Ӑ�}�X�^�̐������_���S�̏����\���ݒ�}�X�^�ɓo�^����Ă��܂���B";
                        return (status);
                    default:
                        return (status);
                }

                // --- DEL 2009/12/16 ---------->>>>>
				// �������/�������擾����
                //status = GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode, out message);
                //switch (status)
                //{
                //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                //        // �������DetaSet�����X�V�t���O�Z�b�g����
                //        SetDepositDataSetClosedFlg();
                //        break;
                //    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                //    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                //        break;
                //    default:
                //        return (status);
                //}
                // --- DEL 2009/12/16 ----------<<<<<

                if (getAllowanceDiv != true)
                {
                    return (status);
                }

                // --- DEL 2009/12/16 ---------->>>>>
				// ����������擾����
                //status = GetClaimSalesInfo(searchSalesParameter, out message);
                //switch (status)
                //{
                //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                //        // ����������DetaSet�����X�V�t���O�Z�b�g����
                //        SetDmdSalesDataSetClosedFlg();
                //        break;
                //    default:
                //        return (status);
                //}
                // --- DEL 2009/12/16 ----------<<<<<
			}
			catch ( DepositException ex )
			{
				status = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return status;
		}

        /// <summary>
        /// �����֘A�f�[�^�擾�����i�����`�[�ԍ��w��j
        /// </summary>
        /// <param name="searchCustomerParameter">���Ӑ���/���Ӑ���z���擾�p�p�����[�^ �N���X</param>
        /// <param name="searchDepositParameter">�������/�������擾�p�p�����[�^ �N���X</param>
        /// <param name="searchSalesParameter">����������擾�p�p�����[�^ �N���X</param>
        /// <param name="getAllowanceDiv">����/��������擾�敪</param>
        /// <param name="depositCustomer">�������Ӑ���N���X</param>
        /// <param name="depositCustDmdPrc">�������Ӑ搿�����z���N���X</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�p�����[�^�̓��Ӑ���/�������z�����擾���Ԃ��܂��B
        ///	                : �܂��A�������/������������擾���A�ȉ��̃f�[�^�Z�b�g�ɂĕԂ��܂��B
        ///					:   �� �������     : Method : GetDsDepositInfo
        ///					:   �� ���������� : Method : GetDsDmdSalesInfo</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int SearchDepositSlipNoMode(SearchCustomerParameter searchCustomerParameter, 
                                           SearchDepositParameter searchDepositParameter, 
                                           SearchSalesParameter searchSalesParameter, 
                                           bool getAllowanceDiv, 
                                           out DepositCustomer depositCustomer, 
                                           out DepositCustDmdPrc depositCustDmdPrc, 
                                           out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            depositCustomer = null;
            depositCustDmdPrc = null;

            try
            {
                int claimCode;
                int customerCode;

                // �������Ӑ���N���X����������
                ClearDepositCustomer();

                // �������Ӑ搿�����z���N���X����������
                ClearDepositCustDmdPrc();

                // �������DataSet����������
                ClearDsDepositInfo();

                // �󒍏��DataSet����������
                ClearDmdSalesInfo();

                // �������/�������擾����
                status = GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        searchCustomerParameter.ClaimCode = claimCode;
                        searchCustomerParameter.CustomerCode = customerCode;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "�w�肳�ꂽ�����ŁA�����`�[�͑��݂��܂���ł����B";
                        return (status);
                    default:
                        return (status);
                }

                // ���Ӑ���/�������z���擾����
                status = GetCustomDemandInfo1(searchCustomerParameter, out depositCustomer, out depositCustDmdPrc, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "���Ӑ�}�X�^�̐������_���S�̏����\���ݒ�}�X�^�ɓo�^����Ă��܂���B";
                        return (status);
                    default:
                        return (status);
                }

                // �������DetaSet�����X�V�t���O�Z�b�g����
                SetDepositDataSetClosedFlg();

                searchSalesParameter.ClaimCode = claimCode;
                searchSalesParameter.CustomerCode = customerCode;

                if (getAllowanceDiv != true)
                {
                    return (status);
                }

                // ����������擾����
                status = GetClaimSalesInfo(searchSalesParameter, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // ����������DetaSet�����X�V�t���O�Z�b�g����
                        SetDmdSalesDataSetClosedFlg();
                        break;
                    default :
                        return (status);
                }
            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }
            finally
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    // �������Ӑ���N���X����������
                    ClearDepositCustomer();

                    // �������Ӑ搿�����z���N���X����������
                    ClearDepositCustDmdPrc();

                    // �������DataSet����������
                    ClearDsDepositInfo();

                    // �󒍏��DataSet����������
                    ClearDmdSalesInfo();
                }
            }
            return (status);
        }

        /// <summary>
        /// �����֘A�f�[�^�擾�����i�󒍔ԍ��w��j
        /// </summary>
        /// <param name="searchCustomerParameter">���Ӑ���/���Ӑ���z���擾�p�p�����[�^ �N���X</param>
        /// <param name="searchDepositParameter">�������/�������擾�p�p�����[�^ �N���X</param>
        /// <param name="searchSalesParameter">����������擾�p�p�����[�^ �N���X</param>
        /// <param name="depositCustomer">�������Ӑ���N���X</param>
        /// <param name="depositCustDmdPrc">�������Ӑ搿�����z���N���X</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�p�����[�^�̓��Ӑ���/�������z�����擾���Ԃ��܂��B
        ///	                : �܂��A�������/������������擾���A�ȉ��̃f�[�^�Z�b�g�ɂĕԂ��܂��B
        ///					:   �� �������Ӑ���         : Method : GetDepositCustomer
        ///					:   �� �������Ӑ搿�����z��� : Method : GetDepositCustDmdPrc
        ///					:   �� �������     : Method : GetDsDepositInfo
        ///					:   �� ���������� : Method : GetDsDmdSalesInfo</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int SearchAcceptAnOrderNoMode(SearchCustomerParameter searchCustomerParameter, 
                                             SearchDepositParameter searchDepositParameter, 
                                             SearchSalesParameter searchSalesParameter, 
                                             out DepositCustomer depositCustomer, 
                                             out DepositCustDmdPrc depositCustDmdPrc, 
                                             out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            depositCustDmdPrc = null;
            depositCustomer = null;

            try
            {
                int claimCode;
                int customerCode;

                // �������Ӑ���N���X����������
                ClearDepositCustomer();

                // �������Ӑ搿�����z���N���X����������
                ClearDepositCustDmdPrc();

                // �������DataSet����������
                ClearDsDepositInfo();

                // �󒍏��DataSet����������
                ClearDmdSalesInfo();

                // ���Ӑ���/�������z���擾����
                status = GetCustomDemandInfo1(searchCustomerParameter, out depositCustomer, out depositCustDmdPrc, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "���Ӑ�}�X�^�̐������_���S�̏����\���ݒ�}�X�^�ɓo�^����Ă��܂���B";
                        return (status);
                    default:
                        return (status);
                }

                // ����������擾����
                status = GetClaimSalesInfo(searchSalesParameter, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "�w�肳�ꂽ�����ŁA����`�[�͑��݂��܂���ł����B";
                        return (status);
                    default:
                        return (status);
                }

                // ����������DetaSet�����X�V�t���O�Z�b�g����
                SetDmdSalesDataSetClosedFlg();

                // �������/�������擾����
                status = GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "�w�肳�ꂽ����`�[�ɑ΂�������`�[�͑��݂��܂���ł����B";
                        return (status);
                    default:
                        return (status);
                }

                // �������DetaSet�����X�V�t���O�Z�b�g����
                SetDepositDataSetClosedFlg();
            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return (status);
        }

        /// <summary>
        /// �����֘A�f�[�^�擾�����i�������̂ݎ擾�j
        /// </summary>
        /// <param name="searchDepositParameter">�������/�������擾�p�p�����[�^ �N���X</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�p�����[�^�̓��������擾���A�ȉ��̃f�[�^�Z�b�g�ɂĕԂ��܂��B
        ///					:   �� �������     : Method : GetDsDepositInfo</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2012/12/24 ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        public int SearchDepositOnlyMode(SearchDepositParameter searchDepositParameter, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                int claimCode;
                int customerCode;

                // �������DataSet����������
                ClearDsDepositInfo();

                // �������/�������擾����
                status = GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "�w�肳�ꂽ�����ŁA�����`�[�͑��݂��܂���ł����B";
                        return (status);
                    default:
                        return (status);
                }
                // ------- ADD ���N 2012/12/24 Redmine#33741 ------->>>>>
                if (status != 0)
                {
                    return 0;
                }
                // ------- ADD ���N 2012/12/24 Redmine#33741 -------<<<<<
                // �������DetaSet�����X�V�t���O�Z�b�g����
                SetDepositDataSetClosedFlg();

                // ����������f�[�^�Z�b�g�ēo�^����
                ResetDsDmdSalesInfo();

            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }

        // ----- ADD ���N�@2012/12/24�@Redmine#33741 ----->>>>>
        /// <summary>
        /// �����֘A�f�[�^�擾�����i�������̂ݎ擾�j
        /// </summary>
        /// <param name="searchDepositParameter">�������/�������擾�p�p�����[�^ �N���X</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�p�����[�^�̓��������擾���A�ȉ��̃f�[�^�Z�b�g�ɂĕԂ��܂��B
        ///					:   �� �������     : Method : GetDsDepositInfo</br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        public int SearchDepositGuidOnlyMode(SearchDepositParameter searchDepositParameter, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                int claimCode;
                int customerCode;

                // DataSet������
                this.ClearDsGuidDepositInfo();

                // �������擾����
                status = GetDepositGuidInfo(searchDepositParameter, out customerCode, out claimCode, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        this._dsDepositInfo.Tables[ctDepositGuidDataTable].DefaultView.Sort = "DepositSlipNo asc";
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "�w�肳�ꂽ�����ŁA�����`�[�͑��݂��܂���ł����B";
                        return (status);
                    default:
                        return (status);
                }
                // ------- ADD ���N 2012/12/24 Redmine#33741 ------->>>>>
                if (status != 0)
                {
                    return 0;
                }
                // ------- ADD ���N 2012/12/24 Redmine#33741 -------<<<<<
                //if (searchDepositParameter.CustomerCode != 0)
                //{
                //    SetDepositGuidDataRemove();
                //}
                //else
                //{
                //    SetDepositGuidDataRemoveByMonth();
                //}
                // �������DetaSet�����X�V�t���O�Z�b�g����
                SetDepositGuidDataSetClosedFlg();
            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }
        // ----- ADD ���N�@2012/12/24�@Redmine#33741 -----<<<<<

        /// <summary>
        /// �����֘A�f�[�^�擾�����i����������̂ݎ擾�j
        /// </summary>
        /// <param name="searchSalesParameter">����������擾�p�p�����[�^ �N���X</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�p�����[�^�̐�����������擾���A�ȉ��̃f�[�^�Z�b�g�ɂĕԂ��܂��B
        ///					:   �� ���������� : Method : GetDsDmdSalesInfo</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int SearchSalesOnlyMode(SearchSalesParameter searchSalesParameter, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                // �󒍏��DataSet����������
                this.ClearDmdSalesInfo();

                // ����������擾����
                status = GetClaimSalesInfo(searchSalesParameter, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "�w�肳�ꂽ�����ŁA����`�[�͑��݂��܂���ł����B";
                        return (status);
                    default:
                        return (status);
                }

                // ����������DetaSet�����X�V�t���O�Z�b�g����
                SetDmdSalesDataSetClosedFlg();
            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �������z���擾����
        /// </summary>
        /// <param name="searchCustomerParameter">���Ӑ���/���Ӑ���z���擾�p�p�����[�^ �N���X</param>
        /// <param name="depositCustDmdPrc">�������Ӑ搿�����z���N���X</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�p�����[�^�̐������z�����擾���Ԃ��܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int ReadCustomDemandInfo(SearchCustomerParameter searchCustomerParameter, out DepositCustDmdPrc depositCustDmdPrc, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            depositCustDmdPrc = null;

            try
            {
                // �������Ӑ搿�����z���N���X����������
                ClearDepositCustDmdPrc();

                // ���Ӑ���/�������z���擾����
                status = GetCustomDemandInfo2(searchCustomerParameter, out depositCustDmdPrc, out message);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        message = "�w�肳�ꂽ�����ŁA�������z���͑��݂��܂���ł����B";
                        return (status);
                    default:
                        return (status);
                }
            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return (status);
        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �����֘A�f�[�^�擾�����i���Ӑ�R�[�h�w��j
        /// </summary>
        /// <param name="searchCustomerParameter">���Ӑ���/���Ӑ���z���擾�p�p�����[�^ �N���X</param>
        /// <param name="searchDepositParameter">�������/�������擾�p�p�����[�^ �N���X</param>
        /// <param name="searchSalesParameter">����������擾�p�p�����[�^ �N���X</param>
        /// <param name="getAllowanceDiv">����/��������擾�敪</param>
        /// <param name="depositCustomer">�������Ӑ���N���X</param>
        /// <param name="depositCustDmdPrc">�������Ӑ搿�����z���N���X</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�p�����[�^�̓��Ӑ���/�������z�����擾���Ԃ��܂��B
        ///	                : �܂��A�������/������������擾���A�ȉ��̃f�[�^�Z�b�g�ɂĕԂ��܂��B
        ///					:   �� �������Ӑ���         : Method : GetDepositCustomer
        ///					:   �� �������Ӑ搿�����z��� : Method : GetDepositCustDmdPrc
        ///					:   �� �������     : Method : GetDsDepositInfo
        ///					:   �� ���������� : Method : GetDsDmdSalesInfo</br>
        /// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// </remarks>
        public int SearchCustomerMode(SearchCustomerParameter searchCustomerParameter, SearchDepositParameter searchDepositParameter, SearchSalesParameter searchSalesParameter, bool getAllowanceDiv, out DepositCustomer depositCustomer, out DepositCustDmdPrc depositCustDmdPrc, out string message)
        {
            int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            depositCustDmdPrc = null;
            depositCustomer = null;

            try
            {
                int customerCode;
                int claimCode;

                // �������Ӑ���N���X����������
                this.ClearDepositCustomer();

                // �������Ӑ搿�����z���N���X����������
                this.ClearDepositCustDmdPrc();

                // �������DataSet����������
                this.ClearDsDepositInfo();

                // �󒍏��DataSet����������
                this.ClearDmdSalesInfo();

                // ���Ӑ���/�������z���擾����
                st = this.GetCustomDemandInfo1(searchCustomerParameter, out depositCustomer, out depositCustDmdPrc);
                if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    message = "�w�肳�ꂽ�����ŁA���Ӑ�͑��݂��܂���ł����B";
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                // �������/�������擾����
                if (this.GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode) == 0)
                {
                    // �������DetaSet�����X�V�t���O�Z�b�g����
                    this.SetDepositDataSetClosedFlg();
                }

                // ����������擾����
                if (getAllowanceDiv == true)
                {
                    // �� 20070122 18322 c MA.NS�p�ɕύX
                    //if (this.GetDmdSalesInfo(searchSalesParameter) == 0)

                    if (this.GetClaimSalesInfo(searchSalesParameter) == 0)
                    // �� 20070122 18322 c
                    {
                        // ����������DetaSet�����X�V�t���O�Z�b�g����
                        this.SetDmdSalesDataSetClosedFlg();
                    }
                }
            }
            catch (DepositException ex)
            {
                st = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return st;
        }
        
        /// <summary>
		/// �����֘A�f�[�^�擾�����i�����`�[�ԍ��w��j
		/// </summary>
		/// <param name="searchCustomerParameter">���Ӑ���/���Ӑ���z���擾�p�p�����[�^ �N���X</param>
		/// <param name="searchDepositParameter">�������/�������擾�p�p�����[�^ �N���X</param>
		/// <param name="searchSalesParameter">����������擾�p�p�����[�^ �N���X</param>
		/// <param name="getAllowanceDiv">����/��������擾�敪</param>
		/// <param name="depositCustomer">�������Ӑ���N���X</param>
		/// <param name="depositCustDmdPrc">�������Ӑ搿�����z���N���X</param>
		/// <param name="message">�G���[���������b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�p�����[�^�̓��Ӑ���/�������z�����擾���Ԃ��܂��B
		///	                : �܂��A�������/������������擾���A�ȉ��̃f�[�^�Z�b�g�ɂĕԂ��܂��B
		///					:   �� �������     : Method : GetDsDepositInfo
		///					:   �� ���������� : Method : GetDsDmdSalesInfo</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int SearchDepositSlipNoMode(SearchCustomerParameter searchCustomerParameter, SearchDepositParameter searchDepositParameter, SearchSalesParameter searchSalesParameter, bool getAllowanceDiv, out DepositCustomer depositCustomer, out DepositCustDmdPrc depositCustDmdPrc, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";
			depositCustomer = null;
			depositCustDmdPrc = null;

			try
			{
                int claimCode;
				int customerCode;

				// �������Ӑ���N���X����������
				this.ClearDepositCustomer();

				// �������Ӑ搿�����z���N���X����������
				this.ClearDepositCustDmdPrc();

				// �������DataSet����������
				this.ClearDsDepositInfo();

				// �󒍏��DataSet����������
				this.ClearDmdSalesInfo();

				// �������/�������擾����
                st = this.GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode);
                if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    message = "�w�肳�ꂽ�����ŁA�����`�[�͑��݂��܂���ł����B";
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                searchCustomerParameter.ClaimCode = claimCode;
                searchCustomerParameter.CustomerCode = customerCode;
                
				// ���Ӑ���/�������z���擾����
                st = this.GetCustomDemandInfo1(searchCustomerParameter, out depositCustomer, out depositCustDmdPrc);
                if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    message = "�w�肳�ꂽ�����`�[�̓��Ӑ悪���݂��܂���ł����B";
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

				// �������DetaSet�����X�V�t���O�Z�b�g����
				this.SetDepositDataSetClosedFlg();

                searchSalesParameter.ClaimCode = claimCode;
                searchSalesParameter.CustomerCode = customerCode;

				// ����������擾����
				if (getAllowanceDiv == true)
				{
                    // �� 20070122 18322 c MA.NS�p�ɕύX
					//if (this.GetDmdSalesInfo(searchSalesParameter) == 0)

					if (this.GetClaimSalesInfo(searchSalesParameter) == 0)
                    // �� 20070122 18322 c
					{
						// ����������DetaSet�����X�V�t���O�Z�b�g����
						this.SetDmdSalesDataSetClosedFlg();
					}
				}
			}
			catch (DepositException ex)
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch (Exception ex)
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}
// >>> Ins Start 2006.11.04 amami >>> //
			finally
			{
				if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
				{
					// �������Ӑ���N���X����������
					this.ClearDepositCustomer();

					// �������Ӑ搿�����z���N���X����������
					this.ClearDepositCustDmdPrc();

					// �������DataSet����������
					this.ClearDsDepositInfo();

					// �󒍏��DataSet����������
					this.ClearDmdSalesInfo();
				}
			}
// <<< Ins End 2006.11.04 amami <<< //
			return st;
		}

        /// <summary>
		/// �����֘A�f�[�^�擾�����i�󒍔ԍ��w��j
		/// </summary>
		/// <param name="searchCustomerParameter">���Ӑ���/���Ӑ���z���擾�p�p�����[�^ �N���X</param>
		/// <param name="searchDepositParameter">�������/�������擾�p�p�����[�^ �N���X</param>
		/// <param name="searchSalesParameter">����������擾�p�p�����[�^ �N���X</param>
		/// <param name="depositCustomer">�������Ӑ���N���X</param>
		/// <param name="depositCustDmdPrc">�������Ӑ搿�����z���N���X</param>
		/// <param name="message">�G���[���������b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�p�����[�^�̓��Ӑ���/�������z�����擾���Ԃ��܂��B
		///	                : �܂��A�������/������������擾���A�ȉ��̃f�[�^�Z�b�g�ɂĕԂ��܂��B
		///					:   �� �������Ӑ���         : Method : GetDepositCustomer
		///					:   �� �������Ӑ搿�����z��� : Method : GetDepositCustDmdPrc
		///					:   �� �������     : Method : GetDsDepositInfo
		///					:   �� ���������� : Method : GetDsDmdSalesInfo</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int SearchAcceptAnOrderNoMode(SearchCustomerParameter searchCustomerParameter, SearchDepositParameter searchDepositParameter, SearchSalesParameter searchSalesParameter, out DepositCustomer depositCustomer, out DepositCustDmdPrc depositCustDmdPrc, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";
			depositCustDmdPrc = null;
			depositCustomer = null;

			try
			{
                int claimCode;
				int customerCode;
			
				// �������Ӑ���N���X����������
				this.ClearDepositCustomer();

				// �������Ӑ搿�����z���N���X����������
				this.ClearDepositCustDmdPrc();

				// �������DataSet����������
				this.ClearDsDepositInfo();

				// �󒍏��DataSet����������
				this.ClearDmdSalesInfo();

				// ���Ӑ���/�������z���擾����
                st = this.GetCustomDemandInfo1(searchCustomerParameter, out depositCustomer, out depositCustDmdPrc);
                if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    // �� 20070129 18322 c MA.NS�p�ɕύX
                    //message = "�w�肳�ꂽ�󒍓`�[�̓��Ӑ悪���݂��܂���ł����B";

                    message = "�w�肳�ꂽ����`�[�̓��Ӑ悪���݂��܂���ł����B";
                    // �� 20070129 18322 c
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

				// ����������擾����
                // �� 20070122 18322 c MA.NS�p�ɕύX
				//st = this.GetDmdSalesInfo(searchSalesParameter);

                st = this.GetClaimSalesInfo(searchSalesParameter);
                // �� 20070122 18322 c
				if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
				{
                    // �� 20070129 18322 c MA.NS�p�ɕύX
					//message = "�w�肳�ꂽ�����ŁA�󒍓`�[�͑��݂��܂���ł����B";

					message = "�w�肳�ꂽ�����ŁA����`�[�͑��݂��܂���ł����B";
                    // �� 20070129 18322 c
					return 14;
				}

				// ����������DetaSet�����X�V�t���O�Z�b�g����
				this.SetDmdSalesDataSetClosedFlg();

				// �������/�������擾����
                st = this.GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode);
                if (st == 9)
                {
                    // �� 20070129 18322 c MA.NS�p�ɕύX
                    //message = "�w�肳�ꂽ�󒍓`�[�ɑ΂�������`�[�͑��݂��܂���ł����B";

                    message = "�w�肳�ꂽ����`�[�ɑ΂�������`�[�͑��݂��܂���ł����B";
                    // �� 20070129 18322 c
                    return 24;
                }

				// �������DetaSet�����X�V�t���O�Z�b�g����
				this.SetDepositDataSetClosedFlg();
			}
			catch ( DepositException ex )
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return st;
		}

		/// <summary>
		/// �����֘A�f�[�^�擾�����i�������̂ݎ擾�j
		/// </summary>
		/// <param name="searchDepositParameter">�������/�������擾�p�p�����[�^ �N���X</param>
		/// <param name="message">�G���[���������b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�p�����[�^�̓��������擾���A�ȉ��̃f�[�^�Z�b�g�ɂĕԂ��܂��B
		///					:   �� �������     : Method : GetDsDepositInfo</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int SearchDepositOnlyMode(SearchDepositParameter searchDepositParameter, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
                int claimCode;
				int customerCode;
			
				// �������DataSet����������
				this.ClearDsDepositInfo();

				// �������/�������擾����
                st = this.GetDepositAlwInfo(searchDepositParameter, out customerCode, out claimCode);
                if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    message = "�w�肳�ꂽ�����ŁA�����`�[�͑��݂��܂���ł����B";
                    return st;
                }

				// �������DetaSet�����X�V�t���O�Z�b�g����
				this.SetDepositDataSetClosedFlg();

				// ����������f�[�^�Z�b�g�ēo�^����
				this.ResetDsDmdSalesInfo();

			}
			catch ( DepositException ex )
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return st;
		}

		/// <summary>
		/// �����֘A�f�[�^�擾�����i����������̂ݎ擾�j
		/// </summary>
		/// <param name="searchSalesParameter">����������擾�p�p�����[�^ �N���X</param>
		/// <param name="message">�G���[���������b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�p�����[�^�̐�����������擾���A�ȉ��̃f�[�^�Z�b�g�ɂĕԂ��܂��B
		///					:   �� ���������� : Method : GetDsDmdSalesInfo</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int SearchSalesOnlyMode(SearchSalesParameter searchSalesParameter, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
				// �󒍏��DataSet����������
				this.ClearDmdSalesInfo();

				// ����������擾����
                // �� 20070122 18322 c MA.NS�p�ɕύX
                #region SF ����������擾����(�S�ăR�����g�A�E�g)
                //st = this.GetDmdSalesInfo(searchSalesParameter);
				//if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
				//{
				//	message = "�w�肳�ꂽ�����ŁA�󒍓`�[�͑��݂��܂���ł����B";
				//	return st;
				//}
                #endregion

				st = this.GetClaimSalesInfo(searchSalesParameter);
				if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
				{
					message = "�w�肳�ꂽ�����ŁA����`�[�͑��݂��܂���ł����B";
					return st;
				}
                // �� 20070122 18322 c

				// ����������DetaSet�����X�V�t���O�Z�b�g����
				this.SetDmdSalesDataSetClosedFlg();
			}
			catch ( DepositException ex )
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return st;
		}
        
        /// <summary>
		/// �������z���擾����
		/// </summary>
		/// <param name="searchCustomerParameter">���Ӑ���/���Ӑ���z���擾�p�p�����[�^ �N���X</param>
		/// <param name="depositCustDmdPrc">�������Ӑ搿�����z���N���X</param>
		/// <param name="message">�G���[���������b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�p�����[�^�̐������z�����擾���Ԃ��܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int ReadCustomDemandInfo(SearchCustomerParameter searchCustomerParameter, out DepositCustDmdPrc depositCustDmdPrc, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";
			depositCustDmdPrc = null;

			try
			{
				// �������Ӑ搿�����z���N���X����������
				this.ClearDepositCustDmdPrc();

				// ���Ӑ���/�������z���擾����
				st = this.GetCustomDemandInfo2(searchCustomerParameter, out depositCustDmdPrc);
				if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
				{
					message = "�w�肳�ꂽ�����ŁA�������z���͑��݂��܂���ł����B";
					return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}

			}
			catch ( DepositException ex )
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return st;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        /// <summary>
        /// �������V�K�s�ǉ�����
        /// </summary>
        /// <returns>�������V�KDataRow</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : ��������DataRow��V�K�쐬���Ԃ��܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2012/09/21 �c����</br>
        /// <br>�Ǘ��ԍ�    : 2012/10/17�z�M��</br>
        /// <br>              Redmine#32415 ���s�҂̒ǉ��Ή�</br>
        /// <br>Update Note: 2012/12/24 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// </remarks>
        public DataRow DepositNewRow()
        {
            // �������(��ʗp)�̍s��ǉ�����
            DataRow drNew = this._dsDepositInfo.Tables[ctDepositDataTable].NewRow();

            drNew[ctDepositDebitNoteCd] = 0;                                                        // �����ԍ��敪
            drNew[ctDepositDebitNoteNm] = "";                                                       // �����ԍ�����
            drNew[ctDepositSlipNo] = 0;                                                             // �����`�[�ԍ�
            drNew[ctDepositAcptAnOdrStatus] = 30;                                                    // �󒍃X�e�[�^�X
            drNew[ctSalesSlipNum] = "";                                                             // ����`�[�ԍ�
            drNew[ctDebitNoteLinkDepoNo] = 0;                                                       // �ԍ������A���ԍ�
            drNew[ctDepositDateDisp] = TDateTime.GetSFDateNow().ToString("yyyy/MM/dd");             // �������t(�\���p)
            drNew[ctDepositDate] = TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow());          // �������t
            drNew[ctDepositAddUpADateDisp] = TDateTime.GetSFDateNow().ToString("yyyy/MM/dd");       // �v����t(�\���p)
            drNew[ctDepositAddUpADate] = TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow());    // �v����t
            drNew[ctAutoDepositCd] = 0;                                                             // ���������敪
            drNew[ctDepositNm] = "�ʏ����";                                                        // �a����敪����
            drNew[ctDepositKindName] = "";                                                          // ��������
            drNew[ctDeposit] = 0;                                                                   // ���� �����z
            drNew[ctFeeDeposit] = 0;                                                                // ���� �萔��
            drNew[ctDiscountDeposit] = 0;                                                           // ���� �l��
            drNew[ctAllowDiv] = "";                                                                 // ����    // ADD 2010/12/20
            drNew[ctDepositTotal] = 0;                                                              // ���� �����v
            drNew[ctDepositAllowance_Deposit] = 0;                                                  // ���������z ����
            drNew[ctDepositAlwcBlnce_Deposit] = 0;                                                  // ���������c ����
            drNew[ctDraftDrawingDate] = 0;                                                          // ��`�U�o��
            drNew[ctBankCode] = 0;                                                                  // ��s�R�[�h
            drNew[ctDraftNo] = "";                                                                  // ��`�ԍ�
            drNew[ctDraftKind] = 0;                                                                 // ��`��ރR�[�h
            drNew[ctDraftDivide] = 0;                                                               // ��`�敪�R�[�h
            drNew[ctOutline] = "";                                                                  // �E�v
            drNew[ctDepositClosedFlg] = "";                                                         // ���t���O
            drNew[ctDepositRowNo1] = 0;                                                             // �����s�ԍ�1
            drNew[ctMoneyKindCode1] = 0;                                                            // ����R�[�h1
            drNew[ctMoneyKindName1] = "";                                                           // ���햼��1
            drNew[ctMoneyKindDiv1] = 0;                                                             // ����敪1
            drNew[ctDeposit1] = 0;                                                                  // �������z1
            drNew[ctValidityTerm1] = DateTime.MinValue;                                             // �L������1
            drNew[ctDepositRowNo2] = 0;                                                             // �����s�ԍ�2
            drNew[ctMoneyKindCode2] = 0;                                                            // ����R�[�h2
            drNew[ctMoneyKindName2] = "";                                                           // ���햼��2
            drNew[ctMoneyKindDiv2] = 0;                                                             // ����敪2
            drNew[ctDeposit2] = 0;                                                                  // �������z2
            drNew[ctValidityTerm2] = DateTime.MinValue;                                             // �L������2
            drNew[ctDepositRowNo3] = 0;                                                             // �����s�ԍ�3
            drNew[ctMoneyKindCode3] = 0;                                                            // ����R�[�h3
            drNew[ctMoneyKindName3] = "";                                                           // ���햼��3
            drNew[ctMoneyKindDiv3] = 0;                                                             // ����敪3
            drNew[ctDeposit3] = 0;                                                                  // �������z3
            drNew[ctValidityTerm3] = DateTime.MinValue;                                             // �L������3
            drNew[ctDepositRowNo4] = 0;                                                             // �����s�ԍ�4
            drNew[ctMoneyKindCode4] = 0;                                                            // ����R�[�h4
            drNew[ctMoneyKindName4] = "";                                                           // ���햼��4
            drNew[ctMoneyKindDiv4] = 0;                                                             // ����敪4
            drNew[ctDeposit4] = 0;                                                                  // �������z4
            drNew[ctValidityTerm4] = DateTime.MinValue;                                             // �L������4
            drNew[ctDepositRowNo5] = 0;                                                             // �����s�ԍ�5
            drNew[ctMoneyKindCode5] = 0;                                                            // ����R�[�h5
            drNew[ctMoneyKindName5] = "";                                                           // ���햼��5
            drNew[ctMoneyKindDiv5] = 0;                                                             // ����敪5
            drNew[ctDeposit5] = 0;                                                                  // �������z5
            drNew[ctValidityTerm5] = DateTime.MinValue;                                             // �L������5
            drNew[ctDepositRowNo6] = 0;                                                             // �����s�ԍ�6
            drNew[ctMoneyKindCode6] = 0;                                                            // ����R�[�h6
            drNew[ctMoneyKindName6] = "";                                                           // ���햼��6
            drNew[ctMoneyKindDiv6] = 0;                                                             // ����敪6
            drNew[ctDeposit6] = 0;                                                                  // �������z6
            drNew[ctValidityTerm6] = DateTime.MinValue;                                             // �L������6
            drNew[ctDepositRowNo7] = 0;                                                             // �����s�ԍ�7
            drNew[ctMoneyKindCode7] = 0;                                                            // ����R�[�h7
            drNew[ctMoneyKindName7] = "";                                                           // ���햼��7
            drNew[ctMoneyKindDiv7] = 0;                                                             // ����敪7
            drNew[ctDeposit7] = 0;                                                                  // �������z7
            drNew[ctValidityTerm7] = DateTime.MinValue;                                             // �L������7
            drNew[ctDepositRowNo8] = 0;                                                             // �����s�ԍ�8
            drNew[ctMoneyKindCode8] = 0;                                                            // ����R�[�h8
            drNew[ctMoneyKindName8] = "";                                                           // ���햼��8
            drNew[ctMoneyKindDiv8] = 0;                                                             // ����敪8
            drNew[ctDeposit8] = 0;                                                                  // �������z8
            drNew[ctValidityTerm8] = DateTime.MinValue;                                             // �L������8
            drNew[ctDepositRowNo9] = 0;                                                             // �����s�ԍ�9
            drNew[ctMoneyKindCode9] = 0;                                                            // ����R�[�h9
            drNew[ctMoneyKindName9] = "";                                                           // ���햼��9
            drNew[ctMoneyKindDiv9] = 0;                                                             // ����敪9
            drNew[ctDeposit9] = 0;                                                                  // �������z9
            drNew[ctValidityTerm9] = DateTime.MinValue;                                             // �L������9
            drNew[ctDepositRowNo10] = 0;                                                             // �����s�ԍ�10
            drNew[ctMoneyKindCode10] = 0;                                                            // ����R�[�h10
            drNew[ctMoneyKindName10] = "";                                                           // ���햼��10
            drNew[ctMoneyKindDiv10] = 0;                                                             // ����敪10
            drNew[ctDeposit10] = 0;                                                                  // �������z10
            drNew[ctValidityTerm10] = DateTime.MinValue;                                             // �L������10

            // ADD 2010/03/25 MANTIS[15196]�F�����ꗗ��ʂɢ���͒S���ң��\���֕ύX ---------->>>>>
            drNew[ctDepositInputAgentNm] = "";                                                      // �������͎Җ���
            // ADD 2010/03/25 MANTIS[15196]�F�����ꗗ��ʂɢ���͒S���ң��\���֕ύX ----------<<<<<

            //----- ADD 2012/09/21 �c���� redmine#32415 ---------->>>>>
            drNew[ctDepositInputEmpCd] = LoginInfoAcquisition.Employee.EmployeeCode.Trim();                // ���s�҃R�[�h
            drNew[ctDepositInputEmpNm] = LoginInfoAcquisition.Employee.Name.Trim();                        // ���s�Җ�
            //----- ADD 2012/09/21 �c���� redmine#32415 ----------<<<<<
            // -----ADD 2012/12/24 ���N Redmine#33741 ---------->>>>>
            drNew[ctCustomerCode] = 0;          // ���Ӑ�R�[�h
            drNew[ctCustomerName] = "";�@�@�@�@ // ���Ӑ於��
            // -----ADD 2012/12/24 ���N Redmine#33741 ----------<<<<<
            
            drNew[ctDepositDataRow] = drNew;                                                        // ���g��DataRow

            // �I���s���擾
            return drNew;
        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �������V�K�s�ǉ�����
		/// </summary>
		/// <returns>�������V�KDataRow</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : ��������DataRow��V�K�쐬���Ԃ��܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public DataRow DepositNewRow()
		{
			// �������(��ʗp)�̍s��ǉ�����
			DataRow drNew = this._dsDepositInfo.Tables[ctDepositDataTable].NewRow();

			// �����ԍ��敪
			drNew[ctDepositDebitNoteCd] = 0;

			// �����ԍ�����
			drNew[ctDepositDebitNoteNm] = "";

			// �����`�[�ԍ�
			drNew[ctDepositSlipNo] = 0;

            // �� 20070525 18322 a
			// �󒍔ԍ�
			// drNew[ctAcceptAnOrderNo] = 0;       // 2007.10.05 del
            // �� 20070525 18322 a

            // �󒍃X�e�[�^�X
            drNew[ctDepositAcptAnOdrStatus] = 0;   // 2007.10.05 add

            // ����`�[�ԍ�
            drNew[ctSalesSlipNum] = "";            // 2007.10.05 add

			// �ԍ������A���ԍ�
			drNew[ctDebitNoteLinkDepoNo] = 0;

            // �� 20070418 18322 c MA.NS�Ή�
			//// �������t(�\���p)
			//drNew[ctDepositDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd",TDateTime.GetSFDateNow());

			// �������t(�\���p)
			drNew[ctDepositDateDisp] = TDateTime.GetSFDateNow().ToString("yyyy/MM/dd");
            // �� 20070418 18322 c

			// �������t
			drNew[ctDepositDate] = TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow());

            // �v����t(�\���p)
            drNew[ctDepositAddUpADateDisp] = TDateTime.GetSFDateNow().ToString("yyyy/MM/dd");      // 2007.10.05 add

            // �v����t
            drNew[ctDepositAddUpADate] = TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow());   // 2007.10.05 add

   			// ���������敪
			drNew[ctAutoDepositCd] = 0;

			// �a����敪����
            //drNew[ctDepositCd] = 0;// DEL 2008/06/26
			drNew[ctDepositNm] = "�ʏ����";
            
            // ��������
			if ((depositRelDataAcs.InitSelMoneyKindCd != 0) && (depositRelDataAcs.HtMoneyKindDiv[depositRelDataAcs.InitSelMoneyKindCd] != null))
			{
                drNew[ctDepositKindDivCd] = (int)depositRelDataAcs.HtMoneyKindDiv[depositRelDataAcs.InitSelMoneyKindCd];
                drNew[ctDepositKindCode]  = depositRelDataAcs.InitSelMoneyKindCd;
                drNew[ctDepositKindName] = depositRelDataAcs.SlMoneyKindCode[depositRelDataAcs.InitSelMoneyKindCd];
                drNew[ctDepositKindName] = depositRelDataAcs.DicMoneyKindCode[depositRelDataAcs.InitSelMoneyKindCd];
			}
			else
			{
				drNew[ctDepositKindDivCd] = 0;
				drNew[ctDepositKindCode]  = 0;
                
                drNew[ctDepositKindName]  = "";
			}

            // �� 20070118 18322 d MA.NS�p�ɕύX
            #region SF �󒍁E����p�i�S�ăR�����g�A�E�g�j
            //// �� �����z
			//drNew[ctAcpOdrDeposit] = 0;
            //
			//// �� �萔��
			//drNew[ctAcpOdrChargeDeposit] = 0;
            //
			//// �� �l��
			//drNew[ctAcpOdrDisDeposit] = 0;
            //
			//// �� �����v
			//drNew[ctAcpOdrDepositTotal] = 0;
            //
			//// ����p �����z
			//drNew[ctVariousCostDeposit] = 0;
            //
			//// ����p �萔��
			//drNew[ctVarCostChargeDeposit] = 0;
            //
			//// ����p �l��
			//drNew[ctVarCostDisDeposit] = 0;
            //
			//// ����p �����v
            //drNew[ctVariousCostDepositTotal] = 0;
            #endregion
            // �� 20070118 18322 d

			// ���� �����z
			drNew[ctDeposit] = 0;

			// ���� �萔��
			drNew[ctFeeDeposit] = 0;

			// ���� �l��
			drNew[ctDiscountDeposit] = 0;

            // �� 20070118 18322 a
			// ���� �C���Z���e�B�u
			// drNew[ctRebateDeposit] = 0;   // 2007.10.05 hikita del
            // �� 20070118 18322 a

			// ���� �����v
			drNew[ctDepositTotal] = 0;

            // �� 20070118 18322 d MA.NS�p�ɕύX
            #region SF �󒍁E����p�i�S�ăR�����g�A�E�g�j
            //// ���������z ��
			//drNew[ctAcpOdrDepositAlwc_Deposit] = 0;
            //
			//// ���������c ��
			//drNew[ctAcpOdrDepoAlwcBlnce_Deposit] = 0;
            //
			//// ���������z ����p
			//drNew[ctVarCostDepoAlwc_Deposit] = 0;
            //
			//// ���������c ����p
            //drNew[ctVarCostDepoAlwcBlnce_Deposit] = 0;
            #endregion
            // �� 20070118 18322 d

			// ���������z ����
			drNew[ctDepositAllowance_Deposit] = 0;

			// ���������c ����
			drNew[ctDepositAlwcBlnce_Deposit] = 0;

            // 2007.10.05 hikita del start ------------------------------->>
			// �N���W�b�g/���[���敪
			// drNew[ctCreditOrLoanCd] = 0;

			// �N���W�b�g��ЃR�[�h
			// drNew[ctCreditCompanyCode] = "";
            // 2007.10.05 hikita del end ---------------------------------<<

			// ��`�U�o��
			drNew[ctDraftDrawingDate] = 0;

			// ��`�x������
			drNew[ctDraftPayTimeLimit] = 0;
            
            // 2007.10.05 hikita add start ------------------------------->>
            // ��s�R�[�h
            drNew[ctBankCode] = 0;

            // ��`�ԍ�
            drNew[ctDraftNo] = "";

            // ��`��ރR�[�h
            drNew[ctDraftKind] = 0;

            // ��`�敪�R�[�h
            drNew[ctDraftDivide] = 0;
            // 2007.10.05 hikita add end ---------------------------------<<

			// �E�v
			drNew[ctOutline] = "";

			// ���t���O
			drNew[ctDepositClosedFlg] = "";

			// ���g��DataRow
			drNew[ctDepositDataRow] = drNew;

			// �I���s���擾
			return drNew;
		}

           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        // �� 20070202 18322 c MA.NS�p�ɕύX
        #region SF �������V�K�s�ǉ������i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// �������V�K�s�ǉ�����
		///// </summary>
		///// <param name="depositSlipNo">�����ԍ�</param>
		///// <param name="acceptAnOrderNo">�󒍔ԍ�</param>
		///// <param name="depositDate">������</param>
		///// <returns>�������V�KDataRow</returns>
		///// <remarks>
		///// <br>Note�@�@�@  : ��������DataRow��V�K�쐬���Ԃ��܂��B</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
        ///// <br>Update Note : 2007.01.22 18322 T.Kimura</br>
        ///// <br>                MA.NS�p�ɕύX</br>
        ///// <br></br>
		///// </remarks>
        //public System.Data.DataRow AllowanceNewRow(int depositSlipNo, int acceptAnOrderNo, int depositDate)
		//{
		//	// �������DataRow���������͐V�K�Ƃ��Ēǉ�����
		//	DataRow drNew = this._dsDepositInfo.Tables[ctAllowanceDataTable].NewRow();
		//
		//	// �����`�[�ԍ�
		//	drNew[ctDepositSlipNo_Alw] = depositSlipNo;
		//
		//	// �󒍓`�[�ԍ�
		//	drNew[ctAcceptAnOrderNo_Alw] = acceptAnOrderNo;
		//
		//	// ���������z ��
		//	drNew[ctAcpOdrDepositAlwc] = 0;
		//
		//	// ���������z ����p
		//	drNew[ctVarCostDepoAlwc] = 0;
		//	
		//	// ���������z ����
		//	drNew[ctDepositAllowance] = 0;
		//
		//	// ������(�\���p)
		//	drNew[ctReconcileDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd",TDateTime.GetSFDateNow());
		//
		//	// ������
		//	drNew[ctReconcileDate] = TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow());
		//
		//	// �����v����t
		//	drNew[ctReconcileAddUpDate] = depositDate; 
		//
		//	// �I���s���擾
		//	return drNew;
		//}
        #endregion

        /// <summary>
		/// �������V�K�s�ǉ�����
		/// </summary>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="depositSlipNo">�����ԍ�</param>
		/// <param name="salesSlipNum">����`�[�ԍ�</param>
		/// <param name="depositDate">������</param>
		/// <returns>�������V�KDataRow</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : ��������DataRow��V�K�쐬���Ԃ��܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
        /// <br>Update Note : 2007.02.02 18322 T.Kimura</br>
        /// <br>                MA.NS�p�ɕύX</br>
        /// <br></br>
		/// </remarks>
        // public System.Data.DataRow AllowanceNewRow(int depositSlipNo, int acceptAnOrderNo, string salesSlipNum, int depositDate)  // 2007.10.05 del
        public DataRow AllowanceNewRow(int acptAnOdrStatus, int depositSlipNo, string salesSlipNum, int depositDate)     // 2007.10.05 add
		{
			// �������DataRow���������͐V�K�Ƃ��Ēǉ�����
			DataRow drNew = this._dsDepositInfo.Tables[ctAllowanceDataTable].NewRow();

			// �����`�[�ԍ�
			drNew[ctDepositSlipNo_Alw] = depositSlipNo;

			// �󒍓`�[�ԍ�
			//drNew[ctAcceptAnOrderNo_Alw] = acceptAnOrderNo;  // 2007.10.05 del

            // �󒍃X�e�[�^�X
            drNew[ctAcptAnOdrStatus_Alw] = acptAnOdrStatus;    // 2007.10.05 add
            
			// ����`�[�ԍ�
			drNew[ctSalesSlipNum] = salesSlipNum;
			
			// ���������z ����
			drNew[ctDepositAllowance] = 0;

            // �� 20070418 18322 c MA.NS�Ή�
			//// ������(�\���p)
			//drNew[ctReconcileDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd",TDateTime.GetSFDateNow());

			// ������(�\���p)
			drNew[ctReconcileDateDisp] = TDateTime.GetSFDateNow().ToString("yyyy/MM/dd");
            // �� 20070418 18322 c

			// ������
			drNew[ctReconcileDate] = TDateTime.DateTimeToLongDate(TDateTime.GetSFDateNow());

			// �����v����t
			drNew[ctReconcileAddUpDate] = depositDate; 

			// �I���s���擾
			return drNew;
		}
        // �� 20070202 18322 c
		
		/// <summary>
		/// �������̐���������W�J����
		/// </summary>
		/// <param name="dr">�I���������DataRow</param>
		/// <remarks>
		/// <br>Note       : �������𐿋�������̓��������z���ɓW�J���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public void ExpandAllowanceRelationData(ArrayList dr)
		{
			// ����������DetaSet�����������N���A����
			this.DmdSalesDepositAllowanceClear();

			// ������񂪖������͏����𔲂���
			if (dr.Count == 0) return;

			// �������DataRow�̎擾
			foreach (DataRow drChild in dr)
			{
				// ����������DataRow�̎擾
				foreach (DataRow drSales in _dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
				{
					// ����󒍔ԍ��̎��A�������z��W�J����
					//if (Convert.ToInt32(drChild[ctAcceptAnOrderNo_Alw]) == Convert.ToInt32(drSales[ctAcceptAnOrderNo]))  // 2007.10.05 del
                    // ���ꔄ��ԍ��̎��A�������z��W�J����
                    if (Convert.ToInt32(drChild[ctSalesSlipNum_Alw]) == Convert.ToInt32(drSales[ctSalesSlipNum]))          // 2007.10.05 add
					{
						// ��
						drSales[ctAlwCheck] = true;

                        // �� 20070118 18322 d MA.NS�p�ɕύX
						//// �����z �� (���������}�X�^)
						//drSales[ctAcpOdrDepositAlwc_Alw] = Convert.ToInt64(drChild[ctAcpOdrDepositAlwc]);
                        //
						//// �����z ����p (���������}�X�^)
						//drSales[ctVarCostDepoAlwc_Alw] = Convert.ToInt64(drChild[ctVarCostDepoAlwc]);
                        // �� 20070118 18322 d

						// �����z ���� (���������}�X�^)
						drSales[ctDepositAllowance_Alw] = Convert.ToInt64(drChild[ctDepositAllowance]);
					}
				}
			}
		}

		/// <summary>
		/// ��������f�[�^�̃X�e�[�^�X���擾���܂��B
		/// </summary>
        /// <param name="salesSlipNum">����ԍ�</param>
		/// <param name="creditSales">�|���t���O�itrue:�|���Afalse:�|���ȊO�j</param>
		/// <remarks>
		/// <br>Note       : ��������f�[�^�̃X�e�[�^�X���擾���܂��B</br>
		/// <br>Programmer : 18322 T.Kimura</br>
		/// <br>Date       : 20070525</br>
		/// </remarks>
		// public void GetDmdSalesStatus(int acceptAnOrderNo, out bool posInput, out bool creditSales)   // 2007.10.05 del
        public void GetDmdSalesStatus(string salesSlipNum, out bool creditSales)                         // 2007.10.05 add
		{
			// posInput = false;    // 2007.10.05 del
			creditSales = false;
			
			// ����������DataRow�̎擾
			foreach (DataRow drSales in _dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
			{
                // 2007.10.05 del start --------------------------------------->>
                //if (acceptAnOrderNo != Convert.ToInt32(drSales[ctAcceptAnOrderNo]))
                //{
                //    // ����󒍔ԍ��łȂ���Γǂݔ�΂�
                //    continue;
                //}
			    
                //// POS���͂��`�F�b�N
                //if (Convert.ToInt32(drSales[ctPosReceiptNo]) > 0)
                //{
                //    // POS���V�[�g�ԍ��������Ă���ꍇ��POS����
                //    posInput = true;
                //}
                // 2007.10.05 del end -----------------------------------------<<
			    
                // 2007.10.05 add start --------------------------------------->>
                if (salesSlipNum != Convert.ToString(drSales[ctSalesSlipNum]))
                {
                    // ���ꔄ��ԍ��łȂ���Γǂݔ�΂�
                    continue;
                }
                // 2007.10.05 add end -----------------------------------------<<

			    // �|�����`�F�b�N
			    if (Convert.ToInt32(drSales[ctAccRecDivCd]) == 1)
			    {
			        // �|���敪��1:�|��
			        creditSales = true;
			    }
			    
			    break;
			}
		}

        // �� 20070118 18322 d MA.NS�p�ɕύX
        #region SF �������z �� �ύX�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// �������z �� �ύX����
		///// </summary>
		///// <param name="acpOdrDeposit">�� �����z</param>
		///// <param name="acpOdrChargeDeposit">�� �萔��</param>
		///// <param name="acpOdrDisDeposit">�� �l��</param>
		///// <param name="drDeposit">�������DataRow</param>
		///// <returns>�������v ��</returns>
		///// <remarks>
		///// <br>Note       : �� �����z �̕ύX���e���e�ɔ��f���܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 ChangeAcpOdrDepositSection(Int64 acpOdrDeposit, Int64 acpOdrChargeDeposit, Int64 acpOdrDisDeposit, ref System.Data.DataRow drDeposit)
		//{
		//	// �� �����z
		//	drDeposit[ctAcpOdrDeposit] = acpOdrDeposit;
        //
		//	// �� �萔��
		//	drDeposit[ctAcpOdrChargeDeposit] = acpOdrChargeDeposit;
        //
		//	// �� �l��
		//	drDeposit[ctAcpOdrDisDeposit] = acpOdrDisDeposit;
        //
		//	Int64 total = acpOdrDeposit + acpOdrChargeDeposit + acpOdrDisDeposit;
        //
		//	// �������v ��
		//	drDeposit[ctAcpOdrDepositTotal] = total;
        //
		//	// ���������c �� (�������v �� - ���������z ��)
		//	drDeposit[ctAcpOdrDepoAlwcBlnce_Deposit] = total - Convert.ToInt64(drDeposit[ctAcpOdrDepositAlwc_Deposit]);
        //
		//	return total;
        //}
        #endregion
        // �� 20070118 18322 d

        // �� 20070118 18322 d MA.NS�p�ɕύX
        #region SF �������z ����p �ύX�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// �������z ����p �ύX����
		///// </summary>
		///// <param name="variousCostDeposit">����p �����z</param>
		///// <param name="varCostChargeDeposit">����p �萔��</param>
		///// <param name="varCostDisDeposit">����p �l��</param>
		///// <param name="drDeposit">�������DataRow</param>
		///// <returns>�������v ����p</returns>
		///// <remarks>
		///// <br>Note       : ����p �����z �̕ύX���e���e�ɔ��f���܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 ChangeCostDepositSection(Int64 variousCostDeposit, Int64 varCostChargeDeposit, Int64 varCostDisDeposit, ref System.Data.DataRow drDeposit)
		//{
		//	// ����p �����z
		//	drDeposit[ctVariousCostDeposit] = variousCostDeposit;
        //
		//	// ����p �萔��
		//	drDeposit[ctVarCostChargeDeposit] = varCostChargeDeposit;
        //
		//	// ����p �l��
		//	drDeposit[ctVarCostDisDeposit] = varCostDisDeposit;
        //
		//	Int64 total = variousCostDeposit + varCostChargeDeposit + varCostDisDeposit;
        //
		//	// �������v ����p
		//	drDeposit[ctVariousCostDepositTotal] = total;
        //
		//	// ���������c ����p (�������v ����p - ���������z ����p)
		//	drDeposit[ctVarCostDepoAlwcBlnce_Deposit] = total - Convert.ToInt64(drDeposit[ctVarCostDepoAlwc_Deposit]);
        //
		//	return total;
        //}
        #endregion
        // �� 20070118 18322 d

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        // 2007.10.05 hikita upd start DC.NS�p�Ɍ��̃��\�b�h�ɕ���(MA.NS�p�͎g�p���Ȃ�)
        // �� 20070118 18322 c MA.NS�p�ɍ�蒼��
        #region SF �������z ���� �ύX�����i�S�ăR�����g�A�E�g�j
        /// <summary>
		/// �������z ���� �ύX����
		/// </summary>
		/// <param name="deposit">���� �����z</param>
		/// <param name="feeDeposit">���� �萔��</param>
		/// <param name="discountDeposit">���� �l��</param>
		/// <param name="drDeposit">�������DataRow</param>
		/// <returns>�������v ����</returns>
		/// <remarks>
		/// <br>Note       : ���� �����z �̕ύX���e���e�ɔ��f���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public Int64 ChangeDepositSection(Int64 deposit, Int64 feeDeposit, Int64 discountDeposit, ref DataRow drDeposit)
		{
			// ���� �����z
			drDeposit[ctDeposit] = deposit;
        
			// ���� �萔��
			drDeposit[ctFeeDeposit] = feeDeposit;
        
			// ���� �l��
			drDeposit[ctDiscountDeposit] = discountDeposit;
        
			Int64 total = deposit + feeDeposit + discountDeposit;
        
			// �������v ����
			drDeposit[ctDepositTotal] = total;
        
			// ���������c ���� (�������v ���� - ���������z ����)
			drDeposit[ctDepositAlwcBlnce_Deposit] = total - Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]);
        
			return total;
        }
        #endregion
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        #region 2007.10.05 hikita del
        ///// <summary>
        ///// �������z ���� �ύX����
        ///// </summary>
        ///// <param name="deposit">���� �����z</param>
        ///// <param name="feeDeposit">���� �萔��</param>
        ///// <param name="discountDeposit">���� �l��</param>
        ///// <param name="rebateDeposit">���� �C���Z���e�B�u</param>
        ///// <param name="drDeposit">�������DataRow</param>
        ///// <returns>�������v ����</returns>
        ///// <remarks>
        ///// <br>Note       : ���� �����z �̕ύX���e���e�ɔ��f���܂��B</br>
        ///// <br>Programmer : 18322 T.Kimura</br>
        ///// <br>Date       : 2007.01.18</br>
        ///// </remarks>
        //public Int64 ChangeDepositSection(Int64 deposit, Int64 feeDeposit, Int64 discountDeposit, Int64 rebateDeposit, ref System.Data.DataRow drDeposit)
        //{
        //    // ���� �����z
        //    drDeposit[ctDeposit] = deposit;

        //    // ���� �萔��
        //    drDeposit[ctFeeDeposit] = feeDeposit;

        //    // ���� �l��
        //    drDeposit[ctDiscountDeposit] = discountDeposit;

        //    // ���� �C���Z���e�B�u
        //    drDeposit[ctRebateDeposit] = rebateDeposit;

        //    Int64 total = deposit + feeDeposit + discountDeposit + rebateDeposit;

        //    // �������v ����
        //    drDeposit[ctDepositTotal] = total;

        //    // ���������c ���� (�������v ���� - ���������z ����)
        //    drDeposit[ctDepositAlwcBlnce_Deposit] = total
        //                                          - Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]);

        //    return total;
        //}
        // �� 20070118 18322 c
        // 2007.10.05 hikita upd end ----------------------------------------------------<<
        #endregion 2007.10.05 hikita del

        // �� 20070118 18322 d MA.NS�p�ɕύX
        #region SF ����������� �� �ύX�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// ����������� �� �ύX����
		///// </summary>
		///// <param name="difference">�����ύX�O�㍷�z</param>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <param name="drDeposit">�������DataRow</param>
		///// <param name="flgAcpOdrDepositAlwc_Alw">�����c �� (���������z) �X�V�t���O</param>
		///// <param name="flgAcpOdrDepoAlwcBlnce_Sales">�����c �� (��������}�X�^) �X�V�t���O</param>
		///// <param name="flgAcpOdrDepositAlwc_Sales">������ �� (��������}�X�^) �X�V�t���O</param>
		///// <returns>�������̓����������z</returns>
		///// <remarks>
		///// <br>Note       : �����z �� �̕ύX���e���e�ɔ��f���܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 UpdateAcpOdrDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales, ref System.Data.DataRow drDeposit, bool flgAcpOdrDepositAlwc_Alw, bool flgAcpOdrDepoAlwcBlnce_Sales, bool flgAcpOdrDepositAlwc_Sales)
		//{
		//	// �����c �� (���������z) ���X�V����
		//	if (flgAcpOdrDepositAlwc_Alw)
		//	{
		//		drDmdSales[ctAcpOdrDepositAlwc_Alw] = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Alw]) + difference;
		//	}
        //
		//	// �����c �� (��������}�X�^) ���X�V����
		//	if (flgAcpOdrDepoAlwcBlnce_Sales)
		//	{
		//		drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales]) - difference;
		//	}
        //
		//	// ������ �� (��������}�X�^) ���X�V����
		//	if (flgAcpOdrDepositAlwc_Sales)
		//	{
		//		drDmdSales[ctAcpOdrDepositAlwc_Sales] = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Sales]) + difference;
		//	}
        //
		//	// ������� ���������z �� ���X�V����
		//	drDeposit[ctAcpOdrDepositAlwc_Deposit] = Convert.ToInt64(drDeposit[ctAcpOdrDepositAlwc_Deposit]) + difference;
        //
		//	// ������� ���������c �� ���X�V����
		//	drDeposit[ctAcpOdrDepoAlwcBlnce_Deposit] = Convert.ToInt64(drDeposit[ctAcpOdrDepoAlwcBlnce_Deposit]) - difference;
        //
		//	// ���������c �� ��߂�
		//	return Convert.ToInt64(drDeposit[ctAcpOdrDepoAlwcBlnce_Deposit]);
        //}
        #endregion
        // �� 20070118 18322 d

        // �� 20070118 18322 d MA.NS�p�ɕύX
        #region SF ����������� ����p �ύX����(�S�ăR�����g�A�E�g)
        ///// <summary>
		///// ����������� ����p �ύX����
		///// </summary>
		///// <param name="difference">�����ύX�O�㍷�z</param>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <param name="drDeposit">�������DataRow</param>
		///// <param name="flgVarCostDepoAlwc_Alw">�����c ����p (���������z) �X�V�t���O</param>
		///// <param name="flgVarCostDepoAlwcBlnce_Sales">�����c ����p (��������}�X�^) �X�V�t���O</param>
		///// <param name="flgVarCostDepoAlwc_Sales">������ ����p (��������}�X�^) �X�V�t���O</param>
		///// <returns>�������̓����������z</returns>
		///// <remarks>
		///// <br>Note       : �����z ����p �̕ύX���e���e�ɔ��f���܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 UpdateCostDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales, ref System.Data.DataRow drDeposit, bool flgVarCostDepoAlwc_Alw, bool flgVarCostDepoAlwcBlnce_Sales, bool flgVarCostDepoAlwc_Sales)
		//{
		//	// �����z ����p (���������z) ���X�V����
		//	if (flgVarCostDepoAlwc_Alw)
		//	{
		//		drDmdSales[ctVarCostDepoAlwc_Alw] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Alw]) + difference;
		//	}
        //
		//	// �����c ����p (��������}�X�^) ���X�V����
		//	if (flgVarCostDepoAlwcBlnce_Sales)
		//	{
		//		drDmdSales[ctVarCostDepoAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwcBlnce_Sales]) - difference;
		//	}
        //
		//	// ������ ����p (��������}�X�^) ���X�V����
		//	if (flgVarCostDepoAlwc_Sales)
		//	{
		//		drDmdSales[ctVarCostDepoAlwc_Sales] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Sales]) + difference;
		//	}
        //
		//	// ������� ���������z ����p ���X�V����
		//	drDeposit[ctVarCostDepoAlwc_Deposit] = Convert.ToInt64(drDeposit[ctVarCostDepoAlwc_Deposit]) + difference;
        //    
		//	// ������� ���������c ����p ���X�V����
		//	drDeposit[ctVarCostDepoAlwcBlnce_Deposit] = Convert.ToInt64(drDeposit[ctVarCostDepoAlwcBlnce_Deposit]) - difference;
        //
		//	// ���������c ����p ��߂�
		//	return Convert.ToInt64(drDeposit[ctVarCostDepoAlwcBlnce_Deposit]);
		//}
        #endregion
        // �� 20070118 18322 d

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ����������� ���� �ύX����
        /// </summary>
        /// <param name="difference">�����ύX�O�㍷�z</param>
        /// <param name="drDmdSales">����������DataRow</param>
        /// <param name="drDeposit">�������DataRow</param>
        /// <param name="flgDepositAllowance_Alw">�����c ���� (���������}�X�^) �X�V�t���O</param>
        /// <param name="flgDepositAlwcBlnce_Sales">�����c ���� (��������}�X�^) �X�V�t���O</param>
        /// <returns>�������̓����������z</returns>
        /// <remarks>
        /// <br>Note       : �����z ���� �̕ύX���e���e�ɔ��f���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        public Int64 UpdateDepositAlwc(Int64 difference, ref DataRow drDmdSales, ref DataRow drDeposit, bool flgDepositAllowance_Alw, bool flgDepositAlwcBlnce_Sales)
        {
            if (flgDepositAllowance_Alw)   // ON
            {
                // ���������z(�����}�X�^)
                drDmdSales[ctDepositAllowance_Alw] = 0;

                // ���������c(��������}�X�^)
                drDmdSales[ctDepositAlwcBlnce_Sales] = difference;

                // ����������(��������}�X�^)
                drDmdSales[ctDepositAllowance_Sales] = 0;
                
                //// ������� ���������z ���� ���X�V����
                //drDeposit[ctDepositAllowance_Deposit] = Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]) + Convert.ToInt64(drDmdSales[ctDepositAllowance_Alw]);
            }

            if (flgDepositAlwcBlnce_Sales) // ���͒�
            {
                // ���������z
                drDmdSales[ctDepositAllowance_Alw] = Convert.ToInt64(drDmdSales[ctDepositAllowance_Alw]) + difference;

                // ���������c
                drDmdSales[ctDepositAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctDepositAlwcBlnce_Sales]) - difference;

                // ����������
                drDmdSales[ctDepositAllowance_Sales] = Convert.ToInt64(drDmdSales[ctDepositAllowance_Sales]) + difference;

                // ������� ���������z ���� ���X�V����
                drDeposit[ctDepositAllowance_Deposit] = Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]) + difference;
            }

            return Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]);
        }

        /// <summary>
        /// �������X�V����
        /// </summary>
        /// <param name="acpOdrDepositAlwc">���������z ��</param>
        /// <param name="varCostDepoAlwc">���������z ����p</param>
        /// <param name="depositAllowance">���������z ����</param>
        /// <param name="drDmdSales">����������DataRow</param>
        /// <param name="drDeposit">�������DataRow</param>
        /// <param name="drAllowance">�������DataRow</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �������̈����z���X�V���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public void UpdateAllowance(Int64 acpOdrDepositAlwc, Int64 varCostDepoAlwc, Int64 depositAllowance, DataRow drDmdSales, DataRow drDeposit, ref ArrayList drAllowance)
        {
            // �������DataRow�̎擾
            foreach (DataRow drChild in drAllowance)
            {
                // ���ꔄ��ԍ��̎�
                if (Convert.ToInt32(drChild[ctSalesSlipNum_Alw]) == Convert.ToInt32(drDmdSales[ctSalesSlipNum]))
                {
                    if ((acpOdrDepositAlwc == 0) && (varCostDepoAlwc == 0) && (depositAllowance == 0))
                    {
                        // �����z0�~�̎��͍폜
                        drAllowance.Remove(drChild);
                    }
                    else
                    {
                        // ���������z
                        drChild[ctDepositAllowance] = depositAllowance;
                    }

                    return;
                }
            }

            //// ����󒍔ԍ��s�������Ă������z0�~�̎��͐V�K�s�͒ǉ������ɖ�������
            //if ((acpOdrDepositAlwc == 0) && (varCostDepoAlwc == 0) && (depositAllowance == 0)) return;

            // �������V�K�s�ǉ�����  �������DataRow���������͐V�K�Ƃ��Ēǉ�����
            DataRow drNewAlw = this.AllowanceNewRow(Convert.ToInt32(drDmdSales[ctAcptAnOdrStatus_Alw])
                                                   , Convert.ToInt32(drDeposit[ctDepositSlipNo])
                                                   , drDmdSales[ctSalesSlipNum].ToString()
                                                   , Convert.ToInt32(drDeposit[ctDepositAddUpADate]));
            
            // ���������z
            drNewAlw[ctDepositAllowance] = depositAllowance;

            // �V�K�ǉ�
            drAllowance.Add(drNewAlw);
        }

        /// <summary>
        /// �����ϋ��z���݃`�F�b�N
        /// </summary>
        /// <param name="selectedDmdSalesRow">�I���s(����������DataRow)</param>
        /// <returns>�X�e�[�^�X(True:���݁@False�F���݂���)</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �����ϋ��z�����݂��邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public bool CheckExistAllowanceSales(DataRow selectedDmdSalesRow)
        {
            if (selectedDmdSalesRow[ctDepositAllowance_Sales] == DBNull.Value)
            {
                return (false);
            }

            if ((Int64)selectedDmdSalesRow[ctDepositAllowance_Sales] == 0)
            {
                return (false);
            }

            return (true);
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/06/26 Parsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ����������� ���� �ύX����
		/// </summary>
		/// <param name="difference">�����ύX�O�㍷�z</param>
		/// <param name="drDmdSales">����������DataRow</param>
		/// <param name="drDeposit">�������DataRow</param>
		/// <param name="flgDepositAllowance_Alw">�����c ���� (���������}�X�^) �X�V�t���O</param>
		/// <param name="flgDepositAlwcBlnce_Sales">�����c ���� (��������}�X�^) �X�V�t���O</param>
		/// <param name="flgDepositAllowance_Sales">������ ���� (��������}�X�^) �X�V�t���O</param>
		/// <returns>�������̓����������z</returns>
		/// <remarks>
		/// <br>Note       : �����z ���� �̕ύX���e���e�ɔ��f���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public Int64 UpdateDepositAlwc(Int64 difference, ref DataRow drDmdSales, ref DataRow drDeposit, bool flgDepositAllowance_Alw, bool flgDepositAlwcBlnce_Sales, bool flgDepositAllowance_Sales)
		{
            //// �����z ���� (���������}�X�^)���X�V����
            //if (flgDepositAllowance_Alw)
            //{
            //    drDmdSales[ctDepositAllowance_Alw] = Convert.ToInt64(drDmdSales[ctDepositAllowance_Alw]) + difference;
            //}

            //// �����c ���� (��������}�X�^) ���X�V����
            //if (flgDepositAlwcBlnce_Sales)
            //{
            //    drDmdSales[ctDepositAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctDepositAlwcBlnce_Sales]) - difference;
            //}

            //// ������ ���� (��������}�X�^) ���X�V����
            //if (flgDepositAllowance_Sales)
            //{
            //    drDmdSales[ctDepositAllowance_Sales] = Convert.ToInt64(drDmdSales[ctDepositAllowance_Sales]) + difference;
            //}

            //// ������� ���������z ���� ���X�V����
            //drDeposit[ctDepositAllowance_Deposit] = Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]) + difference;

            //// ������� ���������c ���� ���X�V����
            //drDeposit[ctDepositAlwcBlnce_Deposit] = Convert.ToInt64(drDeposit[ctDepositAlwcBlnce_Deposit]) - difference;

            //// ���������c ���� ��߂�
            //return Convert.ToInt64(drDeposit[ctDepositAlwcBlnce_Deposit]);

            if (flgDepositAllowance_Alw)   // ON
            {
                drDmdSales[ctDepositAllowance_Alw] = 0;
                drDmdSales[ctDepositAlwcBlnce_Sales] = difference;
                drDmdSales[ctDepositAllowance_Sales] = 0;
                // ������� ���������z ���� ���X�V����
                drDeposit[ctDepositAllowance_Deposit] = Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]) + Convert.ToInt64(drDmdSales[ctDepositAllowance_Alw]);
            }

            if (flgDepositAlwcBlnce_Sales) // ���͒�
            {
                drDmdSales[ctDepositAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctTotalSales]) - difference;
                drDmdSales[ctDepositAllowance_Sales] = difference;
                // ������� ���������z ���� ���X�V����
                drDeposit[ctDepositAllowance_Deposit] = Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]) - difference;
            }

            if (flgDepositAllowance_Sales) // OFF
            {
                // �������Ȃ�
            }

            return Convert.ToInt64(drDeposit[ctDepositAllowance_Deposit]);
		}
		
		/// <summary>
		/// �������X�V����
		/// </summary>
		/// <param name="acpOdrDepositAlwc">���������z ��</param>
		/// <param name="varCostDepoAlwc">���������z ����p</param>
		/// <param name="depositAllowance">���������z ����</param>
		/// <param name="drDmdSales">����������DataRow</param>
		/// <param name="drDeposit">�������DataRow</param>
		/// <param name="drAllowance">�������DataRow</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �������̈����z���X�V���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void UpdateAllowance(Int64 acpOdrDepositAlwc, Int64 varCostDepoAlwc, Int64 depositAllowance, DataRow drDmdSales, DataRow drDeposit, ref ArrayList drAllowance)
		{
			// �������DataRow�̎擾
			foreach (DataRow drChild in drAllowance)
			{
				// ����󒍔ԍ��̎�
				// if (Convert.ToInt32(drChild[ctAcceptAnOrderNo_Alw]) == Convert.ToInt32(drDmdSales[ctAcceptAnOrderNo]))   // 2007.10.05 hikita del
                // ���ꔄ��ԍ��̎�
                if (Convert.ToInt32(drChild[ctSalesSlipNum_Alw]) == Convert.ToInt32(drDmdSales[ctSalesSlipNum]))            // 2007.10.05 hikita add
				{
					if ((acpOdrDepositAlwc == 0) && (varCostDepoAlwc == 0) && (depositAllowance == 0))
					{
						// �����z0�~�̎��͍폜
						drAllowance.Remove(drChild);
					}
					else
					{
                        // �� 20070118 18322 d MA.NS�p�ɕύX
						//// �����z�̍X�V
						//drChild[ctAcpOdrDepositAlwc] = acpOdrDepositAlwc;
						//drChild[ctVarCostDepoAlwc] = varCostDepoAlwc;
                        // �� 20070118 18322 d
						drChild[ctDepositAllowance] = depositAllowance;
					}

					return;
				}
			}

			// ����󒍔ԍ��s�������Ă������z0�~�̎��͐V�K�s�͒ǉ������ɖ�������
			if ((acpOdrDepositAlwc == 0) && (varCostDepoAlwc == 0) && (depositAllowance == 0)) return;

            // �� 20070202 18322 c MA.NS�p�ɕύX
            //// �������V�K�s�ǉ�����  �������DataRow���������͐V�K�Ƃ��Ēǉ�����
			//DataRow drNewAlw = this.AllowanceNewRow(Convert.ToInt32(drDeposit[ctDepositSlipNo]), Convert.ToInt32(drDmdSales[ctAcceptAnOrderNo]), Convert.ToInt32(drDeposit[ctDepositDate]));
            //
			//// ���������z
			//drNewAlw[ctAcpOdrDepositAlwc] = acpOdrDepositAlwc;
			//drNewAlw[ctVarCostDepoAlwc] = varCostDepoAlwc;

            // �������V�K�s�ǉ�����  �������DataRow���������͐V�K�Ƃ��Ēǉ�����
            DataRow drNewAlw = this.AllowanceNewRow(Convert.ToInt32(drDmdSales[ctAcptAnOdrStatus_Alw])
                                                   , Convert.ToInt32(drDeposit[ctDepositSlipNo])
            //                                       , Convert.ToInt32(drDmdSales[ctAcceptAnOrderNo])   // 2007.10.05 del
                                                   , drDmdSales[ctSalesSlipNum].ToString()
            //                                       , Convert.ToInt32(drDeposit[ctDepositDate]));      // 2007.10.05 del
                                                   , Convert.ToInt32(drDeposit[ctDepositAddUpADate]));  // 2007.10.05 add
            // �� 20070202 18322 c
			drNewAlw[ctDepositAllowance] = depositAllowance;

			// �V�K�ǉ�
			drAllowance.Add(drNewAlw);
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Parsman�p�ɕύX

        // �� 20070118 18322 d MA.NS�p�ɕύX
        #region SF ����������� �� �ύX�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// ����������� �� �ύX����
		///// </summary>
		///// <param name="difference">�����O��������z</param>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <param name="drDeposit">�������DataRow</param>
		///// <returns>�����������z</returns>
		///// <remarks>
		///// <br>Note       : ������� �� �̕ύX���e���e�ɔ��f���܂��B��������͈����c��0�~�܂łł��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 ZeroUpdateAcpOdrDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales, ref System.Data.DataRow drDeposit)
		//{
		//	Int64 maxDepositAlw;
		//	Int64 zanDifference;
        //
		//	if (difference >= 0)		// --- �{���� --- //
		//	{
		//		// �����c �� (��������}�X�^) ���擾
		//		Int64 alwcBlnce_sales = Convert.ToInt64(drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales]);
        //
		//		if (difference >= alwcBlnce_sales)		// --- �����O��������z >= �����c �� (��������}�X�^) --- //
		//		{
		//			// �����c �� (��������}�X�^) ���擾
		//			maxDepositAlw = alwcBlnce_sales;
        //
		//			// ������̖����������z
		//			zanDifference = difference - alwcBlnce_sales;
		//		}
		//		else									// --- �����O��������z < �����c �� (��������}�X�^) --- //
		//		{
		//			// �����O�㍷�z ���擾
		//			maxDepositAlw = difference;
        //
		//			// ������̖����������z
		//			zanDifference = 0;
		//		}
		//	}
		//	else						// --- �|���� --- //
		//	{
		//		// �����z �� (���������z) ���擾
		//		Int64 alwc_Alw = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Alw]);
        //
		//		if (difference * -1 > alwc_Alw)			// --- �����O��������z >= �����z �� (���������z) --- //
		//		{
		//			// �����z �� (��������}�X�^) ���擾
		//			maxDepositAlw = alwc_Alw * -1;
        //
		//			// ������̖����������z
		//			zanDifference = difference - alwc_Alw * -1;
		//		}
		//		else									// --- �����O��������z < �����z �� (���������z) --- //
		//		{
		//			// �����O�㍷�z ���擾
		//			maxDepositAlw = difference;
        //
		//			// ������̖����������z
		//			zanDifference = 0;
		//		}
		//	}
        //
		//	// �󒍓����v �������z�������Ȃ��Ă���΁A�����z�̏���� �󒍓����v �ɂ���
		//	Int64 acpOdrDepositTotal = Convert.ToInt64(drDeposit[ctAcpOdrDepositTotal]);
		//	Int64 acpOdrDepositAlwc_Alw = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Alw]);
		//	if (acpOdrDepositTotal < acpOdrDepositAlwc_Alw + maxDepositAlw)
		//	{
		//		zanDifference += acpOdrDepositAlwc_Alw + maxDepositAlw - acpOdrDepositTotal;
		//		maxDepositAlw = acpOdrDepositTotal - acpOdrDepositAlwc_Alw;
		//	}
        //
		//	// �����z �� (���������z) ���X�V����
		//	drDmdSales[ctAcpOdrDepositAlwc_Alw] = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Alw]) + maxDepositAlw;
        //
		//	// �����c �� (��������}�X�^) ���X�V����
		//	drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales]) - maxDepositAlw;
        //
		//	// ������ �� (��������}�X�^) ���X�V����
		//	drDmdSales[ctAcpOdrDepositAlwc_Sales] = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Sales]) + maxDepositAlw;
        //
		//	// ������� ���������z �� ���X�V����
		//	drDeposit[ctAcpOdrDepositAlwc_Deposit] = Convert.ToInt64(drDeposit[ctAcpOdrDepositAlwc_Deposit]) + maxDepositAlw;
        //
		//	// ������� ���������c �� ���X�V����
		//	drDeposit[ctAcpOdrDepoAlwcBlnce_Deposit] = Convert.ToInt64(drDeposit[ctAcpOdrDepoAlwcBlnce_Deposit]) - maxDepositAlw;
        //
		//	return zanDifference;
        //}
        #endregion
        // �� 20070118 18322 d

        // �� 20070118 18322 d MA.NS�p�ɕύX
        #region SF ����������� ����p �ύX�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// ����������� ����p �ύX����
		///// </summary>
		///// <param name="difference">�����O��������z</param>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <param name="drDeposit">�������DataRow</param>
		///// <returns>�����������z</returns>
		///// <remarks>
		///// <br>Note       : ������� ����p �̕ύX���e���e�ɔ��f���܂��B��������͈����c��0�~�܂łł��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 ZeroUpdateCostDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales, ref System.Data.DataRow drDeposit)
		//{
		//	Int64 maxDepositAlw;
		//	Int64 zanDifference;
        //
		//	if (difference >= 0)		// --- �{���� --- //
		//	{
		//		// �����c ����p (��������}�X�^) ���擾
		//		Int64 alwcBlnce_sales = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwcBlnce_Sales]);
        //
		//		if (difference >= alwcBlnce_sales)		// --- �����O��������z >= �����c ����p (��������}�X�^) --- //
		//		{
		//			// �����O�㍷�z �������Ƃ��� �����c ����p (��������}�X�^) ���擾
		//			maxDepositAlw = alwcBlnce_sales;
        //
		//			// ������̖����������z
		//			zanDifference = difference - alwcBlnce_sales;
		//		}
		//		else									// --- �����O��������z < �����c ����p (��������}�X�^) --- //
		//		{
		//			// �����c ����p (��������}�X�^) �������Ƃ��� �����O�㍷�z ���擾
		//			maxDepositAlw = difference;
        //
		//			// ������̖����������z
		//			zanDifference = 0;
		//		}
		//	}
		//	else						// --- �|���� --- //
		//	{
		//		// �����z ����p (���������z) ���擾
		//		Int64 alwc_Alw = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Alw]);
        //
		//		if (difference * -1 > alwc_Alw)			// --- �����O��������z >= �����z ����p (���������z) --- //
		//		{
		//			// �����z ����p (��������}�X�^) ���擾
		//			maxDepositAlw = alwc_Alw * -1;
        //
		//			// ������̖����������z
		//			zanDifference = difference - alwc_Alw * -1;
		//		}
		//		else									// --- �����O��������z < �����z ����p (���������z) --- //
		//		{
		//			// �����O�㍷�z ���擾
		//			maxDepositAlw = difference;
        //
		//			// ������̖����������z
		//			zanDifference = 0;
		//		}
		//	}
        //
		//	// ����p�����v �������z�������Ȃ��Ă���΁A�����z�̏���� ����p�����v �ɂ���
		//	Int64 variousCostDepositTotal = Convert.ToInt64(drDeposit[ctVariousCostDepositTotal]);
		//	Int64 varCostDepoAlwc_Alw = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Alw]);
		//	if (variousCostDepositTotal < varCostDepoAlwc_Alw + maxDepositAlw)
		//	{
		//		zanDifference += varCostDepoAlwc_Alw + maxDepositAlw - variousCostDepositTotal;
		//		maxDepositAlw = variousCostDepositTotal - varCostDepoAlwc_Alw;
		//	}
        //
		//	// �����z ����p (���������z) ���X�V����
		//	drDmdSales[ctVarCostDepoAlwc_Alw] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Alw]) + maxDepositAlw;
        //
		//	// �����c ����p (��������}�X�^) ���X�V����
		//	drDmdSales[ctVarCostDepoAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwcBlnce_Sales]) - maxDepositAlw;
        //
		//	// ������ ����p (��������}�X�^) ���X�V����
		//	drDmdSales[ctVarCostDepoAlwc_Sales] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Sales]) + maxDepositAlw;
        //
		//	// ������� ���������z ����p ���X�V����
		//	drDeposit[ctVarCostDepoAlwc_Deposit] = Convert.ToInt64(drDeposit[ctVarCostDepoAlwc_Deposit]) + maxDepositAlw;
        //    
		//	// ������� ���������c ����p ���X�V����
		//	drDeposit[ctVarCostDepoAlwcBlnce_Deposit] = Convert.ToInt64(drDeposit[ctVarCostDepoAlwcBlnce_Deposit]) - maxDepositAlw;
        //
		//	return zanDifference;
        //}
        #endregion
        // �� 20070118 18322 d

        // �� 20070118 18322 d MA.NS�p�ɕύX
        #region SF �����z �� (���������z) �ő�z�擾�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// �����z �� (���������z) �ő�z�擾����
		///// </summary>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <param name="drDeposit">�������DataRow</param>
		///// <returns>�ő���������z</returns>
		///// <remarks>
		///// <br>Note       : �ő�����c���擾���܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetMaxAcpOdrDepositAlwc(System.Data.DataRow drDmdSales, System.Data.DataRow drDeposit)
		//{
		//	// �}�C�i�X�����̎��͌v�Z���Ȃ�
		//	if (Convert.ToInt64(drDeposit[ctDepositTotal]) < 0)
		//	{
		//		return 0;
		//	}
        //
		//	// ���������c �� ���擾����
		//	Int64 alwcBlnce_deposit = Convert.ToInt64(drDeposit[ctAcpOdrDepoAlwcBlnce_Deposit]);
        //
		//	// �����c �� (��������}�X�^) ���擾����
		//	Int64 alwcBlnce_sales = Convert.ToInt64(drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales]);
        //
		//	Int64 maxDepositAlw;
		//	if (alwcBlnce_deposit >= alwcBlnce_sales)			// --- ���������c �� >= �����c �� (��������}�X�^) --- //
		//	{
		//		// �󒍈����c ��Ԃ�
		//		maxDepositAlw = alwcBlnce_sales;
		//	}
		//	else												// --- ���������c �� < �����c �� (��������}�X�^) --- //
		//	{
		//		// ���������c ��Ԃ�
		//		maxDepositAlw = alwcBlnce_deposit;
		//	}
        //
		//	return maxDepositAlw;
        //}
        #endregion
        // �� 20070118 18322 d

        // �� 20070118 18322 d MA.NS�p�ɕύX
        #region SF �����z ����p (���������z) �ő�z�擾����(�S�ăR�����g�A�E�g)
        ///// <summary>
		///// �����z ����p (���������z) �ő�z�擾����
		///// </summary>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <param name="drDeposit">�������DataRow</param>
		///// <returns>�ő���������z</returns>
		///// <remarks>
		///// <br>Note       : �ő�����c���擾���܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetMaxCostDepositAlwc(System.Data.DataRow drDmdSales, System.Data.DataRow drDeposit)
		//{
		//	// �}�C�i�X�����̎��͌v�Z���Ȃ�
		//	if (Convert.ToInt64(drDeposit[ctDepositTotal]) < 0)
		//	{
		//		return 0;
		//	}
        //
		//	// ���������c ����p ���擾����
		//	Int64 alwcBlnce_deposit = Convert.ToInt64(drDeposit[ctVarCostDepoAlwcBlnce_Deposit]);
        //
		//	// �����c ����p (��������}�X�^) ���擾����
		//	Int64 alwcBlnce_sales = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwcBlnce_Sales]);
        //
		//	Int64 maxDepositAlw;
		//	if (alwcBlnce_deposit >= alwcBlnce_sales)			// --- ���������c ����p >= �����c ����p (��������}�X�^) --- //
		//	{
		//		// �󒍈����c ��Ԃ�
		//		maxDepositAlw = alwcBlnce_sales;
		//	}
		//	else												// --- ���������c ����p < �����c ����p (��������}�X�^) --- //
		//	{
		//		// ���������c ��Ԃ�
		//		maxDepositAlw = alwcBlnce_deposit;
		//	}
        //
		//	return maxDepositAlw;
        //}
        #endregion
        // �� 20070118 18322 d
		
		/// <summary>
		/// �����z ���� (���������z) �ő�z�擾����
		/// </summary>
		/// <param name="drDmdSales">����������DataRow</param>
		/// <param name="drDeposit">�������DataRow</param>
		/// <returns>�ő���������z</returns>
		/// <remarks>
		/// <br>Note       : �ő�����c���擾���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public Int64 GetMaxDepositAlwc(DataRow drDmdSales, DataRow drDeposit)
		{
            //// �}�C�i�X�����̎��͌v�Z���Ȃ�
            //if (Convert.ToInt64(drDeposit[ctDepositTotal]) < 0)
            //{
            //    return 0;
            //}

            //// ���������c ���� ���擾����
            //Int64 alwcBlnce_deposit = Convert.ToInt64(drDeposit[ctDepositAlwcBlnce_Deposit]);

            //// �����c ���� (��������}�X�^) ���擾����
            //Int64 alwcBlnce_sales = Convert.ToInt64(drDmdSales[ctDepositAlwcBlnce_Sales]);

            //Int64 maxDepositAlw;
            //if (alwcBlnce_deposit >= alwcBlnce_sales)			// --- ���������c ���� >= �����c ���� (��������}�X�^) --- //
            //{
            //    // �󒍈����c ��Ԃ�
            //    maxDepositAlw = alwcBlnce_sales;
            //}
            //else												// --- ���������c ���� < �����c ���� (��������}�X�^) --- //
            //{
            //    // ���������c ��Ԃ�
            //    maxDepositAlw = alwcBlnce_deposit;
            //}

            //return maxDepositAlw;

            // �����c���擾����
            Int64 alwcBlnce_sales = Convert.ToInt64(drDmdSales[ctTotalSales]);
            return alwcBlnce_sales;

		}

        // �� 20070118 18322 d MA.NS�p�ɕύX
        #region SF �����z �� (���������z) �N���A�z�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// �����z �� (���������z) �N���A�z����
		///// </summary>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <returns>���������N���A�z</returns>
		///// <remarks>
		///// <br>Note       : �N���A���z��߂��܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetClearAcpOdrDepositAlwc(System.Data.DataRow drDmdSales)
		//{
		//	// �����z �� (���������z) �̃N���A�z�擾
		//	return Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Alw]) * -1;
        //}
        #endregion
        // �� 20070118 18322 d

        // �� 20070118 18322 d MA.NS�p�ɕύX
        #region SF �����z ����p (���������z) �N���A�z�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// �����z ����p (���������z) �N���A�z����
		///// </summary>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <returns>���������N���A�z</returns>
		///// <remarks>
		///// <br>Note       : �N���A���z��߂��܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetClearCostDepositAlwc(System.Data.DataRow drDmdSales)
		//{
		//	// �����z ����p (���������z) �̃N���A�z�擾
		//	return Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Alw]) * -1;
        //}
        #endregion
        // �� 20070118 18322 d
		
		/// <summary>
		/// �����z ���� (���������z) �N���A�z����
		/// </summary>
		/// <param name="drDmdSales">����������DataRow</param>
		/// <returns>���������N���A�z</returns>
		/// <remarks>
		/// <br>Note       : �N���A���z��߂��܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public Int64 GetClearDepositAlwc(DataRow drDmdSales)
		{
			// �����z ���� (���������z) �̃N���A�z�擾
			return Convert.ToInt64(drDmdSales[ctDepositAllowance_Alw]) * -1;
		}
		
		/// <summary>
		/// �������DataRow�R�s�[����
		/// </summary>
		/// <param name="drBef">�R�s�[��DataRow</param>
		/// <param name="drAft">�R�s�[��DataRow</param>
		/// <returns>�������DataRow</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : DataRow�̒��g�̒l�̃R�s�[���s���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void CopyDepositDataRow(ref DataRow drBef, ref DataRow drAft)
		{
			// DataRow���R�s�[����
			drAft = drBef.Table.NewRow();
			for (int ix = 0; ix < drAft.ItemArray.Length; ix++)
			{
				drAft[ix] = drBef[ix];
			}
		}

		/// <summary>
		/// �������DataRow�R�s�[����
		/// </summary>
		/// <param name="arBef">�R�s�[��DataRow ArrayList</param>
		/// <param name="arAft">�R�s�[��DataRow ArrayList</param>
		/// <returns>�������DataRow</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : DataRow�̒��g�̒l�̃R�s�[���s���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void CopyAllowanceDataRow(ref ArrayList arBef, ref ArrayList arAft)
		{
			arAft.Clear();

			foreach (DataRow drBef in arBef)
			{
				// DataRow���R�s�[����
				DataRow drAft = drBef.Table.NewRow();
				for (int ix = 0; ix < drAft.ItemArray.Length; ix++)
				{
					drAft[ix] = drBef[ix];
				}
				arAft.Add(drAft);
			}
		}

		/// <summary>
		/// �������DataRow�����擾����
		/// </summary>
		/// <param name="drDeposit">�������DataRow</param>
		/// <returns>�������DataRow</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �I�����ꂽ�������DataSet��DataRow�̃R�s�[��Ԃ��܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public DataRow GetSelectDepositCopyRow(DataRow drDeposit)
		{
			// �I��DataRow�̕�����߂�
			DataRow dr = _dsDepositInfo.Tables[ctDepositDataTable].NewRow();
			for (int ix = 0; ix < dr.ItemArray.Length; ix++)
			{
				dr[ix] = drDeposit[ix];
			}

			return dr;
		}

		/// <summary>
		/// �������DataRow�����擾����
		/// </summary>
		/// <param name="drDeposit">�������DataRow</param>
		/// <returns>�������DataRow</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �I�����ꂽ�������DataSet�̎qDataRow(�������)�̃R�s�[��Ԃ��܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public ArrayList GetSelectAllowanceCopyRow(DataRow drDeposit)
		{
			ArrayList al = new ArrayList();

			// �I��DataRow�̎q�s���擾����
			foreach (DataRow dr in drDeposit.GetChildRows(ctRelation_DepositAllowance))
			{
				// �I���qDataRow�̕�����߂�
				DataRow cdr = dr.Table.NewRow();
				for (int ix = 0; ix < cdr.ItemArray.Length; ix++)
				{
					cdr[ix] = dr[ix];
				}

				al.Add(cdr);
			}

			return al;
		}

		/// <summary>
		/// ����������DataRow�擾����
		/// </summary>
		/// <param name="index">����������DataSet��RowIndex</param>
		/// <returns>����������DataRow</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �I�����ꂽ����������DataSet��DataRow��Ԃ��܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public DataRow GetSelectDmdSalesRow(int index)
		{
			// �I��DataRow��߂�
			return _dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows[index];
		}

		/// <summary>
		/// �s�̕ύX�󋵃`�F�b�N����
		/// </summary>
		/// <param name="befDepositRow">�������(�����O)</param>
		/// <param name="befAllowanceRows">�������(�����O)</param>
		/// <param name="aftDepositRow">�������(������)</param>
		/// <param name="aftAllowanceRows">�������(������)</param>
        /// <param name="flag">0:�V�K</param>
		/// <returns>�ύX�X�e�[�^�X true:�ύX�L��.false:�ύX����</returns>
		/// <remarks>
		/// <br>Note       : �s���e���ύX���ꂽ���ǂ������`�F�b�N���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
        //public bool CheckUpdateData(DataRow befDepositRow, ArrayList befAllowanceRows, DataRow aftDepositRow, ArrayList aftAllowanceRows) // DEL 2009/12/25
        public bool CheckUpdateData(DataRow befDepositRow, ArrayList befAllowanceRows, DataRow aftDepositRow, ArrayList aftAllowanceRows, int flag) // ADD 2009/12/25
		{
			// �������(������)���������͖��`�F�b�N
			if (aftDepositRow != null)
			{
				// �������(�����O)���������͐V�K�擾
				if (befDepositRow == null)
				{
					// �������V�K�s�ǉ�����
					befDepositRow = DepositNewRow();
				}

				// �������̃`�F�b�N����
				for (int ix=0; ix<befDepositRow.ItemArray.Length; ix++)
				{
                    // --- ADD 2009/12/25 ---------->>>>>
                    if (flag == 0
                        && (befDepositRow.Table.Columns[ix].ColumnName == InputDepositNormalTypeAcs.ctDepositAddUpADate
                        || befDepositRow.Table.Columns[ix].ColumnName == InputDepositNormalTypeAcs.ctDepositAddUpADateDisp
                        || befDepositRow.Table.Columns[ix].ColumnName == InputDepositNormalTypeAcs.ctOutline))
                    {
                        continue;
                    }
                    // --- ADD 2009/12/25 ----------<<<<<

					if (befDepositRow[ix].ToString() != aftDepositRow[ix].ToString())
						return true;

                    // ADD 2010/05/12 MANTIS�Ή�[15195]�F����0���C���ďo������̕ۑ����s���Ȃ� ---------->>>>>
                    // 0�~�̓����͍X�V�Ώ�
                    if (!flag.Equals(0) && ix.Equals(13))   // [13]�F�����̍��v
                    {
                        long deposit = (long)befDepositRow.ItemArray[ix];
                        if (deposit.Equals(0)) return true;
                    }
                    // ADD 2010/05/12 MANTIS�Ή�[15195]�F����0���C���ďo������̕ۑ����s���Ȃ� ----------<<<<<
				}
			}

			// �������(������)���������͖��`�F�b�N
			if (aftAllowanceRows != null)
			{
				// �������̃`�F�b�N���� �s���̔�r
				if (befAllowanceRows.Count != aftAllowanceRows.Count) return true;

				// �������̃\�[�g����
				befAllowanceRows.Sort(new cmpAllowance());
				aftAllowanceRows.Sort(new cmpAllowance());

				// �������̃`�F�b�N���� ���e�̔�r
				for (int ix=0; ix<befAllowanceRows.Count; ix++)
				{
					DataRow befAllowanceRow = (DataRow)befAllowanceRows[ix];
					DataRow aftAllowanceRow = (DataRow)aftAllowanceRows[ix];

					for (int iy=0; iy<befAllowanceRow.ItemArray.Length; iy++)
					{
						if (befAllowanceRow[iy].ToString() != aftAllowanceRow[iy].ToString())
							return true;
					}
				}
			}

			return false;
        }

        #region DEL 2008/06/26 Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �����󋵕s���`�F�b�N����
		/// </summary>
		/// <param name="errorLevel">�s���`�F�b�N���x�� 0:ERR, 1:Info</param>
		/// <param name="optSeparateCost">����p�ʓ����I�v�V���� �L��</param>
		/// <param name="allowanceProc">���������敪</param>
		/// <param name="depositRow">�������(������)</param>
		/// <param name="arrAllowanceRow">�������(������)</param>
		/// <param name="dmdSalesDs">����������(������)</param>
		/// <param name="messages">�G���[���b�Z�[�W</param>
		/// <returns>�ύX�X�e�[�^�X 0:����. -1:�����s��</returns>
		/// <remarks>
		/// <br>Note       : �����s���ɂȂ��Ă��Ȃ����`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int CheckUpdateAlwcBlnce(int errorLevel, bool optSeparateCost, int allowanceProc, DataRow depositRow, ArrayList arrAllowanceRow, DataSet dmdSalesDs, out System.Collections.Specialized.StringCollection messages)
		{
			messages = new System.Collections.Specialized.StringCollection();

			// --- �K�{�����̎� --- //
			if (allowanceProc == 1)
			{
				// �yLevel:Err�z�����c��(����) > 0 �������z(����)�ɖ����Ȃ������z(����)
				if ((errorLevel == 0) && (Convert.ToInt64(depositRow[ctDepositAlwcBlnce_Deposit]) > 0))
				{
					messages.Add("�S�������z����������Ă��܂���B" + "\r\n\r\n" + 
						"    �������z  :  " + Convert.ToInt64(depositRow[ctDepositTotal]).ToString("###,###,##0") + " �~" + "\r\n\r\n" +
						"    �����c  :  " + Convert.ToInt64(depositRow[ctDepositAlwcBlnce_Deposit]).ToString("###,###,##0") + " �~" + "\r\n\r\n");
				}
			}

			// --- �}�C�i�X�����̎� --- //
			if (Convert.ToInt64(depositRow[ctDepositTotal]) < 0)
			{
				// �yLevel:Info�z�������v(��) < 0 ���}�C�i�X����
				if (errorLevel == 1)
				{
					messages.Add("�������z���}�C�i�X�ł��B" + "\r\n\r\n" + 
							"���̂܂ܕۑ����Ă�낵���ł����H");
				}
			}
			else
			{
				// �yLevel:Err�z�����c��(����) < 0 �������z(����)�𒴂�������z(����)
				if ((errorLevel == 0) && (Convert.ToInt64(depositRow[ctDepositAlwcBlnce_Deposit]) < 0))
				{
					messages.Add("�����z���������z�𒴂��Ă��܂��B" + "\r\n\r\n" + 
						"    �������z  :  " + Convert.ToInt64(depositRow[ctDepositTotal]).ToString("###,###,##0") + " �~" + "\r\n\r\n" +
						"    �����z  :  " + Convert.ToInt64(depositRow[ctDepositAllowance_Deposit]).ToString("###,###,##0") + " �~" + "\r\n\r\n");
				}

                // �� 20070118 18322 d MA.NS�p�ɕύX
                #region SF �󒍁E����p�i�S�ăR�����g�A�E�g�j
                //// --- ����p�ʓ��� �L�� --- //
				//if (optSeparateCost == true)
				//{
				//	// �yLevel:Info�z�����c��(��) < 0 �������z(��)�𒴂�������z(��)
				//	if ((errorLevel == 1) && (Convert.ToInt64(depositRow[ctAcpOdrDepoAlwcBlnce_Deposit]) < 0))
				//	{
				//		messages.Add("�����z(��)�������z(��)�𒴂��Ă��܂��B" + "\r\n\r\n" + 
				//			"    �����z(��)  :  " + Convert.ToInt64(depositRow[ctAcpOdrDepositTotal]).ToString("###,###,##0") + " �~" + "\r\n\r\n" +
				//			"    �����z(��)  :  " + Convert.ToInt64(depositRow[ctAcpOdrDepositAlwc_Deposit]).ToString("###,###,##0") + " �~" + "\r\n\r\n" +
				//			"���̂܂ܕۑ����Ă�낵���ł����H");
				//	}
                //
				//	// �yLevel:Info�z�����c��(����p) < 0 �������z(����p)�𒴂�������z(����p)
				//	if ((errorLevel == 1) && (Convert.ToInt64(depositRow[ctVarCostDepoAlwcBlnce_Deposit]) < 0))
				//	{
				//		messages.Add("�����z(��)�������z(��)�𒴂��Ă��܂��B" + "\r\n\r\n" + 
				//			"    �����z(��)  :  " + Convert.ToInt64(depositRow[ctVariousCostDepositTotal]).ToString("###,###,##0") + " �~" + "\r\n\r\n" +
				//			"    �����z(��)  :  " + Convert.ToInt64(depositRow[ctVarCostDepoAlwc_Deposit]).ToString("###,###,##0") + " �~" + "\r\n\r\n" +
				//			"���̂܂ܕۑ����Ă�낵���ł����H");
				//	}
                //}
                #endregion
                // �� 20070118 18322 d
			}


			// --- ��������f�[�^�ɑ΂���G���[�`�F�b�N --- //
			bool hitflg1 = false;
			bool hitflg2 = false;
			// �������������擾
			DataRow[] allowanceRows = (DataRow[])arrAllowanceRow.ToArray(typeof(DataRow));
			foreach (DataRow allowanceRow in allowanceRows)
			{
				// ��������������擾
				foreach (DataRow dmdSalesRow in dmdSalesDs.Tables[ctDmdSalesDataTable].Rows)
				{
					// ���ꐿ������̎�
					// if (Convert.ToInt32(dmdSalesRow[ctAcceptAnOrderNo]) == Convert.ToInt32(allowanceRow[ctAcceptAnOrderNo_Alw]))   // 2007.10.05 del
                    if (Convert.ToInt32(dmdSalesRow[ctSalesSlipNum]) == Convert.ToInt32(allowanceRow[ctSalesSlipNum_Alw]))            // 2007.10.05 add
					{
                        // �� 20070129 18322 c MA.NS�p�ɕύX
                        #region SF �ۑ��m�F�i�S�ăR�����g�A�E�g�j
                        //// �yLevel:Info�z�a����Ŕ[�i���ȊO�̎� ���ʏ�����̎��A���Ϗ�/�w�����ւ̈���
						//if ((errorLevel == 1) && (hitflg1 == false) && (Convert.ToInt64(depositRow[ctDepositCd]) == 0) && (Convert.ToInt32(dmdSalesRow[ctAcptAnOdrStatus]) != 30)) 
						//{
						//	hitflg1 = true;
						//	messages.Add("�a����敪���ʏ�����Ƃ��āA���Ϗ�/�w�����Ɉ����Ă��Ă��܂��B" + "\r\n\r\n" + 
						//		"���̂܂ܕۑ����Ă�낵���ł����H");
						//}
                        //
						//// �yLevel:Info�z�����c ���� (��������}�X�^) < 0 �������c ���� (��������}�X�^)���}�C�i�X�̎�
						//if ((errorLevel == 1) && (hitflg2 == false) && (Convert.ToInt32(dmdSalesRow[ctDmdSalesDebitNoteCd]) == 0) && (Convert.ToInt32(dmdSalesRow[ctDepositAlwcBlnce_Sales]) < 0)) 
						//{
						//	// �����z���v���X�̎�
						//	if (Convert.ToInt64(allowanceRow[ctDepositAllowance]) > 0)
						//	{
						//		hitflg2 = true;
						//		messages.Add("�󒍊z�ȏ�̓�������������Ă��܂��B" + "\r\n\r\n" + 
						//			"���̂܂ܕۑ����Ă�낵���ł����H");
						//	}
                        //}
                        #endregion

						// �yLevel:Info�z�����c ���� (��������}�X�^) < 0
                        //                         �������c ���� (��������}�X�^)���}�C�i�X�̎�
						if ((errorLevel == 1) &&
                            (hitflg2 == false) &&
                            (Convert.ToInt32(dmdSalesRow[ctDmdSalesDebitNoteCd]) == 0))
                        {
                            if (Convert.ToInt32(dmdSalesRow[ctDepositAlwcBlnce_Sales]) < 0)
	    					{
							    // �����z���v���X�̎�
							    if (Convert.ToInt64(allowanceRow[ctDepositAllowance]) > 0)
							    {
								    hitflg2 = true;
								    messages.Add("����z�ȏ�̓�������������Ă��܂��B" + "\r\n\r\n" + 
									             "���̂܂ܕۑ����Ă�낵���ł����H");
							    }
                            }
                        }
                        // �� 20070129 18322 c

						break;
					}
				}
				if ((hitflg1 == true) && (hitflg2 == true)) break;
			}

			if (messages.Count == 0)
			{
				return 0;
			}
			else
			{
				return -1;
			}
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 Partsman�p�ɕύX

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �����󋵕s���`�F�b�N����
        /// </summary>
        /// <param name="errorLevel">�s���`�F�b�N���x�� 0:ERR, 1:Info</param>
        /// <param name="allowanceProc">���������敪</param>
        /// <param name="depositRow">�������(������)</param>
        /// <param name="arrAllowanceRow">�������(������)</param>
        /// <param name="dmdSalesDs">����������(������)</param>
        /// <param name="messages">�G���[���b�Z�[�W</param>
        /// <returns>�ύX�X�e�[�^�X 0:����. -1:�����s��</returns>
        public int CheckUpdateAlwcBlnce(int errorLevel, int allowanceProc, DataRow depositRow, ArrayList arrAllowanceRow, DataSet dmdSalesDs, out StringCollection messages)
        {
            messages = new StringCollection();

            // --- �K�{�����̎� --- //
            if (allowanceProc == 1)
            {
                // �yLevel:Err�z�����c��(����) > 0 �������z(����)�ɖ����Ȃ������z(����)
                if ((errorLevel == 0) && (Convert.ToInt64(depositRow[ctDepositAlwcBlnce_Deposit]) > 0))
                {
                    messages.Add("�S�������z����������Ă��܂���B" + "\r\n\r\n" +
                        "    �������z  :  " + Convert.ToInt64(depositRow[ctDepositTotal]).ToString("###,###,##0") + " �~" + "\r\n\r\n" +
                        "    �����c  :  " + Convert.ToInt64(depositRow[ctDepositAlwcBlnce_Deposit]).ToString("###,###,##0") + " �~" + "\r\n\r\n");
                }
            }

            // --- �}�C�i�X�����̎� --- //
            if (Convert.ToInt64(depositRow[ctDepositTotal]) < 0)
            {
                // �yLevel:Info�z�������v(��) < 0 ���}�C�i�X����
                if (errorLevel == 1)
                {
                    messages.Add("�������z���}�C�i�X�ł��B" + "\r\n\r\n" +
                            "���̂܂ܕۑ����Ă�낵���ł����H");
                }
            }
            else
            {
                // �yLevel:Err�z�����c��(����) < 0 �������z(����)�𒴂�������z(����)
                if ((errorLevel == 0) && (Convert.ToInt64(depositRow[ctDepositAlwcBlnce_Deposit]) < 0))
                {
                    messages.Add("�����z���������z�𒴂��Ă��܂��B" + "\r\n\r\n" +
                        "    �������z  :  " + Convert.ToInt64(depositRow[ctDepositTotal]).ToString("###,###,##0") + " �~" + "\r\n\r\n" +
                        "    �����z  :  " + Convert.ToInt64(depositRow[ctDepositAllowance_Deposit]).ToString("###,###,##0") + " �~" + "\r\n\r\n");
                }
            }

            // --- ��������f�[�^�ɑ΂���G���[�`�F�b�N --- //
            bool hitflg1 = false;
            bool hitflg2 = false;

            // �������������擾
            DataRow[] allowanceRows = (DataRow[])arrAllowanceRow.ToArray(typeof(DataRow));
            foreach (DataRow allowanceRow in allowanceRows)
            {
                // ��������������擾
                foreach (DataRow dmdSalesRow in dmdSalesDs.Tables[ctDmdSalesDataTable].Rows)
                {
                    // ���ꐿ������̎�
                    if (Convert.ToInt32(dmdSalesRow[ctSalesSlipNum]) == Convert.ToInt32(allowanceRow[ctSalesSlipNum_Alw]))            // 2007.10.05 add
                    {
                        // �yLevel:Info�z�����c ���� (��������}�X�^) < 0
                        //  �������c ���� (��������}�X�^)���}�C�i�X�̎�
                        if ((errorLevel == 1) &&
                            (hitflg2 == false) &&
                            (Convert.ToInt32(dmdSalesRow[ctDmdSalesDebitNoteCd]) == 0))
                        {
                            if (Convert.ToInt32(dmdSalesRow[ctDepositAlwcBlnce_Sales]) < 0)
                            {
                                // �����z���v���X�̎�
                                if (Convert.ToInt64(allowanceRow[ctDepositAllowance]) > 0)
                                {
                                    hitflg2 = true;
                                    messages.Add("����z�ȏ�̓�������������Ă��܂��B" + "\r\n\r\n" +
                                                 "���̂܂ܕۑ����Ă�낵���ł����H");
                                }
                            }
                        }

                        break;
                    }
                }
                if ((hitflg1 == true) && (hitflg2 == true)) break;
            }

            if (messages.Count == 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// �������ŏI�����i�����j�ȑO�`�F�b�N����
		/// </summary>
		/// <param name="depositDate">������</param>
		/// <returns>�`�F�b�N�X�e�[�^�X -1:�ߋ�, 0:����. 1:����</returns>
		/// <remarks>
		/// <br>Note       : �������ƑO������́i�����j�֌W���`�F�b�N���܂��B
		///                :   ���O�������0�̎��́A�߂�l��0��Ԃ��܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int CheckPastCAddUpUpdDate(int depositDate)
		{
            //// �����ߏ�Ԃ͖����ŕԂ�
            //if (_depositCustomer.CAddUpUpdDate == 0) return 1;

            //// ���������O������Ɠ���
            //if (_depositCustomer.CAddUpUpdDate == depositDate)
            //{
            //    return 0;
            //}
            //// ���������O��������ߋ��̎�
            //else if (_depositCustomer.CAddUpUpdDate > depositDate)
            //{
            //    return -1;
            //}
            //else
            //{
            //    return 1;
            //}

            // �����ߏ�Ԃ͖����ŕԂ�
            if (this._lastAddUpDay == DateTime.MinValue) return 1;

            // ���������O������Ɠ���
            if (TDateTime.DateTimeToLongDate(this._lastAddUpDay) == depositDate)
            {
                return 0;
            }
            // ���������O��������ߋ��̎�
            else if (TDateTime.DateTimeToLongDate(this._lastAddUpDay) > depositDate)
            {
                return -1;
            }
            else
            {
                return 1;
            }
		}

		/// <summary>
		/// ������󒍓`�[�̃`�F�b�N����
		/// </summary>
		/// <param name="kbn">�`�F�b�N�敪 0:��,1:��,2:���E�ςݍ�,3:���ς�</param>
		/// <param name="drChild">�I���������DataRow</param>
		/// <param name="searchSalesParameter">����������擾�p�p�����[�^ �N���X</param>
		/// <param name="message">�G���[�����b�Z�[�W</param>
		/// <returns>�X�e�[�^�X 0:�`�F�b�N�敪�̎󒍖���. 2:�`�F�b�N�敪�̎󒍗L��, �ȊO:���̑��G���[ </returns>
		/// <remarks>
		/// <br>Note       : ������̎󒍓`�[�̏�Ԃ��`�F�b�N���A�`�F�b�N��ނɂ��킹���X�e�[�^�X��Ԃ��܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int CheackAllowanceSalese(int kbn, DataRow drChild, SearchSalesParameter searchSalesParameter, out string message)
		{
            // �� 20070122 18322 c MA.NS�p�ɕύX
			//// ������󒍓`�[�̃`�F�b�N����
			//return this.CheackAllowanceSalese(kbn, Convert.ToInt32(drChild[ctAcceptAnOrderNo_Alw]), searchSalesParameter.EnterpriseCode, searchSalesParameter.AddUpSecCod, searchSalesParameter.CustomerCode, out message);

			// ������󒍓`�[�̃`�F�b�N����
			return this.CheackAllowanceSalese(     kbn
//                                             ,     Convert.ToInt32(drChild[ctAcceptAnOrderNo_Alw])   // 2007.10.05 del
                                             ,     searchSalesParameter.SalesSlipNum                   // 2007.10.05 add
                                             ,     searchSalesParameter.EnterpriseCode
                                             ,     searchSalesParameter.DemandAddUpSecCd
                                             ,     searchSalesParameter.CustomerCode
                                             ,     searchSalesParameter.ClaimCode
                                             ,     searchSalesParameter.AcptAnOdrStatus
                                             , out message
                                             );
            // �� 20070122 18322 c
		}

        /// <summary>
        /// �����f�[�^�X�V����
        /// </summary>
        /// <param name="loginSectionCode">���O�C�����_�R�[�h</param>
        /// <param name="addSectionCode">�X�V���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="depositRow">�������(�X�V���)</param>
        /// <param name="allowanceRows">�������(�X�V���)</param>
        /// <param name="depositDate">������</param>
        /// <param name="depositSlipNo">�X�V�����ԍ�</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �������̍X�V�������s���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2011/12/15 tianjw</br>
        /// <br>              Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
        /// </remarks>
        public int SaveDepositData(string loginSectionCode, 
                                   string addSectionCode, 
                                   int customerCode, 
                                   int claimCode, 
                                   DataRow depositRow, 
                                   ArrayList allowanceRows, 
                                   DateTime depositDate,
                                   out int depositSlipNo, 
                                   out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            depositSlipNo = 0;

            SearchDepsitMain depsitMain = new SearchDepsitMain();
            Hashtable htDepositAlw = new Hashtable();
            DateTime preDepositDate = DateTime.MinValue; // ADD 2011/12/15

            try
            {
                // �X�V�����`�[�ԍ��擾
                depositSlipNo = (Int32)depositRow[ctDepositSlipNo];

                // �X�V��
                if (depositSlipNo != 0)
                {
                    // �Ǎ����������̎擾
                    preDepositDate = ((SearchDepsitMain)_depsitMain[depositSlipNo]).DepositDate; // ADD 2011/12/15
                    // �Ǎ��������}�X�^�E���������}�X�^�擾����
                    GetBeforeDepositData(depositSlipNo, out depsitMain, out htDepositAlw);
                }

                // �����}�X�^�E���������}�X�^�X�V���e�Z�b�g����
                SetUpdateDepositData1(UpdateMode.Insert, loginSectionCode, addSectionCode, customerCode, claimCode, depositRow, allowanceRows, depositDate, ref depsitMain, ref htDepositAlw);

                // �����}�X�^�������}�X�^���ڃZ�b�g����
                SetUpdateDepositData2(ref depsitMain, htDepositAlw);

                // �N���X�����o�[�R�s�[����
                DepsitDataWork depsitDataWork = CopyToDepsitDataWorkFromDepsitMain(depsitMain);             // �i�����}�X�^�˓����}�X�^���[�N�j
                depsitDataWork.PreDepositDate = preDepositDate; // ADD 2011/12/15
                DepositAlwWork[] depositAlwWorkList = CopyToDepositAlwWorkFromDepositAlw(htDepositAlw);     // �i���������}�X�^�˓��������}�X�^���[�N�j

                // �X�V����
                status = this._depsitMainAcs.WriteDB(ref depsitDataWork, ref depositAlwWorkList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }

                // �N���X�����o�[�R�s�[����
                ArrayList arrDepsitMain = CopyToDepsitMainFromDepsitDataWork(depsitDataWork);      // �i�����}�X�^���[�N�˓����}�X�^�j
                ArrayList arrDepositAlw = CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);  // �i���������}�X�^���[�N�˓��������}�X�^�j

                if (depositSlipNo == 0)
                {
                    // �������/������� �ێ��p�f�[�^�N���X�o�^����
                    SetDepositSaveClass(arrDepsitMain, arrDepositAlw);

                    int customerCode1;
                    int claimCode1;

                    // �������/�������f�[�^�Z�b�g�o�^����
                    SetDsDepositInfo(arrDepsitMain, arrDepositAlw, out customerCode1, out claimCode1);
                }
                else
                {
                    // �������/������� �ێ��p�f�[�^�N���X�X�V����
                    UpdateDepositSaveClass(arrDepsitMain, arrDepositAlw);

                    // �������/�������f�[�^�Z�b�g�X�V����
                    UpdateDepositDataSet(arrDepsitMain, arrDepositAlw);
                }

                // ��������}�X�^�N���X�X�V����
                UpdateDmdSales();

                // �����ԍ��̎擾
                depositSlipNo = depsitDataWork.DepositSlipNo;

            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }

        // --------------- ADD START 2010.05.06 gejun FOR M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>
        /// <summary>
        /// �����X�V����(��`�f�[�^���A���)
        /// </summary>
        /// <param name="loginSectionCode">���O�C�����_�R�[�h</param>
        /// <param name="addSectionCode">�X�V���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="depositRow">�������(�X�V���)</param>
        /// <param name="allowanceRows">�������(�X�V���)</param>
        /// <param name="depositDate">������</param>
        /// <param name="depositSlipNo">�X�V�����ԍ�</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <param name="rcvDraftDataUpd">��`�f�[�^�i�X�V�p�j</param>
        /// <param name="rcvDraftDataDel">��`�f�[�^�i�폜�p�j</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �������A��`�f�[�^�̍X�V�������s���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.06</br>
        /// <br>Update Note : 2011/12/15 tianjw</br>
        /// <br>              Redmine#27390 ���_�Ǘ�/������̃`�F�b�N</br>
        /// </remarks>
        public int SaveDepositDataWithDraftData(string loginSectionCode,
                                   string addSectionCode,
                                   int customerCode,
                                   int claimCode,
                                   DataRow depositRow,
                                   ArrayList allowanceRows,
                                   DateTime depositDate,
                                   out int depositSlipNo,
                                   out string message,
                                   RcvDraftData rcvDraftDataUpd,
                                   RcvDraftData rcvDraftDataDel)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            depositSlipNo = 0;

            SearchDepsitMain depsitMain = new SearchDepsitMain();
            Hashtable htDepositAlw = new Hashtable();
            DateTime preDepositDate = DateTime.MinValue; // ADD 2011/12/15

            try
            {

                // �X�V�����`�[�ԍ��擾
                depositSlipNo = (Int32)depositRow[ctDepositSlipNo];

                // �X�V��
                if (depositSlipNo != 0)
                {
                    // �Ǎ����������̎擾
                    preDepositDate = ((SearchDepsitMain)_depsitMain[depositSlipNo]).DepositDate; // ADD 2011/12/15
                    // �Ǎ��������}�X�^�E���������}�X�^�擾����
                    GetBeforeDepositData(depositSlipNo, out depsitMain, out htDepositAlw);
                }

                // �����}�X�^�E���������}�X�^�X�V���e�Z�b�g����
                SetUpdateDepositData1(UpdateMode.Insert, loginSectionCode, addSectionCode, customerCode, claimCode, depositRow, allowanceRows, depositDate, ref depsitMain, ref htDepositAlw);

                // �����}�X�^�������}�X�^���ڃZ�b�g����
                SetUpdateDepositData2(ref depsitMain, htDepositAlw);


                // �N���X�����o�[�R�s�[����
                DepsitDataWork depsitDataWork = CopyToDepsitDataWorkFromDepsitMain(depsitMain);             // �i�����}�X�^�˓����}�X�^���[�N�j
                depsitDataWork.PreDepositDate = preDepositDate; // ADD 2011/12/15
                DepositAlwWork[] depositAlwWorkList = CopyToDepositAlwWorkFromDepositAlw(htDepositAlw);     // �i���������}�X�^�˓��������}�X�^���[�N�j

                // �X�V�p����`�f�[�^
                RcvDraftDataWork rcvDraftDataWorkUpd;
                if (rcvDraftDataUpd != null)
                    rcvDraftDataWorkUpd = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftDataUpd);
                else
                    rcvDraftDataWorkUpd = null;

                // �폜�p����`�f�[�^
                RcvDraftDataWork rcvDraftDataWorkDel;
                if (rcvDraftDataDel != null)
                    rcvDraftDataWorkDel = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftDataDel);
                else
                    rcvDraftDataWorkDel = null;

                // �X�V����
                status = this._depsitMainAcs.WriteDBWithDraftData(ref depsitDataWork, ref depositAlwWorkList, out message, rcvDraftDataWorkUpd, rcvDraftDataWorkDel);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }

                // �������ύX����ꍇ
                if (depsitDataWork.UpdateSecCd != "")
                {
                    // �N���X�����o�[�R�s�[����
                    ArrayList arrDepsitMain = CopyToDepsitMainFromDepsitDataWork(depsitDataWork);      // �i�����}�X�^���[�N�˓����}�X�^�j
                    ArrayList arrDepositAlw = CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);  // �i���������}�X�^���[�N�˓��������}�X�^�j

                    if (depositSlipNo == 0)
                    {
                        // �������/������� �ێ��p�f�[�^�N���X�o�^����
                        SetDepositSaveClass(arrDepsitMain, arrDepositAlw);

                        int customerCode1;
                        int claimCode1;

                        // �������/�������f�[�^�Z�b�g�o�^����
                        SetDsDepositInfo(arrDepsitMain, arrDepositAlw, out customerCode1, out claimCode1);
                    }
                    else
                    {
                        // �������/������� �ێ��p�f�[�^�N���X�X�V����
                        UpdateDepositSaveClass(arrDepsitMain, arrDepositAlw);

                        // �������/�������f�[�^�Z�b�g�X�V����
                        UpdateDepositDataSet(arrDepsitMain, arrDepositAlw);
                    }

                    // ��������}�X�^�N���X�X�V����
                    UpdateDmdSales();

                    // �����ԍ��̎擾
                    depositSlipNo = depsitDataWork.DepositSlipNo;
                }

            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }
        // --------------- ADD END 2010.05.06 gejun FOR M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>
        /// <summary>
        /// �����f�[�^�폜����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="befDepositRow">�������(�����O)</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �������̍폜�������s���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int DeleteDepositData(string enterpriseCode, DataRow befDepositRow, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            DepsitDataWork depsitDataWork = null;
            DepositAlwWork[] depositAlwWorkList = null;

            try
            {
                // �폜�����`�[�ԍ��擾
                int depositSlipNo = (Int32)befDepositRow[ctDepositSlipNo];
                // �����ԍ��敪�擾
                int depositDebitNoteCd = (Int32)befDepositRow[ctDepositDebitNoteCd];
                // �󒍃X�e�[�^�X
                //int acptAnOdrStatus = (Int32)befDepositRow[ctAcptAnOdrStatus];
                int acptAnOdrStatus = (Int32)befDepositRow[ctDepositAcptAnOdrStatus];

                // �����ԍ��敪 �ʏ퍕�̎�
                if (depositDebitNoteCd == 0)
                {
                    // �폜����
                    status = _depsitMainAcs.DeleteDB(enterpriseCode, depositSlipNo, acptAnOdrStatus, out message);
                }
                // �����ԍ��敪 �Ԃ̎�
                else
                {
                    // �폜����
                    status = _depsitMainAcs.DeleteDB(enterpriseCode, depositSlipNo, acptAnOdrStatus, out depsitDataWork, out depositAlwWorkList, out message);
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }

                // �������/������� �ێ��p�f�[�^�N���X�폜����
                DeleteDepositSaveClass(depositSlipNo);

                // �������/�������f�[�^�Z�b�g�폜����
                DeleteDepositDataSet(depositSlipNo);

                // �����ԍ��敪 �Ԃ̎�
                if (depositDebitNoteCd != 0)
                {
                    // �N���X�����o�[�R�s�[����
                    ArrayList arrDepsitMain = CopyToDepsitMainFromDepsitDataWork(depsitDataWork);      // �i�����}�X�^���[�N�˓����}�X�^�j
                    ArrayList arrDepositAlw = CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);  // �i���������}�X�^���[�N�˓��������}�X�^�j

                    // �������/������� �ێ��p�f�[�^�N���X�X�V����    ��(��)�̍X�V
                    UpdateDepositSaveClass(arrDepsitMain, arrDepositAlw);

                    // �������/�������f�[�^�Z�b�g�X�V����    ��(��)�̍X�V
                    UpdateDepositDataSet(arrDepsitMain, arrDepositAlw);
                }

                // ����������f�[�^�Z�b�g�ēo�^����
                ResetDsDmdSalesInfo();
            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �����f�[�^�X�V����
		/// </summary>
		/// <param name="loginSectionCode">���O�C�����_�R�[�h</param>
		/// <param name="addSectionCode">�X�V���_�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="depositRow">�������(�X�V���)</param>
		/// <param name="allowanceRows">�������(�X�V���)</param>
		/// <param name="depositSlipNo">�X�V�����ԍ�</param>
		/// <param name="message">�G���[���������b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �������̍X�V�������s���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int SaveDepositData(string loginSectionCode, string addSectionCode, int customerCode, int claimCode, DataRow depositRow, ArrayList allowanceRows, out int depositSlipNo, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";
			depositSlipNo = 0;

			try
			{
				// �X�V�����`�[�ԍ��擾
				depositSlipNo = Convert.ToInt32(depositRow[ctDepositSlipNo]);

				if (depositSlipNo == 0)
				{
					// --- �����`�[�V�K�I --- //

					// �����}�X�^�E���������}�X�^�X�V���e�Z�b�g����
					SearchDepsitMain depsitMain = new SearchDepsitMain();
					Hashtable htDepositAlw = new Hashtable();
					this.SetUpdateDepositData1(UpdateMode.Insert, loginSectionCode, addSectionCode, customerCode, claimCode, depositRow, allowanceRows, ref depsitMain, ref htDepositAlw);

					// �����}�X�^�������}�X�^���ڃZ�b�g����
					this.SetUpdateDepositData2(ref depsitMain, htDepositAlw);

					// �N���X�����o�[�R�s�[�����i�����}�X�^�N���X�˓����}�X�^���[�N�N���X�j
                    DepsitMainWork depsitMainWork = this.CopyToDepsitMainWorkFromDepsitMain(depsitMain);

					// �N���X�����o�[�R�s�[�����i���������}�X�^�N���X�˓��������}�X�^���[�N�N���X�j
					DepositAlwWork[] depositAlwWorkList = this.CopyToDepositAlwWorkFromDepositAlw(htDepositAlw);

					// �X�V�����I
                    this.WriteDeposit(ref depsitMainWork, ref depositAlwWorkList);

					// �N���X�����o�[�R�s�[�����i�����}�X�^���[�N�N���X�˓����}�X�^�N���X�j
                    DepsitMainWork[] depsitMainWorkList = new DepsitMainWork[1];
                    depsitMainWorkList[0] = depsitMainWork;
                    ArrayList arrDepsitMain = this.CopyToDepsitMainFromDepsitMainWork(depsitMainWorkList);

					// �N���X�����o�[�R�s�[�����i���������}�X�^���[�N�N���X�˓��������}�X�^�N���X�j
					ArrayList arrDepositAlw = this.CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);

					// �������/������� �ێ��p�f�[�^�N���X�o�^����
					this.SetDepositSaveClass(arrDepsitMain, arrDepositAlw);

                    int customerCode1;
                    int claimCode1;

					// �������/�������f�[�^�Z�b�g�o�^����
                    this.SetDsDepositInfo(arrDepsitMain, arrDepositAlw, out customerCode1, out claimCode1);

					// ��������}�X�^�N���X�X�V����
					this.UpdateDmdSales();

					// �V�K�쐬�����ԍ��̎擾
                    depositSlipNo = depsitMainWork.DepositSlipNo;

				}
				else
				{
					// --- �����`�[�X�V�I --- //

					// �Ǎ��������}�X�^�E���������}�X�^�擾����
					SearchDepsitMain depsitMain;
					Hashtable htDepositAlw;
					this.GetBeforeDepositData(depositSlipNo, out depsitMain, out htDepositAlw);

					// �����}�X�^�E���������}�X�^�X�V���e�Z�b�g����
                    this.SetUpdateDepositData1(UpdateMode.Update, loginSectionCode, addSectionCode, customerCode, claimCode, depositRow, allowanceRows, ref depsitMain, ref htDepositAlw);

					// �����}�X�^�������}�X�^���ڃZ�b�g����
					this.SetUpdateDepositData2(ref depsitMain, htDepositAlw);

					// �N���X�����o�[�R�s�[�����i�����}�X�^�N���X�˓����}�X�^���[�N�N���X�j
                    DepsitMainWork depsitMainWork = this.CopyToDepsitMainWorkFromDepsitMain(depsitMain);

					// �N���X�����o�[�R�s�[�����i���������}�X�^�N���X�˓��������}�X�^���[�N�N���X�j
					DepositAlwWork[] depositAlwWorkList = this.CopyToDepositAlwWorkFromDepositAlw(htDepositAlw);

					// �X�V�����I
                    this.WriteDeposit(ref depsitMainWork, ref depositAlwWorkList);

					// �N���X�����o�[�R�s�[�����i�����}�X�^���[�N�N���X�˓����}�X�^�N���X�j
                    DepsitMainWork[] depsitMainWorkList = new DepsitMainWork[1];
                    depsitMainWorkList[0] = depsitMainWork;
                    ArrayList arrDepsitMain = this.CopyToDepsitMainFromDepsitMainWork(depsitMainWorkList);

					// �N���X�����o�[�R�s�[�����i���������}�X�^���[�N�N���X�˓��������}�X�^�N���X�j
					ArrayList arrDepositAlw = this.CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);

					// �������/������� �ێ��p�f�[�^�N���X�X�V����
					this.UpdateDepositSaveClass(arrDepsitMain, arrDepositAlw);

					// �������/�������f�[�^�Z�b�g�X�V����
					this.UpdateDepositDataSet(arrDepsitMain, arrDepositAlw);

					// ��������}�X�^�N���X�X�V����
					this.UpdateDmdSales();

					// �X�V�����ԍ��̎擾
                    depositSlipNo = depsitMainWork.DepositSlipNo;
				}
			}
			catch ( DepositException ex )
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return st;
		}

        /// <summary>
		/// �����f�[�^�폜����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="befDepositRow">�������(�����O)</param>
		/// <param name="message">�G���[���������b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �������̍폜�������s���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int DeleteDepositData(string enterpriseCode, DataRow befDepositRow, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
				// �폜�����`�[�ԍ��擾
				int depositSlipNo = Convert.ToInt32(befDepositRow[ctDepositSlipNo]);

				// �����ԍ��敪 �ʏ퍕�̎�
				if (Convert.ToInt32(befDepositRow[ctDepositDebitNoteCd]) == 0)
				{
					// �폜�����I
					this.DeleteDeposit(enterpriseCode, depositSlipNo);

					// �������/������� �ێ��p�f�[�^�N���X�폜����
					this.DeleteDepositSaveClass(depositSlipNo);

					// �������/�������f�[�^�Z�b�g�폜����
					this.DeleteDepositDataSet(depositSlipNo);
				}
				// �����ԍ��敪 �Ԃ̎�
				else
				{
                    DepsitMainWork depsitMainWork;

					DepositAlwWork[] depositAlwWorkList;

					// �폜�����I
                    this.DeleteDeposit(enterpriseCode, depositSlipNo, out depsitMainWork, out depositAlwWorkList);

					// �������/������� �ێ��p�f�[�^�N���X�폜����    ��(��)�̍폜
					this.DeleteDepositSaveClass(depositSlipNo);

					// �������/�������f�[�^�Z�b�g�폜����    ��(��)�̍폜
					this.DeleteDepositDataSet(depositSlipNo);

					// �N���X�����o�[�R�s�[�����i�����}�X�^���[�N�N���X�˓����}�X�^�N���X�j
                    DepsitMainWork[] depsitMainWorkList = new DepsitMainWork[1];
                    depsitMainWorkList[0] = depsitMainWork;
                    ArrayList arrDepsitMain = this.CopyToDepsitMainFromDepsitMainWork(depsitMainWorkList);

					// �N���X�����o�[�R�s�[�����i���������}�X�^���[�N�N���X�˓��������}�X�^�N���X�j
					ArrayList arrDepositAlw = this.CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);

					// �������/������� �ێ��p�f�[�^�N���X�X�V����    ��(��)�̍X�V
					this.UpdateDepositSaveClass(arrDepsitMain, arrDepositAlw);

					// �������/�������f�[�^�Z�b�g�X�V����    ��(��)�̍X�V
					this.UpdateDepositDataSet(arrDepsitMain, arrDepositAlw);
				}

				// ����������f�[�^�Z�b�g�ēo�^����
				this.ResetDsDmdSalesInfo();
			}
			catch ( DepositException ex )
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return st;
		}

        /// <summary>
		/// �����f�[�^�ԓ`����
		/// </summary>
		/// <param name="mode">�ԓ`�쐬���[�h  0:�ԓ����쐬, 1:�ԓ����E�V�������쐬</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="updateSecCd">�X�V���_�R�[�h</param>
		/// <param name="depositAgentCode">�����S���҃R�[�h</param>
		/// <param name="depositAgentNm">�����S���Җ�</param>
		/// <param name="addUpADate">�v���</param>
		/// <param name="akaDepositCd">�V�ԓ`�̗a����敪</param>
		/// <param name="depositSlipNo">�����ԍ�(��)</param>
		/// <param name="akaDepositSlipNo">�����ԍ�(��)</param>
		/// <param name="message">�G���[���������b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �������̐ԓ`�������s���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		// �� 20070125 18322 c MA.NS�p�ɕύX
        //public int AkaDepositData(int mode, string enterpriseCode, string updateSecCd, string depositAgentCode, int addUpADate, int akaDepositCd, int depositSlipNo, out int akaDepositSlipNo, out string message)
		public int AkaDepositData(int mode, string enterpriseCode, string updateSecCd, string depositAgentCode, string depositAgentNm, int addUpADate, int akaDepositCd, int depositSlipNo, out int akaDepositSlipNo, out string message)
        // �� 20070125 18322 c
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";
			akaDepositSlipNo = 0;

			try
			{
                DepsitMainWork[] depsitMainWorkList;

				DepositAlwWork[] depositAlwWorkList;

                // �� 20070125 18322 c MA.NS�p�ɕύX
				//// �ԍX�V�����I
				//this.WriteAkaDeposit(mode, enterpriseCode, updateSecCd, depositAgentCode, addUpADate, akaDepositCd, depositSlipNo, out depsitMainWorkList, out depositAlwWorkList);

				// �ԍX�V�����I
				this.WriteAkaDeposit(     mode
                                    ,     enterpriseCode
                                    ,     updateSecCd
                                    ,     depositAgentCode
                                    ,     depositAgentNm
                                    ,     addUpADate
                                    ,     akaDepositCd
                                    ,     depositSlipNo
                                    , out depsitMainWorkList
                                    , out depsitDataWorkList
                                    , out depositAlwWorkList);
                // �� 20070125 18322 c

				// �ԓ`�����ԍ��̎擾
                foreach (DepsitMainWork depsitMainWork in depsitMainWorkList)
                {
                    if (depsitMainWork.DepositDebitNoteCd == 1)
                    {
                        akaDepositSlipNo = depsitMainWork.DepositSlipNo;
                    }
                }

				// �N���X�����o�[�R�s�[�����i�����}�X�^���[�N�N���X�˓����}�X�^�N���X�j
                ArrayList arrDepsitMain = this.CopyToDepsitMainFromDepsitMainWork(depsitMainWorkList);

				// �N���X�����o�[�R�s�[�����i���������}�X�^���[�N�N���X�˓��������}�X�^�N���X�j
				ArrayList arrDepositAlw = this.CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);

				// �������/������� �ێ��p�f�[�^�N���X�X�V����
				this.UpdateDepositSaveClass(arrDepsitMain, arrDepositAlw);

				// �������/�������f�[�^�Z�b�g�X�V����
				this.UpdateDepositDataSet(arrDepsitMain, arrDepositAlw);

				// �ԓ`�ō��`�����E���ꂽ�̂ŁA�����z�����`�̋��z�ŃN���A����
				Hashtable htDepositAlw = (Hashtable)_depositAlw[depositSlipNo];
				if (htDepositAlw != null)
				{
					// ��������}�X�^�N���X�������N���A����
					this.ClearDmdSalesAllowance(htDepositAlw);
					
				}

				// ����������f�[�^�Z�b�g�ēo�^����
				this.ResetDsDmdSalesInfo();
			}
			catch ( DepositException ex )
			{
				st = ex.Status;
				message = ex.Message;
			}
			catch ( Exception ex )
			{
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return st;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        /// <summary>
        /// �����f�[�^�ԓ`����
        /// </summary>
        /// <param name="mode">�ԓ`�쐬���[�h  0:�ԓ����쐬, 1:�ԓ����E�V�������쐬</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="updateSecCd">�X�V���_�R�[�h</param>
        /// <param name="depositAgentCode">�����S���҃R�[�h</param>
        /// <param name="depositAgentNm">�����S���Җ�</param>
        /// <param name="addUpADate">�v���</param>
        /// <param name="akaDepositCd">�V�ԓ`�̗a����敪</param>
        /// <param name="depositSlipNo">�����ԍ�(��)</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:���ρ@20:�󒍁@30:����@40:�o��)</param>
        /// <param name="akaDepositSlipNo">�����ԍ�(��)</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �������̐ԓ`�������s���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int AkaDepositData(int mode, 
                                  string enterpriseCode, 
                                  string updateSecCd, 
                                  string depositAgentCode, 
                                  string depositAgentNm, 
                                  int addUpADate, 
                                  int akaDepositCd, 
                                  int depositSlipNo, 
                                  int acptAnOdrStatus,
                                  out int akaDepositSlipNo, 
                                  out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            akaDepositSlipNo = 0;

            try
            {
                DepsitDataWork[] depsitDataWorkList;
                DepositAlwWork[] depositAlwWorkList;

                // �ԓ����쐬����
                status = this._depsitMainAcs.RedCreate(mode, 
                                                       enterpriseCode, 
                                                       akaDepositCd, 
                                                       updateSecCd, 
                                                       depositAgentCode, 
                                                       depositAgentNm, 
                                                       TDateTime.LongDateToDateTime(addUpADate), 
                                                       depositSlipNo, 
                                                       acptAnOdrStatus,
                                                       out depsitDataWorkList, 
                                                       out depositAlwWorkList, 
                                                       out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }

                // �ԓ`�����ԍ��̎擾
                foreach (DepsitDataWork depsitDataWork in depsitDataWorkList)
                {
                    if (depsitDataWork.DepositDebitNoteCd == 1)
                    {
                        akaDepositSlipNo = depsitDataWork.DepositSlipNo;
                    }
                }

                // �N���X�����o�[�R�s�[����
                ArrayList arrDepsitMain = CopyToDepsitMainFromDepsitDataWork(depsitDataWorkList);  // �i�����}�X�^���[�N�˓����}�X�^�j
                ArrayList arrDepositAlw = CopyToDepositAlwFromDepositAlwWork(depositAlwWorkList);  // �i���������}�X�^���[�N�˓��������}�X�^�j

                // �������/������� �ێ��p�f�[�^�N���X�X�V����
                this.UpdateDepositSaveClass(arrDepsitMain, arrDepositAlw);

                // �������/�������f�[�^�Z�b�g�X�V����
                this.UpdateDepositDataSet(arrDepsitMain, arrDepositAlw);

                // �ԓ`�ō��`�����E���ꂽ�̂ŁA�����z�����`�̋��z�ŃN���A����
                Hashtable htDepositAlw = (Hashtable)_depositAlw[depositSlipNo];
                if (htDepositAlw != null)
                {
                    // ��������}�X�^�N���X�������N���A����
                    this.ClearDmdSalesAllowance(htDepositAlw);
                }

                // ����������f�[�^�Z�b�g�ēo�^����
                this.ResetDsDmdSalesInfo();
            }
            catch (DepositException ex)
            {
                status = ex.Status;
                message = ex.Message;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }

            return status;
        }

		/// <summary>
		/// �̎����f�[�^�쐬����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���s���_�R�[�h</param>
		/// <param name="depositCustomer">�������Ӑ���N���X</param>
		/// <param name="deposit">�������</param>
		/// <returns>�̎����f�[�^</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : ���������̎����f�[�^���쐬���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public Receipt SetReceiptFromDepositDataRow(string enterpriseCode, string sectionCode, DepositCustomer depositCustomer, DataRow deposit)
		{
			Receipt receipt = new Receipt();

			receipt.EnterpriseCode		= enterpriseCode;											// ��ƃR�[�h
   			receipt.CustomerCode		= depositCustomer.CustomerCode;								// ���Ӑ�R�[�h
			receipt.ReceiptAddress1		= depositCustomer.Name;										// �̎��������P
			receipt.ReceiptAddress2		= depositCustomer.Name2;									// �̎��������Q
			receipt.RectHonorificTitle	= depositCustomer.HonorificTitle;							// �̎��������h��
			receipt.ReceiptMoney		= Convert.ToInt64(deposit[ctDepositTotal]);					// �̎������z
			receipt.ReceiptIssueNote	= "";														// �̎������l���e�i���s���j
			receipt.ReceiptIssueOrgCd	= 1;														// �̎������s�敪 0:���ρE�[�i,1:����,2:�̎���
			receipt.DepositSlipNo		= Convert.ToInt32(deposit[ctDepositSlipNo]);				// �����`�[�ԍ�
			receipt.AcceptAnOrderNo		= 0;														// �󒍔ԍ�
            // �� 20070118 18322 d MA.NS�p�ɕύX
			//receipt.SlipKind			= 0;														// �`�[��� 10:����,20:�w��,21:���菑,30:�[�i,40:���C
			//receipt.SlipNo				= "";														// �`�[�ԍ�
            // �� 20070118 18322 d
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			receipt.DepositKindCode		= Convert.ToInt32(deposit[ctDepositKindCode]);				// ��������R�[�h
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            receipt.DepositKindName		= deposit[ctDepositKindName].ToString();					// �������햼��
			receipt.Deposit				= Convert.ToInt64(deposit[ctDeposit]);						// �������z
			receipt.FeeDeposit			= Convert.ToInt64(deposit[ctFeeDeposit]);					// �萔�������z
			receipt.DiscountDeposit		= Convert.ToInt64(deposit[ctDiscountDeposit]);				// �l�������z
            // �� 20070118 18322 a
            // �C���Z���e�B�u
			// receipt.RebateDeposit		= Convert.ToInt64(deposit[ctRebateDeposit]);            // 2007.10.05 hikita del
            // �� 20070118 18322 a

			// �� 20070118 18322 d MA.NS�p�ɕύX
            //receipt.ReceiptIssueSecCd	= sectionCode;												// �̎������s���_�R�[�h
			// �� 20070118 18322 d

			receipt.ReceiptPrintDate	= TDateTime.GetSFDateNow();									// �̎������s���t

			return receipt;
		}

		/// <summary>
		/// ����������f�[�^�Z�b�g�ēo�^����
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : ������������f�[�^�Z�b�g�֍ēW�J���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void ResetDsDmdSalesInfo()
		{
			// DataSet������
			_dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Clear();

			// ����������f�[�^�Z�b�g�o�^����
			this.SetDsDmdSalesInfo(this._dmdSales);

			// ����������DetaSet�����X�V�t���O�Z�b�g����
			this.SetDmdSalesDataSetClosedFlg();
		}

		/// <summary>
		/// �������L�����Z������
		/// </summary>
		/// <param name="drDeposit">�I���s�������DataRow(�ύX�O)</param>
		/// <param name="selectedDepositCopyRow">�������(�ύX��)</param>
		/// <param name="selectedAllowanceCopyRows">�������(�ύX��)</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ��������Ǎ�����Ԃɖ߂��܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public void CancelAllowance(DataRow drDeposit, ref DataRow selectedDepositCopyRow, ref ArrayList selectedAllowanceCopyRows)
		{
			if (drDeposit == null)
			{
				// �������DataRow�擾����
				selectedAllowanceCopyRows.Clear();

                // �� 20070118 18322 d MA.NS�p�ɕύX
                #region SF �󒍁E����p�i�S�ăR�����g�A�E�g�j
                //// ���������z �� ���N���A����
				//selectedDepositCopyRow[ctAcpOdrDepositAlwc_Deposit] = 0;
                //
				//// ���������c �� �����ɖ߂� (�����z + �萔�� + �l��)
				//selectedDepositCopyRow[ctAcpOdrDepoAlwcBlnce_Deposit] = Convert.ToInt64(selectedDepositCopyRow[ctAcpOdrDeposit]) + 
				//														Convert.ToInt64(selectedDepositCopyRow[ctAcpOdrChargeDeposit]) + 
				//														Convert.ToInt64(selectedDepositCopyRow[ctAcpOdrDisDeposit]);
                //
				//// ���������z ����p ���N���A����
				//selectedDepositCopyRow[ctVarCostDepoAlwc_Deposit] = 0;
                //
				//// ���������c ����p �����ɖ߂� (�����z + �萔�� + �l��)
				//selectedDepositCopyRow[ctVarCostDepoAlwcBlnce_Deposit] = Convert.ToInt64(selectedDepositCopyRow[ctVariousCostDeposit]) + 
				//															Convert.ToInt64(selectedDepositCopyRow[ctVarCostChargeDeposit]) + 
                //															Convert.ToInt64(selectedDepositCopyRow[ctVarCostDisDeposit]);
                #endregion
                // �� 20070118 18322 d
			
				// ���������z ���� ���N���A����
				selectedDepositCopyRow[ctDepositAllowance_Deposit] = 0;

                // �� 20070118 18322 c MA.NS�p�ɕύX
                #region SF ���������c ���� �����ɖ߂��i�R�����g�A�E�g�j
				//// ���������c ���� �����ɖ߂� (�����z + �萔�� + �l��)
				//selectedDepositCopyRow[ctDepositAlwcBlnce_Deposit] = Convert.ToInt64(selectedDepositCopyRow[ctDeposit]) + 
				//														Convert.ToInt64(selectedDepositCopyRow[ctFeeDeposit]) + 
				//														Convert.ToInt64(selectedDepositCopyRow[ctDiscountDeposit]);
                #endregion

				// ���������c ���� �����ɖ߂� (�����z + �萔�� + �l���{�C���Z���e�B�u)
                selectedDepositCopyRow[ctDepositAlwcBlnce_Deposit] = Convert.ToInt64(selectedDepositCopyRow[ctDeposit]) +
                                                                     Convert.ToInt64(selectedDepositCopyRow[ctFeeDeposit]) +
                                                                     Convert.ToInt64(selectedDepositCopyRow[ctDiscountDeposit]);
                //                                                     Convert.ToInt64(selectedDepositCopyRow[ctRebateDeposit]);  // 2007.10.05 hikita del
                // �� 20070118 18322 c
			}
			else
			{
				// �������DataRow�擾����
				selectedAllowanceCopyRows = this.GetSelectAllowanceCopyRow(drDeposit);

				// �������DataRow�擾����
				DataRow dr = this.GetSelectDepositCopyRow(drDeposit);

				Int64 iWork = 0;

                // �� 20070118 18322 d MA.NS�p�ɕύX
                #region SF �󒍁E����p�i�S�ăR�����g�A�E�g�j
                //// �ύX�O��̍��z�����߂� ���������z ��
				//iWork = (Int64)selectedDepositCopyRow[ctAcpOdrDepositAlwc_Deposit] - (Int64)dr[ctAcpOdrDepositAlwc_Deposit];
                //
				//// ���������z �� �����ɖ߂�
				//selectedDepositCopyRow[ctAcpOdrDepositAlwc_Deposit] = dr[ctAcpOdrDepositAlwc_Deposit];
                //
				//// ���������c �� �����ɖ߂�
				//selectedDepositCopyRow[ctAcpOdrDepoAlwcBlnce_Deposit] = (Int64)selectedDepositCopyRow[ctAcpOdrDepoAlwcBlnce_Deposit] + iWork;
                //
				//// �ύX�O��̍��z�����߂� ���������z ����p
				//iWork = (Int64)selectedDepositCopyRow[ctVarCostDepoAlwc_Deposit] - (Int64)dr[ctVarCostDepoAlwc_Deposit];
                //
				//// ���������z ����p �����ɖ߂�
				//selectedDepositCopyRow[ctVarCostDepoAlwc_Deposit] = dr[ctVarCostDepoAlwc_Deposit];
                //
				//// ���������c ����p �����ɖ߂�
                //selectedDepositCopyRow[ctVarCostDepoAlwcBlnce_Deposit] = (Int64)selectedDepositCopyRow[ctVarCostDepoAlwcBlnce_Deposit] + iWork;
                #endregion
                // �� 20070118 18322 d

				// �ύX�O��̍��z�����߂� ���������z ����
				iWork = (Int64)selectedDepositCopyRow[ctDepositAllowance_Deposit] - (Int64)dr[ctDepositAllowance_Deposit];

				// ���������z ���� �����ɖ߂�
				selectedDepositCopyRow[ctDepositAllowance_Deposit] = dr[ctDepositAllowance_Deposit];

				// ���������c ���� �����ɖ߂�
				selectedDepositCopyRow[ctDepositAlwcBlnce_Deposit] = (Int64)selectedDepositCopyRow[ctDepositAlwcBlnce_Deposit] + iWork;
			}
		}
		# endregion

		# region Private Methods

        //----- ADD K2013/03/22 �c���� Redmine#35071 ----->>>>>
        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�v�V������񐧌䏈���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : K2013/03/18</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ���R�`���i�I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_YamagataCustomControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_YamagataCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_YamagataCtrl = (int)Option.OFF;
            }
            #endregion
        }
        //----- ADD K2013/03/22 ���� Redmine#35063 -----<<<<<

        private void ReadEmployee()
        {
            this._emoloyeeDtlDic = new Dictionary<string, EmployeeDtl>();

            try
            {
                ArrayList retList1;
                ArrayList retList2;

                int status = this._employeeAcs.SearchAll(out retList1, out retList2, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (EmployeeDtl employeeDtl in retList2)
                    {
                        if (employeeDtl.LogicalDeleteCode == 0)
                        {
                            this._emoloyeeDtlDic.Add(employeeDtl.EmployeeCode.Trim(), employeeDtl);
                        }
                    }
                }
            }
            catch
            {
                this._emoloyeeDtlDic = new Dictionary<string, EmployeeDtl>();
            }
        }

        private int GetSubSectionCode(string employeeCode)
        {
            employeeCode = employeeCode.Trim().PadLeft(2, '0');

            if (this._emoloyeeDtlDic.ContainsKey(employeeCode))
            {
                return this._emoloyeeDtlDic[employeeCode].BelongSubSectionCode;
            }

            return 0;
        }

        /// <summary>
        /// ���Ӑ���/�������z���擾����
        /// </summary>
        /// <param name="searchCustomerParameter">���Ӑ���/���Ӑ���z���擾�p�p�����[�^ �N���X</param>
        /// <param name="depositCustomer">�������Ӑ���N���X</param>
        /// <param name="depositCustDmdPrc">�������Ӑ搿�����z���N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : ���Ӑ���Ɛ������z�����擾���܂��B
        ///					: �G���[����DepositException��O���������܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2010/12/20 ����� PM.NS��Q���ǑΉ�(12����)
        /// <br>              �ӕ��̏W�v���Ԃ̏I������MAX�ɕύX����B</br>
        /// </remarks>
        private int GetCustomDemandInfo1(SearchCustomerParameter searchCustomerParameter, 
                                         out DepositCustomer depositCustomer, 
                                         out DepositCustDmdPrc depositCustDmdPrc, 
                                         out string errMsg)
        {
            // �p�����[�^������
            KingetCustDmdPrcWork kingetCustDmdPrcWork;

            int status;
            errMsg = "";
            depositCustomer = new DepositCustomer();
            depositCustDmdPrc = new DepositCustDmdPrc();

            // --- UPD 2010/12/20 ---------->>>>>
            // ���񔄏���������擾
            //DateTime currentDay = GetCurrentTotalDayDmdC(searchCustomerParameter.AddUpSecCod, searchCustomerParameter.ClaimCode);
            //if (currentDay == DateTime.MinValue)
            //{
            //    currentDay = TDateTime.LongDateToDateTime(searchCustomerParameter.AddUpADate);
            //}
            DateTime currentDay = DateTime.MaxValue;
            // --- UPD 2010/12/20  ----------<<<<<

            try
            {
                // ����KINGET����
                status = this._kingetCustDmdPrcAcs.Read(out kingetCustDmdPrcWork, 
                                                        searchCustomerParameter.EnterpriseCode, 
                                                        searchCustomerParameter.AddUpSecCod, 
                                                        searchCustomerParameter.ClaimCode,
                                                        TDateTime.DateTimeToLongDate(currentDay));
                switch (status)
                {   
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // �N���X�����o�[�R�s�[�����iKINGET�p���Ӑ搿�����z���[�N�˓������Ӑ���j
                        this._depositCustomer = this.CopyToDepositCustomerFromKingetCustDmdPrcWork(kingetCustDmdPrcWork);
                        // �N���X�����o�[�R�s�[�����iKINGET�p���Ӑ搿�����z���[�N�˓������Ӑ搿�����z���j
                        this._depositCustDmdPrc = this.CopyToDepositCustDmdPrcFromKingetCustDmdPrcWork(kingetCustDmdPrcWork);

                        // �O������X�V�N����
                        this._depositCustomer.CAddUpUpdDate = this._depositCustomer.CAddUpUpdDate;

                        // �������Ӑ���N���X
                        depositCustomer = _depositCustomer;
                        // �������Ӑ搿�����z���N���X
                        depositCustDmdPrc = this._depositCustDmdPrc;

                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:

                        this._depositCustomer = new DepositCustomer();
                        this._depositCustDmdPrc = new DepositCustDmdPrc();
                        depositCustomer = this._depositCustomer;
                        depositCustDmdPrc = this._depositCustDmdPrc;

                        return (status);

                    default:

                        errMsg = "����KINGET���̎擾�Ɏ��s���܂����B";
                        return (status);
                }

                // ���㌎���X�V�����擾
                this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccRec(searchCustomerParameter.AddUpSecCod);

                // ��������������擾
                this._lastAddUpDay = GetTotalDayDmdC(searchCustomerParameter.AddUpSecCod, searchCustomerParameter.ClaimCode);
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// �O�񔄏㌎���X�V���擾
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public DateTime GetHisTotalDayMonthlyAccRec(string sectionCode)
        {
            DateTime lastMonthlyAddUpDay;

            this._totalDayCalculator.ClearCache();
            this._totalDayCalculator.InitializeHisMonthlyAccRec();

            int status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(sectionCode, out lastMonthlyAddUpDay);
            if (status != 0)
            {
                lastMonthlyAddUpDay = new DateTime();
            }

            return lastMonthlyAddUpDay;
        }

        /// <summary>
        /// �O�񔄏�����������擾
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="cliamCode"></param>
        /// <returns></returns>
        public DateTime GetTotalDayDmdC(string sectionCode, int cliamCode)
        {
            DateTime lastAddUpDay;

            this._totalDayCalculator.ClearCache();

            int status = this._totalDayCalculator.GetTotalDayDmdC(sectionCode, cliamCode, out lastAddUpDay);
            if (status != 0)
            {
                lastAddUpDay = new DateTime();
            }

            return lastAddUpDay;
        }

        /// <summary>
        /// ���񔄏�����������擾
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <param name="cliamCode"></param>
        /// <returns></returns>
        public DateTime GetCurrentTotalDayDmdC(string sectionCode, int cliamCode)
        {
            DateTime lastAddUpDay;
            DateTime currentDay;

            this._totalDayCalculator.ClearCache();

            int status = this._totalDayCalculator.GetTotalDayDmdC(sectionCode, cliamCode, out lastAddUpDay, out currentDay);
            if (status != 0)
            {
                currentDay = new DateTime();
            }

            return currentDay;
        }

        /// <summary>
        /// �������z���擾����
        /// </summary>
        /// <param name="searchCustomerParameter">���Ӑ���/���Ӑ���z���擾�p�p�����[�^ �N���X</param>
        /// <param name="depositCustDmdPrc">�������Ӑ搿�����z���N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �������z�����擾���܂��B
        ///					: �G���[����DepositException��O���������܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        private int GetCustomDemandInfo2(SearchCustomerParameter searchCustomerParameter, 
                                         out DepositCustDmdPrc depositCustDmdPrc,
                                         out string errMsg)
        {
            // �p�����[�^������
            KingetCustDmdPrcWork kingetCustDmdPrcWork;

            int status;
            errMsg = "";
            depositCustDmdPrc = new DepositCustDmdPrc();

            try
            {
                // ����KINGET����
                status = this._kingetCustDmdPrcAcs.Read(out kingetCustDmdPrcWork, 
                                                        searchCustomerParameter.EnterpriseCode, 
                                                        searchCustomerParameter.AddUpSecCod, 
                                                        searchCustomerParameter.CustomerCode, 
                                                        searchCustomerParameter.AddUpADate);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // �N���X�����o�[�R�s�[�����iKINGET�p���Ӑ搿�����z���[�N�N���X�˓������Ӑ搿�����z���N���X�j
                       this. _depositCustDmdPrc = this.CopyToDepositCustDmdPrcFromKingetCustDmdPrcWork(kingetCustDmdPrcWork);

                        depositCustDmdPrc = this._depositCustDmdPrc;

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:

                        this._depositCustDmdPrc = null;
                        depositCustDmdPrc = this._depositCustDmdPrc;

                        break;
                    default:
                        errMsg = "�������z���̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ���Ӑ���/�������z���擾����
		/// </summary>
		/// <param name="searchCustomerParameter">���Ӑ���/���Ӑ���z���擾�p�p�����[�^ �N���X</param>
		/// <param name="depositCustomer">�������Ӑ���N���X</param>
		/// <param name="depositCustDmdPrc">�������Ӑ搿�����z���N���X</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : ���Ӑ���Ɛ������z�����擾���܂��B
		///					: �G���[����DepositException��O���������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private int GetCustomDemandInfo1(SearchCustomerParameter searchCustomerParameter, out DepositCustomer depositCustomer, out DepositCustDmdPrc depositCustDmdPrc)
		{
			// �p�����[�^������
			KingetCustDmdPrcWork kingetCustDmdPrcWork;

            int st;
            depositCustomer = new DepositCustomer();
            depositCustDmdPrc = new DepositCustDmdPrc();

            try
            {
                // ����KINGET����
                st = this._kingetCustDmdPrcAcs.Read(
                    out kingetCustDmdPrcWork, searchCustomerParameter.EnterpriseCode,
                    searchCustomerParameter.AddUpSecCod, searchCustomerParameter.CustomerCode, searchCustomerParameter.AddUpADate);

                switch (st)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // �N���X�����o�[�R�s�[�����iKINGET�p���Ӑ搿�����z���[�N�N���X�˓������Ӑ���N���X�j
                        _depositCustomer = this.CopyToDepositCustomerFromKingetCustDmdPrcWork(kingetCustDmdPrcWork);

                        // �N���X�����o�[�R�s�[�����iKINGET�p���Ӑ搿�����z���[�N�N���X�˓������Ӑ搿�����z���N���X�j
                        _depositCustDmdPrc = this.CopyToDepositCustDmdPrcFromKingetCustDmdPrcWork(kingetCustDmdPrcWork);

                        // �� 20070518 18322 c 
                        // �O������X�V�N�����擾����
                        //int cAddUpUpDate;
                        //this.GetCAddUpHisInfo(searchCustomerParameter.EnterpriseCode, kingetCustDmdPrcWork.TotalDay, out cAddUpUpDate);
                        //
                        //_depositCustomer.CAddUpUpdDate = cAddUpUpDate;

                        _depositCustomer.CAddUpUpdDate = _depositCustomer.CAddUpUpdDate;
                        // �� 20070518 18322 c

                        depositCustomer = _depositCustomer;
                        depositCustDmdPrc = _depositCustDmdPrc;

                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_EOF:

                        _depositCustomer = null;
                        _depositCustDmdPrc = null;
                        depositCustomer = _depositCustomer;
                        depositCustDmdPrc = _depositCustDmdPrc;

                        break;

                    default:

                        throw new DepositException("���Ӑ���̎擾�Ɏ��s���܂����B", st);
                }

                // �� 20070801 18322 a
                if (this._lastMonthlyAddUpHis == null)
                {
                    // �ŏI�������ߓ����擾
                    MonthlyAddUpHisWork monthlyAddUpHisWork = new MonthlyAddUpHisWork();
                    monthlyAddUpHisWork.EnterpriseCode = searchCustomerParameter.EnterpriseCode;
                    monthlyAddUpHisWork.AddUpSecCode = searchCustomerParameter.AddUpSecCod;

                    string retMsg;
                    object retObj = monthlyAddUpHisWork;
                    int status = this._iMonthlyAddUpDB.ReadHis(ref retObj, out retMsg);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        return status;
                    }

                    this._lastMonthlyAddUpHis = retObj as MonthlyAddUpHisWork;
                    if (this._lastMonthlyAddUpHis == null)
                    {
                        // �擾���s
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
                // �� 20070801 18322 a
            }
            catch
            {
                st = -1;
            }

			return st;
		}

		/// <summary>
		/// �������z���擾����
		/// </summary>
		/// <param name="searchCustomerParameter">���Ӑ���/���Ӑ���z���擾�p�p�����[�^ �N���X</param>
		/// <param name="depositCustDmdPrc">�������Ӑ搿�����z���N���X</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �������z�����擾���܂��B
		///					: �G���[����DepositException��O���������܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private int GetCustomDemandInfo2(SearchCustomerParameter searchCustomerParameter, out DepositCustDmdPrc depositCustDmdPrc)
		{
			// �p�����[�^������
			KingetCustDmdPrcWork kingetCustDmdPrcWork;

            int st;
            depositCustDmdPrc = new DepositCustDmdPrc();

            try
            {
                // ����KINGET����
                st = this._kingetCustDmdPrcAcs.Read(
                    out kingetCustDmdPrcWork, searchCustomerParameter.EnterpriseCode,
                    searchCustomerParameter.AddUpSecCod, searchCustomerParameter.CustomerCode, searchCustomerParameter.AddUpADate);

                switch (st)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // �N���X�����o�[�R�s�[�����iKINGET�p���Ӑ搿�����z���[�N�N���X�˓������Ӑ搿�����z���N���X�j
                        _depositCustDmdPrc = this.CopyToDepositCustDmdPrcFromKingetCustDmdPrcWork(kingetCustDmdPrcWork);

                        depositCustDmdPrc = _depositCustDmdPrc;

                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_EOF:

                        _depositCustDmdPrc = null;
                        depositCustDmdPrc = _depositCustDmdPrc;

                        break;

                    default:

                        throw new DepositException("�������z���̎擾�Ɏ��s���܂����B", st);
                }
            }
            catch
            {
                st = -1;
            }

			return st;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        // �� 20070518 18322 d �g�p���Ȃ��̂ō폜
		#region �O������X�V�N�����擾�����i�g�p���Ȃ��̂ō폜�j
		///// <summary>
		///// �O������X�V�N�����擾����
		///// </summary>
		///// <param name="enterpriseCode">��ƃR�[�h</param>
		///// <param name="totalDay">����</param>
		///// <param name="cAddUpUpDate">�����X�V�N����</param>
		///// <returns>ConstantManagement.DB_Status</returns>
		///// <remarks>
		///// <br>Note�@�@�@  : �w�肷������ɑ΂�������X�V�N�������擾���܂��B</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private int GetCAddUpHisInfo(string enterpriseCode, int totalDay, out int cAddUpUpDate)
		//{
		//	CAddUpHis[] cAddUpHis;
		//
		//	// �����X�V�����擾����
		//	int st = this._cAddUpHisAcs.SearchLastCAddUpHis(out cAddUpHis, enterpriseCode, totalDay, 0);
		//
		//	switch (st)
		//	{
		//		case (int)ConstantManagement.DB_Status.ctDB_NORMAL :
		//			
		//			// �����X�V�N�����擾
		//			cAddUpUpDate = TDateTime.DateTimeToLongDate(cAddUpHis[0].CAddUpUpdDate);
		//
		//			break;
		//
		//		case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND :
		//			
		//			// �����X�V�N�����擾
		//			cAddUpUpDate = 0;
		//
		//			break;
		//
		//		default :
		//		
		//			throw new DepositException("�����X�V�����̎擾�Ɏ��s���܂����B", st);
		//	}
		//
		//	return st;
		//}
		#endregion
        // �� 20070518 18322 d

		/// <summary>
		/// �������/�������擾����
		/// </summary>
		/// <param name="searchDepositParameter">�������/�������擾�p�p�����[�^</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �������ƈ��������f�[�^�Z�b�g�Ɏ擾���܂��B
		///					: �G���[����DepositException��O���������܂��B
		///					:   �� Method : GetDsDepositInfo ��茋�ʎ擾</br>
		/// <br>Programmer  : 30414 �E �K�j</br>
		/// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2012/12/24 ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
		/// </remarks>
        private int GetDepositAlwInfo(SearchDepositParameter searchDepositParameter, 
                                      out int customerCode, 
                                      out int claimCode,
                                      out string errMsg)
		{
            int status;
			errMsg = "";
            customerCode = 0;
            claimCode = 0;

			ArrayList arrDepsitMain;
			ArrayList arrDepositAlw;

			SearchParaDepositRead searchParaDepositRead = new SearchParaDepositRead();
			searchParaDepositRead.EnterpriseCode			= searchDepositParameter.EnterpriseCode;			// ��ƃR�[�h
			searchParaDepositRead.AddUpSecCode				= searchDepositParameter.AddUpSecCode;				// �v�㋒�_
            searchParaDepositRead.ClaimCode                 = searchDepositParameter.ClaimCode;                 // ������R�[�h
			searchParaDepositRead.CustomerCode				= searchDepositParameter.CustomerCode;				// ���Ӑ�R�[�h
			searchParaDepositRead.DepositSlipNo				= searchDepositParameter.DepositSlipNo;				// �����`�[�ԍ�
            searchParaDepositRead.AcptAnOdrStatus = searchDepositParameter.AcptAnOdrStatus;                     // �󒍃X�e�[�^�X
            searchParaDepositRead.SalesSlipNum = searchDepositParameter.SalesSlipNum;                           // ����`�[�ԍ�
            // ���������敪(0:�ʏ�����̂݌Ăяo��
            //              1:���������͔�����͓��ō쐬�����ׁA�������͂ł͕ύX�ł��Ȃ��B)
            searchParaDepositRead.AutoDepositCd = -1;
			if (searchDepositParameter.DepositCallMonthsStart == 0)
			{
				// ������ �J�n
				searchParaDepositRead.DepositCallMonthsStart = TDateTime.DateTimeToLongDate(DateTime.MinValue);
			}
			else
			{
                // ������ �J�n
				searchParaDepositRead.DepositCallMonthsStart = searchDepositParameter.DepositCallMonthsStart;
			}
			if (searchDepositParameter.DepositCallMonthsEnd == 0)
			{
				// ������ �I��
				searchParaDepositRead.DepositCallMonthsEnd = TDateTime.DateTimeToLongDate(DateTime.MaxValue);
			}
			else
			{
                // ������ �I��
				searchParaDepositRead.DepositCallMonthsEnd = searchDepositParameter.DepositCallMonthsEnd;
			}
			searchParaDepositRead.AlwcDepositCall			= searchDepositParameter.AlwcDepositCall;			// �����ϓ����`�[�ďo�敪

            try
            {
                // �������/�������擾����
                status = this._searchDepsitAcs.SearchDB(searchParaDepositRead, out arrDepsitMain, out arrDepositAlw, out errMsg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // ----- ADD ���N 2012/12/24 Redmine#33741 ------- >>>>>
                        if (arrDepsitMain.Count != 0 && searchParaDepositRead.ClaimCode == 0)
                        {
                            searchParaDepositRead.ClaimCode = (arrDepsitMain[0] as SearchDepsitMain).ClaimCode;
                        }
                        // ----- ADD ���N 2012/12/24 Redmine#33741 ------- <<<<<
                        // ���㌎���X�V�����擾
                        this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccRec(searchParaDepositRead.AddUpSecCode);

                        // ��������������擾
                        this._lastAddUpDay = GetTotalDayDmdC(searchParaDepositRead.AddUpSecCode, searchParaDepositRead.ClaimCode);

                        // �������/������� �ێ��p�f�[�^�N���X�o�^����
                        SetDepositSaveClass(arrDepsitMain, arrDepositAlw);

                        // �������/�������f�[�^�Z�b�g�o�^����
                        SetDsDepositInfo(arrDepsitMain, arrDepositAlw, out customerCode, out claimCode);

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "�������E�������̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch
            {
                status = -1;
            }

			return (status);
        }

        // ----- ADD ���N 2012/12/24 Redmine#33741 ----->>>>>
        /// <summary>
        /// ����Guid���/�������擾����
        /// </summary>
        /// <param name="searchDepositParameter">����Guid���/�������擾�p�p�����[�^</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �������ƈ��������f�[�^�Z�b�g�Ɏ擾���܂��B
        ///					: �G���[����DepositException��O���������܂��B
        ///					:   �� Method : GetDsDepositInfo ��茋�ʎ擾</br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private int GetDepositGuidInfo(SearchDepositParameter searchDepositParameter,
                                      out int customerCode,
                                      out int claimCode,
                                      out string errMsg)
        {
            int status;
            errMsg = "";
            customerCode = 0;
            claimCode = 0;

            ArrayList arrDepsitMain;
            ArrayList arrDepositAlw;

            SearchParaDepositRead searchParaDepositRead = new SearchParaDepositRead();
            searchParaDepositRead.EnterpriseCode = searchDepositParameter.EnterpriseCode;			// ��ƃR�[�h
            searchParaDepositRead.AddUpSecCode = searchDepositParameter.AddUpSecCode;				// ���_
            searchParaDepositRead.ClaimCode = searchDepositParameter.CustomerCode;                     // ������R�[�h
            searchParaDepositRead.CustomerCode = searchDepositParameter.CustomerCode;				// ���Ӑ�R�[�h
            searchParaDepositRead.AcptAnOdrStatus = searchDepositParameter.AcptAnOdrStatus;         // �󒍃X�e�[�^�X
            searchParaDepositRead.AlwcDepositCall = searchDepositParameter.AlwcDepositCall;			// �����ϓ����`�[�ďo�敪

            // ���������敪(0:�ʏ�����̂݌Ăяo��
            //              1:���������͔�����͓��ō쐬�����ׁA�������͂ł͕ύX�ł��Ȃ��B)
            searchParaDepositRead.AutoDepositCd = -1;

            // ���㌎���X�V�����擾
            this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccRec(searchParaDepositRead.AddUpSecCode);

            // ��������������擾
            this._lastAddUpDay = GetTotalDayDmdC(searchParaDepositRead.AddUpSecCode, searchParaDepositRead.ClaimCode);

            int dateUpDay = TDateTime.DateTimeToLongDate(this._lastAddUpDay.AddDays(1));

            int dateMonth = TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpDay.AddDays(1));

            if (searchDepositParameter.CustomerCode == 0)
            {
                searchParaDepositRead.DepositCallMonthsStart = dateMonth;
            }
            else
            {
                if (dateUpDay > dateMonth)
                {
                    searchParaDepositRead.DepositCallMonthsStart = dateUpDay;
                }
                else
                {
                    searchParaDepositRead.DepositCallMonthsStart = dateMonth;
                }
            }

            try
            {
                // �������/�������擾����
                status = this._searchDepsitAcs.SearchDB(searchParaDepositRead, out arrDepsitMain, out arrDepositAlw, out errMsg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // �������/������� �ێ��p�f�[�^�N���X�o�^����
                        SetDepositSaveClass(arrDepsitMain, arrDepositAlw);

                        // �������f�[�^�Z�b�g�o�^����
                        SetDsDepositGuidInfo(arrDepsitMain, arrDepositAlw, out customerCode, out claimCode);

                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        errMsg = "�������E�������̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }
        // ----- ADD ���N 2012/12/24 Redmine#33741 -----<<<<<

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �������/�������擾����
        /// </summary>
        /// <param name="searchDepositParameter">�������/�������擾�p�p�����[�^</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �������ƈ��������f�[�^�Z�b�g�Ɏ擾���܂��B
        ///					: �G���[����DepositException��O���������܂��B
        ///					:   �� Method : GetDsDepositInfo ��茋�ʎ擾</br>
        /// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// </remarks>
        private int GetDepositAlwInfo(SearchDepositParameter searchDepositParameter, out int customerCode, out int claimCode)
        {
            int st;
            string errMsg;

            customerCode = 0;
            claimCode = 0;

            ArrayList arrDepsitMain;
            ArrayList arrDepositAlw;
            // �� 20070125 18322 c MA.NS�p�ɕύX
            #region SF �i�S�ăR�����g�A�E�g�j
            //SearchParaDepositRead searchParaDepositRead = new SearchParaDepositRead();
            //searchParaDepositRead.EnterpriseCode			= searchDepositParameter.EnterpriseCode;			// ��ƃR�[�h
            //searchParaDepositRead.AddUpSecCode				= searchDepositParameter.AddUpSecCod;				// �v�㋒�_
            //searchParaDepositRead.CustomerCode				= searchDepositParameter.CustomerCode;				// ���Ӑ�R�[�h
            //searchParaDepositRead.DepositSlipNo				= searchDepositParameter.DepositSlipNo;				// �����`�[�ԍ�
            //
            //searchParaDepositRead.AcceptAnOrderNo			= searchDepositParameter.AcceptAnOrderNo;			// �󒍔ԍ�
            //if (searchDepositParameter.DepositDateStart == 0)
            //{
            //	searchParaDepositRead.DepositCallMonthsStart	= DateTime.MinValue;							// ������ �J�n
            //}
            //else
            //{
            //	searchParaDepositRead.DepositCallMonthsStart	= 
            //		TDateTime.LongDateToDateTime(searchDepositParameter.DepositDateStart);						// ������ �J�n
            //}
            //if (searchDepositParameter.DepositDateEnd == 0)
            //{
            //	searchParaDepositRead.DepositCallMonthsEnd		= DateTime.MaxValue;							// ������ �I��
            //}
            //else
            //{
            //	searchParaDepositRead.DepositCallMonthsEnd		= 
            //		TDateTime.LongDateToDateTime(searchDepositParameter.DepositDateEnd);						// ������ �I��
            //}
            #endregion

            SearchParaDepositRead searchParaDepositRead = new SearchParaDepositRead();
            searchParaDepositRead.EnterpriseCode = searchDepositParameter.EnterpriseCode;			// ��ƃR�[�h
            searchParaDepositRead.AddUpSecCode = searchDepositParameter.AddUpSecCode;				// �v�㋒�_
            searchParaDepositRead.ClaimCode = searchDepositParameter.ClaimCode;                 // ������R�[�h
            searchParaDepositRead.CustomerCode = searchDepositParameter.CustomerCode;				// ���Ӑ�R�[�h
            searchParaDepositRead.DepositSlipNo = searchDepositParameter.DepositSlipNo;				// �����`�[�ԍ�

            // �󒍔ԍ�
            // searchParaDepositRead.AcceptAnOrderNo = searchDepositParameter.AcceptAnOrderNo;   // 2007.10.05 del

            // �󒍃X�e�[�^�X
            searchParaDepositRead.AcptAnOdrStatus = searchDepositParameter.AcptAnOdrStatus;      // 2007.10.05 add

            // ����`�[�ԍ�
            searchParaDepositRead.SalesSlipNum = searchDepositParameter.SalesSlipNum;            // 2007.10.05 add

            // SFUKK01406U.SetSalesParameter()���Q�Ƃ��ĉ������B

            // ���������敪(0:�ʏ�����̂݌Ăяo��
            //              1:���������͔�����͓��ō쐬�����ׁA�������͂ł͕ύX�ł��Ȃ��B)
            searchParaDepositRead.AutoDepositCd = -1;

            // �T�[�r�X�`�[�敪(0:OFF�̂݌Ăяo���A
            //                  1:ON�͓������͂ł͍쐬�ł��Ȃ��ׁA�Ăяo���s��)
            // searchParaDepositRead.ServiceSlipCd = 0;   // 2007.10.05 hikita del

            if (searchDepositParameter.DepositCallMonthsStart == 0)
            {
                // ������ �J�n
                searchParaDepositRead.DepositCallMonthsStart = TDateTime.DateTimeToLongDate(DateTime.MinValue);
            }
            else
            {
                // ������ �J�n
                searchParaDepositRead.DepositCallMonthsStart = searchDepositParameter.DepositCallMonthsStart;
            }
            if (searchDepositParameter.DepositCallMonthsEnd == 0)
            {
                // ������ �I��
                searchParaDepositRead.DepositCallMonthsEnd = TDateTime.DateTimeToLongDate(DateTime.MaxValue);
            }
            else
            {
                // ������ �I��
                searchParaDepositRead.DepositCallMonthsEnd = searchDepositParameter.DepositCallMonthsEnd;
            }
            // �� 20070125 18322 c

            searchParaDepositRead.AlwcDepositCall = searchDepositParameter.AlwcDepositCall;			// �����ϓ����`�[�ďo�敪

            try
            {
                // �������/�������擾����
                st = _searchDepsitAcs.SearchDB(searchParaDepositRead, out arrDepsitMain, out arrDepositAlw, out errMsg);

                switch (st)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                        // �������/������� �ێ��p�f�[�^�N���X�o�^����
                        this.SetDepositSaveClass(arrDepsitMain, arrDepositAlw);

                        // �������/�������f�[�^�Z�b�g�o�^����
                        int customerCode1 = 0;
                        int claimCode1 = 0;

                        this.SetDsDepositInfo(arrDepsitMain, arrDepositAlw, out customerCode1, out claimCode1);

                        customerCode = customerCode1;
                        claimCode = claimCode1;
                        break;

                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:

                        customerCode = 0;
                        claimCode = 0;

                        break;

                    default:

                        throw new DepositException(errMsg, st);
                }
            }
            catch
            {
                st = -1;
            }

            return st;
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        // �� 20070122 18322 c MA.NS�p�ɕύX
        #region SF ����������擾�����i�S�ăR�����g�A�E�g�j
		///// <summary>
		///// ����������擾����
		///// </summary>
		///// <param name="searchSalesParameter">����������擾�p�p�����[�^</param>
		///// <returns>ConstantManagement.DB_Status</returns>
		///// <remarks>
		///// <br>Note�@�@�@  : ������������f�[�^�Z�b�g�Ɏ擾���܂��B
		/////					: �G���[����DepositException��O���������܂��B</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private int GetDmdSalesInfo(SearchSalesParameter searchSalesParameter)
		//{
		//	string errMsg;
		//	
		//	ArrayList arrDmdSales;
		//	SearchParaDmdSalesRead searchParaDmdSalesRead = new SearchParaDmdSalesRead();
		//	searchParaDmdSalesRead.EnterpriseCode	= searchSalesParameter.EnterpriseCode;			// ��ƃR�[�h
		//	searchParaDmdSalesRead.AddUpSecCode		= searchSalesParameter.AddUpSecCod;				// �v�㋒�_
		//	searchParaDmdSalesRead.ClaimCode		= searchSalesParameter.CustomerCode;			// ������R�[�h
		//	searchParaDmdSalesRead.AcceptAnOrderNo	= searchSalesParameter.AcceptAnOrderNo;			// �󒍓`�[�ԍ�
		//	searchParaDmdSalesRead.SlipNo			= searchSalesParameter.SlipNo;					// �`�[�ԍ�
		//	if (searchSalesParameter.SearchSlipDateStart == 0)
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateStart	= DateTime.MinValue;					// �`�[���t �J�n
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.SearchSlipDateStart);			// �`�[���t �J�n
		//	}
		//	if (searchSalesParameter.SearchSlipDateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateEnd	= DateTime.MaxValue;					// �`�[���t �I��
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.SearchSlipDateEnd);			// �`�[���t �I��
		//	}
		//	if (searchSalesParameter.AddUpADateStart == 0)
		//	{
		//		searchParaDmdSalesRead.AddUpADateStart	= DateTime.MinValue;						// ����� �J�n
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AddUpADateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AddUpADateStart);				// ����� �J�n
		//	}
		//	if (searchSalesParameter.AddUpADateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.AddUpADateEnd	= DateTime.MaxValue;						// ����� �I��
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AddUpADateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AddUpADateEnd);				// ����� �I��
		//	}
		//	searchParaDmdSalesRead.AlwcDmdSalesCall	= searchSalesParameter.AlwcDmdSalesCall;		// �����ϐ�������`�[�ďo�敪
		//	searchParaDmdSalesRead.AcptAnOdrStatus	= searchSalesParameter.AcptAnOdrStatus;			// �󒍃X�e�[�^�X
		//	searchParaDmdSalesRead.DataInputSystem	= searchSalesParameter.DataInputSystem;			// �f�[�^���̓V�X�e��
        //
		//	searchParaDmdSalesRead.AutoAuctionDiv	= searchSalesParameter.AutoAuctionDiv;			// AA���o�敪
		//	searchParaDmdSalesRead.CreditOrLoanCd	= searchSalesParameter.CreditOrLoanCd;			// �N���W�b�g�E���[���敪
		//	searchParaDmdSalesRead.CreditCompanyCode	= searchSalesParameter.CreditCompanyCode;	// �N���W�b�g��ЃR�[�h
		//	searchParaDmdSalesRead.SalesEmployeeCd	= searchSalesParameter.SalesEmployeeCd;			// �̔��]�ƈ��R�[�h
		//	if (searchSalesParameter.AcceptAnOrderDateStart == 0)
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateStart	= DateTime.MinValue;				// �󒍓� �J�n
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AcceptAnOrderDateStart);		// �󒍓� �J�n
		//	}
		//	if (searchSalesParameter.AcceptAnOrderDateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateEnd	= DateTime.MaxValue;					// �󒍓� �I��
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AcceptAnOrderDateEnd);		// �󒍓� �I��
		//	}
		//	if (searchSalesParameter.CarDeliExpectedDateStart == 0)
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateStart	= DateTime.MinValue;				// �[�ԗ\��� �J�n
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.CarDeliExpectedDateStart);	// �[�ԗ\��� �J�n
		//	}
		//	if (searchSalesParameter.CarDeliExpectedDateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateEnd	= DateTime.MaxValue;				// �[�ԗ\��� �I��
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.CarDeliExpectedDateEnd);		// �[�ԗ\��� �I��
		//	}
        //
		//	// --- ����������擾���� --- //
		//	int st = _searchDmdSalesAcs.SearchDB(searchParaDmdSalesRead, out arrDmdSales, out errMsg);
		//	
		//	switch (st)
		//	{
		//		case (int)ConstantManagement.DB_Status.ctDB_NORMAL :
        //
		//			// �������� �ێ��p�f�[�^�N���X�ǉ�����
		//			this.InsertDmdSalesSaveClass(arrDmdSales);
        //
		//			// ����������f�[�^�Z�b�g�o�^����
		//			this.SetDsDmdSalesInfo(arrDmdSales);
        //
		//			break;
        //
		//		case (int)ConstantManagement.DB_Status.ctDB_EOF :
        //
		//			break;
        //
		//		default :
        //
		//			throw new DepositException(errMsg, st);
		//	}
        //
		//	return st;
		//}

        ///// <summary>
		///// ����������擾����
		///// </summary>
		///// <param name="searchSalesParameter">����������擾�p�p�����[�^</param>
		///// <param name="searchDmdSalesList">�擾��������f�[�^</param>
		///// <returns>ConstantManagement.DB_Status</returns>
		///// <remarks>
		///// <br>Note�@�@�@  : ������������f�[�^�Z�b�g�Ɏ擾���܂��B
		/////					: �G���[����DepositException��O���������܂��B</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private int GetDmdSalesInfo(SearchSalesParameter searchSalesParameter, out SearchDmdSales[] searchDmdSalesList)
		//{
		//	string errMsg;
		//	searchDmdSalesList = null;
		//	
		//	ArrayList arrDmdSales;
		//	SearchParaDmdSalesRead searchParaDmdSalesRead = new SearchParaDmdSalesRead();
		//	searchParaDmdSalesRead.EnterpriseCode	= searchSalesParameter.EnterpriseCode;			// ��ƃR�[�h
		//	searchParaDmdSalesRead.AddUpSecCode		= searchSalesParameter.AddUpSecCod;				// �v�㋒�_
		//	searchParaDmdSalesRead.ClaimCode		= searchSalesParameter.CustomerCode;			// ������R�[�h
		//	searchParaDmdSalesRead.AcceptAnOrderNo	= searchSalesParameter.AcceptAnOrderNo;			// �󒍓`�[�ԍ�
		//	searchParaDmdSalesRead.SlipNo			= searchSalesParameter.SlipNo;					// �`�[�ԍ�
		//	if (searchSalesParameter.SearchSlipDateStart == 0)
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateStart	= DateTime.MinValue;					// �`�[���t �J�n
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.SearchSlipDateStart);			// �`�[���t �J�n
		//	}
		//	if (searchSalesParameter.SearchSlipDateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateEnd	= DateTime.MaxValue;					// �`�[���t �I��
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.SearchSlipDateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.SearchSlipDateEnd);			// �`�[���t �I��
		//	}
		//	if (searchSalesParameter.AddUpADateStart == 0)
		//	{
		//		searchParaDmdSalesRead.AddUpADateStart	= DateTime.MinValue;						// ����� �J�n
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AddUpADateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AddUpADateStart);				// ����� �J�n
		//	}
		//	if (searchSalesParameter.AddUpADateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.AddUpADateEnd	= DateTime.MaxValue;						// ����� �I��
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AddUpADateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AddUpADateEnd);				// ����� �I��
		//	}
		//	searchParaDmdSalesRead.AlwcDmdSalesCall	= searchSalesParameter.AlwcDmdSalesCall;		// �����ϐ�������`�[�ďo�敪
		//	searchParaDmdSalesRead.AcptAnOdrStatus	= searchSalesParameter.AcptAnOdrStatus;			// �󒍃X�e�[�^�X
		//	searchParaDmdSalesRead.DataInputSystem	= searchSalesParameter.DataInputSystem;			// �f�[�^���̓V�X�e��
        //
		//	searchParaDmdSalesRead.AutoAuctionDiv	= searchSalesParameter.AutoAuctionDiv;			// AA���o�敪
		//	searchParaDmdSalesRead.CreditOrLoanCd	= searchSalesParameter.CreditOrLoanCd;			// �N���W�b�g�E���[���敪
		//	searchParaDmdSalesRead.CreditCompanyCode	= searchSalesParameter.CreditCompanyCode;	// �N���W�b�g��ЃR�[�h
		//	searchParaDmdSalesRead.SalesEmployeeCd	= searchSalesParameter.SalesEmployeeCd;			// �̔��]�ƈ��R�[�h
		//	if (searchSalesParameter.AcceptAnOrderDateStart == 0)
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateStart	= DateTime.MinValue;				// �󒍓� �J�n
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AcceptAnOrderDateStart);		// �󒍓� �J�n
		//	}
		//	if (searchSalesParameter.AcceptAnOrderDateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateEnd	= DateTime.MaxValue;					// �󒍓� �I��
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.AcceptAnOrderDateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.AcceptAnOrderDateEnd);		// �󒍓� �I��
		//	}
		//	if (searchSalesParameter.CarDeliExpectedDateStart == 0)
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateStart	= DateTime.MinValue;				// �[�ԗ\��� �J�n
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateStart	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.CarDeliExpectedDateStart);	// �[�ԗ\��� �J�n
		//	}
		//	if (searchSalesParameter.CarDeliExpectedDateEnd == 0)
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateEnd	= DateTime.MaxValue;				// �[�ԗ\��� �I��
		//	}
		//	else
		//	{
		//		searchParaDmdSalesRead.CarDeliExpectedDateEnd	= 
		//			TDateTime.LongDateToDateTime(searchSalesParameter.CarDeliExpectedDateEnd);		// �[�ԗ\��� �I��
		//	}
        //
		//	// --- ����������擾���� --- //
		//	int st = _searchDmdSalesAcs.SearchDB(searchParaDmdSalesRead, out arrDmdSales, out errMsg);
		//	
		//	switch (st)
		//	{
		//		case (int)ConstantManagement.DB_Status.ctDB_NORMAL :
        //
		//			// �������� �ێ��p�f�[�^�N���X�ǉ�����
		//			this.InsertDmdSalesSecondSaveClass(arrDmdSales);
        //
		//			// �擾��������f�[�^���R���N�V�����ɕۑ�
		//			searchDmdSalesList = (SearchDmdSales[])arrDmdSales.ToArray(typeof(SearchDmdSales));
        //
		//			break;
        //
		//		case (int)ConstantManagement.DB_Status.ctDB_EOF :
        //
		//			break;
        //
		//		default :
        //
		//			throw new DepositException(errMsg, st);
		//	}
        //
		//	return st;
        //}
        #endregion

		/// <summary>
		/// ����������擾����
		/// </summary>
		/// <param name="searchSalesParameter">����������擾�p�p�����[�^</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : ������������f�[�^�Z�b�g�Ɏ擾���܂��B
		///					: �G���[����DepositException��O���������܂��B</br>
		/// <br>Programmer  : 30414 �E �K�j</br>
		/// <br>Date        : 2008/06/26</br>
		/// </remarks>
		private int GetClaimSalesInfo(SearchSalesParameter searchSalesParameter, out string errMsg)
		{
			errMsg = "";
			
			ArrayList arrClaimSales;

            // ����������擾�p�p�����[�^�𐿋�����f�[�^�����p�p�����[�^�ɕϊ�
            SearchParaClaimSalesRead searchParaClaimSalesRead =
                  CopyToSearchParaClaimSalesReadFromSalesParameter(searchSalesParameter);

			// --- ����������擾���� --- //
			int status = this._searchClaimSalesAcs.SearchDB(searchParaClaimSalesRead, 
                                                            out arrClaimSales, 
                                                            out errMsg);
			
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL :

                    // ���㌎���X�V�����擾
                    this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccRec(searchParaClaimSalesRead.DemandAddUpSecCd);

                    // ��������������擾
                    this._lastAddUpDay = GetTotalDayDmdC(searchParaClaimSalesRead.DemandAddUpSecCd, searchParaClaimSalesRead.ClaimCode);

					// �������� �ێ��p�f�[�^�N���X�ǉ�����
					this.InsertDmdSalesSaveClass(arrClaimSales);

					// ����������f�[�^�Z�b�g�o�^����
					this.SetDsDmdSalesInfo(arrClaimSales);

					break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
					break;
				default :
                    errMsg = "����������̎擾�Ɏ��s���܂����B";
                    break;
			}

			return (status);
        }

        /// <summary>
        /// ����������擾����
        /// </summary>
        /// <param name="searchSalesParameter">����������擾�p�p�����[�^</param>
        /// <param name="searchClaimSalesList">�擾��������f�[�^</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : ������������f�[�^�Z�b�g�Ɏ擾���܂��B
        ///					: �G���[����DepositException��O���������܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        private int GetClaimSalesInfo(SearchSalesParameter searchSalesParameter, 
                                      out SearchClaimSales[] searchClaimSalesList,
                                      out string errMsg)
        {
            errMsg = "";
            searchClaimSalesList = null;

            ArrayList arrClaimSales;

            // ����������擾�p�p�����[�^�𐿋�����f�[�^�����p�p�����[�^�ɕϊ�
            SearchParaClaimSalesRead searchParaClaimSalesRead =
                  CopyToSearchParaClaimSalesReadFromSalesParameter(searchSalesParameter);

            // --- ����������擾���� --- //
            int status = this._searchClaimSalesAcs.SearchDB(searchParaClaimSalesRead, out arrClaimSales, out errMsg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                    // �������� �ێ��p�f�[�^�N���X�ǉ�����
                    this.InsertDmdSalesSecondSaveClass(arrClaimSales);

                    // �擾��������f�[�^���R���N�V�����ɕۑ�
                    searchClaimSalesList = (SearchClaimSales[])arrClaimSales.ToArray(typeof(SearchClaimSales));

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    errMsg = "����������̎擾�Ɏ��s���܂����B";
                    break;
            }

            return (status);
        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ����������擾����
        /// </summary>
        /// <param name="searchSalesParameter">����������擾�p�p�����[�^</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : ������������f�[�^�Z�b�g�Ɏ擾���܂��B
        ///					: �G���[����DepositException��O���������܂��B</br>
        /// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// </remarks>
        private int GetClaimSalesInfo(SearchSalesParameter searchSalesParameter)
        {
            string errMsg;

            ArrayList arrClaimSales;

            // ����������擾�p�p�����[�^�𐿋�����f�[�^�����p�p�����[�^�ɕϊ�
            SearchParaClaimSalesRead searchParaClaimSalesRead =
                  CopyToSearchParaClaimSalesReadFromSalesParameter(searchSalesParameter);

            // --- ����������擾���� --- //
            int st = _searchClaimSalesAcs.SearchDB(searchParaClaimSalesRead
                                                  , out arrClaimSales
                                                  , out errMsg
                                                  );

            switch (st)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                    // �������� �ێ��p�f�[�^�N���X�ǉ�����
                    this.InsertDmdSalesSaveClass(arrClaimSales);

                    // ����������f�[�^�Z�b�g�o�^����
                    this.SetDsDmdSalesInfo(arrClaimSales);

                    break;

                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:

                    break;

                default:

                    throw new DepositException(errMsg, st);
            }

            return st;
        }

        /// <summary>
		/// ����������擾����
		/// </summary>
		/// <param name="searchSalesParameter">����������擾�p�p�����[�^</param>
		/// <param name="searchClaimSalesList">�擾��������f�[�^</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : ������������f�[�^�Z�b�g�Ɏ擾���܂��B
		///					: �G���[����DepositException��O���������܂��B</br>
		/// <br>Programmer  : 18322 T.Kimura</br>
		/// <br>Date        : 2007.01.22</br>
		/// </remarks>
		private int GetClaimSalesInfo(SearchSalesParameter searchSalesParameter, out SearchClaimSales[] searchClaimSalesList)
		{
			string errMsg;
			searchClaimSalesList = null;
			
			ArrayList arrClaimSales;

            // ����������擾�p�p�����[�^�𐿋�����f�[�^�����p�p�����[�^�ɕϊ�
            SearchParaClaimSalesRead searchParaClaimSalesRead =
                  CopyToSearchParaClaimSalesReadFromSalesParameter(searchSalesParameter);

			// --- ����������擾���� --- //
			int st = _searchClaimSalesAcs.SearchDB(searchParaClaimSalesRead, out arrClaimSales, out errMsg);
			
			switch (st)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL :

					// �������� �ێ��p�f�[�^�N���X�ǉ�����
					this.InsertDmdSalesSecondSaveClass(arrClaimSales);

					// �擾��������f�[�^���R���N�V�����ɕۑ�
					searchClaimSalesList = (SearchClaimSales[])arrClaimSales.ToArray(typeof(SearchClaimSales));

					break;

				case (int)ConstantManagement.DB_Status.ctDB_EOF :

					break;

				default :

					throw new DepositException(errMsg, st);
			}

			return st;
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        /// <summary>
		///   ���������񌟍��p�p�����[�^�ϊ�����
		/// </summary>
		/// <param name="searchSalesParameter">����������擾�p�p�����[�^</param>
		/// <returns>SearchParaClaimSalesRead</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : ��ʂœ��͂��ꂽ�p�����[�^�𐿋�����f�[�^�����p�����[�^�ɕϊ����܂��B</br>
		/// <br>Programmer  : 18322 T.Kimura</br>
		/// <br>Date        : 2007.01.22</br>
		/// </remarks>
		private SearchParaClaimSalesRead CopyToSearchParaClaimSalesReadFromSalesParameter(SearchSalesParameter searchSalesParameter)
		{
			SearchParaClaimSalesRead searchParaClaimSalesRead = new SearchParaClaimSalesRead();

            // ��ƃR�[�h
			searchParaClaimSalesRead.EnterpriseCode   = searchSalesParameter.EnterpriseCode;
            // �󒍃X�e�[�^�X
            searchParaClaimSalesRead.AcptAnOdrStatus  = searchSalesParameter.AcptAnOdrStatus;
            // ����`�[�ԍ�
            searchParaClaimSalesRead.SalesSlipNum     = searchSalesParameter.SalesSlipNum;
            // ���Ӑ�R�[�h
            searchParaClaimSalesRead.CustomerCode = searchSalesParameter.CustomerCode;
            // ������R�[�h
            searchParaClaimSalesRead.ClaimCode        = searchSalesParameter.ClaimCode;
            // �v���
			if (searchSalesParameter.AddUpADateStart == 0)
			{
				// �v��� �J�n
				searchParaClaimSalesRead.AddUpADateStart = TDateTime.DateTimeToLongDate(DateTime.MinValue);
			}
			else
			{
				// �v��� �J�n
				searchParaClaimSalesRead.AddUpADateStart = searchSalesParameter.AddUpADateStart;
			}

			if (searchSalesParameter.AddUpADateEnd == 0)
			{
				// �v��� �I��
				searchParaClaimSalesRead.AddUpADateEnd = TDateTime.DateTimeToLongDate(DateTime.MaxValue);
			}
			else
			{
				// �v��� �I��
				searchParaClaimSalesRead.AddUpADateEnd = searchSalesParameter.AddUpADateEnd;
			}

			// �����v�㋒�_
			searchParaClaimSalesRead.DemandAddUpSecCd = searchSalesParameter.DemandAddUpSecCd;

            // ���ьv�㋒�_
			searchParaClaimSalesRead.ResultsAddUpSecCd = searchSalesParameter.ResultsAddUpSecCd;

    		// �����ϐ�������`�[�ďo�敪
            searchParaClaimSalesRead.AlwcSalesSlipCall	= searchSalesParameter.AlwcSalesSlipCall;
			
            // �̔��]�ƈ��R�[�h
			searchParaClaimSalesRead.SalesEmployeeCd	= searchSalesParameter.SalesEmployeeCd;

            // �`�[�������t
            if (searchSalesParameter.SearchSlipDateStart == 0)
			{
                // �`�[���t �J�n
				searchParaClaimSalesRead.SearchSlipDateStart = TDateTime.DateTimeToLongDate(DateTime.MinValue);
			}
			else
			{
			    // �`�[���t �J�n
				searchParaClaimSalesRead.SearchSlipDateStart = searchSalesParameter.SearchSlipDateStart;
			}

			if (searchSalesParameter.SearchSlipDateEnd == 0)
			{
				// �`�[���t �I��
				searchParaClaimSalesRead.SearchSlipDateEnd	= TDateTime.DateTimeToLongDate(DateTime.MaxValue);
			}
			else
			{
			    // �`�[���t �I��
				searchParaClaimSalesRead.SearchSlipDateEnd	= searchSalesParameter.SearchSlipDateEnd;
			}
			
            // �� 20070525 18322 a
            // ���|�敪�������Ɋ܂߂Ȃ�
            searchParaClaimSalesRead.AccRecDivCd = -1;

            // ���������������Ɋ܂߂Ȃ�
            searchParaClaimSalesRead.AutoDepositCd = -1;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            // �T�[�r�X�`�[�敪(0:OFF�̂݌Ăяo���A
            //                  1:ON�͓������͂ł͍쐬�ł��Ȃ��ׁA�Ăяo���s��)
            searchParaClaimSalesRead.ServiceSlipCd = 0;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // �� 20070525 18322 a

			return searchParaClaimSalesRead;
		}
        // �� 20070122 18322 c


        // �� 20070122 18322 c MA.NS�p�ɕύX
        #region SF ������󒍓`�[�̃`�F�b�N�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// ������󒍓`�[�̃`�F�b�N����
		///// </summary>
		///// <param name="kbn">�`�F�b�N�敪 0:��,1:��,2:���E�ςݍ�,3:���ς�</param>
		///// <param name="acceptAnOrderNo">�`�F�b�N�Ώێ󒍔ԍ�</param>
		///// <param name="enterpriseCode">��ƃR�[�h</param>
		///// <param name="addUpSecCod">�����v�㋒�_</param>
		///// <param name="customerCode">������R�[�h</param>
		///// <param name="message">�G���[�����b�Z�[�W</param>
		///// <returns>�X�e�[�^�X 0:�`�F�b�N�敪�̎󒍖���. 2:�`�F�b�N�敪�̎󒍗L��, �ȊO:���̑��G���[ </returns>
		///// <remarks>
		///// <br>Note       : ������̎󒍓`�[�̏�Ԃ��`�F�b�N���A�`�F�b�N��ނɂ��킹���X�e�[�^�X��Ԃ��܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//private int CheackAllowanceSalese(int kbn, int acceptAnOrderNo, string enterpriseCode, string addUpSecCod, int customerCode, out string message)
		//{
		//	message = "";
        //
		//	bool hitFlg = false;
        //
		//	// ����������DataRow�̎擾
		//	foreach (System.Data.DataRow drSales in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
		//	{
		//		// ����󒍔ԍ��̎�
		//		if (acceptAnOrderNo == Convert.ToInt32(drSales[ctAcceptAnOrderNo]))
		//		{
		//			hitFlg = true;
        //
		//			switch (kbn)
		//			{
		//				case 0:		// --- ���`�[�`�F�b�N --- //
        //
		//					if (Convert.ToInt32(drSales[ctDmdSalesDebitNoteCd]) == 0)
		//					{
		//						return 2;
		//					}
		//					
		//					break;
		//				
		//				case 1:		// --- �ԓ`�[�`�F�b�N --- //
        //
		//					if (Convert.ToInt32(drSales[ctDmdSalesDebitNoteCd]) == 1)
		//					{
		//						return 2;
		//					}
		//					
		//					break;
		//				
		//				case 2:		// --- ���E�ςݍ��`�[�`�F�b�N --- //
        //
		//					if (Convert.ToInt32(drSales[ctDmdSalesDebitNoteCd]) == 2)
		//					{
		//						return 2;
		//					}
		//					
		//					break;
		//				
		//				case 3:		// --- ���ςݓ`�[�`�F�b�N --- //
		//					
		//					if (drSales[ctSalesClosedFlg].ToString() != "")
		//					{
		//						return 2;
		//					}
        //
		//					break;
		//			}
        //
		//			break;
		//		}
		//	}
		//	
		//	// �����ɊY������󒍃f�[�^������������
		//	// ���ŏ��̃����[�g�łЂ��ςĂ��ĂȂ��� (���������O�̎󒍂Ƃ�����)
		//	if (hitFlg == false)
		//	{
        //        // �Q���Ǎ��o�b�t�@�ɓ����Ă���΂�������擾
		//		SearchDmdSales searchDmdSales = null;
		//		for (int ix = 0; ix < this._dmdSalesSecond.Count; ix++)
		//		{
		//			// ����󒍔ԍ��̎�
		//			if (acceptAnOrderNo == ((SearchDmdSales)this._dmdSalesSecond[ix]).AcceptAnOrderNo)
		//			{
		//				searchDmdSales = (SearchDmdSales)this._dmdSalesSecond[ix];
		//				break;
		//			}
        //        }
        //
		//		// �Q���Ǎ��o�b�t�@�ɂ��������́A�ēx�Ǎ��擾���� ���Q���Ǎ��o�b�t�@�ɂ��ێ�����
		//		if (searchDmdSales == null)
		//		{
		//			try
		//			{
		//				SearchSalesParameter parameter = new SearchSalesParameter();
		//				SearchDmdSales[] searchDmdSalesList;
        //
		//				parameter.EnterpriseCode	= enterpriseCode;						// ��ƃR�[�h
		//				parameter.AddUpSecCod		= addUpSecCod;							// �v�㋒�_
		//				parameter.CustomerCode		= customerCode;							// ������R�[�h
		//				parameter.AcceptAnOrderNo	= acceptAnOrderNo;						// �󒍓`�[�ԍ�
		//				parameter.AcptAnOdrStatus	= new int[] {10, 20, 30};				// �󒍃X�e�[�^�X
		//				parameter.CreditOrLoanCd	= new int[] {0, 1, 2};					// �N���W�b�g�E���[���敪
		//				parameter.DataInputSystem	= new int[] {1, 2, 3};					// �f�[�^���̓V�X�e��
        //
		//				// ����������擾����
		//				if (this.GetDmdSalesInfo(parameter, out searchDmdSalesList) == 0)
		//				{
		//					// �擾�������������� �߂�͂P�������Ȃ��͂�
		//					searchDmdSales = searchDmdSalesList[0];
		//				}
		//			}
		//			catch ( DepositException ex )
		//			{
		//				message = ex.Message;
		//				return ex.Status;
		//			}
		//			catch ( Exception ex )
		//			{
		//				message = ex.Message;
		//				return -999;
		//			}
		//		}
        //
		//		if (searchDmdSales != null)
		//		{
		//			switch (kbn)
		//			{
		//				case 0:		// --- ���`�[�`�F�b�N --- //
        //
		//					if (searchDmdSales.DebitNoteDiv == 0)
		//					{
		//						return 2;
		//					}
		//							
		//					break;
        //
		//				case 1:		// --- �ԓ`�[�`�F�b�N --- //
        //
		//					if (searchDmdSales.DebitNoteDiv == 1)
		//					{
		//						return 2;
		//					}
		//							
		//					break;
		//						
		//				case 2:		// --- ���E�ςݍ��`�[�`�F�b�N --- //
        //
		//					if (searchDmdSales.DebitNoteDiv == 2)
		//					{
		//						return 2;
		//					}
		//							
		//					break;
		//				
		//				case 3:		// --- ���ςݓ`�[�`�F�b�N --- //
		//					
		//					if (TDateTime.DateTimeToLongDate(searchDmdSales.AddUpADate) <= this._depositCustomer.CAddUpUpdDate)
		//					{
		//						return 2;
		//					}
        //
		//					break;
		//			}
		//		}
		//	}
        //
		//	return 0;
        //}
        #endregion

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ������󒍓`�[�̃`�F�b�N����
		/// </summary>
		/// <param name="kbn">�`�F�b�N�敪 0:��,1:��,2:���E�ςݍ�,3:���ς�</param>
        /// <param name="salesSlipNum">�`�F�b�N�Ώ� ����ԍ�</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="addUpSecCod">�����v�㋒�_</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="message">�G���[�����b�Z�[�W</param>
		/// <returns>�X�e�[�^�X 0:�`�F�b�N�敪�̎󒍖���. 2:�`�F�b�N�敪�̎󒍗L��, �ȊO:���̑��G���[ </returns>
		/// <remarks>
		/// <br>Note       : ������̎󒍓`�[�̏�Ԃ��`�F�b�N���A�`�F�b�N��ނɂ��킹���X�e�[�^�X��Ԃ��܂��B</br>
		/// <br>Programmer : 18322 T.Kimura</br>
		/// <br>Date       : 2007.01.22</br>
		/// </remarks>
		private int CheackAllowanceSalese(     int     kbn
		//                                 ,     int     acceptAnOrderNo   // 2007.10.05 hikita del
                                         ,     string  salesSlipNum        // 2007.10.05 hikita add
		                                 ,     string  enterpriseCode
		                                 ,     string  addUpSecCod
		                                 ,     int     customerCode
                                         ,     int     claimCode
                                         ,     int[]   acptAnOdrStatus 
		                                 ,     out string  message
		                                 )
		{
			message = "";

			bool hitFlg = false;

			// ����������DataRow�̎擾
			foreach (DataRow drSales in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
			{
				// ����󒍔ԍ��̎�
				//if (acceptAnOrderNo == Convert.ToInt32(drSales[ctAcceptAnOrderNo]))   // 2007.10.05 hikita del
                // ���ꔄ��ԍ��̎�
                if (salesSlipNum == Convert.ToString(drSales[ctSalesSlipNum]))          // 2007.10.05 hikita add
				{
					hitFlg = true;

					switch (kbn)
					{
						case 0:		// --- ���`�[�`�F�b�N --- //

							if (Convert.ToInt32(drSales[ctDmdSalesDebitNoteCd]) == 0)
							{
								return 2;
							}
							
							break;
						
						case 1:		// --- �ԓ`�[�`�F�b�N --- //

							if (Convert.ToInt32(drSales[ctDmdSalesDebitNoteCd]) == 1)
							{
								return 2;
							}
							
							break;
						
						case 2:		// --- ���E�ςݍ��`�[�`�F�b�N --- //

							if (Convert.ToInt32(drSales[ctDmdSalesDebitNoteCd]) == 2)
							{
								return 2;
							}
							
							break;
						
						case 3:		// --- ���ςݓ`�[�`�F�b�N --- //
							
							if (drSales[ctSalesClosedFlg].ToString() != "")
							{
								return 2;
							}

							break;
					}

					break;
				}
			}
			
			// �����ɊY������󒍃f�[�^������������
			// ���ŏ��̃����[�g�łЂ��ςĂ��ĂȂ��� (���������O�̎󒍂Ƃ�����)
			if (hitFlg == false)
			{
                // �Q���Ǎ��o�b�t�@�ɓ����Ă���΂�������擾
				SearchClaimSales searchClaimSales = null;
				for (int ix = 0; ix < this._dmdSalesSecond.Count; ix++)
				{
					// ����󒍔ԍ��̎�
					//if (acceptAnOrderNo == ((SearchClaimSales)this._dmdSalesSecond[ix]).AcceptAnOrderNo)  // 2007.10.05 hikita del
                    // ���ꔄ��ԍ��̎�
                    if (salesSlipNum == ((SearchClaimSales)this._dmdSalesSecond[ix]).SalesSlipNum)          // 2007.10.05 hikita add
					{
						searchClaimSales = (SearchClaimSales)this._dmdSalesSecond[ix];
						break;
					}
                }

				// �Q���Ǎ��o�b�t�@�ɂ��������́A�ēx�Ǎ��擾���� ���Q���Ǎ��o�b�t�@�ɂ��ێ�����
				if (searchClaimSales == null)
				{
					try
					{
						SearchSalesParameter parameter = new SearchSalesParameter();
						SearchClaimSales[] searchClaimSalesList;

						// ��ƃR�[�h
						parameter.EnterpriseCode   = enterpriseCode;
						// �����v�㋒�_
						parameter.DemandAddUpSecCd = addUpSecCod;
                        // ������R�[�h
                        parameter.ClaimCode = claimCode;
                        // ���Ӑ�R�[�h
						parameter.CustomerCode     = customerCode;
						// �󒍔ԍ�
						//parameter.AcceptAnOrderNo  = acceptAnOrderNo;   // 2007.10.05 del
                        // �󒍃X�e�[�^�X
                        parameter.AcptAnOdrStatus = acptAnOdrStatus;      // 2007.10.05 add
                        // ����ԍ�
                        parameter.SalesSlipNum = salesSlipNum;            // 2007.10.05 add

						// ����������擾����
						if (this.GetClaimSalesInfo(parameter, out searchClaimSalesList) == 0)
						{
							// �擾�������������� �߂�͂P�������Ȃ��͂�
							searchClaimSales = searchClaimSalesList[0];
						}
					}
					catch ( DepositException ex )
					{
						message = ex.Message;
						return ex.Status;
					}
					catch ( Exception ex )
					{
						message = ex.Message;
						return -999;
					}
				}

				if (searchClaimSales != null)
				{
					switch (kbn)
					{
						case 0:		// --- ���`�[�`�F�b�N --- //

							if (searchClaimSales.DebitNoteDiv == 0)
							{
								return 2;
							}
									
							break;

						case 1:		// --- �ԓ`�[�`�F�b�N --- //

							if (searchClaimSales.DebitNoteDiv == 1)
							{
								return 2;
							}
									
							break;
								
						case 2:		// --- ���E�ςݍ��`�[�`�F�b�N --- //

							if (searchClaimSales.DebitNoteDiv == 2)
							{
								return 2;
							}
									
							break;
						
						case 3:		// --- ���ςݓ`�[�`�F�b�N --- //
							
							if (TDateTime.DateTimeToLongDate(searchClaimSales.AddUpADate) <=
							    this._depositCustomer.CAddUpUpdDate)
							{
								return 2;
							}

							break;
					}
				}
			}

			return 0;
		}
        // �� 20070122 18322 c
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        /// <summary>
        /// ������󒍓`�[�̃`�F�b�N����
        /// </summary>
        /// <param name="kbn">�`�F�b�N�敪 0:��,1:��,2:���E�ςݍ�,3:���ς�</param>
        /// <param name="salesSlipNum">�`�F�b�N�Ώ� ����ԍ�</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCod">�����v�㋒�_</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="message">�G���[�����b�Z�[�W</param>
        /// <returns>�X�e�[�^�X 0:�`�F�b�N�敪�̎󒍖���. 2:�`�F�b�N�敪�̎󒍗L��, �ȊO:���̑��G���[ </returns>
        /// <remarks>
        /// <br>Note       : ������̎󒍓`�[�̏�Ԃ��`�F�b�N���A�`�F�b�N��ނɂ��킹���X�e�[�^�X��Ԃ��܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private int CheackAllowanceSalese(int kbn, 
                                          string salesSlipNum, 
                                          string enterpriseCode, 
                                          string addUpSecCod, 
                                          int customerCode, 
                                          int claimCode, 
                                          int[] acptAnOdrStatus, 
                                          out string message)
        {
            message = "";
            int status;
            bool hitFlg = false;

            // ����������DataRow�̎擾
            foreach (DataRow drSales in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
            {
                // ���ꔄ��ԍ��̎�
                if (salesSlipNum == (String)drSales[ctSalesSlipNum])
                {
                    hitFlg = true;

                    switch (kbn)
                    {
                        // --- ���`�[�`�F�b�N --- //
                        case 0: if ((Int32)drSales[ctDmdSalesDebitNoteCd] == 0)
                            if ((Int32)drSales[ctDmdSalesDebitNoteCd] == 0)
                            {
                                return 2;
                            }
                            break;
                        // --- �ԓ`�[�`�F�b�N --- //
                        case 1:		
                            if ((Int32)drSales[ctDmdSalesDebitNoteCd] == 1)
                            {
                                return 2;
                            }
                            break;
                        // --- ���E�ςݍ��`�[�`�F�b�N --- //
                        case 2:		
                            if ((Int32)drSales[ctDmdSalesDebitNoteCd] == 2)
                            {
                                return 2;
                            }
                            break;
                        // --- ���ςݓ`�[�`�F�b�N --- //
                        case 3:		
                            if ((String)drSales[ctSalesClosedFlg] != "")
                            {
                                return 2;
                            }
                            break;
                    }
                    break;
                }
            }

            // �����ɊY������󒍃f�[�^������������
            // ���ŏ��̃����[�g�łЂ��ςĂ��ĂȂ��� (���������O�̎󒍂Ƃ�����)
            if (hitFlg == false)
            {
                // �Q���Ǎ��o�b�t�@�ɓ����Ă���΂�������擾
                SearchClaimSales searchClaimSales = null;
                for (int ix = 0; ix < this._dmdSalesSecond.Count; ix++)
                {
                    // ���ꔄ��ԍ��̎�
                    if (salesSlipNum == ((SearchClaimSales)this._dmdSalesSecond[ix]).SalesSlipNum)
                    {
                        searchClaimSales = (SearchClaimSales)this._dmdSalesSecond[ix];
                        break;
                    }
                }

                // �Q���Ǎ��o�b�t�@�ɂ��������́A�ēx�Ǎ��擾���� ���Q���Ǎ��o�b�t�@�ɂ��ێ�����
                if (searchClaimSales == null)
                {
                    try
                    {
                        SearchSalesParameter parameter = new SearchSalesParameter();
                        SearchClaimSales[] searchClaimSalesList;

                        parameter.EnterpriseCode = enterpriseCode;      // ��ƃR�[�h
                        parameter.DemandAddUpSecCd = addUpSecCod;       // �����v�㋒�_
                        parameter.ClaimCode = claimCode;                // ������R�[�h
                        parameter.CustomerCode = customerCode;          // ���Ӑ�R�[�h
                        parameter.AcptAnOdrStatus = acptAnOdrStatus;    // �󒍃X�e�[�^�X
                        parameter.SalesSlipNum = salesSlipNum;          // ����ԍ�

                        // ����������擾����
                        status = GetClaimSalesInfo(parameter, out searchClaimSalesList, out message);
                        switch (status)
                        {
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                // �擾�������������� �߂�͂P�������Ȃ��͂�
                                searchClaimSales = searchClaimSalesList[0];
                                break;
                            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                break;
                            default:
                                return (status);
                        }
                    }
                    catch (DepositException ex)
                    {
                        message = ex.Message;
                        return ex.Status;
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                        return -999;
                    }
                }

                if (searchClaimSales != null)
                {
                    switch (kbn)
                    {
                        // --- ���`�[�`�F�b�N --- //
                        case 0:		
                            if (searchClaimSales.DebitNoteDiv == 0)
                            {
                                return 2;
                            }
                            break;
                        // --- �ԓ`�[�`�F�b�N --- //
                        case 1:		
                            if (searchClaimSales.DebitNoteDiv == 1)
                            {
                                return 2;
                            }
                            break;
                        // --- ���E�ςݍ��`�[�`�F�b�N --- //
                        case 2:		
                            if (searchClaimSales.DebitNoteDiv == 2)
                            {
                                return 2;
                            }
                            break;
                        // --- ���ςݓ`�[�`�F�b�N --- //
                        case 3:		
                            if (TDateTime.DateTimeToLongDate(searchClaimSales.AddUpADate) <=
                                TDateTime.DateTimeToLongDate(this._lastAddUpDay))
                            {
                                return 2;
                            }
                            break;
                    }
                }
            }

            return 0;
        }

        // �� 20070122 18322 c MA.NS�p�ɕύX
        #region SF ����������f�[�^�Z�b�g�o�^�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// ����������f�[�^�Z�b�g�o�^����
		///// </summary>
		///// <param name="arrDmdSales">��������N���X</param>
		///// <remarks>
		///// <br>Note�@�@�@  : ������������f�[�^�Z�b�g�֓W�J���܂��B</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private void SetDsDmdSalesInfo(ArrayList arrDmdSales)
		//{
		//	// ����������f�[�^�e�[�u�� �f�[�^�Z�b�g����
		//	foreach(SearchDmdSales dmdSales in arrDmdSales)
		//	{
		//		// ����������DataSet�̍s��V�K�ǉ�����
		//		DataRow drNew = this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].NewRow();
        //
		//		// ����������DataRow�Z�b�g����
		//		SetDmdSales(drNew, dmdSales);
        //
		//		// ����������DataSet�̍s��ǉ�����
		//		this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Add(drNew);
		//	}
        //}
        #endregion

        /// <summary>
        /// ����������f�[�^�Z�b�g�o�^����
        /// </summary>
        /// <param name="arrDmdSales">��������N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ������������f�[�^�Z�b�g�֓W�J���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        private void SetDsDmdSalesInfo(ArrayList arrDmdSales)
        {
            // ����������f�[�^�e�[�u�� �f�[�^�Z�b�g����
            foreach (SearchClaimSales dmdSales in arrDmdSales)
            {
                // ����������DataSet�̍s��V�K�ǉ�����
                DataRow drNew = this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].NewRow();

                // ����������DataRow�Z�b�g����
                SetClaimSales(drNew, dmdSales);

                // ���������f�[�^����
                int maxRows = this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows.Count;
                for (int i = 0; i < maxRows; i++)
                {
                    ////���������O���b�h�̔���`�[�ԍ��̐�������̔���`�[�ԍ��Ǝ󒍃X�e�[�^�X���Z�b�g
                    //this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctSalesSlipNum] = dmdSales.SalesSlipNum;
                    this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctAcptAnOdrStatus] = dmdSales.AcptAnOdrStatus;
                }

                // ����������DataSet�̍s��ǉ�����
                this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Add(drNew);
            }
        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// ����������f�[�^�Z�b�g�o�^����
		/// </summary>
		/// <param name="arrDmdSales">��������N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ������������f�[�^�Z�b�g�֓W�J���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SetDsDmdSalesInfo(ArrayList arrDmdSales)
		{
			// ����������f�[�^�e�[�u�� �f�[�^�Z�b�g����
			foreach(SearchClaimSales dmdSales in arrDmdSales)
			{
				// ����������DataSet�̍s��V�K�ǉ�����
				DataRow drNew = this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].NewRow();

				// ����������DataRow�Z�b�g����
				SetClaimSales(drNew, dmdSales);

                // �� 20070202 18322 a
                // ���������ɔ���ԍ��Ǝ󒍃X�e�[�^�X���Z�b�g
                // 2007.10.05 hikita upd start -------------------------------->>
                //SetSalesSlipNumInAllowanceData( dmdSales.AcceptAnOrderNo
                //                              , dmdSales.SalesSlipNum);
                SetSalesSlipNumInAllowanceData(dmdSales.SalesSlipNum, dmdSales.AcptAnOdrStatus);
                // 2007.10.05 hikita upd end ----------------------------------<<
                // �� 20070202 18322 a

                // ���������f�[�^����
                int maxRows = this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows.Count;
                for (int i = 0; i < maxRows; i++)
                {
                    //���������O���b�h�̔���`�[�ԍ��̐�������̔���`�[�ԍ��Ǝ󒍃X�e�[�^�X���Z�b�g
                    this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctSalesSlipNum] = dmdSales.SalesSlipNum;
                    this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctAcptAnOdrStatus] = dmdSales.AcptAnOdrStatus;
                }

				// ����������DataSet�̍s��ǉ�����
				this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Add(drNew);
			}
        }

        /// <summary>
		/// ���������f�[�^�ɔ���`�[�ԍ��Ǝ󒍃X�e�[�^�X���Z�b�g���܂��B
		/// </summary>
		/// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <remarks>
		/// <br>Note�@�@�@  : ���������f�[�^�ɔ���`�[�ԍ����Z�b�g���܂��B�B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
        // 2007.10.05 hikita upd start ----------------------------------------------->>
		// private void SetSalesSlipNumInAllowanceData( int    acceptAnOrderNo    
		//                                           , string salesSlipNum)
        private void SetSalesSlipNumInAllowanceData(string salesSlipNum, int acptAnOdrStatus)    
        // 2007.10.05 hikita upd end -------------------------------------------------<<
		{
			// ���������f�[�^����
            int maxRows = this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows.Count;
            for (int i = 0; i < maxRows; i++)
            {
                // 2007.10.05 hikita upd start --------------------------------------->>
                // int no = Convert.ToInt32(this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctAcceptAnOrderNo]);
                // if (no == acceptAnOrderNo)
                //{
                    // ���������O���b�h�̔���`�[�ԍ��ɁA����󒍔ԍ�������������̔���`�[�ԍ����Z�b�g
				//	this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctSalesSlipNum] = salesSlipNum;
                //}
                //���������O���b�h�̔���`�[�ԍ��̐�������̔���`�[�ԍ��Ǝ󒍃X�e�[�^�X���Z�b�g
                this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctSalesSlipNum] = salesSlipNum;
                this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[i][ctAcptAnOdrStatus] = acptAnOdrStatus;
                // 2007.10.05 hikita upd end -----------------------------------------<<
            }
        }
        // �� 20070122 18322 c
		   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        /// <summary>
		/// �������/�������f�[�^�Z�b�g�o�^����
		/// </summary>
		/// <param name="arrDepsitMain">�����N���X</param>
		/// <param name="arrDepositAlw">���������N���X</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �������/���������f�[�^�Z�b�g�֓W�J���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
        private void SetDsDepositInfo(ArrayList arrDepsitMain, ArrayList arrDepositAlw, out int customerCode, out int claimCode)
		{
            int claimCode1 = 0;

			int customerCode1 = 0;
			
			// �������f�[�^�e�[�u�� �f�[�^�Z�b�g����
			if (arrDepsitMain != null)
			{
				foreach(SearchDepsitMain depsitMain in arrDepsitMain)
				{
					// ���Ӑ�R�[�h�擾
					customerCode1 = depsitMain.CustomerCode;
                    // ������R�[�h�擾
                    claimCode1 = depsitMain.ClaimCode;

					// �������DataSet�̍s��V�K�쐬����
					DataRow drNewDep = this._dsDepositInfo.Tables[ctDepositDataTable].NewRow();

					// �������DataRow�Z�b�g����
					SetDeposit(drNewDep, depsitMain);

					// �������DataSet�̍s��ǉ�����
                    this._dsDepositInfo.Tables[ctDepositDataTable].Rows.Add(drNewDep);
				}
			}

			// �������f�[�^�e�[�u�� �f�[�^�Z�b�g����
			if (arrDepositAlw != null)
			{
				foreach(SearchDepositAlw depositAlw in arrDepositAlw)
				{
					// ���Ӑ�R�[�h�擾
					customerCode1 = depositAlw.CustomerCode;

                    // ������R�[�h�擾
                    claimCode1 = depositAlw.ClaimCode;

					// �������̍s��V�K�쐬����
					DataRow drNewAlw = this._dsDepositInfo.Tables[ctAllowanceDataTable].NewRow();

					// �������DataRow�Z�b�g����
					SetAllowance(drNewAlw, depositAlw);

					// �������̍s��ǉ�����
					this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows.Add(drNewAlw);
				}
			}

            customerCode = customerCode1;
            claimCode = claimCode1;
		}

        // ----- ADD ���N 2012/12/24 Redmine#33741 ----->>>>>
        /// <summary>
        /// �������f�[�^�Z�b�g�o�^����
        /// </summary>
        /// <param name="arrDepsitMain">�����N���X</param>
        /// <param name="arrDepositAlw">���������N���X</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �������/���������f�[�^�Z�b�g�֓W�J���܂��B</br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private void SetDsDepositGuidInfo(ArrayList arrDepsitMain, ArrayList arrDepositAlw, out int customerCode, out int claimCode)
        {
            int claimCode1 = 0;

            int customerCode1 = 0;

            // �������f�[�^�e�[�u�� �f�[�^�Z�b�g����
            if (arrDepsitMain != null)
            {
                foreach (SearchDepsitMain depsitMain in arrDepsitMain)
                {
                    // ���Ӑ�R�[�h�擾
                    customerCode1 = depsitMain.CustomerCode;
                    // ������R�[�h�擾
                    claimCode1 = depsitMain.ClaimCode;

                    // �������DataSet�̍s��V�K�쐬����
                    DataRow drNewDep = this._dsDepositInfo.Tables[ctDepositGuidDataTable].NewRow();

                    // �������DataRow�Z�b�g����
                    SetDeposit(drNewDep, depsitMain);

                    // �������DataSet�̍s��ǉ�����
                    this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows.Add(drNewDep);
                }
            }
            customerCode = customerCode1;
            claimCode = claimCode1;
        }
        // ----- ADD ���N 2012/12/24 Redmine#33741 -----<<<<<
			
		/// <summary>
		/// �������/�������f�[�^�Z�b�g�X�V����
		/// </summary>
		/// <param name="arrDepsitMain">�����N���X</param>
		/// <param name="arrDepositAlw">���������N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �������/���������f�[�^�Z�b�g�֍X�V���܂��B
		///                   �f�[�^�Z�b�g�ɑ��݂��Ȃ������͐V�K�ǉ����܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void UpdateDepositDataSet(ArrayList arrDepsitMain, ArrayList arrDepositAlw)
		{
			bool updateFlag;

			// �������f�[�^�e�[�u�� �f�[�^�Z�b�g����
			foreach(SearchDepsitMain depsitMain in arrDepsitMain)
			{
				updateFlag = false;
				foreach(DataRow dr in this._dsDepositInfo.Tables[ctDepositDataTable].Rows)
				{
					if (Convert.ToInt32(dr[ctDepositSlipNo]) == depsitMain.DepositSlipNo)
					{
						// �������DataRow�Z�b�g����
						SetDeposit(dr, depsitMain);
						updateFlag = true;
						break;
					}
				}

				// �X�V����Ȃ��������͐V�K
				if (updateFlag == false)
				{
					// �������DataSet�̍s��V�K�쐬����
					DataRow drNewDep = this._dsDepositInfo.Tables[ctDepositDataTable].NewRow();

					// �������DataRow�Z�b�g����
					SetDeposit(drNewDep, depsitMain);

					// �������DataSet�̍s��ǉ�����
					this._dsDepositInfo.Tables[ctDepositDataTable].Rows.Add(drNewDep);
				}
			}

			// �������f�[�^�e�[�u�� �f�[�^�Z�b�g����
			foreach(SearchDepositAlw depositAlw in arrDepositAlw)
			{
				updateFlag = false;
				foreach(DataRow dr in this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows)
				{
					// ������������݂���΍X�V
					// 2007.10.05 hikita upd start ---------------------------------------------->>
                    //if ((Convert.ToInt32(dr[ctDepositSlipNo_Alw]) == depositAlw.DepositSlipNo) &&
					//	(Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]) == depositAlw.AcceptAnOrderNo))
                    if (Convert.ToInt32(dr[ctDepositSlipNo_Alw]) == depositAlw.DepositSlipNo)
                    // 2007.10.05 hikita upd end ------------------------------------------------<<
					{
						if (depositAlw.LogicalDeleteCode == 0)
						{
							// �������DataRow�Z�b�g����
							SetAllowance(dr, depositAlw);
							updateFlag = true;
							break;
						}
						else
						{
							// �_���폜�̎��͍폜
							dr.Delete();
							updateFlag = true;
							break;
						}
					}
				}

				// �X�V����Ȃ��������͐V�K
				if (updateFlag == false)
				{
					// �������̍s��V�K�쐬����
					DataRow drNewAlw = this._dsDepositInfo.Tables[ctAllowanceDataTable].NewRow();

					// �������DataRow�Z�b�g����
					SetAllowance(drNewAlw, depositAlw);

					// �������̍s��ǉ�����
					this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows.Add(drNewAlw);
				}
			}
		}

        // �� 20070122 18322 c MA.NS�p�ɕύX
        #region SF ��������}�X�^�N���X�������N���A�����i�R�����g�A�E�g�j
        ///// <summary>
		///// ��������}�X�^�N���X�������N���A����
		///// </summary>
		///// <remarks>
		///// <br>Note�@�@�@  : ��������}�X�^�N���X�̈������z���N���A���܂��B</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private void ClearDmdSalesAllowance(Hashtable htDepositAlw)
		//{
		//	// �Ώۈ����f�[�^
		//	foreach (DictionaryEntry de in htDepositAlw)
		//	{
		//		SearchDepositAlw depositAlw = (SearchDepositAlw)de.Value;
        //
		//		// �f�[�^�ێ��p�̈������z�ɍ폜�������z�����Z����
		//		foreach (SearchDmdSales dmdSales in this._dmdSales)
		//		{
		//			if (depositAlw.AcceptAnOrderNo == dmdSales.AcceptAnOrderNo)
		//			{
		//				// �����z �� (��������}�X�^)
		//				dmdSales.AcpOdrDepositAlwc = dmdSales.AcpOdrDepositAlwc - depositAlw.AcpOdrDepositAlwc;
        //
		//				// �����c �� (��������}�X�^)
		//				dmdSales.AcpOdrDepoAlwcBlnce = dmdSales.AcpOdrDepoAlwcBlnce + depositAlw.AcpOdrDepositAlwc;
        //
		//				// �����z ����p (��������}�X�^)
		//				dmdSales.VarCostDepoAlwc = dmdSales.VarCostDepoAlwc - depositAlw.VarCostDepoAlwc;
        //
		//				// �����c ����p (��������}�X�^)
		//				dmdSales.VarCostDepoAlwcBlnce = dmdSales.VarCostDepoAlwcBlnce + depositAlw.VarCostDepoAlwc;
        //
		//				// �����z ���� (��������}�X�^)
		//				dmdSales.DepositAllowance = dmdSales.DepositAllowance - depositAlw.DepositAllowance;
        //
		//				// �����c ���� (��������}�X�^)
		//				dmdSales.DepositAlwcBlnce = dmdSales.DepositAlwcBlnce + depositAlw.DepositAllowance;
		//			}
		//		}
		//	}
        //}
        #endregion

        /// <summary>
		/// ��������}�X�^�N���X�������N���A����
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : ��������}�X�^�N���X�̈������z���N���A���܂��B</br>
		/// <br>Programmer  : 18322 T.Kimura</br>
		/// <br>Date        : 2007.01.22</br>
		/// </remarks>
		private void ClearDmdSalesAllowance(Hashtable htDepositAlw)
		{
			// �Ώۈ����f�[�^
			foreach (DictionaryEntry de in htDepositAlw)
			{
				SearchDepositAlw depositAlw = (SearchDepositAlw)de.Value;

				// �f�[�^�ێ��p�̈������z�ɍ폜�������z�����Z����
				foreach (SearchClaimSales claimSales in this._dmdSales)
				{
                    //if (depositAlw.AcceptAnOrderNo == claimSales.AcceptAnOrderNo)  // 2007.10.05 del
                    if (depositAlw.SalesSlipNum == claimSales.SalesSlipNum)          // 2007.10.05 add
					{
						// �����z ���� (��������}�X�^)
						claimSales.DepositAllowanceTtl = claimSales.DepositAllowanceTtl - depositAlw.DepositAllowance;

						// �����c ���� (��������}�X�^)
						claimSales.DepositAlwcBlnce = claimSales.DepositAlwcBlnce + depositAlw.DepositAllowance;
					}
				}
			}
        }
        // �� 20070122 18322 c

        // �� 20070122 18322 c MA.NS�p�ɕύX
        #region SF ��������}�X�^�N���X�X�V�����i�S�ăR�����g�A�E�g�j
        ///// <summary>
		///// ��������}�X�^�N���X�X�V����
		///// </summary>
		///// <remarks>
		///// <br>Note�@�@�@  : ��������}�X�^�N���X(�f�[�^�ێ��p)�̓��e���f�[�^�Z�b�g����X�V���܂��B</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private void UpdateDmdSales()
		//{
		//	// �f�[�^�Z�b�g�̓��e���擾
		//	foreach (System.Data.DataRow dr in _dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
		//	{
		//		// �f�[�^�ێ��p����擾
		//		foreach (SearchDmdSales dmdSales in this._dmdSales)
		//		{
		//		
		//			if (Convert.ToInt32(dr[ctAcceptAnOrderNo]) == dmdSales.AcceptAnOrderNo)
		//			{
        //                // �����c �� (��������}�X�^)
		//				dmdSales.AcpOdrDepoAlwcBlnce = Convert.ToInt64(dr[ctAcpOdrDepoAlwcBlnce_Sales]);
        //                
		//				// ������ �� (��������}�X�^)
		//				dmdSales.AcpOdrDepositAlwc = Convert.ToInt64(dr[ctAcpOdrDepositAlwc_Sales]);
        //                
		//				// �����c ����p (��������}�X�^)
		//				dmdSales.VarCostDepoAlwcBlnce = Convert.ToInt64(dr[ctVarCostDepoAlwcBlnce_Sales]);
        //                
		//    			// ������ ����p (��������}�X�^)
        //                dmdSales.VarCostDepoAlwc = Convert.ToInt64(dr[ctVarCostDepoAlwc_Sales]);
        //
		//				// �����c ���� (��������}�X�^)
		//				dmdSales.DepositAlwcBlnce = Convert.ToInt64(dr[ctDepositAlwcBlnce_Sales]);
        //
		//				// ������ ���� (��������}�X�^)
		//				dmdSales.DepositAllowance = Convert.ToInt64(dr[ctDepositAllowance_Sales]);
		//			}
		//		}
		//	}
        //}
        #endregion

        /// <summary>
		/// ��������}�X�^�N���X�X�V����
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : ��������}�X�^�N���X(�f�[�^�ێ��p)�̓��e���f�[�^�Z�b�g����X�V���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void UpdateDmdSales()
		{
			// �f�[�^�Z�b�g�̓��e���擾
			foreach (DataRow dr in _dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
			{
				// �f�[�^�ێ��p����擾
				foreach (SearchClaimSales claimSales in this._dmdSales)
				{
				
					// if (Convert.ToInt32(dr[ctAcceptAnOrderNo]) == claimSales.AcceptAnOrderNo)    // 2007.10.05 del
                    if (Convert.ToString(dr[ctSalesSlipNum]) == claimSales.SalesSlipNum)            // 2007.10.05 add
                    {
						// �����c ���� (��������}�X�^)
						claimSales.DepositAlwcBlnce = Convert.ToInt64(dr[ctDepositAlwcBlnce_Sales]);
                        
						// ������ ���� (��������}�X�^)
						claimSales.DepositAllowanceTtl = Convert.ToInt64(dr[ctDepositAllowance_Sales]);
					}
				}
			}
		}
        // �� 20070122 18322 c
		
		/// <summary>
		/// �������/�������f�[�^�Z�b�g�폜����
		/// </summary>
		/// <param name="depositSlipNo">�����ԍ�</param>
		/// <returns>���Ӑ�R�[�h</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �������/���������f�[�^�Z�b�g����폜���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void DeleteDepositDataSet(int depositSlipNo)
		{
			int ix;

			// �������f�[�^�e�[�u�� �f�[�^�폜����
			for (ix = 0; ix < this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows.Count; ix++)
			{
				if (Convert.ToInt32(this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[ix][ctDepositSlipNo_Alw]) == depositSlipNo)
				{
					this._dsDepositInfo.Tables[ctAllowanceDataTable].Rows[ix].Delete();
					ix--;
				}
			}

			// �������f�[�^�e�[�u�� �f�[�^�폜����
			for (ix = 0; ix < this._dsDepositInfo.Tables[ctDepositDataTable].Rows.Count; ix++)
			{
				if (Convert.ToInt32(this._dsDepositInfo.Tables[ctDepositDataTable].Rows[ix][ctDepositSlipNo]) == depositSlipNo)
				{
					this._dsDepositInfo.Tables[ctDepositDataTable].Rows[ix].Delete();
					ix--;
				}
			}
        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �������DetaRow�Z�b�g����
        /// </summary>
        /// <param name="drNew">�������DataRow</param>
        /// <param name="depsitMain">�����N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ��������DataRow�ɃZ�b�g���܂��B</br>
        /// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// </remarks>
        private void SetDeposit(DataRow drNew, SearchDepsitMain depsitMain)
        {
            // �����ԍ��敪
            drNew[ctDepositDebitNoteCd] = depsitMain.DepositDebitNoteCd;

            // �����ԍ�����
            switch (depsitMain.DepositDebitNoteCd)
            {
                case 0:
                    drNew[ctDepositDebitNoteNm] = "��";
                    break;
                case 1:
                    drNew[ctDepositDebitNoteNm] = "��";
                    break;
                case 2:
                    drNew[ctDepositDebitNoteNm] = "���E�ςݍ�";
                    break;
            }

            // �����`�[�ԍ�
            drNew[ctDepositSlipNo] = depsitMain.DepositSlipNo;

            // �� 20070525 18322 a
            // �󒍔ԍ�
            //drNew[ctAcceptAnOrderNo] = depsitMain.AcceptAnOrderNo;      // 2007.10.05 del
            // �� 20070525 18322 a
            // �󒍃X�e�[�^�X
            drNew[ctDepositAcptAnOdrStatus] = depsitMain.AcptAnOdrStatus; // 2007.10.05 add
            
            // ����`�[�ԍ�
            drNew[ctSalesSlipNum] = depsitMain.SalesSlipNum;

            // �ԍ������A���ԍ�
            drNew[ctDebitNoteLinkDepoNo] = depsitMain.DebitNoteLinkDepoNo;

            // �� 20070418 18322 c MA.NS�Ή�
            //// �������t(�\���p)
            //drNew[ctDepositDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd", depsitMain.DepositDate);

            // �������t(�\���p)
            drNew[ctDepositDateDisp] = depsitMain.DepositDate.ToString("yyyy/MM/dd");
            // �� 20070418 18322 c

            // �������t
            drNew[ctDepositDate] = TDateTime.DateTimeToLongDate(depsitMain.DepositDate);
				
            // �v����t(�\���p)
            drNew[ctDepositAddUpADateDisp] = depsitMain.AddUpADate.ToString("yyyy/MM/dd");    // 2007.10.05 add
                
            // �v����t
            drNew[ctDepositAddUpADate] = TDateTime.DateTimeToLongDate(depsitMain.AddUpADate); // 2007.10.05 add
				
            // ���������敪
            drNew[ctAutoDepositCd] = depsitMain.AutoDepositCd;

            // �a����敪����
            drNew[ctDepositCd] = depsitMain.DepositCd;
            if (depsitMain.AutoDepositCd == 0)
            {
                drNew[ctDepositNm] = depsitMain.DepositNm;
            }
            else
            {
                drNew[ctDepositNm] = depsitMain.DepositNm + "(����)";
            }
            
            // ��������
            drNew[ctDepositKindDivCd] = depsitMain.DepositKindDivCd;
            drNew[ctDepositKindCode] = depsitMain.DepositKindCode;
            
            drNew[ctDepositKindName] = depsitMain.DepositKindName;

            // �� 20070118 18322 d MA.NS�p�ɕύX
            #region SF �󒍁E����p�i�S�ăR�����g�A�E�g�j
            //// �� �����z
            //drNew[ctAcpOdrDeposit] = depsitMain.AcpOdrDeposit;
            //
            //// �� �萔��
            //drNew[ctAcpOdrChargeDeposit] = depsitMain.AcpOdrChargeDeposit;
            //
            //// �� �l��
            //drNew[ctAcpOdrDisDeposit] = depsitMain.AcpOdrDisDeposit;
            //
            //// �� �����v
            //drNew[ctAcpOdrDepositTotal] = depsitMain.AcpOdrDeposit + depsitMain.AcpOdrChargeDeposit + depsitMain.AcpOdrDisDeposit;
            //
            //// ����p �����z
            //drNew[ctVariousCostDeposit] = depsitMain.VariousCostDeposit;
            //
            //// ����p �萔��
            //drNew[ctVarCostChargeDeposit] = depsitMain.VarCostChargeDeposit;
            //
            //// ����p �l��
            //drNew[ctVarCostDisDeposit] = depsitMain.VarCostDisDeposit;
            //
            //// ����p �����v
            //drNew[ctVariousCostDepositTotal] = depsitMain.VariousCostDeposit + depsitMain.VarCostChargeDeposit + depsitMain.VarCostDisDeposit;
            #endregion
            // �� 20070118 18322 d

            // ���� �����z
            drNew[ctDeposit] = depsitMain.Deposit;

            // ���� �萔��
            drNew[ctFeeDeposit] = depsitMain.FeeDeposit;

            // ���� �l��
            drNew[ctDiscountDeposit] = depsitMain.DiscountDeposit;

            // �� 20070118 18322 a
            // ���� �C���Z���e�B�u
            // drNew[ctRebateDeposit] = depsitMain.RebateDeposit;   // 2007.10.05 del
            // �� 20070118 18322 a

            // ���� �����v
            drNew[ctDepositTotal] = depsitMain.DepositTotal;

            // �� 20070118 18322 d MA.NS�p�ɕύX
            #region SF �󒍁E����p�i�S�ăR�����g�A�E�g�j
            //// ���������z ��
            //drNew[ctAcpOdrDepositAlwc_Deposit] = depsitMain.AcpOdrDepositAlwc;
            //
            //// ���������c ��
            //drNew[ctAcpOdrDepoAlwcBlnce_Deposit] = depsitMain.AcpOdrDepoAlwcBlnce;
            //
            //// ���������z ����p
            //drNew[ctVarCostDepoAlwc_Deposit] = depsitMain.VarCostDepoAlwc;
            //
            //// ���������c ����p
            //drNew[ctVarCostDepoAlwcBlnce_Deposit] = depsitMain.VarCostDepoAlwcBlnce;
            #endregion
            // �� 20070118 18322 d

            // ���������z ����
            drNew[ctDepositAllowance_Deposit] = depsitMain.DepositAllowance;

            // ���������c ����
            drNew[ctDepositAlwcBlnce_Deposit] = depsitMain.DepositAlwcBlnce;
            
            // �N���W�b�g/���[���敪
            // drNew[ctCreditOrLoanCd] = depsitMain.CreditOrLoanCd;        // 2007.10.05 del

            // �N���W�b�g��ЃR�[�h
            // drNew[ctCreditCompanyCode] = depsitMain.CreditCompanyCode;  // 2007.10.05 del

            // ��`�U�o��
            drNew[ctDraftDrawingDate] = TDateTime.DateTimeToLongDate(depsitMain.DraftDrawingDate);

            // ��`�x������
            drNew[ctDraftPayTimeLimit] = TDateTime.DateTimeToLongDate(depsitMain.DraftPayTimeLimit);

            // 2007.10.05 add start -------------------------------------------------------->>
            // ��s�R�[�h
            drNew[ctBankCode] = depsitMain.BankCode;
 
            // ��s����
            drNew[ctBankName] = depsitMain.BankName;

            // ��`�ԍ�
            drNew[ctDraftNo] = depsitMain.DraftNo;

            // ��`���
            drNew[ctDraftKind] = depsitMain.DraftKind;

            // ��`��ޖ���
            drNew[ctDraftKindName] = depsitMain.DraftKindName;

            // ��`�敪
            drNew[ctDraftDivide] = depsitMain.DraftDivide;

            // ��`�敪����
            drNew[ctDraftDivideName] = depsitMain.DraftDivideName;
            // 2007.10.05 add end ----------------------------------------------------------<<
            // �E�v
            drNew[ctOutline] = depsitMain.Outline;

            // ���g��DataRow
            drNew[ctDepositDataRow] = drNew;
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        /// <summary>
        /// �������DetaRow�Z�b�g����
        /// </summary>
        /// <param name="drNew">�������DataRow</param>
        /// <param name="depsitMain">�����N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ��������DataRow�ɃZ�b�g���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2010/12/20 ����� PM.NS��Q���ǑΉ�(12����)
        /// <br>              ���ځu�����v��ǉ�����B</br>
        /// <br>Update Note : 2012/09/21 �c����</br>
        /// <br>�Ǘ��ԍ�    : 2012/10/17�z�M��</br>
        /// <br>              Redmine#32415 ���s�҂̒ǉ��Ή�</br>
        /// <br>Update Note : 2012/12/24 ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void SetDeposit(DataRow drNew, SearchDepsitMain depsitMain)
        {
            drNew[ctDepositDebitNoteCd] = depsitMain.DepositDebitNoteCd;                            // �����ԍ��敪
            // �����ԍ�����
            switch (depsitMain.DepositDebitNoteCd)
            {
                case 0:
                    drNew[ctDepositDebitNoteNm] = "��";
                    break;
                case 1:
                    drNew[ctDepositDebitNoteNm] = "��";
                    break;
                case 2:
                    drNew[ctDepositDebitNoteNm] = "���E�ςݍ�";
                    break;
            }
            drNew[ctDepositSlipNo] = depsitMain.DepositSlipNo;                                      // �����`�[�ԍ�
            drNew[ctDepositAcptAnOdrStatus] = depsitMain.AcptAnOdrStatus;                           // �󒍃X�e�[�^�X
            drNew[ctSalesSlipNum] = depsitMain.SalesSlipNum;                                        // ����`�[�ԍ�
            drNew[ctDebitNoteLinkDepoNo] = depsitMain.DebitNoteLinkDepoNo;                          // �ԍ������A���ԍ�
            drNew[ctDepositDateDisp] = depsitMain.DepositDate.ToString("yyyy/MM/dd");               // �������t(�\���p)
            drNew[ctDepositDate] = TDateTime.DateTimeToLongDate(depsitMain.DepositDate);            // �������t
            drNew[ctDepositAddUpADateDisp] = depsitMain.AddUpADate.ToString("yyyy/MM/dd");          // �v����t(�\���p)
            drNew[ctDepositAddUpADate] = TDateTime.DateTimeToLongDate(depsitMain.AddUpADate);       // �v����t
            drNew[ctAutoDepositCd] = depsitMain.AutoDepositCd;                                      // ���������敪
            // �a����敪����
            if (depsitMain.AutoDepositCd == 0)
            {
                drNew[ctDepositNm] = depsitMain.DepositNm;
            }
            else
            {
                drNew[ctDepositNm] = "��������";
            }
            // TODO:��������(�\���p)
            List<string> moneyKindNameList = new List<string>();
            for (int index = 0; index < depsitMain.DepositDtl.Length; index++)
            {
                // DEL 2010/03/25 MANTIS�Ή�[15195]�F0�~�����ۑ����ɢ�����ʣ��\�����A�I����ɓo�^�֕ύX ---------->>>>>
                // if (depsitMain.DepositDtl[index] != 0)
                // DEL 2010/03/25 MANTIS�Ή�[15195]�F0�~�����ۑ����ɢ�����ʣ��\�����A�I����ɓo�^�֕ύX ----------<<<<<
                // ADD 2010/03/25 MANTIS�Ή�[15195]�F0�~�����ۑ����ɢ�����ʣ��\�����A�I����ɓo�^�֕ύX ---------->>>>>
                if (!string.IsNullOrEmpty(depsitMain.MoneyKindName[index]))
                // ADD 2010/03/25 MANTIS�Ή�[15195]�F0�~�����ۑ����ɢ�����ʣ��\�����A�I����ɓo�^�֕ύX ----------<<<<<
                {
                    moneyKindNameList.Add(depsitMain.MoneyKindName[index]);
                }
            }
            switch (moneyKindNameList.Count)
            {
                case 0:
                    drNew[ctDepositKindName] = "";
                    break;
                case 1:
                    drNew[ctDepositKindName] = moneyKindNameList[0];
                    break;
                case 2:
                    drNew[ctDepositKindName] = moneyKindNameList[0] + "�E" + moneyKindNameList[1];
                    break;
                default:
                    drNew[ctDepositKindName] = moneyKindNameList[0] + "�E" + moneyKindNameList[1] + "�ق�";
                    break;
            }
            drNew[ctDeposit] = depsitMain.Deposit;                                                  // ���� �����z
            drNew[ctFeeDeposit] = depsitMain.FeeDeposit;                                            // ���� �萔��
            drNew[ctDiscountDeposit] = depsitMain.DiscountDeposit;                                  // ���� �l��
            // ���� �����v(�����z�{�萔�������z�{�l�������z)
            drNew[ctDepositTotal] = depsitMain.Deposit + depsitMain.FeeDeposit + depsitMain.DiscountDeposit;
            drNew[ctDepositAllowance_Deposit] = depsitMain.DepositAllowance;                        // ���������z ����
            //drNew[ctDepositAlwcBlnce_Deposit] = depsitMain.DepositAlwcBlnce;                        // ���������c ����
            drNew[ctDepositAlwcBlnce_Deposit] = depsitMain.Deposit + depsitMain.FeeDeposit + depsitMain.DiscountDeposit - depsitMain.DepositAllowance;                        // ���������c ����

            // --- ADD 2010/12/20 ---------->>>>>
            // ����
            if ((long)drNew[ctDepositAlwcBlnce_Deposit] == 0)
            {
                // ��1:���������c��(DepositAlwcBlnce)��0�ꍇ
                drNew[ctAllowDiv] = "��";
            }
            else if (depsitMain.DepositAllowance != 0)
            {
                // ��2:��1�ȊO�ŁA���������z(DepositAllowance)��0�ꍇ
                drNew[ctAllowDiv] = "�ꕔ";
            }
            else
            {
                // ��1�ȊO����2�ȊO�ꍇ
                drNew[ctAllowDiv] = "";
            }
            // --- ADD 2010/12/20  ----------<<<<<

            if (depsitMain.DraftDrawingDate == DateTime.MinValue)
            {
                drNew[ctDraftDrawingDate] = 0;
            }
            else
            {
                drNew[ctDraftDrawingDate] = TDateTime.DateTimeToLongDate(depsitMain.DraftDrawingDate);  // ��`�U�o��
            }
            drNew[ctBankCode] = depsitMain.BankCode;                                                // ��s�R�[�h
            drNew[ctBankName] = depsitMain.BankName;                                                // ��s����
            drNew[ctDraftNo] = depsitMain.DraftNo;                                                  // ��`�ԍ�
            drNew[ctDraftKind] = depsitMain.DraftKind;                                              // ��`���
            drNew[ctDraftKindName] = depsitMain.DraftKindName;                                      // ��`��ޖ���
            drNew[ctDraftDivide] = depsitMain.DraftDivide;                                          // ��`�敪
            drNew[ctDraftDivideName] = depsitMain.DraftDivideName;                                  // ��`�敪����
            drNew[ctOutline] = depsitMain.Outline;                                                  // �E�v

            drNew[ctDepositRowNo1] = depsitMain.DepositRowNo[0];                                    // �����s�ԍ�1
            drNew[ctMoneyKindCode1] = depsitMain.MoneyKindCode[0];                                  // ����R�[�h1
            drNew[ctMoneyKindName1] = depsitMain.MoneyKindName[0];                                  // ���햼��1
            drNew[ctMoneyKindDiv1] = depsitMain.MoneyKindDiv[0];                                    // ����敪1
            drNew[ctDeposit1] = depsitMain.DepositDtl[0];                                           // �������z1
            drNew[ctValidityTerm1] = depsitMain.ValidityTerm[0];                                    // �L������1
            drNew[ctDepositRowNo2] = depsitMain.DepositRowNo[1];                                    // �����s�ԍ�2
            drNew[ctMoneyKindCode2] = depsitMain.MoneyKindCode[1];                                  // ����R�[�h2
            drNew[ctMoneyKindName2] = depsitMain.MoneyKindName[1];                                  // ���햼��2
            drNew[ctMoneyKindDiv2] = depsitMain.MoneyKindDiv[1];                                    // ����敪2
            drNew[ctDeposit2] = depsitMain.DepositDtl[1];                                           // �������z2
            drNew[ctValidityTerm2] = depsitMain.ValidityTerm[1];                                    // �L������2
            drNew[ctDepositRowNo3] = depsitMain.DepositRowNo[2];                                    // �����s�ԍ�3
            drNew[ctMoneyKindCode3] = depsitMain.MoneyKindCode[2];                                  // ����R�[�h3
            drNew[ctMoneyKindName3] = depsitMain.MoneyKindName[2];                                  // ���햼��3
            drNew[ctMoneyKindDiv3] = depsitMain.MoneyKindDiv[2];                                    // ����敪3
            drNew[ctDeposit3] = depsitMain.DepositDtl[2];                                           // �������z3
            drNew[ctValidityTerm3] = depsitMain.ValidityTerm[2];                                    // �L������3
            drNew[ctDepositRowNo4] = depsitMain.DepositRowNo[3];                                    // �����s�ԍ�4
            drNew[ctMoneyKindCode4] = depsitMain.MoneyKindCode[3];                                  // ����R�[�h4
            drNew[ctMoneyKindName4] = depsitMain.MoneyKindName[3];                                  // ���햼��4
            drNew[ctMoneyKindDiv4] = depsitMain.MoneyKindDiv[3];                                    // ����敪4
            drNew[ctDeposit4] = depsitMain.DepositDtl[3];                                           // �������z4
            drNew[ctValidityTerm4] = depsitMain.ValidityTerm[3];                                    // �L������4
            drNew[ctDepositRowNo5] = depsitMain.DepositRowNo[4];                                    // �����s�ԍ�5
            drNew[ctMoneyKindCode5] = depsitMain.MoneyKindCode[4];                                  // ����R�[�h5
            drNew[ctMoneyKindName5] = depsitMain.MoneyKindName[4];                                  // ���햼��5
            drNew[ctMoneyKindDiv5] = depsitMain.MoneyKindDiv[4];                                    // ����敪5
            drNew[ctDeposit5] = depsitMain.DepositDtl[4];                                           // �������z5
            drNew[ctValidityTerm5] = depsitMain.ValidityTerm[4];                                    // �L������5
            drNew[ctDepositRowNo6] = depsitMain.DepositRowNo[5];                                    // �����s�ԍ�6
            drNew[ctMoneyKindCode6] = depsitMain.MoneyKindCode[5];                                  // ����R�[�h6
            drNew[ctMoneyKindName6] = depsitMain.MoneyKindName[5];                                  // ���햼��6
            drNew[ctMoneyKindDiv6] = depsitMain.MoneyKindDiv[5];                                    // ����敪6
            drNew[ctDeposit6] = depsitMain.DepositDtl[5];                                           // �������z6
            drNew[ctValidityTerm6] = depsitMain.ValidityTerm[5];                                    // �L������6
            drNew[ctDepositRowNo7] = depsitMain.DepositRowNo[6];                                    // �����s�ԍ�7
            drNew[ctMoneyKindCode7] = depsitMain.MoneyKindCode[6];                                  // ����R�[�h7
            drNew[ctMoneyKindName7] = depsitMain.MoneyKindName[6];                                  // ���햼��7
            drNew[ctMoneyKindDiv7] = depsitMain.MoneyKindDiv[6];                                    // ����敪7
            drNew[ctDeposit7] = depsitMain.DepositDtl[6];                                           // �������z7
            drNew[ctValidityTerm7] = depsitMain.ValidityTerm[6];                                    // �L������7
            drNew[ctDepositRowNo8] = depsitMain.DepositRowNo[7];                                    // �����s�ԍ�8
            drNew[ctMoneyKindCode8] = depsitMain.MoneyKindCode[7];                                  // ����R�[�h8
            drNew[ctMoneyKindName8] = depsitMain.MoneyKindName[7];                                  // ���햼��8
            drNew[ctMoneyKindDiv8] = depsitMain.MoneyKindDiv[7];                                    // ����敪8
            drNew[ctDeposit8] = depsitMain.DepositDtl[7];                                           // �������z8
            drNew[ctValidityTerm8] = depsitMain.ValidityTerm[7];                                    // �L������8
            drNew[ctDepositRowNo9] = depsitMain.DepositRowNo[8];                                    // �����s�ԍ�9
            drNew[ctMoneyKindCode9] = depsitMain.MoneyKindCode[8];                                  // ����R�[�h9
            drNew[ctMoneyKindName9] = depsitMain.MoneyKindName[8];                                  // ���햼��9
            drNew[ctMoneyKindDiv9] = depsitMain.MoneyKindDiv[8];                                    // ����敪9
            drNew[ctDeposit9] = depsitMain.DepositDtl[8];                                           // �������z9
            drNew[ctValidityTerm9] = depsitMain.ValidityTerm[8];                                    // �L������9
            drNew[ctDepositRowNo10] = depsitMain.DepositRowNo[9];                                    // �����s�ԍ�10
            drNew[ctMoneyKindCode10] = depsitMain.MoneyKindCode[9];                                  // ����R�[�h10
            drNew[ctMoneyKindName10] = depsitMain.MoneyKindName[9];                                  // ���햼��10
            drNew[ctMoneyKindDiv10] = depsitMain.MoneyKindDiv[9];                                    // ����敪10
            drNew[ctDeposit10] = depsitMain.DepositDtl[9];                                           // �������z10
            drNew[ctValidityTerm10] = depsitMain.ValidityTerm[9];                                    // �L������10

            // ADD 2010/03/25 MANTIS[15196]�F�����ꗗ��ʂɢ���͒S���ң��\���֕ύX ---------->>>>>
            drNew[ctDepositInputAgentNm] = depsitMain.DepositAgentNm;                               // FIXME:���͒S����
            // ADD 2010/03/25 MANTIS[15196]�F�����ꗗ��ʂɢ���͒S���ң��\���֕ύX ----------<<<<<

            //----- ADD 2012/09/21 �c���� redmine#32415 ---------->>>>>
            drNew[ctDepositInputEmpCd] = depsitMain.DepositInputAgentCd.Trim();                     // ���s�҃R�[�h
            drNew[ctDepositInputEmpNm] = depsitMain.DepositInputAgentNm.Trim();                     // ���s�Җ�
            //----- ADD 2012/09/21 �c���� redmine#32415 ----------<<<<<
            // ADD 2012/12/24 ���N  Redmine#33741 ------------------------->>>>>
            drNew[ctCustomerCode] = depsitMain.CustomerCode;  // ���Ӑ�R�[�h
            drNew[ctCustomerName] = depsitMain.CustomerSnm;   // ���Ӑ旪��
            // ADD 2012/12/24 ���N�@Redmine#33741 -------------------------<<<<<

            drNew[ctDepositDataRow] = drNew;                                                        // ���g��DataRow
        }
		
		/// <summary>
		/// �����������DetaRow�Z�b�g����
		/// </summary>
		/// <param name="drNew">�����������DataRow</param>
		/// <param name="depositAlw">���������N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ������������DataRow�ɃZ�b�g���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SetAllowance(DataRow drNew, SearchDepositAlw depositAlw)
		{
			// �����`�[�ԍ�
			drNew[ctDepositSlipNo_Alw] = depositAlw.DepositSlipNo;

            // �󒍃X�e�[�^�X
            drNew[ctAcptAnOdrStatus_Alw] = depositAlw.AcptAnOdrStatus;      // 2007.10.05 add
            
            // ����`�[�ԍ�
            drNew[ctSalesSlipNum] = depositAlw.SalesSlipNum;                // 2007.10.05 add

			// �󒍓`�[�ԍ�
			// drNew[ctAcceptAnOrderNo_Alw] = depositAlw.AcceptAnOrderNo;   // 2007.10.05 del

            // �� 20070118 18322 d MA.NS�p�ɕύX
			//// ���������z ��
			//drNew[ctAcpOdrDepositAlwc] = depositAlw.AcpOdrDepositAlwc;
            //
			//// ���������z ����p
			//drNew[ctVarCostDepoAlwc] = depositAlw.VarCostDepoAlwc;
            // �� 20070118 18322 d

			// ���������z ����
			drNew[ctDepositAllowance] = depositAlw.DepositAllowance;

            // �� 20070418 18322 c MA.NS�Ή�
			//// ������(�\���p)
			//drNew[ctReconcileDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd", depositAlw.ReconcileDate);

			// ������(�\���p)
			drNew[ctReconcileDateDisp] = depositAlw.ReconcileDate.ToString("yyyy/MM/dd");
            // �� 20070418 18322 c

			// ������
			drNew[ctReconcileDate] = TDateTime.DateTimeToLongDate(depositAlw.ReconcileDate);

			// �����v����t
			drNew[ctReconcileAddUpDate] = TDateTime.DateTimeToLongDate(depositAlw.ReconcileAddUpDate);
		}
		
		/// <summary>
		/// �������/������� �ێ��p�f�[�^�N���X�o�^����
		/// </summary>
		/// <param name="arrDepsitMain">�����N���X</param>
		/// <param name="arrDepositAlw">���������N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �������/��������ێ��p�f�[�^�N���X�֓W�J���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SetDepositSaveClass(ArrayList arrDepsitMain, ArrayList arrDepositAlw)
		{
			if (arrDepsitMain != null)
			{
				// �������f�[�^�e�[�u�� �f�[�^�Z�b�g����
				foreach(SearchDepsitMain depsitMain in arrDepsitMain)
				{
					// �����}�X�^�N���X�ɒǉ�
					_depsitMain.Add(depsitMain.DepositSlipNo, depsitMain);
				}
			}

			if (arrDepositAlw != null)
			{
				// �����������f�[�^�e�[�u�� �f�[�^�Z�b�g����
				// �� htOrderNoTani   : ��������ԍ������󒍔ԍ��œ���
				// �� _depositAlw     : �����ԍ��P�ʂ�htOrderNoTani������
				int depositSlipNo = -1;
				Hashtable htOrderNoTani = new Hashtable();
                // ----- ADD ���N 2012/12/24 Redmine#33741----- >>>>>
                IComparer depositSlipNoComparer = new DepositSlipNoComparer();
                arrDepositAlw.Sort(depositSlipNoComparer);
                // ----- ADD ���N 2012/12/24 Redmine#33741----- <<<<<
				foreach(SearchDepositAlw depositAlw in arrDepositAlw)
				{
					// ����ł͂Ȃ��A�����ԍ����ς������
					if ((depositSlipNo != -1) && (depositSlipNo != depositAlw.DepositSlipNo))
					{
						// ���������}�X�^�N���X(�����ԍ����x���ň��k)�ɒǉ�
						_depositAlw.Add(depositSlipNo, htOrderNoTani);

						// �V�K�ɃI�[�_�[NO�P�ʃn�b�V���e�[�u���𐶐�
						htOrderNoTani = new Hashtable();
					}

					// �I�[�_�[NO�P�ʃn�b�V���e�[�u���ɒǉ�
					// htOrderNoTani.Add(depositAlw.AcceptAnOrderNo, depositAlw);   // 2007.10.05 del
                    // ����`�[�ԍ��P�ʃn�b�V���e�[�u���ɒǉ�
                    htOrderNoTani.Add(depositAlw.SalesSlipNum, depositAlw);         // 2007.10.05 add

					depositSlipNo = depositAlw.DepositSlipNo;
				}
				// �Ō�̂P������ǉ�
				if (htOrderNoTani.Count != 0)
				{
					// ���������}�X�^�N���X(�����ԍ����x���ň��k)�ɒǉ�
					_depositAlw.Add(depositSlipNo, htOrderNoTani);
				}
			}
		}
		
		/// <summary>
		/// �������� �ێ��p�f�[�^�N���X�ǉ�����(���񌟍���)
		/// </summary>
		/// <param name="arrDmdSales">��������N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �����������ێ��p�f�[�^�N���X�֓W�J���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void InsertDmdSalesSaveClass(ArrayList arrDmdSales)
		{
			// ��������}�X�^�N���X�ɒǉ�
			this._dmdSales = (ArrayList)arrDmdSales.Clone();
		}
		
		/// <summary>
		/// �������� �ێ��p�f�[�^�N���X�ǉ�����(���񌟍��œǂݍ���łȂ���)
		/// </summary>
		/// <param name="arrDmdSales">��������N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �����������ێ��p�f�[�^�N���X�֓W�J���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void InsertDmdSalesSecondSaveClass(ArrayList arrDmdSales)
		{
            // �� 20070122 18322 c
			//// ��������}�X�^�N���X�ɒǉ�
			//foreach (SearchDmdSales searchDmdSales in arrDmdSales)
			//{
			//	this._dmdSalesSecond.Add(searchDmdSales);
			//}

			// ��������}�X�^�N���X�ɒǉ�
			foreach (SearchClaimSales searchClaimSales in arrDmdSales)
			{
				this._dmdSalesSecond.Add(searchClaimSales);
			}
            // �� 20070122 18322 c
		}
		
		/// <summary>
		/// �������/������� �ێ��p�f�[�^�N���X�X�V����
		/// </summary>
		/// <param name="arrDepsitMain">�����N���X</param>
		/// <param name="arrDepositAlw">���������N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �������/��������ێ��p�f�[�^�N���X�֍X�V���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void UpdateDepositSaveClass(ArrayList arrDepsitMain, ArrayList arrDepositAlw)
		{
			// �������f�[�^�e�[�u�� �f�[�^�Z�b�g����
			foreach(SearchDepsitMain depsitMain in arrDepsitMain)
			{
				// �����}�X�^�N���X����폜
				_depsitMain.Remove(depsitMain.DepositSlipNo);

				// �����}�X�^�N���X�ɒǉ�
				_depsitMain.Add(depsitMain.DepositSlipNo, depsitMain);


				if ((arrDepositAlw != null) && (arrDepositAlw.Count != 0))
				{
					// �f�[�^�ۑ��p ���������}�X�^�擾
					Hashtable htDepositAlw = (Hashtable)_depositAlw[depsitMain.DepositSlipNo];
			
					// �X�V�������������f�[�^�������擾
					foreach (SearchDepositAlw depositAlw in arrDepositAlw)
					{
						// �����}�X�^�Ɠ���̓����ԍ��̎�
						if (depositAlw.DepositSlipNo == depsitMain.DepositSlipNo)
						{
							// ���������f�[�^�̕ێ������������͐V�K�o�^
							if (htDepositAlw == null)
							{
								htDepositAlw = new Hashtable();
								_depositAlw.Add(depsitMain.DepositSlipNo, htDepositAlw);
							}

							// ���������}�X�^�N���X����폜
							// htDepositAlw.Remove(depositAlw.AcceptAnOrderNo);  // 2007.10.05 del
                            htDepositAlw.Remove(depositAlw.SalesSlipNum);        // 2007.10.05 add

				
							// �폜�X�V�ł͂Ȃ����͒ǉ�����
							if (depositAlw.LogicalDeleteCode == 0)
							{
								// ���������}�X�^�N���X�֒ǉ�
                                // htDepositAlw.Add(depositAlw.AcceptAnOrderNo, depositAlw);  // 2007.10.05 del
                                htDepositAlw.Add(depositAlw.SalesSlipNum, depositAlw);        // 2007.10.05 add
							}
						}
					}
				}

			}
		}

		/// <summary>
		/// �������/������� �ێ��p�f�[�^�N���X�폜����
		/// </summary>
		/// <param name="depositSlipNo">�����ԍ�</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �������/��������ێ��p�f�[�^�N���X����폜���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void DeleteDepositSaveClass(int depositSlipNo)
		{
			// �������f�[�^�e�[�u�� �f�[�^�폜����
			_depsitMain.Remove(depositSlipNo);
			
			Hashtable htDepositAlw = (Hashtable)_depositAlw[depositSlipNo];
			if (htDepositAlw != null)
			{
				// ��������}�X�^�N���X�������N���A����
				this.ClearDmdSalesAllowance(htDepositAlw);

				// �����������f�[�^�e�[�u�� �f�[�^�폜����
				_depositAlw.Remove(depositSlipNo);
			}
		}

        // �� 20070131 18322 c MA.NS�p�ɕύX
        #region SF ����������DetaRow�Z�b�g�����i�S�ăR�����g�A�E�g�j
		///// <summary>
		///// ����������DetaRow�Z�b�g����
		///// </summary>
		///// <param name="drNew">����������DataRow</param>
		///// <param name="dmdSales">��������N���X</param>
		///// <remarks>
		///// <br>Note�@�@�@  : �����������DataRow�ɃZ�b�g���܂��B</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private void SetDmdSales(System.Data.DataRow drNew, SearchDmdSales dmdSales)
		//{
		//	// ��
		//	drNew[ctAlwCheck] = false;
		//
		//	// ��������ԍ��敪/����
		//	switch (dmdSales.DebitNoteDiv)
		//	{
		//		case 0:
		//			if (dmdSales.DebitNLnkAcptAnOdr == 0)
		//			{
		//				drNew[ctDmdSalesDebitNoteCd] = dmdSales.DebitNoteDiv;
		//				drNew[ctDmdSalesDebitNoteNm] = "��";
		//			}
		//			else
		//			{
		//				drNew[ctDmdSalesDebitNoteCd] = 2;					// ���E�ςݍ���2�ɂ��肩����
		//				drNew[ctDmdSalesDebitNoteNm] = "���E�ςݍ�";
		//			}
		//			break;
		//		case 1:
		//			drNew[ctDmdSalesDebitNoteCd] = dmdSales.DebitNoteDiv;
		//			drNew[ctDmdSalesDebitNoteNm] = "��";
		//			break;
		//	}
		//
		//	// �󒍔ԍ�
		//	drNew[ctAcceptAnOrderNo] = dmdSales.AcceptAnOrderNo;
		//
		//	// �`�[�ԍ�
		//	drNew[ctSlipNo] = dmdSales.SlipNo;
		//
		//	if (System.DateTime.MinValue != dmdSales.SearchSlipDate)
		//	{
		//		// �`�[���t(�\���p)
		//		drNew[ctSearchSlipDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd", dmdSales.SearchSlipDate);
		//		
		//		// �`�[���t
		//		drNew[ctSearchSlipDate] = TDateTime.DateTimeToLongDate(dmdSales.SearchSlipDate);
		//	}
		//
		//	if (System.DateTime.MinValue != dmdSales.AddUpADate)
		//	{
		//		// �����
		//		drNew[ctAddUpADate] = TDateTime.DateTimeToLongDate(dmdSales.AddUpADate);
		//	}
		//
		//	// �󒍃X�e�[�^�X
		//	drNew[ctAcptAnOdrStatus] = dmdSales.AcptAnOdrStatus;
		//	
		//	// �󒍎��
		//	string str = "";
		//	if (depositRelDataAcs.IntroducedSystemCount == 1)
		//	{
		//		switch (Convert.ToInt32(drNew[ctAcptAnOdrStatus]))
		//		{
		//			case 10 : 
		//				str += "����";
		//				break;
		//			case 20 : 
		//				str += "�w��";
		//				break;
		//			case 30 : 
		//				str += "�[�i";
		//				break;
		//		}
		//	}
		//	else
		//	{
		//		switch (dmdSales.DataInputSystem)
		//		{
		//			case 0 : 
		//				str = "��:";
		//				break;
		//			case 1 : 
		//				str = "��:";
		//				break;
		//			case 2 : 
		//				str = "��:";
		//				break;
		//			case 3 : 
		//				str = "��:";
		//				break;
		//		}
		//		switch (Convert.ToInt32(drNew[ctAcptAnOdrStatus]))
		//		{
		//			case 10 : 
		//				str += "��";
		//				break;
		//			case 20 : 
		//				str += "�w";
		//				break;
		//			case 30 : 
		//				str += "�[";
		//				break;
		//		}
		//	}
		//	drNew[ctSalesKind] = str;
		//
		//	// ���㖼��
		//	drNew[ctSalesName] = dmdSales.SalesName;
		//
		//	// �o�^�ԍ�
		//	drNew[ctNumberPlate] = CarInfoCalculation.GetNumberPlateString(dmdSales.CarMngNo, dmdSales.NumberPlate1Code, dmdSales.NumberPlate1Name, dmdSales.NumberPlate2, dmdSales.NumberPlate3, dmdSales.NumberPlate4);
		//
		//	// �󒍔���z  �󒍔���v�{�󒍏���Ŋz
		//	drNew[ctAcceptAnOrderSales] = dmdSales.AcceptAnOrderSales + dmdSales.AcceptAnOrderConsTax;
		//
		//	// ����p�z  ����p���z�v�{����p����Ŋz
		//	drNew[ctTotalVariousCost] = dmdSales.TotalVariousCost + dmdSales.VarCstConsTax;
		//
		//	// �󒍍��v�z
		//	drNew[ctTotalSales] = Convert.ToInt64(drNew[ctAcceptAnOrderSales]) + Convert.ToInt64(drNew[ctTotalVariousCost]);
		//
		//	// �����z �� (���������}�X�^)  ���ォ������}�X�^���Z�b�g
		//	drNew[ctAcpOdrDepositAlwc_Alw] = 0;
		//
		//	// �����c �� (��������}�X�^)
		//	drNew[ctAcpOdrDepoAlwcBlnce_Sales] = dmdSales.AcpOdrDepoAlwcBlnce;
		//
		//	// ������ �� (��������}�X�^)
		//	drNew[ctAcpOdrDepositAlwc_Sales] = dmdSales.AcpOdrDepositAlwc;
		//
		//	// �����z ����p (���������}�X�^)  ���ォ������}�X�^���Z�b�g
		//	drNew[ctVarCostDepoAlwc_Alw] = 0;
		//
		//	// �����c ����p (��������}�X�^)
		//	drNew[ctVarCostDepoAlwcBlnce_Sales] = dmdSales.VarCostDepoAlwcBlnce;
		//
		//	// ������ ����p (��������}�X�^)
		//	drNew[ctVarCostDepoAlwc_Sales] = dmdSales.VarCostDepoAlwc;
		//
		//	// �����z ���� (���������}�X�^)  ���ォ������}�X�^���Z�b�g
		//	drNew[ctDepositAllowance_Alw] = 0;
		//
		//	// �����c ���� (��������}�X�^)
		//	drNew[ctDepositAlwcBlnce_Sales] = dmdSales.DepositAlwcBlnce;
		//
		//	// ������ ���� (��������}�X�^)
		//	drNew[ctDepositAllowance_Sales] = dmdSales.DepositAllowance;
		//
		//	// ���g��DataRow
		//	drNew[ctSalesDataRow] = drNew;
		//}
		#endregion

        /// <summary>
		/// ����������DetaRow�Z�b�g����
		/// </summary>
		/// <param name="drNew">����������DataRow</param>
		/// <param name="dmdSales">��������N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �����������DataRow�ɃZ�b�g���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// <br>Update Date : 2007.03.27 18322 T.Kimura ��������ԍ��敪��null������Ȃ��悤�ɏC��</br>
        /// <br>Update Note : 2010/12/20 ����� PM.NS��Q���ǑΉ�(12����)
        /// <br>              ���ځu�����v��ǉ�����B</br>
        /// <br>Update Date : 2011/02/09 �����</br>
        /// <br>              Redmine#18848���C������B</br>
        /// <br>Update Date : 2011/07/22 �{�z��</br>
        /// <br>              �\���s��̈׉��P�肢�܂��B</br>
        /// </remarks>
		private void SetClaimSales(DataRow drNew, SearchClaimSales dmdSales)
		{
			// ��
			drNew[ctAlwCheck] = false;

			// ��������ԍ��敪/����
			switch (dmdSales.DebitNoteDiv)
			{
				case 0:
                    // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                    //if (dmdSales.DebitNLnkAcptAnOdr == 0)
                    //{
                    //    drNew[ctDmdSalesDebitNoteCd] = dmdSales.DebitNoteDiv;
                    //    drNew[ctDmdSalesDebitNoteNm] = "��";
                    //}
                    //else
                    //{
                    //    drNew[ctDmdSalesDebitNoteCd] = 2;					// ���E�ςݍ���2�ɂ��肩����
                    //    drNew[ctDmdSalesDebitNoteNm] = "���E�ςݍ�";
                    //}
                    drNew[ctDmdSalesDebitNoteCd] = dmdSales.DebitNoteDiv;
                    drNew[ctDmdSalesDebitNoteNm] = "��";
                    // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
					break;
				case 1:
					drNew[ctDmdSalesDebitNoteCd] = dmdSales.DebitNoteDiv;
					drNew[ctDmdSalesDebitNoteNm] = "��";
					break;
                // �� 20070327 18322 a null������Ȃ��悤�ɏC��
                case 2:
					drNew[ctDmdSalesDebitNoteCd] = 2;
        			drNew[ctDmdSalesDebitNoteNm] = "���E�ςݍ�";
                    break;
                // �� 20070327 18322 a
			}

			// �󒍔ԍ�
			// drNew[ctAcceptAnOrderNo] = dmdSales.AcceptAnOrderNo;   // 2007.10.05 hikita del

            // ����`�[�ԍ�
            drNew[ctSalesSlipNum] = dmdSales.SalesSlipNum;

            if (System.DateTime.MinValue != dmdSales.SalesDate)
			{
                // �� 20070418 18322 c MA.NS�Ή�
				//// �`�[���t(�\���p)
				//drNew[ctSearchSlipDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd", dmdSales.SearchSlipDate);

				// �`�[���t(�\���p)
                //drNew[ctSearchSlipDateDisp] = dmdSales.SearchSlipDate.ToString("yyyy/MM/dd");
                drNew[ctSearchSlipDateDisp] = dmdSales.SalesDate.ToString("yyyy/MM/dd");
                // �� 20070418 18322 c
				
				// �`�[���t
                //drNew[ctSearchSlipDate] = TDateTime.DateTimeToLongDate(dmdSales.SearchSlipDate);
                drNew[ctSearchSlipDate] = TDateTime.DateTimeToLongDate(dmdSales.SalesDate);
			}

			if (System.DateTime.MinValue != dmdSales.AddUpADate)
			{
				// �����
				drNew[ctAddUpADate] = TDateTime.DateTimeToLongDate(dmdSales.AddUpADate);
			}
		
			// �󒍃X�e�[�^�X
			drNew[ctAcptAnOdrStatus] = dmdSales.AcptAnOdrStatus;

            string str;

            // �󒍃X�e�[�^�X��
            str = "";
            switch (dmdSales.AcptAnOdrStatus)
            {
                case 10: str = "����"          ; break;
                case 20: str = "��"          ; break;
                case 30: str = "����"          ; break;
                case 40: str = "�o��"          ; break;
            }
            drNew[ctAcptAnOdrStatusNm] = str;

            // �`�[��ށi����`�[�敪�j
            str = "";
            switch (dmdSales.SalesSlipCd)
            {
                case 0: str = "����"; break; 
                case 1: str = "�ԕi"; break; 
                case 2: str = "�l��"; break; 
            }
            drNew[ctSalesKind] = str;

            //// ���㖼��
            //str = "";
            //switch (dmdSales.SalesFormal)
            //{
            //    case 10: str = "�X������"      ; break;
            //    case 11: str = "�O��"          ; break;
            //    case 20: str = "�Ɩ��̔�(����)"; break;
            //    case 25: str = "���،v��"      ; break;
            //    case 30: str = "�ϑ�"          ; break;
            //    case 35: str = "�ϑ��v��"      ; break;
            //}
            //drNew[ctSalesName] = str;

			// �`�[���v
            if ((this._consTaxLayMethod == 2) || (this._consTaxLayMethod == 3) || (this._consTaxLayMethod == 9))
            {
                // �Ŕ���
                drNew[ctTotalSales] = dmdSales.SalesTotalTaxExc;

                // --- UPD 2011/02/09 ---------->>>>>
                // �����c ���� (��������}�X�^)
                //if (dmdSales.DepositAllowanceTtl != 0)
                //{
                //    drNew[ctDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxExc - dmdSales.DepositAllowanceTtl;
                //    drNew[ctBfDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxExc - dmdSales.DepositAllowanceTtl;
                //}
                //else
                //{
                //    drNew[ctDepositAlwcBlnce_Sales] = 0;
                //    drNew[ctBfDepositAlwcBlnce_Sales] = 0;
                //}
                drNew[ctDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxExc - dmdSales.DepositAllowanceTtl;
                drNew[ctBfDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxExc - dmdSales.DepositAllowanceTtl;
                // --- UPD 2011/02/09  ----------<<<<<
            }
            else
            {
                // �ō���
                drNew[ctTotalSales] = dmdSales.SalesTotalTaxInc;

                // --- UPD 2011/02/09 ---------->>>>>
                // �����c ���� (��������}�X�^)
                //if (dmdSales.DepositAllowanceTtl != 0)
                //{
                    //drNew[ctDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxInc - dmdSales.DepositAllowanceTtl;
                    //drNew[ctBfDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxInc - dmdSales.DepositAllowanceTtl;
                //}
                //else
                //{
                //    drNew[ctDepositAlwcBlnce_Sales] = 0;
                //    drNew[ctBfDepositAlwcBlnce_Sales] = 0;
                //}
                drNew[ctDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxInc - dmdSales.DepositAllowanceTtl;
                drNew[ctBfDepositAlwcBlnce_Sales] = dmdSales.SalesTotalTaxInc - dmdSales.DepositAllowanceTtl;
                // --- UPD 2011/02/09  ----------<<<<<
            }

			// �����z ���� (���������}�X�^)  ���ォ������}�X�^���Z�b�g
			drNew[ctDepositAllowance_Alw] = 0;
            
   			// ������ ���� (��������}�X�^)
            drNew[ctDepositAllowance_Sales] = dmdSales.DepositAllowanceTtl;
            drNew[ctBfDepositAllowance_Sales] = dmdSales.DepositAllowanceTtl;

            // -- UPD 2011/07/22 ------->>>>>
            // �`�[���l
            drNew[ctSlipNote] = dmdSales.SlipNote.Trim() + " " + dmdSales.SlipNote2.Trim() + " " + dmdSales.SlipNote3.Trim();

            // �ŏI�������ߓ�
            drNew[ctLastMonthlyDate] = TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpDay);

            // �v����t�ƑO������X�V�̔�r
            if (drNew[ctAddUpADate] != System.DBNull.Value)
            {
                if ((Convert.ToInt32(drNew[ctAddUpADate]) <= TDateTime.DateTimeToLongDate(this._lastAddUpDay)) ||
                    (Convert.ToInt32(drNew[ctAddUpADate]) <= TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpDay)))
                {
                    // �v����t���O�񐿋����ߓ��ȑO���A�O�񌎎��X�V���ȑO�̂Ƃ��́A���ߍς�
                    drNew[ctSalesClosedFlg] = "�Y";

                    if (this._lastAddUpDay > this._lastMonthlyAddUpDay)
                    {
                        drNew[ctLastMonthlyDateDisp] = this._lastAddUpDay.ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        drNew[ctLastMonthlyDateDisp] = this._lastMonthlyAddUpDay.ToString("yyyy/MM/dd");
                    }
                }
            }
            // -- UPD 2011/07/22 ------->>>>>

            // --- ADD 2010/12/20 ---------->>>>>
            // ����`�[�ԍ�
            drNew[ctDepSaleSlipNum] = dmdSales.DepSalesSlipNum;

            // ����
            if ((long)drNew[ctDepositAlwcBlnce_Sales] == 0 && !string.IsNullOrEmpty(dmdSales.DepSalesSlipNum))
            {
                // ��1:���������c��(DepositAlwcBlnce)��0���u�֘A�t�������`�[������v�ꍇ
                drNew[ctAllowDiv] = "��";
            }
            else if (dmdSales.DepositAllowanceTtl != 0)
            {
                // ��2:��1�ȊO�ŁA�����������v�z(DepositAllowanceTtl)��0
                drNew[ctAllowDiv] = "�ꕔ";
            }
            else
            {
                // ��1�ȊO����2�ȊO�ꍇ
                drNew[ctAllowDiv] = "";
            }
            // --- ADD 2010/12/20  ----------<<<<<

            // ������R�[�h
            drNew[ctClaimCode] = dmdSales.ClaimCode;

            // �����於��
            drNew[ctClaimName] = dmdSales.ClaimName;

            // �����於��2
            drNew[ctClaimName2] = dmdSales.ClaimName2;

            // �����旪��
            drNew[ctClaimSnm] = dmdSales.ClaimSnm;

            // ���Ӑ�R�[�h
            drNew[ctCustomerCode] = dmdSales.CustomerCode;

            // ���Ӑ於��
            drNew[ctCustomerName] = dmdSales.CustomerName;

            // ���Ӑ於��2
            drNew[ctCustomerName2] = dmdSales.CustomerName2;

            // ���Ӑ旪��
            drNew[ctCustomerSnm] = dmdSales.CustomerSnm;

            // �� 20070525 18322 a
            // ���|�敪(0:���|�Ȃ�,1:���|)
            drNew[ctAccRecDivCd] = dmdSales.AccRecDivCd;

            //// 2007.10.05 hikita del start ----------------------------------------->>
            //if (System.DateTime.MinValue == dmdSales.RegiProcDate)
            //{
            //    // ���W������
            //    drNew[ctRegiProcDate] = "";
            //}
            //else
            //{
            //    // ���W������
            //    drNew[ctRegiProcDate] = dmdSales.RegiProcDate.ToString("yyyy/MM/dd");
            //}

            //// ���W�ԍ�
            //drNew[ctCashRegisterNo] = dmdSales.CashRegisterNo;

            //// POS���V�[�g�ԍ�
            //drNew[ctPosReceiptNo]   = dmdSales.PosReceiptNo;
            // �� 20070525 18322 a
            // 2007.10.05 hikita del end --------------------------------------------<<

			// ���g��DataRow
			drNew[ctSalesDataRow] = drNew;
		}
		// �� 20070131 18322 c

		/// <summary>
		/// �������DetaSet�����X�V�t���O�Z�b�g����
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : �������DataSet�̒����X�V�t���O���Z�b�g���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SetDepositDataSetClosedFlg()
		{
			foreach (DataRow dr in this._dsDepositInfo.Tables[ctDepositDataTable].Rows)
			{
				// �v����t
                if ((Convert.ToInt32(dr[ctDepositAddUpADate]) <= TDateTime.DateTimeToLongDate(this._lastAddUpDay)) ||
                    (Convert.ToInt32(dr[ctDepositAddUpADate]) <= this.GetLastMonthlyDate()))
				{
                    // �������ߍς݂��������߂̂Ƃ�
					dr[ctDepositClosedFlg] = "�Y";
				}
			}
		}

        // --------- ADD ���N�@2012/12/24�@Redmine#33741 ----->>>>>
        /// <summary>
        /// �������DetaSet�����X�V�t���O�Z�b�g����
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �������DataSet�̒����X�V�t���O���Z�b�g���܂��B</br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void SetDepositGuidDataSetClosedFlg()
        {
            foreach (DataRow dr in this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows)
            {
                // �v����t
                if ((Convert.ToInt32(dr[ctDepositAddUpADate]) <= TDateTime.DateTimeToLongDate(this._lastAddUpDay)) ||
                    (Convert.ToInt32(dr[ctDepositAddUpADate]) <= this.GetLastMonthlyDate()))
                {
                    // �������ߍς݂��������߂̂Ƃ�
                    dr[ctDepositClosedFlg] = "�Y";
                }
            }
        }
        /// <summary>
        /// �������DetaSet�����X�VDataRow�폜�������Ӑ���͂Ȃ��̏ꍇ
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �������DataSet�̒����X�VDataRow���폜���܂��B</br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void SetDepositGuidDataRemoveByMonth()
        {
            for (int i = this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows.Count - 1; i >= 0; i--)
            {
                string data = this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows[i][ctDepositAddUpADate].ToString();
                //�v����t
                if ((Convert.ToInt32(data) <= this.GetLastMonthlyDate()))
                {
                    this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows[i].Delete();
                }
            }
            this._dsDepositInfo.Tables[ctDepositGuidDataTable].AcceptChanges();
        }

        /// <summary>
        /// �������DetaSet�����X�VDataRow�폜����(���Ӑ���͂̏ꍇ)
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �������DataSet�̒����X�VDataRow���폜���܂��B</br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void SetDepositGuidDataRemove()
        {
            for (int i = this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows.Count - 1; i >= 0; i--)
            {
                string data = this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows[i][ctDepositAddUpADate].ToString();
                //�v����t
                if ((Convert.ToInt32(data) <= TDateTime.DateTimeToLongDate(this._lastAddUpDay)) ||
                        (Convert.ToInt32(data) <= this.GetLastMonthlyDate()))
                {
                    this._dsDepositInfo.Tables[ctDepositGuidDataTable].Rows[i].Delete();
                }
            }
            this._dsDepositInfo.Tables[ctDepositGuidDataTable].AcceptChanges();
        }
        // --------- ADD ���N�@2012/12/24�@Redmine#33741 -----<<<<<

		/// <summary>
		/// ����������DetaSet�����X�V�t���O�Z�b�g����
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : ����������DataSet�̒����X�V�t���O���Z�b�g���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SetDmdSalesDataSetClosedFlg()
		{
			foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
			{
                // �� 20070202 18322 c MA.NS�p�ɕύX
				//// �v����t ���� ���Z�`�[
				//if ((dr[ctAddUpADate] != System.DBNull.Value) &&
				//    (Convert.ToInt32(dr[ctAddUpADate]) <= _depositCustomer.CAddUpUpdDate) &&
				//	(Convert.ToInt32(dr[ctAcptAnOdrStatus]) == 30))
				//{
				//	dr[ctSalesClosedFlg] = "�Y";
				//}

                if (dr[ctAddUpADate] != System.DBNull.Value)
                {
                    if ((Convert.ToInt32(dr[ctAddUpADate]) <= TDateTime.DateTimeToLongDate(this._lastAddUpDay)) ||
                        (Convert.ToInt32(dr[ctAddUpADate]) <= this.GetLastMonthlyDate()))
                    {
        				// �v����t�ȑO
                        switch (Convert.ToInt32(dr[ctAcptAnOdrStatus]))
                        {
                            case 30 :    // ����
                            //case 40 :    // ����                 // 2007.10.05 del
                            //case 55 :    // �ϑ��v��             // 2007.10.05 del
             					dr[ctSalesClosedFlg] = "�Y";
                                break;
                            default :
                                // ��L�ȊO�̓`�[
         		    			dr[ctSalesClosedFlg] = "";
                                break;
                        }
                    }
                }
                // �� 20070202 18322 c

			}
		}
		
		/// <summary>
		/// ����������DetaSet�����������N���A����
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : ����������DataSet���������������N���A���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void DmdSalesDepositAllowanceClear()
		{
			foreach (DataRow dr in _dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
			{
				// ��
				dr[ctAlwCheck] = false;

                // �� 20070118 18322 d MA.NS�p�ɕύX
				//// �����z �� (���������}�X�^)
				//dr[ctAcpOdrDepositAlwc_Alw] = 0;
                //
				//// �����z ����p (���������}�X�^)
				//dr[ctVarCostDepoAlwc_Alw] = 0;
                // �� 20070118 18322 d

				// �����z ���� (���������}�X�^)
				dr[ctDepositAllowance_Alw] = 0;
			}
        }

        #region DEL 2008/06/26 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �������ύX����
		/// </summary>
		/// <param name="depositAllowance">���������z</param>
		/// <param name="drDmdSales">����������DataRow</param>
		/// <param name="drDeposit">�������DataRow</param>
		/// <param name="drAllowance">�������DataRow</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �������̈����z���X�V���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void UpdateAllowance(Int64 depositAllowance, DataRow drDmdSales, DataRow drDeposit, ref ArrayList drAllowance)
		{
			// �������DataRow�̎擾
			foreach (DataRow drChild in drAllowance)
			{
				// ����󒍔ԍ��̎�
				// if (Convert.ToInt32(drChild[ctAcceptAnOrderNo_Alw]) == Convert.ToInt32(drDmdSales[ctAcceptAnOrderNo]))  // 2007.10.05 del

                // ���ꔄ��ԍ��̎�
                if (Convert.ToString(drChild[ctSalesSlipNum_Alw]) == Convert.ToString(drDmdSales[ctSalesSlipNum]))         // 2007.10.05 add
				{
					if (depositAllowance == 0)
					{
						// �����z0�~�̎��͍폜
						drAllowance.Remove(drChild);
					}
					else
					{
						// �����z�̍X�V
						drChild[ctDepositAllowance] = depositAllowance;
					}

					return;
				}
			}

			// ����󒍔ԍ��s�������Ă������z0�~�̎��͐V�K�s�͒ǉ������ɖ�������
			if (depositAllowance == 0) return;

            // �� 20070202 18322 c MA.NS�p�ɕύX
			//// �������V�K�s�ǉ�����  �������DataRow���������͐V�K�Ƃ��Ēǉ�����
			//DataRow drNewAlw = this.AllowanceNewRow(Convert.ToInt32(drDeposit[ctDepositSlipNo]), Convert.ToInt32(drDmdSales[ctAcceptAnOrderNo]), Convert.ToInt32(drDeposit[ctDepositDate]));

			// �������V�K�s�ǉ�����  �������DataRow���������͐V�K�Ƃ��Ēǉ�����
            DataRow drNewAlw = this.AllowanceNewRow(Convert.ToInt32(drDmdSales[ctAcptAnOdrStatus_Alw])
                                                   , Convert.ToInt32(drDeposit[ctDepositSlipNo])
            //                                       , Convert.ToInt32(drDmdSales[ctAcceptAnOrderNo])  // 2007.10.05 del
                                                   , drDmdSales[ctSalesSlipNum].ToString()
            //                                       , Convert.ToInt32(drDeposit[ctDepositDate]));     // 2007.10.05 del
                                                   , Convert.ToInt32(drDeposit[ctDepositAddUpADate])); // 2007.10.05 add

            // �� 20070202 18322 c

			// ���������z
			drNewAlw[ctDepositAllowance] = depositAllowance;

			// �V�K�ǉ�
			drAllowance.Add(drNewAlw);
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/26 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
		/// �Ǎ��������}�X�^�E���������}�X�^�擾����
		/// </summary>
		/// <param name="depositSlipNo">�����ԍ�</param>
		/// <param name="depsitMain">�����}�X�^</param>
		/// <param name="htDepositAlw">���������}�X�^</param>
		/// <remarks>
		/// <br>Note       : �����ԍ������ɁA�Ǎ����̓����}�X�^/���������}�X�^���擾���܂��B
		///                : �G���[����DepositException��O���������܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void GetBeforeDepositData(int depositSlipNo, out SearchDepsitMain depsitMain, out Hashtable htDepositAlw)
		{
			// �f�[�^�ۑ��p �����}�X�^�擾
			depsitMain = ((SearchDepsitMain)_depsitMain[depositSlipNo]).Clone();

			// �f�[�^�ۑ��p ���������}�X�^�擾
			if (_depositAlw[depositSlipNo] != null)
			{
				htDepositAlw = (Hashtable)((Hashtable)_depositAlw[depositSlipNo]).Clone();
			}
			else
			{
				htDepositAlw = new Hashtable();
			}

			// �����}�X�^���������͗�O�𔭐�������
			if (depsitMain == null)
			{
				throw new DepositException("�Ǎ����̓����`�[�擾�Ɏ��s���܂����B", (int)ConstantManagement.DB_Status.ctDB_ERROR);
			}

		}

        // �� 20070131 18322 c MA.NS�p�ɕύX
        #region SF �����}�X�^�E���������}�X�^�X�V���e�Z�b�g�����i�S�ăR�����g�A�E�g�j
		///// <summary>
		///// �����}�X�^�E���������}�X�^�X�V���e�Z�b�g����
		///// </summary>
		///// <param name="updateMode">�X�V���[�h</param>
		///// <param name="loginSectionCode">���O�C�����_�R�[�h</param>
		///// <param name="addSectionCode">�X�V���_�R�[�h</param>
		///// <param name="customerCode">���Ӑ�R�[�h</param>
		///// <param name="aftDepositRow">�����}�X�^(�ύX���e)</param>
		///// <param name="aftAllowanceRows">���������}�X�^(�ύX���e)</param>
		///// <param name="depsitMain">�����}�X�^</param>
		///// <param name="htDepositAlw">���������}�X�^</param>
		///// <remarks>
		///// <br>Note       : �����}�X�^/���������}�X�^�̓��e��Ǎ����f�[�^���X�V�p�f�[�^�ɕϊ����܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//private void SetUpdateDepositData1(UpdateMode updateMode, string loginSectionCode, string addSectionCode, int customerCode, System.Data.DataRow aftDepositRow, ArrayList aftAllowanceRows, ref SearchDepsitMain depsitMain, ref Hashtable htDepositAlw)
		//{
		//
		//	// --- �����}�X�^ --- //
		//
		//	// �V�K�o�^�̎�
		//	if (updateMode == UpdateMode.Insert)
		//	{
		//		// ��ƃR�[�h
		//		depsitMain.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		//
		//		// ���Ӑ�R�[�h
		//		depsitMain.CustomerCode = customerCode;
		//
		//		// �������͋��_�R�[�h
		//		depsitMain.InputDepositSecCd = loginSectionCode;
		//
		//		// �v�㋒�_�R�[�h
		//		depsitMain.AddUpSecCode = addSectionCode;
		//	}
		//
		//	// �_���폜�敪
		//	depsitMain.LogicalDeleteCode = 0;
		//
		//	// �����ԍ��敪
		//	depsitMain.DepositDebitNoteCd = 0;
		//
		//	// ��������R�[�h
		//	depsitMain.DepositKindCode = Convert.ToInt32(aftDepositRow[ctDepositKindCode]);
		//	
		//	// �������햼��
		//	depsitMain.DepositKindName = aftDepositRow[ctDepositKindName].ToString();
		//
		//	// ��������敪
		//	depsitMain.DepositKindDivCd = Convert.ToInt32(aftDepositRow[ctDepositKindDivCd]);;
		//
		//	// �a����敪
		//	depsitMain.DepositCd = Convert.ToInt32(aftDepositRow[ctDepositCd]);
		//
		//	// �� �����z
		//	depsitMain.AcpOdrDeposit = Convert.ToInt64(aftDepositRow[ctAcpOdrDeposit]);
		//
		//	// �� �萔��
		//	depsitMain.AcpOdrChargeDeposit = Convert.ToInt64(aftDepositRow[ctAcpOdrChargeDeposit]);
		//
		//	// �� �l��
		//	depsitMain.AcpOdrDisDeposit = Convert.ToInt64(aftDepositRow[ctAcpOdrDisDeposit]);
		//
		//	// ����p �����z
		//	depsitMain.VariousCostDeposit = Convert.ToInt64(aftDepositRow[ctVariousCostDeposit]);
		//
		//	// ����p �萔��
		//	depsitMain.VarCostChargeDeposit = Convert.ToInt64(aftDepositRow[ctVarCostChargeDeposit]);
		//
		//	// ����p �l��
		//	depsitMain.VarCostDisDeposit = Convert.ToInt64(aftDepositRow[ctVarCostDisDeposit]);
		//
		//	// ���� �����z
		//	depsitMain.Deposit = Convert.ToInt64(aftDepositRow[ctDeposit]);
		//
		//	// ���� �萔��
		//	depsitMain.FeeDeposit = Convert.ToInt64(aftDepositRow[ctFeeDeposit]);
		//
		//	// ���� �l��
		//	depsitMain.DiscountDeposit = Convert.ToInt64(aftDepositRow[ctDiscountDeposit]);
		//
		//	// ���� �����v
		//	depsitMain.DepositTotal = Convert.ToInt64(aftDepositRow[ctDepositTotal]);
		//
		//	// ���������z ��
		//	depsitMain.AcpOdrDepositAlwc = Convert.ToInt64(aftDepositRow[ctAcpOdrDepositAlwc_Deposit]);
		//
		//	// ���������c ��
		//	depsitMain.AcpOdrDepoAlwcBlnce = Convert.ToInt64(aftDepositRow[ctAcpOdrDepoAlwcBlnce_Deposit]);
		//
		//	// ���������z ����p
		//	depsitMain.VarCostDepoAlwc = Convert.ToInt64(aftDepositRow[ctVarCostDepoAlwc_Deposit]);
		//
		//	// ���������c ����p
		//	depsitMain.VarCostDepoAlwcBlnce = Convert.ToInt64(aftDepositRow[ctVarCostDepoAlwcBlnce_Deposit]);
		//
		//	// ���������z ����
		//	depsitMain.DepositAllowance = Convert.ToInt64(aftDepositRow[ctDepositAllowance_Deposit]);
		//
		//	// ���������c ����
		//	depsitMain.DepositAlwcBlnce = Convert.ToInt64(aftDepositRow[ctDepositAlwcBlnce_Deposit]);
		//
		//	// �E�v
		//	depsitMain.Outline = aftDepositRow[ctOutline].ToString();
		//
		//	// �������t
		//	depsitMain.DepositDate = TDateTime.LongDateToDateTime(Convert.ToInt32(aftDepositRow[ctDepositDate])); 
		//
		//	// �v����t
		//	depsitMain.AddUpADate = depsitMain.DepositDate; 
		//
		//	// �X�V���_�R�[�h
		//	depsitMain.UpdateSecCd = loginSectionCode;
		//
		//	// �����S���҃R�[�h
		//	depsitMain.DepositAgentCode = ((Employee)LoginInfoAcquisition.Employee).EmployeeCode;
		//
		//	// �N���W�b�g/���[���敪
		//	depsitMain.CreditOrLoanCd = Convert.ToInt32(aftDepositRow[ctCreditOrLoanCd]);
		//
		//	// �N���W�b�g��ЃR�[�h
		//	depsitMain.CreditCompanyCode = aftDepositRow[ctCreditCompanyCode].ToString();
		//
		//	// ��`�U�o��
		//	depsitMain.DraftDrawingDate = TDateTime.LongDateToDateTime(Convert.ToInt32(aftDepositRow[ctDraftDrawingDate])); 
		//
		//	// ��`�x������
		//	depsitMain.DraftPayTimeLimit = TDateTime.LongDateToDateTime(Convert.ToInt32(aftDepositRow[ctDraftPayTimeLimit])); 
		//
		//	// �ԍ������A���ԍ�
		//	depsitMain.DebitNoteLinkDepoNo = 0;
		//
		//
		//	// --- ���������}�X�^ �V�K/�X�V --- //
		//	UpdateMode allowanceUpdateMode = 0;
		//	foreach (System.Data.DataRow dr in aftAllowanceRows)
		//	{
		//		// ����󒍔ԍ��̈������擾
		//		SearchDepositAlw depositAlw = (SearchDepositAlw)htDepositAlw[Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw])];
		//
		//		// �n�b�V���e�[�u���ɖ������͐V�K����
		//		if (depositAlw == null)
		//		{
		//			// �V�K���[�h
		//			allowanceUpdateMode = UpdateMode.Insert;
		//			depositAlw = new SearchDepositAlw();
		//			htDepositAlw.Add(Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]), depositAlw);
		//		}
		//		else
		//		{
		//			// �ȉ��̍��ڂ��ς��Ȃ���
		//			// 1.�󒍓��������z, 2.����p���������z, 3.����R�[�h, 4.�������t, 5.�ԓ`���E�敪, 6.�a����敪, 7.�N���W�b�g�敪, 8.�����ݓ�, 9.�����݌v���
		//			if ((depositAlw.AcpOdrDepositAlwc == Convert.ToInt64(dr[ctAcpOdrDepositAlwc])) &&
		//				(depositAlw.VarCostDepoAlwc == Convert.ToInt64(dr[ctVarCostDepoAlwc])) &&
		//				(depositAlw.DepositKindCode == depsitMain.DepositKindCode) &&
		//				(depositAlw.DepositInputDate == depsitMain.DepositDate) &&
		//				(depositAlw.DebitNoteOffSetCd == depsitMain.DepositDebitNoteCd) &&
		//				(depositAlw.DepositCd == depsitMain.DepositCd) &&
		//				(depositAlw.CreditOrLoanCd == depsitMain.CreditOrLoanCd) &&
		//				(depositAlw.ReconcileDate == TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileDate]))) &&
		//				(depositAlw.ReconcileAddUpDate == TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileAddUpDate]))))
		//			{
		//				// �ύX�����̓n�b�V���e�[�u�����폜
		//				htDepositAlw.Remove(Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]));
		//				continue;
		//			}
		//
		//			// �X�V���[�h
		//			allowanceUpdateMode = UpdateMode.Update;
		//		}
		//
		//		
		//		// �V�K�o�^�̎�
		//		if (allowanceUpdateMode == UpdateMode.Insert)
		//		{
		//			// ��ƃR�[�h
		//			depositAlw.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		//
		//			// ���Ӑ�R�[�h
		//			depositAlw.CustomerCode = customerCode;
		//
		//			// �v�㋒�_�R�[�h
		//			depositAlw.AddUpSecCode = addSectionCode;
		//
		//			// �����ԍ�
		//			depositAlw.DepositSlipNo = depsitMain.DepositSlipNo;
		//		}
		//
		//		// �󒍓`�[�ԍ�
		//		depositAlw.AcceptAnOrderNo = Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]);
		//
		//		// ��������R�[�h
		//		depositAlw.DepositKindCode = depsitMain.DepositKindCode;
		//
		//		// �������t
		//		depositAlw.DepositInputDate = depsitMain.DepositDate;
		//
		//		// ���������z ��
		//		depositAlw.AcpOdrDepositAlwc = Convert.ToInt64(dr[ctAcpOdrDepositAlwc]);
		//
		//		// ���������z ����p
		//		depositAlw.VarCostDepoAlwc = Convert.ToInt64(dr[ctVarCostDepoAlwc]);
		//
		//		// ���������z ����
		//		depositAlw.DepositAllowance = Convert.ToInt64(dr[ctDepositAllowance]);
		//
		//		// ������
		//		depositAlw.ReconcileDate = TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileDate])); 
		//
		//		// �����v����t
		//		depositAlw.ReconcileAddUpDate = TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileAddUpDate]));
		//
		//		// �ԓ`���E�敪
		//		depositAlw.DebitNoteOffSetCd = depsitMain.DepositDebitNoteCd; 
		//
		//		// �a����敪
		//		depositAlw.DepositCd = depsitMain.DepositCd;
		//
		//		// �N���W�b�g/���[���敪
		//		depositAlw.CreditOrLoanCd = depsitMain.CreditOrLoanCd;
		//	}
		//
		//	// --- ���������}�X�^ �폜 --- //
		//	foreach (DictionaryEntry myDE in htDepositAlw)
		//	{
		//		SearchDepositAlw depositAlw = (SearchDepositAlw)myDE.Value;
		//		allowanceUpdateMode = UpdateMode.Delete;
		//		foreach (System.Data.DataRow dr in aftAllowanceRows)
		//		{
		//			if (depositAlw.AcceptAnOrderNo == Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]))
		//			{
		//				allowanceUpdateMode = UpdateMode.Update;
		//				break;
		//			}
		//		}
		//
		//		// DataRow�Ƀn�b�V���e�[�u���̃��R�[�h���������͍폜���ꂽ�Ƃ݂Ȃ�
		//		if (allowanceUpdateMode == UpdateMode.Delete)
		//		{
		//			depositAlw.LogicalDeleteCode = 1;
		//		}
		//	}
		//}
        #endregion

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// �����}�X�^�E���������}�X�^�X�V���e�Z�b�g����
		/// </summary>
		/// <param name="updateMode">�X�V���[�h</param>
		/// <param name="loginSectionCode">���O�C�����_�R�[�h</param>
		/// <param name="addSectionCode">�X�V���_�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="aftDepositRow">�����}�X�^(�ύX���e)</param>
		/// <param name="aftAllowanceRows">���������}�X�^(�ύX���e)</param>
		/// <param name="depsitMain">�����}�X�^</param>
		/// <param name="htDepositAlw">���������}�X�^</param>
		/// <remarks>
		/// <br>Note       : �����}�X�^/���������}�X�^�̓��e��Ǎ����f�[�^���X�V�p�f�[�^�ɕϊ����܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SetUpdateDepositData1(UpdateMode updateMode, string loginSectionCode, string addSectionCode, int customerCode, int claimCode, DataRow aftDepositRow, ArrayList aftAllowanceRows, ref SearchDepsitMain depsitMain, ref Hashtable htDepositAlw)
		{
            //==========================================//
			// ---            �����}�X�^            --- //
            //==========================================//

			// �V�K�o�^�̎�
			if (updateMode == UpdateMode.Insert)
			{
				// ��ƃR�[�h
				depsitMain.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // ������R�[�h
                depsitMain.ClaimCode = claimCode;

                // �����於1
                depsitMain.ClaimName = this._depositCustomer.CName;

                // �����於2
                depsitMain.ClaimName2 = this._depositCustomer.CName2;

                // �����旪��
                depsitMain.ClaimSnm = this._depositCustomer.CSnm;

				// ���Ӑ�R�[�h
				depsitMain.CustomerCode = customerCode;

                // ���Ӑ於1
                depsitMain.CustomerName = this._depositCustomer.Name;

                // ���Ӑ於2
                depsitMain.CustomerName2 = this._depositCustomer.Name2;

                // ���Ӑ旪��
                depsitMain.CustomerSnm = this._depositCustomer.CSnm;

				// �������͋��_�R�[�h
				depsitMain.InputDepositSecCd = loginSectionCode;

				// �v�㋒�_�R�[�h
				depsitMain.AddUpSecCode = addSectionCode;
			}

			// �_���폜�敪
			depsitMain.LogicalDeleteCode = 0;

			// �����ԍ��敪
			depsitMain.DepositDebitNoteCd = 0;

            // ��������R�[�h
            depsitMain.DepositKindCode = Convert.ToInt32(aftDepositRow[ctDepositKindCode]);

            // �������햼��
            depsitMain.DepositKindName = aftDepositRow[ctDepositKindName].ToString();

            // ��������敪
            depsitMain.DepositKindDivCd = Convert.ToInt32(aftDepositRow[ctDepositKindDivCd]);
            
			// �a����敪
            depsitMain.DepositCd = Convert.ToInt32(aftDepositRow[ctDepositCd]);

			// ���� �����z
			depsitMain.Deposit = Convert.ToInt64(aftDepositRow[ctDeposit]);

			// ���� �萔��
			depsitMain.FeeDeposit = Convert.ToInt64(aftDepositRow[ctFeeDeposit]);

			// ���� �l��
			depsitMain.DiscountDeposit = Convert.ToInt64(aftDepositRow[ctDiscountDeposit]);

			// ���� �C���Z���e�B�u
			// depsitMain.RebateDeposit = Convert.ToInt64(aftDepositRow[ctRebateDeposit]);    // 2007.10.05 hikita del

            // ���� �����v
            depsitMain.DepositTotal = Convert.ToInt64(aftDepositRow[ctDepositTotal]);
            
            // ���������z ����
			depsitMain.DepositAllowance = Convert.ToInt64(aftDepositRow[ctDepositAllowance_Deposit]);

			// ���������c ����
			depsitMain.DepositAlwcBlnce = Convert.ToInt64(aftDepositRow[ctDepositAlwcBlnce_Deposit]);
            
			// �E�v
			depsitMain.Outline = aftDepositRow[ctOutline].ToString();

            // �󒍃X�e�[�^�X
            depsitMain.AcptAnOdrStatus = Convert.ToInt32(aftDepositRow[ctDepositAcptAnOdrStatus]);                   // 2007.10.05 add

			// �������t
			// depsitMain.DepositDate = TDateTime.LongDateToDateTime(Convert.ToInt32(aftDepositRow[ctDepositDate])); // 2007.10.05 del
            depsitMain.DepositDate = DateTime.Today;                                                                 // 2007.10.05 add
                
			// �v����t
			//depsitMain.AddUpADate = depsitMain.DepositDate;                                                            // 2007.10.05 del
            depsitMain.AddUpADate = TDateTime.LongDateToDateTime(Convert.ToInt32(aftDepositRow[ctDepositAddUpADate]));   // 2007.10.05 add

			// �X�V���_�R�[�h
			depsitMain.UpdateSecCd = loginSectionCode;

			// �����S���҃R�[�h
			depsitMain.DepositAgentCode = ((Employee)LoginInfoAcquisition.Employee).EmployeeCode;

            // �����S���Җ�
			depsitMain.DepositAgentNm = ((Employee)LoginInfoAcquisition.Employee).Name;

			// �N���W�b�g/���[���敪
			// depsitMain.CreditOrLoanCd = Convert.ToInt32(aftDepositRow[ctCreditOrLoanCd]);   // 2007.10.05 hikita del

			// �N���W�b�g��ЃR�[�h
			// depsitMain.CreditCompanyCode = aftDepositRow[ctCreditCompanyCode].ToString();   // 2007.10.05 hikita del

			// ��`�U�o��
			depsitMain.DraftDrawingDate = TDateTime.LongDateToDateTime(Convert.ToInt32(aftDepositRow[ctDraftDrawingDate]));

            // ��`�x������
            depsitMain.DraftPayTimeLimit = TDateTime.LongDateToDateTime(Convert.ToInt32(aftDepositRow[ctDraftPayTimeLimit])); 

            // 2007.10.05 add start -------------------------------------------->>
            // ��s�R�[�h
            depsitMain.BankCode = Convert.ToInt32(aftDepositRow[ctBankCode]);

            // ��s����
            depsitMain.BankName = aftDepositRow[ctBankName].ToString();

            // ��`�ԍ�
            depsitMain.DraftNo = aftDepositRow[ctDraftNo].ToString();

            // ��`���
            depsitMain.DraftKind = Convert.ToInt32(aftDepositRow[ctDraftKind]);

            // ��`��ޖ���
            depsitMain.DraftKindName = aftDepositRow[ctDraftKindName].ToString();

            // ��`�敪
            depsitMain.DraftDivide = Convert.ToInt32(aftDepositRow[ctDraftDivide]);

            // ��`�敪����
            depsitMain.DraftDivideName = aftDepositRow[ctDraftDivideName].ToString();
            // 2007.10.05 add end ----------------------------------------------<<

			// �ԍ������A���ԍ�
			depsitMain.DebitNoteLinkDepoNo = 0;


            //==========================================//
			// ---     ���������}�X�^ �V�K/�X�V     --- //
            //==========================================//
			UpdateMode allowanceUpdateMode = 0;
			foreach (DataRow dr in aftAllowanceRows)
			{
				// ����󒍔ԍ��̈������擾
				// SearchDepositAlw depositAlw = (SearchDepositAlw)htDepositAlw[Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw])];  // 2007.10.05 del
                // ���ꔄ��ԍ��̈������擾
                SearchDepositAlw depositAlw = (SearchDepositAlw)htDepositAlw[Convert.ToString(dr[ctSalesSlipNum_Alw])];       // 2007.10.05 add

				// �n�b�V���e�[�u���ɖ������͐V�K����
				if (depositAlw == null)
				{
					// �V�K���[�h
					allowanceUpdateMode = UpdateMode.Insert;
					depositAlw = new SearchDepositAlw();
					// htDepositAlw.Add(Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]), depositAlw);   // 2007.10.05 del
                    htDepositAlw.Add(Convert.ToString(dr[ctSalesSlipNum_Alw]), depositAlw);        // 2007.10.05 add

				}
				else
				{
					// �ȉ��̍��ڂ��ς��Ȃ���
					// 1.����R�[�h, 2.�ԓ`���E�敪, 3.�a����敪,
                    // 4.�N���W�b�g�敪, 5.�����ݓ�, 6.�����݌v���
                    // 7.�����z
					if (
                        //(depositAlw.DepositKindCode == depsitMain.DepositKindCode) &&   // 2008/06/26 DEL
						(depositAlw.DebitNoteOffSetCd == depsitMain.DepositDebitNoteCd) &&
                        //(depositAlw.DepositCd == depsitMain.DepositCd) &&   // 2008/06/26 DEL
//						(depositAlw.CreditOrLoanCd == depsitMain.CreditOrLoanCd) &&   // 2007.10.05 del
						(depositAlw.ReconcileDate == TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileDate]))) &&
						(depositAlw.ReconcileAddUpDate == TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileAddUpDate]))) &&
                        (depositAlw.DepositAllowance == Convert.ToInt64(dr[ctDepositAllowance])))
					{
						// �ύX�����̓n�b�V���e�[�u�����폜
						// htDepositAlw.Remove(Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]));   // 2007.10.05 del
                        htDepositAlw.Remove(Convert.ToString(dr[ctSalesSlipNum_Alw]));        // 2007.10.05 add
						continue;
					}

					// �X�V���[�h
					allowanceUpdateMode = UpdateMode.Update;
				}

				
				// �V�K�o�^�̎�
				if (allowanceUpdateMode == UpdateMode.Insert)
				{
					// ��ƃR�[�h
					depositAlw.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                    // ������R�[�h
                    depositAlw.ClaimCode = depsitMain.ClaimCode;

                    // �����於1
                    depositAlw.ClaimName = depsitMain.ClaimName;

                    // �����於2
                    depositAlw.ClaimName2 = depsitMain.ClaimName2;

                    // �����旪��
                    depositAlw.ClaimSnm = depsitMain.ClaimSnm;

					// ���Ӑ�R�[�h
					depositAlw.CustomerCode = depsitMain.CustomerCode;

                    // ���Ӑ於1
                    depositAlw.CustomerName = depsitMain.CustomerName;

                    // ���Ӑ於2
                    depositAlw.CustomerName2 = depsitMain.CustomerName2;

                    // ���Ӑ旪��
                    depositAlw.CustomerSnm = depsitMain.CustomerSnm;

					// �v�㋒�_�R�[�h
					depositAlw.AddUpSecCode = depsitMain.AddUpSecCode;

     				// �������͋��_�R�[�h
	    			depositAlw.InputDepositSecCd = depsitMain.InputDepositSecCd;

					// �����ԍ�
					depositAlw.DepositSlipNo = depsitMain.DepositSlipNo;

  				}

                // ��������R�[�h
                depositAlw.DepositKindCode = depsitMain.DepositKindCode;

                // �������햼��
                depositAlw.DepositKindName = depsitMain.DepositKindName;

				// �󒍓`�[�ԍ�
				depositAlw.AcceptAnOrderNo = Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]);   // 2007.10.05 del

                // �󒍃X�e�[�^�X
                depositAlw.AcptAnOdrStatus = Convert.ToInt32(dr[ctAcptAnOdrStatus_Alw]);      // 2007.10.05 add
                
            �@�@// ����`�[�ԍ�
                depositAlw.SalesSlipNum = Convert.ToString(dr[ctSalesSlipNum_Alw]);           // 2007.10.05 add

                // ���������z ����
				depositAlw.DepositAllowance = Convert.ToInt64(dr[ctDepositAllowance]);

				// �������i�������j
				depositAlw.ReconcileDate = TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileDate])); 

				// �����v����t�i�����݌v����j
				depositAlw.ReconcileAddUpDate = TDateTime.LongDateToDateTime(Convert.ToInt32(dr[ctReconcileAddUpDate]));

       			// �����S���҃R�[�h
			    depositAlw.DepositAgentCode = depsitMain.DepositAgentCode;

                // �����S���Җ�
			    depositAlw.DepositAgentNm = depsitMain.DepositAgentNm;

				// �ԓ`���E�敪
				depositAlw.DebitNoteOffSetCd = depsitMain.DepositDebitNoteCd;

				// �a����敪
                depositAlw.DepositCd = 0;
                
                // �N���W�b�g/���[���敪
				// depositAlw.CreditOrLoanCd = depsitMain.CreditOrLoanCd;  // 2007.10.05 del
			}

			// --- ���������}�X�^ �폜 --- //
			foreach (DictionaryEntry myDE in htDepositAlw)
			{
				SearchDepositAlw depositAlw = (SearchDepositAlw)myDE.Value;
				allowanceUpdateMode = UpdateMode.Delete;
				foreach (DataRow dr in aftAllowanceRows)
				{
                    // if (depositAlw.AcceptAnOrderNo == Convert.ToInt32(dr[ctAcceptAnOrderNo_Alw]))  // 2007.10.05 del
                    if (depositAlw.SalesSlipNum == Convert.ToString(dr[ctSalesSlipNum_Alw]))          // 2007.10.05 add
					{
						allowanceUpdateMode = UpdateMode.Update;
						break;
                    }
				}

				// DataRow�Ƀn�b�V���e�[�u���̃��R�[�h���������͍폜���ꂽ�Ƃ݂Ȃ�
				if (allowanceUpdateMode == UpdateMode.Delete)
				{
					depositAlw.LogicalDeleteCode = 1;
				}
			}
		}
        // �� 20070131 18322 c
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        /// <summary>
        /// �����}�X�^�E���������}�X�^�X�V���e�Z�b�g����
        /// </summary>
        /// <param name="updateMode">�X�V���[�h</param>
        /// <param name="loginSectionCode">���O�C�����_�R�[�h</param>
        /// <param name="addSectionCode">�X�V���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="aftDepositRow">�����}�X�^(�ύX���e)</param>
        /// <param name="aftAllowanceRows">���������}�X�^(�ύX���e)</param>
        /// <param name="depositDate">������</param>
        /// <param name="depsitMain">�����}�X�^</param>
        /// <param name="htDepositAlw">���������}�X�^</param>
        /// <remarks>
        /// <br>Note       : �����}�X�^/���������}�X�^�̓��e��Ǎ����f�[�^���X�V�p�f�[�^�ɕϊ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// <br>UpdateNote : K2012/07/13 FSI���� �R�`���i�ʈ˗�</br>
        /// <br>             �U�����z���͎��͓Ǝ��̋�s�R�[�h�̓��͂��\�ɏC��</br>
        /// <br>Update Note: 2012/09/21 �c����</br>
        /// <br>�Ǘ��ԍ�   : 2012/10/17�z�M��</br>
        /// <br>             Redmine#32415 ���s�҂̒ǉ��Ή�</br>
        /// <br>Update Note: 2013/01/31 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#34506 ��������^�u�����������ƁA�����ꗗ�ň�����"��"�A�������z���[���ɂȂ�Ȃ��Ή�</br>
        /// <br>Update Note: 2015/07/16 �e�c ���V</br>
        /// <br>�Ǘ��ԍ�   : 11100068-00</br>
        /// <br>             ���C�����ԍH�Ɖۑ�Ή��ꗗ��1</br>
        /// <br>             ������Q�B</br>
        /// <br>               �ꕔ�������s���������`�[���Ăяo���������z���C�����ۑ����s���ƁA�`�[�̖������z���Ԉ�����z�ŕ\�������</br>
        /// </remarks>
        private void SetUpdateDepositData1(UpdateMode updateMode, 
                                           string loginSectionCode, 
                                           string addSectionCode, 
                                           int customerCode, 
                                           int claimCode, 
                                           DataRow aftDepositRow, 
                                           ArrayList aftAllowanceRows, 
                                           DateTime depositDate,
                                           ref SearchDepsitMain depsitMain, 
                                           ref Hashtable htDepositAlw)
        {
            //==========================================//
            // ---            �����}�X�^            --- //
            //==========================================//

            depsitMain.AcptAnOdrStatus = (Int32)aftDepositRow[ctDepositAcptAnOdrStatus];                            // �󒍃X�e�[�^�X

            // �V�K�o�^�̎�
            if (updateMode == UpdateMode.Insert)
            {
                depsitMain.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;                                    // ��ƃR�[�h
                depsitMain.ClaimCode = claimCode;                                                                   // ������R�[�h
                depsitMain.ClaimName = this._depositCustomer.CName;                                                 // �����於1
                depsitMain.ClaimName2 = this._depositCustomer.CName2;                                               // �����於2
                depsitMain.ClaimSnm = this._depositCustomer.CSnm;                                                   // �����旪��
                depsitMain.CustomerCode = customerCode;                                                             // ���Ӑ�R�[�h
                depsitMain.CustomerName = this._depositCustomer.Name;                                               // ���Ӑ於1
                depsitMain.CustomerName2 = this._depositCustomer.Name2;                                             // ���Ӑ於2
                depsitMain.CustomerSnm = this._depositCustomer.CSnm;                                                // ���Ӑ旪��
                depsitMain.InputDepositSecCd = loginSectionCode;                                                    // �������͋��_�R�[�h
                depsitMain.AddUpSecCode = addSectionCode;                                                           // �v�㋒�_�R�[�h
                depsitMain.AcptAnOdrStatus = 30;
            }

            depsitMain.LogicalDeleteCode = 0;                                                                       // �_���폜�敪
            depsitMain.DepositDebitNoteCd = 0;                                                                      // �����ԍ��敪
            depsitMain.UpdateSecCd = loginSectionCode;                                                              // �X�V���_�R�[�h
            depsitMain.DepositDate = depositDate;                                                                   // �������t 
            depsitMain.AddUpADate = TDateTime.LongDateToDateTime((Int32)aftDepositRow[ctDepositAddUpADate]);        // �v����t
            depsitMain.DepositTotal = (Int64)aftDepositRow[ctDepositTotal];                                         // �����v
            depsitMain.Deposit = (Int64)aftDepositRow[ctDeposit];                                                   // ���� �����z
            depsitMain.FeeDeposit = (Int64)aftDepositRow[ctFeeDeposit];                                             // ���� �萔��
            depsitMain.DiscountDeposit = (Int64)aftDepositRow[ctDiscountDeposit];                                   // ���� �l��
            //depsitMain.DraftDrawingDate = TDateTime.LongDateToDateTime((Int32)aftDepositRow[ctDraftDrawingDate]);   // ��`�U�o��
            //depsitMain.DraftKind = (Int32)aftDepositRow[ctDraftKind];                                               // ��`���
            //depsitMain.DraftKindName = (String)aftDepositRow[ctDraftKindName];                                      // ��`��ޖ���
            //depsitMain.DraftDivide = (Int32)aftDepositRow[ctDraftDivide];                                           // ��`�敪
            //depsitMain.DraftDivideName = (String)aftDepositRow[ctDraftDivideName];                                  // ��`�敪����
            //depsitMain.DraftNo = (String)aftDepositRow[ctDraftNo];                                                  // ��`�ԍ�
            depsitMain.DebitNoteLinkDepoNo = 0;                                                                     // �ԍ������A���ԍ�
            depsitMain.SubSectionCode = GetSubSectionCode(LoginInfoAcquisition.Employee.EmployeeCode);
            depsitMain.DepositAgentCode = ((Employee)LoginInfoAcquisition.Employee).EmployeeCode;                   // �����S���҃R�[�h
            depsitMain.DepositAgentNm = ((Employee)LoginInfoAcquisition.Employee).Name;                             // �����S���Җ�
            //----- DEL 2012/09/21 �c���� redmine#32415 ---------->>>>>
            //depsitMain.DepositInputAgentCd = ((Employee)LoginInfoAcquisition.Employee).EmployeeCode;                // �������͎҃R�[�h
            //depsitMain.DepositInputAgentNm = ((Employee)LoginInfoAcquisition.Employee).Name;                        // �������͎Җ�
            //----- DEL 2012/09/21 �c���� redmine#32415 ----------<<<<<
            //----- ADD 2012/09/21 �c���� redmine#32415 ---------->>>>>
            depsitMain.DepositInputAgentCd = (String)aftDepositRow[ctDepositInputEmpCd];                            // �������͎҃R�[�h
            depsitMain.DepositInputAgentNm = (String)aftDepositRow[ctDepositInputEmpNm];                            // �������͎Җ�
            //----- ADD 2012/09/21 �c���� redmine#32415 ----------<<<<<
            depsitMain.Outline = (String)aftDepositRow[ctOutline];                                                  // �E�v
            //----- ADD K2013/03/22 ���� Redmine#35063 ----->>>>>
            if (this._opt_YamagataCtrl == (int)Option.ON)
            {
                // --- ADD K2012/07/13 ---------->>>>>
                depsitMain.BankCode = (Int32)aftDepositRow[ctBankCode];                                                 // ��s�R�[�h
                // --- ADD K2012/07/13 ----------<<<<<
            }
            //----- ADD K2013/03/22 ���� Redmine#35063 -----<<<<<
            //depsitMain.BankName = (String)aftDepositRow[ctBankName];                                                // ��s����
            depsitMain.DepositAllowance = (Int64)aftDepositRow[ctDepositAllowance_Deposit];                         // ���������z ����
            depsitMain.DepositAlwcBlnce = (Int64)aftDepositRow[ctDepositAlwcBlnce_Deposit];                         // ���������c ����
            depsitMain.DepositRowNo[0] = (Int32)aftDepositRow[ctDepositRowNo1];                                     // �����s�ԍ�1
            depsitMain.MoneyKindCode[0] = (Int32)aftDepositRow[ctMoneyKindCode1];                                   // ����R�[�h1
            depsitMain.MoneyKindName[0] = (String)aftDepositRow[ctMoneyKindName1];                                  // ���햼��1
            depsitMain.MoneyKindDiv[0] = (Int32)aftDepositRow[ctMoneyKindDiv1];                                     // ����敪1
            depsitMain.DepositDtl[0] = (Int64)aftDepositRow[ctDeposit1];                                            // �������z1
            depsitMain.ValidityTerm[0] = (DateTime)aftDepositRow[ctValidityTerm1];                                  // �L������1
            depsitMain.DepositRowNo[1] = (Int32)aftDepositRow[ctDepositRowNo2];                                     // �����s�ԍ�2
            depsitMain.MoneyKindCode[1] = (Int32)aftDepositRow[ctMoneyKindCode2];                                   // ����R�[�h2
            depsitMain.MoneyKindName[1] = (String)aftDepositRow[ctMoneyKindName2];                                  // ���햼��2
            depsitMain.MoneyKindDiv[1] = (Int32)aftDepositRow[ctMoneyKindDiv2];                                     // ����敪2
            depsitMain.DepositDtl[1] = (Int64)aftDepositRow[ctDeposit2];                                            // �������z2
            depsitMain.ValidityTerm[1] = (DateTime)aftDepositRow[ctValidityTerm2];                                  // �L������2
            depsitMain.DepositRowNo[2] = (Int32)aftDepositRow[ctDepositRowNo3];                                     // �����s�ԍ�3
            depsitMain.MoneyKindCode[2] = (Int32)aftDepositRow[ctMoneyKindCode3];                                   // ����R�[�h3
            depsitMain.MoneyKindName[2] = (String)aftDepositRow[ctMoneyKindName3];                                  // ���햼��3
            depsitMain.MoneyKindDiv[2] = (Int32)aftDepositRow[ctMoneyKindDiv3];                                     // ����敪3
            depsitMain.DepositDtl[2] = (Int64)aftDepositRow[ctDeposit3];                                            // �������z3
            depsitMain.ValidityTerm[2] = (DateTime)aftDepositRow[ctValidityTerm3];                                  // �L������3
            depsitMain.DepositRowNo[3] = (Int32)aftDepositRow[ctDepositRowNo4];                                     // �����s�ԍ�4
            depsitMain.MoneyKindCode[3] = (Int32)aftDepositRow[ctMoneyKindCode4];                                   // ����R�[�h4
            depsitMain.MoneyKindName[3] = (String)aftDepositRow[ctMoneyKindName4];                                  // ���햼��4
            depsitMain.MoneyKindDiv[3] = (Int32)aftDepositRow[ctMoneyKindDiv4];                                     // ����敪4
            depsitMain.DepositDtl[3] = (Int64)aftDepositRow[ctDeposit4];                                            // �������z4
            depsitMain.ValidityTerm[3] = (DateTime)aftDepositRow[ctValidityTerm4];                                  // �L������4
            depsitMain.DepositRowNo[4] = (Int32)aftDepositRow[ctDepositRowNo5];                                     // �����s�ԍ�5
            depsitMain.MoneyKindCode[4] = (Int32)aftDepositRow[ctMoneyKindCode5];                                   // ����R�[�h5
            depsitMain.MoneyKindName[4] = (String)aftDepositRow[ctMoneyKindName5];                                  // ���햼��5
            depsitMain.MoneyKindDiv[4] = (Int32)aftDepositRow[ctMoneyKindDiv5];                                     // ����敪5
            depsitMain.DepositDtl[4] = (Int64)aftDepositRow[ctDeposit5];                                            // �������z5
            depsitMain.ValidityTerm[4] = (DateTime)aftDepositRow[ctValidityTerm5];                                  // �L������5
            depsitMain.DepositRowNo[5] = (Int32)aftDepositRow[ctDepositRowNo6];                                     // �����s�ԍ�6
            depsitMain.MoneyKindCode[5] = (Int32)aftDepositRow[ctMoneyKindCode6];                                   // ����R�[�h6
            depsitMain.MoneyKindName[5] = (String)aftDepositRow[ctMoneyKindName6];                                  // ���햼��6
            depsitMain.MoneyKindDiv[5] = (Int32)aftDepositRow[ctMoneyKindDiv6];                                     // ����敪6
            depsitMain.DepositDtl[5] = (Int64)aftDepositRow[ctDeposit6];                                            // �������z6
            depsitMain.ValidityTerm[5] = (DateTime)aftDepositRow[ctValidityTerm6];                                  // �L������6
            depsitMain.DepositRowNo[6] = (Int32)aftDepositRow[ctDepositRowNo7];                                     // �����s�ԍ�7
            depsitMain.MoneyKindCode[6] = (Int32)aftDepositRow[ctMoneyKindCode7];                                   // ����R�[�h7
            depsitMain.MoneyKindName[6] = (String)aftDepositRow[ctMoneyKindName7];                                  // ���햼��7
            depsitMain.MoneyKindDiv[6] = (Int32)aftDepositRow[ctMoneyKindDiv7];                                     // ����敪7
            depsitMain.DepositDtl[6] = (Int64)aftDepositRow[ctDeposit7];                                            // �������z7
            depsitMain.ValidityTerm[6] = (DateTime)aftDepositRow[ctValidityTerm7];                                  // �L������7
            depsitMain.DepositRowNo[7] = (Int32)aftDepositRow[ctDepositRowNo8];                                     // �����s�ԍ�8
            depsitMain.MoneyKindCode[7] = (Int32)aftDepositRow[ctMoneyKindCode8];                                   // ����R�[�h8
            depsitMain.MoneyKindName[7] = (String)aftDepositRow[ctMoneyKindName8];                                  // ���햼��8
            depsitMain.MoneyKindDiv[7] = (Int32)aftDepositRow[ctMoneyKindDiv8];                                     // ����敪8
            depsitMain.DepositDtl[7] = (Int64)aftDepositRow[ctDeposit8];                                            // �������z8
            depsitMain.ValidityTerm[7] = (DateTime)aftDepositRow[ctValidityTerm8];                                  // �L������8
            depsitMain.DepositRowNo[8] = (Int32)aftDepositRow[ctDepositRowNo9];                                     // �����s�ԍ�9
            depsitMain.MoneyKindCode[8] = (Int32)aftDepositRow[ctMoneyKindCode9];                                   // ����R�[�h9
            depsitMain.MoneyKindName[8] = (String)aftDepositRow[ctMoneyKindName9];                                  // ���햼��9
            depsitMain.MoneyKindDiv[8] = (Int32)aftDepositRow[ctMoneyKindDiv9];                                     // ����敪9
            depsitMain.DepositDtl[8] = (Int64)aftDepositRow[ctDeposit9];                                            // �������z9
            depsitMain.ValidityTerm[8] = (DateTime)aftDepositRow[ctValidityTerm9];                                  // �L������9
            depsitMain.DepositRowNo[9] = (Int32)aftDepositRow[ctDepositRowNo10];                                     // �����s�ԍ�10
            depsitMain.MoneyKindCode[9] = (Int32)aftDepositRow[ctMoneyKindCode10];                                   // ����R�[�h10
            depsitMain.MoneyKindName[9] = (String)aftDepositRow[ctMoneyKindName10];                                  // ���햼��10
            depsitMain.MoneyKindDiv[9] = (Int32)aftDepositRow[ctMoneyKindDiv10];                                     // ����敪10
            depsitMain.DepositDtl[9] = (Int64)aftDepositRow[ctDeposit10];                                            // �������z10
            depsitMain.ValidityTerm[9] = (DateTime)aftDepositRow[ctValidityTerm10];                                  // �L������10
            depsitMain.InputDay = DateTime.Today;
            //==========================================//
            // ---     ���������}�X�^ �V�K/�X�V     --- //
            //==========================================//
            UpdateMode allowanceUpdateMode = 0;
            foreach (DataRow dr in aftAllowanceRows)
            {
                // ���ꔄ��ԍ��̈������擾
                SearchDepositAlw depositAlw = (SearchDepositAlw)htDepositAlw[(String)dr[ctSalesSlipNum_Alw]];

                // �n�b�V���e�[�u���ɖ������͐V�K����
                if (depositAlw == null)
                {
                    // �V�K���[�h
                    allowanceUpdateMode = UpdateMode.Insert;
                    depositAlw = new SearchDepositAlw();
                    htDepositAlw.Add((String)dr[ctSalesSlipNum_Alw], depositAlw);
                }
                else
                {
                    // �ȉ��̍��ڂ��ς��Ȃ���
                    // 1.�ԓ`���E�敪, 2.�����ݓ�, 6.�����݌v���, 7.�����z
                    if ((depositAlw.DebitNoteOffSetCd == depsitMain.DepositDebitNoteCd) &&
                        (depositAlw.ReconcileDate == TDateTime.LongDateToDateTime((Int32)dr[ctReconcileDate])) &&
                        (depositAlw.ReconcileAddUpDate == TDateTime.LongDateToDateTime((Int32)dr[ctReconcileAddUpDate])) &&
                        (depositAlw.DepositAllowance == (Int64)dr[ctDepositAllowance]))
                    {
                        // �ύX�����̓n�b�V���e�[�u�����폜
                        htDepositAlw.Remove((String)dr[ctSalesSlipNum_Alw]);
                        continue;
                    }

                    // �X�V���[�h
                    allowanceUpdateMode = UpdateMode.Update;
                }

                // �V�K�o�^�̎�
                if (allowanceUpdateMode == UpdateMode.Insert)
                {
                    depositAlw.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;                                // ��ƃR�[�h
                    depositAlw.ClaimCode = depsitMain.ClaimCode;                                                    // ������R�[�h
                    depositAlw.ClaimName = depsitMain.ClaimName;                                                    // �����於1
                    depositAlw.ClaimName2 = depsitMain.ClaimName2;                                                  // �����於2
                    depositAlw.ClaimSnm = depsitMain.ClaimSnm;                                                      // �����旪��
                    depositAlw.CustomerCode = depsitMain.CustomerCode;                                              // ���Ӑ�R�[�h
                    depositAlw.CustomerName = depsitMain.CustomerName;                                              // ���Ӑ於1
                    depositAlw.CustomerName2 = depsitMain.CustomerName2;                                            // ���Ӑ於2
                    depositAlw.CustomerSnm = depsitMain.CustomerSnm;                                                // ���Ӑ旪��
                    depositAlw.AddUpSecCode = depsitMain.AddUpSecCode;                                              // �v�㋒�_�R�[�h
                    depositAlw.InputDepositSecCd = depsitMain.InputDepositSecCd;                                    // �������͋��_�R�[�h
                    depositAlw.DepositSlipNo = depsitMain.DepositSlipNo;                                            // �����ԍ�
                }

                depositAlw.AcptAnOdrStatus = (Int32)dr[ctAcptAnOdrStatus_Alw];                                      // �󒍃X�e�[�^�X
                depositAlw.SalesSlipNum = (String)dr[ctSalesSlipNum_Alw];                                           // ����`�[�ԍ�

                // �ύX�O�����z
                long bfDepositAllowance = depositAlw.DepositAllowance;

                depositAlw.DepositAllowance = (Int64)dr[ctDepositAllowance];                                        // ���������z ����

                // --- DEL 2015/07/16 y.wakita ���C�����ԍH�Ɖۑ�Ή��ꗗ��1 ������Q�B ----------------------------------------->>>>>
                #region �폜
                //if (allowanceUpdateMode == UpdateMode.Insert)
                //{
                //    //depsitMain.DepositAllowance += depositAlw.DepositAllowance; // DEL 2013/01/31 �c���� Redmine#34506
                //}
                //else
                //{
                //    depsitMain.DepositAllowance += (depositAlw.DepositAllowance - bfDepositAllowance);
                //}
                #endregion �폜
                // --- DEL 2015/07/16 y.wakita ���C�����ԍH�Ɖۑ�Ή��ꗗ��1 ������Q�B -----------------------------------------<<<<<
                
                depositAlw.ReconcileDate = TDateTime.LongDateToDateTime((Int32)dr[ctReconcileDate]);                // �������i�������j
                depositAlw.ReconcileAddUpDate = TDateTime.LongDateToDateTime((Int32)dr[ctReconcileAddUpDate]);      // �����v����t�i�����݌v����j
                depositAlw.DepositAgentCode = depsitMain.DepositAgentCode;                                          // �����S���҃R�[�h
                depositAlw.DepositAgentNm = depsitMain.DepositAgentNm;                                              // �����S���Җ�
                depositAlw.DebitNoteOffSetCd = depsitMain.DepositDebitNoteCd;                                       // �ԓ`���E�敪
            }

            depsitMain.DepositAlwcBlnce = depsitMain.Deposit - depsitMain.DepositAllowance;

            // --- ���������}�X�^ �폜 --- //
            foreach (DictionaryEntry myDE in htDepositAlw)
            {
                SearchDepositAlw depositAlw = (SearchDepositAlw)myDE.Value;
                allowanceUpdateMode = UpdateMode.Delete;
                foreach (DataRow dr in aftAllowanceRows)
                {
                    if (depositAlw.SalesSlipNum == Convert.ToString(dr[ctSalesSlipNum_Alw]))
                    {
                        allowanceUpdateMode = UpdateMode.Update;
                        break;
                    }
                }

                // DataRow�Ƀn�b�V���e�[�u���̃��R�[�h���������͍폜���ꂽ�Ƃ݂Ȃ�
                if (allowanceUpdateMode == UpdateMode.Delete)
                {
                    depositAlw.LogicalDeleteCode = 1;
                }
            }
        }

		/// <summary>
		/// �����}�X�^�������}�X�^���ڃZ�b�g����
		/// </summary>
		/// <param name="depsitMain">�����}�X�^(�ύX���e)</param>
		/// <param name="htDepositAlw">���������}�X�^(�ύX���e)</param>
		/// <remarks>
		/// <br>Note       : ���������}�X�^�Ǎ���/�X�V�p�����ɍX�V���ڂ�����}�X�^�ɃZ�b�g���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SetUpdateDepositData2(ref SearchDepsitMain depsitMain, Hashtable htDepositAlw)
		{
			// �Ǎ��������}�X�^�E���������}�X�^�擾����
			SearchDepsitMain readDepsitMain;
			Hashtable readDepositAlw;
			if (depsitMain.DepositSlipNo == 0)
			{
				readDepositAlw = new Hashtable();
			}
			else
			{
				this.GetBeforeDepositData(depsitMain.DepositSlipNo, out readDepsitMain, out readDepositAlw);
			}

			// ���������f�[�^�̓Ǎ����f�[�^�ɍX�V�p�f�[�^�����Ԃ���
			foreach (DictionaryEntry myDE in htDepositAlw)
			{
				// �X�V���̎擾
				SearchDepositAlw depositAlw1 = (SearchDepositAlw)myDE.Value;

                // �Ǎ������e�̎擾
				// SearchDepositAlw depositAlw2 = (SearchDepositAlw)readDepositAlw[depositAlw1.AcceptAnOrderNo];  // 2007.10.05 del
                SearchDepositAlw depositAlw2 = (SearchDepositAlw)readDepositAlw[depositAlw1.SalesSlipNum];        // 2007.10.05 add

   				// �V�K�����̎�
				if (depositAlw2 == null)
				{
					// readDepositAlw.Add(depositAlw1.AcceptAnOrderNo, depositAlw1);    // 2007.10.05 del
                    readDepositAlw.Add(depositAlw1.SalesSlipNum, depositAlw1);          // 2007.10.05 add
                }
			}

			// �}�[�W�f�[�^(�X�V��̃C���[�W)�̒�������
			DateTime reconcileAddUpDate = DateTime.MinValue;

            // int acceptAnOrderSalesNo = 0;         // 2007.10.05 del
            Int32[] acptAnOdrStatus = new Int32[1];  // 2007.10.05 add
            int index = 0;
            acptAnOdrStatus[index] = 0;
            string salesSlipNum = string.Empty;      // 2007.10.05 add

   			foreach (DictionaryEntry myDE in readDepositAlw)
			{
				SearchDepositAlw depositAlw = (SearchDepositAlw)myDE.Value;

				// �폜�f�[�^�ł͖�����
				if (depositAlw.LogicalDeleteCode == 0)
				{
                    // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                    //// �󒍓`�[�ԍ�  ��������/�a����̎��̂ݎ擾
                    //if ((depsitMain.DepositCd == 1) || (depsitMain.AutoDepositCd == 1))
                    // �󒍓`�[�ԍ��@���������̎��̂ݎ擾
                    if (depsitMain.AutoDepositCd == 1)
                    // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<					
                    {
						// ������󒍓`�[�̃`�F�b�N����
						// �������悪���̎��̂ݔԍ����Z�b�g
						// �����������Ɨa����̎��́A�P�������P��(��)�̊֌W�Ȃ̂ŁB�@�������t�́A�P�󒍁��m�����ɂȂ�B
						// �����̃��W�b�N���K�v�ɂȂ�P�[�X(�菇)��
						//   1.����(��)<-->��(��)����
						//   2.�󒍂�ԓ`�ɂ���
						//   3.����(��)��ʂ̎�(��)�Ɉ���
						//   4.��ʂ��N�����Ȃ����āA����(��)���ďo���X�V�B���̎��A��(��)����ʏ�W�J����ĂȂ���
						string message;

						// int st = this.CheackAllowanceSalese(0, depositAlw.AcceptAnOrderNo, depsitMain.EnterpriseCode, depsitMain.AddUpSecCode, depsitMain.CustomerCode, out message); // 2007.10.05 del
                        int st = this.CheackAllowanceSalese(0, depositAlw.SalesSlipNum, depsitMain.EnterpriseCode, depsitMain.AddUpSecCode, depsitMain.CustomerCode, depsitMain.ClaimCode, acptAnOdrStatus, out message);       // 2007.10.05 add

                        // �G���[�̎��͗�O�𔭐�������
						if ((st != 0) && (st != 2))
						{
							throw new DepositException(message, st);
						}
						if (st == 2)
						{
							// acceptAnOrderSalesNo = depositAlw.AcceptAnOrderNo;   // 2007.10.05 del
                            acptAnOdrStatus[index] = depositAlw.AcptAnOdrStatus;    // 2007.10.05 add
                            salesSlipNum = depositAlw.SalesSlipNum;                 // 2007.10.05 add
   						}
					}

					// ��Ԗ����̍ŏI�����v������擾
					if (depositAlw.ReconcileAddUpDate > reconcileAddUpDate)
						reconcileAddUpDate = depositAlw.ReconcileAddUpDate;
				}
			}

			// �󒍓`�[�ԍ�
			// depsitMain.AcceptAnOrderNo = acceptAnOrderSalesNo;  // 2007.10.05 del

            //depsitMain.AcptAnOdrStatus = acptAnOdrStatus[index];   // 2007.10.05 add

            // ����`�[�ԍ�
            depsitMain.SalesSlipNum = salesSlipNum;                // 2007.10.05 add

			// �ŏI�����v���
			depsitMain.LastReconcileAddUpDt = reconcileAddUpDate;
		}
		
		/// <summary>
		/// �����}�X�^�E���������}�X�^�폜���e�Z�b�g����
		/// </summary>
		/// <param name="depsitMain">�����}�X�^</param>
		/// <param name="htDepositAlw">���������}�X�^</param>
		/// <remarks>
		/// <br>Note       : �����}�X�^/���������}�X�^���폜�f�[�^�Ƃ��܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void SetDeleteDepositData(ref SearchDepsitMain depsitMain, ref Hashtable htDepositAlw)
		{
			// �����f�[�^�̘_���폜
			depsitMain.LogicalDeleteCode = 1;

			// ���������f�[�^�̘_���폜
			foreach (DictionaryEntry de in htDepositAlw)
			{
				((SearchDepositAlw)de.Value).LogicalDeleteCode = 1;
			}
        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �����f�[�^�X�V����
		/// </summary>
		/// <param name="depsitMainWork">�����}�X�^(�X�V�p)</param>
		/// <param name="depositAlwWorkList">���������}�X�^(�X�V�p)</param>
		/// <remarks>
		/// <br>Note       : �����}�X�^/���������}�X�^�̍X�V���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void WriteDeposit(ref DepsitMainWork depsitMainWork, ref DepositAlwWork[] depositAlwWorkList)
		{
			string message = "";
			int st = 0;

            st = _depsitMainAcs.WriteDB(ref depsitMainWork, ref depositAlwWorkList, out message);

			// �G���[�̎��͗�O�𔭐�������
			if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				throw new DepositException(message, st);
			}
		}
        
        /// <summary>
		/// �����f�[�^�폜����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="depositSlipNo">�����`�[�ԍ�</param>
		/// <remarks>
		/// <br>Note       : �����}�X�^/���������}�X�^�̍폜���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void DeleteDeposit(string enterpriseCode, int depositSlipNo)
		{
			string message;
			int st;

			st = _depsitMainAcs.DeleteDB(enterpriseCode, depositSlipNo, out message);

			// �G���[�̎��͗�O�𔭐�������
			if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				throw new DepositException(message, st);
			}
		}

		/// <summary>
		/// �����f�[�^�X�V����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="depositSlipNo">�����`�[�ԍ�</param>
		/// <param name="depsitMainWork">�����}�X�^(�X�V����(�ԍ��̍�))</param>
		/// <param name="depositAlwWorkList">���������}�X�^(�X�V����(�ԍ��̍�))</param>
		/// <remarks>
		/// <br>Note       : �����}�X�^/���������}�X�^�̍폜���s���܂��B
		///                  �Ԃ��폜�������ɂ͌��т����̍X�V���ʂ��Ԃ�܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void DeleteDeposit(string enterpriseCode, int depositSlipNo, out DepsitMainWork depsitMainWork, out DepositAlwWork[] depositAlwWorkList)
		{
			string message = "";
			int st = 0;

            depsitMainWork = new DepsitMainWork();
            depositAlwWorkList = new DepositAlwWork[1];
            st = _depsitMainAcs.DeleteDB(enterpriseCode, depositSlipNo, out depsitMainWork, out depositAlwWorkList, out message);

			// �G���[�̎��͗�O�𔭐�������
			if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				throw new DepositException(message, st);
			}
		}

        /// <summary>
        /// �����f�[�^�X�V����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="depositSlipNo">�����`�[�ԍ�</param>
        /// <param name="depsitDataWork">�����}�X�^(�X�V����(�ԍ��̍�))</param>
        /// <param name="depositAlwWorkList">���������}�X�^(�X�V����(�ԍ��̍�))</param>
        /// <remarks>
        /// <br>Note       : �����}�X�^/���������}�X�^�̍폜���s���܂��B
        ///                  �Ԃ��폜�������ɂ͌��т����̍X�V���ʂ��Ԃ�܂��B</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        private void DeleteDeposit(string enterpriseCode, int depositSlipNo, out DepsitDataWork depsitDataWork, out DepositAlwWork[] depositAlwWorkList)
        {
            string message = "";
            int st = 0;

            depsitDataWork = new DepsitDataWork();
            depositAlwWorkList = new DepositAlwWork[1];
            st = _depsitMainAcs.DeleteDB(enterpriseCode, depositSlipNo, out depsitDataWork, out depositAlwWorkList, out message);

            // �G���[�̎��͗�O�𔭐�������
            if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                throw new DepositException(message, st);
            }
        }

		/// <summary>
		/// �ԓ����f�[�^�쐬����
		/// </summary>
		/// <param name="mode">�ԓ`�쐬���[�h  0:�ԓ����쐬, 1:�ԓ����E�V�������쐬</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="updateSecCd">�X�V���_�R�[�h</param>
		/// <param name="depositAgentCode">�����S���҃R�[�h</param>
		/// <param name="depositAgentNm">�����S���Җ�</param>
		/// <param name="addUpADate">�v���</param>
		/// <param name="depositSlipNo">�����ԍ�</param>
		/// <param name="akaDepositCd">�V�ԓ`�̗a����敪</param>
		/// <param name="depsitMainWorkList">�����}�X�^(�X�V����)</param>
		/// <param name="depositAlwWorkList">�����}�X�^(�X�V����)</param>
		/// <remarks>
		/// <br>Note       : �����}�X�^/���������}�X�^�̍X�V���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		// �� 20070125 18322 c MA.NS�p�ɕύX
        //private void WriteAkaDeposit(int mode, string enterpriseCode, string updateSecCd, string depositAgentCode, int addUpADate, int akaDepositCd, int depositSlipNo, out DepsitMainWork[] depsitMainWorkList, out DepositAlwWork[] depositAlwWorkList)
        private void WriteAkaDeposit(int mode, string enterpriseCode, string updateSecCd, string depositAgentCode, string depositAgentNm, int addUpADate, int akaDepositCd, int depositSlipNo, out DepsitMainWork[] depsitMainWorkList, out DepositAlwWork[] depositAlwWorkList)
        // �� 20070125 18322 c
		{
			string message = "";
			int st = 0;

            // �� 20070125 18322 c MA.NS�p�ɕύX
			//// �ԓ����쐬����
			//st = _depsitMainAcs.RedCreate(mode, enterpriseCode, akaDepositCd, updateSecCd, depositAgentCode, TDateTime.LongDateToDateTime(addUpADate), depositSlipNo, out depsitMainWorkList, out depositAlwWorkList, out message);

			// �ԓ����쐬����
            depsitMainWorkList = new DepsitMainWork[1];
            depositAlwWorkList = new DepositAlwWork[1];
            st = _depsitMainAcs.RedCreate(mode
                                         , enterpriseCode
                                         , akaDepositCd
                                         , updateSecCd
                                         , depositAgentCode
                                         , depositAgentNm
                                         , TDateTime.LongDateToDateTime(addUpADate)
                                         , depositSlipNo
                                         , out depsitMainWorkList
                                         , out depositAlwWorkList
                                         , out message
                                         );
            // �� 20070125 18322 c

			// �G���[�̎��͗�O�𔭐�������
			if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				throw new DepositException(message, st);
			}
		}

        /// <summary>
        /// �ԓ����f�[�^�쐬����
        /// </summary>
        /// <param name="mode">�ԓ`�쐬���[�h  0:�ԓ����쐬, 1:�ԓ����E�V�������쐬</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="updateSecCd">�X�V���_�R�[�h</param>
        /// <param name="depositAgentCode">�����S���҃R�[�h</param>
        /// <param name="depositAgentNm">�����S���Җ�</param>
        /// <param name="addUpADate">�v���</param>
        /// <param name="depositSlipNo">�����ԍ�</param>
        /// <param name="akaDepositCd">�V�ԓ`�̗a����敪</param>
        /// <param name="depsitDataWorkList">�����}�X�^(�X�V����)</param>
        /// <param name="depositAlwWorkList">�����}�X�^(�X�V����)</param>
        /// <remarks>
        /// <br>Note       : �����}�X�^/���������}�X�^�̍X�V���s���܂��B</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        private void WriteAkaDeposit(int mode, string enterpriseCode, string updateSecCd, string depositAgentCode, string depositAgentNm, int addUpADate, int akaDepositCd, int depositSlipNo, out DepsitDataWork[] depsitDataWorkList, out DepositAlwWork[] depositAlwWorkList)
        {
            string message = "";
            int st = 0;

            // �ԓ����쐬����
            depsitDataWorkList = new DepsitDataWork[1];
            depositAlwWorkList = new DepositAlwWork[1];
            st = _depsitMainAcs.RedCreate(mode
                                         , enterpriseCode
                                         , akaDepositCd
                                         , updateSecCd
                                         , depositAgentCode
                                         , depositAgentNm
                                         , TDateTime.LongDateToDateTime(addUpADate)
                                         , depositSlipNo
                                         , out depsitDataWorkList
                                         , out depositAlwWorkList
                                         , out message
                                         );

            // �G���[�̎��͗�O�𔭐�������
            if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                throw new DepositException(message, st);
            }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        /// <summary>
		/// �N���X�����o�[�R�s�[�����iKINGET�p���Ӑ搿�����z���[�N�N���X�˓������Ӑ���N���X�j
		/// </summary>
		/// <param name="kingetCustDmdPrcWork">KINGET�p���Ӑ搿�����z���[�N�N���X</param>
		/// <returns>���Ӑ搿���N���X</returns>
		/// <remarks>
		/// <br>Note       : KINGET�p���Ӑ搿�����z���[�N�N���X����������Ӑ���N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private DepositCustomer CopyToDepositCustomerFromKingetCustDmdPrcWork(KingetCustDmdPrcWork kingetCustDmdPrcWork)
		{
			DepositCustomer depositCustomer = new DepositCustomer();

			// ���Ӑ���Z�b�g
            depositCustomer.ClaimCode           = kingetCustDmdPrcWork.ClaimCode;           // ������R�[�h
            depositCustomer.CName               = kingetCustDmdPrcWork.ClaimName;           // �����於�̂P
            depositCustomer.CName2              = kingetCustDmdPrcWork.ClaimName2;          // �����於�̂Q
            depositCustomer.CSnm                = kingetCustDmdPrcWork.ClaimSnm;            // �����旪��
			depositCustomer.CustomerCode		= kingetCustDmdPrcWork.CustomerCode;		// ���Ӑ�R�[�h
			depositCustomer.Name				= kingetCustDmdPrcWork.CustomerName;		// ���Ӑ於�̂P
			depositCustomer.Name2				= kingetCustDmdPrcWork.CustomerName2;		// ���Ӑ於�̂Q
            depositCustomer.SNm                 = kingetCustDmdPrcWork.CustomerSnm;         // ���Ӑ旪�� 
            depositCustomer.HonorificTitle		= kingetCustDmdPrcWork.HonorificTitle;		// �h��
			depositCustomer.TotalDay			= kingetCustDmdPrcWork.TotalDay;			// ����
			depositCustomer.CollectMoneyName	= kingetCustDmdPrcWork.CollectMoneyName;	// �W�����敪����
			depositCustomer.CollectMoneyDay		= kingetCustDmdPrcWork.CollectMoneyDay;		// �W����
            depositCustomer.CAddUpUpdDate       = TDateTime.DateTimeToLongDate(kingetCustDmdPrcWork.LastCAddUpUpdDate);   // �O������X�V�N����

			return depositCustomer;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iKINGET�p���Ӑ搿�����z���[�N�˓������Ӑ搿�����z���j
        /// </summary>
        /// <param name="kingetCustDmdPrcWork">KINGET�p���Ӑ搿�����z���[�N�N���X</param>
        /// <returns>���Ӑ搿���N���X</returns>
        /// <remarks>
        /// <br>Note       : KINGET�p���Ӑ搿�����z���[�N�N���X����������Ӑ搿�����z���N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private DepositCustDmdPrc CopyToDepositCustDmdPrcFromKingetCustDmdPrcWork(KingetCustDmdPrcWork kingetCustDmdPrcWork)
        {
            DepositCustDmdPrc depositCustDmdPrc = new DepositCustDmdPrc();

            depositCustDmdPrc.AddUpSecCode = kingetCustDmdPrcWork.AddUpSecCode;             // �v�㋒�_�R�[�h
            depositCustDmdPrc.ClaimCode = kingetCustDmdPrcWork.ClaimCode;                   // ������R�[�h
            depositCustDmdPrc.CustomerCode = kingetCustDmdPrcWork.CustomerCode;             // ���Ӑ�R�[�h
            depositCustDmdPrc.AddUpDate = kingetCustDmdPrcWork.AddUpDate;                   // �v��N����
            depositCustDmdPrc.StartDateSpan = kingetCustDmdPrcWork.StartDateSpan;           // �͈͓��t�i�J�n�j
            depositCustDmdPrc.EndDateSpan = kingetCustDmdPrcWork.EndDateSpan;               // �͈͓��t�i�I���j
            depositCustDmdPrc.LastTimeDemand = kingetCustDmdPrcWork.LastTimeDemand;         // �O�񐿋����z
            depositCustDmdPrc.AcpOdrTtl2TmBfBlDmd = kingetCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd;
            depositCustDmdPrc.AcpOdrTtl3TmBfBlDmd = kingetCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd;
            depositCustDmdPrc.ThisTimeDmdNrml = kingetCustDmdPrcWork.ThisTimeDmdNrml;       // ����������z�i�ʏ�����j
            depositCustDmdPrc.ThisTimeFeeDmdNrml = kingetCustDmdPrcWork.ThisTimeFeeDmdNrml; // ����萔���z�i�ʏ�����j
            depositCustDmdPrc.ThisTimeDisDmdNrml = kingetCustDmdPrcWork.ThisTimeDisDmdNrml; // ����l���z�i�ʏ�����j
            depositCustDmdPrc.ThisTimeTtlBlcDmd = kingetCustDmdPrcWork.ThisTimeTtlBlcDmd;   // ����J�z�c���i�����v�j
            depositCustDmdPrc.ThisTimeSales = kingetCustDmdPrcWork.ThisTimeSales;           // ���񔄏���z
            depositCustDmdPrc.ThisSalesTax = kingetCustDmdPrcWork.ThisSalesTax;             // ���񔄏�����
            depositCustDmdPrc.OfsThisTimeSales = kingetCustDmdPrcWork.OfsThisTimeSales;     // ���E�㍡�񔄏���z
            depositCustDmdPrc.OfsThisSalesTax = kingetCustDmdPrcWork.OfsThisSalesTax;       // ���E�㍡�񔄏�����
            depositCustDmdPrc.AfCalDemandPrice = kingetCustDmdPrcWork.AfCalDemandPrice;     // �v�Z�㐿�����z
            depositCustDmdPrc.ThisTimeDmdNrmlTtl = depositCustDmdPrc.ThisTimeDmdNrml;       // ��������v�i�ʏ�����j
            depositCustDmdPrc.ThisTimeDmdTtl = depositCustDmdPrc.ThisTimeDmdNrmlTtl;        // ��������v
            depositCustDmdPrc.LastCAddUpUpdDate = kingetCustDmdPrcWork.LastCAddUpUpdDate;   // �O������X�V�N����
            depositCustDmdPrc.CAddUpUpdExecDate = kingetCustDmdPrcWork.CAddUpUpdExecDate;   // �����X�V���s�N����
            depositCustDmdPrc.StartCAddUpUpdDate = kingetCustDmdPrcWork.StartCAddUpUpdDate; // �����X�V�J�n�N����

            return depositCustDmdPrc;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�����}�X�^���[�N�˓����}�X�^�j
        /// </summary>
        /// <param name="depsitDataWork">�����}�X�^���[�N�N���X</param>
        /// <returns>�����}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^���[�N�N���X��������}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private ArrayList CopyToDepsitMainFromDepsitDataWork(DepsitDataWork depsitDataWork)
        {
            ArrayList depsitDataList = new ArrayList();

            SearchDepsitMain depsitMain = new SearchDepsitMain();

            depsitMain.CreateDateTime = depsitDataWork.CreateDateTime;              // �쐬����
            depsitMain.UpdateDateTime = depsitDataWork.UpdateDateTime;              // �X�V����
            depsitMain.EnterpriseCode = depsitDataWork.EnterpriseCode;              // ��ƃR�[�h
            depsitMain.FileHeaderGuid = depsitDataWork.FileHeaderGuid;              // GUID
            depsitMain.UpdEmployeeCode = depsitDataWork.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
            depsitMain.UpdAssemblyId1 = depsitDataWork.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
            depsitMain.UpdAssemblyId2 = depsitDataWork.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
            depsitMain.LogicalDeleteCode = depsitDataWork.LogicalDeleteCode;        // �_���폜�敪
            depsitMain.DepositDebitNoteCd = depsitDataWork.DepositDebitNoteCd;      // �����ԍ��敪
            depsitMain.DepositSlipNo = depsitDataWork.DepositSlipNo;                // �����`�[�ԍ�
            depsitMain.AcptAnOdrStatus = depsitDataWork.AcptAnOdrStatus;            // �󒍃X�e�[�^�X
            depsitMain.SalesSlipNum = depsitDataWork.SalesSlipNum;                  // ����`�[�ԍ� 
            depsitMain.InputDepositSecCd = depsitDataWork.InputDepositSecCd;        // �������͋��_�R�[�h
            depsitMain.AddUpSecCode = depsitDataWork.AddUpSecCode;                  // �v�㋒�_�R�[�h
            depsitMain.UpdateSecCd = depsitDataWork.UpdateSecCd;                    // �X�V���_�R�[�h
            depsitMain.DepositDate = depsitDataWork.DepositDate;                    // �������t
            depsitMain.AddUpADate = depsitDataWork.AddUpADate;                      // �v����t
            depsitMain.Deposit = depsitDataWork.Deposit;
            depsitMain.FeeDeposit = depsitDataWork.FeeDeposit;                      // �萔�������z
            depsitMain.DiscountDeposit = depsitDataWork.DiscountDeposit;            // �l�������z
            depsitMain.AutoDepositCd = depsitDataWork.AutoDepositCd;                // ���������敪
            depsitMain.DraftDrawingDate = depsitDataWork.DraftDrawingDate;          // ��`�U�o��
            depsitMain.DebitNoteLinkDepoNo = depsitDataWork.DebitNoteLinkDepoNo;    // �ԍ������A���ԍ�
            depsitMain.LastReconcileAddUpDt = depsitDataWork.LastReconcileAddUpDt;  // �ŏI�������݌v���
            depsitMain.DepositAgentCode = depsitDataWork.DepositAgentCode;          // �����S���҃R�[�h
            depsitMain.DepositAgentNm = depsitDataWork.DepositAgentNm;              // �����S���Җ���
            depsitMain.ClaimCode = depsitDataWork.ClaimCode;                        // ������R�[�h
            depsitMain.ClaimName = depsitDataWork.ClaimName;                        // �����於��
            depsitMain.ClaimName2 = depsitDataWork.ClaimName2;                      // �����於��2
            depsitMain.ClaimSnm = depsitDataWork.ClaimSnm;                          // �����旪��
            depsitMain.CustomerCode = depsitDataWork.CustomerCode;                  // ���Ӑ�R�[�h
            depsitMain.CustomerName = depsitDataWork.CustomerName;                  // ���Ӑ於��
            depsitMain.CustomerName2 = depsitDataWork.CustomerName2;                // ���Ӑ於��2
            depsitMain.CustomerSnm = depsitDataWork.CustomerSnm;                    // ���Ӑ旪��
            depsitMain.Outline = depsitDataWork.Outline;                            // �`�[�E�v
            depsitMain.BankCode = depsitDataWork.BankCode;                          // ��s�R�[�h
            depsitMain.BankName = depsitDataWork.BankName;                          // ��s����
            depsitMain.DraftNo = depsitDataWork.DraftNo;                            // ��`�ԍ�
            depsitMain.DraftKind = depsitDataWork.DraftKind;                        // ��`���
            depsitMain.DraftKindName = depsitDataWork.DraftKindName;                // ��`��ޖ���
            depsitMain.DraftDivide = depsitDataWork.DraftDivide;                    // ��`�敪
            depsitMain.DraftDivideName = depsitDataWork.DraftDivideName;            // ��`�敪����
            if (depsitMain.AutoDepositCd == 0)
            {
                depsitMain.DepositNm = "�ʏ����";                                      // �a������敪����
            }
            else
            {
                depsitMain.DepositNm = "��������";                                      // �a������敪����
            }
            depsitMain.DepositAllowance = depsitDataWork.DepositAllowance;          // ���������z
            depsitMain.DepositAlwcBlnce = depsitDataWork.DepositAlwcBlnce;          // ���������c��
            depsitMain.DepositRowNo[0] = depsitDataWork.DepositRowNo1;              // �����s�ԍ�1
            depsitMain.MoneyKindCode[0] = depsitDataWork.MoneyKindCode1;            // ����R�[�h1
            depsitMain.MoneyKindName[0] = depsitDataWork.MoneyKindName1;            // ���햼��1
            depsitMain.MoneyKindDiv[0] = depsitDataWork.MoneyKindDiv1;              // ����敪1
            depsitMain.DepositDtl[0] = depsitDataWork.Deposit1;                     // �������z1
            depsitMain.ValidityTerm[0] = depsitDataWork.ValidityTerm1;              // �L������1
            depsitMain.DepositRowNo[1] = depsitDataWork.DepositRowNo2;              // �����s�ԍ�2
            depsitMain.MoneyKindCode[1] = depsitDataWork.MoneyKindCode2;            // ����R�[�h2
            depsitMain.MoneyKindName[1] = depsitDataWork.MoneyKindName2;            // ���햼��2
            depsitMain.MoneyKindDiv[1] = depsitDataWork.MoneyKindDiv2;              // ����敪2
            depsitMain.DepositDtl[1] = depsitDataWork.Deposit2;                     // �������z2
            depsitMain.ValidityTerm[1] = depsitDataWork.ValidityTerm2;              // �L������2
            depsitMain.DepositRowNo[2] = depsitDataWork.DepositRowNo3;              // �����s�ԍ�3
            depsitMain.MoneyKindCode[2] = depsitDataWork.MoneyKindCode3;            // ����R�[�h3
            depsitMain.MoneyKindName[2] = depsitDataWork.MoneyKindName3;            // ���햼��3
            depsitMain.MoneyKindDiv[2] = depsitDataWork.MoneyKindDiv3;              // ����敪3
            depsitMain.DepositDtl[2] = depsitDataWork.Deposit3;                     // �������z3
            depsitMain.ValidityTerm[2] = depsitDataWork.ValidityTerm3;              // �L������3
            depsitMain.DepositRowNo[3] = depsitDataWork.DepositRowNo4;              // �����s�ԍ�4
            depsitMain.MoneyKindCode[3] = depsitDataWork.MoneyKindCode4;            // ����R�[�h4
            depsitMain.MoneyKindName[3] = depsitDataWork.MoneyKindName4;            // ���햼��4
            depsitMain.MoneyKindDiv[3] = depsitDataWork.MoneyKindDiv4;              // ����敪4
            depsitMain.DepositDtl[3] = depsitDataWork.Deposit4;                     // �������z4
            depsitMain.ValidityTerm[3] = depsitDataWork.ValidityTerm4;              // �L������4
            depsitMain.DepositRowNo[4] = depsitDataWork.DepositRowNo5;              // �����s�ԍ�5
            depsitMain.MoneyKindCode[4] = depsitDataWork.MoneyKindCode5;            // ����R�[�h5
            depsitMain.MoneyKindName[4] = depsitDataWork.MoneyKindName5;            // ���햼��5
            depsitMain.MoneyKindDiv[4] = depsitDataWork.MoneyKindDiv5;              // ����敪5
            depsitMain.DepositDtl[4] = depsitDataWork.Deposit5;                     // �������z5
            depsitMain.ValidityTerm[4] = depsitDataWork.ValidityTerm5;              // �L������5
            depsitMain.DepositRowNo[5] = depsitDataWork.DepositRowNo6;              // �����s�ԍ�6
            depsitMain.MoneyKindCode[5] = depsitDataWork.MoneyKindCode6;            // ����R�[�h6
            depsitMain.MoneyKindName[5] = depsitDataWork.MoneyKindName6;            // ���햼��6
            depsitMain.MoneyKindDiv[5] = depsitDataWork.MoneyKindDiv6;              // ����敪6
            depsitMain.DepositDtl[5] = depsitDataWork.Deposit6;                     // �������z6
            depsitMain.ValidityTerm[5] = depsitDataWork.ValidityTerm6;              // �L������6
            depsitMain.DepositRowNo[6] = depsitDataWork.DepositRowNo7;              // �����s�ԍ�7
            depsitMain.MoneyKindCode[6] = depsitDataWork.MoneyKindCode7;            // ����R�[�h7
            depsitMain.MoneyKindName[6] = depsitDataWork.MoneyKindName7;            // ���햼��7
            depsitMain.MoneyKindDiv[6] = depsitDataWork.MoneyKindDiv7;              // ����敪7
            depsitMain.DepositDtl[6] = depsitDataWork.Deposit7;                     // �������z7
            depsitMain.ValidityTerm[6] = depsitDataWork.ValidityTerm7;              // �L������7
            depsitMain.DepositRowNo[7] = depsitDataWork.DepositRowNo8;              // �����s�ԍ�8
            depsitMain.MoneyKindCode[7] = depsitDataWork.MoneyKindCode8;            // ����R�[�h8
            depsitMain.MoneyKindName[7] = depsitDataWork.MoneyKindName8;            // ���햼��8
            depsitMain.MoneyKindDiv[7] = depsitDataWork.MoneyKindDiv8;              // ����敪8
            depsitMain.DepositDtl[7] = depsitDataWork.Deposit8;                     // �������z8
            depsitMain.ValidityTerm[7] = depsitDataWork.ValidityTerm8;              // �L������8
            depsitMain.DepositRowNo[8] = depsitDataWork.DepositRowNo9;              // �����s�ԍ�9
            depsitMain.MoneyKindCode[8] = depsitDataWork.MoneyKindCode9;            // ����R�[�h9
            depsitMain.MoneyKindName[8] = depsitDataWork.MoneyKindName9;            // ���햼��9
            depsitMain.MoneyKindDiv[8] = depsitDataWork.MoneyKindDiv9;              // ����敪9
            depsitMain.DepositDtl[8] = depsitDataWork.Deposit9;                     // �������z9
            depsitMain.ValidityTerm[8] = depsitDataWork.ValidityTerm9;              // �L������9
            depsitMain.DepositRowNo[9] = depsitDataWork.DepositRowNo10;             // �����s�ԍ�10
            depsitMain.MoneyKindCode[9] = depsitDataWork.MoneyKindCode10;           // ����R�[�h10
            depsitMain.MoneyKindName[9] = depsitDataWork.MoneyKindName10;           // ���햼��10
            depsitMain.MoneyKindDiv[9] = depsitDataWork.MoneyKindDiv10;             // ����敪10
            depsitMain.DepositDtl[9] = depsitDataWork.Deposit10;                    // �������z10
            depsitMain.ValidityTerm[9] = depsitDataWork.ValidityTerm10;             // �L������10
            depsitMain.InputDay = depsitDataWork.InputDay;
            // 2012/10/05 ADD TAKAGAWA 2012/10/17�z�M�V�X�e���e�X�g��QNo24 ---------->>>>>>>>>>
            depsitMain.DepositInputAgentCd = depsitDataWork.DepositInputAgentCd;    // ���s�҃R�[�h
            depsitMain.DepositInputAgentNm = depsitDataWork.DepositInputAgentNm;    // ���s�Җ�
            // 2012/10/05 ADD TAKAGAWA 2012/10/17�z�M�V�X�e���e�X�g��QNo24 ----------<<<<<<<<<<

            depsitDataList.Add(depsitMain);

            return depsitDataList;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�����}�X�^���[�N�˓����}�X�^�j
        /// </summary>
        /// <param name="depsitDataWorkList">�����}�X�^���[�N�N���X</param>
        /// <returns>�����}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^���[�N�N���X��������}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private ArrayList CopyToDepsitMainFromDepsitDataWork(DepsitDataWork[] depsitDataWorkList)
        {
            ArrayList depsitDataList = new ArrayList();

            foreach (DepsitDataWork depsitDataWork in depsitDataWorkList)
            {
                SearchDepsitMain depsitMain = new SearchDepsitMain();

                depsitMain.CreateDateTime = depsitDataWork.CreateDateTime;              // �쐬����
                depsitMain.UpdateDateTime = depsitDataWork.UpdateDateTime;              // �X�V����
                depsitMain.EnterpriseCode = depsitDataWork.EnterpriseCode;              // ��ƃR�[�h
                depsitMain.FileHeaderGuid = depsitDataWork.FileHeaderGuid;              // GUID
                depsitMain.UpdEmployeeCode = depsitDataWork.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
                depsitMain.UpdAssemblyId1 = depsitDataWork.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
                depsitMain.UpdAssemblyId2 = depsitDataWork.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
                depsitMain.LogicalDeleteCode = depsitDataWork.LogicalDeleteCode;        // �_���폜�敪
                depsitMain.DepositDebitNoteCd = depsitDataWork.DepositDebitNoteCd;      // �����ԍ��敪
                depsitMain.DepositSlipNo = depsitDataWork.DepositSlipNo;                // �����`�[�ԍ�
                depsitMain.AcptAnOdrStatus = depsitDataWork.AcptAnOdrStatus;            // �󒍃X�e�[�^�X
                depsitMain.SalesSlipNum = depsitDataWork.SalesSlipNum;                  // ����`�[�ԍ� 
                depsitMain.InputDepositSecCd = depsitDataWork.InputDepositSecCd;        // �������͋��_�R�[�h
                depsitMain.AddUpSecCode = depsitDataWork.AddUpSecCode;                  // �v�㋒�_�R�[�h
                depsitMain.UpdateSecCd = depsitDataWork.UpdateSecCd;                    // �X�V���_�R�[�h
                depsitMain.DepositDate = depsitDataWork.DepositDate;                    // �������t
                depsitMain.AddUpADate = depsitDataWork.AddUpADate;                      // �v����t
                depsitMain.Deposit = depsitDataWork.Deposit;                            // �������z(�ʏ�����Œ�)
                depsitMain.FeeDeposit = depsitDataWork.FeeDeposit;                      // �萔�������z
                depsitMain.DiscountDeposit = depsitDataWork.DiscountDeposit;            // �l�������z
                depsitMain.AutoDepositCd = depsitDataWork.AutoDepositCd;                // ���������敪
                depsitMain.DraftDrawingDate = depsitDataWork.DraftDrawingDate;          // ��`�U�o��
                depsitMain.DebitNoteLinkDepoNo = depsitDataWork.DebitNoteLinkDepoNo;    // �ԍ������A���ԍ�
                depsitMain.LastReconcileAddUpDt = depsitDataWork.LastReconcileAddUpDt;  // �ŏI�������݌v���
                depsitMain.DepositAgentCode = depsitDataWork.DepositAgentCode;          // �����S���҃R�[�h
                depsitMain.DepositAgentNm = depsitDataWork.DepositAgentNm;              // �����S���Җ���
                depsitMain.ClaimCode = depsitDataWork.ClaimCode;                        // ������R�[�h
                depsitMain.ClaimName = depsitDataWork.ClaimName;                        // �����於��
                depsitMain.ClaimName2 = depsitDataWork.ClaimName2;                      // �����於��2
                depsitMain.ClaimSnm = depsitDataWork.ClaimSnm;                          // �����旪��
                depsitMain.CustomerCode = depsitDataWork.CustomerCode;                  // ���Ӑ�R�[�h
                depsitMain.CustomerName = depsitDataWork.CustomerName;                  // ���Ӑ於��
                depsitMain.CustomerName2 = depsitDataWork.CustomerName2;                // ���Ӑ於��2
                depsitMain.CustomerSnm = depsitDataWork.CustomerSnm;                    // ���Ӑ旪��
                depsitMain.Outline = depsitDataWork.Outline;                            // �`�[�E�v
                depsitMain.BankCode = depsitDataWork.BankCode;                          // ��s�R�[�h
                depsitMain.BankName = depsitDataWork.BankName;                          // ��s����
                depsitMain.DraftNo = depsitDataWork.DraftNo;                            // ��`�ԍ�
                depsitMain.DraftKind = depsitDataWork.DraftKind;                        // ��`���
                depsitMain.DraftKindName = depsitDataWork.DraftKindName;                // ��`��ޖ���
                depsitMain.DraftDivide = depsitDataWork.DraftDivide;                    // ��`�敪
                depsitMain.DraftDivideName = depsitDataWork.DraftDivideName;            // ��`�敪����
                if (depsitMain.AutoDepositCd == 0)
                {
                    depsitMain.DepositNm = "�ʏ����";                                      // �a������敪����
                }
                else
                {
                    depsitMain.DepositNm = "��������";                                      // �a������敪����
                }
                depsitMain.DepositAllowance = depsitDataWork.DepositAllowance;          // ���������z
                depsitMain.DepositAlwcBlnce = depsitDataWork.DepositAlwcBlnce;          // ���������c��
                depsitMain.DepositRowNo[0] = depsitDataWork.DepositRowNo1;              // �����s�ԍ�1
                depsitMain.MoneyKindCode[0] = depsitDataWork.MoneyKindCode1;            // ����R�[�h1
                depsitMain.MoneyKindName[0] = depsitDataWork.MoneyKindName1;            // ���햼��1
                depsitMain.MoneyKindDiv[0] = depsitDataWork.MoneyKindDiv1;              // ����敪1
                depsitMain.DepositDtl[0] = depsitDataWork.Deposit1;                     // �������z1
                depsitMain.ValidityTerm[0] = depsitDataWork.ValidityTerm1;              // �L������1
                depsitMain.DepositRowNo[1] = depsitDataWork.DepositRowNo2;              // �����s�ԍ�2
                depsitMain.MoneyKindCode[1] = depsitDataWork.MoneyKindCode2;            // ����R�[�h2
                depsitMain.MoneyKindName[1] = depsitDataWork.MoneyKindName2;            // ���햼��2
                depsitMain.MoneyKindDiv[1] = depsitDataWork.MoneyKindDiv2;              // ����敪2
                depsitMain.DepositDtl[1] = depsitDataWork.Deposit2;                     // �������z2
                depsitMain.ValidityTerm[1] = depsitDataWork.ValidityTerm2;              // �L������2
                depsitMain.DepositRowNo[2] = depsitDataWork.DepositRowNo3;              // �����s�ԍ�3
                depsitMain.MoneyKindCode[2] = depsitDataWork.MoneyKindCode3;            // ����R�[�h3
                depsitMain.MoneyKindName[2] = depsitDataWork.MoneyKindName3;            // ���햼��3
                depsitMain.MoneyKindDiv[2] = depsitDataWork.MoneyKindDiv3;              // ����敪3
                depsitMain.DepositDtl[2] = depsitDataWork.Deposit3;                     // �������z3
                depsitMain.ValidityTerm[2] = depsitDataWork.ValidityTerm3;              // �L������3
                depsitMain.DepositRowNo[3] = depsitDataWork.DepositRowNo4;              // �����s�ԍ�4
                depsitMain.MoneyKindCode[3] = depsitDataWork.MoneyKindCode4;            // ����R�[�h4
                depsitMain.MoneyKindName[3] = depsitDataWork.MoneyKindName4;            // ���햼��4
                depsitMain.MoneyKindDiv[3] = depsitDataWork.MoneyKindDiv4;              // ����敪4
                depsitMain.DepositDtl[3] = depsitDataWork.Deposit4;                     // �������z4
                depsitMain.ValidityTerm[3] = depsitDataWork.ValidityTerm4;              // �L������4
                depsitMain.DepositRowNo[4] = depsitDataWork.DepositRowNo5;              // �����s�ԍ�5
                depsitMain.MoneyKindCode[4] = depsitDataWork.MoneyKindCode5;            // ����R�[�h5
                depsitMain.MoneyKindName[4] = depsitDataWork.MoneyKindName5;            // ���햼��5
                depsitMain.MoneyKindDiv[4] = depsitDataWork.MoneyKindDiv5;              // ����敪5
                depsitMain.DepositDtl[4] = depsitDataWork.Deposit5;                     // �������z5
                depsitMain.ValidityTerm[4] = depsitDataWork.ValidityTerm5;              // �L������5
                depsitMain.DepositRowNo[5] = depsitDataWork.DepositRowNo6;              // �����s�ԍ�6
                depsitMain.MoneyKindCode[5] = depsitDataWork.MoneyKindCode6;            // ����R�[�h6
                depsitMain.MoneyKindName[5] = depsitDataWork.MoneyKindName6;            // ���햼��6
                depsitMain.MoneyKindDiv[5] = depsitDataWork.MoneyKindDiv6;              // ����敪6
                depsitMain.DepositDtl[5] = depsitDataWork.Deposit6;                     // �������z6
                depsitMain.ValidityTerm[5] = depsitDataWork.ValidityTerm6;              // �L������6
                depsitMain.DepositRowNo[6] = depsitDataWork.DepositRowNo7;              // �����s�ԍ�7
                depsitMain.MoneyKindCode[6] = depsitDataWork.MoneyKindCode7;            // ����R�[�h7
                depsitMain.MoneyKindName[6] = depsitDataWork.MoneyKindName7;            // ���햼��7
                depsitMain.MoneyKindDiv[6] = depsitDataWork.MoneyKindDiv7;              // ����敪7
                depsitMain.DepositDtl[6] = depsitDataWork.Deposit7;                     // �������z7
                depsitMain.ValidityTerm[6] = depsitDataWork.ValidityTerm7;              // �L������7
                depsitMain.DepositRowNo[7] = depsitDataWork.DepositRowNo8;              // �����s�ԍ�8
                depsitMain.MoneyKindCode[7] = depsitDataWork.MoneyKindCode8;            // ����R�[�h8
                depsitMain.MoneyKindName[7] = depsitDataWork.MoneyKindName8;            // ���햼��8
                depsitMain.MoneyKindDiv[7] = depsitDataWork.MoneyKindDiv8;              // ����敪8
                depsitMain.DepositDtl[7] = depsitDataWork.Deposit8;                     // �������z8
                depsitMain.ValidityTerm[7] = depsitDataWork.ValidityTerm8;              // �L������8
                depsitMain.DepositRowNo[8] = depsitDataWork.DepositRowNo9;              // �����s�ԍ�9
                depsitMain.MoneyKindCode[8] = depsitDataWork.MoneyKindCode9;            // ����R�[�h9
                depsitMain.MoneyKindName[8] = depsitDataWork.MoneyKindName9;            // ���햼��9
                depsitMain.MoneyKindDiv[8] = depsitDataWork.MoneyKindDiv9;              // ����敪9
                depsitMain.DepositDtl[8] = depsitDataWork.Deposit9;                     // �������z9
                depsitMain.ValidityTerm[8] = depsitDataWork.ValidityTerm9;              // �L������9
                depsitMain.DepositRowNo[9] = depsitDataWork.DepositRowNo10;             // �����s�ԍ�10
                depsitMain.MoneyKindCode[9] = depsitDataWork.MoneyKindCode10;           // ����R�[�h10
                depsitMain.MoneyKindName[9] = depsitDataWork.MoneyKindName10;           // ���햼��10
                depsitMain.MoneyKindDiv[9] = depsitDataWork.MoneyKindDiv10;             // ����敪10
                depsitMain.DepositDtl[9] = depsitDataWork.Deposit10;                    // �������z10
                depsitMain.ValidityTerm[9] = depsitDataWork.ValidityTerm10;             // �L������10
                depsitMain.InputDay = depsitDataWork.InputDay;
                // 2012/10/05 ADD TAKAGAWA 2012/10/17�z�M�V�X�e���e�X�g��QNo24 ---------->>>>>>>>>>
                depsitMain.DepositInputAgentCd = depsitDataWork.DepositInputAgentCd;    // ���s�҃R�[�h
                depsitMain.DepositInputAgentNm = depsitDataWork.DepositInputAgentNm;    // ���s�Җ�
                // 2012/10/05 ADD TAKAGAWA 2012/10/17�z�M�V�X�e���e�X�g��QNo24 ----------<<<<<<<<<<

                depsitDataList.Add(depsitMain);
            }

            return depsitDataList;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���������}�X�^���[�N�˓��������}�X�^�j
        /// </summary>
        /// <param name="depositAlwWorkList">���������}�X�^���[�N�N���X</param>
        /// <returns>���������}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���������}�X�^���[�N�N���X������������}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private ArrayList CopyToDepositAlwFromDepositAlwWork(DepositAlwWork[] depositAlwWorkList)
        {
            ArrayList depositAlwList = new ArrayList();

            foreach (DepositAlwWork depositAlwWork in depositAlwWorkList)
            {
                SearchDepositAlw depositAlw = new SearchDepositAlw();

                depositAlw.CreateDateTime = depositAlwWork.CreateDateTime;          // �쐬����
                depositAlw.UpdateDateTime = depositAlwWork.UpdateDateTime;          // �X�V����
                depositAlw.EnterpriseCode = depositAlwWork.EnterpriseCode;          // ��ƃR�[�h
                depositAlw.FileHeaderGuid = depositAlwWork.FileHeaderGuid;          // GUID
                depositAlw.UpdEmployeeCode = depositAlwWork.UpdEmployeeCode;        // �X�V�]�ƈ��R�[�h
                depositAlw.UpdAssemblyId1 = depositAlwWork.UpdAssemblyId1;          // �X�V�A�Z���u��ID1
                depositAlw.UpdAssemblyId2 = depositAlwWork.UpdAssemblyId2;          // �X�V�A�Z���u��ID2
                depositAlw.LogicalDeleteCode = depositAlwWork.LogicalDeleteCode;    // �_���폜�敪
                depositAlw.InputDepositSecCd = depositAlwWork.InputDepositSecCd;    // �������͋��_�R�[�h
                depositAlw.AddUpSecCode = depositAlwWork.AddUpSecCode;              // �v�㋒�_�R�[�h
                depositAlw.ReconcileDate = depositAlwWork.ReconcileDate;            // �����ݓ�
                depositAlw.ReconcileAddUpDate = depositAlwWork.ReconcileAddUpDate;  // �����݌v���
                depositAlw.DepositSlipNo = depositAlwWork.DepositSlipNo;            // �����`�[�ԍ�
                depositAlw.DepositAllowance = depositAlwWork.DepositAllowance;      // ���������z
                depositAlw.DepositAgentCode = depositAlwWork.DepositAgentCode;      // �����S���҃R�[�h
                depositAlw.DepositAgentNm = depositAlwWork.DepositAgentNm;          // �����S���Җ���
                depositAlw.CustomerCode = depositAlwWork.CustomerCode;              // ���Ӑ�R�[�h
                depositAlw.CustomerName = depositAlwWork.CustomerName;              // ���Ӑ於��
                depositAlw.CustomerName2 = depositAlwWork.CustomerName2;            // ���Ӑ於��2
                depositAlw.DebitNoteOffSetCd = depositAlwWork.DebitNoteOffSetCd;    // �ԓ`���E�敪
                depositAlw.AcptAnOdrStatus = depositAlwWork.AcptAnOdrStatus;        // �󒍃X�e�[�^�X
                depositAlw.SalesSlipNum = depositAlwWork.SalesSlipNum;              // ����`�[�ԍ�

                depositAlwList.Add(depositAlw);
            }

            return depositAlwList;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���������f�[�^�˓����}�X�^���[�N�j
        /// </summary>
        /// <param name="depsitMain">���������f�[�^�N���X</param>
        /// <returns>�����}�X�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note        : ���������f�[�^�N���X��������}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br></br>
        /// </remarks>
        private DepsitDataWork CopyToDepsitDataWorkFromDepsitMain(SearchDepsitMain depsitMain)
        {
            DepsitDataWork depsitDataWork = new DepsitDataWork();

            depsitDataWork.CreateDateTime = depsitMain.CreateDateTime;              // �쐬����
            depsitDataWork.UpdateDateTime = depsitMain.UpdateDateTime;              // �X�V����
            depsitDataWork.EnterpriseCode = depsitMain.EnterpriseCode;              // ��ƃR�[�h
            depsitDataWork.FileHeaderGuid = depsitMain.FileHeaderGuid;              // GUID
            depsitDataWork.UpdEmployeeCode = depsitMain.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
            depsitDataWork.UpdAssemblyId1 = depsitMain.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
            depsitDataWork.UpdAssemblyId2 = depsitMain.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
            depsitDataWork.LogicalDeleteCode = depsitMain.LogicalDeleteCode;        // �_���폜�敪
            depsitDataWork.DepositDebitNoteCd = depsitMain.DepositDebitNoteCd;      // �����ԍ��敪
            depsitDataWork.DepositSlipNo = depsitMain.DepositSlipNo;                // �����`�[�ԍ�
            depsitDataWork.AcptAnOdrStatus = depsitMain.AcptAnOdrStatus;            // �󒍃X�e�[�^�X
            depsitDataWork.SalesSlipNum = depsitMain.SalesSlipNum;                  // ����`�[�ԍ�
            depsitDataWork.InputDepositSecCd = depsitMain.InputDepositSecCd;        // �������͋��_�R�[�h
            depsitDataWork.AddUpSecCode = depsitMain.AddUpSecCode;                  // �v�㋒�_�R�[�h
            depsitDataWork.UpdateSecCd = depsitMain.UpdateSecCd;                    // �X�V���_�R�[�h
            depsitDataWork.DepositDate = depsitMain.DepositDate;                    // �������t
            depsitDataWork.AddUpADate = depsitMain.AddUpADate;                      // �v����t
            depsitDataWork.DepositTotal = depsitMain.DepositTotal;                  // �����v
            depsitDataWork.Deposit = depsitMain.Deposit;                            // �������z
            depsitDataWork.FeeDeposit = depsitMain.FeeDeposit;                      // �萔�������z
            depsitDataWork.DiscountDeposit = depsitMain.DiscountDeposit;            // �l�������z
            depsitDataWork.AutoDepositCd = depsitMain.AutoDepositCd;                // ���������敪
            depsitDataWork.DraftDrawingDate = depsitMain.DraftDrawingDate;          // ��`�U�o��
            depsitDataWork.DebitNoteLinkDepoNo = depsitMain.DebitNoteLinkDepoNo;    // �ԍ������A���ԍ�
            depsitDataWork.LastReconcileAddUpDt = depsitMain.LastReconcileAddUpDt;  // �ŏI�������݌v���
            depsitDataWork.SubSectionCode = depsitMain.SubSectionCode;
            depsitDataWork.DepositAgentCode = depsitMain.DepositAgentCode;          // �����S���҃R�[�h
            depsitDataWork.DepositAgentNm = depsitMain.DepositAgentNm;              // �����S���Җ���
            depsitDataWork.DepositInputAgentCd = depsitMain.DepositInputAgentCd;    // �������͎҃R�[�h
            depsitDataWork.DepositInputAgentNm = depsitMain.DepositInputAgentNm;    // �������͎Җ���
            depsitDataWork.ClaimCode = depsitMain.ClaimCode;                        // ������R�[�h
            depsitDataWork.ClaimName = depsitMain.ClaimName;                        // �����於��
            depsitDataWork.ClaimName2 = depsitMain.ClaimName2;                      // �����於��2
            depsitDataWork.ClaimSnm = depsitMain.ClaimSnm;                          // �����旪��
            depsitDataWork.CustomerCode = depsitMain.CustomerCode;                  // ���Ӑ�R�[�h
            depsitDataWork.CustomerName = depsitMain.CustomerName;                  // ���Ӑ於��
            depsitDataWork.CustomerName2 = depsitMain.CustomerName2;                // ���Ӑ於��2
            depsitDataWork.CustomerSnm = depsitMain.CustomerSnm;                    // ���Ӑ旪��
            depsitDataWork.Outline = depsitMain.Outline;                            // �`�[�E�v
            depsitDataWork.BankCode = depsitMain.BankCode;                          // ��s�R�[�h
            depsitDataWork.BankName = depsitMain.BankName;                          // ��s����
            depsitDataWork.DraftNo = depsitMain.DraftNo;                            // ��`�ԍ�
            depsitDataWork.DraftKind = depsitMain.DraftKind;                        // ��`���
            depsitDataWork.DraftKindName = depsitMain.DraftKindName;                // ��`��ޖ���
            depsitDataWork.DraftDivide = depsitMain.DraftDivide;                    // ��`�敪
            depsitDataWork.DraftDivideName = depsitMain.DraftDivideName;            // ��`�敪����
            depsitDataWork.DepositAllowance = depsitMain.DepositAllowance;          // ���������z
            depsitDataWork.DepositAlwcBlnce = depsitMain.DepositAlwcBlnce;          // ���������c��
            depsitDataWork.DepositRowNo1 = depsitMain.DepositRowNo[0];              // �����s�ԍ�1
            depsitDataWork.MoneyKindCode1 = depsitMain.MoneyKindCode[0];            // ����R�[�h1
            depsitDataWork.MoneyKindName1 = depsitMain.MoneyKindName[0];            // ���햼��1
            depsitDataWork.MoneyKindDiv1 = depsitMain.MoneyKindDiv[0];              // ����敪1
            depsitDataWork.Deposit1 = depsitMain.DepositDtl[0];                     // �������z1
            depsitDataWork.ValidityTerm1 = depsitMain.ValidityTerm[0];              // �L������1
            depsitDataWork.DepositRowNo2 = depsitMain.DepositRowNo[1];              // �����s�ԍ�2
            depsitDataWork.MoneyKindCode2 = depsitMain.MoneyKindCode[1];            // ����R�[�h2
            depsitDataWork.MoneyKindName2 = depsitMain.MoneyKindName[1];            // ���햼��2
            depsitDataWork.MoneyKindDiv2 = depsitMain.MoneyKindDiv[1];              // ����敪2
            depsitDataWork.Deposit2 = depsitMain.DepositDtl[1];                     // �������z2
            depsitDataWork.ValidityTerm2 = depsitMain.ValidityTerm[1];              // �L������2
            depsitDataWork.DepositRowNo3 = depsitMain.DepositRowNo[2];              // �����s�ԍ�3
            depsitDataWork.MoneyKindCode3 = depsitMain.MoneyKindCode[2];            // ����R�[�h3
            depsitDataWork.MoneyKindName3 = depsitMain.MoneyKindName[2];            // ���햼��3
            depsitDataWork.MoneyKindDiv3 = depsitMain.MoneyKindDiv[2];              // ����敪3
            depsitDataWork.Deposit3 = depsitMain.DepositDtl[2];                     // �������z3
            depsitDataWork.ValidityTerm3 = depsitMain.ValidityTerm[2];              // �L������3
            depsitDataWork.DepositRowNo4 = depsitMain.DepositRowNo[3];              // �����s�ԍ�4
            depsitDataWork.MoneyKindCode4 = depsitMain.MoneyKindCode[3];            // ����R�[�h4
            depsitDataWork.MoneyKindName4 = depsitMain.MoneyKindName[3];            // ���햼��4
            depsitDataWork.MoneyKindDiv4 = depsitMain.MoneyKindDiv[3];              // ����敪4
            depsitDataWork.Deposit4 = depsitMain.DepositDtl[3];                     // �������z4
            depsitDataWork.ValidityTerm4 = depsitMain.ValidityTerm[3];              // �L������4
            depsitDataWork.DepositRowNo5 = depsitMain.DepositRowNo[4];              // �����s�ԍ�5
            depsitDataWork.MoneyKindCode5 = depsitMain.MoneyKindCode[4];            // ����R�[�h5
            depsitDataWork.MoneyKindName5 = depsitMain.MoneyKindName[4];            // ���햼��5
            depsitDataWork.MoneyKindDiv5 = depsitMain.MoneyKindDiv[4];              // ����敪5
            depsitDataWork.Deposit5 = depsitMain.DepositDtl[4];                     // �������z5
            depsitDataWork.ValidityTerm5 = depsitMain.ValidityTerm[4];              // �L������5
            depsitDataWork.DepositRowNo6 = depsitMain.DepositRowNo[5];              // �����s�ԍ�6
            depsitDataWork.MoneyKindCode6 = depsitMain.MoneyKindCode[5];            // ����R�[�h6
            depsitDataWork.MoneyKindName6 = depsitMain.MoneyKindName[5];            // ���햼��6
            depsitDataWork.MoneyKindDiv6 = depsitMain.MoneyKindDiv[5];              // ����敪6
            depsitDataWork.Deposit6 = depsitMain.DepositDtl[5];                     // �������z6
            depsitDataWork.ValidityTerm6 = depsitMain.ValidityTerm[5];              // �L������6
            depsitDataWork.DepositRowNo7 = depsitMain.DepositRowNo[6];              // �����s�ԍ�7
            depsitDataWork.MoneyKindCode7 = depsitMain.MoneyKindCode[6];            // ����R�[�h7
            depsitDataWork.MoneyKindName7 = depsitMain.MoneyKindName[6];            // ���햼��7
            depsitDataWork.MoneyKindDiv7 = depsitMain.MoneyKindDiv[6];              // ����敪7
            depsitDataWork.Deposit7 = depsitMain.DepositDtl[6];                     // �������z7
            depsitDataWork.ValidityTerm7 = depsitMain.ValidityTerm[6];              // �L������7
            depsitDataWork.DepositRowNo8 = depsitMain.DepositRowNo[7];              // �����s�ԍ�8
            depsitDataWork.MoneyKindCode8 = depsitMain.MoneyKindCode[7];            // ����R�[�h8
            depsitDataWork.MoneyKindName8 = depsitMain.MoneyKindName[7];            // ���햼��8
            depsitDataWork.MoneyKindDiv8 = depsitMain.MoneyKindDiv[7];              // ����敪8
            depsitDataWork.Deposit8 = depsitMain.DepositDtl[7];                     // �������z8
            depsitDataWork.ValidityTerm8 = depsitMain.ValidityTerm[7];              // �L������8
            depsitDataWork.DepositRowNo9 = depsitMain.DepositRowNo[8];              // �����s�ԍ�9
            depsitDataWork.MoneyKindCode9 = depsitMain.MoneyKindCode[8];            // ����R�[�h9
            depsitDataWork.MoneyKindName9 = depsitMain.MoneyKindName[8];            // ���햼��9
            depsitDataWork.MoneyKindDiv9 = depsitMain.MoneyKindDiv[8];              // ����敪9
            depsitDataWork.Deposit9 = depsitMain.DepositDtl[8];                     // �������z9
            depsitDataWork.ValidityTerm9 = depsitMain.ValidityTerm[8];              // �L������9
            depsitDataWork.DepositRowNo10 = depsitMain.DepositRowNo[9];              // �����s�ԍ�10
            depsitDataWork.MoneyKindCode10 = depsitMain.MoneyKindCode[9];            // ����R�[�h10
            depsitDataWork.MoneyKindName10 = depsitMain.MoneyKindName[9];            // ���햼��10
            depsitDataWork.MoneyKindDiv10 = depsitMain.MoneyKindDiv[9];              // ����敪10
            depsitDataWork.Deposit10 = depsitMain.DepositDtl[9];                     // �������z10
            depsitDataWork.ValidityTerm10 = depsitMain.ValidityTerm[9];              // �L������10
            depsitDataWork.InputDay = depsitMain.InputDay;

            return depsitDataWork;
        }
        // --------------- ADD START 2010.05.06 gejun FOR M1007A-M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i����`�f�[�^�}�X�^�N���X�ˎ���`�f�[�^�}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="rcvDraftData">����`�f�[�^�}�X�^�N���X</param>
        /// <returns>����`�f�[�^�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ����`�f�[�^�}�X�^�N���X�������`�f�[�^�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.06</br>
        /// </remarks>
        private RcvDraftDataWork CopyToRcvDraftDataWorkFromRcvDraftData(RcvDraftData rcvDraftData)
        {
            RcvDraftDataWork rcvDraftDataWork = new RcvDraftDataWork();

            rcvDraftDataWork.CreateDateTime = rcvDraftData.CreateDateTime;
            rcvDraftDataWork.UpdateDateTime = rcvDraftData.UpdateDateTime;
            rcvDraftDataWork.EnterpriseCode = rcvDraftData.EnterpriseCode;
            rcvDraftDataWork.FileHeaderGuid = rcvDraftData.FileHeaderGuid;
            rcvDraftDataWork.UpdEmployeeCode = rcvDraftData.UpdEmployeeCode;
            rcvDraftDataWork.UpdAssemblyId1 = rcvDraftData.UpdAssemblyId1;
            rcvDraftDataWork.UpdAssemblyId2 = rcvDraftData.UpdAssemblyId2;
            rcvDraftDataWork.LogicalDeleteCode = rcvDraftData.LogicalDeleteCode;
            rcvDraftDataWork.RcvDraftNo = rcvDraftData.RcvDraftNo;
            rcvDraftDataWork.DraftKindCd = rcvDraftData.DraftKindCd;
            rcvDraftDataWork.DraftDivide = rcvDraftData.DraftDivide;
            rcvDraftDataWork.Deposit = rcvDraftData.Deposit;
            rcvDraftDataWork.BankAndBranchCd = rcvDraftData.BankAndBranchCd;
            rcvDraftDataWork.BankAndBranchNm = rcvDraftData.BankAndBranchNm;
            rcvDraftDataWork.SectionCode = rcvDraftData.SectionCode;
            rcvDraftDataWork.AddUpSecCode = rcvDraftData.AddUpSecCode;
            rcvDraftDataWork.CustomerCode = rcvDraftData.CustomerCode;
            rcvDraftDataWork.CustomerName = rcvDraftData.CustomerName;
            rcvDraftDataWork.CustomerName2 = rcvDraftData.CustomerName2;
            rcvDraftDataWork.CustomerSnm = rcvDraftData.CustomerSnm;
            rcvDraftDataWork.ProcDate = rcvDraftData.ProcDate;
            rcvDraftDataWork.DraftDrawingDate = rcvDraftData.DraftDrawingDate;
            rcvDraftDataWork.ValidityTerm = rcvDraftData.ValidityTerm;
            rcvDraftDataWork.DraftStmntDate = rcvDraftData.DraftStmntDate;
            rcvDraftDataWork.Outline1 = rcvDraftData.Outline1;
            rcvDraftDataWork.Outline2 = rcvDraftData.Outline2;
            rcvDraftDataWork.AcptAnOdrStatus = rcvDraftData.AcptAnOdrStatus;
            rcvDraftDataWork.DepositSlipNo = rcvDraftData.DepositSlipNo;
            rcvDraftDataWork.DepositRowNo = rcvDraftData.DepositRowNo;
            rcvDraftDataWork.DepositDate = rcvDraftData.DepositDate;

            return rcvDraftDataWork;
        }
        // --------------- ADD END 2010.05.06 gejun FOR M1007A-M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���������}�X�^�˓��������}�X�^���[�N�j
        /// </summary>
        /// <param name="depositAlwList">���������}�X�^�N���X</param>
        /// <returns>�����}�X�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note        : ���������}�X�^�N���X��������}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br></br>
        /// </remarks>
        private DepositAlwWork[] CopyToDepositAlwWorkFromDepositAlw(Hashtable depositAlwList)
        {
            ArrayList arrDepositAlw = new ArrayList();

            foreach (DictionaryEntry de in depositAlwList)
            {
                SearchDepositAlw depositAlw = (SearchDepositAlw)de.Value;
                DepositAlwWork depositAlwWork = new DepositAlwWork();

                depositAlwWork.CreateDateTime = depositAlw.CreateDateTime;              // �쐬����
                depositAlwWork.UpdateDateTime = depositAlw.UpdateDateTime;              // �X�V����
                depositAlwWork.EnterpriseCode = depositAlw.EnterpriseCode;              // ��ƃR�[�h
                depositAlwWork.FileHeaderGuid = depositAlw.FileHeaderGuid;              // GUID
                depositAlwWork.UpdEmployeeCode = depositAlw.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
                depositAlwWork.UpdAssemblyId1 = depositAlw.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
                depositAlwWork.UpdAssemblyId2 = depositAlw.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
                depositAlwWork.LogicalDeleteCode = depositAlw.LogicalDeleteCode;        // �_���폜�敪
                depositAlwWork.InputDepositSecCd = depositAlw.InputDepositSecCd;        // �������͋��_�R�[�h
                depositAlwWork.AddUpSecCode = depositAlw.AddUpSecCode;                  // �v�㋒�_�R�[�h
                depositAlwWork.ReconcileDate = depositAlw.ReconcileDate;                // �����ݓ�
                depositAlwWork.ReconcileAddUpDate = depositAlw.ReconcileAddUpDate;      // �����݌v���
                depositAlwWork.DepositSlipNo = depositAlw.DepositSlipNo;                // �����`�[�ԍ�
                depositAlwWork.DepositAllowance = depositAlw.DepositAllowance;          // ���������z
                depositAlwWork.DepositAgentCode = depositAlw.DepositAgentCode;          // �����S���҃R�[�h
                depositAlwWork.DepositAgentNm = depositAlw.DepositAgentNm;              // �����S���Җ���
                depositAlwWork.CustomerCode = depositAlw.CustomerCode;                  // ���Ӑ�R�[�h
                depositAlwWork.CustomerName = depositAlw.CustomerName;                  // ���Ӑ於��
                depositAlwWork.CustomerName2 = depositAlw.CustomerName2;                // ���Ӑ於��2
                depositAlwWork.AcptAnOdrStatus = depositAlw.AcptAnOdrStatus;            // �󒍃X�e�[�^�X
                depositAlwWork.SalesSlipNum = depositAlw.SalesSlipNum;                  // ����`�[�ԍ�
                depositAlwWork.DebitNoteOffSetCd = depositAlw.DebitNoteOffSetCd;        // �ԓ`���E�敪

                arrDepositAlw.Add(depositAlwWork);
            }

            DepositAlwWork[] list = (DepositAlwWork[])arrDepositAlw.ToArray(typeof(DepositAlwWork));

            return list;
        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �N���X�����o�[�R�s�[�����iKINGET�p���Ӑ搿�����z���[�N�N���X�˓������Ӑ搿�����z���N���X�j
		/// </summary>
		/// <param name="kingetCustDmdPrcWork">KINGET�p���Ӑ搿�����z���[�N�N���X</param>
		/// <returns>���Ӑ搿���N���X</returns>
		/// <remarks>
		/// <br>Note       : KINGET�p���Ӑ搿�����z���[�N�N���X����������Ӑ搿�����z���N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
        /// <br>Update Note : 2007.01.22 18322 T.Kimura MA.NS�p�ɕύX</br>
        /// <br>Update Note : 2007.04.18 18322 T.Kimura ��ʂɕ\�����鐿���̋����ɕ����邽�ߏC��</br>
		/// </remarks>
		private DepositCustDmdPrc CopyToDepositCustDmdPrcFromKingetCustDmdPrcWork(KingetCustDmdPrcWork kingetCustDmdPrcWork)
		{
			DepositCustDmdPrc depositCustDmdPrc = new DepositCustDmdPrc();

            // �� 20070118 18322 c MA.NS�ł͏���p�͎g�p���Ȃ��̂ō폜
            #region SF �������z���Z�b�g(�R�����g�A�E�g)
            //// �������z���Z�b�g
			//depositCustDmdPrc.AddUpSecCode			= kingetCustDmdPrcWork.AddUpSecCode;			// �v�㋒�_�R�[�h
			//depositCustDmdPrc.CustomerCode			= kingetCustDmdPrcWork.CustomerCode;			// ���Ӑ�R�[�h
			//depositCustDmdPrc.AddUpDate				= kingetCustDmdPrcWork.AddUpDate;				// �v��N����
			//depositCustDmdPrc.StartDateSpan			= kingetCustDmdPrcWork.StartDateSpan;			// �͈͓��t�i�J�n�j
			//depositCustDmdPrc.EndDateSpan			= kingetCustDmdPrcWork.EndDateSpan;				// �͈͓��t�i�I���j
			//depositCustDmdPrc.AcpOdrTtlLMBlDmd		= kingetCustDmdPrcWork.AcpOdrTtlLMBlDmd;		// �󒍑O���c���i�����v�j
			//depositCustDmdPrc.TtlLMVarCstDmdBlnce	= kingetCustDmdPrcWork.TtlLMVarCstDmdBlnce;		// ����p�O���c���i�����v�j
			//depositCustDmdPrc.AfCalTtlAOdrDepoDmd	= kingetCustDmdPrcWork.AfCalTtlAOdrDepoDmd;		// �v�Z��󒍓����z�i�����v�j
			//depositCustDmdPrc.AfCalTtlVCstDepoDmd	= kingetCustDmdPrcWork.AfCalTtlVCstDepoDmd;		// �v�Z�㏔��p�����z�i�����v�j
			//depositCustDmdPrc.AfCalTtlAOdrDpDsDmd	= kingetCustDmdPrcWork.AfCalTtlAOdrDpDsDmd;		// �v�Z��󒍓����l���z�i�����v�j
			//depositCustDmdPrc.AfCalTtlVCstDpDsDmd	= kingetCustDmdPrcWork.AfCalTtlVCstDpDsDmd;		// �v�Z�㏔��p�����l���z�i�����v�j
			//depositCustDmdPrc.AcpOdrTtlSalesDmd		= kingetCustDmdPrcWork.AcpOdrTtlSalesDmd;		// �󒍔���z�i�����v�j
			//depositCustDmdPrc.AcpOdrTtlConsTaxDmd	= kingetCustDmdPrcWork.AcpOdrTtlConsTaxDmd;		// �󒍏���Ŋz�i�����v�j
			//depositCustDmdPrc.DmdVarCst				= kingetCustDmdPrcWork.DmdVarCst;				// ����p���z�i�����v�j
			//depositCustDmdPrc.TtlDmdVarCstConsTax	= kingetCustDmdPrcWork.TtlDmdVarCstConsTax;		// ����p����Ŋz�i�����v�j
			//depositCustDmdPrc.AfCalTtlAOdrRMDmd		= kingetCustDmdPrcWork.AfCalTtlAOdrRMDmd;		// �v�Z��󒍑O����i�����v�j
			//depositCustDmdPrc.AfCalTtlVCstBfRMDmd	= kingetCustDmdPrcWork.AfCalTtlVCstBfRMDmd;		// �v�Z�㏔��p�O����i�����v�j
			//depositCustDmdPrc.AfCalTtlAOdrRMDsDmd	= kingetCustDmdPrcWork.AfCalTtlAOdrRMDsDmd;		// �v�Z��󒍑O����l���z�i�����v�j
			//depositCustDmdPrc.AfCalTtlVCstRMDsDmd	= kingetCustDmdPrcWork.AfCalTtlVCstRMDsDmd;		// �v�Z�㏔��p�O����l���z�i�����v�j
			//depositCustDmdPrc.AfCalTtlAOdrBlDmd		= kingetCustDmdPrcWork.AfCalTtlAOdrBlDmd;		// �v�Z��󒍍��v�c���i�����v�j
			//depositCustDmdPrc.AfCalTtlVCstBlDmd		= kingetCustDmdPrcWork.AfCalTtlVCstBlDmd;		// �v�Z�㏔��p���v�c���i�����v�j
            #endregion

            #region MA.NS �������z���Z�b�g
            // �v�㋒�_�R�[�h
            depositCustDmdPrc.AddUpSecCode       = kingetCustDmdPrcWork.AddUpSecCode;
            // ������R�[�h
            depositCustDmdPrc.ClaimCode          = kingetCustDmdPrcWork.ClaimCode;
            // ���Ӑ�R�[�h
            depositCustDmdPrc.CustomerCode       = kingetCustDmdPrcWork.CustomerCode;
            // �v��N����
            depositCustDmdPrc.AddUpDate          = kingetCustDmdPrcWork.AddUpDate;
            // �͈͓��t�i�J�n�j
            depositCustDmdPrc.StartDateSpan      = kingetCustDmdPrcWork.StartDateSpan;
            // �͈͓��t�i�I���j
            depositCustDmdPrc.EndDateSpan        = kingetCustDmdPrcWork.EndDateSpan;
            // �O�񐿋����z
            depositCustDmdPrc.LastTimeDemand     = kingetCustDmdPrcWork.LastTimeDemand;
            // ����������z�i�ʏ�����j
            depositCustDmdPrc.ThisTimeDmdNrml    = kingetCustDmdPrcWork.ThisTimeDmdNrml;
            // ����萔���z�i�ʏ�����j
            depositCustDmdPrc.ThisTimeFeeDmdNrml = kingetCustDmdPrcWork.ThisTimeFeeDmdNrml;
            // ����l���z�i�ʏ�����j
            depositCustDmdPrc.ThisTimeDisDmdNrml = kingetCustDmdPrcWork.ThisTimeDisDmdNrml;
            // 2007.10.05 del start---------------------------------------------------------->>
            // ���񃊃x�[�g�z�i�ʏ�����j
            //depositCustDmdPrc.ThisTimeRbtDmdNrml = kingetCustDmdPrcWork.ThisTimeRbtDmdNrml;
            // ����������z�i�a����j
            //depositCustDmdPrc.ThisTimeDmdDepo    = kingetCustDmdPrcWork.ThisTimeDmdDepo;
            // ����萔���z�i�a����j
            //depositCustDmdPrc.ThisTimeFeeDmdDepo = kingetCustDmdPrcWork.ThisTimeFeeDmdDepo;
            // ����l���z�i�a����j
            //depositCustDmdPrc.ThisTimeDisDmdDepo = kingetCustDmdPrcWork.ThisTimeDisDmdDepo;
            // ���񃊃x�[�g�z�i�a����j
            //depositCustDmdPrc.ThisTimeRbtDmdDepo = kingetCustDmdPrcWork.ThisTimeRbtDmdDepo;
            // 2007.10.05 del end -----------------------------------------------------------<<
            // ����J�z�c���i�����v�j
            depositCustDmdPrc.ThisTimeTtlBlcDmd = kingetCustDmdPrcWork.ThisTimeTtlBlcDmd;
            // ���񔄏���z
            depositCustDmdPrc.ThisTimeSales     = kingetCustDmdPrcWork.ThisTimeSales;
            // ���񔄏�����
            depositCustDmdPrc.ThisSalesTax      = kingetCustDmdPrcWork.ThisSalesTax;
            // 2007.10.05 hikita del start ------------------------------------------------------>>
            //// �x���C���Z���e�B�u�z���v�i�Ŕ����j
            //depositCustDmdPrc.TtlIncDtbtTaxExc  = kingetCustDmdPrcWork.TtlIncDtbtTaxExc;
            //// �x���C���Z���e�B�u�z���v�i�Łj
            //depositCustDmdPrc.TtlIncDtbtTax     = kingetCustDmdPrcWork.TtlIncDtbtTax;
            // 2007.10.05 hikita del end --------------------------------------------------------<<
            // ���E�㍡�񔄏���z
            depositCustDmdPrc.OfsThisTimeSales  = kingetCustDmdPrcWork.OfsThisTimeSales;
            // ���E�㍡�񔄏�����
            depositCustDmdPrc.OfsThisSalesTax   = kingetCustDmdPrcWork.OfsThisSalesTax;
            // �v�Z�㐿�����z
            depositCustDmdPrc.AfCalDemandPrice  = kingetCustDmdPrcWork.AfCalDemandPrice;

            // ��������v�i�ʏ�����j
            depositCustDmdPrc.ThisTimeDmdNrmlTtl = depositCustDmdPrc.ThisTimeDmdNrml;
            //                                     + kingetCustDmdPrcWork.ThisTimeFeeDmdNrml   // 2007.10.05 hikita del
            //                                     + kingetCustDmdPrcWork.ThisTimeDisDmdNrml;  // 2007.10.05 hikita del
            //                                     + kingetCustDmdPrcWork.ThisTimeRbtDmdNrml;  // 2007.10.05 hikita del


            //// ��������v�i�a����j
            //depositCustDmdPrc.ThisTimeDmdDepoTtl = kingetCustDmdPrcWork.ThisTimeDmdDepo      // 2007.10.05 hikita del
            //                                     + kingetCustDmdPrcWork.ThisTimeFeeDmdDepo   // 2007.10.05 hikita del 
            //                                     + kingetCustDmdPrcWork.ThisTimeDisDmdDepo;  // 2007.10.05 hikita del 
            //                                     + kingetCustDmdPrcWork.ThisTimeRbtDmdDepo;  // 2007.10.05 hikita del
            // ��������v
            depositCustDmdPrc.ThisTimeDmdTtl = depositCustDmdPrc.ThisTimeDmdNrmlTtl;
            //                                     + kingetCustDmdPrcWork.ThisTimeDmdDepoTtl;  // 2007.10.05 hikita del
            depositCustDmdPrc.LastCAddUpUpdDate = kingetCustDmdPrcWork.LastCAddUpUpdDate;
            depositCustDmdPrc.CAddUpUpdExecDate = kingetCustDmdPrcWork.CAddUpUpdExecDate;
            depositCustDmdPrc.StartCAddUpUpdDate = kingetCustDmdPrcWork.StartCAddUpUpdDate;
            #endregion
            // �� 20070118 18322 c

			return depositCustDmdPrc;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�����}�X�^���[�N�N���X�˓����}�X�^�N���X�j
        /// </summary>
        /// <param name="depsitMainWorkList">�����}�X�^���[�N�N���X</param>
        /// <returns>�����}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^���[�N�N���X��������}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// <br>Update Note : 2007.01.22 18322 T.Kimura</br>
        /// <br>                MA.NS�p�ɕύX</br>
        /// </remarks>
        private ArrayList CopyToDepsitMainFromDepsitMainWork(DepsitMainWork[] depsitMainWorkList)
        {
            ArrayList depsitMainList = new ArrayList();

            foreach (DepsitMainWork depsitMainWork in depsitMainWorkList)
            {
                SearchDepsitMain depsitMain = new SearchDepsitMain();

                // �� 20070122 18322 c MA.NS�p�ɕύX
                #region SF �����}�X�^���[�N�N���X�˓����}�X�^�N���X�i�S�ăR�����g�A�E�g�j
                //depsitMain.CreateDateTime		= depsitMainWork.CreateDateTime;
                //depsitMain.UpdateDateTime		= depsitMainWork.UpdateDateTime;
                //depsitMain.EnterpriseCode		= depsitMainWork.EnterpriseCode;
                //depsitMain.FileHeaderGuid		= depsitMainWork.FileHeaderGuid;
                //depsitMain.UpdEmployeeCode		= depsitMainWork.UpdEmployeeCode;
                //depsitMain.UpdAssemblyId1		= depsitMainWork.UpdAssemblyId1;
                //depsitMain.UpdAssemblyId2		= depsitMainWork.UpdAssemblyId2;
                //depsitMain.LogicalDeleteCode	= depsitMainWork.LogicalDeleteCode;
                //depsitMain.DepositDebitNoteCd	= depsitMainWork.DepositDebitNoteCd;
                //depsitMain.DepositSlipNo		= depsitMainWork.DepositSlipNo;
                //depsitMain.DepositKindCode		= depsitMainWork.DepositKindCode;
                //depsitMain.CustomerCode			= depsitMainWork.CustomerCode;
                //depsitMain.DepositCd			= depsitMainWork.DepositCd;
                //depsitMain.DepositTotal			= depsitMainWork.DepositTotal;
                //depsitMain.Outline				= depsitMainWork.Outline;
                //depsitMain.AcceptAnOrderSalesNo	= depsitMainWork.AcceptAnOrderSalesNo;
                //depsitMain.InputDepositSecCd	= depsitMainWork.InputDepositSecCd;
                //depsitMain.DepositDate			= depsitMainWork.DepositDate;
                //depsitMain.AddUpSecCode			= depsitMainWork.AddUpSecCode;
                //depsitMain.AddUpADate			= depsitMainWork.AddUpADate;
                //depsitMain.UpdateSecCd			= depsitMainWork.UpdateSecCd;
                //depsitMain.DepositKindName		= depsitMainWork.DepositKindName;
                //depsitMain.DepositAllowance		= depsitMainWork.DepositAllowance;
                //depsitMain.DepositAlwcBlnce		= depsitMainWork.DepositAlwcBlnce;
                //depsitMain.DepositAgentCode		= depsitMainWork.DepositAgentCode;
                //depsitMain.DepositKindDivCd		= depsitMainWork.DepositKindDivCd;
                //depsitMain.FeeDeposit			= depsitMainWork.FeeDeposit;
                //depsitMain.DiscountDeposit		= depsitMainWork.DiscountDeposit;
                //depsitMain.CreditOrLoanCd		= depsitMainWork.CreditOrLoanCd;
                //depsitMain.CreditCompanyCode	= depsitMainWork.CreditCompanyCode;
                //depsitMain.Deposit				= depsitMainWork.Deposit;
                //depsitMain.DraftDrawingDate		= depsitMainWork.DraftDrawingDate;
                //depsitMain.DraftPayTimeLimit	= depsitMainWork.DraftPayTimeLimit;
                //depsitMain.DebitNoteLinkDepoNo	= depsitMainWork.DebitNoteLinkDepoNo;
                //depsitMain.LastReconcileAddUpDt	= depsitMainWork.LastReconcileAddUpDt;
                //depsitMain.AcpOdrDeposit		= depsitMainWork.AcpOdrDeposit;
                //depsitMain.AcpOdrChargeDeposit	= depsitMainWork.AcpOdrChargeDeposit;
                //depsitMain.AcpOdrDisDeposit		= depsitMainWork.AcpOdrDisDeposit;
                //depsitMain.VariousCostDeposit	= depsitMainWork.VariousCostDeposit;
                //depsitMain.VarCostChargeDeposit	= depsitMainWork.VarCostChargeDeposit;
                //depsitMain.VarCostDisDeposit	= depsitMainWork.VarCostDisDeposit;
                //depsitMain.AcpOdrDepositAlwc	= depsitMainWork.AcpOdrDepositAlwc;
                //depsitMain.AcpOdrDepoAlwcBlnce	= depsitMainWork.AcpOdrDepoAlwcBlnce;
                //depsitMain.VarCostDepoAlwc		= depsitMainWork.VarCostDepoAlwc;
                //depsitMain.VarCostDepoAlwcBlnce	= depsitMainWork.VarCostDepoAlwcBlnce;
                #endregion

                // �쐬����
                depsitMain.CreateDateTime = depsitMainWork.CreateDateTime;
                // �X�V����
                depsitMain.UpdateDateTime = depsitMainWork.UpdateDateTime;
                // ��ƃR�[�h
                depsitMain.EnterpriseCode = depsitMainWork.EnterpriseCode;
                // GUID
                depsitMain.FileHeaderGuid = depsitMainWork.FileHeaderGuid;
                // �X�V�]�ƈ��R�[�h
                depsitMain.UpdEmployeeCode = depsitMainWork.UpdEmployeeCode;
                // �X�V�A�Z���u��ID1
                depsitMain.UpdAssemblyId1 = depsitMainWork.UpdAssemblyId1;
                // �X�V�A�Z���u��ID2
                depsitMain.UpdAssemblyId2 = depsitMainWork.UpdAssemblyId2;
                // �_���폜�敪
                depsitMain.LogicalDeleteCode = depsitMainWork.LogicalDeleteCode;
                // �����ԍ��敪
                depsitMain.DepositDebitNoteCd = depsitMainWork.DepositDebitNoteCd;
                // �����`�[�ԍ�
                depsitMain.DepositSlipNo = depsitMainWork.DepositSlipNo;
                // �󒍔ԍ�
                //depsitMain.AcceptAnOrderNo      = depsitMainWork.AcceptAnOrderNo;  // 2007.10.05 del
                // �T�[�r�X�`�[�敪
                //depsitMain.ServiceSlipCd        = depsitMainWork.ServiceSlipCd;    // 2007.10.05 del
                // �󒍃X�e�[�^�X
                depsitMain.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus;
                // ����`�[�ԍ� 
                depsitMain.SalesSlipNum = depsitMainWork.SalesSlipNum;       // 2007.10.05 add
                // �������͋��_�R�[�h
                depsitMain.InputDepositSecCd = depsitMainWork.InputDepositSecCd;
                // �v�㋒�_�R�[�h
                depsitMain.AddUpSecCode = depsitMainWork.AddUpSecCode;
                // �X�V���_�R�[�h
                depsitMain.UpdateSecCd = depsitMainWork.UpdateSecCd;
                // �������t
                depsitMain.DepositDate = depsitMainWork.DepositDate;
                // �v����t
                depsitMain.AddUpADate = depsitMainWork.AddUpADate;
                // ��������R�[�h
                depsitMain.DepositKindCode = depsitMainWork.DepositKindCode;
                // �������햼��
                depsitMain.DepositKindName = depsitMainWork.DepositKindName;
                // ��������敪
                depsitMain.DepositKindDivCd = depsitMainWork.DepositKindDivCd;
                // �����v
                depsitMain.DepositTotal = depsitMainWork.DepositTotal;
                // �������z
                depsitMain.Deposit = depsitMainWork.Deposit;
                // �萔�������z
                depsitMain.FeeDeposit = depsitMainWork.FeeDeposit;
                // �l�������z
                depsitMain.DiscountDeposit = depsitMainWork.DiscountDeposit;
                // ���x�[�g�����z
                // depsitMain.RebateDeposit        = depsitMainWork.RebateDeposit;     // 2007.10.05 del
                // ���������敪
                depsitMain.AutoDepositCd = depsitMainWork.AutoDepositCd;
                // �a����敪
                depsitMain.DepositCd = depsitMainWork.DepositCd;
                // �N���W�b�g�^���[���敪
                // depsitMain.CreditOrLoanCd       = depsitMainWork.CreditOrLoanCd;    // 2007.10.05 del
                // �N���W�b�g��ЃR�[�h
                // depsitMain.CreditCompanyCode    = depsitMainWork.CreditCompanyCode; // 2007.10.05 del
                // ��`�U�o��
                depsitMain.DraftDrawingDate = depsitMainWork.DraftDrawingDate;
                // ��`�x������
                depsitMain.DraftPayTimeLimit = depsitMainWork.DraftPayTimeLimit;
                // ���������z
                depsitMain.DepositAllowance = depsitMainWork.DepositAllowance;
                // ���������c��
                depsitMain.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce;
                // �ԍ������A���ԍ�
                depsitMain.DebitNoteLinkDepoNo = depsitMainWork.DebitNoteLinkDepoNo;
                // �ŏI�������݌v���
                depsitMain.LastReconcileAddUpDt = depsitMainWork.LastReconcileAddUpDt;
                // �����S���҃R�[�h
                depsitMain.DepositAgentCode = depsitMainWork.DepositAgentCode;
                // �����S���Җ���
                depsitMain.DepositAgentNm = depsitMainWork.DepositAgentNm;
                // ������R�[�h
                depsitMain.ClaimCode = depsitMainWork.ClaimCode;
                // �����於��
                depsitMain.ClaimName = depsitMainWork.ClaimName;
                // �����於��2
                depsitMain.ClaimName2 = depsitMainWork.ClaimName2;
                // �����旪��
                depsitMain.ClaimSnm = depsitMainWork.ClaimSnm;
                // ���Ӑ�R�[�h
                depsitMain.CustomerCode = depsitMainWork.CustomerCode;
                // ���Ӑ於��
                depsitMain.CustomerName = depsitMainWork.CustomerName;
                // ���Ӑ於��2
                depsitMain.CustomerName2 = depsitMainWork.CustomerName2;
                // ���Ӑ旪��
                depsitMain.CustomerSnm = depsitMainWork.CustomerSnm;
                // �`�[�E�v
                depsitMain.Outline = depsitMainWork.Outline;
                // �� 20070122 18322 c

                // 2007.10.05 add start ---------------------------------------->>
                // ��s�R�[�h
                depsitMain.BankCode = depsitMainWork.BankCode;

                // ��s����
                depsitMain.BankName = depsitMainWork.BankName;

                // ��`�ԍ�
                depsitMain.DraftNo = depsitMainWork.DraftNo;

                // ��`���
                depsitMain.DraftKind = depsitMainWork.DraftKind;

                // ��`��ޖ���
                depsitMain.DraftKindName = depsitMainWork.DraftKindName;

                // ��`�敪
                depsitMain.DraftDivide = depsitMainWork.DraftDivide;

                // ��`�敪����
                depsitMain.DraftDivideName = depsitMainWork.DraftDivideName;
                // 2007.10.05 add end ------------------------------------------<<

                switch (depsitMain.DepositCd)
                {
                    case 1:
                        depsitMain.DepositNm = "�a���";
                        break;
                    case 2:
                        depsitMain.DepositNm = "��������";
                        break;
                    default:
                        depsitMain.DepositNm = "�ʏ����";
                        break;
                }

                depsitMainList.Add(depsitMain);
            }

            return depsitMainList;
        }

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���������}�X�^���[�N�N���X�˓��������}�X�^�N���X�j
		/// </summary>
		/// <param name="depositAlwWorkList">���������}�X�^���[�N�N���X</param>
		/// <returns>���������}�X�^�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���������}�X�^���[�N�N���X������������}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
        /// <br>Update Note : 2007.01.22 18322 T.Kimura</br>
        /// <br>                MA.NS�p�ɕύX</br>
		/// </remarks>
		private ArrayList CopyToDepositAlwFromDepositAlwWork(DepositAlwWork[] depositAlwWorkList)
		{
			ArrayList depositAlwList = new ArrayList();

			foreach (DepositAlwWork depositAlwWork in depositAlwWorkList)
			{
				SearchDepositAlw depositAlw = new SearchDepositAlw();

                // �� 20070122 18322 c MA.NS�p�ɕύX
                #region SF ���������}�X�^���[�N�N���X�˓��������}�X�^�N���X�i�S�ăR�����g�A�E�g�j
                //depositAlw.CreateDateTime		= depositAlwWork.CreateDateTime;
				//depositAlw.UpdateDateTime		= depositAlwWork.UpdateDateTime;
				//depositAlw.EnterpriseCode		= depositAlwWork.EnterpriseCode;
				//depositAlw.FileHeaderGuid		= depositAlwWork.FileHeaderGuid;
				//depositAlw.UpdEmployeeCode		= depositAlwWork.UpdEmployeeCode;
				//depositAlw.UpdAssemblyId1		= depositAlwWork.UpdAssemblyId1;
				//depositAlw.UpdAssemblyId2		= depositAlwWork.UpdAssemblyId2;
				//depositAlw.LogicalDeleteCode	= depositAlwWork.LogicalDeleteCode;
				//depositAlw.CustomerCode			= depositAlwWork.CustomerCode;
				//depositAlw.AddUpSecCode			= depositAlwWork.AddUpSecCode;
				//depositAlw.AcceptAnOrderNo		= depositAlwWork.AcceptAnOrderNo;
				//depositAlw.DepositSlipNo		= depositAlwWork.DepositSlipNo;
				//depositAlw.DepositKindCode		= depositAlwWork.DepositKindCode;
				//depositAlw.DepositInputDate		= depositAlwWork.DepositInputDate;
				//depositAlw.DepositAllowance		= depositAlwWork.DepositAllowance;
				//depositAlw.ReconcileDate		= depositAlwWork.ReconcileDate;
				//depositAlw.ReconcileAddUpDate	= depositAlwWork.ReconcileAddUpDate;
				//depositAlw.DebitNoteOffSetCd	= depositAlwWork.DebitNoteOffSetCd;
				//depositAlw.DepositCd			= depositAlwWork.DepositCd;
				//depositAlw.CreditOrLoanCd		= depositAlwWork.CreditOrLoanCd;
				//depositAlw.AcpOdrDepositAlwc	= depositAlwWork.AcpOdrDepositAlwc;
                //depositAlw.VarCostDepoAlwc		= depositAlwWork.VarCostDepoAlwc;
                #endregion

                // �쐬����
                depositAlw.CreateDateTime     = depositAlwWork.CreateDateTime;
                // �X�V����
                depositAlw.UpdateDateTime     = depositAlwWork.UpdateDateTime;
                // ��ƃR�[�h
                depositAlw.EnterpriseCode     = depositAlwWork.EnterpriseCode;
                // GUID
                depositAlw.FileHeaderGuid     = depositAlwWork.FileHeaderGuid;
                // �X�V�]�ƈ��R�[�h
                depositAlw.UpdEmployeeCode    = depositAlwWork.UpdEmployeeCode;
                // �X�V�A�Z���u��ID1
                depositAlw.UpdAssemblyId1     = depositAlwWork.UpdAssemblyId1;
                // �X�V�A�Z���u��ID2
                depositAlw.UpdAssemblyId2     = depositAlwWork.UpdAssemblyId2;
                // �_���폜�敪
                depositAlw.LogicalDeleteCode  = depositAlwWork.LogicalDeleteCode;
                // �������͋��_�R�[�h
                depositAlw.InputDepositSecCd  = depositAlwWork.InputDepositSecCd;
                // �v�㋒�_�R�[�h
                depositAlw.AddUpSecCode       = depositAlwWork.AddUpSecCode;
                // �����ݓ�
                depositAlw.ReconcileDate      = depositAlwWork.ReconcileDate;
                // �����݌v���
                depositAlw.ReconcileAddUpDate = depositAlwWork.ReconcileAddUpDate;
                // �����`�[�ԍ�
                depositAlw.DepositSlipNo      = depositAlwWork.DepositSlipNo;

                // ��������R�[�h
                depositAlw.DepositKindCode    = depositAlwWork.DepositKindCode;
                // �������햼��
                depositAlw.DepositKindName    = depositAlwWork.DepositKindName;

                // ���������z
                depositAlw.DepositAllowance   = depositAlwWork.DepositAllowance;
                // �����S���҃R�[�h
                depositAlw.DepositAgentCode   = depositAlwWork.DepositAgentCode;
                // �����S���Җ���
                depositAlw.DepositAgentNm     = depositAlwWork.DepositAgentNm;
                // ���Ӑ�R�[�h
                depositAlw.CustomerCode       = depositAlwWork.CustomerCode;
                // ���Ӑ於��
                depositAlw.CustomerName       = depositAlwWork.CustomerName;
                // ���Ӑ於��2
                depositAlw.CustomerName2      = depositAlwWork.CustomerName2;
                // �󒍔ԍ�
                // depositAlw.AcceptAnOrderNo    = depositAlwWork.AcceptAnOrderNo;   // 2007.10.05 del
                // �T�[�r�X�`�[�敪
                // depositAlw.ServiceSlipCd      = depositAlwWork.ServiceSlipCd;     // 2007.10.05 del
                // �ԓ`���E�敪
                depositAlw.DebitNoteOffSetCd  = depositAlwWork.DebitNoteOffSetCd;

                // �a����敪
                depositAlw.DepositCd = depositAlwWork.DepositCd;

                // �N���W�b�g�^���[���敪
                // depositAlw.CreditOrLoanCd     = depositAlwWork.CreditOrLoanCd;    // 2007.10.05 del
                // �� 20070122 18322 c
                // �󒍃X�e�[�^�X
                depositAlw.AcptAnOdrStatus = depositAlwWork.AcptAnOdrStatus;    // 2007.10.05 add
                // ����`�[�ԍ�
                depositAlw.SalesSlipNum = depositAlwWork.SalesSlipNum;          // 2007.10.05 add

				depositAlwList.Add(depositAlw);
			}

			return depositAlwList;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���������f�[�^�N���X�˓����}�X�^���[�N�N���X�j
		/// </summary>
		/// <param name="depsitMain">���������f�[�^�N���X</param>
		/// <returns>�����}�X�^���[�N�N���X</returns>
		/// <remarks>
		/// <br>Note        : ���������f�[�^�N���X��������}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
        /// <br>Update Note : 2007.01.22 18322 T.Kimura</br>
        /// <br>                MA.NS�p�ɕύX</br>
        /// <br></br>
		/// </remarks>
		private DepsitMainWork CopyToDepsitMainWorkFromDepsitMain(SearchDepsitMain depsitMain)
		{

			DepsitMainWork depsitMainWork = new DepsitMainWork();

            // �� 20070122 18322 c MA.NS�p�ɕύX
            #region SF ���������f�[�^�N���X�˓����}�X�^���[�N�N���X�i�S�ăR�����g�A�E�g�j
            //depsitMainWork.CreateDateTime		= depsitMain.CreateDateTime;
			//depsitMainWork.UpdateDateTime		= depsitMain.UpdateDateTime;
			//depsitMainWork.EnterpriseCode		= depsitMain.EnterpriseCode;
			//depsitMainWork.FileHeaderGuid		= depsitMain.FileHeaderGuid;
			//depsitMainWork.UpdEmployeeCode		= depsitMain.UpdEmployeeCode;
			//depsitMainWork.UpdAssemblyId1		= depsitMain.UpdAssemblyId1;
			//depsitMainWork.UpdAssemblyId2		= depsitMain.UpdAssemblyId2;
			//depsitMainWork.LogicalDeleteCode	= depsitMain.LogicalDeleteCode;
			//depsitMainWork.DepositDebitNoteCd	= depsitMain.DepositDebitNoteCd;
			//depsitMainWork.DepositSlipNo		= depsitMain.DepositSlipNo;
			//depsitMainWork.DepositKindCode		= depsitMain.DepositKindCode;
			//depsitMainWork.CustomerCode			= depsitMain.CustomerCode;
			//depsitMainWork.DepositCd			= depsitMain.DepositCd;
			//depsitMainWork.DepositTotal			= depsitMain.DepositTotal;
			//depsitMainWork.Outline				= depsitMain.Outline;
			//depsitMainWork.AcceptAnOrderSalesNo	= depsitMain.AcceptAnOrderSalesNo;
			//depsitMainWork.InputDepositSecCd	= depsitMain.InputDepositSecCd;
			//depsitMainWork.DepositDate			= depsitMain.DepositDate;
			//depsitMainWork.AddUpSecCode			= depsitMain.AddUpSecCode;
			//depsitMainWork.AddUpADate			= depsitMain.AddUpADate;
			//depsitMainWork.UpdateSecCd			= depsitMain.UpdateSecCd;
			//depsitMainWork.DepositKindName		= depsitMain.DepositKindName;
			//depsitMainWork.DepositAllowance		= depsitMain.DepositAllowance;
			//depsitMainWork.DepositAlwcBlnce		= depsitMain.DepositAlwcBlnce;
			//depsitMainWork.DepositAgentCode		= depsitMain.DepositAgentCode;
			//depsitMainWork.DepositKindDivCd		= depsitMain.DepositKindDivCd;
			//depsitMainWork.FeeDeposit			= depsitMain.FeeDeposit;
			//depsitMainWork.DiscountDeposit		= depsitMain.DiscountDeposit;
			//depsitMainWork.CreditOrLoanCd		= depsitMain.CreditOrLoanCd;
			//depsitMainWork.CreditCompanyCode	= depsitMain.CreditCompanyCode;
			//depsitMainWork.Deposit				= depsitMain.Deposit;
			//depsitMainWork.DraftDrawingDate		= depsitMain.DraftDrawingDate;
			//depsitMainWork.DraftPayTimeLimit	= depsitMain.DraftPayTimeLimit;
			//depsitMainWork.DebitNoteLinkDepoNo	= depsitMain.DebitNoteLinkDepoNo;
			//depsitMainWork.LastReconcileAddUpDt	= depsitMain.LastReconcileAddUpDt;
			//depsitMainWork.AcpOdrDeposit		= depsitMain.AcpOdrDeposit;
			//depsitMainWork.AcpOdrChargeDeposit	= depsitMain.AcpOdrChargeDeposit;
			//depsitMainWork.AcpOdrDisDeposit		= depsitMain.AcpOdrDisDeposit;
			//depsitMainWork.VariousCostDeposit	= depsitMain.VariousCostDeposit;
			//depsitMainWork.VarCostChargeDeposit	= depsitMain.VarCostChargeDeposit;
			//depsitMainWork.VarCostDisDeposit	= depsitMain.VarCostDisDeposit;
			//depsitMainWork.AcpOdrDepositAlwc	= depsitMain.AcpOdrDepositAlwc;
			//depsitMainWork.AcpOdrDepoAlwcBlnce	= depsitMain.AcpOdrDepoAlwcBlnce;
			//depsitMainWork.VarCostDepoAlwc		= depsitMain.VarCostDepoAlwc;
			//depsitMainWork.VarCostDepoAlwcBlnce	= depsitMain.VarCostDepoAlwcBlnce;
            #endregion

            // �쐬����
            depsitMainWork.CreateDateTime       = depsitMain.CreateDateTime;
            // �X�V����
            depsitMainWork.UpdateDateTime       = depsitMain.UpdateDateTime;
            // ��ƃR�[�h
            depsitMainWork.EnterpriseCode       = depsitMain.EnterpriseCode;
            // GUID
            depsitMainWork.FileHeaderGuid       = depsitMain.FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            depsitMainWork.UpdEmployeeCode      = depsitMain.UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            depsitMainWork.UpdAssemblyId1       = depsitMain.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            depsitMainWork.UpdAssemblyId2       = depsitMain.UpdAssemblyId2;
            // �_���폜�敪
            depsitMainWork.LogicalDeleteCode    = depsitMain.LogicalDeleteCode;
            // �����ԍ��敪
            depsitMainWork.DepositDebitNoteCd   = depsitMain.DepositDebitNoteCd;
            // �����`�[�ԍ�
            depsitMainWork.DepositSlipNo        = depsitMain.DepositSlipNo;
            // �󒍔ԍ�
            //depsitMainWork.AcceptAnOrderNo      = depsitMain.AcceptAnOrderNo;   // 2007.10.05 del
            // �T�[�r�X�`�[�敪
            //depsitMainWork.ServiceSlipCd        = depsitMain.ServiceSlipCd;     // 2007.10.05 del
            // �󒍃X�e�[�^�X
            depsitMainWork.AcptAnOdrStatus = depsitMain.AcptAnOdrStatus;          // 2007.10.05 add
            // ����`�[�ԍ�
            depsitMainWork.SalesSlipNum = depsitMain.SalesSlipNum;                // 2007.10.05 add
            // �������͋��_�R�[�h
            depsitMainWork.InputDepositSecCd    = depsitMain.InputDepositSecCd;
            // �v�㋒�_�R�[�h
            depsitMainWork.AddUpSecCode         = depsitMain.AddUpSecCode;
            // �X�V���_�R�[�h
            depsitMainWork.UpdateSecCd          = depsitMain.UpdateSecCd;
            // �������t
            depsitMainWork.DepositDate          = depsitMain.DepositDate;
            // �v����t
            depsitMainWork.AddUpADate           = depsitMain.AddUpADate;

            // ��������R�[�h
            depsitMainWork.DepositKindCode = depsitMain.DepositKindCode;
            // �������햼��
            depsitMainWork.DepositKindName = depsitMain.DepositKindName;
            // ��������敪
            depsitMainWork.DepositKindDivCd = depsitMain.DepositKindDivCd;
            // �����v
            depsitMainWork.DepositTotal = depsitMain.DepositTotal;

            // �������z
            depsitMainWork.Deposit              = depsitMain.Deposit;
            // �萔�������z
            depsitMainWork.FeeDeposit           = depsitMain.FeeDeposit;
            // �l�������z
            depsitMainWork.DiscountDeposit      = depsitMain.DiscountDeposit;
            // ���x�[�g�����z
            // depsitMainWork.RebateDeposit        = depsitMain.RebateDeposit;       // 2007.10.05 del
            // ���������敪
            depsitMainWork.AutoDepositCd        = depsitMain.AutoDepositCd;

            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            // �a����敪
            //depsitMainWork.DepositCd = depsitMain.DepositCd;
            depsitMainWork.DepositCd = 0;
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

            // �N���W�b�g�^���[���敪
            // depsitMainWork.CreditOrLoanCd       = depsitMain.CreditOrLoanCd;      // 2007.10.05 del
            // �N���W�b�g��ЃR�[�h
            // depsitMainWork.CreditCompanyCode    = depsitMain.CreditCompanyCode;   // 2007.10.05 del
            // ��`�U�o��
            depsitMainWork.DraftDrawingDate     = depsitMain.DraftDrawingDate;

            // ��`�x������
            depsitMainWork.DraftPayTimeLimit = depsitMain.DraftPayTimeLimit;
            // ���������z
            depsitMainWork.DepositAllowance = depsitMain.DepositAllowance;
            // ���������c��
            depsitMainWork.DepositAlwcBlnce = depsitMain.DepositAlwcBlnce;

            // �ԍ������A���ԍ�
            depsitMainWork.DebitNoteLinkDepoNo  = depsitMain.DebitNoteLinkDepoNo;
            // �ŏI�������݌v���
            depsitMainWork.LastReconcileAddUpDt = depsitMain.LastReconcileAddUpDt;
            // �����S���҃R�[�h
            depsitMainWork.DepositAgentCode     = depsitMain.DepositAgentCode;
            // �����S���Җ���
            depsitMainWork.DepositAgentNm       = depsitMain.DepositAgentNm;
            // ������R�[�h
            depsitMainWork.ClaimCode            = depsitMain.ClaimCode;
            // �����於��
            depsitMainWork.ClaimName            = depsitMain.ClaimName;
            // �����於��2
            depsitMainWork.ClaimName2           = depsitMain.ClaimName2;
            // �����旪��
            depsitMainWork.ClaimSnm             = depsitMain.ClaimSnm;
            // ���Ӑ�R�[�h
            depsitMainWork.CustomerCode         = depsitMain.CustomerCode;
            // ���Ӑ於��
            depsitMainWork.CustomerName         = depsitMain.CustomerName;
            // ���Ӑ於��2
            depsitMainWork.CustomerName2        = depsitMain.CustomerName2;
            // ���Ӑ旪��
            depsitMainWork.CustomerSnm          = depsitMain.CustomerSnm;
            // �`�[�E�v
            depsitMainWork.Outline              = depsitMain.Outline;
            // �� 20070122 18322 c

            // 2007.10.05 add start ---------------------------------------->>
            // ��s�R�[�h
            depsitMainWork.BankCode = depsitMain.BankCode;

            // ��s����
            depsitMainWork.BankName = depsitMain.BankName;

            // ��`�ԍ�
            depsitMainWork.DraftNo = depsitMain.DraftNo;

            // ��`���
            depsitMainWork.DraftKind = depsitMain.DraftKind;

            // ��`��ޖ���
            depsitMainWork.DraftKindName = depsitMain.DraftKindName;

            // ��`�敪
            depsitMainWork.DraftDivide = depsitMain.DraftDivide;

            // ��`�敪����
            depsitMainWork.DraftDivideName = depsitMain.DraftDivideName;
            // 2007.10.05 add end ------------------------------------------<<

            return depsitMainWork;
		}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���������f�[�^�N���X�˓����}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="depsitMain">���������f�[�^�N���X</param>
        /// <returns>�����}�X�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note        : ���������f�[�^�N���X��������}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br></br>
        /// </remarks>
        private DepsitDataWork CopyToDepsitDataWorkFromDepsitMain(SearchDepsitMain depsitMain)
        {
            DepsitDataWork depsitDataWork = new DepsitDataWork();

            // �쐬����
            depsitDataWork.CreateDateTime = depsitMain.CreateDateTime;
            // �X�V����
            depsitDataWork.UpdateDateTime = depsitMain.UpdateDateTime;
            // ��ƃR�[�h
            depsitDataWork.EnterpriseCode = depsitMain.EnterpriseCode;
            // GUID
            depsitDataWork.FileHeaderGuid = depsitMain.FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            depsitDataWork.UpdEmployeeCode = depsitMain.UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            depsitDataWork.UpdAssemblyId1 = depsitMain.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            depsitDataWork.UpdAssemblyId2 = depsitMain.UpdAssemblyId2;
            // �_���폜�敪
            depsitDataWork.LogicalDeleteCode = depsitMain.LogicalDeleteCode;
            // �����ԍ��敪
            depsitDataWork.DepositDebitNoteCd = depsitMain.DepositDebitNoteCd;
            // �����`�[�ԍ�
            depsitDataWork.DepositSlipNo = depsitMain.DepositSlipNo;
            // �󒍃X�e�[�^�X
            depsitDataWork.AcptAnOdrStatus = depsitMain.AcptAnOdrStatus;
            // ����`�[�ԍ�
            depsitDataWork.SalesSlipNum = depsitMain.SalesSlipNum;
            // �������͋��_�R�[�h
            depsitDataWork.InputDepositSecCd = depsitMain.InputDepositSecCd;
            // �v�㋒�_�R�[�h
            depsitDataWork.AddUpSecCode = depsitMain.AddUpSecCode;
            // �X�V���_�R�[�h
            depsitDataWork.UpdateSecCd = depsitMain.UpdateSecCd;
            // �������t
            depsitDataWork.DepositDate = depsitMain.DepositDate;
            // �v����t
            depsitDataWork.AddUpADate = depsitMain.AddUpADate;
            // �������z
            depsitDataWork.Deposit = depsitMain.Deposit;
            // �萔�������z
            depsitDataWork.FeeDeposit = depsitMain.FeeDeposit;
            // �l�������z
            depsitDataWork.DiscountDeposit = depsitMain.DiscountDeposit;
            // ���������敪
            depsitDataWork.AutoDepositCd = depsitMain.AutoDepositCd;
            // �a����敪
            depsitDataWork.DepositCd = 0;
            // ��`�U�o��
            depsitDataWork.DraftDrawingDate = depsitMain.DraftDrawingDate;
            // �ԍ������A���ԍ�
            depsitDataWork.DebitNoteLinkDepoNo = depsitMain.DebitNoteLinkDepoNo;
            // �ŏI�������݌v���
            depsitDataWork.LastReconcileAddUpDt = depsitMain.LastReconcileAddUpDt;
            // �����S���҃R�[�h
            depsitDataWork.DepositAgentCode = depsitMain.DepositAgentCode;
            // �����S���Җ���
            depsitDataWork.DepositAgentNm = depsitMain.DepositAgentNm;
            // ������R�[�h
            depsitDataWork.ClaimCode = depsitMain.ClaimCode;
            // �����於��
            depsitDataWork.ClaimName = depsitMain.ClaimName;
            // �����於��2
            depsitDataWork.ClaimName2 = depsitMain.ClaimName2;
            // �����旪��
            depsitDataWork.ClaimSnm = depsitMain.ClaimSnm;
            // ���Ӑ�R�[�h
            depsitDataWork.CustomerCode = depsitMain.CustomerCode;
            // ���Ӑ於��
            depsitDataWork.CustomerName = depsitMain.CustomerName;
            // ���Ӑ於��2
            depsitDataWork.CustomerName2 = depsitMain.CustomerName2;
            // ���Ӑ旪��
            depsitDataWork.CustomerSnm = depsitMain.CustomerSnm;
            // �`�[�E�v
            depsitDataWork.Outline = depsitMain.Outline;
            // ��s�R�[�h
            depsitDataWork.BankCode = depsitMain.BankCode;
            // ��s����
            depsitDataWork.BankName = depsitMain.BankName;
            // ��`�ԍ�
            depsitDataWork.DraftNo = depsitMain.DraftNo;
            // ��`���
            depsitDataWork.DraftKind = depsitMain.DraftKind;
            // ��`��ޖ���
            depsitDataWork.DraftKindName = depsitMain.DraftKindName;
            // ��`�敪
            depsitDataWork.DraftDivide = depsitMain.DraftDivide;
            // ��`�敪����
            depsitDataWork.DraftDivideName = depsitMain.DraftDivideName;

            return depsitDataWork;
        }

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���������}�X�^�N���X�˓��������}�X�^���[�N�N���X�j
		/// </summary>
		/// <param name="depositAlwList">���������}�X�^�N���X</param>
		/// <returns>�����}�X�^���[�N�N���X</returns>
		/// <remarks>
		/// <br>Note        : ���������}�X�^�N���X��������}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
        /// <br>Update Note : 2007.01.22 18322 T.Kimura</br>
        /// <br>                MA.NS�p�ɕύX</br>
        /// <br></br>
		/// </remarks>
		private DepositAlwWork[] CopyToDepositAlwWorkFromDepositAlw(Hashtable depositAlwList)
		{
			ArrayList arrDepositAlw = new ArrayList();

			foreach (DictionaryEntry de in depositAlwList)
			{
				SearchDepositAlw depositAlw = (SearchDepositAlw)de.Value;
				DepositAlwWork depositAlwWork = new DepositAlwWork();

                // �� 20070122 18322 c MA.NS�p�ɕύX
                #region SF ���������}�X�^�N���X�˓��������}�X�^���[�N�N���X�i�S�ăR�����g�A�E�g�j
                //depositAlwWork.CreateDateTime		= depositAlw.CreateDateTime;
				//depositAlwWork.UpdateDateTime		= depositAlw.UpdateDateTime;
				//depositAlwWork.EnterpriseCode		= depositAlw.EnterpriseCode;
				//depositAlwWork.FileHeaderGuid		= depositAlw.FileHeaderGuid;
				//depositAlwWork.UpdEmployeeCode		= depositAlw.UpdEmployeeCode;
				//depositAlwWork.UpdAssemblyId1		= depositAlw.UpdAssemblyId1;
				//depositAlwWork.UpdAssemblyId2		= depositAlw.UpdAssemblyId2;
				//depositAlwWork.LogicalDeleteCode	= depositAlw.LogicalDeleteCode;
				//depositAlwWork.CustomerCode			= depositAlw.CustomerCode;
				//depositAlwWork.AddUpSecCode			= depositAlw.AddUpSecCode;
				//depositAlwWork.AcceptAnOrderNo		= depositAlw.AcceptAnOrderNo;
				//depositAlwWork.DepositSlipNo		= depositAlw.DepositSlipNo;
				//depositAlwWork.DepositKindCode		= depositAlw.DepositKindCode;
				//depositAlwWork.DepositInputDate		= depositAlw.DepositInputDate;
				//depositAlwWork.DepositAllowance		= depositAlw.DepositAllowance;
				//depositAlwWork.ReconcileDate		= depositAlw.ReconcileDate;
				//depositAlwWork.ReconcileAddUpDate	= depositAlw.ReconcileAddUpDate;
				//depositAlwWork.DebitNoteOffSetCd	= depositAlw.DebitNoteOffSetCd;
				//depositAlwWork.DepositCd			= depositAlw.DepositCd;
				//depositAlwWork.CreditOrLoanCd		= depositAlw.CreditOrLoanCd;
				//depositAlwWork.AcpOdrDepositAlwc	= depositAlw.AcpOdrDepositAlwc;
				//depositAlwWork.VarCostDepoAlwc		= depositAlw.VarCostDepoAlwc;
                #endregion 

                // �쐬����
                depositAlwWork.CreateDateTime     = depositAlw.CreateDateTime;
                // �X�V����
                depositAlwWork.UpdateDateTime     = depositAlw.UpdateDateTime;
                // ��ƃR�[�h
                depositAlwWork.EnterpriseCode     = depositAlw.EnterpriseCode;
                // GUID
                depositAlwWork.FileHeaderGuid     = depositAlw.FileHeaderGuid;
                // �X�V�]�ƈ��R�[�h
                depositAlwWork.UpdEmployeeCode    = depositAlw.UpdEmployeeCode;
                // �X�V�A�Z���u��ID1
                depositAlwWork.UpdAssemblyId1     = depositAlw.UpdAssemblyId1;
                // �X�V�A�Z���u��ID2
                depositAlwWork.UpdAssemblyId2     = depositAlw.UpdAssemblyId2;
                // �_���폜�敪
                depositAlwWork.LogicalDeleteCode  = depositAlw.LogicalDeleteCode;
                // �������͋��_�R�[�h
                depositAlwWork.InputDepositSecCd  = depositAlw.InputDepositSecCd;
                // �v�㋒�_�R�[�h
                depositAlwWork.AddUpSecCode       = depositAlw.AddUpSecCode;
                // �����ݓ�
                depositAlwWork.ReconcileDate      = depositAlw.ReconcileDate;
                // �����݌v���
                depositAlwWork.ReconcileAddUpDate = depositAlw.ReconcileAddUpDate;
                // �����`�[�ԍ�
                depositAlwWork.DepositSlipNo      = depositAlw.DepositSlipNo;

                // ��������R�[�h
                depositAlwWork.DepositKindCode    = depositAlw.DepositKindCode;
                // �������햼��
                depositAlwWork.DepositKindName    = depositAlw.DepositKindName;

                // ���������z
                depositAlwWork.DepositAllowance   = depositAlw.DepositAllowance;
                // �����S���҃R�[�h
                depositAlwWork.DepositAgentCode   = depositAlw.DepositAgentCode;
                // �����S���Җ���
                depositAlwWork.DepositAgentNm     = depositAlw.DepositAgentNm;
                // ���Ӑ�R�[�h
                depositAlwWork.CustomerCode       = depositAlw.CustomerCode;
                // ���Ӑ於��
                depositAlwWork.CustomerName       = depositAlw.CustomerName;
                // ���Ӑ於��2
                depositAlwWork.CustomerName2      = depositAlw.CustomerName2;
                // �󒍔ԍ�
                // depositAlwWork.AcceptAnOrderNo    = depositAlw.AcceptAnOrderNo; // 2007.10.05 del
                // �󒍃X�e�[�^�X
                depositAlwWork.AcptAnOdrStatus = depositAlw.AcptAnOdrStatus;       // 2007.10.05 add
                // ����`�[�ԍ�
                depositAlwWork.SalesSlipNum = depositAlw.SalesSlipNum;             // 2007.10.05 add
                // �T�[�r�X�`�[�敪
                // depositAlwWork.ServiceSlipCd      = depositAlw.ServiceSlipCd;   // 2007.10.05 del
                // �ԓ`���E�敪
                depositAlwWork.DebitNoteOffSetCd  = depositAlw.DebitNoteOffSetCd;

                // �a����敪
                depositAlwWork.DepositCd = depositAlw.DepositCd;

                // �N���W�b�g�^���[���敪
                // depositAlwWork.CreditOrLoanCd     = depositAlw.CreditOrLoanCd;  // 2007.10.05 del
                // �� 20070122 18322 c

                arrDepositAlw.Add(depositAlwWork);
			}

			DepositAlwWork[] list = (DepositAlwWork[])arrDepositAlw.ToArray(typeof(DepositAlwWork));

			return list;
		}

           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        # endregion

        # region Public class (parameter)

        # region Public class SearchCustomerParameter
        /// <summary>���Ӑ���/���Ӑ���z���擾�p�p�����[�^</summary>
		public class SearchCustomerParameter
		{
			/// <summary>�R���X�g���N�^</summary>
			public SearchCustomerParameter()
			{
				_enterpriseCode = "";
				_addUpSecCod = "";
				_addUpADate = 0;
				_customerCode = 0;
                _claimCode = 0;
			}

			/// <summary>��ƃR�[�h</summary>
			private string _enterpriseCode;
			/// <summary>�v�㋒�_</summary>
			private string _addUpSecCod;
			/// <summary>�v���</summary>
			private Int32 _addUpADate;
			/// <summary>���Ӑ�R�[�h</summary>
			private Int32 _customerCode;
            /// <summary>������R�[�h</summary>
            private Int32 _claimCode;

			/// <summary>��ƃR�[�h �v���p�e�B</summary>
			public string EnterpriseCode
			{
				get{return _enterpriseCode;}
				set{_enterpriseCode = value;}
			}
			/// <summary>�v�㋒�_ �v���p�e�B</summary>
			public string AddUpSecCod
			{
				get{return _addUpSecCod;}
				set{_addUpSecCod = value;}
			}
			/// <summary>�v��� �v���p�e�B</summary>
			public Int32 AddUpADate
			{
				get{return _addUpADate;}
				set{_addUpADate = value;}
			}
			/// <summary>���Ӑ�R�[�h �v���p�e�B</summary>
			public Int32 CustomerCode
			{
				get{return _customerCode;}
				set{_customerCode = value;}
			}
            /// <summary>������R�[�h �v���p�e�B</summary>
            public Int32 ClaimCode
            {
                get { return _claimCode; }
                set { _claimCode = value; }
            }
		}
		# endregion

		# region Public class SearchDepositParameter
        // �� 20070125 18322 c MA.NS�p�ɕύX
        #region SF �������/�������擾�p�p�����[�^�i�S�ăR�����g�A�E�g�j
        ///// <summary>�������/�������擾�p�p�����[�^</summary>
		//public class SearchDepositParameter
		//{
		//	/// <summary>�R���X�g���N�^</summary>
		//	public SearchDepositParameter()
		//	{
		//		_enterpriseCode = "";
		//		_addUpSecCod = "";
		//		_customerCode = 0;
		//		_depositSlipNo = 0;
		//		_acceptAnOrderNo = 0;
		//		_depositDateStart = 0;
		//		_depositDateEnd = 0;
		//		_alwcDepositCall = 0;
		//	}
		//
		//	/// <summary>��ƃR�[�h</summary>
		//	private string _enterpriseCode;
		//	/// <summary>�v�㋒�_</summary>
		//	private string _addUpSecCod;
		//	/// <summary>���Ӑ�R�[�h</summary>
		//	private Int32 _customerCode;
		//	/// <summary>�����`�[�ԍ�</summary>
		//	private Int32 _depositSlipNo;
		//	/// <summary>�󒍔ԍ�</summary>
		//	private Int32 _acceptAnOrderNo;
		//	/// <summary>������ �J�n</summary>
		//	private Int32 _depositDateStart;
		//	/// <summary>������ �I��</summary>
		//	private Int32 _depositDateEnd;
		//	/// <summary>�����ϓ����`�[�ďo�敪</summary>
		//	private Int32 _alwcDepositCall;
		//
		//	/// <summary>��ƃR�[�h �v���p�e�B</summary>
		//	public string EnterpriseCode
		//	{
		//		get{return _enterpriseCode;}
		//		set{_enterpriseCode = value;}
		//	}
		//	/// <summary>�v�㋒�_ �v���p�e�B</summary>
		//	public string AddUpSecCod
		//	{
		//		get{return _addUpSecCod;}
		//		set{_addUpSecCod = value;}
		//	}
		//	/// <summary>���Ӑ�R�[�h �v���p�e�B</summary>
		//	public Int32 CustomerCode
		//	{
		//		get{return _customerCode;}
		//		set{_customerCode = value;}
		//	}
		//	/// <summary>�����`�[�ԍ� �v���p�e�B</summary>
		//	public Int32 DepositSlipNo
		//	{
		//		get{return _depositSlipNo;}
		//		set{_depositSlipNo = value;}
		//	}
		//	/// <summary>�󒍔ԍ� �v���p�e�B</summary>
		//	public Int32 AcceptAnOrderNo
		//	{
		//		get{return _acceptAnOrderNo;}
		//		set{_acceptAnOrderNo = value;}
		//	}
		//	/// <summary>������ �J�n �v���p�e�B</summary>
		//	public Int32 DepositDateStart
		//	{
		//		get{return _depositDateStart;}
		//		set{_depositDateStart = value;}
		//	}
		//	/// <summary>������ �I�� �v���p�e�B</summary>
		//	public Int32 DepositDateEnd
		//	{
		//		get{return _depositDateEnd;}
		//		set{_depositDateEnd = value;}
		//	}
		//	/// <summary>�����ϓ����`�[�ďo�敪 �v���p�e�B</summary>
		//	public Int32 AlwcDepositCall
		//	{
		//		get{return _alwcDepositCall;}
		//		set{_alwcDepositCall = value;}
		//	}
        //}
        #endregion

		/// public class name:   SearchDepositParameter
		/// <summary>
		///                      �������^�������擾�p�p�����[�^
		/// </summary>
		/// <remarks>
		/// <br>note             :   �������^�������擾�p�p�����[�^�w�b�_�t�@�C��</br>
		/// <br>Programmer       :   ��������</br>
		/// <br>Date             :   �ؑ� ����</br>
		/// <br>Genarated Date   :   2007/02/01  (CSharp File Generated Date)</br>
		/// <br>Update Note      :   </br>
		/// </remarks>
		public class SearchDepositParameter
		{
			/// <summary>��ƃR�[�h</summary>
			/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
			private string _enterpriseCode = "";
	
			/// <summary>�v�㋒�_�R�[�h</summary>
			/// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
			private string _addUpSecCode = "";

            /// <summary>������R�[�h</summary>
            private Int32 _claimCode;

			/// <summary>���Ӑ�R�[�h</summary>
			private Int32 _customerCode;
	
			///// <summary>�󒍔ԍ�</summary>
			// private Int32 _acceptAnOrderNo;   // 2007.10.05 del
	
			/// <summary>�󒍃X�e�[�^�X</summary>
			/// <remarks>10:����,20:��,30:����,40:�o��</remarks>
			private Int32 _acptAnOdrStatus;
	
			/// <summary>����`�[�ԍ�</summary>
			private string _salesSlipNum = "";
	
			///// <summary>�󒍓`�[�ԍ�</summary>
            //private Int32 _acptAnOdrSlipNum;  // 2007.10.05 del
	
			/// <summary>�����`�[�ԍ�</summary>
			private Int32 _depositSlipNo;
	
			/// <summary>������(�J�n)</summary>
			/// <remarks>YYYYMMDD</remarks>
			private Int32 _depositCallMonthsStart;
	
			/// <summary>������(�I��)</summary>
			/// <remarks>YYYYMMDD</remarks>
			private Int32 _depositCallMonthsEnd;
	
			/// <summary>�����ϓ����`�[�ďo�敪</summary>
			private Int32 _alwcDepositCall;
	
	
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
	
			/// public propaty name  :  AddUpSecCode
			/// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
			/// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public string AddUpSecCode
			{
				get{return _addUpSecCode;}
				set{_addUpSecCode = value;}
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
                get { return _claimCode; }
                set { _claimCode = value; }
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
	
            // 2007.10.05 hikita del start ------------------------------------------------>>
            ///// public propaty name  :  AcceptAnOrderNo
            ///// <summary>�󒍔ԍ��v���p�e�B</summary>
            ///// ----------------------------------------------------------------------
            ///// <remarks>
            ///// <br>note             :   �󒍔ԍ��v���p�e�B</br>
            ///// <br>Programer        :   ��������</br>
            ///// </remarks>
            //public Int32 AcceptAnOrderNo
            //{
            //    get{return _acceptAnOrderNo;}
            //    set{_acceptAnOrderNo = value;}
            //}
            // 2007.10.05 hikita del end --------------------------------------------------<<
	
			/// public propaty name  :  AcptAnOdrStatus
			/// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
			/// <value>1:�\��,2:�\��L�����Z��,10:����,11:���σL�����Z��20:��,21:�󒍃L�����Z��,30:����,40:����,45:���،v��,50:�ϑ�,55:�ϑ��v��</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public Int32 AcptAnOdrStatus
			{
				get{return _acptAnOdrStatus;}
				set{_acptAnOdrStatus = value;}
			}
	
			/// public propaty name  :  SalesSlipNum
			/// <summary>����`�[�ԍ��v���p�e�B</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public string SalesSlipNum
			{
				get{return _salesSlipNum;}
				set{_salesSlipNum = value;}
			}

            // 2007.10.05 del start ------------------------------------------------>>
            ///// public propaty name  :  AcptAnOdrSlipNum
            ///// <summary>�󒍓`�[�ԍ��v���p�e�B</summary>
            ///// ----------------------------------------------------------------------
            ///// <remarks>
            ///// <br>note             :   �󒍓`�[�ԍ��v���p�e�B</br>
            ///// <br>Programer        :   ��������</br>
            ///// </remarks>
            //public Int32 AcptAnOdrSlipNum
            //{
            //    get{return _acptAnOdrSlipNum;}
            //    set{_acptAnOdrSlipNum = value;}
            //}
            // 2007.10.05 del end --------------------------------------------------<<

			/// public propaty name  :  DepositSlipNo
			/// <summary>�����`�[�ԍ��v���p�e�B</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public Int32 DepositSlipNo
			{
				get{return _depositSlipNo;}
				set{_depositSlipNo = value;}
			}
	
			/// public propaty name  :  DepositCallMonthsStart
			/// <summary>������(�J�n)�v���p�e�B</summary>
			/// <value>YYYYMMDD</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   ������(�J�n)�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public Int32 DepositCallMonthsStart
			{
				get{return _depositCallMonthsStart;}
				set{_depositCallMonthsStart = value;}
			}
	
			/// public propaty name  :  DepositCallMonthsEnd
			/// <summary>������(�I��)�v���p�e�B</summary>
			/// <value>YYYYMMDD</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   ������(�I��)�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public Int32 DepositCallMonthsEnd
			{
				get{return _depositCallMonthsEnd;}
				set{_depositCallMonthsEnd = value;}
			}
	
			/// public propaty name  :  AlwcDepositCall
			/// <summary>�����ϓ����`�[�ďo�敪�v���p�e�B</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �����ϓ����`�[�ďo�敪�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public Int32 AlwcDepositCall
			{
				get{return _alwcDepositCall;}
				set{_alwcDepositCall = value;}
			}
	
	
			/// <summary>
			/// �������^�������擾�p�p�����[�^�R���X�g���N�^
			/// </summary>
			/// <returns>SearchDepositParameter�N���X�̃C���X�^���X</returns>
			/// <remarks>
			/// <br>Note�@�@�@�@�@�@ :   SearchDepositParameter�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public SearchDepositParameter()
			{
			}
	
		}
        # endregion

        // �� 20070122 18322 c MA.NS�p�ɕύX
		# region Public class SearchSalesParameter(�R�����g�A�E�g)
		///// <summary>����������擾�p�p�����[�^</summary>
		//public class SearchSalesParameter
		//{
		//	/// <summary>�R���X�g���N�^</summary>
		//	public SearchSalesParameter()
		//	{
		//		_enterpriseCode = "";
		//		_addUpSecCod = "";
		//		_customerCode = 0;
		//		_acceptAnOrderNo = 0;
		//		_slipNo = "";
		//		_searchSlipDateStart = 0;
		//		_searchSlipDateEnd = 0;
		//		_addUpADateStart = 0;
		//		_addUpADateEnd = 0;
		//		_alwcDmdSalesCall = 0;
		//		_acptAnOdrStatus = null;
		//		_dataInputSystem = null;
		//		_autoAuctionDiv = 0;
		//		_creditOrLoanCd = null;
		//		_creditCompanyCode = "";
		//		_salesEmployeeCd = "";
		//		_acceptAnOrderDateStart = 0;
		//		_acceptAnOrderDateEnd = 0;
		//		_carDeliExpectedDateStart = 0;
		//		_carDeliExpectedDateEnd = 0;
		//	}
        //
		//	/// <summary>��ƃR�[�h</summary>
		//	private string _enterpriseCode;
		//	/// <summary>�v�㋒�_</summary>
		//	private string _addUpSecCod;
		//	/// <summary>���Ӑ�R�[�h</summary>
		//	private Int32 _customerCode;
		//	/// <summary>�󒍓`�[�ԍ�</summary>
		//	private Int32 _acceptAnOrderNo;
		//	/// <summary>�`�[�ԍ�</summary>
		//	private string _slipNo;
		//	/// <summary>�`�[���t �J�n</summary>
		//	private Int32 _searchSlipDateStart;
		//	/// <summary>�`�[���t �I��</summary>
		//	private Int32 _searchSlipDateEnd;
		//	/// <summary>�󒍌v��� �J�n</summary>
		//	private Int32 _addUpADateStart;
		//	/// <summary>�󒍌v��� �I��</summary>
		//	private Int32 _addUpADateEnd;
		//	/// <summary>�����ϐ�������`�[�ďo�敪</summary>
		//	private Int32 _alwcDmdSalesCall;
		//	/// <summary>�󒍃X�e�[�^�X</summary>
		//	private Int32[] _acptAnOdrStatus;
		//	/// <summary>�f�[�^���̓V�X�e��</summary>
		//	private Int32[] _dataInputSystem;
		//	/// <summary>AA���o�敪</summary>
		//	private Int32 _autoAuctionDiv;
		//	/// <summary>�N���W�b�g�E���[���敪</summary>
		//	private Int32[] _creditOrLoanCd;
		//	/// <summary>�N���W�b�g��ЃR�[�h</summary>
		//	private string _creditCompanyCode;
		//	/// <summary>�̔��]�ƈ��R�[�h</summary>
		//	private string _salesEmployeeCd;
		//	/// <summary>�󒍓�(�J�n)</summary>
		//	private Int32 _acceptAnOrderDateStart;
		//	/// <summary>�󒍓�(�I��)</summary>
		//	private Int32 _acceptAnOrderDateEnd;
		//	/// <summary>�[�ԗ\���(�J�n)</summary>
		//	private Int32 _carDeliExpectedDateStart;
		//	/// <summary>�[�ԗ\���(�I��)</summary>
		//	private Int32 _carDeliExpectedDateEnd;
		//	
		//	/// <summary>��ƃR�[�h �v���p�e�B</summary>
		//	public string EnterpriseCode
		//	{
		//		get{return _enterpriseCode;}
		//		set{_enterpriseCode = value;}
		//	}
		//	/// <summary>�v�㋒�_ �v���p�e�B</summary>
		//	public string AddUpSecCod
		//	{
		//		get{return _addUpSecCod;}
		//		set{_addUpSecCod = value;}
		//	}
		//	/// <summary>���Ӑ�R�[�h �v���p�e�B</summary>
		//	public Int32 CustomerCode
		//	{
		//		get{return _customerCode;}
		//		set{_customerCode = value;}
		//	}
		//	/// <summary>�󒍓`�[�ԍ� �v���p�e�B</summary>
		//	public Int32 AcceptAnOrderNo
		//	{
		//		get{return _acceptAnOrderNo;}
		//		set{_acceptAnOrderNo = value;}
		//	}
		//	/// <summary>�`�[�ԍ� �v���p�e�B</summary>
		//	public string SlipNo
		//	{
		//		get{return _slipNo;}
		//		set{_slipNo = value;}
		//	}
		//	/// <summary>�`�[���t �J�n �v���p�e�B</summary>
		//	public Int32 SearchSlipDateStart
		//	{
		//		get{return _searchSlipDateStart;}
		//		set{_searchSlipDateStart = value;}
		//	}
		//	/// <summary>�`�[���t �I�� �v���p�e�B</summary>
		//	public Int32 SearchSlipDateEnd
		//	{
		//		get{return _searchSlipDateEnd;}
		//		set{_searchSlipDateEnd = value;}
		//	}
		//	/// <summary>�󒍌v��� �J�n �v���p�e�B</summary>
		//	public Int32 AddUpADateStart
		//	{
		//		get{return _addUpADateStart;}
		//		set{_addUpADateStart = value;}
		//	}
		//	/// <summary>�󒍌v��� �I�� �v���p�e�B</summary>
		//	public Int32 AddUpADateEnd
		//	{
		//		get{return _addUpADateEnd;}
		//		set{_addUpADateEnd = value;}
		//	}
		//	/// <summary>�����ϐ�������`�[�ďo�敪 �v���p�e�B</summary>
		//	public Int32 AlwcDmdSalesCall
		//	{
		//		get{return _alwcDmdSalesCall;}
		//		set{_alwcDmdSalesCall = value;}
		//	}
		//	/// <summary>�󒍃X�e�[�^�X �v���p�e�B</summary>
		//	public Int32[] AcptAnOdrStatus
		//	{
		//		get{return _acptAnOdrStatus;}
		//		set{_acptAnOdrStatus = value;}
		//	}
		//	/// <summary>�f�[�^���̓V�X�e�� �v���p�e�B</summary>
		//	public Int32[] DataInputSystem
		//	{
		//		get{return _dataInputSystem;}
		//		set{_dataInputSystem = value;}
		//	}
		//	/// <summary>AA���o�敪</summary>
		//	public Int32 AutoAuctionDiv
		//	{
		//		get{return _autoAuctionDiv;}
		//		set{_autoAuctionDiv = value;}
		//	}
		//	/// <summary>�N���W�b�g�E���[���敪</summary>
		//	public Int32[] CreditOrLoanCd
		//	{
		//		get{return _creditOrLoanCd;}
		//		set{_creditOrLoanCd = value;}
		//	}
		//	/// <summary>�N���W�b�g��ЃR�[�h</summary>
		//	public string CreditCompanyCode
		//	{
		//		get{return _creditCompanyCode;}
		//		set{_creditCompanyCode = value;}
		//	}
		//	/// <summary>�̔��]�ƈ��R�[�h</summary>
		//	public string SalesEmployeeCd
		//	{
		//		get{return _salesEmployeeCd;}
		//		set{_salesEmployeeCd = value;}
		//	}
		//	/// <summary>�󒍓�(�J�n)</summary>
		//	public Int32 AcceptAnOrderDateStart
		//	{
		//		get{return _acceptAnOrderDateStart;}
		//		set{_acceptAnOrderDateStart = value;}
		//	}
		//	/// <summary>�󒍓�(�I��)</summary>
		//	public Int32 AcceptAnOrderDateEnd
		//	{
		//		get{return _acceptAnOrderDateEnd;}
		//		set{_acceptAnOrderDateEnd = value;}
		//	}
		//	/// <summary>�[�ԗ\���(�J�n)</summary>
		//	public Int32 CarDeliExpectedDateStart
		//	{
		//		get{return _carDeliExpectedDateStart;}
		//		set{_carDeliExpectedDateStart = value;}
		//	}
		//	/// <summary>�[�ԗ\���(�I��)</summary>
		//	public Int32 CarDeliExpectedDateEnd
		//	{
		//		get{return _carDeliExpectedDateEnd;}
		//		set{_carDeliExpectedDateEnd = value;}
		//	}
		//}
		# endregion

        #region MA.NS ����������擾�p�p�����[�^
		/// <summary>����������擾�p�p�����[�^</summary>
		/// <remarks>�R���X�g���N�^�������AMAHNB01216D�̃p�����[�^�Ɠ��l�ł��B</remarks>
        //     �� �����ϔ���`�[�ďo�敪�̏����l�u-1�v�ɒ���
        public class SearchSalesParameter
		{
			/// <summary>�R���X�g���N�^</summary>
			public SearchSalesParameter()
			{
				// <summary>��ƃR�[�h</summary>
				_enterpriseCode = "";
		
				// <summary>�󒍃X�e�[�^�X</summary>
				_acptAnOdrStatus = null;
		
				// <summary>����`�[�ԍ�</summary>
				_salesSlipNum = "";
		
				// <summary>���Ӑ�R�[�h</summary>
				_customerCode = 0;

                // <summary>������R�[�h</summary>
                _claimCode = 0;

				// <summary>�v����t(�J�n)</summary>
				_addUpADateStart = 0;
		
				// <summary>�v����t(�I��)</summary>
				_addUpADateEnd = 0;

				// <summary>�����v�㋒�_�R�[�h</summary>
				_demandAddUpSecCd = "";
		
				// <summary>���ьv�㋒�_�R�[�h</summary>
				_resultsAddUpSecCd = "";

				// <summary>�����ϔ���`�[�ďo�敪</summary>
				_alwcSalesSlipCall = -1;

				// <summary>�̔��]�ƈ��R�[�h</summary>
				_salesEmployeeCd = "";

				// <summary>�`�[�������t(�J�n)</summary>
				_searchSlipDateStart = 0;
		
				// <summary>�`�[�������t(�I��)</summary>
				_searchSlipDateEnd = 0;

                // <summary>�T�[�r�X�`�[�敪</summary>
                _serviceSlipCd = 0;

                // <summary>���|�敪</summary>
                _accRecDivCd = 0;

                // <summary>���������敪</summary>
                _autoDepositCd = 0;
			}

			/// <summary>��ƃR�[�h</summary>
			/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
			private string _enterpriseCode = "";
	
			/// <summary>�󒍃X�e�[�^�X</summary>
			/// <remarks>10:����,20:��,30:����,40:�o��</remarks>
			private Int32[] _acptAnOdrStatus;
	
			/// <summary>����`�[�ԍ�</summary>
			private string _salesSlipNum = "";
	
			/// <summary>���Ӑ�R�[�h</summary>
			private Int32 _customerCode;

            /// <summary>������R�[�h</summary>
            private Int32 _claimCode;

			/// <summary>�v����t(�J�n)</summary>
			/// <remarks>YYYYMMDD</remarks>
			private Int32 _addUpADateStart;
	
			/// <summary>�v����t(�I��)</summary>
			/// <remarks>YYYYMMDD</remarks>
			private Int32 _addUpADateEnd;
	
			/// <summary>�����v�㋒�_�R�[�h</summary>
			/// <remarks>�����^</remarks>
			private string _demandAddUpSecCd = "";
	
			/// <summary>���ьv�㋒�_�R�[�h</summary>
			/// <remarks>���ьv����s����Ɠ��̋��_�R�[�h</remarks>
			private string _resultsAddUpSecCd = "";
	
			/// <summary>�����ϔ���`�[�ďo�敪</summary>
			/// <remarks>=0�F�����ρA!=0�F������</remarks>
			private Int32 _alwcSalesSlipCall;
	
			/// <summary>�̔��]�ƈ��R�[�h</summary>
			private string _salesEmployeeCd = "";
	
			/// <summary>�`�[�������t(�J�n)</summary>
			/// <remarks>YYYYMMDD</remarks>
			private Int32 _searchSlipDateStart;
	
			/// <summary>�`�[�������t(�I��)</summary>
			/// <remarks>YYYYMMDD</remarks>
			private Int32 _searchSlipDateEnd;

            /// <summary>�T�[�r�X�`�[�敪</summary>
            private Int32 _serviceSlipCd;

            /// <summary>���|�敪</summary>
            private Int32 _accRecDivCd;

            /// <summary>���������敪</summary>
            private Int32 _autoDepositCd;
	
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
	
			/// public propaty name  :  AcptAnOdrStatus
			/// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
			/// <value>1:�\��,2:�\��L�����Z��,10:����,11:���σL�����Z��20:��,21:�󒍃L�����Z��,30:����,40:����,45:���،v��,50:�ϑ�,55:�ϑ��v��</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public Int32[] AcptAnOdrStatus
			{
				get{return _acptAnOdrStatus;}
				set{_acptAnOdrStatus = value;}
			}
	
			/// public propaty name  :  SalesSlipNum
			/// <summary>����`�[�ԍ��v���p�e�B</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public string SalesSlipNum
			{
				get{return _salesSlipNum;}
				set{_salesSlipNum = value;}
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
                get { return _claimCode; }
                set { _claimCode = value; }
            }

			/// public propaty name  :  AddUpADateStart
			/// <summary>�v����t(�J�n)�v���p�e�B</summary>
			/// <value>YYYYMMDD</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �v����t(�J�n)�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public Int32 AddUpADateStart
			{
				get{return _addUpADateStart;}
				set{_addUpADateStart = value;}
			}
	
			/// public propaty name  :  AddUpADateEnd
			/// <summary>�v����t(�I��)�v���p�e�B</summary>
			/// <value>YYYYMMDD</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �v����t(�I��)�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public Int32 AddUpADateEnd
			{
				get{return _addUpADateEnd;}
				set{_addUpADateEnd = value;}
			}
	
			/// public propaty name  :  DemandAddUpSecCd
			/// <summary>�����v�㋒�_�R�[�h�v���p�e�B</summary>
			/// <value>�����^</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �����v�㋒�_�R�[�h�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public string DemandAddUpSecCd
			{
				get{return _demandAddUpSecCd;}
				set{_demandAddUpSecCd = value;}
			}
	
			/// public propaty name  :  ResultsAddUpSecCd
			/// <summary>���ьv�㋒�_�R�[�h�v���p�e�B</summary>
			/// <value>���ьv����s����Ɠ��̋��_�R�[�h</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   ���ьv�㋒�_�R�[�h�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public string ResultsAddUpSecCd
			{
				get{return _resultsAddUpSecCd;}
				set{_resultsAddUpSecCd = value;}
			}
	
			/// public propaty name  :  AlwcSalesSlipCall
			/// <summary>�����ϔ���`�[�ďo�敪�v���p�e�B</summary>
			/// <value>=0�F�����ρA!=0�F������</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �����ϔ���`�[�ďo�敪�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public Int32 AlwcSalesSlipCall
			{
				get{return _alwcSalesSlipCall;}
				set{_alwcSalesSlipCall = value;}
			}
	
			/// public propaty name  :  SalesEmployeeCd
			/// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �̔��]�ƈ��R�[�h�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public string SalesEmployeeCd
			{
				get{return _salesEmployeeCd;}
				set{_salesEmployeeCd = value;}
			}
	
			/// public propaty name  :  SearchSlipDateStart
			/// <summary>�`�[�������t(�J�n)�v���p�e�B</summary>
			/// <value>YYYYMMDD</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �`�[�������t(�J�n)�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public Int32 SearchSlipDateStart
			{
				get{return _searchSlipDateStart;}
				set{_searchSlipDateStart = value;}
			}
	
			/// public propaty name  :  SearchSlipDateEnd
			/// <summary>�`�[�������t(�I��)�v���p�e�B</summary>
			/// <value>YYYYMMDD</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �`�[�������t(�I��)�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public Int32 SearchSlipDateEnd
			{
				get{return _searchSlipDateEnd;}
				set{_searchSlipDateEnd = value;}
			}

            /// public propaty name  :  ServiceSlipCd
            /// <summary>�T�[�r�X�`�[�敪�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �T�[�r�X�`�[�敪�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Int32 ServiceSlipCd
            {
                get { return _serviceSlipCd; }
                set { _serviceSlipCd = value; }
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

            /// public propaty name  :  AutoDepositCd
            /// <summary>���������敪�v���p�e�B</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ���������敪�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Int32 AutoDepositCd
            {
                get { return _autoDepositCd; }
                set { _autoDepositCd = value; }
            }
        }
        #endregion
        // �� 20070122 18322 c

		# endregion

		# region Private class
		//***************************************************************
		// ��O�����N���X
		//***************************************************************
		private class DepositException : ApplicationException
		{
			private int _status;

			# region Constructor
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public DepositException(string message, int status): base(message)
			{
				_status = status;
			}
			# endregion

			# region public property
			public int Status
			{
				get {return _status;}
			}
			# endregion
		}
		//***************************************************************
		// ������� ����`�[�ԍ��\�[�g�N���X
		//***************************************************************
		private class cmpAllowance : IComparer
		{
			public int Compare(object obj1, object obj2)
			{
                // 2007.10.05 upd start -------------------------------------------------->>
				// int no1 = Convert.ToInt32(((System.Data.DataRow)obj1)[ctAcceptAnOrderNo_Alw]);
				// int no2 = Convert.ToInt32(((System.Data.DataRow)obj2)[ctAcceptAnOrderNo_Alw]);
                string no1 = Convert.ToString(((DataRow)obj1)[ctSalesSlipNum_Alw]);
                string no2 = Convert.ToString(((DataRow)obj2)[ctSalesSlipNum_Alw]);
                // 2007.10.05 upd end ----------------------------------------------------<<

				return no1.CompareTo(no2);
			}
		}
		# endregion

		# region Enum
		enum UpdateMode
		{
			Insert = 0,
			Update = 1,
			Delete = 2,
			Aka = 3
		}
        // --- ADD K2013/03/22 ���� Redmine#35063 ---------->>>>>
        /// <summary>
        /// �I�v�V�����L���L��
        /// </summary>
        public enum Option : int
        {
            /// <summary>����</summary>
            OFF = 0,
            /// <summary>�L��</summary>
            ON = 1,
        }
        // --- ADD K2013/03/22 ���� Redmine#35063 ----------<<<<<
		# endregion

        /// <summary>
        /// �f�[�^�\�[�g������
        /// </summary>
        /// <remarks>
        /// <br>Update Note : 2012/12/24 ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private class DepositSlipNoComparer : IComparer
        {
            #region IComparer �����o
            int IComparer.Compare(object x, object y)
            {
                return (((SearchDepositAlw)x).DepositSlipNo.CompareTo(((SearchDepositAlw)y).DepositSlipNo));
            }
            #endregion
        }
	}
}

//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �������́i����w��^�j
// �v���O�����T�v   : �������́i����w��^�j�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �� �� ��  2008/06/26  �C�����e : Partsman�p�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/21  �C�����e : MANTIS�y13326�z���������V�X�e�����t�ł����o�^����Ȃ��s�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �C �� ��  2010/12/20  �C�����e : PM.NS��Q���ǑΉ�(12����)
//                                : �@�������\���̉���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �C �� ��  2011/02/09  �C�����e : Redmine#18848�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : �c����
// �C �� ��  2012/02/10  �C�����e : 2012/03/28�z�M�� Redmine#28395
//                                  �����ۑ��G���[�����̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : ���N�n
// �� �� ��  2012/02/27  �C�����e : 2012/03/28�z�M���ARedmine#28395 
//                                  ����w��^�œ��������ꍇ�A���Ӑ�q�̓���������f�[�^�ƕR�t���Ȃ��ɂ��Ă̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �C �� ��  2012/09/21  �C�����e : 2012/10/17�z�M�� Redmine#32415
//                                  ���s�҂̒ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11001635-00 �쐬�S�� : zhujw
// �C �� ��  K2014/05/28 �C�����e : ���J�g�\�ʑΉ�  
//                                  �@�������́i����w��^�j�Ŕ���`�[�𕡐��I�����A�ۑ������Ƃ��A
//                                    �����`�[������`�[���ꂼ��ɍ쐬�����悤�ɕύX���s���܂��B
//                                  �A���������K�C�h�ł͂Ȃ��A��ʁi���ׁj�ɕ\���ł���悤�ɂ��܂��B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11001635-00 �쐬�S�� : zhujw
// �C �� ��  K2014/06/19 �C�����e : RedMine#42902 �����̃f�[�^�p�����[�^���g�p����
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using System.Collections.Specialized;
using System.Collections.Generic;
using Broadleaf.Application.Resources; // ADD zhujw K2014/05/28 ���J�g�\�ʑΉ�

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �������́i����w��^�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �������́i����w��^�j�t�h�N���X�̃A�N�Z�X�N���X�ł��B</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
    /// <br>Update Note: 2007.01.30 18322 T.Kimura MA.NS�p�ɕύX</br>
    /// <br>             2007.05.14 18322 T.Kimura ��������f�[�^�̌����p�����[�^�ɃT�[�r�X�`�[�敪�A���|�敪�A���������敪��ǉ�</br>
    /// <br>             2007.08.01 18322 T.Kimura �������߂̃`�F�b�N��ǉ�</br>
    /// <br>             2007.10.05 20081 �D�c �E�l DC.NS�p�ɕύX</br> 
    /// <br>             2008/06/26 30414 �E �K�j Partsman�p�ɕύX</br> 
    /// <br>Update Note : 2010.05.06 gejun</br>
    /// <br>              M1007A-�x����`�f�[�^�X�V�ǉ�</br>
    /// <br>Update Note : 2010/12/20 ����� PM.NS��Q���ǑΉ�(12����)
    /// <br>              �������\���̉���</br>
    /// <br>Update Note : 2012/02/10 �c����</br>
    /// <br>�Ǘ��ԍ�    : 10707327-00 2012/03/28�z�M��</br>
    /// <br>              Redmine#28395 �����ۑ��G���[�����̑Ή�</br>
    /// <br>Update Note : 2012/02/27 ���N�n��</br>
    /// <br>�Ǘ��ԍ�    : 10707327-00 2012/03/28�z�M��</br>
    /// <br>              Redmine#28395 ����w��^�œ��������ꍇ�A���Ӑ�q�̓���������f�[�^�ƕR�t���Ȃ��ɂ��Ă̑Ή�</br>
    /// </remarks>
	public class InputDepositSalesTypeAcs
	{
		# region Constructor
		/// <summary>
		/// �������́i����w��^�j�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �g�p���郁���o�̏��������s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public InputDepositSalesTypeAcs()
		{
			// ���������� DataSet
			this._dsDmdSalesInfo = new DataSet();

            // �� 20070125 18322 c MA.NS�p�ɕύX
			//// �������㌟���A�N�Z�X�N���X
			//this._searchDmdSalesAcs = new SearchDmdSalesAcs();

			// �������㌟���A�N�Z�X�N���X
			this._searchDmdSalesAcs = new SearchClaimSalesAcs();
            // �� 20070125 18322 c

			// �����X�V�A�N�Z�X�N���X
			this._depsitMainAcs = new DepsitMainAcs();
		
			// �������͐ݒ�f�[�^�n�A�N�Z�X�N���X
			this.depositRelDataAcs = new DepositRelDataAcs();

            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //// �����[�g�I�u�W�F�N�g�擾
            //this._iCustomerInfoDB = (ICustomerInfoDB)MediationCustomerInfoDB.GetCustomerInfoDB();
            this._customerInfoAcs = new CustomerInfoAcs();

            this._employeeAcs = new EmployeeAcs();

            ReadEmployee();

            this._totalDayCalculator = TotalDayCalculator.GetInstance();
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

            // �� 20070801 18322 a
            // �������ߏ����̃����[�g�I�u�W�F�N�g
            this._iMonthlyAddUpDB = (IMonthlyAddUpDB)MediationMonthlyAddUpDB.GetCustMonthlyAddUpDB();

            this._lastMonthlyAddUpHis = null;
            // �� 20070801 18322 a
		}
		# endregion

		# region Private Menbers
		//***************************************************************
		// ��ʃo�C���h�p DataSet
		//***************************************************************
		/// <summary>���������� DataSet</summary>
		private DataSet _dsDmdSalesInfo;

		//***************************************************************
		// �����o�[
		//***************************************************************
		/// <summary>�������͐ݒ�f�[�^�n�A�N�Z�X�N���X</summary>
		private DepositRelDataAcs depositRelDataAcs;

        // �� 20070125 18322 c MA.NS�p�ɕύX
		///// <summary>�������㌟���A�N�Z�X�N���X</summary>
		//private SearchDmdSalesAcs _searchDmdSalesAcs;

		/// <summary>�������㌟���A�N�Z�X�N���X</summary>
		private SearchClaimSalesAcs _searchDmdSalesAcs;
        // �� 20070125 18322 c

		/// <summary>�����X�V�A�N�Z�X�N���X</summary>
		private DepsitMainAcs _depsitMainAcs;

        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
        ///// <summary>���Ӑ惊���[�g�N���X</summary>
        //private ICustomerInfoDB _iCustomerInfoDB;
        /// <summary>���Ӑ���A�N�Z�X�N���X</summary>
        private CustomerInfoAcs _customerInfoAcs;

        private EmployeeAcs _employeeAcs;

        private Dictionary<string, EmployeeDtl> _emoloyeeDtlDic;

        // �O�񌎎�����
        private DateTime _lastMonthlyAddUpDay;
        // �O�����
        private DateTime _lastAddUpDay;

        /// <summary>�����Z�o���W���[��</summary>
        private TotalDayCalculator _totalDayCalculator;
        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

        // �� 20070801 18322 a
         // �������ߏ����̃����[�g�I�u�W�F�N�g
        private IMonthlyAddUpDB     _iMonthlyAddUpDB     = null;

        private MonthlyAddUpHisWork _lastMonthlyAddUpHis = null;

        private IControlDepsitAlwDB _iControlDepsitAlwDB; // ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� 
        // �� 20070801 18322 a

		# endregion

		# region public const Menbers
		//***************************************************************
		// ����������DataSet�p�萔�錾
		//***************************************************************
		/// <summary>����������Table����</summary>
		public const string ctDmdSalesDataTable = "DmdSalesTable";

        // �� 20070131 18322 c MA.NS�p�ɕύX
        #region SF ����������DataSet�p�萔�錾�i�S�ăR�����g�A�E�g�j
		///// <summary>��</summary>
		//public const string ctAlwCheck = "AlwCheck";
		//
		///// <summary>��������ԍ��敪</summary>
		//public const string ctDebitNoteDiv = "DebitNoteDiv";
		//
		///// <summary>��������ԍ�����</summary>
		//public const string ctDebitNoteNm = "DebitNoteNm";
		//
		///// <summary>���Ӑ�R�[�h</summary>
		//public const string ctCustomerCode = "CustomerCode";
		//
		///// <summary>���Ӑ於��</summary>
		//public const string ctCustomerName = "CustomerName";
		//
		///// <summary>�󒍔ԍ�</summary>
		//public const string ctAcceptAnOrderNo = "AcceptAnOrderNo";
		//
		///// <summary>�`�[�ԍ�</summary>
		//public const string ctSlipNo = "SlipNo";
		//
		///// <summary>�`�[���t(�\���p)</summary>
		//public const string ctSearchSlipDateDisp = "SearchSlipDateDisp";
		//
		///// <summary>�`�[���t</summary>
		//public const string ctSearchSlipDate = "SearchSlipDate";
		//
		///// <summary>�v����t</summary>
		//public const string ctAddUpADate = "AddUpADate";
		//
		///// <summary>�V�X�e��</summary>
		//public const string ctDataInputSystem = "DataInputSystem";
		//
		///// <summary>�󒍃X�e�[�^�X</summary>
		//public const string ctAcptAnOdrStatus = "AcptAnOdrStatus";
		//
		///// <summary>�`�[���</summary>
		//public const string ctSalesKind = "SalesKind";
		//
		///// <summary>���㖼��</summary>
		//public const string ctSalesName = "SalesName";
		//
		///// <summary>�ԗ��o�^�ԍ�</summary>
		//public const string ctNumberPlate = "NumberPlate";
		//
		///// <summary>�󒍔���z</summary>
		//public const string ctAcceptAnOrderSales = "AcceptAnOrderSales";
		//
		///// <summary>����p�z</summary>
		//public const string ctTotalVariousCost = "TotalVariousCost";
		//
		///// <summary>�󒍍��v�z</summary>
		//public const string ctTotalSales = "TotalSales";
		//
		///// <summary>�����z �� (���������z)</summary>
		//public const string ctAcpOdrDepositAlwc_Alw = "AcpOdrDepositAlwc_Alw";
		//
		///// <summary>�����c �� (��������}�X�^)</summary>
		//public const string ctAcpOdrDepoAlwcBlnce_Sales = "AcpOdrDepoAlwcBlnce_Sales";
		//
		///// <summary>������ �� (��������}�X�^)</summary>
		//public const string ctAcpOdrDepositAlwc_Sales = "AcpOdrDepositAlwc_Sales";
		//
		///// <summary>�����z ����p (���������z)</summary>
		//public const string ctVarCostDepoAlwc_Alw = "VarCostDepoAlwc_Alw";
		//
		///// <summary>�����c ����p (��������}�X�^)</summary>
		//public const string ctVarCostDepoAlwcBlnce_Sales = "VarCostDepoAlwcBlnce_Sales";
		//
		///// <summary>������ ����p (��������}�X�^)</summary>
		//public const string ctVarCostDepoAlwc_Sales = "VarCostDepoAlwc_Sales";
		//
		///// <summary>�����z ���� (���������z)</summary>
		//public const string ctDepositAllowance_Alw = "DepositAllowance_Alw";
		//
		///// <summary>�����c ���� (��������}�X�^)</summary>
		//public const string ctDepositAlwcBlnce_Sales = "DepositAlwcBlnce_Sales";
		//
		///// <summary>������ ���� (��������}�X�^)</summary>
		//public const string ctDepositAllowance_Sales = "DepositAllowance_Sales";
		//
		///// <summary>��������</summary>
		//public const string ctDepositAlwBtn = "DepositAlwBtn";
		//
		///// <summary>�ŏI�����X�V��</summary>
		//public const string ctLastTotalAddUpDt = "LastTotalAddUpDt";
		//
		///// <summary>���ߏ��</summary>
		//public const string ctSalesClosedFlg = "ClosedFlg";
        //
		///// <summary>��������N���X</summary>
		//public const string ctSearchDmdSalesCustomer = "SearchDmdSalesCustomer";
        #endregion

		/// <summary>��</summary>
		public const string ctAlwCheck = "AlwCheck";

		/// <summary>��������ԍ��敪</summary>
		public const string ctDebitNoteDiv = "DebitNoteDiv";

		/// <summary>��������ԍ�����</summary>
		public const string ctDebitNoteNm = "DebitNoteNm";

        /// <summary>������R�[�h</summary>
        public const string ctClaimCode = "ClaimCode";

        /// <summary>�����於��</summary>
        public const string ctClaimName = "ClaimName";

        ///// <summary>���Ӑ�R�[�h</summary>
        //public const string ctCustomerCode = "CustomerCode";

		/// <summary>���Ӑ於��</summary>
		public const string ctCustomerName = "CustomerName";

        // --- ADD 2010/12/20 ---------->>>>>
        /// <summary>����</summary>
        public const string ctAllowDiv = "AllowDiv";

        /// <summary>����`�[�ԍ�</summary>
        public const string ctDepSaleSlipNum = "DepSaleSlipNum";
        // --- ADD 2010/12/20  ----------<<<<<

		/// <summary>����`�[�ԍ�</summary>
		public const string ctSalesSlipNum = "SalesSlipNum";

        /// <summary>�`�[���t(�\���p)</summary>
		public const string ctSearchSlipDateDisp = "SearchSlipDateDisp";

		/// <summary>�`�[���t</summary>
		public const string ctSearchSlipDate = "SearchSlipDate";

		/// <summary>�v����t</summary>
		public const string ctAddUpADate = "AddUpADate";

		/// <summary>�󒍃X�e�[�^�X</summary>
		public const string ctAcptAnOdrStatus = "AcptAnOdrStatus";

        /// <summary>�󒍃X�e�[�^�X��</summary>
		public const string ctAcptAnOdrStatusNm = "AcptAnOdrStatusNm";

		/// <summary>�`�[���</summary>
		public const string ctSalesKind = "SalesKind";

		/// <summary>�`�[���l</summary>
        public const string ctSlipNote = "SlipNote";

        /// <summary>����`�[���v�i�ō��݁j</summary>
        public const string ctSalesTotalTaxExc = "SalesTotalTaxExc";

        // �� 20070525 18322 a
		/// <summary>���|�敪(0:���|�Ȃ�,1:���|)</summary>
        public const string ctAccRecDivCd = "AccRecDivCd";
        ///// <summary>���W������</summary>
        //public const string ctRegiProcDate = "RegiProcDate";
        ///// <summary>���W�ԍ�</summary>
        //public const string ctCashRegisterNo = "CashRegisterNo";
        ///// <summary>POS���V�[�g�ԍ�</summary>
        //public const string ctPosReceiptNo = "PosReceiptNo";
        // �� 20070525 18322 a

		/// <summary>�����z ���� (���������z)</summary>
		public const string ctDepositAllowance_Alw = "DepositAllowance_Alw";

		/// <summary>�����c ���� (��������}�X�^)</summary>
		public const string ctDepositAlwcBlnce_Sales = "DepositAlwcBlnce_Sales";

		/// <summary>������ ���� (��������}�X�^)</summary>
		public const string ctDepositAllowance_Sales = "DepositAllowance_Sales";

		/// <summary>��������</summary>
		public const string ctDepositAlwBtn = "DepositAlwBtn";

        // --- ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� ------->>>>> 
        /// <summary>������</summary>
        public const string ctDepositDate = "DepositDate";

        /// <summary>�S����</summary>
        public const string ctDepositAgentCode = "DepositAgentCode";

        /// <summary>����</summary>
        public const string ctDepositKindName = "DepositKindName";
        // --- ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� -------<<<<<

		/// <summary>�ŏI�����X�V��</summary>
		public const string ctLastTotalAddUpDt = "LastTotalAddUpDt";

		/// <summary>�ŏI�����X�V��</summary>
		public const string ctLastMonthlyDate = "LastMonthlyDate";

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>�ŏI�����X�V��(�\���p)</summary>
        public const string ctLastMonthlyDateDisp = "LastMonthlyDateDisp";

        /// <summary>�ύX�O�����c(��������}�X�^)</summary>
        public const string ctBfDepositAlwcBlnce_Sales = "BfDepositAlwcBlnce_Sales";

        /// <summary>�ύX�O������(��������}�X�^)</summary>
        public const string ctBfDepositAllowance_Sales = "BfDepositAllowance_Sales";
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

		/// <summary>���ߏ��</summary>
		public const string ctSalesClosedFlg = "ClosedFlg";

		/// <summary>�������㌟���f�[�^�N���X</summary>
		public const string ctSearchClaimSales = "SearchClaimSales";
        // �� 20070131 18322 c

		/// <summary>�V�K�쐬�����X�V�p�����[�^�N���X</summary>
		public const string ctUpdateDepositParameter = "UpdateDepositParameter";

		/// <summary>���g��DataRow</summary>
		public const string ctDmdSalesDataRow = "DmdSalesDataRow";
		# endregion

		# region public Methods
		/// <summary>
		/// �������͉��(����w��^)�A�N�Z�X�N���X ����������
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
			_dsDmdSalesInfo.Clear();
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
			return _dsDmdSalesInfo;
        }

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
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
            #region SF ���������� ��ݒ�(�S�ăR�����g�A�E�g)
			//// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			//dtDmdSalesTable.Columns.Add(ctAlwCheck, typeof(bool));						// ��
			//dtDmdSalesTable.Columns.Add(ctAcpOdrDepositAlwc_Alw, typeof(Int64));		// �����z �� (���������z)
			//dtDmdSalesTable.Columns.Add(ctAcpOdrDepoAlwcBlnce_Sales, typeof(Int64));	// �����c �� (��������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctAcpOdrDepositAlwc_Sales, typeof(Int64));		// ������ �� (��������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctVarCostDepoAlwc_Alw, typeof(Int64));			// �����z ����p (���������z)
			//dtDmdSalesTable.Columns.Add(ctVarCostDepoAlwcBlnce_Sales, typeof(Int64));	// �����c ����p (��������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctVarCostDepoAlwc_Sales, typeof(Int64));		// ������ ����p (��������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctDepositAllowance_Alw, typeof(Int64));			// �����z ���� (���������z)
			//dtDmdSalesTable.Columns.Add(ctDepositAlwcBlnce_Sales, typeof(Int64));		// �����c ���� (��������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctDepositAllowance_Sales, typeof(Int64));		// ������ ���� (��������}�X�^)
			//dtDmdSalesTable.Columns.Add(ctDebitNoteDiv, typeof(int));					// �ԍ��敪
			//dtDmdSalesTable.Columns.Add(ctDebitNoteNm, typeof(string));					// �ԍ�����
			//dtDmdSalesTable.Columns.Add(ctSlipNo, typeof(string));						// �`�[�ԍ�
			//dtDmdSalesTable.Columns.Add(ctAcceptAnOrderNo, typeof(int));				// �󒍔ԍ�
			//dtDmdSalesTable.Columns.Add(ctSearchSlipDateDisp, typeof(string));			// �`�[���t(�\���p)
			//dtDmdSalesTable.Columns.Add(ctSearchSlipDate, typeof(int));					// �`�[���t
			//dtDmdSalesTable.Columns.Add(ctAddUpADate, typeof(int));						// �����
			//dtDmdSalesTable.Columns.Add(ctCustomerCode, typeof(int));					// ���Ӑ�R�[�h
			//dtDmdSalesTable.Columns.Add(ctCustomerName, typeof(string));				// ���Ӑ於��
			//dtDmdSalesTable.Columns.Add(ctDataInputSystem, typeof(int));				// �V�X�e��
			//dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatus, typeof(int));				// �󒍃X�e�[�^�X
			//dtDmdSalesTable.Columns.Add(ctSalesKind, typeof(string));					// �`�[���
			//dtDmdSalesTable.Columns.Add(ctSalesName, typeof(string));					// ���㖼��
			//dtDmdSalesTable.Columns.Add(ctNumberPlate, typeof(string));					// �o�^�ԍ�
			//dtDmdSalesTable.Columns.Add(ctAcceptAnOrderSales, typeof(Int64));			// �󒍔���z
			//dtDmdSalesTable.Columns.Add(ctTotalVariousCost, typeof(Int64));				// ����p�z
			//dtDmdSalesTable.Columns.Add(ctTotalSales, typeof(Int64));					// �󒍍��v�z
			//dtDmdSalesTable.Columns.Add(ctLastTotalAddUpDt, typeof(int));				// �ŏI�����X�V��
			//dtDmdSalesTable.Columns.Add(ctSalesClosedFlg, typeof(string));				// ���t���O
			//dtDmdSalesTable.Columns.Add(ctSearchDmdSalesCustomer, typeof(SearchDmdSalesCustomer));	// ��������N���X
			//dtDmdSalesTable.Columns.Add(ctUpdateDepositParameter, typeof(UpdateDepositParameter));	// �V�K�쐬�����p�����[�^�N���X
			//dtDmdSalesTable.Columns.Add(ctDmdSalesDataRow, typeof(DataRow));			// ���g��DataRow
			//dtDmdSalesTable.Columns.Add(ctDepositAlwBtn, typeof(string));				// ���������{�^��
            #endregion

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			dtDmdSalesTable.Columns.Add(ctAlwCheck, typeof(bool));						// ��
			dtDmdSalesTable.Columns.Add(ctDepositAllowance_Alw, typeof(Int64));			// �����z ���� (���������z)
			dtDmdSalesTable.Columns.Add(ctDepositAlwcBlnce_Sales, typeof(Int64));		// �����c ���� (��������}�X�^)
			dtDmdSalesTable.Columns.Add(ctDepositAllowance_Sales, typeof(Int64));		// ������ ���� (��������}�X�^)
			dtDmdSalesTable.Columns.Add(ctDebitNoteDiv, typeof(int));					// �ԍ��敪
			dtDmdSalesTable.Columns.Add(ctDebitNoteNm, typeof(string));					// �ԍ�����
			dtDmdSalesTable.Columns.Add(ctSalesSlipNum, typeof(string));                // ����`�[�ԍ�
			dtDmdSalesTable.Columns.Add(ctSearchSlipDateDisp, typeof(string));			// �`�[���t(�\���p)
			dtDmdSalesTable.Columns.Add(ctSearchSlipDate, typeof(int));					// �`�[���t
			dtDmdSalesTable.Columns.Add(ctAddUpADate, typeof(int));						// �����
            dtDmdSalesTable.Columns.Add(ctClaimCode, typeof(int));					    // ������R�[�h
            dtDmdSalesTable.Columns.Add(ctClaimName, typeof(string));				    // �����於��
			dtDmdSalesTable.Columns.Add(ctCustomerCode, typeof(int));					// ���Ӑ�R�[�h
			dtDmdSalesTable.Columns.Add(ctCustomerName, typeof(string));				// ���Ӑ於��
			dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatus, typeof(int));				// �󒍃X�e�[�^�X
			dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatusNm, typeof(string));			// �󒍃X�e�[�^�X��
			dtDmdSalesTable.Columns.Add(ctSalesKind, typeof(string));					// �`�[���
			dtDmdSalesTable.Columns.Add(ctSalesName, typeof(string));					// ���㖼��
            dtDmdSalesTable.Columns.Add(ctSalesTotalTaxExc, typeof(Int64));				// ����`�[���v�i�ō��݁j
            // �� 20070525 18322 a MK.NS�p�ɕύX
            dtDmdSalesTable.Columns.Add(ctAccRecDivCd   , typeof(int));                 // ���|�敪(0:���|�Ȃ�,1:���|)
            //dtDmdSalesTable.Columns.Add(ctRegiProcDate  , typeof(string));              // ���W������
            //dtDmdSalesTable.Columns.Add(ctCashRegisterNo, typeof(int));                 // ���W�ԍ�
            //dtDmdSalesTable.Columns.Add(ctPosReceiptNo  , typeof(int));                 // POS���V�[�g�ԍ�
            // �� 20070525 18322 a MK.NS�p�ɕύX
			dtDmdSalesTable.Columns.Add(ctLastTotalAddUpDt, typeof(int));				// �ŏI�����X�V��
            dtDmdSalesTable.Columns.Add(ctLastMonthlyDate, typeof(int));                // �ŏI�������ߓ�
			dtDmdSalesTable.Columns.Add(ctSalesClosedFlg, typeof(string));				// ���t���O
			dtDmdSalesTable.Columns.Add(ctSearchClaimSales, typeof(SearchClaimSales));	// �������㌟���f�[�^�N���X
			dtDmdSalesTable.Columns.Add(ctUpdateDepositParameter, typeof(UpdateDepositParameter));	// �V�K�쐬�����p�����[�^�N���X
			dtDmdSalesTable.Columns.Add(ctDmdSalesDataRow, typeof(DataRow));			// ���g��DataRow
			dtDmdSalesTable.Columns.Add(ctDepositAlwBtn, typeof(string));				// ���������{�^��
            // �� 20070131 18322 c
			
			// �f�[�^�Z�b�g�ɒǉ�
			_dsDmdSalesInfo.Tables.Add(dtDmdSalesTable.Clone());
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���������� DataSet Table �쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����������f�[�^�Z�b�g�̃e�[�u�����쐬���܂��B
        ///	               :   �� Method : GetDsDepositInfo ��茋�ʎ擾</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// <br>Update Note: 2010/12/20 ����� PM.NS��Q���ǑΉ�(12����)
        /// <br>             ���ځu�����v��ǉ�����B</br>
        /// </remarks>
        public void CreateDmdSalesDataTable()
        {
            // �f�[�^�e�[�u���̗��`
            DataTable dtDmdSalesTable = new DataTable(ctDmdSalesDataTable);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            dtDmdSalesTable.Columns.Add(ctAlwCheck, typeof(bool));						            // ��
            dtDmdSalesTable.Columns.Add(ctDepositAllowance_Alw, typeof(Int64));			            // �����z ���� (���������z)
            dtDmdSalesTable.Columns.Add(ctDepositAlwcBlnce_Sales, typeof(Int64));		            // �����c ���� (��������}�X�^)
            dtDmdSalesTable.Columns.Add(ctBfDepositAlwcBlnce_Sales, typeof(Int64));		            // �ύX�O�����c(��������}�X�^)
            dtDmdSalesTable.Columns.Add(ctDepositAllowance_Sales, typeof(Int64));		            // ������ ���� (��������}�X�^)
            dtDmdSalesTable.Columns.Add(ctBfDepositAllowance_Sales, typeof(Int64));		            // �ύX�O������(��������}�X�^)
            dtDmdSalesTable.Columns.Add(ctDebitNoteDiv, typeof(int));					            // �ԍ��敪
            dtDmdSalesTable.Columns.Add(ctDebitNoteNm, typeof(string));					            // �ԍ�����
            dtDmdSalesTable.Columns.Add(ctAllowDiv, typeof(string));                                // ���� // ADD 2010/12/20
            dtDmdSalesTable.Columns.Add(ctDepSaleSlipNum, typeof(string));				            // ����`�[�ԍ�  // ADD 2010/12/20
            dtDmdSalesTable.Columns.Add(ctSalesSlipNum, typeof(string));                            // ����`�[�ԍ�
            dtDmdSalesTable.Columns.Add(ctSearchSlipDateDisp, typeof(string));			            // �`�[���t(�\���p)
            dtDmdSalesTable.Columns.Add(ctSearchSlipDate, typeof(int));					            // �`�[���t
            dtDmdSalesTable.Columns.Add(ctAddUpADate, typeof(int));						            // �����
            dtDmdSalesTable.Columns.Add(ctClaimCode, typeof(int));					                // ������R�[�h
            dtDmdSalesTable.Columns.Add(ctClaimName, typeof(string));				                // �����於��
            //dtDmdSalesTable.Columns.Add(ctCustomerCode, typeof(int));					            // ���Ӑ�R�[�h
            dtDmdSalesTable.Columns.Add(ctCustomerName, typeof(string));				            // ���Ӑ於��
            dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatus, typeof(int));				            // �󒍃X�e�[�^�X
            dtDmdSalesTable.Columns.Add(ctAcptAnOdrStatusNm, typeof(string));			            // �󒍃X�e�[�^�X��
            dtDmdSalesTable.Columns.Add(ctSalesKind, typeof(string));					            // �`�[���
            dtDmdSalesTable.Columns.Add(ctSlipNote, typeof(string));					            // �`�[���l
            dtDmdSalesTable.Columns.Add(ctSalesTotalTaxExc, typeof(Int64));				            // ����`�[���v�i�ō��݁j
            dtDmdSalesTable.Columns.Add(ctAccRecDivCd, typeof(int));                                // ���|�敪(0:���|�Ȃ�,1:���|)
            dtDmdSalesTable.Columns.Add(ctLastTotalAddUpDt, typeof(int));				            // �ŏI�����X�V��
            dtDmdSalesTable.Columns.Add(ctLastMonthlyDateDisp, typeof(string));                     // �ŏI�������ߓ�(�\���p)
            dtDmdSalesTable.Columns.Add(ctLastMonthlyDate, typeof(int));                            // �ŏI�������ߓ�
            dtDmdSalesTable.Columns.Add(ctSalesClosedFlg, typeof(string));				            // ���t���O
            dtDmdSalesTable.Columns.Add(ctSearchClaimSales, typeof(SearchClaimSales));	            // �������㌟���f�[�^�N���X
            dtDmdSalesTable.Columns.Add(ctUpdateDepositParameter, typeof(UpdateDepositParameter));	// �V�K�쐬�����p�����[�^�N���X
            dtDmdSalesTable.Columns.Add(ctDmdSalesDataRow, typeof(DataRow));			            // ���g��DataRow
            dtDmdSalesTable.Columns.Add(ctDepositAlwBtn, typeof(string));				            // ���������{�^��
            // --- ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� ------->>>>> 
            if (this.KaToOption())
            {
                dtDmdSalesTable.Columns.Add(ctDepositDate, typeof(string));                             // ������
                dtDmdSalesTable.Columns.Add(ctDepositAgentCode, typeof(string));                        // �S����
                dtDmdSalesTable.Columns.Add(ctDepositKindName, typeof(string));				            // ����
            }
            // --- ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� -------<<<<<

            // �f�[�^�Z�b�g�ɒǉ�
            _dsDmdSalesInfo.Tables.Add(dtDmdSalesTable.Clone());
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// �����֘A�f�[�^�擾�����i���Ӑ�R�[�h�w��j
		/// </summary>
		/// <param name="searchSalesParameter">����������擾�p�p�����[�^ �N���X</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���</param>
		/// <param name="message">�G���[���������b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�p�����[�^�̐�����������擾���A�ȉ��̃f�[�^�Z�b�g�ɂĕԂ��܂��B
		///					:   �� ���������� : Method : GetDsDmdSalesInfo</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int SearchDmdSales(SearchSalesParameter searchSalesParameter, int consTaxLayMethod, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
				// �󒍏��DataSet����������
				this.ClearDmdSalesInfo();

				// ����������擾����
				st = this.GetDmdSalesInfo(searchSalesParameter, consTaxLayMethod);
				if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
				{
					message = "�w�肳�ꂽ�����ŁA����`�[�͑��݂��܂���ł����B";
					return st;
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
			return _dsDmdSalesInfo.Tables[ctDmdSalesDataTable].DefaultView[index].Row;
		}

        // �� 20070125 18322 c MA.NS�p�ɕύX
        #region SF ����������� �󒍁E����p �ύX�����iMA.NS�ł͎g�p���Ȃ��̂őS�ăR�����g�A�E�g�j
        ///// <summary>
		///// ����������� �� �ύX����
		///// </summary>
		///// <param name="difference">�����ύX�O�㍷�z</param>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <param name="flgAcpOdrDepositAlwc_Alw">�����c �� (���������z) �X�V�t���O</param>
		///// <param name="flgAcpOdrDepoAlwcBlnce_Sales">�����c �� (��������}�X�^) �X�V�t���O</param>
		///// <param name="flgAcpOdrDepositAlwc_Sales">������ �� (��������}�X�^) �X�V�t���O</param>
		///// <remarks>
		///// <br>Note       : �����z �� �̕ύX���e���e�ɔ��f���܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public void UpdateAcpOdrDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales, bool flgAcpOdrDepositAlwc_Alw, bool flgAcpOdrDepoAlwcBlnce_Sales, bool flgAcpOdrDepositAlwc_Sales)
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
		//}
		//
		///// <summary>
		///// ����������� ����p �ύX����
		///// </summary>
		///// <param name="difference">�����ύX�O�㍷�z</param>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <param name="flgVarCostDepoAlwc_Alw">�����c ����p (���������z) �X�V�t���O</param>
		///// <param name="flgVarCostDepoAlwcBlnce_Sales">�����c ����p (��������}�X�^) �X�V�t���O</param>
		///// <param name="flgVarCostDepoAlwc_Sales">������ ����p (��������}�X�^) �X�V�t���O</param>
		///// <remarks>
		///// <br>Note       : �����z ����p �̕ύX���e���e�ɔ��f���܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public void UpdateCostDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales, bool flgVarCostDepoAlwc_Alw, bool flgVarCostDepoAlwcBlnce_Sales, bool flgVarCostDepoAlwc_Sales)
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
		//}
        #endregion
        // �� 20070125 18322 c

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ����������� ���� �ύX����
		/// </summary>
		/// <param name="difference">�����ύX�O�㍷�z</param>
		/// <param name="drDmdSales">����������DataRow</param>
		/// <param name="flgDepositAllowance_Alw">�����c ���� (���������z) �X�V�t���O</param>
		/// <param name="flgDepositAlwcBlnce_Sales">�����c ���� (��������}�X�^) �X�V�t���O</param>
		/// <remarks>
		/// <br>Note       : �����z ���� �̕ύX���e���e�ɔ��f���܂��B</br>
		/// <br>Programmer : 30414 �E �K�j</br>
		/// <br>Date       : 2008/06/26</br>
		/// </remarks>
		public void UpdateDepositAlwc(Int64 difference, ref DataRow drDmdSales, bool flgDepositAllowance_Alw, bool flgDepositAlwcBlnce_Sales)
		{
            if (flgDepositAllowance_Alw)   // ON
            {
                // ���������z
                drDmdSales[ctDepositAllowance_Alw] = 0;

                // ���������c
                drDmdSales[ctDepositAlwcBlnce_Sales] = difference;

                // ����������
                drDmdSales[ctDepositAllowance_Sales] = 0;
            }

            if (flgDepositAlwcBlnce_Sales) // ���͒�
            {
                // ���������z
                drDmdSales[ctDepositAllowance_Alw] = Convert.ToInt64(drDmdSales[ctDepositAllowance_Alw]) + difference;

                // ���������c
                drDmdSales[ctDepositAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctDepositAlwcBlnce_Sales]) - difference;

                // ����������
                drDmdSales[ctDepositAllowance_Sales] = Convert.ToInt64(drDmdSales[ctDepositAllowance_Sales]) + difference;
            }
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ����������� ���� �ύX����
        /// </summary>
        /// <param name="difference">�����ύX�O�㍷�z</param>
        /// <param name="drDmdSales">����������DataRow</param>
        /// <param name="flgDepositAllowance_Alw">�����c ���� (���������z) �X�V�t���O</param>
        /// <param name="flgDepositAlwcBlnce_Sales">�����c ���� (��������}�X�^) �X�V�t���O</param>
        /// <param name="flgDepositAllowance_Sales">������ ���� (��������}�X�^) �X�V�t���O</param>
        /// <remarks>
        /// <br>Note       : �����z ���� �̕ύX���e���e�ɔ��f���܂��B</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        public void UpdateDepositAlwc(Int64 difference, ref DataRow drDmdSales, bool flgDepositAllowance_Alw, bool flgDepositAlwcBlnce_Sales, bool flgDepositAllowance_Sales)
        {
            //// �����z ���� (���������z) ���X�V����
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
            if (flgDepositAllowance_Alw)   // ON
            {
                drDmdSales[ctDepositAllowance_Alw] = 0;
                drDmdSales[ctDepositAlwcBlnce_Sales] = difference;
                drDmdSales[ctDepositAllowance_Sales] = 0;
            }

            if (flgDepositAlwcBlnce_Sales) // ���͒�
            {
                drDmdSales[ctDepositAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctSalesTotalTaxExc]) - difference;
                drDmdSales[ctDepositAllowance_Sales] = difference;
            }

            if (flgDepositAllowance_Sales) // OFF
            {
                // �������Ȃ�
            }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        // �� 20070125 18322 c MA.NS�p�ɕύX
        #region SF ����������� �󒍁E����p �ύX�����iMA.NS�ł͎g�p���Ȃ��̂őS�ăR�����g�A�E�g�j
        ///// <summary>
		///// ����������� �� �ύX����
		///// </summary>
		///// <param name="difference">�����O��������z</param>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <returns>�����������z</returns>
		///// <remarks>
		///// <br>Note       : ������� �� �̕ύX���e���e�ɔ��f���܂��B��������͈����c��0�~�܂łł��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 ZeroUpdateAcpOdrDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales)
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
		//	// �����z �� (���������z) ���X�V����
		//	drDmdSales[ctAcpOdrDepositAlwc_Alw] = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Alw]) + maxDepositAlw;
		//
		//	// �����c �� (��������}�X�^) ���X�V����
		//	drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales]) - maxDepositAlw;
		//
		//	// ������ �� (��������}�X�^) ���X�V����
		//	drDmdSales[ctAcpOdrDepositAlwc_Sales] = Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Sales]) + maxDepositAlw;
		//
		//	return zanDifference;
		//}
		//
		///// <summary>
		///// ����������� ����p �ύX����
		///// </summary>
		///// <param name="difference">�����O��������z</param>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <returns>�����������z</returns>
		///// <remarks>
		///// <br>Note       : ������� ����p �̕ύX���e���e�ɔ��f���܂��B��������͈����c��0�~�܂łł��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 ZeroUpdateCostDepositAlwc(Int64 difference, ref System.Data.DataRow drDmdSales)
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
		//	// �����z ����p (���������z) ���X�V����
		//	drDmdSales[ctVarCostDepoAlwc_Alw] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Alw]) + maxDepositAlw;
		//
		//	// �����c ����p (��������}�X�^) ���X�V����
		//	drDmdSales[ctVarCostDepoAlwcBlnce_Sales] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwcBlnce_Sales]) - maxDepositAlw;
		//
		//	// ������ ����p (��������}�X�^) ���X�V����
		//	drDmdSales[ctVarCostDepoAlwc_Sales] = Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Sales]) + maxDepositAlw;
		//
		//	return zanDifference;
        //}
        #endregion
        // �� 20070125 18322 c

        // �� 20070125 18322 c MA.NS�p�ɕύX
        #region SF �����z �󒍁E����p (���������z) �ő�z�擾�����iMA.NS�ł͎g�p���Ȃ��̂őS�ăR�����g�A�E�g�j
        ///// <summary>
		///// �����z �� (���������z) �ő�z�擾����
		///// </summary>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <returns>�ő���������z</returns>
		///// <remarks>
		///// <br>Note       : �ő�����c���擾���܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetMaxAcpOdrDepositAlwc(System.Data.DataRow drDmdSales)
		//{
		//	// �����c �� (��������}�X�^) ���擾����
		//	return Convert.ToInt64(drDmdSales[ctAcpOdrDepoAlwcBlnce_Sales]);
		//}
        //
		///// <summary>
		///// �����z ����p (���������z) �ő�z�擾����
		///// </summary>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <returns>�ő���������z</returns>
		///// <remarks>
		///// <br>Note       : �ő�����c���擾���܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetMaxCostDepositAlwc(System.Data.DataRow drDmdSales)
		//{
		//	// �����c ����p (��������}�X�^) ���擾����
		//	return Convert.ToInt64(drDmdSales[ctVarCostDepoAlwcBlnce_Sales]);
        //}
        #endregion
        // �� 20070125 18322 c

		/// <summary>
		/// �����z ���� (���������z) �ő�z�擾����
		/// </summary>
		/// <param name="drDmdSales">����������DataRow</param>
		/// <returns>�ő���������z</returns>
		/// <remarks>
		/// <br>Note       : �ő�����c���擾���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public Int64 GetMaxDepositAlwc(DataRow drDmdSales)
		{
			// �����c ���� (��������}�X�^) ���擾����
			//return Convert.ToInt64(drDmdSales[ctDepositAlwcBlnce_Sales]);
            return Convert.ToInt64(drDmdSales[ctSalesTotalTaxExc]);
		}

        // �� 20070125 18322 c MA.NS�p�ɕύX
        #region SF �����z �󒍁E����p (���������z) �N���A�z�����iMA.NS�ł͎g�p���Ȃ��̂őS�ăR�����g�A�E�g�j
        ///// <summary>
		///// �����z �� (���������z) �N���A�z����
		///// </summary>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <returns>���������N���A�z</returns>
		///// <remarks>
		///// <br>Note       : �N���A���z���擾���܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetClearAcpOdrDepositAlwc(System.Data.DataRow drDmdSales)
		//{
		//	// �����z �� (���������z) �̃N���A�z�擾
		//	return Convert.ToInt64(drDmdSales[ctAcpOdrDepositAlwc_Alw]) * -1;
		//}
        //
		///// <summary>
		///// �����z ����p (���������z) �N���A�z����
		///// </summary>
		///// <param name="drDmdSales">����������DataRow</param>
		///// <returns>���������N���A�z</returns>
		///// <remarks>
		///// <br>Note       : �N���A���z���擾���܂��B</br>
		///// <br>Programmer : 97036 amami</br>
		///// <br>Date       : 2005.07.21</br>
		///// </remarks>
		//public Int64 GetClearCostDepositAlwc(System.Data.DataRow drDmdSales)
		//{
		//	// �����z ����p (���������z) �̃N���A�z�擾
		//	return Convert.ToInt64(drDmdSales[ctVarCostDepoAlwc_Alw]) * -1;
        //}
        #endregion
        // �� 20070125 18322 c

		/// <summary>
		/// �����z ���� (���������z) �N���A�z����
		/// </summary>
		/// <param name="drDmdSales">����������DataRow</param>
		/// <returns>���������N���A�z</returns>
		/// <remarks>
		/// <br>Note       : �N���A���z���擾���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public Int64 GetClearDepositAlwc(DataRow drDmdSales)
		{
			// �����z ���� (���������z) �̃N���A�z�擾
			return Convert.ToInt64(drDmdSales[ctDepositAllowance_Alw]) * -1;
		}

		/// <summary>
		/// �X�V�Ώۃf�[�^�̎擾/�s���`�F�b�N����
		/// </summary>
		/// <param name="updateDepositParameter">�����X�V�p�N���X</param>
		/// <param name="drDmdSalesList">����������DataRow</param>
		/// <param name="message">�s�����b�Z�[�W</param>
		/// <returns>�X�e�[�^�X 0:����, 1:�ύX�f�[�^����, 2:�������s��, 3:��(���ς�)�ɑ΂��a���, 4:��(��)�ɑ΂��a���, 5:��(��[���E�ςݍ�])�ɑ΂��a���</returns>
		/// <remarks>
		/// <br>Note       : �����X�V�Ώ�DatRow�̕s���`�F�b�N/�擾���s���܂��B
		///                : ���펞�͍X�V�Ώۃf�[�^���߂�܂��B
		///                : �G���[���̓G���[�Ώۃf�[�^���߂�܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int CheackUpdateDate(UpdateDepositParameter updateDepositParameter, out DataRow[] drDmdSalesList, out string message)
		{
            // --- ADD m.suzuki 2010/08/18 ---------->>>>>
            //--------------------------------------------------
            // �����t���`�F�b�N���鎞�́A�K���ŐV�����g�p����B
            //--------------------------------------------------
            // �����X�V�����擾
            this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccRec( updateDepositParameter.AddUpSecCode );
            // �����������擾
            this._lastAddUpDay = GetTotalDayDmdC( updateDepositParameter.AddUpSecCode, updateDepositParameter.ClaimCode );
            // --- ADD m.suzuki 2010/08/18 ----------<<<<<

			message = "";
			drDmdSalesList = null;
			ArrayList alUpdateData = new ArrayList();
			ArrayList alMistakeData2 = new ArrayList();
			ArrayList alMistakeData3 = new ArrayList();
			ArrayList alMistakeData4 = new ArrayList();
			ArrayList alMistakeData5 = new ArrayList();
            ArrayList alMistakeData6 = new ArrayList();

			// �����������S�����[�v
			foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
			{
				// �����z ���� (���������z) ���Z�b�g����Ă���Ύ擾����
                // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                //if ((dr[ctDepositAllowance_Alw] != DBNull.Value) && (Convert.ToInt64(dr[ctDepositAllowance_Alw]) != 0))
                if (Convert.ToString(dr[ctAlwCheck]) == "True")
                // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
                {
					alUpdateData.Add(dr);

					// �������t�s���̎�(������<=���Ӑ�O�����)
                    if (updateDepositParameter.DepositDate <= TDateTime.DateTimeToLongDate(this._lastAddUpDay))
					{
						alMistakeData2.Add(dr);
					}
                    else
                    {
                        // �������t�s���̎�(������<=�O�񌎎����ߓ�)
                        if (updateDepositParameter.DepositDate <= TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpDay))
                        {
                            alMistakeData6.Add(dr);
                        }
                    }

                    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
					// ��(���ς�)�ɑ΂��ėa��������̎�
					if ((updateDepositParameter.DepositCd == 1) && (dr[ctSalesClosedFlg].ToString() != ""))
					{
						alMistakeData3.Add(dr);
					}

					// ��(�ԓ`)�ɑ΂��ėa��������̎�
					if ((updateDepositParameter.DepositCd == 1) && (Convert.ToInt32(dr[ctDebitNoteDiv]) == 1))
					{
						alMistakeData4.Add(dr);
					}
				
					// ��(�ԓ`[���E�ςݍ�])�ɑ΂��ėa��������̎�
					if ((updateDepositParameter.DepositCd == 1) && (Convert.ToInt32(dr[ctDebitNoteDiv]) == 2))
					{
						alMistakeData5.Add(dr);
					}
                       --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                }
			}

			// �Ώۃf�[�^������
			if (alUpdateData.Count == 0)
			{
				message = "�ۑ��Ώۃf�[�^������܂���B";
				return 1;
			}

            // �������s���̂Ƃ��i������<=�ŏI�������ߓ��j
            if (alMistakeData6.Count != 0)
            {
                message = "���������O�񌎎��X�V���ȑO�ɂȂ��Ă���ׁA�o�^�ł��܂���B" + "\r\n\r\n" + "  �O�񌎎��X�V���F" + this._lastMonthlyAddUpDay.ToString("yyyy�NMM��dd��");
				// �s���f�[�^���Z�b�g����
				drDmdSalesList = (DataRow[])alMistakeData6.ToArray(typeof(DataRow));
				return 2;
            }

			// �������s���̎�(������<=���Ӑ�O�����)
			if (alMistakeData2.Count != 0)
			{
                message = "���������O�񐿋������ȑO�ɂȂ��Ă���ׁA�o�^�ł��܂���B" + "\r\n\r\n" + "  �O�񐿋������F" + this._lastAddUpDay.ToString("yyyy�NMM��dd��");
				// �s���f�[�^���Z�b�g����
				drDmdSalesList = (DataRow[])alMistakeData2.ToArray(typeof(DataRow));
				return 2;
			}

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            // ��(���ς�)�ɑ΂��ėa��������̎�
            if (alMistakeData3.Count != 0)
            {
                message = "����`�[(���ς�)�ɑ΂��ėa����̓������s���Ă���f�[�^������܂��B";
                // �s���f�[�^���Z�b�g����
                drDmdSalesList = (DataRow[])alMistakeData3.ToArray(typeof(DataRow));
                return 3;
            }

            // ��(�ԓ`)�ɑ΂��ėa��������̎�
            if (alMistakeData4.Count != 0)
            {
                message = "����`�[(��)�ɑ΂��ėa����̓������s���Ă���f�[�^������܂��B";
                // �s���f�[�^���Z�b�g����
                drDmdSalesList = (DataRow[])alMistakeData4.ToArray(typeof(DataRow));
                return 4;
            }

            // ��(��[���E�ςݍ�])�ɑ΂��ėa��������̎�
            if (alMistakeData5.Count != 0)
            {
                message = "����`�[(��[���E�ςݍ�])�ɑ΂��ėa����̓������s���Ă���f�[�^������܂��B";
                // �s���f�[�^���Z�b�g����
                drDmdSalesList = (DataRow[])alMistakeData5.ToArray(typeof(DataRow));
                return 5;
            }
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // ������������Z�b�g����
			drDmdSalesList = (DataRow[])alUpdateData.ToArray(typeof(DataRow));
			
			return 0;
		}

		/// <summary>
		/// �����`�[�X�V�O�m�F���b�Z�[�W����
		/// </summary>
		/// <param name="updateDepositParameter">�����X�V�p�N���X</param>
		/// <param name="drDmdSalesQuestionList">��������m�F���DataRow</param>
		/// <param name="messages">�s�����b�Z�[�W</param>
		/// <returns>�ύX�X�e�[�^�X 0:����. -1:�����s��</returns>
		/// <remarks>
		/// <br>Note       : �ۑ��f�[�^���`�F�b�N���A�ۑ��O�̊m�F���b�Z�[�W��Ԃ��܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int CheckUpdateDepositQuestion(UpdateDepositParameter updateDepositParameter, out ArrayList drDmdSalesQuestionList, out StringCollection messages)
		{
			int st = 0;
			messages = new StringCollection();
			drDmdSalesQuestionList = new ArrayList();

			ArrayList alQuestionData1 = new ArrayList();
			ArrayList alQuestionData2 = new ArrayList();

			// �����������S�����[�v
			foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
			{
				// �����z ���� (���������z) �����鎞
				if (Convert.ToInt64(dr[ctDepositAllowance_Alw]) != 0)
				{
                    // �� 20070202 18322 c MA.NS�p�ɕύX
					//// �ʏ�����Ŏ󒍃X�e�[�^�X���[�i���ȊO�̎�
					//if ((Convert.ToInt64(updateDepositParameter.DepositCd) == 0) && (Convert.ToInt32(dr[ctAcptAnOdrStatus]) != 30))
					//{
					//	alQuestionData1.Add(dr);
					//}

                    // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                    //if (Convert.ToInt32(updateDepositParameter.DepositCd) == 0)
                    //{
                    //    // �ʏ�����̎�
                    //    switch (Convert.ToInt32(dr[ctAcptAnOdrStatus]))
                    //    {
                    //        case 30 :    // ����
                    //        //case 40 :    // ����     // 2007.10.05 del
                    //        //case 55 :    // �ϑ��v�� // 2007.10.05 del
                    //            break;
                    //        default :
                    //            // ��L�ȊO�̓`�[
                    //            alQuestionData1.Add(dr);
                    //            break;
                    //    }
                    //}
                    // �ʏ�����̎�
                    switch (Convert.ToInt32(dr[ctAcptAnOdrStatus]))
                    {
                        case 30:    // ����
                            break;
                        default:
                            // ��L�ȊO�̓`�[
                            alQuestionData1.Add(dr);
                            break;
                    }
                    // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
                    // �� 20070202 18322 c

					// �����c ���� (��������}�X�^) < 0 �������c ���� (��������}�X�^)���}�C�i�X�̎�
					if (Convert.ToInt32(dr[ctDepositAlwcBlnce_Sales]) < 0)
					{
						// �����z ���� (���������z) > 0 �������z ���� (���������z)���v���X�̎�
						if (Convert.ToInt32(dr[ctDepositAllowance_Alw]) > 0)
						{
							alQuestionData2.Add(dr);
						}
					}
				}
			}

			// ���Ϗ�/�w�����ɑ΂��Ă̒ʏ����
			if (alQuestionData1.Count != 0)
			{
                // �� 20070202 18322 c MA.NS�p�ɕύX
				//messages.Add("�a����敪���ʏ�����Ƃ��āA���Ϗ�/�w�����ɓ�������Ă���f�[�^������܂��B" + "\r\n\r\n" + 
				//	"���̂܂ܕۑ����Ă�낵���ł����H");

				messages.Add("�a����敪���ʏ�����Ƃ��āA����/����/�ϑ��v��ȊO�̓`�[�ɓ�������Ă���f�[�^������܂��B" + "\r\n\r\n" + 
					"���̂܂ܕۑ����Ă�낵���ł����H");
                // �� 20070202 18322 c

				// �s���f�[�^���Z�b�g����
				DataRow[] dr = (DataRow[])alQuestionData1.ToArray(typeof(DataRow));
				drDmdSalesQuestionList.Add(dr);
				st = 1;
			}

			// �ߏ�����ɑ΂��Ă̒ʏ����
			if (alQuestionData2.Count != 0)
			{
				messages.Add("����z�ȏ�̓���������Ă���f�[�^������܂��B" + "\r\n\r\n" + 
					"���̂܂ܕۑ����Ă�낵���ł����H");
				// �s���f�[�^���Z�b�g����
				DataRow[] dr = (DataRow[])alQuestionData2.ToArray(typeof(DataRow));
				drDmdSalesQuestionList.Add(dr);
				st = 1;
			}

			return st;
        }

        #region DEL 2008/06/26 Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �����f�[�^�X�V����
		/// </summary>
		/// <param name="updateDepositParameter">�����X�V�p�N���X</param>
		/// <param name="drDmdSalesList">�X�V�Ώې�������DataRow</param>
		/// <param name="message">�G���[���������b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : �������̍X�V�������s���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int SaveDepositData(UpdateDepositParameter updateDepositParameter, DataRow[] drDmdSalesList, out string message)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";

			try
			{
				// �����}�X�^�X�V���e�Z�b�g����
				ArrayList alCreateDepsitMainWork;
				this.SetUpdateDepositData(updateDepositParameter, drDmdSalesList, out alCreateDepsitMainWork);

				CreateDepsitMainWork[] createDepsitMainWorkList = (CreateDepsitMainWork[])alCreateDepsitMainWork.ToArray(typeof(CreateDepsitMainWork));

				// �X�V�����I
                // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
				int[] depositSlipNoList;
                //this.WriteDepositData(updateDepositParameter.EnterpriseCode, createDepsitMainWorkList, out depositSlipNoList);

                st = _depsitMainAcs.WriteDB(updateDepositParameter.EnterpriseCode, createDepsitMainWorkList, out depositSlipNoList, out message);

                // �G���[�̎��͗�O�𔭐�������
                if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    throw new DepositException(message, st);
                }
                // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

				// �V�K�쐬���������ԍ��𐿋�����DataRow�ɖ��ߍ���
				for (int ix = 0; ix < createDepsitMainWorkList.Length; ix++)
				{
					// �����������S�����[�v
					foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
					{
                        // ���ꔄ��ԍ��̎��A�X�V���ʃ��X�g�̓���Index�������ԍ����擾����
                        if ((string)dr[ctSalesSlipNum] == createDepsitMainWorkList[ix].SalesSlipNum)
						{
							if (ix <= depositSlipNoList.Length)
							{
								UpdateDepositParameter para = updateDepositParameter.Clone();
								para.DepositSlipNo = (Int32)depositSlipNoList[ix];
								dr[ctUpdateDepositParameter] = para;
							}
							break;
						}
					}
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
        #endregion DEL 2008/06/26 Partsman�p�ɕύX

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �����f�[�^�X�V����
        /// </summary>
        /// <param name="updateDepositParameter">�����X�V�p�N���X</param>
        /// <param name="drDmdSalesList">�X�V�Ώې�������DataRow</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �������̍X�V�������s���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int SaveDepositData(UpdateDepositParameter updateDepositParameter, DataRow[] drDmdSalesList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                // �����}�X�^�X�V���e�Z�b�g����
                SearchDepsitMain depsitMain;
                Hashtable htDepositAlw;
                SetUpdateDepositData(updateDepositParameter, drDmdSalesList, out depsitMain, out htDepositAlw);

                // �N���X�����o�[�R�s�[����
                DepsitDataWork depsitDataWork = CopyToDepsitDataWorkFromDepsitMain(depsitMain);             // �i�����}�X�^�˓����}�X�^���[�N�j
                DepositAlwWork[] depositAlwWorkList = CopyToDepositAlwWorkFromDepositAlw(htDepositAlw);     // �i���������}�X�^�˓��������}�X�^���[�N�j

                // �X�V����
                status = this._depsitMainAcs.WriteDB(ref depsitDataWork, ref depositAlwWorkList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }

                // �V�K�쐬���������ԍ��𐿋�����DataRow�ɖ��ߍ���
                for (int ix = 0; ix < depositAlwWorkList.Length; ix++)
                {
                    // �����������S�����[�v
                    foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
                    {
                        // ���ꔄ��ԍ��̎��A�X�V���ʃ��X�g�̓���Index�������ԍ����擾����
                        if ((string)dr[ctSalesSlipNum] == depositAlwWorkList[ix].SalesSlipNum)
                        {
                            if (ix <= depositAlwWorkList.Length)
                            {
                                UpdateDepositParameter para = updateDepositParameter.Clone();
                                para.DepositSlipNo = (Int32)depositAlwWorkList[ix].DepositSlipNo;
                                dr[ctUpdateDepositParameter] = para;
                            }
                            break;
                        }
                    }
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

        // --------------- ADD START 2010.05.06 gejun FOR M1007A-M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>

        /// <summary>
        /// �����f�[�^�X�V����(��`�f�[�^���A���)
        /// </summary>
        /// <param name="updateDepositParameter">�����X�V�p�N���X</param>
        /// <param name="drDmdSalesList">�X�V�Ώې�������DataRow</param>
        /// <param name="message">�G���[���������b�Z�[�W</param>
        /// <param name="rcvDraftDataUpd">��`�f�[�^�i�X�V�p�j</param>
        /// <param name="rcvDraftDataDel">��`�f�[�^�i�폜�p�j</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �����A��`���̍X�V�������s���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010/05/06</br>
        /// </remarks>
        public int SaveDepositDataWithDraftData(UpdateDepositParameter updateDepositParameter, DataRow[] drDmdSalesList, out string message, RcvDraftData rcvDraftDataUpd, RcvDraftData rcvDraftDataDel)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                // �����}�X�^�X�V���e�Z�b�g����
                SearchDepsitMain depsitMain;
                Hashtable htDepositAlw;
                SetUpdateDepositData(updateDepositParameter, drDmdSalesList, out depsitMain, out htDepositAlw);

                // �N���X�����o�[�R�s�[����
                DepsitDataWork depsitDataWork = CopyToDepsitDataWorkFromDepsitMain(depsitMain);             // �i�����}�X�^�˓����}�X�^���[�N�j
                DepositAlwWork[] depositAlwWorkList = CopyToDepositAlwWorkFromDepositAlw(htDepositAlw);     // �i���������}�X�^�˓��������}�X�^���[�N�j

                RcvDraftDataWork rcvDraftDataWorkUpd;
                if (rcvDraftDataUpd != null)
                    rcvDraftDataWorkUpd = CopyToRcvDraftDataWorkFromRcvDraftData(rcvDraftDataUpd);
                else
                    rcvDraftDataWorkUpd = null;

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

                // �V�K�쐬���������ԍ��𐿋�����DataRow�ɖ��ߍ���
                for (int ix = 0; ix < depositAlwWorkList.Length; ix++)
                {
                    // �����������S�����[�v
                    foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
                    {
                        // ���ꔄ��ԍ��̎��A�X�V���ʃ��X�g�̓���Index�������ԍ����擾����
                        if ((string)dr[ctSalesSlipNum] == depositAlwWorkList[ix].SalesSlipNum)
                        {
                            if (ix <= depositAlwWorkList.Length)
                            {
                                UpdateDepositParameter para = updateDepositParameter.Clone();
                                para.DepositSlipNo = (Int32)depositAlwWorkList[ix].DepositSlipNo;
                                dr[ctUpdateDepositParameter] = para;
                            }
                            break;
                        }
                    }
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
        // --------------- ADD END 2010.05.06 gejun FOR M1007A-M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>

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

		/// <summary>
		/// ���Ӑ於�̎擾����
		/// </summary>
		/// <param name="logicalMode">�_���폜�敪</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="name">���Ӑ於��</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : ���Ӑ於�̂̎擾�������s���܂��B</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
        public int ReadCustomer(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int customerCode, out string name, out int claimCode)
		{
			name = "";
            claimCode = 0;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			// �p�����[�^����
			CustomerWork customerWork = new CustomerWork();
			customerWork.EnterpriseCode		= enterpriseCode;
			customerWork.CustomerCode		= customerCode;

			ArrayList paraList = new ArrayList();
			paraList.Add(customerWork);
			object obj = (object)paraList;
			
			// ���Ӑ�Ǎ�����
			int st = this._iCustomerInfoDB.Read(logicalMode, ref obj);
			if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				ArrayList list = obj as ArrayList;
				if (list != null)
				{
					CustomerWork ret = list[0] as CustomerWork;
					if (ret != null)
					{
						name = ret.Name + " " + ret.Name2;
                        claimCode = ret.ClaimCode;
					}
				}
			}
            
            return st;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
            int status;
            CustomerInfo customerInfo;

            try
            {
                status = this._customerInfoAcs.ReadDBData(enterpriseCode, customerCode, out customerInfo);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    name = customerInfo.Name.Trim() + customerInfo.Name2.Trim();
                    claimCode = customerInfo.ClaimCode;
                }
            }
            catch
            {
                status = -1;
            }

            return status;
            // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<
		}

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �̎����f�[�^�쐬����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���s���_�R�[�h</param>
        /// <param name="selectedDmdSalesRow">��������DataRow</param>
        /// <returns>�̎����f�[�^</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : ���������̎����f�[�^���쐬���܂��B</br>
        /// <br>Programmer  : 97036 amami</br>
        /// <br>Date        : 2005.07.21</br>
        /// </remarks>
        public Receipt SetReceiptFromDepositDataRow(string enterpriseCode, string sectionCode, DataRow selectedDmdSalesRow)
        {
            Receipt receipt = new Receipt();

            // �� 20070125 18322 c MA.NS�p�ɕύX
            //SearchDmdSalesCustomer searchDmdSalesCustomer = selectedDmdSalesRow[ctSearchDmdSalesCustomer] as SearchDmdSalesCustomer;

            SearchClaimSales searchDmdSalesCustomer = selectedDmdSalesRow[ctSearchClaimSales] as SearchClaimSales;
            // �� 20070125 18322 c
            UpdateDepositParameter updateDepositParameter = selectedDmdSalesRow[ctUpdateDepositParameter] as UpdateDepositParameter;

            receipt.EnterpriseCode = enterpriseCode;												// ��ƃR�[�h
            receipt.CustomerCode = searchDmdSalesCustomer.CustomerCode;							// ���Ӑ�R�[�h
            // �� 20070125 18322 c MA.NS�p�ɕύX
            //receipt.ReceiptAddress1		= searchDmdSalesCustomer.Name;									// �̎��������P
            //receipt.ReceiptAddress2		= searchDmdSalesCustomer.Name2;									// �̎��������Q

            receipt.ReceiptAddress1 = searchDmdSalesCustomer.CustomerName;							// �̎��������P
            receipt.ReceiptAddress2 = searchDmdSalesCustomer.CustomerName2;							// �̎��������Q
            // �� 20070125 18322 c
            receipt.RectHonorificTitle = searchDmdSalesCustomer.HonorificTitle;						// �̎��������h��
            receipt.ReceiptMoney = Convert.ToInt64(selectedDmdSalesRow[ctDepositAllowance_Alw]);	// �̎������z
            receipt.ReceiptIssueNote = "";															// �̎������l���e�i���s���j
            receipt.ReceiptIssueOrgCd = 1;															// �̎������s�敪 0:���ρE�[�i,1:����,2:�̎���
            receipt.DepositSlipNo = updateDepositParameter.DepositSlipNo;							// �����`�[�ԍ�
            receipt.AcceptAnOrderNo = 0;															// �󒍔ԍ�
            // �� 20070118 18322 d MA.NS�p�ɕύX
            //receipt.SlipKind			= 0;															// �`�[��� 10:����,20:�w��,21:���菑,30:�[�i,40:���C
            //receipt.SlipNo				= "";															// �`�[�ԍ�
            // �� 20070118 18322 d
            receipt.DepositKindCode = updateDepositParameter.DepositKindCode;						// ��������R�[�h
            receipt.DepositKindName =

                  (string)depositRelDataAcs.SlMoneyKindCode[updateDepositParameter.DepositKindCode];		// �������햼��
            receipt.Deposit = Convert.ToInt64(selectedDmdSalesRow[ctDepositAllowance_Alw]);	// �������z
            receipt.FeeDeposit = 0;															// �萔�������z
            receipt.DiscountDeposit = 0;															// �l�������z
            // �� 20070118 18322 d
            //receipt.ReceiptIssueSecCd	= sectionCode;													// �̎������s���_�R�[�h
            // �� 20070118 18322 d
            receipt.ReceiptPrintDate = TDateTime.GetSFDateNow();										// �̎������s���t

            return receipt;
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �̎����f�[�^�쐬����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���s���_�R�[�h</param>
		/// <param name="selectedDmdSalesRow">��������DataRow</param>
		/// <returns>�̎����f�[�^</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : ���������̎����f�[�^���쐬���܂��B</br>
		/// <br>Programmer  : 30414 �E �K�j</br>
		/// <br>Date        : 2008/06/26</br>
		/// </remarks>
		public Receipt SetReceiptFromDepositDataRow(string enterpriseCode, string sectionCode, DataRow selectedDmdSalesRow)
		{
			Receipt receipt = new Receipt();

			SearchClaimSales searchDmdSalesCustomer = selectedDmdSalesRow[ctSearchClaimSales] as SearchClaimSales;
			UpdateDepositParameter updateDepositParameter = selectedDmdSalesRow[ctUpdateDepositParameter] as UpdateDepositParameter;

			receipt.EnterpriseCode		= enterpriseCode;												// ��ƃR�[�h
            receipt.CustomerCode		= searchDmdSalesCustomer.CustomerCode;							// ���Ӑ�R�[�h
			receipt.ReceiptAddress1		= searchDmdSalesCustomer.CustomerName;							// �̎��������P
			receipt.ReceiptAddress2		= searchDmdSalesCustomer.CustomerName2;							// �̎��������Q
			receipt.RectHonorificTitle	= searchDmdSalesCustomer.HonorificTitle;						// �̎��������h��
			receipt.ReceiptMoney		= Convert.ToInt64(selectedDmdSalesRow[ctDepositAllowance_Alw]);	// �̎������z
			receipt.ReceiptIssueNote	= "";															// �̎������l���e�i���s���j
			receipt.ReceiptIssueOrgCd	= 1;															// �̎������s�敪 0:���ρE�[�i,1:����,2:�̎���
			receipt.DepositSlipNo		= updateDepositParameter.DepositSlipNo;							// �����`�[�ԍ�
			receipt.AcceptAnOrderNo		= 0;															// �󒍔ԍ�
            receipt.DepositKindCode = updateDepositParameter.MoneyKindCode;						        // ��������R�[�h
			receipt.DepositKindName		=
                  (string)depositRelDataAcs.DicMoneyKindCode[updateDepositParameter.MoneyKindCode];		// �������햼��
            receipt.Deposit = Convert.ToInt64(selectedDmdSalesRow[ctDepositAllowance_Alw]);	            // �������z
			receipt.FeeDeposit			= 0;															// �萔�������z
			receipt.DiscountDeposit		= 0;															// �l�������z
			receipt.ReceiptPrintDate	= TDateTime.GetSFDateNow();										// �̎������s���t

			return receipt;
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        // --- ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� ------->>>>> 
        /// <summary>
        /// ���J�g�\�ʃI�v�V��������
        /// </summary>
        public bool KaToOption()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_KatoCustom);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // --- ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� -------<<<<<
        # endregion

        # region Private Methods
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

        // �� 20070125 18322 c MA.NS�p�ɕύX
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
		//	ArrayList arrDmdSalesCustomer;
		//	SearchParaDmdSalesRead searchParaDmdSalesRead = new SearchParaDmdSalesRead();
		//	searchParaDmdSalesRead.EnterpriseCode	= searchSalesParameter.EnterpriseCode;			// ��ƃR�[�h
		//	searchParaDmdSalesRead.AddUpSecCode		= searchSalesParameter.AddUpSecCod;				// �v�㋒�_
		//	searchParaDmdSalesRead.ClaimCode		= searchSalesParameter.CustomerCode;			// ������R�[�h
		//	searchParaDmdSalesRead.AcceptAnOrderNo	= searchSalesParameter.AcceptAnOrderNo;			// �󒍔ԍ�
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
		//	int st = _searchDmdSalesAcs.SearchCustDB(searchParaDmdSalesRead, out arrDmdSalesCustomer, out errMsg);
		//	
		//	switch (st)
		//	{
		//		case (int)ConstantManagement.DB_Status.ctDB_NORMAL :
		//
		//			// �擾��������f�[�^���R���N�V�����ɕۑ�
		//			SearchDmdSalesCustomer[] listDmdSalesCustomer = (SearchDmdSalesCustomer[])arrDmdSalesCustomer.ToArray(typeof(SearchDmdSalesCustomer));
		//
		//			// ����������f�[�^�e�[�u�� �f�[�^�Z�b�g����
		//			foreach(SearchDmdSalesCustomer dmdSalesCustomer in listDmdSalesCustomer)
		//			{
		//				// ���`�̂ݑΏۂƂ��� �����Ƃł���IF����ꂽ�̂ŉ�ʐ���̐Ԃ⌳���̃��W�b�N�͓��ꂽ�܂܂ɂ��Ă���
		//				if (!((dmdSalesCustomer.DebitNoteDiv == 0) && (dmdSalesCustomer.DebitNLnkAcptAnOdr == 0)))
		//				{
		//					continue;
		//				}
		//
		//				// ����������DataSet�̍s��V�K�쐬����
		//				DataRow drNew = this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].NewRow();
		//
		//				// ����������DataRow�Z�b�g����
		//				SetDmdSalesCustomer(drNew, dmdSalesCustomer);
		//
		//				// ����������DataSet�̍s��ǉ�����
		//				this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Add(drNew);
		//			}
		//
		//			// �ԓ`�݂̂̎��Ȃǂ͌������O���ɂȂ�
		//			if (this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Count == 0)
		//			{
		//				st = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//			}
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
		/// ����������擾����
		/// </summary>
		/// <param name="searchSalesParameter">����������擾�p�p�����[�^</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note�@�@�@  : ������������f�[�^�Z�b�g�Ɏ擾���܂��B
		///					: �G���[����DepositException��O���������܂��B</br>
		/// <br>Programmer  : 18322 T.Kimura</br>
		/// <br>Date        : 2007.01.25</br>
		/// </remarks>
		private int GetDmdSalesInfo(SearchSalesParameter searchSalesParameter, int consTaxLayMethod)
		{
			string errMsg;
			
			ArrayList arrDmdSalesCustomer;

            // ���㌎���X�V�����擾
            this._lastMonthlyAddUpDay = GetHisTotalDayMonthlyAccRec(searchSalesParameter.DemandAddUpSecCd);

            // ��������������擾
            this._lastAddUpDay = GetTotalDayDmdC(searchSalesParameter.DemandAddUpSecCd, searchSalesParameter.ClaimCode);

            SearchParaClaimSalesRead searchParaDmdSalesRead = new SearchParaClaimSalesRead();

			// ��ƃR�[�h
			searchParaDmdSalesRead.EnterpriseCode	= searchSalesParameter.EnterpriseCode;
			// �v�㋒�_
			searchParaDmdSalesRead.DemandAddUpSecCd = searchSalesParameter.DemandAddUpSecCd;
            // �󒍃X�e�[�^�X
            searchParaDmdSalesRead.AcptAnOdrStatus = searchSalesParameter.AcptAnOdrStatus;
            // ����`�[�ԍ�
            searchParaDmdSalesRead.SalesSlipNum = searchSalesParameter.SalesSlipNum;
            // ������R�[�h
			searchParaDmdSalesRead.ClaimCode		= searchSalesParameter.ClaimCode;
            // ���Ӑ�R�[�h
            searchParaDmdSalesRead.CustomerCode     = searchSalesParameter.CustomerCode;
            // �����ϐ�������`�[�ďo�敪
            searchParaDmdSalesRead.AlwcSalesSlipCall = searchSalesParameter.AlwcSalesSlipCall;
            //=================
            // �`�[���t
            //=================
			if (searchSalesParameter.SearchSlipDateStart == 0)
			{
				// �`�[���t �J�n
				searchParaDmdSalesRead.SearchSlipDateStart	= TDateTime.DateTimeToLongDate(DateTime.MinValue);
			}
			else
			{
			    // �`�[���t �J�n
				searchParaDmdSalesRead.SearchSlipDateStart	= searchSalesParameter.SearchSlipDateStart;
			}
			if (searchSalesParameter.SearchSlipDateEnd == 0)
			{
				// �`�[���t �I��
				searchParaDmdSalesRead.SearchSlipDateEnd	= TDateTime.DateTimeToLongDate(DateTime.MaxValue);
			}
			else
			{
			    // �`�[���t �I��
				searchParaDmdSalesRead.SearchSlipDateEnd	= searchSalesParameter.SearchSlipDateEnd;
			}
            //=================
            // �v���
            //=================
			if (searchSalesParameter.AddUpADateStart == 0)
			{
				// �v��� �J�n
				searchParaDmdSalesRead.AddUpADateStart	= TDateTime.DateTimeToLongDate(DateTime.MinValue);
			}
			else
			{
				// �v��� �J�n
				searchParaDmdSalesRead.AddUpADateStart	= searchSalesParameter.AddUpADateStart;
			}
			if (searchSalesParameter.AddUpADateEnd == 0)
			{
				// �v��� �I��
				searchParaDmdSalesRead.AddUpADateEnd	= TDateTime.DateTimeToLongDate(DateTime.MaxValue);
			}
			else
			{
				// �v��� �I��
				searchParaDmdSalesRead.AddUpADateEnd	= searchSalesParameter.AddUpADateEnd;
			}

			// �̔��]�ƈ��R�[�h
			searchParaDmdSalesRead.SalesEmployeeCd	= searchSalesParameter.SalesEmployeeCd;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            // �T�[�r�X�`�[�敪
			searchParaDmdSalesRead.ServiceSlipCd	= searchSalesParameter.ServiceSlipCd;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // ���|�敪
			searchParaDmdSalesRead.AccRecDivCd      = searchSalesParameter.AccRecDivCd;

            // ���������敪
			searchParaDmdSalesRead.AutoDepositCd	= searchSalesParameter.AutoDepositCd;

			// --- ����������擾���� --- //
			int st = _searchDmdSalesAcs.SearchCustDB(searchParaDmdSalesRead, out arrDmdSalesCustomer, out errMsg);

			switch (st)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL :

					// �擾��������f�[�^���R���N�V�����ɕۑ�
					SearchClaimSales[] listDmdSalesCustomer = (SearchClaimSales[])arrDmdSalesCustomer.ToArray(typeof(SearchClaimSales));

                    // ����������f�[�^�e�[�u�� �f�[�^�Z�b�g����
					foreach(SearchClaimSales dmdSalesCustomer in listDmdSalesCustomer)
					{
						// ���`�̂ݑΏۂƂ���
                        // �����Ƃł���IF����ꂽ�̂ŉ�ʐ���̐Ԃ⌳���̃��W�b�N�͓��ꂽ�܂܂ɂ��Ă���
                        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                        //if (!((dmdSalesCustomer.DebitNoteDiv == 0) &&
                        //      (dmdSalesCustomer.DebitNLnkAcptAnOdr == 0)))
                        //{
                        //    continue;
                        //}
                        //if (!(dmdSalesCustomer.DebitNoteDiv == 0))
                        //{
                        //    continue;
                        //}
                        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

                        // ����������DataSet�̍s��V�K�쐬����
						DataRow drNew = this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].NewRow();

						// ����������DataRow�Z�b�g����
						SetDmdSalesCustomer(drNew, dmdSalesCustomer, consTaxLayMethod);

						// ����������DataSet�̍s��ǉ�����
						this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Add(drNew);
					}

                    // --- ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� ------->>>>> 
                    // �I�v�V��������
                    if (KaToOption())
                    {
                        //Dictionary<string, ControlKaToDepsitAlwWork> dic = new Dictionary<string, ControlKaToDepsitAlwWork>(); // DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p����
                        Dictionary<string, DepositAlwWork> dic = new Dictionary<string, DepositAlwWork>();// ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p����
                        int salesSlipNumSt = 0;
                        int salesSlipNumEd = 0;
                        // --- ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� ------->>>>>
                        if (this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Count > 0)
                        {
                            // ����`�[�J�n�ƏI��������
                            salesSlipNumSt = Convert.ToInt32(this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows[0][ctSalesSlipNum]);
                            salesSlipNumEd = Convert.ToInt32(this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows[0][ctSalesSlipNum]);
                        }
                        // --- ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� -------<<<<<

                        // ����`�[�ԍ��͈�
                        foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
                        {
                            int salesSlipNum = Convert.ToInt32(dr[ctSalesSlipNum]);
                            if (salesSlipNum <= salesSlipNumSt || salesSlipNumSt == 0)
                            {
                                salesSlipNumSt = salesSlipNum;
                            }
                            if (salesSlipNum >= salesSlipNumEd)
                            {
                                salesSlipNumEd = salesSlipNum;
                            }
                        }
                        // --- ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� ------->>>>> 
                        DepositAlwWork controlKaToDepsitAlwCndtnWork = new DepositAlwWork();
                        controlKaToDepsitAlwCndtnWork.CustomerCode = searchSalesParameter.ClaimCode;
                        controlKaToDepsitAlwCndtnWork.EnterpriseCode = searchSalesParameter.EnterpriseCode;
                        controlKaToDepsitAlwCndtnWork.SalesSlipNum = salesSlipNumSt.ToString().PadLeft(9, '0') + ";" + salesSlipNumEd.ToString().PadLeft(9, '0');
                        // --- ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� -------<<<<< 

                        // --- DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� ------->>>>> 
                        //ControlKaToDepsitAlwCndtnWork controlKaToDepsitAlwCndtnWork = new ControlKaToDepsitAlwCndtnWork();
                        //controlKaToDepsitAlwCndtnWork.CustomerCode = searchSalesParameter.ClaimCode;
                        //controlKaToDepsitAlwCndtnWork.EnterpriseCode = searchSalesParameter.EnterpriseCode;
                        //controlKaToDepsitAlwCndtnWork.AcptAnOdrStatus = 30;
                        //controlKaToDepsitAlwCndtnWork.SalesSlipNumSt = salesSlipNumSt.ToString().PadLeft(9, '0');
                        //controlKaToDepsitAlwCndtnWork.SalesSlipNumEd = salesSlipNumEd.ToString().PadLeft(9, '0');
                        // --- DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� -------<<<<<
                        this._iControlDepsitAlwDB = (IControlDepsitAlwDB)MediationControlDepsitAlwDB.GetControlDepsitAlwDB();
                        object controlKaToDepsitAlwResultWork = null;

                        // ������������f�[�^�̎擾
                        st = this._iControlDepsitAlwDB.Search(out controlKaToDepsitAlwResultWork, (object)controlKaToDepsitAlwCndtnWork);

                        // ����̏ꍇ
                        if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                            || st == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND
                            || st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                        {
                            st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            //foreach (ControlKaToDepsitAlwWork work in (ArrayList)controlKaToDepsitAlwResultWork) // DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p����
                            foreach (DepositAlwWork work in (ArrayList)controlKaToDepsitAlwResultWork) // ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p����
                            {
                                string newSalesSlipNum = work.SalesSlipNum.ToString().PadLeft(9, '0');
                                if (!dic.ContainsKey(newSalesSlipNum))
                                {
                                    dic.Add(newSalesSlipNum, work);
                                }
                            }

                            // --- ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� ------->>>>>
                            // �O���b�h�ɐݒ�
                            foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
                            {
                                string salesSlipNum = dr[ctSalesSlipNum].ToString();
                                if (dic.ContainsKey(salesSlipNum))
                                {
                                    // ������
                                    dr[ctDepositDate] = dic[salesSlipNum].ReconcileDate.ToString("d");

                                    // ���Ӑ於->����
                                    dr[ctDepositKindName] = dic[salesSlipNum].CustomerName;
                                }
                            }
                            // --- ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� -------<<<<<

                            // --- DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� ------->>>>>
                            // �O���b�h�ɐݒ�
                            //foreach (DataRow dr in this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows)
                            //{
                            //    string salesSlipNum = dr[ctSalesSlipNum].ToString();
                            //    if (dic.ContainsKey(salesSlipNum))
                            //    {
                            //        string date = dic[salesSlipNum].ReconcileDate.ToString();
                            //        // ������
                            //        dr[ctDepositDate] = date.Substring(0, 4) + "/" + date.Substring(4, 2) + "/" + date.Substring(6, 2);

                            //        // ����
                            //        dr[ctDepositKindName] = dic[salesSlipNum].MoneyKindName;
                            //    }
                            //}
                            // --- DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p���� -------<<<<<
                        }
                    }
                    // --- ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� -------<<<<<

					// �ԓ`�݂̂̎��Ȃǂ͌������O���ɂȂ�
					if (this._dsDmdSalesInfo.Tables[ctDmdSalesDataTable].Rows.Count == 0)
					{
						st = (int)ConstantManagement.DB_Status.ctDB_EOF;
					}

					break;

				case (int)ConstantManagement.DB_Status.ctDB_EOF :

					break;

				default :

					throw new DepositException(errMsg, st);
			}

			return st;
		}
        // �� 20070125 18322 c

        // �� 20070125 18322 c MA.NS�p�ɕύX
        #region SF ����������DetaRow�Z�b�g�����i�S�ăR�����g�A�E�g�j
		///// <summary>
		///// ����������DetaRow�Z�b�g����
		///// </summary>
		///// <param name="drNew">����������DataRow</param>
		///// <param name="dmdSalesCustomer">��������N���X</param>
		///// <remarks>
		///// <br>Note�@�@�@  : �����������DataRow�ɃZ�b�g���܂��B</br>
		///// <br>Programmer  : 97036 amami</br>
		///// <br>Date        : 2005.07.21</br>
		///// </remarks>
		//private void SetDmdSalesCustomer(System.Data.DataRow drNew, SearchDmdSalesCustomer dmdSalesCustomer)
		//{
		//	// ��
		//	drNew[ctAlwCheck] = false;
		//
		//	// �ԍ��敪/����
		//	switch (dmdSalesCustomer.DebitNoteDiv)
		//	{
		//		case 0:
		//			if (dmdSalesCustomer.DebitNLnkAcptAnOdr == 0)
		//			{
		//				drNew[ctDebitNoteDiv] = dmdSalesCustomer.DebitNoteDiv;
		//				drNew[ctDebitNoteNm] = "��";
		//			}
		//			else
		//			{
		//				drNew[ctDebitNoteDiv] = 2;					// ���E�ςݍ���2�ɂ��肩����
		//				drNew[ctDebitNoteNm] = "���E�ςݍ�";
		//			}
		//			break;
		//		case 1:
		//			drNew[ctDebitNoteDiv] = dmdSalesCustomer.DebitNoteDiv;
		//			drNew[ctDebitNoteNm] = "��";
		//			break;
		//	}
		//
		//	// �󒍔ԍ�
		//	drNew[ctAcceptAnOrderNo] = dmdSalesCustomer.AcceptAnOrderNo;
		//		
		//	// �`�[�ԍ�
		//	drNew[ctSlipNo] = dmdSalesCustomer.SlipNo;
		//		
		//	if (System.DateTime.MinValue != dmdSalesCustomer.SearchSlipDate)
		//	{
		//		// �`�[���t(�\���p)
		//		drNew[ctSearchSlipDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd", dmdSalesCustomer.SearchSlipDate);
		//		
		//		// �`�[���t
		//		drNew[ctSearchSlipDate] = TDateTime.DateTimeToLongDate(dmdSalesCustomer.SearchSlipDate);
		//	}
		//
		//	if (System.DateTime.MinValue != dmdSalesCustomer.AddUpADate)
		//	{
		//		// �����
		//		drNew[ctAddUpADate] = TDateTime.DateTimeToLongDate(dmdSalesCustomer.AddUpADate);
		//	}
		//
		//	// ���Ӑ�R�[�h
		//	drNew[ctCustomerCode] = dmdSalesCustomer.ClaimCode;
		//		
		//	// ���Ӑ於��
		//	drNew[ctCustomerName] = dmdSalesCustomer.Name + " " + dmdSalesCustomer.Name2;
		//		
		//	// �󒍎��
		//	string str = "";
		//	if (depositRelDataAcs.IntroducedSystemCount == 1)
		//	{
		//		switch (dmdSalesCustomer.AcptAnOdrStatus)
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
		//		switch (dmdSalesCustomer.DataInputSystem)
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
		//		switch (dmdSalesCustomer.AcptAnOdrStatus)
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
		//	drNew[ctDataInputSystem] = dmdSalesCustomer.DataInputSystem;
		//	drNew[ctAcptAnOdrStatus] = dmdSalesCustomer.AcptAnOdrStatus;
		//	drNew[ctSalesKind] = str;
		//
		//	// ���㖼��
		//	drNew[ctSalesName] = dmdSalesCustomer.SalesName;
		//
		//	// �o�^�ԍ�
		//	drNew[ctNumberPlate] = CarInfoCalculation.GetNumberPlateString(dmdSalesCustomer.CarMngNo, dmdSalesCustomer.NumberPlate1Code, dmdSalesCustomer.NumberPlate1Name, dmdSalesCustomer.NumberPlate2, dmdSalesCustomer.NumberPlate3, dmdSalesCustomer.NumberPlate4);
		//
		//	// �󒍔���z  �󒍔���v�{�󒍏���Ŋz
		//	drNew[ctAcceptAnOrderSales] = dmdSalesCustomer.AcceptAnOrderSales + dmdSalesCustomer.AcceptAnOrderConsTax;
		//
		//	// ����p�z  ����p���z�v�{����p����Ŋz
		//	drNew[ctTotalVariousCost] = dmdSalesCustomer.TotalVariousCost + dmdSalesCustomer.VarCstConsTax;
		//
		//	// �󒍍��v�z
		//	drNew[ctTotalSales] = Convert.ToInt64(drNew[ctAcceptAnOrderSales]) + Convert.ToInt64(drNew[ctTotalVariousCost]);
		//
		//	// �����z ���� (���������z)
		//	drNew[ctAcpOdrDepositAlwc_Alw] = 0;
		//
		//	// �����c �� (��������}�X�^)
		//	drNew[ctAcpOdrDepoAlwcBlnce_Sales] = dmdSalesCustomer.AcpOdrDepoAlwcBlnce;
		//
		//	// ������ �� (��������}�X�^)
		//	drNew[ctAcpOdrDepositAlwc_Sales] = dmdSalesCustomer.AcpOdrDepositAlwc;
		//
		//	// �����z �� (���������z)
		//	drNew[ctVarCostDepoAlwc_Alw] = 0;
		//
		//	// �����c ����p (��������}�X�^)
		//	drNew[ctVarCostDepoAlwcBlnce_Sales] = dmdSalesCustomer.VarCostDepoAlwcBlnce;
		//
		//	// ������ ����p (��������}�X�^)
		//	drNew[ctVarCostDepoAlwc_Sales] = dmdSalesCustomer.VarCostDepoAlwc;
		//
		//	// �����z ����p (���������z)
		//	drNew[ctDepositAllowance_Alw] = 0;
		//
		//	// �����c ���� (��������}�X�^)
		//	drNew[ctDepositAlwcBlnce_Sales] = dmdSalesCustomer.DepositAlwcBlnce;
		//
		//	// ������ ���� (��������}�X�^)
		//	drNew[ctDepositAllowance_Sales] = dmdSalesCustomer.DepositAllowance;
		//
		//	// �ŏI�����X�V��
		//	drNew[ctLastTotalAddUpDt] = TDateTime.DateTimeToLongDate(dmdSalesCustomer.LastTotalAddUpDt);
		//
		//	// �[�i�����v����t�ƑO������X�V�̔�r
		//	if ((drNew[ctAddUpADate] != System.DBNull.Value) &&
		//	    (Convert.ToInt32(drNew[ctAddUpADate]) <= Convert.ToInt32(drNew[ctLastTotalAddUpDt])) &&
		//		(dmdSalesCustomer.AcptAnOdrStatus == 30))
		//	{
		//		drNew[ctSalesClosedFlg] = "�Y";
		//	}
		//
		//	// ��������N���X
		//	drNew[ctSearchDmdSalesCustomer] = dmdSalesCustomer;
		//
		//	// �V�K�쐬�����p�����[�^�N���X
		//	drNew[ctUpdateDepositParameter] = null;
		//
		//	// ���g��DataRow
		//	drNew[ctDmdSalesDataRow] = drNew;
		//}
        #endregion

        /// <summary>
		/// ����������DetaRow�Z�b�g����
		/// </summary>
		/// <param name="drNew">����������DataRow</param>
		/// <param name="dmdSalesCustomer">��������N���X</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �����������DataRow�ɃZ�b�g���܂��B</br>
		/// <br>Programmer  : 18322 T.Kimura</br>
		/// <br>Date        : 2007.01.25</br>
        /// <br>Update Note : 2010/12/20 ����� PM.NS��Q���ǑΉ�(12����)
        /// <br>              ���ځu�����v��ǉ�����B</br>
        /// <br>Update Date : 2011/02/09 �����</br>
        /// <br>              Redmine#18848���C������B</br>
		/// </remarks>
		private void SetDmdSalesCustomer(DataRow drNew, SearchClaimSales dmdSalesCustomer, int consTaxLayMethod)
		{
			// ��
			drNew[ctAlwCheck] = false;

			// �ԍ��敪/����
			switch (dmdSalesCustomer.DebitNoteDiv)
			{
				case 0:
                    // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
                    //if (dmdSalesCustomer.DebitNLnkAcptAnOdr == 0)
                    //{
                    //    drNew[ctDebitNoteDiv] = dmdSalesCustomer.DebitNoteDiv;
                    //    drNew[ctDebitNoteNm] = "��";
                    //}
                    //else
                    //{
                    //    drNew[ctDebitNoteDiv] = 2;					// ���E�ςݍ���2�ɂ��肩����
                    //    drNew[ctDebitNoteNm] = "���E�ςݍ�";
                    //}
                    drNew[ctDebitNoteDiv] = dmdSalesCustomer.DebitNoteDiv;
                    drNew[ctDebitNoteNm] = "��";
                    // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
					break;
				case 1:
					drNew[ctDebitNoteDiv] = dmdSalesCustomer.DebitNoteDiv;
					drNew[ctDebitNoteNm] = "��";
					break;
                case 2:
                    {
                        drNew[ctDebitNoteDiv] = dmdSalesCustomer.DebitNoteDiv;
                        drNew[ctDebitNoteNm] = "���E�ςݍ�";
                        break;
                    }
			}
	
            // ����`�[�ԍ�
			drNew[ctSalesSlipNum] = dmdSalesCustomer.SalesSlipNum;

            if (System.DateTime.MinValue != dmdSalesCustomer.SalesDate)
			{
                // �� 20070418 18322 c MA.NS�Ή�
				//// �`�[���t(�\���p)
				//drNew[ctSearchSlipDateDisp] = TDateTime.DateTimeToString("ggyy.mm.dd", dmdSalesCustomer.SearchSlipDate);

				// �`�[���t(�\���p)
                //drNew[ctSearchSlipDateDisp] = dmdSalesCustomer.SearchSlipDate.ToString("yyyy/MM/dd");
                drNew[ctSearchSlipDateDisp] = dmdSalesCustomer.SalesDate.ToString("yyyy/MM/dd");
                // �� 20070418 18322 c
				
				// �`�[���t
                //drNew[ctSearchSlipDate] = TDateTime.DateTimeToLongDate(dmdSalesCustomer.SearchSlipDate);
                drNew[ctSearchSlipDate] = TDateTime.DateTimeToLongDate(dmdSalesCustomer.SalesDate);
			}

			if (System.DateTime.MinValue != dmdSalesCustomer.AddUpADate)
			{
				// �����
				drNew[ctAddUpADate] = TDateTime.DateTimeToLongDate(dmdSalesCustomer.AddUpADate);
			}

            // ������R�[�h
            drNew[ctClaimCode] = dmdSalesCustomer.ClaimCode;

            // �����於��
            drNew[ctClaimName] = dmdSalesCustomer.ClaimSnm.Trim();

            //// ���Ӑ�R�[�h
            //drNew[ctCustomerCode] = dmdSalesCustomer.CustomerCode;
            
            // ���Ӑ於��
            drNew[ctCustomerName] = dmdSalesCustomer.CustomerSnm.Trim();

            // �󒍃X�e�[�^�X
			drNew[ctAcptAnOdrStatus] = dmdSalesCustomer.AcptAnOdrStatus;

            // �󒍃X�e�[�^�X��
			string str = "";
			switch (dmdSalesCustomer.AcptAnOdrStatus)
			{
                case 10 : str += "����"          ; break;
				case 20 : str += "��"          ; break;
                case 30 : str += "����"          ; break;
                case 40 : str += "�o��"          ; break;
			}
            drNew[ctAcptAnOdrStatusNm] = str;

            // �`�[��ށi����`�[�敪�j
            str = "";
            switch (dmdSalesCustomer.SalesSlipCd)
            {
                case 0: str = "����"; break; 
                case 1: str = "�ԕi"; break; 
                case 2: str = "�l��"; break; 
            }
            drNew[ctSalesKind] = str;
            
            //// ����`��
            //str = "";
            //switch (dmdSalesCustomer.SalesFormal)
            //{
            //    case 10 : str = "�X������"        ; break;
            //    case 11 : str = "�O��"            ; break;
            //    case 20 : str = "�Ɩ��̔��i���؁j"; break;
            //    case 25 : str = "���،v��"        ; break;
            //    case 30 : str = "�ϑ�"            ; break;
            //    case 35 : str = "�ϑ��v��"        ; break;
            //}
            //drNew[ctSalesName] = str;
            // �� 20070125 18322 c

            // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
            // �`�[���l
            drNew[ctSlipNote] = dmdSalesCustomer.SlipNote.Trim() + " " + dmdSalesCustomer.SlipNote2.Trim() + " " + dmdSalesCustomer.SlipNote3.Trim();
            // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

			// �����z ���� (���������z)
			drNew[ctDepositAllowance_Alw] = 0;

			// �����c ���� (��������}�X�^)
            if ((consTaxLayMethod == 2) || (consTaxLayMethod == 3) || (consTaxLayMethod == 9))
            {
                // --- UPD 2011/02/09 ---------->>>>>
                // �Ŕ���
                //if (dmdSalesCustomer.DepositAllowanceTtl != 0)
                //{
                //    drNew[ctDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxExc - dmdSalesCustomer.DepositAllowanceTtl;
                //    drNew[ctBfDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxExc - dmdSalesCustomer.DepositAllowanceTtl;
                //}
                //else
                //{
                //    drNew[ctDepositAlwcBlnce_Sales] = 0;
                //    drNew[ctBfDepositAlwcBlnce_Sales] = 0;
                //}

                drNew[ctDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxExc - dmdSalesCustomer.DepositAllowanceTtl;
                drNew[ctBfDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxExc - dmdSalesCustomer.DepositAllowanceTtl;
                // --- UPD 2011/02/09  ----------<<<<<
            }
            else
            {
                // --- UPD 2011/02/09 ---------->>>>>
                // �ō���
                //if (dmdSalesCustomer.DepositAllowanceTtl != 0)
                //{
                //    drNew[ctDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxInc - dmdSalesCustomer.DepositAllowanceTtl;
                //    drNew[ctBfDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxInc - dmdSalesCustomer.DepositAllowanceTtl;
                //}
                //else
                //{
                //    drNew[ctDepositAlwcBlnce_Sales] = 0;
                //    drNew[ctBfDepositAlwcBlnce_Sales] = 0;
                //}

                drNew[ctDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxInc - dmdSalesCustomer.DepositAllowanceTtl;
                drNew[ctBfDepositAlwcBlnce_Sales] = dmdSalesCustomer.SalesTotalTaxInc - dmdSalesCustomer.DepositAllowanceTtl;
                // --- UPD 2011/02/09  ----------<<<<<
            }
            
			// ������ ���� (��������}�X�^)
            drNew[ctDepositAllowance_Sales] = dmdSalesCustomer.DepositAllowanceTtl;
            drNew[ctBfDepositAllowance_Sales] = dmdSalesCustomer.DepositAllowanceTtl;

            // --- ADD 2010/12/20 ---------->>>>>
            // ����`�[�ԍ�
            drNew[ctDepSaleSlipNum] = dmdSalesCustomer.DepSalesSlipNum;

            // ����
            if ((long)drNew[ctDepositAlwcBlnce_Sales] == 0 && !string.IsNullOrEmpty(dmdSalesCustomer.DepSalesSlipNum))
            {
                // ��1:���������c��(DepositAlwcBlnce)��0�ꍇ
                drNew[ctAllowDiv] = "��";
            }
            else if (dmdSalesCustomer.DepositAllowanceTtl != 0)
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

            // ����`�[���v
            if ((consTaxLayMethod == 2) || (consTaxLayMethod == 3) || (consTaxLayMethod == 9))
            {
                // �Ŕ���
                drNew[ctSalesTotalTaxExc] = dmdSalesCustomer.SalesTotalTaxExc;
            }
            else
            {
                // �ō���
                drNew[ctSalesTotalTaxExc] = dmdSalesCustomer.SalesTotalTaxInc;
            }

            // ���|�敪(0:���|�Ȃ�,1:���|)
            drNew[ctAccRecDivCd]  = dmdSalesCustomer.AccRecDivCd;

			// �ŏI�����X�V��
            drNew[ctLastTotalAddUpDt] = TDateTime.DateTimeToLongDate(this._lastAddUpDay);

            // �ŏI�������ߓ�
            drNew[ctLastMonthlyDate] = TDateTime.DateTimeToLongDate(this._lastMonthlyAddUpDay);

            //// --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
            //// �ŏI�������ߓ�(�\���p)
            //if (this._lastMonthlyAddUpDay == DateTime.MinValue)
            //{
            //    drNew[ctLastMonthlyDateDisp] = DBNull.Value;
            //}
            //else
            //{
            //    drNew[ctLastMonthlyDateDisp] = this._lastMonthlyAddUpDay.ToString("yyyy/MM/dd");
            //}
            //// --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

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

			// ��������N���X
			drNew[ctSearchClaimSales] = dmdSalesCustomer;

			// �V�K�쐬�����p�����[�^�N���X
			drNew[ctUpdateDepositParameter] = null;

            // --- ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� ------->>>>> 
            if (KaToOption())
            {
                // �S����
                drNew[ctDepositAgentCode] = dmdSalesCustomer.SalesEmployeeNm ;
            }
            // --- ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� -------<<<<<

			// ���g��DataRow
			drNew[ctDmdSalesDataRow] = drNew;
		}
        // �� 20070125 18322 c

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �����}�X�^�X�V���e�Z�b�g����
		/// </summary>
		/// <param name="updateDepositParameter">�����X�V�p�N���X</param>
		/// <param name="drDmdSalesList">�X�V�Ώې�������DataRow</param>
		/// <param name="alCreateDepsitMainWork">�X�V�����}�X�^</param>
		/// <remarks>
		/// <br>Note       : �����}�X�^�̍X�V���e���쐬���܂��B</br>
		/// <br>Programmer : 30414 �E �K�j</br>
		/// <br>Date       : 2008/06/26</br>
        /// <br>Update Note: 2012/02/27 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/03/28�z�M��</br>
        /// <br>             Redmine#28395 ����w��^�œ��������ꍇ�A���Ӑ�q�̓���������f�[�^�ƕR�t���Ȃ��ɂ��Ă̑Ή�</br>
        /// <br>Update Note: 2012/09/21 �c����</br>
        /// <br>�Ǘ��ԍ�   : 2012/10/17�z�M��</br>
        /// <br>             Redmine#32415 ���s�҂̒ǉ��Ή�</br>
        /// </remarks>
        private void SetUpdateDepositData(UpdateDepositParameter updateDepositParameter, DataRow[] drDmdSalesList, out SearchDepsitMain depsitMain, out Hashtable htDepositAlw)
		{
            depsitMain = new SearchDepsitMain();
            htDepositAlw = new Hashtable();

            //==========================================//
            // ---            �����}�X�^            --- //
            //==========================================//
            depsitMain.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;                                    // ��ƃR�[�h

            SearchClaimSales searchClaimSales = drDmdSalesList[0][ctSearchClaimSales] as SearchClaimSales;
            depsitMain.ClaimCode = searchClaimSales.ClaimCode;                                            // ������R�[�h
            depsitMain.ClaimName = searchClaimSales.ClaimName;                                            // �����於1
            depsitMain.ClaimName2 = searchClaimSales.ClaimName2;                                          // �����於2
            depsitMain.ClaimSnm = searchClaimSales.ClaimSnm;                                              // �����旪��
            //---DEL ���N�n�� 2012/02/27 Redmine#28406------>>>>>
            //depsitMain.CustomerCode = searchClaimSales.CustomerCode;                                      // ���Ӑ�R�[�h
            //depsitMain.CustomerName = searchClaimSales.CustomerName;                                      // ���Ӑ於1
            //depsitMain.CustomerName2 = searchClaimSales.CustomerName2;                                    // ���Ӑ於2
            //depsitMain.CustomerSnm = searchClaimSales.CustomerSnm;                                        // ���Ӑ旪��
            //---DEL ���N�n�� 2012/02/27 Redmine#28406------<<<<<
            //---ADD ���N�n�� 2012/02/27 Redmine#28406------>>>>>
            depsitMain.CustomerCode = searchClaimSales.ClaimCode;                                      // ���Ӑ�R�[�h
            depsitMain.CustomerName = searchClaimSales.ClaimName;                                      // ���Ӑ於1
            depsitMain.CustomerName2 = searchClaimSales.ClaimName2;                                    // ���Ӑ於2
            depsitMain.CustomerSnm = searchClaimSales.ClaimSnm;                                        // ���Ӑ旪��
            //---ADD ���N�n�� 2012/02/27 Redmine#28406------<<<<<

            depsitMain.SubSectionCode = GetSubSectionCode(LoginInfoAcquisition.Employee.EmployeeCode);
            depsitMain.InputDepositSecCd = updateDepositParameter.InputDepositSecCd;                            // �������͋��_�R�[�h
            depsitMain.AddUpSecCode = updateDepositParameter.AddUpSecCode;                                      // �v�㋒�_�R�[�h
            depsitMain.LogicalDeleteCode = 0;                                                                   // �_���폜�敪
            depsitMain.AcptAnOdrStatus = 30;                                                                    // �󒍃X�e�[�^�X
            depsitMain.DepositDebitNoteCd = 0;                                                                  // �����ԍ��敪
            depsitMain.UpdateSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;                           // �X�V���_�R�[�h
            // DEL 2009/05/21 ------>>>
            //depsitMain.DepositDate = DateTime.Today;                                                            // �������t
            //depsitMain.AddUpADate = DateTime.Today;                                                             // �v����t
            // DEL 2009/05/21 ------<<<
            // ADD 2009/05/21 ------>>>
            depsitMain.DepositDate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);          // �������t
            depsitMain.AddUpADate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);           // �v����t
            // ADD 2009/05/21 ------<<<
            depsitMain.DepositTotal = GetDepositAlwTotal(drDmdSalesList);                                       // �����v
            depsitMain.Deposit = (GetDepositAlwTotal(drDmdSalesList) - updateDepositParameter.FeeDeposit);      // ���� �����z
            depsitMain.FeeDeposit = updateDepositParameter.FeeDeposit;                                          // ���� �萔��
            depsitMain.DiscountDeposit = 0;                                                                     // ���� �l��
            depsitMain.DraftDrawingDate = TDateTime.LongDateToDateTime(updateDepositParameter.DraftDrawingDate);// ��`�U�o��
            depsitMain.DraftKind = updateDepositParameter.DraftKind;                                            // ��`���
            depsitMain.DraftKindName = updateDepositParameter.DraftKindName;                                    // ��`��ޖ���
            depsitMain.DraftDivide = updateDepositParameter.DraftDivide;                                        // ��`�敪
            depsitMain.DraftDivideName = updateDepositParameter.DraftDivideName;                                // ��`�敪����
            depsitMain.DraftNo = updateDepositParameter.DraftNo;                                                // ��`�ԍ�
            depsitMain.DebitNoteLinkDepoNo = 0;                                                                 // �ԍ������A���ԍ�
            depsitMain.DepositAgentCode = ((Employee)LoginInfoAcquisition.Employee).EmployeeCode;               // �����S���҃R�[�h
            depsitMain.DepositAgentNm = ((Employee)LoginInfoAcquisition.Employee).Name;                         // �����S���Җ�
            //----- DEL 2012/09/21 �c���� redmine#32415 ---------->>>>>
            //depsitMain.DepositInputAgentCd = ((Employee)LoginInfoAcquisition.Employee).EmployeeCode;            // �������͎҃R�[�h
            //depsitMain.DepositInputAgentNm = ((Employee)LoginInfoAcquisition.Employee).Name;                    // �������͎Җ�
            //----- DEL 2012/09/21 �c���� redmine#32415 ----------<<<<<
            //----- ADD 2012/09/21 �c���� redmine#32415 ---------->>>>>
            depsitMain.DepositInputAgentCd = updateDepositParameter.DepositInputAgentCd;                        // �������͎҃R�[�h
            depsitMain.DepositInputAgentNm = updateDepositParameter.DepositInputAgentNm;                        // �������͎Җ�
            //----- ADD 2012/09/21 �c���� redmine#32415 ----------<<<<<
            depsitMain.Outline = updateDepositParameter.Outline;                                                // �E�v
            depsitMain.BankCode = updateDepositParameter.BankCode;                                              // ��s�R�[�h
            depsitMain.BankName = updateDepositParameter.BankName;                                              // ��s����
            depsitMain.DepositAllowance = GetDepositAlwTotal(drDmdSalesList);                                   // ���������z ����
            depsitMain.DepositAlwcBlnce = 0;                                                                    // ���������c ����

            for (int index = 0; index < depsitMain.MoneyKindName.Length; index++)
            {
                depsitMain.MoneyKindName[index] = "";
            }
            // �����s�ԍ��擾
            int depositRowNo = depositRelDataAcs.GetDepositRowNo(updateDepositParameter.MoneyKindCode);
            depsitMain.DepositRowNo[depositRowNo - 1] = depositRowNo;                                           // �����s�ԍ�
            depsitMain.MoneyKindCode[depositRowNo - 1] = updateDepositParameter.MoneyKindCode;                  // ����R�[�h
            depsitMain.MoneyKindName[depositRowNo - 1] = updateDepositParameter.MoenyKindName;                  // ���햼��
            depsitMain.MoneyKindDiv[depositRowNo - 1] = (Int32)depositRelDataAcs.HtMoneyKindDiv[updateDepositParameter.MoneyKindCode];                    // ����敪
            depsitMain.DepositDtl[depositRowNo - 1] = (GetDepositAlwTotal(drDmdSalesList) - updateDepositParameter.FeeDeposit); // �������z
            depsitMain.ValidityTerm[depositRowNo - 1] = TDateTime.LongDateToDateTime(updateDepositParameter.ValidityTerm);
            depsitMain.InputDay = DateTime.Today;

            //==========================================//
            // ---     ���������}�X�^ �V�K/�X�V     --- //
            //==========================================//
            foreach (DataRow dr in drDmdSalesList)
            {
                SearchDepositAlw depositAlw = new SearchDepositAlw();
                htDepositAlw.Add((String)dr[ctSalesSlipNum], depositAlw);
                
                depositAlw.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;                                    // ��ƃR�[�h
                depositAlw.ClaimCode = depsitMain.ClaimCode;                                                        // ������R�[�h
                depositAlw.ClaimName = depsitMain.ClaimName;                                                        // �����於1
                depositAlw.ClaimName2 = depsitMain.ClaimName2;                                                      // �����於2
                depositAlw.ClaimSnm = depsitMain.ClaimSnm;                                                          // �����旪��
                depositAlw.CustomerCode = depsitMain.CustomerCode;                                                  // ���Ӑ�R�[�h
                depositAlw.CustomerName = depsitMain.CustomerName;                                                  // ���Ӑ於1
                depositAlw.CustomerName2 = depsitMain.CustomerName2;                                                // ���Ӑ於2
                depositAlw.CustomerSnm = depsitMain.CustomerSnm;                                                    // ���Ӑ旪��
                depositAlw.AddUpSecCode = depsitMain.AddUpSecCode;                                                  // �v�㋒�_�R�[�h
                depositAlw.InputDepositSecCd = depsitMain.InputDepositSecCd;                                        // �������͋��_�R�[�h
                depositAlw.DepositSlipNo = depsitMain.DepositSlipNo;                                                // �����ԍ�
                depositAlw.AcptAnOdrStatus = (Int32)dr[ctAcptAnOdrStatus];                                          // �󒍃X�e�[�^�X
                depositAlw.SalesSlipNum = (String)dr[ctSalesSlipNum];                                               // ����`�[�ԍ�
                depositAlw.DepositAllowance = (Int64)dr[ctDepositAllowance_Alw];                                    // ���������z ����
                depositAlw.ReconcileDate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);        // �������i�������j
                depositAlw.ReconcileAddUpDate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);   // �����v����t�i�����݌v����j
                depositAlw.DepositAgentCode = depsitMain.DepositAgentCode;                                          // �����S���҃R�[�h
                depositAlw.DepositAgentNm = depsitMain.DepositAgentNm;                                              // �����S���Җ�
                depositAlw.DebitNoteOffSetCd = depsitMain.DepositDebitNoteCd;                                       // �ԓ`���E�敪
            }
        }

        /// <summary>
        /// �����z���v�擾����
        /// </summary>
        /// <param name="drDmdSalesList">�X�V�Ώې�������DataRow</param>
        /// <returns>�����z���v</returns>
        /// <remarks>
        /// <br>Note       : �����z�̍��v���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/26</br>
        /// </remarks>
        private Int64 GetDepositAlwTotal(DataRow[] drDmdSalesList)
        {
            Int64 depositAlwTotal = 0;
            foreach (DataRow dr in drDmdSalesList)
            {
                depositAlwTotal += (Int64)dr[ctDepositAllowance_Alw];
            }

            return depositAlwTotal;
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        #region 2008/06/26 DEL Partsman�p�ɕύX
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �����}�X�^�X�V���e�Z�b�g����
        /// </summary>
        /// <param name="updateDepositParameter">�����X�V�p�N���X</param>
        /// <param name="drDmdSalesList">�X�V�Ώې�������DataRow</param>
        /// <param name="alCreateDepsitMainWork">�X�V�����}�X�^</param>
        /// <remarks>
        /// <br>Note       : �����}�X�^�̍X�V���e���쐬���܂��B</br>
        /// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2005.07.21</br>
        /// </remarks>
        private void SetUpdateDepositData(UpdateDepositParameter updateDepositParameter, DataRow[] drDmdSalesList, out ArrayList alCreateDepsitMainWork)
        {
            alCreateDepsitMainWork = new ArrayList();

            foreach (DataRow dr in drDmdSalesList)
            {
                // �����X�V�f�[�^
                CreateDepsitMainWork createDepsitMainWork = new CreateDepsitMainWork();

                // �� 20070131 18322 c MA.NS�p�ɕύX
                #region SF �S�ăR�����g�A�E�g
                //// �󒍔ԍ�
                //createDepsitMainWork.AcceptAnOrderNo = Convert.ToInt32(dr[ctAcceptAnOrderNo]);
                //
                //// ��������R�[�h
                //createDepsitMainWork.DepositKindCode = updateDepositParameter.DepositKindCode;
                //
                //// ���Ӑ�R�[�h
                //createDepsitMainWork.CustomerCode = Convert.ToInt32(dr[ctCustomerCode]);
                //
                //// �a����敪
                //createDepsitMainWork.DepositCd = updateDepositParameter.DepositCd;
                //
                //// �`�[�E�v (�����l)
                //createDepsitMainWork.Outline = "";
                //
                //// �������͋��_�R�[�h
                //createDepsitMainWork.InputDepositSecCd = updateDepositParameter.LoginSectionCode;
                //
                //// �������t
                //createDepsitMainWork.DepositDate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);
                //
                //// �v�㋒�_�R�[�h
                //createDepsitMainWork.AddUpSecCode = updateDepositParameter.AddSectionCode;
                //
                //// �v����t
                //createDepsitMainWork.AddUpADate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);
                //
                //// �X�V���_�R�[�h
                //createDepsitMainWork.UpdateSecCd = updateDepositParameter.LoginSectionCode;
                //
                //// �������햼��
                //createDepsitMainWork.DepositKindName = (string)depositRelDataAcs.SlMoneyKindCode[updateDepositParameter.DepositKindCode];
                //
                //// �����S���҃R�[�h
                //createDepsitMainWork.DepositAgentCode = updateDepositParameter.EmployeeCd;
                //
                //// ��������敪
                //createDepsitMainWork.DepositKindDivCd = (int)depositRelDataAcs.HtMoneyKindDiv[updateDepositParameter.DepositKindCode];
                //
                //// �萔�������z ���� (�����l)
                //createDepsitMainWork.FeeDeposit = 0;
                //
                //// �萔�������z �� (�����l)
                //createDepsitMainWork.AcpOdrChargeDeposit = 0;
                //
                //// �萔�������z ����p (�����l)
                //createDepsitMainWork.VarCostChargeDeposit = 0;
                //
                //// �l�������z ���� (�����l)
                //createDepsitMainWork.DiscountDeposit = 0;
                //
                //// �l�������z �� (�����l)
                //createDepsitMainWork.AcpOdrDisDeposit = 0;
                //
                //// �l�������z ����p (�����l)
                //createDepsitMainWork.VarCostDisDeposit = 0;
                //
                //// �N���W�b�g�^���[���敪
                //createDepsitMainWork.CreditOrLoanCd = updateDepositParameter.CreditOrLoanCd;
                //
                //// �N���W�b�g��ЃR�[�h
                //createDepsitMainWork.CreditCompanyCode = updateDepositParameter.CreditCompanyCode;
                //
                //// �����z �� (���������z)
                //createDepsitMainWork.AcpOdrDeposit = Convert.ToInt64(dr[ctAcpOdrDepositAlwc_Alw]);
                //
                //// �����z ����p (���������z)
                //createDepsitMainWork.VariousCostDeposit = Convert.ToInt64(dr[ctVarCostDepoAlwc_Alw]);
                //
                //// �����z ���� (���������z)
                //createDepsitMainWork.Deposit = Convert.ToInt64(dr[ctDepositAllowance_Alw]);
                //
                //// ��`�U�o�� (�����l)
                //createDepsitMainWork.DraftDrawingDate = DateTime.MinValue;
                //
                //// ��`�x������ (�����l)
                //createDepsitMainWork.DraftPayTimeLimit = DateTime.MinValue;
                #endregion

                // �������͋��_�R�[�h
                createDepsitMainWork.InputDepositSecCd = updateDepositParameter.LoginSectionCode;

                // �v�㋒�_�R�[�h
                createDepsitMainWork.AddUpSecCode = updateDepositParameter.AddSectionCode;

                // �X�V���_�R�[�h
                createDepsitMainWork.UpdateSecCd = updateDepositParameter.LoginSectionCode;

                // 2007.10.05 upd start --------------------------------------------------->>
                // �������t
                //createDepsitMainWork.DepositDate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);
                createDepsitMainWork.DepositDate = TDateTime.GetSFDateNow();
                // 2007.10.05 upd end -----------------------------------------------------<<

                // �v����t
                createDepsitMainWork.AddUpADate = TDateTime.LongDateToDateTime(updateDepositParameter.DepositDate);

                // ��������R�[�h
                createDepsitMainWork.DepositKindCode = updateDepositParameter.DepositKindCode;

                // �������햼��
                createDepsitMainWork.DepositKindName = (string)depositRelDataAcs.SlMoneyKindCode[updateDepositParameter.DepositKindCode];

                // ��������敪
                createDepsitMainWork.DepositKindDivCd = (int)depositRelDataAcs.HtMoneyKindDiv[updateDepositParameter.DepositKindCode];

                // �����z�擾
                Int64 amountOfDrawing = Convert.ToInt64(dr[ctDepositAllowance_Alw]);

                // �����v
                createDepsitMainWork.DepositTotal = amountOfDrawing;

                // �������z
                createDepsitMainWork.Deposit = amountOfDrawing;

                // �萔�������z ���� (�����l)
                createDepsitMainWork.FeeDeposit = 0;

                // �l�������z ���� (�����l)
                createDepsitMainWork.DiscountDeposit = 0;

                // �C���Z���e�B�u�i���x�[�g�����z�j
                createDepsitMainWork.RebateDeposit = 0;

                // ���������敪(0:�ʏ����)
                createDepsitMainWork.AutoDepositCd = 0;

                // �a����敪()
                createDepsitMainWork.DepositCd = updateDepositParameter.DepositCd;

                // ��`�U�o�� (�����l)
                createDepsitMainWork.DraftDrawingDate = DateTime.MinValue;

                // ��`�x������ (�����l)
                createDepsitMainWork.DraftPayTimeLimit = DateTime.MinValue;

                // ��s�R�[�h
                createDepsitMainWork.BankCode = updateDepositParameter.BankCode;
                // ��s����
                createDepsitMainWork.BankName = updateDepositParameter.BankName;
                // ��`���
                createDepsitMainWork.DraftKind = updateDepositParameter.DraftKind;
                // ��`��ޖ���
                createDepsitMainWork.DraftKindName = updateDepositParameter.DraftKindName;
                // ��`�敪
                createDepsitMainWork.DraftDivide = updateDepositParameter.DraftDivide;
                // ��`�敪����
                createDepsitMainWork.DraftDivideName = updateDepositParameter.DraftDivideName;
                // ��`�ԍ�
                createDepsitMainWork.DraftNo = updateDepositParameter.DraftNo;

                #region �����[�g���Őݒ�H
                //// �����z ���� (���������z)
                //createDepsitMainWork.DepositAllowance = amountOfDrawing;
                //
                //// ���������c��
                //createDepsitMainWork.DepositAlwcBlnce = Convert.ToInt64(dr[ctDepositAlwcBlnce_Sales]);

                // �ԍ������A���ԍ�

                // �ŏI�����v���
                #endregion

                // �����S���҃R�[�h
                createDepsitMainWork.DepositAgentCode = updateDepositParameter.EmployeeCd;
                createDepsitMainWork.DepositAgentNm = updateDepositParameter.EmployeeName;

                SearchClaimSales searchClaimSales = dr[ctSearchClaimSales] as SearchClaimSales;
                if (searchClaimSales != null)
                {
                    // ������R�[�h
                    createDepsitMainWork.ClaimCode = searchClaimSales.ClaimCode;
                    // �����於1
                    createDepsitMainWork.ClaimName = searchClaimSales.ClaimName;
                    // �����於2
                    createDepsitMainWork.ClaimName2 = searchClaimSales.ClaimName2;
                    // �����旪��
                    createDepsitMainWork.ClaimSnm = searchClaimSales.ClaimSnm;

                    // ���Ӑ�R�[�h
                    createDepsitMainWork.CustomerCode = searchClaimSales.CustomerCode;
                    // ���Ӑ於1
                    createDepsitMainWork.CustomerName = searchClaimSales.CustomerName;
                    // ���Ӑ於2
                    createDepsitMainWork.CustomerName2 = searchClaimSales.CustomerName2;
                    // ���Ӑ旪��
                    createDepsitMainWork.CustomerSnm = searchClaimSales.CustomerSnm;

                    // �󒍃X�e�[�^�X
                    createDepsitMainWork.AcptAnOdrStatus = searchClaimSales.AcptAnOdrStatus;
                    // ����`�[�ԍ�
                    createDepsitMainWork.SalesSlipNum = searchClaimSales.SalesSlipNum;
                }

                // �`�[�E�v (�����l)
                createDepsitMainWork.Outline = "";

                // �� 20070131 18322 c

                // �z��ɒǉ�
                alCreateDepsitMainWork.Add(createDepsitMainWork);
            }

        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL Partsman�p�ɕύX

        #region 2008/06/26 DEL �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// �����f�[�^�X�V����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="createDepsitMainWorkList">�����}�X�^(�X�V�p)</param>
		/// <param name="depositSlipNoList">�V�K�ۑ����������ԍ�</param>
		/// <remarks>
		/// <br>Note       : �����}�X�^�̍X�V���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void WriteDepositData(string enterpriseCode, CreateDepsitMainWork[] createDepsitMainWorkList, out int[] depositSlipNoList)
		{
			string message;

			int st = _depsitMainAcs.WriteDB(enterpriseCode, createDepsitMainWorkList, out depositSlipNoList, out message);

			// �G���[�̎��͗�O�𔭐�������
			if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				throw new DepositException(message, st);
			}
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        #endregion 2008/06/26 DEL �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
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
            depsitDataWork.SubSectionCode = depsitMain.SubSectionCode;
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

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���������}�X�^�˓��������}�X�^���[�N�j
        /// </summary>
        /// <param name="depositAlwList">���������}�X�^�N���X</param>
        /// <returns>�����}�X�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note        : ���������}�X�^�N���X��������}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/06/26</br>
        /// <br>Update Note : 2012/02/10 �c����</br>
        /// <br>�Ǘ��ԍ�    : 10707327-00 2012/03/28�z�M��</br>
        /// <br>              Redmine#28395 �����ۑ��G���[�����̑Ή�</br>
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
                // ----- DEL 2012/02/10 �c���� Redmine#28395 --------------------------------------->>>>>
                //depositAlwWork.CustomerCode = depositAlw.CustomerCode;                  // ���Ӑ�R�[�h
                //depositAlwWork.CustomerName = depositAlw.CustomerName;                  // ���Ӑ於��
                //depositAlwWork.CustomerName2 = depositAlw.CustomerName2;                // ���Ӑ於��2
                // ----- DEL 2012/02/10 �c���� Redmine#28395 ---------------------------------------<<<<<
                // ----- ADD 2012/02/10 �c���� Redmine#28395 --------------------------------------->>>>>
                depositAlwWork.CustomerCode = depositAlw.ClaimCode;                     // ������R�[�h
                depositAlwWork.CustomerName = depositAlw.ClaimName;                     // �����於��
                depositAlwWork.CustomerName2 = depositAlw.ClaimName2;                   // �����於��2
                // ----- ADD 2012/02/10 �c���� Redmine#28395 ---------------------------------------<<<<<
                depositAlwWork.AcptAnOdrStatus = depositAlw.AcptAnOdrStatus;            // �󒍃X�e�[�^�X
                depositAlwWork.SalesSlipNum = depositAlw.SalesSlipNum;                  // ����`�[�ԍ�
                depositAlwWork.DebitNoteOffSetCd = depositAlw.DebitNoteOffSetCd;        // �ԓ`���E�敪

                arrDepositAlw.Add(depositAlwWork);
            }

            DepositAlwWork[] list = (DepositAlwWork[])arrDepositAlw.ToArray(typeof(DepositAlwWork));

            return list;
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
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
		# endregion

		# region Public class SearchSalesParameter
        // �� 20070125 18322 c MA.NS�p�ɕύX
        #region SF ����������擾�p�p�����[�^�i�S�ăR�����g�A�E�g�j
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
		//	/// <summary>�󒍔ԍ�</summary>
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
		//	/// <summary>�󒍔ԍ� �v���p�e�B</summary>
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
        #endregion

        #region ����������擾�p�p�����[�^
		/// public class name:   SearchSalesParameter
		/// <summary>
		///                      ����������擾�p�p�����[�^
		/// </summary>
		/// <remarks>
		/// <br>note             :   ����������擾�p�p�����[�^�w�b�_�t�@�C��</br>
		/// <br>Programmer       :   ��������</br>
		/// <br>Date             :   �ؑ� ����</br>
		/// <br>Genarated Date   :   2007/05/14  (CSharp File Generated Date)</br>
		/// <br>Update Note      :   </br>
		/// </remarks>
		public class SearchSalesParameter
		{
			/// <summary>��ƃR�[�h</summary>
			/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
			private string _enterpriseCode = "";
	
			/// <summary>�󒍃X�e�[�^�X</summary>
			/// <remarks>1:�\��,2:�\��L�����Z��,10:����,11:���σL�����Z��20:��,21:�󒍃L�����Z��,30:����,40:����,45:���،v��,50:�ϑ�,55:�ϑ��v��</remarks>
			private Int32[] _acptAnOdrStatus = null;
	
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
			/// <remarks>0:OFF,1:ON</remarks>
			private Int32 _serviceSlipCd;
	
			/// <summary>���|�敪</summary>
			/// <remarks>0:���|�Ȃ�,1:���|</remarks>
			private Int32 _accRecDivCd;
	
			/// <summary>���������敪</summary>
			/// <remarks>0:�ʏ����,1:��������</remarks>
			private Int32 _autoDepositCd;
	
			/// <summary>��Ɩ���</summary>
			private string _enterpriseName = "";
	
			/// <summary>���ьv�㋒�_����</summary>
			private string _resultsAddUpSecNm = "";
	
			/// <summary>�̔��]�ƈ�����</summary>
			private string _salesEmployeeNm = "";
	
	
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
			/// <value>0:OFF,1:ON</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �T�[�r�X�`�[�敪�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public Int32 ServiceSlipCd
			{
				get{return _serviceSlipCd;}
				set{_serviceSlipCd = value;}
			}
	
			/// public propaty name  :  AccRecDivCd
			/// <summary>���|�敪�v���p�e�B</summary>
			/// <value>0:���|�Ȃ�,1:���|</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   ���|�敪�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public Int32 AccRecDivCd
			{
				get{return _accRecDivCd;}
				set{_accRecDivCd = value;}
			}
	
			/// public propaty name  :  AutoDepositCd
			/// <summary>���������敪�v���p�e�B</summary>
			/// <value>0:�ʏ����,1:��������</value>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   ���������敪�v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public Int32 AutoDepositCd
			{
				get{return _autoDepositCd;}
				set{_autoDepositCd = value;}
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
	
			/// public propaty name  :  ResultsAddUpSecNm
			/// <summary>���ьv�㋒�_���̃v���p�e�B</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   ���ьv�㋒�_���̃v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public string ResultsAddUpSecNm
			{
				get{return _resultsAddUpSecNm;}
				set{_resultsAddUpSecNm = value;}
			}
	
			/// public propaty name  :  SalesEmployeeNm
			/// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
			/// ----------------------------------------------------------------------
			/// <remarks>
			/// <br>note             :   �̔��]�ƈ����̃v���p�e�B</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public string SalesEmployeeNm
			{
				get{return _salesEmployeeNm;}
				set{_salesEmployeeNm = value;}
			}
	
	
			/// <summary>
			/// ����������擾�p�p�����[�^�R���X�g���N�^
			/// </summary>
			/// <returns>SearchSalesParameter�N���X�̃C���X�^���X</returns>
			/// <remarks>
			/// <br>Note�@�@�@�@�@�@ :   SearchSalesParameter�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
			/// <br>Programer        :   ��������</br>
			/// </remarks>
			public SearchSalesParameter()
			{
			}
	
		}
        #endregion
        // �� 20070125 18322 c
        # endregion

        # region Public class UpdateDepositParameter
        /// <summary>�����X�V�p�p�����[�^</summary>
		public class UpdateDepositParameter
        {
            // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
            /// <summary>��ƃR�[�h</summary>
            private string _enterpriseCode;

            /// <summary>�����ԍ�(�X�V��)</summary>
            private Int32 _depositSlipNo;

            /// <summary>�󒍃X�e�[�^�X</summary>
            /// <value>10:���� 20:�� 30:���� 40:�o��</value>
            private Int32 _acptAnOdrStatus;

            /// <summary>����`�[�ԍ�</summary>
            private String _salesSlipNum = "";

            /// <summary>�������͋��_�R�[�h</summary>
            private String _inputDepositSecCd = "";

            /// <summary>�v�㋒�_�R�[�h</summary>
            private String _addUpSecCode = "";

            /// <summary>�X�V���_�R�[�h</summary>
            private String _updateSecCode = "";

            /// <summary>����R�[�h</summary>
            private Int32 _subSectionCode;

            /// <summary>�������t</summary>
            /// <value>YYYYMMDD</value>
            private Int32 _depositDate;

            /// <summary>�v����t</summary>
            /// <value>YYYYMMDD</value>
            private Int32 _addUpDate;

            /// <summary>�����v</summary>
            /// <value>�������z�{�萔�������z�{�l�������z</value>
            private Int64 _depositTotal;

            /// <summary>�������z</summary>
            private Int64 _deposit;

            /// <summary>�萔�������z</summary>
            private Int64 _feeDeposit;

            /// <summary>�l�������z</summary>
            private Int64 _discountDeposit;

            /// <summary>���������敪</summary>
            /// <value>0:�ʏ���� 1:��������</value>
            private Int32 _autoDepositCd;

            /// <summary>��`�U�o��</summary>
            /// <value>YYYYMMDD</value>
            private Int32 _draftDrawingDate;

            /// <summary>��`���</summary>
            private Int32 _draftKind;

            /// <summary>��`��ޖ���</summary>
            private String _draftKindName = "";

            /// <summary>��`�敪</summary>
            private Int32 _draftDivide;

            /// <summary>��`�敪����</summary>
            private String _draftDivideName = "";

            /// <summary>��`�ԍ�</summary>
            private String _draftNo = "";

            /// <summary>�����S���҃R�[�h</summary>
            private String _depositAgentCode = "";

            /// <summary>�����S���Җ���</summary>
            private String _depositAgentNm = "";

            /// <summary>�������͎҃R�[�h</summary>
            private String _depositInputAgentCd = "";

            /// <summary>�������͎Җ���</summary>
            private String _depositInputAgentNm = "";

            /// <summary>���Ӑ�R�[�h</summary>
            private Int32 _customerCode;

            /// <summary>���Ӑ於��</summary>
            private String _customerName = "";

            /// <summary>���Ӑ於��2</summary>
            private String _customerName2 = "";

            /// <summary>���Ӑ旪��</summary>
            private String _customerSnm = "";

            /// <summary>������R�[�h</summary>
            private Int32 _claimCode;

            /// <summary>�����於��</summary>
            private String _claimName = "";

            /// <summary>�����於��2</summary>
            private String _claimName2 = "";

            /// <summary>�����旪��</summary>
            private String _claimSnm = "";

            /// <summary>�`�[�E�v</summary>
            private String _outline = "";

            /// <summary>��s�R�[�h</summary>
            private Int32 _bankCode;

            /// <summary>��s����</summary>
            private String _bankName = "";

            /// <summary>�����s�ԍ�</summary>
            private Int32 _depositRowNo;

            /// <summary>����R�[�h</summary>
            private Int32 _moneyKindCode;

            /// <summary>���햼��</summary>
            private String _moenyKindName = "";

            /// <summary>����敪</summary>
            private Int32 _moneyKindDiv;

            /// <summary>�L������</summary>
            /// <value>YYYYMMDD</value>
            private Int32 _validityTerm;

            /// <summary>��ƃR�[�h �v���p�e�B</summary>
            public String EnterpriseCode
            {
                get { return _enterpriseCode; }
                set { _enterpriseCode = value; }
            }

            /// <summary>�����ԍ�(�X�V��)</summary>
            public Int32 DepositSlipNo
            {
                get { return _depositSlipNo; }
                set { _depositSlipNo = value; }
            }

            /// <summary>�󒍃X�e�[�^�X �v���p�e�B</summary>
            /// <value>10:���� 20:�� 30:���� 40:�o��</value>
            public Int32 AcptAnOdrStatus
            {
                get { return _acptAnOdrStatus; }
                set { _acptAnOdrStatus = value; }
            }

            /// <summary>����`�[�ԍ� �v���p�e�B</summary>
            public String SalesSlipNum
            {
                get { return _salesSlipNum; }
                set { _salesSlipNum = value; }
            }

            /// <summary>�������͋��_�R�[�h �v���p�e�B</summary>
            public String InputDepositSecCd
            {
                get { return _inputDepositSecCd; }
                set { _inputDepositSecCd = value; }
            }

            /// <summary>�v�㋒�_�R�[�h �v���p�e�B</summary>
            public String AddUpSecCode
            {
                get { return _addUpSecCode; }
                set { _addUpSecCode = value; }
            }

            /// <summary>�X�V���_�R�[�h �v���p�e�B</summary>
            public String UpdateSecCode
            {
                get { return _updateSecCode; }
                set { _updateSecCode = value; }
            }

            /// <summary>����R�[�h �v���p�e�B</summary>
            public Int32 SubSectionCode
            {
                get { return _subSectionCode; }
                set { _subSectionCode = value; }
            }

            /// <summary>�������t �v���p�e�B</summary>
            /// <value>YYYYMMDD</value>
            public Int32 DepositDate
            {
                get { return _depositDate; }
                set { _depositDate = value; }
            }

            /// <summary>�v����t �v���p�e�B</summary>
            /// <value>YYYYMMDD</value>
            public Int32 AddUpDate
            {
                get { return _addUpDate; }
                set { _addUpDate = value; }
            }

            /// <summary>�����v �v���p�e�B</summary>
            /// <value>�������z�{�萔�������z�{�l�������z</value>
            public Int64 DepositTotal
            {
                get { return _depositTotal; }
                set { _depositTotal = value; }
            }

            /// <summary>�������z �v���p�e�B</summary>
            public Int64 Deposit
            {
                get { return _deposit; }
                set { _deposit = value; }
            }

            /// <summary>�萔�������z �v���p�e�B</summary>
            public Int64 FeeDeposit
            {
                get { return _feeDeposit; }
                set { _feeDeposit = value; }
            }

            /// <summary>�l�������z �v���p�e�B</summary>
            public Int64 DiscountDeposit
            {
                get { return _discountDeposit; }
                set { _discountDeposit = value; }
            }

            /// <summary>���������敪 �v���p�e�B</summary>
            public Int32 AutoDepositCd
            {
                get { return _autoDepositCd; }
                set { _autoDepositCd = value; }
            }

            /// <summary>��`�U�o�� �v���p�e�B</summary>
            /// <value>YYYYMMDD</value>
            public Int32 DraftDrawingDate
            {
                get { return _draftDrawingDate; }
                set { _draftDrawingDate = value; }
            }

            /// <summary>��`��� �v���p�e�B</summary>
            public Int32 DraftKind
            {
                get { return _draftKind; }
                set { _draftKind = value; }
            }

            /// <summary>��`��ޖ��� �v���p�e�B</summary>
            public String DraftKindName
            {
                get { return _draftKindName; }
                set { _draftKindName = value; }
            }

            /// <summary>��`�敪 �v���p�e�B</summary>
            public Int32 DraftDivide
            {
                get { return _draftDivide; }
                set { _draftDivide = value; }
            }

            /// <summary>��`�敪���� �v���p�e�B</summary>
            public String DraftDivideName
            {
                get { return _draftDivideName; }
                set { _draftDivideName = value; }
            }

            /// <summary>��`�ԍ� �v���p�e�B</summary>
            public String DraftNo
            {
                get { return _draftNo; }
                set { _draftNo = value; }
            }

            /// <summary>�����S���҃R�[�h �v���p�e�B</summary>
            public String DepositAgentCode
            {
                get { return _depositAgentCode; }
                set { _depositAgentCode = value; }
            }

            /// <summary>�����S���Җ��� �v���p�e�B</summary>
            public String DepositAgentNm
            {
                get { return _depositAgentNm; }
                set { _depositAgentNm = value; }
            }

            /// <summary>�������͎҃R�[�h �v���p�e�B</summary>
            public String DepositInputAgentCd
            {
                get { return _depositInputAgentCd; }
                set { _depositInputAgentCd = value; }
            }

            /// <summary>�������͎Җ��� �v���p�e�B</summary>
            public String DepositInputAgentNm
            {
                get { return _depositInputAgentNm; }
                set { _depositInputAgentNm = value; }
            }

            /// <summary>���Ӑ�R�[�h �v���p�e�B</summary>
            public Int32 CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }

            /// <summary>���Ӑ於�� �v���p�e�B</summary>
            public String CustomerName
            {
                get { return _customerName; }
                set { _customerName = value; }
            }

            /// <summary>���Ӑ於��2 �v���p�e�B</summary>
            public String CustomerName2
            {
                get { return _customerName2; }
                set { _customerName2 = value; }
            }

            /// <summary>���Ӑ旪�� �v���p�e�B</summary>
            public String CustomerSnm
            {
                get { return _customerSnm; }
                set { _customerSnm = value; }
            }

            /// <summary>������R�[�h �v���p�e�B</summary>
            public Int32 ClaimCode
            {
                get { return _claimCode; }
                set { _claimCode = value; }
            }

            /// <summary>�����於�� �v���p�e�B</summary>
            public String ClaimName
            {
                get { return _claimName; }
                set { _claimName = value; }
            }

            /// <summary>�����於��2 �v���p�e�B</summary>
            public String ClaimName2
            {
                get { return _claimName2; }
                set { _claimName2 = value; }
            }

            /// <summary>�����旪�� �v���p�e�B</summary>
            public String ClaimSnm
            {
                get { return _claimSnm; }
                set { _claimSnm = value; }
            }

            /// <summary>�`�[�E�v �v���p�e�B</summary>
            public String Outline
            {
                get { return _outline; }
                set { _outline = value; }
            }

            /// <summary>��s�R�[�h �v���p�e�B</summary>
            public Int32 BankCode
            {
                get { return _bankCode; }
                set { _bankCode = value; }
            }

            /// <summary>��s���� �v���p�e�B</summary>
            public String BankName
            {
                get { return _bankName; }
                set { _bankName = value; }
            }

            /// <summary>�����s�ԍ� �v���p�e�B</summary>
            public Int32 DepositRowNo
            {
                get { return _depositRowNo; }
                set { _depositRowNo = value; }
            }

            /// <summary>����R�[�h �v���p�e�B</summary>
            public Int32 MoneyKindCode
            {
                get { return _moneyKindCode; }
                set { _moneyKindCode = value; }
            }

            /// <summary>���햼�� �v���p�e�B</summary>
            public String MoenyKindName
            {
                get { return _moenyKindName; }
                set { _moenyKindName = value; }
            }

            /// <summary>����敪 �v���p�e�B</summary>
            public Int32 MoneyKindDiv
            {
                get { return _moneyKindDiv; }
                set { _moneyKindDiv = value; }
            }

            /// <summary>�L������ �v���p�e�B</summary>
            public Int32 ValidityTerm
            {
                get { return _validityTerm; }
                set { _validityTerm = value; }
            }

            /// <summary>�N���[��</summary>
            public UpdateDepositParameter Clone()
            {
                UpdateDepositParameter ret = new UpdateDepositParameter();

                ret.EnterpriseCode = this._enterpriseCode;
                ret.DepositSlipNo = this._depositSlipNo;
                ret.AcptAnOdrStatus = this._acptAnOdrStatus;
                ret.SalesSlipNum = this._salesSlipNum;
                ret.InputDepositSecCd = this._inputDepositSecCd;
                ret.AddUpSecCode = this._addUpSecCode;
                ret.UpdateSecCode = this._updateSecCode;
                ret.SubSectionCode = this._subSectionCode;
                ret.DepositDate = this._depositDate;
                ret.AddUpDate = this._addUpDate;
                ret.DepositTotal = this._depositTotal;
                ret.Deposit = this._deposit;
                ret.FeeDeposit = this._feeDeposit;
                ret.DiscountDeposit = this._discountDeposit;
                ret.AutoDepositCd = this._autoDepositCd;
                ret.DraftDrawingDate = this._draftDrawingDate;
                ret.DraftKind = this._draftKind;
                ret.DraftKindName = this._draftKindName;
                ret.DraftDivide = this._draftDivide;
                ret.DraftDivideName = this._draftDivideName;
                ret.DraftNo = this._draftNo;
                ret.DepositAgentCode = this._depositAgentCode;
                ret.DepositAgentNm = this._depositAgentNm;
                ret.DepositInputAgentCd = this._depositInputAgentCd;
                ret.DepositInputAgentNm = this._depositInputAgentNm;
                ret.CustomerCode = this._customerCode;
                ret.CustomerName = this._customerName;
                ret.CustomerName2 = this._customerName2;
                ret.CustomerSnm = this._customerSnm;
                ret.ClaimCode = this._claimCode;
                ret.ClaimName = this._claimName;
                ret.ClaimName2 = this._claimName2;
                ret.ClaimSnm = this._claimSnm;
                ret.Outline = this._outline;
                ret.BankCode = this._bankCode;
                ret.BankName = this._bankName;
                ret.DepositRowNo = this._depositRowNo;
                ret.MoneyKindCode = this._moneyKindCode;
                ret.MoenyKindName = this._moenyKindName;
                ret.MoneyKindDiv = this._moneyKindDiv;
                ret.ValidityTerm = this._validityTerm;

                return ret;
            }
            // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
            
            #region 2008/06/26 DEL Partsman�p�ɕύX
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			/// <summary>�R���X�g���N�^</summary>
			public UpdateDepositParameter()
			{
				_enterpriseCode = "";
				_loginSectionCode = "";
				_addSectionCode = "";
				_employeeCd = "";
				_depositDate = 0;
				_depositCd = 0;
				_depositKindCode = 0;
				_depositSlipNo = 0;
                // �� 20070131 18322 c MA.NS�p�ɕύX
                _employeeName = "";
                // �� 20070131 18322 c
                _bankCode = 0;
                _bankName = "";
                _draftKind = 0;
                _draftKindName = "";
                _draftDivide = 0;
                _draftDivideName = "";
                _draftNo = "";
            }

			/// <summary>��ƃR�[�h</summary>
			private string _enterpriseCode;
			/// <summary>���O�C�����_</summary>
			private string _loginSectionCode;
			/// <summary>�v�㋒�_</summary>
			private string _addSectionCode;
			/// <summary>�]�ƈ��R�[�h</summary>
			private string _employeeCd;
			/// <summary>������</summary>
			private Int32 _depositDate;
			/// <summary>�a����敪</summary>
			private Int32 _depositCd;
			/// <summary>����R�[�h</summary>
			private Int32 _depositKindCode;
			/// <summary>�����ԍ�(�X�V��)</summary>
			private Int32 _depositSlipNo;
            // �� 20070131 18322 c MA.NS�p�ɕύX
			/// <summary>�]�ƈ���</summary>
            private string _employeeName;
            // �� 20070131 18322 c
            /// <summary>��s�R�[�h</summary>
            private Int32 _bankCode;
            /// <summary>��s����</summary>
            private string _bankName;
            /// <summary>��`���</summary>
            private Int32 _draftKind;
            /// <summary>��`��ޖ���</summary>
            private string _draftKindName;
            /// <summary>��`�敪</summary>
            private Int32 _draftDivide;
            /// <summary>��`�敪����</summary>
            private string _draftDivideName;
            /// <summary>��`�ԍ�</summary>
            private string _draftNo;

               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            /// <summary>��ƃR�[�h �v���p�e�B</summary>
			public string EnterpriseCode
			{
				get{return _enterpriseCode;}
				set{_enterpriseCode = value;}
			}
			/// <summary>���O�C�����_ �v���p�e�B</summary>
			public string LoginSectionCode
			{
				get{return _loginSectionCode;}
				set{_loginSectionCode = value;}
			}
			/// <summary>�v�㋒�_ �v���p�e�B</summary>
			public string AddSectionCode
			{
				get{return _addSectionCode;}
				set{_addSectionCode = value;}
			}
			/// <summary>�]�ƈ��R�[�h �v���p�e�B</summary>
			public string EmployeeCd
			{
				get{return _employeeCd;}
				set{_employeeCd = value;}
			}
			/// <summary>������ �v���p�e�B</summary>
			public Int32 DepositDate
			{
				get{return _depositDate;}
				set{_depositDate = value;}
			}
			/// <summary>�a����敪 �v���p�e�B</summary>
			public Int32 DepositCd
			{
				get{return _depositCd;}
				set{_depositCd = value;}
			}
			/// <summary>����R�[�h �v���p�e�B</summary>
			public Int32 DepositKindCode
			{
				get{return _depositKindCode;}
				set{_depositKindCode = value;}
			}
			/// <summary>�����ԍ�(�X�V��)</summary>
			public Int32 DepositSlipNo
			{
				get { return _depositSlipNo; }
				set { _depositSlipNo = value; }
			}

            // �� 20070131 18322 c MA.NS�p�ɕύX
			/// <summary>�]�ƈ���</summary>
			public string EmployeeName
			{
				get { return _employeeName; }
				set { _employeeName = value; }
			}
            // �� 20070131 18322 c

			/// <summary>��s�R�[�h �v���p�e�B</summary>
			public Int32 BankCode
			{
				get{return _bankCode;}
				set{_bankCode = value;}
			}

			/// <summary>��s����</summary>
			public string BankName
			{
				get { return _bankName; }
				set { _bankName = value; }
			}
			/// <summary>��`��� �v���p�e�B</summary>
			public Int32 DraftKind
			{
				get{return _draftKind;}
				set{_draftKind = value;}
			}

			/// <summary>��`��ޖ���</summary>
			public string DraftKindName
			{
				get { return _draftKindName; }
				set { _draftKindName = value; }
			}
			/// <summary>��`�敪 �v���p�e�B</summary>
			public Int32 DraftDivide
			{
				get{return _draftDivide;}
				set{_draftDivide = value;}
			}

			/// <summary>��`�敪����</summary>
			public string DraftDivideName
			{
				get { return _draftDivideName; }
				set { _draftDivideName = value; }
			}

			/// <summary>��`�ԍ�</summary>
			public string DraftNo
			{
				get { return _draftNo; }
				set { _draftNo = value; }
			}
            
            /// <summary>�N���[��</summary>
            public UpdateDepositParameter Clone()
            {
                UpdateDepositParameter ret = new UpdateDepositParameter();

                ret.EnterpriseCode = _enterpriseCode;
                ret.LoginSectionCode = _loginSectionCode;
                ret.AddSectionCode = _addSectionCode;
                ret.EmployeeCd = _employeeCd;
                ret.DepositDate = _depositDate;
                ret.DepositCd = _depositCd;
                ret.DepositKindCode = _depositKindCode;
                ret.DepositSlipNo = _depositSlipNo;
                // �� 20070131 18322 c MA.NS�p�ɕύX
                ret.EmployeeName = _employeeName;
                // �� 20070131 18322 c
                ret.BankCode = _bankCode;
                ret.BankName = _bankName;
                ret.DraftKind = _draftKind;
                ret.DraftKindName = _draftKindName;
                ret.DraftDivide = _draftDivide;
                ret.DraftDivideName = _draftDivideName; 
                ret.DraftNo = _draftNo;

                return ret;
            }
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            #endregion 2008/06/26 DEL Partsman�p�ɕύX
        }
		# endregion
	}
}
